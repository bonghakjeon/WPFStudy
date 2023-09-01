// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Inventory.RestServer.InventoryRestServer
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
using UniBiz.Bo.Models.UniStock.Inventory.InventoryWork;
using UniinfoNet.Http.UniBiz;

namespace UniBiz.Bo.Models.UniStock.Inventory.RestServer
{
  [UbRestModel("/Stock", TableCodeType.Unknown, HeaderPath = "")]
  public class InventoryRestServer
  {
    public static UniBizHttpRequest<UbRes<InventoryHeaderView>> GetInventory(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ih_SiteID")] long ih_SiteID,
      [NameConvert("p_ih_StatementNo")] long ih_StatementNo,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_isLtHistory")] bool isLtHistory = true)
    {
      UniBizHttpRequest<UbRes<InventoryHeaderView>> inventory = new UniBizHttpRequest<UbRes<InventoryHeaderView>>(HttpMethod.Get);
      inventory.Resource = UbRestModelAttribute.GetBasePath<InventoryRestServer>() + "/Inventory/{ih_SiteID}/Header/{ih_StatementNo}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      inventory.Headers.Add("Send-Type", SendType);
      inventory.SetSegment<UniBizHttpRequest<UbRes<InventoryHeaderView>>, long>((Expression<Func<long>>) (() => ih_SiteID));
      inventory.SetSegment<UniBizHttpRequest<UbRes<InventoryHeaderView>>, long>((Expression<Func<long>>) (() => ih_StatementNo));
      inventory.SetSegment<UniBizHttpRequest<UbRes<InventoryHeaderView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      inventory.SetSegment<UniBizHttpRequest<UbRes<InventoryHeaderView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      inventory.SetQuery<UniBizHttpRequest<UbRes<InventoryHeaderView>>, bool>((Expression<Func<bool>>) (() => isLtHistory));
      inventory.ReplaceByNameConverter<UniBizHttpRequest<UbRes<InventoryHeaderView>>>(MethodBase.GetCurrentMethod());
      return inventory;
    }

    public static UniBizHttpRequest<UbRes<InventoryHeaderView>> PostInventory(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ih_SiteID")] long ih_SiteID,
      [NameConvert("p_ih_StatementNo")] long ih_StatementNo,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      InventoryHeaderView pData)
    {
      UniBizHttpRequest<UbRes<InventoryHeaderView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<InventoryHeaderView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<InventoryRestServer>() + "/Inventory/{ih_SiteID}/Header/{ih_StatementNo}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<InventoryHeaderView>>, long>((Expression<Func<long>>) (() => ih_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<InventoryHeaderView>>, long>((Expression<Func<long>>) (() => ih_StatementNo));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<InventoryHeaderView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<InventoryHeaderView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<InventoryHeaderView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<InventoryHeaderView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<InventoryHeaderView>>> GetInventoryList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ih_SiteID")] long ih_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_ih_StatementNo")] long ih_StatementNo = 0,
      [NameConvert("p_ih_InventoryStatus")] int ih_InventoryStatus = 0,
      [NameConvert("p_ih_InventoryDate")] long ih_InventoryDate = 0,
      [NameConvert("p_ih_InventoryDateBegin")] long ih_InventoryDateBegin = 0,
      [NameConvert("p_ih_InventoryDateEnd")] long ih_InventoryDateEnd = 0,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_ih_ApplyType")] int ih_ApplyType = 0,
      [NameConvert("p_ih_ApplyDate")] long ih_ApplyDate = 0,
      [NameConvert("p_ih_ApplyDateBegin")] long ih_ApplyDateBegin = 0,
      [NameConvert("p_ih_ApplyDateEnd")] long ih_ApplyDateEnd = 0,
      [NameConvert("p_ih_StockUnit")] int ih_StockUnit = 0,
      [NameConvert("p_ih_StockUnitIn")] string ih_StockUnitIn = null,
      [NameConvert("p_ih_DeviceType")] int ih_DeviceType = 0,
      [NameConvert("p_ih_DeviceKey")] int ih_DeviceKey = 0,
      [NameConvert("p_ih_EmpCode")] int ih_EmpCode = 0,
      [NameConvert("p_ih_PosNo")] int ih_PosNo = 0,
      [NameConvert("p_ih_TransNo")] int ih_TransNo = 0,
      [NameConvert("p_ih_LocationCode")] int ih_LocationCode = 0,
      [NameConvert("p_isLtHistory")] bool isLtHistory = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<InventoryHeaderView>>> inventoryList = new UniBizHttpRequest<UbRes<IList<InventoryHeaderView>>>(HttpMethod.Get);
      inventoryList.Resource = UbRestModelAttribute.GetBasePath<InventoryRestServer>() + "/Inventory/{ih_SiteID}/Header/{work_pm_MenuCode}/{work_pmp_PropCode}";
      inventoryList.Headers.Add("Send-Type", SendType);
      inventoryList.SetSegment<UniBizHttpRequest<UbRes<IList<InventoryHeaderView>>>, long>((Expression<Func<long>>) (() => ih_SiteID));
      inventoryList.SetSegment<UniBizHttpRequest<UbRes<IList<InventoryHeaderView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      inventoryList.SetSegment<UniBizHttpRequest<UbRes<IList<InventoryHeaderView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (ih_StatementNo > 0L)
        inventoryList.SetQuery<UniBizHttpRequest<UbRes<IList<InventoryHeaderView>>>, long>((Expression<Func<long>>) (() => ih_StatementNo));
      if (ih_InventoryStatus > 0)
        inventoryList.SetQuery<UniBizHttpRequest<UbRes<IList<InventoryHeaderView>>>, int>((Expression<Func<int>>) (() => ih_InventoryStatus));
      if (ih_InventoryDate > 0L)
        inventoryList.SetQuery<UniBizHttpRequest<UbRes<IList<InventoryHeaderView>>>, long>((Expression<Func<long>>) (() => ih_InventoryDate));
      if (ih_InventoryDateBegin > 0L)
        inventoryList.SetQuery<UniBizHttpRequest<UbRes<IList<InventoryHeaderView>>>, long>((Expression<Func<long>>) (() => ih_InventoryDateBegin));
      if (ih_InventoryDateEnd > 0L)
        inventoryList.SetQuery<UniBizHttpRequest<UbRes<IList<InventoryHeaderView>>>, long>((Expression<Func<long>>) (() => ih_InventoryDateEnd));
      if (si_StoreCode > 0)
        inventoryList.SetQuery<UniBizHttpRequest<UbRes<IList<InventoryHeaderView>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
        inventoryList.SetQuery<UniBizHttpRequest<UbRes<IList<InventoryHeaderView>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
      if (su_Supplier > 0)
        inventoryList.SetQuery<UniBizHttpRequest<UbRes<IList<InventoryHeaderView>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        inventoryList.SetQuery<UniBizHttpRequest<UbRes<IList<InventoryHeaderView>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (ih_ApplyType > 0)
        inventoryList.SetQuery<UniBizHttpRequest<UbRes<IList<InventoryHeaderView>>>, int>((Expression<Func<int>>) (() => ih_ApplyType));
      if (ih_ApplyDate > 0L)
        inventoryList.SetQuery<UniBizHttpRequest<UbRes<IList<InventoryHeaderView>>>, long>((Expression<Func<long>>) (() => ih_ApplyDate));
      if (ih_ApplyDateBegin > 0L)
        inventoryList.SetQuery<UniBizHttpRequest<UbRes<IList<InventoryHeaderView>>>, long>((Expression<Func<long>>) (() => ih_ApplyDateBegin));
      if (ih_ApplyDateEnd > 0L)
        inventoryList.SetQuery<UniBizHttpRequest<UbRes<IList<InventoryHeaderView>>>, long>((Expression<Func<long>>) (() => ih_ApplyDateEnd));
      if (ih_StockUnit > 0)
        inventoryList.SetQuery<UniBizHttpRequest<UbRes<IList<InventoryHeaderView>>>, int>((Expression<Func<int>>) (() => ih_StockUnit));
      if (!string.IsNullOrEmpty(ih_StockUnitIn))
        inventoryList.SetQuery<UniBizHttpRequest<UbRes<IList<InventoryHeaderView>>>, string>((Expression<Func<string>>) (() => ih_StockUnitIn));
      if (ih_DeviceType > 0)
        inventoryList.SetQuery<UniBizHttpRequest<UbRes<IList<InventoryHeaderView>>>, int>((Expression<Func<int>>) (() => ih_DeviceType));
      if (ih_DeviceKey > 0)
        inventoryList.SetQuery<UniBizHttpRequest<UbRes<IList<InventoryHeaderView>>>, int>((Expression<Func<int>>) (() => ih_DeviceKey));
      if (ih_EmpCode > 0)
        inventoryList.SetQuery<UniBizHttpRequest<UbRes<IList<InventoryHeaderView>>>, int>((Expression<Func<int>>) (() => ih_EmpCode));
      if (ih_PosNo > 0)
        inventoryList.SetQuery<UniBizHttpRequest<UbRes<IList<InventoryHeaderView>>>, int>((Expression<Func<int>>) (() => ih_PosNo));
      if (ih_TransNo > 0)
        inventoryList.SetQuery<UniBizHttpRequest<UbRes<IList<InventoryHeaderView>>>, int>((Expression<Func<int>>) (() => ih_TransNo));
      if (ih_LocationCode > 0)
        inventoryList.SetQuery<UniBizHttpRequest<UbRes<IList<InventoryHeaderView>>>, int>((Expression<Func<int>>) (() => ih_LocationCode));
      inventoryList.SetQuery<UniBizHttpRequest<UbRes<IList<InventoryHeaderView>>>, bool>((Expression<Func<bool>>) (() => isLtHistory));
      if (!string.IsNullOrEmpty(KeyWord))
        inventoryList.SetQuery<UniBizHttpRequest<UbRes<IList<InventoryHeaderView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      inventoryList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<InventoryHeaderView>>>>(MethodBase.GetCurrentMethod());
      return inventoryList;
    }

