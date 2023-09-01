// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.Gift.GiftGiveHistory.TGiftGiveHistory
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

namespace UniBiz.Bo.Models.UniMembers.Gift.GiftGiveHistory
{
  public class TGiftGiveHistory : UbModelBase<TGiftGiveHistory>
  {
    private long _ggh_GiveNo;
    private long _ggh_SiteID;
    private DateTime? _ggh_RequestDate;
    private int _ggh_RequestStore;
    private int _ggh_RequestEmpCode;
    private string _ggh_RequestEmpName;
    private long _ggh_MemberNo;
    private string _ggh_MemberName;
    private string _ggh_RecipientTelNo;
    private int _ggh_GiftCode;
    private string _ggh_GiftName;
    private int _ggh_GiftPrice;
    private int _ggh_DeductionPoint;
    private string _ggh_Memo;
    private int _ggh_GiveStore;
    private int _ggh_GiveEmpCode;
    private string _ggh_GiveEmpName;
    private DateTime? _ggh_GiveDate;
    private int _ggh_Status;
    private DateTime? _ggh_InDate;
    private int _ggh_InUser;
    private DateTime? _ggh_ModDate;
    private int _ggh_ModUser;

    public override object _Key => (object) new object[1]
    {
      (object) this.ggh_GiveNo
    };

    public long ggh_GiveNo
    {
      get => this._ggh_GiveNo;
      set
      {
        this._ggh_GiveNo = value;
        this.Changed(nameof (ggh_GiveNo));
      }
    }

    public long ggh_SiteID
    {
      get => this._ggh_SiteID;
      set
      {
        this._ggh_SiteID = value;
        this.Changed(nameof (ggh_SiteID));
      }
    }

    public DateTime? ggh_RequestDate
    {
      get => this._ggh_RequestDate;
      set
      {
        this._ggh_RequestDate = value;
        this.Changed(nameof (ggh_RequestDate));
      }
    }

    public int ggh_RequestStore
    {
      get => this._ggh_RequestStore;
      set
      {
        this._ggh_RequestStore = value;
        this.Changed(nameof (ggh_RequestStore));
      }
    }

    public int ggh_RequestEmpCode
    {
      get => this._ggh_RequestEmpCode;
      set
      {
        this._ggh_RequestEmpCode = value;
        this.Changed(nameof (ggh_RequestEmpCode));
      }
    }

    public string ggh_RequestEmpName
    {
      get => this._ggh_RequestEmpName;
      set
      {
        this._ggh_RequestEmpName = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (ggh_RequestEmpName));
      }
    }

    public long ggh_MemberNo
    {
      get => this._ggh_MemberNo;
      set
      {
        this._ggh_MemberNo = value;
        this.Changed(nameof (ggh_MemberNo));
      }
    }

