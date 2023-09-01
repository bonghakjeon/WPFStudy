// Decompiled with JetBrains decompiler
// Type: UniBizBO.Views.V0.Part.Main.Code.Employee.PageEmployeeMPartV
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

namespace UniBizBO.Views.V0.Part.Main.Code.Employee
{
  public partial class PageEmployeeMPartV : UserControl, IComponentConnector
  {
    internal TextBox emp_Name;
    internal ComboBox emp_Position;
    internal ComboBox emp_Job;
    internal TextBox emp_ID;
    internal ComboBox emp_MenuGroupID;
    internal TextBox emp_PosID;
    internal TextBox emp_Mobile;
    internal TextBox emp_Tel;
    internal DatePicker emp_EnterDate;
    internal TextBox emp_Zipcode;
    internal TextBox emp_Addr1;
    internal TextBox emp_Addr2;
    internal TextBox emp_Email;
    internal ComboBox emp_ResignationStatus;
    internal DatePicker emp_ResignationDate;
    internal TextBox emp_ExtensionNumber;
    private bool _contentLoaded;

    public PageEmployeeMPartV() => this.InitializeComponent();

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "5.0.17.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/UniBizBO;component/views/v0/part/main/code/employee/pageemployeempartv.xaml", UriKind.Relative));
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
          this.emp_Name = (TextBox) target;
          break;
        case 2:
          this.emp_Position = (ComboBox) target;
          break;
        case 3:
          this.emp_Job = (ComboBox) target;
          break;
        case 4:
          this.emp_ID = (TextBox) target;
          break;
        case 5:
          this.emp_MenuGroupID = (ComboBox) target;
          break;
        case 6:
          this.emp_PosID = (TextBox) target;
          break;
        case 7:
          this.emp_Mobile = (TextBox) target;
          break;
        case 8:
          this.emp_Tel = (TextBox) target;
          break;
        case 9:
          this.emp_EnterDate = (DatePicker) target;
          break;
        case 10:
          this.emp_Zipcode = (TextBox) target;
          break;
        case 11:
          this.emp_Addr1 = (TextBox) target;
          break;
        case 12:
          this.emp_Addr2 = (TextBox) target;
          break;
        case 13:
          this.emp_Email = (TextBox) target;
          break;
        case 14:
          this.emp_ResignationStatus = (ComboBox) target;
          break;
        case 15:
          this.emp_ResignationDate = (DatePicker) target;
          break;
        case 16:
          this.emp_ExtensionNumber = (TextBox) target;
          break;
        default:
          this._contentLoaded = true;
          break;
      }
    }
  }
}
