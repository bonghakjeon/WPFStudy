// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Payment.Statement.TPayment
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using Serilog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.TableInfo;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniStock.Payment.Statement
{
  public class TPayment : UbModelBase<TPayment>
  {
    private long _pay_Code;
    private long _pay_SiteID;
    protected DateTime? _pay_Date;
    protected int _pay_StoreCode;
    protected int _pay_Supplier;
    private int _pay_SupplierType;
    private int _pay_Type;
    private DateTime? _pay_StartDate;
    protected DateTime? _pay_EndDate;
    private int _pay_PayMethod;
    private int _pay_Round;
    private int _pay_Turn;
    private int _pay_ConfirmStatus;
    private int _pay_StatementStatus;
    private int _pay_TypeCustom1;
    private int _pay_TypeCustom2;
    private double _pay_BaseAmount;
    private double _pay_BuyAmount;
    private double _pay_BuyTax;
    private double _pay_BuyVat;
    private double _pay_BuyFree;
    private double _pay_BuyReturnAmount;
    private double _pay_BuyReturnTax;
    private double _pay_BuyReturnVat;
    private double _pay_BuyReturnFree;
    private double _pay_Deposit;
    private double _pay_SaleAmount;
    private double _pay_SaleTax;
    private double _pay_SaleVat;
    private double _pay_SaleFree;
    private double _pay_DeductionAmount;
    private double _pay_PayAmount;
    private double _pay_AddAmount;
    private double _pay_EndAmount;
    private DateTime? _pay_InDate;
    private int _pay_InUser;
    private DateTime? _pay_ModDate;
    private int _pay_ModUser;

    public override object _Key => (object) new object[1]
    {
      (object) this.pay_Code
    };

    public long pay_Code
    {
      get => this._pay_Code;
      set
      {
        this._pay_Code = value;
        this.Changed(nameof (pay_Code));
      }
    }

    public long pay_SiteID
    {
      get => this._pay_SiteID;
      set
      {
        this._pay_SiteID = value;
        this.Changed(nameof (pay_SiteID));
      }
    }

    public virtual DateTime? pay_Date
    {
      get => this._pay_Date;
      set
      {
        this._pay_Date = value;
        this.Changed(nameof (pay_Date));
      }
    }

    public virtual int pay_StoreCode
    {
      get => this._pay_StoreCode;
      set
      {
        this._pay_StoreCode = value;
        this.Changed(nameof (pay_StoreCode));
      }
    }

    public virtual int pay_Supplier
    {
      get => this._pay_Supplier;
      set
      {
        this._pay_Supplier = value;
        this.Changed(nameof (pay_Supplier));
      }
    }

    public int pay_SupplierType
    {
      get => this._pay_SupplierType;
      set
      {
        this._pay_SupplierType = value;
        this.Changed(nameof (pay_SupplierType));
        this.Changed("pay_SupplierTypeDesc");
      }
    }

    public string pay_SupplierTypeDesc => this.pay_SupplierType != 0 ? Enum2StrConverter.ToSupplierType(this.pay_SupplierType).ToDescription() : string.Empty;

    public int pay_Type
    {
      get => this._pay_Type;
      set
      {
        this._pay_Type = value;
        this.Changed(nameof (pay_Type));
        this.Changed("pay_TypeDesc");
      }
    }

    public string pay_TypeDesc => this.pay_Type != 0 ? Enum2StrConverter.ToWriteType(this.pay_Type).ToDescription() : string.Empty;

    public DateTime? pay_StartDate
    {
      get => this._pay_StartDate;
      set
      {
        this._pay_StartDate = value;
        this.Changed(nameof (pay_StartDate));
      }
    }

    public virtual DateTime? pay_EndDate
    {
      get => this._pay_EndDate;
      set
      {
        this._pay_EndDate = value;
        this.Changed(nameof (pay_EndDate));
      }
    }

    public int pay_PayMethod
    {
      get => this._pay_PayMethod;
      set
      {
        this._pay_PayMethod = value;
        this.Changed(nameof (pay_PayMethod));
      }
    }

    public int pay_Round
    {
      get => this._pay_Round;
      set
      {
        this._pay_Round = value;
        this.Changed(nameof (pay_Round));
      }
    }

    public int pay_Turn
    {
      get => this._pay_Turn;
      set
      {
        this._pay_Turn = value;
        this.Changed(nameof (pay_Turn));
      }
    }

    public int pay_ConfirmStatus
    {
      get => this._pay_ConfirmStatus;
      set
      {
        this._pay_ConfirmStatus = value;
        this.Changed(nameof (pay_ConfirmStatus));
        this.Changed("pay_ConfirmStatusDesc");
        this.Changed("IsConfirm");
        this.Changed("IsNotConfirm");
      }
    }

    public string pay_ConfirmStatusDesc => this.pay_ConfirmStatus != 0 ? Enum2StrConverter.ToConfirmStatus(this.pay_ConfirmStatus).ToDescription() : string.Empty;

    public bool IsConfirm => Enum2StrConverter.ToConfirmStatus(this.pay_ConfirmStatus) == EnumConfirmStatus.CONFIRM;

    public bool IsNotConfirm => Enum2StrConverter.ToConfirmStatus(this.pay_ConfirmStatus) == EnumConfirmStatus.NOTCONFIRM;

    public int pay_StatementStatus
    {
      get => this._pay_StatementStatus;
      set
      {
        this._pay_StatementStatus = value;
        this.Changed(nameof (pay_StatementStatus));
        this.Changed("pay_StatementStatusDesc");
        this.Changed("IsStatementConfirm");
        this.Changed("IsStatementNotConfirm");
      }
    }

    public string pay_StatementStatusDesc => this.pay_StatementStatus != 0 ? Enum2StrConverter.ToPayStatementStatus(this.pay_StatementStatus).ToDescription() : string.Empty;

    public bool IsStatementConfirm => Enum2StrConverter.ToPayStatementStatus(this.pay_ConfirmStatus) == EnumPayStatementStatus.Confirm;

    public bool IsStatementNotConfirm => Enum2StrConverter.ToPayStatementStatus(this.pay_ConfirmStatus) == EnumPayStatementStatus.NotConfirm;

    public int pay_TypeCustom1
    {
      get => this._pay_TypeCustom1;
      set
      {
        this._pay_TypeCustom1 = value;
        this.Changed(nameof (pay_TypeCustom1));
      }
    }

    public int pay_TypeCustom2
    {
      get => this._pay_TypeCustom2;
      set
      {
        this._pay_TypeCustom2 = value;
        this.Changed(nameof (pay_TypeCustom2));
      }
    }

    public double pay_BaseAmount
    {
      get => this._pay_BaseAmount;
      set
      {
        this._pay_BaseAmount = value;
        this.Changed(nameof (pay_BaseAmount));
      }
    }

    public double pay_BuyAmount
    {
      get => this._pay_BuyAmount;
      set
      {
        this._pay_BuyAmount = value;
        this.Changed(nameof (pay_BuyAmount));
      }
    }

    public double pay_BuyTax
    {
      get => this._pay_BuyTax;
      set
      {
        this._pay_BuyTax = value;
        this.Changed(nameof (pay_BuyTax));
      }
    }

    public double pay_BuyVat
    {
      get => this._pay_BuyVat;
      set
      {
        this._pay_BuyVat = value;
        this.Changed(nameof (pay_BuyVat));
      }
    }

    public double pay_BuyFree
    {
      get => this._pay_BuyFree;
      set
      {
        this._pay_BuyFree = value;
        this.Changed(nameof (pay_BuyFree));
      }
    }

    public double pay_BuyReturnAmount
    {
      get => this._pay_BuyReturnAmount;
      set
      {
        this._pay_BuyReturnAmount = value;
        this.Changed(nameof (pay_BuyReturnAmount));
      }
    }

    public double pay_BuyReturnTax
    {
      get => this._pay_BuyReturnTax;
      set
      {
        this._pay_BuyReturnTax = value;
        this.Changed(nameof (pay_BuyReturnTax));
      }
    }

    public double pay_BuyReturnVat
    {
      get => this._pay_BuyReturnVat;
      set
      {
        this._pay_BuyReturnVat = value;
        this.Changed(nameof (pay_BuyReturnVat));
      }
    }

    public double pay_BuyReturnFree
    {
      get => this._pay_BuyReturnFree;
      set
      {
        this._pay_BuyReturnFree = value;
        this.Changed(nameof (pay_BuyReturnFree));
      }
    }

    public double pay_Deposit
    {
      get => this._pay_Deposit;
      set
      {
        this._pay_Deposit = value;
        this.Changed(nameof (pay_Deposit));
      }
    }

    public double pay_SaleAmount
    {
      get => this._pay_SaleAmount;
      set
      {
        this._pay_SaleAmount = value;
        this.Changed(nameof (pay_SaleAmount));
      }
    }

    public double pay_SaleTax
    {
      get => this._pay_SaleTax;
      set
      {
        this._pay_SaleTax = value;
        this.Changed(nameof (pay_SaleTax));
      }
    }

    public double pay_SaleVat
    {
      get => this._pay_SaleVat;
      set
      {
        this._pay_SaleVat = value;
        this.Changed(nameof (pay_SaleVat));
      }
    }

    public double pay_SaleFree
    {
      get => this._pay_SaleFree;
      set
      {
        this._pay_SaleFree = value;
        this.Changed(nameof (pay_SaleFree));
      }
    }

    public double pay_DeductionAmount
    {
      get => this._pay_DeductionAmount;
      set
      {
        this._pay_DeductionAmount = value;
        this.Changed(nameof (pay_DeductionAmount));
      }
    }

    public double pay_PayAmount
    {
      get => this._pay_PayAmount;
      set
      {
        this._pay_PayAmount = value;
        this.Changed(nameof (pay_PayAmount));
      }
    }

    public double pay_AddAmount
    {
      get => this._pay_AddAmount;
      set
      {
        this._pay_AddAmount = value;
        this.Changed(nameof (pay_AddAmount));
      }
    }

    public double pay_EndAmount
    {
      get => this._pay_EndAmount;
      set
      {
        this._pay_EndAmount = value;
        this.Changed(nameof (pay_EndAmount));
      }
    }

    public void CalcEndAmount() => this.pay_EndAmount = this.pay_BaseAmount + (this.pay_BuyAmount - this.pay_BuyReturnAmount) - this.pay_DeductionAmount - this.pay_PayAmount - this.pay_AddAmount;

    public DateTime? pay_InDate
    {
      get => this._pay_InDate;
      set
      {
        this._pay_InDate = value;
        this.Changed(nameof (pay_InDate));
      }
    }

    public int pay_InUser
    {
      get => this._pay_InUser;
      set
      {
        this._pay_InUser = value;
        this.Changed(nameof (pay_InUser));
      }
    }

    public DateTime? pay_ModDate
    {
      get => this._pay_ModDate;
      set
      {
        this._pay_ModDate = value;
        this.Changed(nameof (pay_ModDate));
      }
    }

    public int pay_ModUser
    {
      get => this._pay_ModUser;
      set
      {
        this._pay_ModUser = value;
        this.Changed(nameof (pay_ModUser));
      }
    }

    public TPayment() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("pay_Code", new TTableColumn()
      {
        tc_orgin_name = "pay_Code",
        tc_trans_name = "결제코드"
      });
      columnInfo.Add("pay_SiteID", new TTableColumn()
      {
        tc_orgin_name = "pay_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("pay_Date", new TTableColumn()
      {
        tc_orgin_name = "pay_Date",
        tc_trans_name = "결제일"
      });
      columnInfo.Add("pay_StoreCode", new TTableColumn()
      {
        tc_orgin_name = "pay_StoreCode",
        tc_trans_name = "지점코드"
      });
      columnInfo.Add("pay_Supplier", new TTableColumn()
      {
        tc_orgin_name = "pay_Supplier",
        tc_trans_name = "코드"
      });
      columnInfo.Add("pay_SupplierType", new TTableColumn()
      {
        tc_orgin_name = "pay_SupplierType",
        tc_trans_name = "형태",
        tc_comm_code = 40
      });
      columnInfo.Add("pay_Type", new TTableColumn()
      {
        tc_orgin_name = "pay_Type",
        tc_trans_name = "타입",
        tc_comm_code = 68
      });
      columnInfo.Add("pay_StartDate", new TTableColumn()
      {
        tc_orgin_name = "pay_StartDate",
        tc_trans_name = "시작일자"
      });
      columnInfo.Add("pay_EndDate", new TTableColumn()
      {
        tc_orgin_name = "pay_EndDate",
        tc_trans_name = "종료일자"
      });
      columnInfo.Add("pay_PayMethod", new TTableColumn()
      {
        tc_orgin_name = "pay_PayMethod",
        tc_trans_name = "결제수단"
      });
      columnInfo.Add("pay_Round", new TTableColumn()
      {
        tc_orgin_name = "pay_Round",
        tc_trans_name = "회",
        tc_comm_code = 73
      });
      columnInfo.Add("pay_Turn", new TTableColumn()
      {
        tc_orgin_name = "pay_Turn",
        tc_trans_name = "차",
        tc_comm_code = 74
      });
      columnInfo.Add("pay_ConfirmStatus", new TTableColumn()
      {
        tc_orgin_name = "pay_ConfirmStatus",
        tc_trans_name = "결제확정",
        tc_comm_code = 49
      });
      columnInfo.Add("pay_StatementStatus", new TTableColumn()
      {
        tc_orgin_name = "pay_StatementStatus",
        tc_trans_name = "전표확정",
        tc_comm_code = 72
      });
      columnInfo.Add("pay_TypeCustom1", new TTableColumn()
      {
        tc_orgin_name = "pay_TypeCustom1",
        tc_trans_name = "타입1",
        tc_comm_code = 71
      });
      columnInfo.Add("pay_TypeCustom2", new TTableColumn()
      {
        tc_orgin_name = "pay_TypeCustom2",
        tc_trans_name = "타입2",
        tc_comm_code = 70
      });
      columnInfo.Add("pay_BaseAmount", new TTableColumn()
      {
        tc_orgin_name = "pay_BaseAmount",
        tc_trans_name = "기초금액"
      });
      columnInfo.Add("pay_BuyAmount", new TTableColumn()
      {
        tc_orgin_name = "pay_BuyAmount",
        tc_trans_name = "매입금액"
      });
      columnInfo.Add("pay_BuyTax", new TTableColumn()
      {
        tc_orgin_name = "pay_BuyTax",
        tc_trans_name = "매입과세계"
      });
      columnInfo.Add("pay_BuyVat", new TTableColumn()
      {
        tc_orgin_name = "pay_BuyVat",
        tc_trans_name = "매입부가세계"
      });
      columnInfo.Add("pay_BuyFree", new TTableColumn()
      {
        tc_orgin_name = "pay_BuyFree",
        tc_trans_name = "매입면세계"
      });
      columnInfo.Add("pay_BuyReturnAmount", new TTableColumn()
      {
        tc_orgin_name = "pay_BuyReturnAmount",
        tc_trans_name = "반품금액"
      });
      columnInfo.Add("pay_BuyReturnTax", new TTableColumn()
      {
        tc_orgin_name = "pay_BuyReturnTax",
        tc_trans_name = "반품과세계"
      });
      columnInfo.Add("pay_BuyReturnVat", new TTableColumn()
      {
        tc_orgin_name = "pay_BuyReturnVat",
        tc_trans_name = "반품부가세계"
      });
      columnInfo.Add("pay_BuyReturnFree", new TTableColumn()
      {
        tc_orgin_name = "pay_BuyReturnFree",
        tc_trans_name = "반품면세계"
      });
      columnInfo.Add("pay_Deposit", new TTableColumn()
      {
        tc_orgin_name = "pay_Deposit",
        tc_trans_name = "저장품"
      });
      columnInfo.Add("pay_SaleAmount", new TTableColumn()
      {
        tc_orgin_name = "pay_SaleAmount",
        tc_trans_name = "매출금액"
      });
      columnInfo.Add("pay_SaleTax", new TTableColumn()
      {
        tc_orgin_name = "pay_SaleTax",
        tc_trans_name = "매출과세계"
      });
      columnInfo.Add("pay_SaleVat", new TTableColumn()
      {
        tc_orgin_name = "pay_SaleVat",
        tc_trans_name = "매출부가세계"
      });
      columnInfo.Add("pay_SaleFree", new TTableColumn()
      {
        tc_orgin_name = "pay_SaleFree",
        tc_trans_name = "매출면세계"
      });
      columnInfo.Add("pay_DeductionAmount", new TTableColumn()
      {
        tc_orgin_name = "pay_DeductionAmount",
        tc_trans_name = "공제금액"
      });
      columnInfo.Add("pay_PayAmount", new TTableColumn()
      {
        tc_orgin_name = "pay_PayAmount",
        tc_trans_name = "결제금액"
      });
      columnInfo.Add("pay_AddAmount", new TTableColumn()
      {
        tc_orgin_name = "pay_AddAmount",
        tc_trans_name = "보정금액"
      });
      columnInfo.Add("pay_EndAmount", new TTableColumn()
      {
        tc_orgin_name = "pay_EndAmount",
        tc_trans_name = "기말금액"
      });
      columnInfo.Add("pay_InDate", new TTableColumn()
      {
        tc_orgin_name = "pay_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("pay_InUser", new TTableColumn()
      {
        tc_orgin_name = "pay_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("pay_ModDate", new TTableColumn()
      {
        tc_orgin_name = "pay_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("pay_ModUser", new TTableColumn()
      {
        tc_orgin_name = "pay_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.Payment;
      this.pay_Code = 0L;
      this.pay_SiteID = 0L;
      this.pay_Date = new DateTime?();
      this.pay_StoreCode = this.pay_Supplier = 0;
      this.pay_SupplierType = this.pay_Type = 0;
      this.pay_StartDate = new DateTime?();
      this.pay_EndDate = new DateTime?();
      this.pay_PayMethod = 0;
      this.pay_Round = 1;
      this.pay_Turn = 1;
      this.pay_ConfirmStatus = 2;
      this.pay_StatementStatus = 2;
      this.pay_TypeCustom1 = this.pay_TypeCustom2 = 0;
      this.pay_BaseAmount = this.pay_BuyAmount = this.pay_BuyTax = this.pay_BuyVat = this.pay_BuyFree = 0.0;
      this.pay_BuyReturnAmount = this.pay_BuyReturnTax = this.pay_BuyReturnVat = this.pay_BuyReturnFree = 0.0;
      this.pay_Deposit = 0.0;
      this.pay_SaleAmount = this.pay_SaleTax = this.pay_SaleVat = this.pay_SaleFree = 0.0;
      this.pay_DeductionAmount = this.pay_PayAmount = this.pay_AddAmount = this.pay_EndAmount = 0.0;
      this.pay_InDate = new DateTime?();
      this.pay_InUser = 0;
      this.pay_ModDate = new DateTime?();
      this.pay_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TPayment();

    public override object Clone()
    {
      TPayment tpayment = base.Clone() as TPayment;
      tpayment.pay_Code = this.pay_Code;
      tpayment.pay_SiteID = this.pay_SiteID;
      tpayment.pay_Date = this.pay_Date;
      tpayment.pay_StoreCode = this.pay_StoreCode;
      tpayment.pay_Supplier = this.pay_Supplier;
      tpayment.pay_SupplierType = this.pay_SupplierType;
      tpayment.pay_Type = this.pay_Type;
      tpayment.pay_StartDate = this.pay_StartDate;
      tpayment.pay_EndDate = this.pay_EndDate;
      tpayment.pay_PayMethod = this.pay_PayMethod;
      tpayment.pay_Round = this.pay_Round;
      tpayment.pay_Turn = this.pay_Turn;
      tpayment.pay_ConfirmStatus = this.pay_ConfirmStatus;
      tpayment.pay_StatementStatus = this.pay_StatementStatus;
      tpayment.pay_TypeCustom1 = this.pay_TypeCustom1;
      tpayment.pay_TypeCustom2 = this.pay_TypeCustom2;
      tpayment.pay_BaseAmount = this.pay_BaseAmount;
      tpayment.pay_BuyAmount = this.pay_BuyAmount;
      tpayment.pay_BuyTax = this.pay_BuyTax;
      tpayment.pay_BuyVat = this.pay_BuyVat;
      tpayment.pay_BuyFree = this.pay_BuyFree;
      tpayment.pay_BuyReturnAmount = this.pay_BuyReturnAmount;
      tpayment.pay_BuyReturnTax = this.pay_BuyReturnTax;
      tpayment.pay_BuyReturnVat = this.pay_BuyReturnVat;
      tpayment.pay_BuyReturnFree = this.pay_BuyReturnFree;
      tpayment.pay_Deposit = this.pay_Deposit;
      tpayment.pay_SaleAmount = this.pay_SaleAmount;
      tpayment.pay_SaleTax = this.pay_SaleTax;
      tpayment.pay_SaleVat = this.pay_SaleVat;
      tpayment.pay_SaleFree = this.pay_SaleFree;
      tpayment.pay_DeductionAmount = this.pay_DeductionAmount;
      tpayment.pay_PayAmount = this.pay_PayAmount;
      tpayment.pay_AddAmount = this.pay_AddAmount;
      tpayment.pay_EndAmount = this.pay_EndAmount;
      tpayment.pay_InDate = this.pay_InDate;
      tpayment.pay_ModDate = this.pay_ModDate;
      tpayment.pay_InUser = this.pay_InUser;
      tpayment.pay_ModUser = this.pay_ModUser;
      return (object) tpayment;
    }

    public void PutData(TPayment pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.pay_Code = pSource.pay_Code;
      this.pay_SiteID = pSource.pay_SiteID;
      this.pay_Date = pSource.pay_Date;
      this.pay_StoreCode = pSource.pay_StoreCode;
      this.pay_Supplier = pSource.pay_Supplier;
      this.pay_SupplierType = pSource.pay_SupplierType;
      this.pay_Type = pSource.pay_Type;
      this.pay_StartDate = pSource.pay_StartDate;
      this.pay_EndDate = pSource.pay_EndDate;
      this.pay_PayMethod = pSource.pay_PayMethod;
      this.pay_Round = pSource.pay_Round;
      this.pay_Turn = pSource.pay_Turn;
      this.pay_ConfirmStatus = pSource.pay_ConfirmStatus;
      this.pay_StatementStatus = pSource.pay_StatementStatus;
      this.pay_TypeCustom1 = pSource.pay_TypeCustom1;
      this.pay_TypeCustom2 = pSource.pay_TypeCustom2;
      this.pay_BaseAmount = pSource.pay_BaseAmount;
      this.pay_BuyAmount = pSource.pay_BuyAmount;
      this.pay_BuyTax = pSource.pay_BuyTax;
      this.pay_BuyVat = pSource.pay_BuyVat;
      this.pay_BuyFree = pSource.pay_BuyFree;
      this.pay_BuyReturnAmount = pSource.pay_BuyReturnAmount;
      this.pay_BuyReturnTax = pSource.pay_BuyReturnTax;
      this.pay_BuyReturnVat = pSource.pay_BuyReturnVat;
      this.pay_BuyReturnFree = pSource.pay_BuyReturnFree;
      this.pay_Deposit = pSource.pay_Deposit;
      this.pay_SaleAmount = pSource.pay_SaleAmount;
      this.pay_SaleTax = pSource.pay_SaleTax;
      this.pay_SaleVat = pSource.pay_SaleVat;
      this.pay_SaleFree = pSource.pay_SaleFree;
      this.pay_DeductionAmount = pSource.pay_DeductionAmount;
      this.pay_PayAmount = pSource.pay_PayAmount;
      this.pay_AddAmount = pSource.pay_AddAmount;
      this.pay_EndAmount = pSource.pay_EndAmount;
      this.pay_InDate = pSource.pay_InDate;
      this.pay_ModDate = pSource.pay_ModDate;
      this.pay_InUser = pSource.pay_InUser;
      this.pay_ModUser = pSource.pay_ModUser;
    }

    public bool IsZero(EnumZeroCheck pCheckType, TPayment pSource) => pSource == null || pSource.pay_BaseAmount.IsZero() && pSource.pay_BuyAmount.IsZero() && pSource.pay_BuyTax.IsZero() && pSource.pay_BuyVat.IsZero() && pSource.pay_BuyFree.IsZero() && pSource.pay_BuyReturnAmount.IsZero() && pSource.pay_BuyReturnTax.IsZero() && pSource.pay_BuyReturnVat.IsZero() && pSource.pay_BuyReturnFree.IsZero() && pSource.pay_Deposit.IsZero() && pSource.pay_SaleAmount.IsZero() && pSource.pay_SaleTax.IsZero() && pSource.pay_SaleVat.IsZero() && pSource.pay_SaleFree.IsZero() && pSource.pay_DeductionAmount.IsZero() && pSource.pay_PayAmount.IsZero() && pSource.pay_AddAmount.IsZero() && pSource.pay_EndAmount.IsZero();

    public virtual bool IsZero(EnumZeroCheck pCheckType) => this.IsZero(pCheckType, this);

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.pay_Code = p_rs.GetFieldLong("pay_Code");
        this.pay_SiteID = p_rs.GetFieldLong("pay_SiteID");
        if (this.pay_SiteID == 0L)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.pay_Date = p_rs.GetFieldDateTime("pay_Date");
        this.pay_StoreCode = p_rs.GetFieldInt("pay_StoreCode");
        this.pay_StoreCode = p_rs.GetFieldInt("pay_StoreCode");
        this.pay_Supplier = p_rs.GetFieldInt("pay_Supplier");
        this.pay_SupplierType = p_rs.GetFieldInt("pay_SupplierType");
        this.pay_Type = p_rs.GetFieldInt("pay_Type");
        this.pay_StartDate = p_rs.GetFieldDateTime("pay_StartDate");
        this.pay_EndDate = p_rs.GetFieldDateTime("pay_EndDate");
        this.pay_PayMethod = p_rs.GetFieldInt("pay_PayMethod");
        this.pay_Round = p_rs.GetFieldInt("pay_Round");
        this.pay_Turn = p_rs.GetFieldInt("pay_Turn");
        this.pay_ConfirmStatus = p_rs.GetFieldInt("pay_ConfirmStatus");
        this.pay_StatementStatus = p_rs.GetFieldInt("pay_StatementStatus");
        this.pay_TypeCustom1 = p_rs.GetFieldInt("pay_TypeCustom1");
        this.pay_TypeCustom2 = p_rs.GetFieldInt("pay_TypeCustom2");
        this.pay_BaseAmount = p_rs.GetFieldDouble("pay_BaseAmount");
        this.pay_BuyAmount = p_rs.GetFieldDouble("pay_BuyAmount");
        this.pay_BuyTax = p_rs.GetFieldDouble("pay_BuyTax");
        this.pay_BuyVat = p_rs.GetFieldDouble("pay_BuyVat");
        this.pay_BuyFree = p_rs.GetFieldDouble("pay_BuyFree");
        this.pay_BuyReturnAmount = p_rs.GetFieldDouble("pay_BuyReturnAmount");
        this.pay_BuyReturnTax = p_rs.GetFieldDouble("pay_BuyReturnTax");
        this.pay_BuyReturnVat = p_rs.GetFieldDouble("pay_BuyReturnVat");
        this.pay_BuyReturnFree = p_rs.GetFieldDouble("pay_BuyReturnFree");
        this.pay_Deposit = p_rs.GetFieldDouble("pay_Deposit");
        this.pay_SaleAmount = p_rs.GetFieldDouble("pay_SaleAmount");
        this.pay_SaleTax = p_rs.GetFieldDouble("pay_SaleTax");
        this.pay_SaleVat = p_rs.GetFieldDouble("pay_SaleVat");
        this.pay_SaleFree = p_rs.GetFieldDouble("pay_SaleFree");
        this.pay_DeductionAmount = p_rs.GetFieldDouble("pay_DeductionAmount");
        this.pay_PayAmount = p_rs.GetFieldDouble("pay_PayAmount");
        this.pay_AddAmount = p_rs.GetFieldDouble("pay_AddAmount");
        this.pay_EndAmount = p_rs.GetFieldDouble("pay_EndAmount");
        this.pay_InDate = p_rs.GetFieldDateTime("pay_InDate");
        this.pay_InUser = p_rs.GetFieldInt("pay_InUser");
        this.pay_ModDate = p_rs.GetFieldDateTime("pay_ModDate");
        this.pay_ModUser = p_rs.GetFieldInt("pay_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public virtual string DataClearQuery(Hashtable p_param)
    {
      StringBuilder stringBuilder = new StringBuilder();
      try
      {
        string uniStock = UbModelBase.UNI_STOCK;
        this.TableCode.ToString();
        if (!p_param.ContainsKey((object) "pay_SiteID") || Convert.ToInt64(p_param[(object) "pay_SiteID"].ToString()) <= 0L)
          throw new Exception("사이트 아이디 정보 데이터 부족.");
        if (!p_param.ContainsKey((object) "pay_Date") || p_param[(object) "pay_Date"].ToString().Length == 0)
          throw new Exception("결제일자 정보 데이터 부족.");
        int num = !p_param.ContainsKey((object) "_INIT_") ? 0 : (Convert.ToBoolean(p_param[(object) "_INIT_"].ToString()) ? 1 : 0);
        DateTime firstDateOfMonth = (DateTime) p_param[(object) "pay_Date"];
        if (num != 0)
          firstDateOfMonth = firstDateOfMonth.ToFirstDateOfMonth();
        if (firstDateOfMonth.ToIntFormat() == 0)
          throw new Exception("결제일자 정보 기준 변경 에러.");
        stringBuilder.Append(string.Format(" UPDATE {0}{1}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) this.TableCode));
        EnumDB enumDb = DbQueryHelper.DbTypeNotNull();
        if (enumDb == EnumDB.MYSQL)
          stringBuilder.Append(string.Format("\nINNER JOIN {0}{1}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.StoreInfo) + " ON pay_StoreCode=si_StoreCode AND pay_SiteID=si_SiteID AND " + "si_StockConfirmDate".DateToStr(EnumDbDateType.YYYYMMDD).ToInt() + "<pay_Date_YyyyMMdd AND " + "si_StockStartDate".DateToStr(EnumDbDateType.YYYYMMDD).ToInt() + "<pay_Date_YyyyMMdd");
        stringBuilder.Append(" SET  pay_BaseAmount=0,pay_BuyAmount=0,pay_BuyTax=0,pay_BuyVat=0,pay_BuyFree=0,pay_BuyReturnAmount=0,pay_BuyReturnTax=0,pay_BuyReturnVat=0,pay_BuyReturnFree=0,pay_Deposit=0,pay_SaleAmount=0,pay_SaleTax=0,pay_SaleVat=0,pay_SaleFree=0,pay_DeductionAmount=0,pay_PayAmount=0,pay_AddAmount=0,pay_EndAmount=0");
        if (enumDb == EnumDB.MSSQL)
          stringBuilder.Append(string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) this.TableCode, (object) DbQueryHelper.ToWithNolock()) + string.Format("\nINNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()) + " ON pay_StoreCode=si_StoreCode AND pay_SiteID=si_SiteID AND " + "si_StockConfirmDate".DateToStr(EnumDbDateType.YYYYMMDD).ToInt() + "<pay_Date_YyyyMMdd AND " + "si_StockStartDate".DateToStr(EnumDbDateType.YYYYMMDD).ToInt() + "<pay_Date_YyyyMMdd");
        stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "pay_SiteID", p_param[(object) "pay_SiteID"]));
        stringBuilder.Append(" AND pay_Date>='" + new DateTime?(firstDateOfMonth).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
        stringBuilder.Append(" AND pay_Date<='" + new DateTime?(firstDateOfMonth).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
        if (p_param.ContainsKey((object) "pay_StoreCode") || Convert.ToInt32(p_param[(object) "pay_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_Type", (object) Convert.ToInt32(p_param[(object) "pay_StoreCode"].ToString())));
        else
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_Type", (object) 1));
        stringBuilder.Append(string.Format(" AND {0}!={1}", (object) "pay_ConfirmStatus", (object) 2));
        if (p_param.ContainsKey((object) "pay_StoreCode") || Convert.ToInt32(p_param[(object) "pay_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_StoreCode", p_param[(object) "pay_StoreCode"]));
        else if (p_param.ContainsKey((object) "pay_StoreCode_IN_") && p_param[(object) "pay_StoreCode_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "pay_StoreCode", p_param[(object) "pay_StoreCode_IN_"]));
        else if (p_param.ContainsKey((object) "_STORE_AUTHS_") && p_param[(object) "_STORE_AUTHS_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "pay_StoreCode", p_param[(object) "_STORE_AUTHS_"]));
        else
          stringBuilder.Append(" AND pay_StoreCode > 0");
        if (p_param.ContainsKey((object) "pay_Supplier") || Convert.ToInt32(p_param[(object) "pay_Supplier"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_Supplier", p_param[(object) "pay_Supplier"]));
        else if (p_param.ContainsKey((object) "pay_Supplier_IN_"))
        {
          if (p_param[(object) "pay_Supplier_IN_"].ToString().Length > 0)
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "pay_Supplier", p_param[(object) "pay_Supplier_IN_"]));
        }
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) ex.GetHashCode()) + " 내용 : " + ex.Message + "\n" + string.Format(" Query : {0}\n", (object) stringBuilder) + "--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
        stringBuilder.Clear();
      }
      return stringBuilder.ToString();
    }

    public virtual bool DataClear(Hashtable p_param)
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.DataClearQuery(p_param)))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.pay_Code, (object) this.pay_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public virtual async Task<bool> DataClearAsync(Hashtable p_param)
    {
      TPayment tpayment = this;
      // ISSUE: reference to a compiler-generated method
      tpayment.\u003C\u003En__0();
      if (await tpayment.OleDB.ExecuteAsync(tpayment.DataClearQuery(p_param)))
        return true;
      tpayment.message = " " + tpayment.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tpayment.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tpayment.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tpayment.pay_Code, (object) tpayment.pay_SiteID) + " 내용 : " + tpayment.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tpayment.message);
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) this.TableCode) + " pay_Code,pay_SiteID,pay_Date,pay_StoreCode,pay_Supplier,pay_SupplierType,pay_Type,pay_StartDate,pay_EndDate,pay_PayMethod,pay_Round,pay_Turn,pay_ConfirmStatus,pay_StatementStatus,pay_TypeCustom1,pay_TypeCustom2,pay_BaseAmount,pay_BuyAmount,pay_BuyTax,pay_BuyVat,pay_BuyFree,pay_BuyReturnAmount,pay_BuyReturnTax,pay_BuyReturnVat,pay_BuyReturnFree,pay_Deposit,pay_SaleAmount,pay_SaleTax,pay_SaleVat,pay_SaleFree,pay_DeductionAmount,pay_PayAmount,pay_AddAmount,pay_EndAmount,pay_InDate,pay_InUser,pay_ModDate,pay_ModUser) VALUES ( " + string.Format(" {0}", (object) this.pay_Code) + string.Format(",{0}", (object) this.pay_SiteID) + "," + this.pay_Date.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + string.Format(",{0},{1},{2},{3}", (object) this.pay_StoreCode, (object) this.pay_Supplier, (object) this.pay_SupplierType, (object) this.pay_Type) + "," + this.pay_StartDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + "," + this.pay_EndDate.GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'") + string.Format(",{0},{1},{2}", (object) this.pay_PayMethod, (object) this.pay_Round, (object) this.pay_Turn) + string.Format(",{0},{1},{2},{3}", (object) this.pay_ConfirmStatus, (object) this.pay_StatementStatus, (object) this.pay_TypeCustom1, (object) this.pay_TypeCustom2) + "," + this.pay_BaseAmount.FormatTo("{0:0.0000}") + "," + this.pay_BuyAmount.FormatTo("{0:0.0000}") + "," + this.pay_BuyTax.FormatTo("{0:0.0000}") + "," + this.pay_BuyVat.FormatTo("{0:0.0000}") + "," + this.pay_BuyFree.FormatTo("{0:0.0000}") + "," + this.pay_BuyReturnAmount.FormatTo("{0:0.0000}") + "," + this.pay_BuyReturnTax.FormatTo("{0:0.0000}") + "," + this.pay_BuyReturnVat.FormatTo("{0:0.0000}") + "," + this.pay_BuyReturnFree.FormatTo("{0:0.0000}") + "," + this.pay_Deposit.FormatTo("{0:0.0000}") + "," + this.pay_SaleAmount.FormatTo("{0:0.0000}") + "," + this.pay_SaleTax.FormatTo("{0:0.0000}") + "," + this.pay_SaleVat.FormatTo("{0:0.0000}") + "," + this.pay_SaleFree.FormatTo("{0:0.0000}") + "," + this.pay_DeductionAmount.FormatTo("{0:0.0000}") + "," + this.pay_PayAmount.FormatTo("{0:0.0000}") + "," + this.pay_AddAmount.FormatTo("{0:0.0000}") + "," + this.pay_EndAmount.FormatTo("{0:0.0000}") + string.Format(",{0},{1}", (object) this.pay_InDate.GetDateToStrInNull(), (object) this.pay_InUser) + string.Format(",{0},{1}", (object) this.pay_ModDate.GetDateToStrInNull(), (object) this.pay_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.pay_Code, (object) this.pay_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TPayment tpayment = this;
      // ISSUE: reference to a compiler-generated method
      tpayment.\u003C\u003En__0();
      if (await tpayment.OleDB.ExecuteAsync(tpayment.InsertQuery()))
        return true;
      tpayment.message = " " + tpayment.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tpayment.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tpayment.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tpayment.pay_Code, (object) tpayment.pay_SiteID) + " 내용 : " + tpayment.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tpayment.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) this.TableCode) + " pay_Date=" + this.pay_Date.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + string.Format(",{0}={1},{2}={3}", (object) "pay_StoreCode", (object) this.pay_StoreCode, (object) "pay_Supplier", (object) this.pay_Supplier) + string.Format(",{0}={1},{2}={3}", (object) "pay_SupplierType", (object) this.pay_SupplierType, (object) "pay_Type", (object) this.pay_Type) + ",pay_StartDate=" + this.pay_StartDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + ",pay_EndDate=" + this.pay_EndDate.GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'") + string.Format(",{0}={1},{2}={3},{4}={5}", (object) "pay_PayMethod", (object) this.pay_PayMethod, (object) "pay_Round", (object) this.pay_Round, (object) "pay_Turn", (object) this.pay_Turn) + string.Format(",{0}={1},{2}={3}", (object) "pay_ConfirmStatus", (object) this.pay_ConfirmStatus, (object) "pay_StatementStatus", (object) this.pay_StatementStatus) + string.Format(",{0}={1},{2}={3}", (object) "pay_TypeCustom1", (object) this.pay_TypeCustom1, (object) "pay_TypeCustom2", (object) this.pay_TypeCustom2) + ",pay_BaseAmount=" + this.pay_BaseAmount.FormatTo("{0:0.0000}") + ",pay_BuyAmount=" + this.pay_BuyAmount.FormatTo("{0:0.0000}") + ",pay_BuyTax=" + this.pay_BuyTax.FormatTo("{0:0.0000}") + ",pay_BuyVat=" + this.pay_BuyVat.FormatTo("{0:0.0000}") + ",pay_BuyFree=" + this.pay_BuyFree.FormatTo("{0:0.0000}") + ",pay_BuyReturnAmount=" + this.pay_BuyReturnAmount.FormatTo("{0:0.0000}") + ",pay_BuyReturnTax=" + this.pay_BuyReturnTax.FormatTo("{0:0.0000}") + ",pay_BuyReturnVat=" + this.pay_BuyReturnVat.FormatTo("{0:0.0000}") + ",pay_BuyReturnFree=" + this.pay_BuyReturnFree.FormatTo("{0:0.0000}") + ",pay_Deposit=" + this.pay_Deposit.FormatTo("{0:0.0000}") + ",pay_SaleAmount=" + this.pay_Deposit.FormatTo("{0:0.0000}") + ",pay_SaleTax=" + this.pay_SaleTax.FormatTo("{0:0.0000}") + ",pay_SaleVat=" + this.pay_SaleVat.FormatTo("{0:0.0000}") + ",pay_SaleFree=" + this.pay_SaleFree.FormatTo("{0:0.0000}") + ",pay_DeductionAmount=" + this.pay_DeductionAmount.FormatTo("{0:0.0000}") + ",pay_PayAmount=" + this.pay_PayAmount.FormatTo("{0:0.0000}") + ",pay_AddAmount=" + this.pay_AddAmount.FormatTo("{0:0.0000}") + ",pay_EndAmount=" + this.pay_EndAmount.FormatTo("{0:0.0000}") + string.Format(",{0}={1},{2}={3}", (object) "pay_ModDate", (object) this.pay_ModDate.GetDateToStrInNull(), (object) "pay_ModUser", (object) this.pay_ModUser) + string.Format(" WHERE {0}={1}", (object) "pay_Code", (object) this.pay_Code) + string.Format(" AND {0}={1}", (object) "pay_SiteID", (object) this.pay_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.pay_Code, (object) this.pay_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TPayment tpayment = this;
      // ISSUE: reference to a compiler-generated method
      tpayment.\u003C\u003En__1();
      if (await tpayment.OleDB.ExecuteAsync(tpayment.UpdateQuery()))
        return true;
      tpayment.message = " " + tpayment.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tpayment.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tpayment.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tpayment.pay_Code, (object) tpayment.pay_SiteID) + " 내용 : " + tpayment.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tpayment.message);
      return false;
    }

    public override string UpdateExInsertMySQLQuery()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(this.InsertQuery());
      if (stringBuilder.ToString().Contains(";"))
      {
        string str = stringBuilder.ToString().Replace(";", string.Empty);
        stringBuilder.Clear();
        stringBuilder.Append(str);
      }
      stringBuilder.Append(" ON DUPLICATE KEY UPDATE ");
      stringBuilder.Append("\n");
      stringBuilder.Append(" pay_Date=" + this.pay_Date.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + string.Format(",{0}={1},{2}={3}", (object) "pay_StoreCode", (object) this.pay_StoreCode, (object) "pay_Supplier", (object) this.pay_Supplier) + string.Format(",{0}={1},{2}={3}", (object) "pay_SupplierType", (object) this.pay_SupplierType, (object) "pay_Type", (object) this.pay_Type) + ",pay_StartDate=" + this.pay_StartDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + ",pay_EndDate=" + this.pay_EndDate.GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'") + string.Format(",{0}={1},{2}={3},{4}={5}", (object) "pay_PayMethod", (object) this.pay_PayMethod, (object) "pay_Round", (object) this.pay_Round, (object) "pay_Turn", (object) this.pay_Turn) + string.Format(",{0}={1},{2}={3}", (object) "pay_ConfirmStatus", (object) this.pay_ConfirmStatus, (object) "pay_StatementStatus", (object) this.pay_StatementStatus) + string.Format(",{0}={1},{2}={3}", (object) "pay_TypeCustom1", (object) this.pay_TypeCustom1, (object) "pay_TypeCustom2", (object) this.pay_TypeCustom2) + ",pay_BaseAmount=" + this.pay_BaseAmount.FormatTo("{0:0.0000}") + ",pay_BuyAmount=" + this.pay_BuyAmount.FormatTo("{0:0.0000}") + ",pay_BuyTax=" + this.pay_BuyTax.FormatTo("{0:0.0000}") + ",pay_BuyVat=" + this.pay_BuyVat.FormatTo("{0:0.0000}") + ",pay_BuyFree=" + this.pay_BuyFree.FormatTo("{0:0.0000}") + ",pay_BuyReturnAmount=" + this.pay_BuyReturnAmount.FormatTo("{0:0.0000}") + ",pay_BuyReturnTax=" + this.pay_BuyReturnTax.FormatTo("{0:0.0000}") + ",pay_BuyReturnVat=" + this.pay_BuyReturnVat.FormatTo("{0:0.0000}") + ",pay_BuyReturnFree=" + this.pay_BuyReturnFree.FormatTo("{0:0.0000}") + ",pay_Deposit=" + this.pay_Deposit.FormatTo("{0:0.0000}") + ",pay_SaleAmount=" + this.pay_Deposit.FormatTo("{0:0.0000}") + ",pay_SaleTax=" + this.pay_SaleTax.FormatTo("{0:0.0000}") + ",pay_SaleVat=" + this.pay_SaleVat.FormatTo("{0:0.0000}") + ",pay_SaleFree=" + this.pay_SaleFree.FormatTo("{0:0.0000}") + ",pay_DeductionAmount=" + this.pay_DeductionAmount.FormatTo("{0:0.0000}") + ",pay_PayAmount=" + this.pay_PayAmount.FormatTo("{0:0.0000}") + ",pay_AddAmount=" + this.pay_AddAmount.FormatTo("{0:0.0000}") + ",pay_EndAmount=" + this.pay_EndAmount.FormatTo("{0:0.0000}") + string.Format(",{0}={1},{2}={3}", (object) "pay_ModDate", (object) this.pay_ModDate.GetDateToStrInNull(), (object) "pay_ModUser", (object) this.pay_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.pay_Code, (object) this.pay_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TPayment tpayment = this;
      // ISSUE: reference to a compiler-generated method
      tpayment.\u003C\u003En__1();
      if (await tpayment.OleDB.ExecuteAsync(tpayment.UpdateExInsertQuery()))
        return true;
      tpayment.message = " " + tpayment.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tpayment.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tpayment.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tpayment.pay_Code, (object) tpayment.pay_SiteID) + " 내용 : " + tpayment.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tpayment.message);
      return false;
    }

    public override string DeleteQuery() => string.Format(" DELETE FROM {0}{1}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) this.TableCode) + string.Format(" WHERE {0}={1}", (object) "pay_Code", (object) this.pay_Code) + string.Format(" AND {0}={1}", (object) "pay_SiteID", (object) this.pay_SiteID);

    public override bool Delete()
    {
      this.InsertChecked();
      string pStrExec = this.DeleteQuery();
      if (this.OleDB.Execute(pStrExec))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 삭제 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 코드 : ({0},{1})\n", (object) this.pay_Code, (object) this.pay_SiteID) + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n 쿼리 : " + pStrExec + "\n--------------------------------------------------------------------------------------------------\n";
      return false;
    }

    public override async Task<bool> DeleteAsync()
    {
      TPayment tpayment = this;
      // ISSUE: reference to a compiler-generated method
      tpayment.\u003C\u003En__0();
      if (await tpayment.OleDB.ExecuteAsync(tpayment.DeleteQuery()))
        return true;
      tpayment.message = " " + tpayment.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tpayment.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tpayment.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tpayment.pay_Code, (object) tpayment.pay_SiteID) + " 내용 : " + tpayment.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tpayment.message);
      return false;
    }

    public virtual string DeleteQuery(long p_pay_Code, long p_pay_SiteID = 0)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format(" DELETE FROM {0}{1} ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) this.TableCode));
      stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "pay_Code", (object) p_pay_Code));
      if (p_pay_SiteID > 0L)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_SiteID", (object) p_pay_SiteID));
      return stringBuilder.ToString();
    }

    public virtual string DeleteDetailsQuery(long p_pay_Code, long p_pay_SiteID = 0)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format(" DELETE FROM {0}{1} ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) TableCodeType.PaymentDetail));
      stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "pd_PaymentID", (object) p_pay_Code));
      if (p_pay_SiteID > 0L)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pd_SiteID", (object) p_pay_SiteID));
      return stringBuilder.ToString();
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "pay_SiteID") && Convert.ToInt64(hashtable[(object) "pay_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "pay_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "pay_Code") && Convert.ToInt64(hashtable[(object) "pay_Code"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_Code", hashtable[(object) "pay_Code"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "pay_Date"))
        {
          stringBuilder.Append(" AND pay_Date >='" + new DateTime?((DateTime) hashtable[(object) "pay_Date"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND pay_Date <='" + new DateTime?((DateTime) hashtable[(object) "pay_Date"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
        }
        if (hashtable.ContainsKey((object) "pay_Date_BEGIN_") && hashtable.ContainsKey((object) "pay_Date_END_"))
        {
          stringBuilder.Append(" AND pay_Date >='" + new DateTime?((DateTime) hashtable[(object) "pay_Date_BEGIN_"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND pay_Date <='" + new DateTime?((DateTime) hashtable[(object) "pay_Date_END_"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
        }
        if (hashtable.ContainsKey((object) "pay_Date_NEXT_"))
          stringBuilder.Append(" AND pay_Date >='" + new DateTime?((DateTime) hashtable[(object) "pay_Date_NEXT_"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
        if (hashtable.ContainsKey((object) "pay_Date_OUTER_NEXT_"))
          stringBuilder.Append(" AND pay_Date >'" + new DateTime?((DateTime) hashtable[(object) "pay_Date_NEXT_"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
        if (hashtable.ContainsKey((object) "si_StoreCode") && Convert.ToInt32(hashtable[(object) "si_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_StoreCode", hashtable[(object) "si_StoreCode"]));
        else if (hashtable.ContainsKey((object) "pay_StoreCode") && Convert.ToInt32(hashtable[(object) "pay_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_StoreCode", hashtable[(object) "pay_StoreCode"]));
        else if (hashtable.ContainsKey((object) "si_StoreCode_IN_") && hashtable[(object) "si_StoreCode_IN_"].ToString().Length > 0)
        {
          if (hashtable[(object) "si_StoreCode_IN_"].ToString().Contains(","))
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "pay_StoreCode", hashtable[(object) "si_StoreCode_IN_"]));
          else
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_StoreCode", hashtable[(object) "si_StoreCode_IN_"]));
        }
        else if (hashtable.ContainsKey((object) "pay_StoreCode_IN_") && hashtable[(object) "pay_StoreCode_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "pay_StoreCode", hashtable[(object) "pay_StoreCode_IN_"]));
        else if (hashtable.ContainsKey((object) "_STORE_AUTHS_") && hashtable[(object) "_STORE_AUTHS_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "pay_StoreCode", hashtable[(object) "_STORE_AUTHS_"]));
        if (hashtable.ContainsKey((object) "su_Supplier") && Convert.ToInt32(hashtable[(object) "su_Supplier"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_Supplier", hashtable[(object) "su_Supplier"]));
        else if (hashtable.ContainsKey((object) "pay_Supplier") && Convert.ToInt32(hashtable[(object) "pay_Supplier"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_Supplier", hashtable[(object) "pay_Supplier"]));
        else if (hashtable.ContainsKey((object) "su_Supplier_IN_") && hashtable[(object) "su_Supplier_IN_"].ToString().Length > 0)
        {
          if (hashtable[(object) "su_Supplier_IN_"].ToString().Contains(","))
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "pay_Supplier", hashtable[(object) "su_Supplier_IN_"]));
          else
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_Supplier", hashtable[(object) "su_Supplier_IN_"]));
        }
        else if (hashtable.ContainsKey((object) "pay_Supplier_IN_") && hashtable[(object) "pay_Supplier_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "pay_Supplier", hashtable[(object) "pay_Supplier_IN_"]));
        else if (hashtable.ContainsKey((object) "_SUPPLIER_AUTHS_") && hashtable[(object) "_SUPPLIER_AUTHS_"].ToString().Length > 0)
        {
          if (hashtable[(object) "su_Supplier_IN_"].ToString().Contains(","))
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "pay_Supplier", hashtable[(object) "su_Supplier_IN_"]));
          else
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_Supplier", hashtable[(object) "su_Supplier_IN_"]));
        }
        if (hashtable.ContainsKey((object) "su_SupplierType") && Convert.ToInt32(hashtable[(object) "su_SupplierType"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_SupplierType", hashtable[(object) "su_SupplierType"]));
        else if (hashtable.ContainsKey((object) "pay_SupplierType") && Convert.ToInt32(hashtable[(object) "pay_SupplierType"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_SupplierType", hashtable[(object) "pay_SupplierType"]));
        else if (hashtable.ContainsKey((object) "su_SupplierType_IN_") && hashtable[(object) "su_SupplierType_IN_"].ToString().Length > 0)
        {
          if (hashtable[(object) "su_SupplierType_IN_"].ToString().Contains(","))
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "pay_SupplierType", hashtable[(object) "su_SupplierType_IN_"]));
          else
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_SupplierType", hashtable[(object) "su_SupplierType_IN_"]));
        }
        else if (hashtable.ContainsKey((object) "pay_SupplierType_IN_") && hashtable[(object) "pay_SupplierType_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "pay_SupplierType", hashtable[(object) "pay_SupplierType_IN_"]));
        if (hashtable.ContainsKey((object) "pay_Type") && Convert.ToInt32(hashtable[(object) "pay_Type"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_Type", hashtable[(object) "pay_Type"]));
        else if (hashtable.ContainsKey((object) "pay_Type_IN_") && hashtable[(object) "pay_Type_IN_"].ToString().Length > 0)
        {
          if (hashtable[(object) "pay_Type_IN_"].ToString().Contains(","))
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "pay_Type", hashtable[(object) "pay_Type_IN_"]));
          else
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_Type", hashtable[(object) "pay_Type_IN_"]));
        }
        if (hashtable.ContainsKey((object) "pay_PayMethod") && Convert.ToInt32(hashtable[(object) "pay_PayMethod"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_PayMethod", hashtable[(object) "pay_PayMethod"]));
        else if (hashtable.ContainsKey((object) "pay_PayMethod_IN_") && hashtable[(object) "pay_PayMethod_IN_"].ToString().Length > 0)
        {
          if (hashtable[(object) "pay_PayMethod_IN_"].ToString().Contains(","))
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "pay_PayMethod", hashtable[(object) "pay_PayMethod_IN_"]));
          else
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_PayMethod", hashtable[(object) "pay_PayMethod_IN_"]));
        }
        if (hashtable.ContainsKey((object) "pay_Round") && Convert.ToInt32(hashtable[(object) "pay_Round"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_Round", hashtable[(object) "pay_Round"]));
        if (hashtable.ContainsKey((object) "pay_Turn") && Convert.ToInt32(hashtable[(object) "pay_Turn"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_Turn", hashtable[(object) "pay_Turn"]));
        if (hashtable.ContainsKey((object) "pay_ConfirmStatus") && Convert.ToInt32(hashtable[(object) "pay_ConfirmStatus"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_ConfirmStatus", hashtable[(object) "pay_ConfirmStatus"]));
        else if (hashtable.ContainsKey((object) "pay_ConfirmStatus_IN_") && hashtable[(object) "pay_ConfirmStatus_IN_"].ToString().Length > 0)
        {
          if (hashtable[(object) "pay_ConfirmStatus_IN_"].ToString().Contains(","))
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "pay_ConfirmStatus", hashtable[(object) "pay_ConfirmStatus_IN_"]));
          else
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_ConfirmStatus", hashtable[(object) "pay_ConfirmStatus_IN_"]));
        }
        if (hashtable.ContainsKey((object) "pay_StatementStatus") && Convert.ToInt32(hashtable[(object) "pay_StatementStatus"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_StatementStatus", hashtable[(object) "pay_StatementStatus"]));
        else if (hashtable.ContainsKey((object) "pay_StatementStatus_IN_") && hashtable[(object) "pay_StatementStatus_IN_"].ToString().Length > 0)
        {
          if (hashtable[(object) "pay_StatementStatus_IN_"].ToString().Contains(","))
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "pay_StatementStatus", hashtable[(object) "pay_StatementStatus_IN_"]));
          else
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_StatementStatus", hashtable[(object) "pay_StatementStatus_IN_"]));
        }
        if (hashtable.ContainsKey((object) "pay_TypeCustom1") && Convert.ToInt32(hashtable[(object) "pay_TypeCustom1"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_TypeCustom1", hashtable[(object) "pay_TypeCustom1"]));
        if (hashtable.ContainsKey((object) "pay_TypeCustom2") && Convert.ToInt32(hashtable[(object) "pay_TypeCustom2"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_TypeCustom2", hashtable[(object) "pay_TypeCustom2"]));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_"))
        {
          int length = hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length;
        }
      }
      return !stringBuilder.ToString().Equals(" WHERE") ? stringBuilder.Replace("WHERE AND", "WHERE").ToString() : string.Empty;
    }

    public override string GetSelectQuery(object p_param)
    {
      StringBuilder stringBuilder = new StringBuilder();
      try
      {
        string uniStock = UbModelBase.UNI_STOCK;
        string str = this.TableCode.ToString();
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniStock = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
        }
        stringBuilder.Append(" SELECT  pay_Code,pay_SiteID,pay_Date,pay_StoreCode,pay_Supplier,pay_SupplierType,pay_Type,pay_StartDate,pay_EndDate,pay_PayMethod,pay_Round,pay_Turn,pay_ConfirmStatus,pay_StatementStatus,pay_TypeCustom1,pay_TypeCustom2,pay_BaseAmount,pay_BuyAmount,pay_BuyTax,pay_BuyVat,pay_BuyFree,pay_BuyReturnAmount,pay_BuyReturnTax,pay_BuyReturnVat,pay_BuyReturnFree,pay_Deposit,pay_SaleAmount,pay_SaleTax,pay_SaleVat,pay_SaleFree,pay_DeductionAmount,pay_PayAmount,pay_AddAmount,pay_EndAmount,pay_InDate,pay_InUser,pay_ModDate,pay_ModUser");
        stringBuilder.Append(" FROM " + DbQueryHelper.ToDBNameBridge(uniStock) + str + " " + DbQueryHelper.ToWithNolock());
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) ex.GetHashCode()) + " 내용 : " + ex.Message + "\n Query : " + stringBuilder.ToString() + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
        stringBuilder.Clear();
      }
      return stringBuilder.ToString();
    }
  }
}
