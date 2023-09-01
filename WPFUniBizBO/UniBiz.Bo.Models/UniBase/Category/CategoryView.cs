// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Category.CategoryView
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using Serilog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.TableInfo;
using UniBiz.Bo.Models.UniBase.Dept;
using UniBiz.Bo.Models.UniBase.Employee.Employee;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniBase.Category
{
  public class CategoryView : TCategory<CategoryView>
  {
    private DeptView _DeptInfo;
    private int _ctg_lv1_ID;
    private string _ctg_lv1_ViewCode;
    private string _ctg_lv1_Name;
    private int _ctg_lv2_ID;
    private string _ctg_lv2_ViewCode;
    private string _ctg_lv2_Name;
    private string _ctg_ParentsName;
    private string _inEmpName;
    private string _modEmpName;
    private IList<CategoryView> _Lt_Detail;

    public DeptView DeptInfo
    {
      get => this._DeptInfo ?? (this._DeptInfo = new DeptView());
      set
      {
        this._DeptInfo = value;
        this.Changed(nameof (DeptInfo));
      }
    }

    public int ctg_lv1_ID
    {
      get => this._ctg_lv1_ID;
      set
      {
        this._ctg_lv1_ID = value;
        this.Changed(nameof (ctg_lv1_ID));
      }
    }

    public string ctg_lv1_ViewCode
    {
      get => this._ctg_lv1_ViewCode;
      set
      {
        this._ctg_lv1_ViewCode = value;
        this.Changed(nameof (ctg_lv1_ViewCode));
      }
    }

    public string ctg_lv1_Name
    {
      get => this._ctg_lv1_Name;
      set
      {
        this._ctg_lv1_Name = value;
        this.Changed(nameof (ctg_lv1_Name));
      }
    }

    public int ctg_lv2_ID
    {
      get => this._ctg_lv2_ID;
      set
      {
        this._ctg_lv2_ID = value;
        this.Changed(nameof (ctg_lv2_ID));
      }
    }

    public string ctg_lv2_ViewCode
    {
      get => this._ctg_lv2_ViewCode;
      set
      {
        this._ctg_lv2_ViewCode = value;
        this.Changed(nameof (ctg_lv2_ViewCode));
      }
    }

    public string ctg_lv2_Name
    {
      get => this._ctg_lv2_Name;
      set
      {
        this._ctg_lv2_Name = value;
        this.Changed(nameof (ctg_lv2_Name));
      }
    }

    public string ctg_ParentsName
    {
      get => this._ctg_ParentsName;
      set
      {
        this._ctg_ParentsName = value;
        this.Changed(nameof (ctg_ParentsName));
      }
    }

    public string ctg_ViewCodeAll
    {
      get
      {
        StringBuilder stringBuilder = new StringBuilder();
        if (!string.IsNullOrEmpty(this.ctg_lv1_ViewCode))
          stringBuilder.Append(this.ctg_lv1_ViewCode);
        if (!string.IsNullOrEmpty(this.ctg_lv2_ViewCode))
          stringBuilder.Append(this.ctg_lv2_ViewCode);
        if (!string.IsNullOrEmpty(this.ctg_ViewCode))
          stringBuilder.Append(this.ctg_ViewCode);
        return stringBuilder.ToString();
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

    [JsonPropertyName("lt_Detail")]
    public IList<CategoryView> Lt_Detail
    {
      get => this._Lt_Detail ?? (this._Lt_Detail = (IList<CategoryView>) new List<CategoryView>());
      set
      {
        this._Lt_Detail = value;
        this.Changed(nameof (Lt_Detail));
      }
    }

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("dpt_lv1_ID", new TTableColumn()
      {
        tc_orgin_name = "dpt_lv1_ID",
        tc_trans_name = "부서ID",
        tc_col_status = 2
      });
      columnInfo.Add("dpt_lv1_ViewCode", new TTableColumn()
      {
        tc_orgin_name = "dpt_lv1_ViewCode",
        tc_trans_name = "부서코드",
        tc_col_status = 2
      });
      columnInfo.Add("dpt_lv1_Name", new TTableColumn()
      {
        tc_orgin_name = "dpt_lv1_Name",
        tc_trans_name = "부서명",
        tc_col_status = 2
      });
      columnInfo.Add("dpt_lv2_ID", new TTableColumn()
      {
        tc_orgin_name = "dpt_lv2_ID",
        tc_trans_name = "팀ID",
        tc_col_status = 2
      });
      columnInfo.Add("dpt_lv2_ViewCode", new TTableColumn()
      {
        tc_orgin_name = "dpt_lv2_ViewCode",
        tc_trans_name = "팀코드",
        tc_col_status = 2
      });
      columnInfo.Add("dpt_lv2_Name", new TTableColumn()
      {
        tc_orgin_name = "dpt_lv2_Name",
        tc_trans_name = "팀명",
        tc_col_status = 2
      });
      columnInfo.Add("dpt_ID", new TTableColumn()
      {
        tc_orgin_name = "dpt_ID",
        tc_trans_name = "부서ID",
        tc_col_status = 1
      });
      columnInfo.Add("dpt_ViewCode", new TTableColumn()
      {
        tc_orgin_name = "dpt_ViewCode",
        tc_trans_name = "PC코드",
        tc_col_status = 1
      });
      columnInfo.Add("dpt_DeptName", new TTableColumn()
      {
        tc_orgin_name = "dpt_DeptName",
        tc_trans_name = "PC명",
        tc_col_status = 1
      });
      columnInfo.Add("ctg_lv1_ID", new TTableColumn()
      {
        tc_orgin_name = "ctg_lv1_ID",
        tc_trans_name = "대분류ID",
        tc_col_status = 2
      });
      columnInfo.Add("ctg_lv1_ViewCode", new TTableColumn()
      {
        tc_orgin_name = "ctg_lv1_ViewCode",
        tc_trans_name = "대분류코드",
        tc_col_status = 2
      });
      columnInfo.Add("ctg_lv1_Name", new TTableColumn()
      {
        tc_orgin_name = "ctg_lv1_Name",
        tc_trans_name = "대분류명",
        tc_col_status = 2
      });
      columnInfo.Add("ctg_lv2_ID", new TTableColumn()
      {
        tc_orgin_name = "ctg_lv2_ID",
        tc_trans_name = "중분류ID",
        tc_col_status = 2
      });
      columnInfo.Add("ctg_lv2_ViewCode", new TTableColumn()
      {
        tc_orgin_name = "ctg_lv2_ViewCode",
        tc_trans_name = "중분류코드",
        tc_col_status = 2
      });
      columnInfo.Add("ctg_lv2_Name", new TTableColumn()
      {
        tc_orgin_name = "ctg_lv2_Name",
        tc_trans_name = "중분류명",
        tc_col_status = 2
      });
      columnInfo.Add("ctg_ParentsName", new TTableColumn()
      {
        tc_orgin_name = "ctg_ParentsName",
        tc_trans_name = "상위명",
        tc_col_status = 1
      });
      columnInfo.Add("inEmpName", new TTableColumn()
      {
        tc_orgin_name = "inEmpName",
        tc_trans_name = "등록사원",
        tc_col_status = 1
      });
      columnInfo.Add("modEmpName", new TTableColumn()
      {
        tc_orgin_name = "modEmpName",
        tc_trans_name = "수정사원",
        tc_col_status = 1
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.DeptInfo = (DeptView) null;
      this.ctg_lv1_ID = 0;
      this.ctg_lv1_ViewCode = string.Empty;
      this.ctg_lv1_Name = string.Empty;
      this.ctg_lv2_ID = 0;
      this.ctg_lv2_ViewCode = string.Empty;
      this.ctg_lv2_Name = string.Empty;
      this.ctg_ParentsName = string.Empty;
      this.inEmpName = string.Empty;
      this.modEmpName = string.Empty;
      this.Lt_Detail = (IList<CategoryView>) null;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new CategoryView();

    public override object Clone()
    {
      CategoryView categoryView1 = base.Clone() as CategoryView;
      categoryView1.DeptInfo = (DeptView) null;
      if (this.DeptInfo.dpt_ID > 0)
        categoryView1.DeptInfo = this.DeptInfo;
      categoryView1.ctg_lv1_ID = this.ctg_lv1_ID;
      categoryView1.ctg_lv1_ViewCode = this.ctg_lv1_ViewCode;
      categoryView1.ctg_lv1_Name = this.ctg_lv1_Name;
      categoryView1.ctg_lv2_ID = this.ctg_lv2_ID;
      categoryView1.ctg_lv2_ViewCode = this.ctg_lv2_ViewCode;
      categoryView1.ctg_lv2_Name = this.ctg_lv2_Name;
      categoryView1.ctg_ParentsName = this.ctg_ParentsName;
      categoryView1.inEmpName = this.inEmpName;
      categoryView1.modEmpName = this.modEmpName;
      categoryView1.Lt_Detail = (IList<CategoryView>) null;
      if (this.Lt_Detail.Count > 0)
      {
        foreach (CategoryView categoryView2 in (IEnumerable<CategoryView>) this.Lt_Detail)
          categoryView1.Lt_Detail.Add(categoryView2);
      }
      return (object) categoryView1;
    }

    public void PutData(CategoryView pSource)
    {
      this.PutData((TCategory) pSource);
      this.DeptInfo = (DeptView) null;
      if (pSource.DeptInfo.dpt_ID > 0)
        this.DeptInfo.PutData(pSource.DeptInfo);
      this.ctg_lv1_ID = pSource.ctg_lv1_ID;
      this.ctg_lv1_ViewCode = pSource.ctg_lv1_ViewCode;
      this.ctg_lv1_Name = pSource.ctg_lv1_Name;
      this.ctg_lv2_ID = pSource.ctg_lv2_ID;
      this.ctg_lv2_ViewCode = pSource.ctg_lv2_ViewCode;
      this.ctg_lv2_Name = pSource.ctg_lv2_Name;
      this.ctg_ParentsName = pSource.ctg_ParentsName;
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
      this.Lt_Detail = (IList<CategoryView>) null;
      if (pSource.Lt_Detail.Count <= 0)
        return;
      foreach (CategoryView pSource1 in (IEnumerable<CategoryView>) pSource.Lt_Detail)
      {
        CategoryView categoryView = new CategoryView();
        categoryView.PutData(pSource1);
        this.Lt_Detail.Add(categoryView);
      }
    }

    public CategoryView Apply(CategoryLevel pOrigin)
    {
      foreach (CategoryView categoryView in pOrigin.Items)
        this.Lt_Detail.Add(categoryView);
      return this;
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.ctg_SiteID == 0L)
      {
        this.message = "싸이트(ctg_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (string.IsNullOrEmpty(this.ctg_CategoryName))
      {
        this.message = "소분류명(ctg_CategoryName)  " + EnumDataCheck.Empty.ToDescription();
        return EnumDataCheck.Empty;
      }
      if (!this.IsNew && string.IsNullOrEmpty(this.ctg_ViewCode))
      {
        this.message = "소분류코드(ctg_ViewCode)  " + EnumDataCheck.Empty.ToDescription();
        return EnumDataCheck.Empty;
      }
      if (Enum2StrConverter.ToCategoryDepth(this.ctg_Depth) == EnumCategoryDepth.None)
      {
        this.message = "분류단계(ctg_Depth)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.ctg_ParentsID != 0)
        return EnumDataCheck.Success;
      this.message = "상위분류(ctg_ParentsID)  " + EnumDataCheck.CodeZero.ToDescription();
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
      string ctgViewCode = this.ctg_ViewCode;
      if (this.IsNew && string.IsNullOrEmpty(ctgViewCode))
      {
        int num = 0;
        int p_value = 1;
        if (this.ctg_lv2_ID > 0)
        {
          num = this.ctg_lv2_ID;
          p_value = 3;
        }
        else if (this.ctg_lv1_ID > 0)
        {
          num = this.ctg_lv1_ID;
          p_value = 2;
        }
        p_param.Clear();
        p_param.Add((object) "ctg_Depth", (object) p_value);
        p_param.Add((object) "ctg_ParentsID", (object) num);
        p_param.Add((object) "ctg_SiteID", (object) this.ctg_SiteID);
        IList<CategoryView> source = p_db.Create<CategoryView>().SelectListE<CategoryView>((object) p_param);
        if (source.Count == 0)
        {
          this.ctg_ViewCode = "01";
        }
        else
        {
          CategoryView categoryView = source.LastOrDefault<CategoryView>();
          int length = categoryView.ctg_ViewCode.Length;
          switch (Enum2StrConverter.ToDeptDepth(p_value))
          {
            case EnumDeptDepth.Lv1:
            case EnumDeptDepth.Lv2:
            case EnumDeptDepth.Lv3:
              this.ctg_ViewCode = (Convert.ToInt32(categoryView.ctg_ViewCode) + 1).ToString().FillLeftZero(length);
              break;
            default:
              this.message = "소분류코드(ctg_ViewCode)  " + EnumDataCheck.CodeZero.ToDescription();
              return EnumDataCheck.CodeZero;
          }
        }
      }
      if (string.IsNullOrEmpty(ctgViewCode))
      {
        p_param.Clear();
        p_param.Add((object) "ctg_Depth", (object) this.ctg_Depth);
        p_param.Add((object) "ctg_ParentsID", (object) this.ctg_ParentsID);
        p_param.Add((object) "ctg_ViewCode", (object) this.ctg_ViewCode);
        p_param.Add((object) "ctg_SiteID", (object) this.ctg_SiteID);
        IList<CategoryView> categoryViewList = p_db.Create<CategoryView>().SelectListE<CategoryView>((object) p_param);
        if (categoryViewList != null && categoryViewList.Count > 0)
        {
          if (this.IsNew)
          {
            this.message = "소분류코드(ctg_ViewCode) " + EnumDataCheck.Exists.ToDescription() + "\n - " + categoryViewList[0].ctg_CategoryName + "(" + categoryViewList[0].ctg_ViewCode + ") " + EnumDataCheck.Exists.ToDescription() + " 사용중.";
            return EnumDataCheck.Exists;
          }
          if (this.IsUpdate)
          {
            foreach (CategoryView categoryView in (IEnumerable<CategoryView>) categoryViewList)
            {
              if (categoryView.ctg_Depth != this.ctg_Depth)
              {
                this.message = "소분류코드(ctg_ViewCode) " + EnumDataCheck.Exists.ToDescription() + "\n - " + categoryView.ctg_CategoryName + "(" + categoryView.ctg_ViewCode + ") " + EnumDataCheck.Exists.ToDescription() + " 사용중.";
                return EnumDataCheck.Exists;
              }
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
      if (!p_app_employee.IsMasterCommonSave)
      {
        this.message = p_app_employee.emp_Name + "님(Permit) 변경불가.";
        return false;
      }
      return EnumDataCheck.Success == this.DataCheck(this.OleDB);
    }

    public override string CreateCodeQuery()
    {
      base.CreateCodeQuery();
      return " SELECT " + DbQueryHelper.ToIsNULL() + "(MAX(ctg_ID), 0)+1 AS ctg_ID" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode, (object) DbQueryHelper.ToWithNolock());
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
          this.ctg_ID = uniOleDbRecordset.GetFieldInt(0);
        return this.ctg_ID > 0;
      }
      finally
      {
        uniOleDbRecordset?.Close();
        pOleDB?.Close();
      }
    }

    public override async Task<bool> CreateCodeAsync(UniOleDatabase p_db)
    {
      CategoryView categoryView = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(p_db.ConnectionUrl);
        rs = new UniOleDbRecordset(db, db.CommandTimeout);
        if (!await rs.OpenAsync(categoryView.CreateCodeQuery()))
        {
          categoryView.message = " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + categoryView.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) db.LastErrorID) + " 내용 : " + db.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          return false;
        }
        if (await rs.IsDataReadAsync())
          categoryView.ctg_ID = rs.GetFieldInt(0);
        return categoryView.ctg_ID > 0;
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
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
          if (this.ctg_SiteID == 0L)
            this.ctg_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (this.ctg_ID == 0 && !this.CreateCode(p_db))
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
      CategoryView categoryView = this;
      try
      {
        categoryView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != categoryView.DataCheck(p_db))
            throw new UniServiceException(categoryView.message, categoryView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (categoryView.ctg_SiteID == 0L)
            categoryView.ctg_SiteID = p_app_employee.emp_SiteID;
          if (!categoryView.IsPermit(p_app_employee))
            throw new UniServiceException(categoryView.message, categoryView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (categoryView.ctg_ID == 0)
        {
          if (!await categoryView.CreateCodeAsync(p_db))
            throw new UniServiceException(categoryView.message, categoryView.TableCode.ToDescription() + " 코드 생성 오류", 2);
        }
        if (!await categoryView.InsertAsync())
          throw new UniServiceException(categoryView.message, categoryView.TableCode.ToDescription() + " 등록 오류");
        categoryView.db_status = 4;
        categoryView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        categoryView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        categoryView.message = ex.Message;
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
        if (this.ctg_ID == 0)
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 분류ID(ctg_ID)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (!this.Update())
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
      CategoryView categoryView = this;
      try
      {
        categoryView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != categoryView.DataCheck(p_db))
            throw new UniServiceException(categoryView.message, categoryView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!categoryView.IsPermit(p_app_employee))
          throw new UniServiceException(categoryView.message, categoryView.TableCode.ToDescription() + " 권한 검사 실패");
        if (categoryView.ctg_ID == 0)
          throw new UniServiceException(categoryView.message, categoryView.TableCode.ToDescription() + " 분류ID(ctg_ID)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (!await categoryView.UpdateAsync())
          throw new UniServiceException(categoryView.message, categoryView.TableCode.ToDescription() + " 변경 오류");
        categoryView.db_status = 4;
        categoryView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        categoryView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        categoryView.message = ex.Message;
      }
      return false;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.DeptInfo.dpt_lv1_ID = p_rs.GetFieldInt("dpt_lv1_ID");
      this.DeptInfo.dpt_lv1_ViewCode = p_rs.GetFieldString("dpt_lv1_ViewCode");
      this.DeptInfo.dpt_lv1_Name = p_rs.GetFieldString("dpt_lv1_Name");
      this.DeptInfo.dpt_lv2_ID = p_rs.GetFieldInt("dpt_lv2_ID");
      this.DeptInfo.dpt_lv2_ViewCode = p_rs.GetFieldString("dpt_lv2_ViewCode");
      this.DeptInfo.dpt_lv2_Name = p_rs.GetFieldString("dpt_lv2_Name");
      this.DeptInfo.dpt_ID = p_rs.GetFieldInt("dpt_ID");
      this.DeptInfo.dpt_ViewCode = p_rs.GetFieldString("dpt_ViewCode");
      this.DeptInfo.dpt_DeptName = p_rs.GetFieldString("dpt_DeptName");
      this.ctg_lv1_ID = p_rs.GetFieldInt("ctg_lv1_ID");
      this.ctg_lv1_ViewCode = p_rs.GetFieldString("ctg_lv1_ViewCode");
      this.ctg_lv1_Name = p_rs.GetFieldString("ctg_lv1_Name");
      this.ctg_lv2_ID = p_rs.GetFieldInt("ctg_lv2_ID");
      this.ctg_lv2_ViewCode = p_rs.GetFieldString("ctg_lv2_ViewCode");
      this.ctg_lv2_Name = p_rs.GetFieldString("ctg_lv2_Name");
      this.ctg_ParentsName = p_rs.GetFieldString("ctg_ParentsName");
      this.inEmpName = p_rs.GetFieldString("inEmpName");
      this.modEmpName = p_rs.GetFieldString("modEmpName");
      return true;
    }

    public async Task<CategoryView> SelectOneAsync(int p_ctg_ID, long p_ctg_SiteID = 0)
    {
      CategoryView categoryView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "ctg_ID",
          (object) p_ctg_ID
        }
      };
      if (p_ctg_SiteID > 0L)
        p_param.Add((object) "ctg_SiteID", (object) p_ctg_SiteID);
      return await categoryView.SelectOneTAsync<CategoryView>((object) p_param);
    }

    public async Task<IList<CategoryView>> SelectListAsync(object p_param)
    {
      CategoryView categoryView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(categoryView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, categoryView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(categoryView1.GetSelectQuery(p_param)))
        {
          categoryView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + categoryView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<CategoryView>) null;
        }
        IList<CategoryView> lt_list = (IList<CategoryView>) new List<CategoryView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            CategoryView categoryView2 = categoryView1.OleDB.Create<CategoryView>();
            if (categoryView2.GetFieldValues(rs))
            {
              categoryView2.row_number = lt_list.Count + 1;
              lt_list.Add(categoryView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + categoryView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
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
        if (hashtable.ContainsKey((object) "ctg_lv1_ViewCode") && hashtable[(object) "ctg_lv1_ViewCode"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "ctg_lv1_ViewCode", hashtable[(object) "ctg_lv1_ViewCode"]));
        if (hashtable.ContainsKey((object) "ctg_lv2_ViewCode") && hashtable[(object) "ctg_lv2_ViewCode"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "ctg_lv2_ViewCode", hashtable[(object) "ctg_lv2_ViewCode"]));
        if (hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "ctg_CategoryName", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "ctg_Memo", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) DbQueryHelper.ToStrAdd(EnumDB.NONE, "'|'", "ctg_lv1_Name", "ctg_lv2_Name", "ctg_CategoryName"), hashtable[(object) "_KEY_WORD_"]));
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
          if (hashtable.ContainsKey((object) "ctg_SiteID") && Convert.ToInt64(hashtable[(object) "ctg_SiteID"].ToString()) > 0L)
            num = Convert.ToInt64(hashtable[(object) "ctg_SiteID"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS ( SELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_EMPLOYEE_MOD AS ( SELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_PARENTS_NM AS ( SELECT ctg_ID AS Parents_ID,ctg_SiteID AS Parents_SiteID,ctg_CategoryName AS ctg_ParentsName FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock());
        if (num > 0L)
          stringBuilder.Append(string.Format("  WHERE {0}={1}", (object) "ctg_SiteID", (object) num));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_DEPT_LV_1 AS ( SELECT dpt_ID AS dpt_lv1_ID,dpt_SiteID AS dpt_lv1_SiteID,dpt_ViewCode AS dpt_lv1_ViewCode,dpt_DeptName AS dpt_lv1_Name,dpt_ParentsID AS dpt_lv1_ParentsID" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Dept, (object) DbQueryHelper.ToWithNolock()) + string.Format(" WHERE {0}={1}", (object) "dpt_Depth", (object) 1));
        if (num > 0L)
          stringBuilder.Append(string.Format("  AND {0}={1}", (object) "dpt_SiteID", (object) num));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_DEPT_LV_2 AS ( SELECT dpt_ID AS dpt_lv2_ID,dpt_SiteID AS dpt_lv2_SiteID,dpt_ViewCode AS dpt_lv2_ViewCode,dpt_DeptName AS dpt_lv2_Name,dpt_ParentsID AS dpt_lv2_ParentsID" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Dept, (object) DbQueryHelper.ToWithNolock()) + string.Format(" WHERE {0}={1}", (object) "dpt_Depth", (object) 2));
        if (num > 0L)
          stringBuilder.Append(string.Format("  AND {0}={1}", (object) "dpt_SiteID", (object) num));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_DEPT_LV_3 AS ( SELECT dpt_lv1_ID,dpt_lv1_ViewCode,dpt_lv1_Name,dpt_lv2_ID,dpt_lv2_ViewCode,dpt_lv2_Name,dpt_ParentsID AS dpt_parent_id,dpt_ID AS dept_code,dpt_SiteID,dpt_ViewCode,dpt_DeptName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Dept, (object) DbQueryHelper.ToWithNolock()) + " LEFT OUTER JOIN T_DEPT_LV_2 ON dpt_ParentsID=dpt_lv2_ID AND dpt_SiteID=dpt_lv2_SiteID LEFT OUTER JOIN T_DEPT_LV_1 ON dpt_lv2_ParentsID=dpt_lv1_ID AND dpt_lv2_SiteID=dpt_lv1_SiteID" + string.Format(" WHERE {0}={1}", (object) "dpt_Depth", (object) 3));
        if (num > 0L)
          stringBuilder.Append(string.Format("  AND {0}={1}", (object) "dpt_SiteID", (object) num));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_CTG_LV_1 AS ( SELECT ctg_ID AS ctg_lv1_ID,ctg_SiteID AS ctg_lv1_SiteID,ctg_ViewCode AS ctg_lv1_ViewCode,ctg_CategoryName AS ctg_lv1_Name,ctg_ParentsID AS ctg_lv1_ParentsID,dpt_lv1_ID,dpt_lv1_ViewCode,dpt_lv1_Name,dpt_lv2_ID,dpt_lv2_ViewCode,dpt_lv2_Name,dpt_ViewCode,dpt_DeptName,dept_code AS dpt_ID,dpt_parent_id FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock() + " LEFT OUTER JOIN T_DEPT_LV_3 ON ctg_ParentsID=dept_code AND ctg_SiteID=dpt_SiteID" + string.Format(" WHERE {0}={1}", (object) "ctg_Depth", (object) 1));
        if (num > 0L)
          stringBuilder.Append(string.Format("  AND {0}={1}", (object) "ctg_SiteID", (object) num));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_CTG_LV_2 AS ( SELECT ctg_ID AS ctg_lv2_ID,ctg_SiteID AS ctg_lv2_SiteID,ctg_ViewCode AS ctg_lv2_ViewCode,ctg_CategoryName AS ctg_lv2_Name,ctg_ParentsID AS ctg_lv2_ParentsID FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock() + string.Format(" WHERE {0}={1}", (object) "ctg_Depth", (object) 2));
        if (num > 0L)
          stringBuilder.Append(string.Format("  AND {0}={1}", (object) "ctg_SiteID", (object) num));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_CTG_LV_3 AS ( SELECT ctg_ID AS ctg_lv1_ID,ctg_ViewCode AS ctg_lv1_ViewCode,ctg_CategoryName AS ctg_lv1_Name,0 AS ctg_lv2_ID,'' AS ctg_lv2_ViewCode,'' AS ctg_lv2_Name,ctg_ParentsID AS ctg_parent_id,ctg_ID AS ctg_code,'' AS ctg_lv3_ViewCode ,dpt_lv1_ID,dpt_lv1_ViewCode,dpt_lv1_Name,dpt_lv2_ID,dpt_lv2_ViewCode,dpt_lv2_Name,dpt_ViewCode,dpt_DeptName,dpt_ID,dpt_parent_id FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock() + " LEFT OUTER JOIN T_CTG_LV_1 ON ctg_ID=ctg_lv1_ID AND ctg_SiteID=ctg_lv1_SiteID" + string.Format(" WHERE {0}={1}", (object) "ctg_Depth", (object) 1));
        if (num > 0L)
          stringBuilder.Append(string.Format("  AND {0}={1}", (object) "ctg_SiteID", (object) num));
        stringBuilder.Append("\n UNION ALL SELECT ctg_lv1_ID,ctg_lv1_ViewCode,ctg_lv1_Name,ctg_ID AS ctg_lv2_ID,ctg_ViewCode AS ctg_lv2_ViewCode,ctg_CategoryName AS ctg_lv2_Name,ctg_ParentsID AS ctg_parent_id,ctg_ID AS ctg_code, '' AS ctg_lv3_ViewCode,dpt_lv1_ID,dpt_lv1_ViewCode,dpt_lv1_Name,dpt_lv2_ID,dpt_lv2_ViewCode,dpt_lv2_Name,dpt_ViewCode,dpt_DeptName,dpt_ID,dpt_parent_id FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock() + " LEFT OUTER JOIN T_CTG_LV_1 ON ctg_ParentsID=ctg_lv1_ID AND ctg_SiteID=ctg_lv1_SiteID" + string.Format(" WHERE {0}={1}", (object) "ctg_Depth", (object) 2));
        if (num > 0L)
          stringBuilder.Append(string.Format("  AND {0}={1}", (object) "ctg_SiteID", (object) num));
        stringBuilder.Append("\n UNION ALL SELECT ctg_lv1_ID,ctg_lv1_ViewCode,ctg_lv1_Name,ctg_lv2_ID,ctg_lv2_ViewCode,ctg_lv2_Name,ctg_ParentsID AS ctg_parent_id,ctg_ID AS ctg_code, ctg_ViewCode AS ctg_lv3_ViewCode,dpt_lv1_ID,dpt_lv1_ViewCode,dpt_lv1_Name,dpt_lv2_ID,dpt_lv2_ViewCode,dpt_lv2_Name,dpt_ViewCode,dpt_DeptName,dpt_ID,dpt_parent_id FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock() + " LEFT OUTER JOIN T_CTG_LV_2 ON ctg_ParentsID=ctg_lv2_ID AND ctg_SiteID=ctg_lv2_SiteID LEFT OUTER JOIN T_CTG_LV_1 ON ctg_lv2_ParentsID=ctg_lv1_ID AND ctg_lv2_SiteID=ctg_lv1_SiteID" + string.Format(" WHERE {0}={1}", (object) "ctg_Depth", (object) 3));
        if (num > 0L)
          stringBuilder.Append(string.Format("  AND {0}={1}", (object) "ctg_SiteID", (object) num));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(" SELECT  ctg_ID,ctg_SiteID,ctg_CategoryName,ctg_ViewCode,ctg_Memo,ctg_UseYn,ctg_DepositYn,ctg_Depth,ctg_ParentsID,ctg_AddProperty,ctg_InDate,ctg_InUser,ctg_ModDate,ctg_ModUser,dpt_lv1_ID,dpt_lv1_ViewCode,dpt_lv1_Name,dpt_lv2_ID,dpt_lv2_ViewCode,dpt_lv2_Name,dpt_ViewCode,dpt_DeptName,dpt_ID,dpt_parent_id,ctg_lv1_ID,ctg_lv1_ViewCode,ctg_lv1_Name,ctg_lv2_ID,ctg_lv2_ViewCode,ctg_lv2_Name,ctg_parent_id,CASE ctg_Depth WHEN 1 THEN dpt_DeptName ELSE ctg_ParentsName END AS ctg_ParentsName,inEmpName,modEmpName FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock() + " LEFT OUTER JOIN T_EMPLOYEE_IN ON ctg_InUser=emp_CodeIn LEFT OUTER JOIN T_EMPLOYEE_MOD ON ctg_ModUser=emp_CodeMod LEFT OUTER JOIN T_PARENTS_NM ON ctg_ParentsID=Parents_ID AND ctg_SiteID=Parents_SiteID LEFT OUTER JOIN T_CTG_LV_3 ON ctg_ID=ctg_code");
        stringBuilder.Append("\n");
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append(" ORDER BY " + empty);
        else
          stringBuilder.Append(" ORDER BY ctg_lv1_ViewCode,ctg_lv2_ViewCode,ctg_ViewCode");
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
