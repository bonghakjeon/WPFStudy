// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Supplier.PayContion.TPayContion
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

namespace UniBiz.Bo.Models.UniBase.Supplier.PayContion
{
  public class TPayContion : UbModelBase<TPayContion>
  {
    private int _payc_ID;
    private int _payc_Turn;
    private long _payc_SiteID;
    private int _payc_Round;
    private int _payc_PaymentMonth;
    private int _payc_PaymentDay;
    private int _payc_CalcStartMonth;
    private int _payc_CalcStartDay;
    private int _payc_CalcEndMonth;
    private int _payc_CalcEndDay;
    private string _payc_Memo;
    private DateTime? _payc_InDate;
    private int _payc_InUser;
    private DateTime? _payc_ModDate;
    private int _payc_ModUser;

    public override object _Key => (object) new object[3]
    {
      (object) this.payc_ID,
      (object) this.payc_Turn,
      (object) this.payc_SiteID
    };

    public int payc_ID
    {
      get => this._payc_ID;
      set
      {
        this._payc_ID = value;
        this.Changed(nameof (payc_ID));
      }
    }

    public int payc_Turn
    {
      get => this._payc_Turn;
      set
      {
        this._payc_Turn = value;
        this.Changed(nameof (payc_Turn));
      }
    }

    public long payc_SiteID
    {
      get => this._payc_SiteID;
      set
      {
        this._payc_SiteID = value;
        this.Changed(nameof (payc_SiteID));
      }
    }

    public int payc_Round
    {
      get => this._payc_Round;
      set
      {
        this._payc_Round = value;
        this.Changed(nameof (payc_Round));
      }
    }

    public int payc_PaymentMonth
    {
      get => this._payc_PaymentMonth;
      set
      {
        this._payc_PaymentMonth = value;
        this.Changed(nameof (payc_PaymentMonth));
      }
    }

    public int payc_PaymentDay
    {
      get => this._payc_PaymentDay;
      set
      {
        this._payc_PaymentDay = value;
        this.Changed(nameof (payc_PaymentDay));
      }
    }

    public int payc_CalcStartMonth
    {
      get => this._payc_CalcStartMonth;
      set
      {
        this._payc_CalcStartMonth = value;
        this.Changed(nameof (payc_CalcStartMonth));
      }
    }

    public int payc_CalcStartDay
    {
      get => this._payc_CalcStartDay;
      set
      {
        this._payc_CalcStartDay = value;
        this.Changed(nameof (payc_CalcStartDay));
      }
    }

    public int payc_CalcEndMonth
    {
      get => this._payc_CalcEndMonth;
      set
      {
        this._payc_CalcEndMonth = value;
        this.Changed(nameof (payc_CalcEndMonth));
      }
    }

    public int payc_CalcEndDay
    {
      get => this._payc_CalcEndDay;
      set
      {
        this._payc_CalcEndDay = value;
        this.Changed(nameof (payc_CalcEndDay));
      }
    }

    public string payc_Memo
    {
      get => this._payc_Memo;
      set
      {
        this._payc_Memo = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (payc_Memo));
      }
    }

    public DateTime? payc_InDate
    {
      get => this._payc_InDate;
      set
      {
        this._payc_InDate = value;
        this.Changed(nameof (payc_InDate));
      }
    }

    public int payc_InUser
    {
      get => this._payc_InUser;
      set
      {
        this._payc_InUser = value;
        this.Changed(nameof (payc_InUser));
      }
    }

    public DateTime? payc_ModDate
    {
      get => this._payc_ModDate;
      set
      {
        this._payc_ModDate = value;
        this.Changed(nameof (payc_ModDate));
      }
    }

    public int payc_ModUser
    {
      get => this._payc_ModUser;
      set
      {
        this._payc_ModUser = value;
        this.Changed(nameof (payc_ModUser));
      }
    }

