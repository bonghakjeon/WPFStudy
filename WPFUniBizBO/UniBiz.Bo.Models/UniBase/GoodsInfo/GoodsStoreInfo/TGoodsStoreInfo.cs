// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsStoreInfo.TGoodsStoreInfo
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

namespace UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsStoreInfo
{
  public class TGoodsStoreInfo : UbModelBase<TGoodsStoreInfo>
  {
    private int _gdsh_StoreCode;
    private long _gdsh_GoodsCode;
    private long _gdsh_SiteID;
    private int _gdsh_DeliveryDiv;
    private double _gdsh_MinOrderUnit;
    private string _gdsh_MultiSuplierYn;
    private int _gdsh_OrderType;
    private int _gdsh_AutoOrderMonth;
    private int _gdsh_OrderWeekDay;
    private int _gdsh_AutoOrderMonths;
    private int _gdsh_AutoOrderDays;
    private int _gdsh_AutoOrderType;
    private double _gdsh_AutoSafeQty;
    private double _gdsh_AutoMinQty;
    private double _gdsh_AutoMidQty;
    private double _gdsh_AutoMaxQty;
    private double _gdsh_StorageStockQty;
    private DateTime? _gdsh_OrderEndDate;
    private DateTime? _gdsh_SaleEndDate;
    private int _gdsh_AddProperty;
    private DateTime? _gdsh_InDate;
    private int _gdsh_InUser;
    private DateTime? _gdsh_ModDate;
    private int _gdsh_ModUser;

    public override object _Key => (object) new object[2]
    {
      (object) this.gdsh_StoreCode,
      (object) this.gdsh_GoodsCode
    };

    public int gdsh_StoreCode
    {
      get => this._gdsh_StoreCode;
      set
      {
        this._gdsh_StoreCode = value;
        this.Changed(nameof (gdsh_StoreCode));
      }
    }

    public long gdsh_GoodsCode
    {
      get => this._gdsh_GoodsCode;
      set
      {
        this._gdsh_GoodsCode = value;
        this.Changed(nameof (gdsh_GoodsCode));
      }
    }

    public long gdsh_SiteID
    {
      get => this._gdsh_SiteID;
      set
      {
        this._gdsh_SiteID = value;
        this.Changed(nameof (gdsh_SiteID));
      }
    }

    public int gdsh_DeliveryDiv
    {
      get => this._gdsh_DeliveryDiv;
      set
      {
        this._gdsh_DeliveryDiv = value;
        this.Changed(nameof (gdsh_DeliveryDiv));
      }
    }

    public string gdsh_DeliveryDivDesc => this.gdsh_DeliveryDiv <= 0 ? string.Empty : Enum2StrConverter.ToCommonCodeTypeMemo((long) this.gdsh_DeliveryDiv, EnumCommonCodeType.InnerDeliveryDiv, this.gdsh_DeliveryDiv);

    public double gdsh_MinOrderUnit
    {
      get => this._gdsh_MinOrderUnit;
      set
      {
        this._gdsh_MinOrderUnit = value;
        this.Changed(nameof (gdsh_MinOrderUnit));
      }
    }

    public string gdsh_MultiSuplierYn
    {
      get => this._gdsh_MultiSuplierYn;
      set
      {
        this._gdsh_MultiSuplierYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (gdsh_MultiSuplierYn));
        this.Changed("gdsh_IsMultiSuplierYn");
        this.Changed("gdsh_MultiSuplierYnDesc");
      }
    }

    public bool gdsh_IsMultiSuplierYn => "Y".Equals(this.gdsh_MultiSuplierYn);

    public string gdsh_MultiSuplierYnDesc => !"Y".Equals(this.gdsh_MultiSuplierYn) ? "미사용" : "사용";

    public int gdsh_OrderType
    {
      get => this._gdsh_OrderType;
      set
      {
        this._gdsh_OrderType = value;
        this.Changed(nameof (gdsh_OrderType));
      }
    }

    public int gdsh_AutoOrderMonth
    {
      get => this._gdsh_AutoOrderMonth;
      set
      {
        this._gdsh_AutoOrderMonth = value;
        this.Changed(nameof (gdsh_AutoOrderMonth));
      }
    }

    public int gdsh_OrderWeekDay
    {
      get => this._gdsh_OrderWeekDay;
      set
      {
        this._gdsh_OrderWeekDay = value;
        this.Changed(nameof (gdsh_OrderWeekDay));
      }
    }

