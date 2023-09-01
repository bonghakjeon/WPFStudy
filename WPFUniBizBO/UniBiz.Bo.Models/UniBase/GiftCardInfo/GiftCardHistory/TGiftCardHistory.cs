// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.GiftCardInfo.GiftCardHistory.TGiftCardHistory
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

namespace UniBiz.Bo.Models.UniBase.GiftCardInfo.GiftCardHistory
{
  public class TGiftCardHistory : UbModelBase<TGiftCardHistory>
  {
    private string _gch_GiftCardNo;
    private long _gch_SiteID;
    private long _gch_GiftCardID;
    private DateTime? _gch_IssueDate;
    private int _gch_IssueStore;
    private int _gch_FaceValue;
    private DateTime? _gch_ExpireDate;
    private DateTime? _gch_SaleDate;
    private int _gch_SaleStore;
    private int _gch_SalePosNo;
    private int _gch_SaleTransNo;
    private int _gch_SaleEmpCode;
    private long _gch_SaleMemberNo;
    private int _gch_SaleKind;
    private DateTime? _gch_ReturnDate;
    private int _gch_ReturnStore;
    private int _gch_ReturnPosNo;
    private int _gch_ReturnTransNo;
    private long _gch_ReturnMemberNo;
    private string _gch_DisuseYn;
    private DateTime? _gch_DisuseDate;
    private long _gch_DisuseStatement;
    private int _gch_DisuseEmpCode;
    private string _gch_UseYn;
    private DateTime? _gch_InDate;
    private int _gch_InUser;
    private DateTime? _gch_ModDate;
    private int _gch_ModUser;

    public override object _Key => (object) new object[1]
    {
      (object) this.gch_GiftCardNo
    };

    public string gch_GiftCardNo
    {
      get => this._gch_GiftCardNo;
      set
      {
        this._gch_GiftCardNo = UbModelBase.LeftStr(value, 40).Replace("'", "´");
        this.Changed(nameof (gch_GiftCardNo));
      }
    }

    public long gch_SiteID
    {
      get => this._gch_SiteID;
      set
      {
        this._gch_SiteID = value;
        this.Changed(nameof (gch_SiteID));
      }
    }

    public long gch_GiftCardID
    {
      get => this._gch_GiftCardID;
      set
      {
        this._gch_GiftCardID = value;
        this.Changed(nameof (gch_GiftCardID));
      }
    }

    public DateTime? gch_IssueDate
    {
      get => this._gch_IssueDate;
      set
      {
        this._gch_IssueDate = value;
        this.Changed(nameof (gch_IssueDate));
      }
    }

    public int gch_IssueStore
    {
      get => this._gch_IssueStore;
      set
      {
        this._gch_IssueStore = value;
        this.Changed(nameof (gch_IssueStore));
      }
    }

    public int gch_FaceValue
    {
      get => this._gch_FaceValue;
      set
      {
        this._gch_FaceValue = value;
        this.Changed(nameof (gch_FaceValue));
      }
    }

    public DateTime? gch_ExpireDate
    {
      get => this._gch_ExpireDate;
      set
      {
        this._gch_ExpireDate = value;
        this.Changed(nameof (gch_ExpireDate));
      }
    }

    public DateTime? gch_SaleDate
    {
      get => this._gch_SaleDate;
      set
      {
        this._gch_SaleDate = value;
        this.Changed(nameof (gch_SaleDate));
      }
    }

    public int gch_SaleStore
    {
      get => this._gch_SaleStore;
      set
      {
        this._gch_SaleStore = value;
        this.Changed(nameof (gch_SaleStore));
      }
    }

    public int gch_SalePosNo
    {
      get => this._gch_SalePosNo;
      set
      {
        this._gch_SalePosNo = value;
        this.Changed(nameof (gch_SalePosNo));
      }
    }

    public int gch_SaleTransNo
    {
      get => this._gch_SaleTransNo;
      set
      {
        this._gch_SaleTransNo = value;
        this.Changed(nameof (gch_SaleTransNo));
      }
    }

    public int gch_SaleEmpCode
    {
      get => this._gch_SaleEmpCode;
      set
      {
        this._gch_SaleEmpCode = value;
        this.Changed(nameof (gch_SaleEmpCode));
      }
    }

    public long gch_SaleMemberNo
    {
      get => this._gch_SaleMemberNo;
      set
      {
        this._gch_SaleMemberNo = value;
        this.Changed(nameof (gch_SaleMemberNo));
      }
    }

    public int gch_SaleKind
    {
      get => this._gch_SaleKind;
      set
      {
        this._gch_SaleKind = value;
        this.Changed(nameof (gch_SaleKind));
        this.Changed("gch_SaleKindDesc");
      }
    }

    public string gch_SaleKindDesc => this.gch_SaleKind != 0 ? Enum2StrConverter.ToGiftCardSaleKind(this.gch_SaleKind).ToDescription() : string.Empty;

    public DateTime? gch_ReturnDate
    {
      get => this._gch_ReturnDate;
      set
      {
        this._gch_ReturnDate = value;
        this.Changed(nameof (gch_ReturnDate));
      }
    }

    public int gch_ReturnStore
    {
      get => this._gch_ReturnStore;
      set
      {
        this._gch_ReturnStore = value;
        this.Changed(nameof (gch_ReturnStore));
      }
    }

    public int gch_ReturnPosNo
    {
      get => this._gch_ReturnPosNo;
      set
      {
        this._gch_ReturnPosNo = value;
        this.Changed(nameof (gch_ReturnPosNo));
      }
    }

