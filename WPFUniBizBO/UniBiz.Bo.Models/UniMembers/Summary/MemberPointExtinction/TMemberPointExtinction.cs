// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.Summary.MemberPointExtinction.TMemberPointExtinction
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

namespace UniBiz.Bo.Models.UniMembers.Summary.MemberPointExtinction
{
  public class TMemberPointExtinction : UbModelBase<TMemberPointExtinction>
  {
    private DateTime? _mpe_Date;
    private long _mpe_MemberNo;
    private long _mpe_SiteID;
    private int _mpe_AddPoint;
    private int _mpe_UsePoint;
    private int _mpe_ExtinctionPoint;
    private int _mpe_RemainingPoint;
    private int _mpe_BeforeUsablePoint;
    private int _mpe_AfterUsablePoint;
    private DateTime? _mpe_InDate;
    private int _mpe_InUser;
    private DateTime? _mpe_ModDate;
    private int _mpe_ModUser;

    public override object _Key => (object) new object[2]
    {
      (object) this.mpe_Date,
      (object) this.mpe_MemberNo
    };

    public DateTime? mpe_Date
    {
      get => this._mpe_Date;
      set
      {
        this._mpe_Date = value;
        this.Changed(nameof (mpe_Date));
      }
    }

    public long mpe_MemberNo
    {
      get => this._mpe_MemberNo;
      set
      {
        this._mpe_MemberNo = value;
        this.Changed(nameof (mpe_MemberNo));
      }
    }

    public long mpe_SiteID
    {
      get => this._mpe_SiteID;
      set
      {
        this._mpe_SiteID = value;
        this.Changed(nameof (mpe_SiteID));
      }
    }

    public int mpe_AddPoint
    {
      get => this._mpe_AddPoint;
      set
      {
        this._mpe_AddPoint = value;
        this.Changed(nameof (mpe_AddPoint));
      }
    }

    public int mpe_UsePoint
    {
      get => this._mpe_UsePoint;
      set
      {
        this._mpe_UsePoint = value;
        this.Changed(nameof (mpe_UsePoint));
      }
    }

    public int mpe_ExtinctionPoint
    {
      get => this._mpe_ExtinctionPoint;
      set
      {
        this._mpe_ExtinctionPoint = value;
        this.Changed(nameof (mpe_ExtinctionPoint));
      }
    }

    public int mpe_RemainingPoint
    {
      get => this._mpe_RemainingPoint;
      set
      {
        this._mpe_RemainingPoint = value;
        this.Changed(nameof (mpe_RemainingPoint));
      }
    }

    public int mpe_BeforeUsablePoint
    {
      get => this._mpe_BeforeUsablePoint;
      set
      {
        this._mpe_BeforeUsablePoint = value;
        this.Changed(nameof (mpe_BeforeUsablePoint));
      }
    }

    public int mpe_AfterUsablePoint
    {
      get => this._mpe_AfterUsablePoint;
      set
      {
        this._mpe_AfterUsablePoint = value;
        this.Changed(nameof (mpe_AfterUsablePoint));
      }
    }

    public DateTime? mpe_InDate
    {
      get => this._mpe_InDate;
      set
      {
        this._mpe_InDate = value;
        this.Changed(nameof (mpe_InDate));
      }
    }

    public int mpe_InUser
    {
      get => this._mpe_InUser;
      set
      {
        this._mpe_InUser = value;
        this.Changed(nameof (mpe_InUser));
      }
    }

    public DateTime? mpe_ModDate
    {
      get => this._mpe_ModDate;
      set
      {
        this._mpe_ModDate = value;
        this.Changed(nameof (mpe_ModDate));
      }
    }

    public int mpe_ModUser
    {
      get => this._mpe_ModUser;
      set
      {
        this._mpe_ModUser = value;
        this.Changed(nameof (mpe_ModUser));
      }
    }

