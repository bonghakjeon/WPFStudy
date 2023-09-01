// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Employee.Employee.TEmployee
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

namespace UniBiz.Bo.Models.UniBase.Employee.Employee
{
  public class TEmployee : UbModelBase<TEmployee>
  {
    private int _emp_Code;
    private long _emp_SiteID;
    private string _emp_Name;
    private int _emp_BaseStore;
    private string _emp_Dept;
    private int _emp_Position;
    private string _emp_ID;
    private string _emp_ProgPwd;
    private string _emp_PosID;
    private string _emp_PosPwd;
    private string _emp_UseYn;
    private string _emp_Tel;
    private string _emp_Mobile;
    private DateTime? _emp_EnterDate;
    private string _emp_RegidentNo;
    private string _emp_Email;
    private string _emp_EmailPwd;
    private string _emp_Zipcode;
    private string _emp_Addr1;
    private string _emp_Addr2;
    private int _emp_Gender;
    private int _emp_BirthType;
    private DateTime? _emp_Birthday;
    private DateTime? _emp_Anniversary;
    private int _emp_MenuGroupID;
    private int _emp_ProgAuth1;
    private int _emp_ProgAuth2;
    private int _emp_ProgAuth3;
    private DateTime? _emp_LoginLimitDate;
    private DateTime? _emp_PwdLimitDate;
    private int _emp_LoginDeny;
    private int _emp_ResignationStatus;
    private DateTime? _emp_ResignationDate;
    private int _emp_Job;
    private string _emp_ExtensionNumber;
    private DateTime? _emp_InDate;
    private int _emp_InUser;
    private DateTime? _emp_ModDate;
    private int _emp_ModUser;

    public override object _Key => (object) new object[1]
    {
      (object) this.emp_Code
    };

    public int emp_Code
    {
      get => this._emp_Code;
      set
      {
        this._emp_Code = value;
        this.Changed(nameof (emp_Code));
      }
    }

    public long emp_SiteID
    {
      get => this._emp_SiteID;
      set
      {
        this._emp_SiteID = value;
        this.Changed(nameof (emp_SiteID));
        this.Changed("emp_PositionDesc");
        this.Changed("emp_GenderDesc");
        this.Changed("emp_BirthTypeDesc");
        this.Changed("emp_MenuGroupIDDesc");
        this.Changed("emp_ResignationStatusDesc");
        this.Changed("emp_JobDesc");
      }
    }

    public string emp_Name
    {
      get => this._emp_Name;
      set
      {
        this._emp_Name = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (emp_Name));
      }
    }

    public int emp_BaseStore
    {
      get => this._emp_BaseStore;
      set
      {
        this._emp_BaseStore = value;
        this.Changed(nameof (emp_BaseStore));
      }
    }

    public string emp_Dept
    {
      get => this._emp_Dept;
      set
      {
        this._emp_Dept = UbModelBase.LeftStr(value, 6).Replace("'", "´");
        this.Changed(nameof (emp_Dept));
      }
    }

    public int emp_Position
    {
      get => this._emp_Position;
      set
      {
        this._emp_Position = value;
        this.Changed(nameof (emp_Position));
        this.Changed("emp_PositionDesc");
      }
    }

    public string emp_PositionDesc => this.emp_Position <= 0 ? string.Empty : Enum2StrConverter.ToCommonCodeTypeMemo(this.emp_SiteID, EnumCommonCodeType.EmpPosition, this.emp_Position);

    public string emp_ID
    {
      get => this._emp_ID;
      set
      {
        this._emp_ID = UbModelBase.LeftStr(value, 20).Replace("'", "´");
        this.Changed(nameof (emp_ID));
      }
    }

    [JsonIgnore]
    public string emp_ProgPwd
    {
      get => this._emp_ProgPwd;
      set
      {
        this._emp_ProgPwd = UbModelBase.LeftStr(value, 200).Replace("'", "´");
        this.Changed(nameof (emp_ProgPwd));
      }
    }

    public string emp_PosID
    {
      get => this._emp_PosID;
      set
      {
        this._emp_PosID = UbModelBase.LeftStr(value, 20).Replace("'", "´");
        this.Changed(nameof (emp_PosID));
      }
    }

    public string emp_PosPwd
    {
      get => this._emp_PosPwd;
      set
      {
        this._emp_PosPwd = UbModelBase.LeftStr(value, 200).Replace("'", "´");
        this.Changed(nameof (emp_PosPwd));
      }
    }

