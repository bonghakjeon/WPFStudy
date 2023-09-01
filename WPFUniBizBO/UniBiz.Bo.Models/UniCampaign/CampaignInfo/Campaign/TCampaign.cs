// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniCampaign.CampaignInfo.Campaign.TCampaign
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

namespace UniBiz.Bo.Models.UniCampaign.CampaignInfo.Campaign
{
  public class TCampaign : UbModelBase<TCampaign>
  {
    private long _ci_CampaignCode;
    private long _ci_SiteID;
    private string _ci_CampaignName;
    private DateTime? _ci_StartDate;
    private DateTime? _ci_EndDate;
    private int _ci_CampaignType;
    private long _ci_CampaignMember;
    private long _ci_CampaignGoods;
    private DateTime? _ci_InDate;
    private int _ci_InUser;
    private DateTime? _ci_ModDate;
    private int _ci_ModUser;

    public override object _Key => (object) new object[1]
    {
      (object) this.ci_CampaignCode
    };

    public long ci_CampaignCode
    {
      get => this._ci_CampaignCode;
      set
      {
        this._ci_CampaignCode = value;
        this.Changed(nameof (ci_CampaignCode));
      }
    }

    public long ci_SiteID
    {
      get => this._ci_SiteID;
      set
      {
        this._ci_SiteID = value;
        this.Changed(nameof (ci_SiteID));
      }
    }

    public string ci_CampaignName
    {
      get => this._ci_CampaignName;
      set
      {
        this._ci_CampaignName = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (ci_CampaignName));
      }
    }

    public DateTime? ci_StartDate
    {
      get => this._ci_StartDate;
      set
      {
        this._ci_StartDate = value;
        this.Changed(nameof (ci_StartDate));
      }
    }

    public DateTime? ci_EndDate
    {
      get => this._ci_EndDate;
      set
      {
        this._ci_EndDate = value;
        this.Changed(nameof (ci_EndDate));
      }
    }

    public int ci_CampaignType
    {
      get => this._ci_CampaignType;
      set
      {
        this._ci_CampaignType = value;
        this.Changed(nameof (ci_CampaignType));
        this.Changed("ci_CampaignTypeDesc");
      }
    }

    public string ci_CampaignTypeDesc => this.ci_CampaignType != 0 ? Enum2StrConverter.ToCampaignType(this.ci_CampaignType).ToDescription() : string.Empty;

    public long ci_CampaignMember
    {
      get => this._ci_CampaignMember;
      set
      {
        this._ci_CampaignMember = value;
        this.Changed(nameof (ci_CampaignMember));
        this.Changed("ci_IsCampaignMember");
      }
    }

    public bool ci_IsCampaignMember => this.ci_CampaignMember > 0L;

    public long ci_CampaignGoods
    {
      get => this._ci_CampaignGoods;
      set
      {
        this._ci_CampaignGoods = value;
        this.Changed(nameof (ci_CampaignGoods));
        this.Changed("ci_IsCampaignGoods");
      }
    }

    public bool ci_IsCampaignGoods => this.ci_CampaignGoods > 0L;

    public DateTime? ci_InDate
    {
      get => this._ci_InDate;
      set
      {
        this._ci_InDate = value;
        this.Changed(nameof (ci_InDate));
      }
    }

    public int ci_InUser
    {
      get => this._ci_InUser;
      set
      {
        this._ci_InUser = value;
        this.Changed(nameof (ci_InUser));
      }
    }

    public DateTime? ci_ModDate
    {
      get => this._ci_ModDate;
      set
      {
        this._ci_ModDate = value;
        this.Changed(nameof (ci_ModDate));
      }
    }

    public int ci_ModUser
    {
      get => this._ci_ModUser;
      set
      {
        this._ci_ModUser = value;
        this.Changed(nameof (ci_ModUser));
      }
    }

    public override DateTime? ModDate => this.ci_ModDate ?? (this.ci_ModDate = this.ci_InDate);

