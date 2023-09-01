// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniCampaign.CampaignInfo.CampaignStore.TCampaignStore
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

namespace UniBiz.Bo.Models.UniCampaign.CampaignInfo.CampaignStore
{
  public class TCampaignStore : UbModelBase<TCampaignStore>
  {
    private long _cis_CampaignCode;
    private int _cis_StoreCode;
    private long _cis_SiteID;
    private DateTime? _cis_InDate;
    private int _cis_InUser;
    private DateTime? _cis_ModDate;
    private int _cis_ModUser;

    public override object _Key => (object) new object[2]
    {
      (object) this.cis_CampaignCode,
      (object) this.cis_StoreCode
    };

    public long cis_CampaignCode
    {
      get => this._cis_CampaignCode;
      set
      {
        this._cis_CampaignCode = value;
        this.Changed(nameof (cis_CampaignCode));
      }
    }

    public int cis_StoreCode
    {
      get => this._cis_StoreCode;
      set
      {
        this._cis_StoreCode = value;
        this.Changed(nameof (cis_StoreCode));
      }
    }

    public long cis_SiteID
    {
      get => this._cis_SiteID;
      set
      {
        this._cis_SiteID = value;
        this.Changed(nameof (cis_SiteID));
      }
    }

    public DateTime? cis_InDate
    {
      get => this._cis_InDate;
      set
      {
        this._cis_InDate = value;
        this.Changed(nameof (cis_InDate));
      }
    }

    public int cis_InUser
    {
      get => this._cis_InUser;
      set
      {
        this._cis_InUser = value;
        this.Changed(nameof (cis_InUser));
      }
    }

    public DateTime? cis_ModDate
    {
      get => this._cis_ModDate;
      set
      {
        this._cis_ModDate = value;
        this.Changed(nameof (cis_ModDate));
      }
    }

    public int cis_ModUser
    {
      get => this._cis_ModUser;
      set
      {
        this._cis_ModUser = value;
        this.Changed(nameof (cis_ModUser));
      }
    }

    public override DateTime? ModDate => this.cis_ModDate ?? (this.cis_ModDate = this.cis_InDate);

