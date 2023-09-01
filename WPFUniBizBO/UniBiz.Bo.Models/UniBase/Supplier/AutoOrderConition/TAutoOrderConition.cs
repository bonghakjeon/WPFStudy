// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Supplier.AutoOrderConition.TAutoOrderConition
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

namespace UniBiz.Bo.Models.UniBase.Supplier.AutoOrderConition
{
  public class TAutoOrderConition : UbModelBase<TAutoOrderConition>
  {
    private int _aoc_ID;
    private long _aoc_SiteID;
    private int _aoc_Supplier;
    private int _aoc_StoreCode;
    private int _aoc_CategoryCodeTop;
    private int _aoc_DayofWeek;
    private int _aoc_LeadTime;
    private int _aoc_OrderCycle;
    private int _aoc_StatementSeqType;
    private int _aoc_AddProperty;
    private DateTime? _aoc_InDate;
    private int _aoc_InUser;
    private DateTime? _aoc_ModDate;
    private int _aoc_ModUser;

    public override object _Key => (object) new object[1]
    {
      (object) this.aoc_ID
    };

    public int aoc_ID
    {
      get => this._aoc_ID;
      set
      {
        this._aoc_ID = value;
        this.Changed(nameof (aoc_ID));
      }
    }

    public long aoc_SiteID
    {
      get => this._aoc_SiteID;
      set
      {
        this._aoc_SiteID = value;
        this.Changed(nameof (aoc_SiteID));
      }
    }

    public int aoc_Supplier
    {
      get => this._aoc_Supplier;
      set
      {
        this._aoc_Supplier = value;
        this.Changed(nameof (aoc_Supplier));
      }
    }

    public int aoc_StoreCode
    {
      get => this._aoc_StoreCode;
      set
      {
        this._aoc_StoreCode = value;
        this.Changed(nameof (aoc_StoreCode));
      }
    }

    public int aoc_CategoryCodeTop
    {
      get => this._aoc_CategoryCodeTop;
      set
      {
        this._aoc_CategoryCodeTop = value;
        this.Changed(nameof (aoc_CategoryCodeTop));
      }
    }

    public int aoc_DayofWeek
    {
      get => this._aoc_DayofWeek;
      set
      {
        this._aoc_DayofWeek = value;
        this.Changed(nameof (aoc_DayofWeek));
      }
    }

    public int aoc_LeadTime
    {
      get => this._aoc_LeadTime;
      set
      {
        this._aoc_LeadTime = value;
        this.Changed(nameof (aoc_LeadTime));
        this.Changed("aoc_LeadTimeDesc");
      }
    }

    public string aoc_LeadTimeDesc => this.aoc_LeadTime <= 0 ? string.Empty : Enum2StrConverter.ToCommonCodeTypeMemo(this.aoc_SiteID, EnumCommonCodeType.LeadTime, this.aoc_LeadTime);

    public int aoc_OrderCycle
    {
      get => this._aoc_OrderCycle;
      set
      {
        this._aoc_OrderCycle = value;
        this.Changed(nameof (aoc_OrderCycle));
        this.Changed("aoc_OrderCycleDesc");
      }
    }

    public string aoc_OrderCycleDesc => this.aoc_OrderCycle <= 0 ? string.Empty : Enum2StrConverter.ToCommonCodeTypeMemo(this.aoc_SiteID, EnumCommonCodeType.AutoOrderCycle, this.aoc_OrderCycle);

    public int aoc_StatementSeqType
    {
      get => this._aoc_StatementSeqType;
      set
      {
        this._aoc_StatementSeqType = value;
        this.Changed(nameof (aoc_StatementSeqType));
      }
    }

    public string aoc_StatementSeqTypeDesc => this.aoc_StatementSeqType <= 0 ? string.Empty : Enum2StrConverter.ToCommonCodeTypeMemo(this.aoc_SiteID, EnumCommonCodeType.AutoOrderInvoiceType, this.aoc_StatementSeqType);

    public int aoc_AddProperty
    {
      get => this._aoc_AddProperty;
      set
      {
        this._aoc_AddProperty = value;
        this.Changed(nameof (aoc_AddProperty));
      }
    }

