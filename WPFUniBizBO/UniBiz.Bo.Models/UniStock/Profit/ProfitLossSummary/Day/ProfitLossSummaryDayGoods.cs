// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Profit.ProfitLossSummary.Day.ProfitLossSummaryDayGoods
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

namespace UniBiz.Bo.Models.UniStock.Profit.ProfitLossSummary.Day
{
  public class ProfitLossSummaryDayGoods : ProfitLossSummaryDay<ProfitLossSummaryDayGoods>
  {
    private double _pls_CalcQty;
    private double _pls_CalcCostAmt;
    private double _pls_CalcCostVatAmt;
    private double _pls_CalcPriceAmt;
    private double _pls_CalcPriceVatAmt;
    private double _pls_CalcPriceCostAmt;
    private double _pls_CalcPriceCostVatAmt;
    private int _su_Supplier;
    private int _su_HeadSupplier;
    private string _su_SupplierName;
    private string _su_SupplierViewCode;
    private int _su_SupplierType;
    private int _su_SupplierKind;
    private string _su_UseYn;
    private double _gdh_SalePrice;
    private double _gdh_EventPrice;

    public double pls_CalcQty
    {
      get => this._pls_CalcQty;
      set
      {
        this._pls_CalcQty = value;
        this.Changed(nameof (pls_CalcQty));
      }
    }

    public double pls_CalcCostAmt
    {
      get => this._pls_CalcCostAmt;
      set
      {
        this._pls_CalcCostAmt = value;
        this.Changed(nameof (pls_CalcCostAmt));
      }
    }

    public double pls_CalcCostVatAmt
    {
      get => this._pls_CalcCostVatAmt;
      set
      {
        this._pls_CalcCostVatAmt = value;
        this.Changed(nameof (pls_CalcCostVatAmt));
      }
    }

    public double pls_CalcPriceAmt
    {
      get => this._pls_CalcPriceAmt;
      set
      {
        this._pls_CalcPriceAmt = value;
        this.Changed(nameof (pls_CalcPriceAmt));
        this.Changed("pls_CalcPriceTaxFreeAmt");
      }
    }

    public double pls_CalcPriceVatAmt
    {
      get => this._pls_CalcPriceVatAmt;
      set
      {
        this._pls_CalcPriceVatAmt = value;
        this.Changed(nameof (pls_CalcPriceVatAmt));
        this.Changed("pls_CalcPriceTaxFreeAmt");
      }
    }

    public double pls_CalcPriceTaxFreeAmt => this.pls_CalcPriceAmt - this.pls_CalcPriceVatAmt;

    public double pls_CalcPriceCostAmt
    {
      get => this._pls_CalcPriceCostAmt;
      set
      {
        this._pls_CalcPriceCostAmt = value;
        this.Changed(nameof (pls_CalcPriceCostAmt));
        this.Changed("pls_CalcPriceCostSumAmt");
      }
    }

    public double pls_CalcPriceCostVatAmt
    {
      get => this._pls_CalcPriceCostVatAmt;
      set
      {
        this._pls_CalcPriceCostVatAmt = value;
        this.Changed(nameof (pls_CalcPriceCostVatAmt));
        this.Changed("pls_CalcPriceCostSumAmt");
      }
    }

    public double pls_CalcPriceCostSumAmt => this.pls_CalcPriceCostAmt + this.pls_CalcPriceCostVatAmt;

    public int su_Supplier
    {
      get => this._su_Supplier;
      set
      {
        this._su_Supplier = value;
        this.Changed(nameof (su_Supplier));
      }
    }

    public int su_HeadSupplier
    {
      get => this._su_HeadSupplier;
      set
      {
        this._su_HeadSupplier = value;
        this.Changed(nameof (su_HeadSupplier));
      }
    }

    public string su_SupplierName
    {
      get => this._su_SupplierName;
      set
      {
        this._su_SupplierName = value;
        this.Changed(nameof (su_SupplierName));
      }
    }

