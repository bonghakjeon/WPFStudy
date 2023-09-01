// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.StatementHeaderView
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using Serilog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.JobEvtMessage;
using UniBiz.Bo.Models.TableInfo;
using UniBiz.Bo.Models.UniBase.Employee.Employee;
using UniBiz.Bo.Models.UniBase.OuterConnAuth;
using UniBiz.Bo.Models.UniBase.Store.StoreInfo;
using UniBiz.Bo.Models.UniBase.Supplier.Supplier;
using UniBiz.Bo.Models.UniBase.Supplier.SupplierHistory;
using UniBiz.Bo.Models.UniStock.Payment.Statement;
using UniBiz.Bo.Models.UniStock.Payment.Summary;
using UniBiz.Bo.Models.UniStock.Profit.ProfitLossSummary;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniStock.Statement
{
  public class StatementHeaderView : TStatementHeader<StatementHeaderView>
  {
    private int _rowDataType;
    private int _sh_OrderStatusBefore;
    private int _sh_ConfirmStatusBefore;
    private DateTime? _sh_ConfirmDateBefore;
    private bool _IsOuterMovePermitChecked = true;
    [JsonIgnore]
    private SupplierView _SupplierInfo;
    [JsonIgnore]
    private StoreInfoView _StoreInfo;
    private string _si_StoreName;
    private string _si_StoreViewCode;
    private string _si_UseYn;
    private int _si_StoreType;
    private string _si_LocationUseYn;
    private string _si_Email;
    private int _su_HeadSupplier;
    private string _su_HeadName;
    private string _su_SupplierName;
    private string _su_SupplierViewCode;
    private int _su_SupplierType;
    private int _su_SupplierKind;
    private string _su_UseYn;
    private string _su_EmailStatement;
    private string _sh_AssignUser_Name;
    private int _su_PreTaxDiv;
    private int _su_MultiSuplierDiv;
    private string _inEmpName;
    private string _modEmpName;
    private IList<StatementDetailView> _Lt_Details;

    public int rowDataType
    {
      get => this._rowDataType;
      set
      {
        this._rowDataType = value;
        this.Changed(nameof (rowDataType));
        this.Changed("RowDataType");
        this.Changed("row_IsDataTypeTotalSum");
      }
    }

    [JsonIgnore]
    public EnumRowType RowDataType => Enum2StrConverter.ToRowType(this.rowDataType);

    [JsonIgnore]
    public bool row_IsDataTypeTotalSum => this.rowDataType == 3;

    public int sh_OrderStatusBefore
    {
      get => this._sh_OrderStatusBefore;
      set
      {
        this._sh_OrderStatusBefore = value;
        this.Changed(nameof (sh_OrderStatusBefore));
        this.Changed("IsOrderConfirmBefore");
        this.Changed("IsOrderNotConfirmBefore");
        this.Changed("IsOrderToStatementBefore");
        this.Changed("IsOrderDeleteBefore");
      }
    }

    [JsonIgnore]
    public bool IsOrderConfirmBefore => Enum2StrConverter.ToStatementOrderStatus(this.sh_OrderStatusBefore) == EnumStatementOrderStatus.Confirm;

    [JsonIgnore]
    public bool IsOrderNotConfirmBefore => Enum2StrConverter.ToStatementOrderStatus(this.sh_OrderStatusBefore) == EnumStatementOrderStatus.NotConfirm;

    [JsonIgnore]
    public bool IsOrderToStatementBefore => Enum2StrConverter.ToStatementOrderStatus(this.sh_OrderStatusBefore) == EnumStatementOrderStatus.Statement;

    [JsonIgnore]
    public bool IsOrderDeleteBefore => Enum2StrConverter.ToStatementOrderStatus(this.sh_OrderStatusBefore) == EnumStatementOrderStatus.Delete;

    public int sh_ConfirmStatusBefore
    {
      get => this._sh_ConfirmStatusBefore;
      set
      {
        this._sh_ConfirmStatusBefore = value;
        this.Changed(nameof (sh_ConfirmStatusBefore));
        this.Changed("IsConfirmBefore");
        this.Changed("IsNotConfirmBefore");
        this.Changed("IsDeleteBefore");
      }
    }

    [JsonIgnore]
    public bool IsConfirmBefore => Enum2StrConverter.ToStatementConfirmStatus(this.sh_ConfirmStatusBefore) == EnumStatementConfirmStatus.Confirm;

    [JsonIgnore]
    public bool IsNotConfirmBefore => Enum2StrConverter.ToStatementConfirmStatus(this.sh_ConfirmStatusBefore) == EnumStatementConfirmStatus.NotConfirm;

    [JsonIgnore]
    public bool IsDeleteBefore => Enum2StrConverter.ToStatementConfirmStatus(this.sh_ConfirmStatusBefore) == EnumStatementConfirmStatus.Delete;

    [JsonIgnore]
    public DateTime? sh_ConfirmDateBefore
    {
      get => this._sh_ConfirmDateBefore;
      set
      {
        this._sh_ConfirmDateBefore = value;
        this.Changed(nameof (sh_ConfirmDateBefore));
      }
    }

    [JsonIgnore]
    public bool IsOuterMovePermitChecked
    {
      get => this._IsOuterMovePermitChecked;
      set
      {
        this._IsOuterMovePermitChecked = value;
        this.Changed(nameof (IsOuterMovePermitChecked));
      }
    }

    public string si_StoreName
    {
      get => this._si_StoreName;
      set
      {
        this._si_StoreName = value;
        this.Changed(nameof (si_StoreName));
      }
    }

    public string si_StoreViewCode
    {
      get => this._si_StoreViewCode;
      set
      {
        this._si_StoreViewCode = value;
        this.Changed(nameof (si_StoreViewCode));
      }
    }

    public string si_UseYn
    {
      get => this._si_UseYn;
      set
      {
        this._si_UseYn = value;
        this.Changed(nameof (si_UseYn));
        this.Changed("si_IsUseYn");
        this.Changed("si_UseYnDesc");
      }
    }

    public bool si_IsUseYn => "Y".Equals(this.si_UseYn);

    public string si_UseYnDesc => !"Y".Equals(this.si_UseYn) ? "미사용" : "사용";

    public int si_StoreType
    {
      get => this._si_StoreType;
      set
      {
        this._si_StoreType = value;
        this.Changed(nameof (si_StoreType));
        this.Changed("si_StoreTypeDesc");
      }
    }

    public string si_StoreTypeDesc => this.si_StoreType != 0 ? Enum2StrConverter.ToStoreType(this.si_StoreType).ToDescription() : string.Empty;

    public string si_LocationUseYn
    {
      get => this._si_LocationUseYn;
      set
      {
        this._si_LocationUseYn = value;
        this.Changed(nameof (si_LocationUseYn));
      }
    }

    public string si_Email
    {
      get => this._si_Email;
      set
      {
        this._si_Email = value;
        this.Changed(nameof (si_Email));
      }
    }

    public int su_HeadSupplier
    {
      get => this._su_HeadSupplier;
      set
      {
        this._su_HeadSupplier = value;
        this.Changed(nameof (su_HeadSupplier));
      }
    }

    public string su_HeadName
    {
      get => this._su_HeadName;
      set
      {
        this._su_HeadName = value;
        this.Changed(nameof (su_HeadName));
      }
    }

    public string su_SupplierName
    {
      get => this._su_SupplierName;
      set
      {
        this._su_SupplierName = value;
        this.Changed(nameof (su_SupplierName));
      }
    }

    public string su_SupplierViewCode
    {
      get => this._su_SupplierViewCode;
      set
      {
        this._su_SupplierViewCode = value;
        this.Changed(nameof (su_SupplierViewCode));
      }
    }

    public int su_SupplierType
    {
      get => this._su_SupplierType;
      set
      {
        this._su_SupplierType = value;
        this.Changed(nameof (su_SupplierType));
      }
    }

    public string su_SupplierTypeDesc => this.su_SupplierType != 0 ? Enum2StrConverter.ToSupplierType(this.su_SupplierType).ToDescription() : string.Empty;

    public int su_SupplierKind
    {
      get => this._su_SupplierKind;
      set
      {
        this._su_SupplierKind = value;
        this.Changed(nameof (su_SupplierKind));
      }
    }

    public string su_SupplierKindDesc => this.su_SupplierKind != 0 ? Enum2StrConverter.ToSupplierKind(this.su_SupplierKind).ToDescription() : string.Empty;

    public string su_UseYn
    {
      get => this._su_UseYn;
      set
      {
        this._su_UseYn = value;
        this.Changed(nameof (su_UseYn));
        this.Changed("su_IsUseYn");
        this.Changed("su_UseYnDesc");
      }
    }

    public bool su_IsUseYn => "Y".Equals(this.su_UseYn);

    public string su_UseYnDesc => !"Y".Equals(this.su_UseYn) ? "미사용" : "사용";

    public string su_EmailStatement
    {
      get => this._su_EmailStatement;
      set
      {
        this._su_EmailStatement = value;
        this.Changed(nameof (su_EmailStatement));
      }
    }

    public string sh_AssignUser_Name
    {
      get => this._sh_AssignUser_Name;
      set
      {
        this._sh_AssignUser_Name = value;
        this.Changed(nameof (sh_AssignUser_Name));
      }
    }

    public int su_PreTaxDiv
    {
      get => this._su_PreTaxDiv;
      set
      {
        this._su_PreTaxDiv = value;
        this.Changed(nameof (su_PreTaxDiv));
      }
    }

    public string su_PreTaxDivDesc => this.su_PreTaxDiv != 0 ? Enum2StrConverter.ToStdPreTax(this.su_PreTaxDiv).ToDescription() : string.Empty;

    public int su_MultiSuplierDiv
    {
      get => this._su_MultiSuplierDiv;
      set
      {
        this._su_MultiSuplierDiv = value;
        this.Changed(nameof (su_MultiSuplierDiv));
      }
    }

    public string su_MultiSuplierDivDesc => this.su_MultiSuplierDiv != 0 ? Enum2StrConverter.ToSupplierMulti(this.su_MultiSuplierDiv).ToDescription() : string.Empty;

    public string inEmpName
    {
      get => this._inEmpName;
      set
      {
        this._inEmpName = value;
        this.Changed(nameof (inEmpName));
      }
    }

    public string modEmpName
    {
      get => this._modEmpName;
      set
      {
        this._modEmpName = value;
        this.Changed(nameof (modEmpName));
      }
    }

    [JsonPropertyName("lt_Details")]
    public IList<StatementDetailView> Lt_Details
    {
      get => this._Lt_Details ?? (this._Lt_Details = (IList<StatementDetailView>) new List<StatementDetailView>());
      set
      {
        this._Lt_Details = value;
        this.Changed(nameof (Lt_Details));
      }
    }

    public override Dictionary<string, TTableColumn> ToColumnInfo() => base.ToColumnInfo();

    public override void Clear()
    {
      base.Clear();
      this.rowDataType = 1;
      this.sh_OrderStatusBefore = this.sh_ConfirmStatusBefore = 0;
      this.sh_ConfirmDateBefore = new DateTime?();
      this.IsOuterMovePermitChecked = true;
      this._SupplierInfo = (SupplierView) null;
      this._StoreInfo = (StoreInfoView) null;
      this.si_StoreName = string.Empty;
      this.si_StoreViewCode = string.Empty;
      this.si_UseYn = "Y";
      this.si_StoreType = 0;
      this.si_LocationUseYn = string.Empty;
      this.si_Email = string.Empty;
      this.su_HeadSupplier = 0;
      this.su_HeadName = string.Empty;
      this.su_SupplierName = this.su_SupplierViewCode = string.Empty;
      this.su_SupplierType = 0;
      this.su_SupplierKind = 0;
      this.su_UseYn = "Y";
      this.su_EmailStatement = string.Empty;
      this.sh_AssignUser_Name = string.Empty;
      this.su_PreTaxDiv = this.su_MultiSuplierDiv = 0;
      this.inEmpName = string.Empty;
      this.modEmpName = string.Empty;
      this.Lt_Details = (IList<StatementDetailView>) null;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new StatementHeaderView();

    public override object Clone()
    {
      StatementHeaderView statementHeaderView = base.Clone() as StatementHeaderView;
      statementHeaderView.rowDataType = this.rowDataType;
      statementHeaderView.sh_OrderStatusBefore = this.sh_OrderStatusBefore;
      statementHeaderView.sh_ConfirmStatusBefore = this.sh_ConfirmStatusBefore;
      statementHeaderView.sh_ConfirmDateBefore = this.sh_ConfirmDateBefore;
      statementHeaderView.IsOuterMovePermitChecked = this.IsOuterMovePermitChecked;
      statementHeaderView.si_StoreName = this.si_StoreName;
      statementHeaderView.si_StoreViewCode = this.si_StoreViewCode;
      statementHeaderView.si_UseYn = this.si_UseYn;
      statementHeaderView.si_StoreType = this.si_StoreType;
      statementHeaderView.si_LocationUseYn = this.si_LocationUseYn;
      statementHeaderView.si_Email = this.si_Email;
      statementHeaderView.su_HeadSupplier = this.su_HeadSupplier;
      statementHeaderView.su_HeadName = this.su_HeadName;
      statementHeaderView.su_SupplierName = this.su_SupplierName;
      statementHeaderView.su_SupplierViewCode = this.su_SupplierViewCode;
      statementHeaderView.su_SupplierType = this.su_SupplierType;
      statementHeaderView.su_SupplierKind = this.su_SupplierKind;
      statementHeaderView.su_UseYn = this.su_UseYn;
      statementHeaderView.su_EmailStatement = this.su_EmailStatement;
      statementHeaderView.sh_AssignUser_Name = this.sh_AssignUser_Name;
      statementHeaderView.su_PreTaxDiv = this.su_PreTaxDiv;
      statementHeaderView.su_MultiSuplierDiv = this.su_MultiSuplierDiv;
      statementHeaderView.inEmpName = this.inEmpName;
      statementHeaderView.modEmpName = this.modEmpName;
      statementHeaderView.Lt_Details = (IList<StatementDetailView>) null;
      if (this.Lt_Details.Count > 0)
        statementHeaderView.Lt_Details = this.Lt_Details;
      return (object) statementHeaderView;
    }

    public void PutData(StatementHeaderView pSource)
    {
      this.PutData((TStatementHeader) pSource);
      this.rowDataType = pSource.rowDataType;
      this.sh_OrderStatusBefore = pSource.sh_OrderStatusBefore;
      this.sh_ConfirmStatusBefore = pSource.sh_ConfirmStatusBefore;
      this.sh_ConfirmDateBefore = pSource.sh_ConfirmDateBefore;
      this.IsOuterMovePermitChecked = pSource.IsOuterMovePermitChecked;
      this.si_StoreName = pSource.si_StoreName;
      this.si_StoreViewCode = pSource.si_StoreViewCode;
      this.si_UseYn = pSource.si_UseYn;
      this.si_StoreType = pSource.si_StoreType;
      this.si_LocationUseYn = pSource.si_LocationUseYn;
      this.si_Email = pSource.si_Email;
      this.su_HeadSupplier = pSource.su_HeadSupplier;
      this.su_HeadName = pSource.su_HeadName;
      this.su_SupplierName = pSource.su_SupplierName;
      this.su_SupplierViewCode = pSource.su_SupplierViewCode;
      this.su_SupplierType = pSource.su_SupplierType;
      this.su_SupplierKind = pSource.su_SupplierKind;
      this.su_UseYn = pSource.su_UseYn;
      this.su_EmailStatement = pSource.su_EmailStatement;
      this.sh_AssignUser_Name = pSource.sh_AssignUser_Name;
      this.su_PreTaxDiv = pSource.su_PreTaxDiv;
      this.su_MultiSuplierDiv = pSource.su_MultiSuplierDiv;
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
      this.Lt_Details = (IList<StatementDetailView>) null;
      if (pSource.Lt_Details.Count <= 0)
        return;
      foreach (StatementDetailView ltDetail in (IEnumerable<StatementDetailView>) pSource.Lt_Details)
      {
        StatementDetailView statementDetailView = new StatementDetailView();
        statementDetailView.PutData(ltDetail);
        this.Lt_Details.Add(statementDetailView);
      }
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.sh_SiteID == 0L)
      {
        this.message = "싸이트(sh_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.sh_StoreCode == 0)
      {
        this.message = "지점코드(sh_StoreCode)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.sh_Supplier == 0)
      {
        this.message = "코드(sh_Supplier)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (Enum2StrConverter.ToStatementType(this.sh_StatementType) == EnumStatementType.None)
      {
        this.message = "전표 타입(sh_StatementType) " + EnumDataCheck.Valid.ToDescription();
        return EnumDataCheck.Valid;
      }
      if (this.IsBuy || this.IsSale)
      {
        if (this.sh_Supplier < 1001)
        {
          this.message = string.Format("{0}({1}),{2}({3})  {4}", (object) "코드", (object) "sh_Supplier", (object) this.sh_StatementTypeDesc, (object) this.sh_StatementType, (object) EnumDataCheck.Valid.ToDescription());
          return EnumDataCheck.Valid;
        }
      }
      else if (this.IsInnerMove)
      {
        if (this.sh_Supplier != this.sh_StoreCode)
        {
          this.message = string.Format("{0}({1}),{2}({3})  {4}", (object) "코드", (object) "sh_Supplier", (object) this.sh_StatementTypeDesc, (object) this.sh_StatementType, (object) EnumDataCheck.Valid.ToDescription());
          return EnumDataCheck.Valid;
        }
      }
      else if (this.IsOuterMove && this.sh_Supplier >= 1001)
      {
        this.message = string.Format("{0}({1}),{2}({3})  {4}", (object) "코드", (object) "sh_Supplier", (object) this.sh_StatementTypeDesc, (object) this.sh_StatementType, (object) EnumDataCheck.Valid.ToDescription());
        return EnumDataCheck.Valid;
      }
      if (Enum2StrConverter.ToInOutDiv(this.sh_InOutDiv) != EnumInOutDiv.None)
        return EnumDataCheck.Success;
      this.message = "입출고 타입(sh_InOutDiv) " + EnumDataCheck.Valid.ToDescription();
      return EnumDataCheck.Valid;
    }

    protected override EnumDataCheck DataCheck(UniOleDatabase p_db)
    {
      if (p_db == null)
      {
        this.message = "DB CONNECT (UniOleDatabase) " + EnumDataCheck.NULL.ToDescription();
        return EnumDataCheck.NULL;
      }
      EnumDataCheck enumDataCheck = this.DataCheck();
      if (enumDataCheck != EnumDataCheck.Success)
        return enumDataCheck;
      if (this.IsNew)
      {
        this._SupplierInfo = p_db.Create<SupplierView>().SelectOneT<SupplierView>((object) new Hashtable()
        {
          {
            (object) "su_SiteID",
            (object) this.sh_SiteID
          },
          {
            (object) "su_Supplier",
            (object) this.sh_Supplier
          }
        });
        if (this._SupplierInfo == null || this._SupplierInfo.su_Supplier == 0)
        {
          this.message = "코드(sh_Supplier)  " + EnumDataCheck.Valid.ToDescription();
          return EnumDataCheck.Valid;
        }
      }
      return this.IsDeadLineCheck(p_db);
    }

    protected EnumDataCheck IsDeadLineCheck(UniOleDatabase p_db)
    {
      if (this._StoreInfo == null || this._StoreInfo.si_StoreCode == 0 || this._StoreInfo.si_StoreCode != this.sh_StoreCode)
        this._StoreInfo = p_db.Create<StoreInfoView>().SelectOneT<StoreInfoView>((object) new Hashtable()
        {
          {
            (object) "si_SiteID",
            (object) this.sh_SiteID
          },
          {
            (object) "si_StoreCode",
            (object) this.sh_StoreCode
          }
        });
      if (this._StoreInfo == null || this._StoreInfo.si_StoreCode == 0)
      {
        this.message = "지점코드(sh_StoreCode)  " + EnumDataCheck.Valid.ToDescription();
        return EnumDataCheck.Valid;
      }
      DateTime? nullable1;
      DateTime? nullable2;
      if (this.IsConfirm)
      {
        if (!this._StoreInfo.si_StockConfirmDate.HasValue || !this._StoreInfo.si_BuyConfirmDate.HasValue || !this._StoreInfo.si_StockStartDate.HasValue)
        {
          this.message = "지점 확정일자(NULL) 확인 필요. " + EnumDataCheck.DateDeadLind.ToDescription();
          return EnumDataCheck.DateDeadLind;
        }
        DateTime? shConfirmDate = this.sh_ConfirmDate;
        nullable1 = this._StoreInfo.si_StockConfirmDate;
        if ((shConfirmDate.HasValue & nullable1.HasValue ? (shConfirmDate.GetValueOrDefault() < nullable1.GetValueOrDefault() ? 1 : 0) : 0) != 0)
        {
          this.message = string.Format("{0}:{1} > {2}:{3}", (object) "수불확정일", (object) this._StoreInfo.si_StockConfirmDate, (object) "확정일", (object) this.sh_ConfirmDate);
          return EnumDataCheck.DateDeadLind;
        }
        nullable1 = this.sh_ConfirmDate;
        nullable2 = this._StoreInfo.si_BuyConfirmDate;
        if ((nullable1.HasValue & nullable2.HasValue ? (nullable1.GetValueOrDefault() < nullable2.GetValueOrDefault() ? 1 : 0) : 0) != 0)
        {
          this.message = string.Format("{0}:{1} > {2}:{3}", (object) "매입확정일", (object) this._StoreInfo.si_BuyConfirmDate, (object) "확정일", (object) this.sh_ConfirmDate);
          return EnumDataCheck.DateDeadLind;
        }
        nullable2 = this.sh_ConfirmDate;
        nullable1 = this._StoreInfo.si_StockStartDate;
        if ((nullable2.HasValue & nullable1.HasValue ? (nullable2.GetValueOrDefault() < nullable1.GetValueOrDefault() ? 1 : 0) : 0) != 0)
        {
          this.message = string.Format("{0}:{1} > {2}:{3}", (object) "수불시작일", (object) this._StoreInfo.si_StockStartDate, (object) "확정일", (object) this.sh_ConfirmDate);
          return EnumDataCheck.DateDeadLind;
        }
      }
      if (this.IsConfirmBefore)
      {
        nullable1 = this.sh_ConfirmDateBefore;
        nullable2 = this._StoreInfo.si_StockConfirmDate;
        if ((nullable1.HasValue & nullable2.HasValue ? (nullable1.GetValueOrDefault() < nullable2.GetValueOrDefault() ? 1 : 0) : 0) != 0)
        {
          this.message = string.Format("{0}:{1} > 이전 {2}:{3}", (object) "수불확정일", (object) this._StoreInfo.si_StockConfirmDate, (object) "확정일", (object) this.sh_ConfirmDateBefore);
          return EnumDataCheck.DateDeadLind;
        }
        nullable2 = this.sh_ConfirmDateBefore;
        nullable1 = this._StoreInfo.si_BuyConfirmDate;
        if ((nullable2.HasValue & nullable1.HasValue ? (nullable2.GetValueOrDefault() < nullable1.GetValueOrDefault() ? 1 : 0) : 0) != 0)
        {
          this.message = string.Format("{0}:{1} > 이전 {2}:{3}", (object) "매입확정일", (object) this._StoreInfo.si_BuyConfirmDate, (object) "확정일", (object) this.sh_ConfirmDateBefore);
          return EnumDataCheck.DateDeadLind;
        }
        nullable1 = this.sh_ConfirmDateBefore;
        nullable2 = this._StoreInfo.si_StockStartDate;
        if ((nullable1.HasValue & nullable2.HasValue ? (nullable1.GetValueOrDefault() < nullable2.GetValueOrDefault() ? 1 : 0) : 0) != 0)
        {
          this.message = string.Format("{0}:{1} > 이전 {2}:{3}", (object) "수불시작일", (object) this._StoreInfo.si_StockStartDate, (object) "확정일", (object) this.sh_ConfirmDateBefore);
          return EnumDataCheck.DateDeadLind;
        }
      }
      return EnumDataCheck.Success;
    }

    protected bool IsOrderStatementCheck(bool p_isStatement, EmployeeView p_app_employee)
    {
      if (!p_isStatement)
      {
        this.message = p_app_employee.emp_Name + "님(Permit) 주문 전표 전표 등록 불가.";
        return false;
      }
      bool flag = this.IsOrderConfirmBefore || this.IsOrderToStatementBefore;
      if (flag && !p_app_employee.IsOrderConfirm)
      {
        this.message = p_app_employee.emp_Name + "님(Permit) 주문 확정 전표 변경 불가.";
        return false;
      }
      if (this.IsOrderDeleteBefore && !p_app_employee.IsOrderDelete)
      {
        this.message = p_app_employee.emp_Name + "님(Permit) 주문 삭제 전표 변경 불가.";
        return false;
      }
      if (flag && !p_app_employee.IsOrderConfirm)
      {
        this.message = p_app_employee.emp_Name + "님(Permit) 주문 [전표확정,전표이동] 불가.";
        return false;
      }
      if (!this.IsOrderDelete || p_app_employee.IsOrderDelete)
        return true;
      this.message = p_app_employee.emp_Name + "님(Permit) 주문 전표 삭제 불가.";
      return false;
    }

    protected bool IsStatementCheck(
      bool p_isStatement,
      bool p_isConfirm,
      bool p_isDelete,
      EmployeeView p_app_employee)
    {
      if (!p_isStatement)
      {
        this.message = p_app_employee.emp_Name + "님(Permit) 전표 등록 불가.";
        return false;
      }
      if (this.IsConfirmBefore && !p_isConfirm)
      {
        this.message = p_app_employee.emp_Name + "님(Permit) 확정 전표 변경 불가.";
        return false;
      }
      if (this.IsDeleteBefore && !p_isDelete)
      {
        this.message = p_app_employee.emp_Name + "님(Permit) 삭제 전표 변경 불가.";
        return false;
      }
      if (this.IsConfirm && !p_isConfirm)
      {
        this.message = p_app_employee.emp_Name + "님(Permit) 전표 확정 불가.";
        return false;
      }
      if (this.IsDelete && !p_isDelete)
      {
        this.message = p_app_employee.emp_Name + "님(Permit) 전표 삭제 불가.";
        return false;
      }
      if (this.IsConfirmBefore && this.IsConfirm)
      {
        this.message = "확정 상태 변경 불가.\n - 미확정 변경 후 수정 가능.";
        return false;
      }
      if (this.IsConfirmBefore && this.IsDelete)
      {
        this.message = "확정 상태 에서 삭제 불가.\n -  미확정 변경 후 삭제 가능.";
        return false;
      }
      if (!this.IsDeleteBefore || !this.IsConfirm)
        return true;
      this.message = "삭제 상태 에서 확정 불가.\n -  미확정 변경 후 확정 가능.";
      return false;
    }

    protected override bool IsPermit(EmployeeView p_app_employee)
    {
      if (p_app_employee == null)
      {
        this.message = "사용자 정보 NULL.";
        return false;
      }
      if (EnumDataCheck.Success != this.DataCheck(this.OleDB))
        return false;
      if (this.IsBuy)
        return this.IsOrder ? this.IsOrderStatementCheck(this.IsOrder, p_app_employee) : this.IsStatementCheck(this.IsBuy, p_app_employee.IsBuyConfirm, p_app_employee.IsBuyDelete, p_app_employee);
      if (!this.IsSale)
      {
        if (this.IsInnerMove)
          return this.IsOrder ? this.IsOrderStatementCheck(this.IsOrder, p_app_employee) : this.IsStatementCheck(this.IsInnerMove, p_app_employee.IsInnerMoveConfirm, p_app_employee.IsInnerMoveDelete, p_app_employee);
        if (this.IsOuterMove)
        {
          if (this.IsInOutReturn)
          {
            if (this.IsOuterMovePermitChecked)
            {
              if (this.IsConfirmBefore)
              {
                this.message = "이미 확정된 점간 대출 전표 입니다.\n " + this.su_SupplierName + " 지점에서 미확정 변경 요청 하여 주세요.";
                return false;
              }
              if (this.IsConfirm)
              {
                this.message = "점간 대출 전표 확정 불가 합니다.\n " + this.su_SupplierName + " 지점에서 확정하여 주세요.";
                return false;
              }
            }
          }
          else if (this.IsOuterMovePermitChecked)
          {
            if (this.IsDelete)
            {
              this.message = "점간 대입 삭제 전표 수정 불가 합니다.\n " + this.su_SupplierName + " 지점에서 수정하여 주세요.";
              return false;
            }
            if (!this.IsConfirm && !this.IsNotConfirm)
            {
              this.message = "점간 대입 전표 확정 외 불가 합니다.\n " + this.su_SupplierName + " 지점에서 수정하여 주세요.";
              return false;
            }
          }
        }
        else
        {
          if (this.IsAdjust)
            return this.IsStatementCheck(this.IsAdjust, p_app_employee.IsAdjustConfirm, p_app_employee.IsAdjustDelete, p_app_employee);
          if (this.IsDisuse)
            return this.IsStatementCheck(this.IsDisuse, p_app_employee.IsDisuseConfirm, p_app_employee.IsDisuseDelete, p_app_employee);
          if (this.IsPayment)
            return this.IsStatementCheck(this.IsPayment, p_app_employee.IsPaymentConfirm, p_app_employee.IsPaymentDelete, p_app_employee);
          int num = this.IsStockMove ? 1 : 0;
        }
      }
      this.message = p_app_employee.emp_Name + "님(Permit) " + this.sh_StatementTypeDesc + " 전표 변경불가.";
      return false;
    }

    public override string CreateCodeQuery()
    {
      base.CreateCodeQuery();
      int num = this.sh_ConfirmDate.HasValue ? this.sh_ConfirmDate.Value.ToIntFormat() : DateTime.Now.ToIntFormat();
      string str = string.Format("{0}{1:D4}0000", (object) num, (object) this.sh_StoreCode);
      return " SELECT " + DbQueryHelper.ToIsNULL() + "(MAX(sh_StatementNo), " + str + ")+1 AS sh_StatementNo" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) this.TableCode, (object) DbQueryHelper.ToWithNolock()) + string.Format(" WHERE ({0}/100000000)={1}", (object) "sh_StatementNo", (object) num) + string.Format(" AND (({0}%100000000)/10000)={1}", (object) "sh_StatementNo", (object) this.sh_StoreCode);
    }

    public override bool CreateCode(UniOleDatabase p_db)
    {
      UniOleDbRecordset uniOleDbRecordset = (UniOleDbRecordset) null;
      UniOleDatabase pOleDB = (UniOleDatabase) null;
      try
      {
        pOleDB = new UniOleDatabase(p_db.ConnectionUrl);
        uniOleDbRecordset = new UniOleDbRecordset(pOleDB, pOleDB.CommandTimeout);
        string codeQuery = this.CreateCodeQuery();
        if (!uniOleDbRecordset.Open(codeQuery))
        {
          this.message = " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) pOleDB.LastErrorID) + " 내용 : " + pOleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          return false;
        }
        if (uniOleDbRecordset.IsDataRead())
          this.sh_StatementNo = uniOleDbRecordset.GetFieldLong(0);
        return this.sh_StatementNo > 0L;
      }
      finally
      {
        uniOleDbRecordset?.Close();
        pOleDB?.Close();
      }
    }

    public override async Task<bool> CreateCodeAsync(UniOleDatabase p_db)
    {
      StatementHeaderView statementHeaderView = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(p_db.ConnectionUrl);
        rs = new UniOleDbRecordset(db, db.CommandTimeout);
        if (!await rs.OpenAsync(statementHeaderView.CreateCodeQuery()))
        {
          statementHeaderView.message = " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + statementHeaderView.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) db.LastErrorID) + " 내용 : " + db.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          return false;
        }
        if (await rs.IsDataReadAsync())
          statementHeaderView.sh_StatementNo = rs.GetFieldLong(0);
        return statementHeaderView.sh_StatementNo > 0L;
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.sh_OrderStatusBefore = p_rs.GetFieldInt("sh_OrderStatus");
      this.sh_ConfirmStatusBefore = p_rs.GetFieldInt("sh_ConfirmStatus");
      this.sh_ConfirmDateBefore = p_rs.GetFieldDateTime("sh_ConfirmDate");
      this.si_StoreViewCode = p_rs.GetFieldString("si_StoreViewCode");
      this.si_StoreName = p_rs.GetFieldString("si_StoreName");
      this.si_UseYn = p_rs.GetFieldString("si_UseYn");
      this.si_StoreType = p_rs.GetFieldInt("si_StoreType");
      this.si_LocationUseYn = p_rs.GetFieldString("si_LocationUseYn");
      this.si_Email = p_rs.GetFieldString("si_Email");
      this.su_HeadSupplier = p_rs.GetFieldInt("su_HeadSupplier");
      this.su_HeadName = p_rs.GetFieldString("su_HeadName");
      this.su_SupplierViewCode = p_rs.GetFieldString("su_SupplierViewCode");
      this.su_SupplierName = p_rs.GetFieldString("su_SupplierName");
      this.su_SupplierType = p_rs.GetFieldInt("su_SupplierType");
      this.su_SupplierKind = p_rs.GetFieldInt("su_SupplierKind");
      this.su_UseYn = p_rs.GetFieldString("su_UseYn");
      this.su_EmailStatement = p_rs.GetFieldString("su_EmailStatement");
      this.sh_AssignUser_Name = p_rs.GetFieldString("sh_AssignUser_Name");
      this.su_PreTaxDiv = p_rs.GetFieldInt("su_PreTaxDiv");
      this.su_MultiSuplierDiv = p_rs.GetFieldInt("su_MultiSuplierDiv");
      this.inEmpName = p_rs.GetFieldString("inEmpName");
      this.modEmpName = p_rs.GetFieldString("modEmpName");
      return true;
    }

    public async Task<StatementHeaderView> SelectOneAsync(long p_sh_StatementNo, long p_sh_SiteID = 0)
    {
      StatementHeaderView statementHeaderView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "sh_StatementNo",
          (object) p_sh_StatementNo
        }
      };
      if (p_sh_SiteID > 0L)
        p_param.Add((object) "sh_SiteID", (object) p_sh_SiteID);
      return await statementHeaderView.SelectOneTAsync<StatementHeaderView>((object) p_param);
    }

    public StatementHeaderView SelectOne(long p_sh_StatementNo, long p_sh_SiteID = 0)
    {
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "sh_StatementNo",
          (object) p_sh_StatementNo
        }
      };
      if (p_sh_SiteID > 0L)
        p_param.Add((object) "sh_SiteID", (object) p_sh_SiteID);
      return this.SelectOneT<StatementHeaderView>((object) p_param);
    }

    public async Task<IList<StatementHeaderView>> SelectListAsync(object p_param)
    {
      StatementHeaderView statementHeaderView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(statementHeaderView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, statementHeaderView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(statementHeaderView1.GetSelectQuery(p_param)))
        {
          statementHeaderView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + statementHeaderView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<StatementHeaderView>) null;
        }
        IList<StatementHeaderView> lt_list = (IList<StatementHeaderView>) new List<StatementHeaderView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            StatementHeaderView statementHeaderView2 = statementHeaderView1.OleDB.Create<StatementHeaderView>();
            if (statementHeaderView2.GetFieldValues(rs))
            {
              statementHeaderView2.row_number = lt_list.Count + 1;
              lt_list.Add(statementHeaderView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + statementHeaderView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<StatementHeaderView> SelectEnumerableAsync(object p_param)
    {
      StatementHeaderView statementHeaderView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(statementHeaderView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, statementHeaderView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(statementHeaderView1.GetSelectQuery(p_param)))
        {
          statementHeaderView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + statementHeaderView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            StatementHeaderView statementHeaderView2 = statementHeaderView1.OleDB.Create<StatementHeaderView>();
            if (statementHeaderView2.GetFieldValues(rs))
            {
              statementHeaderView2.row_number = ++row_number;
              yield return statementHeaderView2;
            }
          }
          while (await rs.IsDataReadAsync());
        }
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public override string GetSelectWhereAnd(object p_param)
    {
      StringBuilder stringBuilder = new StringBuilder(this.GetSelectWhereAnd(p_param, false));
      if (string.IsNullOrWhiteSpace(stringBuilder.ToString()))
        stringBuilder.Append(" WHERE");
      if (p_param is Hashtable hashtable && hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
      {
        stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "sh_Memo", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "sh_DeliveryNumber", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "su_SupplierName", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(")");
      }
      return !stringBuilder.ToString().Equals(" WHERE") ? stringBuilder.Replace("WHERE AND", "WHERE").ToString() : string.Empty;
    }

    public override string GetSelectQuery(object p_param)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable hashtable1 = new Hashtable();
      try
      {
        string uniBase = UbModelBase.UNI_BASE;
        string str = this.TableCode.ToString();
        string empty = string.Empty;
        int num = 0;
        long p_SiteID = 0;
        if (p_param is Hashtable hashtable2)
        {
          if (hashtable2.ContainsKey((object) "DBMS") && hashtable2[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable2[(object) "DBMS"].ToString();
          if (hashtable2.ContainsKey((object) "table") && hashtable2[(object) "table"].ToString().Length > 0)
            str = hashtable2[(object) "table"].ToString();
          if (hashtable2.ContainsKey((object) "_ORDER_BY_TYPE_") && Convert.ToInt32(hashtable2[(object) "_ORDER_BY_TYPE_"].ToString()) > 0)
            num = Convert.ToInt32(hashtable2[(object) "_ORDER_BY_TYPE_"].ToString());
          if (hashtable2.ContainsKey((object) "_ORDER_BY_COL_") && hashtable2[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable2[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable2.ContainsKey((object) "sh_SiteID") && Convert.ToInt64(hashtable2[(object) "sh_SiteID"].ToString()) > 0L)
            p_SiteID = Convert.ToInt64(hashtable2[(object) "sh_SiteID"].ToString());
        }
        stringBuilder.Append(this.ToWithStoreQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithSupplierQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithHeadSupplierQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithEmployeeInQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithEmployeeModQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithEmployeeAssignQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithOuterConnAuthQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append("\n SELECT  sh_StatementNo,sh_SiteID,sh_StoreCode,sh_OrderDate,sh_OrderStatus,sh_ConfirmDate,sh_ConfirmStatus,sh_Supplier,sh_SupplierType,sh_InOutDiv,sh_StatementType,sh_ReasonCode,sh_CostTaxAmt,sh_CostTaxFreeAmt,sh_CostVatAmt,sh_Deposit,sh_PriceTaxAmt,sh_PriceTaxFreeAmt,sh_PriceVatAmt,sh_ProfitAmt,sh_DeviceType,sh_OuterConnAuth,sh_AdditionalOpt,sh_Memo,sh_DeliveryNumber,sh_TransmitStatus,sh_TransmitDate,sh_MobieStatementNo,sh_AssignUser,sh_InDate,sh_InUser,sh_ModDate,sh_ModUser\n,si_StoreName,si_StoreViewCode,si_StoreType,si_UseYn,si_Email,si_LocationUseYn\n,su_HeadSupplier,su_SupplierName,su_SupplierViewCode,su_SupplierType,su_UseYn,su_SupplierKind,su_PreTaxDiv,su_MultiSuplierDiv,su_EmailStatement\n,head_su_SupplierName AS su_HeadName,head_su_SupplierViewCode\n,oca_DeviceName\n,inEmpName,modEmpName,sh_AssignUser_Name");
        stringBuilder.Append("\n FROM " + DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK) + str + " " + DbQueryHelper.ToWithNolock() + "\n LEFT OUTER JOIN T_STORE ON sh_StoreCode=si_StoreCode AND sh_SiteID=si_SiteID\n LEFT OUTER JOIN T_SUPPLIER ON sh_Supplier=su_Supplier AND sh_SiteID=su_SiteID\n LEFT OUTER JOIN T_SUPPLIER_HEAD ON su_HeadSupplier=head_su_Supplier AND sh_SiteID=head_su_SiteID\n LEFT OUTER JOIN T_OUTER_CONN_AUTH ON sh_OuterConnAuth=oca_ID AND sh_SiteID=oca_SiteID\n LEFT OUTER JOIN T_EMPLOYEE_IN ON sh_InUser=emp_CodeIn\n LEFT OUTER JOIN T_EMPLOYEE_MOD ON sh_ModUser=emp_CodeMod\n LEFT OUTER JOIN T_EMPLOYEE_ASSIGN ON sh_AssignUser=emp_CodeAssign");
        stringBuilder.Append("\n");
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        if (num > 0)
        {
          switch (num)
          {
            case 1:
              stringBuilder.Append(" ORDER BY sh_Supplier,sh_StoreCode,sh_ConfirmDate,sh_StatementNo");
              break;
            case 2:
              stringBuilder.Append(" ORDER BY sh_Supplier,sh_StoreCode,sh_ConfirmDate DESC,sh_StatementNo");
              break;
            default:
              stringBuilder.Append(" ORDER BY sh_StatementNo");
              break;
          }
        }
        else if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append(" ORDER BY " + empty);
        else
          stringBuilder.Append(" ORDER BY sh_StatementNo");
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) ex.GetHashCode()) + " 내용 : " + ex.Message + "\n" + string.Format(" Query : {0}\n", (object) stringBuilder) + "--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
        stringBuilder.Clear();
      }
      finally
      {
        hashtable1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithStoreQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("WITH T_STORE AS (\nSELECT si_StoreCode,si_SiteID,si_StoreName,si_StoreViewCode,si_StoreType,si_UseYn,si_LocationUseYn,si_Email" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("sh_SiteID"))
            p_param1.Add((object) "si_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add((object) "si_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("sh_StoreCode"))
            p_param1.Add((object) "si_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("sh_StoreCode_IN_"))
            p_param1.Add((object) "si_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_STORE_AUTHS_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "si_SiteID"))
            p_param1.Add((object) "si_SiteID", (object) p_SiteID);
          stringBuilder.Append("\n");
          stringBuilder.Append(new TStoreInfo().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "si_SiteID", (object) p_SiteID));
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithSupplierQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_SUPPLIER AS (SELECT su_Supplier,su_SiteID,su_HeadSupplier,su_SupplierViewCode,su_SupplierName,su_SupplierType,su_SupplierKind,su_UseYn,su_PreTaxDiv,su_MultiSuplierDiv,su_EmailStatement" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Supplier, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("sh_SiteID"))
            p_param1.Add((object) "su_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("su_Supplier"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("su_SupplierType"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "su_SiteID"))
            p_param1.Add((object) "su_SiteID", (object) p_SiteID);
          stringBuilder.Append("\n");
          stringBuilder.Append(new TSupplier().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "su_SiteID", (object) p_SiteID));
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithHeadSupplierQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_SUPPLIER_HEAD AS (SELECT su_Supplier AS head_su_Supplier,su_SiteID AS head_su_SiteID,su_SupplierViewCode AS head_su_SupplierViewCode,su_SupplierName AS head_su_SupplierName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Supplier, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("sh_SiteID"))
            p_param1.Add((object) "su_SiteID", dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "su_SiteID"))
            p_param1.Add((object) "su_SiteID", (object) p_SiteID);
          stringBuilder.Append("\n");
          stringBuilder.Append(new TSupplier().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "su_SiteID", (object) p_SiteID));
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithEmployeeInQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_EMPLOYEE_IN AS ( SELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("sh_SiteID"))
            p_param1.Add((object) "emp_SiteID", dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "emp_SiteID"))
            p_param1.Add((object) "emp_SiteID", (object) p_SiteID);
          stringBuilder.Append("\n");
          stringBuilder.Append(new TEmployee().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "emp_SiteID", (object) p_SiteID));
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithEmployeeModQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_EMPLOYEE_MOD AS ( SELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("sh_SiteID"))
            p_param1.Add((object) "emp_SiteID", dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "emp_SiteID"))
            p_param1.Add((object) "emp_SiteID", (object) p_SiteID);
          stringBuilder.Append("\n");
          stringBuilder.Append(new TEmployee().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "emp_SiteID", (object) p_SiteID));
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithEmployeeAssignQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_EMPLOYEE_ASSIGN AS ( SELECT emp_Code AS emp_CodeAssign,emp_Name AS sh_AssignUser_Name" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("sh_SiteID"))
            p_param1.Add((object) "emp_SiteID", dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "emp_SiteID"))
            p_param1.Add((object) "emp_SiteID", (object) p_SiteID);
          stringBuilder.Append("\n");
          stringBuilder.Append(new TEmployee().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "emp_SiteID", (object) p_SiteID));
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithOuterConnAuthQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_OUTER_CONN_AUTH AS ( SELECT oca_ID,oca_SiteID,oca_ProgKind,oca_DeviceName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.OuterConnAuth, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("sh_SiteID"))
            p_param1.Add((object) "oca_SiteID", dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "oca_SiteID"))
            p_param1.Add((object) "oca_SiteID", (object) p_SiteID);
          stringBuilder.Append("\n");
          stringBuilder.Append(new TOuterConnAuth().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "oca_SiteID", (object) p_SiteID));
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public void CalcSum(bool p_isCalcDetail)
    {
      if (this.IsPayment)
        return;
      this.sh_CostTaxAmt = this.sh_CostTaxFreeAmt = this.sh_CostVatAmt = 0.0;
      this.sh_Deposit = 0.0;
      this.sh_PriceTaxAmt = this.sh_PriceTaxFreeAmt = this.sh_PriceVatAmt = 0.0;
      this.sh_ProfitAmt = 0.0;
      foreach (StatementDetailView ltDetail in (IEnumerable<StatementDetailView>) this.Lt_Details)
      {
        if (ltDetail.sd_GoodsCode != 0L)
        {
          if (p_isCalcDetail)
            ltDetail.CalcSum(this.IsOrder);
          if (ltDetail.sd_LinkRowNCount <= 0 || !ltDetail.sd_IsPackUnitEA)
          {
            this.sh_CostTaxAmt += ltDetail.sd_CostTaxAmt;
            this.sh_CostTaxFreeAmt += ltDetail.sd_CostTaxFreeAmt;
            this.sh_CostVatAmt += ltDetail.sd_CostVatAmt;
            this.sh_Deposit += ltDetail.sd_Deposit;
            this.sh_PriceTaxAmt += ltDetail.sd_PriceTaxAmt;
            this.sh_PriceTaxFreeAmt += ltDetail.sd_PriceTaxFreeAmt;
            this.sh_PriceVatAmt += ltDetail.sd_PriceVatAmt;
            this.sh_ProfitAmt += ltDetail.sd_ProfitAmt;
          }
        }
      }
      this.sh_CostTaxAmt = CalcHelper.CalcDoubleToFormatDouble(this.sh_CostTaxAmt);
      this.sh_CostTaxFreeAmt = CalcHelper.CalcDoubleToFormatDouble(this.sh_CostTaxFreeAmt);
      this.sh_CostVatAmt = CalcHelper.CalcDoubleToFormatDouble(this.sh_CostVatAmt);
      this.sh_Deposit = CalcHelper.CalcDoubleToFormatDouble(this.sh_Deposit);
      this.sh_PriceTaxAmt = CalcHelper.CalcDoubleToFormatDouble(this.sh_PriceTaxAmt);
      this.sh_PriceTaxFreeAmt = CalcHelper.CalcDoubleToFormatDouble(this.sh_PriceTaxFreeAmt);
      this.sh_PriceVatAmt = CalcHelper.CalcDoubleToFormatDouble(this.sh_PriceVatAmt);
      this.sh_ProfitAmt = CalcHelper.CalcDoubleToFormatDouble(this.sh_ProfitAmt);
    }

    public override bool InsertData(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_isFirstTime)
    {
      try
      {
        this.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != this.DataCheck(p_db))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (this.sh_SiteID == 0L)
            this.sh_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (this.sh_StatementNo == 0L && !this.CreateCode(p_db))
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 코드 생성 오류", 2);
        this.CalcSum(true);
        if (!this.Insert())
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 등록 오류");
        if (!this.InsertDetails(p_db, p_app_employee))
          throw new Exception(this.message);
        if (this.IsOrderDead && !this.InsertMonth(p_db, p_app_employee))
          throw new Exception(this.message);
        if (p_isFirstTime && this.IsOuterMove && !this.InsertOuterMove(p_db, p_app_employee, true))
          throw new Exception(this.message);
        this.db_status = 4;
        this.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        this.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        this.message = ex.Message;
      }
      return false;
    }

    public override async Task<bool> InsertDataAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_isFirstTime)
    {
      StatementHeaderView statementHeaderView = this;
      try
      {
        statementHeaderView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != statementHeaderView.DataCheck(p_db))
            throw new UniServiceException(statementHeaderView.message, statementHeaderView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (statementHeaderView.sh_SiteID == 0L)
            statementHeaderView.sh_SiteID = p_app_employee.emp_SiteID;
          if (!statementHeaderView.IsPermit(p_app_employee))
            throw new UniServiceException(statementHeaderView.message, statementHeaderView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (statementHeaderView.sh_StatementNo == 0L)
        {
          if (!await statementHeaderView.CreateCodeAsync(p_db))
            throw new UniServiceException(statementHeaderView.message, statementHeaderView.TableCode.ToDescription() + " 코드 생성 오류", 2);
        }
        statementHeaderView.CalcSum(true);
        if (!await statementHeaderView.InsertAsync())
          throw new UniServiceException(statementHeaderView.message, statementHeaderView.TableCode.ToDescription() + " 등록 오류");
        if (!await statementHeaderView.InsertDetailsAsync(p_db, p_app_employee))
          throw new Exception(statementHeaderView.message);
        if (statementHeaderView.IsOrderDead)
        {
          if (!await statementHeaderView.InsertMonthAsync(p_db, p_app_employee))
            throw new Exception(statementHeaderView.message);
        }
        if (p_isFirstTime && statementHeaderView.IsOuterMove)
        {
          if (!await statementHeaderView.InsertOuterMoveAsync(p_db, p_app_employee, true))
            throw new Exception(statementHeaderView.message);
        }
        statementHeaderView.db_status = 4;
        statementHeaderView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        statementHeaderView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        statementHeaderView.message = ex.Message;
      }
      return false;
    }

    public bool InsertDataAuto(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_isFirstTime)
    {
      try
      {
        this.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != this.DataCheck(p_db))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (this.sh_SiteID == 0L)
            this.sh_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (this.sh_StatementNo == 0L && !this.CreateCode(p_db))
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 코드 생성 오류", 2);
        this.CalcSum(true);
        if (!this.Insert())
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 등록 오류");
        if (!this.InsertDetails(p_db, p_app_employee))
          throw new Exception(this.message);
        if (p_isFirstTime && this.IsOuterMove && !this.InsertOuterMove(p_db, p_app_employee, true))
          throw new Exception(this.message);
        this.db_status = 4;
        this.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        this.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        this.message = ex.Message;
      }
      return false;
    }

    public async Task<bool> InsertDataAutoAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_isFirstTime)
    {
      StatementHeaderView statementHeaderView = this;
      try
      {
        statementHeaderView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != statementHeaderView.DataCheck(p_db))
            throw new UniServiceException(statementHeaderView.message, statementHeaderView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (statementHeaderView.sh_SiteID == 0L)
            statementHeaderView.sh_SiteID = p_app_employee.emp_SiteID;
          if (!statementHeaderView.IsPermit(p_app_employee))
            throw new UniServiceException(statementHeaderView.message, statementHeaderView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (statementHeaderView.sh_StatementNo == 0L)
        {
          if (!await statementHeaderView.CreateCodeAsync(p_db))
            throw new UniServiceException(statementHeaderView.message, statementHeaderView.TableCode.ToDescription() + " 코드 생성 오류", 2);
        }
        statementHeaderView.CalcSum(true);
        if (!await statementHeaderView.InsertAsync())
          throw new UniServiceException(statementHeaderView.message, statementHeaderView.TableCode.ToDescription() + " 등록 오류");
        if (!await statementHeaderView.InsertDetailsAsync(p_db, p_app_employee))
          throw new Exception(statementHeaderView.message);
        if (p_isFirstTime && statementHeaderView.IsOuterMove)
        {
          if (!await statementHeaderView.InsertOuterMoveAsync(p_db, p_app_employee, true))
            throw new Exception(statementHeaderView.message);
        }
        statementHeaderView.db_status = 4;
        statementHeaderView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        statementHeaderView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        statementHeaderView.message = ex.Message;
      }
      return false;
    }

    public override bool UpdateData(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_isFirstTime)
    {
      try
      {
        this.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != this.DataCheck(p_db))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!this.IsPermit(p_app_employee))
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        if (this.sh_StatementNo == 0L)
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 전표 코드(sh_StatementNo) " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        this.CalcSum(true);
        if (!this.Update())
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 변경 오류");
        if (!this.InsertMonthBefore(p_db, p_app_employee))
          throw new Exception(this.message);
        if (!this.InsertDetails(p_db, p_app_employee))
          throw new Exception(this.message);
        if (this.IsOrderDead && !this.InsertMonth(p_db, p_app_employee))
          throw new Exception(this.message);
        if (p_isFirstTime && this.IsOuterMove && !this.InsertOuterMove(p_db, p_app_employee, false))
          throw new Exception(this.message);
        this.db_status = 4;
        this.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        this.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        this.message = ex.Message;
      }
      return false;
    }

    public override async Task<bool> UpdateDataAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_isFirstTime)
    {
      StatementHeaderView statementHeaderView = this;
      try
      {
        statementHeaderView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != statementHeaderView.DataCheck(p_db))
            throw new UniServiceException(statementHeaderView.message, statementHeaderView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!statementHeaderView.IsPermit(p_app_employee))
          throw new UniServiceException(statementHeaderView.message, statementHeaderView.TableCode.ToDescription() + " 권한 검사 실패");
        if (statementHeaderView.sh_StatementNo == 0L)
          throw new UniServiceException(statementHeaderView.message, statementHeaderView.TableCode.ToDescription() + " 전표 코드(sh_StatementNo) " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        statementHeaderView.CalcSum(true);
        if (!await statementHeaderView.UpdateAsync())
          throw new UniServiceException(statementHeaderView.message, statementHeaderView.TableCode.ToDescription() + " 변경 오류");
        if (!await statementHeaderView.InsertMonthBeforeAsync(p_db, p_app_employee))
          throw new Exception(statementHeaderView.message);
        if (!await statementHeaderView.InsertDetailsAsync(p_db, p_app_employee))
          throw new Exception(statementHeaderView.message);
        if (statementHeaderView.IsOrderDead)
        {
          if (!await statementHeaderView.InsertMonthAsync(p_db, p_app_employee))
            throw new Exception(statementHeaderView.message);
        }
        if (p_isFirstTime && statementHeaderView.IsOuterMove)
        {
          if (!await statementHeaderView.InsertOuterMoveAsync(p_db, p_app_employee, false))
            throw new Exception(statementHeaderView.message);
        }
        statementHeaderView.db_status = 4;
        statementHeaderView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        statementHeaderView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        statementHeaderView.message = ex.Message;
      }
      return false;
    }

    public bool UpdateStatusData(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_isFirstTime)
    {
      try
      {
        this.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != this.DataCheck(p_db))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!this.IsPermit(p_app_employee))
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        if (this.sh_StatementNo == 0L)
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 전표 코드(sh_StatementNo) " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (!this.UpdateStatus())
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 변경 오류");
        if (p_isFirstTime && this.IsOuterMove && !this.InsertOuterMoveStatus(p_db, p_app_employee, false))
          throw new Exception(this.message);
        this.db_status = 4;
        this.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        this.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        this.message = ex.Message;
      }
      return false;
    }

    public async Task<bool> UpdateStatusDataAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_isFirstTime)
    {
      StatementHeaderView statementHeaderView = this;
      try
      {
        statementHeaderView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != statementHeaderView.DataCheck(p_db))
            throw new UniServiceException(statementHeaderView.message, statementHeaderView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!statementHeaderView.IsPermit(p_app_employee))
          throw new UniServiceException(statementHeaderView.message, statementHeaderView.TableCode.ToDescription() + " 권한 검사 실패");
        if (statementHeaderView.sh_StatementNo == 0L)
          throw new UniServiceException(statementHeaderView.message, statementHeaderView.TableCode.ToDescription() + " 전표 코드(sh_StatementNo) " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (!await statementHeaderView.UpdateStatusAsync())
          throw new UniServiceException(statementHeaderView.message, statementHeaderView.TableCode.ToDescription() + " 변경 오류");
        if (p_isFirstTime && statementHeaderView.IsOuterMove)
        {
          if (!await statementHeaderView.InsertOuterMoveStatusAsync(p_db, p_app_employee, false))
            throw new Exception(statementHeaderView.message);
        }
        statementHeaderView.db_status = 4;
        statementHeaderView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        statementHeaderView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        statementHeaderView.message = ex.Message;
      }
      return false;
    }

    public virtual bool InsertDetails(UniOleDatabase p_db, EmployeeView p_app_employee)
    {
      if (this.IsPayment)
        return true;
      if (this.Lt_Details.Count == 0)
      {
        this.message = "전표 상세 데이터 부족.  " + EnumDataCheck.NULL.ToDescription();
        return false;
      }
      int num1 = 1;
      int num2 = -1;
      foreach (StatementDetailView ltDetail in (IEnumerable<StatementDetailView>) this.Lt_Details)
      {
        if (ltDetail.sd_GoodsCode == 0L)
        {
          this.message = string.Format("{0}번째 항목이 상품코드 확인.  {1}", (object) ltDetail.sd_Seq, (object) EnumDataCheck.Valid.ToDescription());
          return false;
        }
        if (ltDetail.sd_Seq > 0)
        {
          if (num1 != ltDetail.sd_Seq)
            num1 = ltDetail.sd_Seq;
        }
        else
        {
          ltDetail.sd_Seq = num1;
          ltDetail.db_status = 1;
        }
        if (ltDetail.sd_StatementNo == 0L)
        {
          ltDetail.sd_StatementNo = this.sh_StatementNo;
          ltDetail.db_status = 1;
        }
        if (ltDetail.sd_IsPackUnitBOM)
          num2 = ltDetail.sd_Seq;
        else if (ltDetail.sd_LinkRowNCount > 0 && ltDetail.sd_IsPackUnitEA && ltDetail.sd_LinkRowNCount != num2)
        {
          ltDetail.sd_LinkRowNCount = num2;
          if (!ltDetail.IsNew)
            ltDetail.db_status = 2;
        }
        if (p_app_employee != null && p_app_employee.emp_Code > 0)
        {
          if (ltDetail.IsNew)
            ltDetail.sd_InUser = p_app_employee.emp_Code;
          else if (ltDetail.IsUpdate)
            ltDetail.sd_ModUser = p_app_employee.emp_Code;
        }
        ltDetail.SetAdoDatabase(p_db);
        if (ltDetail.DataCheckOn(p_db) != EnumDataCheck.Success)
        {
          this.message = ltDetail.message;
          return false;
        }
        if (ltDetail.IsNew)
        {
          if (!ltDetail.Insert())
          {
            this.message = string.Format("{0}행 {1}항목 신규등록 에러", (object) ltDetail.sd_Seq, (object) ltDetail.sd_BarCode);
            throw new Exception(this.message);
          }
        }
        else if (ltDetail.IsUpdate && !ltDetail.Update((UbModelBase) null))
        {
          this.message = string.Format("{0}행 {1}항목 데이터 변경 에러", (object) ltDetail.sd_Seq, (object) ltDetail.sd_BarCode);
          throw new Exception(this.message);
        }
        ++num1;
      }
      return true;
    }

    public virtual async Task<bool> InsertDetailsAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee)
    {
      StatementHeaderView statementHeaderView = this;
      if (statementHeaderView.IsPayment)
        return true;
      if (statementHeaderView.Lt_Details.Count == 0)
      {
        statementHeaderView.message = "전표 상세 데이터 부족.  " + EnumDataCheck.NULL.ToDescription();
        return false;
      }
      int nCount = 1;
      int nLastBomSeq = -1;
      foreach (StatementDetailView ltDetail in (IEnumerable<StatementDetailView>) statementHeaderView.Lt_Details)
      {
        StatementDetailView item = ltDetail;
        if (item.sd_GoodsCode == 0L)
        {
          statementHeaderView.message = string.Format("{0}번째 항목이 상품코드 확인.  {1}", (object) item.sd_Seq, (object) EnumDataCheck.Valid.ToDescription());
          return false;
        }
        if (item.sd_Seq > 0)
        {
          if (nCount != item.sd_Seq)
            nCount = item.sd_Seq;
        }
        else
        {
          item.sd_Seq = nCount;
          item.db_status = 1;
        }
        if (item.sd_StatementNo == 0L)
        {
          item.sd_StatementNo = statementHeaderView.sh_StatementNo;
          item.db_status = 1;
        }
        if (item.sd_IsPackUnitBOM)
          nLastBomSeq = item.sd_Seq;
        else if (item.sd_LinkRowNCount > 0 && item.sd_IsPackUnitEA && item.sd_LinkRowNCount != nLastBomSeq)
        {
          item.sd_LinkRowNCount = nLastBomSeq;
          if (!item.IsNew)
            item.db_status = 2;
        }
        if (p_app_employee != null && p_app_employee.emp_Code > 0)
        {
          if (item.IsNew)
            item.sd_InUser = p_app_employee.emp_Code;
          else if (item.IsUpdate)
            item.sd_ModUser = p_app_employee.emp_Code;
        }
        item.SetAdoDatabase(p_db);
        if (item.DataCheckOn(p_db) != EnumDataCheck.Success)
        {
          statementHeaderView.message = item.message;
          return false;
        }
        if (item.IsNew)
        {
          item.sd_InDate = new DateTime?(DateTime.Now);
          if (!await item.InsertAsync())
          {
            statementHeaderView.message = string.Format("{0}행 {1}항목 신규등록 에러", (object) item.sd_Seq, (object) item.sd_BarCode);
            throw new Exception(statementHeaderView.message);
          }
        }
        else if (item.IsUpdate)
        {
          item.sd_ModDate = new DateTime?(DateTime.Now);
          if (!await item.UpdateAsync((UbModelBase) null))
          {
            statementHeaderView.message = string.Format("{0}행 {1}항목 데이터 변경 에러", (object) item.sd_Seq, (object) item.sd_BarCode);
            throw new Exception(statementHeaderView.message);
          }
        }
        ++nCount;
        item = (StatementDetailView) null;
      }
      return true;
    }

    public virtual bool InsertMonthBefore(UniOleDatabase p_db, EmployeeView p_app_employee)
    {
      if (!this.IsConfirmBefore)
        return true;
      DateTime? confirmDateBefore;
      if (!this.IsPayment)
      {
        ProfitLossSummaryStatement summaryStatement = p_db.Create<ProfitLossSummaryStatement>();
        long shSiteId = this.sh_SiteID;
        int shStoreCode = this.sh_StoreCode;
        long shStatementNo = this.sh_StatementNo;
        confirmDateBefore = this.sh_ConfirmDateBefore;
        DateTime p_sh_ConfirmDate = confirmDateBefore.Value;
        if (!summaryStatement.ProcNext((JobEvtInfo) null, "전 전표 월재고 복구", shSiteId, shStoreCode, shStatementNo, p_sh_ConfirmDate))
        {
          this.message = "전 전표 월재고 복구 에러";
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 재고 복구 오류");
        }
      }
      if (this.IsBuy || this.IsSale || this.IsPayment)
      {
        PaymentMonthWork paymentMonthWork = p_db.Create<PaymentMonthWork>();
        confirmDateBefore = this.sh_ConfirmDateBefore;
        DateTime p_WorkOriginDate = confirmDateBefore.Value;
        int shStoreCode = this.sh_StoreCode;
        int shSupplier = this.sh_Supplier;
        long shSiteId = this.sh_SiteID;
        if (!paymentMonthWork.ProcNext((JobEvtInfo) null, "전 전표 월대금 복구", p_WorkOriginDate, shStoreCode, shSupplier, shSiteId))
        {
          this.message = "전 전표 월대금 복구 에러";
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 대금 복구 오류");
        }
      }
      if (!this.IsPayment)
      {
        SupplierHistoryView supplierHistoryView = p_db.Create<SupplierHistoryView>();
        long shSiteId = this.sh_SiteID;
        int shSupplier = this.sh_Supplier;
        int shStoreCode = this.sh_StoreCode;
        confirmDateBefore = this.sh_ConfirmDateBefore;
        DateTime p_Date = confirmDateBefore.Value;
        if (supplierHistoryView.IsPamentAnyTime(shSiteId, shSupplier, shStoreCode, p_Date))
        {
          UniOleDatabase p_db1 = p_db;
          confirmDateBefore = this.sh_ConfirmDateBefore;
          DateTime p_sh_ConfirmDate = confirmDateBefore.Value;
          EmployeeView p_app_employee1 = p_app_employee;
          if (!this.InsertPaymentAnyTime(p_db1, p_sh_ConfirmDate, p_app_employee1))
          {
            this.message = "수시 결제 등록 에러";
            return false;
          }
        }
        else
        {
          UniOleDatabase p_db2 = p_db;
          confirmDateBefore = this.sh_ConfirmDateBefore;
          DateTime p_sh_ConfirmDate = confirmDateBefore.Value;
          EmployeeView p_app_employee2 = p_app_employee;
          if (!this.InsertPayment(p_db2, p_sh_ConfirmDate, p_app_employee2))
          {
            this.message = "결제 등록 에러";
            return false;
          }
        }
      }
      return true;
    }

    public virtual async Task<bool> InsertMonthBeforeAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee)
    {
      StatementHeaderView statementHeaderView1 = this;
      if (!statementHeaderView1.IsConfirmBefore)
        return true;
      if (!statementHeaderView1.IsPayment)
      {
        if (!await p_db.Create<ProfitLossSummaryStatement>().ProcNextAsync((JobEvtInfo) null, "전 전표 월재고 복구", statementHeaderView1.sh_SiteID, statementHeaderView1.sh_StoreCode, statementHeaderView1.sh_StatementNo, statementHeaderView1.sh_ConfirmDateBefore.Value))
        {
          statementHeaderView1.message = "전 전표 월재고 복구 에러";
          throw new UniServiceException(statementHeaderView1.message, statementHeaderView1.TableCode.ToDescription() + " 재고 복구 오류");
        }
      }
      if (statementHeaderView1.IsBuy || statementHeaderView1.IsSale || statementHeaderView1.IsPayment)
      {
        if (!await p_db.Create<PaymentMonthWork>().ProcNextAsync((JobEvtInfo) null, "전 전표 월대금 복구", statementHeaderView1.sh_ConfirmDateBefore.Value, statementHeaderView1.sh_StoreCode, statementHeaderView1.sh_Supplier, statementHeaderView1.sh_SiteID))
        {
          statementHeaderView1.message = "전 전표 월대금 복구 에러";
          throw new UniServiceException(statementHeaderView1.message, statementHeaderView1.TableCode.ToDescription() + " 대금 마감 오류");
        }
      }
      if (!statementHeaderView1.IsPayment)
      {
        SupplierHistoryView supplierHistoryView = p_db.Create<SupplierHistoryView>();
        long shSiteId = statementHeaderView1.sh_SiteID;
        int shSupplier = statementHeaderView1.sh_Supplier;
        int shStoreCode = statementHeaderView1.sh_StoreCode;
        DateTime? confirmDateBefore = statementHeaderView1.sh_ConfirmDateBefore;
        DateTime p_Date = confirmDateBefore.Value;
        if (await supplierHistoryView.IsPamentAnyTimeAsync(shSiteId, shSupplier, shStoreCode, p_Date))
        {
          StatementHeaderView statementHeaderView2 = statementHeaderView1;
          UniOleDatabase p_db1 = p_db;
          confirmDateBefore = statementHeaderView1.sh_ConfirmDateBefore;
          DateTime p_sh_ConfirmDate = confirmDateBefore.Value;
          EmployeeView p_app_employee1 = p_app_employee;
          if (!await statementHeaderView2.InsertPaymentAnyTimeAsync(p_db1, p_sh_ConfirmDate, p_app_employee1))
          {
            statementHeaderView1.message = "수시 결제 등록 에러";
            return false;
          }
        }
        else
        {
          StatementHeaderView statementHeaderView3 = statementHeaderView1;
          UniOleDatabase p_db2 = p_db;
          confirmDateBefore = statementHeaderView1.sh_ConfirmDateBefore;
          DateTime p_sh_ConfirmDate = confirmDateBefore.Value;
          EmployeeView p_app_employee2 = p_app_employee;
          if (!await statementHeaderView3.InsertPaymentAsync(p_db2, p_sh_ConfirmDate, p_app_employee2))
          {
            statementHeaderView1.message = "결제 등록 에러";
            return false;
          }
        }
      }
      return true;
    }

    public virtual bool InsertPayment(
      UniOleDatabase p_db,
      DateTime p_sh_ConfirmDate,
      EmployeeView p_app_employee)
    {
      if (1001 == this.sh_Supplier)
        return true;
      if (!p_db.Create<PaymentStatement>().ProcApply((JobEvtInfo) null, "전표 결제 파일 적용", this.sh_SiteID, this.sh_StoreCode, this.sh_Supplier, p_sh_ConfirmDate, p_app_employee))
      {
        this.message = "전표 결제 파일 적용 에러";
        throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 전표 결제 파일 적용 오류");
      }
      if (!p_db.Create<PaymentMonthWork>().ProcNext((JobEvtInfo) null, "전표 결제 기초 파일 적용", p_sh_ConfirmDate, this.sh_StoreCode, this.sh_Supplier, this.sh_SiteID))
      {
        this.message = "전표 결제 기초 파일 적용 에러";
        throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 전표 결제 기초 파일 적용 오류");
      }
      return true;
    }

    public virtual async Task<bool> InsertPaymentAsync(
      UniOleDatabase p_db,
      DateTime p_sh_ConfirmDate,
      EmployeeView p_app_employee)
    {
      StatementHeaderView statementHeaderView = this;
      if (1001 == statementHeaderView.sh_Supplier)
        return true;
      if (!await p_db.Create<PaymentStatement>().ProcApplyAsync((JobEvtInfo) null, "전표 결제 파일 적용", statementHeaderView.sh_SiteID, statementHeaderView.sh_StoreCode, statementHeaderView.sh_Supplier, p_sh_ConfirmDate, p_app_employee))
      {
        statementHeaderView.message = "전표 결제 파일 적용 에러";
        throw new UniServiceException(statementHeaderView.message, statementHeaderView.TableCode.ToDescription() + " 전표 결제 파일 적용 오류");
      }
      if (!await p_db.Create<PaymentMonthWork>().ProcNextAsync((JobEvtInfo) null, "전표 결제 기초 파일 적용", p_sh_ConfirmDate, statementHeaderView.sh_StoreCode, statementHeaderView.sh_Supplier, statementHeaderView.sh_SiteID))
      {
        statementHeaderView.message = "전표 결제 기초 파일 적용 에러";
        throw new UniServiceException(statementHeaderView.message, statementHeaderView.TableCode.ToDescription() + " 전표 결제 기초 파일 적용 오류");
      }
      return true;
    }

    public virtual bool InsertPaymentAnyTime(
      UniOleDatabase p_db,
      DateTime p_sh_ConfirmDate,
      EmployeeView p_app_employee)
    {
      if (1001 == this.sh_Supplier)
        return true;
      if (!p_db.Create<PaymentStatementByManual>().ProcApply((JobEvtInfo) null, "전표 수기 결제 파일 적용", this.sh_SiteID, this.sh_StoreCode, this.sh_Supplier, p_sh_ConfirmDate, p_app_employee))
      {
        this.message = "전표 수기 결제 파일 적용 에러";
        throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 전표 수기 결제 파일 적용 오류");
      }
      if (!p_db.Create<PaymentMonthWork>().ProcNext((JobEvtInfo) null, "전표 수기 결제 기초 파일 적용", p_sh_ConfirmDate, this.sh_StoreCode, this.sh_Supplier, this.sh_SiteID))
      {
        this.message = "전표 수기 결제 기초 파일 적용 에러";
        throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 전표 수기 결제 기초 파일 적용 오류");
      }
      return true;
    }

    public virtual async Task<bool> InsertPaymentAnyTimeAsync(
      UniOleDatabase p_db,
      DateTime p_sh_ConfirmDate,
      EmployeeView p_app_employee)
    {
      StatementHeaderView statementHeaderView = this;
      if (1001 == statementHeaderView.sh_Supplier)
        return true;
      if (!await p_db.Create<PaymentStatementByManual>().ProcApplyAsync((JobEvtInfo) null, "전표 수기 결제 파일 적용", statementHeaderView.sh_SiteID, statementHeaderView.sh_StoreCode, statementHeaderView.sh_Supplier, p_sh_ConfirmDate, p_app_employee))
      {
        statementHeaderView.message = "전표 수기 결제 파일 적용 에러";
        throw new UniServiceException(statementHeaderView.message, statementHeaderView.TableCode.ToDescription() + " 전표 수기 결제 파일 적용 오류");
      }
      if (!await p_db.Create<PaymentMonthWork>().ProcNextAsync((JobEvtInfo) null, "전표 수기 결제 기초 파일 적용", p_sh_ConfirmDate, statementHeaderView.sh_StoreCode, statementHeaderView.sh_Supplier, statementHeaderView.sh_SiteID))
      {
        statementHeaderView.message = "전표 수기 결제 기초 파일 적용 에러";
        throw new UniServiceException(statementHeaderView.message, statementHeaderView.TableCode.ToDescription() + " 전표 수기 결제 기초 파일 적용 오류");
      }
      return true;
    }

    public virtual bool InsertMonth(UniOleDatabase p_db, EmployeeView p_app_employee)
    {
      if (this.IsConfirm)
      {
        DateTime? shConfirmDate;
        if (!this.IsPayment)
        {
          ProfitLossSummaryStatement summaryStatement = p_db.Create<ProfitLossSummaryStatement>();
          long shSiteId = this.sh_SiteID;
          int shStoreCode = this.sh_StoreCode;
          long shStatementNo = this.sh_StatementNo;
          shConfirmDate = this.sh_ConfirmDate;
          DateTime p_sh_ConfirmDate = shConfirmDate.Value;
          if (!summaryStatement.ProcNext((JobEvtInfo) null, "전표 월재고 마감", shSiteId, shStoreCode, shStatementNo, p_sh_ConfirmDate))
          {
            this.message = "전표 월재고 마감 에러";
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 재고 마감 오류");
          }
        }
        if (this.IsBuy || this.IsSale)
        {
          PaymentMonthWork paymentMonthWork = p_db.Create<PaymentMonthWork>();
          shConfirmDate = this.sh_ConfirmDate;
          DateTime p_WorkOriginDate = shConfirmDate.Value;
          int shStoreCode = this.sh_StoreCode;
          int shSupplier = this.sh_Supplier;
          long shSiteId = this.sh_SiteID;
          if (!paymentMonthWork.ProcNext((JobEvtInfo) null, "전표 월대금 마감", p_WorkOriginDate, shStoreCode, shSupplier, shSiteId))
          {
            this.message = "전표 월대금 마감 에러";
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 대금 마감 오류");
          }
        }
        if (!this.IsPayment)
        {
          SupplierHistoryView supplierHistoryView = p_db.Create<SupplierHistoryView>();
          long shSiteId = this.sh_SiteID;
          int shSupplier = this.sh_Supplier;
          int shStoreCode = this.sh_StoreCode;
          shConfirmDate = this.sh_ConfirmDate;
          DateTime p_Date = shConfirmDate.Value;
          if (supplierHistoryView.IsPamentAnyTime(shSiteId, shSupplier, shStoreCode, p_Date))
          {
            UniOleDatabase p_db1 = p_db;
            shConfirmDate = this.sh_ConfirmDate;
            DateTime p_sh_ConfirmDate = shConfirmDate.Value;
            EmployeeView p_app_employee1 = p_app_employee;
            if (!this.InsertPaymentAnyTime(p_db1, p_sh_ConfirmDate, p_app_employee1))
            {
              this.message = "수시 결제 등록 에러";
              return false;
            }
          }
          else
          {
            UniOleDatabase p_db2 = p_db;
            shConfirmDate = this.sh_ConfirmDate;
            DateTime p_sh_ConfirmDate = shConfirmDate.Value;
            EmployeeView p_app_employee2 = p_app_employee;
            if (!this.InsertPayment(p_db2, p_sh_ConfirmDate, p_app_employee2))
            {
              this.message = "결제 등록 에러";
              return false;
            }
          }
        }
      }
      int num = this.IsPayment ? 1 : 0;
      return true;
    }

    public virtual async Task<bool> InsertMonthAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee)
    {
      StatementHeaderView statementHeaderView1 = this;
      if (statementHeaderView1.IsConfirm)
      {
        DateTime? shConfirmDate;
        if (!statementHeaderView1.IsPayment)
        {
          ProfitLossSummaryStatement summaryStatement = p_db.Create<ProfitLossSummaryStatement>();
          long shSiteId = statementHeaderView1.sh_SiteID;
          int shStoreCode = statementHeaderView1.sh_StoreCode;
          long shStatementNo = statementHeaderView1.sh_StatementNo;
          shConfirmDate = statementHeaderView1.sh_ConfirmDate;
          DateTime p_sh_ConfirmDate = shConfirmDate.Value;
          if (!await summaryStatement.ProcNextAsync((JobEvtInfo) null, "전표 월재고 마감", shSiteId, shStoreCode, shStatementNo, p_sh_ConfirmDate))
          {
            statementHeaderView1.message = "전표 월재고 마감 에러";
            throw new UniServiceException(statementHeaderView1.message, statementHeaderView1.TableCode.ToDescription() + " 재고 마감 오류");
          }
        }
        if (statementHeaderView1.IsBuy || statementHeaderView1.IsSale)
        {
          PaymentMonthWork paymentMonthWork = p_db.Create<PaymentMonthWork>();
          shConfirmDate = statementHeaderView1.sh_ConfirmDate;
          DateTime p_WorkOriginDate = shConfirmDate.Value;
          int shStoreCode = statementHeaderView1.sh_StoreCode;
          int shSupplier = statementHeaderView1.sh_Supplier;
          long shSiteId = statementHeaderView1.sh_SiteID;
          if (!await paymentMonthWork.ProcNextAsync((JobEvtInfo) null, "전표 월대금 마감", p_WorkOriginDate, shStoreCode, shSupplier, shSiteId))
          {
            statementHeaderView1.message = "전표 월대금 마감 에러";
            throw new UniServiceException(statementHeaderView1.message, statementHeaderView1.TableCode.ToDescription() + " 대금 마감 오류");
          }
        }
        if (!statementHeaderView1.IsPayment)
        {
          SupplierHistoryView supplierHistoryView = p_db.Create<SupplierHistoryView>();
          long shSiteId = statementHeaderView1.sh_SiteID;
          int shSupplier = statementHeaderView1.sh_Supplier;
          int shStoreCode = statementHeaderView1.sh_StoreCode;
          shConfirmDate = statementHeaderView1.sh_ConfirmDate;
          DateTime p_Date = shConfirmDate.Value;
          if (await supplierHistoryView.IsPamentAnyTimeAsync(shSiteId, shSupplier, shStoreCode, p_Date))
          {
            StatementHeaderView statementHeaderView2 = statementHeaderView1;
            UniOleDatabase p_db1 = p_db;
            shConfirmDate = statementHeaderView1.sh_ConfirmDate;
            DateTime p_sh_ConfirmDate = shConfirmDate.Value;
            EmployeeView p_app_employee1 = p_app_employee;
            if (!await statementHeaderView2.InsertPaymentAnyTimeAsync(p_db1, p_sh_ConfirmDate, p_app_employee1))
            {
              statementHeaderView1.message = "수시 결제 등록 에러";
              return false;
            }
          }
          else
          {
            StatementHeaderView statementHeaderView3 = statementHeaderView1;
            UniOleDatabase p_db2 = p_db;
            shConfirmDate = statementHeaderView1.sh_ConfirmDate;
            DateTime p_sh_ConfirmDate = shConfirmDate.Value;
            EmployeeView p_app_employee2 = p_app_employee;
            if (!await statementHeaderView3.InsertPaymentAsync(p_db2, p_sh_ConfirmDate, p_app_employee2))
            {
              statementHeaderView1.message = "결제 등록 에러";
              return false;
            }
          }
        }
      }
      int num = statementHeaderView1.IsPayment ? 1 : 0;
      return true;
    }

    public bool InsertOuterMove(UniOleDatabase p_db, EmployeeView p_app_employee, bool p_isNew)
    {
      MoveInOutLinkView moveInOutLinkView1 = (MoveInOutLinkView) null;
      try
      {
        StatementHeaderView statementHeaderView;
        if (p_isNew)
        {
          statementHeaderView = this.SetSideStatement(p_db);
          statementHeaderView.Lt_Details.Clear();
          statementHeaderView.db_status = 1;
        }
        else
        {
          moveInOutLinkView1 = p_db.Create<MoveInOutLinkView>().SelectOne(this.sh_StatementNo, Enum2StrConverter.ToInOutDiv(this.sh_InOutDiv), this.sh_SiteID);
          if (moveInOutLinkView1 == null)
          {
            statementHeaderView = this.SetSideStatement(p_db);
            statementHeaderView.Lt_Details.Clear();
            statementHeaderView.DB_STATUS = EnumDBStatus.NEW;
          }
          else
          {
            statementHeaderView = p_db.Create<StatementHeaderView>().SelectOne(this.IsInOutReturn ? moveInOutLinkView1.mio_InnerStatementNo : moveInOutLinkView1.mio_OuterStatementNo, moveInOutLinkView1.mio_SiteID);
            if (statementHeaderView == null)
            {
              this.RowStatus = 0;
              this.message = "상대지점 전표 미존재";
              return false;
            }
            statementHeaderView.Lt_Details.Clear();
            statementHeaderView.Lt_Details = p_db.Create<StatementDetailView>().SelectListE<StatementDetailView>((object) new Hashtable()
            {
              {
                (object) "sd_StatementNo",
                (object) (this.IsInOutReturn ? moveInOutLinkView1.mio_InnerStatementNo : moveInOutLinkView1.mio_OuterStatementNo)
              }
            });
            statementHeaderView.DB_STATUS = EnumDBStatus.UPDATE;
          }
        }
        statementHeaderView.sh_OrderDate = this.sh_OrderDate;
        statementHeaderView.sh_OrderStatus = this.sh_OrderStatus;
        statementHeaderView.sh_ConfirmDate = this.sh_ConfirmDate;
        statementHeaderView.sh_ConfirmStatus = this.sh_ConfirmStatus;
        statementHeaderView.sh_DeviceType = this.sh_DeviceType;
        statementHeaderView.sh_OuterConnAuth = this.sh_OuterConnAuth;
        statementHeaderView.sh_AdditionalOpt = this.sh_AdditionalOpt;
        statementHeaderView.sh_Memo = this.sh_Memo;
        statementHeaderView.sh_DeliveryNumber = this.sh_DeliveryNumber;
        statementHeaderView.sh_TransmitStatus = this.sh_TransmitStatus;
        statementHeaderView.sh_AssignUser = this.sh_AssignUser;
        statementHeaderView.sh_InUser = this.sh_InUser;
        statementHeaderView.sh_ModUser = this.sh_ModUser;
        statementHeaderView.IsOuterMovePermitChecked = false;
        if (this.Lt_Details.Count < statementHeaderView.Lt_Details.Count)
        {
          this.RowStatus = 0;
          this.message = "상대지점 데이터 과다 오류";
          return false;
        }
        foreach (StatementDetailView statementDetailView1 in this.Lt_Details.Where<StatementDetailView>((Func<StatementDetailView, bool>) (it => it.sd_Seq > 0)).OrderBy<StatementDetailView, int>((Func<StatementDetailView, int>) (it => it.sd_Seq)).ToList<StatementDetailView>())
        {
          StatementDetailView item = statementDetailView1;
          StatementDetailView statementDetailView2 = statementHeaderView.Lt_Details.Where<StatementDetailView>((Func<StatementDetailView, bool>) (it => it.sd_Seq == item.sd_Seq)).FirstOrDefault<StatementDetailView>();
          if (item.sd_GoodsCode != 0L)
          {
            if (statementDetailView2 != null)
            {
              statementDetailView2.PutData(item);
              statementDetailView2.sd_StatementNo = statementHeaderView.sh_StatementNo;
              statementDetailView2.DB_STATUS = EnumDBStatus.UPDATE;
            }
            else
            {
              StatementDetailView statementDetailView3 = new StatementDetailView();
              statementDetailView3.PutData(item);
              statementDetailView3.sd_StatementNo = statementHeaderView.sh_StatementNo;
              statementDetailView3.DB_STATUS = EnumDBStatus.NEW;
              statementHeaderView.Lt_Details.Add(statementDetailView3);
            }
          }
        }
        if (statementHeaderView.IsUpdate)
        {
          if (!statementHeaderView.UpdateData(p_db, p_app_employee))
            throw new UniServiceException(statementHeaderView.message, "전표 상대지점 수정 오류");
        }
        else if (!statementHeaderView.InsertData(p_db, p_app_employee))
          throw new UniServiceException(statementHeaderView.message, "전표 상대지점 신규 등록 오류");
        if (moveInOutLinkView1 == null)
        {
          MoveInOutLinkView moveInOutLinkView2 = p_db.Create<MoveInOutLinkView>();
          if (this.IsInOutReturn)
          {
            moveInOutLinkView2.mio_OuterStatementNo = this.sh_StatementNo;
            moveInOutLinkView2.mio_InnerStatementNo = statementHeaderView.sh_StatementNo;
          }
          else
          {
            moveInOutLinkView2.mio_OuterStatementNo = statementHeaderView.sh_StatementNo;
            moveInOutLinkView2.mio_InnerStatementNo = this.sh_StatementNo;
          }
          if (!moveInOutLinkView2.Insert())
            throw new UniServiceException(moveInOutLinkView2.message, "전표 연결 신규 등록 오류");
        }
        return true;
      }
      catch (UniServiceException ex)
      {
        this.RowStatus = 0;
        this.message = ex.Message + "\n" + ex.UserMessage;
      }
      catch (Exception ex)
      {
        this.RowStatus = 0;
        this.message = ex.Message;
      }
      return false;
    }

    public virtual async Task<bool> InsertOuterMoveAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_isNew)
    {
      StatementHeaderView statementHeaderView1 = this;
      MoveInOutLinkView link = (MoveInOutLinkView) null;
      StatementHeaderView side_statement = (StatementHeaderView) null;
      try
      {
        if (p_isNew)
        {
          side_statement = statementHeaderView1.SetSideStatement(p_db);
          side_statement.Lt_Details.Clear();
          side_statement.db_status = 1;
        }
        else
        {
          link = await p_db.Create<MoveInOutLinkView>().SelectOneAsync(statementHeaderView1.sh_StatementNo, Enum2StrConverter.ToInOutDiv(statementHeaderView1.sh_InOutDiv), statementHeaderView1.sh_SiteID);
          if (link == null)
          {
            side_statement = statementHeaderView1.SetSideStatement(p_db);
            side_statement.Lt_Details.Clear();
            side_statement.DB_STATUS = EnumDBStatus.NEW;
          }
          else
          {
            side_statement = await p_db.Create<StatementHeaderView>().SelectOneAsync(statementHeaderView1.IsInOutReturn ? link.mio_InnerStatementNo : link.mio_OuterStatementNo, link.mio_SiteID);
            if (side_statement == null)
            {
              statementHeaderView1.RowStatus = 0;
              statementHeaderView1.message = "상대지점 전표 미존재";
              return false;
            }
            side_statement.Lt_Details.Clear();
            Hashtable p_param = new Hashtable();
            p_param.Add((object) "sd_StatementNo", (object) (statementHeaderView1.IsInOutReturn ? link.mio_InnerStatementNo : link.mio_OuterStatementNo));
            StatementHeaderView statementHeaderView = side_statement;
            statementHeaderView.Lt_Details = await p_db.Create<StatementDetailView>().SelectListAsync((object) p_param);
            statementHeaderView = (StatementHeaderView) null;
            side_statement.DB_STATUS = EnumDBStatus.UPDATE;
          }
        }
        side_statement.sh_OrderDate = statementHeaderView1.sh_OrderDate;
        side_statement.sh_OrderStatus = statementHeaderView1.sh_OrderStatus;
        side_statement.sh_ConfirmDate = statementHeaderView1.sh_ConfirmDate;
        side_statement.sh_ConfirmStatus = statementHeaderView1.sh_ConfirmStatus;
        side_statement.sh_DeviceType = statementHeaderView1.sh_DeviceType;
        side_statement.sh_OuterConnAuth = statementHeaderView1.sh_OuterConnAuth;
        side_statement.sh_AdditionalOpt = statementHeaderView1.sh_AdditionalOpt;
        side_statement.sh_Memo = statementHeaderView1.sh_Memo;
        side_statement.sh_DeliveryNumber = statementHeaderView1.sh_DeliveryNumber;
        side_statement.sh_TransmitStatus = statementHeaderView1.sh_TransmitStatus;
        side_statement.sh_AssignUser = statementHeaderView1.sh_AssignUser;
        side_statement.sh_InUser = statementHeaderView1.sh_InUser;
        side_statement.sh_ModUser = statementHeaderView1.sh_ModUser;
        side_statement.IsOuterMovePermitChecked = false;
        if (statementHeaderView1.Lt_Details.Count < side_statement.Lt_Details.Count)
        {
          statementHeaderView1.RowStatus = 0;
          statementHeaderView1.message = "상대지점 데이터 과다 오류";
          return false;
        }
        foreach (StatementDetailView statementDetailView1 in statementHeaderView1.Lt_Details.Where<StatementDetailView>((Func<StatementDetailView, bool>) (it => it.sd_Seq > 0)).OrderBy<StatementDetailView, int>((Func<StatementDetailView, int>) (it => it.sd_Seq)).ToList<StatementDetailView>())
        {
          StatementDetailView item = statementDetailView1;
          StatementDetailView statementDetailView2 = side_statement.Lt_Details.Where<StatementDetailView>((Func<StatementDetailView, bool>) (it => it.sd_Seq == item.sd_Seq)).FirstOrDefault<StatementDetailView>();
          if (item.sd_GoodsCode != 0L)
          {
            if (statementDetailView2 != null)
            {
              statementDetailView2.PutData(item);
              statementDetailView2.sd_StatementNo = side_statement.sh_StatementNo;
              statementDetailView2.DB_STATUS = EnumDBStatus.UPDATE;
            }
            else
            {
              StatementDetailView statementDetailView3 = new StatementDetailView();
              statementDetailView3.PutData(item);
              statementDetailView3.sd_StatementNo = side_statement.sh_StatementNo;
              statementDetailView3.DB_STATUS = EnumDBStatus.NEW;
              side_statement.Lt_Details.Add(statementDetailView3);
            }
          }
        }
        if (side_statement.IsUpdate)
        {
          if (!await side_statement.UpdateDataAsync(p_db, p_app_employee))
            throw new UniServiceException(side_statement.message, "전표 상대지점 수정 오류");
        }
        else if (!await side_statement.InsertDataAsync(p_db, p_app_employee))
          throw new UniServiceException(side_statement.message, "전표 상대지점 신규 등록 오류");
        if (link == null)
        {
          link = p_db.Create<MoveInOutLinkView>();
          if (statementHeaderView1.IsInOutReturn)
          {
            link.mio_OuterStatementNo = statementHeaderView1.sh_StatementNo;
            link.mio_InnerStatementNo = side_statement.sh_StatementNo;
          }
          else
          {
            link.mio_OuterStatementNo = side_statement.sh_StatementNo;
            link.mio_InnerStatementNo = statementHeaderView1.sh_StatementNo;
          }
          if (!await link.InsertAsync())
            throw new UniServiceException(link.message, "전표 연결 신규 등록 오류");
        }
        return true;
      }
      catch (UniServiceException ex)
      {
        statementHeaderView1.RowStatus = 0;
        statementHeaderView1.message = ex.Message + "\n" + ex.UserMessage;
      }
      catch (Exception ex)
      {
        statementHeaderView1.RowStatus = 0;
        statementHeaderView1.message = ex.Message;
      }
      return false;
    }

    public bool InsertOuterMoveStatus(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_isNew)
    {
      MoveInOutLinkView moveInOutLinkView1 = (MoveInOutLinkView) null;
      try
      {
        StatementHeaderView statementHeaderView;
        if (p_isNew)
        {
          statementHeaderView = this.SetSideStatement(p_db);
          statementHeaderView.Lt_Details.Clear();
          statementHeaderView.db_status = 1;
        }
        else
        {
          moveInOutLinkView1 = p_db.Create<MoveInOutLinkView>().SelectOne(this.sh_StatementNo, Enum2StrConverter.ToInOutDiv(this.sh_InOutDiv), this.sh_SiteID);
          if (moveInOutLinkView1 == null)
          {
            statementHeaderView = this.SetSideStatement(p_db);
            statementHeaderView.Lt_Details.Clear();
            statementHeaderView.DB_STATUS = EnumDBStatus.NEW;
          }
          else
          {
            statementHeaderView = p_db.Create<StatementHeaderView>().SelectOne(this.IsInOutReturn ? moveInOutLinkView1.mio_InnerStatementNo : moveInOutLinkView1.mio_OuterStatementNo, moveInOutLinkView1.mio_SiteID);
            if (statementHeaderView == null)
            {
              this.RowStatus = 0;
              this.message = "상대지점 전표 미존재";
              return false;
            }
            statementHeaderView.DB_STATUS = EnumDBStatus.UPDATE;
          }
        }
        statementHeaderView.sh_OrderDate = this.sh_OrderDate;
        statementHeaderView.sh_OrderStatus = this.sh_OrderStatus;
        statementHeaderView.sh_ConfirmDate = this.sh_ConfirmDate;
        statementHeaderView.sh_ConfirmStatus = this.sh_ConfirmStatus;
        statementHeaderView.sh_DeviceType = this.sh_DeviceType;
        statementHeaderView.sh_OuterConnAuth = this.sh_OuterConnAuth;
        statementHeaderView.sh_AdditionalOpt = this.sh_AdditionalOpt;
        statementHeaderView.sh_Memo = this.sh_Memo;
        statementHeaderView.sh_DeliveryNumber = this.sh_DeliveryNumber;
        statementHeaderView.sh_TransmitStatus = this.sh_TransmitStatus;
        statementHeaderView.sh_AssignUser = this.sh_AssignUser;
        statementHeaderView.sh_InUser = this.sh_InUser;
        statementHeaderView.sh_ModUser = this.sh_ModUser;
        statementHeaderView.IsOuterMovePermitChecked = false;
        if (statementHeaderView.IsNew)
          throw new UniServiceException(statementHeaderView.message, "전표 상대지점 신규[X] 등록 오류");
        if (!statementHeaderView.UpdateStatusData(p_db, p_app_employee, false))
          throw new UniServiceException(statementHeaderView.message, "전표 상대지점 수정 오류");
        if (moveInOutLinkView1 == null)
        {
          MoveInOutLinkView moveInOutLinkView2 = p_db.Create<MoveInOutLinkView>();
          if (this.IsInOutReturn)
          {
            moveInOutLinkView2.mio_OuterStatementNo = this.sh_StatementNo;
            moveInOutLinkView2.mio_InnerStatementNo = statementHeaderView.sh_StatementNo;
          }
          else
          {
            moveInOutLinkView2.mio_OuterStatementNo = statementHeaderView.sh_StatementNo;
            moveInOutLinkView2.mio_InnerStatementNo = this.sh_StatementNo;
          }
          if (!moveInOutLinkView2.Insert())
            throw new UniServiceException(moveInOutLinkView2.message, "전표 연결 신규 등록 오류");
        }
        return true;
      }
      catch (UniServiceException ex)
      {
        this.RowStatus = 0;
        this.message = ex.Message + "\n" + ex.UserMessage;
      }
      catch (Exception ex)
      {
        this.RowStatus = 0;
        this.message = ex.Message;
      }
      return false;
    }

    public virtual async Task<bool> InsertOuterMoveStatusAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_isNew)
    {
      StatementHeaderView statementHeaderView = this;
      MoveInOutLinkView link = (MoveInOutLinkView) null;
      try
      {
        StatementHeaderView side_statement;
        if (p_isNew)
        {
          side_statement = statementHeaderView.SetSideStatement(p_db);
          side_statement.Lt_Details.Clear();
          side_statement.db_status = 1;
        }
        else
        {
          link = await p_db.Create<MoveInOutLinkView>().SelectOneAsync(statementHeaderView.sh_StatementNo, Enum2StrConverter.ToInOutDiv(statementHeaderView.sh_InOutDiv), statementHeaderView.sh_SiteID);
          if (link == null)
          {
            side_statement = statementHeaderView.SetSideStatement(p_db);
            side_statement.Lt_Details.Clear();
            side_statement.DB_STATUS = EnumDBStatus.NEW;
          }
          else
          {
            side_statement = await p_db.Create<StatementHeaderView>().SelectOneAsync(statementHeaderView.IsInOutReturn ? link.mio_InnerStatementNo : link.mio_OuterStatementNo, link.mio_SiteID);
            if (side_statement == null)
            {
              statementHeaderView.RowStatus = 0;
              statementHeaderView.message = "상대지점 전표 미존재";
              return false;
            }
            side_statement.DB_STATUS = EnumDBStatus.UPDATE;
          }
        }
        side_statement.sh_OrderDate = statementHeaderView.sh_OrderDate;
        side_statement.sh_OrderStatus = statementHeaderView.sh_OrderStatus;
        side_statement.sh_ConfirmDate = statementHeaderView.sh_ConfirmDate;
        side_statement.sh_ConfirmStatus = statementHeaderView.sh_ConfirmStatus;
        side_statement.sh_DeviceType = statementHeaderView.sh_DeviceType;
        side_statement.sh_OuterConnAuth = statementHeaderView.sh_OuterConnAuth;
        side_statement.sh_AdditionalOpt = statementHeaderView.sh_AdditionalOpt;
        side_statement.sh_Memo = statementHeaderView.sh_Memo;
        side_statement.sh_DeliveryNumber = statementHeaderView.sh_DeliveryNumber;
        side_statement.sh_TransmitStatus = statementHeaderView.sh_TransmitStatus;
        side_statement.sh_AssignUser = statementHeaderView.sh_AssignUser;
        side_statement.sh_InUser = statementHeaderView.sh_InUser;
        side_statement.sh_ModUser = statementHeaderView.sh_ModUser;
        side_statement.IsOuterMovePermitChecked = false;
        if (side_statement.IsNew)
          throw new UniServiceException(side_statement.message, "전표 상대지점 신규[X] 등록 오류");
        if (!await side_statement.UpdateStatusDataAsync(p_db, p_app_employee, false))
          throw new UniServiceException(side_statement.message, "전표 상대지점 수정 오류");
        if (link == null)
        {
          link = p_db.Create<MoveInOutLinkView>();
          if (statementHeaderView.IsInOutReturn)
          {
            link.mio_OuterStatementNo = statementHeaderView.sh_StatementNo;
            link.mio_InnerStatementNo = side_statement.sh_StatementNo;
          }
          else
          {
            link.mio_OuterStatementNo = side_statement.sh_StatementNo;
            link.mio_InnerStatementNo = statementHeaderView.sh_StatementNo;
          }
          if (!await link.InsertAsync())
            throw new UniServiceException(link.message, "전표 연결 신규 등록 오류");
        }
        return true;
      }
      catch (UniServiceException ex)
      {
        statementHeaderView.RowStatus = 0;
        statementHeaderView.message = ex.Message + "\n" + ex.UserMessage;
      }
      catch (Exception ex)
      {
        statementHeaderView.RowStatus = 0;
        statementHeaderView.message = ex.Message;
      }
      return false;
    }

    private StatementHeaderView SetSideStatement(UniOleDatabase p_db)
    {
      StatementHeaderView statementHeaderView = p_db.Create<StatementHeaderView>();
      statementHeaderView.PutData(this);
      statementHeaderView.sh_StatementNo = 0L;
      statementHeaderView.sh_Supplier = this.sh_StoreCode;
      statementHeaderView.sh_StoreCode = this.sh_Supplier;
      if (this.IsOuterMoveIn)
      {
        statementHeaderView.sh_StatementType = 4;
        statementHeaderView.sh_InOutDiv = -1;
      }
      else if (this.IsOuterMoveOut)
      {
        statementHeaderView.sh_StatementType = 4;
        statementHeaderView.sh_InOutDiv = 1;
      }
      return statementHeaderView;
    }
  }
}
