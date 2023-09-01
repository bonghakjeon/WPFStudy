// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.Environment.MemberCalcCycle.TMemberCalcCycle
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
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.TableInfo;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniMembers.Environment.MemberCalcCycle
{
  public class TMemberCalcCycle : UbModelBase<TMemberCalcCycle>
  {
    private long _mcc_SiteID;
    private int _mcc_CalcCycleDiv;
    private DateTime? _mcc_StartDate;
    private DateTime? _mcc_EndDate;
    private int _mcc_CalcCycle;
    private int _mcc_CalcPeriod;
    private DateTime? _mcc_InDate;
    private int _mcc_InUser;
    private DateTime? _mcc_ModDate;
    private int _mcc_ModUser;

    public override object _Key => (object) new object[3]
    {
      (object) this.mcc_SiteID,
      (object) this.mcc_CalcCycleDiv,
      (object) this.mcc_StartDate
    };

    public long mcc_SiteID
    {
      get => this._mcc_SiteID;
      set
      {
        this._mcc_SiteID = value;
        this.Changed(nameof (mcc_SiteID));
      }
    }

    public int mcc_CalcCycleDiv
    {
      get => this._mcc_CalcCycleDiv;
      set
      {
        this._mcc_CalcCycleDiv = value;
        this.Changed(nameof (mcc_CalcCycleDiv));
        this.Changed("mcc_CalcCycleDivDesc");
      }
    }

    public string mcc_CalcCycleDivDesc => this.mcc_CalcCycleDiv != 0 ? Enum2StrConverter.ToMemberCalcCycleDiv(this.mcc_CalcCycleDiv).ToDescription() : string.Empty;

    public DateTime? mcc_StartDate
    {
      get => this._mcc_StartDate;
      set
      {
        this._mcc_StartDate = value;
        this.Changed(nameof (mcc_StartDate));
        this.Changed("IntStartDate");
      }
    }

    [JsonIgnore]
    public int IntStartDate => this.mcc_StartDate.HasValue ? this.mcc_StartDate.Value.ToIntFormat() : 0;

    public DateTime? mcc_EndDate
    {
      get => this._mcc_EndDate;
      set
      {
        this._mcc_EndDate = value;
        this.Changed(nameof (mcc_EndDate));
        this.Changed("IntEndDate");
      }
    }

    [JsonIgnore]
    public int IntEndDate => this.mcc_EndDate.HasValue ? this.mcc_EndDate.Value.ToIntFormat() : 0;

    public int mcc_CalcCycle
    {
      get => this._mcc_CalcCycle;
      set
      {
        this._mcc_CalcCycle = value;
        this.Changed(nameof (mcc_CalcCycle));
      }
    }

    public int mcc_CalcPeriod
    {
      get => this._mcc_CalcPeriod;
      set
      {
        this._mcc_CalcPeriod = value;
        this.Changed(nameof (mcc_CalcPeriod));
      }
    }

    public DateTime? mcc_InDate
    {
      get => this._mcc_InDate;
      set
      {
        this._mcc_InDate = value;
        this.Changed(nameof (mcc_InDate));
      }
    }

    public int mcc_InUser
    {
      get => this._mcc_InUser;
      set
      {
        this._mcc_InUser = value;
        this.Changed(nameof (mcc_InUser));
      }
    }

    public DateTime? mcc_ModDate
    {
      get => this._mcc_ModDate;
      set
      {
        this._mcc_ModDate = value;
        this.Changed(nameof (mcc_ModDate));
      }
    }

    public int mcc_ModUser
    {
      get => this._mcc_ModUser;
      set
      {
        this._mcc_ModUser = value;
        this.Changed(nameof (mcc_ModUser));
      }
    }

    public TMemberCalcCycle() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("mcc_SiteID", new TTableColumn()
      {
        tc_orgin_name = "mcc_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("mcc_CalcCycleDiv", new TTableColumn()
      {
        tc_orgin_name = "mcc_CalcCycleDiv",
        tc_trans_name = "산정주기구분",
        tc_comm_code = 191
      });
      columnInfo.Add("mcc_StartDate", new TTableColumn()
      {
        tc_orgin_name = "mcc_StartDate",
        tc_trans_name = "시작일"
      });
      columnInfo.Add("mcc_EndDate", new TTableColumn()
      {
        tc_orgin_name = "mcc_EndDate",
        tc_trans_name = "종료일"
      });
      columnInfo.Add("mcc_CalcCycle", new TTableColumn()
      {
        tc_orgin_name = "mcc_CalcCycle",
        tc_trans_name = "산정주기"
      });
      columnInfo.Add("mcc_CalcPeriod", new TTableColumn()
      {
        tc_orgin_name = "mcc_CalcPeriod",
        tc_trans_name = "산정기간"
      });
      columnInfo.Add("mcc_InDate", new TTableColumn()
      {
        tc_orgin_name = "mcc_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("mcc_InUser", new TTableColumn()
      {
        tc_orgin_name = "mcc_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("mcc_ModDate", new TTableColumn()
      {
        tc_orgin_name = "mcc_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("mcc_ModUser", new TTableColumn()
      {
        tc_orgin_name = "mcc_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.MemberCalcCycle;
      this.mcc_SiteID = 0L;
      this.mcc_CalcCycleDiv = 0;
      this.mcc_StartDate = new DateTime?();
      this.mcc_EndDate = new DateTime?();
      this.mcc_CalcCycle = this.mcc_CalcPeriod = 0;
      this.mcc_InDate = new DateTime?();
      this.mcc_InUser = 0;
      this.mcc_ModDate = new DateTime?();
      this.mcc_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TMemberCalcCycle();

    public override object Clone()
    {
      TMemberCalcCycle tmemberCalcCycle = base.Clone() as TMemberCalcCycle;
      tmemberCalcCycle.mcc_SiteID = this.mcc_SiteID;
      tmemberCalcCycle.mcc_CalcCycleDiv = this.mcc_CalcCycleDiv;
      tmemberCalcCycle.mcc_StartDate = this.mcc_StartDate;
      tmemberCalcCycle.mcc_EndDate = this.mcc_EndDate;
      tmemberCalcCycle.mcc_CalcCycle = this.mcc_CalcCycle;
      tmemberCalcCycle.mcc_CalcPeriod = this.mcc_CalcPeriod;
      tmemberCalcCycle.mcc_InDate = this.mcc_InDate;
      tmemberCalcCycle.mcc_InUser = this.mcc_InUser;
      tmemberCalcCycle.mcc_ModDate = this.mcc_ModDate;
      tmemberCalcCycle.mcc_ModUser = this.mcc_ModUser;
      return (object) tmemberCalcCycle;
    }

    public void PutData(TMemberCalcCycle pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.mcc_SiteID = pSource.mcc_SiteID;
      this.mcc_CalcCycleDiv = pSource.mcc_CalcCycleDiv;
      this.mcc_StartDate = pSource.mcc_StartDate;
      this.mcc_EndDate = pSource.mcc_EndDate;
      this.mcc_CalcCycle = pSource.mcc_CalcCycle;
      this.mcc_CalcPeriod = pSource.mcc_CalcPeriod;
      this.mcc_InDate = pSource.mcc_InDate;
      this.mcc_InUser = pSource.mcc_InUser;
      this.mcc_ModDate = pSource.mcc_ModDate;
      this.mcc_ModUser = pSource.mcc_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.mcc_SiteID = p_rs.GetFieldLong("mcc_SiteID");
        this.mcc_CalcCycleDiv = p_rs.GetFieldInt("mcc_CalcCycleDiv");
        if (this.mcc_CalcCycleDiv == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.mcc_StartDate = p_rs.GetFieldDateTime("mcc_StartDate");
        this.mcc_EndDate = p_rs.GetFieldDateTime("mcc_EndDate");
        this.mcc_CalcCycle = p_rs.GetFieldInt("mcc_CalcCycle");
        this.mcc_CalcPeriod = p_rs.GetFieldInt("mcc_CalcPeriod");
        this.mcc_InDate = p_rs.GetFieldDateTime("mcc_InDate");
        this.mcc_InUser = p_rs.GetFieldInt("mcc_InUser");
        this.mcc_ModDate = p_rs.GetFieldDateTime("mcc_ModDate");
        this.mcc_ModUser = p_rs.GetFieldInt("mcc_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode) + " mcc_SiteID,mcc_CalcCycleDiv,mcc_StartDate,mcc_EndDate,mcc_CalcCycle,mcc_CalcPeriod,mcc_InDate,mcc_InUser,mcc_ModDate,mcc_ModUser) VALUES ( " + string.Format(" {0},{1}", (object) this.mcc_SiteID, (object) this.mcc_CalcCycleDiv) + "," + this.mcc_StartDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + "," + this.mcc_EndDate.GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'") + string.Format(",{0},{1}", (object) this.mcc_CalcCycle, (object) this.mcc_CalcPeriod) + string.Format(",{0},{1}", (object) this.mcc_InDate.GetDateToStrInNull(), (object) this.mcc_InUser) + string.Format(",{0},{1}", (object) this.mcc_ModDate.GetDateToStrInNull(), (object) this.mcc_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.mcc_SiteID, (object) this.mcc_CalcCycleDiv, (object) this.mcc_StartDate) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TMemberCalcCycle tmemberCalcCycle = this;
      // ISSUE: reference to a compiler-generated method
      tmemberCalcCycle.\u003C\u003En__0();
      if (await tmemberCalcCycle.OleDB.ExecuteAsync(tmemberCalcCycle.InsertQuery()))
        return true;
      tmemberCalcCycle.message = " " + tmemberCalcCycle.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberCalcCycle.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberCalcCycle.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tmemberCalcCycle.mcc_SiteID, (object) tmemberCalcCycle.mcc_CalcCycleDiv, (object) tmemberCalcCycle.mcc_StartDate) + " 내용 : " + tmemberCalcCycle.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberCalcCycle.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode) + " mcc_EndDate=" + this.mcc_EndDate.GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'") + string.Format(",{0}={1}", (object) "mcc_CalcCycle", (object) this.mcc_CalcCycle) + string.Format(",{0}={1}", (object) "mcc_CalcPeriod", (object) this.mcc_CalcPeriod) + string.Format(",{0}={1},{2}={3}", (object) "mcc_ModDate", (object) this.mcc_ModDate.GetDateToStrInNull(), (object) "mcc_ModUser", (object) this.mcc_ModUser) + string.Format(" WHERE {0}={1}", (object) "mcc_SiteID", (object) this.mcc_SiteID) + string.Format(" AND {0}={1}", (object) "mcc_CalcCycleDiv", (object) this.mcc_CalcCycleDiv) + " AND mcc_StartDate=" + this.mcc_StartDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'");

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.mcc_SiteID, (object) this.mcc_CalcCycleDiv, (object) this.mcc_StartDate) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TMemberCalcCycle tmemberCalcCycle = this;
      // ISSUE: reference to a compiler-generated method
      tmemberCalcCycle.\u003C\u003En__1();
      if (await tmemberCalcCycle.OleDB.ExecuteAsync(tmemberCalcCycle.UpdateQuery()))
        return true;
      tmemberCalcCycle.message = " " + tmemberCalcCycle.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberCalcCycle.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberCalcCycle.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tmemberCalcCycle.mcc_SiteID, (object) tmemberCalcCycle.mcc_CalcCycleDiv, (object) tmemberCalcCycle.mcc_StartDate) + " 내용 : " + tmemberCalcCycle.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberCalcCycle.message);
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
      stringBuilder.Append(" mcc_EndDate=" + this.mcc_EndDate.GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'") + string.Format(",{0}={1}", (object) "mcc_CalcCycle", (object) this.mcc_CalcCycle) + string.Format(",{0}={1}", (object) "mcc_CalcPeriod", (object) this.mcc_CalcPeriod) + string.Format(",{0}={1},{2}={3}", (object) "mcc_ModDate", (object) this.mcc_ModDate.GetDateToStrInNull(), (object) "mcc_ModUser", (object) this.mcc_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.mcc_SiteID, (object) this.mcc_CalcCycleDiv, (object) this.mcc_StartDate) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TMemberCalcCycle tmemberCalcCycle = this;
      // ISSUE: reference to a compiler-generated method
      tmemberCalcCycle.\u003C\u003En__1();
      if (await tmemberCalcCycle.OleDB.ExecuteAsync(tmemberCalcCycle.UpdateExInsertQuery()))
        return true;
      tmemberCalcCycle.message = " " + tmemberCalcCycle.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberCalcCycle.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberCalcCycle.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tmemberCalcCycle.mcc_SiteID, (object) tmemberCalcCycle.mcc_CalcCycleDiv, (object) tmemberCalcCycle.mcc_StartDate) + " 내용 : " + tmemberCalcCycle.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberCalcCycle.message);
      return false;
    }

    public string UpdateStartDateQuery(
      long p_mcc_SiteID,
      int p_mcc_CalcCycleDiv,
      DateTime p_mcc_StartDate,
      DateTime pModStartDate)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode));
      stringBuilder.Append(" mcc_StartDate=" + new DateTime?(pModStartDate).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'"));
      if (this.mcc_ModDate.HasValue)
        stringBuilder.Append(",mcc_ModDate=" + this.mcc_ModDate.GetDateToStrInNull());
      stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "mcc_SiteID", (object) p_mcc_SiteID));
      stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mcc_CalcCycleDiv", (object) p_mcc_CalcCycleDiv));
      stringBuilder.Append(" AND mcc_StartDate=" + new DateTime?(p_mcc_StartDate).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'"));
      return stringBuilder.ToString();
    }

    public bool UpdateStartDate(
      long p_mcc_SiteID,
      int p_mcc_CalcCycleDiv,
      DateTime p_mcc_StartDate,
      DateTime pModStartDate)
    {
      this.UpdateChecked();
      this.mcc_ModDate = new DateTime?(DateTime.Now);
      if (this.OleDB.Execute(this.UpdateStartDateQuery(p_mcc_SiteID, p_mcc_CalcCycleDiv, p_mcc_StartDate, pModStartDate)))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2}) => {3})\n", (object) p_mcc_SiteID, (object) p_mcc_CalcCycleDiv, (object) new DateTime?(p_mcc_StartDate).GetDateToStr("yyyy-MM-dd"), (object) new DateTime?(pModStartDate).GetDateToStr("yyyy-MM-dd")) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public async Task<bool> UpdateStartDateAsync(
      long p_mcc_SiteID,
      int p_mcc_CalcCycleDiv,
      DateTime p_mcc_StartDate,
      DateTime pModStartDate)
    {
      TMemberCalcCycle tmemberCalcCycle = this;
      // ISSUE: reference to a compiler-generated method
      tmemberCalcCycle.\u003C\u003En__1();
      tmemberCalcCycle.mcc_ModDate = new DateTime?(DateTime.Now);
      if (await tmemberCalcCycle.OleDB.ExecuteAsync(tmemberCalcCycle.UpdateStartDateQuery(p_mcc_SiteID, p_mcc_CalcCycleDiv, p_mcc_StartDate, pModStartDate)))
        return true;
      tmemberCalcCycle.message = " " + tmemberCalcCycle.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberCalcCycle.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberCalcCycle.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2}) => {3})\n", (object) p_mcc_SiteID, (object) p_mcc_CalcCycleDiv, (object) new DateTime?(p_mcc_StartDate).GetDateToStr("yyyy-MM-dd"), (object) new DateTime?(pModStartDate).GetDateToStr("yyyy-MM-dd")) + " 내용 : " + tmemberCalcCycle.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberCalcCycle.message);
      return false;
    }

    public string UpdateEndDateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode) + " mcc_EndDate=" + this.mcc_EndDate.GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'") + string.Format(",{0}={1},{2}={3}", (object) "mcc_ModDate", (object) this.mcc_ModDate.GetDateToStrInNull(), (object) "mcc_ModUser", (object) this.mcc_ModUser) + string.Format(" WHERE {0}={1}", (object) "mcc_SiteID", (object) this.mcc_SiteID) + string.Format(" AND {0}={1}", (object) "mcc_CalcCycleDiv", (object) this.mcc_CalcCycleDiv) + " AND mcc_StartDate=" + this.mcc_StartDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'");

    public bool UpdateEndDate()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateEndDateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.mcc_SiteID, (object) this.mcc_CalcCycleDiv, (object) this.mcc_StartDate) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public async Task<bool> UpdateEndDateAsync()
    {
      TMemberCalcCycle tmemberCalcCycle = this;
      // ISSUE: reference to a compiler-generated method
      tmemberCalcCycle.\u003C\u003En__1();
      if (await tmemberCalcCycle.OleDB.ExecuteAsync(tmemberCalcCycle.UpdateEndDateQuery()))
        return true;
      tmemberCalcCycle.message = " " + tmemberCalcCycle.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberCalcCycle.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberCalcCycle.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tmemberCalcCycle.mcc_SiteID, (object) tmemberCalcCycle.mcc_CalcCycleDiv, (object) tmemberCalcCycle.mcc_StartDate) + " 내용 : " + tmemberCalcCycle.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberCalcCycle.message);
      return false;
    }

    public override string DeleteQuery() => string.Format(" DELETE FROM {0}{1}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode) + string.Format(" WHERE {0}={1}", (object) "mcc_SiteID", (object) this.mcc_SiteID) + string.Format(" AND {0}={1}", (object) "mcc_CalcCycleDiv", (object) this.mcc_CalcCycleDiv) + " AND mcc_StartDate=" + this.mcc_StartDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'");

    public override bool Delete()
    {
      this.InsertChecked();
      string pStrExec = this.DeleteQuery();
      if (this.OleDB.Execute(pStrExec))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 삭제 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.mcc_SiteID, (object) this.mcc_CalcCycleDiv, (object) this.mcc_StartDate) + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n 쿼리 : " + pStrExec + "\n--------------------------------------------------------------------------------------------------\n";
      return false;
    }

    public override async Task<bool> DeleteAsync()
    {
      TMemberCalcCycle tmemberCalcCycle = this;
      // ISSUE: reference to a compiler-generated method
      tmemberCalcCycle.\u003C\u003En__0();
      if (await tmemberCalcCycle.OleDB.ExecuteAsync(tmemberCalcCycle.DeleteQuery()))
        return true;
      tmemberCalcCycle.message = " " + tmemberCalcCycle.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberCalcCycle.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberCalcCycle.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tmemberCalcCycle.mcc_SiteID, (object) tmemberCalcCycle.mcc_CalcCycleDiv, (object) tmemberCalcCycle.mcc_StartDate) + " 내용 : " + tmemberCalcCycle.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberCalcCycle.message);
      return false;
    }

    public virtual string DeleteQuery(
      long p_mcc_SiteID,
      int p_mcc_CalcCycleDiv,
      DateTime p_mcc_StartDate)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format(" DELETE FROM {0}{1} ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode));
      stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "mcc_SiteID", (object) p_mcc_SiteID));
      stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mcc_CalcCycleDiv", (object) p_mcc_CalcCycleDiv));
      stringBuilder.Append(" AND mcc_StartDate=" + new DateTime?(p_mcc_StartDate).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'"));
      return stringBuilder.ToString();
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "mcc_SiteID") && Convert.ToInt64(hashtable[(object) "mcc_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "mcc_SiteID"].ToString());
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mcc_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "mcc_CalcCycleDiv") && Convert.ToInt32(hashtable[(object) "mcc_CalcCycleDiv"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mcc_CalcCycleDiv", hashtable[(object) "mcc_CalcCycleDiv"]));
        if (hashtable.ContainsKey((object) "mcc_StartDate") && !string.IsNullOrEmpty(hashtable[(object) "mcc_StartDate"].ToString()))
          stringBuilder.Append(" AND mcc_StartDate<=" + new DateTime?((DateTime) hashtable[(object) "mcc_StartDate"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + " AND mcc_StartDate>=" + new DateTime?((DateTime) hashtable[(object) "mcc_StartDate"]).GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'"));
        if (hashtable.ContainsKey((object) "_DT_DATE_") && !string.IsNullOrEmpty(hashtable[(object) "_DT_DATE_"].ToString()))
        {
          stringBuilder.Append(" AND mcc_StartDate <='" + new DateTime?((DateTime) hashtable[(object) "_DT_DATE_"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND mcc_EndDate >='" + new DateTime?((DateTime) hashtable[(object) "_DT_DATE_"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
        }
        if (hashtable.ContainsKey((object) "_DT_START_DATE_") && !string.IsNullOrEmpty(hashtable[(object) "_DT_START_DATE_"].ToString()) && hashtable.ContainsKey((object) "_DT_END_DATE_") && !string.IsNullOrEmpty(hashtable[(object) "_DT_END_DATE_"].ToString()))
        {
          string dateToStr1 = new DateTime?((DateTime) hashtable[(object) "_DT_START_DATE_"]).GetDateToStr("yyyy-MM-dd 00:00:00");
          string dateToStr2 = new DateTime?((DateTime) hashtable[(object) "_DT_START_DATE_"]).GetDateToStr("yyyy-MM-dd 23:59:59");
          string dateToStr3 = new DateTime?((DateTime) hashtable[(object) "_DT_END_DATE_"]).GetDateToStr("yyyy-MM-dd 00:00:00");
          string dateToStr4 = new DateTime?((DateTime) hashtable[(object) "_DT_END_DATE_"]).GetDateToStr("yyyy-MM-dd 23:59:59");
          stringBuilder.Append(" AND (");
          stringBuilder.Append(" (mcc_StartDate <= '" + dateToStr1 + "' AND mcc_EndDate >= '" + dateToStr2 + "' )");
          stringBuilder.Append(" OR (mcc_StartDate <= '" + dateToStr3 + "' AND mcc_EndDate >= '" + dateToStr4 + "' )");
          stringBuilder.Append(" OR (mcc_StartDate >= '" + dateToStr1 + "' AND mcc_EndDate <= '" + dateToStr4 + "' )");
          stringBuilder.Append(") ");
        }
        if (hashtable.ContainsKey((object) "mcc_CalcCycle") && Convert.ToInt32(hashtable[(object) "mcc_CalcCycle"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mcc_CalcCycle", hashtable[(object) "mcc_CalcCycle"]));
        if (hashtable.ContainsKey((object) "mcc_CalcPeriod") && Convert.ToInt32(hashtable[(object) "mcc_CalcPeriod"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mcc_CalcPeriod", hashtable[(object) "mcc_CalcPeriod"]));
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
        string uniMembers = UbModelBase.UNI_MEMBERS;
        string str = this.TableCode.ToString();
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniMembers = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
        }
        stringBuilder.Append(" SELECT  mcc_SiteID,mcc_CalcCycleDiv,mcc_StartDate,mcc_EndDate,mcc_CalcCycle,mcc_CalcPeriod,mcc_InDate,mcc_InUser,mcc_ModDate,mcc_ModUser");
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
