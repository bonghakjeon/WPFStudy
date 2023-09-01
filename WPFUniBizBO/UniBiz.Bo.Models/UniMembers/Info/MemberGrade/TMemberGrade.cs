// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.Info.MemberGrade.TMemberGrade
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

namespace UniBiz.Bo.Models.UniMembers.Info.MemberGrade
{
  public class TMemberGrade : UbModelBase<TMemberGrade>
  {
    private int _mgd_MemberGrade;
    private long _mgd_SiteID;
    private string _mgd_MemberGradeName;
    private int _mgd_SortNo;
    private string _mgd_UseYn;
    private DateTime? _mgd_InDate;
    private int _mgd_InUser;
    private DateTime? _mgd_ModDate;
    private int _mgd_ModUser;

    public override object _Key => (object) new object[1]
    {
      (object) this.mgd_MemberGrade
    };

    public int mgd_MemberGrade
    {
      get => this._mgd_MemberGrade;
      set
      {
        this._mgd_MemberGrade = value;
        this.Changed(nameof (mgd_MemberGrade));
      }
    }

    public long mgd_SiteID
    {
      get => this._mgd_SiteID;
      set
      {
        this._mgd_SiteID = value;
        this.Changed(nameof (mgd_SiteID));
      }
    }

    public string mgd_MemberGradeName
    {
      get => this._mgd_MemberGradeName;
      set
      {
        this._mgd_MemberGradeName = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (mgd_MemberGradeName));
      }
    }

    public int mgd_SortNo
    {
      get => this._mgd_SortNo;
      set
      {
        this._mgd_SortNo = value;
        this.Changed(nameof (mgd_SortNo));
      }
    }

