// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniCampaign.CampaignInfo.CampaignMember.TCampaignMember
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

namespace UniBiz.Bo.Models.UniCampaign.CampaignInfo.CampaignMember
{
  public class TCampaignMember : UbModelBase<TCampaignMember>
  {
    private long _cim_CampaignCode;
    private long _cim_MemberNo;
    private long _cim_SiteID;
    private DateTime? _cim_InDate;
    private int _cim_InUser;
    private DateTime? _cim_ModDate;
    private int _cim_ModUser;

    public override object _Key => (object) new object[2]
    {
      (object) this.cim_CampaignCode,
      (object) this.cim_MemberNo
    };

    public long cim_CampaignCode
    {
      get => this._cim_CampaignCode;
      set
      {
        this._cim_CampaignCode = value;
        this.Changed(nameof (cim_CampaignCode));
      }
    }

    public long cim_MemberNo
    {
      get => this._cim_MemberNo;
      set
      {
        this._cim_MemberNo = value;
        this.Changed(nameof (cim_MemberNo));
      }
    }

    public long cim_SiteID
    {
      get => this._cim_SiteID;
      set
      {
        this._cim_SiteID = value;
        this.Changed(nameof (cim_SiteID));
      }
    }

    public DateTime? cim_InDate
    {
      get => this._cim_InDate;
      set
      {
        this._cim_InDate = value;
        this.Changed(nameof (cim_InDate));
      }
    }

    public int cim_InUser
    {
      get => this._cim_InUser;
      set
      {
        this._cim_InUser = value;
        this.Changed(nameof (cim_InUser));
      }
    }

    public DateTime? cim_ModDate
    {
      get => this._cim_ModDate;
      set
      {
        this._cim_ModDate = value;
        this.Changed(nameof (cim_ModDate));
      }
    }

    public int cim_ModUser
    {
      get => this._cim_ModUser;
      set
      {
        this._cim_ModUser = value;
        this.Changed(nameof (cim_ModUser));
      }
    }

    public override DateTime? ModDate => this.cim_ModDate ?? (this.cim_ModDate = this.cim_InDate);

