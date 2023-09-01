// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.Info.MemberCreditHistory.TMemberCreditHistory
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

namespace UniBiz.Bo.Models.UniMembers.Info.MemberCreditHistory
{
  public class TMemberCreditHistory : UbModelBase<TMemberCreditHistory>
  {
    private int _mch_ID;
    private long _mch_SiteID;
    private long _mch_MemberNo;
    private int _mch_StoreCode;
    private DateTime? _mch_StartDate;
    private DateTime? _mch_EndDate;
    private int _mch_PayMethod;
    private int _mch_PayCondition;
    private DateTime? _mch_InDate;
    private int _mch_InUser;
    private DateTime? _mch_ModDate;
    private int _mch_ModUser;

    public override object _Key => (object) new object[1]
    {
      (object) this.mch_ID
    };

    public int mch_ID
    {
      get => this._mch_ID;
      set
      {
        this._mch_ID = value;
        this.Changed(nameof (mch_ID));
      }
    }

    public long mch_SiteID
    {
      get => this._mch_SiteID;
      set
      {
        this._mch_SiteID = value;
        this.Changed(nameof (mch_SiteID));
      }
    }

    public long mch_MemberNo
    {
      get => this._mch_MemberNo;
      set
      {
        this._mch_MemberNo = value;
        this.Changed(nameof (mch_MemberNo));
      }
    }

    public int mch_StoreCode
    {
      get => this._mch_StoreCode;
      set
      {
        this._mch_StoreCode = value;
        this.Changed(nameof (mch_StoreCode));
      }
    }

    public DateTime? mch_StartDate
    {
      get => this._mch_StartDate;
      set
      {
        this._mch_StartDate = value;
        this.Changed(nameof (mch_StartDate));
      }
    }

    public DateTime? mch_EndDate
    {
      get => this._mch_EndDate;
      set
      {
        this._mch_EndDate = value;
        this.Changed(nameof (mch_EndDate));
      }
    }

    public int mch_PayMethod
    {
      get => this._mch_PayMethod;
      set
      {
        this._mch_PayMethod = value;
        this.Changed(nameof (mch_PayMethod));
        this.Changed("mch_PayMethodDesc");
      }
    }

    public string mch_PayMethodDesc => this.mch_PayMethod != 0 ? Enum2StrConverter.ToCommonCodeTypeMemo(this.mch_SiteID, EnumCommonCodeType.SupplierPayMethod, this.mch_PayMethod) : string.Empty;

    public int mch_PayCondition
    {
      get => this._mch_PayCondition;
      set
      {
        this._mch_PayCondition = value;
        this.Changed(nameof (mch_PayCondition));
      }
    }

    public DateTime? mch_InDate
    {
      get => this._mch_InDate;
      set
      {
        this._mch_InDate = value;
        this.Changed(nameof (mch_InDate));
      }
    }

    public int mch_InUser
    {
      get => this._mch_InUser;
      set
      {
        this._mch_InUser = value;
        this.Changed(nameof (mch_InUser));
      }
    }

    public DateTime? mch_ModDate
    {
      get => this._mch_ModDate;
      set
      {
        this._mch_ModDate = value;
        this.Changed(nameof (mch_ModDate));
      }
    }

    public int mch_ModUser
    {
      get => this._mch_ModUser;
      set
      {
        this._mch_ModUser = value;
        this.Changed(nameof (mch_ModUser));
      }
    }

