// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Profit.ProfitLossWork.TProfitLossWorkCntLog
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

namespace UniBiz.Bo.Models.UniStock.Profit.ProfitLossWork
{
  public class TProfitLossWorkCntLog : UbModelBase<TProfitLossWorkCntLog>
  {
    private DateTime? _plwcl_SysDate;
    private int _plwcl_YyyyMm;
    private int _plwcl_Day;
    private int _plwcl_StoreCode;
    private long _plwcl_SiteID;
    private string _plwcl_ApplyWorkYn;
    private string _plwcl_AmountWorkYn;
    private string _plwcl_QtyWorkYn;
    private string _plwcl_WeightWorkYn;
    private string _plwcl_MinusToZeroWorkYn;
    private string _plwcl_PoorToZeroWorkYn;
    private int _plwcl_EmpCode;

    public override object _Key => (object) new object[4]
    {
      (object) this.plwcl_SysDate,
      (object) this.plwcl_YyyyMm,
      (object) this.plwcl_Day,
      (object) this.plwcl_StoreCode
    };

    public DateTime? plwcl_SysDate
    {
      get => this._plwcl_SysDate;
      set
      {
        this._plwcl_SysDate = value;
        this.Changed(nameof (plwcl_SysDate));
      }
    }

    public int plwcl_YyyyMm
    {
      get => this._plwcl_YyyyMm;
      set
      {
        this._plwcl_YyyyMm = value;
        this.Changed(nameof (plwcl_YyyyMm));
      }
    }

    public int plwcl_Day
    {
      get => this._plwcl_Day;
      set
      {
        this._plwcl_Day = value;
        this.Changed(nameof (plwcl_Day));
      }
    }

    public int plwcl_StoreCode
    {
      get => this._plwcl_StoreCode;
      set
      {
        this._plwcl_StoreCode = value;
        this.Changed(nameof (plwcl_StoreCode));
      }
    }

    public long plwcl_SiteID
    {
      get => this._plwcl_SiteID;
      set
      {
        this._plwcl_SiteID = value;
        this.Changed(nameof (plwcl_SiteID));
      }
    }

    public string plwcl_ApplyWorkYn
    {
      get => this._plwcl_ApplyWorkYn;
      set
      {
        this._plwcl_ApplyWorkYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (plwcl_ApplyWorkYn));
        this.Changed("plwcl_IsApplyWorkYn");
      }
    }

    public bool plwcl_IsApplyWorkYn => "Y".Equals(this.plwcl_ApplyWorkYn);

