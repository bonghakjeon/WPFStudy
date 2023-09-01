// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Employee.EmpAuthority.EmpAuthoritySupplier
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
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.TableInfo;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniBase.Employee.EmpAuthority
{
  public class EmpAuthoritySupplier : EmpAuthorityView<EmpAuthoritySupplier>
  {
    private int _eas_status;
    private int _su_Supplier;
    private string _su_SupplierName;
    private string _su_SupplierViewCode;
    private int _su_SupplierType;
    private string _su_UseYn;
    private string _su_BizNo;
    private string _su_BizCeo;

    public int eas_status
    {
      get => this._eas_status;
      set
      {
        this._eas_status = value;
        this.Changed(nameof (eas_status));
        this.Changed("eas_UseYn");
      }
    }

    public bool eas_UseYn => this.eas_status > 0;

    public int su_Supplier
    {
      get => this._su_Supplier;
      set
      {
        this._su_Supplier = value;
        this.Changed(nameof (su_Supplier));
      }
    }

    public string su_SupplierName
    {
      get => this._su_SupplierName;
      set
      {
        this._su_SupplierName = value;
        this.Changed(nameof (su_SupplierName));
      }
    }

    public string su_SupplierViewCode
    {
      get => this._su_SupplierViewCode;
      set
      {
        this._su_SupplierViewCode = value;
        this.Changed(nameof (su_SupplierViewCode));
      }
    }

    public int su_SupplierType
    {
      get => this._su_SupplierType;
      set
      {
        this._su_SupplierType = value;
        this.Changed(nameof (su_SupplierType));
      }
    }

    public string su_SupplierTypeDesc => this.su_SupplierType != 0 ? Enum2StrConverter.ToSupplierType(this.su_SupplierType).ToDescription() : string.Empty;

    public string su_UseYn
    {
      get => this._su_UseYn;
      set
      {
        this._su_UseYn = value;
        this.Changed(nameof (su_UseYn));
        this.Changed("su_IsUseYn");
        this.Changed("su_UseYnDesc");
      }
    }

    public bool su_IsUseYn => "Y".Equals(this.su_UseYn);

    public string su_UseYnDesc => !"Y".Equals(this.su_UseYn) ? "미사용" : "사용";

    public string su_BizNo
    {
      get => this._su_BizNo;
      set
      {
        this._su_BizNo = value;
        this.Changed(nameof (su_BizNo));
      }
    }

    public string su_BizCeo
    {
      get => this._su_BizCeo;
      set
      {
        this._su_BizCeo = value;
        this.Changed(nameof (su_BizCeo));
      }
    }

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("su_Supplier", new TTableColumn()
      {
        tc_orgin_name = "su_Supplier",
        tc_trans_name = "코드"
      });
      columnInfo.Add("su_SupplierName", new TTableColumn()
      {
        tc_orgin_name = "su_SupplierName",
        tc_trans_name = "업체명"
      });
      columnInfo.Add("su_SupplierViewCode", new TTableColumn()
      {
        tc_orgin_name = "su_SupplierViewCode",
        tc_trans_name = "식별코드"
      });
      columnInfo.Add("su_SupplierType", new TTableColumn()
      {
        tc_orgin_name = "su_SupplierType",
        tc_trans_name = "형태"
      });
      columnInfo.Add("su_SupplierTypeDesc", new TTableColumn()
      {
        tc_orgin_name = "su_SupplierTypeDesc",
        tc_trans_name = "형태 설명"
      });
      columnInfo.Add("su_UseYn", new TTableColumn()
      {
        tc_orgin_name = "su_UseYn",
        tc_trans_name = "상태"
      });
      columnInfo.Add("su_BizNo", new TTableColumn()
      {
        tc_orgin_name = "su_BizNo",
        tc_trans_name = "사업자번호"
      });
      columnInfo.Add("su_BizCeo", new TTableColumn()
      {
        tc_orgin_name = "su_BizCeo",
        tc_trans_name = "대표자"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.eas_status = 0;
      this.su_Supplier = 0;
      this.su_SupplierName = string.Empty;
      this.su_SupplierViewCode = string.Empty;
      this.su_SupplierType = 0;
      this.su_UseYn = "N";
      this.su_BizNo = string.Empty;
      this.su_BizCeo = string.Empty;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new EmpAuthoritySupplier();

    public override object Clone()
    {
      EmpAuthoritySupplier authoritySupplier = base.Clone() as EmpAuthoritySupplier;
      authoritySupplier.eas_status = this.eas_status;
      authoritySupplier.su_Supplier = this.su_Supplier;
      authoritySupplier.su_SupplierName = this.su_SupplierName;
      authoritySupplier.su_SupplierViewCode = this.su_SupplierViewCode;
      authoritySupplier.su_SupplierType = this.su_SupplierType;
      authoritySupplier.su_UseYn = this.su_UseYn;
      authoritySupplier.su_BizNo = this.su_BizNo;
      authoritySupplier.su_BizCeo = this.su_BizCeo;
      return (object) authoritySupplier;
    }

    public void PutData(EmpAuthoritySupplier pSource)
    {
      this.PutData((EmpAuthorityView) pSource);
      this.eas_status = pSource.eas_status;
      this.su_Supplier = pSource.su_Supplier;
      this.su_SupplierName = pSource.su_SupplierName;
      this.su_SupplierViewCode = pSource.su_SupplierViewCode;
      this.su_SupplierType = pSource.su_SupplierType;
      this.su_UseYn = pSource.su_UseYn;
      this.su_BizNo = pSource.su_BizNo;
      this.su_BizCeo = pSource.su_BizCeo;
    }

    protected override EnumDataCheck DataCheck()
    {
      EnumDataCheck enumDataCheck = base.DataCheck();
      if (enumDataCheck != EnumDataCheck.Success)
        return enumDataCheck;
      if (this.ea_AuthType == 22)
        return EnumDataCheck.Success;
      this.message = "타입(지점,분류,거래처)(ea_AuthType)  " + EnumDataCheck.CodeZero.ToDescription();
      return EnumDataCheck.CodeZero;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.eas_status = p_rs.GetFieldInt("eas_status");
      this.su_Supplier = p_rs.GetFieldInt("su_Supplier");
      this.su_SupplierName = p_rs.GetFieldString("su_SupplierName");
      this.su_SupplierViewCode = p_rs.GetFieldString("su_SupplierViewCode");
      this.su_SupplierType = p_rs.GetFieldInt("su_SupplierType");
      this.su_UseYn = p_rs.GetFieldString("su_UseYn");
      this.su_BizNo = p_rs.GetFieldString("su_BizNo");
      this.su_BizCeo = p_rs.GetFieldString("su_BizCeo");
      return true;
    }

    public override string GetSelectWhereAnd(object p_param)
    {
      StringBuilder stringBuilder = new StringBuilder(this.GetSelectWhereAnd(p_param, false));
      if (string.IsNullOrWhiteSpace(stringBuilder.ToString()))
        stringBuilder.Append(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        if (hashtable.ContainsKey((object) "ea_SiteID") && Convert.ToInt64(hashtable[(object) "ea_SiteID"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "su_SiteID", hashtable[(object) "ea_SiteID"]));
        if (hashtable.ContainsKey((object) "su_Supplier") && Convert.ToInt32(hashtable[(object) "su_Supplier"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}(ea_Supplier,{1})={2}", (object) DbQueryHelper.ToIsNULL(), (object) "su_Supplier", hashtable[(object) "su_Supplier"]));
        else if (hashtable.ContainsKey((object) "_SUPPLIER_AUTHS_") && hashtable[(object) "_SUPPLIER_AUTHS_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "su_Supplier", hashtable[(object) "_SUPPLIER_AUTHS_"]));
        if (hashtable.ContainsKey((object) "UseYn") && hashtable[(object) "UseYn"].ToString().Length > 0)
          stringBuilder.Append(" AND " + DbQueryHelper.ToIsNULL() + "(ea_EmpCode,0) " + (hashtable[(object) "UseYn"].Equals((object) "Y") ? ">" : "=") + " 0");
        if (hashtable.ContainsKey((object) "_IS_NOT_NULL_") && Convert.ToBoolean(hashtable[(object) "_IS_NOT_NULL_"].ToString()))
          stringBuilder.Append(" AND ea_EmpCode " + DbQueryHelper.ToWhereIsNULL(false));
        if (hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "emp_Name", hashtable[(object) "_KEY_WORD_"]));
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
        string empty = string.Empty;
        long num1 = 0;
        int num2 = 0;
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
          if (hashtable.ContainsKey((object) "_ORDER_BY_COL_") && hashtable[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable.ContainsKey((object) "ea_SiteID") && Convert.ToInt64(hashtable[(object) "ea_SiteID"].ToString()) > 0L)
            num1 = Convert.ToInt64(hashtable[(object) "ea_SiteID"].ToString());
          if (hashtable.ContainsKey((object) "ea_EmpCode") && Convert.ToInt32(hashtable[(object) "ea_EmpCode"].ToString()) > 0)
            num2 = Convert.ToInt32(hashtable[(object) "ea_EmpCode"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS ( SELECT emp_Code,emp_SiteID,emp_Name" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_EMP_AUTHORITY AS ( SELECT ea_EmpCode,ea_AuthType,ea_AuthValue," + "ea_AuthValue".ToInt() + " AS ea_Supplier,ea_SiteID,ea_InputYn,ea_PrintYn FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock() + string.Format(" WHERE {0}={1}", (object) "ea_AuthType", (object) 22));
        if (num2 > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ea_EmpCode", (object) num2));
        if (num1 > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ea_SiteID", (object) num1));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(" SELECT " + string.Format(" {0}({1},{2}) AS {3}", (object) DbQueryHelper.ToIsNULL(), (object) "ea_EmpCode", (object) num2, (object) "ea_EmpCode") + string.Format(",{0}({1},{2}) AS {3}", (object) DbQueryHelper.ToIsNULL(), (object) "ea_AuthType", (object) 22, (object) "ea_AuthType") + "," + DbQueryHelper.ToIsNULL() + "(ea_AuthValue,su_Supplier) AS ea_AuthValue," + DbQueryHelper.ToIsNULL() + "(ea_SiteID,su_SiteID) AS ea_SiteID," + DbQueryHelper.ToIsNULL() + "(ea_InputYn,'N') AS ea_InputYn," + DbQueryHelper.ToIsNULL() + "(ea_PrintYn,'N') AS ea_PrintYn," + DbQueryHelper.ToIsNULL() + "(ea_EmpCode,0) AS eas_status,su_Supplier,su_SupplierName,su_SupplierViewCode,su_SupplierType,su_UseYn,su_BizNo,su_BizCeo,emp_Name");
        stringBuilder.Append("\n");
        stringBuilder.Append(string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Supplier, (object) DbQueryHelper.ToWithNolock()) + " LEFT OUTER JOIN T_EMP_AUTHORITY ON su_Supplier=ea_Supplier AND su_SiteID=ea_SiteID" + string.Format(" AND {0}({1},{2})={3}", (object) DbQueryHelper.ToIsNULL(), (object) "ea_EmpCode", (object) num2, (object) num2) + string.Format(" LEFT OUTER JOIN T_EMPLOYEE_IN ON {0}({1},{2})={3}", (object) DbQueryHelper.ToIsNULL(), (object) "ea_EmpCode", (object) num2, (object) "emp_Code") + " AND " + DbQueryHelper.ToIsNULL() + "(ea_SiteID,su_SiteID)=emp_SiteID");
        stringBuilder.Append("\n");
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append(" ORDER BY " + empty);
        else
          stringBuilder.Append(" ORDER BY su_SupplierViewCode,su_SupplierName");
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
