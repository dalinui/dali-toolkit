/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd.
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

#include <iostream>
#include <stdlib.h>

#include <dali-toolkit-test-suite-utils.h>
#include "dali-toolkit-test-utils/toolkit-timer.h"

#include <dali.h>
#include <dali/integration-api/events/key-event-integ.h>
#include <dali/integration-api/events/touch-event-integ.h>
#include <dali-toolkit/public-api/focus-manager/keyboard-focus-manager.h>
#include <dali-toolkit/devel-api/controls/web-view/web-view.h>


using namespace Dali;
using namespace Toolkit;

namespace
{

const char* const TEST_URL1( "http://www.somewhere.valid1.com" );
const char* const TEST_URL2( "http://www.somewhere.valid2.com" );

static int gPageLoadStartedCallbackCalled = 0;
static int gPageLoadFinishedCallbackCalled = 0;
static bool gTouched = false;

struct CallbackFunctor
{
  CallbackFunctor(bool* callbackFlag)
  : mCallbackFlag( callbackFlag )
  {
  }

  void operator()()
  {
    *mCallbackFlag = true;
  }
  bool* mCallbackFlag;
};

static void OnPageLoadStarted( WebView view, const std::string& url )
{
  gPageLoadStartedCallbackCalled++;
}

static void OnPageLoadFinished( WebView view, const std::string& url )
{
  gPageLoadFinishedCallbackCalled++;
}

static bool OnTouched( Actor actor, const Dali::TouchData& touch )
{
  gTouched = true;
  return true;
}

} // namespace

void web_view_startup(void)
{
  test_return_value = TET_UNDEF;
}

void web_view_cleanup(void)
{
  test_return_value = TET_PASS;
}

int UtcDaliWebViewBasics(void)
{
  ToolkitTestApplication application;

  // Copy and Assignment Test
  tet_infoline( "UtcDaliWebViewBasic Copy and Assignment Test" );
  WebView view = WebView::New();
  DALI_TEST_CHECK( view );

  WebView copy( view );
  DALI_TEST_CHECK( view == copy );

  WebView assign;
  DALI_TEST_CHECK( !assign );

  assign = copy;
  DALI_TEST_CHECK( assign == view );


  // DownCast Test
  tet_infoline( "UtcDaliWebViewBasic DownCast Test" );
  BaseHandle handle(view);

  WebView view2 = WebView::DownCast( handle );
  DALI_TEST_CHECK( view );
  DALI_TEST_CHECK( view2 );
  DALI_TEST_CHECK( view == view2 );


  // TypeRegistry Test
  tet_infoline( "UtcDaliWebViewBasic TypeRegistry Test" );
  TypeRegistry typeRegistry = TypeRegistry::Get();
  DALI_TEST_CHECK( typeRegistry );

  TypeInfo typeInfo = typeRegistry.GetTypeInfo( "WebView" );
  DALI_TEST_CHECK( typeInfo );

  BaseHandle handle2 = typeInfo.CreateInstance();
  DALI_TEST_CHECK( handle2 );

  WebView view3 = WebView::DownCast( handle2 );
  DALI_TEST_CHECK( view3 );

  END_TEST;
}

