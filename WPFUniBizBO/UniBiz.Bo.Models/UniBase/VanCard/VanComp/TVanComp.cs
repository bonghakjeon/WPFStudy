// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.VanCard.VanComp.TVanComp
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

namespace UniBiz.Bo.Models.UniBase.VanCard.VanComp
{
  public class TVanComp : UbModelBase<TVanComp>
  {
    private int _van_ID;
    public long _van_SiteID;
    private string _van_Name;
    private string _van_AcroNm;
    private int _van_Type;
    private string _van_UseYn;
    private DateTime? _van_InDate;
    private int _van_InUser;
    private DateTime? _van_ModDate;
    private int _van_ModUser;

    public override object _Key => (object) new object[1]
    {
      (object) this.van_ID
    };

    public int van_ID
    {
      get => this._van_ID;
      set
      {
        this._van_ID = value;
        this.Changed(nameof (van_ID));
      }
    }

    public long van_SiteID
    {
      get => this._van_SiteID;
      set
      {
        this._van_SiteID = value;
        this.Changed(nameof (van_SiteID));
      }
    }

    public string van_Name
    {
      get => this._van_Name;
      set
      {
        this._van_Name = value;
        this.Changed(nameof (van_Name));
      }
    }

    public string van_AcroNm
    {
      get => this._van_AcroNm;
      set
      {
        this._van_AcroNm = value;
        this.Changed(nameof (van_AcroNm));
      }
    }

    public int van_Type
    {
      get => this._van_Type;
      set
      {
        this._van_Type = value;
        this.Changed(nameof (van_Type));
      }
    }

    public string van_UseYn
    {
      get => this._van_UseYn;
      set
      {
        this._van_UseYn = value;
        this.Changed(nameof (van_UseYn));
        this.Changed("van_IsUse");
      }
    }

    public bool van_IsUse => this.van_UseYn.Equals("Y");

    public DateTime? van_InDate
    {
      get => this._van_InDate;
      set
      {
        this._van_InDate = value;
        this.Changed(nameof (van_InDate));
      }
    }

    public int van_InUser
    {
      get => this._van_InUser;
      set
      {
        this._van_InUser = value;
        this.Changed(nameof (van_InUser));
      }
    }

    public DateTime? van_ModDate
    {
      get => this._van_ModDate;
      set
      {
        this._van_ModDate = value;
        this.Changed(nameof (van_ModDate));
      }
    }

    public int van_ModUser
    {
      get => this._van_ModUser;
      set
      {
        this._van_ModUser = value;
        this.Changed(nameof (van_ModUser));
      }
    }

