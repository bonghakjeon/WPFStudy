// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.History.MemberPointHistory.TMemberPointHistory
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

namespace UniBiz.Bo.Models.UniMembers.History.MemberPointHistory
{
  public class TMemberPointHistory : UbModelBase<TMemberPointHistory>
  {
    private long _mph_Seq;
    private long _mph_SiteID;
    private DateTime? _mph_SysDate;
    private long _mph_MemberNo;
    private int _mph_StoreCode;
    private int _mph_PointType;
    private DateTime? _mph_SaleDate;
    private int _mph_PosNo;
    private int _mph_TransNo;
    private string _mph_MemberCardNo;
    private int _mph_SaleType;
    private double _mph_SaleAmt;
    private int _mph_TodayAddPoint;
    private int _mph_TodayUsePoint;
    private int _mph_TotalPoint;
    private int _mph_UsePoint;
    private int _mph_UsablePoint;
    private string _mph_Memo;
    private DateTime? _mph_ExtinctionDate;
    private string _mph_TransmitYn;
    private DateTime? _mph_TransmitDate;
    private DateTime? _mph_InputDate;
    private DateTime? _mph_InDate;
    private int _mph_InUser;
    private DateTime? _mph_ModDate;
    private int _mph_ModUser;

    public override object _Key => (object) new object[1]
    {
      (object) this.mph_Seq
    };

    public long mph_Seq
    {
      get => this._mph_Seq;
      set
      {
        this._mph_Seq = value;
        this.Changed(nameof (mph_Seq));
      }
    }

    public long mph_SiteID
    {
      get => this._mph_SiteID;
      set
      {
        this._mph_SiteID = value;
        this.Changed(nameof (mph_SiteID));
      }
    }

    public DateTime? mph_SysDate
    {
      get => this._mph_SysDate;
      set
      {
        this._mph_SysDate = value;
        this.Changed(nameof (mph_SysDate));
      }
    }

    public long mph_MemberNo
    {
      get => this._mph_MemberNo;
      set
      {
        this._mph_MemberNo = value;
        this.Changed(nameof (mph_MemberNo));
      }
    }

    public int mph_StoreCode
    {
      get => this._mph_StoreCode;
      set
      {
        this._mph_StoreCode = value;
        this.Changed(nameof (mph_StoreCode));
      }
    }

    public int mph_PointType
    {
      get => this._mph_PointType;
      set
      {
        this._mph_PointType = value;
        this.Changed(nameof (mph_PointType));
        this.Changed("mph_PointTypeDesc");
      }
    }

    public string mph_PointTypeDesc => this.mph_PointType != 0 ? Enum2StrConverter.ToCommonCodeTypeMemo(this.mph_SiteID, EnumCommonCodeType.PointHistoryPointType, this.mph_PointType) : string.Empty;

    public DateTime? mph_SaleDate
    {
      get => this._mph_SaleDate;
      set
      {
        this._mph_SaleDate = value;
        this.Changed(nameof (mph_SaleDate));
      }
    }

    public int mph_PosNo
    {
      get => this._mph_PosNo;
      set
      {
        this._mph_PosNo = value;
        this.Changed(nameof (mph_PosNo));
      }
    }

    public int mph_TransNo
    {
      get => this._mph_TransNo;
      set
      {
        this._mph_TransNo = value;
        this.Changed(nameof (mph_TransNo));
      }
    }

    public string mph_MemberCardNo
    {
      get => this._mph_MemberCardNo;
      set
      {
        this._mph_MemberCardNo = UbModelBase.LeftStr(value, 20).Replace("'", "´");
        this.Changed(nameof (mph_MemberCardNo));
      }
    }

    public int mph_SaleType
    {
      get => this._mph_SaleType;
      set
      {
        this._mph_SaleType = value;
        this.Changed(nameof (mph_SaleType));
        this.Changed("mph_SaleTypeDesc");
      }
    }

    public string mph_SaleTypeDesc => this.mph_SaleType != 0 ? Enum2StrConverter.ToCommonCodeTypeMemo(this.mph_SiteID, EnumCommonCodeType.TrSaleType, this.mph_SaleType) : string.Empty;

    public double mph_SaleAmt
    {
      get => this._mph_SaleAmt;
      set
      {
        this._mph_SaleAmt = value;
        this.Changed(nameof (mph_SaleAmt));
      }
    }

    public int mph_TodayAddPoint
    {
      get => this._mph_TodayAddPoint;
      set
      {
        this._mph_TodayAddPoint = value;
        this.Changed(nameof (mph_TodayAddPoint));
      }
    }