    public TPayContion() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("payc_ID", new TTableColumn()
      {
        tc_orgin_name = "payc_ID",
        tc_trans_name = "결제조건 ID"
      });
      columnInfo.Add("payc_Turn", new TTableColumn()
      {
        tc_orgin_name = "payc_Turn",
        tc_trans_name = "차",
        tc_comm_code = 74
      });
      columnInfo.Add("payc_SiteID", new TTableColumn()
      {
        tc_orgin_name = "payc_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("payc_Round", new TTableColumn()
      {
        tc_orgin_name = "payc_Round",
        tc_trans_name = "회",
        tc_comm_code = 73
      });
      columnInfo.Add("payc_PaymentMonth", new TTableColumn()
      {
        tc_orgin_name = "payc_PaymentMonth",
        tc_trans_name = "결제월"
      });
      columnInfo.Add("payc_PaymentDay", new TTableColumn()
      {
        tc_orgin_name = "payc_PaymentDay",
        tc_trans_name = "결제일",
        tc_comm_code = 75
      });
      columnInfo.Add("payc_CalcStartMonth", new TTableColumn()
      {
        tc_orgin_name = "payc_CalcStartMonth",
        tc_trans_name = "조회 시작월"
      });
      columnInfo.Add("payc_CalcStartDay", new TTableColumn()
      {
        tc_orgin_name = "payc_CalcStartDay",
        tc_trans_name = "조회 시작일"
      });
      columnInfo.Add("payc_CalcEndMonth", new TTableColumn()
      {
        tc_orgin_name = "payc_CalcEndMonth",
        tc_trans_name = "조회 종료월"
      });
      columnInfo.Add("payc_CalcEndDay", new TTableColumn()
      {
        tc_orgin_name = "payc_CalcEndDay",
        tc_trans_name = "조회 종료일"
      });
      columnInfo.Add("payc_Memo", new TTableColumn()
      {
        tc_orgin_name = "payc_Memo",
        tc_trans_name = "메모"
      });
      columnInfo.Add("payc_InDate", new TTableColumn()
      {
        tc_orgin_name = "payc_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("payc_InUser", new TTableColumn()
      {
        tc_orgin_name = "payc_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("payc_ModDate", new TTableColumn()
      {
        tc_orgin_name = "payc_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("payc_ModUser", new TTableColumn()
      {
        tc_orgin_name = "payc_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.PayContion;
      this.payc_ID = this.payc_Turn = 0;
      this.payc_SiteID = 0L;
      this.payc_Round = 0;
      this.payc_PaymentMonth = this.payc_PaymentDay = 0;
      this.payc_CalcStartMonth = this.payc_CalcStartDay = this.payc_CalcEndMonth = this.payc_CalcEndDay = 0;
      this.payc_Memo = string.Empty;
      this.payc_InDate = new DateTime?();
      this.payc_InUser = 0;
      this.payc_ModDate = new DateTime?();
      this.payc_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TPayContion();

    public override object Clone()
    {
      TPayContion tpayContion = base.Clone() as TPayContion;
      tpayContion.payc_ID = this.payc_ID;
      tpayContion.payc_Turn = this.payc_Turn;
      tpayContion.payc_SiteID = this.payc_SiteID;
      tpayContion.payc_Round = this.payc_Round;
      tpayContion.payc_PaymentMonth = this.payc_PaymentMonth;
      tpayContion.payc_PaymentDay = this.payc_PaymentDay;
      tpayContion.payc_CalcStartMonth = this.payc_CalcStartMonth;
      tpayContion.payc_CalcStartDay = this.payc_CalcStartDay;
      tpayContion.payc_CalcEndMonth = this.payc_CalcEndMonth;
      tpayContion.payc_CalcEndDay = this.payc_CalcEndDay;
      tpayContion.payc_Memo = this.payc_Memo;
      tpayContion.payc_InDate = this.payc_InDate;
      tpayContion.payc_ModDate = this.payc_ModDate;
      tpayContion.payc_InUser = this.payc_InUser;
      tpayContion.payc_ModUser = this.payc_ModUser;
      return (object) tpayContion;
    }

    public void PutData(TPayContion pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.payc_ID = pSource.payc_ID;
      this.payc_Turn = pSource.payc_Turn;
      this.payc_SiteID = pSource.payc_SiteID;
      this.payc_Round = pSource.payc_Round;
      this.payc_PaymentMonth = pSource.payc_PaymentMonth;
      this.payc_PaymentDay = pSource.payc_PaymentDay;
      this.payc_CalcStartMonth = pSource.payc_CalcStartMonth;
      this.payc_CalcStartDay = pSource.payc_CalcStartDay;
      this.payc_CalcEndMonth = pSource.payc_CalcEndMonth;
      this.payc_CalcEndDay = pSource.payc_CalcEndDay;
      this.payc_Memo = pSource.payc_Memo;
      this.payc_InDate = pSource.payc_InDate;
      this.payc_ModDate = pSource.payc_ModDate;
      this.payc_InUser = pSource.payc_InUser;
      this.payc_ModUser = pSource.payc_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.payc_ID = p_rs.GetFieldInt("payc_ID");
        if (this.payc_ID == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.payc_Turn = p_rs.GetFieldInt("payc_Turn");
        this.payc_SiteID = p_rs.GetFieldLong("payc_SiteID");
        this.payc_Round = p_rs.GetFieldInt("payc_Round");
        this.payc_PaymentMonth = p_rs.GetFieldInt("payc_PaymentMonth");
        this.payc_PaymentDay = p_rs.GetFieldInt("payc_PaymentDay");
        this.payc_CalcStartMonth = p_rs.GetFieldInt("payc_CalcStartMonth");
        this.payc_CalcStartDay = p_rs.GetFieldInt("payc_CalcStartDay");
        this.payc_CalcEndMonth = p_rs.GetFieldInt("payc_CalcEndMonth");
        this.payc_CalcEndDay = p_rs.GetFieldInt("payc_CalcEndDay");
        this.payc_Memo = p_rs.GetFieldString("payc_Memo");
        this.payc_InDate = p_rs.GetFieldDateTime("payc_InDate");
        this.payc_InUser = p_rs.GetFieldInt("payc_InUser");
        this.payc_ModDate = p_rs.GetFieldDateTime("payc_ModDate");
        this.payc_ModUser = p_rs.GetFieldInt("payc_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " payc_ID,payc_Turn,payc_SiteID,payc_Round,payc_PaymentMonth,payc_PaymentDay,payc_CalcStartMonth,payc_CalcStartDay,payc_CalcEndMonth,payc_CalcEndDay,payc_Memo,payc_InDate,payc_InUser,payc_ModDate,payc_ModUser) VALUES ( " + string.Format(" {0},{1},{2}", (object) this.payc_ID, (object) this.payc_Turn, (object) this.payc_SiteID) + string.Format(",{0}", (object) this.payc_Round) + string.Format(",{0},{1}", (object) this.payc_PaymentMonth, (object) this.payc_PaymentDay) + string.Format(",{0},{1},{2},{3}", (object) this.payc_CalcStartMonth, (object) this.payc_CalcStartDay, (object) this.payc_CalcEndMonth, (object) this.payc_CalcEndDay) + ",'" + this.payc_Memo + "'" + string.Format(",{0},{1}", (object) this.payc_InDate.GetDateToStrInNull(), (object) this.payc_InUser) + string.Format(",{0},{1}", (object) this.payc_ModDate.GetDateToStrInNull(), (object) this.payc_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.payc_ID, (object) this.payc_Turn, (object) this.payc_SiteID, (object) this.payc_Round) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TPayContion tpayContion = this;
      // ISSUE: reference to a compiler-generated method
      tpayContion.\u003C\u003En__0();
      if (await tpayContion.OleDB.ExecuteAsync(tpayContion.InsertQuery()))
        return true;
      tpayContion.message = " " + tpayContion.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tpayContion.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tpayContion.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tpayContion.payc_ID, (object) tpayContion.payc_Turn, (object) tpayContion.payc_SiteID, (object) tpayContion.payc_Round) + " 내용 : " + tpayContion.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tpayContion.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + string.Format(" {0}={1},{2}={3}", (object) "payc_PaymentMonth", (object) this.payc_PaymentMonth, (object) "payc_PaymentDay", (object) this.payc_PaymentDay) + string.Format(",{0}={1},{2}={3}", (object) "payc_CalcStartMonth", (object) this.payc_CalcStartMonth, (object) "payc_CalcStartDay", (object) this.payc_CalcStartDay) + string.Format(",{0}={1},{2}={3}", (object) "payc_CalcEndMonth", (object) this.payc_CalcEndMonth, (object) "payc_CalcEndDay", (object) this.payc_CalcEndDay) + ",payc_Memo='" + this.payc_Memo + "'" + string.Format(",{0}={1},{2}={3}", (object) "payc_ModDate", (object) this.payc_ModDate.GetDateToStrInNull(), (object) "payc_ModUser", (object) this.payc_ModUser) + string.Format(" WHERE {0}={1}", (object) "payc_ID", (object) this.payc_ID) + string.Format(" AND {0}={1}", (object) "payc_Turn", (object) this.payc_Turn) + string.Format(" AND {0}={1}", (object) "payc_SiteID", (object) this.payc_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.payc_ID, (object) this.payc_Turn, (object) this.payc_SiteID, (object) this.payc_Round) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TPayContion tpayContion = this;
      // ISSUE: reference to a compiler-generated method
      tpayContion.\u003C\u003En__1();
      if (await tpayContion.OleDB.ExecuteAsync(tpayContion.UpdateQuery()))
        return true;
      tpayContion.message = " " + tpayContion.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tpayContion.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tpayContion.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tpayContion.payc_ID, (object) tpayContion.payc_Turn, (object) tpayContion.payc_SiteID, (object) tpayContion.payc_Round) + " 내용 : " + tpayContion.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tpayContion.message);
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
      stringBuilder.Append(string.Format(" {0}={1},{2}={3}", (object) "payc_PaymentMonth", (object) this.payc_PaymentMonth, (object) "payc_PaymentDay", (object) this.payc_PaymentDay) + string.Format(",{0}={1},{2}={3}", (object) "payc_CalcStartMonth", (object) this.payc_CalcStartMonth, (object) "payc_CalcStartDay", (object) this.payc_CalcStartDay) + string.Format(",{0}={1},{2}={3}", (object) "payc_CalcEndMonth", (object) this.payc_CalcEndMonth, (object) "payc_CalcEndDay", (object) this.payc_CalcEndDay) + ",payc_Memo='" + this.payc_Memo + "'" + string.Format(",{0}={1},{2}={3}", (object) "payc_ModDate", (object) this.payc_ModDate.GetDateToStrInNull(), (object) "payc_ModUser", (object) this.payc_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.payc_ID, (object) this.payc_Turn, (object) this.payc_SiteID, (object) this.payc_Round) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TPayContion tpayContion = this;
      // ISSUE: reference to a compiler-generated method
      tpayContion.\u003C\u003En__1();
      if (await tpayContion.OleDB.ExecuteAsync(tpayContion.UpdateExInsertQuery()))
        return true;
      tpayContion.message = " " + tpayContion.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tpayContion.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tpayContion.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tpayContion.payc_ID, (object) tpayContion.payc_Turn, (object) tpayContion.payc_SiteID, (object) tpayContion.payc_Round) + " 내용 : " + tpayContion.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tpayContion.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "payc_SiteID") && Convert.ToInt64(hashtable[(object) "payc_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "payc_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "payc_ID") && Convert.ToInt32(hashtable[(object) "payc_ID"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "payc_ID", hashtable[(object) "payc_ID"]));
        else
          stringBuilder.Append(" AND payc_ID>0");
        if (hashtable.ContainsKey((object) "payc_Turn") && Convert.ToInt32(hashtable[(object) "payc_Turn"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "payc_Turn", hashtable[(object) "payc_Turn"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "payc_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "payc_Round") && Convert.ToInt32(hashtable[(object) "payc_Round"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "payc_Round", hashtable[(object) "payc_Round"]));
        if (hashtable.ContainsKey((object) "payc_PaymentMonth") && Convert.ToInt32(hashtable[(object) "payc_PaymentMonth"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "payc_PaymentMonth", hashtable[(object) "payc_PaymentMonth"]));
        if (hashtable.ContainsKey((object) "payc_PaymentMonth_BIT_AND_") && Convert.ToInt32(hashtable[(object) "payc_PaymentMonth_BIT_AND_"].ToString()) >= 0)
          stringBuilder.Append(string.Format(" AND ({0}&{1})={2}", (object) "payc_PaymentMonth", hashtable[(object) "payc_PaymentMonth_BIT_AND_"], hashtable[(object) "payc_PaymentMonth_BIT_AND_"]));
        if (hashtable.ContainsKey((object) "payc_PaymentDay") && Convert.ToInt32(hashtable[(object) "payc_PaymentDay"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "payc_PaymentDay", hashtable[(object) "payc_PaymentDay"]));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_"))
        {
          int length = hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length;
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
        stringBuilder.Append(" SELECT  payc_ID,payc_Turn,payc_SiteID,payc_Round,payc_PaymentMonth,payc_PaymentDay,payc_CalcStartMonth,payc_CalcStartDay,payc_CalcEndMonth,payc_CalcEndDay,payc_Memo,payc_InDate,payc_InUser,payc_ModDate,payc_ModUser");
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