    public TMemberPointExtinction() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("mpe_Date", new TTableColumn()
      {
        tc_orgin_name = "mpe_Date",
        tc_trans_name = "소멸예정일"
      });
      columnInfo.Add("mpe_MemberNo", new TTableColumn()
      {
        tc_orgin_name = "mpe_MemberNo",
        tc_trans_name = "회원코드"
      });
      columnInfo.Add("mpe_SiteID", new TTableColumn()
      {
        tc_orgin_name = "mpe_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("mpe_AddPoint", new TTableColumn()
      {
        tc_orgin_name = "mpe_AddPoint",
        tc_trans_name = "적립포인트"
      });
      columnInfo.Add("mpe_UsePoint", new TTableColumn()
      {
        tc_orgin_name = "mpe_UsePoint",
        tc_trans_name = "사용포인트"
      });
      columnInfo.Add("mpe_ExtinctionPoint", new TTableColumn()
      {
        tc_orgin_name = "mpe_ExtinctionPoint",
        tc_trans_name = "소멸포인트"
      });
      columnInfo.Add("mpe_RemainingPoint", new TTableColumn()
      {
        tc_orgin_name = "mpe_RemainingPoint",
        tc_trans_name = "잔여포인트"
      });
      columnInfo.Add("mpe_BeforeUsablePoint", new TTableColumn()
      {
        tc_orgin_name = "mpe_BeforeUsablePoint",
        tc_trans_name = "소멸전가용포인트"
      });
      columnInfo.Add("mpe_AfterUsablePoint", new TTableColumn()
      {
        tc_orgin_name = "mpe_AfterUsablePoint",
        tc_trans_name = "소멸후가용포인트"
      });
      columnInfo.Add("mpe_InDate", new TTableColumn()
      {
        tc_orgin_name = "mpe_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("mpe_InUser", new TTableColumn()
      {
        tc_orgin_name = "mpe_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("mpe_ModDate", new TTableColumn()
      {
        tc_orgin_name = "mpe_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("mpe_ModUser", new TTableColumn()
      {
        tc_orgin_name = "mpe_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.MemberPointExtinction;
      this.mpe_Date = new DateTime?();
      this.mpe_MemberNo = 0L;
      this.mpe_SiteID = 0L;
      this.mpe_AddPoint = this.mpe_UsePoint = this.mpe_ExtinctionPoint = this.mpe_RemainingPoint = this.mpe_BeforeUsablePoint = this.mpe_AfterUsablePoint = 0;
      this.mpe_InDate = new DateTime?();
      this.mpe_InUser = 0;
      this.mpe_ModDate = new DateTime?();
      this.mpe_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TMemberPointExtinction();

    public override object Clone()
    {
      TMemberPointExtinction tmemberPointExtinction = base.Clone() as TMemberPointExtinction;
      tmemberPointExtinction.mpe_Date = this.mpe_Date;
      tmemberPointExtinction.mpe_MemberNo = this.mpe_MemberNo;
      tmemberPointExtinction.mpe_SiteID = this.mpe_SiteID;
      tmemberPointExtinction.mpe_AddPoint = this.mpe_AddPoint;
      tmemberPointExtinction.mpe_UsePoint = this.mpe_UsePoint;
      tmemberPointExtinction.mpe_ExtinctionPoint = this.mpe_ExtinctionPoint;
      tmemberPointExtinction.mpe_RemainingPoint = this.mpe_RemainingPoint;
      tmemberPointExtinction.mpe_BeforeUsablePoint = this.mpe_BeforeUsablePoint;
      tmemberPointExtinction.mpe_AfterUsablePoint = this.mpe_AfterUsablePoint;
      tmemberPointExtinction.mpe_InDate = this.mpe_InDate;
      tmemberPointExtinction.mpe_InUser = this.mpe_InUser;
      tmemberPointExtinction.mpe_ModDate = this.mpe_ModDate;
      tmemberPointExtinction.mpe_ModUser = this.mpe_ModUser;
      return (object) tmemberPointExtinction;
    }

    public void PutData(TMemberPointExtinction pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.mpe_Date = pSource.mpe_Date;
      this.mpe_MemberNo = pSource.mpe_MemberNo;
      this.mpe_SiteID = pSource.mpe_SiteID;
      this.mpe_AddPoint = pSource.mpe_AddPoint;
      this.mpe_UsePoint = pSource.mpe_UsePoint;
      this.mpe_ExtinctionPoint = pSource.mpe_ExtinctionPoint;
      this.mpe_RemainingPoint = pSource.mpe_RemainingPoint;
      this.mpe_BeforeUsablePoint = pSource.mpe_BeforeUsablePoint;
      this.mpe_AfterUsablePoint = pSource.mpe_AfterUsablePoint;
      this.mpe_InDate = pSource.mpe_InDate;
      this.mpe_InUser = pSource.mpe_InUser;
      this.mpe_ModDate = pSource.mpe_ModDate;
      this.mpe_ModUser = pSource.mpe_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.mpe_Date = p_rs.GetFieldDateTime("mpe_Date");
        this.mpe_MemberNo = p_rs.GetFieldLong("mpe_MemberNo");
        if (this.mpe_MemberNo == 0L)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.mpe_SiteID = p_rs.GetFieldLong("mpe_SiteID");
        this.mpe_AddPoint = p_rs.GetFieldInt("mpe_AddPoint");
        this.mpe_UsePoint = p_rs.GetFieldInt("mpe_UsePoint");
        this.mpe_ExtinctionPoint = p_rs.GetFieldInt("mpe_ExtinctionPoint");
        this.mpe_RemainingPoint = p_rs.GetFieldInt("mpe_RemainingPoint");
        this.mpe_BeforeUsablePoint = p_rs.GetFieldInt("mpe_BeforeUsablePoint");
        this.mpe_AfterUsablePoint = p_rs.GetFieldInt("mpe_AfterUsablePoint");
        this.mpe_InDate = p_rs.GetFieldDateTime("mpe_InDate");
        this.mpe_InUser = p_rs.GetFieldInt("mpe_InUser");
        this.mpe_ModDate = p_rs.GetFieldDateTime("mpe_ModDate");
        this.mpe_ModUser = p_rs.GetFieldInt("mpe_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode) + " mpe_Date,mpe_MemberNo,mpe_SiteID,mpe_AddPoint,mpe_UsePoint,mpe_ExtinctionPoint,mpe_RemainingPoint,mpe_BeforeUsablePoint,mpe_AfterUsablePoint,mpe_InDate,mpe_InUser,mpe_ModDate,mpe_ModUser) VALUES (  " + this.mpe_Date.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + string.Format(",{0}", (object) this.mpe_MemberNo) + string.Format(",{0}", (object) this.mpe_SiteID) + string.Format(",{0},{1},{2}", (object) this.mpe_AddPoint, (object) this.mpe_UsePoint, (object) this.mpe_ExtinctionPoint) + string.Format(",{0},{1},{2}", (object) this.mpe_RemainingPoint, (object) this.mpe_BeforeUsablePoint, (object) this.mpe_AfterUsablePoint) + string.Format(",{0},{1}", (object) this.mpe_InDate.GetDateToStrInNull(), (object) this.mpe_InUser) + string.Format(",{0},{1}", (object) this.mpe_ModDate.GetDateToStrInNull(), (object) this.mpe_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.mpe_Date, (object) this.mpe_MemberNo, (object) this.mpe_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TMemberPointExtinction tmemberPointExtinction = this;
      // ISSUE: reference to a compiler-generated method
      tmemberPointExtinction.\u003C\u003En__0();
      if (await tmemberPointExtinction.OleDB.ExecuteAsync(tmemberPointExtinction.InsertQuery()))
        return true;
      tmemberPointExtinction.message = " " + tmemberPointExtinction.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberPointExtinction.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberPointExtinction.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tmemberPointExtinction.mpe_Date, (object) tmemberPointExtinction.mpe_MemberNo, (object) tmemberPointExtinction.mpe_SiteID) + " 내용 : " + tmemberPointExtinction.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberPointExtinction.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode) + string.Format(" {0}={1},{2}={3}", (object) "mpe_AddPoint", (object) this.mpe_AddPoint, (object) "mpe_UsePoint", (object) this.mpe_UsePoint) + string.Format(",{0}={1},{2}={3}", (object) "mpe_ExtinctionPoint", (object) this.mpe_ExtinctionPoint, (object) "mpe_RemainingPoint", (object) this.mpe_RemainingPoint) + string.Format(",{0}={1},{2}={3}", (object) "mpe_BeforeUsablePoint", (object) this.mpe_BeforeUsablePoint, (object) "mpe_AfterUsablePoint", (object) this.mpe_AfterUsablePoint) + string.Format(",{0}={1},{2}={3}", (object) "mpe_ModDate", (object) this.mpe_ModDate.GetDateToStrInNull(), (object) "mpe_ModUser", (object) this.mpe_ModUser) + " WHERE mpe_Date=" + this.mpe_Date.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + string.Format(" AND {0}={1}", (object) "mpe_MemberNo", (object) this.mpe_MemberNo) + string.Format(" AND {0}={1}", (object) "mpe_SiteID", (object) this.mpe_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.mpe_Date, (object) this.mpe_MemberNo, (object) this.mpe_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TMemberPointExtinction tmemberPointExtinction = this;
      // ISSUE: reference to a compiler-generated method
      tmemberPointExtinction.\u003C\u003En__1();
      if (await tmemberPointExtinction.OleDB.ExecuteAsync(tmemberPointExtinction.UpdateQuery()))
        return true;
      tmemberPointExtinction.message = " " + tmemberPointExtinction.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberPointExtinction.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberPointExtinction.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tmemberPointExtinction.mpe_Date, (object) tmemberPointExtinction.mpe_MemberNo, (object) tmemberPointExtinction.mpe_SiteID) + " 내용 : " + tmemberPointExtinction.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberPointExtinction.message);
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
      stringBuilder.Append(string.Format(" {0}={1},{2}={3}", (object) "mpe_AddPoint", (object) this.mpe_AddPoint, (object) "mpe_UsePoint", (object) this.mpe_UsePoint) + string.Format(",{0}={1},{2}={3}", (object) "mpe_ExtinctionPoint", (object) this.mpe_ExtinctionPoint, (object) "mpe_RemainingPoint", (object) this.mpe_RemainingPoint) + string.Format(",{0}={1},{2}={3}", (object) "mpe_BeforeUsablePoint", (object) this.mpe_BeforeUsablePoint, (object) "mpe_AfterUsablePoint", (object) this.mpe_AfterUsablePoint) + string.Format(",{0}={1},{2}={3}", (object) "mpe_ModDate", (object) this.mpe_ModDate.GetDateToStrInNull(), (object) "mpe_ModUser", (object) this.mpe_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.mpe_Date, (object) this.mpe_MemberNo, (object) this.mpe_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TMemberPointExtinction tmemberPointExtinction = this;
      // ISSUE: reference to a compiler-generated method
      tmemberPointExtinction.\u003C\u003En__1();
      if (await tmemberPointExtinction.OleDB.ExecuteAsync(tmemberPointExtinction.UpdateExInsertQuery()))
        return true;
      tmemberPointExtinction.message = " " + tmemberPointExtinction.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberPointExtinction.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberPointExtinction.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tmemberPointExtinction.mpe_Date, (object) tmemberPointExtinction.mpe_MemberNo, (object) tmemberPointExtinction.mpe_SiteID) + " 내용 : " + tmemberPointExtinction.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberPointExtinction.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "mpe_SiteID") && Convert.ToInt64(hashtable[(object) "mpe_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "mpe_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "mpe_Date") && !string.IsNullOrEmpty(hashtable[(object) "mpe_Date"].ToString()))
          stringBuilder.Append(" AND mpe_Date=" + new DateTime?((DateTime) hashtable[(object) "mpe_Date"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'"));
        if (hashtable.ContainsKey((object) "mpe_Date_BEGIN_") && !string.IsNullOrEmpty(hashtable[(object) "mpe_Date_BEGIN_"].ToString()) && hashtable.ContainsKey((object) "mpe_Date_END_") && !string.IsNullOrEmpty(hashtable[(object) "mpe_Date_END_"].ToString()))
          stringBuilder.Append(" AND mpe_Date<=" + new DateTime?((DateTime) hashtable[(object) "mpe_Date_BEGIN_"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + " AND mpe_Date>=" + new DateTime?((DateTime) hashtable[(object) "mpe_Date_END_"]).GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'"));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mpe_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "mpe_ExtinctionPoint_IS_NOT_DATA_VALUE_ZERO_") && !string.IsNullOrEmpty(hashtable[(object) "mpe_ExtinctionPoint_IS_NOT_DATA_VALUE_ZERO_"].ToString()) && Convert.ToBoolean(hashtable[(object) "mpe_ExtinctionPoint_IS_NOT_DATA_VALUE_ZERO_"].ToString()))
          stringBuilder.Append(" AND mpe_ExtinctionPoint!=0");
        else if (hashtable.ContainsKey((object) "mpe_ExtinctionPointIDS_ZERO") && !string.IsNullOrEmpty(hashtable[(object) "mpe_ExtinctionPointIDS_ZERO"].ToString()) && Convert.ToBoolean(hashtable[(object) "mpe_ExtinctionPointIDS_ZERO"].ToString()))
          stringBuilder.Append(" AND mpe_ExtinctionPoint=0");
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_"))
          string.IsNullOrEmpty(hashtable[(object) "_KEY_WORD_"].ToString());
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
        stringBuilder.Append(" SELECT  mpe_Date,mpe_MemberNo,mpe_SiteID,mpe_AddPoint,mpe_UsePoint,mpe_ExtinctionPoint,mpe_RemainingPoint,mpe_BeforeUsablePoint,mpe_AfterUsablePoint,mpe_InDate,mpe_InUser,mpe_ModDate,mpe_ModUser");
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
