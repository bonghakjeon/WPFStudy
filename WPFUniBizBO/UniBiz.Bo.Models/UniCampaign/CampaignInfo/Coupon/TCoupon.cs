// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniCampaign.CampaignInfo.Coupon.TCoupon
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

namespace UniBiz.Bo.Models.UniCampaign.CampaignInfo.Coupon
{
  public class TCoupon : UbModelBase<TCoupon>
  {
    private long _cp_GiftCardID;
    private long _cp_CouponID;
    private long _cp_SiteID;
    private int _cp_CouponType;
    private int _cp_Apply;
    private int _cp_EmpCode;
    private string _cp_Title;
    private string _cp_Url;
    private string _cp_Desc;
    private string _cp_LMSKey;
    private int _cp_IssueCnt;
    private int _cp_UsableCnt;
    private long _cp_CampaignCode;
    private long _cp_PromotionID;
    private int _cp_Status;
    private DateTime? _cp_ApprovalDate;
    private DateTime? _cp_SendDate;
    private DateTime? _cp_InDate;
    private int _cp_InUser;
    private DateTime? _cp_ModDate;
    private int _cp_ModUser;

    public override object _Key => (object) new object[2]
    {
      (object) this.cp_GiftCardID,
      (object) this.cp_CouponID
    };

    public long cp_GiftCardID
    {
      get => this._cp_GiftCardID;
      set
      {
        this._cp_GiftCardID = value;
        this.Changed(nameof (cp_GiftCardID));
      }
    }

    public long cp_CouponID
    {
      get => this._cp_CouponID;
      set
      {
        this._cp_CouponID = value;
        this.Changed(nameof (cp_CouponID));
      }
    }

    public long cp_SiteID
    {
      get => this._cp_SiteID;
      set
      {
        this._cp_SiteID = value;
        this.Changed(nameof (cp_SiteID));
      }
    }

    public int cp_CouponType
    {
      get => this._cp_CouponType;
      set
      {
        this._cp_CouponType = value;
        this.Changed(nameof (cp_CouponType));
        this.Changed("cp_CouponTypeDesc");
      }
    }

    public string cp_CouponTypeDesc => this.cp_CouponType != 0 ? Enum2StrConverter.ToCouponType(this.cp_CouponType).ToDescription() : string.Empty;

    public int cp_Apply
    {
      get => this._cp_Apply;
      set
      {
        this._cp_Apply = value;
        this.Changed(nameof (cp_Apply));
        this.Changed("cp_ApplyDesc");
      }
    }

    public string cp_ApplyDesc => this.cp_Apply != 0 ? Enum2StrConverter.ToCouponApply(this.cp_Apply).ToDescription() : string.Empty;

    public int cp_EmpCode
    {
      get => this._cp_EmpCode;
      set
      {
        this._cp_EmpCode = value;
        this.Changed(nameof (cp_EmpCode));
      }
    }

    public string cp_Title
    {
      get => this._cp_Title;
      set
      {
        this._cp_Title = UbModelBase.LeftStr(value, 50).Replace("'", "´");
        this.Changed(nameof (cp_Title));
      }
    }

    public string cp_Url
    {
      get => this._cp_Url;
      set
      {
        this._cp_Url = UbModelBase.LeftStr(value, 200).Replace("'", "´");
        this.Changed(nameof (cp_Url));
      }
    }

    public string cp_Desc
    {
      get => this._cp_Desc;
      set
      {
        this._cp_Desc = UbModelBase.LeftStr(value, 500).Replace("'", "´");
        this.Changed(nameof (cp_Desc));
      }
    }

    public string cp_LMSKey
    {
      get => this._cp_LMSKey;
      set
      {
        this._cp_LMSKey = UbModelBase.LeftStr(value, 20).Replace("'", "´");
        this.Changed(nameof (cp_LMSKey));
      }
    }

    public int cp_IssueCnt
    {
      get => this._cp_IssueCnt;
      set
      {
        this._cp_IssueCnt = value;
        this.Changed(nameof (cp_IssueCnt));
      }
    }

    public int cp_UsableCnt
    {
      get => this._cp_UsableCnt;
      set
      {
        this._cp_UsableCnt = value;
        this.Changed(nameof (cp_UsableCnt));
      }
    }

    public long cp_CampaignCode
    {
      get => this._cp_CampaignCode;
      set
      {
        this._cp_CampaignCode = value;
        this.Changed(nameof (cp_CampaignCode));
      }
    }