    public int gch_ReturnTransNo
    {
      get => this._gch_ReturnTransNo;
      set
      {
        this._gch_ReturnTransNo = value;
        this.Changed(nameof (gch_ReturnTransNo));
      }
    }

    public long gch_ReturnMemberNo
    {
      get => this._gch_ReturnMemberNo;
      set
      {
        this._gch_ReturnMemberNo = value;
        this.Changed(nameof (gch_ReturnMemberNo));
      }
    }

    public string gch_DisuseYn
    {
      get => this._gch_DisuseYn;
      set
      {
        this._gch_DisuseYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (gch_DisuseYn));
        this.Changed("gch_IsDisuse");
        this.Changed("gch_DisuseYnDesc");
      }
    }

    public bool gch_IsDisuse => "Y".Equals(this.gch_DisuseYn);

    public string gch_DisuseYnDesc => !"Y".Equals(this.gch_DisuseYn) ? "사용가능" : "폐기";

    public DateTime? gch_DisuseDate
    {
      get => this._gch_DisuseDate;
      set
      {
        this._gch_DisuseDate = value;
        this.Changed(nameof (gch_DisuseDate));
      }
    }

    public long gch_DisuseStatement
    {
      get => this._gch_DisuseStatement;
      set
      {
        this._gch_DisuseStatement = value;
        this.Changed(nameof (gch_DisuseStatement));
      }
    }

    public int gch_DisuseEmpCode
    {
      get => this._gch_DisuseEmpCode;
      set
      {
        this._gch_DisuseEmpCode = value;
        this.Changed(nameof (gch_DisuseEmpCode));
      }
    }