    public int mph_TodayUsePoint
    {
      get => this._mph_TodayUsePoint;
      set
      {
        this._mph_TodayUsePoint = value;
        this.Changed(nameof (mph_TodayUsePoint));
      }
    }

    public int mph_TotalPoint
    {
      get => this._mph_TotalPoint;
      set
      {
        this._mph_TotalPoint = value;
        this.Changed(nameof (mph_TotalPoint));
      }
    }

    public int mph_UsePoint
    {
      get => this._mph_UsePoint;
      set
      {
        this._mph_UsePoint = value;
        this.Changed(nameof (mph_UsePoint));
      }
    }

    public int mph_UsablePoint
    {
      get => this._mph_UsablePoint;
      set
      {
        this._mph_UsablePoint = value;
        this.Changed(nameof (mph_UsablePoint));
      }
    }

    public string mph_Memo
    {
      get => this._mph_Memo;
      set
      {
        this._mph_Memo = UbModelBase.LeftStr(value, 50).Replace("'", "´");
        this.Changed(nameof (mph_Memo));
      }
    }

    public DateTime? mph_ExtinctionDate
    {
      get => this._mph_ExtinctionDate;
      set
      {
        this._mph_ExtinctionDate = value;
        this.Changed(nameof (mph_ExtinctionDate));
      }
    }

    public string mph_TransmitYn
    {
      get => this._mph_TransmitYn;
      set
      {
        this._mph_TransmitYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (mph_TransmitYn));
        this.Changed("mph_IsTransmit");
        this.Changed("mph_TransmitYnDesc");
      }
    }

    public bool mph_IsTransmit => "Y".Equals(this.mph_TransmitYn);

    public string mph_TransmitYnDesc => !"Y".Equals(this.mph_TransmitYn) ? "미전송" : "전송";

    public DateTime? mph_TransmitDate
    {
      get => this._mph_TransmitDate;
      set
      {
        this._mph_TransmitDate = value;
        this.Changed(nameof (mph_TransmitDate));
      }
    }

    public DateTime? mph_InputDate
    {
      get => this._mph_InputDate;
      set
      {
        this._mph_InputDate = value;
        this.Changed(nameof (mph_InputDate));
      }
    }

    public DateTime? mph_InDate
    {
      get => this._mph_InDate;
      set
      {
        this._mph_InDate = value;
        this.Changed(nameof (mph_InDate));
      }
    }

    public int mph_InUser
    {
      get => this._mph_InUser;
      set
      {
        this._mph_InUser = value;
        this.Changed(nameof (mph_InUser));
      }
    }

    public DateTime? mph_ModDate
    {
      get => this._mph_ModDate;
      set
      {
        this._mph_ModDate = value;
        this.Changed(nameof (mph_ModDate));
      }
    }

    public int mph_ModUser
    {
      get => this._mph_ModUser;
      set
      {
        this._mph_ModUser = value;
        this.Changed(nameof (mph_ModUser));
      }
    }