    public DateTime? aoc_InDate
    {
      get => this._aoc_InDate;
      set
      {
        this._aoc_InDate = value;
        this.Changed(nameof (aoc_InDate));
      }
    }

    public int aoc_InUser
    {
      get => this._aoc_InUser;
      set
      {
        this._aoc_InUser = value;
        this.Changed(nameof (aoc_InUser));
      }
    }

    public DateTime? aoc_ModDate
    {
      get => this._aoc_ModDate;
      set
      {
        this._aoc_ModDate = value;
        this.Changed(nameof (aoc_ModDate));
      }
    }

    public int aoc_ModUser
    {
      get => this._aoc_ModUser;
      set
      {
        this._aoc_ModUser = value;
        this.Changed(nameof (aoc_ModUser));
      }
    }

    public TAutoOrderConition() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("aoc_ID", new TTableColumn()
      {
        tc_orgin_name = "aoc_ID",
        tc_trans_name = "자동발주ID"
      });
      columnInfo.Add("aoc_SiteID", new TTableColumn()
      {
        tc_orgin_name = "aoc_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("aoc_Supplier", new TTableColumn()
      {
        tc_orgin_name = "aoc_Supplier",
        tc_trans_name = "코드"
      });
      columnInfo.Add("aoc_StoreCode", new TTableColumn()
      {
        tc_orgin_name = "aoc_StoreCode",
        tc_trans_name = "지점코드"
      });
      columnInfo.Add("aoc_CategoryCodeTop", new TTableColumn()
      {
        tc_orgin_name = "aoc_CategoryCodeTop",
        tc_trans_name = "대분류코드"
      });
      columnInfo.Add("aoc_DayofWeek", new TTableColumn()
      {
        tc_orgin_name = "aoc_DayofWeek",
        tc_trans_name = "요일"
      });
      columnInfo.Add("aoc_LeadTime", new TTableColumn()
      {
        tc_orgin_name = "aoc_LeadTime",
        tc_trans_name = "리드타임",
        tc_comm_code = 110
      });
      columnInfo.Add("aoc_OrderCycle", new TTableColumn()
      {
        tc_orgin_name = "aoc_OrderCycle",
        tc_trans_name = "발주 주기일",
        tc_comm_code = 108
      });
      columnInfo.Add("aoc_StatementSeqType", new TTableColumn()
      {
        tc_orgin_name = "aoc_StatementSeqType",
        tc_trans_name = "전표 채번타입",
        tc_comm_code = 109
      });
      columnInfo.Add("aoc_AddProperty", new TTableColumn()
      {
        tc_orgin_name = "aoc_AddProperty",
        tc_trans_name = "속성타입"
      });
      columnInfo.Add("aoc_InDate", new TTableColumn()
      {
        tc_orgin_name = "aoc_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("aoc_InUser", new TTableColumn()
      {
        tc_orgin_name = "aoc_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("aoc_ModDate", new TTableColumn()
      {
        tc_orgin_name = "aoc_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("aoc_ModUser", new TTableColumn()
      {
        tc_orgin_name = "aoc_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.AutoOrderConition;
      this.aoc_ID = 0;
      this.aoc_SiteID = 0L;
      this.aoc_Supplier = this.aoc_StoreCode = this.aoc_CategoryCodeTop = this.aoc_DayofWeek = this.aoc_LeadTime = this.aoc_OrderCycle = this.aoc_StatementSeqType = 0;
      this.aoc_AddProperty = 0;
      this.aoc_InDate = new DateTime?();
      this.aoc_InUser = 0;
      this.aoc_ModDate = new DateTime?();
      this.aoc_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TAutoOrderConition();

    public override object Clone()
    {
      TAutoOrderConition tautoOrderConition = base.Clone() as TAutoOrderConition;
      tautoOrderConition.aoc_ID = this.aoc_ID;
      tautoOrderConition.aoc_SiteID = this.aoc_SiteID;
      tautoOrderConition.aoc_Supplier = this.aoc_Supplier;
      tautoOrderConition.aoc_StoreCode = this.aoc_StoreCode;
      tautoOrderConition.aoc_CategoryCodeTop = this.aoc_CategoryCodeTop;
      tautoOrderConition.aoc_DayofWeek = this.aoc_DayofWeek;
      tautoOrderConition.aoc_LeadTime = this.aoc_LeadTime;
      tautoOrderConition.aoc_OrderCycle = this.aoc_OrderCycle;
      tautoOrderConition.aoc_StatementSeqType = this.aoc_StatementSeqType;
      tautoOrderConition.aoc_AddProperty = this.aoc_AddProperty;
      tautoOrderConition.aoc_InDate = this.aoc_InDate;
      tautoOrderConition.aoc_InUser = this.aoc_InUser;
      tautoOrderConition.aoc_ModDate = this.aoc_ModDate;
      tautoOrderConition.aoc_ModUser = this.aoc_ModUser;
      return (object) tautoOrderConition;
    }

    public void PutData(TAutoOrderConition pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.aoc_ID = pSource.aoc_ID;
      this.aoc_SiteID = pSource.aoc_SiteID;
      this.aoc_Supplier = pSource.aoc_Supplier;
      this.aoc_StoreCode = pSource.aoc_StoreCode;
      this.aoc_CategoryCodeTop = pSource.aoc_CategoryCodeTop;
      this.aoc_DayofWeek = pSource.aoc_DayofWeek;
      this.aoc_LeadTime = pSource.aoc_LeadTime;
      this.aoc_OrderCycle = pSource.aoc_OrderCycle;
      this.aoc_StatementSeqType = pSource.aoc_StatementSeqType;
      this.aoc_AddProperty = pSource.aoc_AddProperty;
      this.aoc_InDate = pSource.aoc_InDate;
      this.aoc_InUser = pSource.aoc_InUser;
      this.aoc_ModDate = pSource.aoc_ModDate;
      this.aoc_ModUser = pSource.aoc_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.aoc_ID = p_rs.GetFieldInt("aoc_ID");
        if (this.aoc_ID == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.aoc_SiteID = p_rs.GetFieldLong("aoc_SiteID");
        this.aoc_Supplier = p_rs.GetFieldInt("aoc_Supplier");
        this.aoc_StoreCode = p_rs.GetFieldInt("aoc_StoreCode");
        this.aoc_CategoryCodeTop = p_rs.GetFieldInt("aoc_CategoryCodeTop");
        this.aoc_DayofWeek = p_rs.GetFieldInt("aoc_DayofWeek");
        this.aoc_LeadTime = p_rs.GetFieldInt("aoc_LeadTime");
        this.aoc_OrderCycle = p_rs.GetFieldInt("aoc_OrderCycle");
        this.aoc_StatementSeqType = p_rs.GetFieldInt("aoc_StatementSeqType");
        this.aoc_InDate = p_rs.GetFieldDateTime("aoc_InDate");
        this.aoc_InUser = p_rs.GetFieldInt("aoc_InUser");
        this.aoc_ModDate = p_rs.GetFieldDateTime("aoc_ModDate");
        this.aoc_ModUser = p_rs.GetFieldInt("aoc_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " aoc_ID,aoc_SiteID,aoc_Supplier,aoc_StoreCode,aoc_CategoryCodeTop,aoc_DayofWeek,aoc_LeadTime,aoc_OrderCycle,aoc_StatementSeqType,aoc_AddProperty,aoc_InDate,aoc_InUser,aoc_ModDate,aoc_ModUser) VALUES ( " + string.Format(" {0}", (object) this.aoc_ID) + string.Format(",{0}", (object) this.aoc_SiteID) + string.Format(",{0},{1}", (object) this.aoc_Supplier, (object) this.aoc_StoreCode) + string.Format(",{0},{1},{2}", (object) this.aoc_CategoryCodeTop, (object) this.aoc_DayofWeek, (object) this.aoc_LeadTime) + string.Format(",{0},{1},{2}", (object) this.aoc_OrderCycle, (object) this.aoc_StatementSeqType, (object) this.aoc_AddProperty) + string.Format(",{0},{1}", (object) this.aoc_InDate.GetDateToStrInNull(), (object) this.aoc_InUser) + string.Format(",{0},{1}", (object) this.aoc_ModDate.GetDateToStrInNull(), (object) this.aoc_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.aoc_ID, (object) this.aoc_Supplier, (object) this.aoc_StoreCode, (object) this.aoc_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TAutoOrderConition tautoOrderConition = this;
      // ISSUE: reference to a compiler-generated method
      tautoOrderConition.\u003C\u003En__0();
      if (await tautoOrderConition.OleDB.ExecuteAsync(tautoOrderConition.InsertQuery()))
        return true;
      tautoOrderConition.message = " " + tautoOrderConition.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tautoOrderConition.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tautoOrderConition.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tautoOrderConition.aoc_ID, (object) tautoOrderConition.aoc_Supplier, (object) tautoOrderConition.aoc_StoreCode, (object) tautoOrderConition.aoc_SiteID) + " 내용 : " + tautoOrderConition.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tautoOrderConition.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + string.Format(" {0}={1},{2}={3}", (object) "aoc_CategoryCodeTop", (object) this.aoc_CategoryCodeTop, (object) "aoc_DayofWeek", (object) this.aoc_DayofWeek) + string.Format(",{0}={1}", (object) "aoc_LeadTime", (object) this.aoc_LeadTime) + string.Format(",{0}={1},{2}={3}", (object) "aoc_OrderCycle", (object) this.aoc_OrderCycle, (object) "aoc_StatementSeqType", (object) this.aoc_StatementSeqType) + string.Format(",{0}={1}", (object) "aoc_AddProperty", (object) this.aoc_AddProperty) + string.Format(",{0}={1},{2}={3}", (object) "aoc_ModDate", (object) this.aoc_ModDate.GetDateToStrInNull(), (object) "aoc_ModUser", (object) this.aoc_ModUser) + string.Format(" WHERE {0}={1}", (object) "aoc_ID", (object) this.aoc_ID) + string.Format(" AND {0}={1}", (object) "aoc_SiteID", (object) this.aoc_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.aoc_ID, (object) this.aoc_Supplier, (object) this.aoc_StoreCode, (object) this.aoc_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TAutoOrderConition tautoOrderConition = this;
      // ISSUE: reference to a compiler-generated method
      tautoOrderConition.\u003C\u003En__1();
      if (await tautoOrderConition.OleDB.ExecuteAsync(tautoOrderConition.UpdateQuery()))
        return true;
      tautoOrderConition.message = " " + tautoOrderConition.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tautoOrderConition.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tautoOrderConition.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tautoOrderConition.aoc_ID, (object) tautoOrderConition.aoc_Supplier, (object) tautoOrderConition.aoc_StoreCode, (object) tautoOrderConition.aoc_SiteID) + " 내용 : " + tautoOrderConition.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tautoOrderConition.message);
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
      stringBuilder.Append(string.Format(" {0}={1},{2}={3}", (object) "aoc_CategoryCodeTop", (object) this.aoc_CategoryCodeTop, (object) "aoc_DayofWeek", (object) this.aoc_DayofWeek) + string.Format(",{0}={1}", (object) "aoc_LeadTime", (object) this.aoc_LeadTime) + string.Format(",{0}={1},{2}={3}", (object) "aoc_OrderCycle", (object) this.aoc_OrderCycle, (object) "aoc_StatementSeqType", (object) this.aoc_StatementSeqType) + string.Format(",{0}={1}", (object) "aoc_AddProperty", (object) this.aoc_AddProperty) + string.Format(",{0}={1},{2}={3}", (object) "aoc_ModDate", (object) this.aoc_ModDate.GetDateToStrInNull(), (object) "aoc_ModUser", (object) this.aoc_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.aoc_ID, (object) this.aoc_Supplier, (object) this.aoc_StoreCode, (object) this.aoc_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TAutoOrderConition tautoOrderConition = this;
      // ISSUE: reference to a compiler-generated method
      tautoOrderConition.\u003C\u003En__1();
      if (await tautoOrderConition.OleDB.ExecuteAsync(tautoOrderConition.UpdateExInsertQuery()))
        return true;
      tautoOrderConition.message = " " + tautoOrderConition.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tautoOrderConition.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tautoOrderConition.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tautoOrderConition.aoc_ID, (object) tautoOrderConition.aoc_Supplier, (object) tautoOrderConition.aoc_StoreCode, (object) tautoOrderConition.aoc_SiteID) + " 내용 : " + tautoOrderConition.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tautoOrderConition.message);
      return false;
    }

    public override string DeleteQuery() => string.Format(" DELETE FROM {0}{1}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + string.Format(" WHERE {0}={1}", (object) "aoc_ID", (object) this.aoc_ID) + string.Format(" AND {0}={1}", (object) "aoc_SiteID", (object) this.aoc_SiteID);

    public override bool Delete()
    {
      this.InsertChecked();
      string pStrExec = this.DeleteQuery();
      if (this.OleDB.Execute(pStrExec))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 삭제 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.aoc_ID, (object) this.aoc_Supplier, (object) this.aoc_StoreCode, (object) this.aoc_SiteID) + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n 쿼리 : " + pStrExec + "\n--------------------------------------------------------------------------------------------------\n";
      return false;
    }

    public override async Task<bool> DeleteAsync()
    {
      TAutoOrderConition tautoOrderConition = this;
      // ISSUE: reference to a compiler-generated method
      tautoOrderConition.\u003C\u003En__0();
      if (await tautoOrderConition.OleDB.ExecuteAsync(tautoOrderConition.DeleteQuery()))
        return true;
      tautoOrderConition.message = " " + tautoOrderConition.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tautoOrderConition.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tautoOrderConition.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tautoOrderConition.aoc_ID, (object) tautoOrderConition.aoc_Supplier, (object) tautoOrderConition.aoc_StoreCode, (object) tautoOrderConition.aoc_SiteID) + " 내용 : " + tautoOrderConition.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tautoOrderConition.message);
      return false;
    }

    public virtual string DeleteQuery(int p_aoc_ID, long p_aoc_SiteID = 0)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format(" DELETE FROM {0}{1} ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode));
      stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "aoc_ID", (object) p_aoc_ID));
      if (p_aoc_SiteID > 0L)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "aoc_SiteID", (object) p_aoc_SiteID));
      return stringBuilder.ToString();
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "aoc_SiteID") && Convert.ToInt64(hashtable[(object) "aoc_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "aoc_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "aoc_ID") && Convert.ToInt32(hashtable[(object) "aoc_ID"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "aoc_ID", hashtable[(object) "aoc_ID"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "aoc_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "aoc_Supplier") && Convert.ToInt32(hashtable[(object) "aoc_Supplier"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "aoc_Supplier", hashtable[(object) "aoc_Supplier"]));
        else if (hashtable.ContainsKey((object) "aoc_Supplier_IN_") && hashtable[(object) "aoc_Supplier_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "aoc_Supplier", hashtable[(object) "aoc_Supplier_IN_"]));
        else if (hashtable.ContainsKey((object) "_SUPPLIER_AUTHS_") && hashtable[(object) "_SUPPLIER_AUTHS_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "aoc_Supplier", hashtable[(object) "_SUPPLIER_AUTHS_"]));
        if (hashtable.ContainsKey((object) "aoc_StoreCode") && Convert.ToInt32(hashtable[(object) "aoc_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "aoc_StoreCode", hashtable[(object) "aoc_StoreCode"]));
        else if (hashtable.ContainsKey((object) "aoc_StoreCode_IN_") && hashtable[(object) "aoc_StoreCode_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "aoc_StoreCode", hashtable[(object) "aoc_StoreCode_IN_"]));
        else if (hashtable.ContainsKey((object) "_STORE_AUTHS_") && hashtable[(object) "_STORE_AUTHS_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "aoc_StoreCode", hashtable[(object) "_STORE_AUTHS_"]));
        if (hashtable.ContainsKey((object) "aoc_CategoryCodeTop") && Convert.ToInt32(hashtable[(object) "aoc_CategoryCodeTop"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "aoc_CategoryCodeTop", hashtable[(object) "aoc_CategoryCodeTop"]));
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
        stringBuilder.Append(" SELECT  aoc_ID,aoc_SiteID,aoc_Supplier,aoc_StoreCode,aoc_CategoryCodeTop,aoc_DayofWeek,aoc_LeadTime,aoc_OrderCycle,aoc_StatementSeqType,aoc_AddProperty,aoc_InDate,aoc_InUser,aoc_ModDate,aoc_ModUser");
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
