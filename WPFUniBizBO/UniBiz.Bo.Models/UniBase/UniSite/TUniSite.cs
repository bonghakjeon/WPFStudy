// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.UniSite.TUniSite
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

namespace UniBiz.Bo.Models.UniBase.UniSite
{
  public class TUniSite : UbModelBase<TUniSite>
  {
    private long _uis_SiteID;
    private string _uis_SiteViewCode;
    private string _uis_SiteName;
    private int _uis_SiteType;
    private int _uis_AddProperty;

    public override object _Key => (object) new object[1]
    {
      (object) this.uis_SiteID
    };

    public long uis_SiteID
    {
      get => this._uis_SiteID;
      set
      {
        this._uis_SiteID = value;
        this.Changed(nameof (uis_SiteID));
      }
    }

    public string uis_SiteViewCode
    {
      get => this._uis_SiteViewCode;
      set
      {
        this._uis_SiteViewCode = UbModelBase.LeftStr(value, 10).Replace("'", "´");
        this.Changed(nameof (uis_SiteViewCode));
        this.Changed("viewCommonCode");
      }
    }

    public string viewCommonCode => this.uis_SiteViewCode;

    public string uis_SiteName
    {
      get => this._uis_SiteName;
      set
      {
        this._uis_SiteName = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (uis_SiteName));
        this.Changed("viewCommonName");
      }
    }

    public string viewCommonName => this.uis_SiteName;

    public int uis_SiteType
    {
      get => this._uis_SiteType;
      set
      {
        this._uis_SiteType = value;
        this.Changed(nameof (uis_SiteType));
        this.Changed("uis_SiteTypeDesc");
      }
    }

    [JsonIgnore]
    public string uis_SiteTypeDesc => ((EnumSiteType) this.uis_SiteType).ToDescription();

    public int uis_AddProperty
    {
      get => this._uis_AddProperty;
      set
      {
        this._uis_AddProperty = value;
        this.Changed(nameof (uis_AddProperty));
        this.Changed("IsEmpActionLog");
        this.Changed("IsDataModLog");
      }
    }

    [JsonIgnore]
    public bool IsEmpActionLog => this.uis_AddProperty > 0 && UniSiteConverter.IsEmpActionLog(this.uis_AddProperty);

    [JsonIgnore]
    public bool IsDataModLog => this.uis_AddProperty > 0 && UniSiteConverter.IsDataModLog(this.uis_AddProperty);

