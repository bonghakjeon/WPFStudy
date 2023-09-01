// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.RestServer.StatementRestServer
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection;
using UniBiz.Bo.Models.JobEvtMessage;
using UniBiz.Bo.Models.UbRest;
using UniBiz.Bo.Models.UniStock.Statement.Date;
using UniBiz.Bo.Models.UniStock.Statement.Day.Horizontal;
using UniBiz.Bo.Models.UniStock.Statement.Day.Horizontal.Supplier;
using UniBiz.Bo.Models.UniStock.Statement.Day.Vertical;
using UniBiz.Bo.Models.UniStock.Statement.Month.Horizontal;
using UniBiz.Bo.Models.UniStock.Statement.Month.Horizontal.Supplier;
using UniBiz.Bo.Models.UniStock.Statement.Month.Vertical;
using UniBiz.Bo.Models.UniStock.Statement.Supplier;
using UniinfoNet.Http.UniBiz;

namespace UniBiz.Bo.Models.UniStock.Statement.RestServer
{
  [UbRestModel("/Statement", TableCodeType.StatementHeader, HeaderPath = "")]
  public class StatementRestServer
  {
    public static UniBizHttpRequest<UbRes<StatementHeaderView>> GetStatement(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sh_SiteID")] long sh_SiteID,
      [NameConvert("p_sh_StatementNo")] long sh_StatementNo,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_isStatementDetails")] bool isStatementDetails = true)
    {
      UniBizHttpRequest<UbRes<StatementHeaderView>> statement = new UniBizHttpRequest<UbRes<StatementHeaderView>>(HttpMethod.Get);
      statement.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sh_SiteID}/{sh_StatementNo}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      statement.Headers.Add("Send-Type", SendType);
      statement.SetSegment<UniBizHttpRequest<UbRes<StatementHeaderView>>, long>((Expression<Func<long>>) (() => sh_SiteID));
      statement.SetSegment<UniBizHttpRequest<UbRes<StatementHeaderView>>, long>((Expression<Func<long>>) (() => sh_StatementNo));
      statement.SetSegment<UniBizHttpRequest<UbRes<StatementHeaderView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      statement.SetSegment<UniBizHttpRequest<UbRes<StatementHeaderView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      statement.SetQuery<UniBizHttpRequest<UbRes<StatementHeaderView>>, bool>((Expression<Func<bool>>) (() => isStatementDetails));
      statement.ReplaceByNameConverter<UniBizHttpRequest<UbRes<StatementHeaderView>>>(MethodBase.GetCurrentMethod());
      return statement;
    }

