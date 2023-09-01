// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Supplier.Supplier.SupplierView
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
using UniBiz.Bo.Models.UniBase.Employee.Employee;
using UniBiz.Bo.Models.UniBase.Supplier.SupplierImage;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniBase.Supplier.Supplier
{
  public class SupplierView : TSupplier<SupplierView>
  {
    private string _su_head_Name;
    private string _su_head_ViewCode;
    private string _su_AssignUser_Name;
    private string _inEmpName;
    private string _modEmpName;
    private SupplierImageKind _ImageInfo;

    public string su_head_Name
    {
      get => this._su_head_Name;
      set
      {
        this._su_head_Name = value;
        this.Changed(nameof (su_head_Name));
      }
    }

    public string su_head_ViewCode
    {
      get => this._su_head_ViewCode;
      set
      {
        this._su_head_ViewCode = value;
        this.Changed(nameof (su_head_ViewCode));
      }
    }

    public string su_AssignUser_Name
    {
      get => this._su_AssignUser_Name;
      set
      {
        this._su_AssignUser_Name = value;
        this.Changed(nameof (su_AssignUser_Name));
      }
    }

    public string inEmpName
    {
      get => this._inEmpName;
      set
      {
        this._inEmpName = value;
        this.Changed(nameof (inEmpName));
      }
    }

    public string modEmpName
    {
      get => this._modEmpName;
      set
      {
        this._modEmpName = value;
        this.Changed(nameof (modEmpName));
      }
    }

    [JsonPropertyName("imageInfo")]
    public SupplierImageKind ImageInfo
    {
      get => this._ImageInfo ?? (this._ImageInfo = new SupplierImageKind(this.su_Supplier));
      set
      {
        this._ImageInfo = value;
        this.Changed(nameof (ImageInfo));
      }
    }

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
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
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.su_head_Name = string.Empty;
      this.su_head_ViewCode = string.Empty;
      this.su_AssignUser_Name = string.Empty;
      this.inEmpName = string.Empty;
      this.modEmpName = string.Empty;
      this.ImageInfo = (SupplierImageKind) null;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new SupplierView();

    public override object Clone()
    {
      SupplierView supplierView = base.Clone() as SupplierView;
      supplierView.su_head_Name = this.su_head_Name;
      supplierView.su_head_ViewCode = this.su_head_ViewCode;
      supplierView.su_AssignUser_Name = this.su_AssignUser_Name;
      supplierView.inEmpName = this.inEmpName;
      supplierView.modEmpName = this.modEmpName;
      supplierView.ImageInfo = (SupplierImageKind) null;
      if (this.su_Supplier > 0 && this.ImageInfo.Count > 0)
        supplierView.ImageInfo.AddRange((IEnumerable<SupplierImageView>) this.ImageInfo);
      return (object) supplierView;
    }

    public void PutData(SupplierView pSource)
    {
      this.PutData((TSupplier) pSource);
      this.su_head_Name = pSource.su_head_Name;
      this.su_head_ViewCode = pSource.su_head_ViewCode;
      this.su_AssignUser_Name = pSource.su_AssignUser_Name;
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
      this.ImageInfo = (SupplierImageKind) null;
      if (pSource.su_Supplier <= 0 || pSource.ImageInfo.Count <= 0)
        return;
      this.ImageInfo.AddRange((IEnumerable<SupplierImageView>) pSource.ImageInfo);
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.su_SiteID == 0L)
      {
        this.message = "싸이트(su_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (string.IsNullOrEmpty(this.su_SupplierName))
      {
        this.message = "업체명(su_SupplierName)  " + EnumDataCheck.Empty.ToDescription();
        return EnumDataCheck.Empty;
      }
      if (Enum2StrConverter.ToSupplierType(this.su_SupplierType) == EnumSupplierType.None)
      {
        this.message = "형태(su_SupplierType)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (Enum2StrConverter.ToSupplierKind(this.su_SupplierKind) == EnumSupplierKind.None)
      {
        this.message = "타입(su_SupplierKind)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (Enum2StrConverter.ToStdPreTax(this.su_PreTaxDiv) == EnumStdPreTax.None)
      {
        this.message = "기준단가(su_PreTaxDiv)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (Enum2StrConverter.ToSupplierMulti(this.su_MultiSuplierDiv) == EnumSupplierMulti.None)
      {
        this.message = "타사상품(su_MultiSuplierDiv)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (Enum2StrConverter.ToSupplierDeductionDayType(this.su_DeductionDayDiv) != EnumSupplierDeductionDayType.None)
        return EnumDataCheck.Success;
      this.message = "자동공제(su_DeductionDayDiv)  " + EnumDataCheck.CodeZero.ToDescription();
      return EnumDataCheck.CodeZero;
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
        if (string.IsNullOrEmpty(this.su_SupplierViewCode))
        {
          if (this.su_Supplier == 0 && !this.CreateCode(p_db))
          {
            this.message = "코드(su_Supplier)  " + EnumDataCheck.CodeZero.ToDescription();
            return EnumDataCheck.CodeZero;
          }
          p_param.Clear();
          p_param.Add((object) "su_SiteID", (object) this.su_SiteID);
          p_param.Add((object) "su_SupplierViewCode", (object) string.Format("{0:000000}", (object) this.su_Supplier));
          IList<SupplierView> supplierViewList1 = p_db.Create<SupplierView>().SelectListE<SupplierView>((object) p_param);
          if (supplierViewList1 != null && supplierViewList1.Count > 0)
          {
            bool flag = false;
            foreach (SupplierView supplierView in (IEnumerable<SupplierView>) supplierViewList1)
            {
              if (supplierView.su_Supplier != this.su_Supplier)
              {
                this.message = "식별코드(su_SupplierViewCode) " + EnumDataCheck.Exists.ToDescription() + string.Format("\n - {0}({1}) {2} 사용중.", (object) supplierView.su_SupplierName, (object) supplierView.su_Supplier, (object) EnumDataCheck.Exists.ToDescription());
                flag = true;
              }
            }
            if (flag)
            {
              p_param.Clear();
              p_param.Add((object) "su_SiteID", (object) this.su_SiteID);
              p_param.Add((object) "su_SupplierViewCode", (object) string.Format("9{0:00000}", (object) this.su_Supplier));
              IList<SupplierView> supplierViewList2 = p_db.Create<SupplierView>().SelectListE<SupplierView>((object) p_param);
              if (supplierViewList2 != null && supplierViewList2.Count > 0)
              {
                foreach (TSupplier tsupplier in (IEnumerable<SupplierView>) supplierViewList2)
                {
                  if (tsupplier.su_Supplier != this.su_Supplier)
                    return EnumDataCheck.Exists;
                }
              }
            }
          }
        }
      }
      else if (this.IsUpdate && !string.IsNullOrEmpty(this.su_SupplierViewCode))
      {
        p_param.Clear();
        p_param.Add((object) "su_SiteID", (object) this.su_SiteID);
        p_param.Add((object) "su_SupplierViewCode", (object) this.su_SupplierViewCode);
        IList<SupplierView> supplierViewList = p_db.Create<SupplierView>().SelectListE<SupplierView>((object) p_param);
        if (supplierViewList != null && supplierViewList.Count > 0)
        {
          foreach (SupplierView supplierView in (IEnumerable<SupplierView>) supplierViewList)
          {
            if (supplierView.su_Supplier != this.su_Supplier)
            {
              this.message = "식별코드(su_SupplierViewCode) " + EnumDataCheck.Exists.ToDescription() + string.Format("\n - {0}({1}) {2} 사용중.", (object) supplierView.su_SupplierName, (object) supplierView.su_Supplier, (object) EnumDataCheck.Exists.ToDescription());
              return EnumDataCheck.Exists;
            }
          }
        }
      }
      if (this.su_HeadSupplier > 0 && this.su_Supplier != this.su_HeadSupplier)
      {
        p_param.Clear();
        p_param.Add((object) "su_SiteID", (object) this.su_SiteID);
        p_param.Add((object) "su_Supplier", (object) this.su_Supplier);
        p_param.Add((object) "_IS_NOT_SUPPLIER_", (object) this.su_Supplier);
        IList<SupplierView> supplierViewList3 = p_db.Create<SupplierView>().SelectListE<SupplierView>((object) p_param);
        if (supplierViewList3 != null && supplierViewList3.Count > 0)
        {
          this.message = "코드(su_Supplier)  " + EnumDataCheck.Valid.ToDescription() + string.Format("\n이미 {0}({1}건)대표업체 등록 되어있습니다.", (object) supplierViewList3[0].su_SupplierName, (object) supplierViewList3.Count);
          return EnumDataCheck.Valid;
        }
        p_param.Clear();
        p_param.Add((object) "su_SiteID", (object) this.su_SiteID);
        p_param.Add((object) "su_Supplier", (object) this.su_HeadSupplier);
        IList<SupplierView> supplierViewList4 = p_db.Create<SupplierView>().SelectListE<SupplierView>((object) p_param);
        if (supplierViewList4 != null && supplierViewList4.Count == 0)
        {
          this.message = "대표코드(su_HeadSupplier)  " + EnumDataCheck.Valid.ToDescription();
          return EnumDataCheck.Valid;
        }
        if (supplierViewList4.Count > 1)
        {
          this.message = "대표코드(su_HeadSupplier)  " + EnumDataCheck.Exists.ToDescription() + string.Format("\n이미 {0}({1}건)대표업체 등록 되어있습니다.", (object) supplierViewList4[0].su_SupplierName, (object) supplierViewList4.Count);
          return EnumDataCheck.Exists;
        }
        if (supplierViewList4[0].su_HeadSupplier != supplierViewList4[0].su_Supplier)
        {
          this.message = "대표코드(su_HeadSupplier)  " + EnumDataCheck.Valid.ToDescription() + string.Format("{0}({1})는 대표업체가 아닙니다.", (object) supplierViewList4[0].su_SupplierName, (object) supplierViewList4[0].su_Supplier);
          return EnumDataCheck.Valid;
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
      if (!p_app_employee.IsSupplierSave)
      {
        this.message = p_app_employee.emp_Name + "님(Permit) 변경불가.";
        return false;
      }
      return EnumDataCheck.Success == this.DataCheck(this.OleDB);
    }

    public override string CreateCodeQuery()
    {
      base.CreateCodeQuery();
      return " SELECT " + DbQueryHelper.ToIsNULL() + "(MAX(su_Supplier), 0)+1 AS su_Supplier" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode, (object) DbQueryHelper.ToWithNolock());
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
          this.su_Supplier = uniOleDbRecordset.GetFieldInt(0);
        return this.su_Supplier > 0;
      }
      finally
      {
        uniOleDbRecordset?.Close();
        pOleDB?.Close();
      }
    }

    public override async Task<bool> CreateCodeAsync(UniOleDatabase p_db)
    {
      SupplierView supplierView = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(p_db.ConnectionUrl);
        rs = new UniOleDbRecordset(db, db.CommandTimeout);
        if (!await rs.OpenAsync(supplierView.CreateCodeQuery()))
        {
          supplierView.message = " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + supplierView.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) db.LastErrorID) + " 내용 : " + db.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          return false;
        }
        if (await rs.IsDataReadAsync())
          supplierView.su_Supplier = rs.GetFieldInt(0);
        return supplierView.su_Supplier > 0;
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    private string MergeStoreQueryMsSQL()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format("MERGE INTO {0}{1} AS T_STORE", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.StoreInfo));
      stringBuilder.Append(string.Format(" USING (SELECT * FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode, (object) DbQueryHelper.ToWithNolock()) + string.Format(" WHERE {0}={1}) AS T_SUP ", (object) "su_Supplier", (object) this.su_Supplier) + " ON T_STORE.si_StoreCode = T_SUP.su_Supplier");
      stringBuilder.Append(" WHEN MATCHED THEN UPDATE SET");
      stringBuilder.Append(" si_StoreViewCode='" + this.su_SupplierViewCode + "'");
      stringBuilder.Append(",si_StoreName='" + this.su_SupplierName + "'");
      stringBuilder.Append(",si_Tel1='" + this.su_Tel + "'");
      stringBuilder.Append(",si_Tel2='" + this.su_Fax + "'");
      stringBuilder.Append(",si_UseYn='" + this.su_UseYn + "'");
      stringBuilder.Append(",si_ErpCode='" + this.su_ErpCode + "'");
      stringBuilder.Append(",si_BizNo='" + this.su_BizNo + "'");
      stringBuilder.Append(",si_BizName='" + this.su_BizName + "'");
      stringBuilder.Append(",si_BizCeo='" + this.su_BizCeo + "'");
      stringBuilder.Append(",si_BizType='" + this.su_BizType + "'");
      stringBuilder.Append(",si_BizCategory='" + this.su_BizCategory + "'");
      stringBuilder.Append(",si_BizAddr1='" + this.su_Addr1 + "'");
      stringBuilder.Append(",si_BizAddr2='" + this.su_Addr2 + "'");
      stringBuilder.Append(",si_ZipCode='" + this.su_ZipCode + "'");
      stringBuilder.Append(",si_ModDate=" + new DateTime?(DateTime.Now).GetDateToStrInNull());
      stringBuilder.Append(string.Format(",{0}='{1}'", (object) "si_ModUser", (object) this.su_ModUser));
      stringBuilder.Append(" WHEN NOT MATCHED THEN INSERT ( si_StoreCode,si_SiteID,si_StoreType,si_StoreViewCode,si_StoreName,si_Tel1,si_Tel2,si_LocalIP,si_PublicIP,si_UseYn,si_ErpCode,si_BizNo,si_BizName,si_BizCeo,si_BizType,si_BizCategory,si_BizAddr1,si_BizAddr2,si_ZipCode,si_SortNo,si_MemberMntStore,si_WeatherCode,si_Email,si_EmailPwd,si_LocationUseYn,si_AutoOrderSafetyFactor,si_AutoOrderOpt,si_AutoOrderRef,si_InDate,si_InUser) VALUES (" + string.Format(" {0}", (object) this.su_Supplier) + string.Format(",{0},{1},'{2}','{3}'", (object) this.su_SiteID, (object) 2, (object) this.su_SupplierViewCode, (object) this.su_SupplierName) + ",'" + this.su_Tel + "','" + this.su_Fax + "','','','" + this.su_UseYn + "','" + this.su_ErpCode + "','" + this.su_BizNo + "','" + this.su_BizName + "','" + this.su_BizCeo + "','" + this.su_BizType + "','" + this.su_BizCategory + "','" + this.su_Addr1 + "','" + this.su_Addr2 + "','" + this.su_ZipCode + "'" + string.Format(",{0},{1},''", (object) 0, (object) this.su_Supplier) + ",'','','N',0.0,0,0" + string.Format(",{0},{1}", (object) new DateTime?(DateTime.Now).GetDateToStrInNull(), (object) this.su_InUser) + "); ");
      return stringBuilder.ToString();
    }

    private string MergeStoreQueryMySQL()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format("INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.StoreInfo) + " si_StoreCode,si_SiteID,si_StoreType,si_StoreViewCode,si_StoreName,si_Tel1,si_Tel2,si_LocalIP,si_PublicIP,si_UseYn,si_ErpCode,si_BizNo,si_BizName,si_BizCeo,si_BizType,si_BizCategory,si_BizAddr1,si_BizAddr2,si_ZipCode,si_SortNo,si_MemberMntStore,si_WeatherCode,si_Email,si_EmailPwd,si_LocationUseYn,si_AutoOrderSafetyFactor,si_AutoOrderOpt,si_AutoOrderRef,si_InDate,si_InUser) VALUES (" + string.Format(" {0}", (object) this.su_Supplier) + string.Format(",{0},{1},'{2}','{3}'", (object) this.su_SiteID, (object) 2, (object) this.su_SupplierViewCode, (object) this.su_SupplierName) + ",'" + this.su_Tel + "','" + this.su_Fax + "','','','" + this.su_UseYn + "','" + this.su_ErpCode + "','" + this.su_BizNo + "','" + this.su_BizName + "','" + this.su_BizCeo + "','" + this.su_BizType + "','" + this.su_BizCategory + "','" + this.su_Addr1 + "','" + this.su_Addr2 + "','" + this.su_ZipCode + "'" + string.Format(",{0},{1},''", (object) 0, (object) this.su_Supplier) + ",'','','N',0.0,0,0" + string.Format(",{0},{1}", (object) new DateTime?(DateTime.Now).GetDateToStrInNull(), (object) this.su_InUser) + ") ON DUPLICATE KEY UPDATE ");
      stringBuilder.Append(" si_StoreViewCode='" + this.su_SupplierViewCode + "'");
      stringBuilder.Append(",si_StoreName='" + this.su_SupplierName + "'");
      stringBuilder.Append(",si_Tel1='" + this.su_Tel + "'");
      stringBuilder.Append(",si_Tel2='" + this.su_Fax + "'");
      stringBuilder.Append(",si_UseYn='" + this.su_UseYn + "'");
      stringBuilder.Append(",si_ErpCode='" + this.su_ErpCode + "'");
      stringBuilder.Append(",si_BizNo='" + this.su_BizNo + "'");
      stringBuilder.Append(",si_BizName='" + this.su_BizName + "'");
      stringBuilder.Append(",si_BizCeo='" + this.su_BizCeo + "'");
      stringBuilder.Append(",si_BizType='" + this.su_BizType + "'");
      stringBuilder.Append(",si_BizCategory='" + this.su_BizCategory + "'");
      stringBuilder.Append(",si_BizAddr1='" + this.su_Addr1 + "'");
      stringBuilder.Append(",si_BizAddr2='" + this.su_Addr2 + "'");
      stringBuilder.Append(",si_ZipCode='" + this.su_ZipCode + "'");
      stringBuilder.Append(",si_ModDate=" + new DateTime?(DateTime.Now).GetDateToStrInNull());
      stringBuilder.Append(string.Format(",{0}='{1}'", (object) "si_ModUser", (object) this.su_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public bool MergeStore()
    {
      if (this.su_Supplier == 0)
        return false;
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          return this.OleDB.Execute(this.MergeStoreQueryMsSQL());
        case EnumDB.MYSQL:
          return this.OleDB.Execute(this.MergeStoreQueryMySQL());
        default:
          return false;
      }
    }

    public async Task<bool> MergeStoreAsync()
    {
      SupplierView supplierView = this;
      if (supplierView.su_Supplier == 0)
        return false;
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          return await supplierView.OleDB.ExecuteAsync(supplierView.MergeStoreQueryMsSQL());
        case EnumDB.MYSQL:
          return await supplierView.OleDB.ExecuteAsync(supplierView.MergeStoreQueryMySQL());
        default:
          return false;
      }
    }

    public override bool Insert() => (this.su_Supplier != 0 || this.CreateCode(this.OleDB)) && base.Insert() && this.MergeStore() && this.SetSuccessInfo(string.Format("({0},{1}) 등록됨.", (object) this.su_Supplier, (object) this.su_SiteID));

    public override async Task<bool> InsertAsync()
    {
      SupplierView supplierView = this;
      if (supplierView.su_Supplier == 0)
      {
        if (!await supplierView.CreateCodeAsync(supplierView.OleDB))
          return false;
      }
      // ISSUE: reference to a compiler-generated method
      return await supplierView.\u003C\u003En__0() && await supplierView.MergeStoreAsync() && supplierView.SetSuccessInfo(string.Format("({0},{1}) 등록됨.", (object) supplierView.su_Supplier, (object) supplierView.su_SiteID));
    }

    public override bool Update(UbModelBase p_old = null) => base.Update(p_old) && this.MergeStore() && this.SetSuccessInfo(string.Format("({0},{1}) 변경됨.", (object) this.su_Supplier, (object) this.su_SiteID));

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      SupplierView supplierView = this;
      // ISSUE: reference to a compiler-generated method
      return await supplierView.\u003C\u003En__1(p_old) && await supplierView.MergeStoreAsync() && supplierView.SetSuccessInfo(string.Format("({0},{1}) 변경됨.", (object) supplierView.su_Supplier, (object) supplierView.su_SiteID));
    }

    public override bool UpdateExInsert() => base.UpdateExInsert() && this.SetSuccessInfo(string.Format("({0},{1}) 변경됨.", (object) this.su_Supplier, (object) this.su_SiteID));

    public override async Task<bool> UpdateExInsertAsync()
    {
      SupplierView supplierView = this;
      // ISSUE: reference to a compiler-generated method
      return await supplierView.\u003C\u003En__2() && supplierView.SetSuccessInfo(string.Format("({0},{1}) 변경됨.", (object) supplierView.su_Supplier, (object) supplierView.su_SiteID));
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
          if (this.su_SiteID == 0L)
            this.su_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (this.su_Supplier == 0 && !this.CreateCode(p_db))
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 코드 생성 오류", 2);
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!this.Insert())
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 등록 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        this.db_status = 4;
        this.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        this.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        this.message = ex.Message;
      }
      return false;
    }

    public override async Task<bool> InsertDataAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      SupplierView supplierView = this;
      try
      {
        supplierView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != supplierView.DataCheck(p_db))
            throw new UniServiceException(supplierView.message, supplierView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (supplierView.su_SiteID == 0L)
            supplierView.su_SiteID = p_app_employee.emp_SiteID;
          if (!supplierView.IsPermit(p_app_employee))
            throw new UniServiceException(supplierView.message, supplierView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (supplierView.su_Supplier == 0)
        {
          if (!await supplierView.CreateCodeAsync(p_db))
            throw new UniServiceException(supplierView.message, supplierView.TableCode.ToDescription() + " 코드 생성 오류", 2);
        }
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await supplierView.InsertAsync())
          throw new UniServiceException(supplierView.message, supplierView.TableCode.ToDescription() + " 등록 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        supplierView.db_status = 4;
        supplierView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        supplierView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        supplierView.message = ex.Message;
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
        if (this.su_Supplier == 0)
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 코드(su_Supplier)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!this.Update())
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 변경 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        this.db_status = 4;
        this.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        this.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        this.message = ex.Message;
      }
      return false;
    }

    public override async Task<bool> UpdateDataAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      SupplierView supplierView = this;
      try
      {
        supplierView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != supplierView.DataCheck(p_db))
            throw new UniServiceException(supplierView.message, supplierView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!supplierView.IsPermit(p_app_employee))
          throw new UniServiceException(supplierView.message, supplierView.TableCode.ToDescription() + " 권한 검사 실패");
        if (supplierView.su_Supplier == 0)
          throw new UniServiceException(supplierView.message, supplierView.TableCode.ToDescription() + " 코드(su_Supplier)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await supplierView.UpdateAsync())
          throw new UniServiceException(supplierView.message, supplierView.TableCode.ToDescription() + " 변경 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        supplierView.db_status = 4;
        supplierView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        supplierView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        supplierView.message = ex.Message;
      }
      return false;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.su_head_Name = p_rs.GetFieldString("su_head_Name");
      this.su_head_ViewCode = p_rs.GetFieldString("su_head_ViewCode");
      this.su_AssignUser_Name = p_rs.GetFieldString("su_AssignUser_Name");
      this.inEmpName = p_rs.GetFieldString("inEmpName");
      this.modEmpName = p_rs.GetFieldString("modEmpName");
      return true;
    }

    public async Task<SupplierView> SelectOneAsync(int p_su_Supplier, long p_su_SiteID = 0)
    {
      SupplierView supplierView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "su_Supplier",
          (object) p_su_Supplier
        }
      };
      if (p_su_SiteID > 0L)
        p_param.Add((object) "su_SiteID", (object) p_su_SiteID);
      return await supplierView.SelectOneTAsync<SupplierView>((object) p_param);
    }

    public async Task<IList<SupplierView>> SelectListAsync(object p_param)
    {
      SupplierView supplierView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(supplierView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, supplierView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(supplierView1.GetSelectQuery(p_param)))
        {
          supplierView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + supplierView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<SupplierView>) null;
        }
        IList<SupplierView> lt_list = (IList<SupplierView>) new List<SupplierView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            SupplierView supplierView2 = supplierView1.OleDB.Create<SupplierView>();
            if (supplierView2.GetFieldValues(rs))
            {
              supplierView2.row_number = lt_list.Count + 1;
              lt_list.Add(supplierView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + supplierView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
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
      if (p_param is Hashtable hashtable && hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
      {
        stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "su_SupplierName", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "su_SupplierViewCode", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "su_BizCeo", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "su_BizNo", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "su_BizName", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "su_Tel", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "su_Fax", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "su_Memo1", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "su_Memo2", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(")");
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
          if (hashtable.ContainsKey((object) "su_SiteID") && Convert.ToInt64(hashtable[(object) "su_SiteID"].ToString()) > 0L)
            num = Convert.ToInt64(hashtable[(object) "su_SiteID"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS ( SELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_EMPLOYEE_MOD AS ( SELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_EMPLOYEE_ASSIGN AS ( SELECT emp_Code AS emp_CodeAssign,emp_Name AS su_AssignUser_Name" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_HEADER AS ( SELECT su_Supplier AS su_head_Supplier,su_SupplierName AS su_head_Name,su_SupplierViewCode AS su_head_ViewCode FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock() + " WHERE su_Supplier=su_HeadSupplier");
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "su_SiteID", (object) num));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(" SELECT  su_Supplier,su_SiteID,su_HeadSupplier,su_SupplierViewCode,su_SupplierName,su_SupplierType,su_SupplierKind,su_UseYn,su_PreTaxDiv,su_MultiSuplierDiv,su_DeductionDayDiv,su_NewStatementYn,su_Tel,su_Fax,su_BizNo,su_BizName,su_BizCeo,su_BizType,su_BizCategory,su_RegidentNo,su_Addr1,su_Addr2,su_ZipCode,su_ContactNm1,su_ContactMemo1,su_ContactEmail1,su_ContactNm2,su_ContactMemo2,su_ContactEmail2,su_BankCode,su_AccountNo,su_AccountName,su_Memo1,su_Memo2,su_LeadTime,su_Deposit,su_ErpCode,su_EmailStatement,su_EmailTax,su_AssignUser,su_InDate,su_InUser,su_ModDate,su_ModUser,su_head_Name,su_head_ViewCode,su_AssignUser_Name,inEmpName,modEmpName\n FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock() + " LEFT OUTER JOIN T_EMPLOYEE_IN ON su_InUser=emp_CodeIn LEFT OUTER JOIN T_EMPLOYEE_MOD ON su_ModUser=emp_CodeMod LEFT OUTER JOIN T_EMPLOYEE_ASSIGN ON su_AssignUser=emp_CodeAssign LEFT OUTER JOIN T_HEADER ON su_HeadSupplier=su_head_Supplier");
        stringBuilder.Append("\n");
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append(" ORDER BY " + empty);
        else
          stringBuilder.Append(" ORDER BY su_SupplierName,su_Supplier");
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
