// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.Environment.MemberCycleStd.TMemberCycleStd
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

namespace UniBiz.Bo.Models.UniMembers.Environment.MemberCycleStd
{
  public class TMemberCycleStd : UbModelBase<TMemberCycleStd>
  {
    private int _mcs_StoreCode;
    private DateTime? _mcs_StartDate;
    private long _mcs_SiteID;
    private DateTime? _mcc_EndDate;
    private int _mcs_NewStdQty;
    private int _mcs_Cycle1MinBuyCnt;
    private int _mcs_Cycle1MaxBuyCnt;
    private int _mcs_Cycle2MinBuyCnt;
    private int _mcs_Cycle2MaxBuyCnt;
    private int _mcs_DormancyPeriod;
    private DateTime? _mcs_InDate;
    private int _mcs_InUser;
    private DateTime? _mcs_ModDate;
    private int _mcs_ModUser;

    public override object _Key => (object) new object[2]
    {
      (object) this.mcs_StoreCode,
      (object) this.mcs_StartDate
    };

    public int mcs_StoreCode
    {
      get => this._mcs_StoreCode;
      set
      {
        this._mcs_StoreCode = value;
        this.Changed(nameof (mcs_StoreCode));
      }
    }

    public DateTime? mcs_StartDate
    {
      get => this._mcs_StartDate;
      set
      {
        this._mcs_StartDate = value;
        this.Changed(nameof (mcs_StartDate));
      }
    }

    [JsonIgnore]
    public int IntStartDate => this.mcs_StartDate.HasValue ? this.mcs_StartDate.Value.ToIntFormat() : 0;

    public long mcs_SiteID
    {
      get => this._mcs_SiteID;
      set
      {
        this._mcs_SiteID = value;
        this.Changed(nameof (mcs_SiteID));
      }
    }

    public DateTime? mcs_EndDate
    {
      get => this._mcc_EndDate;
      set
      {
        this._mcc_EndDate = value;
        this.Changed(nameof (mcs_EndDate));
      }
    }

    [JsonIgnore]
    public int IntEndDate => this.mcs_StartDate.HasValue ? this.mcs_EndDate.Value.ToIntFormat() : 0;

    public int mcs_NewStdQty
    {
      get => this._mcs_NewStdQty;
      set
      {
        this._mcs_NewStdQty = value;
        this.Changed(nameof (mcs_NewStdQty));
      }
    }

    public int mcs_Cycle1MinBuyCnt
    {
      get => this._mcs_Cycle1MinBuyCnt;
      set
      {
        this._mcs_Cycle1MinBuyCnt = value;
        this.Changed(nameof (mcs_Cycle1MinBuyCnt));
      }
    }

    public int mcs_Cycle1MaxBuyCnt
    {
      get => this._mcs_Cycle1MaxBuyCnt;
      set
      {
        this._mcs_Cycle1MaxBuyCnt = value;
        this.Changed(nameof (mcs_Cycle1MaxBuyCnt));
      }
    }

    public int mcs_Cycle2MinBuyCnt
    {
      get => this._mcs_Cycle2MinBuyCnt;
      set
      {
        this._mcs_Cycle2MinBuyCnt = value;
        this.Changed(nameof (mcs_Cycle2MinBuyCnt));
      }
    }

    public int mcs_Cycle2MaxBuyCnt
    {
      get => this._mcs_Cycle2MaxBuyCnt;
      set
      {
        this._mcs_Cycle2MaxBuyCnt = value;
        this.Changed(nameof (mcs_Cycle2MaxBuyCnt));
      }
    }

    public int mcs_DormancyPeriod
    {
      get => this._mcs_DormancyPeriod;
      set
      {
        this._mcs_DormancyPeriod = value;
        this.Changed(nameof (mcs_DormancyPeriod));
      }
    }

    public DateTime? mcs_InDate
    {
      get => this._mcs_InDate;
      set
      {
        this._mcs_InDate = value;
        this.Changed(nameof (mcs_InDate));
      }
    }

    public int mcs_InUser
    {
      get => this._mcs_InUser;
      set
      {
        this._mcs_InUser = value;
        this.Changed(nameof (mcs_InUser));
      }
    }

