// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsHistory.TGoodsHistory
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

namespace UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsHistory
{
  public class TGoodsHistory : UbModelBase<TGoodsHistory>
  {
    private int _gdh_StoreCode;
    private long _gdh_GoodsCode;
    private DateTime? _gdh_StartDate;
    private long _gdh_SiteID;
    private DateTime? _gdh_EndDate;
    private int _gdh_GoodsCategory;
    private int _gdh_Supplier;
    private double _gdh_ChargeRate;
    private double _gdh_BuyCost;
    private double _gdh_BuyVat;
    private double _gdh_SalePrice;
    private double _gdh_EventCost;
    private double _gdh_EventVat;
    private double _gdh_EventPrice;
    private double _gdh_MemberPrice1;
    private double _gdh_MemberPrice2;
    private double _gdh_MemberPrice3;
    private double _gdh_PointRate;
    private DateTime? _gdh_InDate;
    private int _gdh_InUser;
    private DateTime? _gdh_ModDate;
    private int _gdh_ModUser;

    public override object _Key => (object) new object[3]
    {
      (object) this.gdh_StoreCode,
      (object) this.gdh_GoodsCode,
      (object) this.gdh_StartDate
    };

    public int gdh_StoreCode
    {
      get => this._gdh_StoreCode;
      set
      {
        this._gdh_StoreCode = value;
        this.Changed(nameof (gdh_StoreCode));
      }
    }

    public long gdh_GoodsCode
    {
      get => this._gdh_GoodsCode;
      set
      {
        this._gdh_GoodsCode = value;
        this.Changed(nameof (gdh_GoodsCode));
      }
    }

    public DateTime? gdh_StartDate
    {
      get => this._gdh_StartDate;
      set
      {
        this._gdh_StartDate = value;
        this.Changed(nameof (gdh_StartDate));
        this.Changed("IntStartDate");
      }
    }

    [JsonIgnore]
    public int IntStartDate => this.gdh_StartDate.HasValue ? Convert.ToInt32(this.gdh_StartDate.GetDateToStr("yyyyMMdd")) : 0;

    public long gdh_SiteID
    {
      get => this._gdh_SiteID;
      set
      {
        this._gdh_SiteID = value;
        this.Changed(nameof (gdh_SiteID));
      }
    }

    public DateTime? gdh_EndDate
    {
      get => this._gdh_EndDate;
      set
      {
        this._gdh_EndDate = value;
        this.Changed(nameof (gdh_EndDate));
        this.Changed("IntEndDate");
      }
    }

    [JsonIgnore]
    public int IntEndDate => this.gdh_EndDate.HasValue ? Convert.ToInt32(this.gdh_EndDate.GetDateToStr("yyyyMMdd")) : 0;

    public int gdh_GoodsCategory
    {
      get => this._gdh_GoodsCategory;
      set
      {
        this._gdh_GoodsCategory = value;
        this.Changed(nameof (gdh_GoodsCategory));
      }
    }

    public int gdh_Supplier
    {
      get => this._gdh_Supplier;
      set
      {
        this._gdh_Supplier = value;
        this.Changed(nameof (gdh_Supplier));
      }
    }

    public double gdh_ChargeRate
    {
      get => this._gdh_ChargeRate;
      set
      {
        this._gdh_ChargeRate = value;
        this.Changed(nameof (gdh_ChargeRate));
      }
    }

    public double gdh_BuyCost
    {
      get => this._gdh_BuyCost;
      set
      {
        this._gdh_BuyCost = value;
        this.Changed(nameof (gdh_BuyCost));
      }
    }

    public double gdh_BuyVat
    {
      get => this._gdh_BuyVat;
      set
      {
        this._gdh_BuyVat = value;
        this.Changed(nameof (gdh_BuyVat));
      }
    }

    public double gdh_SalePrice
    {
      get => this._gdh_SalePrice;
      set
      {
        this._gdh_SalePrice = value;
        this.Changed(nameof (gdh_SalePrice));
      }
    }

    public double gdh_EventCost
    {
      get => this._gdh_EventCost;
      set
      {
        this._gdh_EventCost = value;
        this.Changed(nameof (gdh_EventCost));
      }
    }

    public double gdh_EventVat
    {
      get => this._gdh_EventVat;
      set
      {
        this._gdh_EventVat = value;
        this.Changed(nameof (gdh_EventVat));
      }
    }

    public double gdh_EventPrice
    {
      get => this._gdh_EventPrice;
      set
      {
        this._gdh_EventPrice = value;
        this.Changed(nameof (gdh_EventPrice));
      }
    }

    public double gdh_MemberPrice1
    {
      get => this._gdh_MemberPrice1;
      set
      {
        this._gdh_MemberPrice1 = value;
        this.Changed(nameof (gdh_MemberPrice1));
      }
    }

    public double gdh_MemberPrice2
    {
      get => this._gdh_MemberPrice2;
      set
      {
        this._gdh_MemberPrice2 = value;
        this.Changed(nameof (gdh_MemberPrice2));
      }
    }

    public double gdh_MemberPrice3
    {
      get => this._gdh_MemberPrice3;
      set
      {
        this._gdh_MemberPrice3 = value;
        this.Changed(nameof (gdh_MemberPrice3));
      }
    }

    public double gdh_PointRate
    {
      get => this._gdh_PointRate;
      set
      {
        this._gdh_PointRate = value;
        this.Changed(nameof (gdh_PointRate));
      }
    }

