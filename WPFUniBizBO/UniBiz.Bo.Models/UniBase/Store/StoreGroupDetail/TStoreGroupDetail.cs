// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Store.StoreGroupDetail.TStoreGroupDetail
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

namespace UniBiz.Bo.Models.UniBase.Store.StoreGroupDetail
{
  public class TStoreGroupDetail : UbModelBase<TStoreGroupDetail>
  {
    private int _sgd_GroupCode;
    private int _sgd_StoreCode;
    private long _sgd_SiteID;
    private int _sgd_SortNo;
    private DateTime? _sgd_InDate;
    private int _sgd_InUser;
    private DateTime? _sgd_ModDate;
    private int _sgd_ModUser;

    public override object _Key => (object) new object[2]
    {
      (object) this.sgd_GroupCode,
      (object) this.sgd_StoreCode
    };

    public int sgd_GroupCode
    {
      get => this._sgd_GroupCode;
      set
      {
        this._sgd_GroupCode = value;
        this.Changed(nameof (sgd_GroupCode));
      }
    }

    public int sgd_StoreCode
    {
      get => this._sgd_StoreCode;
      set
      {
        this._sgd_StoreCode = value;
        this.Changed(nameof (sgd_StoreCode));
      }
    }

    public long sgd_SiteID
    {
      get => this._sgd_SiteID;
      set
      {
        this._sgd_SiteID = value;
        this.Changed(nameof (sgd_SiteID));
      }
    }

    public int sgd_SortNo
    {
      get => this._sgd_SortNo;
      set
      {
        this._sgd_SortNo = value;
        this.Changed(nameof (sgd_SortNo));
      }
    }

    public DateTime? sgd_InDate
    {
      get => this._sgd_InDate;
      set
      {
        this._sgd_InDate = value;
        this.Changed(nameof (sgd_InDate));
      }
    }

    public int sgd_InUser
    {
      get => this._sgd_InUser;
      set
      {
        this._sgd_InUser = value;
        this.Changed(nameof (sgd_InUser));
      }
    }

    public DateTime? sgd_ModDate
    {
      get => this._sgd_ModDate;
      set
      {
        this._sgd_ModDate = value;
        this.Changed(nameof (sgd_ModDate));
      }
    }

    public int sgd_ModUser
    {
      get => this._sgd_ModUser;
      set
      {
        this._sgd_ModUser = value;
        this.Changed(nameof (sgd_ModUser));
      }
    }

