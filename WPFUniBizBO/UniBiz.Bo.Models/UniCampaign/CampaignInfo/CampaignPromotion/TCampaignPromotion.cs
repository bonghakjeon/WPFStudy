// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniCampaign.CampaignInfo.CampaignPromotion.TCampaignPromotion
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

namespace UniBiz.Bo.Models.UniCampaign.CampaignInfo.CampaignPromotion
{
  public class TCampaignPromotion : UbModelBase<TCampaignPromotion>
  {
    private long _cip_CampaignCode;
    private long _cip_PromotionCode;
    private long _cip_SiteID;
    private DateTime? _cip_InDate;
    private int _cip_InUser;
    private DateTime? _cip_ModDate;
    private int _cip_ModUser;

    public override object _Key => (object) new object[2]
    {
      (object) this.cip_CampaignCode,
      (object) this.cip_PromotionCode
    };

    public long cip_CampaignCode
    {
      get => this._cip_CampaignCode;
      set
      {
        this._cip_CampaignCode = value;
        this.Changed(nameof (cip_CampaignCode));
      }
    }

    public long cip_PromotionCode
    {
      get => this._cip_PromotionCode;
      set
      {
        this._cip_PromotionCode = value;
        this.Changed(nameof (cip_PromotionCode));
      }
    }

    public long cip_SiteID
    {
      get => this._cip_SiteID;
      set
      {
        this._cip_SiteID = value;
        this.Changed(nameof (cip_SiteID));
      }
    }

    public DateTime? cip_InDate
    {
      get => this._cip_InDate;
      set
      {
        this._cip_InDate = value;
        this.Changed(nameof (cip_InDate));
      }
    }

    public int cip_InUser
    {
      get => this._cip_InUser;
      set
      {
        this._cip_InUser = value;
        this.Changed(nameof (cip_InUser));
      }
    }

    public DateTime? cip_ModDate
    {
      get => this._cip_ModDate;
      set
      {
        this._cip_ModDate = value;
        this.Changed(nameof (cip_ModDate));
      }
    }

    public int cip_ModUser
    {
      get => this._cip_ModUser;
      set
      {
        this._cip_ModUser = value;
        this.Changed(nameof (cip_ModUser));
      }
    }

    public override DateTime? ModDate => this.cip_ModDate ?? (this.cip_ModDate = this.cip_InDate);