    public string gch_UseYn
    {
      get => this._gch_UseYn;
      set
      {
        this._gch_UseYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (gch_UseYn));
        this.Changed("gch_IsUse");
        this.Changed("gch_UseYnDesc");
      }
    }

    public bool gch_IsUse => "Y".Equals(this.gch_UseYn);

    public string gch_UseYnDesc => !"Y".Equals(this.gch_UseYn) ? "미사용" : "사용";

    public DateTime? gch_InDate
    {
      get => this._gch_InDate;
      set
      {
        this._gch_InDate = value;
        this.Changed(nameof (gch_InDate));
        this.Changed("ModDate");
      }
    }

    public int gch_InUser
    {
      get => this._gch_InUser;
      set
      {
        this._gch_InUser = value;
        this.Changed(nameof (gch_InUser));
      }
    }

    public DateTime? gch_ModDate
    {
      get => this._gch_ModDate;
      set
      {
        this._gch_ModDate = value;
        this.Changed(nameof (gch_ModDate));
        this.Changed("ModDate");
      }
    }

    public int gch_ModUser
    {
      get => this._gch_ModUser;
      set
      {
        this._gch_ModUser = value;
        this.Changed(nameof (gch_ModUser));
      }
    }

    public override DateTime? ModDate => this.gch_ModDate ?? (this.gch_ModDate = this.gch_InDate);

    public TGiftCardHistory() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("gch_GiftCardNo", new TTableColumn()
      {
        tc_orgin_name = "gch_GiftCardNo",
        tc_trans_name = "상품권No"
      });
      columnInfo.Add("gch_SiteID", new TTableColumn()
      {
        tc_orgin_name = "gch_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("gch_GiftCardID", new TTableColumn()
      {
        tc_orgin_name = "gch_GiftCardID",
        tc_trans_name = "상품권ID"
      });
      columnInfo.Add("gch_IssueDate", new TTableColumn()
      {
        tc_orgin_name = "gch_IssueDate",
        tc_trans_name = "발행일"
      });
      columnInfo.Add("gch_IssueStore", new TTableColumn()
      {
        tc_orgin_name = "gch_IssueStore",
        tc_trans_name = "발행매장"
      });
      columnInfo.Add("gch_FaceValue", new TTableColumn()
      {
        tc_orgin_name = "gch_FaceValue",
        tc_trans_name = "액면가"
      });
      columnInfo.Add("gch_ExpireDate", new TTableColumn()
      {
        tc_orgin_name = "gch_ExpireDate",
        tc_trans_name = "만료일"
      });
      columnInfo.Add("gch_SaleDate", new TTableColumn()
      {
        tc_orgin_name = "gch_SaleDate",
        tc_trans_name = "판매일자"
      });
      columnInfo.Add("gch_SaleStore", new TTableColumn()
      {
        tc_orgin_name = "gch_SaleStore",
        tc_trans_name = "판매지점"
      });
      columnInfo.Add("gch_SalePosNo", new TTableColumn()
      {
        tc_orgin_name = "gch_SalePosNo",
        tc_trans_name = "판매POS"
      });
      columnInfo.Add("gch_SaleTransNo", new TTableColumn()
      {
        tc_orgin_name = "gch_SaleTransNo",
        tc_trans_name = "판매영수증No"
      });
      columnInfo.Add("gch_SaleEmpCode", new TTableColumn()
      {
        tc_orgin_name = "gch_SaleEmpCode",
        tc_trans_name = "판매담당자"
      });
      columnInfo.Add("gch_SaleMemberNo", new TTableColumn()
      {
        tc_orgin_name = "gch_SaleMemberNo",
        tc_trans_name = "판매회원번호"
      });
      columnInfo.Add("gch_SaleKind", new TTableColumn()
      {
        tc_orgin_name = "gch_SaleKind",
        tc_trans_name = "판매구분",
        tc_comm_code = 155
      });
      columnInfo.Add("gch_ReturnDate", new TTableColumn()
      {
        tc_orgin_name = "gch_ReturnDate",
        tc_trans_name = "사용일자"
      });
      columnInfo.Add("gch_ReturnStore", new TTableColumn()
      {
        tc_orgin_name = "gch_ReturnStore",
        tc_trans_name = "사용지점"
      });
      columnInfo.Add("gch_ReturnPosNo", new TTableColumn()
      {
        tc_orgin_name = "gch_ReturnPosNo",
        tc_trans_name = "사용POS "
      });
      columnInfo.Add("gch_ReturnTransNo", new TTableColumn()
      {
        tc_orgin_name = "gch_ReturnTransNo",
        tc_trans_name = "사용영수증N"
      });
      columnInfo.Add("gch_ReturnMemberNo", new TTableColumn()
      {
        tc_orgin_name = "gch_ReturnMemberNo",
        tc_trans_name = "사용회원"
      });
      columnInfo.Add("gch_DisuseYn", new TTableColumn()
      {
        tc_orgin_name = "gch_DisuseYn",
        tc_trans_name = "폐기구분 (Y:폐기, N:사용가능)"
      });
      columnInfo.Add("gch_DisuseDate", new TTableColumn()
      {
        tc_orgin_name = "gch_DisuseDate",
        tc_trans_name = "폐기일 "
      });
      columnInfo.Add("gch_DisuseStatement", new TTableColumn()
      {
        tc_orgin_name = "gch_DisuseStatement",
        tc_trans_name = "폐기전표번호"
      });
      columnInfo.Add("gch_DisuseEmpCode", new TTableColumn()
      {
        tc_orgin_name = "gch_DisuseEmpCode",
        tc_trans_name = "폐기담당"
      });
      columnInfo.Add("gch_UseYn", new TTableColumn()
      {
        tc_orgin_name = "gch_UseYn",
        tc_trans_name = "사용상태"
      });
      columnInfo.Add("gch_InDate", new TTableColumn()
      {
        tc_orgin_name = "gch_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("gch_InUser", new TTableColumn()
      {
        tc_orgin_name = "gch_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("gch_ModDate", new TTableColumn()
      {
        tc_orgin_name = "gch_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("gch_ModUser", new TTableColumn()
      {
        tc_orgin_name = "gch_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.GiftCardHistory;
      this.gch_GiftCardNo = string.Empty;
      this.gch_SiteID = 0L;
      this.gch_GiftCardID = 0L;
      this.gch_IssueDate = new DateTime?();
      this.gch_IssueStore = this.gch_FaceValue = 0;
      this.gch_ExpireDate = new DateTime?();
      this.gch_SaleDate = new DateTime?();
      this.gch_SaleStore = this.gch_SalePosNo = this.gch_SaleTransNo = this.gch_SaleEmpCode = 0;
      this.gch_SaleMemberNo = 0L;
      this.gch_SaleKind = 0;
      this.gch_ReturnDate = new DateTime?();
      this.gch_ReturnStore = this.gch_ReturnPosNo = this.gch_ReturnTransNo = 0;
      this.gch_ReturnMemberNo = 0L;
      this.gch_DisuseYn = "N";
      this.gch_DisuseDate = new DateTime?();
      this.gch_DisuseStatement = 0L;
      this.gch_DisuseEmpCode = 0;
      this.gch_UseYn = "Y";
      this.gch_InDate = new DateTime?();
      this.gch_InUser = 0;
      this.gch_ModDate = new DateTime?();
      this.gch_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TGiftCardHistory();

    public override object Clone()
    {
      TGiftCardHistory tgiftCardHistory = base.Clone() as TGiftCardHistory;
      tgiftCardHistory.gch_GiftCardNo = this.gch_GiftCardNo;
      tgiftCardHistory.gch_SiteID = this.gch_SiteID;
      tgiftCardHistory.gch_GiftCardID = this.gch_GiftCardID;
      tgiftCardHistory.gch_IssueDate = this.gch_IssueDate;
      tgiftCardHistory.gch_IssueStore = this.gch_IssueStore;
      tgiftCardHistory.gch_FaceValue = this.gch_FaceValue;
      tgiftCardHistory.gch_ExpireDate = this.gch_ExpireDate;
      tgiftCardHistory.gch_SaleDate = this.gch_SaleDate;
      tgiftCardHistory.gch_SaleStore = this.gch_SaleStore;
      tgiftCardHistory.gch_SalePosNo = this.gch_SalePosNo;
      tgiftCardHistory.gch_SaleTransNo = this.gch_SaleTransNo;
      tgiftCardHistory.gch_SaleEmpCode = this.gch_SaleEmpCode;
      tgiftCardHistory.gch_SaleMemberNo = this.gch_SaleMemberNo;
      tgiftCardHistory.gch_SaleKind = this.gch_SaleKind;
      tgiftCardHistory.gch_ReturnDate = this.gch_ReturnDate;
      tgiftCardHistory.gch_ReturnStore = this.gch_ReturnStore;
      tgiftCardHistory.gch_ReturnPosNo = this.gch_ReturnPosNo;
      tgiftCardHistory.gch_ReturnTransNo = this.gch_ReturnTransNo;
      tgiftCardHistory.gch_ReturnMemberNo = this.gch_ReturnMemberNo;
      tgiftCardHistory.gch_DisuseYn = this.gch_DisuseYn;
      tgiftCardHistory.gch_DisuseDate = this.gch_DisuseDate;
      tgiftCardHistory.gch_DisuseStatement = this.gch_DisuseStatement;
      tgiftCardHistory.gch_DisuseEmpCode = this.gch_DisuseEmpCode;
      tgiftCardHistory.gch_UseYn = this.gch_UseYn;
      tgiftCardHistory.gch_InDate = this.gch_InDate;
      tgiftCardHistory.gch_ModDate = this.gch_ModDate;
      tgiftCardHistory.gch_InUser = this.gch_InUser;
      tgiftCardHistory.gch_ModUser = this.gch_ModUser;
      return (object) tgiftCardHistory;
    }

    public void PutData(TGiftCardHistory pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.gch_GiftCardNo = pSource.gch_GiftCardNo;
      this.gch_SiteID = pSource.gch_SiteID;
      this.gch_GiftCardID = pSource.gch_GiftCardID;
      this.gch_IssueDate = pSource.gch_IssueDate;
      this.gch_IssueStore = pSource.gch_IssueStore;
      this.gch_FaceValue = pSource.gch_FaceValue;
      this.gch_ExpireDate = pSource.gch_ExpireDate;
      this.gch_SaleDate = pSource.gch_SaleDate;
      this.gch_SaleStore = pSource.gch_SaleStore;
      this.gch_SalePosNo = pSource.gch_SalePosNo;
      this.gch_SaleTransNo = pSource.gch_SaleTransNo;
      this.gch_SaleEmpCode = pSource.gch_SaleEmpCode;
      this.gch_SaleMemberNo = pSource.gch_SaleMemberNo;
      this.gch_SaleKind = pSource.gch_SaleKind;
      this.gch_ReturnDate = pSource.gch_ReturnDate;
      this.gch_ReturnStore = pSource.gch_ReturnStore;
      this.gch_ReturnPosNo = pSource.gch_ReturnPosNo;
      this.gch_ReturnTransNo = pSource.gch_ReturnTransNo;
      this.gch_ReturnMemberNo = pSource.gch_ReturnMemberNo;
      this.gch_DisuseYn = pSource.gch_DisuseYn;
      this.gch_DisuseDate = pSource.gch_DisuseDate;
      this.gch_DisuseStatement = pSource.gch_DisuseStatement;
      this.gch_DisuseEmpCode = pSource.gch_DisuseEmpCode;
      this.gch_UseYn = pSource.gch_UseYn;
      this.gch_InDate = pSource.gch_InDate;
      this.gch_ModDate = pSource.gch_ModDate;
      this.gch_InUser = pSource.gch_InUser;
      this.gch_ModUser = pSource.gch_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.gch_GiftCardNo = p_rs.GetFieldString("gch_GiftCardNo");
        if (string.IsNullOrEmpty(this.gch_GiftCardNo))
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.gch_SiteID = p_rs.GetFieldLong("gch_SiteID");
        this.gch_GiftCardID = p_rs.GetFieldLong("gch_GiftCardID");
        this.gch_IssueDate = p_rs.GetFieldDateTime("gch_IssueDate");
        this.gch_IssueStore = p_rs.GetFieldInt("gch_IssueStore");
        this.gch_FaceValue = p_rs.GetFieldInt("gch_FaceValue");
        this.gch_ExpireDate = p_rs.GetFieldDateTime("gch_ExpireDate");
        this.gch_SaleDate = p_rs.GetFieldDateTime("gch_SaleDate");
        this.gch_SaleStore = p_rs.GetFieldInt("gch_SaleStore");
        this.gch_SalePosNo = p_rs.GetFieldInt("gch_SalePosNo");
        this.gch_SaleTransNo = p_rs.GetFieldInt("gch_SaleTransNo");
        this.gch_SaleEmpCode = p_rs.GetFieldInt("gch_SaleEmpCode");
        this.gch_SaleMemberNo = p_rs.GetFieldLong("gch_SaleMemberNo");
        this.gch_SaleKind = p_rs.GetFieldInt("gch_SaleKind");
        this.gch_ReturnDate = p_rs.GetFieldDateTime("gch_ReturnDate");
        this.gch_ReturnStore = p_rs.GetFieldInt("gch_ReturnStore");
        this.gch_ReturnPosNo = p_rs.GetFieldInt("gch_ReturnPosNo");
        this.gch_ReturnTransNo = p_rs.GetFieldInt("gch_ReturnTransNo");
        this.gch_ReturnMemberNo = p_rs.GetFieldLong("gch_ReturnMemberNo");
        this.gch_DisuseYn = p_rs.GetFieldString("gch_DisuseYn");
        this.gch_DisuseDate = p_rs.GetFieldDateTime("gch_DisuseDate");
        this.gch_DisuseStatement = p_rs.GetFieldLong("gch_DisuseStatement");
        this.gch_DisuseEmpCode = p_rs.GetFieldInt("gch_DisuseEmpCode");
        this.gch_UseYn = p_rs.GetFieldString("gch_UseYn");
        this.gch_InDate = p_rs.GetFieldDateTime("gch_InDate");
        this.gch_InUser = p_rs.GetFieldInt("gch_InUser");
        this.gch_ModDate = p_rs.GetFieldDateTime("gch_ModDate");
        this.gch_ModUser = p_rs.GetFieldInt("gch_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " gch_GiftCardNo,gch_SiteID,gch_GiftCardID,gch_IssueDate,gch_IssueStore,gch_FaceValue,gch_ExpireDate,gch_SaleDate,gch_SaleStore,gch_SalePosNo,gch_SaleTransNo,gch_SaleEmpCode,gch_SaleMemberNo,gch_SaleKind,gch_ReturnDate,gch_ReturnStore,gch_ReturnPosNo,gch_ReturnTransNo,gch_ReturnMemberNo,gch_DisuseYn,gch_DisuseDate,gch_DisuseStatement,gch_DisuseEmpCode,gch_UseYn,gch_InDate,gch_InUser,gch_ModDate,gch_ModUser) VALUES (  " + this.gch_GiftCardNo + string.Format(",{0}", (object) this.gch_SiteID) + string.Format(",{0}", (object) this.gch_GiftCardID) + "," + this.gch_IssueDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + string.Format(",{0},{1}", (object) this.gch_IssueStore, (object) this.gch_FaceValue) + "," + this.gch_ExpireDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + "," + this.gch_SaleDate.GetDateToStrInNull(p_format: "\\'yyyy-MM-dd 00:00:00\\'") + string.Format(",{0},{1},{2},{3}", (object) this.gch_SaleStore, (object) this.gch_SalePosNo, (object) this.gch_SaleTransNo, (object) this.gch_SaleEmpCode) + string.Format(",{0},{1}", (object) this.gch_SaleMemberNo, (object) this.gch_SaleKind) + "," + this.gch_ReturnDate.GetDateToStrInNull(p_format: "\\'yyyy-MM-dd 00:00:00\\'") + string.Format(",{0},{1},{2}", (object) this.gch_ReturnStore, (object) this.gch_ReturnPosNo, (object) this.gch_ReturnTransNo) + string.Format(",{0}", (object) this.gch_ReturnMemberNo) + ",'" + this.gch_DisuseYn + "'," + this.gch_DisuseDate.GetDateToStrInNull(p_format: "\\'yyyy-MM-dd 00:00:00\\'") + string.Format(",{0},{1},'{2}'", (object) this.gch_DisuseStatement, (object) this.gch_DisuseEmpCode, (object) this.gch_UseYn) + string.Format(",{0},{1}", (object) this.gch_InDate.GetDateToStrInNull(), (object) this.gch_InUser) + string.Format(",{0},{1}", (object) this.gch_ModDate.GetDateToStrInNull(), (object) this.gch_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.gch_GiftCardNo, (object) this.gch_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TGiftCardHistory tgiftCardHistory = this;
      // ISSUE: reference to a compiler-generated method
      tgiftCardHistory.\u003C\u003En__0();
      if (await tgiftCardHistory.OleDB.ExecuteAsync(tgiftCardHistory.InsertQuery()))
        return true;
      tgiftCardHistory.message = " " + tgiftCardHistory.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tgiftCardHistory.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tgiftCardHistory.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tgiftCardHistory.gch_GiftCardNo, (object) tgiftCardHistory.gch_SiteID) + " 내용 : " + tgiftCardHistory.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tgiftCardHistory.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + string.Format(" {0}={1}", (object) "gch_GiftCardID", (object) this.gch_GiftCardID) + ",gch_IssueDate=" + this.gch_IssueDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + string.Format(",{0}={1},{2}={3}", (object) "gch_IssueStore", (object) this.gch_IssueStore, (object) "gch_FaceValue", (object) this.gch_FaceValue) + ",gch_ExpireDate=" + this.gch_ExpireDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + ",gch_SaleDate=" + this.gch_SaleDate.GetDateToStrInNull(p_format: "\\'yyyy-MM-dd 00:00:00\\'") + string.Format(",{0}={1},{2}={3}", (object) "gch_SaleStore", (object) this.gch_SaleStore, (object) "gch_SalePosNo", (object) this.gch_SalePosNo) + string.Format(",{0}={1},{2}={3}", (object) "gch_SaleTransNo", (object) this.gch_SaleTransNo, (object) "gch_SaleEmpCode", (object) this.gch_SaleEmpCode) + string.Format(",{0}={1},{2}={3}", (object) "gch_SaleMemberNo", (object) this.gch_SaleMemberNo, (object) "gch_SaleKind", (object) this.gch_SaleKind) + ",gch_ReturnDate=" + this.gch_ReturnDate.GetDateToStrInNull(p_format: "\\'yyyy-MM-dd 00:00:00\\'") + string.Format(",{0}={1},{2}={3}", (object) "gch_ReturnStore", (object) this.gch_ReturnStore, (object) "gch_ReturnPosNo", (object) this.gch_ReturnPosNo) + string.Format(",{0}={1}", (object) "gch_ReturnTransNo", (object) this.gch_ReturnTransNo) + string.Format(",{0}={1}", (object) "gch_ReturnMemberNo", (object) this.gch_ReturnMemberNo) + ",gch_DisuseYn='" + this.gch_DisuseYn + "',gch_DisuseDate=" + this.gch_DisuseDate.GetDateToStrInNull(p_format: "\\'yyyy-MM-dd 00:00:00\\'") + string.Format(",{0}={1},{2}={3}", (object) "gch_DisuseStatement", (object) this.gch_DisuseStatement, (object) "gch_DisuseEmpCode", (object) this.gch_DisuseEmpCode) + ",gch_UseYn='" + this.gch_UseYn + "'" + string.Format(",{0}={1},{2}={3}", (object) "gch_ModDate", (object) this.gch_ModDate.GetDateToStrInNull(), (object) "gch_ModUser", (object) this.gch_ModUser) + " WHERE gch_GiftCardNo='" + this.gch_GiftCardNo + "'" + string.Format(" AND {0}={1}", (object) "gch_SiteID", (object) this.gch_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.gch_GiftCardNo, (object) this.gch_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TGiftCardHistory tgiftCardHistory = this;
      // ISSUE: reference to a compiler-generated method
      tgiftCardHistory.\u003C\u003En__1();
      if (await tgiftCardHistory.OleDB.ExecuteAsync(tgiftCardHistory.UpdateQuery()))
        return true;
      tgiftCardHistory.message = " " + tgiftCardHistory.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tgiftCardHistory.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tgiftCardHistory.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tgiftCardHistory.gch_GiftCardNo, (object) tgiftCardHistory.gch_SiteID) + " 내용 : " + tgiftCardHistory.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tgiftCardHistory.message);
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
      stringBuilder.Append(string.Format(" {0}={1}", (object) "gch_GiftCardID", (object) this.gch_GiftCardID) + ",gch_IssueDate=" + this.gch_IssueDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + string.Format(",{0}={1},{2}={3}", (object) "gch_IssueStore", (object) this.gch_IssueStore, (object) "gch_FaceValue", (object) this.gch_FaceValue) + ",gch_ExpireDate=" + this.gch_ExpireDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + ",gch_SaleDate=" + this.gch_SaleDate.GetDateToStrInNull(p_format: "\\'yyyy-MM-dd 00:00:00\\'") + string.Format(",{0}={1},{2}={3}", (object) "gch_SaleStore", (object) this.gch_SaleStore, (object) "gch_SalePosNo", (object) this.gch_SalePosNo) + string.Format(",{0}={1},{2}={3}", (object) "gch_SaleTransNo", (object) this.gch_SaleTransNo, (object) "gch_SaleEmpCode", (object) this.gch_SaleEmpCode) + string.Format(",{0}={1},{2}={3}", (object) "gch_SaleMemberNo", (object) this.gch_SaleMemberNo, (object) "gch_SaleKind", (object) this.gch_SaleKind) + ",gch_ReturnDate=" + this.gch_ReturnDate.GetDateToStrInNull(p_format: "\\'yyyy-MM-dd 00:00:00\\'") + string.Format(",{0}={1},{2}={3}", (object) "gch_ReturnStore", (object) this.gch_ReturnStore, (object) "gch_ReturnPosNo", (object) this.gch_ReturnPosNo) + string.Format(",{0}={1}", (object) "gch_ReturnTransNo", (object) this.gch_ReturnTransNo) + string.Format(",{0}={1}", (object) "gch_ReturnMemberNo", (object) this.gch_ReturnMemberNo) + ",gch_DisuseYn='" + this.gch_DisuseYn + "',gch_DisuseDate=" + this.gch_DisuseDate.GetDateToStrInNull(p_format: "\\'yyyy-MM-dd 00:00:00\\'") + string.Format(",{0}={1},{2}={3}", (object) "gch_DisuseStatement", (object) this.gch_DisuseStatement, (object) "gch_DisuseEmpCode", (object) this.gch_DisuseEmpCode) + ",gch_UseYn='" + this.gch_UseYn + "'" + string.Format(",{0}={1},{2}={3}", (object) "gch_ModDate", (object) this.gch_ModDate.GetDateToStrInNull(), (object) "gch_ModUser", (object) this.gch_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.gch_GiftCardNo, (object) this.gch_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TGiftCardHistory tgiftCardHistory = this;
      // ISSUE: reference to a compiler-generated method
      tgiftCardHistory.\u003C\u003En__1();
      if (await tgiftCardHistory.OleDB.ExecuteAsync(tgiftCardHistory.UpdateExInsertQuery()))
        return true;
      tgiftCardHistory.message = " " + tgiftCardHistory.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tgiftCardHistory.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tgiftCardHistory.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tgiftCardHistory.gch_GiftCardNo, (object) tgiftCardHistory.gch_SiteID) + " 내용 : " + tgiftCardHistory.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tgiftCardHistory.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "gch_SiteID") && Convert.ToInt64(hashtable[(object) "gch_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "gch_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "gch_GiftCardNo") && !string.IsNullOrEmpty(hashtable[(object) "gch_GiftCardNo"].ToString()))
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "gch_GiftCardNo", hashtable[(object) "gch_GiftCardNo"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gch_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "gch_GiftCardID") && Convert.ToInt64(hashtable[(object) "gch_GiftCardID"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gch_GiftCardID", hashtable[(object) "gch_GiftCardID"]));
        if (hashtable.ContainsKey((object) "gch_IssueDate") && !string.IsNullOrEmpty(hashtable[(object) "gch_IssueDate"].ToString()))
          stringBuilder.Append(" AND gch_IssueDate=" + new DateTime?((DateTime) hashtable[(object) "gch_IssueDate"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'"));
        if (hashtable.ContainsKey((object) "gch_IssueDate_BEGIN_") && !string.IsNullOrEmpty(hashtable[(object) "gch_IssueDate_BEGIN_"].ToString()) && hashtable.ContainsKey((object) "gch_IssueDate_END_") && !string.IsNullOrEmpty(hashtable[(object) "gch_IssueDate_END_"].ToString()))
          stringBuilder.Append(" AND gch_IssueDate<=" + new DateTime?((DateTime) hashtable[(object) "gch_IssueDate_BEGIN_"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + " AND gch_IssueDate>=" + new DateTime?((DateTime) hashtable[(object) "gch_IssueDate_END_"]).GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'"));
        if (hashtable.ContainsKey((object) "gch_IssueStore") && Convert.ToInt32(hashtable[(object) "gch_IssueStore"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gch_IssueStore", hashtable[(object) "gch_IssueStore"]));
        else if (hashtable.ContainsKey((object) "gch_IssueStore_IN_") && !string.IsNullOrEmpty(hashtable[(object) "gch_IssueStore_IN_"].ToString()))
        {
          if (hashtable[(object) "gch_IssueStore_IN_"].ToString().Contains(","))
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "gch_IssueStore", hashtable[(object) "gch_IssueStore_IN_"]));
          else
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gch_IssueStore", hashtable[(object) "gch_IssueStore_IN_"]));
        }
        else if (hashtable.ContainsKey((object) "_STORE_AUTHS_") && !string.IsNullOrEmpty(hashtable[(object) "_STORE_AUTHS_"].ToString()))
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "gch_IssueStore", hashtable[(object) "_STORE_AUTHS_"]));
        if (hashtable.ContainsKey((object) "gch_FaceValue") && Convert.ToInt32(hashtable[(object) "gch_FaceValue"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gch_FaceValue", hashtable[(object) "gch_FaceValue"]));
        else if (hashtable.ContainsKey((object) "gch_FaceValue_BEGIN_") && string.IsNullOrEmpty(hashtable[(object) "gch_FaceValue_BEGIN_"].ToString()) && hashtable.ContainsKey((object) "gch_FaceValue_END_") && string.IsNullOrEmpty(hashtable[(object) "gch_FaceValue_END_"].ToString()))
          stringBuilder.Append(" AND gch_FaceValue>=gch_FaceValue_BEGIN_ AND gch_FaceValue<=gch_FaceValue_END_");
        if (hashtable.ContainsKey((object) "gch_ExpireDate") && !string.IsNullOrEmpty(hashtable[(object) "gch_ExpireDate"].ToString()))
          stringBuilder.Append(" AND gch_ExpireDate=" + new DateTime?((DateTime) hashtable[(object) "gch_ExpireDate"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'"));
        else if (hashtable.ContainsKey((object) "gch_ExpireDate_BEGIN_") && !string.IsNullOrEmpty(hashtable[(object) "gch_ExpireDate_BEGIN_"].ToString()) && hashtable.ContainsKey((object) "gch_ExpireDate_END_") && !string.IsNullOrEmpty(hashtable[(object) "gch_ExpireDate_END_"].ToString()))
          stringBuilder.Append(" AND gch_ExpireDate<=" + new DateTime?((DateTime) hashtable[(object) "gch_ExpireDate_BEGIN_"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + " AND gch_ExpireDate>=" + new DateTime?((DateTime) hashtable[(object) "gch_ExpireDate_END_"]).GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'"));
        if (hashtable.ContainsKey((object) "gch_SaleDate") && !string.IsNullOrEmpty(hashtable[(object) "gch_SaleDate"].ToString()))
          stringBuilder.Append(" AND gch_SaleDate=" + new DateTime?((DateTime) hashtable[(object) "gch_SaleDate"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'"));
        else if (hashtable.ContainsKey((object) "gch_SaleDate_BEGIN_") && !string.IsNullOrEmpty(hashtable[(object) "gch_SaleDate_BEGIN_"].ToString()) && hashtable.ContainsKey((object) "gch_SaleDate_END_") && !string.IsNullOrEmpty(hashtable[(object) "gch_SaleDate_END_"].ToString()))
          stringBuilder.Append(" AND gch_SaleDate<=" + new DateTime?((DateTime) hashtable[(object) "gch_SaleDate_BEGIN_"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + " AND gch_SaleDate>=" + new DateTime?((DateTime) hashtable[(object) "gch_SaleDate_END_"]).GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'"));
        if (hashtable.ContainsKey((object) "gch_SaleStore") && Convert.ToInt32(hashtable[(object) "gch_SaleStore"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gch_SaleStore", hashtable[(object) "gch_SaleStore"]));
        else if (hashtable.ContainsKey((object) "gch_SaleStore_IN_") && !string.IsNullOrEmpty(hashtable[(object) "gch_SaleStore_IN_"].ToString()))
        {
          if (hashtable[(object) "gch_SaleStore_IN_"].ToString().Contains(","))
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "gch_SaleStore", hashtable[(object) "gch_SaleStore_IN_"]));
          else
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gch_SaleStore", hashtable[(object) "gch_SaleStore_IN_"]));
        }
        else if (hashtable.ContainsKey((object) "_STORE_AUTHS_") && !string.IsNullOrEmpty(hashtable[(object) "_STORE_AUTHS_"].ToString()))
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "gch_SaleStore", hashtable[(object) "_STORE_AUTHS_"]));
        if (hashtable.ContainsKey((object) "gch_SalePosNo") && Convert.ToInt32(hashtable[(object) "gch_SalePosNo"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gch_SalePosNo", hashtable[(object) "gch_SalePosNo"]));
        if (hashtable.ContainsKey((object) "gch_SaleTransNo") && Convert.ToInt32(hashtable[(object) "gch_SaleTransNo"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gch_SaleTransNo", hashtable[(object) "gch_SaleTransNo"]));
        if (hashtable.ContainsKey((object) "gch_SaleEmpCode") && Convert.ToInt32(hashtable[(object) "gch_SaleEmpCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gch_SaleEmpCode", hashtable[(object) "gch_SaleEmpCode"]));
        if (hashtable.ContainsKey((object) "gch_SaleMemberNo") && Convert.ToInt64(hashtable[(object) "gch_SaleMemberNo"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gch_SaleMemberNo", hashtable[(object) "gch_SaleMemberNo"]));
        if (hashtable.ContainsKey((object) "gch_SaleKind") && Convert.ToInt32(hashtable[(object) "gch_SaleKind"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gch_SaleKind", hashtable[(object) "gch_SaleKind"]));
        if (hashtable.ContainsKey((object) "gch_ReturnDate") && !string.IsNullOrEmpty(hashtable[(object) "gch_ReturnDate"].ToString()))
          stringBuilder.Append(" AND gch_ReturnDate=" + new DateTime?((DateTime) hashtable[(object) "gch_ReturnDate"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'"));
        else if (hashtable.ContainsKey((object) "gch_ReturnDate_BEGIN_") && !string.IsNullOrEmpty(hashtable[(object) "gch_ReturnDate_BEGIN_"].ToString()) && hashtable.ContainsKey((object) "gch_ReturnDate_END_") && !string.IsNullOrEmpty(hashtable[(object) "gch_ReturnDate_END_"].ToString()))
          stringBuilder.Append(" AND gch_ReturnDate<=" + new DateTime?((DateTime) hashtable[(object) "gch_ReturnDate_BEGIN_"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + " AND gch_ReturnDate>=" + new DateTime?((DateTime) hashtable[(object) "gch_ReturnDate_END_"]).GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'"));
        if (hashtable.ContainsKey((object) "gch_ReturnStore") && Convert.ToInt32(hashtable[(object) "gch_ReturnStore"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gch_ReturnStore", hashtable[(object) "gch_ReturnStore"]));
        else if (hashtable.ContainsKey((object) "gch_ReturnStore_IN_") && !string.IsNullOrEmpty(hashtable[(object) "gch_ReturnStore_IN_"].ToString()))
        {
          if (hashtable[(object) "gch_ReturnStore_IN_"].ToString().Contains(","))
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "gch_ReturnStore", hashtable[(object) "gch_ReturnStore_IN_"]));
          else
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gch_ReturnStore", hashtable[(object) "gch_ReturnStore_IN_"]));
        }
        else if (hashtable.ContainsKey((object) "_STORE_AUTHS_") && !string.IsNullOrEmpty(hashtable[(object) "_STORE_AUTHS_"].ToString()))
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "gch_ReturnStore", hashtable[(object) "_STORE_AUTHS_"]));
        if (hashtable.ContainsKey((object) "gch_ReturnPosNo") && Convert.ToInt32(hashtable[(object) "gch_ReturnPosNo"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gch_ReturnPosNo", hashtable[(object) "gch_ReturnPosNo"]));
        if (hashtable.ContainsKey((object) "gch_ReturnTransNo") && Convert.ToInt32(hashtable[(object) "gch_ReturnTransNo"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gch_ReturnTransNo", hashtable[(object) "gch_ReturnTransNo"]));
        if (hashtable.ContainsKey((object) "gch_ReturnMemberNo") && Convert.ToInt64(hashtable[(object) "gch_ReturnMemberNo"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gch_ReturnMemberNo", hashtable[(object) "gch_ReturnMemberNo"]));
        if (hashtable.ContainsKey((object) "gch_DisuseYn") && !string.IsNullOrEmpty(hashtable[(object) "gch_DisuseYn"].ToString()))
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "gch_DisuseYn", hashtable[(object) "gch_DisuseYn"]));
        if (hashtable.ContainsKey((object) "gch_DisuseDate") && !string.IsNullOrEmpty(hashtable[(object) "gch_DisuseDate"].ToString()))
          stringBuilder.Append(" AND gch_DisuseDate=" + new DateTime?((DateTime) hashtable[(object) "gch_DisuseDate"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'"));
        else if (hashtable.ContainsKey((object) "gch_DisuseDate_BEGIN_") && !string.IsNullOrEmpty(hashtable[(object) "gch_DisuseDate_BEGIN_"].ToString()) && hashtable.ContainsKey((object) "gch_DisuseDate_END_") && !string.IsNullOrEmpty(hashtable[(object) "gch_DisuseDate_END_"].ToString()))
          stringBuilder.Append(" AND gch_DisuseDate<=" + new DateTime?((DateTime) hashtable[(object) "gch_DisuseDate_BEGIN_"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + " AND gch_DisuseDate>=" + new DateTime?((DateTime) hashtable[(object) "gch_DisuseDate_END_"]).GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'"));
        if (hashtable.ContainsKey((object) "gch_DisuseStatement") && Convert.ToInt64(hashtable[(object) "gch_DisuseStatement"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gch_DisuseStatement", hashtable[(object) "gch_DisuseStatement"]));
        if (hashtable.ContainsKey((object) "gch_DisuseEmpCode") && Convert.ToInt32(hashtable[(object) "gch_DisuseEmpCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gch_DisuseEmpCode", hashtable[(object) "gch_DisuseEmpCode"]));
        if (hashtable.ContainsKey((object) "gch_UseYn") && !string.IsNullOrEmpty(hashtable[(object) "gch_UseYn"].ToString()))
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "gch_UseYn", hashtable[(object) "gch_UseYn"]));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "gch_GiftCardNo", hashtable[(object) "_KEY_WORD_"]));
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
        stringBuilder.Append(" SELECT  gch_GiftCardNo,gch_SiteID,gch_GiftCardID,gch_IssueDate,gch_IssueStore,gch_FaceValue,gch_ExpireDate,gch_SaleDate,gch_SaleStore,gch_SalePosNo,gch_SaleTransNo,gch_SaleEmpCode,gch_SaleMemberNo,gch_SaleKind,gch_ReturnDate,gch_ReturnStore,gch_ReturnPosNo,gch_ReturnTransNo,gch_ReturnMemberNo,gch_DisuseYn,gch_DisuseDate,gch_DisuseStatement,gch_DisuseEmpCode,gch_UseYn,gch_InDate,gch_InUser,gch_ModDate,gch_ModUser");
        stringBuilder.Append(" FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock());
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