    public TVanComp() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("van_ID", new TTableColumn()
      {
        tc_orgin_name = "van_ID",
        tc_trans_name = "밴사"
      });
      columnInfo.Add("van_SiteID", new TTableColumn()
      {
        tc_orgin_name = "van_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("van_Name", new TTableColumn()
      {
        tc_orgin_name = "van_Name",
        tc_trans_name = "밴사명"
      });
      columnInfo.Add("van_AcroNm", new TTableColumn()
      {
        tc_orgin_name = "van_AcroNm",
        tc_trans_name = "단축명"
      });
      columnInfo.Add("van_Type", new TTableColumn()
      {
        tc_orgin_name = "van_Type",
        tc_trans_name = "밴Type"
      });
      columnInfo.Add("van_UseYn", new TTableColumn()
      {
        tc_orgin_name = "van_UseYn",
        tc_trans_name = "사용상태"
      });
      columnInfo.Add("van_InDate", new TTableColumn()
      {
        tc_orgin_name = "van_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("van_InUser", new TTableColumn()
      {
        tc_orgin_name = "van_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("van_ModDate", new TTableColumn()
      {
        tc_orgin_name = "van_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("van_ModUser", new TTableColumn()
      {
        tc_orgin_name = "van_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.VanComp;
      this.van_ID = 0;
      this.van_SiteID = 0L;
      this.van_Name = string.Empty;
      this.van_AcroNm = string.Empty;
      this.van_Type = 0;
      this.van_UseYn = "Y";
      this.van_InDate = new DateTime?();
      this.van_InUser = 0;
      this.van_ModDate = new DateTime?();
      this.van_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TVanComp();

    public override object Clone()
    {
      TVanComp tvanComp = base.Clone() as TVanComp;
      tvanComp.van_ID = this.van_ID;
      tvanComp.van_SiteID = this.van_SiteID;
      tvanComp.van_Name = this.van_Name;
      tvanComp.van_AcroNm = this.van_AcroNm;
      tvanComp.van_Type = this.van_Type;
      tvanComp.van_UseYn = this.van_UseYn;
      tvanComp.van_InDate = this.van_InDate;
      tvanComp.van_InUser = this.van_InUser;
      tvanComp.van_ModDate = this.van_ModDate;
      tvanComp.van_ModUser = this.van_ModUser;
      return (object) tvanComp;
    }

    public void PutData(TVanComp pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.van_ID = pSource.van_ID;
      this.van_SiteID = pSource.van_SiteID;
      this.van_Name = pSource.van_Name;
      this.van_AcroNm = pSource.van_AcroNm;
      this.van_Type = pSource.van_Type;
      this.van_UseYn = pSource.van_UseYn;
      this.van_InDate = pSource.van_InDate;
      this.van_InUser = pSource.van_InUser;
      this.van_ModDate = pSource.van_ModDate;
      this.van_ModUser = pSource.van_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.van_ID = p_rs.GetFieldInt("van_ID");
        if (this.van_ID == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.van_SiteID = (long) p_rs.GetFieldInt("van_SiteID");
        this.van_Name = p_rs.GetFieldString("van_Name");
        this.van_AcroNm = p_rs.GetFieldString("van_AcroNm");
        this.van_Type = p_rs.GetFieldInt("van_Type");
        this.van_UseYn = p_rs.GetFieldString("van_UseYn");
        this.van_InDate = p_rs.GetFieldDateTime("van_InDate");
        this.van_InUser = p_rs.GetFieldInt("van_InUser");
        this.van_ModDate = p_rs.GetFieldDateTime("van_ModDate");
        this.van_ModUser = p_rs.GetFieldInt("van_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " van_ID,van_SiteID,van_Name,van_AcroNm,van_Type,van_UseYn,van_InDate,van_InUser,van_ModDate,van_ModUser) VALUES ( " + string.Format(" {0}", (object) this.van_ID) + string.Format(",{0}", (object) this.van_SiteID) + string.Format(",'{0}','{1}',{2},'{3}'", (object) this.van_Name, (object) this.van_AcroNm, (object) this.van_Type, (object) this.van_UseYn) + string.Format(",{0},{1}", (object) this.van_InDate.GetDateToStrInNull(), (object) this.van_InUser) + string.Format(",{0},{1}", (object) this.van_ModDate.GetDateToStrInNull(), (object) this.van_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.van_ID, (object) this.van_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TVanComp tvanComp = this;
      // ISSUE: reference to a compiler-generated method
      tvanComp.\u003C\u003En__0();
      if (await tvanComp.OleDB.ExecuteAsync(tvanComp.InsertQuery()))
        return true;
      tvanComp.message = " " + tvanComp.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tvanComp.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tvanComp.OleDB.LastErrorID) + string.Format(" 코드 : {0},{1})\n", (object) tvanComp.van_ID, (object) tvanComp.van_SiteID) + " 내용 : " + tvanComp.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tvanComp.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + string.Format(" {0}='{1}',{2}='{3}',{4}={5},{6}='{7}'", (object) "van_Name", (object) this.van_Name, (object) "van_AcroNm", (object) this.van_AcroNm, (object) "van_Type", (object) this.van_Type, (object) "van_UseYn", (object) this.van_UseYn) + string.Format(",{0}={1},{2}={3}", (object) "van_ModDate", (object) this.van_ModDate.GetDateToStrInNull(), (object) "van_ModUser", (object) this.van_ModUser) + string.Format(" WHERE {0}={1}", (object) "van_ID", (object) this.van_ID) + string.Format(" AND {0}={1}", (object) "van_SiteID", (object) this.van_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.van_ID, (object) this.van_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TVanComp tvanComp = this;
      // ISSUE: reference to a compiler-generated method
      tvanComp.\u003C\u003En__1();
      if (await tvanComp.OleDB.ExecuteAsync(tvanComp.UpdateQuery()))
        return true;
      tvanComp.message = " " + tvanComp.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tvanComp.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tvanComp.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tvanComp.van_ID, (object) tvanComp.van_SiteID) + " 내용 : " + tvanComp.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tvanComp.message);
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
      stringBuilder.Append(string.Format(" {0}='{1}',{2}='{3}',{4}={5},{6}='{7}'", (object) "van_Name", (object) this.van_Name, (object) "van_AcroNm", (object) this.van_AcroNm, (object) "van_Type", (object) this.van_Type, (object) "van_UseYn", (object) this.van_UseYn) + string.Format(",{0}={1},{2}={3}", (object) "van_ModDate", (object) this.van_ModDate.GetDateToStrInNull(), (object) "van_ModUser", (object) this.van_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.van_ID, (object) this.van_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TVanComp tvanComp = this;
      // ISSUE: reference to a compiler-generated method
      tvanComp.\u003C\u003En__1();
      if (await tvanComp.OleDB.ExecuteAsync(tvanComp.UpdateExInsertQuery()))
        return true;
      tvanComp.message = " " + tvanComp.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tvanComp.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tvanComp.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tvanComp.van_ID, (object) tvanComp.van_SiteID) + " 내용 : " + tvanComp.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tvanComp.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "van_SiteID") && Convert.ToInt64(hashtable[(object) "van_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "van_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "van_ID") && Convert.ToInt32(hashtable[(object) "van_ID"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "van_ID", hashtable[(object) "van_ID"]));
        else
          stringBuilder.Append(" AND van_ID>0");
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "van_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "van_Name") && hashtable[(object) "van_Name"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "van_Name", hashtable[(object) "van_Name"]));
        if (hashtable.ContainsKey((object) "van_Type") && Convert.ToInt32(hashtable[(object) "van_Type"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "van_Type", hashtable[(object) "van_Type"]));
        if (hashtable.ContainsKey((object) "van_UseYn") && hashtable[(object) "van_UseYn"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "van_UseYn", hashtable[(object) "van_UseYn"]));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "van_Name", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "van_AcroNm", hashtable[(object) "_KEY_WORD_"]));
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
        stringBuilder.Append(" SELECT  van_ID,van_SiteID,van_Name,van_AcroNm,van_Type,van_UseYn,van_InDate,van_InUser,van_ModDate,van_ModUser");
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
