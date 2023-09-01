// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByTime.Date.SaleByTimeDateStore
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
using UniBiz.Bo.Models.UniBase.GoodsInfo.Goods;
using UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsHistory;
using UniBiz.Bo.Models.UniBase.Store.StoreInfo;
using UniBiz.Bo.Models.UniBase.Supplier.Supplier;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniSales.SalesBy.SalesByTime.Date
{
  public class SaleByTimeDateStore : TSalesByTime<SaleByTimeDateStore>
  {
    private int _rowDataType;
    private int _rowDateCondition;
    private int _rowTimeStatus;
    private int _sbt_SaleDays;
    private string _si_StoreName;
    private string _si_StoreViewCode;
    private string _si_UseYn;
    private int _si_StoreType;

    public int rowDataType
    {
      get => this._rowDataType;
      set
      {
        this._rowDataType = value;
        this.Changed(nameof (rowDataType));
        this.Changed("RowDataType");
      }
    }

    [JsonIgnore]
    public EnumRowType RowDataType => Enum2StrConverter.ToRowType(this.rowDataType);

    public int rowDateCondition
    {
      get => this._rowDateCondition;
      set
      {
        this._rowDateCondition = value;
        this.Changed(nameof (rowDateCondition));
        this.Changed("RowDateCondition");
      }
    }

    [JsonIgnore]
    public EnumRowDateCondition RowDateCondition => Enum2StrConverter.ToRowDateCondition(this.rowDateCondition);

    public int rowTimeStatus
    {
      get => this._rowTimeStatus;
      set
      {
        this._rowTimeStatus = value;
        this.Changed(nameof (rowTimeStatus));
        this.Changed("RowTimeStatus");
      }
    }

    [JsonIgnore]
    public EnumRowTimeStatus RowTimeStatus => Enum2StrConverter.ToRowTimeStatus(this.rowTimeStatus);

    public int sbt_SaleDays
    {
      get => this._sbt_SaleDays;
      set
      {
        this._sbt_SaleDays = value;
        this.Changed(nameof (sbt_SaleDays));
      }
    }

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

    [JsonIgnore]
    public static string MainCol
    {
      get
      {
        StringBuilder stringBuilder = new StringBuilder();
        for (int index = 0; index < 24; ++index)
          stringBuilder.Append(string.Format(",{0}{1:00}", (object) "sbt_SaleAmt", (object) index) + string.Format(",{0}{1:00}", (object) "sbt_BoxQty", (object) index) + string.Format(",{0}{1:00}", (object) "sbt_SaleQty", (object) index) + string.Format(",{0}{1:00}", (object) "sbt_SlipCustomer", (object) index) + string.Format(",{0}{1:00}", (object) "sbt_CategoryCustomer", (object) index) + string.Format(",{0}{1:00}", (object) "sbt_GoodsCustomer", (object) index) + string.Format(",{0}{1:00}", (object) "sbt_SupplierCustomer", (object) index));
        return stringBuilder.ToString();
      }
    }

    [JsonIgnore]
    public static string SubCol
    {
      get
      {
        StringBuilder stringBuilder = new StringBuilder();
        for (int index = 0; index < 24; ++index)
          stringBuilder.Append(string.Format(",SUM({0}{1:00}) AS {2}{3:00}", (object) "sbt_SaleAmt", (object) index, (object) "sbt_SaleAmt", (object) index) + string.Format(",SUM({0}{1:00}) AS {2}{3:00}", (object) "sbt_BoxQty", (object) index, (object) "sbt_BoxQty", (object) index) + string.Format(",SUM({0}{1:00}) AS {2}{3:00}", (object) "sbt_SaleQty", (object) index, (object) "sbt_SaleQty", (object) index) + string.Format(",SUM({0}{1:00}) AS {2}{3:00}", (object) "sbt_SlipCustomer", (object) index, (object) "sbt_SlipCustomer", (object) index) + string.Format(",SUM({0}{1:00}) AS {2}{3:00}", (object) "sbt_CategoryCustomer", (object) index, (object) "sbt_CategoryCustomer", (object) index) + string.Format(",SUM({0}{1:00}) AS {2}{3:00}", (object) "sbt_GoodsCustomer", (object) index, (object) "sbt_GoodsCustomer", (object) index) + string.Format(",SUM({0}{1:00}) AS {2}{3:00}", (object) "sbt_SupplierCustomer", (object) index, (object) "sbt_SupplierCustomer", (object) index));
        return stringBuilder.ToString();
      }
    }

    [JsonIgnore]
    public static string BaseColMaker
    {
      get
      {
        StringBuilder stringBuilder = new StringBuilder();
        for (int index = 0; index < 24; ++index)
          stringBuilder.Append(string.Format(",SUM({0}{1:00}) AS {2}{3:00}", (object) "sbt_SaleAmt", (object) index, (object) "sbt_SaleAmt", (object) index) + string.Format(",SUM({0}{1:00}) AS {2}{3:00}", (object) "sbt_BoxQty", (object) index, (object) "sbt_BoxQty", (object) index) + string.Format(",SUM({0}{1:00}) AS {2}{3:00}", (object) "sbt_SaleQty", (object) index, (object) "sbt_SaleQty", (object) index) + string.Format(",SUM({0}{1:00}) AS {2}{3:00}", (object) "sbt_SlipCustomer", (object) index, (object) "sbt_SlipCustomer", (object) index) + string.Format(",SUM({0}{1:00}) AS {2}{3:00}", (object) "sbt_CategoryCustomer", (object) index, (object) "sbt_CategoryCustomer", (object) index) + string.Format(",SUM({0}{1:00}) AS {2}{3:00}", (object) "sbt_GoodsCustomer", (object) index, (object) "sbt_GoodsCustomer", (object) index) + string.Format(",SUM({0}{1:00}) AS {2}{3:00}", (object) "sbt_SupplierCustomer", (object) index, (object) "sbt_SupplierCustomer", (object) index));
        return stringBuilder.ToString();
      }
    }

    [JsonIgnore]
    public static string TableCol
    {
      get
      {
        StringBuilder stringBuilder = new StringBuilder();
        for (int index = 0; index < 24; ++index)
          stringBuilder.Append(string.Format(",{0}{1:00}", (object) "sbt_SaleAmt", (object) index) + string.Format(",{0}{1:00}", (object) "sbt_BoxQty", (object) index) + string.Format(",{0}{1:00}", (object) "sbt_SaleQty", (object) index) + string.Format(",{0}{1:00}", (object) "sbt_SlipCustomer", (object) index) + string.Format(",{0}{1:00}", (object) "sbt_CategoryCustomer", (object) index) + string.Format(",{0}{1:00}", (object) "sbt_GoodsCustomer", (object) index) + string.Format(",{0}{1:00}", (object) "sbt_SupplierCustomer", (object) index));
        return stringBuilder.ToString();
      }
    }

    public override Dictionary<string, TTableColumn> ToColumnInfo() => base.ToColumnInfo();

    public override void Clear()
    {
      base.Clear();
      this.rowDataType = 1;
      this.rowDateCondition = 1;
      this.rowTimeStatus = 1;
      this.sbt_SaleDays = 0;
      this.si_StoreName = string.Empty;
      this.si_StoreViewCode = string.Empty;
      this.si_UseYn = "Y";
      this.si_StoreType = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new SaleByTimeDateStore();

    public override object Clone()
    {
      SaleByTimeDateStore saleByTimeDateStore = base.Clone() as SaleByTimeDateStore;
      saleByTimeDateStore.rowDataType = this.rowDataType;
      saleByTimeDateStore.rowDateCondition = this.rowDateCondition;
      saleByTimeDateStore.rowTimeStatus = this.rowTimeStatus;
      saleByTimeDateStore.sbt_SaleDays = this.sbt_SaleDays;
      saleByTimeDateStore.si_StoreName = this.si_StoreName;
      saleByTimeDateStore.si_StoreViewCode = this.si_StoreViewCode;
      saleByTimeDateStore.si_UseYn = this.si_UseYn;
      saleByTimeDateStore.si_StoreType = this.si_StoreType;
      return (object) saleByTimeDateStore;
    }

    public void PutData(SaleByTimeDateStore pSource)
    {
      this.PutData((TSalesByTime) pSource);
      this.rowDataType = pSource.rowDataType;
      this.rowDateCondition = pSource.rowDateCondition;
      this.rowTimeStatus = pSource.rowTimeStatus;
      this.sbt_SaleDays = pSource.sbt_SaleDays;
      this.si_StoreName = pSource.si_StoreName;
      this.si_StoreViewCode = pSource.si_StoreViewCode;
      this.si_UseYn = pSource.si_UseYn;
      this.si_StoreType = pSource.si_StoreType;
    }

    public bool CalcAddSum(SaleByTimeDateStore pSource) => pSource != null && this.CalcAddSum((TSalesByTime) pSource);

    public bool IsZero(EnumZeroCheck pCheckType, SaleByTimeDateStore pSource) => pSource == null || this.IsZero(pCheckType, (TSalesByTime) pSource);

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        if (!base.GetFieldValues(p_rs))
          return false;
        this.rowDateCondition = p_rs.GetFieldInt("rowDateCondition");
        this.rowTimeStatus = p_rs.GetFieldInt("rowTimeStatus");
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

    public async Task<IList<SaleByTimeDateStore>> SelectDateStoreListAsync(object p_param)
    {
      SaleByTimeDateStore saleByTimeDateStore1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(saleByTimeDateStore1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, saleByTimeDateStore1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(saleByTimeDateStore1.GetSelectQuery(p_param)))
        {
          saleByTimeDateStore1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + saleByTimeDateStore1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<SaleByTimeDateStore>) null;
        }
        IList<SaleByTimeDateStore> lt_list = (IList<SaleByTimeDateStore>) new List<SaleByTimeDateStore>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            SaleByTimeDateStore saleByTimeDateStore2 = saleByTimeDateStore1.OleDB.Create<SaleByTimeDateStore>();
            if (saleByTimeDateStore2.GetFieldValues(rs))
            {
              saleByTimeDateStore2.row_number = lt_list.Count + 1;
              lt_list.Add(saleByTimeDateStore2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + saleByTimeDateStore1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<SaleByTimeDateStore> SelectDateStoreEnumerableAsync(object p_param)
    {
      SaleByTimeDateStore saleByTimeDateStore1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(saleByTimeDateStore1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, saleByTimeDateStore1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(saleByTimeDateStore1.GetSelectQuery(p_param)))
        {
          saleByTimeDateStore1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + saleByTimeDateStore1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            SaleByTimeDateStore saleByTimeDateStore2 = saleByTimeDateStore1.OleDB.Create<SaleByTimeDateStore>();
            if (saleByTimeDateStore2.GetFieldValues(rs))
            {
              saleByTimeDateStore2.row_number = ++row_number;
              yield return saleByTimeDateStore2;
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

    protected Hashtable SearchConditionDefault(Hashtable p_param)
    {
      Hashtable hashtable = new Hashtable();
      foreach (DictionaryEntry dictionaryEntry in p_param)
      {
        if (dictionaryEntry.Key.ToString().Equals("sbt_SiteID"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("sbt_SaleDate"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("sbt_SaleDate_BEGIN_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("sbt_SaleDate_END_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("sbt_StoreCode"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("sbt_StoreCode_IN_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("_STORE_AUTHS_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("gd_GoodsCode"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("sbt_GoodsCode"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("su_Supplier"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("su_Supplier_IN_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("_SUPPLIER_AUTHS_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("su_SupplierType"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("gd_TaxDiv"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("gd_SalesUnit"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("gd_StockUnit"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("dpt_lv1_ID"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("dpt_lv2_ID"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("dpt_lv3_ID"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("ctg_lv1_ID"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("ctg_lv1_ID_IN_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("ctg_lv2_ID"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("ctg_lv2_ID_IN_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("ctg_lv3_ID"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("ctg_lv3_ID_IN_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("_KEY_WORD_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
      }
      return hashtable;
    }

    protected Hashtable SearchConditionBefore(Hashtable p_param)
    {
      Hashtable hashtable = new Hashtable();
      foreach (DictionaryEntry dictionaryEntry in p_param)
      {
        if (dictionaryEntry.Key.ToString().Equals("sbt_SiteID"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("sbt_SaleDate_BEFORE_"))
          hashtable.Add((object) "sbt_SaleDate", dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("sbt_SaleDate_BEFORE__BEGIN_"))
          hashtable.Add((object) "sbt_SaleDate_BEGIN_", dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("sbt_SaleDate_BEFORE__END_"))
          hashtable.Add((object) "sbt_SaleDate_END_", dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("sbt_StoreCode"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("sbt_StoreCode_IN_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("_STORE_AUTHS_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("gd_GoodsCode"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("sbt_GoodsCode"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("su_Supplier"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("su_Supplier_IN_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("_SUPPLIER_AUTHS_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("su_SupplierType"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("gd_TaxDiv"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("gd_SalesUnit"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("gd_StockUnit"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("dpt_lv1_ID"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("dpt_lv2_ID"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("dpt_lv3_ID"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("ctg_lv1_ID"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("ctg_lv1_ID_IN_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("ctg_lv2_ID"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("ctg_lv2_ID_IN_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("ctg_lv3_ID"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("ctg_lv3_ID_IN_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("_KEY_WORD_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
      }
      return hashtable;
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
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_BASE AS (SELECT");
        if (p_isStoreTotal)
          stringBuilder.Append(" 1 AS");
        stringBuilder.Append(" sbt_StoreCode");
        stringBuilder.Append(string.Format(",{0} AS {1}", (object) 1, (object) "rowDateCondition") + string.Format(",{0} AS {1}", (object) 1, (object) "rowTimeStatus"));
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
          stringBuilder.Append(" sbt_StoreCode");
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        if (flag)
        {
          stringBuilder.Append(",T_BEFORE AS (SELECT");
          if (p_isStoreTotal)
            stringBuilder.Append(" 1 AS");
          stringBuilder.Append(" sbt_StoreCode");
          stringBuilder.Append(string.Format(",{0} AS {1}", (object) 2, (object) "rowDateCondition") + string.Format(",{0} AS {1}", (object) 5, (object) "rowTimeStatus"));
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
            stringBuilder.Append(" sbt_StoreCode");
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
        stringBuilder.Append("\nFROM (");
        stringBuilder.Append("\nSELECT sbt_StoreCode");
        stringBuilder.Append(",rowDateCondition,rowTimeStatus");
        stringBuilder.Append(SaleByTimeDateStore.SubCol);
        stringBuilder.Append("\nFROM (");
        stringBuilder.Append("\nSELECT sbt_StoreCode");
        stringBuilder.Append(",rowDateCondition,rowTimeStatus");
        stringBuilder.Append(SaleByTimeDateStore.TableCol);
        stringBuilder.Append("\nFROM T_BASE");
        if (flag)
        {
          stringBuilder.Append("\nUNION ALL");
          stringBuilder.Append("\nSELECT sbt_StoreCode");
          stringBuilder.Append(",rowDateCondition,rowTimeStatus");
          stringBuilder.Append(SaleByTimeDateStore.TableCol);
          stringBuilder.Append("\nFROM T_BEFORE");
        }
        stringBuilder.Append("\n) SUB");
        stringBuilder.Append("\nGROUP BY sbt_StoreCode");
        stringBuilder.Append(",rowDateCondition,rowTimeStatus");
        stringBuilder.Append("\n) MAIN");
        stringBuilder.Append("\nINNER JOIN T_STORE ON sbt_StoreCode=si_StoreCode" + string.Format(" AND {0}={1}", (object) "si_SiteID", (object) p_SiteID));
        stringBuilder.Append("\n");
        if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append(" ORDER BY " + empty);
        else
          stringBuilder.Append(" ORDER BY si_StoreViewCode,sbt_StoreCode");
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

    public string ToWithStoreQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("WITH T_STORE AS ( SELECT si_StoreCode,si_SiteID,si_StoreName,si_StoreViewCode,si_StoreType,si_UseYn,si_LocationUseYn" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("sbt_SiteID"))
            p_param1.Add((object) "si_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add((object) "si_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("sbt_StoreCode"))
            p_param1.Add((object) "si_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("sbt_StoreCode_IN_"))
            p_param1.Add((object) "si_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_STORE_AUTHS_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "si_SiteID"))
            p_param1.Add((object) "si_SiteID", (object) p_SiteID);
          stringBuilder.Append(new TStoreInfo().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format("  WHERE {0}={1}", (object) "si_SiteID", (object) p_SiteID));
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithSupplierQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_SUPPLIER AS (SELECT su_Supplier,su_SiteID,su_HeadSupplier,su_SupplierViewCode,su_SupplierName,su_SupplierType" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Supplier, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("sbt_SiteID"))
            p_param1.Add((object) "su_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("su_Supplier"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("su_SupplierType"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "su_SiteID"))
            p_param1.Add((object) "su_SiteID", (object) p_SiteID);
          stringBuilder.Append(new TSupplier().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "su_SiteID", (object) p_SiteID));
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithDeptLv1Query(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable hashtable = new Hashtable();
      try
      {
        if (p_SiteID == 0L)
          return string.Empty;
        stringBuilder.Append("\n,T_DEPT_LV1_NAME AS (SELECT dpt_ID,dpt_SiteID,dpt_ViewCode,dpt_DeptName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Dept, (object) DbQueryHelper.ToWithNolock()));
        stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "dpt_SiteID", (object) p_SiteID));
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "dpt_Depth", (object) 1));
        stringBuilder.Append(")");
      }
      finally
      {
        hashtable.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithDeptLv2Query(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable hashtable = new Hashtable();
      try
      {
        if (p_SiteID == 0L)
          return string.Empty;
        stringBuilder.Append("\n,T_DEPT_LV2_NAME AS (SELECT dpt_ID,dpt_SiteID,dpt_ViewCode,dpt_DeptName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Dept, (object) DbQueryHelper.ToWithNolock()));
        stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "dpt_SiteID", (object) p_SiteID) + string.Format(" AND {0}={1}", (object) "dpt_Depth", (object) 2));
        stringBuilder.Append(")");
      }
      finally
      {
        hashtable.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithDeptLv3Query(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable hashtable = new Hashtable();
      try
      {
        if (p_SiteID == 0L)
          return string.Empty;
        stringBuilder.Append("\n,T_DEPT_LV3_NAME AS (SELECT dpt_ID,dpt_SiteID,dpt_ViewCode,dpt_DeptName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Dept, (object) DbQueryHelper.ToWithNolock()));
        stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "dpt_SiteID", (object) p_SiteID) + string.Format(" AND {0}={1}", (object) "dpt_Depth", (object) 3));
        stringBuilder.Append(")");
      }
      finally
      {
        hashtable.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithCategoryLv1Query(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable hashtable = new Hashtable();
      try
      {
        if (p_SiteID == 0L)
          return string.Empty;
        stringBuilder.Append("\n,T_CTG_LV_1_NAME AS (SELECT ctg_ID,ctg_SiteID,ctg_ViewCode,ctg_CategoryName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Category, (object) DbQueryHelper.ToWithNolock()));
        stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "ctg_SiteID", (object) p_SiteID));
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ctg_Depth", (object) 1));
        stringBuilder.Append(")");
      }
      finally
      {
        hashtable.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithCategoryLv2Query(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable hashtable = new Hashtable();
      try
      {
        if (p_SiteID == 0L)
          return string.Empty;
        stringBuilder.Append("\n,T_CTG_LV_2_NAME AS (SELECT ctg_ID,ctg_SiteID,ctg_ViewCode,ctg_CategoryName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Category, (object) DbQueryHelper.ToWithNolock()));
        stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "ctg_SiteID", (object) p_SiteID));
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ctg_Depth", (object) 2));
        stringBuilder.Append(")");
      }
      finally
      {
        hashtable.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithCategoryLv3Query(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable hashtable = new Hashtable();
      try
      {
        if (p_SiteID == 0L)
          return string.Empty;
        stringBuilder.Append("\n,T_CTG_LV_3_NAME AS (SELECT ctg_ID,ctg_SiteID,ctg_ViewCode,ctg_CategoryName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Category, (object) DbQueryHelper.ToWithNolock()));
        stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "ctg_SiteID", (object) p_SiteID));
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ctg_Depth", (object) 3));
        stringBuilder.Append(")");
      }
      finally
      {
        hashtable.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithViewCategoryLv1Query(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable hashtable = new Hashtable();
      try
      {
        if (p_SiteID == 0L)
          return string.Empty;
        stringBuilder.Append("\n,T_VIEW_CATEGORY_LV1 AS (SELECT dpt_lv1_ID,dpt_lv2_ID,dept_code,ctg_lv1_ID,ctg_SiteID FROM " + DbQueryHelper.ToDBNameBridge(p_dbms) + "view_category_v1 " + DbQueryHelper.ToWithNolock());
        stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "ctg_SiteID", (object) p_SiteID));
        stringBuilder.Append(" GROUP BY dpt_lv1_ID,dpt_lv2_ID,dept_code");
        stringBuilder.Append(",ctg_lv1_ID,ctg_SiteID");
        stringBuilder.Append(")");
      }
      finally
      {
        hashtable.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithBookmarkGoodsQuery(
      object p_param,
      string p_dbms,
      long p_SiteID,
      int p_bgg_GroupID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable hashtable = new Hashtable();
      try
      {
        if (p_bgg_GroupID > 0)
        {
          stringBuilder.Append("\n,T_BOOKMARK_GOODS AS ( SELECT bgl_GoodsCode,bgl_SiteID" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.BookmarkGoodsList, (object) DbQueryHelper.ToWithNolock()) + string.Format(" WHERE {0}={1}", (object) "bgl_GroupID", (object) p_bgg_GroupID));
          if (p_SiteID > 0L)
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "bgl_SiteID", (object) p_SiteID));
          stringBuilder.Append(" GROUP BY bgl_GoodsCode,bgl_SiteID");
          stringBuilder.Append(")");
        }
      }
      finally
      {
        hashtable.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithGoodsQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        if (p_SiteID == 0L)
          return string.Empty;
        stringBuilder.Append("\n,T_GOODS AS ( SELECT gd_GoodsCode,gd_SiteID,gd_GoodsName,gd_BarCode,gd_GoodsSize,gd_TaxDiv,gd_SalesUnit,gd_StockUnit,gd_BoxGoodsCode,gd_MakerCode,gd_UseYn" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Goods, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("sbt_SiteID"))
            p_param1.Add((object) "gd_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("sbt_GoodsCode"))
            p_param1.Add((object) "gd_GoodsCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_TaxDiv"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("mk_MakerCode"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("mk_MakerCode_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_MakerCode"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_MakerCode_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("br_BrandCode"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("br_BrandCode_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_BrandCode"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_BrandCode_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_SalesUnit"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_StockUnit"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_PackUnit"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_AbcValue"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_UseYn"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "gd_SiteID"))
            p_param1.Add((object) "gd_SiteID", (object) p_SiteID);
          stringBuilder.Append("\n");
          stringBuilder.Append(new GoodsView().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gd_SiteID", (object) p_SiteID));
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithGoodsHistoryQuery(
      object p_param,
      string p_dbms,
      long p_SiteID,
      bool p_isStoreTotal = false)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_HISTORY AS (\nSELECT gdh_StoreCode,gdh_GoodsCode,gdh_StartDate,gdh_EndDate,gdh_SiteID,gdh_GoodsCategory,gdh_Supplier,gdh_BuyCost,gdh_BuyVat,gdh_SalePrice,gdh_EventCost,gdh_EventVat,gdh_EventPrice\n,dpt_lv1_ID,dpt_lv1_ViewCode,dpt_lv1_Name,dpt_lv2_ID,dpt_lv2_ViewCode,dpt_lv2_Name,dept_code,dept_code AS dpt_lv3_ID,dpt_lv3_ViewCode,dpt_lv3_Name\n,ctg_lv1_ID,ctg_lv1_ViewCode,ctg_lv1_Name,ctg_lv2_ID,ctg_lv2_ViewCode,ctg_lv2_Name,ctg_code,ctg_code AS ctg_lv3_ID,ctg_lv3_ViewCode,ctg_lv3_Name" + string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + "\n INNER MERGE JOIN " + DbQueryHelper.ToDBNameBridge(p_dbms) + "view_category_v1 " + DbQueryHelper.ToWithNolock() + " ON gdh_GoodsCategory=view_category_v1.ctg_code AND gdh_SiteID=view_category_v1.ctg_SiteID");
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("sbt_SiteID"))
            p_param1.Add((object) "gdh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add((object) "gdh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
          {
            if (p_isStoreTotal)
            {
              string[] strArray = dictionaryEntry.Value.ToString().Split(",");
              if (strArray.Length != 0)
                p_param1.Add((object) "gdh_StoreCode", (object) Convert.ToInt32(strArray[0]));
            }
            else
              p_param1.Add((object) "gdh_StoreCode_IN_", dictionaryEntry.Value);
          }
          if (dictionaryEntry.Key.ToString().Equals("sbt_StoreCode"))
            p_param1.Add((object) "gdh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("sbt_StoreCode_IN_"))
          {
            if (p_isStoreTotal)
            {
              string[] strArray = dictionaryEntry.Value.ToString().Split(",");
              if (strArray.Length != 0)
                p_param1.Add((object) "gdh_StoreCode", (object) Convert.ToInt32(strArray[0]));
            }
            else
              p_param1.Add((object) "gdh_StoreCode_IN_", dictionaryEntry.Value);
          }
          if (dictionaryEntry.Key.ToString().Equals("_STORE_AUTHS_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("sbt_GoodsCode"))
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
          if (dictionaryEntry.Key.ToString().Equals("_GoodsHistoryDiv_"))
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
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "gdh_SiteID"))
            p_param1.Add((object) "gdh_SiteID", (object) p_SiteID);
          if (p_isStoreTotal && !p_param1.ContainsKey((object) "gdh_StoreCode"))
            p_param1.Add((object) "gdh_StoreCode", (object) 1);
          stringBuilder.Append("\n");
          stringBuilder.Append(new GoodsHistoryView().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format("\n WHERE {0}={1}", (object) "gdh_SiteID", (object) p_SiteID));
        stringBuilder.Append("\n");
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToInnerJoinSupplierTypeQuery(Hashtable p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      if (p_SiteID == 0L)
        return string.Empty;
      bool flag = false;
      int num = 0;
      string str = (string) null;
      if (p_param.ContainsKey((object) "su_SupplierType") && Convert.ToInt32(p_param[(object) "su_SupplierType"].ToString()) > 0)
      {
        flag = true;
        num = Convert.ToInt32(p_param[(object) "su_SupplierType"].ToString());
      }
      if (p_param.ContainsKey((object) "su_SupplierType_IN_") && p_param[(object) "su_SupplierType_IN_"].ToString().Length > 0)
      {
        flag = true;
        str = p_param[(object) "su_SupplierType_IN_"].ToString();
      }
      if (!flag)
        return string.Empty;
      stringBuilder.Append("\n INNER JOIN T_SUPPLIER ON gdh_Supplier=su_Supplier" + string.Format(" AND {0}={1}", (object) "su_SiteID", (object) p_SiteID));
      if (num > 0)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "su_SupplierType", (object) num));
      if (string.IsNullOrEmpty(str))
        stringBuilder.Append(" AND su_SupplierType IN (" + str + ")");
      return stringBuilder.ToString();
    }

    public string ToInnerJoinGoodsTypeQuery(Hashtable p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      if (p_SiteID == 0L)
        return string.Empty;
      bool flag = false;
      int num1 = 0;
      int num2 = 0;
      string str = (string) null;
      if (p_param.ContainsKey((object) "gd_TaxDiv") && Convert.ToInt32(p_param[(object) "gd_TaxDiv"].ToString()) > 0)
      {
        flag = true;
        num1 = Convert.ToInt32(p_param[(object) "gd_TaxDiv"].ToString());
      }
      if (p_param.ContainsKey((object) "gd_StockUnit") && Convert.ToInt32(p_param[(object) "gd_StockUnit"].ToString()) > 0)
      {
        flag = true;
        num2 = Convert.ToInt32(p_param[(object) "gd_StockUnit"].ToString());
      }
      if (p_param.ContainsKey((object) "gd_StockUnit_IN_") && p_param[(object) "gd_StockUnit_IN_"].ToString().Length > 0)
      {
        flag = true;
        str = p_param[(object) "gd_StockUnit_IN_"].ToString();
      }
      if (!flag)
        return string.Empty;
      stringBuilder.Append("\n INNER JOIN T_GOODS ON sbt_GoodsCode=gd_GoodsCode" + string.Format(" AND {0}={1}", (object) "gd_SiteID", (object) p_SiteID));
      if (num1 > 0)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gd_TaxDiv", (object) num1));
      if (num2 > 0)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gd_StockUnit", (object) num2));
      if (string.IsNullOrEmpty(str))
        stringBuilder.Append(" AND gd_StockUnit IN (" + str + ")");
      return stringBuilder.ToString();
    }
  }
}
