// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Inventory.InventoryHeaderView
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
using UniBiz.Bo.Models.UniBase.Store.StoreInfo;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniStock.Inventory
{
  public class InventoryHeaderView : TInventoryHeader<InventoryHeaderView>
  {
    private string _si_StoreName;
    private string _si_StoreViewCode;
    private string _si_UseYn;
    private int _si_StoreType;
    private string _si_LocationUseYn;
    private string _si_Email;
    private string _ih_EmpName;
    private string _inEmpName;
    private string _modEmpName;
    private IList<InventoryDetailView> _Lt_Details;

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

    public int si_StoreType
    {
      get => this._si_StoreType;
      set
      {
        this._si_StoreType = value;
        this.Changed(nameof (si_StoreType));
        this.Changed("si_StoreTypeDesc");
      }
    }

    public string si_StoreTypeDesc => this.si_StoreType != 0 ? Enum2StrConverter.ToStoreType(this.si_StoreType).ToDescription() : string.Empty;

    public string si_LocationUseYn
    {
      get => this._si_LocationUseYn;
      set
      {
        this._si_LocationUseYn = value;
        this.Changed(nameof (si_LocationUseYn));
      }
    }

    public string si_Email
    {
      get => this._si_Email;
      set
      {
        this._si_Email = value;
        this.Changed(nameof (si_Email));
      }
    }

    public string ih_EmpName
    {
      get => this._ih_EmpName;
      set
      {
        this._ih_EmpName = value;
        this.Changed(nameof (ih_EmpName));
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

    [JsonPropertyName("lt_Details")]
    public IList<InventoryDetailView> Lt_Details
    {
      get => this._Lt_Details ?? (this._Lt_Details = (IList<InventoryDetailView>) new List<InventoryDetailView>());
      set
      {
        this._Lt_Details = value;
        this.Changed(nameof (Lt_Details));
      }
    }

    public override Dictionary<string, TTableColumn> ToColumnInfo() => base.ToColumnInfo();

    public override void Clear()
    {
      base.Clear();
      this.si_StoreName = string.Empty;
      this.si_StoreViewCode = string.Empty;
      this.si_UseYn = "Y";
      this.si_StoreType = 0;
      this.si_LocationUseYn = string.Empty;
      this.si_Email = string.Empty;
      this.ih_EmpName = string.Empty;
      this.inEmpName = string.Empty;
      this.modEmpName = string.Empty;
      this.Lt_Details = (IList<InventoryDetailView>) null;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new InventoryHeaderView();

    public override object Clone()
    {
      InventoryHeaderView inventoryHeaderView = base.Clone() as InventoryHeaderView;
      inventoryHeaderView.si_StoreName = this.si_StoreName;
      inventoryHeaderView.si_StoreViewCode = this.si_StoreViewCode;
      inventoryHeaderView.si_UseYn = this.si_UseYn;
      inventoryHeaderView.si_StoreType = this.si_StoreType;
      inventoryHeaderView.si_LocationUseYn = this.si_LocationUseYn;
      inventoryHeaderView.si_Email = this.si_Email;
      inventoryHeaderView.ih_EmpName = this.ih_EmpName;
      inventoryHeaderView.inEmpName = this.inEmpName;
      inventoryHeaderView.modEmpName = this.modEmpName;
      inventoryHeaderView.Lt_Details = (IList<InventoryDetailView>) null;
      if (this.Lt_Details.Count > 0)
        inventoryHeaderView.Lt_Details = this.Lt_Details;
      return (object) inventoryHeaderView;
    }

    public void PutData(InventoryHeaderView pSource)
    {
      this.PutData((TInventoryHeader) pSource);
      this.si_StoreName = pSource.si_StoreName;
      this.si_StoreViewCode = pSource.si_StoreViewCode;
      this.si_UseYn = pSource.si_UseYn;
      this.si_StoreType = pSource.si_StoreType;
      this.si_LocationUseYn = pSource.si_LocationUseYn;
      this.si_Email = pSource.si_Email;
      this.ih_EmpName = pSource.ih_EmpName;
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
      this.Lt_Details = (IList<InventoryDetailView>) null;
      if (pSource.Lt_Details.Count <= 0)
        return;
      foreach (InventoryDetailView ltDetail in (IEnumerable<InventoryDetailView>) pSource.Lt_Details)
      {
        InventoryDetailView inventoryDetailView = new InventoryDetailView();
        inventoryDetailView.PutData(ltDetail);
        this.Lt_Details.Add(inventoryDetailView);
      }
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.ih_SiteID == 0L)
      {
        this.message = "싸이트(ih_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.ih_StoreCode == 0)
      {
        this.message = "지점(ih_StoreCode)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      DateTime? nullable = this.ih_InventoryDate;
      if (!nullable.HasValue)
      {
        this.message = "재고조사일자(ih_InventoryDate)  " + EnumDataCheck.NULL.ToDescription();
        return EnumDataCheck.NULL;
      }
      nullable = this.ih_ApplyDate;
      if (!nullable.HasValue)
      {
        this.message = "변환일시(ih_ApplyDate)  " + EnumDataCheck.NULL.ToDescription();
        return EnumDataCheck.NULL;
      }
      if (Enum2StrConverter.ToStatementConfirmStatus(this.ih_InventoryStatus) == EnumStatementConfirmStatus.None)
      {
        this.message = "재고확정(ih_InventoryStatus) " + EnumDataCheck.Valid.ToDescription();
        return EnumDataCheck.Valid;
      }
      if (Enum2StrConverter.ToInventoryApplyType(this.ih_ApplyType) == EnumInventoryApplyType.None)
      {
        this.message = "변환구분(ih_ApplyType) " + EnumDataCheck.Valid.ToDescription();
        return EnumDataCheck.Valid;
      }
      if (Enum2StrConverter.ToStockUnit(this.ih_StockUnit) != EnumStockUnit.NONE)
        return EnumDataCheck.Success;
      this.message = "재고단위(ih_StockUnit) " + EnumDataCheck.Valid.ToDescription();
      return EnumDataCheck.Valid;
    }

    protected override EnumDataCheck DataCheck(UniOleDatabase p_db) => base.DataCheck(p_db);

    protected override bool IsPermit(EmployeeView p_app_employee)
    {
      if (p_app_employee == null)
      {
        this.message = "사용자 정보 NULL.";
        return false;
      }
      if (!p_app_employee.IsStockInventory)
      {
        this.message = p_app_employee.emp_Name + "님(Permit) 변경불가.";
        return false;
      }
      return EnumDataCheck.Success == this.DataCheck(this.OleDB);
    }

    public override string CreateCodeQuery()
    {
      base.CreateCodeQuery();
      int intFormat = this.ih_InventoryDate.Value.ToIntFormat();
      string str = string.Format("{0}{1:D4}0000", (object) intFormat, (object) this.ih_StoreCode);
      return " SELECT " + DbQueryHelper.ToIsNULL() + "(MAX(ih_StatementNo), " + str + ")+1 AS ih_StatementNo" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) this.TableCode, (object) DbQueryHelper.ToWithNolock()) + string.Format(" WHERE ({0}/100000000)={1}", (object) "ih_StatementNo", (object) intFormat) + string.Format(" AND ((({0}%100000000)/10000)={1}", (object) "ih_StatementNo", (object) this.ih_StoreCode);
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
          this.ih_StatementNo = uniOleDbRecordset.GetFieldLong(0);
        return this.ih_StatementNo > 0L;
      }
      finally
      {
        uniOleDbRecordset?.Close();
        pOleDB?.Close();
      }
    }

    public override async Task<bool> CreateCodeAsync(UniOleDatabase p_db)
    {
      InventoryHeaderView inventoryHeaderView = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(p_db.ConnectionUrl);
        rs = new UniOleDbRecordset(db, db.CommandTimeout);
        if (!await rs.OpenAsync(inventoryHeaderView.CreateCodeQuery()))
        {
          inventoryHeaderView.message = " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + inventoryHeaderView.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) db.LastErrorID) + " 내용 : " + db.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          return false;
        }
        if (await rs.IsDataReadAsync())
          inventoryHeaderView.ih_StatementNo = rs.GetFieldLong(0);
        return inventoryHeaderView.ih_StatementNo > 0L;
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public void CalcSum(bool p_isCalcDetail)
    {
      this.ih_GoodsCount = 0;
      this.ih_CostAmt = this.ih_CostVatAmt = 0.0;
      this.ih_AvgCostAmt = this.ih_AvgCostVatAmt = 0.0;
      this.ih_PriceAmt = 0.0;
      this.ih_CostAmt = CalcHelper.CalcDoubleToFormatDouble(this.ih_CostAmt);
      this.ih_CostVatAmt = CalcHelper.CalcDoubleToFormatDouble(this.ih_CostVatAmt);
      this.ih_AvgCostAmt = CalcHelper.CalcDoubleToFormatDouble(this.ih_AvgCostAmt);
      this.ih_AvgCostVatAmt = CalcHelper.CalcDoubleToFormatDouble(this.ih_AvgCostVatAmt);
      this.ih_PriceAmt = CalcHelper.CalcDoubleToFormatDouble(this.ih_PriceAmt);
    }

    public virtual bool InsertDetails(UniOleDatabase p_db, EmployeeView p_app_employee)
    {
      if (this.Lt_Details.Count == 0)
      {
        this.message = "전표 상세 데이터 부족.  " + EnumDataCheck.NULL.ToDescription();
        return false;
      }
      int num1 = 1;
      int num2 = -1;
      foreach (InventoryDetailView ltDetail in (IEnumerable<InventoryDetailView>) this.Lt_Details)
      {
        if (ltDetail.id_GoodsCode == 0L)
        {
          this.message = string.Format("{0}번째 항목이 상품코드 확인.  {1}", (object) ltDetail.id_Seq, (object) EnumDataCheck.Valid.ToDescription());
          return false;
        }
        if (ltDetail.id_Seq > 0)
        {
          if (num1 != ltDetail.id_Seq)
            num1 = ltDetail.id_Seq;
        }
        else
        {
          ltDetail.id_Seq = num1;
          ltDetail.db_status = 1;
        }
        if (ltDetail.id_StatementNo == 0L)
        {
          ltDetail.id_StatementNo = this.ih_StatementNo;
          ltDetail.db_status = 1;
        }
        if (ltDetail.id_IsPackUnitBOM)
          num2 = ltDetail.id_Seq;
        else if (ltDetail.id_LinkRowNCount > 0 && ltDetail.id_IsPackUnitEA && ltDetail.id_LinkRowNCount != num2)
        {
          ltDetail.id_LinkRowNCount = num2;
          if (!ltDetail.IsNew)
            ltDetail.db_status = 2;
        }
        if (p_app_employee != null && p_app_employee.emp_Code > 0)
        {
          if (ltDetail.IsNew)
            ltDetail.id_InUser = p_app_employee.emp_Code;
          else if (ltDetail.IsUpdate)
            ltDetail.id_ModUser = p_app_employee.emp_Code;
        }
        ltDetail.SetAdoDatabase(p_db);
        if (ltDetail.DataCheckOn(p_db) != EnumDataCheck.Success)
        {
          this.message = ltDetail.message;
          return false;
        }
        if (ltDetail.IsNew)
        {
          if (!ltDetail.Insert())
          {
            this.message = string.Format("{0}행 {1}항목 신규등록 에러", (object) ltDetail.id_Seq, (object) ltDetail.id_BarCode);
            throw new Exception(this.message);
          }
        }
        else if (ltDetail.IsUpdate && !ltDetail.Update((UbModelBase) null))
        {
          this.message = string.Format("{0}행 {1}항목 데이터 변경 에러", (object) ltDetail.id_Seq, (object) ltDetail.id_BarCode);
          throw new Exception(this.message);
        }
        ++num1;
      }
      return true;
    }

    public async Task<bool> InsertDetailsAsync(UniOleDatabase p_db, EmployeeView p_app_employee)
    {
      InventoryHeaderView inventoryHeaderView = this;
      if (inventoryHeaderView.Lt_Details.Count == 0)
      {
        inventoryHeaderView.message = "전표 상세 데이터 부족.  " + EnumDataCheck.NULL.ToDescription();
        return false;
      }
      int nCount = 1;
      int nLastBomSeq = -1;
      foreach (InventoryDetailView ltDetail in (IEnumerable<InventoryDetailView>) inventoryHeaderView.Lt_Details)
      {
        InventoryDetailView item = ltDetail;
        if (item.id_GoodsCode == 0L)
        {
          inventoryHeaderView.message = string.Format("{0}번째 항목이 상품코드 확인.  {1}", (object) item.id_Seq, (object) EnumDataCheck.Valid.ToDescription());
          return false;
        }
        if (item.id_Seq > 0)
        {
          if (nCount != item.id_Seq)
            nCount = item.id_Seq;
        }
        else
        {
          item.id_Seq = nCount;
          item.db_status = 1;
        }
        if (item.id_StatementNo == 0L)
        {
          item.id_StatementNo = inventoryHeaderView.ih_StatementNo;
          item.db_status = 1;
        }
        if (item.id_IsPackUnitBOM)
          nLastBomSeq = item.id_Seq;
        else if (item.id_LinkRowNCount > 0 && item.id_IsPackUnitEA && item.id_LinkRowNCount != nLastBomSeq)
        {
          item.id_LinkRowNCount = nLastBomSeq;
          if (!item.IsNew)
            item.db_status = 2;
        }
        if (p_app_employee != null && p_app_employee.emp_Code > 0)
        {
          if (item.IsNew)
            item.id_InUser = p_app_employee.emp_Code;
          else if (item.IsUpdate)
            item.id_ModUser = p_app_employee.emp_Code;
        }
        item.SetAdoDatabase(p_db);
        if (item.DataCheckOn(p_db) != EnumDataCheck.Success)
        {
          inventoryHeaderView.message = item.message;
          return false;
        }
        if (item.IsNew)
        {
          if (!await item.InsertAsync())
          {
            inventoryHeaderView.message = string.Format("{0}행 {1}항목 신규등록 에러", (object) item.id_Seq, (object) item.id_BarCode);
            throw new Exception(inventoryHeaderView.message);
          }
        }
        else if (item.IsUpdate)
        {
          if (!await item.UpdateAsync((UbModelBase) null))
          {
            inventoryHeaderView.message = string.Format("{0}행 {1}항목 데이터 변경 에러", (object) item.id_Seq, (object) item.id_BarCode);
            throw new Exception(inventoryHeaderView.message);
          }
        }
        ++nCount;
        item = (InventoryDetailView) null;
      }
      return true;
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
          if (this.ih_SiteID == 0L)
            this.ih_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (this.ih_StatementNo == 0L && !this.CreateCode(p_db))
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 코드 생성 오류", 2);
        this.CalcSum(true);
        if (!this.Insert())
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 등록 오류");
        if (!this.InsertDetails(p_db, p_app_employee))
          throw new Exception(this.message);
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
      InventoryHeaderView inventoryHeaderView = this;
      try
      {
        inventoryHeaderView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != inventoryHeaderView.DataCheck(p_db))
            throw new UniServiceException(inventoryHeaderView.message, inventoryHeaderView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (inventoryHeaderView.ih_SiteID == 0L)
            inventoryHeaderView.ih_SiteID = p_app_employee.emp_SiteID;
          if (!inventoryHeaderView.IsPermit(p_app_employee))
            throw new UniServiceException(inventoryHeaderView.message, inventoryHeaderView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (inventoryHeaderView.ih_StatementNo == 0L)
        {
          if (!await inventoryHeaderView.CreateCodeAsync(p_db))
            throw new UniServiceException(inventoryHeaderView.message, inventoryHeaderView.TableCode.ToDescription() + " 코드 생성 오류", 2);
        }
        inventoryHeaderView.CalcSum(true);
        if (!await inventoryHeaderView.InsertAsync())
          throw new UniServiceException(inventoryHeaderView.message, inventoryHeaderView.TableCode.ToDescription() + " 등록 오류");
        if (!await inventoryHeaderView.InsertDetailsAsync(p_db, p_app_employee))
          throw new Exception(inventoryHeaderView.message);
        inventoryHeaderView.db_status = 4;
        inventoryHeaderView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        inventoryHeaderView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        inventoryHeaderView.message = ex.Message;
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
        if (this.ih_StatementNo == 0L)
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 재고조사전표번호(ih_StatementNo) " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        this.CalcSum(true);
        if (!this.Update())
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 변경 오류");
        if (!this.InsertDetails(p_db, p_app_employee))
          throw new Exception(this.message);
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
      InventoryHeaderView inventoryHeaderView = this;
      try
      {
        inventoryHeaderView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != inventoryHeaderView.DataCheck(p_db))
            throw new UniServiceException(inventoryHeaderView.message, inventoryHeaderView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!inventoryHeaderView.IsPermit(p_app_employee))
          throw new UniServiceException(inventoryHeaderView.message, inventoryHeaderView.TableCode.ToDescription() + " 권한 검사 실패");
        if (inventoryHeaderView.ih_StatementNo == 0L)
          throw new UniServiceException(inventoryHeaderView.message, inventoryHeaderView.TableCode.ToDescription() + " 재고조사전표번호(ih_StatementNo) " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        inventoryHeaderView.CalcSum(true);
        if (!await inventoryHeaderView.UpdateAsync())
          throw new UniServiceException(inventoryHeaderView.message, inventoryHeaderView.TableCode.ToDescription() + " 변경 오류");
        if (!await inventoryHeaderView.InsertDetailsAsync(p_db, p_app_employee))
          throw new Exception(inventoryHeaderView.message);
        inventoryHeaderView.db_status = 4;
        inventoryHeaderView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        inventoryHeaderView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        inventoryHeaderView.message = ex.Message;
      }
      return false;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.si_StoreViewCode = p_rs.GetFieldString("si_StoreViewCode");
      this.si_StoreName = p_rs.GetFieldString("si_StoreName");
      this.si_UseYn = p_rs.GetFieldString("si_UseYn");
      this.si_StoreType = p_rs.GetFieldInt("si_StoreType");
      this.si_LocationUseYn = p_rs.GetFieldString("si_LocationUseYn");
      this.si_Email = p_rs.GetFieldString("si_Email");
      this.ih_EmpName = p_rs.GetFieldString("ih_EmpName");
      this.inEmpName = p_rs.GetFieldString("inEmpName");
      this.modEmpName = p_rs.GetFieldString("modEmpName");
      return true;
    }

    public async Task<InventoryHeaderView> SelectOneAsync(long p_ih_StatementNo, long p_ih_SiteID = 0)
    {
      InventoryHeaderView inventoryHeaderView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "ih_StatementNo",
          (object) p_ih_StatementNo
        }
      };
      if (p_ih_SiteID > 0L)
        p_param.Add((object) "ih_SiteID", (object) p_ih_SiteID);
      return await inventoryHeaderView.SelectOneTAsync<InventoryHeaderView>((object) p_param);
    }

    public InventoryHeaderView SelectOne(long p_ih_StatementNo, long p_ih_SiteID = 0)
    {
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "ih_StatementNo",
          (object) p_ih_StatementNo
        }
      };
      if (p_ih_SiteID > 0L)
        p_param.Add((object) "ih_SiteID", (object) p_ih_SiteID);
      return this.SelectOneT<InventoryHeaderView>((object) p_param);
    }

    public async Task<IList<InventoryHeaderView>> SelectListAsync(object p_param)
    {
      InventoryHeaderView inventoryHeaderView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(inventoryHeaderView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, inventoryHeaderView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(inventoryHeaderView1.GetSelectQuery(p_param)))
        {
          inventoryHeaderView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + inventoryHeaderView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<InventoryHeaderView>) null;
        }
        IList<InventoryHeaderView> lt_list = (IList<InventoryHeaderView>) new List<InventoryHeaderView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            InventoryHeaderView inventoryHeaderView2 = inventoryHeaderView1.OleDB.Create<InventoryHeaderView>();
            if (inventoryHeaderView2.GetFieldValues(rs))
            {
              inventoryHeaderView2.row_number = lt_list.Count + 1;
              lt_list.Add(inventoryHeaderView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + inventoryHeaderView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<InventoryHeaderView> SelectEnumerableAsync(object p_param)
    {
      InventoryHeaderView inventoryHeaderView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(inventoryHeaderView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, inventoryHeaderView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(inventoryHeaderView1.GetSelectQuery(p_param)))
        {
          inventoryHeaderView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + inventoryHeaderView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            InventoryHeaderView inventoryHeaderView2 = inventoryHeaderView1.OleDB.Create<InventoryHeaderView>();
            if (inventoryHeaderView2.GetFieldValues(rs))
            {
              inventoryHeaderView2.row_number = ++row_number;
              yield return inventoryHeaderView2;
            }
          }
          while (await rs.IsDataReadAsync());
        }
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
        stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "ih_Title", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "ih_Memo", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(")");
      }
      return !stringBuilder.ToString().Equals(" WHERE") ? stringBuilder.Replace("WHERE AND", "WHERE").ToString() : string.Empty;
    }

    public override string GetSelectQuery(object p_param)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable hashtable1 = new Hashtable();
      try
      {
        string uniBase = UbModelBase.UNI_BASE;
        string str = this.TableCode.ToString();
        string empty = string.Empty;
        long p_SiteID = 0;
        if (p_param is Hashtable hashtable2)
        {
          if (hashtable2.ContainsKey((object) "DBMS") && hashtable2[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable2[(object) "DBMS"].ToString();
          if (hashtable2.ContainsKey((object) "table") && hashtable2[(object) "table"].ToString().Length > 0)
            str = hashtable2[(object) "table"].ToString();
          if (hashtable2.ContainsKey((object) "_ORDER_BY_COL_") && hashtable2[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable2[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable2.ContainsKey((object) "ih_SiteID") && Convert.ToInt64(hashtable2[(object) "ih_SiteID"].ToString()) > 0L)
            p_SiteID = Convert.ToInt64(hashtable2[(object) "ih_SiteID"].ToString());
        }
        stringBuilder.Append(this.ToWithStoreQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithEmployeeInQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithEmployeeModQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append(this.ToWithEmployeeAssignQuery(p_param, uniBase, p_SiteID));
        stringBuilder.Append("\n SELECT  ih_StatementNo,ih_SiteID,ih_StoreCode,ih_Title,ih_EmpCode,ih_InventoryStatus,ih_InventoryDate,ih_ApplyType,ih_ApplyDate,ih_DeviceType,ih_DeviceKey,ih_DeviceName,ih_GoodsCount,ih_CostAmt,ih_CostVatAmt,ih_AvgCostAmt,ih_AvgCostVatAmt,ih_PriceAmt,ih_PosNo,ih_TransNo,ih_LocationCode,ih_LocationCount,ih_StockUnit,ih_Memo,ih_MobileStatementNo,ih_InDate,ih_InUser,ih_ModDate,ih_ModUser\n,si_StoreName,si_StoreViewCode,si_StoreType,si_UseYn,si_Email,si_LocationUseYn\n,inEmpName,modEmpName,ih_EmpName");
        stringBuilder.Append("\n FROM " + DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK) + str + " " + DbQueryHelper.ToWithNolock() + "\n LEFT OUTER JOIN T_STORE ON ih_StoreCode=si_StoreCode AND ih_SiteID=si_SiteID\n LEFT OUTER JOIN T_EMPLOYEE_IN ON ih_InUser=emp_CodeIn\n LEFT OUTER JOIN T_EMPLOYEE_MOD ON ih_ModUser=emp_CodeMod\n LEFT OUTER JOIN T_EMPLOYEE_ASSIGN ON ih_EmpCode=emp_CodeAssign");
        stringBuilder.Append("\n");
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append(" ORDER BY " + empty);
        else
          stringBuilder.Append(" ORDER BY ih_StatementNo");
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) ex.GetHashCode()) + " 내용 : " + ex.Message + "\n" + string.Format(" Query : {0}\n", (object) stringBuilder) + "--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
        stringBuilder.Clear();
      }
      finally
      {
        hashtable1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithStoreQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("WITH T_STORE AS ( SELECT si_StoreCode,si_SiteID,si_StoreName,si_StoreViewCode,si_StoreType,si_UseYn,si_LocationUseYn,si_Email" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("ih_SiteID"))
            p_param1.Add((object) "si_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add((object) "si_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ih_StoreCode"))
            p_param1.Add((object) "si_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ih_StoreCode_IN_"))
            p_param1.Add((object) "si_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_STORE_AUTHS_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "si_SiteID"))
            p_param1.Add((object) "si_SiteID", (object) p_SiteID);
          stringBuilder.Append(new TStoreInfo().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format("  WHERE {0}={1}", (object) "si_SiteID", (object) p_SiteID));
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithEmployeeInQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_EMPLOYEE_IN AS ( SELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("ih_SiteID"))
            p_param1.Add((object) "emp_SiteID", dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "emp_SiteID"))
            p_param1.Add((object) "emp_SiteID", (object) p_SiteID);
          stringBuilder.Append(new TEmployee().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "emp_SiteID", (object) p_SiteID));
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithEmployeeModQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_EMPLOYEE_MOD AS ( SELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("ih_SiteID"))
            p_param1.Add((object) "emp_SiteID", dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "emp_SiteID"))
            p_param1.Add((object) "emp_SiteID", (object) p_SiteID);
          stringBuilder.Append(new TEmployee().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "emp_SiteID", (object) p_SiteID));
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }

    public string ToWithEmployeeAssignQuery(object p_param, string p_dbms, long p_SiteID)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        stringBuilder.Append("\n,T_EMPLOYEE_ASSIGN AS ( SELECT emp_Code AS emp_CodeAssign,emp_Name AS ih_EmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(p_dbms), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("ih_SiteID"))
            p_param1.Add((object) "emp_SiteID", dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "emp_SiteID"))
            p_param1.Add((object) "emp_SiteID", (object) p_SiteID);
          stringBuilder.Append(new TEmployee().GetSelectWhereAnd((object) p_param1));
        }
        else if (p_SiteID > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "emp_SiteID", (object) p_SiteID));
        stringBuilder.Append(")");
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }
  }
}