    public string plwcl_AmountWorkYn
    {
      get => this._plwcl_AmountWorkYn;
      set
      {
        this._plwcl_AmountWorkYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (plwcl_AmountWorkYn));
        this.Changed("plwcl_IsAmountWorkYn");
      }
    }

    public bool plwcl_IsAmountWorkYn => "Y".Equals(this.plwcl_AmountWorkYn);

    public string plwcl_QtyWorkYn
    {
      get => this._plwcl_QtyWorkYn;
      set
      {
        this._plwcl_QtyWorkYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (plwcl_QtyWorkYn));
        this.Changed("plwcl_IsQtyWorkYn");
      }
    }

    public bool plwcl_IsQtyWorkYn => "Y".Equals(this.plwcl_QtyWorkYn);

    public string plwcl_WeightWorkYn
    {
      get => this._plwcl_WeightWorkYn;
      set
      {
        this._plwcl_WeightWorkYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (plwcl_WeightWorkYn));
        this.Changed("plwcl_IsWeightWorkYn");
      }
    }

    public bool plwcl_IsWeightWorkYn => "Y".Equals(this.plwcl_WeightWorkYn);

    public string plwcl_MinusToZeroWorkYn
    {
      get => this._plwcl_MinusToZeroWorkYn;
      set
      {
        this._plwcl_MinusToZeroWorkYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (plwcl_MinusToZeroWorkYn));
        this.Changed("plwcl_IsMinusToZeroWorkYn");
      }
    }

    public bool plwcl_IsMinusToZeroWorkYn => "Y".Equals(this.plwcl_MinusToZeroWorkYn);

    public string plwcl_PoorToZeroWorkYn
    {
      get => this._plwcl_PoorToZeroWorkYn;
      set
      {
        this._plwcl_PoorToZeroWorkYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (plwcl_PoorToZeroWorkYn));
        this.Changed("plwcl_IsPoorToZeroWorkYn");
      }
    }

    public bool plwcl_IsPoorToZeroWorkYn => "Y".Equals(this.plwcl_PoorToZeroWorkYn);

    public int plwcl_EmpCode
    {
      get => this._plwcl_EmpCode;
      set
      {
        this._plwcl_EmpCode = value;
        this.Changed(nameof (plwcl_EmpCode));
      }
    }

    public TProfitLossWorkCntLog() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("plwcl_SysDate", new TTableColumn()
      {
        tc_orgin_name = "plwcl_SysDate",
        tc_trans_name = "작업일시"
      });
      columnInfo.Add("plwcl_YyyyMm", new TTableColumn()
      {
        tc_orgin_name = "plwcl_YyyyMm",
        tc_trans_name = "결산년월"
      });
      columnInfo.Add("plwcl_Day", new TTableColumn()
      {
        tc_orgin_name = "plwcl_Day",
        tc_trans_name = "일자"
      });
      columnInfo.Add("plwcl_StoreCode", new TTableColumn()
      {
        tc_orgin_name = "plwcl_StoreCode",
        tc_trans_name = "지점코드"
      });
      columnInfo.Add("plwcl_SiteID", new TTableColumn()
      {
        tc_orgin_name = "plwcl_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("plwcl_ApplyWorkYn", new TTableColumn()
      {
        tc_orgin_name = "plwcl_ApplyWorkYn",
        tc_trans_name = "재고 조정 여부"
      });
      columnInfo.Add("plwcl_AmountWorkYn", new TTableColumn()
      {
        tc_orgin_name = "plwcl_AmountWorkYn",
        tc_trans_name = "금액 여부"
      });
      columnInfo.Add("plwcl_QtyWorkYn", new TTableColumn()
      {
        tc_orgin_name = "plwcl_QtyWorkYn",
        tc_trans_name = "수량 여부"
      });
      columnInfo.Add("plwcl_WeightWorkYn", new TTableColumn()
      {
        tc_orgin_name = "plwcl_WeightWorkYn",
        tc_trans_name = "중량 여부"
      });
      columnInfo.Add("plwcl_MinusToZeroWorkYn", new TTableColumn()
      {
        tc_orgin_name = "plwcl_MinusToZeroWorkYn",
        tc_trans_name = "마이너스 재고 0 처리 여부"
      });
      columnInfo.Add("plwcl_PoorToZeroWorkYn", new TTableColumn()
      {
        tc_orgin_name = "plwcl_PoorToZeroWorkYn",
        tc_trans_name = "불량재고 0 처리 여부"
      });
      columnInfo.Add("plwcl_EmpCode", new TTableColumn()
      {
        tc_orgin_name = "plwcl_EmpCode",
        tc_trans_name = "사원코드"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.ProfitLossWorkCntLog;
      this.plwcl_SysDate = new DateTime?();
      this.plwcl_YyyyMm = this.plwcl_Day = this.plwcl_StoreCode = 0;
      this.plwcl_SiteID = 0L;
      this.plwcl_ApplyWorkYn = "N";
      this.plwcl_AmountWorkYn = "N";
      this.plwcl_QtyWorkYn = "N";
      this.plwcl_WeightWorkYn = "N";
      this.plwcl_MinusToZeroWorkYn = "N";
      this.plwcl_PoorToZeroWorkYn = "N";
      this.plwcl_EmpCode = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TProfitLossWorkCntLog();

    public override object Clone()
    {
      TProfitLossWorkCntLog tprofitLossWorkCntLog = base.Clone() as TProfitLossWorkCntLog;
      tprofitLossWorkCntLog.plwcl_SysDate = this.plwcl_SysDate;
      tprofitLossWorkCntLog.plwcl_YyyyMm = this.plwcl_YyyyMm;
      tprofitLossWorkCntLog.plwcl_Day = this.plwcl_Day;
      tprofitLossWorkCntLog.plwcl_StoreCode = this.plwcl_StoreCode;
      tprofitLossWorkCntLog.plwcl_SiteID = this.plwcl_SiteID;
      tprofitLossWorkCntLog.plwcl_ApplyWorkYn = this.plwcl_ApplyWorkYn;
      tprofitLossWorkCntLog.plwcl_AmountWorkYn = this.plwcl_AmountWorkYn;
      tprofitLossWorkCntLog.plwcl_QtyWorkYn = this.plwcl_QtyWorkYn;
      tprofitLossWorkCntLog.plwcl_WeightWorkYn = this.plwcl_WeightWorkYn;
      tprofitLossWorkCntLog.plwcl_MinusToZeroWorkYn = this.plwcl_MinusToZeroWorkYn;
      tprofitLossWorkCntLog.plwcl_PoorToZeroWorkYn = this.plwcl_PoorToZeroWorkYn;
      tprofitLossWorkCntLog.plwcl_EmpCode = this.plwcl_EmpCode;
      return (object) tprofitLossWorkCntLog;
    }

    public void PutData(TProfitLossWorkCntLog pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.plwcl_SysDate = pSource.plwcl_SysDate;
      this.plwcl_YyyyMm = pSource.plwcl_YyyyMm;
      this.plwcl_Day = pSource.plwcl_Day;
      this.plwcl_StoreCode = pSource.plwcl_StoreCode;
      this.plwcl_SiteID = pSource.plwcl_SiteID;
      this.plwcl_ApplyWorkYn = pSource.plwcl_ApplyWorkYn;
      this.plwcl_AmountWorkYn = pSource.plwcl_AmountWorkYn;
      this.plwcl_QtyWorkYn = pSource.plwcl_QtyWorkYn;
      this.plwcl_WeightWorkYn = pSource.plwcl_WeightWorkYn;
      this.plwcl_MinusToZeroWorkYn = pSource.plwcl_MinusToZeroWorkYn;
      this.plwcl_PoorToZeroWorkYn = pSource.plwcl_PoorToZeroWorkYn;
      this.plwcl_EmpCode = pSource.plwcl_EmpCode;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.plwcl_SysDate = p_rs.GetFieldDateTime("plwcl_SysDate");
        this.plwcl_YyyyMm = p_rs.GetFieldInt("plwcl_YyyyMm");
        this.plwcl_Day = p_rs.GetFieldInt("plwcl_Day");
        this.plwcl_StoreCode = p_rs.GetFieldInt("plwcl_StoreCode");
        if (this.plwcl_StoreCode == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.plwcl_SiteID = p_rs.GetFieldLong("plwcl_SiteID");
        this.plwcl_ApplyWorkYn = p_rs.GetFieldString("plwcl_ApplyWorkYn");
        this.plwcl_AmountWorkYn = p_rs.GetFieldString("plwcl_AmountWorkYn");
        this.plwcl_QtyWorkYn = p_rs.GetFieldString("plwcl_QtyWorkYn");
        this.plwcl_WeightWorkYn = p_rs.GetFieldString("plwcl_WeightWorkYn");
        this.plwcl_MinusToZeroWorkYn = p_rs.GetFieldString("plwcl_MinusToZeroWorkYn");
        this.plwcl_PoorToZeroWorkYn = p_rs.GetFieldString("plwcl_PoorToZeroWorkYn");
        this.plwcl_EmpCode = p_rs.GetFieldInt("plwcl_EmpCode");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) this.TableCode) + " plwcl_SysDate,plwcl_YyyyMm,plwcl_Day,plwcl_StoreCode,plwcl_SiteID,plwcl_ApplyWorkYn,plwcl_AmountWorkYn,plwcl_QtyWorkYn,plwcl_WeightWorkYn,plwcl_MinusToZeroWorkYn,plwcl_PoorToZeroWorkYn,plwcl_EmpCode) VALUES (  " + this.plwcl_SysDate.GetDateToStrInNull() + string.Format(",{0},{1},{2}", (object) this.plwcl_YyyyMm, (object) this.plwcl_Day, (object) this.plwcl_StoreCode) + string.Format(",{0}", (object) this.plwcl_SiteID) + ",'" + this.plwcl_ApplyWorkYn + "','" + this.plwcl_AmountWorkYn + "','" + this.plwcl_QtyWorkYn + "','" + this.plwcl_WeightWorkYn + "','" + this.plwcl_MinusToZeroWorkYn + "','" + this.plwcl_PoorToZeroWorkYn + "'" + string.Format(",{0}", (object) this.plwcl_EmpCode) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3},{4})\n", (object) this.plwcl_SysDate, (object) this.plwcl_YyyyMm, (object) this.plwcl_Day, (object) this.plwcl_StoreCode, (object) this.plwcl_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TProfitLossWorkCntLog tprofitLossWorkCntLog = this;
      // ISSUE: reference to a compiler-generated method
      tprofitLossWorkCntLog.\u003C\u003En__0();
      if (await tprofitLossWorkCntLog.OleDB.ExecuteAsync(tprofitLossWorkCntLog.InsertQuery()))
        return true;
      tprofitLossWorkCntLog.message = " " + tprofitLossWorkCntLog.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tprofitLossWorkCntLog.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tprofitLossWorkCntLog.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3},{4})\n", (object) tprofitLossWorkCntLog.plwcl_SysDate, (object) tprofitLossWorkCntLog.plwcl_YyyyMm, (object) tprofitLossWorkCntLog.plwcl_Day, (object) tprofitLossWorkCntLog.plwcl_StoreCode, (object) tprofitLossWorkCntLog.plwcl_SiteID) + " 내용 : " + tprofitLossWorkCntLog.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tprofitLossWorkCntLog.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "plwcl_SiteID") && Convert.ToInt64(hashtable[(object) "plwcl_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "plwcl_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "plwcl_SysDate"))
          stringBuilder.Append(" AND plwcl_SysDate = '" + new DateTime?((DateTime) hashtable[(object) "plwcl_SysDate"]).GetDateToStr() + "'");
        if (hashtable.ContainsKey((object) "plwcl_YyyyMm") && Convert.ToInt32(hashtable[(object) "plwcl_YyyyMm"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "plwcl_YyyyMm", hashtable[(object) "plwcl_YyyyMm"]));
        if (hashtable.ContainsKey((object) "plwcl_YyyyMm_BEGIN_") && hashtable.ContainsKey((object) "plwcl_YyyyMm_END_"))
        {
          stringBuilder.Append(string.Format(" AND {0} >= {1}", (object) "plwcl_YyyyMm", (object) Convert.ToInt32(hashtable[(object) "plwcl_YyyyMm_BEGIN_"].ToString())));
          stringBuilder.Append(string.Format(" AND {0} <= {1}", (object) "plwcl_YyyyMm", (object) Convert.ToInt32(hashtable[(object) "plwcl_YyyyMm_END_"].ToString())));
        }
        if (hashtable.ContainsKey((object) "plwcl_YyyyMm_NEXT_") && Convert.ToInt32(hashtable[(object) "plwcl_YyyyMm_NEXT_"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}>={1}", (object) "plwcl_YyyyMm", hashtable[(object) "plwcl_YyyyMm"]));
        if (hashtable.ContainsKey((object) "plwcl_Day") && Convert.ToInt32(hashtable[(object) "plwcl_Day"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "plwcl_Day", hashtable[(object) "plwcl_Day"]));
        if (hashtable.ContainsKey((object) "_DT_DATE_"))
        {
          string dateToStr = new DateTime?((DateTime) hashtable[(object) "_DT_DATE_"]).GetDateToStr("yyyyMMdd");
          stringBuilder.Append(" AND plwcl_YyyyMm = " + dateToStr.ToLeft(6));
          stringBuilder.Append(" AND plwcl_Day = " + dateToStr.ToRight(2));
        }
        if (hashtable.ContainsKey((object) "si_StoreCode") && Convert.ToInt32(hashtable[(object) "si_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "plwcl_StoreCode", hashtable[(object) "si_StoreCode"]));
        else if (hashtable.ContainsKey((object) "plwcl_StoreCode") && Convert.ToInt32(hashtable[(object) "plwcl_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "plwcl_StoreCode", hashtable[(object) "plwcl_StoreCode"]));
        else if (hashtable.ContainsKey((object) "si_StoreCode_IN_") && hashtable[(object) "si_StoreCode_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "plwcl_StoreCode", hashtable[(object) "si_StoreCode_IN_"]));
        else if (hashtable.ContainsKey((object) "plwcl_StoreCode_IN_") && hashtable[(object) "plwcl_StoreCode_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "plwcl_StoreCode", hashtable[(object) "plwcl_StoreCode_IN_"]));
        else if (hashtable.ContainsKey((object) "_STORE_AUTHS_") && hashtable[(object) "_STORE_AUTHS_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "plwcl_StoreCode", hashtable[(object) "_STORE_AUTHS_"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "plwcl_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "plwcl_ApplyWorkYn") && hashtable[(object) "plwcl_ApplyWorkYn"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "plwcl_ApplyWorkYn", hashtable[(object) "plwcl_ApplyWorkYn"]));
        if (hashtable.ContainsKey((object) "plwcl_AmountWorkYn") && hashtable[(object) "plwcl_AmountWorkYn"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "plwcl_AmountWorkYn", hashtable[(object) "plwcl_AmountWorkYn"]));
        if (hashtable.ContainsKey((object) "plwcl_QtyWorkYn") && hashtable[(object) "plwcl_QtyWorkYn"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "plwcl_QtyWorkYn", hashtable[(object) "plwcl_QtyWorkYn"]));
        if (hashtable.ContainsKey((object) "plwcl_WeightWorkYn") && hashtable[(object) "plwcl_WeightWorkYn"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "plwcl_WeightWorkYn", hashtable[(object) "plwcl_WeightWorkYn"]));
        if (hashtable.ContainsKey((object) "plwcl_MinusToZeroWorkYn") && hashtable[(object) "plwcl_MinusToZeroWorkYn"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "plwcl_MinusToZeroWorkYn", hashtable[(object) "plwcl_MinusToZeroWorkYn"]));
        if (hashtable.ContainsKey((object) "plwcl_PoorToZeroWorkYn") && hashtable[(object) "plwcl_PoorToZeroWorkYn"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "plwcl_PoorToZeroWorkYn", hashtable[(object) "plwcl_PoorToZeroWorkYn"]));
        if (hashtable.ContainsKey((object) "plwcl_EmpCode") && Convert.ToInt32(hashtable[(object) "plwcl_EmpCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "plwcl_EmpCode", hashtable[(object) "plwcl_EmpCode"]));
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
        stringBuilder.Append(" SELECT  plwcl_SysDate,plwcl_YyyyMm,plwcl_Day,plwcl_StoreCode,plwcl_SiteID,plwcl_ApplyWorkYn,plwcl_AmountWorkYn,plwcl_QtyWorkYn,plwcl_WeightWorkYn,plwcl_MinusToZeroWorkYn,plwcl_PoorToZeroWorkYn,plwcl_EmpCode");
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
  }
}