    public TStoreGroupDetail() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("sgd_GroupCode", new TTableColumn()
      {
        tc_orgin_name = "sgd_GroupCode",
        tc_trans_name = "지점그룹 코드"
      });
      columnInfo.Add("sgd_StoreCode", new TTableColumn()
      {
        tc_orgin_name = "sgd_StoreCode",
        tc_trans_name = "지점코드"
      });
      columnInfo.Add("sgd_SiteID", new TTableColumn()
      {
        tc_orgin_name = "sgd_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("sgd_SortNo", new TTableColumn()
      {
        tc_orgin_name = "sgd_SortNo",
        tc_trans_name = "순서"
      });
      columnInfo.Add("sgd_InDate", new TTableColumn()
      {
        tc_orgin_name = "sgd_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("sgd_InUser", new TTableColumn()
      {
        tc_orgin_name = "sgd_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("sgd_ModDate", new TTableColumn()
      {
        tc_orgin_name = "sgd_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("sgd_ModUser", new TTableColumn()
      {
        tc_orgin_name = "sgd_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.StoreGroupDetail;
      this.sgd_GroupCode = this.sgd_StoreCode = 0;
      this.sgd_SiteID = 0L;
      this.sgd_SortNo = 0;
      this.sgd_InDate = new DateTime?();
      this.sgd_ModDate = new DateTime?();
      this.sgd_InUser = this.sgd_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TStoreGroupDetail();

    public override object Clone()
    {
      TStoreGroupDetail tstoreGroupDetail = base.Clone() as TStoreGroupDetail;
      tstoreGroupDetail.sgd_GroupCode = this.sgd_GroupCode;
      tstoreGroupDetail.sgd_StoreCode = this.sgd_StoreCode;
      tstoreGroupDetail.sgd_SiteID = this.sgd_SiteID;
      tstoreGroupDetail.sgd_SortNo = this.sgd_SortNo;
      tstoreGroupDetail.sgd_InDate = this.sgd_InDate;
      tstoreGroupDetail.sgd_ModDate = this.sgd_ModDate;
      tstoreGroupDetail.sgd_InUser = this.sgd_InUser;
      tstoreGroupDetail.sgd_ModUser = this.sgd_ModUser;
      return (object) tstoreGroupDetail;
    }

    public void PutData(TStoreGroupDetail pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.sgd_GroupCode = pSource.sgd_GroupCode;
      this.sgd_StoreCode = pSource.sgd_StoreCode;
      this.sgd_SiteID = pSource.sgd_SiteID;
      this.sgd_SortNo = pSource.sgd_SortNo;
      this.sgd_InDate = pSource.sgd_InDate;
      this.sgd_ModDate = pSource.sgd_ModDate;
      this.sgd_InUser = pSource.sgd_InUser;
      this.sgd_ModUser = pSource.sgd_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.sgd_GroupCode = p_rs.GetFieldInt("sgd_GroupCode");
        if (this.sgd_GroupCode == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.sgd_StoreCode = p_rs.GetFieldInt("sgd_StoreCode");
        this.sgd_SiteID = p_rs.GetFieldLong("sgd_SiteID");
        this.sgd_SortNo = p_rs.GetFieldInt("sgd_SortNo");
        this.sgd_InDate = p_rs.GetFieldDateTime("sgd_InDate");
        this.sgd_InUser = p_rs.GetFieldInt("sgd_InUser");
        this.sgd_ModDate = p_rs.GetFieldDateTime("sgd_ModDate");
        this.sgd_ModUser = p_rs.GetFieldInt("sgd_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " sgd_GroupCode,sgd_StoreCode,sgd_SiteID,sgd_SortNo,sgd_InDate,sgd_InUser,sgd_ModDate,sgd_ModUser) VALUES ( " + string.Format(" {0},{1}", (object) this.sgd_GroupCode, (object) this.sgd_StoreCode) + string.Format(",{0},{1}", (object) this.sgd_SiteID, (object) this.sgd_SortNo) + string.Format(",{0},{1}", (object) this.sgd_InDate.GetDateToStrInNull(), (object) this.sgd_InUser) + string.Format(",{0},{1}", (object) this.sgd_ModDate.GetDateToStrInNull(), (object) this.sgd_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.sgd_GroupCode, (object) this.sgd_GroupCode) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TStoreGroupDetail tstoreGroupDetail = this;
      // ISSUE: reference to a compiler-generated method
      tstoreGroupDetail.\u003C\u003En__0();
      if (await tstoreGroupDetail.OleDB.ExecuteAsync(tstoreGroupDetail.InsertQuery()))
        return true;
      tstoreGroupDetail.message = " " + tstoreGroupDetail.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tstoreGroupDetail.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tstoreGroupDetail.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tstoreGroupDetail.sgd_GroupCode, (object) tstoreGroupDetail.sgd_GroupCode) + " 내용 : " + tstoreGroupDetail.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tstoreGroupDetail.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + string.Format(" {0}={1}", (object) "sgd_SortNo", (object) this.sgd_SortNo) + string.Format(",{0}={1},{2}={3}", (object) "sgd_ModDate", (object) this.sgd_ModDate.GetDateToStrInNull(), (object) "sgd_ModUser", (object) this.sgd_ModUser) + string.Format(" WHERE {0}={1}", (object) "sgd_GroupCode", (object) this.sgd_GroupCode) + string.Format(" AND {0}={1}", (object) "sgd_StoreCode", (object) this.sgd_StoreCode);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.sgd_GroupCode, (object) this.sgd_StoreCode) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TStoreGroupDetail tstoreGroupDetail = this;
      // ISSUE: reference to a compiler-generated method
      tstoreGroupDetail.\u003C\u003En__1();
      if (await tstoreGroupDetail.OleDB.ExecuteAsync(tstoreGroupDetail.UpdateQuery()))
        return true;
      tstoreGroupDetail.message = " " + tstoreGroupDetail.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tstoreGroupDetail.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tstoreGroupDetail.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tstoreGroupDetail.sgd_GroupCode, (object) tstoreGroupDetail.sgd_GroupCode) + " 내용 : " + tstoreGroupDetail.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tstoreGroupDetail.message);
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
      stringBuilder.Append(string.Format(" {0}={1}", (object) "sgd_SortNo", (object) this.sgd_SortNo) + string.Format(",{0}={1},{2}={3}", (object) "sgd_ModDate", (object) this.sgd_ModDate.GetDateToStrInNull(), (object) "sgd_ModUser", (object) this.sgd_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.sgd_GroupCode, (object) this.sgd_GroupCode) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TStoreGroupDetail tstoreGroupDetail = this;
      // ISSUE: reference to a compiler-generated method
      tstoreGroupDetail.\u003C\u003En__1();
      if (await tstoreGroupDetail.OleDB.ExecuteAsync(tstoreGroupDetail.UpdateExInsertQuery()))
        return true;
      tstoreGroupDetail.message = " " + tstoreGroupDetail.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tstoreGroupDetail.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tstoreGroupDetail.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tstoreGroupDetail.sgd_GroupCode, (object) tstoreGroupDetail.sgd_GroupCode) + " 내용 : " + tstoreGroupDetail.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tstoreGroupDetail.message);
      return false;
    }

    public override string DeleteQuery() => string.Format(" DELETE FROM {0}{1}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + string.Format(" WHERE {0}={1}", (object) "sgd_GroupCode", (object) this.sgd_GroupCode) + string.Format(" AND {0}={1}", (object) "sgd_StoreCode", (object) this.sgd_StoreCode);

    public override bool Delete()
    {
      this.InsertChecked();
      string pStrExec = this.DeleteQuery();
      if (this.OleDB.Execute(pStrExec))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 삭제 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 코드 : ({0},{1})\n", (object) this.sgd_GroupCode, (object) this.sgd_StoreCode) + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n 쿼리 : " + pStrExec + "\n--------------------------------------------------------------------------------------------------\n";
      return false;
    }

    public override async Task<bool> DeleteAsync()
    {
      TStoreGroupDetail tstoreGroupDetail = this;
      // ISSUE: reference to a compiler-generated method
      tstoreGroupDetail.\u003C\u003En__0();
      if (await tstoreGroupDetail.OleDB.ExecuteAsync(tstoreGroupDetail.DeleteQuery()))
        return true;
      tstoreGroupDetail.message = " " + tstoreGroupDetail.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tstoreGroupDetail.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tstoreGroupDetail.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tstoreGroupDetail.sgd_GroupCode, (object) tstoreGroupDetail.sgd_StoreCode) + " 내용 : " + tstoreGroupDetail.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tstoreGroupDetail.message);
      return false;
    }

    public virtual string DeleteQuery(int p_sgd_GroupCode, int p_sgd_StoreCode, long p_sgd_SiteID = 0)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format(" DELETE FROM {0}{1} ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode));
      stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "sgd_GroupCode", (object) p_sgd_GroupCode));
      stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sgd_StoreCode", (object) p_sgd_StoreCode));
      if (p_sgd_SiteID > 0L)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sgd_SiteID", (object) p_sgd_SiteID));
      return stringBuilder.ToString();
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "sgd_SiteID") && Convert.ToInt64(hashtable[(object) "sgd_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "sgd_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "sgd_GroupCode") && Convert.ToInt32(hashtable[(object) "sgd_GroupCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sgd_GroupCode", hashtable[(object) "sgd_GroupCode"]));
        if (hashtable.ContainsKey((object) "sgd_StoreCode") && Convert.ToInt32(hashtable[(object) "sgd_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sgd_StoreCode", hashtable[(object) "sgd_StoreCode"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sgd_SiteID", (object) num));
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
        stringBuilder.Append(" SELECT  sgd_GroupCode,sgd_StoreCode,sgd_SiteID,sgd_SortNo,sgd_InDate,sgd_InUser,sgd_ModDate,sgd_ModUser");
        stringBuilder.Append(" FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock());
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
