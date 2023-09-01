// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Supplier.SupplierHistory.TSupplierHistory
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

namespace UniBiz.Bo.Models.UniBase.Supplier.SupplierHistory
{
  public class TSupplierHistory : UbModelBase<TSupplierHistory>
  {
    private int _suh_ID;
    private long _suh_SiteID;
    private int _suh_Supplier;
    private int _suh_StoreCode;
    private DateTime? _suh_StartDate;
    private DateTime? _suh_EndDate;
    private int _suh_PayMethod;
    private int _suh_PayCondition;
    private DateTime? _suh_InDate;
    private int _suh_InUser;
    private DateTime? _suh_ModDate;
    private int _suh_ModUser;

    public override object _Key => (object) new object[1]
    {
      (object) this.suh_ID
    };

    public int suh_ID
    {
      get => this._suh_ID;
      set
      {
        this._suh_ID = value;
        this.Changed(nameof (suh_ID));
      }
    }

    public long suh_SiteID
    {
      get => this._suh_SiteID;
      set
      {
        this._suh_SiteID = value;
        this.Changed(nameof (suh_SiteID));
      }
    }

    public int suh_Supplier
    {
      get => this._suh_Supplier;
      set
      {
        this._suh_Supplier = value;
        this.Changed(nameof (suh_Supplier));
      }
    }

    public int suh_StoreCode
    {
      get => this._suh_StoreCode;
      set
      {
        this._suh_StoreCode = value;
        this.Changed(nameof (suh_StoreCode));
      }
    }

    public DateTime? suh_StartDate
    {
      get => this._suh_StartDate;
      set
      {
        this._suh_StartDate = value;
        this.Changed(nameof (suh_StartDate));
        this.Changed("IntStartDate");
      }
    }

    [JsonIgnore]
    public int IntStartDate => this.suh_StartDate.HasValue ? Convert.ToInt32(this.suh_StartDate.GetDateToStr("yyyyMMdd")) : 0;

    public DateTime? suh_EndDate
    {
      get => this._suh_EndDate;
      set
      {
        this._suh_EndDate = value;
        this.Changed(nameof (suh_EndDate));
        this.Changed("IntEndDate");
      }
    }

    [JsonIgnore]
    public int IntEndDate => this.suh_EndDate.HasValue ? Convert.ToInt32(this.suh_EndDate.GetDateToStr("yyyyMMdd")) : 0;

    public int suh_PayMethod
    {
      get => this._suh_PayMethod;
      set
      {
        this._suh_PayMethod = value;
        this.Changed(nameof (suh_PayMethod));
        this.Changed("suh_PayMethodDesc");
      }
    }

    public string suh_PayMethodDesc => this.suh_PayMethod <= 0 ? string.Empty : Enum2StrConverter.ToCommonCodeTypeMemo((long) this.suh_PayMethod, EnumCommonCodeType.SupplierPayMethod, this.suh_PayMethod);

    public int suh_PayCondition
    {
      get => this._suh_PayCondition;
      set
      {
        this._suh_PayCondition = value;
        this.Changed(nameof (suh_PayCondition));
      }
    }

    public DateTime? suh_InDate
    {
      get => this._suh_InDate;
      set
      {
        this._suh_InDate = value;
        this.Changed(nameof (suh_InDate));
      }
    }

    public int suh_InUser
    {
      get => this._suh_InUser;
      set
      {
        this._suh_InUser = value;
        this.Changed(nameof (suh_InUser));
      }
    }

    public DateTime? suh_ModDate
    {
      get => this._suh_ModDate;
      set
      {
        this._suh_ModDate = value;
        this.Changed(nameof (suh_ModDate));
      }
    }

    public int suh_ModUser
    {
      get => this._suh_ModUser;
      set
      {
        this._suh_ModUser = value;
        this.Changed(nameof (suh_ModUser));
      }
    }

