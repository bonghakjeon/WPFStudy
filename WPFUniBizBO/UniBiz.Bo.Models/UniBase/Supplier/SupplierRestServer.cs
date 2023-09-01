// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Supplier.SupplierRestServer
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
using UniBiz.Bo.Models.UbRest;
using UniBiz.Bo.Models.UniBase.Supplier.AutoOrderConition;
using UniBiz.Bo.Models.UniBase.Supplier.PayContion;
using UniBiz.Bo.Models.UniBase.Supplier.RebateConditionDetail;
using UniBiz.Bo.Models.UniBase.Supplier.RebateConditionHeader;
using UniBiz.Bo.Models.UniBase.Supplier.Supplier;
using UniBiz.Bo.Models.UniBase.Supplier.SupplierAutoDeduction;
using UniBiz.Bo.Models.UniBase.Supplier.SupplierHistory;
using UniBiz.Bo.Models.UniBase.Supplier.SupplierImage;
using UniinfoNet;
using UniinfoNet.Http.UniBiz;

namespace UniBiz.Bo.Models.UniBase.Supplier
{
  [UbRestModel("/Code", TableCodeType.Unknown, HeaderPath = "")]
  public class SupplierRestServer : BindableBase
  {
    public static UniBizHttpRequest<UbRes<SupplierView>> GetSupplier(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_su_SiteID")] long su_SiteID,
      [NameConvert("p_su_Supplier")] int su_Supplier,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_is_thumb_image")] bool is_thumb_image = false,
      [NameConvert("p_is_origin_image")] bool is_origin_image = false)
    {
      UniBizHttpRequest<UbRes<SupplierView>> supplier = new UniBizHttpRequest<UbRes<SupplierView>>(HttpMethod.Get);
      supplier.Resource = UbRestModelAttribute.GetBasePath<SupplierRestServer>() + "/Supplier/{su_SiteID}/{su_Supplier}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      supplier.Headers.Add("Send-Type", SendType);
      supplier.SetSegment<UniBizHttpRequest<UbRes<SupplierView>>, long>((Expression<Func<long>>) (() => su_SiteID));
      supplier.SetSegment<UniBizHttpRequest<UbRes<SupplierView>>, int>((Expression<Func<int>>) (() => su_Supplier));
      supplier.SetSegment<UniBizHttpRequest<UbRes<SupplierView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      supplier.SetSegment<UniBizHttpRequest<UbRes<SupplierView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (is_thumb_image)
        supplier.SetQuery<UniBizHttpRequest<UbRes<SupplierView>>, bool>((Expression<Func<bool>>) (() => is_thumb_image));
      if (is_origin_image)
        supplier.SetQuery<UniBizHttpRequest<UbRes<SupplierView>>, bool>((Expression<Func<bool>>) (() => is_origin_image));
      supplier.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SupplierView>>>(MethodBase.GetCurrentMethod());
      return supplier;
    }

