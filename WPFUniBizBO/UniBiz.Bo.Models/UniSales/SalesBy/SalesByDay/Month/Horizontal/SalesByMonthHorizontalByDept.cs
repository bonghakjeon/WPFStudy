// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Month.Horizontal.SalesByMonthHorizontalByDept
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
using UniBiz.Bo.Models.UniSales.SalesBy.GoalBy.GoalByDept;
using UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Date;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Month.Horizontal
{
  public class SalesByMonthHorizontalByDept : 
    SalesByMonthHorizontalByTeam<SalesByMonthHorizontalByDept>
  {
    private string _dpt_ViewCode;
    private string _dpt_DeptName;

    public override string KeyCode => string.Format("{0}|{1}|{2}|{3}", (object) this.si_StoreCode, (object) this.dpt_lv1_ID, (object) this.dpt_lv2_ID, (object) this.sbd_DeptCode);

    public override int sbd_DeptCode
    {
      get => this._sbd_DeptCode;
      set
      {
        this._sbd_DeptCode = value;
        this.Changed(nameof (sbd_DeptCode));
        this.Changed("KeyCode");
      }
    }

    public string dpt_ViewCode
    {
      get => this._dpt_ViewCode;
      set
      {
        this._dpt_ViewCode = value;
        this.Changed(nameof (dpt_ViewCode));
        this.Changed("dpt_lv3_ViewCode");
      }
    }

    public string dpt_lv3_ViewCode => this.dpt_ViewCode;

    public string dpt_DeptName
    {
      get => this._dpt_DeptName;
      set
      {
        this._dpt_DeptName = value;
        this.Changed(nameof (dpt_DeptName));
        this.Changed("dpt_lv3_Name");
      }
    }

    public string dpt_lv3_Name => this.dpt_DeptName;

    public override void Clear()
    {
      base.Clear();
      this.dpt_ViewCode = string.Empty;
      this.dpt_DeptName = string.Empty;
    }

    public void PutInfo(SalesByMonthHorizontalByDept pSource)
    {
      this.PutInfo((SalesByMonthHorizontalByTeam) pSource);
      this.dpt_ViewCode = pSource.dpt_ViewCode;
      this.dpt_DeptName = pSource.dpt_DeptName;
    }

    public void InitInfo(SalesByMonthHorizontalByDept pData, IList<DateTime> p_Days)
    {
      if (!this.KeyCode.Equals(pData.KeyCode))
        throw new Exception("pData 의 [sbd_StoreCode|dpt_lv1_ID|dpt_lv2_ID|sbd_DeptCode] 이 KeyCode 와 다릅니다");
      this.PutInfo(pData);
      foreach (DateTime pDay in (IEnumerable<DateTime>) p_Days)
      {
        IList<SalesByDayGoal> ltDetails = this.Lt_Details;
        SalesByMonthGoal salesByMonthGoal = new SalesByMonthGoal();
        salesByMonthGoal.sbd_SaleDate = new DateTime?(pDay);
        salesByMonthGoal.sbd_StoreCode = this.si_StoreCode;
        salesByMonthGoal.sbd_DeptCode = this.sbd_DeptCode;
        ltDetails.Add((SalesByDayGoal) salesByMonthGoal);
      }
    }

    public void Add(SalesByMonthHorizontalByDept item)
    {
      if (this.si_StoreCode == 0)
      {
        this.si_StoreCode = item.sbd_StoreCode;
        this.dpt_lv1_ID = item.dpt_lv1_ID;
        this.dpt_lv2_ID = item.dpt_lv2_ID;
        this.sbd_DeptCode = item.sbd_DeptCode;
      }
      else if (!this.KeyCode.Equals(item.KeyCode))
        throw new Exception("item 의 [sbd_StoreCode|dpt_lv1_ID|dpt_lv2_ID|sbd_DeptCode] 이 KeyCode 와 다릅니다");
      this.CalcAddSum((SalesByMonthGoal) item);
      SalesByDayGoal salesByDayGoal = this.Lt_Details.FirstOrDefault<SalesByDayGoal>((Func<SalesByDayGoal, bool>) (it => it.sbd_SaleDate.Equals((object) item.sbd_SaleDate)));
      if (salesByDayGoal == null)
        this.Lt_Details.Add((SalesByDayGoal) item);
      else
        salesByDayGoal.PutData((SalesByDayGoal) item);
    }

    public void AddRange(IList<SalesByMonthHorizontalByDept> infos)
    {
      foreach (SalesByMonthHorizontalByDept info in (IEnumerable<SalesByMonthHorizontalByDept>) infos)
        this.Add(info);
    }

    public bool IsZero(EnumZeroCheck pCheckType, SalesByMonthHorizontalByDept pSource) => pSource == null || this.IsZero(pCheckType, (SalesByMonthHorizontalByTeam) pSource);

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        if (!base.GetFieldValues(p_rs))
          return false;
        this.dpt_ViewCode = p_rs.GetFieldString("dpt_ViewCode");
        this.dpt_DeptName = p_rs.GetFieldString("dpt_DeptName");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public async Task<IList<SalesByMonthHorizontalByDept>> SelectMonthHorizontalByDeptListAsync(
      object p_param)
    {
      SalesByMonthHorizontalByDept horizontalByDept1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(horizontalByDept1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, horizontalByDept1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(horizontalByDept1.GetSelectQuery(p_param)))
        {
          horizontalByDept1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + horizontalByDept1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<SalesByMonthHorizontalByDept>) null;
        }
        IList<SalesByMonthHorizontalByDept> lt_list = (IList<SalesByMonthHorizontalByDept>) new List<SalesByMonthHorizontalByDept>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            SalesByMonthHorizontalByDept horizontalByDept2 = horizontalByDept1.OleDB.Create<SalesByMonthHorizontalByDept>();
            if (horizontalByDept2.GetFieldValues(rs))
            {
              horizontalByDept2.row_number = lt_list.Count + 1;
              lt_list.Add(horizontalByDept2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + horizontalByDept1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<SalesByMonthHorizontalByDept> SelectMonthHorizontalByDeptEnumerableAsync(
      object p_param)
    {
      SalesByMonthHorizontalByDept horizontalByDept1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(horizontalByDept1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, horizontalByDept1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(horizontalByDept1.GetSelectQuery(p_param)))
        {
          horizontalByDept1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + horizontalByDept1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            SalesByMonthHorizontalByDept horizontalByDept2 = horizontalByDept1.OleDB.Create<SalesByMonthHorizontalByDept>();
            if (horizontalByDept2.GetFieldValues(rs))
            {
              horizontalByDept2.row_number = ++row_number;
              yield return horizontalByDept2;
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
        stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "si_StoreName", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "dpt_DeptName", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "dpt_ViewCode", hashtable[(object) "_KEY_WORD_"]));
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
        SaleByDayDateStore saleByDayDateStore = new SaleByDayDateStore();
        string uniBase = UbModelBase.UNI_BASE;
        string str = this.TableCode.ToString();
        string empty = string.Empty;
        long p_SiteID = 0;
        int p_bgg_GroupID = 0;
        bool p_isStoreTotal = false;
        bool flag = false;
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
          if (hashtable.ContainsKey((object) "_ORDER_BY_COL_") && hashtable[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable.ContainsKey((object) "sbd_SiteID") && Convert.ToInt64(hashtable[(object) "sbd_SiteID"].ToString()) > 0L)
            p_SiteID = Convert.ToInt64(hashtable[(object) "sbd_SiteID"].ToString());
          if (hashtable.ContainsKey((object) "bgg_GroupID") && Convert.ToInt32(hashtable[(object) "bgg_GroupID"].ToString()) > 0)
            p_bgg_GroupID = Convert.ToInt32(hashtable[(object) "bgg_GroupID"].ToString());
          if (hashtable.ContainsKey((object) "_IS_STORE_TOTAL_SUM_") && Convert.ToBoolean(hashtable[(object) "_IS_STORE_TOTAL_SUM_"].ToString()))
            p_isStoreTotal = Convert.ToBoolean(hashtable[(object) "_IS_STORE_TOTAL_SUM_"].ToString());
          if (hashtable.ContainsKey((object) "_IsGoalSelect_") && Convert.ToBoolean(hashtable[(object) "_IsGoalSelect_"].ToString()))
            flag = Convert.ToBoolean(hashtable[(object) "_IsGoalSelect_"].ToString());
        }
        stringBuilder.Append(saleByDayDateStore.ToWithStoreQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(saleByDayDateStore.ToWithSupplierQuery(p_param, uniBase, p_SiteID));
        if (p_bgg_GroupID > 0)
          stringBuilder.Append(saleByDayDateStore.ToWithBookmarkGoodsQuery(p_param, uniBase, p_SiteID, p_bgg_GroupID));
        stringBuilder.Append(saleByDayDateStore.ToWithGoodsHistoryQuery(p_param, uniBase, p_SiteID, p_isStoreTotal));
        stringBuilder.Append(saleByDayDateStore.ToWithDeptLv1Query(p_param, uniBase, p_SiteID));
        stringBuilder.Append(saleByDayDateStore.ToWithDeptLv2Query(p_param, uniBase, p_SiteID));
        stringBuilder.Append(saleByDayDateStore.ToWithDeptLv3Query(p_param, uniBase, p_SiteID));
        stringBuilder.Append("\n,T_BASE AS (SELECT");
        stringBuilder.Append(" " + "sbd_SaleDate".DateToStr(EnumDbDateType.YYYYMM) + " AS sbd_SaleMonth");
        stringBuilder.Append(",");
        if (p_isStoreTotal)
          stringBuilder.Append(" 1 AS");
        stringBuilder.Append(" sbd_StoreCode");
        stringBuilder.Append(",dpt_lv1_ID,dpt_lv2_ID,dept_code");
        stringBuilder.Append(SaleByDayDateStore.BaseColMaker);
        stringBuilder.Append("\n FROM " + DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_SALES) + str + " " + DbQueryHelper.ToWithNolock() + "\n INNER JOIN T_HISTORY ON sbd_StoreCode=gdh_StoreCode AND sbd_GoodsCode=gdh_GoodsCode AND sbd_SaleDate >= gdh_StartDate AND sbd_SaleDate <= gdh_EndDate AND sbd_SiteID=gdh_SiteID");
        if (p_bgg_GroupID > 0)
          stringBuilder.Append("\n INNER JOIN T_BOOKMARK_GOODS ON sbd_GoodsCode=bgl_GoodsCode AND sbd_SiteID=bgl_SiteID");
        p_param1.Clear();
        p_param1 = saleByDayDateStore.SearchConditionDefault((Hashtable) p_param);
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "sbd_SiteID"))
            p_param1.Add((object) "sbd_SiteID", (object) p_SiteID);
          stringBuilder.Append("\n");
          stringBuilder.Append(this.GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format("\n WHERE {0}={1}", (object) "sbd_SiteID", (object) p_SiteID));
        stringBuilder.Append("\n GROUP BY " + "sbd_SaleDate".DateToStr(EnumDbDateType.YYYYMM));
        if (!p_isStoreTotal)
          stringBuilder.Append("\n,sbd_StoreCode");
        stringBuilder.Append(",dpt_lv1_ID,dpt_lv2_ID,dept_code");
        stringBuilder.Append(")");
        if (flag)
        {
          stringBuilder.Append("\n,T_BASE_GOAL_DEPT AS (SELECT");
          stringBuilder.Append(" " + "gbd_SaleDate".DateToStr(EnumDbDateType.YYYYMM) + " AS sbd_SaleMonth");
          stringBuilder.Append(",");
          if (p_isStoreTotal)
            stringBuilder.Append(" 1 AS");
          else
            stringBuilder.Append(" gbd_StoreCode AS");
          stringBuilder.Append(" sbd_StoreCode");
          stringBuilder.Append(",dpt_lv1_ID,dpt_lv2_ID,dept_code");
          stringBuilder.Append(SaleByDayDateStore.BaseGoalDeptColMaker);
          stringBuilder.Append(string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_SALES), (object) TableCodeType.GoalByDept, (object) DbQueryHelper.ToWithNolock()) + "\n INNER JOIN " + DbQueryHelper.ToDBNameBridge(uniBase) + "view_dept_v1 " + DbQueryHelper.ToWithNolock() + " ON gbd_DeptCode=view_dept_v1.dept_code AND gbd_SiteID=view_dept_v1.dpt_SiteID");
          p_param1.Clear();
          p_param1 = saleByDayDateStore.SearchConditionGoalByDept((Hashtable) p_param);
          if (p_param1.Count > 0)
          {
            if (!p_param1.ContainsKey((object) "gbd_SiteID"))
              p_param1.Add((object) "gbd_SiteID", (object) p_SiteID);
            stringBuilder.Append("\n");
            stringBuilder.Append(new GoalByDeptView().GetSelectWhereAnd((object) p_param1));
          }
          else if (p_SiteID > 0L)
            stringBuilder.Append(string.Format("\n WHERE {0}={1}", (object) "gbd_SiteID", (object) p_SiteID));
          stringBuilder.Append("\n GROUP BY " + "gbd_SaleDate".DateToStr(EnumDbDateType.YYYYMM));
          if (!p_isStoreTotal)
            stringBuilder.Append(",gbd_StoreCode");
          stringBuilder.Append(",dpt_lv1_ID,dpt_lv2_ID,dept_code");
          stringBuilder.Append(")");
        }
        stringBuilder.Append("\nSELECTNULL AS sbd_SaleDate,sbd_SaleMonth,sbd_StoreCode,0 AS sbd_BoxCode,0 AS sbd_GoodsCode,0 AS sbd_Supplier,0 AS sbd_SupplierType,0 AS sbd_CategoryCode,dept_code AS sbd_DeptCode,0 AS sbd_MakerCode,0 AS sbd_KeySeq" + string.Format(",{0} AS {1}", (object) p_SiteID, (object) "sbd_SiteID") + ",0 AS sbd_DayOfWeek,0 AS sbd_WeekOfYear,0 AS sbd_DayOfYear,0 AS sbd_SkyCondition,0 AS sbd_TaxDiv,0 AS sbd_SalesUnit,0 AS sbd_StockUnit");
        stringBuilder.Append(SaleByDayDateStore.MainCol);
        if (p_isStoreTotal)
          stringBuilder.Append("\n,통합 AS si_StoreName");
        else
          stringBuilder.Append("\n,si_StoreName");
        stringBuilder.Append(",si_StoreViewCode,si_UseYn,si_StoreType");
        stringBuilder.Append("\n,dpt_lv1_ID,T_DEPT_LV1_NAME.dpt_ViewCode AS dpt_lv1_ViewCode,T_DEPT_LV1_NAME.dpt_DeptName AS dpt_lv1_Name,dpt_lv2_ID,T_DEPT_LV2_NAME.dpt_ViewCode AS dpt_lv2_ViewCode,T_DEPT_LV2_NAME.dpt_DeptName AS dpt_lv2_Name,dept_code,T_DEPT_LV3_NAME.dpt_ViewCode AS dpt_ViewCode,T_DEPT_LV3_NAME.dpt_DeptName AS dpt_DeptName");
        stringBuilder.Append("\nFROM (");
        stringBuilder.Append("\nSELECT sbd_SaleMonth,sbd_StoreCode");
        stringBuilder.Append(",dpt_lv1_ID,dpt_lv2_ID,dept_code");
        stringBuilder.Append(SaleByDayDateStore.SubCol);
        stringBuilder.Append("\nFROM (");
        stringBuilder.Append("\nSELECT sbd_SaleMonth,sbd_StoreCode");
        stringBuilder.Append(",dpt_lv1_ID,dpt_lv2_ID,dept_code");
        stringBuilder.Append(SaleByDayDateStore.TableCol);
        stringBuilder.Append("\nFROM T_BASE");
        if (flag)
        {
          stringBuilder.Append("\nUNION ALL");
          stringBuilder.Append("\nSELECT sbd_SaleMonth,sbd_StoreCode");
          stringBuilder.Append(",dpt_lv1_ID,dpt_lv2_ID,dept_code");
          stringBuilder.Append(SaleByDayDateStore.TableColGoal);
          stringBuilder.Append("\nFROM T_BASE_GOAL_DEPT");
        }
        stringBuilder.Append("\n) SUB");
        stringBuilder.Append("\nGROUP BY sbd_SaleMonth,sbd_StoreCode");
        stringBuilder.Append(",dpt_lv1_ID,dpt_lv2_ID,dept_code");
        stringBuilder.Append("\n) MAIN");
        stringBuilder.Append("\nINNER JOIN T_STORE ON sbd_StoreCode=si_StoreCode" + string.Format(" AND {0}={1}", (object) "si_SiteID", (object) p_SiteID) + "\n LEFT OUTER JOIN T_DEPT_LV1_NAME ON dpt_lv1_ID=T_DEPT_LV1_NAME.dpt_ID" + string.Format(" AND T_DEPT_LV1_NAME.{0}={1}", (object) "dpt_SiteID", (object) p_SiteID) + "\n LEFT OUTER JOIN T_DEPT_LV2_NAME ON dpt_lv2_ID=T_DEPT_LV2_NAME.dpt_ID" + string.Format(" AND T_DEPT_LV2_NAME.{0}={1}", (object) "dpt_SiteID", (object) p_SiteID) + "\n LEFT OUTER JOIN T_DEPT_LV3_NAME ON dept_code=T_DEPT_LV3_NAME.dpt_ID" + string.Format(" AND T_DEPT_LV3_NAME.{0}={1}", (object) "dpt_SiteID", (object) p_SiteID));
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
