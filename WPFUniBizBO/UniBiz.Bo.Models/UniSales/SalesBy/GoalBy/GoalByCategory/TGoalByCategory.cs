// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.GoalBy.GoalByCategory.TGoalByCategory
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

namespace UniBiz.Bo.Models.UniSales.SalesBy.GoalBy.GoalByCategory
{
  public class TGoalByCategory : UbModelBase<TGoalByCategory>
  {
    private int _gbc_StoreCode;
    private DateTime? _gbc_SaleDate;
    private int _gbc_CategoryCode;
    private long _gbc_SiteID;
    private double _gbc_GoalSaleAmt;
    private double _gbc_GoalProfitAmt;
    private DateTime? _gbc_InDate;
    private int _gbc_InUser;
    private DateTime? _gbc_ModDate;
    private int _gbc_ModUser;

    public override object _Key => (object) new object[3]
    {
      (object) this.gbc_StoreCode,
      (object) this.gbc_SaleDate,
      (object) this.gbc_CategoryCode
    };

    public int gbc_StoreCode
    {
      get => this._gbc_StoreCode;
      set
      {
        this._gbc_StoreCode = value;
        this.Changed(nameof (gbc_StoreCode));
      }
    }

    public DateTime? gbc_SaleDate
    {
      get => this._gbc_SaleDate;
      set
      {
        this._gbc_SaleDate = value;
        this.Changed(nameof (gbc_SaleDate));
      }
    }

    public int gbc_CategoryCode
    {
      get => this._gbc_CategoryCode;
      set
      {
        this._gbc_CategoryCode = value;
        this.Changed(nameof (gbc_CategoryCode));
        this.Changed("ctg_lv1_ID");
      }
    }

    public int ctg_lv1_ID => this.gbc_CategoryCode;

    public long gbc_SiteID
    {
      get => this._gbc_SiteID;
      set
      {
        this._gbc_SiteID = value;
        this.Changed(nameof (gbc_SiteID));
      }
    }

    public double gbc_GoalSaleAmt
    {
      get => this._gbc_GoalSaleAmt;
      set
      {
        this._gbc_GoalSaleAmt = value;
        this.Changed(nameof (gbc_GoalSaleAmt));
      }
    }

    public double gbc_GoalProfitAmt
    {
      get => this._gbc_GoalProfitAmt;
      set
      {
        this._gbc_GoalProfitAmt = value;
        this.Changed(nameof (gbc_GoalProfitAmt));
      }
    }

    public DateTime? gbc_InDate
    {
      get => this._gbc_InDate;
      set
      {
        this._gbc_InDate = value;
        this.Changed(nameof (gbc_InDate));
      }
    }

    public int gbc_InUser
    {
      get => this._gbc_InUser;
      set
      {
        this._gbc_InUser = value;
        this.Changed(nameof (gbc_InUser));
      }
    }

    public DateTime? gbc_ModDate
    {
      get => this._gbc_ModDate;
      set
      {
        this._gbc_ModDate = value;
        this.Changed(nameof (gbc_ModDate));
      }
    }

    public int gbc_ModUser
    {
      get => this._gbc_ModUser;
      set
      {
        this._gbc_ModUser = value;
        this.Changed(nameof (gbc_ModUser));
      }
    }

