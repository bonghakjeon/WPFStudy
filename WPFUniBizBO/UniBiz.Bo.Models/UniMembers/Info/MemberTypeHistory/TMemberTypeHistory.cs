// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.Info.MemberTypeHistory.TMemberTypeHistory
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

namespace UniBiz.Bo.Models.UniMembers.Info.MemberTypeHistory
{
  public class TMemberTypeHistory : UbModelBase<TMemberTypeHistory>
  {
    private int _mth_StoreCode;
    private int _mth_TypeCode;
    private DateTime? _mth_StartDate;
    private long _mth_SiteID;
    private DateTime? _mth_EndDate;
    private int _mth_MemberPrice;
    private string _mth_CreditYn;
    private string _mth_PointAddYn;
    private double _mth_EnurySlipRate;
    private double _mth_EnurySlipStdAmt;
    private double _mth_PointRateCash;
    private double _mth_PointRateCard;
    private double _mth_PointRateInnerGift;
    private double _mth_PointRateOuterGift;
    private double _mth_PointRatePoint;
    private double _mth_PointRateCredit;
    private double _mth_PointRateSocial;
    private double _mth_PointRateEtc;
    private DateTime? _mth_InDate;
    private int _mth_InUser;
    private DateTime? _mth_ModDate;
    private int _mth_ModUser;

    public override object _Key => (object) new object[3]
    {
      (object) this.mth_StoreCode,
      (object) this.mth_TypeCode,
      (object) this.mth_StartDate
    };

    public int mth_StoreCode
    {
      get => this._mth_StoreCode;
      set
      {
        this._mth_StoreCode = value;
        this.Changed(nameof (mth_StoreCode));
      }
    }

    public int mth_TypeCode
    {
      get => this._mth_TypeCode;
      set
      {
        this._mth_TypeCode = value;
        this.Changed(nameof (mth_TypeCode));
      }
    }

    public DateTime? mth_StartDate
    {
      get => this._mth_StartDate;
      set
      {
        this._mth_StartDate = value;
        this.Changed(nameof (mth_StartDate));
      }
    }

    [JsonIgnore]
    public int IntStartDate => this.mth_StartDate.HasValue ? Convert.ToInt32(this.mth_StartDate.GetDateToStr("yyyyMMdd")) : 0;

    public long mth_SiteID
    {
      get => this._mth_SiteID;
      set
      {
        this._mth_SiteID = value;
        this.Changed(nameof (mth_SiteID));
      }
    }

    public DateTime? mth_EndDate
    {
      get => this._mth_EndDate;
      set
      {
        this._mth_EndDate = value;
        this.Changed(nameof (mth_EndDate));
      }
    }

    [JsonIgnore]
    public int IntEndDate => this.mth_EndDate.HasValue ? Convert.ToInt32(this.mth_EndDate.GetDateToStr("yyyyMMdd")) : 0;

    public int mth_MemberPrice
    {
      get => this._mth_MemberPrice;
      set
      {
        this._mth_MemberPrice = value;
        this.Changed(nameof (mth_MemberPrice));
      }
    }

    public string mth_CreditYn
    {
      get => this._mth_CreditYn;
      set
      {
        this._mth_CreditYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (mth_CreditYn));
        this.Changed("mth_IsCredit");
        this.Changed("mth_CreditYnDesc");
      }
    }

    public bool mth_IsCredit => "Y".Equals(this.mth_CreditYn);

    public string mth_CreditYnDesc => !"Y".Equals(this.mth_CreditYn) ? "불가" : "가능";

