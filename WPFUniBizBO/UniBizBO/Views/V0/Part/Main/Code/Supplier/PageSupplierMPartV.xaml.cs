// Decompiled with JetBrains decompiler
// Type: UniBizBO.Views.V0.Part.Main.Code.Supplier.PageSupplierMPartV
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

namespace UniBizBO.Views.V0.Part.Main.Code.Supplier
{
  public partial class PageSupplierMPartV : UserControl, IComponentConnector
  {
    internal TextBox su_SupplierName;
    internal ComboBox su_SupplierType;
    internal ComboBox su_SupplierKind;
    internal ComboBox su_PreTaxDiv;
    internal ComboBox su_MultiSuplierDiv;
    internal ComboBox su_DeductionDayDiv;
    internal ComboBox su_LeadTime;
    internal TextBox su_Tel;
    internal TextBox su_Fax;
    internal TextBox su_ContactNm1;
    internal TextBox su_ContactMemo1;
    internal TextBox su_ContactNm2;
    internal TextBox su_ContactMemo2;
    internal TextBox su_ContactEmail1;
    internal TextBox su_ContactEmail2;
    internal TextBox su_BizNo;
    internal TextBox su_BizCeo;
    internal TextBox su_BizName;
    internal TextBox su_RegidentNo;
    internal TextBox su_BizType;
    internal TextBox su_BizCategory;
    internal TextBox su_ZipCode;
    internal TextBox su_Addr1;
    internal TextBox su_Addr2;
    internal TextBox su_ErpCode;
    internal ComboBox su_BankCode;
    internal TextBox su_AccountName;
    internal TextBox su_AccountNo;
    internal TextBox su_EmailStatement;
    internal TextBox su_EmailTax;
    internal TextBox su_Deposit;
    internal TextBox su_Memo1;
    internal TextBox su_Memo2;
    private bool _contentLoaded;

    public PageSupplierMPartV() => this.InitializeComponent();

    [DebuggerNonUserCode]
    [GeneratedCode("PresentationBuildTasks", "5.0.17.0")]
    public void InitializeComponent()
    {
      if (this._contentLoaded)
        return;
      this._contentLoaded = true;
      Application.LoadComponent((object) this, new Uri("/UniBizBO;component/views/v0/part/main/code/supplier/pagesuppliermpartv.xaml", UriKind.Relative));
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
          this.su_SupplierName = (TextBox) target;
          break;
        case 2:
          this.su_SupplierType = (ComboBox) target;
          break;
        case 3:
          this.su_SupplierKind = (ComboBox) target;
          break;
        case 4:
          this.su_PreTaxDiv = (ComboBox) target;
          break;
        case 5:
          this.su_MultiSuplierDiv = (ComboBox) target;
          break;
        case 6:
          this.su_DeductionDayDiv = (ComboBox) target;
          break;
        case 7:
          this.su_LeadTime = (ComboBox) target;
          break;
        case 8:
          this.su_Tel = (TextBox) target;
          break;
        case 9:
          this.su_Fax = (TextBox) target;
          break;
        case 10:
          this.su_ContactNm1 = (TextBox) target;
          break;
        case 11:
          this.su_ContactMemo1 = (TextBox) target;
          break;
        case 12:
          this.su_ContactNm2 = (TextBox) target;
          break;
        case 13:
          this.su_ContactMemo2 = (TextBox) target;
          break;
        case 14:
          this.su_ContactEmail1 = (TextBox) target;
          break;
        case 15:
          this.su_ContactEmail2 = (TextBox) target;
          break;
        case 16:
          this.su_BizNo = (TextBox) target;
          break;
        case 17:
          this.su_BizCeo = (TextBox) target;
          break;
        case 18:
          this.su_BizName = (TextBox) target;
          break;
        case 19:
          this.su_RegidentNo = (TextBox) target;
          break;
        case 20:
          this.su_BizType = (TextBox) target;
          break;
        case 21:
          this.su_BizCategory = (TextBox) target;
          break;
        case 22:
          this.su_ZipCode = (TextBox) target;
          break;
        case 23:
          this.su_Addr1 = (TextBox) target;
          break;
        case 24:
          this.su_Addr2 = (TextBox) target;
          break;
        case 25:
          this.su_ErpCode = (TextBox) target;
          break;
        case 26:
          this.su_BankCode = (ComboBox) target;
          break;
        case 27:
          this.su_AccountName = (TextBox) target;
          break;
        case 28:
          this.su_AccountNo = (TextBox) target;
          break;
        case 29:
          this.su_EmailStatement = (TextBox) target;
          break;
        case 30:
          this.su_EmailTax = (TextBox) target;
          break;
        case 31:
          this.su_Deposit = (TextBox) target;
          break;
        case 32:
          this.su_Memo1 = (TextBox) target;
          break;
        case 33:
          this.su_Memo2 = (TextBox) target;
          break;
        default:
          this._contentLoaded = true;
          break;
      }
    }
  }
}
