// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Supplier.SupplierAutoDeduction.TSupplierAutoDeduction
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

namespace UniBiz.Bo.Models.UniBase.Supplier.SupplierAutoDeduction
{
  public class TSupplierAutoDeduction : UbModelBase<TSupplierAutoDeduction>
  {
    private int _suad_SupplierHistory;
    private int _suad_Seq;
    private long _suad_SiteID;
    private int _suad_CalcType;
    private int _suad_StdPriceType;
    private double _suad_StdValue;
    private double _suad_Value;
    private int _suad_AddProperty;
    private DateTime? _suad_InDate;
    private int _suad_InUser;
    private DateTime? _suad_ModDate;
    private int _suad_ModUser;

    public override object _Key => (object) new object[2]
    {
      (object) this.suad_SupplierHistory,
      (object) this.suad_Seq
    };

    public int suad_SupplierHistory
    {
      get => this._suad_SupplierHistory;
      set
      {
        this._suad_SupplierHistory = value;
        this.Changed(nameof (suad_SupplierHistory));
      }
    }

    public int suad_Seq
    {
      get => this._suad_Seq;
      set
      {
        this._suad_Seq = value;
        this.Changed(nameof (suad_Seq));
        this.Changed("suad_SeqDesc");
      }
    }

    public string suad_SeqDesc => this.suad_Seq <= 0 ? string.Empty : Enum2StrConverter.ToCommonCodeTypeMemo(this.suad_SiteID, EnumCommonCodeType.DeductionAutoType, this.suad_Seq);

    public long suad_SiteID
    {
      get => this._suad_SiteID;
      set
      {
        this._suad_SiteID = value;
        this.Changed(nameof (suad_SiteID));
        this.Changed("suad_SeqDesc");
      }
    }

    public int suad_CalcType
    {
      get => this._suad_CalcType;
      set
      {
        this._suad_CalcType = value;
        this.Changed(nameof (suad_CalcType));
        this.Changed("suad_CalcTypeDesc");
      }
    }

    public string suad_CalcTypeDesc => this.suad_CalcType <= 0 ? string.Empty : Enum2StrConverter.ToCommonCodeTypeMemo(this.suad_SiteID, EnumCommonCodeType.DeductionAutoCalc, this.suad_CalcType);

    public int suad_StdPriceType
    {
      get => this._suad_StdPriceType;
      set
      {
        this._suad_StdPriceType = value;
        this.Changed(nameof (suad_StdPriceType));
      }
    }

    public string suad_StdPriceTypeDesc => this.suad_StdPriceType <= 0 ? string.Empty : Enum2StrConverter.ToCommonCodeTypeMemo(this.suad_SiteID, EnumCommonCodeType.StdPreTax, this.suad_StdPriceType);

    public double suad_StdValue
    {
      get => this._suad_StdValue;
      set
      {
        this._suad_StdValue = value;
        this.Changed(nameof (suad_StdValue));
      }
    }

    public double suad_Value
    {
      get => this._suad_Value;
      set
      {
        this._suad_Value = value;
        this.Changed(nameof (suad_Value));
      }
    }

    public int suad_AddProperty
    {
      get => this._suad_AddProperty;
      set
      {
        this._suad_AddProperty = value;
        this.Changed(nameof (suad_AddProperty));
      }
    }

    public DateTime? suad_InDate
    {
      get => this._suad_InDate;
      set
      {
        this._suad_InDate = value;
        this.Changed(nameof (suad_InDate));
      }
    }

    public int suad_InUser
    {
      get => this._suad_InUser;
      set
      {
        this._suad_InUser = value;
        this.Changed(nameof (suad_InUser));
      }
    }

    public DateTime? suad_ModDate
    {
      get => this._suad_ModDate;
      set
      {
        this._suad_ModDate = value;
        this.Changed(nameof (suad_ModDate));
      }
    }

    public int suad_ModUser
    {
      get => this._suad_ModUser;
      set
      {
        this._suad_ModUser = value;
        this.Changed(nameof (suad_ModUser));
      }
    }

