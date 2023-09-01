// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniCampaign.CampaignInfo.CouponDetail.TCouponDetail
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

namespace UniBiz.Bo.Models.UniCampaign.CampaignInfo.CouponDetail
{
  public class TCouponDetail : UbModelBase<TCouponDetail>
  {
    private string _cpd_CouponNo;
    private long _cpd_GiftCardID;
    private long _cpd_CouponID;
    private long _cpd_SiteID;
    private int _cpd_ApplyDiv;
    private long _cpd_MemberNo;
    private string _cpd_MobileNo;
    private int _cpd_UseCnt;
    private string _cpd_StopYn;
    private DateTime? _cpd_InDate;
    private int _cpd_InUser;
    private DateTime? _cpd_ModDate;
    private int _cpd_ModUser;

    public override object _Key => (object) new object[3]
    {
      (object) this.cpd_CouponNo,
      (object) this.cpd_GiftCardID,
      (object) this.cpd_CouponID
    };

    public string cpd_CouponNo
    {
      get => this._cpd_CouponNo;
      set
      {
        this._cpd_CouponNo = UbModelBase.LeftStr(value, 20).Replace("'", "´");
        this.Changed(nameof (cpd_CouponNo));
      }
    }

    public long cpd_GiftCardID
    {
      get => this._cpd_GiftCardID;
      set
      {
        this._cpd_GiftCardID = value;
        this.Changed(nameof (cpd_GiftCardID));
      }
    }

    public long cpd_CouponID
    {
      get => this._cpd_CouponID;
      set
      {
        this._cpd_CouponID = value;
        this.Changed(nameof (cpd_CouponID));
      }
    }

    public long cpd_SiteID
    {
      get => this._cpd_SiteID;
      set
      {
        this._cpd_SiteID = value;
        this.Changed(nameof (cpd_SiteID));
      }
    }

    public int cpd_ApplyDiv
    {
      get => this._cpd_ApplyDiv;
      set
      {
        this._cpd_ApplyDiv = value;
        this.Changed(nameof (cpd_ApplyDiv));
        this.Changed("cpd_ApplyDivDesc");
      }
    }

    public string cpd_ApplyDivDesc => this.cpd_ApplyDiv != 0 ? Enum2StrConverter.ToCouponApplyDiv(this.cpd_ApplyDiv).ToDescription() : string.Empty;

    public long cpd_MemberNo
    {
      get => this._cpd_MemberNo;
      set
      {
        this._cpd_MemberNo = value;
        this.Changed(nameof (cpd_MemberNo));
      }
    }

    public string cpd_MobileNo
    {
      get => this._cpd_MobileNo;
      set
      {
        this._cpd_MobileNo = UbModelBase.LeftStr(value, 20).Replace("'", "´");
        this.Changed(nameof (cpd_MobileNo));
      }
    }

    public int cpd_UseCnt
    {
      get => this._cpd_UseCnt;
      set
      {
        this._cpd_UseCnt = value;
        this.Changed(nameof (cpd_UseCnt));
      }
    }

    public string cpd_StopYn
    {
      get => this._cpd_StopYn;
      set
      {
        this._cpd_StopYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (cpd_StopYn));
        this.Changed("cpd_IsStop");
        this.Changed("cpd_StopYnDesc");
      }
    }

    public bool cpd_IsStop => "Y".Equals(this.cpd_StopYn);

    public string cpd_StopYnDesc => !"Y".Equals(this.cpd_StopYn) ? "허용" : "중지";

    public DateTime? cpd_InDate
    {
      get => this._cpd_InDate;
      set
      {
        this._cpd_InDate = value;
        this.Changed(nameof (cpd_InDate));
      }
    }

    public int cpd_InUser
    {
      get => this._cpd_InUser;
      set
      {
        this._cpd_InUser = value;
        this.Changed(nameof (cpd_InUser));
      }
    }

    public DateTime? cpd_ModDate
    {
      get => this._cpd_ModDate;
      set
      {
        this._cpd_ModDate = value;
        this.Changed(nameof (cpd_ModDate));
      }
    }

    public int cpd_ModUser
    {
      get => this._cpd_ModUser;
      set
      {
        this._cpd_ModUser = value;
        this.Changed(nameof (cpd_ModUser));
      }
    }

    public override DateTime? ModDate => this.cpd_ModDate ?? (this.cpd_ModDate = this.cpd_InDate);