    public TUniSite() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("uis_SiteID", new TTableColumn()
      {
        tc_orgin_name = "uis_SiteID",
        tc_trans_name = "사이트"
      });
      columnInfo.Add("uis_SiteViewCode", new TTableColumn()
      {
        tc_orgin_name = "uis_SiteViewCode",
        tc_trans_name = "사이트뷰코드"
      });
      columnInfo.Add("uis_SiteName", new TTableColumn()
      {
        tc_orgin_name = "uis_SiteName",
        tc_trans_name = "사이트명"
      });
      columnInfo.Add("uis_SiteType", new TTableColumn()
      {
        tc_orgin_name = "uis_SiteType",
        tc_trans_name = "사이트타입",
        tc_comm_code = 305
      });
      columnInfo.Add("uis_AddProperty", new TTableColumn()
      {
        tc_orgin_name = "uis_AddProperty",
        tc_trans_name = "속성타입"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.UniSite;
      this.uis_SiteID = 0L;
      this.uis_SiteViewCode = string.Empty;
      this.uis_SiteName = string.Empty;
      this.uis_SiteType = 3;
      this.uis_AddProperty = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TUniSite();

    public override object Clone()
    {
      TUniSite tuniSite = base.Clone() as TUniSite;
      tuniSite.uis_SiteID = this.uis_SiteID;
      tuniSite.uis_SiteViewCode = this.uis_SiteViewCode;
      tuniSite.uis_SiteName = this.uis_SiteName;
      tuniSite.uis_SiteType = this.uis_SiteType;
      tuniSite.uis_AddProperty = this.uis_AddProperty;
      return (object) tuniSite;
    }

    public void PutData(TUniSite pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.uis_SiteID = pSource.uis_SiteID;
      this.uis_SiteViewCode = pSource.uis_SiteViewCode;
      this.uis_SiteName = pSource.uis_SiteName;
      this.uis_SiteType = pSource.uis_SiteType;
      this.uis_AddProperty = pSource.uis_AddProperty;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.uis_SiteID = p_rs.GetFieldLong("uis_SiteID");
        if (this.uis_SiteID == 0L)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.uis_SiteViewCode = p_rs.GetFieldString("uis_SiteViewCode");
        this.uis_SiteName = p_rs.GetFieldString("uis_SiteName");
        this.uis_SiteType = p_rs.GetFieldInt("uis_SiteType");
        this.uis_AddProperty = p_rs.GetFieldInt("uis_AddProperty");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " uis_SiteID,uis_SiteViewCode,uis_SiteName,uis_SiteType,uis_AddProperty) VALUES ( " + string.Format(" {0}", (object) this.uis_SiteID) + ",'" + this.uis_SiteViewCode + "','" + this.uis_SiteName + "'" + string.Format(",{0},{1}", (object) this.uis_SiteType, (object) this.uis_AddProperty) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : {0}\n", (object) this.uis_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TUniSite tuniSite = this;
      // ISSUE: reference to a compiler-generated method
      tuniSite.\u003C\u003En__0();
      if (await tuniSite.OleDB.ExecuteAsync(tuniSite.InsertQuery()))
        return true;
      tuniSite.message = " " + tuniSite.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tuniSite.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tuniSite.OleDB.LastErrorID) + string.Format(" 코드 : {0}\n", (object) tuniSite.uis_SiteID) + " 내용 : " + tuniSite.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tuniSite.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " uis_SiteViewCode='" + this.uis_SiteViewCode + "',uis_SiteName='" + this.uis_SiteName + "'" + string.Format(",{0}={1}", (object) "uis_SiteType", (object) this.uis_SiteType) + string.Format(",{0}={1}", (object) "uis_AddProperty", (object) this.uis_AddProperty) + string.Format(" WHERE {0}={1}", (object) "uis_SiteID", (object) this.uis_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : {0}\n", (object) this.uis_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TUniSite tuniSite = this;
      // ISSUE: reference to a compiler-generated method
      tuniSite.\u003C\u003En__1();
      if (await tuniSite.OleDB.ExecuteAsync(tuniSite.UpdateQuery()))
        return true;
      tuniSite.message = " " + tuniSite.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tuniSite.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tuniSite.OleDB.LastErrorID) + string.Format(" 코드 : {0}\n", (object) tuniSite.uis_SiteID) + " 내용 : " + tuniSite.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tuniSite.message);
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
      stringBuilder.Append(" uis_SiteViewCode='" + this.uis_SiteViewCode + "',uis_SiteName='" + this.uis_SiteName + "'" + string.Format(",{0}={1}", (object) "uis_SiteType", (object) this.uis_SiteType));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : {0}\n", (object) this.uis_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TUniSite tuniSite = this;
      // ISSUE: reference to a compiler-generated method
      tuniSite.\u003C\u003En__1();
      if (await tuniSite.OleDB.ExecuteAsync(tuniSite.UpdateExInsertQuery()))
        return true;
      tuniSite.message = " " + tuniSite.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tuniSite.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tuniSite.OleDB.LastErrorID) + string.Format(" 코드 : {0}\n", (object) tuniSite.uis_SiteID) + " 내용 : " + tuniSite.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tuniSite.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        if (hashtable.ContainsKey((object) "uis_SiteID") && Convert.ToInt64(hashtable[(object) "uis_SiteID"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "uis_SiteID", hashtable[(object) "uis_SiteID"]));
        if (hashtable.ContainsKey((object) "uis_SiteViewCode") && hashtable[(object) "uis_SiteViewCode"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "uis_SiteViewCode", hashtable[(object) "uis_SiteViewCode"]));
        if (hashtable.ContainsKey((object) "uis_SiteName") && hashtable[(object) "uis_SiteName"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "uis_SiteName", hashtable[(object) "uis_SiteName"]));
        if (hashtable.ContainsKey((object) "uis_SiteType") && Convert.ToInt32(hashtable[(object) "uis_SiteType"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "uis_SiteType", hashtable[(object) "uis_SiteType"]));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "uis_SiteViewCode", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%')", (object) "uis_SiteName", hashtable[(object) "_KEY_WORD_"]));
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
        stringBuilder.Append(" SELECT  uis_SiteID,uis_SiteViewCode,uis_SiteName,uis_SiteType,uis_AddProperty");
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
