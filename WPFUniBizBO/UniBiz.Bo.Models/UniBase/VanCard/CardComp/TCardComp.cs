// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.VanCard.CardComp.TCardComp
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

namespace UniBiz.Bo.Models.UniBase.VanCard.CardComp
{
  public class TCardComp : UbModelBase<TCardComp>
  {
    private int _cc_ID;
    public long _cc_SiteID;
    private string _cc_Name;
    private string _cc_AcroNm;
    private int _cc_CompType;
    private string _cc_ErpCode;
    private string _cc_UseYn;
    private DateTime? _cc_InDate;
    private int _cc_InUser;
    private DateTime? _cc_ModDate;
    private int _cc_ModUser;

    public override object _Key => (object) new object[1]
    {
      (object) this.cc_ID
    };

    public int cc_ID
    {
      get => this._cc_ID;
      set
      {
        this._cc_ID = value;
        this.Changed(nameof (cc_ID));
      }
    }

    public long cc_SiteID
    {
      get => this._cc_SiteID;
      set
      {
        this._cc_SiteID = value;
        this.Changed(nameof (cc_SiteID));
      }
    }

    public string cc_Name
    {
      get => this._cc_Name;
      set
      {
        this._cc_Name = value;
        this.Changed(nameof (cc_Name));
      }
    }

    public string cc_AcroNm
    {
      get => this._cc_AcroNm;
      set
      {
        this._cc_AcroNm = value;
        this.Changed(nameof (cc_AcroNm));
      }
    }

    public int cc_CompType
    {
      get => this._cc_CompType;
      set
      {
        this._cc_CompType = value;
        this.Changed(nameof (cc_CompType));
      }
    }

    public string cc_ErpCode
    {
      get => this._cc_ErpCode;
      set
      {
        this._cc_ErpCode = value;
        this.Changed(nameof (cc_ErpCode));
      }
    }

    public string cc_UseYn
    {
      get => this._cc_UseYn;
      set
      {
        this._cc_UseYn = value;
        this.Changed(nameof (cc_UseYn));
        this.Changed("cc_IsUse");
      }
    }

    public bool cc_IsUse => this.cc_UseYn.Equals("Y");

    public DateTime? cc_InDate
    {
      get => this._cc_InDate;
      set
      {
        this._cc_InDate = value;
        this.Changed(nameof (cc_InDate));
      }
    }

    public int cc_InUser
    {
      get => this._cc_InUser;
      set
      {
        this._cc_InUser = value;
        this.Changed(nameof (cc_InUser));
      }
    }

    public DateTime? cc_ModDate
    {
      get => this._cc_ModDate;
      set
      {
        this._cc_ModDate = value;
        this.Changed(nameof (cc_ModDate));
      }
    }

    public int cc_ModUser
    {
      get => this._cc_ModUser;
      set
      {
        this._cc_ModUser = value;
        this.Changed(nameof (cc_ModUser));
      }
    }

