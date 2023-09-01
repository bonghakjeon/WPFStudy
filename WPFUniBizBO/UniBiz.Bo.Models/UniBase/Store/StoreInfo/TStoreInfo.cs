// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Store.StoreInfo.TStoreInfo
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

namespace UniBiz.Bo.Models.UniBase.Store.StoreInfo
{
  public class TStoreInfo : UbModelBase<TStoreInfo>
  {
    private int _si_StoreCode;
    private long _si_SiteID;
    private int _si_StoreType;
    private string _si_StoreViewCode;
    private string _si_StoreName;
    private string _si_Tel1;
    private string _si_Tel2;
    private string _si_LocalIP;
    private string _si_PublicIP;
    private string _si_UseYn;
    private string _si_ErpCode;
    private DateTime? _si_ErpUpdateDate;
    private string _si_BizNo;
    private string _si_BizName;
    private string _si_BizCeo;
    private string _si_BizType;
    private string _si_BizCategory;
    private string _si_BizAddr1;
    private string _si_BizAddr2;
    private string _si_ZipCode;
    private DateTime? _si_BuyConfirmDate;
    private DateTime? _si_StockConfirmDate;
    private DateTime? _si_StockStartDate;
    private DateTime? _si_SaleConfirmDate;
    private int _si_SortNo;
    private int _si_MemberMntStore;
    private string _si_WeatherCode;
    private string _si_Email;
    private string _si_EmailPwd;
    private string _si_LocationUseYn;
    private double _si_AutoOrderSafetyFactor;
    private int _si_AutoOrderOpt;
    private int _si_AutoOrderRef;
    private DateTime? _si_InDate;
    private int _si_InUser;
    private DateTime? _si_ModDate;
    private int _si_ModUser;

    public override object _Key => (object) new object[1]
    {
      (object) this.si_StoreCode
    };

    public int si_StoreCode
    {
      get => this._si_StoreCode;
      set
      {
        this._si_StoreCode = value;
        this.Changed(nameof (si_StoreCode));
      }
    }

    public long si_SiteID
    {
      get => this._si_SiteID;
      set
      {
        this._si_SiteID = value;
        this.Changed(nameof (si_SiteID));
      }
    }

    public int si_StoreType
    {
      get => this._si_StoreType;
      set
      {
        this._si_StoreType = value;
        this.Changed(nameof (si_StoreType));
        this.Changed("si_StoreTypeDesc");
      }
    }

    public string si_StoreTypeDesc => this.si_StoreType != 0 ? Enum2StrConverter.ToStoreType(this.si_StoreType).ToDescription() : string.Empty;

    public string si_StoreViewCode
    {
      get => this._si_StoreViewCode;
      set
      {
        this._si_StoreViewCode = UbModelBase.LeftStr(value, 6).Replace("'", "´");
        this.Changed(nameof (si_StoreViewCode));
      }
    }

    public string si_StoreName
    {
      get => this._si_StoreName;
      set
      {
        this._si_StoreName = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (si_StoreName));
      }
    }

    public string si_Tel1
    {
      get => this._si_Tel1;
      set
      {
        this._si_Tel1 = UbModelBase.LeftStr(value, 20).Replace("'", "´");
        this.Changed(nameof (si_Tel1));
      }
    }

    public string si_Tel2
    {
      get => this._si_Tel2;
      set
      {
        this._si_Tel2 = UbModelBase.LeftStr(value, 20).Replace("'", "´");
        this.Changed(nameof (si_Tel2));
      }
    }

    public string si_LocalIP
    {
      get => this._si_LocalIP;
      set
      {
        this._si_LocalIP = UbModelBase.LeftStr(value, 20).Replace("'", "´");
        this.Changed(nameof (si_LocalIP));
      }
    }

    public string si_PublicIP
    {
      get => this._si_PublicIP;
      set
      {
        this._si_PublicIP = UbModelBase.LeftStr(value, 20).Replace("'", "´");
        this.Changed(nameof (si_PublicIP));
      }
    }

