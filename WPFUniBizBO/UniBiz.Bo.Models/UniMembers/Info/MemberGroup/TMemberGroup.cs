// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.Info.MemberGroup.TMemberGroup
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

namespace UniBiz.Bo.Models.UniMembers.Info.MemberGroup
{
  public class TMemberGroup : UbModelBase<TMemberGroup>
  {
    private string _mg_GroupCode;
    private long _mg_SiteID;
    private string _mg_GroupName;
    private int _mg_GroupDepth;
    private string _mg_UseYn;
    private DateTime? _mg_InDate;
    private int _mg_InUser;
    private DateTime? _mg_ModDate;
    private int _mg_ModUser;

    public override object _Key => (object) new object[2]
    {
      (object) this.mg_GroupCode,
      (object) this.mg_SiteID
    };

    public string mg_GroupCode
    {
      get => this._mg_GroupCode;
      set
      {
        this._mg_GroupCode = UbModelBase.LeftStr(value, 6).Replace("'", "´");
        this.Changed(nameof (mg_GroupCode));
      }
    }

    public long mg_SiteID
    {
      get => this._mg_SiteID;
      set
      {
        this._mg_SiteID = value;
        this.Changed(nameof (mg_SiteID));
      }
    }

    public string mg_GroupName
    {
      get => this._mg_GroupName;
      set
      {
        this._mg_GroupName = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (mg_GroupName));
      }
    }

    public int mg_GroupDepth
    {
      get => this._mg_GroupDepth;
      set
      {
        this._mg_GroupDepth = value;
        this.Changed(nameof (mg_GroupDepth));
      }
    }

