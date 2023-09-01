// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Inventory.TInventoryHeader
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

namespace UniBiz.Bo.Models.UniStock.Inventory
{
  public class TInventoryHeader : UbModelBase<TInventoryHeader>
  {
    private long _ih_StatementNo;
    private long _ih_SiteID;
    private int _ih_StoreCode;
    private string _ih_Title;
    private int _ih_EmpCode;
    private int _ih_InventoryStatus;
    private DateTime? _ih_InventoryDate;
    private int _ih_ApplyType;
    private DateTime? _ih_ApplyDate;
    private int _ih_DeviceType;
    private int _ih_DeviceKey;
    private string _ih_DeviceName;
    private int _ih_GoodsCount;
    private double _ih_CostAmt;
    private double _ih_CostVatAmt;
    private double _ih_AvgCostAmt;
    private double _ih_AvgCostVatAmt;
    private double _ih_PriceAmt;
    private int _ih_PosNo;
    private int _ih_TransNo;
    private int _ih_LocationCode;
    private int _ih_LocationCount;
    private int _ih_StockUnit;
    private string _ih_Memo;
    private long _ih_MobileStatementNo;
    private DateTime? _ih_InDate;
    private int _ih_InUser;
    private DateTime? _ih_ModDate;
    private int _ih_ModUser;

    public override object _Key => (object) new object[1]
    {
      (object) this.ih_StatementNo
    };

    public long ih_StatementNo
    {
      get => this._ih_StatementNo;
      set
      {
        this._ih_StatementNo = value;
        this.Changed(nameof (ih_StatementNo));
      }
    }

    public long ih_SiteID
    {
      get => this._ih_SiteID;
      set
      {
        this._ih_SiteID = value;
        this.Changed(nameof (ih_SiteID));
      }
    }

    public int ih_StoreCode
    {
      get => this._ih_StoreCode;
      set
      {
        this._ih_StoreCode = value;
        this.Changed(nameof (ih_StoreCode));
      }
    }

    public string ih_Title
    {
      get => this._ih_Title;
      set
      {
        this._ih_Title = UbModelBase.LeftStr(value, 500).Replace("'", "´");
        this.Changed(nameof (ih_Title));
      }
    }

    public int ih_EmpCode
    {
      get => this._ih_EmpCode;
      set
      {
        this._ih_EmpCode = value;
        this.Changed(nameof (ih_EmpCode));
      }
    }

    public int ih_InventoryStatus
    {
      get => this._ih_InventoryStatus;
      set
      {
        this._ih_InventoryStatus = value;
        this.Changed(nameof (ih_InventoryStatus));
        this.Changed("ih_InventoryStatusDesc");
        this.Changed("IsConfirm");
        this.Changed("IsNotConfirm");
        this.Changed("IsDelete");
      }
    }

    public string ih_InventoryStatusDesc => this.ih_InventoryStatus != 0 ? Enum2StrConverter.ToStatementConfirmStatus(this.ih_InventoryStatus).ToDescription() : string.Empty;

    public bool IsConfirm => Enum2StrConverter.ToStatementConfirmStatus(this.ih_InventoryStatus) == EnumStatementConfirmStatus.Confirm;

    public bool IsNotConfirm => Enum2StrConverter.ToStatementConfirmStatus(this.ih_InventoryStatus) == EnumStatementConfirmStatus.NotConfirm;

    public bool IsDelete => Enum2StrConverter.ToStatementConfirmStatus(this.ih_InventoryStatus) == EnumStatementConfirmStatus.Delete;

    public DateTime? ih_InventoryDate
    {
      get => this._ih_InventoryDate;
      set
      {
        this._ih_InventoryDate = value;
        this.Changed(nameof (ih_InventoryDate));
      }
    }

    public int ih_ApplyType
    {
      get => this._ih_ApplyType;
      set
      {
        this._ih_ApplyType = value;
        this.Changed(nameof (ih_ApplyType));
        this.Changed("ih_ApplyTypeDesc");
        this.Changed("IsApply");
      }
    }

    public string ih_ApplyTypeDesc => this.ih_ApplyType != 0 ? Enum2StrConverter.ToInventoryApplyType(this.ih_ApplyType).ToDescription() : string.Empty;

    public bool IsApply => Enum2StrConverter.ToInventoryApplyType(this.ih_ApplyType) == EnumInventoryApplyType.Apply;

    public DateTime? ih_ApplyDate
    {
      get => this._ih_ApplyDate;
      set
      {
        this._ih_ApplyDate = value;
        this.Changed(nameof (ih_ApplyDate));
      }
    }

    public int ih_DeviceType
    {
      get => this._ih_DeviceType;
      set
      {
        this._ih_DeviceType = value;
        this.Changed(nameof (ih_DeviceType));
        this.Changed("ih_DeviceTypeDesc");
      }
    }

