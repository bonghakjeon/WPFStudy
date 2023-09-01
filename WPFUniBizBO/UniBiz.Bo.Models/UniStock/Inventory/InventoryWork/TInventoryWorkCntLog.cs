// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Inventory.InventoryWork.TInventoryWorkCntLog
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
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniStock.Inventory.InventoryWork
{
  public class TInventoryWorkCntLog : UbModelBase<TInventoryWorkCntLog>
  {
    private DateTime? _iwcl_SysDate;
    private DateTime? _iwcl_InventoryDate;
    private int _iwcl_StoreCode;
    private long _iwcl_SiteID;
    private string _iwcl_AmountWorkYn;
    private string _iwcl_QtyWorkYn;
    private string _iwcl_WeightWorkYn;
    private string _iwcl_AllWorkYn;
    private string _iwcl_MinusToZeroWorkYn;
    private string _iwcl_PoorToZeroWorkYn;
    private string _iwcl_UnRegToZeroWorkYn;
    private int _iwcl_EmpCode;

    public override object _Key => (object) new object[3]
    {
      (object) this.iwcl_SysDate,
      (object) this.iwcl_InventoryDate,
      (object) this.iwcl_StoreCode
    };

    public DateTime? iwcl_SysDate
    {
      get => this._iwcl_SysDate;
      set
      {
        this._iwcl_SysDate = value;
        this.Changed(nameof (iwcl_SysDate));
      }
    }

    public DateTime? iwcl_InventoryDate
    {
      get => this._iwcl_InventoryDate;
      set
      {
        this._iwcl_InventoryDate = value;
        this.Changed(nameof (iwcl_InventoryDate));
        this.Changed("iwcl_InventoryDateInt");
      }
    }

    [JsonIgnore]
    public int iwcl_InventoryDateInt => this.iwcl_InventoryDate.HasValue ? this.iwcl_InventoryDate.Value.ToIntFormat() : 0;

    public int iwcl_StoreCode
    {
      get => this._iwcl_StoreCode;
      set
      {
        this._iwcl_StoreCode = value;
        this.Changed(nameof (iwcl_StoreCode));
      }
    }

    public long iwcl_SiteID
    {
      get => this._iwcl_SiteID;
      set
      {
        this._iwcl_SiteID = value;
        this.Changed(nameof (iwcl_SiteID));
      }
    }

    public string iwcl_AmountWorkYn
    {
      get => this._iwcl_AmountWorkYn;
      set
      {
        this._iwcl_AmountWorkYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (iwcl_AmountWorkYn));
        this.Changed("iwcl_IsAmountWorkYn");
      }
    }

    public bool iwcl_IsAmountWorkYn => "Y".Equals(this.iwcl_AmountWorkYn);

    public string iwcl_QtyWorkYn
    {
      get => this._iwcl_QtyWorkYn;
      set
      {
        this._iwcl_QtyWorkYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (iwcl_QtyWorkYn));
        this.Changed("iwcl_IsQtyWorkYn");
      }
    }

    public bool iwcl_IsQtyWorkYn => "Y".Equals(this.iwcl_QtyWorkYn);

    public string iwcl_WeightWorkYn
    {
      get => this._iwcl_WeightWorkYn;
      set
      {
        this._iwcl_WeightWorkYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (iwcl_WeightWorkYn));
        this.Changed("iwcl_IsWeightWorkYn");
      }
    }

    public bool iwcl_IsWeightWorkYn => "Y".Equals(this.iwcl_WeightWorkYn);

    public string iwcl_AllWorkYn
    {
      get => this._iwcl_AllWorkYn;
      set
      {
        this._iwcl_AllWorkYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (iwcl_AllWorkYn));
        this.Changed("iwcl_IsAllWorkYn");
      }
    }

    public bool iwcl_IsAllWorkYn => "Y".Equals(this.iwcl_AllWorkYn);

    public string iwcl_MinusToZeroWorkYn
    {
      get => this._iwcl_MinusToZeroWorkYn;
      set
      {
        this._iwcl_MinusToZeroWorkYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (iwcl_MinusToZeroWorkYn));
        this.Changed("iwcl_IsMinusToZeroWorkYn");
      }
    }

    public bool iwcl_IsMinusToZeroWorkYn => "Y".Equals(this.iwcl_MinusToZeroWorkYn);

    public string iwcl_PoorToZeroWorkYn
    {
      get => this._iwcl_PoorToZeroWorkYn;
      set
      {
        this._iwcl_PoorToZeroWorkYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (iwcl_PoorToZeroWorkYn));
        this.Changed("iwcl_IsPoorToZeroWorkYn");
      }
    }

    public bool iwcl_IsPoorToZeroWorkYn => "Y".Equals(this.iwcl_PoorToZeroWorkYn);

    public string iwcl_UnRegToZeroWorkYn
    {
      get => this._iwcl_UnRegToZeroWorkYn;
      set
      {
        this._iwcl_UnRegToZeroWorkYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (iwcl_UnRegToZeroWorkYn));
        this.Changed("iwcl_IsUnRegToZeroWorkYn");
      }
    }

    public bool iwcl_IsUnRegToZeroWorkYn => "Y".Equals(this.iwcl_UnRegToZeroWorkYn);

    public int iwcl_EmpCode
    {
      get => this._iwcl_EmpCode;
      set
      {
        this._iwcl_EmpCode = value;
        this.Changed(nameof (iwcl_EmpCode));
      }
    }

    public TInventoryWorkCntLog() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("iwcl_SysDate", new TTableColumn()
      {
        tc_orgin_name = "iwcl_SysDate",
        tc_trans_name = "작업일시"
      });
      columnInfo.Add("iwcl_InventoryDate", new TTableColumn()
      {
        tc_orgin_name = "iwcl_InventoryDate",
        tc_trans_name = "재고조사일자"
      });
      columnInfo.Add("iwcl_StoreCode", new TTableColumn()
      {
        tc_orgin_name = "iwcl_StoreCode",
        tc_trans_name = "지점코드"
      });
      columnInfo.Add("iwcl_SiteID", new TTableColumn()
      {
        tc_orgin_name = "iwcl_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("iwcl_AmountWorkYn", new TTableColumn()
      {
        tc_orgin_name = "iwcl_AmountWorkYn",
        tc_trans_name = "금액 작업 여부"
      });
      columnInfo.Add("iwcl_QtyWorkYn", new TTableColumn()
      {
        tc_orgin_name = "iwcl_QtyWorkYn",
        tc_trans_name = "수량 작업 여부"
      });
      columnInfo.Add("iwcl_WeightWorkYn", new TTableColumn()
      {
        tc_orgin_name = "iwcl_WeightWorkYn",
        tc_trans_name = "중량 작업 여부"
      });
      columnInfo.Add("iwcl_AllWorkYn", new TTableColumn()
      {
        tc_orgin_name = "iwcl_AllWorkYn",
        tc_trans_name = "전체 재고조사 여부"
      });
      columnInfo.Add("iwcl_MinusToZeroWorkYn", new TTableColumn()
      {
        tc_orgin_name = "iwcl_MinusToZeroWorkYn",
        tc_trans_name = "마이너스 재고 0 처리 여부"
      });
      columnInfo.Add("iwcl_PoorToZeroWorkYn", new TTableColumn()
      {
        tc_orgin_name = "iwcl_PoorToZeroWorkYn",
        tc_trans_name = "불량재고 0 처리여부"
      });
      columnInfo.Add("iwcl_UnRegToZeroWorkYn", new TTableColumn()
      {
        tc_orgin_name = "iwcl_UnRegToZeroWorkYn",
        tc_trans_name = "미등록 로케이션 0 처리여부"
      });
      columnInfo.Add("iwcl_EmpCode", new TTableColumn()
      {
        tc_orgin_name = "iwcl_EmpCode",
        tc_trans_name = "사원코드"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.InventoryWorkCntLog;
      this.iwcl_SysDate = new DateTime?();
      this.iwcl_InventoryDate = new DateTime?();
      this.iwcl_StoreCode = 0;
      this.iwcl_SiteID = 0L;
      this.iwcl_AmountWorkYn = "N";
      this.iwcl_QtyWorkYn = "N";
      this.iwcl_WeightWorkYn = "N";
      this.iwcl_AllWorkYn = "N";
      this.iwcl_MinusToZeroWorkYn = "N";
      this.iwcl_PoorToZeroWorkYn = "N";
      this.iwcl_UnRegToZeroWorkYn = "N";
      this.iwcl_EmpCode = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TInventoryWorkCntLog();

    public override object Clone()
    {
      TInventoryWorkCntLog tinventoryWorkCntLog = base.Clone() as TInventoryWorkCntLog;
      tinventoryWorkCntLog.iwcl_SysDate = this.iwcl_SysDate;
      tinventoryWorkCntLog.iwcl_InventoryDate = this.iwcl_InventoryDate;
      tinventoryWorkCntLog.iwcl_StoreCode = this.iwcl_StoreCode;
      tinventoryWorkCntLog.iwcl_SiteID = this.iwcl_SiteID;
      tinventoryWorkCntLog.iwcl_AmountWorkYn = this.iwcl_AmountWorkYn;
      tinventoryWorkCntLog.iwcl_QtyWorkYn = this.iwcl_QtyWorkYn;
      tinventoryWorkCntLog.iwcl_WeightWorkYn = this.iwcl_WeightWorkYn;
      tinventoryWorkCntLog.iwcl_AllWorkYn = this.iwcl_AllWorkYn;
      tinventoryWorkCntLog.iwcl_MinusToZeroWorkYn = this.iwcl_MinusToZeroWorkYn;
      tinventoryWorkCntLog.iwcl_PoorToZeroWorkYn = this.iwcl_PoorToZeroWorkYn;
      tinventoryWorkCntLog.iwcl_UnRegToZeroWorkYn = this.iwcl_UnRegToZeroWorkYn;
      tinventoryWorkCntLog.iwcl_EmpCode = this.iwcl_EmpCode;
      return (object) tinventoryWorkCntLog;
    }

    public void PutData(TInventoryWorkCntLog pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.iwcl_SysDate = pSource.iwcl_SysDate;
      this.iwcl_InventoryDate = pSource.iwcl_InventoryDate;
      this.iwcl_StoreCode = pSource.iwcl_StoreCode;
      this.iwcl_SiteID = pSource.iwcl_SiteID;
      this.iwcl_AmountWorkYn = pSource.iwcl_AmountWorkYn;
      this.iwcl_QtyWorkYn = pSource.iwcl_QtyWorkYn;
      this.iwcl_WeightWorkYn = pSource.iwcl_WeightWorkYn;
      this.iwcl_AllWorkYn = pSource.iwcl_AllWorkYn;
      this.iwcl_MinusToZeroWorkYn = pSource.iwcl_MinusToZeroWorkYn;
      this.iwcl_PoorToZeroWorkYn = pSource.iwcl_PoorToZeroWorkYn;
      this.iwcl_UnRegToZeroWorkYn = pSource.iwcl_UnRegToZeroWorkYn;
      this.iwcl_EmpCode = pSource.iwcl_EmpCode;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.iwcl_SysDate = p_rs.GetFieldDateTime("iwcl_SysDate");
        this.iwcl_InventoryDate = p_rs.GetFieldDateTime("iwcl_InventoryDate");
        this.iwcl_StoreCode = p_rs.GetFieldInt("iwcl_StoreCode");
        if (this.iwcl_StoreCode == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.iwcl_SiteID = p_rs.GetFieldLong("iwcl_SiteID");
        this.iwcl_AmountWorkYn = p_rs.GetFieldString("iwcl_AmountWorkYn");
        this.iwcl_QtyWorkYn = p_rs.GetFieldString("iwcl_QtyWorkYn");
        this.iwcl_WeightWorkYn = p_rs.GetFieldString("iwcl_WeightWorkYn");
        this.iwcl_AllWorkYn = p_rs.GetFieldString("iwcl_AllWorkYn");
        this.iwcl_MinusToZeroWorkYn = p_rs.GetFieldString("iwcl_MinusToZeroWorkYn");
        this.iwcl_PoorToZeroWorkYn = p_rs.GetFieldString("iwcl_PoorToZeroWorkYn");
        this.iwcl_UnRegToZeroWorkYn = p_rs.GetFieldString("iwcl_UnRegToZeroWorkYn");
        this.iwcl_EmpCode = p_rs.GetFieldInt("iwcl_EmpCode");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) this.TableCode) + " iwcl_SysDate,iwcl_InventoryDate,iwcl_StoreCode,iwcl_SiteID,iwcl_AmountWorkYn,iwcl_QtyWorkYn,iwcl_WeightWorkYn,iwcl_AllWorkYn,iwcl_MinusToZeroWorkYn,iwcl_PoorToZeroWorkYn,iwcl_UnRegToZeroWorkYn,iwcl_EmpCode) VALUES (  " + this.iwcl_SysDate.GetDateToStrInNull() + string.Format(",'{0}',{1}", (object) this.iwcl_InventoryDate.GetDateToStr("yyyy-MM-dd 00:00:00"), (object) this.iwcl_StoreCode) + string.Format(",{0}", (object) this.iwcl_SiteID) + ",'" + this.iwcl_AmountWorkYn + "','" + this.iwcl_QtyWorkYn + "','" + this.iwcl_WeightWorkYn + "','" + this.iwcl_AllWorkYn + "','" + this.iwcl_MinusToZeroWorkYn + "','" + this.iwcl_PoorToZeroWorkYn + "','" + this.iwcl_UnRegToZeroWorkYn + "'" + string.Format(",{0}", (object) this.iwcl_EmpCode) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.iwcl_SysDate.GetDateToStrInNull(), (object) this.iwcl_InventoryDate.GetDateToStr("yyyy-MM-dd"), (object) this.iwcl_StoreCode, (object) this.iwcl_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TInventoryWorkCntLog tinventoryWorkCntLog = this;
      // ISSUE: reference to a compiler-generated method
      tinventoryWorkCntLog.\u003C\u003En__0();
      if (await tinventoryWorkCntLog.OleDB.ExecuteAsync(tinventoryWorkCntLog.InsertQuery()))
        return true;
      tinventoryWorkCntLog.message = " " + tinventoryWorkCntLog.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tinventoryWorkCntLog.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tinventoryWorkCntLog.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tinventoryWorkCntLog.iwcl_SysDate.GetDateToStrInNull(), (object) tinventoryWorkCntLog.iwcl_InventoryDate.GetDateToStr("yyyy-MM-dd"), (object) tinventoryWorkCntLog.iwcl_StoreCode, (object) tinventoryWorkCntLog.iwcl_SiteID) + " 내용 : " + tinventoryWorkCntLog.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tinventoryWorkCntLog.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "iwcl_SiteID") && Convert.ToInt64(hashtable[(object) "iwcl_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "iwcl_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "iwcl_SysDate"))
          stringBuilder.Append(" AND iwcl_SysDate = '" + new DateTime?((DateTime) hashtable[(object) "iwcl_SysDate"]).GetDateToStr() + "'");
        if (hashtable.ContainsKey((object) "iwcl_InventoryDate"))
        {
          stringBuilder.Append(" AND iwcl_InventoryDate >='" + new DateTime?((DateTime) hashtable[(object) "iwcl_InventoryDate"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND iwcl_InventoryDate <='" + new DateTime?((DateTime) hashtable[(object) "iwcl_InventoryDate"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
        }
        if (hashtable.ContainsKey((object) "iwcl_InventoryDate_BEGIN_") && hashtable.ContainsKey((object) "iwcl_InventoryDate_END_"))
        {
          stringBuilder.Append(" AND iwcl_InventoryDate >='" + new DateTime?((DateTime) hashtable[(object) "iwcl_InventoryDate_BEGIN_"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND iwcl_InventoryDate <='" + new DateTime?((DateTime) hashtable[(object) "iwcl_InventoryDate_END_"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
        }
        if (hashtable.ContainsKey((object) "si_StoreCode") && Convert.ToInt32(hashtable[(object) "si_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "iwcl_StoreCode", hashtable[(object) "si_StoreCode"]));
        else if (hashtable.ContainsKey((object) "iwcl_StoreCode") && Convert.ToInt32(hashtable[(object) "iwcl_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "iwcl_StoreCode", hashtable[(object) "iwcl_StoreCode"]));
        else if (hashtable.ContainsKey((object) "si_StoreCode_IN_") && hashtable[(object) "si_StoreCode_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "iwcl_StoreCode", hashtable[(object) "si_StoreCode_IN_"]));
        else if (hashtable.ContainsKey((object) "iwcl_StoreCode_IN_") && hashtable[(object) "iwcl_StoreCode_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "iwcl_StoreCode", hashtable[(object) "iwcl_StoreCode_IN_"]));
        else if (hashtable.ContainsKey((object) "_STORE_AUTHS_") && hashtable[(object) "_STORE_AUTHS_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "iwcl_StoreCode", hashtable[(object) "_STORE_AUTHS_"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "iwcl_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "iwcl_AmountWorkYn") && hashtable[(object) "iwcl_AmountWorkYn"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "iwcl_AmountWorkYn", hashtable[(object) "iwcl_AmountWorkYn"]));
        if (hashtable.ContainsKey((object) "iwcl_QtyWorkYn") && hashtable[(object) "iwcl_QtyWorkYn"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "iwcl_QtyWorkYn", hashtable[(object) "iwcl_QtyWorkYn"]));
        if (hashtable.ContainsKey((object) "iwcl_WeightWorkYn") && hashtable[(object) "iwcl_WeightWorkYn"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "iwcl_WeightWorkYn", hashtable[(object) "iwcl_WeightWorkYn"]));
        if (hashtable.ContainsKey((object) "iwcl_AllWorkYn") && hashtable[(object) "iwcl_AllWorkYn"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "iwcl_AllWorkYn", hashtable[(object) "iwcl_AllWorkYn"]));
        if (hashtable.ContainsKey((object) "iwcl_MinusToZeroWorkYn") && hashtable[(object) "iwcl_MinusToZeroWorkYn"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "iwcl_MinusToZeroWorkYn", hashtable[(object) "iwcl_MinusToZeroWorkYn"]));
        if (hashtable.ContainsKey((object) "iwcl_PoorToZeroWorkYn") && hashtable[(object) "iwcl_PoorToZeroWorkYn"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "iwcl_PoorToZeroWorkYn", hashtable[(object) "iwcl_PoorToZeroWorkYn"]));
        if (hashtable.ContainsKey((object) "iwcl_UnRegToZeroWorkYn") && hashtable[(object) "iwcl_UnRegToZeroWorkYn"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "iwcl_UnRegToZeroWorkYn", hashtable[(object) "iwcl_UnRegToZeroWorkYn"]));
        if (hashtable.ContainsKey((object) "iwcl_EmpCode") && Convert.ToInt32(hashtable[(object) "iwcl_EmpCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "iwcl_EmpCode", hashtable[(object) "iwcl_EmpCode"]));
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
        stringBuilder.Append(" SELECT  iwcl_SysDate,iwcl_InventoryDate,iwcl_StoreCode,iwcl_SiteID,iwcl_AmountWorkYn,iwcl_QtyWorkYn,iwcl_WeightWorkYn,iwcl_AllWorkYn,iwcl_MinusToZeroWorkYn,iwcl_PoorToZeroWorkYn,iwcl_UnRegToZeroWorkYn,iwcl_EmpCode");
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