    public string mg_UseYn
    {
      get => this._mg_UseYn;
      set
      {
        this._mg_UseYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (mg_UseYn));
        this.Changed("mg_IsUse");
        this.Changed("mg_UseYnDesc");
      }
    }

    public bool mg_IsUse => "Y".Equals(this.mg_UseYn);

    public string mg_UseYnDesc => !"Y".Equals(this.mg_UseYn) ? "미사용" : "사용";

    public DateTime? mg_InDate
    {
      get => this._mg_InDate;
      set
      {
        this._mg_InDate = value;
        this.Changed(nameof (mg_InDate));
      }
    }

    public int mg_InUser
    {
      get => this._mg_InUser;
      set
      {
        this._mg_InUser = value;
        this.Changed(nameof (mg_InUser));
      }
    }

    public DateTime? mg_ModDate
    {
      get => this._mg_ModDate;
      set
      {
        this._mg_ModDate = value;
        this.Changed(nameof (mg_ModDate));
      }
    }

    public int mg_ModUser
    {
      get => this._mg_ModUser;
      set
      {
        this._mg_ModUser = value;
        this.Changed(nameof (mg_ModUser));
      }
    }

    public TMemberGroup() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("mg_GroupCode", new TTableColumn()
      {
        tc_orgin_name = "mg_GroupCode",
        tc_trans_name = "코드"
      });
      columnInfo.Add("mg_SiteID", new TTableColumn()
      {
        tc_orgin_name = "mg_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("mg_GroupName", new TTableColumn()
      {
        tc_orgin_name = "mg_GroupName",
        tc_trans_name = "명칭"
      });
      columnInfo.Add("mg_GroupDepth", new TTableColumn()
      {
        tc_orgin_name = "mg_GroupDepth",
        tc_trans_name = "단계(대/중)"
      });
      columnInfo.Add("mg_UseYn", new TTableColumn()
      {
        tc_orgin_name = "mg_UseYn",
        tc_trans_name = "사용구분"
      });
      columnInfo.Add("mg_InDate", new TTableColumn()
      {
        tc_orgin_name = "mg_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("mg_InUser", new TTableColumn()
      {
        tc_orgin_name = "mg_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("mg_ModDate", new TTableColumn()
      {
        tc_orgin_name = "mg_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("mg_ModUser", new TTableColumn()
      {
        tc_orgin_name = "mg_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.MemberGroup;
      this.mg_GroupCode = string.Empty;
      this.mg_SiteID = 0L;
      this.mg_GroupName = string.Empty;
      this.mg_GroupDepth = 0;
      this.mg_UseYn = "Y";
      this.mg_InDate = new DateTime?();
      this.mg_InUser = 0;
      this.mg_ModDate = new DateTime?();
      this.mg_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TMemberGroup();

    public override object Clone()
    {
      TMemberGroup tmemberGroup = base.Clone() as TMemberGroup;
      tmemberGroup.mg_GroupCode = this.mg_GroupCode;
      tmemberGroup.mg_SiteID = this.mg_SiteID;
      tmemberGroup.mg_GroupName = this.mg_GroupName;
      tmemberGroup.mg_GroupDepth = this.mg_GroupDepth;
      tmemberGroup.mg_UseYn = this.mg_UseYn;
      tmemberGroup.mg_InDate = this.mg_InDate;
      tmemberGroup.mg_InUser = this.mg_InUser;
      tmemberGroup.mg_ModDate = this.mg_ModDate;
      tmemberGroup.mg_ModUser = this.mg_ModUser;
      return (object) tmemberGroup;
    }

    public void PutData(TMemberGroup pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.mg_GroupCode = pSource.mg_GroupCode;
      this.mg_SiteID = pSource.mg_SiteID;
      this.mg_GroupName = pSource.mg_GroupName;
      this.mg_GroupDepth = pSource.mg_GroupDepth;
      this.mg_UseYn = pSource.mg_UseYn;
      this.mg_InDate = pSource.mg_InDate;
      this.mg_InUser = pSource.mg_InUser;
      this.mg_ModDate = pSource.mg_ModDate;
      this.mg_ModUser = pSource.mg_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.mg_GroupCode = p_rs.GetFieldString("mg_GroupCode");
        this.mg_SiteID = p_rs.GetFieldLong("mg_SiteID");
        if (this.mg_SiteID == 0L)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.mg_GroupName = p_rs.GetFieldString("mg_GroupName");
        this.mg_GroupDepth = p_rs.GetFieldInt("mg_GroupDepth");
        this.mg_UseYn = p_rs.GetFieldString("mg_UseYn");
        this.mg_InDate = p_rs.GetFieldDateTime("mg_InDate");
        this.mg_InUser = p_rs.GetFieldInt("mg_InUser");
        this.mg_ModDate = p_rs.GetFieldDateTime("mg_ModDate");
        this.mg_ModUser = p_rs.GetFieldInt("mg_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode) + " mg_GroupCode,mg_SiteID,mg_GroupName,mg_GroupDepth,mg_UseYn,mg_InDate,mg_InUser,mg_ModDate,mg_ModUser) VALUES (  '" + this.mg_GroupCode + "'" + string.Format(",{0}", (object) this.mg_SiteID) + string.Format(",'{0}',{1},'{2}'", (object) this.mg_GroupName, (object) this.mg_GroupDepth, (object) this.mg_UseYn) + string.Format(",{0},{1}", (object) this.mg_InDate.GetDateToStrInNull(), (object) this.mg_InUser) + string.Format(",{0},{1}", (object) this.mg_ModDate.GetDateToStrInNull(), (object) this.mg_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.mg_GroupCode, (object) this.mg_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TMemberGroup tmemberGroup = this;
      // ISSUE: reference to a compiler-generated method
      tmemberGroup.\u003C\u003En__0();
      if (await tmemberGroup.OleDB.ExecuteAsync(tmemberGroup.InsertQuery()))
        return true;
      tmemberGroup.message = " " + tmemberGroup.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberGroup.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberGroup.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tmemberGroup.mg_GroupCode, (object) tmemberGroup.mg_SiteID) + " 내용 : " + tmemberGroup.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberGroup.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode) + " mg_GroupName='" + this.mg_GroupName + "'" + string.Format(",{0}={1}", (object) "mg_GroupDepth", (object) this.mg_GroupDepth) + ",mg_UseYn='" + this.mg_UseYn + "'" + string.Format(",{0}={1},{2}={3}", (object) "mg_ModDate", (object) this.mg_ModDate.GetDateToStrInNull(), (object) "mg_ModUser", (object) this.mg_ModUser) + " WHERE mg_GroupCode='" + this.mg_GroupCode + "'" + string.Format(" AND {0}={1}", (object) "mg_SiteID", (object) this.mg_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.mg_GroupCode, (object) this.mg_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TMemberGroup tmemberGroup = this;
      // ISSUE: reference to a compiler-generated method
      tmemberGroup.\u003C\u003En__1();
      if (await tmemberGroup.OleDB.ExecuteAsync(tmemberGroup.UpdateQuery()))
        return true;
      tmemberGroup.message = " " + tmemberGroup.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberGroup.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberGroup.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tmemberGroup.mg_GroupCode, (object) tmemberGroup.mg_SiteID) + " 내용 : " + tmemberGroup.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberGroup.message);
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
      stringBuilder.Append(" mg_GroupName='" + this.mg_GroupName + "'" + string.Format(",{0}={1}", (object) "mg_GroupDepth", (object) this.mg_GroupDepth) + ",mg_UseYn='" + this.mg_UseYn + "'" + string.Format(",{0}={1},{2}={3}", (object) "mg_ModDate", (object) this.mg_ModDate.GetDateToStrInNull(), (object) "mg_ModUser", (object) this.mg_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.mg_GroupCode, (object) this.mg_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TMemberGroup tmemberGroup = this;
      // ISSUE: reference to a compiler-generated method
      tmemberGroup.\u003C\u003En__1();
      if (await tmemberGroup.OleDB.ExecuteAsync(tmemberGroup.UpdateExInsertQuery()))
        return true;
      tmemberGroup.message = " " + tmemberGroup.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberGroup.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberGroup.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tmemberGroup.mg_GroupCode, (object) tmemberGroup.mg_SiteID) + " 내용 : " + tmemberGroup.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberGroup.message);
      return false;
    }

    public override string DeleteQuery() => string.Format(" DELETE FROM {0}{1}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode) + " WHERE mg_GroupCode='" + this.mg_GroupCode + "'" + string.Format(" AND {0}={1}", (object) "mg_SiteID", (object) this.mg_SiteID);

    public override bool Delete()
    {
      this.InsertChecked();
      string pStrExec = this.DeleteQuery();
      if (this.OleDB.Execute(pStrExec))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 삭제 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 코드 : ({0},{1})\n", (object) this.mg_GroupCode, (object) this.mg_SiteID) + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n 쿼리 : " + pStrExec + "\n--------------------------------------------------------------------------------------------------\n";
      return false;
    }

    public override async Task<bool> DeleteAsync()
    {
      TMemberGroup tmemberGroup = this;
      // ISSUE: reference to a compiler-generated method
      tmemberGroup.\u003C\u003En__0();
      if (await tmemberGroup.OleDB.ExecuteAsync(tmemberGroup.DeleteQuery()))
        return true;
      tmemberGroup.message = " " + tmemberGroup.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberGroup.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberGroup.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tmemberGroup.mg_GroupCode, (object) tmemberGroup.mg_SiteID) + " 내용 : " + tmemberGroup.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberGroup.message);
      return false;
    }

    public virtual string DeleteQuery(string p_mg_GroupCode, long p_mg_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format(" DELETE FROM {0}{1} ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode));
      stringBuilder.Append(" WHERE mg_GroupCode=" + p_mg_GroupCode);
      if (p_mg_SiteID > 0L)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mg_SiteID", (object) p_mg_SiteID));
      return stringBuilder.ToString();
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "mg_SiteID") && Convert.ToInt64(hashtable[(object) "mg_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "mg_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "mg_GroupCode") && !string.IsNullOrEmpty(hashtable[(object) "mg_GroupCode"].ToString()))
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "mg_GroupCode", hashtable[(object) "mg_GroupCode"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mg_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "mg_GroupName") && !string.IsNullOrEmpty(hashtable[(object) "mg_GroupName"].ToString()))
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "mg_GroupName", hashtable[(object) "mg_GroupName"]));
        if (hashtable.ContainsKey((object) "mg_GroupDepth") && Convert.ToInt32(hashtable[(object) "mg_GroupDepth"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mg_GroupDepth", hashtable[(object) "mg_GroupDepth"]));
        if (hashtable.ContainsKey((object) "mg_UseYn") && !string.IsNullOrEmpty(hashtable[(object) "mg_UseYn"].ToString()))
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "mg_UseYn", hashtable[(object) "mg_UseYn"]));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && !string.IsNullOrEmpty(hashtable[(object) "_KEY_WORD_"].ToString()))
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "mg_GroupName", hashtable[(object) "_KEY_WORD_"]));
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
        stringBuilder.Append(" SELECT  mg_GroupCode,mg_SiteID,mg_GroupName,mg_GroupDepth,mg_UseYn,mg_InDate,mg_InUser,mg_ModDate,mg_ModUser");
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
