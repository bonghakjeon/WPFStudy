// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsOldBarcode.TGoodsOldBarcode
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

namespace UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsOldBarcode
{
  public class TGoodsOldBarcode : UbModelBase<TGoodsOldBarcode>
  {
    private long _gdob_GoodsCode;
    private string _gdob_BarCode;
    private long _gdob_SiteID;
    private int _gdob_AddProperty;
    private DateTime? _gdob_InDate;
    private int _gdob_InUser;
    private DateTime? _gdob_ModDate;
    private int _gdob_ModUser;

    public override object _Key => (object) new object[2]
    {
      (object) this.gdob_GoodsCode,
      (object) this.gdob_BarCode
    };

    public long gdob_GoodsCode
    {
      get => this._gdob_GoodsCode;
      set
      {
        this._gdob_GoodsCode = value;
        this.Changed(nameof (gdob_GoodsCode));
      }
    }

    public string gdob_BarCode
    {
      get => this._gdob_BarCode;
      set
      {
        this._gdob_BarCode = UbModelBase.LeftStr(value, 40).Replace("'", "´");
        this.Changed(nameof (gdob_BarCode));
      }
    }

    public long gdob_SiteID
    {
      get => this._gdob_SiteID;
      set
      {
        this._gdob_SiteID = value;
        this.Changed(nameof (gdob_SiteID));
      }
    }

    public int gdob_AddProperty
    {
      get => this._gdob_AddProperty;
      set
      {
        this._gdob_AddProperty = value;
        this.Changed(nameof (gdob_AddProperty));
      }
    }

    public DateTime? gdob_InDate
    {
      get => this._gdob_InDate;
      set
      {
        this._gdob_InDate = value;
        this.Changed(nameof (gdob_InDate));
      }
    }

    public int gdob_InUser
    {
      get => this._gdob_InUser;
      set
      {
        this._gdob_InUser = value;
        this.Changed(nameof (gdob_InUser));
      }
    }

    public DateTime? gdob_ModDate
    {
      get => this._gdob_ModDate;
      set
      {
        this._gdob_ModDate = value;
        this.Changed(nameof (gdob_ModDate));
      }
    }

    public int gdob_ModUser
    {
      get => this._gdob_ModUser;
      set
      {
        this._gdob_ModUser = value;
        this.Changed(nameof (gdob_ModUser));
      }
    }