    public TSupplierHistory() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("suh_ID", new TTableColumn()
      {
        tc_orgin_name = "suh_ID",
        tc_trans_name = "업체 결제 이력 KEY"
      });
      columnInfo.Add("suh_SiteID", new TTableColumn()
      {
        tc_orgin_name = "suh_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("suh_Supplier", new TTableColumn()
      {
        tc_orgin_name = "suh_Supplier",
        tc_trans_name = "코드"
      });
      columnInfo.Add("suh_StoreCode", new TTableColumn()
      {
        tc_orgin_name = "suh_StoreCode",
        tc_trans_name = "지점코드"
      });
      columnInfo.Add("suh_StartDate", new TTableColumn()
      {
        tc_orgin_name = "suh_StartDate",
        tc_trans_name = "시작일자"
      });
      columnInfo.Add("suh_EndDate", new TTableColumn()
      {
        tc_orgin_name = "suh_EndDate",
        tc_trans_name = "종료일자"
      });
      columnInfo.Add("suh_PayMethod", new TTableColumn()
      {
        tc_orgin_name = "suh_PayMethod",
        tc_trans_name = "결제수단",
        tc_comm_code = 45
      });
      columnInfo.Add("suh_PayCondition", new TTableColumn()
      {
        tc_orgin_name = "suh_PayCondition",
        tc_trans_name = "결제조건"
      });
      columnInfo.Add("suh_InDate", new TTableColumn()
      {
        tc_orgin_name = "suh_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("suh_InUser", new TTableColumn()
      {
        tc_orgin_name = "suh_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("suh_ModDate", new TTableColumn()
      {
        tc_orgin_name = "suh_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("suh_ModUser", new TTableColumn()
      {
        tc_orgin_name = "suh_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.SupplierHistory;
      this.suh_ID = 0;
      this.suh_SiteID = 0L;
      this.suh_Supplier = this.suh_StoreCode = 0;
      this.suh_StartDate = new DateTime?();
      this.suh_EndDate = new DateTime?();
      this.suh_PayMethod = 0;
      this.suh_PayCondition = 0;
      this.suh_InDate = new DateTime?();
      this.suh_InUser = 0;
      this.suh_ModDate = new DateTime?();
      this.suh_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TSupplierHistory();

    public override object Clone()
    {
      TSupplierHistory tsupplierHistory = base.Clone() as TSupplierHistory;
      tsupplierHistory.suh_ID = this.suh_ID;
      tsupplierHistory.suh_SiteID = this.suh_SiteID;
      tsupplierHistory.suh_Supplier = this.suh_Supplier;
      tsupplierHistory.suh_StoreCode = this.suh_StoreCode;
      tsupplierHistory.suh_StartDate = this.suh_StartDate;
      tsupplierHistory.suh_EndDate = this.suh_EndDate;
      tsupplierHistory.suh_PayMethod = this.suh_PayMethod;
      tsupplierHistory.suh_PayCondition = this.suh_PayCondition;
      tsupplierHistory.suh_InDate = this.suh_InDate;
      tsupplierHistory.suh_ModDate = this.suh_ModDate;
      tsupplierHistory.suh_InUser = this.suh_InUser;
      tsupplierHistory.suh_ModUser = this.suh_ModUser;
      return (object) tsupplierHistory;
    }

    public void PutData(TSupplierHistory pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.suh_ID = pSource.suh_ID;
      this.suh_SiteID = pSource.suh_SiteID;
      this.suh_Supplier = pSource.suh_Supplier;
      this.suh_StoreCode = pSource.suh_StoreCode;
      this.suh_StartDate = pSource.suh_StartDate;
      this.suh_EndDate = pSource.suh_EndDate;
      this.suh_PayMethod = pSource.suh_PayMethod;
      this.suh_PayCondition = pSource.suh_PayCondition;
      this.suh_InDate = pSource.suh_InDate;
      this.suh_ModDate = pSource.suh_ModDate;
      this.suh_InUser = pSource.suh_InUser;
      this.suh_ModUser = pSource.suh_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.suh_ID = p_rs.GetFieldInt("suh_ID");
        if (this.suh_ID == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.suh_SiteID = p_rs.GetFieldLong("suh_SiteID");
        this.suh_Supplier = p_rs.GetFieldInt("suh_Supplier");
        this.suh_StoreCode = p_rs.GetFieldInt("suh_StoreCode");
        this.suh_StartDate = p_rs.GetFieldDateTime("suh_StartDate");
        this.suh_EndDate = p_rs.GetFieldDateTime("suh_EndDate");
        this.suh_PayMethod = p_rs.GetFieldInt("suh_PayMethod");
        this.suh_PayCondition = p_rs.GetFieldInt("suh_PayCondition");
        this.suh_InDate = p_rs.GetFieldDateTime("suh_InDate");
        this.suh_InUser = p_rs.GetFieldInt("suh_InUser");
        this.suh_ModDate = p_rs.GetFieldDateTime("suh_ModDate");
        this.suh_ModUser = p_rs.GetFieldInt("suh_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " suh_ID,suh_SiteID,suh_Supplier,suh_StoreCode,suh_StartDate,suh_EndDate,suh_PayMethod,suh_PayCondition,suh_InDate,suh_InUser,suh_ModDate,suh_ModUser) VALUES ( " + string.Format(" {0}", (object) this.suh_ID) + string.Format(",{0}", (object) this.suh_SiteID) + string.Format(",{0},{1}", (object) this.suh_Supplier, (object) this.suh_StoreCode) + ",'" + this.suh_StartDate.GetDateToStr("yyyy-MM-dd 00:00:00") + "','" + this.suh_EndDate.GetDateToStr("yyyy-MM-dd 23:59:59") + "'" + string.Format(",{0},{1}", (object) this.suh_PayMethod, (object) this.suh_PayCondition) + string.Format(",{0},{1}", (object) this.suh_InDate.GetDateToStrInNull(), (object) this.suh_InUser) + string.Format(",{0},{1}", (object) this.suh_ModDate.GetDateToStrInNull(), (object) this.suh_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.suh_ID, (object) this.suh_SiteID, (object) this.suh_Supplier, (object) this.suh_StoreCode) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TSupplierHistory tsupplierHistory = this;
      // ISSUE: reference to a compiler-generated method
      tsupplierHistory.\u003C\u003En__0();
      if (await tsupplierHistory.OleDB.ExecuteAsync(tsupplierHistory.InsertQuery()))
        return true;
      tsupplierHistory.message = " " + tsupplierHistory.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tsupplierHistory.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tsupplierHistory.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tsupplierHistory.suh_ID, (object) tsupplierHistory.suh_SiteID, (object) tsupplierHistory.suh_Supplier, (object) tsupplierHistory.suh_StoreCode) + " 내용 : " + tsupplierHistory.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tsupplierHistory.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " suh_StartDate='" + this.suh_StartDate.GetDateToStr("yyyy-MM-dd 00:00:00") + "',suh_EndDate='" + this.suh_EndDate.GetDateToStr("yyyy-MM-dd 23:59:59") + "'" + string.Format(",{0}={1},{2}={3}", (object) "suh_PayMethod", (object) this.suh_PayMethod, (object) "suh_PayCondition", (object) this.suh_PayCondition) + string.Format(",{0}={1},{2}={3}", (object) "suh_ModDate", (object) this.suh_ModDate.GetDateToStrInNull(), (object) "suh_ModUser", (object) this.suh_ModUser) + string.Format(" WHERE {0}={1}", (object) "suh_ID", (object) this.suh_ID) + string.Format(" AND {0}={1}", (object) "suh_SiteID", (object) this.suh_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.suh_ID, (object) this.suh_SiteID, (object) this.suh_Supplier, (object) this.suh_StoreCode) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TSupplierHistory tsupplierHistory = this;
      // ISSUE: reference to a compiler-generated method
      tsupplierHistory.\u003C\u003En__1();
      if (await tsupplierHistory.OleDB.ExecuteAsync(tsupplierHistory.UpdateQuery()))
        return true;
      tsupplierHistory.message = " " + tsupplierHistory.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tsupplierHistory.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tsupplierHistory.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tsupplierHistory.suh_ID, (object) tsupplierHistory.suh_SiteID, (object) tsupplierHistory.suh_Supplier, (object) tsupplierHistory.suh_StoreCode) + " 내용 : " + tsupplierHistory.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tsupplierHistory.message);
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
      stringBuilder.Append(" suh_StartDate='" + this.suh_StartDate.GetDateToStr("yyyy-MM-dd 00:00:00") + "',suh_EndDate='" + this.suh_EndDate.GetDateToStr("yyyy-MM-dd 23:59:59") + "'" + string.Format(",{0}={1},{2}={3}", (object) "suh_PayMethod", (object) this.suh_PayMethod, (object) "suh_PayCondition", (object) this.suh_PayCondition) + string.Format(",{0}={1},{2}={3}", (object) "suh_ModDate", (object) this.suh_ModDate.GetDateToStrInNull(), (object) "suh_ModUser", (object) this.suh_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.suh_ID, (object) this.suh_SiteID, (object) this.suh_Supplier, (object) this.suh_StoreCode) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TSupplierHistory tsupplierHistory = this;
      // ISSUE: reference to a compiler-generated method
      tsupplierHistory.\u003C\u003En__1();
      if (await tsupplierHistory.OleDB.ExecuteAsync(tsupplierHistory.UpdateExInsertQuery()))
        return true;
      tsupplierHistory.message = " " + tsupplierHistory.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tsupplierHistory.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tsupplierHistory.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tsupplierHistory.suh_ID, (object) tsupplierHistory.suh_SiteID, (object) tsupplierHistory.suh_Supplier, (object) tsupplierHistory.suh_StoreCode) + " 내용 : " + tsupplierHistory.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tsupplierHistory.message);
      return false;
    }

    public override string DeleteQuery() => string.Format(" DELETE FROM {0}{1}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + string.Format(" WHERE {0}={1}", (object) "suh_ID", (object) this.suh_ID) + string.Format(" AND {0}={1}", (object) "suh_SiteID", (object) this.suh_SiteID);

    public override bool Delete()
    {
      this.InsertChecked();
      string pStrExec = this.DeleteQuery();
      if (this.OleDB.Execute(pStrExec))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 삭제 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.suh_ID, (object) this.suh_SiteID, (object) this.suh_Supplier, (object) this.suh_StoreCode) + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n 쿼리 : " + pStrExec + "\n--------------------------------------------------------------------------------------------------\n";
      return false;
    }

    public override async Task<bool> DeleteAsync()
    {
      TSupplierHistory tsupplierHistory = this;
      // ISSUE: reference to a compiler-generated method
      tsupplierHistory.\u003C\u003En__0();
      if (await tsupplierHistory.OleDB.ExecuteAsync(tsupplierHistory.DeleteQuery()))
        return true;
      tsupplierHistory.message = " " + tsupplierHistory.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tsupplierHistory.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tsupplierHistory.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tsupplierHistory.suh_ID, (object) tsupplierHistory.suh_SiteID, (object) tsupplierHistory.suh_Supplier, (object) tsupplierHistory.suh_StoreCode) + " 내용 : " + tsupplierHistory.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tsupplierHistory.message);
      return false;
    }

    public virtual string DeleteQuery(int p_suh_ID, long p_suh_SiteID = 0)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format(" DELETE FROM {0}{1} ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode));
      stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "suh_ID", (object) p_suh_ID));
      if (p_suh_SiteID > 0L)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "suh_SiteID", (object) p_suh_SiteID));
      return stringBuilder.ToString();
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "suh_SiteID") && Convert.ToInt64(hashtable[(object) "suh_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "suh_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "suh_ID") && Convert.ToInt32(hashtable[(object) "suh_ID"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "suh_ID", hashtable[(object) "suh_ID"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "suh_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "suh_Supplier") && Convert.ToInt32(hashtable[(object) "suh_Supplier"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "suh_Supplier", hashtable[(object) "suh_Supplier"]));
        else if (hashtable.ContainsKey((object) "_SUPPLIER_AUTHS_") && hashtable[(object) "_SUPPLIER_AUTHS_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "suh_Supplier", hashtable[(object) "_SUPPLIER_AUTHS_"]));
        if (hashtable.ContainsKey((object) "suh_StoreCode") && Convert.ToInt32(hashtable[(object) "suh_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "suh_StoreCode", hashtable[(object) "suh_StoreCode"]));
        else if (hashtable.ContainsKey((object) "suh_StoreCode_IN_") && hashtable[(object) "suh_StoreCode_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "suh_StoreCode", hashtable[(object) "suh_StoreCode_IN_"]));
        else if (hashtable.ContainsKey((object) "_STORE_AUTHS_") && hashtable[(object) "_STORE_AUTHS_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "suh_StoreCode", hashtable[(object) "_STORE_AUTHS_"]));
        if (hashtable.ContainsKey((object) "_DT_DATE_"))
        {
          stringBuilder.Append(" AND suh_StartDate >='" + new DateTime?((DateTime) hashtable[(object) "_DT_DATE_"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND suh_EndDate <='" + new DateTime?((DateTime) hashtable[(object) "_DT_DATE_"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
        }
        if (hashtable.ContainsKey((object) "_DT_START_DATE_") && hashtable.ContainsKey((object) "_DT_END_DATE_"))
        {
          string dateToStr1 = new DateTime?((DateTime) hashtable[(object) "_DT_START_DATE_"]).GetDateToStr("yyyy-MM-dd 00:00:00");
          string dateToStr2 = new DateTime?((DateTime) hashtable[(object) "_DT_START_DATE_"]).GetDateToStr("yyyy-MM-dd 23:59:59");
          string dateToStr3 = new DateTime?((DateTime) hashtable[(object) "_DT_END_DATE_"]).GetDateToStr("yyyy-MM-dd 00:00:00");
          string dateToStr4 = new DateTime?((DateTime) hashtable[(object) "_DT_END_DATE_"]).GetDateToStr("yyyy-MM-dd 23:59:59");
          stringBuilder.Append(" AND (");
          stringBuilder.Append(" (suh_StartDate <= '" + dateToStr1 + "' AND suh_EndDate >= '" + dateToStr2 + "' )");
          stringBuilder.Append(" OR (suh_StartDate <= '" + dateToStr3 + "' AND suh_EndDate >= '" + dateToStr4 + "' )");
          stringBuilder.Append(" OR (suh_StartDate >= '" + dateToStr1 + "' AND suh_EndDate <= '" + dateToStr4 + "' )");
          stringBuilder.Append(") ");
        }
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
        stringBuilder.Append(" SELECT  suh_ID,suh_SiteID,suh_Supplier,suh_StoreCode,suh_StartDate,suh_EndDate,suh_PayMethod,suh_PayCondition,suh_InDate,suh_InUser,suh_ModDate,suh_ModUser");
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
