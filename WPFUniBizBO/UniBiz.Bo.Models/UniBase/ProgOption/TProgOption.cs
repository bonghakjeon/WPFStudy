// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.ProgOption.TProgOption
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

namespace UniBiz.Bo.Models.UniBase.ProgOption
{
  public class TProgOption : UbModelBase<TProgOption>
  {
    private int _opt_Code;
    private int _opt_StoreCode;
    private long _opt_SiteID;
    private int _opt_Type;
    private string _opt_Name;
    private int _opt_ValueType;
    private string _opt_Value;
    private string _opt_Memo;
    private int _opt_AddProperty;
    private DateTime? _opt_InDate;
    private int _opt_InUser;
    private DateTime? _opt_ModDate;
    private int _opt_ModUser;

    public override object _Key => (object) new object[3]
    {
      (object) this.opt_Code,
      (object) this.opt_StoreCode,
      (object) this.opt_SiteID
    };

    public int opt_Code
    {
      get => this._opt_Code;
      set
      {
        this._opt_Code = value;
        this.Changed(nameof (opt_Code));
        this.Changed("opt_CodeDesc");
      }
    }

    public string opt_CodeDesc => Enum2StrConverter.ToOptionType(this.opt_Code).ToString();

    public int opt_StoreCode
    {
      get => this._opt_StoreCode;
      set
      {
        this._opt_StoreCode = value;
        this.Changed(nameof (opt_StoreCode));
      }
    }

    public long opt_SiteID
    {
      get => this._opt_SiteID;
      set
      {
        this._opt_SiteID = value;
        this.Changed(nameof (opt_SiteID));
      }
    }

    public int opt_Type
    {
      get => this._opt_Type;
      set
      {
        this._opt_Type = value;
        this.Changed(nameof (opt_Type));
        this.Changed("opt_TypeDesc");
      }
    }

    public string opt_TypeDesc => this.opt_Type != 0 ? Enum2StrConverter.ToProgOptionType(this.opt_Type).ToDescription() : string.Empty;

    public string opt_Name
    {
      get => this._opt_Name;
      set
      {
        this._opt_Name = UbModelBase.LeftStr(value, 200).Replace("'", "´");
        this.Changed(nameof (opt_Name));
      }
    }

    public int opt_ValueType
    {
      get => this._opt_ValueType;
      set
      {
        this._opt_ValueType = value;
        this.Changed(nameof (opt_ValueType));
      }
    }

    public string opt_ValueTypeDesc => this.opt_ValueType != 0 ? Enum2StrConverter.ToProgOptionValueType(this.opt_ValueType).ToDescription() : string.Empty;

    public string opt_Value
    {
      get => this._opt_Value;
      set
      {
        this._opt_Value = UbModelBase.LeftStr(value, 200).Replace("'", "´");
        this.Changed(nameof (opt_Value));
      }
    }

    public string opt_Memo
    {
      get => this._opt_Memo;
      set
      {
        this._opt_Memo = UbModelBase.LeftStr(value, 200).Replace("'", "´");
        this.Changed(nameof (opt_Memo));
      }
    }

    public int opt_AddProperty
    {
      get => this._opt_AddProperty;
      set
      {
        this._opt_AddProperty = value;
        this.Changed(nameof (opt_AddProperty));
      }
    }

    public DateTime? opt_InDate
    {
      get => this._opt_InDate;
      set
      {
        this._opt_InDate = value;
        this.Changed(nameof (opt_InDate));
      }
    }

    public int opt_InUser
    {
      get => this._opt_InUser;
      set
      {
        this._opt_InUser = value;
        this.Changed(nameof (opt_InUser));
      }
    }

    public DateTime? opt_ModDate
    {
      get => this._opt_ModDate;
      set
      {
        this._opt_ModDate = value;
        this.Changed(nameof (opt_ModDate));
      }
    }