    public string emp_UseYn
    {
      get => this._emp_UseYn;
      set
      {
        this._emp_UseYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (emp_UseYn));
        this.Changed("emp_IsUse");
        this.Changed("emp_UseYnDesc");
      }
    }

    public bool emp_IsUse => "Y".Equals(this.emp_UseYn);

    public string emp_UseYnDesc => !"Y".Equals(this.emp_UseYn) ? "미사용" : "사용";

    public string emp_Tel
    {
      get => this._emp_Tel;
      set
      {
        this._emp_Tel = UbModelBase.LeftStr(value, 20).Replace("'", "´");
        this.Changed(nameof (emp_Tel));
        this.Changed("emp_DisplayTel");
      }
    }

    public string emp_DisplayTel
    {
      get => this.emp_Tel.GetDispPhoneNumber();
      set => this.emp_Tel = value.Replace("-", string.Empty).Replace(")", string.Empty).ToString();
    }

    public string emp_Mobile
    {
      get => this._emp_Mobile;
      set
      {
        this._emp_Mobile = UbModelBase.LeftStr(value, 20).Replace("'", "´");
        this.Changed(nameof (emp_Mobile));
        this.Changed("emp_DisplayMobile");
      }
    }

    public string emp_DisplayMobile
    {
      get => this.emp_Mobile.GetDispPhoneNumber();
      set => this.emp_Mobile = value.Replace("-", string.Empty).Replace(")", string.Empty).ToString();
    }

    public DateTime? emp_EnterDate
    {
      get => this._emp_EnterDate;
      set
      {
        this._emp_EnterDate = value;
        this.Changed(nameof (emp_EnterDate));
      }
    }

    public string emp_RegidentNo
    {
      get => this._emp_RegidentNo;
      set
      {
        this._emp_RegidentNo = UbModelBase.LeftStr(value, 50).Replace("'", "´");
        this.Changed(nameof (emp_RegidentNo));
      }
    }

    public string emp_Email
    {
      get => this._emp_Email;
      set
      {
        this._emp_Email = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (emp_Email));
      }
    }

    public string emp_EmailPwd
    {
      get => this._emp_EmailPwd;
      set
      {
        this._emp_EmailPwd = UbModelBase.LeftStr(value, 200).Replace("'", "´");
        this.Changed(nameof (emp_EmailPwd));
      }
    }

    public string emp_Zipcode
    {
      get => this._emp_Zipcode;
      set
      {
        this._emp_Zipcode = UbModelBase.LeftStr(value, 7).Replace("'", "´");
        this.Changed(nameof (emp_Zipcode));
      }
    }

    public string emp_Addr1
    {
      get => this._emp_Addr1;
      set
      {
        this._emp_Addr1 = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (emp_Addr1));
      }
    }

    public string emp_Addr2
    {
      get => this._emp_Addr2;
      set
      {
        this._emp_Addr2 = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (emp_Addr2));
      }
    }

    public int emp_Gender
    {
      get => this._emp_Gender;
      set
      {
        this._emp_Gender = value;
        this.Changed(nameof (emp_Gender));
        this.Changed("emp_GenderDesc");
      }
    }

    public string emp_GenderDesc => this.emp_Gender <= 0 ? string.Empty : Enum2StrConverter.ToCommonCodeTypeMemo(this.emp_SiteID, EnumCommonCodeType.Gender, this.emp_Gender);

    public int emp_BirthType
    {
      get => this._emp_BirthType;
      set
      {
        this._emp_BirthType = value;
        this.Changed(nameof (emp_BirthType));
        this.Changed("emp_BirthTypeDesc");
      }
    }

    public string emp_BirthTypeDesc => this.emp_BirthType <= 0 ? string.Empty : Enum2StrConverter.ToCommonCodeTypeMemo(this.emp_SiteID, EnumCommonCodeType.MonthCalendarType, this.emp_BirthType);

    public DateTime? emp_Birthday
    {
      get => this._emp_Birthday;
      set
      {
        this._emp_Birthday = value;
        this.Changed(nameof (emp_Birthday));
      }
    }

    public DateTime? emp_Anniversary
    {
      get => this._emp_Anniversary;
      set
      {
        this._emp_Anniversary = value;
        this.Changed(nameof (emp_Anniversary));
      }
    }

    public int emp_MenuGroupID
    {
      get => this._emp_MenuGroupID;
      set
      {
        this._emp_MenuGroupID = value;
        this.Changed(nameof (emp_MenuGroupID));
        this.Changed("emp_MenuGroupIDDesc");
      }
    }

    public string emp_MenuGroupIDDesc => this.emp_MenuGroupID <= 0 ? string.Empty : Enum2StrConverter.ToCommonCodeTypeMemo(this.emp_SiteID, EnumCommonCodeType.UserMenuGroup, this.emp_MenuGroupID);

    public int emp_ProgAuth1
    {
      get => this._emp_ProgAuth1;
      set
      {
        this._emp_ProgAuth1 = value;
        this.Changed(nameof (emp_ProgAuth1));
        this.Changed("IsSystem");
        this.Changed("IsAgent");
        this.Changed("IsAdmin");
        this.Changed("IsPermitPrint");
        this.Changed("IsPermitExcel");
        this.Changed("IsPermitSMS");
        this.Changed("IsPermitEmail");
        this.Changed("IsGoodsSave");
        this.Changed("IsGoodsSavePriceExcept");
        this.Changed("IsStoreInsert");
        this.Changed("IsStoreUpdate");
        this.Changed("IsStore");
        this.Changed("IsEmployeeSave");
        this.Changed("IsEmployeePermitSave");
        this.Changed("IsSupplierSave");
        this.Changed("IsMasterCommonSave");
        this.Changed("IsSalesGoalSave");
        this.Changed("IsMemberTypeSave");
        this.Changed("IsMemberStdSave");
        this.Changed("IsMemberTaxPublish");
        this.Changed("IsPaymentInput");
        this.Changed("IsPaymentConfirm");
        this.Changed("IsPaymentDelete");
        this.Changed("IsPaymentClosed");
        this.Changed("IsPayment");
        this.Changed("IsInvtClosed");
        this.Changed("IsCampaignSave");
        this.Changed("IsPromotionSave");
        this.Changed("IsCouponSave");
      }
    }

    public bool IsSystem => EmployeeConverter.IsSystem(this.emp_ProgAuth1);

    public bool IsAgent => EmployeeConverter.IsAgent(this.emp_ProgAuth1);

    public bool IsAdmin => EmployeeConverter.IsAdmin(this.emp_ProgAuth1);

    public bool IsPermitPrint => EmployeeConverter.IsPermitPrint(this.emp_ProgAuth1);

    public bool IsPermitExcel => EmployeeConverter.IsPermitExcel(this.emp_ProgAuth1);

    public bool IsPermitSMS => EmployeeConverter.IsPermitSMS(this.emp_ProgAuth1);

    public bool IsPermitEmail => EmployeeConverter.IsPermitEmail(this.emp_ProgAuth1);

    public bool IsGoodsSave => EmployeeConverter.IsGoodsSave(this.emp_ProgAuth1);

    public bool IsGoodsSavePriceExcept => EmployeeConverter.IsGoodsSavePriceExcept(this.emp_ProgAuth1);

    public bool IsStoreInsert => EmployeeConverter.IsStoreInsert(this.emp_ProgAuth1);

    public bool IsStoreUpdate => EmployeeConverter.IsStoreUpdate(this.emp_ProgAuth1);

    public bool IsStore => this.IsStoreInsert || this.IsStoreUpdate;

    public bool IsEmployeeSave => EmployeeConverter.IsEmployeeSave(this.emp_ProgAuth1);

    public bool IsEmployeePermitSave => EmployeeConverter.IsEmployeePermitSave(this.emp_ProgAuth1);

    public bool IsSupplierSave => EmployeeConverter.IsSupplierSave(this.emp_ProgAuth1);

    public bool IsMasterCommonSave => EmployeeConverter.IsMasterCommonSave(this.emp_ProgAuth1);

    public bool IsSalesGoalSave => EmployeeConverter.IsSalesGoalSave(this.emp_ProgAuth1);

    public bool IsMemberTypeSave => EmployeeConverter.IsMemberTypeSave(this.emp_ProgAuth1);

    public bool IsMemberStdSave => EmployeeConverter.IsMemberStdSave(this.emp_ProgAuth1);

    public bool IsMemberTaxPublish => EmployeeConverter.IsMemberTaxPublish(this.emp_ProgAuth1);

    public bool IsPaymentInput => EmployeeConverter.IsPaymentInput(this.emp_ProgAuth1);

    public bool IsPaymentConfirm => EmployeeConverter.IsPaymentConfirm(this.emp_ProgAuth1);

    public bool IsPaymentDelete => EmployeeConverter.IsPaymentDelete(this.emp_ProgAuth1);

    public bool IsPaymentClosed => EmployeeConverter.IsPaymentClosed(this.emp_ProgAuth1);

    [JsonIgnore]
    public bool IsPayment => this.IsPaymentInput || this.IsPaymentConfirm || this.IsPaymentDelete;

    public bool IsInvtClosed => EmployeeConverter.IsInvtClosed(this.emp_ProgAuth1);

    public bool IsCampaignSave => EmployeeConverter.IsCampaignSave(this.emp_ProgAuth1);

    public bool IsPromotionSave => EmployeeConverter.IsPromotionSave(this.emp_ProgAuth1);

    public bool IsCouponSave => EmployeeConverter.IsCouponSave(this.emp_ProgAuth1);

    public int emp_ProgAuth2
    {
      get => this._emp_ProgAuth2;
      set
      {
        this._emp_ProgAuth2 = value;
        this.Changed(nameof (emp_ProgAuth2));
        this.Changed("IsOrderInput");
        this.Changed("IsOrderConfirm");
        this.Changed("IsOrderDelete");
        this.Changed("IsOrderMove");
        this.Changed("IsOrder");
        this.Changed("IsBuyInput");
        this.Changed("IsBuyConfirm");
        this.Changed("IsBuyDelete");
        this.Changed("IsBuy");
        this.Changed("IsOuterMoveInput");
        this.Changed("IsOuterMoveConfirm");
        this.Changed("IsOuterMoveDelete");
        this.Changed("IsOuterMove");
        this.Changed("IsInnerMoveInput");
        this.Changed("IsInnerMoveConfirm");
        this.Changed("IsInnerMoveDelete");
        this.Changed("IsInnerMove");
        this.Changed("IsAdjustInput");
        this.Changed("IsAdjustConfirm");
        this.Changed("IsAdjustDelete");
        this.Changed("IsAdjust");
        this.Changed("IsDisuseInput");
        this.Changed("IsDisuseConfirm");
        this.Changed("IsDisuseDelete");
        this.Changed("IsDisuse");
        this.Changed("IsStockInventoryInput");
        this.Changed("IsStockInventoryConfirm");
        this.Changed("IsStockInventoryDelete");
        this.Changed("IsStockInventory");
        this.Changed("IsAutoOrderSet");
      }
    }

    public bool IsOrderInput => this.IsAdmin || EmployeeConverter.IsOrderInput(this.emp_ProgAuth2);

    public bool IsOrderConfirm => this.IsAdmin || EmployeeConverter.IsOrderConfirm(this.emp_ProgAuth2);

    public bool IsOrderDelete => this.IsAdmin || EmployeeConverter.IsOrderDelete(this.emp_ProgAuth2);

    public bool IsOrderMove => this.IsAdmin || EmployeeConverter.IsOrderMove(this.emp_ProgAuth2);

    [JsonIgnore]
    public bool IsOrder => this.IsOrderInput || this.IsOrderConfirm || this.IsOrderDelete;

    public bool IsBuyInput => this.IsAdmin || EmployeeConverter.IsBuyInput(this.emp_ProgAuth2);

    public bool IsBuyConfirm => this.IsAdmin || EmployeeConverter.IsBuyConfirm(this.emp_ProgAuth2);

    public bool IsBuyDelete => this.IsAdmin || EmployeeConverter.IsBuyDelete(this.emp_ProgAuth2);

    [JsonIgnore]
    public bool IsBuy => this.IsBuyInput || this.IsBuyConfirm || this.IsBuyDelete;

    public bool IsOuterMoveInput => this.IsAdmin || EmployeeConverter.IsOuterMoveInput(this.emp_ProgAuth2);

    public bool IsOuterMoveConfirm => this.IsAdmin || EmployeeConverter.IsOuterMoveConfirm(this.emp_ProgAuth2);

    public bool IsOuterMoveDelete => this.IsAdmin || EmployeeConverter.IsOuterMoveDelete(this.emp_ProgAuth2);

    [JsonIgnore]
    public bool IsOuterMove => this.IsOuterMoveInput || this.IsOuterMoveConfirm || this.IsOuterMoveDelete;

    public bool IsInnerMoveInput => this.IsAdmin || EmployeeConverter.IsInnerMoveInput(this.emp_ProgAuth2);

    public bool IsInnerMoveConfirm => this.IsAdmin || EmployeeConverter.IsInnerMoveConfirm(this.emp_ProgAuth2);

    public bool IsInnerMoveDelete => this.IsAdmin || EmployeeConverter.IsInnerMoveDelete(this.emp_ProgAuth2);

    [JsonIgnore]
    public bool IsInnerMove => this.IsInnerMoveInput || this.IsInnerMoveConfirm || this.IsInnerMoveDelete;

    public bool IsAdjustInput => this.IsAdmin || EmployeeConverter.IsAdjustInput(this.emp_ProgAuth2);

    public bool IsAdjustConfirm => this.IsAdmin || EmployeeConverter.IsAdjustConfirm(this.emp_ProgAuth2);

    public bool IsAdjustDelete => this.IsAdmin || EmployeeConverter.IsAdjustDelete(this.emp_ProgAuth2);

    [JsonIgnore]
    public bool IsAdjust => this.IsAdjustInput || this.IsAdjustConfirm || this.IsAdjustDelete;

    public bool IsDisuseInput => this.IsAdmin || EmployeeConverter.IsDisuseInput(this.emp_ProgAuth2);

    public bool IsDisuseConfirm => this.IsAdmin || EmployeeConverter.IsDisuseConfirm(this.emp_ProgAuth2);

    public bool IsDisuseDelete => this.IsAdmin || EmployeeConverter.IsDisuseDelete(this.emp_ProgAuth2);

    [JsonIgnore]
    public bool IsDisuse => this.IsDisuseInput || this.IsDisuseConfirm || this.IsDisuseDelete;

    public bool IsStockInventoryInput => this.IsAdmin || EmployeeConverter.IsStockInventoryInput(this.emp_ProgAuth2);

    public bool IsStockInventoryConfirm => this.IsAdmin || EmployeeConverter.IsStockInventoryConfirm(this.emp_ProgAuth2);

    public bool IsStockInventoryDelete => this.IsAdmin || EmployeeConverter.IsStockInventoryDelete(this.emp_ProgAuth2);

    [JsonIgnore]
    public bool IsStockInventory => this.IsStockInventoryInput || this.IsStockInventoryConfirm || this.IsStockInventoryDelete;

    public bool IsAutoOrderSet => this.IsAdmin || EmployeeConverter.IsAutoOrderSet(this.emp_ProgAuth2);

    public int emp_ProgAuth3
    {
      get => this._emp_ProgAuth3;
      set
      {
        this._emp_ProgAuth3 = value;
        this.Changed(nameof (emp_ProgAuth3));
      }
    }

    public DateTime? emp_LoginLimitDate
    {
      get => this._emp_LoginLimitDate;
      set
      {
        this._emp_LoginLimitDate = value;
        this.Changed(nameof (emp_LoginLimitDate));
      }
    }

    public DateTime? emp_PwdLimitDate
    {
      get => this._emp_PwdLimitDate;
      set
      {
        this._emp_PwdLimitDate = value;
        this.Changed(nameof (emp_PwdLimitDate));
      }
    }

    public int emp_LoginDeny
    {
      get => this._emp_LoginDeny;
      set
      {
        this._emp_LoginDeny = value;
        this.Changed(nameof (emp_LoginDeny));
      }
    }

    public int emp_ResignationStatus
    {
      get => this._emp_ResignationStatus;
      set
      {
        this._emp_ResignationStatus = value;
        this.Changed(nameof (emp_ResignationStatus));
        this.Changed("emp_ResignationStatusDesc");
      }
    }

    public string emp_ResignationStatusDesc => this.emp_ResignationStatus <= 0 ? string.Empty : Enum2StrConverter.ToCommonCodeTypeMemo(this.emp_SiteID, EnumCommonCodeType.EmpResignStatus, this.emp_ResignationStatus);

    public DateTime? emp_ResignationDate
    {
      get => this._emp_ResignationDate;
      set
      {
        this._emp_ResignationDate = value;
        this.Changed(nameof (emp_ResignationDate));
      }
    }

    public int emp_Job
    {
      get => this._emp_Job;
      set
      {
        this._emp_Job = value;
        this.Changed(nameof (emp_Job));
        this.Changed("emp_JobDesc");
      }
    }

    public string emp_JobDesc => this.emp_Job <= 0 ? string.Empty : Enum2StrConverter.ToCommonCodeTypeMemo(this.emp_SiteID, EnumCommonCodeType.EmpJob, this.emp_Job);

    public string emp_ExtensionNumber
    {
      get => this._emp_ExtensionNumber;
      set
      {
        this._emp_ExtensionNumber = UbModelBase.LeftStr(value, 20).Replace("'", "´");
        this.Changed(nameof (emp_ExtensionNumber));
      }
    }

    public DateTime? emp_InDate
    {
      get => this._emp_InDate;
      set
      {
        this._emp_InDate = value;
        this.Changed(nameof (emp_InDate));
        this.Changed("ModDate");
      }
    }

    public int emp_InUser
    {
      get => this._emp_InUser;
      set
      {
        this._emp_InUser = value;
        this.Changed(nameof (emp_InUser));
      }
    }

    public DateTime? emp_ModDate
    {
      get => this._emp_ModDate;
      set
      {
        this._emp_ModDate = value;
        this.Changed(nameof (emp_ModDate));
        this.Changed("ModDate");
      }
    }

    public int emp_ModUser
    {
      get => this._emp_ModUser;
      set
      {
        this._emp_ModUser = value;
        this.Changed(nameof (emp_ModUser));
      }
    }

    public override DateTime? ModDate => !this.emp_ModDate.HasValue ? this.emp_InDate : this.emp_ModDate;

    public TEmployee() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("emp_Code", new TTableColumn()
      {
        tc_orgin_name = "emp_Code",
        tc_trans_name = "사원코드"
      });
      columnInfo.Add("emp_SiteID", new TTableColumn()
      {
        tc_orgin_name = "emp_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("emp_Name", new TTableColumn()
      {
        tc_orgin_name = "emp_Name",
        tc_trans_name = "사원명"
      });
      columnInfo.Add("emp_BaseStore", new TTableColumn()
      {
        tc_orgin_name = "emp_BaseStore",
        tc_trans_name = "시작지점"
      });
      columnInfo.Add("emp_Dept", new TTableColumn()
      {
        tc_orgin_name = "emp_Dept",
        tc_trans_name = "부서"
      });
      columnInfo.Add("emp_Position", new TTableColumn()
      {
        tc_orgin_name = "emp_Position",
        tc_trans_name = "직위",
        tc_comm_code = 35
      });
      columnInfo.Add("emp_ID", new TTableColumn()
      {
        tc_orgin_name = "emp_ID",
        tc_trans_name = "ID "
      });
      columnInfo.Add("emp_ProgPwd", new TTableColumn()
      {
        tc_orgin_name = "emp_ProgPwd",
        tc_trans_name = "패스워드"
      });
      columnInfo.Add("emp_PosID", new TTableColumn()
      {
        tc_orgin_name = "emp_PosID",
        tc_trans_name = "포스 ID"
      });
      columnInfo.Add("emp_PosPwd", new TTableColumn()
      {
        tc_orgin_name = "emp_PosPwd",
        tc_trans_name = "포스 패스워드"
      });
      columnInfo.Add("emp_UseYn", new TTableColumn()
      {
        tc_orgin_name = "emp_UseYn",
        tc_trans_name = "사용상태"
      });
      columnInfo.Add("emp_Tel", new TTableColumn()
      {
        tc_orgin_name = "emp_Tel",
        tc_trans_name = "전화"
      });
      columnInfo.Add("emp_Mobile", new TTableColumn()
      {
        tc_orgin_name = "emp_Mobile",
        tc_trans_name = "모바일"
      });
      columnInfo.Add("emp_EnterDate", new TTableColumn()
      {
        tc_orgin_name = "emp_EnterDate",
        tc_trans_name = "입사일"
      });
      columnInfo.Add("emp_RegidentNo", new TTableColumn()
      {
        tc_orgin_name = "emp_RegidentNo",
        tc_trans_name = "주민번호"
      });
      columnInfo.Add("emp_Email", new TTableColumn()
      {
        tc_orgin_name = "emp_Email",
        tc_trans_name = "이메일"
      });
      columnInfo.Add("emp_EmailPwd", new TTableColumn()
      {
        tc_orgin_name = "emp_EmailPwd",
        tc_trans_name = "이메일패스워드"
      });
      columnInfo.Add("emp_Zipcode", new TTableColumn()
      {
        tc_orgin_name = "emp_Zipcode",
        tc_trans_name = "우편번호"
      });
      columnInfo.Add("emp_Addr1", new TTableColumn()
      {
        tc_orgin_name = "emp_Addr1",
        tc_trans_name = "주소"
      });
      columnInfo.Add("emp_Addr2", new TTableColumn()
      {
        tc_orgin_name = "emp_Addr2",
        tc_trans_name = "주소 상세"
      });
      columnInfo.Add("emp_Gender", new TTableColumn()
      {
        tc_orgin_name = "emp_Gender",
        tc_trans_name = "성별",
        tc_comm_code = 100
      });
      columnInfo.Add("emp_BirthType", new TTableColumn()
      {
        tc_orgin_name = "emp_BirthType",
        tc_trans_name = "양/음력",
        tc_comm_code = 101
      });
      columnInfo.Add("emp_Birthday", new TTableColumn()
      {
        tc_orgin_name = "emp_Birthday",
        tc_trans_name = "생년월일"
      });
      columnInfo.Add("emp_Anniversary", new TTableColumn()
      {
        tc_orgin_name = "emp_Anniversary",
        tc_trans_name = "기념일"
      });
      columnInfo.Add("emp_MenuGroupID", new TTableColumn()
      {
        tc_orgin_name = "emp_MenuGroupID",
        tc_trans_name = "화면권한ID",
        tc_comm_code = 4
      });
      columnInfo.Add("emp_ProgAuth1", new TTableColumn()
      {
        tc_orgin_name = "emp_ProgAuth1",
        tc_trans_name = "작업 권한1"
      });
      columnInfo.Add("emp_ProgAuth2", new TTableColumn()
      {
        tc_orgin_name = "emp_ProgAuth2",
        tc_trans_name = "작업 권한2"
      });
      columnInfo.Add("emp_ProgAuth3", new TTableColumn()
      {
        tc_orgin_name = "emp_ProgAuth3",
        tc_trans_name = "작업 권한3"
      });
      columnInfo.Add("emp_LoginLimitDate", new TTableColumn()
      {
        tc_orgin_name = "emp_LoginLimitDate",
        tc_trans_name = "로그인 만료일"
      });
      columnInfo.Add("emp_PwdLimitDate", new TTableColumn()
      {
        tc_orgin_name = "emp_PwdLimitDate",
        tc_trans_name = "패스워드 만료일"
      });
      columnInfo.Add("emp_LoginDeny", new TTableColumn()
      {
        tc_orgin_name = "emp_LoginDeny",
        tc_trans_name = "접속거절"
      });
      columnInfo.Add("emp_ResignationStatus", new TTableColumn()
      {
        tc_orgin_name = "emp_ResignationStatus",
        tc_trans_name = "퇴사여부",
        tc_comm_code = 234
      });
      columnInfo.Add("emp_ResignationDate", new TTableColumn()
      {
        tc_orgin_name = "emp_ResignationDate",
        tc_trans_name = "퇴사일자"
      });
      columnInfo.Add("emp_Job", new TTableColumn()
      {
        tc_orgin_name = "emp_Job",
        tc_trans_name = "직책",
        tc_comm_code = 233
      });
      columnInfo.Add("emp_ExtensionNumber", new TTableColumn()
      {
        tc_orgin_name = "emp_ExtensionNumber",
        tc_trans_name = "내선번호"
      });
      columnInfo.Add("emp_InDate", new TTableColumn()
      {
        tc_orgin_name = "emp_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("emp_InUser", new TTableColumn()
      {
        tc_orgin_name = "emp_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("emp_ModDate", new TTableColumn()
      {
        tc_orgin_name = "emp_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("emp_ModUser", new TTableColumn()
      {
        tc_orgin_name = "emp_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.Employee;
      this.emp_Code = 0;
      this.emp_SiteID = 0L;
      this.emp_BaseStore = this.emp_Position = 0;
      this.emp_Name = string.Empty;
      this.emp_Dept = string.Empty;
      this.emp_ID = string.Empty;
      this.emp_ProgPwd = string.Empty;
      this.emp_PosID = string.Empty;
      this.emp_PosPwd = string.Empty;
      this.emp_UseYn = "Y";
      this.emp_Tel = string.Empty;
      this.emp_Mobile = string.Empty;
      this.emp_EnterDate = new DateTime?();
      this.emp_RegidentNo = string.Empty;
      this.emp_Email = string.Empty;
      this.emp_EmailPwd = string.Empty;
      this.emp_Zipcode = string.Empty;
      this.emp_Addr1 = string.Empty;
      this.emp_Addr2 = string.Empty;
      this.emp_Gender = this.emp_BirthType = 0;
      this.emp_Birthday = new DateTime?();
      this.emp_Anniversary = new DateTime?();
      this.emp_MenuGroupID = this.emp_ProgAuth1 = this.emp_ProgAuth2 = this.emp_ProgAuth3 = 0;
      this.emp_LoginLimitDate = new DateTime?();
      this.emp_PwdLimitDate = new DateTime?();
      this.emp_LoginDeny = 0;
      this.emp_ResignationDate = new DateTime?();
      this.emp_ResignationStatus = 0;
      this.emp_Job = 0;
      this.emp_ExtensionNumber = string.Empty;
      this.emp_InDate = new DateTime?();
      this.emp_ModDate = new DateTime?();
      this.emp_InUser = this.emp_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TEmployee();

    public override object Clone()
    {
      TEmployee temployee = base.Clone() as TEmployee;
      temployee.emp_Code = this.emp_Code;
      temployee.emp_SiteID = this.emp_SiteID;
      temployee.emp_BaseStore = this.emp_BaseStore;
      temployee.emp_Position = this.emp_Position;
      temployee.emp_Name = this.emp_Name;
      temployee.emp_Dept = this.emp_Dept;
      temployee.emp_ID = this.emp_ID;
      temployee.emp_ProgPwd = this.emp_ProgPwd;
      temployee.emp_PosID = this.emp_PosID;
      temployee.emp_PosPwd = this.emp_PosPwd;
      temployee.emp_UseYn = this.emp_UseYn;
      temployee.emp_Tel = this.emp_Tel;
      temployee.emp_Mobile = this.emp_Mobile;
      temployee.emp_EnterDate = this.emp_EnterDate;
      temployee.emp_RegidentNo = this.emp_RegidentNo;
      temployee.emp_Email = this.emp_Email;
      temployee.emp_EmailPwd = this.emp_EmailPwd;
      temployee.emp_Zipcode = this.emp_Zipcode;
      temployee.emp_Addr1 = this.emp_Addr1;
      temployee.emp_Addr2 = this.emp_Addr2;
      temployee.emp_Gender = this.emp_Gender;
      temployee.emp_BirthType = this.emp_BirthType;
      temployee.emp_Birthday = this.emp_Birthday;
      temployee.emp_Anniversary = this.emp_Anniversary;
      temployee.emp_MenuGroupID = this.emp_MenuGroupID;
      temployee.emp_ProgAuth1 = this.emp_ProgAuth1;
      temployee.emp_ProgAuth2 = this.emp_ProgAuth2;
      temployee.emp_ProgAuth3 = this.emp_ProgAuth3;
      temployee.emp_LoginLimitDate = this.emp_LoginLimitDate;
      temployee.emp_PwdLimitDate = this.emp_PwdLimitDate;
      temployee.emp_LoginDeny = this.emp_LoginDeny;
      temployee.emp_ResignationDate = this.emp_ResignationDate;
      temployee.emp_ResignationStatus = this.emp_ResignationStatus;
      temployee.emp_Job = this.emp_Job;
      temployee.emp_ExtensionNumber = this.emp_ExtensionNumber;
      temployee.emp_InDate = this.emp_InDate;
      temployee.emp_ModDate = this.emp_ModDate;
      temployee.emp_InUser = this.emp_InUser;
      temployee.emp_ModUser = this.emp_ModUser;
      return (object) temployee;
    }

    public void PutData(TEmployee pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.emp_Code = pSource.emp_Code;
      this.emp_SiteID = pSource.emp_SiteID;
      this.emp_BaseStore = pSource.emp_BaseStore;
      this.emp_Position = pSource.emp_Position;
      this.emp_Name = pSource.emp_Name;
      this.emp_Dept = pSource.emp_Dept;
      this.emp_ID = pSource.emp_ID;
      this.emp_ProgPwd = pSource.emp_ProgPwd;
      this.emp_PosID = pSource.emp_PosID;
      this.emp_PosPwd = pSource.emp_PosPwd;
      this.emp_UseYn = pSource.emp_UseYn;
      this.emp_Tel = pSource.emp_Tel;
      this.emp_Mobile = pSource.emp_Mobile;
      this.emp_EnterDate = pSource.emp_EnterDate;
      this.emp_RegidentNo = pSource.emp_RegidentNo;
      this.emp_Email = pSource.emp_Email;
      this.emp_EmailPwd = pSource.emp_EmailPwd;
      this.emp_Zipcode = pSource.emp_Zipcode;
      this.emp_Addr1 = pSource.emp_Addr1;
      this.emp_Addr2 = pSource.emp_Addr2;
      this.emp_Gender = pSource.emp_Gender;
      this.emp_BirthType = pSource.emp_BirthType;
      this.emp_Birthday = pSource.emp_Birthday;
      this.emp_Anniversary = pSource.emp_Anniversary;
      this.emp_MenuGroupID = pSource.emp_MenuGroupID;
      this.emp_ProgAuth1 = pSource.emp_ProgAuth1;
      this.emp_ProgAuth2 = pSource.emp_ProgAuth2;
      this.emp_ProgAuth3 = pSource.emp_ProgAuth3;
      this.emp_LoginLimitDate = pSource.emp_LoginLimitDate;
      this.emp_PwdLimitDate = pSource.emp_PwdLimitDate;
      this.emp_LoginDeny = pSource.emp_LoginDeny;
      this.emp_ResignationDate = pSource.emp_ResignationDate;
      this.emp_ResignationStatus = pSource.emp_ResignationStatus;
      this.emp_Job = pSource.emp_Job;
      this.emp_ExtensionNumber = pSource.emp_ExtensionNumber;
      this.emp_InDate = pSource.emp_InDate;
      this.emp_ModDate = pSource.emp_ModDate;
      this.emp_InUser = pSource.emp_InUser;
      this.emp_ModUser = pSource.emp_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.emp_Code = p_rs.GetFieldInt("emp_Code");
        if (this.emp_Code == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.emp_SiteID = p_rs.GetFieldLong("emp_SiteID");
        this.emp_BaseStore = p_rs.GetFieldInt("emp_BaseStore");
        this.emp_Position = p_rs.GetFieldInt("emp_Position");
        this.emp_Name = p_rs.GetFieldString("emp_Name");
        this.emp_Dept = p_rs.GetFieldString("emp_Dept");
        this.emp_ID = p_rs.GetFieldString("emp_ID");
        this.emp_ProgPwd = p_rs.GetFieldString("emp_ProgPwd");
        this.emp_PosID = p_rs.GetFieldString("emp_PosID");
        this.emp_PosPwd = p_rs.GetFieldString("emp_PosPwd");
        this.emp_UseYn = p_rs.GetFieldString("emp_UseYn");
        this.emp_Tel = p_rs.GetFieldString("emp_Tel");
        this.emp_Mobile = p_rs.GetFieldString("emp_Mobile");
        this.emp_EnterDate = p_rs.GetFieldDateTime("emp_EnterDate");
        this.emp_RegidentNo = p_rs.GetFieldString("emp_RegidentNo");
        this.emp_Email = p_rs.GetFieldString("emp_Email");
        this.emp_EmailPwd = p_rs.GetFieldString("emp_EmailPwd");
        this.emp_Zipcode = p_rs.GetFieldString("emp_Zipcode");
        this.emp_Addr1 = p_rs.GetFieldString("emp_Addr1");
        this.emp_Addr2 = p_rs.GetFieldString("emp_Addr2");
        this.emp_Gender = p_rs.GetFieldInt("emp_Gender");
        this.emp_BirthType = p_rs.GetFieldInt("emp_BirthType");
        this.emp_Birthday = p_rs.GetFieldDateTime("emp_Birthday");
        this.emp_Anniversary = p_rs.GetFieldDateTime("emp_Anniversary");
        this.emp_MenuGroupID = p_rs.GetFieldInt("emp_MenuGroupID");
        this.emp_ProgAuth1 = p_rs.GetFieldInt("emp_ProgAuth1");
        this.emp_ProgAuth2 = p_rs.GetFieldInt("emp_ProgAuth2");
        this.emp_ProgAuth3 = p_rs.GetFieldInt("emp_ProgAuth3");
        this.emp_LoginLimitDate = p_rs.GetFieldDateTime("emp_LoginLimitDate");
        this.emp_PwdLimitDate = p_rs.GetFieldDateTime("emp_PwdLimitDate");
        this.emp_LoginDeny = p_rs.GetFieldInt("emp_LoginDeny");
        this.emp_ResignationDate = p_rs.GetFieldDateTime("emp_ResignationDate");
        this.emp_ResignationStatus = p_rs.GetFieldInt("emp_ResignationStatus");
        this.emp_Job = p_rs.GetFieldInt("emp_Job");
        this.emp_ExtensionNumber = p_rs.GetFieldString("emp_ExtensionNumber");
        this.emp_InDate = p_rs.GetFieldDateTime("emp_InDate");
        this.emp_InUser = p_rs.GetFieldInt("emp_InUser");
        this.emp_ModDate = p_rs.GetFieldDateTime("emp_ModDate");
        this.emp_ModUser = p_rs.GetFieldInt("emp_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " emp_Code,emp_SiteID,emp_BaseStore,emp_Position,emp_Name,emp_Dept,emp_ID,emp_ProgPwd,emp_PosID,emp_PosPwd,emp_UseYn,emp_Tel,emp_Mobile,emp_EnterDate,emp_RegidentNo,emp_Email,emp_EmailPwd,emp_Zipcode,emp_Addr1,emp_Addr2,emp_Gender,emp_BirthType,emp_Birthday,emp_Anniversary,emp_MenuGroupID,emp_ProgAuth1,emp_ProgAuth2,emp_ProgAuth3,emp_LoginLimitDate,emp_PwdLimitDate,emp_LoginDeny,emp_ResignationStatus,emp_ResignationDate,emp_Job,emp_ExtensionNumber,emp_InDate,emp_InUser,emp_ModDate,emp_ModUser) VALUES ( " + string.Format(" {0}", (object) this.emp_Code) + string.Format(",{0},{1},{2},'{3}','{4}'", (object) this.emp_SiteID, (object) this.emp_BaseStore, (object) this.emp_Position, (object) this.emp_Name, (object) this.emp_Dept) + ",'" + this.emp_ID + "','" + this.emp_ProgPwd + "','" + this.emp_PosID + "','" + this.emp_PosPwd + "','" + this.emp_UseYn + "','" + this.emp_Tel + "','" + this.emp_Mobile + "'," + this.emp_EnterDate.GetDateToStrInNull() + ",'" + this.emp_RegidentNo + "','" + this.emp_Email + "','" + this.emp_EmailPwd + "','" + this.emp_Zipcode + "','" + this.emp_Addr1 + "','" + this.emp_Addr2 + "'" + string.Format(",{0},{1}", (object) this.emp_Gender, (object) this.emp_BirthType) + "," + this.emp_Birthday.GetDateToStrInNull() + "," + this.emp_Anniversary.GetDateToStrInNull() + string.Format(",{0},{1},{2},{3}", (object) this.emp_MenuGroupID, (object) this.emp_ProgAuth1, (object) this.emp_ProgAuth2, (object) this.emp_ProgAuth3) + "," + this.emp_LoginLimitDate.GetDateToStrInNull() + "," + this.emp_PwdLimitDate.GetDateToStrInNull() + string.Format(",{0}", (object) this.emp_LoginDeny) + string.Format(",{0},{1},{2},'{3}'", (object) this.emp_ResignationStatus, (object) this.emp_ResignationDate.GetDateToStrInNull(), (object) this.emp_Job, (object) this.emp_ExtensionNumber) + string.Format(",{0},{1}", (object) this.emp_InDate.GetDateToStrInNull(), (object) this.emp_InUser) + string.Format(",{0},{1}", (object) this.emp_ModDate.GetDateToStrInNull(), (object) this.emp_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : {0}\n", (object) this.emp_Code) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TEmployee temployee = this;
      // ISSUE: reference to a compiler-generated method
      temployee.\u003C\u003En__0();
      if (await temployee.OleDB.ExecuteAsync(temployee.InsertQuery()))
        return true;
      temployee.message = " " + temployee.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + temployee.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) temployee.OleDB.LastErrorID) + string.Format(" 코드 : {0}\n", (object) temployee.emp_Code) + " 내용 : " + temployee.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(temployee.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + string.Format(" {0}={1},{2}={3}", (object) "emp_BaseStore", (object) this.emp_BaseStore, (object) "emp_Position", (object) this.emp_Position) + ",emp_Name='" + this.emp_Name + "',emp_Dept='" + this.emp_Dept + "',emp_ID='" + this.emp_ID + "',emp_ProgPwd='" + this.emp_ProgPwd + "',emp_PosID='" + this.emp_PosID + "',emp_PosPwd='" + this.emp_PosPwd + "',emp_UseYn='" + this.emp_UseYn + "',emp_Tel='" + this.emp_Tel + "',emp_Mobile='" + this.emp_Mobile + "',emp_EnterDate=" + this.emp_EnterDate.GetDateToStrInNull() + ",emp_RegidentNo='" + this.emp_RegidentNo + "',emp_Email='" + this.emp_Email + "',emp_EmailPwd='" + this.emp_EmailPwd + "',emp_Zipcode='" + this.emp_Zipcode + "',emp_Addr1='" + this.emp_Addr1 + "',emp_Addr2='" + this.emp_Addr2 + "'" + string.Format(",{0}={1},{2}={3}", (object) "emp_Gender", (object) this.emp_Gender, (object) "emp_BirthType", (object) this.emp_BirthType) + ",emp_Birthday=" + this.emp_Birthday.GetDateToStrInNull() + ",emp_Anniversary=" + this.emp_Anniversary.GetDateToStrInNull() + string.Format(",{0}={1},{2}={3},{4}='{5}',{6}={7}", (object) "emp_MenuGroupID", (object) this.emp_MenuGroupID, (object) "emp_ProgAuth1", (object) this.emp_ProgAuth1, (object) "emp_ProgAuth2", (object) this.emp_ProgAuth2, (object) "emp_ProgAuth3", (object) this.emp_ProgAuth3) + string.Format(",{0}={1},{2}={3},{4}={5}", (object) "emp_LoginLimitDate", (object) this.emp_LoginLimitDate.GetDateToStrInNull(), (object) "emp_PwdLimitDate", (object) this.emp_PwdLimitDate.GetDateToStrInNull(), (object) "emp_LoginDeny", (object) this.emp_LoginDeny) + string.Format(",{0}={1},{2}={3}", (object) "emp_ResignationStatus", (object) this.emp_ResignationStatus, (object) "emp_ResignationDate", (object) this.emp_ResignationDate.GetDateToStrInNull()) + string.Format(",{0}={1},{2}='{3}'", (object) "emp_Job", (object) this.emp_Job, (object) "emp_ExtensionNumber", (object) this.emp_ExtensionNumber) + string.Format(",{0}={1},{2}={3}", (object) "emp_ModDate", (object) this.emp_ModDate.GetDateToStrInNull(), (object) "emp_ModUser", (object) this.emp_ModUser) + string.Format(" WHERE {0}={1}", (object) "emp_Code", (object) this.emp_Code);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : {0}\n", (object) this.emp_Code) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TEmployee temployee = this;
      // ISSUE: reference to a compiler-generated method
      temployee.\u003C\u003En__1();
      if (await temployee.OleDB.ExecuteAsync(temployee.UpdateQuery()))
        return true;
      temployee.message = " " + temployee.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + temployee.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) temployee.OleDB.LastErrorID) + string.Format(" 코드 : {0}\n", (object) temployee.emp_Code) + " 내용 : " + temployee.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(temployee.message);
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
      stringBuilder.Append(string.Format(" {0}={1},{2}={3}", (object) "emp_BaseStore", (object) this.emp_BaseStore, (object) "emp_Position", (object) this.emp_Position) + ",emp_Name='" + this.emp_Name + "',emp_Dept='" + this.emp_Dept + "',emp_ID='" + this.emp_ID + "',emp_ProgPwd='" + this.emp_ProgPwd + "',emp_PosID='" + this.emp_PosID + "',emp_PosPwd='" + this.emp_PosPwd + "',emp_UseYn='" + this.emp_UseYn + "',emp_Tel='" + this.emp_Tel + "',emp_Mobile='" + this.emp_Mobile + "',emp_EnterDate=" + this.emp_EnterDate.GetDateToStrInNull() + ",emp_RegidentNo='" + this.emp_RegidentNo + "',emp_Email='" + this.emp_Email + "',emp_EmailPwd='" + this.emp_EmailPwd + "',emp_Zipcode='" + this.emp_Zipcode + "',emp_Addr1='" + this.emp_Addr1 + "',emp_Addr2='" + this.emp_Addr2 + "'" + string.Format(",{0}={1},{2}={3}", (object) "emp_Gender", (object) this.emp_Gender, (object) "emp_BirthType", (object) this.emp_BirthType) + ",emp_Birthday=" + this.emp_Birthday.GetDateToStrInNull() + ",emp_Anniversary=" + this.emp_Anniversary.GetDateToStrInNull() + string.Format(",{0}={1},{2}={3},{4}='{5}',{6}={7}", (object) "emp_MenuGroupID", (object) this.emp_MenuGroupID, (object) "emp_ProgAuth1", (object) this.emp_ProgAuth1, (object) "emp_ProgAuth2", (object) this.emp_ProgAuth2, (object) "emp_ProgAuth3", (object) this.emp_ProgAuth3) + string.Format(",{0}={1},{2}={3},{4}={5}", (object) "emp_LoginLimitDate", (object) this.emp_LoginLimitDate.GetDateToStrInNull(), (object) "emp_PwdLimitDate", (object) this.emp_PwdLimitDate.GetDateToStrInNull(), (object) "emp_LoginDeny", (object) this.emp_LoginDeny) + string.Format(",{0}={1},{2}={3}", (object) "emp_ResignationStatus", (object) this.emp_ResignationStatus, (object) "emp_ResignationDate", (object) this.emp_ResignationDate.GetDateToStrInNull()) + string.Format(",{0}={1},{2}='{3}'", (object) "emp_Job", (object) this.emp_Job, (object) "emp_ExtensionNumber", (object) this.emp_ExtensionNumber) + string.Format(",{0}={1},{2}={3}", (object) "emp_ModDate", (object) this.emp_ModDate.GetDateToStrInNull(), (object) "emp_ModUser", (object) this.emp_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : {0}\n", (object) this.emp_Code) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TEmployee temployee = this;
      // ISSUE: reference to a compiler-generated method
      temployee.\u003C\u003En__1();
      if (await temployee.OleDB.ExecuteAsync(temployee.UpdateExInsertQuery()))
        return true;
      temployee.message = " " + temployee.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + temployee.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) temployee.OleDB.LastErrorID) + string.Format(" 코드 : {0}\n", (object) temployee.emp_Code) + " 내용 : " + temployee.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(temployee.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "emp_SiteID") && Convert.ToInt64(hashtable[(object) "emp_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "emp_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "emp_Code") && Convert.ToInt32(hashtable[(object) "emp_Code"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "emp_Code", hashtable[(object) "emp_Code"]));
        else
          stringBuilder.Append(" AND emp_Code > 0");
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "emp_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "emp_Name") && hashtable[(object) "emp_Name"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "emp_Name", hashtable[(object) "emp_Name"]));
        if (hashtable.ContainsKey((object) "emp_BaseStore") && Convert.ToInt32(hashtable[(object) "emp_BaseStore"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "emp_BaseStore", hashtable[(object) "emp_BaseStore"]));
        else if (hashtable.ContainsKey((object) "emp_BaseStore_IN_") && hashtable[(object) "emp_BaseStore_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "emp_BaseStore", hashtable[(object) "emp_BaseStore_IN_"]));
        else if (hashtable.ContainsKey((object) "_STORE_AUTHS_") && hashtable[(object) "_STORE_AUTHS_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "emp_BaseStore", hashtable[(object) "_STORE_AUTHS_"]));
        else
          stringBuilder.Append(" AND emp_BaseStore > 0");
        if (hashtable.ContainsKey((object) "emp_Position") && Convert.ToInt32(hashtable[(object) "emp_Position"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "emp_Position", hashtable[(object) "emp_Position"]));
        if (hashtable.ContainsKey((object) "emp_ID") && hashtable[(object) "emp_ID"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "emp_ID", hashtable[(object) "emp_ID"]));
        if (hashtable.ContainsKey((object) "emp_PosID") && hashtable[(object) "emp_PosID"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "emp_PosID", hashtable[(object) "emp_PosID"]));
        if (hashtable.ContainsKey((object) "emp_UseYn") && hashtable[(object) "emp_UseYn"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "emp_UseYn", hashtable[(object) "emp_UseYn"]));
        if (hashtable.ContainsKey((object) "emp_Job") && Convert.ToInt32(hashtable[(object) "emp_Job"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "emp_Job", hashtable[(object) "emp_Job"]));
        if (hashtable.ContainsKey((object) "emp_ResignationStatus") && Convert.ToInt32(hashtable[(object) "emp_ResignationStatus"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "emp_ResignationStatus", hashtable[(object) "emp_ResignationStatus"]));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "emp_Name", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "emp_ID", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "emp_Tel", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%')", (object) "emp_Mobile", hashtable[(object) "_KEY_WORD_"]));
        }
      }
      return !stringBuilder.ToString().Equals(" WHERE") ? stringBuilder.Replace("WHERE AND", "WHERE").ToString() : string.Empty;
    }

    public override string GetSelectQuery(object p_param)
    {
      StringBuilder stringBuilder = new StringBuilder();
      try
      {
        string uniBase = UbModelBase.UNI_BASE;
        string str = this.TableCode.ToString();
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
        }
        stringBuilder.Append(" SELECT  emp_Code,emp_SiteID,emp_BaseStore,emp_Position,emp_Name,emp_Dept,emp_ID,emp_ProgPwd,emp_PosID,emp_PosPwd,emp_UseYn,emp_Tel,emp_Mobile,emp_EnterDate,emp_RegidentNo,emp_Email,emp_EmailPwd,emp_Zipcode,emp_Addr1,emp_Addr2,emp_Gender,emp_BirthType,emp_Birthday,emp_Anniversary,emp_MenuGroupID,emp_ProgAuth1,emp_ProgAuth2,emp_ProgAuth3,emp_LoginLimitDate,emp_PwdLimitDate,emp_LoginDeny,emp_ResignationStatus,emp_ResignationDate,emp_Job,emp_ExtensionNumber,emp_InDate,emp_InUser,emp_ModDate,emp_ModUser");
        stringBuilder.Append(" FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock());
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
