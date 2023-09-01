// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByTime.Date.SaleByTimeDateCategoryTop
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

namespace UniBiz.Bo.Models.UniSales.SalesBy.SalesByTime.Date
{
  public class SaleByTimeDateCategoryTop : SaleByTimeDateDept<SaleByTimeDateCategoryTop>
  {
    private int _ctg_lv1_ID;
    private string _ctg_lv1_ViewCode;
    private string _ctg_lv1_Name;

    public int ctg_lv1_ID
    {
      get => this._ctg_lv1_ID;
      set
      {
        this._ctg_lv1_ID = value;
        this.Changed(nameof (ctg_lv1_ID));
      }
    }

    public string ctg_lv1_ViewCode
    {
      get => this._ctg_lv1_ViewCode;
      set
      {
        this._ctg_lv1_ViewCode = value;
        this.Changed(nameof (ctg_lv1_ViewCode));
      }
    }

    public string ctg_lv1_Name
    {
      get => this._ctg_lv1_Name;
      set
      {
        this._ctg_lv1_Name = value;
        this.Changed(nameof (ctg_lv1_Name));
      }
    }

    public override Dictionary<string, TTableColumn> ToColumnInfo() => base.ToColumnInfo();

    public override void Clear()
    {
      base.Clear();
      this.ctg_lv1_ID = 0;
      this.ctg_lv1_ViewCode = string.Empty;
      this.ctg_lv1_Name = string.Empty;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new SaleByTimeDateCategoryTop();

    public override object Clone()
    {
      SaleByTimeDateCategoryTop timeDateCategoryTop = base.Clone() as SaleByTimeDateCategoryTop;
      timeDateCategoryTop.ctg_lv1_ID = this.ctg_lv1_ID;
      timeDateCategoryTop.ctg_lv1_ViewCode = this.ctg_lv1_ViewCode;
      timeDateCategoryTop.ctg_lv1_Name = this.ctg_lv1_Name;
      return (object) timeDateCategoryTop;
    }

    public void PutData(SaleByTimeDateCategoryTop pSource)
    {
      this.PutData((SaleByTimeDateDept) pSource);
      this.ctg_lv1_ID = pSource.ctg_lv1_ID;
      this.ctg_lv1_ViewCode = pSource.ctg_lv1_ViewCode;
      this.ctg_lv1_Name = pSource.ctg_lv1_Name;
    }

    public bool IsZero(EnumZeroCheck pCheckType, SaleByTimeDateCategoryTop pSource) => pSource == null || this.IsZero(pCheckType, (SaleByTimeDateDept) pSource);

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        if (!base.GetFieldValues(p_rs))
          return false;
        this.ctg_lv1_ID = p_rs.GetFieldInt("ctg_lv1_ID");
        this.ctg_lv1_ViewCode = p_rs.GetFieldString("ctg_lv1_ViewCode");
        this.ctg_lv1_Name = p_rs.GetFieldString("ctg_lv1_Name");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public async Task<IList<SaleByTimeDateCategoryTop>> SelectDateCategoryTopListAsync(
      object p_param)
    {
      SaleByTimeDateCategoryTop timeDateCategoryTop1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(timeDateCategoryTop1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, timeDateCategoryTop1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(timeDateCategoryTop1.GetSelectQuery(p_param)))
        {
          timeDateCategoryTop1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + timeDateCategoryTop1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<SaleByTimeDateCategoryTop>) null;
        }
        IList<SaleByTimeDateCategoryTop> lt_list = (IList<SaleByTimeDateCategoryTop>) new List<SaleByTimeDateCategoryTop>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            SaleByTimeDateCategoryTop timeDateCategoryTop2 = timeDateCategoryTop1.OleDB.Create<SaleByTimeDateCategoryTop>();
            if (timeDateCategoryTop2.GetFieldValues(rs))
            {
              timeDateCategoryTop2.row_number = lt_list.Count + 1;
              lt_list.Add(timeDateCategoryTop2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + timeDateCategoryTop1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<SaleByTimeDateCategoryTop> SelectDateCategoryTopEnumerableAsync(
      object p_param)
    {
      SaleByTimeDateCategoryTop timeDateCategoryTop1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(timeDateCategoryTop1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, timeDateCategoryTop1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(timeDateCategoryTop1.GetSelectQuery(p_param)))
        {
          timeDateCategoryTop1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + timeDateCategoryTop1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            SaleByTimeDateCategoryTop timeDateCategoryTop2 = timeDateCategoryTop1.OleDB.Create<SaleByTimeDateCategoryTop>();
            if (timeDateCategoryTop2.GetFieldValues(rs))
            {
              timeDateCategoryTop2.row_number = ++row_number;
              yield return timeDateCategoryTop2;
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
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "ctg_lv1_Name", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "ctg_lv1_ViewCode", hashtable[(object) "_KEY_WORD_"]));
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
          if (hashtable.ContainsKey((object) "sbt_SiteID") && Convert.ToInt64(hashtable[(object) "sbt_SiteID"].ToString()) > 0L)
            p_SiteID = Convert.ToInt64(hashtable[(object) "sbt_SiteID"].ToString());
          if (hashtable.ContainsKey((object) "bgg_GroupID") && Convert.ToInt32(hashtable[(object) "bgg_GroupID"].ToString()) > 0)
            p_bgg_GroupID = Convert.ToInt32(hashtable[(object) "bgg_GroupID"].ToString());
          if (hashtable.ContainsKey((object) "_IS_STORE_TOTAL_SUM_") && Convert.ToBoolean(hashtable[(object) "_IS_STORE_TOTAL_SUM_"].ToString()))
            p_isStoreTotal = Convert.ToBoolean(hashtable[(object) "_IS_STORE_TOTAL_SUM_"].ToString());
          if (hashtable.ContainsKey((object) "_BEFORE_") && Convert.ToBoolean(hashtable[(object) "_BEFORE_"].ToString()))
            flag = Convert.ToBoolean(hashtable[(object) "_BEFORE_"].ToString());
        }
        stringBuilder.Append(this.ToWithStoreQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithSupplierQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithGoodsQuery(p_param, uniBase, p_SiteID));
        if (p_bgg_GroupID > 0)
          stringBuilder.Append(this.ToWithBookmarkGoodsQuery(p_param, uniBase, p_SiteID, p_bgg_GroupID));
        stringBuilder.Append(this.ToWithGoodsHistoryQuery(p_param, uniBase, p_SiteID, p_isStoreTotal));
        stringBuilder.Append(this.ToWithDeptLv1Query(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithDeptLv2Query(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithDeptLv3Query(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithCategoryLv1Query(p_param, uniBase, p_SiteID));
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_BASE AS (SELECT");
        if (p_isStoreTotal)
          stringBuilder.Append(" 1 AS");
        stringBuilder.Append(" sbt_StoreCode");
        stringBuilder.Append(string.Format(",{0} AS {1}", (object) 1, (object) "rowDateCondition") + string.Format(",{0} AS {1}", (object) 1, (object) "rowTimeStatus"));
        stringBuilder.Append(",dpt_lv1_ID,dpt_lv2_ID,dept_code");
        stringBuilder.Append(",ctg_lv1_ID");
        stringBuilder.Append(SaleByTimeDateStore.BaseColMaker);
        stringBuilder.Append(" FROM " + DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_SALES) + str + " " + DbQueryHelper.ToWithNolock() + "\n INNER JOIN T_HISTORY ON sbt_StoreCode=gdh_StoreCode AND sbt_GoodsCode=gdh_GoodsCode AND sbt_SaleDate >= gdh_StartDate AND sbt_SaleDate <= gdh_EndDate AND sbt_SiteID=gdh_SiteID");
        stringBuilder.Append(this.ToInnerJoinSupplierTypeQuery((Hashtable) p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToInnerJoinGoodsTypeQuery((Hashtable) p_param, uniBase, p_SiteID));
        if (p_bgg_GroupID > 0)
          stringBuilder.Append("\n INNER JOIN T_BOOKMARK_GOODS ON sbt_GoodsCode=bgl_GoodsCode AND sbt_SiteID=bgl_SiteID");
        p_param1.Clear();
        p_param1 = this.SearchConditionDefault((Hashtable) p_param);
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "sbt_SiteID"))
            p_param1.Add((object) "sbt_SiteID", (object) p_SiteID);
          stringBuilder.Append("\n");
          stringBuilder.Append(this.GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format("\n WHERE {0}={1}", (object) "sbt_SiteID", (object) p_SiteID));
        stringBuilder.Append("\n GROUP BY ");
        if (!p_isStoreTotal)
          stringBuilder.Append("\n sbt_StoreCode,");
        stringBuilder.Append(" dpt_lv1_ID,dpt_lv2_ID,dept_code");
        stringBuilder.Append(",ctg_lv1_ID");
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        if (flag)
        {
          stringBuilder.Append(",T_BEFORE AS (SELECT");
          if (p_isStoreTotal)
            stringBuilder.Append(" 1 AS");
          stringBuilder.Append(" sbt_StoreCode");
          stringBuilder.Append(string.Format(",{0} AS {1}", (object) 2, (object) "rowDateCondition") + string.Format(",{0} AS {1}", (object) 5, (object) "rowTimeStatus"));
          stringBuilder.Append(",dpt_lv1_ID,dpt_lv2_ID,dept_code");
          stringBuilder.Append(",ctg_lv1_ID");
          stringBuilder.Append(SaleByTimeDateStore.BaseColMaker);
          stringBuilder.Append(" FROM " + DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_SALES) + str + " " + DbQueryHelper.ToWithNolock() + "\n INNER JOIN T_HISTORY ON sbt_StoreCode=gdh_StoreCode AND sbt_GoodsCode=gdh_GoodsCode AND sbt_SaleDate >= gdh_StartDate AND sbt_SaleDate <= gdh_EndDate AND sbt_SiteID=gdh_SiteID");
          stringBuilder.Append(this.ToInnerJoinSupplierTypeQuery((Hashtable) p_param, uniBase, p_SiteID));
          stringBuilder.Append(this.ToInnerJoinGoodsTypeQuery((Hashtable) p_param, uniBase, p_SiteID));
          if (p_bgg_GroupID > 0)
            stringBuilder.Append("\n INNER JOIN T_BOOKMARK_GOODS ON sbt_GoodsCode=bgl_GoodsCode AND sbt_SiteID=bgl_SiteID");
          p_param1.Clear();
          p_param1 = this.SearchConditionBefore((Hashtable) p_param);
          if (p_param1.Count > 0)
          {
            if (!p_param1.ContainsKey((object) "sbt_SiteID"))
              p_param1.Add((object) "sbt_SiteID", (object) p_SiteID);
            stringBuilder.Append("\n");
            stringBuilder.Append(this.GetSelectWhereAnd((object) p_param1));
          }
          else if (p_SiteID > 0L)
            stringBuilder.Append(string.Format("\n WHERE {0}={1}", (object) "sbt_SiteID", (object) p_SiteID));
          stringBuilder.Append("\n GROUP BY ");
          if (!p_isStoreTotal)
            stringBuilder.Append("\n sbt_StoreCode,");
          stringBuilder.Append(" dpt_lv1_ID,dpt_lv2_ID,dept_code");
          stringBuilder.Append(",ctg_lv1_ID");
          stringBuilder.Append(")");
          stringBuilder.Append("\n");
        }
        stringBuilder.Append("SELECT NULL AS sbt_SaleDate,sbt_StoreCode,0 AS sbt_CategoryCode,dept_code AS sbt_DeptCode,0 AS sbt_BoxCode,0 AS sbt_GoodsCode,0 AS sbt_Supplier,0 AS sbt_KeySeq" + string.Format(",{0} AS {1}", (object) p_SiteID, (object) "sbt_SiteID") + ",0 AS sbt_DayOfWeek,0 AS sbt_WeekOfYear,0 AS sbt_DayOfYear");
        stringBuilder.Append(",rowDateCondition,rowTimeStatus");
        stringBuilder.Append(SaleByTimeDateStore.MainCol);
        if (p_isStoreTotal)
          stringBuilder.Append("\n,통합 AS si_StoreName");
        else
          stringBuilder.Append("\n,si_StoreName");
        stringBuilder.Append(",si_StoreViewCode,si_UseYn,si_StoreType");
        stringBuilder.Append("\n,dpt_lv1_ID,T_DEPT_LV1_NAME.dpt_ViewCode AS dpt_lv1_ViewCode,T_DEPT_LV1_NAME.dpt_DeptName AS dpt_lv1_Name,dpt_lv2_ID,T_DEPT_LV2_NAME.dpt_ViewCode AS dpt_lv2_ViewCode,T_DEPT_LV2_NAME.dpt_DeptName AS dpt_lv2_Name,dept_code,T_DEPT_LV3_NAME.dpt_ViewCode AS dpt_ViewCode,T_DEPT_LV3_NAME.dpt_DeptName AS dpt_DeptName,ctg_lv1_ID,T_CTG_LV_1_NAME.ctg_ViewCode AS ctg_lv1_ViewCode,T_CTG_LV_1_NAME.ctg_CategoryName AS ctg_lv1_Name");
        stringBuilder.Append("\nFROM (");
        stringBuilder.Append("\nSELECT sbt_StoreCode");
        stringBuilder.Append(",rowDateCondition,rowTimeStatus");
        stringBuilder.Append(",dpt_lv1_ID,dpt_lv2_ID,dept_code");
        stringBuilder.Append(",ctg_lv1_ID");
        stringBuilder.Append(SaleByTimeDateStore.SubCol);
        stringBuilder.Append("\nFROM (");
        stringBuilder.Append("\nSELECT sbt_StoreCode");
        stringBuilder.Append(",rowDateCondition,rowTimeStatus");
        stringBuilder.Append(",dpt_lv1_ID,dpt_lv2_ID,dept_code");
        stringBuilder.Append(",ctg_lv1_ID");
        stringBuilder.Append(SaleByTimeDateStore.TableCol);
        stringBuilder.Append("\nFROM T_BASE");
        if (flag)
        {
          stringBuilder.Append("\nUNION ALL");
          stringBuilder.Append("\nSELECT sbt_StoreCode");
          stringBuilder.Append(",rowDateCondition,rowTimeStatus");
          stringBuilder.Append(",dpt_lv1_ID,dpt_lv2_ID,dept_code");
          stringBuilder.Append(",ctg_lv1_ID");
          stringBuilder.Append(SaleByTimeDateStore.TableCol);
          stringBuilder.Append("\nFROM T_BEFORE");
        }
        stringBuilder.Append("\n) SUB");
        stringBuilder.Append("\nGROUP BY sbt_StoreCode");
        stringBuilder.Append(",rowDateCondition,rowTimeStatus");
        stringBuilder.Append(",dpt_lv1_ID,dpt_lv2_ID,dept_code");
        stringBuilder.Append(",ctg_lv1_ID");
        stringBuilder.Append("\n) MAIN");
        stringBuilder.Append("\nINNER JOIN T_STORE ON sbt_StoreCode=si_StoreCode" + string.Format(" AND {0}={1}", (object) "si_SiteID", (object) p_SiteID) + "\n LEFT OUTER JOIN T_DEPT_LV1_NAME ON dpt_lv1_ID=T_DEPT_LV1_NAME.dpt_ID" + string.Format(" AND T_DEPT_LV1_NAME.{0}={1}", (object) "dpt_SiteID", (object) p_SiteID) + "\n LEFT OUTER JOIN T_DEPT_LV2_NAME ON dpt_lv2_ID=T_DEPT_LV2_NAME.dpt_ID" + string.Format(" AND T_DEPT_LV2_NAME.{0}={1}", (object) "dpt_SiteID", (object) p_SiteID) + "\n LEFT OUTER JOIN T_DEPT_LV3_NAME ON dept_code=T_DEPT_LV3_NAME.dpt_ID" + string.Format(" AND T_DEPT_LV3_NAME.{0}={1}", (object) "dpt_SiteID", (object) p_SiteID) + "\n LEFT OUTER JOIN T_CTG_LV_1_NAME ON ctg_lv1_ID=T_CTG_LV_1_NAME.ctg_ID" + string.Format(" AND T_CTG_LV_1_NAME.{0}={1}", (object) "ctg_SiteID", (object) p_SiteID));
        stringBuilder.Append("\n");
        if (!string.IsNullOrEmpty(empty))
        {
          stringBuilder.Append(" ORDER BY " + empty);
        }
        else
        {
          stringBuilder.Append(" ORDER BY si_StoreViewCode,sbt_StoreCode");
          stringBuilder.Append(",T_DEPT_LV1_NAME.dpt_ViewCode,T_DEPT_LV2_NAME.dpt_ViewCode");
          stringBuilder.Append(",T_DEPT_LV3_NAME.dpt_ViewCode");
          stringBuilder.Append(",T_CTG_LV_1_NAME.ctg_ViewCode");
        }
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