    public int opt_ModUser
    {
      get => this._opt_ModUser;
      set
      {
        this._opt_ModUser = value;
        this.Changed(nameof (opt_ModUser));
      }
    }

    public TProgOption() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("opt_Code", new TTableColumn()
      {
        tc_orgin_name = "opt_Code",
        tc_trans_name = "ID"
      });
      columnInfo.Add("opt_StoreCode", new TTableColumn()
      {
        tc_orgin_name = "opt_StoreCode",
        tc_trans_name = "지점코드"
      });
      columnInfo.Add("opt_SiteID", new TTableColumn()
      {
        tc_orgin_name = "opt_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("opt_Type", new TTableColumn()
      {
        tc_orgin_name = "opt_Type",
        tc_trans_name = "옵션유형",
        tc_comm_code = 152
      });
      columnInfo.Add("opt_Name", new TTableColumn()
      {
        tc_orgin_name = "opt_Name",
        tc_trans_name = "옵션명"
      });
      columnInfo.Add("opt_ValueType", new TTableColumn()
      {
        tc_orgin_name = "opt_ValueType",
        tc_trans_name = "값유형",
        tc_comm_code = 153
      });
      columnInfo.Add("opt_Value", new TTableColumn()
      {
        tc_orgin_name = "opt_Value",
        tc_trans_name = "값"
      });
      columnInfo.Add("opt_Memo", new TTableColumn()
      {
        tc_orgin_name = "opt_Memo",
        tc_trans_name = "메모"
      });
      columnInfo.Add("opt_AddProperty", new TTableColumn()
      {
        tc_orgin_name = "opt_AddProperty",
        tc_trans_name = "속성타입"
      });
      columnInfo.Add("opt_InDate", new TTableColumn()
      {
        tc_orgin_name = "opt_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("opt_InUser", new TTableColumn()
      {
        tc_orgin_name = "opt_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("opt_ModDate", new TTableColumn()
      {
        tc_orgin_name = "opt_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("opt_ModUser", new TTableColumn()
      {
        tc_orgin_name = "opt_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.ProgOption;
      this.opt_Code = this.opt_StoreCode = 0;
      this.opt_SiteID = 0L;
      this.opt_Type = 0;
      this.opt_Name = string.Empty;
      this.opt_ValueType = 0;
      this.opt_Value = this.opt_Memo = string.Empty;
      this.opt_AddProperty = 0;
      this.opt_InDate = new DateTime?();
      this.opt_InUser = 0;
      this.opt_ModDate = new DateTime?();
      this.opt_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TProgOption();

    public override object Clone()
    {
      TProgOption tprogOption = base.Clone() as TProgOption;
      tprogOption.opt_Code = this.opt_Code;
      tprogOption.opt_StoreCode = this.opt_StoreCode;
      tprogOption.opt_SiteID = this.opt_SiteID;
      tprogOption.opt_Type = this.opt_Type;
      tprogOption.opt_Name = this.opt_Name;
      tprogOption.opt_ValueType = this.opt_ValueType;
      tprogOption.opt_Value = this.opt_Value;
      tprogOption.opt_Memo = this.opt_Memo;
      tprogOption.opt_AddProperty = this.opt_AddProperty;
      tprogOption.opt_InDate = this.opt_InDate;
      tprogOption.opt_InUser = this.opt_InUser;
      tprogOption.opt_ModDate = this.opt_ModDate;
      tprogOption.opt_ModUser = this.opt_ModUser;
      return (object) tprogOption;
    }

    public void PutData(TProgOption pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.opt_Code = pSource.opt_Code;
      this.opt_StoreCode = pSource.opt_StoreCode;
      this.opt_SiteID = pSource.opt_SiteID;
      this.opt_Type = pSource.opt_Type;
      this.opt_Name = pSource.opt_Name;
      this.opt_ValueType = pSource.opt_ValueType;
      this.opt_Value = pSource.opt_Value;
      this.opt_Memo = pSource.opt_Memo;
      this.opt_AddProperty = pSource.opt_AddProperty;
      this.opt_InDate = pSource.opt_InDate;
      this.opt_InUser = pSource.opt_InUser;
      this.opt_ModDate = pSource.opt_ModDate;
      this.opt_ModUser = pSource.opt_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.opt_Code = p_rs.GetFieldInt("opt_Code");
        if (this.opt_Code == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.opt_StoreCode = p_rs.GetFieldInt("opt_StoreCode");
        this.opt_SiteID = p_rs.GetFieldLong("opt_SiteID");
        this.opt_Type = p_rs.GetFieldInt("opt_Type");
        this.opt_Name = p_rs.GetFieldString("opt_Name");
        this.opt_ValueType = p_rs.GetFieldInt("opt_ValueType");
        this.opt_Value = p_rs.GetFieldString("opt_Value");
        this.opt_Memo = p_rs.GetFieldString("opt_Memo");
        this.opt_AddProperty = p_rs.GetFieldInt("opt_AddProperty");
        this.opt_InDate = p_rs.GetFieldDateTime("opt_InDate");
        this.opt_InUser = p_rs.GetFieldInt("opt_InUser");
        this.opt_ModDate = p_rs.GetFieldDateTime("opt_ModDate");
        this.opt_ModUser = p_rs.GetFieldInt("opt_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " opt_Code,opt_StoreCode,opt_SiteID,opt_Type,opt_Name,opt_ValueType,opt_Value,opt_Memo,opt_AddProperty,opt_InDate,opt_InUser,opt_ModDate,opt_ModUser) VALUES ( " + string.Format(" {0},{1},{2}", (object) this.opt_Code, (object) this.opt_StoreCode, (object) this.opt_SiteID) + string.Format(",{0},'{1}',{2},'{3}'", (object) this.opt_Type, (object) this.opt_Name, (object) this.opt_ValueType, (object) this.opt_Value) + string.Format(",'{0}',{1}", (object) this.opt_Memo, (object) this.opt_AddProperty) + string.Format(",{0},{1}", (object) this.opt_InDate.GetDateToStrInNull(), (object) this.opt_InUser) + string.Format(",{0},{1}", (object) this.opt_ModDate.GetDateToStrInNull(), (object) this.opt_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.opt_Code, (object) this.opt_StoreCode, (object) this.opt_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TProgOption tprogOption = this;
      // ISSUE: reference to a compiler-generated method
      tprogOption.\u003C\u003En__0();
      if (await tprogOption.OleDB.ExecuteAsync(tprogOption.InsertQuery()))
        return true;
      tprogOption.message = " " + tprogOption.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tprogOption.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tprogOption.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tprogOption.opt_Code, (object) tprogOption.opt_StoreCode, (object) tprogOption.opt_SiteID) + " 내용 : " + tprogOption.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tprogOption.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + string.Format(" {0}={1},{2}='{3}'", (object) "opt_Type", (object) this.opt_Type, (object) "opt_Name", (object) this.opt_Name) + string.Format(",{0}={1},{2}='{3}'", (object) "opt_ValueType", (object) this.opt_ValueType, (object) "opt_Value", (object) this.opt_Value) + string.Format(",{0}='{1}',{2}={3}", (object) "opt_Memo", (object) this.opt_Memo, (object) "opt_AddProperty", (object) this.opt_AddProperty) + string.Format(",{0}={1},{2}={3}", (object) "opt_ModDate", (object) this.opt_ModDate.GetDateToStrInNull(), (object) "opt_ModUser", (object) this.opt_ModUser) + string.Format(" WHERE {0}={1}", (object) "opt_Code", (object) this.opt_Code) + string.Format(" AND {0}={1}", (object) "opt_StoreCode", (object) this.opt_StoreCode) + string.Format(" AND {0}={1}", (object) "opt_SiteID", (object) this.opt_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.opt_Code, (object) this.opt_StoreCode, (object) this.opt_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TProgOption tprogOption = this;
      // ISSUE: reference to a compiler-generated method
      tprogOption.\u003C\u003En__1();
      if (await tprogOption.OleDB.ExecuteAsync(tprogOption.UpdateQuery()))
        return true;
      tprogOption.message = " " + tprogOption.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tprogOption.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tprogOption.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tprogOption.opt_Code, (object) tprogOption.opt_StoreCode, (object) tprogOption.opt_SiteID) + " 내용 : " + tprogOption.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tprogOption.message);
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
      stringBuilder.Append(string.Format(" {0}={1},{2}='{3}'", (object) "opt_Type", (object) this.opt_Type, (object) "opt_Name", (object) this.opt_Name) + string.Format(",{0}={1},{2}='{3}'", (object) "opt_ValueType", (object) this.opt_ValueType, (object) "opt_Value", (object) this.opt_Value) + string.Format(",{0}='{1}',{2}={3}", (object) "opt_Memo", (object) this.opt_Memo, (object) "opt_AddProperty", (object) this.opt_AddProperty) + string.Format(",{0}={1},{2}={3}", (object) "opt_ModDate", (object) this.opt_ModDate.GetDateToStrInNull(), (object) "opt_ModUser", (object) this.opt_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.opt_Code, (object) this.opt_StoreCode, (object) this.opt_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TProgOption tprogOption = this;
      // ISSUE: reference to a compiler-generated method
      tprogOption.\u003C\u003En__1();
      if (await tprogOption.OleDB.ExecuteAsync(tprogOption.UpdateExInsertQuery()))
        return true;
      tprogOption.message = " " + tprogOption.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tprogOption.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tprogOption.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tprogOption.opt_Code, (object) tprogOption.opt_StoreCode, (object) tprogOption.opt_SiteID) + " 내용 : " + tprogOption.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tprogOption.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "opt_SiteID") && Convert.ToInt64(hashtable[(object) "opt_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "opt_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "opt_Code") && Convert.ToInt32(hashtable[(object) "opt_Code"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "opt_Code", hashtable[(object) "opt_Code"]));
        else if (!hashtable.ContainsKey((object) "opt_Code코드 0 포함") || !Convert.ToBoolean(hashtable[(object) "opt_Code코드 0 포함"].ToString()))
          stringBuilder.Append(" AND opt_Code>0");
        if (hashtable.ContainsKey((object) "si_StoreCode") && Convert.ToInt32(hashtable[(object) "si_StoreCode"].ToString()) >= 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "opt_StoreCode", hashtable[(object) "si_StoreCode"]));
        else if (hashtable.ContainsKey((object) "opt_StoreCode") && Convert.ToInt32(hashtable[(object) "opt_StoreCode"].ToString()) >= 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "opt_StoreCode", hashtable[(object) "opt_StoreCode"]));
        else if (hashtable.ContainsKey((object) "si_StoreCode코드 0 포함") && Convert.ToBoolean(hashtable[(object) "si_StoreCode코드 0 포함"].ToString()))
          stringBuilder.Append(" AND opt_StoreCode=0");
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "opt_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "opt_Type") && Convert.ToInt32(hashtable[(object) "opt_Type"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "opt_Type", hashtable[(object) "opt_Type"]));
        if (hashtable.ContainsKey((object) "opt_ValueType") && Convert.ToInt32(hashtable[(object) "opt_ValueType"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "opt_ValueType", hashtable[(object) "opt_ValueType"]));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "opt_Name", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "opt_Value", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "opt_Memo", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(")");
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
        stringBuilder.Append(" SELECT  opt_Code,opt_StoreCode,opt_SiteID,opt_Type,opt_Name,opt_ValueType,opt_Value,opt_Memo,opt_AddProperty,opt_InDate,opt_InUser,opt_ModDate,opt_ModUser");
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