    public long cp_PromotionID
    {
      get => this._cp_PromotionID;
      set
      {
        this._cp_PromotionID = value;
        this.Changed(nameof (cp_PromotionID));
      }
    }

    public int cp_Status
    {
      get => this._cp_Status;
      set
      {
        this._cp_Status = value;
        this.Changed(nameof (cp_Status));
        this.Changed("cp_StatusDesc");
      }
    }

    public string cp_StatusDesc => this.cp_Status != 0 ? Enum2StrConverter.ToCouponStatus(this.cp_Status).ToDescription() : string.Empty;

    public DateTime? cp_ApprovalDate
    {
      get => this._cp_ApprovalDate;
      set
      {
        this._cp_ApprovalDate = value;
        this.Changed(nameof (cp_ApprovalDate));
      }
    }

    public DateTime? cp_SendDate
    {
      get => this._cp_SendDate;
      set
      {
        this._cp_SendDate = value;
        this.Changed(nameof (cp_SendDate));
      }
    }

    public DateTime? cp_InDate
    {
      get => this._cp_InDate;
      set
      {
        this._cp_InDate = value;
        this.Changed(nameof (cp_InDate));
      }
    }

    public int cp_InUser
    {
      get => this._cp_InUser;
      set
      {
        this._cp_InUser = value;
        this.Changed(nameof (cp_InUser));
      }
    }

    public DateTime? cp_ModDate
    {
      get => this._cp_ModDate;
      set
      {
        this._cp_ModDate = value;
        this.Changed(nameof (cp_ModDate));
      }
    }

    public int cp_ModUser
    {
      get => this._cp_ModUser;
      set
      {
        this._cp_ModUser = value;
        this.Changed(nameof (cp_ModUser));
      }
    }

    public override DateTime? ModDate => this.cp_ModDate ?? (this.cp_ModDate = this.cp_InDate);