    public string su_SupplierViewCode
    {
      get => this._su_SupplierViewCode;
      set
      {
        this._su_SupplierViewCode = value;
        this.Changed(nameof (su_SupplierViewCode));
      }
    }

    public int su_SupplierType
    {
      get => this._su_SupplierType;
      set
      {
        this._su_SupplierType = value;
        this.Changed(nameof (su_SupplierType));
      }
    }

    public string su_SupplierTypeDesc => this.su_SupplierType != 0 ? Enum2StrConverter.ToSupplierType(this.su_SupplierType).ToDescription() : string.Empty;

    public int su_SupplierKind
    {
      get => this._su_SupplierKind;
      set
      {
        this._su_SupplierKind = value;
        this.Changed(nameof (su_SupplierKind));
      }
    }

    public string su_SupplierKindDesc => this.su_SupplierKind != 0 ? Enum2StrConverter.ToSupplierKind(this.su_SupplierKind).ToDescription() : string.Empty;

    public string su_UseYn
    {
      get => this._su_UseYn;
      set
      {
        this._su_UseYn = value;
        this.Changed(nameof (su_UseYn));
        this.Changed("su_IsUseYn");
        this.Changed("su_UseYnDesc");
      }
    }

    public bool su_IsUseYn => "Y".Equals(this.su_UseYn);

    public string su_UseYnDesc => !"Y".Equals(this.su_UseYn) ? "미사용" : "사용";