    public DateTime? gdh_InDate
    {
      get => this._gdh_InDate;
      set
      {
        this._gdh_InDate = value;
        this.Changed(nameof (gdh_InDate));
      }
    }

    public int gdh_InUser
    {
      get => this._gdh_InUser;
      set
      {
        this._gdh_InUser = value;
        this.Changed(nameof (gdh_InUser));
      }
    }

    public DateTime? gdh_ModDate
    {
      get => this._gdh_ModDate;
      set
      {
        this._gdh_ModDate = value;
        this.Changed(nameof (gdh_ModDate));
      }
    }

    public int gdh_ModUser
    {
      get => this._gdh_ModUser;
      set
      {
        this._gdh_ModUser = value;
        this.Changed(nameof (gdh_ModUser));
      }
    }

    public TGoodsHistory() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("gdh_StoreCode", new TTableColumn()
      {
        tc_orgin_name = "gdh_StoreCode",
        tc_trans_name = "지점코드"
      });
      columnInfo.Add("gdh_GoodsCode", new TTableColumn()
      {
        tc_orgin_name = "gdh_GoodsCode",
        tc_trans_name = "상품코드"
      });
      columnInfo.Add("gdh_StartDate", new TTableColumn()
      {
        tc_orgin_name = "gdh_StartDate",
        tc_trans_name = "시작일"
      });
      columnInfo.Add("gdh_SiteID", new TTableColumn()
      {
        tc_orgin_name = "gdh_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("gdh_EndDate", new TTableColumn()
      {
        tc_orgin_name = "gdh_EndDate",
        tc_trans_name = "종료일"
      });
      columnInfo.Add("gdh_GoodsCategory", new TTableColumn()
      {
        tc_orgin_name = "gdh_GoodsCategory",
        tc_trans_name = "소분류"
      });
      columnInfo.Add("gdh_Supplier", new TTableColumn()
      {
        tc_orgin_name = "gdh_Supplier",
        tc_trans_name = "업체"
      });
      columnInfo.Add("gdh_ChargeRate", new TTableColumn()
      {
        tc_orgin_name = "gdh_ChargeRate",
        tc_trans_name = "수수료율"
      });
      columnInfo.Add("gdh_BuyCost", new TTableColumn()
      {
        tc_orgin_name = "gdh_BuyCost",
        tc_trans_name = "매입원가"
      });
      columnInfo.Add("gdh_BuyVat", new TTableColumn()
      {
        tc_orgin_name = "gdh_BuyVat",
        tc_trans_name = "매입VAT"
      });
      columnInfo.Add("gdh_SalePrice", new TTableColumn()
      {
        tc_orgin_name = "gdh_SalePrice",
        tc_trans_name = "판매가"
      });
      columnInfo.Add("gdh_EventCost", new TTableColumn()
      {
        tc_orgin_name = "gdh_EventCost",
        tc_trans_name = "행사원가"
      });
      columnInfo.Add("gdh_EventVat", new TTableColumn()
      {
        tc_orgin_name = "gdh_EventVat",
        tc_trans_name = "행사VAT"
      });
      columnInfo.Add("gdh_EventPrice", new TTableColumn()
      {
        tc_orgin_name = "gdh_EventPrice",
        tc_trans_name = "행사판매가"
      });
      columnInfo.Add("gdh_MemberPrice1", new TTableColumn()
      {
        tc_orgin_name = "gdh_MemberPrice1",
        tc_trans_name = "회원가"
      });
      columnInfo.Add("gdh_MemberPrice2", new TTableColumn()
      {
        tc_orgin_name = "gdh_MemberPrice2",
        tc_trans_name = "회원가2"
      });
      columnInfo.Add("gdh_MemberPrice3", new TTableColumn()
      {
        tc_orgin_name = "gdh_MemberPrice3",
        tc_trans_name = "회원가3"
      });
      columnInfo.Add("gdh_PointRate", new TTableColumn()
      {
        tc_orgin_name = "gdh_PointRate",
        tc_trans_name = "회원특별적립율"
      });
      columnInfo.Add("gdh_InDate", new TTableColumn()
      {
        tc_orgin_name = "gdh_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("gdh_InUser", new TTableColumn()
      {
        tc_orgin_name = "gdh_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("gdh_ModDate", new TTableColumn()
      {
        tc_orgin_name = "gdh_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("gdh_ModUser", new TTableColumn()
      {
        tc_orgin_name = "gdh_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.GoodsHistory;
      this.gdh_StoreCode = 0;
      this.gdh_GoodsCode = 0L;
      this.gdh_StartDate = new DateTime?();
      this.gdh_SiteID = 0L;
      this.gdh_EndDate = new DateTime?();
      this.gdh_GoodsCategory = 0;
      this.gdh_Supplier = 0;
      this.gdh_ChargeRate = 0.0;
      this.gdh_BuyCost = this.gdh_BuyVat = this.gdh_SalePrice = 0.0;
      this.gdh_EventCost = this.gdh_EventVat = this.gdh_EventPrice = 0.0;
      this.gdh_MemberPrice1 = this.gdh_MemberPrice2 = this.gdh_MemberPrice3 = this.gdh_PointRate = 0.0;
      this.gdh_InDate = new DateTime?();
      this.gdh_InUser = 0;
      this.gdh_ModDate = new DateTime?();
      this.gdh_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TGoodsHistory();

    public override object Clone()
    {
      TGoodsHistory tgoodsHistory = base.Clone() as TGoodsHistory;
      tgoodsHistory.gdh_StoreCode = this.gdh_StoreCode;
      tgoodsHistory.gdh_GoodsCode = this.gdh_GoodsCode;
      tgoodsHistory.gdh_StartDate = this.gdh_StartDate;
      tgoodsHistory.gdh_SiteID = this.gdh_SiteID;
      tgoodsHistory.gdh_EndDate = this.gdh_EndDate;
      tgoodsHistory.gdh_GoodsCategory = this.gdh_GoodsCategory;
      tgoodsHistory.gdh_Supplier = this.gdh_Supplier;
      tgoodsHistory.gdh_ChargeRate = this.gdh_ChargeRate;
      tgoodsHistory.gdh_BuyCost = this.gdh_BuyCost;
      tgoodsHistory.gdh_BuyVat = this.gdh_BuyVat;
      tgoodsHistory.gdh_SalePrice = this.gdh_SalePrice;
      tgoodsHistory.gdh_EventCost = this.gdh_EventCost;
      tgoodsHistory.gdh_EventVat = this.gdh_EventVat;
      tgoodsHistory.gdh_EventPrice = this.gdh_EventPrice;
      tgoodsHistory.gdh_MemberPrice1 = this.gdh_MemberPrice1;
      tgoodsHistory.gdh_MemberPrice2 = this.gdh_MemberPrice2;
      tgoodsHistory.gdh_MemberPrice3 = this.gdh_MemberPrice3;
      tgoodsHistory.gdh_PointRate = this.gdh_PointRate;
      tgoodsHistory.gdh_InDate = this.gdh_InDate;
      tgoodsHistory.gdh_InUser = this.gdh_InUser;
      tgoodsHistory.gdh_ModDate = this.gdh_ModDate;
      tgoodsHistory.gdh_ModUser = this.gdh_ModUser;
      return (object) tgoodsHistory;
    }

    public void PutData(TGoodsHistory pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.gdh_StoreCode = pSource.gdh_StoreCode;
      this.gdh_GoodsCode = pSource.gdh_GoodsCode;
      this.gdh_StartDate = pSource.gdh_StartDate;
      this.gdh_SiteID = pSource.gdh_SiteID;
      this.gdh_EndDate = pSource.gdh_EndDate;
      this.gdh_GoodsCategory = pSource.gdh_GoodsCategory;
      this.gdh_Supplier = pSource.gdh_Supplier;
      this.gdh_ChargeRate = pSource.gdh_ChargeRate;
      this.gdh_BuyCost = pSource.gdh_BuyCost;
      this.gdh_BuyVat = pSource.gdh_BuyVat;
      this.gdh_SalePrice = pSource.gdh_SalePrice;
      this.gdh_EventCost = pSource.gdh_EventCost;
      this.gdh_EventVat = pSource.gdh_EventVat;
      this.gdh_EventPrice = pSource.gdh_EventPrice;
      this.gdh_MemberPrice1 = pSource.gdh_MemberPrice1;
      this.gdh_MemberPrice2 = pSource.gdh_MemberPrice2;
      this.gdh_MemberPrice3 = pSource.gdh_MemberPrice3;
      this.gdh_PointRate = pSource.gdh_PointRate;
      this.gdh_InDate = pSource.gdh_InDate;
      this.gdh_InUser = pSource.gdh_InUser;
      this.gdh_ModDate = pSource.gdh_ModDate;
      this.gdh_ModUser = pSource.gdh_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.gdh_StoreCode = p_rs.GetFieldInt("gdh_StoreCode");
        this.gdh_GoodsCode = p_rs.GetFieldLong("gdh_GoodsCode");
        if (this.gdh_GoodsCode == 0L)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.gdh_StartDate = p_rs.GetFieldDateTime("gdh_StartDate");
        this.gdh_SiteID = p_rs.GetFieldLong("gdh_SiteID");
        this.gdh_EndDate = p_rs.GetFieldDateTime("gdh_EndDate");
        this.gdh_GoodsCategory = p_rs.GetFieldInt("gdh_GoodsCategory");
        this.gdh_Supplier = p_rs.GetFieldInt("gdh_Supplier");
        this.gdh_ChargeRate = p_rs.GetFieldDouble("gdh_ChargeRate");
        this.gdh_BuyCost = p_rs.GetFieldDouble("gdh_BuyCost");
        this.gdh_BuyVat = p_rs.GetFieldDouble("gdh_BuyVat");
        this.gdh_SalePrice = p_rs.GetFieldDouble("gdh_SalePrice");
        this.gdh_EventCost = p_rs.GetFieldDouble("gdh_EventCost");
        this.gdh_EventVat = p_rs.GetFieldDouble("gdh_EventVat");
        this.gdh_EventPrice = p_rs.GetFieldDouble("gdh_EventPrice");
        this.gdh_MemberPrice1 = p_rs.GetFieldDouble("gdh_MemberPrice1");
        this.gdh_MemberPrice2 = p_rs.GetFieldDouble("gdh_MemberPrice2");
        this.gdh_MemberPrice3 = p_rs.GetFieldDouble("gdh_MemberPrice3");
        this.gdh_PointRate = p_rs.GetFieldDouble("gdh_PointRate");
        this.gdh_InDate = p_rs.GetFieldDateTime("gdh_InDate");
        this.gdh_InUser = p_rs.GetFieldInt("gdh_InUser");
        this.gdh_ModDate = p_rs.GetFieldDateTime("gdh_ModDate");
        this.gdh_ModUser = p_rs.GetFieldInt("gdh_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " gdh_StoreCode,gdh_GoodsCode,gdh_StartDate,gdh_SiteID,gdh_EndDate,gdh_GoodsCategory,gdh_Supplier,gdh_ChargeRate,gdh_BuyCost,gdh_BuyVat,gdh_SalePrice,gdh_EventCost,gdh_EventVat,gdh_EventPrice,gdh_MemberPrice1,gdh_MemberPrice2,gdh_MemberPrice3,gdh_PointRate,gdh_InDate,gdh_InUser,gdh_ModDate,gdh_ModUser) VALUES ( " + string.Format(" {0},{1},'{2}'", (object) this.gdh_StoreCode, (object) this.gdh_GoodsCode, (object) this.gdh_StartDate.GetDateToStr("yyyy-MM-dd 00:00:00")) + string.Format(",{0}", (object) this.gdh_SiteID) + ",'" + this.gdh_EndDate.GetDateToStr("yyyy-MM-dd 23:59:59") + "'" + string.Format(",{0},{1}", (object) this.gdh_GoodsCategory, (object) this.gdh_Supplier) + "," + this.gdh_ChargeRate.FormatTo("{0:0.0000}") + "," + this.gdh_BuyCost.FormatTo("{0:0.0000}") + "," + this.gdh_BuyVat.FormatTo("{0:0.0000}") + "," + this.gdh_SalePrice.FormatTo("{0:0.0000}") + "," + this.gdh_EventCost.FormatTo("{0:0.0000}") + "," + this.gdh_EventVat.FormatTo("{0:0.0000}") + "," + this.gdh_EventPrice.FormatTo("{0:0.0000}") + "," + this.gdh_MemberPrice1.FormatTo("{0:0.0000}") + "," + this.gdh_MemberPrice2.FormatTo("{0:0.0000}") + "," + this.gdh_MemberPrice3.FormatTo("{0:0.0000}") + "," + this.gdh_PointRate.FormatTo("{0:0.0000}") + string.Format(",{0},{1}", (object) this.gdh_InDate.GetDateToStrInNull(), (object) this.gdh_InUser) + string.Format(",{0},{1}", (object) this.gdh_ModDate.GetDateToStrInNull(), (object) this.gdh_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.gdh_StoreCode, (object) this.gdh_GoodsCode, (object) this.IntStartDate, (object) this.gdh_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TGoodsHistory tgoodsHistory = this;
      // ISSUE: reference to a compiler-generated method
      tgoodsHistory.\u003C\u003En__0();
      if (await tgoodsHistory.OleDB.ExecuteAsync(tgoodsHistory.InsertQuery()))
        return true;
      tgoodsHistory.message = " " + tgoodsHistory.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tgoodsHistory.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tgoodsHistory.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tgoodsHistory.gdh_StoreCode, (object) tgoodsHistory.gdh_GoodsCode, (object) tgoodsHistory.IntStartDate, (object) tgoodsHistory.gdh_SiteID) + " 내용 : " + tgoodsHistory.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tgoodsHistory.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " gdh_EndDate='" + this.gdh_EndDate.GetDateToStr("yyyy-MM-dd 23:59:59") + "'" + string.Format(",{0}={1},{2}={3}", (object) "gdh_GoodsCategory", (object) this.gdh_GoodsCategory, (object) "gdh_Supplier", (object) this.gdh_Supplier) + ",gdh_ChargeRate=" + this.gdh_ChargeRate.FormatTo("{0:0.0000}") + ",gdh_BuyCost=" + this.gdh_BuyCost.FormatTo("{0:0.0000}") + ",gdh_BuyVat=" + this.gdh_BuyVat.FormatTo("{0:0.0000}") + ",gdh_SalePrice=" + this.gdh_SalePrice.FormatTo("{0:0.0000}") + ",gdh_EventCost=" + this.gdh_EventCost.FormatTo("{0:0.0000}") + ",gdh_EventVat=" + this.gdh_EventVat.FormatTo("{0:0.0000}") + ",gdh_EventPrice=" + this.gdh_EventPrice.FormatTo("{0:0.0000}") + ",gdh_MemberPrice1=" + this.gdh_MemberPrice1.FormatTo("{0:0.0000}") + ",gdh_MemberPrice2=" + this.gdh_MemberPrice2.FormatTo("{0:0.0000}") + ",gdh_MemberPrice3=" + this.gdh_MemberPrice3.FormatTo("{0:0.0000}") + ",gdh_PointRate=" + this.gdh_PointRate.FormatTo("{0:0.0000}") + string.Format(",{0}={1},{2}={3}", (object) "gdh_ModDate", (object) this.gdh_ModDate.GetDateToStrInNull(), (object) "gdh_ModUser", (object) this.gdh_ModUser) + string.Format(" WHERE {0}={1}", (object) "gdh_StoreCode", (object) this.gdh_StoreCode) + string.Format(" AND {0}={1}", (object) "gdh_GoodsCode", (object) this.gdh_GoodsCode) + " AND gdh_StartDate='" + this.gdh_StartDate.GetDateToStr("yyyy-MM-dd 00:00:00") + "'" + string.Format(" AND {0}={1}", (object) "gdh_SiteID", (object) this.gdh_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.gdh_StoreCode, (object) this.gdh_GoodsCode, (object) this.IntStartDate, (object) this.gdh_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TGoodsHistory tgoodsHistory = this;
      // ISSUE: reference to a compiler-generated method
      tgoodsHistory.\u003C\u003En__1();
      if (await tgoodsHistory.OleDB.ExecuteAsync(tgoodsHistory.UpdateQuery()))
        return true;
      tgoodsHistory.message = " " + tgoodsHistory.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tgoodsHistory.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tgoodsHistory.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tgoodsHistory.gdh_StoreCode, (object) tgoodsHistory.gdh_GoodsCode, (object) tgoodsHistory.IntStartDate, (object) tgoodsHistory.gdh_SiteID) + " 내용 : " + tgoodsHistory.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tgoodsHistory.message);
      return false;
    }

    public string UpdateEndDateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " gdh_EndDate='" + this.gdh_EndDate.GetDateToStr("yyyy-MM-dd 23:59:59") + "'" + string.Format(",{0}={1},{2}={3}", (object) "gdh_ModDate", (object) this.gdh_ModDate.GetDateToStrInNull(), (object) "gdh_ModUser", (object) this.gdh_ModUser) + string.Format(" WHERE {0}={1}", (object) "gdh_StoreCode", (object) this.gdh_StoreCode) + string.Format(" AND {0}={1}", (object) "gdh_GoodsCode", (object) this.gdh_GoodsCode) + " AND gdh_StartDate='" + this.gdh_StartDate.GetDateToStr("yyyy-MM-dd 00:00:00") + "'" + string.Format(" AND {0}={1}", (object) "gdh_SiteID", (object) this.gdh_SiteID);

    public bool UpdateEndDate()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateEndDateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.gdh_StoreCode, (object) this.gdh_GoodsCode, (object) this.IntStartDate, (object) this.gdh_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public async Task<bool> UpdateEndDateAsync()
    {
      TGoodsHistory tgoodsHistory = this;
      // ISSUE: reference to a compiler-generated method
      tgoodsHistory.\u003C\u003En__1();
      if (await tgoodsHistory.OleDB.ExecuteAsync(tgoodsHistory.UpdateEndDateQuery()))
        return true;
      tgoodsHistory.message = " " + tgoodsHistory.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tgoodsHistory.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tgoodsHistory.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tgoodsHistory.gdh_StoreCode, (object) tgoodsHistory.gdh_GoodsCode, (object) tgoodsHistory.IntStartDate, (object) tgoodsHistory.gdh_SiteID) + " 내용 : " + tgoodsHistory.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tgoodsHistory.message);
      return false;
    }

    public string UpdateStartDateQuery(
      int p_gdh_StoreCode,
      long p_gdh_GoodsCode,
      DateTime p_gdh_StartDate,
      DateTime pModStartDate,
      long p_gdh_SiteID = 0)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode));
      stringBuilder.Append(" gdh_StartDate='" + new DateTime?(pModStartDate).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
      stringBuilder.Append(",gdh_ModDate=" + this.gdh_ModDate.GetDateToStrInNull());
      stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "gdh_StoreCode", (object) p_gdh_StoreCode));
      stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gdh_GoodsCode", (object) p_gdh_GoodsCode));
      stringBuilder.Append(" AND gdh_StartDate='" + new DateTime?(p_gdh_StartDate).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
      if (p_gdh_SiteID > 0L)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gdh_SiteID", (object) p_gdh_SiteID));
      return stringBuilder.ToString();
    }