    public TCampaignMember() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("cim_CampaignCode", new TTableColumn()
      {
        tc_orgin_name = "cim_CampaignCode",
        tc_trans_name = "캠페인코드"
      });
      columnInfo.Add("cim_MemberNo", new TTableColumn()
      {
        tc_orgin_name = "cim_MemberNo",
        tc_trans_name = "회원코드"
      });
      columnInfo.Add("cim_SiteID", new TTableColumn()
      {
        tc_orgin_name = "cim_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("cim_InDate", new TTableColumn()
      {
        tc_orgin_name = "cim_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("cim_InUser", new TTableColumn()
      {
        tc_orgin_name = "cim_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("cim_ModDate", new TTableColumn()
      {
        tc_orgin_name = "cim_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("cim_ModUser", new TTableColumn()
      {
        tc_orgin_name = "cim_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.CampaignMember;
      this.cim_CampaignCode = this.cim_MemberNo = 0L;
      this.cim_SiteID = 0L;
      this.cim_InDate = new DateTime?();
      this.cim_InUser = 0;
      this.cim_ModDate = new DateTime?();
      this.cim_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TCampaignMember();

    public override object Clone()
    {
      TCampaignMember tcampaignMember = base.Clone() as TCampaignMember;
      tcampaignMember.cim_CampaignCode = this.cim_CampaignCode;
      tcampaignMember.cim_MemberNo = this.cim_MemberNo;
      tcampaignMember.cim_SiteID = this.cim_SiteID;
      tcampaignMember.cim_InDate = this.cim_InDate;
      tcampaignMember.cim_InUser = this.cim_InUser;
      tcampaignMember.cim_ModDate = this.cim_ModDate;
      tcampaignMember.cim_ModUser = this.cim_ModUser;
      return (object) tcampaignMember;
    }

    public void PutData(TCampaignMember pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.cim_CampaignCode = pSource.cim_CampaignCode;
      this.cim_MemberNo = pSource.cim_MemberNo;
      this.cim_SiteID = pSource.cim_SiteID;
      this.cim_InDate = pSource.cim_InDate;
      this.cim_InUser = pSource.cim_InUser;
      this.cim_ModDate = pSource.cim_ModDate;
      this.cim_ModUser = pSource.cim_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.cim_CampaignCode = p_rs.GetFieldLong("cim_CampaignCode");
        if (this.cim_CampaignCode == 0L)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.cim_MemberNo = p_rs.GetFieldLong("cim_MemberNo");
        this.cim_SiteID = p_rs.GetFieldLong("cim_SiteID");
        this.cim_InDate = p_rs.GetFieldDateTime("cim_InDate");
        this.cim_InUser = p_rs.GetFieldInt("cim_InUser");
        this.cim_ModDate = p_rs.GetFieldDateTime("cim_ModDate");
        this.cim_ModUser = p_rs.GetFieldInt("cim_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_CAMPANIGN), (object) this.TableCode) + " cim_CampaignCode,cim_MemberNo,cim_SiteID,cim_InDate,cim_InUser,cim_ModDate,cim_ModUser) VALUES ( " + string.Format(" {0},{1}", (object) this.cim_CampaignCode, (object) this.cim_MemberNo) + string.Format(",{0}", (object) this.cim_SiteID) + string.Format(",{0},{1}", (object) this.cim_InDate.GetDateToStrInNull(), (object) this.cim_InUser) + string.Format(",{0},{1}", (object) this.cim_ModDate.GetDateToStrInNull(), (object) this.cim_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.cim_CampaignCode, (object) this.cim_MemberNo, (object) this.cim_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TCampaignMember tcampaignMember = this;
      // ISSUE: reference to a compiler-generated method
      tcampaignMember.\u003C\u003En__0();
      if (await tcampaignMember.OleDB.ExecuteAsync(tcampaignMember.InsertQuery()))
        return true;
      tcampaignMember.message = " " + tcampaignMember.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tcampaignMember.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tcampaignMember.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tcampaignMember.cim_CampaignCode, (object) tcampaignMember.cim_MemberNo, (object) tcampaignMember.cim_SiteID) + " 내용 : " + tcampaignMember.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tcampaignMember.message);
      return false;
    }

    public override string DeleteQuery() => string.Format(" DELETE FROM {0}{1}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_CAMPANIGN), (object) this.TableCode) + string.Format(" WHERE {0}={1}", (object) "cim_CampaignCode", (object) this.cim_CampaignCode) + string.Format(" AND {0}={1}", (object) "cim_MemberNo", (object) this.cim_MemberNo) + string.Format(" AND {0}={1}", (object) "cim_SiteID", (object) this.cim_SiteID);

    public override bool Delete()
    {
      this.InsertChecked();
      string pStrExec = this.DeleteQuery();
      if (this.OleDB.Execute(pStrExec))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 삭제 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.cim_CampaignCode, (object) this.cim_MemberNo, (object) this.cim_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n 쿼리 : " + pStrExec + "\n--------------------------------------------------------------------------------------------------\n";
      return false;
    }

    public override async Task<bool> DeleteAsync()
    {
      TCampaignMember tcampaignMember = this;
      // ISSUE: reference to a compiler-generated method
      tcampaignMember.\u003C\u003En__0();
      if (await tcampaignMember.OleDB.ExecuteAsync(tcampaignMember.DeleteQuery()))
        return true;
      tcampaignMember.message = " " + tcampaignMember.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tcampaignMember.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tcampaignMember.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tcampaignMember.cim_CampaignCode, (object) tcampaignMember.cim_MemberNo, (object) tcampaignMember.cim_SiteID) + " 내용 : " + tcampaignMember.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tcampaignMember.message);
      return false;
    }

    public virtual string DeleteQuery(
      long p_cim_CampaignCode,
      long p_cim_MemberNo,
      long p_cig_SiteID = 0)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format(" DELETE FROM {0}{1} ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_CAMPANIGN), (object) this.TableCode));
      stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "cim_CampaignCode", (object) p_cim_CampaignCode));
      stringBuilder.Append(string.Format(" AND {0}={1}", (object) "cim_MemberNo", (object) p_cim_MemberNo));
      if (p_cig_SiteID > 0L)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "cim_SiteID", (object) p_cig_SiteID));
      return stringBuilder.ToString();
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "cim_SiteID") && Convert.ToInt64(hashtable[(object) "cim_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "cim_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "cim_CampaignCode") && Convert.ToInt64(hashtable[(object) "cim_CampaignCode"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "cim_CampaignCode", hashtable[(object) "cim_CampaignCode"]));
        if (hashtable.ContainsKey((object) "cim_MemberNo") && Convert.ToInt64(hashtable[(object) "cim_MemberNo"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "cim_MemberNo", hashtable[(object) "cim_MemberNo"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "cim_SiteID", (object) num));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_"))
          string.IsNullOrEmpty(hashtable[(object) "_KEY_WORD_"].ToString());
      }
      return !stringBuilder.ToString().Equals(" WHERE") ? stringBuilder.Replace("WHERE AND", "WHERE").ToString() : string.Empty;
    }

    public override string GetSelectQuery(object p_param)
    {
      StringBuilder stringBuilder = new StringBuilder();
      try
      {
        string uniCampanign = UbModelBase.UNI_CAMPANIGN;
        string str = this.TableCode.ToString();
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniCampanign = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
        }
        stringBuilder.Append(" SELECT  cim_CampaignCode,cim_MemberNo,cim_SiteID,cim_InDate,cim_InUser,cim_ModDate,cim_ModUser");
        stringBuilder.Append(" FROM " + DbQueryHelper.ToDBNameBridge(uniCampanign) + str + " " + DbQueryHelper.ToWithNolock());
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