    public DateTime? mcs_ModDate
    {
      get => this._mcs_ModDate;
      set
      {
        this._mcs_ModDate = value;
        this.Changed(nameof (mcs_ModDate));
      }
    }

    public int mcs_ModUser
    {
      get => this._mcs_ModUser;
      set
      {
        this._mcs_ModUser = value;
        this.Changed(nameof (mcs_ModUser));
      }
    }

    public TMemberCycleStd() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("mcs_StoreCode", new TTableColumn()
      {
        tc_orgin_name = "mcs_StoreCode",
        tc_trans_name = "지점코드"
      });
      columnInfo.Add("mcs_StartDate", new TTableColumn()
      {
        tc_orgin_name = "mcs_StartDate",
        tc_trans_name = "시작일"
      });
      columnInfo.Add("mcs_SiteID", new TTableColumn()
      {
        tc_orgin_name = "mcs_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("mcs_EndDate", new TTableColumn()
      {
        tc_orgin_name = "mcs_EndDate",
        tc_trans_name = "종료일"
      });
      columnInfo.Add("mcs_NewStdQty", new TTableColumn()
      {
        tc_orgin_name = "mcs_NewStdQty",
        tc_trans_name = "신규기준횟수"
      });
      columnInfo.Add("mcs_Cycle1MinBuyCnt", new TTableColumn()
      {
        tc_orgin_name = "mcs_Cycle1MinBuyCnt",
        tc_trans_name = "주기1최소횟수"
      });
      columnInfo.Add("mcs_Cycle1MaxBuyCnt", new TTableColumn()
      {
        tc_orgin_name = "mcs_Cycle1MaxBuyCnt",
        tc_trans_name = "주기1최대구매횟수"
      });
      columnInfo.Add("mcs_Cycle2MinBuyCnt", new TTableColumn()
      {
        tc_orgin_name = "mcs_Cycle2MinBuyCnt",
        tc_trans_name = "주기2최소횟수"
      });
      columnInfo.Add("mcs_Cycle2MaxBuyCnt", new TTableColumn()
      {
        tc_orgin_name = "mcs_Cycle2MaxBuyCnt",
        tc_trans_name = "주기2최대구매횟수"
      });
      columnInfo.Add("mcs_DormancyPeriod", new TTableColumn()
      {
        tc_orgin_name = "mcs_DormancyPeriod",
        tc_trans_name = "휴면산정기간"
      });
      columnInfo.Add("mcs_InDate", new TTableColumn()
      {
        tc_orgin_name = "mcs_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("mcs_InUser", new TTableColumn()
      {
        tc_orgin_name = "mcs_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("mcs_ModDate", new TTableColumn()
      {
        tc_orgin_name = "mcs_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("mcs_ModUser", new TTableColumn()
      {
        tc_orgin_name = "mcs_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.MemberCycleStd;
      this.mcs_StoreCode = 0;
      this.mcs_StartDate = new DateTime?();
      this.mcs_SiteID = 0L;
      this.mcs_EndDate = new DateTime?();
      this.mcs_NewStdQty = 1;
      this.mcs_Cycle1MinBuyCnt = this.mcs_Cycle1MaxBuyCnt = this.mcs_Cycle2MinBuyCnt = this.mcs_Cycle2MaxBuyCnt = this.mcs_DormancyPeriod = 0;
      this.mcs_InDate = new DateTime?();
      this.mcs_InUser = 0;
      this.mcs_ModDate = new DateTime?();
      this.mcs_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TMemberCycleStd();

    public override object Clone()
    {
      TMemberCycleStd tmemberCycleStd = base.Clone() as TMemberCycleStd;
      tmemberCycleStd.mcs_StoreCode = this.mcs_StoreCode;
      tmemberCycleStd.mcs_StartDate = this.mcs_StartDate;
      tmemberCycleStd.mcs_SiteID = this.mcs_SiteID;
      tmemberCycleStd.mcs_EndDate = this.mcs_EndDate;
      tmemberCycleStd.mcs_NewStdQty = this.mcs_NewStdQty;
      tmemberCycleStd.mcs_Cycle1MinBuyCnt = this.mcs_Cycle1MinBuyCnt;
      tmemberCycleStd.mcs_Cycle1MaxBuyCnt = this.mcs_Cycle1MaxBuyCnt;
      tmemberCycleStd.mcs_Cycle2MinBuyCnt = this.mcs_Cycle2MinBuyCnt;
      tmemberCycleStd.mcs_Cycle2MaxBuyCnt = this.mcs_Cycle2MaxBuyCnt;
      tmemberCycleStd.mcs_DormancyPeriod = this.mcs_DormancyPeriod;
      tmemberCycleStd.mcs_InDate = this.mcs_InDate;
      tmemberCycleStd.mcs_InUser = this.mcs_InUser;
      tmemberCycleStd.mcs_ModDate = this.mcs_ModDate;
      tmemberCycleStd.mcs_ModUser = this.mcs_ModUser;
      return (object) tmemberCycleStd;
    }

    public void PutData(TMemberCycleStd pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.mcs_StoreCode = pSource.mcs_StoreCode;
      this.mcs_StartDate = pSource.mcs_StartDate;
      this.mcs_SiteID = pSource.mcs_SiteID;
      this.mcs_EndDate = pSource.mcs_EndDate;
      this.mcs_NewStdQty = pSource.mcs_NewStdQty;
      this.mcs_Cycle1MinBuyCnt = pSource.mcs_Cycle1MinBuyCnt;
      this.mcs_Cycle1MaxBuyCnt = pSource.mcs_Cycle1MaxBuyCnt;
      this.mcs_Cycle2MinBuyCnt = pSource.mcs_Cycle2MinBuyCnt;
      this.mcs_Cycle2MaxBuyCnt = pSource.mcs_Cycle2MaxBuyCnt;
      this.mcs_DormancyPeriod = pSource.mcs_DormancyPeriod;
      this.mcs_InDate = pSource.mcs_InDate;
      this.mcs_InUser = pSource.mcs_InUser;
      this.mcs_ModDate = pSource.mcs_ModDate;
      this.mcs_ModUser = pSource.mcs_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.mcs_StoreCode = p_rs.GetFieldInt("mcs_StoreCode");
        if (this.mcs_StoreCode == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.mcs_StartDate = p_rs.GetFieldDateTime("mcs_StartDate");
        this.mcs_SiteID = p_rs.GetFieldLong("mcs_SiteID");
        this.mcs_EndDate = p_rs.GetFieldDateTime("mcs_EndDate");
        this.mcs_NewStdQty = p_rs.GetFieldInt("mcs_NewStdQty");
        this.mcs_Cycle1MinBuyCnt = p_rs.GetFieldInt("mcs_Cycle1MinBuyCnt");
        this.mcs_Cycle1MaxBuyCnt = p_rs.GetFieldInt("mcs_Cycle1MaxBuyCnt");
        this.mcs_Cycle2MinBuyCnt = p_rs.GetFieldInt("mcs_Cycle2MinBuyCnt");
        this.mcs_Cycle2MaxBuyCnt = p_rs.GetFieldInt("mcs_Cycle2MaxBuyCnt");
        this.mcs_DormancyPeriod = p_rs.GetFieldInt("mcs_DormancyPeriod");
        this.mcs_InDate = p_rs.GetFieldDateTime("mcs_InDate");
        this.mcs_InUser = p_rs.GetFieldInt("mcs_InUser");
        this.mcs_ModDate = p_rs.GetFieldDateTime("mcs_ModDate");
        this.mcs_ModUser = p_rs.GetFieldInt("mcs_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode) + " mcs_StoreCode,mcs_StartDate,mcs_SiteID,mcs_EndDate,mcs_NewStdQty,mcs_Cycle1MinBuyCnt,mcs_Cycle1MaxBuyCnt,mcs_Cycle2MinBuyCnt,mcs_Cycle2MaxBuyCnt,mcs_DormancyPeriod,mcs_InDate,mcs_InUser,mcs_ModDate,mcs_ModUser) VALUES ( " + string.Format(" {0},{1}", (object) this.mcs_StoreCode, (object) this.mcs_StartDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'")) + string.Format(",{0}", (object) this.mcs_SiteID) + "," + this.mcs_EndDate.GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'") + string.Format(",{0},{1},{2}", (object) this.mcs_NewStdQty, (object) this.mcs_Cycle1MinBuyCnt, (object) this.mcs_Cycle1MaxBuyCnt) + string.Format(",{0},{1},{2}", (object) this.mcs_Cycle2MinBuyCnt, (object) this.mcs_Cycle2MaxBuyCnt, (object) this.mcs_DormancyPeriod) + string.Format(",{0},{1}", (object) this.mcs_InDate.GetDateToStrInNull(), (object) this.mcs_InUser) + string.Format(",{0},{1}", (object) this.mcs_ModDate.GetDateToStrInNull(), (object) this.mcs_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.mcs_StoreCode, (object) this.mcs_StartDate, (object) this.mcs_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TMemberCycleStd tmemberCycleStd = this;
      // ISSUE: reference to a compiler-generated method
      tmemberCycleStd.\u003C\u003En__0();
      if (await tmemberCycleStd.OleDB.ExecuteAsync(tmemberCycleStd.InsertQuery()))
        return true;
      tmemberCycleStd.message = " " + tmemberCycleStd.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberCycleStd.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberCycleStd.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tmemberCycleStd.mcs_StoreCode, (object) tmemberCycleStd.mcs_StartDate, (object) tmemberCycleStd.mcs_SiteID) + " 내용 : " + tmemberCycleStd.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberCycleStd.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode) + " mcs_EndDate=" + this.mcs_EndDate.GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'") + string.Format(",{0}={1}", (object) "mcs_NewStdQty", (object) this.mcs_NewStdQty) + string.Format(",{0}={1}", (object) "mcs_Cycle1MinBuyCnt", (object) this.mcs_Cycle1MinBuyCnt) + string.Format(",{0}={1}", (object) "mcs_Cycle1MaxBuyCnt", (object) this.mcs_Cycle1MaxBuyCnt) + string.Format(",{0}={1}", (object) "mcs_Cycle2MinBuyCnt", (object) this.mcs_Cycle2MinBuyCnt) + string.Format(",{0}={1}", (object) "mcs_Cycle2MaxBuyCnt", (object) this.mcs_Cycle2MaxBuyCnt) + string.Format(",{0}={1}", (object) "mcs_DormancyPeriod", (object) this.mcs_DormancyPeriod) + string.Format(",{0}={1},{2}={3}", (object) "mcs_ModDate", (object) this.mcs_ModDate.GetDateToStrInNull(), (object) "mcs_ModUser", (object) this.mcs_ModUser) + string.Format(" WHERE {0}={1}", (object) "mcs_StoreCode", (object) this.mcs_StoreCode) + " AND mcs_StartDate=" + this.mcs_StartDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + string.Format(" AND {0}={1}", (object) "mcs_SiteID", (object) this.mcs_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.mcs_StoreCode, (object) this.mcs_StartDate, (object) this.mcs_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TMemberCycleStd tmemberCycleStd = this;
      // ISSUE: reference to a compiler-generated method
      tmemberCycleStd.\u003C\u003En__1();
      if (await tmemberCycleStd.OleDB.ExecuteAsync(tmemberCycleStd.UpdateQuery()))
        return true;
      tmemberCycleStd.message = " " + tmemberCycleStd.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberCycleStd.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberCycleStd.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tmemberCycleStd.mcs_StoreCode, (object) tmemberCycleStd.mcs_StartDate, (object) tmemberCycleStd.mcs_SiteID) + " 내용 : " + tmemberCycleStd.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberCycleStd.message);
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
      stringBuilder.Append(" mcs_EndDate=" + this.mcs_EndDate.GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'") + string.Format(",{0}={1}", (object) "mcs_NewStdQty", (object) this.mcs_NewStdQty) + string.Format(",{0}={1}", (object) "mcs_Cycle1MinBuyCnt", (object) this.mcs_Cycle1MinBuyCnt) + string.Format(",{0}={1}", (object) "mcs_Cycle1MaxBuyCnt", (object) this.mcs_Cycle1MaxBuyCnt) + string.Format(",{0}={1}", (object) "mcs_Cycle2MinBuyCnt", (object) this.mcs_Cycle2MinBuyCnt) + string.Format(",{0}={1}", (object) "mcs_Cycle2MaxBuyCnt", (object) this.mcs_Cycle2MaxBuyCnt) + string.Format(",{0}={1}", (object) "mcs_DormancyPeriod", (object) this.mcs_DormancyPeriod) + string.Format(",{0}={1},{2}={3}", (object) "mcs_ModDate", (object) this.mcs_ModDate.GetDateToStrInNull(), (object) "mcs_ModUser", (object) this.mcs_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.mcs_StoreCode, (object) this.mcs_StartDate, (object) this.mcs_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TMemberCycleStd tmemberCycleStd = this;
      // ISSUE: reference to a compiler-generated method
      tmemberCycleStd.\u003C\u003En__1();
      if (await tmemberCycleStd.OleDB.ExecuteAsync(tmemberCycleStd.UpdateExInsertQuery()))
        return true;
      tmemberCycleStd.message = " " + tmemberCycleStd.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberCycleStd.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberCycleStd.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tmemberCycleStd.mcs_StoreCode, (object) tmemberCycleStd.mcs_StartDate, (object) tmemberCycleStd.mcs_SiteID) + " 내용 : " + tmemberCycleStd.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberCycleStd.message);
      return false;
    }

    public string UpdateStartDateQuery(
      int p_mcs_StoreCode,
      DateTime p_mcs_StartDate,
      DateTime pModStartDate,
      long p_mcs_SiteID = 0)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode));
      stringBuilder.Append(" mcs_StartDate=" + new DateTime?(pModStartDate).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'"));
      stringBuilder.Append(",mcs_ModDate=" + this.mcs_ModDate.GetDateToStrInNull());
      stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "mcs_StoreCode", (object) p_mcs_StoreCode));
      stringBuilder.Append(" AND mcs_StartDate=" + new DateTime?(p_mcs_StartDate).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'"));
      if (p_mcs_SiteID > 0L)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mcs_SiteID", (object) p_mcs_SiteID));
      return stringBuilder.ToString();
    }

    public bool UpdateStartDate(
      int p_mcs_StoreCode,
      DateTime p_mcs_StartDate,
      DateTime pModStartDate,
      long p_mcs_SiteID = 0)
    {
      this.UpdateChecked();
      this.mcs_ModDate = new DateTime?(DateTime.Now);
      if (this.OleDB.Execute(this.UpdateStartDateQuery(p_mcs_StoreCode, p_mcs_StartDate, pModStartDate, p_mcs_SiteID)))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1}) => {2},{3})\n", (object) p_mcs_StoreCode, (object) new DateTime?(p_mcs_StartDate).GetDateToStr("yyyy-MM-dd"), (object) new DateTime?(pModStartDate).GetDateToStr("yyyy-MM-dd"), (object) p_mcs_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public async Task<bool> UpdateStartDateAsync(
      int p_mcs_StoreCode,
      DateTime p_mcs_StartDate,
      DateTime pModStartDate,
      long p_mcs_SiteID = 0)
    {
      TMemberCycleStd tmemberCycleStd = this;
      // ISSUE: reference to a compiler-generated method
      tmemberCycleStd.\u003C\u003En__1();
      tmemberCycleStd.mcs_ModDate = new DateTime?(DateTime.Now);
      if (await tmemberCycleStd.OleDB.ExecuteAsync(tmemberCycleStd.UpdateStartDateQuery(p_mcs_StoreCode, p_mcs_StartDate, pModStartDate, p_mcs_SiteID)))
        return true;
      tmemberCycleStd.message = " " + tmemberCycleStd.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberCycleStd.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberCycleStd.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1}) => {2},{3})\n", (object) p_mcs_StoreCode, (object) new DateTime?(p_mcs_StartDate).GetDateToStr("yyyy-MM-dd"), (object) new DateTime?(pModStartDate).GetDateToStr("yyyy-MM-dd"), (object) p_mcs_SiteID) + " 내용 : " + tmemberCycleStd.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberCycleStd.message);
      return false;
    }

    public string UpdateEndDateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode) + " mcs_EndDate=" + this.mcs_EndDate.GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'") + string.Format(",{0}={1},{2}={3}", (object) "mcs_ModDate", (object) this.mcs_ModDate.GetDateToStrInNull(), (object) "mcs_ModUser", (object) this.mcs_ModUser) + string.Format(" WHERE {0}={1}", (object) "mcs_StoreCode", (object) this.mcs_StoreCode) + " AND mcs_StartDate=" + this.mcs_StartDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + string.Format(" AND {0}={1}", (object) "mcs_SiteID", (object) this.mcs_SiteID);

    public bool UpdateEndDate()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateEndDateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.mcs_StoreCode, (object) this.mcs_StartDate, (object) this.mcs_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public async Task<bool> UpdateEndDateAsync()
    {
      TMemberCycleStd tmemberCycleStd = this;
      // ISSUE: reference to a compiler-generated method
      tmemberCycleStd.\u003C\u003En__1();
      if (await tmemberCycleStd.OleDB.ExecuteAsync(tmemberCycleStd.UpdateEndDateQuery()))
        return true;
      tmemberCycleStd.message = " " + tmemberCycleStd.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberCycleStd.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberCycleStd.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tmemberCycleStd.mcs_StoreCode, (object) tmemberCycleStd.mcs_StartDate, (object) tmemberCycleStd.mcs_SiteID) + " 내용 : " + tmemberCycleStd.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberCycleStd.message);
      return false;
    }

    public override string DeleteQuery() => string.Format(" DELETE FROM {0}{1}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode) + string.Format(" WHERE {0}={1}", (object) "mcs_StoreCode", (object) this.mcs_StoreCode) + " AND mcs_StartDate=" + this.mcs_StartDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + string.Format(" AND {0}={1}", (object) "mcs_SiteID", (object) this.mcs_SiteID);

    public override bool Delete()
    {
      this.InsertChecked();
      string pStrExec = this.DeleteQuery();
      if (this.OleDB.Execute(pStrExec))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 삭제 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.mcs_StoreCode, (object) this.mcs_StartDate, (object) this.mcs_SiteID) + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n 쿼리 : " + pStrExec + "\n--------------------------------------------------------------------------------------------------\n";
      return false;
    }

    public override async Task<bool> DeleteAsync()
    {
      TMemberCycleStd tmemberCycleStd = this;
      // ISSUE: reference to a compiler-generated method
      tmemberCycleStd.\u003C\u003En__0();
      if (await tmemberCycleStd.OleDB.ExecuteAsync(tmemberCycleStd.DeleteQuery()))
        return true;
      tmemberCycleStd.message = " " + tmemberCycleStd.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberCycleStd.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberCycleStd.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tmemberCycleStd.mcs_StoreCode, (object) tmemberCycleStd.mcs_StartDate, (object) tmemberCycleStd.mcs_SiteID) + " 내용 : " + tmemberCycleStd.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberCycleStd.message);
      return false;
    }

    public virtual string DeleteQuery(
      int p_mcs_StoreCode,
      DateTime p_mcs_StartDate,
      long p_mcs_SiteID = 0)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format(" DELETE FROM {0}{1} ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode));
      stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "mcs_StoreCode", (object) p_mcs_StoreCode));
      stringBuilder.Append(" AND mcs_StartDate=" + new DateTime?(p_mcs_StartDate).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'"));
      if (p_mcs_SiteID > 0L)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mcs_SiteID", (object) p_mcs_SiteID));
      return stringBuilder.ToString();
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "mcs_SiteID") && Convert.ToInt64(hashtable[(object) "mcs_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "mcs_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "mcs_StoreCode") && Convert.ToInt32(hashtable[(object) "mcs_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mcs_StoreCode", hashtable[(object) "mcs_StoreCode"]));
        else if (hashtable.ContainsKey((object) "si_StoreCode") && Convert.ToInt32(hashtable[(object) "si_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mcs_StoreCode", hashtable[(object) "si_StoreCode"]));
        else if (hashtable.ContainsKey((object) "si_StoreCode_IN_") && hashtable[(object) "si_StoreCode_IN_"].ToString().Length > 0)
        {
          if (hashtable[(object) "si_StoreCode_IN_"].ToString().Contains(","))
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "mcs_StoreCode", hashtable[(object) "si_StoreCode_IN_"]));
          else
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mcs_StoreCode", hashtable[(object) "si_StoreCode_IN_"]));
        }
        else if (hashtable.ContainsKey((object) "mcs_StoreCode_IN_") && hashtable[(object) "mcs_StoreCode_IN_"].ToString().Length > 0)
        {
          if (hashtable[(object) "mcs_StoreCode_IN_"].ToString().Contains(","))
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "mcs_StoreCode", hashtable[(object) "mcs_StoreCode_IN_"]));
          else
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mcs_StoreCode", hashtable[(object) "mcs_StoreCode_IN_"]));
        }
        else if (hashtable.ContainsKey((object) "_STORE_AUTHS_") && !string.IsNullOrEmpty(hashtable[(object) "_STORE_AUTHS_"].ToString()))
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "mcs_StoreCode", hashtable[(object) "_STORE_AUTHS_"]));
        if (hashtable.ContainsKey((object) "mcs_StartDate") && !string.IsNullOrEmpty(hashtable[(object) "mcs_StartDate"].ToString()))
          stringBuilder.Append(" AND mcs_StartDate<=" + new DateTime?((DateTime) hashtable[(object) "mcs_StartDate"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + " AND mcs_StartDate>=" + new DateTime?((DateTime) hashtable[(object) "mcs_StartDate"]).GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'"));
        if (hashtable.ContainsKey((object) "_DT_DATE_") && !string.IsNullOrEmpty(hashtable[(object) "_DT_DATE_"].ToString()))
        {
          stringBuilder.Append(" AND mcs_StartDate <='" + new DateTime?((DateTime) hashtable[(object) "_DT_DATE_"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND mcs_EndDate >='" + new DateTime?((DateTime) hashtable[(object) "_DT_DATE_"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
        }
        if (hashtable.ContainsKey((object) "_DT_START_DATE_") && !string.IsNullOrEmpty(hashtable[(object) "_DT_START_DATE_"].ToString()) && hashtable.ContainsKey((object) "_DT_END_DATE_") && !string.IsNullOrEmpty(hashtable[(object) "_DT_END_DATE_"].ToString()))
        {
          string dateToStr1 = new DateTime?((DateTime) hashtable[(object) "_DT_START_DATE_"]).GetDateToStr("yyyy-MM-dd 00:00:00");
          string dateToStr2 = new DateTime?((DateTime) hashtable[(object) "_DT_START_DATE_"]).GetDateToStr("yyyy-MM-dd 23:59:59");
          string dateToStr3 = new DateTime?((DateTime) hashtable[(object) "_DT_END_DATE_"]).GetDateToStr("yyyy-MM-dd 00:00:00");
          string dateToStr4 = new DateTime?((DateTime) hashtable[(object) "_DT_END_DATE_"]).GetDateToStr("yyyy-MM-dd 23:59:59");
          stringBuilder.Append(" AND (");
          stringBuilder.Append(" (mcs_StartDate <= '" + dateToStr1 + "' AND mcs_EndDate >= '" + dateToStr2 + "' )");
          stringBuilder.Append(" OR (mcs_StartDate <= '" + dateToStr3 + "' AND mcs_EndDate >= '" + dateToStr4 + "' )");
          stringBuilder.Append(" OR (mcs_StartDate >= '" + dateToStr1 + "' AND mcs_EndDate <= '" + dateToStr4 + "' )");
          stringBuilder.Append(") ");
        }
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mcs_SiteID", (object) num));
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
        stringBuilder.Append(" SELECT  mcs_StoreCode,mcs_StartDate,mcs_SiteID,mcs_EndDate,mcs_NewStdQty,mcs_Cycle1MinBuyCnt,mcs_Cycle1MaxBuyCnt,mcs_Cycle2MinBuyCnt,mcs_Cycle2MaxBuyCnt,mcs_DormancyPeriod,mcs_InDate,mcs_InUser,mcs_ModDate,mcs_ModUser");
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
