// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Dept.DeptView
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
using UniBiz.Bo.Models.UniBase.Employee.Employee;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniBase.Dept
{
  public class DeptView : TDept<DeptView>
  {
    private int _dpt_lv1_ID;
    private string _dpt_lv1_ViewCode;
    private string _dpt_lv1_Name;
    private int _dpt_lv2_ID;
    private string _dpt_lv2_ViewCode;
    private string _dpt_lv2_Name;
    private string _dpt_ParentsName;
    private string _inEmpName;
    private string _modEmpName;
    private IList<DeptView> _Lt_Detail;

    public int dpt_lv1_ID
    {
      get => this._dpt_lv1_ID;
      set
      {
        this._dpt_lv1_ID = value;
        this.Changed(nameof (dpt_lv1_ID));
      }
    }

    public string dpt_lv1_ViewCode
    {
      get => this._dpt_lv1_ViewCode;
      set
      {
        this._dpt_lv1_ViewCode = value;
        this.Changed(nameof (dpt_lv1_ViewCode));
      }
    }

    public string dpt_lv1_Name
    {
      get => this._dpt_lv1_Name;
      set
      {
        this._dpt_lv1_Name = value;
        this.Changed(nameof (dpt_lv1_Name));
      }
    }

    public int dpt_lv2_ID
    {
      get => this._dpt_lv2_ID;
      set
      {
        this._dpt_lv2_ID = value;
        this.Changed(nameof (dpt_lv2_ID));
      }
    }

    public string dpt_lv2_ViewCode
    {
      get => this._dpt_lv2_ViewCode;
      set
      {
        this._dpt_lv2_ViewCode = value;
        this.Changed(nameof (dpt_lv2_ViewCode));
      }
    }

    public string dpt_lv2_Name
    {
      get => this._dpt_lv2_Name;
      set
      {
        this._dpt_lv2_Name = value;
        this.Changed(nameof (dpt_lv2_Name));
      }
    }

    public string dpt_ParentsName
    {
      get => this._dpt_ParentsName;
      set
      {
        this._dpt_ParentsName = value;
        this.Changed(nameof (dpt_ParentsName));
      }
    }

    public string dpt_ViewCodeAll
    {
      get
      {
        StringBuilder stringBuilder = new StringBuilder();
        if (!string.IsNullOrEmpty(this.dpt_lv1_ViewCode))
          stringBuilder.Append(this.dpt_lv1_ViewCode);
        if (!string.IsNullOrEmpty(this.dpt_lv2_ViewCode))
          stringBuilder.Append(this.dpt_lv2_ViewCode);
        if (!string.IsNullOrEmpty(this.dpt_ViewCode))
          stringBuilder.Append(this.dpt_ViewCode);
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
    public IList<DeptView> Lt_Detail
    {
      get => this._Lt_Detail ?? (this._Lt_Detail = (IList<DeptView>) new List<DeptView>());
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
      columnInfo.Add("dpt_ViewCodeAll", new TTableColumn()
      {
        tc_orgin_name = "dpt_ViewCodeAll",
        tc_trans_name = "부서_코드",
        tc_col_status = 2
      });
      columnInfo.Add("dpt_ParentsName", new TTableColumn()
      {
        tc_orgin_name = "dpt_ParentsName",
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
      this.dpt_lv1_ID = this.dpt_lv2_ID = 0;
      this.dpt_lv1_ViewCode = string.Empty;
      this.dpt_lv1_Name = string.Empty;
      this.dpt_lv2_ViewCode = string.Empty;
      this.dpt_lv2_Name = string.Empty;
      this.inEmpName = string.Empty;
      this.modEmpName = string.Empty;
      this.dpt_ParentsName = string.Empty;
      this.Lt_Detail = (IList<DeptView>) null;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new DeptView();

    public override object Clone()
    {
      DeptView deptView1 = base.Clone() as DeptView;
      deptView1.dpt_lv1_ID = this.dpt_lv1_ID;
      deptView1.dpt_lv1_ViewCode = this.dpt_lv1_ViewCode;
      deptView1.dpt_lv1_Name = this.dpt_lv1_Name;
      deptView1.dpt_lv2_ID = this.dpt_lv2_ID;
      deptView1.dpt_lv2_ViewCode = this.dpt_lv2_ViewCode;
      deptView1.dpt_lv2_Name = this.dpt_lv2_Name;
      deptView1.dpt_ParentsName = this.dpt_ParentsName;
      deptView1.inEmpName = this.inEmpName;
      deptView1.modEmpName = this.modEmpName;
      deptView1.Lt_Detail = (IList<DeptView>) null;
      if (this.Lt_Detail.Count > 0)
      {
        foreach (DeptView deptView2 in (IEnumerable<DeptView>) this.Lt_Detail)
          deptView1.Lt_Detail.Add(deptView2);
      }
      return (object) deptView1;
    }

    public void PutData(DeptView pSource)
    {
      this.PutData((TDept) pSource);
      this.dpt_lv1_ID = pSource.dpt_lv1_ID;
      this.dpt_lv1_ViewCode = pSource.dpt_lv1_ViewCode;
      this.dpt_lv1_Name = pSource.dpt_lv1_Name;
      this.dpt_lv2_ID = pSource.dpt_lv2_ID;
      this.dpt_lv2_ViewCode = pSource.dpt_lv2_ViewCode;
      this.dpt_lv2_Name = pSource.dpt_lv2_Name;
      this.dpt_ParentsName = pSource.dpt_ParentsName;
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
      this.Lt_Detail = (IList<DeptView>) null;
      if (pSource.Lt_Detail.Count <= 0)
        return;
      foreach (DeptView pSource1 in (IEnumerable<DeptView>) pSource.Lt_Detail)
      {
        DeptView deptView = new DeptView();
        deptView.PutData(pSource1);
        this.Lt_Detail.Add(deptView);
      }
    }

    public DeptView Apply(DeptLevel pOrigin)
    {
      foreach (DeptView deptView in pOrigin.Items)
        this.Lt_Detail.Add(deptView);
      return this;
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.dpt_SiteID == 0L)
      {
        this.message = "싸이트(dpt_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (string.IsNullOrEmpty(this.dpt_DeptName))
      {
        this.message = "PC명(dpt_DeptName)  " + EnumDataCheck.Empty.ToDescription();
        return EnumDataCheck.Empty;
      }
      if (!this.IsNew && string.IsNullOrEmpty(this.dpt_ViewCode))
      {
        this.message = "PC코드(dpt_ViewCode)  " + EnumDataCheck.Empty.ToDescription();
        return EnumDataCheck.Empty;
      }
      if (Enum2StrConverter.ToDeptDepth(this.dpt_Depth) == EnumDeptDepth.None)
      {
        this.message = "부서 단계(dpt_Depth)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.dpt_Depth <= 1 || this.dpt_ParentsID != 0)
        return EnumDataCheck.Success;
      this.message = "상위부서(dpt_ParentsID)  " + EnumDataCheck.CodeZero.ToDescription();
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
      string dptViewCode = this.dpt_ViewCode;
      if (this.IsNew && string.IsNullOrEmpty(dptViewCode))
      {
        int num = 0;
        int p_value = 1;
        if (this.dpt_lv2_ID > 0)
        {
          num = this.dpt_lv2_ID;
          p_value = 3;
        }
        else if (this.dpt_lv1_ID > 0)
        {
          num = this.dpt_lv1_ID;
          p_value = 2;
        }
        p_param.Clear();
        p_param.Add((object) "dpt_Depth", (object) p_value);
        p_param.Add((object) "dpt_ParentsID", (object) num);
        p_param.Add((object) "dpt_SiteID", (object) this.dpt_SiteID);
        IList<DeptView> source = p_db.Create<DeptView>().SelectListE<DeptView>((object) p_param);
        if (source.Count == 0)
        {
          this.dpt_ViewCode = "01";
        }
        else
        {
          DeptView deptView = source.LastOrDefault<DeptView>();
          int length = deptView.dpt_ViewCode.Length;
          switch (Enum2StrConverter.ToDeptDepth(p_value))
          {
            case EnumDeptDepth.Lv1:
            case EnumDeptDepth.Lv2:
            case EnumDeptDepth.Lv3:
              this.dpt_ViewCode = (Convert.ToInt32(deptView.dpt_ViewCode) + 1).ToString().FillLeftZero(length);
              break;
            default:
              this.message = "PC코드(dpt_ViewCode)  " + EnumDataCheck.CodeZero.ToDescription();
              return EnumDataCheck.CodeZero;
          }
        }
      }
      if (string.IsNullOrEmpty(dptViewCode))
      {
        p_param.Clear();
        p_param.Add((object) "dpt_Depth", (object) this.dpt_Depth);
        p_param.Add((object) "dpt_ParentsID", (object) this.dpt_ParentsID);
        p_param.Add((object) "dpt_ViewCode", (object) this.dpt_ViewCode);
        p_param.Add((object) "dpt_SiteID", (object) this.dpt_SiteID);
        IList<DeptView> deptViewList = p_db.Create<DeptView>().SelectListE<DeptView>((object) p_param);
        if (deptViewList != null && deptViewList.Count > 0)
        {
          if (this.IsNew)
          {
            this.message = "PC코드(dpt_ViewCode) " + EnumDataCheck.Exists.ToDescription() + "\n - " + deptViewList[0].dpt_DeptName + "(" + deptViewList[0].dpt_ViewCode + ") " + EnumDataCheck.Exists.ToDescription() + " 사용중.";
            return EnumDataCheck.Exists;
          }
          if (this.IsUpdate)
          {
            foreach (DeptView deptView in (IEnumerable<DeptView>) deptViewList)
            {
              if (deptView.dpt_Depth != this.dpt_Depth)
              {
                this.message = "PC코드(dpt_ViewCode) " + EnumDataCheck.Exists.ToDescription() + "\n - " + deptView.dpt_DeptName + "(" + deptView.dpt_ViewCode + ") " + EnumDataCheck.Exists.ToDescription() + " 사용중.";
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
      return " SELECT " + DbQueryHelper.ToIsNULL() + "(MAX(dpt_ID), 0)+1 AS dpt_ID" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode, (object) DbQueryHelper.ToWithNolock());
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
          this.dpt_ID = uniOleDbRecordset.GetFieldInt(0);
        return this.dpt_ID > 0;
      }
      finally
      {
        uniOleDbRecordset?.Close();
        pOleDB?.Close();
      }
    }

    public override async Task<bool> CreateCodeAsync(UniOleDatabase p_db)
    {
      DeptView deptView = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(p_db.ConnectionUrl);
        rs = new UniOleDbRecordset(db, db.CommandTimeout);
        if (!await rs.OpenAsync(deptView.CreateCodeQuery()))
        {
          deptView.message = " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + deptView.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) db.LastErrorID) + " 내용 : " + db.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          return false;
        }
        if (await rs.IsDataReadAsync())
          deptView.dpt_ID = rs.GetFieldInt(0);
        return deptView.dpt_ID > 0;
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public override bool Insert() => (this.dpt_ID != 0 || this.CreateCode(this.OleDB)) && base.Insert() && this.SetSuccessInfo(string.Format("({0},{1}) 등록됨.", (object) this.dpt_ID, (object) this.dpt_SiteID));

    public override async Task<bool> InsertAsync()
    {
      DeptView deptView = this;
      if (deptView.dpt_ID == 0)
      {
        if (!await deptView.CreateCodeAsync(deptView.OleDB))
          return false;
      }
      // ISSUE: reference to a compiler-generated method
      return await deptView.\u003C\u003En__0() && deptView.SetSuccessInfo(string.Format("({0},{1}) 등록됨.", (object) deptView.dpt_ID, (object) deptView.dpt_SiteID));
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
          if (this.dpt_SiteID == 0L)
            this.dpt_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (this.dpt_ID == 0 && !this.CreateCode(p_db))
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
      DeptView deptView = this;
      try
      {
        deptView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != deptView.DataCheck(p_db))
            throw new UniServiceException(deptView.message, deptView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (deptView.dpt_SiteID == 0L)
            deptView.dpt_SiteID = p_app_employee.emp_SiteID;
          if (!deptView.IsPermit(p_app_employee))
            throw new UniServiceException(deptView.message, deptView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (deptView.dpt_ID == 0)
        {
          if (!await deptView.CreateCodeAsync(p_db))
            throw new UniServiceException(deptView.message, deptView.TableCode.ToDescription() + " 코드 생성 오류", 2);
        }
        if (!await deptView.InsertAsync())
          throw new UniServiceException(deptView.message, deptView.TableCode.ToDescription() + " 등록 오류");
        deptView.db_status = 4;
        deptView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        deptView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        deptView.message = ex.Message;
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
        if (this.dpt_ID == 0)
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 부서ID(dpt_ID)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
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
      DeptView deptView = this;
      try
      {
        deptView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != deptView.DataCheck(p_db))
            throw new UniServiceException(deptView.message, deptView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!deptView.IsPermit(p_app_employee))
          throw new UniServiceException(deptView.message, deptView.TableCode.ToDescription() + " 권한 검사 실패");
        if (deptView.dpt_ID == 0)
          throw new UniServiceException(deptView.message, deptView.TableCode.ToDescription() + " 부서ID(dpt_ID)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (!await deptView.UpdateAsync())
          throw new UniServiceException(deptView.message, deptView.TableCode.ToDescription() + " 변경 오류");
        deptView.db_status = 4;
        deptView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        deptView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        deptView.message = ex.Message;
      }
      return false;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.dpt_lv1_ID = p_rs.GetFieldInt("dpt_lv1_ID");
      this.dpt_lv1_ViewCode = p_rs.GetFieldString("dpt_lv1_ViewCode");
      this.dpt_lv1_Name = p_rs.GetFieldString("dpt_lv1_Name");
      this.dpt_lv2_ID = p_rs.GetFieldInt("dpt_lv2_ID");
      this.dpt_lv2_ViewCode = p_rs.GetFieldString("dpt_lv2_ViewCode");
      this.dpt_lv2_Name = p_rs.GetFieldString("dpt_lv2_Name");
      this.dpt_ParentsName = p_rs.GetFieldString("dpt_ParentsName");
      this.inEmpName = p_rs.GetFieldString("inEmpName");
      this.modEmpName = p_rs.GetFieldString("modEmpName");
      return true;
    }

    public async Task<DeptView> SelectOneAsync(int p_dpt_ID, long p_dpt_SiteID = 0)
    {
      DeptView deptView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "dpt_ID",
          (object) p_dpt_ID
        }
      };
      if (p_dpt_SiteID > 0L)
        p_param.Add((object) "dpt_SiteID", (object) p_dpt_SiteID);
      return await deptView.SelectOneTAsync<DeptView>((object) p_param);
    }

    public async Task<IList<DeptView>> SelectListAsync(object p_param)
    {
      DeptView deptView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(deptView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, deptView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(deptView1.GetSelectQuery(p_param)))
        {
          deptView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + deptView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<DeptView>) null;
        }
        IList<DeptView> lt_list = (IList<DeptView>) new List<DeptView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            DeptView deptView2 = deptView1.OleDB.Create<DeptView>();
            if (deptView2.GetFieldValues(rs))
            {
              deptView2.row_number = lt_list.Count + 1;
              lt_list.Add(deptView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + deptView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
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
        stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "dpt_DeptName", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "dpt_Memo", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) DbQueryHelper.ToStrAdd(EnumDB.NONE, "'|'", "dpt_lv1_Name", "dpt_lv2_Name", "dpt_DeptName"), hashtable[(object) "_KEY_WORD_"]));
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
          if (hashtable.ContainsKey((object) "dpt_SiteID") && Convert.ToInt64(hashtable[(object) "dpt_SiteID"].ToString()) > 0L)
            num = Convert.ToInt64(hashtable[(object) "dpt_SiteID"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS ( SELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_EMPLOYEE_MOD AS ( SELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_PARENTS_NM AS ( SELECT dpt_ID AS Parents_ID,dpt_SiteID AS Parents_SiteID,dpt_DeptName AS dpt_ParentsName FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock());
        if (num > 0L)
          stringBuilder.Append(string.Format("  WHERE {0}={1}", (object) "dpt_SiteID", (object) num));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_LV_1 AS ( SELECT dpt_ID AS dpt_lv1_ID,dpt_SiteID AS dpt_lv1_SiteID,dpt_ViewCode AS dpt_lv1_ViewCode,dpt_DeptName AS dpt_lv1_Name,dpt_ParentsID AS dpt_lv1_ParentsID FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock() + string.Format(" WHERE {0}={1}", (object) "dpt_Depth", (object) 1));
        if (num > 0L)
          stringBuilder.Append(string.Format("  AND {0}={1}", (object) "dpt_SiteID", (object) num));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_LV_2 AS ( SELECT dpt_ID AS dpt_lv2_ID,dpt_SiteID AS dpt_lv2_SiteID,dpt_ViewCode AS dpt_lv2_ViewCode,dpt_DeptName AS dpt_lv2_Name,dpt_ParentsID AS dpt_lv2_ParentsID FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock() + string.Format(" WHERE {0}={1}", (object) "dpt_Depth", (object) 2));
        if (num > 0L)
          stringBuilder.Append(string.Format("  AND {0}={1}", (object) "dpt_SiteID", (object) num));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_LV_3 AS ( SELECT dpt_ID AS dpt_lv1_ID,dpt_ViewCode AS dpt_lv1_ViewCode,dpt_DeptName AS dpt_lv1_Name,0 AS dpt_lv2_ID,'' AS dpt_lv2_ViewCode,'' AS dpt_lv2_Name,dpt_ParentsID AS dpt_parent_id,dpt_ID AS dept_code,'' AS dpt_lv3_ViewCode FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock() + string.Format(" WHERE {0}={1}", (object) "dpt_Depth", (object) 1));
        if (num > 0L)
          stringBuilder.Append(string.Format("  AND {0}={1}", (object) "dpt_SiteID", (object) num));
        stringBuilder.Append("\n UNION ALL SELECT dpt_lv1_ID,dpt_lv1_ViewCode,dpt_lv1_Name,dpt_ID AS dpt_lv2_ID,dpt_ViewCode AS dpt_lv2_ViewCode,dpt_DeptName AS dpt_lv2_Name,dpt_ParentsID AS dpt_parent_id,dpt_ID AS dept_code,'' AS dpt_lv3_ViewCode FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock() + " LEFT OUTER JOIN T_LV_1 ON dpt_ParentsID = dpt_lv1_ID AND dpt_SiteID=dpt_lv1_SiteID" + string.Format(" WHERE {0}={1}", (object) "dpt_Depth", (object) 2));
        if (num > 0L)
          stringBuilder.Append(string.Format("  AND {0}={1}", (object) "dpt_SiteID", (object) num));
        stringBuilder.Append("\n UNION ALL SELECT dpt_lv1_ID,dpt_lv1_ViewCode,dpt_lv1_Name,dpt_lv2_ID,dpt_lv2_ViewCode,dpt_lv2_Name,dpt_ParentsID AS dpt_parent_id,dpt_ID AS dept_code,dpt_ViewCode AS dpt_lv3_ViewCode FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock() + " LEFT OUTER JOIN T_LV_2 ON dpt_ParentsID=dpt_lv2_ID AND dpt_SiteID=dpt_lv2_SiteID LEFT OUTER JOIN T_LV_1 ON dpt_lv2_ParentsID=dpt_lv1_ID AND dpt_lv2_SiteID=dpt_lv1_SiteID" + string.Format(" WHERE {0}={1}", (object) "dpt_Depth", (object) 3));
        if (num > 0L)
          stringBuilder.Append(string.Format("  AND {0}={1}", (object) "dpt_SiteID", (object) num));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(" SELECT  dpt_ID,dpt_SiteID,dpt_DeptName,dpt_ViewCode,dpt_Memo,dpt_UseYn,dpt_Depth,dpt_ParentsID,dpt_InDate,dpt_InUser,dpt_ModDate,dpt_ModUser,dpt_lv1_ID,dpt_lv1_ViewCode,dpt_lv1_Name,dpt_lv2_ID,dpt_lv2_ViewCode,dpt_lv2_Name,dpt_ParentsName,inEmpName,modEmpName FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock() + " LEFT OUTER JOIN T_EMPLOYEE_IN ON dpt_InUser=emp_CodeIn LEFT OUTER JOIN T_EMPLOYEE_MOD ON dpt_ModUser=emp_CodeMod LEFT OUTER JOIN T_PARENTS_NM ON dpt_ParentsID=Parents_ID AND dpt_SiteID=Parents_SiteID LEFT OUTER JOIN T_LV_3 ON dpt_ID=dept_code");
        stringBuilder.Append("\n");
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append(" ORDER BY " + empty);
        else
          stringBuilder.Append(" ORDER BY dpt_lv1_ViewCode,dpt_lv2_ViewCode,dpt_ViewCode");
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
