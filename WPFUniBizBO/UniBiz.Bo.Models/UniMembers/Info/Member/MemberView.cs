// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.Info.Member.MemberView
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
using UniBiz.Bo.Models.UniBase.Employee.Employee;
using UniBiz.Bo.Models.UniBase.Store.StoreInfo;
using UniBiz.Bo.Models.UniMembers.Info.MemberCard;
using UniBiz.Bo.Models.UniMembers.Info.MemberTypeHistory;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniMembers.Info.Member
{
  public class MemberView : TMember<MemberView>
  {
    private string _inEmpName;
    private string _modEmpName;
    private string _mbr_RegStoreName;
    private string _mbr_LastVisitStoreName;
    private string _mt_TypeName;
    private string _mt_UseYn;
    private DateTime? _mth_StartDate;
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
    private string _mgd_MemberGradeName;
    private string _mgd_UseYn;
    private string _mg_GroupName;
    private int _mg_GroupDepth;
    private string _mg_UseYn;
    private string _su_SupplierName;
    private string _su_BizNo;
    private string _su_BizName;
    private string _su_BizCeo;
    private string _su_BizType;
    private string _su_BizCategory;
    private int _mbrs_Supplier;
    private int _mbrs_MemberStore;
    private MemberCardView _CardInfo;
    private IList<MemberCardView> _Lt_MemberCard;

    public string inEmpName
    {
      get => this._inEmpName;
      set
      {
        this._inEmpName = value;
        this.Changed(nameof (inEmpName));
      }
    }

    public string modEmpName
    {
      get => this._modEmpName;
      set
      {
        this._modEmpName = value;
        this.Changed(nameof (modEmpName));
      }
    }

    public string mbr_RegStoreName
    {
      get => this._mbr_RegStoreName;
      set
      {
        this._mbr_RegStoreName = value;
        this.Changed(nameof (mbr_RegStoreName));
      }
    }

    public string mbr_LastVisitStoreName
    {
      get => this._mbr_LastVisitStoreName;
      set
      {
        this._mbr_LastVisitStoreName = value;
        this.Changed(nameof (mbr_LastVisitStoreName));
      }
    }

    public string mt_TypeName
    {
      get => this._mt_TypeName;
      set
      {
        this._mt_TypeName = value;
        this.Changed(nameof (mt_TypeName));
      }
    }

    public string mt_UseYn
    {
      get => this._mt_UseYn;
      set
      {
        this._mt_UseYn = value;
        this.Changed(nameof (mt_UseYn));
        this.Changed("mt_IsUse");
        this.Changed("mt_UseYnDesc");
      }
    }

    public bool mt_IsUse => "Y".Equals(this.mt_UseYn);

    public string mt_UseYnDesc => !"Y".Equals(this.mt_UseYn) ? "미사용" : "사용";

    public DateTime? mth_StartDate
    {
      get => this._mth_StartDate;
      set
      {
        this._mth_StartDate = value;
        this.Changed(nameof (mth_StartDate));
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
        this._mth_CreditYn = value;
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
        this._mth_PointAddYn = value;
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

    public string mgd_MemberGradeName
    {
      get => this._mgd_MemberGradeName;
      set
      {
        this._mgd_MemberGradeName = value;
        this.Changed(nameof (mgd_MemberGradeName));
      }
    }

    public string mgd_UseYn
    {
      get => this._mgd_UseYn;
      set
      {
        this._mgd_UseYn = value;
        this.Changed(nameof (mgd_UseYn));
        this.Changed("mgd_IsUse");
        this.Changed("mgd_UseYnDesc");
      }
    }

    public bool mgd_IsUse => "Y".Equals(this.mgd_UseYn);

    public string mgd_UseYnDesc => !"Y".Equals(this.mgd_UseYn) ? "미사용" : "사용";

    public string mg_GroupName
    {
      get => this._mg_GroupName;
      set
      {
        this._mg_GroupName = value;
        this.Changed(nameof (mg_GroupName));
      }
    }

    public int mg_GroupDepth
    {
      get => this._mg_GroupDepth;
      set
      {
        this._mg_GroupDepth = value;
        this.Changed(nameof (mg_GroupDepth));
      }
    }

    public string mg_UseYn
    {
      get => this._mg_UseYn;
      set
      {
        this._mg_UseYn = value;
        this.Changed(nameof (mg_UseYn));
        this.Changed("mg_IsUse");
        this.Changed("mg_UseYnDesc");
      }
    }

    public bool mg_IsUse => "Y".Equals(this.mg_UseYn);

    public string mg_UseYnDesc => !"Y".Equals(this.mg_UseYn) ? "미사용" : "사용";

    public string su_SupplierName
    {
      get => this._su_SupplierName;
      set
      {
        this._su_SupplierName = value;
        this.Changed(nameof (su_SupplierName));
      }
    }

    public string su_BizNo
    {
      get => this._su_BizNo;
      set
      {
        this._su_BizNo = value;
        this.Changed(nameof (su_BizNo));
      }
    }

    public string su_BizName
    {
      get => this._su_BizName;
      set
      {
        this._su_BizName = value;
        this.Changed(nameof (su_BizName));
      }
    }

    public string su_BizCeo
    {
      get => this._su_BizCeo;
      set
      {
        this._su_BizCeo = value;
        this.Changed(nameof (su_BizCeo));
      }
    }

    public string su_BizType
    {
      get => this._su_BizType;
      set
      {
        this._su_BizType = value;
        this.Changed(nameof (su_BizType));
      }
    }

    public string su_BizCategory
    {
      get => this._su_BizCategory;
      set
      {
        this._su_BizCategory = value;
        this.Changed(nameof (su_BizCategory));
      }
    }

    public int mbrs_Supplier
    {
      get => this._mbrs_Supplier;
      set
      {
        this._mbrs_Supplier = value;
        this.Changed(nameof (mbrs_Supplier));
      }
    }

    public int mbrs_MemberStore
    {
      get => this._mbrs_MemberStore;
      set
      {
        this._mbrs_MemberStore = value;
        this.Changed(nameof (mbrs_MemberStore));
      }
    }

    [JsonPropertyName("cardInfo")]
    public MemberCardView CardInfo
    {
      get => this._CardInfo ?? (this._CardInfo = new MemberCardView());
      set
      {
        this._CardInfo = value;
        this.Changed(nameof (CardInfo));
      }
    }

    [JsonPropertyName("lt_MemberCard")]
    public IList<MemberCardView> Lt_MemberCard
    {
      get => this._Lt_MemberCard ?? (this._Lt_MemberCard = (IList<MemberCardView>) new List<MemberCardView>());
      set
      {
        this._Lt_MemberCard = value;
        this.Changed(nameof (Lt_MemberCard));
      }
    }

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("mbr_RegStoreName", new TTableColumn()
      {
        tc_orgin_name = "mbr_RegStoreName",
        tc_trans_name = "등록지점",
        tc_col_status = 1
      });
      columnInfo.Add("mbr_LastVisitStoreName", new TTableColumn()
      {
        tc_orgin_name = "mbr_LastVisitStoreName",
        tc_trans_name = "최근방문지점",
        tc_col_status = 1
      });
      columnInfo.Add("mt_TypeName", new TTableColumn()
      {
        tc_orgin_name = "mt_TypeName",
        tc_trans_name = "회원유형명",
        tc_col_status = 1
      });
      columnInfo.Add("mt_UseYn", new TTableColumn()
      {
        tc_orgin_name = "mt_UseYn",
        tc_trans_name = "사용상태",
        tc_col_status = 1
      });
      columnInfo.Add("mth_StartDate", new TTableColumn()
      {
        tc_orgin_name = "mth_StartDate",
        tc_trans_name = "시작일",
        tc_col_status = 1
      });
      columnInfo.Add("mth_EndDate", new TTableColumn()
      {
        tc_orgin_name = "mth_EndDate",
        tc_trans_name = "종료일",
        tc_col_status = 1
      });
      columnInfo.Add("mth_MemberPrice", new TTableColumn()
      {
        tc_orgin_name = "mth_MemberPrice",
        tc_trans_name = "회원가적용",
        tc_col_status = 1
      });
      columnInfo.Add("mth_CreditYn", new TTableColumn()
      {
        tc_orgin_name = "mth_CreditYn",
        tc_trans_name = "외상가능여부",
        tc_col_status = 1
      });
      columnInfo.Add("mth_PointAddYn", new TTableColumn()
      {
        tc_orgin_name = "mth_PointAddYn",
        tc_trans_name = "적립율사용여부",
        tc_col_status = 1
      });
      columnInfo.Add("mth_EnurySlipRate", new TTableColumn()
      {
        tc_orgin_name = "mth_EnurySlipRate",
        tc_trans_name = "에누리율",
        tc_col_status = 1
      });
      columnInfo.Add("mth_EnurySlipStdAmt", new TTableColumn()
      {
        tc_orgin_name = "mth_EnurySlipStdAmt",
        tc_trans_name = "에누리최소금액",
        tc_col_status = 1
      });
      columnInfo.Add("mth_PointRateCash", new TTableColumn()
      {
        tc_orgin_name = "mth_PointRateCash",
        tc_trans_name = "현금적립율",
        tc_col_status = 1
      });
      columnInfo.Add("mth_PointRateCard", new TTableColumn()
      {
        tc_orgin_name = "mth_PointRateCard",
        tc_trans_name = "카드적립율",
        tc_col_status = 1
      });
      columnInfo.Add("mth_PointRateInnerGift", new TTableColumn()
      {
        tc_orgin_name = "mth_PointRateInnerGift",
        tc_trans_name = "자사상품권적립율",
        tc_col_status = 1
      });
      columnInfo.Add("mth_PointRateOuterGift", new TTableColumn()
      {
        tc_orgin_name = "mth_PointRateOuterGift",
        tc_trans_name = "타사상품권적립율",
        tc_col_status = 1
      });
      columnInfo.Add("mth_PointRatePoint", new TTableColumn()
      {
        tc_orgin_name = "mth_PointRatePoint",
        tc_trans_name = "포인트사용적립율",
        tc_col_status = 1
      });
      columnInfo.Add("mth_PointRateCredit", new TTableColumn()
      {
        tc_orgin_name = "mth_PointRateCredit",
        tc_trans_name = "외상적립율",
        tc_col_status = 1
      });
      columnInfo.Add("mth_PointRateSocial", new TTableColumn()
      {
        tc_orgin_name = "mth_PointRateSocial",
        tc_trans_name = "소셜/Pay적립율",
        tc_col_status = 1
      });
      columnInfo.Add("mth_PointRateEtc", new TTableColumn()
      {
        tc_orgin_name = "mth_PointRateEtc",
        tc_trans_name = "기타적립율",
        tc_col_status = 1
      });
      columnInfo.Add("mgd_MemberGradeName", new TTableColumn()
      {
        tc_orgin_name = "mgd_MemberGradeName",
        tc_trans_name = "회원등급명",
        tc_col_status = 1
      });
      columnInfo.Add("mgd_UseYn", new TTableColumn()
      {
        tc_orgin_name = "mgd_UseYn",
        tc_trans_name = "사용구분",
        tc_col_status = 1
      });
      columnInfo.Add("mg_GroupName", new TTableColumn()
      {
        tc_orgin_name = "mg_GroupName",
        tc_trans_name = "명칭",
        tc_col_status = 1
      });
      columnInfo.Add("mg_GroupDepth", new TTableColumn()
      {
        tc_orgin_name = "mg_GroupDepth",
        tc_trans_name = "단계(대/중)",
        tc_col_status = 1
      });
      columnInfo.Add("mg_UseYn", new TTableColumn()
      {
        tc_orgin_name = "mg_UseYn",
        tc_trans_name = "사용구분",
        tc_col_status = 1
      });
      columnInfo.Add("mbrs_Supplier", new TTableColumn()
      {
        tc_orgin_name = "mbrs_Supplier",
        tc_trans_name = "업체코드",
        tc_col_status = 1
      });
      columnInfo.Add("mbrs_MemberStore", new TTableColumn()
      {
        tc_orgin_name = "mbrs_MemberStore",
        tc_trans_name = "포인트지점코드",
        tc_col_status = 1
      });
      columnInfo.Add("su_SupplierName", new TTableColumn()
      {
        tc_orgin_name = "su_SupplierName",
        tc_trans_name = "업체명",
        tc_col_status = 1
      });
      columnInfo.Add("su_BizNo", new TTableColumn()
      {
        tc_orgin_name = "su_BizNo",
        tc_trans_name = "사업자번호",
        tc_col_status = 1
      });
      columnInfo.Add("su_BizName", new TTableColumn()
      {
        tc_orgin_name = "su_BizName",
        tc_trans_name = "사업자명",
        tc_col_status = 1
      });
      columnInfo.Add("su_BizCeo", new TTableColumn()
      {
        tc_orgin_name = "su_BizCeo",
        tc_trans_name = "대표자",
        tc_col_status = 1
      });
      columnInfo.Add("su_BizType", new TTableColumn()
      {
        tc_orgin_name = "su_BizType",
        tc_trans_name = "업태",
        tc_col_status = 1
      });
      columnInfo.Add("su_BizCategory", new TTableColumn()
      {
        tc_orgin_name = "su_BizCategory",
        tc_trans_name = "업종",
        tc_col_status = 1
      });
      columnInfo.Add("inEmpName", new TTableColumn()
      {
        tc_orgin_name = "inEmpName",
        tc_trans_name = "등록사원",
        tc_col_status = 1
      });
      columnInfo.Add("modEmpName", new TTableColumn()
      {
        tc_orgin_name = "modEmpName",
        tc_trans_name = "수정사원",
        tc_col_status = 1
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.inEmpName = string.Empty;
      this.modEmpName = string.Empty;
      this.mbr_RegStoreName = string.Empty;
      this.mbr_LastVisitStoreName = string.Empty;
      this.mt_TypeName = string.Empty;
      this.mt_UseYn = "Y";
      DateTime? nullable = new DateTime?();
      this.mth_EndDate = nullable;
      this.mth_StartDate = nullable;
      this.mth_MemberPrice = 0;
      this.mth_CreditYn = this.mth_PointAddYn = "Y";
      this.mth_EnurySlipRate = this.mth_EnurySlipStdAmt = this.mth_PointRateCash = this.mth_PointRateCard = this.mth_PointRateInnerGift = 0.0;
      this.mth_PointRateOuterGift = this.mth_PointRatePoint = this.mth_PointRateCredit = this.mth_PointRateSocial = this.mth_PointRateEtc = 0.0;
      this.mgd_MemberGradeName = string.Empty;
      this.mgd_UseYn = "Y";
      this.mg_GroupName = string.Empty;
      this.mg_UseYn = "Y";
      this.mg_GroupDepth = 0;
      this.su_SupplierName = string.Empty;
      this.su_BizNo = string.Empty;
      this.su_BizName = string.Empty;
      this.su_BizCeo = string.Empty;
      this.su_BizType = string.Empty;
      this.su_BizCategory = string.Empty;
      this.mbrs_Supplier = this.mbrs_MemberStore = 0;
      this.CardInfo = (MemberCardView) null;
      this.Lt_MemberCard = (IList<MemberCardView>) null;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new MemberView();

    public override object Clone()
    {
      MemberView memberView = base.Clone() as MemberView;
      memberView.inEmpName = this.inEmpName;
      memberView.modEmpName = this.modEmpName;
      memberView.mbr_RegStoreName = this.mbr_RegStoreName;
      memberView.mbr_LastVisitStoreName = this.mbr_LastVisitStoreName;
      memberView.mt_TypeName = this.mt_TypeName;
      memberView.mt_UseYn = this.mt_UseYn;
      memberView.mth_StartDate = this.mth_StartDate;
      memberView.mth_EndDate = this.mth_EndDate;
      memberView.mth_MemberPrice = this.mth_MemberPrice;
      memberView.mth_CreditYn = this.mth_CreditYn;
      memberView.mth_PointAddYn = this.mth_PointAddYn;
      memberView.mth_EnurySlipRate = this.mth_EnurySlipRate;
      memberView.mth_EnurySlipStdAmt = this.mth_EnurySlipStdAmt;
      memberView.mth_PointRateCash = this.mth_PointRateCash;
      memberView.mth_PointRateCard = this.mth_PointRateCard;
      memberView.mth_PointRateInnerGift = this.mth_PointRateInnerGift;
      memberView.mth_PointRateOuterGift = this.mth_PointRateOuterGift;
      memberView.mth_PointRatePoint = this.mth_PointRatePoint;
      memberView.mth_PointRateCredit = this.mth_PointRateCredit;
      memberView.mth_PointRateSocial = this.mth_PointRateSocial;
      memberView.mth_PointRateEtc = this.mth_PointRateEtc;
      memberView.mgd_MemberGradeName = this.mgd_MemberGradeName;
      memberView.mgd_UseYn = this.mgd_UseYn;
      memberView.mg_GroupName = this.mg_GroupName;
      memberView.mg_UseYn = this.mg_UseYn;
      memberView.mg_GroupDepth = this.mg_GroupDepth;
      memberView.su_SupplierName = this.su_SupplierName;
      memberView.su_BizNo = this.su_BizNo;
      memberView.su_BizName = this.su_BizName;
      memberView.su_BizCeo = this.su_BizCeo;
      memberView.su_BizType = this.su_BizType;
      memberView.su_BizCategory = this.su_BizCategory;
      memberView.mbrs_Supplier = this.mbrs_Supplier;
      memberView.mbrs_MemberStore = this.mbrs_MemberStore;
      memberView.CardInfo = this.CardInfo;
      memberView.Lt_MemberCard = this.Lt_MemberCard;
      return (object) memberView;
    }

    public void PutData(MemberView pSource)
    {
      this.PutData((TMember) pSource);
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
      this.mbr_RegStoreName = pSource.mbr_RegStoreName;
      this.mbr_LastVisitStoreName = pSource.mbr_LastVisitStoreName;
      this.mt_TypeName = pSource.mt_TypeName;
      this.mt_UseYn = pSource.mt_UseYn;
      this.mth_StartDate = pSource.mth_StartDate;
      this.mth_EndDate = pSource.mth_EndDate;
      this.mth_MemberPrice = pSource.mth_MemberPrice;
      this.mth_CreditYn = pSource.mth_CreditYn;
      this.mth_PointAddYn = pSource.mth_PointAddYn;
      this.mth_EnurySlipRate = pSource.mth_EnurySlipRate;
      this.mth_EnurySlipStdAmt = pSource.mth_EnurySlipStdAmt;
      this.mth_PointRateCash = pSource.mth_PointRateCash;
      this.mth_PointRateCard = pSource.mth_PointRateCard;
      this.mth_PointRateInnerGift = pSource.mth_PointRateInnerGift;
      this.mth_PointRateOuterGift = pSource.mth_PointRateOuterGift;
      this.mth_PointRatePoint = pSource.mth_PointRatePoint;
      this.mth_PointRateCredit = pSource.mth_PointRateCredit;
      this.mth_PointRateSocial = pSource.mth_PointRateSocial;
      this.mth_PointRateEtc = pSource.mth_PointRateEtc;
      this.mgd_MemberGradeName = pSource.mgd_MemberGradeName;
      this.mgd_UseYn = pSource.mgd_UseYn;
      this.mg_GroupName = pSource.mg_GroupName;
      this.mg_UseYn = pSource.mg_UseYn;
      this.mg_GroupDepth = pSource.mg_GroupDepth;
      this.su_SupplierName = pSource.su_SupplierName;
      this.su_BizNo = pSource.su_BizNo;
      this.su_BizName = pSource.su_BizName;
      this.su_BizCeo = pSource.su_BizCeo;
      this.su_BizType = pSource.su_BizType;
      this.su_BizCategory = pSource.su_BizCategory;
      this.mbrs_Supplier = pSource.mbrs_Supplier;
      this.mbrs_MemberStore = pSource.mbrs_MemberStore;
      this.CardInfo = (MemberCardView) null;
      if (!string.IsNullOrEmpty(pSource.CardInfo.mbrc_MemberCardNo))
        this.CardInfo.PutData(pSource.CardInfo);
      this.Lt_MemberCard = (IList<MemberCardView>) null;
      if (pSource.Lt_MemberCard.Count <= 0)
        return;
      foreach (MemberCardView pSource1 in (IEnumerable<MemberCardView>) pSource.Lt_MemberCard)
      {
        MemberCardView memberCardView = new MemberCardView();
        memberCardView.PutData(pSource1);
        this.Lt_MemberCard.Add(memberCardView);
      }
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.mbr_SiteID == 0L)
      {
        this.message = "싸이트(mbr_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (string.IsNullOrEmpty(this.mbr_MemberName))
      {
        this.message = "회원명(mbr_MemberName)  " + EnumDataCheck.Empty.ToDescription();
        return EnumDataCheck.Empty;
      }
      if (this.mbr_MemberType == 0)
      {
        this.message = "회원유형(mbr_MemberType)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (Enum2StrConverter.ToMemberStatus(this.mbr_Status) == EnumMemberStatus.NONE)
      {
        this.message = "상태(mbr_Status)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (Enum2StrConverter.ToSmsSendAgree(this.mbr_SmsSendAgree) == EnumSmsSendAgree.NONE)
      {
        this.message = "SMS 허용(mbr_SmsSendAgree)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (Enum2StrConverter.ToGender(this.mbr_Gender) == EnumGender.NONE)
      {
        this.message = "SMS 허용(mbr_Gender)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (Enum2StrConverter.ToMonthCalendarType(this.mbr_BirthType) != EnumMonthCalendarType.NONE)
        return EnumDataCheck.Success;
      this.message = "SMS 허용(mbr_BirthType)  " + EnumDataCheck.CodeZero.ToDescription();
      return EnumDataCheck.CodeZero;
    }

    protected override EnumDataCheck DataCheck(UniOleDatabase p_db) => base.DataCheck(p_db);

    protected override bool IsPermit(EmployeeView p_app_employee)
    {
      if (p_app_employee == null)
      {
        this.message = "사용자 정보 NULL.";
        return false;
      }
      return EnumDataCheck.Success == this.DataCheck(this.OleDB);
    }

    public override string CreateCodeQuery()
    {
      base.CreateCodeQuery();
      return " SELECT " + DbQueryHelper.ToIsNULL() + "(MAX(mbr_MemberNo), 0)+1 AS mbr_MemberNo" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode, (object) DbQueryHelper.ToWithNolock());
    }

    public override bool CreateCode(UniOleDatabase p_db)
    {
      UniOleDbRecordset uniOleDbRecordset = (UniOleDbRecordset) null;
      UniOleDatabase pOleDB = (UniOleDatabase) null;
      try
      {
        pOleDB = new UniOleDatabase(p_db.ConnectionUrl);
        uniOleDbRecordset = new UniOleDbRecordset(pOleDB, pOleDB.CommandTimeout);
        string codeQuery = this.CreateCodeQuery();
        if (!uniOleDbRecordset.Open(codeQuery))
        {
          this.message = " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) pOleDB.LastErrorID) + " 내용 : " + pOleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          return false;
        }
        if (uniOleDbRecordset.IsDataRead())
          this.mbr_MemberNo = uniOleDbRecordset.GetFieldLong(0);
        return this.mbr_MemberNo > 0L;
      }
      finally
      {
        uniOleDbRecordset?.Close();
        pOleDB?.Close();
      }
    }

    public override async Task<bool> CreateCodeAsync(UniOleDatabase p_db)
    {
      MemberView memberView = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(p_db.ConnectionUrl);
        rs = new UniOleDbRecordset(db, db.CommandTimeout);
        if (!await rs.OpenAsync(memberView.CreateCodeQuery()))
        {
          memberView.message = " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + memberView.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) db.LastErrorID) + " 내용 : " + db.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          return false;
        }
        if (await rs.IsDataReadAsync())
          memberView.mbr_MemberNo = rs.GetFieldLong(0);
        return memberView.mbr_MemberNo > 0L;
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    protected bool InsertCards(UniOleDatabase p_db, EmployeeView p_app_employee, bool p_isNew)
    {
      if (p_isNew)
      {
        int count = this.Lt_MemberCard.Count;
      }
      if (this.Lt_MemberCard.Count == 0)
        return true;
      foreach (MemberCardView memberCardView in (IEnumerable<MemberCardView>) this.Lt_MemberCard)
      {
        if (memberCardView.mbrc_SiteID == 0L)
          memberCardView.mbrc_SiteID = this.mbr_SiteID;
        if (memberCardView.mbr_RegStore == 0)
          memberCardView.mbr_RegStore = this.mbr_RegStore;
        if (memberCardView.IsNew)
        {
          memberCardView.mbrc_MemberNo = this.mbr_MemberNo;
          if (!memberCardView.InsertData(p_db, p_app_employee, false))
            throw new UniServiceException(memberCardView.message, memberCardView.TableCode.ToDescription() + " 신규 등록 에러");
        }
        else if (memberCardView.IsUpdate && !memberCardView.UpdateData(p_db, p_app_employee, false))
          throw new UniServiceException(memberCardView.message, memberCardView.TableCode.ToDescription() + " 데이터 변경 에러");
      }
      return true;
    }

    protected async Task<bool> InsertCardsAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_isNew)
    {
      MemberView memberView = this;
      if (p_isNew)
      {
        int count = memberView.Lt_MemberCard.Count;
      }
      if (memberView.Lt_MemberCard.Count == 0)
        return true;
      foreach (MemberCardView card in (IEnumerable<MemberCardView>) memberView.Lt_MemberCard)
      {
        if (card.mbrc_SiteID == 0L)
          card.mbrc_SiteID = memberView.mbr_SiteID;
        if (card.mbr_RegStore == 0)
          card.mbr_RegStore = memberView.mbr_RegStore;
        if (card.IsNew)
        {
          card.mbrc_MemberNo = memberView.mbr_MemberNo;
          if (!await card.InsertDataAsync(p_db, p_app_employee, false))
            throw new UniServiceException(card.message, card.TableCode.ToDescription() + " 신규 등록 에러");
        }
        else if (card.IsUpdate)
        {
          if (!await card.UpdateDataAsync(p_db, p_app_employee, false))
            throw new UniServiceException(card.message, card.TableCode.ToDescription() + " 데이터 변경 에러");
        }
      }
      return true;
    }

    public override bool InsertData(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      try
      {
        this.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != this.DataCheck(p_db))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (this.mbr_SiteID == 0L)
            this.mbr_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (this.mbr_MemberNo == 0L && !this.CreateCode(p_db))
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 코드 생성 오류", 2);
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!this.Insert())
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 등록 오류");
        if (!this.InsertCards(p_db, p_app_employee, true))
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 카드 등록 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        this.db_status = 4;
        this.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        this.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        this.message = ex.Message;
      }
      return false;
    }

    public override async Task<bool> InsertDataAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      MemberView memberView = this;
      try
      {
        memberView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != memberView.DataCheck(p_db))
            throw new UniServiceException(memberView.message, memberView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (memberView.mbr_SiteID == 0L)
            memberView.mbr_SiteID = p_app_employee.emp_SiteID;
          if (!memberView.IsPermit(p_app_employee))
            throw new UniServiceException(memberView.message, memberView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (memberView.mbr_MemberNo == 0L)
        {
          if (!await memberView.CreateCodeAsync(p_db))
            throw new UniServiceException(memberView.message, memberView.TableCode.ToDescription() + " 코드 생성 오류", 2);
        }
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await memberView.InsertAsync())
          throw new UniServiceException(memberView.message, memberView.TableCode.ToDescription() + " 등록 오류");
        if (!await memberView.InsertCardsAsync(p_db, p_app_employee, true))
          throw new UniServiceException(memberView.message, memberView.TableCode.ToDescription() + " 카드 등록 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        memberView.db_status = 4;
        memberView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        memberView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        memberView.message = ex.Message;
      }
      return false;
    }

    public override bool UpdateData(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      try
      {
        this.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != this.DataCheck(p_db))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!this.IsPermit(p_app_employee))
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        if (this.mbr_MemberNo == 0L)
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 회원코드(mbr_MemberNo)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!this.Update())
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 변경 오류");
        if (!this.InsertCards(p_db, p_app_employee, false))
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 카드 등록 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        this.db_status = 4;
        this.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        this.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        this.message = ex.Message;
      }
      return false;
    }

    public override async Task<bool> UpdateDataAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      MemberView memberView = this;
      try
      {
        memberView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != memberView.DataCheck(p_db))
            throw new UniServiceException(memberView.message, memberView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!memberView.IsPermit(p_app_employee))
          throw new UniServiceException(memberView.message, memberView.TableCode.ToDescription() + " 권한 검사 실패");
        if (memberView.mbr_MemberNo == 0L)
          throw new UniServiceException(memberView.message, memberView.TableCode.ToDescription() + " 회원코드(mbr_MemberNo)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await memberView.UpdateAsync())
          throw new UniServiceException(memberView.message, memberView.TableCode.ToDescription() + " 변경 오류");
        if (!await memberView.InsertCardsAsync(p_db, p_app_employee, false))
          throw new UniServiceException(memberView.message, memberView.TableCode.ToDescription() + " 카드 등록 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        memberView.db_status = 4;
        memberView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        memberView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        memberView.message = ex.Message;
      }
      return false;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.inEmpName = p_rs.GetFieldString("inEmpName");
      this.modEmpName = p_rs.GetFieldString("modEmpName");
      this.mbr_RegStoreName = p_rs.GetFieldString("mbr_RegStoreName");
      this.mbr_LastVisitStoreName = p_rs.GetFieldString("mbr_LastVisitStoreName");
      this.mt_TypeName = p_rs.GetFieldString("mt_TypeName");
      this.mt_UseYn = p_rs.GetFieldString("mt_UseYn");
      if (p_rs.IsFieldName("mth_StartDate"))
      {
        this.mth_StartDate = p_rs.GetFieldDateTime("mth_StartDate");
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
      }
      this.mgd_MemberGradeName = p_rs.GetFieldString("mgd_MemberGradeName");
      this.mgd_UseYn = p_rs.GetFieldString("mgd_UseYn");
      this.mg_GroupName = p_rs.GetFieldString("mg_GroupName");
      this.mg_UseYn = p_rs.GetFieldString("mg_UseYn");
      this.mg_GroupDepth = p_rs.GetFieldInt("mg_GroupDepth");
      this.su_SupplierName = p_rs.GetFieldString("su_SupplierName");
      this.su_BizNo = p_rs.GetFieldString("su_BizNo");
      this.su_BizName = p_rs.GetFieldString("su_BizName");
      this.su_BizCeo = p_rs.GetFieldString("su_BizCeo");
      this.su_BizType = p_rs.GetFieldString("su_BizType");
      this.su_BizCategory = p_rs.GetFieldString("su_BizCategory");
      this.mbrs_Supplier = p_rs.GetFieldInt("mbrs_Supplier");
      this.mbrs_MemberStore = p_rs.GetFieldInt("mbrs_MemberStore");
      if (p_rs.IsFieldName("mbrc_MemberCardNo"))
      {
        this.CardInfo.mbrc_MemberNo = this.mbr_MemberNo;
        this.CardInfo.mbrc_MemberCardNo = p_rs.GetFieldString("mbrc_MemberCardNo");
        this.CardInfo.mbrc_SiteID = this.mbr_SiteID;
        this.CardInfo.mbrc_CardType = p_rs.GetFieldInt("mbrc_CardType");
        this.CardInfo.mbrc_Memo = p_rs.GetFieldString("mbrc_Memo");
        this.CardInfo.mbrc_UseYn = p_rs.GetFieldString("mbrc_UseYn");
      }
      return true;
    }

    public async Task<MemberView> SelectOneAsync(long p_mbr_MemberNo, long p_mbr_SiteID = 0)
    {
      MemberView memberView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "mbr_MemberNo",
          (object) p_mbr_MemberNo
        }
      };
      if (p_mbr_SiteID > 0L)
        p_param.Add((object) "mbr_SiteID", (object) p_mbr_SiteID);
      return await memberView.SelectOneTAsync<MemberView>((object) p_param);
    }

    public MemberView SelectOne(long p_mbr_MemberNo, long p_mbr_SiteID = 0)
    {
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "mbr_MemberNo",
          (object) p_mbr_MemberNo
        }
      };
      if (p_mbr_SiteID > 0L)
        p_param.Add((object) "mbr_SiteID", (object) p_mbr_SiteID);
      return this.SelectOneT<MemberView>((object) p_param);
    }

    public async Task<IList<MemberView>> SelectListAsync(object p_param)
    {
      MemberView memberView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(memberView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, memberView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(memberView1.GetSelectQuery(p_param)))
        {
          memberView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + memberView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<MemberView>) null;
        }
        IList<MemberView> lt_list = (IList<MemberView>) new List<MemberView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            MemberView memberView2 = memberView1.OleDB.Create<MemberView>();
            if (memberView2.GetFieldValues(rs))
            {
              memberView2.row_number = lt_list.Count + 1;
              lt_list.Add(memberView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + memberView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<MemberView> SelectEnumerableAsync(object p_param)
    {
      MemberView memberView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(memberView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, memberView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(memberView1.GetSelectQuery(p_param)))
        {
          memberView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + memberView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            MemberView memberView2 = memberView1.OleDB.Create<MemberView>();
            if (memberView2.GetFieldValues(rs))
            {
              memberView2.row_number = ++row_number;
              yield return memberView2;
            }
          }
          while (await rs.IsDataReadAsync());
        }
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public override string GetSelectWhereAnd(object p_param)
    {
      StringBuilder stringBuilder = new StringBuilder(this.GetSelectWhereAnd(p_param, false));
      if (string.IsNullOrWhiteSpace(stringBuilder.ToString()))
        stringBuilder.Append(" WHERE");
      if (p_param is Hashtable hashtable && hashtable.ContainsKey((object) "_KEY_WORD_") && !string.IsNullOrEmpty(hashtable[(object) "_KEY_WORD_"].ToString()))
      {
        stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "mbr_MemberName", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "mbr_TelNo", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "mbr_MobileNo", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "mbr_BizName", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "mbr_BizCeo", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "mbr_AccountName", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(")");
      }
      return !stringBuilder.ToString().Equals(" WHERE") ? stringBuilder.Replace("WHERE AND", "WHERE").ToString() : string.Empty;
    }

    public override string GetSelectQuery(object p_param)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        string uniBase = UbModelBase.UNI_BASE;
        string str = this.TableCode.ToString();
        string empty = string.Empty;
        long num = 0;
        bool flag1 = false;
        bool flag2 = false;
        DateTime? nullable = new DateTime?();
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
          if (hashtable.ContainsKey((object) "_ORDER_BY_COL_") && hashtable[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable.ContainsKey((object) "mbr_SiteID") && Convert.ToInt64(hashtable[(object) "mbr_SiteID"].ToString()) > 0L)
            num = Convert.ToInt64(hashtable[(object) "mbr_SiteID"].ToString());
          if (hashtable.ContainsKey((object) "MemberCard_INCLUDE_") && Convert.ToBoolean(hashtable[(object) "MemberCard_INCLUDE_"].ToString()))
          {
            flag1 = Convert.ToBoolean(hashtable[(object) "MemberCard_INCLUDE_"].ToString());
            if (hashtable.ContainsKey((object) "PERSON_INCLUDE_") && Convert.ToBoolean(hashtable[(object) "PERSON_INCLUDE_"].ToString()))
              flag2 = Convert.ToBoolean(hashtable[(object) "PERSON_INCLUDE_"].ToString());
          }
          if (hashtable.ContainsKey((object) "MemberTypeHistory_DT_DATE_") && !string.IsNullOrEmpty(hashtable[(object) "MemberCard_DT_DATE_"].ToString()))
            nullable = new DateTime?((DateTime) hashtable[(object) "MemberCard_DT_DATE_"]);
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS (\nSELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n,T_EMPLOYEE_MOD AS (\nSELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n,T_STORE_REG AS (\nSELECT si_StoreCode AS reg_si_StoreCode,si_SiteID AS reg_si_SiteID,si_StoreName AS reg_si_StoreName,si_StoreType AS reg_si_StoreType,si_StoreViewCode AS reg_si_StoreViewCode,si_UseYn AS reg_si_UseYn" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("reg_si_MemberMntStore"))
            p_param1.Add((object) "si_MemberMntStore", dictionaryEntry.Value);
        }
        p_param1.Add((object) "si_SiteID", (object) num);
        stringBuilder.Append("\n");
        stringBuilder.Append(new TStoreInfo().GetSelectWhereAnd((object) p_param1));
        stringBuilder.Append(")");
        stringBuilder.Append("\n,T_STORE_LAST_VISIT AS (\nSELECT si_StoreCode AS vis_si_StoreCode,si_SiteID AS vis_si_SiteID,si_StoreName AS vis_si_StoreName,si_StoreType AS vis_si_StoreType,si_StoreViewCode AS vis_si_StoreViewCode,si_UseYn AS vis_si_UseYn" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()) + string.Format("\nWHERE {0}={1}", (object) "si_SiteID", (object) num) + ")");
        if (flag1)
        {
          stringBuilder.Append("\n,T_MEMBER_CARD AS (\nSELECT mbrc_MemberNo,mbrc_MemberCardNo,mbrc_SiteID,mbrc_CardType,mbrc_Memo,mbrc_UseYn" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) TableCodeType.MemberCard, (object) DbQueryHelper.ToWithNolock()));
          p_param1.Clear();
          foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
          {
            if (dictionaryEntry.Key.ToString().Equals("mbr_MemberNo"))
              p_param1.Add((object) "mbrc_MemberNo", dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("mbrc_MemberCardNo"))
              p_param1.Add((object) "mbrc_MemberCardNo", dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("mbrc_CardType") && flag2)
              p_param1.Add((object) "mbrc_CardType", dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("mbrc_UseYn"))
              p_param1.Add((object) "mbrc_UseYn", dictionaryEntry.Value);
            dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
          }
          p_param1.Add((object) "mbrc_SiteID", (object) num);
          if (flag2)
            p_param1.Add((object) "mbrc_CardType", (object) 1);
          stringBuilder.Append("\n");
          stringBuilder.Append(new TMemberCard().GetSelectWhereAnd((object) p_param1));
          stringBuilder.Append(")");
        }
        stringBuilder.Append("\n,T_MEMBER_TYPE AS (\nSELECT mt_TypeCode,mt_SiteID,mt_TypeName,mt_Memo,mt_UseYn" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) TableCodeType.MemberType, (object) DbQueryHelper.ToWithNolock()) + string.Format("\nWHERE {0}={1}", (object) "mt_SiteID", (object) num) + ")");
        if (nullable.HasValue)
        {
          stringBuilder.Append("\n,T_MEMBER_TYPE_HISTORY AS (\nSELECT mth_StoreCode,mth_TypeCode,mth_StartDate,mth_SiteID,mth_EndDate,mth_MemberPrice,mth_CreditYn,mth_EnurySlipRate,mth_EnurySlipStdAmt,mth_PointAddYn,mth_PointRateCash,mth_PointRateCard,mth_PointRateInnerGift,mth_PointRateOuterGift,mth_PointRatePoint,mth_PointRateCredit,mth_PointRateSocial,mth_PointRateEtc" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) TableCodeType.MemberTypeHistory, (object) DbQueryHelper.ToWithNolock()));
          p_param1.Clear();
          foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
          {
            if (dictionaryEntry.Key.ToString().Equals("mth_CreditYn"))
              p_param1.Add((object) "mth_CreditYn", dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("si_MemberMntStore"))
              p_param1.Add((object) "mth_StoreCode", dictionaryEntry.Value);
          }
          p_param1.Add((object) "mth_SiteID", (object) num);
          p_param1.Add((object) "_DT_DATE_", (object) nullable);
          stringBuilder.Append("\n");
          stringBuilder.Append(new TMemberTypeHistory().GetSelectWhereAnd((object) p_param1));
          stringBuilder.Append(")");
        }
        stringBuilder.Append("\n,T_MEMBER_GRADE AS (\nSELECT mgd_MemberGrade,mgd_SiteID,mgd_MemberGradeName,mgd_UseYn" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) TableCodeType.MemberGrade, (object) DbQueryHelper.ToWithNolock()) + string.Format("\nWHERE {0}={1}", (object) "mgd_SiteID", (object) num) + ")");
        stringBuilder.Append("\n,T_MEMBER_GROUP AS (\nSELECT mg_GroupCode,mg_SiteID,mg_GroupName,mg_GroupDepth,mg_UseYn" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) TableCodeType.MemberGroup, (object) DbQueryHelper.ToWithNolock()) + string.Format("\nWHERE {0}={1}", (object) "mg_SiteID", (object) num) + ")");
        stringBuilder.Append("\n,T_MEMBER_SUPPLIER AS (\nSELECT mbrs_MemberNo,mbrs_Supplier,mbrs_MemberStore,mbrs_SiteID\n,su_SupplierName,su_BizNo,su_BizName,su_BizCeo,su_BizType,su_BizCategory" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) TableCodeType.MemberLinkSupplier, (object) DbQueryHelper.ToWithNolock()) + string.Format("\nINNER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Supplier, (object) DbQueryHelper.ToWithNolock()) + " ON mbrs_Supplier=su_Supplier AND mbrs_SiteID=su_SiteID" + string.Format("\nWHERE {0}={1}", (object) "mbrs_SiteID", (object) num) + ")");
        stringBuilder.Append("\nSELECT  mbr_MemberNo,mbr_SiteID,mbr_MemberType,mbr_MemberName,mbr_MemberEngName,mbr_MemberCycle,mbr_MemberGrade,mbr_GroupCode,mbr_Status,mbr_TotalPoint,mbr_UsePoint,mbr_CurrentPoint,mbr_UsablePoint,mbr_ExtinctionPoint,mbr_PreSystemPoint,mbr_PointExtinctionAgree,mbr_PointExtinctionStartDate,mbr_PointUsePassword,mbr_CashReceiptDiv,mbr_CashReceiptAuthNo,mbr_CreditLimitAmt,mbr_CreditAmt,mbr_RegStore,mbr_LastVisitStore,mbr_LastVisitDate,mbr_SmsSendAgree,mbr_SmsFailCnt,mbr_LastSmsSendDate,mbr_ZipCode,mbr_Addr1,mbr_Addr2,mbr_TelNo,mbr_MobileNo,mbr_MobileNoEnc,mbr_Email,mbr_Gender,mbr_BirthType,mbr_Birthday,mbr_Anniversary,mbr_DeliveryZipCode,mbr_DeliveryAddr1,mbr_DeliveryAddr2,mbr_DeliveryRecvName,mbr_DeliveryMobileNoEnc1,mbr_DeliveryMobileNoEnc2,mbr_DeliveryMemo,mbr_PosMsg,mbr_DeliveryMsg,mbr_ExpireDate,mbr_Supplier,mbr_BizNo,mbr_BizName,mbr_BizCeo,mbr_BizType,mbr_BizCategory,mbr_TaxBillYn,mbr_LastTaxBillDate,mbr_TaxBillCycle,mbr_BankCode,mbr_AccountNo,mbr_AccountName,mbr_BuyCycle,mbr_InDate,mbr_InUser,mbr_ModDate,mbr_ModUser\n,inEmpName,modEmpName\n,reg_si_StoreName AS mbr_RegStoreName,vis_si_StoreName AS mbr_LastVisitStoreName\n,mt_TypeName,mt_UseYn");
        if (nullable.HasValue)
          stringBuilder.Append("\n,mth_StartDate,mth_EndDate,mth_MemberPrice,mth_CreditYn,mth_PointAddYn,mth_EnurySlipRate,mth_EnurySlipStdAmt,mth_PointRateCash,mth_PointRateCard,mth_PointRateInnerGift,mth_PointRateOuterGift,mth_PointRatePoint,mth_PointRateCredit,mth_PointRateSocial,mth_PointRateEtc");
        stringBuilder.Append("\n,mgd_MemberGradeName,mgd_UseYn\n,mg_GroupName,mg_UseYn,mg_GroupDepth\n,su_SupplierName,su_BizNo,su_BizName,su_BizCeo,su_BizType,su_BizCategory\n,mbrs_Supplier,mbrs_MemberStore");
        if (flag1)
          stringBuilder.Append("\n,mbrc_MemberNo,mbrc_MemberCardNo,mbrc_CardType,mbrc_Memo,mbrc_UseYn");
        stringBuilder.Append("\nFROM " + DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS) + str + " " + DbQueryHelper.ToWithNolock() + "\nINNER JOIN T_STORE_REG ON mbr_RegStore=reg_si_StoreCode AND mbr_SiteID=reg_si_SiteID\nLEFT OUTER JOIN T_STORE_LAST_VISIT ON mbr_LastVisitStore=vis_si_StoreCode AND mbr_SiteID=vis_si_SiteID\nLEFT OUTER JOIN T_MEMBER_SUPPLIER ON mbr_MemberNo=mbrs_MemberNo AND mbr_SiteID=vis_mbrs_SiteID\nLEFT OUTER JOIN T_MEMBER_TYPE ON mbr_MemberType=mt_TypeCode AND mbr_SiteID=vis_mt_SiteID\nLEFT OUTER JOIN T_MEMBER_GRADE ON mbr_MemberGrade=mgd_MemberGrade AND mbr_SiteID=vis_mgd_SiteID\nLEFT OUTER JOIN T_MEMBER_GROUP ON mbr_GroupCode=mg_GroupCode AND mbr_SiteID=vis_mg_SiteID\nLEFT OUTER JOIN T_EMPLOYEE_IN ON mbr_InUser=emp_CodeIn\nLEFT OUTER JOIN T_EMPLOYEE_MOD ON mbr_ModUser=emp_CodeMod");
        if (flag1)
          stringBuilder.Append("\nINNER JOIN T_MEMBER_CARD ON mbr_MemberNo=mbrc_MemberNo AND mbr_SiteID=mbrc_SiteID");
        if (nullable.HasValue)
          stringBuilder.Append("\nINNER JOIN T_MEMBER_TYPE_HISTORY ON mbr_MemberType=mth_TypeCode AND mbr_SiteID=mth_SiteID");
        if (p_param is Hashtable)
        {
          stringBuilder.Append("\n");
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        }
        if (!string.IsNullOrEmpty(empty))
        {
          stringBuilder.Append("\nORDER BY " + empty);
        }
        else
        {
          stringBuilder.Append("\nORDER BY mbr_MemberNo");
          if (flag1)
            stringBuilder.Append(",mbrc_CardType");
        }
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) ex.GetHashCode()) + " 내용 : " + ex.Message + "\n" + string.Format(" Query : {0}\n", (object) stringBuilder) + "--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
        stringBuilder.Clear();
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }
  }
}
