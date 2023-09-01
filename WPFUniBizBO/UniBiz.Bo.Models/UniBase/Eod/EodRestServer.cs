// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Eod.EodRestServer
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http;
using System.Reflection;
using UniBiz.Bo.Models.JobEvtMessage;
using UniBiz.Bo.Models.UbRest;
using UniBiz.Bo.Models.UniBase.Eod.EodDbBackup;
using UniBiz.Bo.Models.UniBase.Eod.EodInfo;
using UniinfoNet;
using UniinfoNet.Http.UniBiz;

namespace UniBiz.Bo.Models.UniBase.Eod
{
  [UbRestModel("/Sys", TableCodeType.Unknown, HeaderPath = "")]
  public class EodRestServer : BindableBase
  {
    public static UniBizHttpRequest<UbRes<EodInfoView>> GetEodInfo(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_eod_SiteID")] long eod_SiteID,
      [NameConvert("p_eod_ID")] int eod_ID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<EodInfoView>> eodInfo = new UniBizHttpRequest<UbRes<EodInfoView>>(HttpMethod.Get);
      eodInfo.Resource = UbRestModelAttribute.GetBasePath<EodRestServer>() + "/EodInfo/{eod_SiteID}/{eod_ID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      eodInfo.Headers.Add("Send-Type", SendType);
      eodInfo.SetSegment<UniBizHttpRequest<UbRes<EodInfoView>>, long>((Expression<Func<long>>) (() => eod_SiteID));
      eodInfo.SetSegment<UniBizHttpRequest<UbRes<EodInfoView>>, int>((Expression<Func<int>>) (() => eod_ID));
      eodInfo.SetSegment<UniBizHttpRequest<UbRes<EodInfoView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      eodInfo.SetSegment<UniBizHttpRequest<UbRes<EodInfoView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      eodInfo.ReplaceByNameConverter<UniBizHttpRequest<UbRes<EodInfoView>>>(MethodBase.GetCurrentMethod());
      return eodInfo;
    }

