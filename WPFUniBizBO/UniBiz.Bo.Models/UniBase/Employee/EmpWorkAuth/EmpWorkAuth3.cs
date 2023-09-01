// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Employee.EmpWorkAuth.EmpWorkAuth3
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.UniBase.Employee.Employee;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniBase.Employee.EmpWorkAuth
{
  public class EmpWorkAuth3 : EmpWorkAuthView<EmpWorkAuth3>
  {
    public override string emp_TypeNoDesc => this.emp_TypeNo != 0 ? Enum2StrConverter.ToCommonCodeTypeMemo(this.emp_SiteID, EnumCommonCodeType.EmpWorkAuth3, this.emp_TypeNo) : string.Empty;

    public override bool emp_IsTypeNoFixed => EmployeeConverter.ToEmpAuth3Fixed(this.emp_TypeNo) != 0;

    public async Task<EmpWorkAuth3> SelectOneAsync(
      int p_emp_Code,
      int p_emp_TypeNo,
      long p_emp_SiteID = 0)
    {
      EmpWorkAuth3 empWorkAuth3_1 = this;
      UniOleDatabase db = (UniOleDatabase) null;
      EmpWorkAuth3 empWorkAuth3_2;
      try
      {
        db = new UniOleDatabase(empWorkAuth3_1.OleDB.ConnectionUrl);
        EmployeeView employeeView = await db.Create<EmployeeView>().SelectOneAsync(p_emp_Code, p_emp_SiteID);
        if (employeeView == null || employeeView.emp_Code == 0)
          throw new Exception(string.Format("데이터({0},{1}) 정보 부족", (object) p_emp_Code, (object) p_emp_SiteID));
        EmpWorkAuth3 empWorkAuth3_3 = new EmpWorkAuth3();
        empWorkAuth3_3.emp_Code = employeeView.emp_Code;
        empWorkAuth3_3.emp_SiteID = employeeView.emp_SiteID;
        empWorkAuth3_3.emp_ProgAuth = employeeView.emp_ProgAuth3;
        empWorkAuth3_3.emp_TypeNo = p_emp_TypeNo;
        empWorkAuth3_3.ColName = "emp_ProgAuth3";
        empWorkAuth3_2 = empWorkAuth3_3;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + empWorkAuth3_1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        db?.Close();
      }
      db = (UniOleDatabase) null;
      return empWorkAuth3_2;
    }

    public async Task<IList<EmpWorkAuth3>> SelectListAsync(int p_emp_Code, long p_emp_SiteID = 0)
    {
      EmpWorkAuth3 empWorkAuth3_1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      IList<EmpWorkAuth3> empWorkAuth3List1;
      try
      {
        db = new UniOleDatabase(empWorkAuth3_1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, empWorkAuth3_1.OleDB.CommandTimeout);
        EmployeeView employeeView = await db.Create<EmployeeView>().SelectOneAsync(p_emp_Code, p_emp_SiteID);
        if (employeeView == null || employeeView.emp_Code == 0)
          throw new Exception(string.Format("데이터({0},{1}) 정보 부족", (object) p_emp_Code, (object) p_emp_SiteID));
        IList<EmpWorkAuth3> empWorkAuth3List2 = (IList<EmpWorkAuth3>) new List<EmpWorkAuth3>();
        foreach (EnumEmpAuth3 enumEmpAuth3 in Enum.GetValues(typeof (EnumEmpAuth3)))
        {
          if (enumEmpAuth3 != EnumEmpAuth3.NONE)
          {
            IList<EmpWorkAuth3> empWorkAuth3List3 = empWorkAuth3List2;
            EmpWorkAuth3 empWorkAuth3_2 = new EmpWorkAuth3();
            empWorkAuth3_2.row_number = empWorkAuth3List2.Count + 1;
            empWorkAuth3_2.emp_Code = employeeView.emp_Code;
            empWorkAuth3_2.emp_SiteID = employeeView.emp_SiteID;
            empWorkAuth3_2.emp_ProgAuth = employeeView.emp_ProgAuth3;
            empWorkAuth3_2.emp_TypeNo = (int) enumEmpAuth3;
            empWorkAuth3_2.ColName = "emp_ProgAuth3";
            empWorkAuth3List3.Add(empWorkAuth3_2);
          }
        }
        empWorkAuth3List1 = empWorkAuth3List2;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + empWorkAuth3_1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
      rs = (UniOleDbRecordset) null;
      db = (UniOleDatabase) null;
      return empWorkAuth3List1;
    }
  }
}
