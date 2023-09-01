// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.Environment.MemberGradeCalcStd.TMemberGradeCalcStd
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

namespace UniBiz.Bo.Models.UniMembers.Environment.MemberGradeCalcStd
{
  public class TMemberGradeCalcStd : UbModelBase<TMemberGradeCalcStd>
  {
    private int _mgcs_StoreCode;
    private int _mgcs_MemberGrade;
    private DateTime? _mgcs_StartDate;
    private long _mgcs_SiteID;
    private DateTime? _mgcs_EndDate;
    private int _mgcs_MinBuyCnt;
    private int _mgcs_MaxBuyCnt;
    private string _mgcs_Operator;
    private double _mgcs_MinBuyAmt;
    private double _mgcs_MaxBuyAmt;
    private double _mgcs_AddPointRate;
    private DateTime? _mgcs_InDate;
    private int _mgcs_InUser;
    private DateTime? _mgcs_ModDate;
    private int _mgcs_ModUser;

    public override object _Key => (object) new object[3]
    {
      (object) this.mgcs_StoreCode,
      (object) this.mgcs_MemberGrade,
      (object) this.mgcs_StartDate
    };

    public int mgcs_StoreCode
    {
      get => this._mgcs_StoreCode;
      set
      {
        this._mgcs_StoreCode = value;
        this.Changed(nameof (mgcs_StoreCode));
      }
    }

    public int mgcs_MemberGrade
    {
      get => this._mgcs_MemberGrade;
      set
      {
        this._mgcs_MemberGrade = value;
        this.Changed(nameof (mgcs_MemberGrade));
      }
    }

    public DateTime? mgcs_StartDate
    {
      get => this._mgcs_StartDate;
      set
      {
        this._mgcs_StartDate = value;
        this.Changed(nameof (mgcs_StartDate));
      }
    }

    [JsonIgnore]
    public int IntStartDate => this.mgcs_StartDate.HasValue ? this.mgcs_StartDate.Value.ToIntFormat() : 0;

    public long mgcs_SiteID
    {
      get => this._mgcs_SiteID;
      set
      {
        this._mgcs_SiteID = value;
        this.Changed(nameof (mgcs_SiteID));
      }
    }

    public DateTime? mgcs_EndDate
    {
      get => this._mgcs_EndDate;
      set
      {
        this._mgcs_EndDate = value;
        this.Changed(nameof (mgcs_EndDate));
      }
    }

    [JsonIgnore]
    public int IntEndDate => this.mgcs_EndDate.HasValue ? this.mgcs_EndDate.Value.ToIntFormat() : 0;

    public int mgcs_MinBuyCnt
    {
      get => this._mgcs_MinBuyCnt;
      set
      {
        this._mgcs_MinBuyCnt = value;
        this.Changed(nameof (mgcs_MinBuyCnt));
      }
    }

    public int mgcs_MaxBuyCnt
    {
      get => this._mgcs_MaxBuyCnt;
      set
      {
        this._mgcs_MaxBuyCnt = value;
        this.Changed(nameof (mgcs_MaxBuyCnt));
      }
    }

    public string mgcs_Operator
    {
      get => this._mgcs_Operator;
      set
      {
        this._mgcs_Operator = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (mgcs_Operator));
        this.Changed("mgcs_AndOperator");
      }
    }

    public bool mgcs_AndOperator => "A".Equals(this.mgcs_Operator);

    public double mgcs_MinBuyAmt
    {
      get => this._mgcs_MinBuyAmt;
      set
      {
        this._mgcs_MinBuyAmt = value;
        this.Changed(nameof (mgcs_MinBuyAmt));
      }
    }

    public double mgcs_MaxBuyAmt
    {
      get => this._mgcs_MaxBuyAmt;
      set
      {
        this._mgcs_MaxBuyAmt = value;
        this.Changed(nameof (mgcs_MaxBuyAmt));
      }
    }

    public double mgcs_AddPointRate
    {
      get => this._mgcs_AddPointRate;
      set
      {
        this._mgcs_AddPointRate = value;
        this.Changed(nameof (mgcs_AddPointRate));
      }
    }

