// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Category.CategoryRestServer
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Json;
using System.Reflection;
using UniBiz.Bo.Models.UbRest;
using UniinfoNet;
using UniinfoNet.Http.UniBiz;

namespace UniBiz.Bo.Models.UniBase.Category
{
  [UbRestModel("/Code/Category", TableCodeType.Category, HeaderPath = "")]
  public class CategoryRestServer : BindableBase
  {
    public static UniBizHttpRequest<UbRes<CategoryView>> GetCategory(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ctg_SiteID")] long ctg_SiteID,
      [NameConvert("p_ctg_ID")] int ctg_ID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode)
    {
      UniBizHttpRequest<UbRes<CategoryView>> category = new UniBizHttpRequest<UbRes<CategoryView>>(HttpMethod.Get);
      category.Resource = UbRestModelAttribute.GetBasePath<CategoryRestServer>() + "/{ctg_SiteID}/{ctg_ID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      category.Headers.Add("Send-Type", SendType);
      category.SetSegment<UniBizHttpRequest<UbRes<CategoryView>>, long>((Expression<Func<long>>) (() => ctg_SiteID));
      category.SetSegment<UniBizHttpRequest<UbRes<CategoryView>>, int>((Expression<Func<int>>) (() => ctg_ID));
      category.SetSegment<UniBizHttpRequest<UbRes<CategoryView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      category.SetSegment<UniBizHttpRequest<UbRes<CategoryView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      category.ReplaceByNameConverter<UniBizHttpRequest<UbRes<CategoryView>>>(MethodBase.GetCurrentMethod());
      return category;
    }

    public static UniBizHttpRequest<UbRes<CategoryView>> PostCategory(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ctg_SiteID")] long ctg_SiteID,
      [NameConvert("p_ctg_ID")] int ctg_ID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      CategoryView pData)
    {
      UniBizHttpRequest<UbRes<CategoryView>> uniBizHttpRequest = new UniBizHttpRequest<UbRes<CategoryView>>(HttpMethod.Post);
      uniBizHttpRequest.Resource = UbRestModelAttribute.GetBasePath<CategoryRestServer>() + "/{ctg_SiteID}/{ctg_ID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      uniBizHttpRequest.Headers.Add("Send-Type", SendType);
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CategoryView>>, long>((Expression<Func<long>>) (() => ctg_SiteID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CategoryView>>, int>((Expression<Func<int>>) (() => ctg_ID));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CategoryView>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      uniBizHttpRequest.SetSegment<UniBizHttpRequest<UbRes<CategoryView>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      uniBizHttpRequest.Content = (HttpContent) JsonContent.Create<CategoryView>(pData, options: UniBizHttpClient.DefaultJsonOption);
      uniBizHttpRequest.ReplaceByNameConverter<UniBizHttpRequest<UbRes<CategoryView>>>(MethodBase.GetCurrentMethod());
      return uniBizHttpRequest;
    }

    public static UniBizHttpRequest<UbRes<IList<CategoryView>>> GetCategoryList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ctg_SiteID")] long ctg_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_ctg_ID")] int ctg_ID = 0,
      [NameConvert("p_ctg_CategoryName")] string ctg_CategoryName = null,
      [NameConvert("p_ctg_ViewCode")] string ctg_ViewCode = null,
      [NameConvert("p_ctg_UseYn")] string ctg_UseYn = null,
      [NameConvert("p_ctg_Depth")] int ctg_Depth = 0,
      [NameConvert("p_ctg_ParentsID")] int ctg_ParentsID = 0,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<IList<CategoryView>>> categoryList = new UniBizHttpRequest<UbRes<IList<CategoryView>>>(HttpMethod.Get);
      categoryList.Resource = UbRestModelAttribute.GetBasePath<CategoryRestServer>() + "/{ctg_SiteID}/{work_pm_MenuCode}/{work_pmp_PropCode}";
      categoryList.Headers.Add("Send-Type", SendType);
      categoryList.SetSegment<UniBizHttpRequest<UbRes<IList<CategoryView>>>, long>((Expression<Func<long>>) (() => ctg_SiteID));
      categoryList.SetSegment<UniBizHttpRequest<UbRes<IList<CategoryView>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      categoryList.SetSegment<UniBizHttpRequest<UbRes<IList<CategoryView>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (ctg_ID > 0)
        categoryList.SetQuery<UniBizHttpRequest<UbRes<IList<CategoryView>>>, int>((Expression<Func<int>>) (() => ctg_ID));
      if (!string.IsNullOrEmpty(ctg_CategoryName))
        categoryList.SetQuery<UniBizHttpRequest<UbRes<IList<CategoryView>>>, string>((Expression<Func<string>>) (() => ctg_CategoryName));
      if (!string.IsNullOrEmpty(ctg_ViewCode))
        categoryList.SetQuery<UniBizHttpRequest<UbRes<IList<CategoryView>>>, string>((Expression<Func<string>>) (() => ctg_ViewCode));
      if (!string.IsNullOrEmpty(ctg_UseYn))
        categoryList.SetQuery<UniBizHttpRequest<UbRes<IList<CategoryView>>>, string>((Expression<Func<string>>) (() => ctg_UseYn));
      if (ctg_Depth > 0)
        categoryList.SetQuery<UniBizHttpRequest<UbRes<IList<CategoryView>>>, int>((Expression<Func<int>>) (() => ctg_Depth));
      if (ctg_ParentsID > 0)
        categoryList.SetQuery<UniBizHttpRequest<UbRes<IList<CategoryView>>>, int>((Expression<Func<int>>) (() => ctg_ParentsID));
      if (!string.IsNullOrEmpty(KeyWord))
        categoryList.SetQuery<UniBizHttpRequest<UbRes<IList<CategoryView>>>, string>((Expression<Func<string>>) (() => KeyWord));
      categoryList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<CategoryView>>>>(MethodBase.GetCurrentMethod());
      return categoryList;
    }