    public string ih_DeviceTypeDesc => this.ih_DeviceType != 0 ? Enum2StrConverter.ToDeviceType(this.ih_DeviceType).ToDescription() : string.Empty;

    public int ih_DeviceKey
    {
      get => this._ih_DeviceKey;
      set
      {
        this._ih_DeviceKey = value;
        this.Changed(nameof (ih_DeviceKey));
      }
    }

    public string ih_DeviceName
    {
      get => this._ih_DeviceName;
      set
      {
        this._ih_DeviceName = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (ih_DeviceName));
      }
    }

    public int ih_GoodsCount
    {
      get => this._ih_GoodsCount;
      set
      {
        this._ih_GoodsCount = value;
        this.Changed(nameof (ih_GoodsCount));
      }
    }

    public double ih_CostAmt
    {
      get => this._ih_CostAmt;
      set
      {
        this._ih_CostAmt = CalcHelper.CalcDoubleToFormatDouble(value);
        this.Changed(nameof (ih_CostAmt));
      }
    }

    public double ih_CostVatAmt
    {
      get => this._ih_CostVatAmt;
      set
      {
        this._ih_CostVatAmt = CalcHelper.CalcDoubleToFormatDouble(value);
        this.Changed(nameof (ih_CostVatAmt));
      }
    }

    public double ih_AvgCostAmt
    {
      get => this._ih_AvgCostAmt;
      set
      {
        this._ih_AvgCostAmt = CalcHelper.CalcDoubleToFormatDouble(value);
        this.Changed(nameof (ih_AvgCostAmt));
      }
    }

    public double ih_AvgCostVatAmt
    {
      get => this._ih_AvgCostVatAmt;
      set
      {
        this._ih_AvgCostVatAmt = CalcHelper.CalcDoubleToFormatDouble(value);
        this.Changed(nameof (ih_AvgCostVatAmt));
      }
    }

    public double ih_PriceAmt
    {
      get => this._ih_PriceAmt;
      set
      {
        this._ih_PriceAmt = CalcHelper.CalcDoubleToFormatDouble(value);
        this.Changed(nameof (ih_PriceAmt));
      }
    }

    public int ih_PosNo
    {
      get => this._ih_PosNo;
      set
      {
        this._ih_PosNo = value;
        this.Changed(nameof (ih_PosNo));
      }
    }

    public int ih_TransNo
    {
      get => this._ih_TransNo;
      set
      {
        this._ih_TransNo = value;
        this.Changed(nameof (ih_TransNo));
      }
    }

    public int ih_LocationCode
    {
      get => this._ih_LocationCode;
      set
      {
        this._ih_LocationCode = value;
        this.Changed(nameof (ih_LocationCode));
      }
    }

    public int ih_LocationCount
    {
      get => this._ih_LocationCount;
      set
      {
        this._ih_LocationCount = value;
        this.Changed(nameof (ih_LocationCount));
      }
    }

    public int ih_StockUnit
    {
      get => this._ih_StockUnit;
      set
      {
        this._ih_StockUnit = value;
        this.Changed(nameof (ih_StockUnit));
        this.Changed("ih_StockUnitDesc");
      }
    }

    public string ih_StockUnitDesc => this.ih_StockUnit != 0 ? Enum2StrConverter.ToStockUnit(this.ih_StockUnit).ToDescription() : string.Empty;

    public string ih_Memo
    {
      get => this._ih_Memo;
      set
      {
        this._ih_Memo = UbModelBase.LeftStr(value, 1000).Replace("'", "´");
        this.Changed(nameof (ih_Memo));
      }
    }

    public long ih_MobileStatementNo
    {
      get => this._ih_MobileStatementNo;
      set
      {
        this._ih_MobileStatementNo = value;
        this.Changed(nameof (ih_MobileStatementNo));
      }
    }

    public DateTime? ih_InDate
    {
      get => this._ih_InDate;
      set
      {
        this._ih_InDate = value;
        this.Changed(nameof (ih_InDate));
      }
    }

    public int ih_InUser
    {
      get => this._ih_InUser;
      set
      {
        this._ih_InUser = value;
        this.Changed(nameof (ih_InUser));
      }
    }

    public DateTime? ih_ModDate
    {
      get => this._ih_ModDate;
      set
      {
        this._ih_ModDate = value;
        this.Changed(nameof (ih_ModDate));
      }
    }

    public int ih_ModUser
    {
      get => this._ih_ModUser;
      set
      {
        this._ih_ModUser = value;
        this.Changed(nameof (ih_ModUser));
      }
    }