    public string mth_PointAddYn
    {
      get => this._mth_PointAddYn;
      set
      {
        this._mth_PointAddYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (mth_PointAddYn));
        this.Changed("mth_IsPointAdd");
        this.Changed("mth_PointAddYnDesc");
      }
    }

    public bool mth_IsPointAdd => "Y".Equals(this.mth_PointAddYn);

    public string mth_PointAddYnDesc => !"Y".Equals(this.mth_PointAddYn) ? "불가" : "가능";

    public double mth_EnurySlipRate
    {
      get => this._mth_EnurySlipRate;
      set
      {
        this._mth_EnurySlipRate = value;
        this.Changed(nameof (mth_EnurySlipRate));
      }
    }

    public double mth_EnurySlipStdAmt
    {
      get => this._mth_EnurySlipStdAmt;
      set
      {
        this._mth_EnurySlipStdAmt = value;
        this.Changed(nameof (mth_EnurySlipStdAmt));
      }
    }

    public double mth_PointRateCash
    {
      get => this._mth_PointRateCash;
      set
      {
        this._mth_PointRateCash = value;
        this.Changed(nameof (mth_PointRateCash));
      }
    }

    public double mth_PointRateCard
    {
      get => this._mth_PointRateCard;
      set
      {
        this._mth_PointRateCard = value;
        this.Changed(nameof (mth_PointRateCard));
      }
    }

    public double mth_PointRateInnerGift
    {
      get => this._mth_PointRateInnerGift;
      set
      {
        this._mth_PointRateInnerGift = value;
        this.Changed(nameof (mth_PointRateInnerGift));
      }
    }

    public double mth_PointRateOuterGift
    {
      get => this._mth_PointRateOuterGift;
      set
      {
        this._mth_PointRateOuterGift = value;
        this.Changed(nameof (mth_PointRateOuterGift));
      }
    }

    public double mth_PointRatePoint
    {
      get => this._mth_PointRatePoint;
      set
      {
        this._mth_PointRatePoint = value;
        this.Changed(nameof (mth_PointRatePoint));
      }
    }

    public double mth_PointRateCredit
    {
      get => this._mth_PointRateCredit;
      set
      {
        this._mth_PointRateCredit = value;
        this.Changed(nameof (mth_PointRateCredit));
      }
    }

    public double mth_PointRateSocial
    {
      get => this._mth_PointRateSocial;
      set
      {
        this._mth_PointRateSocial = value;
        this.Changed(nameof (mth_PointRateSocial));
      }
    }

    public double mth_PointRateEtc
    {
      get => this._mth_PointRateEtc;
      set
      {
        this._mth_PointRateEtc = value;
        this.Changed(nameof (mth_PointRateEtc));
      }
    }

    public DateTime? mth_InDate
    {
      get => this._mth_InDate;
      set
      {
        this._mth_InDate = value;
        this.Changed(nameof (mth_InDate));
        this.Changed("ModDate");
      }
    }

    public int mth_InUser
    {
      get => this._mth_InUser;
      set
      {
        this._mth_InUser = value;
        this.Changed(nameof (mth_InUser));
      }
    }

    public DateTime? mth_ModDate
    {
      get => this._mth_ModDate;
      set
      {
        this._mth_ModDate = value;
        this.Changed(nameof (mth_ModDate));
        this.Changed("ModDate");
      }
    }

    public int mth_ModUser
    {
      get => this._mth_ModUser;
      set
      {
        this._mth_ModUser = value;
        this.Changed(nameof (mth_ModUser));
      }
    }

    public override DateTime? ModDate => !this.mth_ModDate.HasValue ? this.mth_InDate : this.mth_ModDate;

    public TMemberTypeHistory() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("mth_StoreCode", new TTableColumn()
      {
        tc_orgin_name = "mth_StoreCode",
        tc_trans_name = "지점"
      });
      columnInfo.Add("mth_TypeCode", new TTableColumn()
      {
        tc_orgin_name = "mth_TypeCode",
        tc_trans_name = "회원유형코드"
      });
      columnInfo.Add("mth_StartDate", new TTableColumn()
      {
        tc_orgin_name = "mth_StartDate",
        tc_trans_name = "시작일",
        tc_parents_name = "기간"
      });
      columnInfo.Add("mth_SiteID", new TTableColumn()
      {
        tc_orgin_name = "mth_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("mth_EndDate", new TTableColumn()
      {
        tc_orgin_name = "mth_EndDate",
        tc_trans_name = "종료일",
        tc_parents_name = "기간"
      });
      columnInfo.Add("mth_MemberPrice", new TTableColumn()
      {
        tc_orgin_name = "mth_MemberPrice",
        tc_trans_name = "회원가적용",
        tc_parents_name = "회원가"
      });
      columnInfo.Add("mth_CreditYn", new TTableColumn()
      {
        tc_orgin_name = "mth_CreditYn",
        tc_trans_name = "외상가능여부",
        tc_parents_name = "외상가능"
      });
      columnInfo.Add("mth_PointAddYn", new TTableColumn()
      {
        tc_orgin_name = "mth_PointAddYn",
        tc_trans_name = "적립율사용여부",
        tc_parents_name = "적립율사용"
      });
      columnInfo.Add("mth_EnurySlipRate", new TTableColumn()
      {
        tc_orgin_name = "mth_EnurySlipRate",
        tc_trans_name = "에누리율",
        tc_parents_name = "에누리"
      });
      columnInfo.Add("mth_EnurySlipStdAmt", new TTableColumn()
      {
        tc_orgin_name = "mth_EnurySlipStdAmt",
        tc_trans_name = "에누리최소금액",
        tc_parents_name = "에누리"
      });
      columnInfo.Add("mth_PointRateCash", new TTableColumn()
      {
        tc_orgin_name = "mth_PointRateCash",
        tc_trans_name = "현금적립율",
        tc_parents_name = "적립율"
      });
      columnInfo.Add("mth_PointRateCard", new TTableColumn()
      {
        tc_orgin_name = "mth_PointRateCard",
        tc_trans_name = "카드적립율",
        tc_parents_name = "적립율"
      });
      columnInfo.Add("mth_PointRateInnerGift", new TTableColumn()
      {
        tc_orgin_name = "mth_PointRateInnerGift",
        tc_trans_name = "자사상품권적립율",
        tc_parents_name = "적립율"
      });
      columnInfo.Add("mth_PointRateOuterGift", new TTableColumn()
      {
        tc_orgin_name = "mth_PointRateOuterGift",
        tc_trans_name = "타사상품권적립율",
        tc_parents_name = "적립율"
      });
      columnInfo.Add("mth_PointRatePoint", new TTableColumn()
      {
        tc_orgin_name = "mth_PointRatePoint",
        tc_trans_name = "포인트사용적립율",
        tc_parents_name = "적립율"
      });
      columnInfo.Add("mth_PointRateCredit", new TTableColumn()
      {
        tc_orgin_name = "mth_PointRateCredit",
        tc_trans_name = "외상적립율",
        tc_parents_name = "적립율"
      });
      columnInfo.Add("mth_PointRateSocial", new TTableColumn()
      {
        tc_orgin_name = "mth_PointRateSocial",
        tc_trans_name = "소셜/Pay적립율",
        tc_parents_name = "적립율"
      });
      columnInfo.Add("mth_PointRateEtc", new TTableColumn()
      {
        tc_orgin_name = "mth_PointRateEtc",
        tc_trans_name = "기타적립율",
        tc_parents_name = "적립율"
      });
      columnInfo.Add("mth_InDate", new TTableColumn()
      {
        tc_orgin_name = "mth_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("mth_InUser", new TTableColumn()
      {
        tc_orgin_name = "mth_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("mth_ModDate", new TTableColumn()
      {
        tc_orgin_name = "mth_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("mth_ModUser", new TTableColumn()
      {
        tc_orgin_name = "mth_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.MemberTypeHistory;
      this.mth_StoreCode = this.mth_TypeCode = 0;
      this.mth_StartDate = new DateTime?();
      this.mth_SiteID = 0L;
      this.mth_EndDate = new DateTime?();
      this.mth_MemberPrice = 0;
      this.mth_CreditYn = this.mth_PointAddYn = "Y";
      this.mth_EnurySlipRate = this.mth_EnurySlipStdAmt = this.mth_PointRateCash = this.mth_PointRateCard = this.mth_PointRateInnerGift = 0.0;
      this.mth_PointRateOuterGift = this.mth_PointRatePoint = this.mth_PointRateCredit = this.mth_PointRateSocial = this.mth_PointRateEtc = 0.0;
      this.mth_InDate = new DateTime?();
      this.mth_InUser = 0;
      this.mth_ModDate = new DateTime?();
      this.mth_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TMemberTypeHistory();

    public override object Clone()
    {
      TMemberTypeHistory tmemberTypeHistory = base.Clone() as TMemberTypeHistory;
      tmemberTypeHistory.mth_StoreCode = this.mth_StoreCode;
      tmemberTypeHistory.mth_TypeCode = this.mth_TypeCode;
      tmemberTypeHistory.mth_StartDate = this.mth_StartDate;
      tmemberTypeHistory.mth_SiteID = this.mth_SiteID;
      tmemberTypeHistory.mth_EndDate = this.mth_EndDate;
      tmemberTypeHistory.mth_MemberPrice = this.mth_MemberPrice;
      tmemberTypeHistory.mth_CreditYn = this.mth_CreditYn;
      tmemberTypeHistory.mth_EnurySlipRate = this.mth_EnurySlipRate;
      tmemberTypeHistory.mth_EnurySlipStdAmt = this.mth_EnurySlipStdAmt;
      tmemberTypeHistory.mth_PointAddYn = this.mth_PointAddYn;
      tmemberTypeHistory.mth_PointRateCash = this.mth_PointRateCash;
      tmemberTypeHistory.mth_PointRateCard = this.mth_PointRateCard;
      tmemberTypeHistory.mth_PointRateInnerGift = this.mth_PointRateInnerGift;
      tmemberTypeHistory.mth_PointRateOuterGift = this.mth_PointRateOuterGift;
      tmemberTypeHistory.mth_PointRatePoint = this.mth_PointRatePoint;
      tmemberTypeHistory.mth_PointRateCredit = this.mth_PointRateCredit;
      tmemberTypeHistory.mth_PointRateSocial = this.mth_PointRateSocial;
      tmemberTypeHistory.mth_PointRateEtc = this.mth_PointRateEtc;
      tmemberTypeHistory.mth_InDate = this.mth_InDate;
      tmemberTypeHistory.mth_InUser = this.mth_InUser;
      tmemberTypeHistory.mth_ModDate = this.mth_ModDate;
      tmemberTypeHistory.mth_ModUser = this.mth_ModUser;
      return (object) tmemberTypeHistory;
    }

    public void PutData(TMemberTypeHistory pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.mth_StoreCode = pSource.mth_StoreCode;
      this.mth_TypeCode = pSource.mth_TypeCode;
      this.mth_StartDate = pSource.mth_StartDate;
      this.mth_SiteID = pSource.mth_SiteID;
      this.mth_EndDate = pSource.mth_EndDate;
      this.mth_MemberPrice = pSource.mth_MemberPrice;
      this.mth_CreditYn = pSource.mth_CreditYn;
      this.mth_EnurySlipRate = pSource.mth_EnurySlipRate;
      this.mth_EnurySlipStdAmt = pSource.mth_EnurySlipStdAmt;
      this.mth_PointAddYn = pSource.mth_PointAddYn;
      this.mth_PointRateCash = pSource.mth_PointRateCash;
      this.mth_PointRateCard = pSource.mth_PointRateCard;
      this.mth_PointRateInnerGift = pSource.mth_PointRateInnerGift;
      this.mth_PointRateOuterGift = pSource.mth_PointRateOuterGift;
      this.mth_PointRatePoint = pSource.mth_PointRatePoint;
      this.mth_PointRateCredit = pSource.mth_PointRateCredit;
      this.mth_PointRateSocial = pSource.mth_PointRateSocial;
      this.mth_PointRateEtc = pSource.mth_PointRateEtc;
      this.mth_InDate = pSource.mth_InDate;
      this.mth_InUser = pSource.mth_InUser;
      this.mth_ModDate = pSource.mth_ModDate;
      this.mth_ModUser = pSource.mth_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.mth_StoreCode = p_rs.GetFieldInt("mth_StoreCode");
        if (this.mth_StoreCode == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.mth_TypeCode = p_rs.GetFieldInt("mth_TypeCode");
        this.mth_StartDate = p_rs.GetFieldDateTime("mth_StartDate");
        this.mth_SiteID = p_rs.GetFieldLong("mth_SiteID");
        this.mth_EndDate = p_rs.GetFieldDateTime("mth_EndDate");
        this.mth_MemberPrice = p_rs.GetFieldInt("mth_MemberPrice");
        this.mth_CreditYn = p_rs.GetFieldString("mth_CreditYn");
        this.mth_PointAddYn = p_rs.GetFieldString("mth_PointAddYn");
        this.mth_EnurySlipRate = p_rs.GetFieldDouble("mth_EnurySlipRate");
        this.mth_EnurySlipStdAmt = p_rs.GetFieldDouble("mth_EnurySlipStdAmt");
        this.mth_PointRateCash = p_rs.GetFieldDouble("mth_PointRateCash");
        this.mth_PointRateCard = p_rs.GetFieldDouble("mth_PointRateCard");
        this.mth_PointRateInnerGift = p_rs.GetFieldDouble("mth_PointRateInnerGift");
        this.mth_PointRateOuterGift = p_rs.GetFieldDouble("mth_PointRateOuterGift");
        this.mth_PointRatePoint = p_rs.GetFieldDouble("mth_PointRatePoint");
        this.mth_PointRateCredit = p_rs.GetFieldDouble("mth_PointRateCredit");
        this.mth_PointRateSocial = p_rs.GetFieldDouble("mth_PointRateSocial");
        this.mth_PointRateEtc = p_rs.GetFieldDouble("mth_PointRateEtc");
        this.mth_InDate = p_rs.GetFieldDateTime("mth_InDate");
        this.mth_InUser = p_rs.GetFieldInt("mth_InUser");
        this.mth_ModDate = p_rs.GetFieldDateTime("mth_ModDate");
        this.mth_ModUser = p_rs.GetFieldInt("mth_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode) + " mth_StoreCode,mth_TypeCode,mth_StartDate,mth_SiteID,mth_EndDate,mth_MemberPrice,mth_CreditYn,mth_PointAddYn,mth_EnurySlipRate,mth_EnurySlipStdAmt,mth_PointRateCash,mth_PointRateCard,mth_PointRateInnerGift,mth_PointRateOuterGift,mth_PointRatePoint,mth_PointRateCredit,mth_PointRateSocial,mth_PointRateEtc,mth_InDate,mth_InUser,mth_ModDate,mth_ModUser) VALUES ( " + string.Format(" {0},{1},{2}", (object) this.mth_StoreCode, (object) this.mth_TypeCode, (object) this.mth_StartDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'")) + string.Format(",{0}", (object) this.mth_SiteID) + "," + this.mth_EndDate.GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'") + string.Format(",{0},'{1}','{2}'", (object) this.mth_MemberPrice, (object) this.mth_CreditYn, (object) this.mth_PointAddYn) + "," + this.mth_EnurySlipRate.FormatTo("{0:0.0000}") + "," + this.mth_EnurySlipStdAmt.FormatTo("{0:0.0000}") + "," + this.mth_PointRateCash.FormatTo("{0:0.0000}") + "," + this.mth_PointRateCard.FormatTo("{0:0.0000}") + "," + this.mth_PointRateInnerGift.FormatTo("{0:0.0000}") + "," + this.mth_PointRateOuterGift.FormatTo("{0:0.0000}") + "," + this.mth_PointRatePoint.FormatTo("{0:0.0000}") + "," + this.mth_PointRateCredit.FormatTo("{0:0.0000}") + "," + this.mth_PointRateSocial.FormatTo("{0:0.0000}") + "," + this.mth_PointRateEtc.FormatTo("{0:0.0000}") + string.Format(",{0},{1}", (object) this.mth_InDate.GetDateToStrInNull(), (object) this.mth_InUser) + string.Format(",{0},{1}", (object) this.mth_ModDate.GetDateToStrInNull(), (object) this.mth_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.mth_StoreCode, (object) this.mth_TypeCode, (object) this.mth_StartDate, (object) this.mth_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TMemberTypeHistory tmemberTypeHistory = this;
      // ISSUE: reference to a compiler-generated method
      tmemberTypeHistory.\u003C\u003En__0();
      if (await tmemberTypeHistory.OleDB.ExecuteAsync(tmemberTypeHistory.InsertQuery()))
        return true;
      tmemberTypeHistory.message = " " + tmemberTypeHistory.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberTypeHistory.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberTypeHistory.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tmemberTypeHistory.mth_StoreCode, (object) tmemberTypeHistory.mth_TypeCode, (object) tmemberTypeHistory.mth_StartDate, (object) tmemberTypeHistory.mth_SiteID) + " 내용 : " + tmemberTypeHistory.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberTypeHistory.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode) + " mth_EndDate=" + this.mth_EndDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + string.Format(",{0}={1},{2}='{3}'", (object) "mth_MemberPrice", (object) this.mth_MemberPrice, (object) "mth_CreditYn", (object) this.mth_CreditYn) + ",mth_PointAddYn='" + this.mth_PointAddYn + "',mth_EnurySlipRate=" + this.mth_EnurySlipRate.FormatTo("{0:0.0000}") + ",mth_EnurySlipStdAmt=" + this.mth_EnurySlipStdAmt.FormatTo("{0:0.0000}") + ",mth_PointRateCash=" + this.mth_PointRateCash.FormatTo("{0:0.0000}") + ",mth_PointRateCard=" + this.mth_PointRateCard.FormatTo("{0:0.0000}") + ",mth_PointRateInnerGift=" + this.mth_PointRateInnerGift.FormatTo("{0:0.0000}") + ",mth_PointRateOuterGift=" + this.mth_PointRateOuterGift.FormatTo("{0:0.0000}") + ",mth_PointRatePoint=" + this.mth_PointRatePoint.FormatTo("{0:0.0000}") + ",mth_PointRateCredit=" + this.mth_PointRateCredit.FormatTo("{0:0.0000}") + ",mth_PointRateSocial=" + this.mth_PointRateSocial.FormatTo("{0:0.0000}") + ",mth_PointRateEtc=" + this.mth_PointRateEtc.FormatTo("{0:0.0000}") + ",mth_ModDate=" + this.mth_ModDate.GetDateToStrInNull() + string.Format(",{0}={1}", (object) "mth_ModUser", (object) this.mth_ModUser) + string.Format(" WHERE {0}={1}", (object) "mth_StoreCode", (object) this.mth_StoreCode) + string.Format(" AND {0}={1}", (object) "mth_TypeCode", (object) this.mth_TypeCode) + " AND mth_StartDate=" + this.mth_StartDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + string.Format(" AND {0}={1}", (object) "mth_SiteID", (object) this.mth_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.mth_StoreCode, (object) this.mth_TypeCode, (object) this.mth_StartDate, (object) this.mth_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TMemberTypeHistory tmemberTypeHistory = this;
      // ISSUE: reference to a compiler-generated method
      tmemberTypeHistory.\u003C\u003En__1();
      if (await tmemberTypeHistory.OleDB.ExecuteAsync(tmemberTypeHistory.UpdateQuery()))
        return true;
      tmemberTypeHistory.message = " " + tmemberTypeHistory.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberTypeHistory.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberTypeHistory.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tmemberTypeHistory.mth_StoreCode, (object) tmemberTypeHistory.mth_TypeCode, (object) tmemberTypeHistory.mth_StartDate, (object) tmemberTypeHistory.mth_SiteID) + " 내용 : " + tmemberTypeHistory.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberTypeHistory.message);
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
      stringBuilder.Append(" mth_EndDate=" + this.mth_EndDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + string.Format(",{0}={1},{2}='{3}'", (object) "mth_MemberPrice", (object) this.mth_MemberPrice, (object) "mth_CreditYn", (object) this.mth_CreditYn) + ",mth_PointAddYn='" + this.mth_PointAddYn + "',mth_EnurySlipRate=" + this.mth_EnurySlipRate.FormatTo("{0:0.0000}") + ",mth_EnurySlipStdAmt=" + this.mth_EnurySlipStdAmt.FormatTo("{0:0.0000}") + ",mth_PointRateCash=" + this.mth_PointRateCash.FormatTo("{0:0.0000}") + ",mth_PointRateCard=" + this.mth_PointRateCard.FormatTo("{0:0.0000}") + ",mth_PointRateInnerGift=" + this.mth_PointRateInnerGift.FormatTo("{0:0.0000}") + ",mth_PointRateOuterGift=" + this.mth_PointRateOuterGift.FormatTo("{0:0.0000}") + ",mth_PointRatePoint=" + this.mth_PointRatePoint.FormatTo("{0:0.0000}") + ",mth_PointRateCredit=" + this.mth_PointRateCredit.FormatTo("{0:0.0000}") + ",mth_PointRateSocial=" + this.mth_PointRateSocial.FormatTo("{0:0.0000}") + ",mth_PointRateEtc=" + this.mth_PointRateEtc.FormatTo("{0:0.0000}") + ",mth_ModDate=" + this.mth_ModDate.GetDateToStrInNull() + string.Format(",{0}={1}", (object) "mth_ModUser", (object) this.mth_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.mth_StoreCode, (object) this.mth_TypeCode, (object) this.mth_StartDate, (object) this.mth_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TMemberTypeHistory tmemberTypeHistory = this;
      // ISSUE: reference to a compiler-generated method
      tmemberTypeHistory.\u003C\u003En__1();
      if (await tmemberTypeHistory.OleDB.ExecuteAsync(tmemberTypeHistory.UpdateExInsertQuery()))
        return true;
      tmemberTypeHistory.message = " " + tmemberTypeHistory.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberTypeHistory.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberTypeHistory.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tmemberTypeHistory.mth_StoreCode, (object) tmemberTypeHistory.mth_TypeCode, (object) tmemberTypeHistory.mth_StartDate, (object) tmemberTypeHistory.mth_SiteID) + " 내용 : " + tmemberTypeHistory.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberTypeHistory.message);
      return false;
    }

    public string UpdateEndDateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode) + " mth_EndDate=" + this.mth_EndDate.GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'") + string.Format(",{0}={1},{2}={3}", (object) "mth_ModDate", (object) this.mth_ModDate.GetDateToStrInNull(), (object) "mth_ModUser", (object) this.mth_ModUser) + string.Format(" WHERE {0}={1}", (object) "mth_StoreCode", (object) this.mth_StoreCode) + string.Format(" AND {0}={1}", (object) "mth_TypeCode", (object) this.mth_TypeCode) + " AND mth_StartDate=" + this.mth_StartDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + string.Format(" AND {0}={1}", (object) "mth_SiteID", (object) this.mth_SiteID);

    public bool UpdateEndDate()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateEndDateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.mth_StoreCode, (object) this.mth_TypeCode, (object) this.mth_StartDate, (object) this.mth_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public async Task<bool> UpdateEndDateAsync()
    {
      TMemberTypeHistory tmemberTypeHistory = this;
      // ISSUE: reference to a compiler-generated method
      tmemberTypeHistory.\u003C\u003En__1();
      if (await tmemberTypeHistory.OleDB.ExecuteAsync(tmemberTypeHistory.UpdateEndDateQuery()))
        return true;
      tmemberTypeHistory.message = " " + tmemberTypeHistory.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberTypeHistory.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberTypeHistory.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tmemberTypeHistory.mth_StoreCode, (object) tmemberTypeHistory.mth_TypeCode, (object) tmemberTypeHistory.mth_StartDate, (object) tmemberTypeHistory.mth_SiteID) + " 내용 : " + tmemberTypeHistory.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberTypeHistory.message);
      return false;
    }

    public string UpdateStartDateQuery(
      int p_mth_StoreCode,
      int p_mth_TypeCode,
      DateTime p_mth_StartDate,
      DateTime pModStartDate,
      long p_mth_SiteID = 0)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode));
      stringBuilder.Append(" mth_StartDate=" + new DateTime?(pModStartDate).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'"));
      stringBuilder.Append(",mth_ModDate=" + this.mth_ModDate.GetDateToStrInNull());
      stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "mth_StoreCode", (object) p_mth_StoreCode));
      stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mth_TypeCode", (object) p_mth_TypeCode));
      stringBuilder.Append(" AND mth_StartDate=" + new DateTime?(p_mth_StartDate).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'"));
      if (p_mth_SiteID > 0L)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mth_SiteID", (object) p_mth_SiteID));
      return stringBuilder.ToString();
    }

    public bool UpdateStartDate(
      int p_mth_StoreCode,
      int p_mth_TypeCode,
      DateTime p_mth_StartDate,
      DateTime pModStartDate,
      long p_mth_SiteID = 0)
    {
      this.UpdateChecked();
      this.mth_ModDate = new DateTime?(DateTime.Now);
      if (this.OleDB.Execute(this.UpdateStartDateQuery(p_mth_StoreCode, p_mth_TypeCode, p_mth_StartDate, pModStartDate, p_mth_SiteID)))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2}) => {3},{4})\n", (object) p_mth_StoreCode, (object) p_mth_TypeCode, (object) new DateTime?(p_mth_StartDate).GetDateToStr("yyyy-MM-dd"), (object) new DateTime?(pModStartDate).GetDateToStr("yyyy-MM-dd"), (object) p_mth_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public async Task<bool> UpdateStartDateAsync(
      int p_mth_StoreCode,
      int p_mth_TypeCode,
      DateTime p_mth_StartDate,
      DateTime pModStartDate,
      long p_mth_SiteID = 0)
    {
      TMemberTypeHistory tmemberTypeHistory = this;
      // ISSUE: reference to a compiler-generated method
      tmemberTypeHistory.\u003C\u003En__1();
      tmemberTypeHistory.mth_ModDate = new DateTime?(DateTime.Now);
      if (await tmemberTypeHistory.OleDB.ExecuteAsync(tmemberTypeHistory.UpdateStartDateQuery(p_mth_StoreCode, p_mth_TypeCode, p_mth_StartDate, pModStartDate, p_mth_SiteID)))
        return true;
      tmemberTypeHistory.message = " " + tmemberTypeHistory.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberTypeHistory.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberTypeHistory.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2}) => {3},{4})\n", (object) p_mth_StoreCode, (object) p_mth_TypeCode, (object) new DateTime?(p_mth_StartDate).GetDateToStr("yyyy-MM-dd"), (object) new DateTime?(pModStartDate).GetDateToStr("yyyy-MM-dd"), (object) p_mth_SiteID) + " 내용 : " + tmemberTypeHistory.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberTypeHistory.message);
      return false;
    }

    public override string DeleteQuery() => string.Format(" DELETE FROM {0}{1}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode) + string.Format(" WHERE {0}={1}", (object) "mth_StoreCode", (object) this.mth_StoreCode) + string.Format(" AND {0}={1}", (object) "mth_TypeCode", (object) this.mth_TypeCode) + " AND mth_StartDate=" + this.mth_StartDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + string.Format(" AND {0}={1}", (object) "mth_SiteID", (object) this.mth_SiteID);

    public override bool Delete()
    {
      this.InsertChecked();
      string pStrExec = this.DeleteQuery();
      if (this.OleDB.Execute(pStrExec))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 삭제 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.mth_StoreCode, (object) this.mth_TypeCode, (object) this.mth_StartDate, (object) this.mth_SiteID) + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n 쿼리 : " + pStrExec + "\n--------------------------------------------------------------------------------------------------\n";
      return false;
    }

    public override async Task<bool> DeleteAsync()
    {
      TMemberTypeHistory tmemberTypeHistory = this;
      // ISSUE: reference to a compiler-generated method
      tmemberTypeHistory.\u003C\u003En__0();
      if (await tmemberTypeHistory.OleDB.ExecuteAsync(tmemberTypeHistory.DeleteQuery()))
        return true;
      tmemberTypeHistory.message = " " + tmemberTypeHistory.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberTypeHistory.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberTypeHistory.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tmemberTypeHistory.mth_StoreCode, (object) tmemberTypeHistory.mth_TypeCode, (object) tmemberTypeHistory.mth_StartDate, (object) tmemberTypeHistory.mth_SiteID) + " 내용 : " + tmemberTypeHistory.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberTypeHistory.message);
      return false;
    }

    public virtual string DeleteQuery(
      int p_mth_StoreCode,
      int p_mth_TypeCode,
      DateTime p_mth_StartDate,
      long p_mth_SiteID = 0)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format(" DELETE FROM {0}{1} ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode));
      stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "mth_StoreCode", (object) p_mth_StoreCode));
      stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mth_TypeCode", (object) p_mth_TypeCode));
      stringBuilder.Append(" AND mth_StartDate=" + new DateTime?(p_mth_StartDate).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'"));
      if (p_mth_SiteID > 0L)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mth_SiteID", (object) p_mth_SiteID));
      return stringBuilder.ToString();
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "mth_SiteID") && Convert.ToInt64(hashtable[(object) "mth_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "mth_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "mth_StoreCode") && Convert.ToInt32(hashtable[(object) "mth_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mth_StoreCode", hashtable[(object) "mth_StoreCode"]));
        else if (hashtable.ContainsKey((object) "si_StoreCode") && Convert.ToInt32(hashtable[(object) "si_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mth_StoreCode", hashtable[(object) "si_StoreCode"]));
        else if (hashtable.ContainsKey((object) "si_StoreCode_IN_") && hashtable[(object) "si_StoreCode_IN_"].ToString().Length > 0)
        {
          if (hashtable[(object) "si_StoreCode_IN_"].ToString().Contains(","))
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "mth_StoreCode", hashtable[(object) "si_StoreCode_IN_"]));
          else
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mth_StoreCode", hashtable[(object) "si_StoreCode_IN_"]));
        }
        else if (hashtable.ContainsKey((object) "mth_StoreCode_IN_") && hashtable[(object) "mth_StoreCode_IN_"].ToString().Length > 0)
        {
          if (hashtable[(object) "mth_StoreCode_IN_"].ToString().Contains(","))
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "mth_StoreCode", hashtable[(object) "mth_StoreCode_IN_"]));
          else
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mth_StoreCode", hashtable[(object) "mth_StoreCode_IN_"]));
        }
        else if (hashtable.ContainsKey((object) "_STORE_AUTHS_") && !string.IsNullOrEmpty(hashtable[(object) "_STORE_AUTHS_"].ToString()))
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "mth_StoreCode", hashtable[(object) "_STORE_AUTHS_"]));
        if (hashtable.ContainsKey((object) "mth_TypeCode") && Convert.ToInt32(hashtable[(object) "mth_TypeCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mth_TypeCode", hashtable[(object) "mth_TypeCode"]));
        if (hashtable.ContainsKey((object) "mth_StartDate") && !string.IsNullOrEmpty(hashtable[(object) "mth_StartDate"].ToString()))
          stringBuilder.Append(" AND mth_StartDate<=" + new DateTime?((DateTime) hashtable[(object) "mth_StartDate"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + " AND mth_StartDate>=" + new DateTime?((DateTime) hashtable[(object) "mth_StartDate"]).GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'"));
        if (hashtable.ContainsKey((object) "_DT_DATE_") && !string.IsNullOrEmpty(hashtable[(object) "_DT_DATE_"].ToString()))
        {
          stringBuilder.Append(" AND mth_StartDate <='" + new DateTime?((DateTime) hashtable[(object) "_DT_DATE_"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND mth_EndDate >='" + new DateTime?((DateTime) hashtable[(object) "_DT_DATE_"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
        }
        if (hashtable.ContainsKey((object) "_DT_START_DATE_") && !string.IsNullOrEmpty(hashtable[(object) "_DT_START_DATE_"].ToString()) && hashtable.ContainsKey((object) "_DT_END_DATE_") && !string.IsNullOrEmpty(hashtable[(object) "_DT_END_DATE_"].ToString()))
        {
          string dateToStr1 = new DateTime?((DateTime) hashtable[(object) "_DT_START_DATE_"]).GetDateToStr("yyyy-MM-dd 00:00:00");
          string dateToStr2 = new DateTime?((DateTime) hashtable[(object) "_DT_START_DATE_"]).GetDateToStr("yyyy-MM-dd 23:59:59");
          string dateToStr3 = new DateTime?((DateTime) hashtable[(object) "_DT_END_DATE_"]).GetDateToStr("yyyy-MM-dd 00:00:00");
          string dateToStr4 = new DateTime?((DateTime) hashtable[(object) "_DT_END_DATE_"]).GetDateToStr("yyyy-MM-dd 23:59:59");
          stringBuilder.Append(" AND (");
          stringBuilder.Append(" (mth_StartDate <= '" + dateToStr1 + "' AND mth_EndDate >= '" + dateToStr2 + "' )");
          stringBuilder.Append(" OR (mth_StartDate <= '" + dateToStr3 + "' AND mth_EndDate >= '" + dateToStr4 + "' )");
          stringBuilder.Append(" OR (mth_StartDate >= '" + dateToStr1 + "' AND mth_EndDate <= '" + dateToStr4 + "' )");
          stringBuilder.Append(") ");
        }
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mth_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "mth_CreditYn") && !string.IsNullOrEmpty(hashtable[(object) "mth_CreditYn"].ToString()))
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "mth_CreditYn", hashtable[(object) "mth_CreditYn"]));
        if (hashtable.ContainsKey((object) "mth_PointAddYn") && !string.IsNullOrEmpty(hashtable[(object) "mth_PointAddYn"].ToString()))
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "mth_PointAddYn", hashtable[(object) "mth_PointAddYn"]));
        if (hashtable.ContainsKey((object) "mt_UseYn") && hashtable[(object) "mt_UseYn"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "mt_UseYn", hashtable[(object) "mt_UseYn"]));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "mt_TypeName", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(") ");
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
        stringBuilder.Append(" SELECT  mth_StoreCode,mth_TypeCode,mth_StartDate,mth_SiteID,mth_EndDate,mth_MemberPrice,mth_CreditYn,mth_PointAddYn,mth_EnurySlipRate,mth_EnurySlipStdAmt,mth_PointRateCash,mth_PointRateCard,mth_PointRateInnerGift,mth_PointRateOuterGift,mth_PointRatePoint,mth_PointRateCredit,mth_PointRateSocial,mth_PointRateEtc,mth_InDate,mth_InUser,mth_ModDate,mth_ModUser");
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
