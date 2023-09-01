// Decompiled with JetBrains decompiler
// Type: UniBizBO.Views.V0.Part.Main.Code.Store.PageStoreMPartV
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace UniBizBO.Views.V0.Part.Main.Code.Store
{
  public partial class PageStoreMPartV : UserControl, IComponentConnector
  {
    internal TextBox si_StoreName;
    internal TextBox si_Tel1;
    internal TextBox si_Tel2;
    internal TextBox si_ErpCode;
    internal TextBox si_DisplayBizNo;
    internal TextBox si_BizName;
    internal TextBox si_BizCeo;
    internal TextBox si_BizType;
    internal TextBox si_BizCategory;
    internal TextBox si_ZipCode;
    internal TextBox si_WeatherCode;
    internal TextBox si_BizAddr1;
    internal TextBox si_BizAddr2;
    internal TextBox si_Email;
    internal CheckBox IsPwdChanged;
    internal TextBox si_EmailPwd;
    internal DatePicker LastUI;
    private bool _contentLoaded;

    public PageStoreMPartV() => this.InitializeComponent();

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "5.0.17.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/UniBizBO;component/views/v0/part/main/code/store/pagestorempartv.xaml", UriKind.Relative));
    }

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "5.0.17.0")]
    internal Delegate _CreateDelegate(Type delegateType, string handler) => Delegate.CreateDelegate(delegateType, (object) this, handler);

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "5.0.17.0")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    void IComponentConnector.Connect(int connectionId, object target)
    {
      switch (connectionId)
      {
        case 1:
          this.si_StoreName = (TextBox) target;
          break;
        case 2:
          this.si_Tel1 = (TextBox) target;
          break;
        case 3:
          this.si_Tel2 = (TextBox) target;
          break;
        case 4:
          this.si_ErpCode = (TextBox) target;
          break;
        case 5:
          this.si_DisplayBizNo = (TextBox) target;
          break;
        case 6:
          this.si_BizName = (TextBox) target;
          break;
        case 7:
          this.si_BizCeo = (TextBox) target;
          break;
        case 8:
          this.si_BizType = (TextBox) target;
          break;
        case 9:
          this.si_BizCategory = (TextBox) target;
          break;
        case 10:
          this.si_ZipCode = (TextBox) target;
          break;
        case 11:
          this.si_WeatherCode = (TextBox) target;
          break;
        case 12:
          this.si_BizAddr1 = (TextBox) target;
          break;
        case 13:
          this.si_BizAddr2 = (TextBox) target;
          break;
        case 14:
          this.si_Email = (TextBox) target;
          break;
        case 15:
          this.IsPwdChanged = (CheckBox) target;
          break;
        case 16:
          this.si_EmailPwd = (TextBox) target;
          break;
        case 17:
          this.LastUI = (DatePicker) target;
          break;
        default:
          this._contentLoaded = true;
          break;
      }
    }
  }
}
