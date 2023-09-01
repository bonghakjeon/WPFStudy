// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Supplier.RebateConditionHeader.TRebateConditionHeader
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

namespace UniBiz.Bo.Models.UniBase.Supplier.RebateConditionHeader
{
  public class TRebateConditionHeader : UbModelBase<TRebateConditionHeader>
  {
    private int _rch_StoreCode;
    private int _rch_Supplier;
    private long _rch_SiteID;
    private DateTime? _rch_ContractDate;
    private int _rch_CalcPeriodType;
    private int _rch_StdAmtType;
    private string _rch_UseYn;
    private int _rch_AddProperty;
    private DateTime? _rch_InDate;
    private int _rch_InUser;
    private DateTime? _rch_ModDate;
    private int _rch_ModUser;

    public override object _Key => (object) new object[2]
    {
      (object) this.rch_StoreCode,
      (object) this.rch_Supplier
    };

    public int rch_StoreCode
    {
      get => this._rch_StoreCode;
      set
      {
        this._rch_StoreCode = value;
        this.Changed(nameof (rch_StoreCode));
      }
    }

    public int rch_Supplier
    {
      get => this._rch_Supplier;
      set
      {
        this._rch_Supplier = value;
        this.Changed(nameof (rch_Supplier));
      }
    }

    public long rch_SiteID
    {
      get => this._rch_SiteID;
      set
      {
        this._rch_SiteID = value;
        this.Changed(nameof (rch_SiteID));
      }
    }

    public DateTime? rch_ContractDate
    {
      get => this._rch_ContractDate;
      set
      {
        this._rch_ContractDate = value;
        this.Changed(nameof (rch_ContractDate));
      }
    }

    public int rch_CalcPeriodType
    {
      get => this._rch_CalcPeriodType;
      set
      {
        this._rch_CalcPeriodType = value;
        this.Changed(nameof (rch_CalcPeriodType));
        this.Changed("rch_CalcPeriodTypeDesc");
      }
    }

    public string rch_CalcPeriodTypeDesc => this.rch_CalcPeriodType != 0 ? Enum2StrConverter.ToSupRebateStdDate(this.rch_CalcPeriodType).ToDescription() : string.Empty;

    public int rch_StdAmtType
    {
      get => this._rch_StdAmtType;
      set
      {
        this._rch_StdAmtType = value;
        this.Changed(nameof (rch_StdAmtType));
        this.Changed("rch_StdAmtTypeDesc");
      }
    }

    public string rch_StdAmtTypeDesc => this.rch_StdAmtType != 0 ? Enum2StrConverter.ToSupRebateStdAmount(this.rch_StdAmtType).ToDescription() : string.Empty;

    public string rch_UseYn
    {
      get => this._rch_UseYn;
      set
      {
        this._rch_UseYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (rch_UseYn));
        this.Changed("rch_IsUseYn");
        this.Changed("rch_UseYnDesc");
      }
    }

    public bool rch_IsUseYn => "Y".Equals(this.rch_UseYn);

    public string rch_UseYnDesc => !"Y".Equals(this.rch_UseYn) ? "미사용" : "사용";

    public int rch_AddProperty
    {
      get => this._rch_AddProperty;
      set
      {
        this._rch_AddProperty = value;
        this.Changed(nameof (rch_AddProperty));
      }
    }

    public DateTime? rch_InDate
    {
      get => this._rch_InDate;
      set
      {
        this._rch_InDate = value;
        this.Changed(nameof (rch_InDate));
      }
    }

    public int rch_InUser
    {
      get => this._rch_InUser;
      set
      {
        this._rch_InUser = value;
        this.Changed(nameof (rch_InUser));
      }
    }

    public DateTime? rch_ModDate
    {
      get => this._rch_ModDate;
      set
      {
        this._rch_ModDate = value;
        this.Changed(nameof (rch_ModDate));
      }
    }

    public int rch_ModUser
    {
      get => this._rch_ModUser;
      set
      {
        this._rch_ModUser = value;
        this.Changed(nameof (rch_ModUser));
      }
    }