    public string ggh_MemberName
    {
      get => this._ggh_MemberName;
      set
      {
        this._ggh_MemberName = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (ggh_MemberName));
      }
    }

    public string ggh_RecipientTelNo
    {
      get => this._ggh_RecipientTelNo;
      set
      {
        this._ggh_RecipientTelNo = UbModelBase.LeftStr(value, 20).Replace("'", "´");
        this.Changed(nameof (ggh_RecipientTelNo));
      }
    }

    public int ggh_GiftCode
    {
      get => this._ggh_GiftCode;
      set
      {
        this._ggh_GiftCode = value;
        this.Changed(nameof (ggh_GiftCode));
      }
    }

    public string ggh_GiftName
    {
      get => this._ggh_GiftName;
      set
      {
        this._ggh_GiftName = UbModelBase.LeftStr(value, 50).Replace("'", "´");
        this.Changed(nameof (ggh_GiftName));
      }
    }

    public int ggh_GiftPrice
    {
      get => this._ggh_GiftPrice;
      set
      {
        this._ggh_GiftPrice = value;
        this.Changed(nameof (ggh_GiftPrice));
      }
    }

    public int ggh_DeductionPoint
    {
      get => this._ggh_DeductionPoint;
      set
      {
        this._ggh_DeductionPoint = value;
        this.Changed(nameof (ggh_DeductionPoint));
      }
    }

    public string ggh_Memo
    {
      get => this._ggh_Memo;
      set
      {
        this._ggh_Memo = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (ggh_Memo));
      }
    }

    public int ggh_GiveStore
    {
      get => this._ggh_GiveStore;
      set
      {
        this._ggh_GiveStore = value;
        this.Changed(nameof (ggh_GiveStore));
      }
    }

    public int ggh_GiveEmpCode
    {
      get => this._ggh_GiveEmpCode;
      set
      {
        this._ggh_GiveEmpCode = value;
        this.Changed(nameof (ggh_GiveEmpCode));
      }
    }

    public string ggh_GiveEmpName
    {
      get => this._ggh_GiveEmpName;
      set
      {
        this._ggh_GiveEmpName = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (ggh_GiveEmpName));
      }
    }

    public DateTime? ggh_GiveDate
    {
      get => this._ggh_GiveDate;
      set
      {
        this._ggh_GiveDate = value;
        this.Changed(nameof (ggh_GiveDate));
      }
    }

    public int ggh_Status
    {
      get => this._ggh_Status;
      set
      {
        this._ggh_Status = value;
        this.Changed(nameof (ggh_Status));
      }
    }

    public DateTime? ggh_InDate
    {
      get => this._ggh_InDate;
      set
      {
        this._ggh_InDate = value;
        this.Changed(nameof (ggh_InDate));
      }
    }

    public int ggh_InUser
    {
      get => this._ggh_InUser;
      set
      {
        this._ggh_InUser = value;
        this.Changed(nameof (ggh_InUser));
      }
    }

    public DateTime? ggh_ModDate
    {
      get => this._ggh_ModDate;
      set
      {
        this._ggh_ModDate = value;
        this.Changed(nameof (ggh_ModDate));
      }
    }

    public int ggh_ModUser
    {
      get => this._ggh_ModUser;
      set
      {
        this._ggh_ModUser = value;
        this.Changed(nameof (ggh_ModUser));
      }
    }

    public TGiftGiveHistory() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("ggh_GiveNo", new TTableColumn()
      {
        tc_orgin_name = "ggh_GiveNo",
        tc_trans_name = "지급No"
      });
      columnInfo.Add("ggh_SiteID", new TTableColumn()
      {
        tc_orgin_name = "ggh_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("ggh_RequestDate", new TTableColumn()
      {
        tc_orgin_name = "ggh_RequestDate",
        tc_trans_name = "요청일"
      });
      columnInfo.Add("ggh_RequestStore", new TTableColumn()
      {
        tc_orgin_name = "ggh_RequestStore",
        tc_trans_name = "요청지점"
      });
      columnInfo.Add("ggh_RequestEmpCode", new TTableColumn()
      {
        tc_orgin_name = "ggh_RequestEmpCode",
        tc_trans_name = "요청사원"
      });
      columnInfo.Add("ggh_RequestEmpName", new TTableColumn()
      {
        tc_orgin_name = "ggh_RequestEmpName",
        tc_trans_name = "요청사원명"
      });
      columnInfo.Add("ggh_MemberNo", new TTableColumn()
      {
        tc_orgin_name = "ggh_MemberNo",
        tc_trans_name = "회원코드"
      });
      columnInfo.Add("ggh_MemberName", new TTableColumn()
      {
        tc_orgin_name = "ggh_MemberName",
        tc_trans_name = "회원명"
      });
      columnInfo.Add("ggh_RecipientTelNo", new TTableColumn()
      {
        tc_orgin_name = "ggh_RecipientTelNo",
        tc_trans_name = "수령인 연락처"
      });
      columnInfo.Add("ggh_GiftCode", new TTableColumn()
      {
        tc_orgin_name = "ggh_GiftCode",
        tc_trans_name = "사은품코드"
      });
      columnInfo.Add("ggh_GiftName", new TTableColumn()
      {
        tc_orgin_name = "ggh_GiftName",
        tc_trans_name = "사은품명"
      });
      columnInfo.Add("ggh_GiftPrice", new TTableColumn()
      {
        tc_orgin_name = "ggh_GiftPrice",
        tc_trans_name = "사은품단가"
      });
      columnInfo.Add("ggh_DeductionPoint", new TTableColumn()
      {
        tc_orgin_name = "ggh_DeductionPoint",
        tc_trans_name = "차감포인트"
      });
      columnInfo.Add("ggh_Memo", new TTableColumn()
      {
        tc_orgin_name = "ggh_Memo",
        tc_trans_name = "메모"
      });
      columnInfo.Add("ggh_GiveStore", new TTableColumn()
      {
        tc_orgin_name = "ggh_GiveStore",
        tc_trans_name = "지급지점"
      });
      columnInfo.Add("ggh_GiveEmpCode", new TTableColumn()
      {
        tc_orgin_name = "ggh_GiveEmpCode",
        tc_trans_name = "지급사원"
      });
      columnInfo.Add("ggh_GiveEmpName", new TTableColumn()
      {
        tc_orgin_name = "ggh_GiveEmpName",
        tc_trans_name = "지급사원명"
      });
      columnInfo.Add("ggh_GiveDate", new TTableColumn()
      {
        tc_orgin_name = "ggh_GiveDate",
        tc_trans_name = "지급일시"
      });
      columnInfo.Add("ggh_Status", new TTableColumn()
      {
        tc_orgin_name = "ggh_Status",
        tc_trans_name = "사용상태"
      });
      columnInfo.Add("ggh_InDate", new TTableColumn()
      {
        tc_orgin_name = "ggh_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("ggh_InUser", new TTableColumn()
      {
        tc_orgin_name = "ggh_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("ggh_ModDate", new TTableColumn()
      {
        tc_orgin_name = "ggh_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("ggh_ModUser", new TTableColumn()
      {
        tc_orgin_name = "ggh_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.GiftGiveHistory;
      this.ggh_GiveNo = 0L;
      this.ggh_SiteID = 0L;
      this.ggh_RequestDate = new DateTime?();
      this.ggh_RequestStore = 0;
      this.ggh_RequestEmpCode = 0;
      this.ggh_RequestEmpName = string.Empty;
      this.ggh_MemberNo = 0L;
      this.ggh_MemberName = string.Empty;
      this.ggh_RecipientTelNo = string.Empty;
      this.ggh_GiftCode = 0;
      this.ggh_GiftName = string.Empty;
      this.ggh_GiftPrice = 0;
      this.ggh_DeductionPoint = 0;
      this.ggh_Memo = string.Empty;
      this.ggh_GiveStore = 0;
      this.ggh_GiveEmpCode = 0;
      this.ggh_GiveEmpName = string.Empty;
      this.ggh_GiveDate = new DateTime?();
      this.ggh_Status = 0;
      this.ggh_InDate = new DateTime?();
      this.ggh_InUser = 0;
      this.ggh_ModDate = new DateTime?();
      this.ggh_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TGiftGiveHistory();

    public override object Clone()
    {
      TGiftGiveHistory tgiftGiveHistory = base.Clone() as TGiftGiveHistory;
      tgiftGiveHistory.ggh_GiveNo = this.ggh_GiveNo;
      tgiftGiveHistory.ggh_SiteID = this.ggh_SiteID;
      tgiftGiveHistory.ggh_RequestDate = this.ggh_RequestDate;
      tgiftGiveHistory.ggh_RequestStore = this.ggh_RequestStore;
      tgiftGiveHistory.ggh_RequestEmpCode = this.ggh_RequestEmpCode;
      tgiftGiveHistory.ggh_RequestEmpName = this.ggh_RequestEmpName;
      tgiftGiveHistory.ggh_MemberNo = this.ggh_MemberNo;
      tgiftGiveHistory.ggh_MemberName = this.ggh_MemberName;
      tgiftGiveHistory.ggh_RecipientTelNo = this.ggh_RecipientTelNo;
      tgiftGiveHistory.ggh_GiftCode = this.ggh_GiftCode;
      tgiftGiveHistory.ggh_GiftName = this.ggh_GiftName;
      tgiftGiveHistory.ggh_GiftPrice = this.ggh_GiftPrice;
      tgiftGiveHistory.ggh_DeductionPoint = this.ggh_DeductionPoint;
      tgiftGiveHistory.ggh_Memo = this.ggh_Memo;
      tgiftGiveHistory.ggh_GiveStore = this.ggh_GiveStore;
      tgiftGiveHistory.ggh_GiveEmpCode = this.ggh_GiveEmpCode;
      tgiftGiveHistory.ggh_GiveEmpName = this.ggh_GiveEmpName;
      tgiftGiveHistory.ggh_GiveDate = this.ggh_GiveDate;
      tgiftGiveHistory.ggh_Status = this.ggh_Status;
      tgiftGiveHistory.ggh_InDate = this.ggh_InDate;
      tgiftGiveHistory.ggh_InUser = this.ggh_InUser;
      tgiftGiveHistory.ggh_ModDate = this.ggh_ModDate;
      tgiftGiveHistory.ggh_ModUser = this.ggh_ModUser;
      return (object) tgiftGiveHistory;
    }

    public void PutData(TGiftGiveHistory pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.ggh_GiveNo = pSource.ggh_GiveNo;
      this.ggh_SiteID = pSource.ggh_SiteID;
      this.ggh_RequestDate = pSource.ggh_RequestDate;
      this.ggh_RequestStore = pSource.ggh_RequestStore;
      this.ggh_RequestEmpCode = pSource.ggh_RequestEmpCode;
      this.ggh_RequestEmpName = pSource.ggh_RequestEmpName;
      this.ggh_MemberNo = pSource.ggh_MemberNo;
      this.ggh_MemberName = pSource.ggh_MemberName;
      this.ggh_RecipientTelNo = pSource.ggh_RecipientTelNo;
      this.ggh_GiftCode = pSource.ggh_GiftCode;
      this.ggh_GiftName = pSource.ggh_GiftName;
      this.ggh_GiftPrice = pSource.ggh_GiftPrice;
      this.ggh_DeductionPoint = pSource.ggh_DeductionPoint;
      this.ggh_Memo = pSource.ggh_Memo;
      this.ggh_GiveStore = pSource.ggh_GiveStore;
      this.ggh_GiveEmpCode = pSource.ggh_GiveEmpCode;
      this.ggh_GiveEmpName = pSource.ggh_GiveEmpName;
      this.ggh_GiveDate = pSource.ggh_GiveDate;
      this.ggh_Status = pSource.ggh_Status;
      this.ggh_InDate = pSource.ggh_InDate;
      this.ggh_InUser = pSource.ggh_InUser;
      this.ggh_ModDate = pSource.ggh_ModDate;
      this.ggh_ModUser = pSource.ggh_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.ggh_GiveNo = p_rs.GetFieldLong("ggh_GiveNo");
        if (this.ggh_GiveNo == 0L)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.ggh_SiteID = p_rs.GetFieldLong("ggh_SiteID");
        this.ggh_RequestDate = p_rs.GetFieldDateTime("ggh_RequestDate");
        this.ggh_RequestStore = p_rs.GetFieldInt("ggh_RequestStore");
        this.ggh_RequestEmpCode = p_rs.GetFieldInt("ggh_RequestEmpCode");
        this.ggh_RequestEmpName = p_rs.GetFieldString("ggh_RequestEmpName");
        this.ggh_MemberNo = p_rs.GetFieldLong("ggh_MemberNo");
        this.ggh_MemberName = p_rs.GetFieldString("ggh_MemberName");
        this.ggh_RecipientTelNo = p_rs.GetFieldString("ggh_RecipientTelNo");
        this.ggh_GiftCode = p_rs.GetFieldInt("ggh_GiftCode");
        this.ggh_GiftName = p_rs.GetFieldString("ggh_GiftName");
        this.ggh_GiftPrice = p_rs.GetFieldInt("ggh_GiftPrice");
        this.ggh_DeductionPoint = p_rs.GetFieldInt("ggh_DeductionPoint");
        this.ggh_Memo = p_rs.GetFieldString("ggh_Memo");
        this.ggh_GiveStore = p_rs.GetFieldInt("ggh_GiveStore");
        this.ggh_GiveEmpCode = p_rs.GetFieldInt("ggh_GiveEmpCode");
        this.ggh_GiveEmpName = p_rs.GetFieldString("ggh_GiveEmpName");
        this.ggh_GiveDate = p_rs.GetFieldDateTime("ggh_GiveDate");
        this.ggh_Status = p_rs.GetFieldInt("ggh_Status");
        this.ggh_InDate = p_rs.GetFieldDateTime("ggh_InDate");
        this.ggh_InUser = p_rs.GetFieldInt("ggh_InUser");
        this.ggh_ModDate = p_rs.GetFieldDateTime("ggh_ModDate");
        this.ggh_ModUser = p_rs.GetFieldInt("ggh_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode) + " ggh_GiveNo,ggh_SiteID,ggh_RequestDate,ggh_RequestStore,ggh_RequestEmpCode,ggh_RequestEmpName,ggh_MemberNo,ggh_MemberName,ggh_RecipientTelNo,ggh_GiftCode,ggh_GiftName,ggh_GiftPrice,ggh_DeductionPoint,ggh_Memo,ggh_GiveStore,ggh_GiveEmpCode,ggh_GiveEmpName,ggh_GiveDate,ggh_Status,ggh_InDate,ggh_InUser,ggh_ModDate,ggh_ModUser) VALUES ( " + string.Format(" {0}", (object) this.ggh_GiveNo) + string.Format(",{0}", (object) this.ggh_SiteID) + "," + this.ggh_RequestDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + string.Format(",{0},{1},'{2}'", (object) this.ggh_RequestStore, (object) this.ggh_RequestEmpCode, (object) this.ggh_RequestEmpName) + string.Format(",{0},'{1}','{2}'", (object) this.ggh_MemberNo, (object) this.ggh_MemberName, (object) this.ggh_RecipientTelNo) + string.Format(",{0},'{1}'", (object) this.ggh_GiftCode, (object) this.ggh_GiftName) + string.Format(",{0},{1},'{2}'", (object) this.ggh_GiftPrice, (object) this.ggh_DeductionPoint, (object) this.ggh_Memo) + string.Format(",{0},{1},'{2}'", (object) this.ggh_GiveStore, (object) this.ggh_GiveEmpCode, (object) this.ggh_GiveEmpName) + "," + this.ggh_GiveDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + string.Format(",{0}", (object) this.ggh_Status) + string.Format(",{0},{1}", (object) this.ggh_InDate.GetDateToStrInNull(), (object) this.ggh_InUser) + string.Format(",{0},{1}", (object) this.ggh_ModDate.GetDateToStrInNull(), (object) this.ggh_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.ggh_GiveNo, (object) this.ggh_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TGiftGiveHistory tgiftGiveHistory = this;
      // ISSUE: reference to a compiler-generated method
      tgiftGiveHistory.\u003C\u003En__0();
      if (await tgiftGiveHistory.OleDB.ExecuteAsync(tgiftGiveHistory.InsertQuery()))
        return true;
      tgiftGiveHistory.message = " " + tgiftGiveHistory.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tgiftGiveHistory.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tgiftGiveHistory.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tgiftGiveHistory.ggh_GiveNo, (object) tgiftGiveHistory.ggh_SiteID) + " 내용 : " + tgiftGiveHistory.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tgiftGiveHistory.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode) + " ggh_RequestDate=" + this.ggh_RequestDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + string.Format(",{0}={1},{2}={3}", (object) "ggh_RequestStore", (object) this.ggh_RequestStore, (object) "ggh_RequestEmpCode", (object) this.ggh_RequestEmpCode) + ",ggh_RequestEmpName='" + this.ggh_RequestEmpName + "'" + string.Format(",{0}={1},{2}='{3}'", (object) "ggh_MemberNo", (object) this.ggh_MemberNo, (object) "ggh_MemberName", (object) this.ggh_MemberName) + ",ggh_RecipientTelNo='" + this.ggh_RecipientTelNo + "'" + string.Format(",{0}={1},{2}='{3}'", (object) "ggh_GiftCode", (object) this.ggh_GiftCode, (object) "ggh_GiftName", (object) this.ggh_GiftName) + string.Format(",{0}={1},{2}={3}", (object) "ggh_GiftPrice", (object) this.ggh_GiftPrice, (object) "ggh_DeductionPoint", (object) this.ggh_DeductionPoint) + ",ggh_Memo='" + this.ggh_Memo + "'" + string.Format(",{0}={1},{2}={3}", (object) "ggh_GiveStore", (object) this.ggh_GiveStore, (object) "ggh_GiveEmpCode", (object) this.ggh_GiveEmpCode) + ",ggh_GiveEmpName='" + this.ggh_GiveEmpName + "',ggh_GiveDate=" + this.ggh_GiveDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + string.Format(",{0}={1}", (object) "ggh_Status", (object) this.ggh_Status) + string.Format(",{0}={1},{2}={3}", (object) "ggh_ModDate", (object) this.ggh_ModDate.GetDateToStrInNull(), (object) "ggh_ModUser", (object) this.ggh_ModUser) + string.Format(" WHERE {0}={1}", (object) "ggh_GiveNo", (object) this.ggh_GiveNo) + string.Format(" AND {0}={1}", (object) "ggh_SiteID", (object) this.ggh_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.ggh_GiveNo, (object) this.ggh_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TGiftGiveHistory tgiftGiveHistory = this;
      // ISSUE: reference to a compiler-generated method
      tgiftGiveHistory.\u003C\u003En__1();
      if (await tgiftGiveHistory.OleDB.ExecuteAsync(tgiftGiveHistory.UpdateQuery()))
        return true;
      tgiftGiveHistory.message = " " + tgiftGiveHistory.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tgiftGiveHistory.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tgiftGiveHistory.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tgiftGiveHistory.ggh_GiveNo, (object) tgiftGiveHistory.ggh_SiteID) + " 내용 : " + tgiftGiveHistory.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tgiftGiveHistory.message);
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
      stringBuilder.Append(" ggh_RequestDate=" + this.ggh_RequestDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + string.Format(",{0}={1},{2}={3}", (object) "ggh_RequestStore", (object) this.ggh_RequestStore, (object) "ggh_RequestEmpCode", (object) this.ggh_RequestEmpCode) + ",ggh_RequestEmpName='" + this.ggh_RequestEmpName + "'" + string.Format(",{0}={1},{2}='{3}'", (object) "ggh_MemberNo", (object) this.ggh_MemberNo, (object) "ggh_MemberName", (object) this.ggh_MemberName) + ",ggh_RecipientTelNo='" + this.ggh_RecipientTelNo + "'" + string.Format(",{0}={1},{2}='{3}'", (object) "ggh_GiftCode", (object) this.ggh_GiftCode, (object) "ggh_GiftName", (object) this.ggh_GiftName) + string.Format(",{0}={1},{2}={3}", (object) "ggh_GiftPrice", (object) this.ggh_GiftPrice, (object) "ggh_DeductionPoint", (object) this.ggh_DeductionPoint) + ",ggh_Memo='" + this.ggh_Memo + "'" + string.Format(",{0}={1},{2}={3}", (object) "ggh_GiveStore", (object) this.ggh_GiveStore, (object) "ggh_GiveEmpCode", (object) this.ggh_GiveEmpCode) + ",ggh_GiveEmpName='" + this.ggh_GiveEmpName + "',ggh_GiveDate=" + this.ggh_GiveDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + string.Format(",{0}={1}", (object) "ggh_Status", (object) this.ggh_Status) + string.Format(",{0}={1},{2}={3}", (object) "ggh_ModDate", (object) this.ggh_ModDate.GetDateToStrInNull(), (object) "ggh_ModUser", (object) this.ggh_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.ggh_GiveNo, (object) this.ggh_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TGiftGiveHistory tgiftGiveHistory = this;
      // ISSUE: reference to a compiler-generated method
      tgiftGiveHistory.\u003C\u003En__1();
      if (await tgiftGiveHistory.OleDB.ExecuteAsync(tgiftGiveHistory.UpdateExInsertQuery()))
        return true;
      tgiftGiveHistory.message = " " + tgiftGiveHistory.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tgiftGiveHistory.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tgiftGiveHistory.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tgiftGiveHistory.ggh_GiveNo, (object) tgiftGiveHistory.ggh_SiteID) + " 내용 : " + tgiftGiveHistory.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tgiftGiveHistory.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "ggh_SiteID") && Convert.ToInt64(hashtable[(object) "ggh_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "ggh_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "ggh_GiveNo") && Convert.ToInt64(hashtable[(object) "ggh_GiveNo"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ggh_GiveNo", hashtable[(object) "ggh_GiveNo"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ggh_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "ggh_RequestDate") && !string.IsNullOrEmpty(hashtable[(object) "ggh_RequestDate"].ToString()))
          stringBuilder.Append(" AND ggh_RequestDate<=" + new DateTime?((DateTime) hashtable[(object) "ggh_RequestDate"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + " AND ggh_RequestDate>=" + new DateTime?((DateTime) hashtable[(object) "ggh_RequestDate"]).GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'"));
        if (hashtable.ContainsKey((object) "ggh_RequestDate_BEGIN_") && !string.IsNullOrEmpty(hashtable[(object) "ggh_RequestDate_BEGIN_"].ToString()) && hashtable.ContainsKey((object) "ggh_RequestDate_END_") && !string.IsNullOrEmpty(hashtable[(object) "ggh_RequestDate_END_"].ToString()))
          stringBuilder.Append(" AND ggh_RequestDate<=" + new DateTime?((DateTime) hashtable[(object) "ggh_RequestDate_BEGIN_"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + " AND ggh_RequestDate>=" + new DateTime?((DateTime) hashtable[(object) "ggh_RequestDate_END_"]).GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'"));
        if (hashtable.ContainsKey((object) "ggh_RequestStore") && Convert.ToInt32(hashtable[(object) "ggh_RequestStore"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ggh_RequestStore", hashtable[(object) "ggh_RequestStore"]));
        else if (hashtable.ContainsKey((object) "ggh_RequestStore_IN_") && hashtable[(object) "ggh_RequestStore_IN_"].ToString().Length > 0)
        {
          if (hashtable[(object) "ggh_RequestStore_IN_"].ToString().Contains(","))
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "ggh_RequestStore", hashtable[(object) "ggh_RequestStore_IN_"]));
          else
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ggh_RequestStore", hashtable[(object) "ggh_RequestStore_IN_"]));
        }
        else if (hashtable.ContainsKey((object) "_STORE_AUTHS_") && !string.IsNullOrEmpty(hashtable[(object) "_STORE_AUTHS_"].ToString()))
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "ggh_RequestStore", hashtable[(object) "_STORE_AUTHS_"]));
        if (hashtable.ContainsKey((object) "ggh_RequestEmpCode") && Convert.ToInt32(hashtable[(object) "ggh_RequestEmpCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ggh_RequestEmpCode", hashtable[(object) "ggh_RequestEmpCode"]));
        if (hashtable.ContainsKey((object) "ggh_MemberNo") && Convert.ToInt64(hashtable[(object) "ggh_MemberNo"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ggh_MemberNo", hashtable[(object) "ggh_MemberNo"]));
        if (hashtable.ContainsKey((object) "ggh_GiftCode") && Convert.ToInt32(hashtable[(object) "ggh_GiftCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ggh_GiftCode", hashtable[(object) "ggh_GiftCode"]));
        if (hashtable.ContainsKey((object) "ggh_GiveStore") && Convert.ToInt32(hashtable[(object) "ggh_GiveStore"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ggh_GiveStore", hashtable[(object) "ggh_GiveStore"]));
        else if (hashtable.ContainsKey((object) "ggh_GiveStore_IN_") && hashtable[(object) "ggh_GiveStore_IN_"].ToString().Length > 0)
        {
          if (hashtable[(object) "ggh_GiveStore_IN_"].ToString().Contains(","))
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "ggh_GiveStore", hashtable[(object) "ggh_GiveStore_IN_"]));
          else
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ggh_GiveStore", hashtable[(object) "ggh_GiveStore_IN_"]));
        }
        else if (hashtable.ContainsKey((object) "_STORE_AUTHS_") && !string.IsNullOrEmpty(hashtable[(object) "_STORE_AUTHS_"].ToString()))
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "ggh_GiveStore", hashtable[(object) "_STORE_AUTHS_"]));
        if (hashtable.ContainsKey((object) "ggh_GiveEmpCode") && Convert.ToInt32(hashtable[(object) "ggh_GiveEmpCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ggh_GiveEmpCode", hashtable[(object) "ggh_GiveEmpCode"]));
        if (hashtable.ContainsKey((object) "ggh_GiveDate") && !string.IsNullOrEmpty(hashtable[(object) "ggh_GiveDate"].ToString()))
          stringBuilder.Append(" AND ggh_GiveDate<=" + new DateTime?((DateTime) hashtable[(object) "ggh_GiveDate"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + " AND ggh_GiveDate>=" + new DateTime?((DateTime) hashtable[(object) "ggh_GiveDate"]).GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'"));
        if (hashtable.ContainsKey((object) "ggh_GiveDate_BEGIN_") && !string.IsNullOrEmpty(hashtable[(object) "ggh_GiveDate_BEGIN_"].ToString()) && hashtable.ContainsKey((object) "ggh_GiveDate_END_") && !string.IsNullOrEmpty(hashtable[(object) "ggh_GiveDate_END_"].ToString()))
          stringBuilder.Append(" AND ggh_GiveDate<=" + new DateTime?((DateTime) hashtable[(object) "ggh_GiveDate_BEGIN_"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + " AND ggh_GiveDate>=" + new DateTime?((DateTime) hashtable[(object) "ggh_GiveDate_END_"]).GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'"));
        if (hashtable.ContainsKey((object) "ggh_Status") && Convert.ToInt32(hashtable[(object) "ggh_Status"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ggh_Status", hashtable[(object) "ggh_Status"]));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && !string.IsNullOrEmpty(hashtable[(object) "_KEY_WORD_"].ToString()))
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "ggh_MemberName", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "ggh_RecipientTelNo", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "ggh_GiftName", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "ggh_Memo", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "ggh_RequestEmpName", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "ggh_GiveEmpName", hashtable[(object) "_KEY_WORD_"]));
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
        stringBuilder.Append(" SELECT  ggh_GiveNo,ggh_SiteID,ggh_RequestDate,ggh_RequestStore,ggh_RequestEmpCode,ggh_RequestEmpName,ggh_MemberNo,ggh_MemberName,ggh_RecipientTelNo,ggh_GiftCode,ggh_GiftName,ggh_GiftPrice,ggh_DeductionPoint,ggh_Memo,ggh_GiveStore,ggh_GiveEmpCode,ggh_GiveEmpName,ggh_GiveDate,ggh_Status,ggh_InDate,ggh_InUser,ggh_ModDate,ggh_ModUser");
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