    public static UniBizHttpRequest<UbRes<CategoryLevel>> GetCategoryDepth(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ctg_SiteID")] long ctg_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_ctg_UseYn")] string ctg_UseYn = null,
      [NameConvert("p_KeyWord")] string KeyWord = null)
    {
      UniBizHttpRequest<UbRes<CategoryLevel>> categoryDepth = new UniBizHttpRequest<UbRes<CategoryLevel>>(HttpMethod.Get);
      categoryDepth.Resource = UbRestModelAttribute.GetBasePath<CategoryRestServer>() + "/{ctg_SiteID}/Depth/{work_pm_MenuCode}/{work_pmp_PropCode}";
      categoryDepth.Headers.Add("Send-Type", SendType);
      categoryDepth.SetSegment<UniBizHttpRequest<UbRes<CategoryLevel>>, long>((Expression<Func<long>>) (() => ctg_SiteID));
      categoryDepth.SetSegment<UniBizHttpRequest<UbRes<CategoryLevel>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      categoryDepth.SetSegment<UniBizHttpRequest<UbRes<CategoryLevel>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (!string.IsNullOrEmpty(ctg_UseYn))
        categoryDepth.SetQuery<UniBizHttpRequest<UbRes<CategoryLevel>>, string>((Expression<Func<string>>) (() => ctg_UseYn));
      if (!string.IsNullOrEmpty(KeyWord))
        categoryDepth.SetQuery<UniBizHttpRequest<UbRes<CategoryLevel>>, string>((Expression<Func<string>>) (() => KeyWord));
      categoryDepth.ReplaceByNameConverter<UniBizHttpRequest<UbRes<CategoryLevel>>>(MethodBase.GetCurrentMethod());
      return categoryDepth;
    }

    public static UniBizHttpRequest<UbRes<IList<GoodsCountByCategory>>> GetGoodsCountByCategoryList(
      [NameConvert("Send-Type")] string SendType,
      [NameConvert("p_ctg_SiteID")] long ctg_SiteID,
      [NameConvert("p_work_pm_MenuCode")] int work_pm_MenuCode,
      [NameConvert("p_work_pmp_PropCode")] int work_pmp_PropCode,
      [NameConvert("p_dt_date")] long dt_date = 0,
      [NameConvert("p_si_StoreCode")] int si_StoreCode = 0,
      [NameConvert("p_su_Supplier")] int su_Supplier = 0,
      [NameConvert("p_ctg_lv1_ID")] int ctg_lv1_ID = 0,
      [NameConvert("p_ctg_lv2_ID")] int ctg_lv2_ID = 0,
      [NameConvert("p_ctg_ID")] int ctg_ID = 0,
      [NameConvert("p_ctg_Depth")] int ctg_Depth = 1,
      [NameConvert("p_mk_MakerCode")] int mk_MakerCode = 0,
      [NameConvert("p_br_BrandCode")] int br_BrandCode = 0)
    {
      UniBizHttpRequest<UbRes<IList<GoodsCountByCategory>>> countByCategoryList = new UniBizHttpRequest<UbRes<IList<GoodsCountByCategory>>>(HttpMethod.Get);
      countByCategoryList.Resource = UbRestModelAttribute.GetBasePath<CategoryRestServer>() + "/{ctg_SiteID}/Count/Goods/{work_pm_MenuCode}/{work_pmp_PropCode}";
      countByCategoryList.Headers.Add("Send-Type", SendType);
      countByCategoryList.SetSegment<UniBizHttpRequest<UbRes<IList<GoodsCountByCategory>>>, long>((Expression<Func<long>>) (() => ctg_SiteID));
      countByCategoryList.SetSegment<UniBizHttpRequest<UbRes<IList<GoodsCountByCategory>>>, int>((Expression<Func<int>>) (() => work_pm_MenuCode));
      countByCategoryList.SetSegment<UniBizHttpRequest<UbRes<IList<GoodsCountByCategory>>>, int>((Expression<Func<int>>) (() => work_pmp_PropCode));
      if (dt_date > 0L)
        countByCategoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsCountByCategory>>>, long>((Expression<Func<long>>) (() => dt_date));
      if (si_StoreCode > 0)
        countByCategoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsCountByCategory>>>, int>((Expression<Func<int>>) (() => si_StoreCode));
      if (su_Supplier > 0)
        countByCategoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsCountByCategory>>>, int>((Expression<Func<int>>) (() => su_Supplier));
      if (ctg_lv1_ID > 0)
        countByCategoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsCountByCategory>>>, int>((Expression<Func<int>>) (() => ctg_lv1_ID));
      if (ctg_lv2_ID > 0)
        countByCategoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsCountByCategory>>>, int>((Expression<Func<int>>) (() => ctg_lv2_ID));
      if (ctg_ID > 0)
        countByCategoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsCountByCategory>>>, int>((Expression<Func<int>>) (() => ctg_ID));
      if (ctg_Depth > 0)
        countByCategoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsCountByCategory>>>, int>((Expression<Func<int>>) (() => ctg_Depth));
      if (mk_MakerCode > 0)
        countByCategoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsCountByCategory>>>, int>((Expression<Func<int>>) (() => mk_MakerCode));
      if (br_BrandCode > 0)
        countByCategoryList.SetQuery<UniBizHttpRequest<UbRes<IList<GoodsCountByCategory>>>, int>((Expression<Func<int>>) (() => br_BrandCode));
      countByCategoryList.ReplaceByNameConverter<UniBizHttpRequest<UbRes<IList<GoodsCountByCategory>>>>(MethodBase.GetCurrentMethod());
      return countByCategoryList;
    }
  }
}
