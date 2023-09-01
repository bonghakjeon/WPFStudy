// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Category.GoodsCountByCategory
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
using UniBiz.Bo.Models.UniBase.GoodsInfo.Goods;
using UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsHistory;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniBase.Category
{
  public class GoodsCountByCategory : CategoryView<GoodsCountByCategory>
  {
    private int _goods_Count;
    private int _goods_UseCount;
    private int _goods_EndOrderCount;
    private int _goods_EndSaleCount;

    public int goods_Count
    {
      get => this._goods_Count;
      set
      {
        this._goods_Count = value;
        this.Changed(nameof (goods_Count));
        this.Changed("goods_DisCount");
      }
    }

    public int goods_UseCount
    {
      get => this._goods_UseCount;
      set
      {
        this._goods_UseCount = value;
        this.Changed(nameof (goods_UseCount));
        this.Changed("goods_DisCount");
      }
    }

    public int goods_DisCount => this.goods_Count - this.goods_UseCount;

    public int goods_EndOrderCount
    {
      get => this._goods_EndOrderCount;
      set
      {
        this._goods_EndOrderCount = value;
        this.Changed(nameof (goods_EndOrderCount));
      }
    }

    public int goods_EndSaleCount
    {
      get => this._goods_EndSaleCount;
      set
      {
        this._goods_EndSaleCount = value;
        this.Changed(nameof (goods_EndSaleCount));
      }
    }

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("goods_Count", new TTableColumn()
      {
        tc_orgin_name = "goods_Count",
        tc_trans_name = "등록",
        tc_col_status = 2
      });
      columnInfo.Add("goods_UseCount", new TTableColumn()
      {
        tc_orgin_name = "goods_UseCount",
        tc_trans_name = "사용",
        tc_col_status = 2
      });
      columnInfo.Add("goods_DisCount", new TTableColumn()
      {
        tc_orgin_name = "goods_DisCount",
        tc_trans_name = "미사용",
        tc_col_status = 2
      });
      columnInfo.Add("goods_EndOrderCount", new TTableColumn()
      {
        tc_orgin_name = "goods_EndOrderCount",
        tc_trans_name = "발주중지",
        tc_col_status = 2
      });
      columnInfo.Add("goods_EndSaleCount", new TTableColumn()
      {
        tc_orgin_name = "goods_EndSaleCount",
        tc_trans_name = "판매종료",
        tc_col_status = 2
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.goods_Count = this.goods_UseCount = this.goods_EndOrderCount = this.goods_EndSaleCount = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new GoodsCountByCategory();

    public override object Clone()
    {
      GoodsCountByCategory goodsCountByCategory = base.Clone() as GoodsCountByCategory;
      goodsCountByCategory.goods_Count = this.goods_Count;
      goodsCountByCategory.goods_UseCount = this.goods_UseCount;
      goodsCountByCategory.goods_EndOrderCount = this.goods_EndOrderCount;
      goodsCountByCategory.goods_EndSaleCount = this.goods_EndSaleCount;
      return (object) goodsCountByCategory;
    }

    public void PutData(GoodsCountByCategory pSource)
    {
      this.PutData((CategoryView) pSource);
      this.goods_Count = pSource.goods_Count;
      this.goods_UseCount = pSource.goods_UseCount;
      this.goods_EndOrderCount = pSource.goods_EndOrderCount;
      this.goods_EndSaleCount = pSource.goods_EndSaleCount;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.goods_Count = p_rs.GetFieldInt("goods_Count");
      this.goods_UseCount = p_rs.GetFieldInt("goods_UseCount");
      this.goods_EndOrderCount = p_rs.GetFieldInt("goods_EndOrderCount");
      this.goods_EndSaleCount = p_rs.GetFieldInt("goods_EndSaleCount");
      return true;
    }

    public async Task<GoodsCountByCategory> SelectGoodsCountByOneAsync(
      int p_ctg_ID,
      long p_ctg_SiteID = 0)
    {
      GoodsCountByCategory goodsCountByCategory = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "ctg_ID",
          (object) p_ctg_ID
        }
      };
      if (p_ctg_SiteID > 0L)
        p_param.Add((object) "ctg_SiteID", (object) p_ctg_SiteID);
      return await goodsCountByCategory.SelectOneTAsync<GoodsCountByCategory>((object) p_param);
    }

    public async Task<IList<GoodsCountByCategory>> SelectGoodsCountByListAsync(object p_param)
    {
      GoodsCountByCategory goodsCountByCategory1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(goodsCountByCategory1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, goodsCountByCategory1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(goodsCountByCategory1.GetSelectQuery(p_param)))
        {
          goodsCountByCategory1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + goodsCountByCategory1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<GoodsCountByCategory>) null;
        }
        IList<GoodsCountByCategory> lt_list = (IList<GoodsCountByCategory>) new List<GoodsCountByCategory>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            GoodsCountByCategory goodsCountByCategory2 = goodsCountByCategory1.OleDB.Create<GoodsCountByCategory>();
            if (goodsCountByCategory2.GetFieldValues(rs))
            {
              goodsCountByCategory2.row_number = lt_list.Count + 1;
              lt_list.Add(goodsCountByCategory2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + goodsCountByCategory1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public override string GetSelectQuery(object p_param)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        string uniBase = UbModelBase.UNI_BASE;
        string str1 = this.TableCode.ToString();
        string empty = string.Empty;
        long num = 0;
        int p_value = 1;
        DateTime now = DateTime.Now;
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str1 = hashtable[(object) "table"].ToString();
          if (hashtable.ContainsKey((object) "_ORDER_BY_COL_") && hashtable[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable.ContainsKey((object) "ctg_SiteID") && Convert.ToInt64(hashtable[(object) "ctg_SiteID"].ToString()) > 0L)
            num = Convert.ToInt64(hashtable[(object) "ctg_SiteID"].ToString());
          if (hashtable.ContainsKey((object) "ctg_Depth") && Convert.ToInt32(hashtable[(object) "ctg_Depth"].ToString()) > 0)
            p_value = Convert.ToInt32(hashtable[(object) "ctg_Depth"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS (\nSELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n,T_EMPLOYEE_MOD AS (\nSELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n,T_PARENTS_NM AS (\nSELECT ctg_ID AS Parents_ID,ctg_SiteID AS Parents_SiteID,ctg_CategoryName AS ctg_ParentsName\nFROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str1 + " " + DbQueryHelper.ToWithNolock());
        if (num > 0L)
          stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "ctg_SiteID", (object) num));
        stringBuilder.Append(")");
        stringBuilder.Append("\n,T_DEPT_LV_1 AS (\nSELECT dpt_ID AS dpt_lv1_ID,dpt_SiteID AS dpt_lv1_SiteID,dpt_ViewCode AS dpt_lv1_ViewCode,dpt_DeptName AS dpt_lv1_Name,dpt_ParentsID AS dpt_lv1_ParentsID" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Dept, (object) DbQueryHelper.ToWithNolock()) + string.Format("\nWHERE {0}={1}", (object) "dpt_Depth", (object) 1));
        if (num > 0L)
          stringBuilder.Append(string.Format("  AND {0}={1}", (object) "dpt_SiteID", (object) num));
        stringBuilder.Append(")");
        stringBuilder.Append("\n,T_DEPT_LV_2 AS (\nSELECT dpt_ID AS dpt_lv2_ID,dpt_SiteID AS dpt_lv2_SiteID,dpt_ViewCode AS dpt_lv2_ViewCode,dpt_DeptName AS dpt_lv2_Name,dpt_ParentsID AS dpt_lv2_ParentsID" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Dept, (object) DbQueryHelper.ToWithNolock()) + string.Format("\nWHERE {0}={1}", (object) "dpt_Depth", (object) 2));
        if (num > 0L)
          stringBuilder.Append(string.Format("  AND {0}={1}", (object) "dpt_SiteID", (object) num));
        stringBuilder.Append(")");
        stringBuilder.Append("\n,T_DEPT_LV_3 AS (\nSELECT dpt_lv1_ID,dpt_lv1_ViewCode,dpt_lv1_Name,dpt_lv2_ID,dpt_lv2_ViewCode,dpt_lv2_Name,dpt_ParentsID AS dpt_parent_id,dpt_ID AS dept_code,dpt_SiteID,dpt_ViewCode,dpt_DeptName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Dept, (object) DbQueryHelper.ToWithNolock()) + "\nLEFT OUTER JOIN T_DEPT_LV_2 ON dpt_ParentsID=dpt_lv2_ID AND dpt_SiteID=dpt_lv2_SiteID\nLEFT OUTER JOIN T_DEPT_LV_1 ON dpt_lv2_ParentsID=dpt_lv1_ID AND dpt_lv2_SiteID=dpt_lv1_SiteID" + string.Format("\nWHERE {0}={1}", (object) "dpt_Depth", (object) 3));
        if (num > 0L)
          stringBuilder.Append(string.Format("  AND {0}={1}", (object) "dpt_SiteID", (object) num));
        stringBuilder.Append(")");
        stringBuilder.Append("\n,T_CTG_LV_1 AS (\nSELECT ctg_ID AS ctg_lv1_ID,ctg_SiteID AS ctg_lv1_SiteID,ctg_ViewCode AS ctg_lv1_ViewCode,ctg_CategoryName AS ctg_lv1_Name,ctg_ParentsID AS ctg_lv1_ParentsID,dpt_lv1_ID,dpt_lv1_ViewCode,dpt_lv1_Name,dpt_lv2_ID,dpt_lv2_ViewCode,dpt_lv2_Name,dpt_ViewCode,dpt_DeptName,dept_code AS dpt_ID,dpt_parent_id\nFROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str1 + " " + DbQueryHelper.ToWithNolock() + "\nLEFT OUTER JOIN T_DEPT_LV_3 ON ctg_ParentsID=dept_code AND ctg_SiteID=dpt_SiteID" + string.Format("\nWHERE {0}={1}", (object) "ctg_Depth", (object) 1));
        if (num > 0L)
          stringBuilder.Append(string.Format("  AND {0}={1}", (object) "ctg_SiteID", (object) num));
        stringBuilder.Append(")");
        stringBuilder.Append("\n,T_CTG_LV_2 AS (\nSELECT ctg_ID AS ctg_lv2_ID,ctg_SiteID AS ctg_lv2_SiteID,ctg_ViewCode AS ctg_lv2_ViewCode,ctg_CategoryName AS ctg_lv2_Name,ctg_ParentsID AS ctg_lv2_ParentsID\nFROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str1 + " " + DbQueryHelper.ToWithNolock() + string.Format("\nWHERE {0}={1}", (object) "ctg_Depth", (object) 2));
        if (num > 0L)
          stringBuilder.Append(string.Format("  AND {0}={1}", (object) "ctg_SiteID", (object) num));
        stringBuilder.Append(")");
        stringBuilder.Append("\n,T_CTG_LV_3 AS (\nSELECT ctg_ID AS ctg_lv1_ID,ctg_ViewCode AS ctg_lv1_ViewCode,ctg_CategoryName AS ctg_lv1_Name,0 AS ctg_lv2_ID,'' AS ctg_lv2_ViewCode,'' AS ctg_lv2_Name,ctg_ParentsID AS ctg_parent_id,ctg_ID AS ctg_code,'' AS ctg_lv3_ViewCode \n,dpt_lv1_ID,dpt_lv1_ViewCode,dpt_lv1_Name,dpt_lv2_ID,dpt_lv2_ViewCode,dpt_lv2_Name,dpt_ViewCode,dpt_DeptName,dpt_ID,dpt_parent_id\n,ctg_SiteID AS ctg_lv3_SiteID\nFROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str1 + " " + DbQueryHelper.ToWithNolock() + "\nLEFT OUTER JOIN T_CTG_LV_1 ON ctg_ID=ctg_lv1_ID AND ctg_SiteID=ctg_lv1_SiteID" + string.Format("\nWHERE {0}={1}", (object) "ctg_Depth", (object) 1));
        if (num > 0L)
          stringBuilder.Append(string.Format("  AND {0}={1}", (object) "ctg_SiteID", (object) num));
        stringBuilder.Append("\n UNION ALL\nSELECT ctg_lv1_ID,ctg_lv1_ViewCode,ctg_lv1_Name,ctg_ID AS ctg_lv2_ID,ctg_ViewCode AS ctg_lv2_ViewCode,ctg_CategoryName AS ctg_lv2_Name,ctg_ParentsID AS ctg_parent_id,ctg_ID AS ctg_code, '' AS ctg_lv3_ViewCode\n,dpt_lv1_ID,dpt_lv1_ViewCode,dpt_lv1_Name,dpt_lv2_ID,dpt_lv2_ViewCode,dpt_lv2_Name,dpt_ViewCode,dpt_DeptName,dpt_ID,dpt_parent_id\n,ctg_SiteID AS ctg_lv3_SiteID\nFROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str1 + " " + DbQueryHelper.ToWithNolock() + "\nLEFT OUTER JOIN T_CTG_LV_1 ON ctg_ParentsID=ctg_lv1_ID AND ctg_SiteID=ctg_lv1_SiteID" + string.Format("\nWHERE {0}={1}", (object) "ctg_Depth", (object) 2));
        if (num > 0L)
          stringBuilder.Append(string.Format("  AND {0}={1}", (object) "ctg_SiteID", (object) num));
        stringBuilder.Append("\n UNION ALL\nSELECT ctg_lv1_ID,ctg_lv1_ViewCode,ctg_lv1_Name,ctg_lv2_ID,ctg_lv2_ViewCode,ctg_lv2_Name,ctg_ParentsID AS ctg_parent_id,ctg_ID AS ctg_code, ctg_ViewCode AS ctg_lv3_ViewCode\n,dpt_lv1_ID,dpt_lv1_ViewCode,dpt_lv1_Name,dpt_lv2_ID,dpt_lv2_ViewCode,dpt_lv2_Name,dpt_ViewCode,dpt_DeptName,dpt_ID,dpt_parent_id\n,ctg_SiteID AS ctg_lv3_SiteID\nFROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str1 + " " + DbQueryHelper.ToWithNolock() + "\nLEFT OUTER JOIN T_CTG_LV_2 ON ctg_ParentsID=ctg_lv2_ID AND ctg_SiteID=ctg_lv2_SiteID\nLEFT OUTER JOIN T_CTG_LV_1 ON ctg_lv2_ParentsID=ctg_lv1_ID AND ctg_lv2_SiteID=ctg_lv1_SiteID" + string.Format("\nWHERE {0}={1}", (object) "ctg_Depth", (object) 3));
        if (num > 0L)
          stringBuilder.Append(string.Format("  AND {0}={1}", (object) "ctg_SiteID", (object) num));
        stringBuilder.Append(")");
        string str2;
        string str3;
        switch (Enum2StrConverter.ToCategoryDepth(p_value))
        {
          case EnumCategoryDepth.Lv2:
            str2 = "ctg_lv1_ID,ctg_lv2_ID";
            str3 = str2;
            break;
          case EnumCategoryDepth.Lv3:
            str2 = "ctg_lv1_ID,ctg_lv2_ID,ctg_lv3_ID";
            str3 = "ctg_lv1_ID,ctg_lv2_ID,ctg_code AS ctg_lv3_ID";
            break;
          default:
            str2 = "ctg_lv1_ID";
            str3 = str2;
            break;
        }
        stringBuilder.Append("\n,T_GOODS_HISTORY AS (\nSELECT gdh_StoreCode,gdh_GoodsCode,gdh_SiteID,gdh_GoodsCategory," + str3 + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + "\nLEFT OUTER MERGE JOIN " + DbQueryHelper.ToDBNameBridge(uniBase) + "view_category_v1 " + DbQueryHelper.ToWithNolock() + " ON gdh_GoodsCategory=view_category_v1.ctg_code AND gdh_SiteID=view_category_v1.ctg_SiteID");
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("ctg_SiteID"))
            p_param1.Add((object) "gdh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gdh_StoreCode"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gdh_StoreCode_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_STORE_AUTHS_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_GoodsCode"))
            p_param1.Add((object) "gdh_GoodsCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_DT_DATE_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("su_Supplier"))
            p_param1.Add((object) "gdh_Supplier", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("su_Supplier_IN_"))
            p_param1.Add((object) "gdh_Supplier_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_SUPPLIER_AUTHS_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("su_SupplierType"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("dpt_lv1_ID"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("dpt_lv2_ID"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("dpt_lv3_ID"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ctg_lv1_ID"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ctg_lv1_ID_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ctg_lv2_ID"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ctg_lv2_ID_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ctg_lv3_ID"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ctg_lv3_ID_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "gdh_SiteID"))
            p_param1.Add((object) "gdh_SiteID", (object) num);
          stringBuilder.Append("\n");
          stringBuilder.Append(new GoodsHistoryView().GetSelectWhereAnd((object) p_param1));
        }
        else if (num > 0L)
          stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "gdh_SiteID", (object) num));
        stringBuilder.Append(")");
        string dateToStr = new DateTime?(now).GetDateToStr("yyyy-MM-dd 00:00:00");
        stringBuilder.Append("\n,T_GOODS_STORE AS (\nSELECT gdsh_StoreCode,gdsh_GoodsCode,gdsh_SiteID\n,CASE WHEN gdsh_OrderEndDate<'" + dateToStr + "' THEN 1 ELSE 0 END AS goods_EndOrderCount\n,CASE WHEN gdsh_SaleEndDate<'" + dateToStr + "' THEN 1 ELSE 0 END AS goods_EndSaleCount" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.GoodsStoreInfo, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_GOODS_HISTORY ON gdsh_StoreCode=gdh_StoreCode AND gdsh_GoodsCode=gdh_GoodsCode AND gdsh_SiteID=gdh_SiteID)");
        stringBuilder.Append("\n,T_GOODS AS (\nSELECT " + str2 + ",gd_SiteID\n,COUNT(*) AS goods_Count\n,SUM(CASE gd_UseYn WHEN 'Y' THEN 1 ELSE 0 END) AS goods_UseCount\n,SUM(" + DbQueryHelper.ToIsNULL() + "(goods_EndOrderCount,0)) AS goods_EndOrderCount\n,SUM(" + DbQueryHelper.ToIsNULL() + "(goods_EndSaleCount,0)) AS goods_EndSaleCount" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Goods, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_GOODS_HISTORY ON gd_GoodsCode=gdh_GoodsCode AND gd_SiteID=gdh_SiteID\nLEFT OUTER  JOIN T_GOODS_STORE ON gd_GoodsCode=gdsh_GoodsCode AND gd_SiteID=gdsh_SiteID");
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("ctg_SiteID"))
            p_param1.Add((object) "gd_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_GoodsCode"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_MakerCode"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("mk_MakerCode"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_BrandCode"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("br_BrandCode"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "gd_SiteID"))
            p_param1.Add((object) "gd_SiteID", (object) num);
          stringBuilder.Append("\n");
          stringBuilder.Append(new TGoods().GetSelectWhereAnd((object) p_param1));
        }
        else if (num > 0L)
          stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "gd_SiteID", (object) num));
        stringBuilder.Append("\nGROUP BY " + str2 + ",gd_SiteID");
        stringBuilder.Append(")");
        stringBuilder.Append("\nSELECT  ctg_ID,ctg_SiteID,ctg_CategoryName,ctg_ViewCode,ctg_Memo,ctg_UseYn,ctg_DepositYn,ctg_Depth,ctg_ParentsID,ctg_AddProperty,ctg_InDate,ctg_InUser,ctg_ModDate,ctg_ModUser\n,0 AS dpt_lv1_ID,'' AS dpt_lv1_ViewCode,'' AS dpt_lv1_Name,0 AS dpt_lv2_ID,'' AS dpt_lv2_ViewCode,'' AS dpt_lv2_Name,0 AS dpt_ViewCode,'' AS  dpt_DeptName ,'' AS  dpt_ID\n,T_GOODS.ctg_lv1_ID,ctg_lv1_ViewCode,ctg_lv1_Name");
        if (Enum2StrConverter.ToCategoryDepth(p_value) >= EnumCategoryDepth.Lv2)
          stringBuilder.Append(",T_GOODS.ctg_lv2_ID,ctg_lv2_ViewCode,ctg_lv2_Name");
        else
          stringBuilder.Append(",0 AS ctg_lv2_ID,'' AS ctg_lv2_ViewCode,'' AS ctg_lv2_Name");
        if (Enum2StrConverter.ToCategoryDepth(p_value) >= EnumCategoryDepth.Lv3)
          stringBuilder.Append(",ctg_parent_id\n,CASE ctg_Depth WHEN 1 THEN dpt_DeptName ELSE ctg_ParentsName END AS ctg_ParentsName");
        else
          stringBuilder.Append(",0 AS ctg_parent_id\n,CASE ctg_Depth WHEN 1 THEN dpt_DeptName ELSE '' END AS ctg_ParentsName");
        stringBuilder.Append("\n,goods_Count,goods_UseCount,goods_EndOrderCount,goods_EndSaleCount\n,inEmpName,modEmpName\nFROM T_GOODS");
        switch (Enum2StrConverter.ToCategoryDepth(p_value))
        {
          case EnumCategoryDepth.Lv2:
            stringBuilder.Append("\nINNER JOIN " + DbQueryHelper.ToDBNameBridge(uniBase) + str1 + " " + DbQueryHelper.ToWithNolock() + " ON T_GOODS.ctg_lv2_ID=ctg_ID AND gd_SiteID=ctg_SiteID\nINNER JOIN T_CTG_LV_1 ON T_GOODS.ctg_lv1_ID=T_CTG_LV_1.ctg_lv1_ID AND gd_SiteID=ctg_lv1_SiteID\nINNER JOIN T_CTG_LV_2 ON ctg_ID=T_CTG_LV_2.ctg_lv2_ID AND gd_SiteID=ctg_lv2_SiteID");
            break;
          case EnumCategoryDepth.Lv3:
            stringBuilder.Append("\nINNER JOIN " + DbQueryHelper.ToDBNameBridge(uniBase) + str1 + " " + DbQueryHelper.ToWithNolock() + " ON T_GOODS.ctg_lv3_ID=ctg_ID AND gd_SiteID=ctg_SiteID\nINNER JOIN T_CTG_LV_3 ON ctg_ID=T_CTG_LV_3.ctg_code AND gd_SiteID=ctg_lv3_SiteID\nLEFT OUTER JOIN T_PARENTS_NM ON ctg_ParentsID=Parents_ID AND ctg_SiteID=Parents_SiteID");
            break;
          default:
            stringBuilder.Append("\nINNER JOIN " + DbQueryHelper.ToDBNameBridge(uniBase) + str1 + " " + DbQueryHelper.ToWithNolock() + " ON T_GOODS.ctg_lv1_ID=ctg_ID AND gd_SiteID=ctg_SiteID\nINNER JOIN T_CTG_LV_1 ON ctg_ID=T_CTG_LV_1.ctg_lv1_ID AND gd_SiteID=ctg_lv1_SiteID");
            break;
        }
        stringBuilder.Append("\nLEFT OUTER JOIN T_EMPLOYEE_IN ON ctg_InUser=emp_CodeIn\nLEFT OUTER JOIN T_EMPLOYEE_MOD ON ctg_ModUser=emp_CodeMod");
        if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append("\nORDER BY " + empty);
        else
          stringBuilder.Append("\nORDER BY " + str2);
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
