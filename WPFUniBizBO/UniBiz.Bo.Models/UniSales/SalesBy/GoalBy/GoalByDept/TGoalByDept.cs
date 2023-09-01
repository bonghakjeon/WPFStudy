// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.GoalBy.GoalByDept.TGoalByDept
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
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.TableInfo;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniSales.SalesBy.GoalBy.GoalByDept
{
  public class TGoalByDept : UbModelBase<TGoalByDept>
  {
    private int _gbd_StoreCode;
    private DateTime? _gbd_SaleDate;
    private int _gbd_DeptCode;
    private long _gbd_SiteID;
    private double _gbd_GoalSaleAmt;
    private double _gbd_GoalProfitAmt;
    private DateTime? _gbd_InDate;
    private int _gbd_InUser;
    private DateTime? _gbd_ModDate;
    private int _gbd_ModUser;

    public override object _Key => (object) new object[3]
    {
      (object) this.gbd_StoreCode,
      (object) this.gbd_SaleDate,
      (object) this.gbd_DeptCode
    };

    public int gbd_StoreCode
    {
      get => this._gbd_StoreCode;
      set
      {
        this._gbd_StoreCode = value;
        this.Changed(nameof (gbd_StoreCode));
      }
    }

    public DateTime? gbd_SaleDate
    {
      get => this._gbd_SaleDate;
      set
      {
        this._gbd_SaleDate = value;
        this.Changed(nameof (gbd_SaleDate));
      }
    }

    public int gbd_DeptCode
    {
      get => this._gbd_DeptCode;
      set
      {
        this._gbd_DeptCode = value;
        this.Changed(nameof (gbd_DeptCode));
        this.Changed("dpt_lv3_ID");
      }
    }

    [JsonIgnore]
    public int dpt_lv3_ID => this.gbd_DeptCode;

    public long gbd_SiteID
    {
      get => this._gbd_SiteID;
      set
      {
        this._gbd_SiteID = value;
        this.Changed(nameof (gbd_SiteID));
      }
    }

    public double gbd_GoalSaleAmt
    {
      get => this._gbd_GoalSaleAmt;
      set
      {
        this._gbd_GoalSaleAmt = value;
        this.Changed(nameof (gbd_GoalSaleAmt));
      }
    }

    public double gbd_GoalProfitAmt
    {
      get => this._gbd_GoalProfitAmt;
      set
      {
        this._gbd_GoalProfitAmt = value;
        this.Changed(nameof (gbd_GoalProfitAmt));
      }
    }

    public DateTime? gbd_InDate
    {
      get => this._gbd_InDate;
      set
      {
        this._gbd_InDate = value;
        this.Changed(nameof (gbd_InDate));
      }
    }

    public int gbd_InUser
    {
      get => this._gbd_InUser;
      set
      {
        this._gbd_InUser = value;
        this.Changed(nameof (gbd_InUser));
      }
    }

    public DateTime? gbd_ModDate
    {
      get => this._gbd_ModDate;
      set
      {
        this._gbd_ModDate = value;
        this.Changed(nameof (gbd_ModDate));
      }
    }

    public int gbd_ModUser
    {
      get => this._gbd_ModUser;
      set
      {
        this._gbd_ModUser = value;
        this.Changed(nameof (gbd_ModUser));
      }
    }

    public TGoalByDept() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("gbd_StoreCode", new TTableColumn()
      {
        tc_orgin_name = "gbd_StoreCode",
        tc_trans_name = "지점코드"
      });
      columnInfo.Add("gbd_SaleDate", new TTableColumn()
      {
        tc_orgin_name = "gbd_SaleDate",
        tc_trans_name = "판매일자"
      });
      columnInfo.Add("gbd_DeptCode", new TTableColumn()
      {
        tc_orgin_name = "gbd_DeptCode",
        tc_trans_name = "부서ID"
      });
      columnInfo.Add("gbd_SiteID", new TTableColumn()
      {
        tc_orgin_name = "gbd_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("gbd_GoalSaleAmt", new TTableColumn()
      {
        tc_orgin_name = "gbd_GoalSaleAmt",
        tc_trans_name = "매출목표"
      });
      columnInfo.Add("gbd_GoalProfitAmt", new TTableColumn()
      {
        tc_orgin_name = "gbd_GoalProfitAmt",
        tc_trans_name = "매출이익 목표"
      });
      columnInfo.Add("gbd_InDate", new TTableColumn()
      {
        tc_orgin_name = "gbd_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("gbd_InUser", new TTableColumn()
      {
        tc_orgin_name = "gbd_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("gbd_ModDate", new TTableColumn()
      {
        tc_orgin_name = "gbd_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("gbd_ModUser", new TTableColumn()
      {
        tc_orgin_name = "gbd_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.GoalByDept;
      this.gbd_StoreCode = 0;
      this.gbd_SaleDate = new DateTime?();
      this.gbd_DeptCode = 0;
      this.gbd_SiteID = 0L;
      this.gbd_GoalSaleAmt = this.gbd_GoalProfitAmt = 0.0;
      this.gbd_InDate = new DateTime?();
      this.gbd_InUser = 0;
      this.gbd_ModDate = new DateTime?();
      this.gbd_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TGoalByDept();

    public override object Clone()
    {
      TGoalByDept tgoalByDept = base.Clone() as TGoalByDept;
      tgoalByDept.gbd_StoreCode = this.gbd_StoreCode;
      tgoalByDept.gbd_SaleDate = this.gbd_SaleDate;
      tgoalByDept.gbd_DeptCode = this.gbd_DeptCode;
      tgoalByDept.gbd_SiteID = this.gbd_SiteID;
      tgoalByDept.gbd_GoalSaleAmt = this.gbd_GoalSaleAmt;
      tgoalByDept.gbd_GoalProfitAmt = this.gbd_GoalProfitAmt;
      tgoalByDept.gbd_InDate = this.gbd_InDate;
      tgoalByDept.gbd_ModDate = this.gbd_ModDate;
      tgoalByDept.gbd_InUser = this.gbd_InUser;
      tgoalByDept.gbd_ModUser = this.gbd_ModUser;
      return (object) tgoalByDept;
    }

    public void PutData(TGoalByDept pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.gbd_StoreCode = pSource.gbd_StoreCode;
      this.gbd_SaleDate = pSource.gbd_SaleDate;
      this.gbd_DeptCode = pSource.gbd_DeptCode;
      this.gbd_SiteID = pSource.gbd_SiteID;
      this.gbd_GoalSaleAmt = pSource.gbd_GoalSaleAmt;
      this.gbd_GoalProfitAmt = pSource.gbd_GoalProfitAmt;
      this.gbd_InDate = pSource.gbd_InDate;
      this.gbd_ModDate = pSource.gbd_ModDate;
      this.gbd_InUser = pSource.gbd_InUser;
      this.gbd_ModUser = pSource.gbd_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.gbd_StoreCode = p_rs.GetFieldInt("gbd_StoreCode");
        if (this.gbd_StoreCode == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.gbd_SaleDate = p_rs.GetFieldDateTime("gbd_SaleDate");
        this.gbd_DeptCode = p_rs.GetFieldInt("gbd_DeptCode");
        this.gbd_SiteID = p_rs.GetFieldLong("gbd_SiteID");
        this.gbd_GoalSaleAmt = p_rs.GetFieldDouble("gbd_GoalSaleAmt");
        this.gbd_GoalProfitAmt = p_rs.GetFieldDouble("gbd_GoalProfitAmt");
        this.gbd_InDate = p_rs.GetFieldDateTime("gbd_InDate");
        this.gbd_InUser = p_rs.GetFieldInt("gbd_InUser");
        this.gbd_ModDate = p_rs.GetFieldDateTime("gbd_ModDate");
        this.gbd_ModUser = p_rs.GetFieldInt("gbd_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_SALES), (object) this.TableCode) + " gbd_StoreCode,gbd_SaleDate,gbd_DeptCode,gbd_SiteID,gbd_GoalSaleAmt,gbd_GoalProfitAmt,gbd_InDate,gbd_InUser,gbd_ModDate,gbd_ModUser) VALUES ( " + string.Format(" {0},'{1}',{2}", (object) this.gbd_StoreCode, (object) this.gbd_SaleDate.GetDateToStr("yyyy-MM-dd 00:00:00"), (object) this.gbd_DeptCode) + string.Format(",{0}", (object) this.gbd_SiteID) + "," + this.gbd_GoalSaleAmt.FormatTo("{0:0.0000}") + "," + this.gbd_GoalProfitAmt.FormatTo("{0:0.0000}") + string.Format(",{0},{1}", (object) this.gbd_InDate.GetDateToStrInNull(), (object) this.gbd_InUser) + string.Format(",{0},{1}", (object) this.gbd_ModDate.GetDateToStrInNull(), (object) this.gbd_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.gbd_StoreCode, (object) this.gbd_SaleDate, (object) this.gbd_DeptCode, (object) this.gbd_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TGoalByDept tgoalByDept = this;
      // ISSUE: reference to a compiler-generated method
      tgoalByDept.\u003C\u003En__0();
      if (await tgoalByDept.OleDB.ExecuteAsync(tgoalByDept.InsertQuery()))
        return true;
      tgoalByDept.message = " " + tgoalByDept.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tgoalByDept.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tgoalByDept.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tgoalByDept.gbd_StoreCode, (object) tgoalByDept.gbd_SaleDate, (object) tgoalByDept.gbd_DeptCode, (object) tgoalByDept.gbd_SiteID) + " 내용 : " + tgoalByDept.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tgoalByDept.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_SALES), (object) this.TableCode) + " gbd_GoalSaleAmt=" + this.gbd_GoalSaleAmt.FormatTo("{0:0.0000}") + ",gbd_GoalProfitAmt=" + this.gbd_GoalProfitAmt.FormatTo("{0:0.0000}") + string.Format(",{0}={1},{2}={3}", (object) "gbd_ModDate", (object) this.gbd_ModDate.GetDateToStrInNull(), (object) "gbd_ModUser", (object) this.gbd_ModUser) + string.Format(" WHERE {0}={1}", (object) "gbd_StoreCode", (object) this.gbd_StoreCode) + " AND gbd_SaleDate='" + this.gbd_SaleDate.GetDateToStr("yyyy-MM-dd 00:00:00") + "'" + string.Format(" AND {0}={1}", (object) "gbd_DeptCode", (object) this.gbd_DeptCode) + string.Format(" AND {0}={1}", (object) "gbd_SiteID", (object) this.gbd_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.gbd_StoreCode, (object) this.gbd_SaleDate, (object) this.gbd_DeptCode, (object) this.gbd_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TGoalByDept tgoalByDept = this;
      // ISSUE: reference to a compiler-generated method
      tgoalByDept.\u003C\u003En__1();
      if (await tgoalByDept.OleDB.ExecuteAsync(tgoalByDept.UpdateQuery()))
        return true;
      tgoalByDept.message = " " + tgoalByDept.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tgoalByDept.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tgoalByDept.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tgoalByDept.gbd_StoreCode, (object) tgoalByDept.gbd_SaleDate, (object) tgoalByDept.gbd_DeptCode, (object) tgoalByDept.gbd_SiteID) + " 내용 : " + tgoalByDept.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tgoalByDept.message);
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
      stringBuilder.Append(" gbd_GoalSaleAmt=" + this.gbd_GoalSaleAmt.FormatTo("{0:0.0000}") + ",gbd_GoalProfitAmt=" + this.gbd_GoalProfitAmt.FormatTo("{0:0.0000}") + string.Format(",{0}={1},{2}={3}", (object) "gbd_ModDate", (object) this.gbd_ModDate.GetDateToStrInNull(), (object) "gbd_ModUser", (object) this.gbd_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.gbd_StoreCode, (object) this.gbd_SaleDate, (object) this.gbd_DeptCode, (object) this.gbd_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TGoalByDept tgoalByDept = this;
      // ISSUE: reference to a compiler-generated method
      tgoalByDept.\u003C\u003En__1();
      if (await tgoalByDept.OleDB.ExecuteAsync(tgoalByDept.UpdateExInsertQuery()))
        return true;
      tgoalByDept.message = " " + tgoalByDept.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tgoalByDept.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tgoalByDept.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tgoalByDept.gbd_StoreCode, (object) tgoalByDept.gbd_SaleDate, (object) tgoalByDept.gbd_DeptCode, (object) tgoalByDept.gbd_SiteID) + " 내용 : " + tgoalByDept.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tgoalByDept.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "gbd_SiteID") && Convert.ToInt64(hashtable[(object) "gbd_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "gbd_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "si_StoreCode") && Convert.ToInt32(hashtable[(object) "si_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gbd_StoreCode", hashtable[(object) "si_StoreCode"]));
        else if (hashtable.ContainsKey((object) "gbd_StoreCode") && Convert.ToInt32(hashtable[(object) "gbd_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gbd_StoreCode", hashtable[(object) "gbd_StoreCode"]));
        else if (hashtable.ContainsKey((object) "si_StoreCode_IN_") && hashtable[(object) "si_StoreCode_IN_"].ToString().Length > 0)
        {
          if (hashtable[(object) "si_StoreCode_IN_"].ToString().Contains(","))
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "gbd_StoreCode", hashtable[(object) "si_StoreCode_IN_"]));
          else
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gbd_StoreCode", hashtable[(object) "si_StoreCode_IN_"]));
        }
        else if (hashtable.ContainsKey((object) "gbd_StoreCode_IN_") && hashtable[(object) "gbd_StoreCode_IN_"].ToString().Length > 0)
        {
          if (hashtable[(object) "gbd_StoreCode_IN_"].ToString().Contains(","))
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "gbd_StoreCode", hashtable[(object) "gbd_StoreCode_IN_"]));
          else
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gbd_StoreCode", hashtable[(object) "gbd_StoreCode_IN_"]));
        }
        else if (hashtable.ContainsKey((object) "_STORE_AUTHS_") && hashtable[(object) "_STORE_AUTHS_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "gbd_StoreCode", hashtable[(object) "_STORE_AUTHS_"]));
        if (hashtable.ContainsKey((object) "gbd_SaleDate"))
        {
          stringBuilder.Append(" AND gbd_SaleDate >='" + new DateTime?((DateTime) hashtable[(object) "gbd_SaleDate"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND gbd_SaleDate <='" + new DateTime?((DateTime) hashtable[(object) "gbd_SaleDate"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
        }
        if (hashtable.ContainsKey((object) "gbd_SaleDate_BEGIN_") && hashtable.ContainsKey((object) "gbd_SaleDate_END_"))
        {
          stringBuilder.Append(" AND gbd_SaleDate >='" + new DateTime?((DateTime) hashtable[(object) "gbd_SaleDate_BEGIN_"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND gbd_SaleDate <='" + new DateTime?((DateTime) hashtable[(object) "gbd_SaleDate_END_"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
        }
        if (hashtable.ContainsKey((object) "gbd_DeptCode") && Convert.ToInt32(hashtable[(object) "gbd_DeptCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gbd_DeptCode", hashtable[(object) "gbd_DeptCode"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gbd_SiteID", (object) num));
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
        string uniSales = UbModelBase.UNI_SALES;
        string str = this.TableCode.ToString();
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniSales = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
        }
        stringBuilder.Append(" SELECT  gbd_StoreCode,gbd_SaleDate,gbd_DeptCode,gbd_SiteID,gbd_GoalSaleAmt,gbd_GoalProfitAmt,gbd_InDate,gbd_InUser,gbd_ModDate,gbd_ModUser");
        stringBuilder.Append(" FROM " + DbQueryHelper.ToDBNameBridge(uniSales) + str + " " + DbQueryHelper.ToWithNolock());
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
