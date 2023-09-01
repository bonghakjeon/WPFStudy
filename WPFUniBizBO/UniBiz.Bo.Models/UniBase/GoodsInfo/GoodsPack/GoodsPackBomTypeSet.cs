// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsPack.GoodsPackBomTypeSet
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
using UniBiz.Bo.Models.TableInfo;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsPack
{
  public class GoodsPackBomTypeSet : TGoodsPack<GoodsPackBomTypeSet>
  {
    private int _gd_TaxDiv;
    private int _gd_SalesUnit;
    private int _gd_StockUnit;
    private double _gdh_BuyCost;
    private double _gdh_BuyVat;
    private double _gdh_SalePrice;
    private double _gdh_EventCost;
    private double _gdh_EventVat;
    private double _gdh_EventPrice;
    private double _gdh_BuyCostRate;
    private double _gdh_SalePriceRate;
    private double _gdh_ChargeRate;
    private bool _IsLastIdx;
    private IList<GoodsPackBomTypeSet> _Lt_Details;

    public int gd_TaxDiv
    {
      get => this._gd_TaxDiv;
      set
      {
        this._gd_TaxDiv = value;
        this.Changed(nameof (gd_TaxDiv));
        this.Changed("gd_TaxDivDesc");
        this.Changed("gd_IsTax");
      }
    }

    public string gd_TaxDivDesc => this.gd_TaxDiv != 0 ? Enum2StrConverter.ToTaxDiv(this.gd_TaxDiv).ToDescription() : string.Empty;

    public bool gd_IsTax => Enum2StrConverter.ToTaxDiv(this.gd_TaxDiv) == EnumTaxDiv.TAX;

    public int gd_SalesUnit
    {
      get => this._gd_SalesUnit;
      set
      {
        this._gd_SalesUnit = value;
        this.Changed(nameof (gd_SalesUnit));
        this.Changed("gd_SalesUnitDesc");
      }
    }

    public string gd_SalesUnitDesc => this.gd_SalesUnit != 0 ? Enum2StrConverter.ToSalesUnit(this.gd_SalesUnit).ToDescription() : string.Empty;

    public int gd_StockUnit
    {
      get => this._gd_StockUnit;
      set
      {
        this._gd_StockUnit = value;
        this.Changed(nameof (gd_StockUnit));
        this.Changed("gd_StockUnitDesc");
      }
    }

    public string gd_StockUnitDesc => this.gd_StockUnit != 0 ? Enum2StrConverter.ToStockUnit(this.gd_StockUnit).ToDescription() : string.Empty;

    public double gdh_BuyCost
    {
      get => this._gdh_BuyCost;
      set
      {
        this._gdh_BuyCost = value;
        this.Changed(nameof (gdh_BuyCost));
        this.Changed("gdh_BuyTaxPrice");
      }
    }

    public double gdh_BuyVat
    {
      get => this._gdh_BuyVat;
      set
      {
        this._gdh_BuyVat = value;
        this.Changed(nameof (gdh_BuyVat));
        this.Changed("gdh_BuyTaxPrice");
      }
    }

    public double gdh_BuyTaxPrice => this.gdh_BuyCost + this.gdh_BuyVat;

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
        this.Changed("gdh_EventBuyTaxPrice");
      }
    }

    public double gdh_EventVat
    {
      get => this._gdh_EventVat;
      set
      {
        this._gdh_EventVat = value;
        this.Changed(nameof (gdh_EventVat));
        this.Changed("gdh_EventBuyTaxPrice");
      }
    }

    public double gdh_EventBuyTaxPrice => this.gdh_EventCost + this.gdh_EventVat;

    public double gdh_EventPrice
    {
      get => this._gdh_EventPrice;
      set
      {
        this._gdh_EventPrice = value;
        this.Changed(nameof (gdh_EventPrice));
      }
    }

    public double gdh_BuyCostRate
    {
      get => this._gdh_BuyCostRate;
      set
      {
        this._gdh_BuyCostRate = value;
        this.Changed(nameof (gdh_BuyCostRate));
      }
    }

    public double gdh_SalePriceRate
    {
      get => this._gdh_SalePriceRate;
      set
      {
        this._gdh_SalePriceRate = value;
        this.Changed(nameof (gdh_SalePriceRate));
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

    [JsonPropertyName("isLastIdx")]
    public bool IsLastIdx
    {
      get => this._IsLastIdx;
      set
      {
        this._IsLastIdx = value;
        this.Changed(nameof (IsLastIdx));
      }
    }

    public IList<GoodsPackBomTypeSet> Lt_Details
    {
      get => this._Lt_Details ?? (this._Lt_Details = (IList<GoodsPackBomTypeSet>) new List<GoodsPackBomTypeSet>());
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
      this.gd_TaxDiv = this.gd_SalesUnit = this.gd_StockUnit = 0;
      this.gdh_BuyCost = this.gdh_BuyVat = this.gdh_EventCost = this.gdh_EventVat = this.gdh_SalePrice = this.gdh_EventPrice = 0.0;
      this.gdh_ChargeRate = 0.0;
      this.gdh_BuyCostRate = this.gdh_SalePriceRate = 0.0;
      this.IsLastIdx = false;
      this.Lt_Details = (IList<GoodsPackBomTypeSet>) null;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new GoodsPackBomTypeSet();

    public override object Clone()
    {
      GoodsPackBomTypeSet goodsPackBomTypeSet = base.Clone() as GoodsPackBomTypeSet;
      goodsPackBomTypeSet.gd_TaxDiv = this.gd_TaxDiv;
      goodsPackBomTypeSet.gd_SalesUnit = this.gd_SalesUnit;
      goodsPackBomTypeSet.gd_StockUnit = this.gd_StockUnit;
      goodsPackBomTypeSet.gdh_BuyCost = this.gdh_BuyCost;
      goodsPackBomTypeSet.gdh_BuyVat = this.gdh_BuyVat;
      goodsPackBomTypeSet.gdh_EventCost = this.gdh_EventCost;
      goodsPackBomTypeSet.gdh_EventVat = this.gdh_EventVat;
      goodsPackBomTypeSet.gdh_SalePrice = this.gdh_SalePrice;
      goodsPackBomTypeSet.gdh_EventPrice = this.gdh_EventPrice;
      goodsPackBomTypeSet.gdh_ChargeRate = this.gdh_ChargeRate;
      goodsPackBomTypeSet.gdh_BuyCostRate = this.gdh_BuyCostRate;
      goodsPackBomTypeSet.gdh_SalePriceRate = this.gdh_SalePriceRate;
      goodsPackBomTypeSet.IsLastIdx = this.IsLastIdx;
      goodsPackBomTypeSet.Lt_Details = this.Lt_Details;
      return (object) goodsPackBomTypeSet;
    }

    public void PutData(GoodsPackBomTypeSet pSource)
    {
      this.PutData((TGoodsPack) pSource);
      this.gd_TaxDiv = pSource.gd_TaxDiv;
      this.gd_SalesUnit = pSource.gd_SalesUnit;
      this.gd_StockUnit = pSource.gd_StockUnit;
      this.gdh_BuyCost = pSource.gdh_BuyCost;
      this.gdh_BuyVat = pSource.gdh_BuyVat;
      this.gdh_EventCost = pSource.gdh_EventCost;
      this.gdh_EventVat = pSource.gdh_EventVat;
      this.gdh_SalePrice = pSource.gdh_SalePrice;
      this.gdh_EventPrice = pSource.gdh_EventPrice;
      this.gdh_ChargeRate = pSource.gdh_ChargeRate;
      this.gdh_BuyCostRate = pSource.gdh_BuyCostRate;
      this.gdh_SalePriceRate = pSource.gdh_SalePriceRate;
      this.IsLastIdx = pSource.IsLastIdx;
      this.Lt_Details = (IList<GoodsPackBomTypeSet>) null;
      if (pSource.Lt_Details.Count <= 0)
        return;
      foreach (GoodsPackBomTypeSet ltDetail in (IEnumerable<GoodsPackBomTypeSet>) pSource.Lt_Details)
      {
        GoodsPackBomTypeSet goodsPackBomTypeSet = new GoodsPackBomTypeSet();
        goodsPackBomTypeSet.PutData(ltDetail);
        this.Lt_Details.Add(goodsPackBomTypeSet);
      }
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs) => base.GetFieldValues(p_rs);

    public async Task<IList<GoodsPackBomTypeSet>> SelectListAsync(object p_param)
    {
      GoodsPackBomTypeSet goodsPackBomTypeSet1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(goodsPackBomTypeSet1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, goodsPackBomTypeSet1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(goodsPackBomTypeSet1.GetSelectQuery(p_param)))
        {
          goodsPackBomTypeSet1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + goodsPackBomTypeSet1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<GoodsPackBomTypeSet>) null;
        }
        IList<GoodsPackBomTypeSet> lt_list = (IList<GoodsPackBomTypeSet>) new List<GoodsPackBomTypeSet>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            GoodsPackBomTypeSet goodsPackBomTypeSet2 = goodsPackBomTypeSet1.OleDB.Create<GoodsPackBomTypeSet>();
            if (goodsPackBomTypeSet2.GetFieldValues(rs))
            {
              goodsPackBomTypeSet2.row_number = lt_list.Count + 1;
              lt_list.Add(goodsPackBomTypeSet2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + goodsPackBomTypeSet1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<GoodsPackBomTypeSet> SelectEnumerableAsync(object p_param)
    {
      GoodsPackBomTypeSet goodsPackBomTypeSet1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(goodsPackBomTypeSet1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, goodsPackBomTypeSet1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(goodsPackBomTypeSet1.GetSelectQuery(p_param)))
        {
          goodsPackBomTypeSet1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + goodsPackBomTypeSet1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            GoodsPackBomTypeSet goodsPackBomTypeSet2 = goodsPackBomTypeSet1.OleDB.Create<GoodsPackBomTypeSet>();
            if (goodsPackBomTypeSet2.GetFieldValues(rs))
            {
              goodsPackBomTypeSet2.row_number = ++row_number;
              yield return goodsPackBomTypeSet2;
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

    public async Task<IList<GoodsPackBomTypeSet>> SelectDeptAsync(object p_param)
    {
      GoodsPackBomTypeSet goodsPackBomTypeSet1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      IList<GoodsPackBomTypeSet> goodsPackBomTypeSetList1;
      try
      {
        db = new UniOleDatabase(goodsPackBomTypeSet1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, goodsPackBomTypeSet1.OleDB.CommandTimeout);
        GoodsPackBomTypeSetByGoodsDic dic = new GoodsPackBomTypeSetByGoodsDic();
        await foreach (GoodsPackBomTypeSet info in goodsPackBomTypeSet1.SelectEnumerableAsync(p_param))
        {
          dic.Add(info);
          dic[info.gdp_GoodsCode].gdh_BuyCost += info.gdh_BuyCost;
          dic[info.gdp_GoodsCode].gdh_EventCost += info.gdh_EventCost;
          dic[info.gdp_GoodsCode].gdh_SalePrice += info.gdh_SalePrice;
          dic[info.gdp_GoodsCode].gdh_EventPrice += info.gdh_EventPrice;
        }
        IList<GoodsPackBomTypeSet> goodsPackBomTypeSetList2 = (IList<GoodsPackBomTypeSet>) new List<GoodsPackBomTypeSet>();
        foreach (GoodsPackBomTypeSet goodsPackBomTypeSet2 in dic.Values)
        {
          if (goodsPackBomTypeSet2.Lt_Details.Count > 0)
          {
            foreach (GoodsPackBomTypeSet ltDetail in (IEnumerable<GoodsPackBomTypeSet>) goodsPackBomTypeSet2.Lt_Details)
            {
              ltDetail.gdh_BuyCostRate = NumberHelper.ToDiv(ltDetail.gdh_BuyCost * ltDetail.gdp_StockConvQty, goodsPackBomTypeSet2.gdh_BuyCost);
              ltDetail.gdh_SalePriceRate = NumberHelper.ToDiv(ltDetail.gdh_SalePrice * ltDetail.gdp_StockConvQty, goodsPackBomTypeSet2.gdh_SalePrice);
            }
            GoodsPackBomTypeSet goodsPackBomTypeSet3 = goodsPackBomTypeSet2.Lt_Details.LastOrDefault<GoodsPackBomTypeSet>();
            if (goodsPackBomTypeSet3 != null)
              goodsPackBomTypeSet3.IsLastIdx = true;
          }
          goodsPackBomTypeSetList2.Add(goodsPackBomTypeSet2);
        }
        goodsPackBomTypeSetList1 = goodsPackBomTypeSetList2;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + goodsPackBomTypeSet1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
      rs = (UniOleDbRecordset) null;
      db = (UniOleDatabase) null;
      return goodsPackBomTypeSetList1;
    }

    public override string GetSelectWhereAnd(object p_param)
    {
      StringBuilder stringBuilder = new StringBuilder(this.GetSelectWhereAnd(p_param, false));
      if (string.IsNullOrWhiteSpace(stringBuilder.ToString()))
        stringBuilder.Append(" WHERE");
      if (p_param is Hashtable hashtable && hashtable.ContainsKey((object) "_KEY_WORD_"))
      {
        int length = hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length;
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
        DateTime? p_day = new DateTime?();
        if (p_param is Hashtable hashtable2)
        {
          if (hashtable2.ContainsKey((object) "DBMS") && hashtable2[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable2[(object) "DBMS"].ToString();
          if (hashtable2.ContainsKey((object) "table") && hashtable2[(object) "table"].ToString().Length > 0)
            str = hashtable2[(object) "table"].ToString();
          if (hashtable2.ContainsKey((object) "_ORDER_BY_COL_") && hashtable2[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable2[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable2.ContainsKey((object) "gdp_SiteID") && Convert.ToInt64(hashtable2[(object) "gdp_SiteID"].ToString()) > 0L)
            Convert.ToInt64(hashtable2[(object) "gdp_SiteID"].ToString());
          if (hashtable2.ContainsKey((object) "si_StoreCode") && Convert.ToInt32(hashtable2[(object) "si_StoreCode"].ToString()) > 0)
            num = Convert.ToInt32(hashtable2[(object) "si_StoreCode"].ToString());
          if (hashtable2.ContainsKey((object) "_DT_DATE_"))
            p_day = new DateTime?((DateTime) hashtable2[(object) "_DT_DATE_"]);
          if (hashtable2.ContainsKey((object) "_DT_DATE__END_"))
            p_day = new DateTime?(((DateTime) hashtable2[(object) "_DT_DATE__END_"]).ToLastDateOfMonth());
        }
        if (!p_day.HasValue)
          p_day = new DateTime?(DateTime.Now);
        stringBuilder.Append(" SELECT  gdp_GoodsCode,gdp_SubGoodsCode,gdp_SiteID,gdp_StockConvQty,gdp_InDate,gdp_InUser,gdp_ModDate,gdp_ModUser\n,gd_TaxDiv,gd_SalesUnit,gd_StockUnit\n,gdh_BuyCost,gdh_BuyVat,gdh_SalePrice,gdh_EventCost,gdh_EventVat,gdh_EventPrice,gdh_ChargeRate\n FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock() + string.Format("\nINNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Goods, (object) DbQueryHelper.ToWithNolock()) + " ON gdp_GoodsCode=gd_GoodsCode AND gdp_SiteID=gd_SiteID" + string.Format(" AND {0}={1}", (object) "gd_PackUnit", (object) 4) + string.Format("\n LEFT OUTER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + string.Format(" ON {0}={1} AND {2}={3}", (object) "gdh_StoreCode", (object) num, (object) "gdp_SubGoodsCode", (object) "gdh_GoodsCode") + " AND gdh_StartDate <='" + p_day.GetDateToStr("yyyy-MM-dd 00:00:00") + "' AND gdh_EndDate>='" + p_day.GetDateToStr("yyyy-MM-dd 00:00:00") + "' AND gdp_SiteID=gdh_SiteID");
        stringBuilder.Append("\n");
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append(" ORDER BY " + empty);
        else
          stringBuilder.Append(" ORDER BY gdp_GoodsCode,gdp_SubGoodsCode");
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
  }
}
