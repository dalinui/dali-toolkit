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

public class TextLabel : View {
  private global::System.Runtime.InteropServices.HandleRef swigCPtr;

  internal TextLabel(global::System.IntPtr cPtr, bool cMemoryOwn) : base(NDalicPINVOKE.TextLabel_SWIGUpcast(cPtr), cMemoryOwn) {
    swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
  }

  internal static global::System.Runtime.InteropServices.HandleRef getCPtr(TextLabel obj) {
    return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
  }

  ~TextLabel() {
    Dispose();
  }

  public override void Dispose() {
    lock(this) {
      if (swigCPtr.Handle != global::System.IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          NDalicPINVOKE.delete_TextLabel(swigCPtr);
        }
        swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
      }
      global::System.GC.SuppressFinalize(this);
      base.Dispose();
    }
  }

  public class Property : global::System.IDisposable {
    private global::System.Runtime.InteropServices.HandleRef swigCPtr;
    protected bool swigCMemOwn;
  
    internal Property(global::System.IntPtr cPtr, bool cMemoryOwn) {
      swigCMemOwn = cMemoryOwn;
      swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
    }
  
    internal static global::System.Runtime.InteropServices.HandleRef getCPtr(Property obj) {
      return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
    }
  
    ~Property() {
      Dispose();
    }
  
    public virtual void Dispose() {
      lock(this) {
        if (swigCPtr.Handle != global::System.IntPtr.Zero) {
          if (swigCMemOwn) {
            swigCMemOwn = false;
            NDalicPINVOKE.delete_TextLabel_Property(swigCPtr);
          }
          swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
        }
        global::System.GC.SuppressFinalize(this);
      }
    }
  
    public Property() : this(NDalicPINVOKE.new_TextLabel_Property(), true) {
      if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    }
  
    public static readonly int RENDERING_BACKEND = NDalicPINVOKE.TextLabel_Property_RENDERING_BACKEND_get();
    public static readonly int TEXT = NDalicPINVOKE.TextLabel_Property_TEXT_get();
    public static readonly int FONT_FAMILY = NDalicPINVOKE.TextLabel_Property_FONT_FAMILY_get();
    public static readonly int FONT_STYLE = NDalicPINVOKE.TextLabel_Property_FONT_STYLE_get();
    public static readonly int POINT_SIZE = NDalicPINVOKE.TextLabel_Property_POINT_SIZE_get();
    public static readonly int MULTI_LINE = NDalicPINVOKE.TextLabel_Property_MULTI_LINE_get();
    public static readonly int HORIZONTAL_ALIGNMENT = NDalicPINVOKE.TextLabel_Property_HORIZONTAL_ALIGNMENT_get();
    public static readonly int VERTICAL_ALIGNMENT = NDalicPINVOKE.TextLabel_Property_VERTICAL_ALIGNMENT_get();
    public static readonly int TEXT_COLOR = NDalicPINVOKE.TextLabel_Property_TEXT_COLOR_get();
    public static readonly int SHADOW_OFFSET = NDalicPINVOKE.TextLabel_Property_SHADOW_OFFSET_get();
    public static readonly int SHADOW_COLOR = NDalicPINVOKE.TextLabel_Property_SHADOW_COLOR_get();
    public static readonly int UNDERLINE_ENABLED = NDalicPINVOKE.TextLabel_Property_UNDERLINE_ENABLED_get();
    public static readonly int UNDERLINE_COLOR = NDalicPINVOKE.TextLabel_Property_UNDERLINE_COLOR_get();
    public static readonly int UNDERLINE_HEIGHT = NDalicPINVOKE.TextLabel_Property_UNDERLINE_HEIGHT_get();
    public static readonly int ENABLE_MARKUP = NDalicPINVOKE.TextLabel_Property_ENABLE_MARKUP_get();
    public static readonly int ENABLE_AUTO_SCROLL = NDalicPINVOKE.TextLabel_Property_ENABLE_AUTO_SCROLL_get();
    public static readonly int AUTO_SCROLL_SPEED = NDalicPINVOKE.TextLabel_Property_AUTO_SCROLL_SPEED_get();
    public static readonly int AUTO_SCROLL_LOOP_COUNT = NDalicPINVOKE.TextLabel_Property_AUTO_SCROLL_LOOP_COUNT_get();
    public static readonly int AUTO_SCROLL_GAP = NDalicPINVOKE.TextLabel_Property_AUTO_SCROLL_GAP_get();
    public static readonly int LINE_SPACING = NDalicPINVOKE.TextLabel_Property_LINE_SPACING_get();
    public static readonly int UNDERLINE = NDalicPINVOKE.TextLabel_Property_UNDERLINE_get();
    public static readonly int SHADOW = NDalicPINVOKE.TextLabel_Property_SHADOW_get();
    public static readonly int EMBOSS = NDalicPINVOKE.TextLabel_Property_EMBOSS_get();
    public static readonly int OUTLINE = NDalicPINVOKE.TextLabel_Property_OUTLINE_get();
  
  }

  public TextLabel () : this (NDalicPINVOKE.TextLabel_New__SWIG_0(), true) {
      if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

  }
  public TextLabel (string text) : this (NDalicPINVOKE.TextLabel_New__SWIG_1(text), true) {
      if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

  }
  public TextLabel(TextLabel handle) : this(NDalicPINVOKE.new_TextLabel__SWIG_1(TextLabel.getCPtr(handle)), true) {
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
  }

  public TextLabel Assign(TextLabel handle) {
    TextLabel ret = new TextLabel(NDalicPINVOKE.TextLabel_Assign(swigCPtr, TextLabel.getCPtr(handle)), false);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public new static TextLabel DownCast(BaseHandle handle) {
    TextLabel ret = new TextLabel(NDalicPINVOKE.TextLabel_DownCast(BaseHandle.getCPtr(handle)), true);
    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
    return ret;
  }

  public enum PropertyRange {
    PROPERTY_START_INDEX = PropertyRanges.PROPERTY_REGISTRATION_START_INDEX,
    PROPERTY_END_INDEX = View.PropertyRange.PROPERTY_START_INDEX+1000
  }

  public int RenderingBackend 
  { 
    get 
    {
      int temp = 0;
      GetProperty( TextLabel.Property.RENDERING_BACKEND).Get( ref temp );
      return temp;
    }
    set 
    { 
      SetProperty( TextLabel.Property.RENDERING_BACKEND, new Dali.Property.Value( value ) );
    }
  }
  public string Text 
  { 
    get 
    {
      string temp;
      GetProperty( TextLabel.Property.TEXT).Get( out temp );
      return temp;
    }
    set 
    { 
      SetProperty( TextLabel.Property.TEXT, new Dali.Property.Value( value ) );
    }
  }
  public string FontFamily 
  { 
    get 
    {
      string temp;
      GetProperty( TextLabel.Property.FONT_FAMILY).Get( out temp );
      return temp;
    }
    set 
    { 
      SetProperty( TextLabel.Property.FONT_FAMILY, new Dali.Property.Value( value ) );
    }
  }
  public string FontStyle 
  { 
    get 
    {
      string temp;
      GetProperty( TextLabel.Property.FONT_STYLE).Get( out temp );
      return temp;
    }
    set 
    { 
      SetProperty( TextLabel.Property.FONT_STYLE, new Dali.Property.Value( value ) );
    }
  }
  public float PointSize 
  { 
    get 
    {
      float temp = 0.0f;
      GetProperty( TextLabel.Property.POINT_SIZE).Get( ref temp );
      return temp;
    }
    set 
    { 
      SetProperty( TextLabel.Property.POINT_SIZE, new Dali.Property.Value( value ) );
    }
  }
  public bool MultiLine 
  { 
    get 
    {
      bool temp = false;
      GetProperty( TextLabel.Property.MULTI_LINE).Get( ref temp );
      return temp;
    }
    set 
    { 
      SetProperty( TextLabel.Property.MULTI_LINE, new Dali.Property.Value( value ) );
    }
  }
  public string HorizontalAlignment 
  { 
    get 
    {
      string temp;
      GetProperty( TextLabel.Property.HORIZONTAL_ALIGNMENT).Get( out temp );
      return temp;
    }
    set 
    { 
      SetProperty( TextLabel.Property.HORIZONTAL_ALIGNMENT, new Dali.Property.Value( value ) );
    }
  }
  public string VerticalAlignment 
  { 
    get 
    {
      string temp;
      GetProperty( TextLabel.Property.VERTICAL_ALIGNMENT).Get( out temp );
      return temp;
    }
    set 
    { 
      SetProperty( TextLabel.Property.VERTICAL_ALIGNMENT, new Dali.Property.Value( value ) );
    }
  }
  public Vector4 TextColor 
  { 
    get 
    {
      Vector4 temp = new Vector4(0.0f,0.0f,0.0f,0.0f);
      GetProperty( TextLabel.Property.TEXT_COLOR).Get(  temp );
      return temp;
    }
    set 
    { 
      SetProperty( TextLabel.Property.TEXT_COLOR, new Dali.Property.Value( value ) );
    }
  }
  public Vector2 ShadowOffset 
  { 
    get 
    {
      Vector2 temp = new Vector2(0.0f,0.0f);
      GetProperty( TextLabel.Property.SHADOW_OFFSET).Get(  temp );
      return temp;
    }
    set 
    { 
      SetProperty( TextLabel.Property.SHADOW_OFFSET, new Dali.Property.Value( value ) );
    }
  }
  public Vector4 ShadowColor 
  { 
    get 
    {
      Vector4 temp = new Vector4(0.0f,0.0f,0.0f,0.0f);
      GetProperty( TextLabel.Property.SHADOW_COLOR).Get(  temp );
      return temp;
    }
    set 
    { 
      SetProperty( TextLabel.Property.SHADOW_COLOR, new Dali.Property.Value( value ) );
    }
  }
  public bool UnderlineEnabled 
  { 
    get 
    {
      bool temp = false;
      GetProperty( TextLabel.Property.UNDERLINE_ENABLED).Get( ref temp );
      return temp;
    }
    set 
    { 
      SetProperty( TextLabel.Property.UNDERLINE_ENABLED, new Dali.Property.Value( value ) );
    }
  }
  public Vector4 UnderlineColor 
  { 
    get 
    {
      Vector4 temp = new Vector4(0.0f,0.0f,0.0f,0.0f);
      GetProperty( TextLabel.Property.UNDERLINE_COLOR).Get(  temp );
      return temp;
    }
    set 
    { 
      SetProperty( TextLabel.Property.UNDERLINE_COLOR, new Dali.Property.Value( value ) );
    }
  }
  public float UnderlineHeight 
  { 
    get 
    {
      float temp = 0.0f;
      GetProperty( TextLabel.Property.UNDERLINE_HEIGHT).Get( ref temp );
      return temp;
    }
    set 
    { 
      SetProperty( TextLabel.Property.UNDERLINE_HEIGHT, new Dali.Property.Value( value ) );
    }
  }
  public bool EnableMarkup 
  { 
    get 
    {
      bool temp = false;
      GetProperty( TextLabel.Property.ENABLE_MARKUP).Get( ref temp );
      return temp;
    }
    set 
    { 
      SetProperty( TextLabel.Property.ENABLE_MARKUP, new Dali.Property.Value( value ) );
    }
  }
  public bool EnableAutoScroll 
  { 
    get 
    {
      bool temp = false;
      GetProperty( TextLabel.Property.ENABLE_AUTO_SCROLL).Get( ref temp );
      return temp;
    }
    set 
    { 
      SetProperty( TextLabel.Property.ENABLE_AUTO_SCROLL, new Dali.Property.Value( value ) );
    }
  }
  public int AutoScrollSpeed 
  { 
    get 
    {
      int temp = 0;
      GetProperty( TextLabel.Property.AUTO_SCROLL_SPEED).Get( ref temp );
      return temp;
    }
    set 
    { 
      SetProperty( TextLabel.Property.AUTO_SCROLL_SPEED, new Dali.Property.Value( value ) );
    }
  }
  public int AutoScrollLoopCount 
  { 
    get 
    {
      int temp = 0;
      GetProperty( TextLabel.Property.AUTO_SCROLL_LOOP_COUNT).Get( ref temp );
      return temp;
    }
    set 
    { 
      SetProperty( TextLabel.Property.AUTO_SCROLL_LOOP_COUNT, new Dali.Property.Value( value ) );
    }
  }
  public float AutoScrollGap 
  { 
    get 
    {
      float temp = 0.0f;
      GetProperty( TextLabel.Property.AUTO_SCROLL_GAP).Get( ref temp );
      return temp;
    }
    set 
    { 
      SetProperty( TextLabel.Property.AUTO_SCROLL_GAP, new Dali.Property.Value( value ) );
    }
  }
  public float LineSpacing 
  { 
    get 
    {
      float temp = 0.0f;
      GetProperty( TextLabel.Property.LINE_SPACING).Get( ref temp );
      return temp;
    }
    set 
    { 
      SetProperty( TextLabel.Property.LINE_SPACING, new Dali.Property.Value( value ) );
    }
  }
  public string Underline 
  { 
    get 
    {
      string temp;
      GetProperty( TextLabel.Property.UNDERLINE).Get( out temp );
      return temp;
    }
    set 
    { 
      SetProperty( TextLabel.Property.UNDERLINE, new Dali.Property.Value( value ) );
    }
  }
  public string Shadow 
  { 
    get 
    {
      string temp;
      GetProperty( TextLabel.Property.SHADOW).Get( out temp );
      return temp;
    }
    set 
    { 
      SetProperty( TextLabel.Property.SHADOW, new Dali.Property.Value( value ) );
    }
  }
  public string Emboss 
  { 
    get 
    {
      string temp;
      GetProperty( TextLabel.Property.EMBOSS).Get( out temp );
      return temp;
    }
    set 
    { 
      SetProperty( TextLabel.Property.EMBOSS, new Dali.Property.Value( value ) );
    }
  }
  public string Outline 
  { 
    get 
    {
      string temp;
      GetProperty( TextLabel.Property.OUTLINE).Get( out temp );
      return temp;
    }
    set 
    { 
      SetProperty( TextLabel.Property.OUTLINE, new Dali.Property.Value( value ) );
    }
  }

}

}