// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniCampaign.CampaignInfo.PromotionMix.TPromotionMix
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

namespace UniBiz.Bo.Models.UniCampaign.CampaignInfo.PromotionMix
{
  public class TPromotionMix : UbModelBase<TPromotionMix>
  {
    private long _pmm_PromotionCode;
    private long _pmm_ConditionCode;
    private long _pmm_SiteID;
    private DateTime? _pmm_InDate;
    private int _pmm_InUser;
    private DateTime? _pmm_ModDate;
    private int _pmm_ModUser;

    public override object _Key => (object) new object[2]
    {
      (object) this.pmm_PromotionCode,
      (object) this.pmm_ConditionCode
    };

    public long pmm_PromotionCode
    {
      get => this._pmm_PromotionCode;
      set
      {
        this._pmm_PromotionCode = value;
        this.Changed(nameof (pmm_PromotionCode));
      }
    }

    public long pmm_ConditionCode
    {
      get => this._pmm_ConditionCode;
      set
      {
        this._pmm_ConditionCode = value;
        this.Changed(nameof (pmm_ConditionCode));
      }
    }

    public long pmm_SiteID
    {
      get => this._pmm_SiteID;
      set
      {
        this._pmm_SiteID = value;
        this.Changed(nameof (pmm_SiteID));
      }
    }

    public DateTime? pmm_InDate
    {
      get => this._pmm_InDate;
      set
      {
        this._pmm_InDate = value;
        this.Changed(nameof (pmm_InDate));
      }
    }

    public int pmm_InUser
    {
      get => this._pmm_InUser;
      set
      {
        this._pmm_InUser = value;
        this.Changed(nameof (pmm_InUser));
      }
    }

    public DateTime? pmm_ModDate
    {
      get => this._pmm_ModDate;
      set
      {
        this._pmm_ModDate = value;
        this.Changed(nameof (pmm_ModDate));
      }
    }

    public int pmm_ModUser
    {
      get => this._pmm_ModUser;
      set
      {
        this._pmm_ModUser = value;
        this.Changed(nameof (pmm_ModUser));
      }
    }

    public override DateTime? ModDate => this.pmm_ModDate ?? (this.pmm_ModDate = this.pmm_InDate);

