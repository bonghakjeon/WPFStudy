// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Employee.EmpAuthority.TEmpAuthority
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

namespace UniBiz.Bo.Models.UniBase.Employee.EmpAuthority
{
  public class TEmpAuthority : UbModelBase<TEmpAuthority>
  {
    private int _ea_EmpCode;
    private int _ea_AuthType;
    private string _ea_AuthValue;
    private long _ea_SiteID;
    private string _ea_InputYn;
    private string _ea_PrintYn;

    public override object _Key => (object) new object[3]
    {
      (object) this.ea_EmpCode,
      (object) this.ea_AuthType,
      (object) this.ea_AuthValue
    };

    public int ea_EmpCode
    {
      get => this._ea_EmpCode;
      set
      {
        this._ea_EmpCode = value;
        this.Changed(nameof (ea_EmpCode));
      }
    }

    public int ea_AuthType
    {
      get => this._ea_AuthType;
      set
      {
        this._ea_AuthType = value;
        this.Changed(nameof (ea_AuthType));
      }
    }

    public string ea_AuthValue
    {
      get => this._ea_AuthValue;
      set
      {
        this._ea_AuthValue = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (ea_AuthValue));
      }
    }

    public long ea_SiteID
    {
      get => this._ea_SiteID;
      set
      {
        this._ea_SiteID = value;
        this.Changed(nameof (ea_SiteID));
      }
    }

