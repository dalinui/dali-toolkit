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

public class ItemLayout : RefObject {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;

  internal ItemLayout(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.ItemLayout_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(ItemLayout obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~ItemLayout() {
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
          NDalicPINVOKE.delete_ItemLayout(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
      base.Dispose();
    }
  }


  public void SetOrientation(ControlOrientationType orientation) {
    NDalicPINVOKE.ItemLayout_SetOrientation(swigCPtr, (int)orientation);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public ControlOrientationType GetOrientation() {
    ControlOrientationType ret = (ControlOrientationType)NDalicPINVOKE.ItemLayout_GetOrientation(swigCPtr);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void SetLayoutProperties(Property.Map properties) {
    NDalicPINVOKE.ItemLayout_SetLayoutProperties(swigCPtr, Property.Map.getCPtr(properties));
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public Property.Map GetLayoutProperties() {
    Property.Map ret = new Property.Map(NDalicPINVOKE.ItemLayout_GetLayoutProperties(swigCPtr), true);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public void GetItemSize(uint itemId, Vector3 layoutSize, Vector3 itemSize) {
    NDalicPINVOKE.ItemLayout_GetItemSize(swigCPtr, itemId, Vector3.getCPtr(layoutSize), Vector3.getCPtr(itemSize));
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public void SetItemSize(Vector3 itemSize) {
    NDalicPINVOKE.ItemLayout_SetItemSize(swigCPtr, Vector3.getCPtr(itemSize));
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual float GetMinimumLayoutPosition(uint numberOfItems, Vector3 layoutSize) {
    float ret = NDalicPINVOKE.ItemLayout_GetMinimumLayoutPosition(swigCPtr, numberOfItems, Vector3.getCPtr(layoutSize));
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual float GetClosestAnchorPosition(float layoutPosition) {
    float ret = NDalicPINVOKE.ItemLayout_GetClosestAnchorPosition(swigCPtr, layoutPosition);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual float GetItemScrollToPosition(uint itemId) {
    float ret = NDalicPINVOKE.ItemLayout_GetItemScrollToPosition(swigCPtr, itemId);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual ItemRange GetItemsWithinArea(float firstItemPosition, Vector3 layoutSize) {
    ItemRange ret = new ItemRange(NDalicPINVOKE.ItemLayout_GetItemsWithinArea(swigCPtr, firstItemPosition, Vector3.getCPtr(layoutSize)), true);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual float GetClosestOnScreenLayoutPosition(int itemID, float currentLayoutPosition, Vector3 layoutSize) {
    float ret = NDalicPINVOKE.ItemLayout_GetClosestOnScreenLayoutPosition(swigCPtr, itemID, currentLayoutPosition, Vector3.getCPtr(layoutSize));
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual uint GetReserveItemCount(Vector3 layoutSize) {
    uint ret = NDalicPINVOKE.ItemLayout_GetReserveItemCount(swigCPtr, Vector3.getCPtr(layoutSize));
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual void GetDefaultItemSize(uint itemId, Vector3 layoutSize, Vector3 itemSize) {
    NDalicPINVOKE.ItemLayout_GetDefaultItemSize(swigCPtr, itemId, Vector3.getCPtr(layoutSize), Vector3.getCPtr(itemSize));
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual Degree GetScrollDirection() {
    Degree ret = new Degree(NDalicPINVOKE.ItemLayout_GetScrollDirection(swigCPtr), true);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual float GetScrollSpeedFactor() {
    float ret = NDalicPINVOKE.ItemLayout_GetScrollSpeedFactor(swigCPtr);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual float GetMaximumSwipeSpeed() {
    float ret = NDalicPINVOKE.ItemLayout_GetMaximumSwipeSpeed(swigCPtr);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual float GetItemFlickAnimationDuration() {
    float ret = NDalicPINVOKE.ItemLayout_GetItemFlickAnimationDuration(swigCPtr);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual int GetNextFocusItemID(int itemID, int maxItems, View.KeyboardFocus.Direction direction, bool loopEnabled) {
    int ret = NDalicPINVOKE.ItemLayout_GetNextFocusItemID(swigCPtr, itemID, maxItems, (int)direction, loopEnabled);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual float GetFlickSpeedFactor() {
    float ret = NDalicPINVOKE.ItemLayout_GetFlickSpeedFactor(swigCPtr);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public virtual void ApplyConstraints(View view, int itemId, Vector3 layoutSize, View itemView) {
    NDalicPINVOKE.ItemLayout_ApplyConstraints(swigCPtr, View.getCPtr(view), itemId, Vector3.getCPtr(layoutSize), View.getCPtr(itemView));
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public virtual Vector3 GetItemPosition(int itemID, float currentLayoutPosition, Vector3 layoutSize) {
    Vector3 ret = new Vector3(NDalicPINVOKE.ItemLayout_GetItemPosition(swigCPtr, itemID, currentLayoutPosition, Vector3.getCPtr(layoutSize)), true);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

}

}