    public TCoupon() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("cp_GiftCardID", new TTableColumn()
      {
        tc_orgin_name = "cp_GiftCardID",
        tc_trans_name = "상품권코드"
      });
      columnInfo.Add("cp_CouponID", new TTableColumn()
      {
        tc_orgin_name = "cp_CouponID",
        tc_trans_name = "쿠폰ID"
      });
      columnInfo.Add("cp_SiteID", new TTableColumn()
      {
        tc_orgin_name = "cp_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("cp_CouponType", new TTableColumn()
      {
        tc_orgin_name = "cp_CouponType",
        tc_trans_name = "쿠폰구분",
        tc_comm_code = 227
      });
      columnInfo.Add("cp_Apply", new TTableColumn()
      {
        tc_orgin_name = "cp_Apply",
        tc_trans_name = "회원인증시 적용",
        tc_comm_code = 228
      });
      columnInfo.Add("cp_EmpCode", new TTableColumn()
      {
        tc_orgin_name = "cp_EmpCode",
        tc_trans_name = "담당자코드"
      });
      columnInfo.Add("cp_Title", new TTableColumn()
      {
        tc_orgin_name = "cp_Title",
        tc_trans_name = "타이틀"
      });
      columnInfo.Add("cp_Url", new TTableColumn()
      {
        tc_orgin_name = "cp_Url",
        tc_trans_name = "디자인 URL"
      });
      columnInfo.Add("cp_Desc", new TTableColumn()
      {
        tc_orgin_name = "cp_Desc",
        tc_trans_name = "설명"
      });
      columnInfo.Add("cp_LMSKey", new TTableColumn()
      {
        tc_orgin_name = "cp_LMSKey",
        tc_trans_name = "LMS전송키"
      });
      columnInfo.Add("cp_IssueCnt", new TTableColumn()
      {
        tc_orgin_name = "cp_IssueCnt",
        tc_trans_name = "발급건수"
      });
      columnInfo.Add("cp_UsableCnt", new TTableColumn()
      {
        tc_orgin_name = "cp_UsableCnt",
        tc_trans_name = "사용가능횟수"
      });
      columnInfo.Add("cp_CampaignCode", new TTableColumn()
      {
        tc_orgin_name = "cp_CampaignCode",
        tc_trans_name = "캠페인코드"
      });
      columnInfo.Add("cp_PromotionID", new TTableColumn()
      {
        tc_orgin_name = "cp_PromotionID",
        tc_trans_name = "프로모션ID"
      });
      columnInfo.Add("cp_Status", new TTableColumn()
      {
        tc_orgin_name = "cp_Status",
        tc_trans_name = "상태",
        tc_comm_code = 229
      });
      columnInfo.Add("cp_ApprovalDate", new TTableColumn()
      {
        tc_orgin_name = "cp_ApprovalDate",
        tc_trans_name = "승인일시"
      });
      columnInfo.Add("cp_SendDate", new TTableColumn()
      {
        tc_orgin_name = "cp_SendDate",
        tc_trans_name = "발송일시"
      });
      columnInfo.Add("cp_InDate", new TTableColumn()
      {
        tc_orgin_name = "cp_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("cp_InUser", new TTableColumn()
      {
        tc_orgin_name = "cp_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("cp_ModDate", new TTableColumn()
      {
        tc_orgin_name = "cp_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("cp_ModUser", new TTableColumn()
      {
        tc_orgin_name = "cp_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.Coupon;
      this.cp_GiftCardID = this.cp_CouponID = 0L;
      this.cp_SiteID = 0L;
      this.cp_CouponType = 0;
      this.cp_Apply = 0;
      this.cp_EmpCode = 0;
      this.cp_Title = this.cp_Url = this.cp_Desc = this.cp_LMSKey = string.Empty;
      this.cp_IssueCnt = this.cp_UsableCnt = 0;
      this.cp_CampaignCode = this.cp_PromotionID = 0L;
      this.cp_Status = 0;
      this.cp_ApprovalDate = new DateTime?();
      this.cp_SendDate = new DateTime?();
      this.cp_InDate = new DateTime?();
      this.cp_InUser = 0;
      this.cp_ModDate = new DateTime?();
      this.cp_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TCoupon();

    public override object Clone()
    {
      TCoupon tcoupon = base.Clone() as TCoupon;
      tcoupon.cp_GiftCardID = this.cp_GiftCardID;
      tcoupon.cp_CouponID = this.cp_CouponID;
      tcoupon.cp_SiteID = this.cp_SiteID;
      tcoupon.cp_CouponType = this.cp_CouponType;
      tcoupon.cp_Apply = this.cp_Apply;
      tcoupon.cp_EmpCode = this.cp_EmpCode;
      tcoupon.cp_Title = this.cp_Title;
      tcoupon.cp_Url = this.cp_Url;
      tcoupon.cp_Desc = this.cp_Desc;
      tcoupon.cp_LMSKey = this.cp_LMSKey;
      tcoupon.cp_IssueCnt = this.cp_IssueCnt;
      tcoupon.cp_UsableCnt = this.cp_UsableCnt;
      tcoupon.cp_CampaignCode = this.cp_CampaignCode;
      tcoupon.cp_PromotionID = this.cp_PromotionID;
      tcoupon.cp_Status = this.cp_Status;
      tcoupon.cp_ApprovalDate = this.cp_ApprovalDate;
      tcoupon.cp_SendDate = this.cp_SendDate;
      tcoupon.cp_InDate = this.cp_InDate;
      tcoupon.cp_InUser = this.cp_InUser;
      tcoupon.cp_ModDate = this.cp_ModDate;
      tcoupon.cp_ModUser = this.cp_ModUser;
      return (object) tcoupon;
    }

    public void PutData(TCoupon pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.cp_GiftCardID = pSource.cp_GiftCardID;
      this.cp_CouponID = pSource.cp_CouponID;
      this.cp_SiteID = pSource.cp_SiteID;
      this.cp_CouponType = pSource.cp_CouponType;
      this.cp_Apply = pSource.cp_Apply;
      this.cp_EmpCode = pSource.cp_EmpCode;
      this.cp_Title = pSource.cp_Title;
      this.cp_Url = pSource.cp_Url;
      this.cp_Desc = pSource.cp_Desc;
      this.cp_LMSKey = pSource.cp_LMSKey;
      this.cp_IssueCnt = pSource.cp_IssueCnt;
      this.cp_UsableCnt = pSource.cp_UsableCnt;
      this.cp_CampaignCode = pSource.cp_CampaignCode;
      this.cp_PromotionID = pSource.cp_PromotionID;
      this.cp_Status = pSource.cp_Status;
      this.cp_ApprovalDate = pSource.cp_ApprovalDate;
      this.cp_SendDate = pSource.cp_SendDate;
      this.cp_InDate = pSource.cp_InDate;
      this.cp_InUser = pSource.cp_InUser;
      this.cp_ModDate = pSource.cp_ModDate;
      this.cp_ModUser = pSource.cp_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.cp_GiftCardID = p_rs.GetFieldLong("cp_GiftCardID");
        if (this.cp_GiftCardID == 0L)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.cp_CouponID = p_rs.GetFieldLong("cp_CouponID");
        this.cp_SiteID = p_rs.GetFieldLong("cp_SiteID");
        this.cp_CouponType = p_rs.GetFieldInt("cp_CouponType");
        this.cp_Apply = p_rs.GetFieldInt("cp_Apply");
        this.cp_EmpCode = p_rs.GetFieldInt("cp_EmpCode");
        this.cp_Title = p_rs.GetFieldString("cp_Title");
        this.cp_Url = p_rs.GetFieldString("cp_Url");
        this.cp_Desc = p_rs.GetFieldString("cp_Desc");
        this.cp_LMSKey = p_rs.GetFieldString("cp_LMSKey");
        this.cp_IssueCnt = p_rs.GetFieldInt("cp_IssueCnt");
        this.cp_UsableCnt = p_rs.GetFieldInt("cp_UsableCnt");
        this.cp_CampaignCode = p_rs.GetFieldLong("cp_CampaignCode");
        this.cp_PromotionID = p_rs.GetFieldLong("cp_PromotionID");
        this.cp_Status = p_rs.GetFieldInt("cp_Status");
        this.cp_ApprovalDate = p_rs.GetFieldDateTime("cp_ApprovalDate");
        this.cp_SendDate = p_rs.GetFieldDateTime("cp_SendDate");
        this.cp_InDate = p_rs.GetFieldDateTime("cp_InDate");
        this.cp_InUser = p_rs.GetFieldInt("cp_InUser");
        this.cp_ModDate = p_rs.GetFieldDateTime("cp_ModDate");
        this.cp_ModUser = p_rs.GetFieldInt("cp_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_CAMPANIGN), (object) this.TableCode) + " cp_GiftCardID,cp_CouponID,cp_SiteID,cp_CouponType,cp_Apply,cp_EmpCode,cp_Title,cp_Url,cp_Desc,cp_LMSKey,cp_IssueCnt,cp_UsableCnt,cp_CampaignCode,cp_PromotionID,cp_Status,cp_ApprovalDate,cp_SendDate,cp_InDate,cp_InUser,cp_ModDate,cp_ModUser) VALUES ( " + string.Format(" {0},{1}", (object) this.cp_GiftCardID, (object) this.cp_CouponID) + string.Format(",{0}", (object) this.cp_SiteID) + string.Format(",{0},{1},{2}", (object) this.cp_CouponType, (object) this.cp_Apply, (object) this.cp_EmpCode) + ",'" + this.cp_Title + "','" + this.cp_Url + "','" + this.cp_Desc + "','" + this.cp_LMSKey + "'" + string.Format(",{0},{1}", (object) this.cp_IssueCnt, (object) this.cp_UsableCnt) + string.Format(",{0},{1}", (object) this.cp_CampaignCode, (object) this.cp_PromotionID) + string.Format(",{0}", (object) this.cp_Status) + "," + this.cp_ApprovalDate.GetDateToStrInNull() + "," + this.cp_SendDate.GetDateToStrInNull() + string.Format(",{0},{1}", (object) this.cp_InDate.GetDateToStrInNull(), (object) this.cp_InUser) + string.Format(",{0},{1}", (object) this.cp_ModDate.GetDateToStrInNull(), (object) this.cp_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.cp_GiftCardID, (object) this.cp_CouponID, (object) this.cp_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TCoupon tcoupon = this;
      // ISSUE: reference to a compiler-generated method
      tcoupon.\u003C\u003En__0();
      if (await tcoupon.OleDB.ExecuteAsync(tcoupon.InsertQuery()))
        return true;
      tcoupon.message = " " + tcoupon.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tcoupon.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tcoupon.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tcoupon.cp_GiftCardID, (object) tcoupon.cp_CouponID, (object) tcoupon.cp_SiteID) + " 내용 : " + tcoupon.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tcoupon.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_CAMPANIGN), (object) this.TableCode) + string.Format(" {0}={1},{2}={3}", (object) "cp_CouponType", (object) this.cp_CouponType, (object) "cp_Apply", (object) this.cp_Apply) + string.Format(",{0}={1}", (object) "cp_EmpCode", (object) this.cp_EmpCode) + ",cp_Title='" + this.cp_Title + "',cp_Url='" + this.cp_Url + "',cp_Desc='" + this.cp_Desc + "',cp_LMSKey='" + this.cp_LMSKey + "'" + string.Format(",{0}={1},{2}={3}", (object) "cp_IssueCnt", (object) this.cp_IssueCnt, (object) "cp_UsableCnt", (object) this.cp_UsableCnt) + string.Format(",{0}={1},{2}={3}", (object) "cp_CampaignCode", (object) this.cp_CampaignCode, (object) "cp_PromotionID", (object) this.cp_PromotionID) + string.Format(",{0}={1}", (object) "cp_Status", (object) this.cp_Status) + ",cp_ApprovalDate=" + this.cp_ApprovalDate.GetDateToStrInNull() + ",cp_SendDate=" + this.cp_SendDate.GetDateToStrInNull() + string.Format(",{0}={1},{2}={3}", (object) "cp_ModDate", (object) this.cp_ModDate.GetDateToStrInNull(), (object) "cp_ModUser", (object) this.cp_ModUser) + string.Format(" WHERE {0}={1}", (object) "cp_GiftCardID", (object) this.cp_GiftCardID) + string.Format(" AND {0}={1}", (object) "cp_CouponID", (object) this.cp_CouponID) + string.Format(" AND {0}={1}", (object) "cp_SiteID", (object) this.cp_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.cp_GiftCardID, (object) this.cp_CouponID, (object) this.cp_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TCoupon tcoupon = this;
      // ISSUE: reference to a compiler-generated method
      tcoupon.\u003C\u003En__1();
      if (await tcoupon.OleDB.ExecuteAsync(tcoupon.UpdateQuery()))
        return true;
      tcoupon.message = " " + tcoupon.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tcoupon.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tcoupon.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tcoupon.cp_GiftCardID, (object) tcoupon.cp_CouponID, (object) tcoupon.cp_SiteID) + " 내용 : " + tcoupon.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tcoupon.message);
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
      stringBuilder.Append(string.Format(" {0}={1},{2}={3}", (object) "cp_CouponType", (object) this.cp_CouponType, (object) "cp_Apply", (object) this.cp_Apply) + string.Format(",{0}={1}", (object) "cp_EmpCode", (object) this.cp_EmpCode) + ",cp_Title='" + this.cp_Title + "',cp_Url='" + this.cp_Url + "',cp_Desc='" + this.cp_Desc + "',cp_LMSKey='" + this.cp_LMSKey + "'" + string.Format(",{0}={1},{2}={3}", (object) "cp_IssueCnt", (object) this.cp_IssueCnt, (object) "cp_UsableCnt", (object) this.cp_UsableCnt) + string.Format(",{0}={1},{2}={3}", (object) "cp_CampaignCode", (object) this.cp_CampaignCode, (object) "cp_PromotionID", (object) this.cp_PromotionID) + string.Format(",{0}={1}", (object) "cp_Status", (object) this.cp_Status) + ",cp_ApprovalDate=" + this.cp_ApprovalDate.GetDateToStrInNull() + ",cp_SendDate=" + this.cp_SendDate.GetDateToStrInNull() + string.Format(",{0}={1},{2}={3}", (object) "cp_ModDate", (object) this.cp_ModDate.GetDateToStrInNull(), (object) "cp_ModUser", (object) this.cp_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.cp_GiftCardID, (object) this.cp_CouponID, (object) this.cp_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TCoupon tcoupon = this;
      // ISSUE: reference to a compiler-generated method
      tcoupon.\u003C\u003En__1();
      if (await tcoupon.OleDB.ExecuteAsync(tcoupon.UpdateExInsertQuery()))
        return true;
      tcoupon.message = " " + tcoupon.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tcoupon.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tcoupon.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tcoupon.cp_GiftCardID, (object) tcoupon.cp_CouponID, (object) tcoupon.cp_SiteID) + " 내용 : " + tcoupon.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tcoupon.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "cp_SiteID") && Convert.ToInt64(hashtable[(object) "cp_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "cp_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "cp_GiftCardID") && Convert.ToInt64(hashtable[(object) "cp_GiftCardID"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "cp_GiftCardID", hashtable[(object) "cp_GiftCardID"]));
        if (hashtable.ContainsKey((object) "cp_CouponID") && Convert.ToInt64(hashtable[(object) "cp_CouponID"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "cp_CouponID", hashtable[(object) "cp_CouponID"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "cp_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "cp_CouponType") && Convert.ToInt32(hashtable[(object) "cp_CouponType"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "cp_CouponType", hashtable[(object) "cp_CouponType"]));
        if (hashtable.ContainsKey((object) "cp_Apply") && Convert.ToInt32(hashtable[(object) "cp_Apply"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "cp_Apply", hashtable[(object) "cp_Apply"]));
        if (hashtable.ContainsKey((object) "cp_EmpCode") && Convert.ToInt32(hashtable[(object) "cp_EmpCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "cp_EmpCode", hashtable[(object) "cp_EmpCode"]));
        if (hashtable.ContainsKey((object) "cp_LMSKey") && Convert.ToInt64(hashtable[(object) "cp_LMSKey"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "cp_LMSKey", hashtable[(object) "cp_LMSKey"]));
        if (hashtable.ContainsKey((object) "cp_CampaignCode") && Convert.ToInt64(hashtable[(object) "cp_CampaignCode"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "cp_CampaignCode", hashtable[(object) "cp_CampaignCode"]));
        if (hashtable.ContainsKey((object) "cp_PromotionID") && Convert.ToInt64(hashtable[(object) "cp_PromotionID"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "cp_PromotionID", hashtable[(object) "cp_PromotionID"]));
        if (hashtable.ContainsKey((object) "cp_Status") && Convert.ToInt32(hashtable[(object) "cp_Status"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "cp_Status", hashtable[(object) "cp_Status"]));
        if (hashtable.ContainsKey((object) "cp_ApprovalDate") && !string.IsNullOrEmpty(hashtable[(object) "cp_ApprovalDate"].ToString()))
          stringBuilder.Append(" AND cp_ApprovalDate<=" + new DateTime?((DateTime) hashtable[(object) "cp_ApprovalDate"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + " AND cp_ApprovalDate>=" + new DateTime?((DateTime) hashtable[(object) "cp_ApprovalDate"]).GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'"));
        if (hashtable.ContainsKey((object) "cp_SendDate") && !string.IsNullOrEmpty(hashtable[(object) "cp_SendDate"].ToString()))
          stringBuilder.Append(" AND cp_SendDate<=" + new DateTime?((DateTime) hashtable[(object) "cp_SendDate"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + " AND cp_SendDate>=" + new DateTime?((DateTime) hashtable[(object) "cp_SendDate"]).GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'"));
        if (hashtable.ContainsKey((object) "cp_SendDate_BEFORE_") && !string.IsNullOrEmpty(hashtable[(object) "cp_SendDate_BEFORE_"].ToString()) && hashtable.ContainsKey((object) "cp_SendDate_END_") && !string.IsNullOrEmpty(hashtable[(object) "cp_SendDate_END_"].ToString()))
        {
          string dateToStr1 = new DateTime?((DateTime) hashtable[(object) "cp_SendDate_BEFORE_"]).GetDateToStr("yyyy-MM-dd 00:00:00");
          string dateToStr2 = new DateTime?((DateTime) hashtable[(object) "cp_SendDate_BEFORE_"]).GetDateToStr("yyyy-MM-dd 23:59:59");
          string dateToStr3 = new DateTime?((DateTime) hashtable[(object) "cp_SendDate_END_"]).GetDateToStr("yyyy-MM-dd 00:00:00");
          string dateToStr4 = new DateTime?((DateTime) hashtable[(object) "cp_SendDate_END_"]).GetDateToStr("yyyy-MM-dd 23:59:59");
          stringBuilder.Append(" AND (");
          stringBuilder.Append(" (cp_SendDate <= '" + dateToStr1 + "' AND cp_SendDate >= '" + dateToStr2 + "' )");
          stringBuilder.Append(" OR (cp_SendDate <= '" + dateToStr3 + "' AND cp_SendDate >= '" + dateToStr4 + "' )");
          stringBuilder.Append(" OR (cp_SendDate >= '" + dateToStr1 + "' AND cp_SendDate <= '" + dateToStr4 + "' )");
          stringBuilder.Append(") ");
        }
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && !string.IsNullOrEmpty(hashtable[(object) "_KEY_WORD_"].ToString()))
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "cp_Title", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "cp_Url", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "cp_Desc", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "cp_LMSKey", hashtable[(object) "_KEY_WORD_"]));
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
        stringBuilder.Append(" SELECT  cp_GiftCardID,cp_CouponID,cp_SiteID,cp_CouponType,cp_Apply,cp_EmpCode,cp_Title,cp_Url,cp_Desc,cp_LMSKey,cp_IssueCnt,cp_UsableCnt,cp_CampaignCode,cp_PromotionID,cp_Status,cp_ApprovalDate,cp_SendDate,cp_InDate,cp_InUser,cp_ModDate,cp_ModUser");
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