    public static UniBizHttpRequest<UbRes<SupplierView>> PostSupplier(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_su_SiteID")] long su_SiteID,
      [NameConvert("p_su_Supplier")] int su_Supplier,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      SupplierView pData)
    {
      UniBizHttpRequest<UbRes<SupplierView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<SupplierView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<SupplierRestServer>() + "/Supplier/{su_SiteID}/{su_Supplier}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<SupplierView>>, long>((Expression<Func<long>>) (() => su_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<SupplierView>>, int>((Expression<Func<int>>) (() => su_Supplier));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<SupplierView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<SupplierView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<SupplierView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SupplierView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<SupplierView>>> GetSupplierList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_su_SiteID")] long su_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_SupplierIn")] string SupplierIn = null,
      [NameConvert("p_su_SupplierName")] string su_SupplierName = null,
      [NameConvert("p_not_Supplier")] int not_Supplier = 0,
      [NameConvert("p_su_HeadSupplier")] int su_HeadSupplier = 0,
      [NameConvert("p_su_SupplierViewCode")] string su_SupplierViewCode = null,
      [NameConvert("p_su_SupplierType")] int su_SupplierType = 0,
      [NameConvert("p_su_SupplierKind")] int su_SupplierKind = 0,
      [NameConvert("p_su_PreTaxDiv")] int su_PreTaxDiv = 0,
      [NameConvert("p_su_MultiSuplierDiv")] int su_MultiSuplierDiv = 0,
      [NameConvert("p_su_DeductionDayDiv")] int su_DeductionDayDiv = 0,
      [NameConvert("p_su_NewStatementYn")] string su_NewStatementYn = null,
      [NameConvert("p_su_BizNo")] string su_BizNo = null,
      [NameConvert("p_su_BizCeo")] string su_BizCeo = null,
      [NameConvert("p_su_UseYn")] string su_UseYn = null,
      [NameConvert("p_is_thumb_image")] bool is_thumb_image = false,
      [NameConvert("p_is_origin_image")] bool is_origin_image = false,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<SupplierView>>> supplierList = new UniBizHttpRequest<UbRes<IList<SupplierView>>>(HttpMethod.Get);
      supplierList.Resource = UbRestModelAttribute.GetBasePath<SupplierRestServer>() + "/Supplier/{su_SiteID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      supplierList.Headers.Add("Send-Type", SendType);
      supplierList.SetSegment<UniBizHttpRequest<UbRes<IList<SupplierView>>>, long>((Expression<Func<long>>) (() => su_SiteID));
      supplierList.SetSegment<UniBizHttpRequest<UbRes<IList<SupplierView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      supplierList.SetSegment<UniBizHttpRequest<UbRes<IList<SupplierView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (su_Supplier > 0)
        supplierList.SetQuery<UniBizHttpRequest<UbRes<IList<SupplierView>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(SupplierIn))
        supplierList.SetQuery<UniBizHttpRequest<UbRes<IList<SupplierView>>>, string>((Expression<Func<string>>) (() => SupplierIn));
      if (!string.IsNullOrEmpty(su_SupplierName))
        supplierList.SetQuery<UniBizHttpRequest<UbRes<IList<SupplierView>>>, string>((Expression<Func<string>>) (() => su_SupplierName));
      if (not_Supplier > 0)
        supplierList.SetQuery<UniBizHttpRequest<UbRes<IList<SupplierView>>>, int>((Expression<Func<int>>) (() => not_Supplier));
      if (su_HeadSupplier > 0)
        supplierList.SetQuery<UniBizHttpRequest<UbRes<IList<SupplierView>>>, int>((Expression<Func<int>>) (() => su_HeadSupplier));
      if (!string.IsNullOrEmpty(su_SupplierViewCode))
        supplierList.SetQuery<UniBizHttpRequest<UbRes<IList<SupplierView>>>, string>((Expression<Func<string>>) (() => su_SupplierViewCode));
      if (su_SupplierType > 0)
        supplierList.SetQuery<UniBizHttpRequest<UbRes<IList<SupplierView>>>, int>((Expression<Func<int>>) (() => su_SupplierType));
      if (su_SupplierKind > 0)
        supplierList.SetQuery<UniBizHttpRequest<UbRes<IList<SupplierView>>>, int>((Expression<Func<int>>) (() => su_SupplierKind));
      if (su_PreTaxDiv > 0)
        supplierList.SetQuery<UniBizHttpRequest<UbRes<IList<SupplierView>>>, int>((Expression<Func<int>>) (() => su_PreTaxDiv));
      if (su_MultiSuplierDiv > 0)
        supplierList.SetQuery<UniBizHttpRequest<UbRes<IList<SupplierView>>>, int>((Expression<Func<int>>) (() => su_MultiSuplierDiv));
      if (su_DeductionDayDiv > 0)
        supplierList.SetQuery<UniBizHttpRequest<UbRes<IList<SupplierView>>>, int>((Expression<Func<int>>) (() => su_DeductionDayDiv));
      if (!string.IsNullOrEmpty(su_NewStatementYn))
        supplierList.SetQuery<UniBizHttpRequest<UbRes<IList<SupplierView>>>, string>((Expression<Func<string>>) (() => su_NewStatementYn));
      if (!string.IsNullOrEmpty(su_BizNo))
        supplierList.SetQuery<UniBizHttpRequest<UbRes<IList<SupplierView>>>, string>((Expression<Func<string>>) (() => su_BizNo));
      if (!string.IsNullOrEmpty(su_BizCeo))
        supplierList.SetQuery<UniBizHttpRequest<UbRes<IList<SupplierView>>>, string>((Expression<Func<string>>) (() => su_BizCeo));
      if (!string.IsNullOrEmpty(su_UseYn))
        supplierList.SetQuery<UniBizHttpRequest<UbRes<IList<SupplierView>>>, string>((Expression<Func<string>>) (() => su_UseYn));
      if (is_thumb_image)
        supplierList.SetQuery<UniBizHttpRequest<UbRes<IList<SupplierView>>>, bool>((Expression<Func<bool>>) (() => is_thumb_image));
      if (is_origin_image)
        supplierList.SetQuery<UniBizHttpRequest<UbRes<IList<SupplierView>>>, bool>((Expression<Func<bool>>) (() => is_origin_image));
      if (!string.IsNullOrEmpty(KeyWord))
        supplierList.SetQuery<UniBizHttpRequest<UbRes<IList<SupplierView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      supplierList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<SupplierView>>>>(MethodBase.GetCurrentMethod());
      return supplierList;
    }

    public static UniBizHttpRequest<UbRes<IList<SupplierView>>> PostSupplierList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_su_SiteID")] long su_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      IList<SupplierView> p_list)
    {
      UniBizHttpRequest<UbRes<IList<SupplierView>>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<IList<SupplierView>>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<SupplierRestServer>() + "/Supplier/{su_SiteID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<SupplierView>>>, long>((Expression<Func<long>>) (() => su_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<SupplierView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<SupplierView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<IList<SupplierView>>(p_list, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<SupplierView>>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<SupplierView>>> GetSupplierBizNoList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_su_SiteID")] long su_SiteID,
      [NameConvert("p_su_BizNo")] string su_BizNo,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_su_BizCeo")] string su_BizCeo = null,
      [NameConvert("p_su_UseYn")] string su_UseYn = null,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<SupplierView>>> supplierBizNoList = new UniBizHttpRequest<UbRes<IList<SupplierView>>>(HttpMethod.Get);
      supplierBizNoList.Resource = UbRestModelAttribute.GetBasePath<SupplierRestServer>() + "/Supplier/{su_SiteID}/BizNo/{su_BizNo}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      supplierBizNoList.Headers.Add("Send-Type", SendType);
      supplierBizNoList.SetSegment<UniBizHttpRequest<UbRes<IList<SupplierView>>>, long>((Expression<Func<long>>) (() => su_SiteID));
      supplierBizNoList.SetSegment<UniBizHttpRequest<UbRes<IList<SupplierView>>>, string>((Expression<Func<string>>) (() => su_BizNo));
      supplierBizNoList.SetSegment<UniBizHttpRequest<UbRes<IList<SupplierView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      supplierBizNoList.SetSegment<UniBizHttpRequest<UbRes<IList<SupplierView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (su_Supplier > 0)
        supplierBizNoList.SetQuery<UniBizHttpRequest<UbRes<IList<SupplierView>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (!string.IsNullOrEmpty(su_BizCeo))
        supplierBizNoList.SetQuery<UniBizHttpRequest<UbRes<IList<SupplierView>>>, string>((Expression<Func<string>>) (() => su_BizCeo));
      if (!string.IsNullOrEmpty(su_UseYn))
        supplierBizNoList.SetQuery<UniBizHttpRequest<UbRes<IList<SupplierView>>>, string>((Expression<Func<string>>) (() => su_UseYn));
      if (!string.IsNullOrEmpty(KeyWord))
        supplierBizNoList.SetQuery<UniBizHttpRequest<UbRes<IList<SupplierView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      supplierBizNoList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<SupplierView>>>>(MethodBase.GetCurrentMethod());
      return supplierBizNoList;
    }

    public static UniBizHttpRequest<UbRes<AutoOrderConitionView>> GetAutoOrderConition(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_aoc_SiteID")] long aoc_SiteID,
      [NameConvert("p_aoc_ID")] int aoc_ID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<AutoOrderConitionView>> autoOrderConition = new UniBizHttpRequest<UbRes<AutoOrderConitionView>>(HttpMethod.Get);
      autoOrderConition.Resource = UbRestModelAttribute.GetBasePath<SupplierRestServer>() + "/Supplier/{aoc_SiteID}/AutoOrderConition/{aoc_ID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      autoOrderConition.Headers.Add("Send-Type", SendType);
      autoOrderConition.SetSegment<UniBizHttpRequest<UbRes<AutoOrderConitionView>>, long>((Expression<Func<long>>) (() => aoc_SiteID));
      autoOrderConition.SetSegment<UniBizHttpRequest<UbRes<AutoOrderConitionView>>, int>((Expression<Func<int>>) (() => aoc_ID));
      autoOrderConition.SetSegment<UniBizHttpRequest<UbRes<AutoOrderConitionView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      autoOrderConition.SetSegment<UniBizHttpRequest<UbRes<AutoOrderConitionView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      autoOrderConition.ReplaceByNameConverter<UniBizHttpRequest<UbRes<AutoOrderConitionView>>>(MethodBase.GetCurrentMethod());
      return autoOrderConition;
    }

    public static UniBizHttpRequest<UbRes<AutoOrderConitionView>> PostAutoOrderConition(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_aoc_SiteID")] long aoc_SiteID,
      [NameConvert("p_aoc_ID")] int aoc_ID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      AutoOrderConitionView pData)
    {
      UniBizHttpRequest<UbRes<AutoOrderConitionView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<AutoOrderConitionView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<SupplierRestServer>() + "/Supplier/{aoc_SiteID}/AutoOrderConition/{aoc_ID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<AutoOrderConitionView>>, long>((Expression<Func<long>>) (() => aoc_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<AutoOrderConitionView>>, int>((Expression<Func<int>>) (() => aoc_ID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<AutoOrderConitionView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<AutoOrderConitionView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<AutoOrderConitionView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<AutoOrderConitionView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<AutoOrderConitionView>> DeleteAutoOrderConition(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_aoc_SiteID")] long aoc_SiteID,
      [NameConvert("p_aoc_ID")] int aoc_ID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<AutoOrderConitionView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<AutoOrderConitionView>>(HttpMethod.Delete);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<SupplierRestServer>() + "/Supplier/{aoc_SiteID}/AutoOrderConition/{aoc_ID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<AutoOrderConitionView>>, long>((Expression<Func<long>>) (() => aoc_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<AutoOrderConitionView>>, int>((Expression<Func<int>>) (() => aoc_ID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<AutoOrderConitionView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<AutoOrderConitionView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<AutoOrderConitionView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<AutoOrderConitionView>>> GetAutoOrderConitionList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_aoc_SiteID")] long aoc_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_aoc_ID")] int aoc_ID = 0,
      [NameConvert("p_aoc_Supplier")] int aoc_Supplier = 0,
      [NameConvert("p_aoc_SupplierIn")] string aoc_SupplierIn = null,
      [NameConvert("p_aoc_StoreCode")] int aoc_StoreCode = 0,
      [NameConvert("p_aoc_StoreCodeIn")] string aoc_StoreCodeIn = null,
      [NameConvert("p_aoc_CategoryCodeTop")] int aoc_CategoryCodeTop = 0,
      [NameConvert("p_aoc_CategoryCodeTopIn")] string aoc_CategoryCodeTopIn = null,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<AutoOrderConitionView>>> orderConitionList = new UniBizHttpRequest<UbRes<IList<AutoOrderConitionView>>>(HttpMethod.Get);
      orderConitionList.Resource = UbRestModelAttribute.GetBasePath<SupplierRestServer>() + "/Supplier/{aoc_SiteID}/AutoOrderConition/{work_pm_MenuCode}/{work_pmp_PropCode}";
      orderConitionList.Headers.Add("Send-Type", SendType);
      orderConitionList.SetSegment<UniBizHttpRequest<UbRes<IList<AutoOrderConitionView>>>, long>((Expression<Func<long>>) (() => aoc_SiteID));
      orderConitionList.SetSegment<UniBizHttpRequest<UbRes<IList<AutoOrderConitionView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      orderConitionList.SetSegment<UniBizHttpRequest<UbRes<IList<AutoOrderConitionView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (aoc_ID > 0)
        orderConitionList.SetQuery<UniBizHttpRequest<UbRes<IList<AutoOrderConitionView>>>, int>((Expression<Func<int>>) (() => aoc_ID));
      if (aoc_Supplier > 0)
        orderConitionList.SetQuery<UniBizHttpRequest<UbRes<IList<AutoOrderConitionView>>>, int>((Expression<Func<int>>) (() => aoc_Supplier));
      if (!string.IsNullOrEmpty(aoc_SupplierIn))
        orderConitionList.SetQuery<UniBizHttpRequest<UbRes<IList<AutoOrderConitionView>>>, string>((Expression<Func<string>>) (() => aoc_SupplierIn));
      if (aoc_StoreCode > 0)
        orderConitionList.SetQuery<UniBizHttpRequest<UbRes<IList<AutoOrderConitionView>>>, int>((Expression<Func<int>>) (() => aoc_StoreCode));
      if (!string.IsNullOrEmpty(aoc_StoreCodeIn))
        orderConitionList.SetQuery<UniBizHttpRequest<UbRes<IList<AutoOrderConitionView>>>, string>((Expression<Func<string>>) (() => aoc_StoreCodeIn));
      if (aoc_CategoryCodeTop > 0)
        orderConitionList.SetQuery<UniBizHttpRequest<UbRes<IList<AutoOrderConitionView>>>, int>((Expression<Func<int>>) (() => aoc_CategoryCodeTop));
      if (!string.IsNullOrEmpty(aoc_CategoryCodeTopIn))
        orderConitionList.SetQuery<UniBizHttpRequest<UbRes<IList<AutoOrderConitionView>>>, string>((Expression<Func<string>>) (() => aoc_CategoryCodeTopIn));
      if (!string.IsNullOrEmpty(KeyWord))
        orderConitionList.SetQuery<UniBizHttpRequest<UbRes<IList<AutoOrderConitionView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      orderConitionList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<AutoOrderConitionView>>>>(MethodBase.GetCurrentMethod());
      return orderConitionList;
    }

    public static UniBizHttpRequest<UbRes<IList<AutoOrderConitionView>>> PostAutoOrderConitionList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_aoc_SiteID")] long aoc_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      IList<AutoOrderConitionView> p_list)
    {
      UniBizHttpRequest<UbRes<IList<AutoOrderConitionView>>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<IList<AutoOrderConitionView>>>(HttpMethod.Get);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<SupplierRestServer>() + "/Supplier/{aoc_SiteID}/AutoOrderConition/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<AutoOrderConitionView>>>, long>((Expression<Func<long>>) (() => aoc_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<AutoOrderConitionView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<AutoOrderConitionView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<IList<AutoOrderConitionView>>(p_list, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<AutoOrderConitionView>>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<AutoOrderConitionView>>> DeleteAutoOrderConitionList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_aoc_SiteID")] long aoc_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      IList<AutoOrderConitionView> p_list)
    {
      UniBizHttpRequest<UbRes<IList<AutoOrderConitionView>>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<IList<AutoOrderConitionView>>>(HttpMethod.Delete);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<SupplierRestServer>() + "/Supplier/{aoc_SiteID}/AutoOrderConition/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<AutoOrderConitionView>>>, long>((Expression<Func<long>>) (() => aoc_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<AutoOrderConitionView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<AutoOrderConitionView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<IList<AutoOrderConitionView>>(p_list, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<AutoOrderConitionView>>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<PayContionView>> GetPayContion(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_payc_SiteID")] long payc_SiteID,
      [NameConvert("p_payc_ID")] int payc_ID,
      [NameConvert("p_payc_Turn")] int payc_Turn,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<PayContionView>> payContion = new UniBizHttpRequest<UbRes<PayContionView>>(HttpMethod.Get);
      payContion.Resource = UbRestModelAttribute.GetBasePath<SupplierRestServer>() + "/PayContion/{payc_SiteID}/{payc_ID}/{payc_Turn}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      payContion.Headers.Add("Send-Type", SendType);
      payContion.SetSegment<UniBizHttpRequest<UbRes<PayContionView>>, long>((Expression<Func<long>>) (() => payc_SiteID));
      payContion.SetSegment<UniBizHttpRequest<UbRes<PayContionView>>, int>((Expression<Func<int>>) (() => payc_ID));
      payContion.SetSegment<UniBizHttpRequest<UbRes<PayContionView>>, int>((Expression<Func<int>>) (() => payc_Turn));
      payContion.SetSegment<UniBizHttpRequest<UbRes<PayContionView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      payContion.SetSegment<UniBizHttpRequest<UbRes<PayContionView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      payContion.ReplaceByNameConverter<UniBizHttpRequest<UbRes<PayContionView>>>(MethodBase.GetCurrentMethod());
      return payContion;
    }

    public static UniBizHttpRequest<UbRes<PayContionView>> PostPayContion(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_payc_SiteID")] long payc_SiteID,
      [NameConvert("p_payc_ID")] int payc_ID,
      [NameConvert("p_payc_Turn")] int payc_Turn,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      PayContionView pData)
    {
      UniBizHttpRequest<UbRes<PayContionView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<PayContionView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<SupplierRestServer>() + "/PayContion/{payc_SiteID}/{payc_ID}/{payc_Turn}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<PayContionView>>, long>((Expression<Func<long>>) (() => payc_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<PayContionView>>, int>((Expression<Func<int>>) (() => payc_ID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<PayContionView>>, int>((Expression<Func<int>>) (() => payc_Turn));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<PayContionView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<PayContionView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<PayContionView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<PayContionView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<PayContionView>>> GetPayContionListAsync(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_payc_SiteID")] long payc_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_payc_ID")] int payc_ID = 0,
      [NameConvert("p_payc_Turn")] int payc_Turn = 0,
      [NameConvert("p_payc_Round")] int payc_Round = 0,
      [NameConvert("p_payc_PaymentDay")] int payc_PaymentDay = 0,
      [NameConvert("p_dt_date")] long dt_date = 0)
    {
      UniBizHttpRequest<UbRes<IList<PayContionView>>> contionListAsync = new UniBizHttpRequest<UbRes<IList<PayContionView>>>(HttpMethod.Get);
      contionListAsync.Resource = UbRestModelAttribute.GetBasePath<SupplierRestServer>() + "/PayContion/{payc_SiteID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      contionListAsync.Headers.Add("Send-Type", SendType);
      contionListAsync.SetSegment<UniBizHttpRequest<UbRes<IList<PayContionView>>>, long>((Expression<Func<long>>) (() => payc_SiteID));
      contionListAsync.SetSegment<UniBizHttpRequest<UbRes<IList<PayContionView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      contionListAsync.SetSegment<UniBizHttpRequest<UbRes<IList<PayContionView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (payc_ID > 0)
        contionListAsync.SetQuery<UniBizHttpRequest<UbRes<IList<PayContionView>>>, int>((Expression<Func<int>>) (() => payc_ID));
      if (payc_Turn > 0)
        contionListAsync.SetQuery<UniBizHttpRequest<UbRes<IList<PayContionView>>>, int>((Expression<Func<int>>) (() => payc_Turn));
      if (payc_Round > 0)
        contionListAsync.SetQuery<UniBizHttpRequest<UbRes<IList<PayContionView>>>, int>((Expression<Func<int>>) (() => payc_Round));
      if (payc_PaymentDay > 0)
        contionListAsync.SetQuery<UniBizHttpRequest<UbRes<IList<PayContionView>>>, int>((Expression<Func<int>>) (() => payc_PaymentDay));
      if (dt_date > 0L)
        contionListAsync.SetQuery<UniBizHttpRequest<UbRes<IList<PayContionView>>>, long>((Expression<Func<long>>) (() => dt_date));
      contionListAsync.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<PayContionView>>>>(MethodBase.GetCurrentMethod());
      return contionListAsync;
    }

    public static UniBizHttpRequest<UbRes<IList<PayContionView>>> PostPayContionList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_payc_SiteID")] long payc_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      IList<PayContionView> p_list)
    {
      UniBizHttpRequest<UbRes<IList<PayContionView>>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<IList<PayContionView>>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<SupplierRestServer>() + "/PayContion/{payc_SiteID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<PayContionView>>>, long>((Expression<Func<long>>) (() => payc_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<PayContionView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<PayContionView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<IList<PayContionView>>(p_list, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<PayContionView>>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<RebateConditionHeaderView>> GetRebateConditionHeader(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_rch_SiteID")] long rch_SiteID,
      [NameConvert("p_rch_Supplier")] int rch_Supplier,
      [NameConvert("p_rch_StoreCode")] int rch_StoreCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<RebateConditionHeaderView>> rebateConditionHeader = new UniBizHttpRequest<UbRes<RebateConditionHeaderView>>(HttpMethod.Get);
      rebateConditionHeader.Resource = UbRestModelAttribute.GetBasePath<SupplierRestServer>() + "/Supplier/{rch_SiteID}/{rch_Supplier}/RebateConditionHeader/{rch_StoreCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      rebateConditionHeader.Headers.Add("Send-Type", SendType);
      rebateConditionHeader.SetSegment<UniBizHttpRequest<UbRes<RebateConditionHeaderView>>, long>((Expression<Func<long>>) (() => rch_SiteID));
      rebateConditionHeader.SetSegment<UniBizHttpRequest<UbRes<RebateConditionHeaderView>>, int>((Expression<Func<int>>) (() => rch_Supplier));
      rebateConditionHeader.SetSegment<UniBizHttpRequest<UbRes<RebateConditionHeaderView>>, int>((Expression<Func<int>>) (() => rch_StoreCode));
      rebateConditionHeader.SetSegment<UniBizHttpRequest<UbRes<RebateConditionHeaderView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      rebateConditionHeader.SetSegment<UniBizHttpRequest<UbRes<RebateConditionHeaderView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      rebateConditionHeader.ReplaceByNameConverter<UniBizHttpRequest<UbRes<RebateConditionHeaderView>>>(MethodBase.GetCurrentMethod());
      return rebateConditionHeader;
    }

    public static UniBizHttpRequest<UbRes<RebateConditionHeaderView>> PostRebateConditionHeader(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_rch_SiteID")] long rch_SiteID,
      [NameConvert("p_rch_Supplier")] int rch_Supplier,
      [NameConvert("p_rch_StoreCode")] int rch_StoreCode,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      RebateConditionHeaderView pData)
    {
      UniBizHttpRequest<UbRes<RebateConditionHeaderView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<RebateConditionHeaderView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<SupplierRestServer>() + "/Supplier/{rch_SiteID}/{rch_Supplier}/RebateConditionHeader/{rch_StoreCode}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<RebateConditionHeaderView>>, long>((Expression<Func<long>>) (() => rch_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<RebateConditionHeaderView>>, int>((Expression<Func<int>>) (() => rch_Supplier));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<RebateConditionHeaderView>>, int>((Expression<Func<int>>) (() => rch_StoreCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<RebateConditionHeaderView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<RebateConditionHeaderView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<RebateConditionHeaderView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<RebateConditionHeaderView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<PayContionView>>> GetRebateConditionHeaderList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_rch_SiteID")] long rch_SiteID,
      [NameConvert("p_rch_Supplier")] int rch_Supplier,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_rch_SupplierIn")] string rch_SupplierIn = null,
      [NameConvert("p_rch_StoreCode")] int rch_StoreCode = 0,
      [NameConvert("p_rch_StoreCodeIn")] string rch_StoreCodeIn = null,
      [NameConvert("p_OrderByType")] int OrderByType = 0,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<PayContionView>>> conditionHeaderList = new UniBizHttpRequest<UbRes<IList<PayContionView>>>(HttpMethod.Get);
      conditionHeaderList.Resource = UbRestModelAttribute.GetBasePath<SupplierRestServer>() + "/Supplier/{rch_SiteID}/{rch_Supplier}/RebateConditionHeader/{work_pm_MenuCode}/{work_pmp_PropCode}";
      conditionHeaderList.Headers.Add("Send-Type", SendType);
      conditionHeaderList.SetSegment<UniBizHttpRequest<UbRes<IList<PayContionView>>>, long>((Expression<Func<long>>) (() => rch_SiteID));
      conditionHeaderList.SetSegment<UniBizHttpRequest<UbRes<IList<PayContionView>>>, int>((Expression<Func<int>>) (() => rch_Supplier));
      conditionHeaderList.SetSegment<UniBizHttpRequest<UbRes<IList<PayContionView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      conditionHeaderList.SetSegment<UniBizHttpRequest<UbRes<IList<PayContionView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (!string.IsNullOrEmpty(rch_SupplierIn))
        conditionHeaderList.SetQuery<UniBizHttpRequest<UbRes<IList<PayContionView>>>, string>((Expression<Func<string>>) (() => rch_SupplierIn));
      if (rch_StoreCode > 0)
        conditionHeaderList.SetQuery<UniBizHttpRequest<UbRes<IList<PayContionView>>>, int>((Expression<Func<int>>) (() => rch_StoreCode));
      if (!string.IsNullOrEmpty(rch_StoreCodeIn))
        conditionHeaderList.SetQuery<UniBizHttpRequest<UbRes<IList<PayContionView>>>, string>((Expression<Func<string>>) (() => rch_StoreCodeIn));
      if (OrderByType > 0)
        conditionHeaderList.SetQuery<UniBizHttpRequest<UbRes<IList<PayContionView>>>, int>((Expression<Func<int>>) (() => OrderByType));
      if (!string.IsNullOrEmpty(KeyWord))
        conditionHeaderList.SetQuery<UniBizHttpRequest<UbRes<IList<PayContionView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      conditionHeaderList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<PayContionView>>>>(MethodBase.GetCurrentMethod());
      return conditionHeaderList;
    }

    public static UniBizHttpRequest<UbRes<IList<PayContionView>>> PostRebateConditionHeaderList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_rch_SiteID")] long rch_SiteID,
      [NameConvert("p_rch_Supplier")] int rch_Supplier,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      IList<RebateConditionHeaderView> p_list)
    {
      UniBizHttpRequest<UbRes<IList<PayContionView>>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<IList<PayContionView>>>(HttpMethod.Get);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<SupplierRestServer>() + "/Supplier/{rch_SiteID}/{rch_Supplier}/RebateConditionHeader/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<PayContionView>>>, long>((Expression<Func<long>>) (() => rch_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<PayContionView>>>, int>((Expression<Func<int>>) (() => rch_Supplier));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<PayContionView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<PayContionView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<IList<RebateConditionHeaderView>>(p_list, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<PayContionView>>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<RebateConditionDetailView>> GetRebateConditionDetail(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_rcd_SiteID")] long rcd_SiteID,
      [NameConvert("p_rcd_Supplier")] int rcd_Supplier,
      [NameConvert("p_rcd_StoreCode")] int rcd_StoreCode,
      [NameConvert("p_rcd_Seq")] int rcd_Seq,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<RebateConditionDetailView>> rebateConditionDetail = new UniBizHttpRequest<UbRes<RebateConditionDetailView>>(HttpMethod.Get);
      rebateConditionDetail.Resource = UbRestModelAttribute.GetBasePath<SupplierRestServer>() + "/Supplier/{rcd_SiteID}/{rcd_Supplier}/RebateConditionDetail/{rcd_StoreCode}/{rcd_Seq}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      rebateConditionDetail.Headers.Add("Send-Type", SendType);
      rebateConditionDetail.SetSegment<UniBizHttpRequest<UbRes<RebateConditionDetailView>>, long>((Expression<Func<long>>) (() => rcd_SiteID));
      rebateConditionDetail.SetSegment<UniBizHttpRequest<UbRes<RebateConditionDetailView>>, int>((Expression<Func<int>>) (() => rcd_Supplier));
      rebateConditionDetail.SetSegment<UniBizHttpRequest<UbRes<RebateConditionDetailView>>, int>((Expression<Func<int>>) (() => rcd_StoreCode));
      rebateConditionDetail.SetSegment<UniBizHttpRequest<UbRes<RebateConditionDetailView>>, int>((Expression<Func<int>>) (() => rcd_Seq));
      rebateConditionDetail.SetSegment<UniBizHttpRequest<UbRes<RebateConditionDetailView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      rebateConditionDetail.SetSegment<UniBizHttpRequest<UbRes<RebateConditionDetailView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      rebateConditionDetail.ReplaceByNameConverter<UniBizHttpRequest<UbRes<RebateConditionDetailView>>>(MethodBase.GetCurrentMethod());
      return rebateConditionDetail;
    }

    public static UniBizHttpRequest<UbRes<RebateConditionDetailView>> PostRebateConditionDetail(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_rcd_SiteID")] long rcd_SiteID,
      [NameConvert("p_rcd_Supplier")] int rcd_Supplier,
      [NameConvert("p_rcd_StoreCode")] int rcd_StoreCode,
      [NameConvert("p_rcd_Seq")] int rcd_Seq,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      RebateConditionDetailView p_data)
    {
      UniBizHttpRequest<UbRes<RebateConditionDetailView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<RebateConditionDetailView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<SupplierRestServer>() + "/Supplier/{rcd_SiteID}/{rcd_Supplier}/RebateConditionDetail/{rcd_StoreCode}/{rcd_Seq}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<RebateConditionDetailView>>, long>((Expression<Func<long>>) (() => rcd_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<RebateConditionDetailView>>, int>((Expression<Func<int>>) (() => rcd_Supplier));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<RebateConditionDetailView>>, int>((Expression<Func<int>>) (() => rcd_StoreCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<RebateConditionDetailView>>, int>((Expression<Func<int>>) (() => rcd_Seq));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<RebateConditionDetailView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<RebateConditionDetailView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<RebateConditionDetailView>(p_data, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<RebateConditionDetailView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<RebateConditionDetailView>>> GetRebateConditionDetailList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_rcd_SiteID")] long rcd_SiteID,
      [NameConvert("p_rcd_Supplier")] int rcd_Supplier,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_rcd_SupplierIn")] string rcd_SupplierIn = null,
      [NameConvert("p_rcd_StoreCode")] int rcd_StoreCode = 0,
      [NameConvert("p_rcd_StoreCodeIn")] string rcd_StoreCodeIn = null,
      [NameConvert("p_rcd_Seq")] int rcd_Seq = 0,
      [NameConvert("p_OrderByType")] int OrderByType = 0,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<RebateConditionDetailView>>> conditionDetailList = new UniBizHttpRequest<UbRes<IList<RebateConditionDetailView>>>(HttpMethod.Get);
      conditionDetailList.Resource = UbRestModelAttribute.GetBasePath<SupplierRestServer>() + "/Supplier/{rcd_SiteID}/{rcd_Supplier}/RebateConditionDetail/{work_pm_MenuCode}/{work_pmp_PropCode}";
      conditionDetailList.Headers.Add("Send-Type", SendType);
      conditionDetailList.SetSegment<UniBizHttpRequest<UbRes<IList<RebateConditionDetailView>>>, long>((Expression<Func<long>>) (() => rcd_SiteID));
      conditionDetailList.SetSegment<UniBizHttpRequest<UbRes<IList<RebateConditionDetailView>>>, int>((Expression<Func<int>>) (() => rcd_Supplier));
      conditionDetailList.SetSegment<UniBizHttpRequest<UbRes<IList<RebateConditionDetailView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      conditionDetailList.SetSegment<UniBizHttpRequest<UbRes<IList<RebateConditionDetailView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (!string.IsNullOrEmpty(rcd_SupplierIn))
        conditionDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<RebateConditionDetailView>>>, string>((Expression<Func<string>>) (() => rcd_SupplierIn));
      if (rcd_StoreCode > 0)
        conditionDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<RebateConditionDetailView>>>, int>((Expression<Func<int>>) (() => rcd_StoreCode));
      if (!string.IsNullOrEmpty(rcd_StoreCodeIn))
        conditionDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<RebateConditionDetailView>>>, string>((Expression<Func<string>>) (() => rcd_StoreCodeIn));
      if (rcd_Seq > 0)
        conditionDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<RebateConditionDetailView>>>, int>((Expression<Func<int>>) (() => rcd_Seq));
      if (OrderByType > 0)
        conditionDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<RebateConditionDetailView>>>, int>((Expression<Func<int>>) (() => OrderByType));
      if (!string.IsNullOrEmpty(KeyWord))
        conditionDetailList.SetQuery<UniBizHttpRequest<UbRes<IList<RebateConditionDetailView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      conditionDetailList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<RebateConditionDetailView>>>>(MethodBase.GetCurrentMethod());
      return conditionDetailList;
    }

    public static UniBizHttpRequest<UbRes<IList<RebateConditionDetailView>>> PostRebateConditionDetailList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_rcd_SiteID")] long rcd_SiteID,
      [NameConvert("p_rcd_Supplier")] int rcd_Supplier,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      IList<RebateConditionDetailView> p_list)
    {
      UniBizHttpRequest<UbRes<IList<RebateConditionDetailView>>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<IList<RebateConditionDetailView>>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<SupplierRestServer>() + "/Supplier/{rcd_SiteID}/{rcd_Supplier}/RebateConditionDetail/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<RebateConditionDetailView>>>, long>((Expression<Func<long>>) (() => rcd_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<RebateConditionDetailView>>>, int>((Expression<Func<int>>) (() => rcd_Supplier));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<RebateConditionDetailView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<RebateConditionDetailView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<IList<RebateConditionDetailView>>(p_list, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<RebateConditionDetailView>>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<SupplierHistoryView>> GetSupplierHistory(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_suh_SiteID")] long suh_SiteID,
      [NameConvert("p_suh_ID")] int suh_ID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<SupplierHistoryView>> supplierHistory = new UniBizHttpRequest<UbRes<SupplierHistoryView>>(HttpMethod.Get);
      supplierHistory.Resource = UbRestModelAttribute.GetBasePath<SupplierRestServer>() + "/Supplier/{suh_SiteID}/SupplierHistory/{suh_ID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      supplierHistory.Headers.Add("Send-Type", SendType);
      supplierHistory.SetSegment<UniBizHttpRequest<UbRes<SupplierHistoryView>>, long>((Expression<Func<long>>) (() => suh_SiteID));
      supplierHistory.SetSegment<UniBizHttpRequest<UbRes<SupplierHistoryView>>, int>((Expression<Func<int>>) (() => suh_ID));
      supplierHistory.SetSegment<UniBizHttpRequest<UbRes<SupplierHistoryView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      supplierHistory.SetSegment<UniBizHttpRequest<UbRes<SupplierHistoryView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      supplierHistory.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SupplierHistoryView>>>(MethodBase.GetCurrentMethod());
      return supplierHistory;
    }

    public static UniBizHttpRequest<UbRes<SupplierHistoryView>> PostSupplierHistory(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_suh_SiteID")] long suh_SiteID,
      [NameConvert("p_suh_ID")] int suh_ID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      SupplierHistoryView p_data)
    {
      UniBizHttpRequest<UbRes<SupplierHistoryView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<SupplierHistoryView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<SupplierRestServer>() + "/Supplier/{suh_SiteID}/SupplierHistory/{suh_ID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<SupplierHistoryView>>, long>((Expression<Func<long>>) (() => suh_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<SupplierHistoryView>>, int>((Expression<Func<int>>) (() => suh_ID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<SupplierHistoryView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<SupplierHistoryView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<SupplierHistoryView>(p_data, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SupplierHistoryView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<SupplierHistoryView>>> GetSupplierHistoryList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_suh_SiteID")] long suh_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_suh_ID")] int suh_ID = 0,
      [NameConvert("p_suh_Supplier")] int suh_Supplier = 0,
      [NameConvert("p_suh_StoreCode")] int suh_StoreCode = 0,
      [NameConvert("p_suh_StoreCodeIn")] string suh_StoreCodeIn = null,
      [NameConvert("p_dt_date")] long dt_date = 0,
      [NameConvert("p_OrderByType")] int OrderByType = 0)
    {
      UniBizHttpRequest<UbRes<IList<SupplierHistoryView>>> supplierHistoryList = new UniBizHttpRequest<UbRes<IList<SupplierHistoryView>>>(HttpMethod.Get);
      supplierHistoryList.Resource = UbRestModelAttribute.GetBasePath<SupplierRestServer>() + "/Supplier/{suh_SiteID}/SupplierHistory/{work_pm_MenuCode}/{work_pmp_PropCode}";
      supplierHistoryList.Headers.Add("Send-Type", SendType);
      supplierHistoryList.SetSegment<UniBizHttpRequest<UbRes<IList<SupplierHistoryView>>>, long>((Expression<Func<long>>) (() => suh_SiteID));
      supplierHistoryList.SetSegment<UniBizHttpRequest<UbRes<IList<SupplierHistoryView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      supplierHistoryList.SetSegment<UniBizHttpRequest<UbRes<IList<SupplierHistoryView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (suh_ID > 0)
        supplierHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<SupplierHistoryView>>>, int>((Expression<Func<int>>) (() => suh_ID));
      if (suh_Supplier > 0)
        supplierHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<SupplierHistoryView>>>, int>((Expression<Func<int>>) (() => suh_Supplier));
      if (suh_StoreCode > 0)
        supplierHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<SupplierHistoryView>>>, int>((Expression<Func<int>>) (() => suh_StoreCode));
      if (!string.IsNullOrEmpty(suh_StoreCodeIn))
        supplierHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<SupplierHistoryView>>>, string>((Expression<Func<string>>) (() => suh_StoreCodeIn));
      if (dt_date > 0L)
        supplierHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<SupplierHistoryView>>>, long>((Expression<Func<long>>) (() => dt_date));
      if (OrderByType > 0)
        supplierHistoryList.SetQuery<UniBizHttpRequest<UbRes<IList<SupplierHistoryView>>>, int>((Expression<Func<int>>) (() => OrderByType));
      supplierHistoryList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<SupplierHistoryView>>>>(MethodBase.GetCurrentMethod());
      return supplierHistoryList;
    }

    public static UniBizHttpRequest<UbRes<IList<SupplierHistoryView>>> PostSupplierHistoryList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_suh_SiteID")] long suh_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      IList<SupplierHistoryView> p_list)
    {
      UniBizHttpRequest<UbRes<IList<SupplierHistoryView>>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<IList<SupplierHistoryView>>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<SupplierRestServer>() + "/Supplier/{suh_SiteID}/SupplierHistory/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<SupplierHistoryView>>>, long>((Expression<Func<long>>) (() => suh_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<SupplierHistoryView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<SupplierHistoryView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<IList<SupplierHistoryView>>(p_list, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<SupplierHistoryView>>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<SupplierHistoryPack>> PostSupplierHistoryPack(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_suh_SiteID")] long suh_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      SupplierHistoryPack p_pack)
    {
      UniBizHttpRequest<UbRes<SupplierHistoryPack>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<SupplierHistoryPack>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<SupplierRestServer>() + "/Supplier/{suh_SiteID}/SupplierHistory/Pack/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<SupplierHistoryPack>>, long>((Expression<Func<long>>) (() => suh_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<SupplierHistoryPack>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<SupplierHistoryPack>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<SupplierHistoryPack>(p_pack, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SupplierHistoryPack>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<SupplierAutoDeductionView>> GetSupplierAutoDeduction(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_suad_SiteID")] long suad_SiteID,
      [NameConvert("p_suad_SupplierHistory")] int suad_SupplierHistory,
      [NameConvert("p_suad_Seq")] int suad_Seq,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<SupplierAutoDeductionView>> supplierAutoDeduction = new UniBizHttpRequest<UbRes<SupplierAutoDeductionView>>(HttpMethod.Get);
      supplierAutoDeduction.Resource = UbRestModelAttribute.GetBasePath<SupplierRestServer>() + "/Supplier/{suad_SiteID}/AutoDeduction/{suad_SupplierHistory}/{suad_Seq}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      supplierAutoDeduction.Headers.Add("Send-Type", SendType);
      supplierAutoDeduction.SetSegment<UniBizHttpRequest<UbRes<SupplierAutoDeductionView>>, long>((Expression<Func<long>>) (() => suad_SiteID));
      supplierAutoDeduction.SetSegment<UniBizHttpRequest<UbRes<SupplierAutoDeductionView>>, int>((Expression<Func<int>>) (() => suad_SupplierHistory));
      supplierAutoDeduction.SetSegment<UniBizHttpRequest<UbRes<SupplierAutoDeductionView>>, int>((Expression<Func<int>>) (() => suad_Seq));
      supplierAutoDeduction.SetSegment<UniBizHttpRequest<UbRes<SupplierAutoDeductionView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      supplierAutoDeduction.SetSegment<UniBizHttpRequest<UbRes<SupplierAutoDeductionView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      supplierAutoDeduction.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SupplierAutoDeductionView>>>(MethodBase.GetCurrentMethod());
      return supplierAutoDeduction;
    }

    public static UniBizHttpRequest<UbRes<SupplierAutoDeductionView>> PostSupplierAutoDeduction(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_suad_SiteID")] long suad_SiteID,
      [NameConvert("p_suad_SupplierHistory")] int suad_SupplierHistory,
      [NameConvert("p_suad_Seq")] int suad_Seq,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      SupplierAutoDeductionView pData)
    {
      UniBizHttpRequest<UbRes<SupplierAutoDeductionView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<SupplierAutoDeductionView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<SupplierRestServer>() + "/Supplier/{suad_SiteID}/AutoDeduction/{suad_SupplierHistory}/{suad_Seq}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<SupplierAutoDeductionView>>, long>((Expression<Func<long>>) (() => suad_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<SupplierAutoDeductionView>>, int>((Expression<Func<int>>) (() => suad_SupplierHistory));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<SupplierAutoDeductionView>>, int>((Expression<Func<int>>) (() => suad_Seq));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<SupplierAutoDeductionView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<SupplierAutoDeductionView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<SupplierAutoDeductionView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SupplierAutoDeductionView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<SupplierAutoDeductionView>> DeleteSupplierAutoDeduction(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_suad_SiteID")] long suad_SiteID,
      [NameConvert("p_suad_SupplierHistory")] int suad_SupplierHistory,
      [NameConvert("p_suad_Seq")] int suad_Seq,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<SupplierAutoDeductionView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<SupplierAutoDeductionView>>(HttpMethod.Delete);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<SupplierRestServer>() + "/Employee/{suad_SiteID}/AutoDeduction/{suad_SupplierHistory}/{suad_Seq}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<SupplierAutoDeductionView>>, long>((Expression<Func<long>>) (() => suad_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<SupplierAutoDeductionView>>, int>((Expression<Func<int>>) (() => suad_SupplierHistory));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<SupplierAutoDeductionView>>, int>((Expression<Func<int>>) (() => suad_Seq));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<SupplierAutoDeductionView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<SupplierAutoDeductionView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SupplierAutoDeductionView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<SupplierAutoDeductionView>>> GetSupplierAutoDeductionList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_suad_SiteID")] long suad_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_suad_SupplierHistory")] int suad_SupplierHistory = 0,
      [NameConvert("p_suad_Seq")] int suad_Seq = 0,
      [NameConvert("p_OrderByType")] int OrderByType = 0)
    {
      UniBizHttpRequest<UbRes<IList<SupplierAutoDeductionView>>> autoDeductionList = new UniBizHttpRequest<UbRes<IList<SupplierAutoDeductionView>>>(HttpMethod.Get);
      autoDeductionList.Resource = UbRestModelAttribute.GetBasePath<SupplierRestServer>() + "/Supplier/{suad_SiteID}/AutoDeduction/{work_pm_MenuCode}/{work_pmp_PropCode}";
      autoDeductionList.Headers.Add("Send-Type", SendType);
      autoDeductionList.SetSegment<UniBizHttpRequest<UbRes<IList<SupplierAutoDeductionView>>>, long>((Expression<Func<long>>) (() => suad_SiteID));
      autoDeductionList.SetSegment<UniBizHttpRequest<UbRes<IList<SupplierAutoDeductionView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      autoDeductionList.SetSegment<UniBizHttpRequest<UbRes<IList<SupplierAutoDeductionView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (suad_SupplierHistory > 0)
        autoDeductionList.SetQuery<UniBizHttpRequest<UbRes<IList<SupplierAutoDeductionView>>>, int>((Expression<Func<int>>) (() => suad_SupplierHistory));
      if (suad_Seq > 0)
        autoDeductionList.SetQuery<UniBizHttpRequest<UbRes<IList<SupplierAutoDeductionView>>>, int>((Expression<Func<int>>) (() => suad_Seq));
      if (OrderByType > 0)
        autoDeductionList.SetQuery<UniBizHttpRequest<UbRes<IList<SupplierAutoDeductionView>>>, int>((Expression<Func<int>>) (() => OrderByType));
      autoDeductionList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<SupplierAutoDeductionView>>>>(MethodBase.GetCurrentMethod());
      return autoDeductionList;
    }

    public static UniBizHttpRequest<UbRes<IList<SupplierAutoDeductionView>>> PostSupplierAuthDeducktionList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_suad_SiteID")] long suad_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      IList<SupplierAutoDeductionView> p_list)
    {
      UniBizHttpRequest<UbRes<IList<SupplierAutoDeductionView>>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<IList<SupplierAutoDeductionView>>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<SupplierRestServer>() + "/Supplier/{suad_SiteID}/AutoDeduction/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<SupplierAutoDeductionView>>>, long>((Expression<Func<long>>) (() => suad_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<SupplierAutoDeductionView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<SupplierAutoDeductionView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<IList<SupplierAutoDeductionView>>(p_list, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<SupplierAutoDeductionView>>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<SupplierAutoDeductionView>>> DeleteSupplierAutoDeductionList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_suad_SiteID")] long suad_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      IList<SupplierAutoDeductionView> p_list)
    {
      UniBizHttpRequest<UbRes<IList<SupplierAutoDeductionView>>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<IList<SupplierAutoDeductionView>>>(HttpMethod.Delete);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<SupplierRestServer>() + "/Employee/{suad_SiteID}/AutoDeduction/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<SupplierAutoDeductionView>>>, long>((Expression<Func<long>>) (() => suad_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<SupplierAutoDeductionView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<IList<SupplierAutoDeductionView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<IList<SupplierAutoDeductionView>>(p_list, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<SupplierAutoDeductionView>>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<SupplierImageView>> GetSupplierImage(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sui_SiteID")] long sui_SiteID,
      [NameConvert("p_sui_ID")] int sui_ID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_is_thumb_image")] bool is_thumb_image = false,
      [NameConvert("p_is_origin_image")] bool is_origin_image = false)
    {
      UniBizHttpRequest<UbRes<SupplierImageView>> supplierImage = new UniBizHttpRequest<UbRes<SupplierImageView>>(HttpMethod.Get);
      supplierImage.Resource = UbRestModelAttribute.GetBasePath<SupplierRestServer>() + "/Supplier/{sui_SiteID}/Image/{sui_ID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      supplierImage.Headers.Add("Send-Type", SendType);
      supplierImage.SetSegment<UniBizHttpRequest<UbRes<SupplierImageView>>, long>((Expression<Func<long>>) (() => sui_SiteID));
      supplierImage.SetSegment<UniBizHttpRequest<UbRes<SupplierImageView>>, int>((Expression<Func<int>>) (() => sui_ID));
      supplierImage.SetSegment<UniBizHttpRequest<UbRes<SupplierImageView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      supplierImage.SetSegment<UniBizHttpRequest<UbRes<SupplierImageView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      supplierImage.SetQuery<UniBizHttpRequest<UbRes<SupplierImageView>>, bool>((Expression<Func<bool>>) (() => is_thumb_image));
      supplierImage.SetQuery<UniBizHttpRequest<UbRes<SupplierImageView>>, bool>((Expression<Func<bool>>) (() => is_origin_image));
      supplierImage.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SupplierImageView>>>(MethodBase.GetCurrentMethod());
      return supplierImage;
    }

    public static UniBizHttpRequest<UbRes<SupplierImageView>> DeleteSupplierImage(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sui_SiteID")] long sui_SiteID,
      [NameConvert("p_sui_ID")] int sui_ID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<SupplierImageView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<SupplierImageView>>(HttpMethod.Delete);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<SupplierRestServer>() + "/Supplier/{sui_SiteID}/Image/{sui_ID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<SupplierImageView>>, long>((Expression<Func<long>>) (() => sui_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<SupplierImageView>>, int>((Expression<Func<int>>) (() => sui_ID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<SupplierImageView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<SupplierImageView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SupplierImageView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<SupplierImageView>> PostEmpImageFile(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sui_SiteID")] long sui_SiteID,
      [NameConvert("p_sui_ID")] int sui_ID,
      [NameConvert("p_sui_Supplier")] int sui_Supplier,
      [NameConvert("p_sui_Kind")] int sui_Kind,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      string fileName,
      Stream dataStream)
    {
      UniBizHttpRequest<UbRes<SupplierImageView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<SupplierImageView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<SupplierRestServer>() + "/Supplier/{sui_SiteID}/Image/{sui_ID}/{sui_Supplier}/{sui_Kind}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<SupplierImageView>>, long>((Expression<Func<long>>) (() => sui_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<SupplierImageView>>, int>((Expression<Func<int>>) (() => sui_ID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<SupplierImageView>>, int>((Expression<Func<int>>) (() => sui_Supplier));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<SupplierImageView>>, int>((Expression<Func<int>>) (() => sui_Kind));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<SupplierImageView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<SupplierImageView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) new MultipartFormDataContent()
      {
        {
          (HttpContent) new StreamContent(dataStream),
          "p_File",
          fileName
        }
      };
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SupplierImageView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<SupplierImageView>> PostEmpImageFile(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sui_SiteID")] long sui_SiteID,
      [NameConvert("p_sui_ID")] int sui_ID,
      [NameConvert("p_sui_Supplier")] int sui_Supplier,
      [NameConvert("p_sui_Kind")] int sui_Kind,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      string fileName,
      byte[] fileData)
    {
      UniBizHttpRequest<UbRes<SupplierImageView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<SupplierImageView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<SupplierRestServer>() + "/Supplier/{sui_SiteID}/Image/{sui_ID}/{sui_Supplier}/{sui_Kind}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<SupplierImageView>>, long>((Expression<Func<long>>) (() => sui_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<SupplierImageView>>, int>((Expression<Func<int>>) (() => sui_ID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<SupplierImageView>>, int>((Expression<Func<int>>) (() => sui_Supplier));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<SupplierImageView>>, int>((Expression<Func<int>>) (() => sui_Kind));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<SupplierImageView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<SupplierImageView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) new MultipartFormDataContent()
      {
        {
          (HttpContent) new ByteArrayContent(fileData),
          "p_File",
          fileName
        }
      };
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<SupplierImageView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest GetSupplierImageThumb(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sui_SiteID")] long sui_SiteID,
      [NameConvert("p_sui_ID")] int sui_ID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest supplierImageThumb = new UniBizHttpRequest(HttpMethod.Get);
      supplierImageThumb.Resource = UbRestModelAttribute.GetBasePath<SupplierRestServer>() + "/Supplier/{sui_SiteID}/Image/{sui_ID}/Thumb/{work_pm_MenuCode}/{work_pmp_PropCode}";
      supplierImageThumb.Headers.Add("Send-Type", SendType);
      supplierImageThumb.SetSegment<UniBizHttpRequest, long>((Expression<Func<long>>) (() => sui_SiteID));
      supplierImageThumb.SetSegment<UniBizHttpRequest, int>((Expression<Func<int>>) (() => sui_ID));
      supplierImageThumb.SetSegment<UniBizHttpRequest, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      supplierImageThumb.SetSegment<UniBizHttpRequest, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      supplierImageThumb.ReplaceByNameConverter<UniBizHttpRequest>(MethodBase.GetCurrentMethod());
      return supplierImageThumb;
    }

    public static UniBizHttpRequest GetSupplierImageOrigin(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sui_SiteID")] long sui_SiteID,
      [NameConvert("p_sui_ID")] int sui_ID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest supplierImageOrigin = new UniBizHttpRequest(HttpMethod.Get);
      supplierImageOrigin.Resource = UbRestModelAttribute.GetBasePath<SupplierRestServer>() + "/Supplier/{sui_SiteID}/Image/{sui_ID}/Origin/{work_pm_MenuCode}/{work_pmp_PropCode}";
      supplierImageOrigin.Headers.Add("Send-Type", SendType);
      supplierImageOrigin.SetSegment<UniBizHttpRequest, long>((Expression<Func<long>>) (() => sui_SiteID));
      supplierImageOrigin.SetSegment<UniBizHttpRequest, int>((Expression<Func<int>>) (() => sui_ID));
      supplierImageOrigin.SetSegment<UniBizHttpRequest, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      supplierImageOrigin.SetSegment<UniBizHttpRequest, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      supplierImageOrigin.ReplaceByNameConverter<UniBizHttpRequest>(MethodBase.GetCurrentMethod());
      return supplierImageOrigin;
    }

    public static UniBizHttpRequest GetSupplierImageFile(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_sui_SiteID")] long sui_SiteID,
      [NameConvert("p_sui_ID")] int sui_ID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest supplierImageFile = new UniBizHttpRequest(HttpMethod.Get);
      supplierImageFile.Resource = UbRestModelAttribute.GetBasePath<SupplierRestServer>() + "/Supplier/{sui_SiteID}/Image/{sui_ID}/File/{work_pm_MenuCode}/{work_pmp_PropCode}";
      supplierImageFile.Headers.Add("Send-Type", SendType);
      supplierImageFile.SetSegment<UniBizHttpRequest, long>((Expression<Func<long>>) (() => sui_SiteID));
      supplierImageFile.SetSegment<UniBizHttpRequest, int>((Expression<Func<int>>) (() => sui_ID));
      supplierImageFile.SetSegment<UniBizHttpRequest, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      supplierImageFile.SetSegment<UniBizHttpRequest, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      supplierImageFile.ReplaceByNameConverter<UniBizHttpRequest>(MethodBase.GetCurrentMethod());
      return supplierImageFile;
    }
  }
}
