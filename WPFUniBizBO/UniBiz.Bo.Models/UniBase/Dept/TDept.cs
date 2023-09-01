// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Dept.TDept
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

namespace UniBiz.Bo.Models.UniBase.Dept
{
  public class TDept : UbModelBase<TDept>
  {
    private int _dpt_ID;
    private long _dpt_SiteID;
    private string _dpt_DeptName;
    private string _dpt_ViewCode;
    private string _dpt_Memo;
    private string _dpt_UseYn;
    private int _dpt_Depth;
    private int _dpt_ParentsID;
    private DateTime? _dpt_InDate;
    private int _dpt_InUser;
    private DateTime? _dpt_ModDate;
    private int _dpt_ModUser;

    public override object _Key => (object) new object[1]
    {
      (object) this.dpt_ID
    };

    public int dpt_ID
    {
      get => this._dpt_ID;
      set
      {
        this._dpt_ID = value;
        this.Changed(nameof (dpt_ID));
        this.Changed("dpt_lv3_ID");
      }
    }

    [JsonIgnore]
    public int dpt_lv3_ID => this.dpt_Depth != 3 ? 0 : this.dpt_ID;

    public long dpt_SiteID
    {
      get => this._dpt_SiteID;
      set
      {
        this._dpt_SiteID = value;
        this.Changed(nameof (dpt_SiteID));
      }
    }

    public string dpt_DeptName
    {
      get => this._dpt_DeptName;
      set
      {
        this._dpt_DeptName = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (dpt_DeptName));
        this.Changed("dpt_lv3_Name");
      }
    }

    [JsonIgnore]
    public string dpt_lv3_Name => this.dpt_Depth != 3 ? string.Empty : this.dpt_DeptName;

    public string dpt_ViewCode
    {
      get => this._dpt_ViewCode;
      set
      {
        this._dpt_ViewCode = UbModelBase.LeftStr(value, 10).Replace("'", "´");
        this.Changed(nameof (dpt_ViewCode));
        this.Changed("dpt_lv3_ViewCode");
      }
    }

    [JsonIgnore]
    public string dpt_lv3_ViewCode => this.dpt_Depth != 3 ? string.Empty : this.dpt_ViewCode;

    public string dpt_Memo
    {
      get => this._dpt_Memo;
      set
      {
        this._dpt_Memo = UbModelBase.LeftStr(value, 200).Replace("'", "´");
        this.Changed(nameof (dpt_Memo));
      }
    }

