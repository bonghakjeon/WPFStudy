// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.Info.Member.TMember
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

namespace UniBiz.Bo.Models.UniMembers.Info.Member
{
  public class TMember : UbModelBase<TMember>
  {
    private long _mbr_MemberNo;
    private long _mbr_SiteID;
    private string _mbr_MemberName;
    private string _mbr_MemberEngName;
    private int _mbr_MemberType;
    private int _mbr_MemberCycle;
    private int _mbr_MemberGrade;
    private string _mbr_GroupCode;
    private int _mbr_Status;
    private int _mbr_TotalPoint;
    private int _mbr_UsePoint;
    private int _mbr_CurrentPoint;
    private int _mbr_UsablePoint;
    private int _mbr_ExtinctionPoint;
    private int _mbr_PreSystemPoint;
    private int _mbr_PointExtinctionAgree;
    private DateTime? _mbr_PointExtinctionStartDate;
    private string _mbr_PointUsePassword;
    private int _mbr_CashReceiptDiv;
    private string _mbr_CashReceiptAuthNo;
    private double _mbr_CreditLimitAmt;
    private double _mbr_CreditAmt;
    private int _mbr_RegStore;
    private int _mbr_LastVisitStore;
    private DateTime? _mbr_LastVisitDate;
    private int _mbr_SmsSendAgree;
    private int _mbr_SmsFailCnt;
    private DateTime? _mbr_LastSmsSendDate;
    private string _mbr_ZipCode;
    private string _mbr_Addr1;
    private string _mbr_Addr2;
    private string _mbr_TelNo;
    private string _mbr_MobileNo;
    private string _mbr_MobileNoEnc;
    private string _mbr_Email;
    private int _mbr_Gender;
    private int _mbr_BirthType;
    private DateTime? _mbr_Birthday;
    private DateTime? _mbr_Anniversary;
    private string _mbr_DeliveryZipCode;
    private string _mbr_DeliveryAddr1;
    private string _mbr_DeliveryAddr2;
    private string _mbr_DeliveryRecvName;
    private string _mbr_DeliveryMobileNoEnc1;
    private string _mbr_DeliveryMobileNoEnc2;
    private string _mbr_DeliveryMemo;
    private string _mbr_PosMsg;
    private string _mbr_DeliveryMsg;
    private DateTime? _mbr_ExpireDate;
    private int _mbr_Supplier;
    private string _mbr_BizNo;
    private string _mbr_BizName;
    private string _mbr_BizCeo;
    private string _mbr_BizType;
    private string _mbr_BizCategory;
    private string _mbr_TaxBillYn;
    private DateTime? _mbr_LastTaxBillDate;
    private int _mbr_TaxBillCycle;
    private int _mbr_BankCode;
    private string _mbr_AccountNo;
    private string _mbr_AccountName;
    private int _mbr_BuyCycle;
    private DateTime? _mbr_InDate;
    private int _mbr_InUser;
    private DateTime? _mbr_ModDate;
    private int _mbr_ModUser;

    public override object _Key => (object) new object[1]
    {
      (object) this.mbr_MemberNo
    };

    public long mbr_MemberNo
    {
      get => this._mbr_MemberNo;
      set
      {
        this._mbr_MemberNo = value;
        this.Changed(nameof (mbr_MemberNo));
      }
    }

    public long mbr_SiteID
    {
      get => this._mbr_SiteID;
      set
      {
        this._mbr_SiteID = value;
        this.Changed(nameof (mbr_SiteID));
      }
    }

    public string mbr_MemberName
    {
      get => this._mbr_MemberName;
      set
      {
        this._mbr_MemberName = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (mbr_MemberName));
      }
    }

    public string mbr_MemberEngName
    {
      get => this._mbr_MemberEngName;
      set
      {
        this._mbr_MemberEngName = UbModelBase.LeftStr(value, 50).Replace("'", "´");
        this.Changed(nameof (mbr_MemberEngName));
      }
    }

    public int mbr_MemberType
    {
      get => this._mbr_MemberType;
      set
      {
        this._mbr_MemberType = value;
        this.Changed(nameof (mbr_MemberType));
      }
    }

    public int mbr_MemberCycle
    {
      get => this._mbr_MemberCycle;
      set
      {
        this._mbr_MemberCycle = value;
        this.Changed(nameof (mbr_MemberCycle));
        this.Changed("mbr_MemberCycleDesc");
      }
    }

    public string mbr_MemberCycleDesc => this.mbr_MemberCycle != 0 ? Enum2StrConverter.ToMemberCycle(this.mbr_MemberCycle).ToDescription() : string.Empty;

    public int mbr_MemberGrade
    {
      get => this._mbr_MemberGrade;
      set
      {
        this._mbr_MemberGrade = value;
        this.Changed(nameof (mbr_MemberGrade));
      }
    }

    public string mbr_GroupCode
    {
      get => this._mbr_GroupCode;
      set
      {
        this._mbr_GroupCode = UbModelBase.LeftStr(value, 10).Replace("'", "´");
        this.Changed(nameof (mbr_GroupCode));
      }
    }

    public int mbr_Status
    {
      get => this._mbr_Status;
      set
      {
        this._mbr_Status = value;
        this.Changed(nameof (mbr_Status));
        this.Changed("mbr_StatusDesc");
      }
    }

    public string mbr_StatusDesc => this.mbr_Status != 0 ? Enum2StrConverter.ToMemberStatus(this.mbr_Status).ToDescription() : string.Empty;

    public int mbr_TotalPoint
    {
      get => this._mbr_TotalPoint;
      set
      {
        this._mbr_TotalPoint = value;
        this.Changed(nameof (mbr_TotalPoint));
      }
    }

    public int mbr_UsePoint
    {
      get => this._mbr_UsePoint;
      set
      {
        this._mbr_UsePoint = value;
        this.Changed(nameof (mbr_UsePoint));
      }
    }

    public int mbr_CurrentPoint
    {
      get => this._mbr_CurrentPoint;
      set
      {
        this._mbr_CurrentPoint = value;
        this.Changed(nameof (mbr_CurrentPoint));
      }
    }

    public int mbr_UsablePoint
    {
      get => this._mbr_UsablePoint;
      set
      {
        this._mbr_UsablePoint = value;
        this.Changed(nameof (mbr_UsablePoint));
      }
    }

    public int mbr_ExtinctionPoint
    {
      get => this._mbr_ExtinctionPoint;
      set
      {
        this._mbr_ExtinctionPoint = value;
        this.Changed(nameof (mbr_ExtinctionPoint));
      }
    }

    public int mbr_PreSystemPoint
    {
      get => this._mbr_PreSystemPoint;
      set
      {
        this._mbr_PreSystemPoint = value;
        this.Changed(nameof (mbr_PreSystemPoint));
      }
    }

    public int mbr_PointExtinctionAgree
    {
      get => this._mbr_PointExtinctionAgree;
      set
      {
        this._mbr_PointExtinctionAgree = value;
        this.Changed(nameof (mbr_PointExtinctionAgree));
        this.Changed("mbr_PointExtinctionAgreeDesc");
      }
    }

    public string mbr_PointExtinctionAgreeDesc => this.mbr_PointExtinctionAgree != 0 ? Enum2StrConverter.ToMemberPointExtinctionAgree(this.mbr_PointExtinctionAgree).ToDescription() : string.Empty;

    public DateTime? mbr_PointExtinctionStartDate
    {
      get => this._mbr_PointExtinctionStartDate;
      set
      {
        this._mbr_PointExtinctionStartDate = value;
        this.Changed(nameof (mbr_PointExtinctionStartDate));
      }
    }

    public string mbr_PointUsePassword
    {
      get => this._mbr_PointUsePassword;
      set
      {
        this._mbr_PointUsePassword = UbModelBase.LeftStr(value, 200).Replace("'", "´");
        this.Changed(nameof (mbr_PointUsePassword));
      }
    }

    public int mbr_CashReceiptDiv
    {
      get => this._mbr_CashReceiptDiv;
      set
      {
        this._mbr_CashReceiptDiv = value;
        this.Changed(nameof (mbr_CashReceiptDiv));
        this.Changed("mbr_CashReceiptDivDesc");
      }
    }

    public string mbr_CashReceiptDivDesc => this.mbr_CashReceiptDiv != 0 ? Enum2StrConverter.ToCashReceiptDiv(this.mbr_CashReceiptDiv).ToDescription() : string.Empty;

    public string mbr_CashReceiptAuthNo
    {
      get => this._mbr_CashReceiptAuthNo;
      set
      {
        this._mbr_CashReceiptAuthNo = UbModelBase.LeftStr(value, 200).Replace("'", "´");
        this.Changed(nameof (mbr_CashReceiptAuthNo));
      }
    }

    public double mbr_CreditLimitAmt
    {
      get => this._mbr_CreditLimitAmt;
      set
      {
        this._mbr_CreditLimitAmt = value;
        this.Changed(nameof (mbr_CreditLimitAmt));
        this.Changed("mbr_IsCreditLimitAmt");
      }
    }

    public bool mbr_IsCreditLimitAmt => !this.mbr_CreditLimitAmt.IsZero();

    public double mbr_CreditAmt
    {
      get => this._mbr_CreditAmt;
      set
      {
        this._mbr_CreditAmt = value;
        this.Changed(nameof (mbr_CreditAmt));
        this.Changed("mbr_IsCreditAmt");
      }
    }

    public bool mbr_IsCreditAmt => !this.mbr_CreditAmt.IsZero();

    public int mbr_RegStore
    {
      get => this._mbr_RegStore;
      set
      {
        this._mbr_RegStore = value;
        this.Changed(nameof (mbr_RegStore));
      }
    }

    public int mbr_LastVisitStore
    {
      get => this._mbr_LastVisitStore;
      set
      {
        this._mbr_LastVisitStore = value;
        this.Changed(nameof (mbr_LastVisitStore));
      }
    }

    public DateTime? mbr_LastVisitDate
    {
      get => this._mbr_LastVisitDate;
      set
      {
        this._mbr_LastVisitDate = value;
        this.Changed(nameof (mbr_LastVisitDate));
      }
    }

    public int mbr_SmsSendAgree
    {
      get => this._mbr_SmsSendAgree;
      set
      {
        this._mbr_SmsSendAgree = value;
        this.Changed(nameof (mbr_SmsSendAgree));
        this.Changed("mbr_SmsSendAgreeDesc");
      }
    }

    public string mbr_SmsSendAgreeDesc => this.mbr_SmsSendAgree != 0 ? Enum2StrConverter.ToSmsSendAgree(this.mbr_SmsSendAgree).ToDescription() : string.Empty;

    public int mbr_SmsFailCnt
    {
      get => this._mbr_SmsFailCnt;
      set
      {
        this._mbr_SmsFailCnt = value;
        this.Changed(nameof (mbr_SmsFailCnt));
      }
    }

    public DateTime? mbr_LastSmsSendDate
    {
      get => this._mbr_LastSmsSendDate;
      set
      {
        this._mbr_LastSmsSendDate = value;
        this.Changed(nameof (mbr_LastSmsSendDate));
      }
    }

    public string mbr_ZipCode
    {
      get => this._mbr_ZipCode;
      set
      {
        this._mbr_ZipCode = UbModelBase.LeftStr(value, 10).Replace("'", "´");
        this.Changed(nameof (mbr_ZipCode));
      }
    }

