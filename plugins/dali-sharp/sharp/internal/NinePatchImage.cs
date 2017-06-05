/** Copyright (c) 2017 Samsung Electronics Co., Ltd.
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
// Version 3.0.10
//
// Do not make changes to this file unless you know what you are doing--modify
// the SWIG interface file instead.
//------------------------------------------------------------------------------

namespace Dali {

internal class NinePatchImage : ResourceImage {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;

  internal NinePatchImage(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.NinePatchImage_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(NinePatchImage obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~NinePatchImage() {
    DisposeQueue.Instance.Add(this);
  }

  public override void Dispose() {
    if (!Window.IsInstalled()) {
      DisposeQueue.Instance.Add(this);
      return;
    }

    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          NDalicPINVOKE.delete_NinePatchImage(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
      base.Dispose();
    }
  }


  public NinePatchImage (string filename) : this (NDalicPINVOKE.NinePatchImage_New(filename), true) {
      if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

  }
  public new static NinePatchImage DownCast(BaseHandle handle) {
    NinePatchImage ret = new NinePatchImage(NDalicPINVOKE.NinePatchImage_DownCast(BaseHandle.getCPtr(handle)), true);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public NinePatchImage(NinePatchImage handle) : this(NDalicPINVOKE.new_NinePatchImage__SWIG_1(NinePatchImage.getCPtr(handle)), true) {
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public NinePatchImage Assign(NinePatchImage rhs) {
    NinePatchImage ret = new NinePatchImage(NDalicPINVOKE.NinePatchImage_Assign(swigCPtr, NinePatchImage.getCPtr(rhs)), false);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public Vector4 GetStretchBorders() {
    Vector4 ret = new Vector4(NDalicPINVOKE.NinePatchImage_GetStretchBorders(swigCPtr), true);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public VectorUint16Pair GetStretchPixelsX() {
    VectorUint16Pair ret = new VectorUint16Pair(NDalicPINVOKE.NinePatchImage_GetStretchPixelsX(swigCPtr), false);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public VectorUint16Pair GetStretchPixelsY() {
    VectorUint16Pair ret = new VectorUint16Pair(NDalicPINVOKE.NinePatchImage_GetStretchPixelsY(swigCPtr), false);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public Rectangle GetChildRectangle() {
    Rectangle ret = new Rectangle(NDalicPINVOKE.NinePatchImage_GetChildRectangle(swigCPtr), true);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public BufferImage CreateCroppedBufferImage() {
    BufferImage ret = new BufferImage(NDalicPINVOKE.NinePatchImage_CreateCroppedBufferImage(swigCPtr), true);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public static bool IsNinePatchUrl(string url) {
    bool ret = NDalicPINVOKE.NinePatchImage_IsNinePatchUrl(url);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

}

}