    public double gdh_SalePrice
    {
      get => this._gdh_SalePrice;
      set
      {
        this._gdh_SalePrice = value;
        this.Changed(nameof (gdh_SalePrice));
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

    public override Dictionary<string, TTableColumn> ToColumnInfo() => base.ToColumnInfo();

    public override void Clear()
    {
      base.Clear();
      this.pls_CalcQty = this.pls_CalcCostAmt = this.pls_CalcCostVatAmt = 0.0;
      this.pls_CalcPriceAmt = this.pls_CalcPriceVatAmt = this.pls_CalcPriceCostAmt = this.pls_CalcPriceCostVatAmt = 0.0;
      this.su_Supplier = 0;
      this.su_HeadSupplier = 0;
      this.su_SupplierName = this.su_SupplierViewCode = string.Empty;
      this.su_SupplierType = 0;
      this.su_SupplierKind = 0;
      this.su_UseYn = "Y";
      this.gdh_SalePrice = this.gdh_EventPrice = 0.0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new ProfitLossSummaryDayGoods();

    public override object Clone()
    {
      ProfitLossSummaryDayGoods lossSummaryDayGoods = base.Clone() as ProfitLossSummaryDayGoods;
      lossSummaryDayGoods.pls_CalcQty = this.pls_CalcQty;
      lossSummaryDayGoods.pls_CalcCostAmt = this.pls_CalcCostAmt;
      lossSummaryDayGoods.pls_CalcCostVatAmt = this.pls_CalcCostVatAmt;
      lossSummaryDayGoods.pls_CalcPriceAmt = this.pls_CalcPriceAmt;
      lossSummaryDayGoods.pls_CalcPriceVatAmt = this.pls_CalcPriceVatAmt;
      lossSummaryDayGoods.pls_CalcPriceCostAmt = this.pls_CalcPriceCostAmt;
      lossSummaryDayGoods.pls_CalcPriceCostVatAmt = this.pls_CalcPriceCostVatAmt;
      lossSummaryDayGoods.su_Supplier = this.su_Supplier;
      lossSummaryDayGoods.su_HeadSupplier = this.su_HeadSupplier;
      lossSummaryDayGoods.su_SupplierName = this.su_SupplierName;
      lossSummaryDayGoods.su_SupplierViewCode = this.su_SupplierViewCode;
      lossSummaryDayGoods.su_SupplierType = this.su_SupplierType;
      lossSummaryDayGoods.su_SupplierKind = this.su_SupplierKind;
      lossSummaryDayGoods.su_UseYn = this.su_UseYn;
      lossSummaryDayGoods.gdh_SalePrice = this.gdh_SalePrice;
      lossSummaryDayGoods.gdh_EventPrice = this.gdh_EventPrice;
      return (object) lossSummaryDayGoods;
    }

    public void PutData(ProfitLossSummaryDayGoods pSource)
    {
      this.PutData((ProfitLossSummaryDay) pSource);
      this.pls_CalcQty = pSource.pls_CalcQty;
      this.pls_CalcCostAmt = pSource.pls_CalcCostAmt;
      this.pls_CalcCostVatAmt = pSource.pls_CalcCostVatAmt;
      this.pls_CalcPriceAmt = pSource.pls_CalcPriceAmt;
      this.pls_CalcPriceVatAmt = pSource.pls_CalcPriceVatAmt;
      this.pls_CalcPriceCostAmt = pSource.pls_CalcPriceCostAmt;
      this.pls_CalcPriceCostVatAmt = pSource.pls_CalcPriceCostVatAmt;
      this.su_Supplier = pSource.su_Supplier;
      this.su_HeadSupplier = pSource.su_HeadSupplier;
      this.su_SupplierName = pSource.su_SupplierName;
      this.su_SupplierViewCode = pSource.su_SupplierViewCode;
      this.su_SupplierType = pSource.su_SupplierType;
      this.su_SupplierKind = pSource.su_SupplierKind;
      this.su_UseYn = pSource.su_UseYn;
      this.gdh_SalePrice = pSource.gdh_SalePrice;
      this.gdh_EventPrice = pSource.gdh_EventPrice;
    }

    public bool CalcAddSum(ProfitLossSummaryDayGoods pSource)
    {
      if (pSource == null || !this.CalcAddSum((TProfitLossSummary) pSource))
        return false;
      this.pls_CalcCostAmt += pSource.pls_CalcCostAmt;
      this.pls_CalcCostVatAmt += pSource.pls_CalcCostVatAmt;
      this.pls_CalcPriceAmt += pSource.pls_CalcPriceAmt;
      this.pls_CalcPriceVatAmt += pSource.pls_CalcPriceVatAmt;
      this.pls_CalcPriceCostAmt += pSource.pls_CalcPriceCostAmt;
      this.pls_CalcPriceCostVatAmt += pSource.pls_CalcPriceCostVatAmt;
      return true;
    }

    public bool IsZero(EnumZeroCheck pCheckType, ProfitLossSummaryDayGoods pSource) => pSource == null || this.IsZero(pCheckType, (TProfitLossSummary) pSource) && (!Enum2StrConverter.IsZeroCheckSubsetQty(pCheckType) || pSource.pls_CalcQty.IsZero()) && (!Enum2StrConverter.IsZeroCheckSubsetAmount(pCheckType) || pSource.pls_CalcCostAmt.IsZero() && pSource.pls_CalcCostVatAmt.IsZero() && pSource.pls_CalcPriceAmt.IsZero() && pSource.pls_CalcPriceVatAmt.IsZero() && pSource.pls_CalcPriceCostAmt.IsZero() && pSource.pls_CalcPriceCostVatAmt.IsZero());

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        if (!base.GetFieldValues(p_rs))
          return false;
        this.pls_Date = p_rs.GetFieldDateTime("pls_Date");
        this.su_Supplier = p_rs.GetFieldInt("su_Supplier");
        this.su_HeadSupplier = p_rs.GetFieldInt("su_HeadSupplier");
        this.su_SupplierName = p_rs.GetFieldString("su_SupplierName");
        this.su_SupplierViewCode = p_rs.GetFieldString("su_SupplierViewCode");
        this.su_SupplierType = p_rs.GetFieldInt("su_SupplierType");
        this.su_SupplierKind = p_rs.GetFieldInt("su_SupplierKind");
        this.su_UseYn = p_rs.GetFieldString("su_UseYn");
        this.gdh_SalePrice = p_rs.GetFieldDouble("gdh_SalePrice");
        this.gdh_EventPrice = p_rs.GetFieldDouble("gdh_EventPrice");
        this.pls_CalcPriceAmt = this.CalcStockQty() * this.gdh_SalePrice;
        if (this.pls_IsTax)
          this.pls_CalcPriceVatAmt = this.pls_CalcPriceAmt.ToPriceVat();
        this.pls_BuyPriceAmt = this.gdh_SalePrice * this.pls_BuyQty;
        if (this.pls_IsTax)
          this.pls_BuyPriceVatAmt = this.pls_BuyPriceAmt.ToPriceVat();
        this.pls_ReturnPriceAmt = this.gdh_SalePrice * this.pls_ReturnQty;
        if (this.pls_IsTax)
          this.pls_ReturnPriceVatAmt = this.pls_ReturnPriceAmt.ToPriceVat();
        this.pls_InnerMoveOutPriceAmt = this.gdh_SalePrice * this.pls_InnerMoveOutQty;
        if (this.pls_IsTax)
          this.pls_InnerMoveOutPriceVatAmt = this.pls_InnerMoveOutPriceAmt.ToPriceVat();
        this.pls_InnerMoveInPriceAmt = this.gdh_SalePrice * this.pls_InnerMoveInQty;
        if (this.pls_IsTax)
          this.pls_InnerMoveInPriceVatAmt = this.pls_InnerMoveInPriceAmt.ToPriceVat();
        this.pls_OuterMoveOutPriceAmt = this.gdh_SalePrice * this.pls_OuterMoveOutQty;
        if (this.pls_IsTax)
          this.pls_OuterMoveOutPriceVatAmt = this.pls_OuterMoveOutPriceAmt.ToPriceVat();
        this.pls_OuterMoveInPriceAmt = this.gdh_SalePrice * this.pls_OuterMoveInQty;
        if (this.pls_IsTax)
          this.pls_OuterMoveInPriceVatAmt = this.pls_OuterMoveInPriceAmt.ToPriceVat();
        this.pls_AdjustPriceAmt = this.gdh_SalePrice * this.pls_AdjustQty;
        if (this.pls_IsTax)
          this.pls_AdjustPriceVatAmt = this.pls_AdjustPriceAmt.ToPriceVat();
        this.pls_DisusePriceAmt = this.gdh_SalePrice * this.pls_DisuseQty;
        if (this.pls_IsTax)
          this.pls_DisusePriceVatAmt = this.pls_DisusePriceAmt.ToPriceVat();
        this.pls_CalcPriceCostAmt = CalcHelper.CalcDoubleToFormatDouble(this.pls_CalcPriceAmt * this.CalcEndPriceCostRate());
        if (this.pls_IsTax)
          this.pls_CalcPriceCostVatAmt = this.pls_CalcPriceCostAmt.ToCostVat();
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public async Task<IList<ProfitLossSummaryDayGoods>> SelectDayGoodsListAsync(object p_param)
    {
      ProfitLossSummaryDayGoods lossSummaryDayGoods1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(lossSummaryDayGoods1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, lossSummaryDayGoods1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(lossSummaryDayGoods1.GetSelectQuery(p_param)))
        {
          lossSummaryDayGoods1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + lossSummaryDayGoods1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<ProfitLossSummaryDayGoods>) null;
        }
        IList<ProfitLossSummaryDayGoods> lt_list = (IList<ProfitLossSummaryDayGoods>) new List<ProfitLossSummaryDayGoods>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            ProfitLossSummaryDayGoods lossSummaryDayGoods2 = lossSummaryDayGoods1.OleDB.Create<ProfitLossSummaryDayGoods>();
            if (lossSummaryDayGoods2.GetFieldValues(rs))
            {
              lossSummaryDayGoods2.row_number = lt_list.Count + 1;
              lt_list.Add(lossSummaryDayGoods2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + lossSummaryDayGoods1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<ProfitLossSummaryDayGoods> SelectDayGoodsEnumerableAsync(
      object p_param)
    {
      ProfitLossSummaryDayGoods lossSummaryDayGoods1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(lossSummaryDayGoods1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, lossSummaryDayGoods1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(lossSummaryDayGoods1.GetSelectQuery(p_param)))
        {
          lossSummaryDayGoods1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + lossSummaryDayGoods1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            ProfitLossSummaryDayGoods lossSummaryDayGoods2 = lossSummaryDayGoods1.OleDB.Create<ProfitLossSummaryDayGoods>();
            if (lossSummaryDayGoods2.GetFieldValues(rs))
            {
              lossSummaryDayGoods2.row_number = ++row_number;
              yield return lossSummaryDayGoods2;
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
        this.TableCode.ToString();
        string empty = string.Empty;
        long p_SiteID = 0;
        DateTime? nullable = new DateTime?();
        bool p_IsSupplierView = false;
        int num = 0;
        TProfitLossSummary tprofitLossSummary = new TProfitLossSummary();
        if (p_param is Hashtable hashtable2)
        {
          if (hashtable2.ContainsKey((object) "DBMS") && hashtable2[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable2[(object) "DBMS"].ToString();
          if (hashtable2.ContainsKey((object) "table") && hashtable2[(object) "table"].ToString().Length > 0)
            hashtable2[(object) "table"].ToString();
          if (hashtable2.ContainsKey((object) "_ORDER_BY_COL_") && hashtable2[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable2[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable2.ContainsKey((object) "pls_SiteID") && Convert.ToInt64(hashtable2[(object) "pls_SiteID"].ToString()) > 0L)
            p_SiteID = Convert.ToInt64(hashtable2[(object) "pls_SiteID"].ToString());
          if (hashtable2.ContainsKey((object) "bgg_GroupID") && Convert.ToInt32(hashtable2[(object) "bgg_GroupID"].ToString()) > 0)
            Convert.ToInt32(hashtable2[(object) "bgg_GroupID"].ToString());
          if (hashtable2.ContainsKey((object) "_IS_STORE_TOTAL_SUM_") && Convert.ToBoolean(hashtable2[(object) "_IS_STORE_TOTAL_SUM_"].ToString()))
            Convert.ToBoolean(hashtable2[(object) "_IS_STORE_TOTAL_SUM_"].ToString());
          if (hashtable2.ContainsKey((object) "_DT_END_DATE_"))
            nullable = new DateTime?((DateTime) hashtable2[(object) "_DT_END_DATE_"]);
          if (hashtable2.ContainsKey((object) "su_Supplier_IS_DATA_VIEW_") && Convert.ToBoolean(hashtable2[(object) "su_Supplier_IS_DATA_VIEW_"].ToString()))
            p_IsSupplierView = Convert.ToBoolean(hashtable2[(object) "su_Supplier_IS_DATA_VIEW_"].ToString());
          if (hashtable2.ContainsKey((object) "si_StoreCode") && Convert.ToInt32(hashtable2[(object) "si_StoreCode"].ToString()) > 0)
            num = Convert.ToInt32(hashtable2[(object) "si_StoreCode"].ToString());
          if (num == 0 && hashtable2.ContainsKey((object) "si_StoreCode_IN_") && hashtable2[(object) "si_StoreCode_IN_"].ToString().Length > 0)
          {
            string str = hashtable2[(object) "si_StoreCode_IN_"].ToString();
            if (!str.Contains(","))
            {
              num = Convert.ToInt32(hashtable2[(object) "si_StoreCode_IN_"].ToString());
            }
            else
            {
              string[] strArray = str.Split(',');
              if (strArray.Length != 0)
                num = Convert.ToInt32(strArray[0].ToString());
            }
          }
        }
        if (!nullable.HasValue)
          throw new Exception("종료일자 정보 조건 부족.");
        if (num == 0)
          num = 1;
        stringBuilder.Append(this.ToWithStoreQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithGoodsCodeQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithWorkGoods(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithWorkGoodsHistoryQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithSupplierQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithWorkStartQuery(p_param, UbModelBase.UNI_STOCK, p_SiteID, p_IsSupplierView));
        stringBuilder.Append(this.ToWithWorkSaleQuery(p_param, UbModelBase.UNI_SALES, p_SiteID, p_IsSupplierView));
        stringBuilder.Append(this.ToWithWorkBuyQuery(p_param, UbModelBase.UNI_STOCK, p_SiteID, p_IsSupplierView));
        stringBuilder.Append(this.ToWithWorkReturnQuery(p_param, UbModelBase.UNI_STOCK, p_SiteID, p_IsSupplierView));
        stringBuilder.Append(this.ToWithWorkInnerMoveOutQuery(p_param, UbModelBase.UNI_STOCK, p_SiteID, p_IsSupplierView));
        stringBuilder.Append(this.ToWithWorkInnerMoveInQuery(p_param, UbModelBase.UNI_STOCK, p_SiteID, p_IsSupplierView));
        stringBuilder.Append(this.ToWithWorkOuterMoveOutQuery(p_param, UbModelBase.UNI_STOCK, p_SiteID, p_IsSupplierView));
        stringBuilder.Append(this.ToWithWorkOuterMoveInQuery(p_param, UbModelBase.UNI_STOCK, p_SiteID, p_IsSupplierView));
        stringBuilder.Append(this.ToWithWorkAdjustQuery(p_param, UbModelBase.UNI_STOCK, p_SiteID, p_IsSupplierView));
        stringBuilder.Append(this.ToWithWorkDisuseQuery(p_param, UbModelBase.UNI_STOCK, p_SiteID, p_IsSupplierView));
        stringBuilder.Append("\nSELECT" + string.Format(" 0 AS {0},{1} AS {2},{3}", (object) "pls_YyyyMm", (object) num, (object) "pls_StoreCode", (object) "pls_GoodsCode") + ",pls_SiteID,gdh_Supplier AS pls_Supplier,0 AS pls_SupplierType,gdh_GoodsCategory AS pls_CategoryCode,gd_TaxDiv AS pls_TaxDiv,gd_StockUnit AS pls_StockUnit,gd_SalesUnit AS pls_SalesUnit");
        stringBuilder.Append(TProfitLossSummary.MainCol);
        stringBuilder.Append("\n,0 AS pls_PriceUp,0 AS pls_PriceUpVat,0 AS pls_PriceDown,0 AS pls_PriceDownVat");
        stringBuilder.Append("\n,pls_Date");
        if (p_IsSupplierView)
          stringBuilder.Append("\n,su_Supplier,su_HeadSupplier,su_SupplierName,su_SupplierViewCode,su_SupplierType,su_SupplierKind,su_UseYn");
        else
          stringBuilder.Append("\n,0 AS su_Supplier,0 AS su_HeadSupplier,'' AS su_SupplierName,'' AS su_SupplierViewCode,0 AS su_SupplierType,0 AS su_SupplierKind,'' AS su_UseYn");
        stringBuilder.Append("\n,gdh_SalePrice,gdh_EventPrice");
        stringBuilder.Append("\nFROM (");
        stringBuilder.Append("\nSELECT pls_Date,pls_GoodsCode,pls_SiteID");
        if (p_IsSupplierView)
          stringBuilder.Append(",pls_Supplier");
        stringBuilder.Append(TProfitLossSummary.SubCol);
        stringBuilder.Append("\nFROM (");
        stringBuilder.Append("\nSELECT  pls_Date,pls_GoodsCode,pls_SiteID");
        if (p_IsSupplierView)
          stringBuilder.Append(",pls_Supplier");
        stringBuilder.Append(TProfitLossSummary.TBodyStartCol);
        stringBuilder.Append("\nFROM TBodyStartTable");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append("\nSELECT  pls_Date,pls_GoodsCode,pls_SiteID");
        if (p_IsSupplierView)
          stringBuilder.Append(",pls_Supplier");
        stringBuilder.Append(TProfitLossSummary.TBodySaleCol);
        stringBuilder.Append("\nFROM TBodySaleTable");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append("\nSELECT  pls_Date,pls_GoodsCode,pls_SiteID");
        if (p_IsSupplierView)
          stringBuilder.Append(",pls_Supplier");
        stringBuilder.Append(TProfitLossSummary.TBodyBuyCol);
        stringBuilder.Append("\nFROM TBodyBuyTable");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append("\nSELECT  pls_Date,pls_GoodsCode,pls_SiteID");
        if (p_IsSupplierView)
          stringBuilder.Append(",pls_Supplier");
        stringBuilder.Append(TProfitLossSummary.TBodyReturnCol);
        stringBuilder.Append("\nFROM TBodyReturnTable");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append("\nSELECT  pls_Date,pls_GoodsCode,pls_SiteID");
        if (p_IsSupplierView)
          stringBuilder.Append(",pls_Supplier");
        stringBuilder.Append(TProfitLossSummary.TBodyInnerMoveOutCol);
        stringBuilder.Append("\nFROM TBodyInnerMoveOutTable");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append("\nSELECT  pls_Date,pls_GoodsCode,pls_SiteID");
        if (p_IsSupplierView)
          stringBuilder.Append(",pls_Supplier");
        stringBuilder.Append(TProfitLossSummary.TBodyInnerMoveInCol);
        stringBuilder.Append("\nFROM TBodyInnerMoveInTable");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append("\nSELECT  pls_Date,pls_GoodsCode,pls_SiteID");
        if (p_IsSupplierView)
          stringBuilder.Append(",pls_Supplier");
        stringBuilder.Append(TProfitLossSummary.TBodyOuterMoveOutCol);
        stringBuilder.Append("\nFROM TBodyOuterMoveOutTable");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append("\nSELECT  pls_Date,pls_GoodsCode,pls_SiteID");
        if (p_IsSupplierView)
          stringBuilder.Append(",pls_Supplier");
        stringBuilder.Append(TProfitLossSummary.TBodyOuterMoveInCol);
        stringBuilder.Append("\nFROM TBodyOuterMoveInTable");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append("\nSELECT  pls_Date,pls_GoodsCode,pls_SiteID");
        if (p_IsSupplierView)
          stringBuilder.Append(",pls_Supplier");
        stringBuilder.Append(TProfitLossSummary.TBodyAdjustCol);
        stringBuilder.Append("\nFROM TBodyAdjustTable");
        stringBuilder.Append("\nUNION ALL");
        stringBuilder.Append("\nSELECT  pls_Date,pls_GoodsCode,pls_SiteID");
        if (p_IsSupplierView)
          stringBuilder.Append(",pls_Supplier");
        stringBuilder.Append(TProfitLossSummary.TBodyDisuseCol);
        stringBuilder.Append("\nFROM TBodyDisuseTable");
        stringBuilder.Append("\n) SUB");
        stringBuilder.Append("\nGROUP BY pls_Date,pls_GoodsCode");
        stringBuilder.Append(",pls_SiteID");
        if (p_IsSupplierView)
          stringBuilder.Append(",pls_Supplier");
        stringBuilder.Append("\n) MAIN");
        stringBuilder.Append("\nINNER JOIN T_GOODS ON pls_GoodsCode=gd_GoodsCode AND pls_SiteID=gd_SiteID" + string.Format("\nINNER JOIN T_HISTORY ON {0}={1}", (object) "gdh_StoreCode", (object) num) + " AND pls_GoodsCode=gdh_GoodsCode AND gdh_StartDate<=pls_Date AND gdh_EndDate>=pls_Date AND pls_SiteID=gdh_SiteID");
        if (p_IsSupplierView)
          stringBuilder.Append("\n INNER JOIN T_SUPPLIER ON gdh_Supplier=su_Supplier AND pls_SiteID=su_SiteID");
        stringBuilder.Append("\n");
        if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append(" ORDER BY " + empty);
        else
          stringBuilder.Append(" ORDER BY pls_GoodsCode,pls_Date");
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
      Log.Logger.DebugColor(" 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + string.Format("\n LINE : {0} 행", (object) new StackFrame(0, true).GetFileLineNumber()) + "\n--------------------------------------------------------------------------------------------------\nQuery\n--------------------------------------------------------------------------------------------------\n" + stringBuilder.ToString() + "\n--------------------------------------------------------------------------------------------------");
      return stringBuilder.ToString();
    }
  }
}