    public TCampaignPromotion() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("cip_CampaignCode", new TTableColumn()
      {
        tc_orgin_name = "cip_CampaignCode",
        tc_trans_name = "캠페인코드"
      });
      columnInfo.Add("cip_PromotionCode", new TTableColumn()
      {
        tc_orgin_name = "cip_PromotionCode",
        tc_trans_name = "프로모션코드"
      });
      columnInfo.Add("cip_SiteID", new TTableColumn()
      {
        tc_orgin_name = "cip_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("cip_InDate", new TTableColumn()
      {
        tc_orgin_name = "cip_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("cip_InUser", new TTableColumn()
      {
        tc_orgin_name = "cip_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("cip_ModDate", new TTableColumn()
      {
        tc_orgin_name = "cip_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("cip_ModUser", new TTableColumn()
      {
        tc_orgin_name = "cip_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.CampaignPromotion;
      this.cip_CampaignCode = this.cip_PromotionCode = 0L;
      this.cip_SiteID = 0L;
      this.cip_InDate = new DateTime?();
      this.cip_InUser = 0;
      this.cip_ModDate = new DateTime?();
      this.cip_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TCampaignPromotion();

    public override object Clone()
    {
      TCampaignPromotion tcampaignPromotion = base.Clone() as TCampaignPromotion;
      tcampaignPromotion.cip_CampaignCode = this.cip_CampaignCode;
      tcampaignPromotion.cip_PromotionCode = this.cip_PromotionCode;
      tcampaignPromotion.cip_SiteID = this.cip_SiteID;
      tcampaignPromotion.cip_InDate = this.cip_InDate;
      tcampaignPromotion.cip_InUser = this.cip_InUser;
      tcampaignPromotion.cip_ModDate = this.cip_ModDate;
      tcampaignPromotion.cip_ModUser = this.cip_ModUser;
      return (object) tcampaignPromotion;
    }

    public void PutData(TCampaignPromotion pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.cip_CampaignCode = pSource.cip_CampaignCode;
      this.cip_PromotionCode = pSource.cip_PromotionCode;
      this.cip_SiteID = pSource.cip_SiteID;
      this.cip_InDate = pSource.cip_InDate;
      this.cip_InUser = pSource.cip_InUser;
      this.cip_ModDate = pSource.cip_ModDate;
      this.cip_ModUser = pSource.cip_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.cip_CampaignCode = p_rs.GetFieldLong("cip_CampaignCode");
        if (this.cip_CampaignCode == 0L)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.cip_PromotionCode = p_rs.GetFieldLong("cip_PromotionCode");
        this.cip_SiteID = p_rs.GetFieldLong("cip_SiteID");
        this.cip_InDate = p_rs.GetFieldDateTime("cip_InDate");
        this.cip_InUser = p_rs.GetFieldInt("cip_InUser");
        this.cip_ModDate = p_rs.GetFieldDateTime("cip_ModDate");
        this.cip_ModUser = p_rs.GetFieldInt("cip_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_CAMPANIGN), (object) this.TableCode) + " cip_CampaignCode,cip_PromotionCode,cip_SiteID,cip_InDate,cip_InUser,cip_ModDate,cip_ModUser) VALUES ( " + string.Format(" {0},{1}", (object) this.cip_CampaignCode, (object) this.cip_PromotionCode) + string.Format(",{0}", (object) this.cip_SiteID) + string.Format(",{0},{1}", (object) this.cip_InDate.GetDateToStrInNull(), (object) this.cip_InUser) + string.Format(",{0},{1}", (object) this.cip_ModDate.GetDateToStrInNull(), (object) this.cip_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.cip_CampaignCode, (object) this.cip_PromotionCode, (object) this.cip_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TCampaignPromotion tcampaignPromotion = this;
      // ISSUE: reference to a compiler-generated method
      tcampaignPromotion.\u003C\u003En__0();
      if (await tcampaignPromotion.OleDB.ExecuteAsync(tcampaignPromotion.InsertQuery()))
        return true;
      tcampaignPromotion.message = " " + tcampaignPromotion.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tcampaignPromotion.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tcampaignPromotion.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tcampaignPromotion.cip_CampaignCode, (object) tcampaignPromotion.cip_PromotionCode, (object) tcampaignPromotion.cip_SiteID) + " 내용 : " + tcampaignPromotion.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tcampaignPromotion.message);
      return false;
    }

    public override string DeleteQuery() => string.Format(" DELETE FROM {0}{1}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_CAMPANIGN), (object) this.TableCode) + string.Format(" WHERE {0}={1}", (object) "cip_CampaignCode", (object) this.cip_CampaignCode) + string.Format(" AND {0}={1}", (object) "cip_PromotionCode", (object) this.cip_PromotionCode) + string.Format(" AND {0}={1}", (object) "cip_SiteID", (object) this.cip_SiteID);

    public override bool Delete()
    {
      this.InsertChecked();
      string pStrExec = this.DeleteQuery();
      if (this.OleDB.Execute(pStrExec))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 삭제 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.cip_CampaignCode, (object) this.cip_PromotionCode, (object) this.cip_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n 쿼리 : " + pStrExec + "\n--------------------------------------------------------------------------------------------------\n";
      return false;
    }

    public override async Task<bool> DeleteAsync()
    {
      TCampaignPromotion tcampaignPromotion = this;
      // ISSUE: reference to a compiler-generated method
      tcampaignPromotion.\u003C\u003En__0();
      if (await tcampaignPromotion.OleDB.ExecuteAsync(tcampaignPromotion.DeleteQuery()))
        return true;
      tcampaignPromotion.message = " " + tcampaignPromotion.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tcampaignPromotion.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tcampaignPromotion.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tcampaignPromotion.cip_CampaignCode, (object) tcampaignPromotion.cip_PromotionCode, (object) tcampaignPromotion.cip_SiteID) + " 내용 : " + tcampaignPromotion.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tcampaignPromotion.message);
      return false;
    }

    public virtual string DeleteQuery(
      long p_cip_CampaignCode,
      long p_cip_PromotionCode,
      long p_cig_SiteID = 0)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format(" DELETE FROM {0}{1} ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_CAMPANIGN), (object) this.TableCode));
      stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "cip_CampaignCode", (object) p_cip_CampaignCode));
      stringBuilder.Append(string.Format(" AND {0}={1}", (object) "cip_PromotionCode", (object) p_cip_PromotionCode));
      if (p_cig_SiteID > 0L)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "cip_SiteID", (object) p_cig_SiteID));
      return stringBuilder.ToString();
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "cip_SiteID") && Convert.ToInt64(hashtable[(object) "cip_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "cip_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "cip_CampaignCode") && Convert.ToInt64(hashtable[(object) "cip_CampaignCode"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "cip_CampaignCode", hashtable[(object) "cip_CampaignCode"]));
        if (hashtable.ContainsKey((object) "cip_PromotionCode") && Convert.ToInt64(hashtable[(object) "cip_PromotionCode"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "cip_PromotionCode", hashtable[(object) "cip_PromotionCode"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "cip_SiteID", (object) num));
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
        stringBuilder.Append(" SELECT  cip_CampaignCode,cip_PromotionCode,cip_SiteID,cip_InDate,cip_InUser,cip_ModDate,cip_ModUser");
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
