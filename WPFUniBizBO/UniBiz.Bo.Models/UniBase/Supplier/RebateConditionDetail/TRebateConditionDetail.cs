// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Supplier.RebateConditionDetail.TRebateConditionDetail
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

namespace UniBiz.Bo.Models.UniBase.Supplier.RebateConditionDetail
{
  public class TRebateConditionDetail : UbModelBase<TRebateConditionDetail>
  {
    private int _rcd_StoreCode;
    private int _rcd_Supplier;
    private int _rcd_Seq;
    private long _rcd_SiteID;
    private double _rcd_StdAmtFrom;
    private double _rcd_StdAmtTo;
    private double _rcd_RebateRate;
    private int _rcd_AddProperty;
    private DateTime? _rcd_InDate;
    private int _rcd_InUser;
    private DateTime? _rcd_ModDate;
    private int _rcd_ModUser;

    public override object _Key => (object) new object[3]
    {
      (object) this.rcd_StoreCode,
      (object) this.rcd_Supplier,
      (object) this.rcd_Seq
    };

    public int rcd_StoreCode
    {
      get => this._rcd_StoreCode;
      set
      {
        this._rcd_StoreCode = value;
        this.Changed(nameof (rcd_StoreCode));
      }
    }

    public int rcd_Supplier
    {
      get => this._rcd_Supplier;
      set
      {
        this._rcd_Supplier = value;
        this.Changed(nameof (rcd_Supplier));
      }
    }

    public int rcd_Seq
    {
      get => this._rcd_Seq;
      set
      {
        this._rcd_Seq = value;
        this.Changed(nameof (rcd_Seq));
      }
    }

    public long rcd_SiteID
    {
      get => this._rcd_SiteID;
      set
      {
        this._rcd_SiteID = value;
        this.Changed(nameof (rcd_SiteID));
      }
    }

    public double rcd_StdAmtFrom
    {
      get => this._rcd_StdAmtFrom;
      set
      {
        this._rcd_StdAmtFrom = value;
        this.Changed(nameof (rcd_StdAmtFrom));
      }
    }

    public double rcd_StdAmtTo
    {
      get => this._rcd_StdAmtTo;
      set
      {
        this._rcd_StdAmtTo = value;
        this.Changed(nameof (rcd_StdAmtTo));
      }
    }

    public double rcd_RebateRate
    {
      get => this._rcd_RebateRate;
      set
      {
        this._rcd_RebateRate = value;
        this.Changed(nameof (rcd_RebateRate));
      }
    }

    public int rcd_AddProperty
    {
      get => this._rcd_AddProperty;
      set
      {
        this._rcd_AddProperty = value;
        this.Changed(nameof (rcd_AddProperty));
      }
    }

    public DateTime? rcd_InDate
    {
      get => this._rcd_InDate;
      set
      {
        this._rcd_InDate = value;
        this.Changed(nameof (rcd_InDate));
      }
    }

    public int rcd_InUser
    {
      get => this._rcd_InUser;
      set
      {
        this._rcd_InUser = value;
        this.Changed(nameof (rcd_InUser));
      }
    }

    public DateTime? rcd_ModDate
    {
      get => this._rcd_ModDate;
      set
      {
        this._rcd_ModDate = value;
        this.Changed(nameof (rcd_ModDate));
      }
    }

    public int rcd_ModUser
    {
      get => this._rcd_ModUser;
      set
      {
        this._rcd_ModUser = value;
        this.Changed(nameof (rcd_ModUser));
      }
    }