    public static UniBizHttpRequest<UbRes<StatementHeaderView>> PostStatement(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sh_SiteID")] long sh_SiteID,
      [NameConvert("p_sh_StatementNo")] long sh_StatementNo,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      StatementHeaderView pData)
    {
      UniBizHttpRequest<UbRes<StatementHeaderView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<StatementHeaderView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sh_SiteID}/{sh_StatementNo}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<StatementHeaderView>>, long>((Expression<Func<long>>) (() => sh_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<StatementHeaderView>>, long>((Expression<Func<long>>) (() => sh_StatementNo));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<StatementHeaderView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<StatementHeaderView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<StatementHeaderView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<StatementHeaderView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<StatementHeaderView>>> GetStatementList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sh_SiteID")] long sh_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_sh_StatementNo")] long sh_StatementNo = 0,
      [NameConvert("p_sh_ConfirmDate")] long sh_ConfirmDate = 0,
      [NameConvert("p_sh_ConfirmDateBegin")] long sh_ConfirmDateBegin = 0,
      [NameConvert("p_sh_ConfirmDateEnd")] long sh_ConfirmDateEnd = 0,
      [NameConvert("p_sh_OrderDate")] long sh_OrderDate = 0,
      [NameConvert("p_sh_OrderDateBegin")] long sh_OrderDateBegin = 0,
      [NameConvert("p_sh_OrderDateEnd")] long sh_OrderDateEnd = 0,
      [NameConvert("p_sh_InOutDiv")] int sh_InOutDiv = 0,
      [NameConvert("p_sh_ConfirmStatus")] int sh_ConfirmStatus = 0,
      [NameConvert("p_sh_StatementType")] int sh_StatementType = 0,
      [NameConvert("p_sh_StatementTypeIn")] string sh_StatementTypeIn = null,
      [NameConvert("p_sh_DeviceType")] int sh_DeviceType = 0,
      [NameConvert("p_sh_AssignUser")] int sh_AssignUser = 0,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_emp_Code")] int emp_Code = 0,
      [NameConvert("p_isStatementDetails")] bool isStatementDetails = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<StatementHeaderView>>> statementList = new UniBizHttpRequest<UbRes<IList<StatementHeaderView>>>(HttpMethod.Get);
      statementList.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sh_SiteID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      statementList.Headers.Add("Send-Type", SendType);
      statementList.SetSegment<UniBizHttpRequest<UbRes<IList<StatementHeaderView>>>, long>((Expression<Func<long>>) (() => sh_SiteID));
      statementList.SetSegment<UniBizHttpRequest<UbRes<IList<StatementHeaderView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      statementList.SetSegment<UniBizHttpRequest<UbRes<IList<StatementHeaderView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (sh_StatementNo > 0L)
        statementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementHeaderView>>>, long>((Expression<Func<long>>) (() => sh_StatementNo));
      if (sh_ConfirmDate > 0L)
        statementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementHeaderView>>>, long>((Expression<Func<long>>) (() => sh_ConfirmDate));
      if (sh_ConfirmDateBegin > 0L)
        statementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementHeaderView>>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateBegin));
      if (sh_ConfirmDateEnd > 0L)
        statementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementHeaderView>>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateEnd));
      if (sh_OrderDate > 0L)
        statementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementHeaderView>>>, long>((Expression<Func<long>>) (() => sh_OrderDate));
      if (sh_OrderDateBegin > 0L)
        statementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementHeaderView>>>, long>((Expression<Func<long>>) (() => sh_OrderDateBegin));
      if (sh_OrderDateEnd > 0L)
        statementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementHeaderView>>>, long>((Expression<Func<long>>) (() => sh_OrderDateEnd));
      if (sh_InOutDiv > 0)
        statementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementHeaderView>>>, int>((Expression<Func<int>>) (() => sh_InOutDiv));
      if (sh_ConfirmStatus > 0)
        statementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementHeaderView>>>, int>((Expression<Func<int>>) (() => sh_ConfirmStatus));
      if (sh_StatementType > 0)
        statementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementHeaderView>>>, int>((Expression<Func<int>>) (() => sh_StatementType));
      if (!string.IsNullOrEmpty(sh_StatementTypeIn))
        statementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementHeaderView>>>, string>((Expression<Func<string>>) (() => sh_StatementTypeIn));
      if (sh_DeviceType > 0)
        statementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementHeaderView>>>, int>((Expression<Func<int>>) (() => sh_DeviceType));
      if (sh_AssignUser > 0)
        statementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementHeaderView>>>, int>((Expression<Func<int>>) (() => sh_AssignUser));
      if (si_StoreCode > 0)
        statementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementHeaderView>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
        statementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementHeaderView>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
      if (su_Supplier > 0)
        statementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementHeaderView>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        statementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementHeaderView>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        statementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementHeaderView>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        statementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementHeaderView>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (emp_Code > 0)
        statementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementHeaderView>>>, int>((Expression<Func<int>>) (() => emp_Code));
      statementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementHeaderView>>>, bool>((Expression<Func<bool>>) (() => isStatementDetails));
      if (!string.IsNullOrEmpty(KeyWord))
        statementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementHeaderView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      statementList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<StatementHeaderView>>>>(MethodBase.GetCurrentMethod());
      return statementList;
    }

    public static UniBizHttpRequest<UbRes<JobEvtStatementHeader>> PostStatementList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sh_SiteID")] long sh_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      JobEvtStatementHeader pData)
    {
      UniBizHttpRequest<UbRes<JobEvtStatementHeader>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<JobEvtStatementHeader>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sh_SiteID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<JobEvtStatementHeader>>, long>((Expression<Func<long>>) (() => sh_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<JobEvtStatementHeader>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<JobEvtStatementHeader>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<JobEvtStatementHeader>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<JobEvtStatementHeader>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<bool>> DeleteStatementList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sh_SiteID")] long sh_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      string p_JobID)
    {
      UniBizHttpRequest<UbRes<bool>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<bool>>(HttpMethod.Delete);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sh_SiteID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<bool>>, long>((Expression<Func<long>>) (() => sh_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<bool>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<bool>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<string>(p_JobID, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<bool>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<JobEvtStatementHeader>> PutStatementStatusList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sh_SiteID")] long sh_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      JobEvtStatementHeader pData)
    {
      UniBizHttpRequest<UbRes<JobEvtStatementHeader>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<JobEvtStatementHeader>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sh_SiteID}/Status/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<JobEvtStatementHeader>>, long>((Expression<Func<long>>) (() => sh_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<JobEvtStatementHeader>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<JobEvtStatementHeader>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<JobEvtStatementHeader>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<JobEvtStatementHeader>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<bool>> DeleteStatementStatusList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sh_SiteID")] long sh_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      string p_JobID)
    {
      UniBizHttpRequest<UbRes<bool>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<bool>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sh_SiteID}/Status/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<bool>>, long>((Expression<Func<long>>) (() => sh_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<bool>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<bool>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<string>(p_JobID, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<bool>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<StatementDetailView>> GetStatementDetailsBarcode(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sh_SiteID")] long sh_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_sh_StoreCode")] int sh_StoreCode,
      [NameConvert("p_sh_Supplier")] int sh_Supplier,
      [NameConvert("p_sh_ConfirmDate")] long sh_ConfirmDate,
      [NameConvert("p_sd_BarCode")] string sd_BarCode,
      [NameConvert("p_isHistoryList")] bool isHistoryList = false)
    {
      if (string.IsNullOrEmpty(sd_BarCode))
        return (UniBizHttpRequest<UbRes<StatementDetailView>>) null;
      UniBizHttpRequest<UbRes<StatementDetailView>> statementDetailsBarcode = new UniBizHttpRequest<UbRes<StatementDetailView>>(HttpMethod.Get);
      statementDetailsBarcode.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sh_SiteID}/Details/Barcode/{work_pm_MenuCode}/{work_pmp_PropCode}";
      statementDetailsBarcode.Headers.Add("Send-Type", SendType);
      statementDetailsBarcode.SetSegment<UniBizHttpRequest<UbRes<StatementDetailView>>, long>((Expression<Func<long>>) (() => sh_SiteID));
      statementDetailsBarcode.SetSegment<UniBizHttpRequest<UbRes<StatementDetailView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      statementDetailsBarcode.SetSegment<UniBizHttpRequest<UbRes<StatementDetailView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      statementDetailsBarcode.SetQuery<UniBizHttpRequest<UbRes<StatementDetailView>>, int>((Expression<Func<int>>) (() => sh_StoreCode));
      statementDetailsBarcode.SetQuery<UniBizHttpRequest<UbRes<StatementDetailView>>, int>((Expression<Func<int>>) (() => sh_Supplier));
      statementDetailsBarcode.SetQuery<UniBizHttpRequest<UbRes<StatementDetailView>>, long>((Expression<Func<long>>) (() => sh_ConfirmDate));
      statementDetailsBarcode.SetQuery<UniBizHttpRequest<UbRes<StatementDetailView>>, string>((Expression<Func<string>>) (() => sd_BarCode));
      statementDetailsBarcode.SetQuery<UniBizHttpRequest<UbRes<StatementDetailView>>, bool>((Expression<Func<bool>>) (() => isHistoryList));
      statementDetailsBarcode.ReplaceByNameConverter<UniBizHttpRequest<UbRes<StatementDetailView>>>(MethodBase.GetCurrentMethod());
      return statementDetailsBarcode;
    }

    public static UniBizHttpRequest<UbRes<IList<StatementDetailView>>> PutStatementDetailsBarcodeList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sh_SiteID")] long sh_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      StatementDetailBarcodeSearchPack pPack)
    {
      UniBizHttpRequest<UbRes<IList<StatementDetailView>>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<IList<StatementDetailView>>>(HttpMethod.Put);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sh_SiteID}/Details/Barcode/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<StatementDetailView>>>, long>((Expression<Func<long>>) (() => sh_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<StatementDetailView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<StatementDetailView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<StatementDetailBarcodeSearchPack>(pPack, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<StatementDetailView>>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<StatementDateStore>>> GetStatementDateStoreList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sd_SiteID")] long sd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sh_ConfirmDate")] long sh_ConfirmDate = 0,
      [NameConvert("p_sh_ConfirmDateBegin")] long sh_ConfirmDateBegin = 0,
      [NameConvert("p_sh_ConfirmDateEnd")] long sh_ConfirmDateEnd = 0,
      [NameConvert("p_sh_ConfirmStatus")] int sh_ConfirmStatus = 0,
      [NameConvert("p_sh_StatementType")] int sh_StatementType = 0,
      [NameConvert("p_sh_StatementTypeIn")] string sh_StatementTypeIn = null,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<StatementDateStore>>> statementDateStoreList = new UniBizHttpRequest<UbRes<IList<StatementDateStore>>>(HttpMethod.Get);
      statementDateStoreList.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sd_SiteID}/Date/Store/{work_pm_MenuCode}/{work_pmp_PropCode}";
      statementDateStoreList.Headers.Add("Send-Type", SendType);
      statementDateStoreList.SetSegment<UniBizHttpRequest<UbRes<IList<StatementDateStore>>>, long>((Expression<Func<long>>) (() => sd_SiteID));
      statementDateStoreList.SetSegment<UniBizHttpRequest<UbRes<IList<StatementDateStore>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      statementDateStoreList.SetSegment<UniBizHttpRequest<UbRes<IList<StatementDateStore>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      statementDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateStore>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sh_ConfirmDate > 0L)
        statementDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateStore>>>, long>((Expression<Func<long>>) (() => sh_ConfirmDate));
      if (sh_ConfirmDateBegin > 0L)
        statementDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateStore>>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateBegin));
      if (sh_ConfirmDateEnd > 0L)
        statementDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateStore>>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateEnd));
      if (sh_ConfirmStatus > 0)
        statementDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateStore>>>, int>((Expression<Func<int>>) (() => sh_ConfirmStatus));
      if (sh_StatementType > 0)
        statementDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateStore>>>, int>((Expression<Func<int>>) (() => sh_StatementType));
      if (!string.IsNullOrEmpty(sh_StatementTypeIn))
        statementDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateStore>>>, string>((Expression<Func<string>>) (() => sh_StatementTypeIn));
      if (si_StoreCode > 0)
        statementDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateStore>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        statementDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateStore>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        statementDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateStore>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        statementDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateStore>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        statementDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateStore>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        statementDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateStore>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        statementDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateStore>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        statementDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateStore>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        statementDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateStore>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        statementDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateStore>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        statementDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateStore>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        statementDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateStore>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        statementDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateStore>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        statementDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateStore>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        statementDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateStore>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        statementDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateStore>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        statementDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateStore>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        statementDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateStore>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        statementDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateStore>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        statementDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateStore>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        statementDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateStore>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        statementDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateStore>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        statementDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateStore>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        statementDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateStore>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        statementDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateStore>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      statementDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateStore>>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        statementDateStoreList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateStore>>>, string>((Expression<Func<string>>) (() => KeyWord));
      statementDateStoreList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<StatementDateStore>>>>(MethodBase.GetCurrentMethod());
      return statementDateStoreList;
    }

    public static UniBizHttpRequest<UbRes<IList<StatementDateTeam>>> GetStatementDateTeamList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sd_SiteID")] long sd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sh_ConfirmDate")] long sh_ConfirmDate = 0,
      [NameConvert("p_sh_ConfirmDateBegin")] long sh_ConfirmDateBegin = 0,
      [NameConvert("p_sh_ConfirmDateEnd")] long sh_ConfirmDateEnd = 0,
      [NameConvert("p_sh_ConfirmStatus")] int sh_ConfirmStatus = 0,
      [NameConvert("p_sh_StatementType")] int sh_StatementType = 0,
      [NameConvert("p_sh_StatementTypeIn")] string sh_StatementTypeIn = null,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<StatementDateTeam>>> statementDateTeamList = new UniBizHttpRequest<UbRes<IList<StatementDateTeam>>>(HttpMethod.Get);
      statementDateTeamList.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sd_SiteID}/Date/Team/{work_pm_MenuCode}/{work_pmp_PropCode}";
      statementDateTeamList.Headers.Add("Send-Type", SendType);
      statementDateTeamList.SetSegment<UniBizHttpRequest<UbRes<IList<StatementDateTeam>>>, long>((Expression<Func<long>>) (() => sd_SiteID));
      statementDateTeamList.SetSegment<UniBizHttpRequest<UbRes<IList<StatementDateTeam>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      statementDateTeamList.SetSegment<UniBizHttpRequest<UbRes<IList<StatementDateTeam>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      statementDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateTeam>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sh_ConfirmDate > 0L)
        statementDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateTeam>>>, long>((Expression<Func<long>>) (() => sh_ConfirmDate));
      if (sh_ConfirmDateBegin > 0L)
        statementDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateTeam>>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateBegin));
      if (sh_ConfirmDateEnd > 0L)
        statementDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateTeam>>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateEnd));
      if (sh_ConfirmStatus > 0)
        statementDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateTeam>>>, int>((Expression<Func<int>>) (() => sh_ConfirmStatus));
      if (sh_StatementType > 0)
        statementDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateTeam>>>, int>((Expression<Func<int>>) (() => sh_StatementType));
      if (!string.IsNullOrEmpty(sh_StatementTypeIn))
        statementDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateTeam>>>, string>((Expression<Func<string>>) (() => sh_StatementTypeIn));
      if (si_StoreCode > 0)
        statementDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateTeam>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        statementDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateTeam>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        statementDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateTeam>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        statementDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateTeam>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        statementDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateTeam>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        statementDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateTeam>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        statementDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateTeam>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        statementDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateTeam>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        statementDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateTeam>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        statementDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateTeam>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        statementDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateTeam>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        statementDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateTeam>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        statementDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateTeam>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        statementDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateTeam>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        statementDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateTeam>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        statementDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateTeam>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        statementDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateTeam>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        statementDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateTeam>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        statementDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateTeam>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        statementDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateTeam>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        statementDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateTeam>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        statementDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateTeam>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        statementDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateTeam>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        statementDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateTeam>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        statementDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateTeam>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      statementDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateTeam>>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        statementDateTeamList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateTeam>>>, string>((Expression<Func<string>>) (() => KeyWord));
      statementDateTeamList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<StatementDateTeam>>>>(MethodBase.GetCurrentMethod());
      return statementDateTeamList;
    }

    public static UniBizHttpRequest<UbRes<IList<StatementDateDept>>> GetStatementDateDeptList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sd_SiteID")] long sd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sh_ConfirmDate")] long sh_ConfirmDate = 0,
      [NameConvert("p_sh_ConfirmDateBegin")] long sh_ConfirmDateBegin = 0,
      [NameConvert("p_sh_ConfirmDateEnd")] long sh_ConfirmDateEnd = 0,
      [NameConvert("p_sh_ConfirmStatus")] int sh_ConfirmStatus = 0,
      [NameConvert("p_sh_StatementType")] int sh_StatementType = 0,
      [NameConvert("p_sh_StatementTypeIn")] string sh_StatementTypeIn = null,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<StatementDateDept>>> statementDateDeptList = new UniBizHttpRequest<UbRes<IList<StatementDateDept>>>(HttpMethod.Get);
      statementDateDeptList.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sd_SiteID}/Date/Dept/{work_pm_MenuCode}/{work_pmp_PropCode}";
      statementDateDeptList.Headers.Add("Send-Type", SendType);
      statementDateDeptList.SetSegment<UniBizHttpRequest<UbRes<IList<StatementDateDept>>>, long>((Expression<Func<long>>) (() => sd_SiteID));
      statementDateDeptList.SetSegment<UniBizHttpRequest<UbRes<IList<StatementDateDept>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      statementDateDeptList.SetSegment<UniBizHttpRequest<UbRes<IList<StatementDateDept>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      statementDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateDept>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sh_ConfirmDate > 0L)
        statementDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateDept>>>, long>((Expression<Func<long>>) (() => sh_ConfirmDate));
      if (sh_ConfirmDateBegin > 0L)
        statementDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateDept>>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateBegin));
      if (sh_ConfirmDateEnd > 0L)
        statementDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateDept>>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateEnd));
      if (sh_ConfirmStatus > 0)
        statementDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateDept>>>, int>((Expression<Func<int>>) (() => sh_ConfirmStatus));
      if (sh_StatementType > 0)
        statementDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateDept>>>, int>((Expression<Func<int>>) (() => sh_StatementType));
      if (!string.IsNullOrEmpty(sh_StatementTypeIn))
        statementDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateDept>>>, string>((Expression<Func<string>>) (() => sh_StatementTypeIn));
      if (si_StoreCode > 0)
        statementDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateDept>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        statementDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateDept>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        statementDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateDept>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        statementDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateDept>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        statementDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateDept>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        statementDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateDept>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        statementDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateDept>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        statementDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateDept>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        statementDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateDept>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        statementDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateDept>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        statementDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateDept>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        statementDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateDept>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        statementDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateDept>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        statementDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateDept>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        statementDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateDept>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        statementDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateDept>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        statementDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateDept>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        statementDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateDept>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        statementDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateDept>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        statementDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateDept>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        statementDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateDept>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        statementDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateDept>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        statementDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateDept>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        statementDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateDept>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        statementDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateDept>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      statementDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateDept>>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        statementDateDeptList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateDept>>>, string>((Expression<Func<string>>) (() => KeyWord));
      statementDateDeptList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<StatementDateDept>>>>(MethodBase.GetCurrentMethod());
      return statementDateDeptList;
    }

    public static UniBizHttpRequest<UbRes<IList<StatementDateCategoryTop>>> GetStatementDateCategoryTopList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sd_SiteID")] long sd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sh_ConfirmDate")] long sh_ConfirmDate = 0,
      [NameConvert("p_sh_ConfirmDateBegin")] long sh_ConfirmDateBegin = 0,
      [NameConvert("p_sh_ConfirmDateEnd")] long sh_ConfirmDateEnd = 0,
      [NameConvert("p_sh_ConfirmStatus")] int sh_ConfirmStatus = 0,
      [NameConvert("p_sh_StatementType")] int sh_StatementType = 0,
      [NameConvert("p_sh_StatementTypeIn")] string sh_StatementTypeIn = null,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<StatementDateCategoryTop>>> dateCategoryTopList = new UniBizHttpRequest<UbRes<IList<StatementDateCategoryTop>>>(HttpMethod.Get);
      dateCategoryTopList.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sd_SiteID}/Date/CategoryTop/{work_pm_MenuCode}/{work_pmp_PropCode}";
      dateCategoryTopList.Headers.Add("Send-Type", SendType);
      dateCategoryTopList.SetSegment<UniBizHttpRequest<UbRes<IList<StatementDateCategoryTop>>>, long>((Expression<Func<long>>) (() => sd_SiteID));
      dateCategoryTopList.SetSegment<UniBizHttpRequest<UbRes<IList<StatementDateCategoryTop>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      dateCategoryTopList.SetSegment<UniBizHttpRequest<UbRes<IList<StatementDateCategoryTop>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryTop>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sh_ConfirmDate > 0L)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryTop>>>, long>((Expression<Func<long>>) (() => sh_ConfirmDate));
      if (sh_ConfirmDateBegin > 0L)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryTop>>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateBegin));
      if (sh_ConfirmDateEnd > 0L)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryTop>>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateEnd));
      if (sh_ConfirmStatus > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryTop>>>, int>((Expression<Func<int>>) (() => sh_ConfirmStatus));
      if (sh_StatementType > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryTop>>>, int>((Expression<Func<int>>) (() => sh_StatementType));
      if (!string.IsNullOrEmpty(sh_StatementTypeIn))
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryTop>>>, string>((Expression<Func<string>>) (() => sh_StatementTypeIn));
      if (si_StoreCode > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryTop>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryTop>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryTop>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryTop>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryTop>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryTop>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryTop>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryTop>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryTop>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryTop>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryTop>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryTop>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryTop>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryTop>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryTop>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryTop>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryTop>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryTop>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryTop>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryTop>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryTop>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryTop>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryTop>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryTop>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryTop>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryTop>>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        dateCategoryTopList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryTop>>>, string>((Expression<Func<string>>) (() => KeyWord));
      dateCategoryTopList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<StatementDateCategoryTop>>>>(MethodBase.GetCurrentMethod());
      return dateCategoryTopList;
    }

    public static UniBizHttpRequest<UbRes<IList<StatementDateCategoryMid>>> GetStatementDateCategoryMidList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sd_SiteID")] long sd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sh_ConfirmDate")] long sh_ConfirmDate = 0,
      [NameConvert("p_sh_ConfirmDateBegin")] long sh_ConfirmDateBegin = 0,
      [NameConvert("p_sh_ConfirmDateEnd")] long sh_ConfirmDateEnd = 0,
      [NameConvert("p_sh_ConfirmStatus")] int sh_ConfirmStatus = 0,
      [NameConvert("p_sh_StatementType")] int sh_StatementType = 0,
      [NameConvert("p_sh_StatementTypeIn")] string sh_StatementTypeIn = null,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<StatementDateCategoryMid>>> dateCategoryMidList = new UniBizHttpRequest<UbRes<IList<StatementDateCategoryMid>>>(HttpMethod.Get);
      dateCategoryMidList.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sd_SiteID}/Date/CategoryMid/{work_pm_MenuCode}/{work_pmp_PropCode}";
      dateCategoryMidList.Headers.Add("Send-Type", SendType);
      dateCategoryMidList.SetSegment<UniBizHttpRequest<UbRes<IList<StatementDateCategoryMid>>>, long>((Expression<Func<long>>) (() => sd_SiteID));
      dateCategoryMidList.SetSegment<UniBizHttpRequest<UbRes<IList<StatementDateCategoryMid>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      dateCategoryMidList.SetSegment<UniBizHttpRequest<UbRes<IList<StatementDateCategoryMid>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryMid>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sh_ConfirmDate > 0L)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryMid>>>, long>((Expression<Func<long>>) (() => sh_ConfirmDate));
      if (sh_ConfirmDateBegin > 0L)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryMid>>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateBegin));
      if (sh_ConfirmDateEnd > 0L)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryMid>>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateEnd));
      if (sh_ConfirmStatus > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryMid>>>, int>((Expression<Func<int>>) (() => sh_ConfirmStatus));
      if (sh_StatementType > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryMid>>>, int>((Expression<Func<int>>) (() => sh_StatementType));
      if (!string.IsNullOrEmpty(sh_StatementTypeIn))
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryMid>>>, string>((Expression<Func<string>>) (() => sh_StatementTypeIn));
      if (si_StoreCode > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryMid>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryMid>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryMid>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryMid>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryMid>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryMid>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryMid>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryMid>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryMid>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryMid>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryMid>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryMid>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryMid>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryMid>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryMid>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryMid>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryMid>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryMid>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryMid>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryMid>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryMid>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryMid>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryMid>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryMid>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryMid>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryMid>>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        dateCategoryMidList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryMid>>>, string>((Expression<Func<string>>) (() => KeyWord));
      dateCategoryMidList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<StatementDateCategoryMid>>>>(MethodBase.GetCurrentMethod());
      return dateCategoryMidList;
    }

    public static UniBizHttpRequest<UbRes<IList<StatementDateCategoryBot>>> GetStatementDateCategoryBotList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sd_SiteID")] long sd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sh_ConfirmDate")] long sh_ConfirmDate = 0,
      [NameConvert("p_sh_ConfirmDateBegin")] long sh_ConfirmDateBegin = 0,
      [NameConvert("p_sh_ConfirmDateEnd")] long sh_ConfirmDateEnd = 0,
      [NameConvert("p_sh_ConfirmStatus")] int sh_ConfirmStatus = 0,
      [NameConvert("p_sh_StatementType")] int sh_StatementType = 0,
      [NameConvert("p_sh_StatementTypeIn")] string sh_StatementTypeIn = null,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<StatementDateCategoryBot>>> dateCategoryBotList = new UniBizHttpRequest<UbRes<IList<StatementDateCategoryBot>>>(HttpMethod.Get);
      dateCategoryBotList.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sd_SiteID}/Date/CategoryBot/{work_pm_MenuCode}/{work_pmp_PropCode}";
      dateCategoryBotList.Headers.Add("Send-Type", SendType);
      dateCategoryBotList.SetSegment<UniBizHttpRequest<UbRes<IList<StatementDateCategoryBot>>>, long>((Expression<Func<long>>) (() => sd_SiteID));
      dateCategoryBotList.SetSegment<UniBizHttpRequest<UbRes<IList<StatementDateCategoryBot>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      dateCategoryBotList.SetSegment<UniBizHttpRequest<UbRes<IList<StatementDateCategoryBot>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryBot>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sh_ConfirmDate > 0L)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryBot>>>, long>((Expression<Func<long>>) (() => sh_ConfirmDate));
      if (sh_ConfirmDateBegin > 0L)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryBot>>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateBegin));
      if (sh_ConfirmDateEnd > 0L)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryBot>>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateEnd));
      if (sh_ConfirmStatus > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryBot>>>, int>((Expression<Func<int>>) (() => sh_ConfirmStatus));
      if (sh_StatementType > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryBot>>>, int>((Expression<Func<int>>) (() => sh_StatementType));
      if (!string.IsNullOrEmpty(sh_StatementTypeIn))
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryBot>>>, string>((Expression<Func<string>>) (() => sh_StatementTypeIn));
      if (si_StoreCode > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryBot>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryBot>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryBot>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryBot>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryBot>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryBot>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryBot>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryBot>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryBot>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryBot>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryBot>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryBot>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryBot>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryBot>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryBot>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryBot>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryBot>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryBot>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryBot>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryBot>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryBot>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryBot>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryBot>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryBot>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryBot>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryBot>>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        dateCategoryBotList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateCategoryBot>>>, string>((Expression<Func<string>>) (() => KeyWord));
      dateCategoryBotList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<StatementDateCategoryBot>>>>(MethodBase.GetCurrentMethod());
      return dateCategoryBotList;
    }

    public static UniBizHttpRequest<UbRes<IList<StatementDateGoods>>> GetStatementDateGoodsList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sd_SiteID")] long sd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sh_ConfirmDate")] long sh_ConfirmDate = 0,
      [NameConvert("p_sh_ConfirmDateBegin")] long sh_ConfirmDateBegin = 0,
      [NameConvert("p_sh_ConfirmDateEnd")] long sh_ConfirmDateEnd = 0,
      [NameConvert("p_sh_ConfirmStatus")] int sh_ConfirmStatus = 0,
      [NameConvert("p_sh_StatementType")] int sh_StatementType = 0,
      [NameConvert("p_sh_StatementTypeIn")] string sh_StatementTypeIn = null,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<StatementDateGoods>>> statementDateGoodsList = new UniBizHttpRequest<UbRes<IList<StatementDateGoods>>>(HttpMethod.Get);
      statementDateGoodsList.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sd_SiteID}/Date/Goods/{work_pm_MenuCode}/{work_pmp_PropCode}";
      statementDateGoodsList.Headers.Add("Send-Type", SendType);
      statementDateGoodsList.SetSegment<UniBizHttpRequest<UbRes<IList<StatementDateGoods>>>, long>((Expression<Func<long>>) (() => sd_SiteID));
      statementDateGoodsList.SetSegment<UniBizHttpRequest<UbRes<IList<StatementDateGoods>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      statementDateGoodsList.SetSegment<UniBizHttpRequest<UbRes<IList<StatementDateGoods>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      statementDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateGoods>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sh_ConfirmDate > 0L)
        statementDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateGoods>>>, long>((Expression<Func<long>>) (() => sh_ConfirmDate));
      if (sh_ConfirmDateBegin > 0L)
        statementDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateGoods>>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateBegin));
      if (sh_ConfirmDateEnd > 0L)
        statementDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateGoods>>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateEnd));
      if (sh_ConfirmStatus > 0)
        statementDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateGoods>>>, int>((Expression<Func<int>>) (() => sh_ConfirmStatus));
      if (sh_StatementType > 0)
        statementDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateGoods>>>, int>((Expression<Func<int>>) (() => sh_StatementType));
      if (!string.IsNullOrEmpty(sh_StatementTypeIn))
        statementDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateGoods>>>, string>((Expression<Func<string>>) (() => sh_StatementTypeIn));
      if (si_StoreCode > 0)
        statementDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateGoods>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        statementDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateGoods>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        statementDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateGoods>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        statementDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateGoods>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        statementDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateGoods>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        statementDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateGoods>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        statementDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateGoods>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        statementDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateGoods>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        statementDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateGoods>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        statementDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateGoods>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        statementDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateGoods>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        statementDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateGoods>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        statementDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateGoods>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        statementDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateGoods>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        statementDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateGoods>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        statementDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateGoods>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        statementDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateGoods>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        statementDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateGoods>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        statementDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateGoods>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        statementDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateGoods>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        statementDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateGoods>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        statementDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateGoods>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        statementDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateGoods>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        statementDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateGoods>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        statementDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateGoods>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      statementDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateGoods>>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        statementDateGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementDateGoods>>>, string>((Expression<Func<string>>) (() => KeyWord));
      statementDateGoodsList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<StatementDateGoods>>>>(MethodBase.GetCurrentMethod());
      return statementDateGoodsList;
    }

    public static UniBizHttpRequest<UbRes<StatementDayHorizontalByStorePack>> GetStatementDayHorizontalByStorePack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sd_SiteID")] long sd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sh_ConfirmDate")] long sh_ConfirmDate = 0,
      [NameConvert("p_sh_ConfirmDateBegin")] long sh_ConfirmDateBegin = 0,
      [NameConvert("p_sh_ConfirmDateEnd")] long sh_ConfirmDateEnd = 0,
      [NameConvert("p_sh_ConfirmStatus")] int sh_ConfirmStatus = 0,
      [NameConvert("p_sh_StatementType")] int sh_StatementType = 0,
      [NameConvert("p_sh_StatementTypeIn")] string sh_StatementTypeIn = null,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<StatementDayHorizontalByStorePack>> horizontalByStorePack = new UniBizHttpRequest<UbRes<StatementDayHorizontalByStorePack>>(HttpMethod.Get);
      horizontalByStorePack.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sd_SiteID}/Day/Horizontal/Store/{work_pm_MenuCode}/{work_pmp_PropCode}";
      horizontalByStorePack.Headers.Add("Send-Type", SendType);
      horizontalByStorePack.SetSegment<UniBizHttpRequest<UbRes<StatementDayHorizontalByStorePack>>, long>((Expression<Func<long>>) (() => sd_SiteID));
      horizontalByStorePack.SetSegment<UniBizHttpRequest<UbRes<StatementDayHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      horizontalByStorePack.SetSegment<UniBizHttpRequest<UbRes<StatementDayHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByStorePack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sh_ConfirmDate > 0L)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByStorePack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDate));
      if (sh_ConfirmDateBegin > 0L)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByStorePack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateBegin));
      if (sh_ConfirmDateEnd > 0L)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByStorePack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateEnd));
      if (sh_ConfirmStatus > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => sh_ConfirmStatus));
      if (sh_StatementType > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => sh_StatementType));
      if (!string.IsNullOrEmpty(sh_StatementTypeIn))
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByStorePack>>, string>((Expression<Func<string>>) (() => sh_StatementTypeIn));
      if (si_StoreCode > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByStorePack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByStorePack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByStorePack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByStorePack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByStorePack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByStorePack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByStorePack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByStorePack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByStorePack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByStorePack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByStorePack>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByStorePack>>, string>((Expression<Func<string>>) (() => KeyWord));
      horizontalByStorePack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<StatementDayHorizontalByStorePack>>>(MethodBase.GetCurrentMethod());
      return horizontalByStorePack;
    }

    public static UniBizHttpRequest<UbRes<StatementDayHorizontalByTeamPack>> GetStatementDayHorizontalByTeamPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sd_SiteID")] long sd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sh_ConfirmDate")] long sh_ConfirmDate = 0,
      [NameConvert("p_sh_ConfirmDateBegin")] long sh_ConfirmDateBegin = 0,
      [NameConvert("p_sh_ConfirmDateEnd")] long sh_ConfirmDateEnd = 0,
      [NameConvert("p_sh_ConfirmStatus")] int sh_ConfirmStatus = 0,
      [NameConvert("p_sh_StatementType")] int sh_StatementType = 0,
      [NameConvert("p_sh_StatementTypeIn")] string sh_StatementTypeIn = null,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<StatementDayHorizontalByTeamPack>> horizontalByTeamPack = new UniBizHttpRequest<UbRes<StatementDayHorizontalByTeamPack>>(HttpMethod.Get);
      horizontalByTeamPack.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sd_SiteID}/Day/Horizontal/Team/{work_pm_MenuCode}/{work_pmp_PropCode}";
      horizontalByTeamPack.Headers.Add("Send-Type", SendType);
      horizontalByTeamPack.SetSegment<UniBizHttpRequest<UbRes<StatementDayHorizontalByTeamPack>>, long>((Expression<Func<long>>) (() => sd_SiteID));
      horizontalByTeamPack.SetSegment<UniBizHttpRequest<UbRes<StatementDayHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      horizontalByTeamPack.SetSegment<UniBizHttpRequest<UbRes<StatementDayHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByTeamPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sh_ConfirmDate > 0L)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByTeamPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDate));
      if (sh_ConfirmDateBegin > 0L)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByTeamPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateBegin));
      if (sh_ConfirmDateEnd > 0L)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByTeamPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateEnd));
      if (sh_ConfirmStatus > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => sh_ConfirmStatus));
      if (sh_StatementType > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => sh_StatementType));
      if (!string.IsNullOrEmpty(sh_StatementTypeIn))
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByTeamPack>>, string>((Expression<Func<string>>) (() => sh_StatementTypeIn));
      if (si_StoreCode > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByTeamPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByTeamPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByTeamPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByTeamPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByTeamPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByTeamPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByTeamPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByTeamPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByTeamPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByTeamPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByTeamPack>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByTeamPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      horizontalByTeamPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<StatementDayHorizontalByTeamPack>>>(MethodBase.GetCurrentMethod());
      return horizontalByTeamPack;
    }

    public static UniBizHttpRequest<UbRes<StatementDayHorizontalByDeptPack>> GetStatementDayHorizontalByDeptPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sd_SiteID")] long sd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sh_ConfirmDate")] long sh_ConfirmDate = 0,
      [NameConvert("p_sh_ConfirmDateBegin")] long sh_ConfirmDateBegin = 0,
      [NameConvert("p_sh_ConfirmDateEnd")] long sh_ConfirmDateEnd = 0,
      [NameConvert("p_sh_ConfirmStatus")] int sh_ConfirmStatus = 0,
      [NameConvert("p_sh_StatementType")] int sh_StatementType = 0,
      [NameConvert("p_sh_StatementTypeIn")] string sh_StatementTypeIn = null,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<StatementDayHorizontalByDeptPack>> horizontalByDeptPack = new UniBizHttpRequest<UbRes<StatementDayHorizontalByDeptPack>>(HttpMethod.Get);
      horizontalByDeptPack.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sd_SiteID}/Day/Horizontal/Dept/{work_pm_MenuCode}/{work_pmp_PropCode}";
      horizontalByDeptPack.Headers.Add("Send-Type", SendType);
      horizontalByDeptPack.SetSegment<UniBizHttpRequest<UbRes<StatementDayHorizontalByDeptPack>>, long>((Expression<Func<long>>) (() => sd_SiteID));
      horizontalByDeptPack.SetSegment<UniBizHttpRequest<UbRes<StatementDayHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      horizontalByDeptPack.SetSegment<UniBizHttpRequest<UbRes<StatementDayHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByDeptPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sh_ConfirmDate > 0L)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByDeptPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDate));
      if (sh_ConfirmDateBegin > 0L)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByDeptPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateBegin));
      if (sh_ConfirmDateEnd > 0L)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByDeptPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateEnd));
      if (sh_ConfirmStatus > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => sh_ConfirmStatus));
      if (sh_StatementType > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => sh_StatementType));
      if (!string.IsNullOrEmpty(sh_StatementTypeIn))
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByDeptPack>>, string>((Expression<Func<string>>) (() => sh_StatementTypeIn));
      if (si_StoreCode > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByDeptPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByDeptPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByDeptPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByDeptPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByDeptPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByDeptPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByDeptPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByDeptPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByDeptPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByDeptPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByDeptPack>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByDeptPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      horizontalByDeptPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<StatementDayHorizontalByDeptPack>>>(MethodBase.GetCurrentMethod());
      return horizontalByDeptPack;
    }

    public static UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryTopPack>> GetStatementDayHorizontalByCategoryTopPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sd_SiteID")] long sd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sh_ConfirmDate")] long sh_ConfirmDate = 0,
      [NameConvert("p_sh_ConfirmDateBegin")] long sh_ConfirmDateBegin = 0,
      [NameConvert("p_sh_ConfirmDateEnd")] long sh_ConfirmDateEnd = 0,
      [NameConvert("p_sh_ConfirmStatus")] int sh_ConfirmStatus = 0,
      [NameConvert("p_sh_StatementType")] int sh_StatementType = 0,
      [NameConvert("p_sh_StatementTypeIn")] string sh_StatementTypeIn = null,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryTopPack>> byCategoryTopPack = new UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryTopPack>>(HttpMethod.Get);
      byCategoryTopPack.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sd_SiteID}/Day/Horizontal/CategoryTop/{work_pm_MenuCode}/{work_pmp_PropCode}";
      byCategoryTopPack.Headers.Add("Send-Type", SendType);
      byCategoryTopPack.SetSegment<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryTopPack>>, long>((Expression<Func<long>>) (() => sd_SiteID));
      byCategoryTopPack.SetSegment<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      byCategoryTopPack.SetSegment<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryTopPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sh_ConfirmDate > 0L)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryTopPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDate));
      if (sh_ConfirmDateBegin > 0L)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryTopPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateBegin));
      if (sh_ConfirmDateEnd > 0L)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryTopPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateEnd));
      if (sh_ConfirmStatus > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => sh_ConfirmStatus));
      if (sh_StatementType > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => sh_StatementType));
      if (!string.IsNullOrEmpty(sh_StatementTypeIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => sh_StatementTypeIn));
      if (si_StoreCode > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryTopPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryTopPack>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      byCategoryTopPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryTopPack>>>(MethodBase.GetCurrentMethod());
      return byCategoryTopPack;
    }

    public static UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryMidPack>> GetStatementDayHorizontalByCategoryMidPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sd_SiteID")] long sd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sh_ConfirmDate")] long sh_ConfirmDate = 0,
      [NameConvert("p_sh_ConfirmDateBegin")] long sh_ConfirmDateBegin = 0,
      [NameConvert("p_sh_ConfirmDateEnd")] long sh_ConfirmDateEnd = 0,
      [NameConvert("p_sh_ConfirmStatus")] int sh_ConfirmStatus = 0,
      [NameConvert("p_sh_StatementType")] int sh_StatementType = 0,
      [NameConvert("p_sh_StatementTypeIn")] string sh_StatementTypeIn = null,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryMidPack>> byCategoryMidPack = new UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryMidPack>>(HttpMethod.Get);
      byCategoryMidPack.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sd_SiteID}/Day/Horizontal/CategoryMid/{work_pm_MenuCode}/{work_pmp_PropCode}";
      byCategoryMidPack.Headers.Add("Send-Type", SendType);
      byCategoryMidPack.SetSegment<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryMidPack>>, long>((Expression<Func<long>>) (() => sd_SiteID));
      byCategoryMidPack.SetSegment<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      byCategoryMidPack.SetSegment<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryMidPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sh_ConfirmDate > 0L)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryMidPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDate));
      if (sh_ConfirmDateBegin > 0L)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryMidPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateBegin));
      if (sh_ConfirmDateEnd > 0L)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryMidPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateEnd));
      if (sh_ConfirmStatus > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => sh_ConfirmStatus));
      if (sh_StatementType > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => sh_StatementType));
      if (!string.IsNullOrEmpty(sh_StatementTypeIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => sh_StatementTypeIn));
      if (si_StoreCode > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryMidPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryMidPack>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      byCategoryMidPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryMidPack>>>(MethodBase.GetCurrentMethod());
      return byCategoryMidPack;
    }

    public static UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryBotPack>> GetStatementDayHorizontalByCategoryBotPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sd_SiteID")] long sd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sh_ConfirmDate")] long sh_ConfirmDate = 0,
      [NameConvert("p_sh_ConfirmDateBegin")] long sh_ConfirmDateBegin = 0,
      [NameConvert("p_sh_ConfirmDateEnd")] long sh_ConfirmDateEnd = 0,
      [NameConvert("p_sh_ConfirmStatus")] int sh_ConfirmStatus = 0,
      [NameConvert("p_sh_StatementType")] int sh_StatementType = 0,
      [NameConvert("p_sh_StatementTypeIn")] string sh_StatementTypeIn = null,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryBotPack>> byCategoryBotPack = new UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryBotPack>>(HttpMethod.Get);
      byCategoryBotPack.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sd_SiteID}/Day/Horizontal/CategoryBot/{work_pm_MenuCode}/{work_pmp_PropCode}";
      byCategoryBotPack.Headers.Add("Send-Type", SendType);
      byCategoryBotPack.SetSegment<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryBotPack>>, long>((Expression<Func<long>>) (() => sd_SiteID));
      byCategoryBotPack.SetSegment<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      byCategoryBotPack.SetSegment<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryBotPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sh_ConfirmDate > 0L)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryBotPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDate));
      if (sh_ConfirmDateBegin > 0L)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryBotPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateBegin));
      if (sh_ConfirmDateEnd > 0L)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryBotPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateEnd));
      if (sh_ConfirmStatus > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => sh_ConfirmStatus));
      if (sh_StatementType > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => sh_StatementType));
      if (!string.IsNullOrEmpty(sh_StatementTypeIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => sh_StatementTypeIn));
      if (si_StoreCode > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryBotPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryBotPack>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      byCategoryBotPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<StatementDayHorizontalByCategoryBotPack>>>(MethodBase.GetCurrentMethod());
      return byCategoryBotPack;
    }

    public static UniBizHttpRequest<UbRes<StatementDayHorizontalByGoodsPack>> GetStatementDayHorizontalByGoodsPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sd_SiteID")] long sd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sh_ConfirmDate")] long sh_ConfirmDate = 0,
      [NameConvert("p_sh_ConfirmDateBegin")] long sh_ConfirmDateBegin = 0,
      [NameConvert("p_sh_ConfirmDateEnd")] long sh_ConfirmDateEnd = 0,
      [NameConvert("p_sh_ConfirmStatus")] int sh_ConfirmStatus = 0,
      [NameConvert("p_sh_StatementType")] int sh_StatementType = 0,
      [NameConvert("p_sh_StatementTypeIn")] string sh_StatementTypeIn = null,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<StatementDayHorizontalByGoodsPack>> horizontalByGoodsPack = new UniBizHttpRequest<UbRes<StatementDayHorizontalByGoodsPack>>(HttpMethod.Get);
      horizontalByGoodsPack.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sd_SiteID}/Day/Horizontal/Goods/{work_pm_MenuCode}/{work_pmp_PropCode}";
      horizontalByGoodsPack.Headers.Add("Send-Type", SendType);
      horizontalByGoodsPack.SetSegment<UniBizHttpRequest<UbRes<StatementDayHorizontalByGoodsPack>>, long>((Expression<Func<long>>) (() => sd_SiteID));
      horizontalByGoodsPack.SetSegment<UniBizHttpRequest<UbRes<StatementDayHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      horizontalByGoodsPack.SetSegment<UniBizHttpRequest<UbRes<StatementDayHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByGoodsPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sh_ConfirmDate > 0L)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByGoodsPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDate));
      if (sh_ConfirmDateBegin > 0L)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByGoodsPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateBegin));
      if (sh_ConfirmDateEnd > 0L)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByGoodsPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateEnd));
      if (sh_ConfirmStatus > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => sh_ConfirmStatus));
      if (sh_StatementType > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => sh_StatementType));
      if (!string.IsNullOrEmpty(sh_StatementTypeIn))
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByGoodsPack>>, string>((Expression<Func<string>>) (() => sh_StatementTypeIn));
      if (si_StoreCode > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByGoodsPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByGoodsPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByGoodsPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByGoodsPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByGoodsPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByGoodsPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByGoodsPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByGoodsPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByGoodsPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByGoodsPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByGoodsPack>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalByGoodsPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      horizontalByGoodsPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<StatementDayHorizontalByGoodsPack>>>(MethodBase.GetCurrentMethod());
      return horizontalByGoodsPack;
    }

    public static UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierPack>> GetStatementDayHorizontalBySupplierPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sd_SiteID")] long sd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sh_ConfirmDate")] long sh_ConfirmDate = 0,
      [NameConvert("p_sh_ConfirmDateBegin")] long sh_ConfirmDateBegin = 0,
      [NameConvert("p_sh_ConfirmDateEnd")] long sh_ConfirmDateEnd = 0,
      [NameConvert("p_sh_ConfirmStatus")] int sh_ConfirmStatus = 0,
      [NameConvert("p_sh_StatementType")] int sh_StatementType = 0,
      [NameConvert("p_sh_StatementTypeIn")] string sh_StatementTypeIn = null,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierPack>> horizontalBySupplierPack = new UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierPack>>(HttpMethod.Get);
      horizontalBySupplierPack.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sd_SiteID}/Day/Horizontal/Supplier/Store/{work_pm_MenuCode}/{work_pmp_PropCode}";
      horizontalBySupplierPack.Headers.Add("Send-Type", SendType);
      horizontalBySupplierPack.SetSegment<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierPack>>, long>((Expression<Func<long>>) (() => sd_SiteID));
      horizontalBySupplierPack.SetSegment<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      horizontalBySupplierPack.SetSegment<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sh_ConfirmDate > 0L)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDate));
      if (sh_ConfirmDateBegin > 0L)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateBegin));
      if (sh_ConfirmDateEnd > 0L)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateEnd));
      if (sh_ConfirmStatus > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => sh_ConfirmStatus));
      if (sh_StatementType > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => sh_StatementType));
      if (!string.IsNullOrEmpty(sh_StatementTypeIn))
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierPack>>, string>((Expression<Func<string>>) (() => sh_StatementTypeIn));
      if (si_StoreCode > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierPack>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      horizontalBySupplierPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierPack>>>(MethodBase.GetCurrentMethod());
      return horizontalBySupplierPack;
    }

    public static UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatTopPack>> GetStatementDayHorizontalBySupplierCatTopPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sd_SiteID")] long sd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sh_ConfirmDate")] long sh_ConfirmDate = 0,
      [NameConvert("p_sh_ConfirmDateBegin")] long sh_ConfirmDateBegin = 0,
      [NameConvert("p_sh_ConfirmDateEnd")] long sh_ConfirmDateEnd = 0,
      [NameConvert("p_sh_ConfirmStatus")] int sh_ConfirmStatus = 0,
      [NameConvert("p_sh_StatementType")] int sh_StatementType = 0,
      [NameConvert("p_sh_StatementTypeIn")] string sh_StatementTypeIn = null,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatTopPack>> supplierCatTopPack = new UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatTopPack>>(HttpMethod.Get);
      supplierCatTopPack.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sd_SiteID}/Day/Horizontal/Supplier/CategoryTop/{work_pm_MenuCode}/{work_pmp_PropCode}";
      supplierCatTopPack.Headers.Add("Send-Type", SendType);
      supplierCatTopPack.SetSegment<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatTopPack>>, long>((Expression<Func<long>>) (() => sd_SiteID));
      supplierCatTopPack.SetSegment<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatTopPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      supplierCatTopPack.SetSegment<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatTopPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatTopPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sh_ConfirmDate > 0L)
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatTopPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDate));
      if (sh_ConfirmDateBegin > 0L)
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatTopPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateBegin));
      if (sh_ConfirmDateEnd > 0L)
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatTopPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateEnd));
      if (sh_ConfirmStatus > 0)
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatTopPack>>, int>((Expression<Func<int>>) (() => sh_ConfirmStatus));
      if (sh_StatementType > 0)
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatTopPack>>, int>((Expression<Func<int>>) (() => sh_StatementType));
      if (!string.IsNullOrEmpty(sh_StatementTypeIn))
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatTopPack>>, string>((Expression<Func<string>>) (() => sh_StatementTypeIn));
      if (si_StoreCode > 0)
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatTopPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatTopPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatTopPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatTopPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatTopPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatTopPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatTopPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatTopPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatTopPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatTopPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatTopPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatTopPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatTopPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatTopPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatTopPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatTopPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatTopPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatTopPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatTopPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatTopPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatTopPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatTopPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatTopPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatTopPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatTopPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatTopPack>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatTopPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      supplierCatTopPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatTopPack>>>(MethodBase.GetCurrentMethod());
      return supplierCatTopPack;
    }

    public static UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatMidPack>> GetStatementDayHorizontalBySupplierCatMidPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sd_SiteID")] long sd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sh_ConfirmDate")] long sh_ConfirmDate = 0,
      [NameConvert("p_sh_ConfirmDateBegin")] long sh_ConfirmDateBegin = 0,
      [NameConvert("p_sh_ConfirmDateEnd")] long sh_ConfirmDateEnd = 0,
      [NameConvert("p_sh_ConfirmStatus")] int sh_ConfirmStatus = 0,
      [NameConvert("p_sh_StatementType")] int sh_StatementType = 0,
      [NameConvert("p_sh_StatementTypeIn")] string sh_StatementTypeIn = null,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatMidPack>> supplierCatMidPack = new UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatMidPack>>(HttpMethod.Get);
      supplierCatMidPack.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sd_SiteID}/Day/Horizontal/Supplier/CategoryMid/{work_pm_MenuCode}/{work_pmp_PropCode}";
      supplierCatMidPack.Headers.Add("Send-Type", SendType);
      supplierCatMidPack.SetSegment<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatMidPack>>, long>((Expression<Func<long>>) (() => sd_SiteID));
      supplierCatMidPack.SetSegment<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatMidPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      supplierCatMidPack.SetSegment<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatMidPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatMidPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sh_ConfirmDate > 0L)
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatMidPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDate));
      if (sh_ConfirmDateBegin > 0L)
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatMidPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateBegin));
      if (sh_ConfirmDateEnd > 0L)
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatMidPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateEnd));
      if (sh_ConfirmStatus > 0)
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatMidPack>>, int>((Expression<Func<int>>) (() => sh_ConfirmStatus));
      if (sh_StatementType > 0)
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatMidPack>>, int>((Expression<Func<int>>) (() => sh_StatementType));
      if (!string.IsNullOrEmpty(sh_StatementTypeIn))
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatMidPack>>, string>((Expression<Func<string>>) (() => sh_StatementTypeIn));
      if (si_StoreCode > 0)
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatMidPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatMidPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatMidPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatMidPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatMidPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatMidPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatMidPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatMidPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatMidPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatMidPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatMidPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatMidPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatMidPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatMidPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatMidPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatMidPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatMidPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatMidPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatMidPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatMidPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatMidPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatMidPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatMidPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatMidPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatMidPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatMidPack>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatMidPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      supplierCatMidPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatMidPack>>>(MethodBase.GetCurrentMethod());
      return supplierCatMidPack;
    }

    public static UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatBotPack>> GetStatementDayHorizontalBySupplierCatBotPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sd_SiteID")] long sd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sh_ConfirmDate")] long sh_ConfirmDate = 0,
      [NameConvert("p_sh_ConfirmDateBegin")] long sh_ConfirmDateBegin = 0,
      [NameConvert("p_sh_ConfirmDateEnd")] long sh_ConfirmDateEnd = 0,
      [NameConvert("p_sh_ConfirmStatus")] int sh_ConfirmStatus = 0,
      [NameConvert("p_sh_StatementType")] int sh_StatementType = 0,
      [NameConvert("p_sh_StatementTypeIn")] string sh_StatementTypeIn = null,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatBotPack>> supplierCatBotPack = new UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatBotPack>>(HttpMethod.Get);
      supplierCatBotPack.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sd_SiteID}/Day/Horizontal/Supplier/CategoryBot/{work_pm_MenuCode}/{work_pmp_PropCode}";
      supplierCatBotPack.Headers.Add("Send-Type", SendType);
      supplierCatBotPack.SetSegment<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatBotPack>>, long>((Expression<Func<long>>) (() => sd_SiteID));
      supplierCatBotPack.SetSegment<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatBotPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      supplierCatBotPack.SetSegment<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatBotPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatBotPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sh_ConfirmDate > 0L)
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatBotPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDate));
      if (sh_ConfirmDateBegin > 0L)
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatBotPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateBegin));
      if (sh_ConfirmDateEnd > 0L)
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatBotPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateEnd));
      if (sh_ConfirmStatus > 0)
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatBotPack>>, int>((Expression<Func<int>>) (() => sh_ConfirmStatus));
      if (sh_StatementType > 0)
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatBotPack>>, int>((Expression<Func<int>>) (() => sh_StatementType));
      if (!string.IsNullOrEmpty(sh_StatementTypeIn))
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatBotPack>>, string>((Expression<Func<string>>) (() => sh_StatementTypeIn));
      if (si_StoreCode > 0)
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatBotPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatBotPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatBotPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatBotPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatBotPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatBotPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatBotPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatBotPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatBotPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatBotPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatBotPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatBotPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatBotPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatBotPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatBotPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatBotPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatBotPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatBotPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatBotPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatBotPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatBotPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatBotPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatBotPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatBotPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatBotPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatBotPack>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatBotPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      supplierCatBotPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierCatBotPack>>>(MethodBase.GetCurrentMethod());
      return supplierCatBotPack;
    }

    public static UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierGoodsPack>> GetStatementDayHorizontalBySupplierGoodsPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sd_SiteID")] long sd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sh_ConfirmDate")] long sh_ConfirmDate = 0,
      [NameConvert("p_sh_ConfirmDateBegin")] long sh_ConfirmDateBegin = 0,
      [NameConvert("p_sh_ConfirmDateEnd")] long sh_ConfirmDateEnd = 0,
      [NameConvert("p_sh_ConfirmStatus")] int sh_ConfirmStatus = 0,
      [NameConvert("p_sh_StatementType")] int sh_StatementType = 0,
      [NameConvert("p_sh_StatementTypeIn")] string sh_StatementTypeIn = null,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierGoodsPack>> supplierGoodsPack = new UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierGoodsPack>>(HttpMethod.Get);
      supplierGoodsPack.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sd_SiteID}/Day/Horizontal/Supplier/Goods/{work_pm_MenuCode}/{work_pmp_PropCode}";
      supplierGoodsPack.Headers.Add("Send-Type", SendType);
      supplierGoodsPack.SetSegment<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierGoodsPack>>, long>((Expression<Func<long>>) (() => sd_SiteID));
      supplierGoodsPack.SetSegment<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      supplierGoodsPack.SetSegment<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierGoodsPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sh_ConfirmDate > 0L)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierGoodsPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDate));
      if (sh_ConfirmDateBegin > 0L)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierGoodsPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateBegin));
      if (sh_ConfirmDateEnd > 0L)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierGoodsPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateEnd));
      if (sh_ConfirmStatus > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => sh_ConfirmStatus));
      if (sh_StatementType > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => sh_StatementType));
      if (!string.IsNullOrEmpty(sh_StatementTypeIn))
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierGoodsPack>>, string>((Expression<Func<string>>) (() => sh_StatementTypeIn));
      if (si_StoreCode > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierGoodsPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierGoodsPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierGoodsPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierGoodsPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierGoodsPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierGoodsPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierGoodsPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierGoodsPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierGoodsPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierGoodsPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierGoodsPack>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierGoodsPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      supplierGoodsPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<StatementDayHorizontalBySupplierGoodsPack>>>(MethodBase.GetCurrentMethod());
      return supplierGoodsPack;
    }

    public static UniBizHttpRequest<UbRes<StatementDayVerticalByStorePack>> GetStatementDayVerticalByStorePack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sd_SiteID")] long sd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sh_ConfirmDate")] long sh_ConfirmDate = 0,
      [NameConvert("p_sh_ConfirmDateBegin")] long sh_ConfirmDateBegin = 0,
      [NameConvert("p_sh_ConfirmDateEnd")] long sh_ConfirmDateEnd = 0,
      [NameConvert("p_sh_ConfirmStatus")] int sh_ConfirmStatus = 0,
      [NameConvert("p_sh_StatementType")] int sh_StatementType = 0,
      [NameConvert("p_sh_StatementTypeIn")] string sh_StatementTypeIn = null,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<StatementDayVerticalByStorePack>> verticalByStorePack = new UniBizHttpRequest<UbRes<StatementDayVerticalByStorePack>>(HttpMethod.Get);
      verticalByStorePack.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sd_SiteID}/Day/Vertical/Store/{work_pm_MenuCode}/{work_pmp_PropCode}";
      verticalByStorePack.Headers.Add("Send-Type", SendType);
      verticalByStorePack.SetSegment<UniBizHttpRequest<UbRes<StatementDayVerticalByStorePack>>, long>((Expression<Func<long>>) (() => sd_SiteID));
      verticalByStorePack.SetSegment<UniBizHttpRequest<UbRes<StatementDayVerticalByStorePack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      verticalByStorePack.SetSegment<UniBizHttpRequest<UbRes<StatementDayVerticalByStorePack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByStorePack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sh_ConfirmDate > 0L)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByStorePack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDate));
      if (sh_ConfirmDateBegin > 0L)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByStorePack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateBegin));
      if (sh_ConfirmDateEnd > 0L)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByStorePack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateEnd));
      if (sh_ConfirmStatus > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByStorePack>>, int>((Expression<Func<int>>) (() => sh_ConfirmStatus));
      if (sh_StatementType > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByStorePack>>, int>((Expression<Func<int>>) (() => sh_StatementType));
      if (!string.IsNullOrEmpty(sh_StatementTypeIn))
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByStorePack>>, string>((Expression<Func<string>>) (() => sh_StatementTypeIn));
      if (si_StoreCode > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByStorePack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByStorePack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByStorePack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByStorePack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByStorePack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByStorePack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByStorePack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByStorePack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByStorePack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByStorePack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByStorePack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByStorePack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByStorePack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByStorePack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByStorePack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByStorePack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByStorePack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByStorePack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByStorePack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByStorePack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByStorePack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByStorePack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByStorePack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByStorePack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByStorePack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByStorePack>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByStorePack>>, string>((Expression<Func<string>>) (() => KeyWord));
      verticalByStorePack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<StatementDayVerticalByStorePack>>>(MethodBase.GetCurrentMethod());
      return verticalByStorePack;
    }

    public static UniBizHttpRequest<UbRes<StatementDayVerticalByTeamPack>> GetStatementDayVerticalByTeamPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sd_SiteID")] long sd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sh_ConfirmDate")] long sh_ConfirmDate = 0,
      [NameConvert("p_sh_ConfirmDateBegin")] long sh_ConfirmDateBegin = 0,
      [NameConvert("p_sh_ConfirmDateEnd")] long sh_ConfirmDateEnd = 0,
      [NameConvert("p_sh_ConfirmStatus")] int sh_ConfirmStatus = 0,
      [NameConvert("p_sh_StatementType")] int sh_StatementType = 0,
      [NameConvert("p_sh_StatementTypeIn")] string sh_StatementTypeIn = null,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<StatementDayVerticalByTeamPack>> verticalByTeamPack = new UniBizHttpRequest<UbRes<StatementDayVerticalByTeamPack>>(HttpMethod.Get);
      verticalByTeamPack.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sd_SiteID}/Day/Vertical/Team/{work_pm_MenuCode}/{work_pmp_PropCode}";
      verticalByTeamPack.Headers.Add("Send-Type", SendType);
      verticalByTeamPack.SetSegment<UniBizHttpRequest<UbRes<StatementDayVerticalByTeamPack>>, long>((Expression<Func<long>>) (() => sd_SiteID));
      verticalByTeamPack.SetSegment<UniBizHttpRequest<UbRes<StatementDayVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      verticalByTeamPack.SetSegment<UniBizHttpRequest<UbRes<StatementDayVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByTeamPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sh_ConfirmDate > 0L)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByTeamPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDate));
      if (sh_ConfirmDateBegin > 0L)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByTeamPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateBegin));
      if (sh_ConfirmDateEnd > 0L)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByTeamPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateEnd));
      if (sh_ConfirmStatus > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => sh_ConfirmStatus));
      if (sh_StatementType > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => sh_StatementType));
      if (!string.IsNullOrEmpty(sh_StatementTypeIn))
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByTeamPack>>, string>((Expression<Func<string>>) (() => sh_StatementTypeIn));
      if (si_StoreCode > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByTeamPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByTeamPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByTeamPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByTeamPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByTeamPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByTeamPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByTeamPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByTeamPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByTeamPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByTeamPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByTeamPack>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByTeamPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      verticalByTeamPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<StatementDayVerticalByTeamPack>>>(MethodBase.GetCurrentMethod());
      return verticalByTeamPack;
    }

    public static UniBizHttpRequest<UbRes<StatementDayVerticalByDeptPack>> GetStatementDayVerticalByDeptPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sd_SiteID")] long sd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sh_ConfirmDate")] long sh_ConfirmDate = 0,
      [NameConvert("p_sh_ConfirmDateBegin")] long sh_ConfirmDateBegin = 0,
      [NameConvert("p_sh_ConfirmDateEnd")] long sh_ConfirmDateEnd = 0,
      [NameConvert("p_sh_ConfirmStatus")] int sh_ConfirmStatus = 0,
      [NameConvert("p_sh_StatementType")] int sh_StatementType = 0,
      [NameConvert("p_sh_StatementTypeIn")] string sh_StatementTypeIn = null,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<StatementDayVerticalByDeptPack>> verticalByDeptPack = new UniBizHttpRequest<UbRes<StatementDayVerticalByDeptPack>>(HttpMethod.Get);
      verticalByDeptPack.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sd_SiteID}/Day/Vertical/Dept/{work_pm_MenuCode}/{work_pmp_PropCode}";
      verticalByDeptPack.Headers.Add("Send-Type", SendType);
      verticalByDeptPack.SetSegment<UniBizHttpRequest<UbRes<StatementDayVerticalByDeptPack>>, long>((Expression<Func<long>>) (() => sd_SiteID));
      verticalByDeptPack.SetSegment<UniBizHttpRequest<UbRes<StatementDayVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      verticalByDeptPack.SetSegment<UniBizHttpRequest<UbRes<StatementDayVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByDeptPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sh_ConfirmDate > 0L)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByDeptPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDate));
      if (sh_ConfirmDateBegin > 0L)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByDeptPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateBegin));
      if (sh_ConfirmDateEnd > 0L)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByDeptPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateEnd));
      if (sh_ConfirmStatus > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => sh_ConfirmStatus));
      if (sh_StatementType > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => sh_StatementType));
      if (!string.IsNullOrEmpty(sh_StatementTypeIn))
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByDeptPack>>, string>((Expression<Func<string>>) (() => sh_StatementTypeIn));
      if (si_StoreCode > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByDeptPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByDeptPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByDeptPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByDeptPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByDeptPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByDeptPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByDeptPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByDeptPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByDeptPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByDeptPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByDeptPack>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByDeptPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      verticalByDeptPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<StatementDayVerticalByDeptPack>>>(MethodBase.GetCurrentMethod());
      return verticalByDeptPack;
    }

    public static UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryTopPack>> GetStatementDayVerticalByCategoryTopPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sd_SiteID")] long sd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sh_ConfirmDate")] long sh_ConfirmDate = 0,
      [NameConvert("p_sh_ConfirmDateBegin")] long sh_ConfirmDateBegin = 0,
      [NameConvert("p_sh_ConfirmDateEnd")] long sh_ConfirmDateEnd = 0,
      [NameConvert("p_sh_ConfirmStatus")] int sh_ConfirmStatus = 0,
      [NameConvert("p_sh_StatementType")] int sh_StatementType = 0,
      [NameConvert("p_sh_StatementTypeIn")] string sh_StatementTypeIn = null,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryTopPack>> byCategoryTopPack = new UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryTopPack>>(HttpMethod.Get);
      byCategoryTopPack.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sd_SiteID}/Day/Vertical/CategoryTop/{work_pm_MenuCode}/{work_pmp_PropCode}";
      byCategoryTopPack.Headers.Add("Send-Type", SendType);
      byCategoryTopPack.SetSegment<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryTopPack>>, long>((Expression<Func<long>>) (() => sd_SiteID));
      byCategoryTopPack.SetSegment<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      byCategoryTopPack.SetSegment<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryTopPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sh_ConfirmDate > 0L)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryTopPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDate));
      if (sh_ConfirmDateBegin > 0L)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryTopPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateBegin));
      if (sh_ConfirmDateEnd > 0L)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryTopPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateEnd));
      if (sh_ConfirmStatus > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => sh_ConfirmStatus));
      if (sh_StatementType > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => sh_StatementType));
      if (!string.IsNullOrEmpty(sh_StatementTypeIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => sh_StatementTypeIn));
      if (si_StoreCode > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryTopPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryTopPack>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      byCategoryTopPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryTopPack>>>(MethodBase.GetCurrentMethod());
      return byCategoryTopPack;
    }

    public static UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryMidPack>> GetStatementDayVerticalByCategoryMidPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sd_SiteID")] long sd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sh_ConfirmDate")] long sh_ConfirmDate = 0,
      [NameConvert("p_sh_ConfirmDateBegin")] long sh_ConfirmDateBegin = 0,
      [NameConvert("p_sh_ConfirmDateEnd")] long sh_ConfirmDateEnd = 0,
      [NameConvert("p_sh_ConfirmStatus")] int sh_ConfirmStatus = 0,
      [NameConvert("p_sh_StatementType")] int sh_StatementType = 0,
      [NameConvert("p_sh_StatementTypeIn")] string sh_StatementTypeIn = null,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryMidPack>> byCategoryMidPack = new UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryMidPack>>(HttpMethod.Get);
      byCategoryMidPack.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sd_SiteID}/Day/Vertical/CategoryMid/{work_pm_MenuCode}/{work_pmp_PropCode}";
      byCategoryMidPack.Headers.Add("Send-Type", SendType);
      byCategoryMidPack.SetSegment<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryMidPack>>, long>((Expression<Func<long>>) (() => sd_SiteID));
      byCategoryMidPack.SetSegment<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      byCategoryMidPack.SetSegment<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryMidPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sh_ConfirmDate > 0L)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryMidPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDate));
      if (sh_ConfirmDateBegin > 0L)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryMidPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateBegin));
      if (sh_ConfirmDateEnd > 0L)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryMidPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateEnd));
      if (sh_ConfirmStatus > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => sh_ConfirmStatus));
      if (sh_StatementType > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => sh_StatementType));
      if (!string.IsNullOrEmpty(sh_StatementTypeIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => sh_StatementTypeIn));
      if (si_StoreCode > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryMidPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryMidPack>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      byCategoryMidPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryMidPack>>>(MethodBase.GetCurrentMethod());
      return byCategoryMidPack;
    }

    public static UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryBotPack>> GetStatementDayVerticalByCategoryBotPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sd_SiteID")] long sd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sh_ConfirmDate")] long sh_ConfirmDate = 0,
      [NameConvert("p_sh_ConfirmDateBegin")] long sh_ConfirmDateBegin = 0,
      [NameConvert("p_sh_ConfirmDateEnd")] long sh_ConfirmDateEnd = 0,
      [NameConvert("p_sh_ConfirmStatus")] int sh_ConfirmStatus = 0,
      [NameConvert("p_sh_StatementType")] int sh_StatementType = 0,
      [NameConvert("p_sh_StatementTypeIn")] string sh_StatementTypeIn = null,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryBotPack>> byCategoryBotPack = new UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryBotPack>>(HttpMethod.Get);
      byCategoryBotPack.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sd_SiteID}/Day/Vertical/CategoryBot/{work_pm_MenuCode}/{work_pmp_PropCode}";
      byCategoryBotPack.Headers.Add("Send-Type", SendType);
      byCategoryBotPack.SetSegment<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryBotPack>>, long>((Expression<Func<long>>) (() => sd_SiteID));
      byCategoryBotPack.SetSegment<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      byCategoryBotPack.SetSegment<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryBotPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sh_ConfirmDate > 0L)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryBotPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDate));
      if (sh_ConfirmDateBegin > 0L)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryBotPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateBegin));
      if (sh_ConfirmDateEnd > 0L)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryBotPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateEnd));
      if (sh_ConfirmStatus > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => sh_ConfirmStatus));
      if (sh_StatementType > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => sh_StatementType));
      if (!string.IsNullOrEmpty(sh_StatementTypeIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => sh_StatementTypeIn));
      if (si_StoreCode > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryBotPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryBotPack>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      byCategoryBotPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<StatementDayVerticalByCategoryBotPack>>>(MethodBase.GetCurrentMethod());
      return byCategoryBotPack;
    }

    public static UniBizHttpRequest<UbRes<StatementDayVerticalByGoodsPack>> GetStatementDayVerticalByGoodsPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sd_SiteID")] long sd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sh_ConfirmDate")] long sh_ConfirmDate = 0,
      [NameConvert("p_sh_ConfirmDateBegin")] long sh_ConfirmDateBegin = 0,
      [NameConvert("p_sh_ConfirmDateEnd")] long sh_ConfirmDateEnd = 0,
      [NameConvert("p_sh_ConfirmStatus")] int sh_ConfirmStatus = 0,
      [NameConvert("p_sh_StatementType")] int sh_StatementType = 0,
      [NameConvert("p_sh_StatementTypeIn")] string sh_StatementTypeIn = null,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<StatementDayVerticalByGoodsPack>> verticalByGoodsPack = new UniBizHttpRequest<UbRes<StatementDayVerticalByGoodsPack>>(HttpMethod.Get);
      verticalByGoodsPack.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sd_SiteID}/Day/Vertical/Goods/{work_pm_MenuCode}/{work_pmp_PropCode}";
      verticalByGoodsPack.Headers.Add("Send-Type", SendType);
      verticalByGoodsPack.SetSegment<UniBizHttpRequest<UbRes<StatementDayVerticalByGoodsPack>>, long>((Expression<Func<long>>) (() => sd_SiteID));
      verticalByGoodsPack.SetSegment<UniBizHttpRequest<UbRes<StatementDayVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      verticalByGoodsPack.SetSegment<UniBizHttpRequest<UbRes<StatementDayVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByGoodsPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sh_ConfirmDate > 0L)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByGoodsPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDate));
      if (sh_ConfirmDateBegin > 0L)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByGoodsPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateBegin));
      if (sh_ConfirmDateEnd > 0L)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByGoodsPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateEnd));
      if (sh_ConfirmStatus > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => sh_ConfirmStatus));
      if (sh_StatementType > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => sh_StatementType));
      if (!string.IsNullOrEmpty(sh_StatementTypeIn))
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByGoodsPack>>, string>((Expression<Func<string>>) (() => sh_StatementTypeIn));
      if (si_StoreCode > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByGoodsPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByGoodsPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByGoodsPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByGoodsPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByGoodsPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByGoodsPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByGoodsPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByGoodsPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByGoodsPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByGoodsPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByGoodsPack>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementDayVerticalByGoodsPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      verticalByGoodsPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<StatementDayVerticalByGoodsPack>>>(MethodBase.GetCurrentMethod());
      return verticalByGoodsPack;
    }

    public static UniBizHttpRequest<UbRes<StatementMonthHorizontalByStorePack>> GetStatementMonthHorizontalByStorePack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sd_SiteID")] long sd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sh_ConfirmDate")] long sh_ConfirmDate = 0,
      [NameConvert("p_sh_ConfirmDateBegin")] long sh_ConfirmDateBegin = 0,
      [NameConvert("p_sh_ConfirmDateEnd")] long sh_ConfirmDateEnd = 0,
      [NameConvert("p_sh_ConfirmStatus")] int sh_ConfirmStatus = 0,
      [NameConvert("p_sh_StatementType")] int sh_StatementType = 0,
      [NameConvert("p_sh_StatementTypeIn")] string sh_StatementTypeIn = null,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<StatementMonthHorizontalByStorePack>> horizontalByStorePack = new UniBizHttpRequest<UbRes<StatementMonthHorizontalByStorePack>>(HttpMethod.Get);
      horizontalByStorePack.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sd_SiteID}/Month/Horizontal/Store/{work_pm_MenuCode}/{work_pmp_PropCode}";
      horizontalByStorePack.Headers.Add("Send-Type", SendType);
      horizontalByStorePack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthHorizontalByStorePack>>, long>((Expression<Func<long>>) (() => sd_SiteID));
      horizontalByStorePack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      horizontalByStorePack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByStorePack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sh_ConfirmDate > 0L)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByStorePack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDate));
      if (sh_ConfirmDateBegin > 0L)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByStorePack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateBegin));
      if (sh_ConfirmDateEnd > 0L)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByStorePack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateEnd));
      if (sh_ConfirmStatus > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => sh_ConfirmStatus));
      if (sh_StatementType > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => sh_StatementType));
      if (!string.IsNullOrEmpty(sh_StatementTypeIn))
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByStorePack>>, string>((Expression<Func<string>>) (() => sh_StatementTypeIn));
      if (si_StoreCode > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByStorePack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByStorePack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByStorePack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByStorePack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByStorePack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByStorePack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByStorePack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByStorePack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByStorePack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByStorePack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByStorePack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByStorePack>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        horizontalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByStorePack>>, string>((Expression<Func<string>>) (() => KeyWord));
      horizontalByStorePack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<StatementMonthHorizontalByStorePack>>>(MethodBase.GetCurrentMethod());
      return horizontalByStorePack;
    }

    public static UniBizHttpRequest<UbRes<StatementMonthHorizontalByTeamPack>> GetStatementMonthHorizontalByTeamPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sd_SiteID")] long sd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sh_ConfirmDate")] long sh_ConfirmDate = 0,
      [NameConvert("p_sh_ConfirmDateBegin")] long sh_ConfirmDateBegin = 0,
      [NameConvert("p_sh_ConfirmDateEnd")] long sh_ConfirmDateEnd = 0,
      [NameConvert("p_sh_ConfirmStatus")] int sh_ConfirmStatus = 0,
      [NameConvert("p_sh_StatementType")] int sh_StatementType = 0,
      [NameConvert("p_sh_StatementTypeIn")] string sh_StatementTypeIn = null,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<StatementMonthHorizontalByTeamPack>> horizontalByTeamPack = new UniBizHttpRequest<UbRes<StatementMonthHorizontalByTeamPack>>(HttpMethod.Get);
      horizontalByTeamPack.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sd_SiteID}/Month/Horizontal/Team/{work_pm_MenuCode}/{work_pmp_PropCode}";
      horizontalByTeamPack.Headers.Add("Send-Type", SendType);
      horizontalByTeamPack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthHorizontalByTeamPack>>, long>((Expression<Func<long>>) (() => sd_SiteID));
      horizontalByTeamPack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      horizontalByTeamPack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByTeamPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sh_ConfirmDate > 0L)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByTeamPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDate));
      if (sh_ConfirmDateBegin > 0L)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByTeamPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateBegin));
      if (sh_ConfirmDateEnd > 0L)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByTeamPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateEnd));
      if (sh_ConfirmStatus > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => sh_ConfirmStatus));
      if (sh_StatementType > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => sh_StatementType));
      if (!string.IsNullOrEmpty(sh_StatementTypeIn))
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByTeamPack>>, string>((Expression<Func<string>>) (() => sh_StatementTypeIn));
      if (si_StoreCode > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByTeamPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByTeamPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByTeamPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByTeamPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByTeamPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByTeamPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByTeamPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByTeamPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByTeamPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByTeamPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByTeamPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByTeamPack>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        horizontalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByTeamPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      horizontalByTeamPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<StatementMonthHorizontalByTeamPack>>>(MethodBase.GetCurrentMethod());
      return horizontalByTeamPack;
    }

    public static UniBizHttpRequest<UbRes<StatementMonthHorizontalByDeptPack>> GetStatementMonthHorizontalByDeptPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sd_SiteID")] long sd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sh_ConfirmDate")] long sh_ConfirmDate = 0,
      [NameConvert("p_sh_ConfirmDateBegin")] long sh_ConfirmDateBegin = 0,
      [NameConvert("p_sh_ConfirmDateEnd")] long sh_ConfirmDateEnd = 0,
      [NameConvert("p_sh_ConfirmStatus")] int sh_ConfirmStatus = 0,
      [NameConvert("p_sh_StatementType")] int sh_StatementType = 0,
      [NameConvert("p_sh_StatementTypeIn")] string sh_StatementTypeIn = null,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<StatementMonthHorizontalByDeptPack>> horizontalByDeptPack = new UniBizHttpRequest<UbRes<StatementMonthHorizontalByDeptPack>>(HttpMethod.Get);
      horizontalByDeptPack.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sd_SiteID}/Month/Horizontal/Dept/{work_pm_MenuCode}/{work_pmp_PropCode}";
      horizontalByDeptPack.Headers.Add("Send-Type", SendType);
      horizontalByDeptPack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthHorizontalByDeptPack>>, long>((Expression<Func<long>>) (() => sd_SiteID));
      horizontalByDeptPack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      horizontalByDeptPack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByDeptPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sh_ConfirmDate > 0L)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByDeptPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDate));
      if (sh_ConfirmDateBegin > 0L)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByDeptPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateBegin));
      if (sh_ConfirmDateEnd > 0L)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByDeptPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateEnd));
      if (sh_ConfirmStatus > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => sh_ConfirmStatus));
      if (sh_StatementType > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => sh_StatementType));
      if (!string.IsNullOrEmpty(sh_StatementTypeIn))
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByDeptPack>>, string>((Expression<Func<string>>) (() => sh_StatementTypeIn));
      if (si_StoreCode > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByDeptPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByDeptPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByDeptPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByDeptPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByDeptPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByDeptPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByDeptPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByDeptPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByDeptPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByDeptPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByDeptPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByDeptPack>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        horizontalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByDeptPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      horizontalByDeptPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<StatementMonthHorizontalByDeptPack>>>(MethodBase.GetCurrentMethod());
      return horizontalByDeptPack;
    }

    public static UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryTopPack>> GetStatementMonthHorizontalByCategoryTopPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sd_SiteID")] long sd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sh_ConfirmDate")] long sh_ConfirmDate = 0,
      [NameConvert("p_sh_ConfirmDateBegin")] long sh_ConfirmDateBegin = 0,
      [NameConvert("p_sh_ConfirmDateEnd")] long sh_ConfirmDateEnd = 0,
      [NameConvert("p_sh_ConfirmStatus")] int sh_ConfirmStatus = 0,
      [NameConvert("p_sh_StatementType")] int sh_StatementType = 0,
      [NameConvert("p_sh_StatementTypeIn")] string sh_StatementTypeIn = null,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryTopPack>> byCategoryTopPack = new UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryTopPack>>(HttpMethod.Get);
      byCategoryTopPack.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sd_SiteID}/Month/Horizontal/CategoryTop/{work_pm_MenuCode}/{work_pmp_PropCode}";
      byCategoryTopPack.Headers.Add("Send-Type", SendType);
      byCategoryTopPack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryTopPack>>, long>((Expression<Func<long>>) (() => sd_SiteID));
      byCategoryTopPack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      byCategoryTopPack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryTopPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sh_ConfirmDate > 0L)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryTopPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDate));
      if (sh_ConfirmDateBegin > 0L)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryTopPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateBegin));
      if (sh_ConfirmDateEnd > 0L)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryTopPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateEnd));
      if (sh_ConfirmStatus > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => sh_ConfirmStatus));
      if (sh_StatementType > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => sh_StatementType));
      if (!string.IsNullOrEmpty(sh_StatementTypeIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => sh_StatementTypeIn));
      if (si_StoreCode > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryTopPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryTopPack>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      byCategoryTopPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryTopPack>>>(MethodBase.GetCurrentMethod());
      return byCategoryTopPack;
    }

    public static UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryMidPack>> GetStatementMonthHorizontalByCategoryMidPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sd_SiteID")] long sd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sh_ConfirmDate")] long sh_ConfirmDate = 0,
      [NameConvert("p_sh_ConfirmDateBegin")] long sh_ConfirmDateBegin = 0,
      [NameConvert("p_sh_ConfirmDateEnd")] long sh_ConfirmDateEnd = 0,
      [NameConvert("p_sh_ConfirmStatus")] int sh_ConfirmStatus = 0,
      [NameConvert("p_sh_StatementType")] int sh_StatementType = 0,
      [NameConvert("p_sh_StatementTypeIn")] string sh_StatementTypeIn = null,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryMidPack>> byCategoryMidPack = new UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryMidPack>>(HttpMethod.Get);
      byCategoryMidPack.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sd_SiteID}/Month/Horizontal/CategoryMid/{work_pm_MenuCode}/{work_pmp_PropCode}";
      byCategoryMidPack.Headers.Add("Send-Type", SendType);
      byCategoryMidPack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryMidPack>>, long>((Expression<Func<long>>) (() => sd_SiteID));
      byCategoryMidPack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      byCategoryMidPack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryMidPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sh_ConfirmDate > 0L)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryMidPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDate));
      if (sh_ConfirmDateBegin > 0L)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryMidPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateBegin));
      if (sh_ConfirmDateEnd > 0L)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryMidPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateEnd));
      if (sh_ConfirmStatus > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => sh_ConfirmStatus));
      if (sh_StatementType > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => sh_StatementType));
      if (!string.IsNullOrEmpty(sh_StatementTypeIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => sh_StatementTypeIn));
      if (si_StoreCode > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryMidPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryMidPack>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      byCategoryMidPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryMidPack>>>(MethodBase.GetCurrentMethod());
      return byCategoryMidPack;
    }

    public static UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryBotPack>> GetStatementMonthHorizontalByCategoryBotPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sd_SiteID")] long sd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sh_ConfirmDate")] long sh_ConfirmDate = 0,
      [NameConvert("p_sh_ConfirmDateBegin")] long sh_ConfirmDateBegin = 0,
      [NameConvert("p_sh_ConfirmDateEnd")] long sh_ConfirmDateEnd = 0,
      [NameConvert("p_sh_ConfirmStatus")] int sh_ConfirmStatus = 0,
      [NameConvert("p_sh_StatementType")] int sh_StatementType = 0,
      [NameConvert("p_sh_StatementTypeIn")] string sh_StatementTypeIn = null,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryBotPack>> byCategoryBotPack = new UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryBotPack>>(HttpMethod.Get);
      byCategoryBotPack.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sd_SiteID}/Month/Horizontal/CategoryBot/{work_pm_MenuCode}/{work_pmp_PropCode}";
      byCategoryBotPack.Headers.Add("Send-Type", SendType);
      byCategoryBotPack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryBotPack>>, long>((Expression<Func<long>>) (() => sd_SiteID));
      byCategoryBotPack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      byCategoryBotPack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryBotPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sh_ConfirmDate > 0L)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryBotPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDate));
      if (sh_ConfirmDateBegin > 0L)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryBotPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateBegin));
      if (sh_ConfirmDateEnd > 0L)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryBotPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateEnd));
      if (sh_ConfirmStatus > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => sh_ConfirmStatus));
      if (sh_StatementType > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => sh_StatementType));
      if (!string.IsNullOrEmpty(sh_StatementTypeIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => sh_StatementTypeIn));
      if (si_StoreCode > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryBotPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryBotPack>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      byCategoryBotPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<StatementMonthHorizontalByCategoryBotPack>>>(MethodBase.GetCurrentMethod());
      return byCategoryBotPack;
    }

    public static UniBizHttpRequest<UbRes<StatementMonthHorizontalByGoodsPack>> GetStatementMonthHorizontalByGoodsPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sd_SiteID")] long sd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sh_ConfirmDate")] long sh_ConfirmDate = 0,
      [NameConvert("p_sh_ConfirmDateBegin")] long sh_ConfirmDateBegin = 0,
      [NameConvert("p_sh_ConfirmDateEnd")] long sh_ConfirmDateEnd = 0,
      [NameConvert("p_sh_ConfirmStatus")] int sh_ConfirmStatus = 0,
      [NameConvert("p_sh_StatementType")] int sh_StatementType = 0,
      [NameConvert("p_sh_StatementTypeIn")] string sh_StatementTypeIn = null,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<StatementMonthHorizontalByGoodsPack>> horizontalByGoodsPack = new UniBizHttpRequest<UbRes<StatementMonthHorizontalByGoodsPack>>(HttpMethod.Get);
      horizontalByGoodsPack.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sd_SiteID}/Month/Horizontal/Goods/{work_pm_MenuCode}/{work_pmp_PropCode}";
      horizontalByGoodsPack.Headers.Add("Send-Type", SendType);
      horizontalByGoodsPack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthHorizontalByGoodsPack>>, long>((Expression<Func<long>>) (() => sd_SiteID));
      horizontalByGoodsPack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      horizontalByGoodsPack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByGoodsPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sh_ConfirmDate > 0L)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByGoodsPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDate));
      if (sh_ConfirmDateBegin > 0L)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByGoodsPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateBegin));
      if (sh_ConfirmDateEnd > 0L)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByGoodsPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateEnd));
      if (sh_ConfirmStatus > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => sh_ConfirmStatus));
      if (sh_StatementType > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => sh_StatementType));
      if (!string.IsNullOrEmpty(sh_StatementTypeIn))
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByGoodsPack>>, string>((Expression<Func<string>>) (() => sh_StatementTypeIn));
      if (si_StoreCode > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByGoodsPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByGoodsPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByGoodsPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByGoodsPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByGoodsPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByGoodsPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByGoodsPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByGoodsPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByGoodsPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByGoodsPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByGoodsPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByGoodsPack>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        horizontalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalByGoodsPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      horizontalByGoodsPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<StatementMonthHorizontalByGoodsPack>>>(MethodBase.GetCurrentMethod());
      return horizontalByGoodsPack;
    }

    public static UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierPack>> GetStatementMonthHorizontalBySupplierPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sd_SiteID")] long sd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sh_ConfirmDate")] long sh_ConfirmDate = 0,
      [NameConvert("p_sh_ConfirmDateBegin")] long sh_ConfirmDateBegin = 0,
      [NameConvert("p_sh_ConfirmDateEnd")] long sh_ConfirmDateEnd = 0,
      [NameConvert("p_sh_ConfirmStatus")] int sh_ConfirmStatus = 0,
      [NameConvert("p_sh_StatementType")] int sh_StatementType = 0,
      [NameConvert("p_sh_StatementTypeIn")] string sh_StatementTypeIn = null,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierPack>> horizontalBySupplierPack = new UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierPack>>(HttpMethod.Get);
      horizontalBySupplierPack.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sd_SiteID}/Month/Horizontal/Supplier/Store/{work_pm_MenuCode}/{work_pmp_PropCode}";
      horizontalBySupplierPack.Headers.Add("Send-Type", SendType);
      horizontalBySupplierPack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierPack>>, long>((Expression<Func<long>>) (() => sd_SiteID));
      horizontalBySupplierPack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      horizontalBySupplierPack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sh_ConfirmDate > 0L)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDate));
      if (sh_ConfirmDateBegin > 0L)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateBegin));
      if (sh_ConfirmDateEnd > 0L)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateEnd));
      if (sh_ConfirmStatus > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => sh_ConfirmStatus));
      if (sh_StatementType > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => sh_StatementType));
      if (!string.IsNullOrEmpty(sh_StatementTypeIn))
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierPack>>, string>((Expression<Func<string>>) (() => sh_StatementTypeIn));
      if (si_StoreCode > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierPack>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        horizontalBySupplierPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      horizontalBySupplierPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierPack>>>(MethodBase.GetCurrentMethod());
      return horizontalBySupplierPack;
    }

    public static UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatTopPack>> GetStatementMonthHorizontalBySupplierCatTopPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sd_SiteID")] long sd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sh_ConfirmDate")] long sh_ConfirmDate = 0,
      [NameConvert("p_sh_ConfirmDateBegin")] long sh_ConfirmDateBegin = 0,
      [NameConvert("p_sh_ConfirmDateEnd")] long sh_ConfirmDateEnd = 0,
      [NameConvert("p_sh_ConfirmStatus")] int sh_ConfirmStatus = 0,
      [NameConvert("p_sh_StatementType")] int sh_StatementType = 0,
      [NameConvert("p_sh_StatementTypeIn")] string sh_StatementTypeIn = null,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatTopPack>> supplierCatTopPack = new UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatTopPack>>(HttpMethod.Get);
      supplierCatTopPack.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sd_SiteID}/Month/Horizontal/Supplier/CategoryTop/{work_pm_MenuCode}/{work_pmp_PropCode}";
      supplierCatTopPack.Headers.Add("Send-Type", SendType);
      supplierCatTopPack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatTopPack>>, long>((Expression<Func<long>>) (() => sd_SiteID));
      supplierCatTopPack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatTopPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      supplierCatTopPack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatTopPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatTopPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sh_ConfirmDate > 0L)
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatTopPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDate));
      if (sh_ConfirmDateBegin > 0L)
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatTopPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateBegin));
      if (sh_ConfirmDateEnd > 0L)
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatTopPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateEnd));
      if (sh_ConfirmStatus > 0)
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatTopPack>>, int>((Expression<Func<int>>) (() => sh_ConfirmStatus));
      if (sh_StatementType > 0)
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatTopPack>>, int>((Expression<Func<int>>) (() => sh_StatementType));
      if (!string.IsNullOrEmpty(sh_StatementTypeIn))
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatTopPack>>, string>((Expression<Func<string>>) (() => sh_StatementTypeIn));
      if (si_StoreCode > 0)
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatTopPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatTopPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatTopPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatTopPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatTopPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatTopPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatTopPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatTopPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatTopPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatTopPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatTopPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatTopPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatTopPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatTopPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatTopPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatTopPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatTopPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatTopPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatTopPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatTopPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatTopPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatTopPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatTopPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatTopPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatTopPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatTopPack>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        supplierCatTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatTopPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      supplierCatTopPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatTopPack>>>(MethodBase.GetCurrentMethod());
      return supplierCatTopPack;
    }

    public static UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatMidPack>> GetStatementMonthHorizontalBySupplierCatMidPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sd_SiteID")] long sd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sh_ConfirmDate")] long sh_ConfirmDate = 0,
      [NameConvert("p_sh_ConfirmDateBegin")] long sh_ConfirmDateBegin = 0,
      [NameConvert("p_sh_ConfirmDateEnd")] long sh_ConfirmDateEnd = 0,
      [NameConvert("p_sh_ConfirmStatus")] int sh_ConfirmStatus = 0,
      [NameConvert("p_sh_StatementType")] int sh_StatementType = 0,
      [NameConvert("p_sh_StatementTypeIn")] string sh_StatementTypeIn = null,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatMidPack>> supplierCatMidPack = new UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatMidPack>>(HttpMethod.Get);
      supplierCatMidPack.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sd_SiteID}/Month/Horizontal/Supplier/CategoryMid/{work_pm_MenuCode}/{work_pmp_PropCode}";
      supplierCatMidPack.Headers.Add("Send-Type", SendType);
      supplierCatMidPack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatMidPack>>, long>((Expression<Func<long>>) (() => sd_SiteID));
      supplierCatMidPack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatMidPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      supplierCatMidPack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatMidPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatMidPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sh_ConfirmDate > 0L)
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatMidPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDate));
      if (sh_ConfirmDateBegin > 0L)
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatMidPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateBegin));
      if (sh_ConfirmDateEnd > 0L)
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatMidPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateEnd));
      if (sh_ConfirmStatus > 0)
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatMidPack>>, int>((Expression<Func<int>>) (() => sh_ConfirmStatus));
      if (sh_StatementType > 0)
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatMidPack>>, int>((Expression<Func<int>>) (() => sh_StatementType));
      if (!string.IsNullOrEmpty(sh_StatementTypeIn))
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatMidPack>>, string>((Expression<Func<string>>) (() => sh_StatementTypeIn));
      if (si_StoreCode > 0)
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatMidPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatMidPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatMidPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatMidPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatMidPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatMidPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatMidPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatMidPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatMidPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatMidPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatMidPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatMidPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatMidPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatMidPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatMidPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatMidPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatMidPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatMidPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatMidPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatMidPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatMidPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatMidPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatMidPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatMidPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatMidPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatMidPack>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        supplierCatMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatMidPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      supplierCatMidPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatMidPack>>>(MethodBase.GetCurrentMethod());
      return supplierCatMidPack;
    }

    public static UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatBotPack>> GetStatementMonthHorizontalBySupplierCatBotPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sd_SiteID")] long sd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sh_ConfirmDate")] long sh_ConfirmDate = 0,
      [NameConvert("p_sh_ConfirmDateBegin")] long sh_ConfirmDateBegin = 0,
      [NameConvert("p_sh_ConfirmDateEnd")] long sh_ConfirmDateEnd = 0,
      [NameConvert("p_sh_ConfirmStatus")] int sh_ConfirmStatus = 0,
      [NameConvert("p_sh_StatementType")] int sh_StatementType = 0,
      [NameConvert("p_sh_StatementTypeIn")] string sh_StatementTypeIn = null,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatBotPack>> supplierCatBotPack = new UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatBotPack>>(HttpMethod.Get);
      supplierCatBotPack.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sd_SiteID}/Month/Horizontal/Supplier/CategoryBot/{work_pm_MenuCode}/{work_pmp_PropCode}";
      supplierCatBotPack.Headers.Add("Send-Type", SendType);
      supplierCatBotPack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatBotPack>>, long>((Expression<Func<long>>) (() => sd_SiteID));
      supplierCatBotPack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatBotPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      supplierCatBotPack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatBotPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatBotPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sh_ConfirmDate > 0L)
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatBotPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDate));
      if (sh_ConfirmDateBegin > 0L)
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatBotPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateBegin));
      if (sh_ConfirmDateEnd > 0L)
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatBotPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateEnd));
      if (sh_ConfirmStatus > 0)
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatBotPack>>, int>((Expression<Func<int>>) (() => sh_ConfirmStatus));
      if (sh_StatementType > 0)
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatBotPack>>, int>((Expression<Func<int>>) (() => sh_StatementType));
      if (!string.IsNullOrEmpty(sh_StatementTypeIn))
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatBotPack>>, string>((Expression<Func<string>>) (() => sh_StatementTypeIn));
      if (si_StoreCode > 0)
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatBotPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatBotPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatBotPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatBotPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatBotPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatBotPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatBotPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatBotPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatBotPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatBotPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatBotPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatBotPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatBotPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatBotPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatBotPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatBotPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatBotPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatBotPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatBotPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatBotPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatBotPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatBotPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatBotPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatBotPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatBotPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatBotPack>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        supplierCatBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatBotPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      supplierCatBotPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierCatBotPack>>>(MethodBase.GetCurrentMethod());
      return supplierCatBotPack;
    }

    public static UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierGoodsPack>> GetStatementMonthHorizontalBySupplierGoodsPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sd_SiteID")] long sd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sh_ConfirmDate")] long sh_ConfirmDate = 0,
      [NameConvert("p_sh_ConfirmDateBegin")] long sh_ConfirmDateBegin = 0,
      [NameConvert("p_sh_ConfirmDateEnd")] long sh_ConfirmDateEnd = 0,
      [NameConvert("p_sh_ConfirmStatus")] int sh_ConfirmStatus = 0,
      [NameConvert("p_sh_StatementType")] int sh_StatementType = 0,
      [NameConvert("p_sh_StatementTypeIn")] string sh_StatementTypeIn = null,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierGoodsPack>> supplierGoodsPack = new UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierGoodsPack>>(HttpMethod.Get);
      supplierGoodsPack.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sd_SiteID}/Month/Horizontal/Supplier/Goods/{work_pm_MenuCode}/{work_pmp_PropCode}";
      supplierGoodsPack.Headers.Add("Send-Type", SendType);
      supplierGoodsPack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierGoodsPack>>, long>((Expression<Func<long>>) (() => sd_SiteID));
      supplierGoodsPack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      supplierGoodsPack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierGoodsPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sh_ConfirmDate > 0L)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierGoodsPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDate));
      if (sh_ConfirmDateBegin > 0L)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierGoodsPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateBegin));
      if (sh_ConfirmDateEnd > 0L)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierGoodsPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateEnd));
      if (sh_ConfirmStatus > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => sh_ConfirmStatus));
      if (sh_StatementType > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => sh_StatementType));
      if (!string.IsNullOrEmpty(sh_StatementTypeIn))
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierGoodsPack>>, string>((Expression<Func<string>>) (() => sh_StatementTypeIn));
      if (si_StoreCode > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierGoodsPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierGoodsPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierGoodsPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierGoodsPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierGoodsPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierGoodsPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierGoodsPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierGoodsPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierGoodsPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierGoodsPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierGoodsPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierGoodsPack>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        supplierGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierGoodsPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      supplierGoodsPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<StatementMonthHorizontalBySupplierGoodsPack>>>(MethodBase.GetCurrentMethod());
      return supplierGoodsPack;
    }

    public static UniBizHttpRequest<UbRes<StatementMonthVerticalByStorePack>> GetStatementMonthVerticalByStorePack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sd_SiteID")] long sd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sh_ConfirmDate")] long sh_ConfirmDate = 0,
      [NameConvert("p_sh_ConfirmDateBegin")] long sh_ConfirmDateBegin = 0,
      [NameConvert("p_sh_ConfirmDateEnd")] long sh_ConfirmDateEnd = 0,
      [NameConvert("p_sh_ConfirmStatus")] int sh_ConfirmStatus = 0,
      [NameConvert("p_sh_StatementType")] int sh_StatementType = 0,
      [NameConvert("p_sh_StatementTypeIn")] string sh_StatementTypeIn = null,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<StatementMonthVerticalByStorePack>> verticalByStorePack = new UniBizHttpRequest<UbRes<StatementMonthVerticalByStorePack>>(HttpMethod.Get);
      verticalByStorePack.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sd_SiteID}/Month/Vertical/Store/{work_pm_MenuCode}/{work_pmp_PropCode}";
      verticalByStorePack.Headers.Add("Send-Type", SendType);
      verticalByStorePack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthVerticalByStorePack>>, long>((Expression<Func<long>>) (() => sd_SiteID));
      verticalByStorePack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthVerticalByStorePack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      verticalByStorePack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthVerticalByStorePack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByStorePack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sh_ConfirmDate > 0L)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByStorePack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDate));
      if (sh_ConfirmDateBegin > 0L)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByStorePack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateBegin));
      if (sh_ConfirmDateEnd > 0L)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByStorePack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateEnd));
      if (sh_ConfirmStatus > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByStorePack>>, int>((Expression<Func<int>>) (() => sh_ConfirmStatus));
      if (sh_StatementType > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByStorePack>>, int>((Expression<Func<int>>) (() => sh_StatementType));
      if (!string.IsNullOrEmpty(sh_StatementTypeIn))
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByStorePack>>, string>((Expression<Func<string>>) (() => sh_StatementTypeIn));
      if (si_StoreCode > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByStorePack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByStorePack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByStorePack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByStorePack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByStorePack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByStorePack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByStorePack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByStorePack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByStorePack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByStorePack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByStorePack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByStorePack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByStorePack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByStorePack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByStorePack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByStorePack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByStorePack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByStorePack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByStorePack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByStorePack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByStorePack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByStorePack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByStorePack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByStorePack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByStorePack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByStorePack>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        verticalByStorePack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByStorePack>>, string>((Expression<Func<string>>) (() => KeyWord));
      verticalByStorePack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<StatementMonthVerticalByStorePack>>>(MethodBase.GetCurrentMethod());
      return verticalByStorePack;
    }

    public static UniBizHttpRequest<UbRes<StatementMonthVerticalByTeamPack>> GetStatementMonthVerticalByTeamPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sd_SiteID")] long sd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sh_ConfirmDate")] long sh_ConfirmDate = 0,
      [NameConvert("p_sh_ConfirmDateBegin")] long sh_ConfirmDateBegin = 0,
      [NameConvert("p_sh_ConfirmDateEnd")] long sh_ConfirmDateEnd = 0,
      [NameConvert("p_sh_ConfirmStatus")] int sh_ConfirmStatus = 0,
      [NameConvert("p_sh_StatementType")] int sh_StatementType = 0,
      [NameConvert("p_sh_StatementTypeIn")] string sh_StatementTypeIn = null,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<StatementMonthVerticalByTeamPack>> verticalByTeamPack = new UniBizHttpRequest<UbRes<StatementMonthVerticalByTeamPack>>(HttpMethod.Get);
      verticalByTeamPack.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sd_SiteID}/Month/Vertical/Team/{work_pm_MenuCode}/{work_pmp_PropCode}";
      verticalByTeamPack.Headers.Add("Send-Type", SendType);
      verticalByTeamPack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthVerticalByTeamPack>>, long>((Expression<Func<long>>) (() => sd_SiteID));
      verticalByTeamPack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      verticalByTeamPack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByTeamPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sh_ConfirmDate > 0L)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByTeamPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDate));
      if (sh_ConfirmDateBegin > 0L)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByTeamPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateBegin));
      if (sh_ConfirmDateEnd > 0L)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByTeamPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateEnd));
      if (sh_ConfirmStatus > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => sh_ConfirmStatus));
      if (sh_StatementType > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => sh_StatementType));
      if (!string.IsNullOrEmpty(sh_StatementTypeIn))
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByTeamPack>>, string>((Expression<Func<string>>) (() => sh_StatementTypeIn));
      if (si_StoreCode > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByTeamPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByTeamPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByTeamPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByTeamPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByTeamPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByTeamPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByTeamPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByTeamPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByTeamPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByTeamPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByTeamPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByTeamPack>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        verticalByTeamPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByTeamPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      verticalByTeamPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<StatementMonthVerticalByTeamPack>>>(MethodBase.GetCurrentMethod());
      return verticalByTeamPack;
    }

    public static UniBizHttpRequest<UbRes<StatementMonthVerticalByDeptPack>> GetStatementMonthVerticalByDeptPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sd_SiteID")] long sd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sh_ConfirmDate")] long sh_ConfirmDate = 0,
      [NameConvert("p_sh_ConfirmDateBegin")] long sh_ConfirmDateBegin = 0,
      [NameConvert("p_sh_ConfirmDateEnd")] long sh_ConfirmDateEnd = 0,
      [NameConvert("p_sh_ConfirmStatus")] int sh_ConfirmStatus = 0,
      [NameConvert("p_sh_StatementType")] int sh_StatementType = 0,
      [NameConvert("p_sh_StatementTypeIn")] string sh_StatementTypeIn = null,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<StatementMonthVerticalByDeptPack>> verticalByDeptPack = new UniBizHttpRequest<UbRes<StatementMonthVerticalByDeptPack>>(HttpMethod.Get);
      verticalByDeptPack.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sd_SiteID}/Month/Vertical/Dept/{work_pm_MenuCode}/{work_pmp_PropCode}";
      verticalByDeptPack.Headers.Add("Send-Type", SendType);
      verticalByDeptPack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthVerticalByDeptPack>>, long>((Expression<Func<long>>) (() => sd_SiteID));
      verticalByDeptPack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      verticalByDeptPack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByDeptPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sh_ConfirmDate > 0L)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByDeptPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDate));
      if (sh_ConfirmDateBegin > 0L)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByDeptPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateBegin));
      if (sh_ConfirmDateEnd > 0L)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByDeptPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateEnd));
      if (sh_ConfirmStatus > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => sh_ConfirmStatus));
      if (sh_StatementType > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => sh_StatementType));
      if (!string.IsNullOrEmpty(sh_StatementTypeIn))
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByDeptPack>>, string>((Expression<Func<string>>) (() => sh_StatementTypeIn));
      if (si_StoreCode > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByDeptPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByDeptPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByDeptPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByDeptPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByDeptPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByDeptPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByDeptPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByDeptPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByDeptPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByDeptPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByDeptPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByDeptPack>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        verticalByDeptPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByDeptPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      verticalByDeptPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<StatementMonthVerticalByDeptPack>>>(MethodBase.GetCurrentMethod());
      return verticalByDeptPack;
    }

    public static UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryTopPack>> GetStatementMonthVerticalByCategoryTopPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sd_SiteID")] long sd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sh_ConfirmDate")] long sh_ConfirmDate = 0,
      [NameConvert("p_sh_ConfirmDateBegin")] long sh_ConfirmDateBegin = 0,
      [NameConvert("p_sh_ConfirmDateEnd")] long sh_ConfirmDateEnd = 0,
      [NameConvert("p_sh_ConfirmStatus")] int sh_ConfirmStatus = 0,
      [NameConvert("p_sh_StatementType")] int sh_StatementType = 0,
      [NameConvert("p_sh_StatementTypeIn")] string sh_StatementTypeIn = null,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryTopPack>> byCategoryTopPack = new UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryTopPack>>(HttpMethod.Get);
      byCategoryTopPack.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sd_SiteID}/Month/Vertical/CategoryTop/{work_pm_MenuCode}/{work_pmp_PropCode}";
      byCategoryTopPack.Headers.Add("Send-Type", SendType);
      byCategoryTopPack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryTopPack>>, long>((Expression<Func<long>>) (() => sd_SiteID));
      byCategoryTopPack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      byCategoryTopPack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryTopPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sh_ConfirmDate > 0L)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryTopPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDate));
      if (sh_ConfirmDateBegin > 0L)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryTopPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateBegin));
      if (sh_ConfirmDateEnd > 0L)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryTopPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateEnd));
      if (sh_ConfirmStatus > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => sh_ConfirmStatus));
      if (sh_StatementType > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => sh_StatementType));
      if (!string.IsNullOrEmpty(sh_StatementTypeIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => sh_StatementTypeIn));
      if (si_StoreCode > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryTopPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryTopPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryTopPack>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        byCategoryTopPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryTopPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      byCategoryTopPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryTopPack>>>(MethodBase.GetCurrentMethod());
      return byCategoryTopPack;
    }

    public static UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryMidPack>> GetStatementMonthVerticalByCategoryMidPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sd_SiteID")] long sd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sh_ConfirmDate")] long sh_ConfirmDate = 0,
      [NameConvert("p_sh_ConfirmDateBegin")] long sh_ConfirmDateBegin = 0,
      [NameConvert("p_sh_ConfirmDateEnd")] long sh_ConfirmDateEnd = 0,
      [NameConvert("p_sh_ConfirmStatus")] int sh_ConfirmStatus = 0,
      [NameConvert("p_sh_StatementType")] int sh_StatementType = 0,
      [NameConvert("p_sh_StatementTypeIn")] string sh_StatementTypeIn = null,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryMidPack>> byCategoryMidPack = new UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryMidPack>>(HttpMethod.Get);
      byCategoryMidPack.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sd_SiteID}/Month/Vertical/CategoryMid/{work_pm_MenuCode}/{work_pmp_PropCode}";
      byCategoryMidPack.Headers.Add("Send-Type", SendType);
      byCategoryMidPack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryMidPack>>, long>((Expression<Func<long>>) (() => sd_SiteID));
      byCategoryMidPack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      byCategoryMidPack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryMidPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sh_ConfirmDate > 0L)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryMidPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDate));
      if (sh_ConfirmDateBegin > 0L)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryMidPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateBegin));
      if (sh_ConfirmDateEnd > 0L)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryMidPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateEnd));
      if (sh_ConfirmStatus > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => sh_ConfirmStatus));
      if (sh_StatementType > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => sh_StatementType));
      if (!string.IsNullOrEmpty(sh_StatementTypeIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => sh_StatementTypeIn));
      if (si_StoreCode > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryMidPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryMidPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryMidPack>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        byCategoryMidPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryMidPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      byCategoryMidPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryMidPack>>>(MethodBase.GetCurrentMethod());
      return byCategoryMidPack;
    }

    public static UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryBotPack>> GetStatementMonthVerticalByCategoryBotPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sd_SiteID")] long sd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sh_ConfirmDate")] long sh_ConfirmDate = 0,
      [NameConvert("p_sh_ConfirmDateBegin")] long sh_ConfirmDateBegin = 0,
      [NameConvert("p_sh_ConfirmDateEnd")] long sh_ConfirmDateEnd = 0,
      [NameConvert("p_sh_ConfirmStatus")] int sh_ConfirmStatus = 0,
      [NameConvert("p_sh_StatementType")] int sh_StatementType = 0,
      [NameConvert("p_sh_StatementTypeIn")] string sh_StatementTypeIn = null,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryBotPack>> byCategoryBotPack = new UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryBotPack>>(HttpMethod.Get);
      byCategoryBotPack.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sd_SiteID}/Month/Vertical/CategoryBot/{work_pm_MenuCode}/{work_pmp_PropCode}";
      byCategoryBotPack.Headers.Add("Send-Type", SendType);
      byCategoryBotPack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryBotPack>>, long>((Expression<Func<long>>) (() => sd_SiteID));
      byCategoryBotPack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      byCategoryBotPack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryBotPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sh_ConfirmDate > 0L)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryBotPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDate));
      if (sh_ConfirmDateBegin > 0L)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryBotPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateBegin));
      if (sh_ConfirmDateEnd > 0L)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryBotPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateEnd));
      if (sh_ConfirmStatus > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => sh_ConfirmStatus));
      if (sh_StatementType > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => sh_StatementType));
      if (!string.IsNullOrEmpty(sh_StatementTypeIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => sh_StatementTypeIn));
      if (si_StoreCode > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryBotPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryBotPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryBotPack>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        byCategoryBotPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryBotPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      byCategoryBotPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<StatementMonthVerticalByCategoryBotPack>>>(MethodBase.GetCurrentMethod());
      return byCategoryBotPack;
    }

    public static UniBizHttpRequest<UbRes<StatementMonthVerticalByGoodsPack>> GetStatementMonthVerticalByGoodsPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sd_SiteID")] long sd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sh_ConfirmDate")] long sh_ConfirmDate = 0,
      [NameConvert("p_sh_ConfirmDateBegin")] long sh_ConfirmDateBegin = 0,
      [NameConvert("p_sh_ConfirmDateEnd")] long sh_ConfirmDateEnd = 0,
      [NameConvert("p_sh_ConfirmStatus")] int sh_ConfirmStatus = 0,
      [NameConvert("p_sh_StatementType")] int sh_StatementType = 0,
      [NameConvert("p_sh_StatementTypeIn")] string sh_StatementTypeIn = null,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<StatementMonthVerticalByGoodsPack>> verticalByGoodsPack = new UniBizHttpRequest<UbRes<StatementMonthVerticalByGoodsPack>>(HttpMethod.Get);
      verticalByGoodsPack.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sd_SiteID}/Month/Vertical/Goods/{work_pm_MenuCode}/{work_pmp_PropCode}";
      verticalByGoodsPack.Headers.Add("Send-Type", SendType);
      verticalByGoodsPack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthVerticalByGoodsPack>>, long>((Expression<Func<long>>) (() => sd_SiteID));
      verticalByGoodsPack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      verticalByGoodsPack.SetSegment<UniBizHttpRequest<UbRes<StatementMonthVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByGoodsPack>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sh_ConfirmDate > 0L)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByGoodsPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDate));
      if (sh_ConfirmDateBegin > 0L)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByGoodsPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateBegin));
      if (sh_ConfirmDateEnd > 0L)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByGoodsPack>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateEnd));
      if (sh_ConfirmStatus > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => sh_ConfirmStatus));
      if (sh_StatementType > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => sh_StatementType));
      if (!string.IsNullOrEmpty(sh_StatementTypeIn))
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByGoodsPack>>, string>((Expression<Func<string>>) (() => sh_StatementTypeIn));
      if (si_StoreCode > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByGoodsPack>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByGoodsPack>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByGoodsPack>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByGoodsPack>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByGoodsPack>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByGoodsPack>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByGoodsPack>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByGoodsPack>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByGoodsPack>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByGoodsPack>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByGoodsPack>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByGoodsPack>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        verticalByGoodsPack.SetQuery<UniBizHttpRequest<UbRes<StatementMonthVerticalByGoodsPack>>, string>((Expression<Func<string>>) (() => KeyWord));
      verticalByGoodsPack.ReplaceByNameConverter<UniBizHttpRequest<UbRes<StatementMonthVerticalByGoodsPack>>>(MethodBase.GetCurrentMethod());
      return verticalByGoodsPack;
    }

    public static UniBizHttpRequest<UbRes<StatementHeaderView>> GetOrder(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sh_SiteID")] long sh_SiteID,
      [NameConvert("p_sh_StatementNo")] long sh_StatementNo,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_isStatementDetails")] bool isStatementDetails = true)
    {
      UniBizHttpRequest<UbRes<StatementHeaderView>> order = new UniBizHttpRequest<UbRes<StatementHeaderView>>(HttpMethod.Get);
      order.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/Order/{sh_SiteID}/{sh_StatementNo}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      order.Headers.Add("Send-Type", SendType);
      order.SetSegment<UniBizHttpRequest<UbRes<StatementHeaderView>>, long>((Expression<Func<long>>) (() => sh_SiteID));
      order.SetSegment<UniBizHttpRequest<UbRes<StatementHeaderView>>, long>((Expression<Func<long>>) (() => sh_StatementNo));
      order.SetSegment<UniBizHttpRequest<UbRes<StatementHeaderView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      order.SetSegment<UniBizHttpRequest<UbRes<StatementHeaderView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      order.SetQuery<UniBizHttpRequest<UbRes<StatementHeaderView>>, bool>((Expression<Func<bool>>) (() => isStatementDetails));
      order.ReplaceByNameConverter<UniBizHttpRequest<UbRes<StatementHeaderView>>>(MethodBase.GetCurrentMethod());
      return order;
    }

    public static UniBizHttpRequest<UbRes<StatementHeaderView>> PostOrder(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sh_SiteID")] long sh_SiteID,
      [NameConvert("p_sh_StatementNo")] long sh_StatementNo,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      StatementHeaderView pData)
    {
      UniBizHttpRequest<UbRes<StatementHeaderView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<StatementHeaderView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/Order/{sh_SiteID}/{sh_StatementNo}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<StatementHeaderView>>, long>((Expression<Func<long>>) (() => sh_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<StatementHeaderView>>, long>((Expression<Func<long>>) (() => sh_StatementNo));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<StatementHeaderView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<StatementHeaderView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<StatementHeaderView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<StatementHeaderView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<StatementHeaderView>>> GetOrderList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sh_SiteID")] long sh_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_sh_StatementNo")] long sh_StatementNo = 0,
      [NameConvert("p_is_sh_OrderDate")] bool is_sh_OrderDate = true,
      [NameConvert("p_StartDate")] long StartDate = 0,
      [NameConvert("p_EndDate")] long EndDate = 0,
      [NameConvert("p_sh_OrderStatus")] int sh_OrderStatus = 0,
      [NameConvert("p_sh_StatementType")] int sh_StatementType = 0,
      [NameConvert("p_sh_StatementTypeIn")] string sh_StatementTypeIn = null,
      [NameConvert("p_sh_InOutDiv")] int sh_InOutDiv = 0,
      [NameConvert("p_sh_ConfirmStatus")] int sh_ConfirmStatus = 0,
      [NameConvert("p_sh_DeviceType")] int sh_DeviceType = 0,
      [NameConvert("p_sh_AssignUser")] int sh_AssignUser = 0,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_emp_Code")] int emp_Code = 0,
      [NameConvert("p_isDetails")] bool isDetails = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<StatementHeaderView>>> orderList = new UniBizHttpRequest<UbRes<IList<StatementHeaderView>>>(HttpMethod.Get);
      orderList.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/Order/{sh_SiteID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      orderList.Headers.Add("Send-Type", SendType);
      orderList.SetSegment<UniBizHttpRequest<UbRes<IList<StatementHeaderView>>>, long>((Expression<Func<long>>) (() => sh_SiteID));
      orderList.SetSegment<UniBizHttpRequest<UbRes<IList<StatementHeaderView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      orderList.SetSegment<UniBizHttpRequest<UbRes<IList<StatementHeaderView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (sh_StatementNo > 0L)
        orderList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementHeaderView>>>, long>((Expression<Func<long>>) (() => sh_StatementNo));
      orderList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementHeaderView>>>, bool>((Expression<Func<bool>>) (() => is_sh_OrderDate));
      if (StartDate > 0L)
        orderList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementHeaderView>>>, long>((Expression<Func<long>>) (() => StartDate));
      if (EndDate > 0L)
        orderList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementHeaderView>>>, long>((Expression<Func<long>>) (() => EndDate));
      if (sh_OrderStatus > 0)
        orderList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementHeaderView>>>, int>((Expression<Func<int>>) (() => sh_OrderStatus));
      if (sh_StatementType > 0)
        orderList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementHeaderView>>>, int>((Expression<Func<int>>) (() => sh_StatementType));
      if (!string.IsNullOrEmpty(sh_StatementTypeIn))
        orderList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementHeaderView>>>, string>((Expression<Func<string>>) (() => sh_StatementTypeIn));
      if (sh_InOutDiv > 0)
        orderList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementHeaderView>>>, int>((Expression<Func<int>>) (() => sh_InOutDiv));
      if (sh_ConfirmStatus > 0)
        orderList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementHeaderView>>>, int>((Expression<Func<int>>) (() => sh_ConfirmStatus));
      if (sh_DeviceType > 0)
        orderList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementHeaderView>>>, int>((Expression<Func<int>>) (() => sh_DeviceType));
      if (sh_AssignUser > 0)
        orderList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementHeaderView>>>, int>((Expression<Func<int>>) (() => sh_AssignUser));
      if (si_StoreCode > 0)
        orderList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementHeaderView>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
        orderList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementHeaderView>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
      if (su_Supplier > 0)
        orderList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementHeaderView>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        orderList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementHeaderView>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (emp_Code > 0)
        orderList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementHeaderView>>>, int>((Expression<Func<int>>) (() => emp_Code));
      orderList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementHeaderView>>>, bool>((Expression<Func<bool>>) (() => isDetails));
      if (!string.IsNullOrEmpty(KeyWord))
        orderList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementHeaderView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      orderList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<StatementHeaderView>>>>(MethodBase.GetCurrentMethod());
      return orderList;
    }

    public static UniBizHttpRequest<UbRes<JobEvtStatementHeader>> PostOrderList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sh_SiteID")] long sh_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      JobEvtStatementHeader pData)
    {
      UniBizHttpRequest<UbRes<JobEvtStatementHeader>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<JobEvtStatementHeader>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/Order/{sh_SiteID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<JobEvtStatementHeader>>, long>((Expression<Func<long>>) (() => sh_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<JobEvtStatementHeader>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<JobEvtStatementHeader>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<JobEvtStatementHeader>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<JobEvtStatementHeader>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<bool>> DeleteOrderList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sh_SiteID")] long sh_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      string p_JobID)
    {
      UniBizHttpRequest<UbRes<bool>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<bool>>(HttpMethod.Delete);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/Order/{sh_SiteID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<bool>>, long>((Expression<Func<long>>) (() => sh_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<bool>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<bool>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<string>(p_JobID, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<bool>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<JobEvtStatementHeader>> PutOrderStatusList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sh_SiteID")] long sh_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      JobEvtStatementHeader pData)
    {
      UniBizHttpRequest<UbRes<JobEvtStatementHeader>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<JobEvtStatementHeader>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/Order/{sh_SiteID}/Status/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<JobEvtStatementHeader>>, long>((Expression<Func<long>>) (() => sh_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<JobEvtStatementHeader>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<JobEvtStatementHeader>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<JobEvtStatementHeader>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<JobEvtStatementHeader>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<bool>> DeleteOrderStatusList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sh_SiteID")] long sh_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      string p_JobID)
    {
      UniBizHttpRequest<UbRes<bool>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<bool>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/Order/{sh_SiteID}/Status/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<bool>>, long>((Expression<Func<long>>) (() => sh_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<bool>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<bool>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<string>(p_JobID, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<bool>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<StatementSupplierDate>>> GetStatementSupplierDateList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sd_SiteID")] long sd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sh_ConfirmDate")] long sh_ConfirmDate = 0,
      [NameConvert("p_sh_ConfirmDateBegin")] long sh_ConfirmDateBegin = 0,
      [NameConvert("p_sh_ConfirmDateEnd")] long sh_ConfirmDateEnd = 0,
      [NameConvert("p_sh_ConfirmStatus")] int sh_ConfirmStatus = 0,
      [NameConvert("p_sh_StatementType")] int sh_StatementType = 0,
      [NameConvert("p_sh_StatementTypeIn")] string sh_StatementTypeIn = null,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<StatementSupplierDate>>> supplierDateList = new UniBizHttpRequest<UbRes<IList<StatementSupplierDate>>>(HttpMethod.Get);
      supplierDateList.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sd_SiteID}/Supplier/Date/{work_pm_MenuCode}/{work_pmp_PropCode}";
      supplierDateList.Headers.Add("Send-Type", SendType);
      supplierDateList.SetSegment<UniBizHttpRequest<UbRes<IList<StatementSupplierDate>>>, long>((Expression<Func<long>>) (() => sd_SiteID));
      supplierDateList.SetSegment<UniBizHttpRequest<UbRes<IList<StatementSupplierDate>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      supplierDateList.SetSegment<UniBizHttpRequest<UbRes<IList<StatementSupplierDate>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      supplierDateList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDate>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sh_ConfirmDate > 0L)
        supplierDateList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDate>>>, long>((Expression<Func<long>>) (() => sh_ConfirmDate));
      if (sh_ConfirmDateBegin > 0L)
        supplierDateList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDate>>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateBegin));
      if (sh_ConfirmDateEnd > 0L)
        supplierDateList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDate>>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateEnd));
      if (sh_ConfirmStatus > 0)
        supplierDateList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDate>>>, int>((Expression<Func<int>>) (() => sh_ConfirmStatus));
      if (sh_StatementType > 0)
        supplierDateList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDate>>>, int>((Expression<Func<int>>) (() => sh_StatementType));
      if (!string.IsNullOrEmpty(sh_StatementTypeIn))
        supplierDateList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDate>>>, string>((Expression<Func<string>>) (() => sh_StatementTypeIn));
      if (si_StoreCode > 0)
        supplierDateList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDate>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        supplierDateList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDate>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        supplierDateList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDate>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        supplierDateList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDate>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        supplierDateList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDate>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        supplierDateList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDate>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        supplierDateList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDate>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        supplierDateList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDate>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        supplierDateList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDate>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        supplierDateList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDate>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        supplierDateList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDate>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        supplierDateList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDate>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        supplierDateList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDate>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        supplierDateList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDate>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        supplierDateList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDate>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        supplierDateList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDate>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        supplierDateList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDate>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        supplierDateList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDate>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        supplierDateList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDate>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        supplierDateList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDate>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        supplierDateList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDate>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        supplierDateList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDate>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        supplierDateList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDate>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        supplierDateList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDate>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        supplierDateList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDate>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      supplierDateList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDate>>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        supplierDateList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDate>>>, string>((Expression<Func<string>>) (() => KeyWord));
      supplierDateList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<StatementSupplierDate>>>>(MethodBase.GetCurrentMethod());
      return supplierDateList;
    }

    public static UniBizHttpRequest<UbRes<IList<StatementSupplierGoods>>> GetStatementSupplierGoodsList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sd_SiteID")] long sd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sh_ConfirmDate")] long sh_ConfirmDate = 0,
      [NameConvert("p_sh_ConfirmDateBegin")] long sh_ConfirmDateBegin = 0,
      [NameConvert("p_sh_ConfirmDateEnd")] long sh_ConfirmDateEnd = 0,
      [NameConvert("p_sh_ConfirmStatus")] int sh_ConfirmStatus = 0,
      [NameConvert("p_sh_StatementType")] int sh_StatementType = 0,
      [NameConvert("p_sh_StatementTypeIn")] string sh_StatementTypeIn = null,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<StatementSupplierGoods>>> supplierGoodsList = new UniBizHttpRequest<UbRes<IList<StatementSupplierGoods>>>(HttpMethod.Get);
      supplierGoodsList.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sd_SiteID}/Supplier/Goods/{work_pm_MenuCode}/{work_pmp_PropCode}";
      supplierGoodsList.Headers.Add("Send-Type", SendType);
      supplierGoodsList.SetSegment<UniBizHttpRequest<UbRes<IList<StatementSupplierGoods>>>, long>((Expression<Func<long>>) (() => sd_SiteID));
      supplierGoodsList.SetSegment<UniBizHttpRequest<UbRes<IList<StatementSupplierGoods>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      supplierGoodsList.SetSegment<UniBizHttpRequest<UbRes<IList<StatementSupplierGoods>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierGoods>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sh_ConfirmDate > 0L)
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierGoods>>>, long>((Expression<Func<long>>) (() => sh_ConfirmDate));
      if (sh_ConfirmDateBegin > 0L)
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierGoods>>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateBegin));
      if (sh_ConfirmDateEnd > 0L)
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierGoods>>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateEnd));
      if (sh_ConfirmStatus > 0)
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierGoods>>>, int>((Expression<Func<int>>) (() => sh_ConfirmStatus));
      if (sh_StatementType > 0)
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierGoods>>>, int>((Expression<Func<int>>) (() => sh_StatementType));
      if (!string.IsNullOrEmpty(sh_StatementTypeIn))
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierGoods>>>, string>((Expression<Func<string>>) (() => sh_StatementTypeIn));
      if (si_StoreCode > 0)
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierGoods>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierGoods>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierGoods>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierGoods>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierGoods>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierGoods>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierGoods>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierGoods>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierGoods>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierGoods>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierGoods>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierGoods>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierGoods>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierGoods>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierGoods>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierGoods>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierGoods>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierGoods>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierGoods>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierGoods>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierGoods>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierGoods>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierGoods>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierGoods>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierGoods>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierGoods>>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        supplierGoodsList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierGoods>>>, string>((Expression<Func<string>>) (() => KeyWord));
      supplierGoodsList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<StatementSupplierGoods>>>>(MethodBase.GetCurrentMethod());
      return supplierGoodsList;
    }

    public static UniBizHttpRequest<UbRes<IList<StatementSupplierDay>>> GetStatementSupplierDayList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sd_SiteID")] long sd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sh_ConfirmDate")] long sh_ConfirmDate = 0,
      [NameConvert("p_sh_ConfirmDateBegin")] long sh_ConfirmDateBegin = 0,
      [NameConvert("p_sh_ConfirmDateEnd")] long sh_ConfirmDateEnd = 0,
      [NameConvert("p_sh_ConfirmStatus")] int sh_ConfirmStatus = 0,
      [NameConvert("p_sh_StatementType")] int sh_StatementType = 0,
      [NameConvert("p_sh_StatementTypeIn")] string sh_StatementTypeIn = null,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<StatementSupplierDay>>> statementSupplierDayList = new UniBizHttpRequest<UbRes<IList<StatementSupplierDay>>>(HttpMethod.Get);
      statementSupplierDayList.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sd_SiteID}/Supplier/Day/{work_pm_MenuCode}/{work_pmp_PropCode}";
      statementSupplierDayList.Headers.Add("Send-Type", SendType);
      statementSupplierDayList.SetSegment<UniBizHttpRequest<UbRes<IList<StatementSupplierDay>>>, long>((Expression<Func<long>>) (() => sd_SiteID));
      statementSupplierDayList.SetSegment<UniBizHttpRequest<UbRes<IList<StatementSupplierDay>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      statementSupplierDayList.SetSegment<UniBizHttpRequest<UbRes<IList<StatementSupplierDay>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      statementSupplierDayList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDay>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sh_ConfirmDate > 0L)
        statementSupplierDayList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDay>>>, long>((Expression<Func<long>>) (() => sh_ConfirmDate));
      if (sh_ConfirmDateBegin > 0L)
        statementSupplierDayList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDay>>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateBegin));
      if (sh_ConfirmDateEnd > 0L)
        statementSupplierDayList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDay>>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateEnd));
      if (sh_ConfirmStatus > 0)
        statementSupplierDayList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDay>>>, int>((Expression<Func<int>>) (() => sh_ConfirmStatus));
      if (sh_StatementType > 0)
        statementSupplierDayList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDay>>>, int>((Expression<Func<int>>) (() => sh_StatementType));
      if (!string.IsNullOrEmpty(sh_StatementTypeIn))
        statementSupplierDayList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDay>>>, string>((Expression<Func<string>>) (() => sh_StatementTypeIn));
      if (si_StoreCode > 0)
        statementSupplierDayList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDay>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        statementSupplierDayList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDay>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        statementSupplierDayList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDay>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        statementSupplierDayList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDay>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        statementSupplierDayList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDay>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        statementSupplierDayList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDay>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        statementSupplierDayList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDay>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        statementSupplierDayList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDay>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        statementSupplierDayList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDay>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        statementSupplierDayList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDay>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        statementSupplierDayList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDay>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        statementSupplierDayList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDay>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        statementSupplierDayList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDay>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        statementSupplierDayList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDay>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        statementSupplierDayList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDay>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        statementSupplierDayList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDay>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        statementSupplierDayList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDay>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        statementSupplierDayList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDay>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        statementSupplierDayList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDay>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        statementSupplierDayList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDay>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        statementSupplierDayList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDay>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        statementSupplierDayList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDay>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        statementSupplierDayList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDay>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        statementSupplierDayList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDay>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        statementSupplierDayList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDay>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      statementSupplierDayList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDay>>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        statementSupplierDayList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierDay>>>, string>((Expression<Func<string>>) (() => KeyWord));
      statementSupplierDayList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<StatementSupplierDay>>>>(MethodBase.GetCurrentMethod());
      return statementSupplierDayList;
    }

    public static UniBizHttpRequest<UbRes<IList<StatementSupplierStatement>>> GetStatementSupplierStatementList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sd_SiteID")] long sd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sh_ConfirmDate")] long sh_ConfirmDate = 0,
      [NameConvert("p_sh_ConfirmDateBegin")] long sh_ConfirmDateBegin = 0,
      [NameConvert("p_sh_ConfirmDateEnd")] long sh_ConfirmDateEnd = 0,
      [NameConvert("p_sh_ConfirmStatus")] int sh_ConfirmStatus = 0,
      [NameConvert("p_sh_StatementType")] int sh_StatementType = 0,
      [NameConvert("p_sh_StatementTypeIn")] string sh_StatementTypeIn = null,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<StatementSupplierStatement>>> supplierStatementList = new UniBizHttpRequest<UbRes<IList<StatementSupplierStatement>>>(HttpMethod.Get);
      supplierStatementList.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sd_SiteID}/Supplier/Statement/{work_pm_MenuCode}/{work_pmp_PropCode}";
      supplierStatementList.Headers.Add("Send-Type", SendType);
      supplierStatementList.SetSegment<UniBizHttpRequest<UbRes<IList<StatementSupplierStatement>>>, long>((Expression<Func<long>>) (() => sd_SiteID));
      supplierStatementList.SetSegment<UniBizHttpRequest<UbRes<IList<StatementSupplierStatement>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      supplierStatementList.SetSegment<UniBizHttpRequest<UbRes<IList<StatementSupplierStatement>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      supplierStatementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatement>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sh_ConfirmDate > 0L)
        supplierStatementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatement>>>, long>((Expression<Func<long>>) (() => sh_ConfirmDate));
      if (sh_ConfirmDateBegin > 0L)
        supplierStatementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatement>>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateBegin));
      if (sh_ConfirmDateEnd > 0L)
        supplierStatementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatement>>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateEnd));
      if (sh_ConfirmStatus > 0)
        supplierStatementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatement>>>, int>((Expression<Func<int>>) (() => sh_ConfirmStatus));
      if (sh_StatementType > 0)
        supplierStatementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatement>>>, int>((Expression<Func<int>>) (() => sh_StatementType));
      if (!string.IsNullOrEmpty(sh_StatementTypeIn))
        supplierStatementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatement>>>, string>((Expression<Func<string>>) (() => sh_StatementTypeIn));
      if (si_StoreCode > 0)
        supplierStatementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatement>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        supplierStatementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatement>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        supplierStatementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatement>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        supplierStatementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatement>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        supplierStatementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatement>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        supplierStatementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatement>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        supplierStatementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatement>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        supplierStatementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatement>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        supplierStatementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatement>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        supplierStatementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatement>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        supplierStatementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatement>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        supplierStatementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatement>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        supplierStatementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatement>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        supplierStatementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatement>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        supplierStatementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatement>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        supplierStatementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatement>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        supplierStatementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatement>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        supplierStatementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatement>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        supplierStatementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatement>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        supplierStatementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatement>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        supplierStatementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatement>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        supplierStatementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatement>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        supplierStatementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatement>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        supplierStatementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatement>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        supplierStatementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatement>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      supplierStatementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatement>>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        supplierStatementList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatement>>>, string>((Expression<Func<string>>) (() => KeyWord));
      supplierStatementList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<StatementSupplierStatement>>>>(MethodBase.GetCurrentMethod());
      return supplierStatementList;
    }

    public static UniBizHttpRequest<UbRes<IList<StatementSupplierStatementDetail>>> GetStatementSupplierStatementDetailList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sd_SiteID")] long sd_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_IsTotalSum")] bool isTotalSum = false,
      [NameConvert("p_sh_ConfirmDate")] long sh_ConfirmDate = 0,
      [NameConvert("p_sh_ConfirmDateBegin")] long sh_ConfirmDateBegin = 0,
      [NameConvert("p_sh_ConfirmDateEnd")] long sh_ConfirmDateEnd = 0,
      [NameConvert("p_sh_ConfirmStatus")] int sh_ConfirmStatus = 0,
      [NameConvert("p_sh_StatementType")] int sh_StatementType = 0,
      [NameConvert("p_sh_StatementTypeIn")] string sh_StatementTypeIn = null,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_IsStoreTotalSum")] bool isStoreTotalSum = false,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierTypeIn")] string su_SupplierTypeIn = null,
      [NameConvert("p_dpt_lv1_ID")] int dpt_lv1_ID = 0,
      [NameConvert("p_dpt_lv2_ID")] int dpt_lv2_ID = 0,
      [NameConvert("p_dpt_lv3_ID")] int dpt_lv3_ID = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv1_IDIn")] string ctg_lv1_IDIn = null,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_lv2_IDIn")] string ctg_lv2_IDIn = null,
      [NameConvert("p_ctg_lv3_ID")] int ctg_lv3_ID = 0,
      [NameConvert("p_ctg_lv3_IDIn")] string ctg_lv3_IDIn = null,
      [NameConvert("p_bgg_GroupID")] int bgg_GroupID = 0,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_mk_MakerCodeIn")] string mk_MakerCodeIn = null,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0,
      [NameConvert("p_br_BrandCodeIn")] string br_BrandCodeIn = null,
      [NameConvert("p_gd_TaxDiv")] int gd_TaxDiv = 0,
      [NameConvert("p_gd_SalesUnit")] int gd_SalesUnit = 0,
      [NameConvert("p_gd_StockUnit")] int gd_StockUnit = 0,
      [NameConvert("p_gd_StockUnitIn")] string gd_StockUnitIn = null,
      [NameConvert("p_IsStatementSalse")] bool isStatementSalse = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<StatementSupplierStatementDetail>>> statementDetailList = new UniBizHttpRequest<UbRes<IList<StatementSupplierStatementDetail>>>(HttpMethod.Get);
      statementDetailList.Resource = UbRestModelAttribute.GetBasePath<StatementRestServer>() + "/{sd_SiteID}/Supplier/StatementDetail/{work_pm_MenuCode}/{work_pmp_PropCode}";
      statementDetailList.Headers.Add("Send-Type", SendType);
      statementDetailList.SetSegment<UniBizHttpRequest<UbRes<IList<StatementSupplierStatementDetail>>>, long>((Expression<Func<long>>) (() => sd_SiteID));
      statementDetailList.SetSegment<UniBizHttpRequest<UbRes<IList<StatementSupplierStatementDetail>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      statementDetailList.SetSegment<UniBizHttpRequest<UbRes<IList<StatementSupplierStatementDetail>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      statementDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatementDetail>>>, bool>((Expression<Func<bool>>) (() => isTotalSum));
      if (sh_ConfirmDate > 0L)
        statementDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatementDetail>>>, long>((Expression<Func<long>>) (() => sh_ConfirmDate));
      if (sh_ConfirmDateBegin > 0L)
        statementDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatementDetail>>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateBegin));
      if (sh_ConfirmDateEnd > 0L)
        statementDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatementDetail>>>, long>((Expression<Func<long>>) (() => sh_ConfirmDateEnd));
      if (sh_ConfirmStatus > 0)
        statementDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatementDetail>>>, int>((Expression<Func<int>>) (() => sh_ConfirmStatus));
      if (sh_StatementType > 0)
        statementDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatementDetail>>>, int>((Expression<Func<int>>) (() => sh_StatementType));
      if (!string.IsNullOrEmpty(sh_StatementTypeIn))
        statementDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatementDetail>>>, string>((Expression<Func<string>>) (() => sh_StatementTypeIn));
      if (si_StoreCode > 0)
        statementDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatementDetail>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
      {
        statementDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatementDetail>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
        statementDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatementDetail>>>, bool>((Expression<Func<bool>>) (() => isStoreTotalSum));
      }
      if (su_Supplier > 0)
        statementDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatementDetail>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        statementDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatementDetail>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (su_SupplierType > 0)
        statementDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatementDetail>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (!string.IsNullOrEmpty(su_SupplierTypeIn))
        statementDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatementDetail>>>, string>((Expression<Func<string>>) (() => su_SupplierTypeIn));
      if (dpt_lv1_ID > 0)
        statementDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatementDetail>>>, int>((Expression<Func<int>>) (() => dpt_lv1_ID));
      if (dpt_lv2_ID > 0)
        statementDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatementDetail>>>, int>((Expression<Func<int>>) (() => dpt_lv2_ID));
      if (dpt_lv3_ID > 0)
        statementDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatementDetail>>>, int>((Expression<Func<int>>) (() => dpt_lv3_ID));
      if (ctg_lv1_ID > 0)
        statementDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatementDetail>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (!string.IsNullOrEmpty(ctg_lv1_IDIn))
        statementDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatementDetail>>>, string>((Expression<Func<string>>) (() => ctg_lv1_IDIn));
      if (ctg_lv2_ID > 0)
        statementDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatementDetail>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (!string.IsNullOrEmpty(ctg_lv2_IDIn))
        statementDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatementDetail>>>, string>((Expression<Func<string>>) (() => ctg_lv2_IDIn));
      if (ctg_lv3_ID > 0)
        statementDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatementDetail>>>, int>((Expression<Func<int>>) (() => ctg_lv3_ID));
      if (!string.IsNullOrEmpty(ctg_lv3_IDIn))
        statementDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatementDetail>>>, string>((Expression<Func<string>>) (() => ctg_lv3_IDIn));
      if (bgg_GroupID > 0)
        statementDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatementDetail>>>, int>((Expression<Func<int>>) (() => bgg_GroupID));
      if (mk_MakerCode > 0)
        statementDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatementDetail>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (!string.IsNullOrEmpty(mk_MakerCodeIn))
        statementDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatementDetail>>>, string>((Expression<Func<string>>) (() => mk_MakerCodeIn));
      if (br_BrandCode > 0)
        statementDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatementDetail>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      if (!string.IsNullOrEmpty(br_BrandCodeIn))
        statementDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatementDetail>>>, string>((Expression<Func<string>>) (() => br_BrandCodeIn));
      if (gd_TaxDiv > 0)
        statementDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatementDetail>>>, int>((Expression<Func<int>>) (() => gd_TaxDiv));
      if (gd_SalesUnit > 0)
        statementDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatementDetail>>>, int>((Expression<Func<int>>) (() => gd_SalesUnit));
      if (gd_StockUnit > 0)
        statementDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatementDetail>>>, int>((Expression<Func<int>>) (() => gd_StockUnit));
      if (!string.IsNullOrEmpty(gd_StockUnitIn))
        statementDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatementDetail>>>, string>((Expression<Func<string>>) (() => gd_StockUnitIn));
      statementDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatementDetail>>>, bool>((Expression<Func<bool>>) (() => isStatementSalse));
      if (!string.IsNullOrEmpty(KeyWord))
        statementDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<StatementSupplierStatementDetail>>>, string>((Expression<Func<string>>) (() => KeyWord));
      statementDetailList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<StatementSupplierStatementDetail>>>>(MethodBase.GetCurrentMethod());
      return statementDetailList;
    }
  }
}