    public TGoodsOldBarcode() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("gdob_GoodsCode", new TTableColumn()
      {
        tc_orgin_name = "gdob_GoodsCode",
        tc_trans_name = "지점코드"
      });
      columnInfo.Add("gdob_BarCode", new TTableColumn()
      {
        tc_orgin_name = "gdob_BarCode",
        tc_trans_name = "구 바코드"
      });
      columnInfo.Add("gdob_SiteID", new TTableColumn()
      {
        tc_orgin_name = "gdob_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("gdob_AddProperty", new TTableColumn()
      {
        tc_orgin_name = "gdob_AddProperty",
        tc_trans_name = "속성타입"
      });
      columnInfo.Add("gdob_InDate", new TTableColumn()
      {
        tc_orgin_name = "gdob_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("gdob_InUser", new TTableColumn()
      {
        tc_orgin_name = "gdob_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("gdob_ModDate", new TTableColumn()
      {
        tc_orgin_name = "gdob_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("gdob_ModUser", new TTableColumn()
      {
        tc_orgin_name = "gdob_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.GoodsOldBarcode;
      this.gdob_GoodsCode = 0L;
      this.gdob_BarCode = string.Empty;
      this.gdob_SiteID = 0L;
      this.gdob_AddProperty = 0;
      this.gdob_InDate = new DateTime?();
      this.gdob_InUser = 0;
      this.gdob_ModDate = new DateTime?();
      this.gdob_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TGoodsOldBarcode();

    public override object Clone()
    {
      TGoodsOldBarcode tgoodsOldBarcode = base.Clone() as TGoodsOldBarcode;
      tgoodsOldBarcode.gdob_GoodsCode = this.gdob_GoodsCode;
      tgoodsOldBarcode.gdob_BarCode = this.gdob_BarCode;
      tgoodsOldBarcode.gdob_SiteID = this.gdob_SiteID;
      tgoodsOldBarcode.gdob_AddProperty = this.gdob_AddProperty;
      tgoodsOldBarcode.gdob_InDate = this.gdob_InDate;
      tgoodsOldBarcode.gdob_InUser = this.gdob_InUser;
      tgoodsOldBarcode.gdob_ModDate = this.gdob_ModDate;
      tgoodsOldBarcode.gdob_ModUser = this.gdob_ModUser;
      return (object) tgoodsOldBarcode;
    }

    public void PutData(TGoodsOldBarcode pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.gdob_GoodsCode = pSource.gdob_GoodsCode;
      this.gdob_BarCode = pSource.gdob_BarCode;
      this.gdob_SiteID = pSource.gdob_SiteID;
      this.gdob_AddProperty = pSource.gdob_AddProperty;
      this.gdob_InDate = pSource.gdob_InDate;
      this.gdob_InUser = pSource.gdob_InUser;
      this.gdob_ModDate = pSource.gdob_ModDate;
      this.gdob_ModUser = pSource.gdob_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.gdob_GoodsCode = p_rs.GetFieldLong("gdob_GoodsCode");
        if (this.gdob_GoodsCode == 0L)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.gdob_BarCode = p_rs.GetFieldString("gdob_BarCode");
        this.gdob_SiteID = p_rs.GetFieldLong("gdob_SiteID");
        this.gdob_AddProperty = p_rs.GetFieldInt("gdob_AddProperty");
        this.gdob_InDate = p_rs.GetFieldDateTime("gdob_InDate");
        this.gdob_InUser = p_rs.GetFieldInt("gdob_InUser");
        this.gdob_ModDate = p_rs.GetFieldDateTime("gdob_ModDate");
        this.gdob_ModUser = p_rs.GetFieldInt("gdob_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " gdob_GoodsCode,gdob_BarCode,gdob_SiteID,gdob_AddProperty,gdob_InDate,gdob_InUser,gdob_ModDate,gdob_ModUser) VALUES ( " + string.Format(" {0},'{1}'", (object) this.gdob_GoodsCode, (object) this.gdob_BarCode) + string.Format(",{0}", (object) this.gdob_SiteID) + string.Format(",{0}", (object) this.gdob_AddProperty) + string.Format(",{0},{1}", (object) this.gdob_InDate.GetDateToStrInNull(), (object) this.gdob_InUser) + string.Format(",{0},{1}", (object) this.gdob_ModDate.GetDateToStrInNull(), (object) this.gdob_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.gdob_GoodsCode, (object) this.gdob_BarCode, (object) this.gdob_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TGoodsOldBarcode tgoodsOldBarcode = this;
      // ISSUE: reference to a compiler-generated method
      tgoodsOldBarcode.\u003C\u003En__0();
      if (await tgoodsOldBarcode.OleDB.ExecuteAsync(tgoodsOldBarcode.InsertQuery()))
        return true;
      tgoodsOldBarcode.message = " " + tgoodsOldBarcode.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tgoodsOldBarcode.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tgoodsOldBarcode.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tgoodsOldBarcode.gdob_GoodsCode, (object) tgoodsOldBarcode.gdob_BarCode, (object) tgoodsOldBarcode.gdob_SiteID) + " 내용 : " + tgoodsOldBarcode.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tgoodsOldBarcode.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + string.Format(" {0}={1}", (object) "gdob_AddProperty", (object) this.gdob_AddProperty) + string.Format(",{0}={1},{2}={3}", (object) "gdob_ModDate", (object) this.gdob_ModDate.GetDateToStrInNull(), (object) "gdob_ModUser", (object) this.gdob_ModUser) + string.Format(" WHERE {0}={1}", (object) "gdob_GoodsCode", (object) this.gdob_GoodsCode) + " AND gdob_BarCode='" + this.gdob_BarCode + "'" + string.Format(" AND {0}={1}", (object) "gdob_SiteID", (object) this.gdob_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.gdob_GoodsCode, (object) this.gdob_BarCode, (object) this.gdob_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TGoodsOldBarcode tgoodsOldBarcode = this;
      // ISSUE: reference to a compiler-generated method
      tgoodsOldBarcode.\u003C\u003En__1();
      if (await tgoodsOldBarcode.OleDB.ExecuteAsync(tgoodsOldBarcode.UpdateQuery()))
        return true;
      tgoodsOldBarcode.message = " " + tgoodsOldBarcode.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tgoodsOldBarcode.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tgoodsOldBarcode.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tgoodsOldBarcode.gdob_GoodsCode, (object) tgoodsOldBarcode.gdob_BarCode, (object) tgoodsOldBarcode.gdob_SiteID) + " 내용 : " + tgoodsOldBarcode.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tgoodsOldBarcode.message);
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
      stringBuilder.Append(string.Format(" {0}={1}", (object) "gdob_AddProperty", (object) this.gdob_AddProperty) + string.Format(",{0}={1},{2}={3}", (object) "gdob_ModDate", (object) this.gdob_ModDate.GetDateToStrInNull(), (object) "gdob_ModUser", (object) this.gdob_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.gdob_GoodsCode, (object) this.gdob_BarCode, (object) this.gdob_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TGoodsOldBarcode tgoodsOldBarcode = this;
      // ISSUE: reference to a compiler-generated method
      tgoodsOldBarcode.\u003C\u003En__1();
      if (await tgoodsOldBarcode.OleDB.ExecuteAsync(tgoodsOldBarcode.UpdateExInsertQuery()))
        return true;
      tgoodsOldBarcode.message = " " + tgoodsOldBarcode.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tgoodsOldBarcode.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tgoodsOldBarcode.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tgoodsOldBarcode.gdob_GoodsCode, (object) tgoodsOldBarcode.gdob_BarCode, (object) tgoodsOldBarcode.gdob_SiteID) + " 내용 : " + tgoodsOldBarcode.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tgoodsOldBarcode.message);
      return false;
    }

    public override string DeleteQuery() => string.Format(" DELETE FROM {0}{1}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + string.Format(" WHERE {0}={1}", (object) "gdob_GoodsCode", (object) this.gdob_GoodsCode) + " AND gdob_BarCode='" + this.gdob_BarCode + "'" + string.Format(" AND {0}={1}", (object) "gdob_SiteID", (object) this.gdob_SiteID);

    public override bool Delete()
    {
      this.InsertChecked();
      string pStrExec = this.DeleteQuery();
      if (this.OleDB.Execute(pStrExec))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 삭제 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.gdob_GoodsCode, (object) this.gdob_BarCode, (object) this.gdob_SiteID) + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n 쿼리 : " + pStrExec + "\n--------------------------------------------------------------------------------------------------\n";
      return false;
    }

    public override async Task<bool> DeleteAsync()
    {
      TGoodsOldBarcode tgoodsOldBarcode = this;
      // ISSUE: reference to a compiler-generated method
      tgoodsOldBarcode.\u003C\u003En__0();
      if (await tgoodsOldBarcode.OleDB.ExecuteAsync(tgoodsOldBarcode.DeleteQuery()))
        return true;
      tgoodsOldBarcode.message = " " + tgoodsOldBarcode.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tgoodsOldBarcode.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tgoodsOldBarcode.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tgoodsOldBarcode.gdob_GoodsCode, (object) tgoodsOldBarcode.gdob_BarCode, (object) tgoodsOldBarcode.gdob_SiteID) + " 내용 : " + tgoodsOldBarcode.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tgoodsOldBarcode.message);
      return false;
    }

    public virtual string DeleteQuery(
      long p_gdob_GoodsCode,
      string p_gdob_BarCode,
      long p_gdob_SiteID = 0)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format(" DELETE FROM {0}{1} ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode));
      stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "gdob_GoodsCode", (object) p_gdob_GoodsCode));
      stringBuilder.Append(" AND gdob_BarCode='" + p_gdob_BarCode + "'");
      if (p_gdob_SiteID > 0L)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gdob_SiteID", (object) p_gdob_SiteID));
      return stringBuilder.ToString();
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "gdob_SiteID") && Convert.ToInt64(hashtable[(object) "gdob_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "gdob_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "gdob_GoodsCode") && Convert.ToInt64(hashtable[(object) "gdob_GoodsCode"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gdob_GoodsCode", hashtable[(object) "gdob_GoodsCode"]));
        if (hashtable.ContainsKey((object) "gdob_BarCode") && hashtable[(object) "gdob_BarCode"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "gdob_BarCode", hashtable[(object) "gdob_BarCode"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gdob_SiteID", (object) num));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "gdob_BarCode", hashtable[(object) "_KEY_WORD_"]));
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
        string uniBase = UbModelBase.UNI_BASE;
        string str = this.TableCode.ToString();
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
        }
        stringBuilder.Append(" SELECT  gdob_GoodsCode,gdob_BarCode,gdob_SiteID,gdob_AddProperty,gdob_InDate,gdob_InUser,gdob_ModDate,gdob_ModUser");
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
