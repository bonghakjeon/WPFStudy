// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniCampaign.CampaignInfo.Promotion.TPromotion
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

namespace UniBiz.Bo.Models.UniCampaign.CampaignInfo.Promotion
{
  public class TPromotion : UbModelBase<TPromotion>
  {
    private long _pm_PromotionCode;
    private long _pm_SiteID;
    private string _pm_PromotionName;
    private string _pm_PromotionDesc;
    private int _pm_PromotionKind;
    private int _pm_PromotionType;
    private int _pm_PromotionDiv;
    private int _pm_TargetGroup;
    private double _pm_DcValue;
    private string _pm_MixYn;
    private int _pm_MixOperator;
    private int _pm_MixQty;
    private int _pm_ApplyDiv;
    private int _pm_ApplyPackQty;
    private int _pm_ApplyMinQty;
    private int _pm_ApplyMaxQty;
    private double _pm_ApplyMinAmt;
    private double _pm_ApplyMaxAmt;
    private string _pm_ApplyAllYn;
    private int _pm_EventReceiptID;
    private DateTime? _pm_StartDate;
    private string _pm_StartTime;
    private DateTime? _pm_EndDate;
    private string _pm_EndTime;
    private string _pm_SunYn;
    private string _pm_MonYn;
    private string _pm_TueYn;
    private string _pm_WedYn;
    private string _pm_ThuYn;
    private string _pm_FriYn;
    private string _pm_SatYn;
    private string _pm_DuplicationYn;
    private DateTime? _pm_InDate;
    private int _pm_InUser;
    private DateTime? _pm_ModDate;
    private int _pm_ModUser;

    public override object _Key => (object) new object[1]
    {
      (object) this.pm_PromotionCode
    };

    public long pm_PromotionCode
    {
      get => this._pm_PromotionCode;
      set
      {
        this._pm_PromotionCode = value;
        this.Changed(nameof (pm_PromotionCode));
      }
    }

    public long pm_SiteID
    {
      get => this._pm_SiteID;
      set
      {
        this._pm_SiteID = value;
        this.Changed(nameof (pm_SiteID));
      }
    }

    public string pm_PromotionName
    {
      get => this._pm_PromotionName;
      set
      {
        this._pm_PromotionName = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (pm_PromotionName));
      }
    }

    public string pm_PromotionDesc
    {
      get => this._pm_PromotionDesc;
      set
      {
        this._pm_PromotionDesc = UbModelBase.LeftStr(value, 500).Replace("'", "´");
        this.Changed(nameof (pm_PromotionDesc));
      }
    }

    public int pm_PromotionKind
    {
      get => this._pm_PromotionKind;
      set
      {
        this._pm_PromotionKind = value;
        this.Changed(nameof (pm_PromotionKind));
        this.Changed("pm_PromotionKindDesc");
      }
    }

    public string pm_PromotionKindDesc => this.pm_PromotionKind != 0 ? Enum2StrConverter.ToPromotionKind(this.pm_PromotionKind).ToDescription() : string.Empty;

    public int pm_PromotionType
    {
      get => this._pm_PromotionType;
      set
      {
        this._pm_PromotionType = value;
        this.Changed(nameof (pm_PromotionType));
        this.Changed("pm_PromotionTypeDesc");
      }
    }

    public string pm_PromotionTypeDesc => this.pm_PromotionType != 0 ? Enum2StrConverter.ToPromotionType(this.pm_PromotionKind).ToDescription() : string.Empty;

    public int pm_PromotionDiv
    {
      get => this._pm_PromotionDiv;
      set
      {
        this._pm_PromotionDiv = value;
        this.Changed(nameof (pm_PromotionDiv));
        this.Changed("pm_PromotionDivDesc");
      }
    }

    public string pm_PromotionDivDesc => this.pm_PromotionDiv != 0 ? Enum2StrConverter.ToPromotionDiv(this.pm_PromotionDiv).ToDescription() : string.Empty;

    public int pm_TargetGroup
    {
      get => this._pm_TargetGroup;
      set
      {
        this._pm_TargetGroup = value;
        this.Changed(nameof (pm_TargetGroup));
        this.Changed("pm_TargetGroupDesc");
      }
    }

    public string pm_TargetGroupDesc => this.pm_TargetGroup != 0 ? Enum2StrConverter.ToPromotionTargetGroup(this.pm_TargetGroup).ToDescription() : string.Empty;

    public double pm_DcValue
    {
      get => this._pm_DcValue;
      set
      {
        this._pm_DcValue = value;
        this.Changed(nameof (pm_DcValue));
      }
    }