    public TMemberCreditHistory() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("mch_ID", new TTableColumn()
      {
        tc_orgin_name = "mch_ID",
        tc_trans_name = "협력업체 결제 이력 KEY"
      });
      columnInfo.Add("mch_SiteID", new TTableColumn()
      {
        tc_orgin_name = "mch_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("mch_MemberNo", new TTableColumn()
      {
        tc_orgin_name = "mch_MemberNo",
        tc_trans_name = "회원코드"
      });
      columnInfo.Add("mch_StoreCode", new TTableColumn()
      {
        tc_orgin_name = "mch_StoreCode",
        tc_trans_name = "지점코드"
      });
      columnInfo.Add("mch_StartDate", new TTableColumn()
      {
        tc_orgin_name = "mch_StartDate",
        tc_trans_name = "시작일자"
      });
      columnInfo.Add("mch_EndDate", new TTableColumn()
      {
        tc_orgin_name = "mch_EndDate",
        tc_trans_name = "종료일자"
      });
      columnInfo.Add("mch_PayMethod", new TTableColumn()
      {
        tc_orgin_name = "mch_PayMethod",
        tc_trans_name = "결제수단"
      });
      columnInfo.Add("mch_PayCondition", new TTableColumn()
      {
        tc_orgin_name = "mch_PayCondition",
        tc_trans_name = "결제조건"
      });
      columnInfo.Add("mch_InDate", new TTableColumn()
      {
        tc_orgin_name = "mch_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("mch_InUser", new TTableColumn()
      {
        tc_orgin_name = "mch_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("mch_ModDate", new TTableColumn()
      {
        tc_orgin_name = "mch_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("mch_ModUser", new TTableColumn()
      {
        tc_orgin_name = "mch_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.MemberCreditHistory;
      this.mch_ID = 0;
      this.mch_SiteID = 0L;
      this.mch_MemberNo = 0L;
      this.mch_StoreCode = 0;
      this.mch_StartDate = new DateTime?();
      this.mch_EndDate = new DateTime?();
      this.mch_PayMethod = this.mch_PayCondition = 0;
      this.mch_InDate = new DateTime?();
      this.mch_InUser = 0;
      this.mch_ModDate = new DateTime?();
      this.mch_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TMemberCreditHistory();

    public override object Clone()
    {
      TMemberCreditHistory tmemberCreditHistory = base.Clone() as TMemberCreditHistory;
      tmemberCreditHistory.mch_ID = this.mch_ID;
      tmemberCreditHistory.mch_SiteID = this.mch_SiteID;
      tmemberCreditHistory.mch_MemberNo = this.mch_MemberNo;
      tmemberCreditHistory.mch_StoreCode = this.mch_StoreCode;
      tmemberCreditHistory.mch_StartDate = this.mch_StartDate;
      tmemberCreditHistory.mch_EndDate = this.mch_EndDate;
      tmemberCreditHistory.mch_PayMethod = this.mch_PayMethod;
      tmemberCreditHistory.mch_PayCondition = this.mch_PayCondition;
      tmemberCreditHistory.mch_InDate = this.mch_InDate;
      tmemberCreditHistory.mch_ModDate = this.mch_ModDate;
      tmemberCreditHistory.mch_InUser = this.mch_InUser;
      tmemberCreditHistory.mch_ModUser = this.mch_ModUser;
      return (object) tmemberCreditHistory;
    }

    public void PutData(TMemberCreditHistory pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.mch_ID = pSource.mch_ID;
      this.mch_SiteID = pSource.mch_SiteID;
      this.mch_MemberNo = pSource.mch_MemberNo;
      this.mch_StoreCode = pSource.mch_StoreCode;
      this.mch_StartDate = pSource.mch_StartDate;
      this.mch_EndDate = pSource.mch_EndDate;
      this.mch_PayMethod = pSource.mch_PayMethod;
      this.mch_PayCondition = pSource.mch_PayCondition;
      this.mch_InDate = pSource.mch_InDate;
      this.mch_ModDate = pSource.mch_ModDate;
      this.mch_InUser = pSource.mch_InUser;
      this.mch_ModUser = pSource.mch_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.mch_ID = p_rs.GetFieldInt("mch_ID");
        if (this.mch_ID == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.mch_SiteID = p_rs.GetFieldLong("mch_SiteID");
        this.mch_MemberNo = p_rs.GetFieldLong("mch_MemberNo");
        this.mch_StoreCode = p_rs.GetFieldInt("mch_StoreCode");
        this.mch_StartDate = p_rs.GetFieldDateTime("mch_StartDate");
        this.mch_EndDate = p_rs.GetFieldDateTime("mch_EndDate");
        this.mch_PayMethod = p_rs.GetFieldInt("mch_PayMethod");
        this.mch_PayCondition = p_rs.GetFieldInt("mch_PayCondition");
        this.mch_InDate = p_rs.GetFieldDateTime("mch_InDate");
        this.mch_InUser = p_rs.GetFieldInt("mch_InUser");
        this.mch_ModDate = p_rs.GetFieldDateTime("mch_ModDate");
        this.mch_ModUser = p_rs.GetFieldInt("mch_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode) + " mch_ID,mch_SiteID,mch_MemberNo,mch_StoreCode,mch_StartDate,mch_EndDate,mch_PayMethod,mch_PayCondition,mch_InDate,mch_InUser,mch_ModDate,mch_ModUser) VALUES ( " + string.Format(" {0}", (object) this.mch_ID) + string.Format(",{0}", (object) this.mch_SiteID) + string.Format(",{0},{1}", (object) this.mch_MemberNo, (object) this.mch_StoreCode) + "," + this.mch_StartDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + "," + this.mch_EndDate.GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'") + string.Format(",{0},{1}", (object) this.mch_PayMethod, (object) this.mch_PayCondition) + string.Format(",{0},{1}", (object) this.mch_InDate.GetDateToStrInNull(), (object) this.mch_InUser) + string.Format(",{0},{1}", (object) this.mch_ModDate.GetDateToStrInNull(), (object) this.mch_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.mch_ID, (object) this.mch_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TMemberCreditHistory tmemberCreditHistory = this;
      // ISSUE: reference to a compiler-generated method
      tmemberCreditHistory.\u003C\u003En__0();
      if (await tmemberCreditHistory.OleDB.ExecuteAsync(tmemberCreditHistory.InsertQuery()))
        return true;
      tmemberCreditHistory.message = " " + tmemberCreditHistory.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberCreditHistory.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberCreditHistory.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tmemberCreditHistory.mch_ID, (object) tmemberCreditHistory.mch_SiteID) + " 내용 : " + tmemberCreditHistory.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberCreditHistory.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode) + string.Format(" {0}={1}", (object) "mch_MemberNo", (object) this.mch_MemberNo) + string.Format(",{0}={1}", (object) "mch_StoreCode", (object) this.mch_StoreCode) + ",mch_StartDate=" + this.mch_StartDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + ",mch_EndDate=" + this.mch_EndDate.GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'") + string.Format(",{0}={1}", (object) "mch_PayMethod", (object) this.mch_PayMethod) + string.Format(",{0}={1}", (object) "mch_PayCondition", (object) this.mch_PayCondition) + string.Format(",{0}={1},{2}={3}", (object) "mch_ModDate", (object) this.mch_ModDate.GetDateToStrInNull(), (object) "mch_ModUser", (object) this.mch_ModUser) + string.Format(" WHERE {0}={1}", (object) "mch_ID", (object) this.mch_ID) + string.Format(" AND {0}={1}", (object) "mch_SiteID", (object) this.mch_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.mch_ID, (object) this.mch_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TMemberCreditHistory tmemberCreditHistory = this;
      // ISSUE: reference to a compiler-generated method
      tmemberCreditHistory.\u003C\u003En__1();
      if (await tmemberCreditHistory.OleDB.ExecuteAsync(tmemberCreditHistory.UpdateQuery()))
        return true;
      tmemberCreditHistory.message = " " + tmemberCreditHistory.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberCreditHistory.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberCreditHistory.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tmemberCreditHistory.mch_ID, (object) tmemberCreditHistory.mch_SiteID) + " 내용 : " + tmemberCreditHistory.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberCreditHistory.message);
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
      stringBuilder.Append(string.Format(" {0}={1}", (object) "mch_MemberNo", (object) this.mch_MemberNo) + string.Format(",{0}={1}", (object) "mch_StoreCode", (object) this.mch_StoreCode) + ",mch_StartDate=" + this.mch_StartDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + ",mch_EndDate=" + this.mch_EndDate.GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'") + string.Format(",{0}={1}", (object) "mch_PayMethod", (object) this.mch_PayMethod) + string.Format(",{0}={1}", (object) "mch_PayCondition", (object) this.mch_PayCondition) + string.Format(",{0}={1},{2}={3}", (object) "mch_ModDate", (object) this.mch_ModDate.GetDateToStrInNull(), (object) "mch_ModUser", (object) this.mch_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.mch_ID, (object) this.mch_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TMemberCreditHistory tmemberCreditHistory = this;
      // ISSUE: reference to a compiler-generated method
      tmemberCreditHistory.\u003C\u003En__1();
      if (await tmemberCreditHistory.OleDB.ExecuteAsync(tmemberCreditHistory.UpdateExInsertQuery()))
        return true;
      tmemberCreditHistory.message = " " + tmemberCreditHistory.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberCreditHistory.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberCreditHistory.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tmemberCreditHistory.mch_ID, (object) tmemberCreditHistory.mch_SiteID) + " 내용 : " + tmemberCreditHistory.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberCreditHistory.message);
      return false;
    }

    public override string DeleteQuery() => string.Format(" DELETE FROM {0}{1}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode) + string.Format(" WHERE {0}={1}", (object) "mch_ID", (object) this.mch_ID) + string.Format(" AND {0}={1}", (object) "mch_SiteID", (object) this.mch_SiteID);

    public override bool Delete()
    {
      this.InsertChecked();
      string pStrExec = this.DeleteQuery();
      if (this.OleDB.Execute(pStrExec))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 삭제 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 코드 : ({0},{1})\n", (object) this.mch_ID, (object) this.mch_SiteID) + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n 쿼리 : " + pStrExec + "\n--------------------------------------------------------------------------------------------------\n";
      return false;
    }

    public override async Task<bool> DeleteAsync()
    {
      TMemberCreditHistory tmemberCreditHistory = this;
      // ISSUE: reference to a compiler-generated method
      tmemberCreditHistory.\u003C\u003En__0();
      if (await tmemberCreditHistory.OleDB.ExecuteAsync(tmemberCreditHistory.DeleteQuery()))
        return true;
      tmemberCreditHistory.message = " " + tmemberCreditHistory.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberCreditHistory.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberCreditHistory.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tmemberCreditHistory.mch_ID, (object) tmemberCreditHistory.mch_SiteID) + " 내용 : " + tmemberCreditHistory.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberCreditHistory.message);
      return false;
    }

    public virtual string DeleteQuery(int p_mch_ID, long p_mch_SiteID = 0)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format(" DELETE FROM {0}{1} ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode));
      stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "mch_ID", (object) p_mch_ID));
      if (p_mch_SiteID > 0L)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mch_SiteID", (object) p_mch_SiteID));
      return stringBuilder.ToString();
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "mch_SiteID") && Convert.ToInt64(hashtable[(object) "mch_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "mch_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "mch_ID") && Convert.ToInt32(hashtable[(object) "mch_ID"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mch_ID", hashtable[(object) "mch_ID"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mch_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "mch_MemberNo") && Convert.ToInt64(hashtable[(object) "mch_MemberNo"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mch_MemberNo", hashtable[(object) "mch_MemberNo"]));
        if (hashtable.ContainsKey((object) "mch_StoreCode") && Convert.ToInt32(hashtable[(object) "mch_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mch_StoreCode", hashtable[(object) "mch_StoreCode"]));
        else if (hashtable.ContainsKey((object) "si_StoreCode") && Convert.ToInt32(hashtable[(object) "si_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mch_StoreCode", hashtable[(object) "si_StoreCode"]));
        else if (hashtable.ContainsKey((object) "si_StoreCode_IN_") && hashtable[(object) "si_StoreCode_IN_"].ToString().Length > 0)
        {
          if (hashtable[(object) "si_StoreCode_IN_"].ToString().Contains(","))
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "mch_StoreCode", hashtable[(object) "si_StoreCode_IN_"]));
          else
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mch_StoreCode", hashtable[(object) "si_StoreCode_IN_"]));
        }
        else if (hashtable.ContainsKey((object) "mch_StoreCode_IN_") && hashtable[(object) "mch_StoreCode_IN_"].ToString().Length > 0)
        {
          if (hashtable[(object) "mch_StoreCode_IN_"].ToString().Contains(","))
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "mch_StoreCode", hashtable[(object) "mch_StoreCode_IN_"]));
          else
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mch_StoreCode", hashtable[(object) "mch_StoreCode_IN_"]));
        }
        else if (hashtable.ContainsKey((object) "_STORE_AUTHS_") && !string.IsNullOrEmpty(hashtable[(object) "_STORE_AUTHS_"].ToString()))
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "mch_StoreCode", hashtable[(object) "_STORE_AUTHS_"]));
        if (hashtable.ContainsKey((object) "_DT_DATE_") && !string.IsNullOrEmpty(hashtable[(object) "_DT_DATE_"].ToString()))
        {
          stringBuilder.Append(" AND mch_StartDate <='" + new DateTime?((DateTime) hashtable[(object) "_DT_DATE_"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND mch_EndDate >='" + new DateTime?((DateTime) hashtable[(object) "_DT_DATE_"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
        }
        if (hashtable.ContainsKey((object) "_DT_START_DATE_") && !string.IsNullOrEmpty(hashtable[(object) "_DT_START_DATE_"].ToString()) && hashtable.ContainsKey((object) "_DT_END_DATE_") && !string.IsNullOrEmpty(hashtable[(object) "_DT_END_DATE_"].ToString()))
        {
          string dateToStr1 = new DateTime?((DateTime) hashtable[(object) "_DT_START_DATE_"]).GetDateToStr("yyyy-MM-dd 00:00:00");
          string dateToStr2 = new DateTime?((DateTime) hashtable[(object) "_DT_START_DATE_"]).GetDateToStr("yyyy-MM-dd 23:59:59");
          string dateToStr3 = new DateTime?((DateTime) hashtable[(object) "_DT_END_DATE_"]).GetDateToStr("yyyy-MM-dd 00:00:00");
          string dateToStr4 = new DateTime?((DateTime) hashtable[(object) "_DT_END_DATE_"]).GetDateToStr("yyyy-MM-dd 23:59:59");
          stringBuilder.Append(" AND (");
          stringBuilder.Append(" (mch_StartDate <= '" + dateToStr1 + "' AND mch_EndDate >= '" + dateToStr2 + "' )");
          stringBuilder.Append(" OR (mch_StartDate <= '" + dateToStr3 + "' AND mch_EndDate >= '" + dateToStr4 + "' )");
          stringBuilder.Append(" OR (mch_StartDate >= '" + dateToStr1 + "' AND mch_EndDate <= '" + dateToStr4 + "' )");
          stringBuilder.Append(") ");
        }
        if (hashtable.ContainsKey((object) "mch_PayMethod") && Convert.ToInt32(hashtable[(object) "mch_PayMethod"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mch_PayMethod", hashtable[(object) "mch_PayMethod"]));
        if (hashtable.ContainsKey((object) "mch_PayCondition") && Convert.ToInt32(hashtable[(object) "mch_PayCondition"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mch_PayCondition", hashtable[(object) "mch_PayCondition"]));
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
        stringBuilder.Append(" SELECT  mch_ID,mch_SiteID,mch_MemberNo,mch_StoreCode,mch_StartDate,mch_EndDate,mch_PayMethod,mch_PayCondition,mch_InDate,mch_InUser,mch_ModDate,mch_ModUser");
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
