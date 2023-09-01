// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Date.SaleByDayDateStore
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
using UniBiz.Bo.Models.UniSales.SalesBy.GoalBy.GoalByDept;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Date
{
  public class SaleByDayDateStore : TSalesByDay<SaleByDayDateStore>, ISalesByDayDate
  {
    private int _rowDataType;
    private int _sbd_SaleDays;
    private double _sbd_GoalAmount;
    private double _sbd_GoalProfitAmount;
    private double _sbd_SaleQtyRule;
    private double _sbd_SaleAmtRule;
    private string _si_StoreName;
    private string _si_StoreViewCode;
    private string _si_UseYn;
    private int _si_StoreType;
    [JsonIgnore]
    public static string MainCol = ",sbd_SlipCustomer,sbd_GoodsCustomer,sbd_CategoryCustomer,sbd_SupplierCustomer,sbd_BoxQty,sbd_SaleQty,sbd_DcAmtGoods,sbd_DcAmtEvent,sbd_DcAmtCoupon,sbd_DcAmtPromotion,sbd_DcAmtManual,sbd_DcAmtMember,sbd_EnurySlip,sbd_EnuryEnd,sbd_Deposit,sbd_TotalSaleAmt,sbd_SaleAmt,sbd_SaleVatAmt,sbd_SaleCostAmt,sbd_ChargeAmt,sbd_ProfitAmt,sbd_PreTaxProfitAmt,sbd_AddPoint,sbd_PayCash,sbd_PayCard,sbd_PayEtc,sbd_GoalAmount,sbd_GoalProfitAmount";
    [JsonIgnore]
    public static string SubCol = ",SUM(sbd_SlipCustomer) AS sbd_SlipCustomer,SUM(sbd_GoodsCustomer) AS sbd_GoodsCustomer,SUM(sbd_CategoryCustomer) AS sbd_CategoryCustomer,SUM(sbd_SupplierCustomer) AS sbd_SupplierCustomer,SUM(sbd_BoxQty) AS sbd_BoxQty,SUM(sbd_SaleQty) AS sbd_SaleQty,SUM(sbd_DcAmtGoods) AS sbd_DcAmtGoods,SUM(sbd_DcAmtEvent) AS sbd_DcAmtEvent,SUM(sbd_DcAmtCoupon) AS sbd_DcAmtCoupon,SUM(sbd_DcAmtPromotion) AS sbd_DcAmtPromotion,SUM(sbd_DcAmtManual) AS sbd_DcAmtManual,SUM(sbd_DcAmtMember) AS sbd_DcAmtMember,SUM(sbd_EnurySlip) AS sbd_EnurySlip,SUM(sbd_EnuryEnd) AS sbd_EnuryEnd,SUM(sbd_Deposit) AS sbd_Deposit,SUM(sbd_TotalSaleAmt) AS sbd_TotalSaleAmt,SUM(sbd_SaleAmt) AS sbd_SaleAmt,SUM(sbd_SaleVatAmt) AS sbd_SaleVatAmt,SUM(sbd_SaleCostAmt) AS sbd_SaleCostAmt,SUM(sbd_ChargeAmt) AS sbd_ChargeAmt,SUM(sbd_ProfitAmt) AS sbd_ProfitAmt,SUM(sbd_PreTaxProfitAmt) AS sbd_PreTaxProfitAmt,SUM(sbd_AddPoint) AS sbd_AddPoint,SUM(sbd_PayCash) AS sbd_PayCash,SUM(sbd_PayCard) AS sbd_PayCard,SUM(sbd_PayEtc) AS sbd_PayEtc\n,SUM(sbd_GoalAmount) AS sbd_GoalAmount,SUM(sbd_GoalProfitAmount) AS sbd_GoalProfitAmount";
    [JsonIgnore]
    public static string BaseColMaker = ",SUM(sbd_SlipCustomer) AS sbd_SlipCustomer,SUM(sbd_GoodsCustomer) AS sbd_GoodsCustomer,SUM(sbd_CategoryCustomer) AS sbd_CategoryCustomer,SUM(sbd_SupplierCustomer) AS sbd_SupplierCustomer,SUM(sbd_BoxQty) AS sbd_BoxQty,SUM(sbd_SaleQty) AS sbd_SaleQty,SUM(sbd_DcAmtGoods) AS sbd_DcAmtGoods,SUM(sbd_DcAmtEvent) AS sbd_DcAmtEvent,SUM(sbd_DcAmtCoupon) AS sbd_DcAmtCoupon,SUM(sbd_DcAmtPromotion) AS sbd_DcAmtPromotion,SUM(sbd_DcAmtManual) AS sbd_DcAmtManual,SUM(sbd_DcAmtMember) AS sbd_DcAmtMember,SUM(sbd_EnurySlip) AS sbd_EnurySlip,SUM(sbd_EnuryEnd) AS sbd_EnuryEnd,SUM(sbd_Deposit) AS sbd_Deposit,SUM(sbd_TotalSaleAmt) AS sbd_TotalSaleAmt,SUM(sbd_SaleAmt) AS sbd_SaleAmt,SUM(sbd_SaleVatAmt) AS sbd_SaleVatAmt,SUM(sbd_SaleCostAmt) AS sbd_SaleCostAmt,SUM(sbd_ChargeAmt) AS sbd_ChargeAmt,SUM(sbd_ProfitAmt) AS sbd_ProfitAmt,SUM(sbd_PreTaxProfitAmt) AS sbd_PreTaxProfitAmt,SUM(sbd_AddPoint) AS sbd_AddPoint,SUM(sbd_PayCash) AS sbd_PayCash,SUM(sbd_PayCard) AS sbd_PayCard,SUM(sbd_PayEtc) AS sbd_PayEtc";
    [JsonIgnore]
    public static string BaseGoalAmountColMaker = ",SUM(sbd_GoalAmount) AS sbd_GoalAmount,SUM(sbd_GoalProfitAmount) AS sbd_GoalProfitAmount";
    [JsonIgnore]
    public static string BaseGoalDeptColMaker = ",SUM(gbd_GoalSaleAmt) AS sbd_GoalAmount,SUM(gbd_GoalProfitAmt) AS sbd_GoalProfitAmount";
    [JsonIgnore]
    public static string BaseGoalCategoryColMaker = ",SUM(gbc_GoalSaleAmt) AS sbd_GoalAmount,SUM(gbc_GoalProfitAmt) AS sbd_GoalProfitAmount";
    [JsonIgnore]
    public static string TableCol = ",sbd_SlipCustomer,sbd_GoodsCustomer,sbd_CategoryCustomer,sbd_SupplierCustomer,sbd_BoxQty,sbd_SaleQty,sbd_DcAmtGoods,sbd_DcAmtEvent,sbd_DcAmtCoupon,sbd_DcAmtPromotion,sbd_DcAmtManual,sbd_DcAmtMember,sbd_EnurySlip,sbd_EnuryEnd,sbd_Deposit,sbd_TotalSaleAmt,sbd_SaleAmt,sbd_SaleVatAmt,sbd_SaleCostAmt,sbd_ChargeAmt,sbd_ProfitAmt,sbd_PreTaxProfitAmt,sbd_AddPoint,sbd_PayCash,sbd_PayCard,sbd_PayEtc,0 AS sbd_GoalAmount,0 AS sbd_GoalProfitAmount";
    [JsonIgnore]
    public static string TableColGoal = ",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,sbd_GoalAmount,sbd_GoalProfitAmount";

    public int rowDataType
    {
      get => this._rowDataType;
      set
      {
        this._rowDataType = value;
        this.Changed(nameof (rowDataType));
        this.Changed("RowDataType");
        this.Changed("row_IsDataTypeTotalSum");
      }
    }

    [JsonIgnore]
    public EnumRowType RowDataType => Enum2StrConverter.ToRowType(this.rowDataType);

    [JsonIgnore]
    public bool row_IsDataTypeTotalSum => this.rowDataType == 3;

    public int sbd_SaleDays
    {
      get => this._sbd_SaleDays;
      set
      {
        this._sbd_SaleDays = value;
        this.Changed(nameof (sbd_SaleDays));
      }
    }

    public double sbd_GoalAmount
    {
      get => this._sbd_GoalAmount;
      set
      {
        this._sbd_GoalAmount = value;
        this.Changed(nameof (sbd_GoalAmount));
      }
    }

    public double sbd_GoalProfitAmount
    {
      get => this._sbd_GoalProfitAmount;
      set
      {
        this._sbd_GoalProfitAmount = value;
        this.Changed(nameof (sbd_GoalProfitAmount));
      }
    }

    public double sbd_SaleQtyRule
    {
      get => this._sbd_SaleQtyRule;
      set
      {
        this._sbd_SaleQtyRule = value;
        this.Changed(nameof (sbd_SaleQtyRule));
      }
    }

    public double sbd_SaleAmtRule
    {
      get => this._sbd_SaleAmtRule;
      set
      {
        this._sbd_SaleAmtRule = value;
        this.Changed(nameof (sbd_SaleAmtRule));
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

    public override Dictionary<string, TTableColumn> ToColumnInfo() => base.ToColumnInfo();

    public override void Clear()
    {
      base.Clear();
      this.rowDataType = 1;
      this.sbd_SaleDays = 0;
      this.si_StoreName = string.Empty;
      this.si_StoreViewCode = string.Empty;
      this.si_UseYn = "Y";
      this.si_StoreType = 0;
      this.sbd_GoalAmount = this.sbd_SaleQtyRule = this.sbd_SaleAmtRule = 0.0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new SaleByDayDateStore();

    public override object Clone()
    {
      SaleByDayDateStore saleByDayDateStore = base.Clone() as SaleByDayDateStore;
      saleByDayDateStore.rowDataType = this.rowDataType;
      saleByDayDateStore.sbd_SaleDays = this.sbd_SaleDays;
      saleByDayDateStore.si_StoreName = this.si_StoreName;
      saleByDayDateStore.si_StoreViewCode = this.si_StoreViewCode;
      saleByDayDateStore.si_UseYn = this.si_UseYn;
      saleByDayDateStore.si_StoreType = this.si_StoreType;
      saleByDayDateStore.sbd_GoalAmount = this.sbd_GoalAmount;
      saleByDayDateStore.sbd_SaleQtyRule = this.sbd_SaleQtyRule;
      saleByDayDateStore.sbd_SaleAmtRule = this.sbd_SaleAmtRule;
      return (object) saleByDayDateStore;
    }

    public void PutData(SaleByDayDateStore pSource)
    {
      this.PutData((TSalesByDay) pSource);
      this.rowDataType = pSource.rowDataType;
      this.sbd_SaleDays = pSource.sbd_SaleDays;
      this.si_StoreName = pSource.si_StoreName;
      this.si_StoreViewCode = pSource.si_StoreViewCode;
      this.si_UseYn = pSource.si_UseYn;
      this.si_StoreType = pSource.si_StoreType;
      this.sbd_GoalAmount = pSource.sbd_GoalAmount;
      this.sbd_SaleQtyRule = pSource.sbd_SaleQtyRule;
      this.sbd_SaleAmtRule = pSource.sbd_SaleAmtRule;
    }

    public bool CalcAddSum(SaleByDayDateStore pSource)
    {
      if (pSource == null || !this.CalcAddSum((TSalesByDay) pSource))
        return false;
      this.sbd_GoalAmount += pSource.sbd_GoalAmount;
      return true;
    }

    public bool IsZero(EnumZeroCheck pCheckType, SaleByDayDateStore pSource) => pSource == null || this.IsZero(pCheckType, (TSalesByDay) pSource) && (!Enum2StrConverter.IsZeroCheckSubsetAmount(pCheckType) || pSource.sbd_GoalAmount.IsZero());

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        if (!base.GetFieldValues(p_rs))
          return false;
        this.si_StoreName = p_rs.GetFieldString("si_StoreName");
        this.si_StoreViewCode = p_rs.GetFieldString("si_StoreViewCode");
        this.si_UseYn = p_rs.GetFieldString("si_UseYn");
        this.si_StoreType = p_rs.GetFieldInt("si_StoreType");
        this.sbd_GoalAmount = p_rs.GetFieldDouble("sbd_GoalAmount");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public async Task<IList<SaleByDayDateStore>> SelectDateStoreListAsync(object p_param)
    {
      SaleByDayDateStore saleByDayDateStore1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(saleByDayDateStore1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, saleByDayDateStore1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(saleByDayDateStore1.GetSelectQuery(p_param)))
        {
          saleByDayDateStore1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + saleByDayDateStore1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<SaleByDayDateStore>) null;
        }
        IList<SaleByDayDateStore> lt_list = (IList<SaleByDayDateStore>) new List<SaleByDayDateStore>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            SaleByDayDateStore saleByDayDateStore2 = saleByDayDateStore1.OleDB.Create<SaleByDayDateStore>();
            if (saleByDayDateStore2.GetFieldValues(rs))
            {
              saleByDayDateStore2.row_number = lt_list.Count + 1;
              lt_list.Add(saleByDayDateStore2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + saleByDayDateStore1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<SaleByDayDateStore> SelectDateStoreEnumerableAsync(object p_param)
    {
      SaleByDayDateStore saleByDayDateStore1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(saleByDayDateStore1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, saleByDayDateStore1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(saleByDayDateStore1.GetSelectQuery(p_param)))
        {
          saleByDayDateStore1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + saleByDayDateStore1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            SaleByDayDateStore saleByDayDateStore2 = saleByDayDateStore1.OleDB.Create<SaleByDayDateStore>();
            if (saleByDayDateStore2.GetFieldValues(rs))
            {
              saleByDayDateStore2.row_number = ++row_number;
              yield return saleByDayDateStore2;
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

    public Hashtable SearchConditionDefault(Hashtable p_param)
    {
      Hashtable hashtable = new Hashtable();
      foreach (DictionaryEntry dictionaryEntry in p_param)
      {
        if (dictionaryEntry.Key.ToString().Equals("sbd_SiteID"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("sbd_SaleDate"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("sbd_SaleDate_BEGIN_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("sbd_SaleDate_END_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("sbd_StoreCode"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("sbd_StoreCode_IN_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("_STORE_AUTHS_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("gd_GoodsCode"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("sbd_GoodsCode"))
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
        if (dictionaryEntry.Key.ToString().Equals("sbd_TaxDiv"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("gd_SalesUnit"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("sbd_SalesUnit"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("gd_StockUnit"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("sbd_StockUnit"))
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

    public Hashtable SearchConditionGoalByDept(Hashtable p_param)
    {
      Hashtable hashtable = new Hashtable();
      foreach (DictionaryEntry dictionaryEntry in p_param)
      {
        if (dictionaryEntry.Key.ToString().Equals("sbd_SiteID"))
          hashtable.Add((object) "gbd_SiteID", dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("sbd_SaleDate"))
          hashtable.Add((object) "gbd_SaleDate", dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("sbd_SaleDate_BEGIN_"))
          hashtable.Add((object) "gbd_SaleDate_BEGIN_", dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("sbd_SaleDate_END_"))
          hashtable.Add((object) "gbd_SaleDate_END_", dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("sbd_StoreCode"))
          hashtable.Add((object) "gbd_StoreCode", dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("sbd_StoreCode_IN_"))
        {
          hashtable.Add((object) "gbd_StoreCode_IN_", dictionaryEntry.Value);
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        }
        if (dictionaryEntry.Key.ToString().Equals("_STORE_AUTHS_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("dpt_lv1_ID"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("dpt_lv2_ID"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("dpt_lv3_ID"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
      }
      return hashtable;
    }

    public Hashtable SearchConditionGoalByCategory(Hashtable p_param)
    {
      Hashtable hashtable = new Hashtable();
      foreach (DictionaryEntry dictionaryEntry in p_param)
      {
        if (dictionaryEntry.Key.ToString().Equals("sbd_SiteID"))
          hashtable.Add((object) "gbc_SiteID", dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("sbd_SaleDate"))
          hashtable.Add((object) "gbc_SaleDate", dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("sbd_SaleDate_BEGIN_"))
          hashtable.Add((object) "gbc_SaleDate_BEGIN_", dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("sbd_SaleDate_END_"))
          hashtable.Add((object) "gbc_SaleDate_END_", dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("sbd_StoreCode"))
          hashtable.Add((object) "gbc_StoreCode", dictionaryEntry.Value);
        if (dictionaryEntry.Key.ToString().Equals("sbd_StoreCode_IN_"))
        {
          hashtable.Add((object) "gbc_StoreCode_IN_", dictionaryEntry.Value);
          hashtable.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        }
        if (dictionaryEntry.Key.ToString().Equals("_STORE_AUTHS_"))
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
        dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
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
        }
        stringBuilder.Append(this.ToWithStoreQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithSupplierQuery(p_param, uniBase, p_SiteID));
        if (p_bgg_GroupID > 0)
          stringBuilder.Append(this.ToWithBookmarkGoodsQuery(p_param, uniBase, p_SiteID, p_bgg_GroupID));
        stringBuilder.Append(this.ToWithGoodsHistoryQuery(p_param, uniBase, p_SiteID, p_isStoreTotal));
        stringBuilder.Append(",T_BASE AS (SELECT");
        if (p_isStoreTotal)
          stringBuilder.Append(" 1 AS");
        stringBuilder.Append(" sbd_StoreCode");
        stringBuilder.Append(SaleByDayDateStore.BaseColMaker);
        stringBuilder.Append(" FROM " + DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_SALES) + str + " " + DbQueryHelper.ToWithNolock() + "\n INNER JOIN T_HISTORY ON sbd_StoreCode=gdh_StoreCode AND sbd_GoodsCode=gdh_GoodsCode AND sbd_SaleDate >= gdh_StartDate AND sbd_SaleDate <= gdh_EndDate AND sbd_SiteID=gdh_SiteID");
        if (p_bgg_GroupID > 0)
          stringBuilder.Append("\n INNER JOIN T_BOOKMARK_GOODS ON sbd_GoodsCode=bgl_GoodsCode AND sbd_SiteID=bgl_SiteID");
        p_param1.Clear();
        p_param1 = this.SearchConditionDefault((Hashtable) p_param);
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "sbd_SiteID"))
            p_param1.Add((object) "sbd_SiteID", (object) p_SiteID);
          stringBuilder.Append("\n");
          stringBuilder.Append(this.GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format("\n WHERE {0}={1}", (object) "sbd_SiteID", (object) p_SiteID));
        if (!p_isStoreTotal)
          stringBuilder.Append("\n GROUP BY sbd_StoreCode");
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_BASE_GOAL_DEPT AS (SELECT");
        if (p_isStoreTotal)
          stringBuilder.Append(" 1 AS");
        else
          stringBuilder.Append(" gbd_StoreCode AS");
        stringBuilder.Append(" sbd_StoreCode");
        stringBuilder.Append(SaleByDayDateStore.BaseGoalDeptColMaker);
        stringBuilder.Append(string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_SALES), (object) TableCodeType.GoalByDept, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        p_param1 = this.SearchConditionGoalByDept((Hashtable) p_param);
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "gbd_SiteID"))
            p_param1.Add((object) "gbd_SiteID", (object) p_SiteID);
          stringBuilder.Append("\n");
          stringBuilder.Append(new GoalByDeptView().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format("\n WHERE {0}={1}", (object) "gbd_SiteID", (object) p_SiteID));
        if (!p_isStoreTotal)
          stringBuilder.Append("\n GROUP BY gbd_StoreCode");
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append("SELECT NULL AS sbd_SaleDate,sbd_StoreCode,0 AS sbd_BoxCode,0 AS sbd_GoodsCode,0 AS sbd_Supplier,0 AS sbd_SupplierType,0 AS sbd_CategoryCode,0 AS sbd_DeptCode,0 AS sbd_MakerCode,0 AS sbd_KeySeq" + string.Format(",{0} AS {1}", (object) p_SiteID, (object) "sbd_SiteID") + ",0 AS sbd_DayOfWeek,0 AS sbd_WeekOfYear,0 AS sbd_DayOfYear,0 AS sbd_SkyCondition,0 AS sbd_TaxDiv,0 AS sbd_SalesUnit,0 AS sbd_StockUnit");
        stringBuilder.Append(SaleByDayDateStore.MainCol);
        if (p_isStoreTotal)
          stringBuilder.Append("\n,통합 AS si_StoreName");
        else
          stringBuilder.Append("\n,si_StoreName");
        stringBuilder.Append(",si_StoreViewCode,si_UseYn,si_StoreType");
        stringBuilder.Append("\nFROM (");
        stringBuilder.Append("\nSELECT sbd_StoreCode");
        stringBuilder.Append(SaleByDayDateStore.SubCol);
        stringBuilder.Append("\nFROM (");
        stringBuilder.Append("\nSELECT sbd_StoreCode");
        stringBuilder.Append(SaleByDayDateStore.TableCol);
        stringBuilder.Append("\nFROM T_BASE");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append("\nSELECT sbd_StoreCode");
        stringBuilder.Append(SaleByDayDateStore.TableColGoal);
        stringBuilder.Append("\nFROM T_BASE_GOAL_DEPT");
        stringBuilder.Append("\n) SUB");
        stringBuilder.Append("\nGROUP BY sbd_StoreCode");
        stringBuilder.Append("\n) MAIN");
        stringBuilder.Append("\nINNER JOIN T_STORE ON sbd_StoreCode=si_StoreCode" + string.Format(" AND {0}={1}", (object) "si_SiteID", (object) p_SiteID));
        stringBuilder.Append("\n");
        if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append(" ORDER BY " + empty);
        else
          stringBuilder.Append(" ORDER BY si_StoreViewCode,sbd_StoreCode");
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
          if (dictionaryEntry.Key.ToString().Equals("sbd_SiteID"))
            p_param1.Add((object) "si_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add((object) "si_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("sbd_StoreCode"))
            p_param1.Add((object) "si_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("sbd_StoreCode_IN_"))
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
        stringBuilder.Append("\n,T_SUPPLIER AS (SELECT su_Supplier,su_SiteID,su_HeadSupplier,su_SupplierViewCode,su_SupplierName,su_SupplierType,su_SupplierKind,su_UseYn" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Supplier, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("sbd_SiteID"))
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
          if (dictionaryEntry.Key.ToString().Equals("sbd_SiteID"))
            p_param1.Add((object) "gd_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("sbd_GoodsCode"))
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
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "gd_SiteID", (object) p_SiteID));
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
          if (dictionaryEntry.Key.ToString().Equals("sbd_SiteID"))
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
          if (dictionaryEntry.Key.ToString().Equals("sbd_StoreCode"))
            p_param1.Add((object) "gdh_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("sbd_StoreCode_IN_"))
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
          if (dictionaryEntry.Key.ToString().Equals("sbd_GoodsCode"))
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
  }
}
