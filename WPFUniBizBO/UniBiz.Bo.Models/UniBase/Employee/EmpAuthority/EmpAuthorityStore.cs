// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Employee.EmpAuthority.EmpAuthorityStore
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
  public class EmpAuthorityStore : EmpAuthorityView<EmpAuthorityStore>
  {
    private int _eas_status;
    private int _si_StoreCode;
    private string _si_StoreName;
    private string _si_StoreViewCode;
    private string _si_BizCeo;
    private string _si_UseYn;

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

    public int si_StoreCode
    {
      get => this._si_StoreCode;
      set
      {
        this._si_StoreCode = value;
        this.Changed(nameof (si_StoreCode));
      }
    }

    public string si_StoreName
    {
      get => this._si_StoreName;
      set
      {
        this._si_StoreName = value;
        this.Changed(nameof (si_StoreName));
      }
    }

    public string si_StoreViewCode
    {
      get => this._si_StoreViewCode;
      set
      {
        this._si_StoreViewCode = value;
        this.Changed(nameof (si_StoreViewCode));
      }
    }

    public string si_BizCeo
    {
      get => this._si_BizCeo;
      set
      {
        this._si_BizCeo = value;
        this.Changed(nameof (si_BizCeo));
      }
    }

    public string si_UseYn
    {
      get => this._si_UseYn;
      set
      {
        this._si_UseYn = value;
        this.Changed(nameof (si_UseYn));
        this.Changed("si_IsUseYn");
        this.Changed("si_UseYnDesc");
      }
    }

    public bool si_IsUseYn => "Y".Equals(this.si_UseYn);

    public string si_UseYnDesc => !"Y".Equals(this.si_UseYn) ? "미사용" : "사용";

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("si_StoreCode", new TTableColumn()
      {
        tc_orgin_name = "si_StoreCode",
        tc_trans_name = "지점코드"
      });
      columnInfo.Add("si_StoreName", new TTableColumn()
      {
        tc_orgin_name = "si_StoreName",
        tc_trans_name = "지점명"
      });
      columnInfo.Add("si_StoreViewCode", new TTableColumn()
      {
        tc_orgin_name = "si_StoreViewCode",
        tc_trans_name = "관리코드"
      });
      columnInfo.Add("si_BizCeo", new TTableColumn()
      {
        tc_orgin_name = "si_BizCeo",
        tc_trans_name = "대표자"
      });
      columnInfo.Add("si_UseYn", new TTableColumn()
      {
        tc_orgin_name = "si_UseYn",
        tc_trans_name = "사용상태"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.eas_status = 0;
      this.si_StoreCode = 0;
      this.si_StoreName = string.Empty;
      this.si_StoreViewCode = string.Empty;
      this.si_BizCeo = string.Empty;
      this.si_UseYn = "N";
    }

    protected override UbModelBase CreateClone => (UbModelBase) new EmpAuthorityStore();

    public override object Clone()
    {
      EmpAuthorityStore empAuthorityStore = base.Clone() as EmpAuthorityStore;
      empAuthorityStore.eas_status = this.eas_status;
      empAuthorityStore.si_StoreCode = this.si_StoreCode;
      empAuthorityStore.si_StoreName = this.si_StoreName;
      empAuthorityStore.si_StoreViewCode = this.si_StoreViewCode;
      empAuthorityStore.si_BizCeo = this.si_BizCeo;
      empAuthorityStore.si_UseYn = this.si_UseYn;
      return (object) empAuthorityStore;
    }

    public void PutData(EmpAuthorityStore pSource)
    {
      this.PutData((EmpAuthorityView) pSource);
      this.eas_status = pSource.eas_status;
      this.si_StoreCode = pSource.si_StoreCode;
      this.si_StoreName = pSource.si_StoreName;
      this.si_StoreViewCode = pSource.si_StoreViewCode;
      this.si_BizCeo = pSource.si_BizCeo;
      this.si_UseYn = pSource.si_UseYn;
    }

    protected override EnumDataCheck DataCheck()
    {
      EnumDataCheck enumDataCheck = base.DataCheck();
      if (enumDataCheck != EnumDataCheck.Success)
        return enumDataCheck;
      if (this.ea_AuthType == 3)
        return EnumDataCheck.Success;
      this.message = "타입(지점,분류,거래처)(ea_AuthType)  " + EnumDataCheck.CodeZero.ToDescription();
      return EnumDataCheck.CodeZero;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.eas_status = p_rs.GetFieldInt("eas_status");
      this.si_StoreCode = p_rs.GetFieldInt("si_StoreCode");
      this.si_StoreName = p_rs.GetFieldString("si_StoreName");
      this.si_StoreViewCode = p_rs.GetFieldString("si_StoreViewCode");
      this.si_BizCeo = p_rs.GetFieldString("si_BizCeo");
      this.si_UseYn = p_rs.GetFieldString("si_UseYn");
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
          stringBuilder.Append(string.Format(" AND si_SiteID={0}", hashtable[(object) "ea_SiteID"]));
        if (hashtable.ContainsKey((object) "si_StoreCode") && Convert.ToInt32(hashtable[(object) "si_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}(ea_StoreCode,{1})={2}", (object) DbQueryHelper.ToIsNULL(), (object) "si_StoreCode", hashtable[(object) "si_StoreCode"]));
        else if (hashtable.ContainsKey((object) "_STORE_AUTHS_") && hashtable[(object) "_STORE_AUTHS_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "si_StoreCode", hashtable[(object) "_STORE_AUTHS_"]));
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
          if (hashtable.ContainsKey((object) "ea_SiteID_store") && Convert.ToInt64(hashtable[(object) "ea_SiteID_store"].ToString()) > 0L)
            num1 = Convert.ToInt64(hashtable[(object) "ea_SiteID_store"].ToString());
          if (hashtable.ContainsKey((object) "ea_SiteID") && Convert.ToInt64(hashtable[(object) "ea_SiteID"].ToString()) > 0L)
            num1 = Convert.ToInt64(hashtable[(object) "ea_SiteID"].ToString());
          if (hashtable.ContainsKey((object) "ea_EmpCode_store") && Convert.ToInt32(hashtable[(object) "ea_EmpCode_store"].ToString()) > 0)
            num2 = Convert.ToInt32(hashtable[(object) "ea_EmpCode_store"].ToString());
          if (hashtable.ContainsKey((object) "ea_EmpCode") && Convert.ToInt32(hashtable[(object) "ea_EmpCode"].ToString()) > 0)
            num2 = Convert.ToInt32(hashtable[(object) "ea_EmpCode"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS ( SELECT emp_Code,emp_SiteID,emp_Name" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_EMP_AUTHORITY AS ( SELECT ea_EmpCode,ea_AuthType,ea_AuthValue," + "ea_AuthValue".ToInt() + " AS ea_StoreCode,ea_SiteID,ea_InputYn,ea_PrintYn FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock() + string.Format(" WHERE {0}={1}", (object) "ea_AuthType", (object) 3));
        if (num2 > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ea_EmpCode", (object) num2));
        if (num1 > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ea_SiteID", (object) num1));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(" SELECT " + string.Format(" {0}({1},{2}) AS {3}", (object) DbQueryHelper.ToIsNULL(), (object) "ea_EmpCode", (object) num2, (object) "ea_EmpCode") + string.Format(",{0}({1},{2}) AS {3}", (object) DbQueryHelper.ToIsNULL(), (object) "ea_AuthType", (object) 3, (object) "ea_AuthType") + "," + DbQueryHelper.ToIsNULL() + "(ea_AuthValue,si_StoreCode) AS ea_AuthValue," + DbQueryHelper.ToIsNULL() + "(ea_SiteID,si_SiteID) AS ea_SiteID," + DbQueryHelper.ToIsNULL() + "(ea_InputYn,'N') AS ea_InputYn," + DbQueryHelper.ToIsNULL() + "(ea_PrintYn,'N') AS ea_PrintYn," + DbQueryHelper.ToIsNULL() + "(ea_EmpCode,0) AS eas_status,si_StoreCode,si_StoreName,si_StoreViewCode,si_UseYn,si_BizCeo,emp_Name");
        stringBuilder.Append(string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()) + " LEFT OUTER JOIN T_EMP_AUTHORITY ON si_StoreCode=ea_StoreCode AND si_SiteID=ea_SiteID" + string.Format(" AND {0}({1},{2})={3}", (object) DbQueryHelper.ToIsNULL(), (object) "ea_EmpCode", (object) num2, (object) num2) + string.Format(" LEFT OUTER JOIN T_EMPLOYEE_IN ON {0}({1},{2})={3}", (object) DbQueryHelper.ToIsNULL(), (object) "ea_EmpCode", (object) num2, (object) "emp_Code") + " AND " + DbQueryHelper.ToIsNULL() + "(ea_SiteID,si_SiteID)=emp_SiteID");
        stringBuilder.Append("\n");
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append(" ORDER BY " + empty);
        else
          stringBuilder.Append(" ORDER BY si_StoreViewCode,si_StoreName");
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