int UtcDaliWebViewPageNavigation(void)
{
  ToolkitTestApplication application;

  WebView view = WebView::New();
  view.SetAnchorPoint( AnchorPoint::TOP_LEFT );
  view.SetParentOrigin( ParentOrigin::TOP_LEFT );
  view.SetPosition( 0, 0 );
  view.SetSize( 800, 600 );
  Stage::GetCurrent().Add( view );
  application.SendNotification();
  application.Render();
  DALI_TEST_CHECK( view );

  ConnectionTracker* testTracker = new ConnectionTracker();
  view.PageLoadStartedSignal().Connect( &OnPageLoadStarted );
  view.PageLoadFinishedSignal().Connect( &OnPageLoadFinished );
  bool signal1 = false;
  bool signal2 = false;
  bool signal3 = false;
  view.ConnectSignal( testTracker, "pageLoadStarted", CallbackFunctor(&signal1) );
  view.ConnectSignal( testTracker, "pageLoadFinished", CallbackFunctor(&signal2) );
  view.ConnectSignal( testTracker, "invalidname", CallbackFunctor(&signal3) );
  DALI_TEST_EQUALS( gPageLoadStartedCallbackCalled, 0, TEST_LOCATION );
  DALI_TEST_EQUALS( gPageLoadFinishedCallbackCalled, 0, TEST_LOCATION );


  view.LoadUrl( TEST_URL1 );
  view.GetNaturalSize();
  Test::EmitGlobalTimerSignal();
  DALI_TEST_CHECK( view.GetUrl().find( TEST_URL1 ) != std::string::npos );
  DALI_TEST_EQUALS( view.CanGoBack(), false, TEST_LOCATION );
  DALI_TEST_EQUALS( gPageLoadStartedCallbackCalled, 1, TEST_LOCATION );
  DALI_TEST_EQUALS( gPageLoadFinishedCallbackCalled, 1, TEST_LOCATION );
  DALI_TEST_CHECK( signal1 & signal2 );
  DALI_TEST_CHECK( !signal3 );

  view.LoadUrl( TEST_URL2 );
  view.SetSize( 400, 300 );
  application.SendNotification();
  application.Render();
  Test::EmitGlobalTimerSignal();
  DALI_TEST_CHECK( view.GetUrl().find( TEST_URL2 ) != std::string::npos );
  DALI_TEST_EQUALS( view.CanGoBack(), true, TEST_LOCATION );
  DALI_TEST_EQUALS( view.CanGoForward(), false, TEST_LOCATION );
  DALI_TEST_EQUALS( gPageLoadStartedCallbackCalled, 2, TEST_LOCATION );
  DALI_TEST_EQUALS( gPageLoadFinishedCallbackCalled, 2, TEST_LOCATION );

  view.GoBack();
  Test::EmitGlobalTimerSignal();
  DALI_TEST_CHECK( !view.CanGoBack() );
  DALI_TEST_CHECK( view.CanGoForward() );

  view.GoForward();
  Test::EmitGlobalTimerSignal();
  DALI_TEST_CHECK( view.CanGoBack() );
  DALI_TEST_CHECK( !view.CanGoForward() );

  view.Reload();
  view.StopLoading();
  view.ClearHistory();
  view.ClearCache();
  Test::EmitGlobalTimerSignal();
  DALI_TEST_CHECK( !view.CanGoBack() );
  DALI_TEST_CHECK( !view.CanGoForward() );

  END_TEST;
}

int UtcDaliWebViewTouchAndKeys(void)
{
  ToolkitTestApplication application;

  WebView view = WebView::New();
  view.SetAnchorPoint( AnchorPoint::TOP_LEFT );
  view.SetParentOrigin( ParentOrigin::TOP_LEFT );
  view.SetPosition( 0, 0 );
  view.SetSize( 800, 600 );

  Stage::GetCurrent().Add( view );
  application.SendNotification();
  application.Render();

  view.GetNaturalSize();
  view.TouchSignal().Connect( &OnTouched );

  // Touch event
  Dali::Integration::TouchEvent event;
  Dali::Integration::Point pointDown, pointUp;

  event = Dali::Integration::TouchEvent();
  pointDown.SetState( PointState::DOWN );
  pointDown.SetScreenPosition( Vector2( 10, 10 ) );
  event.AddPoint( pointDown );
  application.ProcessEvent( event );

  event = Dali::Integration::TouchEvent();
  pointUp.SetState( PointState::UP );
  pointUp.SetScreenPosition( Vector2( 10, 10 ) );
  event.AddPoint( pointUp );
  application.ProcessEvent( event );

  // Key event
  Toolkit::KeyboardFocusManager::Get().SetCurrentFocusActor( view );
  application.ProcessEvent( Integration::KeyEvent( "", "", "", DALI_KEY_ESCAPE, 0, 0, Integration::KeyEvent::Down, "", "", Device::Class::NONE, Device::Subclass::NONE ) );
  application.SendNotification();

  DALI_TEST_CHECK( gTouched );
  DALI_TEST_CHECK( view );

  END_TEST;
}

int UtcDaliWebViewProperty1(void)
{
  ToolkitTestApplication application;

  WebView view = WebView::New();
  DALI_TEST_CHECK( view );

  std::string local;
  view.SetProperty( WebView::Property::URL, TEST_URL1 );
  Property::Value val = view.GetProperty( WebView::Property::URL );
  DALI_TEST_CHECK( val.Get( local ) );
  DALI_TEST_EQUALS( local, TEST_URL1, TEST_LOCATION );

  END_TEST;
}

int UtcDaliWebViewMethodsForCoverage(void)
{
  ToolkitTestApplication application;

  WebView view = WebView::New( "ko-KR", "Asia/Seoul" );

  view.LoadHTMLString( "<body>Hello World!</body>" );
  view.AddJavaScriptMessageHandler( "jsObject",
    []( const std::string& arg ) {
    }
  );
  view.EvaluateJavaScript( "jsObject.postMessage('Hello')" );

  DALI_TEST_CHECK( view );

  END_TEST;
}
