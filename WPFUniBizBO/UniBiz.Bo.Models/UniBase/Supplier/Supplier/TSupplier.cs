// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Supplier.Supplier.TSupplier
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

namespace UniBiz.Bo.Models.UniBase.Supplier.Supplier
{
  public class TSupplier : UbModelBase<TSupplier>
  {
    private int _su_Supplier;
    private long _su_SiteID;
    private int _su_HeadSupplier;
    private string _su_SupplierViewCode;
    private string _su_SupplierName;
    private int _su_SupplierType;
    private int _su_SupplierKind;
    private string _su_UseYn;
    private int _su_PreTaxDiv;
    private int _su_MultiSuplierDiv;
    private int _su_DeductionDayDiv;
    private string _su_NewStatementYn;
    private string _su_Tel;
    private string _su_Fax;
    private string _su_BizNo;
    private string _su_BizName;
    private string _su_BizCeo;
    private string _su_BizType;
    private string _su_BizCategory;
    private string _su_RegidentNo;
    private string _su_Addr1;
    private string _su_Addr2;
    private string _su_ZipCode;
    private string _su_ContactNm1;
    private string _su_ContactMemo1;
    private string _su_ContactEmail1;
    private string _su_ContactNm2;
    private string _su_ContactMemo2;
    private string _su_ContactEmail2;
    private int _su_BankCode;
    private string _su_AccountNo;
    private string _su_AccountName;
    private string _su_Memo1;
    private string _su_Memo2;
    private int _su_LeadTime;
    private int _su_Deposit;
    private string _su_ErpCode;
    private string _su_EmailStatement;
    private string _su_EmailTax;
    private int _su_AssignUser;
    private DateTime? _su_InDate;
    private int _su_InUser;
    private DateTime? _su_ModDate;
    private int _su_ModUser;

    public override object _Key => (object) new object[1]
    {
      (object) this.su_Supplier
    };

    public int su_Supplier
    {
      get => this._su_Supplier;
      set
      {
        this._su_Supplier = value;
        this.Changed(nameof (su_Supplier));
      }
    }

    public long su_SiteID
    {
      get => this._su_SiteID;
      set
      {
        this._su_SiteID = value;
        this.Changed(nameof (su_SiteID));
      }
    }

    public int su_HeadSupplier
    {
      get => this._su_HeadSupplier;
      set
      {
        this._su_HeadSupplier = value;
        this.Changed(nameof (su_HeadSupplier));
      }
    }

    public string su_SupplierViewCode
    {
      get => this._su_SupplierViewCode;
      set
      {
        this._su_SupplierViewCode = UbModelBase.LeftStr(value, 6).Replace("'", "´");
        this.Changed(nameof (su_SupplierViewCode));
      }
    }

    public string su_SupplierName
    {
      get => this._su_SupplierName;
      set
      {
        this._su_SupplierName = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (su_SupplierName));
      }
    }

    public int su_SupplierType
    {
      get => this._su_SupplierType;
      set
      {
        this._su_SupplierType = value;
        this.Changed(nameof (su_SupplierType));
      }
    }

    public string su_SupplierTypeDesc => this.su_SupplierType != 0 ? Enum2StrConverter.ToSupplierType(this.su_SupplierType).ToDescription() : string.Empty;

    public int su_SupplierKind
    {
      get => this._su_SupplierKind;
      set
      {
        this._su_SupplierKind = value;
        this.Changed(nameof (su_SupplierKind));
      }
    }

    public string su_SupplierKindDesc => this.su_SupplierKind != 0 ? Enum2StrConverter.ToSupplierKind(this.su_SupplierKind).ToDescription() : string.Empty;

