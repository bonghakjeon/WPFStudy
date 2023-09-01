// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.Info.MemberType.TMemberType
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

namespace UniBiz.Bo.Models.UniMembers.Info.MemberType
{
  public class TMemberType : UbModelBase<TMemberType>
  {
    private int _mt_TypeCode;
    private long _mt_SiteID;
    private string _mt_TypeName;
    private string _mt_Memo;
    private string _mt_UseYn;
    private DateTime? _mt_InDate;
    private int _mt_InUser;
    private DateTime? _mt_ModDate;
    private int _mt_ModUser;

    public override object _Key => (object) new object[1]
    {
      (object) this.mt_TypeCode
    };

    public int mt_TypeCode
    {
      get => this._mt_TypeCode;
      set
      {
        this._mt_TypeCode = value;
        this.Changed(nameof (mt_TypeCode));
      }
    }

    public long mt_SiteID
    {
      get => this._mt_SiteID;
      set
      {
        this._mt_SiteID = value;
        this.Changed(nameof (mt_SiteID));
      }
    }

    public string mt_TypeName
    {
      get => this._mt_TypeName;
      set
      {
        this._mt_TypeName = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (mt_TypeName));
      }
    }

    public string mt_Memo
    {
      get => this._mt_Memo;
      set
      {
        this._mt_Memo = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (mt_Memo));
      }
    }

    public string mt_UseYn
    {
      get => this._mt_UseYn;
      set
      {
        this._mt_UseYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (mt_UseYn));
        this.Changed("mt_IsUse");
        this.Changed("mt_UseYnDesc");
      }
    }

    public bool mt_IsUse => "Y".Equals(this.mt_UseYn);

    public string mt_UseYnDesc => !"Y".Equals(this.mt_UseYn) ? "미사용" : "사용";

    public DateTime? mt_InDate
    {
      get => this._mt_InDate;
      set
      {
        this._mt_InDate = value;
        this.Changed(nameof (mt_InDate));
        this.Changed("ModDate");
      }
    }

    public int mt_InUser
    {
      get => this._mt_InUser;
      set
      {
        this._mt_InUser = value;
        this.Changed(nameof (mt_InUser));
      }
    }

    public DateTime? mt_ModDate
    {
      get => this._mt_ModDate;
      set
      {
        this._mt_ModDate = value;
        this.Changed(nameof (mt_ModDate));
        this.Changed("ModDate");
      }
    }

    public int mt_ModUser
    {
      get => this._mt_ModUser;
      set
      {
        this._mt_ModUser = value;
        this.Changed(nameof (mt_ModUser));
      }
    }

    public override DateTime? ModDate => !this.mt_ModDate.HasValue ? this.mt_InDate : this.mt_ModDate;

    public TMemberType() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("mt_TypeCode", new TTableColumn()
      {
        tc_orgin_name = "mt_TypeCode",
        tc_trans_name = "회원유형코드"
      });
      columnInfo.Add("mt_SiteID", new TTableColumn()
      {
        tc_orgin_name = "mt_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("mt_TypeName", new TTableColumn()
      {
        tc_orgin_name = "mt_TypeName",
        tc_trans_name = "회원유형명"
      });
      columnInfo.Add("mt_Memo", new TTableColumn()
      {
        tc_orgin_name = "mt_Memo",
        tc_trans_name = "메모"
      });
      columnInfo.Add("mt_UseYn", new TTableColumn()
      {
        tc_orgin_name = "mt_UseYn",
        tc_trans_name = "사용상태"
      });
      columnInfo.Add("mt_InDate", new TTableColumn()
      {
        tc_orgin_name = "mt_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("mt_InUser", new TTableColumn()
      {
        tc_orgin_name = "mt_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("mt_ModDate", new TTableColumn()
      {
        tc_orgin_name = "mt_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("mt_ModUser", new TTableColumn()
      {
        tc_orgin_name = "mt_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.MemberType;
      this.mt_TypeCode = 0;
      this.mt_SiteID = 0L;
      this.mt_TypeName = this.mt_Memo = string.Empty;
      this.mt_UseYn = "Y";
      this.mt_InDate = new DateTime?();
      this.mt_InUser = 0;
      this.mt_ModDate = new DateTime?();
      this.mt_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TMemberType();

    public override object Clone()
    {
      TMemberType tmemberType = base.Clone() as TMemberType;
      tmemberType.mt_TypeCode = this.mt_TypeCode;
      tmemberType.mt_SiteID = this.mt_SiteID;
      tmemberType.mt_TypeName = this.mt_TypeName;
      tmemberType.mt_Memo = this.mt_Memo;
      tmemberType.mt_UseYn = this.mt_UseYn;
      tmemberType.mt_InDate = this.mt_InDate;
      tmemberType.mt_InUser = this.mt_InUser;
      tmemberType.mt_ModDate = this.mt_ModDate;
      tmemberType.mt_ModUser = this.mt_ModUser;
      return (object) tmemberType;
    }

    public void PutData(TMemberType pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.mt_TypeCode = pSource.mt_TypeCode;
      this.mt_SiteID = pSource.mt_SiteID;
      this.mt_TypeName = pSource.mt_TypeName;
      this.mt_Memo = pSource.mt_Memo;
      this.mt_UseYn = pSource.mt_UseYn;
      this.mt_InDate = pSource.mt_InDate;
      this.mt_InUser = pSource.mt_InUser;
      this.mt_ModDate = pSource.mt_ModDate;
      this.mt_ModUser = pSource.mt_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.mt_TypeCode = p_rs.GetFieldInt("mt_TypeCode");
        if (this.mt_TypeCode == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.mt_SiteID = p_rs.GetFieldLong("mt_SiteID");
        this.mt_TypeName = p_rs.GetFieldString("mt_TypeName");
        this.mt_Memo = p_rs.GetFieldString("mt_Memo");
        this.mt_UseYn = p_rs.GetFieldString("mt_UseYn");
        this.mt_InDate = p_rs.GetFieldDateTime("mt_InDate");
        this.mt_InUser = p_rs.GetFieldInt("mt_InUser");
        this.mt_ModDate = p_rs.GetFieldDateTime("mt_ModDate");
        this.mt_ModUser = p_rs.GetFieldInt("mt_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode) + " mt_TypeCode,mt_SiteID,mt_TypeName,mt_Memo,mt_UseYn,mt_InDate,mt_InUser,mt_ModDate,mt_ModUser) VALUES ( " + string.Format(" {0}", (object) this.mt_TypeCode) + string.Format(",{0}", (object) this.mt_SiteID) + ",'" + this.mt_TypeName + "','" + this.mt_Memo + "','" + this.mt_UseYn + "'" + string.Format(",{0},{1}", (object) this.mt_InDate.GetDateToStrInNull(), (object) this.mt_InUser) + string.Format(",{0},{1}", (object) this.mt_ModDate.GetDateToStrInNull(), (object) this.mt_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.mt_TypeCode, (object) this.mt_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TMemberType tmemberType = this;
      // ISSUE: reference to a compiler-generated method
      tmemberType.\u003C\u003En__0();
      if (await tmemberType.OleDB.ExecuteAsync(tmemberType.InsertQuery()))
        return true;
      tmemberType.message = " " + tmemberType.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberType.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberType.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tmemberType.mt_TypeCode, (object) tmemberType.mt_SiteID) + " 내용 : " + tmemberType.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberType.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode) + " mt_TypeName='" + this.mt_TypeName + "',mt_Memo='" + this.mt_Memo + "',mt_UseYn='" + this.mt_UseYn + "'" + string.Format(",{0}={1},{2}={3}", (object) "mt_ModDate", (object) this.mt_ModDate.GetDateToStrInNull(), (object) "mt_ModUser", (object) this.mt_ModUser) + string.Format(" WHERE {0}={1}", (object) "mt_TypeCode", (object) this.mt_TypeCode) + string.Format(" AND {0}={1}", (object) "mt_SiteID", (object) this.mt_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.mt_TypeCode, (object) this.mt_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TMemberType tmemberType = this;
      // ISSUE: reference to a compiler-generated method
      tmemberType.\u003C\u003En__1();
      if (await tmemberType.OleDB.ExecuteAsync(tmemberType.UpdateQuery()))
        return true;
      tmemberType.message = " " + tmemberType.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberType.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberType.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tmemberType.mt_TypeCode, (object) tmemberType.mt_SiteID) + " 내용 : " + tmemberType.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberType.message);
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
      stringBuilder.Append(" mt_TypeName='" + this.mt_TypeName + "',mt_Memo='" + this.mt_Memo + "',mt_UseYn='" + this.mt_UseYn + "'" + string.Format(",{0}={1},{2}={3}", (object) "mt_ModDate", (object) this.mt_ModDate.GetDateToStrInNull(), (object) "mt_ModUser", (object) this.mt_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.mt_TypeCode, (object) this.mt_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TMemberType tmemberType = this;
      // ISSUE: reference to a compiler-generated method
      tmemberType.\u003C\u003En__1();
      if (await tmemberType.OleDB.ExecuteAsync(tmemberType.UpdateExInsertQuery()))
        return true;
      tmemberType.message = " " + tmemberType.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberType.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberType.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tmemberType.mt_TypeCode, (object) tmemberType.mt_SiteID) + " 내용 : " + tmemberType.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberType.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "mt_SiteID") && Convert.ToInt64(hashtable[(object) "mt_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "mt_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "mt_TypeCode") && Convert.ToInt32(hashtable[(object) "mt_TypeCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mt_TypeCode", hashtable[(object) "mt_TypeCode"]));
        else
          stringBuilder.Append(" AND mt_TypeCode>0");
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mt_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "mt_TypeName") && !string.IsNullOrEmpty(hashtable[(object) "mt_TypeName"].ToString()))
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "mt_TypeName", hashtable[(object) "mt_TypeName"]));
        if (hashtable.ContainsKey((object) "mt_UseYn") && !string.IsNullOrEmpty(hashtable[(object) "mt_UseYn"].ToString()))
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "mt_UseYn", hashtable[(object) "mt_UseYn"]));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && !string.IsNullOrEmpty(hashtable[(object) "_KEY_WORD_"].ToString()))
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "mt_TypeName", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "mt_Memo", hashtable[(object) "_KEY_WORD_"]));
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
        string uniMembers = UbModelBase.UNI_MEMBERS;
        string str = this.TableCode.ToString();
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniMembers = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
        }
        stringBuilder.Append(" SELECT  mt_TypeCode,mt_SiteID,mt_TypeName,mt_Memo,mt_UseYn,mt_InDate,mt_InUser,mt_ModDate,mt_ModUser");
        stringBuilder.Append(" FROM " + DbQueryHelper.ToDBNameBridge(uniMembers) + str + " " + DbQueryHelper.ToWithNolock());
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