    public DateTime? mgcs_InDate
    {
      get => this._mgcs_InDate;
      set
      {
        this._mgcs_InDate = value;
        this.Changed(nameof (mgcs_InDate));
      }
    }

    public int mgcs_InUser
    {
      get => this._mgcs_InUser;
      set
      {
        this._mgcs_InUser = value;
        this.Changed(nameof (mgcs_InUser));
      }
    }

    public DateTime? mgcs_ModDate
    {
      get => this._mgcs_ModDate;
      set
      {
        this._mgcs_ModDate = value;
        this.Changed(nameof (mgcs_ModDate));
      }
    }

    public int mgcs_ModUser
    {
      get => this._mgcs_ModUser;
      set
      {
        this._mgcs_ModUser = value;
        this.Changed(nameof (mgcs_ModUser));
      }
    }

    public TMemberGradeCalcStd() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("mgcs_StoreCode", new TTableColumn()
      {
        tc_orgin_name = "mgcs_StoreCode",
        tc_trans_name = "지점코드"
      });
      columnInfo.Add("mgcs_MemberGrade", new TTableColumn()
      {
        tc_orgin_name = "mgcs_MemberGrade",
        tc_trans_name = "회원등급"
      });
      columnInfo.Add("mgcs_StartDate", new TTableColumn()
      {
        tc_orgin_name = "mgcs_StartDate",
        tc_trans_name = "시작일"
      });
      columnInfo.Add("mgcs_SiteID", new TTableColumn()
      {
        tc_orgin_name = "mgcs_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("mgcs_EndDate", new TTableColumn()
      {
        tc_orgin_name = "mgcs_EndDate",
        tc_trans_name = "종료일"
      });
      columnInfo.Add("mgcs_MinBuyCnt", new TTableColumn()
      {
        tc_orgin_name = "mgcs_MinBuyCnt",
        tc_trans_name = "최소구매횟수"
      });
      columnInfo.Add("mgcs_MaxBuyCnt", new TTableColumn()
      {
        tc_orgin_name = "mgcs_MaxBuyCnt",
        tc_trans_name = "최대구매횟수"
      });
      columnInfo.Add("mgcs_Operator", new TTableColumn()
      {
        tc_orgin_name = "mgcs_Operator",
        tc_trans_name = "연산자"
      });
      columnInfo.Add("mgcs_MinBuyAmt", new TTableColumn()
      {
        tc_orgin_name = "mgcs_MinBuyAmt",
        tc_trans_name = "최소구매금액"
      });
      columnInfo.Add("mgcs_MaxBuyAmt", new TTableColumn()
      {
        tc_orgin_name = "mgcs_MaxBuyAmt",
        tc_trans_name = "최대구매금액"
      });
      columnInfo.Add("mgcs_AddPointRate", new TTableColumn()
      {
        tc_orgin_name = "mgcs_AddPointRate",
        tc_trans_name = "추가적립률"
      });
      columnInfo.Add("mgcs_InDate", new TTableColumn()
      {
        tc_orgin_name = "mgcs_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("mgcs_InUser", new TTableColumn()
      {
        tc_orgin_name = "mgcs_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("mgcs_ModDate", new TTableColumn()
      {
        tc_orgin_name = "mgcs_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("mgcs_ModUser", new TTableColumn()
      {
        tc_orgin_name = "mgcs_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.MemberGradeCalcStd;
      this.mgcs_StoreCode = 0;
      this.mgcs_MemberGrade = 0;
      this.mgcs_StartDate = new DateTime?();
      this.mgcs_SiteID = 0L;
      this.mgcs_EndDate = new DateTime?();
      this.mgcs_MinBuyCnt = this.mgcs_MaxBuyCnt = 0;
      this.mgcs_Operator = string.Empty;
      this.mgcs_MinBuyAmt = this.mgcs_MaxBuyAmt = this.mgcs_AddPointRate = 0.0;
      this.mgcs_InDate = new DateTime?();
      this.mgcs_InUser = 0;
      this.mgcs_ModDate = new DateTime?();
      this.mgcs_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TMemberGradeCalcStd();

    public override object Clone()
    {
      TMemberGradeCalcStd tmemberGradeCalcStd = base.Clone() as TMemberGradeCalcStd;
      tmemberGradeCalcStd.mgcs_StoreCode = this.mgcs_StoreCode;
      tmemberGradeCalcStd.mgcs_MemberGrade = this.mgcs_MemberGrade;
      tmemberGradeCalcStd.mgcs_StartDate = this.mgcs_StartDate;
      tmemberGradeCalcStd.mgcs_SiteID = this.mgcs_SiteID;
      tmemberGradeCalcStd.mgcs_EndDate = this.mgcs_EndDate;
      tmemberGradeCalcStd.mgcs_MinBuyCnt = this.mgcs_MinBuyCnt;
      tmemberGradeCalcStd.mgcs_MaxBuyCnt = this.mgcs_MaxBuyCnt;
      tmemberGradeCalcStd.mgcs_Operator = this.mgcs_Operator;
      tmemberGradeCalcStd.mgcs_MinBuyAmt = this.mgcs_MinBuyAmt;
      tmemberGradeCalcStd.mgcs_MaxBuyAmt = this.mgcs_MaxBuyAmt;
      tmemberGradeCalcStd.mgcs_AddPointRate = this.mgcs_AddPointRate;
      tmemberGradeCalcStd.mgcs_InDate = this.mgcs_InDate;
      tmemberGradeCalcStd.mgcs_InUser = this.mgcs_InUser;
      tmemberGradeCalcStd.mgcs_ModDate = this.mgcs_ModDate;
      tmemberGradeCalcStd.mgcs_ModUser = this.mgcs_ModUser;
      return (object) tmemberGradeCalcStd;
    }

    public void PutData(TMemberGradeCalcStd pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.mgcs_StoreCode = pSource.mgcs_StoreCode;
      this.mgcs_MemberGrade = pSource.mgcs_MemberGrade;
      this.mgcs_StartDate = pSource.mgcs_StartDate;
      this.mgcs_SiteID = pSource.mgcs_SiteID;
      this.mgcs_EndDate = pSource.mgcs_EndDate;
      this.mgcs_MinBuyCnt = pSource.mgcs_MinBuyCnt;
      this.mgcs_MaxBuyCnt = pSource.mgcs_MaxBuyCnt;
      this.mgcs_Operator = pSource.mgcs_Operator;
      this.mgcs_MinBuyAmt = pSource.mgcs_MinBuyAmt;
      this.mgcs_MaxBuyAmt = pSource.mgcs_MaxBuyAmt;
      this.mgcs_AddPointRate = pSource.mgcs_AddPointRate;
      this.mgcs_InDate = pSource.mgcs_InDate;
      this.mgcs_InUser = pSource.mgcs_InUser;
      this.mgcs_ModDate = pSource.mgcs_ModDate;
      this.mgcs_ModUser = pSource.mgcs_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.mgcs_StoreCode = p_rs.GetFieldInt("mgcs_StoreCode");
        if (this.mgcs_StoreCode == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.mgcs_MemberGrade = p_rs.GetFieldInt("mgcs_MemberGrade");
        this.mgcs_StartDate = p_rs.GetFieldDateTime("mgcs_StartDate");
        this.mgcs_SiteID = p_rs.GetFieldLong("mgcs_SiteID");
        this.mgcs_EndDate = p_rs.GetFieldDateTime("mgcs_EndDate");
        this.mgcs_MinBuyCnt = p_rs.GetFieldInt("mgcs_MinBuyCnt");
        this.mgcs_MaxBuyCnt = p_rs.GetFieldInt("mgcs_MaxBuyCnt");
        this.mgcs_Operator = p_rs.GetFieldString("mgcs_Operator");
        this.mgcs_MinBuyAmt = p_rs.GetFieldDouble("mgcs_MinBuyAmt");
        this.mgcs_MaxBuyAmt = p_rs.GetFieldDouble("mgcs_MaxBuyAmt");
        this.mgcs_AddPointRate = p_rs.GetFieldDouble("mgcs_AddPointRate");
        this.mgcs_InDate = p_rs.GetFieldDateTime("mgcs_InDate");
        this.mgcs_InUser = p_rs.GetFieldInt("mgcs_InUser");
        this.mgcs_ModDate = p_rs.GetFieldDateTime("mgcs_ModDate");
        this.mgcs_ModUser = p_rs.GetFieldInt("mgcs_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode) + " mgcs_StoreCode,mgcs_MemberGrade,mgcs_StartDate,mgcs_SiteID,mgcs_EndDate,mgcs_MinBuyCnt,mgcs_MaxBuyCnt,mgcs_Operator,mgcs_MinBuyAmt,mgcs_MaxBuyAmt,mgcs_AddPointRate,mgcs_InDate,mgcs_InUser,mgcs_ModDate,mgcs_ModUser) VALUES ( " + string.Format(" {0},{1},{2}", (object) this.mgcs_StoreCode, (object) this.mgcs_MemberGrade, (object) this.mgcs_StartDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'")) + string.Format(",{0}", (object) this.mgcs_SiteID) + "," + this.mgcs_EndDate.GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'") + string.Format(",{0},{1},'{2}'", (object) this.mgcs_MinBuyCnt, (object) this.mgcs_MaxBuyCnt, (object) this.mgcs_Operator) + "," + this.mgcs_MinBuyAmt.FormatTo("{0:0.0000}") + "," + this.mgcs_MaxBuyAmt.FormatTo("{0:0.0000}") + "," + this.mgcs_AddPointRate.FormatTo("{0:0.0000}") + string.Format(",{0},{1}", (object) this.mgcs_InDate.GetDateToStrInNull(), (object) this.mgcs_InUser) + string.Format(",{0},{1}", (object) this.mgcs_ModDate.GetDateToStrInNull(), (object) this.mgcs_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.mgcs_StoreCode, (object) this.mgcs_MemberGrade, (object) this.mgcs_StartDate, (object) this.mgcs_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TMemberGradeCalcStd tmemberGradeCalcStd = this;
      // ISSUE: reference to a compiler-generated method
      tmemberGradeCalcStd.\u003C\u003En__0();
      if (await tmemberGradeCalcStd.OleDB.ExecuteAsync(tmemberGradeCalcStd.InsertQuery()))
        return true;
      tmemberGradeCalcStd.message = " " + tmemberGradeCalcStd.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberGradeCalcStd.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberGradeCalcStd.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tmemberGradeCalcStd.mgcs_StoreCode, (object) tmemberGradeCalcStd.mgcs_MemberGrade, (object) tmemberGradeCalcStd.mgcs_StartDate, (object) tmemberGradeCalcStd.mgcs_SiteID) + " 내용 : " + tmemberGradeCalcStd.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberGradeCalcStd.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode) + " mgcs_EndDate=" + this.mgcs_EndDate.GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'") + string.Format(",{0}={1}", (object) "mgcs_MinBuyCnt", (object) this.mgcs_MinBuyCnt) + string.Format(",{0}={1}", (object) "mgcs_MaxBuyCnt", (object) this.mgcs_MaxBuyCnt) + ",mgcs_Operator='" + this.mgcs_Operator + "',mgcs_MinBuyAmt=" + this.mgcs_MinBuyAmt.FormatTo("{0:0.0000}") + ",mgcs_MaxBuyAmt=" + this.mgcs_MaxBuyAmt.FormatTo("{0:0.0000}") + ",mgcs_AddPointRate=" + this.mgcs_AddPointRate.FormatTo("{0:0.0000}") + string.Format(",{0}={1},{2}={3}", (object) "mgcs_ModDate", (object) this.mgcs_ModDate.GetDateToStrInNull(), (object) "mgcs_ModUser", (object) this.mgcs_ModUser) + string.Format(" WHERE {0}={1}", (object) "mgcs_StoreCode", (object) this.mgcs_StoreCode) + string.Format(" AND {0}={1}", (object) "mgcs_MemberGrade", (object) this.mgcs_MemberGrade) + " AND mgcs_StartDate=" + this.mgcs_StartDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + string.Format(" AND {0}={1}", (object) "mgcs_SiteID", (object) this.mgcs_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.mgcs_StoreCode, (object) this.mgcs_MemberGrade, (object) this.mgcs_StartDate, (object) this.mgcs_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TMemberGradeCalcStd tmemberGradeCalcStd = this;
      // ISSUE: reference to a compiler-generated method
      tmemberGradeCalcStd.\u003C\u003En__1();
      if (await tmemberGradeCalcStd.OleDB.ExecuteAsync(tmemberGradeCalcStd.UpdateQuery()))
        return true;
      tmemberGradeCalcStd.message = " " + tmemberGradeCalcStd.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberGradeCalcStd.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberGradeCalcStd.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tmemberGradeCalcStd.mgcs_StoreCode, (object) tmemberGradeCalcStd.mgcs_MemberGrade, (object) tmemberGradeCalcStd.mgcs_StartDate, (object) tmemberGradeCalcStd.mgcs_SiteID) + " 내용 : " + tmemberGradeCalcStd.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberGradeCalcStd.message);
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
      stringBuilder.Append(" mgcs_EndDate=" + this.mgcs_EndDate.GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'") + string.Format(",{0}={1}", (object) "mgcs_MinBuyCnt", (object) this.mgcs_MinBuyCnt) + string.Format(",{0}={1}", (object) "mgcs_MaxBuyCnt", (object) this.mgcs_MaxBuyCnt) + ",mgcs_Operator='" + this.mgcs_Operator + "',mgcs_MinBuyAmt=" + this.mgcs_MinBuyAmt.FormatTo("{0:0.0000}") + ",mgcs_MaxBuyAmt=" + this.mgcs_MaxBuyAmt.FormatTo("{0:0.0000}") + ",mgcs_AddPointRate=" + this.mgcs_AddPointRate.FormatTo("{0:0.0000}") + string.Format(",{0}={1},{2}={3}", (object) "mgcs_ModDate", (object) this.mgcs_ModDate.GetDateToStrInNull(), (object) "mgcs_ModUser", (object) this.mgcs_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.mgcs_StoreCode, (object) this.mgcs_MemberGrade, (object) this.mgcs_StartDate, (object) this.mgcs_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TMemberGradeCalcStd tmemberGradeCalcStd = this;
      // ISSUE: reference to a compiler-generated method
      tmemberGradeCalcStd.\u003C\u003En__1();
      if (await tmemberGradeCalcStd.OleDB.ExecuteAsync(tmemberGradeCalcStd.UpdateExInsertQuery()))
        return true;
      tmemberGradeCalcStd.message = " " + tmemberGradeCalcStd.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberGradeCalcStd.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberGradeCalcStd.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tmemberGradeCalcStd.mgcs_StoreCode, (object) tmemberGradeCalcStd.mgcs_MemberGrade, (object) tmemberGradeCalcStd.mgcs_StartDate, (object) tmemberGradeCalcStd.mgcs_SiteID) + " 내용 : " + tmemberGradeCalcStd.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberGradeCalcStd.message);
      return false;
    }

    public string UpdateStartDateQuery(
      int p_mgcs_StoreCode,
      int p_mgcs_MemberGrade,
      DateTime p_mgcs_StartDate,
      DateTime pModStartDate,
      long p_mgcs_SiteID = 0)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode));
      stringBuilder.Append(" mgcs_StartDate=" + new DateTime?(pModStartDate).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'"));
      stringBuilder.Append(",mgcs_ModDate=" + this.mgcs_ModDate.GetDateToStrInNull());
      stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "mgcs_StoreCode", (object) p_mgcs_StoreCode));
      stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mgcs_MemberGrade", (object) p_mgcs_MemberGrade));
      stringBuilder.Append(" AND mgcs_StartDate=" + new DateTime?(p_mgcs_StartDate).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'"));
      if (p_mgcs_SiteID > 0L)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mgcs_SiteID", (object) p_mgcs_SiteID));
      return stringBuilder.ToString();
    }

    public bool UpdateStartDate(
      int p_mgcs_StoreCode,
      int p_mgcs_MemberGrade,
      DateTime p_mgcs_StartDate,
      DateTime pModStartDate,
      long p_mgcs_SiteID = 0)
    {
      this.UpdateChecked();
      this.mgcs_ModDate = new DateTime?(DateTime.Now);
      if (this.OleDB.Execute(this.UpdateStartDateQuery(p_mgcs_StoreCode, p_mgcs_MemberGrade, p_mgcs_StartDate, pModStartDate, p_mgcs_SiteID)))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2}) => {3},{4})\n", (object) p_mgcs_StoreCode, (object) p_mgcs_MemberGrade, (object) new DateTime?(p_mgcs_StartDate).GetDateToStr("yyyy-MM-dd"), (object) new DateTime?(pModStartDate).GetDateToStr("yyyy-MM-dd"), (object) p_mgcs_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public async Task<bool> UpdateStartDateAsync(
      int p_mgcs_StoreCode,
      int p_mgcs_MemberGrade,
      DateTime p_mgcs_StartDate,
      DateTime pModStartDate,
      long p_mgcs_SiteID = 0)
    {
      TMemberGradeCalcStd tmemberGradeCalcStd = this;
      // ISSUE: reference to a compiler-generated method
      tmemberGradeCalcStd.\u003C\u003En__1();
      tmemberGradeCalcStd.mgcs_ModDate = new DateTime?(DateTime.Now);
      if (await tmemberGradeCalcStd.OleDB.ExecuteAsync(tmemberGradeCalcStd.UpdateStartDateQuery(p_mgcs_StoreCode, p_mgcs_MemberGrade, p_mgcs_StartDate, pModStartDate, p_mgcs_SiteID)))
        return true;
      tmemberGradeCalcStd.message = " " + tmemberGradeCalcStd.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberGradeCalcStd.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberGradeCalcStd.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2}) => {3},{4})\n", (object) p_mgcs_StoreCode, (object) p_mgcs_MemberGrade, (object) new DateTime?(p_mgcs_StartDate).GetDateToStr("yyyy-MM-dd"), (object) new DateTime?(pModStartDate).GetDateToStr("yyyy-MM-dd"), (object) p_mgcs_SiteID) + " 내용 : " + tmemberGradeCalcStd.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberGradeCalcStd.message);
      return false;
    }

    public string UpdateEndDateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode) + " mgcs_EndDate=" + this.mgcs_EndDate.GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'") + string.Format(",{0}={1},{2}={3}", (object) "mgcs_ModDate", (object) this.mgcs_ModDate.GetDateToStrInNull(), (object) "mgcs_ModUser", (object) this.mgcs_ModUser) + string.Format(" WHERE {0}={1}", (object) "mgcs_StoreCode", (object) this.mgcs_StoreCode) + string.Format(" AND {0}={1}", (object) "mgcs_MemberGrade", (object) this.mgcs_MemberGrade) + " AND mgcs_StartDate=" + this.mgcs_StartDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + string.Format(" AND {0}={1}", (object) "mgcs_SiteID", (object) this.mgcs_SiteID);

    public bool UpdateEndDate()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateEndDateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.mgcs_StoreCode, (object) this.mgcs_MemberGrade, (object) this.mgcs_StartDate, (object) this.mgcs_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public async Task<bool> UpdateEndDateAsync()
    {
      TMemberGradeCalcStd tmemberGradeCalcStd = this;
      // ISSUE: reference to a compiler-generated method
      tmemberGradeCalcStd.\u003C\u003En__1();
      if (await tmemberGradeCalcStd.OleDB.ExecuteAsync(tmemberGradeCalcStd.UpdateEndDateQuery()))
        return true;
      tmemberGradeCalcStd.message = " " + tmemberGradeCalcStd.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberGradeCalcStd.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberGradeCalcStd.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tmemberGradeCalcStd.mgcs_StoreCode, (object) tmemberGradeCalcStd.mgcs_MemberGrade, (object) tmemberGradeCalcStd.mgcs_StartDate, (object) tmemberGradeCalcStd.mgcs_SiteID) + " 내용 : " + tmemberGradeCalcStd.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberGradeCalcStd.message);
      return false;
    }

    public override string DeleteQuery() => string.Format(" DELETE FROM {0}{1}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode) + string.Format(" WHERE {0}={1}", (object) "mgcs_StoreCode", (object) this.mgcs_StoreCode) + string.Format(" AND {0}={1}", (object) "mgcs_MemberGrade", (object) this.mgcs_MemberGrade) + " AND mgcs_StartDate=" + this.mgcs_StartDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + string.Format(" AND {0}={1}", (object) "mgcs_SiteID", (object) this.mgcs_SiteID);

    public override bool Delete()
    {
      this.InsertChecked();
      string pStrExec = this.DeleteQuery();
      if (this.OleDB.Execute(pStrExec))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 삭제 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.mgcs_StoreCode, (object) this.mgcs_MemberGrade, (object) this.mgcs_StartDate, (object) this.mgcs_SiteID) + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n 쿼리 : " + pStrExec + "\n--------------------------------------------------------------------------------------------------\n";
      return false;
    }

    public override async Task<bool> DeleteAsync()
    {
      TMemberGradeCalcStd tmemberGradeCalcStd = this;
      // ISSUE: reference to a compiler-generated method
      tmemberGradeCalcStd.\u003C\u003En__0();
      if (await tmemberGradeCalcStd.OleDB.ExecuteAsync(tmemberGradeCalcStd.DeleteQuery()))
        return true;
      tmemberGradeCalcStd.message = " " + tmemberGradeCalcStd.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberGradeCalcStd.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberGradeCalcStd.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tmemberGradeCalcStd.mgcs_StoreCode, (object) tmemberGradeCalcStd.mgcs_MemberGrade, (object) tmemberGradeCalcStd.mgcs_StartDate, (object) tmemberGradeCalcStd.mgcs_SiteID) + " 내용 : " + tmemberGradeCalcStd.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberGradeCalcStd.message);
      return false;
    }

    public virtual string DeleteQuery(
      int p_mgcs_StoreCode,
      int p_mgcs_MemberGrade,
      DateTime p_mgcs_StartDate,
      long p_mgcs_SiteID = 0)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format(" DELETE FROM {0}{1} ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode));
      stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "mgcs_StoreCode", (object) p_mgcs_StoreCode));
      stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mgcs_MemberGrade", (object) p_mgcs_MemberGrade));
      stringBuilder.Append(" AND mgcs_StartDate=" + new DateTime?(p_mgcs_StartDate).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'"));
      if (p_mgcs_SiteID > 0L)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mgcs_SiteID", (object) p_mgcs_SiteID));
      return stringBuilder.ToString();
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "mgcs_SiteID") && Convert.ToInt64(hashtable[(object) "mgcs_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "mgcs_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "mgcs_StoreCode") && Convert.ToInt32(hashtable[(object) "mgcs_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mgcs_StoreCode", hashtable[(object) "mgcs_StoreCode"]));
        else if (hashtable.ContainsKey((object) "si_StoreCode") && Convert.ToInt32(hashtable[(object) "si_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mgcs_StoreCode", hashtable[(object) "si_StoreCode"]));
        else if (hashtable.ContainsKey((object) "si_StoreCode_IN_") && hashtable[(object) "si_StoreCode_IN_"].ToString().Length > 0)
        {
          if (hashtable[(object) "si_StoreCode_IN_"].ToString().Contains(","))
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "mgcs_StoreCode", hashtable[(object) "si_StoreCode_IN_"]));
          else
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mgcs_StoreCode", hashtable[(object) "si_StoreCode_IN_"]));
        }
        else if (hashtable.ContainsKey((object) "mgcs_StoreCode_IN_") && hashtable[(object) "mgcs_StoreCode_IN_"].ToString().Length > 0)
        {
          if (hashtable[(object) "mgcs_StoreCode_IN_"].ToString().Contains(","))
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "mgcs_StoreCode", hashtable[(object) "mgcs_StoreCode_IN_"]));
          else
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mgcs_StoreCode", hashtable[(object) "mgcs_StoreCode_IN_"]));
        }
        else if (hashtable.ContainsKey((object) "_STORE_AUTHS_") && !string.IsNullOrEmpty(hashtable[(object) "_STORE_AUTHS_"].ToString()))
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "mgcs_StoreCode", hashtable[(object) "_STORE_AUTHS_"]));
        if (hashtable.ContainsKey((object) "mgcs_MemberGrade") && Convert.ToInt32(hashtable[(object) "mgcs_MemberGrade"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mgcs_MemberGrade", hashtable[(object) "mgcs_MemberGrade"]));
        if (hashtable.ContainsKey((object) "mgcs_StartDate") && !string.IsNullOrEmpty(hashtable[(object) "mgcs_StartDate"].ToString()))
          stringBuilder.Append(" AND mgcs_StartDate<=" + new DateTime?((DateTime) hashtable[(object) "mgcs_StartDate"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + " AND mgcs_StartDate>=" + new DateTime?((DateTime) hashtable[(object) "mgcs_StartDate"]).GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'"));
        if (hashtable.ContainsKey((object) "_DT_DATE_") && !string.IsNullOrEmpty(hashtable[(object) "_DT_DATE_"].ToString()))
        {
          stringBuilder.Append(" AND mgcs_StartDate <='" + new DateTime?((DateTime) hashtable[(object) "_DT_DATE_"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND mgcs_EndDate >='" + new DateTime?((DateTime) hashtable[(object) "_DT_DATE_"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
        }
        if (hashtable.ContainsKey((object) "_DT_START_DATE_") && !string.IsNullOrEmpty(hashtable[(object) "_DT_START_DATE_"].ToString()) && hashtable.ContainsKey((object) "_DT_END_DATE_") && !string.IsNullOrEmpty(hashtable[(object) "_DT_END_DATE_"].ToString()))
        {
          string dateToStr1 = new DateTime?((DateTime) hashtable[(object) "_DT_START_DATE_"]).GetDateToStr("yyyy-MM-dd 00:00:00");
          string dateToStr2 = new DateTime?((DateTime) hashtable[(object) "_DT_START_DATE_"]).GetDateToStr("yyyy-MM-dd 23:59:59");
          string dateToStr3 = new DateTime?((DateTime) hashtable[(object) "_DT_END_DATE_"]).GetDateToStr("yyyy-MM-dd 00:00:00");
          string dateToStr4 = new DateTime?((DateTime) hashtable[(object) "_DT_END_DATE_"]).GetDateToStr("yyyy-MM-dd 23:59:59");
          stringBuilder.Append(" AND (");
          stringBuilder.Append(" (mgcs_StartDate <= '" + dateToStr1 + "' AND mgcs_EndDate >= '" + dateToStr2 + "' )");
          stringBuilder.Append(" OR (mgcs_StartDate <= '" + dateToStr3 + "' AND mgcs_EndDate >= '" + dateToStr4 + "' )");
          stringBuilder.Append(" OR (mgcs_StartDate >= '" + dateToStr1 + "' AND mgcs_EndDate <= '" + dateToStr4 + "' )");
          stringBuilder.Append(") ");
        }
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mgcs_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "mgcs_Operator") && !string.IsNullOrEmpty(this.mgcs_Operator))
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "mgcs_Operator", hashtable[(object) "mgcs_Operator"]));
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
        stringBuilder.Append(" SELECT  mgcs_StoreCode,mgcs_MemberGrade,mgcs_StartDate,mgcs_SiteID,mgcs_EndDate,mgcs_MinBuyCnt,mgcs_MaxBuyCnt,mgcs_Operator,mgcs_MinBuyAmt,mgcs_MaxBuyAmt,mgcs_AddPointRate,mgcs_InDate,mgcs_InUser,mgcs_ModDate,mgcs_ModUser");
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
