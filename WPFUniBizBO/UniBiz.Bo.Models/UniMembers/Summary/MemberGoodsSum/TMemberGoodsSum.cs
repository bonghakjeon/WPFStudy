// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.Summary.MemberGoodsSum.TMemberGoodsSum
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

namespace UniBiz.Bo.Models.UniMembers.Summary.MemberGoodsSum
{
  public class TMemberGoodsSum : UbModelBase<TMemberGoodsSum>
  {
    private DateTime? _mgs_SysDate;
    private long _mgs_MemberNo;
    private int _mgs_StoreCode;
    private long _mgs_GoodsCode;
    private long _mgs_SiteID;
    private int _mgs_GoodsCategory;
    private double _mgs_SaleQty;
    private double _mgs_TotalSaleAmt;
    private DateTime? _mgs_InDate;
    private int _mgs_InUser;
    private DateTime? _mgs_ModDate;
    private int _mgs_ModUser;

    public override object _Key => (object) new object[4]
    {
      (object) this.mgs_SysDate,
      (object) this.mgs_MemberNo,
      (object) this.mgs_StoreCode,
      (object) this.mgs_GoodsCode
    };

    public DateTime? mgs_SysDate
    {
      get => this._mgs_SysDate;
      set
      {
        this._mgs_SysDate = value;
        this.Changed(nameof (mgs_SysDate));
      }
    }

    public long mgs_MemberNo
    {
      get => this._mgs_MemberNo;
      set
      {
        this._mgs_MemberNo = value;
        this.Changed(nameof (mgs_MemberNo));
      }
    }

    public int mgs_StoreCode
    {
      get => this._mgs_StoreCode;
      set
      {
        this._mgs_StoreCode = value;
        this.Changed(nameof (mgs_StoreCode));
      }
    }

    public long mgs_GoodsCode
    {
      get => this._mgs_GoodsCode;
      set
      {
        this._mgs_GoodsCode = value;
        this.Changed(nameof (mgs_GoodsCode));
      }
    }

    public long mgs_SiteID
    {
      get => this._mgs_SiteID;
      set
      {
        this._mgs_SiteID = value;
        this.Changed(nameof (mgs_SiteID));
      }
    }

    public int mgs_GoodsCategory
    {
      get => this._mgs_GoodsCategory;
      set
      {
        this._mgs_GoodsCategory = value;
        this.Changed(nameof (mgs_GoodsCategory));
      }
    }

    public double mgs_SaleQty
    {
      get => this._mgs_SaleQty;
      set
      {
        this._mgs_SaleQty = value;
        this.Changed(nameof (mgs_SaleQty));
      }
    }

    public double mgs_TotalSaleAmt
    {
      get => this._mgs_TotalSaleAmt;
      set
      {
        this._mgs_TotalSaleAmt = value;
        this.Changed(nameof (mgs_TotalSaleAmt));
      }
    }

    public DateTime? mgs_InDate
    {
      get => this._mgs_InDate;
      set
      {
        this._mgs_InDate = value;
        this.Changed(nameof (mgs_InDate));
      }
    }

    public int mgs_InUser
    {
      get => this._mgs_InUser;
      set
      {
        this._mgs_InUser = value;
        this.Changed(nameof (mgs_InUser));
      }
    }

    public DateTime? mgs_ModDate
    {
      get => this._mgs_ModDate;
      set
      {
        this._mgs_ModDate = value;
        this.Changed(nameof (mgs_ModDate));
      }
    }

    public int mgs_ModUser
    {
      get => this._mgs_ModUser;
      set
      {
        this._mgs_ModUser = value;
        this.Changed(nameof (mgs_ModUser));
      }
    }

