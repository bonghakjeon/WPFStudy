// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniCampaign.CampaignInfo.PromotionTarget.TPromotionTarget
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

namespace UniBiz.Bo.Models.UniCampaign.CampaignInfo.PromotionTarget
{
  public class TPromotionTarget : UbModelBase<TPromotionTarget>
  {
    private long _pmt_PromotionCode;
    private long _pmt_TargetCode;
    private long _pmt_SiteID;
    private DateTime? _pmt_InDate;
    private int _pmt_InUser;
    private DateTime? _pmt_ModDate;
    private int _pmt_ModUser;

    public override object _Key => (object) new object[2]
    {
      (object) this.pmt_PromotionCode,
      (object) this.pmt_TargetCode
    };

    public long pmt_PromotionCode
    {
      get => this._pmt_PromotionCode;
      set
      {
        this._pmt_PromotionCode = value;
        this.Changed(nameof (pmt_PromotionCode));
      }
    }

    public long pmt_TargetCode
    {
      get => this._pmt_TargetCode;
      set
      {
        this._pmt_TargetCode = value;
        this.Changed(nameof (pmt_TargetCode));
      }
    }

    public long pmt_SiteID
    {
      get => this._pmt_SiteID;
      set
      {
        this._pmt_SiteID = value;
        this.Changed(nameof (pmt_SiteID));
      }
    }

    public DateTime? pmt_InDate
    {
      get => this._pmt_InDate;
      set
      {
        this._pmt_InDate = value;
        this.Changed(nameof (pmt_InDate));
      }
    }

    public int pmt_InUser
    {
      get => this._pmt_InUser;
      set
      {
        this._pmt_InUser = value;
        this.Changed(nameof (pmt_InUser));
      }
    }

    public DateTime? pmt_ModDate
    {
      get => this._pmt_ModDate;
      set
      {
        this._pmt_ModDate = value;
        this.Changed(nameof (pmt_ModDate));
      }
    }

    public int pmt_ModUser
    {
      get => this._pmt_ModUser;
      set
      {
        this._pmt_ModUser = value;
        this.Changed(nameof (pmt_ModUser));
      }
    }

    public override DateTime? ModDate => this.pmt_ModDate ?? (this.pmt_ModDate = this.pmt_InDate);