    public static UniBizHttpRequest<UbRes<JobEvtInventoryHeader>> PostInventoryList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ih_SiteID")] long ih_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      JobEvtInventoryHeader pData)
    {
      UniBizHttpRequest<UbRes<JobEvtInventoryHeader>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<JobEvtInventoryHeader>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<InventoryRestServer>() + "/Inventory/{ih_SiteID}/Header/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<JobEvtInventoryHeader>>, long>((Expression<Func<long>>) (() => ih_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<JobEvtInventoryHeader>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<JobEvtInventoryHeader>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<JobEvtInventoryHeader>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<JobEvtInventoryHeader>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<bool>> DeleteInventoryList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ih_SiteID")] long ih_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      string p_JobID)
    {
      UniBizHttpRequest<UbRes<bool>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<bool>>(HttpMethod.Delete);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<InventoryRestServer>() + "/Inventory/{ih_SiteID}/Header/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<bool>>, long>((Expression<Func<long>>) (() => ih_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<bool>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<bool>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<string>(p_JobID, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<bool>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<InventoryDetailView>>> GetInventoryDetailList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_id_SiteID")] long id_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_id_StatementNo")] long id_StatementNo = 0,
      [NameConvert("p_id_Seq")] int id_Seq = 0,
      [NameConvert("p_ih_InventoryStatus")] int ih_InventoryStatus = 0,
      [NameConvert("p_ih_InventoryDate")] long ih_InventoryDate = 0,
      [NameConvert("p_ih_InventoryDateBegin")] long ih_InventoryDateBegin = 0,
      [NameConvert("p_ih_InventoryDateEnd")] long ih_InventoryDateEnd = 0,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_SupplierIn")] string su_SupplierIn = null,
      [NameConvert("p_ih_EmpCode")] int ih_EmpCode = 0,
      [NameConvert("p_ih_ApplyType")] int ih_ApplyType = 0,
      [NameConvert("p_ih_StockUnit")] int ih_StockUnit = 0,
      [NameConvert("p_ih_StockUnitIn")] string ih_StockUnitIn = null,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<InventoryDetailView>>> inventoryDetailList = new UniBizHttpRequest<UbRes<IList<InventoryDetailView>>>(HttpMethod.Get);
      inventoryDetailList.Resource = UbRestModelAttribute.GetBasePath<InventoryRestServer>() + "/Inventory/{id_SiteID}/Detail/{work_pm_MenuCode}/{work_pmp_PropCode}";
      inventoryDetailList.Headers.Add("Send-Type", SendType);
      inventoryDetailList.SetSegment<UniBizHttpRequest<UbRes<IList<InventoryDetailView>>>, long>((Expression<Func<long>>) (() => id_SiteID));
      inventoryDetailList.SetSegment<UniBizHttpRequest<UbRes<IList<InventoryDetailView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      inventoryDetailList.SetSegment<UniBizHttpRequest<UbRes<IList<InventoryDetailView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (id_StatementNo > 0L)
        inventoryDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<InventoryDetailView>>>, long>((Expression<Func<long>>) (() => id_StatementNo));
      if (id_Seq > 0)
        inventoryDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<InventoryDetailView>>>, int>((Expression<Func<int>>) (() => id_Seq));
      if (ih_InventoryStatus > 0)
        inventoryDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<InventoryDetailView>>>, int>((Expression<Func<int>>) (() => ih_InventoryStatus));
      if (ih_InventoryDate > 0L)
        inventoryDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<InventoryDetailView>>>, long>((Expression<Func<long>>) (() => ih_InventoryDate));
      if (ih_InventoryDateBegin > 0L)
        inventoryDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<InventoryDetailView>>>, long>((Expression<Func<long>>) (() => ih_InventoryDateBegin));
      if (ih_InventoryDateEnd > 0L)
        inventoryDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<InventoryDetailView>>>, long>((Expression<Func<long>>) (() => ih_InventoryDateEnd));
      if (si_StoreCode > 0)
        inventoryDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<InventoryDetailView>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
        inventoryDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<InventoryDetailView>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
      if (su_Supplier > 0)
        inventoryDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<InventoryDetailView>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_SupplierIn))
        inventoryDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<InventoryDetailView>>>, string>((Expression<Func<string>>) (() => su_SupplierIn));
      if (ih_EmpCode > 0)
        inventoryDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<InventoryDetailView>>>, int>((Expression<Func<int>>) (() => ih_EmpCode));
      if (ih_ApplyType > 0)
        inventoryDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<InventoryDetailView>>>, int>((Expression<Func<int>>) (() => ih_ApplyType));
      if (ih_StockUnit > 0)
        inventoryDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<InventoryDetailView>>>, int>((Expression<Func<int>>) (() => ih_StockUnit));
      if (!string.IsNullOrEmpty(ih_StockUnitIn))
        inventoryDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<InventoryDetailView>>>, string>((Expression<Func<string>>) (() => ih_StockUnitIn));
      if (!string.IsNullOrEmpty(KeyWord))
        inventoryDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<InventoryDetailView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      inventoryDetailList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<InventoryDetailView>>>>(MethodBase.GetCurrentMethod());
      return inventoryDetailList;
    }

    public static UniBizHttpRequest<UbRes<InventoryDetailView>> GetStatementDetailsBarcode(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_id_SiteID")] long id_SiteID,
      [NameConvert("p_ih_StoreCode")] int ih_StoreCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_ih_InventoryDate")] long ih_InventoryDate,
      [NameConvert("p_id_BoxCode")] long id_BoxCode,
      [NameConvert("p_id_BarCode")] string id_BarCode)
    {
      UniBizHttpRequest<UbRes<InventoryDetailView>> statementDetailsBarcode = new UniBizHttpRequest<UbRes<InventoryDetailView>>(HttpMethod.Get);
      statementDetailsBarcode.Resource = UbRestModelAttribute.GetBasePath<InventoryRestServer>() + "/Inventory/{id_SiteID}/Details/Goods/{ih_StoreCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      statementDetailsBarcode.Headers.Add("Send-Type", SendType);
      statementDetailsBarcode.SetSegment<UniBizHttpRequest<UbRes<InventoryDetailView>>, long>((Expression<Func<long>>) (() => id_SiteID));
      statementDetailsBarcode.SetSegment<UniBizHttpRequest<UbRes<InventoryDetailView>>, int>((Expression<Func<int>>) (() => ih_StoreCode));
      statementDetailsBarcode.SetSegment<UniBizHttpRequest<UbRes<InventoryDetailView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      statementDetailsBarcode.SetSegment<UniBizHttpRequest<UbRes<InventoryDetailView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      statementDetailsBarcode.SetQuery<UniBizHttpRequest<UbRes<InventoryDetailView>>, long>((Expression<Func<long>>) (() => ih_InventoryDate));
      if (id_BoxCode > 0L)
        statementDetailsBarcode.SetQuery<UniBizHttpRequest<UbRes<InventoryDetailView>>, long>((Expression<Func<long>>) (() => id_BoxCode));
      if (!string.IsNullOrEmpty(id_BarCode))
        statementDetailsBarcode.SetQuery<UniBizHttpRequest<UbRes<InventoryDetailView>>, string>((Expression<Func<string>>) (() => id_BarCode));
      statementDetailsBarcode.ReplaceByNameConverter<UniBizHttpRequest<UbRes<InventoryDetailView>>>(MethodBase.GetCurrentMethod());
      return statementDetailsBarcode;
    }

    public static UniBizHttpRequest<UbRes<IList<InventoryDetailView>>> PutStatementDetailsBarcodeList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_id_SiteID")] long id_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      InventoryDetailBarcodeSearchPack pPack)
    {
      UniBizHttpRequest<UbRes<IList<InventoryDetailView>>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<IList<InventoryDetailView>>>(HttpMethod.Put);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<InventoryRestServer>() + "/Inventory/{id_SiteID}/Details/Barcode/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<InventoryDetailView>>>, long>((Expression<Func<long>>) (() => id_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<InventoryDetailView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<InventoryDetailView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<InventoryDetailBarcodeSearchPack>(pPack, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<InventoryDetailView>>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<JobEvtInventoryWork>> PostInventoryWork(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_iwc_SiteID")] long iwc_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      JobEvtInventoryWork pData)
    {
      UniBizHttpRequest<UbRes<JobEvtInventoryWork>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<JobEvtInventoryWork>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<InventoryRestServer>() + "/Inventory/{iwc_SiteID}/InventoryWork/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<JobEvtInventoryWork>>, long>((Expression<Func<long>>) (() => iwc_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<JobEvtInventoryWork>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<JobEvtInventoryWork>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<JobEvtInventoryWork>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<JobEvtInventoryWork>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<bool>> DeleteInventoryWork(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_iwc_SiteID")] long iwc_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      string p_JobID)
    {
      UniBizHttpRequest<UbRes<bool>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<bool>>(HttpMethod.Delete);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<InventoryRestServer>() + "/Inventory/{iwc_SiteID}/InventoryWork/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<bool>>, long>((Expression<Func<long>>) (() => iwc_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<bool>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<bool>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<string>(p_JobID, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<bool>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<InventoryWorkCntView>> GetInventoryWorkCount(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_iwc_SiteID")] long iwc_SiteID,
      [NameConvert("p_iwc_InventoryDate")] long iwc_InventoryDate,
      [NameConvert("p_iwc_StoreCode")] int iwc_StoreCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_isLtHistory")] bool isLtHistory = false)
    {
      UniBizHttpRequest<UbRes<InventoryWorkCntView>> inventoryWorkCount = new UniBizHttpRequest<UbRes<InventoryWorkCntView>>(HttpMethod.Get);
      inventoryWorkCount.Resource = UbRestModelAttribute.GetBasePath<InventoryRestServer>() + "/Inventory/{iwc_SiteID}/InventoryWork/Count/{iwc_InventoryDate}/{iwc_StoreCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      inventoryWorkCount.Headers.Add("Send-Type", SendType);
      inventoryWorkCount.SetSegment<UniBizHttpRequest<UbRes<InventoryWorkCntView>>, long>((Expression<Func<long>>) (() => iwc_SiteID));
      inventoryWorkCount.SetSegment<UniBizHttpRequest<UbRes<InventoryWorkCntView>>, long>((Expression<Func<long>>) (() => iwc_InventoryDate));
      inventoryWorkCount.SetSegment<UniBizHttpRequest<UbRes<InventoryWorkCntView>>, int>((Expression<Func<int>>) (() => iwc_StoreCode));
      inventoryWorkCount.SetSegment<UniBizHttpRequest<UbRes<InventoryWorkCntView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      inventoryWorkCount.SetSegment<UniBizHttpRequest<UbRes<InventoryWorkCntView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      inventoryWorkCount.SetQuery<UniBizHttpRequest<UbRes<InventoryWorkCntView>>, bool>((Expression<Func<bool>>) (() => isLtHistory));
      inventoryWorkCount.ReplaceByNameConverter<UniBizHttpRequest<UbRes<InventoryWorkCntView>>>(MethodBase.GetCurrentMethod());
      return inventoryWorkCount;
    }

    public static UniBizHttpRequest<UbRes<IList<InventoryWorkCntView>>> GetInventoryWorkCountList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_iwc_SiteID")] long iwc_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_iwc_InventoryDate")] long iwc_InventoryDate = 0,
      [NameConvert("p_iwc_InventoryDateBegin")] long iwc_InventoryDateBegin = 0,
      [NameConvert("p_iwc_InventoryDateEnd")] long iwc_InventoryDateEnd = 0,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null,
      [NameConvert("p_isLtHistory")] bool isLtHistory = true)
    {
      UniBizHttpRequest<UbRes<IList<InventoryWorkCntView>>> inventoryWorkCountList = new UniBizHttpRequest<UbRes<IList<InventoryWorkCntView>>>(HttpMethod.Get);
      inventoryWorkCountList.Resource = UbRestModelAttribute.GetBasePath<InventoryRestServer>() + "/Inventory/{iwc_SiteID}/InventoryWork/Count/{work_pm_MenuCode}/{work_pmp_PropCode}";
      inventoryWorkCountList.Headers.Add("Send-Type", SendType);
      inventoryWorkCountList.SetSegment<UniBizHttpRequest<UbRes<IList<InventoryWorkCntView>>>, long>((Expression<Func<long>>) (() => iwc_SiteID));
      inventoryWorkCountList.SetSegment<UniBizHttpRequest<UbRes<IList<InventoryWorkCntView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      inventoryWorkCountList.SetSegment<UniBizHttpRequest<UbRes<IList<InventoryWorkCntView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (iwc_InventoryDate > 0L)
        inventoryWorkCountList.SetQuery<UniBizHttpRequest<UbRes<IList<InventoryWorkCntView>>>, long>((Expression<Func<long>>) (() => iwc_InventoryDate));
      if (iwc_InventoryDateBegin > 0L)
        inventoryWorkCountList.SetQuery<UniBizHttpRequest<UbRes<IList<InventoryWorkCntView>>>, long>((Expression<Func<long>>) (() => iwc_InventoryDateBegin));
      if (iwc_InventoryDateEnd > 0L)
        inventoryWorkCountList.SetQuery<UniBizHttpRequest<UbRes<IList<InventoryWorkCntView>>>, long>((Expression<Func<long>>) (() => iwc_InventoryDateEnd));
      if (si_StoreCode > 0)
        inventoryWorkCountList.SetQuery<UniBizHttpRequest<UbRes<IList<InventoryWorkCntView>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
        inventoryWorkCountList.SetQuery<UniBizHttpRequest<UbRes<IList<InventoryWorkCntView>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
      inventoryWorkCountList.SetQuery<UniBizHttpRequest<UbRes<IList<InventoryWorkCntView>>>, bool>((Expression<Func<bool>>) (() => isLtHistory));
      inventoryWorkCountList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<InventoryWorkCntView>>>>(MethodBase.GetCurrentMethod());
      return inventoryWorkCountList;
    }

    public static UniBizHttpRequest<UbRes<IList<InventoryWorkCntLogView>>> GetInventoryWorkCountLogList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_iwcl_SiteID")] long iwcl_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_iwcl_InventoryDate")] long iwcl_InventoryDate = 0,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_si_StoreCodeIn")] string si_StoreCodeIn = null)
    {
      UniBizHttpRequest<UbRes<IList<InventoryWorkCntLogView>>> workCountLogList = new UniBizHttpRequest<UbRes<IList<InventoryWorkCntLogView>>>(HttpMethod.Get);
      workCountLogList.Resource = UbRestModelAttribute.GetBasePath<InventoryRestServer>() + "/Inventory/{iwcl_SiteID}/InventoryWork/Count/Log/{work_pm_MenuCode}/{work_pmp_PropCode}";
      workCountLogList.Headers.Add("Send-Type", SendType);
      workCountLogList.SetSegment<UniBizHttpRequest<UbRes<IList<InventoryWorkCntLogView>>>, long>((Expression<Func<long>>) (() => iwcl_SiteID));
      workCountLogList.SetSegment<UniBizHttpRequest<UbRes<IList<InventoryWorkCntLogView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      workCountLogList.SetSegment<UniBizHttpRequest<UbRes<IList<InventoryWorkCntLogView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (iwcl_InventoryDate > 0L)
        workCountLogList.SetQuery<UniBizHttpRequest<UbRes<IList<InventoryWorkCntLogView>>>, long>((Expression<Func<long>>) (() => iwcl_InventoryDate));
      if (si_StoreCode > 0)
        workCountLogList.SetQuery<UniBizHttpRequest<UbRes<IList<InventoryWorkCntLogView>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (!string.IsNullOrEmpty(si_StoreCodeIn))
        workCountLogList.SetQuery<UniBizHttpRequest<UbRes<IList<InventoryWorkCntLogView>>>, string>((Expression<Func<string>>) (() => si_StoreCodeIn));
      workCountLogList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<InventoryWorkCntLogView>>>>(MethodBase.GetCurrentMethod());
      return workCountLogList;
    }
  }
}