    public string mgd_UseYn
    {
      get => this._mgd_UseYn;
      set
      {
        this._mgd_UseYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (mgd_UseYn));
        this.Changed("mgd_IsUse");
        this.Changed("mgd_UseYnDesc");
      }
    }

    public bool mgd_IsUse => "Y".Equals(this.mgd_UseYn);

    public string mgd_UseYnDesc => !"Y".Equals(this.mgd_UseYn) ? "미사용" : "사용";

    public DateTime? mgd_InDate
    {
      get => this._mgd_InDate;
      set
      {
        this._mgd_InDate = value;
        this.Changed(nameof (mgd_InDate));
      }
    }

    public int mgd_InUser
    {
      get => this._mgd_InUser;
      set
      {
        this._mgd_InUser = value;
        this.Changed(nameof (mgd_InUser));
      }
    }

    public DateTime? mgd_ModDate
    {
      get => this._mgd_ModDate;
      set
      {
        this._mgd_ModDate = value;
        this.Changed(nameof (mgd_ModDate));
      }
    }

    public int mgd_ModUser
    {
      get => this._mgd_ModUser;
      set
      {
        this._mgd_ModUser = value;
        this.Changed(nameof (mgd_ModUser));
      }
    }

    public TMemberGrade() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("mgd_MemberGrade", new TTableColumn()
      {
        tc_orgin_name = "mgd_MemberGrade",
        tc_trans_name = "회원등급코드"
      });
      columnInfo.Add("mgd_SiteID", new TTableColumn()
      {
        tc_orgin_name = "mgd_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("mgd_MemberGradeName", new TTableColumn()
      {
        tc_orgin_name = "mgd_MemberGradeName",
        tc_trans_name = "회원등급명"
      });
      columnInfo.Add("mgd_SortNo", new TTableColumn()
      {
        tc_orgin_name = "mgd_SortNo",
        tc_trans_name = "순서"
      });
      columnInfo.Add("mgd_UseYn", new TTableColumn()
      {
        tc_orgin_name = "mgd_UseYn",
        tc_trans_name = "사용구분"
      });
      columnInfo.Add("mgd_InDate", new TTableColumn()
      {
        tc_orgin_name = "mgd_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("mgd_InUser", new TTableColumn()
      {
        tc_orgin_name = "mgd_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("mgd_ModDate", new TTableColumn()
      {
        tc_orgin_name = "mgd_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("mgd_ModUser", new TTableColumn()
      {
        tc_orgin_name = "mgd_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.MemberGrade;
      this.mgd_MemberGrade = 0;
      this.mgd_SiteID = 0L;
      this.mgd_MemberGradeName = string.Empty;
      this.mgd_SortNo = 0;
      this.mgd_UseYn = "Y";
      this.mgd_InDate = new DateTime?();
      this.mgd_InUser = 0;
      this.mgd_ModDate = new DateTime?();
      this.mgd_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TMemberGrade();

    public override object Clone()
    {
      TMemberGrade tmemberGrade = base.Clone() as TMemberGrade;
      tmemberGrade.mgd_MemberGrade = this.mgd_MemberGrade;
      tmemberGrade.mgd_SiteID = this.mgd_SiteID;
      tmemberGrade.mgd_MemberGradeName = this.mgd_MemberGradeName;
      tmemberGrade.mgd_SortNo = this.mgd_SortNo;
      tmemberGrade.mgd_UseYn = this.mgd_UseYn;
      tmemberGrade.mgd_InDate = this.mgd_InDate;
      tmemberGrade.mgd_InUser = this.mgd_InUser;
      tmemberGrade.mgd_ModDate = this.mgd_ModDate;
      tmemberGrade.mgd_ModUser = this.mgd_ModUser;
      return (object) tmemberGrade;
    }

    public void PutData(TMemberGrade pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.mgd_MemberGrade = pSource.mgd_MemberGrade;
      this.mgd_SiteID = pSource.mgd_SiteID;
      this.mgd_MemberGradeName = pSource.mgd_MemberGradeName;
      this.mgd_SortNo = pSource.mgd_SortNo;
      this.mgd_UseYn = pSource.mgd_UseYn;
      this.mgd_InDate = pSource.mgd_InDate;
      this.mgd_InUser = pSource.mgd_InUser;
      this.mgd_ModDate = pSource.mgd_ModDate;
      this.mgd_ModUser = pSource.mgd_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.mgd_MemberGrade = p_rs.GetFieldInt("mgd_MemberGrade");
        if (this.mgd_MemberGrade == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.mgd_SiteID = p_rs.GetFieldLong("mgd_SiteID");
        this.mgd_MemberGradeName = p_rs.GetFieldString("mgd_MemberGradeName");
        this.mgd_SortNo = p_rs.GetFieldInt("mgd_SortNo");
        this.mgd_UseYn = p_rs.GetFieldString("mgd_UseYn");
        this.mgd_InDate = p_rs.GetFieldDateTime("mgd_InDate");
        this.mgd_InUser = p_rs.GetFieldInt("mgd_InUser");
        this.mgd_ModDate = p_rs.GetFieldDateTime("mgd_ModDate");
        this.mgd_ModUser = p_rs.GetFieldInt("mgd_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode) + " mgd_MemberGrade,mgd_SiteID,mgd_MemberGradeName,mgd_SortNo,mgd_UseYn,mgd_InDate,mgd_InUser,mgd_ModDate,mgd_ModUser) VALUES ( " + string.Format(" {0}", (object) this.mgd_MemberGrade) + string.Format(",{0}", (object) this.mgd_SiteID) + string.Format(",'{0}',{1},'{2}'", (object) this.mgd_MemberGradeName, (object) this.mgd_SortNo, (object) this.mgd_UseYn) + string.Format(",{0},{1}", (object) this.mgd_InDate.GetDateToStrInNull(), (object) this.mgd_InUser) + string.Format(",{0},{1}", (object) this.mgd_ModDate.GetDateToStrInNull(), (object) this.mgd_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.mgd_MemberGrade, (object) this.mgd_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TMemberGrade tmemberGrade = this;
      // ISSUE: reference to a compiler-generated method
      tmemberGrade.\u003C\u003En__0();
      if (await tmemberGrade.OleDB.ExecuteAsync(tmemberGrade.InsertQuery()))
        return true;
      tmemberGrade.message = " " + tmemberGrade.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberGrade.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberGrade.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tmemberGrade.mgd_MemberGrade, (object) tmemberGrade.mgd_SiteID) + " 내용 : " + tmemberGrade.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberGrade.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode) + " mgd_MemberGradeName='" + this.mgd_MemberGradeName + "'" + string.Format(",{0}={1}", (object) "mgd_SortNo", (object) this.mgd_SortNo) + ",mgd_UseYn='" + this.mgd_UseYn + "'" + string.Format(",{0}={1},{2}={3}", (object) "mgd_ModDate", (object) this.mgd_ModDate.GetDateToStrInNull(), (object) "mgd_ModUser", (object) this.mgd_ModUser) + string.Format(" WHERE {0}={1}", (object) "mgd_MemberGrade", (object) this.mgd_MemberGrade) + string.Format(" AND {0}={1}", (object) "mgd_SiteID", (object) this.mgd_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.mgd_MemberGrade, (object) this.mgd_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TMemberGrade tmemberGrade = this;
      // ISSUE: reference to a compiler-generated method
      tmemberGrade.\u003C\u003En__1();
      if (await tmemberGrade.OleDB.ExecuteAsync(tmemberGrade.UpdateQuery()))
        return true;
      tmemberGrade.message = " " + tmemberGrade.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberGrade.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberGrade.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tmemberGrade.mgd_MemberGrade, (object) tmemberGrade.mgd_SiteID) + " 내용 : " + tmemberGrade.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberGrade.message);
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
      stringBuilder.Append(" mgd_MemberGradeName='" + this.mgd_MemberGradeName + "'" + string.Format(",{0}={1}", (object) "mgd_SortNo", (object) this.mgd_SortNo) + ",mgd_UseYn='" + this.mgd_UseYn + "'" + string.Format(",{0}={1},{2}={3}", (object) "mgd_ModDate", (object) this.mgd_ModDate.GetDateToStrInNull(), (object) "mgd_ModUser", (object) this.mgd_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.mgd_MemberGrade, (object) this.mgd_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TMemberGrade tmemberGrade = this;
      // ISSUE: reference to a compiler-generated method
      tmemberGrade.\u003C\u003En__1();
      if (await tmemberGrade.OleDB.ExecuteAsync(tmemberGrade.UpdateExInsertQuery()))
        return true;
      tmemberGrade.message = " " + tmemberGrade.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberGrade.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberGrade.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tmemberGrade.mgd_MemberGrade, (object) tmemberGrade.mgd_SiteID) + " 내용 : " + tmemberGrade.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberGrade.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "mgd_SiteID") && Convert.ToInt64(hashtable[(object) "mgd_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "mgd_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "mgd_MemberGrade") && Convert.ToInt32(hashtable[(object) "mgd_MemberGrade"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mgd_MemberGrade", hashtable[(object) "mgd_MemberGrade"]));
        else
          stringBuilder.Append(" AND mgd_MemberGrade>0");
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mgd_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "mgd_MemberGradeName") && !string.IsNullOrEmpty(hashtable[(object) "mgd_MemberGradeName"].ToString()))
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "mgd_MemberGradeName", hashtable[(object) "mgd_MemberGradeName"]));
        if (hashtable.ContainsKey((object) "mgd_UseYn") && !string.IsNullOrEmpty(hashtable[(object) "mgd_UseYn"].ToString()))
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "mgd_UseYn", hashtable[(object) "mgd_UseYn"]));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && !string.IsNullOrEmpty(hashtable[(object) "_KEY_WORD_"].ToString()))
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "mgd_MemberGradeName", hashtable[(object) "_KEY_WORD_"]));
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
        stringBuilder.Append(" SELECT  mgd_MemberGrade,mgd_SiteID,mgd_MemberGradeName,mgd_SortNo,mgd_UseYn,mgd_InDate,mgd_InUser,mgd_ModDate,mgd_ModUser");
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
