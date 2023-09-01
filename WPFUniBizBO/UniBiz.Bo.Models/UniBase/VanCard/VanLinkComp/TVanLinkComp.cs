// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.VanCard.VanLinkComp.TVanLinkComp
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

namespace UniBiz.Bo.Models.UniBase.VanCard.VanLinkComp
{
  public class TVanLinkComp : UbModelBase<TVanLinkComp>
  {
    private int _vlc_VanID;
    private int _vlc_CardID;
    public long _vlc_SiteID;
    private string _vlc_LinkComp = string.Empty;
    private DateTime? _vlc_InDate;
    private int _vlc_InUser;
    private DateTime? _vlc_ModDate;
    private int _vlc_ModUser;

    public override object _Key => (object) new object[2]
    {
      (object) this.vlc_VanID,
      (object) this.vlc_CardID
    };

    public int vlc_VanID
    {
      get => this._vlc_VanID;
      set
      {
        this._vlc_VanID = value;
        this.Changed(nameof (vlc_VanID));
      }
    }

    public int vlc_CardID
    {
      get => this._vlc_CardID;
      set
      {
        this._vlc_CardID = value;
        this.Changed(nameof (vlc_CardID));
      }
    }

    public long vlc_SiteID
    {
      get => this._vlc_SiteID;
      set
      {
        this._vlc_SiteID = value;
        this.Changed(nameof (vlc_SiteID));
      }
    }

    public string vlc_LinkComp
    {
      get => this._vlc_LinkComp;
      set
      {
        this._vlc_LinkComp = value;
        this.Changed(nameof (vlc_LinkComp));
      }
    }

    public DateTime? vlc_InDate
    {
      get => this._vlc_InDate;
      set
      {
        this._vlc_InDate = value;
        this.Changed(nameof (vlc_InDate));
      }
    }

    public int vlc_InUser
    {
      get => this._vlc_InUser;
      set
      {
        this._vlc_InUser = value;
        this.Changed(nameof (vlc_InUser));
      }
    }

    public DateTime? vlc_ModDate
    {
      get => this._vlc_ModDate;
      set
      {
        this._vlc_ModDate = value;
        this.Changed(nameof (vlc_ModDate));
      }
    }

    public int vlc_ModUser
    {
      get => this._vlc_ModUser;
      set
      {
        this._vlc_ModUser = value;
        this.Changed(nameof (vlc_ModUser));
      }
    }

