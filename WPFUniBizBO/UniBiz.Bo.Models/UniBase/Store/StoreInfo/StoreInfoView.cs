// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Store.StoreInfo.StoreInfoView
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
using UniBiz.Bo.Models.UniBase.Employee.Employee;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniBase.Store.StoreInfo
{
  public class StoreInfoView : TStoreInfo<StoreInfoView>
  {
    private string _uis_SiteViewCode;
    private string _uis_SiteName;
    private string _inEmpName;
    private string _modEmpName;
    private string _si_StoreNameMember;
    private int _sgh_GroupCode;
    private int _sgh_GroupType;
    private string _sgh_GroupName;
    private int _email_pwd_changed;

    public string uis_SiteViewCode
    {
      get => this._uis_SiteViewCode;
      set
      {
        this._uis_SiteViewCode = value;
        this.Changed(nameof (uis_SiteViewCode));
      }
    }

    public string uis_SiteName
    {
      get => this._uis_SiteName;
      set
      {
        this._uis_SiteName = value;
        this.Changed(nameof (uis_SiteName));
      }
    }

    public string inEmpName
    {
      get => this._inEmpName;
      set
      {
        this._inEmpName = value;
        this.Changed(nameof (inEmpName));
        this.Changed("EmpName");
      }
    }

    public string modEmpName
    {
      get => this._modEmpName;
      set
      {
        this._modEmpName = value;
        this.Changed(nameof (modEmpName));
        this.Changed("EmpName");
      }
    }

    public override string EmpName => this.si_ModUser <= 0 ? this.inEmpName : this.modEmpName;

    public string si_StoreNameMember
    {
      get => this._si_StoreNameMember;
      set
      {
        this._si_StoreNameMember = value;
        this.Changed(nameof (si_StoreNameMember));
      }
    }

    public int sgh_GroupCode
    {
      get => this._sgh_GroupCode;
      set
      {
        this._sgh_GroupCode = value;
        this.Changed(nameof (sgh_GroupCode));
      }
    }

    public int sgh_GroupType
    {
      get => this._sgh_GroupType;
      set
      {
        this._sgh_GroupType = value;
        this.Changed(nameof (sgh_GroupType));
        this.Changed("sgh_GroupTypeDesc");
      }
    }

    public string sgh_GroupTypeDesc => this.sgh_GroupType <= 0 ? string.Empty : Enum2StrConverter.ToCommonCodeTypeMemo(this.si_SiteID, EnumCommonCodeType.StoreGroupType, this.sgh_GroupType);

    public string sgh_GroupName
    {
      get => this._sgh_GroupName;
      set
      {
        this._sgh_GroupName = value;
        this.Changed(nameof (sgh_GroupName));
      }
    }

    public int email_pwd_changed
    {
      get => this._email_pwd_changed;
      set
      {
        this._email_pwd_changed = value;
        this.Changed(nameof (email_pwd_changed));
      }
    }

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("uis_SiteViewCode", new TTableColumn()
      {
        tc_orgin_name = "uis_SiteViewCode",
        tc_trans_name = "사이트뷰코드"
      });
      columnInfo.Add("uis_SiteName", new TTableColumn()
      {
        tc_orgin_name = "uis_SiteName",
        tc_trans_name = "사이트명"
      });
      columnInfo.Add("inEmpName", new TTableColumn()
      {
        tc_orgin_name = "inEmpName",
        tc_trans_name = "등록사원"
      });
      columnInfo.Add("modEmpName", new TTableColumn()
      {
        tc_orgin_name = "modEmpName",
        tc_trans_name = "수정사원"
      });
      columnInfo.Add("si_StoreNameMember", new TTableColumn()
      {
        tc_orgin_name = "si_StoreNameMember",
        tc_trans_name = "포인트 지점명"
      });
      columnInfo.Add("sgh_GroupCode", new TTableColumn()
      {
        tc_orgin_name = "sgh_GroupCode",
        tc_trans_name = "지점그룹 코드"
      });
      columnInfo.Add("sgh_GroupType", new TTableColumn()
      {
        tc_orgin_name = "sgh_GroupType",
        tc_trans_name = "타입"
      });
      columnInfo.Add("sgh_GroupName", new TTableColumn()
      {
        tc_orgin_name = "sgh_GroupName",
        tc_trans_name = "지점그룹명"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.uis_SiteViewCode = string.Empty;
      this.uis_SiteName = string.Empty;
      this.inEmpName = string.Empty;
      this.modEmpName = string.Empty;
      this.si_StoreNameMember = string.Empty;
      this.sgh_GroupCode = 0;
      this.sgh_GroupType = 0;
      this.sgh_GroupName = string.Empty;
      this.email_pwd_changed = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new StoreInfoView();

    public override object Clone()
    {
      StoreInfoView storeInfoView = base.Clone() as StoreInfoView;
      storeInfoView.uis_SiteViewCode = this.uis_SiteViewCode;
      storeInfoView.uis_SiteName = this.uis_SiteName;
      storeInfoView.inEmpName = this.inEmpName;
      storeInfoView.modEmpName = this.modEmpName;
      storeInfoView.si_StoreNameMember = this.si_StoreNameMember;
      storeInfoView.sgh_GroupCode = this.sgh_GroupCode;
      storeInfoView.sgh_GroupType = this.sgh_GroupType;
      storeInfoView.sgh_GroupName = this.sgh_GroupName;
      storeInfoView.email_pwd_changed = this.email_pwd_changed;
      return (object) storeInfoView;
    }

    public void PutData(StoreInfoView pSource)
    {
      this.PutData((TStoreInfo) pSource);
      this.uis_SiteViewCode = pSource.uis_SiteViewCode;
      this.uis_SiteName = pSource.uis_SiteName;
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
      this.si_StoreNameMember = pSource.si_StoreNameMember;
      this.sgh_GroupCode = pSource.sgh_GroupCode;
      this.sgh_GroupType = pSource.sgh_GroupType;
      this.sgh_GroupName = pSource.sgh_GroupName;
      this.email_pwd_changed = pSource.email_pwd_changed;
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.si_SiteID == 0L)
      {
        this.message = "싸이트(si_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (string.IsNullOrEmpty(this.si_StoreName))
      {
        this.message = "지점명(si_StoreName)  " + EnumDataCheck.Empty.ToDescription();
        return EnumDataCheck.Empty;
      }
      if (Enum2StrConverter.ToStoreType(this.si_StoreType) == EnumStoreType.None)
      {
        this.message = "지점타입(si_StoreType)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (!string.IsNullOrEmpty(this.si_BizNo))
        return EnumDataCheck.Success;
      this.message = "사업자번호(si_BizNo)  " + EnumDataCheck.Empty.ToDescription();
      return EnumDataCheck.Empty;
    }

    protected override EnumDataCheck DataCheck(UniOleDatabase p_db)
    {
      EnumDataCheck enumDataCheck = this.DataCheck();
      if (enumDataCheck != EnumDataCheck.Success)
        return enumDataCheck;
      if (p_db == null)
      {
        this.message = "DB CONNECT (UniOleDatabase) " + EnumDataCheck.NULL.ToDescription();
        return EnumDataCheck.NULL;
      }
      Hashtable p_param = new Hashtable();
      if (this.IsNew)
      {
        if (string.IsNullOrEmpty(this.si_StoreViewCode))
        {
          if (this.si_StoreCode == 0 && !this.CreateCode(p_db))
          {
            this.message = "지점코드(si_StoreCode)  " + EnumDataCheck.CodeZero.ToDescription();
            return EnumDataCheck.CodeZero;
          }
          p_param.Clear();
          p_param.Add((object) "si_SiteID", (object) this.si_SiteID);
          p_param.Add((object) "si_StoreViewCode", (object) string.Format("{0:0000}", (object) this.si_StoreCode));
          IList<StoreInfoView> storeInfoViewList = p_db.Create<StoreInfoView>().SelectListE<StoreInfoView>((object) p_param);
          if (storeInfoViewList != null && storeInfoViewList.Count > 0)
          {
            foreach (StoreInfoView storeInfoView in (IEnumerable<StoreInfoView>) storeInfoViewList)
            {
              if (storeInfoView.si_StoreCode != this.si_StoreCode)
              {
                this.message = "관리코드(si_StoreViewCode) " + EnumDataCheck.Exists.ToDescription() + string.Format("\n - {0}({1}) {2} 사용중.", (object) storeInfoView.si_StoreName, (object) storeInfoView.si_StoreCode, (object) EnumDataCheck.Exists.ToDescription());
                return EnumDataCheck.Exists;
              }
            }
          }
        }
      }
      else if (this.IsUpdate && !string.IsNullOrEmpty(this.si_StoreViewCode))
      {
        p_param.Clear();
        p_param.Add((object) "si_SiteID", (object) this.si_SiteID);
        p_param.Add((object) "si_StoreViewCode", (object) this.si_StoreViewCode);
        IList<StoreInfoView> storeInfoViewList = p_db.Create<StoreInfoView>().SelectListE<StoreInfoView>((object) p_param);
        if (storeInfoViewList != null && storeInfoViewList.Count > 0)
        {
          foreach (StoreInfoView storeInfoView in (IEnumerable<StoreInfoView>) storeInfoViewList)
          {
            if (storeInfoView.si_StoreCode != this.si_StoreCode)
            {
              this.message = "관리코드(si_StoreViewCode) " + EnumDataCheck.Exists.ToDescription() + string.Format("\n - {0}({1}) {2} 사용중.", (object) storeInfoView.si_StoreName, (object) storeInfoView.si_StoreCode, (object) EnumDataCheck.Exists.ToDescription());
              return EnumDataCheck.Exists;
            }
          }
        }
      }
      return EnumDataCheck.Success;
    }

    protected override bool IsPermit(EmployeeView p_app_employee)
    {
      if (p_app_employee == null)
      {
        this.message = "사용자 정보 NULL.";
        return false;
      }
      if (this.IsNew)
      {
        if (!p_app_employee.IsStoreInsert)
        {
          this.message = p_app_employee.emp_Name + "님(Permit) 변경불가.";
          return false;
        }
      }
      else if (this.IsUpdate)
      {
        this.message = p_app_employee.emp_Name + "님(Permit) 변경불가.";
        if (!p_app_employee.IsStoreUpdate)
          return false;
      }
      return EnumDataCheck.Success == this.DataCheck(this.OleDB);
    }

    public override string CreateCodeQuery()
    {
      base.CreateCodeQuery();
      return " SELECT " + DbQueryHelper.ToIsNULL() + "(MAX(si_StoreCode), 0)+1 AS si_StoreCode" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode, (object) DbQueryHelper.ToWithNolock());
    }

    public override bool CreateCode(UniOleDatabase p_db)
    {
      UniOleDbRecordset uniOleDbRecordset = (UniOleDbRecordset) null;
      UniOleDatabase pOleDB = (UniOleDatabase) null;
      try
      {
        pOleDB = new UniOleDatabase(p_db.ConnectionUrl);
        uniOleDbRecordset = new UniOleDbRecordset(pOleDB, pOleDB.CommandTimeout);
        string codeQuery = this.CreateCodeQuery();
        if (!uniOleDbRecordset.Open(codeQuery))
        {
          this.message = " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) pOleDB.LastErrorID) + " 내용 : " + pOleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          return false;
        }
        if (uniOleDbRecordset.IsDataRead())
          this.si_StoreCode = uniOleDbRecordset.GetFieldInt(0);
        return this.si_StoreCode > 0;
      }
      finally
      {
        uniOleDbRecordset?.Close();
        pOleDB?.Close();
      }
    }

    public override async Task<bool> CreateCodeAsync(UniOleDatabase p_db)
    {
      StoreInfoView storeInfoView = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(p_db.ConnectionUrl);
        rs = new UniOleDbRecordset(db, db.CommandTimeout);
        if (!await rs.OpenAsync(storeInfoView.CreateCodeQuery()))
        {
          storeInfoView.message = " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + storeInfoView.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) db.LastErrorID) + " 내용 : " + db.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          return false;
        }
        if (await rs.IsDataReadAsync())
          storeInfoView.si_StoreCode = rs.GetFieldInt(0);
        return storeInfoView.si_StoreCode > 0;
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    private string MergeSupplierQueryMsSQL()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format("MERGE INTO {0}{1} AS T_SUP", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.Supplier));
      stringBuilder.Append(string.Format(" USING (SELECT * FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode, (object) DbQueryHelper.ToWithNolock()) + string.Format(" WHERE {0}={1}) AS T_SITE ", (object) "si_StoreCode", (object) this.si_StoreCode) + " ON T_SUP.su_Supplier = T_SITE.si_StoreCode");
      stringBuilder.Append(" WHEN MATCHED THEN UPDATE SET");
      stringBuilder.Append(" su_SupplierViewCode='" + this.si_StoreViewCode + "'");
      stringBuilder.Append(",su_SupplierName='" + this.si_StoreName + "'");
      stringBuilder.Append(",su_UseYn='" + this.si_UseYn + "'");
      stringBuilder.Append(",su_Tel='" + this.si_Tel1 + "'");
      stringBuilder.Append(",su_Fax='" + this.si_Tel2 + "'");
      stringBuilder.Append(",su_BizNo='" + this.si_BizNo + "'");
      stringBuilder.Append(",su_BizName='" + this.si_BizName + "'");
      stringBuilder.Append(",su_BizCeo='" + this.si_BizCeo + "'");
      stringBuilder.Append(",su_BizType='" + this.si_BizType + "'");
      stringBuilder.Append(",su_BizCategory='" + this.si_BizCategory + "'");
      stringBuilder.Append(",su_Addr1='" + this.si_BizAddr1 + "'");
      stringBuilder.Append(",su_Addr2='" + this.si_BizAddr2 + "'");
      stringBuilder.Append(",su_ZipCode='" + this.si_ZipCode + "'");
      stringBuilder.Append(",su_ErpCode='" + this.si_ErpCode + "'");
      stringBuilder.Append(",su_ModDate=" + this.si_ModDate.GetDateToStrInNull());
      stringBuilder.Append(string.Format(",{0}={1}", (object) "su_ModUser", (object) this.si_ModUser));
      stringBuilder.Append(" WHEN NOT MATCHED THEN INSERT ( su_Supplier,su_SiteID,su_HeadSupplier,su_SupplierViewCode,su_SupplierName,su_SupplierType,su_SupplierKind,su_UseYn,su_PreTaxDiv,su_MultiSuplierDiv,su_DeductionDayDiv,su_NewStatementYn,su_Tel,su_Fax,su_BizNo,su_BizName,su_BizCeo,su_BizType,su_BizCategory,su_RegidentNo,su_Addr1,su_Addr2,su_ZipCode,su_ContactNm1,su_ContactMemo1,su_ContactNm2,su_ContactMemo2,su_BankCode,su_AccountNo,su_AccountName,su_Memo1,su_Memo2,su_LeadTime,su_Deposit,su_ErpCode,su_EmailStatement,su_EmailTax,su_InDate,su_InUser) VALUES (" + string.Format(" {0}", (object) this.si_StoreCode) + string.Format(",{0},{1},'{2}','{3}'", (object) this.si_SiteID, (object) this.si_StoreCode, (object) this.si_StoreViewCode, (object) this.si_StoreName) + string.Format(",{0},{1},'{2}'", (object) 1, (object) 1, (object) this.si_UseYn) + string.Format(",{0},{1},{2},'{3}'", (object) 1, (object) 2, (object) 2, (object) "Y") + ",'" + this.si_Tel1 + "','" + this.si_Tel2 + "','" + this.si_BizNo + "','" + this.si_BizName + "','" + this.si_BizCeo + "','" + this.si_BizType + "','" + this.si_BizCategory + "','','" + this.si_BizAddr1 + "','" + this.si_BizAddr2 + "','" + this.si_ZipCode + "','','','','','','','','','',0,0,'" + this.si_ErpCode + "','',''" + string.Format(",{0},{1}", (object) this.si_InDate.GetDateToStrInNull(), (object) this.si_InUser) + "); ");
      return stringBuilder.ToString();
    }

    private string MergeSupplierQueryMySQL()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format("INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.Supplier) + " su_Supplier,su_SiteID,su_HeadSupplier,su_SupplierViewCode,su_SupplierName,su_SupplierType,su_SupplierKind,su_UseYn,su_PreTaxDiv,su_MultiSuplierDiv,su_DeductionDayDiv,su_NewStatementYn,su_Tel,su_Fax,su_BizNo,su_BizName,su_BizCeo,su_BizType,su_BizCategory,su_RegidentNo,su_Addr1,su_Addr2,su_ZipCode,su_ContactNm1,su_ContactMemo1,su_ContactNm2,su_ContactMemo2,su_BankCode,su_AccountNo,su_AccountName,su_Memo1,su_Memo2,su_LeadTime,su_Deposit,su_ErpCode,su_EmailStatement,su_EmailTax,su_InDate,su_InUser) VALUES (" + string.Format(" {0}", (object) this.si_StoreCode) + string.Format(",{0},{1},'{2}','{3}'", (object) this.si_SiteID, (object) this.si_StoreCode, (object) this.si_StoreViewCode, (object) this.si_StoreName) + string.Format(",{0},{1},'{2}'", (object) 1, (object) 1, (object) this.si_UseYn) + string.Format(",{0},{1},{2},'{3}'", (object) 1, (object) 2, (object) 2, (object) "Y") + ",'" + this.si_Tel1 + "','" + this.si_Tel2 + "','" + this.si_BizNo + "','" + this.si_BizName + "','" + this.si_BizCeo + "','" + this.si_BizType + "','" + this.si_BizCategory + "','','" + this.si_BizAddr1 + "','" + this.si_BizAddr2 + "','" + this.si_ZipCode + "','','','','','','','','','',0,0,'" + this.si_ErpCode + "','',''" + string.Format(",{0},{1}", (object) this.si_InDate.GetDateToStrInNull(), (object) this.si_InUser) + ") ON DUPLICATE KEY UPDATE ");
      stringBuilder.Append(" su_SupplierViewCode='" + this.si_StoreViewCode + "'");
      stringBuilder.Append(",su_SupplierName='" + this.si_StoreName + "'");
      stringBuilder.Append(",su_UseYn='" + this.si_UseYn + "'");
      stringBuilder.Append(",su_Tel='" + this.si_Tel1 + "'");
      stringBuilder.Append(",su_Fax='" + this.si_Tel2 + "'");
      stringBuilder.Append(",su_BizNo='" + this.si_BizNo + "'");
      stringBuilder.Append(",su_BizName='" + this.si_BizName + "'");
      stringBuilder.Append(",su_BizCeo='" + this.si_BizCeo + "'");
      stringBuilder.Append(",su_BizType='" + this.si_BizType + "'");
      stringBuilder.Append(",su_BizCategory='" + this.si_BizCategory + "'");
      stringBuilder.Append(",su_Addr1='" + this.si_BizAddr1 + "'");
      stringBuilder.Append(",su_Addr2='" + this.si_BizAddr2 + "'");
      stringBuilder.Append(",su_ZipCode='" + this.si_ZipCode + "'");
      stringBuilder.Append(",su_ErpCode='" + this.si_ErpCode + "'");
      stringBuilder.Append(",su_ModDate=" + this.si_ModDate.GetDateToStrInNull());
      stringBuilder.Append(string.Format(",{0}={1}", (object) "su_ModUser", (object) this.si_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public bool MergeSupplier()
    {
      if (this.si_StoreCode == 0)
        return false;
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          return this.OleDB.Execute(this.MergeSupplierQueryMsSQL());
        case EnumDB.MYSQL:
          return this.OleDB.Execute(this.MergeSupplierQueryMySQL());
        default:
          return false;
      }
    }

    public async Task<bool> MergeSupplierAsync()
    {
      StoreInfoView storeInfoView = this;
      if (storeInfoView.si_StoreCode == 0)
        return false;
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          return await storeInfoView.OleDB.ExecuteAsync(storeInfoView.MergeSupplierQueryMsSQL());
        case EnumDB.MYSQL:
          return await storeInfoView.OleDB.ExecuteAsync(storeInfoView.MergeSupplierQueryMySQL());
        default:
          return false;
      }
    }

    public override bool Insert() => (this.si_StoreCode != 0 || this.CreateCode(this.OleDB)) && base.Insert() && this.MergeSupplier() && this.SetSuccessInfo(string.Format("({0}) 등록됨.", (object) this.si_StoreCode));

    public override async Task<bool> InsertAsync()
    {
      StoreInfoView storeInfoView = this;
      if (storeInfoView.si_StoreCode == 0)
      {
        if (!await storeInfoView.CreateCodeAsync(storeInfoView.OleDB))
          return false;
      }
      // ISSUE: reference to a compiler-generated method
      return await storeInfoView.\u003C\u003En__0() && await storeInfoView.MergeSupplierAsync() && storeInfoView.SetSuccessInfo(string.Format("({0}) 등록됨.", (object) storeInfoView.si_StoreCode));
    }

    public override bool Update(UbModelBase p_old = null) => base.Update(p_old) && this.MergeSupplier() && this.SetSuccessInfo(string.Format("({0}) 변경됨.", (object) this.si_StoreCode));

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      StoreInfoView storeInfoView = this;
      // ISSUE: reference to a compiler-generated method
      return await storeInfoView.\u003C\u003En__1(p_old) && await storeInfoView.MergeSupplierAsync() && storeInfoView.SetSuccessInfo(string.Format("({0}) 변경됨.", (object) storeInfoView.si_StoreCode));
    }

    public override bool UpdateExInsert() => base.UpdateExInsert() && this.SetSuccessInfo(string.Format("({0}) 변경됨.", (object) this.si_StoreCode));

    public override async Task<bool> UpdateExInsertAsync()
    {
      StoreInfoView storeInfoView = this;
      // ISSUE: reference to a compiler-generated method
      return await storeInfoView.\u003C\u003En__2() && storeInfoView.SetSuccessInfo(string.Format("({0}) 변경됨.", (object) storeInfoView.si_StoreCode));
    }

    public override bool InsertData(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      try
      {
        this.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != this.DataCheck(p_db))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (this.si_SiteID == 0L)
            this.si_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (this.si_StoreCode == 0 && !this.CreateCode(p_db))
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 코드 생성 오류", 2);
        if (!this.Insert())
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 등록 오류");
        this.db_status = 4;
        this.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        this.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        this.message = ex.Message;
      }
      return false;
    }

    public override async Task<bool> InsertDataAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      StoreInfoView storeInfoView = this;
      try
      {
        storeInfoView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != storeInfoView.DataCheck(p_db))
            throw new UniServiceException(storeInfoView.message, storeInfoView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (storeInfoView.si_SiteID == 0L)
            storeInfoView.si_SiteID = p_app_employee.emp_SiteID;
          if (!storeInfoView.IsPermit(p_app_employee))
            throw new UniServiceException(storeInfoView.message, storeInfoView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (storeInfoView.si_StoreCode == 0)
        {
          if (!await storeInfoView.CreateCodeAsync(p_db))
            throw new UniServiceException(storeInfoView.message, storeInfoView.TableCode.ToDescription() + " 코드 생성 오류", 2);
        }
        if (!await storeInfoView.InsertAsync())
          throw new UniServiceException(storeInfoView.message, storeInfoView.TableCode.ToDescription() + " 등록 오류");
        storeInfoView.db_status = 4;
        storeInfoView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        storeInfoView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        storeInfoView.message = ex.Message;
      }
      return false;
    }

    public override bool UpdateData(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      try
      {
        this.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != this.DataCheck(p_db))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!this.IsPermit(p_app_employee))
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        if (this.si_StoreCode == 0)
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 지점코드(si_StoreCode)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (!this.Update((UbModelBase) null))
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 변경 오류");
        this.db_status = 4;
        this.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        this.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        this.message = ex.Message;
      }
      return false;
    }

    public override async Task<bool> UpdateDataAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      StoreInfoView storeInfoView = this;
      try
      {
        storeInfoView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != storeInfoView.DataCheck(p_db))
            throw new UniServiceException(storeInfoView.message, storeInfoView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!storeInfoView.IsPermit(p_app_employee))
          throw new UniServiceException(storeInfoView.message, storeInfoView.TableCode.ToDescription() + " 권한 검사 실패");
        if (storeInfoView.si_StoreCode == 0)
          throw new UniServiceException(storeInfoView.message, storeInfoView.TableCode.ToDescription() + " 지점코드(si_StoreCode)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (!await storeInfoView.UpdateAsync())
          throw new UniServiceException(storeInfoView.message, storeInfoView.TableCode.ToDescription() + " 변경 오류");
        storeInfoView.db_status = 4;
        storeInfoView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        storeInfoView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        storeInfoView.message = ex.Message;
      }
      return false;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.uis_SiteViewCode = p_rs.GetFieldString("uis_SiteViewCode");
      this.uis_SiteName = p_rs.GetFieldString("uis_SiteName");
      this.inEmpName = p_rs.GetFieldString("inEmpName");
      this.modEmpName = p_rs.GetFieldString("modEmpName");
      this.si_StoreNameMember = p_rs.GetFieldString("si_StoreNameMember");
      this.sgh_GroupCode = p_rs.GetFieldInt("sgh_GroupCode");
      this.sgh_GroupType = p_rs.GetFieldInt("sgh_GroupType");
      this.sgh_GroupName = p_rs.GetFieldString("sgh_GroupName");
      return true;
    }

    public async Task<StoreInfoView> SelectOneAsync(int p_si_StoreCode, long p_si_SiteID = 0)
    {
      StoreInfoView storeInfoView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "si_StoreCode",
          (object) p_si_StoreCode
        }
      };
      if (p_si_SiteID > 0L)
        p_param.Add((object) "si_SiteID", (object) p_si_SiteID);
      return await storeInfoView.SelectOneTAsync<StoreInfoView>((object) p_param);
    }

    public async Task<IList<StoreInfoView>> SelectListAsync(object p_param)
    {
      StoreInfoView storeInfoView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(storeInfoView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, storeInfoView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(storeInfoView1.GetSelectQuery(p_param)))
        {
          storeInfoView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + storeInfoView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<StoreInfoView>) null;
        }
        IList<StoreInfoView> lt_list = (IList<StoreInfoView>) new List<StoreInfoView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            StoreInfoView storeInfoView2 = storeInfoView1.OleDB.Create<StoreInfoView>();
            if (storeInfoView2.GetFieldValues(rs))
            {
              storeInfoView2.row_number = lt_list.Count + 1;
              lt_list.Add(storeInfoView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + storeInfoView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public override string GetSelectWhereAnd(object p_param)
    {
      StringBuilder stringBuilder = new StringBuilder(this.GetSelectWhereAnd(p_param, false));
      if (string.IsNullOrWhiteSpace(stringBuilder.ToString()))
        stringBuilder.Append(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        if ((!hashtable.ContainsKey((object) "_IS_MEMBER_MNT_STORE_") ? 0 : (Convert.ToBoolean(hashtable[(object) "_IS_MEMBER_MNT_STORE_"].ToString()) ? 1 : 0)) != 0)
          stringBuilder.Append(" AND si_StoreCode=si_MemberMntStore");
        if (hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "si_StoreViewCode", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "si_StoreName", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "si_BizName", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "si_BizCeo", hashtable[(object) "_KEY_WORD_"]));
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
        long num = 0;
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
          if (hashtable.ContainsKey((object) "_ORDER_BY_COL_") && hashtable[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable.ContainsKey((object) "si_SiteID") && Convert.ToInt64(hashtable[(object) "si_SiteID"].ToString()) > 0L)
            num = Convert.ToInt64(hashtable[(object) "si_SiteID"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS ( SELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_EMPLOYEE_MOD AS ( SELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_UNI_SITE AS ( SELECT uis_SiteID,uis_SiteViewCode,uis_SiteName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.UniSite, (object) DbQueryHelper.ToWithNolock()));
        if (num > 0L)
          stringBuilder.Append(string.Format("  WHERE {0}={1}", (object) "uis_SiteID", (object) num));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_SITE_INFO_MEMBER AS ( SELECT si_StoreCode AS StoreCodeMember,si_StoreName AS si_StoreNameMember" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()));
        if (num > 0L)
          stringBuilder.Append(string.Format("  WHERE {0}={1}", (object) "si_SiteID", (object) num));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_GROUP_DETAIL AS ( SELECT sgd_GroupCode,sgd_StoreCode,sgd_SortNo,sgd_SiteID,sgh_GroupCode,sgh_GroupType,sgh_GroupName,sgh_Memo,sgh_SortNo,sgh_UseYn" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.StoreGroupDetail, (object) DbQueryHelper.ToWithNolock()) + string.Format(" LEFT OUTER JOIN {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.StoreGroupHeader, (object) DbQueryHelper.ToWithNolock()) + " ON sgd_GroupCode=sgh_GroupCode");
        if (num > 0L)
          stringBuilder.Append(string.Format("  WHERE {0}={1}", (object) "sgd_SiteID", (object) num));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(" SELECT  si_StoreCode,si_SiteID,si_StoreType,si_StoreViewCode,si_StoreName,si_Tel1,si_Tel2,si_LocalIP,si_PublicIP,si_UseYn,si_ErpCode,si_ErpUpdateDate,si_BizNo,si_BizName,si_BizCeo,si_BizType,si_BizCategory,si_BizAddr1,si_BizAddr2,si_ZipCode,si_BuyConfirmDate,si_StockConfirmDate,si_StockStartDate,si_SaleConfirmDate,si_SortNo,si_MemberMntStore,si_WeatherCode,si_Email,si_EmailPwd,si_LocationUseYn,si_AutoOrderSafetyFactor,si_AutoOrderOpt,si_AutoOrderRef,si_InDate,si_InUser,si_ModDate,si_ModUser,uis_SiteViewCode,uis_SiteName,inEmpName,modEmpName,si_StoreNameMember,sgh_GroupCode,sgh_GroupType,sgh_GroupName FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock() + " INNER JOIN T_UNI_SITE ON si_SiteID=uis_SiteID LEFT OUTER JOIN T_EMPLOYEE_IN ON si_InUser=emp_CodeIn LEFT OUTER JOIN T_EMPLOYEE_MOD ON si_ModUser=emp_CodeMod LEFT OUTER JOIN T_SITE_INFO_MEMBER ON si_MemberMntStore=StoreCodeMember  LEFT OUTER JOIN T_GROUP_DETAIL ON si_StoreCode=sgd_StoreCode");
        stringBuilder.Append("\n");
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append(" ORDER BY " + empty);
        else
          stringBuilder.Append(" ORDER BY si_StoreCode");
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