    public TSupplierAutoDeduction() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("suad_SupplierHistory", new TTableColumn()
      {
        tc_orgin_name = "suad_SupplierHistory",
        tc_trans_name = "업체 결제 이력 KEY"
      });
      columnInfo.Add("suad_Seq", new TTableColumn()
      {
        tc_orgin_name = "suad_Seq",
        tc_trans_name = "공제항목",
        tc_comm_code = 77
      });
      columnInfo.Add("suad_SiteID", new TTableColumn()
      {
        tc_orgin_name = "suad_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("suad_CalcType", new TTableColumn()
      {
        tc_orgin_name = "suad_CalcType",
        tc_trans_name = "계산방법",
        tc_comm_code = 78
      });
      columnInfo.Add("suad_StdPriceType", new TTableColumn()
      {
        tc_orgin_name = "suad_StdPriceType",
        tc_trans_name = "기준단가",
        tc_comm_code = 42
      });
      columnInfo.Add("suad_StdValue", new TTableColumn()
      {
        tc_orgin_name = "suad_StdValue",
        tc_trans_name = "기준금액"
      });
      columnInfo.Add("suad_Value", new TTableColumn()
      {
        tc_orgin_name = "suad_Value",
        tc_trans_name = "공제값"
      });
      columnInfo.Add("suad_AddProperty", new TTableColumn()
      {
        tc_orgin_name = "suad_AddProperty",
        tc_trans_name = "속성타입"
      });
      columnInfo.Add("suad_InDate", new TTableColumn()
      {
        tc_orgin_name = "suad_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("suad_InUser", new TTableColumn()
      {
        tc_orgin_name = "suad_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("suad_ModDate", new TTableColumn()
      {
        tc_orgin_name = "suad_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("suad_ModUser", new TTableColumn()
      {
        tc_orgin_name = "suad_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.SupplierAutoDeduction;
      this.suad_SupplierHistory = this.suad_Seq = 0;
      this.suad_SiteID = 0L;
      this.suad_CalcType = this.suad_StdPriceType = 0;
      this.suad_StdValue = this.suad_Value = 0.0;
      this.suad_AddProperty = 0;
      this.suad_InDate = new DateTime?();
      this.suad_InUser = 0;
      this.suad_ModDate = new DateTime?();
      this.suad_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TSupplierAutoDeduction();

    public override object Clone()
    {
      TSupplierAutoDeduction tsupplierAutoDeduction = base.Clone() as TSupplierAutoDeduction;
      tsupplierAutoDeduction.suad_SupplierHistory = this.suad_SupplierHistory;
      tsupplierAutoDeduction.suad_SiteID = this.suad_SiteID;
      tsupplierAutoDeduction.suad_Seq = this.suad_Seq;
      tsupplierAutoDeduction.suad_CalcType = this.suad_CalcType;
      tsupplierAutoDeduction.suad_StdPriceType = this.suad_StdPriceType;
      tsupplierAutoDeduction.suad_StdValue = this.suad_StdValue;
      tsupplierAutoDeduction.suad_Value = this.suad_Value;
      tsupplierAutoDeduction.suad_AddProperty = this.suad_AddProperty;
      tsupplierAutoDeduction.suad_InDate = this.suad_InDate;
      tsupplierAutoDeduction.suad_ModDate = this.suad_ModDate;
      tsupplierAutoDeduction.suad_InUser = this.suad_InUser;
      tsupplierAutoDeduction.suad_ModUser = this.suad_ModUser;
      return (object) tsupplierAutoDeduction;
    }

    public void PutData(TSupplierAutoDeduction pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.suad_SupplierHistory = pSource.suad_SupplierHistory;
      this.suad_SiteID = pSource.suad_SiteID;
      this.suad_Seq = pSource.suad_Seq;
      this.suad_CalcType = pSource.suad_CalcType;
      this.suad_StdPriceType = pSource.suad_StdPriceType;
      this.suad_StdValue = pSource.suad_StdValue;
      this.suad_Value = pSource.suad_Value;
      this.suad_AddProperty = pSource.suad_AddProperty;
      this.suad_InDate = pSource.suad_InDate;
      this.suad_ModDate = pSource.suad_ModDate;
      this.suad_InUser = pSource.suad_InUser;
      this.suad_ModUser = pSource.suad_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.suad_SupplierHistory = p_rs.GetFieldInt("suad_SupplierHistory");
        if (this.suad_SupplierHistory == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.suad_SiteID = p_rs.GetFieldLong("suad_SiteID");
        this.suad_Seq = p_rs.GetFieldInt("suad_Seq");
        this.suad_CalcType = p_rs.GetFieldInt("suad_CalcType");
        this.suad_StdPriceType = p_rs.GetFieldInt("suad_StdPriceType");
        this.suad_StdValue = p_rs.GetFieldDouble("suad_StdValue");
        this.suad_Value = p_rs.GetFieldDouble("suad_Value");
        this.suad_AddProperty = p_rs.GetFieldInt("suad_AddProperty");
        this.suad_InDate = p_rs.GetFieldDateTime("suad_InDate");
        this.suad_InUser = p_rs.GetFieldInt("suad_InUser");
        this.suad_ModDate = p_rs.GetFieldDateTime("suad_ModDate");
        this.suad_ModUser = p_rs.GetFieldInt("suad_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " suad_SupplierHistory,suad_Seq,suad_SiteID,suad_CalcType,suad_StdPriceType,suad_StdValue,suad_Value,suad_AddProperty,suad_InDate,suad_InUser,suad_ModDate,suad_ModUser) VALUES ( " + string.Format(" {0},{1}", (object) this.suad_SupplierHistory, (object) this.suad_Seq) + string.Format(",{0}", (object) this.suad_SiteID) + string.Format(",{0},{1}", (object) this.suad_CalcType, (object) this.suad_StdPriceType) + string.Format(",{0},{1},{2}", (object) this.suad_StdValue.FormatTo("{0:0.0000}"), (object) this.suad_Value.FormatTo("{0:0.0000}"), (object) this.suad_AddProperty) + string.Format(",{0},{1}", (object) this.suad_InDate.GetDateToStrInNull(), (object) this.suad_InUser) + string.Format(",{0},{1}", (object) this.suad_ModDate.GetDateToStrInNull(), (object) this.suad_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.suad_SupplierHistory, (object) this.suad_Seq, (object) this.suad_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TSupplierAutoDeduction tsupplierAutoDeduction = this;
      // ISSUE: reference to a compiler-generated method
      tsupplierAutoDeduction.\u003C\u003En__0();
      if (await tsupplierAutoDeduction.OleDB.ExecuteAsync(tsupplierAutoDeduction.InsertQuery()))
        return true;
      tsupplierAutoDeduction.message = " " + tsupplierAutoDeduction.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tsupplierAutoDeduction.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tsupplierAutoDeduction.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tsupplierAutoDeduction.suad_SupplierHistory, (object) tsupplierAutoDeduction.suad_Seq, (object) tsupplierAutoDeduction.suad_SiteID) + " 내용 : " + tsupplierAutoDeduction.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tsupplierAutoDeduction.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + string.Format(" {0}={1},{2}={3}", (object) "suad_CalcType", (object) this.suad_CalcType, (object) "suad_StdPriceType", (object) this.suad_StdPriceType) + ",suad_StdValue=" + this.suad_StdValue.FormatTo("{0:0.0000}") + ",suad_Value=" + this.suad_Value.FormatTo("{0:0.0000}") + string.Format(",{0}={1}", (object) "suad_AddProperty", (object) this.suad_AddProperty) + string.Format(",{0}={1},{2}={3}", (object) "suad_ModDate", (object) this.suad_ModDate.GetDateToStrInNull(), (object) "suad_ModUser", (object) this.suad_ModUser) + string.Format(" WHERE {0}={1}", (object) "suad_SupplierHistory", (object) this.suad_SupplierHistory) + string.Format(" AND {0}={1}", (object) "suad_Seq", (object) this.suad_Seq) + string.Format(" AND {0}={1}", (object) "suad_SiteID", (object) this.suad_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.suad_SupplierHistory, (object) this.suad_Seq, (object) this.suad_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TSupplierAutoDeduction tsupplierAutoDeduction = this;
      // ISSUE: reference to a compiler-generated method
      tsupplierAutoDeduction.\u003C\u003En__1();
      if (await tsupplierAutoDeduction.OleDB.ExecuteAsync(tsupplierAutoDeduction.UpdateQuery()))
        return true;
      tsupplierAutoDeduction.message = " " + tsupplierAutoDeduction.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tsupplierAutoDeduction.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tsupplierAutoDeduction.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tsupplierAutoDeduction.suad_SupplierHistory, (object) tsupplierAutoDeduction.suad_Seq, (object) tsupplierAutoDeduction.suad_SiteID) + " 내용 : " + tsupplierAutoDeduction.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tsupplierAutoDeduction.message);
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
      stringBuilder.Append(string.Format(" {0}={1},{2}={3}", (object) "suad_CalcType", (object) this.suad_CalcType, (object) "suad_StdPriceType", (object) this.suad_StdPriceType) + ",suad_StdValue=" + this.suad_StdValue.FormatTo("{0:0.0000}") + ",suad_Value=" + this.suad_Value.FormatTo("{0:0.0000}") + string.Format(",{0}={1}", (object) "suad_AddProperty", (object) this.suad_AddProperty) + string.Format(",{0}={1},{2}={3}", (object) "suad_ModDate", (object) this.suad_ModDate.GetDateToStrInNull(), (object) "suad_ModUser", (object) this.suad_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.suad_SupplierHistory, (object) this.suad_Seq, (object) this.suad_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TSupplierAutoDeduction tsupplierAutoDeduction = this;
      // ISSUE: reference to a compiler-generated method
      tsupplierAutoDeduction.\u003C\u003En__1();
      if (await tsupplierAutoDeduction.OleDB.ExecuteAsync(tsupplierAutoDeduction.UpdateExInsertQuery()))
        return true;
      tsupplierAutoDeduction.message = " " + tsupplierAutoDeduction.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tsupplierAutoDeduction.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tsupplierAutoDeduction.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tsupplierAutoDeduction.suad_SupplierHistory, (object) tsupplierAutoDeduction.suad_Seq, (object) tsupplierAutoDeduction.suad_SiteID) + " 내용 : " + tsupplierAutoDeduction.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tsupplierAutoDeduction.message);
      return false;
    }

    public override string DeleteQuery() => string.Format(" DELETE FROM {0}{1}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + string.Format(" WHERE {0}={1}", (object) "suad_SupplierHistory", (object) this.suad_SupplierHistory) + string.Format(" AND {0}={1}", (object) "suad_Seq", (object) this.suad_Seq) + string.Format(" AND {0}={1}", (object) "suad_SiteID", (object) this.suad_SiteID);

    public override bool Delete()
    {
      this.InsertChecked();
      string pStrExec = this.DeleteQuery();
      if (this.OleDB.Execute(pStrExec))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 삭제 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.suad_SupplierHistory, (object) this.suad_Seq, (object) this.suad_SiteID) + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n 쿼리 : " + pStrExec + "\n--------------------------------------------------------------------------------------------------\n";
      return false;
    }

    public override async Task<bool> DeleteAsync()
    {
      TSupplierAutoDeduction tsupplierAutoDeduction = this;
      // ISSUE: reference to a compiler-generated method
      tsupplierAutoDeduction.\u003C\u003En__0();
      if (await tsupplierAutoDeduction.OleDB.ExecuteAsync(tsupplierAutoDeduction.DeleteQuery()))
        return true;
      tsupplierAutoDeduction.message = " " + tsupplierAutoDeduction.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tsupplierAutoDeduction.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tsupplierAutoDeduction.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tsupplierAutoDeduction.suad_SupplierHistory, (object) tsupplierAutoDeduction.suad_Seq, (object) tsupplierAutoDeduction.suad_SiteID) + " 내용 : " + tsupplierAutoDeduction.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tsupplierAutoDeduction.message);
      return false;
    }

    public virtual string DeleteQuery(
      int p_suad_SupplierHistory,
      int p_suad_Seq,
      long p_suad_SiteID = 0)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format(" DELETE FROM {0}{1} ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode));
      stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "suad_SupplierHistory", (object) p_suad_SupplierHistory));
      if (p_suad_Seq > 0)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "suad_Seq", (object) p_suad_Seq));
      if (p_suad_SiteID > 0L)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "suad_SiteID", (object) p_suad_SiteID));
      return stringBuilder.ToString();
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "suad_SiteID") && Convert.ToInt64(hashtable[(object) "suad_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "suad_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "suad_SupplierHistory") && Convert.ToInt32(hashtable[(object) "suad_SupplierHistory"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "suad_SupplierHistory", hashtable[(object) "suad_SupplierHistory"]));
        if (hashtable.ContainsKey((object) "suad_Seq") && Convert.ToInt32(hashtable[(object) "suad_Seq"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "suad_Seq", hashtable[(object) "suad_Seq"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "suad_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "suad_CalcType") && Convert.ToInt32(hashtable[(object) "suad_CalcType"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "suad_CalcType", hashtable[(object) "suad_CalcType"]));
        if (hashtable.ContainsKey((object) "suad_StdPriceType") && Convert.ToInt32(hashtable[(object) "suad_StdPriceType"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "suad_StdPriceType", hashtable[(object) "suad_StdPriceType"]));
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
        stringBuilder.Append(" SELECT  suad_SupplierHistory,suad_Seq,suad_SiteID,suad_CalcType,suad_StdPriceType,suad_StdValue,suad_Value,suad_AddProperty,suad_InDate,suad_InUser,suad_ModDate,suad_ModUser");
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