    public string dpt_UseYn
    {
      get => this._dpt_UseYn;
      set
      {
        this._dpt_UseYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (dpt_UseYn));
        this.Changed("dpt_IsUseYn");
        this.Changed("dpt_UseYnDesc");
      }
    }

    public bool dpt_IsUseYn => "Y".Equals(this.dpt_UseYn);

    public string dpt_UseYnDesc => !"Y".Equals(this.dpt_UseYn) ? "미사용" : "사용";

    public int dpt_Depth
    {
      get => this._dpt_Depth;
      set
      {
        this._dpt_Depth = value;
        this.Changed(nameof (dpt_Depth));
        this.Changed("dpt_DepthDesc");
        this.Changed("dpt_lv3_ID");
        this.Changed("dpt_lv3_Name");
        this.Changed("dpt_lv3_ViewCode");
      }
    }

    public string dpt_DepthDesc => this.dpt_Depth != 0 ? Enum2StrConverter.ToDeptDepth(this.dpt_Depth).ToDescription() : string.Empty;

    public int dpt_ParentsID
    {
      get => this._dpt_ParentsID;
      set
      {
        this._dpt_ParentsID = value;
        this.Changed(nameof (dpt_ParentsID));
      }
    }

    public DateTime? dpt_InDate
    {
      get => this._dpt_InDate;
      set
      {
        this._dpt_InDate = value;
        this.Changed(nameof (dpt_InDate));
      }
    }

    public int dpt_InUser
    {
      get => this._dpt_InUser;
      set
      {
        this._dpt_InUser = value;
        this.Changed(nameof (dpt_InUser));
      }
    }

    public DateTime? dpt_ModDate
    {
      get => this._dpt_ModDate;
      set
      {
        this._dpt_ModDate = value;
        this.Changed(nameof (dpt_ModDate));
      }
    }

    public int dpt_ModUser
    {
      get => this._dpt_ModUser;
      set
      {
        this._dpt_ModUser = value;
        this.Changed(nameof (dpt_ModUser));
      }
    }

    public TDept() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("dpt_ID", new TTableColumn()
      {
        tc_orgin_name = "dpt_ID",
        tc_trans_name = "부서ID"
      });
      columnInfo.Add("dpt_SiteID", new TTableColumn()
      {
        tc_orgin_name = "dpt_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("dpt_DeptName", new TTableColumn()
      {
        tc_orgin_name = "dpt_DeptName",
        tc_trans_name = "PC명"
      });
      columnInfo.Add("dpt_ViewCode", new TTableColumn()
      {
        tc_orgin_name = "dpt_ViewCode",
        tc_trans_name = "PC코드"
      });
      columnInfo.Add("dpt_Memo", new TTableColumn()
      {
        tc_orgin_name = "dpt_Memo",
        tc_trans_name = "부서설명"
      });
      columnInfo.Add("dpt_UseYn", new TTableColumn()
      {
        tc_orgin_name = "dpt_UseYn",
        tc_trans_name = "사용상태"
      });
      columnInfo.Add("dpt_Depth", new TTableColumn()
      {
        tc_orgin_name = "dpt_Depth",
        tc_trans_name = "부서 단계",
        tc_comm_code = 38
      });
      columnInfo.Add("dpt_ParentsID", new TTableColumn()
      {
        tc_orgin_name = "dpt_ParentsID",
        tc_trans_name = "상위부서"
      });
      columnInfo.Add("dpt_InDate", new TTableColumn()
      {
        tc_orgin_name = "dpt_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("dpt_InUser", new TTableColumn()
      {
        tc_orgin_name = "dpt_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("dpt_ModDate", new TTableColumn()
      {
        tc_orgin_name = "dpt_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("dpt_ModUser", new TTableColumn()
      {
        tc_orgin_name = "dpt_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.Dept;
      this.dpt_ID = 0;
      this.dpt_SiteID = 0L;
      this.dpt_DeptName = string.Empty;
      this.dpt_ViewCode = string.Empty;
      this.dpt_Memo = string.Empty;
      this.dpt_UseYn = "Y";
      this.dpt_Depth = this.dpt_ParentsID = 0;
      this.dpt_InDate = new DateTime?();
      this.dpt_ModDate = new DateTime?();
      this.dpt_InUser = this.dpt_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TDept();

    public override object Clone()
    {
      TDept tdept = base.Clone() as TDept;
      tdept.dpt_ID = this.dpt_ID;
      tdept.dpt_SiteID = this.dpt_SiteID;
      tdept.dpt_DeptName = this.dpt_DeptName;
      tdept.dpt_ViewCode = this.dpt_ViewCode;
      tdept.dpt_Memo = this.dpt_Memo;
      tdept.dpt_UseYn = this.dpt_UseYn;
      tdept.dpt_Depth = this.dpt_Depth;
      tdept.dpt_ParentsID = this.dpt_ParentsID;
      tdept.dpt_InDate = this.dpt_InDate;
      tdept.dpt_ModDate = this.dpt_ModDate;
      tdept.dpt_InUser = this.dpt_InUser;
      tdept.dpt_ModUser = this.dpt_ModUser;
      return (object) tdept;
    }

    public void PutData(TDept pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.dpt_ID = pSource.dpt_ID;
      this.dpt_SiteID = pSource.dpt_SiteID;
      this.dpt_DeptName = pSource.dpt_DeptName;
      this.dpt_ViewCode = pSource.dpt_ViewCode;
      this.dpt_Memo = pSource.dpt_Memo;
      this.dpt_UseYn = pSource.dpt_UseYn;
      this.dpt_Depth = pSource.dpt_Depth;
      this.dpt_ParentsID = pSource.dpt_ParentsID;
      this.dpt_InDate = pSource.dpt_InDate;
      this.dpt_ModDate = pSource.dpt_ModDate;
      this.dpt_InUser = pSource.dpt_InUser;
      this.dpt_ModUser = pSource.dpt_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.dpt_ID = p_rs.GetFieldInt("dpt_ID");
        if (this.dpt_ID == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.dpt_SiteID = p_rs.GetFieldLong("dpt_SiteID");
        this.dpt_DeptName = p_rs.GetFieldString("dpt_DeptName");
        this.dpt_ViewCode = p_rs.GetFieldString("dpt_ViewCode");
        this.dpt_Memo = p_rs.GetFieldString("dpt_Memo");
        this.dpt_UseYn = p_rs.GetFieldString("dpt_UseYn");
        this.dpt_Depth = p_rs.GetFieldInt("dpt_Depth");
        this.dpt_ParentsID = p_rs.GetFieldInt("dpt_ParentsID");
        this.dpt_InDate = p_rs.GetFieldDateTime("dpt_InDate");
        this.dpt_InUser = p_rs.GetFieldInt("dpt_InUser");
        this.dpt_ModDate = p_rs.GetFieldDateTime("dpt_ModDate");
        this.dpt_ModUser = p_rs.GetFieldInt("dpt_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " dpt_ID,dpt_SiteID,dpt_DeptName,dpt_ViewCode,dpt_Memo,dpt_UseYn,dpt_Depth,dpt_ParentsID,dpt_InDate,dpt_InUser,dpt_ModDate,dpt_ModUser) VALUES ( " + string.Format(" {0}", (object) this.dpt_ID) + string.Format(",{0}", (object) this.dpt_SiteID) + ",'" + this.dpt_DeptName + "','" + this.dpt_ViewCode + "','" + this.dpt_Memo + "'" + string.Format(",'{0}',{1},{2}", (object) this.dpt_UseYn, (object) this.dpt_Depth, (object) this.dpt_ParentsID) + string.Format(",{0},{1}", (object) this.dpt_InDate.GetDateToStrInNull(), (object) this.dpt_InUser) + string.Format(",{0},{1}", (object) this.dpt_ModDate.GetDateToStrInNull(), (object) this.dpt_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.dpt_ID, (object) this.dpt_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TDept tdept = this;
      // ISSUE: reference to a compiler-generated method
      tdept.\u003C\u003En__0();
      if (await tdept.OleDB.ExecuteAsync(tdept.InsertQuery()))
        return true;
      tdept.message = " " + tdept.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tdept.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tdept.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tdept.dpt_ID, (object) tdept.dpt_SiteID) + " 내용 : " + tdept.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tdept.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " dpt_DeptName='" + this.dpt_DeptName + "',dpt_ViewCode='" + this.dpt_ViewCode + "',dpt_Memo='" + this.dpt_Memo + "'" + string.Format(",{0}='{1}',{2}={3},{4}={5}", (object) "dpt_UseYn", (object) this.dpt_UseYn, (object) "dpt_Depth", (object) this.dpt_Depth, (object) "dpt_ParentsID", (object) this.dpt_ParentsID) + string.Format(",{0}={1},{2}={3}", (object) "dpt_ModDate", (object) this.dpt_ModDate.GetDateToStrInNull(), (object) "dpt_ModUser", (object) this.dpt_ModUser) + string.Format(" WHERE {0}={1}", (object) "dpt_ID", (object) this.dpt_ID) + string.Format(" AND {0}={1}", (object) "dpt_SiteID", (object) this.dpt_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.dpt_ID, (object) this.dpt_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TDept tdept = this;
      // ISSUE: reference to a compiler-generated method
      tdept.\u003C\u003En__1();
      if (await tdept.OleDB.ExecuteAsync(tdept.UpdateQuery()))
        return true;
      tdept.message = " " + tdept.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tdept.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tdept.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tdept.dpt_ID, (object) tdept.dpt_SiteID) + " 내용 : " + tdept.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tdept.message);
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
      stringBuilder.Append(" dpt_DeptName='" + this.dpt_DeptName + "',dpt_ViewCode='" + this.dpt_ViewCode + "',dpt_Memo='" + this.dpt_Memo + "'" + string.Format(",{0}='{1}',{2}={3},{4}={5}", (object) "dpt_UseYn", (object) this.dpt_UseYn, (object) "dpt_Depth", (object) this.dpt_Depth, (object) "dpt_ParentsID", (object) this.dpt_ParentsID) + string.Format(",{0}={1},{2}={3}", (object) "dpt_ModDate", (object) this.dpt_ModDate.GetDateToStrInNull(), (object) "dpt_ModUser", (object) this.dpt_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.dpt_ID, (object) this.dpt_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TDept tdept = this;
      // ISSUE: reference to a compiler-generated method
      tdept.\u003C\u003En__1();
      if (await tdept.OleDB.ExecuteAsync(tdept.UpdateExInsertQuery()))
        return true;
      tdept.message = " " + tdept.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tdept.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tdept.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tdept.dpt_ID, (object) tdept.dpt_SiteID) + " 내용 : " + tdept.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tdept.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "dpt_SiteID") && Convert.ToInt64(hashtable[(object) "dpt_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "dpt_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "dpt_ID") && Convert.ToInt32(hashtable[(object) "dpt_ID"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "dpt_ID", hashtable[(object) "dpt_ID"]));
        else
          stringBuilder.Append(" AND dpt_ID>0");
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "dpt_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "dpt_ViewCode") && hashtable[(object) "dpt_ViewCode"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "dpt_ViewCode", hashtable[(object) "dpt_ViewCode"]));
        if (hashtable.ContainsKey((object) "dpt_ViewCode_IN_") && hashtable[(object) "dpt_ViewCode_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "dpt_ViewCode", hashtable[(object) "dpt_ViewCode_IN_"]));
        if (hashtable.ContainsKey((object) "dpt_DeptName") && hashtable[(object) "dpt_DeptName"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "dpt_DeptName", hashtable[(object) "dpt_DeptName"]));
        if (hashtable.ContainsKey((object) "dpt_UseYn") && hashtable[(object) "dpt_UseYn"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "dpt_UseYn", hashtable[(object) "dpt_UseYn"]));
        if (hashtable.ContainsKey((object) "dpt_Depth") && Convert.ToInt32(hashtable[(object) "dpt_Depth"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "dpt_Depth", hashtable[(object) "dpt_Depth"]));
        if (hashtable.ContainsKey((object) "dpt_ParentsID") && Convert.ToInt32(hashtable[(object) "dpt_ParentsID"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "dpt_ParentsID", hashtable[(object) "dpt_ParentsID"]));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "dpt_DeptName", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "dpt_Memo", hashtable[(object) "_KEY_WORD_"]));
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
        stringBuilder.Append(" SELECT  dpt_ID,dpt_SiteID,dpt_DeptName,dpt_ViewCode,dpt_Memo,dpt_UseYn,dpt_Depth,dpt_ParentsID,dpt_InDate,dpt_InUser,dpt_ModDate,dpt_ModUser");
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