    public string si_UseYn
    {
      get => this._si_UseYn;
      set
      {
        this._si_UseYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (si_UseYn));
        this.Changed("si_IsUseYn");
        this.Changed("si_UseYnDesc");
      }
    }

    public bool si_IsUseYn => "Y".Equals(this.si_UseYn);

    public string si_UseYnDesc => !"Y".Equals(this.si_UseYn) ? "미사용" : "사용";

    public string si_ErpCode
    {
      get => this._si_ErpCode;
      set
      {
        this._si_ErpCode = UbModelBase.LeftStr(value, 10);
        this.Changed(nameof (si_ErpCode));
      }
    }

    public DateTime? si_ErpUpdateDate
    {
      get => this._si_ErpUpdateDate;
      set
      {
        this._si_ErpUpdateDate = value;
        this.Changed(nameof (si_ErpUpdateDate));
      }
    }

    public string si_BizNo
    {
      get => this._si_BizNo;
      set
      {
        this._si_BizNo = UbModelBase.LeftStr(value, 15).Replace("'", "´");
        this.Changed(nameof (si_BizNo));
      }
    }

    public string si_DisplayBizNo
    {
      get => this.si_BizNo.GetDispBizNumber();
      set => this.si_BizNo = value.Replace("-", string.Empty).ToString();
    }

    public string si_BizName
    {
      get => this._si_BizName;
      set
      {
        this._si_BizName = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (si_BizName));
      }
    }

    public string si_BizCeo
    {
      get => this._si_BizCeo;
      set
      {
        this._si_BizCeo = UbModelBase.LeftStr(value, 50).Replace("'", "´");
        this.Changed(nameof (si_BizCeo));
      }
    }

    public string si_BizType
    {
      get => this._si_BizType;
      set
      {
        this._si_BizType = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (si_BizType));
      }
    }

    public string si_BizCategory
    {
      get => this._si_BizCategory;
      set
      {
        this._si_BizCategory = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (si_BizCategory));
      }
    }

    public string si_BizAddr1
    {
      get => this._si_BizAddr1;
      set
      {
        this._si_BizAddr1 = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (si_BizAddr1));
      }
    }

    public string si_BizAddr2
    {
      get => this._si_BizAddr2;
      set
      {
        this._si_BizAddr2 = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (si_BizAddr2));
      }
    }

    public string si_ZipCode
    {
      get => this._si_ZipCode;
      set
      {
        this._si_ZipCode = UbModelBase.LeftStr(value, 7).Replace("'", "´");
        this.Changed(nameof (si_ZipCode));
      }
    }

    public DateTime? si_BuyConfirmDate
    {
      get => this._si_BuyConfirmDate;
      set
      {
        this._si_BuyConfirmDate = value;
        this.Changed(nameof (si_BuyConfirmDate));
      }
    }

    public DateTime? si_StockConfirmDate
    {
      get => this._si_StockConfirmDate;
      set
      {
        this._si_StockConfirmDate = value;
        this.Changed(nameof (si_StockConfirmDate));
      }
    }

    public DateTime? si_StockStartDate
    {
      get => this._si_StockStartDate;
      set
      {
        this._si_StockStartDate = value;
        this.Changed(nameof (si_StockStartDate));
      }
    }

    public DateTime? si_SaleConfirmDate
    {
      get => this._si_SaleConfirmDate;
      set
      {
        this._si_SaleConfirmDate = value;
        this.Changed(nameof (si_SaleConfirmDate));
      }
    }

    public int si_SortNo
    {
      get => this._si_SortNo;
      set
      {
        this._si_SortNo = value;
        this.Changed(nameof (si_SortNo));
      }
    }

    public int si_MemberMntStore
    {
      get => this._si_MemberMntStore;
      set
      {
        this._si_MemberMntStore = value;
        this.Changed(nameof (si_MemberMntStore));
      }
    }

    public string si_WeatherCode
    {
      get => this._si_WeatherCode;
      set
      {
        this._si_WeatherCode = UbModelBase.LeftStr(value, 20).Replace("'", "´");
        this.Changed(nameof (si_WeatherCode));
      }
    }

    public string si_Email
    {
      get => this._si_Email;
      set
      {
        this._si_Email = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (si_Email));
      }
    }

    public string si_EmailPwd
    {
      get => this._si_EmailPwd;
      set
      {
        this._si_EmailPwd = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (si_EmailPwd));
      }
    }

    public string si_LocationUseYn
    {
      get => this._si_LocationUseYn;
      set
      {
        this._si_LocationUseYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (si_LocationUseYn));
        this.Changed("si_IsLocationUseYn");
        this.Changed("si_LocationUseYnDesc");
      }
    }

    public bool si_IsLocationUseYn => "Y".Equals(this.si_LocationUseYn);

    public string si_LocationUseYnDesc => !"Y".Equals(this.si_LocationUseYn) ? "미사용" : "사용";

    public double si_AutoOrderSafetyFactor
    {
      get => this._si_AutoOrderSafetyFactor;
      set
      {
        this._si_AutoOrderSafetyFactor = value;
        this.Changed(nameof (si_AutoOrderSafetyFactor));
      }
    }

    public int si_AutoOrderOpt
    {
      get => this._si_AutoOrderOpt;
      set
      {
        this._si_AutoOrderOpt = value;
        this.Changed(nameof (si_AutoOrderOpt));
      }
    }

    public int si_AutoOrderRef
    {
      get => this._si_AutoOrderRef;
      set
      {
        this._si_AutoOrderRef = value;
        this.Changed(nameof (si_AutoOrderRef));
      }
    }

    public DateTime? si_InDate
    {
      get => this._si_InDate;
      set
      {
        this._si_InDate = value;
        this.Changed(nameof (si_InDate));
        this.Changed("ModDate");
      }
    }

    public int si_InUser
    {
      get => this._si_InUser;
      set
      {
        this._si_InUser = value;
        this.Changed(nameof (si_InUser));
      }
    }

    public DateTime? si_ModDate
    {
      get => this._si_ModDate;
      set
      {
        this._si_ModDate = value;
        this.Changed(nameof (si_ModDate));
        this.Changed("ModDate");
      }
    }

    public int si_ModUser
    {
      get => this._si_ModUser;
      set
      {
        this._si_ModUser = value;
        this.Changed(nameof (si_ModUser));
      }
    }

    public override DateTime? ModDate => !this.si_ModDate.HasValue ? this.si_InDate : this.si_ModDate;

    public TStoreInfo() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("si_StoreCode", new TTableColumn()
      {
        tc_orgin_name = "si_StoreCode",
        tc_trans_name = "지점코드"
      });
      columnInfo.Add("si_SiteID", new TTableColumn()
      {
        tc_orgin_name = "si_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("si_StoreType", new TTableColumn()
      {
        tc_orgin_name = "si_StoreType",
        tc_trans_name = "지점타입",
        tc_comm_code = 30
      });
      columnInfo.Add("si_StoreTypeDesc", new TTableColumn()
      {
        tc_orgin_name = "si_StoreTypeDesc",
        tc_trans_name = "지점타입 설명"
      });
      columnInfo.Add("si_StoreViewCode", new TTableColumn()
      {
        tc_orgin_name = "si_StoreViewCode",
        tc_trans_name = "관리코드"
      });
      columnInfo.Add("si_StoreName", new TTableColumn()
      {
        tc_orgin_name = "si_StoreName",
        tc_trans_name = "지점명",
        tc_col_hint = "힌트 테스트.\n <span>툴팁.</span>"
      });
      columnInfo.Add("si_Tel1", new TTableColumn()
      {
        tc_orgin_name = "si_Tel1",
        tc_trans_name = "TEL 1"
      });
      columnInfo.Add("si_Tel2", new TTableColumn()
      {
        tc_orgin_name = "si_Tel2",
        tc_trans_name = "TEL 2"
      });
      columnInfo.Add("si_LocalIP", new TTableColumn()
      {
        tc_orgin_name = "si_LocalIP",
        tc_trans_name = "로컬 IP"
      });
      columnInfo.Add("si_PublicIP", new TTableColumn()
      {
        tc_orgin_name = "si_PublicIP",
        tc_trans_name = "Public IP"
      });
      columnInfo.Add("si_UseYn", new TTableColumn()
      {
        tc_orgin_name = "si_UseYn",
        tc_trans_name = "사용상태"
      });
      columnInfo.Add("si_UseYnDesc", new TTableColumn()
      {
        tc_orgin_name = "si_UseYnDesc",
        tc_trans_name = "사용상태"
      });
      columnInfo.Add("si_IsUseYn", new TTableColumn()
      {
        tc_orgin_name = "si_IsUseYn",
        tc_trans_name = "사용상태"
      });
      columnInfo.Add("si_ErpCode", new TTableColumn()
      {
        tc_orgin_name = "si_ErpCode",
        tc_trans_name = "ERP 코드"
      });
      columnInfo.Add("si_ErpUpdateDate", new TTableColumn()
      {
        tc_orgin_name = "si_ErpUpdateDate",
        tc_trans_name = "ERP 연결 일자"
      });
      columnInfo.Add("si_BizNo", new TTableColumn()
      {
        tc_orgin_name = "si_BizNo",
        tc_trans_name = "사업자번호"
      });
      columnInfo.Add("si_BizName", new TTableColumn()
      {
        tc_orgin_name = "si_BizName",
        tc_trans_name = "사업자명"
      });
      columnInfo.Add("si_BizCeo", new TTableColumn()
      {
        tc_orgin_name = "si_BizCeo",
        tc_trans_name = "대표자"
      });
      columnInfo.Add("si_BizType", new TTableColumn()
      {
        tc_orgin_name = "si_BizType",
        tc_trans_name = "업태"
      });
      columnInfo.Add("si_BizCategory", new TTableColumn()
      {
        tc_orgin_name = "si_BizCategory",
        tc_trans_name = "업종"
      });
      columnInfo.Add("si_BizAddr1", new TTableColumn()
      {
        tc_orgin_name = "si_BizAddr1",
        tc_trans_name = "주소"
      });
      columnInfo.Add("si_BizAddr2", new TTableColumn()
      {
        tc_orgin_name = "si_BizAddr2",
        tc_trans_name = "주소 상세"
      });
      columnInfo.Add("si_ZipCode", new TTableColumn()
      {
        tc_orgin_name = "si_ZipCode",
        tc_trans_name = "우편번호"
      });
      columnInfo.Add("si_BuyConfirmDate", new TTableColumn()
      {
        tc_orgin_name = "si_BuyConfirmDate",
        tc_trans_name = "매입확정일",
        tc_col_hint = "매입 확정 마감일자."
      });
      columnInfo.Add("si_StockConfirmDate", new TTableColumn()
      {
        tc_orgin_name = "si_StockConfirmDate",
        tc_trans_name = "수불확정일",
        tc_col_hint = "수불 확정 마감일자."
      });
      columnInfo.Add("si_StockStartDate", new TTableColumn()
      {
        tc_orgin_name = "si_StockStartDate",
        tc_trans_name = "수불시작일",
        tc_col_hint = "수불(현시스템) 시작일자"
      });
      columnInfo.Add("si_SaleConfirmDate", new TTableColumn()
      {
        tc_orgin_name = "si_SaleConfirmDate",
        tc_trans_name = "판매확정일",
        tc_col_hint = "판매 확정 마감일자."
      });
      columnInfo.Add("si_SortNo", new TTableColumn()
      {
        tc_orgin_name = "si_SortNo",
        tc_trans_name = "순위"
      });
      columnInfo.Add("si_MemberMntStore", new TTableColumn()
      {
        tc_orgin_name = "si_MemberMntStore",
        tc_trans_name = "포인트 지점"
      });
      columnInfo.Add("si_WeatherCode", new TTableColumn()
      {
        tc_orgin_name = "si_WeatherCode",
        tc_trans_name = "날씨"
      });
      columnInfo.Add("si_Email", new TTableColumn()
      {
        tc_orgin_name = "si_Email",
        tc_trans_name = "이메일"
      });
      columnInfo.Add("si_EmailPwd", new TTableColumn()
      {
        tc_orgin_name = "si_EmailPwd",
        tc_trans_name = "이메일패스워드"
      });
      columnInfo.Add("si_LocationUseYn", new TTableColumn()
      {
        tc_orgin_name = "si_LocationUseYn",
        tc_trans_name = "로케이션 사용유무"
      });
      columnInfo.Add("si_LocationUseYnDesc", new TTableColumn()
      {
        tc_orgin_name = "si_LocationUseYnDesc",
        tc_trans_name = "로케이션 사용유무 설명"
      });
      columnInfo.Add("si_AutoOrderSafetyFactor", new TTableColumn()
      {
        tc_orgin_name = "si_AutoOrderSafetyFactor",
        tc_trans_name = "자동발주 안전계수"
      });
      columnInfo.Add("si_AutoOrderOpt", new TTableColumn()
      {
        tc_orgin_name = "si_AutoOrderOpt",
        tc_trans_name = "자동발주 옵션"
      });
      columnInfo.Add("si_AutoOrderRef", new TTableColumn()
      {
        tc_orgin_name = "si_AutoOrderRef",
        tc_trans_name = "자동발주 최근 참고 데이터 일수"
      });
      columnInfo.Add("si_InDate", new TTableColumn()
      {
        tc_orgin_name = "si_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("si_InUser", new TTableColumn()
      {
        tc_orgin_name = "si_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("si_ModDate", new TTableColumn()
      {
        tc_orgin_name = "si_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("si_ModUser", new TTableColumn()
      {
        tc_orgin_name = "si_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.StoreInfo;
      this.si_StoreCode = this.si_StoreType = 0;
      this.si_SiteID = 0L;
      this.si_StoreViewCode = string.Empty;
      this.si_StoreName = string.Empty;
      this.si_Tel1 = string.Empty;
      this.si_Tel2 = string.Empty;
      this.si_LocalIP = string.Empty;
      this.si_PublicIP = string.Empty;
      this.si_UseYn = "Y";
      this.si_ErpCode = string.Empty;
      this.si_ErpUpdateDate = new DateTime?();
      this.si_BizNo = string.Empty;
      this.si_BizName = string.Empty;
      this.si_BizCeo = string.Empty;
      this.si_BizType = string.Empty;
      this.si_BizCategory = string.Empty;
      this.si_BizAddr1 = string.Empty;
      this.si_BizAddr2 = string.Empty;
      this.si_ZipCode = string.Empty;
      this.si_BuyConfirmDate = new DateTime?();
      this.si_StockConfirmDate = new DateTime?();
      this.si_StockStartDate = new DateTime?();
      this.si_SaleConfirmDate = new DateTime?();
      this.si_SortNo = this.si_MemberMntStore = 0;
      this.si_WeatherCode = string.Empty;
      this.si_Email = string.Empty;
      this.si_EmailPwd = string.Empty;
      this.si_LocationUseYn = "N";
      this.si_AutoOrderSafetyFactor = 0.0;
      this.si_AutoOrderOpt = this.si_AutoOrderRef = 0;
      this.si_InDate = new DateTime?();
      this.si_ModDate = new DateTime?();
      this.si_InUser = this.si_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TStoreInfo();

    public override object Clone()
    {
      TStoreInfo tstoreInfo = base.Clone() as TStoreInfo;
      tstoreInfo.si_StoreCode = this.si_StoreCode;
      tstoreInfo.si_SiteID = this.si_SiteID;
      tstoreInfo.si_StoreType = this.si_StoreType;
      tstoreInfo.si_StoreViewCode = this.si_StoreViewCode;
      tstoreInfo.si_StoreName = this.si_StoreName;
      tstoreInfo.si_Tel1 = this.si_Tel1;
      tstoreInfo.si_Tel2 = this.si_Tel2;
      tstoreInfo.si_LocalIP = this.si_LocalIP;
      tstoreInfo.si_PublicIP = this.si_PublicIP;
      tstoreInfo.si_UseYn = this.si_UseYn;
      tstoreInfo.si_ErpCode = this.si_ErpCode;
      tstoreInfo.si_BizNo = this.si_BizNo;
      tstoreInfo.si_BizName = this.si_BizName;
      tstoreInfo.si_BizCeo = this.si_BizCeo;
      tstoreInfo.si_BizType = this.si_BizType;
      tstoreInfo.si_BizCategory = this.si_BizCategory;
      tstoreInfo.si_BizAddr1 = this.si_BizAddr1;
      tstoreInfo.si_BizAddr2 = this.si_BizAddr2;
      tstoreInfo.si_ZipCode = this.si_ZipCode;
      tstoreInfo.si_BuyConfirmDate = this.si_BuyConfirmDate;
      tstoreInfo.si_StockConfirmDate = this.si_StockConfirmDate;
      tstoreInfo.si_StockStartDate = this.si_StockStartDate;
      tstoreInfo.si_SaleConfirmDate = this.si_SaleConfirmDate;
      tstoreInfo.si_SortNo = this.si_SortNo;
      tstoreInfo.si_MemberMntStore = this.si_MemberMntStore;
      tstoreInfo.si_WeatherCode = this.si_WeatherCode;
      tstoreInfo.si_ErpUpdateDate = this.si_ErpUpdateDate;
      tstoreInfo.si_Email = this.si_Email;
      tstoreInfo.si_EmailPwd = this.si_EmailPwd;
      tstoreInfo.si_LocationUseYn = this.si_LocationUseYn;
      tstoreInfo.si_AutoOrderSafetyFactor = this.si_AutoOrderSafetyFactor;
      tstoreInfo.si_AutoOrderOpt = this.si_AutoOrderOpt;
      tstoreInfo.si_AutoOrderRef = this.si_AutoOrderRef;
      tstoreInfo.si_InDate = this.si_InDate;
      tstoreInfo.si_ModDate = this.si_ModDate;
      tstoreInfo.si_InUser = this.si_InUser;
      tstoreInfo.si_ModUser = this.si_ModUser;
      return (object) tstoreInfo;
    }

    public void PutData(TStoreInfo pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.si_StoreCode = pSource.si_StoreCode;
      this.si_SiteID = pSource.si_SiteID;
      this.si_StoreType = pSource.si_StoreType;
      this.si_StoreViewCode = pSource.si_StoreViewCode;
      this.si_StoreName = pSource.si_StoreName;
      this.si_Tel1 = pSource.si_Tel1;
      this.si_Tel2 = pSource.si_Tel2;
      this.si_LocalIP = pSource.si_LocalIP;
      this.si_PublicIP = pSource.si_PublicIP;
      this.si_UseYn = pSource.si_UseYn;
      this.si_ErpCode = pSource.si_ErpCode;
      this.si_BizNo = pSource.si_BizNo;
      this.si_BizName = pSource.si_BizName;
      this.si_BizCeo = pSource.si_BizCeo;
      this.si_BizType = pSource.si_BizType;
      this.si_BizCategory = pSource.si_BizCategory;
      this.si_BizAddr1 = pSource.si_BizAddr1;
      this.si_BizAddr2 = pSource.si_BizAddr2;
      this.si_ZipCode = pSource.si_ZipCode;
      this.si_BuyConfirmDate = pSource.si_BuyConfirmDate;
      this.si_StockConfirmDate = pSource.si_StockConfirmDate;
      this.si_StockStartDate = pSource.si_StockStartDate;
      this.si_SaleConfirmDate = pSource.si_SaleConfirmDate;
      this.si_SortNo = pSource.si_SortNo;
      this.si_MemberMntStore = pSource.si_MemberMntStore;
      this.si_WeatherCode = pSource.si_WeatherCode;
      this.si_ErpUpdateDate = pSource.si_ErpUpdateDate;
      this.si_Email = pSource.si_Email;
      this.si_EmailPwd = pSource.si_EmailPwd;
      this.si_LocationUseYn = pSource.si_LocationUseYn;
      this.si_AutoOrderSafetyFactor = pSource.si_AutoOrderSafetyFactor;
      this.si_AutoOrderOpt = pSource.si_AutoOrderOpt;
      this.si_AutoOrderRef = pSource.si_AutoOrderRef;
      this.si_InDate = pSource.si_InDate;
      this.si_ModDate = pSource.si_ModDate;
      this.si_InUser = pSource.si_InUser;
      this.si_ModUser = pSource.si_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.si_StoreCode = p_rs.GetFieldInt("si_StoreCode");
        if (this.si_StoreCode == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.si_SiteID = p_rs.GetFieldLong("si_SiteID");
        this.si_StoreType = p_rs.GetFieldInt("si_StoreType");
        this.si_StoreViewCode = p_rs.GetFieldString("si_StoreViewCode");
        this.si_StoreName = p_rs.GetFieldString("si_StoreName");
        this.si_Tel1 = p_rs.GetFieldString("si_Tel1");
        this.si_Tel2 = p_rs.GetFieldString("si_Tel2");
        this.si_LocalIP = p_rs.GetFieldString("si_LocalIP");
        this.si_PublicIP = p_rs.GetFieldString("si_PublicIP");
        this.si_UseYn = p_rs.GetFieldString("si_UseYn");
        this.si_ErpCode = p_rs.GetFieldString("si_ErpCode");
        this.si_ErpUpdateDate = p_rs.GetFieldDateTime("si_ErpUpdateDate");
        this.si_BizNo = p_rs.GetFieldString("si_BizNo");
        this.si_BizName = p_rs.GetFieldString("si_BizName");
        this.si_BizCeo = p_rs.GetFieldString("si_BizCeo");
        this.si_BizType = p_rs.GetFieldString("si_BizType");
        this.si_BizCategory = p_rs.GetFieldString("si_BizCategory");
        this.si_BizAddr1 = p_rs.GetFieldString("si_BizAddr1");
        this.si_BizAddr2 = p_rs.GetFieldString("si_BizAddr2");
        this.si_ZipCode = p_rs.GetFieldString("si_ZipCode");
        this.si_BuyConfirmDate = p_rs.GetFieldDateTime("si_BuyConfirmDate");
        this.si_StockConfirmDate = p_rs.GetFieldDateTime("si_StockConfirmDate");
        this.si_StockStartDate = p_rs.GetFieldDateTime("si_StockStartDate");
        this.si_SaleConfirmDate = p_rs.GetFieldDateTime("si_SaleConfirmDate");
        this.si_SortNo = p_rs.GetFieldInt("si_SortNo");
        this.si_MemberMntStore = p_rs.GetFieldInt("si_MemberMntStore");
        this.si_WeatherCode = p_rs.GetFieldString("si_WeatherCode");
        this.si_Email = p_rs.GetFieldString("si_Email");
        this.si_EmailPwd = p_rs.GetFieldString("si_EmailPwd");
        this.si_LocationUseYn = p_rs.GetFieldString("si_LocationUseYn");
        this.si_AutoOrderSafetyFactor = p_rs.GetFieldDouble("si_AutoOrderSafetyFactor");
        this.si_AutoOrderOpt = p_rs.GetFieldInt("si_AutoOrderOpt");
        this.si_AutoOrderRef = p_rs.GetFieldInt("si_AutoOrderRef");
        this.si_InDate = p_rs.GetFieldDateTime("si_InDate");
        this.si_InUser = p_rs.GetFieldInt("si_InUser");
        this.si_ModDate = p_rs.GetFieldDateTime("si_ModDate");
        this.si_ModUser = p_rs.GetFieldInt("si_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " si_StoreCode,si_SiteID,si_StoreType,si_StoreViewCode,si_StoreName,si_Tel1,si_Tel2,si_LocalIP,si_PublicIP,si_UseYn,si_ErpCode,si_ErpUpdateDate,si_BizNo,si_BizName,si_BizCeo,si_BizType,si_BizCategory,si_BizAddr1,si_BizAddr2,si_ZipCode,si_BuyConfirmDate,si_StockConfirmDate,si_StockStartDate,si_SaleConfirmDate,si_SortNo,si_MemberMntStore,si_WeatherCode,si_Email,si_EmailPwd,si_LocationUseYn,si_AutoOrderSafetyFactor,si_AutoOrderOpt,si_AutoOrderRef,si_InDate,si_InUser,si_ModDate,si_ModUser) VALUES ( " + string.Format(" {0}", (object) this.si_StoreCode) + string.Format(",{0},{1},'{2}','{3}'", (object) this.si_SiteID, (object) this.si_StoreType, (object) this.si_StoreViewCode, (object) this.si_StoreName) + ",'" + this.si_Tel1 + "','" + this.si_Tel2 + "','" + this.si_LocalIP + "','" + this.si_PublicIP + "','" + this.si_UseYn + "','" + this.si_ErpCode + "'," + this.si_ErpUpdateDate.GetDateToStrInNull() + ",'" + this.si_BizNo + "','" + this.si_BizName + "','" + this.si_BizCeo + "','" + this.si_BizType + "','" + this.si_BizCategory + "','" + this.si_BizAddr1 + "','" + this.si_BizAddr2 + "','" + this.si_ZipCode + "'," + this.si_BuyConfirmDate.GetDateToStrInNull() + "," + this.si_StockConfirmDate.GetDateToStrInNull() + "," + this.si_StockStartDate.GetDateToStrInNull() + "," + this.si_SaleConfirmDate.GetDateToStrInNull() + string.Format(",{0},{1},'{2}'", (object) this.si_SortNo, (object) this.si_MemberMntStore, (object) this.si_WeatherCode) + ",'" + this.si_Email + "','" + this.si_EmailPwd + "','" + this.si_LocationUseYn + "'" + string.Format(",{0},{1},{2}", (object) this.si_AutoOrderSafetyFactor, (object) this.si_AutoOrderOpt, (object) this.si_AutoOrderRef) + string.Format(",{0},{1}", (object) this.si_InDate.GetDateToStrInNull(), (object) this.si_InUser) + string.Format(",{0},{1}", (object) this.si_ModDate.GetDateToStrInNull(), (object) this.si_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : {0}\n", (object) this.si_StoreCode) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TStoreInfo tstoreInfo = this;
      // ISSUE: reference to a compiler-generated method
      tstoreInfo.\u003C\u003En__0();
      if (await tstoreInfo.OleDB.ExecuteAsync(tstoreInfo.InsertQuery()))
        return true;
      tstoreInfo.message = " " + tstoreInfo.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tstoreInfo.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tstoreInfo.OleDB.LastErrorID) + string.Format(" 코드 : {0}\n", (object) tstoreInfo.si_StoreCode) + " 내용 : " + tstoreInfo.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tstoreInfo.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + string.Format(" {0}={1},{2}='{3}',{4}='{5}'", (object) "si_StoreType", (object) this.si_StoreType, (object) "si_StoreViewCode", (object) this.si_StoreViewCode, (object) "si_StoreName", (object) this.si_StoreName) + ",si_Tel1='" + this.si_Tel1 + "',si_Tel2='" + this.si_Tel2 + "',si_LocalIP='" + this.si_LocalIP + "',si_PublicIP='" + this.si_PublicIP + "',si_UseYn='" + this.si_UseYn + "',si_ErpCode='" + this.si_ErpCode + "',si_ErpUpdateDate=" + this.si_ErpUpdateDate.GetDateToStrInNull() + ",si_BizNo='" + this.si_BizNo + "',si_BizName='" + this.si_BizName + "',si_BizCeo='" + this.si_BizCeo + "',si_BizType='" + this.si_BizType + "',si_BizCategory='" + this.si_BizCategory + "',si_BizAddr1='" + this.si_BizAddr1 + "',si_BizAddr2='" + this.si_BizAddr2 + "',si_ZipCode='" + this.si_ZipCode + "',si_BuyConfirmDate=" + this.si_BuyConfirmDate.GetDateToStrInNull() + ",si_StockConfirmDate=" + this.si_StockConfirmDate.GetDateToStrInNull() + ",si_StockStartDate=" + this.si_StockStartDate.GetDateToStrInNull() + ",si_SaleConfirmDate=" + this.si_SaleConfirmDate.GetDateToStrInNull() + string.Format(",{0}={1},{2}={3},{4}='{5}'", (object) "si_SortNo", (object) this.si_SortNo, (object) "si_MemberMntStore", (object) this.si_MemberMntStore, (object) "si_WeatherCode", (object) this.si_WeatherCode) + ",si_Email='" + this.si_Email + "',si_EmailPwd='" + this.si_EmailPwd + "',si_LocationUseYn='" + this.si_LocationUseYn + "'" + string.Format(",{0}={1},{2}={3},{4}={5}", (object) "si_AutoOrderSafetyFactor", (object) this.si_AutoOrderSafetyFactor, (object) "si_AutoOrderOpt", (object) this.si_AutoOrderOpt, (object) "si_AutoOrderRef", (object) this.si_AutoOrderRef) + string.Format(",{0}={1},{2}={3}", (object) "si_ModDate", (object) this.si_ModDate.GetDateToStrInNull(), (object) "si_ModUser", (object) this.si_ModUser) + string.Format(" WHERE {0}={1}", (object) "si_StoreCode", (object) this.si_StoreCode);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : {0}\n", (object) this.si_StoreCode) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TStoreInfo tstoreInfo = this;
      // ISSUE: reference to a compiler-generated method
      tstoreInfo.\u003C\u003En__1();
      if (await tstoreInfo.OleDB.ExecuteAsync(tstoreInfo.UpdateQuery()))
        return true;
      tstoreInfo.message = " " + tstoreInfo.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tstoreInfo.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tstoreInfo.OleDB.LastErrorID) + string.Format(" 코드 : {0}\n", (object) tstoreInfo.si_StoreCode) + " 내용 : " + tstoreInfo.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tstoreInfo.message);
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
      stringBuilder.Append(string.Format(" {0}={1},{2}='{3}',{4}='{5}'", (object) "si_StoreType", (object) this.si_StoreType, (object) "si_StoreViewCode", (object) this.si_StoreViewCode, (object) "si_StoreName", (object) this.si_StoreName) + ",si_Tel1='" + this.si_Tel1 + "',si_Tel2='" + this.si_Tel2 + "',si_LocalIP='" + this.si_LocalIP + "',si_PublicIP='" + this.si_PublicIP + "',si_UseYn='" + this.si_UseYn + "',si_ErpCode='" + this.si_ErpCode + "',si_ErpUpdateDate=" + this.si_ErpUpdateDate.GetDateToStrInNull() + ",si_BizNo='" + this.si_BizNo + "',si_BizName='" + this.si_BizName + "',si_BizCeo='" + this.si_BizCeo + "',si_BizType='" + this.si_BizType + "',si_BizCategory='" + this.si_BizCategory + "',si_BizAddr1='" + this.si_BizAddr1 + "',si_BizAddr2='" + this.si_BizAddr2 + "',si_ZipCode='" + this.si_ZipCode + "',si_BuyConfirmDate=" + this.si_BuyConfirmDate.GetDateToStrInNull() + ",si_StockConfirmDate=" + this.si_StockConfirmDate.GetDateToStrInNull() + ",si_StockStartDate=" + this.si_StockStartDate.GetDateToStrInNull() + ",si_SaleConfirmDate=" + this.si_SaleConfirmDate.GetDateToStrInNull() + string.Format(",{0}={1},{2}={3},{4}='{5}'", (object) "si_SortNo", (object) this.si_SortNo, (object) "si_MemberMntStore", (object) this.si_MemberMntStore, (object) "si_WeatherCode", (object) this.si_WeatherCode) + ",si_Email,si_EmailPwd,si_LocationUseYn" + string.Format(",{0}={1},{2}={3},{4}={5}", (object) "si_AutoOrderSafetyFactor", (object) this.si_AutoOrderSafetyFactor, (object) "si_AutoOrderOpt", (object) this.si_AutoOrderOpt, (object) "si_AutoOrderRef", (object) this.si_AutoOrderRef) + string.Format(",{0}={1},{2}={3}", (object) "si_ModDate", (object) this.si_ModDate.GetDateToStrInNull(), (object) "si_ModUser", (object) this.si_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : {0}\n", (object) this.si_StoreCode) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TStoreInfo tstoreInfo = this;
      // ISSUE: reference to a compiler-generated method
      tstoreInfo.\u003C\u003En__1();
      if (await tstoreInfo.OleDB.ExecuteAsync(tstoreInfo.UpdateExInsertQuery()))
        return true;
      tstoreInfo.message = " " + tstoreInfo.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tstoreInfo.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tstoreInfo.OleDB.LastErrorID) + string.Format(" 코드 : {0}\n", (object) tstoreInfo.si_StoreCode) + " 내용 : " + tstoreInfo.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tstoreInfo.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "uis_SiteID") && Convert.ToInt64(hashtable[(object) "uis_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "uis_SiteID"].ToString());
        else if (hashtable.ContainsKey((object) "si_SiteID") && Convert.ToInt64(hashtable[(object) "si_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "si_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "si_StoreCode") && Convert.ToInt32(hashtable[(object) "si_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "si_StoreCode", hashtable[(object) "si_StoreCode"]));
        else if (hashtable.ContainsKey((object) "si_StoreCode_IN_") && hashtable[(object) "si_StoreCode_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "si_StoreCode", hashtable[(object) "si_StoreCode_IN_"]));
        else if (hashtable.ContainsKey((object) "_STORE_AUTHS_") && hashtable[(object) "_STORE_AUTHS_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "si_StoreCode", hashtable[(object) "_STORE_AUTHS_"]));
        else
          stringBuilder.Append(" AND si_StoreCode > 0");
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "si_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "si_StoreViewCode") && hashtable[(object) "si_StoreViewCode"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "si_StoreViewCode", hashtable[(object) "si_StoreViewCode"]));
        if (hashtable.ContainsKey((object) "si_StoreName") && hashtable[(object) "si_StoreName"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "si_StoreName", hashtable[(object) "si_StoreName"]));
        if (hashtable.ContainsKey((object) "si_BizNo") && hashtable[(object) "si_BizNo"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "si_BizNo", hashtable[(object) "si_BizNo"]));
        if (hashtable.ContainsKey((object) "si_UseYn") && hashtable[(object) "si_UseYn"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "si_UseYn", hashtable[(object) "si_UseYn"]));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "si_StoreViewCode", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "si_StoreName", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "si_BizName", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "si_BizCeo", hashtable[(object) "_KEY_WORD_"]));
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
        stringBuilder.Append(" SELECT  si_StoreCode,si_SiteID,si_StoreType,si_StoreViewCode,si_StoreName,si_Tel1,si_Tel2,si_LocalIP,si_PublicIP,si_UseYn,si_ErpCode,si_ErpUpdateDate,si_BizNo,si_BizName,si_BizCeo,si_BizType,si_BizCategory,si_BizAddr1,si_BizAddr2,si_ZipCode,si_BuyConfirmDate,si_StockConfirmDate,si_StockStartDate,si_SaleConfirmDate,si_SortNo,si_MemberMntStore,si_WeatherCode,si_Email,si_EmailPwd,si_LocationUseYn,si_AutoOrderSafetyFactor,si_AutoOrderOpt,si_AutoOrderRef,si_InDate,si_InUser,si_ModDate,si_ModUser");
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