    public int gdsh_AutoOrderMonths
    {
      get => this._gdsh_AutoOrderMonths;
      set
      {
        this._gdsh_AutoOrderMonths = value;
        this.Changed(nameof (gdsh_AutoOrderMonths));
      }
    }

    public int gdsh_AutoOrderDays
    {
      get => this._gdsh_AutoOrderDays;
      set
      {
        this._gdsh_AutoOrderDays = value;
        this.Changed(nameof (gdsh_AutoOrderDays));
      }
    }

    public int gdsh_AutoOrderType
    {
      get => this._gdsh_AutoOrderType;
      set
      {
        this._gdsh_AutoOrderType = value;
        this.Changed(nameof (gdsh_AutoOrderType));
      }
    }

    public double gdsh_AutoSafeQty
    {
      get => this._gdsh_AutoSafeQty;
      set
      {
        this._gdsh_AutoSafeQty = value;
        this.Changed(nameof (gdsh_AutoSafeQty));
      }
    }

    public double gdsh_AutoMinQty
    {
      get => this._gdsh_AutoMinQty;
      set
      {
        this._gdsh_AutoMinQty = value;
        this.Changed(nameof (gdsh_AutoMinQty));
      }
    }

    public double gdsh_AutoMidQty
    {
      get => this._gdsh_AutoMidQty;
      set
      {
        this._gdsh_AutoMidQty = value;
        this.Changed(nameof (gdsh_AutoMidQty));
      }
    }

    public double gdsh_AutoMaxQty
    {
      get => this._gdsh_AutoMaxQty;
      set
      {
        this._gdsh_AutoMaxQty = value;
        this.Changed(nameof (gdsh_AutoMaxQty));
      }
    }

    public double gdsh_StorageStockQty
    {
      get => this._gdsh_StorageStockQty;
      set
      {
        this._gdsh_StorageStockQty = value;
        this.Changed(nameof (gdsh_StorageStockQty));
      }
    }

    public DateTime? gdsh_OrderEndDate
    {
      get => this._gdsh_OrderEndDate;
      set
      {
        this._gdsh_OrderEndDate = value;
        this.Changed(nameof (gdsh_OrderEndDate));
      }
    }

    public DateTime? gdsh_SaleEndDate
    {
      get => this._gdsh_SaleEndDate;
      set
      {
        this._gdsh_SaleEndDate = value;
        this.Changed(nameof (gdsh_SaleEndDate));
      }
    }

    public int gdsh_AddProperty
    {
      get => this._gdsh_AddProperty;
      set
      {
        this._gdsh_AddProperty = value;
        this.Changed(nameof (gdsh_AddProperty));
      }
    }

    public DateTime? gdsh_InDate
    {
      get => this._gdsh_InDate;
      set
      {
        this._gdsh_InDate = value;
        this.Changed(nameof (gdsh_InDate));
      }
    }

    public int gdsh_InUser
    {
      get => this._gdsh_InUser;
      set
      {
        this._gdsh_InUser = value;
        this.Changed(nameof (gdsh_InUser));
      }
    }

    public DateTime? gdsh_ModDate
    {
      get => this._gdsh_ModDate;
      set
      {
        this._gdsh_ModDate = value;
        this.Changed(nameof (gdsh_ModDate));
      }
    }

    public int gdsh_ModUser
    {
      get => this._gdsh_ModUser;
      set
      {
        this._gdsh_ModUser = value;
        this.Changed(nameof (gdsh_ModUser));
      }
    }

