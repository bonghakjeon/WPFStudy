// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.Info.MemberLinkSupplier.TMemberLinkSupplier
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

namespace UniBiz.Bo.Models.UniMembers.Info.MemberLinkSupplier
{
  public class TMemberLinkSupplier : UbModelBase<TMemberLinkSupplier>
  {
    private long _mbrs_MemberNo;
    private int _mbrs_Supplier;
    private int _mbrs_MemberStore;
    private long _mbrs_SiteID;
    private DateTime? _mbrs_InDate;
    private int _mbrs_InUser;

    public override object _Key => (object) new object[3]
    {
      (object) this.mbrs_MemberNo,
      (object) this.mbrs_Supplier,
      (object) this.mbrs_MemberStore
    };

    public long mbrs_MemberNo
    {
      get => this._mbrs_MemberNo;
      set
      {
        this._mbrs_MemberNo = value;
        this.Changed(nameof (mbrs_MemberNo));
      }
    }

    public int mbrs_Supplier
    {
      get => this._mbrs_Supplier;
      set
      {
        this._mbrs_Supplier = value;
        this.Changed(nameof (mbrs_Supplier));
      }
    }

    public int mbrs_MemberStore
    {
      get => this._mbrs_MemberStore;
      set
      {
        this._mbrs_MemberStore = value;
        this.Changed(nameof (mbrs_MemberStore));
      }
    }

    public long mbrs_SiteID
    {
      get => this._mbrs_SiteID;
      set
      {
        this._mbrs_SiteID = value;
        this.Changed(nameof (mbrs_SiteID));
      }
    }

    public DateTime? mbrs_InDate
    {
      get => this._mbrs_InDate;
      set
      {
        this._mbrs_InDate = value;
        this.Changed(nameof (mbrs_InDate));
      }
    }

    public int mbrs_InUser
    {
      get => this._mbrs_InUser;
      set
      {
        this._mbrs_InUser = value;
        this.Changed(nameof (mbrs_InUser));
      }
    }

    public TMemberLinkSupplier() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("mbrs_MemberNo", new TTableColumn()
      {
        tc_orgin_name = "mbrs_MemberNo",
        tc_trans_name = "회원코드"
      });
      columnInfo.Add("mbrs_Supplier", new TTableColumn()
      {
        tc_orgin_name = "mbrs_Supplier",
        tc_trans_name = "업체코드"
      });
      columnInfo.Add("mbrs_MemberStore", new TTableColumn()
      {
        tc_orgin_name = "mbrs_MemberStore",
        tc_trans_name = "포인트지점코드"
      });
      columnInfo.Add("mbrs_SiteID", new TTableColumn()
      {
        tc_orgin_name = "mbrs_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("mbrs_InDate", new TTableColumn()
      {
        tc_orgin_name = "mbrs_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("mbrs_InUser", new TTableColumn()
      {
        tc_orgin_name = "mbrs_InUser",
        tc_trans_name = "등록인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.MemberLinkSupplier;
      this.mbrs_MemberNo = 0L;
      this.mbrs_Supplier = this.mbrs_MemberStore = 0;
      this.mbrs_SiteID = 0L;
      this.mbrs_InDate = new DateTime?();
      this.mbrs_InUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TMemberLinkSupplier();

    public override object Clone()
    {
      TMemberLinkSupplier tmemberLinkSupplier = base.Clone() as TMemberLinkSupplier;
      tmemberLinkSupplier.mbrs_MemberNo = this.mbrs_MemberNo;
      tmemberLinkSupplier.mbrs_Supplier = this.mbrs_Supplier;
      tmemberLinkSupplier.mbrs_MemberStore = this.mbrs_MemberStore;
      tmemberLinkSupplier.mbrs_SiteID = this.mbrs_SiteID;
      tmemberLinkSupplier.mbrs_InDate = this.mbrs_InDate;
      tmemberLinkSupplier.mbrs_InUser = this.mbrs_InUser;
      return (object) tmemberLinkSupplier;
    }

    public void PutData(TMemberLinkSupplier pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.mbrs_MemberNo = pSource.mbrs_MemberNo;
      this.mbrs_Supplier = pSource.mbrs_Supplier;
      this.mbrs_MemberStore = pSource.mbrs_MemberStore;
      this.mbrs_SiteID = pSource.mbrs_SiteID;
      this.mbrs_InDate = pSource.mbrs_InDate;
      this.mbrs_InUser = pSource.mbrs_InUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.mbrs_MemberNo = p_rs.GetFieldLong("mbrs_MemberNo");
        if (this.mbrs_MemberNo == 0L)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.mbrs_Supplier = p_rs.GetFieldInt("mbrs_Supplier");
        this.mbrs_MemberStore = p_rs.GetFieldInt("mbrs_MemberStore");
        this.mbrs_SiteID = p_rs.GetFieldLong("mbrs_SiteID");
        this.mbrs_InDate = p_rs.GetFieldDateTime("mbrs_InDate");
        this.mbrs_InUser = p_rs.GetFieldInt("mbrs_InUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode) + " mbrs_MemberNo,mbrs_Supplier,mbrs_MemberStore,mbrs_SiteID,mbrs_InDate,mbrs_InUser) VALUES ( " + string.Format(" {0},{1},{2}", (object) this.mbrs_MemberNo, (object) this.mbrs_Supplier, (object) this.mbrs_MemberStore) + string.Format(",{0}", (object) this.mbrs_SiteID) + string.Format(",{0},{1}", (object) this.mbrs_InDate.GetDateToStrInNull(), (object) this.mbrs_InUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.mbrs_MemberNo, (object) this.mbrs_Supplier, (object) this.mbrs_MemberStore, (object) this.mbrs_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TMemberLinkSupplier tmemberLinkSupplier = this;
      // ISSUE: reference to a compiler-generated method
      tmemberLinkSupplier.\u003C\u003En__0();
      if (await tmemberLinkSupplier.OleDB.ExecuteAsync(tmemberLinkSupplier.InsertQuery()))
        return true;
      tmemberLinkSupplier.message = " " + tmemberLinkSupplier.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberLinkSupplier.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberLinkSupplier.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tmemberLinkSupplier.mbrs_MemberNo, (object) tmemberLinkSupplier.mbrs_Supplier, (object) tmemberLinkSupplier.mbrs_MemberStore, (object) tmemberLinkSupplier.mbrs_SiteID) + " 내용 : " + tmemberLinkSupplier.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberLinkSupplier.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "mbrs_SiteID") && Convert.ToInt64(hashtable[(object) "mbrs_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "mbrs_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "mbrs_MemberNo") && Convert.ToInt64(hashtable[(object) "mbrs_MemberNo"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mbrs_MemberNo", hashtable[(object) "mbrs_MemberNo"]));
        if (hashtable.ContainsKey((object) "mbrs_Supplier") && Convert.ToInt32(hashtable[(object) "mbrs_Supplier"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mbrs_Supplier", hashtable[(object) "mbrs_Supplier"]));
        if (hashtable.ContainsKey((object) "mbrs_MemberStore") && Convert.ToInt32(hashtable[(object) "mbrs_MemberStore"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mbrs_MemberStore", hashtable[(object) "mbrs_MemberStore"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mbrs_SiteID", (object) num));
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
        stringBuilder.Append(" SELECT  mbrs_MemberNo,mbrs_Supplier,mbrs_MemberStore,mbrs_SiteID,mbrs_InDate,mbrs_InUser");
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
