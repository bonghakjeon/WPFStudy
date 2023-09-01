// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.Month.Horizontal.Supplier.StatementMonthHorizontalBySupplierGoods
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
using System.Threading.Tasks;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay;
using UniBiz.Bo.Models.UniStock.Statement.Date;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniStock.Statement.Month.Horizontal.Supplier
{
  public class StatementMonthHorizontalBySupplierGoods : 
    StatementMonthHorizontalBySupplierCatBot<StatementMonthHorizontalBySupplierGoods>
  {
    private string _gd_GoodsName;
    private string _gd_BarCode;
    private string _gd_GoodsSize;
    private string _gd_UseYn;
    private double _gdh_BuyCost;
    private double _gdh_BuyVat;
    private double _gdh_SalePrice;
    private double _gdh_EventCost;
    private double _gdh_EventVat;
    private double _gdh_EventPrice;

    public override string KeyCode => string.Format("{0}|{1}|{2}|{3}|{4}|{5}", (object) this.sh_StoreCode, (object) this.sh_Supplier, (object) this.ctg_lv1_ID, (object) this.ctg_lv2_ID, (object) this.sd_CategoryCode, (object) this.sd_BoxCode);

    public override long sd_BoxCode
    {
      get => this._sd_BoxCode;
      set
      {
        this._sd_BoxCode = value;
        this.Changed(nameof (sd_BoxCode));
        this.Changed("KeyCode");
      }
    }

    public string gd_GoodsName
    {
      get => this._gd_GoodsName;
      set
      {
        this._gd_GoodsName = value;
        this.Changed(nameof (gd_GoodsName));
      }
    }

    public string gd_BarCode
    {
      get => this._gd_BarCode;
      set
      {
        this._gd_BarCode = value;
        this.Changed(nameof (gd_BarCode));
      }
    }

    public string gd_GoodsSize
    {
      get => this._gd_GoodsSize;
      set
      {
        this._gd_GoodsSize = value;
        this.Changed(nameof (gd_GoodsSize));
      }
    }

    public string gd_UseYn
    {
      get => this._gd_UseYn;
      set
      {
        this._gd_UseYn = value;
        this.Changed(nameof (gd_UseYn));
        this.Changed("gd_IsUseYn");
        this.Changed("gd_UseYnDesc");
      }
    }

    public bool gd_IsUseYn => "Y".Equals(this.gd_UseYn);

    public string gd_UseYnDesc => !"Y".Equals(this.gd_UseYn) ? "미사용" : "사용";

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

    public override string ToString() => string.Format("{0} [{1}({2})][{3}({4})] Count : {5}", (object) nameof (StatementMonthHorizontalBySupplierGoods), (object) this.su_SupplierName, (object) this.sh_Supplier, (object) this.gd_GoodsName, (object) this.gd_BarCode, (object) this.Lt_Details.Count);

    public override void Clear()
    {
      base.Clear();
      this.gd_GoodsName = this.gd_BarCode = this.gd_GoodsSize = string.Empty;
      this.gd_UseYn = string.Empty;
      this.gdh_BuyCost = this.gdh_BuyVat = this.gdh_SalePrice = 0.0;
      this.gdh_EventCost = this.gdh_EventVat = this.gdh_EventPrice = 0.0;
    }

    public void PutInfo(StatementMonthHorizontalBySupplierGoods pSource)
    {
      this.PutInfo((StatementMonthHorizontalBySupplierCatBot) pSource);
      this.gd_GoodsName = pSource.gd_GoodsName;
      this.gd_BarCode = pSource.gd_BarCode;
      this.gd_GoodsSize = pSource.gd_GoodsSize;
      this.gd_UseYn = pSource.gd_UseYn;
      this.gdh_BuyCost = pSource.gdh_BuyCost;
      this.gdh_BuyVat = pSource.gdh_BuyVat;
      this.gdh_SalePrice = pSource.gdh_SalePrice;
      this.gdh_EventCost = pSource.gdh_EventCost;
      this.gdh_EventVat = pSource.gdh_EventVat;
      this.gdh_EventPrice = pSource.gdh_EventPrice;
    }

    public void InitInfo(StatementMonthHorizontalBySupplierGoods pData, IList<DateTime> p_Days)
    {
      if (!this.KeyCode.Equals(pData.KeyCode))
        throw new Exception("pData 의 [sh_StoreCode|sh_Supplier|ctg_lv1_ID|ctg_lv2_ID|sd_CategoryCode|sd_BoxCode] 이 KeyCode 와 다릅니다");
      this.PutInfo(pData);
      foreach (DateTime pDay in (IEnumerable<DateTime>) p_Days)
      {
        IList<StatementMonthHorizontal> ltDetails = this.Lt_Details;
        StatementMonthHorizontal statementMonthHorizontal = new StatementMonthHorizontal();
        statementMonthHorizontal.sh_ConfirmDate = new DateTime?(pDay);
        statementMonthHorizontal.sh_StoreCode = this.sh_StoreCode;
        statementMonthHorizontal.sd_CategoryCode = this.sd_CategoryCode;
        statementMonthHorizontal.sd_BoxCode = this.sd_BoxCode;
        ltDetails.Add(statementMonthHorizontal);
      }
    }

    public void Add(StatementMonthHorizontalBySupplierGoods item)
    {
      if (this.sh_StoreCode == 0)
      {
        this.sh_StoreCode = item.sh_StoreCode;
        this.sh_Supplier = item.sh_Supplier;
        this.ctg_lv1_ID = item.ctg_lv1_ID;
        this.ctg_lv2_ID = item.ctg_lv2_ID;
        this.sd_CategoryCode = item.sd_CategoryCode;
        this.sd_BoxCode = item.sd_BoxCode;
      }
      else if (!this.KeyCode.Equals(item.KeyCode))
        throw new Exception("item 의 [sh_StoreCode|sh_Supplier|ctg_lv1_ID|ctg_lv2_ID|sd_CategoryCode|sd_BoxCode] 이 KeyCode 와 다릅니다");
      this.CalcAddSum((StatementMonthHorizontal) item);
      StatementMonthHorizontal statementMonthHorizontal = this.Lt_Details.Where<StatementMonthHorizontal>((Func<StatementMonthHorizontal, bool>) (it => it.sh_ConfirmDate.Value.Equals(item.sh_ConfirmDate.Value))).FirstOrDefault<StatementMonthHorizontal>();
      if (statementMonthHorizontal == null)
        this.Lt_Details.Add((StatementMonthHorizontal) item);
      else
        statementMonthHorizontal.PutData((StatementMonthHorizontal) item);
    }

    public void AddRange(
      IList<StatementMonthHorizontalBySupplierGoods> infos)
    {
      foreach (StatementMonthHorizontalBySupplierGoods info in (IEnumerable<StatementMonthHorizontalBySupplierGoods>) infos)
        this.Add(info);
    }

    public bool IsZero(EnumZeroCheck pCheckType, StatementMonthHorizontalBySupplierGoods pSource) => pSource == null || this.IsZero(pCheckType, (StatementMonthHorizontalBySupplierCatBot) pSource);

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        if (!base.GetFieldValues(p_rs))
          return false;
        this.gd_GoodsName = p_rs.GetFieldString("gd_GoodsName");
        this.gd_BarCode = p_rs.GetFieldString("gd_BarCode");
        this.gd_GoodsSize = p_rs.GetFieldString("gd_GoodsSize");
        this.gd_UseYn = p_rs.GetFieldString("gd_UseYn");
        this.gdh_BuyCost = p_rs.GetFieldDouble("gdh_BuyCost");
        this.gdh_BuyVat = p_rs.GetFieldDouble("gdh_BuyVat");
        this.gdh_SalePrice = p_rs.GetFieldDouble("gdh_SalePrice");
        this.gdh_EventCost = p_rs.GetFieldDouble("gdh_EventCost");
        this.gdh_EventVat = p_rs.GetFieldDouble("gdh_EventVat");
        this.gdh_EventPrice = p_rs.GetFieldDouble("gdh_EventPrice");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public async Task<IList<StatementMonthHorizontalBySupplierGoods>> SelectMonthHorizontalBySupplierGoodsListAsync(
      object p_param)
    {
      StatementMonthHorizontalBySupplierGoods horizontalBySupplierGoods1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(horizontalBySupplierGoods1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, horizontalBySupplierGoods1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(horizontalBySupplierGoods1.GetSelectQuery(p_param)))
        {
          horizontalBySupplierGoods1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + horizontalBySupplierGoods1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<StatementMonthHorizontalBySupplierGoods>) null;
        }
        IList<StatementMonthHorizontalBySupplierGoods> lt_list = (IList<StatementMonthHorizontalBySupplierGoods>) new List<StatementMonthHorizontalBySupplierGoods>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            StatementMonthHorizontalBySupplierGoods horizontalBySupplierGoods2 = horizontalBySupplierGoods1.OleDB.Create<StatementMonthHorizontalBySupplierGoods>();
            if (horizontalBySupplierGoods2.GetFieldValues(rs))
            {
              horizontalBySupplierGoods2.row_number = lt_list.Count + 1;
              lt_list.Add(horizontalBySupplierGoods2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + horizontalBySupplierGoods1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<StatementMonthHorizontalBySupplierGoods> SelectMonthHorizontalBySupplierGoodsEnumerableAsync(
      object p_param)
    {
      StatementMonthHorizontalBySupplierGoods horizontalBySupplierGoods1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(horizontalBySupplierGoods1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, horizontalBySupplierGoods1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(horizontalBySupplierGoods1.GetSelectQuery(p_param)))
        {
          horizontalBySupplierGoods1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + horizontalBySupplierGoods1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            StatementMonthHorizontalBySupplierGoods horizontalBySupplierGoods2 = horizontalBySupplierGoods1.OleDB.Create<StatementMonthHorizontalBySupplierGoods>();
            if (horizontalBySupplierGoods2.GetFieldValues(rs))
            {
              horizontalBySupplierGoods2.row_number = ++row_number;
              yield return horizontalBySupplierGoods2;
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
      StringBuilder stringBuilder = new StringBuilder(new StatementHeaderView().GetSelectWhereAnd(p_param, false));
      if (string.IsNullOrWhiteSpace(stringBuilder.ToString()))
        stringBuilder.Append(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        if (hashtable.ContainsKey((object) "gd_BarCode") && hashtable[(object) "gd_BarCode"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "gd_BarCode", hashtable[(object) "gd_BarCode"]));
        if (hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "si_StoreName", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "su_SupplierName", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "su_SupplierViewCode", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "gd_GoodsName", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "gd_BarCode", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(")");
        }
      }
      return !stringBuilder.ToString().Equals(" WHERE") ? stringBuilder.Replace("WHERE AND", "WHERE").ToString() : string.Empty;
    }

    public override string GetSelectQuery(object p_param)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        StatementDateStore statementDateStore = new StatementDateStore();
        string uniBase = UbModelBase.UNI_BASE;
        this.TableCode.ToString();
        string empty = string.Empty;
        long p_SiteID = 0;
        int p_bgg_GroupID = 0;
        bool p_isStoreTotal = false;
        bool flag1 = statementDateStore.IsGoodsSelect((Hashtable) p_param);
        bool flag2 = false;
        DateTime? p_day = new DateTime?();
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            hashtable[(object) "table"].ToString();
          if (hashtable.ContainsKey((object) "_ORDER_BY_COL_") && hashtable[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable.ContainsKey((object) "sd_SiteID") && Convert.ToInt64(hashtable[(object) "sd_SiteID"].ToString()) > 0L)
            p_SiteID = Convert.ToInt64(hashtable[(object) "sd_SiteID"].ToString());
          if (hashtable.ContainsKey((object) "bgg_GroupID") && Convert.ToInt32(hashtable[(object) "bgg_GroupID"].ToString()) > 0)
            p_bgg_GroupID = Convert.ToInt32(hashtable[(object) "bgg_GroupID"].ToString());
          if (hashtable.ContainsKey((object) "_IS_STORE_TOTAL_SUM_") && Convert.ToBoolean(hashtable[(object) "_IS_STORE_TOTAL_SUM_"].ToString()))
            p_isStoreTotal = Convert.ToBoolean(hashtable[(object) "_IS_STORE_TOTAL_SUM_"].ToString());
          if (hashtable.ContainsKey((object) "_IsStatementSalse_") && Convert.ToBoolean(hashtable[(object) "_IsStatementSalse_"].ToString()))
            flag2 = Convert.ToBoolean(hashtable[(object) "_IsStatementSalse_"].ToString());
          if (hashtable.ContainsKey((object) "sh_ConfirmDate"))
            p_day = new DateTime?((DateTime) hashtable[(object) "sh_ConfirmDate"]);
          if (hashtable.ContainsKey((object) "sh_ConfirmDate_END_"))
            p_day = new DateTime?((DateTime) hashtable[(object) "sh_ConfirmDate_END_"]);
        }
        stringBuilder.Append(statementDateStore.ToWithStoreQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(statementDateStore.ToWithSupplierQuery(p_param, uniBase, p_SiteID));
        if (p_bgg_GroupID > 0)
          stringBuilder.Append(statementDateStore.ToWithBookmarkGoodsQuery(p_param, uniBase, p_SiteID, p_bgg_GroupID));
        stringBuilder.Append(statementDateStore.ToWithGoodsHistoryQuery(p_param, uniBase, p_SiteID, p_isStoreTotal));
        stringBuilder.Append(statementDateStore.ToWithGoodsQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(statementDateStore.ToWithCategoryLv1Query(p_param, uniBase, p_SiteID));
        stringBuilder.Append(statementDateStore.ToWithCategoryLv2Query(p_param, uniBase, p_SiteID));
        stringBuilder.Append(statementDateStore.ToWithCategoryLv3Query(p_param, uniBase, p_SiteID));
        stringBuilder.Append("\n,T_STATEMENT AS (SELECT");
        stringBuilder.Append(" " + "sh_ConfirmDate".DateToStr(EnumDbDateType.YYYYMM) + " AS sh_ConfirmMonth");
        stringBuilder.Append(",");
        if (p_isStoreTotal)
          stringBuilder.Append(" 1 AS");
        stringBuilder.Append(" sh_StoreCode");
        stringBuilder.Append(",sh_Supplier");
        stringBuilder.Append(",ctg_lv1_ID,ctg_lv2_ID,ctg_code");
        stringBuilder.Append(",sd_BoxCode");
        stringBuilder.Append(StatementDateStore.DetailColMaker);
        stringBuilder.Append(string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) TableCodeType.StatementHeader, (object) DbQueryHelper.ToWithNolock()));
        stringBuilder.Append(string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) TableCodeType.StatementDetail, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StatementNo=sd_StatementNo AND sh_SiteID=sd_SiteID" + string.Format(" AND {0}!={1}", (object) "sd_PackUnit", (object) 4) + "\n INNER JOIN T_HISTORY ON sh_StoreCode=gdh_StoreCode AND sd_BoxCode=gdh_GoodsCode AND sh_ConfirmDate>=gdh_StartDate AND sh_ConfirmDate<=gdh_EndDate AND sh_SiteID=gdh_SiteID");
        if (p_bgg_GroupID > 0)
          stringBuilder.Append("\n INNER JOIN T_BOOKMARK_GOODS ON sd_BoxCode=bgl_GoodsCode AND sh_SiteID=bgl_SiteID");
        if (flag1)
          stringBuilder.Append("\n INNER JOIN T_GOODS ON sd_BoxCode=gd_GoodsCode AND sh_SiteID=gd_SiteID");
        p_param1.Clear();
        p_param1 = statementDateStore.SearchConditionStatement((Hashtable) p_param);
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "sh_SiteID"))
            p_param1.Add((object) "sh_SiteID", (object) p_SiteID);
          stringBuilder.Append("\n");
          stringBuilder.Append(this.GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format("\n WHERE {0}={1}", (object) "sh_SiteID", (object) p_SiteID));
        stringBuilder.Append("\n GROUP BY " + "sh_ConfirmDate".DateToStr(EnumDbDateType.YYYYMM));
        if (!p_isStoreTotal)
          stringBuilder.Append(",sh_StoreCode");
        stringBuilder.Append(",sh_Supplier");
        stringBuilder.Append(",ctg_lv1_ID,ctg_lv2_ID,ctg_code");
        stringBuilder.Append(",sd_BoxCode");
        stringBuilder.Append(")");
        if (flag2)
        {
          stringBuilder.Append("\n,T_SALE AS (\nSELECT");
          stringBuilder.Append(" " + "sbd_SaleDate".DateToStr(EnumDbDateType.YYYYMM) + " AS sh_ConfirmMonth");
          stringBuilder.Append(",");
          if (p_isStoreTotal)
            stringBuilder.Append(" 1 ");
          else
            stringBuilder.Append(" sbd_StoreCode");
          stringBuilder.Append(" AS sh_StoreCode");
          stringBuilder.Append(",gdh_Supplier AS sh_Supplier");
          stringBuilder.Append(",ctg_lv1_ID,ctg_lv2_ID,ctg_code");
          stringBuilder.Append(",sbd_GoodsCode AS sd_BoxCode");
          stringBuilder.Append(StatementDateStore.SalesColMaker);
          stringBuilder.Append(string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_SALES), (object) TableCodeType.SalesByDay, (object) DbQueryHelper.ToWithNolock()) + "\n INNER JOIN T_HISTORY ON sbd_StoreCode=gdh_StoreCode AND sbd_GoodsCode=gdh_GoodsCode AND sbd_SaleDate>=gdh_StartDate AND sbd_SaleDate<=gdh_EndDate AND sbd_SiteID=gdh_SiteID");
          if (p_bgg_GroupID > 0)
            stringBuilder.Append("\n INNER JOIN T_BOOKMARK_GOODS ON sbd_GoodsCode=bgl_GoodsCode AND sbd_SiteID=bgl_SiteID");
          if (flag1)
            stringBuilder.Append("\n INNER JOIN T_GOODS ON sbd_GoodsCode=gd_GoodsCode AND sbd_SiteID=gd_SiteID");
          p_param1.Clear();
          p_param1 = statementDateStore.SearchConditionSales((Hashtable) p_param);
          if (p_param1.Count > 0)
          {
            if (!p_param1.ContainsKey((object) "sbd_SiteID"))
              p_param1.Add((object) "sbd_SiteID", (object) p_SiteID);
            stringBuilder.Append("\n");
            stringBuilder.Append(new TSalesByDay().GetSelectWhereAnd((object) p_param1));
          }
          else if (p_SiteID > 0L)
            stringBuilder.Append(string.Format("\n WHERE {0}={1}", (object) "sbd_SiteID", (object) p_SiteID));
          stringBuilder.Append("\n GROUP BY " + "sbd_SaleDate".DateToStr(EnumDbDateType.YYYYMM));
          if (!p_isStoreTotal)
            stringBuilder.Append(",sbd_StoreCode");
          stringBuilder.Append(",gdh_Supplier");
          stringBuilder.Append(",ctg_lv1_ID,ctg_lv2_ID,ctg_code");
          stringBuilder.Append(",sbd_GoodsCode");
          stringBuilder.Append(")");
        }
        stringBuilder.Append("\nSELECT 1 AS sd_StatementNo,0 AS sd_Seq" + string.Format(",{0} AS {1}", (object) p_SiteID, (object) "sd_SiteID") + ",0 AS sd_GoodsCode,sd_BoxCode,gd_BarCode AS sd_BarCode,gdh_GoodsCategory AS sd_CategoryCode,gd_TaxDiv AS sd_TaxDiv,gd_SalesUnit AS sd_SalesUnit,gd_StockUnit AS sd_StockUnit,gd_PackUnit AS sd_PackUnit,0 AS sd_LinkRowNCount,0 AS sd_CostGoods,0 AS sd_PriceGoods,0 AS sd_CostInput,0 AS sd_CostInputVat,'' AS sd_EventYn,0 AS sd_Native,'' AS sd_HistoryID,'' AS sd_Memo,0 AS sd_MobieSeq,NULL AS sd_InDate,0 AS sd_InUser,NULL AS sd_ModDate,0 AS sd_ModUser");
        stringBuilder.Append(StatementDateStore.MainCol);
        stringBuilder.Append("\n,sh_ConfirmMonth,sh_StoreCode");
        stringBuilder.Append(",sh_Supplier");
        if (p_isStoreTotal)
          stringBuilder.Append("\n,통합 AS si_StoreName");
        else
          stringBuilder.Append("\n,si_StoreName");
        stringBuilder.Append(",si_StoreViewCode,si_UseYn,si_StoreType");
        stringBuilder.Append("\n,su_SupplierName,su_SupplierViewCode,su_UseYn,su_HeadSupplier,su_SupplierType,su_SupplierKind");
        stringBuilder.Append(",T_CTG_LV_1_NAME.ctg_ID AS ctg_lv1_ID,T_CTG_LV_1_NAME.ctg_ViewCode AS ctg_lv1_ViewCode,T_CTG_LV_1_NAME.ctg_CategoryName AS ctg_lv1_Name,T_CTG_LV_2_NAME.ctg_ID AS ctg_lv2_ID,T_CTG_LV_2_NAME.ctg_ViewCode AS ctg_lv2_ViewCode,T_CTG_LV_2_NAME.ctg_CategoryName AS ctg_lv2_Name,T_CTG_LV_3_NAME.ctg_ID AS ctg_code,T_CTG_LV_3_NAME.ctg_ViewCode AS ctg_ViewCode,T_CTG_LV_3_NAME.ctg_CategoryName AS ctg_CategoryName,gd_GoodsName,gd_BarCode,gd_GoodsSize,gd_UseYn,gdh_BuyCost,gdh_BuyVat,gdh_SalePrice,gdh_EventCost,gdh_EventVat,gdh_EventPrice");
        stringBuilder.Append("\nFROM (");
        stringBuilder.Append("\nSELECT sh_ConfirmMonth,sh_StoreCode");
        stringBuilder.Append(",sh_Supplier");
        stringBuilder.Append(",ctg_lv1_ID,ctg_lv2_ID,ctg_code");
        stringBuilder.Append(",sd_BoxCode");
        stringBuilder.Append(StatementDateStore.SubCol);
        stringBuilder.Append("\nFROM (");
        stringBuilder.Append("\nSELECT sh_ConfirmMonth,sh_StoreCode");
        stringBuilder.Append(",sh_Supplier");
        stringBuilder.Append(",ctg_lv1_ID,ctg_lv2_ID,ctg_code");
        stringBuilder.Append(",sd_BoxCode");
        stringBuilder.Append(StatementDateStore.TStatementCol);
        stringBuilder.Append("\nFROM T_STATEMENT");
        if (flag2)
        {
          stringBuilder.Append("\nUNION ALL");
          stringBuilder.Append("\nSELECT sh_ConfirmMonth,sh_StoreCode");
          stringBuilder.Append(",sh_Supplier");
          stringBuilder.Append(",ctg_lv1_ID,ctg_lv2_ID,ctg_code");
          stringBuilder.Append(",sd_BoxCode");
          stringBuilder.Append(StatementDateStore.TSaleCol);
          stringBuilder.Append("\nFROM T_SALE");
        }
        stringBuilder.Append("\n) SUB");
        stringBuilder.Append("\nGROUP BY sh_ConfirmMonth,sh_StoreCode");
        stringBuilder.Append(",sh_Supplier");
        stringBuilder.Append(",ctg_lv1_ID,ctg_lv2_ID,ctg_code");
        stringBuilder.Append(",sd_BoxCode");
        stringBuilder.Append("\n) MAIN");
        stringBuilder.Append("\nINNER JOIN T_STORE ON sh_StoreCode=si_StoreCode" + string.Format(" AND {0}={1}", (object) "si_SiteID", (object) p_SiteID) + "\nINNER JOIN T_SUPPLIER ON sh_Supplier=su_Supplier" + string.Format(" AND {0}={1}", (object) "su_SiteID", (object) p_SiteID) + "\n LEFT OUTER JOIN T_CTG_LV_1_NAME ON ctg_lv1_ID=T_CTG_LV_1_NAME.ctg_ID" + string.Format(" AND T_CTG_LV_1_NAME.{0}={1}", (object) "ctg_SiteID", (object) p_SiteID) + "\n LEFT OUTER JOIN T_CTG_LV_2_NAME ON ctg_lv2_ID=T_CTG_LV_2_NAME.ctg_ID" + string.Format(" AND T_CTG_LV_2_NAME.{0}={1}", (object) "ctg_SiteID", (object) p_SiteID) + "\n LEFT OUTER JOIN T_CTG_LV_3_NAME ON ctg_code=T_CTG_LV_3_NAME.ctg_ID" + string.Format(" AND T_CTG_LV_3_NAME.{0}={1}", (object) "ctg_SiteID", (object) p_SiteID) + "\n LEFT OUTER JOIN T_GOODS ON sd_BoxCode=T_GOODS.gd_GoodsCode" + string.Format(" AND T_GOODS.{0}={1}", (object) "gd_SiteID", (object) p_SiteID));
        if (!p_day.HasValue)
          p_day = new DateTime?(DateTime.Now);
        stringBuilder.Append("\n INNER JOIN T_HISTORY ON sh_StoreCode=gdh_StoreCode AND sd_BoxCode=gdh_GoodsCode AND '" + p_day.GetDateToStr("yyyy-MM-dd 00:00:00") + "'>=gdh_StartDate AND '" + p_day.GetDateToStr("yyyy-MM-dd 00:00:00") + "'<=gdh_EndDate" + string.Format(" AND {0}={1}", (object) "gdh_SiteID", (object) p_SiteID));
        stringBuilder.Append("\n");
        if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append(" ORDER BY " + empty);
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) ex.GetHashCode()) + " 내용 : " + ex.Message + "\n" + string.Format(" Query : {0}\n", (object) stringBuilder) + "--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
        stringBuilder.Clear();
      }
      finally
      {
        p_param1.Clear();
      }
      Log.Logger.DebugColor(" 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + string.Format("\n LINE : {0} 행", (object) new StackFrame(0, true).GetFileLineNumber()) + "\n--------------------------------------------------------------------------------------------------\nQuery\n--------------------------------------------------------------------------------------------------\n" + stringBuilder.ToString() + "\n--------------------------------------------------------------------------------------------------");
      return stringBuilder.ToString();
    }
  }
}