    public TGoodsStoreInfo() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("gdsh_StoreCode", new TTableColumn()
      {
        tc_orgin_name = "gdsh_StoreCode",
        tc_trans_name = "지점코드"
      });
      columnInfo.Add("gdsh_GoodsCode", new TTableColumn()
      {
        tc_orgin_name = "gdsh_GoodsCode",
        tc_trans_name = "상품코드"
      });
      columnInfo.Add("gdsh_SiteID", new TTableColumn()
      {
        tc_orgin_name = "gdsh_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("gdsh_DeliveryDiv", new TTableColumn()
      {
        tc_orgin_name = "gdsh_DeliveryDiv",
        tc_trans_name = "배송 구분",
        tc_comm_code = 60
      });
      columnInfo.Add("gdsh_MinOrderUnit", new TTableColumn()
      {
        tc_orgin_name = "gdsh_MinOrderUnit",
        tc_trans_name = "최소 발주량"
      });
      columnInfo.Add("gdsh_MultiSuplierYn", new TTableColumn()
      {
        tc_orgin_name = "gdsh_MultiSuplierYn",
        tc_trans_name = "복수거래처 여부"
      });
      columnInfo.Add("gdsh_OrderType", new TTableColumn()
      {
        tc_orgin_name = "gdsh_OrderType",
        tc_trans_name = "발주유형"
      });
      columnInfo.Add("gdsh_AutoOrderMonth", new TTableColumn()
      {
        tc_orgin_name = "gdsh_AutoOrderMonth",
        tc_trans_name = "자동발주가능년월"
      });
      columnInfo.Add("gdsh_OrderWeekDay", new TTableColumn()
      {
        tc_orgin_name = "gdsh_OrderWeekDay",
        tc_trans_name = "주문가능요일"
      });
      columnInfo.Add("gdsh_AutoOrderMonths", new TTableColumn()
      {
        tc_orgin_name = "gdsh_AutoOrderMonths",
        tc_trans_name = "개월수"
      });
      columnInfo.Add("gdsh_AutoOrderDays", new TTableColumn()
      {
        tc_orgin_name = "gdsh_AutoOrderDays",
        tc_trans_name = "판매일수"
      });
      columnInfo.Add("gdsh_AutoOrderType", new TTableColumn()
      {
        tc_orgin_name = "gdsh_AutoOrderType",
        tc_trans_name = "타입구분"
      });
      columnInfo.Add("gdsh_AutoSafeQty", new TTableColumn()
      {
        tc_orgin_name = "gdsh_AutoSafeQty",
        tc_trans_name = "안전재고량"
      });
      columnInfo.Add("gdsh_AutoMinQty", new TTableColumn()
      {
        tc_orgin_name = "gdsh_AutoMinQty",
        tc_trans_name = "최소재고발주량"
      });
      columnInfo.Add("gdsh_AutoMidQty", new TTableColumn()
      {
        tc_orgin_name = "gdsh_AutoMidQty",
        tc_trans_name = "중간재고발주량"
      });
      columnInfo.Add("gdsh_AutoMaxQty", new TTableColumn()
      {
        tc_orgin_name = "gdsh_AutoMaxQty",
        tc_trans_name = "최대재고발주량"
      });
      columnInfo.Add("gdsh_OrderEndDate", new TTableColumn()
      {
        tc_orgin_name = "gdsh_OrderEndDate",
        tc_trans_name = "발주중지"
      });
      columnInfo.Add("gdsh_SaleEndDate", new TTableColumn()
      {
        tc_orgin_name = "gdsh_SaleEndDate",
        tc_trans_name = "판매중지"
      });
      columnInfo.Add("gdsh_StorageStockQty", new TTableColumn()
      {
        tc_orgin_name = "gdsh_StorageStockQty",
        tc_trans_name = "창고 적정 재고 유지량"
      });
      columnInfo.Add("gdsh_InDate", new TTableColumn()
      {
        tc_orgin_name = "gdsh_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("gdsh_InUser", new TTableColumn()
      {
        tc_orgin_name = "gdsh_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("gdsh_ModDate", new TTableColumn()
      {
        tc_orgin_name = "gdsh_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("gdsh_ModUser", new TTableColumn()
      {
        tc_orgin_name = "gdsh_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.GoodsStoreInfo;
      this.gdsh_StoreCode = 0;
      this.gdsh_GoodsCode = 0L;
      this.gdsh_SiteID = 0L;
      this.gdsh_DeliveryDiv = 0;
      this.gdsh_MinOrderUnit = 0.0;
      this.gdsh_MultiSuplierYn = "Y";
      this.gdsh_OrderType = this.gdsh_AutoOrderMonth = this.gdsh_OrderWeekDay = this.gdsh_AutoOrderMonths = this.gdsh_AutoOrderDays = this.gdsh_AutoOrderType = 0;
      this.gdsh_AutoSafeQty = this.gdsh_AutoMinQty = this.gdsh_AutoMidQty = this.gdsh_AutoMaxQty = 0.0;
      this.gdsh_StorageStockQty = 0.0;
      this.gdsh_OrderEndDate = new DateTime?();
      this.gdsh_SaleEndDate = new DateTime?();
      this.gdsh_AddProperty = 0;
      this.gdsh_InDate = new DateTime?();
      this.gdsh_InUser = 0;
      this.gdsh_ModDate = new DateTime?();
      this.gdsh_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TGoodsStoreInfo();

    public override object Clone()
    {
      TGoodsStoreInfo tgoodsStoreInfo = base.Clone() as TGoodsStoreInfo;
      tgoodsStoreInfo.gdsh_StoreCode = this.gdsh_StoreCode;
      tgoodsStoreInfo.gdsh_GoodsCode = this.gdsh_GoodsCode;
      tgoodsStoreInfo.gdsh_SiteID = this.gdsh_SiteID;
      tgoodsStoreInfo.gdsh_DeliveryDiv = this.gdsh_DeliveryDiv;
      tgoodsStoreInfo.gdsh_MinOrderUnit = this.gdsh_MinOrderUnit;
      tgoodsStoreInfo.gdsh_MultiSuplierYn = this.gdsh_MultiSuplierYn;
      tgoodsStoreInfo.gdsh_OrderType = this.gdsh_OrderType;
      tgoodsStoreInfo.gdsh_AutoOrderMonth = this.gdsh_AutoOrderMonth;
      tgoodsStoreInfo.gdsh_OrderWeekDay = this.gdsh_OrderWeekDay;
      tgoodsStoreInfo.gdsh_AutoOrderMonths = this.gdsh_AutoOrderMonths;
      tgoodsStoreInfo.gdsh_AutoOrderDays = this.gdsh_AutoOrderDays;
      tgoodsStoreInfo.gdsh_AutoOrderType = this.gdsh_AutoOrderType;
      tgoodsStoreInfo.gdsh_AutoSafeQty = this.gdsh_AutoSafeQty;
      tgoodsStoreInfo.gdsh_AutoMinQty = this.gdsh_AutoMinQty;
      tgoodsStoreInfo.gdsh_AutoMidQty = this.gdsh_AutoMidQty;
      tgoodsStoreInfo.gdsh_AutoMaxQty = this.gdsh_AutoMaxQty;
      tgoodsStoreInfo.gdsh_StorageStockQty = this.gdsh_StorageStockQty;
      tgoodsStoreInfo.gdsh_OrderEndDate = this.gdsh_OrderEndDate;
      tgoodsStoreInfo.gdsh_SaleEndDate = this.gdsh_SaleEndDate;
      tgoodsStoreInfo.gdsh_AddProperty = this.gdsh_AddProperty;
      tgoodsStoreInfo.gdsh_InDate = this.gdsh_InDate;
      tgoodsStoreInfo.gdsh_InUser = this.gdsh_InUser;
      tgoodsStoreInfo.gdsh_ModDate = this.gdsh_ModDate;
      tgoodsStoreInfo.gdsh_ModUser = this.gdsh_ModUser;
      return (object) tgoodsStoreInfo;
    }

    public void PutData(TGoodsStoreInfo pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.gdsh_StoreCode = pSource.gdsh_StoreCode;
      this.gdsh_GoodsCode = pSource.gdsh_GoodsCode;
      this.gdsh_SiteID = pSource.gdsh_SiteID;
      this.gdsh_DeliveryDiv = pSource.gdsh_DeliveryDiv;
      this.gdsh_MinOrderUnit = pSource.gdsh_MinOrderUnit;
      this.gdsh_MultiSuplierYn = pSource.gdsh_MultiSuplierYn;
      this.gdsh_OrderType = pSource.gdsh_OrderType;
      this.gdsh_AutoOrderMonth = pSource.gdsh_AutoOrderMonth;
      this.gdsh_OrderWeekDay = pSource.gdsh_OrderWeekDay;
      this.gdsh_AutoOrderMonths = pSource.gdsh_AutoOrderMonths;
      this.gdsh_AutoOrderDays = pSource.gdsh_AutoOrderDays;
      this.gdsh_AutoOrderType = pSource.gdsh_AutoOrderType;
      this.gdsh_AutoSafeQty = pSource.gdsh_AutoSafeQty;
      this.gdsh_AutoMinQty = pSource.gdsh_AutoMinQty;
      this.gdsh_AutoMidQty = pSource.gdsh_AutoMidQty;
      this.gdsh_AutoMaxQty = pSource.gdsh_AutoMaxQty;
      this.gdsh_StorageStockQty = pSource.gdsh_StorageStockQty;
      this.gdsh_OrderEndDate = pSource.gdsh_OrderEndDate;
      this.gdsh_SaleEndDate = pSource.gdsh_SaleEndDate;
      this.gdsh_AddProperty = pSource.gdsh_AddProperty;
      this.gdsh_InDate = pSource.gdsh_InDate;
      this.gdsh_InUser = pSource.gdsh_InUser;
      this.gdsh_ModDate = pSource.gdsh_ModDate;
      this.gdsh_ModUser = pSource.gdsh_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.gdsh_StoreCode = p_rs.GetFieldInt("gdsh_StoreCode");
        this.gdsh_GoodsCode = p_rs.GetFieldLong("gdsh_GoodsCode");
        if (this.gdsh_GoodsCode == 0L)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.gdsh_SiteID = p_rs.GetFieldLong("gdsh_SiteID");
        this.gdsh_DeliveryDiv = p_rs.GetFieldInt("gdsh_DeliveryDiv");
        this.gdsh_MinOrderUnit = p_rs.GetFieldDouble("gdsh_MinOrderUnit");
        this.gdsh_MultiSuplierYn = p_rs.GetFieldString("gdsh_MultiSuplierYn");
        this.gdsh_OrderType = p_rs.GetFieldInt("gdsh_OrderType");
        this.gdsh_AutoOrderMonth = p_rs.GetFieldInt("gdsh_AutoOrderMonth");
        this.gdsh_OrderWeekDay = p_rs.GetFieldInt("gdsh_OrderWeekDay");
        this.gdsh_AutoOrderMonths = p_rs.GetFieldInt("gdsh_AutoOrderMonths");
        this.gdsh_AutoOrderDays = p_rs.GetFieldInt("gdsh_AutoOrderDays");
        this.gdsh_AutoOrderType = p_rs.GetFieldInt("gdsh_AutoOrderType");
        this.gdsh_AutoSafeQty = p_rs.GetFieldDouble("gdsh_AutoSafeQty");
        this.gdsh_AutoMinQty = p_rs.GetFieldDouble("gdsh_AutoMinQty");
        this.gdsh_AutoMidQty = p_rs.GetFieldDouble("gdsh_AutoMidQty");
        this.gdsh_AutoMaxQty = p_rs.GetFieldDouble("gdsh_AutoMaxQty");
        this.gdsh_StorageStockQty = p_rs.GetFieldDouble("gdsh_StorageStockQty");
        this.gdsh_OrderEndDate = p_rs.GetFieldDateTime("gdsh_OrderEndDate");
        this.gdsh_SaleEndDate = p_rs.GetFieldDateTime("gdsh_SaleEndDate");
        this.gdsh_AddProperty = p_rs.GetFieldInt("gdsh_AddProperty");
        this.gdsh_InDate = p_rs.GetFieldDateTime("gdsh_InDate");
        this.gdsh_InUser = p_rs.GetFieldInt("gdsh_InUser");
        this.gdsh_ModDate = p_rs.GetFieldDateTime("gdsh_ModDate");
        this.gdsh_ModUser = p_rs.GetFieldInt("gdsh_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " gdsh_StoreCode,gdsh_GoodsCode,gdsh_SiteID,gdsh_DeliveryDiv,gdsh_MinOrderUnit,gdsh_MultiSuplierYn,gdsh_OrderType,gdsh_AutoOrderMonth,gdsh_OrderWeekDay,gdsh_AutoOrderMonths,gdsh_AutoOrderDays,gdsh_AutoOrderType,gdsh_AutoSafeQty,gdsh_AutoMinQty,gdsh_AutoMidQty,gdsh_AutoMaxQty,gdsh_StorageStockQty,gdsh_OrderEndDate,gdsh_SaleEndDate,gdsh_AddProperty,gdsh_InDate,gdsh_InUser,gdsh_ModDate,gdsh_ModUser) VALUES ( " + string.Format(" {0},{1}", (object) this.gdsh_StoreCode, (object) this.gdsh_GoodsCode) + string.Format(",{0}", (object) this.gdsh_SiteID) + string.Format(",{0},{1},'{2}'", (object) this.gdsh_DeliveryDiv, (object) this.gdsh_MinOrderUnit, (object) this.gdsh_MultiSuplierYn) + string.Format(",{0},{1},{2}", (object) this.gdsh_OrderType, (object) this.gdsh_AutoOrderMonth, (object) this.gdsh_OrderWeekDay) + string.Format(",{0},{1},{2}", (object) this.gdsh_AutoOrderMonths, (object) this.gdsh_AutoOrderDays, (object) this.gdsh_AutoOrderType) + "," + this.gdsh_AutoSafeQty.FormatTo("{0:0.0000}") + "," + this.gdsh_AutoMinQty.FormatTo("{0:0.0000}") + "," + this.gdsh_AutoMidQty.FormatTo("{0:0.0000}") + "," + this.gdsh_AutoMaxQty.FormatTo("{0:0.0000}") + "," + this.gdsh_StorageStockQty.FormatTo("{0:0.0000}") + "," + this.gdsh_OrderEndDate.GetDateToStrInNull() + "," + this.gdsh_SaleEndDate.GetDateToStrInNull() + string.Format(",{0}", (object) this.gdsh_AddProperty) + string.Format(",{0},{1}", (object) this.gdsh_InDate.GetDateToStrInNull(), (object) this.gdsh_InUser) + string.Format(",{0},{1}", (object) this.gdsh_ModDate.GetDateToStrInNull(), (object) this.gdsh_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.gdsh_StoreCode, (object) this.gdsh_GoodsCode, (object) this.gdsh_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TGoodsStoreInfo tgoodsStoreInfo = this;
      // ISSUE: reference to a compiler-generated method
      tgoodsStoreInfo.\u003C\u003En__0();
      if (await tgoodsStoreInfo.OleDB.ExecuteAsync(tgoodsStoreInfo.InsertQuery()))
        return true;
      tgoodsStoreInfo.message = " " + tgoodsStoreInfo.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tgoodsStoreInfo.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tgoodsStoreInfo.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tgoodsStoreInfo.gdsh_StoreCode, (object) tgoodsStoreInfo.gdsh_GoodsCode, (object) tgoodsStoreInfo.gdsh_SiteID) + " 내용 : " + tgoodsStoreInfo.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tgoodsStoreInfo.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + string.Format(" {0}={1},{2}={3},{4}='{5}'", (object) "gdsh_DeliveryDiv", (object) this.gdsh_DeliveryDiv, (object) "gdsh_MinOrderUnit", (object) this.gdsh_MinOrderUnit, (object) "gdsh_MultiSuplierYn", (object) this.gdsh_MultiSuplierYn) + string.Format(",{0}={1},{2}={3},{4}={5}", (object) "gdsh_OrderType", (object) this.gdsh_OrderType, (object) "gdsh_AutoOrderMonth", (object) this.gdsh_AutoOrderMonth, (object) "gdsh_OrderWeekDay", (object) this.gdsh_OrderWeekDay) + ",gdsh_AutoOrderMonths,gdsh_AutoOrderDays,gdsh_AutoOrderType,gdsh_AutoSafeQty=" + this.gdsh_AutoSafeQty.FormatTo("{0:0.0000}") + ",gdsh_AutoMinQty=" + this.gdsh_AutoMinQty.FormatTo("{0:0.0000}") + ",gdsh_AutoMidQty=" + this.gdsh_AutoMidQty.FormatTo("{0:0.0000}") + ",gdsh_AutoMaxQty=" + this.gdsh_AutoMaxQty.FormatTo("{0:0.0000}") + ",gdsh_StorageStockQty,gdsh_OrderEndDate=" + this.gdsh_OrderEndDate.GetDateToStrInNull() + ",gdsh_SaleEndDate=" + this.gdsh_SaleEndDate.GetDateToStrInNull() + string.Format(",{0}={1}", (object) "gdsh_AddProperty", (object) this.gdsh_AddProperty) + string.Format(",{0}={1},{2}={3}", (object) "gdsh_ModDate", (object) this.gdsh_ModDate.GetDateToStrInNull(), (object) "gdsh_ModUser", (object) this.gdsh_ModUser) + string.Format(" WHERE {0}={1}", (object) "gdsh_StoreCode", (object) this.gdsh_StoreCode) + string.Format(" AND {0}={1}", (object) "gdsh_GoodsCode", (object) this.gdsh_GoodsCode) + string.Format(" AND {0}={1}", (object) "gdsh_SiteID", (object) this.gdsh_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.gdsh_StoreCode, (object) this.gdsh_GoodsCode, (object) this.gdsh_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TGoodsStoreInfo tgoodsStoreInfo = this;
      // ISSUE: reference to a compiler-generated method
      tgoodsStoreInfo.\u003C\u003En__1();
      if (await tgoodsStoreInfo.OleDB.ExecuteAsync(tgoodsStoreInfo.UpdateQuery()))
        return true;
      tgoodsStoreInfo.message = " " + tgoodsStoreInfo.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tgoodsStoreInfo.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tgoodsStoreInfo.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tgoodsStoreInfo.gdsh_StoreCode, (object) tgoodsStoreInfo.gdsh_GoodsCode, (object) tgoodsStoreInfo.gdsh_SiteID) + " 내용 : " + tgoodsStoreInfo.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tgoodsStoreInfo.message);
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
      stringBuilder.Append(string.Format(" {0}={1},{2}={3},{4}='{5}'", (object) "gdsh_DeliveryDiv", (object) this.gdsh_DeliveryDiv, (object) "gdsh_MinOrderUnit", (object) this.gdsh_MinOrderUnit, (object) "gdsh_MultiSuplierYn", (object) this.gdsh_MultiSuplierYn) + string.Format(",{0}={1},{2}={3},{4}={5}", (object) "gdsh_OrderType", (object) this.gdsh_OrderType, (object) "gdsh_AutoOrderMonth", (object) this.gdsh_AutoOrderMonth, (object) "gdsh_OrderWeekDay", (object) this.gdsh_OrderWeekDay) + ",gdsh_AutoOrderMonths,gdsh_AutoOrderDays,gdsh_AutoOrderType,gdsh_AutoSafeQty=" + this.gdsh_AutoSafeQty.FormatTo("{0:0.0000}") + ",gdsh_AutoMinQty=" + this.gdsh_AutoMinQty.FormatTo("{0:0.0000}") + ",gdsh_AutoMidQty=" + this.gdsh_AutoMidQty.FormatTo("{0:0.0000}") + ",gdsh_AutoMaxQty=" + this.gdsh_AutoMaxQty.FormatTo("{0:0.0000}") + ",gdsh_StorageStockQty,gdsh_OrderEndDate=" + this.gdsh_OrderEndDate.GetDateToStrInNull() + ",gdsh_SaleEndDate=" + this.gdsh_SaleEndDate.GetDateToStrInNull() + string.Format(",{0}={1}", (object) "gdsh_AddProperty", (object) this.gdsh_AddProperty) + string.Format(",{0}={1},{2}={3}", (object) "gdsh_ModDate", (object) this.gdsh_ModDate.GetDateToStrInNull(), (object) "gdsh_ModUser", (object) this.gdsh_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.gdsh_StoreCode, (object) this.gdsh_GoodsCode, (object) this.gdsh_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TGoodsStoreInfo tgoodsStoreInfo = this;
      // ISSUE: reference to a compiler-generated method
      tgoodsStoreInfo.\u003C\u003En__1();
      if (await tgoodsStoreInfo.OleDB.ExecuteAsync(tgoodsStoreInfo.UpdateExInsertQuery()))
        return true;
      tgoodsStoreInfo.message = " " + tgoodsStoreInfo.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tgoodsStoreInfo.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tgoodsStoreInfo.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tgoodsStoreInfo.gdsh_StoreCode, (object) tgoodsStoreInfo.gdsh_GoodsCode, (object) tgoodsStoreInfo.gdsh_SiteID) + " 내용 : " + tgoodsStoreInfo.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tgoodsStoreInfo.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        DateTime? nullable = new DateTime?();
        if (hashtable.ContainsKey((object) "_DT_DATE_") && hashtable[(object) "_DT_DATE_"].ToString().Length > 0)
          nullable = new DateTime?(Convert.ToDateTime(hashtable[(object) "_DT_DATE_"].ToString()));
        if (hashtable.ContainsKey((object) "gdsh_SiteID") && Convert.ToInt64(hashtable[(object) "gdsh_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "gdsh_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "gdsh_StoreCode") && Convert.ToInt32(hashtable[(object) "gdsh_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gdsh_StoreCode", hashtable[(object) "gdsh_StoreCode"]));
        else if (hashtable.ContainsKey((object) "gdsh_StoreCode_IN_") && hashtable[(object) "gdsh_StoreCode_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "gdsh_StoreCode", hashtable[(object) "gdsh_StoreCode_IN_"]));
        else if (hashtable.ContainsKey((object) "_STORE_AUTHS_") && hashtable[(object) "_STORE_AUTHS_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "gdsh_StoreCode", hashtable[(object) "_STORE_AUTHS_"]));
        if (hashtable.ContainsKey((object) "gdsh_GoodsCode") && Convert.ToInt64(hashtable[(object) "gdsh_GoodsCode"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gdsh_GoodsCode", hashtable[(object) "gdsh_GoodsCode"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gdsh_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "gdsh_DeliveryDiv") && Convert.ToInt32(hashtable[(object) "gdsh_DeliveryDiv"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gdsh_DeliveryDiv", hashtable[(object) "gdsh_DeliveryDiv"]));
        if (hashtable.ContainsKey((object) "gdsh_MultiSuplierYn") && hashtable[(object) "gdsh_MultiSuplierYn"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "gdsh_MultiSuplierYn", hashtable[(object) "gdsh_MultiSuplierYn"]));
        if (hashtable.ContainsKey((object) "gdsh_OrderEndDate") && hashtable[(object) "gdsh_OrderEndDate"].ToString().Length > 0)
        {
          stringBuilder.Append(" AND gdsh_OrderEndDate >='" + new DateTime?((DateTime) hashtable[(object) "gdsh_OrderEndDate"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND gdsh_OrderEndDate <='" + new DateTime?((DateTime) hashtable[(object) "gdsh_OrderEndDate"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
        }
        bool flag1 = hashtable.ContainsKey((object) "gdsh_OrderEndDate_LIVE_") && Convert.ToBoolean(hashtable[(object) "gdsh_OrderEndDate_LIVE_"].ToString());
        bool flag2 = hashtable.ContainsKey((object) "gdsh_OrderEndDate_END_") && Convert.ToBoolean(hashtable[(object) "gdsh_OrderEndDate_END_"].ToString());
        if (!(flag1 & flag2))
        {
          if (flag1)
          {
            if (!nullable.HasValue)
              nullable = new DateTime?(DateTime.Now);
            stringBuilder.Append(" AND " + DbQueryHelper.ToIsNULL() + "(gdsh_OrderEndDate,'2999-12-31 23:59:59') > '" + new DateTime?(nullable.Value).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          }
          else if (flag2)
          {
            if (!nullable.HasValue)
              nullable = new DateTime?(DateTime.Now);
            stringBuilder.Append(" AND " + DbQueryHelper.ToIsNULL() + "(gdsh_OrderEndDate,'2999-12-31 23:59:59') < '" + new DateTime?(nullable.Value).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          }
        }
        if (hashtable.ContainsKey((object) "gdsh_SaleEndDate") && hashtable[(object) "gdsh_SaleEndDate"].ToString().Length > 0)
        {
          stringBuilder.Append(" AND gdsh_SaleEndDate >='" + new DateTime?((DateTime) hashtable[(object) "gdsh_SaleEndDate"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND gdsh_SaleEndDate <='" + new DateTime?((DateTime) hashtable[(object) "gdsh_SaleEndDate"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
        }
        bool flag3 = hashtable.ContainsKey((object) "gdsh_SaleEndDate_LIVE_") && Convert.ToBoolean(hashtable[(object) "gdsh_SaleEndDate_LIVE_"].ToString());
        bool flag4 = hashtable.ContainsKey((object) "gdsh_SaleEndDate_END_") && Convert.ToBoolean(hashtable[(object) "gdsh_SaleEndDate_END_"].ToString());
        if (!(flag3 & flag4))
        {
          if (flag3)
          {
            if (!nullable.HasValue)
              nullable = new DateTime?(DateTime.Now);
            stringBuilder.Append(" AND " + DbQueryHelper.ToIsNULL() + "(gdsh_SaleEndDate,'2999-12-31 23:59:59') > '" + new DateTime?(nullable.Value).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          }
          else if (flag4)
          {
            if (!nullable.HasValue)
              nullable = new DateTime?(DateTime.Now);
            stringBuilder.Append(" AND " + DbQueryHelper.ToIsNULL() + "(gdsh_SaleEndDate,'2999-12-31 23:59:59') < '" + new DateTime?(nullable.Value).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          }
        }
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
        string uniBase = UbModelBase.UNI_BASE;
        string str = this.TableCode.ToString();
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
        }
        stringBuilder.Append(" SELECT  gdsh_StoreCode,gdsh_GoodsCode,gdsh_SiteID,gdsh_DeliveryDiv,gdsh_MinOrderUnit,gdsh_MultiSuplierYn,gdsh_OrderType,gdsh_AutoOrderMonth,gdsh_OrderWeekDay,gdsh_AutoOrderMonths,gdsh_AutoOrderDays,gdsh_AutoOrderType,gdsh_AutoSafeQty,gdsh_AutoMinQty,gdsh_AutoMidQty,gdsh_AutoMaxQty,gdsh_StorageStockQty,gdsh_OrderEndDate,gdsh_SaleEndDate,gdsh_AddProperty,gdsh_InDate,gdsh_InUser,gdsh_ModDate,gdsh_ModUser");
        stringBuilder.Append(" FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock());
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