    public bool UpdateStartDate(
      int p_gdh_StoreCode,
      long p_gdh_GoodsCode,
      DateTime p_gdh_StartDate,
      DateTime pModStartDate,
      long p_gdh_SiteID = 0)
    {
      this.UpdateChecked();
      this.gdh_ModDate = new DateTime?(DateTime.Now);
      if (this.OleDB.Execute(this.UpdateStartDateQuery(p_gdh_StoreCode, p_gdh_GoodsCode, p_gdh_StartDate, pModStartDate, p_gdh_SiteID)))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2}) => {3},{4})\n", (object) p_gdh_StoreCode, (object) p_gdh_GoodsCode, (object) new DateTime?(p_gdh_StartDate).GetDateToStr("yyyy-MM-dd"), (object) new DateTime?(pModStartDate).GetDateToStr("yyyy-MM-dd"), (object) p_gdh_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public async Task<bool> UpdateStartDateAsync(
      int p_gdh_StoreCode,
      long p_gdh_GoodsCode,
      DateTime p_gdh_StartDate,
      DateTime pModStartDate,
      long p_gdh_SiteID = 0)
    {
      TGoodsHistory tgoodsHistory = this;
      // ISSUE: reference to a compiler-generated method
      tgoodsHistory.\u003C\u003En__1();
      tgoodsHistory.gdh_ModDate = new DateTime?(DateTime.Now);
      if (await tgoodsHistory.OleDB.ExecuteAsync(tgoodsHistory.UpdateStartDateQuery(p_gdh_StoreCode, p_gdh_GoodsCode, p_gdh_StartDate, pModStartDate, p_gdh_SiteID)))
        return true;
      tgoodsHistory.message = " " + tgoodsHistory.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tgoodsHistory.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tgoodsHistory.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2}) => {3},{4})\n", (object) p_gdh_StoreCode, (object) p_gdh_GoodsCode, (object) new DateTime?(p_gdh_StartDate).GetDateToStr("yyyy-MM-dd"), (object) new DateTime?(pModStartDate).GetDateToStr("yyyy-MM-dd"), (object) p_gdh_SiteID) + " 내용 : " + tgoodsHistory.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tgoodsHistory.message);
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
      stringBuilder.Append(" gdh_EndDate='" + this.gdh_EndDate.GetDateToStr("yyyy-MM-dd 23:59:59") + "'" + string.Format(",{0}={1},{2}={3}", (object) "gdh_GoodsCategory", (object) this.gdh_GoodsCategory, (object) "gdh_Supplier", (object) this.gdh_Supplier) + ",gdh_ChargeRate=" + this.gdh_ChargeRate.FormatTo("{0:0.0000}") + ",gdh_BuyCost=" + this.gdh_BuyCost.FormatTo("{0:0.0000}") + ",gdh_BuyVat=" + this.gdh_BuyVat.FormatTo("{0:0.0000}") + ",gdh_SalePrice=" + this.gdh_SalePrice.FormatTo("{0:0.0000}") + ",gdh_EventCost=" + this.gdh_EventCost.FormatTo("{0:0.0000}") + ",gdh_EventVat=" + this.gdh_EventVat.FormatTo("{0:0.0000}") + ",gdh_EventPrice=" + this.gdh_EventPrice.FormatTo("{0:0.0000}") + ",gdh_MemberPrice1=" + this.gdh_MemberPrice1.FormatTo("{0:0.0000}") + ",gdh_MemberPrice2=" + this.gdh_MemberPrice2.FormatTo("{0:0.0000}") + ",gdh_MemberPrice3=" + this.gdh_MemberPrice3.FormatTo("{0:0.0000}") + ",gdh_PointRate=" + this.gdh_PointRate.FormatTo("{0:0.0000}") + string.Format(",{0}={1},{2}={3}", (object) "gdh_ModDate", (object) this.gdh_ModDate.GetDateToStrInNull(), (object) "gdh_ModUser", (object) this.gdh_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.gdh_StoreCode, (object) this.gdh_GoodsCode, (object) this.IntStartDate, (object) this.gdh_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TGoodsHistory tgoodsHistory = this;
      // ISSUE: reference to a compiler-generated method
      tgoodsHistory.\u003C\u003En__1();
      if (await tgoodsHistory.OleDB.ExecuteAsync(tgoodsHistory.UpdateExInsertQuery()))
        return true;
      tgoodsHistory.message = " " + tgoodsHistory.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tgoodsHistory.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tgoodsHistory.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tgoodsHistory.gdh_StoreCode, (object) tgoodsHistory.gdh_GoodsCode, (object) tgoodsHistory.IntStartDate, (object) tgoodsHistory.gdh_SiteID) + " 내용 : " + tgoodsHistory.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tgoodsHistory.message);
      return false;
    }

    public override string DeleteQuery() => string.Format(" DELETE FROM {0}{1}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + string.Format(" WHERE {0}={1}", (object) "gdh_StoreCode", (object) this.gdh_StoreCode) + string.Format(" AND {0}={1}", (object) "gdh_GoodsCode", (object) this.gdh_GoodsCode) + " AND gdh_StartDate='" + this.gdh_StartDate.GetDateToStr("yyyy-MM-dd 00:00:00") + "'" + string.Format(" AND {0}={1}", (object) "gdh_SiteID", (object) this.gdh_SiteID);

    public override bool Delete()
    {
      this.InsertChecked();
      string pStrExec = this.DeleteQuery();
      if (this.OleDB.Execute(pStrExec))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 삭제 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.gdh_StoreCode, (object) this.gdh_GoodsCode, (object) this.IntStartDate, (object) this.gdh_SiteID) + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n 쿼리 : " + pStrExec + "\n--------------------------------------------------------------------------------------------------\n";
      return false;
    }

    public override async Task<bool> DeleteAsync()
    {
      TGoodsHistory tgoodsHistory = this;
      // ISSUE: reference to a compiler-generated method
      tgoodsHistory.\u003C\u003En__0();
      if (await tgoodsHistory.OleDB.ExecuteAsync(tgoodsHistory.DeleteQuery()))
        return true;
      tgoodsHistory.message = " " + tgoodsHistory.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tgoodsHistory.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tgoodsHistory.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tgoodsHistory.gdh_StoreCode, (object) tgoodsHistory.gdh_GoodsCode, (object) tgoodsHistory.IntStartDate, (object) tgoodsHistory.gdh_SiteID) + " 내용 : " + tgoodsHistory.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tgoodsHistory.message);
      return false;
    }

    public virtual string DeleteQuery(
      int p_gdh_StoreCode,
      long p_gdh_GoodsCode,
      DateTime p_gdh_StartDate,
      long p_gdh_SiteID = 0)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format(" DELETE FROM {0}{1} ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode));
      stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "gdh_StoreCode", (object) p_gdh_StoreCode));
      stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gdh_GoodsCode", (object) p_gdh_GoodsCode));
      stringBuilder.Append(" AND gdh_StartDate='" + new DateTime?(p_gdh_StartDate).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
      if (p_gdh_SiteID > 0L)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gdh_SiteID", (object) p_gdh_SiteID));
      return stringBuilder.ToString();
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        DateTime? p_day = new DateTime?();
        if (hashtable.ContainsKey((object) "_DT_DATE_") && hashtable[(object) "_DT_DATE_"].ToString().Length > 0)
          p_day = new DateTime?(Convert.ToDateTime(hashtable[(object) "_DT_DATE_"].ToString()));
        int pValue = 0;
        if (hashtable.ContainsKey((object) "_GoodsHistoryDiv_") && Convert.ToInt32(hashtable[(object) "_GoodsHistoryDiv_"].ToString()) > 0)
          pValue = Convert.ToInt32(hashtable[(object) "_GoodsHistoryDiv_"].ToString());
        if (pValue > 0 && !p_day.HasValue)
          p_day = new DateTime?(DateTime.Now);
        if (hashtable.ContainsKey((object) "gdh_SiteID") && Convert.ToInt64(hashtable[(object) "gdh_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "gdh_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "si_StoreCode") && Convert.ToInt32(hashtable[(object) "si_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gdh_StoreCode", hashtable[(object) "si_StoreCode"]));
        else if (hashtable.ContainsKey((object) "gdh_StoreCode") && Convert.ToInt32(hashtable[(object) "gdh_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gdh_StoreCode", hashtable[(object) "gdh_StoreCode"]));
        else if (hashtable.ContainsKey((object) "si_StoreCode_IN_") && hashtable[(object) "si_StoreCode_IN_"].ToString().Length > 0)
        {
          if (hashtable[(object) "si_StoreCode_IN_"].ToString().Contains(","))
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "gdh_StoreCode", hashtable[(object) "si_StoreCode_IN_"]));
          else
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gdh_StoreCode", hashtable[(object) "si_StoreCode_IN_"]));
        }
        else if (hashtable.ContainsKey((object) "gdh_StoreCode_IN_") && hashtable[(object) "gdh_StoreCode_IN_"].ToString().Length > 0)
        {
          if (hashtable[(object) "gdh_StoreCode_IN_"].ToString().Contains(","))
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "gdh_StoreCode", hashtable[(object) "gdh_StoreCode_IN_"]));
          else
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gdh_StoreCode", hashtable[(object) "gdh_StoreCode_IN_"]));
        }
        else if (hashtable.ContainsKey((object) "_STORE_AUTHS_") && hashtable[(object) "_STORE_AUTHS_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "gdh_StoreCode", hashtable[(object) "_STORE_AUTHS_"]));
        if (hashtable.ContainsKey((object) "gdh_GoodsCode") && Convert.ToInt64(hashtable[(object) "gdh_GoodsCode"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gdh_GoodsCode", hashtable[(object) "gdh_GoodsCode"]));
        else if (hashtable.ContainsKey((object) "gdh_GoodsCode_IN_") && hashtable[(object) "gdh_GoodsCode_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "gdh_GoodsCode", hashtable[(object) "gdh_GoodsCode_IN_"]));
        else
          stringBuilder.Append(" AND gdh_GoodsCode>0");
        if (hashtable.ContainsKey((object) "gdh_StartDate") && hashtable[(object) "gdh_StartDate"].ToString().Length > 0)
        {
          stringBuilder.Append(" AND gdh_StartDate <='" + new DateTime?((DateTime) hashtable[(object) "gdh_StartDate"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND gdh_StartDate >='" + new DateTime?((DateTime) hashtable[(object) "gdh_StartDate"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
        }
        if (hashtable.ContainsKey((object) "_DT_DATE_"))
        {
          stringBuilder.Append(" AND gdh_StartDate <='" + new DateTime?((DateTime) hashtable[(object) "_DT_DATE_"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND gdh_EndDate >='" + new DateTime?((DateTime) hashtable[(object) "_DT_DATE_"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
        }
        if (hashtable.ContainsKey((object) "_DT_START_DATE_") && hashtable.ContainsKey((object) "_DT_END_DATE_"))
        {
          string dateToStr1 = new DateTime?((DateTime) hashtable[(object) "_DT_START_DATE_"]).GetDateToStr("yyyy-MM-dd 00:00:00");
          string dateToStr2 = new DateTime?((DateTime) hashtable[(object) "_DT_START_DATE_"]).GetDateToStr("yyyy-MM-dd 23:59:59");
          string dateToStr3 = new DateTime?((DateTime) hashtable[(object) "_DT_END_DATE_"]).GetDateToStr("yyyy-MM-dd 00:00:00");
          string dateToStr4 = new DateTime?((DateTime) hashtable[(object) "_DT_END_DATE_"]).GetDateToStr("yyyy-MM-dd 23:59:59");
          stringBuilder.Append(" AND (");
          stringBuilder.Append(" (gdh_StartDate <= '" + dateToStr1 + "' AND gdh_EndDate >= '" + dateToStr2 + "' )");
          stringBuilder.Append(" OR (gdh_StartDate <= '" + dateToStr3 + "' AND gdh_EndDate >= '" + dateToStr4 + "' )");
          stringBuilder.Append(" OR (gdh_StartDate >= '" + dateToStr1 + "' AND gdh_EndDate <= '" + dateToStr4 + "' )");
          stringBuilder.Append(") ");
        }
        if (pValue > 0)
        {
          switch (Enum2StrConverter.ToGoodsHistoryDiv(pValue))
          {
            case EnumGoodsHistoryDiv.HISTORY_START:
              stringBuilder.Append(" AND gdh_StartDate <='" + p_day.GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
              stringBuilder.Append(" AND gdh_StartDate >='" + p_day.GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
              break;
            case EnumGoodsHistoryDiv.EVENT_START:
              stringBuilder.Append(" AND gdh_StartDate <='" + p_day.GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
              stringBuilder.Append(" AND gdh_StartDate >='" + p_day.GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
              stringBuilder.Append(" AND gdh_EventPrice > 0");
              break;
            case EnumGoodsHistoryDiv.EVENT_ING:
              stringBuilder.Append(" AND gdh_StartDate <='" + p_day.GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
              stringBuilder.Append(" AND gdh_EndDate >='" + p_day.GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
              stringBuilder.Append(" AND gdh_EventPrice > 0");
              break;
            case EnumGoodsHistoryDiv.MEMBER1_START:
              stringBuilder.Append(" AND gdh_StartDate <='" + p_day.GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
              stringBuilder.Append(" AND gdh_StartDate >='" + p_day.GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
              stringBuilder.Append(" AND gdh_MemberPrice1 > 0");
              break;
            case EnumGoodsHistoryDiv.MEMBER1_ING:
              stringBuilder.Append(" AND gdh_StartDate <='" + p_day.GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
              stringBuilder.Append(" AND gdh_EndDate >='" + p_day.GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
              stringBuilder.Append(" AND gdh_MemberPrice1 > 0");
              break;
            case EnumGoodsHistoryDiv.MEMBER2_START:
              stringBuilder.Append(" AND gdh_StartDate <='" + p_day.GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
              stringBuilder.Append(" AND gdh_StartDate >='" + p_day.GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
              stringBuilder.Append(" AND gdh_MemberPrice2 > 0");
              break;
            case EnumGoodsHistoryDiv.MEMBER2_ING:
              stringBuilder.Append(" AND gdh_StartDate <='" + p_day.GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
              stringBuilder.Append(" AND gdh_EndDate >='" + p_day.GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
              stringBuilder.Append(" AND gdh_MemberPrice2 > 0");
              break;
            case EnumGoodsHistoryDiv.MEMBER3_START:
              stringBuilder.Append(" AND gdh_StartDate <='" + p_day.GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
              stringBuilder.Append(" AND gdh_StartDate >='" + p_day.GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
              stringBuilder.Append(" AND gdh_MemberPrice3 > 0");
              break;
            case EnumGoodsHistoryDiv.MEMBER3_ING:
              stringBuilder.Append(" AND gdh_StartDate <='" + p_day.GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
              stringBuilder.Append(" AND gdh_EndDate >='" + p_day.GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
              stringBuilder.Append(" AND gdh_MemberPrice3 > 0");
              break;
            default:
              stringBuilder.Append(" AND gdh_StartDate <='" + p_day.GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
              stringBuilder.Append(" AND gdh_EndDate >='" + p_day.GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
              break;
          }
        }
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gdh_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "gdh_GoodsCategory") && Convert.ToInt32(hashtable[(object) "gdh_GoodsCategory"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gdh_GoodsCategory", hashtable[(object) "gdh_GoodsCategory"]));
        else if (hashtable.ContainsKey((object) "gdh_GoodsCategory_IN_") && hashtable[(object) "gdh_GoodsCategory_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "gdh_GoodsCategory", hashtable[(object) "gdh_GoodsCategory_IN_"]));
        if (hashtable.ContainsKey((object) "gdh_Supplier") && Convert.ToInt32(hashtable[(object) "gdh_Supplier"].ToString()) > 0)
        {
          if (hashtable.ContainsKey((object) "_IS_REPRESENTATIVE_INCLUDE_SUPPLIER_") && Convert.ToBoolean(hashtable[(object) "_IS_REPRESENTATIVE_INCLUDE_SUPPLIER_"].ToString()))
            stringBuilder.Append(string.Format(" AND {0} IN ({1},{2})", (object) "gdh_Supplier", (object) 1001, hashtable[(object) "gdh_Supplier"]));
          else
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gdh_Supplier", hashtable[(object) "gdh_Supplier"]));
        }
        else if (hashtable.ContainsKey((object) "gdh_Supplier_IN_") && hashtable[(object) "gdh_Supplier_IN_"].ToString().Length > 0)
        {
          if (hashtable.ContainsKey((object) "_IS_REPRESENTATIVE_INCLUDE_SUPPLIER_") && Convert.ToBoolean(hashtable[(object) "_IS_REPRESENTATIVE_INCLUDE_SUPPLIER_"].ToString()))
            stringBuilder.Append(string.Format(" AND {0} IN ({1},{2})", (object) "gdh_Supplier", (object) 1001, hashtable[(object) "gdh_Supplier_IN_"]));
          else
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "gdh_Supplier", hashtable[(object) "gdh_Supplier_IN_"]));
        }
        else if (hashtable.ContainsKey((object) "_SUPPLIER_AUTHS_") && hashtable[(object) "_SUPPLIER_AUTHS_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "gdh_Supplier", hashtable[(object) "_SUPPLIER_AUTHS_"]));
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
        stringBuilder.Append(" SELECT  gdh_StoreCode,gdh_GoodsCode,gdh_StartDate,gdh_SiteID,gdh_EndDate,gdh_GoodsCategory,gdh_Supplier,gdh_ChargeRate,gdh_BuyCost,gdh_BuyVat,gdh_SalePrice,gdh_EventCost,gdh_EventVat,gdh_EventPrice,gdh_MemberPrice1,gdh_MemberPrice2,gdh_MemberPrice3,gdh_PointRate,gdh_InDate,gdh_InUser,gdh_ModDate,gdh_ModUser");
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