    public TCampaign() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("ci_CampaignCode", new TTableColumn()
      {
        tc_orgin_name = "ci_CampaignCode",
        tc_trans_name = "캠페인코드"
      });
      columnInfo.Add("ci_SiteID", new TTableColumn()
      {
        tc_orgin_name = "ci_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("ci_CampaignName", new TTableColumn()
      {
        tc_orgin_name = "ci_CampaignName",
        tc_trans_name = "캠페인명"
      });
      columnInfo.Add("ci_StartDate", new TTableColumn()
      {
        tc_orgin_name = "ci_StartDate",
        tc_trans_name = "시작일"
      });
      columnInfo.Add("ci_EndDate", new TTableColumn()
      {
        tc_orgin_name = "ci_EndDate",
        tc_trans_name = "종료일"
      });
      columnInfo.Add("ci_CampaignType", new TTableColumn()
      {
        tc_orgin_name = "ci_CampaignType",
        tc_trans_name = "캠페인유형",
        tc_comm_code = 231
      });
      columnInfo.Add("ci_CampaignMember", new TTableColumn()
      {
        tc_orgin_name = "ci_CampaignMember",
        tc_trans_name = "캠페인회원대상여부"
      });
      columnInfo.Add("ci_CampaignGoods", new TTableColumn()
      {
        tc_orgin_name = "ci_CampaignGoods",
        tc_trans_name = "캠페인상품대상여부"
      });
      columnInfo.Add("ci_InDate", new TTableColumn()
      {
        tc_orgin_name = "ci_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("ci_InUser", new TTableColumn()
      {
        tc_orgin_name = "ci_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("ci_ModDate", new TTableColumn()
      {
        tc_orgin_name = "ci_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("ci_ModUser", new TTableColumn()
      {
        tc_orgin_name = "ci_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.Campaign;
      this.ci_CampaignCode = 0L;
      this.ci_SiteID = 0L;
      this.ci_CampaignName = string.Empty;
      this.ci_StartDate = new DateTime?();
      this.ci_EndDate = new DateTime?();
      this.ci_CampaignType = 0;
      this.ci_CampaignMember = this.ci_CampaignGoods = 0L;
      this.ci_InDate = new DateTime?();
      this.ci_InUser = 0;
      this.ci_ModDate = new DateTime?();
      this.ci_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TCampaign();

    public override object Clone()
    {
      TCampaign tcampaign = base.Clone() as TCampaign;
      tcampaign.ci_CampaignCode = this.ci_CampaignCode;
      tcampaign.ci_SiteID = this.ci_SiteID;
      tcampaign.ci_CampaignName = this.ci_CampaignName;
      tcampaign.ci_StartDate = this.ci_StartDate;
      tcampaign.ci_EndDate = this.ci_EndDate;
      tcampaign.ci_CampaignType = this.ci_CampaignType;
      tcampaign.ci_CampaignMember = this.ci_CampaignMember;
      tcampaign.ci_CampaignGoods = this.ci_CampaignGoods;
      tcampaign.ci_InDate = this.ci_InDate;
      tcampaign.ci_InUser = this.ci_InUser;
      tcampaign.ci_ModDate = this.ci_ModDate;
      tcampaign.ci_ModUser = this.ci_ModUser;
      return (object) tcampaign;
    }

    public void PutData(TCampaign pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.ci_CampaignCode = pSource.ci_CampaignCode;
      this.ci_SiteID = pSource.ci_SiteID;
      this.ci_CampaignName = pSource.ci_CampaignName;
      this.ci_StartDate = pSource.ci_StartDate;
      this.ci_EndDate = pSource.ci_EndDate;
      this.ci_CampaignType = pSource.ci_CampaignType;
      this.ci_CampaignMember = pSource.ci_CampaignMember;
      this.ci_CampaignGoods = pSource.ci_CampaignGoods;
      this.ci_InDate = pSource.ci_InDate;
      this.ci_InUser = pSource.ci_InUser;
      this.ci_ModDate = pSource.ci_ModDate;
      this.ci_ModUser = pSource.ci_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.ci_CampaignCode = p_rs.GetFieldLong("ci_CampaignCode");
        if (this.ci_CampaignCode == 0L)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.ci_SiteID = p_rs.GetFieldLong("ci_SiteID");
        this.ci_CampaignName = p_rs.GetFieldString("ci_CampaignName");
        this.ci_StartDate = p_rs.GetFieldDateTime("ci_StartDate");
        this.ci_EndDate = p_rs.GetFieldDateTime("ci_EndDate");
        this.ci_CampaignType = p_rs.GetFieldInt("ci_CampaignType");
        this.ci_CampaignMember = p_rs.GetFieldLong("ci_CampaignMember");
        this.ci_CampaignGoods = p_rs.GetFieldLong("ci_CampaignGoods");
        this.ci_InDate = p_rs.GetFieldDateTime("ci_InDate");
        this.ci_InUser = p_rs.GetFieldInt("ci_InUser");
        this.ci_ModDate = p_rs.GetFieldDateTime("ci_ModDate");
        this.ci_ModUser = p_rs.GetFieldInt("ci_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_CAMPANIGN), (object) this.TableCode) + " ci_CampaignCode,ci_SiteID,ci_CampaignName,ci_StartDate,ci_EndDate,ci_CampaignType,ci_CampaignMember,ci_CampaignGoods,ci_InDate,ci_InUser,ci_ModDate,ci_ModUser) VALUES ( " + string.Format(" {0}", (object) this.ci_CampaignCode) + string.Format(",{0}", (object) this.ci_SiteID) + ",'" + this.ci_CampaignName + "'," + this.ci_StartDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + "," + this.ci_EndDate.GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'") + string.Format(",{0},{1},{2}", (object) this.ci_CampaignType, (object) this.ci_CampaignMember, (object) this.ci_CampaignGoods) + string.Format(",{0},{1}", (object) this.ci_InDate.GetDateToStrInNull(), (object) this.ci_InUser) + string.Format(",{0},{1}", (object) this.ci_ModDate.GetDateToStrInNull(), (object) this.ci_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.ci_CampaignCode, (object) this.ci_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TCampaign tcampaign = this;
      // ISSUE: reference to a compiler-generated method
      tcampaign.\u003C\u003En__0();
      if (await tcampaign.OleDB.ExecuteAsync(tcampaign.InsertQuery()))
        return true;
      tcampaign.message = " " + tcampaign.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tcampaign.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tcampaign.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tcampaign.ci_CampaignCode, (object) tcampaign.ci_SiteID) + " 내용 : " + tcampaign.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tcampaign.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_CAMPANIGN), (object) this.TableCode) + " ci_CampaignName='" + this.ci_CampaignName + "',ci_StartDate=" + this.ci_StartDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + ",ci_EndDate=" + this.ci_EndDate.GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'") + string.Format(",{0}={1}", (object) "ci_CampaignType", (object) this.ci_CampaignType) + string.Format(",{0}={1},{2}={3}", (object) "ci_CampaignMember", (object) this.ci_CampaignMember, (object) "ci_CampaignGoods", (object) this.ci_CampaignGoods) + string.Format(",{0}={1},{2}={3}", (object) "ci_ModDate", (object) this.ci_ModDate.GetDateToStrInNull(), (object) "ci_ModUser", (object) this.ci_ModUser) + string.Format(" WHERE {0}={1}", (object) "ci_CampaignCode", (object) this.ci_CampaignCode) + string.Format(" AND {0}={1}", (object) "ci_SiteID", (object) this.ci_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.ci_CampaignCode, (object) this.ci_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TCampaign tcampaign = this;
      // ISSUE: reference to a compiler-generated method
      tcampaign.\u003C\u003En__1();
      if (await tcampaign.OleDB.ExecuteAsync(tcampaign.UpdateQuery()))
        return true;
      tcampaign.message = " " + tcampaign.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tcampaign.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tcampaign.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tcampaign.ci_CampaignCode, (object) tcampaign.ci_SiteID) + " 내용 : " + tcampaign.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tcampaign.message);
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
      stringBuilder.Append(" ci_CampaignName='" + this.ci_CampaignName + "',ci_StartDate=" + this.ci_StartDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + ",ci_EndDate=" + this.ci_EndDate.GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'") + string.Format(",{0}={1}", (object) "ci_CampaignType", (object) this.ci_CampaignType) + string.Format(",{0}={1},{2}={3}", (object) "ci_CampaignMember", (object) this.ci_CampaignMember, (object) "ci_CampaignGoods", (object) this.ci_CampaignGoods) + string.Format(",{0}={1},{2}={3}", (object) "ci_ModDate", (object) this.ci_ModDate.GetDateToStrInNull(), (object) "ci_ModUser", (object) this.ci_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.ci_CampaignCode, (object) this.ci_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TCampaign tcampaign = this;
      // ISSUE: reference to a compiler-generated method
      tcampaign.\u003C\u003En__1();
      if (await tcampaign.OleDB.ExecuteAsync(tcampaign.UpdateExInsertQuery()))
        return true;
      tcampaign.message = " " + tcampaign.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tcampaign.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tcampaign.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tcampaign.ci_CampaignCode, (object) tcampaign.ci_SiteID) + " 내용 : " + tcampaign.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tcampaign.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "ci_SiteID") && Convert.ToInt64(hashtable[(object) "ci_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "ci_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "ci_CampaignCode") && Convert.ToInt64(hashtable[(object) "ci_CampaignCode"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ci_CampaignCode", hashtable[(object) "ci_CampaignCode"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ci_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "ci_CampaignName") && !string.IsNullOrEmpty(hashtable[(object) "ci_CampaignName"].ToString()))
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "ci_CampaignName", hashtable[(object) "ci_CampaignName"]));
        if (hashtable.ContainsKey((object) "ci_StartDate") && !string.IsNullOrEmpty(hashtable[(object) "ci_StartDate"].ToString()))
          stringBuilder.Append(" AND ci_StartDate<=" + new DateTime?((DateTime) hashtable[(object) "ci_StartDate"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + " AND ci_StartDate>=" + new DateTime?((DateTime) hashtable[(object) "ci_StartDate"]).GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'"));
        if (hashtable.ContainsKey((object) "ci_EndDate") && !string.IsNullOrEmpty(hashtable[(object) "ci_EndDate"].ToString()))
          stringBuilder.Append(" AND ci_EndDate<=" + new DateTime?((DateTime) hashtable[(object) "ci_EndDate"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + " AND ci_EndDate>=" + new DateTime?((DateTime) hashtable[(object) "ci_EndDate"]).GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'"));
        if (hashtable.ContainsKey((object) "_DT_DATE_") && !string.IsNullOrEmpty(hashtable[(object) "_DT_DATE_"].ToString()))
        {
          stringBuilder.Append(" AND ci_StartDate <='" + new DateTime?((DateTime) hashtable[(object) "_DT_DATE_"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND ci_EndDate >='" + new DateTime?((DateTime) hashtable[(object) "_DT_DATE_"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
        }
        if (hashtable.ContainsKey((object) "_DT_START_DATE_") && !string.IsNullOrEmpty(hashtable[(object) "_DT_START_DATE_"].ToString()) && hashtable.ContainsKey((object) "_DT_END_DATE_") && !string.IsNullOrEmpty(hashtable[(object) "_DT_END_DATE_"].ToString()))
        {
          string dateToStr1 = new DateTime?((DateTime) hashtable[(object) "_DT_START_DATE_"]).GetDateToStr("yyyy-MM-dd 00:00:00");
          string dateToStr2 = new DateTime?((DateTime) hashtable[(object) "_DT_START_DATE_"]).GetDateToStr("yyyy-MM-dd 23:59:59");
          string dateToStr3 = new DateTime?((DateTime) hashtable[(object) "_DT_END_DATE_"]).GetDateToStr("yyyy-MM-dd 00:00:00");
          string dateToStr4 = new DateTime?((DateTime) hashtable[(object) "_DT_END_DATE_"]).GetDateToStr("yyyy-MM-dd 23:59:59");
          stringBuilder.Append(" AND (");
          stringBuilder.Append(" (ci_StartDate <= '" + dateToStr1 + "' AND ci_EndDate >= '" + dateToStr2 + "' )");
          stringBuilder.Append(" OR (ci_StartDate <= '" + dateToStr3 + "' AND ci_EndDate >= '" + dateToStr4 + "' )");
          stringBuilder.Append(" OR (ci_StartDate >= '" + dateToStr1 + "' AND ci_EndDate <= '" + dateToStr4 + "' )");
          stringBuilder.Append(") ");
        }
        if (hashtable.ContainsKey((object) "ci_CampaignType") && Convert.ToInt32(hashtable[(object) "ci_CampaignType"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ci_CampaignType", hashtable[(object) "ci_CampaignType"]));
        if (hashtable.ContainsKey((object) "ci_CampaignMember_ALL_") && string.IsNullOrEmpty(hashtable[(object) "ci_CampaignMember_ALL_"].ToString()))
        {
          if (Convert.ToBoolean(hashtable[(object) "ci_CampaignMember_ALL_"].ToString()))
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ci_CampaignMember", (object) 0));
          else
            stringBuilder.Append(string.Format(" AND {0}>{1}", (object) "ci_CampaignMember", (object) 0));
        }
        if (hashtable.ContainsKey((object) "ci_CampaignMember") && Convert.ToInt64(hashtable[(object) "ci_CampaignMember"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ci_CampaignMember", hashtable[(object) "ci_CampaignMember"]));
        if (hashtable.ContainsKey((object) "ci_CampaignGoods_ALL_") && string.IsNullOrEmpty(hashtable[(object) "ci_CampaignGoods_ALL_"].ToString()))
        {
          if (Convert.ToBoolean(hashtable[(object) "ci_CampaignGoods_ALL_"].ToString()))
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ci_CampaignGoods", (object) 0));
          else
            stringBuilder.Append(string.Format(" AND {0}>{1}", (object) "ci_CampaignGoods", (object) 0));
        }
        if (hashtable.ContainsKey((object) "ci_CampaignGoods") && Convert.ToInt64(hashtable[(object) "ci_CampaignGoods"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ci_CampaignGoods", hashtable[(object) "ci_CampaignGoods"]));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && !string.IsNullOrEmpty(hashtable[(object) "_KEY_WORD_"].ToString()))
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "ci_CampaignName", hashtable[(object) "_KEY_WORD_"]));
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
        string uniCampanign = UbModelBase.UNI_CAMPANIGN;
        string str = this.TableCode.ToString();
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniCampanign = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
        }
        stringBuilder.Append(" SELECT  ci_CampaignCode,ci_SiteID,ci_CampaignName,ci_StartDate,ci_EndDate,ci_CampaignType,ci_CampaignMember,ci_CampaignGoods,ci_InDate,ci_InUser,ci_ModDate,ci_ModUser");
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
