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

public class AlphaFunction : global::System.IDisposable {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;
  protected bool swigCMemOwn;

  internal AlphaFunction(global::System.IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(AlphaFunction obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~AlphaFunction() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          NDalicPINVOKE.delete_AlphaFunction(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
    }
  }

  public AlphaFunction() : this(NDalicPINVOKE.new_AlphaFunction__SWIG_0(), true) {
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public AlphaFunction(AlphaFunction.BuiltinFunction function) : this(NDalicPINVOKE.new_AlphaFunction__SWIG_1((int)function), true) {
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public AlphaFunction(SWIGTYPE_p_f_float__float function) : this(NDalicPINVOKE.new_AlphaFunction__SWIG_2(SWIGTYPE_p_f_float__float.getCPtr(function)), true) {
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public AlphaFunction(Vector2 controlPoint0, Vector2 controlPoint1) : this(NDalicPINVOKE.new_AlphaFunction__SWIG_3(Vector2.getCPtr(controlPoint0), Vector2.getCPtr(controlPoint1)), true) {
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public Vector4 GetBezierControlPoints() {
    Vector4 ret = new Vector4(NDalicPINVOKE.AlphaFunction_GetBezierControlPoints(swigCPtr), true);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public SWIGTYPE_p_f_float__float GetCustomFunction() {
    global::System.IntPtr cPtr = NDalicPINVOKE.AlphaFunction_GetCustomFunction(swigCPtr);
    SWIGTYPE_p_f_float__float ret = (cPtr == global::System.IntPtr.Zero) ? null : new SWIGTYPE_p_f_float__float(cPtr, false);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public AlphaFunction.BuiltinFunction GetBuiltinFunction() {
    AlphaFunction.BuiltinFunction ret = (AlphaFunction.BuiltinFunction)NDalicPINVOKE.AlphaFunction_GetBuiltinFunction(swigCPtr);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public AlphaFunction.Mode GetMode() {
    AlphaFunction.Mode ret = (AlphaFunction.Mode)NDalicPINVOKE.AlphaFunction_GetMode(swigCPtr);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public enum BuiltinFunction {
    DEFAULT,
    LINEAR,
    REVERSE,
    EASE_IN_SQUARE,
    EASE_OUT_SQUARE,
    EASE_IN,
    EASE_OUT,
    EASE_IN_OUT,
    EASE_IN_SINE,
    EASE_OUT_SINE,
    EASE_IN_OUT_SINE,
    BOUNCE,
    SIN,
    EASE_OUT_BACK,
    COUNT
  }

  public enum Mode {
    BUILTIN_FUNCTION,
    CUSTOM_FUNCTION,
    BEZIER
  }

}

}