    public TPromotionMix() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("pmm_PromotionCode", new TTableColumn()
      {
        tc_orgin_name = "pmm_PromotionCode",
        tc_trans_name = "프로모션코드"
      });
      columnInfo.Add("pmm_ConditionCode", new TTableColumn()
      {
        tc_orgin_name = "pmm_ConditionCode",
        tc_trans_name = "믹스조건코드"
      });
      columnInfo.Add("pmm_SiteID", new TTableColumn()
      {
        tc_orgin_name = "pmm_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("pmm_InDate", new TTableColumn()
      {
        tc_orgin_name = "pmm_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("pmm_InUser", new TTableColumn()
      {
        tc_orgin_name = "pmm_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("pmm_ModDate", new TTableColumn()
      {
        tc_orgin_name = "pmm_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("pmm_ModUser", new TTableColumn()
      {
        tc_orgin_name = "pmm_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.PromotionMix;
      this.pmm_PromotionCode = 0L;
      this.pmm_ConditionCode = 0L;
      this.pmm_SiteID = 0L;
      this.pmm_InDate = new DateTime?();
      this.pmm_InUser = 0;
      this.pmm_ModDate = new DateTime?();
      this.pmm_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TPromotionMix();

    public override object Clone()
    {
      TPromotionMix tpromotionMix = base.Clone() as TPromotionMix;
      tpromotionMix.pmm_PromotionCode = this.pmm_PromotionCode;
      tpromotionMix.pmm_ConditionCode = this.pmm_ConditionCode;
      tpromotionMix.pmm_SiteID = this.pmm_SiteID;
      tpromotionMix.pmm_InDate = this.pmm_InDate;
      tpromotionMix.pmm_InUser = this.pmm_InUser;
      tpromotionMix.pmm_ModDate = this.pmm_ModDate;
      tpromotionMix.pmm_ModUser = this.pmm_ModUser;
      return (object) tpromotionMix;
    }

    public void PutData(TPromotionMix pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.pmm_PromotionCode = pSource.pmm_PromotionCode;
      this.pmm_ConditionCode = pSource.pmm_ConditionCode;
      this.pmm_SiteID = pSource.pmm_SiteID;
      this.pmm_InDate = pSource.pmm_InDate;
      this.pmm_InUser = pSource.pmm_InUser;
      this.pmm_ModDate = pSource.pmm_ModDate;
      this.pmm_ModUser = pSource.pmm_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.pmm_PromotionCode = p_rs.GetFieldLong("pmm_PromotionCode");
        if (this.pmm_PromotionCode == 0L)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.pmm_ConditionCode = p_rs.GetFieldLong("pmm_ConditionCode");
        this.pmm_SiteID = p_rs.GetFieldLong("pmm_SiteID");
        this.pmm_InDate = p_rs.GetFieldDateTime("pmm_InDate");
        this.pmm_InUser = p_rs.GetFieldInt("pmm_InUser");
        this.pmm_ModDate = p_rs.GetFieldDateTime("pmm_ModDate");
        this.pmm_ModUser = p_rs.GetFieldInt("pmm_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_CAMPANIGN), (object) this.TableCode) + " pmm_PromotionCode,pmm_ConditionCode,pmm_SiteID,pmm_InDate,pmm_InUser,pmm_ModDate,pmm_ModUser) VALUES ( " + string.Format(" {0},{1}", (object) this.pmm_PromotionCode, (object) this.pmm_ConditionCode) + string.Format(",{0}", (object) this.pmm_SiteID) + string.Format(",{0},{1}", (object) this.pmm_InDate.GetDateToStrInNull(), (object) this.pmm_InUser) + string.Format(",{0},{1}", (object) this.pmm_ModDate.GetDateToStrInNull(), (object) this.pmm_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.pmm_PromotionCode, (object) this.pmm_ConditionCode, (object) this.pmm_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TPromotionMix tpromotionMix = this;
      // ISSUE: reference to a compiler-generated method
      tpromotionMix.\u003C\u003En__0();
      if (await tpromotionMix.OleDB.ExecuteAsync(tpromotionMix.InsertQuery()))
        return true;
      tpromotionMix.message = " " + tpromotionMix.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tpromotionMix.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tpromotionMix.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tpromotionMix.pmm_PromotionCode, (object) tpromotionMix.pmm_ConditionCode, (object) tpromotionMix.pmm_SiteID) + " 내용 : " + tpromotionMix.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tpromotionMix.message);
      return false;
    }

    public override string DeleteQuery() => string.Format(" DELETE FROM {0}{1}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_CAMPANIGN), (object) this.TableCode) + string.Format(" WHERE {0}={1}", (object) "pmm_PromotionCode", (object) this.pmm_PromotionCode) + string.Format(" AND {0}={1}", (object) "pmm_ConditionCode", (object) this.pmm_ConditionCode) + string.Format(" AND {0}={1}", (object) "pmm_SiteID", (object) this.pmm_SiteID);

    public override bool Delete()
    {
      this.InsertChecked();
      string pStrExec = this.DeleteQuery();
      if (this.OleDB.Execute(pStrExec))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 삭제 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.pmm_PromotionCode, (object) this.pmm_ConditionCode, (object) this.pmm_SiteID) + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n 쿼리 : " + pStrExec + "\n--------------------------------------------------------------------------------------------------\n";
      return false;
    }

    public override async Task<bool> DeleteAsync()
    {
      TPromotionMix tpromotionMix = this;
      // ISSUE: reference to a compiler-generated method
      tpromotionMix.\u003C\u003En__0();
      if (await tpromotionMix.OleDB.ExecuteAsync(tpromotionMix.DeleteQuery()))
        return true;
      tpromotionMix.message = " " + tpromotionMix.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tpromotionMix.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tpromotionMix.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tpromotionMix.pmm_PromotionCode, (object) tpromotionMix.pmm_ConditionCode, (object) tpromotionMix.pmm_SiteID) + " 내용 : " + tpromotionMix.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tpromotionMix.message);
      return false;
    }

    public virtual string DeleteQuery(
      long p_pmm_PromotionCode,
      long p_pmm_ConditionCode,
      long p_pmm_SiteID = 0)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format(" DELETE FROM {0}{1} ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_CAMPANIGN), (object) this.TableCode));
      stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "pmm_PromotionCode", (object) p_pmm_PromotionCode));
      stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pmm_ConditionCode", (object) p_pmm_ConditionCode));
      if (p_pmm_SiteID > 0L)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pmm_SiteID", (object) p_pmm_SiteID));
      return stringBuilder.ToString();
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "pmm_SiteID") && Convert.ToInt64(hashtable[(object) "pmm_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "pmm_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "pmm_PromotionCode") && Convert.ToInt64(hashtable[(object) "pmm_PromotionCode"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pmm_PromotionCode", hashtable[(object) "pmm_PromotionCode"]));
        if (hashtable.ContainsKey((object) "pmm_ConditionCode") && Convert.ToInt64(hashtable[(object) "pmm_ConditionCode"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pmm_ConditionCode", hashtable[(object) "pmm_ConditionCode"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pmm_SiteID", (object) num));
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
        stringBuilder.Append(" SELECT  pmm_PromotionCode,pmm_ConditionCode,pmm_SiteID,pmm_InDate,pmm_InUser,pmm_ModDate,pmm_ModUser");
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
