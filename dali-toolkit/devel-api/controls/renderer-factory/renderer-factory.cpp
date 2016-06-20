 /*
 * Copyright (c) 2015 Samsung Electronics Co., Ltd.
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
#include "renderer-factory.h"

// EXTERNAL INCLUDES
#include <dali/devel-api/adaptor-framework/singleton-service.h>
#include <dali/devel-api/adaptor-framework/environment-variable.h>

// INTERNAL INCLUDES
#include <dali-toolkit/internal/controls/renderers/renderer-factory-impl.h>

namespace Dali
{

namespace Toolkit
{

namespace
{
  const char * const DALI_DEBUG_RENDERING("DALI_DEBUG_RENDERING");
}

RendererFactory RendererFactory::Get()
{
  RendererFactory factory;

  // Check whether the RendererFactory is already created
  SingletonService singletonService( SingletonService::Get() );
  if( singletonService )
  {
    BaseHandle handle = singletonService.GetSingleton( typeid(RendererFactory) );
    if( handle )
    {
      //If so, downcast the handle of singleton to RendererFactory
      factory = RendererFactory( dynamic_cast<Internal::RendererFactory*>(handle.GetObjectPtr()) );
    }

    if( !factory )// If not, create the RendererFactory and register it as a singleton
    {
      // Check whether debug rendering is required
      if( EnvironmentVariable::GetEnvironmentVariable( DALI_DEBUG_RENDERING ) )
      {
        factory = RendererFactory( new Internal::RendererFactory(true) );
      }
      else
      {
        factory = RendererFactory( new Internal::RendererFactory(false) );
      }
      singletonService.Register( typeid(RendererFactory), factory );

    }
  }

  return factory;
}

RendererFactory::RendererFactory()
{
}

RendererFactory::~RendererFactory()
{
}

RendererFactory::RendererFactory( const RendererFactory& handle )
: BaseHandle( handle )
{
}

RendererFactory& RendererFactory::operator=( const RendererFactory& handle )
{
  BaseHandle::operator=( handle );
  return *this;
}

RendererFactory::RendererFactory(Internal::RendererFactory *impl)
: BaseHandle(impl)
{
}

ControlRenderer RendererFactory::CreateControlRenderer( const Property::Map& propertyMap )
{
  return GetImplementation( *this ).CreateControlRenderer( propertyMap );
}

ControlRenderer RendererFactory::CreateControlRenderer( const Image& image )
{
  return GetImplementation( *this ).CreateControlRenderer( image );
}

ControlRenderer RendererFactory::CreateControlRenderer( const std::string& url, ImageDimensions size )
{
  return GetImplementation( *this ).CreateControlRenderer( url, size );
}

} // namespace Toolkit

} // namespace Dali