    public TCampaignStore() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("cis_CampaignCode", new TTableColumn()
      {
        tc_orgin_name = "cis_CampaignCode",
        tc_trans_name = "캠페인코드"
      });
      columnInfo.Add("cis_StoreCode", new TTableColumn()
      {
        tc_orgin_name = "cis_StoreCode",
        tc_trans_name = "지점코드"
      });
      columnInfo.Add("cis_SiteID", new TTableColumn()
      {
        tc_orgin_name = "cis_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("cis_InDate", new TTableColumn()
      {
        tc_orgin_name = "cis_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("cis_InUser", new TTableColumn()
      {
        tc_orgin_name = "cis_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("cis_ModDate", new TTableColumn()
      {
        tc_orgin_name = "cis_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("cis_ModUser", new TTableColumn()
      {
        tc_orgin_name = "cis_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.CampaignStore;
      this.cis_CampaignCode = 0L;
      this.cis_StoreCode = 0;
      this.cis_SiteID = 0L;
      this.cis_InDate = new DateTime?();
      this.cis_InUser = 0;
      this.cis_ModDate = new DateTime?();
      this.cis_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TCampaignStore();

    public override object Clone()
    {
      TCampaignStore tcampaignStore = base.Clone() as TCampaignStore;
      tcampaignStore.cis_CampaignCode = this.cis_CampaignCode;
      tcampaignStore.cis_StoreCode = this.cis_StoreCode;
      tcampaignStore.cis_SiteID = this.cis_SiteID;
      tcampaignStore.cis_InDate = this.cis_InDate;
      tcampaignStore.cis_InUser = this.cis_InUser;
      tcampaignStore.cis_ModDate = this.cis_ModDate;
      tcampaignStore.cis_ModUser = this.cis_ModUser;
      return (object) tcampaignStore;
    }

    public void PutData(TCampaignStore pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.cis_CampaignCode = pSource.cis_CampaignCode;
      this.cis_StoreCode = pSource.cis_StoreCode;
      this.cis_SiteID = pSource.cis_SiteID;
      this.cis_InDate = pSource.cis_InDate;
      this.cis_InUser = pSource.cis_InUser;
      this.cis_ModDate = pSource.cis_ModDate;
      this.cis_ModUser = pSource.cis_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.cis_CampaignCode = p_rs.GetFieldLong("cis_CampaignCode");
        if (this.cis_CampaignCode == 0L)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.cis_StoreCode = p_rs.GetFieldInt("cis_StoreCode");
        this.cis_SiteID = p_rs.GetFieldLong("cis_SiteID");
        this.cis_InDate = p_rs.GetFieldDateTime("cis_InDate");
        this.cis_InUser = p_rs.GetFieldInt("cis_InUser");
        this.cis_ModDate = p_rs.GetFieldDateTime("cis_ModDate");
        this.cis_ModUser = p_rs.GetFieldInt("cis_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_CAMPANIGN), (object) this.TableCode) + " cis_CampaignCode,cis_StoreCode,cis_SiteID,cis_InDate,cis_InUser,cis_ModDate,cis_ModUser) VALUES ( " + string.Format(" {0},{1}", (object) this.cis_CampaignCode, (object) this.cis_StoreCode) + string.Format(",{0}", (object) this.cis_SiteID) + string.Format(",{0},{1}", (object) this.cis_InDate.GetDateToStrInNull(), (object) this.cis_InUser) + string.Format(",{0},{1}", (object) this.cis_ModDate.GetDateToStrInNull(), (object) this.cis_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.cis_CampaignCode, (object) this.cis_StoreCode, (object) this.cis_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TCampaignStore tcampaignStore = this;
      // ISSUE: reference to a compiler-generated method
      tcampaignStore.\u003C\u003En__0();
      if (await tcampaignStore.OleDB.ExecuteAsync(tcampaignStore.InsertQuery()))
        return true;
      tcampaignStore.message = " " + tcampaignStore.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tcampaignStore.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tcampaignStore.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tcampaignStore.cis_CampaignCode, (object) tcampaignStore.cis_StoreCode, (object) tcampaignStore.cis_SiteID) + " 내용 : " + tcampaignStore.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tcampaignStore.message);
      return false;
    }

    public override string DeleteQuery() => string.Format(" DELETE FROM {0}{1}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_CAMPANIGN), (object) this.TableCode) + string.Format(" WHERE {0}={1}", (object) "cis_CampaignCode", (object) this.cis_CampaignCode) + string.Format(" AND {0}={1}", (object) "cis_StoreCode", (object) this.cis_StoreCode) + string.Format(" AND {0}={1}", (object) "cis_SiteID", (object) this.cis_SiteID);

    public override bool Delete()
    {
      this.InsertChecked();
      string pStrExec = this.DeleteQuery();
      if (this.OleDB.Execute(pStrExec))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 삭제 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.cis_CampaignCode, (object) this.cis_StoreCode, (object) this.cis_SiteID) + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n 쿼리 : " + pStrExec + "\n--------------------------------------------------------------------------------------------------\n";
      return false;
    }

    public override async Task<bool> DeleteAsync()
    {
      TCampaignStore tcampaignStore = this;
      // ISSUE: reference to a compiler-generated method
      tcampaignStore.\u003C\u003En__0();
      if (await tcampaignStore.OleDB.ExecuteAsync(tcampaignStore.DeleteQuery()))
        return true;
      tcampaignStore.message = " " + tcampaignStore.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tcampaignStore.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tcampaignStore.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tcampaignStore.cis_CampaignCode, (object) tcampaignStore.cis_StoreCode, (object) tcampaignStore.cis_SiteID) + " 내용 : " + tcampaignStore.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tcampaignStore.message);
      return false;
    }

    public virtual string DeleteQuery(
      long p_cis_CampaignCode,
      int p_cis_StoreCode,
      long p_cis_SiteID = 0)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format(" DELETE FROM {0}{1} ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_CAMPANIGN), (object) this.TableCode));
      stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "cis_CampaignCode", (object) p_cis_CampaignCode));
      stringBuilder.Append(string.Format(" AND {0}={1}", (object) "cis_StoreCode", (object) p_cis_StoreCode));
      if (p_cis_SiteID > 0L)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "cis_SiteID", (object) p_cis_SiteID));
      return stringBuilder.ToString();
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "cis_SiteID") && Convert.ToInt64(hashtable[(object) "cis_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "cis_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "cis_CampaignCode") && Convert.ToInt64(hashtable[(object) "cis_CampaignCode"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "cis_CampaignCode", hashtable[(object) "cis_CampaignCode"]));
        if (hashtable.ContainsKey((object) "cis_StoreCode") && Convert.ToInt32(hashtable[(object) "cis_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "cis_StoreCode", hashtable[(object) "cis_StoreCode"]));
        else if (hashtable.ContainsKey((object) "cis_StoreCode_IN_") && hashtable[(object) "cis_StoreCode_IN_"].ToString().Length > 0)
        {
          if (hashtable[(object) "cis_StoreCode_IN_"].ToString().Contains(","))
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "cis_StoreCode", hashtable[(object) "cis_StoreCode_IN_"]));
          else
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "cis_StoreCode", hashtable[(object) "cis_StoreCode_IN_"]));
        }
        else if (hashtable.ContainsKey((object) "_STORE_AUTHS_") && !string.IsNullOrEmpty(hashtable[(object) "_STORE_AUTHS_"].ToString()))
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "cis_StoreCode", hashtable[(object) "_STORE_AUTHS_"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "cis_SiteID", (object) num));
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
        stringBuilder.Append(" SELECT  cis_CampaignCode,cis_StoreCode,cis_SiteID,cis_InDate,cis_InUser,cis_ModDate,cis_ModUser");
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