    public TCouponDetail() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("cpd_CouponNo", new TTableColumn()
      {
        tc_orgin_name = "cpd_CouponNo",
        tc_trans_name = "쿠폰번호"
      });
      columnInfo.Add("cpd_GiftCardID", new TTableColumn()
      {
        tc_orgin_name = "cpd_GiftCardID",
        tc_trans_name = "상품권코드"
      });
      columnInfo.Add("cpd_CouponID", new TTableColumn()
      {
        tc_orgin_name = "cpd_CouponID",
        tc_trans_name = "쿠폰ID"
      });
      columnInfo.Add("cpd_SiteID", new TTableColumn()
      {
        tc_orgin_name = "cpd_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("cpd_ApplyDiv", new TTableColumn()
      {
        tc_orgin_name = "cpd_ApplyDiv",
        tc_trans_name = "적용구분",
        tc_comm_code = 230
      });
      columnInfo.Add("cpd_MemberNo", new TTableColumn()
      {
        tc_orgin_name = "cpd_MemberNo",
        tc_trans_name = "회원(회원유형)"
      });
      columnInfo.Add("cpd_MobileNo", new TTableColumn()
      {
        tc_orgin_name = "cpd_MobileNo",
        tc_trans_name = "휴대폰번호"
      });
      columnInfo.Add("cpd_UseCnt", new TTableColumn()
      {
        tc_orgin_name = "cpd_UseCnt",
        tc_trans_name = "사용횟수"
      });
      columnInfo.Add("cpd_StopYn", new TTableColumn()
      {
        tc_orgin_name = "cpd_StopYn",
        tc_trans_name = "중지여부"
      });
      columnInfo.Add("cpd_InDate", new TTableColumn()
      {
        tc_orgin_name = "cpd_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("cpd_InUser", new TTableColumn()
      {
        tc_orgin_name = "cpd_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("cpd_ModDate", new TTableColumn()
      {
        tc_orgin_name = "cpd_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("cpd_ModUser", new TTableColumn()
      {
        tc_orgin_name = "cpd_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.CouponDetail;
      this.cpd_CouponNo = string.Empty;
      this.cpd_GiftCardID = this.cpd_CouponID = 0L;
      this.cpd_SiteID = 0L;
      this.cpd_ApplyDiv = 0;
      this.cpd_MemberNo = 0L;
      this.cpd_MobileNo = string.Empty;
      this.cpd_UseCnt = 0;
      this.cpd_StopYn = "N";
      this.cpd_InDate = new DateTime?();
      this.cpd_InUser = 0;
      this.cpd_ModDate = new DateTime?();
      this.cpd_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TCouponDetail();

    public override object Clone()
    {
      TCouponDetail tcouponDetail = base.Clone() as TCouponDetail;
      tcouponDetail.cpd_CouponNo = this.cpd_CouponNo;
      tcouponDetail.cpd_GiftCardID = this.cpd_GiftCardID;
      tcouponDetail.cpd_CouponID = this.cpd_CouponID;
      tcouponDetail.cpd_SiteID = this.cpd_SiteID;
      tcouponDetail.cpd_ApplyDiv = this.cpd_ApplyDiv;
      tcouponDetail.cpd_MemberNo = this.cpd_MemberNo;
      tcouponDetail.cpd_MobileNo = this.cpd_MobileNo;
      tcouponDetail.cpd_UseCnt = this.cpd_UseCnt;
      tcouponDetail.cpd_StopYn = this.cpd_StopYn;
      tcouponDetail.cpd_InDate = this.cpd_InDate;
      tcouponDetail.cpd_InUser = this.cpd_InUser;
      tcouponDetail.cpd_ModDate = this.cpd_ModDate;
      tcouponDetail.cpd_ModUser = this.cpd_ModUser;
      return (object) tcouponDetail;
    }

    public void PutData(TCouponDetail pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.cpd_CouponNo = pSource.cpd_CouponNo;
      this.cpd_GiftCardID = pSource.cpd_GiftCardID;
      this.cpd_CouponID = pSource.cpd_CouponID;
      this.cpd_SiteID = pSource.cpd_SiteID;
      this.cpd_ApplyDiv = pSource.cpd_ApplyDiv;
      this.cpd_MemberNo = pSource.cpd_MemberNo;
      this.cpd_MobileNo = pSource.cpd_MobileNo;
      this.cpd_UseCnt = pSource.cpd_UseCnt;
      this.cpd_StopYn = pSource.cpd_StopYn;
      this.cpd_InDate = pSource.cpd_InDate;
      this.cpd_InUser = pSource.cpd_InUser;
      this.cpd_ModDate = pSource.cpd_ModDate;
      this.cpd_ModUser = pSource.cpd_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.cpd_CouponNo = p_rs.GetFieldString("cpd_CouponNo");
        if (string.IsNullOrEmpty(this.cpd_CouponNo))
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.cpd_GiftCardID = p_rs.GetFieldLong("cpd_GiftCardID");
        this.cpd_CouponID = p_rs.GetFieldLong("cpd_CouponID");
        this.cpd_SiteID = p_rs.GetFieldLong("cpd_SiteID");
        this.cpd_ApplyDiv = p_rs.GetFieldInt("cpd_ApplyDiv");
        this.cpd_MemberNo = (long) p_rs.GetFieldInt("cpd_MemberNo");
        this.cpd_MobileNo = p_rs.GetFieldString("cpd_MobileNo");
        this.cpd_UseCnt = p_rs.GetFieldInt("cpd_UseCnt");
        this.cpd_StopYn = p_rs.GetFieldString("cpd_StopYn");
        this.cpd_InDate = p_rs.GetFieldDateTime("cpd_InDate");
        this.cpd_InUser = p_rs.GetFieldInt("cpd_InUser");
        this.cpd_ModDate = p_rs.GetFieldDateTime("cpd_ModDate");
        this.cpd_ModUser = p_rs.GetFieldInt("cpd_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_CAMPANIGN), (object) this.TableCode) + " cpd_CouponNo,cpd_GiftCardID,cpd_CouponID,cpd_SiteID,cpd_ApplyDiv,cpd_MemberNo,cpd_MobileNo,cpd_UseCnt,cpd_StopYn,cpd_InDate,cpd_InUser,cpd_ModDate,cpd_ModUser) VALUES ( " + string.Format(" '{0}',{1},{2}", (object) this.cpd_CouponNo, (object) this.cpd_GiftCardID, (object) this.cpd_CouponID) + string.Format(",{0}", (object) this.cpd_SiteID) + string.Format(",{0},{1},'{2}'", (object) this.cpd_ApplyDiv, (object) this.cpd_MemberNo, (object) this.cpd_MobileNo) + string.Format(",{0},'{1}'", (object) this.cpd_UseCnt, (object) this.cpd_StopYn) + string.Format(",{0},{1}", (object) this.cpd_InDate.GetDateToStrInNull(), (object) this.cpd_InUser) + string.Format(",{0},{1}", (object) this.cpd_ModDate.GetDateToStrInNull(), (object) this.cpd_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.cpd_CouponNo, (object) this.cpd_GiftCardID, (object) this.cpd_CouponNo, (object) this.cpd_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TCouponDetail tcouponDetail = this;
      // ISSUE: reference to a compiler-generated method
      tcouponDetail.\u003C\u003En__0();
      if (await tcouponDetail.OleDB.ExecuteAsync(tcouponDetail.InsertQuery()))
        return true;
      tcouponDetail.message = " " + tcouponDetail.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tcouponDetail.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tcouponDetail.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tcouponDetail.cpd_CouponNo, (object) tcouponDetail.cpd_GiftCardID, (object) tcouponDetail.cpd_CouponNo, (object) tcouponDetail.cpd_SiteID) + " 내용 : " + tcouponDetail.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tcouponDetail.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_CAMPANIGN), (object) this.TableCode) + string.Format(" {0}={1},{2}={3}", (object) "cpd_ApplyDiv", (object) this.cpd_ApplyDiv, (object) "cpd_MemberNo", (object) this.cpd_MemberNo) + ",cpd_MobileNo='" + this.cpd_MobileNo + "'" + string.Format(",{0}={1},{2}='{3}'", (object) "cpd_UseCnt", (object) this.cpd_UseCnt, (object) "cpd_StopYn", (object) this.cpd_StopYn) + string.Format(",{0}={1},{2}={3}", (object) "cpd_ModDate", (object) this.cpd_ModDate.GetDateToStrInNull(), (object) "cpd_ModUser", (object) this.cpd_ModUser) + " WHERE cpd_CouponNo='" + this.cpd_CouponNo + "'" + string.Format(" AND {0}={1}", (object) "cpd_GiftCardID", (object) this.cpd_GiftCardID) + " AND cpd_CouponNo=" + this.cpd_CouponNo + string.Format(" AND {0}={1}", (object) "cpd_SiteID", (object) this.cpd_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.cpd_CouponNo, (object) this.cpd_GiftCardID, (object) this.cpd_CouponNo, (object) this.cpd_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TCouponDetail tcouponDetail = this;
      // ISSUE: reference to a compiler-generated method
      tcouponDetail.\u003C\u003En__1();
      if (await tcouponDetail.OleDB.ExecuteAsync(tcouponDetail.UpdateQuery()))
        return true;
      tcouponDetail.message = " " + tcouponDetail.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tcouponDetail.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tcouponDetail.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tcouponDetail.cpd_CouponNo, (object) tcouponDetail.cpd_GiftCardID, (object) tcouponDetail.cpd_CouponNo, (object) tcouponDetail.cpd_SiteID) + " 내용 : " + tcouponDetail.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tcouponDetail.message);
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
      stringBuilder.Append(string.Format(" {0}={1},{2}={3}", (object) "cpd_ApplyDiv", (object) this.cpd_ApplyDiv, (object) "cpd_MemberNo", (object) this.cpd_MemberNo) + ",cpd_MobileNo='" + this.cpd_MobileNo + "'" + string.Format(",{0}={1},{2}='{3}'", (object) "cpd_UseCnt", (object) this.cpd_UseCnt, (object) "cpd_StopYn", (object) this.cpd_StopYn) + string.Format(",{0}={1},{2}={3}", (object) "cpd_ModDate", (object) this.cpd_ModDate.GetDateToStrInNull(), (object) "cpd_ModUser", (object) this.cpd_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.cpd_CouponNo, (object) this.cpd_GiftCardID, (object) this.cpd_CouponNo, (object) this.cpd_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TCouponDetail tcouponDetail = this;
      // ISSUE: reference to a compiler-generated method
      tcouponDetail.\u003C\u003En__1();
      if (await tcouponDetail.OleDB.ExecuteAsync(tcouponDetail.UpdateExInsertQuery()))
        return true;
      tcouponDetail.message = " " + tcouponDetail.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tcouponDetail.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tcouponDetail.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tcouponDetail.cpd_CouponNo, (object) tcouponDetail.cpd_GiftCardID, (object) tcouponDetail.cpd_CouponNo, (object) tcouponDetail.cpd_SiteID) + " 내용 : " + tcouponDetail.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tcouponDetail.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "cpd_SiteID") && Convert.ToInt64(hashtable[(object) "cpd_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "cpd_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "cpd_CouponNo") && Convert.ToInt64(hashtable[(object) "cpd_CouponNo"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "cpd_CouponNo", hashtable[(object) "cpd_CouponNo"]));
        if (hashtable.ContainsKey((object) "cpd_GiftCardID") && Convert.ToInt64(hashtable[(object) "cpd_GiftCardID"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "cpd_GiftCardID", hashtable[(object) "cpd_GiftCardID"]));
        if (hashtable.ContainsKey((object) "cpd_CouponID") && Convert.ToInt64(hashtable[(object) "cpd_CouponID"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "cpd_CouponID", hashtable[(object) "cpd_CouponID"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "cpd_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "cpd_ApplyDiv") && Convert.ToInt32(hashtable[(object) "cpd_ApplyDiv"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "cpd_ApplyDiv", hashtable[(object) "cpd_ApplyDiv"]));
        if (hashtable.ContainsKey((object) "cpd_MemberNo") && Convert.ToInt64(hashtable[(object) "cpd_MemberNo"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "cpd_MemberNo", hashtable[(object) "cpd_MemberNo"]));
        if (hashtable.ContainsKey((object) "cpd_MobileNo") && Convert.ToInt64(hashtable[(object) "cpd_MobileNo"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "cpd_MobileNo", hashtable[(object) "cpd_MobileNo"]));
        if (hashtable.ContainsKey((object) "cpd_StopYn") && Convert.ToInt64(hashtable[(object) "cpd_StopYn"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "cpd_StopYn", hashtable[(object) "cpd_StopYn"]));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && !string.IsNullOrEmpty(hashtable[(object) "_KEY_WORD_"].ToString()))
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "cpd_MobileNo", hashtable[(object) "_KEY_WORD_"]));
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
        stringBuilder.Append(" SELECT  cpd_CouponNo,cpd_GiftCardID,cpd_CouponID,cpd_SiteID,cpd_ApplyDiv,cpd_MemberNo,cpd_MobileNo,cpd_UseCnt,cpd_StopYn,cpd_InDate,cpd_InUser,cpd_ModDate,cpd_ModUser");
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