    public TInventoryHeader() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("ih_StatementNo", new TTableColumn()
      {
        tc_orgin_name = "ih_StatementNo",
        tc_trans_name = "재고조사전표번호"
      });
      columnInfo.Add("ih_SiteID", new TTableColumn()
      {
        tc_orgin_name = "ih_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("ih_StoreCode", new TTableColumn()
      {
        tc_orgin_name = "ih_StoreCode",
        tc_trans_name = "지점"
      });
      columnInfo.Add("ih_EmpCode", new TTableColumn()
      {
        tc_orgin_name = "ih_EmpCode",
        tc_trans_name = "조사자"
      });
      columnInfo.Add("ih_InventoryStatus", new TTableColumn()
      {
        tc_orgin_name = "ih_InventoryStatus",
        tc_trans_name = "재고확정",
        tc_comm_code = 49
      });
      columnInfo.Add("ih_InventoryDate", new TTableColumn()
      {
        tc_orgin_name = "ih_InventoryDate",
        tc_trans_name = "재고조사일자"
      });
      columnInfo.Add("ih_ApplyType", new TTableColumn()
      {
        tc_orgin_name = "ih_ApplyType",
        tc_trans_name = "변환구분",
        tc_comm_code = 156
      });
      columnInfo.Add("ih_ApplyDate", new TTableColumn()
      {
        tc_orgin_name = "ih_ApplyDate",
        tc_trans_name = "변환일시"
      });
      columnInfo.Add("ih_DeviceType", new TTableColumn()
      {
        tc_orgin_name = "ih_DeviceType",
        tc_trans_name = "디바이스유형",
        tc_comm_code = 50
      });
      columnInfo.Add("ih_DeviceKey", new TTableColumn()
      {
        tc_orgin_name = "ih_DeviceKey",
        tc_trans_name = "디바이스ID"
      });
      columnInfo.Add("ih_DeviceName", new TTableColumn()
      {
        tc_orgin_name = "ih_DeviceName",
        tc_trans_name = "디바이스명"
      });
      columnInfo.Add("ih_GoodsCount", new TTableColumn()
      {
        tc_orgin_name = "ih_GoodsCount",
        tc_trans_name = "상품건수"
      });
      columnInfo.Add("ih_CostAmt", new TTableColumn()
      {
        tc_orgin_name = "ih_CostAmt",
        tc_trans_name = "원가계"
      });
      columnInfo.Add("ih_CostVatAmt", new TTableColumn()
      {
        tc_orgin_name = "ih_CostVatAmt",
        tc_trans_name = "원가VAT계"
      });
      columnInfo.Add("ih_AvgCostAmt", new TTableColumn()
      {
        tc_orgin_name = "ih_AvgCostAmt",
        tc_trans_name = "평균원가계"
      });
      columnInfo.Add("ih_AvgCostVatAmt", new TTableColumn()
      {
        tc_orgin_name = "ih_AvgCostVatAmt",
        tc_trans_name = "평균원가VAT계"
      });
      columnInfo.Add("ih_PriceAmt", new TTableColumn()
      {
        tc_orgin_name = "ih_PriceAmt",
        tc_trans_name = "판매가계"
      });
      columnInfo.Add("ih_PosNo", new TTableColumn()
      {
        tc_orgin_name = "ih_PosNo",
        tc_trans_name = "영수번호"
      });
      columnInfo.Add("ih_TransNo", new TTableColumn()
      {
        tc_orgin_name = "ih_TransNo",
        tc_trans_name = "영수번호"
      });
      columnInfo.Add("ih_LocationCode", new TTableColumn()
      {
        tc_orgin_name = "ih_LocationCode",
        tc_trans_name = "로케이션 코드"
      });
      columnInfo.Add("ih_LocationCount", new TTableColumn()
      {
        tc_orgin_name = "ih_LocationCount",
        tc_trans_name = "로케이션 건"
      });
      columnInfo.Add("ih_StockUnit", new TTableColumn()
      {
        tc_orgin_name = "ih_StockUnit",
        tc_trans_name = "재고단위",
        tc_comm_code = 53
      });
      columnInfo.Add("ih_Memo", new TTableColumn()
      {
        tc_orgin_name = "ih_Memo",
        tc_trans_name = "메모"
      });
      columnInfo.Add("ih_MobileStatementNo", new TTableColumn()
      {
        tc_orgin_name = "ih_MobileStatementNo",
        tc_trans_name = "모바일용 전표번호"
      });
      columnInfo.Add("ih_InDate", new TTableColumn()
      {
        tc_orgin_name = "ih_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("ih_InUser", new TTableColumn()
      {
        tc_orgin_name = "ih_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("ih_ModDate", new TTableColumn()
      {
        tc_orgin_name = "ih_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("ih_ModUser", new TTableColumn()
      {
        tc_orgin_name = "ih_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.InventoryHeader;
      this.ih_StatementNo = 0L;
      this.ih_SiteID = 0L;
      this.ih_StoreCode = this.ih_EmpCode = this.ih_InventoryStatus = this.ih_ApplyType = this.ih_DeviceType = 0;
      this.ih_GoodsCount = this.ih_PosNo = this.ih_TransNo = this.ih_LocationCode = this.ih_LocationCount = 0;
      this.ih_MobileStatementNo = 0L;
      this.ih_DeviceType = 1;
      this.ih_StockUnit = 2;
      this.ih_CostAmt = this.ih_CostVatAmt = this.ih_AvgCostAmt = this.ih_AvgCostVatAmt = this.ih_PriceAmt = 0.0;
      this.ih_Title = this.ih_DeviceName = this.ih_Memo = string.Empty;
      this.ih_DeviceKey = 0;
      DateTime? nullable1 = new DateTime?();
      this.ih_ApplyDate = nullable1;
      this.ih_InventoryDate = nullable1;
      this.ih_ModUser = this.ih_InUser = 0;
      DateTime? nullable2 = new DateTime?();
      this.ih_ModDate = nullable2;
      this.ih_InDate = nullable2;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TInventoryHeader();

    public override object Clone()
    {
      TInventoryHeader tinventoryHeader = base.Clone() as TInventoryHeader;
      tinventoryHeader.ih_StatementNo = this.ih_StatementNo;
      tinventoryHeader.ih_SiteID = this.ih_SiteID;
      tinventoryHeader.ih_StoreCode = this.ih_StoreCode;
      tinventoryHeader.ih_Title = this.ih_Title;
      tinventoryHeader.ih_EmpCode = this.ih_EmpCode;
      tinventoryHeader.ih_InventoryStatus = this.ih_InventoryStatus;
      tinventoryHeader.ih_InventoryDate = this.ih_InventoryDate;
      tinventoryHeader.ih_ApplyType = this.ih_ApplyType;
      tinventoryHeader.ih_ApplyDate = this.ih_ApplyDate;
      tinventoryHeader.ih_DeviceType = this.ih_DeviceType;
      tinventoryHeader.ih_DeviceKey = this.ih_DeviceKey;
      tinventoryHeader.ih_DeviceName = this.ih_DeviceName;
      tinventoryHeader.ih_GoodsCount = this.ih_GoodsCount;
      tinventoryHeader.ih_CostAmt = this.ih_CostAmt;
      tinventoryHeader.ih_CostVatAmt = this.ih_CostVatAmt;
      tinventoryHeader.ih_AvgCostAmt = this.ih_AvgCostAmt;
      tinventoryHeader.ih_AvgCostVatAmt = this.ih_AvgCostVatAmt;
      tinventoryHeader.ih_PriceAmt = this.ih_PriceAmt;
      tinventoryHeader.ih_PosNo = this.ih_PosNo;
      tinventoryHeader.ih_TransNo = this.ih_TransNo;
      tinventoryHeader.ih_LocationCode = this.ih_LocationCode;
      tinventoryHeader.ih_LocationCount = this.ih_LocationCount;
      tinventoryHeader.ih_StockUnit = this.ih_LocationCount;
      tinventoryHeader.ih_Memo = this.ih_Memo;
      tinventoryHeader.ih_MobileStatementNo = this.ih_MobileStatementNo;
      tinventoryHeader.ih_InDate = this.ih_InDate;
      tinventoryHeader.ih_InUser = this.ih_InUser;
      tinventoryHeader.ih_ModDate = this.ih_ModDate;
      tinventoryHeader.ih_ModUser = this.ih_ModUser;
      return (object) tinventoryHeader;
    }

    public void PutData(TInventoryHeader pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.ih_StatementNo = pSource.ih_StatementNo;
      this.ih_SiteID = pSource.ih_SiteID;
      this.ih_StoreCode = pSource.ih_StoreCode;
      this.ih_Title = pSource.ih_Title;
      this.ih_EmpCode = pSource.ih_EmpCode;
      this.ih_InventoryStatus = pSource.ih_InventoryStatus;
      this.ih_InventoryDate = pSource.ih_InventoryDate;
      this.ih_ApplyType = pSource.ih_ApplyType;
      this.ih_ApplyDate = pSource.ih_ApplyDate;
      this.ih_DeviceType = pSource.ih_DeviceType;
      this.ih_DeviceKey = pSource.ih_DeviceKey;
      this.ih_DeviceName = pSource.ih_DeviceName;
      this.ih_GoodsCount = pSource.ih_GoodsCount;
      this.ih_CostAmt = pSource.ih_CostAmt;
      this.ih_CostVatAmt = pSource.ih_CostVatAmt;
      this.ih_AvgCostAmt = pSource.ih_AvgCostAmt;
      this.ih_AvgCostVatAmt = pSource.ih_AvgCostVatAmt;
      this.ih_PriceAmt = pSource.ih_PriceAmt;
      this.ih_PosNo = pSource.ih_PosNo;
      this.ih_TransNo = pSource.ih_TransNo;
      this.ih_LocationCode = pSource.ih_LocationCode;
      this.ih_LocationCount = pSource.ih_LocationCount;
      this.ih_StockUnit = pSource.ih_LocationCount;
      this.ih_Memo = pSource.ih_Memo;
      this.ih_MobileStatementNo = pSource.ih_MobileStatementNo;
      this.ih_InDate = pSource.ih_InDate;
      this.ih_InUser = pSource.ih_InUser;
      this.ih_ModDate = pSource.ih_ModDate;
      this.ih_ModUser = pSource.ih_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.ih_StatementNo = p_rs.GetFieldLong("ih_StatementNo");
        this.ih_SiteID = p_rs.GetFieldLong("ih_SiteID");
        if (this.ih_SiteID == 0L)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.ih_StoreCode = p_rs.GetFieldInt("ih_StoreCode");
        this.ih_Title = p_rs.GetFieldString("ih_Title");
        this.ih_EmpCode = p_rs.GetFieldInt("ih_EmpCode");
        this.ih_InventoryStatus = p_rs.GetFieldInt("ih_InventoryStatus");
        this.ih_InventoryDate = p_rs.GetFieldDateTime("ih_InventoryDate");
        this.ih_ApplyType = p_rs.GetFieldInt("ih_ApplyType");
        this.ih_ApplyDate = p_rs.GetFieldDateTime("ih_ApplyDate");
        this.ih_DeviceType = p_rs.GetFieldInt("ih_DeviceType");
        this.ih_DeviceKey = p_rs.GetFieldInt("ih_DeviceKey");
        this.ih_DeviceName = p_rs.GetFieldString("ih_DeviceName");
        this.ih_GoodsCount = p_rs.GetFieldInt("ih_GoodsCount");
        this.ih_CostAmt = p_rs.GetFieldDouble("ih_CostAmt");
        this.ih_CostVatAmt = p_rs.GetFieldDouble("ih_CostVatAmt");
        this.ih_AvgCostAmt = p_rs.GetFieldDouble("ih_AvgCostAmt");
        this.ih_AvgCostVatAmt = p_rs.GetFieldDouble("ih_AvgCostVatAmt");
        this.ih_PriceAmt = p_rs.GetFieldDouble("ih_PriceAmt");
        this.ih_PosNo = p_rs.GetFieldInt("ih_PosNo");
        this.ih_TransNo = p_rs.GetFieldInt("ih_TransNo");
        this.ih_LocationCode = p_rs.GetFieldInt("ih_LocationCode");
        this.ih_LocationCount = p_rs.GetFieldInt("ih_LocationCount");
        this.ih_StockUnit = p_rs.GetFieldInt("ih_StockUnit");
        this.ih_Memo = p_rs.GetFieldString("ih_Memo");
        this.ih_MobileStatementNo = p_rs.GetFieldLong("ih_MobileStatementNo");
        this.ih_InDate = p_rs.GetFieldDateTime("ih_InDate");
        this.ih_InUser = p_rs.GetFieldInt("ih_InUser");
        this.ih_ModDate = p_rs.GetFieldDateTime("ih_ModDate");
        this.ih_ModUser = p_rs.GetFieldInt("ih_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) this.TableCode) + " ih_StatementNo,ih_SiteID,ih_StoreCode,ih_Title,ih_EmpCode,ih_InventoryStatus,ih_InventoryDate,ih_ApplyType,ih_ApplyDate,ih_DeviceType,ih_DeviceKey,ih_DeviceName,ih_GoodsCount,ih_CostAmt,ih_CostVatAmt,ih_AvgCostAmt,ih_AvgCostVatAmt,ih_PriceAmt,ih_PosNo,ih_TransNo,ih_LocationCode,ih_LocationCount,ih_StockUnit,ih_Memo,ih_MobileStatementNo,ih_InDate,ih_InUser,ih_ModDate,ih_ModUser) VALUES ( " + string.Format(" {0}", (object) this.ih_StatementNo) + string.Format(",{0}", (object) this.ih_SiteID) + string.Format(",{0},'{1}',{2}", (object) this.ih_StoreCode, (object) this.ih_Title, (object) this.ih_EmpCode) + string.Format(",{0},{1}", (object) this.ih_InventoryStatus, (object) this.ih_InventoryDate.GetDateToStrInNull()) + string.Format(",{0},{1}", (object) this.ih_ApplyType, (object) this.ih_ApplyDate.GetDateToStrInNull()) + string.Format(",{0},{1},'{2}'", (object) this.ih_DeviceType, (object) this.ih_DeviceKey, (object) this.ih_DeviceName) + string.Format(",{0},{1},{2}", (object) this.ih_GoodsCount, (object) this.ih_CostAmt.FormatTo("{0:0.0000}"), (object) this.ih_CostVatAmt.FormatTo("{0:0.0000}")) + "," + this.ih_AvgCostAmt.FormatTo("{0:0.0000}") + "," + this.ih_AvgCostVatAmt.FormatTo("{0:0.0000}") + "," + this.ih_PriceAmt.FormatTo("{0:0.0000}") + string.Format(",{0},{1},{2},{3}", (object) this.ih_PosNo, (object) this.ih_TransNo, (object) this.ih_LocationCode, (object) this.ih_LocationCount) + string.Format(",{0},'{1}',{2}", (object) this.ih_StockUnit, (object) this.ih_Memo, (object) this.ih_MobileStatementNo) + string.Format(",{0},{1}", (object) this.ih_InDate.GetDateToStrInNull(), (object) this.ih_InUser) + string.Format(",{0},{1}", (object) this.ih_ModDate.GetDateToStrInNull(), (object) this.ih_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.ih_StatementNo, (object) this.ih_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TInventoryHeader tinventoryHeader = this;
      // ISSUE: reference to a compiler-generated method
      tinventoryHeader.\u003C\u003En__0();
      if (await tinventoryHeader.OleDB.ExecuteAsync(tinventoryHeader.InsertQuery()))
        return true;
      tinventoryHeader.message = " " + tinventoryHeader.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tinventoryHeader.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tinventoryHeader.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tinventoryHeader.ih_StatementNo, (object) tinventoryHeader.ih_SiteID) + " 내용 : " + tinventoryHeader.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tinventoryHeader.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) this.TableCode) + string.Format(" {0}={1},{2}='{3}',{4}={5}", (object) "ih_StoreCode", (object) this.ih_StoreCode, (object) "ih_Title", (object) this.ih_Title, (object) "ih_EmpCode", (object) this.ih_EmpCode) + string.Format(",{0}={1},{2}={3}", (object) "ih_InventoryStatus", (object) this.ih_InventoryStatus, (object) "ih_InventoryDate", (object) this.ih_InventoryDate.GetDateToStrInNull()) + string.Format(",{0}={1},{2}={3}", (object) "ih_ApplyType", (object) this.ih_ApplyType, (object) "ih_ApplyDate", (object) this.ih_ApplyDate.GetDateToStrInNull()) + string.Format(",{0}={1},{2}={3},{4}='{5}'", (object) "ih_DeviceType", (object) this.ih_DeviceType, (object) "ih_DeviceKey", (object) this.ih_DeviceKey, (object) "ih_DeviceName", (object) this.ih_DeviceName) + string.Format(",{0}={1},{2}={3},{4}={5}", (object) "ih_GoodsCount", (object) this.ih_GoodsCount, (object) "ih_CostAmt", (object) this.ih_CostAmt.FormatTo("{0:0.0000}"), (object) "ih_CostVatAmt", (object) this.ih_CostVatAmt.FormatTo("{0:0.0000}")) + ",ih_AvgCostAmt=" + this.ih_AvgCostAmt.FormatTo("{0:0.0000}") + ",ih_AvgCostVatAmt=" + this.ih_AvgCostVatAmt.FormatTo("{0:0.0000}") + ",ih_PriceAmt=" + this.ih_PriceAmt.FormatTo("{0:0.0000}") + string.Format(",{0}={1},{2}={3}", (object) "ih_PosNo", (object) this.ih_PosNo, (object) "ih_TransNo", (object) this.ih_TransNo) + string.Format(",{0}={1},{2}={3}", (object) "ih_LocationCode", (object) this.ih_LocationCode, (object) "ih_LocationCount", (object) this.ih_LocationCount) + string.Format(",{0}={1},{2}='{3}',{4}={5}", (object) "ih_StockUnit", (object) this.ih_StockUnit, (object) "ih_Memo", (object) this.ih_Memo, (object) "ih_MobileStatementNo", (object) this.ih_MobileStatementNo) + string.Format(",{0}={1},{2}={3}", (object) "ih_ModDate", (object) this.ih_ModDate.GetDateToStrInNull(), (object) "ih_ModUser", (object) this.ih_ModUser) + string.Format(" WHERE {0}={1}", (object) "ih_StatementNo", (object) this.ih_StatementNo) + string.Format(" AND {0}={1}", (object) "ih_SiteID", (object) this.ih_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.ih_StatementNo, (object) this.ih_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TInventoryHeader tinventoryHeader = this;
      // ISSUE: reference to a compiler-generated method
      tinventoryHeader.\u003C\u003En__1();
      if (await tinventoryHeader.OleDB.ExecuteAsync(tinventoryHeader.UpdateQuery()))
        return true;
      tinventoryHeader.message = " " + tinventoryHeader.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tinventoryHeader.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tinventoryHeader.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tinventoryHeader.ih_StatementNo, (object) tinventoryHeader.ih_SiteID) + " 내용 : " + tinventoryHeader.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tinventoryHeader.message);
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
      stringBuilder.Append(string.Format(" {0}={1},{2}='{3}',{4}={5}", (object) "ih_StoreCode", (object) this.ih_StoreCode, (object) "ih_Title", (object) this.ih_Title, (object) "ih_EmpCode", (object) this.ih_EmpCode) + string.Format(",{0}={1},{2}={3}", (object) "ih_InventoryStatus", (object) this.ih_InventoryStatus, (object) "ih_InventoryDate", (object) this.ih_InventoryDate.GetDateToStrInNull()) + string.Format(",{0}={1},{2}={3}", (object) "ih_ApplyType", (object) this.ih_ApplyType, (object) "ih_ApplyDate", (object) this.ih_ApplyDate.GetDateToStrInNull()) + string.Format(",{0}={1},{2}={3},{4}='{5}'", (object) "ih_DeviceType", (object) this.ih_DeviceType, (object) "ih_DeviceKey", (object) this.ih_DeviceKey, (object) "ih_DeviceName", (object) this.ih_DeviceName) + string.Format(",{0}={1},{2}={3},{4}={5}", (object) "ih_GoodsCount", (object) this.ih_GoodsCount, (object) "ih_CostAmt", (object) this.ih_CostAmt.FormatTo("{0:0.0000}"), (object) "ih_CostVatAmt", (object) this.ih_CostVatAmt.FormatTo("{0:0.0000}")) + ",ih_AvgCostAmt=" + this.ih_AvgCostAmt.FormatTo("{0:0.0000}") + ",ih_AvgCostVatAmt=" + this.ih_AvgCostVatAmt.FormatTo("{0:0.0000}") + ",ih_PriceAmt=" + this.ih_PriceAmt.FormatTo("{0:0.0000}") + string.Format(",{0}={1},{2}={3}", (object) "ih_PosNo", (object) this.ih_PosNo, (object) "ih_TransNo", (object) this.ih_TransNo) + string.Format(",{0}={1},{2}={3}", (object) "ih_LocationCode", (object) this.ih_LocationCode, (object) "ih_LocationCount", (object) this.ih_LocationCount) + string.Format(",{0}={1},{2}='{3}',{4}={5}", (object) "ih_StockUnit", (object) this.ih_StockUnit, (object) "ih_Memo", (object) this.ih_Memo, (object) "ih_MobileStatementNo", (object) this.ih_MobileStatementNo) + string.Format(",{0}={1},{2}={3}", (object) "ih_ModDate", (object) this.ih_ModDate.GetDateToStrInNull(), (object) "ih_ModUser", (object) this.ih_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.ih_StatementNo, (object) this.ih_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TInventoryHeader tinventoryHeader = this;
      // ISSUE: reference to a compiler-generated method
      tinventoryHeader.\u003C\u003En__1();
      if (await tinventoryHeader.OleDB.ExecuteAsync(tinventoryHeader.UpdateExInsertQuery()))
        return true;
      tinventoryHeader.message = " " + tinventoryHeader.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tinventoryHeader.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tinventoryHeader.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tinventoryHeader.ih_StatementNo, (object) tinventoryHeader.ih_SiteID) + " 내용 : " + tinventoryHeader.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tinventoryHeader.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "ih_SiteID") && Convert.ToInt64(hashtable[(object) "ih_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "ih_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "ih_StatementNo") && Convert.ToInt64(hashtable[(object) "ih_StatementNo"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ih_StatementNo", hashtable[(object) "ih_StatementNo"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ih_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "si_StoreCode") && Convert.ToInt32(hashtable[(object) "si_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ih_StoreCode", hashtable[(object) "si_StoreCode"]));
        else if (hashtable.ContainsKey((object) "ih_StoreCode") && Convert.ToInt32(hashtable[(object) "ih_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ih_StoreCode", hashtable[(object) "ih_StoreCode"]));
        else if (hashtable.ContainsKey((object) "si_StoreCode_IN_") && hashtable[(object) "si_StoreCode_IN_"].ToString().Length > 0)
        {
          if (hashtable[(object) "si_StoreCode_IN_"].ToString().Contains(","))
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "ih_StoreCode", hashtable[(object) "si_StoreCode_IN_"]));
          else
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ih_StoreCode", hashtable[(object) "si_StoreCode_IN_"]));
        }
        else if (hashtable.ContainsKey((object) "ih_StoreCode_IN_") && hashtable[(object) "ih_StoreCode_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "ih_StoreCode", hashtable[(object) "ih_StoreCode_IN_"]));
        else if (hashtable.ContainsKey((object) "_STORE_AUTHS_") && hashtable[(object) "_STORE_AUTHS_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "ih_StoreCode", hashtable[(object) "_STORE_AUTHS_"]));
        if (hashtable.ContainsKey((object) "ih_EmpCode") && Convert.ToInt32(hashtable[(object) "ih_EmpCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ih_EmpCode", hashtable[(object) "ih_EmpCode"]));
        else if (hashtable.ContainsKey((object) "emp_Code") && Convert.ToInt32(hashtable[(object) "emp_Code"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ih_EmpCode", hashtable[(object) "emp_Code"]));
        if (hashtable.ContainsKey((object) "ih_InventoryStatus") && Convert.ToInt32(hashtable[(object) "ih_InventoryStatus"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ih_InventoryStatus", hashtable[(object) "ih_InventoryStatus"]));
        if (hashtable.ContainsKey((object) "ih_InventoryDate"))
        {
          stringBuilder.Append(" AND ih_InventoryDate >='" + new DateTime?((DateTime) hashtable[(object) "ih_InventoryDate"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND ih_InventoryDate <='" + new DateTime?((DateTime) hashtable[(object) "ih_InventoryDate"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
        }
        if (hashtable.ContainsKey((object) "ih_InventoryDate_BEGIN_") && hashtable.ContainsKey((object) "ih_InventoryDate_END_"))
        {
          stringBuilder.Append(" AND ih_InventoryDate >='" + new DateTime?((DateTime) hashtable[(object) "ih_InventoryDate_BEGIN_"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND ih_InventoryDate <='" + new DateTime?((DateTime) hashtable[(object) "ih_InventoryDate_END_"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
        }
        if (hashtable.ContainsKey((object) "ih_ApplyType") && Convert.ToInt32(hashtable[(object) "ih_ApplyType"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ih_ApplyType", hashtable[(object) "ih_ApplyType"]));
        if (hashtable.ContainsKey((object) "ih_ApplyDate"))
        {
          stringBuilder.Append(" AND ih_ApplyDate >='" + new DateTime?((DateTime) hashtable[(object) "ih_ApplyDate"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND ih_ApplyDate <='" + new DateTime?((DateTime) hashtable[(object) "ih_ApplyDate"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
        }
        if (hashtable.ContainsKey((object) "ih_ApplyDate_BEGIN_") && hashtable.ContainsKey((object) "ih_ApplyDate_END_"))
        {
          stringBuilder.Append(" AND ih_ApplyDate >='" + new DateTime?((DateTime) hashtable[(object) "ih_ApplyDate_BEGIN_"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND ih_ApplyDate <='" + new DateTime?((DateTime) hashtable[(object) "ih_ApplyDate_END_"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
        }
        if (hashtable.ContainsKey((object) "ih_DeviceType") && Convert.ToInt32(hashtable[(object) "ih_DeviceType"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ih_DeviceType", hashtable[(object) "ih_DeviceType"]));
        if (hashtable.ContainsKey((object) "ih_LocationCode") && Convert.ToInt32(hashtable[(object) "ih_LocationCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ih_LocationCode", hashtable[(object) "ih_LocationCode"]));
        if (hashtable.ContainsKey((object) "ih_StockUnit") && Convert.ToInt32(hashtable[(object) "ih_StockUnit"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ih_StockUnit", hashtable[(object) "ih_StockUnit"]));
        else if (hashtable.ContainsKey((object) "ih_StockUnit_IN_") && hashtable[(object) "ih_StockUnit_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "ih_StockUnit", hashtable[(object) "ih_StockUnit_IN_"]));
        if (hashtable.ContainsKey((object) "ih_MobileStatementNo") && Convert.ToInt64(hashtable[(object) "ih_MobileStatementNo"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ih_MobileStatementNo", hashtable[(object) "ih_MobileStatementNo"]));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "ih_Title", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "ih_Memo", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(")");
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
        stringBuilder.Append(" SELECT  ih_StatementNo,ih_SiteID,ih_StoreCode,ih_Title,ih_EmpCode,ih_InventoryStatus,ih_InventoryDate,ih_ApplyType,ih_ApplyDate,ih_DeviceType,ih_DeviceKey,ih_DeviceName,ih_GoodsCount,ih_CostAmt,ih_CostVatAmt,ih_AvgCostAmt,ih_AvgCostVatAmt,ih_PriceAmt,ih_PosNo,ih_TransNo,ih_LocationCode,ih_LocationCount,ih_StockUnit,ih_Memo,ih_MobileStatementNo,ih_InDate,ih_InUser,ih_ModDate,ih_ModUser");
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
