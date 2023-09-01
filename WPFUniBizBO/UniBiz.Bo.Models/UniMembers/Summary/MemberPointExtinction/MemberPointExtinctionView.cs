// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.Summary.MemberPointExtinction.MemberPointExtinctionView
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
using UniBiz.Bo.Models.UniMembers.Info.Member;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniMembers.Summary.MemberPointExtinction
{
  public class MemberPointExtinctionView : TMemberPointExtinction<MemberPointExtinctionView>
  {
    private string _mbr_MemberName;
    private int _mbr_MemberType;
    private int _mbr_MemberCycle;
    private int _mbr_MemberGrade;
    private string _mbr_GroupCode;
    private int _mbr_Status;
    private string _mt_TypeName;
    private string _mt_UseYn;
    private string _mgd_MemberGradeName;
    private string _mgd_UseYn;
    private string _mg_GroupName;
    private int _mg_GroupDepth;
    private string _mg_UseYn;
    private string _inEmpName;
    private string _modEmpName;

    public string mbr_MemberName
    {
      get => this._mbr_MemberName;
      set
      {
        this._mbr_MemberName = value;
        this.Changed(nameof (mbr_MemberName));
      }
    }

    public int mbr_MemberType
    {
      get => this._mbr_MemberType;
      set
      {
        this._mbr_MemberType = value;
        this.Changed(nameof (mbr_MemberType));
      }
    }

    public int mbr_MemberCycle
    {
      get => this._mbr_MemberCycle;
      set
      {
        this._mbr_MemberCycle = value;
        this.Changed(nameof (mbr_MemberCycle));
        this.Changed("mbr_MemberCycleDesc");
      }
    }

    public string mbr_MemberCycleDesc => this.mbr_MemberCycle != 0 ? Enum2StrConverter.ToMemberCycle(this.mbr_MemberCycle).ToDescription() : string.Empty;

    public int mbr_MemberGrade
    {
      get => this._mbr_MemberGrade;
      set
      {
        this._mbr_MemberGrade = value;
        this.Changed(nameof (mbr_MemberGrade));
      }
    }

    public string mbr_GroupCode
    {
      get => this._mbr_GroupCode;
      set
      {
        this._mbr_GroupCode = value;
        this.Changed(nameof (mbr_GroupCode));
      }
    }

    public int mbr_Status
    {
      get => this._mbr_Status;
      set
      {
        this._mbr_Status = value;
        this.Changed(nameof (mbr_Status));
        this.Changed("mbr_StatusDesc");
      }
    }

    public string mbr_StatusDesc => this.mbr_Status != 0 ? Enum2StrConverter.ToMemberStatus(this.mbr_Status).ToDescription() : string.Empty;

    public string mt_TypeName
    {
      get => this._mt_TypeName;
      set
      {
        this._mt_TypeName = value;
        this.Changed(nameof (mt_TypeName));
      }
    }

    public string mt_UseYn
    {
      get => this._mt_UseYn;
      set
      {
        this._mt_UseYn = value;
        this.Changed(nameof (mt_UseYn));
        this.Changed("mt_IsUse");
        this.Changed("mt_UseYnDesc");
      }
    }

    public bool mt_IsUse => "Y".Equals(this.mt_UseYn);

    public string mt_UseYnDesc => !"Y".Equals(this.mt_UseYn) ? "미사용" : "사용";

    public string mgd_MemberGradeName
    {
      get => this._mgd_MemberGradeName;
      set
      {
        this._mgd_MemberGradeName = value;
        this.Changed(nameof (mgd_MemberGradeName));
      }
    }

    public string mgd_UseYn
    {
      get => this._mgd_UseYn;
      set
      {
        this._mgd_UseYn = value;
        this.Changed(nameof (mgd_UseYn));
        this.Changed("mgd_IsUse");
        this.Changed("mgd_UseYnDesc");
      }
    }

    public bool mgd_IsUse => "Y".Equals(this.mgd_UseYn);

    public string mgd_UseYnDesc => !"Y".Equals(this.mgd_UseYn) ? "미사용" : "사용";

    public string mg_GroupName
    {
      get => this._mg_GroupName;
      set
      {
        this._mg_GroupName = value;
        this.Changed(nameof (mg_GroupName));
      }
    }

    public int mg_GroupDepth
    {
      get => this._mg_GroupDepth;
      set
      {
        this._mg_GroupDepth = value;
        this.Changed(nameof (mg_GroupDepth));
      }
    }

    public string mg_UseYn
    {
      get => this._mg_UseYn;
      set
      {
        this._mg_UseYn = value;
        this.Changed(nameof (mg_UseYn));
        this.Changed("mg_IsUse");
        this.Changed("mg_UseYnDesc");
      }
    }

    public bool mg_IsUse => "Y".Equals(this.mg_UseYn);

    public string mg_UseYnDesc => !"Y".Equals(this.mg_UseYn) ? "미사용" : "사용";

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

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("mbr_MemberName", new TTableColumn()
      {
        tc_orgin_name = "mbr_MemberName",
        tc_trans_name = "회원명"
      });
      columnInfo.Add("mbr_MemberType", new TTableColumn()
      {
        tc_orgin_name = "mbr_MemberType",
        tc_trans_name = "회원유형"
      });
      columnInfo.Add("mbr_MemberCycle", new TTableColumn()
      {
        tc_orgin_name = "mbr_MemberCycle",
        tc_trans_name = "회원주기",
        tc_comm_code = 186
      });
      columnInfo.Add("mbr_MemberGrade", new TTableColumn()
      {
        tc_orgin_name = "mbr_MemberGrade",
        tc_trans_name = "회원등급"
      });
      columnInfo.Add("mbr_GroupCode", new TTableColumn()
      {
        tc_orgin_name = "mbr_GroupCode",
        tc_trans_name = "회원그룹"
      });
      columnInfo.Add("mbr_Status", new TTableColumn()
      {
        tc_orgin_name = "mbr_Status",
        tc_trans_name = "상태",
        tc_comm_code = 181
      });
      columnInfo.Add("mt_TypeName", new TTableColumn()
      {
        tc_orgin_name = "mt_TypeName",
        tc_trans_name = "회원유형명",
        tc_col_status = 1
      });
      columnInfo.Add("mt_UseYn", new TTableColumn()
      {
        tc_orgin_name = "mt_UseYn",
        tc_trans_name = "사용상태",
        tc_col_status = 1
      });
      columnInfo.Add("mgd_MemberGradeName", new TTableColumn()
      {
        tc_orgin_name = "mgd_MemberGradeName",
        tc_trans_name = "회원등급명",
        tc_col_status = 1
      });
      columnInfo.Add("mgd_UseYn", new TTableColumn()
      {
        tc_orgin_name = "mgd_UseYn",
        tc_trans_name = "사용구분",
        tc_col_status = 1
      });
      columnInfo.Add("mg_GroupName", new TTableColumn()
      {
        tc_orgin_name = "mg_GroupName",
        tc_trans_name = "명칭",
        tc_col_status = 1
      });
      columnInfo.Add("mg_GroupDepth", new TTableColumn()
      {
        tc_orgin_name = "mg_GroupDepth",
        tc_trans_name = "단계(대/중)",
        tc_col_status = 1
      });
      columnInfo.Add("mg_UseYn", new TTableColumn()
      {
        tc_orgin_name = "mg_UseYn",
        tc_trans_name = "사용구분",
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
      this.mbr_MemberName = string.Empty;
      this.mbr_MemberType = 0;
      this.mbr_MemberCycle = 0;
      this.mbr_MemberGrade = 0;
      this.mbr_GroupCode = string.Empty;
      this.mbr_Status = 0;
      this.mt_TypeName = string.Empty;
      this.mt_UseYn = "Y";
      this.mgd_MemberGradeName = string.Empty;
      this.mgd_UseYn = "Y";
      this.mg_GroupName = string.Empty;
      this.mg_GroupDepth = 0;
      this.mg_UseYn = "Y";
      this.inEmpName = string.Empty;
      this.modEmpName = string.Empty;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new MemberPointExtinctionView();

    public override object Clone()
    {
      MemberPointExtinctionView pointExtinctionView = base.Clone() as MemberPointExtinctionView;
      pointExtinctionView.mbr_MemberName = this.mbr_MemberName;
      pointExtinctionView.mbr_MemberType = this.mbr_MemberType;
      pointExtinctionView.mbr_MemberCycle = this.mbr_MemberCycle;
      pointExtinctionView.mbr_MemberGrade = this.mbr_MemberGrade;
      pointExtinctionView.mbr_GroupCode = this.mbr_GroupCode;
      pointExtinctionView.mbr_Status = this.mbr_Status;
      pointExtinctionView.mt_TypeName = this.mt_TypeName;
      pointExtinctionView.mt_UseYn = this.mt_UseYn;
      pointExtinctionView.mgd_MemberGradeName = this.mgd_MemberGradeName;
      pointExtinctionView.mgd_UseYn = this.mgd_UseYn;
      pointExtinctionView.mg_GroupName = this.mg_GroupName;
      pointExtinctionView.mg_GroupDepth = this.mg_GroupDepth;
      pointExtinctionView.mg_UseYn = this.mg_UseYn;
      pointExtinctionView.inEmpName = this.inEmpName;
      pointExtinctionView.modEmpName = this.modEmpName;
      return (object) pointExtinctionView;
    }

    public void PutData(MemberPointExtinctionView pSource)
    {
      this.PutData((TMemberPointExtinction) pSource);
      this.mbr_MemberName = pSource.mbr_MemberName;
      this.mbr_MemberType = pSource.mbr_MemberType;
      this.mbr_MemberCycle = pSource.mbr_MemberCycle;
      this.mbr_MemberGrade = pSource.mbr_MemberGrade;
      this.mbr_GroupCode = pSource.mbr_GroupCode;
      this.mbr_Status = pSource.mbr_Status;
      this.mt_TypeName = pSource.mt_TypeName;
      this.mt_UseYn = pSource.mt_UseYn;
      this.mgd_MemberGradeName = pSource.mgd_MemberGradeName;
      this.mgd_UseYn = pSource.mgd_UseYn;
      this.mg_GroupName = pSource.mg_GroupName;
      this.mg_GroupDepth = pSource.mg_GroupDepth;
      this.mg_UseYn = pSource.mg_UseYn;
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.mpe_SiteID == 0L)
      {
        this.message = "싸이트(mpe_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (!this.mpe_Date.HasValue)
      {
        this.message = "소멸예정일(mpe_Date)  " + EnumDataCheck.NULL.ToDescription();
        return EnumDataCheck.NULL;
      }
      if (this.mpe_MemberNo != 0L)
        return EnumDataCheck.Success;
      this.message = "회원코드(mpe_MemberNo)  " + EnumDataCheck.CodeZero.ToDescription();
      return EnumDataCheck.CodeZero;
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
          if (this.mpe_SiteID == 0L)
            this.mpe_SiteID = p_app_employee.emp_SiteID;
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
      MemberPointExtinctionView pointExtinctionView = this;
      try
      {
        pointExtinctionView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != pointExtinctionView.DataCheck(p_db))
            throw new UniServiceException(pointExtinctionView.message, pointExtinctionView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (pointExtinctionView.mpe_SiteID == 0L)
            pointExtinctionView.mpe_SiteID = p_app_employee.emp_SiteID;
          if (!pointExtinctionView.IsPermit(p_app_employee))
            throw new UniServiceException(pointExtinctionView.message, pointExtinctionView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (!await pointExtinctionView.InsertAsync())
          throw new UniServiceException(pointExtinctionView.message, pointExtinctionView.TableCode.ToDescription() + " 등록 오류");
        pointExtinctionView.db_status = 4;
        pointExtinctionView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        pointExtinctionView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        pointExtinctionView.message = ex.Message;
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
      MemberPointExtinctionView pointExtinctionView = this;
      try
      {
        pointExtinctionView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != pointExtinctionView.DataCheck(p_db))
            throw new UniServiceException(pointExtinctionView.message, pointExtinctionView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!pointExtinctionView.IsPermit(p_app_employee))
          throw new UniServiceException(pointExtinctionView.message, pointExtinctionView.TableCode.ToDescription() + " 권한 검사 실패");
        if (!await pointExtinctionView.UpdateAsync())
          throw new UniServiceException(pointExtinctionView.message, pointExtinctionView.TableCode.ToDescription() + " 변경 오류");
        pointExtinctionView.db_status = 4;
        pointExtinctionView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        pointExtinctionView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        pointExtinctionView.message = ex.Message;
      }
      return false;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.mbr_MemberName = p_rs.GetFieldString("mbr_MemberName");
      this.mbr_MemberType = p_rs.GetFieldInt("mbr_MemberType");
      this.mbr_MemberCycle = p_rs.GetFieldInt("mbr_MemberCycle");
      this.mbr_MemberGrade = p_rs.GetFieldInt("mbr_MemberGrade");
      this.mbr_GroupCode = p_rs.GetFieldString("mbr_GroupCode");
      this.mbr_Status = p_rs.GetFieldInt("mbr_Status");
      this.mt_TypeName = p_rs.GetFieldString("mt_TypeName");
      this.mt_UseYn = p_rs.GetFieldString("mt_UseYn");
      this.mgd_MemberGradeName = p_rs.GetFieldString("mgd_MemberGradeName");
      this.mgd_UseYn = p_rs.GetFieldString("mgd_UseYn");
      this.mg_GroupName = p_rs.GetFieldString("mg_GroupName");
      this.mg_GroupDepth = p_rs.GetFieldInt("mg_GroupDepth");
      this.mg_UseYn = p_rs.GetFieldString("mg_UseYn");
      this.inEmpName = p_rs.GetFieldString("inEmpName");
      this.modEmpName = p_rs.GetFieldString("modEmpName");
      return true;
    }

    public async Task<MemberPointExtinctionView> SelectOneAsync(
      DateTime p_mpe_Date,
      long p_mpe_MemberNo,
      long p_mpe_SiteID = 0)
    {
      MemberPointExtinctionView pointExtinctionView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "mpe_Date",
          (object) p_mpe_Date
        },
        {
          (object) "mpe_MemberNo",
          (object) p_mpe_MemberNo
        }
      };
      if (p_mpe_SiteID > 0L)
        p_param.Add((object) "mpe_SiteID", (object) p_mpe_SiteID);
      return await pointExtinctionView.SelectOneTAsync<MemberPointExtinctionView>((object) p_param);
    }

    public MemberPointExtinctionView SelectOne(
      DateTime p_mpe_Date,
      long p_mpe_MemberNo,
      long p_mpe_SiteID = 0)
    {
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "mpe_Date",
          (object) p_mpe_Date
        },
        {
          (object) "mpe_MemberNo",
          (object) p_mpe_MemberNo
        }
      };
      if (p_mpe_SiteID > 0L)
        p_param.Add((object) "mpe_SiteID", (object) p_mpe_SiteID);
      return this.SelectOneT<MemberPointExtinctionView>((object) p_param);
    }

    public async Task<IList<MemberPointExtinctionView>> SelectListAsync(object p_param)
    {
      MemberPointExtinctionView pointExtinctionView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(pointExtinctionView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, pointExtinctionView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(pointExtinctionView1.GetSelectQuery(p_param)))
        {
          pointExtinctionView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + pointExtinctionView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<MemberPointExtinctionView>) null;
        }
        IList<MemberPointExtinctionView> lt_list = (IList<MemberPointExtinctionView>) new List<MemberPointExtinctionView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            MemberPointExtinctionView pointExtinctionView2 = pointExtinctionView1.OleDB.Create<MemberPointExtinctionView>();
            if (pointExtinctionView2.GetFieldValues(rs))
            {
              pointExtinctionView2.row_number = lt_list.Count + 1;
              lt_list.Add(pointExtinctionView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + pointExtinctionView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<MemberPointExtinctionView> SelectEnumerableAsync(object p_param)
    {
      MemberPointExtinctionView pointExtinctionView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(pointExtinctionView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, pointExtinctionView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(pointExtinctionView1.GetSelectQuery(p_param)))
        {
          pointExtinctionView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + pointExtinctionView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            MemberPointExtinctionView pointExtinctionView2 = pointExtinctionView1.OleDB.Create<MemberPointExtinctionView>();
            if (pointExtinctionView2.GetFieldValues(rs))
            {
              pointExtinctionView2.row_number = ++row_number;
              yield return pointExtinctionView2;
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
      if (p_param is Hashtable hashtable && hashtable.ContainsKey((object) "_KEY_WORD_") && !string.IsNullOrEmpty(hashtable[(object) "_KEY_WORD_"].ToString()))
      {
        stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "mbr_MemberName", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "mt_TypeName", hashtable[(object) "_KEY_WORD_"]));
      }
      return !stringBuilder.ToString().Equals(" WHERE") ? stringBuilder.Replace("WHERE AND", "WHERE").ToString() : string.Empty;
    }

    public override string GetSelectQuery(object p_param)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
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
          if (hashtable.ContainsKey((object) "mpe_SiteID") && Convert.ToInt64(hashtable[(object) "mpe_SiteID"].ToString()) > 0L)
            num = Convert.ToInt64(hashtable[(object) "mpe_SiteID"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS (\nSELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n,T_EMPLOYEE_MOD AS (\nSELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n,T_MEMBER AS (\nSELECT mbr_MemberNo,mbr_SiteID,mbr_MemberName,mbr_MemberType,mbr_MemberCycle,mbr_MemberGrade,mbr_GroupCode,mbr_Status" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) TableCodeType.Member, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("mpe_SiteID"))
            p_param1.Add((object) "mbr_SiteID", dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "mbr_SiteID"))
            p_param1.Add((object) "mbr_SiteID", (object) num);
          stringBuilder.Append("\n");
          stringBuilder.Append(new TMember().GetSelectWhereAnd((object) p_param1));
        }
        else if (num > 0L)
          stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "mbr_SiteID", (object) num));
        stringBuilder.Append(")");
        stringBuilder.Append("\n,T_MEMBER_TYPE AS (\nSELECT mt_TypeCode,mt_SiteID,mt_TypeName,mt_Memo,mt_UseYn" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) TableCodeType.MemberType, (object) DbQueryHelper.ToWithNolock()) + string.Format("\nWHERE {0}={1}", (object) "mt_SiteID", (object) num) + ")");
        stringBuilder.Append("\n,T_MEMBER_GRADE AS (\nSELECT mgd_MemberGrade,mgd_SiteID,mgd_MemberGradeName,mgd_UseYn" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) TableCodeType.MemberGrade, (object) DbQueryHelper.ToWithNolock()) + string.Format("\nWHERE {0}={1}", (object) "mgd_SiteID", (object) num) + ")");
        stringBuilder.Append("\n,T_MEMBER_GROUP AS (\nSELECT mg_GroupCode,mg_SiteID,mg_GroupName,mg_GroupDepth,mg_UseYn" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) TableCodeType.MemberGroup, (object) DbQueryHelper.ToWithNolock()) + string.Format("\nWHERE {0}={1}", (object) "mg_SiteID", (object) num) + ")");
        stringBuilder.Append("\nSELECT  mpe_Date,mpe_MemberNo,mpe_SiteID,mpe_AddPoint,mpe_UsePoint,mpe_ExtinctionPoint,mpe_RemainingPoint,mpe_BeforeUsablePoint,mpe_AfterUsablePoint,mpe_InDate,mpe_InUser,mpe_ModDate,mpe_ModUser\n,mbr_MemberName,mbr_MemberType,mbr_MemberCycle,mbr_MemberGrade,mbr_GroupCode,mbr_Status\n,mt_TypeName,mt_UseYn\n,mgd_MemberGradeName,mgd_UseYn\n,mg_GroupName,mg_GroupDepth,mg_UseYn,inEmpName,modEmpName\nFROM " + DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS) + str + " " + DbQueryHelper.ToWithNolock() + "\nINNER JOIN T_MEMBER ON mpe_MemberNo=mbr_MemberNo AND mpe_SiteID=mbr_SiteID\nLEFT OUTER JOIN T_MEMBER_TYPE ON mbr_MemberType=mt_TypeCode AND mbr_SiteID=vis_mt_SiteID\nLEFT OUTER JOIN T_MEMBER_GRADE ON mbr_MemberGrade=mgd_MemberGrade AND mbr_SiteID=vis_mgd_SiteID\nLEFT OUTER JOIN T_MEMBER_GROUP ON mbr_GroupCode=mg_GroupCode AND mbr_SiteID=vis_mg_SiteID\nLEFT OUTER JOIN T_EMPLOYEE_IN ON mpe_InUser=emp_CodeIn\nLEFT OUTER JOIN T_EMPLOYEE_MOD ON mpe_ModUser=emp_CodeMod");
        if (p_param is Hashtable)
        {
          stringBuilder.Append("\n");
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        }
        if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append("\nORDER BY " + empty);
        else
          stringBuilder.Append("\nORDER BY mpe_Date,mpe_MemberNo");
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) ex.GetHashCode()) + " 내용 : " + ex.Message + "\n" + string.Format(" Query : {0}\n", (object) stringBuilder) + "--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
        stringBuilder.Clear();
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }
  }
}
