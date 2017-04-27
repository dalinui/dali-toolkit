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

using System;
using System.Runtime.InteropServices;


public class Image : BaseHandle {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;

  internal Image(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.Image_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Image obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~Image() {
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
          NDalicPINVOKE.delete_Image(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
      base.Dispose();
    }
  }




/**
  * @brief Event arguments that passed via Uploaded signal
  *
  */
public class UploadedEventArgs : EventArgs
{
   private Image _image;
   /**
     * @brief Image - is the image data that gets uploaded to GL.
     *
     */
   public Image Image
   {
      get
      {
         return _image;
      }
      set
      {
         _image = value;
      }
   }
}

  [UnmanagedFunctionPointer(CallingConvention.StdCall)]
  private delegate void UploadedEventCallbackDelegate(IntPtr image);
  private DaliEventHandler<object,UploadedEventArgs> _imageUploadedEventHandler;
  private UploadedEventCallbackDelegate _imageUploadedEventCallbackDelegate;

  /**
    * @brief Event for Uploaded signal which can be used to subscribe/unsubscribe the event handler
    * (in the type of UploadedEventHandler-DaliEventHandler<object,UploadedEventArgs>) 
    * provided by the user. Uploaded signal is emitted when the image data gets uploaded to GL.
    */
  public event DaliEventHandler<object,UploadedEventArgs> Uploaded
  {
     add
     {
        lock(this)
        {
           // Restricted to only one listener
           if (_imageUploadedEventHandler == null)
           {
              _imageUploadedEventHandler += value;

              _imageUploadedEventCallbackDelegate = new UploadedEventCallbackDelegate(OnUploaded);
              this.UploadedSignal().Connect(_imageUploadedEventCallbackDelegate);
           }
        }
     }

     remove
     {
        lock(this)
        {
           if (_imageUploadedEventHandler != null)
           {
              this.UploadedSignal().Disconnect(_imageUploadedEventCallbackDelegate);
           }

           _imageUploadedEventHandler -= value;
        }
     }
  }

  // Callback for Image UploadedSignal
  private void OnUploaded(IntPtr data)
  {
     UploadedEventArgs e = new UploadedEventArgs();

     // Populate all members of "e" (UploadedEventArgs) with real data
     e.Image = Image.GetImageFromPtr(data);

     if (_imageUploadedEventHandler != null)
     {
        //here we send all data to user event handlers
        _imageUploadedEventHandler(this, e);
     }
  }


public static Image GetImageFromPtr(global::System.IntPtr cPtr) {
    Image ret = new Image(cPtr, false);
   if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }


  public Image() : this(NDalicPINVOKE.new_Image__SWIG_0(), true) {
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public Image(Image handle) : this(NDalicPINVOKE.new_Image__SWIG_1(Image.getCPtr(handle)), true) {
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public Image Assign(Image rhs) {
    Image ret = new Image(NDalicPINVOKE.Image_Assign(swigCPtr, Image.getCPtr(rhs)), false);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public static Image DownCast(BaseHandle handle) {
    Image ret = new Image(NDalicPINVOKE.Image_DownCast(BaseHandle.getCPtr(handle)), true);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public uint GetWidth() {
    uint ret = NDalicPINVOKE.Image_GetWidth(swigCPtr);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public uint GetHeight() {
    uint ret = NDalicPINVOKE.Image_GetHeight(swigCPtr);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public ImageSignal UploadedSignal() {
    ImageSignal ret = new ImageSignal(NDalicPINVOKE.Image_UploadedSignal(swigCPtr), false);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

}

}
