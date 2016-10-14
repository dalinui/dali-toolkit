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

public class Any : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal Any(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Any obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~Any() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          NDalicPINVOKE.delete_Any(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public Any() : this(NDalicPINVOKE.new_Any__SWIG_0(), true) {
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public static void AssertAlways(string assertMessage) {
    NDalicPINVOKE.Any_AssertAlways(assertMessage);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public Any(Any any) : this(NDalicPINVOKE.new_Any__SWIG_2(Any.getCPtr(any)), true) {
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public Any Assign(Any any) {
    Any ret = new Any(NDalicPINVOKE.Any_Assign(swigCPtr, Any.getCPtr(any)), false);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public SWIGTYPE_p_std__type_info GetType() {
    SWIGTYPE_p_std__type_info ret = new SWIGTYPE_p_std__type_info(NDalicPINVOKE.Any_GetType(swigCPtr), false);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public bool Empty() {
    bool ret = NDalicPINVOKE.Any_Empty(swigCPtr);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public class AnyContainerBase : global::System.IDisposable {
    private global::System.Runtime.InteropServices.HandleRef swigCPtr;
    protected bool swigCMemOwn;
  
    internal AnyContainerBase(global::System.IntPtr cPtr, bool cMemoryOwn) {
      swigCMemOwn = cMemoryOwn;
      swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
    }
  
    internal static global::System.Runtime.InteropServices.HandleRef getCPtr(AnyContainerBase obj) {
      return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
    }
  
    ~AnyContainerBase() {
      Dispose();
    }
  
    public virtual void Dispose() {
      lock(this) {
        if (swigCPtr.Handle != global::System.IntPtr.Zero) {
          if (swigCMemOwn) {
            swigCMemOwn = false;
            NDalicPINVOKE.delete_Any_AnyContainerBase(swigCPtr);
          }
          swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
        }
        global::System.GC.SuppressFinalize(this);
      }
    }
  
    public AnyContainerBase(SWIGTYPE_p_std__type_info type, SWIGTYPE_p_f_r_q_const__Dali__Any__AnyContainerBase__p_Dali__Any__AnyContainerBase cloneFunc, SWIGTYPE_p_f_p_q_const__Dali__Any__AnyContainerBase__void deleteFunc) : this(NDalicPINVOKE.new_Any_AnyContainerBase(SWIGTYPE_p_std__type_info.getCPtr(type), SWIGTYPE_p_f_r_q_const__Dali__Any__AnyContainerBase__p_Dali__Any__AnyContainerBase.getCPtr(cloneFunc), SWIGTYPE_p_f_p_q_const__Dali__Any__AnyContainerBase__void.getCPtr(deleteFunc)), true) {
      if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    }
  
    public SWIGTYPE_p_std__type_info GetType() {
      SWIGTYPE_p_std__type_info ret = new SWIGTYPE_p_std__type_info(NDalicPINVOKE.Any_AnyContainerBase_GetType(swigCPtr), false);
      if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    }
  
    public SWIGTYPE_p_std__type_info mType {
      get {
        SWIGTYPE_p_std__type_info ret = new SWIGTYPE_p_std__type_info(NDalicPINVOKE.Any_AnyContainerBase_mType_get(swigCPtr), false);
        if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        return ret;
      } 
    }
  
    public SWIGTYPE_p_f_r_q_const__Dali__Any__AnyContainerBase__p_Dali__Any__AnyContainerBase mCloneFunc {
      set {
        NDalicPINVOKE.Any_AnyContainerBase_mCloneFunc_set(swigCPtr, SWIGTYPE_p_f_r_q_const__Dali__Any__AnyContainerBase__p_Dali__Any__AnyContainerBase.getCPtr(value));
        if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
      } 
      get {
        global::System.IntPtr cPtr = NDalicPINVOKE.Any_AnyContainerBase_mCloneFunc_get(swigCPtr);
        SWIGTYPE_p_f_r_q_const__Dali__Any__AnyContainerBase__p_Dali__Any__AnyContainerBase ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_r_q_const__Dali__Any__AnyContainerBase__p_Dali__Any__AnyContainerBase(cPtr, false);
        if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        return ret;
      } 
    }
  
    public SWIGTYPE_p_f_p_q_const__Dali__Any__AnyContainerBase__void mDeleteFunc {
      set {
        NDalicPINVOKE.Any_AnyContainerBase_mDeleteFunc_set(swigCPtr, SWIGTYPE_p_f_p_q_const__Dali__Any__AnyContainerBase__void.getCPtr(value));
        if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
      } 
      get {
        global::System.IntPtr cPtr = NDalicPINVOKE.Any_AnyContainerBase_mDeleteFunc_get(swigCPtr);
        SWIGTYPE_p_f_p_q_const__Dali__Any__AnyContainerBase__void ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_p_q_const__Dali__Any__AnyContainerBase__void(cPtr, false);
        if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        return ret;
      } 
    }
  
  }

  public Any.AnyContainerBase mContainer {
    set {
      NDalicPINVOKE.Any_mContainer_set(swigCPtr, Any.AnyContainerBase.getCPtr(value));
      if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    } 
    get {
      global::System.IntPtr cPtr = NDalicPINVOKE.Any_mContainer_get(swigCPtr);
      Any.AnyContainerBase ret = (cPtr == global::System.IntPtr.Zero) ? null : new Any.AnyContainerBase(cPtr, false);
      if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
      return ret;
    } 
  }

}

}