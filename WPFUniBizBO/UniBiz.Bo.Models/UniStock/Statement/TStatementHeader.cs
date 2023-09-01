// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.TStatementHeader
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
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.TableInfo;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniStock.Statement
{
  public class TStatementHeader : UbModelBase<TStatementHeader>
  {
    private long _sh_StatementNo;
    private long _sh_SiteID;
    private int _sh_StoreCode;
    private DateTime? _sh_OrderDate;
    private int _sh_OrderStatus;
    private DateTime? _sh_ConfirmDate;
    private int _sh_ConfirmStatus;
    private int _sh_Supplier;
    private int _sh_SupplierType;
    private int _sh_InOutDiv;
    private int _sh_StatementType;
    private int _sh_ReasonCode;
    private double _sh_CostTaxAmt;
    private double _sh_CostTaxFreeAmt;
    private double _sh_CostVatAmt;
    private double _sh_Deposit;
    private double _sh_PriceTaxAmt;
    private double _sh_PriceTaxFreeAmt;
    private double _sh_PriceVatAmt;
    private double _sh_ProfitAmt;
    private int _sh_DeviceType;
    private int _sh_OuterConnAuth;
    private int _sh_AdditionalOpt;
    private string _sh_Memo;
    private string _sh_DeliveryNumber;
    private int _sh_TransmitStatus;
    private DateTime? _sh_TransmitDate;
    private long _sh_MobieStatementNo;
    private int _sh_AssignUser;
    private DateTime? _sh_InDate;
    private int _sh_InUser;
    private DateTime? _sh_ModDate;
    private int _sh_ModUser;

    public override object _Key => (object) new object[1]
    {
      (object) this.sh_StatementNo
    };

    public long sh_StatementNo
    {
      get => this._sh_StatementNo;
      set
      {
        this._sh_StatementNo = value;
        this.Changed(nameof (sh_StatementNo));
      }
    }

    public long sh_SiteID
    {
      get => this._sh_SiteID;
      set
      {
        this._sh_SiteID = value;
        this.Changed(nameof (sh_SiteID));
      }
    }

    public int sh_StoreCode
    {
      get => this._sh_StoreCode;
      set
      {
        this._sh_StoreCode = value;
        this.Changed(nameof (sh_StoreCode));
      }
    }

    public DateTime? sh_OrderDate
    {
      get => this._sh_OrderDate;
      set
      {
        this._sh_OrderDate = value;
        this.Changed(nameof (sh_OrderDate));
      }
    }

    public int sh_OrderStatus
    {
      get => this._sh_OrderStatus;
      set
      {
        this._sh_OrderStatus = value;
        this.Changed(nameof (sh_OrderStatus));
        this.Changed("sh_OrderStatusDesc");
        this.Changed("IsOrderConfirm");
        this.Changed("IsOrderNotConfirm");
        this.Changed("IsOrderToStatement");
        this.Changed("IsOrderDead");
        this.Changed("IsOrderDelete");
        this.Changed("IsOrder");
      }
    }

    public string sh_OrderStatusDesc => this.sh_OrderStatus != 0 ? Enum2StrConverter.ToStatementOrderStatus(this.sh_OrderStatus).ToDescription() : string.Empty;

    [JsonIgnore]
    public bool IsOrderConfirm => Enum2StrConverter.ToStatementOrderStatus(this.sh_OrderStatus) == EnumStatementOrderStatus.Confirm;

    [JsonIgnore]
    public bool IsOrderNotConfirm => Enum2StrConverter.ToStatementOrderStatus(this.sh_OrderStatus) == EnumStatementOrderStatus.NotConfirm;

    [JsonIgnore]
    public bool IsOrderToStatement => Enum2StrConverter.ToStatementOrderStatus(this.sh_OrderStatus) == EnumStatementOrderStatus.Statement;

    [JsonIgnore]
    public bool IsOrderDead => Enum2StrConverter.ToStatementOrderStatus(this.sh_OrderStatus) == EnumStatementOrderStatus.Dead;

    [JsonIgnore]
    public bool IsOrderDelete => Enum2StrConverter.ToStatementOrderStatus(this.sh_OrderStatus) == EnumStatementOrderStatus.Delete;

    public DateTime? sh_ConfirmDate
    {
      get => this._sh_ConfirmDate;
      set
      {
        this._sh_ConfirmDate = value;
        this.Changed(nameof (sh_ConfirmDate));
      }
    }

    public int sh_ConfirmStatus
    {
      get => this._sh_ConfirmStatus;
      set
      {
        this._sh_ConfirmStatus = value;
        this.Changed(nameof (sh_ConfirmStatus));
        this.Changed("sh_ConfirmStatusDesc");
        this.Changed("IsConfirm");
        this.Changed("IsNotConfirm");
        this.Changed("IsDelete");
        this.Changed("IsOrder");
      }
    }

    public string sh_ConfirmStatusDesc => this.sh_ConfirmStatus != 0 ? Enum2StrConverter.ToStatementConfirmStatus(this.sh_ConfirmStatus).ToDescription() : string.Empty;

    public bool IsConfirm => Enum2StrConverter.ToStatementConfirmStatus(this.sh_ConfirmStatus) == EnumStatementConfirmStatus.Confirm;

    public bool IsNotConfirm => Enum2StrConverter.ToStatementConfirmStatus(this.sh_ConfirmStatus) == EnumStatementConfirmStatus.NotConfirm;

    public bool IsDelete => Enum2StrConverter.ToStatementConfirmStatus(this.sh_ConfirmStatus) == EnumStatementConfirmStatus.Delete;

    public bool IsOrder => this.IsNotConfirm && !this.IsOrderDead;

    public int sh_Supplier
    {
      get => this._sh_Supplier;
      set
      {
        this._sh_Supplier = value;
        this.Changed(nameof (sh_Supplier));
      }
    }

    public int sh_SupplierType
    {
      get => this._sh_SupplierType;
      set
      {
        this._sh_SupplierType = value;
        this.Changed(nameof (sh_SupplierType));
      }
    }

    public int sh_InOutDiv
    {
      get => this._sh_InOutDiv;
      set
      {
        this._sh_InOutDiv = value;
        this.Changed(nameof (sh_InOutDiv));
        this.Changed("IsInOutNormal");
        this.Changed("IsInOutReturn");
        this.Changed("IsOuterMoveIn");
        this.Changed("IsOuterMoveOut");
      }
    }

    public bool IsInOutNormal => Enum2StrConverter.ToInOutDiv(this.sh_InOutDiv) == EnumInOutDiv.Normal;

    public bool IsInOutReturn => Enum2StrConverter.ToInOutDiv(this.sh_InOutDiv) == EnumInOutDiv.Return;

    public int sh_StatementType
    {
      get => this._sh_StatementType;
      set
      {
        this._sh_StatementType = value;
        this.Changed(nameof (sh_StatementType));
        this.Changed("sh_StatementTypeDesc");
        this.Changed("IsBuy");
        this.Changed("IsSale");
        this.Changed("IsInnerMove");
        this.Changed("IsOuterMove");
        this.Changed("IsOuterMoveIn");
        this.Changed("IsOuterMoveOut");
        this.Changed("IsAdjust");
        this.Changed("IsDisuse");
        this.Changed("IsStockMove");
        this.Changed("IsPayment");
      }
    }

    public string sh_StatementTypeDesc => this.sh_StatementType != 0 ? Enum2StrConverter.ToStatementType(this.sh_StatementType).ToDescription() : string.Empty;

    public bool IsBuy => Enum2StrConverter.ToStatementType(this.sh_StatementType) == EnumStatementType.Buy;

    public bool IsSale => Enum2StrConverter.ToStatementType(this.sh_StatementType) == EnumStatementType.Sale;

    public bool IsInnerMove => Enum2StrConverter.ToStatementType(this.sh_StatementType) == EnumStatementType.InnerMove;

    public bool IsOuterMove => Enum2StrConverter.ToStatementType(this.sh_StatementType) == EnumStatementType.OuterMove;

    public bool IsOuterMoveIn => Enum2StrConverter.ToStatementType(this.sh_StatementType) == EnumStatementType.OuterMove && this.IsInOutNormal;

    public bool IsOuterMoveOut => Enum2StrConverter.ToStatementType(this.sh_StatementType) == EnumStatementType.OuterMove && this.IsInOutReturn;

    public bool IsAdjust => Enum2StrConverter.ToStatementType(this.sh_StatementType) == EnumStatementType.Adjust;

    public bool IsDisuse => Enum2StrConverter.ToStatementType(this.sh_StatementType) == EnumStatementType.Disuse;

    public bool IsStockMove => Enum2StrConverter.ToStatementType(this.sh_StatementType) == EnumStatementType.StockMove;

    public bool IsPayment => Enum2StrConverter.ToStatementType(this.sh_StatementType) == EnumStatementType.Payment;

    public int sh_ReasonCode
    {
      get => this._sh_ReasonCode;
      set
      {
        this._sh_ReasonCode = value;
        this.Changed(nameof (sh_ReasonCode));
      }
    }

    public double sh_CostTaxAmt
    {
      get => this._sh_CostTaxAmt;
      set
      {
        this._sh_CostTaxAmt = CalcHelper.CalcDoubleToFormatDouble(value);
        this.Changed(nameof (sh_CostTaxAmt));
        this.Changed("sh_SaleMargin");
      }
    }

    public double sh_CostTaxFreeAmt
    {
      get => this._sh_CostTaxFreeAmt;
      set
      {
        this._sh_CostTaxFreeAmt = CalcHelper.CalcDoubleToFormatDouble(value);
        this.Changed(nameof (sh_CostTaxFreeAmt));
        this.Changed("sh_SaleMargin");
      }
    }

    public double sh_CostVatAmt
    {
      get => this._sh_CostVatAmt;
      set
      {
        this._sh_CostVatAmt = CalcHelper.CalcDoubleToFormatDouble(value);
        this.Changed(nameof (sh_CostVatAmt));
      }
    }

    public double sh_Deposit
    {
      get => this._sh_Deposit;
      set
      {
        this._sh_Deposit = CalcHelper.CalcDoubleToFormatDouble(value);
        this.Changed(nameof (sh_Deposit));
      }
    }

    public double sh_PriceTaxAmt
    {
      get => this._sh_PriceTaxAmt;
      set
      {
        this._sh_PriceTaxAmt = CalcHelper.CalcDoubleToFormatDouble(value);
        this.Changed(nameof (sh_PriceTaxAmt));
        this.Changed("sh_SaleMargin");
      }
    }

    public double sh_PriceTaxFreeAmt
    {
      get => this._sh_PriceTaxFreeAmt;
      set
      {
        this._sh_PriceTaxFreeAmt = CalcHelper.CalcDoubleToFormatDouble(value);
        this.Changed(nameof (sh_PriceTaxFreeAmt));
        this.Changed("sh_SaleMargin");
      }
    }

    public double sh_PriceVatAmt
    {
      get => this._sh_PriceVatAmt;
      set
      {
        this._sh_PriceVatAmt = CalcHelper.CalcDoubleToFormatDouble(value);
        this.Changed(nameof (sh_PriceVatAmt));
      }
    }

    public double sh_ProfitAmt
    {
      get => this._sh_ProfitAmt;
      set
      {
        this._sh_ProfitAmt = CalcHelper.CalcDoubleToFormatDouble(value);
        this.Changed(nameof (sh_ProfitAmt));
      }
    }

    public double sh_SaleMargin => (this.sh_CostTaxAmt + this.sh_CostTaxFreeAmt).ToSaleMargin(this.sh_PriceTaxAmt + this.sh_PriceTaxFreeAmt);

    public int sh_DeviceType
    {
      get => this._sh_DeviceType;
      set
      {
        this._sh_DeviceType = value;
        this.Changed(nameof (sh_DeviceType));
        this.Changed("sh_DeviceTypeDesc");
      }
    }

    public string sh_DeviceTypeDesc => this.sh_DeviceType != 0 ? Enum2StrConverter.ToDeviceType(this.sh_DeviceType).ToDescription() : string.Empty;

    public int sh_OuterConnAuth
    {
      get => this._sh_OuterConnAuth;
      set
      {
        this._sh_OuterConnAuth = value;
        this.Changed(nameof (sh_OuterConnAuth));
      }
    }

    public int sh_AdditionalOpt
    {
      get => this._sh_AdditionalOpt;
      set
      {
        this._sh_AdditionalOpt = value;
        this.Changed(nameof (sh_AdditionalOpt));
      }
    }

    public string sh_Memo
    {
      get => this._sh_Memo;
      set
      {
        this._sh_Memo = UbModelBase.LeftStr(value, 500).Replace("'", "´");
        this.Changed(nameof (sh_Memo));
      }
    }

    public string sh_DeliveryNumber
    {
      get => this._sh_DeliveryNumber;
      set
      {
        this._sh_DeliveryNumber = UbModelBase.LeftStr(value, 30).Replace("'", "´");
        this.Changed(nameof (sh_DeliveryNumber));
      }
    }

    public int sh_TransmitStatus
    {
      get => this._sh_TransmitStatus;
      set
      {
        this._sh_TransmitStatus = value;
        this.Changed(nameof (sh_TransmitStatus));
      }
    }

    public DateTime? sh_TransmitDate
    {
      get => this._sh_TransmitDate;
      set
      {
        this._sh_TransmitDate = value;
        this.Changed(nameof (sh_TransmitDate));
      }
    }

    public long sh_MobieStatementNo
    {
      get => this._sh_MobieStatementNo;
      set
      {
        this._sh_MobieStatementNo = value;
        this.Changed(nameof (sh_MobieStatementNo));
      }
    }

    public int sh_AssignUser
    {
      get => this._sh_AssignUser;
      set
      {
        this._sh_AssignUser = value;
        this.Changed(nameof (sh_AssignUser));
      }
    }

    public DateTime? sh_InDate
    {
      get => this._sh_InDate;
      set
      {
        this._sh_InDate = value;
        this.Changed(nameof (sh_InDate));
      }
    }

    public int sh_InUser
    {
      get => this._sh_InUser;
      set
      {
        this._sh_InUser = value;
        this.Changed(nameof (sh_InUser));
      }
    }

    public DateTime? sh_ModDate
    {
      get => this._sh_ModDate;
      set
      {
        this._sh_ModDate = value;
        this.Changed(nameof (sh_ModDate));
      }
    }

    public int sh_ModUser
    {
      get => this._sh_ModUser;
      set
      {
        this._sh_ModUser = value;
        this.Changed(nameof (sh_ModUser));
      }
    }

    public TStatementHeader() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("sh_StatementNo", new TTableColumn()
      {
        tc_orgin_name = "sh_StatementNo",
        tc_trans_name = "전표 코드"
      });
      columnInfo.Add("sh_SiteID", new TTableColumn()
      {
        tc_orgin_name = "sh_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("sh_StoreCode", new TTableColumn()
      {
        tc_orgin_name = "sh_StoreCode",
        tc_trans_name = "지점코드"
      });
      columnInfo.Add("sh_OrderDate", new TTableColumn()
      {
        tc_orgin_name = "sh_OrderDate",
        tc_trans_name = "발주일"
      });
      columnInfo.Add("sh_OrderStatus", new TTableColumn()
      {
        tc_orgin_name = "sh_OrderStatus",
        tc_trans_name = "발주상태",
        tc_comm_code = 47
      });
      columnInfo.Add("sh_ConfirmDate", new TTableColumn()
      {
        tc_orgin_name = "sh_ConfirmDate",
        tc_trans_name = "확정일"
      });
      columnInfo.Add("sh_ConfirmStatus", new TTableColumn()
      {
        tc_orgin_name = "sh_ConfirmStatus",
        tc_trans_name = "확정상태",
        tc_comm_code = 49
      });
      columnInfo.Add("sh_Supplier", new TTableColumn()
      {
        tc_orgin_name = "sh_Supplier",
        tc_trans_name = "코드"
      });
      columnInfo.Add("sh_SupplierType", new TTableColumn()
      {
        tc_orgin_name = "sh_SupplierType",
        tc_trans_name = "형태",
        tc_comm_code = 40
      });
      columnInfo.Add("sh_InOutDiv", new TTableColumn()
      {
        tc_orgin_name = "sh_InOutDiv",
        tc_trans_name = "입출고 타입",
        tc_comm_code = 21
      });
      columnInfo.Add("sh_StatementType", new TTableColumn()
      {
        tc_orgin_name = "sh_StatementType",
        tc_trans_name = "전표 타입",
        tc_comm_code = 22
      });
      columnInfo.Add("sh_ReasonCode", new TTableColumn()
      {
        tc_orgin_name = "sh_ReasonCode",
        tc_trans_name = "사유 코드"
      });
      columnInfo.Add("sh_CostTaxAmt", new TTableColumn()
      {
        tc_orgin_name = "sh_CostTaxAmt",
        tc_trans_name = "과세계"
      });
      columnInfo.Add("sh_CostTaxFreeAmt", new TTableColumn()
      {
        tc_orgin_name = "sh_CostTaxFreeAmt",
        tc_trans_name = "면세계"
      });
      columnInfo.Add("sh_CostVatAmt", new TTableColumn()
      {
        tc_orgin_name = "sh_CostVatAmt",
        tc_trans_name = "부가세계"
      });
      columnInfo.Add("sh_Deposit", new TTableColumn()
      {
        tc_orgin_name = "sh_Deposit",
        tc_trans_name = "보증금"
      });
      columnInfo.Add("sh_PriceTaxAmt", new TTableColumn()
      {
        tc_orgin_name = "sh_PriceTaxAmt",
        tc_trans_name = "매가 과세계"
      });
      columnInfo.Add("sh_PriceTaxFreeAmt", new TTableColumn()
      {
        tc_orgin_name = "sh_PriceTaxFreeAmt",
        tc_trans_name = "매가 면세계"
      });
      columnInfo.Add("sh_PriceVatAmt", new TTableColumn()
      {
        tc_orgin_name = "sh_PriceVatAmt",
        tc_trans_name = "매가 부가세계"
      });
      columnInfo.Add("sh_ProfitAmt", new TTableColumn()
      {
        tc_orgin_name = "sh_ProfitAmt",
        tc_trans_name = "세제외이익"
      });
      columnInfo.Add("sh_DeviceType", new TTableColumn()
      {
        tc_orgin_name = "sh_DeviceType",
        tc_trans_name = "장치타입",
        tc_comm_code = 50
      });
      columnInfo.Add("sh_OuterConnAuth", new TTableColumn()
      {
        tc_orgin_name = "sh_OuterConnAuth",
        tc_trans_name = "장치 코드"
      });
      columnInfo.Add("sh_AdditionalOpt", new TTableColumn()
      {
        tc_orgin_name = "sh_AdditionalOpt",
        tc_trans_name = "추가옵션"
      });
      columnInfo.Add("sh_Memo", new TTableColumn()
      {
        tc_orgin_name = "sh_Memo",
        tc_trans_name = "메모"
      });
      columnInfo.Add("sh_DeliveryNumber", new TTableColumn()
      {
        tc_orgin_name = "sh_DeliveryNumber",
        tc_trans_name = "송장번호"
      });
      columnInfo.Add("sh_TransmitStatus", new TTableColumn()
      {
        tc_orgin_name = "sh_TransmitStatus",
        tc_trans_name = "전송상태",
        tc_comm_code = 59
      });
      columnInfo.Add("sh_TransmitDate", new TTableColumn()
      {
        tc_orgin_name = "sh_TransmitDate",
        tc_trans_name = "전송일"
      });
      columnInfo.Add("sh_MobieStatementNo", new TTableColumn()
      {
        tc_orgin_name = "sh_MobieStatementNo",
        tc_trans_name = "장치 전표 번호"
      });
      columnInfo.Add("sh_AssignUser", new TTableColumn()
      {
        tc_orgin_name = "sh_AssignUser",
        tc_trans_name = "담당사원"
      });
      columnInfo.Add("sh_InDate", new TTableColumn()
      {
        tc_orgin_name = "sh_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("sh_InUser", new TTableColumn()
      {
        tc_orgin_name = "sh_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("sh_ModDate", new TTableColumn()
      {
        tc_orgin_name = "sh_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("sh_ModUser", new TTableColumn()
      {
        tc_orgin_name = "sh_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.StatementHeader;
      this.sh_StatementNo = 0L;
      this.sh_SiteID = 0L;
      this.sh_StoreCode = 0;
      this.sh_OrderDate = new DateTime?();
      this.sh_OrderStatus = 0;
      this.sh_ConfirmDate = new DateTime?();
      this.sh_ConfirmStatus = 0;
      this.sh_Supplier = this.sh_SupplierType = 0;
      this.sh_InOutDiv = 1;
      this.sh_StatementType = 1;
      this.sh_ReasonCode = 0;
      this.sh_CostTaxAmt = this.sh_CostTaxFreeAmt = this.sh_CostVatAmt = 0.0;
      this.sh_Deposit = this.sh_PriceTaxAmt = this.sh_PriceTaxFreeAmt = this.sh_PriceVatAmt = this.sh_ProfitAmt = 0.0;
      this.sh_DeviceType = 1;
      this.sh_OuterConnAuth = 0;
      this.sh_AdditionalOpt = 0;
      this.sh_Memo = string.Empty;
      this.sh_DeliveryNumber = string.Empty;
      this.sh_TransmitStatus = 2;
      this.sh_TransmitDate = new DateTime?();
      this.sh_MobieStatementNo = 0L;
      this.sh_AssignUser = 0;
      this.sh_InDate = new DateTime?();
      this.sh_InUser = 0;
      this.sh_ModDate = new DateTime?();
      this.sh_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TStatementHeader();

    public override object Clone()
    {
      TStatementHeader tstatementHeader = base.Clone() as TStatementHeader;
      tstatementHeader.sh_StatementNo = this.sh_StatementNo;
      tstatementHeader.sh_SiteID = this.sh_SiteID;
      tstatementHeader.sh_StoreCode = this.sh_StoreCode;
      tstatementHeader.sh_OrderDate = this.sh_OrderDate;
      tstatementHeader.sh_OrderStatus = this.sh_OrderStatus;
      tstatementHeader.sh_ConfirmDate = this.sh_ConfirmDate;
      tstatementHeader.sh_ConfirmStatus = this.sh_ConfirmStatus;
      tstatementHeader.sh_Supplier = this.sh_Supplier;
      tstatementHeader.sh_SupplierType = this.sh_SupplierType;
      tstatementHeader.sh_InOutDiv = this.sh_InOutDiv;
      tstatementHeader.sh_StatementType = this.sh_StatementType;
      tstatementHeader.sh_ReasonCode = this.sh_ReasonCode;
      tstatementHeader.sh_CostTaxAmt = this.sh_CostTaxAmt;
      tstatementHeader.sh_CostTaxFreeAmt = this.sh_CostTaxFreeAmt;
      tstatementHeader.sh_CostVatAmt = this.sh_CostVatAmt;
      tstatementHeader.sh_Deposit = this.sh_Deposit;
      tstatementHeader.sh_PriceTaxAmt = this.sh_PriceTaxAmt;
      tstatementHeader.sh_PriceTaxFreeAmt = this.sh_PriceTaxFreeAmt;
      tstatementHeader.sh_PriceVatAmt = this.sh_PriceVatAmt;
      tstatementHeader.sh_ProfitAmt = this.sh_ProfitAmt;
      tstatementHeader.sh_DeviceType = this.sh_DeviceType;
      tstatementHeader.sh_OuterConnAuth = this.sh_OuterConnAuth;
      tstatementHeader.sh_AdditionalOpt = this.sh_AdditionalOpt;
      tstatementHeader.sh_Memo = this.sh_Memo;
      tstatementHeader.sh_DeliveryNumber = this.sh_DeliveryNumber;
      tstatementHeader.sh_TransmitStatus = this.sh_TransmitStatus;
      tstatementHeader.sh_TransmitDate = this.sh_TransmitDate;
      tstatementHeader.sh_MobieStatementNo = this.sh_MobieStatementNo;
      tstatementHeader.sh_AssignUser = this.sh_AssignUser;
      tstatementHeader.sh_InDate = this.sh_InDate;
      tstatementHeader.sh_InUser = this.sh_InUser;
      tstatementHeader.sh_ModDate = this.sh_ModDate;
      tstatementHeader.sh_ModUser = this.sh_ModUser;
      return (object) tstatementHeader;
    }

    public void PutData(TStatementHeader pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.sh_StatementNo = pSource.sh_StatementNo;
      this.sh_SiteID = pSource.sh_SiteID;
      this.sh_StoreCode = pSource.sh_StoreCode;
      this.sh_OrderDate = pSource.sh_OrderDate;
      this.sh_OrderStatus = pSource.sh_OrderStatus;
      this.sh_ConfirmDate = pSource.sh_ConfirmDate;
      this.sh_ConfirmStatus = pSource.sh_ConfirmStatus;
      this.sh_Supplier = pSource.sh_Supplier;
      this.sh_SupplierType = pSource.sh_SupplierType;
      this.sh_InOutDiv = pSource.sh_InOutDiv;
      this.sh_StatementType = pSource.sh_StatementType;
      this.sh_ReasonCode = pSource.sh_ReasonCode;
      this.sh_CostTaxAmt = pSource.sh_CostTaxAmt;
      this.sh_CostTaxFreeAmt = pSource.sh_CostTaxFreeAmt;
      this.sh_CostVatAmt = pSource.sh_CostVatAmt;
      this.sh_Deposit = pSource.sh_Deposit;
      this.sh_PriceTaxAmt = pSource.sh_PriceTaxAmt;
      this.sh_PriceTaxFreeAmt = pSource.sh_PriceTaxFreeAmt;
      this.sh_PriceVatAmt = pSource.sh_PriceVatAmt;
      this.sh_ProfitAmt = pSource.sh_ProfitAmt;
      this.sh_DeviceType = pSource.sh_DeviceType;
      this.sh_OuterConnAuth = pSource.sh_OuterConnAuth;
      this.sh_AdditionalOpt = pSource.sh_AdditionalOpt;
      this.sh_Memo = pSource.sh_Memo;
      this.sh_DeliveryNumber = pSource.sh_DeliveryNumber;
      this.sh_TransmitStatus = pSource.sh_TransmitStatus;
      this.sh_TransmitDate = pSource.sh_TransmitDate;
      this.sh_MobieStatementNo = pSource.sh_MobieStatementNo;
      this.sh_AssignUser = pSource.sh_AssignUser;
      this.sh_InDate = pSource.sh_InDate;
      this.sh_InUser = pSource.sh_InUser;
      this.sh_ModDate = pSource.sh_ModDate;
      this.sh_ModUser = pSource.sh_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.sh_StatementNo = p_rs.GetFieldLong("sh_StatementNo");
        if (this.sh_StatementNo == 0L)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.sh_SiteID = p_rs.GetFieldLong("sh_SiteID");
        this.sh_StoreCode = p_rs.GetFieldInt("sh_StoreCode");
        this.sh_OrderDate = p_rs.GetFieldDateTime("sh_OrderDate");
        this.sh_OrderStatus = p_rs.GetFieldInt("sh_OrderStatus");
        this.sh_ConfirmDate = p_rs.GetFieldDateTime("sh_ConfirmDate");
        this.sh_ConfirmStatus = p_rs.GetFieldInt("sh_ConfirmStatus");
        this.sh_Supplier = p_rs.GetFieldInt("sh_Supplier");
        this.sh_SupplierType = p_rs.GetFieldInt("sh_SupplierType");
        this.sh_InOutDiv = p_rs.GetFieldInt("sh_InOutDiv");
        this.sh_StatementType = p_rs.GetFieldInt("sh_StatementType");
        this.sh_ReasonCode = p_rs.GetFieldInt("sh_ReasonCode");
        this.sh_CostTaxAmt = p_rs.GetFieldDouble("sh_CostTaxAmt");
        this.sh_CostTaxFreeAmt = p_rs.GetFieldDouble("sh_CostTaxFreeAmt");
        this.sh_CostVatAmt = p_rs.GetFieldDouble("sh_CostVatAmt");
        this.sh_Deposit = p_rs.GetFieldDouble("sh_Deposit");
        this.sh_PriceTaxAmt = p_rs.GetFieldDouble("sh_PriceTaxAmt");
        this.sh_PriceTaxFreeAmt = p_rs.GetFieldDouble("sh_PriceTaxFreeAmt");
        this.sh_PriceVatAmt = p_rs.GetFieldDouble("sh_PriceVatAmt");
        this.sh_ProfitAmt = p_rs.GetFieldDouble("sh_ProfitAmt");
        this.sh_DeviceType = p_rs.GetFieldInt("sh_DeviceType");
        this.sh_OuterConnAuth = p_rs.GetFieldInt("sh_OuterConnAuth");
        this.sh_AdditionalOpt = p_rs.GetFieldInt("sh_AdditionalOpt");
        this.sh_Memo = p_rs.GetFieldString("sh_Memo");
        this.sh_DeliveryNumber = p_rs.GetFieldString("sh_DeliveryNumber");
        this.sh_TransmitStatus = p_rs.GetFieldInt("sh_TransmitStatus");
        this.sh_TransmitDate = p_rs.GetFieldDateTime("sh_TransmitDate");
        this.sh_MobieStatementNo = p_rs.GetFieldLong("sh_MobieStatementNo");
        this.sh_AssignUser = p_rs.GetFieldInt("sh_AssignUser");
        this.sh_InDate = p_rs.GetFieldDateTime("sh_InDate");
        this.sh_InUser = p_rs.GetFieldInt("sh_InUser");
        this.sh_ModDate = p_rs.GetFieldDateTime("sh_ModDate");
        this.sh_ModUser = p_rs.GetFieldInt("sh_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) this.TableCode) + " sh_StatementNo,sh_SiteID,sh_StoreCode,sh_OrderDate,sh_OrderStatus,sh_ConfirmDate,sh_ConfirmStatus,sh_Supplier,sh_SupplierType,sh_InOutDiv,sh_StatementType,sh_ReasonCode,sh_CostTaxAmt,sh_CostTaxFreeAmt,sh_CostVatAmt,sh_Deposit,sh_PriceTaxAmt,sh_PriceTaxFreeAmt,sh_PriceVatAmt,sh_ProfitAmt,sh_DeviceType,sh_OuterConnAuth,sh_AdditionalOpt,sh_Memo,sh_DeliveryNumber,sh_TransmitStatus,sh_TransmitDate,sh_MobieStatementNo,sh_AssignUser,sh_InDate,sh_InUser,sh_ModDate,sh_ModUser) VALUES ( " + string.Format(" {0}", (object) this.sh_StatementNo) + string.Format(",{0}", (object) this.sh_SiteID) + string.Format(",{0},{1},{2}", (object) this.sh_StoreCode, (object) this.sh_OrderDate.GetDateToStrInNull(), (object) this.sh_OrderStatus) + string.Format(",{0},{1}", (object) this.sh_ConfirmDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'"), (object) this.sh_ConfirmStatus) + string.Format(",{0},{1}", (object) this.sh_Supplier, (object) this.sh_SupplierType) + string.Format(",{0},{1},{2}", (object) this.sh_InOutDiv, (object) this.sh_StatementType, (object) this.sh_ReasonCode) + "," + this.sh_CostTaxAmt.FormatTo("{0:0.0000}") + "," + this.sh_CostTaxFreeAmt.FormatTo("{0:0.0000}") + "," + this.sh_CostVatAmt.FormatTo("{0:0.0000}") + "," + this.sh_Deposit.FormatTo("{0:0.0000}") + "," + this.sh_PriceTaxAmt.FormatTo("{0:0.0000}") + "," + this.sh_PriceTaxFreeAmt.FormatTo("{0:0.0000}") + "," + this.sh_PriceVatAmt.FormatTo("{0:0.0000}") + "," + this.sh_ProfitAmt.FormatTo("{0:0.0000}") + string.Format(",{0},{1},{2}", (object) this.sh_DeviceType, (object) this.sh_OuterConnAuth, (object) this.sh_AdditionalOpt) + ",'" + this.sh_Memo + "','" + this.sh_DeliveryNumber + "'" + string.Format(",{0},{1}", (object) this.sh_TransmitStatus, (object) this.sh_TransmitDate.GetDateToStrInNull()) + string.Format(",{0}", (object) this.sh_MobieStatementNo) + string.Format(",{0}", (object) this.sh_AssignUser) + string.Format(",{0},{1}", (object) this.sh_InDate.GetDateToStrInNull(), (object) this.sh_InUser) + string.Format(",{0},{1}", (object) this.sh_ModDate.GetDateToStrInNull(), (object) this.sh_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.sh_StatementNo, (object) this.sh_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TStatementHeader tstatementHeader = this;
      // ISSUE: reference to a compiler-generated method
      tstatementHeader.\u003C\u003En__0();
      if (await tstatementHeader.OleDB.ExecuteAsync(tstatementHeader.InsertQuery()))
        return true;
      tstatementHeader.message = " " + tstatementHeader.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tstatementHeader.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tstatementHeader.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tstatementHeader.sh_StatementNo, (object) tstatementHeader.sh_SiteID) + " 내용 : " + tstatementHeader.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tstatementHeader.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) this.TableCode) + string.Format(" {0}={1}", (object) "sh_StoreCode", (object) this.sh_StoreCode) + string.Format(",{0}={1},{2}={3}", (object) "sh_OrderDate", (object) this.sh_OrderDate.GetDateToStrInNull(), (object) "sh_OrderStatus", (object) this.sh_OrderStatus) + ",sh_ConfirmDate=" + this.sh_ConfirmDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + string.Format(",{0}={1}", (object) "sh_ConfirmStatus", (object) this.sh_ConfirmStatus) + string.Format(",{0}={1},{2}={3}", (object) "sh_Supplier", (object) this.sh_Supplier, (object) "sh_SupplierType", (object) this.sh_SupplierType) + string.Format(",{0}={1},{2}={3},{4}={5}", (object) "sh_InOutDiv", (object) this.sh_InOutDiv, (object) "sh_StatementType", (object) this.sh_StatementType, (object) "sh_ReasonCode", (object) this.sh_ReasonCode) + ",sh_CostTaxAmt=" + this.sh_CostTaxAmt.FormatTo("{0:0.0000}") + ",sh_CostTaxFreeAmt=" + this.sh_CostTaxFreeAmt.FormatTo("{0:0.0000}") + ",sh_CostVatAmt=" + this.sh_CostVatAmt.FormatTo("{0:0.0000}") + ",sh_Deposit=" + this.sh_Deposit.FormatTo("{0:0.0000}") + ",sh_PriceTaxAmt=" + this.sh_PriceTaxAmt.FormatTo("{0:0.0000}") + ",sh_PriceTaxFreeAmt=" + this.sh_PriceTaxFreeAmt.FormatTo("{0:0.0000}") + ",sh_PriceVatAmt=" + this.sh_PriceVatAmt.FormatTo("{0:0.0000}") + ",sh_ProfitAmt=" + this.sh_ProfitAmt.FormatTo("{0:0.0000}") + string.Format(",{0}={1},{2}={3},{4}={5}", (object) "sh_DeviceType", (object) this.sh_DeviceType, (object) "sh_OuterConnAuth", (object) this.sh_OuterConnAuth, (object) "sh_AdditionalOpt", (object) this.sh_AdditionalOpt) + ",sh_Memo='" + this.sh_Memo + "',sh_DeliveryNumber='" + this.sh_DeliveryNumber + "'" + string.Format(",{0}={1},{2}={3}", (object) "sh_TransmitStatus", (object) this.sh_TransmitStatus, (object) "sh_TransmitDate", (object) this.sh_OrderDate.GetDateToStrInNull()) + string.Format(",{0}={1}", (object) "sh_MobieStatementNo", (object) this.sh_MobieStatementNo) + string.Format(",{0}={1}", (object) "sh_AssignUser", (object) this.sh_AssignUser) + string.Format(",{0}={1},{2}={3}", (object) "sh_ModDate", (object) this.sh_ModDate.GetDateToStrInNull(), (object) "sh_ModUser", (object) this.sh_ModUser) + string.Format(" WHERE {0}={1}", (object) "sh_StatementNo", (object) this.sh_StatementNo) + string.Format(" AND {0}={1}", (object) "sh_SiteID", (object) this.sh_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.sh_StatementNo, (object) this.sh_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TStatementHeader tstatementHeader = this;
      // ISSUE: reference to a compiler-generated method
      tstatementHeader.\u003C\u003En__1();
      if (await tstatementHeader.OleDB.ExecuteAsync(tstatementHeader.UpdateQuery()))
        return true;
      tstatementHeader.message = " " + tstatementHeader.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tstatementHeader.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tstatementHeader.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tstatementHeader.sh_StatementNo, (object) tstatementHeader.sh_SiteID) + " 내용 : " + tstatementHeader.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tstatementHeader.message);
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
      stringBuilder.Append(string.Format(" {0}={1}", (object) "sh_StoreCode", (object) this.sh_StoreCode) + string.Format(",{0}={1},{2}={3}", (object) "sh_OrderDate", (object) this.sh_OrderDate.GetDateToStrInNull(), (object) "sh_OrderStatus", (object) this.sh_OrderStatus) + ",sh_ConfirmDate=" + this.sh_ConfirmDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + string.Format(",{0}={1}", (object) "sh_ConfirmStatus", (object) this.sh_ConfirmStatus) + string.Format(",{0}={1},{2}={3}", (object) "sh_Supplier", (object) this.sh_Supplier, (object) "sh_SupplierType", (object) this.sh_SupplierType) + string.Format(",{0}={1},{2}={3},{4}={5}", (object) "sh_InOutDiv", (object) this.sh_InOutDiv, (object) "sh_StatementType", (object) this.sh_StatementType, (object) "sh_ReasonCode", (object) this.sh_ReasonCode) + ",sh_CostTaxAmt=" + this.sh_CostTaxAmt.FormatTo("{0:0.0000}") + ",sh_CostTaxFreeAmt=" + this.sh_CostTaxFreeAmt.FormatTo("{0:0.0000}") + ",sh_CostVatAmt=" + this.sh_CostVatAmt.FormatTo("{0:0.0000}") + ",sh_Deposit=" + this.sh_Deposit.FormatTo("{0:0.0000}") + ",sh_PriceTaxAmt=" + this.sh_PriceTaxAmt.FormatTo("{0:0.0000}") + ",sh_PriceTaxFreeAmt=" + this.sh_PriceTaxFreeAmt.FormatTo("{0:0.0000}") + ",sh_PriceVatAmt=" + this.sh_PriceVatAmt.FormatTo("{0:0.0000}") + ",sh_ProfitAmt=" + this.sh_ProfitAmt.FormatTo("{0:0.0000}") + string.Format(",{0}={1},{2}={3},{4}={5}", (object) "sh_DeviceType", (object) this.sh_DeviceType, (object) "sh_OuterConnAuth", (object) this.sh_OuterConnAuth, (object) "sh_AdditionalOpt", (object) this.sh_AdditionalOpt) + ",sh_Memo='" + this.sh_Memo + "',sh_DeliveryNumber='" + this.sh_DeliveryNumber + "'" + string.Format(",{0}={1},{2}={3}", (object) "sh_TransmitStatus", (object) this.sh_TransmitStatus, (object) "sh_TransmitDate", (object) this.sh_OrderDate.GetDateToStrInNull()) + string.Format(",{0}={1}", (object) "sh_MobieStatementNo", (object) this.sh_MobieStatementNo) + string.Format(",{0}={1}", (object) "sh_AssignUser", (object) this.sh_AssignUser) + string.Format(",{0}={1},{2}={3}", (object) "sh_ModDate", (object) this.sh_ModDate.GetDateToStrInNull(), (object) "sh_ModUser", (object) this.sh_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.sh_StatementNo, (object) this.sh_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TStatementHeader tstatementHeader = this;
      // ISSUE: reference to a compiler-generated method
      tstatementHeader.\u003C\u003En__1();
      if (await tstatementHeader.OleDB.ExecuteAsync(tstatementHeader.UpdateExInsertQuery()))
        return true;
      tstatementHeader.message = " " + tstatementHeader.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tstatementHeader.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tstatementHeader.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tstatementHeader.sh_StatementNo, (object) tstatementHeader.sh_SiteID) + " 내용 : " + tstatementHeader.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tstatementHeader.message);
      return false;
    }

    public string UpdateStatusQuery()
    {
      this.sh_ModDate = new DateTime?(DateTime.Now);
      return string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) this.TableCode) + string.Format(" {0}={1}", (object) "sh_OrderStatus", (object) this.sh_OrderStatus) + string.Format(",{0}={1}", (object) "sh_ConfirmStatus", (object) this.sh_ConfirmStatus) + string.Format(",{0}={1}", (object) "sh_MobieStatementNo", (object) this.sh_MobieStatementNo) + string.Format(",{0}={1}", (object) "sh_AssignUser", (object) this.sh_AssignUser) + string.Format(",{0}={1},{2}={3}", (object) "sh_ModDate", (object) this.sh_ModDate.GetDateToStrInNull(), (object) "sh_ModUser", (object) this.sh_ModUser) + string.Format(" WHERE {0}={1}", (object) "sh_StatementNo", (object) this.sh_StatementNo) + string.Format(" AND {0}={1}", (object) "sh_SiteID", (object) this.sh_SiteID);
    }

    public bool UpdateStatus()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateStatusQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.sh_StatementNo, (object) this.sh_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public async Task<bool> UpdateStatusAsync()
    {
      TStatementHeader tstatementHeader = this;
      // ISSUE: reference to a compiler-generated method
      tstatementHeader.\u003C\u003En__1();
      if (await tstatementHeader.OleDB.ExecuteAsync(tstatementHeader.UpdateStatusQuery()))
        return true;
      tstatementHeader.message = " " + tstatementHeader.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tstatementHeader.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tstatementHeader.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tstatementHeader.sh_StatementNo, (object) tstatementHeader.sh_SiteID) + " 내용 : " + tstatementHeader.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tstatementHeader.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        bool flag = false;
        long num = 0;
        if (hashtable.ContainsKey((object) "sh_SiteID") && Convert.ToInt64(hashtable[(object) "sh_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "sh_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "sh_StatementNo") && Convert.ToInt64(hashtable[(object) "sh_StatementNo"].ToString()) > 0L)
        {
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_StatementNo", hashtable[(object) "sh_StatementNo"]));
          flag = true;
        }
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_SiteID", (object) num));
        if (!flag)
        {
          if (hashtable.ContainsKey((object) "si_StoreCode") && Convert.ToInt32(hashtable[(object) "si_StoreCode"].ToString()) > 0)
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_StoreCode", hashtable[(object) "si_StoreCode"]));
          else if (hashtable.ContainsKey((object) "sh_StoreCode") && Convert.ToInt32(hashtable[(object) "sh_StoreCode"].ToString()) > 0)
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_StoreCode", hashtable[(object) "sh_StoreCode"]));
          else if (hashtable.ContainsKey((object) "si_StoreCode_IN_") && hashtable[(object) "si_StoreCode_IN_"].ToString().Length > 0)
          {
            if (hashtable[(object) "si_StoreCode_IN_"].ToString().Contains(","))
              stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "sh_StoreCode", hashtable[(object) "si_StoreCode_IN_"]));
            else
              stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_StoreCode", hashtable[(object) "si_StoreCode_IN_"]));
          }
          else if (hashtable.ContainsKey((object) "sh_StoreCode_IN_") && hashtable[(object) "sh_StoreCode_IN_"].ToString().Length > 0)
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "sh_StoreCode", hashtable[(object) "sh_StoreCode_IN_"]));
          else if (hashtable.ContainsKey((object) "_STORE_AUTHS_") && hashtable[(object) "_STORE_AUTHS_"].ToString().Length > 0)
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "sh_StoreCode", hashtable[(object) "_STORE_AUTHS_"]));
          if (hashtable.ContainsKey((object) "sh_StatementType") && Convert.ToInt32(hashtable[(object) "sh_StatementType"].ToString()) > 0)
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_StatementType", hashtable[(object) "sh_StatementType"]));
          else if (hashtable.ContainsKey((object) "sh_StatementType_IN_") && hashtable[(object) "sh_StatementType_IN_"].ToString().Length > 0)
          {
            if (hashtable[(object) "sh_StatementType_IN_"].ToString().Contains(","))
              stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "sh_StatementType", hashtable[(object) "sh_StatementType_IN_"]));
            else
              stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_StatementType", hashtable[(object) "sh_StatementType_IN_"]));
          }
          else if (hashtable.ContainsKey((object) "_IsStatementPayment_"))
          {
            if (Convert.ToBoolean(hashtable[(object) "_IsStatementPayment_"].ToString()))
              stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_StatementType", (object) 21));
            else
              stringBuilder.Append(string.Format(" AND {0}!={1}", (object) "sh_StatementType", (object) 21));
          }
          if (hashtable.ContainsKey((object) "sh_OrderDate"))
          {
            stringBuilder.Append(" AND sh_OrderDate >='" + new DateTime?((DateTime) hashtable[(object) "sh_OrderDate"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
            stringBuilder.Append(" AND sh_OrderDate <='" + new DateTime?((DateTime) hashtable[(object) "sh_OrderDate"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
          }
          if (hashtable.ContainsKey((object) "sh_OrderDate_BEGIN_") && hashtable.ContainsKey((object) "sh_OrderDate_END_"))
          {
            stringBuilder.Append(" AND sh_OrderDate >='" + new DateTime?((DateTime) hashtable[(object) "sh_OrderDate_BEGIN_"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
            stringBuilder.Append(" AND sh_OrderDate <='" + new DateTime?((DateTime) hashtable[(object) "sh_OrderDate_END_"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
          }
          if (hashtable.ContainsKey((object) "sh_ConfirmDate"))
          {
            stringBuilder.Append(" AND sh_ConfirmDate >='" + new DateTime?((DateTime) hashtable[(object) "sh_ConfirmDate"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
            stringBuilder.Append(" AND sh_ConfirmDate <='" + new DateTime?((DateTime) hashtable[(object) "sh_ConfirmDate"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
          }
          if (hashtable.ContainsKey((object) "sh_ConfirmDate_BEGIN_") && hashtable.ContainsKey((object) "sh_ConfirmDate_END_"))
          {
            stringBuilder.Append(" AND sh_ConfirmDate >='" + new DateTime?((DateTime) hashtable[(object) "sh_ConfirmDate_BEGIN_"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
            stringBuilder.Append(" AND sh_ConfirmDate <='" + new DateTime?((DateTime) hashtable[(object) "sh_ConfirmDate_END_"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
          }
          if (hashtable.ContainsKey((object) "_IsStatementOrder_") && Convert.ToBoolean(hashtable[(object) "_IsStatementOrder_"].ToString()))
          {
            if (hashtable.ContainsKey((object) "sh_OrderStatus") && Convert.ToInt32(hashtable[(object) "sh_OrderStatus"].ToString()) > 0)
              stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_OrderStatus", hashtable[(object) "sh_OrderStatus"]));
            else
              stringBuilder.Append(string.Format(" AND {0}<{1}", (object) "sh_OrderStatus", (object) 4));
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_OrderStatus", (object) 2));
          }
          else
          {
            if (hashtable.ContainsKey((object) "_IsStatementPayment_") && Convert.ToBoolean(hashtable[(object) "_IsStatementPayment_"].ToString()))
            {
              if (hashtable.ContainsKey((object) "sh_OrderStatus") && Convert.ToInt32(hashtable[(object) "sh_OrderStatus"].ToString()) > 0)
                stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_OrderStatus", hashtable[(object) "sh_OrderStatus"]));
            }
            else
            {
              stringBuilder.Append(string.Format(" AND {0}>={1}", (object) "sh_OrderStatus", (object) 3));
              stringBuilder.Append(string.Format(" AND {0}<={1}", (object) "sh_OrderStatus", (object) 4));
            }
            if (hashtable.ContainsKey((object) "sh_ConfirmStatus"))
            {
              if (Convert.ToInt32(hashtable[(object) "sh_ConfirmStatus"].ToString()) == 0)
              {
                stringBuilder.Append(string.Format(" AND {0}>={1}", (object) "sh_ConfirmStatus", (object) 1));
                stringBuilder.Append(string.Format(" AND {0}<{1}", (object) "sh_ConfirmStatus", (object) 3));
              }
              else
                stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_ConfirmStatus", hashtable[(object) "sh_ConfirmStatus"]));
            }
          }
          if (hashtable.ContainsKey((object) "sh_InOutDiv") && Convert.ToInt32(hashtable[(object) "sh_InOutDiv"].ToString()) != 0)
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_InOutDiv", hashtable[(object) "sh_InOutDiv"]));
          if (hashtable.ContainsKey((object) "su_SupplierType") && Convert.ToInt32(hashtable[(object) "su_SupplierType"].ToString()) > 0)
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_SupplierType", hashtable[(object) "su_SupplierType"]));
          else if (hashtable.ContainsKey((object) "sh_SupplierType") && Convert.ToInt32(hashtable[(object) "sh_SupplierType"].ToString()) > 0)
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_SupplierType", hashtable[(object) "sh_SupplierType"]));
          else if (hashtable.ContainsKey((object) "su_SupplierType_IN_") && hashtable[(object) "su_SupplierType_IN_"].ToString().Length > 0)
          {
            if (hashtable[(object) "su_SupplierType_IN_"].ToString().Contains(","))
              stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "sh_SupplierType", hashtable[(object) "su_SupplierType_IN_"]));
            else
              stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_SupplierType", hashtable[(object) "su_SupplierType_IN_"]));
          }
          else if (hashtable.ContainsKey((object) "sh_SupplierType_IN_") && hashtable[(object) "sh_SupplierType_IN_"].ToString().Length > 0)
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "sh_SupplierType", hashtable[(object) "sh_SupplierType_IN_"]));
          if (hashtable.ContainsKey((object) "su_Supplier") && Convert.ToInt32(hashtable[(object) "su_Supplier"].ToString()) > 0)
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_Supplier", hashtable[(object) "su_Supplier"]));
          else if (hashtable.ContainsKey((object) "sh_Supplier") && Convert.ToInt32(hashtable[(object) "sh_Supplier"].ToString()) > 0)
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_Supplier", hashtable[(object) "sh_Supplier"]));
          else if (hashtable.ContainsKey((object) "su_Supplier_IN_") && hashtable[(object) "su_Supplier_IN_"].ToString().Length > 0)
          {
            if (hashtable[(object) "su_Supplier_IN_"].ToString().Contains(","))
              stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "sh_Supplier", hashtable[(object) "su_Supplier_IN_"]));
            else
              stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_Supplier", hashtable[(object) "su_Supplier_IN_"]));
          }
          else if (hashtable.ContainsKey((object) "sh_Supplier_IN_") && hashtable[(object) "sh_Supplier_IN_"].ToString().Length > 0)
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "sh_Supplier", hashtable[(object) "sh_Supplier_IN_"]));
          else if (hashtable.ContainsKey((object) "_SUPPLIER_AUTHS_") && hashtable[(object) "_SUPPLIER_AUTHS_"].ToString().Length > 0)
          {
            if (hashtable[(object) "su_Supplier_IN_"].ToString().Contains(","))
              stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "sh_Supplier", hashtable[(object) "su_Supplier_IN_"]));
            else
              stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_Supplier", hashtable[(object) "su_Supplier_IN_"]));
          }
          if (hashtable.ContainsKey((object) "sh_ReasonCode") && Convert.ToInt32(hashtable[(object) "sh_ReasonCode"].ToString()) > 0)
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_ReasonCode", hashtable[(object) "sh_ReasonCode"]));
          if (hashtable.ContainsKey((object) "sh_DeviceType") && Convert.ToInt32(hashtable[(object) "sh_DeviceType"].ToString()) > 0)
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_DeviceType", hashtable[(object) "sh_DeviceType"]));
          if (hashtable.ContainsKey((object) "sh_DeviceType_IS_NOT_EQUALS_") && Convert.ToInt32(hashtable[(object) "sh_DeviceType_IS_NOT_EQUALS_"].ToString()) > 0)
            stringBuilder.Append(string.Format(" AND {0}!={1}", (object) "sh_DeviceType", hashtable[(object) "sh_DeviceType_IS_NOT_EQUALS_"]));
          if (hashtable.ContainsKey((object) "emp_Code") && Convert.ToInt32(hashtable[(object) "emp_Code"].ToString()) > 0)
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_InUser", hashtable[(object) "emp_Code"]));
          if (hashtable.ContainsKey((object) "sh_InUser") && Convert.ToInt32(hashtable[(object) "sh_InUser"].ToString()) > 0)
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_InUser", hashtable[(object) "sh_InUser"]));
          if (hashtable.ContainsKey((object) "sh_AssignUser") && Convert.ToInt32(hashtable[(object) "sh_AssignUser"].ToString()) > 0)
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sh_AssignUser", hashtable[(object) "sh_AssignUser"]));
          if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
          {
            stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "sh_Memo", hashtable[(object) "_KEY_WORD_"]));
            stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "sh_DeliveryNumber", hashtable[(object) "_KEY_WORD_"]));
            stringBuilder.Append(")");
          }
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
        stringBuilder.Append(" SELECT  sh_StatementNo,sh_SiteID,sh_StoreCode,sh_OrderDate,sh_OrderStatus,sh_ConfirmDate,sh_ConfirmStatus,sh_Supplier,sh_SupplierType,sh_InOutDiv,sh_StatementType,sh_ReasonCode,sh_CostTaxAmt,sh_CostTaxFreeAmt,sh_CostVatAmt,sh_Deposit,sh_PriceTaxAmt,sh_PriceTaxFreeAmt,sh_PriceVatAmt,sh_ProfitAmt,sh_DeviceType,sh_OuterConnAuth,sh_AdditionalOpt,sh_Memo,sh_DeliveryNumber,sh_TransmitStatus,sh_TransmitDate,sh_MobieStatementNo,sh_AssignUser,sh_InDate,sh_InUser,sh_ModDate,sh_ModUser");
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