    public TMemberGoodsSum() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("mgs_SysDate", new TTableColumn()
      {
        tc_orgin_name = "mgs_SysDate",
        tc_trans_name = "발생일시"
      });
      columnInfo.Add("mgs_MemberNo", new TTableColumn()
      {
        tc_orgin_name = "mgs_MemberNo",
        tc_trans_name = "회원코드"
      });
      columnInfo.Add("mgs_StoreCode", new TTableColumn()
      {
        tc_orgin_name = "mgs_StoreCode",
        tc_trans_name = "지점코드"
      });
      columnInfo.Add("mgs_GoodsCode", new TTableColumn()
      {
        tc_orgin_name = "mgs_GoodsCode",
        tc_trans_name = "상품코드"
      });
      columnInfo.Add("mgs_SiteID", new TTableColumn()
      {
        tc_orgin_name = "mgs_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("mgs_GoodsCategory", new TTableColumn()
      {
        tc_orgin_name = "mgs_GoodsCategory",
        tc_trans_name = "소분류"
      });
      columnInfo.Add("mgs_SaleQty", new TTableColumn()
      {
        tc_orgin_name = "mgs_SaleQty",
        tc_trans_name = "매출수량"
      });
      columnInfo.Add("mgs_TotalSaleAmt", new TTableColumn()
      {
        tc_orgin_name = "mgs_TotalSaleAmt",
        tc_trans_name = "총매출금액"
      });
      columnInfo.Add("mgs_InDate", new TTableColumn()
      {
        tc_orgin_name = "mgs_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("mgs_InUser", new TTableColumn()
      {
        tc_orgin_name = "mgs_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("mgs_ModDate", new TTableColumn()
      {
        tc_orgin_name = "mgs_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("mgs_ModUser", new TTableColumn()
      {
        tc_orgin_name = "mgs_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.MemberGoodsSum;
      this.mgs_SysDate = new DateTime?();
      this.mgs_MemberNo = 0L;
      this.mgs_StoreCode = 0;
      this.mgs_GoodsCode = 0L;
      this.mgs_SiteID = 0L;
      this.mgs_GoodsCategory = 0;
      this.mgs_SaleQty = this.mgs_TotalSaleAmt = 0.0;
      this.mgs_InDate = new DateTime?();
      this.mgs_InUser = 0;
      this.mgs_ModDate = new DateTime?();
      this.mgs_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TMemberGoodsSum();

    public override object Clone()
    {
      TMemberGoodsSum tmemberGoodsSum = base.Clone() as TMemberGoodsSum;
      tmemberGoodsSum.mgs_SysDate = this.mgs_SysDate;
      tmemberGoodsSum.mgs_MemberNo = this.mgs_MemberNo;
      tmemberGoodsSum.mgs_StoreCode = this.mgs_StoreCode;
      tmemberGoodsSum.mgs_GoodsCode = this.mgs_GoodsCode;
      tmemberGoodsSum.mgs_SiteID = this.mgs_SiteID;
      tmemberGoodsSum.mgs_GoodsCategory = this.mgs_GoodsCategory;
      tmemberGoodsSum.mgs_SaleQty = this.mgs_SaleQty;
      tmemberGoodsSum.mgs_TotalSaleAmt = this.mgs_TotalSaleAmt;
      tmemberGoodsSum.mgs_InDate = this.mgs_InDate;
      tmemberGoodsSum.mgs_InUser = this.mgs_InUser;
      tmemberGoodsSum.mgs_ModDate = this.mgs_ModDate;
      tmemberGoodsSum.mgs_ModUser = this.mgs_ModUser;
      return (object) tmemberGoodsSum;
    }

    public void PutData(TMemberGoodsSum pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.mgs_SysDate = pSource.mgs_SysDate;
      this.mgs_MemberNo = pSource.mgs_MemberNo;
      this.mgs_StoreCode = pSource.mgs_StoreCode;
      this.mgs_GoodsCode = pSource.mgs_GoodsCode;
      this.mgs_SiteID = pSource.mgs_SiteID;
      this.mgs_GoodsCategory = pSource.mgs_GoodsCategory;
      this.mgs_SaleQty = pSource.mgs_SaleQty;
      this.mgs_TotalSaleAmt = pSource.mgs_TotalSaleAmt;
      this.mgs_InDate = pSource.mgs_InDate;
      this.mgs_InUser = pSource.mgs_InUser;
      this.mgs_ModDate = pSource.mgs_ModDate;
      this.mgs_ModUser = pSource.mgs_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.mgs_SysDate = p_rs.GetFieldDateTime("mgs_SysDate");
        this.mgs_MemberNo = p_rs.GetFieldLong("mgs_MemberNo");
        if (this.mgs_MemberNo == 0L)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.mgs_StoreCode = p_rs.GetFieldInt("mgs_StoreCode");
        this.mgs_GoodsCode = p_rs.GetFieldLong("mgs_GoodsCode");
        this.mgs_SiteID = p_rs.GetFieldLong("mgs_SiteID");
        this.mgs_GoodsCategory = p_rs.GetFieldInt("mgs_GoodsCategory");
        this.mgs_SaleQty = p_rs.GetFieldDouble("mgs_SaleQty");
        this.mgs_TotalSaleAmt = p_rs.GetFieldDouble("mgs_TotalSaleAmt");
        this.mgs_InDate = p_rs.GetFieldDateTime("mgs_InDate");
        this.mgs_InUser = p_rs.GetFieldInt("mgs_InUser");
        this.mgs_ModDate = p_rs.GetFieldDateTime("mgs_ModDate");
        this.mgs_ModUser = p_rs.GetFieldInt("mgs_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode) + " mgs_SysDate,mgs_MemberNo,mgs_StoreCode,mgs_GoodsCode,mgs_SiteID,mgs_GoodsCategory,mgs_SaleQty,mgs_TotalSaleAmt,mgs_InDate,mgs_InUser,mgs_ModDate,mgs_ModUser) VALUES (  " + this.mgs_SysDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + string.Format(",{0},{1},{2}", (object) this.mgs_MemberNo, (object) this.mgs_StoreCode, (object) this.mgs_GoodsCode) + string.Format(",{0}", (object) this.mgs_SiteID) + string.Format(",{0}", (object) this.mgs_GoodsCategory) + "," + this.mgs_SaleQty.FormatTo("{0:0.0000}") + "," + this.mgs_TotalSaleAmt.FormatTo("{0:0.0000}") + string.Format(",{0},{1}", (object) this.mgs_InDate.GetDateToStrInNull(), (object) this.mgs_InUser) + string.Format(",{0},{1}", (object) this.mgs_ModDate.GetDateToStrInNull(), (object) this.mgs_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3},{4})\n", (object) this.mgs_SysDate, (object) this.mgs_MemberNo, (object) this.mgs_StoreCode, (object) this.mgs_GoodsCode, (object) this.mgs_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TMemberGoodsSum tmemberGoodsSum = this;
      // ISSUE: reference to a compiler-generated method
      tmemberGoodsSum.\u003C\u003En__0();
      if (await tmemberGoodsSum.OleDB.ExecuteAsync(tmemberGoodsSum.InsertQuery()))
        return true;
      tmemberGoodsSum.message = " " + tmemberGoodsSum.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberGoodsSum.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberGoodsSum.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3},{4})\n", (object) tmemberGoodsSum.mgs_SysDate, (object) tmemberGoodsSum.mgs_MemberNo, (object) tmemberGoodsSum.mgs_StoreCode, (object) tmemberGoodsSum.mgs_GoodsCode, (object) tmemberGoodsSum.mgs_SiteID) + " 내용 : " + tmemberGoodsSum.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberGoodsSum.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode) + string.Format(" {0}={1}", (object) "mgs_GoodsCategory", (object) this.mgs_GoodsCategory) + ",mgs_SaleQty=" + this.mgs_SaleQty.FormatTo("{0:0.0000}") + ",mgs_TotalSaleAmt=" + this.mgs_TotalSaleAmt.FormatTo("{0:0.0000}") + string.Format(",{0}={1},{2}={3}", (object) "mgs_ModDate", (object) this.mgs_ModDate.GetDateToStrInNull(), (object) "mgs_ModUser", (object) this.mgs_ModUser) + " WHERE mgs_SysDate=" + this.mgs_SysDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + string.Format(" AND {0}={1}", (object) "mgs_MemberNo", (object) this.mgs_MemberNo) + string.Format(" AND {0}={1}", (object) "mgs_StoreCode", (object) this.mgs_StoreCode) + string.Format(" AND {0}={1}", (object) "mgs_GoodsCode", (object) this.mgs_GoodsCode) + string.Format(" AND {0}={1}", (object) "mgs_SiteID", (object) this.mgs_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3},{4})\n", (object) this.mgs_SysDate, (object) this.mgs_MemberNo, (object) this.mgs_StoreCode, (object) this.mgs_GoodsCode, (object) this.mgs_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TMemberGoodsSum tmemberGoodsSum = this;
      // ISSUE: reference to a compiler-generated method
      tmemberGoodsSum.\u003C\u003En__1();
      if (await tmemberGoodsSum.OleDB.ExecuteAsync(tmemberGoodsSum.UpdateQuery()))
        return true;
      tmemberGoodsSum.message = " " + tmemberGoodsSum.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberGoodsSum.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberGoodsSum.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3},{4})\n", (object) tmemberGoodsSum.mgs_SysDate, (object) tmemberGoodsSum.mgs_MemberNo, (object) tmemberGoodsSum.mgs_StoreCode, (object) tmemberGoodsSum.mgs_GoodsCode, (object) tmemberGoodsSum.mgs_SiteID) + " 내용 : " + tmemberGoodsSum.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberGoodsSum.message);
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
      stringBuilder.Append(string.Format(" {0}={1}", (object) "mgs_GoodsCategory", (object) this.mgs_GoodsCategory) + ",mgs_SaleQty=" + this.mgs_SaleQty.FormatTo("{0:0.0000}") + ",mgs_TotalSaleAmt=" + this.mgs_TotalSaleAmt.FormatTo("{0:0.0000}") + string.Format(",{0}={1},{2}={3}", (object) "mgs_ModDate", (object) this.mgs_ModDate.GetDateToStrInNull(), (object) "mgs_ModUser", (object) this.mgs_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3},{4})\n", (object) this.mgs_SysDate, (object) this.mgs_MemberNo, (object) this.mgs_StoreCode, (object) this.mgs_GoodsCode, (object) this.mgs_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TMemberGoodsSum tmemberGoodsSum = this;
      // ISSUE: reference to a compiler-generated method
      tmemberGoodsSum.\u003C\u003En__1();
      if (await tmemberGoodsSum.OleDB.ExecuteAsync(tmemberGoodsSum.UpdateExInsertQuery()))
        return true;
      tmemberGoodsSum.message = " " + tmemberGoodsSum.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberGoodsSum.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberGoodsSum.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3},{4})\n", (object) tmemberGoodsSum.mgs_SysDate, (object) tmemberGoodsSum.mgs_MemberNo, (object) tmemberGoodsSum.mgs_StoreCode, (object) tmemberGoodsSum.mgs_GoodsCode, (object) tmemberGoodsSum.mgs_SiteID) + " 내용 : " + tmemberGoodsSum.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberGoodsSum.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "mgs_SiteID") && Convert.ToInt64(hashtable[(object) "mgs_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "mgs_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "mgs_SysDate") && !string.IsNullOrEmpty(hashtable[(object) "mgs_SysDate"].ToString()))
          stringBuilder.Append(" AND mgs_SysDate=" + new DateTime?((DateTime) hashtable[(object) "mgs_SysDate"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'"));
        if (hashtable.ContainsKey((object) "mgs_SysDate_BEGIN_") && !string.IsNullOrEmpty(hashtable[(object) "mgs_SysDate_BEGIN_"].ToString()) && hashtable.ContainsKey((object) "mgs_SysDate_END_") && !string.IsNullOrEmpty(hashtable[(object) "mgs_SysDate_END_"].ToString()))
          stringBuilder.Append(" AND mgs_SysDate<=" + new DateTime?((DateTime) hashtable[(object) "mgs_SysDate_BEGIN_"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + " AND mgs_SysDate>=" + new DateTime?((DateTime) hashtable[(object) "mgs_SysDate_END_"]).GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'"));
        if (hashtable.ContainsKey((object) "mgs_MemberNo") && Convert.ToInt64(hashtable[(object) "mgs_MemberNo"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mgs_MemberNo", hashtable[(object) "mgs_MemberNo"]));
        if (hashtable.ContainsKey((object) "mgs_StoreCode") && Convert.ToInt32(hashtable[(object) "mgs_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mgs_StoreCode", hashtable[(object) "mgs_StoreCode"]));
        if (hashtable.ContainsKey((object) "mgs_GoodsCode") && Convert.ToInt64(hashtable[(object) "mgs_GoodsCode"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mgs_GoodsCode", hashtable[(object) "mgs_GoodsCode"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mgs_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "mgs_GoodsCategory") && Convert.ToInt32(hashtable[(object) "mgs_GoodsCategory"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mgs_GoodsCategory", hashtable[(object) "mgs_GoodsCategory"]));
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
        stringBuilder.Append(" SELECT  mgs_SysDate,mgs_MemberNo,mgs_StoreCode,mgs_GoodsCode,mgs_SiteID,mgs_GoodsCategory,mgs_SaleQty,mgs_TotalSaleAmt,mgs_InDate,mgs_InUser,mgs_ModDate,mgs_ModUser");
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