    public TRebateConditionDetail() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("rcd_StoreCode", new TTableColumn()
      {
        tc_orgin_name = "rcd_StoreCode",
        tc_trans_name = "지점코드"
      });
      columnInfo.Add("rcd_Supplier", new TTableColumn()
      {
        tc_orgin_name = "rcd_Supplier",
        tc_trans_name = "코드"
      });
      columnInfo.Add("rcd_Seq", new TTableColumn()
      {
        tc_orgin_name = "rcd_Seq",
        tc_trans_name = "순번"
      });
      columnInfo.Add("rcd_SiteID", new TTableColumn()
      {
        tc_orgin_name = "rcd_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("rcd_StdAmtFrom", new TTableColumn()
      {
        tc_orgin_name = "rcd_StdAmtFrom",
        tc_trans_name = "기준금액 (이상)"
      });
      columnInfo.Add("rcd_RebateRate", new TTableColumn()
      {
        tc_orgin_name = "rcd_RebateRate",
        tc_trans_name = "적용장려금율 "
      });
      columnInfo.Add("rcd_InDate", new TTableColumn()
      {
        tc_orgin_name = "rcd_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("rcd_InUser", new TTableColumn()
      {
        tc_orgin_name = "rcd_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("rcd_ModDate", new TTableColumn()
      {
        tc_orgin_name = "rcd_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("rcd_ModUser", new TTableColumn()
      {
        tc_orgin_name = "rcd_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.RebateConditionDetail;
      this.rcd_StoreCode = this.rcd_Supplier = this.rcd_Seq = 0;
      this.rcd_SiteID = 0L;
      this.rcd_StdAmtFrom = this.rcd_StdAmtTo = this.rcd_RebateRate = 0.0;
      this.rcd_AddProperty = 0;
      this.rcd_InDate = new DateTime?();
      this.rcd_InUser = 0;
      this.rcd_ModDate = new DateTime?();
      this.rcd_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TRebateConditionDetail();

    public override object Clone()
    {
      TRebateConditionDetail trebateConditionDetail = base.Clone() as TRebateConditionDetail;
      trebateConditionDetail.rcd_StoreCode = this.rcd_StoreCode;
      trebateConditionDetail.rcd_Supplier = this.rcd_Supplier;
      trebateConditionDetail.rcd_Seq = this.rcd_Seq;
      trebateConditionDetail.rcd_SiteID = this.rcd_SiteID;
      trebateConditionDetail.rcd_StdAmtFrom = this.rcd_StdAmtFrom;
      trebateConditionDetail.rcd_StdAmtTo = this.rcd_StdAmtTo;
      trebateConditionDetail.rcd_RebateRate = this.rcd_RebateRate;
      trebateConditionDetail.rcd_AddProperty = this.rcd_AddProperty;
      trebateConditionDetail.rcd_InDate = this.rcd_InDate;
      trebateConditionDetail.rcd_ModDate = this.rcd_ModDate;
      trebateConditionDetail.rcd_InUser = this.rcd_InUser;
      trebateConditionDetail.rcd_ModUser = this.rcd_ModUser;
      return (object) trebateConditionDetail;
    }

    public void PutData(TRebateConditionDetail pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.rcd_StoreCode = pSource.rcd_StoreCode;
      this.rcd_Supplier = pSource.rcd_Supplier;
      this.rcd_Seq = pSource.rcd_Seq;
      this.rcd_SiteID = pSource.rcd_SiteID;
      this.rcd_StdAmtFrom = pSource.rcd_StdAmtFrom;
      this.rcd_StdAmtTo = pSource.rcd_StdAmtTo;
      this.rcd_RebateRate = pSource.rcd_RebateRate;
      this.rcd_AddProperty = pSource.rcd_AddProperty;
      this.rcd_InDate = pSource.rcd_InDate;
      this.rcd_ModDate = pSource.rcd_ModDate;
      this.rcd_InUser = pSource.rcd_InUser;
      this.rcd_ModUser = pSource.rcd_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.rcd_StoreCode = p_rs.GetFieldInt("rcd_StoreCode");
        if (this.rcd_StoreCode == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.rcd_Supplier = p_rs.GetFieldInt("rcd_Supplier");
        this.rcd_Seq = p_rs.GetFieldInt("rcd_Seq");
        this.rcd_SiteID = p_rs.GetFieldLong("rcd_SiteID");
        this.rcd_StdAmtFrom = p_rs.GetFieldDouble("rcd_StdAmtFrom");
        this.rcd_StdAmtTo = p_rs.GetFieldDouble("rcd_StdAmtTo");
        this.rcd_RebateRate = p_rs.GetFieldDouble("rcd_RebateRate");
        this.rcd_AddProperty = p_rs.GetFieldInt("rcd_AddProperty");
        this.rcd_InDate = p_rs.GetFieldDateTime("rcd_InDate");
        this.rcd_InUser = p_rs.GetFieldInt("rcd_InUser");
        this.rcd_ModDate = p_rs.GetFieldDateTime("rcd_ModDate");
        this.rcd_ModUser = p_rs.GetFieldInt("rcd_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " rcd_StoreCode,rcd_Supplier,rcd_Seq,rcd_SiteID,rcd_StdAmtFrom,rcd_StdAmtTo,rcd_RebateRate,rcd_AddProperty,rcd_InDate,rcd_InUser,rcd_ModDate,rcd_ModUser) VALUES ( " + string.Format(" {0},{1},{2}", (object) this.rcd_StoreCode, (object) this.rcd_Supplier, (object) this.rcd_Seq) + string.Format(",{0}", (object) this.rcd_SiteID) + "," + this.rcd_StdAmtFrom.FormatTo("{0:0.0000}") + "," + this.rcd_StdAmtTo.FormatTo("{0:0.0000}") + "," + this.rcd_RebateRate.FormatTo("{0:0.0000}") + string.Format(",{0}", (object) this.rcd_AddProperty) + string.Format(",{0},{1}", (object) this.rcd_InDate.GetDateToStrInNull(), (object) this.rcd_InUser) + string.Format(",{0},{1}", (object) this.rcd_ModDate.GetDateToStrInNull(), (object) this.rcd_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.rcd_StoreCode, (object) this.rcd_Supplier, (object) this.rcd_Seq, (object) this.rcd_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TRebateConditionDetail trebateConditionDetail = this;
      // ISSUE: reference to a compiler-generated method
      trebateConditionDetail.\u003C\u003En__0();
      if (await trebateConditionDetail.OleDB.ExecuteAsync(trebateConditionDetail.InsertQuery()))
        return true;
      trebateConditionDetail.message = " " + trebateConditionDetail.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + trebateConditionDetail.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) trebateConditionDetail.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) trebateConditionDetail.rcd_StoreCode, (object) trebateConditionDetail.rcd_Supplier, (object) trebateConditionDetail.rcd_Seq, (object) trebateConditionDetail.rcd_SiteID) + " 내용 : " + trebateConditionDetail.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(trebateConditionDetail.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " rcd_StdAmtFrom=" + this.rcd_StdAmtFrom.FormatTo("{0:0.0000}") + ",rcd_StdAmtTo=" + this.rcd_StdAmtTo.FormatTo("{0:0.0000}") + ",rcd_RebateRate=" + this.rcd_RebateRate.FormatTo("{0:0.0000}") + string.Format(",{0}={1}", (object) "rcd_AddProperty", (object) this.rcd_AddProperty) + string.Format(",{0}={1},{2}={3}", (object) "rcd_ModDate", (object) this.rcd_ModDate.GetDateToStrInNull(), (object) "rcd_ModUser", (object) this.rcd_ModUser) + string.Format(" WHERE {0}={1}", (object) "rcd_StoreCode", (object) this.rcd_StoreCode) + string.Format(" AND {0}={1}", (object) "rcd_Supplier", (object) this.rcd_Supplier) + string.Format(" AND {0}={1}", (object) "rcd_Seq", (object) this.rcd_Seq) + string.Format(" AND {0}={1}", (object) "rcd_SiteID", (object) this.rcd_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.rcd_StoreCode, (object) this.rcd_Supplier, (object) this.rcd_Seq, (object) this.rcd_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TRebateConditionDetail trebateConditionDetail = this;
      // ISSUE: reference to a compiler-generated method
      trebateConditionDetail.\u003C\u003En__1();
      if (await trebateConditionDetail.OleDB.ExecuteAsync(trebateConditionDetail.UpdateQuery()))
        return true;
      trebateConditionDetail.message = " " + trebateConditionDetail.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + trebateConditionDetail.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) trebateConditionDetail.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) trebateConditionDetail.rcd_StoreCode, (object) trebateConditionDetail.rcd_Supplier, (object) trebateConditionDetail.rcd_Seq, (object) trebateConditionDetail.rcd_SiteID) + " 내용 : " + trebateConditionDetail.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(trebateConditionDetail.message);
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
      stringBuilder.Append(" rcd_StdAmtFrom=" + this.rcd_StdAmtFrom.FormatTo("{0:0.0000}") + ",rcd_StdAmtTo=" + this.rcd_StdAmtTo.FormatTo("{0:0.0000}") + ",rcd_RebateRate=" + this.rcd_RebateRate.FormatTo("{0:0.0000}") + string.Format(",{0}={1}", (object) "rcd_AddProperty", (object) this.rcd_AddProperty) + string.Format(",{0}={1},{2}={3}", (object) "rcd_ModDate", (object) this.rcd_ModDate.GetDateToStrInNull(), (object) "rcd_ModUser", (object) this.rcd_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.rcd_StoreCode, (object) this.rcd_Supplier, (object) this.rcd_Seq, (object) this.rcd_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TRebateConditionDetail trebateConditionDetail = this;
      // ISSUE: reference to a compiler-generated method
      trebateConditionDetail.\u003C\u003En__1();
      if (await trebateConditionDetail.OleDB.ExecuteAsync(trebateConditionDetail.UpdateExInsertQuery()))
        return true;
      trebateConditionDetail.message = " " + trebateConditionDetail.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + trebateConditionDetail.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) trebateConditionDetail.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) trebateConditionDetail.rcd_StoreCode, (object) trebateConditionDetail.rcd_Supplier, (object) trebateConditionDetail.rcd_Seq, (object) trebateConditionDetail.rcd_SiteID) + " 내용 : " + trebateConditionDetail.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(trebateConditionDetail.message);
      return false;
    }

    public override string DeleteQuery() => string.Format(" DELETE FROM {0}{1}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + string.Format(" WHERE {0}={1}", (object) "rcd_StoreCode", (object) this.rcd_StoreCode) + string.Format(" AND {0}={1}", (object) "rcd_Supplier", (object) this.rcd_Supplier) + string.Format(" AND {0}={1}", (object) "rcd_Seq", (object) this.rcd_Seq) + string.Format(" AND {0}={1}", (object) "rcd_SiteID", (object) this.rcd_SiteID);

    public override bool Delete()
    {
      this.InsertChecked();
      string pStrExec = this.DeleteQuery();
      if (this.OleDB.Execute(pStrExec))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 삭제 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.rcd_StoreCode, (object) this.rcd_Supplier, (object) this.rcd_Seq, (object) this.rcd_SiteID) + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n 쿼리 : " + pStrExec + "\n--------------------------------------------------------------------------------------------------\n";
      return false;
    }

    public override async Task<bool> DeleteAsync()
    {
      TRebateConditionDetail trebateConditionDetail = this;
      // ISSUE: reference to a compiler-generated method
      trebateConditionDetail.\u003C\u003En__0();
      if (await trebateConditionDetail.OleDB.ExecuteAsync(trebateConditionDetail.DeleteQuery()))
        return true;
      trebateConditionDetail.message = " " + trebateConditionDetail.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + trebateConditionDetail.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) trebateConditionDetail.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) trebateConditionDetail.rcd_StoreCode, (object) trebateConditionDetail.rcd_Supplier, (object) trebateConditionDetail.rcd_Seq, (object) trebateConditionDetail.rcd_SiteID) + " 내용 : " + trebateConditionDetail.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(trebateConditionDetail.message);
      return false;
    }