    public TVanLinkComp() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("vlc_VanID", new TTableColumn()
      {
        tc_orgin_name = "vlc_VanID",
        tc_trans_name = "밴사코드"
      });
      columnInfo.Add("vlc_CardID", new TTableColumn()
      {
        tc_orgin_name = "vlc_CardID",
        tc_trans_name = "관리카드사"
      });
      columnInfo.Add("vlc_SiteID", new TTableColumn()
      {
        tc_orgin_name = "vlc_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("vlc_LinkComp", new TTableColumn()
      {
        tc_orgin_name = "vlc_LinkComp",
        tc_trans_name = "밴카드사"
      });
      columnInfo.Add("vlc_InDate", new TTableColumn()
      {
        tc_orgin_name = "vlc_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("vlc_InUser", new TTableColumn()
      {
        tc_orgin_name = "vlc_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("vlc_ModDate", new TTableColumn()
      {
        tc_orgin_name = "vlc_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("vlc_ModUser", new TTableColumn()
      {
        tc_orgin_name = "vlc_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.VanLinkComp;
      this.vlc_VanID = 0;
      this.vlc_CardID = 0;
      this.vlc_SiteID = 0L;
      this.vlc_LinkComp = string.Empty;
      this.vlc_InDate = new DateTime?();
      this.vlc_InUser = 0;
      this.vlc_ModDate = new DateTime?();
      this.vlc_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TVanLinkComp();

    public override object Clone()
    {
      TVanLinkComp tvanLinkComp = base.Clone() as TVanLinkComp;
      tvanLinkComp.vlc_VanID = this.vlc_VanID;
      tvanLinkComp.vlc_CardID = this.vlc_CardID;
      tvanLinkComp.vlc_SiteID = this.vlc_SiteID;
      tvanLinkComp.vlc_LinkComp = this.vlc_LinkComp;
      tvanLinkComp.vlc_InDate = this.vlc_InDate;
      tvanLinkComp.vlc_InUser = this.vlc_InUser;
      tvanLinkComp.vlc_ModDate = this.vlc_ModDate;
      tvanLinkComp.vlc_ModUser = this.vlc_ModUser;
      return (object) tvanLinkComp;
    }

    public void PutData(TVanLinkComp pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.vlc_VanID = pSource.vlc_VanID;
      this.vlc_CardID = pSource.vlc_CardID;
      this.vlc_SiteID = pSource.vlc_SiteID;
      this.vlc_LinkComp = pSource.vlc_LinkComp;
      this.vlc_InDate = pSource.vlc_InDate;
      this.vlc_InUser = pSource.vlc_InUser;
      this.vlc_ModDate = pSource.vlc_ModDate;
      this.vlc_ModUser = pSource.vlc_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.vlc_VanID = p_rs.GetFieldInt("vlc_VanID");
        if (this.vlc_VanID == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.vlc_CardID = p_rs.GetFieldInt("vlc_CardID");
        this.vlc_SiteID = (long) p_rs.GetFieldInt("vlc_SiteID");
        this.vlc_LinkComp = p_rs.GetFieldString("vlc_LinkComp");
        this.vlc_InDate = p_rs.GetFieldDateTime("vlc_InDate");
        this.vlc_InUser = p_rs.GetFieldInt("vlc_InUser");
        this.vlc_ModDate = p_rs.GetFieldDateTime("vlc_ModDate");
        this.vlc_ModUser = p_rs.GetFieldInt("vlc_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " vlc_VanID,vlc_CardID,vlc_SiteID,vlc_LinkComp,vlc_InDate,vlc_InUser,vlc_ModDate,vlc_ModUser) VALUES ( " + string.Format(" {0},{1}", (object) this.vlc_VanID, (object) this.vlc_CardID) + string.Format(",{0}", (object) this.vlc_SiteID) + ",'" + this.vlc_LinkComp + "'" + string.Format(",{0},{1}", (object) this.vlc_InDate.GetDateToStrInNull(), (object) this.vlc_InUser) + string.Format(",{0},{1}", (object) this.vlc_ModDate.GetDateToStrInNull(), (object) this.vlc_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.vlc_VanID, (object) this.vlc_CardID, (object) this.vlc_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TVanLinkComp tvanLinkComp = this;
      // ISSUE: reference to a compiler-generated method
      tvanLinkComp.\u003C\u003En__0();
      if (await tvanLinkComp.OleDB.ExecuteAsync(tvanLinkComp.InsertQuery()))
        return true;
      tvanLinkComp.message = " " + tvanLinkComp.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tvanLinkComp.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tvanLinkComp.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tvanLinkComp.vlc_VanID, (object) tvanLinkComp.vlc_CardID, (object) tvanLinkComp.vlc_SiteID) + " 내용 : " + tvanLinkComp.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tvanLinkComp.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " vlc_LinkComp='" + this.vlc_LinkComp + "'" + string.Format(",{0}={1},{2}={3}", (object) "vlc_ModDate", (object) this.vlc_ModDate.GetDateToStrInNull(), (object) "vlc_ModUser", (object) this.vlc_ModUser) + string.Format(" WHERE {0}={1}", (object) "vlc_VanID", (object) this.vlc_VanID) + string.Format(" AND {0}={1}", (object) "vlc_CardID", (object) this.vlc_CardID) + string.Format(" AND {0}={1}", (object) "vlc_SiteID", (object) this.vlc_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.vlc_VanID, (object) this.vlc_CardID, (object) this.vlc_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TVanLinkComp tvanLinkComp = this;
      // ISSUE: reference to a compiler-generated method
      tvanLinkComp.\u003C\u003En__1();
      if (await tvanLinkComp.OleDB.ExecuteAsync(tvanLinkComp.UpdateQuery()))
        return true;
      tvanLinkComp.message = " " + tvanLinkComp.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tvanLinkComp.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tvanLinkComp.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tvanLinkComp.vlc_VanID, (object) tvanLinkComp.vlc_CardID, (object) tvanLinkComp.vlc_SiteID) + " 내용 : " + tvanLinkComp.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tvanLinkComp.message);
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
      stringBuilder.Append(" vlc_LinkComp='" + this.vlc_LinkComp + "'" + string.Format(",{0}={1},{2}={3}", (object) "vlc_ModDate", (object) this.vlc_ModDate.GetDateToStrInNull(), (object) "vlc_ModUser", (object) this.vlc_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.vlc_VanID, (object) this.vlc_CardID, (object) this.vlc_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TVanLinkComp tvanLinkComp = this;
      // ISSUE: reference to a compiler-generated method
      tvanLinkComp.\u003C\u003En__1();
      if (await tvanLinkComp.OleDB.ExecuteAsync(tvanLinkComp.UpdateExInsertQuery()))
        return true;
      tvanLinkComp.message = " " + tvanLinkComp.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tvanLinkComp.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tvanLinkComp.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tvanLinkComp.vlc_VanID, (object) tvanLinkComp.vlc_CardID, (object) tvanLinkComp.vlc_SiteID) + " 내용 : " + tvanLinkComp.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tvanLinkComp.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "vlc_SiteID") && Convert.ToInt64(hashtable[(object) "vlc_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "vlc_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "vlc_VanID") && Convert.ToInt32(hashtable[(object) "vlc_VanID"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "vlc_VanID", hashtable[(object) "vlc_VanID"]));
        else
          stringBuilder.Append(" AND vlc_VanID>0");
        if (hashtable.ContainsKey((object) "vlc_CardID") && Convert.ToInt32(hashtable[(object) "vlc_CardID"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "vlc_CardID", hashtable[(object) "vlc_CardID"]));
        else
          stringBuilder.Append(" AND vlc_CardID>0");
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "vlc_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "vlc_LinkComp") && hashtable[(object) "vlc_LinkComp"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "vlc_LinkComp", hashtable[(object) "vlc_LinkComp"]));
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
        stringBuilder.Append(" SELECT  vlc_VanID,vlc_CardID,vlc_SiteID,vlc_LinkComp,vlc_InDate,vlc_InUser,vlc_ModDate,vlc_ModUser");
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
