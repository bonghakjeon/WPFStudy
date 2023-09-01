// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByTime.Date.SaleByTimeDateTeam
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
  public class SaleByTimeDateTeam : SaleByTimeDateStore<SaleByTimeDateTeam>
  {
    private int _dpt_lv1_ID;
    private string _dpt_lv1_ViewCode;
    private string _dpt_lv1_Name;
    private int _dpt_lv2_ID;
    private string _dpt_lv2_ViewCode;
    private string _dpt_lv2_Name;

    public int dpt_lv1_ID
    {
      get => this._dpt_lv1_ID;
      set
      {
        this._dpt_lv1_ID = value;
        this.Changed(nameof (dpt_lv1_ID));
      }
    }

    public string dpt_lv1_ViewCode
    {
      get => this._dpt_lv1_ViewCode;
      set
      {
        this._dpt_lv1_ViewCode = value;
        this.Changed(nameof (dpt_lv1_ViewCode));
      }
    }

    public string dpt_lv1_Name
    {
      get => this._dpt_lv1_Name;
      set
      {
        this._dpt_lv1_Name = value;
        this.Changed(nameof (dpt_lv1_Name));
      }
    }

    public int dpt_lv2_ID
    {
      get => this._dpt_lv2_ID;
      set
      {
        this._dpt_lv2_ID = value;
        this.Changed(nameof (dpt_lv2_ID));
      }
    }

    public string dpt_lv2_ViewCode
    {
      get => this._dpt_lv2_ViewCode;
      set
      {
        this._dpt_lv2_ViewCode = value;
        this.Changed(nameof (dpt_lv2_ViewCode));
      }
    }

    public string dpt_lv2_Name
    {
      get => this._dpt_lv2_Name;
      set
      {
        this._dpt_lv2_Name = value;
        this.Changed(nameof (dpt_lv2_Name));
      }
    }

    public override Dictionary<string, TTableColumn> ToColumnInfo() => base.ToColumnInfo();

    public override void Clear()
    {
      base.Clear();
      this.dpt_lv1_ID = 0;
      this.dpt_lv1_ViewCode = string.Empty;
      this.dpt_lv1_Name = string.Empty;
      this.dpt_lv2_ID = 0;
      this.dpt_lv2_ViewCode = string.Empty;
      this.dpt_lv2_Name = string.Empty;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new SaleByTimeDateTeam();

    public override object Clone()
    {
      SaleByTimeDateTeam saleByTimeDateTeam = base.Clone() as SaleByTimeDateTeam;
      saleByTimeDateTeam.dpt_lv1_ID = this.dpt_lv1_ID;
      saleByTimeDateTeam.dpt_lv1_ViewCode = this.dpt_lv1_ViewCode;
      saleByTimeDateTeam.dpt_lv1_Name = this.dpt_lv1_Name;
      saleByTimeDateTeam.dpt_lv2_ID = this.dpt_lv2_ID;
      saleByTimeDateTeam.dpt_lv2_ViewCode = this.dpt_lv2_ViewCode;
      saleByTimeDateTeam.dpt_lv2_Name = this.dpt_lv2_Name;
      return (object) saleByTimeDateTeam;
    }

    public void PutData(SaleByTimeDateTeam pSource)
    {
      this.PutData((SaleByTimeDateStore) pSource);
      this.dpt_lv1_ID = pSource.dpt_lv1_ID;
      this.dpt_lv1_ViewCode = pSource.dpt_lv1_ViewCode;
      this.dpt_lv1_Name = pSource.dpt_lv1_Name;
      this.dpt_lv2_ID = pSource.dpt_lv2_ID;
      this.dpt_lv2_ViewCode = pSource.dpt_lv2_ViewCode;
      this.dpt_lv2_Name = pSource.dpt_lv2_Name;
    }

    public bool IsZero(EnumZeroCheck pCheckType, SaleByTimeDateTeam pSource) => pSource == null || this.IsZero(pCheckType, (SaleByTimeDateStore) pSource);

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        if (!base.GetFieldValues(p_rs))
          return false;
        this.dpt_lv1_ID = p_rs.GetFieldInt("dpt_lv1_ID");
        this.dpt_lv1_ViewCode = p_rs.GetFieldString("dpt_lv1_ViewCode");
        this.dpt_lv1_Name = p_rs.GetFieldString("dpt_lv1_Name");
        this.dpt_lv2_ID = p_rs.GetFieldInt("dpt_lv2_ID");
        this.dpt_lv2_ViewCode = p_rs.GetFieldString("dpt_lv2_ViewCode");
        this.dpt_lv2_Name = p_rs.GetFieldString("dpt_lv2_Name");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public async Task<IList<SaleByTimeDateTeam>> SelectDateTeamListAsync(object p_param)
    {
      SaleByTimeDateTeam saleByTimeDateTeam1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(saleByTimeDateTeam1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, saleByTimeDateTeam1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(saleByTimeDateTeam1.GetSelectQuery(p_param)))
        {
          saleByTimeDateTeam1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + saleByTimeDateTeam1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<SaleByTimeDateTeam>) null;
        }
        IList<SaleByTimeDateTeam> lt_list = (IList<SaleByTimeDateTeam>) new List<SaleByTimeDateTeam>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            SaleByTimeDateTeam saleByTimeDateTeam2 = saleByTimeDateTeam1.OleDB.Create<SaleByTimeDateTeam>();
            if (saleByTimeDateTeam2.GetFieldValues(rs))
            {
              saleByTimeDateTeam2.row_number = lt_list.Count + 1;
              lt_list.Add(saleByTimeDateTeam2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + saleByTimeDateTeam1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<SaleByTimeDateTeam> SelectDateTeamEnumerableAsync(object p_param)
    {
      SaleByTimeDateTeam saleByTimeDateTeam1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(saleByTimeDateTeam1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, saleByTimeDateTeam1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(saleByTimeDateTeam1.GetSelectQuery(p_param)))
        {
          saleByTimeDateTeam1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + saleByTimeDateTeam1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            SaleByTimeDateTeam saleByTimeDateTeam2 = saleByTimeDateTeam1.OleDB.Create<SaleByTimeDateTeam>();
            if (saleByTimeDateTeam2.GetFieldValues(rs))
            {
              saleByTimeDateTeam2.row_number = ++row_number;
              yield return saleByTimeDateTeam2;
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
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "dpt_lv2_Name", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "dpt_lv2_ViewCode", hashtable[(object) "_KEY_WORD_"]));
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
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_BASE AS (SELECT");
        if (p_isStoreTotal)
          stringBuilder.Append(" 1 AS");
        stringBuilder.Append(" sbt_StoreCode");
        stringBuilder.Append(string.Format(",{0} AS {1}", (object) 1, (object) "rowDateCondition") + string.Format(",{0} AS {1}", (object) 1, (object) "rowTimeStatus"));
        stringBuilder.Append(",dpt_lv1_ID,dpt_lv2_ID");
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
        stringBuilder.Append(" dpt_lv1_ID,dpt_lv2_ID");
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        if (flag)
        {
          stringBuilder.Append(",T_BEFORE AS (SELECT");
          if (p_isStoreTotal)
            stringBuilder.Append(" 1 AS");
          stringBuilder.Append(" sbt_StoreCode");
          stringBuilder.Append(string.Format(",{0} AS {1}", (object) 2, (object) "rowDateCondition") + string.Format(",{0} AS {1}", (object) 5, (object) "rowTimeStatus"));
          stringBuilder.Append(",dpt_lv1_ID,dpt_lv2_ID");
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
          stringBuilder.Append(" dpt_lv1_ID,dpt_lv2_ID");
          stringBuilder.Append(")");
          stringBuilder.Append("\n");
        }
        stringBuilder.Append("SELECT NULL AS sbt_SaleDate,sbt_StoreCode,0 AS sbt_CategoryCode,0 AS sbt_DeptCode,0 AS sbt_BoxCode,0 AS sbt_GoodsCode,0 AS sbt_Supplier,0 AS sbt_KeySeq" + string.Format(",{0} AS {1}", (object) p_SiteID, (object) "sbt_SiteID") + ",0 AS sbt_DayOfWeek,0 AS sbt_WeekOfYear,0 AS sbt_DayOfYear");
        stringBuilder.Append(",rowDateCondition,rowTimeStatus");
        stringBuilder.Append(SaleByTimeDateStore.MainCol);
        if (p_isStoreTotal)
          stringBuilder.Append("\n,통합 AS si_StoreName");
        else
          stringBuilder.Append("\n,si_StoreName");
        stringBuilder.Append(",si_StoreViewCode,si_UseYn,si_StoreType");
        stringBuilder.Append("\n,dpt_lv1_ID,T_DEPT_LV1_NAME.dpt_ViewCode AS dpt_lv1_ViewCode,T_DEPT_LV1_NAME.dpt_DeptName AS dpt_lv1_Name,dpt_lv2_ID,T_DEPT_LV2_NAME.dpt_ViewCode AS dpt_lv2_ViewCode,T_DEPT_LV2_NAME.dpt_DeptName AS dpt_lv2_Name");
        stringBuilder.Append("\nFROM (");
        stringBuilder.Append("\nSELECT sbt_StoreCode");
        stringBuilder.Append(",rowDateCondition,rowTimeStatus");
        stringBuilder.Append(",dpt_lv1_ID,dpt_lv2_ID");
        stringBuilder.Append(SaleByTimeDateStore.SubCol);
        stringBuilder.Append("\nFROM (");
        stringBuilder.Append("\nSELECT sbt_StoreCode");
        stringBuilder.Append(",rowDateCondition,rowTimeStatus");
        stringBuilder.Append(",dpt_lv1_ID,dpt_lv2_ID");
        stringBuilder.Append(SaleByTimeDateStore.TableCol);
        stringBuilder.Append("\nFROM T_BASE");
        if (flag)
        {
          stringBuilder.Append("\nUNION ALL");
          stringBuilder.Append("\nSELECT sbt_StoreCode");
          stringBuilder.Append(",rowDateCondition,rowTimeStatus");
          stringBuilder.Append(",dpt_lv1_ID,dpt_lv2_ID");
          stringBuilder.Append(SaleByTimeDateStore.TableCol);
          stringBuilder.Append("\nFROM T_BEFORE");
        }
        stringBuilder.Append("\n) SUB");
        stringBuilder.Append("\nGROUP BY sbt_StoreCode");
        stringBuilder.Append(",rowDateCondition,rowTimeStatus");
        stringBuilder.Append(",dpt_lv1_ID,dpt_lv2_ID");
        stringBuilder.Append("\n) MAIN");
        stringBuilder.Append("\nINNER JOIN T_STORE ON sbt_StoreCode=si_StoreCode" + string.Format(" AND {0}={1}", (object) "si_SiteID", (object) p_SiteID) + "\n LEFT OUTER JOIN T_DEPT_LV1_NAME ON dpt_lv1_ID=T_DEPT_LV1_NAME.dpt_ID" + string.Format(" AND T_DEPT_LV1_NAME.{0}={1}", (object) "dpt_SiteID", (object) p_SiteID) + "\n LEFT OUTER JOIN T_DEPT_LV2_NAME ON dpt_lv2_ID=T_DEPT_LV2_NAME.dpt_ID" + string.Format(" AND T_DEPT_LV2_NAME.{0}={1}", (object) "dpt_SiteID", (object) p_SiteID));
        stringBuilder.Append("\n");
        if (!string.IsNullOrEmpty(empty))
        {
          stringBuilder.Append(" ORDER BY " + empty);
        }
        else
        {
          stringBuilder.Append(" ORDER BY si_StoreViewCode,sbt_StoreCode");
          stringBuilder.Append(",T_DEPT_LV1_NAME.dpt_ViewCode,T_DEPT_LV2_NAME.dpt_ViewCode");
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
