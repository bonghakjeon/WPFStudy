// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.Supplier.StatementSupplierGoods
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
using UniBiz.Bo.Models.UniStock.Statement.Date;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniStock.Statement.Supplier
{
  public class StatementSupplierGoods : StatementSupplierDate<StatementSupplierGoods>
  {
    private int _dpt_lv1_ID;
    private string _dpt_lv1_ViewCode;
    private string _dpt_lv1_Name;
    private int _dpt_lv2_ID;
    private string _dpt_lv2_ViewCode;
    private string _dpt_lv2_Name;
    private int _dpt_ID;
    private string _dpt_ViewCode;
    private string _dpt_DeptName;
    private int _ctg_lv1_ID;
    private string _ctg_lv1_ViewCode;
    private string _ctg_lv1_Name;
    private int _ctg_lv2_ID;
    private string _ctg_lv2_ViewCode;
    private string _ctg_lv2_Name;
    private string _ctg_ViewCode;
    private string _ctg_CategoryName;
    private string _gd_GoodsName;
    private string _gd_BarCode;
    private string _gd_GoodsSize;
    private string _gd_UseYn;
    private double _gdh_BuyCost;
    private double _gdh_BuyVat;
    private double _gdh_SalePrice;
    private double _gdh_EventCost;
    private double _gdh_EventVat;
    private double _gdh_EventPrice;

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

    public int dpt_ID
    {
      get => this._dpt_ID;
      set
      {
        this._dpt_ID = value;
        this.Changed(nameof (dpt_ID));
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

    public int ctg_lv2_ID
    {
      get => this._ctg_lv2_ID;
      set
      {
        this._ctg_lv2_ID = value;
        this.Changed(nameof (ctg_lv2_ID));
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

    public string ctg_ViewCode
    {
      get => this._ctg_ViewCode;
      set
      {
        this._ctg_ViewCode = value;
        this.Changed(nameof (ctg_ViewCode));
        this.Changed("ctg_lv3_ViewCode");
      }
    }

    public string ctg_lv3_ViewCode => this.ctg_ViewCode;

    public string ctg_CategoryName
    {
      get => this._ctg_CategoryName;
      set
      {
        this._ctg_CategoryName = value;
        this.Changed(nameof (ctg_CategoryName));
        this.Changed("ctg_lv3_Name");
      }
    }

    public string ctg_lv3_Name => this.ctg_CategoryName;

    public string gd_GoodsName
    {
      get => this._gd_GoodsName;
      set
      {
        this._gd_GoodsName = value;
        this.Changed(nameof (gd_GoodsName));
      }
    }

    public string gd_BarCode
    {
      get => this._gd_BarCode;
      set
      {
        this._gd_BarCode = value;
        this.Changed(nameof (gd_BarCode));
      }
    }

    public string gd_GoodsSize
    {
      get => this._gd_GoodsSize;
      set
      {
        this._gd_GoodsSize = value;
        this.Changed(nameof (gd_GoodsSize));
      }
    }

    public string gd_UseYn
    {
      get => this._gd_UseYn;
      set
      {
        this._gd_UseYn = value;
        this.Changed(nameof (gd_UseYn));
        this.Changed("gd_IsUseYn");
        this.Changed("gd_UseYnDesc");
      }
    }

    public bool gd_IsUseYn => "Y".Equals(this.gd_UseYn);

    public string gd_UseYnDesc => !"Y".Equals(this.gd_UseYn) ? "미사용" : "사용";

    public double gdh_BuyCost
    {
      get => this._gdh_BuyCost;
      set
      {
        this._gdh_BuyCost = value;
        this.Changed(nameof (gdh_BuyCost));
      }
    }

    public double gdh_BuyVat
    {
      get => this._gdh_BuyVat;
      set
      {
        this._gdh_BuyVat = value;
        this.Changed(nameof (gdh_BuyVat));
      }
    }

    public double gdh_SalePrice
    {
      get => this._gdh_SalePrice;
      set
      {
        this._gdh_SalePrice = value;
        this.Changed(nameof (gdh_SalePrice));
      }
    }

    public double gdh_EventCost
    {
      get => this._gdh_EventCost;
      set
      {
        this._gdh_EventCost = value;
        this.Changed(nameof (gdh_EventCost));
      }
    }

    public double gdh_EventVat
    {
      get => this._gdh_EventVat;
      set
      {
        this._gdh_EventVat = value;
        this.Changed(nameof (gdh_EventVat));
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
      this.dpt_lv1_ID = 0;
      this.dpt_lv1_ViewCode = string.Empty;
      this.dpt_lv1_Name = string.Empty;
      this.dpt_lv2_ID = 0;
      this.dpt_lv2_ViewCode = string.Empty;
      this.dpt_lv2_Name = string.Empty;
      this.dpt_ID = 0;
      this.dpt_ViewCode = string.Empty;
      this.dpt_DeptName = string.Empty;
      this.ctg_lv1_ID = 0;
      this.ctg_lv1_ViewCode = string.Empty;
      this.ctg_lv1_Name = string.Empty;
      this.ctg_lv2_ID = 0;
      this.ctg_lv2_ViewCode = string.Empty;
      this.ctg_lv2_Name = string.Empty;
      this.ctg_ViewCode = string.Empty;
      this.ctg_CategoryName = string.Empty;
      this.gd_GoodsName = this.gd_BarCode = this.gd_GoodsSize = string.Empty;
      this.gd_UseYn = string.Empty;
      this.gdh_BuyCost = this.gdh_BuyVat = this.gdh_SalePrice = 0.0;
      this.gdh_EventCost = this.gdh_EventVat = this.gdh_EventPrice = 0.0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new StatementSupplierGoods();

    public override object Clone()
    {
      StatementSupplierGoods statementSupplierGoods = base.Clone() as StatementSupplierGoods;
      statementSupplierGoods.dpt_lv1_ID = this.dpt_lv1_ID;
      statementSupplierGoods.dpt_lv1_ViewCode = this.dpt_lv1_ViewCode;
      statementSupplierGoods.dpt_lv1_Name = this.dpt_lv1_Name;
      statementSupplierGoods.dpt_lv2_ID = this.dpt_lv2_ID;
      statementSupplierGoods.dpt_lv2_ViewCode = this.dpt_lv2_ViewCode;
      statementSupplierGoods.dpt_lv2_Name = this.dpt_lv2_Name;
      statementSupplierGoods.dpt_ID = this.dpt_ID;
      statementSupplierGoods.dpt_ViewCode = this.dpt_ViewCode;
      statementSupplierGoods.dpt_DeptName = this.dpt_DeptName;
      statementSupplierGoods.ctg_lv1_ID = this.ctg_lv1_ID;
      statementSupplierGoods.ctg_lv1_ViewCode = this.ctg_lv1_ViewCode;
      statementSupplierGoods.ctg_lv1_Name = this.ctg_lv1_Name;
      statementSupplierGoods.ctg_lv2_ID = this.ctg_lv2_ID;
      statementSupplierGoods.ctg_lv2_ViewCode = this.ctg_lv2_ViewCode;
      statementSupplierGoods.ctg_lv2_Name = this.ctg_lv2_Name;
      statementSupplierGoods.ctg_ViewCode = this.ctg_ViewCode;
      statementSupplierGoods.ctg_CategoryName = this.ctg_CategoryName;
      statementSupplierGoods.gd_GoodsName = this.gd_GoodsName;
      statementSupplierGoods.gd_BarCode = this.gd_BarCode;
      statementSupplierGoods.gd_GoodsSize = this.gd_GoodsSize;
      statementSupplierGoods.gd_UseYn = this.gd_UseYn;
      statementSupplierGoods.gdh_BuyCost = this.gdh_BuyCost;
      statementSupplierGoods.gdh_BuyVat = this.gdh_BuyVat;
      statementSupplierGoods.gdh_SalePrice = this.gdh_SalePrice;
      statementSupplierGoods.gdh_EventCost = this.gdh_EventCost;
      statementSupplierGoods.gdh_EventVat = this.gdh_EventVat;
      statementSupplierGoods.gdh_EventPrice = this.gdh_EventPrice;
      return (object) statementSupplierGoods;
    }

    public void PutData(StatementSupplierGoods pSource)
    {
      this.PutData((StatementSupplierDate) pSource);
      this.dpt_lv1_ID = pSource.dpt_lv1_ID;
      this.dpt_lv1_ViewCode = pSource.dpt_lv1_ViewCode;
      this.dpt_lv1_Name = pSource.dpt_lv1_Name;
      this.dpt_lv2_ID = pSource.dpt_lv2_ID;
      this.dpt_lv2_ViewCode = pSource.dpt_lv2_ViewCode;
      this.dpt_lv2_Name = pSource.dpt_lv2_Name;
      this.dpt_ID = pSource.dpt_ID;
      this.dpt_ViewCode = pSource.dpt_ViewCode;
      this.dpt_DeptName = pSource.dpt_DeptName;
      this.ctg_lv1_ID = pSource.ctg_lv1_ID;
      this.ctg_lv1_ViewCode = pSource.ctg_lv1_ViewCode;
      this.ctg_lv1_Name = pSource.ctg_lv1_Name;
      this.ctg_lv2_ID = pSource.ctg_lv2_ID;
      this.ctg_lv2_ViewCode = pSource.ctg_lv2_ViewCode;
      this.ctg_lv2_Name = pSource.ctg_lv2_Name;
      this.ctg_ViewCode = pSource.ctg_ViewCode;
      this.ctg_CategoryName = pSource.ctg_CategoryName;
      this.gd_GoodsName = pSource.gd_GoodsName;
      this.gd_BarCode = pSource.gd_BarCode;
      this.gd_GoodsSize = pSource.gd_GoodsSize;
      this.gd_UseYn = pSource.gd_UseYn;
      this.gdh_BuyCost = pSource.gdh_BuyCost;
      this.gdh_BuyVat = pSource.gdh_BuyVat;
      this.gdh_SalePrice = pSource.gdh_SalePrice;
      this.gdh_EventCost = pSource.gdh_EventCost;
      this.gdh_EventVat = pSource.gdh_EventVat;
      this.gdh_EventPrice = pSource.gdh_EventPrice;
    }

    public bool IsZero(EnumZeroCheck pCheckType, StatementSupplierGoods pSource) => pSource == null || this.IsZero(pCheckType, (StatementSupplierDate) pSource);

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
        this.dpt_ID = p_rs.GetFieldInt("dpt_ID");
        this.dpt_ViewCode = p_rs.GetFieldString("dpt_ViewCode");
        this.dpt_DeptName = p_rs.GetFieldString("dpt_DeptName");
        this.ctg_lv1_ID = p_rs.GetFieldInt("ctg_lv1_ID");
        this.ctg_lv1_ViewCode = p_rs.GetFieldString("ctg_lv1_ViewCode");
        this.ctg_lv1_Name = p_rs.GetFieldString("ctg_lv1_Name");
        this.ctg_lv2_ID = p_rs.GetFieldInt("ctg_lv2_ID");
        this.ctg_lv2_ViewCode = p_rs.GetFieldString("ctg_lv2_ViewCode");
        this.ctg_lv2_Name = p_rs.GetFieldString("ctg_lv2_Name");
        this.ctg_ViewCode = p_rs.GetFieldString("ctg_ViewCode");
        this.ctg_CategoryName = p_rs.GetFieldString("ctg_CategoryName");
        this.gd_GoodsName = p_rs.GetFieldString("gd_GoodsName");
        this.gd_BarCode = p_rs.GetFieldString("gd_BarCode");
        this.gd_GoodsSize = p_rs.GetFieldString("gd_GoodsSize");
        this.gd_UseYn = p_rs.GetFieldString("gd_UseYn");
        this.gdh_BuyCost = p_rs.GetFieldDouble("gdh_BuyCost");
        this.gdh_BuyVat = p_rs.GetFieldDouble("gdh_BuyVat");
        this.gdh_SalePrice = p_rs.GetFieldDouble("gdh_SalePrice");
        this.gdh_EventCost = p_rs.GetFieldDouble("gdh_EventCost");
        this.gdh_EventVat = p_rs.GetFieldDouble("gdh_EventVat");
        this.gdh_EventPrice = p_rs.GetFieldDouble("gdh_EventPrice");
        if (this.gdh_EventCost.IsZero())
        {
          this.sd_CostGoods = this.gdh_BuyCost;
        }
        else
        {
          this.sd_CostGoods = this.gdh_EventCost;
          this.sd_EventYn = "Y";
        }
        if (this.gdh_EventPrice.IsZero())
        {
          this.sd_PriceGoods = this.gdh_SalePrice;
        }
        else
        {
          this.sd_PriceGoods = this.gdh_EventPrice;
          this.sd_EventYn = "Y";
        }
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public async Task<IList<StatementSupplierGoods>> SelectSupplierGoodsListAsync(object p_param)
    {
      StatementSupplierGoods statementSupplierGoods1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(statementSupplierGoods1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, statementSupplierGoods1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(statementSupplierGoods1.GetSelectQuery(p_param)))
        {
          statementSupplierGoods1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + statementSupplierGoods1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<StatementSupplierGoods>) null;
        }
        IList<StatementSupplierGoods> lt_list = (IList<StatementSupplierGoods>) new List<StatementSupplierGoods>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            StatementSupplierGoods statementSupplierGoods2 = statementSupplierGoods1.OleDB.Create<StatementSupplierGoods>();
            if (statementSupplierGoods2.GetFieldValues(rs))
            {
              statementSupplierGoods2.row_number = lt_list.Count + 1;
              lt_list.Add(statementSupplierGoods2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + statementSupplierGoods1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<StatementSupplierGoods> SelectSupplierGoodsEnumerableAsync(
      object p_param)
    {
      StatementSupplierGoods statementSupplierGoods1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(statementSupplierGoods1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, statementSupplierGoods1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(statementSupplierGoods1.GetSelectQuery(p_param)))
        {
          statementSupplierGoods1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + statementSupplierGoods1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            StatementSupplierGoods statementSupplierGoods2 = statementSupplierGoods1.OleDB.Create<StatementSupplierGoods>();
            if (statementSupplierGoods2.GetFieldValues(rs))
            {
              statementSupplierGoods2.row_number = ++row_number;
              yield return statementSupplierGoods2;
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
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "su_SupplierName", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "su_SupplierViewCode", hashtable[(object) "_KEY_WORD_"]));
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
        this.TableCode.ToString();
        string empty = string.Empty;
        long p_SiteID = 0;
        int p_bgg_GroupID = 0;
        bool p_isStoreTotal = false;
        int num = this.IsGoodsSelect((Hashtable) p_param) ? 1 : 0;
        DateTime? p_day = new DateTime?();
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
          if (hashtable.ContainsKey((object) "sh_ConfirmDate"))
            p_day = new DateTime?((DateTime) hashtable[(object) "sh_ConfirmDate"]);
          if (hashtable.ContainsKey((object) "sh_ConfirmDate_END_"))
            p_day = new DateTime?((DateTime) hashtable[(object) "sh_ConfirmDate_END_"]);
        }
        stringBuilder.Append(this.ToWithStoreQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithSupplierQuery(p_param, uniBase, p_SiteID));
        if (p_bgg_GroupID > 0)
          stringBuilder.Append(this.ToWithBookmarkGoodsQuery(p_param, uniBase, p_SiteID, p_bgg_GroupID));
        stringBuilder.Append(this.ToWithGoodsHistoryQuery(p_param, uniBase, p_SiteID, p_isStoreTotal));
        stringBuilder.Append(this.ToWithGoodsQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithDeptLv1Query(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithDeptLv2Query(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithDeptLv3Query(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithCategoryLv1Query(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithCategoryLv2Query(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithCategoryLv3Query(p_param, uniBase, p_SiteID));
        stringBuilder.Append("\n,T_STATEMENT AS (\nSELECT");
        if (p_isStoreTotal)
          stringBuilder.Append(" 1 AS");
        stringBuilder.Append(" sh_StoreCode");
        stringBuilder.Append(",sh_Supplier");
        stringBuilder.Append(",dpt_lv1_ID,dpt_lv2_ID,dept_code");
        stringBuilder.Append(",ctg_lv1_ID,ctg_lv2_ID,ctg_code");
        stringBuilder.Append(",sd_BoxCode");
        stringBuilder.Append(StatementDateStore.DetailColMaker);
        stringBuilder.Append(string.Format("\n FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) TableCodeType.StatementHeader, (object) DbQueryHelper.ToWithNolock()));
        stringBuilder.Append(string.Format("\n INNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) TableCodeType.StatementDetail, (object) DbQueryHelper.ToWithNolock()) + " ON sh_StatementNo=sd_StatementNo AND sh_SiteID=sd_SiteID" + string.Format(" AND {0}!={1}", (object) "sd_PackUnit", (object) 4) + "\n INNER JOIN T_HISTORY ON sh_StoreCode=gdh_StoreCode AND sd_BoxCode=gdh_GoodsCode AND sh_ConfirmDate>=gdh_StartDate AND sh_ConfirmDate<=gdh_EndDate AND sh_SiteID=gdh_SiteID");
        if (p_bgg_GroupID > 0)
          stringBuilder.Append("\n INNER JOIN T_BOOKMARK_GOODS ON sd_BoxCode=bgl_GoodsCode AND sh_SiteID=bgl_SiteID");
        if (num != 0)
          stringBuilder.Append("\n INNER JOIN T_GOODS ON sd_BoxCode=gd_GoodsCode AND sh_SiteID=gd_SiteID");
        p_param1.Clear();
        p_param1 = this.SearchConditionStatement((Hashtable) p_param);
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "sh_SiteID"))
            p_param1.Add((object) "sh_SiteID", (object) p_SiteID);
          stringBuilder.Append("\n");
          stringBuilder.Append(this.GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format("\n WHERE {0}={1}", (object) "sh_SiteID", (object) p_SiteID));
        stringBuilder.Append("\n GROUP BY ");
        if (!p_isStoreTotal)
          stringBuilder.Append(" sh_StoreCode,");
        stringBuilder.Append(" sh_Supplier");
        stringBuilder.Append(",dpt_lv1_ID,dpt_lv2_ID,dept_code");
        stringBuilder.Append(",ctg_lv1_ID,ctg_lv2_ID,ctg_code");
        stringBuilder.Append(",sd_BoxCode");
        stringBuilder.Append(")");
        stringBuilder.Append("\nSELECT 1 AS sd_StatementNo,0 AS sd_Seq" + string.Format(",{0} AS {1}", (object) p_SiteID, (object) "sd_SiteID") + ",0 AS sd_GoodsCode,sd_BoxCode,gd_BarCode AS sd_BarCode,gdh_GoodsCategory AS sd_CategoryCode,gd_TaxDiv AS sd_TaxDiv,gd_SalesUnit AS sd_SalesUnit,gd_StockUnit AS sd_StockUnit,gd_PackUnit AS sd_PackUnit,0 AS sd_LinkRowNCount,0 AS sd_CostGoods,0 AS sd_PriceGoods,0 AS sd_CostInput,0 AS sd_CostInputVat,'' AS sd_EventYn,0 AS sd_Native,'' AS sd_HistoryID,'' AS sd_Memo,0 AS sd_MobieSeq,NULL AS sd_InDate,0 AS sd_InUser,NULL AS sd_ModDate,0 AS sd_ModUser");
        stringBuilder.Append(StatementDateStore.MainCol);
        stringBuilder.Append("\n,sh_StoreCode,sh_Supplier");
        if (p_isStoreTotal)
          stringBuilder.Append("\n,통합 AS si_StoreName");
        else
          stringBuilder.Append("\n,si_StoreName");
        stringBuilder.Append(",si_StoreViewCode,si_UseYn,si_StoreType");
        stringBuilder.Append("\n,su_SupplierName,su_SupplierViewCode,su_UseYn,su_HeadSupplier,su_SupplierType,su_SupplierKind");
        stringBuilder.Append("\n,T_DEPT_LV1_NAME.dpt_ID AS dpt_lv1_ID,T_DEPT_LV1_NAME.dpt_ViewCode AS dpt_lv1_ViewCode,T_DEPT_LV1_NAME.dpt_DeptName AS dpt_lv1_Name,T_DEPT_LV2_NAME.dpt_ID AS dpt_lv2_ID,T_DEPT_LV2_NAME.dpt_ViewCode AS dpt_lv2_ViewCode,T_DEPT_LV2_NAME.dpt_DeptName AS dpt_lv2_Name,T_DEPT_LV3_NAME.dpt_ID AS dpt_ID,T_DEPT_LV3_NAME.dpt_ViewCode AS dpt_ViewCode,T_DEPT_LV3_NAME.dpt_DeptName AS dpt_DeptName,T_CTG_LV_1_NAME.ctg_ID AS ctg_lv1_ID,T_CTG_LV_1_NAME.ctg_ViewCode AS ctg_lv1_ViewCode,T_CTG_LV_1_NAME.ctg_CategoryName AS ctg_lv1_Name,T_CTG_LV_2_NAME.ctg_ID AS ctg_lv2_ID,T_CTG_LV_2_NAME.ctg_ViewCode AS ctg_lv2_ViewCode,T_CTG_LV_2_NAME.ctg_CategoryName AS ctg_lv2_Name,T_CTG_LV_3_NAME.ctg_ID AS ctg_code,T_CTG_LV_3_NAME.ctg_ViewCode AS ctg_ViewCode,T_CTG_LV_3_NAME.ctg_CategoryName AS ctg_CategoryName,gd_GoodsName,gd_BarCode,gd_GoodsSize,gd_UseYn,gdh_BuyCost,gdh_BuyVat,gdh_SalePrice,gdh_EventCost,gdh_EventVat,gdh_EventPrice");
        stringBuilder.Append("\nFROM (");
        stringBuilder.Append("\nSELECT sh_StoreCode");
        stringBuilder.Append(",sh_Supplier");
        stringBuilder.Append(",dpt_lv1_ID,dpt_lv2_ID,dept_code");
        stringBuilder.Append(",ctg_lv1_ID,ctg_lv2_ID,ctg_code");
        stringBuilder.Append(",sd_BoxCode");
        stringBuilder.Append(StatementDateStore.SubCol);
        stringBuilder.Append("\nFROM (");
        stringBuilder.Append("\nSELECT sh_StoreCode");
        stringBuilder.Append(",sh_Supplier");
        stringBuilder.Append(",dpt_lv1_ID,dpt_lv2_ID,dept_code");
        stringBuilder.Append(",ctg_lv1_ID,ctg_lv2_ID,ctg_code");
        stringBuilder.Append(",sd_BoxCode");
        stringBuilder.Append(StatementDateStore.TStatementCol);
        stringBuilder.Append("\nFROM T_STATEMENT");
        stringBuilder.Append("\n) SUB");
        stringBuilder.Append("\nGROUP BY sh_StoreCode");
        stringBuilder.Append(",sh_Supplier");
        stringBuilder.Append(",dpt_lv1_ID,dpt_lv2_ID,dept_code");
        stringBuilder.Append(",ctg_lv1_ID,ctg_lv2_ID,ctg_code");
        stringBuilder.Append(",sd_BoxCode");
        stringBuilder.Append("\n) MAIN");
        stringBuilder.Append("\nINNER JOIN T_STORE ON sh_StoreCode=si_StoreCode" + string.Format(" AND {0}={1}", (object) "si_SiteID", (object) p_SiteID) + "\n LEFT OUTER JOIN T_DEPT_LV1_NAME ON dpt_lv1_ID=T_DEPT_LV1_NAME.dpt_ID" + string.Format(" AND T_DEPT_LV1_NAME.{0}={1}", (object) "dpt_SiteID", (object) p_SiteID) + "\n LEFT OUTER JOIN T_DEPT_LV2_NAME ON dpt_lv2_ID=T_DEPT_LV2_NAME.dpt_ID" + string.Format(" AND T_DEPT_LV2_NAME.{0}={1}", (object) "dpt_SiteID", (object) p_SiteID) + "\n LEFT OUTER JOIN T_DEPT_LV3_NAME ON dept_code=T_DEPT_LV3_NAME.dpt_ID" + string.Format(" AND T_DEPT_LV3_NAME.{0}={1}", (object) "dpt_SiteID", (object) p_SiteID) + "\n LEFT OUTER JOIN T_CTG_LV_1_NAME ON ctg_lv1_ID=T_CTG_LV_1_NAME.ctg_ID" + string.Format(" AND T_CTG_LV_1_NAME.{0}={1}", (object) "ctg_SiteID", (object) p_SiteID) + "\n LEFT OUTER JOIN T_CTG_LV_2_NAME ON ctg_lv2_ID=T_CTG_LV_2_NAME.ctg_ID" + string.Format(" AND T_CTG_LV_2_NAME.{0}={1}", (object) "ctg_SiteID", (object) p_SiteID) + "\n LEFT OUTER JOIN T_CTG_LV_3_NAME ON ctg_code=T_CTG_LV_3_NAME.ctg_ID" + string.Format(" AND T_CTG_LV_3_NAME.{0}={1}", (object) "ctg_SiteID", (object) p_SiteID) + "\n LEFT OUTER JOIN T_GOODS ON sd_BoxCode=T_GOODS.gd_GoodsCode" + string.Format(" AND T_GOODS.{0}={1}", (object) "gd_SiteID", (object) p_SiteID));
        if (!p_day.HasValue)
          p_day = new DateTime?(DateTime.Now);
        stringBuilder.Append("\n INNER JOIN T_HISTORY ON sh_StoreCode=gdh_StoreCode AND sd_BoxCode=gdh_GoodsCode AND '" + p_day.GetDateToStr("yyyy-MM-dd 00:00:00") + "'>=gdh_StartDate AND '" + p_day.GetDateToStr("yyyy-MM-dd 00:00:00") + "'<=gdh_EndDate" + string.Format(" AND {0}={1}", (object) "gdh_SiteID", (object) p_SiteID) + "\n LEFT OUTER JOIN T_SUPPLIER ON gdh_Supplier=su_Supplier" + string.Format(" AND {0}={1}", (object) "su_SiteID", (object) p_SiteID));
        stringBuilder.Append("\n");
        if (!string.IsNullOrEmpty(empty))
        {
          stringBuilder.Append(" ORDER BY " + empty);
        }
        else
        {
          stringBuilder.Append(" ORDER BY si_StoreViewCode,sh_StoreCode");
          stringBuilder.Append(",su_SupplierType,su_SupplierName,su_SupplierViewCode,su_HeadSupplier");
          stringBuilder.Append(",T_GOODS.gd_BarCode");
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
