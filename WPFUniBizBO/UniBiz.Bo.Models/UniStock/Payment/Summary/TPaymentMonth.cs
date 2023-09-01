// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Payment.Summary.TPaymentMonth
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
using UniBiz.Bo.Models.UniBase.Store.StoreInfo;
using UniBiz.Bo.Models.UniBase.Supplier.Supplier;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniStock.Payment.Summary
{
  public class TPaymentMonth : UbModelBase<TPaymentMonth>
  {
    private int _paym_YyyyMm;
    private int _paym_StoreCode;
    private int _paym_Supplier;
    private long _paym_SiteID;
    private double _paym_BaseAmount;
    private double _paym_BuyTax;
    private double _paym_BuyVat;
    private double _paym_BuyFree;
    private double _paym_BuyReturnTax;
    private double _paym_BuyReturnVat;
    private double _paym_BuyReturnFree;
    private double _paym_Deposit;
    private double _paym_SaleTax;
    private double _paym_SaleVat;
    private double _paym_SaleFree;
    private double _paym_DeductionAmount;
    private double _paym_PayAmount;
    private double _paym_AddAmount;
    private double _paym_EndAmount;
    [JsonIgnore]
    public static string MainCol = ",paym_BaseAmount,paym_BuyTax,paym_BuyVat,paym_BuyFree,paym_BuyReturnTax,paym_BuyReturnVat,paym_BuyReturnFree,paym_Deposit,paym_SaleTax,paym_SaleVat,paym_SaleFree,paym_DeductionAmount,paym_PayAmount,paym_AddAmount,paym_EndAmount";
    [JsonIgnore]
    public static string SubCol = ",SUM(paym_BaseAmount) AS paym_BaseAmount,SUM(paym_BuyTax) AS paym_BuyTax,SUM(paym_BuyVat) AS paym_BuyVat,SUM(paym_BuyFree) AS paym_BuyFree,SUM(paym_BuyReturnTax) AS paym_BuyReturnTax,SUM(paym_BuyReturnVat) AS paym_BuyReturnVat,SUM(paym_BuyReturnFree) AS paym_BuyReturnFree,SUM(paym_Deposit) AS paym_Deposit,SUM(paym_SaleTax) AS paym_SaleTax,SUM(paym_SaleVat) AS paym_SaleVat,SUM(paym_SaleFree) AS paym_SaleFree,SUM(paym_DeductionAmount) AS paym_DeductionAmount,SUM(paym_PayAmount) AS paym_PayAmount,SUM(paym_AddAmount) AS paym_AddAmount,SUM(paym_EndAmount) AS paym_EndAmount";
    [JsonIgnore]
    public const string TBodyStartTable = "기초";
    [JsonIgnore]
    public static string TBodyStartCol = ",paym_BaseAmount,0 AS paym_BuyTax,0 AS paym_BuyVat,0 AS paym_BuyFree,0 AS paym_BuyReturnTax,0 AS paym_BuyReturnVat,0 AS paym_BuyReturnFree,0 AS paym_Deposit,0 AS paym_SaleTax,0 AS paym_SaleVat,0 AS paym_SaleFree,0 AS paym_DeductionAmount,0 AS paym_PayAmount,0 AS paym_AddAmount,0 AS paym_EndAmount";
    [JsonIgnore]
    public const string TBodyEndTable = "기말";
    [JsonIgnore]
    public static string TBodyEndCol = ",0 AS paym_BaseAmount,0 AS paym_BuyTax,0 AS paym_BuyVat,0 AS paym_BuyFree,0 AS paym_BuyReturnTax,0 AS paym_BuyReturnVat,0 AS paym_BuyReturnFree,0 AS paym_Deposit,0 AS paym_SaleTax,0 AS paym_SaleVat,0 AS paym_SaleFree,0 AS paym_DeductionAmount,0 AS paym_PayAmount,0 AS paym_AddAmount,paym_EndAmount";
    [JsonIgnore]
    public const string TBodyBuyTable = "매입";
    [JsonIgnore]
    public static string TBodyBuyCol = ",0 AS paym_BaseAmount,paym_BuyTax,paym_BuyVat,paym_BuyFree,0 AS paym_BuyReturnTax,0 AS paym_BuyReturnVat,0 AS paym_BuyReturnFree,paym_Deposit,0 AS paym_SaleTax,0 AS paym_SaleVat,0 AS paym_SaleFree,0 AS paym_DeductionAmount,0 AS paym_PayAmount,0 AS paym_AddAmount,0 AS paym_EndAmount";
    [JsonIgnore]
    public const string TBodyReturnTable = "반품";
    [JsonIgnore]
    public static string TBodyReturnCol = ",0 AS paym_BaseAmount,0 AS paym_BuyTax,0 AS paym_BuyVat,0 AS paym_BuyFree,paym_BuyReturnTax,paym_BuyReturnVat,paym_BuyReturnFree,paym_Deposit,0 AS paym_SaleTax,0 AS paym_SaleVat,0 AS paym_SaleFree,0 AS paym_DeductionAmount,0 AS paym_PayAmount,0 AS paym_AddAmount,0 AS paym_EndAmount";
    [JsonIgnore]
    public const string TPaymetDetailTable = "대금결제전표상세";
    [JsonIgnore]
    public static string TPaymetDetailCol = ",0 AS paym_BaseAmount,0 AS paym_BuyTax,0 AS paym_BuyVat,0 AS paym_BuyFree,0 AS paym_BuyReturnTax,0 AS paym_BuyReturnVat,0 AS paym_BuyReturnFree,0 AS paym_Deposit,0 AS paym_SaleTax,0 AS paym_SaleVat,0 AS paym_SaleFree,paym_DeductionAmount,paym_PayAmount,paym_AddAmount,0 AS paym_EndAmount";

    public override object _Key => (object) new object[3]
    {
      (object) this.paym_YyyyMm,
      (object) this.paym_StoreCode,
      (object) this.paym_Supplier
    };

    public int paym_YyyyMm
    {
      get => this._paym_YyyyMm;
      set
      {
        this._paym_YyyyMm = value;
        this.Changed(nameof (paym_YyyyMm));
      }
    }

    public int paym_StoreCode
    {
      get => this._paym_StoreCode;
      set
      {
        this._paym_StoreCode = value;
        this.Changed(nameof (paym_StoreCode));
      }
    }

    public int paym_Supplier
    {
      get => this._paym_Supplier;
      set
      {
        this._paym_Supplier = value;
        this.Changed(nameof (paym_Supplier));
      }
    }

    public long paym_SiteID
    {
      get => this._paym_SiteID;
      set
      {
        this._paym_SiteID = value;
        this.Changed(nameof (paym_SiteID));
      }
    }

    public double paym_BaseAmount
    {
      get => this._paym_BaseAmount;
      set
      {
        this._paym_BaseAmount = value;
        this.Changed(nameof (paym_BaseAmount));
      }
    }

    public double paym_BuyTax
    {
      get => this._paym_BuyTax;
      set
      {
        this._paym_BuyTax = value;
        this.Changed(nameof (paym_BuyTax));
        this.Changed("paym_BuyAmount");
        this.Changed("paym_BuySumAmount");
      }
    }

    public double paym_BuyVat
    {
      get => this._paym_BuyVat;
      set
      {
        this._paym_BuyVat = value;
        this.Changed(nameof (paym_BuyVat));
        this.Changed("paym_BuyAmount");
        this.Changed("paym_BuySumAmount");
      }
    }

    public double paym_BuyFree
    {
      get => this._paym_BuyFree;
      set
      {
        this._paym_BuyFree = value;
        this.Changed(nameof (paym_BuyFree));
        this.Changed("paym_BuyAmount");
        this.Changed("paym_BuySumAmount");
      }
    }

    public double paym_BuyAmount => this.paym_BuyTax + this.paym_BuyVat + this.paym_BuyFree;

    public double paym_BuyReturnTax
    {
      get => this._paym_BuyReturnTax;
      set
      {
        this._paym_BuyReturnTax = value;
        this.Changed(nameof (paym_BuyReturnTax));
        this.Changed("paym_BuyReturnAmount");
        this.Changed("paym_BuySumAmount");
      }
    }

    public double paym_BuyReturnVat
    {
      get => this._paym_BuyReturnVat;
      set
      {
        this._paym_BuyReturnVat = value;
        this.Changed(nameof (paym_BuyReturnVat));
        this.Changed("paym_BuyReturnAmount");
        this.Changed("paym_BuySumAmount");
      }
    }

    public double paym_BuyReturnFree
    {
      get => this._paym_BuyReturnFree;
      set
      {
        this._paym_BuyReturnFree = value;
        this.Changed(nameof (paym_BuyReturnFree));
        this.Changed("paym_BuyReturnAmount");
        this.Changed("paym_BuySumAmount");
      }
    }

    public double paym_BuyReturnAmount => this.paym_BuyReturnTax + this.paym_BuyReturnVat + this.paym_BuyReturnFree;

    public double paym_BuySumAmount => this.paym_BuyAmount - this.paym_BuyReturnAmount;

    public double paym_Deposit
    {
      get => this._paym_Deposit;
      set
      {
        this._paym_Deposit = value;
        this.Changed(nameof (paym_Deposit));
      }
    }

    public double paym_SaleTax
    {
      get => this._paym_SaleTax;
      set
      {
        this._paym_SaleTax = value;
        this.Changed(nameof (paym_SaleTax));
      }
    }

    public double paym_SaleVat
    {
      get => this._paym_SaleVat;
      set
      {
        this._paym_SaleVat = value;
        this.Changed(nameof (paym_SaleVat));
      }
    }

    public double paym_SaleFree
    {
      get => this._paym_SaleFree;
      set
      {
        this._paym_SaleFree = value;
        this.Changed(nameof (paym_SaleFree));
      }
    }

    public double paym_DeductionAmount
    {
      get => this._paym_DeductionAmount;
      set
      {
        this._paym_DeductionAmount = value;
        this.Changed(nameof (paym_DeductionAmount));
      }
    }

    public double paym_PayAmount
    {
      get => this._paym_PayAmount;
      set
      {
        this._paym_PayAmount = value;
        this.Changed(nameof (paym_PayAmount));
      }
    }

    public double paym_AddAmount
    {
      get => this._paym_AddAmount;
      set
      {
        this._paym_AddAmount = value;
        this.Changed(nameof (paym_AddAmount));
      }
    }

    public double paym_EndAmount
    {
      get => this._paym_EndAmount;
      set
      {
        this._paym_EndAmount = value;
        this.Changed(nameof (paym_EndAmount));
      }
    }

    public void CalcEndAAmount() => this.paym_EndAmount = this.paym_BaseAmount + this.paym_BuySumAmount - this.paym_DeductionAmount - this.paym_PayAmount - this.paym_AddAmount;

    public TPaymentMonth() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("paym_YyyyMm", new TTableColumn()
      {
        tc_orgin_name = "paym_YyyyMm",
        tc_trans_name = "결제월"
      });
      columnInfo.Add("paym_StoreCode", new TTableColumn()
      {
        tc_orgin_name = "paym_StoreCode",
        tc_trans_name = "지점코드"
      });
      columnInfo.Add("paym_Supplier", new TTableColumn()
      {
        tc_orgin_name = "paym_Supplier",
        tc_trans_name = "코드"
      });
      columnInfo.Add("paym_SiteID", new TTableColumn()
      {
        tc_orgin_name = "paym_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("paym_BaseAmount", new TTableColumn()
      {
        tc_orgin_name = "paym_BaseAmount",
        tc_trans_name = "기초금액"
      });
      columnInfo.Add("paym_BuyTax", new TTableColumn()
      {
        tc_orgin_name = "paym_BuyTax",
        tc_trans_name = "매입과세계"
      });
      columnInfo.Add("paym_BuyVat", new TTableColumn()
      {
        tc_orgin_name = "paym_BuyVat",
        tc_trans_name = "매입부가세계"
      });
      columnInfo.Add("paym_BuyFree", new TTableColumn()
      {
        tc_orgin_name = "paym_BuyFree",
        tc_trans_name = "매입면세계"
      });
      columnInfo.Add("paym_BuyAmount", new TTableColumn()
      {
        tc_orgin_name = "paym_BuyAmount",
        tc_trans_name = "매입계"
      });
      columnInfo.Add("paym_BuyReturnTax", new TTableColumn()
      {
        tc_orgin_name = "paym_BuyReturnTax",
        tc_trans_name = "반품과세계"
      });
      columnInfo.Add("paym_BuyReturnVat", new TTableColumn()
      {
        tc_orgin_name = "paym_BuyReturnVat",
        tc_trans_name = "반품부가세계"
      });
      columnInfo.Add("paym_BuyReturnFree", new TTableColumn()
      {
        tc_orgin_name = "paym_BuyReturnFree",
        tc_trans_name = "반품면세계"
      });
      columnInfo.Add("paym_BuyReturnAmount", new TTableColumn()
      {
        tc_orgin_name = "paym_BuyReturnAmount",
        tc_trans_name = "반품계"
      });
      columnInfo.Add("paym_BuySumAmount", new TTableColumn()
      {
        tc_orgin_name = "paym_BuySumAmount",
        tc_trans_name = "매입반품합계"
      });
      columnInfo.Add("paym_Deposit", new TTableColumn()
      {
        tc_orgin_name = "paym_Deposit",
        tc_trans_name = "저장품계"
      });
      columnInfo.Add("paym_SaleTax", new TTableColumn()
      {
        tc_orgin_name = "paym_SaleTax",
        tc_trans_name = "매출과세계"
      });
      columnInfo.Add("paym_SaleVat", new TTableColumn()
      {
        tc_orgin_name = "paym_SaleVat",
        tc_trans_name = "매출부가세계"
      });
      columnInfo.Add("paym_SaleFree", new TTableColumn()
      {
        tc_orgin_name = "paym_SaleFree",
        tc_trans_name = "매출면세계"
      });
      columnInfo.Add("paym_DeductionAmount", new TTableColumn()
      {
        tc_orgin_name = "paym_DeductionAmount",
        tc_trans_name = "공제금액"
      });
      columnInfo.Add("paym_PayAmount", new TTableColumn()
      {
        tc_orgin_name = "paym_PayAmount",
        tc_trans_name = "결제금액"
      });
      columnInfo.Add("paym_AddAmount", new TTableColumn()
      {
        tc_orgin_name = "paym_AddAmount",
        tc_trans_name = "보정금액"
      });
      columnInfo.Add("paym_EndAmount", new TTableColumn()
      {
        tc_orgin_name = "paym_EndAmount",
        tc_trans_name = "기말금액"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.PaymentMonth;
      this.paym_YyyyMm = this.paym_StoreCode = this.paym_Supplier = 0;
      this.paym_SiteID = 0L;
      this.paym_BaseAmount = 0.0;
      this.paym_BuyTax = this.paym_BuyVat = this.paym_BuyFree = 0.0;
      this.paym_BuyReturnTax = this.paym_BuyReturnVat = this.paym_BuyReturnFree = 0.0;
      this.paym_Deposit = 0.0;
      this.paym_SaleTax = this.paym_SaleVat = this.paym_SaleFree = 0.0;
      this.paym_DeductionAmount = this.paym_PayAmount = this.paym_AddAmount = this.paym_EndAmount = 0.0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TPaymentMonth();

    public override object Clone()
    {
      TPaymentMonth tpaymentMonth = base.Clone() as TPaymentMonth;
      tpaymentMonth.paym_YyyyMm = this.paym_YyyyMm;
      tpaymentMonth.paym_StoreCode = this.paym_StoreCode;
      tpaymentMonth.paym_Supplier = this.paym_Supplier;
      tpaymentMonth.paym_SiteID = this.paym_SiteID;
      tpaymentMonth.paym_BaseAmount = this.paym_BaseAmount;
      tpaymentMonth.paym_BuyTax = this.paym_BuyTax;
      tpaymentMonth.paym_BuyVat = this.paym_BuyVat;
      tpaymentMonth.paym_BuyFree = this.paym_BuyFree;
      tpaymentMonth.paym_BuyReturnTax = this.paym_BuyReturnTax;
      tpaymentMonth.paym_BuyReturnVat = this.paym_BuyReturnVat;
      tpaymentMonth.paym_BuyReturnFree = this.paym_BuyReturnFree;
      tpaymentMonth.paym_Deposit = this.paym_Deposit;
      tpaymentMonth.paym_SaleTax = this.paym_SaleTax;
      tpaymentMonth.paym_SaleVat = this.paym_SaleVat;
      tpaymentMonth.paym_SaleFree = this.paym_SaleFree;
      tpaymentMonth.paym_DeductionAmount = this.paym_DeductionAmount;
      tpaymentMonth.paym_PayAmount = this.paym_PayAmount;
      tpaymentMonth.paym_AddAmount = this.paym_AddAmount;
      tpaymentMonth.paym_EndAmount = this.paym_EndAmount;
      return (object) tpaymentMonth;
    }

    public void PutData(TPaymentMonth pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.paym_YyyyMm = pSource.paym_YyyyMm;
      this.paym_StoreCode = pSource.paym_StoreCode;
      this.paym_Supplier = pSource.paym_Supplier;
      this.paym_SiteID = pSource.paym_SiteID;
      this.paym_BaseAmount = pSource.paym_BaseAmount;
      this.paym_BuyTax = pSource.paym_BuyTax;
      this.paym_BuyVat = pSource.paym_BuyVat;
      this.paym_BuyFree = pSource.paym_BuyFree;
      this.paym_BuyReturnTax = pSource.paym_BuyReturnTax;
      this.paym_BuyReturnVat = pSource.paym_BuyReturnVat;
      this.paym_BuyReturnFree = pSource.paym_BuyReturnFree;
      this.paym_Deposit = pSource.paym_Deposit;
      this.paym_SaleTax = pSource.paym_SaleTax;
      this.paym_SaleVat = pSource.paym_SaleVat;
      this.paym_SaleFree = pSource.paym_SaleFree;
      this.paym_DeductionAmount = pSource.paym_DeductionAmount;
      this.paym_PayAmount = pSource.paym_PayAmount;
      this.paym_AddAmount = pSource.paym_AddAmount;
      this.paym_EndAmount = pSource.paym_EndAmount;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.paym_YyyyMm = p_rs.GetFieldInt("paym_YyyyMm");
        if (this.paym_YyyyMm == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.paym_StoreCode = p_rs.GetFieldInt("paym_StoreCode");
        this.paym_Supplier = p_rs.GetFieldInt("paym_Supplier");
        this.paym_SiteID = p_rs.GetFieldLong("paym_SiteID");
        this.paym_BaseAmount = p_rs.GetFieldDouble("paym_BaseAmount");
        this.paym_BuyTax = p_rs.GetFieldDouble("paym_BuyTax");
        this.paym_BuyVat = p_rs.GetFieldDouble("paym_BuyVat");
        this.paym_BuyFree = p_rs.GetFieldDouble("paym_BuyFree");
        this.paym_BuyReturnTax = p_rs.GetFieldDouble("paym_BuyReturnTax");
        this.paym_BuyReturnVat = p_rs.GetFieldDouble("paym_BuyReturnVat");
        this.paym_BuyReturnFree = p_rs.GetFieldDouble("paym_BuyReturnFree");
        this.paym_Deposit = p_rs.GetFieldDouble("paym_Deposit");
        this.paym_SaleTax = p_rs.GetFieldDouble("paym_SaleTax");
        this.paym_SaleVat = p_rs.GetFieldDouble("paym_SaleVat");
        this.paym_SaleFree = p_rs.GetFieldDouble("paym_SaleFree");
        this.paym_DeductionAmount = p_rs.GetFieldDouble("paym_DeductionAmount");
        this.paym_PayAmount = p_rs.GetFieldDouble("paym_PayAmount");
        this.paym_AddAmount = p_rs.GetFieldDouble("paym_AddAmount");
        this.paym_EndAmount = p_rs.GetFieldDouble("paym_EndAmount");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public virtual bool CalcAddSum(TPaymentMonth pSource)
    {
      if (pSource == null)
        return false;
      this.paym_BaseAmount += pSource.paym_BaseAmount;
      this.paym_BuyTax = pSource.paym_BuyTax;
      this.paym_BuyVat = pSource.paym_BuyVat;
      this.paym_BuyFree = pSource.paym_BuyFree;
      this.paym_BuyReturnTax = pSource.paym_BuyReturnTax;
      this.paym_BuyReturnVat = pSource.paym_BuyReturnVat;
      this.paym_BuyReturnFree = pSource.paym_BuyReturnFree;
      this.paym_Deposit = pSource.paym_Deposit;
      this.paym_SaleTax = pSource.paym_SaleTax;
      this.paym_SaleVat = pSource.paym_SaleVat;
      this.paym_SaleFree = pSource.paym_SaleFree;
      this.paym_DeductionAmount = pSource.paym_DeductionAmount;
      this.paym_PayAmount = pSource.paym_PayAmount;
      this.paym_AddAmount = pSource.paym_AddAmount;
      this.paym_EndAmount = pSource.paym_EndAmount;
      return true;
    }

    public virtual bool IsZero(EnumZeroCheck pCheckType, TPaymentMonth pSource) => pSource == null || !Enum2StrConverter.IsZeroCheckSubsetAmount(pCheckType) || pSource.paym_BaseAmount.IsZero() && pSource.paym_BuyTax.IsZero() && pSource.paym_BuyVat.IsZero() && pSource.paym_BuyFree.IsZero() && pSource.paym_BuyReturnTax.IsZero() && pSource.paym_BuyReturnVat.IsZero() && pSource.paym_BuyReturnFree.IsZero() && pSource.paym_Deposit.IsZero() && pSource.paym_SaleTax.IsZero() && pSource.paym_SaleVat.IsZero() && pSource.paym_SaleFree.IsZero() && pSource.paym_DeductionAmount.IsZero() && pSource.paym_PayAmount.IsZero() && pSource.paym_AddAmount.IsZero() && pSource.paym_EndAmount.IsZero();

    public virtual bool IsZero(EnumZeroCheck pCheckType) => this.IsZero(pCheckType, this);

    public virtual string DataClearQuery(Hashtable p_param)
    {
      StringBuilder stringBuilder = new StringBuilder();
      try
      {
        string uniStock = UbModelBase.UNI_STOCK;
        this.TableCode.ToString();
        if (!p_param.ContainsKey((object) "paym_YyyyMm") || Convert.ToInt32(p_param[(object) "paym_YyyyMm"].ToString()) == 0)
          throw new Exception("월 정보 데이터 부족.");
        stringBuilder.Append(string.Format(" UPDATE {0}{1}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) this.TableCode));
        EnumDB enumDb = DbQueryHelper.DbTypeNotNull();
        if (enumDb == EnumDB.MYSQL)
          stringBuilder.Append(string.Format("\nINNER JOIN {0}{1}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.StoreInfo) + " ON paym_StoreCode=si_StoreCode AND paym_SiteID=si_SiteID AND " + "si_StockConfirmDate".DateToStr(EnumDbDateType.YYYYMM).ToInt() + "<paym_YyyyMm AND " + "si_StockStartDate".DateToStr(EnumDbDateType.YYYYMM).ToInt() + "<paym_YyyyMm");
        stringBuilder.Append("\nSET  paym_BaseAmount=0,paym_BuyTax=0,paym_BuyVat=0,paym_BuyFree=0,paym_BuyReturnTax=0,paym_BuyReturnVat=0,paym_BuyReturnFree=0,paym_Deposit=0,paym_SaleTax=0,paym_SaleVat=0,paym_SaleFree=0,paym_DeductionAmount=0,paym_PayAmount=0,paym_AddAmount=0,paym_EndAmount=0");
        if (enumDb == EnumDB.MSSQL)
          stringBuilder.Append(string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) this.TableCode, (object) DbQueryHelper.ToWithNolock()) + string.Format("\nINNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()) + " ON paym_StoreCode=si_StoreCode AND paym_SiteID=si_SiteID AND " + "si_StockConfirmDate".DateToStr(EnumDbDateType.YYYYMM).ToInt() + "<paym_YyyyMm AND " + "si_StockStartDate".DateToStr(EnumDbDateType.YYYYMM).ToInt() + "<paym_YyyyMm");
        stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "paym_YyyyMm", p_param[(object) "paym_YyyyMm"]));
        if (p_param.ContainsKey((object) "paym_StoreCode") && Convert.ToInt32(p_param[(object) "paym_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "paym_StoreCode", p_param[(object) "paym_StoreCode"]));
        else if (p_param.ContainsKey((object) "paym_StoreCode_IN_") && p_param[(object) "paym_StoreCode_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "paym_StoreCode", p_param[(object) "paym_StoreCode_IN_"]));
        else if (p_param.ContainsKey((object) "_STORE_AUTHS_") && p_param[(object) "_STORE_AUTHS_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "paym_StoreCode", p_param[(object) "_STORE_AUTHS_"]));
        else
          stringBuilder.Append(" AND paym_StoreCode > 0");
        if (p_param.ContainsKey((object) "paym_Supplier") && Convert.ToInt32(p_param[(object) "paym_Supplier"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "paym_Supplier", p_param[(object) "paym_Supplier"]));
        else if (p_param.ContainsKey((object) "paym_Supplier_IN_"))
        {
          if (p_param[(object) "paym_Supplier_IN_"].ToString().Length > 0)
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "paym_Supplier", p_param[(object) "paym_Supplier_IN_"]));
        }
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) ex.GetHashCode()) + " 내용 : " + ex.Message + "\n" + string.Format(" Query : {0}\n", (object) stringBuilder) + "--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
        stringBuilder.Clear();
      }
      return stringBuilder.ToString();
    }

    public virtual bool DataClear(Hashtable p_param)
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.DataClearQuery(p_param)))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.paym_YyyyMm, (object) this.paym_StoreCode, (object) this.paym_Supplier, (object) this.paym_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public virtual async Task<bool> DataClearAsync(Hashtable p_param)
    {
      TPaymentMonth tpaymentMonth = this;
      // ISSUE: reference to a compiler-generated method
      tpaymentMonth.\u003C\u003En__0();
      if (await tpaymentMonth.OleDB.ExecuteAsync(tpaymentMonth.DataClearQuery(p_param)))
        return true;
      tpaymentMonth.message = " " + tpaymentMonth.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tpaymentMonth.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tpaymentMonth.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tpaymentMonth.paym_YyyyMm, (object) tpaymentMonth.paym_StoreCode, (object) tpaymentMonth.paym_Supplier, (object) tpaymentMonth.paym_SiteID) + " 내용 : " + tpaymentMonth.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tpaymentMonth.message);
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) this.TableCode) + " paym_YyyyMm,paym_StoreCode,paym_Supplier,paym_SiteID,paym_BaseAmount,paym_BuyTax,paym_BuyVat,paym_BuyFree,paym_BuyReturnTax,paym_BuyReturnVat,paym_BuyReturnFree,paym_Deposit,paym_SaleTax,paym_SaleVat,paym_SaleFree,paym_DeductionAmount,paym_PayAmount,paym_AddAmount,paym_EndAmount) VALUES ( " + string.Format(" {0},{1},{2}", (object) this.paym_YyyyMm, (object) this.paym_StoreCode, (object) this.paym_Supplier) + string.Format(",{0}", (object) this.paym_SiteID) + "," + this.paym_BaseAmount.FormatTo("{0:0.0000}") + "," + this.paym_BuyTax.FormatTo("{0:0.0000}") + "," + this.paym_BuyVat.FormatTo("{0:0.0000}") + "," + this.paym_BuyFree.FormatTo("{0:0.0000}") + "," + this.paym_BuyReturnTax.FormatTo("{0:0.0000}") + "," + this.paym_BuyReturnVat.FormatTo("{0:0.0000}") + "," + this.paym_BuyReturnFree.FormatTo("{0:0.0000}") + "," + this.paym_Deposit.FormatTo("{0:0.0000}") + "," + this.paym_SaleTax.FormatTo("{0:0.0000}") + "," + this.paym_SaleVat.FormatTo("{0:0.0000}") + "," + this.paym_SaleFree.FormatTo("{0:0.0000}") + "," + this.paym_DeductionAmount.FormatTo("{0:0.0000}") + "," + this.paym_PayAmount.FormatTo("{0:0.0000}") + "," + this.paym_AddAmount.FormatTo("{0:0.0000}") + "," + this.paym_EndAmount.FormatTo("{0:0.0000}") + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.paym_YyyyMm, (object) this.paym_StoreCode, (object) this.paym_Supplier, (object) this.paym_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TPaymentMonth tpaymentMonth = this;
      // ISSUE: reference to a compiler-generated method
      tpaymentMonth.\u003C\u003En__0();
      if (await tpaymentMonth.OleDB.ExecuteAsync(tpaymentMonth.InsertQuery()))
        return true;
      tpaymentMonth.message = " " + tpaymentMonth.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tpaymentMonth.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tpaymentMonth.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tpaymentMonth.paym_YyyyMm, (object) tpaymentMonth.paym_StoreCode, (object) tpaymentMonth.paym_Supplier, (object) tpaymentMonth.paym_SiteID) + " 내용 : " + tpaymentMonth.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tpaymentMonth.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) this.TableCode) + " paym_BaseAmount=" + this.paym_BaseAmount.FormatTo("{0:0.0000}") + ",paym_BuyTax=" + this.paym_BuyTax.FormatTo("{0:0.0000}") + ",paym_BuyVat=" + this.paym_BuyVat.FormatTo("{0:0.0000}") + ",paym_BuyFree=" + this.paym_BuyFree.FormatTo("{0:0.0000}") + ",paym_BuyReturnTax=" + this.paym_BuyReturnTax.FormatTo("{0:0.0000}") + ",paym_BuyReturnVat=" + this.paym_BuyReturnVat.FormatTo("{0:0.0000}") + ",paym_BuyReturnFree=" + this.paym_BuyReturnFree.FormatTo("{0:0.0000}") + ",paym_Deposit=" + this.paym_Deposit.FormatTo("{0:0.0000}") + ",paym_SaleTax=" + this.paym_SaleTax.FormatTo("{0:0.0000}") + ",paym_SaleVat=" + this.paym_SaleVat.FormatTo("{0:0.0000}") + ",paym_SaleFree=" + this.paym_SaleFree.FormatTo("{0:0.0000}") + ",paym_DeductionAmount=" + this.paym_DeductionAmount.FormatTo("{0:0.0000}") + ",paym_PayAmount=" + this.paym_PayAmount.FormatTo("{0:0.0000}") + ",paym_AddAmount=" + this.paym_AddAmount.FormatTo("{0:0.0000}") + ",paym_EndAmount=" + this.paym_EndAmount.FormatTo("{0:0.0000}") + string.Format(" WHERE {0}={1}", (object) "paym_YyyyMm", (object) this.paym_YyyyMm) + string.Format(" AND {0}={1}", (object) "paym_StoreCode", (object) this.paym_StoreCode) + string.Format(" AND {0}={1}", (object) "paym_Supplier", (object) this.paym_Supplier) + string.Format(" AND {0}={1}", (object) "paym_SiteID", (object) this.paym_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.paym_YyyyMm, (object) this.paym_StoreCode, (object) this.paym_Supplier, (object) this.paym_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TPaymentMonth tpaymentMonth = this;
      // ISSUE: reference to a compiler-generated method
      tpaymentMonth.\u003C\u003En__1();
      if (await tpaymentMonth.OleDB.ExecuteAsync(tpaymentMonth.UpdateQuery()))
        return true;
      tpaymentMonth.message = " " + tpaymentMonth.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tpaymentMonth.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tpaymentMonth.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tpaymentMonth.paym_YyyyMm, (object) tpaymentMonth.paym_StoreCode, (object) tpaymentMonth.paym_Supplier, (object) tpaymentMonth.paym_SiteID) + " 내용 : " + tpaymentMonth.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tpaymentMonth.message);
      return false;
    }

    public override string UpdateExInsertMySQLQuery()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(this.InsertQuery());
      if (stringBuilder.ToString().Contains(";"))
      {
        string str = stringBuilder.ToString().Replace(";", string.Empty);
        stringBuilder.Clear();
        stringBuilder.Append(str);
      }
      stringBuilder.Append(" ON DUPLICATE KEY UPDATE ");
      stringBuilder.Append("\n");
      stringBuilder.Append(" paym_BaseAmount=" + this.paym_BaseAmount.FormatTo("{0:0.0000}") + ",paym_BuyTax=" + this.paym_BuyTax.FormatTo("{0:0.0000}") + ",paym_BuyVat=" + this.paym_BuyVat.FormatTo("{0:0.0000}") + ",paym_BuyFree=" + this.paym_BuyFree.FormatTo("{0:0.0000}") + ",paym_BuyReturnTax=" + this.paym_BuyReturnTax.FormatTo("{0:0.0000}") + ",paym_BuyReturnVat=" + this.paym_BuyReturnVat.FormatTo("{0:0.0000}") + ",paym_BuyReturnFree=" + this.paym_BuyReturnFree.FormatTo("{0:0.0000}") + ",paym_Deposit=" + this.paym_Deposit.FormatTo("{0:0.0000}") + ",paym_SaleTax=" + this.paym_SaleTax.FormatTo("{0:0.0000}") + ",paym_SaleVat=" + this.paym_SaleVat.FormatTo("{0:0.0000}") + ",paym_SaleFree=" + this.paym_SaleFree.FormatTo("{0:0.0000}") + ",paym_DeductionAmount=" + this.paym_DeductionAmount.FormatTo("{0:0.0000}") + ",paym_PayAmount=" + this.paym_PayAmount.FormatTo("{0:0.0000}") + ",paym_AddAmount=" + this.paym_AddAmount.FormatTo("{0:0.0000}") + ",paym_EndAmount=" + this.paym_EndAmount.FormatTo("{0:0.0000}"));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.paym_YyyyMm, (object) this.paym_StoreCode, (object) this.paym_Supplier, (object) this.paym_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TPaymentMonth tpaymentMonth = this;
      // ISSUE: reference to a compiler-generated method
      tpaymentMonth.\u003C\u003En__1();
      if (await tpaymentMonth.OleDB.ExecuteAsync(tpaymentMonth.UpdateExInsertQuery()))
        return true;
      tpaymentMonth.message = " " + tpaymentMonth.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tpaymentMonth.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tpaymentMonth.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tpaymentMonth.paym_YyyyMm, (object) tpaymentMonth.paym_StoreCode, (object) tpaymentMonth.paym_Supplier, (object) tpaymentMonth.paym_SiteID) + " 내용 : " + tpaymentMonth.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tpaymentMonth.message);
      return false;
    }

    public virtual bool ItemSave() => false;

    public virtual async Task<bool> ItemSaveAsync()
    {
      await Task.CompletedTask;
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "paym_SiteID") && Convert.ToInt64(hashtable[(object) "paym_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "paym_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "paym_YyyyMm") && Convert.ToInt32(hashtable[(object) "paym_YyyyMm"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "paym_YyyyMm", hashtable[(object) "paym_YyyyMm"]));
        if (hashtable.ContainsKey((object) "paym_YyyyMm_BEGIN_") && Convert.ToInt32(hashtable[(object) "paym_YyyyMm_BEGIN_"].ToString()) > 0 && hashtable.ContainsKey((object) "paym_YyyyMm_END_") && Convert.ToInt32(hashtable[(object) "paym_YyyyMm_END_"].ToString()) > 0)
        {
          stringBuilder.Append(string.Format(" AND {0}>={1}", (object) "paym_YyyyMm", hashtable[(object) "paym_YyyyMm_BEGIN_"]));
          stringBuilder.Append(string.Format(" AND {0}<={1}", (object) "paym_YyyyMm", hashtable[(object) "paym_YyyyMm_END_"]));
        }
        if (hashtable.ContainsKey((object) "_DT_DATE_") && hashtable[(object) "_DT_DATE_"].ToString().Length > 0)
        {
          DateTime dateTime = Convert.ToDateTime(hashtable[(object) "_DT_DATE_"].ToString());
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "paym_YyyyMm", (object) (dateTime.Year * 100 + dateTime.Month)));
        }
        if (hashtable.ContainsKey((object) "_DT_START_DATE_") && hashtable.ContainsKey((object) "_DT_END_DATE_"))
        {
          DateTime dateTime1 = Convert.ToDateTime(hashtable[(object) "_DT_START_DATE_"].ToString());
          DateTime dateTime2 = Convert.ToDateTime(hashtable[(object) "_DT_END_DATE_"].ToString());
          stringBuilder.Append(string.Format(" AND {0}<={1}", (object) "paym_YyyyMm", (object) (dateTime1.Year * 100 + dateTime1.Month)));
          stringBuilder.Append(string.Format(" AND {0}>={1}", (object) "paym_YyyyMm", (object) (dateTime2.Year * 100 + dateTime2.Month)));
        }
        if (hashtable.ContainsKey((object) "paym_YyyyMm_BEFORE_") && Convert.ToInt32(hashtable[(object) "paym_YyyyMm_BEFORE_"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}<{1}", (object) "paym_YyyyMm", hashtable[(object) "paym_YyyyMm_BEFORE_"]));
        if (hashtable.ContainsKey((object) "paym_YyyyMm_NEXT_") && Convert.ToInt32(hashtable[(object) "paym_YyyyMm_NEXT_"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}>={1}", (object) "paym_YyyyMm", hashtable[(object) "paym_YyyyMm_NEXT_"]));
        if (hashtable.ContainsKey((object) "si_StoreCode") && Convert.ToInt32(hashtable[(object) "si_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "paym_StoreCode", hashtable[(object) "si_StoreCode"]));
        else if (hashtable.ContainsKey((object) "si_StoreCode_IN_") && hashtable[(object) "si_StoreCode_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "paym_StoreCode", hashtable[(object) "si_StoreCode_IN_"]));
        else if (hashtable.ContainsKey((object) "paym_StoreCode") && Convert.ToInt32(hashtable[(object) "paym_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "paym_StoreCode", hashtable[(object) "paym_StoreCode"]));
        else if (hashtable.ContainsKey((object) "paym_StoreCode_IN_") && hashtable[(object) "paym_StoreCode_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "paym_StoreCode", hashtable[(object) "paym_StoreCode_IN_"]));
        else if (hashtable.ContainsKey((object) "_STORE_AUTHS_") && hashtable[(object) "_STORE_AUTHS_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "paym_StoreCode", hashtable[(object) "_STORE_AUTHS_"]));
        if (hashtable.ContainsKey((object) "su_Supplier") && Convert.ToInt32(hashtable[(object) "su_Supplier"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "paym_Supplier", hashtable[(object) "su_Supplier"]));
        else if (hashtable.ContainsKey((object) "su_Supplier_IN_") && hashtable[(object) "su_Supplier_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "paym_Supplier", hashtable[(object) "su_Supplier_IN_"]));
        else if (hashtable.ContainsKey((object) "paym_Supplier") && Convert.ToInt32(hashtable[(object) "paym_Supplier"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "paym_Supplier", hashtable[(object) "paym_Supplier"]));
        else if (hashtable.ContainsKey((object) "paym_Supplier_IN_") && hashtable[(object) "paym_Supplier_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "paym_Supplier", hashtable[(object) "paym_Supplier_IN_"]));
        else if (hashtable.ContainsKey((object) "_SUPPLIER_AUTHS_") && hashtable[(object) "_SUPPLIER_AUTHS_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "paym_Supplier", hashtable[(object) "_SUPPLIER_AUTHS_"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "paym_SiteID", (object) num));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_"))
        {
          int length = hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length;
        }
      }
      return !stringBuilder.ToString().Equals(" WHERE") ? stringBuilder.Replace("WHERE AND", "WHERE").ToString() : string.Empty;
    }

    public override string GetSelectQuery(object p_param)
    {
      StringBuilder stringBuilder = new StringBuilder();
      try
      {
        string uniStock = UbModelBase.UNI_STOCK;
        string str = this.TableCode.ToString();
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniStock = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
        }
        stringBuilder.Append(" SELECT  paym_YyyyMm,paym_StoreCode,paym_Supplier,paym_SiteID,paym_BaseAmount,paym_BuyTax,paym_BuyVat,paym_BuyFree,paym_BuyReturnTax,paym_BuyReturnVat,paym_BuyReturnFree,paym_Deposit,paym_SaleTax,paym_SaleVat,paym_SaleFree,paym_DeductionAmount,paym_PayAmount,paym_AddAmount,paym_EndAmount");
        stringBuilder.Append(" FROM " + DbQueryHelper.ToDBNameBridge(uniStock) + str + " " + DbQueryHelper.ToWithNolock());
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) ex.GetHashCode()) + " 내용 : " + ex.Message + "\n Query : " + stringBuilder.ToString() + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
        stringBuilder.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToPaymentWhereAnd(Hashtable p_param)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param.ContainsKey((object) "pay_Code") && Convert.ToInt64(p_param[(object) "pay_Code"].ToString()) > 0L)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_Code", p_param[(object) "pay_Code"]));
      if (p_param.ContainsKey((object) "pay_SiteID") && Convert.ToInt64(p_param[(object) "pay_SiteID"].ToString()) > 0L)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_SiteID", (object) Convert.ToInt64(p_param[(object) "pay_SiteID"].ToString())));
      if (p_param.ContainsKey((object) "pay_Date"))
      {
        stringBuilder.Append(" AND pay_Date >='" + new DateTime?((DateTime) p_param[(object) "pay_Date"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
        stringBuilder.Append(" AND pay_Date <='" + new DateTime?((DateTime) p_param[(object) "pay_Date"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
      }
      if (p_param.ContainsKey((object) "pay_Date_BEGIN_") && p_param.ContainsKey((object) "pay_Date_END_"))
      {
        stringBuilder.Append(" AND pay_Date >='" + new DateTime?((DateTime) p_param[(object) "pay_Date_BEGIN_"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
        stringBuilder.Append(" AND pay_Date <='" + new DateTime?((DateTime) p_param[(object) "pay_Date_END_"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
      }
      if (p_param.ContainsKey((object) "si_StoreCode") && Convert.ToInt32(p_param[(object) "si_StoreCode"].ToString()) > 0)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_StoreCode", p_param[(object) "si_StoreCode"]));
      else if (p_param.ContainsKey((object) "pay_StoreCode") && Convert.ToInt32(p_param[(object) "pay_StoreCode"].ToString()) > 0)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_StoreCode", p_param[(object) "pay_StoreCode"]));
      else if (p_param.ContainsKey((object) "si_StoreCode_IN_") && p_param[(object) "si_StoreCode_IN_"].ToString().Length > 0)
      {
        if (p_param[(object) "si_StoreCode_IN_"].ToString().Contains(","))
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "pay_StoreCode", p_param[(object) "si_StoreCode_IN_"]));
        else
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_StoreCode", p_param[(object) "si_StoreCode_IN_"]));
      }
      else if (p_param.ContainsKey((object) "pay_StoreCode_IN_") && p_param[(object) "pay_StoreCode_IN_"].ToString().Length > 0)
        stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "pay_StoreCode", p_param[(object) "pay_StoreCode_IN_"]));
      else if (p_param.ContainsKey((object) "_STORE_AUTHS_") && p_param[(object) "_STORE_AUTHS_"].ToString().Length > 0)
        stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "pay_StoreCode", p_param[(object) "_STORE_AUTHS_"]));
      if (p_param.ContainsKey((object) "su_Supplier") && Convert.ToInt32(p_param[(object) "su_Supplier"].ToString()) > 0)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_Supplier", p_param[(object) "su_Supplier"]));
      else if (p_param.ContainsKey((object) "pay_Supplier") && Convert.ToInt32(p_param[(object) "pay_Supplier"].ToString()) > 0)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_Supplier", p_param[(object) "pay_Supplier"]));
      else if (p_param.ContainsKey((object) "su_Supplier_IN_") && p_param[(object) "su_Supplier_IN_"].ToString().Length > 0)
      {
        if (p_param[(object) "su_Supplier_IN_"].ToString().Contains(","))
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "pay_Supplier", p_param[(object) "su_Supplier_IN_"]));
        else
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_Supplier", p_param[(object) "su_Supplier_IN_"]));
      }
      else if (p_param.ContainsKey((object) "pay_Supplier_IN_") && p_param[(object) "pay_Supplier_IN_"].ToString().Length > 0)
        stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "pay_Supplier", p_param[(object) "pay_Supplier_IN_"]));
      else if (p_param.ContainsKey((object) "_SUPPLIER_AUTHS_") && p_param[(object) "_SUPPLIER_AUTHS_"].ToString().Length > 0)
      {
        if (p_param[(object) "su_Supplier_IN_"].ToString().Contains(","))
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "pay_Supplier", p_param[(object) "su_Supplier_IN_"]));
        else
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_Supplier", p_param[(object) "su_Supplier_IN_"]));
      }
      if (p_param.ContainsKey((object) "pay_ConfirmStatus") && Convert.ToInt32(p_param[(object) "pay_ConfirmStatus"].ToString()) > 0)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_ConfirmStatus", p_param[(object) "pay_ConfirmStatus"]));
      else if (p_param.ContainsKey((object) "pay_ConfirmStatus_IN_") && p_param[(object) "pay_ConfirmStatus_IN_"].ToString().Length > 0)
      {
        if (p_param[(object) "pay_ConfirmStatus_IN_"].ToString().Contains(","))
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "pay_ConfirmStatus", p_param[(object) "pay_ConfirmStatus_IN_"]));
        else
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_ConfirmStatus", p_param[(object) "pay_ConfirmStatus_IN_"]));
      }
      if (p_param.ContainsKey((object) "pay_StatementStatus") && Convert.ToInt32(p_param[(object) "pay_StatementStatus"].ToString()) > 0)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_StatementStatus", p_param[(object) "pay_StatementStatus"]));
      else if (p_param.ContainsKey((object) "pay_StatementStatus_IN_") && p_param[(object) "pay_StatementStatus_IN_"].ToString().Length > 0)
      {
        if (p_param[(object) "pay_StatementStatus_IN_"].ToString().Contains(","))
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "pay_StatementStatus", p_param[(object) "pay_StatementStatus_IN_"]));
        else
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pay_StatementStatus", p_param[(object) "pay_StatementStatus_IN_"]));
      }
      if (p_param.ContainsKey((object) "pd_ConfirmDate"))
      {
        stringBuilder.Append(" AND pd_ConfirmDate >='" + new DateTime?((DateTime) p_param[(object) "pd_ConfirmDate"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
        stringBuilder.Append(" AND pd_ConfirmDate <='" + new DateTime?((DateTime) p_param[(object) "pd_ConfirmDate"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
      }
      if (p_param.ContainsKey((object) "pd_ConfirmDate_BEGIN_") && p_param.ContainsKey((object) "pd_ConfirmDate_END_"))
      {
        stringBuilder.Append(" AND pd_ConfirmDate >='" + new DateTime?((DateTime) p_param[(object) "pd_ConfirmDate_BEGIN_"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
        stringBuilder.Append(" AND pd_ConfirmDate <='" + new DateTime?((DateTime) p_param[(object) "pd_ConfirmDate_END_"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
      }
      if (p_param.ContainsKey((object) "pd_ConfirmStatus") && Convert.ToInt32(p_param[(object) "pd_ConfirmStatus"].ToString()) > 0)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pd_ConfirmStatus", p_param[(object) "pd_ConfirmStatus"]));
      return !stringBuilder.ToString().Equals(" WHERE") ? stringBuilder.Replace("WHERE AND", "WHERE").ToString() : string.Empty;
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
          if (dictionaryEntry.Key.ToString().Equals("paym_SiteID"))
            p_param1.Add((object) "si_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("paym_StoreCode"))
            p_param1.Add((object) "si_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("paym_StoreCode_IN_"))
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
        stringBuilder.Append("\n,T_SUPPLIER AS (SELECT su_Supplier,su_SiteID,su_HeadSupplier,su_SupplierViewCode,su_SupplierName,su_SupplierType,su_SupplierKind,su_UseYn,su_PreTaxDiv,su_MultiSuplierDiv,su_DeductionDayDiv,su_NewStatementYn" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Supplier, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("paym_SiteID"))
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
  }
}