    public TCardComp() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("cc_ID", new TTableColumn()
      {
        tc_orgin_name = "cc_ID",
        tc_trans_name = "카드회사"
      });
      columnInfo.Add("cc_SiteID", new TTableColumn()
      {
        tc_orgin_name = "cc_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("cc_Name", new TTableColumn()
      {
        tc_orgin_name = "cc_Name",
        tc_trans_name = "카드회사명"
      });
      columnInfo.Add("cc_AcroNm", new TTableColumn()
      {
        tc_orgin_name = "cc_AcroNm",
        tc_trans_name = "단축명"
      });
      columnInfo.Add("cc_CompType", new TTableColumn()
      {
        tc_orgin_name = "cc_CompType",
        tc_trans_name = "카드사구분"
      });
      columnInfo.Add("cc_ErpCode", new TTableColumn()
      {
        tc_orgin_name = "cc_ErpCode",
        tc_trans_name = "ERP코드"
      });
      columnInfo.Add("cc_UseYn", new TTableColumn()
      {
        tc_orgin_name = "cc_UseYn",
        tc_trans_name = "사용상태"
      });
      columnInfo.Add("cc_InDate", new TTableColumn()
      {
        tc_orgin_name = "cc_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("cc_InUser", new TTableColumn()
      {
        tc_orgin_name = "cc_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("cc_ModDate", new TTableColumn()
      {
        tc_orgin_name = "cc_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("cc_ModUser", new TTableColumn()
      {
        tc_orgin_name = "cc_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.CardComp;
      this.cc_ID = 0;
      this.cc_SiteID = 0L;
      this.cc_Name = string.Empty;
      this.cc_AcroNm = string.Empty;
      this.cc_CompType = 0;
      this.cc_ErpCode = string.Empty;
      this.cc_UseYn = "Y";
      this.cc_InDate = new DateTime?();
      this.cc_InUser = 0;
      this.cc_ModDate = new DateTime?();
      this.cc_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TCardComp();

    public override object Clone()
    {
      TCardComp tcardComp = base.Clone() as TCardComp;
      tcardComp.cc_ID = this.cc_ID;
      tcardComp.cc_SiteID = this.cc_SiteID;
      tcardComp.cc_Name = this.cc_Name;
      tcardComp.cc_AcroNm = this.cc_AcroNm;
      tcardComp.cc_CompType = this.cc_CompType;
      tcardComp.cc_ErpCode = this.cc_ErpCode;
      tcardComp.cc_UseYn = this.cc_UseYn;
      tcardComp.cc_InDate = this.cc_InDate;
      tcardComp.cc_InUser = this.cc_InUser;
      tcardComp.cc_ModDate = this.cc_ModDate;
      tcardComp.cc_ModUser = this.cc_ModUser;
      return (object) tcardComp;
    }

    public void PutData(TCardComp pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.cc_ID = pSource.cc_ID;
      this.cc_SiteID = pSource.cc_SiteID;
      this.cc_Name = pSource.cc_Name;
      this.cc_AcroNm = pSource.cc_AcroNm;
      this.cc_CompType = pSource.cc_CompType;
      this.cc_ErpCode = pSource.cc_ErpCode;
      this.cc_UseYn = pSource.cc_UseYn;
      this.cc_InDate = pSource.cc_InDate;
      this.cc_InUser = pSource.cc_InUser;
      this.cc_ModDate = pSource.cc_ModDate;
      this.cc_ModUser = pSource.cc_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.cc_ID = p_rs.GetFieldInt("cc_ID");
        if (this.cc_ID == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.cc_SiteID = (long) p_rs.GetFieldInt("cc_SiteID");
        this.cc_Name = p_rs.GetFieldString("cc_Name");
        this.cc_AcroNm = p_rs.GetFieldString("cc_AcroNm");
        this.cc_CompType = p_rs.GetFieldInt("cc_CompType");
        this.cc_ErpCode = p_rs.GetFieldString("cc_ErpCode");
        this.cc_UseYn = p_rs.GetFieldString("cc_UseYn");
        this.cc_InDate = p_rs.GetFieldDateTime("cc_InDate");
        this.cc_InUser = p_rs.GetFieldInt("cc_InUser");
        this.cc_ModDate = p_rs.GetFieldDateTime("cc_ModDate");
        this.cc_ModUser = p_rs.GetFieldInt("cc_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " cc_ID,cc_SiteID,cc_Name,cc_AcroNm,cc_CompType,cc_ErpCode,cc_UseYn,cc_InDate,cc_InUser,cc_ModDate,cc_ModUser) VALUES ( " + string.Format(" {0}", (object) this.cc_ID) + string.Format(",{0}", (object) this.cc_SiteID) + string.Format(",'{0}','{1}',{2},'{3}','{4}'", (object) this.cc_Name, (object) this.cc_AcroNm, (object) this.cc_CompType, (object) this.cc_ErpCode, (object) this.cc_UseYn) + string.Format(",{0},{1}", (object) this.cc_InDate.GetDateToStrInNull(), (object) this.cc_InUser) + string.Format(",{0},{1}", (object) this.cc_ModDate.GetDateToStrInNull(), (object) this.cc_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.cc_ID, (object) this.cc_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TCardComp tcardComp = this;
      // ISSUE: reference to a compiler-generated method
      tcardComp.\u003C\u003En__0();
      if (await tcardComp.OleDB.ExecuteAsync(tcardComp.InsertQuery()))
        return true;
      tcardComp.message = " " + tcardComp.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tcardComp.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tcardComp.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tcardComp.cc_ID, (object) tcardComp.cc_SiteID) + " 내용 : " + tcardComp.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tcardComp.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + string.Format(" {0}='{1}',{2}='{3}',{4}={5}", (object) "cc_Name", (object) this.cc_Name, (object) "cc_AcroNm", (object) this.cc_AcroNm, (object) "cc_CompType", (object) this.cc_CompType) + ",cc_ErpCode='" + this.cc_ErpCode + "',cc_UseYn='" + this.cc_UseYn + "'" + string.Format(",{0}={1},{2}={3}", (object) "cc_ModDate", (object) this.cc_ModDate.GetDateToStrInNull(), (object) "cc_ModUser", (object) this.cc_ModUser) + string.Format(" WHERE {0}={1}", (object) "cc_ID", (object) this.cc_ID) + string.Format(" AND {0}={1}", (object) "cc_SiteID", (object) this.cc_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.cc_ID, (object) this.cc_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TCardComp tcardComp = this;
      // ISSUE: reference to a compiler-generated method
      tcardComp.\u003C\u003En__1();
      if (await tcardComp.OleDB.ExecuteAsync(tcardComp.UpdateQuery()))
        return true;
      tcardComp.message = " " + tcardComp.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tcardComp.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tcardComp.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tcardComp.cc_ID, (object) tcardComp.cc_SiteID) + " 내용 : " + tcardComp.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tcardComp.message);
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
      stringBuilder.Append(string.Format(" {0}='{1}',{2}='{3}',{4}={5}", (object) "cc_Name", (object) this.cc_Name, (object) "cc_AcroNm", (object) this.cc_AcroNm, (object) "cc_CompType", (object) this.cc_CompType) + ",cc_ErpCode='" + this.cc_ErpCode + "',cc_UseYn='" + this.cc_UseYn + "'" + string.Format(",{0}={1},{2}={3}", (object) "cc_ModDate", (object) this.cc_ModDate.GetDateToStrInNull(), (object) "cc_ModUser", (object) this.cc_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.cc_ID, (object) this.cc_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TCardComp tcardComp = this;
      // ISSUE: reference to a compiler-generated method
      tcardComp.\u003C\u003En__1();
      if (await tcardComp.OleDB.ExecuteAsync(tcardComp.UpdateExInsertQuery()))
        return true;
      tcardComp.message = " " + tcardComp.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tcardComp.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tcardComp.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tcardComp.cc_ID, (object) tcardComp.cc_SiteID) + " 내용 : " + tcardComp.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tcardComp.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "cc_SiteID") && Convert.ToInt64(hashtable[(object) "cc_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "cc_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "cc_ID") && Convert.ToInt32(hashtable[(object) "cc_ID"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "cc_ID", hashtable[(object) "cc_ID"]));
        else
          stringBuilder.Append(" AND cc_ID>0");
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "cc_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "cc_Name") && hashtable[(object) "cc_Name"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "cc_Name", hashtable[(object) "cc_Name"]));
        if (hashtable.ContainsKey((object) "cc_CompType") && Convert.ToInt32(hashtable[(object) "cc_CompType"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "cc_CompType", hashtable[(object) "cc_CompType"]));
        if (hashtable.ContainsKey((object) "IsAcquirer") && Convert.ToBoolean(hashtable[(object) "IsAcquirer"]))
          stringBuilder.Append(string.Format(" AND ({0}&{1})={2}", (object) "cc_CompType", (object) 1, (object) 1));
        else if (hashtable.ContainsKey((object) "IsIssuer") && Convert.ToBoolean(hashtable[(object) "IsIssuer"]))
          stringBuilder.Append(string.Format(" AND ({0}&{1})={2}", (object) "cc_CompType", (object) 2, (object) 2));
        if (hashtable.ContainsKey((object) "cc_ErpCode") && hashtable[(object) "cc_ErpCode"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "cc_ErpCode", hashtable[(object) "cc_ErpCode"]));
        if (hashtable.ContainsKey((object) "cc_UseYn") && hashtable[(object) "cc_UseYn"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "cc_UseYn", hashtable[(object) "cc_UseYn"]));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "cc_Name", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "cc_AcroNm", hashtable[(object) "_KEY_WORD_"]));
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
        stringBuilder.Append(" SELECT  cc_ID,cc_SiteID,cc_Name,cc_AcroNm,cc_CompType,cc_ErpCode,cc_UseYn,cc_InDate,cc_InUser,cc_ModDate,cc_ModUser");
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