    public static UniBizHttpRequest<UbRes<IList<EodInfoView>>> GetEodInfoList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_eod_SiteID")] long eod_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_eod_ID")] int eod_ID = 0,
      [NameConvert("p_dt_date")] long dt_date = 0,
      [NameConvert("p_dt_Start")] long dt_Start = 0,
      [NameConvert("p_dt_End")] long dt_End = 0,
      [NameConvert("p_eod_Type")] int eod_Type = 0,
      [NameConvert("p_eod_Status")] int eod_Status = 0,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<EodInfoView>>> eodInfoList = new UniBizHttpRequest<UbRes<IList<EodInfoView>>>(HttpMethod.Get);
      eodInfoList.Resource = UbRestModelAttribute.GetBasePath<EodRestServer>() + "/EodInfo/{eod_SiteID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      eodInfoList.Headers.Add("Send-Type", SendType);
      eodInfoList.SetSegment<UniBizHttpRequest<UbRes<IList<EodInfoView>>>, long>((Expression<Func<long>>) (() => eod_SiteID));
      eodInfoList.SetSegment<UniBizHttpRequest<UbRes<IList<EodInfoView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      eodInfoList.SetSegment<UniBizHttpRequest<UbRes<IList<EodInfoView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (eod_ID > 0)
        eodInfoList.SetQuery<UniBizHttpRequest<UbRes<IList<EodInfoView>>>, int>((Expression<Func<int>>) (() => eod_ID));
      if (dt_date > 0L)
        eodInfoList.SetQuery<UniBizHttpRequest<UbRes<IList<EodInfoView>>>, long>((Expression<Func<long>>) (() => dt_date));
      if (dt_Start > 0L)
        eodInfoList.SetQuery<UniBizHttpRequest<UbRes<IList<EodInfoView>>>, long>((Expression<Func<long>>) (() => dt_Start));
      if (dt_End > 0L)
        eodInfoList.SetQuery<UniBizHttpRequest<UbRes<IList<EodInfoView>>>, long>((Expression<Func<long>>) (() => dt_End));
      if (eod_Type > 0)
        eodInfoList.SetQuery<UniBizHttpRequest<UbRes<IList<EodInfoView>>>, int>((Expression<Func<int>>) (() => eod_Type));
      if (eod_Status > 0)
        eodInfoList.SetQuery<UniBizHttpRequest<UbRes<IList<EodInfoView>>>, int>((Expression<Func<int>>) (() => eod_Status));
      if (!string.IsNullOrEmpty(KeyWord))
        eodInfoList.SetQuery<UniBizHttpRequest<UbRes<IList<EodInfoView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      eodInfoList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<EodInfoView>>>>(MethodBase.GetCurrentMethod());
      return eodInfoList;
    }

    public static UniBizHttpRequest<UbRes<JobEvtEodReWork>> PutEodInfo(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_eod_SiteID")] long eod_SiteID,
      [NameConvert("p_eod_ID")] int eod_ID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<JobEvtEodReWork>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<JobEvtEodReWork>>(HttpMethod.Put);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<EodRestServer>() + "/EodInfo/{eod_SiteID}/{eod_ID}/ReWork/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<JobEvtEodReWork>>, long>((Expression<Func<long>>) (() => eod_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<JobEvtEodReWork>>, int>((Expression<Func<int>>) (() => eod_ID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<JobEvtEodReWork>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<JobEvtEodReWork>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<JobEvtEodReWork>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<bool>> DeleteEodInfo(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_eod_SiteID")] long eod_SiteID,
      [NameConvert("p_eod_ID")] int eod_ID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<bool>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<bool>>(HttpMethod.Delete);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<EodRestServer>() + "/EodInfo/{eod_SiteID}/{eod_ID}/ReWork/WorkStop/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<bool>>, long>((Expression<Func<long>>) (() => eod_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<bool>>, int>((Expression<Func<int>>) (() => eod_ID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<bool>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<bool>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<bool>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<EodDbBackupView>> GetEodDbBackup(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_eodb_SiteID")] long eodb_SiteID,
      [NameConvert("p_eodb_code")] int eodb_code,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<EodDbBackupView>> eodDbBackup = new UniBizHttpRequest<UbRes<EodDbBackupView>>(HttpMethod.Get);
      eodDbBackup.Resource = UbRestModelAttribute.GetBasePath<EodRestServer>() + "/EodDbBackup/{eodb_SiteID}/{eodb_code}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      eodDbBackup.Headers.Add("Send-Type", SendType);
      eodDbBackup.SetSegment<UniBizHttpRequest<UbRes<EodDbBackupView>>, long>((Expression<Func<long>>) (() => eodb_SiteID));
      eodDbBackup.SetSegment<UniBizHttpRequest<UbRes<EodDbBackupView>>, int>((Expression<Func<int>>) (() => eodb_code));
      eodDbBackup.SetSegment<UniBizHttpRequest<UbRes<EodDbBackupView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      eodDbBackup.SetSegment<UniBizHttpRequest<UbRes<EodDbBackupView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      eodDbBackup.ReplaceByNameConverter<UniBizHttpRequest<UbRes<EodDbBackupView>>>(MethodBase.GetCurrentMethod());
      return eodDbBackup;
    }

    public static UniBizHttpRequest<UbRes<IList<EodDbBackupView>>> GetEodDbBackupList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_eodb_SiteID")] long eodb_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_eodb_code")] int eodb_code = 0,
      [NameConvert("p_dt_date")] long dt_date = 0,
      [NameConvert("p_dt_Start")] long dt_Start = 0,
      [NameConvert("p_dt_End")] long dt_End = 0,
      [NameConvert("p_eodb_db_name_type")] int eodb_db_name_type = 0,
      [NameConvert("p_eodb_status")] int eodb_status = 0,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<EodDbBackupView>>> eodDbBackupList = new UniBizHttpRequest<UbRes<IList<EodDbBackupView>>>(HttpMethod.Get);
      eodDbBackupList.Resource = UbRestModelAttribute.GetBasePath<EodRestServer>() + "/EodDbBackup/{eodb_SiteID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      eodDbBackupList.Headers.Add("Send-Type", SendType);
      eodDbBackupList.SetSegment<UniBizHttpRequest<UbRes<IList<EodDbBackupView>>>, long>((Expression<Func<long>>) (() => eodb_SiteID));
      eodDbBackupList.SetSegment<UniBizHttpRequest<UbRes<IList<EodDbBackupView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      eodDbBackupList.SetSegment<UniBizHttpRequest<UbRes<IList<EodDbBackupView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (eodb_code > 0)
        eodDbBackupList.SetQuery<UniBizHttpRequest<UbRes<IList<EodDbBackupView>>>, int>((Expression<Func<int>>) (() => eodb_code));
      if (dt_date > 0L)
        eodDbBackupList.SetQuery<UniBizHttpRequest<UbRes<IList<EodDbBackupView>>>, long>((Expression<Func<long>>) (() => dt_date));
      if (dt_Start > 0L)
        eodDbBackupList.SetQuery<UniBizHttpRequest<UbRes<IList<EodDbBackupView>>>, long>((Expression<Func<long>>) (() => dt_Start));
      if (dt_End > 0L)
        eodDbBackupList.SetQuery<UniBizHttpRequest<UbRes<IList<EodDbBackupView>>>, long>((Expression<Func<long>>) (() => dt_End));
      if (eodb_db_name_type > 0)
        eodDbBackupList.SetQuery<UniBizHttpRequest<UbRes<IList<EodDbBackupView>>>, int>((Expression<Func<int>>) (() => eodb_db_name_type));
      if (eodb_status > 0)
        eodDbBackupList.SetQuery<UniBizHttpRequest<UbRes<IList<EodDbBackupView>>>, int>((Expression<Func<int>>) (() => eodb_status));
      if (!string.IsNullOrEmpty(KeyWord))
        eodDbBackupList.SetQuery<UniBizHttpRequest<UbRes<IList<EodDbBackupView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      eodDbBackupList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<EodDbBackupView>>>>(MethodBase.GetCurrentMethod());
      return eodDbBackupList;
    }

    public static UniBizHttpRequest GetEodDbBackupFile(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_eodb_SiteID")] long eodb_SiteID,
      [NameConvert("p_eodb_code")] int eodb_code,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest eodDbBackupFile = new UniBizHttpRequest(HttpMethod.Get);
      eodDbBackupFile.Resource = UbRestModelAttribute.GetBasePath<EodRestServer>() + "/EodDbBackup/{eodb_SiteID}/{eodb_code}/File/{work_pm_MenuCode}/{work_pmp_PropCode}";
      eodDbBackupFile.Headers.Add("Send-Type", SendType);
      eodDbBackupFile.SetSegment<UniBizHttpRequest, long>((Expression<Func<long>>) (() => eodb_SiteID));
      eodDbBackupFile.SetSegment<UniBizHttpRequest, long>((Expression<Func<long>>) (() => eodb_SiteID));
      eodDbBackupFile.SetSegment<UniBizHttpRequest, int>((Expression<Func<int>>) (() => eodb_code));
      eodDbBackupFile.SetSegment<UniBizHttpRequest, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      eodDbBackupFile.SetSegment<UniBizHttpRequest, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      eodDbBackupFile.ReplaceByNameConverter<UniBizHttpRequest>(MethodBase.GetCurrentMethod());
      return eodDbBackupFile;
    }
  }
}
