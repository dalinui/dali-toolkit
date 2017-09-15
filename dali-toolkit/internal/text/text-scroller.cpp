/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

// CLASS HEADER
#include <dali-toolkit/internal/text/text-scroller.h>

// EXTERNAL INCLUDES
#include <dali/public-api/common/stage.h>
#include <dali/public-api/images/frame-buffer-image.h>
#include <dali/public-api/render-tasks/render-task-list.h>
#include <dali/public-api/rendering/geometry.h>
#include <dali/public-api/rendering/renderer.h>
#include <dali/public-api/rendering/sampler.h>
#include <dali/public-api/rendering/shader.h>
#include <dali/devel-api/images/texture-set-image.h>
#include <dali/integration-api/debug.h>

// INTERNAL INCLUDES
#include <dali-toolkit/internal/text/text-scroller-interface.h>

namespace Dali
{

namespace Toolkit
{

namespace
{

#if defined ( DEBUG_ENABLED )
  Debug::Filter* gLogFilter = Debug::Filter::New(Debug::NoLogging, true, "LOG_TEXT_SCROLLING");
#endif

const int MINIMUM_SCROLL_SPEED = 1; // Speed should be set by Property system.

const char* VERTEX_SHADER_SCROLL = DALI_COMPOSE_SHADER(
  attribute mediump vec2 aPosition;\n
  varying highp vec2 vTexCoord;\n
  varying highp float vRatio;\n
  uniform mediump mat4 uModelMatrix;\n
  uniform mediump mat4 uViewMatrix;\n
  uniform mediump mat4 uProjection;\n
  uniform mediump vec3 uSize;\n
  uniform mediump float uDelta;\n
  uniform mediump vec2 uTextureSize;
  uniform mediump float uGap;\n
  uniform mediump float uAlign;\n
  \n
  void main()\n
  {\n
    {\n
      highp vec4 vertexPosition = vec4(aPosition*uSize.xy, 0.0, 1.0);\n
      vertexPosition = uViewMatrix *  uModelMatrix  * vertexPosition ;\n
      vertexPosition.x = floor( vertexPosition.x ) + 0.5;
      vertexPosition.y = floor( vertexPosition.y ) + 0.5;
      float smallTextPadding = max(uSize.x - uTextureSize.x, 0. );\n
      float gap = max( uGap, smallTextPadding );\n
      float delta = floor ( uDelta ) + 0.5;
      vTexCoord.x = ( delta  + ( uAlign * ( uTextureSize.x - uSize.x ) ) + (  aPosition.x * uSize.x ) )/ ( uTextureSize.x + gap );\n
      vTexCoord.y = ( 0.5 + floor(  aPosition.y * uSize.y ) )/ ( uTextureSize.y ) ;\n
      vRatio = uTextureSize.x / ( uTextureSize.x + gap );\n
      gl_Position = uProjection * vertexPosition;
    }\n
  }\n
);

const char* FRAGMENT_SHADER = DALI_COMPOSE_SHADER(
  varying highp vec2 vTexCoord;\n
  varying highp float vRatio;\n
  uniform sampler2D sTexture;\n
  \n
  void main()\n
  {\n
    highp vec2 texCoord;\n
    texCoord.y = vTexCoord.y;\n
    texCoord.x = fract( vTexCoord.x ) / vRatio;\n
    if ( texCoord.x > 1.0 )\n
      discard;\n
    \n
    gl_FragColor = texture2D( sTexture, texCoord );\n
  }\n
);

/**
 * @brief How the text should be aligned when scrolling the text.
 *
 * 0.0f aligns the text to the left, 1.0f aligns the text to the right.
 * The final alignment depends on three factors:
 *   1) The alignment value of the text label (Use Text::Layout::HorizontalAlignment enumerations).
 *   2) The text direction, i.e. whether it's LTR or RTL (0 = LTR, 1 = RTL).
 *   3) Whether the text is greater than the size of the control ( 0 = Text width <= Control width, 1 = Text width > Control width ).
 */
const float ALIGNMENT_TABLE[ Text::Layout::HORIZONTAL_ALIGN_COUNT ][ 2 ][ 2 ] =
{
  // HORIZONTAL_ALIGN_BEGIN
  {
    { // LTR
      0.0f, // Text width <= Control width
      0.0f  // Text width >  Control width
    },
    { // RTL
      1.0f, // Text width <= Control width
      1.0f  // Text width >  Control width
    }
  },

  // HORIZONTAL_ALIGN_CENTER
  {
    { // LTR
      0.5f, // Text width <= Control width
      0.0f  // Text width >  Control width
    },
    { // RTL
      0.5f, // Text width <= Control width
      1.0f  // Text width >  Control width
    }
  },

  // HORIZONTAL_ALIGN_END
  {
    { // LTR
      1.0f, // Text width <= Control width
      0.0f  // Text width >  Control width
    },
    { // RTL
      0.0f, // Text width <= Control width
      1.0f  // Text width >  Control width
    }
  }
};

/**
 * @brief Create and set up a camera for the render task to use
 *
 * @param[in] sizeOfTarget size of the source camera to look at
 * @param[out] offscreenCamera custom camera
 */
void CreateCameraActor( const Size& sizeOfTarget, CameraActor& offscreenCamera )
{
  offscreenCamera = CameraActor::New();
  offscreenCamera.SetOrthographicProjection( sizeOfTarget );
  offscreenCamera.SetInvertYAxis( true );
}

/**
 * @brief Create a render task
 *
 * @param[in] sourceActor actor to be used as source
 * @param[in] cameraActor camera looking at source
 * @param[in] offscreenTarget resulting image from render task
 * @param[out] renderTask render task that has been setup
 */
void CreateRenderTask( Actor sourceActor, CameraActor cameraActor , FrameBufferImage offscreenTarget, RenderTask& renderTask )
{
  Stage stage = Stage::GetCurrent();
  RenderTaskList taskList = stage.GetRenderTaskList();
  renderTask = taskList.CreateTask();
  renderTask.SetSourceActor( sourceActor );
  renderTask.SetExclusive( true );
  renderTask.SetInputEnabled( false );
  renderTask.SetClearEnabled( true );
  renderTask.SetCameraActor( cameraActor );
  renderTask.SetTargetFrameBuffer( offscreenTarget );
  renderTask.SetClearColor( Color::TRANSPARENT );
  renderTask.SetCullMode( false );
}

/**
 * @brief Create quad geometry for the mesh
 *
 * @param[out] geometry quad geometry that can be used for a mesh
 */
void CreateGeometry( Geometry& geometry )
{
  struct QuadVertex { Vector2 position;  };

  QuadVertex quadVertexData[4] =
  {
      { Vector2( 0.0f, 0.0f) },
      { Vector2( 1.0f, 0.0f) },
      { Vector2( 0.0f, 1.0f) },
      { Vector2( 1.0f, 1.0f) },
  };

  const unsigned short indices[6] =
  {
     3,1,0,0,2,3
  };

  Property::Map quadVertexFormat;
  quadVertexFormat["aPosition"] = Property::VECTOR2;
  PropertyBuffer quadVertices = PropertyBuffer::New( quadVertexFormat );
  quadVertices.SetData(quadVertexData, 4 );

  geometry = Geometry::New();
  geometry.AddVertexBuffer( quadVertices );
  geometry.SetIndexBuffer( indices, sizeof(indices)/sizeof(indices[0]) );
}


/**
 * @brief Create a renderer
 *
 * @param[in] frameBufferImage texture to be used
 * @param[out] renderer mesh renderer using the supplied texture
 */
void CreateRenderer( FrameBufferImage frameBufferImage, Dali::Renderer& renderer )
{
  Shader shader = Shader::New( VERTEX_SHADER_SCROLL , FRAGMENT_SHADER, Shader::Hint::NONE );

  Sampler sampler = Sampler::New();
  sampler.SetFilterMode(FilterMode::LINEAR, FilterMode::LINEAR );

  TextureSet textureSet = TextureSet::New();
  TextureSetImage( textureSet, 0u, frameBufferImage );
  textureSet.SetSampler( 0u, sampler );

  Geometry meshGeometry;
  CreateGeometry( meshGeometry );

  renderer = Renderer::New( meshGeometry, shader );
  renderer.SetProperty( Renderer::Property::BLEND_PRE_MULTIPLIED_ALPHA, true );
  renderer.SetTextures( textureSet );
}

} // namespace

namespace Text
{

TextScrollerPtr TextScroller::New( ScrollerInterface& scrollerInterface )
{
  DALI_LOG_INFO( gLogFilter, Debug::Verbose, "TextScroller::New\n" );

  TextScrollerPtr textScroller( new TextScroller( scrollerInterface) );
  return textScroller;
}

void TextScroller::SetGap( int gap )
{
  DALI_LOG_INFO( gLogFilter, Debug::Verbose, "TextScroller::SetGap gap[%d]\n", gap );
  mWrapGap = static_cast<float>(gap);
}

int TextScroller::GetGap() const
{
  return static_cast<int>(mWrapGap);
}

void TextScroller::SetSpeed( int scrollSpeed )
{
  mScrollSpeed = std::max( MINIMUM_SCROLL_SPEED, scrollSpeed );
}

int TextScroller::GetSpeed() const
{
  return mScrollSpeed;
}

void TextScroller::SetLoopCount( int loopCount )
{
  if ( loopCount >= 0 )
  {
    mLoopCount = loopCount;
  }

  DALI_LOG_INFO( gLogFilter, Debug::Verbose, "TextScroller::SetLoopCount [%d] Status[%s]\n", mLoopCount, (loopCount)?"looping":"stop" );
}

int TextScroller::GetLoopCount() const
{
  return mLoopCount;
}

void TextScroller::SetLoopDelay( float delay )
{
  mLoopDelay = delay;
}

float TextScroller::GetLoopDelay() const
{
  return mLoopDelay;
}

void TextScroller::SetStopMode( DevelTextLabel::AutoScrollStopMode::Type stopMode )
{
  DALI_LOG_INFO( gLogFilter, Debug::Verbose, "TextScroller::SetAutoScrollStopMode [%s]\n",(stopMode == DevelTextLabel::AutoScrollStopMode::IMMEDIATE)?"IMMEDIATE":"FINISH_LOOP" );
  mStopMode = stopMode;
}

void TextScroller::StopScrolling()
{
  if ( mScrollAnimation && mScrollAnimation.GetState() == Animation::PLAYING )
  {
    switch( mStopMode )
    {
      case DevelTextLabel::AutoScrollStopMode::IMMEDIATE:
      {
        mScrollAnimation.Stop();
        CleanUp();
        mScrollerInterface.ScrollingFinished();
        break;
      }
      case DevelTextLabel::AutoScrollStopMode::FINISH_LOOP:
      {
        mScrollAnimation.SetLoopCount( 1 ); // As animation already playing this allows the current animation to finish instead of trying to stop mid-way
        break;
      }
      default:
      {
        DALI_LOG_INFO( gLogFilter, Debug::Verbose, "Undifined AutoScrollStopMode\n" );
      }
    }
  }
}

DevelTextLabel::AutoScrollStopMode::Type TextScroller::GetStopMode() const
{
  return mStopMode;
}

Actor TextScroller::GetSourceCamera() const
{
  return mOffscreenCameraActor;
}

Actor TextScroller::GetScrollingText() const
{
  return mScrollingTextActor;
}

TextScroller::TextScroller( ScrollerInterface& scrollerInterface ) : mScrollerInterface( scrollerInterface ),
                            mScrollDeltaIndex( Property::INVALID_INDEX ),
                            mScrollSpeed( MINIMUM_SCROLL_SPEED ),
                            mLoopCount( 1 ),
                            mLoopDelay( 0.0f ),
                            mWrapGap( 0.0f ),
                            mStopMode( DevelTextLabel::AutoScrollStopMode::FINISH_LOOP )
{
  DALI_LOG_INFO( gLogFilter, Debug::Verbose, "TextScroller Default Constructor\n" );
}

TextScroller::~TextScroller()
{
  CleanUp();
}

void TextScroller::SetParameters( Actor sourceActor, const Size& controlSize, const Size& offScreenSize, CharacterDirection direction, float alignmentOffset, Layout::HorizontalAlignment horizontalAlignment )
{
  DALI_LOG_INFO( gLogFilter, Debug::Verbose, "TextScroller::SetParameters controlSize[%f,%f] offscreenSize[%f,%f] direction[%d] alignmentOffset[%f]\n",
                 controlSize.x, controlSize.y, offScreenSize.x, offScreenSize.y, direction, alignmentOffset );

  CleanUp(); //  If already scrolling then restart with new parameters

  float animationProgress = 0.0f;
  int   remainedLoop = mLoopCount;
  if ( mScrollAnimation )
  {
    if( mScrollAnimation.GetState() == Animation::PLAYING )
    {
      animationProgress = mScrollAnimation.GetCurrentProgress();

      if( mLoopCount > 0 ) // If not a ininity loop, then calculate remained loop
      {
        remainedLoop = mLoopCount - ( mScrollAnimation.GetCurrentLoop() );
        remainedLoop = ( remainedLoop <= 0 ? 1 : remainedLoop );
      }
    }
    mScrollAnimation.Clear();
  }

  FrameBufferImage offscreenRenderTargetForText = FrameBufferImage::New( offScreenSize.width, offScreenSize.height, Pixel::RGBA8888 );
  Renderer renderer;

  CreateCameraActor( offScreenSize, mOffscreenCameraActor );
  CreateRenderer( offscreenRenderTargetForText, renderer );
  CreateRenderTask( sourceActor, mOffscreenCameraActor, offscreenRenderTargetForText, mRenderTask );

  float xPosition = 0.0f;
  switch( horizontalAlignment )
  {
    case Layout::HORIZONTAL_ALIGN_BEGIN:
    {
      // Reposition camera to match alignment of target, RTL text has direction=true
      if ( direction )
      {
        xPosition = alignmentOffset + offScreenSize.width * 0.5f;
      }
      else
      {
        xPosition = offScreenSize.width * 0.5f;
      }
      break;
    }

    case Layout::HORIZONTAL_ALIGN_CENTER:
    {
      xPosition = controlSize.width * 0.5f;
      break;
    }

    case Layout::HORIZONTAL_ALIGN_END:
    {
      // Reposition camera to match alignment of target, RTL text has direction=true
      if ( direction )
      {
        xPosition = offScreenSize.width * 0.5f;
      }
      else
      {
        xPosition = alignmentOffset + offScreenSize.width * 0.5f;
      }
      break;
    }
  }

  DALI_LOG_INFO( gLogFilter, Debug::Verbose, "TextScroller::SetParameters xPosition[%f]\n", xPosition );

  mOffscreenCameraActor.SetX( xPosition );
  mOffscreenCameraActor.SetY( offScreenSize.height * 0.5f );

  DALI_LOG_INFO( gLogFilter, Debug::Verbose, "TextScroller::SetParameters mWrapGap[%f]\n", mWrapGap );

  const float align = ALIGNMENT_TABLE[ horizontalAlignment ][ direction ][ offScreenSize.width > controlSize.width ];
  DALI_LOG_INFO( gLogFilter, Debug::Verbose, "TextScroller::SetParameters align[%f]\n", align );

  mScrollingTextActor = Actor::New();
  mScrollingTextActor.AddRenderer( renderer );
  mScrollingTextActor.RegisterProperty( "uTextureSize", offScreenSize );
  mScrollingTextActor.RegisterProperty( "uAlign", align );
  mScrollingTextActor.RegisterProperty( "uGap", mWrapGap );
  mScrollingTextActor.SetSize( controlSize.width, std::min( offScreenSize.height, controlSize.height ) );
  mScrollDeltaIndex = mScrollingTextActor.RegisterProperty( "uDelta", 0.0f );

  float scrollAmount = std::max( offScreenSize.width + mWrapGap, controlSize.width );
  float scrollDuration =  scrollAmount / mScrollSpeed;

  if ( direction  )
  {
     scrollAmount = -scrollAmount; // reverse direction of scrollung
  }

  StartScrolling( scrollAmount, scrollDuration, remainedLoop );
  mScrollAnimation.SetCurrentProgress(animationProgress);
}

void TextScroller::AutoScrollAnimationFinished( Dali::Animation& animation )
{
  DALI_LOG_INFO( gLogFilter, Debug::Verbose, "TextScroller::AutoScrollAnimationFinished\n" );
  CleanUp();
  mScrollerInterface.ScrollingFinished();
}

void TextScroller::StartScrolling( float scrollAmount, float scrollDuration, int loopCount )
{
  DALI_LOG_INFO( gLogFilter, Debug::Verbose, "TextScroller::StartScrolling scrollAmount[%f] scrollDuration[%f], loop[%d] speed[%d]\n", scrollAmount, scrollDuration, loopCount, mScrollSpeed );

  mScrollAnimation = Animation::New( scrollDuration );
  mScrollAnimation.AnimateTo( Property( mScrollingTextActor, mScrollDeltaIndex ), scrollAmount, TimePeriod( mLoopDelay, scrollDuration ) );
  mScrollAnimation.SetEndAction( Animation::Discard );
  mScrollAnimation.SetLoopCount( loopCount );
  mScrollAnimation.FinishedSignal().Connect( this, &TextScroller::AutoScrollAnimationFinished );
  mScrollAnimation.Play();
}

void TextScroller::CleanUp()
{
  if ( Stage::IsInstalled() )
  {
    Stage stage = Stage::GetCurrent();
    RenderTaskList taskList = stage.GetRenderTaskList();
    UnparentAndReset( mScrollingTextActor );
    UnparentAndReset( mOffscreenCameraActor );
    taskList.RemoveTask( mRenderTask );
  }
}

} // namespace Text

} // namespace Toolkit

} // namespace Dali
