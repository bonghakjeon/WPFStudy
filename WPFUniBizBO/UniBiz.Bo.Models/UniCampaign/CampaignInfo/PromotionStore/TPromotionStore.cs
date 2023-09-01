// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniCampaign.CampaignInfo.PromotionStore.TPromotionStore
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

namespace UniBiz.Bo.Models.UniCampaign.CampaignInfo.PromotionStore
{
  public class TPromotionStore : UbModelBase<TPromotionStore>
  {
    private long _pms_PromotionCode;
    private int _pms_StoreCode;
    private long _pms_SiteID;
    private DateTime? _pms_InDate;
    private int _pms_InUser;
    private DateTime? _pms_ModDate;
    private int _pms_ModUser;

    public override object _Key => (object) new object[2]
    {
      (object) this.pms_PromotionCode,
      (object) this.pms_StoreCode
    };

    public long pms_PromotionCode
    {
      get => this._pms_PromotionCode;
      set
      {
        this._pms_PromotionCode = value;
        this.Changed(nameof (pms_PromotionCode));
      }
    }

    public int pms_StoreCode
    {
      get => this._pms_StoreCode;
      set
      {
        this._pms_StoreCode = value;
        this.Changed(nameof (pms_StoreCode));
      }
    }

    public long pms_SiteID
    {
      get => this._pms_SiteID;
      set
      {
        this._pms_SiteID = value;
        this.Changed(nameof (pms_SiteID));
      }
    }

    public DateTime? pms_InDate
    {
      get => this._pms_InDate;
      set
      {
        this._pms_InDate = value;
        this.Changed(nameof (pms_InDate));
      }
    }

    public int pms_InUser
    {
      get => this._pms_InUser;
      set
      {
        this._pms_InUser = value;
        this.Changed(nameof (pms_InUser));
      }
    }

    public DateTime? pms_ModDate
    {
      get => this._pms_ModDate;
      set
      {
        this._pms_ModDate = value;
        this.Changed(nameof (pms_ModDate));
      }
    }

    public int pms_ModUser
    {
      get => this._pms_ModUser;
      set
      {
        this._pms_ModUser = value;
        this.Changed(nameof (pms_ModUser));
      }
    }

    public override DateTime? ModDate => this.pms_ModDate ?? (this.pms_ModDate = this.pms_InDate);