    public virtual string DeleteQuery(
      int p_rcd_StoreCode,
      int p_rcd_Supplier,
      int p_rcd_Seq,
      long p_rcd_SiteID = 0)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format(" DELETE FROM {0}{1} ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode));
      stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "rcd_StoreCode", (object) p_rcd_StoreCode));
      stringBuilder.Append(string.Format(" AND {0}={1}", (object) "rcd_Supplier", (object) p_rcd_Supplier));
      stringBuilder.Append(string.Format(" AND {0}={1}", (object) "rcd_Seq", (object) p_rcd_Seq));
      if (p_rcd_SiteID > 0L)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "rcd_SiteID", (object) p_rcd_SiteID));
      return stringBuilder.ToString();
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "rcd_SiteID") && Convert.ToInt64(hashtable[(object) "rcd_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "rcd_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "rcd_StoreCode") && Convert.ToInt32(hashtable[(object) "rcd_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "rcd_StoreCode", hashtable[(object) "rcd_StoreCode"]));
        else if (hashtable.ContainsKey((object) "rcd_StoreCode_IN_") && hashtable[(object) "rcd_StoreCode_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "rcd_StoreCode", hashtable[(object) "rcd_StoreCode_IN_"]));
        else if (hashtable.ContainsKey((object) "_STORE_AUTHS_") && hashtable[(object) "_STORE_AUTHS_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "rcd_StoreCode", hashtable[(object) "_STORE_AUTHS_"]));
        if (hashtable.ContainsKey((object) "rcd_Supplier") && Convert.ToInt32(hashtable[(object) "rcd_Supplier"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "rcd_Supplier", hashtable[(object) "rcd_Supplier"]));
        else if (hashtable.ContainsKey((object) "rcd_Supplier_IN_") && hashtable[(object) "rcd_Supplier_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "rcd_Supplier", hashtable[(object) "rcd_Supplier_IN_"]));
        else if (hashtable.ContainsKey((object) "_SUPPLIER_AUTHS_") && hashtable[(object) "_SUPPLIER_AUTHS_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "rcd_Supplier", hashtable[(object) "_SUPPLIER_AUTHS_"]));
        if (hashtable.ContainsKey((object) "rcd_Seq") && Convert.ToInt32(hashtable[(object) "rcd_Seq"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "rcd_Seq", hashtable[(object) "rcd_Seq"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "rcd_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "rcd_StdAmtFrom") && !Convert.ToDouble(hashtable[(object) "rcd_StdAmtFrom"].ToString()).IsZero())
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "rcd_StdAmtFrom", hashtable[(object) "rcd_StdAmtFrom"]));
        if (hashtable.ContainsKey((object) "rcd_StdAmtTo") && !Convert.ToDouble(hashtable[(object) "rcd_StdAmtTo"].ToString()).IsZero())
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "rcd_StdAmtTo", hashtable[(object) "rcd_StdAmtTo"]));
        if (hashtable.ContainsKey((object) "rcd_RebateRate") && !Convert.ToDouble(hashtable[(object) "rcd_RebateRate"].ToString()).IsZero())
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "rcd_RebateRate", hashtable[(object) "rcd_RebateRate"]));
        if (hashtable.ContainsKey((object) "_BEGIN_") && hashtable.ContainsKey((object) "_END_"))
        {
          stringBuilder.Append(" AND (");
          stringBuilder.Append(string.Format(" ({0} <= {1} AND {2} >= {3} )", (object) "rcd_StdAmtFrom", hashtable[(object) "_BEGIN_"], (object) "rcd_StdAmtTo", hashtable[(object) "_BEGIN_"]));
          stringBuilder.Append(string.Format(" OR ({0} <= {1} AND {2} >= {3} )", (object) "rcd_StdAmtFrom", hashtable[(object) "_END_"], (object) "rcd_StdAmtTo", hashtable[(object) "_END_"]));
          stringBuilder.Append(string.Format(" OR ({0} >= {1} AND {2} <= {3} )", (object) "rcd_StdAmtFrom", hashtable[(object) "_BEGIN_"], (object) "rcd_StdAmtTo", hashtable[(object) "_END_"]));
          stringBuilder.Append(") ");
        }
        if (hashtable.ContainsKey((object) "rcd_AddProperty") && Convert.ToInt32(hashtable[(object) "rcd_AddProperty"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "rcd_AddProperty", hashtable[(object) "rcd_AddProperty"]));
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
        stringBuilder.Append(" SELECT  rcd_StoreCode,rcd_Supplier,rcd_Seq,rcd_SiteID,rcd_StdAmtFrom,rcd_StdAmtTo,rcd_RebateRate,rcd_AddProperty,rcd_InDate,rcd_InUser,rcd_ModDate,rcd_ModUser");
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