    public string ea_InputYn
    {
      get => this._ea_InputYn;
      set
      {
        this._ea_InputYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (ea_InputYn));
        this.Changed("ea_IsInputYn");
        this.Changed("ea_InputYnDesc");
      }
    }

    public bool ea_IsInputYn => "Y".Equals(this.ea_InputYn);

    public string ea_InputYnDesc => !"Y".Equals(this.ea_InputYn) ? "미사용" : "사용";

    public string ea_PrintYn
    {
      get => this._ea_PrintYn;
      set
      {
        this._ea_PrintYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (ea_PrintYn));
        this.Changed("ea_IsPrintYn");
        this.Changed("ea_PrintYnDesc");
      }
    }

    public bool ea_IsPrintYn => "Y".Equals(this.ea_PrintYn);

    public string ea_PrintYnDesc => !"Y".Equals(this.ea_PrintYn) ? "미사용" : "사용";

    public TEmpAuthority() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("ea_EmpCode", new TTableColumn()
      {
        tc_orgin_name = "ea_EmpCode",
        tc_trans_name = "사원코드"
      });
      columnInfo.Add("ea_AuthType", new TTableColumn()
      {
        tc_orgin_name = "ea_AuthType",
        tc_trans_name = "타입(지점,분류,거래처)"
      });
      columnInfo.Add("ea_AuthValue", new TTableColumn()
      {
        tc_orgin_name = "ea_AuthValue",
        tc_trans_name = "허용코드"
      });
      columnInfo.Add("ea_SiteID", new TTableColumn()
      {
        tc_orgin_name = "ea_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("ea_InputYn", new TTableColumn()
      {
        tc_orgin_name = "ea_InputYn",
        tc_trans_name = "입력여부"
      });
      columnInfo.Add("ea_PrintYn", new TTableColumn()
      {
        tc_orgin_name = "ea_PrintYn",
        tc_trans_name = "출력여부"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.EmpAuthority;
      this.ea_EmpCode = this.ea_AuthType = 0;
      this.ea_AuthValue = string.Empty;
      this.ea_SiteID = 0L;
      this.ea_InputYn = "N";
      this.ea_PrintYn = "N";
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TEmpAuthority();

    public override object Clone()
    {
      TEmpAuthority tempAuthority = base.Clone() as TEmpAuthority;
      tempAuthority.ea_EmpCode = this.ea_EmpCode;
      tempAuthority.ea_AuthType = this.ea_AuthType;
      tempAuthority.ea_AuthValue = this.ea_AuthValue;
      tempAuthority.ea_SiteID = this.ea_SiteID;
      tempAuthority.ea_InputYn = this.ea_InputYn;
      tempAuthority.ea_PrintYn = this.ea_PrintYn;
      return (object) tempAuthority;
    }

    public void PutData(TEmpAuthority pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.ea_EmpCode = pSource.ea_EmpCode;
      this.ea_AuthType = pSource.ea_AuthType;
      this.ea_AuthValue = pSource.ea_AuthValue;
      this.ea_SiteID = pSource.ea_SiteID;
      this.ea_InputYn = pSource.ea_InputYn;
      this.ea_PrintYn = pSource.ea_PrintYn;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.ea_EmpCode = p_rs.GetFieldInt("ea_EmpCode");
        if (this.ea_EmpCode == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.ea_AuthType = p_rs.GetFieldInt("ea_AuthType");
        this.ea_AuthValue = p_rs.GetFieldString("ea_AuthValue");
        this.ea_SiteID = p_rs.GetFieldLong("ea_SiteID");
        this.ea_InputYn = p_rs.GetFieldString("ea_InputYn");
        this.ea_PrintYn = p_rs.GetFieldString("ea_PrintYn");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " ea_EmpCode,ea_AuthType,ea_AuthValue,ea_SiteID,ea_InputYn,ea_PrintYn) VALUES ( " + string.Format(" {0},{1},'{2}'", (object) this.ea_EmpCode, (object) this.ea_AuthType, (object) this.ea_AuthValue) + string.Format(",{0}", (object) this.ea_SiteID) + ",'" + this.ea_InputYn + "','" + this.ea_PrintYn + "')";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.ea_AuthType, (object) this.ea_EmpCode, (object) this.ea_AuthValue, (object) this.ea_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TEmpAuthority tempAuthority = this;
      // ISSUE: reference to a compiler-generated method
      tempAuthority.\u003C\u003En__0();
      if (await tempAuthority.OleDB.ExecuteAsync(tempAuthority.InsertQuery()))
        return true;
      tempAuthority.message = " " + tempAuthority.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tempAuthority.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tempAuthority.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tempAuthority.ea_AuthType, (object) tempAuthority.ea_EmpCode, (object) tempAuthority.ea_AuthValue, (object) tempAuthority.ea_SiteID) + " 내용 : " + tempAuthority.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tempAuthority.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " ea_InputYn='" + this.ea_InputYn + "',ea_PrintYn='" + this.ea_PrintYn + "'" + string.Format(" WHERE {0}={1}", (object) "ea_EmpCode", (object) this.ea_EmpCode) + string.Format(" AND {0}={1}", (object) "ea_AuthType", (object) this.ea_AuthType) + " AND ea_AuthValue=" + this.ea_AuthValue + string.Format(" AND {0}={1}", (object) "ea_SiteID", (object) this.ea_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.ea_AuthType, (object) this.ea_EmpCode, (object) this.ea_AuthValue, (object) this.ea_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TEmpAuthority tempAuthority = this;
      // ISSUE: reference to a compiler-generated method
      tempAuthority.\u003C\u003En__1();
      if (await tempAuthority.OleDB.ExecuteAsync(tempAuthority.UpdateQuery()))
        return true;
      tempAuthority.message = " " + tempAuthority.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tempAuthority.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tempAuthority.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tempAuthority.ea_AuthType, (object) tempAuthority.ea_EmpCode, (object) tempAuthority.ea_AuthValue, (object) tempAuthority.ea_SiteID) + " 내용 : " + tempAuthority.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tempAuthority.message);
      return false;
    }

    public override string DeleteQuery() => string.Format(" DELETE FROM {0}{1}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + string.Format(" WHERE {0}={1}", (object) "ea_EmpCode", (object) this.ea_EmpCode) + string.Format(" AND {0}={1}", (object) "ea_AuthType", (object) this.ea_AuthType) + " AND ea_AuthValue=" + this.ea_AuthValue;

    public override bool Delete()
    {
      this.InsertChecked();
      string pStrExec = this.DeleteQuery();
      if (this.OleDB.Execute(pStrExec))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 삭제 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.ea_AuthType, (object) this.ea_EmpCode, (object) this.ea_AuthValue, (object) this.ea_SiteID) + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n 쿼리 : " + pStrExec + "\n--------------------------------------------------------------------------------------------------\n";
      return false;
    }

    public override async Task<bool> DeleteAsync()
    {
      TEmpAuthority tempAuthority = this;
      // ISSUE: reference to a compiler-generated method
      tempAuthority.\u003C\u003En__0();
      if (await tempAuthority.OleDB.ExecuteAsync(tempAuthority.DeleteQuery()))
        return true;
      tempAuthority.message = " " + tempAuthority.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tempAuthority.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tempAuthority.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tempAuthority.ea_AuthType, (object) tempAuthority.ea_EmpCode, (object) tempAuthority.ea_AuthValue, (object) tempAuthority.ea_SiteID) + " 내용 : " + tempAuthority.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tempAuthority.message);
      return false;
    }

    public virtual string DeleteQuery(
      int p_ea_EmpCode,
      int p_ea_AuthType,
      string p_ea_AuthValue,
      long p_ea_SiteID = 0)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format(" DELETE FROM {0}{1} ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode));
      stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "ea_EmpCode", (object) p_ea_EmpCode));
      stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ea_AuthType", (object) p_ea_AuthType));
      if (!string.IsNullOrEmpty(p_ea_AuthValue))
        stringBuilder.Append(" AND ea_AuthValue=" + p_ea_AuthValue);
      if (p_ea_SiteID > 0L)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ea_SiteID", (object) p_ea_SiteID));
      return stringBuilder.ToString();
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "ea_SiteID") && Convert.ToInt64(hashtable[(object) "ea_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "ea_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "ea_AuthType") && Convert.ToInt32(hashtable[(object) "ea_AuthType"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ea_AuthType", hashtable[(object) "ea_AuthType"]));
        if (hashtable.ContainsKey((object) "ea_EmpCode") && Convert.ToInt32(hashtable[(object) "ea_EmpCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ea_EmpCode", hashtable[(object) "ea_EmpCode"]));
        if (hashtable.ContainsKey((object) "ea_AuthValue") && hashtable[(object) "ea_AuthValue"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "ea_AuthValue", hashtable[(object) "ea_AuthValue"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ea_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "ea_InputYn") && hashtable[(object) "ea_InputYn"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "ea_InputYn", hashtable[(object) "ea_InputYn"]));
        if (hashtable.ContainsKey((object) "ea_PrintYn") && hashtable[(object) "ea_PrintYn"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "ea_PrintYn", hashtable[(object) "ea_PrintYn"]));
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
        stringBuilder.Append(" SELECT  ea_AuthType,ea_EmpCode,ea_AuthValue,ea_SiteID,ea_InputYn,ea_PrintYn");
        stringBuilder.Append(" FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock());
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) ex.GetHashCode()) + " 내용 : " + ex.Message + "\n" + string.Format(" Query : {0}\n", (object) stringBuilder) + "--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
        stringBuilder.Clear();
      }
      return stringBuilder.ToString();
    }
  }
}