    public TPromotionStore() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("pms_PromotionCode", new TTableColumn()
      {
        tc_orgin_name = "pms_PromotionCode",
        tc_trans_name = "프로모션코드"
      });
      columnInfo.Add("pms_StoreCode", new TTableColumn()
      {
        tc_orgin_name = "pms_StoreCode",
        tc_trans_name = "지점코드"
      });
      columnInfo.Add("pms_SiteID", new TTableColumn()
      {
        tc_orgin_name = "pms_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("pms_InDate", new TTableColumn()
      {
        tc_orgin_name = "pms_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("pms_InUser", new TTableColumn()
      {
        tc_orgin_name = "pms_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("pms_ModDate", new TTableColumn()
      {
        tc_orgin_name = "pms_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("pms_ModUser", new TTableColumn()
      {
        tc_orgin_name = "pms_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.PromotionStore;
      this.pms_PromotionCode = 0L;
      this.pms_StoreCode = 0;
      this.pms_SiteID = 0L;
      this.pms_InDate = new DateTime?();
      this.pms_InUser = 0;
      this.pms_ModDate = new DateTime?();
      this.pms_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TPromotionStore();

    public override object Clone()
    {
      TPromotionStore tpromotionStore = base.Clone() as TPromotionStore;
      tpromotionStore.pms_PromotionCode = this.pms_PromotionCode;
      tpromotionStore.pms_StoreCode = this.pms_StoreCode;
      tpromotionStore.pms_SiteID = this.pms_SiteID;
      tpromotionStore.pms_InDate = this.pms_InDate;
      tpromotionStore.pms_InUser = this.pms_InUser;
      tpromotionStore.pms_ModDate = this.pms_ModDate;
      tpromotionStore.pms_ModUser = this.pms_ModUser;
      return (object) tpromotionStore;
    }

    public void PutData(TPromotionStore pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.pms_PromotionCode = pSource.pms_PromotionCode;
      this.pms_StoreCode = pSource.pms_StoreCode;
      this.pms_SiteID = pSource.pms_SiteID;
      this.pms_InDate = pSource.pms_InDate;
      this.pms_InUser = pSource.pms_InUser;
      this.pms_ModDate = pSource.pms_ModDate;
      this.pms_ModUser = pSource.pms_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.pms_PromotionCode = p_rs.GetFieldLong("pms_PromotionCode");
        if (this.pms_PromotionCode == 0L)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.pms_StoreCode = p_rs.GetFieldInt("pms_StoreCode");
        this.pms_SiteID = p_rs.GetFieldLong("pms_SiteID");
        this.pms_InDate = p_rs.GetFieldDateTime("pms_InDate");
        this.pms_InUser = p_rs.GetFieldInt("pms_InUser");
        this.pms_ModDate = p_rs.GetFieldDateTime("pms_ModDate");
        this.pms_ModUser = p_rs.GetFieldInt("pms_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_CAMPANIGN), (object) this.TableCode) + " pms_PromotionCode,pms_StoreCode,pms_SiteID,pms_InDate,pms_InUser,pms_ModDate,pms_ModUser) VALUES ( " + string.Format(" {0},{1}", (object) this.pms_PromotionCode, (object) this.pms_StoreCode) + string.Format(",{0}", (object) this.pms_SiteID) + string.Format(",{0},{1}", (object) this.pms_InDate.GetDateToStrInNull(), (object) this.pms_InUser) + string.Format(",{0},{1}", (object) this.pms_ModDate.GetDateToStrInNull(), (object) this.pms_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.pms_PromotionCode, (object) this.pms_StoreCode, (object) this.pms_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TPromotionStore tpromotionStore = this;
      // ISSUE: reference to a compiler-generated method
      tpromotionStore.\u003C\u003En__0();
      if (await tpromotionStore.OleDB.ExecuteAsync(tpromotionStore.InsertQuery()))
        return true;
      tpromotionStore.message = " " + tpromotionStore.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tpromotionStore.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tpromotionStore.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tpromotionStore.pms_PromotionCode, (object) tpromotionStore.pms_StoreCode, (object) tpromotionStore.pms_SiteID) + " 내용 : " + tpromotionStore.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tpromotionStore.message);
      return false;
    }

    public override string DeleteQuery() => string.Format(" DELETE FROM {0}{1}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_CAMPANIGN), (object) this.TableCode) + string.Format(" WHERE {0}={1}", (object) "pms_PromotionCode", (object) this.pms_PromotionCode) + string.Format(" AND {0}={1}", (object) "pms_StoreCode", (object) this.pms_StoreCode) + string.Format(" AND {0}={1}", (object) "pms_SiteID", (object) this.pms_SiteID);

    public override bool Delete()
    {
      this.InsertChecked();
      string pStrExec = this.DeleteQuery();
      if (this.OleDB.Execute(pStrExec))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 삭제 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.pms_PromotionCode, (object) this.pms_StoreCode, (object) this.pms_SiteID) + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n 쿼리 : " + pStrExec + "\n--------------------------------------------------------------------------------------------------\n";
      return false;
    }

    public override async Task<bool> DeleteAsync()
    {
      TPromotionStore tpromotionStore = this;
      // ISSUE: reference to a compiler-generated method
      tpromotionStore.\u003C\u003En__0();
      if (await tpromotionStore.OleDB.ExecuteAsync(tpromotionStore.DeleteQuery()))
        return true;
      tpromotionStore.message = " " + tpromotionStore.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tpromotionStore.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tpromotionStore.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tpromotionStore.pms_PromotionCode, (object) tpromotionStore.pms_StoreCode, (object) tpromotionStore.pms_SiteID) + " 내용 : " + tpromotionStore.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tpromotionStore.message);
      return false;
    }

    public virtual string DeleteQuery(
      long p_pms_PromotionCode,
      int p_pms_StoreCode,
      long p_pms_SiteID = 0)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format(" DELETE FROM {0}{1} ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_CAMPANIGN), (object) this.TableCode));
      stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "pms_PromotionCode", (object) p_pms_PromotionCode));
      stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pms_StoreCode", (object) p_pms_StoreCode));
      if (p_pms_SiteID > 0L)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pms_SiteID", (object) p_pms_SiteID));
      return stringBuilder.ToString();
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "pms_SiteID") && Convert.ToInt64(hashtable[(object) "pms_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "pms_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "pms_PromotionCode") && Convert.ToInt64(hashtable[(object) "pms_PromotionCode"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pms_PromotionCode", hashtable[(object) "pms_PromotionCode"]));
        if (hashtable.ContainsKey((object) "pms_StoreCode") && Convert.ToInt32(hashtable[(object) "pms_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pms_StoreCode", hashtable[(object) "pms_StoreCode"]));
        else if (hashtable.ContainsKey((object) "pms_StoreCode_IN_") && hashtable[(object) "pms_StoreCode_IN_"].ToString().Length > 0)
        {
          if (hashtable[(object) "pms_StoreCode_IN_"].ToString().Contains(","))
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "pms_StoreCode", hashtable[(object) "pms_StoreCode_IN_"]));
          else
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pms_StoreCode", hashtable[(object) "pms_StoreCode_IN_"]));
        }
        else if (hashtable.ContainsKey((object) "_STORE_AUTHS_") && !string.IsNullOrEmpty(hashtable[(object) "_STORE_AUTHS_"].ToString()))
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "pms_StoreCode", hashtable[(object) "_STORE_AUTHS_"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pms_SiteID", (object) num));
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
        stringBuilder.Append(" SELECT  pms_PromotionCode,pms_StoreCode,pms_SiteID,pms_InDate,pms_InUser,pms_ModDate,pms_ModUser");
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