    public string su_UseYn
    {
      get => this._su_UseYn;
      set
      {
        this._su_UseYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (su_UseYn));
        this.Changed("su_IsUseYn");
        this.Changed("su_UseYnDesc");
      }
    }

    public bool su_IsUseYn => "Y".Equals(this.su_UseYn);

    public string su_UseYnDesc => !"Y".Equals(this.su_UseYn) ? "미사용" : "사용";

    public int su_PreTaxDiv
    {
      get => this._su_PreTaxDiv;
      set
      {
        this._su_PreTaxDiv = value;
        this.Changed(nameof (su_PreTaxDiv));
      }
    }

    public string su_PreTaxDivDesc => this.su_PreTaxDiv != 0 ? Enum2StrConverter.ToStdPreTax(this.su_PreTaxDiv).ToDescription() : string.Empty;

    public int su_MultiSuplierDiv
    {
      get => this._su_MultiSuplierDiv;
      set
      {
        this._su_MultiSuplierDiv = value;
        this.Changed(nameof (su_MultiSuplierDiv));
      }
    }

    public string su_MultiSuplierDivDesc => this.su_MultiSuplierDiv != 0 ? Enum2StrConverter.ToSupplierMulti(this.su_MultiSuplierDiv).ToDescription() : string.Empty;

    public int su_DeductionDayDiv
    {
      get => this._su_DeductionDayDiv;
      set
      {
        this._su_DeductionDayDiv = value;
        this.Changed(nameof (su_DeductionDayDiv));
      }
    }

    public string su_DeductionDayDivDesc => this.su_DeductionDayDiv != 0 ? Enum2StrConverter.ToSupplierDeductionDayType(this.su_DeductionDayDiv).ToDescription() : string.Empty;

    public string su_NewStatementYn
    {
      get => this._su_NewStatementYn;
      set
      {
        this._su_NewStatementYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (su_NewStatementYn));
        this.Changed("su_IsNewStatementYn");
        this.Changed("su_NewStatementYnDesc");
      }
    }

    public bool su_IsNewStatementYn => "Y".Equals(this.su_NewStatementYn);

    public string su_NewStatementYnDesc => !"Y".Equals(this.su_NewStatementYn) ? "미사용" : "사용";

    public string su_Tel
    {
      get => this._su_Tel;
      set
      {
        this._su_Tel = UbModelBase.LeftStr(value, 20).Replace("'", "´");
        this.Changed(nameof (su_Tel));
        this.Changed("su_DisplayTel");
      }
    }

    public string su_DisplayTel
    {
      get => this.su_Tel.GetDispPhoneNumber();
      set => this.su_Tel = value.Replace("-", string.Empty).Replace(")", string.Empty).ToString();
    }

    public string su_Fax
    {
      get => this._su_Fax;
      set
      {
        this._su_Fax = UbModelBase.LeftStr(value, 20).Replace("'", "´");
        this.Changed(nameof (su_Fax));
        this.Changed("su_DisplayFax");
      }
    }

    public string su_DisplayFax
    {
      get => this.su_Fax.GetDispPhoneNumber();
      set => this.su_Fax = value.Replace("-", string.Empty).Replace(")", string.Empty).ToString();
    }

    public string su_BizNo
    {
      get => this._su_BizNo;
      set
      {
        this._su_BizNo = UbModelBase.LeftStr(value, 15).Replace("'", "´");
        this.Changed(nameof (su_BizNo));
        this.Changed("su_BizNoDisp");
      }
    }

    public string su_BizNoDisp
    {
      get => this.su_BizNo.GetDispBizNumber();
      set
      {
        this.su_BizNo = value.Replace("-", string.Empty).ToString();
        this.Changed(nameof (su_BizNoDisp));
      }
    }

    public string su_BizName
    {
      get => this._su_BizName;
      set
      {
        this._su_BizName = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (su_BizName));
      }
    }

    public string su_BizCeo
    {
      get => this._su_BizCeo;
      set
      {
        this._su_BizCeo = UbModelBase.LeftStr(value, 50).Replace("'", "´");
        this.Changed(nameof (su_BizCeo));
      }
    }

    public string su_BizType
    {
      get => this._su_BizType;
      set
      {
        this._su_BizType = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (su_BizType));
      }
    }

    public string su_BizCategory
    {
      get => this._su_BizCategory;
      set
      {
        this._su_BizCategory = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (su_BizCategory));
      }
    }

    public string su_RegidentNo
    {
      get => this._su_RegidentNo;
      set
      {
        this._su_RegidentNo = UbModelBase.LeftStr(value, 50).Replace("'", "´");
        this.Changed(nameof (su_RegidentNo));
      }
    }

    public string su_Addr1
    {
      get => this._su_Addr1;
      set
      {
        this._su_Addr1 = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (su_Addr1));
      }
    }

    public string su_Addr2
    {
      get => this._su_Addr2;
      set
      {
        this._su_Addr2 = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (su_Addr2));
      }
    }

    public string su_ZipCode
    {
      get => this._su_ZipCode;
      set
      {
        this._su_ZipCode = UbModelBase.LeftStr(value, 7).Replace("'", "´");
        this.Changed(nameof (su_ZipCode));
      }
    }

    public string su_ContactNm1
    {
      get => this._su_ContactNm1;
      set
      {
        this._su_ContactNm1 = UbModelBase.LeftStr(value, 20).Replace("'", "´");
        this.Changed(nameof (su_ContactNm1));
      }
    }

    public string su_ContactMemo1
    {
      get => this._su_ContactMemo1;
      set
      {
        this._su_ContactMemo1 = UbModelBase.LeftStr(value, 20).Replace("'", "´");
        this.Changed(nameof (su_ContactMemo1));
      }
    }

    public string su_ContactEmail1
    {
      get => this._su_ContactEmail1;
      set
      {
        this._su_ContactEmail1 = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (su_ContactEmail1));
      }
    }

    public string su_ContactNm2
    {
      get => this._su_ContactNm2;
      set
      {
        this._su_ContactNm2 = UbModelBase.LeftStr(value, 20).Replace("'", "´");
        this.Changed(nameof (su_ContactNm2));
      }
    }

    public string su_ContactMemo2
    {
      get => this._su_ContactMemo2;
      set
      {
        this._su_ContactMemo2 = UbModelBase.LeftStr(value, 20).Replace("'", "´");
        this.Changed(nameof (su_ContactMemo2));
      }
    }

    public string su_ContactEmail2
    {
      get => this._su_ContactEmail2;
      set
      {
        this._su_ContactEmail2 = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (su_ContactEmail2));
      }
    }

    public int su_BankCode
    {
      get => this._su_BankCode;
      set
      {
        this._su_BankCode = value;
        this.Changed(nameof (su_BankCode));
        this.Changed("su_BankCodeDesc");
      }
    }

    public string su_BankCodeDesc => this.su_BankCode <= 0 ? string.Empty : Enum2StrConverter.ToCommonCodeTypeMemo(this.su_SiteID, EnumCommonCodeType.Bank, this.su_BankCode);

    public string su_AccountNo
    {
      get => this._su_AccountNo;
      set
      {
        this._su_AccountNo = UbModelBase.LeftStr(value, 30).Replace("'", "´");
        this.Changed(nameof (su_AccountNo));
      }
    }

    public string su_AccountName
    {
      get => this._su_AccountName;
      set
      {
        this._su_AccountName = UbModelBase.LeftStr(value, 30).Replace("'", "´");
        this.Changed(nameof (su_AccountName));
      }
    }

    public string su_Memo1
    {
      get => this._su_Memo1;
      set
      {
        this._su_Memo1 = UbModelBase.LeftStr(value, 200).Replace("'", "´");
        this.Changed(nameof (su_Memo1));
        this.Changed("su_Memo1EnterSkip");
      }
    }

    public string su_Memo1EnterSkip => this.su_Memo1.Replace("\r\n", "↵").Replace("\n", "↵");

    public string su_Memo2
    {
      get => this._su_Memo2;
      set
      {
        this._su_Memo2 = UbModelBase.LeftStr(value, 200).Replace("'", "´");
        this.Changed(nameof (su_Memo2));
        this.Changed("su_Memo2EnterSkip");
      }
    }

    public string su_Memo2EnterSkip => this.su_Memo2.Replace("\r\n", "↵").Replace("\n", "↵");

    public int su_LeadTime
    {
      get => this._su_LeadTime;
      set
      {
        this._su_LeadTime = value;
        this.Changed(nameof (su_LeadTime));
        this.Changed("su_LeadTimeDesc");
      }
    }

    public string su_LeadTimeDesc => this.su_LeadTime <= 0 ? string.Empty : Enum2StrConverter.ToCommonCodeTypeMemo(this.su_SiteID, EnumCommonCodeType.LeadTime, this.su_LeadTime);

    public int su_Deposit
    {
      get => this._su_Deposit;
      set
      {
        this._su_Deposit = value;
        this.Changed(nameof (su_Deposit));
      }
    }

    public string su_ErpCode
    {
      get => this._su_ErpCode;
      set
      {
        this._su_ErpCode = UbModelBase.LeftStr(value, 10).Replace("'", "´");
        this.Changed(nameof (su_ErpCode));
      }
    }

    public string su_EmailStatement
    {
      get => this._su_EmailStatement;
      set
      {
        this._su_EmailStatement = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (su_EmailStatement));
      }
    }

    public string su_EmailTax
    {
      get => this._su_EmailTax;
      set
      {
        this._su_EmailTax = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (su_EmailTax));
      }
    }

    public int su_AssignUser
    {
      get => this._su_AssignUser;
      set
      {
        this._su_AssignUser = value;
        this.Changed(nameof (su_AssignUser));
      }
    }

    public DateTime? su_InDate
    {
      get => this._su_InDate;
      set
      {
        this._su_InDate = value;
        this.Changed(nameof (su_InDate));
        this.Changed("ModDate");
      }
    }

    public int su_InUser
    {
      get => this._su_InUser;
      set
      {
        this._su_InUser = value;
        this.Changed(nameof (su_InUser));
      }
    }

    public DateTime? su_ModDate
    {
      get => this._su_ModDate;
      set
      {
        this._su_ModDate = value;
        this.Changed(nameof (su_ModDate));
        this.Changed("ModDate");
      }
    }

    public int su_ModUser
    {
      get => this._su_ModUser;
      set
      {
        this._su_ModUser = value;
        this.Changed(nameof (su_ModUser));
      }
    }

    public override DateTime? ModDate => !this.su_ModDate.HasValue ? this.su_InDate : this.su_ModDate;

    public TSupplier() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("su_Supplier", new TTableColumn()
      {
        tc_orgin_name = "su_Supplier",
        tc_trans_name = "코드"
      });
      columnInfo.Add("su_SiteID", new TTableColumn()
      {
        tc_orgin_name = "su_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("su_HeadSupplier", new TTableColumn()
      {
        tc_orgin_name = "su_HeadSupplier",
        tc_trans_name = "대표코드"
      });
      columnInfo.Add("su_SupplierViewCode", new TTableColumn()
      {
        tc_orgin_name = "su_SupplierViewCode",
        tc_trans_name = "식별코드"
      });
      columnInfo.Add("su_SupplierName", new TTableColumn()
      {
        tc_orgin_name = "su_SupplierName",
        tc_trans_name = "업체명"
      });
      columnInfo.Add("su_SupplierType", new TTableColumn()
      {
        tc_orgin_name = "su_SupplierType",
        tc_trans_name = "형태",
        tc_comm_code = 40
      });
      columnInfo.Add("su_SupplierKind", new TTableColumn()
      {
        tc_orgin_name = "su_SupplierKind",
        tc_trans_name = "타입",
        tc_comm_code = 41
      });
      columnInfo.Add("su_UseYn", new TTableColumn()
      {
        tc_orgin_name = "su_UseYn",
        tc_trans_name = "상태"
      });
      columnInfo.Add("su_PreTaxDiv", new TTableColumn()
      {
        tc_orgin_name = "su_PreTaxDiv",
        tc_trans_name = "기준단가",
        tc_comm_code = 42
      });
      columnInfo.Add("su_MultiSuplierDiv", new TTableColumn()
      {
        tc_orgin_name = "su_MultiSuplierDiv",
        tc_trans_name = "타사상품",
        tc_comm_code = 43
      });
      columnInfo.Add("su_DeductionDayDiv", new TTableColumn()
      {
        tc_orgin_name = "su_DeductionDayDiv",
        tc_trans_name = "자동공제",
        tc_comm_code = 44
      });
      columnInfo.Add("su_NewStatementYn", new TTableColumn()
      {
        tc_orgin_name = "su_NewStatementYn",
        tc_trans_name = "신규전표사용상태"
      });
      columnInfo.Add("su_Tel", new TTableColumn()
      {
        tc_orgin_name = "su_Tel",
        tc_trans_name = "전화"
      });
      columnInfo.Add("su_Fax", new TTableColumn()
      {
        tc_orgin_name = "su_Fax",
        tc_trans_name = "FAX"
      });
      columnInfo.Add("su_BizNo", new TTableColumn()
      {
        tc_orgin_name = "su_BizNo",
        tc_trans_name = "사업자번호"
      });
      columnInfo.Add("su_BizName", new TTableColumn()
      {
        tc_orgin_name = "su_BizName",
        tc_trans_name = "사업자명"
      });
      columnInfo.Add("su_BizCeo", new TTableColumn()
      {
        tc_orgin_name = "su_BizCeo",
        tc_trans_name = "대표자"
      });
      columnInfo.Add("su_BizType", new TTableColumn()
      {
        tc_orgin_name = "su_BizType",
        tc_trans_name = "업태"
      });
      columnInfo.Add("su_BizCategory", new TTableColumn()
      {
        tc_orgin_name = "su_BizCategory",
        tc_trans_name = "업종"
      });
      columnInfo.Add("su_Addr1", new TTableColumn()
      {
        tc_orgin_name = "su_Addr1",
        tc_trans_name = "주소"
      });
      columnInfo.Add("su_Addr2", new TTableColumn()
      {
        tc_orgin_name = "su_Addr2",
        tc_trans_name = "주소 상세"
      });
      columnInfo.Add("su_ZipCode", new TTableColumn()
      {
        tc_orgin_name = "su_ZipCode",
        tc_trans_name = "우편번호"
      });
      columnInfo.Add("su_ContactNm1", new TTableColumn()
      {
        tc_orgin_name = "su_ContactNm1",
        tc_trans_name = "담당자"
      });
      columnInfo.Add("su_ContactMemo1", new TTableColumn()
      {
        tc_orgin_name = "su_ContactMemo1",
        tc_trans_name = "담당자 연락처"
      });
      columnInfo.Add("su_ContactEmail1", new TTableColumn()
      {
        tc_orgin_name = "su_ContactEmail1",
        tc_trans_name = "담당자 이메일"
      });
      columnInfo.Add("su_ContactNm2", new TTableColumn()
      {
        tc_orgin_name = "su_ContactNm2",
        tc_trans_name = "담당자2"
      });
      columnInfo.Add("su_ContactMemo2", new TTableColumn()
      {
        tc_orgin_name = "su_ContactMemo2",
        tc_trans_name = "담당자2 연락처"
      });
      columnInfo.Add("su_ContactEmail2", new TTableColumn()
      {
        tc_orgin_name = "su_ContactEmail2",
        tc_trans_name = "담당자2 이메일"
      });
      columnInfo.Add("su_BankCode", new TTableColumn()
      {
        tc_orgin_name = "su_BankCode",
        tc_trans_name = "은행",
        tc_comm_code = 32
      });
      columnInfo.Add("su_AccountNo", new TTableColumn()
      {
        tc_orgin_name = "su_AccountNo",
        tc_trans_name = "계좌번호"
      });
      columnInfo.Add("su_AccountName", new TTableColumn()
      {
        tc_orgin_name = "su_AccountName",
        tc_trans_name = "예금주명"
      });
      columnInfo.Add("su_Memo1", new TTableColumn()
      {
        tc_orgin_name = "su_Memo1",
        tc_trans_name = "메모"
      });
      columnInfo.Add("su_Memo2", new TTableColumn()
      {
        tc_orgin_name = "su_Memo2",
        tc_trans_name = "메모 상세"
      });
      columnInfo.Add("su_LeadTime", new TTableColumn()
      {
        tc_orgin_name = "su_LeadTime",
        tc_trans_name = "리드타입",
        tc_comm_code = 110
      });
      columnInfo.Add("su_Deposit", new TTableColumn()
      {
        tc_orgin_name = "su_Deposit",
        tc_trans_name = "보증금"
      });
      columnInfo.Add("su_ErpCode", new TTableColumn()
      {
        tc_orgin_name = "su_ErpCode",
        tc_trans_name = "ERP 코드"
      });
      columnInfo.Add("su_EmailStatement", new TTableColumn()
      {
        tc_orgin_name = "su_EmailStatement",
        tc_trans_name = "전표용 이메일"
      });
      columnInfo.Add("su_EmailTax", new TTableColumn()
      {
        tc_orgin_name = "su_EmailTax",
        tc_trans_name = "계산서용 이메일"
      });
      columnInfo.Add("su_AssignUser", new TTableColumn()
      {
        tc_orgin_name = "su_AssignUser",
        tc_trans_name = "담당사원"
      });
      columnInfo.Add("su_InDate", new TTableColumn()
      {
        tc_orgin_name = "su_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("su_InUser", new TTableColumn()
      {
        tc_orgin_name = "su_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("su_ModDate", new TTableColumn()
      {
        tc_orgin_name = "su_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("su_ModUser", new TTableColumn()
      {
        tc_orgin_name = "su_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.Supplier;
      this.su_Supplier = 0;
      this.su_SiteID = 0L;
      this.su_HeadSupplier = 0;
      this.su_SupplierViewCode = string.Empty;
      this.su_SupplierName = string.Empty;
      this.su_SupplierType = this.su_SupplierKind = 0;
      this.su_UseYn = "Y";
      this.su_PreTaxDiv = this.su_MultiSuplierDiv = this.su_DeductionDayDiv = 0;
      this.su_NewStatementYn = "Y";
      this.su_Tel = string.Empty;
      this.su_Fax = string.Empty;
      this.su_BizNo = string.Empty;
      this.su_BizName = string.Empty;
      this.su_BizCeo = string.Empty;
      this.su_BizType = string.Empty;
      this.su_BizCategory = string.Empty;
      this.su_RegidentNo = string.Empty;
      this.su_Addr1 = string.Empty;
      this.su_Addr2 = string.Empty;
      this.su_ZipCode = string.Empty;
      this.su_ContactNm1 = string.Empty;
      this.su_ContactMemo1 = string.Empty;
      this.su_ContactEmail1 = string.Empty;
      this.su_ContactNm2 = string.Empty;
      this.su_ContactMemo2 = string.Empty;
      this.su_ContactEmail2 = string.Empty;
      this.su_BankCode = 0;
      this.su_AccountNo = string.Empty;
      this.su_AccountName = string.Empty;
      this.su_Memo1 = string.Empty;
      this.su_Memo2 = string.Empty;
      this.su_LeadTime = this.su_Deposit = 0;
      this.su_ErpCode = string.Empty;
      this.su_EmailStatement = string.Empty;
      this.su_EmailTax = string.Empty;
      this.su_InDate = new DateTime?();
      this.su_ModDate = new DateTime?();
      this.su_AssignUser = 0;
      this.su_InUser = this.su_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TSupplier();

    public override object Clone()
    {
      TSupplier tsupplier = base.Clone() as TSupplier;
      tsupplier.su_Supplier = this.su_Supplier;
      tsupplier.su_SiteID = this.su_SiteID;
      tsupplier.su_HeadSupplier = this.su_HeadSupplier;
      tsupplier.su_SupplierViewCode = this.su_SupplierViewCode;
      tsupplier.su_SupplierName = this.su_SupplierName;
      tsupplier.su_SupplierType = this.su_SupplierType;
      tsupplier.su_SupplierKind = this.su_SupplierKind;
      tsupplier.su_UseYn = this.su_UseYn;
      tsupplier.su_PreTaxDiv = this.su_PreTaxDiv;
      tsupplier.su_MultiSuplierDiv = this.su_MultiSuplierDiv;
      tsupplier.su_DeductionDayDiv = this.su_DeductionDayDiv;
      tsupplier.su_NewStatementYn = this.su_NewStatementYn;
      tsupplier.su_Tel = this.su_Tel;
      tsupplier.su_Fax = this.su_Fax;
      tsupplier.su_BizNo = this.su_BizNo;
      tsupplier.su_BizName = this.su_BizName;
      tsupplier.su_BizCeo = this.su_BizCeo;
      tsupplier.su_BizType = this.su_BizType;
      tsupplier.su_BizCategory = this.su_BizCategory;
      tsupplier.su_RegidentNo = this.su_RegidentNo;
      tsupplier.su_Addr1 = this.su_Addr1;
      tsupplier.su_Addr2 = this.su_Addr2;
      tsupplier.su_ZipCode = this.su_ZipCode;
      tsupplier.su_ContactNm1 = this.su_ContactNm1;
      tsupplier.su_ContactMemo1 = this.su_ContactMemo1;
      tsupplier.su_ContactEmail1 = this.su_ContactEmail1;
      tsupplier.su_ContactNm2 = this.su_ContactNm2;
      tsupplier.su_ContactMemo2 = this.su_ContactMemo2;
      tsupplier.su_ContactEmail2 = this.su_ContactEmail2;
      tsupplier.su_BankCode = this.su_BankCode;
      tsupplier.su_AccountNo = this.su_AccountNo;
      tsupplier.su_AccountName = this.su_AccountName;
      tsupplier.su_Memo1 = this.su_Memo1;
      tsupplier.su_Memo2 = this.su_Memo2;
      tsupplier.su_LeadTime = this.su_LeadTime;
      tsupplier.su_ErpCode = this.su_ErpCode;
      tsupplier.su_EmailStatement = this.su_EmailStatement;
      tsupplier.su_EmailTax = this.su_EmailTax;
      tsupplier.su_InDate = this.su_InDate;
      tsupplier.su_ModDate = this.su_ModDate;
      tsupplier.su_AssignUser = this.su_AssignUser;
      tsupplier.su_InUser = this.su_InUser;
      tsupplier.su_ModUser = this.su_ModUser;
      return (object) tsupplier;
    }

    public void PutData(TSupplier pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.su_Supplier = pSource.su_Supplier;
      this.su_SiteID = pSource.su_SiteID;
      this.su_HeadSupplier = pSource.su_HeadSupplier;
      this.su_SupplierViewCode = pSource.su_SupplierViewCode;
      this.su_SupplierName = pSource.su_SupplierName;
      this.su_SupplierType = pSource.su_SupplierType;
      this.su_SupplierKind = pSource.su_SupplierKind;
      this.su_UseYn = pSource.su_UseYn;
      this.su_PreTaxDiv = pSource.su_PreTaxDiv;
      this.su_MultiSuplierDiv = pSource.su_MultiSuplierDiv;
      this.su_DeductionDayDiv = pSource.su_DeductionDayDiv;
      this.su_NewStatementYn = pSource.su_NewStatementYn;
      this.su_Tel = pSource.su_Tel;
      this.su_Fax = pSource.su_Fax;
      this.su_BizNo = pSource.su_BizNo;
      this.su_BizName = pSource.su_BizName;
      this.su_BizCeo = pSource.su_BizCeo;
      this.su_BizType = pSource.su_BizType;
      this.su_BizCategory = pSource.su_BizCategory;
      this.su_RegidentNo = pSource.su_RegidentNo;
      this.su_Addr1 = pSource.su_Addr1;
      this.su_Addr2 = pSource.su_Addr2;
      this.su_ZipCode = pSource.su_ZipCode;
      this.su_ContactNm1 = pSource.su_ContactNm1;
      this.su_ContactMemo1 = pSource.su_ContactMemo1;
      this.su_ContactEmail1 = pSource.su_ContactEmail1;
      this.su_ContactNm2 = pSource.su_ContactNm2;
      this.su_ContactMemo2 = pSource.su_ContactMemo2;
      this.su_ContactEmail2 = pSource.su_ContactEmail2;
      this.su_BankCode = pSource.su_BankCode;
      this.su_AccountNo = pSource.su_AccountNo;
      this.su_AccountName = pSource.su_AccountName;
      this.su_Memo1 = pSource.su_Memo1;
      this.su_Memo2 = pSource.su_Memo2;
      this.su_LeadTime = pSource.su_LeadTime;
      this.su_ErpCode = pSource.su_ErpCode;
      this.su_EmailStatement = pSource.su_EmailStatement;
      this.su_EmailTax = pSource.su_EmailTax;
      this.su_InDate = pSource.su_InDate;
      this.su_ModDate = pSource.su_ModDate;
      this.su_AssignUser = pSource.su_AssignUser;
      this.su_InUser = pSource.su_InUser;
      this.su_ModUser = pSource.su_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.su_Supplier = p_rs.GetFieldInt("su_Supplier");
        if (this.su_Supplier == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.su_SiteID = p_rs.GetFieldLong("su_SiteID");
        this.su_HeadSupplier = p_rs.GetFieldInt("su_HeadSupplier");
        this.su_SupplierViewCode = p_rs.GetFieldString("su_SupplierViewCode");
        this.su_SupplierName = p_rs.GetFieldString("su_SupplierName");
        this.su_SupplierType = p_rs.GetFieldInt("su_SupplierType");
        this.su_UseYn = p_rs.GetFieldString("su_UseYn");
        this.su_PreTaxDiv = p_rs.GetFieldInt("su_PreTaxDiv");
        this.su_MultiSuplierDiv = p_rs.GetFieldInt("su_MultiSuplierDiv");
        this.su_DeductionDayDiv = p_rs.GetFieldInt("su_DeductionDayDiv");
        this.su_NewStatementYn = p_rs.GetFieldString("su_NewStatementYn");
        this.su_Tel = p_rs.GetFieldString("su_Tel");
        this.su_Fax = p_rs.GetFieldString("su_Fax");
        this.su_BizNo = p_rs.GetFieldString("su_BizNo");
        this.su_BizName = p_rs.GetFieldString("su_BizName");
        this.su_BizCeo = p_rs.GetFieldString("su_BizCeo");
        this.su_BizType = p_rs.GetFieldString("su_BizType");
        this.su_BizCategory = p_rs.GetFieldString("su_BizCategory");
        this.su_RegidentNo = p_rs.GetFieldString("su_RegidentNo");
        this.su_Addr1 = p_rs.GetFieldString("su_Addr1");
        this.su_Addr2 = p_rs.GetFieldString("su_Addr2");
        this.su_ZipCode = p_rs.GetFieldString("su_ZipCode");
        this.su_ContactNm1 = p_rs.GetFieldString("su_ContactNm1");
        this.su_ContactMemo1 = p_rs.GetFieldString("su_ContactMemo1");
        this.su_ContactEmail1 = p_rs.GetFieldString("su_ContactEmail1");
        this.su_ContactNm2 = p_rs.GetFieldString("su_ContactNm2");
        this.su_ContactMemo2 = p_rs.GetFieldString("su_ContactMemo2");
        this.su_ContactEmail2 = p_rs.GetFieldString("su_ContactEmail2");
        this.su_BankCode = p_rs.GetFieldInt("su_BankCode");
        this.su_AccountNo = p_rs.GetFieldString("su_AccountNo");
        this.su_AccountName = p_rs.GetFieldString("su_AccountName");
        this.su_Memo1 = p_rs.GetFieldString("su_Memo1");
        this.su_Memo2 = p_rs.GetFieldString("su_Memo2");
        this.su_LeadTime = p_rs.GetFieldInt("su_LeadTime");
        this.su_Deposit = p_rs.GetFieldInt("su_Deposit");
        this.su_ErpCode = p_rs.GetFieldString("su_ErpCode");
        this.su_EmailStatement = p_rs.GetFieldString("su_EmailStatement");
        this.su_EmailTax = p_rs.GetFieldString("su_EmailTax");
        this.su_AssignUser = p_rs.GetFieldInt("su_AssignUser");
        this.su_InDate = p_rs.GetFieldDateTime("su_InDate");
        this.su_InUser = p_rs.GetFieldInt("su_InUser");
        this.su_ModDate = p_rs.GetFieldDateTime("su_ModDate");
        this.su_ModUser = p_rs.GetFieldInt("su_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " su_Supplier,su_SiteID,su_HeadSupplier,su_SupplierViewCode,su_SupplierName,su_SupplierType,su_SupplierKind,su_UseYn,su_PreTaxDiv,su_MultiSuplierDiv,su_DeductionDayDiv,su_NewStatementYn,su_Tel,su_Fax,su_BizNo,su_BizName,su_BizCeo,su_BizType,su_BizCategory,su_RegidentNo,su_Addr1,su_Addr2,su_ZipCode,su_ContactNm1,su_ContactMemo1,su_ContactEmail1,su_ContactNm2,su_ContactMemo2,su_ContactEmail2,su_BankCode,su_AccountNo,su_AccountName,su_Memo1,su_Memo2,su_LeadTime,su_Deposit,su_ErpCode,su_EmailStatement,su_EmailTax,su_AssignUser,su_InDate,su_InUser,su_ModDate,su_ModUser) VALUES ( " + string.Format(" {0}", (object) this.su_Supplier) + string.Format(",{0},{1},'{2}','{3}'", (object) this.su_SiteID, (object) this.su_HeadSupplier, (object) this.su_SupplierViewCode, (object) this.su_SupplierName) + string.Format(",{0},{1},'{2}'", (object) this.su_SupplierType, (object) this.su_SupplierKind, (object) this.su_UseYn) + string.Format(",{0},{1},{2},'{3}'", (object) this.su_PreTaxDiv, (object) this.su_MultiSuplierDiv, (object) this.su_DeductionDayDiv, (object) this.su_NewStatementYn) + ",'" + this.su_Tel + "','" + this.su_Fax + "','" + this.su_BizNo + "','" + this.su_BizName + "','" + this.su_BizCeo + "','" + this.su_BizType + "','" + this.su_BizCategory + "','" + this.su_RegidentNo + "','" + this.su_Addr1 + "','" + this.su_Addr2 + "','" + this.su_ZipCode + "','" + this.su_ContactNm1 + "','" + this.su_ContactMemo1 + "','" + this.su_ContactEmail1 + "','" + this.su_ContactNm2 + "','" + this.su_ContactMemo2 + "','" + this.su_ContactEmail2 + "'" + string.Format(",{0},'{1}','{2}'", (object) this.su_BankCode, (object) this.su_AccountNo, (object) this.su_AccountName) + string.Format(",'{0}','{1}',{2},{3}", (object) this.su_Memo1, (object) this.su_Memo2, (object) this.su_LeadTime, (object) this.su_Deposit) + string.Format(",'{0}','{1}','{2}',{3}", (object) this.su_ErpCode, (object) this.su_EmailStatement, (object) this.su_EmailTax, (object) this.su_AssignUser) + string.Format(",{0},{1}", (object) this.su_InDate.GetDateToStrInNull(), (object) this.su_InUser) + string.Format(",{0},{1}", (object) this.su_ModDate.GetDateToStrInNull(), (object) this.su_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.su_Supplier, (object) this.su_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TSupplier tsupplier = this;
      // ISSUE: reference to a compiler-generated method
      tsupplier.\u003C\u003En__0();
      if (await tsupplier.OleDB.ExecuteAsync(tsupplier.InsertQuery()))
        return true;
      tsupplier.message = " " + tsupplier.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tsupplier.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tsupplier.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tsupplier.su_Supplier, (object) tsupplier.su_SiteID) + " 내용 : " + tsupplier.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tsupplier.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + string.Format(" {0}={1},{2}='{3}',{4}='{5}'", (object) "su_HeadSupplier", (object) this.su_HeadSupplier, (object) "su_SupplierViewCode", (object) this.su_SupplierViewCode, (object) "su_SupplierName", (object) this.su_SupplierName) + string.Format(",{0}={1},{2}='{3}'", (object) "su_SupplierKind", (object) this.su_SupplierKind, (object) "su_UseYn", (object) this.su_UseYn) + string.Format(",{0}={1},{2}={3},{4}={5},{6}='{7}'", (object) "su_PreTaxDiv", (object) this.su_PreTaxDiv, (object) "su_MultiSuplierDiv", (object) this.su_MultiSuplierDiv, (object) "su_DeductionDayDiv", (object) this.su_DeductionDayDiv, (object) "su_NewStatementYn", (object) this.su_NewStatementYn) + ",su_Tel='" + this.su_Tel + "',su_Fax='" + this.su_Fax + "',su_BizNo='" + this.su_BizNo + "',su_BizName='" + this.su_BizName + "',su_BizCeo='" + this.su_BizCeo + "',su_BizType='" + this.su_BizType + "',su_BizCategory='" + this.su_BizCategory + "',su_RegidentNo='" + this.su_RegidentNo + "',su_Addr1='" + this.su_Addr1 + "',su_Addr2='" + this.su_Addr2 + "',su_ZipCode='" + this.su_ZipCode + "',su_ContactNm1='" + this.su_ContactNm1 + "',su_ContactMemo1='" + this.su_ContactMemo1 + "',su_ContactEmail1='" + this.su_ContactEmail1 + "',su_ContactNm2='" + this.su_ContactNm2 + "',su_ContactMemo2='" + this.su_ContactMemo2 + "',su_ContactEmail2='" + this.su_ContactEmail2 + "'" + string.Format(",{0}={1},{2}='{3}',{4}='{5}'", (object) "su_BankCode", (object) this.su_BankCode, (object) "su_AccountNo", (object) this.su_AccountNo, (object) "su_AccountName", (object) this.su_AccountName) + string.Format(",{0}='{1}',{2}='{3}',{4}={5},{6}={7}", (object) "su_Memo1", (object) this.su_Memo1, (object) "su_Memo2", (object) this.su_Memo2, (object) "su_LeadTime", (object) this.su_LeadTime, (object) "su_Deposit", (object) this.su_Deposit) + ",su_ErpCode,su_EmailStatement,su_EmailTax,su_AssignUser" + string.Format(",{0}={1},{2}={3}", (object) "su_ModDate", (object) this.su_ModDate.GetDateToStrInNull(), (object) "su_ModUser", (object) this.su_ModUser) + string.Format(" WHERE {0}={1}", (object) "su_Supplier", (object) this.su_Supplier);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.su_Supplier, (object) this.su_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TSupplier tsupplier = this;
      // ISSUE: reference to a compiler-generated method
      tsupplier.\u003C\u003En__1();
      if (await tsupplier.OleDB.ExecuteAsync(tsupplier.UpdateQuery()))
        return true;
      tsupplier.message = " " + tsupplier.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tsupplier.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tsupplier.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tsupplier.su_Supplier, (object) tsupplier.su_SiteID) + " 내용 : " + tsupplier.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tsupplier.message);
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
      stringBuilder.Append(string.Format(" {0}={1},{2}='{3}',{4}='{5}'", (object) "su_HeadSupplier", (object) this.su_HeadSupplier, (object) "su_SupplierViewCode", (object) this.su_SupplierViewCode, (object) "su_SupplierName", (object) this.su_SupplierName) + string.Format(",{0}={1},{2}='{3}'", (object) "su_SupplierKind", (object) this.su_SupplierKind, (object) "su_UseYn", (object) this.su_UseYn) + string.Format(",{0}={1},{2}={3},{4}={5},{6}='{7}'", (object) "su_PreTaxDiv", (object) this.su_PreTaxDiv, (object) "su_MultiSuplierDiv", (object) this.su_MultiSuplierDiv, (object) "su_DeductionDayDiv", (object) this.su_DeductionDayDiv, (object) "su_NewStatementYn", (object) this.su_NewStatementYn) + ",su_Tel='" + this.su_Tel + "',su_Fax='" + this.su_Fax + "',su_BizNo='" + this.su_BizNo + "',su_BizName='" + this.su_BizName + "',su_BizCeo='" + this.su_BizCeo + "',su_BizType='" + this.su_BizType + "',su_BizCategory='" + this.su_BizCategory + "',su_RegidentNo='" + this.su_RegidentNo + "',su_Addr1='" + this.su_Addr1 + "',su_Addr2='" + this.su_Addr2 + "',su_ZipCode='" + this.su_ZipCode + "',su_ContactNm1='" + this.su_ContactNm1 + "',su_ContactMemo1='" + this.su_ContactMemo1 + "',su_ContactEmail1='" + this.su_ContactEmail1 + "',su_ContactNm2='" + this.su_ContactNm2 + "',su_ContactMemo2='" + this.su_ContactMemo2 + "',su_ContactEmail2='" + this.su_ContactEmail2 + "'" + string.Format(",{0}={1},{2}='{3}',{4}='{5}'", (object) "su_BankCode", (object) this.su_BankCode, (object) "su_AccountNo", (object) this.su_AccountNo, (object) "su_AccountName", (object) this.su_AccountName) + string.Format(",{0}='{1}',{2}='{3}',{4}={5},{6}={7}", (object) "su_Memo1", (object) this.su_Memo1, (object) "su_Memo2", (object) this.su_Memo2, (object) "su_LeadTime", (object) this.su_LeadTime, (object) "su_Deposit", (object) this.su_Deposit) + ",su_ErpCode,su_EmailStatement,su_EmailTax,su_AssignUser" + string.Format(",{0}={1},{2}={3}", (object) "su_ModDate", (object) this.su_ModDate.GetDateToStrInNull(), (object) "su_ModUser", (object) this.su_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.su_Supplier, (object) this.su_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TSupplier tsupplier = this;
      // ISSUE: reference to a compiler-generated method
      tsupplier.\u003C\u003En__1();
      if (await tsupplier.OleDB.ExecuteAsync(tsupplier.UpdateExInsertQuery()))
        return true;
      tsupplier.message = " " + tsupplier.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tsupplier.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tsupplier.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tsupplier.su_Supplier, (object) tsupplier.su_SiteID) + " 내용 : " + tsupplier.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tsupplier.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "su_SiteID") && Convert.ToInt64(hashtable[(object) "su_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "su_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "su_Supplier") && Convert.ToInt32(hashtable[(object) "su_Supplier"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "su_Supplier", hashtable[(object) "su_Supplier"]));
        else if (hashtable.ContainsKey((object) "su_Supplier_IN_") && hashtable[(object) "su_Supplier_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "su_Supplier", hashtable[(object) "su_Supplier_IN_"]));
        else if (hashtable.ContainsKey((object) "_IS_STORE_UP_") && Convert.ToBoolean(hashtable[(object) "_IS_STORE_UP_"].ToString()))
          stringBuilder.Append(string.Format(" AND {0} > {1}", (object) "su_Supplier", (object) 1001));
        else
          stringBuilder.Append(" AND su_Supplier > 0");
        if (hashtable.ContainsKey((object) "_SUPPLIER_AUTHS_") && hashtable[(object) "_SUPPLIER_AUTHS_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "su_Supplier", hashtable[(object) "_SUPPLIER_AUTHS_"]));
        if (hashtable.ContainsKey((object) "_IS_NOT_SUPPLIER_") && Convert.ToInt32(hashtable[(object) "_IS_NOT_SUPPLIER_"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0} != {1}", (object) "su_Supplier", (object) Convert.ToInt32(hashtable[(object) "_IS_NOT_SUPPLIER_"].ToString())));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "su_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "su_HeadSupplier") && Convert.ToInt32(hashtable[(object) "su_HeadSupplier"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "su_HeadSupplier", hashtable[(object) "su_HeadSupplier"]));
        else if (hashtable.ContainsKey((object) "su_HeadSupplier_IN_") && hashtable[(object) "su_HeadSupplier_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "su_HeadSupplier", hashtable[(object) "su_HeadSupplier_IN_"]));
        if (hashtable.ContainsKey((object) "su_SupplierViewCode") && hashtable[(object) "su_SupplierViewCode"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "su_SupplierViewCode", hashtable[(object) "su_SupplierViewCode"]));
        if (hashtable.ContainsKey((object) "su_SupplierName") && hashtable[(object) "su_SupplierName"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "su_SupplierName", hashtable[(object) "su_SupplierName"]));
        if (hashtable.ContainsKey((object) "su_SupplierType") && Convert.ToInt32(hashtable[(object) "su_SupplierType"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "su_SupplierType", hashtable[(object) "su_SupplierType"]));
        if (hashtable.ContainsKey((object) "su_SupplierKind") && Convert.ToInt32(hashtable[(object) "su_SupplierKind"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "su_SupplierKind", hashtable[(object) "su_SupplierKind"]));
        if (hashtable.ContainsKey((object) "su_UseYn") && hashtable[(object) "su_UseYn"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "su_UseYn", hashtable[(object) "su_UseYn"]));
        if (hashtable.ContainsKey((object) "su_PreTaxDiv") && Convert.ToInt32(hashtable[(object) "su_PreTaxDiv"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "su_PreTaxDiv", hashtable[(object) "su_PreTaxDiv"]));
        if (hashtable.ContainsKey((object) "su_MultiSuplierDiv") && Convert.ToInt32(hashtable[(object) "su_MultiSuplierDiv"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "su_MultiSuplierDiv", hashtable[(object) "su_MultiSuplierDiv"]));
        if (hashtable.ContainsKey((object) "su_DeductionDayDiv") && Convert.ToInt32(hashtable[(object) "su_DeductionDayDiv"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "su_DeductionDayDiv", hashtable[(object) "su_DeductionDayDiv"]));
        if (hashtable.ContainsKey((object) "su_NewStatementYn") && hashtable[(object) "su_NewStatementYn"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "su_NewStatementYn", hashtable[(object) "su_NewStatementYn"]));
        if (hashtable.ContainsKey((object) "su_BizNo") && hashtable[(object) "su_BizNo"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "su_BizNo", hashtable[(object) "su_BizNo"]));
        if (hashtable.ContainsKey((object) "su_BizCeo") && hashtable[(object) "su_BizCeo"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "su_BizCeo", hashtable[(object) "su_BizCeo"]));
        if (hashtable.ContainsKey((object) "su_AssignUser") && Convert.ToInt32(hashtable[(object) "su_AssignUser"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "su_AssignUser", hashtable[(object) "su_AssignUser"]));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "su_SupplierName", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "su_SupplierViewCode", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "su_BizCeo", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "su_BizNo", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "su_BizName", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "su_Tel", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "su_Fax", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "su_Memo1", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "su_Memo2", hashtable[(object) "_KEY_WORD_"]));
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
        string uniBase = UbModelBase.UNI_BASE;
        string str = this.TableCode.ToString();
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
        }
        stringBuilder.Append(" SELECT  su_Supplier,su_SiteID,su_HeadSupplier,su_SupplierViewCode,su_SupplierName,su_SupplierType,su_SupplierKind,su_UseYn,su_PreTaxDiv,su_MultiSuplierDiv,su_DeductionDayDiv,su_NewStatementYn,su_Tel,su_Fax,su_BizNo,su_BizName,su_BizCeo,su_BizType,su_BizCategory,su_RegidentNo,su_Addr1,su_Addr2,su_ZipCode,su_ContactNm1,su_ContactMemo1,su_ContactEmail1,su_ContactNm2,su_ContactMemo2,su_ContactEmail2,su_BankCode,su_AccountNo,su_AccountName,su_Memo1,su_Memo2,su_LeadTime,su_Deposit,su_ErpCode,su_EmailStatement,su_EmailTax,su_AssignUser,su_InDate,su_InUser,su_ModDate,su_ModUser");
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