    public TPromotionTarget() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("pmt_PromotionCode", new TTableColumn()
      {
        tc_orgin_name = "pmt_PromotionCode",
        tc_trans_name = "프로모션코드"
      });
      columnInfo.Add("pmt_TargetCode", new TTableColumn()
      {
        tc_orgin_name = "pmt_TargetCode",
        tc_trans_name = "할인대상코드"
      });
      columnInfo.Add("pmt_SiteID", new TTableColumn()
      {
        tc_orgin_name = "pmt_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("pmt_InDate", new TTableColumn()
      {
        tc_orgin_name = "pmt_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("pmt_InUser", new TTableColumn()
      {
        tc_orgin_name = "pmt_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("pmt_ModDate", new TTableColumn()
      {
        tc_orgin_name = "pmt_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("pmt_ModUser", new TTableColumn()
      {
        tc_orgin_name = "pmt_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.PromotionTarget;
      this.pmt_PromotionCode = 0L;
      this.pmt_TargetCode = 0L;
      this.pmt_SiteID = 0L;
      this.pmt_InDate = new DateTime?();
      this.pmt_InUser = 0;
      this.pmt_ModDate = new DateTime?();
      this.pmt_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TPromotionTarget();

    public override object Clone()
    {
      TPromotionTarget tpromotionTarget = base.Clone() as TPromotionTarget;
      tpromotionTarget.pmt_PromotionCode = this.pmt_PromotionCode;
      tpromotionTarget.pmt_TargetCode = this.pmt_TargetCode;
      tpromotionTarget.pmt_SiteID = this.pmt_SiteID;
      tpromotionTarget.pmt_InDate = this.pmt_InDate;
      tpromotionTarget.pmt_InUser = this.pmt_InUser;
      tpromotionTarget.pmt_ModDate = this.pmt_ModDate;
      tpromotionTarget.pmt_ModUser = this.pmt_ModUser;
      return (object) tpromotionTarget;
    }

    public void PutData(TPromotionTarget pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.pmt_PromotionCode = pSource.pmt_PromotionCode;
      this.pmt_TargetCode = pSource.pmt_TargetCode;
      this.pmt_SiteID = pSource.pmt_SiteID;
      this.pmt_InDate = pSource.pmt_InDate;
      this.pmt_InUser = pSource.pmt_InUser;
      this.pmt_ModDate = pSource.pmt_ModDate;
      this.pmt_ModUser = pSource.pmt_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.pmt_PromotionCode = p_rs.GetFieldLong("pmt_PromotionCode");
        if (this.pmt_PromotionCode == 0L)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.pmt_TargetCode = p_rs.GetFieldLong("pmt_TargetCode");
        this.pmt_SiteID = p_rs.GetFieldLong("pmt_SiteID");
        this.pmt_InDate = p_rs.GetFieldDateTime("pmt_InDate");
        this.pmt_InUser = p_rs.GetFieldInt("pmt_InUser");
        this.pmt_ModDate = p_rs.GetFieldDateTime("pmt_ModDate");
        this.pmt_ModUser = p_rs.GetFieldInt("pmt_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_CAMPANIGN), (object) this.TableCode) + " pmt_PromotionCode,pmt_TargetCode,pmt_SiteID,pmt_InDate,pmt_InUser,pmt_ModDate,pmt_ModUser) VALUES ( " + string.Format(" {0},{1}", (object) this.pmt_PromotionCode, (object) this.pmt_TargetCode) + string.Format(",{0}", (object) this.pmt_SiteID) + string.Format(",{0},{1}", (object) this.pmt_InDate.GetDateToStrInNull(), (object) this.pmt_InUser) + string.Format(",{0},{1}", (object) this.pmt_ModDate.GetDateToStrInNull(), (object) this.pmt_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.pmt_PromotionCode, (object) this.pmt_TargetCode, (object) this.pmt_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TPromotionTarget tpromotionTarget = this;
      // ISSUE: reference to a compiler-generated method
      tpromotionTarget.\u003C\u003En__0();
      if (await tpromotionTarget.OleDB.ExecuteAsync(tpromotionTarget.InsertQuery()))
        return true;
      tpromotionTarget.message = " " + tpromotionTarget.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tpromotionTarget.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tpromotionTarget.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tpromotionTarget.pmt_PromotionCode, (object) tpromotionTarget.pmt_TargetCode, (object) tpromotionTarget.pmt_SiteID) + " 내용 : " + tpromotionTarget.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tpromotionTarget.message);
      return false;
    }

    public override string DeleteQuery() => string.Format(" DELETE FROM {0}{1}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_CAMPANIGN), (object) this.TableCode) + string.Format(" WHERE {0}={1}", (object) "pmt_PromotionCode", (object) this.pmt_PromotionCode) + string.Format(" AND {0}={1}", (object) "pmt_TargetCode", (object) this.pmt_TargetCode) + string.Format(" AND {0}={1}", (object) "pmt_SiteID", (object) this.pmt_SiteID);

    public override bool Delete()
    {
      this.InsertChecked();
      string pStrExec = this.DeleteQuery();
      if (this.OleDB.Execute(pStrExec))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 삭제 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.pmt_PromotionCode, (object) this.pmt_TargetCode, (object) this.pmt_SiteID) + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n 쿼리 : " + pStrExec + "\n--------------------------------------------------------------------------------------------------\n";
      return false;
    }

    public override async Task<bool> DeleteAsync()
    {
      TPromotionTarget tpromotionTarget = this;
      // ISSUE: reference to a compiler-generated method
      tpromotionTarget.\u003C\u003En__0();
      if (await tpromotionTarget.OleDB.ExecuteAsync(tpromotionTarget.DeleteQuery()))
        return true;
      tpromotionTarget.message = " " + tpromotionTarget.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tpromotionTarget.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tpromotionTarget.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tpromotionTarget.pmt_PromotionCode, (object) tpromotionTarget.pmt_TargetCode, (object) tpromotionTarget.pmt_SiteID) + " 내용 : " + tpromotionTarget.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tpromotionTarget.message);
      return false;
    }

    public virtual string DeleteQuery(
      long p_pmt_PromotionCode,
      long p_pmt_TargetCode,
      long p_pmt_SiteID = 0)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format(" DELETE FROM {0}{1} ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_CAMPANIGN), (object) this.TableCode));
      stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "pmt_PromotionCode", (object) p_pmt_PromotionCode));
      stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pmt_TargetCode", (object) p_pmt_TargetCode));
      if (p_pmt_SiteID > 0L)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pmt_SiteID", (object) p_pmt_SiteID));
      return stringBuilder.ToString();
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "pmt_SiteID") && Convert.ToInt64(hashtable[(object) "pmt_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "pmt_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "pmt_PromotionCode") && Convert.ToInt64(hashtable[(object) "pmt_PromotionCode"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pmt_PromotionCode", hashtable[(object) "pmt_PromotionCode"]));
        if (hashtable.ContainsKey((object) "pmt_TargetCode") && Convert.ToInt64(hashtable[(object) "pmt_TargetCode"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pmt_TargetCode", hashtable[(object) "pmt_TargetCode"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pmt_SiteID", (object) num));
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
        stringBuilder.Append(" SELECT  pmt_PromotionCode,pmt_TargetCode,pmt_SiteID,pmt_InDate,pmt_InUser,pmt_ModDate,pmt_ModUser");
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
