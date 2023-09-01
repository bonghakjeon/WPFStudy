// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Day.Horizontal.SalesByDayHorizontalByStore
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
using UniBiz.Bo.Models.UniSales.SalesBy.GoalBy.GoalByDept;
using UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Date;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Day.Horizontal
{
  public class SalesByDayHorizontalByStore : SalesByDayGoal<SalesByDayHorizontalByStore>
  {
    private int _si_StoreCode;
    private string _si_StoreName;
    private string _si_StoreViewCode;
    private string _si_UseYn;
    private int _si_StoreType;
    private IList<SalesByDayGoal> _Lt_Details;

    public int si_StoreCode
    {
      get => this._si_StoreCode;
      set
      {
        this._si_StoreCode = value;
        this.Changed(nameof (si_StoreCode));
        this.Changed("KeyCode");
      }
    }

    public override string KeyCode => string.Format("{0}", (object) this.si_StoreCode);

    public string si_StoreName
    {
      get => this._si_StoreName;
      set
      {
        this._si_StoreName = value;
        this.Changed(nameof (si_StoreName));
      }
    }

    public string si_StoreViewCode
    {
      get => this._si_StoreViewCode;
      set
      {
        this._si_StoreViewCode = value;
        this.Changed(nameof (si_StoreViewCode));
      }
    }

    public string si_UseYn
    {
      get => this._si_UseYn;
      set
      {
        this._si_UseYn = value;
        this.Changed(nameof (si_UseYn));
        this.Changed("si_IsUseYn");
        this.Changed("si_UseYnDesc");
      }
    }

    public bool si_IsUseYn => "Y".Equals(this.si_UseYn);

    public string si_UseYnDesc => !"Y".Equals(this.si_UseYn) ? "미사용" : "사용";

    public int si_StoreType
    {
      get => this._si_StoreType;
      set
      {
        this._si_StoreType = value;
        this.Changed(nameof (si_StoreType));
        this.Changed("si_StoreTypeDesc");
      }
    }

    public string si_StoreTypeDesc => this.si_StoreType != 0 ? Enum2StrConverter.ToStoreType(this.si_StoreType).ToDescription() : string.Empty;

    [JsonPropertyName("lt_Details")]
    public IList<SalesByDayGoal> Lt_Details
    {
      get => this._Lt_Details ?? (this._Lt_Details = (IList<SalesByDayGoal>) new List<SalesByDayGoal>());
      set
      {
        this._Lt_Details = value;
        this.Changed(nameof (Lt_Details));
      }
    }

    public override string ToString() => string.Format("{0} [{1}:{2}] Count : {3}", (object) nameof (SalesByDayHorizontalByStore), (object) this.si_StoreName, (object) this.si_StoreCode, (object) this.Lt_Details.Count);

    public override void Clear()
    {
      base.Clear();
      this.si_StoreCode = 0;
      this.si_StoreName = string.Empty;
      this.si_StoreViewCode = string.Empty;
      this.si_UseYn = "Y";
      this.si_StoreType = 0;
      this.Lt_Details = (IList<SalesByDayGoal>) null;
    }

    public void PutInfo(SalesByDayHorizontalByStore pSource)
    {
      this.si_StoreName = pSource.si_StoreName;
      this.si_StoreViewCode = pSource.si_StoreViewCode;
      this.si_UseYn = pSource.si_UseYn;
      this.si_StoreType = pSource.si_StoreType;
    }

    public void InitInfo(SalesByDayHorizontalByStore pData, IList<DateTime> p_Days)
    {
      if (!this.KeyCode.Equals(pData.KeyCode))
        throw new Exception("pData 의 [sbd_StoreCode] 이 KeyCode 와 다릅니다");
      this.PutInfo(pData);
      foreach (DateTime pDay in (IEnumerable<DateTime>) p_Days)
      {
        IList<SalesByDayGoal> ltDetails = this.Lt_Details;
        SalesByDayGoal salesByDayGoal = new SalesByDayGoal();
        salesByDayGoal.sbd_SaleDate = new DateTime?(pDay);
        salesByDayGoal.sbd_StoreCode = this.si_StoreCode;
        ltDetails.Add(salesByDayGoal);
      }
    }

    public void Add(SalesByDayHorizontalByStore item)
    {
      if (this.si_StoreCode == 0)
        this.si_StoreCode = item.sbd_StoreCode;
      else if (!this.KeyCode.Equals(item.KeyCode))
        throw new Exception("item 의 sbd_StoreCode 이 si_StoreCode 와 다릅니다");
      this.CalcAddSum((SalesByDayGoal) item);
      SalesByDayGoal salesByDayGoal = this.Lt_Details.FirstOrDefault<SalesByDayGoal>((Func<SalesByDayGoal, bool>) (it => it.sbd_SaleDate.Equals((object) item.sbd_SaleDate)));
      if (salesByDayGoal == null)
        this.Lt_Details.Add((SalesByDayGoal) item);
      else
        salesByDayGoal.PutData((SalesByDayGoal) item);
    }

    public void AddRange(IList<SalesByDayHorizontalByStore> infos)
    {
      foreach (SalesByDayHorizontalByStore info in (IEnumerable<SalesByDayHorizontalByStore>) infos)
        this.Add(info);
    }

    public bool IsZero(EnumZeroCheck pCheckType, SalesByDayHorizontalByStore pSource) => pSource == null || this.IsZero(pCheckType, (SalesByDayGoal) pSource);

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        if (!base.GetFieldValues(p_rs))
          return false;
        this.si_StoreCode = this.sbd_StoreCode;
        this.si_StoreName = p_rs.GetFieldString("si_StoreName");
        this.si_StoreViewCode = p_rs.GetFieldString("si_StoreViewCode");
        this.si_UseYn = p_rs.GetFieldString("si_UseYn");
        this.si_StoreType = p_rs.GetFieldInt("si_StoreType");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public async Task<IList<SalesByDayHorizontalByStore>> SelectDayHorizontalByStoreListAsync(
      object p_param)
    {
      SalesByDayHorizontalByStore horizontalByStore1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(horizontalByStore1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, horizontalByStore1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(horizontalByStore1.GetSelectQuery(p_param)))
        {
          horizontalByStore1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + horizontalByStore1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<SalesByDayHorizontalByStore>) null;
        }
        IList<SalesByDayHorizontalByStore> lt_list = (IList<SalesByDayHorizontalByStore>) new List<SalesByDayHorizontalByStore>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            SalesByDayHorizontalByStore horizontalByStore2 = horizontalByStore1.OleDB.Create<SalesByDayHorizontalByStore>();
            if (horizontalByStore2.GetFieldValues(rs))
            {
              horizontalByStore2.row_number = lt_list.Count + 1;
              lt_list.Add(horizontalByStore2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + horizontalByStore1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<SalesByDayHorizontalByStore> SelectDayHorizontalByStoreEnumerableAsync(
      object p_param)
    {
      SalesByDayHorizontalByStore horizontalByStore1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(horizontalByStore1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, horizontalByStore1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(horizontalByStore1.GetSelectQuery(p_param)))
        {
          horizontalByStore1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + horizontalByStore1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            SalesByDayHorizontalByStore horizontalByStore2 = horizontalByStore1.OleDB.Create<SalesByDayHorizontalByStore>();
            if (horizontalByStore2.GetFieldValues(rs))
            {
              horizontalByStore2.row_number = ++row_number;
              yield return horizontalByStore2;
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
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "si_StoreViewCode", hashtable[(object) "_KEY_WORD_"]));
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
        stringBuilder.Append("\n,T_BASE AS (SELECT");
        stringBuilder.Append(" sbd_SaleDate");
        stringBuilder.Append(",");
        if (p_isStoreTotal)
          stringBuilder.Append(" 1 AS");
        stringBuilder.Append(" sbd_StoreCode");
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
        stringBuilder.Append("\n GROUP BY sbd_SaleDate");
        if (!p_isStoreTotal)
          stringBuilder.Append("\n,sbd_StoreCode");
        stringBuilder.Append(")");
        if (flag)
        {
          stringBuilder.Append("\n,T_BASE_GOAL_DEPT AS (SELECT");
          stringBuilder.Append(" gbd_SaleDate AS sbd_SaleDate");
          stringBuilder.Append(",");
          if (p_isStoreTotal)
            stringBuilder.Append(" 1 AS");
          else
            stringBuilder.Append(" gbd_StoreCode AS");
          stringBuilder.Append(" sbd_StoreCode");
          stringBuilder.Append(SaleByDayDateStore.BaseGoalDeptColMaker);
          stringBuilder.Append(string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_SALES), (object) TableCodeType.GoalByDept, (object) DbQueryHelper.ToWithNolock()));
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
          stringBuilder.Append("\n GROUP BY gbd_SaleDate");
          if (!p_isStoreTotal)
            stringBuilder.Append(",gbd_StoreCode");
          stringBuilder.Append(")");
        }
        stringBuilder.Append("\nSELECT sbd_SaleDate,sbd_StoreCode,0 AS sbd_BoxCode,0 AS sbd_GoodsCode,0 AS sbd_Supplier,0 AS sbd_SupplierType,0 AS sbd_CategoryCode,0 AS sbd_DeptCode,0 AS sbd_MakerCode,0 AS sbd_KeySeq" + string.Format(",{0} AS {1}", (object) p_SiteID, (object) "sbd_SiteID") + ",0 AS sbd_DayOfWeek,0 AS sbd_WeekOfYear,0 AS sbd_DayOfYear,0 AS sbd_SkyCondition,0 AS sbd_TaxDiv,0 AS sbd_SalesUnit,0 AS sbd_StockUnit");
        stringBuilder.Append(SaleByDayDateStore.MainCol);
        if (p_isStoreTotal)
          stringBuilder.Append("\n,통합 AS si_StoreName");
        else
          stringBuilder.Append("\n,si_StoreName");
        stringBuilder.Append(",si_StoreViewCode,si_UseYn,si_StoreType");
        stringBuilder.Append("\nFROM (");
        stringBuilder.Append("\nSELECT sbd_SaleDate,sbd_StoreCode");
        stringBuilder.Append(SaleByDayDateStore.SubCol);
        stringBuilder.Append("\nFROM (");
        stringBuilder.Append("\nSELECT sbd_SaleDate,sbd_StoreCode");
        stringBuilder.Append(SaleByDayDateStore.TableCol);
        stringBuilder.Append("\nFROM T_BASE");
        if (flag)
        {
          stringBuilder.Append("\nUNION ALL");
          stringBuilder.Append("\nSELECT sbd_SaleDate,sbd_StoreCode");
          stringBuilder.Append(SaleByDayDateStore.TableColGoal);
          stringBuilder.Append("\nFROM T_BASE_GOAL_DEPT");
        }
        stringBuilder.Append("\n) SUB");
        stringBuilder.Append("\nGROUP BY sbd_SaleDate,sbd_StoreCode");
        stringBuilder.Append("\n) MAIN");
        stringBuilder.Append("\nINNER JOIN T_STORE ON sbd_StoreCode=si_StoreCode" + string.Format(" AND {0}={1}", (object) "si_SiteID", (object) p_SiteID));
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