    public string pm_MixYn
    {
      get => this._pm_MixYn;
      set
      {
        this._pm_MixYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (pm_MixYn));
        this.Changed("pm_IsMix");
      }
    }

    public bool pm_IsMix => "Y".Equals(this.pm_MixYn);

    public int pm_MixOperator
    {
      get => this._pm_MixOperator;
      set
      {
        this._pm_MixOperator = value;
        this.Changed(nameof (pm_MixOperator));
        this.Changed("pm_MixOperatorDesc");
      }
    }

    public string pm_MixOperatorDesc => this.pm_MixOperator != 0 ? Enum2StrConverter.ToOperatorAndOr(this.pm_MixOperator).ToDescription() : string.Empty;

    public int pm_MixQty
    {
      get => this._pm_MixQty;
      set
      {
        this._pm_MixQty = value;
        this.Changed(nameof (pm_MixQty));
      }
    }

    public int pm_ApplyDiv
    {
      get => this._pm_ApplyDiv;
      set
      {
        this._pm_ApplyDiv = value;
        this.Changed(nameof (pm_ApplyDiv));
        this.Changed("pm_ApplyDivDesc");
      }
    }

    public string pm_ApplyDivDesc => this.pm_ApplyDiv != 0 ? Enum2StrConverter.ToApplyDiv(this.pm_ApplyDiv).ToDescription() : string.Empty;

    public int pm_ApplyPackQty
    {
      get => this._pm_ApplyPackQty;
      set
      {
        this._pm_ApplyPackQty = value;
        this.Changed(nameof (pm_ApplyPackQty));
      }
    }

    public int pm_ApplyMinQty
    {
      get => this._pm_ApplyMinQty;
      set
      {
        this._pm_ApplyMinQty = value;
        this.Changed(nameof (pm_ApplyMinQty));
      }
    }

    public int pm_ApplyMaxQty
    {
      get => this._pm_ApplyMaxQty;
      set
      {
        this._pm_ApplyMaxQty = value;
        this.Changed(nameof (pm_ApplyMaxQty));
      }
    }

    public double pm_ApplyMinAmt
    {
      get => this._pm_ApplyMinAmt;
      set
      {
        this._pm_ApplyMinAmt = value;
        this.Changed(nameof (pm_ApplyMinAmt));
      }
    }

    public double pm_ApplyMaxAmt
    {
      get => this._pm_ApplyMaxAmt;
      set
      {
        this._pm_ApplyMaxAmt = value;
        this.Changed(nameof (pm_ApplyMaxAmt));
      }
    }

    public string pm_ApplyAllYn
    {
      get => this._pm_ApplyAllYn;
      set
      {
        this._pm_ApplyAllYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (pm_ApplyAllYn));
        this.Changed("pm_IsApplyAll");
        this.Changed("pm_ApplyAllYnDesc");
      }
    }

    public bool pm_IsApplyAll => "Y".Equals(this.pm_ApplyAllYn);

    public string pm_ApplyAllYnDesc => !"Y".Equals(this.pm_ApplyAllYn) ? "1개만할인" : "모두할인";

    public int pm_EventReceiptID
    {
      get => this._pm_EventReceiptID;
      set
      {
        this._pm_EventReceiptID = value;
        this.Changed(nameof (pm_EventReceiptID));
      }
    }

    public DateTime? pm_StartDate
    {
      get => this._pm_StartDate;
      set
      {
        this._pm_StartDate = value;
        this.Changed(nameof (pm_StartDate));
      }
    }

    public string pm_StartTime
    {
      get => this._pm_StartTime;
      set
      {
        this._pm_StartTime = UbModelBase.LeftStr(value, 4).Replace("'", "´");
        this.Changed(nameof (pm_StartTime));
      }
    }

    public DateTime? pm_EndDate
    {
      get => this._pm_EndDate;
      set
      {
        this._pm_EndDate = value;
        this.Changed(nameof (pm_EndDate));
      }
    }

    public string pm_EndTime
    {
      get => this._pm_EndTime;
      set
      {
        this._pm_EndTime = UbModelBase.LeftStr(value, 4).Replace("'", "´");
        this.Changed(nameof (pm_EndTime));
      }
    }

    public string pm_SunYn
    {
      get => this._pm_SunYn;
      set
      {
        this._pm_SunYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (pm_SunYn));
        this.Changed("pm_IsSun");
        this.Changed("pm_SunYnDesc");
      }
    }

    public bool pm_IsSun => "Y".Equals(this.pm_SunYn);

    public string pm_SunYnDesc => !"Y".Equals(this.pm_SunYn) ? "미사용" : "사용";

    public string pm_MonYn
    {
      get => this._pm_SunYn;
      set
      {
        this._pm_MonYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (pm_MonYn));
        this.Changed("pm_IsMon");
        this.Changed("pm_MonYnDesc");
      }
    }

    public bool pm_IsMon => "Y".Equals(this.pm_MonYn);

    public string pm_MonYnDesc => !"Y".Equals(this.pm_MonYn) ? "미사용" : "사용";

    public string pm_TueYn
    {
      get => this._pm_TueYn;
      set
      {
        this._pm_TueYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (pm_TueYn));
        this.Changed("pm_IsTue");
        this.Changed("pm_TueYnDesc");
      }
    }

    public bool pm_IsTue => "Y".Equals(this.pm_TueYn);

    public string pm_TueYnDesc => !"Y".Equals(this.pm_TueYn) ? "미사용" : "사용";

    public string pm_WedYn
    {
      get => this._pm_WedYn;
      set
      {
        this._pm_WedYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (pm_WedYn));
        this.Changed("pm_IsWed");
        this.Changed("pm_WedYnDesc");
      }
    }

    public bool pm_IsWed => "Y".Equals(this.pm_WedYn);

    public string pm_WedYnDesc => !"Y".Equals(this.pm_WedYn) ? "미사용" : "사용";

    public string pm_ThuYn
    {
      get => this._pm_ThuYn;
      set
      {
        this._pm_ThuYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (pm_ThuYn));
        this.Changed("pm_IsThu");
        this.Changed("pm_ThuYnDesc");
      }
    }

    public bool pm_IsThu => "Y".Equals(this.pm_ThuYn);

    public string pm_ThuYnDesc => !"Y".Equals(this.pm_ThuYn) ? "미사용" : "사용";

    public string pm_FriYn
    {
      get => this._pm_FriYn;
      set
      {
        this._pm_FriYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (pm_FriYn));
        this.Changed("pm_IsFri");
        this.Changed("pm_FriYnDesc");
      }
    }

    public bool pm_IsFri => "Y".Equals(this.pm_FriYn);

    public string pm_FriYnDesc => !"Y".Equals(this.pm_FriYn) ? "미사용" : "사용";

    public string pm_SatYn
    {
      get => this._pm_SatYn;
      set
      {
        this._pm_SatYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (pm_SatYn));
        this.Changed("pm_IsSat");
        this.Changed("pm_SatYnDesc");
      }
    }

    public bool pm_IsSat => "Y".Equals(this.pm_SatYn);

    public string pm_SatYnDesc => !"Y".Equals(this.pm_SatYn) ? "미사용" : "사용";

    public string pm_DuplicationYn
    {
      get => this._pm_DuplicationYn;
      set
      {
        this._pm_DuplicationYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (pm_DuplicationYn));
        this.Changed("pm_IsDuplication");
        this.Changed("pm_DuplicationYnDesc");
      }
    }

    public bool pm_IsDuplication => "Y".Equals(this.pm_DuplicationYn);

    public string pm_DuplicationYnDesc => !"Y".Equals(this.pm_DuplicationYn) ? "미사용" : "사용";

    public DateTime? pm_InDate
    {
      get => this._pm_InDate;
      set
      {
        this._pm_InDate = value;
        this.Changed(nameof (pm_InDate));
      }
    }

    public int pm_InUser
    {
      get => this._pm_InUser;
      set
      {
        this._pm_InUser = value;
        this.Changed(nameof (pm_InUser));
      }
    }

    public DateTime? pm_ModDate
    {
      get => this._pm_ModDate;
      set
      {
        this._pm_ModDate = value;
        this.Changed(nameof (pm_ModDate));
      }
    }

    public int pm_ModUser
    {
      get => this._pm_ModUser;
      set
      {
        this._pm_ModUser = value;
        this.Changed(nameof (pm_ModUser));
      }
    }

    public override DateTime? ModDate => this.pm_ModDate ?? (this.pm_ModDate = this.pm_InDate);

    public TPromotion() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("pm_PromotionCode", new TTableColumn()
      {
        tc_orgin_name = "pm_PromotionCode",
        tc_trans_name = "프로모션코드"
      });
      columnInfo.Add("pm_SiteID", new TTableColumn()
      {
        tc_orgin_name = "pm_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("pm_PromotionName", new TTableColumn()
      {
        tc_orgin_name = "pm_PromotionName",
        tc_trans_name = "프로모션명"
      });
      columnInfo.Add("pm_PromotionDesc", new TTableColumn()
      {
        tc_orgin_name = "pm_PromotionDesc",
        tc_trans_name = "프로모션상세명"
      });
      columnInfo.Add("pm_PromotionKind", new TTableColumn()
      {
        tc_orgin_name = "pm_PromotionKind",
        tc_trans_name = "종류",
        tc_comm_code = 221
      });
      columnInfo.Add("pm_PromotionType", new TTableColumn()
      {
        tc_orgin_name = "pm_PromotionType",
        tc_trans_name = "유형",
        tc_comm_code = 222
      });
      columnInfo.Add("pm_PromotionDiv", new TTableColumn()
      {
        tc_orgin_name = "pm_PromotionDiv",
        tc_trans_name = "구분",
        tc_comm_code = 223
      });
      columnInfo.Add("pm_TargetGroup", new TTableColumn()
      {
        tc_orgin_name = "pm_TargetGroup",
        tc_trans_name = "적용대상",
        tc_comm_code = 224
      });
      columnInfo.Add("pm_DcValue", new TTableColumn()
      {
        tc_orgin_name = "pm_DcValue",
        tc_trans_name = "할인값"
      });
      columnInfo.Add("pm_MixYn", new TTableColumn()
      {
        tc_orgin_name = "pm_MixYn",
        tc_trans_name = "믹스조건"
      });
      columnInfo.Add("pm_MixOperator", new TTableColumn()
      {
        tc_orgin_name = "pm_MixOperator",
        tc_trans_name = "연산자"
      });
      columnInfo.Add("pm_MixQty", new TTableColumn()
      {
        tc_orgin_name = "pm_MixQty",
        tc_trans_name = "믹스수량"
      });
      columnInfo.Add("pm_ApplyDiv", new TTableColumn()
      {
        tc_orgin_name = "pm_ApplyDiv",
        tc_trans_name = "적용체크",
        tc_comm_code = 226
      });
      columnInfo.Add("pm_ApplyPackQty", new TTableColumn()
      {
        tc_orgin_name = "pm_ApplyPackQty",
        tc_trans_name = "적용묶음수량"
      });
      columnInfo.Add("pm_ApplyMinQty", new TTableColumn()
      {
        tc_orgin_name = "pm_ApplyMinQty",
        tc_trans_name = "적용최소수량"
      });
      columnInfo.Add("pm_ApplyMaxQty", new TTableColumn()
      {
        tc_orgin_name = "pm_ApplyMaxQty",
        tc_trans_name = "적용최대수량"
      });
      columnInfo.Add("pm_ApplyMinAmt", new TTableColumn()
      {
        tc_orgin_name = "pm_ApplyMinAmt",
        tc_trans_name = "적용최소금액"
      });
      columnInfo.Add("pm_ApplyMaxAmt", new TTableColumn()
      {
        tc_orgin_name = "pm_ApplyMaxAmt",
        tc_trans_name = "적용최대금액"
      });
      columnInfo.Add("pm_ApplyAllYn", new TTableColumn()
      {
        tc_orgin_name = "pm_ApplyAllYn",
        tc_trans_name = "모두적용"
      });
      columnInfo.Add("pm_EventReceiptID", new TTableColumn()
      {
        tc_orgin_name = "pm_EventReceiptID",
        tc_trans_name = "이벤트영수증ID"
      });
      columnInfo.Add("pm_StartDate", new TTableColumn()
      {
        tc_orgin_name = "pm_StartDate",
        tc_trans_name = "시작일자"
      });
      columnInfo.Add("pm_StartTime", new TTableColumn()
      {
        tc_orgin_name = "pm_StartTime",
        tc_trans_name = "시작시간"
      });
      columnInfo.Add("pm_EndDate", new TTableColumn()
      {
        tc_orgin_name = "pm_EndDate",
        tc_trans_name = "종료일자"
      });
      columnInfo.Add("pm_EndTime", new TTableColumn()
      {
        tc_orgin_name = "pm_EndTime",
        tc_trans_name = "종료시간"
      });
      columnInfo.Add("pm_SunYn", new TTableColumn()
      {
        tc_orgin_name = "pm_SunYn",
        tc_trans_name = "일"
      });
      columnInfo.Add("pm_MonYn", new TTableColumn()
      {
        tc_orgin_name = "pm_MonYn",
        tc_trans_name = "월"
      });
      columnInfo.Add("pm_TueYn", new TTableColumn()
      {
        tc_orgin_name = "pm_TueYn",
        tc_trans_name = "화"
      });
      columnInfo.Add("pm_WedYn", new TTableColumn()
      {
        tc_orgin_name = "pm_WedYn",
        tc_trans_name = "수"
      });
      columnInfo.Add("pm_ThuYn", new TTableColumn()
      {
        tc_orgin_name = "pm_ThuYn",
        tc_trans_name = "목"
      });
      columnInfo.Add("pm_FriYn", new TTableColumn()
      {
        tc_orgin_name = "pm_FriYn",
        tc_trans_name = "금"
      });
      columnInfo.Add("pm_SatYn", new TTableColumn()
      {
        tc_orgin_name = "pm_SatYn",
        tc_trans_name = "토"
      });
      columnInfo.Add("pm_DuplicationYn", new TTableColumn()
      {
        tc_orgin_name = "pm_DuplicationYn",
        tc_trans_name = "중복가능"
      });
      columnInfo.Add("pm_InDate", new TTableColumn()
      {
        tc_orgin_name = "pm_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("pm_InUser", new TTableColumn()
      {
        tc_orgin_name = "pm_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("pm_ModDate", new TTableColumn()
      {
        tc_orgin_name = "pm_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("pm_ModUser", new TTableColumn()
      {
        tc_orgin_name = "pm_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.Promotion;
      this.pm_PromotionCode = 0L;
      this.pm_SiteID = 0L;
      this.pm_PromotionName = this.pm_PromotionDesc = string.Empty;
      this.pm_PromotionKind = 0;
      this.pm_PromotionType = 0;
      this.pm_PromotionDiv = 0;
      this.pm_TargetGroup = 0;
      this.pm_DcValue = 0.0;
      this.pm_MixYn = "N";
      this.pm_MixOperator = 1;
      this.pm_MixQty = 0;
      this.pm_ApplyDiv = 0;
      this.pm_ApplyPackQty = this.pm_ApplyMinQty = this.pm_ApplyMaxQty = 0;
      this.pm_ApplyMinAmt = this.pm_ApplyMaxAmt = 0.0;
      this.pm_ApplyAllYn = "Y";
      this.pm_EventReceiptID = 0;
      this.pm_StartDate = new DateTime?();
      this.pm_StartTime = "0000";
      this.pm_EndDate = new DateTime?();
      this.pm_EndTime = "2359";
      this.pm_SunYn = this.pm_MonYn = this.pm_TueYn = this.pm_WedYn = this.pm_ThuYn = this.pm_FriYn = this.pm_SatYn = "Y";
      this.pm_DuplicationYn = "Y";
      this.pm_InDate = new DateTime?();
      this.pm_InUser = 0;
      this.pm_ModDate = new DateTime?();
      this.pm_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TPromotion();

    public override object Clone()
    {
      TPromotion tpromotion = base.Clone() as TPromotion;
      tpromotion.pm_PromotionCode = this.pm_PromotionCode;
      tpromotion.pm_SiteID = this.pm_SiteID;
      tpromotion.pm_PromotionName = this.pm_PromotionName;
      tpromotion.pm_PromotionDesc = this.pm_PromotionDesc;
      tpromotion.pm_PromotionKind = this.pm_PromotionKind;
      tpromotion.pm_PromotionType = this.pm_PromotionType;
      tpromotion.pm_PromotionDiv = this.pm_PromotionDiv;
      tpromotion.pm_TargetGroup = this.pm_TargetGroup;
      tpromotion.pm_DcValue = this.pm_DcValue;
      tpromotion.pm_MixYn = this.pm_MixYn;
      tpromotion.pm_MixOperator = this.pm_MixOperator;
      tpromotion.pm_MixQty = this.pm_MixQty;
      tpromotion.pm_ApplyDiv = this.pm_ApplyDiv;
      tpromotion.pm_ApplyPackQty = this.pm_ApplyPackQty;
      tpromotion.pm_ApplyMinQty = this.pm_ApplyMinQty;
      tpromotion.pm_ApplyMaxQty = this.pm_ApplyMaxQty;
      tpromotion.pm_ApplyMinAmt = this.pm_ApplyMinAmt;
      tpromotion.pm_ApplyMaxAmt = this.pm_ApplyMaxAmt;
      tpromotion.pm_ApplyAllYn = this.pm_ApplyAllYn;
      tpromotion.pm_EventReceiptID = this.pm_EventReceiptID;
      tpromotion.pm_StartDate = this.pm_StartDate;
      tpromotion.pm_StartTime = this.pm_StartTime;
      tpromotion.pm_EndDate = this.pm_EndDate;
      tpromotion.pm_EndTime = this.pm_EndTime;
      tpromotion.pm_SunYn = this.pm_SunYn;
      tpromotion.pm_MonYn = this.pm_MonYn;
      tpromotion.pm_TueYn = this.pm_TueYn;
      tpromotion.pm_WedYn = this.pm_WedYn;
      tpromotion.pm_ThuYn = this.pm_ThuYn;
      tpromotion.pm_FriYn = this.pm_FriYn;
      tpromotion.pm_SatYn = this.pm_SatYn;
      tpromotion.pm_DuplicationYn = this.pm_DuplicationYn;
      tpromotion.pm_InDate = this.pm_InDate;
      tpromotion.pm_InUser = this.pm_InUser;
      tpromotion.pm_ModDate = this.pm_ModDate;
      tpromotion.pm_ModUser = this.pm_ModUser;
      return (object) tpromotion;
    }

    public void PutData(TPromotion pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.pm_PromotionCode = pSource.pm_PromotionCode;
      this.pm_SiteID = pSource.pm_SiteID;
      this.pm_PromotionName = pSource.pm_PromotionName;
      this.pm_PromotionDesc = pSource.pm_PromotionDesc;
      this.pm_PromotionKind = pSource.pm_PromotionKind;
      this.pm_PromotionType = pSource.pm_PromotionType;
      this.pm_PromotionDiv = pSource.pm_PromotionDiv;
      this.pm_TargetGroup = pSource.pm_TargetGroup;
      this.pm_DcValue = pSource.pm_DcValue;
      this.pm_MixYn = pSource.pm_MixYn;
      this.pm_MixOperator = pSource.pm_MixOperator;
      this.pm_MixQty = pSource.pm_MixQty;
      this.pm_ApplyDiv = pSource.pm_ApplyDiv;
      this.pm_ApplyPackQty = pSource.pm_ApplyPackQty;
      this.pm_ApplyMinQty = pSource.pm_ApplyMinQty;
      this.pm_ApplyMaxQty = pSource.pm_ApplyMaxQty;
      this.pm_ApplyMinAmt = pSource.pm_ApplyMinAmt;
      this.pm_ApplyMaxAmt = pSource.pm_ApplyMaxAmt;
      this.pm_ApplyAllYn = pSource.pm_ApplyAllYn;
      this.pm_EventReceiptID = pSource.pm_EventReceiptID;
      this.pm_StartDate = pSource.pm_StartDate;
      this.pm_StartTime = pSource.pm_StartTime;
      this.pm_EndDate = pSource.pm_EndDate;
      this.pm_EndTime = pSource.pm_EndTime;
      this.pm_SunYn = pSource.pm_SunYn;
      this.pm_MonYn = pSource.pm_MonYn;
      this.pm_TueYn = pSource.pm_TueYn;
      this.pm_WedYn = pSource.pm_WedYn;
      this.pm_ThuYn = pSource.pm_ThuYn;
      this.pm_FriYn = pSource.pm_FriYn;
      this.pm_SatYn = pSource.pm_SatYn;
      this.pm_DuplicationYn = pSource.pm_DuplicationYn;
      this.pm_InDate = pSource.pm_InDate;
      this.pm_InUser = pSource.pm_InUser;
      this.pm_ModDate = pSource.pm_ModDate;
      this.pm_ModUser = pSource.pm_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.pm_PromotionCode = p_rs.GetFieldLong("pm_PromotionCode");
        if (this.pm_PromotionCode == 0L)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.pm_SiteID = p_rs.GetFieldLong("pm_SiteID");
        this.pm_PromotionName = p_rs.GetFieldString("pm_PromotionName");
        this.pm_PromotionDesc = p_rs.GetFieldString("pm_PromotionDesc");
        this.pm_PromotionKind = p_rs.GetFieldInt("pm_PromotionKind");
        this.pm_PromotionType = p_rs.GetFieldInt("pm_PromotionType");
        this.pm_PromotionDiv = p_rs.GetFieldInt("pm_PromotionDiv");
        this.pm_TargetGroup = p_rs.GetFieldInt("pm_TargetGroup");
        this.pm_DcValue = p_rs.GetFieldDouble("pm_DcValue");
        this.pm_MixYn = p_rs.GetFieldString("pm_MixYn");
        this.pm_MixOperator = p_rs.GetFieldInt("pm_MixOperator");
        this.pm_MixQty = p_rs.GetFieldInt("pm_MixQty");
        this.pm_ApplyDiv = p_rs.GetFieldInt("pm_ApplyDiv");
        this.pm_ApplyPackQty = p_rs.GetFieldInt("pm_ApplyPackQty");
        this.pm_ApplyMinQty = p_rs.GetFieldInt("pm_ApplyMinQty");
        this.pm_ApplyMaxQty = p_rs.GetFieldInt("pm_ApplyMaxQty");
        this.pm_ApplyMinAmt = p_rs.GetFieldDouble("pm_ApplyMinAmt");
        this.pm_ApplyMaxAmt = p_rs.GetFieldDouble("pm_ApplyMaxAmt");
        this.pm_ApplyAllYn = p_rs.GetFieldString("pm_ApplyAllYn");
        this.pm_EventReceiptID = p_rs.GetFieldInt("pm_EventReceiptID");
        this.pm_StartDate = p_rs.GetFieldDateTime("pm_StartDate");
        this.pm_StartTime = p_rs.GetFieldString("pm_StartTime");
        this.pm_EndDate = p_rs.GetFieldDateTime("pm_EndDate");
        this.pm_EndTime = p_rs.GetFieldString("pm_EndTime");
        this.pm_SunYn = p_rs.GetFieldString("pm_SunYn");
        this.pm_MonYn = p_rs.GetFieldString("pm_MonYn");
        this.pm_TueYn = p_rs.GetFieldString("pm_TueYn");
        this.pm_WedYn = p_rs.GetFieldString("pm_WedYn");
        this.pm_ThuYn = p_rs.GetFieldString("pm_ThuYn");
        this.pm_FriYn = p_rs.GetFieldString("pm_FriYn");
        this.pm_SatYn = p_rs.GetFieldString("pm_SatYn");
        this.pm_DuplicationYn = p_rs.GetFieldString("pm_DuplicationYn");
        this.pm_InDate = p_rs.GetFieldDateTime("pm_InDate");
        this.pm_InUser = p_rs.GetFieldInt("pm_InUser");
        this.pm_ModDate = p_rs.GetFieldDateTime("pm_ModDate");
        this.pm_ModUser = p_rs.GetFieldInt("pm_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_CAMPANIGN), (object) this.TableCode) + " pm_PromotionCode,pm_SiteID,pm_PromotionName,pm_PromotionDesc,pm_PromotionKind,pm_PromotionType,pm_PromotionDiv,pm_TargetGroup,pm_DcValue,pm_MixYn,pm_MixOperator,pm_MixQty,pm_ApplyDiv,pm_ApplyPackQty,pm_ApplyMinQty,pm_ApplyMaxQty,pm_ApplyMinAmt,pm_ApplyMaxAmt,pm_ApplyAllYn,pm_EventReceiptID,pm_StartDate,pm_StartTime,pm_EndDate,pm_EndTime,pm_SunYn,pm_MonYn,pm_TueYn,pm_WedYn,pm_ThuYn,pm_FriYn,pm_SatYn,pm_DuplicationYn,pm_InDate,pm_InUser,pm_ModDate,pm_ModUser) VALUES ( " + string.Format(" {0}", (object) this.pm_PromotionCode) + string.Format(",{0}", (object) this.pm_SiteID) + ",'" + this.pm_PromotionName + "','" + this.pm_PromotionDesc + "'" + string.Format(",{0},{1},{2},{3}", (object) this.pm_PromotionKind, (object) this.pm_PromotionType, (object) this.pm_PromotionDiv, (object) this.pm_TargetGroup) + "," + this.pm_DcValue.FormatTo("{0:0.0000}") + string.Format(",'{0}',{1},{2},{3}", (object) this.pm_MixYn, (object) this.pm_MixOperator, (object) this.pm_MixQty, (object) this.pm_ApplyDiv) + string.Format(",{0},{1},{2}", (object) this.pm_ApplyPackQty, (object) this.pm_ApplyMinQty, (object) this.pm_ApplyMaxQty) + "," + this.pm_ApplyMinAmt.FormatTo("{0:0.0000}") + "," + this.pm_ApplyMaxAmt.FormatTo("{0:0.0000}") + string.Format(",'{0}',{1}", (object) this.pm_ApplyAllYn, (object) this.pm_EventReceiptID) + "," + this.pm_StartDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + ",'" + this.pm_StartTime + "'," + this.pm_EndDate.GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'") + ",'" + this.pm_EndTime + "','" + this.pm_SunYn + "','" + this.pm_MonYn + "','" + this.pm_TueYn + "','" + this.pm_WedYn + "','" + this.pm_ThuYn + "','" + this.pm_FriYn + "','" + this.pm_SatYn + "','" + this.pm_DuplicationYn + "'" + string.Format(",{0},{1}", (object) this.pm_InDate.GetDateToStrInNull(), (object) this.pm_InUser) + string.Format(",{0},{1}", (object) this.pm_ModDate.GetDateToStrInNull(), (object) this.pm_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.pm_PromotionCode, (object) this.pm_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TPromotion tpromotion = this;
      // ISSUE: reference to a compiler-generated method
      tpromotion.\u003C\u003En__0();
      if (await tpromotion.OleDB.ExecuteAsync(tpromotion.InsertQuery()))
        return true;
      tpromotion.message = " " + tpromotion.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tpromotion.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tpromotion.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tpromotion.pm_PromotionCode, (object) tpromotion.pm_SiteID) + " 내용 : " + tpromotion.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tpromotion.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_CAMPANIGN), (object) this.TableCode) + " pm_PromotionName='" + this.pm_PromotionName + "',pm_PromotionDesc='" + this.pm_PromotionDesc + "'" + string.Format(",{0}={1},{2}={3}", (object) "pm_PromotionKind", (object) this.pm_PromotionKind, (object) "pm_PromotionType", (object) this.pm_PromotionType) + string.Format(",{0}={1},{2}={3}", (object) "pm_PromotionDiv", (object) this.pm_PromotionDiv, (object) "pm_TargetGroup", (object) this.pm_TargetGroup) + ",pm_DcValue=" + this.pm_DcValue.FormatTo("{0:0.0000}") + string.Format(",{0}='{1}',{2}={3}", (object) "pm_MixYn", (object) this.pm_MixYn, (object) "pm_MixOperator", (object) this.pm_MixOperator) + string.Format(",{0}={1},{2}={3}", (object) "pm_MixQty", (object) this.pm_MixQty, (object) "pm_ApplyDiv", (object) this.pm_ApplyDiv) + string.Format(",{0}={1},{2}={3}", (object) "pm_ApplyPackQty", (object) this.pm_ApplyPackQty, (object) "pm_ApplyMinQty", (object) this.pm_ApplyMinQty) + string.Format(",{0}={1}", (object) "pm_ApplyMaxQty", (object) this.pm_ApplyMaxQty) + ",pm_ApplyMinAmt=" + this.pm_ApplyMinAmt.FormatTo("{0:0.0000}") + ",pm_ApplyMaxAmt=" + this.pm_ApplyMaxAmt.FormatTo("{0:0.0000}") + string.Format(",{0}='{1}',{2}={3}", (object) "pm_ApplyAllYn", (object) this.pm_ApplyAllYn, (object) "pm_EventReceiptID", (object) this.pm_EventReceiptID) + ",pm_StartDate=" + this.pm_StartDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + ",pm_StartTime='" + this.pm_StartTime + "',pm_EndDate=" + this.pm_EndDate.GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'") + ",pm_EndTime='" + this.pm_EndTime + "',pm_SunYn='" + this.pm_SunYn + "',pm_MonYn='" + this.pm_MonYn + "',pm_TueYn='" + this.pm_TueYn + "',pm_WedYn='" + this.pm_WedYn + "',pm_ThuYn='" + this.pm_ThuYn + "',pm_FriYn='" + this.pm_FriYn + "',pm_SatYn='" + this.pm_SatYn + "',pm_DuplicationYn='" + this.pm_DuplicationYn + "'" + string.Format(",{0}={1},{2}={3}", (object) "pm_ModDate", (object) this.pm_ModDate.GetDateToStrInNull(), (object) "pm_ModUser", (object) this.pm_ModUser) + string.Format(" WHERE {0}={1}", (object) "pm_PromotionCode", (object) this.pm_PromotionCode) + string.Format(" AND {0}={1}", (object) "pm_SiteID", (object) this.pm_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.pm_PromotionCode, (object) this.pm_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TPromotion tpromotion = this;
      // ISSUE: reference to a compiler-generated method
      tpromotion.\u003C\u003En__1();
      if (await tpromotion.OleDB.ExecuteAsync(tpromotion.UpdateQuery()))
        return true;
      tpromotion.message = " " + tpromotion.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tpromotion.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tpromotion.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tpromotion.pm_PromotionCode, (object) tpromotion.pm_SiteID) + " 내용 : " + tpromotion.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tpromotion.message);
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
      stringBuilder.Append(" pm_PromotionName='" + this.pm_PromotionName + "',pm_PromotionDesc='" + this.pm_PromotionDesc + "'" + string.Format(",{0}={1},{2}={3}", (object) "pm_PromotionKind", (object) this.pm_PromotionKind, (object) "pm_PromotionType", (object) this.pm_PromotionType) + string.Format(",{0}={1},{2}={3}", (object) "pm_PromotionDiv", (object) this.pm_PromotionDiv, (object) "pm_TargetGroup", (object) this.pm_TargetGroup) + ",pm_DcValue=" + this.pm_DcValue.FormatTo("{0:0.0000}") + string.Format(",{0}='{1}',{2}={3}", (object) "pm_MixYn", (object) this.pm_MixYn, (object) "pm_MixOperator", (object) this.pm_MixOperator) + string.Format(",{0}={1},{2}={3}", (object) "pm_MixQty", (object) this.pm_MixQty, (object) "pm_ApplyDiv", (object) this.pm_ApplyDiv) + string.Format(",{0}={1},{2}={3}", (object) "pm_ApplyPackQty", (object) this.pm_ApplyPackQty, (object) "pm_ApplyMinQty", (object) this.pm_ApplyMinQty) + string.Format(",{0}={1}", (object) "pm_ApplyMaxQty", (object) this.pm_ApplyMaxQty) + ",pm_ApplyMinAmt=" + this.pm_ApplyMinAmt.FormatTo("{0:0.0000}") + ",pm_ApplyMaxAmt=" + this.pm_ApplyMaxAmt.FormatTo("{0:0.0000}") + string.Format(",{0}='{1}',{2}={3}", (object) "pm_ApplyAllYn", (object) this.pm_ApplyAllYn, (object) "pm_EventReceiptID", (object) this.pm_EventReceiptID) + ",pm_StartDate=" + this.pm_StartDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + ",pm_StartTime='" + this.pm_StartTime + "',pm_EndDate=" + this.pm_EndDate.GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'") + ",pm_EndTime='" + this.pm_EndTime + "',pm_SunYn='" + this.pm_SunYn + "',pm_MonYn='" + this.pm_MonYn + "',pm_TueYn='" + this.pm_TueYn + "',pm_WedYn='" + this.pm_WedYn + "',pm_ThuYn='" + this.pm_ThuYn + "',pm_FriYn='" + this.pm_FriYn + "',pm_SatYn='" + this.pm_SatYn + "',pm_DuplicationYn='" + this.pm_DuplicationYn + "'" + string.Format(",{0}={1},{2}={3}", (object) "pm_ModDate", (object) this.pm_ModDate.GetDateToStrInNull(), (object) "pm_ModUser", (object) this.pm_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.pm_PromotionCode, (object) this.pm_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TPromotion tpromotion = this;
      // ISSUE: reference to a compiler-generated method
      tpromotion.\u003C\u003En__1();
      if (await tpromotion.OleDB.ExecuteAsync(tpromotion.UpdateExInsertQuery()))
        return true;
      tpromotion.message = " " + tpromotion.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tpromotion.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tpromotion.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tpromotion.pm_PromotionCode, (object) tpromotion.pm_SiteID) + " 내용 : " + tpromotion.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tpromotion.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "pm_SiteID") && Convert.ToInt64(hashtable[(object) "pm_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "pm_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "pm_PromotionCode") && Convert.ToInt64(hashtable[(object) "pm_PromotionCode"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pm_PromotionCode", hashtable[(object) "pm_PromotionCode"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pm_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "pm_PromotionName") && !string.IsNullOrEmpty(hashtable[(object) "pm_PromotionName"].ToString()))
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "pm_PromotionName", hashtable[(object) "pm_PromotionName"]));
        if (hashtable.ContainsKey((object) "pm_PromotionKind") && Convert.ToInt32(hashtable[(object) "pm_PromotionKind"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pm_PromotionKind", hashtable[(object) "pm_PromotionKind"]));
        if (hashtable.ContainsKey((object) "pm_PromotionType") && Convert.ToInt32(hashtable[(object) "pm_PromotionType"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pm_PromotionType", hashtable[(object) "pm_PromotionType"]));
        if (hashtable.ContainsKey((object) "pm_PromotionDiv") && Convert.ToInt32(hashtable[(object) "pm_PromotionDiv"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pm_PromotionDiv", hashtable[(object) "pm_PromotionDiv"]));
        if (hashtable.ContainsKey((object) "pm_TargetGroup") && Convert.ToInt32(hashtable[(object) "pm_TargetGroup"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pm_TargetGroup", hashtable[(object) "pm_TargetGroup"]));
        if (hashtable.ContainsKey((object) "pm_MixYn") && !string.IsNullOrEmpty(hashtable[(object) "pm_MixYn"].ToString()))
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "pm_MixYn", hashtable[(object) "pm_MixYn"]));
        if (hashtable.ContainsKey((object) "pm_MixOperator") && Convert.ToInt32(hashtable[(object) "pm_MixOperator"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pm_MixOperator", hashtable[(object) "pm_MixOperator"]));
        if (hashtable.ContainsKey((object) "pm_ApplyDiv") && Convert.ToInt32(hashtable[(object) "pm_ApplyDiv"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pm_ApplyDiv", hashtable[(object) "pm_ApplyDiv"]));
        if (hashtable.ContainsKey((object) "pm_ApplyAllYn") && !string.IsNullOrEmpty(hashtable[(object) "pm_ApplyAllYn"].ToString()))
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "pm_ApplyAllYn", hashtable[(object) "pm_ApplyAllYn"]));
        if (hashtable.ContainsKey((object) "pm_EventReceiptID") && Convert.ToInt32(hashtable[(object) "pm_EventReceiptID"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pm_EventReceiptID", hashtable[(object) "pm_EventReceiptID"]));
        if (hashtable.ContainsKey((object) "pm_StartDate") && !string.IsNullOrEmpty(hashtable[(object) "pm_StartDate"].ToString()))
          stringBuilder.Append(" AND pm_StartDate<=" + new DateTime?((DateTime) hashtable[(object) "pm_StartDate"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + " AND pm_StartDate>=" + new DateTime?((DateTime) hashtable[(object) "pm_StartDate"]).GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'"));
        if (hashtable.ContainsKey((object) "pm_EndDate") && !string.IsNullOrEmpty(hashtable[(object) "pm_EndDate"].ToString()))
          stringBuilder.Append(" AND pm_EndDate<=" + new DateTime?((DateTime) hashtable[(object) "pm_EndDate"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + " AND pm_EndDate>=" + new DateTime?((DateTime) hashtable[(object) "pm_EndDate"]).GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'"));
        if (hashtable.ContainsKey((object) "_DT_DATE_") && !string.IsNullOrEmpty(hashtable[(object) "_DT_DATE_"].ToString()))
        {
          stringBuilder.Append(" AND pm_StartDate <='" + new DateTime?((DateTime) hashtable[(object) "_DT_DATE_"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND pm_EndDate >='" + new DateTime?((DateTime) hashtable[(object) "_DT_DATE_"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
        }
        if (hashtable.ContainsKey((object) "_DT_START_DATE_") && !string.IsNullOrEmpty(hashtable[(object) "_DT_START_DATE_"].ToString()) && hashtable.ContainsKey((object) "_DT_END_DATE_") && !string.IsNullOrEmpty(hashtable[(object) "_DT_END_DATE_"].ToString()))
        {
          string dateToStr1 = new DateTime?((DateTime) hashtable[(object) "_DT_START_DATE_"]).GetDateToStr("yyyy-MM-dd 00:00:00");
          string dateToStr2 = new DateTime?((DateTime) hashtable[(object) "_DT_START_DATE_"]).GetDateToStr("yyyy-MM-dd 23:59:59");
          string dateToStr3 = new DateTime?((DateTime) hashtable[(object) "_DT_END_DATE_"]).GetDateToStr("yyyy-MM-dd 00:00:00");
          string dateToStr4 = new DateTime?((DateTime) hashtable[(object) "_DT_END_DATE_"]).GetDateToStr("yyyy-MM-dd 23:59:59");
          stringBuilder.Append(" AND (");
          stringBuilder.Append(" (pm_StartDate <= '" + dateToStr1 + "' AND pm_EndDate >= '" + dateToStr2 + "' )");
          stringBuilder.Append(" OR (pm_StartDate <= '" + dateToStr3 + "' AND pm_EndDate >= '" + dateToStr4 + "' )");
          stringBuilder.Append(" OR (pm_StartDate >= '" + dateToStr1 + "' AND pm_EndDate <= '" + dateToStr4 + "' )");
          stringBuilder.Append(") ");
        }
        if (hashtable.ContainsKey((object) "pm_StartTime") && !string.IsNullOrEmpty(hashtable[(object) "pm_StartTime"].ToString()))
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "pm_StartTime", hashtable[(object) "pm_StartTime"]));
        if (hashtable.ContainsKey((object) "pm_EndTime") && !string.IsNullOrEmpty(hashtable[(object) "pm_EndTime"].ToString()))
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "pm_EndTime", hashtable[(object) "pm_EndTime"]));
        if (hashtable.ContainsKey((object) "pm_StartTime_BEGIN_") && !string.IsNullOrEmpty(hashtable[(object) "pm_StartTime_BEGIN_"].ToString()) && hashtable.ContainsKey((object) "pm_EndTime_END_") && !string.IsNullOrEmpty(hashtable[(object) "pm_EndTime_END_"].ToString()))
          stringBuilder.Append(string.Format(" AND {0}>='{1}'", (object) "pm_StartTime", hashtable[(object) "pm_StartTime_BEGIN_"]) + string.Format(" AND {0}<='{1}'", (object) "pm_EndTime", hashtable[(object) "pm_EndTime_END_"]));
        if (hashtable.ContainsKey((object) "pm_SunYn") && !string.IsNullOrEmpty(hashtable[(object) "pm_SunYn"].ToString()))
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "pm_SunYn", hashtable[(object) "pm_SunYn"]));
        if (hashtable.ContainsKey((object) "pm_MonYn") && !string.IsNullOrEmpty(hashtable[(object) "pm_MonYn"].ToString()))
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "pm_MonYn", hashtable[(object) "pm_MonYn"]));
        if (hashtable.ContainsKey((object) "pm_TueYn") && !string.IsNullOrEmpty(hashtable[(object) "pm_TueYn"].ToString()))
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "pm_TueYn", hashtable[(object) "pm_TueYn"]));
        if (hashtable.ContainsKey((object) "pm_WedYn") && !string.IsNullOrEmpty(hashtable[(object) "pm_WedYn"].ToString()))
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "pm_WedYn", hashtable[(object) "pm_WedYn"]));
        if (hashtable.ContainsKey((object) "pm_ThuYn") && !string.IsNullOrEmpty(hashtable[(object) "pm_ThuYn"].ToString()))
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "pm_ThuYn", hashtable[(object) "pm_ThuYn"]));
        if (hashtable.ContainsKey((object) "pm_FriYn") && !string.IsNullOrEmpty(hashtable[(object) "pm_FriYn"].ToString()))
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "pm_FriYn", hashtable[(object) "pm_FriYn"]));
        if (hashtable.ContainsKey((object) "pm_SatYn") && !string.IsNullOrEmpty(hashtable[(object) "pm_SatYn"].ToString()))
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "pm_SatYn", hashtable[(object) "pm_SatYn"]));
        if (hashtable.ContainsKey((object) "pm_DuplicationYn") && !string.IsNullOrEmpty(hashtable[(object) "pm_DuplicationYn"].ToString()))
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "pm_DuplicationYn", hashtable[(object) "pm_DuplicationYn"]));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && !string.IsNullOrEmpty(hashtable[(object) "_KEY_WORD_"].ToString()))
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "pm_PromotionName", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "pm_PromotionDesc", hashtable[(object) "_KEY_WORD_"]));
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
        stringBuilder.Append(" SELECT  pm_PromotionCode,pm_SiteID,pm_PromotionName,pm_PromotionDesc,pm_PromotionKind,pm_PromotionType,pm_PromotionDiv,pm_TargetGroup,pm_DcValue,pm_MixYn,pm_MixOperator,pm_MixQty,pm_ApplyDiv,pm_ApplyPackQty,pm_ApplyMinQty,pm_ApplyMaxQty,pm_ApplyMinAmt,pm_ApplyMaxAmt,pm_ApplyAllYn,pm_EventReceiptID,pm_StartDate,pm_StartTime,pm_EndDate,pm_EndTime,pm_SunYn,pm_MonYn,pm_TueYn,pm_WedYn,pm_ThuYn,pm_FriYn,pm_SatYn,pm_DuplicationYn,pm_InDate,pm_InUser,pm_ModDate,pm_ModUser");
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
