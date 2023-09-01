// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.Day.Horizontal.StatementDayHorizontalByCategoryMid
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

namespace UniBiz.Bo.Models.UniStock.Statement.Day.Horizontal
{
  public class StatementDayHorizontalByCategoryMid : 
    StatementDayHorizontalByCategoryTop<StatementDayHorizontalByCategoryMid>
  {
    private int _ctg_lv2_ID;
    private string _ctg_lv2_ViewCode;
    private string _ctg_lv2_Name;

    public override string KeyCode => string.Format("{0}|{1}|{2}|{3}|{4}|{5}", (object) this.sh_StoreCode, (object) this.dpt_lv1_ID, (object) this.dpt_lv2_ID, (object) this.dpt_ID, (object) this.ctg_lv1_ID, (object) this.ctg_lv2_ID);

    public int ctg_lv2_ID
    {
      get => this._ctg_lv2_ID;
      set
      {
        this._ctg_lv2_ID = value;
        this.Changed(nameof (ctg_lv2_ID));
        this.Changed("KeyCode");
      }
    }

    public string ctg_lv2_ViewCode
    {
      get => this._ctg_lv2_ViewCode;
      set
      {
        this._ctg_lv2_ViewCode = value;
        this.Changed(nameof (ctg_lv2_ViewCode));
      }
    }

    public string ctg_lv2_Name
    {
      get => this._ctg_lv2_Name;
      set
      {
        this._ctg_lv2_Name = value;
        this.Changed(nameof (ctg_lv2_Name));
      }
    }

    public override string ToString() => string.Format("{0} [{1}:{2}>{3}] Count : {4}", (object) nameof (StatementDayHorizontalByCategoryMid), (object) this.si_StoreName, (object) this.ctg_lv1_Name, (object) this.ctg_lv2_Name, (object) this.Lt_Details.Count);

    public override void Clear()
    {
      base.Clear();
      this.ctg_lv2_ID = 0;
      this.ctg_lv2_ViewCode = string.Empty;
      this.ctg_lv2_Name = string.Empty;
    }

    public void PutInfo(StatementDayHorizontalByCategoryMid pSource)
    {
      this.PutInfo((StatementDayHorizontalByCategoryTop) pSource);
      this.ctg_lv2_ID = pSource.ctg_lv2_ID;
      this.ctg_lv2_ViewCode = pSource.ctg_lv2_ViewCode;
      this.ctg_lv2_Name = pSource.ctg_lv2_Name;
    }

    public void InitInfo(StatementDayHorizontalByCategoryMid pData, IList<DateTime> p_Days)
    {
      if (!this.KeyCode.Equals(pData.KeyCode))
        throw new Exception("pData 의 [sh_StoreCode|dpt_lv1_ID|dpt_lv2_ID|dpt_ID|ctg_lv1_ID|ctg_lv2_ID] 이 KeyCode 와 다릅니다");
      this.PutInfo(pData);
      foreach (DateTime pDay in (IEnumerable<DateTime>) p_Days)
        this.Lt_Details.Add(new StatementDayHorizontal()
        {
          sh_ConfirmDate = new DateTime?(pDay),
          sh_StoreCode = this.sh_StoreCode
        });
    }

    public void Add(StatementDayHorizontalByCategoryMid item)
    {
      if (this.sh_StoreCode == 0)
      {
        this.sh_StoreCode = item.sh_StoreCode;
        this.dpt_lv1_ID = item.dpt_lv1_ID;
        this.dpt_lv2_ID = item.dpt_lv2_ID;
        this.dpt_ID = item.dpt_ID;
        this.ctg_lv1_ID = item.ctg_lv1_ID;
        this.ctg_lv2_ID = item.ctg_lv2_ID;
      }
      else
      {
        if (!item.sh_ConfirmDate.HasValue)
          throw new Exception("item 의 sh_ConfirmDate 일자 데이터 널");
        if (!this.KeyCode.Equals(item.KeyCode))
          throw new Exception("item 의 [sh_StoreCode|dpt_lv1_ID|dpt_lv2_ID|dpt_ID|ctg_lv1_ID|ctg_lv2_ID] 이 KeyCode 와 다릅니다");
      }
      this.CalcAddSum((StatementDayHorizontal) item);
      StatementDayHorizontal statementDayHorizontal = this.Lt_Details.FirstOrDefault<StatementDayHorizontal>((Func<StatementDayHorizontal, bool>) (it => it.sh_ConfirmDate.Value.Equals(item.sh_ConfirmDate.Value)));
      if (statementDayHorizontal == null)
        this.Lt_Details.Add((StatementDayHorizontal) item);
      else
        statementDayHorizontal.PutData((StatementDayHorizontal) item);
    }

    public void AddRange(IList<StatementDayHorizontalByCategoryMid> infos)
    {
      foreach (StatementDayHorizontalByCategoryMid info in (IEnumerable<StatementDayHorizontalByCategoryMid>) infos)
        this.Add(info);
    }

    public bool IsZero(EnumZeroCheck pCheckType, StatementDayHorizontalByCategoryMid pSource) => pSource == null || this.IsZero(pCheckType, (StatementDayHorizontalByCategoryTop) pSource);

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        if (!base.GetFieldValues(p_rs))
          return false;
        this.ctg_lv2_ID = p_rs.GetFieldInt("ctg_lv2_ID");
        this.ctg_lv2_ViewCode = p_rs.GetFieldString("ctg_lv2_ViewCode");
        this.ctg_lv2_Name = p_rs.GetFieldString("ctg_lv2_Name");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public async Task<IList<StatementDayHorizontalByCategoryMid>> SelectDayHorizontalByCategoryMidListAsync(
      object p_param)
    {
      StatementDayHorizontalByCategoryMid horizontalByCategoryMid1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(horizontalByCategoryMid1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, horizontalByCategoryMid1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(horizontalByCategoryMid1.GetSelectQuery(p_param)))
        {
          horizontalByCategoryMid1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + horizontalByCategoryMid1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<StatementDayHorizontalByCategoryMid>) null;
        }
        IList<StatementDayHorizontalByCategoryMid> lt_list = (IList<StatementDayHorizontalByCategoryMid>) new List<StatementDayHorizontalByCategoryMid>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            StatementDayHorizontalByCategoryMid horizontalByCategoryMid2 = horizontalByCategoryMid1.OleDB.Create<StatementDayHorizontalByCategoryMid>();
            if (horizontalByCategoryMid2.GetFieldValues(rs))
            {
              horizontalByCategoryMid2.row_number = lt_list.Count + 1;
              lt_list.Add(horizontalByCategoryMid2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + horizontalByCategoryMid1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<StatementDayHorizontalByCategoryMid> SelectDayHorizontalByCategoryMidEnumerableAsync(
      object p_param)
    {
      StatementDayHorizontalByCategoryMid horizontalByCategoryMid1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(horizontalByCategoryMid1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, horizontalByCategoryMid1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(horizontalByCategoryMid1.GetSelectQuery(p_param)))
        {
          horizontalByCategoryMid1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + horizontalByCategoryMid1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            StatementDayHorizontalByCategoryMid horizontalByCategoryMid2 = horizontalByCategoryMid1.OleDB.Create<StatementDayHorizontalByCategoryMid>();
            if (horizontalByCategoryMid2.GetFieldValues(rs))
            {
              horizontalByCategoryMid2.row_number = ++row_number;
              yield return horizontalByCategoryMid2;
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
      if (p_param is Hashtable hashtable && hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
      {
        stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "si_StoreName", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "ctg_lv2_Name", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "ctg_lv2_ViewCode", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(")");
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
        }
        stringBuilder.Append(statementDateStore.ToWithStoreQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(statementDateStore.ToWithSupplierQuery(p_param, uniBase, p_SiteID));
        if (p_bgg_GroupID > 0)
          stringBuilder.Append(statementDateStore.ToWithBookmarkGoodsQuery(p_param, uniBase, p_SiteID, p_bgg_GroupID));
        stringBuilder.Append(statementDateStore.ToWithGoodsHistoryQuery(p_param, uniBase, p_SiteID, p_isStoreTotal));
        if (flag1)
          stringBuilder.Append(statementDateStore.ToWithGoodsQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(statementDateStore.ToWithDeptLv1Query(p_param, uniBase, p_SiteID));
        stringBuilder.Append(statementDateStore.ToWithDeptLv2Query(p_param, uniBase, p_SiteID));
        stringBuilder.Append(statementDateStore.ToWithDeptLv3Query(p_param, uniBase, p_SiteID));
        stringBuilder.Append(statementDateStore.ToWithCategoryLv1Query(p_param, uniBase, p_SiteID));
        stringBuilder.Append(statementDateStore.ToWithCategoryLv2Query(p_param, uniBase, p_SiteID));
        stringBuilder.Append("\n,T_STATEMENT AS (SELECT");
        stringBuilder.Append(" sh_ConfirmDate");
        stringBuilder.Append(",");
        if (p_isStoreTotal)
          stringBuilder.Append(" 1 AS");
        stringBuilder.Append(" sh_StoreCode");
        stringBuilder.Append(",dpt_lv1_ID,dpt_lv2_ID,dept_code");
        stringBuilder.Append(",ctg_lv1_ID,ctg_lv2_ID");
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
        stringBuilder.Append("\n GROUP BY sh_ConfirmDate");
        if (!p_isStoreTotal)
          stringBuilder.Append(",sh_StoreCode");
        stringBuilder.Append(",dpt_lv1_ID,dpt_lv2_ID,dept_code");
        stringBuilder.Append(",ctg_lv1_ID,ctg_lv2_ID");
        stringBuilder.Append(")");
        if (flag2)
        {
          stringBuilder.Append("\n,T_SALE AS (\nSELECT");
          stringBuilder.Append(" sbd_SaleDate AS sh_ConfirmDate");
          stringBuilder.Append(",");
          if (p_isStoreTotal)
            stringBuilder.Append(" 1 ");
          else
            stringBuilder.Append(" sbd_StoreCode");
          stringBuilder.Append(" AS sh_StoreCode");
          stringBuilder.Append(",dpt_lv1_ID,dpt_lv2_ID,dept_code");
          stringBuilder.Append(",ctg_lv1_ID,ctg_lv2_ID");
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
          stringBuilder.Append("\n GROUP BY sbd_SaleDate");
          if (!p_isStoreTotal)
            stringBuilder.Append(",sbd_StoreCode");
          stringBuilder.Append(",dpt_lv1_ID,dpt_lv2_ID,dept_code");
          stringBuilder.Append(",ctg_lv1_ID,ctg_lv2_ID");
          stringBuilder.Append(")");
        }
        stringBuilder.Append("\nSELECT 1 AS sd_StatementNo,0 AS sd_Seq" + string.Format(",{0} AS {1}", (object) p_SiteID, (object) "sd_SiteID") + ",0 AS sd_GoodsCode,0 AS sd_BoxCode,'' AS sd_BarCode,0 AS sd_CategoryCode,0 AS sd_TaxDiv,0 AS sd_SalesUnit,0 AS sd_StockUnit,0 AS sd_PackUnit,0 AS sd_LinkRowNCount,0 AS sd_CostGoods,0 AS sd_PriceGoods,0 AS sd_CostInput,0 AS sd_CostInputVat,'' AS sd_EventYn,0 AS sd_Native,'' AS sd_HistoryID,'' AS sd_Memo,0 AS sd_MobieSeq,NULL AS sd_InDate,0 AS sd_InUser,NULL AS sd_ModDate,0 AS sd_ModUser");
        stringBuilder.Append(StatementDateStore.MainCol);
        stringBuilder.Append("\n,sh_ConfirmDate,sh_StoreCode");
        if (p_isStoreTotal)
          stringBuilder.Append("\n,통합 AS si_StoreName");
        else
          stringBuilder.Append("\n,si_StoreName");
        stringBuilder.Append(",si_StoreViewCode,si_UseYn,si_StoreType");
        stringBuilder.Append("\n,dpt_lv1_ID,T_DEPT_LV1_NAME.dpt_ViewCode AS dpt_lv1_ViewCode,T_DEPT_LV1_NAME.dpt_DeptName AS dpt_lv1_Name,dpt_lv2_ID,T_DEPT_LV2_NAME.dpt_ViewCode AS dpt_lv2_ViewCode,T_DEPT_LV2_NAME.dpt_DeptName AS dpt_lv2_Name,dept_code AS dpt_ID,T_DEPT_LV3_NAME.dpt_ViewCode AS dpt_ViewCode,T_DEPT_LV3_NAME.dpt_DeptName AS dpt_DeptName,ctg_lv1_ID,T_CTG_LV_1_NAME.ctg_ViewCode AS ctg_lv1_ViewCode,T_CTG_LV_1_NAME.ctg_CategoryName AS ctg_lv1_Name,ctg_lv2_ID,T_CTG_LV_2_NAME.ctg_ViewCode AS ctg_lv2_ViewCode,T_CTG_LV_2_NAME.ctg_CategoryName AS ctg_lv2_Name");
        stringBuilder.Append("\nFROM (");
        stringBuilder.Append("\nSELECT sh_ConfirmDate,sh_StoreCode");
        stringBuilder.Append(",dpt_lv1_ID,dpt_lv2_ID,dept_code");
        stringBuilder.Append(",ctg_lv1_ID,ctg_lv2_ID");
        stringBuilder.Append(StatementDateStore.SubCol);
        stringBuilder.Append("\nFROM (");
        stringBuilder.Append("\nSELECT sh_ConfirmDate,sh_StoreCode");
        stringBuilder.Append(",dpt_lv1_ID,dpt_lv2_ID,dept_code");
        stringBuilder.Append(",ctg_lv1_ID,ctg_lv2_ID");
        stringBuilder.Append(StatementDateStore.TStatementCol);
        stringBuilder.Append("\nFROM T_STATEMENT");
        if (flag2)
        {
          stringBuilder.Append("\nUNION ALL");
          stringBuilder.Append("\nSELECT sh_ConfirmDate,sh_StoreCode");
          stringBuilder.Append(",dpt_lv1_ID,dpt_lv2_ID,dept_code");
          stringBuilder.Append(",ctg_lv1_ID,ctg_lv2_ID");
          stringBuilder.Append(StatementDateStore.TSaleCol);
          stringBuilder.Append("\nFROM T_SALE");
        }
        stringBuilder.Append("\n) SUB");
        stringBuilder.Append("\nGROUP BY sh_ConfirmDate,sh_StoreCode");
        stringBuilder.Append(",dpt_lv1_ID,dpt_lv2_ID,dept_code");
        stringBuilder.Append(",ctg_lv1_ID,ctg_lv2_ID");
        stringBuilder.Append("\n) MAIN");
        stringBuilder.Append("\nINNER JOIN T_STORE ON sh_StoreCode=si_StoreCode" + string.Format(" AND {0}={1}", (object) "si_SiteID", (object) p_SiteID) + "\n LEFT OUTER JOIN T_DEPT_LV1_NAME ON dpt_lv1_ID=T_DEPT_LV1_NAME.dpt_ID" + string.Format(" AND T_DEPT_LV1_NAME.{0}={1}", (object) "dpt_SiteID", (object) p_SiteID) + "\n LEFT OUTER JOIN T_DEPT_LV2_NAME ON dpt_lv2_ID=T_DEPT_LV2_NAME.dpt_ID" + string.Format(" AND T_DEPT_LV2_NAME.{0}={1}", (object) "dpt_SiteID", (object) p_SiteID) + "\n LEFT OUTER JOIN T_DEPT_LV3_NAME ON dept_code=T_DEPT_LV3_NAME.dpt_ID" + string.Format(" AND T_DEPT_LV3_NAME.{0}={1}", (object) "dpt_SiteID", (object) p_SiteID) + "\n LEFT OUTER JOIN T_CTG_LV_1_NAME ON ctg_lv1_ID=T_CTG_LV_1_NAME.ctg_ID" + string.Format(" AND T_CTG_LV_1_NAME.{0}={1}", (object) "ctg_SiteID", (object) p_SiteID) + "\n LEFT OUTER JOIN T_CTG_LV_2_NAME ON ctg_lv2_ID=T_CTG_LV_2_NAME.ctg_ID" + string.Format(" AND T_CTG_LV_2_NAME.{0}={1}", (object) "ctg_SiteID", (object) p_SiteID));
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
      return stringBuilder.ToString();
    }
  }
}