    public TGoalByCategory() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("gbc_StoreCode", new TTableColumn()
      {
        tc_orgin_name = "gbc_StoreCode",
        tc_trans_name = "지점코드"
      });
      columnInfo.Add("gbc_SaleDate", new TTableColumn()
      {
        tc_orgin_name = "gbc_SaleDate",
        tc_trans_name = "판매일자"
      });
      columnInfo.Add("gbc_CategoryCode", new TTableColumn()
      {
        tc_orgin_name = "gbc_CategoryCode",
        tc_trans_name = "분류ID"
      });
      columnInfo.Add("gbc_SiteID", new TTableColumn()
      {
        tc_orgin_name = "gbc_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("gbc_GoalSaleAmt", new TTableColumn()
      {
        tc_orgin_name = "gbc_GoalSaleAmt",
        tc_trans_name = "매출목표"
      });
      columnInfo.Add("gbc_GoalProfitAmt", new TTableColumn()
      {
        tc_orgin_name = "gbc_GoalProfitAmt",
        tc_trans_name = "매출이익 목표"
      });
      columnInfo.Add("gbc_InDate", new TTableColumn()
      {
        tc_orgin_name = "gbc_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("gbc_InUser", new TTableColumn()
      {
        tc_orgin_name = "gbc_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("gbc_ModDate", new TTableColumn()
      {
        tc_orgin_name = "gbc_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("gbc_ModUser", new TTableColumn()
      {
        tc_orgin_name = "gbc_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.GoalByCategory;
      this.gbc_StoreCode = 0;
      this.gbc_SaleDate = new DateTime?();
      this.gbc_CategoryCode = 0;
      this.gbc_SiteID = 0L;
      this.gbc_GoalSaleAmt = this.gbc_GoalProfitAmt = 0.0;
      this.gbc_InDate = new DateTime?();
      this.gbc_InUser = 0;
      this.gbc_ModDate = new DateTime?();
      this.gbc_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TGoalByCategory();

    public override object Clone()
    {
      TGoalByCategory tgoalByCategory = base.Clone() as TGoalByCategory;
      tgoalByCategory.gbc_StoreCode = this.gbc_StoreCode;
      tgoalByCategory.gbc_SaleDate = this.gbc_SaleDate;
      tgoalByCategory.gbc_CategoryCode = this.gbc_CategoryCode;
      tgoalByCategory.gbc_SiteID = this.gbc_SiteID;
      tgoalByCategory.gbc_GoalSaleAmt = this.gbc_GoalSaleAmt;
      tgoalByCategory.gbc_GoalProfitAmt = this.gbc_GoalProfitAmt;
      tgoalByCategory.gbc_InDate = this.gbc_InDate;
      tgoalByCategory.gbc_ModDate = this.gbc_ModDate;
      tgoalByCategory.gbc_InUser = this.gbc_InUser;
      tgoalByCategory.gbc_ModUser = this.gbc_ModUser;
      return (object) tgoalByCategory;
    }

    public void PutData(TGoalByCategory pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.gbc_StoreCode = pSource.gbc_StoreCode;
      this.gbc_SaleDate = pSource.gbc_SaleDate;
      this.gbc_CategoryCode = pSource.gbc_CategoryCode;
      this.gbc_SiteID = pSource.gbc_SiteID;
      this.gbc_GoalSaleAmt = pSource.gbc_GoalSaleAmt;
      this.gbc_GoalProfitAmt = pSource.gbc_GoalProfitAmt;
      this.gbc_InDate = pSource.gbc_InDate;
      this.gbc_ModDate = pSource.gbc_ModDate;
      this.gbc_InUser = pSource.gbc_InUser;
      this.gbc_ModUser = pSource.gbc_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.gbc_StoreCode = p_rs.GetFieldInt("gbc_StoreCode");
        if (this.gbc_StoreCode == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.gbc_SaleDate = p_rs.GetFieldDateTime("gbc_SaleDate");
        this.gbc_CategoryCode = p_rs.GetFieldInt("gbc_CategoryCode");
        this.gbc_SiteID = p_rs.GetFieldLong("gbc_SiteID");
        this.gbc_GoalSaleAmt = p_rs.GetFieldDouble("gbc_GoalSaleAmt");
        this.gbc_GoalProfitAmt = p_rs.GetFieldDouble("gbc_GoalProfitAmt");
        this.gbc_InDate = p_rs.GetFieldDateTime("gbc_InDate");
        this.gbc_InUser = p_rs.GetFieldInt("gbc_InUser");
        this.gbc_ModDate = p_rs.GetFieldDateTime("gbc_ModDate");
        this.gbc_ModUser = p_rs.GetFieldInt("gbc_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_SALES), (object) this.TableCode) + " gbc_StoreCode,gbc_SaleDate,gbc_CategoryCode,gbc_SiteID,gbc_GoalSaleAmt,gbc_GoalProfitAmt,gbc_InDate,gbc_InUser,gbc_ModDate,gbc_ModUser) VALUES ( " + string.Format(" {0},'{1}',{2}", (object) this.gbc_StoreCode, (object) this.gbc_SaleDate.GetDateToStr("yyyy-MM-dd 00:00:00"), (object) this.gbc_CategoryCode) + string.Format(",{0}", (object) this.gbc_SiteID) + "," + this.gbc_GoalSaleAmt.FormatTo("{0:0.0000}") + "," + this.gbc_GoalProfitAmt.FormatTo("{0:0.0000}") + string.Format(",{0},{1}", (object) this.gbc_InDate.GetDateToStrInNull(), (object) this.gbc_InUser) + string.Format(",{0},{1}", (object) this.gbc_ModDate.GetDateToStrInNull(), (object) this.gbc_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.gbc_StoreCode, (object) this.gbc_SaleDate, (object) this.gbc_CategoryCode, (object) this.gbc_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TGoalByCategory tgoalByCategory = this;
      // ISSUE: reference to a compiler-generated method
      tgoalByCategory.\u003C\u003En__0();
      if (await tgoalByCategory.OleDB.ExecuteAsync(tgoalByCategory.InsertQuery()))
        return true;
      tgoalByCategory.message = " " + tgoalByCategory.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tgoalByCategory.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tgoalByCategory.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tgoalByCategory.gbc_StoreCode, (object) tgoalByCategory.gbc_SaleDate, (object) tgoalByCategory.gbc_CategoryCode, (object) tgoalByCategory.gbc_SiteID) + " 내용 : " + tgoalByCategory.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tgoalByCategory.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_SALES), (object) this.TableCode) + " gbc_GoalSaleAmt=" + this.gbc_GoalSaleAmt.FormatTo("{0:0.0000}") + ",gbc_GoalProfitAmt=" + this.gbc_GoalProfitAmt.FormatTo("{0:0.0000}") + string.Format(",{0}={1},{2}={3}", (object) "gbc_ModDate", (object) this.gbc_ModDate.GetDateToStrInNull(), (object) "gbc_ModUser", (object) this.gbc_ModUser) + string.Format(" WHERE {0}={1}", (object) "gbc_StoreCode", (object) this.gbc_StoreCode) + " AND gbc_SaleDate='" + this.gbc_SaleDate.GetDateToStr("yyyy-MM-dd 00:00:00") + "'" + string.Format(" AND {0}={1}", (object) "gbc_CategoryCode", (object) this.gbc_CategoryCode) + string.Format(" AND {0}={1}", (object) "gbc_SiteID", (object) this.gbc_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.gbc_StoreCode, (object) this.gbc_SaleDate, (object) this.gbc_CategoryCode, (object) this.gbc_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TGoalByCategory tgoalByCategory = this;
      // ISSUE: reference to a compiler-generated method
      tgoalByCategory.\u003C\u003En__1();
      if (await tgoalByCategory.OleDB.ExecuteAsync(tgoalByCategory.UpdateQuery()))
        return true;
      tgoalByCategory.message = " " + tgoalByCategory.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tgoalByCategory.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tgoalByCategory.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tgoalByCategory.gbc_StoreCode, (object) tgoalByCategory.gbc_SaleDate, (object) tgoalByCategory.gbc_CategoryCode, (object) tgoalByCategory.gbc_SiteID) + " 내용 : " + tgoalByCategory.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tgoalByCategory.message);
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
      stringBuilder.Append(" gbc_GoalSaleAmt=" + this.gbc_GoalSaleAmt.FormatTo("{0:0.0000}") + ",gbc_GoalProfitAmt=" + this.gbc_GoalProfitAmt.FormatTo("{0:0.0000}") + string.Format(",{0}={1},{2}={3}", (object) "gbc_ModDate", (object) this.gbc_ModDate.GetDateToStrInNull(), (object) "gbc_ModUser", (object) this.gbc_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.gbc_StoreCode, (object) this.gbc_SaleDate, (object) this.gbc_CategoryCode, (object) this.gbc_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TGoalByCategory tgoalByCategory = this;
      // ISSUE: reference to a compiler-generated method
      tgoalByCategory.\u003C\u003En__1();
      if (await tgoalByCategory.OleDB.ExecuteAsync(tgoalByCategory.UpdateExInsertQuery()))
        return true;
      tgoalByCategory.message = " " + tgoalByCategory.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tgoalByCategory.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tgoalByCategory.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tgoalByCategory.gbc_StoreCode, (object) tgoalByCategory.gbc_SaleDate, (object) tgoalByCategory.gbc_CategoryCode, (object) tgoalByCategory.gbc_SiteID) + " 내용 : " + tgoalByCategory.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tgoalByCategory.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "gbc_SiteID") && Convert.ToInt64(hashtable[(object) "gbc_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "gbc_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "si_StoreCode") && Convert.ToInt32(hashtable[(object) "si_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gbc_StoreCode", hashtable[(object) "si_StoreCode"]));
        else if (hashtable.ContainsKey((object) "gbc_StoreCode") && Convert.ToInt32(hashtable[(object) "gbc_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gbc_StoreCode", hashtable[(object) "gbc_StoreCode"]));
        else if (hashtable.ContainsKey((object) "si_StoreCode_IN_") && hashtable[(object) "si_StoreCode_IN_"].ToString().Length > 0)
        {
          if (hashtable[(object) "si_StoreCode_IN_"].ToString().Contains(","))
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "gbc_StoreCode", hashtable[(object) "si_StoreCode_IN_"]));
          else
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gbc_StoreCode", hashtable[(object) "si_StoreCode_IN_"]));
        }
        else if (hashtable.ContainsKey((object) "gbc_StoreCode_IN_") && hashtable[(object) "gbc_StoreCode_IN_"].ToString().Length > 0)
        {
          if (hashtable[(object) "gbc_StoreCode_IN_"].ToString().Contains(","))
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "gbc_StoreCode", hashtable[(object) "gbc_StoreCode_IN_"]));
          else
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gbc_StoreCode", hashtable[(object) "gbc_StoreCode_IN_"]));
        }
        else if (hashtable.ContainsKey((object) "_STORE_AUTHS_") && hashtable[(object) "_STORE_AUTHS_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "gbc_StoreCode", hashtable[(object) "_STORE_AUTHS_"]));
        if (hashtable.ContainsKey((object) "gbc_SaleDate"))
        {
          stringBuilder.Append(" AND gbc_SaleDate >='" + new DateTime?((DateTime) hashtable[(object) "gbc_SaleDate"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND gbc_SaleDate <='" + new DateTime?((DateTime) hashtable[(object) "gbc_SaleDate"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
        }
        if (hashtable.ContainsKey((object) "gbc_SaleDate_BEGIN_") && hashtable.ContainsKey((object) "gbc_SaleDate_END_"))
        {
          stringBuilder.Append(" AND gbc_SaleDate >='" + new DateTime?((DateTime) hashtable[(object) "gbc_SaleDate_BEGIN_"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND gbc_SaleDate <='" + new DateTime?((DateTime) hashtable[(object) "gbc_SaleDate_END_"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
        }
        if (hashtable.ContainsKey((object) "gbc_CategoryCode") && Convert.ToInt32(hashtable[(object) "gbc_CategoryCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gbc_CategoryCode", hashtable[(object) "gbc_CategoryCode"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gbc_SiteID", (object) num));
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
        stringBuilder.Append(" SELECT  gbc_StoreCode,gbc_SaleDate,gbc_CategoryCode,gbc_SiteID,gbc_GoalSaleAmt,gbc_GoalProfitAmt,gbc_InDate,gbc_InUser,gbc_ModDate,gbc_ModUser");
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