    public TMemberPointHistory() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("mph_Seq", new TTableColumn()
      {
        tc_orgin_name = "mph_Seq",
        tc_trans_name = "순번"
      });
      columnInfo.Add("mph_SiteID", new TTableColumn()
      {
        tc_orgin_name = "mph_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("mph_SysDate", new TTableColumn()
      {
        tc_orgin_name = "mph_SysDate",
        tc_trans_name = "발생일자(시스템)"
      });
      columnInfo.Add("mph_MemberNo", new TTableColumn()
      {
        tc_orgin_name = "mph_MemberNo",
        tc_trans_name = "회원번호"
      });
      columnInfo.Add("mph_StoreCode", new TTableColumn()
      {
        tc_orgin_name = "mph_StoreCode",
        tc_trans_name = "지점"
      });
      columnInfo.Add("mph_PointType", new TTableColumn()
      {
        tc_orgin_name = "mph_PointType",
        tc_trans_name = "적립구분",
        tc_comm_code = 189
      });
      columnInfo.Add("mph_SaleDate", new TTableColumn()
      {
        tc_orgin_name = "mph_SaleDate",
        tc_trans_name = "영업일자"
      });
      columnInfo.Add("mph_PosNo", new TTableColumn()
      {
        tc_orgin_name = "mph_PosNo",
        tc_trans_name = "포스번호"
      });
      columnInfo.Add("mph_TransNo", new TTableColumn()
      {
        tc_orgin_name = "mph_TransNo",
        tc_trans_name = "거래번호"
      });
      columnInfo.Add("mph_MemberCardNo", new TTableColumn()
      {
        tc_orgin_name = "mph_MemberCardNo",
        tc_trans_name = "사용카드"
      });
      columnInfo.Add("mph_SaleType", new TTableColumn()
      {
        tc_orgin_name = "mph_SaleType",
        tc_trans_name = "TrlogTextDesc.trh_SaleType",
        tc_comm_code = 157
      });
      columnInfo.Add("mph_SaleAmt", new TTableColumn()
      {
        tc_orgin_name = "mph_SaleAmt",
        tc_trans_name = "적립(사용)대상금액"
      });
      columnInfo.Add("mph_TodayAddPoint", new TTableColumn()
      {
        tc_orgin_name = "mph_TodayAddPoint",
        tc_trans_name = "적립포인트"
      });
      columnInfo.Add("mph_TodayUsePoint", new TTableColumn()
      {
        tc_orgin_name = "mph_TodayUsePoint",
        tc_trans_name = "사용포인트"
      });
      columnInfo.Add("mph_TotalPoint", new TTableColumn()
      {
        tc_orgin_name = "mph_TotalPoint",
        tc_trans_name = "적립후 누계포인트"
      });
      columnInfo.Add("mph_UsablePoint", new TTableColumn()
      {
        tc_orgin_name = "mph_UsablePoint",
        tc_trans_name = "적립후 가용포인트"
      });
      columnInfo.Add("mph_Memo", new TTableColumn()
      {
        tc_orgin_name = "mph_Memo",
        tc_trans_name = "메모"
      });
      columnInfo.Add("mph_ExtinctionDate", new TTableColumn()
      {
        tc_orgin_name = "mph_ExtinctionDate",
        tc_trans_name = "소멸예정일"
      });
      columnInfo.Add("mph_TransmitYn", new TTableColumn()
      {
        tc_orgin_name = "mph_TransmitYn",
        tc_trans_name = "수신여부"
      });
      columnInfo.Add("mph_TransmitDate", new TTableColumn()
      {
        tc_orgin_name = "mph_TransmitDate",
        tc_trans_name = "수신일자"
      });
      columnInfo.Add("mph_InputDate", new TTableColumn()
      {
        tc_orgin_name = "mph_InputDate",
        tc_trans_name = "발생일시"
      });
      columnInfo.Add("mph_InDate", new TTableColumn()
      {
        tc_orgin_name = "mph_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("mph_InUser", new TTableColumn()
      {
        tc_orgin_name = "mph_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("mph_ModDate", new TTableColumn()
      {
        tc_orgin_name = "mph_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("mph_ModUser", new TTableColumn()
      {
        tc_orgin_name = "mph_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.MemberPointHistory;
      this.mph_Seq = this.mph_SiteID = 0L;
      this.mph_SysDate = new DateTime?();
      this.mph_MemberNo = 0L;
      this.mph_StoreCode = 0;
      this.mph_PointType = 0;
      this.mph_SaleDate = new DateTime?();
      this.mph_PosNo = this.mph_TransNo = 0;
      this.mph_MemberCardNo = string.Empty;
      this.mph_SaleType = 0;
      this.mph_SaleAmt = 0.0;
      this.mph_TodayAddPoint = this.mph_TodayUsePoint = this.mph_TotalPoint = this.mph_UsePoint = this.mph_UsablePoint = 0;
      this.mph_Memo = string.Empty;
      this.mph_ExtinctionDate = new DateTime?();
      this.mph_TransmitYn = "N";
      this.mph_TransmitDate = new DateTime?();
      this.mph_InputDate = new DateTime?();
      this.mph_InDate = new DateTime?();
      this.mph_InUser = 0;
      this.mph_ModDate = new DateTime?();
      this.mph_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TMemberPointHistory();

    public override object Clone()
    {
      TMemberPointHistory tmemberPointHistory = base.Clone() as TMemberPointHistory;
      tmemberPointHistory.mph_Seq = this.mph_Seq;
      tmemberPointHistory.mph_SiteID = this.mph_SiteID;
      tmemberPointHistory.mph_SysDate = this.mph_SysDate;
      tmemberPointHistory.mph_MemberNo = this.mph_MemberNo;
      tmemberPointHistory.mph_StoreCode = this.mph_StoreCode;
      tmemberPointHistory.mph_PointType = this.mph_PointType;
      tmemberPointHistory.mph_SaleDate = this.mph_SaleDate;
      tmemberPointHistory.mph_PosNo = this.mph_PosNo;
      tmemberPointHistory.mph_TransNo = this.mph_TransNo;
      tmemberPointHistory.mph_MemberCardNo = this.mph_MemberCardNo;
      tmemberPointHistory.mph_SaleType = this.mph_SaleType;
      tmemberPointHistory.mph_SaleAmt = this.mph_SaleAmt;
      tmemberPointHistory.mph_TodayAddPoint = this.mph_TodayAddPoint;
      tmemberPointHistory.mph_TodayUsePoint = this.mph_TodayUsePoint;
      tmemberPointHistory.mph_TotalPoint = this.mph_TotalPoint;
      tmemberPointHistory.mph_UsePoint = this.mph_UsePoint;
      tmemberPointHistory.mph_UsablePoint = this.mph_UsablePoint;
      tmemberPointHistory.mph_Memo = this.mph_Memo;
      tmemberPointHistory.mph_ExtinctionDate = this.mph_ExtinctionDate;
      tmemberPointHistory.mph_TransmitYn = this.mph_TransmitYn;
      tmemberPointHistory.mph_TransmitDate = this.mph_TransmitDate;
      tmemberPointHistory.mph_InputDate = this.mph_InputDate;
      tmemberPointHistory.mph_InDate = this.mph_InDate;
      tmemberPointHistory.mph_InUser = this.mph_InUser;
      tmemberPointHistory.mph_ModDate = this.mph_ModDate;
      tmemberPointHistory.mph_ModUser = this.mph_ModUser;
      return (object) tmemberPointHistory;
    }

    public void PutData(TMemberPointHistory pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.mph_Seq = pSource.mph_Seq;
      this.mph_SiteID = pSource.mph_SiteID;
      this.mph_SysDate = pSource.mph_SysDate;
      this.mph_MemberNo = pSource.mph_MemberNo;
      this.mph_StoreCode = pSource.mph_StoreCode;
      this.mph_PointType = pSource.mph_PointType;
      this.mph_SaleDate = pSource.mph_SaleDate;
      this.mph_PosNo = pSource.mph_PosNo;
      this.mph_TransNo = pSource.mph_TransNo;
      this.mph_MemberCardNo = pSource.mph_MemberCardNo;
      this.mph_SaleType = pSource.mph_SaleType;
      this.mph_SaleAmt = pSource.mph_SaleAmt;
      this.mph_TodayAddPoint = pSource.mph_TodayAddPoint;
      this.mph_TodayUsePoint = pSource.mph_TodayUsePoint;
      this.mph_TotalPoint = pSource.mph_TotalPoint;
      this.mph_UsePoint = pSource.mph_UsePoint;
      this.mph_UsablePoint = pSource.mph_UsablePoint;
      this.mph_Memo = pSource.mph_Memo;
      this.mph_ExtinctionDate = pSource.mph_ExtinctionDate;
      this.mph_TransmitYn = pSource.mph_TransmitYn;
      this.mph_TransmitDate = pSource.mph_TransmitDate;
      this.mph_InputDate = pSource.mph_InputDate;
      this.mph_InDate = pSource.mph_InDate;
      this.mph_InUser = pSource.mph_InUser;
      this.mph_ModDate = pSource.mph_ModDate;
      this.mph_ModUser = pSource.mph_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.mph_Seq = (long) p_rs.GetFieldInt("mph_Seq");
        if (this.mph_Seq == 0L)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.mph_SiteID = p_rs.GetFieldLong("mph_SiteID");
        this.mph_SysDate = p_rs.GetFieldDateTime("mph_SysDate");
        this.mph_MemberNo = p_rs.GetFieldLong("mph_MemberNo");
        this.mph_StoreCode = p_rs.GetFieldInt("mph_StoreCode");
        this.mph_PointType = p_rs.GetFieldInt("mph_PointType");
        this.mph_SaleDate = p_rs.GetFieldDateTime("mph_SaleDate");
        this.mph_PosNo = p_rs.GetFieldInt("mph_PosNo");
        this.mph_TransNo = p_rs.GetFieldInt("mph_TransNo");
        this.mph_MemberCardNo = p_rs.GetFieldString("mph_MemberCardNo");
        this.mph_SaleType = p_rs.GetFieldInt("mph_SaleType");
        this.mph_SaleAmt = p_rs.GetFieldDouble("mph_SaleAmt");
        this.mph_TodayAddPoint = p_rs.GetFieldInt("mph_TodayAddPoint");
        this.mph_TodayUsePoint = p_rs.GetFieldInt("mph_TodayUsePoint");
        this.mph_TotalPoint = p_rs.GetFieldInt("mph_TotalPoint");
        this.mph_UsePoint = p_rs.GetFieldInt("mph_UsePoint");
        this.mph_UsablePoint = p_rs.GetFieldInt("mph_UsablePoint");
        this.mph_Memo = p_rs.GetFieldString("mph_Memo");
        this.mph_ExtinctionDate = p_rs.GetFieldDateTime("mph_ExtinctionDate");
        this.mph_TransmitYn = p_rs.GetFieldString("mph_TransmitYn");
        this.mph_TransmitDate = p_rs.GetFieldDateTime("mph_TransmitDate");
        this.mph_InputDate = p_rs.GetFieldDateTime("mph_InputDate");
        this.mph_InDate = p_rs.GetFieldDateTime("mph_InDate");
        this.mph_InUser = p_rs.GetFieldInt("mph_InUser");
        this.mph_ModDate = p_rs.GetFieldDateTime("mph_ModDate");
        this.mph_ModUser = p_rs.GetFieldInt("mph_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode) + " mph_Seq,mph_SiteID,mph_SysDate,mph_MemberNo,mph_StoreCode,mph_PointType,mph_SaleDate,mph_PosNo,mph_TransNo,mph_MemberCardNo,mph_SaleType,mph_SaleAmt,mph_TodayAddPoint,mph_TodayUsePoint,mph_TotalPoint,mph_UsePoint,mph_UsablePoint,mph_Memo,mph_ExtinctionDate,mph_TransmitYn,mph_TransmitDate,mph_InputDate,mph_InDate,mph_InUser,mph_ModDate,mph_ModUser\n) VALUES (\n" + string.Format(" {0}", (object) this.mph_Seq) + string.Format(",{0}", (object) this.mph_SiteID) + "," + this.mph_SysDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + string.Format(",{0},{1},{2}", (object) this.mph_MemberNo, (object) this.mph_StoreCode, (object) this.mph_PointType) + "," + this.mph_SaleDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + string.Format(",{0},{1},'{2}',{3}", (object) this.mph_PosNo, (object) this.mph_TransNo, (object) this.mph_MemberCardNo, (object) this.mph_SaleType) + "," + this.mph_SaleAmt.FormatTo("{0:0.0000}") + string.Format(",{0},{1},{2}", (object) this.mph_TodayAddPoint, (object) this.mph_TodayUsePoint, (object) this.mph_TotalPoint) + string.Format(",{0},{1}", (object) this.mph_UsePoint, (object) this.mph_UsablePoint) + ",'" + this.mph_Memo + "'," + this.mph_ExtinctionDate.GetDateToStrInNull() + ",'" + this.mph_TransmitYn + "'," + this.mph_TransmitDate.GetDateToStrInNull() + "," + this.mph_InputDate.GetDateToStrInNull() + string.Format(",{0},{1}", (object) this.mph_InDate.GetDateToStrInNull(), (object) this.mph_InUser) + string.Format(",{0},{1}", (object) this.mph_ModDate.GetDateToStrInNull(), (object) this.mph_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.mph_Seq, (object) this.mph_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TMemberPointHistory tmemberPointHistory = this;
      // ISSUE: reference to a compiler-generated method
      tmemberPointHistory.\u003C\u003En__0();
      if (await tmemberPointHistory.OleDB.ExecuteAsync(tmemberPointHistory.InsertQuery()))
        return true;
      tmemberPointHistory.message = " " + tmemberPointHistory.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberPointHistory.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberPointHistory.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tmemberPointHistory.mph_Seq, (object) tmemberPointHistory.mph_SiteID) + " 내용 : " + tmemberPointHistory.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberPointHistory.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode) + " mph_SysDate=" + this.mph_SysDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + string.Format(",{0}={1},{2}={3},{4}={5}", (object) "mph_MemberNo", (object) this.mph_MemberNo, (object) "mph_StoreCode", (object) this.mph_StoreCode, (object) "mph_PointType", (object) this.mph_PointType) + ",mph_SaleDate=" + this.mph_SaleDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + string.Format(",{0}={1},{2}={3}", (object) "mph_PosNo", (object) this.mph_PosNo, (object) "mph_TransNo", (object) this.mph_TransNo) + string.Format(",{0}='{1}',{2}={3}", (object) "mph_MemberCardNo", (object) this.mph_MemberCardNo, (object) "mph_SaleType", (object) this.mph_SaleType) + ",mph_SaleAmt=" + this.mph_SaleAmt.FormatTo("{0:0.0000}") + string.Format(",{0}={1},{2}={3}", (object) "mph_TodayAddPoint", (object) this.mph_TodayAddPoint, (object) "mph_TodayUsePoint", (object) this.mph_TodayUsePoint) + string.Format(",{0}={1}", (object) "mph_TotalPoint", (object) this.mph_TotalPoint) + string.Format(",{0}={1},{2}={3}", (object) "mph_UsePoint", (object) this.mph_UsePoint, (object) "mph_UsablePoint", (object) this.mph_UsablePoint) + ",mph_Memo='" + this.mph_Memo + "',mph_ExtinctionDate=" + this.mph_ExtinctionDate.GetDateToStrInNull() + ",mph_TransmitYn='" + this.mph_TransmitYn + "',mph_TransmitDate=" + this.mph_TransmitDate.GetDateToStrInNull() + ",mph_InputDate=" + this.mph_InputDate.GetDateToStrInNull() + string.Format(",{0}={1},{2}={3}", (object) "mph_ModDate", (object) this.mph_ModDate.GetDateToStrInNull(), (object) "mph_ModUser", (object) this.mph_ModUser) + string.Format(" WHERE {0}={1}", (object) "mph_Seq", (object) this.mph_Seq) + string.Format(" AND {0}={1}", (object) "mph_SiteID", (object) this.mph_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.mph_Seq, (object) this.mph_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TMemberPointHistory tmemberPointHistory = this;
      // ISSUE: reference to a compiler-generated method
      tmemberPointHistory.\u003C\u003En__1();
      if (await tmemberPointHistory.OleDB.ExecuteAsync(tmemberPointHistory.UpdateQuery()))
        return true;
      tmemberPointHistory.message = " " + tmemberPointHistory.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberPointHistory.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberPointHistory.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tmemberPointHistory.mph_Seq, (object) tmemberPointHistory.mph_SiteID) + " 내용 : " + tmemberPointHistory.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberPointHistory.message);
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
      stringBuilder.Append(" mph_SysDate=" + this.mph_SysDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + string.Format(",{0}={1},{2}={3},{4}={5}", (object) "mph_MemberNo", (object) this.mph_MemberNo, (object) "mph_StoreCode", (object) this.mph_StoreCode, (object) "mph_PointType", (object) this.mph_PointType) + ",mph_SaleDate=" + this.mph_SaleDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + string.Format(",{0}={1},{2}={3}", (object) "mph_PosNo", (object) this.mph_PosNo, (object) "mph_TransNo", (object) this.mph_TransNo) + string.Format(",{0}='{1}',{2}={3}", (object) "mph_MemberCardNo", (object) this.mph_MemberCardNo, (object) "mph_SaleType", (object) this.mph_SaleType) + ",mph_SaleAmt=" + this.mph_SaleAmt.FormatTo("{0:0.0000}") + string.Format(",{0}={1},{2}={3}", (object) "mph_TodayAddPoint", (object) this.mph_TodayAddPoint, (object) "mph_TodayUsePoint", (object) this.mph_TodayUsePoint) + string.Format(",{0}={1}", (object) "mph_TotalPoint", (object) this.mph_TotalPoint) + string.Format(",{0}={1},{2}={3}", (object) "mph_UsePoint", (object) this.mph_UsePoint, (object) "mph_UsablePoint", (object) this.mph_UsablePoint) + ",mph_Memo='" + this.mph_Memo + "',mph_ExtinctionDate=" + this.mph_ExtinctionDate.GetDateToStrInNull() + ",mph_TransmitYn='" + this.mph_TransmitYn + "',mph_TransmitDate=" + this.mph_TransmitDate.GetDateToStrInNull() + ",mph_InputDate=" + this.mph_InputDate.GetDateToStrInNull() + string.Format(",{0}={1},{2}={3}", (object) "mph_ModDate", (object) this.mph_ModDate.GetDateToStrInNull(), (object) "mph_ModUser", (object) this.mph_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.mph_Seq, (object) this.mph_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TMemberPointHistory tmemberPointHistory = this;
      // ISSUE: reference to a compiler-generated method
      tmemberPointHistory.\u003C\u003En__1();
      if (await tmemberPointHistory.OleDB.ExecuteAsync(tmemberPointHistory.UpdateExInsertQuery()))
        return true;
      tmemberPointHistory.message = " " + tmemberPointHistory.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberPointHistory.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberPointHistory.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tmemberPointHistory.mph_Seq, (object) tmemberPointHistory.mph_SiteID) + " 내용 : " + tmemberPointHistory.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberPointHistory.message);
      return false;
    }

    public override string DeleteQuery() => string.Format(" DELETE FROM {0}{1}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode) + string.Format(" WHERE {0}={1}", (object) "mph_Seq", (object) this.mph_Seq) + string.Format(" AND {0}={1}", (object) "mph_SiteID", (object) this.mph_SiteID);

    public override bool Delete()
    {
      this.InsertChecked();
      string pStrExec = this.DeleteQuery();
      if (this.OleDB.Execute(pStrExec))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 삭제 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 코드 : ({0},{1})\n", (object) this.mph_Seq, (object) this.mph_SiteID) + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n 쿼리 : " + pStrExec + "\n--------------------------------------------------------------------------------------------------\n";
      return false;
    }

    public override async Task<bool> DeleteAsync()
    {
      TMemberPointHistory tmemberPointHistory = this;
      // ISSUE: reference to a compiler-generated method
      tmemberPointHistory.\u003C\u003En__0();
      if (await tmemberPointHistory.OleDB.ExecuteAsync(tmemberPointHistory.DeleteQuery()))
        return true;
      tmemberPointHistory.message = " " + tmemberPointHistory.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberPointHistory.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberPointHistory.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tmemberPointHistory.mph_Seq, (object) tmemberPointHistory.mph_SiteID) + " 내용 : " + tmemberPointHistory.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberPointHistory.message);
      return false;
    }

    public virtual string DeleteQuery(long p_mph_Seq, long p_mph_SiteID = 0)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format(" DELETE FROM {0}{1} ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode));
      stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "mph_Seq", (object) p_mph_Seq));
      if (p_mph_SiteID > 0L)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mph_SiteID", (object) p_mph_SiteID));
      return stringBuilder.ToString();
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "mph_SiteID") && Convert.ToInt64(hashtable[(object) "mph_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "mph_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "mph_Seq") && Convert.ToInt64(hashtable[(object) "mph_Seq"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mph_Seq", hashtable[(object) "mph_Seq"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mph_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "mph_SysDate_BEGIN_") && !string.IsNullOrEmpty(hashtable[(object) "mph_SysDate_BEGIN_"].ToString()) && hashtable.ContainsKey((object) "mph_SysDate_END_") && !string.IsNullOrEmpty(hashtable[(object) "mph_SysDate_END_"].ToString()))
          stringBuilder.Append(" AND mph_SysDate<=" + new DateTime?((DateTime) hashtable[(object) "mph_SysDate_BEGIN_"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + " AND mph_SysDate>=" + new DateTime?((DateTime) hashtable[(object) "mph_SysDate_END_"]).GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'"));
        if (hashtable.ContainsKey((object) "mph_MemberNo") && Convert.ToInt64(hashtable[(object) "mph_MemberNo"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mph_MemberNo", hashtable[(object) "mph_MemberNo"]));
        if (hashtable.ContainsKey((object) "mph_StoreCode") && Convert.ToInt32(hashtable[(object) "mph_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mph_StoreCode", hashtable[(object) "mph_StoreCode"]));
        else if (hashtable.ContainsKey((object) "si_StoreCode") && Convert.ToInt32(hashtable[(object) "si_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mph_StoreCode", hashtable[(object) "si_StoreCode"]));
        else if (hashtable.ContainsKey((object) "si_StoreCode_IN_") && hashtable[(object) "si_StoreCode_IN_"].ToString().Length > 0)
        {
          if (hashtable[(object) "si_StoreCode_IN_"].ToString().Contains(","))
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "mph_StoreCode", hashtable[(object) "si_StoreCode_IN_"]));
          else
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mph_StoreCode", hashtable[(object) "si_StoreCode_IN_"]));
        }
        else if (hashtable.ContainsKey((object) "mph_StoreCode_IN_") && hashtable[(object) "mph_StoreCode_IN_"].ToString().Length > 0)
        {
          if (hashtable[(object) "mph_StoreCode_IN_"].ToString().Contains(","))
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "mph_StoreCode", hashtable[(object) "mph_StoreCode_IN_"]));
          else
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mph_StoreCode", hashtable[(object) "mph_StoreCode_IN_"]));
        }
        else if (hashtable.ContainsKey((object) "_STORE_AUTHS_") && !string.IsNullOrEmpty(hashtable[(object) "_STORE_AUTHS_"].ToString()))
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "mph_StoreCode", hashtable[(object) "_STORE_AUTHS_"]));
        if (hashtable.ContainsKey((object) "mph_PointType") && Convert.ToInt32(hashtable[(object) "mph_PointType"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mph_PointType", hashtable[(object) "mph_PointType"]));
        if (hashtable.ContainsKey((object) "mph_SaleDate_BEGIN_") && !string.IsNullOrEmpty(hashtable[(object) "mph_SaleDate_BEGIN_"].ToString()) && hashtable.ContainsKey((object) "mph_SaleDate_END_") && !string.IsNullOrEmpty(hashtable[(object) "mph_SaleDate_END_"].ToString()))
          stringBuilder.Append(" AND mph_SaleDate<=" + new DateTime?((DateTime) hashtable[(object) "mph_SaleDate_BEGIN_"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + " AND mph_SaleDate>=" + new DateTime?((DateTime) hashtable[(object) "mph_SaleDate_END_"]).GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'"));
        if (hashtable.ContainsKey((object) "mph_PosNo") && Convert.ToInt32(hashtable[(object) "mph_PosNo"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mph_PosNo", hashtable[(object) "mph_PosNo"]));
        if (hashtable.ContainsKey((object) "mph_TransNo") && Convert.ToInt32(hashtable[(object) "mph_TransNo"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mph_TransNo", hashtable[(object) "mph_TransNo"]));
        if (hashtable.ContainsKey((object) "mph_MemberCardNo") && !string.IsNullOrEmpty(hashtable[(object) "mph_MemberCardNo"].ToString()))
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "mph_MemberCardNo", hashtable[(object) "mph_MemberCardNo"]));
        if (hashtable.ContainsKey((object) "mph_SaleType") && Convert.ToInt32(hashtable[(object) "mph_SaleType"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mph_SaleType", hashtable[(object) "mph_SaleType"]));
        if (hashtable.ContainsKey((object) "mph_ExtinctionDate_BEGIN_") && !string.IsNullOrEmpty(hashtable[(object) "mph_ExtinctionDate_BEGIN_"].ToString()) && hashtable.ContainsKey((object) "mph_ExtinctionDate_END_") && !string.IsNullOrEmpty(hashtable[(object) "mph_ExtinctionDate_END_"].ToString()))
          stringBuilder.Append(" AND mph_ExtinctionDate<=" + new DateTime?((DateTime) hashtable[(object) "mph_ExtinctionDate_BEGIN_"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + " AND mph_ExtinctionDate>=" + new DateTime?((DateTime) hashtable[(object) "mph_ExtinctionDate_END_"]).GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'"));
        if (hashtable.ContainsKey((object) "mph_TransmitYn") && !string.IsNullOrEmpty(hashtable[(object) "mph_TransmitYn"].ToString()))
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "mph_TransmitYn", hashtable[(object) "mph_TransmitYn"]));
        if (hashtable.ContainsKey((object) "mph_TransmitDate_BEGIN_") && !string.IsNullOrEmpty(hashtable[(object) "mph_TransmitDate_BEGIN_"].ToString()) && hashtable.ContainsKey((object) "mph_TransmitDate_END_") && !string.IsNullOrEmpty(hashtable[(object) "mph_TransmitDate_END_"].ToString()))
          stringBuilder.Append(" AND mph_TransmitDate<=" + new DateTime?((DateTime) hashtable[(object) "mph_TransmitDate_BEGIN_"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + " AND mph_TransmitDate>=" + new DateTime?((DateTime) hashtable[(object) "mph_TransmitDate_END_"]).GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'"));
        if (hashtable.ContainsKey((object) "mph_InputDate_BEGIN_") && !string.IsNullOrEmpty(hashtable[(object) "mph_InputDate_BEGIN_"].ToString()) && hashtable.ContainsKey((object) "mph_InputDate_END_") && !string.IsNullOrEmpty(hashtable[(object) "mph_InputDate_END_"].ToString()))
          stringBuilder.Append(" AND mph_InputDate<=" + new DateTime?((DateTime) hashtable[(object) "mph_InputDate_BEGIN_"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + " AND mph_InputDate>=" + new DateTime?((DateTime) hashtable[(object) "mph_InputDate_END_"]).GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'"));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && !string.IsNullOrEmpty(hashtable[(object) "_KEY_WORD_"].ToString()))
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "mph_MemberCardNo", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "mph_Memo", hashtable[(object) "_KEY_WORD_"]));
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
        string uniMembers = UbModelBase.UNI_MEMBERS;
        string str = this.TableCode.ToString();
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniMembers = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
        }
        stringBuilder.Append(" SELECT  mph_Seq,mph_SiteID,mph_SysDate,mph_MemberNo,mph_StoreCode,mph_PointType,mph_SaleDate,mph_PosNo,mph_TransNo,mph_MemberCardNo,mph_SaleType,mph_SaleAmt,mph_TodayAddPoint,mph_TodayUsePoint,mph_TotalPoint,mph_UsePoint,mph_UsablePoint,mph_Memo,mph_ExtinctionDate,mph_TransmitYn,mph_TransmitDate,mph_InputDate,mph_InDate,mph_InUser,mph_ModDate,mph_ModUser");
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