    public TRebateConditionHeader() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("rch_StoreCode", new TTableColumn()
      {
        tc_orgin_name = "rch_StoreCode",
        tc_trans_name = "지점코드"
      });
      columnInfo.Add("rch_Supplier", new TTableColumn()
      {
        tc_orgin_name = "rch_Supplier",
        tc_trans_name = "코드"
      });
      columnInfo.Add("rch_SiteID", new TTableColumn()
      {
        tc_orgin_name = "rch_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("rch_ContractDate", new TTableColumn()
      {
        tc_orgin_name = "rch_ContractDate",
        tc_trans_name = "입점일(계약일)"
      });
      columnInfo.Add("rch_CalcPeriodType", new TTableColumn()
      {
        tc_orgin_name = "rch_CalcPeriodType",
        tc_trans_name = "생성주기",
        tc_comm_code = 79
      });
      columnInfo.Add("rch_StdAmtType", new TTableColumn()
      {
        tc_orgin_name = "rch_StdAmtType",
        tc_trans_name = "기준금액유형",
        tc_comm_code = 80
      });
      columnInfo.Add("rch_UseYn", new TTableColumn()
      {
        tc_orgin_name = "rch_UseYn",
        tc_trans_name = "사용상태"
      });
      columnInfo.Add("rch_AddProperty", new TTableColumn()
      {
        tc_orgin_name = "rch_AddProperty",
        tc_trans_name = "속성타입"
      });
      columnInfo.Add("rch_InDate", new TTableColumn()
      {
        tc_orgin_name = "rch_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("rch_InUser", new TTableColumn()
      {
        tc_orgin_name = "rch_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("rch_ModDate", new TTableColumn()
      {
        tc_orgin_name = "rch_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("rch_ModUser", new TTableColumn()
      {
        tc_orgin_name = "rch_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.RebateConditionHeader;
      this.rch_StoreCode = this.rch_Supplier = 0;
      this.rch_SiteID = 0L;
      this.rch_ContractDate = new DateTime?();
      this.rch_CalcPeriodType = this.rch_StdAmtType = 0;
      this.rch_UseYn = "Y";
      this.rch_AddProperty = 0;
      this.rch_InDate = new DateTime?();
      this.rch_InUser = 0;
      this.rch_ModDate = new DateTime?();
      this.rch_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TRebateConditionHeader();

    public override object Clone()
    {
      TRebateConditionHeader trebateConditionHeader = base.Clone() as TRebateConditionHeader;
      trebateConditionHeader.rch_StoreCode = this.rch_StoreCode;
      trebateConditionHeader.rch_Supplier = this.rch_Supplier;
      trebateConditionHeader.rch_SiteID = this.rch_SiteID;
      trebateConditionHeader.rch_ContractDate = this.rch_ContractDate;
      trebateConditionHeader.rch_CalcPeriodType = this.rch_CalcPeriodType;
      trebateConditionHeader.rch_StdAmtType = this.rch_StdAmtType;
      trebateConditionHeader.rch_UseYn = this.rch_UseYn;
      trebateConditionHeader.rch_AddProperty = this.rch_AddProperty;
      trebateConditionHeader.rch_InDate = this.rch_InDate;
      trebateConditionHeader.rch_InUser = this.rch_InUser;
      trebateConditionHeader.rch_ModDate = this.rch_ModDate;
      trebateConditionHeader.rch_ModUser = this.rch_ModUser;
      return (object) trebateConditionHeader;
    }

    public void PutData(TRebateConditionHeader pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.rch_StoreCode = pSource.rch_StoreCode;
      this.rch_Supplier = pSource.rch_Supplier;
      this.rch_SiteID = pSource.rch_SiteID;
      this.rch_ContractDate = pSource.rch_ContractDate;
      this.rch_CalcPeriodType = pSource.rch_CalcPeriodType;
      this.rch_StdAmtType = pSource.rch_StdAmtType;
      this.rch_UseYn = pSource.rch_UseYn;
      this.rch_AddProperty = pSource.rch_AddProperty;
      this.rch_InDate = pSource.rch_InDate;
      this.rch_InUser = pSource.rch_InUser;
      this.rch_ModDate = pSource.rch_ModDate;
      this.rch_ModUser = pSource.rch_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.rch_StoreCode = p_rs.GetFieldInt("rch_StoreCode");
        if (this.rch_StoreCode == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.rch_Supplier = p_rs.GetFieldInt("rch_Supplier");
        this.rch_SiteID = p_rs.GetFieldLong("rch_SiteID");
        this.rch_ContractDate = p_rs.GetFieldDateTime("rch_ContractDate");
        this.rch_CalcPeriodType = p_rs.GetFieldInt("rch_CalcPeriodType");
        this.rch_StdAmtType = p_rs.GetFieldInt("rch_StdAmtType");
        this.rch_UseYn = p_rs.GetFieldString("rch_UseYn");
        this.rch_AddProperty = p_rs.GetFieldInt("rch_AddProperty");
        this.rch_InDate = p_rs.GetFieldDateTime("rch_InDate");
        this.rch_InUser = p_rs.GetFieldInt("rch_InUser");
        this.rch_ModDate = p_rs.GetFieldDateTime("rch_ModDate");
        this.rch_ModUser = p_rs.GetFieldInt("rch_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " rch_StoreCode,rch_Supplier,rch_SiteID,rch_ContractDate,rch_CalcPeriodType,rch_StdAmtType,rch_UseYn,rch_AddProperty,rch_InDate,rch_InUser,rch_ModDate,rch_ModUser) VALUES ( " + string.Format(" {0},{1}", (object) this.rch_StoreCode, (object) this.rch_Supplier) + string.Format(",{0}", (object) this.rch_SiteID) + "," + this.rch_ContractDate.GetDateToStrInNull() + string.Format(",{0},{1}", (object) this.rch_CalcPeriodType, (object) this.rch_StdAmtType) + string.Format(",'{0}',{1}", (object) this.rch_UseYn, (object) this.rch_AddProperty) + string.Format(",{0},{1}", (object) this.rch_InDate.GetDateToStrInNull(), (object) this.rch_InUser) + string.Format(",{0},{1}", (object) this.rch_ModDate.GetDateToStrInNull(), (object) this.rch_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.rch_StoreCode, (object) this.rch_Supplier, (object) this.rch_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TRebateConditionHeader trebateConditionHeader = this;
      // ISSUE: reference to a compiler-generated method
      trebateConditionHeader.\u003C\u003En__0();
      if (await trebateConditionHeader.OleDB.ExecuteAsync(trebateConditionHeader.InsertQuery()))
        return true;
      trebateConditionHeader.message = " " + trebateConditionHeader.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + trebateConditionHeader.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) trebateConditionHeader.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) trebateConditionHeader.rch_StoreCode, (object) trebateConditionHeader.rch_Supplier, (object) trebateConditionHeader.rch_SiteID) + " 내용 : " + trebateConditionHeader.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(trebateConditionHeader.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " rch_ContractDate=" + this.rch_ContractDate.GetDateToStrInNull() + string.Format(",{0}={1},{2}={3}", (object) "rch_CalcPeriodType", (object) this.rch_CalcPeriodType, (object) "rch_StdAmtType", (object) this.rch_StdAmtType) + string.Format(",{0}='{1}',{2}={3}", (object) "rch_UseYn", (object) this.rch_UseYn, (object) "rch_AddProperty", (object) this.rch_AddProperty) + string.Format(",{0}={1},{2}={3}", (object) "rch_ModDate", (object) this.rch_ModDate.GetDateToStrInNull(), (object) "rch_ModUser", (object) this.rch_ModUser) + string.Format(" WHERE {0}={1}", (object) "rch_StoreCode", (object) this.rch_StoreCode) + string.Format(" AND {0}={1}", (object) "rch_Supplier", (object) this.rch_Supplier) + string.Format(" AND {0}={1}", (object) "rch_SiteID", (object) this.rch_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.rch_StoreCode, (object) this.rch_Supplier, (object) this.rch_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TRebateConditionHeader trebateConditionHeader = this;
      // ISSUE: reference to a compiler-generated method
      trebateConditionHeader.\u003C\u003En__1();
      if (await trebateConditionHeader.OleDB.ExecuteAsync(trebateConditionHeader.UpdateQuery()))
        return true;
      trebateConditionHeader.message = " " + trebateConditionHeader.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + trebateConditionHeader.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) trebateConditionHeader.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) trebateConditionHeader.rch_StoreCode, (object) trebateConditionHeader.rch_Supplier, (object) trebateConditionHeader.rch_SiteID) + " 내용 : " + trebateConditionHeader.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(trebateConditionHeader.message);
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
      stringBuilder.Append(" rch_ContractDate=" + this.rch_ContractDate.GetDateToStrInNull() + string.Format(",{0}={1},{2}={3}", (object) "rch_CalcPeriodType", (object) this.rch_CalcPeriodType, (object) "rch_StdAmtType", (object) this.rch_StdAmtType) + string.Format(",{0}='{1}',{2}={3}", (object) "rch_UseYn", (object) this.rch_UseYn, (object) "rch_AddProperty", (object) this.rch_AddProperty) + string.Format(",{0}={1},{2}={3}", (object) "rch_ModDate", (object) this.rch_ModDate.GetDateToStrInNull(), (object) "rch_ModUser", (object) this.rch_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.rch_StoreCode, (object) this.rch_Supplier, (object) this.rch_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TRebateConditionHeader trebateConditionHeader = this;
      // ISSUE: reference to a compiler-generated method
      trebateConditionHeader.\u003C\u003En__1();
      if (await trebateConditionHeader.OleDB.ExecuteAsync(trebateConditionHeader.UpdateExInsertQuery()))
        return true;
      trebateConditionHeader.message = " " + trebateConditionHeader.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + trebateConditionHeader.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) trebateConditionHeader.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) trebateConditionHeader.rch_StoreCode, (object) trebateConditionHeader.rch_Supplier, (object) trebateConditionHeader.rch_SiteID) + " 내용 : " + trebateConditionHeader.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(trebateConditionHeader.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "rch_SiteID") && Convert.ToInt64(hashtable[(object) "rch_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "rch_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "rch_StoreCode") && Convert.ToInt32(hashtable[(object) "rch_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "rch_StoreCode", hashtable[(object) "rch_StoreCode"]));
        else if (hashtable.ContainsKey((object) "rch_StoreCode_IN_") && hashtable[(object) "rch_StoreCode_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "rch_StoreCode", hashtable[(object) "rch_StoreCode_IN_"]));
        else if (hashtable.ContainsKey((object) "_STORE_AUTHS_") && hashtable[(object) "_STORE_AUTHS_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "rch_StoreCode", hashtable[(object) "_STORE_AUTHS_"]));
        if (hashtable.ContainsKey((object) "rch_Supplier") && Convert.ToInt32(hashtable[(object) "rch_Supplier"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "rch_Supplier", hashtable[(object) "rch_Supplier"]));
        else if (hashtable.ContainsKey((object) "rch_Supplier_IN_") && hashtable[(object) "rch_Supplier_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "rch_Supplier", hashtable[(object) "rch_Supplier_IN_"]));
        else if (hashtable.ContainsKey((object) "_SUPPLIER_AUTHS_") && hashtable[(object) "_SUPPLIER_AUTHS_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "rch_Supplier", hashtable[(object) "_SUPPLIER_AUTHS_"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "rch_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "rch_CalcPeriodType") && Convert.ToInt32(hashtable[(object) "rch_CalcPeriodType"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "rch_CalcPeriodType", hashtable[(object) "rch_CalcPeriodType"]));
        if (hashtable.ContainsKey((object) "rch_StdAmtType") && Convert.ToInt32(hashtable[(object) "rch_StdAmtType"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "rch_StdAmtType", hashtable[(object) "rch_StdAmtType"]));
        if (hashtable.ContainsKey((object) "rch_UseYn") && hashtable[(object) "rch_UseYn"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "rch_UseYn", hashtable[(object) "rch_UseYn"]));
        if (hashtable.ContainsKey((object) "rch_AddProperty") && Convert.ToInt32(hashtable[(object) "rch_AddProperty"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "rch_AddProperty", hashtable[(object) "rch_AddProperty"]));
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
        string uniBase = UbModelBase.UNI_BASE;
        string str = this.TableCode.ToString();
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
        }
        stringBuilder.Append(" SELECT  rch_StoreCode,rch_Supplier,rch_SiteID,rch_ContractDate,rch_CalcPeriodType,rch_StdAmtType,rch_UseYn,rch_AddProperty,rch_InDate,rch_InUser,rch_ModDate,rch_ModUser");
        stringBuilder.Append(" FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock());
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
