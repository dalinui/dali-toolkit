/** Copyright (c) 2016 Samsung Electronics Co., Ltd.
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
// This File has been auto-generated by SWIG and then modified using DALi Ruby Scripts
//------------------------------------------------------------------------------
// <auto-generated />
//
// This file was automatically generated by SWIG (http://www.swig.org).
// Version 3.0.9
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------

namespace Dali {

public class Texture : BaseHandle {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;

  internal Texture(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.Texture_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Texture obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~Texture() {
    Dispose();
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          NDalicPINVOKE.delete_Texture(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

  public Texture (TextureType type, PixelFormat format, uint width, uint height) : this (NDalicPINVOKE.Texture_New__SWIG_0((int)type, (int)format, width, height), true) {
      if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

  }
  public Texture (NativeImageInterface nativeImageInterface) : this (NDalicPINVOKE.Texture_New__SWIG_1(NativeImageInterface.getCPtr(nativeImageInterface)), true) {
      if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

  }
  public Texture(Texture handle) : this(NDalicPINVOKE.new_Texture__SWIG_1(Texture.getCPtr(handle)), true) {
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public static Texture DownCast(BaseHandle handle) {
    Texture ret = new Texture(NDalicPINVOKE.Texture_DownCast(BaseHandle.getCPtr(handle)), true);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public Texture Assign(Texture handle) {
    Texture ret = new Texture(NDalicPINVOKE.Texture_Assign(swigCPtr, Texture.getCPtr(handle)), false);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool Upload(PixelData pixelData) {
    bool ret = NDalicPINVOKE.Texture_Upload__SWIG_0(swigCPtr, PixelData.getCPtr(pixelData));
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool Upload(PixelData pixelData, uint layer, uint mipmap, uint xOffset, uint yOffset, uint width, uint height) {
    bool ret = NDalicPINVOKE.Texture_Upload__SWIG_1(swigCPtr, PixelData.getCPtr(pixelData), layer, mipmap, xOffset, yOffset, width, height);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void GenerateMipmaps() {
    NDalicPINVOKE.Texture_GenerateMipmaps(swigCPtr);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public uint GetWidth() {
    uint ret = NDalicPINVOKE.Texture_GetWidth(swigCPtr);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public uint GetHeight() {
    uint ret = NDalicPINVOKE.Texture_GetHeight(swigCPtr);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

}

}