    public string mbr_Addr1
    {
      get => this._mbr_Addr1;
      set
      {
        this._mbr_Addr1 = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (mbr_Addr1));
      }
    }

    public string mbr_Addr2
    {
      get => this._mbr_Addr2;
      set
      {
        this._mbr_Addr2 = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (mbr_Addr2));
      }
    }

    public string mbr_TelNo
    {
      get => this._mbr_TelNo;
      set
      {
        this._mbr_TelNo = UbModelBase.LeftStr(value, 20).Replace("'", "´");
        this.Changed(nameof (mbr_TelNo));
      }
    }

    public string mbr_MobileNo
    {
      get => this._mbr_MobileNo;
      set
      {
        this._mbr_MobileNo = UbModelBase.LeftStr(value, 20).Replace("'", "´");
        this.Changed(nameof (mbr_MobileNo));
      }
    }

    public string mbr_MobileNoEnc
    {
      get => this._mbr_MobileNoEnc;
      set
      {
        this._mbr_MobileNoEnc = UbModelBase.LeftStr(value, 200).Replace("'", "´");
        this.Changed(nameof (mbr_MobileNoEnc));
      }
    }

    public string mbr_Email
    {
      get => this._mbr_Email;
      set
      {
        this._mbr_Email = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (mbr_Email));
      }
    }

    public int mbr_Gender
    {
      get => this._mbr_Gender;
      set
      {
        this._mbr_Gender = value;
        this.Changed(nameof (mbr_Gender));
        this.Changed("mbr_GenderDesc");
      }
    }

    public string mbr_GenderDesc => this.mbr_Gender != 0 ? Enum2StrConverter.ToGender(this.mbr_Gender).ToDescription() : string.Empty;

    public int mbr_BirthType
    {
      get => this._mbr_BirthType;
      set
      {
        this._mbr_BirthType = value;
        this.Changed(nameof (mbr_BirthType));
        this.Changed("mbr_BirthTypeDesc");
      }
    }

    public string mbr_BirthTypeDesc => this.mbr_BirthType != 0 ? Enum2StrConverter.ToMonthCalendarType(this.mbr_BirthType).ToDescription() : string.Empty;

    public DateTime? mbr_Birthday
    {
      get => this._mbr_Birthday;
      set
      {
        this._mbr_Birthday = value;
        this.Changed(nameof (mbr_Birthday));
        this.Changed("mbr_Age");
      }
    }

    public int mbr_Age => this.mbr_Birthday.HasValue ? DateHelper.ToAge(this.mbr_Birthday) : 0;

    public DateTime? mbr_Anniversary
    {
      get => this._mbr_Anniversary;
      set
      {
        this._mbr_Anniversary = value;
        this.Changed(nameof (mbr_Anniversary));
      }
    }

    public string mbr_DeliveryZipCode
    {
      get => this._mbr_DeliveryZipCode;
      set
      {
        this._mbr_DeliveryZipCode = UbModelBase.LeftStr(value, 10).Replace("'", "´");
        this.Changed(nameof (mbr_DeliveryZipCode));
      }
    }

    public string mbr_DeliveryAddr1
    {
      get => this._mbr_DeliveryAddr1;
      set
      {
        this._mbr_DeliveryAddr1 = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (mbr_DeliveryAddr1));
      }
    }

    public string mbr_DeliveryAddr2
    {
      get => this._mbr_DeliveryAddr2;
      set
      {
        this._mbr_DeliveryAddr2 = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (mbr_DeliveryAddr2));
      }
    }

    public string mbr_DeliveryRecvName
    {
      get => this._mbr_DeliveryRecvName;
      set
      {
        this._mbr_DeliveryRecvName = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (mbr_DeliveryRecvName));
      }
    }

    public string mbr_DeliveryMobileNoEnc1
    {
      get => this._mbr_DeliveryMobileNoEnc1;
      set
      {
        this._mbr_DeliveryMobileNoEnc1 = UbModelBase.LeftStr(value, 200).Replace("'", "´");
        this.Changed(nameof (mbr_DeliveryMobileNoEnc1));
      }
    }

    public string mbr_DeliveryMobileNoEnc2
    {
      get => this._mbr_DeliveryMobileNoEnc2;
      set
      {
        this._mbr_DeliveryMobileNoEnc2 = UbModelBase.LeftStr(value, 200).Replace("'", "´");
        this.Changed(nameof (mbr_DeliveryMobileNoEnc2));
      }
    }

    public string mbr_DeliveryMemo
    {
      get => this._mbr_DeliveryMemo;
      set
      {
        this._mbr_DeliveryMemo = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (mbr_DeliveryMemo));
      }
    }

    public string mbr_PosMsg
    {
      get => this._mbr_PosMsg;
      set
      {
        this._mbr_PosMsg = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (mbr_PosMsg));
      }
    }

    public string mbr_DeliveryMsg
    {
      get => this._mbr_DeliveryMsg;
      set
      {
        this._mbr_DeliveryMsg = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (mbr_DeliveryMsg));
      }
    }

    public DateTime? mbr_ExpireDate
    {
      get => this._mbr_ExpireDate;
      set
      {
        this._mbr_ExpireDate = value;
        this.Changed(nameof (mbr_ExpireDate));
      }
    }

    public int mbr_Supplier
    {
      get => this._mbr_Supplier;
      set
      {
        this._mbr_Supplier = value;
        this.Changed(nameof (mbr_Supplier));
      }
    }

    public string mbr_BizNo
    {
      get => this._mbr_BizNo;
      set
      {
        this._mbr_BizNo = UbModelBase.LeftStr(value, 15).Replace("'", "´");
        this.Changed(nameof (mbr_BizNo));
      }
    }

    public string mbr_BizName
    {
      get => this._mbr_BizName;
      set
      {
        this._mbr_BizName = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (mbr_BizName));
      }
    }

    public string mbr_BizCeo
    {
      get => this._mbr_BizCeo;
      set
      {
        this._mbr_BizCeo = UbModelBase.LeftStr(value, 50).Replace("'", "´");
        this.Changed(nameof (mbr_BizCeo));
      }
    }

    public string mbr_BizType
    {
      get => this._mbr_BizType;
      set
      {
        this._mbr_BizType = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (mbr_BizType));
      }
    }

    public string mbr_BizCategory
    {
      get => this._mbr_BizCategory;
      set
      {
        this._mbr_BizCategory = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (mbr_BizCategory));
      }
    }

    public string mbr_TaxBillYn
    {
      get => this._mbr_TaxBillYn;
      set
      {
        this._mbr_TaxBillYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (mbr_TaxBillYn));
        this.Changed("mbr_IsTaxBill");
        this.Changed("mbr_TaxBillYnDesc");
      }
    }

    public bool mbr_IsTaxBill => "Y".Equals(this.mbr_TaxBillYn);

    public string mbr_TaxBillYnDesc => !"Y".Equals(this.mbr_TaxBillYn) ? "미발행" : "발행";

    public DateTime? mbr_LastTaxBillDate
    {
      get => this._mbr_LastTaxBillDate;
      set
      {
        this._mbr_LastTaxBillDate = value;
        this.Changed(nameof (mbr_LastTaxBillDate));
      }
    }

    public int mbr_TaxBillCycle
    {
      get => this._mbr_TaxBillCycle;
      set
      {
        this._mbr_TaxBillCycle = value;
        this.Changed(nameof (mbr_TaxBillCycle));
        this.Changed("mbr_TaxBillCycleDesc");
      }
    }

    public string mbr_TaxBillCycleDesc => this.mbr_TaxBillCycle != 0 ? Enum2StrConverter.ToMemberTaxBillCycle(this.mbr_TaxBillCycle).ToDescription() : string.Empty;

    public int mbr_BankCode
    {
      get => this._mbr_BankCode;
      set
      {
        this._mbr_BankCode = value;
        this.Changed(nameof (mbr_BankCode));
        this.Changed("mbr_BankCodeDesc");
      }
    }

    public string mbr_BankCodeDesc => this.mbr_BankCode != 0 ? Enum2StrConverter.ToCommonCodeTypeMemo(this.mbr_SiteID, EnumCommonCodeType.Bank, this.mbr_BankCode) : string.Empty;

    public string mbr_AccountNo
    {
      get => this._mbr_AccountNo;
      set
      {
        this._mbr_AccountNo = UbModelBase.LeftStr(value, 30).Replace("'", "´");
        this.Changed(nameof (mbr_AccountNo));
      }
    }

    public string mbr_AccountName
    {
      get => this._mbr_AccountName;
      set
      {
        this._mbr_AccountName = UbModelBase.LeftStr(value, 30).Replace("'", "´");
        this.Changed(nameof (mbr_AccountName));
      }
    }

    public int mbr_BuyCycle
    {
      get => this._mbr_BuyCycle;
      set
      {
        this._mbr_BuyCycle = value;
        this.Changed(nameof (mbr_BuyCycle));
      }
    }

    public DateTime? mbr_InDate
    {
      get => this._mbr_InDate;
      set
      {
        this._mbr_InDate = value;
        this.Changed(nameof (mbr_InDate));
      }
    }

    public int mbr_InUser
    {
      get => this._mbr_InUser;
      set
      {
        this._mbr_InUser = value;
        this.Changed(nameof (mbr_InUser));
      }
    }

    public DateTime? mbr_ModDate
    {
      get => this._mbr_ModDate;
      set
      {
        this._mbr_ModDate = value;
        this.Changed(nameof (mbr_ModDate));
      }
    }

    public int mbr_ModUser
    {
      get => this._mbr_ModUser;
      set
      {
        this._mbr_ModUser = value;
        this.Changed(nameof (mbr_ModUser));
      }
    }

    public override DateTime? ModDate => this.mbr_ModDate ?? (this.mbr_ModDate = this.mbr_InDate);

    public TMember() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("mbr_MemberNo", new TTableColumn()
      {
        tc_orgin_name = "mbr_MemberNo",
        tc_trans_name = "회원코드"
      });
      columnInfo.Add("mbr_SiteID", new TTableColumn()
      {
        tc_orgin_name = "mbr_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("mbr_MemberType", new TTableColumn()
      {
        tc_orgin_name = "mbr_MemberType",
        tc_trans_name = "회원유형"
      });
      columnInfo.Add("mbr_MemberName", new TTableColumn()
      {
        tc_orgin_name = "mbr_MemberName",
        tc_trans_name = "회원명"
      });
      columnInfo.Add("mbr_MemberEngName", new TTableColumn()
      {
        tc_orgin_name = "mbr_MemberEngName",
        tc_trans_name = "영문명"
      });
      columnInfo.Add("mbr_MemberCycle", new TTableColumn()
      {
        tc_orgin_name = "mbr_MemberCycle",
        tc_trans_name = "회원주기",
        tc_comm_code = 186
      });
      columnInfo.Add("mbr_MemberGrade", new TTableColumn()
      {
        tc_orgin_name = "mbr_MemberGrade",
        tc_trans_name = "회원등급"
      });
      columnInfo.Add("mbr_GroupCode", new TTableColumn()
      {
        tc_orgin_name = "mbr_GroupCode",
        tc_trans_name = "회원그룹"
      });
      columnInfo.Add("mbr_Status", new TTableColumn()
      {
        tc_orgin_name = "mbr_Status",
        tc_trans_name = "상태",
        tc_comm_code = 181
      });
      columnInfo.Add("mbr_TotalPoint", new TTableColumn()
      {
        tc_orgin_name = "mbr_TotalPoint",
        tc_trans_name = "누적포인트"
      });
      columnInfo.Add("mbr_UsePoint", new TTableColumn()
      {
        tc_orgin_name = "mbr_UsePoint",
        tc_trans_name = "사용포인트"
      });
      columnInfo.Add("mbr_CurrentPoint", new TTableColumn()
      {
        tc_orgin_name = "mbr_CurrentPoint",
        tc_trans_name = "현재포인트"
      });
      columnInfo.Add("mbr_UsablePoint", new TTableColumn()
      {
        tc_orgin_name = "mbr_UsablePoint",
        tc_trans_name = "가용포인트"
      });
      columnInfo.Add("mbr_ExtinctionPoint", new TTableColumn()
      {
        tc_orgin_name = "mbr_ExtinctionPoint",
        tc_trans_name = "소멸포인트"
      });
      columnInfo.Add("mbr_PreSystemPoint", new TTableColumn()
      {
        tc_orgin_name = "mbr_PreSystemPoint",
        tc_trans_name = "이전시스템포인트"
      });
      columnInfo.Add("mbr_PointExtinctionAgree", new TTableColumn()
      {
        tc_orgin_name = "mbr_PointExtinctionAgree",
        tc_trans_name = "포인트소멸동의",
        tc_comm_code = 182
      });
      columnInfo.Add("mbr_PointExtinctionStartDate", new TTableColumn()
      {
        tc_orgin_name = "mbr_PointExtinctionStartDate",
        tc_trans_name = "포인트소멸시작일"
      });
      columnInfo.Add("mbr_PointUsePassword", new TTableColumn()
      {
        tc_orgin_name = "mbr_PointUsePassword",
        tc_trans_name = "포인트사용 비밀번호"
      });
      columnInfo.Add("mbr_CashReceiptDiv", new TTableColumn()
      {
        tc_orgin_name = "mbr_CashReceiptDiv",
        tc_trans_name = "현금영수증구분",
        tc_comm_code = 183
      });
      columnInfo.Add("mbr_CashReceiptAuthNo", new TTableColumn()
      {
        tc_orgin_name = "mbr_CashReceiptAuthNo",
        tc_trans_name = "현금영수증인증번호"
      });
      columnInfo.Add("mbr_CreditLimitAmt", new TTableColumn()
      {
        tc_orgin_name = "mbr_CreditLimitAmt",
        tc_trans_name = "외상한도"
      });
      columnInfo.Add("mbr_CreditAmt", new TTableColumn()
      {
        tc_orgin_name = "mbr_CreditAmt",
        tc_trans_name = "외상합계"
      });
      columnInfo.Add("mbr_RegStore", new TTableColumn()
      {
        tc_orgin_name = "mbr_RegStore",
        tc_trans_name = "등록지점코드"
      });
      columnInfo.Add("mbr_LastVisitStore", new TTableColumn()
      {
        tc_orgin_name = "mbr_LastVisitStore",
        tc_trans_name = "최종방문지점코드"
      });
      columnInfo.Add("mbr_LastVisitDate", new TTableColumn()
      {
        tc_orgin_name = "mbr_LastVisitDate",
        tc_trans_name = "최종방문일"
      });
      columnInfo.Add("mbr_SmsSendAgree", new TTableColumn()
      {
        tc_orgin_name = "mbr_SmsSendAgree",
        tc_trans_name = "SMS 허용",
        tc_comm_code = 184
      });
      columnInfo.Add("mbr_SmsFailCnt", new TTableColumn()
      {
        tc_orgin_name = "mbr_SmsFailCnt",
        tc_trans_name = "SMS 실패수"
      });
      columnInfo.Add("mbr_LastSmsSendDate", new TTableColumn()
      {
        tc_orgin_name = "mbr_LastSmsSendDate",
        tc_trans_name = "최근SMS전송일"
      });
      columnInfo.Add("mbr_ZipCode", new TTableColumn()
      {
        tc_orgin_name = "mbr_ZipCode",
        tc_trans_name = "우편번호"
      });
      columnInfo.Add("mbr_Addr1", new TTableColumn()
      {
        tc_orgin_name = "mbr_Addr1",
        tc_trans_name = "주소"
      });
      columnInfo.Add("mbr_Addr2", new TTableColumn()
      {
        tc_orgin_name = "mbr_Addr2",
        tc_trans_name = "주소 상세"
      });
      columnInfo.Add("mbr_TelNo", new TTableColumn()
      {
        tc_orgin_name = "mbr_TelNo",
        tc_trans_name = "전화"
      });
      columnInfo.Add("mbr_MobileNo", new TTableColumn()
      {
        tc_orgin_name = "mbr_MobileNo",
        tc_trans_name = "모바일"
      });
      columnInfo.Add("mbr_MobileNoEnc", new TTableColumn()
      {
        tc_orgin_name = "mbr_MobileNoEnc",
        tc_trans_name = "모바일"
      });
      columnInfo.Add("mbr_Email", new TTableColumn()
      {
        tc_orgin_name = "mbr_Email",
        tc_trans_name = "이메일"
      });
      columnInfo.Add("mbr_Gender", new TTableColumn()
      {
        tc_orgin_name = "mbr_Gender",
        tc_trans_name = "성별",
        tc_comm_code = 100
      });
      columnInfo.Add("mbr_BirthType", new TTableColumn()
      {
        tc_orgin_name = "mbr_BirthType",
        tc_trans_name = "양/음력",
        tc_comm_code = 101
      });
      columnInfo.Add("mbr_Birthday", new TTableColumn()
      {
        tc_orgin_name = "mbr_Birthday",
        tc_trans_name = "생년월일"
      });
      columnInfo.Add("mbr_Anniversary", new TTableColumn()
      {
        tc_orgin_name = "mbr_Anniversary",
        tc_trans_name = "기념일"
      });
      columnInfo.Add("mbr_PosMsg", new TTableColumn()
      {
        tc_orgin_name = "mbr_PosMsg",
        tc_trans_name = "포스안내메세지"
      });
      columnInfo.Add("mbr_DeliveryMsg", new TTableColumn()
      {
        tc_orgin_name = "mbr_DeliveryMsg",
        tc_trans_name = "배달영수증메세지"
      });
      columnInfo.Add("mbr_ExpireDate", new TTableColumn()
      {
        tc_orgin_name = "mbr_ExpireDate",
        tc_trans_name = "유료회원만료일"
      });
      columnInfo.Add("mbr_Supplier", new TTableColumn()
      {
        tc_orgin_name = "mbr_Supplier",
        tc_trans_name = "외상거래처"
      });
      columnInfo.Add("mbr_BizNo", new TTableColumn()
      {
        tc_orgin_name = "mbr_BizNo",
        tc_trans_name = "사업자번호"
      });
      columnInfo.Add("mbr_BizName", new TTableColumn()
      {
        tc_orgin_name = "mbr_BizName",
        tc_trans_name = "사업자명"
      });
      columnInfo.Add("mbr_BizCeo", new TTableColumn()
      {
        tc_orgin_name = "mbr_BizCeo",
        tc_trans_name = "대표자"
      });
      columnInfo.Add("mbr_BizType", new TTableColumn()
      {
        tc_orgin_name = "mbr_BizType",
        tc_trans_name = "업태"
      });
      columnInfo.Add("mbr_BizCategory", new TTableColumn()
      {
        tc_orgin_name = "mbr_BizCategory",
        tc_trans_name = "업종"
      });
      columnInfo.Add("mbr_TaxBillYn", new TTableColumn()
      {
        tc_orgin_name = "mbr_TaxBillYn",
        tc_trans_name = "계산서발행여부"
      });
      columnInfo.Add("mbr_LastTaxBillDate", new TTableColumn()
      {
        tc_orgin_name = "mbr_LastTaxBillDate",
        tc_trans_name = "최근계산서발행일"
      });
      columnInfo.Add("mbr_TaxBillCycle", new TTableColumn()
      {
        tc_orgin_name = "mbr_TaxBillCycle",
        tc_trans_name = "계산서발행주기",
        tc_comm_code = 192
      });
      columnInfo.Add("mbr_BankCode", new TTableColumn()
      {
        tc_orgin_name = "mbr_BankCode",
        tc_trans_name = "은행",
        tc_comm_code = 32
      });
      columnInfo.Add("mbr_AccountNo", new TTableColumn()
      {
        tc_orgin_name = "mbr_AccountNo",
        tc_trans_name = "계좌번호"
      });
      columnInfo.Add("mbr_AccountName", new TTableColumn()
      {
        tc_orgin_name = "mbr_AccountName",
        tc_trans_name = "예금주명"
      });
      columnInfo.Add("mbr_DeliveryZipCode", new TTableColumn()
      {
        tc_orgin_name = "mbr_DeliveryZipCode",
        tc_trans_name = "배송지우편번호"
      });
      columnInfo.Add("mbr_DeliveryAddr1", new TTableColumn()
      {
        tc_orgin_name = "mbr_DeliveryAddr1",
        tc_trans_name = "배송지주소"
      });
      columnInfo.Add("mbr_DeliveryAddr2", new TTableColumn()
      {
        tc_orgin_name = "mbr_DeliveryAddr2",
        tc_trans_name = "배송지상세"
      });
      columnInfo.Add("mbr_DeliveryRecvName", new TTableColumn()
      {
        tc_orgin_name = "mbr_DeliveryRecvName",
        tc_trans_name = "수취인명"
      });
      columnInfo.Add("mbr_DeliveryMobileNoEnc1", new TTableColumn()
      {
        tc_orgin_name = "mbr_DeliveryMobileNoEnc1",
        tc_trans_name = "모바일"
      });
      columnInfo.Add("mbr_DeliveryMobileNoEnc2", new TTableColumn()
      {
        tc_orgin_name = "mbr_DeliveryMobileNoEnc2",
        tc_trans_name = "모바일"
      });
      columnInfo.Add("mbr_DeliveryMemo", new TTableColumn()
      {
        tc_orgin_name = "mbr_DeliveryMemo",
        tc_trans_name = "배송메모"
      });
      columnInfo.Add("mbr_BuyCycle", new TTableColumn()
      {
        tc_orgin_name = "mbr_BuyCycle",
        tc_trans_name = "구매주기"
      });
      columnInfo.Add("mbr_InDate", new TTableColumn()
      {
        tc_orgin_name = "mbr_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("mbr_InUser", new TTableColumn()
      {
        tc_orgin_name = "mbr_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("mbr_ModDate", new TTableColumn()
      {
        tc_orgin_name = "mbr_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("mbr_ModUser", new TTableColumn()
      {
        tc_orgin_name = "mbr_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.Member;
      this.mbr_MemberNo = 0L;
      this.mbr_SiteID = 0L;
      this.mbr_MemberType = 1;
      this.mbr_MemberName = this.mbr_MemberEngName = string.Empty;
      this.mbr_MemberCycle = 1;
      this.mbr_MemberGrade = 0;
      this.mbr_GroupCode = "000000";
      this.mbr_Status = 1;
      this.mbr_TotalPoint = this.mbr_UsePoint = this.mbr_CurrentPoint = this.mbr_UsablePoint = this.mbr_ExtinctionPoint = this.mbr_PreSystemPoint = 0;
      this.mbr_PointExtinctionAgree = 1;
      this.mbr_PointExtinctionStartDate = new DateTime?();
      this.mbr_PointUsePassword = string.Empty;
      this.mbr_CashReceiptDiv = 1;
      this.mbr_CashReceiptAuthNo = string.Empty;
      this.mbr_CreditLimitAmt = this.mbr_CreditAmt = 0.0;
      this.mbr_RegStore = this.mbr_LastVisitStore = 0;
      this.mbr_LastVisitDate = new DateTime?();
      this.mbr_SmsSendAgree = 1;
      this.mbr_SmsFailCnt = 0;
      this.mbr_LastSmsSendDate = new DateTime?();
      this.mbr_ZipCode = string.Empty;
      this.mbr_Addr1 = string.Empty;
      this.mbr_Addr2 = string.Empty;
      this.mbr_TelNo = string.Empty;
      this.mbr_MobileNo = this.mbr_MobileNoEnc = string.Empty;
      this.mbr_Email = string.Empty;
      this.mbr_Gender = 1;
      this.mbr_BirthType = 1;
      this.mbr_Birthday = new DateTime?();
      this.mbr_Anniversary = new DateTime?();
      this.mbr_DeliveryZipCode = string.Empty;
      this.mbr_DeliveryAddr1 = string.Empty;
      this.mbr_DeliveryAddr2 = string.Empty;
      this.mbr_DeliveryRecvName = string.Empty;
      this.mbr_DeliveryMobileNoEnc1 = string.Empty;
      this.mbr_DeliveryMobileNoEnc2 = string.Empty;
      this.mbr_DeliveryMemo = string.Empty;
      this.mbr_PosMsg = string.Empty;
      this.mbr_DeliveryMsg = string.Empty;
      this.mbr_ExpireDate = new DateTime?();
      this.mbr_Supplier = 0;
      this.mbr_BizNo = string.Empty;
      this.mbr_BizName = string.Empty;
      this.mbr_BizCeo = string.Empty;
      this.mbr_BizType = string.Empty;
      this.mbr_BizCategory = string.Empty;
      this.mbr_TaxBillYn = "N";
      this.mbr_LastTaxBillDate = new DateTime?();
      this.mbr_TaxBillCycle = 0;
      this.mbr_BankCode = 0;
      this.mbr_AccountNo = string.Empty;
      this.mbr_AccountName = string.Empty;
      this.mbr_BuyCycle = 999;
      this.mbr_InDate = new DateTime?();
      this.mbr_InUser = 0;
      this.mbr_ModDate = new DateTime?();
      this.mbr_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TMember();

    public override object Clone()
    {
      TMember tmember = base.Clone() as TMember;
      tmember.mbr_MemberNo = this.mbr_MemberNo;
      tmember.mbr_SiteID = this.mbr_SiteID;
      tmember.mbr_MemberType = this.mbr_MemberType;
      tmember.mbr_MemberName = this.mbr_MemberName;
      tmember.mbr_MemberEngName = this.mbr_MemberEngName;
      tmember.mbr_MemberCycle = this.mbr_MemberCycle;
      tmember.mbr_MemberGrade = this.mbr_MemberGrade;
      tmember.mbr_GroupCode = this.mbr_GroupCode;
      tmember.mbr_Status = this.mbr_Status;
      tmember.mbr_TotalPoint = this.mbr_TotalPoint;
      tmember.mbr_UsePoint = this.mbr_UsePoint;
      tmember.mbr_CurrentPoint = this.mbr_CurrentPoint;
      tmember.mbr_UsablePoint = this.mbr_UsablePoint;
      tmember.mbr_ExtinctionPoint = this.mbr_ExtinctionPoint;
      tmember.mbr_PreSystemPoint = this.mbr_PreSystemPoint;
      tmember.mbr_PointExtinctionAgree = this.mbr_PointExtinctionAgree;
      tmember.mbr_PointExtinctionStartDate = this.mbr_PointExtinctionStartDate;
      tmember.mbr_PointUsePassword = this.mbr_PointUsePassword;
      tmember.mbr_CashReceiptDiv = this.mbr_CashReceiptDiv;
      tmember.mbr_CashReceiptAuthNo = this.mbr_CashReceiptAuthNo;
      tmember.mbr_CreditLimitAmt = this.mbr_CreditLimitAmt;
      tmember.mbr_CreditAmt = this.mbr_CreditAmt;
      tmember.mbr_RegStore = this.mbr_RegStore;
      tmember.mbr_LastVisitStore = this.mbr_LastVisitStore;
      tmember.mbr_LastVisitDate = this.mbr_LastVisitDate;
      tmember.mbr_SmsSendAgree = this.mbr_SmsSendAgree;
      tmember.mbr_SmsFailCnt = this.mbr_SmsFailCnt;
      tmember.mbr_LastSmsSendDate = this.mbr_LastSmsSendDate;
      tmember.mbr_ZipCode = this.mbr_ZipCode;
      tmember.mbr_Addr1 = this.mbr_Addr1;
      tmember.mbr_Addr2 = this.mbr_Addr2;
      tmember.mbr_TelNo = this.mbr_TelNo;
      tmember.mbr_MobileNo = this.mbr_MobileNo;
      tmember.mbr_MobileNoEnc = this.mbr_MobileNoEnc;
      tmember.mbr_Email = this.mbr_Email;
      tmember.mbr_Gender = this.mbr_Gender;
      tmember.mbr_BirthType = this.mbr_BirthType;
      tmember.mbr_Birthday = this.mbr_Birthday;
      tmember.mbr_Anniversary = this.mbr_Anniversary;
      tmember.mbr_PosMsg = this.mbr_PosMsg;
      tmember.mbr_DeliveryMsg = this.mbr_DeliveryMsg;
      tmember.mbr_ExpireDate = this.mbr_ExpireDate;
      tmember.mbr_Supplier = this.mbr_Supplier;
      tmember.mbr_BizNo = this.mbr_BizNo;
      tmember.mbr_BizName = this.mbr_BizName;
      tmember.mbr_BizCeo = this.mbr_BizCeo;
      tmember.mbr_BizType = this.mbr_BizType;
      tmember.mbr_BizCategory = this.mbr_BizCategory;
      tmember.mbr_TaxBillYn = this.mbr_TaxBillYn;
      tmember.mbr_LastTaxBillDate = this.mbr_LastTaxBillDate;
      tmember.mbr_TaxBillCycle = this.mbr_TaxBillCycle;
      tmember.mbr_BankCode = this.mbr_BankCode;
      tmember.mbr_AccountNo = this.mbr_AccountNo;
      tmember.mbr_AccountName = this.mbr_AccountName;
      tmember.mbr_InDate = this.mbr_InDate;
      tmember.mbr_InUser = this.mbr_InUser;
      tmember.mbr_ModDate = this.mbr_ModDate;
      tmember.mbr_ModUser = this.mbr_ModUser;
      tmember.mbr_DeliveryZipCode = this.mbr_DeliveryZipCode;
      tmember.mbr_DeliveryAddr1 = this.mbr_DeliveryAddr1;
      tmember.mbr_DeliveryAddr2 = this.mbr_DeliveryAddr2;
      tmember.mbr_DeliveryRecvName = this.mbr_DeliveryRecvName;
      tmember.mbr_DeliveryMobileNoEnc1 = this.mbr_DeliveryMobileNoEnc1;
      tmember.mbr_DeliveryMobileNoEnc2 = this.mbr_DeliveryMobileNoEnc2;
      tmember.mbr_DeliveryMemo = this.mbr_DeliveryMemo;
      tmember.mbr_BuyCycle = this.mbr_BuyCycle;
      return (object) tmember;
    }

    public void PutData(TMember pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.mbr_MemberNo = pSource.mbr_MemberNo;
      this.mbr_SiteID = pSource.mbr_SiteID;
      this.mbr_MemberType = pSource.mbr_MemberType;
      this.mbr_MemberName = pSource.mbr_MemberName;
      this.mbr_MemberEngName = pSource.mbr_MemberEngName;
      this.mbr_MemberCycle = pSource.mbr_MemberCycle;
      this.mbr_MemberGrade = pSource.mbr_MemberGrade;
      this.mbr_GroupCode = pSource.mbr_GroupCode;
      this.mbr_Status = pSource.mbr_Status;
      this.mbr_TotalPoint = pSource.mbr_TotalPoint;
      this.mbr_UsePoint = pSource.mbr_UsePoint;
      this.mbr_CurrentPoint = pSource.mbr_CurrentPoint;
      this.mbr_UsablePoint = pSource.mbr_UsablePoint;
      this.mbr_ExtinctionPoint = pSource.mbr_ExtinctionPoint;
      this.mbr_PreSystemPoint = pSource.mbr_PreSystemPoint;
      this.mbr_PointExtinctionAgree = pSource.mbr_PointExtinctionAgree;
      this.mbr_PointExtinctionStartDate = pSource.mbr_PointExtinctionStartDate;
      this.mbr_PointUsePassword = pSource.mbr_PointUsePassword;
      this.mbr_CashReceiptDiv = pSource.mbr_CashReceiptDiv;
      this.mbr_CashReceiptAuthNo = pSource.mbr_CashReceiptAuthNo;
      this.mbr_CreditLimitAmt = pSource.mbr_CreditLimitAmt;
      this.mbr_CreditAmt = pSource.mbr_CreditAmt;
      this.mbr_RegStore = pSource.mbr_RegStore;
      this.mbr_LastVisitStore = pSource.mbr_LastVisitStore;
      this.mbr_LastVisitDate = pSource.mbr_LastVisitDate;
      this.mbr_SmsSendAgree = pSource.mbr_SmsSendAgree;
      this.mbr_SmsFailCnt = pSource.mbr_SmsFailCnt;
      this.mbr_LastSmsSendDate = pSource.mbr_LastSmsSendDate;
      this.mbr_ZipCode = pSource.mbr_ZipCode;
      this.mbr_Addr1 = pSource.mbr_Addr1;
      this.mbr_Addr2 = pSource.mbr_Addr2;
      this.mbr_TelNo = pSource.mbr_TelNo;
      this.mbr_MobileNo = pSource.mbr_MobileNo;
      this.mbr_MobileNoEnc = pSource.mbr_MobileNoEnc;
      this.mbr_Email = pSource.mbr_Email;
      this.mbr_Gender = pSource.mbr_Gender;
      this.mbr_BirthType = pSource.mbr_BirthType;
      this.mbr_Birthday = pSource.mbr_Birthday;
      this.mbr_Anniversary = pSource.mbr_Anniversary;
      this.mbr_PosMsg = pSource.mbr_PosMsg;
      this.mbr_DeliveryMsg = pSource.mbr_DeliveryMsg;
      this.mbr_ExpireDate = pSource.mbr_ExpireDate;
      this.mbr_Supplier = pSource.mbr_Supplier;
      this.mbr_BizNo = pSource.mbr_BizNo;
      this.mbr_BizName = pSource.mbr_BizName;
      this.mbr_BizCeo = pSource.mbr_BizCeo;
      this.mbr_BizType = pSource.mbr_BizType;
      this.mbr_BizCategory = pSource.mbr_BizCategory;
      this.mbr_TaxBillYn = pSource.mbr_TaxBillYn;
      this.mbr_LastTaxBillDate = pSource.mbr_LastTaxBillDate;
      this.mbr_TaxBillCycle = pSource.mbr_TaxBillCycle;
      this.mbr_BankCode = pSource.mbr_BankCode;
      this.mbr_AccountNo = pSource.mbr_AccountNo;
      this.mbr_AccountName = pSource.mbr_AccountName;
      this.mbr_InDate = pSource.mbr_InDate;
      this.mbr_InUser = pSource.mbr_InUser;
      this.mbr_ModDate = pSource.mbr_ModDate;
      this.mbr_ModUser = pSource.mbr_ModUser;
      this.mbr_DeliveryZipCode = pSource.mbr_DeliveryZipCode;
      this.mbr_DeliveryAddr1 = pSource.mbr_DeliveryAddr1;
      this.mbr_DeliveryAddr2 = pSource.mbr_DeliveryAddr2;
      this.mbr_DeliveryRecvName = pSource.mbr_DeliveryRecvName;
      this.mbr_DeliveryMobileNoEnc1 = pSource.mbr_DeliveryMobileNoEnc1;
      this.mbr_DeliveryMobileNoEnc2 = pSource.mbr_DeliveryMobileNoEnc2;
      this.mbr_DeliveryMemo = pSource.mbr_DeliveryMemo;
      this.mbr_BuyCycle = pSource.mbr_BuyCycle;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.mbr_MemberNo = p_rs.GetFieldLong("mbr_MemberNo");
        if (this.mbr_MemberNo == 0L)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.mbr_SiteID = p_rs.GetFieldLong("mbr_SiteID");
        this.mbr_MemberType = p_rs.GetFieldInt("mbr_MemberType");
        this.mbr_MemberName = p_rs.GetFieldString("mbr_MemberName");
        this.mbr_MemberEngName = p_rs.GetFieldString("mbr_MemberEngName");
        this.mbr_MemberCycle = p_rs.GetFieldInt("mbr_MemberCycle");
        this.mbr_MemberGrade = p_rs.GetFieldInt("mbr_MemberGrade");
        this.mbr_GroupCode = p_rs.GetFieldString("mbr_GroupCode");
        this.mbr_Status = p_rs.GetFieldInt("mbr_Status");
        this.mbr_TotalPoint = p_rs.GetFieldInt("mbr_TotalPoint");
        this.mbr_UsePoint = p_rs.GetFieldInt("mbr_UsePoint");
        this.mbr_CurrentPoint = p_rs.GetFieldInt("mbr_CurrentPoint");
        this.mbr_UsablePoint = p_rs.GetFieldInt("mbr_UsablePoint");
        this.mbr_ExtinctionPoint = p_rs.GetFieldInt("mbr_ExtinctionPoint");
        this.mbr_PreSystemPoint = p_rs.GetFieldInt("mbr_PreSystemPoint");
        this.mbr_PointExtinctionAgree = p_rs.GetFieldInt("mbr_PointExtinctionAgree");
        this.mbr_PointExtinctionStartDate = p_rs.GetFieldDateTime("mbr_PointExtinctionStartDate");
        this.mbr_PointUsePassword = p_rs.GetFieldString("mbr_PointUsePassword");
        this.mbr_CashReceiptDiv = p_rs.GetFieldInt("mbr_CashReceiptDiv");
        this.mbr_CashReceiptAuthNo = p_rs.GetFieldString("mbr_CashReceiptAuthNo");
        this.mbr_CreditLimitAmt = p_rs.GetFieldDouble("mbr_CreditLimitAmt");
        this.mbr_CreditAmt = p_rs.GetFieldDouble("mbr_CreditAmt");
        this.mbr_RegStore = p_rs.GetFieldInt("mbr_RegStore");
        this.mbr_LastVisitStore = p_rs.GetFieldInt("mbr_LastVisitStore");
        this.mbr_LastVisitDate = p_rs.GetFieldDateTime("mbr_LastVisitDate");
        this.mbr_SmsSendAgree = p_rs.GetFieldInt("mbr_SmsSendAgree");
        this.mbr_SmsFailCnt = p_rs.GetFieldInt("mbr_SmsFailCnt");
        this.mbr_LastSmsSendDate = p_rs.GetFieldDateTime("mbr_LastSmsSendDate");
        this.mbr_ZipCode = p_rs.GetFieldString("mbr_ZipCode");
        this.mbr_Addr1 = p_rs.GetFieldString("mbr_Addr1");
        this.mbr_Addr2 = p_rs.GetFieldString("mbr_Addr2");
        this.mbr_TelNo = p_rs.GetFieldString("mbr_TelNo");
        this.mbr_MobileNo = p_rs.GetFieldString("mbr_MobileNo");
        this.mbr_MobileNoEnc = p_rs.GetFieldString("mbr_MobileNoEnc");
        this.mbr_Email = p_rs.GetFieldString("mbr_Email");
        this.mbr_Gender = p_rs.GetFieldInt("mbr_Gender");
        this.mbr_BirthType = p_rs.GetFieldInt("mbr_BirthType");
        this.mbr_Birthday = p_rs.GetFieldDateTime("mbr_Birthday");
        this.mbr_Anniversary = p_rs.GetFieldDateTime("mbr_Anniversary");
        this.mbr_DeliveryZipCode = p_rs.GetFieldString("mbr_DeliveryZipCode");
        this.mbr_DeliveryAddr1 = p_rs.GetFieldString("mbr_DeliveryAddr1");
        this.mbr_DeliveryAddr2 = p_rs.GetFieldString("mbr_DeliveryAddr2");
        this.mbr_DeliveryRecvName = p_rs.GetFieldString("mbr_DeliveryRecvName");
        this.mbr_DeliveryMobileNoEnc1 = p_rs.GetFieldString("mbr_DeliveryMobileNoEnc1");
        this.mbr_DeliveryMobileNoEnc2 = p_rs.GetFieldString("mbr_DeliveryMobileNoEnc2");
        this.mbr_DeliveryMemo = p_rs.GetFieldString("mbr_DeliveryMemo");
        this.mbr_PosMsg = p_rs.GetFieldString("mbr_PosMsg");
        this.mbr_DeliveryMsg = p_rs.GetFieldString("mbr_DeliveryMsg");
        this.mbr_ExpireDate = p_rs.GetFieldDateTime("mbr_ExpireDate");
        this.mbr_Supplier = p_rs.GetFieldInt("mbr_Supplier");
        this.mbr_BizNo = p_rs.GetFieldString("mbr_BizNo");
        this.mbr_BizName = p_rs.GetFieldString("mbr_BizName");
        this.mbr_BizCeo = p_rs.GetFieldString("mbr_BizCeo");
        this.mbr_BizType = p_rs.GetFieldString("mbr_BizType");
        this.mbr_BizCategory = p_rs.GetFieldString("mbr_BizCategory");
        this.mbr_TaxBillYn = p_rs.GetFieldString("mbr_TaxBillYn");
        this.mbr_LastTaxBillDate = p_rs.GetFieldDateTime("mbr_LastTaxBillDate");
        this.mbr_TaxBillCycle = p_rs.GetFieldInt("mbr_TaxBillCycle");
        this.mbr_BankCode = p_rs.GetFieldInt("mbr_BankCode");
        this.mbr_AccountNo = p_rs.GetFieldString("mbr_AccountNo");
        this.mbr_AccountName = p_rs.GetFieldString("mbr_AccountName");
        this.mbr_BuyCycle = p_rs.GetFieldInt("mbr_BuyCycle");
        this.mbr_InDate = p_rs.GetFieldDateTime("mbr_InDate");
        this.mbr_InUser = p_rs.GetFieldInt("mbr_InUser");
        this.mbr_ModDate = p_rs.GetFieldDateTime("mbr_ModDate");
        this.mbr_ModUser = p_rs.GetFieldInt("mbr_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode) + " mbr_MemberNo,mbr_SiteID,mbr_MemberType,mbr_MemberName,mbr_MemberEngName,mbr_MemberCycle,mbr_MemberGrade,mbr_GroupCode,mbr_Status,mbr_TotalPoint,mbr_UsePoint,mbr_CurrentPoint,mbr_UsablePoint,mbr_ExtinctionPoint,mbr_PreSystemPoint,mbr_PointExtinctionAgree,mbr_PointExtinctionStartDate,mbr_PointUsePassword,mbr_CashReceiptDiv,mbr_CashReceiptAuthNo,mbr_CreditLimitAmt,mbr_CreditAmt,mbr_RegStore,mbr_LastVisitStore,mbr_LastVisitDate,mbr_SmsSendAgree,mbr_SmsFailCnt,mbr_LastSmsSendDate,mbr_ZipCode,mbr_Addr1,mbr_Addr2,mbr_TelNo,mbr_MobileNo,mbr_MobileNoEnc,mbr_Email,mbr_Gender,mbr_BirthType,mbr_Birthday,mbr_Anniversary,mbr_DeliveryZipCode,mbr_DeliveryAddr1,mbr_DeliveryAddr2,mbr_DeliveryRecvName,mbr_DeliveryMobileNoEnc1,mbr_DeliveryMobileNoEnc2,mbr_DeliveryMemo,mbr_PosMsg,mbr_DeliveryMsg,mbr_ExpireDate,mbr_Supplier,mbr_BizNo,mbr_BizName,mbr_BizCeo,mbr_BizType,mbr_BizCategory,mbr_TaxBillYn,mbr_LastTaxBillDate,mbr_TaxBillCycle,mbr_BankCode,mbr_AccountNo,mbr_AccountName,mbr_BuyCycle,mbr_InDate,mbr_InUser,mbr_ModDate,mbr_ModUser) VALUES ( " + string.Format(" {0}", (object) this.mbr_MemberNo) + string.Format(",{0}", (object) this.mbr_SiteID) + string.Format(",{0},'{1}','{2}'", (object) this.mbr_MemberType, (object) this.mbr_MemberName, (object) this.mbr_MemberEngName) + string.Format(",{0},{1},'{2}',{3}", (object) this.mbr_MemberCycle, (object) this.mbr_MemberGrade, (object) this.mbr_GroupCode, (object) this.mbr_Status) + string.Format(",{0},{1},{2}", (object) this.mbr_TotalPoint, (object) this.mbr_UsePoint, (object) this.mbr_CurrentPoint) + string.Format(",{0},{1},{2}", (object) this.mbr_UsablePoint, (object) this.mbr_ExtinctionPoint, (object) this.mbr_PreSystemPoint) + string.Format(",{0},{1}", (object) this.mbr_PointExtinctionAgree, (object) this.mbr_PointExtinctionStartDate.GetDateToStrInNull()) + ",'" + this.mbr_PointUsePassword + "'" + string.Format(",{0},'{1}',{2},{3}", (object) this.mbr_CashReceiptDiv, (object) this.mbr_CashReceiptAuthNo, (object) this.mbr_CreditLimitAmt.FormatTo("{0:0.0000}"), (object) this.mbr_CreditAmt.FormatTo("{0:0.0000}")) + string.Format(",{0},{1}", (object) this.mbr_RegStore, (object) this.mbr_LastVisitStore) + "," + this.mbr_LastVisitDate.GetDateToStrInNull() + string.Format(",{0},{1}", (object) this.mbr_SmsSendAgree, (object) this.mbr_SmsFailCnt) + "," + this.mbr_LastSmsSendDate.GetDateToStrInNull() + ",'" + this.mbr_ZipCode + "','" + this.mbr_Addr1 + "','" + this.mbr_Addr2 + "','" + this.mbr_TelNo + "','" + this.mbr_MobileNo + "','" + this.mbr_MobileNoEnc + "'" + string.Format(",'{0}',{1},{2}", (object) this.mbr_Email, (object) this.mbr_Gender, (object) this.mbr_BirthType) + "," + this.mbr_Birthday.GetDateToStrInNull() + "," + this.mbr_Anniversary.GetDateToStrInNull() + ",'" + this.mbr_DeliveryZipCode + "','" + this.mbr_DeliveryAddr1 + "','" + this.mbr_DeliveryAddr2 + "','" + this.mbr_DeliveryRecvName + "','" + this.mbr_DeliveryMobileNoEnc1 + "','" + this.mbr_DeliveryMobileNoEnc2 + "','" + this.mbr_DeliveryMemo + "','" + this.mbr_PosMsg + "','" + this.mbr_DeliveryMsg + "'," + this.mbr_ExpireDate.GetDateToStrInNull() + string.Format(",{0},'{1}','{2}'", (object) this.mbr_Supplier, (object) this.mbr_BizNo, (object) this.mbr_BizName) + ",'" + this.mbr_BizCeo + "','" + this.mbr_BizType + "','" + this.mbr_BizCategory + "','" + this.mbr_TaxBillYn + "'," + this.mbr_LastTaxBillDate.GetDateToStrInNull() + string.Format(",{0},{1},'{2}','{3}'", (object) this.mbr_TaxBillCycle, (object) this.mbr_BankCode, (object) this.mbr_AccountNo, (object) this.mbr_AccountName) + string.Format(",{0}", (object) this.mbr_BuyCycle) + string.Format(",{0},{1}", (object) this.mbr_InDate.GetDateToStrInNull(), (object) this.mbr_InUser) + string.Format(",{0},{1}", (object) this.mbr_ModDate.GetDateToStrInNull(), (object) this.mbr_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.mbr_MemberNo, (object) this.mbr_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TMember tmember = this;
      // ISSUE: reference to a compiler-generated method
      tmember.\u003C\u003En__0();
      if (await tmember.OleDB.ExecuteAsync(tmember.InsertQuery()))
        return true;
      tmember.message = " " + tmember.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmember.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmember.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tmember.mbr_MemberNo, (object) tmember.mbr_SiteID) + " 내용 : " + tmember.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmember.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode) + string.Format(" {0}={1},{2}='{3}',{4}='{5}'", (object) "mbr_MemberType", (object) this.mbr_MemberType, (object) "mbr_MemberName", (object) this.mbr_MemberName, (object) "mbr_MemberEngName", (object) this.mbr_MemberEngName) + string.Format(",{0}={1},{2}={3}", (object) "mbr_MemberCycle", (object) this.mbr_MemberCycle, (object) "mbr_MemberGrade", (object) this.mbr_MemberGrade) + string.Format(",{0}='{1}',{2}={3}", (object) "mbr_GroupCode", (object) this.mbr_GroupCode, (object) "mbr_Status", (object) this.mbr_Status) + string.Format(",{0}={1},{2}={3},{4}={5}", (object) "mbr_TotalPoint", (object) this.mbr_TotalPoint, (object) "mbr_UsePoint", (object) this.mbr_UsePoint, (object) "mbr_CurrentPoint", (object) this.mbr_CurrentPoint) + string.Format(",{0}={1},{2}={3},{4}={5}", (object) "mbr_UsablePoint", (object) this.mbr_UsablePoint, (object) "mbr_ExtinctionPoint", (object) this.mbr_ExtinctionPoint, (object) "mbr_PreSystemPoint", (object) this.mbr_PreSystemPoint) + string.Format(",{0}={1}", (object) "mbr_PointExtinctionAgree", (object) this.mbr_PointExtinctionAgree) + ",mbr_PointExtinctionStartDate=" + this.mbr_PointExtinctionStartDate.GetDateToStrInNull() + ",mbr_PointUsePassword='" + this.mbr_PointUsePassword + "'" + string.Format(",{0}={1},{2}='{3}'", (object) "mbr_CashReceiptDiv", (object) this.mbr_CashReceiptDiv, (object) "mbr_CashReceiptAuthNo", (object) this.mbr_CashReceiptAuthNo) + ",mbr_CreditLimitAmt=" + this.mbr_CreditLimitAmt.FormatTo("{0:0.0000}") + ",mbr_CreditAmt=" + this.mbr_CreditAmt.FormatTo("{0:0.0000}") + string.Format(",{0}={1},{2}={3}", (object) "mbr_RegStore", (object) this.mbr_RegStore, (object) "mbr_LastVisitStore", (object) this.mbr_LastVisitStore) + ",mbr_LastVisitDate=" + this.mbr_LastVisitDate.GetDateToStrInNull() + string.Format(",{0}={1},{2}={3}", (object) "mbr_SmsSendAgree", (object) this.mbr_SmsSendAgree, (object) "mbr_SmsFailCnt", (object) this.mbr_SmsFailCnt) + ",mbr_LastSmsSendDate=" + this.mbr_LastSmsSendDate.GetDateToStrInNull() + ",mbr_ZipCode='" + this.mbr_ZipCode + "',mbr_Addr1='" + this.mbr_Addr1 + "',mbr_Addr2='" + this.mbr_Addr2 + "',mbr_TelNo='" + this.mbr_TelNo + "',mbr_MobileNo='" + this.mbr_MobileNo + "',mbr_MobileNoEnc='" + this.mbr_MobileNoEnc + "'" + string.Format(",{0}='{1}',{2}={3},{4}={5}", (object) "mbr_Email", (object) this.mbr_Email, (object) "mbr_Gender", (object) this.mbr_Gender, (object) "mbr_BirthType", (object) this.mbr_BirthType) + ",mbr_Birthday=" + this.mbr_Birthday.GetDateToStrInNull() + ",mbr_Anniversary=" + this.mbr_Anniversary.GetDateToStrInNull() + ",mbr_DeliveryZipCode='" + this.mbr_DeliveryZipCode + "',mbr_DeliveryAddr1='" + this.mbr_DeliveryAddr1 + "',mbr_DeliveryAddr2='" + this.mbr_DeliveryAddr2 + "',mbr_DeliveryRecvName='" + this.mbr_DeliveryRecvName + "',mbr_DeliveryMobileNoEnc1='" + this.mbr_DeliveryMobileNoEnc1 + "',mbr_DeliveryMobileNoEnc2='" + this.mbr_DeliveryMobileNoEnc2 + "',mbr_DeliveryMemo='" + this.mbr_DeliveryMemo + "',mbr_PosMsg='" + this.mbr_PosMsg + "',mbr_DeliveryMsg='" + this.mbr_DeliveryMsg + "',mbr_ExpireDate=" + this.mbr_ExpireDate.GetDateToStrInNull() + string.Format(",{0}={1},{2}='{3}',{4}='{5}'", (object) "mbr_Supplier", (object) this.mbr_Supplier, (object) "mbr_BizNo", (object) this.mbr_BizNo, (object) "mbr_BizName", (object) this.mbr_BizName) + ",mbr_BizCeo='" + this.mbr_BizCeo + "',mbr_BizType='" + this.mbr_BizType + "',mbr_BizCategory='" + this.mbr_BizCategory + "',mbr_TaxBillYn='" + this.mbr_TaxBillYn + "',mbr_LastTaxBillDate=" + this.mbr_LastTaxBillDate.GetDateToStrInNull() + string.Format(",{0}={1},{2}={3}", (object) "mbr_TaxBillCycle", (object) this.mbr_TaxBillCycle, (object) "mbr_BankCode", (object) this.mbr_BankCode) + ",mbr_AccountNo='" + this.mbr_AccountNo + "',mbr_AccountName='" + this.mbr_AccountName + "'" + string.Format(",{0}={1}", (object) "mbr_BuyCycle", (object) this.mbr_BuyCycle) + string.Format(",{0}={1},{2}={3}", (object) "mbr_ModDate", (object) this.mbr_ModDate.GetDateToStrInNull(), (object) "mbr_ModUser", (object) this.mbr_ModUser) + string.Format(" WHERE {0}={1}", (object) "mbr_MemberNo", (object) this.mbr_MemberNo) + string.Format(" AND {0}={1}", (object) "mbr_SiteID", (object) this.mbr_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.mbr_MemberNo, (object) this.mbr_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TMember tmember = this;
      // ISSUE: reference to a compiler-generated method
      tmember.\u003C\u003En__1();
      if (await tmember.OleDB.ExecuteAsync(tmember.UpdateQuery()))
        return true;
      tmember.message = " " + tmember.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmember.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmember.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tmember.mbr_MemberNo, (object) tmember.mbr_SiteID) + " 내용 : " + tmember.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmember.message);
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
      stringBuilder.Append(string.Format(" {0}={1},{2}='{3}',{4}='{5}'", (object) "mbr_MemberType", (object) this.mbr_MemberType, (object) "mbr_MemberName", (object) this.mbr_MemberName, (object) "mbr_MemberEngName", (object) this.mbr_MemberEngName) + string.Format(",{0}={1},{2}={3}", (object) "mbr_MemberCycle", (object) this.mbr_MemberCycle, (object) "mbr_MemberGrade", (object) this.mbr_MemberGrade) + string.Format(",{0}='{1}',{2}={3}", (object) "mbr_GroupCode", (object) this.mbr_GroupCode, (object) "mbr_Status", (object) this.mbr_Status) + string.Format(",{0}={1},{2}={3},{4}={5}", (object) "mbr_TotalPoint", (object) this.mbr_TotalPoint, (object) "mbr_UsePoint", (object) this.mbr_UsePoint, (object) "mbr_CurrentPoint", (object) this.mbr_CurrentPoint) + string.Format(",{0}={1},{2}={3},{4}={5}", (object) "mbr_UsablePoint", (object) this.mbr_UsablePoint, (object) "mbr_ExtinctionPoint", (object) this.mbr_ExtinctionPoint, (object) "mbr_PreSystemPoint", (object) this.mbr_PreSystemPoint) + string.Format(",{0}={1}", (object) "mbr_PointExtinctionAgree", (object) this.mbr_PointExtinctionAgree) + ",mbr_PointExtinctionStartDate=" + this.mbr_PointExtinctionStartDate.GetDateToStrInNull() + ",mbr_PointUsePassword='" + this.mbr_PointUsePassword + "'" + string.Format(",{0}={1},{2}='{3}'", (object) "mbr_CashReceiptDiv", (object) this.mbr_CashReceiptDiv, (object) "mbr_CashReceiptAuthNo", (object) this.mbr_CashReceiptAuthNo) + ",mbr_CreditLimitAmt=" + this.mbr_CreditLimitAmt.FormatTo("{0:0.0000}") + ",mbr_CreditAmt=" + this.mbr_CreditAmt.FormatTo("{0:0.0000}") + string.Format(",{0}={1},{2}={3}", (object) "mbr_RegStore", (object) this.mbr_RegStore, (object) "mbr_LastVisitStore", (object) this.mbr_LastVisitStore) + ",mbr_LastVisitDate=" + this.mbr_LastVisitDate.GetDateToStrInNull() + string.Format(",{0}={1},{2}={3}", (object) "mbr_SmsSendAgree", (object) this.mbr_SmsSendAgree, (object) "mbr_SmsFailCnt", (object) this.mbr_SmsFailCnt) + ",mbr_LastSmsSendDate=" + this.mbr_LastSmsSendDate.GetDateToStrInNull() + ",mbr_ZipCode='" + this.mbr_ZipCode + "',mbr_Addr1='" + this.mbr_Addr1 + "',mbr_Addr2='" + this.mbr_Addr2 + "',mbr_TelNo='" + this.mbr_TelNo + "',mbr_MobileNo='" + this.mbr_MobileNo + "',mbr_MobileNoEnc='" + this.mbr_MobileNoEnc + "'" + string.Format(",{0}='{1}',{2}={3},{4}={5}", (object) "mbr_Email", (object) this.mbr_Email, (object) "mbr_Gender", (object) this.mbr_Gender, (object) "mbr_BirthType", (object) this.mbr_BirthType) + ",mbr_Birthday=" + this.mbr_Birthday.GetDateToStrInNull() + ",mbr_Anniversary=" + this.mbr_Anniversary.GetDateToStrInNull() + ",mbr_DeliveryZipCode='" + this.mbr_DeliveryZipCode + "',mbr_DeliveryAddr1='" + this.mbr_DeliveryAddr1 + "',mbr_DeliveryAddr2='" + this.mbr_DeliveryAddr2 + "',mbr_DeliveryRecvName,mbr_DeliveryMobileNoEnc1,mbr_DeliveryMobileNoEnc2,mbr_DeliveryMemo='" + this.mbr_DeliveryMemo + "',mbr_PosMsg='" + this.mbr_PosMsg + "',mbr_DeliveryMsg='" + this.mbr_DeliveryMsg + "',mbr_ExpireDate=" + this.mbr_ExpireDate.GetDateToStrInNull() + string.Format(",{0}={1},{2}='{3}',{4}='{5}'", (object) "mbr_Supplier", (object) this.mbr_Supplier, (object) "mbr_BizNo", (object) this.mbr_BizNo, (object) "mbr_BizName", (object) this.mbr_BizName) + ",mbr_BizCeo='" + this.mbr_BizCeo + "',mbr_BizType='" + this.mbr_BizType + "',mbr_BizCategory='" + this.mbr_BizCategory + "',mbr_TaxBillYn='" + this.mbr_TaxBillYn + "',mbr_LastTaxBillDate=" + this.mbr_LastTaxBillDate.GetDateToStrInNull() + string.Format(",{0}={1},{2}={3}", (object) "mbr_TaxBillCycle", (object) this.mbr_TaxBillCycle, (object) "mbr_BankCode", (object) this.mbr_BankCode) + ",mbr_AccountNo='" + this.mbr_AccountNo + "',mbr_AccountName='" + this.mbr_AccountName + "'" + string.Format(",{0}={1}", (object) "mbr_BuyCycle", (object) this.mbr_BuyCycle) + string.Format(",{0}={1},{2}={3}", (object) "mbr_ModDate", (object) this.mbr_ModDate.GetDateToStrInNull(), (object) "mbr_ModUser", (object) this.mbr_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.mbr_MemberNo, (object) this.mbr_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TMember tmember = this;
      // ISSUE: reference to a compiler-generated method
      tmember.\u003C\u003En__1();
      if (await tmember.OleDB.ExecuteAsync(tmember.UpdateExInsertQuery()))
        return true;
      tmember.message = " " + tmember.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmember.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmember.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tmember.mbr_MemberNo, (object) tmember.mbr_SiteID) + " 내용 : " + tmember.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmember.message);
      return false;
    }

    protected string UpdateAddUsePointQuery(int p_add_use_point)
    {
      this.mbr_ModDate = new DateTime?(DateTime.Now);
      return string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode) + string.Format(" {0}={1}+{2}", (object) "mbr_UsePoint", (object) this.mbr_UsePoint, (object) p_add_use_point) + ",mbr_ModDate=" + this.mbr_ModDate.GetDateToStrInNull() + string.Format(" WHERE {0}={1}", (object) "mbr_MemberNo", (object) this.mbr_MemberNo) + string.Format(" AND {0}={1}", (object) "mbr_SiteID", (object) this.mbr_SiteID);
    }

    public bool UpdateAddUsePoint(int p_add_use_point)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateAddUsePointQuery(p_add_use_point)))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.mbr_MemberNo, (object) this.mbr_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public async Task<bool> UpdateAddUsePointAsync(int p_add_use_point)
    {
      TMember tmember = this;
      // ISSUE: reference to a compiler-generated method
      tmember.\u003C\u003En__1();
      if (await tmember.OleDB.ExecuteAsync(tmember.UpdateAddUsePointQuery(p_add_use_point)))
        return true;
      tmember.message = " " + tmember.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmember.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmember.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tmember.mbr_MemberNo, (object) tmember.mbr_SiteID) + " 내용 : " + tmember.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmember.message);
      return false;
    }

    protected string UpdateAddTodayPointQuery(int p_add_today_point)
    {
      this.mbr_ModDate = new DateTime?(DateTime.Now);
      return string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode) + string.Format(" {0}={1}+{2}", (object) "mbr_TotalPoint", (object) this.mbr_TotalPoint, (object) p_add_today_point) + string.Format(",{0}={1}+{2}", (object) "mbr_UsablePoint", (object) this.mbr_UsablePoint, (object) p_add_today_point) + ",mbr_ModDate=" + this.mbr_ModDate.GetDateToStrInNull() + string.Format(" WHERE {0}={1}", (object) "mbr_MemberNo", (object) this.mbr_MemberNo) + string.Format(" AND {0}={1}", (object) "mbr_SiteID", (object) this.mbr_SiteID);
    }

    public bool UpdateAddTodayPoint(int p_add_today_point)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateAddTodayPointQuery(p_add_today_point)))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.mbr_MemberNo, (object) this.mbr_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public async Task<bool> UpdateAddTodayPointAsync(int p_add_today_point)
    {
      TMember tmember = this;
      // ISSUE: reference to a compiler-generated method
      tmember.\u003C\u003En__1();
      if (await tmember.OleDB.ExecuteAsync(tmember.UpdateAddTodayPointQuery(p_add_today_point)))
        return true;
      tmember.message = " " + tmember.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmember.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmember.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tmember.mbr_MemberNo, (object) tmember.mbr_SiteID) + " 내용 : " + tmember.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmember.message);
      return false;
    }

    public string UpdateCycleQuery(
      long p_mbr_MemberNo,
      long p_mbr_SiteID,
      EnumMemberCycle p_mbr_MemberCycle)
    {
      if (p_mbr_MemberCycle == EnumMemberCycle.NONE)
        return string.Empty;
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode) + string.Format(" {0}={1} ", (object) "mbr_MemberCycle", (object) (int) p_mbr_MemberCycle) + string.Format(" WHERE {0}={1}", (object) "mbr_MemberNo", (object) p_mbr_MemberNo) + string.Format(" AND {0}={1}", (object) "mbr_SiteID", (object) p_mbr_SiteID) + ";");
      return stringBuilder.ToString();
    }

    public string UpdateGradeQuery(long p_mbr_MemberNo, long p_mbr_SiteID, int p_mbr_MemberGrade)
    {
      if (p_mbr_MemberGrade == 0)
        return string.Empty;
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode) + string.Format(" {0}={1} ", (object) "mbr_MemberGrade", (object) p_mbr_MemberGrade) + string.Format(" WHERE {0}={1}", (object) "mbr_MemberNo", (object) p_mbr_MemberNo) + string.Format(" AND {0}={1}", (object) "mbr_SiteID", (object) p_mbr_SiteID) + ";");
      return stringBuilder.ToString();
    }

    public string UpdateBuyCycleQuery(long p_mbr_MemberNo, long p_mbr_SiteID, int p_mbr_BuyCycle)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode) + string.Format(" {0}={1} ", (object) "mbr_BuyCycle", (object) p_mbr_BuyCycle) + string.Format(" WHERE {0}={1}", (object) "mbr_MemberNo", (object) p_mbr_MemberNo) + string.Format(" AND {0}={1}", (object) "mbr_SiteID", (object) p_mbr_SiteID) + ";");
      return stringBuilder.ToString();
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "mbr_SiteID") && Convert.ToInt64(hashtable[(object) "mbr_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "mbr_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "mbr_MemberNo") && Convert.ToInt64(hashtable[(object) "mbr_MemberNo"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mbr_MemberNo", hashtable[(object) "mbr_MemberNo"]));
        else
          stringBuilder.Append(" AND mbr_MemberNo>0");
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mbr_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "mbr_MemberName") && !string.IsNullOrEmpty(hashtable[(object) "mbr_MemberName"].ToString()))
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "mbr_MemberName", hashtable[(object) "mbr_MemberName"]));
        else if (hashtable.ContainsKey((object) "mbr_MemberName_LIKE_ALL_") && !string.IsNullOrEmpty(hashtable[(object) "mbr_MemberName_LIKE_ALL_"].ToString()))
          stringBuilder.Append(string.Format(" AND {0} LIKE '%{1}%'", (object) "mbr_MemberName", hashtable[(object) "mbr_MemberName"]));
        if (hashtable.ContainsKey((object) "mbr_MemberType") && Convert.ToInt32(hashtable[(object) "mbr_MemberType"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mbr_MemberType", hashtable[(object) "mbr_MemberType"]));
        if (hashtable.ContainsKey((object) "mbr_MemberCycle") && Convert.ToInt32(hashtable[(object) "mbr_MemberCycle"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mbr_MemberCycle", hashtable[(object) "mbr_MemberCycle"]));
        if (hashtable.ContainsKey((object) "mbr_MemberGrade") && Convert.ToInt32(hashtable[(object) "mbr_MemberGrade"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mbr_MemberGrade", hashtable[(object) "mbr_MemberGrade"]));
        if (hashtable.ContainsKey((object) "mbr_GroupCode") && !string.IsNullOrEmpty(hashtable[(object) "mbr_GroupCode"].ToString()))
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "mbr_GroupCode", hashtable[(object) "mbr_GroupCode"]));
        if (hashtable.ContainsKey((object) "mbr_Status") && Convert.ToInt32(hashtable[(object) "mbr_Status"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mbr_Status", hashtable[(object) "mbr_Status"]));
        if (hashtable.ContainsKey((object) "mbr_CashReceiptDiv") && Convert.ToInt32(hashtable[(object) "mbr_CashReceiptDiv"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mbr_CashReceiptDiv", hashtable[(object) "mbr_CashReceiptDiv"]));
        if (hashtable.ContainsKey((object) "mbr_RegStore") && Convert.ToInt32(hashtable[(object) "mbr_RegStore"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mbr_RegStore", hashtable[(object) "mbr_RegStore"]));
        if (hashtable.ContainsKey((object) "mbr_LastVisitStore") && Convert.ToInt32(hashtable[(object) "mbr_LastVisitStore"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mbr_LastVisitStore", hashtable[(object) "mbr_LastVisitStore"]));
        if (hashtable.ContainsKey((object) "mbr_LastVisitDate_BEGIN_") && !string.IsNullOrEmpty(hashtable[(object) "mbr_LastVisitDate_BEGIN_"].ToString()) && hashtable.ContainsKey((object) "mbr_LastVisitDate_END_") && !string.IsNullOrEmpty(hashtable[(object) "mbr_LastVisitDate_END_"].ToString()))
          stringBuilder.Append(" AND mbr_LastVisitDate<=" + new DateTime?((DateTime) hashtable[(object) "mbr_LastVisitDate_BEGIN_"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + " AND mbr_LastVisitDate>=" + new DateTime?((DateTime) hashtable[(object) "mbr_LastVisitDate_END_"]).GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'"));
        if (hashtable.ContainsKey((object) "mbr_SmsSendAgree") && Convert.ToInt32(hashtable[(object) "mbr_SmsSendAgree"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mbr_SmsSendAgree", hashtable[(object) "mbr_SmsSendAgree"]));
        if (hashtable.ContainsKey((object) "mbr_SmsFailCnt_NEXT_") && Convert.ToInt32(hashtable[(object) "mbr_SmsFailCnt_NEXT_"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}>={1}", (object) "mbr_SmsFailCnt", hashtable[(object) "mbr_SmsFailCnt_NEXT_"]));
        if (hashtable.ContainsKey((object) "mbr_LastSmsSendDate_BEGIN_") && !string.IsNullOrEmpty(hashtable[(object) "mbr_LastSmsSendDate_BEGIN_"].ToString()) && hashtable.ContainsKey((object) "mbr_LastSmsSendDate_END_") && !string.IsNullOrEmpty(hashtable[(object) "mbr_LastSmsSendDate_END_"].ToString()))
          stringBuilder.Append(" AND mbr_LastSmsSendDate<=" + new DateTime?((DateTime) hashtable[(object) "mbr_LastSmsSendDate_BEGIN_"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + " AND mbr_LastSmsSendDate>=" + new DateTime?((DateTime) hashtable[(object) "mbr_LastSmsSendDate_END_"]).GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'"));
        if (hashtable.ContainsKey((object) "mbr_ZipCode") && !string.IsNullOrEmpty(hashtable[(object) "mbr_ZipCode"].ToString()))
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "mbr_ZipCode", hashtable[(object) "mbr_ZipCode"]));
        if (hashtable.ContainsKey((object) "_PHONE_NO__LIKE_LEFT_") && !string.IsNullOrEmpty(hashtable[(object) "_PHONE_NO__LIKE_LEFT_"].ToString()))
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "mbr_TelNo", hashtable[(object) "_PHONE_NO__LIKE_LEFT_"]) + string.Format(" OR {0} LIKE '%{1}%'", (object) "mbr_MobileNo", hashtable[(object) "_PHONE_NO__LIKE_LEFT_"]) + ")");
        if (hashtable.ContainsKey((object) "mbr_Gender") && Convert.ToInt32(hashtable[(object) "mbr_Gender"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mbr_Gender", hashtable[(object) "mbr_Gender"]));
        if (hashtable.ContainsKey((object) "mbr_TaxBillYn") && !string.IsNullOrEmpty(hashtable[(object) "mbr_TaxBillYn"].ToString()))
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "mbr_TaxBillYn", hashtable[(object) "mbr_TaxBillYn"]));
        if (hashtable.ContainsKey((object) "mbr_IsCreditLimitAmt"))
          stringBuilder.Append(" AND mbr_CreditLimitAmt" + (Convert.ToBoolean(hashtable[(object) "mbr_IsCreditLimitAmt"].ToString()) ? "!=" : "=") + "0");
        if (hashtable.ContainsKey((object) "mbr_IsCreditAmt") && Convert.ToBoolean(hashtable[(object) "mbr_IsCreditAmt"].ToString()))
          stringBuilder.Append(" AND mbr_CreditAmt" + (Convert.ToBoolean(hashtable[(object) "mbr_IsCreditAmt"].ToString()) ? "!=" : "=") + "0");
        if (hashtable.ContainsKey((object) "mbr_BirthType") && Convert.ToInt32(hashtable[(object) "mbr_BirthType"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mbr_BirthType", hashtable[(object) "mbr_BirthType"]));
        if (hashtable.ContainsKey((object) "mbr_Birthday") && !string.IsNullOrEmpty(hashtable[(object) "mbr_Birthday"].ToString()))
          stringBuilder.Append(" AND mbr_Birthday<=" + new DateTime?((DateTime) hashtable[(object) "mbr_Birthday"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + " AND mbr_Birthday>=" + new DateTime?((DateTime) hashtable[(object) "mbr_Birthday"]).GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'"));
        if (hashtable.ContainsKey((object) "mbr_Age") && Convert.ToInt32(hashtable[(object) "mbr_Age"].ToString()) > 0)
        {
          DateTime birthYear = DateHelper.ToBirthYear(this.mbr_Age);
          stringBuilder.Append(" AND mbr_Birthday<=" + new DateTime?(birthYear).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + " AND mbr_Birthday>=" + new DateTime?(birthYear.GetDateAdd(1, 0, -1)).GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'"));
        }
        else if (hashtable.ContainsKey((object) "mbr_Age_BEGIN_") && !string.IsNullOrEmpty(hashtable[(object) "mbr_Age_BEGIN_"].ToString()) && Convert.ToInt32(hashtable[(object) "mbr_Age_BEGIN_"].ToString()) > 0 && hashtable.ContainsKey((object) "mbr_Age_END_") && !string.IsNullOrEmpty(hashtable[(object) "mbr_Age_END_"].ToString()) && Convert.ToInt32(hashtable[(object) "mbr_Age_END_"].ToString()) > 0)
        {
          DateTime birthYear1 = DateHelper.ToBirthYear(Convert.ToInt32(hashtable[(object) "mbr_Age_BEGIN_"].ToString()));
          DateTime birthYear2 = DateHelper.ToBirthYear(Convert.ToInt32(hashtable[(object) "mbr_Age_END_"].ToString()));
          stringBuilder.Append(" AND mbr_Birthday<=" + new DateTime?(birthYear1).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + " AND mbr_Birthday>=" + new DateTime?(birthYear2.GetDateAdd(1, 0, -1)).GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'"));
        }
        if (hashtable.ContainsKey((object) "mbr_Anniversary") && !string.IsNullOrEmpty(hashtable[(object) "mbr_Anniversary"].ToString()))
          stringBuilder.Append(" AND mbr_Anniversary<=" + new DateTime?((DateTime) hashtable[(object) "mbr_Anniversary"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + " AND mbr_Anniversary>=" + new DateTime?((DateTime) hashtable[(object) "mbr_Anniversary"]).GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'"));
        if (hashtable.ContainsKey((object) "mbr_InDate_BEGIN_") && !string.IsNullOrEmpty(hashtable[(object) "mbr_InDate_BEGIN_"].ToString()) && hashtable.ContainsKey((object) "mbr_InDate_END_") && !string.IsNullOrEmpty(hashtable[(object) "mbr_InDate_END_"].ToString()))
          stringBuilder.Append(" AND mbr_InDate<=" + new DateTime?((DateTime) hashtable[(object) "mbr_InDate_BEGIN_"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + " AND mbr_InDate>=" + new DateTime?((DateTime) hashtable[(object) "mbr_InDate_END_"]).GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'"));
        if (hashtable.ContainsKey((object) "mbr_ModDate_BEGIN_") && !string.IsNullOrEmpty(hashtable[(object) "mbr_ModDate_BEGIN_"].ToString()) && hashtable.ContainsKey((object) "mbr_ModDate_END_") && !string.IsNullOrEmpty(hashtable[(object) "mbr_ModDate_END_"].ToString()))
          stringBuilder.Append(" AND mbr_ModDate<=" + new DateTime?((DateTime) hashtable[(object) "mbr_ModDate_BEGIN_"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + " AND mbr_ModDate>=" + new DateTime?((DateTime) hashtable[(object) "mbr_ModDate_END_"]).GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'"));
        if (hashtable.ContainsKey((object) "mbr_BuyCycle") && Convert.ToInt32(hashtable[(object) "mbr_BuyCycle"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mbr_BuyCycle", hashtable[(object) "mbr_BuyCycle"]));
        else if (hashtable.ContainsKey((object) "mbr_BuyCycle_BEGIN_") && Convert.ToInt32(hashtable[(object) "mbr_BuyCycle_BEGIN_"].ToString()) > 0 && hashtable.ContainsKey((object) "mbr_BuyCycle_END_") && Convert.ToInt32(hashtable[(object) "mbr_BuyCycle_END_"].ToString()) > 0)
          stringBuilder.Append(" AND mbr_BuyCycle>=" + string.Format("{0}", (object) Convert.ToInt32(hashtable[(object) "mbr_BuyCycle_BEGIN_"].ToString())) + " AND mbr_BuyCycle<=" + string.Format("{0}", (object) Convert.ToInt32(hashtable[(object) "mbr_BuyCycle_END_"].ToString())));
        else if (hashtable.ContainsKey((object) "mbr_BuyCycle_NEXT_") && Convert.ToInt32(hashtable[(object) "mbr_BuyCycle_NEXT_"].ToString()) > 0)
          stringBuilder.Append(" AND mbr_BuyCycle<=" + string.Format("{0}", (object) Convert.ToInt32(hashtable[(object) "mbr_BuyCycle_NEXT_"].ToString())));
        else if (hashtable.ContainsKey((object) "mbr_BuyCycle_BEFORE_") && Convert.ToInt32(hashtable[(object) "mbr_BuyCycle_BEFORE_"].ToString()) > 0)
          stringBuilder.Append(" AND mbr_BuyCycle>=" + string.Format("{0}", (object) Convert.ToInt32(hashtable[(object) "mbr_BuyCycle_BEFORE_"].ToString())));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && !string.IsNullOrEmpty(hashtable[(object) "_KEY_WORD_"].ToString()))
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "mbr_MemberName", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "mbr_TelNo", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "mbr_MobileNo", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "mbr_BizNo", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "mbr_BizName", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "mbr_BizCeo", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "mbr_AccountNo", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "mbr_AccountName", hashtable[(object) "_KEY_WORD_"]));
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
        if (p_param is Hashtable hashtable1)
        {
          if (hashtable1.ContainsKey((object) "DBMS") && hashtable1[(object) "DBMS"].ToString().Length > 0)
            uniMembers = hashtable1[(object) "DBMS"].ToString();
          if (hashtable1.ContainsKey((object) "table") && hashtable1[(object) "table"].ToString().Length > 0)
            str = hashtable1[(object) "table"].ToString();
        }
        stringBuilder.Append(" SELECT  mbr_MemberNo,mbr_SiteID,mbr_MemberType,mbr_MemberName,mbr_MemberEngName,mbr_MemberCycle,mbr_MemberGrade,mbr_GroupCode,mbr_Status,mbr_TotalPoint,mbr_UsePoint,mbr_CurrentPoint,mbr_UsablePoint,mbr_ExtinctionPoint,mbr_PreSystemPoint,mbr_PointExtinctionAgree,mbr_PointExtinctionStartDate,mbr_PointUsePassword,mbr_CashReceiptDiv,mbr_CashReceiptAuthNo,mbr_CreditLimitAmt,mbr_CreditAmt,mbr_RegStore,mbr_LastVisitStore,mbr_LastVisitDate,mbr_SmsSendAgree,mbr_SmsFailCnt,mbr_LastSmsSendDate,mbr_ZipCode,mbr_Addr1,mbr_Addr2,mbr_TelNo,mbr_MobileNo,mbr_MobileNoEnc,mbr_Email,mbr_Gender,mbr_BirthType,mbr_Birthday,mbr_Anniversary,mbr_DeliveryZipCode,mbr_DeliveryAddr1,mbr_DeliveryAddr2,mbr_DeliveryRecvName,mbr_DeliveryMobileNoEnc1,mbr_DeliveryMobileNoEnc2,mbr_DeliveryMemo,mbr_PosMsg,mbr_DeliveryMsg,mbr_ExpireDate,mbr_Supplier,mbr_BizNo,mbr_BizName,mbr_BizCeo,mbr_BizType,mbr_BizCategory,mbr_TaxBillYn,mbr_LastTaxBillDate,mbr_TaxBillCycle,mbr_BankCode,mbr_AccountNo,mbr_AccountName,mbr_BuyCycle,mbr_InDate,mbr_InUser,mbr_ModDate,mbr_ModUser");
        stringBuilder.Append("\nFROM " + DbQueryHelper.ToDBNameBridge(uniMembers) + str + " " + DbQueryHelper.ToWithNolock());
        if (p_param is Hashtable hashtable2)
        {
          if (hashtable2.Count > 0)
            stringBuilder.Append("\n");
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        }
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
