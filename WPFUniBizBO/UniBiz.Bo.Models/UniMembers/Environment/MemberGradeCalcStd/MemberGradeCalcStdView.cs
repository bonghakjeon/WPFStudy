// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.Environment.MemberGradeCalcStd.MemberGradeCalcStdView
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
using UniBiz.Bo.Models.UniBase.Employee;
using UniBiz.Bo.Models.UniBase.Employee.DataModLog;
using UniBiz.Bo.Models.UniBase.Employee.Employee;
using UniBiz.Bo.Models.UniBase.ProgOption;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniMembers.Environment.MemberGradeCalcStd
{
  public class MemberGradeCalcStdView : TMemberGradeCalcStd<MemberGradeCalcStdView>
  {
    private string _si_StoreName;
    private string _si_StoreViewCode;
    private string _si_UseYn;
    private string _mgd_MemberGradeName;
    private int _mgd_SortNo;
    private string _mgd_UseYn;
    private string _inEmpName;
    private string _modEmpName;
    private string _arrStrStoreCode;
    private IList<MemberGradeCalcStdView> _Lt_History;

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
      }
    }

    public bool si_IsUseYn => "Y".Equals(this.si_UseYn);

    public string si_UseYnDesc => !"Y".Equals(this.si_UseYn) ? "미사용" : "사용";

    public string mgd_MemberGradeName
    {
      get => this._mgd_MemberGradeName;
      set
      {
        this._mgd_MemberGradeName = value;
        this.Changed(nameof (mgd_MemberGradeName));
      }
    }

    public int mgd_SortNo
    {
      get => this._mgd_SortNo;
      set
      {
        this._mgd_SortNo = value;
        this.Changed(nameof (mgd_SortNo));
      }
    }

    public string mgd_UseYn
    {
      get => this._mgd_UseYn;
      set
      {
        this._mgd_UseYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (mgd_UseYn));
        this.Changed("mgd_IsUse");
        this.Changed("mgd_UseYnDesc");
      }
    }

    public bool mgd_IsUse => "Y".Equals(this.mgd_UseYn);

    public string mgd_UseYnDesc => !"Y".Equals(this.mgd_UseYn) ? "미사용" : "사용";

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

    public string arrStrStoreCode
    {
      get => this._arrStrStoreCode ?? (this._arrStrStoreCode = string.Empty);
      set
      {
        this._arrStrStoreCode = value;
        this.Changed(nameof (arrStrStoreCode));
      }
    }

    [JsonPropertyName("lt_history")]
    public IList<MemberGradeCalcStdView> Lt_History
    {
      get => this._Lt_History ?? (this._Lt_History = (IList<MemberGradeCalcStdView>) new List<MemberGradeCalcStdView>());
      set
      {
        this._Lt_History = value;
        this.Changed(nameof (Lt_History));
      }
    }

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("si_StoreName", new TTableColumn()
      {
        tc_orgin_name = "si_StoreName",
        tc_trans_name = "지점명",
        tc_col_status = 1
      });
      columnInfo.Add("si_StoreViewCode", new TTableColumn()
      {
        tc_orgin_name = "si_StoreViewCode",
        tc_trans_name = "관리코드",
        tc_col_status = 1
      });
      columnInfo.Add("si_UseYn", new TTableColumn()
      {
        tc_orgin_name = "si_UseYn",
        tc_trans_name = "사용상태",
        tc_col_status = 1
      });
      columnInfo.Add("mgd_MemberGradeName", new TTableColumn()
      {
        tc_orgin_name = "mgd_MemberGradeName",
        tc_trans_name = "회원등급명"
      });
      columnInfo.Add("mgd_SortNo", new TTableColumn()
      {
        tc_orgin_name = "mgd_SortNo",
        tc_trans_name = "순서"
      });
      columnInfo.Add("mgd_UseYn", new TTableColumn()
      {
        tc_orgin_name = "mgd_UseYn",
        tc_trans_name = "사용구분"
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
      this.si_StoreName = string.Empty;
      this.si_StoreViewCode = string.Empty;
      this.si_UseYn = "Y";
      this.mgd_MemberGradeName = string.Empty;
      this.mgd_SortNo = 0;
      this.mgd_UseYn = "Y";
      this.inEmpName = string.Empty;
      this.modEmpName = string.Empty;
      this.arrStrStoreCode = string.Empty;
      this.Lt_History = (IList<MemberGradeCalcStdView>) null;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new MemberGradeCalcStdView();

    public override object Clone()
    {
      MemberGradeCalcStdView gradeCalcStdView = base.Clone() as MemberGradeCalcStdView;
      gradeCalcStdView.si_StoreName = this.si_StoreName;
      gradeCalcStdView.si_StoreViewCode = this.si_StoreViewCode;
      gradeCalcStdView.si_UseYn = this.si_UseYn;
      gradeCalcStdView.mgd_MemberGradeName = this.mgd_MemberGradeName;
      gradeCalcStdView.mgd_SortNo = this.mgd_SortNo;
      gradeCalcStdView.mgd_UseYn = this.mgd_UseYn;
      gradeCalcStdView.inEmpName = this.inEmpName;
      gradeCalcStdView.modEmpName = this.modEmpName;
      gradeCalcStdView.arrStrStoreCode = this.arrStrStoreCode;
      gradeCalcStdView.Lt_History = this.Lt_History;
      return (object) gradeCalcStdView;
    }

    public void PutData(MemberGradeCalcStdView pSource)
    {
      this.PutData((TMemberGradeCalcStd) pSource);
      this.si_StoreName = pSource.si_StoreName;
      this.si_StoreViewCode = pSource.si_StoreViewCode;
      this.si_UseYn = pSource.si_UseYn;
      this.mgd_MemberGradeName = pSource.mgd_MemberGradeName;
      this.mgd_SortNo = pSource.mgd_SortNo;
      this.mgd_UseYn = pSource.mgd_UseYn;
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
      this.arrStrStoreCode = pSource.arrStrStoreCode;
      this.Lt_History = (IList<MemberGradeCalcStdView>) null;
      if (pSource.Lt_History.Count <= 0)
        return;
      foreach (MemberGradeCalcStdView pSource1 in (IEnumerable<MemberGradeCalcStdView>) pSource.Lt_History)
      {
        MemberGradeCalcStdView gradeCalcStdView = new MemberGradeCalcStdView();
        gradeCalcStdView.PutData(pSource1);
        this.Lt_History.Add(gradeCalcStdView);
      }
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.mgcs_SiteID == 0L)
      {
        this.message = "싸이트(mgcs_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      IList<ProgOptionView> progOptionList = Enum2StrConverter.ToProgOptionList(this.mgcs_SiteID, EnumOptionType.opt_OnlySiteMember);
      if (progOptionList != null && progOptionList.Count > 0)
      {
        if (Convert.ToInt32(progOptionList[0].opt_Value) != 0)
        {
          if (this.mgcs_StoreCode == 0)
          {
            this.message = "지점코드(mgcs_StoreCode) " + EnumDataCheck.Empty.ToDescription();
            return EnumDataCheck.Empty;
          }
        }
        else if (this.mgcs_StoreCode > 0)
        {
          this.message = "지점코드(mgcs_StoreCode) " + EnumDataCheck.Valid.ToDescription();
          return EnumDataCheck.Valid;
        }
      }
      if (this.mgcs_MemberGrade == 0)
      {
        this.message = "회원등급(mgcs_MemberGrade)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      DateTime? nullable = this.mgcs_StartDate;
      if (!nullable.HasValue)
      {
        this.message = "시작일(mgcs_StartDate)  " + EnumDataCheck.NULL.ToDescription();
        return EnumDataCheck.NULL;
      }
      nullable = this.mgcs_EndDate;
      if (!nullable.HasValue)
      {
        this.message = "종료일(mgcs_EndDate)  " + EnumDataCheck.NULL.ToDescription();
        return EnumDataCheck.NULL;
      }
      nullable = this.mgcs_StartDate;
      int intFormat1 = nullable.Value.ToIntFormat();
      nullable = this.mgcs_EndDate;
      int intFormat2 = nullable.Value.ToIntFormat();
      if (intFormat1 > intFormat2)
      {
        this.message = "시작일(mgcs_StartDate) > 종료일(mgcs_EndDate)  " + EnumDataCheck.Valid.ToDescription();
        return EnumDataCheck.Valid;
      }
      if (string.IsNullOrEmpty(this.mgcs_Operator))
      {
        this.message = "연산자(mgcs_Operator)  " + EnumDataCheck.NULL.ToDescription();
        return EnumDataCheck.NULL;
      }
      if ("A".Equals(this.mgcs_Operator) || "O".Equals(this.mgcs_Operator))
        return EnumDataCheck.Success;
      this.message = "연산자(mgcs_Operator)=>[A,O] " + EnumDataCheck.Valid.ToDescription();
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
      if (!p_app_employee.IsMemberStdSave)
      {
        this.message = p_app_employee.emp_Name + "님(Permit) 변경불가.";
        return false;
      }
      return EnumDataCheck.Success == this.DataCheck(this.OleDB);
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
          if (this.mgcs_SiteID == 0L)
            this.mgcs_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
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
      MemberGradeCalcStdView gradeCalcStdView = this;
      try
      {
        gradeCalcStdView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != gradeCalcStdView.DataCheck(p_db))
            throw new UniServiceException(gradeCalcStdView.message, gradeCalcStdView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (gradeCalcStdView.mgcs_SiteID == 0L)
            gradeCalcStdView.mgcs_SiteID = p_app_employee.emp_SiteID;
          if (!gradeCalcStdView.IsPermit(p_app_employee))
            throw new UniServiceException(gradeCalcStdView.message, gradeCalcStdView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (!await gradeCalcStdView.InsertAsync())
          throw new UniServiceException(gradeCalcStdView.message, gradeCalcStdView.TableCode.ToDescription() + " 등록 오류");
        gradeCalcStdView.db_status = 4;
        gradeCalcStdView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        gradeCalcStdView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        gradeCalcStdView.message = ex.Message;
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
      MemberGradeCalcStdView gradeCalcStdView = this;
      try
      {
        gradeCalcStdView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != gradeCalcStdView.DataCheck(p_db))
            throw new UniServiceException(gradeCalcStdView.message, gradeCalcStdView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!gradeCalcStdView.IsPermit(p_app_employee))
          throw new UniServiceException(gradeCalcStdView.message, gradeCalcStdView.TableCode.ToDescription() + " 권한 검사 실패");
        if (!await gradeCalcStdView.UpdateAsync())
          throw new UniServiceException(gradeCalcStdView.message, gradeCalcStdView.TableCode.ToDescription() + " 변경 오류");
        gradeCalcStdView.db_status = 4;
        gradeCalcStdView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        gradeCalcStdView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        gradeCalcStdView.message = ex.Message;
      }
      return false;
    }

    public override bool DeleteData(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      try
      {
        this.SetAdoDatabase(p_db);
        if (p_app_employee == null || p_app_employee.emp_Code == 0)
        {
          if (EnumDataCheck.Success != this.DataCheck(p_db))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!this.IsPermit(p_app_employee))
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!this.Delete())
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

    public override async Task<bool> DeleteDataAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      MemberGradeCalcStdView gradeCalcStdView = this;
      try
      {
        gradeCalcStdView.SetAdoDatabase(p_db);
        if (p_app_employee == null || p_app_employee.emp_Code == 0)
        {
          if (EnumDataCheck.Success != gradeCalcStdView.DataCheck(p_db))
            throw new UniServiceException(gradeCalcStdView.message, gradeCalcStdView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!gradeCalcStdView.IsPermit(p_app_employee))
          throw new UniServiceException(gradeCalcStdView.message, gradeCalcStdView.TableCode.ToDescription() + " 권한 검사 실패");
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await gradeCalcStdView.DeleteAsync())
          throw new UniServiceException(gradeCalcStdView.message, gradeCalcStdView.TableCode.ToDescription() + " 삭제 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        gradeCalcStdView.db_status = 4;
        gradeCalcStdView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        gradeCalcStdView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        gradeCalcStdView.message = ex.Message;
      }
      return false;
    }

    public async Task<bool> RegisterDataAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      LogInSmallPack p_login_employee)
    {
      MemberGradeCalcStdView gradeCalcStdView1 = this;
      try
      {
        gradeCalcStdView1.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != gradeCalcStdView1.DataCheck(p_db))
            throw new UniServiceException(gradeCalcStdView1.message, gradeCalcStdView1.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (gradeCalcStdView1.mgcs_SiteID == 0L)
            gradeCalcStdView1.mgcs_SiteID = p_app_employee.emp_SiteID;
          if (!gradeCalcStdView1.IsPermit(p_app_employee))
            throw new UniServiceException(gradeCalcStdView1.message, gradeCalcStdView1.TableCode.ToDescription() + " 권한 검사 실패");
        }
        IList<StringBuilder> lt_sbLogs = (IList<StringBuilder>) new List<StringBuilder>();
        lt_sbLogs.Add(new StringBuilder());
        DataModLogView logs = p_db.Create<DataModLogView>();
        DateTime? nullable1;
        if (Enum2StrConverter.IsDataModLog(gradeCalcStdView1.mgcs_SiteID))
        {
          logs.dml_CodeInt = gradeCalcStdView1.mgcs_StoreCode;
          DataModLogView dataModLogView1 = logs;
          nullable1 = gradeCalcStdView1.mgcs_StartDate;
          long num = nullable1.Value.ToLong();
          dataModLogView1.dml_CodeLong = num;
          DataModLogView dataModLogView2 = logs;
          object[] objArray = new object[4]
          {
            (object) gradeCalcStdView1.mgcs_StoreCode,
            (object) gradeCalcStdView1.mgcs_MemberGrade,
            null,
            null
          };
          nullable1 = gradeCalcStdView1.mgcs_StartDate;
          objArray[2] = (object) nullable1.Value.ToIntFormat();
          objArray[3] = (object) gradeCalcStdView1.mgcs_SiteID;
          string str = string.Format("{0}|{1}|{2}|{3}", objArray);
          dataModLogView2.dml_CodeStr = str;
          logs.CreateCode(p_db);
        }
        if (string.IsNullOrEmpty(gradeCalcStdView1.arrStrStoreCode))
          gradeCalcStdView1.arrStrStoreCode = gradeCalcStdView1.mgcs_StoreCode.ToString();
        Hashtable param = new Hashtable();
        param.Add((object) "mgcs_StoreCode_IN_", (object) gradeCalcStdView1.arrStrStoreCode);
        param.Add((object) "mgcs_MemberGrade", (object) gradeCalcStdView1.mgcs_MemberGrade);
        Hashtable hashtable1 = param;
        nullable1 = gradeCalcStdView1.mgcs_StartDate;
        // ISSUE: variable of a boxed type
        __Boxed<DateTime> local1 = (ValueType) nullable1.Value;
        hashtable1.Add((object) "_DT_START_DATE_", (object) local1);
        Hashtable hashtable2 = param;
        nullable1 = gradeCalcStdView1.mgcs_EndDate;
        // ISSUE: variable of a boxed type
        __Boxed<DateTime> local2 = (ValueType) nullable1.Value;
        hashtable2.Add((object) "_DT_END_DATE_", (object) local2);
        IList<MemberGradeCalcStdView> infos = await p_db.Create<MemberGradeCalcStdView>().SelectListAsync((object) param);
        MemberGradeCalcStdByStoreDic dic_Store = new MemberGradeCalcStdByStoreDic();
        dic_Store.AddOriginRange((IEnumerable<MemberGradeCalcStdView>) infos);
        if (dic_Store == null || dic_Store.Count == 0)
          throw new UniServiceException(gradeCalcStdView1.message, gradeCalcStdView1.TableCode.ToDescription() + " 변경 데이터 없음");
        param.Clear();
        param.Add((object) "mgcs_StoreCode_IN_", (object) gradeCalcStdView1.arrStrStoreCode);
        param.Add((object) "mgcs_MemberGrade", (object) gradeCalcStdView1.mgcs_MemberGrade);
        Hashtable hashtable3 = param;
        nullable1 = gradeCalcStdView1.mgcs_StartDate;
        // ISSUE: variable of a boxed type
        __Boxed<DateTime> local3 = (ValueType) nullable1.Value;
        hashtable3.Add((object) "_DT_DATE_", (object) local3);
        IList<MemberGradeCalcStdView> gradeCalcStdViewList = await p_db.Create<MemberGradeCalcStdView>().SelectListAsync((object) param);
        List<MemberGradeCalcStdView> lt_origin_insert = new List<MemberGradeCalcStdView>();
        MemberGradeCalcStdView origin_start = (MemberGradeCalcStdView) null;
        MemberGradeCalcStdView origin_end = (MemberGradeCalcStdView) null;
        foreach (MemberGradeCalcStdView gradeCalcStdView2 in (IEnumerable<MemberGradeCalcStdView>) gradeCalcStdViewList)
        {
          MemberGradeCalcStdView item = gradeCalcStdView2;
          item.SetAdoDatabase(p_db);
          if (dic_Store.ContainsKey(item.mgcs_StoreCode))
          {
            logs.Init(p_login_employee, gradeCalcStdView1.TableCode, EnumEmpActionKind.UPDATE);
            nullable1 = item.mgcs_EndDate;
            if (nullable1.HasValue)
            {
              nullable1 = item.mgcs_EndDate;
              if (!nullable1.Equals((object) gradeCalcStdView1.mgcs_EndDate))
              {
                if (lt_sbLogs[lt_sbLogs.Count - 1].Length > 4000)
                  lt_sbLogs.Add(new StringBuilder());
                lt_sbLogs[lt_sbLogs.Count - 1].Append(logs.LogInfoQuery("mgcs_EndDate", "종료일", item.mgcs_EndDate, gradeCalcStdView1.mgcs_EndDate));
                lt_sbLogs[lt_sbLogs.Count - 1].Append(";");
              }
            }
            if (!item.mgcs_MinBuyCnt.Equals(gradeCalcStdView1.mgcs_MinBuyCnt))
            {
              if (lt_sbLogs[lt_sbLogs.Count - 1].Length > 4000)
                lt_sbLogs.Add(new StringBuilder());
              lt_sbLogs[lt_sbLogs.Count - 1].Append(logs.LogInfoQuery("mgcs_MinBuyCnt", "최소구매횟수", item.mgcs_MinBuyCnt, gradeCalcStdView1.mgcs_MinBuyCnt));
              lt_sbLogs[lt_sbLogs.Count - 1].Append(";");
            }
            if (!item.mgcs_MaxBuyCnt.Equals(gradeCalcStdView1.mgcs_MaxBuyCnt))
            {
              if (lt_sbLogs[lt_sbLogs.Count - 1].Length > 4000)
                lt_sbLogs.Add(new StringBuilder());
              lt_sbLogs[lt_sbLogs.Count - 1].Append(logs.LogInfoQuery("mgcs_MaxBuyCnt", "최대구매횟수", item.mgcs_MaxBuyCnt, gradeCalcStdView1.mgcs_MaxBuyCnt));
              lt_sbLogs[lt_sbLogs.Count - 1].Append(";");
            }
            if (!item.mgcs_Operator.Equals(gradeCalcStdView1.mgcs_Operator))
            {
              if (lt_sbLogs[lt_sbLogs.Count - 1].Length > 4000)
                lt_sbLogs.Add(new StringBuilder());
              lt_sbLogs[lt_sbLogs.Count - 1].Append(logs.LogInfoQuery("mgcs_Operator", "연산자", item.mgcs_Operator, gradeCalcStdView1.mgcs_Operator));
              lt_sbLogs[lt_sbLogs.Count - 1].Append(";");
            }
            if (!item.mgcs_MinBuyAmt.Equals(gradeCalcStdView1.mgcs_MinBuyAmt))
            {
              if (lt_sbLogs[lt_sbLogs.Count - 1].Length > 4000)
                lt_sbLogs.Add(new StringBuilder());
              lt_sbLogs[lt_sbLogs.Count - 1].Append(logs.LogInfoQuery("mgcs_MinBuyAmt", "최소구매금액", item.mgcs_MinBuyAmt, gradeCalcStdView1.mgcs_MinBuyAmt));
              lt_sbLogs[lt_sbLogs.Count - 1].Append(";");
            }
            if (!item.mgcs_MaxBuyAmt.Equals(gradeCalcStdView1.mgcs_MaxBuyAmt))
            {
              if (lt_sbLogs[lt_sbLogs.Count - 1].Length > 4000)
                lt_sbLogs.Add(new StringBuilder());
              lt_sbLogs[lt_sbLogs.Count - 1].Append(logs.LogInfoQuery("mgcs_MaxBuyAmt", "최대구매금액", item.mgcs_MaxBuyAmt, gradeCalcStdView1.mgcs_MaxBuyAmt));
              lt_sbLogs[lt_sbLogs.Count - 1].Append(";");
            }
            if (!item.mgcs_AddPointRate.Equals(gradeCalcStdView1.mgcs_AddPointRate))
            {
              if (lt_sbLogs[lt_sbLogs.Count - 1].Length > 4000)
                lt_sbLogs.Add(new StringBuilder());
              lt_sbLogs[lt_sbLogs.Count - 1].Append(logs.LogInfoQuery("mgcs_AddPointRate", "추가적립률", item.mgcs_AddPointRate, gradeCalcStdView1.mgcs_AddPointRate));
              lt_sbLogs[lt_sbLogs.Count - 1].Append(";");
            }
            item.mgcs_StartDate = gradeCalcStdView1.mgcs_StartDate;
            item.mgcs_SiteID = gradeCalcStdView1.mgcs_SiteID;
            item.mgcs_EndDate = gradeCalcStdView1.mgcs_EndDate;
            item.mgcs_MinBuyCnt = gradeCalcStdView1.mgcs_MinBuyCnt;
            item.mgcs_MaxBuyCnt = gradeCalcStdView1.mgcs_MaxBuyCnt;
            item.mgcs_Operator = gradeCalcStdView1.mgcs_Operator;
            item.mgcs_MinBuyAmt = gradeCalcStdView1.mgcs_MinBuyAmt;
            item.mgcs_MaxBuyAmt = gradeCalcStdView1.mgcs_MaxBuyAmt;
            item.mgcs_AddPointRate = gradeCalcStdView1.mgcs_AddPointRate;
            item.mgcs_InUser = p_app_employee.emp_Code;
            item.mgcs_ModUser = p_app_employee.emp_Code;
            lt_origin_insert.Clear();
            if (origin_start == null)
              origin_start = p_db.Create<MemberGradeCalcStdView>();
            else
              origin_start.Clear();
            origin_start.PutData(item);
            lt_origin_insert.Add(origin_start);
            foreach (MemberGradeCalcStdView history in (IEnumerable<MemberGradeCalcStdView>) dic_Store[item.mgcs_StoreCode].Lt_History)
            {
              history.SetAdoDatabase(p_db);
              if (history.IntStartDate >= item.IntStartDate && history.IntEndDate <= item.IntEndDate)
              {
                if (lt_origin_insert[0].IntEndDate == item.IntEndDate)
                {
                  if (lt_origin_insert[0].IntStartDate == history.IntEndDate)
                    lt_origin_insert[0].mgcs_EndDate = history.mgcs_EndDate;
                  else if (lt_origin_insert[0].IntStartDate < history.IntStartDate)
                  {
                    MemberGradeCalcStdView gradeCalcStdView3 = lt_origin_insert[0];
                    nullable1 = history.mgcs_StartDate;
                    DateTime? nullable2 = new DateTime?(nullable1.Value.GetDateAdd(0, 0, -1));
                    gradeCalcStdView3.mgcs_EndDate = nullable2;
                  }
                }
                if (history.IntStartDate == item.IntStartDate)
                {
                  if (!await history.DeleteAsync())
                    throw new Exception(history.message);
                }
                else if (!await history.UpdateAsync((UbModelBase) null))
                  throw new Exception(history.message);
                if (item.IntEndDate > history.IntEndDate)
                {
                  if (lt_origin_insert.Count == 1)
                  {
                    if (origin_end == null)
                      origin_end = p_db.Create<MemberGradeCalcStdView>();
                    else
                      origin_end.Clear();
                    origin_end.PutData(item);
                    lt_origin_insert.Add(origin_end);
                  }
                  MemberGradeCalcStdView gradeCalcStdView4 = lt_origin_insert[1];
                  nullable1 = history.mgcs_EndDate;
                  DateTime? nullable3 = new DateTime?(nullable1.Value.GetDateAdd(0, 0, 1));
                  gradeCalcStdView4.mgcs_StartDate = nullable3;
                }
              }
              else if (history.IntStartDate < item.IntStartDate && history.IntEndDate > item.IntEndDate)
              {
                MemberGradeCalcStdView next_data = p_db.Create<MemberGradeCalcStdView>();
                next_data.PutData(history);
                MemberGradeCalcStdView gradeCalcStdView5 = history;
                nullable1 = item.mgcs_StartDate;
                DateTime? nullable4 = new DateTime?(nullable1.Value.GetDateAdd(0, 0, -1));
                gradeCalcStdView5.mgcs_EndDate = nullable4;
                if (!await history.UpdateEndDateAsync())
                  throw new Exception(history.message);
                MemberGradeCalcStdView gradeCalcStdView6 = next_data;
                nullable1 = item.mgcs_EndDate;
                DateTime? nullable5 = new DateTime?(nullable1.Value.GetDateAdd(0, 0, 1));
                gradeCalcStdView6.mgcs_StartDate = nullable5;
                next_data.mgcs_SiteID = gradeCalcStdView1.mgcs_SiteID;
                next_data = await next_data.InsertAsync() ? (MemberGradeCalcStdView) null : throw new Exception(next_data.message);
              }
              else if (history.IntStartDate < item.IntStartDate && history.IntEndDate <= item.IntEndDate)
              {
                MemberGradeCalcStdView gradeCalcStdView7 = history;
                nullable1 = item.mgcs_StartDate;
                DateTime? nullable6 = new DateTime?(nullable1.Value.GetDateAdd(0, 0, -1));
                gradeCalcStdView7.mgcs_EndDate = nullable6;
                if (!await history.UpdateEndDateAsync())
                  throw new Exception(history.message);
              }
              else if (item.IntEndDate < 29991231 && history.IntStartDate >= item.IntStartDate && history.IntEndDate > item.IntEndDate)
              {
                MemberGradeCalcStdView gradeCalcStdView8 = history;
                int mgcsStoreCode = history.mgcs_StoreCode;
                int mgcsMemberGrade = history.mgcs_MemberGrade;
                nullable1 = history.mgcs_StartDate;
                DateTime p_mgcs_StartDate = nullable1.Value;
                nullable1 = item.mgcs_EndDate;
                DateTime dateAdd = nullable1.Value.GetDateAdd(0, 0, 1);
                long mgcsSiteId = history.mgcs_SiteID;
                if (!await gradeCalcStdView8.UpdateStartDateAsync(mgcsStoreCode, mgcsMemberGrade, p_mgcs_StartDate, dateAdd, mgcsSiteId))
                  throw new Exception(history.message);
              }
            }
            if (lt_origin_insert.Count == 2)
            {
              foreach (MemberGradeCalcStdView gradeCalcStdView9 in (IEnumerable<MemberGradeCalcStdView>) dic_Store[item.mgcs_StoreCode].Lt_History)
              {
                if (gradeCalcStdView9.IntStartDate == lt_origin_insert[1].IntStartDate)
                {
                  int num = await gradeCalcStdView9.DeleteAsync() ? 1 : 0;
                }
              }
            }
            foreach (MemberGradeCalcStdView gradeCalcStdView10 in lt_origin_insert)
            {
              if (gradeCalcStdView10.IntStartDate <= gradeCalcStdView10.IntEndDate)
              {
                if (!await gradeCalcStdView10.InsertAsync())
                  throw new Exception(item.message);
              }
            }
            if (lt_sbLogs.Count > 0)
            {
              foreach (StringBuilder log in (IEnumerable<StringBuilder>) lt_sbLogs)
              {
                if (log.Length > 0)
                {
                  int num = await p_db.ExecuteAsync(log.ToString()) ? 1 : 0;
                  log.Clear();
                }
              }
              lt_sbLogs.Clear();
              lt_sbLogs.Add(new StringBuilder());
            }
            item = (MemberGradeCalcStdView) null;
          }
        }
        gradeCalcStdView1.db_status = 4;
        gradeCalcStdView1.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        gradeCalcStdView1.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        gradeCalcStdView1.message = ex.Message;
      }
      return false;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.si_StoreName = p_rs.GetFieldString("si_StoreName");
      this.si_StoreViewCode = p_rs.GetFieldString("si_StoreViewCode");
      this.si_UseYn = p_rs.GetFieldString("si_UseYn");
      this.mgd_MemberGradeName = p_rs.GetFieldString("mgd_MemberGradeName");
      this.mgd_SortNo = p_rs.GetFieldInt("mgd_SortNo");
      this.mgd_UseYn = p_rs.GetFieldString("mgd_UseYn");
      this.inEmpName = p_rs.GetFieldString("inEmpName");
      this.modEmpName = p_rs.GetFieldString("modEmpName");
      return true;
    }

    public async Task<MemberGradeCalcStdView> SelectOneAsync(
      int p_mgcs_StoreCode,
      int p_mgcs_MemberGrade,
      DateTime p_mgcs_StartDate,
      long p_mgcs_SiteID = 0)
    {
      MemberGradeCalcStdView gradeCalcStdView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "mgcs_StoreCode",
          (object) p_mgcs_StoreCode
        },
        {
          (object) "mgcs_MemberGrade",
          (object) p_mgcs_MemberGrade
        },
        {
          (object) "mgcs_StartDate",
          (object) p_mgcs_StartDate
        }
      };
      if (p_mgcs_SiteID > 0L)
        p_param.Add((object) "mgcs_SiteID", (object) p_mgcs_SiteID);
      return await gradeCalcStdView.SelectOneTAsync<MemberGradeCalcStdView>((object) p_param);
    }

    public async Task<IList<MemberGradeCalcStdView>> SelectListAsync(object p_param)
    {
      MemberGradeCalcStdView gradeCalcStdView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(gradeCalcStdView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, gradeCalcStdView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(gradeCalcStdView1.GetSelectQuery(p_param)))
        {
          gradeCalcStdView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + gradeCalcStdView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<MemberGradeCalcStdView>) null;
        }
        IList<MemberGradeCalcStdView> lt_list = (IList<MemberGradeCalcStdView>) new List<MemberGradeCalcStdView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            MemberGradeCalcStdView gradeCalcStdView2 = gradeCalcStdView1.OleDB.Create<MemberGradeCalcStdView>();
            if (gradeCalcStdView2.GetFieldValues(rs))
            {
              gradeCalcStdView2.row_number = lt_list.Count + 1;
              lt_list.Add(gradeCalcStdView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + gradeCalcStdView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<MemberGradeCalcStdView> SelectEnumerableAsync(object p_param)
    {
      MemberGradeCalcStdView gradeCalcStdView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(gradeCalcStdView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, gradeCalcStdView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(gradeCalcStdView1.GetSelectQuery(p_param)))
        {
          gradeCalcStdView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + gradeCalcStdView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            MemberGradeCalcStdView gradeCalcStdView2 = gradeCalcStdView1.OleDB.Create<MemberGradeCalcStdView>();
            if (gradeCalcStdView2.GetFieldValues(rs))
            {
              gradeCalcStdView2.row_number = ++row_number;
              yield return gradeCalcStdView2;
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
      if (p_param is Hashtable hashtable && hashtable.ContainsKey((object) "_KEY_WORD_"))
        string.IsNullOrEmpty(hashtable[(object) "_KEY_WORD_"].ToString());
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
        int num1 = 0;
        long num2 = 0;
        bool flag = false;
        if (p_param is Hashtable hashtable2)
        {
          if (hashtable2.ContainsKey((object) "DBMS") && hashtable2[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable2[(object) "DBMS"].ToString();
          if (hashtable2.ContainsKey((object) "table") && hashtable2[(object) "table"].ToString().Length > 0)
            str = hashtable2[(object) "table"].ToString();
          if (hashtable2.ContainsKey((object) "_ORDER_BY_TYPE_") && Convert.ToInt32(hashtable2[(object) "_ORDER_BY_TYPE_"].ToString()) > 0)
            num1 = Convert.ToInt32(hashtable2[(object) "_ORDER_BY_TYPE_"].ToString());
          if (hashtable2.ContainsKey((object) "_ORDER_BY_COL_") && hashtable2[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable2[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable2.ContainsKey((object) "mgcs_SiteID") && Convert.ToInt64(hashtable2[(object) "mgcs_SiteID"].ToString()) > 0L)
            num2 = Convert.ToInt64(hashtable2[(object) "mgcs_SiteID"].ToString());
          if (hashtable2.ContainsKey((object) "MemberType_DEFULT_TABLE_") && Convert.ToBoolean(hashtable2[(object) "MemberType_DEFULT_TABLE_"].ToString()))
            flag = Convert.ToBoolean(hashtable2[(object) "MemberType_DEFULT_TABLE_"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS (\nSELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n,T_EMPLOYEE_MOD AS (\nSELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n,T_STORE AS (\nSELECT si_StoreCode,si_SiteID,si_StoreName,si_StoreViewCode,si_UseYn,si_LocationUseYn" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()));
        if (num2 > 0L)
          stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "si_SiteID", (object) num2));
        stringBuilder.Append(")");
        stringBuilder.Append("\n,T_MEMBER_GRADE AS (\nSELECT mgd_MemberGrade,mgd_SiteID,mgd_MemberGradeName,mgd_SortNo,mgd_UseYn" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) TableCodeType.MemberGrade, (object) DbQueryHelper.ToWithNolock()) + string.Format("\nWHERE {0}={1}", (object) "mgd_SiteID", (object) num2) + ")");
        stringBuilder.Append("\nSELECT  mgcs_StoreCode,mgcs_MemberGrade,mgcs_StartDate,mgcs_SiteID,mgcs_EndDate,mgcs_MinBuyCnt,mgcs_MaxBuyCnt,mgcs_Operator,mgcs_MinBuyAmt,mgcs_MaxBuyAmt,mgcs_AddPointRate,mgcs_InDate,mgcs_InUser,mgcs_ModDate,mgcs_ModUser\n,si_StoreName,si_StoreViewCode,si_UseYn,mgd_MemberGradeName,mgd_SortNo,mgd_UseYn\n,inEmpName,modEmpName\nFROM " + DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS) + str + " " + DbQueryHelper.ToWithNolock() + "\nINNER JOIN T_STORE ON mgcs_StoreCode=si_StoreCode AND mgcs_SiteID=si_SiteID\nLEFT OUTER JOIN T_MEMBER_GRADE ON mgcs_MemberGrade=mgd_MemberGrade AND mgcs_SiteID=vis_mgd_SiteID\nLEFT OUTER JOIN T_EMPLOYEE_IN ON mgcs_InUser=emp_CodeIn\nLEFT OUTER JOIN T_EMPLOYEE_MOD ON mgcs_ModUser=emp_CodeMod");
        if (!flag && p_param is Hashtable)
        {
          stringBuilder.Append("\n");
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        }
        if (num1 > 0)
        {
          if (num1 == 1)
            stringBuilder.Append("\nORDER BY mgcs_StoreCode,mgd_SortNo,mgcs_MemberGrade,mgcs_StartDate DESC");
        }
        else if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append("\nORDER BY " + empty);
        else
          stringBuilder.Append("\nORDER BY mgcs_StoreCode,mgd_SortNo,mgcs_MemberGrade,mgcs_StartDate DESC");
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
  }
}
