// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Employee.EmployeeRestServer
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection;
using UniBiz.Bo.Models.JobEvtMessage;
using UniBiz.Bo.Models.UbRest;
using UniBiz.Bo.Models.UniBase.Employee.DataModLog;
using UniBiz.Bo.Models.UniBase.Employee.EmpActionLog;
using UniBiz.Bo.Models.UniBase.Employee.EmpAuthority;
using UniBiz.Bo.Models.UniBase.Employee.EmpImage;
using UniBiz.Bo.Models.UniBase.Employee.Employee;
using UniBiz.Bo.Models.UniBase.Employee.EmpWorkAuth;
using UniinfoNet;
using UniinfoNet.Http.UniBiz;

namespace UniBiz.Bo.Models.UniBase.Employee
{
  [UbRestModel("/Code", TableCodeType.Unknown, HeaderPath = "")]
  public class EmployeeRestServer : BindableBase
  {
    public static UniBizHttpRequest<UbRes<LogInPack>> PostEmployeeLogIn(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_emp_SiteID")] long emp_SiteID,
      LogInPack pData)
    {
      UniBizHttpRequest<UbRes<LogInPack>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<LogInPack>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<EmployeeRestServer>() + "/Employee/LogIn/{emp_SiteID}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<LogInPack>>, long>((Expression<Func<long>>) (() => emp_SiteID));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<LogInPack>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<LogInPack>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<bool>> PostEmployeeLogOut()
    {
      UniBizHttpRequest<UbRes<bool>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<bool>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<EmployeeRestServer>() + "/LogOut";
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<bool>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<EmployeeView>> GetEmployee(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_emp_SiteID")] long emp_SiteID,
      [NameConvert("p_emp_Code")] int emp_Code,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_is_thumb_image")] bool is_thumb_image = false,
      [NameConvert("p_is_origin_image")] bool is_origin_image = false)
    {
      UniBizHttpRequest<UbRes<EmployeeView>> employee = new UniBizHttpRequest<UbRes<EmployeeView>>(HttpMethod.Get);
      employee.Resource = UbRestModelAttribute.GetBasePath<EmployeeRestServer>() + "/Employee/{emp_SiteID}/{emp_Code}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      employee.Headers.Add("Send-Type", SendType);
      employee.SetSegment<UniBizHttpRequest<UbRes<EmployeeView>>, long>((Expression<Func<long>>) (() => emp_SiteID));
      employee.SetSegment<UniBizHttpRequest<UbRes<EmployeeView>>, int>((Expression<Func<int>>) (() => emp_Code));
      employee.SetSegment<UniBizHttpRequest<UbRes<EmployeeView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      employee.SetSegment<UniBizHttpRequest<UbRes<EmployeeView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      employee.SetQuery<UniBizHttpRequest<UbRes<EmployeeView>>, bool>((Expression<Func<bool>>) (() => is_thumb_image));
      employee.SetQuery<UniBizHttpRequest<UbRes<EmployeeView>>, bool>((Expression<Func<bool>>) (() => is_origin_image));
      employee.ReplaceByNameConverter<UniBizHttpRequest<UbRes<EmployeeView>>>(MethodBase.GetCurrentMethod());
      return employee;
    }

    public static UniBizHttpRequest<UbRes<EmployeeView>> PostEmployee(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_emp_SiteID")] long emp_SiteID,
      [NameConvert("p_emp_Code")] int emp_Code,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      EmployeeView pData)
    {
      UniBizHttpRequest<UbRes<EmployeeView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<EmployeeView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<EmployeeRestServer>() + "/Employee/{emp_SiteID}/{emp_Code}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmployeeView>>, long>((Expression<Func<long>>) (() => emp_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmployeeView>>, int>((Expression<Func<int>>) (() => emp_Code));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmployeeView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmployeeView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<EmployeeView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<EmployeeView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<bool>> PutEmployeePassword(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_emp_SiteID")] long emp_SiteID,
      [NameConvert("p_emp_Code")] int emp_Code,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      EmployeePassword pData)
    {
      UniBizHttpRequest<UbRes<bool>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<bool>>(HttpMethod.Put);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<EmployeeRestServer>() + "/Employee/{emp_SiteID}/{emp_Code}/Password/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<bool>>, long>((Expression<Func<long>>) (() => emp_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<bool>>, int>((Expression<Func<int>>) (() => emp_Code));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<bool>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<bool>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<EmployeePassword>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<bool>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<EmployeeView>>> GetEmployeeList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_emp_SiteID")] long emp_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_emp_Code")] int emp_Code = 0,
      [NameConvert("p_emp_BaseStore")] int emp_BaseStore = 0,
      [NameConvert("p_emp_BaseStoreIn")] string emp_BaseStoreIn = null,
      [NameConvert("p_emp_UseYn")] string emp_UseYn = null,
      [NameConvert("p_is_thumb_image")] bool is_thumb_image = false,
      [NameConvert("p_is_origin_image")] bool is_origin_image = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<EmployeeView>>> employeeList = new UniBizHttpRequest<UbRes<IList<EmployeeView>>>(HttpMethod.Get);
      employeeList.Resource = UbRestModelAttribute.GetBasePath<EmployeeRestServer>() + "/Employee/{emp_SiteID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      employeeList.Headers.Add("Send-Type", SendType);
      employeeList.SetSegment<UniBizHttpRequest<UbRes<IList<EmployeeView>>>, long>((Expression<Func<long>>) (() => emp_SiteID));
      employeeList.SetSegment<UniBizHttpRequest<UbRes<IList<EmployeeView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      employeeList.SetSegment<UniBizHttpRequest<UbRes<IList<EmployeeView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (emp_Code > 0)
        employeeList.SetQuery<UniBizHttpRequest<UbRes<IList<EmployeeView>>>, int>((Expression<Func<int>>) (() => emp_Code));
      if (emp_BaseStore > 0)
        employeeList.SetQuery<UniBizHttpRequest<UbRes<IList<EmployeeView>>>, int>((Expression<Func<int>>) (() => emp_BaseStore));
      if (!string.IsNullOrEmpty(emp_BaseStoreIn))
        employeeList.SetQuery<UniBizHttpRequest<UbRes<IList<EmployeeView>>>, string>((Expression<Func<string>>) (() => emp_BaseStoreIn));
      if (!string.IsNullOrEmpty(emp_UseYn))
        employeeList.SetQuery<UniBizHttpRequest<UbRes<IList<EmployeeView>>>, string>((Expression<Func<string>>) (() => emp_UseYn));
      if (is_thumb_image)
        employeeList.SetQuery<UniBizHttpRequest<UbRes<IList<EmployeeView>>>, bool>((Expression<Func<bool>>) (() => is_thumb_image));
      if (is_origin_image)
        employeeList.SetQuery<UniBizHttpRequest<UbRes<IList<EmployeeView>>>, bool>((Expression<Func<bool>>) (() => is_origin_image));
      if (!string.IsNullOrEmpty(KeyWord))
        employeeList.SetQuery<UniBizHttpRequest<UbRes<IList<EmployeeView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      employeeList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<EmployeeView>>>>(MethodBase.GetCurrentMethod());
      return employeeList;
    }

    public static UniBizHttpRequest<UbRes<DataModLogView>> GetDataModLog(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_dml_SiteID")] long dml_SiteID,
      [NameConvert("p_dml_ID")] long dml_ID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<DataModLogView>> dataModLog = new UniBizHttpRequest<UbRes<DataModLogView>>(HttpMethod.Get);
      dataModLog.Resource = UbRestModelAttribute.GetBasePath<EmployeeRestServer>() + "/DataModLog/{dml_SiteID}/{dml_ID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      dataModLog.Headers.Add("Send-Type", SendType);
      dataModLog.SetSegment<UniBizHttpRequest<UbRes<DataModLogView>>, long>((Expression<Func<long>>) (() => dml_SiteID));
      dataModLog.SetSegment<UniBizHttpRequest<UbRes<DataModLogView>>, long>((Expression<Func<long>>) (() => dml_ID));
      dataModLog.SetSegment<UniBizHttpRequest<UbRes<DataModLogView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      dataModLog.SetSegment<UniBizHttpRequest<UbRes<DataModLogView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      dataModLog.ReplaceByNameConverter<UniBizHttpRequest<UbRes<DataModLogView>>>(MethodBase.GetCurrentMethod());
      return dataModLog;
    }

    public static UniBizHttpRequest<UbRes<IList<DataModLogView>>> GetDataModLogList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_dml_SiteID")] long dml_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_dml_ID")] long dml_ID = 0,
      [NameConvert("p_dml_SysDate")] long dml_SysDate = 0,
      [NameConvert("p_dml_SysDate_Begin")] long dml_SysDate_Begin = 0,
      [NameConvert("p_dml_SysDate_End")] long dml_SysDate_End = 0,
      [NameConvert("p_dml_CodeInt")] int dml_CodeInt = 0,
      [NameConvert("p_dml_CodeLong")] long dml_CodeLong = 0,
      [NameConvert("p_dml_CodeStr")] string dml_CodeStr = null,
      [NameConvert("p_dml_ActionKind")] int dml_ActionKind = 0,
      [NameConvert("p_dml_TableSeq")] int dml_TableSeq = 0,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_emp_Code")] int emp_Code = 0,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<DataModLogView>>> dataModLogList = new UniBizHttpRequest<UbRes<IList<DataModLogView>>>(HttpMethod.Get);
      dataModLogList.Resource = UbRestModelAttribute.GetBasePath<EmployeeRestServer>() + "/DataModLog/{dml_SiteID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      dataModLogList.Headers.Add("Send-Type", SendType);
      dataModLogList.SetSegment<UniBizHttpRequest<UbRes<IList<DataModLogView>>>, long>((Expression<Func<long>>) (() => dml_SiteID));
      dataModLogList.SetSegment<UniBizHttpRequest<UbRes<IList<DataModLogView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      dataModLogList.SetSegment<UniBizHttpRequest<UbRes<IList<DataModLogView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (dml_ID > 0L)
        dataModLogList.SetQuery<UniBizHttpRequest<UbRes<IList<DataModLogView>>>, long>((Expression<Func<long>>) (() => dml_ID));
      if (dml_SysDate > 0L)
        dataModLogList.SetQuery<UniBizHttpRequest<UbRes<IList<DataModLogView>>>, long>((Expression<Func<long>>) (() => dml_SysDate));
      if (dml_SysDate_Begin > 0L)
        dataModLogList.SetQuery<UniBizHttpRequest<UbRes<IList<DataModLogView>>>, long>((Expression<Func<long>>) (() => dml_SysDate_Begin));
      if (dml_SysDate_End > 0L)
        dataModLogList.SetQuery<UniBizHttpRequest<UbRes<IList<DataModLogView>>>, long>((Expression<Func<long>>) (() => dml_SysDate_End));
      if (dml_CodeInt > 0)
        dataModLogList.SetQuery<UniBizHttpRequest<UbRes<IList<DataModLogView>>>, int>((Expression<Func<int>>) (() => dml_CodeInt));
      if (dml_CodeLong > 0L)
        dataModLogList.SetQuery<UniBizHttpRequest<UbRes<IList<DataModLogView>>>, long>((Expression<Func<long>>) (() => dml_CodeLong));
      if (!string.IsNullOrEmpty(dml_CodeStr))
        dataModLogList.SetQuery<UniBizHttpRequest<UbRes<IList<DataModLogView>>>, string>((Expression<Func<string>>) (() => dml_CodeStr));
      if (dml_ActionKind > 0)
        dataModLogList.SetQuery<UniBizHttpRequest<UbRes<IList<DataModLogView>>>, int>((Expression<Func<int>>) (() => dml_ActionKind));
      if (dml_TableSeq > 0)
        dataModLogList.SetQuery<UniBizHttpRequest<UbRes<IList<DataModLogView>>>, int>((Expression<Func<int>>) (() => dml_TableSeq));
      if (si_StoreCode > 0)
        dataModLogList.SetQuery<UniBizHttpRequest<UbRes<IList<DataModLogView>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
        dataModLogList.SetQuery<UniBizHttpRequest<UbRes<IList<DataModLogView>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
      if (emp_Code > 0)
        dataModLogList.SetQuery<UniBizHttpRequest<UbRes<IList<DataModLogView>>>, int>((Expression<Func<int>>) (() => emp_Code));
      if (!string.IsNullOrEmpty(KeyWord))
        dataModLogList.SetQuery<UniBizHttpRequest<UbRes<IList<DataModLogView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      dataModLogList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<DataModLogView>>>>(MethodBase.GetCurrentMethod());
      return dataModLogList;
    }

    public static UniBizHttpRequest<UbRes<EmpActionLogView>> GetEmpActionLog(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_eal_SiteID")] long eal_SiteID,
      [NameConvert("p_eal_ID")] long eal_ID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<EmpActionLogView>> empActionLog = new UniBizHttpRequest<UbRes<EmpActionLogView>>(HttpMethod.Get);
      empActionLog.Resource = UbRestModelAttribute.GetBasePath<EmployeeRestServer>() + "/EmpActionLog/{eal_SiteID}/{eal_ID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      empActionLog.Headers.Add("Send-Type", SendType);
      empActionLog.SetSegment<UniBizHttpRequest<UbRes<EmpActionLogView>>, long>((Expression<Func<long>>) (() => eal_SiteID));
      empActionLog.SetSegment<UniBizHttpRequest<UbRes<EmpActionLogView>>, long>((Expression<Func<long>>) (() => eal_ID));
      empActionLog.SetSegment<UniBizHttpRequest<UbRes<EmpActionLogView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      empActionLog.SetSegment<UniBizHttpRequest<UbRes<EmpActionLogView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      empActionLog.ReplaceByNameConverter<UniBizHttpRequest<UbRes<EmpActionLogView>>>(MethodBase.GetCurrentMethod());
      return empActionLog;
    }

    public static UniBizHttpRequest<UbRes<EmpActionLogView>> PostEmpActionLog(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_eal_SiteID")] long eal_SiteID,
      [NameConvert("p_eal_ID")] long eal_ID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      EmpActionLogView pData)
    {
      UniBizHttpRequest<UbRes<EmpActionLogView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<EmpActionLogView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<EmployeeRestServer>() + "/EmpActionLog/{eal_SiteID}/{eal_ID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpActionLogView>>, long>((Expression<Func<long>>) (() => eal_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpActionLogView>>, long>((Expression<Func<long>>) (() => eal_ID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpActionLogView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpActionLogView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<EmpActionLogView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<EmpActionLogView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<EmpActionLogView>>> GetEmpActionLogList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_eal_SiteID")] long eal_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_eal_ID")] long eal_ID = 0,
      [NameConvert("p_eal_SysDate")] long eal_SysDate = 0,
      [NameConvert("p_eal_SysDate_Begin")] long eal_SysDate_Begin = 0,
      [NameConvert("p_eal_SysDate_End")] long eal_SysDate_End = 0,
      [NameConvert("p_eal_ActionKind")] int eal_ActionKind = 0,
      [NameConvert("p_eal_ProgKind")] int eal_ProgKind = 0,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_emp_Code")] int emp_Code = 0,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<EmpActionLogView>>> empActionLogList = new UniBizHttpRequest<UbRes<IList<EmpActionLogView>>>(HttpMethod.Get);
      empActionLogList.Resource = UbRestModelAttribute.GetBasePath<EmployeeRestServer>() + "/EmpActionLog/{eal_SiteID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      empActionLogList.Headers.Add("Send-Type", SendType);
      empActionLogList.SetSegment<UniBizHttpRequest<UbRes<IList<EmpActionLogView>>>, long>((Expression<Func<long>>) (() => eal_SiteID));
      empActionLogList.SetSegment<UniBizHttpRequest<UbRes<IList<EmpActionLogView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      empActionLogList.SetSegment<UniBizHttpRequest<UbRes<IList<EmpActionLogView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (eal_ID > 0L)
        empActionLogList.SetQuery<UniBizHttpRequest<UbRes<IList<EmpActionLogView>>>, long>((Expression<Func<long>>) (() => eal_ID));
      if (eal_SysDate > 0L)
        empActionLogList.SetQuery<UniBizHttpRequest<UbRes<IList<EmpActionLogView>>>, long>((Expression<Func<long>>) (() => eal_SysDate));
      if (eal_SysDate_Begin > 0L)
        empActionLogList.SetQuery<UniBizHttpRequest<UbRes<IList<EmpActionLogView>>>, long>((Expression<Func<long>>) (() => eal_SysDate_Begin));
      if (eal_SysDate_End > 0L)
        empActionLogList.SetQuery<UniBizHttpRequest<UbRes<IList<EmpActionLogView>>>, long>((Expression<Func<long>>) (() => eal_SysDate_End));
      if (eal_ActionKind > 0)
        empActionLogList.SetQuery<UniBizHttpRequest<UbRes<IList<EmpActionLogView>>>, int>((Expression<Func<int>>) (() => eal_ActionKind));
      if (eal_ProgKind > 0)
        empActionLogList.SetQuery<UniBizHttpRequest<UbRes<IList<EmpActionLogView>>>, int>((Expression<Func<int>>) (() => eal_ProgKind));
      if (si_StoreCode > 0)
        empActionLogList.SetQuery<UniBizHttpRequest<UbRes<IList<EmpActionLogView>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
        empActionLogList.SetQuery<UniBizHttpRequest<UbRes<IList<EmpActionLogView>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
      if (emp_Code > 0)
        empActionLogList.SetQuery<UniBizHttpRequest<UbRes<IList<EmpActionLogView>>>, int>((Expression<Func<int>>) (() => emp_Code));
      if (!string.IsNullOrEmpty(KeyWord))
        empActionLogList.SetQuery<UniBizHttpRequest<UbRes<IList<EmpActionLogView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      empActionLogList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<EmpActionLogView>>>>(MethodBase.GetCurrentMethod());
      return empActionLogList;
    }

    public static UniBizHttpRequest<UbRes<EmpAuthorityStore>> GetEmpAuthorityStore(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ea_SiteID")] long ea_SiteID,
      [NameConvert("p_ea_EmpCode")] int ea_EmpCode,
      [NameConvert("p_ea_AuthType")] int ea_AuthType,
      [NameConvert("p_ea_AuthValue")] string ea_AuthValue,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<EmpAuthorityStore>> empAuthorityStore = new UniBizHttpRequest<UbRes<EmpAuthorityStore>>(HttpMethod.Get);
      empAuthorityStore.Resource = UbRestModelAttribute.GetBasePath<EmployeeRestServer>() + "/Employee/{ea_SiteID}/{ea_EmpCode}/EmpAuthority/Store/{ea_AuthType}/{ea_AuthValue}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      empAuthorityStore.Headers.Add("Send-Type", SendType);
      empAuthorityStore.SetSegment<UniBizHttpRequest<UbRes<EmpAuthorityStore>>, long>((Expression<Func<long>>) (() => ea_SiteID));
      empAuthorityStore.SetSegment<UniBizHttpRequest<UbRes<EmpAuthorityStore>>, int>((Expression<Func<int>>) (() => ea_EmpCode));
      empAuthorityStore.SetSegment<UniBizHttpRequest<UbRes<EmpAuthorityStore>>, int>((Expression<Func<int>>) (() => ea_AuthType));
      empAuthorityStore.SetSegment<UniBizHttpRequest<UbRes<EmpAuthorityStore>>, string>((Expression<Func<string>>) (() => ea_AuthValue));
      empAuthorityStore.SetSegment<UniBizHttpRequest<UbRes<EmpAuthorityStore>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      empAuthorityStore.SetSegment<UniBizHttpRequest<UbRes<EmpAuthorityStore>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      empAuthorityStore.ReplaceByNameConverter<UniBizHttpRequest<UbRes<EmpAuthorityStore>>>(MethodBase.GetCurrentMethod());
      return empAuthorityStore;
    }

    public static UniBizHttpRequest<UbRes<EmpAuthorityStore>> PostEmpAuthorityStore(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ea_SiteID")] long ea_SiteID,
      [NameConvert("p_ea_EmpCode")] int ea_EmpCode,
      [NameConvert("p_ea_AuthType")] int ea_AuthType,
      [NameConvert("p_ea_AuthValue")] string ea_AuthValue,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      EmpAuthorityStore pData)
    {
      UniBizHttpRequest<UbRes<EmpAuthorityStore>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<EmpAuthorityStore>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<EmployeeRestServer>() + "/Employee/{ea_SiteID}/{ea_EmpCode}/EmpAuthority/Store/{ea_AuthType}/{ea_AuthValue}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpAuthorityStore>>, long>((Expression<Func<long>>) (() => ea_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpAuthorityStore>>, int>((Expression<Func<int>>) (() => ea_EmpCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpAuthorityStore>>, int>((Expression<Func<int>>) (() => ea_AuthType));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpAuthorityStore>>, string>((Expression<Func<string>>) (() => ea_AuthValue));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpAuthorityStore>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpAuthorityStore>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<EmpAuthorityStore>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<EmpAuthorityStore>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<EmpAuthorityStore>> DeleteEmpAuthorityStore(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ea_SiteID")] long ea_SiteID,
      [NameConvert("p_ea_EmpCode")] int ea_EmpCode,
      [NameConvert("p_ea_AuthType")] int ea_AuthType,
      [NameConvert("p_ea_AuthValue")] string ea_AuthValue,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<EmpAuthorityStore>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<EmpAuthorityStore>>(HttpMethod.Delete);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<EmployeeRestServer>() + "/Employee/{ea_SiteID}/{ea_EmpCode}/EmpAuthority/Store/{ea_AuthType}/{ea_AuthValue}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpAuthorityStore>>, long>((Expression<Func<long>>) (() => ea_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpAuthorityStore>>, int>((Expression<Func<int>>) (() => ea_EmpCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpAuthorityStore>>, int>((Expression<Func<int>>) (() => ea_AuthType));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpAuthorityStore>>, string>((Expression<Func<string>>) (() => ea_AuthValue));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpAuthorityStore>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpAuthorityStore>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<EmpAuthorityStore>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<EmpAuthorityStore>>> GetEmpAuthorityStoreList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ea_SiteID")] long ea_SiteID,
      [NameConvert("p_ea_EmpCode")] int ea_EmpCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_UseYn")] string UseYn = null,
      [NameConvert("p_config")] int config = 0)
    {
      UniBizHttpRequest<UbRes<IList<EmpAuthorityStore>>> authorityStoreList = new UniBizHttpRequest<UbRes<IList<EmpAuthorityStore>>>(HttpMethod.Get);
      authorityStoreList.Resource = UbRestModelAttribute.GetBasePath<EmployeeRestServer>() + "/Employee/{ea_SiteID}/{ea_EmpCode}/EmpAuthority/Store/{work_pm_MenuCode}/{work_pmp_PropCode}";
      authorityStoreList.Headers.Add("Send-Type", SendType);
      authorityStoreList.SetSegment<UniBizHttpRequest<UbRes<IList<EmpAuthorityStore>>>, long>((Expression<Func<long>>) (() => ea_SiteID));
      authorityStoreList.SetSegment<UniBizHttpRequest<UbRes<IList<EmpAuthorityStore>>>, int>((Expression<Func<int>>) (() => ea_EmpCode));
      authorityStoreList.SetSegment<UniBizHttpRequest<UbRes<IList<EmpAuthorityStore>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      authorityStoreList.SetSegment<UniBizHttpRequest<UbRes<IList<EmpAuthorityStore>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (si_StoreCode > 0)
        authorityStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<EmpAuthorityStore>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(UseYn))
        authorityStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<EmpAuthorityStore>>>, string>((Expression<Func<string>>) (() => UseYn));
      if (config > 0)
        authorityStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<EmpAuthorityStore>>>, int>((Expression<Func<int>>) (() => config));
      authorityStoreList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<EmpAuthorityStore>>>>(MethodBase.GetCurrentMethod());
      return authorityStoreList;
    }

    public static UniBizHttpRequest<UbRes<IList<EmpAuthorityStore>>> PostEmpAuthorityStoreList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ea_SiteID")] long ea_SiteID,
      [NameConvert("p_ea_EmpCode")] int ea_EmpCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      IList<EmpAuthorityStore> p_list)
    {
      UniBizHttpRequest<UbRes<IList<EmpAuthorityStore>>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<IList<EmpAuthorityStore>>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<EmployeeRestServer>() + "/Employee/{ea_SiteID}/{ea_EmpCode}/EmpAuthority/Store/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<EmpAuthorityStore>>>, long>((Expression<Func<long>>) (() => ea_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<EmpAuthorityStore>>>, int>((Expression<Func<int>>) (() => ea_EmpCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<EmpAuthorityStore>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<EmpAuthorityStore>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<IList<EmpAuthorityStore>>(p_list, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<EmpAuthorityStore>>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<EmpAuthorityStore>>> DeleteEmpAuthorityStoreList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ea_SiteID")] long ea_SiteID,
      [NameConvert("p_ea_EmpCode")] int ea_EmpCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      IList<EmpAuthorityStore> p_list)
    {
      UniBizHttpRequest<UbRes<IList<EmpAuthorityStore>>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<IList<EmpAuthorityStore>>>(HttpMethod.Delete);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<EmployeeRestServer>() + "/Employee/{ea_SiteID}/{ea_EmpCode}/EmpAuthority/Store/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<EmpAuthorityStore>>>, long>((Expression<Func<long>>) (() => ea_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<EmpAuthorityStore>>>, int>((Expression<Func<int>>) (() => ea_EmpCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<EmpAuthorityStore>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<EmpAuthorityStore>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<IList<EmpAuthorityStore>>(p_list, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<EmpAuthorityStore>>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<EmpAuthoritySupplier>> GetEmpAuthoritySupplier(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ea_SiteID")] long ea_SiteID,
      [NameConvert("p_ea_EmpCode")] int ea_EmpCode,
      [NameConvert("p_ea_AuthValue")] string ea_AuthValue,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<EmpAuthoritySupplier>> authoritySupplier = new UniBizHttpRequest<UbRes<EmpAuthoritySupplier>>(HttpMethod.Get);
      authoritySupplier.Resource = UbRestModelAttribute.GetBasePath<EmployeeRestServer>() + "/Employee/{ea_SiteID}/{ea_EmpCode}/EmpAuthority/Supplier/{ea_AuthValue}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      authoritySupplier.Headers.Add("Send-Type", SendType);
      authoritySupplier.SetSegment<UniBizHttpRequest<UbRes<EmpAuthoritySupplier>>, long>((Expression<Func<long>>) (() => ea_SiteID));
      authoritySupplier.SetSegment<UniBizHttpRequest<UbRes<EmpAuthoritySupplier>>, int>((Expression<Func<int>>) (() => ea_EmpCode));
      authoritySupplier.SetSegment<UniBizHttpRequest<UbRes<EmpAuthoritySupplier>>, string>((Expression<Func<string>>) (() => ea_AuthValue));
      authoritySupplier.SetSegment<UniBizHttpRequest<UbRes<EmpAuthoritySupplier>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      authoritySupplier.SetSegment<UniBizHttpRequest<UbRes<EmpAuthoritySupplier>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      authoritySupplier.ReplaceByNameConverter<UniBizHttpRequest<UbRes<EmpAuthoritySupplier>>>(MethodBase.GetCurrentMethod());
      return authoritySupplier;
    }

    public static UniBizHttpRequest<UbRes<EmpAuthoritySupplier>> PostEmpAuthoritySupplier(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ea_SiteID")] long ea_SiteID,
      [NameConvert("p_ea_EmpCode")] int ea_EmpCode,
      [NameConvert("p_ea_AuthValue")] string ea_AuthValue,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      EmpAuthoritySupplier pData)
    {
      UniBizHttpRequest<UbRes<EmpAuthoritySupplier>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<EmpAuthoritySupplier>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<EmployeeRestServer>() + "/Employee/{ea_SiteID}/{ea_EmpCode}/EmpAuthority/Supplier/{ea_AuthValue}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpAuthoritySupplier>>, long>((Expression<Func<long>>) (() => ea_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpAuthoritySupplier>>, int>((Expression<Func<int>>) (() => ea_EmpCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpAuthoritySupplier>>, string>((Expression<Func<string>>) (() => ea_AuthValue));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpAuthoritySupplier>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpAuthoritySupplier>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<EmpAuthoritySupplier>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<EmpAuthoritySupplier>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<EmpAuthoritySupplier>> DeleteEmpAuthoritySupplier(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ea_SiteID")] long ea_SiteID,
      [NameConvert("p_ea_EmpCode")] int ea_EmpCode,
      [NameConvert("p_ea_AuthValue")] string ea_AuthValue,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<EmpAuthoritySupplier>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<EmpAuthoritySupplier>>(HttpMethod.Delete);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<EmployeeRestServer>() + "/Employee/{ea_SiteID}/{ea_EmpCode}/EmpAuthority/Supplier/{ea_AuthValue}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpAuthoritySupplier>>, long>((Expression<Func<long>>) (() => ea_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpAuthoritySupplier>>, int>((Expression<Func<int>>) (() => ea_EmpCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpAuthoritySupplier>>, string>((Expression<Func<string>>) (() => ea_AuthValue));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpAuthoritySupplier>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpAuthoritySupplier>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<EmpAuthoritySupplier>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<EmpAuthoritySupplier>>> GetEmpAuthoritySupplierList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ea_SiteID")] long ea_SiteID,
      [NameConvert("p_ea_EmpCode")] int ea_EmpCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_UseYn")] string UseYn = null)
    {
      UniBizHttpRequest<UbRes<IList<EmpAuthoritySupplier>>> authoritySupplierList = new UniBizHttpRequest<UbRes<IList<EmpAuthoritySupplier>>>(HttpMethod.Get);
      authoritySupplierList.Resource = UbRestModelAttribute.GetBasePath<EmployeeRestServer>() + "/Employee/{ea_SiteID}/{ea_EmpCode}/EmpAuthority/Supplier/{work_pm_MenuCode}/{work_pmp_PropCode}";
      authoritySupplierList.Headers.Add("Send-Type", SendType);
      authoritySupplierList.SetSegment<UniBizHttpRequest<UbRes<IList<EmpAuthoritySupplier>>>, long>((Expression<Func<long>>) (() => ea_SiteID));
      authoritySupplierList.SetSegment<UniBizHttpRequest<UbRes<IList<EmpAuthoritySupplier>>>, int>((Expression<Func<int>>) (() => ea_EmpCode));
      authoritySupplierList.SetSegment<UniBizHttpRequest<UbRes<IList<EmpAuthoritySupplier>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      authoritySupplierList.SetSegment<UniBizHttpRequest<UbRes<IList<EmpAuthoritySupplier>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (si_StoreCode > 0)
        authoritySupplierList.SetQuery<UniBizHttpRequest<UbRes<IList<EmpAuthoritySupplier>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(UseYn))
        authoritySupplierList.SetQuery<UniBizHttpRequest<UbRes<IList<EmpAuthoritySupplier>>>, string>((Expression<Func<string>>) (() => UseYn));
      authoritySupplierList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<EmpAuthoritySupplier>>>>(MethodBase.GetCurrentMethod());
      return authoritySupplierList;
    }

    public static UniBizHttpRequest<UbRes<IList<EmpAuthoritySupplier>>> PostEmpAuthoritySupplierList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ea_SiteID")] long ea_SiteID,
      [NameConvert("p_ea_EmpCode")] int ea_EmpCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      IList<EmpAuthoritySupplier> p_list)
    {
      UniBizHttpRequest<UbRes<IList<EmpAuthoritySupplier>>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<IList<EmpAuthoritySupplier>>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<EmployeeRestServer>() + "/Employee/{ea_SiteID}/{ea_EmpCode}/EmpAuthority/Supplier/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<EmpAuthoritySupplier>>>, long>((Expression<Func<long>>) (() => ea_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<EmpAuthoritySupplier>>>, int>((Expression<Func<int>>) (() => ea_EmpCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<EmpAuthoritySupplier>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<EmpAuthoritySupplier>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<IList<EmpAuthoritySupplier>>(p_list, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<EmpAuthoritySupplier>>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<EmpAuthoritySupplier>>> DeleteEmpAuthoritySupplierList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ea_SiteID")] long ea_SiteID,
      [NameConvert("p_ea_EmpCode")] int ea_EmpCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      IList<EmpAuthoritySupplier> p_list)
    {
      UniBizHttpRequest<UbRes<IList<EmpAuthoritySupplier>>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<IList<EmpAuthoritySupplier>>>(HttpMethod.Delete);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<EmployeeRestServer>() + "/Employee/{ea_SiteID}/{ea_EmpCode}/EmpAuthority/Supplier/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<EmpAuthoritySupplier>>>, long>((Expression<Func<long>>) (() => ea_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<EmpAuthoritySupplier>>>, int>((Expression<Func<int>>) (() => ea_EmpCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<EmpAuthoritySupplier>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<EmpAuthoritySupplier>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<IList<EmpAuthoritySupplier>>(p_list, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<EmpAuthoritySupplier>>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<EmpImageView>> GetEmpImage(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ei_SiteID")] long ei_SiteID,
      [NameConvert("p_ei_EmpCode")] int ei_EmpCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_is_thumb_image")] bool is_thumb_image = false,
      [NameConvert("p_is_origin_image")] bool is_origin_image = false)
    {
      UniBizHttpRequest<UbRes<EmpImageView>> empImage = new UniBizHttpRequest<UbRes<EmpImageView>>(HttpMethod.Get);
      empImage.Resource = UbRestModelAttribute.GetBasePath<EmployeeRestServer>() + "/Employee/{ei_SiteID}/{ei_EmpCode}/Image/{work_pm_MenuCode}/{work_pmp_PropCode}";
      empImage.Headers.Add("Send-Type", SendType);
      empImage.SetSegment<UniBizHttpRequest<UbRes<EmpImageView>>, long>((Expression<Func<long>>) (() => ei_SiteID));
      empImage.SetSegment<UniBizHttpRequest<UbRes<EmpImageView>>, int>((Expression<Func<int>>) (() => ei_EmpCode));
      empImage.SetSegment<UniBizHttpRequest<UbRes<EmpImageView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      empImage.SetSegment<UniBizHttpRequest<UbRes<EmpImageView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      empImage.SetQuery<UniBizHttpRequest<UbRes<EmpImageView>>, bool>((Expression<Func<bool>>) (() => is_thumb_image));
      empImage.SetQuery<UniBizHttpRequest<UbRes<EmpImageView>>, bool>((Expression<Func<bool>>) (() => is_origin_image));
      empImage.ReplaceByNameConverter<UniBizHttpRequest<UbRes<EmpImageView>>>(MethodBase.GetCurrentMethod());
      return empImage;
    }

    public static UniBizHttpRequest<UbRes<EmpImageView>> DeleteEmpImage(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ei_SiteID")] long ei_SiteID,
      [NameConvert("p_ei_EmpCode")] int ei_EmpCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<EmpImageView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<EmpImageView>>(HttpMethod.Delete);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<EmployeeRestServer>() + "/Employee/{ei_SiteID}/{ei_EmpCode}/Image/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpImageView>>, long>((Expression<Func<long>>) (() => ei_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpImageView>>, int>((Expression<Func<int>>) (() => ei_EmpCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpImageView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpImageView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<EmpImageView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<EmpImageView>> PostEmpImageFile(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ei_SiteID")] long ei_SiteID,
      [NameConvert("p_ei_EmpCode")] int ei_EmpCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      string fileName,
      Stream dataStream)
    {
      UniBizHttpRequest<UbRes<EmpImageView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<EmpImageView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<EmployeeRestServer>() + "/Employee/{ei_SiteID}/{ei_EmpCode}/Image/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpImageView>>, long>((Expression<Func<long>>) (() => ei_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpImageView>>, int>((Expression<Func<int>>) (() => ei_EmpCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpImageView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpImageView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) new MultipartFormDataContent()
      {
        {
          (HttpContent) new StreamContent(dataStream),
          "p_File",
          fileName
        }
      };
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<EmpImageView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<EmpImageView>> PostEmpImageFile(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ei_SiteID")] long ei_SiteID,
      [NameConvert("p_ei_EmpCode")] int ei_EmpCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      string fileName,
      byte[] fileData)
    {
      UniBizHttpRequest<UbRes<EmpImageView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<EmpImageView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<EmployeeRestServer>() + "/Employee/{ei_SiteID}/{ei_EmpCode}/Image/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpImageView>>, long>((Expression<Func<long>>) (() => ei_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpImageView>>, int>((Expression<Func<int>>) (() => ei_EmpCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpImageView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpImageView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) new MultipartFormDataContent()
      {
        {
          (HttpContent) new ByteArrayContent(fileData),
          "p_File",
          fileName
        }
      };
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<EmpImageView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest GetEmpImageThumb(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ei_SiteID")] long ei_SiteID,
      [NameConvert("p_ei_EmpCode")] int ei_EmpCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest empImageThumb = new UniBizHttpRequest(HttpMethod.Get);
      empImageThumb.Resource = UbRestModelAttribute.GetBasePath<EmployeeRestServer>() + "/Employee/{ei_SiteID}/{ei_EmpCode}/Image/Thumb/{work_pm_MenuCode}/{work_pmp_PropCode}";
      empImageThumb.Headers.Add("Send-Type", SendType);
      empImageThumb.SetSegment<UniBizHttpRequest, long>((Expression<Func<long>>) (() => ei_SiteID));
      empImageThumb.SetSegment<UniBizHttpRequest, int>((Expression<Func<int>>) (() => ei_EmpCode));
      empImageThumb.SetSegment<UniBizHttpRequest, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      empImageThumb.SetSegment<UniBizHttpRequest, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      empImageThumb.ReplaceByNameConverter<UniBizHttpRequest>(MethodBase.GetCurrentMethod());
      return empImageThumb;
    }

    public static UniBizHttpRequest GetEmpImageOrigin(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ei_SiteID")] long ei_SiteID,
      [NameConvert("p_ei_EmpCode")] int ei_EmpCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest empImageOrigin = new UniBizHttpRequest(HttpMethod.Get);
      empImageOrigin.Resource = UbRestModelAttribute.GetBasePath<EmployeeRestServer>() + "/Employee/{ei_SiteID}/{ei_EmpCode}/Image/Origin/{work_pm_MenuCode}/{work_pmp_PropCode}";
      empImageOrigin.Headers.Add("Send-Type", SendType);
      empImageOrigin.SetSegment<UniBizHttpRequest, long>((Expression<Func<long>>) (() => ei_SiteID));
      empImageOrigin.SetSegment<UniBizHttpRequest, int>((Expression<Func<int>>) (() => ei_EmpCode));
      empImageOrigin.SetSegment<UniBizHttpRequest, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      empImageOrigin.SetSegment<UniBizHttpRequest, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      empImageOrigin.ReplaceByNameConverter<UniBizHttpRequest>(MethodBase.GetCurrentMethod());
      return empImageOrigin;
    }

    public static UniBizHttpRequest GetEmpImageFile(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ei_SiteID")] long ei_SiteID,
      [NameConvert("p_ei_EmpCode")] int ei_EmpCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest empImageFile = new UniBizHttpRequest(HttpMethod.Get);
      empImageFile.Resource = UbRestModelAttribute.GetBasePath<EmployeeRestServer>() + "/Employee/{ei_SiteID}/{ei_EmpCode}/Image/File/{work_pm_MenuCode}/{work_pmp_PropCode}";
      empImageFile.Headers.Add("Send-Type", SendType);
      empImageFile.SetSegment<UniBizHttpRequest, long>((Expression<Func<long>>) (() => ei_SiteID));
      empImageFile.SetSegment<UniBizHttpRequest, int>((Expression<Func<int>>) (() => ei_EmpCode));
      empImageFile.SetSegment<UniBizHttpRequest, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      empImageFile.SetSegment<UniBizHttpRequest, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      empImageFile.ReplaceByNameConverter<UniBizHttpRequest>(MethodBase.GetCurrentMethod());
      return empImageFile;
    }

    public static UniBizHttpRequest<UbRes<EmpWorkAuth1>> GetEmpWorkAuth1(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_emp_SiteID")] long emp_SiteID,
      [NameConvert("p_emp_Code")] int emp_Code,
      [NameConvert("p_emp_TypeNo")] int emp_TypeNo,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<EmpWorkAuth1>> empWorkAuth1 = new UniBizHttpRequest<UbRes<EmpWorkAuth1>>(HttpMethod.Get);
      empWorkAuth1.Resource = UbRestModelAttribute.GetBasePath<EmployeeRestServer>() + "/Employee/{emp_SiteID}/{emp_Code}/EmpWorkAuth1/{emp_TypeNo}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      empWorkAuth1.Headers.Add("Send-Type", SendType);
      empWorkAuth1.SetSegment<UniBizHttpRequest<UbRes<EmpWorkAuth1>>, long>((Expression<Func<long>>) (() => emp_SiteID));
      empWorkAuth1.SetSegment<UniBizHttpRequest<UbRes<EmpWorkAuth1>>, int>((Expression<Func<int>>) (() => emp_Code));
      empWorkAuth1.SetSegment<UniBizHttpRequest<UbRes<EmpWorkAuth1>>, int>((Expression<Func<int>>) (() => emp_TypeNo));
      empWorkAuth1.SetSegment<UniBizHttpRequest<UbRes<EmpWorkAuth1>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      empWorkAuth1.SetSegment<UniBizHttpRequest<UbRes<EmpWorkAuth1>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      empWorkAuth1.ReplaceByNameConverter<UniBizHttpRequest<UbRes<EmpWorkAuth1>>>(MethodBase.GetCurrentMethod());
      return empWorkAuth1;
    }

    public static UniBizHttpRequest<UbRes<EmpWorkAuth1>> PostEmpWorkAuth1(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_emp_SiteID")] long emp_SiteID,
      [NameConvert("p_emp_Code")] int emp_Code,
      [NameConvert("p_emp_TypeNo")] int emp_TypeNo,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      EmpWorkAuth1 pData)
    {
      UniBizHttpRequest<UbRes<EmpWorkAuth1>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<EmpWorkAuth1>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<EmployeeRestServer>() + "/Employee/{emp_SiteID}/{emp_Code}/EmpWorkAuth1/{emp_TypeNo}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpWorkAuth1>>, long>((Expression<Func<long>>) (() => emp_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpWorkAuth1>>, int>((Expression<Func<int>>) (() => emp_Code));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpWorkAuth1>>, int>((Expression<Func<int>>) (() => emp_TypeNo));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpWorkAuth1>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpWorkAuth1>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<EmpWorkAuth1>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<EmpWorkAuth1>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<EmpWorkAuth1>> DeleteEmpWorkAuth1(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_emp_SiteID")] long emp_SiteID,
      [NameConvert("p_emp_Code")] int emp_Code,
      [NameConvert("p_emp_TypeNo")] int emp_TypeNo,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<EmpWorkAuth1>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<EmpWorkAuth1>>(HttpMethod.Delete);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<EmployeeRestServer>() + "/Employee/{emp_SiteID}/{emp_Code}/EmpWorkAuth1/{emp_TypeNo}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpWorkAuth1>>, long>((Expression<Func<long>>) (() => emp_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpWorkAuth1>>, int>((Expression<Func<int>>) (() => emp_Code));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpWorkAuth1>>, int>((Expression<Func<int>>) (() => emp_TypeNo));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpWorkAuth1>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpWorkAuth1>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<EmpWorkAuth1>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<EmpWorkAuth1>>> GetEmpWorkAuth1List(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_emp_SiteID")] long emp_SiteID,
      [NameConvert("p_emp_Code")] int emp_Code,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<IList<EmpWorkAuth1>>> empWorkAuth1List = new UniBizHttpRequest<UbRes<IList<EmpWorkAuth1>>>(HttpMethod.Get);
      empWorkAuth1List.Resource = UbRestModelAttribute.GetBasePath<EmployeeRestServer>() + "/Employee/{emp_SiteID}/{emp_Code}/EmpWorkAuth1/{work_pm_MenuCode}/{work_pmp_PropCode}";
      empWorkAuth1List.Headers.Add("Send-Type", SendType);
      empWorkAuth1List.SetSegment<UniBizHttpRequest<UbRes<IList<EmpWorkAuth1>>>, long>((Expression<Func<long>>) (() => emp_SiteID));
      empWorkAuth1List.SetSegment<UniBizHttpRequest<UbRes<IList<EmpWorkAuth1>>>, int>((Expression<Func<int>>) (() => emp_Code));
      empWorkAuth1List.SetSegment<UniBizHttpRequest<UbRes<IList<EmpWorkAuth1>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      empWorkAuth1List.SetSegment<UniBizHttpRequest<UbRes<IList<EmpWorkAuth1>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      empWorkAuth1List.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<EmpWorkAuth1>>>>(MethodBase.GetCurrentMethod());
      return empWorkAuth1List;
    }

    public static UniBizHttpRequest<UbRes<IList<EmpWorkAuth1>>> PostEmpWorkAuth1List(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_emp_SiteID")] long emp_SiteID,
      [NameConvert("p_emp_Code")] int emp_Code,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      IList<EmpWorkAuth1> p_list)
    {
      UniBizHttpRequest<UbRes<IList<EmpWorkAuth1>>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<IList<EmpWorkAuth1>>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<EmployeeRestServer>() + "/Employee/{emp_SiteID}/{emp_Code}/EmpWorkAuth1/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<EmpWorkAuth1>>>, long>((Expression<Func<long>>) (() => emp_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<EmpWorkAuth1>>>, int>((Expression<Func<int>>) (() => emp_Code));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<EmpWorkAuth1>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<EmpWorkAuth1>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<IList<EmpWorkAuth1>>(p_list, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<EmpWorkAuth1>>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<EmpWorkAuth1>>> DeleteEmpWorkAuth1List(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_emp_SiteID")] long emp_SiteID,
      [NameConvert("p_emp_Code")] int emp_Code,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      IList<EmpWorkAuth1> p_list)
    {
      UniBizHttpRequest<UbRes<IList<EmpWorkAuth1>>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<IList<EmpWorkAuth1>>>(HttpMethod.Delete);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<EmployeeRestServer>() + "/Employee/{emp_SiteID}/{emp_Code}/EmpWorkAuth1/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<EmpWorkAuth1>>>, long>((Expression<Func<long>>) (() => emp_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<EmpWorkAuth1>>>, int>((Expression<Func<int>>) (() => emp_Code));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<EmpWorkAuth1>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<EmpWorkAuth1>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<IList<EmpWorkAuth1>>(p_list, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<EmpWorkAuth1>>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<EmpWorkAuth2>> GetEmpWorkAuth2(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_emp_SiteID")] long emp_SiteID,
      [NameConvert("p_emp_Code")] int emp_Code,
      [NameConvert("p_emp_TypeNo")] int emp_TypeNo,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<EmpWorkAuth2>> empWorkAuth2 = new UniBizHttpRequest<UbRes<EmpWorkAuth2>>(HttpMethod.Get);
      empWorkAuth2.Resource = UbRestModelAttribute.GetBasePath<EmployeeRestServer>() + "/Employee/{emp_SiteID}/{emp_Code}/EmpWorkAuth2/{emp_TypeNo}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      empWorkAuth2.Headers.Add("Send-Type", SendType);
      empWorkAuth2.SetSegment<UniBizHttpRequest<UbRes<EmpWorkAuth2>>, long>((Expression<Func<long>>) (() => emp_SiteID));
      empWorkAuth2.SetSegment<UniBizHttpRequest<UbRes<EmpWorkAuth2>>, int>((Expression<Func<int>>) (() => emp_Code));
      empWorkAuth2.SetSegment<UniBizHttpRequest<UbRes<EmpWorkAuth2>>, int>((Expression<Func<int>>) (() => emp_TypeNo));
      empWorkAuth2.SetSegment<UniBizHttpRequest<UbRes<EmpWorkAuth2>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      empWorkAuth2.SetSegment<UniBizHttpRequest<UbRes<EmpWorkAuth2>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      empWorkAuth2.ReplaceByNameConverter<UniBizHttpRequest<UbRes<EmpWorkAuth2>>>(MethodBase.GetCurrentMethod());
      return empWorkAuth2;
    }

    public static UniBizHttpRequest<UbRes<EmpWorkAuth2>> PostEmpWorkAuth2(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_emp_SiteID")] long emp_SiteID,
      [NameConvert("p_emp_Code")] int emp_Code,
      [NameConvert("p_emp_TypeNo")] int emp_TypeNo,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      EmpWorkAuth2 pData)
    {
      UniBizHttpRequest<UbRes<EmpWorkAuth2>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<EmpWorkAuth2>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<EmployeeRestServer>() + "/Employee/{emp_SiteID}/{emp_Code}/EmpWorkAuth2/{emp_TypeNo}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpWorkAuth2>>, long>((Expression<Func<long>>) (() => emp_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpWorkAuth2>>, int>((Expression<Func<int>>) (() => emp_Code));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpWorkAuth2>>, int>((Expression<Func<int>>) (() => emp_TypeNo));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpWorkAuth2>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpWorkAuth2>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<EmpWorkAuth2>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<EmpWorkAuth2>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<EmpWorkAuth2>> DeleteEmpWorkAuth2(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_emp_SiteID")] long emp_SiteID,
      [NameConvert("p_emp_Code")] int emp_Code,
      [NameConvert("p_emp_TypeNo")] int emp_TypeNo,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<EmpWorkAuth2>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<EmpWorkAuth2>>(HttpMethod.Delete);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<EmployeeRestServer>() + "/Employee/{emp_SiteID}/{emp_Code}/EmpWorkAuth2/{emp_TypeNo}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpWorkAuth2>>, long>((Expression<Func<long>>) (() => emp_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpWorkAuth2>>, int>((Expression<Func<int>>) (() => emp_Code));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpWorkAuth2>>, int>((Expression<Func<int>>) (() => emp_TypeNo));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpWorkAuth2>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpWorkAuth2>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<EmpWorkAuth2>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<EmpWorkAuth2>>> GetEmpWorkAuth2List(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_emp_SiteID")] long emp_SiteID,
      [NameConvert("p_emp_Code")] int emp_Code,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<IList<EmpWorkAuth2>>> empWorkAuth2List = new UniBizHttpRequest<UbRes<IList<EmpWorkAuth2>>>(HttpMethod.Get);
      empWorkAuth2List.Resource = UbRestModelAttribute.GetBasePath<EmployeeRestServer>() + "/Employee/{emp_SiteID}/{emp_Code}/EmpWorkAuth2/{work_pm_MenuCode}/{work_pmp_PropCode}";
      empWorkAuth2List.Headers.Add("Send-Type", SendType);
      empWorkAuth2List.SetSegment<UniBizHttpRequest<UbRes<IList<EmpWorkAuth2>>>, long>((Expression<Func<long>>) (() => emp_SiteID));
      empWorkAuth2List.SetSegment<UniBizHttpRequest<UbRes<IList<EmpWorkAuth2>>>, int>((Expression<Func<int>>) (() => emp_Code));
      empWorkAuth2List.SetSegment<UniBizHttpRequest<UbRes<IList<EmpWorkAuth2>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      empWorkAuth2List.SetSegment<UniBizHttpRequest<UbRes<IList<EmpWorkAuth2>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      empWorkAuth2List.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<EmpWorkAuth2>>>>(MethodBase.GetCurrentMethod());
      return empWorkAuth2List;
    }

    public static UniBizHttpRequest<UbRes<IList<EmpWorkAuth2>>> PostEmpWorkAuth2List(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_emp_SiteID")] long emp_SiteID,
      [NameConvert("p_emp_Code")] int emp_Code,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      IList<EmpWorkAuth1> p_list)
    {
      UniBizHttpRequest<UbRes<IList<EmpWorkAuth2>>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<IList<EmpWorkAuth2>>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<EmployeeRestServer>() + "/Employee/{emp_SiteID}/{emp_Code}/EmpWorkAuth2/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<EmpWorkAuth2>>>, long>((Expression<Func<long>>) (() => emp_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<EmpWorkAuth2>>>, int>((Expression<Func<int>>) (() => emp_Code));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<EmpWorkAuth2>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<EmpWorkAuth2>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<IList<EmpWorkAuth1>>(p_list, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<EmpWorkAuth2>>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<EmpWorkAuth2>>> DeleteEmpWorkAuth2List(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_emp_SiteID")] long emp_SiteID,
      [NameConvert("p_emp_Code")] int emp_Code,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      IList<EmpWorkAuth1> p_list)
    {
      UniBizHttpRequest<UbRes<IList<EmpWorkAuth2>>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<IList<EmpWorkAuth2>>>(HttpMethod.Delete);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<EmployeeRestServer>() + "/Employee/{emp_SiteID}/{emp_Code}/EmpWorkAuth2/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<EmpWorkAuth2>>>, long>((Expression<Func<long>>) (() => emp_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<EmpWorkAuth2>>>, int>((Expression<Func<int>>) (() => emp_Code));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<EmpWorkAuth2>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<EmpWorkAuth2>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<IList<EmpWorkAuth1>>(p_list, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<EmpWorkAuth2>>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<EmpWorkAuth3>> GetEmpWorkAuth3(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_emp_SiteID")] long emp_SiteID,
      [NameConvert("p_emp_Code")] int emp_Code,
      [NameConvert("p_emp_TypeNo")] int emp_TypeNo,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<EmpWorkAuth3>> empWorkAuth3 = new UniBizHttpRequest<UbRes<EmpWorkAuth3>>(HttpMethod.Get);
      empWorkAuth3.Resource = UbRestModelAttribute.GetBasePath<EmployeeRestServer>() + "/Employee/{emp_SiteID}/{emp_Code}/EmpWorkAuth3/{emp_TypeNo}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      empWorkAuth3.Headers.Add("Send-Type", SendType);
      empWorkAuth3.SetSegment<UniBizHttpRequest<UbRes<EmpWorkAuth3>>, long>((Expression<Func<long>>) (() => emp_SiteID));
      empWorkAuth3.SetSegment<UniBizHttpRequest<UbRes<EmpWorkAuth3>>, int>((Expression<Func<int>>) (() => emp_Code));
      empWorkAuth3.SetSegment<UniBizHttpRequest<UbRes<EmpWorkAuth3>>, int>((Expression<Func<int>>) (() => emp_TypeNo));
      empWorkAuth3.SetSegment<UniBizHttpRequest<UbRes<EmpWorkAuth3>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      empWorkAuth3.SetSegment<UniBizHttpRequest<UbRes<EmpWorkAuth3>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      empWorkAuth3.ReplaceByNameConverter<UniBizHttpRequest<UbRes<EmpWorkAuth3>>>(MethodBase.GetCurrentMethod());
      return empWorkAuth3;
    }

    public static UniBizHttpRequest<UbRes<EmpWorkAuth3>> PostEmpWorkAuth3(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_emp_SiteID")] long emp_SiteID,
      [NameConvert("p_emp_Code")] int emp_Code,
      [NameConvert("p_emp_TypeNo")] int emp_TypeNo,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      EmpWorkAuth3 pData)
    {
      UniBizHttpRequest<UbRes<EmpWorkAuth3>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<EmpWorkAuth3>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<EmployeeRestServer>() + "/Employee/{emp_SiteID}/{emp_Code}/EmpWorkAuth3/{emp_TypeNo}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpWorkAuth3>>, long>((Expression<Func<long>>) (() => emp_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpWorkAuth3>>, int>((Expression<Func<int>>) (() => emp_Code));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpWorkAuth3>>, int>((Expression<Func<int>>) (() => emp_TypeNo));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpWorkAuth3>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpWorkAuth3>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<EmpWorkAuth3>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<EmpWorkAuth3>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<EmpWorkAuth3>> DeleteEmpWorkAuth3(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_emp_SiteID")] long emp_SiteID,
      [NameConvert("p_emp_Code")] int emp_Code,
      [NameConvert("p_emp_TypeNo")] int emp_TypeNo,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<EmpWorkAuth3>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<EmpWorkAuth3>>(HttpMethod.Delete);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<EmployeeRestServer>() + "/Employee/{emp_SiteID}/{emp_Code}/EmpWorkAuth3/{emp_TypeNo}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpWorkAuth3>>, long>((Expression<Func<long>>) (() => emp_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpWorkAuth3>>, int>((Expression<Func<int>>) (() => emp_Code));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpWorkAuth3>>, int>((Expression<Func<int>>) (() => emp_TypeNo));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpWorkAuth3>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<EmpWorkAuth3>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<EmpWorkAuth3>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<EmpWorkAuth3>>> GetEmpWorkAuth3List(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_emp_SiteID")] long emp_SiteID,
      [NameConvert("p_emp_Code")] int emp_Code,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<IList<EmpWorkAuth3>>> empWorkAuth3List = new UniBizHttpRequest<UbRes<IList<EmpWorkAuth3>>>(HttpMethod.Get);
      empWorkAuth3List.Resource = UbRestModelAttribute.GetBasePath<EmployeeRestServer>() + "/Employee/{emp_SiteID}/{emp_Code}/EmpWorkAuth3/{work_pm_MenuCode}/{work_pmp_PropCode}";
      empWorkAuth3List.Headers.Add("Send-Type", SendType);
      empWorkAuth3List.SetSegment<UniBizHttpRequest<UbRes<IList<EmpWorkAuth3>>>, long>((Expression<Func<long>>) (() => emp_SiteID));
      empWorkAuth3List.SetSegment<UniBizHttpRequest<UbRes<IList<EmpWorkAuth3>>>, int>((Expression<Func<int>>) (() => emp_Code));
      empWorkAuth3List.SetSegment<UniBizHttpRequest<UbRes<IList<EmpWorkAuth3>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      empWorkAuth3List.SetSegment<UniBizHttpRequest<UbRes<IList<EmpWorkAuth3>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      empWorkAuth3List.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<EmpWorkAuth3>>>>(MethodBase.GetCurrentMethod());
      return empWorkAuth3List;
    }

    public static UniBizHttpRequest<UbRes<IList<EmpWorkAuth3>>> PostEmpWorkAuth3List(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_emp_SiteID")] long emp_SiteID,
      [NameConvert("p_emp_Code")] int emp_Code,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      IList<EmpWorkAuth1> p_list)
    {
      UniBizHttpRequest<UbRes<IList<EmpWorkAuth3>>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<IList<EmpWorkAuth3>>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<EmployeeRestServer>() + "/Employee/{emp_SiteID}/{emp_Code}/EmpWorkAuth3/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<EmpWorkAuth3>>>, long>((Expression<Func<long>>) (() => emp_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<EmpWorkAuth3>>>, int>((Expression<Func<int>>) (() => emp_Code));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<EmpWorkAuth3>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<EmpWorkAuth3>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<IList<EmpWorkAuth1>>(p_list, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<EmpWorkAuth3>>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<EmpWorkAuth3>>> DeleteEmpWorkAuth3List(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_emp_SiteID")] long emp_SiteID,
      [NameConvert("p_emp_Code")] int emp_Code,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      IList<EmpWorkAuth1> p_list)
    {
      UniBizHttpRequest<UbRes<IList<EmpWorkAuth3>>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<IList<EmpWorkAuth3>>>(HttpMethod.Delete);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<EmployeeRestServer>() + "/Employee/{emp_SiteID}/{emp_Code}/EmpWorkAuth3/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<EmpWorkAuth3>>>, long>((Expression<Func<long>>) (() => emp_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<EmpWorkAuth3>>>, int>((Expression<Func<int>>) (() => emp_Code));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<EmpWorkAuth3>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<EmpWorkAuth3>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<IList<EmpWorkAuth1>>(p_list, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<EmpWorkAuth3>>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<JobEvtEodReWork>> PostWebSocketTest(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("_JobID_")] string JobId,
      [NameConvert("p_emp_SiteID")] long emp_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<JobEvtEodReWork>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<JobEvtEodReWork>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<EmployeeRestServer>() + "/Employee/{emp_SiteID}/Socket/Test/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.Headers.Add("_JobID_", JobId);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<JobEvtEodReWork>>, long>((Expression<Func<long>>) (() => emp_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<JobEvtEodReWork>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<JobEvtEodReWork>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<JobEvtEodReWork>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<bool>> DeleteWebSocketTest(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_emp_SiteID")] long emp_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      string p_JobID)
    {
      UniBizHttpRequest<UbRes<bool>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<bool>>(HttpMethod.Delete);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<EmployeeRestServer>() + "/Employee/{emp_SiteID}/Socket/Test/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<bool>>, long>((Expression<Func<long>>) (() => emp_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<bool>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<bool>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<string>(p_JobID, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<bool>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }
  }
}
