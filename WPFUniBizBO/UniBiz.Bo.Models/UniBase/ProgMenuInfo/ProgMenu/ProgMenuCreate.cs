// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenu.ProgMenuCreate
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
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.Interface;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenu
{
  public class ProgMenuCreate : TProgMenu, ICreateTable
  {
    private bool InitTableBizBOCampaign(long pSiteID)
    {
      int num1 = 8000;
      TProgMenu pData1 = this.OleDB.Create<TProgMenu>();
      pData1.pm_MenuCode = 1601;
      int pmMenuCode = pData1.pm_MenuCode;
      pData1.pm_SiteID = pSiteID;
      pData1.pm_ProgKind = 26;
      pData1.pm_MenuSortNo = "08000000";
      pData1.pm_MenuName = "캠페인";
      pData1.pm_GroupID = num1;
      pData1.pm_ProgID = "캠페인";
      pData1.pm_ProgTitle = "캠페인";
      pData1.pm_ViewType = 1;
      pData1.pm_MenuDepth = 1;
      pData1.pm_IconUrl = "price_manage";
      if (!this.OleDB.Execute(pData1.InsertQuery()))
        return false;
      int p_pm_GroupID1 = num1 + 1;
      int num2;
      TProgMenu pData2 = this.InitTableBizSMLv2(pData1, num2 = pmMenuCode + 1, "08100000", "등록", p_pm_GroupID1, "등록", "등록", "info");
      if (!this.OleDB.Execute(pData2.InsertQuery()))
        return false;
      int p_pm_GroupID2 = p_pm_GroupID1 + 1;
      int num3;
      TProgMenu pData3 = this.InitTableBizSMLv3(pData2, num3 = num2 + 1, "08110000", "캠페인", p_pm_GroupID2, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "캠페인", "campaign");
      if (!this.OleDB.Execute(pData3.InsertQuery()))
        return false;
      string str1 = "UniBizBO.ViewModels.Page.UniSales.Campaign.Reg.Campaign.";
      int num4;
      TProgMenu pData4 = this.InitTableBizSMLv4(pData3, num4 = num3 + 1, "08110010", "캠페인", p_pm_GroupID2, str1 + "CampaignPageVM", "캠페인", "campaign");
      if (!this.OleDB.Execute(pData4.InsertQuery()))
        return false;
      int p_pm_GroupID3 = p_pm_GroupID2 + 1;
      int num5;
      TProgMenu pData5 = this.InitTableBizSMLv3(pData4, num5 = num4 + 1, "08120000", "프로모션", p_pm_GroupID3, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "프로모션", "campaign");
      if (!this.OleDB.Execute(pData5.InsertQuery()))
        return false;
      string str2 = "UniBizBO.ViewModels.Page.UniSales.Campaign.Reg.Promotion.";
      int num6;
      TProgMenu pData6 = this.InitTableBizSMLv4(pData5, num6 = num5 + 1, "08120010", "프로모션", p_pm_GroupID3, str2 + "PromotionPageVM", "프로모션", "campaign");
      if (!this.OleDB.Execute(pData6.InsertQuery()))
        return false;
      int p_pm_GroupID4 = p_pm_GroupID3 + 1;
      int num7;
      TProgMenu pData7 = this.InitTableBizSMLv3(pData6, num7 = num6 + 1, "08130000", "쿠폰", p_pm_GroupID4, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "쿠폰", "campaign");
      if (!this.OleDB.Execute(pData7.InsertQuery()))
        return false;
      string str3 = "UniBizBO.ViewModels.Page.UniSales.Campaign.Reg.Coupon.";
      int num8;
      TProgMenu pData8 = this.InitTableBizSMLv4(pData7, num8 = num7 + 1, "08130010", "쿠폰", p_pm_GroupID4, str3 + "CouponPageVM", "쿠폰", "campaign");
      if (!this.OleDB.Execute(pData8.InsertQuery()))
        return false;
      int p_pm_GroupID5 = p_pm_GroupID4 + 1;
      int num9;
      TProgMenu pData9 = this.InitTableBizSMLv2(pData8, num9 = num8 + 1, "08200000", "조회", p_pm_GroupID5, "조회", "조회", "member");
      if (!this.OleDB.Execute(pData9.InsertQuery()))
        return false;
      int p_pm_GroupID6 = p_pm_GroupID5 + 1;
      int num10;
      TProgMenu pData10 = this.InitTableBizSMLv3(pData9, num10 = num9 + 1, "08210000", "기본조회", p_pm_GroupID6, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "기본조회", "campaign");
      if (!this.OleDB.Execute(pData10.InsertQuery()))
        return false;
      string str4 = "UniBizBO.ViewModels.Page.UniSales.Campaign.Inq.Basic.";
      int num11;
      TProgMenu pData11 = this.InitTableBizSMLv4(pData10, num11 = num10 + 1, "08210010", "기본", p_pm_GroupID6, str4 + "CampaignInqBasicBasicPageVM", "기본조회(기본)", "member_info");
      int num12;
      return this.OleDB.Execute(pData11.InsertQuery()) && this.OleDB.Execute(this.InitTableBizSMLv4(pData11, num12 = num11 + 1, "08210020", "캠페인별", p_pm_GroupID6, str4 + "CampaignInqBasicCampaignPageVM", "기본조회(캠페인별)", "member").InsertQuery());
    }

    private bool InitTableBizBOCode(long pSiteID)
    {
      int num1 = 3000;
      TProgMenu pData1 = this.OleDB.Create<TProgMenu>();
      pData1.pm_MenuCode = 1101;
      int pmMenuCode = pData1.pm_MenuCode;
      pData1.pm_SiteID = pSiteID;
      pData1.pm_ProgKind = 26;
      pData1.pm_MenuSortNo = "03000000";
      pData1.pm_MenuName = "코드관리";
      pData1.pm_GroupID = num1;
      pData1.pm_ProgID = "코드관리";
      pData1.pm_ProgTitle = "코드관리";
      pData1.pm_ViewType = 1;
      pData1.pm_MenuDepth = 1;
      pData1.pm_IconUrl = "invoice";
      if (!this.OleDB.Execute(pData1.InsertQuery()))
        return false;
      int p_pm_GroupID1 = num1 + 1;
      int num2;
      TProgMenu pData2 = this.InitTableBizSMLv2(pData1, num2 = pmMenuCode + 1, "03100000", "기초정보", p_pm_GroupID1, "기초정보", "기초정보", "info");
      if (!this.OleDB.Execute(pData2.InsertQuery()))
        return false;
      int p_pm_GroupID2 = p_pm_GroupID1 + 1;
      int num3;
      TProgMenu pData3 = this.InitTableBizSMLv3(pData2, num3 = num2 + 1, "03110000", "지점", p_pm_GroupID2, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "지점 등록 현황", "site");
      if (!this.OleDB.Execute(pData3.InsertQuery()))
        return false;
      string str1 = "UniBizBO.ViewModels.Page.UniSales.Code.BasicInfo.Store.";
      int num4;
      TProgMenu pData4 = this.InitTableBizSMLv4(pData3, num4 = num3 + 1, "03110010", "지점", p_pm_GroupID2, str1 + "StoreListPageVM", "지점리스트", "site");
      if (!this.OleDB.Execute(pData4.InsertQuery()))
        return false;
      int num5;
      TProgMenu pData5 = this.InitTableBizSMLv4(pData4, num5 = num4 + 1, "03110020", "지점 그룹", p_pm_GroupID2, str1 + "StoreGroupPageVM", "지점 그룹 조회", "group");
      if (!this.OleDB.Execute(pData5.InsertQuery()))
        return false;
      int p_pm_GroupID3 = p_pm_GroupID2 + 1;
      int num6;
      TProgMenu pData6 = this.InitTableBizSMLv3(pData5, num6 = num5 + 1, "03120000", "사원", p_pm_GroupID3, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "사원 등록 현황", "employee");
      if (!this.OleDB.Execute(pData6.InsertQuery()))
        return false;
      string str2 = "UniBizBO.ViewModels.Page.UniSales.Code.BasicInfo.Employee.";
      int num7;
      TProgMenu pData7 = this.InitTableBizSMLv4(pData6, num7 = num6 + 1, "03120010", "사원", p_pm_GroupID3, str2 + "EmployeeListPageVM", "사원리스트", "employee");
      if (!this.OleDB.Execute(pData7.InsertQuery()))
        return false;
      int p_pm_GroupID4 = p_pm_GroupID3 + 1;
      int num8;
      TProgMenu pData8 = this.InitTableBizSMLv2(pData7, num8 = num7 + 1, "03200000", "코드정보", p_pm_GroupID4, "코드정보", "코드정보", "common_code");
      if (!this.OleDB.Execute(pData8.InsertQuery()))
        return false;
      int p_pm_GroupID5 = p_pm_GroupID4 + 1;
      int num9;
      TProgMenu pData9 = this.InitTableBizSMLv3(pData8, num9 = num8 + 1, "03210000", "부서", p_pm_GroupID5, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "부서 등록 현황", "department");
      if (!this.OleDB.Execute(pData9.InsertQuery()))
        return false;
      string str3 = "UniBizBO.ViewModels.Page.UniSales.Code.CodeInfo.Dept.";
      int num10;
      TProgMenu pData10 = this.InitTableBizSMLv4(pData9, num10 = num9 + 1, "03210010", "단계", p_pm_GroupID5, str3 + "DeptDepthPageVM", "부서단계", "tree");
      if (!this.OleDB.Execute(pData10.InsertQuery()))
        return false;
      int num11;
      TProgMenu pData11 = this.InitTableBizSMLv4(pData10, num11 = num10 + 1, "03210020", "리스트", p_pm_GroupID5, str3 + "DeptListPageVM", "부서리스트", "department");
      if (!this.OleDB.Execute(pData11.InsertQuery()))
        return false;
      int p_pm_GroupID6 = p_pm_GroupID5 + 1;
      int num12;
      TProgMenu pData12 = this.InitTableBizSMLv3(pData11, num12 = num11 + 1, "03220000", "분류", p_pm_GroupID6, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "분류 등록 현황", "category");
      if (!this.OleDB.Execute(pData12.InsertQuery()))
        return false;
      string str4 = "UniBizBO.ViewModels.Page.UniSales.Code.CodeInfo.Category.";
      int num13;
      TProgMenu pData13 = this.InitTableBizSMLv4(pData12, num13 = num12 + 1, "03220010", "단계", p_pm_GroupID6, str4 + "CategoryDepthPageVM", "분류단계", "tree");
      if (!this.OleDB.Execute(pData13.InsertQuery()))
        return false;
      int num14;
      TProgMenu pData14 = this.InitTableBizSMLv4(pData13, num14 = num13 + 1, "03220020", "리스트", p_pm_GroupID6, str4 + "CategoryListPageVM", "분류리스트", "category");
      if (!this.OleDB.Execute(pData14.InsertQuery()))
        return false;
      int p_pm_GroupID7 = p_pm_GroupID6 + 1;
      int num15;
      TProgMenu pData15 = this.InitTableBizSMLv3(pData14, num15 = num14 + 1, "03230000", "가상분류", p_pm_GroupID7, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "가상분류 등록 현황", "category");
      if (!this.OleDB.Execute(pData15.InsertQuery()))
        return false;
      string str5 = "UniBizBO.ViewModels.Page.UniSales.Code.CodeInfo.EmployeeCategory.";
      int num16;
      TProgMenu pData16 = this.InitTableBizSMLv4(pData15, num16 = num15 + 1, "03230010", "단계", p_pm_GroupID7, str5 + "EmployeeCategoryDepthPageVM", "분류단계", "tree");
      if (!this.OleDB.Execute(pData16.InsertQuery()))
        return false;
      int num17;
      TProgMenu pData17 = this.InitTableBizSMLv4(pData16, num17 = num16 + 1, "03230020", "리스트", p_pm_GroupID7, str5 + "CategoryListPageVM", "분류리스트", "category");
      if (!this.OleDB.Execute(pData17.InsertQuery()))
        return false;
      int p_pm_GroupID8 = p_pm_GroupID7 + 1;
      int num18;
      TProgMenu pData18 = this.InitTableBizSMLv3(pData17, num18 = num17 + 1, "03240000", "업체", p_pm_GroupID8, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "업체 등록 현황", "company");
      if (!this.OleDB.Execute(pData18.InsertQuery()))
        return false;
      string str6 = "UniBizBO.ViewModels.Page.UniSales.Code.CodeInfo.Supplier.";
      int num19;
      TProgMenu pData19 = this.InitTableBizSMLv4(pData18, num19 = num18 + 1, "03240010", "업체", p_pm_GroupID8, str6 + "SupplierListPageVM", "업체 리스트", "company");
      if (!this.OleDB.Execute(pData19.InsertQuery()))
        return false;
      int p_pm_GroupID9 = p_pm_GroupID8 + 1;
      int num20;
      TProgMenu pData20 = this.InitTableBizSMLv3(pData19, num20 = num19 + 1, "03250000", "제조사", p_pm_GroupID9, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "제조사 등록 현황", "maker");
      if (!this.OleDB.Execute(pData20.InsertQuery()))
        return false;
      string str7 = "UniBizBO.ViewModels.Page.UniSales.Code.CodeInfo.Maker.";
      int num21;
      TProgMenu pData21 = this.InitTableBizSMLv4(pData20, num21 = num20 + 1, "03250010", "제조사", p_pm_GroupID9, str7 + "MakerListPageVM", "제조사 리스트", "maker");
      if (!this.OleDB.Execute(pData21.InsertQuery()))
        return false;
      int p_pm_GroupID10 = p_pm_GroupID9 + 1;
      int num22;
      TProgMenu pData22 = this.InitTableBizSMLv3(pData21, num22 = num21 + 1, "03260000", "브랜드", p_pm_GroupID10, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "브랜드 등록 현황", "brand");
      if (!this.OleDB.Execute(pData22.InsertQuery()))
        return false;
      string str8 = "UniBizBO.ViewModels.Page.UniSales.Code.CodeInfo.Brand.";
      int num23;
      TProgMenu pData23 = this.InitTableBizSMLv4(pData22, num23 = num22 + 1, "03260010", "브랜드", p_pm_GroupID10, str8 + "BrandListPageVM", "브랜드 리스트", "brand");
      if (!this.OleDB.Execute(pData23.InsertQuery()))
        return false;
      int p_pm_GroupID11 = p_pm_GroupID10 + 1;
      int num24;
      TProgMenu pData24 = this.InitTableBizSMLv2(pData23, num24 = num23 + 1, "03400000", "상품정보", p_pm_GroupID11, "상품정보", "상품정보", "item");
      if (!this.OleDB.Execute(pData24.InsertQuery()))
        return false;
      int p_pm_GroupID12 = p_pm_GroupID11 + 1;
      int num25;
      TProgMenu pData25 = this.InitTableBizSMLv3(pData24, num25 = num24 + 1, "03410000", "상품관리", p_pm_GroupID12, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "상품 등록 현황", "item_manage");
      if (!this.OleDB.Execute(pData25.InsertQuery()))
        return false;
      string str9 = "UniBizBO.ViewModels.Page.UniSales.Code.GoodsInfo.Goods.";
      int num26;
      TProgMenu pData26 = this.InitTableBizSMLv4(pData25, num26 = num25 + 1, "03410010", "상품조회", p_pm_GroupID12, str9 + "GoodsListPageVM", "상품 리스트", "item_manage");
      if (!this.OleDB.Execute(pData26.InsertQuery()))
        return false;
      int num27;
      TProgMenu pData27 = this.InitTableBizSMLv4(pData26, num27 = num26 + 1, "03410020", "박스", p_pm_GroupID12, str9 + "GoodsBoxListPageVM", "박스 리스트", "set");
      if (!this.OleDB.Execute(pData27.InsertQuery()))
        return false;
      int num28;
      TProgMenu pData28 = this.InitTableBizSMLv4(pData27, num28 = num27 + 1, "03410030", "이력", p_pm_GroupID12, str9 + "GoodsHistoryPageVM", "기간별 이력 조회", "set");
      if (!this.OleDB.Execute(pData28.InsertQuery()))
        return false;
      int num29;
      TProgMenu pData29 = this.InitTableBizSMLv4(pData28, num29 = num28 + 1, "03410040", "점별이력", p_pm_GroupID12, str9 + "GoodsHistoryByStorePageVM", "점별 이력 조회", "set");
      if (!this.OleDB.Execute(pData29.InsertQuery()))
        return false;
      int num30;
      TProgMenu pData30 = this.InitTableBizSMLv4(pData29, num30 = num29 + 1, "03410050", "점별상품", p_pm_GroupID12, str9 + "GoodsByStorePageVM", "점별 상품 조회", "set");
      if (!this.OleDB.Execute(pData30.InsertQuery()))
        return false;
      int p_pm_GroupID13 = p_pm_GroupID12 + 1;
      int num31;
      TProgMenu pData31 = this.InitTableBizSMLv3(pData30, num31 = num30 + 1, "03430000", "가격관리", p_pm_GroupID13, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "원매가변경", "item_price_changed");
      if (!this.OleDB.Execute(pData31.InsertQuery()))
        return false;
      string str10 = "UniBizBO.ViewModels.Page.UniSales.Code.GoodsInfo.GoodsPrice.";
      int num32;
      TProgMenu pData32 = this.InitTableBizSMLv4(pData31, num32 = num31 + 1, "03430010", "원매가", p_pm_GroupID13, str10 + "GoodsPriceChangePageVM", "원매가 변경 리스트", "price_changed");
      if (!this.OleDB.Execute(pData32.InsertQuery()))
        return false;
      int num33;
      TProgMenu pData33 = this.InitTableBizSMLv4(pData32, num33 = num32 + 1, "03430020", "행사가", p_pm_GroupID13, str10 + "GoodsEventPriceChangePageVM", "행사 상품 리스트", "event_sale");
      if (!this.OleDB.Execute(pData33.InsertQuery()))
        return false;
      int num34;
      TProgMenu pData34 = this.InitTableBizSMLv4(pData33, num34 = num33 + 1, "03430030", "회원가", p_pm_GroupID13, str10 + "GoodsMemberPriceChangePageVM", "회원 행사 상품 리스트", "member");
      if (!this.OleDB.Execute(pData34.InsertQuery()))
        return false;
      int num35;
      TProgMenu pData35 = this.InitTableBizSMLv4(pData34, num35 = num34 + 1, "03430040", "회원 할인율", p_pm_GroupID13, str10 + "GoodsMemberPriceChangePageVM", "회원 등급별 할인 리스트", "member");
      if (!this.OleDB.Execute(pData35.InsertQuery()))
        return false;
      int p_pm_GroupID14 = p_pm_GroupID13 + 1;
      int num36;
      TProgMenu pData36 = this.InitTableBizSMLv3(pData35, num36 = num35 + 1, "03450000", "이력관리", p_pm_GroupID14, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "이력변경", "item_price_changed");
      if (!this.OleDB.Execute(pData36.InsertQuery()))
        return false;
      string str11 = "UniBizBO.ViewModels.Page.UniSales.Code.GoodsInfo.GoodsHistory.";
      int num37;
      return this.OleDB.Execute(this.InitTableBizSMLv4(pData36, num37 = num36 + 1, "03450010", "이력관리", p_pm_GroupID14, str11 + "GoodsHistoryChangePageVM", "이력관리 리스트", "history_changed").InsertQuery());
    }

    private bool InitTableBizBO(long pSiteID)
    {
      Log.Logger.DebugColor("\n - START BizBO");
      Log.Logger.DebugColor("\n - BizBO.Sale");
      if (!this.InitTableBizBOSale(pSiteID))
        return false;
      Log.Logger.DebugColor("\n - BizBO.Order");
      if (!this.InitTableBizBOOrder(pSiteID))
        return false;
      Log.Logger.DebugColor("\n - BizBO.Code");
      if (!this.InitTableBizBOCode(pSiteID))
        return false;
      Log.Logger.DebugColor("\n - BizBO.Profit");
      if (!this.InitTableBizBOProfit(pSiteID))
        return false;
      Log.Logger.DebugColor("\n - BizBO.Pos");
      if (!this.InitTableBizBOPos(pSiteID))
        return false;
      Log.Logger.DebugColor("\n - BizBO.Payment");
      if (!this.InitTableBizBOPayment(pSiteID))
        return false;
      Log.Logger.DebugColor("\n - BizBO.Member");
      if (!this.InitTableBizBOMember(pSiteID))
        return false;
      Log.Logger.DebugColor("\n - BizBO.Campaign");
      if (!this.InitTableBizBOCampaign(pSiteID) || !this.InitTableBizBOSystem(pSiteID))
        return false;
      Log.Logger.DebugColor("\n - END BizBO");
      return true;
    }

    private TProgMenu InitTableBizBOLv2(
      TProgMenu pData,
      int p_pm_MenuCode,
      string p_pm_MenuSortNo,
      string p_pm_MenuName,
      int p_pm_GroupID,
      string p_pm_ProgID,
      string p_pm_ProgTitle,
      string p_pm_IconUrl = null)
    {
      pData.pm_MenuCode = p_pm_MenuCode;
      pData.pm_MenuSortNo = p_pm_MenuSortNo;
      pData.pm_MenuName = p_pm_MenuName;
      pData.pm_GroupID = p_pm_GroupID;
      pData.pm_ProgID = p_pm_ProgID;
      pData.pm_ProgTitle = p_pm_ProgTitle;
      pData.pm_ViewType = 1;
      pData.pm_MenuDepth = 2;
      return pData;
    }

    private TProgMenu InitTableBizBOLv3(
      TProgMenu pData,
      int p_pm_MenuCode,
      string p_pm_MenuSortNo,
      string p_pm_MenuName,
      int p_pm_GroupID,
      string p_pm_ProgID,
      string p_pm_ProgTitle,
      string p_pm_IconUrl = null)
    {
      pData.pm_MenuCode = p_pm_MenuCode;
      pData.pm_MenuSortNo = p_pm_MenuSortNo;
      pData.pm_MenuName = p_pm_MenuName;
      pData.pm_GroupID = p_pm_GroupID;
      pData.pm_ProgID = p_pm_ProgID;
      pData.pm_ProgTitle = p_pm_ProgTitle;
      pData.pm_ViewType = 2;
      pData.pm_MenuDepth = 3;
      pData.pm_IconUrl = p_pm_IconUrl;
      return pData;
    }

    private TProgMenu InitTableBizBOLv4(
      TProgMenu pData,
      int p_pm_MenuCode,
      string p_pm_MenuSortNo,
      string p_pm_MenuName,
      int p_pm_GroupID,
      string p_pm_ProgID,
      string p_pm_ProgTitle,
      string p_pm_IconUrl = null)
    {
      pData.pm_MenuCode = p_pm_MenuCode;
      pData.pm_MenuSortNo = p_pm_MenuSortNo;
      pData.pm_MenuName = p_pm_MenuName;
      pData.pm_GroupID = p_pm_GroupID;
      pData.pm_ProgID = p_pm_ProgID;
      pData.pm_ProgTitle = p_pm_ProgTitle;
      pData.pm_ViewType = 3;
      pData.pm_MenuDepth = 4;
      pData.pm_IconUrl = p_pm_IconUrl;
      return pData;
    }

    private bool InitTableBizBOMember(long pSiteID)
    {
      int num1 = 7000;
      TProgMenu pData1 = this.OleDB.Create<TProgMenu>();
      pData1.pm_MenuCode = 1501;
      int pmMenuCode = pData1.pm_MenuCode;
      pData1.pm_SiteID = pSiteID;
      pData1.pm_ProgKind = 26;
      pData1.pm_MenuSortNo = "07000000";
      pData1.pm_MenuName = "고객관리";
      pData1.pm_GroupID = num1;
      pData1.pm_ProgID = "고객관리";
      pData1.pm_ProgTitle = "고객관리";
      pData1.pm_ViewType = 1;
      pData1.pm_MenuDepth = 1;
      pData1.pm_IconUrl = "member";
      if (!this.OleDB.Execute(pData1.InsertQuery()))
        return false;
      int p_pm_GroupID1 = num1 + 1;
      int num2;
      TProgMenu pData2 = this.InitTableBizSMLv2(pData1, num2 = pmMenuCode + 1, "07100000", "기초정보", p_pm_GroupID1, "기초정보", "기초정보", "info");
      if (!this.OleDB.Execute(pData2.InsertQuery()))
        return false;
      int p_pm_GroupID2 = p_pm_GroupID1 + 1;
      int num3;
      TProgMenu pData3 = this.InitTableBizSMLv3(pData2, num3 = num2 + 1, "07110000", "회원유형", p_pm_GroupID2, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "회원유형", "member_type");
      if (!this.OleDB.Execute(pData3.InsertQuery()))
        return false;
      string str1 = "UniBizBO.ViewModels.Page.UniSales.Member.BaseInfo.RegType.";
      int num4;
      TProgMenu pData4 = this.InitTableBizSMLv4(pData3, num4 = num3 + 1, "07110010", "회원유형", p_pm_GroupID2, str1 + "RegTypePageVM", "회원유형", "member_type");
      if (!this.OleDB.Execute(pData4.InsertQuery()))
        return false;
      int num5;
      TProgMenu pData5 = this.InitTableBizSMLv4(pData4, num5 = num4 + 1, "07110020", "회원유형이력", p_pm_GroupID2, str1 + "RegTypeHistoryPageVM", "회원 유형 이력", "member_type");
      if (!this.OleDB.Execute(pData5.InsertQuery()))
        return false;
      int p_pm_GroupID3 = p_pm_GroupID2 + 1;
      int num6;
      TProgMenu pData6 = this.InitTableBizSMLv3(pData5, num6 = num5 + 1, "07130000", "회원그룹", p_pm_GroupID3, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "회원그룹", "member_group");
      if (!this.OleDB.Execute(pData6.InsertQuery()))
        return false;
      string str2 = "UniBizBO.ViewModels.Page.UniSales.Member.BaseInfo.RegGroup.";
      int num7;
      TProgMenu pData7 = this.InitTableBizSMLv4(pData6, num7 = num6 + 1, "07130010", "회원그룹", p_pm_GroupID3, str2 + "RegGroupPageVM", "회원그룹", "member_type");
      if (!this.OleDB.Execute(pData7.InsertQuery()))
        return false;
      int p_pm_GroupID4 = p_pm_GroupID3 + 1;
      int num8;
      TProgMenu pData8 = this.InitTableBizSMLv3(pData7, num8 = num7 + 1, "07150000", "회원상태", p_pm_GroupID4, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "회원상태", "member_state");
      if (!this.OleDB.Execute(pData8.InsertQuery()))
        return false;
      string str3 = "UniBizBO.ViewModels.Page.UniSales.Member.BaseInfo.RegCycle.";
      int num9;
      TProgMenu pData9 = this.InitTableBizSMLv4(pData8, num9 = num8 + 1, "07150020", "산정기준", p_pm_GroupID4, str3 + "RegCycleStdPageVM", "산정기준", "standard");
      if (!this.OleDB.Execute(pData9.InsertQuery()))
        return false;
      int p_pm_GroupID5 = p_pm_GroupID4 + 1;
      int num10;
      TProgMenu pData10 = this.InitTableBizSMLv3(pData9, num10 = num9 + 1, "07170000", "회원등급", p_pm_GroupID5, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "회원등급", "benchmark");
      if (!this.OleDB.Execute(pData10.InsertQuery()))
        return false;
      string str4 = "UniBizBO.ViewModels.Page.UniSales.Member.BaseInfo.RegGrade.";
      int num11;
      TProgMenu pData11 = this.InitTableBizSMLv4(pData10, num11 = num10 + 1, "07170010", "등급등록", p_pm_GroupID5, str4 + "RegGradePageVM", "회원 등급 등록", "benchmark_registration");
      if (!this.OleDB.Execute(pData11.InsertQuery()))
        return false;
      int num12;
      TProgMenu pData12 = this.InitTableBizSMLv4(pData11, num12 = num11 + 1, "07170020", "산정기준", p_pm_GroupID5, str4 + "RegGradeStdPageVM", "산정기준 등록", "standard");
      if (!this.OleDB.Execute(pData12.InsertQuery()))
        return false;
      int p_pm_GroupID6 = p_pm_GroupID5 + 1;
      int num13;
      TProgMenu pData13 = this.InitTableBizSMLv3(pData12, num13 = num12 + 1, "07180000", "마감조건", p_pm_GroupID6, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "마감조건", "set");
      if (!this.OleDB.Execute(pData13.InsertQuery()))
        return false;
      string str5 = "UniBizBO.ViewModels.Page.UniSales.Member.BaseInfo.RegCalcCycle.";
      int num14;
      TProgMenu pData14 = this.InitTableBizSMLv4(pData13, num14 = num13 + 1, "07180010", "EOD마감", p_pm_GroupID6, str5 + "RegCalcCyclePageVM", "EOD 마감 조건", "set");
      if (!this.OleDB.Execute(pData14.InsertQuery()))
        return false;
      int p_pm_GroupID7 = p_pm_GroupID6 + 1;
      int num15;
      TProgMenu pData15 = this.InitTableBizSMLv2(pData14, num15 = num14 + 1, "07300000", "회원", p_pm_GroupID7, "회원", "회원", "member");
      if (!this.OleDB.Execute(pData15.InsertQuery()))
        return false;
      int p_pm_GroupID8 = p_pm_GroupID7 + 1;
      int num16;
      TProgMenu pData16 = this.InitTableBizSMLv3(pData15, num16 = num15 + 1, "07310000", "회원정보", p_pm_GroupID8, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "회원정보", "member_info");
      if (!this.OleDB.Execute(pData16.InsertQuery()))
        return false;
      string str6 = "UniBizBO.ViewModels.Page.UniSales.Member.MemberInfo.RegMember.";
      int num17;
      TProgMenu pData17 = this.InitTableBizSMLv4(pData16, num17 = num16 + 1, "07310010", "회원정보", p_pm_GroupID8, str6 + "RegMemberPageVM", "회원정보", "member_info");
      if (!this.OleDB.Execute(pData17.InsertQuery()))
        return false;
      int p_pm_GroupID9 = p_pm_GroupID8 + 1;
      int num18;
      TProgMenu pData18 = this.InitTableBizSMLv2(pData17, num18 = num17 + 1, "07500000", "세금계산서", p_pm_GroupID9, "세금계산서", "세금계산서", "member");
      if (!this.OleDB.Execute(pData18.InsertQuery()))
        return false;
      int p_pm_GroupID10 = p_pm_GroupID9 + 1;
      int num19;
      TProgMenu pData19 = this.InitTableBizSMLv3(pData18, num19 = num18 + 1, "07510000", "수기발행", p_pm_GroupID10, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "수기발행", "member_info");
      if (!this.OleDB.Execute(pData19.InsertQuery()))
        return false;
      string str7 = "UniBizBO.ViewModels.Page.UniSales.Member.TaxBill.Reg.";
      int num20;
      TProgMenu pData20 = this.InitTableBizSMLv4(pData19, num20 = num19 + 1, "07510010", "수기발행", p_pm_GroupID10, str7 + "RegTaxBillPageVM", "수기발행", "member_info");
      if (!this.OleDB.Execute(pData20.InsertQuery()))
        return false;
      int p_pm_GroupID11 = p_pm_GroupID10 + 1;
      int num21;
      TProgMenu pData21 = this.InitTableBizSMLv3(pData20, num21 = num20 + 1, "07530000", "세금계산서조회", p_pm_GroupID11, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "세금계산서조회", "member_info");
      if (!this.OleDB.Execute(pData21.InsertQuery()))
        return false;
      string str8 = "UniBizBO.ViewModels.Page.UniSales.Member.TaxBill.Inq.";
      int num22;
      TProgMenu pData22 = this.InitTableBizSMLv4(pData21, num22 = num21 + 1, "07530010", "세금계산서", p_pm_GroupID11, str8 + "TaxBillPageVM", "세금계산서 조회", "member_info");
      if (!this.OleDB.Execute(pData22.InsertQuery()))
        return false;
      int p_pm_GroupID12 = p_pm_GroupID11 + 1;
      int num23;
      TProgMenu pData23 = this.InitTableBizSMLv2(pData22, num23 = num22 + 1, "07600000", "조회", p_pm_GroupID12, "조회", "조회", "member");
      if (!this.OleDB.Execute(pData23.InsertQuery()))
        return false;
      int p_pm_GroupID13 = p_pm_GroupID12 + 1;
      int num24;
      TProgMenu pData24 = this.InitTableBizSMLv3(pData23, num24 = num23 + 1, "07610000", "기본조회", p_pm_GroupID13, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "기본조회", "member_info");
      if (!this.OleDB.Execute(pData24.InsertQuery()))
        return false;
      string str9 = "UniBizBO.ViewModels.Page.UniSales.Member.Inq.Basic.";
      int num25;
      TProgMenu pData25 = this.InitTableBizSMLv4(pData24, num25 = num24 + 1, "07610010", "포인트일별현황", p_pm_GroupID13, str9 + "MemberInqBasicPointDayStatusPageVM", "기본조회(포인트일별현황)", "member_info");
      if (!this.OleDB.Execute(pData25.InsertQuery()))
        return false;
      int num26;
      TProgMenu pData26 = this.InitTableBizSMLv4(pData25, num26 = num25 + 1, "07610020", "회원주기변경이력", p_pm_GroupID13, str9 + "MemberInqBasicCycleChgHisPageVM", "기본조회(회원주기변경이력)", "member");
      if (!this.OleDB.Execute(pData26.InsertQuery()))
        return false;
      int num27;
      TProgMenu pData27 = this.InitTableBizSMLv4(pData26, num27 = num26 + 1, "07610030", "회원등급변경이력", p_pm_GroupID13, str9 + "MemberInqBasicGradeChgHisPageVM", "기본조회(회원등급변경이력)", "member");
      if (!this.OleDB.Execute(pData27.InsertQuery()))
        return false;
      int p_pm_GroupID14 = p_pm_GroupID13 + 1;
      int num28;
      TProgMenu pData28 = this.InitTableBizSMLv3(pData27, num28 = num27 + 1, "07620000", "회원현황", p_pm_GroupID14, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "회원현황", "member");
      if (!this.OleDB.Execute(pData28.InsertQuery()))
        return false;
      string str10 = "UniBizBO.ViewModels.Page.UniSales.Member.Inq.Status.";
      int num29;
      TProgMenu pData29 = this.InitTableBizSMLv4(pData28, num29 = num28 + 1, "07620010", "년간 신규가입 회원수", p_pm_GroupID14, str10 + "MemberInqStatusYearNewRegPageVM", "회원현황(년간 신규가입 회원수)", "member_info");
      if (!this.OleDB.Execute(pData29.InsertQuery()))
        return false;
      int num30;
      TProgMenu pData30 = this.InitTableBizSMLv4(pData29, num30 = num29 + 1, "07620020", "회원상세", p_pm_GroupID14, str10 + "MemberInqStatusMemberPageVM", "회원현황(회원상세)", "member");
      if (!this.OleDB.Execute(pData30.InsertQuery()))
        return false;
      int num31;
      TProgMenu pData31 = this.InitTableBizSMLv4(pData30, num31 = num30 + 1, "07620030", "연령대/구매주기 회원수", p_pm_GroupID14, str10 + "MemberInqStatusMemberCntPageVM", "회원현황(연령대/구매주기 회원수)", "member");
      if (!this.OleDB.Execute(pData31.InsertQuery()))
        return false;
      int p_pm_GroupID15 = p_pm_GroupID14 + 1;
      int num32;
      TProgMenu pData32 = this.InitTableBizSMLv3(pData31, num32 = num31 + 1, "07630000", "BestWorst상품", p_pm_GroupID15, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "BestWorst상품", "member");
      if (!this.OleDB.Execute(pData32.InsertQuery()))
        return false;
      string str11 = "UniBizBO.ViewModels.Page.UniSales.Member.Inq.BestWorst.";
      int num33;
      TProgMenu pData33 = this.InitTableBizSMLv4(pData32, num33 = num32 + 1, "07630010", "기본", p_pm_GroupID15, str11 + "MemberInqBestWorstBasicPageVM", "BestWorst상품(기본)", "member_info");
      if (!this.OleDB.Execute(pData33.InsertQuery()))
        return false;
      int num34;
      TProgMenu pData34 = this.InitTableBizSMLv4(pData33, num34 = num33 + 1, "07630020", "회원속성별", p_pm_GroupID15, str11 + "MemberInqBestWorstMemberAttributePageVM", "BestWorst상품(회원속성별)", "member");
      if (!this.OleDB.Execute(pData34.InsertQuery()))
        return false;
      int num35;
      TProgMenu pData35 = this.InitTableBizSMLv4(pData34, num35 = num34 + 1, "07630030", "구매순위", p_pm_GroupID15, str11 + "MemberInqBestWorstBuyRankingPageVM", "BestWorst상품(구매순위)", "member");
      if (!this.OleDB.Execute(pData35.InsertQuery()))
        return false;
      int p_pm_GroupID16 = p_pm_GroupID15 + 1;
      int num36;
      TProgMenu pData36 = this.InitTableBizSMLv3(pData35, num36 = num35 + 1, "07640000", "회원매출", p_pm_GroupID16, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "회원매출", "member");
      if (!this.OleDB.Execute(pData36.InsertQuery()))
        return false;
      string str12 = "UniBizBO.ViewModels.Page.UniSales.Member.Inq.Sales.";
      int num37;
      TProgMenu pData37 = this.InitTableBizSMLv4(pData36, num37 = num36 + 1, "07640010", "영수증", p_pm_GroupID16, str12 + "MemberInqSalesSlipPageVM", "회원매출(영수증)", "member_info");
      if (!this.OleDB.Execute(pData37.InsertQuery()))
        return false;
      int num38;
      TProgMenu pData38 = this.InitTableBizSMLv4(pData37, num38 = num37 + 1, "07640020", "일별", p_pm_GroupID16, str12 + "MemberInqSalesDayAllPageVM", "회원매출(일별)", "member");
      if (!this.OleDB.Execute(pData38.InsertQuery()))
        return false;
      int num39;
      TProgMenu pData39 = this.InitTableBizSMLv4(pData38, num39 = num38 + 1, "07640030", "일별 회원속성", p_pm_GroupID16, str12 + "MemberInqSalesDayMemberAttributePageVM", "회원매출(일별 회원속성)", "member");
      if (!this.OleDB.Execute(pData39.InsertQuery()))
        return false;
      int p_pm_GroupID17 = p_pm_GroupID16 + 1;
      int num40;
      TProgMenu pData40 = this.InitTableBizSMLv3(pData39, num40 = num39 + 1, "07650000", "포인트소멸", p_pm_GroupID17, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "포인트소멸", "member");
      if (!this.OleDB.Execute(pData40.InsertQuery()))
        return false;
      string str13 = "UniBizBO.ViewModels.Page.UniSales.Member.Inq.Extinction.";
      int num41;
      TProgMenu pData41 = this.InitTableBizSMLv4(pData40, num41 = num40 + 1, "07650010", "포인트소멸예정", p_pm_GroupID17, str13 + "MemberInqExtinctionExpectedPageVM", "포인트소멸(포인트소멸예정)", "member_info");
      int num42;
      return this.OleDB.Execute(pData41.InsertQuery()) && this.OleDB.Execute(this.InitTableBizSMLv4(pData41, num42 = num41 + 1, "07650010", "포인트소멸내역", p_pm_GroupID17, str13 + "MemberInqExtinctionStatementPageVM", "포인트소멸(포인트소멸내역)", "member").InsertQuery());
    }

    private bool InitTableBizBOOrder(long pSiteID)
    {
      int num1 = 2000;
      TProgMenu pData1 = this.OleDB.Create<TProgMenu>();
      pData1.pm_MenuCode = 1001;
      int pmMenuCode = pData1.pm_MenuCode;
      pData1.pm_SiteID = pSiteID;
      pData1.pm_ProgKind = 26;
      pData1.pm_MenuSortNo = "02000000";
      pData1.pm_MenuName = "전표관리";
      pData1.pm_GroupID = num1;
      pData1.pm_ProgID = "전표관리";
      pData1.pm_ProgTitle = "전표관리";
      pData1.pm_ViewType = 1;
      pData1.pm_MenuDepth = 1;
      pData1.pm_IconUrl = "invoice";
      if (!this.OleDB.Execute(pData1.InsertQuery()))
        return false;
      int p_pm_GroupID1 = num1 + 1;
      int num2;
      TProgMenu pData2 = this.InitTableBizSMLv2(pData1, num2 = pmMenuCode + 1, "02100000", "발주관리", p_pm_GroupID1, "발주관리", "발주관리", "order");
      if (!this.OleDB.Execute(pData2.InsertQuery()))
        return false;
      int p_pm_GroupID2 = p_pm_GroupID1 + 1;
      int num3;
      TProgMenu pData3 = this.InitTableBizSMLv3(pData2, num3 = num2 + 1, "02110000", "발주", p_pm_GroupID2, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "발주 조회/등록", "order_add");
      if (!this.OleDB.Execute(pData3.InsertQuery()))
        return false;
      string str1 = "UniBizBO.ViewModels.Page.UniSales.Order.RegOrder.Order.";
      int num4;
      TProgMenu pData4 = this.InitTableBizSMLv4(pData3, num4 = num3 + 1, "02110010", "발주", p_pm_GroupID2, str1 + "OrderPageVM", "발주리스트", "detail");
      if (!this.OleDB.Execute(pData4.InsertQuery()))
        return false;
      int p_pm_GroupID3 = p_pm_GroupID2 + 1;
      int num5;
      TProgMenu pData5 = this.InitTableBizSMLv2(pData4, num5 = num4 + 1, "02200000", "전표관리", p_pm_GroupID3, "전표관리", "전표관리", "invoice");
      if (!this.OleDB.Execute(pData5.InsertQuery()))
        return false;
      int p_pm_GroupID4 = p_pm_GroupID3 + 1;
      int num6;
      TProgMenu pData6 = this.InitTableBizSMLv3(pData5, num6 = num5 + 1, "02210000", "매입/대출입", p_pm_GroupID4, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "전표 조회/등록", "invoice_manage");
      if (!this.OleDB.Execute(pData6.InsertQuery()))
        return false;
      string str2 = "UniBizBO.ViewModels.Page.UniSales.Order.RegStatement.Statement.";
      int num7;
      TProgMenu pData7 = this.InitTableBizSMLv4(pData6, num7 = num6 + 1, "02210010", "전표", p_pm_GroupID4, str2 + "StatementPageVM", "전표리스트", "detail");
      if (!this.OleDB.Execute(pData7.InsertQuery()))
        return false;
      int p_pm_GroupID5 = p_pm_GroupID4 + 1;
      int num8;
      TProgMenu pData8 = this.InitTableBizSMLv3(pData7, num8 = num7 + 1, "02230000", "매출전표", p_pm_GroupID5, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "매출 전표 조회/등록", "invoice_manage");
      if (!this.OleDB.Execute(pData8.InsertQuery()))
        return false;
      string str3 = "UniBizBO.ViewModels.Page.UniSales.Credit.RegStatement.Statement.";
      int num9;
      TProgMenu pData9 = this.InitTableBizSMLv4(pData8, num9 = num8 + 1, "02230010", "전표", p_pm_GroupID5, str3 + "CreditStatementPageVM", "매출전표리스트", "detail");
      if (!this.OleDB.Execute(pData9.InsertQuery()))
        return false;
      string str4 = "UniBizBO.ViewModels.Page.UniSales.Credit.RegStatement.Payment.";
      int num10;
      TProgMenu pData10 = this.InitTableBizSMLv4(pData9, num10 = num9 + 1, "02230020", "결제관리", p_pm_GroupID5, str4 + "CreditPaymentPageVM", "회원별 결제관리", "detail");
      if (!this.OleDB.Execute(pData10.InsertQuery()))
        return false;
      int num11;
      TProgMenu pData11 = this.InitTableBizSMLv4(pData10, num11 = num10 + 1, "02230030", "일자별", p_pm_GroupID5, str4 + "CreditPaymentDayPageVM", "일자별 결제 내역", "detail");
      if (!this.OleDB.Execute(pData11.InsertQuery()))
        return false;
      int p_pm_GroupID6 = p_pm_GroupID5 + 1;
      int num12;
      TProgMenu pData12 = this.InitTableBizSMLv2(pData11, num12 = num11 + 1, "02300000", "전표조회", p_pm_GroupID6, "전표조회", "전표조회", "invoice_detail");
      if (!this.OleDB.Execute(pData12.InsertQuery()))
        return false;
      int p_pm_GroupID7 = p_pm_GroupID6 + 1;
      int num13;
      TProgMenu pData13 = this.InitTableBizSMLv3(pData12, num13 = num12 + 1, "02310000", "업체별", p_pm_GroupID7, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "업체별 전표 조회", "invoice_company");
      if (!this.OleDB.Execute(pData13.InsertQuery()))
        return false;
      string str5 = "UniBizBO.ViewModels.Page.UniSales.Order.Statement.Supplier.";
      int num14;
      TProgMenu pData14 = this.InitTableBizSMLv4(pData13, num14 = num13 + 1, "02310010", "기간", p_pm_GroupID7, str5 + "PeriodPageVM", "기간별", "term");
      if (!this.OleDB.Execute(pData14.InsertQuery()))
        return false;
      int num15;
      TProgMenu pData15 = this.InitTableBizSMLv4(pData14, num15 = num14 + 1, "02310020", "일자", p_pm_GroupID7, str5 + "DayPageVM", "일자별", "day");
      if (!this.OleDB.Execute(pData15.InsertQuery()))
        return false;
      int num16;
      TProgMenu pData16 = this.InitTableBizSMLv4(pData15, num16 = num15 + 1, "02310030", "전표", p_pm_GroupID7, str5 + "StatementPageVM", "전표별", "invoice");
      if (!this.OleDB.Execute(pData16.InsertQuery()))
        return false;
      int num17;
      TProgMenu pData17 = this.InitTableBizSMLv4(pData16, num17 = num16 + 1, "02310040", "전표상세", p_pm_GroupID7, str5 + "StatementDetailPageVM", "전표상세", "invoice_detail");
      if (!this.OleDB.Execute(pData17.InsertQuery()))
        return false;
      int num18;
      TProgMenu pData18 = this.InitTableBizSMLv4(pData17, num18 = num17 + 1, "02310050", "상품", p_pm_GroupID7, str5 + "GoodsPageVM", "상품별", "item");
      if (!this.OleDB.Execute(pData18.InsertQuery()))
        return false;
      int p_pm_GroupID8 = p_pm_GroupID7 + 1;
      int num19;
      TProgMenu pData19 = this.InitTableBizSMLv3(pData18, num19 = num18 + 1, "02320000", "기간별", p_pm_GroupID8, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "기간별 전표 조회", "term_invoice");
      if (!this.OleDB.Execute(pData19.InsertQuery()))
        return false;
      string str6 = "UniBizBO.ViewModels.Page.UniSales.Order.Statement.Period.";
      int num20;
      TProgMenu pData20 = this.InitTableBizSMLv4(pData19, num20 = num19 + 1, "02320010", "지점", p_pm_GroupID8, str6 + "StorePageVM", "지점별", "site");
      if (!this.OleDB.Execute(pData20.InsertQuery()))
        return false;
      int num21;
      TProgMenu pData21 = this.InitTableBizSMLv4(pData20, num21 = num20 + 1, "02320020", "팀", p_pm_GroupID8, str6 + "TeamPageVM", "팀별", "team");
      if (!this.OleDB.Execute(pData21.InsertQuery()))
        return false;
      int num22;
      TProgMenu pData22 = this.InitTableBizSMLv4(pData21, num22 = num21 + 1, "02320030", "부서", p_pm_GroupID8, str6 + "PartPageVM", "부서별", "department");
      if (!this.OleDB.Execute(pData22.InsertQuery()))
        return false;
      int num23;
      TProgMenu pData23 = this.InitTableBizSMLv4(pData22, num23 = num22 + 1, "02320040", "대분류", p_pm_GroupID8, str6 + "CategoryTopPageVM", "대분류별", "category_main_category");
      if (!this.OleDB.Execute(pData23.InsertQuery()))
        return false;
      int num24;
      TProgMenu pData24 = this.InitTableBizSMLv4(pData23, num24 = num23 + 1, "02320050", "중분류", p_pm_GroupID8, str6 + "CategoryMiddlePageVM", "중분류별", "category_middle_category");
      if (!this.OleDB.Execute(pData24.InsertQuery()))
        return false;
      int num25;
      TProgMenu pData25 = this.InitTableBizSMLv4(pData24, num25 = num24 + 1, "02320060", "소분류", p_pm_GroupID8, str6 + "CategoryBottomPageVM", "소분류별", "category_subclass");
      if (!this.OleDB.Execute(pData25.InsertQuery()))
        return false;
      int num26;
      TProgMenu pData26 = this.InitTableBizSMLv4(pData25, num26 = num25 + 1, "02320070", "상품", p_pm_GroupID8, str6 + "GoodsPageVM", "상품별", "item");
      if (!this.OleDB.Execute(pData26.InsertQuery()))
        return false;
      int p_pm_GroupID9 = p_pm_GroupID8 + 1;
      int num27;
      TProgMenu pData27 = this.InitTableBizSMLv3(pData26, num27 = num26 + 1, "02330000", "분류별", p_pm_GroupID9, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "분류별 전표 조회", "category_invoice");
      if (!this.OleDB.Execute(pData27.InsertQuery()))
        return false;
      string str7 = "UniBizBO.ViewModels.Page.UniSales.Order.Statement.Category.";
      int num28;
      TProgMenu pData28 = this.InitTableBizSMLv4(pData27, num28 = num27 + 1, "02330010", "분류", p_pm_GroupID9, str7 + "CategoryPageVM", "분류별", "category");
      if (!this.OleDB.Execute(pData28.InsertQuery()))
        return false;
      int num29;
      TProgMenu pData29 = this.InitTableBizSMLv4(pData28, num29 = num28 + 1, "02330020", "상품별", p_pm_GroupID9, str7 + "GoodsPageVM", "상품별", "item");
      if (!this.OleDB.Execute(pData29.InsertQuery()))
        return false;
      int p_pm_GroupID10 = p_pm_GroupID9 + 1;
      int num30;
      TProgMenu pData30 = this.InitTableBizSMLv3(pData29, num30 = num29 + 1, "02360000", "재고조정", p_pm_GroupID10, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "재고조정 현황", "stocktaking");
      if (!this.OleDB.Execute(pData30.InsertQuery()))
        return false;
      string str8 = "UniBizBO.ViewModels.Page.UniSales.Order.Statement.Adjust.";
      int num31;
      TProgMenu pData31 = this.InitTableBizSMLv4(pData30, num31 = num30 + 1, "02360010", "상품", p_pm_GroupID10, str8 + "GoodsPageVM", "상품리스트", "item");
      if (!this.OleDB.Execute(pData31.InsertQuery()))
        return false;
      int num32;
      TProgMenu pData32 = this.InitTableBizSMLv4(pData31, num32 = num31 + 1, "02360020", "전표상세", p_pm_GroupID10, str8 + "StatementDetailPageVM", "전표상세", "invoice_detail");
      if (!this.OleDB.Execute(pData32.InsertQuery()))
        return false;
      int p_pm_GroupID11 = p_pm_GroupID10 + 1;
      int num33;
      TProgMenu pData33 = this.InitTableBizSMLv3(pData32, num33 = num32 + 1, "02370000", "폐기", p_pm_GroupID11, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "폐기 현황", "stock_buy_disuse");
      if (!this.OleDB.Execute(pData33.InsertQuery()))
        return false;
      string str9 = "UniBizBO.ViewModels.Page.UniSales.Order.Statement.Disuse.";
      int num34;
      TProgMenu pData34 = this.InitTableBizSMLv4(pData33, num34 = num33 + 1, "02370010", "상품", p_pm_GroupID11, str9 + "GoodsPageVM", "상품리스트", "item");
      if (!this.OleDB.Execute(pData34.InsertQuery()))
        return false;
      int num35;
      TProgMenu pData35 = this.InitTableBizSMLv4(pData34, num35 = num34 + 1, "02370020", "전표상세", p_pm_GroupID11, str9 + "StatementDetailPageVM", "전표상세", "invoice_detail");
      if (!this.OleDB.Execute(pData35.InsertQuery()))
        return false;
      int p_pm_GroupID12 = p_pm_GroupID11 + 1;
      int num36;
      TProgMenu pData36 = this.InitTableBizSMLv2(pData35, num36 = num35 + 1, "02500000", "일별 조회", p_pm_GroupID12, "일별 조회", "일별 조회", "day");
      if (!this.OleDB.Execute(pData36.InsertQuery()))
        return false;
      int p_pm_GroupID13 = p_pm_GroupID12 + 1;
      int num37;
      TProgMenu pData37 = this.InitTableBizSMLv3(pData36, num37 = num36 + 1, "02510000", "일별(가로)", p_pm_GroupID13, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "일별 전표 조회 (가로형)", "day_horizontal");
      if (!this.OleDB.Execute(pData37.InsertQuery()))
        return false;
      string str10 = "UniBizBO.ViewModels.Page.UniSales.Order.Day.Horizontal.";
      int num38;
      TProgMenu pData38 = this.InitTableBizSMLv4(pData37, num38 = num37 + 1, "02510010", "지점", p_pm_GroupID13, str10 + "StorePageVM", "지점별", "site");
      if (!this.OleDB.Execute(pData38.InsertQuery()))
        return false;
      int num39;
      TProgMenu pData39 = this.InitTableBizSMLv4(pData38, num39 = num38 + 1, "02510020", "팀", p_pm_GroupID13, str10 + "TeamPageVM", "팀별", "team");
      if (!this.OleDB.Execute(pData39.InsertQuery()))
        return false;
      int num40;
      TProgMenu pData40 = this.InitTableBizSMLv4(pData39, num40 = num39 + 1, "02510030", "부서", p_pm_GroupID13, str10 + "PartPageVM", "부서별", "department");
      if (!this.OleDB.Execute(pData40.InsertQuery()))
        return false;
      int num41;
      TProgMenu pData41 = this.InitTableBizSMLv4(pData40, num41 = num40 + 1, "02510040", "대분류", p_pm_GroupID13, str10 + "CategoryTopPageVM", "대분류별", "category_main_category");
      if (!this.OleDB.Execute(pData41.InsertQuery()))
        return false;
      int num42;
      TProgMenu pData42 = this.InitTableBizSMLv4(pData41, num42 = num41 + 1, "02510050", "중분류", p_pm_GroupID13, str10 + "CategoryMiddlePageVM", "중분류별", "category_middle_category");
      if (!this.OleDB.Execute(pData42.InsertQuery()))
        return false;
      int num43;
      TProgMenu pData43 = this.InitTableBizSMLv4(pData42, num43 = num42 + 1, "02510060", "소분류", p_pm_GroupID13, str10 + "CategoryBottomPageVM", "소분류별", "category_subclass");
      if (!this.OleDB.Execute(pData43.InsertQuery()))
        return false;
      int num44;
      TProgMenu pData44 = this.InitTableBizSMLv4(pData43, num44 = num43 + 1, "02510070", "상품", p_pm_GroupID13, str10 + "GoodsPageVM", "상품별", "item");
      if (!this.OleDB.Execute(pData44.InsertQuery()))
        return false;
      int p_pm_GroupID14 = p_pm_GroupID13 + 1;
      int num45;
      TProgMenu pData45 = this.InitTableBizSMLv3(pData44, num45 = num44 + 1, "02520000", "업체(일별)", p_pm_GroupID14, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "업체 일자별 전표 조회", "invoice_company_day");
      if (!this.OleDB.Execute(pData45.InsertQuery()))
        return false;
      string str11 = "UniBizBO.ViewModels.Page.UniSales.Order.Day.Supplier.";
      int num46;
      TProgMenu pData46 = this.InitTableBizSMLv4(pData45, num46 = num45 + 1, "02520010", "업체", p_pm_GroupID14, str11 + "SupplierPageVM", "업체별", "company");
      if (!this.OleDB.Execute(pData46.InsertQuery()))
        return false;
      int num47;
      TProgMenu pData47 = this.InitTableBizSMLv4(pData46, num47 = num46 + 1, "02520020", "분류", p_pm_GroupID14, str11 + "CategoryPageVM", "업체-분류별", "company_category");
      if (!this.OleDB.Execute(pData47.InsertQuery()))
        return false;
      int num48;
      TProgMenu pData48 = this.InitTableBizSMLv4(pData47, num48 = num47 + 1, "02520030", "상품", p_pm_GroupID14, str11 + "GoodsPageVM", "업체-분류-상품별", "company_category_item");
      if (!this.OleDB.Execute(pData48.InsertQuery()))
        return false;
      int p_pm_GroupID15 = p_pm_GroupID14 + 1;
      int num49;
      TProgMenu pData49 = this.InitTableBizSMLv3(pData48, num49 = num48 + 1, "02530000", "일별(세로)", p_pm_GroupID15, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "일별 전표 조회 (세로형)", "day_vertical");
      if (!this.OleDB.Execute(pData49.InsertQuery()))
        return false;
      string str12 = "UniBizBO.ViewModels.Page.UniSales.Order.Day.Vertical.";
      int num50;
      TProgMenu pData50 = this.InitTableBizSMLv4(pData49, num50 = num49 + 1, "02530010", "지점", p_pm_GroupID15, str12 + "StorePageVM", "지점별", "site");
      if (!this.OleDB.Execute(pData50.InsertQuery()))
        return false;
      int num51;
      TProgMenu pData51 = this.InitTableBizSMLv4(pData50, num51 = num50 + 1, "02530020", "팀", p_pm_GroupID15, str12 + "TeamPageVM", "팀별", "team");
      if (!this.OleDB.Execute(pData51.InsertQuery()))
        return false;
      int num52;
      TProgMenu pData52 = this.InitTableBizSMLv4(pData51, num52 = num51 + 1, "02530030", "부서", p_pm_GroupID15, str12 + "PartPageVM", "부서별", "department");
      if (!this.OleDB.Execute(pData52.InsertQuery()))
        return false;
      int num53;
      TProgMenu pData53 = this.InitTableBizSMLv4(pData52, num53 = num52 + 1, "02530040", "대분류", p_pm_GroupID15, str12 + "CategoryTopPageVM", "대분류별", "category_main_category");
      if (!this.OleDB.Execute(pData53.InsertQuery()))
        return false;
      int num54;
      TProgMenu pData54 = this.InitTableBizSMLv4(pData53, num54 = num53 + 1, "02530050", "중분류", p_pm_GroupID15, str12 + "CategoryMiddlePageVM", "중분류별", "category_middle_category");
      if (!this.OleDB.Execute(pData54.InsertQuery()))
        return false;
      int num55;
      TProgMenu pData55 = this.InitTableBizSMLv4(pData54, num55 = num54 + 1, "02530060", "소분류", p_pm_GroupID15, str12 + "CategoryBottomPageVM", "소분류별", "category_subclass");
      if (!this.OleDB.Execute(pData55.InsertQuery()))
        return false;
      int num56;
      TProgMenu pData56 = this.InitTableBizSMLv4(pData55, num56 = num55 + 1, "02530070", "상품", p_pm_GroupID15, str12 + "GoodsPageVM", "상품별", "item");
      if (!this.OleDB.Execute(pData56.InsertQuery()))
        return false;
      int p_pm_GroupID16 = p_pm_GroupID15 + 1;
      int num57;
      TProgMenu pData57 = this.InitTableBizSMLv2(pData56, num57 = num56 + 1, "02700000", "월별조회", p_pm_GroupID16, "월별조회", "월별조회", "day");
      if (!this.OleDB.Execute(pData57.InsertQuery()))
        return false;
      int p_pm_GroupID17 = p_pm_GroupID16 + 1;
      int num58;
      TProgMenu pData58 = this.InitTableBizSMLv3(pData57, num58 = num57 + 1, "02710000", "월별(가로형)", p_pm_GroupID17, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "월별 전표 조회 (가로형)", "day_horizontal");
      if (!this.OleDB.Execute(pData58.InsertQuery()))
        return false;
      string str13 = "UniBizBO.ViewModels.Page.UniSales.Order.Month.Horizontal.";
      int num59;
      TProgMenu pData59 = this.InitTableBizSMLv4(pData58, num59 = num58 + 1, "02710010", "지점", p_pm_GroupID17, str13 + "StorePageVM", "지점별", "site");
      if (!this.OleDB.Execute(pData59.InsertQuery()))
        return false;
      int num60;
      TProgMenu pData60 = this.InitTableBizSMLv4(pData59, num60 = num59 + 1, "02710020", "팀", p_pm_GroupID17, str13 + "TeamPageVM", "팀별", "team");
      if (!this.OleDB.Execute(pData60.InsertQuery()))
        return false;
      int num61;
      TProgMenu pData61 = this.InitTableBizSMLv4(pData60, num61 = num60 + 1, "02710030", "부서", p_pm_GroupID17, str13 + "PartPageVM", "부서별", "department");
      if (!this.OleDB.Execute(pData61.InsertQuery()))
        return false;
      int num62;
      TProgMenu pData62 = this.InitTableBizSMLv4(pData61, num62 = num61 + 1, "02710040", "대분류", p_pm_GroupID17, str13 + "CategoryTopPageVM", "대분류별", "category_main_category");
      if (!this.OleDB.Execute(pData62.InsertQuery()))
        return false;
      int num63;
      TProgMenu pData63 = this.InitTableBizSMLv4(pData62, num63 = num62 + 1, "02710050", "중분류", p_pm_GroupID17, str13 + "CategoryMiddlePageVM", "중분류별", "category_middle_category");
      if (!this.OleDB.Execute(pData63.InsertQuery()))
        return false;
      int num64;
      TProgMenu pData64 = this.InitTableBizSMLv4(pData63, num64 = num63 + 1, "02710060", "소분류", p_pm_GroupID17, str13 + "CategoryBottomPageVM", "소분류별", "category_subclass");
      if (!this.OleDB.Execute(pData64.InsertQuery()))
        return false;
      int num65;
      TProgMenu pData65 = this.InitTableBizSMLv4(pData64, num65 = num64 + 1, "02710070", "상품", p_pm_GroupID17, str13 + "GoodsPageVM", "상품별", "item");
      if (!this.OleDB.Execute(pData65.InsertQuery()))
        return false;
      int p_pm_GroupID18 = p_pm_GroupID17 + 1;
      int num66;
      TProgMenu pData66 = this.InitTableBizSMLv3(pData65, num66 = num65 + 1, "02730000", "업체(월별)", p_pm_GroupID18, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "업체 월별 전표 조회(가로형)", "invoice_company_month");
      if (!this.OleDB.Execute(pData66.InsertQuery()))
        return false;
      string str14 = "UniBizBO.ViewModels.Page.UniSales.Order.Month.Supplier.";
      int num67;
      TProgMenu pData67 = this.InitTableBizSMLv4(pData66, num67 = num66 + 1, "02730010", "업체", p_pm_GroupID18, str14 + "SupplierPageVM", "업체별", "company");
      if (!this.OleDB.Execute(pData67.InsertQuery()))
        return false;
      int num68;
      TProgMenu pData68 = this.InitTableBizSMLv4(pData67, num68 = num67 + 1, "02730020", "분류", p_pm_GroupID18, str14 + "CategoryPageVM", "업체-분류별", "company_category");
      if (!this.OleDB.Execute(pData68.InsertQuery()))
        return false;
      int num69;
      TProgMenu pData69 = this.InitTableBizSMLv4(pData68, num69 = num68 + 1, "02730030", "상품", p_pm_GroupID18, str14 + "GoodsPageVM", "업체-분류-상품별", "company_category");
      if (!this.OleDB.Execute(pData69.InsertQuery()))
        return false;
      int p_pm_GroupID19 = p_pm_GroupID18 + 1;
      int num70;
      TProgMenu pData70 = this.InitTableBizSMLv3(pData69, num70 = num69 + 1, "02750000", "월별(세로형)", p_pm_GroupID19, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "월별 전표 조회(세로형)", "month_vertical");
      if (!this.OleDB.Execute(pData70.InsertQuery()))
        return false;
      string str15 = "UniBizBO.ViewModels.Page.UniSales.Order.Month.Vertical.";
      int num71;
      TProgMenu pData71 = this.InitTableBizSMLv4(pData70, num71 = num70 + 1, "02750010", "지점", p_pm_GroupID19, str15 + "StorePageVM", "지점별", "site");
      if (!this.OleDB.Execute(pData71.InsertQuery()))
        return false;
      int num72;
      TProgMenu pData72 = this.InitTableBizSMLv4(pData71, num72 = num71 + 1, "02750020", "팀", p_pm_GroupID19, str15 + "TeamPageVM", "팀별", "team");
      if (!this.OleDB.Execute(pData72.InsertQuery()))
        return false;
      int num73;
      TProgMenu pData73 = this.InitTableBizSMLv4(pData72, num73 = num72 + 1, "02750030", "부서", p_pm_GroupID19, str15 + "PartPageVM", "부서별", "department");
      if (!this.OleDB.Execute(pData73.InsertQuery()))
        return false;
      int num74;
      TProgMenu pData74 = this.InitTableBizSMLv4(pData73, num74 = num73 + 1, "02750040", "대분류", p_pm_GroupID19, str15 + "CategoryTopPageVM", "대분류별", "category_main_category");
      if (!this.OleDB.Execute(pData74.InsertQuery()))
        return false;
      int num75;
      TProgMenu pData75 = this.InitTableBizSMLv4(pData74, num75 = num74 + 1, "02750050", "중분류", p_pm_GroupID19, str15 + "CategoryMiddlePageVM", "중분류별", "category_middle_category");
      if (!this.OleDB.Execute(pData75.InsertQuery()))
        return false;
      int num76;
      TProgMenu pData76 = this.InitTableBizSMLv4(pData75, num76 = num75 + 1, "02750060", "소분류", p_pm_GroupID19, str15 + "CategoryBottomPageVM", "소분류별", "category_subclass");
      int num77;
      return this.OleDB.Execute(pData76.InsertQuery()) && this.OleDB.Execute(this.InitTableBizSMLv4(pData76, num77 = num76 + 1, "02750070", "상품", p_pm_GroupID19, str15 + "GoodsPageVM", "상품별", "item").InsertQuery());
    }

    private bool InitTableBizBOPayment(long pSiteID)
    {
      int num1 = 6000;
      TProgMenu pData1 = this.OleDB.Create<TProgMenu>();
      pData1.pm_MenuCode = 1401;
      int pmMenuCode = pData1.pm_MenuCode;
      pData1.pm_SiteID = pSiteID;
      pData1.pm_ProgKind = 26;
      pData1.pm_MenuSortNo = "06000000";
      pData1.pm_MenuName = "대금관리";
      pData1.pm_GroupID = num1;
      pData1.pm_ProgID = "대금관리";
      pData1.pm_ProgTitle = "대금관리";
      pData1.pm_ViewType = 1;
      pData1.pm_MenuDepth = 1;
      pData1.pm_IconUrl = "price_manage";
      if (!this.OleDB.Execute(pData1.InsertQuery()))
        return false;
      int p_pm_GroupID1 = num1 + 1;
      int num2;
      TProgMenu pData2 = this.InitTableBizSMLv2(pData1, num2 = pmMenuCode + 1, "06100000", "결제", p_pm_GroupID1, "결제", "결제", "payment_condition");
      if (!this.OleDB.Execute(pData2.InsertQuery()))
        return false;
      int p_pm_GroupID2 = p_pm_GroupID1 + 1;
      int num3;
      TProgMenu pData3 = this.InitTableBizSMLv3(pData2, num3 = num2 + 1, "06110000", "결제지급", p_pm_GroupID2, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "결제 지급 관리 현황", "pos");
      if (!this.OleDB.Execute(pData3.InsertQuery()))
        return false;
      string str1 = "UniBizBO.ViewModels.Page.UniSales.Payment.RegPayment.";
      int num4;
      TProgMenu pData4 = this.InitTableBizSMLv4(pData3, num4 = num3 + 1, "06110010", "체크리스트", p_pm_GroupID2, str1 + "PaymentCheckPageVM", "업체 체크 리스트(마감)", "pos");
      if (!this.OleDB.Execute(pData4.InsertQuery()))
        return false;
      int num5;
      TProgMenu pData5 = this.InitTableBizSMLv4(pData4, num5 = num4 + 1, "06110020", "결제관리", p_pm_GroupID2, str1 + "PaymentPageVM", "업체별 결제관리", "pos");
      if (!this.OleDB.Execute(pData5.InsertQuery()))
        return false;
      int num6;
      TProgMenu pData6 = this.InitTableBizSMLv4(pData5, num6 = num5 + 1, "06110030", "결제정보", p_pm_GroupID2, str1 + "PaymentInfoPageVM", "업체별 결제정보", "pos");
      if (!this.OleDB.Execute(pData6.InsertQuery()))
        return false;
      int num7;
      TProgMenu pData7 = this.InitTableBizSMLv4(pData6, num7 = num6 + 1, "06110040", "일자별", p_pm_GroupID2, str1 + "PaymentDayPageVM", "일자별 결제 내역", "pos");
      if (!this.OleDB.Execute(pData7.InsertQuery()))
        return false;
      int p_pm_GroupID3 = p_pm_GroupID2 + 1;
      int num8;
      TProgMenu pData8 = this.InitTableBizSMLv2(pData7, num8 = num7 + 1, "06500000", "결제조건", p_pm_GroupID3, "결제조건", "결제조건", "payment_condition");
      if (!this.OleDB.Execute(pData8.InsertQuery()))
        return false;
      int p_pm_GroupID4 = p_pm_GroupID3 + 1;
      int num9;
      TProgMenu pData9 = this.InitTableBizSMLv3(pData8, num9 = num8 + 1, "06510000", "결제조건", p_pm_GroupID4, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "결제 조건 관리 현황", "payment_condition");
      if (!this.OleDB.Execute(pData9.InsertQuery()))
        return false;
      string str2 = "niBizSM.Client.Core.ViewModels.Page.UniSales.Payment.PayContion.";
      int num10;
      return this.OleDB.Execute(this.InitTableBizSMLv4(pData9, num10 = num9 + 1, "06510010", "결제조건", p_pm_GroupID4, str2 + "UPayContionPageVM", "결제 조건 리스트", "payment_condition").InsertQuery());
    }

    private bool InitTableBizBOPos(long pSiteID)
    {
      int num1 = 5000;
      TProgMenu pData1 = this.OleDB.Create<TProgMenu>();
      pData1.pm_MenuCode = 1301;
      int pmMenuCode = pData1.pm_MenuCode;
      pData1.pm_SiteID = pSiteID;
      pData1.pm_ProgKind = 26;
      pData1.pm_MenuSortNo = "05000000";
      pData1.pm_MenuName = "POS관리";
      pData1.pm_GroupID = num1;
      pData1.pm_ProgID = "POS관리";
      pData1.pm_ProgTitle = "POS관리";
      pData1.pm_ViewType = 1;
      pData1.pm_MenuDepth = 1;
      pData1.pm_IconUrl = "pos";
      if (!this.OleDB.Execute(pData1.InsertQuery()))
        return false;
      int p_pm_GroupID1 = num1 + 1;
      int num2;
      TProgMenu pData2 = this.InitTableBizSMLv2(pData1, num2 = pmMenuCode + 1, "05100000", "기초정보", p_pm_GroupID1, "기초정보", "기초정보", "info");
      if (!this.OleDB.Execute(pData2.InsertQuery()))
        return false;
      int p_pm_GroupID2 = p_pm_GroupID1 + 1;
      int num3;
      TProgMenu pData3 = this.InitTableBizSMLv3(pData2, num3 = num2 + 1, "05110000", "POS", p_pm_GroupID2, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "POS 등록 현황", "pos");
      if (!this.OleDB.Execute(pData3.InsertQuery()))
        return false;
      string str1 = "UniBizBO.ViewModels.Page.UniSales.Pos.BaseInfo.RegPos.";
      int num4;
      TProgMenu pData4 = this.InitTableBizSMLv4(pData3, num4 = num3 + 1, "05110010", "POS", p_pm_GroupID2, str1 + "RegPosPageVM", "POS 리스트", "pos");
      if (!this.OleDB.Execute(pData4.InsertQuery()))
        return false;
      int p_pm_GroupID3 = p_pm_GroupID2 + 1;
      int num5;
      TProgMenu pData5 = this.InitTableBizSMLv3(pData4, num5 = num4 + 1, "05130000", "영수증폼등록", p_pm_GroupID3, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "영수증 폼 등록", "receipt");
      if (!this.OleDB.Execute(pData5.InsertQuery()))
        return false;
      string str2 = "UniBizBO.ViewModels.Page.UniSales.Pos.BaseInfo.RegForm.";
      int num6;
      TProgMenu pData6 = this.InitTableBizSMLv4(pData5, num6 = num5 + 1, "05130010", "영수증폼", p_pm_GroupID3, str2 + "RegFormPageVM", "영수증폼 리스트", "detail");
      if (!this.OleDB.Execute(pData6.InsertQuery()))
        return false;
      int p_pm_GroupID4 = p_pm_GroupID3 + 1;
      int num7;
      TProgMenu pData7 = this.InitTableBizSMLv3(pData6, num7 = num6 + 1, "05150000", "지정키", p_pm_GroupID4, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "지정키 등록", "pos_key");
      if (!this.OleDB.Execute(pData7.InsertQuery()))
        return false;
      string str3 = "UniBizBO.ViewModels.Page.UniSales.Pos.BaseInfo.RegShortCut.";
      int num8;
      TProgMenu pData8 = this.InitTableBizSMLv4(pData7, num8 = num7 + 1, "05150010", "지정키", p_pm_GroupID4, str3 + "RegShortCutPageVM", "지정키 리스트", "detail");
      if (!this.OleDB.Execute(pData8.InsertQuery()))
        return false;
      int p_pm_GroupID5 = p_pm_GroupID4 + 1;
      int num9;
      TProgMenu pData9 = this.InitTableBizSMLv3(pData8, num9 = num8 + 1, "05170000", "밴사관리", p_pm_GroupID5, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "밴사관리", "van");
      if (!this.OleDB.Execute(pData9.InsertQuery()))
        return false;
      string str4 = "UniBizBO.ViewModels.Page.UniSales.Pos.BaseInfo.RegVan.";
      int num10;
      TProgMenu pData10 = this.InitTableBizSMLv4(pData9, num10 = num9 + 1, "05170010", "밴사", p_pm_GroupID5, str4 + "RegVanPageVM", "밴사 리스트", "detail");
      if (!this.OleDB.Execute(pData10.InsertQuery()))
        return false;
      int num11;
      TProgMenu pData11 = this.InitTableBizSMLv4(pData10, num11 = num10 + 1, "05170020", "카드사", p_pm_GroupID5, str4 + "RegCardCompPageVM", "카드사 리스트", "detail");
      if (!this.OleDB.Execute(pData11.InsertQuery()))
        return false;
      int num12;
      TProgMenu pData12 = this.InitTableBizSMLv4(pData11, num12 = num11 + 1, "05170030", "카드사연결", p_pm_GroupID5, str4 + "RegLinkPageVM", "카드사연결 리스트", "detail");
      if (!this.OleDB.Execute(pData12.InsertQuery()))
        return false;
      int p_pm_GroupID6 = p_pm_GroupID5 + 1;
      int num13;
      TProgMenu pData13 = this.InitTableBizSMLv2(pData12, num13 = num12 + 1, "05300000", "매출시제", p_pm_GroupID6, "매출시제", "매출시제", "sales_tense");
      if (!this.OleDB.Execute(pData13.InsertQuery()))
        return false;
      int p_pm_GroupID7 = p_pm_GroupID6 + 1;
      int num14;
      TProgMenu pData14 = this.InitTableBizSMLv3(pData13, num14 = num13 + 1, "05310000", "POS정산", p_pm_GroupID7, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "POS정산", "pos_calculate");
      if (!this.OleDB.Execute(pData14.InsertQuery()))
        return false;
      string str5 = "UniBizBO.ViewModels.Page.UniSales.Pos.Sales.RegPosClose.";
      int num15;
      TProgMenu pData15 = this.InitTableBizSMLv4(pData14, num15 = num14 + 1, "05310010", "정산", p_pm_GroupID7, str5 + "RegPosClosePageVM", "정산 리스트", "detail");
      if (!this.OleDB.Execute(pData15.InsertQuery()))
        return false;
      int p_pm_GroupID8 = p_pm_GroupID7 + 1;
      int num16;
      TProgMenu pData16 = this.InitTableBizSMLv3(pData15, num16 = num15 + 1, "05330000", "사무실정산", p_pm_GroupID8, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "사무실정산", "office_calculate");
      if (!this.OleDB.Execute(pData16.InsertQuery()))
        return false;
      string str6 = "UniBizBO.ViewModels.Page.UniSales.Pos.Sales.RegOfficeClose.";
      int num17;
      TProgMenu pData17 = this.InitTableBizSMLv4(pData16, num17 = num16 + 1, "05330010", "정산내역", p_pm_GroupID8, str6 + "RegOfficeClosePageVM", "정산내역 리스트", "calculate_history");
      if (!this.OleDB.Execute(pData17.InsertQuery()))
        return false;
      int p_pm_GroupID9 = p_pm_GroupID8 + 1;
      int num18;
      TProgMenu pData18 = this.InitTableBizSMLv3(pData17, num18 = num17 + 1, "05350000", "TR조회", p_pm_GroupID9, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "TR조회", "tr");
      if (!this.OleDB.Execute(pData18.InsertQuery()))
        return false;
      string str7 = "UniBizBO.ViewModels.Page.UniSales.Pos.Sales.InqTr.";
      int num19;
      TProgMenu pData19 = this.InitTableBizSMLv4(pData18, num19 = num18 + 1, "05350010", "TR조회", p_pm_GroupID9, str7 + "InqTrPageVM", "TR 리스트", "tr");
      if (!this.OleDB.Execute(pData19.InsertQuery()))
        return false;
      int p_pm_GroupID10 = p_pm_GroupID9 + 1;
      int num20;
      TProgMenu pData20 = this.InitTableBizSMLv2(pData19, num20 = num19 + 1, "05500000", "승인내역", p_pm_GroupID10, "승인내역", "승인내역", "acknowledgment_history");
      if (!this.OleDB.Execute(pData20.InsertQuery()))
        return false;
      int p_pm_GroupID11 = p_pm_GroupID10 + 1;
      int num21;
      TProgMenu pData21 = this.InitTableBizSMLv3(pData20, num21 = num20 + 1, "05510000", "카드사별", p_pm_GroupID11, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "카드사별 매출조회", "card_sales");
      if (!this.OleDB.Execute(pData21.InsertQuery()))
        return false;
      string str8 = "UniBizBO.ViewModels.Page.UniSales.Pos.Approve.InqCard.";
      int num22;
      TProgMenu pData22 = this.InitTableBizSMLv4(pData21, num22 = num21 + 1, "05510010", "카드사", p_pm_GroupID11, str8 + "InqCardPageVM", "카드사별 매출 리스트", "card_sales");
      if (!this.OleDB.Execute(pData22.InsertQuery()))
        return false;
      int p_pm_GroupID12 = p_pm_GroupID11 + 1;
      int num23;
      TProgMenu pData23 = this.InitTableBizSMLv3(pData22, num23 = num22 + 1, "05530000", "일별카드사", p_pm_GroupID12, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "일별 카드사 매출조회", "card_day");
      if (!this.OleDB.Execute(pData23.InsertQuery()))
        return false;
      string str9 = "UniBizBO.ViewModels.Page.UniSales.Pos.Approve.InqByDay.";
      int num24;
      TProgMenu pData24 = this.InitTableBizSMLv4(pData23, num24 = num23 + 1, "05530010", "일별", p_pm_GroupID12, str9 + "InqByDayPageVM", "일별 카드사 매출 리스트", "card_sales");
      if (!this.OleDB.Execute(pData24.InsertQuery()))
        return false;
      int p_pm_GroupID13 = p_pm_GroupID12 + 1;
      int num25;
      TProgMenu pData25 = this.InitTableBizSMLv3(pData24, num25 = num24 + 1, "05550000", "현금영수증", p_pm_GroupID13, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "현금영수증 내역 조회", "card_day");
      if (!this.OleDB.Execute(pData25.InsertQuery()))
        return false;
      string str10 = "UniBizBO.ViewModels.Page.UniSales.Pos.Approve.InqCash.";
      int num26;
      return this.OleDB.Execute(this.InitTableBizSMLv4(pData25, num26 = num25 + 1, "05550010", "현금영수증", p_pm_GroupID13, str10 + "InqCashPageVM", "현금영수증 내역 리스트", "card_sales").InsertQuery());
    }

    private bool InitTableBizBOProfit(long pSiteID)
    {
      int num1 = 4000;
      TProgMenu pData1 = this.OleDB.Create<TProgMenu>();
      pData1.pm_MenuCode = 1201;
      int pmMenuCode = pData1.pm_MenuCode;
      pData1.pm_SiteID = pSiteID;
      pData1.pm_ProgKind = 26;
      pData1.pm_MenuSortNo = "04000000";
      pData1.pm_MenuName = "수불관리";
      pData1.pm_GroupID = num1;
      pData1.pm_ProgID = "수불관리";
      pData1.pm_ProgTitle = "수불관리";
      pData1.pm_ViewType = 1;
      pData1.pm_MenuDepth = 1;
      pData1.pm_IconUrl = "account_book";
      if (!this.OleDB.Execute(pData1.InsertQuery()))
        return false;
      int p_pm_GroupID1 = num1 + 1;
      int num2;
      TProgMenu pData2 = this.InitTableBizSMLv2(pData1, num2 = pmMenuCode + 1, "04100000", "결산", p_pm_GroupID1, "결산", "결산", "account_book_closed");
      if (!this.OleDB.Execute(pData2.InsertQuery()))
        return false;
      int p_pm_GroupID2 = p_pm_GroupID1 + 1;
      int num3;
      TProgMenu pData3 = this.InitTableBizSMLv3(pData2, num3 = num2 + 1, "04110000", "손익(장부)결산", p_pm_GroupID2, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "손익(장부)결산", "account_book_closed");
      if (!this.OleDB.Execute(pData3.InsertQuery()))
        return false;
      string str1 = "UniBizBO.ViewModels.Page.UniSales.Stock.Summary.Profit.";
      int num4;
      TProgMenu pData4 = this.InitTableBizSMLv4(pData3, num4 = num3 + 1, "04110010", "장부결산", p_pm_GroupID2, str1 + "ProfitPageVM", "장부결산", "account_book_closed");
      if (!this.OleDB.Execute(pData4.InsertQuery()))
        return false;
      int p_pm_GroupID3 = p_pm_GroupID2 + 1;
      int num5;
      TProgMenu pData5 = this.InitTableBizSMLv3(pData4, num5 = num4 + 1, "04130000", "재고결산", p_pm_GroupID3, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "재고결산", "stock_closed");
      if (!this.OleDB.Execute(pData5.InsertQuery()))
        return false;
      string str2 = "UniBizBO.ViewModels.Page.UniSales.Stock.Summary.Stock.";
      int num6;
      TProgMenu pData6 = this.InitTableBizSMLv4(pData5, num6 = num5 + 1, "04130010", "재고결산", p_pm_GroupID3, str2 + "StockPageVM", "재고결산", "stock_closed");
      if (!this.OleDB.Execute(pData6.InsertQuery()))
        return false;
      int p_pm_GroupID4 = p_pm_GroupID3 + 1;
      int num7;
      TProgMenu pData7 = this.InitTableBizSMLv2(pData6, num7 = num6 + 1, "04300000", "재고등록/조회", p_pm_GroupID4, "재고등록/조회", "재고등록/조회", "stocktaking");
      if (!this.OleDB.Execute(pData7.InsertQuery()))
        return false;
      int p_pm_GroupID5 = p_pm_GroupID4 + 1;
      int num8;
      TProgMenu pData8 = this.InitTableBizSMLv3(pData7, num8 = num7 + 1, "04310000", "재고조사", p_pm_GroupID5, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "재고조사 등록/조회", "stocktaking_item");
      if (!this.OleDB.Execute(pData8.InsertQuery()))
        return false;
      string str3 = "UniBizBO.ViewModels.Page.UniSales.Stock.Inventory.Reg.";
      int num9;
      TProgMenu pData9 = this.InitTableBizSMLv4(pData8, num9 = num8 + 1, "04310010", "재고결산", p_pm_GroupID5, str3 + "InventoryRegPageVM", "재고조사 등록", "stocktaking_history");
      if (!this.OleDB.Execute(pData9.InsertQuery()))
        return false;
      int num10;
      TProgMenu pData10 = this.InitTableBizSMLv4(pData9, num10 = num9 + 1, "04310020", "전표-상품별", p_pm_GroupID5, str3 + "StatementGoodsPageVM", "전표-상품별 리스트", "invoice_item");
      if (!this.OleDB.Execute(pData10.InsertQuery()))
        return false;
      int num11;
      TProgMenu pData11 = this.InitTableBizSMLv4(pData10, num11 = num10 + 1, "04310030", "상품별", p_pm_GroupID5, str3 + "StatementGoodsPageVM", "상품별 리스트", "invoice_item");
      if (!this.OleDB.Execute(pData11.InsertQuery()))
        return false;
      int p_pm_GroupID6 = p_pm_GroupID5 + 1;
      int num12;
      TProgMenu pData12 = this.InitTableBizSMLv3(pData11, num12 = num11 + 1, "04330000", "재고집계표(매가환원)", p_pm_GroupID6, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "재고집계표(매가환원) 조회", "adjust_total_price_reduction");
      if (!this.OleDB.Execute(pData12.InsertQuery()))
        return false;
      string str4 = "UniBizBO.ViewModels.Page.UniSales.Stock.Inventory.Inq.";
      int num13;
      TProgMenu pData13 = this.InitTableBizSMLv4(pData12, num13 = num12 + 1, "04330010", "지점", p_pm_GroupID6, str4 + "StorePageVM", "지점별", "site");
      if (!this.OleDB.Execute(pData13.InsertQuery()))
        return false;
      int num14;
      TProgMenu pData14 = this.InitTableBizSMLv4(pData13, num14 = num13 + 1, "04330020", "팀", p_pm_GroupID6, str4 + "TeamPageVM", "팀별", "team");
      if (!this.OleDB.Execute(pData14.InsertQuery()))
        return false;
      int num15;
      TProgMenu pData15 = this.InitTableBizSMLv4(pData14, num15 = num14 + 1, "04330030", "부서", p_pm_GroupID6, str4 + "PartPageVM", "부서별", "department");
      if (!this.OleDB.Execute(pData15.InsertQuery()))
        return false;
      int num16;
      TProgMenu pData16 = this.InitTableBizSMLv4(pData15, num16 = num15 + 1, "04330040", "대분류", p_pm_GroupID6, str4 + "CategoryTopPageVM", "대분류별", "category_main_category");
      if (!this.OleDB.Execute(pData16.InsertQuery()))
        return false;
      int num17;
      TProgMenu pData17 = this.InitTableBizSMLv4(pData16, num17 = num16 + 1, "04330050", "중분류", p_pm_GroupID6, str4 + "CategoryMiddlePageVM", "중분류별", "category_middle_category");
      if (!this.OleDB.Execute(pData17.InsertQuery()))
        return false;
      int num18;
      TProgMenu pData18 = this.InitTableBizSMLv4(pData17, num18 = num17 + 1, "04330060", "소분류", p_pm_GroupID6, str4 + "CategoryBottomPageVM", "소분류별", "category_subclass");
      if (!this.OleDB.Execute(pData18.InsertQuery()))
        return false;
      int num19;
      TProgMenu pData19 = this.InitTableBizSMLv4(pData18, num19 = num18 + 1, "04330070", "상품", p_pm_GroupID6, str4 + "GoodsPageVM", "상품별", "item");
      if (!this.OleDB.Execute(pData19.InsertQuery()))
        return false;
      int p_pm_GroupID7 = p_pm_GroupID6 + 1;
      int num20;
      TProgMenu pData20 = this.InitTableBizSMLv3(pData19, num20 = num19 + 1, "04350000", "재고집계표(총평균)", p_pm_GroupID7, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "재고집계표(총평균) 조회", "adjust_total_price_reduction");
      if (!this.OleDB.Execute(pData20.InsertQuery()))
        return false;
      string str5 = "UniBizBO.ViewModels.Page.UniSales.Stock.Inventory.InqAvg.";
      int num21;
      TProgMenu pData21 = this.InitTableBizSMLv4(pData20, num21 = num20 + 1, "04350010", "지점", p_pm_GroupID7, str5 + "StorePageVM", "지점별", "site");
      if (!this.OleDB.Execute(pData21.InsertQuery()))
        return false;
      int num22;
      TProgMenu pData22 = this.InitTableBizSMLv4(pData21, num22 = num21 + 1, "04350020", "팀", p_pm_GroupID7, str5 + "TeamPageVM", "팀별", "team");
      if (!this.OleDB.Execute(pData22.InsertQuery()))
        return false;
      int num23;
      TProgMenu pData23 = this.InitTableBizSMLv4(pData22, num23 = num22 + 1, "04350030", "부서", p_pm_GroupID7, str5 + "PartPageVM", "부서별", "department");
      if (!this.OleDB.Execute(pData23.InsertQuery()))
        return false;
      int num24;
      TProgMenu pData24 = this.InitTableBizSMLv4(pData23, num24 = num23 + 1, "04350040", "대분류", p_pm_GroupID7, str5 + "CategoryTopPageVM", "대분류별", "category_main_category");
      if (!this.OleDB.Execute(pData24.InsertQuery()))
        return false;
      int num25;
      TProgMenu pData25 = this.InitTableBizSMLv4(pData24, num25 = num24 + 1, "04350050", "중분류", p_pm_GroupID7, str5 + "CategoryMiddlePageVM", "중분류별", "category_middle_category");
      if (!this.OleDB.Execute(pData25.InsertQuery()))
        return false;
      int num26;
      TProgMenu pData26 = this.InitTableBizSMLv4(pData25, num26 = num25 + 1, "04350060", "소분류", p_pm_GroupID7, str5 + "CategoryBottomPageVM", "소분류별", "category_subclass");
      if (!this.OleDB.Execute(pData26.InsertQuery()))
        return false;
      int num27;
      TProgMenu pData27 = this.InitTableBizSMLv4(pData26, num27 = num26 + 1, "04350070", "상품", p_pm_GroupID7, str5 + "GoodsPageVM", "상품별", "item");
      if (!this.OleDB.Execute(pData27.InsertQuery()))
        return false;
      int p_pm_GroupID8 = p_pm_GroupID7 + 1;
      int num28;
      TProgMenu pData28 = this.InitTableBizSMLv2(pData27, num28 = num27 + 1, "04400000", "수불조회", p_pm_GroupID8, "수불조회", "수불조회", "account_book");
      if (!this.OleDB.Execute(pData28.InsertQuery()))
        return false;
      int p_pm_GroupID9 = p_pm_GroupID8 + 1;
      int num29;
      TProgMenu pData29 = this.InitTableBizSMLv3(pData28, num29 = num28 + 1, "04410000", "상품일별조회(매가환원)", p_pm_GroupID9, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "상품 일별 수불(매가환원) 조회", "day_item");
      if (!this.OleDB.Execute(pData29.InsertQuery()))
        return false;
      string str6 = "UniBizBO.ViewModels.Page.UniSales.Stock.ReceiptNPay.ByDay.";
      int num30;
      TProgMenu pData30 = this.InitTableBizSMLv4(pData29, num30 = num29 + 1, "04410010", "상품일별", p_pm_GroupID9, str6 + "ByDayPageVM", "상품일별", "day_item");
      if (!this.OleDB.Execute(pData30.InsertQuery()))
        return false;
      int p_pm_GroupID10 = p_pm_GroupID9 + 1;
      int num31;
      TProgMenu pData31 = this.InitTableBizSMLv3(pData30, num31 = num30 + 1, "04420000", "상품일별조회(총평균)", p_pm_GroupID10, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "상품 일별 수불(총평균) 조회", "day_item");
      if (!this.OleDB.Execute(pData31.InsertQuery()))
        return false;
      string str7 = "UniBizBO.ViewModels.Page.UniSales.Stock.ReceiptNPay.ByDayAvg.";
      int num32;
      TProgMenu pData32 = this.InitTableBizSMLv4(pData31, num32 = num31 + 1, "04420010", "상품일별", p_pm_GroupID10, str7 + "ByDayPageVM", "상품일별", "day_item");
      if (!this.OleDB.Execute(pData32.InsertQuery()))
        return false;
      int p_pm_GroupID11 = p_pm_GroupID10 + 1;
      int num33;
      TProgMenu pData33 = this.InitTableBizSMLv3(pData32, num33 = num32 + 1, "04430000", "기간수불조회(매가환원)", p_pm_GroupID11, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "기간별 수불(매가환원) 조회", "payment_term_price_reduction");
      if (!this.OleDB.Execute(pData33.InsertQuery()))
        return false;
      string str8 = "UniBizBO.ViewModels.Page.UniSales.Stock.ReceiptNPay.Period.";
      int num34;
      TProgMenu pData34 = this.InitTableBizSMLv4(pData33, num34 = num33 + 1, "04430010", "지점", p_pm_GroupID11, str8 + "StorePageVM", "지점별", "site");
      if (!this.OleDB.Execute(pData34.InsertQuery()))
        return false;
      int num35;
      TProgMenu pData35 = this.InitTableBizSMLv4(pData34, num35 = num34 + 1, "04430020", "팀", p_pm_GroupID11, str8 + "TeamPageVM", "팀별", "team");
      if (!this.OleDB.Execute(pData35.InsertQuery()))
        return false;
      int num36;
      TProgMenu pData36 = this.InitTableBizSMLv4(pData35, num36 = num35 + 1, "04430030", "부서", p_pm_GroupID11, str8 + "PartPageVM", "부서별", "department");
      if (!this.OleDB.Execute(pData36.InsertQuery()))
        return false;
      int num37;
      TProgMenu pData37 = this.InitTableBizSMLv4(pData36, num37 = num36 + 1, "04430040", "대분류", p_pm_GroupID11, str8 + "CategoryTopPageVM", "대분류별", "category_main_category");
      if (!this.OleDB.Execute(pData37.InsertQuery()))
        return false;
      int num38;
      TProgMenu pData38 = this.InitTableBizSMLv4(pData37, num38 = num37 + 1, "04430050", "중분류", p_pm_GroupID11, str8 + "CategoryMiddlePageVM", "중분류별", "category_middle_category");
      if (!this.OleDB.Execute(pData38.InsertQuery()))
        return false;
      int num39;
      TProgMenu pData39 = this.InitTableBizSMLv4(pData38, num39 = num38 + 1, "04430060", "소분류", p_pm_GroupID11, str8 + "CategoryBottomPageVM", "소분류별", "category_subclass");
      if (!this.OleDB.Execute(pData39.InsertQuery()))
        return false;
      int num40;
      TProgMenu pData40 = this.InitTableBizSMLv4(pData39, num40 = num39 + 1, "04430070", "상품", p_pm_GroupID11, str8 + "GoodsPageVM", "상품별", "item");
      if (!this.OleDB.Execute(pData40.InsertQuery()))
        return false;
      int p_pm_GroupID12 = p_pm_GroupID11 + 1;
      int num41;
      TProgMenu pData41 = this.InitTableBizSMLv3(pData40, num41 = num40 + 1, "04440000", "기간수불조회(총평균)", p_pm_GroupID12, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "기간별 수불(총평균) 조회", "payment_term_price_reduction");
      if (!this.OleDB.Execute(pData41.InsertQuery()))
        return false;
      string str9 = "UniBizBO.ViewModels.Page.UniSales.Stock.ReceiptNPay.PeriodAvg.";
      int num42;
      TProgMenu pData42 = this.InitTableBizSMLv4(pData41, num42 = num41 + 1, "04440010", "지점", p_pm_GroupID12, str9 + "StorePageVM", "지점별", "site");
      if (!this.OleDB.Execute(pData42.InsertQuery()))
        return false;
      int num43;
      TProgMenu pData43 = this.InitTableBizSMLv4(pData42, num43 = num42 + 1, "04440020", "팀", p_pm_GroupID12, str9 + "TeamPageVM", "팀별", "team");
      if (!this.OleDB.Execute(pData43.InsertQuery()))
        return false;
      int num44;
      TProgMenu pData44 = this.InitTableBizSMLv4(pData43, num44 = num43 + 1, "04440030", "부서", p_pm_GroupID12, str9 + "PartPageVM", "부서별", "department");
      if (!this.OleDB.Execute(pData44.InsertQuery()))
        return false;
      int num45;
      TProgMenu pData45 = this.InitTableBizSMLv4(pData44, num45 = num44 + 1, "04440040", "대분류", p_pm_GroupID12, str9 + "CategoryTopPageVM", "대분류별", "category_main_category");
      if (!this.OleDB.Execute(pData45.InsertQuery()))
        return false;
      int num46;
      TProgMenu pData46 = this.InitTableBizSMLv4(pData45, num46 = num45 + 1, "04440050", "중분류", p_pm_GroupID12, str9 + "CategoryMiddlePageVM", "중분류별", "category_middle_category");
      if (!this.OleDB.Execute(pData46.InsertQuery()))
        return false;
      int num47;
      TProgMenu pData47 = this.InitTableBizSMLv4(pData46, num47 = num46 + 1, "04440060", "소분류", p_pm_GroupID12, str9 + "CategoryBottomPageVM", "소분류별", "category_subclass");
      if (!this.OleDB.Execute(pData47.InsertQuery()))
        return false;
      int num48;
      TProgMenu pData48 = this.InitTableBizSMLv4(pData47, num48 = num47 + 1, "04440070", "상품", p_pm_GroupID12, str9 + "GoodsPageVM", "상품별", "item");
      if (!this.OleDB.Execute(pData48.InsertQuery()))
        return false;
      int p_pm_GroupID13 = p_pm_GroupID12 + 1;
      int num49;
      TProgMenu pData49 = this.InitTableBizSMLv3(pData48, num49 = num48 + 1, "04450000", "지점재고(매가환원)", p_pm_GroupID13, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "지점별 재고(매가환원) 조회", "site_adjust_price_reduction");
      if (!this.OleDB.Execute(pData49.InsertQuery()))
        return false;
      string str10 = "UniBizBO.ViewModels.Page.UniSales.Stock.ReceiptNPay.Store.";
      int num50;
      TProgMenu pData50 = this.InitTableBizSMLv4(pData49, num50 = num49 + 1, "04450010", "상품재고", p_pm_GroupID13, str10 + "StorePageVM", "상품재고", "adjust");
      if (!this.OleDB.Execute(pData50.InsertQuery()))
        return false;
      int p_pm_GroupID14 = p_pm_GroupID13 + 1;
      int num51;
      TProgMenu pData51 = this.InitTableBizSMLv3(pData50, num51 = num50 + 1, "04460000", "지점재고(총평균)", p_pm_GroupID14, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "지점별 재고(총평균) 조회", "site_adjust_average");
      if (!this.OleDB.Execute(pData51.InsertQuery()))
        return false;
      string str11 = "UniBizBO.ViewModels.Page.UniSales.Stock.ReceiptNPay.StoreAvg.";
      int num52;
      TProgMenu pData52 = this.InitTableBizSMLv4(pData51, num52 = num51 + 1, "04460010", "상품재고", p_pm_GroupID14, str11 + "StorePageVM", "상품재고", "adjust");
      if (!this.OleDB.Execute(pData52.InsertQuery()))
        return false;
      int p_pm_GroupID15 = p_pm_GroupID14 + 1;
      int num53;
      TProgMenu pData53 = this.InitTableBizSMLv3(pData52, num53 = num52 + 1, "04610000", "손익 조회(매가환원)", p_pm_GroupID15, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "손익(매가환원) 조회", "month_price_reduction");
      if (!this.OleDB.Execute(pData53.InsertQuery()))
        return false;
      string str12 = "UniBizBO.ViewModels.Page.UniSales.Stock.ProfitNLoss.Inq.";
      int num54;
      TProgMenu pData54 = this.InitTableBizSMLv4(pData53, num54 = num53 + 1, "04610010", "지점", p_pm_GroupID15, str12 + "StorePageVM", "지점별", "site");
      if (!this.OleDB.Execute(pData54.InsertQuery()))
        return false;
      int num55;
      TProgMenu pData55 = this.InitTableBizSMLv4(pData54, num55 = num54 + 1, "04610020", "팀", p_pm_GroupID15, str12 + "TeamPageVM", "팀별", "team");
      if (!this.OleDB.Execute(pData55.InsertQuery()))
        return false;
      int num56;
      TProgMenu pData56 = this.InitTableBizSMLv4(pData55, num56 = num55 + 1, "04610030", "부서", p_pm_GroupID15, str12 + "PartPageVM", "부서별", "department");
      if (!this.OleDB.Execute(pData56.InsertQuery()))
        return false;
      int num57;
      TProgMenu pData57 = this.InitTableBizSMLv4(pData56, num57 = num56 + 1, "04610040", "대분류", p_pm_GroupID15, str12 + "CategoryTopPageVM", "대분류별", "category_main_category");
      if (!this.OleDB.Execute(pData57.InsertQuery()))
        return false;
      int num58;
      TProgMenu pData58 = this.InitTableBizSMLv4(pData57, num58 = num57 + 1, "04610050", "중분류", p_pm_GroupID15, str12 + "CategoryMiddlePageVM", "중분류별", "category_middle_category");
      if (!this.OleDB.Execute(pData58.InsertQuery()))
        return false;
      int num59;
      TProgMenu pData59 = this.InitTableBizSMLv4(pData58, num59 = num58 + 1, "04610060", "소분류", p_pm_GroupID15, str12 + "CategoryBottomPageVM", "소분류별", "category_subclass");
      if (!this.OleDB.Execute(pData59.InsertQuery()))
        return false;
      int num60;
      TProgMenu pData60 = this.InitTableBizSMLv4(pData59, num60 = num59 + 1, "04610070", "상품", p_pm_GroupID15, str12 + "GoodsPageVM", "상품별", "item");
      if (!this.OleDB.Execute(pData60.InsertQuery()))
        return false;
      int p_pm_GroupID16 = p_pm_GroupID15 + 1;
      int num61;
      TProgMenu pData61 = this.InitTableBizSMLv3(pData60, num61 = num60 + 1, "04630000", "손익 조회(총평균)", p_pm_GroupID16, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "손익(총평균) 조회", "month_price_reduction");
      if (!this.OleDB.Execute(pData61.InsertQuery()))
        return false;
      string str13 = "UniBizBO.ViewModels.Page.UniSales.Stock.ProfitNLoss.InqAvg.";
      int num62;
      TProgMenu pData62 = this.InitTableBizSMLv4(pData61, num62 = num61 + 1, "04630010", "지점", p_pm_GroupID16, str13 + "StorePageVM", "지점별", "site");
      if (!this.OleDB.Execute(pData62.InsertQuery()))
        return false;
      int num63;
      TProgMenu pData63 = this.InitTableBizSMLv4(pData62, num63 = num62 + 1, "04630020", "팀", p_pm_GroupID16, str13 + "TeamPageVM", "팀별", "team");
      if (!this.OleDB.Execute(pData63.InsertQuery()))
        return false;
      int num64;
      TProgMenu pData64 = this.InitTableBizSMLv4(pData63, num64 = num63 + 1, "04630030", "부서", p_pm_GroupID16, str13 + "PartPageVM", "부서별", "department");
      if (!this.OleDB.Execute(pData64.InsertQuery()))
        return false;
      int num65;
      TProgMenu pData65 = this.InitTableBizSMLv4(pData64, num65 = num64 + 1, "04630040", "대분류", p_pm_GroupID16, str13 + "CategoryTopPageVM", "대분류별", "category_main_category");
      if (!this.OleDB.Execute(pData65.InsertQuery()))
        return false;
      int num66;
      TProgMenu pData66 = this.InitTableBizSMLv4(pData65, num66 = num65 + 1, "04630050", "중분류", p_pm_GroupID16, str13 + "CategoryMiddlePageVM", "중분류별", "category_middle_category");
      if (!this.OleDB.Execute(pData66.InsertQuery()))
        return false;
      int num67;
      TProgMenu pData67 = this.InitTableBizSMLv4(pData66, num67 = num66 + 1, "04630060", "소분류", p_pm_GroupID16, str13 + "CategoryBottomPageVM", "소분류별", "category_subclass");
      int num68;
      return this.OleDB.Execute(pData67.InsertQuery()) && this.OleDB.Execute(this.InitTableBizSMLv4(pData67, num68 = num67 + 1, "04630070", "상품", p_pm_GroupID16, str13 + "GoodsPageVM", "상품별", "item").InsertQuery());
    }

    private bool InitTableBizBOSale(long pSiteID)
    {
      int num1 = 1000;
      TProgMenu pData1 = this.OleDB.Create<TProgMenu>();
      pData1.pm_MenuCode = 901;
      int pmMenuCode = pData1.pm_MenuCode;
      pData1.pm_SiteID = pSiteID;
      pData1.pm_ProgKind = 26;
      pData1.pm_MenuSortNo = "01000000";
      pData1.pm_MenuName = "영업정보";
      pData1.pm_GroupID = num1;
      pData1.pm_ProgID = "영업정보";
      pData1.pm_ProgTitle = "영업정보";
      pData1.pm_ViewType = 1;
      pData1.pm_MenuDepth = 1;
      pData1.pm_IconUrl = "sales";
      if (!this.OleDB.Execute(pData1.InsertQuery()))
        return false;
      int p_pm_GroupID1 = num1 + 1;
      int num2;
      TProgMenu pData2 = this.InitTableBizSMLv2(pData1, num2 = pmMenuCode + 1, "01100000", "속보", p_pm_GroupID1, "속보", "속보", "time");
      if (!this.OleDB.Execute(pData2.InsertQuery()))
        return false;
      int p_pm_GroupID2 = p_pm_GroupID1 + 1;
      int num3;
      TProgMenu pData3 = this.InitTableBizSMLv3(pData2, num3 = num2 + 1, "01110000", "기간별 매출", p_pm_GroupID2, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "기간별 매출 현황", "sales_term");
      if (!this.OleDB.Execute(pData3.InsertQuery()))
        return false;
      string str1 = "UniBizBO.ViewModels.Page.UniSales.Sales.RealTime.Period.";
      int num4;
      TProgMenu pData4 = this.InitTableBizSMLv4(pData3, num4 = num3 + 1, "01110010", "지점", p_pm_GroupID2, str1 + "StorePageVM", "지점별", "site");
      if (!this.OleDB.Execute(pData4.InsertQuery()))
        return false;
      int num5;
      TProgMenu pData5 = this.InitTableBizSMLv4(pData4, num5 = num4 + 1, "01110020", "팀", p_pm_GroupID2, str1 + "TeamPageVM", "팀별", "team");
      if (!this.OleDB.Execute(pData5.InsertQuery()))
        return false;
      int num6;
      TProgMenu pData6 = this.InitTableBizSMLv4(pData5, num6 = num5 + 1, "01110030", "부서", p_pm_GroupID2, str1 + "PartPageVM", "부서별", "department");
      if (!this.OleDB.Execute(pData6.InsertQuery()))
        return false;
      int num7;
      TProgMenu pData7 = this.InitTableBizSMLv4(pData6, num7 = num6 + 1, "01110040", "대분류", p_pm_GroupID2, str1 + "CategoryTopPageVM", "대분류별", "category_main_category");
      if (!this.OleDB.Execute(pData7.InsertQuery()))
        return false;
      int num8;
      TProgMenu pData8 = this.InitTableBizSMLv4(pData7, num8 = num7 + 1, "01110050", "중분류", p_pm_GroupID2, str1 + "CategoryMiddlePageVM", "중분류별", "category_middle_category");
      if (!this.OleDB.Execute(pData8.InsertQuery()))
        return false;
      int num9;
      TProgMenu pData9 = this.InitTableBizSMLv4(pData8, num9 = num8 + 1, "01110060", "소분류", p_pm_GroupID2, str1 + "CategoryBottomPageVM", "소분류별", "category_subclass");
      if (!this.OleDB.Execute(pData9.InsertQuery()))
        return false;
      int num10;
      TProgMenu pData10 = this.InitTableBizSMLv4(pData9, num10 = num9 + 1, "01110070", "상품", p_pm_GroupID2, str1 + "GoodsPageVM", "상품별", "item");
      if (!this.OleDB.Execute(pData10.InsertQuery()))
        return false;
      int p_pm_GroupID3 = p_pm_GroupID2 + 1;
      int num11;
      TProgMenu pData11 = this.InitTableBizSMLv3(pData10, num11 = num10 + 1, "01130000", "시간대(가로)", p_pm_GroupID3, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "시간대별 매출현황(가로형)", "sales_time_horizontal");
      if (!this.OleDB.Execute(pData11.InsertQuery()))
        return false;
      string str2 = "UniBizBO.ViewModels.Page.UniSales.Sales.RealTime.TimeHorizontal.";
      int num12;
      TProgMenu pData12 = this.InitTableBizSMLv4(pData11, num12 = num11 + 1, "01130010", "지점", p_pm_GroupID3, str2 + "StorePageVM", "지점별", "site");
      if (!this.OleDB.Execute(pData12.InsertQuery()))
        return false;
      int num13;
      TProgMenu pData13 = this.InitTableBizSMLv4(pData12, num13 = num12 + 1, "01130020", "팀", p_pm_GroupID3, str2 + "TeamPageVM", "팀별", "team");
      if (!this.OleDB.Execute(pData13.InsertQuery()))
        return false;
      int num14;
      TProgMenu pData14 = this.InitTableBizSMLv4(pData13, num14 = num13 + 1, "01130030", "부서", p_pm_GroupID3, str2 + "PartPageVM", "대분류별", "department");
      if (!this.OleDB.Execute(pData14.InsertQuery()))
        return false;
      int num15;
      TProgMenu pData15 = this.InitTableBizSMLv4(pData14, num15 = num14 + 1, "01130040", "대분류", p_pm_GroupID3, str2 + "CategoryTopPageVM", "대분류별", "category_main_category");
      if (!this.OleDB.Execute(pData15.InsertQuery()))
        return false;
      int num16;
      TProgMenu pData16 = this.InitTableBizSMLv4(pData15, num16 = num15 + 1, "01130050", "중분류", p_pm_GroupID3, str2 + "CategoryMiddlePageVM", "중분류별", "category_middle_category");
      if (!this.OleDB.Execute(pData16.InsertQuery()))
        return false;
      int num17;
      TProgMenu pData17 = this.InitTableBizSMLv4(pData16, num17 = num16 + 1, "01130060", "소분류", p_pm_GroupID3, str2 + "CategoryBottomPageVM", "소분류별", "category_subclass");
      if (!this.OleDB.Execute(pData17.InsertQuery()))
        return false;
      int num18;
      TProgMenu pData18 = this.InitTableBizSMLv4(pData17, num18 = num17 + 1, "01130070", "상품", p_pm_GroupID3, str2 + "GoodsPageVM", "상품별", "item");
      if (!this.OleDB.Execute(pData18.InsertQuery()))
        return false;
      int p_pm_GroupID4 = p_pm_GroupID3 + 1;
      int num19;
      TProgMenu pData19 = this.InitTableBizSMLv3(pData18, num19 = num18 + 1, "01140000", "시간대(세로)", p_pm_GroupID4, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "시간대별 매출현황(세로형)", "sales_time_horizontal");
      if (!this.OleDB.Execute(pData19.InsertQuery()))
        return false;
      string str3 = "UniBizBO.ViewModels.Page.UniSales.Sales.RealTime.TimeVertical.";
      int num20;
      TProgMenu pData20 = this.InitTableBizSMLv4(pData19, num20 = num19 + 1, "01140010", "지점", p_pm_GroupID4, str3 + "StorePageVM", "지점별", "site");
      if (!this.OleDB.Execute(pData20.InsertQuery()))
        return false;
      int num21;
      TProgMenu pData21 = this.InitTableBizSMLv4(pData20, num21 = num20 + 1, "01140020", "팀", p_pm_GroupID4, str3 + "TeamPageVM", "팀별", "team");
      if (!this.OleDB.Execute(pData21.InsertQuery()))
        return false;
      int num22;
      TProgMenu pData22 = this.InitTableBizSMLv4(pData21, num22 = num21 + 1, "01140030", "부서", p_pm_GroupID4, str3 + "PartPageVM", "부서별", "department");
      if (!this.OleDB.Execute(pData22.InsertQuery()))
        return false;
      int num23;
      TProgMenu pData23 = this.InitTableBizSMLv4(pData22, num23 = num22 + 1, "01140040", "대분류", p_pm_GroupID4, str3 + "CategoryTopPageVM", "대분류별", "category_main_category");
      if (!this.OleDB.Execute(pData23.InsertQuery()))
        return false;
      int num24;
      TProgMenu pData24 = this.InitTableBizSMLv4(pData23, num24 = num23 + 1, "01140050", "중분류", p_pm_GroupID4, str3 + "CategoryMiddlePageVM", "중분류별", "category_middle_category");
      if (!this.OleDB.Execute(pData24.InsertQuery()))
        return false;
      int num25;
      TProgMenu pData25 = this.InitTableBizSMLv4(pData24, num25 = num24 + 1, "01140060", "소분류", p_pm_GroupID4, str3 + "CategoryBottomPageVM", "소분류별", "category_subclass");
      if (!this.OleDB.Execute(pData25.InsertQuery()))
        return false;
      int num26;
      TProgMenu pData26 = this.InitTableBizSMLv4(pData25, num26 = num25 + 1, "01140070", "상품", p_pm_GroupID4, str3 + "GoodsPageVM", "상품별", "item");
      if (!this.OleDB.Execute(pData26.InsertQuery()))
        return false;
      int p_pm_GroupID5 = p_pm_GroupID4 + 1;
      int num27;
      TProgMenu pData27 = this.InitTableBizSMLv3(pData26, num27 = num26 + 1, "01150000", "기간별 대비", p_pm_GroupID5, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "기간별 대비매출 현황", "sales_term_diff");
      if (!this.OleDB.Execute(pData27.InsertQuery()))
        return false;
      string str4 = "UniBizBO.ViewModels.Page.UniSales.Sales.RealTime.Comparison.";
      int num28;
      TProgMenu pData28 = this.InitTableBizSMLv4(pData27, num28 = num27 + 1, "01150010", "지점", p_pm_GroupID5, str4 + "StorePageVM", "지점별", "site");
      if (!this.OleDB.Execute(pData28.InsertQuery()))
        return false;
      int num29;
      TProgMenu pData29 = this.InitTableBizSMLv4(pData28, num29 = num28 + 1, "01150020", "팀", p_pm_GroupID5, str4 + "TeamPageVM", "팀별", "team");
      if (!this.OleDB.Execute(pData29.InsertQuery()))
        return false;
      int num30;
      TProgMenu pData30 = this.InitTableBizSMLv4(pData29, num30 = num29 + 1, "01150030", "부서", p_pm_GroupID5, str4 + "PartPageVM", "부서별", "department");
      if (!this.OleDB.Execute(pData30.InsertQuery()))
        return false;
      int num31;
      TProgMenu pData31 = this.InitTableBizSMLv4(pData30, num31 = num30 + 1, "01150040", "대분류", p_pm_GroupID5, str4 + "CategoryTopPageVM", "대분류별", "category_main_category");
      if (!this.OleDB.Execute(pData31.InsertQuery()))
        return false;
      int num32;
      TProgMenu pData32 = this.InitTableBizSMLv4(pData31, num32 = num31 + 1, "01150050", "중분류", p_pm_GroupID5, str4 + "CategoryMiddlePageVM", "중분류별", "category_middle_category");
      if (!this.OleDB.Execute(pData32.InsertQuery()))
        return false;
      int num33;
      TProgMenu pData33 = this.InitTableBizSMLv4(pData32, num33 = num32 + 1, "01150060", "소분류", p_pm_GroupID5, str4 + "CategoryBottomPageVM", "소분류별", "category_subclass");
      if (!this.OleDB.Execute(pData33.InsertQuery()))
        return false;
      int num34;
      TProgMenu pData34 = this.InitTableBizSMLv4(pData33, num34 = num33 + 1, "01150070", "상품", p_pm_GroupID5, str4 + "GoodsPageVM", "상품별", "item");
      if (!this.OleDB.Execute(pData34.InsertQuery()))
        return false;
      int p_pm_GroupID6 = p_pm_GroupID5 + 1;
      int num35;
      TProgMenu pData35 = this.InitTableBizSMLv2(pData34, num35 = num34 + 1, "01300000", "업체별조회", p_pm_GroupID6, "업체별 조회", "업체별 조회", "company");
      if (!this.OleDB.Execute(pData35.InsertQuery()))
        return false;
      int p_pm_GroupID7 = p_pm_GroupID6 + 1;
      int num36;
      TProgMenu pData36 = this.InitTableBizSMLv3(pData35, num36 = num35 + 1, "01310000", "업체별 매출", p_pm_GroupID7, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "업체별 매출 조회", "invoice_supplier");
      if (!this.OleDB.Execute(pData36.InsertQuery()))
        return false;
      string str5 = "UniBizBO.ViewModels.Page.UniSales.Sales.Supplier.Sales.";
      int num37;
      TProgMenu pData37 = this.InitTableBizSMLv4(pData36, num37 = num36 + 1, "01310010", "업체", p_pm_GroupID7, str5 + "SupplierPageVM", "업체별", "company");
      if (!this.OleDB.Execute(pData37.InsertQuery()))
        return false;
      int num38;
      TProgMenu pData38 = this.InitTableBizSMLv4(pData37, num38 = num37 + 1, "01310020", "분류", p_pm_GroupID7, str5 + "CategoryPageVM", "분류별", "company_category");
      if (!this.OleDB.Execute(pData38.InsertQuery()))
        return false;
      int num39;
      TProgMenu pData39 = this.InitTableBizSMLv4(pData38, num39 = num38 + 1, "01310030", "상품", p_pm_GroupID7, str5 + "GoodsPageVM", "상품별", "company_category_item");
      if (!this.OleDB.Execute(pData39.InsertQuery()))
        return false;
      int p_pm_GroupID8 = p_pm_GroupID7 + 1;
      int num40;
      TProgMenu pData40 = this.InitTableBizSMLv3(pData39, num40 = num39 + 1, "01320000", "업체별 대비", p_pm_GroupID8, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "업체별 대비 조회", "invoice_supplier");
      if (!this.OleDB.Execute(pData40.InsertQuery()))
        return false;
      string str6 = "UniBizBO.ViewModels.Page.UniSales.Sales.Supplier.Comparison.";
      int num41;
      TProgMenu pData41 = this.InitTableBizSMLv4(pData40, num41 = num40 + 1, "01320010", "업체", p_pm_GroupID8, str6 + "SupplierPageVM", "업체별", "company");
      if (!this.OleDB.Execute(pData41.InsertQuery()))
        return false;
      int num42;
      TProgMenu pData42 = this.InitTableBizSMLv4(pData41, num42 = num41 + 1, "01320020", "분류", p_pm_GroupID8, str6 + "CategoryPageVM", "분류별", "company_category");
      if (!this.OleDB.Execute(pData42.InsertQuery()))
        return false;
      int num43;
      TProgMenu pData43 = this.InitTableBizSMLv4(pData42, num43 = num42 + 1, "01320030", "상품", p_pm_GroupID8, str6 + "GoodsPageVM", "상품별", "company_category_item");
      if (!this.OleDB.Execute(pData43.InsertQuery()))
        return false;
      int p_pm_GroupID9 = p_pm_GroupID8 + 1;
      int num44;
      TProgMenu pData44 = this.InitTableBizSMLv2(pData43, num44 = num43 + 1, "01500000", "일자별 조회", p_pm_GroupID9, "일자별 조회", "일자별 조회", "item");
      if (!this.OleDB.Execute(pData44.InsertQuery()))
        return false;
      int p_pm_GroupID10 = p_pm_GroupID9 + 1;
      int num45;
      TProgMenu pData45 = this.InitTableBizSMLv3(pData44, num45 = num44 + 1, "01510000", "일별(가로형)", p_pm_GroupID10, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "일별 매출 조회 (가로형)", "day_horizontal");
      if (!this.OleDB.Execute(pData45.InsertQuery()))
        return false;
      string str7 = "UniBizBO.ViewModels.Page.UniSales.Sales.Day.Horizontal.";
      int num46;
      TProgMenu pData46 = this.InitTableBizSMLv4(pData45, num46 = num45 + 1, "01510010", "지점", p_pm_GroupID10, str7 + "StorePageVM", "지점별", "site");
      if (!this.OleDB.Execute(pData46.InsertQuery()))
        return false;
      int num47;
      TProgMenu pData47 = this.InitTableBizSMLv4(pData46, num47 = num46 + 1, "01510020", "팀", p_pm_GroupID10, str7 + "TeamPageVM", "팀별", "team");
      if (!this.OleDB.Execute(pData47.InsertQuery()))
        return false;
      int num48;
      TProgMenu pData48 = this.InitTableBizSMLv4(pData47, num48 = num47 + 1, "01510030", "부서", p_pm_GroupID10, str7 + "PartPageVM", "부서별", "department");
      if (!this.OleDB.Execute(pData48.InsertQuery()))
        return false;
      int num49;
      TProgMenu pData49 = this.InitTableBizSMLv4(pData48, num49 = num48 + 1, "01510040", "대분류", p_pm_GroupID10, str7 + "CategoryTopPageVM", "대분류별", "category_main_category");
      if (!this.OleDB.Execute(pData49.InsertQuery()))
        return false;
      int num50;
      TProgMenu pData50 = this.InitTableBizSMLv4(pData49, num50 = num49 + 1, "01510050", "소분류", p_pm_GroupID10, str7 + "CategoryMiddlePageVM", "중분류별", "category_middle_category");
      if (!this.OleDB.Execute(pData50.InsertQuery()))
        return false;
      int num51;
      TProgMenu pData51 = this.InitTableBizSMLv4(pData50, num51 = num50 + 1, "01510060", "소분류", p_pm_GroupID10, str7 + "CategoryBottomPageVM", "소분류별", "category_subclass");
      if (!this.OleDB.Execute(pData51.InsertQuery()))
        return false;
      int num52;
      TProgMenu pData52 = this.InitTableBizSMLv4(pData51, num52 = num51 + 1, "01510070", "상품", p_pm_GroupID10, str7 + "GoodsPageVM", "상품별", "item");
      if (!this.OleDB.Execute(pData52.InsertQuery()))
        return false;
      int p_pm_GroupID11 = p_pm_GroupID10 + 1;
      int num53;
      TProgMenu pData53 = this.InitTableBizSMLv3(pData52, num53 = num52 + 1, "01520000", "업체(일별)", p_pm_GroupID11, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "업체 일별 매출 조회", "day_company");
      if (!this.OleDB.Execute(pData53.InsertQuery()))
        return false;
      string str8 = "UniBizBO.ViewModels.Page.UniSales.Sales.Day.Supplier.";
      int num54;
      TProgMenu pData54 = this.InitTableBizSMLv4(pData53, num54 = num53 + 1, "01520010", "업체", p_pm_GroupID11, str8 + "SupplierPageVM", "업체별", "company");
      if (!this.OleDB.Execute(pData54.InsertQuery()))
        return false;
      int num55;
      TProgMenu pData55 = this.InitTableBizSMLv4(pData54, num55 = num54 + 1, "01520020", "분류", p_pm_GroupID11, str8 + "CategoryPageVM", "분류별", "company_category");
      if (!this.OleDB.Execute(pData55.InsertQuery()))
        return false;
      int num56;
      TProgMenu pData56 = this.InitTableBizSMLv4(pData55, num56 = num55 + 1, "01520030", "상품", p_pm_GroupID11, str8 + "GoodsPageVM", "상품별", "company_category_item");
      if (!this.OleDB.Execute(pData56.InsertQuery()))
        return false;
      int p_pm_GroupID12 = p_pm_GroupID11 + 1;
      int num57;
      TProgMenu pData57 = this.InitTableBizSMLv3(pData56, num57 = num56 + 1, "01530000", "일별(세로형)", p_pm_GroupID12, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "일별 매출 조회 (세로형)", "day_vertical");
      if (!this.OleDB.Execute(pData57.InsertQuery()))
        return false;
      string str9 = "UniBizBO.ViewModels.Page.UniSales.Sales.Day.Vertical.";
      int num58;
      TProgMenu pData58 = this.InitTableBizSMLv4(pData57, num58 = num57 + 1, "01530010", "지점", p_pm_GroupID12, str9 + "StorePageVM", "지점별", "site");
      if (!this.OleDB.Execute(pData58.InsertQuery()))
        return false;
      int num59;
      TProgMenu pData59 = this.InitTableBizSMLv4(pData58, num59 = num58 + 1, "01530020", "팀", p_pm_GroupID12, str9 + "TeamPageVM", "팀별", "team");
      if (!this.OleDB.Execute(pData59.InsertQuery()))
        return false;
      int num60;
      TProgMenu pData60 = this.InitTableBizSMLv4(pData59, num60 = num59 + 1, "01530030", "부서", p_pm_GroupID12, str9 + "PartPageVM", "부서별", "department");
      if (!this.OleDB.Execute(pData60.InsertQuery()))
        return false;
      int num61;
      TProgMenu pData61 = this.InitTableBizSMLv4(pData60, num61 = num60 + 1, "01530040", "대분류", p_pm_GroupID12, str9 + "CategoryTopPageVM", "대분류별", "category_main_category");
      if (!this.OleDB.Execute(pData61.InsertQuery()))
        return false;
      int num62;
      TProgMenu pData62 = this.InitTableBizSMLv4(pData61, num62 = num61 + 1, "01530050", "중분류", p_pm_GroupID12, str9 + "CategoryMiddlePageVM", "중분류별", "category_middle_category");
      if (!this.OleDB.Execute(pData62.InsertQuery()))
        return false;
      int num63;
      TProgMenu pData63 = this.InitTableBizSMLv4(pData62, num63 = num62 + 1, "01530060", "소분류", p_pm_GroupID12, str9 + "CategoryBottomPageVM", "소분류별", "category_subclass");
      if (!this.OleDB.Execute(pData63.InsertQuery()))
        return false;
      int num64;
      TProgMenu pData64 = this.InitTableBizSMLv4(pData63, num64 = num63 + 1, "01530070", "상품", p_pm_GroupID12, str9 + "GoodsPageVM", "상품별", "item");
      if (!this.OleDB.Execute(pData64.InsertQuery()))
        return false;
      int p_pm_GroupID13 = p_pm_GroupID12 + 1;
      int num65;
      TProgMenu pData65 = this.InitTableBizSMLv2(pData64, num65 = num64 + 1, "01700000", "월별 조회", p_pm_GroupID13, "월별 조회", "월별 조회", "month");
      if (!this.OleDB.Execute(pData65.InsertQuery()))
        return false;
      int p_pm_GroupID14 = p_pm_GroupID13 + 1;
      int num66;
      TProgMenu pData66 = this.InitTableBizSMLv3(pData65, num66 = num65 + 1, "01710000", "월별(가로형)", p_pm_GroupID14, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "월별 매출 조회 (가로형)", "month_horizontal");
      if (!this.OleDB.Execute(pData66.InsertQuery()))
        return false;
      string str10 = "UniBizBO.ViewModels.Page.UniSales.Sales.Month.Horizontal.";
      int num67;
      TProgMenu pData67 = this.InitTableBizSMLv4(pData66, num67 = num66 + 1, "01710010", "지점", p_pm_GroupID14, str10 + "StorePageVM", "지점별", "site");
      if (!this.OleDB.Execute(pData67.InsertQuery()))
        return false;
      int num68;
      TProgMenu pData68 = this.InitTableBizSMLv4(pData67, num68 = num67 + 1, "01710020", "팀", p_pm_GroupID14, str10 + "TeamPageVM", "팀별", "team");
      if (!this.OleDB.Execute(pData68.InsertQuery()))
        return false;
      int num69;
      TProgMenu pData69 = this.InitTableBizSMLv4(pData68, num69 = num68 + 1, "01710030", "부서", p_pm_GroupID14, str10 + "PartPageVM", "부서별", "department");
      if (!this.OleDB.Execute(pData69.InsertQuery()))
        return false;
      int num70;
      TProgMenu pData70 = this.InitTableBizSMLv4(pData69, num70 = num69 + 1, "01710040", "대분류", p_pm_GroupID14, str10 + "CategoryTopPageVM", "대분류별", "category_main_category");
      if (!this.OleDB.Execute(pData70.InsertQuery()))
        return false;
      int num71;
      TProgMenu pData71 = this.InitTableBizSMLv4(pData70, num71 = num70 + 1, "01710050", "중분류", p_pm_GroupID14, str10 + "CategoryMiddlePageVM", "중분류별", "category_middle_category");
      if (!this.OleDB.Execute(pData71.InsertQuery()))
        return false;
      int num72;
      TProgMenu pData72 = this.InitTableBizSMLv4(pData71, num72 = num71 + 1, "01710060", "소분류", p_pm_GroupID14, str10 + "CategoryBottomPageVM", "소분류별", "category_subclass");
      if (!this.OleDB.Execute(pData72.InsertQuery()))
        return false;
      int num73;
      TProgMenu pData73 = this.InitTableBizSMLv4(pData72, num73 = num72 + 1, "01710070", "상품", p_pm_GroupID14, str10 + "GoodsPageVM", "상품별", "item");
      if (!this.OleDB.Execute(pData73.InsertQuery()))
        return false;
      int p_pm_GroupID15 = p_pm_GroupID14 + 1;
      int num74;
      TProgMenu pData74 = this.InitTableBizSMLv3(pData73, num74 = num73 + 1, "01730000", "업체(월별)", p_pm_GroupID15, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "업체 월별 매출 조회", "month_company");
      if (!this.OleDB.Execute(pData74.InsertQuery()))
        return false;
      string str11 = "UniBizBO.ViewModels.Page.UniSales.Sales.Month.Supplier.";
      int num75;
      TProgMenu pData75 = this.InitTableBizSMLv4(pData74, num75 = num74 + 1, "01730010", "업체", p_pm_GroupID15, str11 + "SupplierPageVM", "업체별", "company");
      if (!this.OleDB.Execute(pData75.InsertQuery()))
        return false;
      int num76;
      TProgMenu pData76 = this.InitTableBizSMLv4(pData75, num76 = num75 + 1, "01730020", "분류", p_pm_GroupID15, str11 + "CategoryPageVM", "업체-분류별", "company");
      if (!this.OleDB.Execute(pData76.InsertQuery()))
        return false;
      int num77;
      TProgMenu pData77 = this.InitTableBizSMLv4(pData76, num77 = num76 + 1, "01730030", "상품", p_pm_GroupID15, str11 + "GoodsPageVM", "업체-분류-상품별", "company");
      if (!this.OleDB.Execute(pData77.InsertQuery()))
        return false;
      int p_pm_GroupID16 = p_pm_GroupID15 + 1;
      int num78;
      TProgMenu pData78 = this.InitTableBizSMLv3(pData77, num78 = num77 + 1, "01750000", "월별(세로형)", p_pm_GroupID16, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "월별 매출 조회(세로형)", "month_horizontal");
      if (!this.OleDB.Execute(pData78.InsertQuery()))
        return false;
      string str12 = "UniBizBO.ViewModels.Page.UniSales.Sales.Month.Vertical.";
      int num79;
      TProgMenu pData79 = this.InitTableBizSMLv4(pData78, num79 = num78 + 1, "01750010", "지점", p_pm_GroupID16, str12 + "StorePageVM", "지점별", "site");
      if (!this.OleDB.Execute(pData79.InsertQuery()))
        return false;
      int num80;
      TProgMenu pData80 = this.InitTableBizSMLv4(pData79, num80 = num79 + 1, "01750020", "팀", p_pm_GroupID16, str12 + "TeamPageVM", "팀별", "team");
      if (!this.OleDB.Execute(pData80.InsertQuery()))
        return false;
      int num81;
      TProgMenu pData81 = this.InitTableBizSMLv4(pData80, num81 = num80 + 1, "01750030", "부서", p_pm_GroupID16, str12 + "PartPageVM", "부서별", "department");
      if (!this.OleDB.Execute(pData81.InsertQuery()))
        return false;
      int num82;
      TProgMenu pData82 = this.InitTableBizSMLv4(pData81, num82 = num81 + 1, "01750040", "대분류", p_pm_GroupID16, str12 + "CategoryTopPageVM", "대분류별", "category_main_category");
      if (!this.OleDB.Execute(pData82.InsertQuery()))
        return false;
      int num83;
      TProgMenu pData83 = this.InitTableBizSMLv4(pData82, num83 = num82 + 1, "01750050", "중분류", p_pm_GroupID16, str12 + "CategoryMiddlePageVM", "중분류별", "category_middle_category");
      if (!this.OleDB.Execute(pData83.InsertQuery()))
        return false;
      int num84;
      TProgMenu pData84 = this.InitTableBizSMLv4(pData83, num84 = num83 + 1, "01750060", "소분류", p_pm_GroupID16, str12 + "CategoryBottomPageVM", "소분류별", "category_subclass");
      int num85;
      return this.OleDB.Execute(pData84.InsertQuery()) && this.OleDB.Execute(this.InitTableBizSMLv4(pData84, num85 = num84 + 1, "01750070", "상품", p_pm_GroupID16, str12 + "GoodsPageVM", "상품별", "item").InsertQuery());
    }

    private bool InitTableBizBOSystem(long pSiteID)
    {
      int num1 = 9000;
      TProgMenu pData1 = this.OleDB.Create<TProgMenu>();
      pData1.pm_MenuCode = 1701;
      int pmMenuCode = pData1.pm_MenuCode;
      pData1.pm_SiteID = pSiteID;
      pData1.pm_ProgKind = 26;
      pData1.pm_MenuSortNo = "99000000";
      pData1.pm_MenuName = "시스템";
      pData1.pm_GroupID = num1;
      pData1.pm_ProgID = "시스템";
      pData1.pm_ProgTitle = "시스템";
      pData1.pm_ViewType = 1;
      pData1.pm_MenuDepth = 1;
      pData1.pm_IconUrl = "system";
      if (!this.OleDB.Execute(pData1.InsertQuery()))
        return false;
      int p_pm_GroupID1 = num1 + 1;
      int num2;
      TProgMenu pData2 = this.InitTableBizBOLv2(pData1, num2 = pmMenuCode + 1, "99100000", "프로그램", p_pm_GroupID1, "프로그램", "프로그램", "program");
      if (!this.OleDB.Execute(pData2.InsertQuery()))
        return false;
      int p_pm_GroupID2 = p_pm_GroupID1 + 1;
      int num3;
      TProgMenu pData3 = this.InitTableBizBOLv3(pData2, num3 = num2 + 1, "99120000", "공통코드", p_pm_GroupID2, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "공통코드 등록 정보", "common_code");
      if (!this.OleDB.Execute(pData3.InsertQuery()))
        return false;
      string str1 = "UniBizBO.ViewModels.Page.UniSales.Systems.Program.CommonCode.";
      int num4;
      TProgMenu pData4 = this.InitTableBizBOLv4(pData3, num4 = num3 + 1, "99120010", "공통코드", p_pm_GroupID2, str1 + "CommonCodeListPageVM", "공통코드", "common_code");
      if (!this.OleDB.Execute(pData4.InsertQuery()))
        return false;
      int p_pm_GroupID3 = p_pm_GroupID2 + 1;
      int num5;
      TProgMenu pData5 = this.InitTableBizBOLv3(pData4, num5 = num4 + 1, "99130000", "메뉴", p_pm_GroupID3, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "메뉴 등록 정보", "menu");
      if (!this.OleDB.Execute(pData5.InsertQuery()))
        return false;
      string str2 = "UniBizBO.ViewModels.Page.UniSales.Systems.Program.ProgMenu.";
      int num6;
      TProgMenu pData6 = this.InitTableBizBOLv4(pData5, num6 = num5 + 1, "99130010", "메뉴", p_pm_GroupID3, str2 + "ProgMenuListPageVM", "메뉴코드", "menu");
      if (!this.OleDB.Execute(pData6.InsertQuery()))
        return false;
      int p_pm_GroupID4 = p_pm_GroupID3 + 1;
      int num7;
      TProgMenu pData7 = this.InitTableBizBOLv3(pData6, num7 = num6 + 1, "99140000", "메뉴권한", p_pm_GroupID4, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "메뉴 권한 정보", "menu_permit");
      if (!this.OleDB.Execute(pData7.InsertQuery()))
        return false;
      string str3 = "UniBizBO.ViewModels.Page.UniSales.Systems.Program.ProgMenuAuth.";
      int num8;
      TProgMenu pData8 = this.InitTableBizBOLv4(pData7, num8 = num7 + 1, "99140010", "메뉴", p_pm_GroupID4, str3 + "ProgMenuAuthListPageVM", "메뉴권한", "menu_permit");
      if (!this.OleDB.Execute(pData8.InsertQuery()))
        return false;
      int num9;
      TProgMenu pData9 = this.InitTableBizBOLv4(pData8, num9 = num8 + 1, "99140020", "권한단계", p_pm_GroupID4, str3 + "ProgMenuAuthDepthPageVM", "메뉴 권한 단계", "menu_permit");
      if (!this.OleDB.Execute(pData9.InsertQuery()))
        return false;
      int p_pm_GroupID5 = p_pm_GroupID4 + 1;
      int num10;
      TProgMenu pData10 = this.InitTableBizBOLv3(pData9, num10 = num9 + 1, "99150000", "팝업", p_pm_GroupID5, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "팝업 등록 정보", "popup");
      if (!this.OleDB.Execute(pData10.InsertQuery()))
        return false;
      string str4 = "UniBizBO.ViewModels.Page.UniSales.Systems.Program.ProgMenuProp.";
      int num11;
      TProgMenu pData11 = this.InitTableBizBOLv4(pData10, num11 = num10 + 1, "99150010", "팝업", p_pm_GroupID5, str4 + "ProgMenuPropListPageVM", "팝업", "popup");
      if (!this.OleDB.Execute(pData11.InsertQuery()))
        return false;
      int p_pm_GroupID6 = p_pm_GroupID5 + 1;
      int num12;
      TProgMenu pData12 = this.InitTableBizBOLv3(pData11, num12 = num11 + 1, "99160000", "팝업권한", p_pm_GroupID6, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "팝업 권한 정보", "popup_permit");
      if (!this.OleDB.Execute(pData12.InsertQuery()))
        return false;
      string str5 = "UniBizBO.ViewModels.Page.UniSales.Systems.Program.ProgMenuPropAuth.";
      int num13;
      TProgMenu pData13 = this.InitTableBizBOLv4(pData12, num13 = num12 + 1, "99160010", "팝업권한", p_pm_GroupID6, str5 + "ProgMenuPropAuthListPageVM", "팝업 권한", "popup_permit");
      if (!this.OleDB.Execute(pData13.InsertQuery()))
        return false;
      int num14;
      TProgMenu pData14 = this.InitTableBizBOLv4(pData13, num14 = num13 + 1, "99160020", "권한단계", p_pm_GroupID6, str5 + "ProgMenuPropAuthDepthPageVM", "팝업 권한 단계", "popup_permit");
      if (!this.OleDB.Execute(pData14.InsertQuery()))
        return false;
      int p_pm_GroupID7 = p_pm_GroupID6 + 1;
      int num15;
      TProgMenu pData15 = this.InitTableBizBOLv3(pData14, num15 = num14 + 1, "99170000", "환경설정", p_pm_GroupID7, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "환경 설정 정보", "program");
      if (!this.OleDB.Execute(pData15.InsertQuery()))
        return false;
      string str6 = "UniBizBO.ViewModels.Page.UniSales.Systems.Program.ProgOption.";
      int num16;
      TProgMenu pData16 = this.InitTableBizBOLv4(pData15, num16 = num15 + 1, "99170010", "환경설정", p_pm_GroupID7, str6 + "ProgOptionPageVM", "환경 설정 등록", "program");
      if (!this.OleDB.Execute(pData16.InsertQuery()))
        return false;
      int p_pm_GroupID8 = p_pm_GroupID7 + 1;
      int num17;
      TProgMenu pData17 = this.InitTableBizBOLv2(pData16, num17 = num16 + 1, "99300000", "보안", p_pm_GroupID8, "보안", "보안", "security_permit");
      if (!this.OleDB.Execute(pData17.InsertQuery()))
        return false;
      int p_pm_GroupID9 = p_pm_GroupID8 + 1;
      int num18;
      TProgMenu pData18 = this.InitTableBizBOLv3(pData17, num18 = num17 + 1, "99310000", "장치등록", p_pm_GroupID9, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "장치 등록 권한 정보", "device");
      if (!this.OleDB.Execute(pData18.InsertQuery()))
        return false;
      string str7 = "UniBizBO.ViewModels.Page.UniSales.Systems.Security.OuterConnAuth.";
      int num19;
      TProgMenu pData19 = this.InitTableBizBOLv4(pData18, num19 = num18 + 1, "99310010", "장치", p_pm_GroupID9, str7 + "OuterConnAuthListPageVM", "장치 관리 현황", "device_register");
      if (!this.OleDB.Execute(pData19.InsertQuery()))
        return false;
      int p_pm_GroupID10 = p_pm_GroupID9 + 1;
      int num20;
      TProgMenu pData20 = this.InitTableBizBOLv3(pData19, num20 = num19 + 1, "99320000", "사용로그", p_pm_GroupID10, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "사용 로그 조회", "data_log_search");
      if (!this.OleDB.Execute(pData20.InsertQuery()))
        return false;
      string str8 = "UniBizBO.ViewModels.Page.UniSales.Systems.Security.EmpActionLog.";
      int num21;
      TProgMenu pData21 = this.InitTableBizBOLv4(pData20, num21 = num20 + 1, "99320010", "사용로그", p_pm_GroupID10, str8 + "EmpActionLogPageVM", "사용 로그 현황", "data_log");
      if (!this.OleDB.Execute(pData21.InsertQuery()))
        return false;
      int p_pm_GroupID11 = p_pm_GroupID10 + 1;
      int num22;
      TProgMenu pData22 = this.InitTableBizBOLv2(pData21, num22 = num21 + 1, "99500000", "Server", p_pm_GroupID11, "Server", "Server", "info");
      if (!this.OleDB.Execute(pData22.InsertQuery()))
        return false;
      int p_pm_GroupID12 = p_pm_GroupID11 + 1;
      int num23;
      TProgMenu pData23 = this.InitTableBizBOLv3(pData22, num23 = num22 + 1, "99510000", "일마감", p_pm_GroupID12, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "일 마감 개설", "link_table");
      if (!this.OleDB.Execute(pData23.InsertQuery()))
        return false;
      string str9 = "UniBizBO.ViewModels.Page.UniSales.Systems.Eod.EodInfo.";
      int num24;
      TProgMenu pData24 = this.InitTableBizBOLv4(pData23, num24 = num23 + 1, "99510010", "일마감", p_pm_GroupID12, str9 + "EodInfoListPageVM", "일 마감 개설 작업", "link_table");
      if (!this.OleDB.Execute(pData24.InsertQuery()))
        return false;
      int p_pm_GroupID13 = p_pm_GroupID12 + 1;
      int num25;
      TProgMenu pData25 = this.InitTableBizBOLv3(pData24, num25 = num24 + 1, "99520000", "디비백업", p_pm_GroupID13, "UniBizBO.ViewModels.Page.Parents.TabParentPageVM", "DB BACKUP", "link_table");
      if (!this.OleDB.Execute(pData25.InsertQuery()))
        return false;
      string str10 = "UniBizBO.ViewModels.Page.UniSales.Systems.Eod.DbBackup.";
      int num26;
      return this.OleDB.Execute(this.InitTableBizBOLv4(pData25, num26 = num25 + 1, "99520010", "DB BACKUP", p_pm_GroupID13, str10 + "DbBackupListPageVM", "마감 데이터베이스 백업 작업", "link_table").InsertQuery());
    }

    private bool InitTableBizSCM(long pSiteID)
    {
      Log.Logger.DebugColor("\n - START BizSCM");
      int num1 = 1000;
      TProgMenu tprogMenu = this.OleDB.Create<TProgMenu>();
      tprogMenu.pm_MenuCode = 801;
      int pmMenuCode = tprogMenu.pm_MenuCode;
      tprogMenu.pm_SiteID = pSiteID;
      tprogMenu.pm_ProgKind = 9;
      tprogMenu.pm_MenuSortNo = "01000000";
      tprogMenu.pm_MenuName = "영업정보";
      tprogMenu.pm_GroupID = num1;
      tprogMenu.pm_ProgID = "영업정보";
      tprogMenu.pm_ProgTitle = "영업정보";
      tprogMenu.pm_ViewType = 1;
      tprogMenu.pm_MenuDepth = 1;
      if (!this.OleDB.Execute(tprogMenu.InsertQuery()))
        return false;
      int num2 = num1 + 1;
      int num3;
      tprogMenu.pm_MenuCode = num3 = pmMenuCode + 1;
      tprogMenu.pm_MenuSortNo = "01100000";
      tprogMenu.pm_MenuName = "매출조회";
      tprogMenu.pm_GroupID = num2;
      tprogMenu.pm_ProgID = "매출조회";
      tprogMenu.pm_ProgTitle = "매출조회";
      tprogMenu.pm_ViewType = 1;
      tprogMenu.pm_MenuDepth = 2;
      if (!this.OleDB.Execute(tprogMenu.InsertQuery()))
        return false;
      int num4 = num2 + 1;
      int num5;
      tprogMenu.pm_MenuCode = num5 = num3 + 1;
      tprogMenu.pm_MenuSortNo = "01110000";
      tprogMenu.pm_MenuName = "기간별 매출내역";
      tprogMenu.pm_GroupID = num4;
      tprogMenu.pm_ProgID = "/sales/sale/date/view";
      tprogMenu.pm_ProgTitle = "기간별 매출내역";
      tprogMenu.pm_ViewType = 2;
      tprogMenu.pm_MenuDepth = 3;
      tprogMenu.pm_IconUrl = "sales_from_to";
      if (!this.OleDB.Execute(tprogMenu.InsertQuery()))
        return false;
      int num6;
      tprogMenu.pm_MenuCode = num6 = num5 + 1;
      tprogMenu.pm_MenuSortNo = "01110010";
      tprogMenu.pm_MenuName = "지점";
      tprogMenu.pm_GroupID = num4;
      tprogMenu.pm_ProgID = "/sales/sale/date/page_store.jsp";
      tprogMenu.pm_ProgTitle = "지점별 판매 현황";
      tprogMenu.pm_ViewType = 3;
      tprogMenu.pm_MenuDepth = 4;
      tprogMenu.pm_IconUrl = "store";
      if (!this.OleDB.Execute(tprogMenu.InsertQuery()))
        return false;
      int num7;
      tprogMenu.pm_MenuCode = num7 = num6 + 1;
      tprogMenu.pm_MenuSortNo = "01110020";
      tprogMenu.pm_MenuName = "일자별";
      tprogMenu.pm_GroupID = num4;
      tprogMenu.pm_ProgID = "/sales/sale/date/page_day.jsp";
      tprogMenu.pm_ProgTitle = "일자별 판매 현황";
      tprogMenu.pm_ViewType = 3;
      tprogMenu.pm_MenuDepth = 4;
      tprogMenu.pm_IconUrl = "day";
      if (!this.OleDB.Execute(tprogMenu.InsertQuery()))
        return false;
      int num8;
      tprogMenu.pm_MenuCode = num8 = num7 + 1;
      tprogMenu.pm_MenuSortNo = "01110030";
      tprogMenu.pm_MenuName = "상품별";
      tprogMenu.pm_GroupID = num4;
      tprogMenu.pm_ProgID = "/sales/sale/date/page_goods.jsp";
      tprogMenu.pm_ProgTitle = "상품별 판매 현황";
      tprogMenu.pm_ViewType = 3;
      tprogMenu.pm_MenuDepth = 4;
      tprogMenu.pm_IconUrl = "goods";
      if (!this.OleDB.Execute(tprogMenu.InsertQuery()))
        return false;
      int num9 = num4 + 1;
      int num10;
      tprogMenu.pm_MenuCode = num10 = num8 + 1;
      tprogMenu.pm_MenuSortNo = "01120000";
      tprogMenu.pm_MenuName = "시간대(세로)별 판매";
      tprogMenu.pm_GroupID = num9;
      tprogMenu.pm_ProgID = "/sales/sale/time/vertical/view";
      tprogMenu.pm_ProgTitle = "시간대별 판매 현황";
      tprogMenu.pm_ViewType = 2;
      tprogMenu.pm_MenuDepth = 3;
      tprogMenu.pm_IconUrl = "sales_time_vertical";
      if (!this.OleDB.Execute(tprogMenu.InsertQuery()))
        return false;
      int num11;
      tprogMenu.pm_MenuCode = num11 = num10 + 1;
      tprogMenu.pm_MenuSortNo = "01120010";
      tprogMenu.pm_MenuName = "지점";
      tprogMenu.pm_GroupID = num9;
      tprogMenu.pm_ProgID = "/sales/sale/time_vertical/page_store.jsp";
      tprogMenu.pm_ProgTitle = "지점 시간대별 판매 현황";
      tprogMenu.pm_ViewType = 3;
      tprogMenu.pm_MenuDepth = 4;
      tprogMenu.pm_IconUrl = "store";
      if (!this.OleDB.Execute(tprogMenu.InsertQuery()))
        return false;
      int num12 = 2000;
      int num13;
      tprogMenu.pm_MenuCode = num13 = num11 + 1;
      tprogMenu.pm_MenuSortNo = "02000000";
      tprogMenu.pm_MenuName = "전표관리";
      tprogMenu.pm_GroupID = num12;
      tprogMenu.pm_ProgID = "전표관리";
      tprogMenu.pm_ProgTitle = "전표관리";
      tprogMenu.pm_ViewType = 1;
      tprogMenu.pm_MenuDepth = 1;
      if (!this.OleDB.Execute(tprogMenu.InsertQuery()))
        return false;
      int num14 = num12 + 1;
      int num15;
      tprogMenu.pm_MenuCode = num15 = num13 + 1;
      tprogMenu.pm_MenuSortNo = "02100000";
      tprogMenu.pm_MenuName = "발주";
      tprogMenu.pm_GroupID = num14;
      tprogMenu.pm_ProgID = "발주";
      tprogMenu.pm_ProgTitle = "발주";
      tprogMenu.pm_ViewType = 1;
      tprogMenu.pm_MenuDepth = 2;
      if (!this.OleDB.Execute(tprogMenu.InsertQuery()))
        return false;
      int num16 = num14 + 1;
      int num17;
      tprogMenu.pm_MenuCode = num17 = num15 + 1;
      tprogMenu.pm_MenuSortNo = "02110000";
      tprogMenu.pm_MenuName = "발주관리";
      tprogMenu.pm_GroupID = num16;
      tprogMenu.pm_ProgID = "/statement/order/view";
      tprogMenu.pm_ProgTitle = "발주관리";
      tprogMenu.pm_ViewType = 2;
      tprogMenu.pm_MenuDepth = 3;
      tprogMenu.pm_IconUrl = "order";
      if (!this.OleDB.Execute(tprogMenu.InsertQuery()))
        return false;
      int num18;
      tprogMenu.pm_MenuCode = num18 = num17 + 1;
      tprogMenu.pm_MenuSortNo = "02110010";
      tprogMenu.pm_MenuName = "주문";
      tprogMenu.pm_GroupID = num16;
      tprogMenu.pm_ProgID = "/statement/order/order/page_order.jsp";
      tprogMenu.pm_ProgTitle = "주문전표 등록 현황";
      tprogMenu.pm_ViewType = 3;
      tprogMenu.pm_MenuDepth = 4;
      tprogMenu.pm_IconUrl = "order";
      if (!this.OleDB.Execute(tprogMenu.InsertQuery()))
        return false;
      int num19;
      tprogMenu.pm_MenuCode = num19 = num18 + 1;
      tprogMenu.pm_MenuSortNo = "02110020";
      tprogMenu.pm_MenuName = "주문 단계";
      tprogMenu.pm_GroupID = num16;
      tprogMenu.pm_ProgID = "/statement/order/order/page_order_tree.jsp";
      tprogMenu.pm_ProgTitle = "주문전표 등록 현황 단계";
      tprogMenu.pm_ViewType = 3;
      tprogMenu.pm_MenuDepth = 4;
      tprogMenu.pm_IconUrl = "depth";
      if (!this.OleDB.Execute(tprogMenu.InsertQuery()))
        return false;
      int num20 = num16 + 1;
      int num21;
      tprogMenu.pm_MenuCode = num21 = num19 + 1;
      tprogMenu.pm_MenuSortNo = "02200000";
      tprogMenu.pm_MenuName = "매입조회";
      tprogMenu.pm_GroupID = num20;
      tprogMenu.pm_ProgID = "매입조회";
      tprogMenu.pm_ProgTitle = "매입조회";
      tprogMenu.pm_ViewType = 1;
      tprogMenu.pm_MenuDepth = 2;
      if (!this.OleDB.Execute(tprogMenu.InsertQuery()))
        return false;
      int num22 = num20 + 1;
      int num23;
      tprogMenu.pm_MenuCode = num23 = num21 + 1;
      tprogMenu.pm_MenuSortNo = "02210000";
      tprogMenu.pm_MenuName = "업체";
      tprogMenu.pm_GroupID = num22;
      tprogMenu.pm_ProgID = "/statement/view/supplier/view";
      tprogMenu.pm_ProgTitle = "업체 기간별 매입 현황";
      tprogMenu.pm_ViewType = 2;
      tprogMenu.pm_MenuDepth = 3;
      tprogMenu.pm_IconUrl = "supplier";
      if (!this.OleDB.Execute(tprogMenu.InsertQuery()))
        return false;
      int num24;
      tprogMenu.pm_MenuCode = num24 = num23 + 1;
      tprogMenu.pm_MenuSortNo = "02210010";
      tprogMenu.pm_MenuName = "지점";
      tprogMenu.pm_GroupID = num22;
      tprogMenu.pm_ProgID = "/statement/view/supplier/page_fromto.jsp";
      tprogMenu.pm_ProgTitle = "업체 기간별 매입 현황";
      tprogMenu.pm_ViewType = 3;
      tprogMenu.pm_MenuDepth = 4;
      tprogMenu.pm_IconUrl = "site";
      if (!this.OleDB.Execute(tprogMenu.InsertQuery()))
        return false;
      int num25;
      tprogMenu.pm_MenuCode = num25 = num24 + 1;
      tprogMenu.pm_MenuSortNo = "02210020";
      tprogMenu.pm_MenuName = "일자(가로)";
      tprogMenu.pm_GroupID = num22;
      tprogMenu.pm_ProgID = "/statement/view/supplier/page_day_horizontal.jsp";
      tprogMenu.pm_ProgTitle = "업체 일자(가로)별 매입 현황";
      tprogMenu.pm_ViewType = 3;
      tprogMenu.pm_MenuDepth = 4;
      tprogMenu.pm_IconUrl = "day_horizontal";
      if (!this.OleDB.Execute(tprogMenu.InsertQuery()))
        return false;
      int num26;
      tprogMenu.pm_MenuCode = num26 = num25 + 1;
      tprogMenu.pm_MenuSortNo = "02210030";
      tprogMenu.pm_MenuName = "일자(세로)";
      tprogMenu.pm_GroupID = num22;
      tprogMenu.pm_ProgID = "/statement/view/supplier/page_day.jsp";
      tprogMenu.pm_ProgTitle = "업체 일자(세로)별 매입 현황";
      tprogMenu.pm_ViewType = 3;
      tprogMenu.pm_MenuDepth = 4;
      tprogMenu.pm_IconUrl = "day_vertical";
      if (!this.OleDB.Execute(tprogMenu.InsertQuery()))
        return false;
      int num27;
      tprogMenu.pm_MenuCode = num27 = num26 + 1;
      tprogMenu.pm_MenuSortNo = "02210050";
      tprogMenu.pm_MenuName = "상품";
      tprogMenu.pm_GroupID = num22;
      tprogMenu.pm_ProgID = "/statement/view/supplier/page_goods.jsp";
      tprogMenu.pm_ProgTitle = "업체 상품별 매입 현황";
      tprogMenu.pm_ViewType = 3;
      tprogMenu.pm_MenuDepth = 4;
      tprogMenu.pm_IconUrl = "goods";
      if (!this.OleDB.Execute(tprogMenu.InsertQuery()))
        return false;
      Log.Logger.DebugColor("\n - END BizSCM");
      return true;
    }

    private bool InitTableBizSMCampaign(long pSiteID)
    {
      int num1 = 8000;
      TProgMenu pData1 = this.OleDB.Create<TProgMenu>();
      pData1.pm_MenuCode = 701;
      int pmMenuCode = pData1.pm_MenuCode;
      pData1.pm_SiteID = pSiteID;
      pData1.pm_ProgKind = 5;
      pData1.pm_MenuSortNo = "08000000";
      pData1.pm_MenuName = "캠페인";
      pData1.pm_GroupID = num1;
      pData1.pm_ProgID = "캠페인";
      pData1.pm_ProgTitle = "캠페인";
      pData1.pm_ViewType = 1;
      pData1.pm_MenuDepth = 1;
      pData1.pm_IconUrl = "price_manage";
      if (!this.OleDB.Execute(pData1.InsertQuery()))
        return false;
      int p_pm_GroupID1 = num1 + 1;
      int num2;
      TProgMenu pData2 = this.InitTableBizSMLv2(pData1, num2 = pmMenuCode + 1, "08100000", "등록", p_pm_GroupID1, "등록", "등록", "info");
      if (!this.OleDB.Execute(pData2.InsertQuery()))
        return false;
      int p_pm_GroupID2 = p_pm_GroupID1 + 1;
      int num3;
      TProgMenu pData3 = this.InitTableBizSMLv3(pData2, num3 = num2 + 1, "08110000", "캠페인", p_pm_GroupID2, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "캠페인", "campaign");
      if (!this.OleDB.Execute(pData3.InsertQuery()))
        return false;
      string str1 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Campaign.Reg.Campaign.";
      int num4;
      TProgMenu pData4 = this.InitTableBizSMLv4(pData3, num4 = num3 + 1, "08110010", "캠페인", p_pm_GroupID2, str1 + "CampaignPageVM", "캠페인", "campaign");
      if (!this.OleDB.Execute(pData4.InsertQuery()))
        return false;
      int p_pm_GroupID3 = p_pm_GroupID2 + 1;
      int num5;
      TProgMenu pData5 = this.InitTableBizSMLv3(pData4, num5 = num4 + 1, "08120000", "프로모션", p_pm_GroupID3, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "프로모션", "campaign");
      if (!this.OleDB.Execute(pData5.InsertQuery()))
        return false;
      string str2 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Campaign.Reg.Promotion.";
      int num6;
      TProgMenu pData6 = this.InitTableBizSMLv4(pData5, num6 = num5 + 1, "08120010", "프로모션", p_pm_GroupID3, str2 + "PromotionPageVM", "프로모션", "campaign");
      if (!this.OleDB.Execute(pData6.InsertQuery()))
        return false;
      int p_pm_GroupID4 = p_pm_GroupID3 + 1;
      int num7;
      TProgMenu pData7 = this.InitTableBizSMLv3(pData6, num7 = num6 + 1, "08130000", "쿠폰", p_pm_GroupID4, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "쿠폰", "campaign");
      if (!this.OleDB.Execute(pData7.InsertQuery()))
        return false;
      string str3 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Campaign.Reg.Coupon.";
      int num8;
      TProgMenu pData8 = this.InitTableBizSMLv4(pData7, num8 = num7 + 1, "08130010", "쿠폰", p_pm_GroupID4, str3 + "CouponPageVM", "쿠폰", "campaign");
      if (!this.OleDB.Execute(pData8.InsertQuery()))
        return false;
      int p_pm_GroupID5 = p_pm_GroupID4 + 1;
      int num9;
      TProgMenu pData9 = this.InitTableBizSMLv2(pData8, num9 = num8 + 1, "08200000", "조회", p_pm_GroupID5, "조회", "조회", "member");
      if (!this.OleDB.Execute(pData9.InsertQuery()))
        return false;
      int p_pm_GroupID6 = p_pm_GroupID5 + 1;
      int num10;
      TProgMenu pData10 = this.InitTableBizSMLv3(pData9, num10 = num9 + 1, "08210000", "기본조회", p_pm_GroupID6, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "기본조회", "campaign");
      if (!this.OleDB.Execute(pData10.InsertQuery()))
        return false;
      string str4 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Campaign.Inq.Basic.";
      int num11;
      TProgMenu pData11 = this.InitTableBizSMLv4(pData10, num11 = num10 + 1, "08210010", "기본", p_pm_GroupID6, str4 + "CampaignInqBasicBasicPageVM", "기본조회(기본)", "member_info");
      int num12;
      return this.OleDB.Execute(pData11.InsertQuery()) && this.OleDB.Execute(this.InitTableBizSMLv4(pData11, num12 = num11 + 1, "08210020", "캠페인별", p_pm_GroupID6, str4 + "CampaignInqBasicCampaignPageVM", "기본조회(캠페인별)", "member").InsertQuery());
    }

    private bool InitTableBizSMCode(long pSiteID)
    {
      int num1 = 3000;
      TProgMenu pData1 = this.OleDB.Create<TProgMenu>();
      pData1.pm_MenuCode = 201;
      int pmMenuCode = pData1.pm_MenuCode;
      pData1.pm_SiteID = pSiteID;
      pData1.pm_ProgKind = 5;
      pData1.pm_MenuSortNo = "03000000";
      pData1.pm_MenuName = "코드관리";
      pData1.pm_GroupID = num1;
      pData1.pm_ProgID = "코드관리";
      pData1.pm_ProgTitle = "코드관리";
      pData1.pm_ViewType = 1;
      pData1.pm_MenuDepth = 1;
      pData1.pm_IconUrl = "invoice";
      if (!this.OleDB.Execute(pData1.InsertQuery()))
        return false;
      int p_pm_GroupID1 = num1 + 1;
      int num2;
      TProgMenu pData2 = this.InitTableBizSMLv2(pData1, num2 = pmMenuCode + 1, "03100000", "기초정보", p_pm_GroupID1, "기초정보", "기초정보", "info");
      if (!this.OleDB.Execute(pData2.InsertQuery()))
        return false;
      int p_pm_GroupID2 = p_pm_GroupID1 + 1;
      int num3;
      TProgMenu pData3 = this.InitTableBizSMLv3(pData2, num3 = num2 + 1, "03110000", "지점", p_pm_GroupID2, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "지점 등록 현황", "site");
      if (!this.OleDB.Execute(pData3.InsertQuery()))
        return false;
      string str1 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Code.BasicInfo.Store.";
      int num4;
      TProgMenu pData4 = this.InitTableBizSMLv4(pData3, num4 = num3 + 1, "03110010", "지점", p_pm_GroupID2, str1 + "StoreListPageVM", "지점리스트", "site");
      if (!this.OleDB.Execute(pData4.InsertQuery()))
        return false;
      int num5;
      TProgMenu pData5 = this.InitTableBizSMLv4(pData4, num5 = num4 + 1, "03110020", "지점 그룹", p_pm_GroupID2, str1 + "StoreGroupPageVM", "지점 그룹 조회", "group");
      if (!this.OleDB.Execute(pData5.InsertQuery()))
        return false;
      int p_pm_GroupID3 = p_pm_GroupID2 + 1;
      int num6;
      TProgMenu pData6 = this.InitTableBizSMLv3(pData5, num6 = num5 + 1, "03120000", "사원", p_pm_GroupID3, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "사원 등록 현황", "employee");
      if (!this.OleDB.Execute(pData6.InsertQuery()))
        return false;
      string str2 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Code.BasicInfo.Employee.";
      int num7;
      TProgMenu pData7 = this.InitTableBizSMLv4(pData6, num7 = num6 + 1, "03120010", "사원", p_pm_GroupID3, str2 + "EmployeeListPageVM", "사원리스트", "employee");
      if (!this.OleDB.Execute(pData7.InsertQuery()))
        return false;
      int p_pm_GroupID4 = p_pm_GroupID3 + 1;
      int num8;
      TProgMenu pData8 = this.InitTableBizSMLv2(pData7, num8 = num7 + 1, "03200000", "코드정보", p_pm_GroupID4, "코드정보", "코드정보", "common_code");
      if (!this.OleDB.Execute(pData8.InsertQuery()))
        return false;
      int p_pm_GroupID5 = p_pm_GroupID4 + 1;
      int num9;
      TProgMenu pData9 = this.InitTableBizSMLv3(pData8, num9 = num8 + 1, "03210000", "부서", p_pm_GroupID5, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "부서 등록 현황", "department");
      if (!this.OleDB.Execute(pData9.InsertQuery()))
        return false;
      string str3 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Code.CodeInfo.Dept.";
      int num10;
      TProgMenu pData10 = this.InitTableBizSMLv4(pData9, num10 = num9 + 1, "03210010", "단계", p_pm_GroupID5, str3 + "DeptDepthPageVM", "부서단계", "tree");
      if (!this.OleDB.Execute(pData10.InsertQuery()))
        return false;
      int num11;
      TProgMenu pData11 = this.InitTableBizSMLv4(pData10, num11 = num10 + 1, "03210020", "리스트", p_pm_GroupID5, str3 + "DeptListPageVM", "부서리스트", "department");
      if (!this.OleDB.Execute(pData11.InsertQuery()))
        return false;
      int p_pm_GroupID6 = p_pm_GroupID5 + 1;
      int num12;
      TProgMenu pData12 = this.InitTableBizSMLv3(pData11, num12 = num11 + 1, "03220000", "분류", p_pm_GroupID6, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "분류 등록 현황", "category");
      if (!this.OleDB.Execute(pData12.InsertQuery()))
        return false;
      string str4 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Code.CodeInfo.Category.";
      int num13;
      TProgMenu pData13 = this.InitTableBizSMLv4(pData12, num13 = num12 + 1, "03220010", "단계", p_pm_GroupID6, str4 + "CategoryDepthPageVM", "분류단계", "tree");
      if (!this.OleDB.Execute(pData13.InsertQuery()))
        return false;
      int num14;
      TProgMenu pData14 = this.InitTableBizSMLv4(pData13, num14 = num13 + 1, "03220020", "리스트", p_pm_GroupID6, str4 + "CategoryListPageVM", "분류리스트", "category");
      if (!this.OleDB.Execute(pData14.InsertQuery()))
        return false;
      int p_pm_GroupID7 = p_pm_GroupID6 + 1;
      int num15;
      TProgMenu pData15 = this.InitTableBizSMLv3(pData14, num15 = num14 + 1, "03230000", "가상분류", p_pm_GroupID7, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "가상분류 등록 현황", "category");
      if (!this.OleDB.Execute(pData15.InsertQuery()))
        return false;
      string str5 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Code.CodeInfo.EmployeeCategory.";
      int num16;
      TProgMenu pData16 = this.InitTableBizSMLv4(pData15, num16 = num15 + 1, "03230010", "단계", p_pm_GroupID7, str5 + "EmployeeCategoryDepthPageVM", "분류단계", "tree");
      if (!this.OleDB.Execute(pData16.InsertQuery()))
        return false;
      int num17;
      TProgMenu pData17 = this.InitTableBizSMLv4(pData16, num17 = num16 + 1, "03230020", "리스트", p_pm_GroupID7, str5 + "CategoryListPageVM", "분류리스트", "category");
      if (!this.OleDB.Execute(pData17.InsertQuery()))
        return false;
      int p_pm_GroupID8 = p_pm_GroupID7 + 1;
      int num18;
      TProgMenu pData18 = this.InitTableBizSMLv3(pData17, num18 = num17 + 1, "03240000", "업체", p_pm_GroupID8, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "업체 등록 현황", "company");
      if (!this.OleDB.Execute(pData18.InsertQuery()))
        return false;
      string str6 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Code.CodeInfo.Supplier.";
      int num19;
      TProgMenu pData19 = this.InitTableBizSMLv4(pData18, num19 = num18 + 1, "03240010", "업체", p_pm_GroupID8, str6 + "SupplierListPageVM", "업체 리스트", "company");
      if (!this.OleDB.Execute(pData19.InsertQuery()))
        return false;
      int p_pm_GroupID9 = p_pm_GroupID8 + 1;
      int num20;
      TProgMenu pData20 = this.InitTableBizSMLv3(pData19, num20 = num19 + 1, "03250000", "제조사", p_pm_GroupID9, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "제조사 등록 현황", "company");
      if (!this.OleDB.Execute(pData20.InsertQuery()))
        return false;
      string str7 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Code.CodeInfo.Maker.";
      int num21;
      TProgMenu pData21 = this.InitTableBizSMLv4(pData20, num21 = num20 + 1, "03250010", "제조사", p_pm_GroupID9, str7 + "MakerListPageVM", "제조사 리스트", "company");
      if (!this.OleDB.Execute(pData21.InsertQuery()))
        return false;
      int p_pm_GroupID10 = p_pm_GroupID9 + 1;
      int num22;
      TProgMenu pData22 = this.InitTableBizSMLv3(pData21, num22 = num21 + 1, "03260000", "브랜드", p_pm_GroupID10, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "브랜드 등록 현황", "company");
      if (!this.OleDB.Execute(pData22.InsertQuery()))
        return false;
      string str8 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Code.CodeInfo.Brand.";
      int num23;
      TProgMenu pData23 = this.InitTableBizSMLv4(pData22, num23 = num22 + 1, "03260010", "브랜드", p_pm_GroupID10, str8 + "BrandListPageVM", "브랜드 리스트", "company");
      if (!this.OleDB.Execute(pData23.InsertQuery()))
        return false;
      int p_pm_GroupID11 = p_pm_GroupID10 + 1;
      int num24;
      TProgMenu pData24 = this.InitTableBizSMLv2(pData23, num24 = num23 + 1, "03400000", "상품정보", p_pm_GroupID11, "상품정보", "상품정보", "item");
      if (!this.OleDB.Execute(pData24.InsertQuery()))
        return false;
      int p_pm_GroupID12 = p_pm_GroupID11 + 1;
      int num25;
      TProgMenu pData25 = this.InitTableBizSMLv3(pData24, num25 = num24 + 1, "03410000", "상품관리", p_pm_GroupID12, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "상품 등록 현황", "item_manage");
      if (!this.OleDB.Execute(pData25.InsertQuery()))
        return false;
      string str9 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Code.GoodsInfo.Goods.";
      int num26;
      TProgMenu pData26 = this.InitTableBizSMLv4(pData25, num26 = num25 + 1, "03410010", "상품조회", p_pm_GroupID12, str9 + "GoodsListPageVM", "상품 리스트", "item_manage");
      if (!this.OleDB.Execute(pData26.InsertQuery()))
        return false;
      int num27;
      TProgMenu pData27 = this.InitTableBizSMLv4(pData26, num27 = num26 + 1, "03410020", "박스", p_pm_GroupID12, str9 + "GoodsBoxListPageVM", "박스 리스트", "set");
      if (!this.OleDB.Execute(pData27.InsertQuery()))
        return false;
      int num28;
      TProgMenu pData28 = this.InitTableBizSMLv4(pData27, num28 = num27 + 1, "03410030", "이력", p_pm_GroupID12, str9 + "GoodsHistoryPageVM", "기간별 이력 조회", "set");
      if (!this.OleDB.Execute(pData28.InsertQuery()))
        return false;
      int num29;
      TProgMenu pData29 = this.InitTableBizSMLv4(pData28, num29 = num28 + 1, "03410040", "점별이력", p_pm_GroupID12, str9 + "GoodsHistoryByStorePageVM", "점별 이력 조회", "set");
      if (!this.OleDB.Execute(pData29.InsertQuery()))
        return false;
      int num30;
      TProgMenu pData30 = this.InitTableBizSMLv4(pData29, num30 = num29 + 1, "03410050", "점별상품", p_pm_GroupID12, str9 + "GoodsByStorePageVM", "점별 상품 조회", "set");
      if (!this.OleDB.Execute(pData30.InsertQuery()))
        return false;
      int p_pm_GroupID13 = p_pm_GroupID12 + 1;
      int num31;
      TProgMenu pData31 = this.InitTableBizSMLv3(pData30, num31 = num30 + 1, "03430000", "가격관리", p_pm_GroupID13, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "원매가변경", "item_price_changed");
      if (!this.OleDB.Execute(pData31.InsertQuery()))
        return false;
      string str10 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Code.GoodsInfo.GoodsPrice.";
      int num32;
      TProgMenu pData32 = this.InitTableBizSMLv4(pData31, num32 = num31 + 1, "03430010", "원매가", p_pm_GroupID13, str10 + "GoodsPriceChangePageVM", "원매가 변경 리스트", "price_changed");
      if (!this.OleDB.Execute(pData32.InsertQuery()))
        return false;
      int num33;
      TProgMenu pData33 = this.InitTableBizSMLv4(pData32, num33 = num32 + 1, "03430020", "행사가", p_pm_GroupID13, str10 + "GoodsEventPriceChangePageVM", "행사 상품 리스트", "event_sale");
      if (!this.OleDB.Execute(pData33.InsertQuery()))
        return false;
      int num34;
      TProgMenu pData34 = this.InitTableBizSMLv4(pData33, num34 = num33 + 1, "03430030", "회원가", p_pm_GroupID13, str10 + "GoodsMemberPriceChangePageVM", "회원 행사 상품 리스트", "member");
      if (!this.OleDB.Execute(pData34.InsertQuery()))
        return false;
      int num35;
      TProgMenu pData35 = this.InitTableBizSMLv4(pData34, num35 = num34 + 1, "03430040", "회원 할인율", p_pm_GroupID13, str10 + "GoodsMemberPriceChangePageVM", "회원 등급별 할인 리스트", "member");
      if (!this.OleDB.Execute(pData35.InsertQuery()))
        return false;
      int p_pm_GroupID14 = p_pm_GroupID13 + 1;
      int num36;
      TProgMenu pData36 = this.InitTableBizSMLv3(pData35, num36 = num35 + 1, "03450000", "이력관리", p_pm_GroupID14, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "이력변경", "item_price_changed");
      if (!this.OleDB.Execute(pData36.InsertQuery()))
        return false;
      string str11 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Code.GoodsInfo.GoodsHistory.";
      int num37;
      return this.OleDB.Execute(this.InitTableBizSMLv4(pData36, num37 = num36 + 1, "03450010", "이력관리", p_pm_GroupID14, str11 + "GoodsHistoryChangePageVM", "이력관리 리스트", "history_changed").InsertQuery());
    }

    private bool InitTableBizSM(long pSiteID)
    {
      Log.Logger.DebugColor("\n - START BizSM");
      Log.Logger.DebugColor("\n - BizSM.Sale");
      if (!this.InitTableBizSMSale(pSiteID))
        return false;
      Log.Logger.DebugColor("\n - BizSM.Order");
      if (!this.InitTableBizSMOrder(pSiteID))
        return false;
      Log.Logger.DebugColor("\n - BizSM.Code");
      if (!this.InitTableBizSMCode(pSiteID))
        return false;
      Log.Logger.DebugColor("\n - BizSM.Profit");
      if (!this.InitTableBizSMProfit(pSiteID))
        return false;
      Log.Logger.DebugColor("\n - BizSM.Pos");
      if (!this.InitTableBizSMPos(pSiteID))
        return false;
      Log.Logger.DebugColor("\n - BizSM.Payment");
      if (!this.InitTableBizSMPayment(pSiteID))
        return false;
      Log.Logger.DebugColor("\n - BizSM.Member");
      if (!this.InitTableBizSMMember(pSiteID))
        return false;
      Log.Logger.DebugColor("\n - BizSM.Campaign");
      if (!this.InitTableBizSMCampaign(pSiteID) || !this.InitTableBizSMSystem(pSiteID))
        return false;
      Log.Logger.DebugColor("\n - END BizSM");
      return true;
    }

    private TProgMenu InitTableBizSMLv2(
      TProgMenu pData,
      int p_pm_MenuCode,
      string p_pm_MenuSortNo,
      string p_pm_MenuName,
      int p_pm_GroupID,
      string p_pm_ProgID,
      string p_pm_ProgTitle,
      string p_pm_IconUrl = null)
    {
      pData.pm_MenuCode = p_pm_MenuCode;
      pData.pm_MenuSortNo = p_pm_MenuSortNo;
      pData.pm_MenuName = p_pm_MenuName;
      pData.pm_GroupID = p_pm_GroupID;
      pData.pm_ProgID = p_pm_ProgID;
      pData.pm_ProgTitle = p_pm_ProgTitle;
      pData.pm_ViewType = 1;
      pData.pm_MenuDepth = 2;
      pData.pm_IconUrl = p_pm_IconUrl;
      return pData;
    }

    private TProgMenu InitTableBizSMLv3(
      TProgMenu pData,
      int p_pm_MenuCode,
      string p_pm_MenuSortNo,
      string p_pm_MenuName,
      int p_pm_GroupID,
      string p_pm_ProgID,
      string p_pm_ProgTitle,
      string p_pm_IconUrl = null)
    {
      pData.pm_MenuCode = p_pm_MenuCode;
      pData.pm_MenuSortNo = p_pm_MenuSortNo;
      pData.pm_MenuName = p_pm_MenuName;
      pData.pm_GroupID = p_pm_GroupID;
      pData.pm_ProgID = p_pm_ProgID;
      pData.pm_ProgTitle = p_pm_ProgTitle;
      pData.pm_ViewType = 2;
      pData.pm_MenuDepth = 3;
      pData.pm_IconUrl = p_pm_IconUrl;
      return pData;
    }

    private TProgMenu InitTableBizSMLv4(
      TProgMenu pData,
      int p_pm_MenuCode,
      string p_pm_MenuSortNo,
      string p_pm_MenuName,
      int p_pm_GroupID,
      string p_pm_ProgID,
      string p_pm_ProgTitle,
      string p_pm_IconUrl = null)
    {
      pData.pm_MenuCode = p_pm_MenuCode;
      pData.pm_MenuSortNo = p_pm_MenuSortNo;
      pData.pm_MenuName = p_pm_MenuName;
      pData.pm_GroupID = p_pm_GroupID;
      pData.pm_ProgID = p_pm_ProgID;
      pData.pm_ProgTitle = p_pm_ProgTitle;
      pData.pm_ViewType = 3;
      pData.pm_MenuDepth = 4;
      pData.pm_IconUrl = p_pm_IconUrl;
      return pData;
    }

    private bool InitTableBizSMMember(long pSiteID)
    {
      int num1 = 7000;
      TProgMenu pData1 = this.OleDB.Create<TProgMenu>();
      pData1.pm_MenuCode = 601;
      int pmMenuCode = pData1.pm_MenuCode;
      pData1.pm_SiteID = pSiteID;
      pData1.pm_ProgKind = 5;
      pData1.pm_MenuSortNo = "07000000";
      pData1.pm_MenuName = "고객관리";
      pData1.pm_GroupID = num1;
      pData1.pm_ProgID = "고객관리";
      pData1.pm_ProgTitle = "고객관리";
      pData1.pm_ViewType = 1;
      pData1.pm_MenuDepth = 1;
      pData1.pm_IconUrl = "member";
      if (!this.OleDB.Execute(pData1.InsertQuery()))
        return false;
      int p_pm_GroupID1 = num1 + 1;
      int num2;
      TProgMenu pData2 = this.InitTableBizSMLv2(pData1, num2 = pmMenuCode + 1, "07100000", "기초정보", p_pm_GroupID1, "기초정보", "기초정보", "info");
      if (!this.OleDB.Execute(pData2.InsertQuery()))
        return false;
      int p_pm_GroupID2 = p_pm_GroupID1 + 1;
      int num3;
      TProgMenu pData3 = this.InitTableBizSMLv3(pData2, num3 = num2 + 1, "07110000", "회원유형", p_pm_GroupID2, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "회원유형", "member_type");
      if (!this.OleDB.Execute(pData3.InsertQuery()))
        return false;
      string str1 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Member.BaseInfo.RegType.";
      int num4;
      TProgMenu pData4 = this.InitTableBizSMLv4(pData3, num4 = num3 + 1, "07110010", "회원유형", p_pm_GroupID2, str1 + "RegTypePageVM", "회원유형", "member_type");
      if (!this.OleDB.Execute(pData4.InsertQuery()))
        return false;
      int num5;
      TProgMenu pData5 = this.InitTableBizSMLv4(pData4, num5 = num4 + 1, "07110020", "회원유형이력", p_pm_GroupID2, str1 + "RegTypeHistoryPageVM", "회원 유형 이력", "member_type");
      if (!this.OleDB.Execute(pData5.InsertQuery()))
        return false;
      int p_pm_GroupID3 = p_pm_GroupID2 + 1;
      int num6;
      TProgMenu pData6 = this.InitTableBizSMLv3(pData5, num6 = num5 + 1, "07130000", "회원그룹", p_pm_GroupID3, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "회원그룹", "member_group");
      if (!this.OleDB.Execute(pData6.InsertQuery()))
        return false;
      string str2 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Member.BaseInfo.RegGroup.";
      int num7;
      TProgMenu pData7 = this.InitTableBizSMLv4(pData6, num7 = num6 + 1, "07130010", "회원그룹", p_pm_GroupID3, str2 + "RegGroupPageVM", "회원그룹", "member_type");
      if (!this.OleDB.Execute(pData7.InsertQuery()))
        return false;
      int p_pm_GroupID4 = p_pm_GroupID3 + 1;
      int num8;
      TProgMenu pData8 = this.InitTableBizSMLv3(pData7, num8 = num7 + 1, "07150000", "회원상태", p_pm_GroupID4, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "회원상태", "member_state");
      if (!this.OleDB.Execute(pData8.InsertQuery()))
        return false;
      string str3 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Member.BaseInfo.RegCycle.";
      int num9;
      TProgMenu pData9 = this.InitTableBizSMLv4(pData8, num9 = num8 + 1, "07150020", "산정기준", p_pm_GroupID4, str3 + "RegCycleStdPageVM", "산정기준", "standard");
      if (!this.OleDB.Execute(pData9.InsertQuery()))
        return false;
      int p_pm_GroupID5 = p_pm_GroupID4 + 1;
      int num10;
      TProgMenu pData10 = this.InitTableBizSMLv3(pData9, num10 = num9 + 1, "07170000", "회원등급", p_pm_GroupID5, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "회원등급", "benchmark");
      if (!this.OleDB.Execute(pData10.InsertQuery()))
        return false;
      string str4 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Member.BaseInfo.RegGrade.";
      int num11;
      TProgMenu pData11 = this.InitTableBizSMLv4(pData10, num11 = num10 + 1, "07170010", "등급등록", p_pm_GroupID5, str4 + "RegGradePageVM", "회원 등급 등록", "benchmark_registration");
      if (!this.OleDB.Execute(pData11.InsertQuery()))
        return false;
      int num12;
      TProgMenu pData12 = this.InitTableBizSMLv4(pData11, num12 = num11 + 1, "07170020", "산정기준", p_pm_GroupID5, str4 + "RegGradeStdPageVM", "산정기준 등록", "standard");
      if (!this.OleDB.Execute(pData12.InsertQuery()))
        return false;
      int p_pm_GroupID6 = p_pm_GroupID5 + 1;
      int num13;
      TProgMenu pData13 = this.InitTableBizSMLv3(pData12, num13 = num12 + 1, "07180000", "마감조건", p_pm_GroupID6, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "마감조건", "set");
      if (!this.OleDB.Execute(pData13.InsertQuery()))
        return false;
      string str5 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Member.BaseInfo.RegCalcCycle.";
      int num14;
      TProgMenu pData14 = this.InitTableBizSMLv4(pData13, num14 = num13 + 1, "07180010", "EOD마감", p_pm_GroupID6, str5 + "RegCalcCyclePageVM", "EOD 마감 조건", "set");
      if (!this.OleDB.Execute(pData14.InsertQuery()))
        return false;
      int p_pm_GroupID7 = p_pm_GroupID6 + 1;
      int num15;
      TProgMenu pData15 = this.InitTableBizSMLv2(pData14, num15 = num14 + 1, "07300000", "회원", p_pm_GroupID7, "회원", "회원", "member");
      if (!this.OleDB.Execute(pData15.InsertQuery()))
        return false;
      int p_pm_GroupID8 = p_pm_GroupID7 + 1;
      int num16;
      TProgMenu pData16 = this.InitTableBizSMLv3(pData15, num16 = num15 + 1, "07310000", "회원정보", p_pm_GroupID8, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "회원정보", "member_info");
      if (!this.OleDB.Execute(pData16.InsertQuery()))
        return false;
      string str6 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Member.MemberInfo.RegMember.";
      int num17;
      TProgMenu pData17 = this.InitTableBizSMLv4(pData16, num17 = num16 + 1, "07310010", "회원정보", p_pm_GroupID8, str6 + "RegMemberPageVM", "회원정보", "member_info");
      if (!this.OleDB.Execute(pData17.InsertQuery()))
        return false;
      int p_pm_GroupID9 = p_pm_GroupID8 + 1;
      int num18;
      TProgMenu pData18 = this.InitTableBizSMLv2(pData17, num18 = num17 + 1, "07500000", "세금계산서", p_pm_GroupID9, "세금계산서", "세금계산서", "member");
      if (!this.OleDB.Execute(pData18.InsertQuery()))
        return false;
      int p_pm_GroupID10 = p_pm_GroupID9 + 1;
      int num19;
      TProgMenu pData19 = this.InitTableBizSMLv3(pData18, num19 = num18 + 1, "07510000", "수기발행", p_pm_GroupID10, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "수기발행", "member_info");
      if (!this.OleDB.Execute(pData19.InsertQuery()))
        return false;
      string str7 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Member.TaxBill.Reg.";
      int num20;
      TProgMenu pData20 = this.InitTableBizSMLv4(pData19, num20 = num19 + 1, "07510010", "수기발행", p_pm_GroupID10, str7 + "RegTaxBillPageVM", "수기발행", "member_info");
      if (!this.OleDB.Execute(pData20.InsertQuery()))
        return false;
      int p_pm_GroupID11 = p_pm_GroupID10 + 1;
      int num21;
      TProgMenu pData21 = this.InitTableBizSMLv3(pData20, num21 = num20 + 1, "07530000", "세금계산서조회", p_pm_GroupID11, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "세금계산서조회", "member_info");
      if (!this.OleDB.Execute(pData21.InsertQuery()))
        return false;
      string str8 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Member.TaxBill.Inq.";
      int num22;
      TProgMenu pData22 = this.InitTableBizSMLv4(pData21, num22 = num21 + 1, "07530010", "세금계산서", p_pm_GroupID11, str8 + "TaxBillPageVM", "세금계산서 조회", "member_info");
      if (!this.OleDB.Execute(pData22.InsertQuery()))
        return false;
      int p_pm_GroupID12 = p_pm_GroupID11 + 1;
      int num23;
      TProgMenu pData23 = this.InitTableBizSMLv2(pData22, num23 = num22 + 1, "07600000", "조회", p_pm_GroupID12, "조회", "조회", "member");
      if (!this.OleDB.Execute(pData23.InsertQuery()))
        return false;
      int p_pm_GroupID13 = p_pm_GroupID12 + 1;
      int num24;
      TProgMenu pData24 = this.InitTableBizSMLv3(pData23, num24 = num23 + 1, "07610000", "기본조회", p_pm_GroupID13, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "기본조회", "member_info");
      if (!this.OleDB.Execute(pData24.InsertQuery()))
        return false;
      string str9 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Member.Inq.Basic.";
      int num25;
      TProgMenu pData25 = this.InitTableBizSMLv4(pData24, num25 = num24 + 1, "07610010", "포인트일별현황", p_pm_GroupID13, str9 + "MemberInqBasicPointDayStatusPageVM", "기본조회(포인트일별현황)", "member_info");
      if (!this.OleDB.Execute(pData25.InsertQuery()))
        return false;
      int num26;
      TProgMenu pData26 = this.InitTableBizSMLv4(pData25, num26 = num25 + 1, "07610020", "회원주기변경이력", p_pm_GroupID13, str9 + "MemberInqBasicCycleChgHisPageVM", "기본조회(회원주기변경이력)", "member");
      if (!this.OleDB.Execute(pData26.InsertQuery()))
        return false;
      int num27;
      TProgMenu pData27 = this.InitTableBizSMLv4(pData26, num27 = num26 + 1, "07610030", "회원등급변경이력", p_pm_GroupID13, str9 + "MemberInqBasicGradeChgHisPageVM", "기본조회(회원등급변경이력)", "member");
      if (!this.OleDB.Execute(pData27.InsertQuery()))
        return false;
      int p_pm_GroupID14 = p_pm_GroupID13 + 1;
      int num28;
      TProgMenu pData28 = this.InitTableBizSMLv3(pData27, num28 = num27 + 1, "07620000", "회원현황", p_pm_GroupID14, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "회원현황", "member");
      if (!this.OleDB.Execute(pData28.InsertQuery()))
        return false;
      string str10 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Member.Inq.Status.";
      int num29;
      TProgMenu pData29 = this.InitTableBizSMLv4(pData28, num29 = num28 + 1, "07620010", "년간 신규가입 회원수", p_pm_GroupID14, str10 + "MemberInqStatusYearNewRegPageVM", "회원현황(년간 신규가입 회원수)", "member_info");
      if (!this.OleDB.Execute(pData29.InsertQuery()))
        return false;
      int num30;
      TProgMenu pData30 = this.InitTableBizSMLv4(pData29, num30 = num29 + 1, "07620020", "회원상세", p_pm_GroupID14, str10 + "MemberInqStatusMemberPageVM", "회원현황(회원상세)", "member");
      if (!this.OleDB.Execute(pData30.InsertQuery()))
        return false;
      int num31;
      TProgMenu pData31 = this.InitTableBizSMLv4(pData30, num31 = num30 + 1, "07620030", "연령대/구매주기 회원수", p_pm_GroupID14, str10 + "MemberInqStatusMemberCntPageVM", "회원현황(연령대/구매주기 회원수)", "member");
      if (!this.OleDB.Execute(pData31.InsertQuery()))
        return false;
      int p_pm_GroupID15 = p_pm_GroupID14 + 1;
      int num32;
      TProgMenu pData32 = this.InitTableBizSMLv3(pData31, num32 = num31 + 1, "07630000", "BestWorst상품", p_pm_GroupID15, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "BestWorst상품", "member");
      if (!this.OleDB.Execute(pData32.InsertQuery()))
        return false;
      string str11 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Member.Inq.BestWorst.";
      int num33;
      TProgMenu pData33 = this.InitTableBizSMLv4(pData32, num33 = num32 + 1, "07630010", "기본", p_pm_GroupID15, str11 + "MemberInqBestWorstBasicPageVM", "BestWorst상품(기본)", "member_info");
      if (!this.OleDB.Execute(pData33.InsertQuery()))
        return false;
      int num34;
      TProgMenu pData34 = this.InitTableBizSMLv4(pData33, num34 = num33 + 1, "07630020", "회원속성별", p_pm_GroupID15, str11 + "MemberInqBestWorstMemberAttributePageVM", "BestWorst상품(회원속성별)", "member");
      if (!this.OleDB.Execute(pData34.InsertQuery()))
        return false;
      int num35;
      TProgMenu pData35 = this.InitTableBizSMLv4(pData34, num35 = num34 + 1, "07630030", "구매순위", p_pm_GroupID15, str11 + "MemberInqBestWorstBuyRankingPageVM", "BestWorst상품(구매순위)", "member");
      if (!this.OleDB.Execute(pData35.InsertQuery()))
        return false;
      int p_pm_GroupID16 = p_pm_GroupID15 + 1;
      int num36;
      TProgMenu pData36 = this.InitTableBizSMLv3(pData35, num36 = num35 + 1, "07640000", "회원매출", p_pm_GroupID16, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "회원매출", "member");
      if (!this.OleDB.Execute(pData36.InsertQuery()))
        return false;
      string str12 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Member.Inq.Sales.";
      int num37;
      TProgMenu pData37 = this.InitTableBizSMLv4(pData36, num37 = num36 + 1, "07640010", "영수증", p_pm_GroupID16, str12 + "MemberInqSalesSlipPageVM", "회원매출(영수증)", "member_info");
      if (!this.OleDB.Execute(pData37.InsertQuery()))
        return false;
      int num38;
      TProgMenu pData38 = this.InitTableBizSMLv4(pData37, num38 = num37 + 1, "07640020", "일별", p_pm_GroupID16, str12 + "MemberInqSalesDayAllPageVM", "회원매출(일별)", "member");
      if (!this.OleDB.Execute(pData38.InsertQuery()))
        return false;
      int num39;
      TProgMenu pData39 = this.InitTableBizSMLv4(pData38, num39 = num38 + 1, "07640030", "일별 회원속성", p_pm_GroupID16, str12 + "MemberInqSalesDayMemberAttributePageVM", "회원매출(일별 회원속성)", "member");
      if (!this.OleDB.Execute(pData39.InsertQuery()))
        return false;
      int p_pm_GroupID17 = p_pm_GroupID16 + 1;
      int num40;
      TProgMenu pData40 = this.InitTableBizSMLv3(pData39, num40 = num39 + 1, "07650000", "포인트소멸", p_pm_GroupID17, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "포인트소멸", "member");
      if (!this.OleDB.Execute(pData40.InsertQuery()))
        return false;
      string str13 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Member.Inq.Extinction.";
      int num41;
      TProgMenu pData41 = this.InitTableBizSMLv4(pData40, num41 = num40 + 1, "07650010", "포인트소멸예정", p_pm_GroupID17, str13 + "MemberInqExtinctionExpectedPageVM", "포인트소멸(포인트소멸예정)", "member_info");
      int num42;
      return this.OleDB.Execute(pData41.InsertQuery()) && this.OleDB.Execute(this.InitTableBizSMLv4(pData41, num42 = num41 + 1, "07650010", "포인트소멸내역", p_pm_GroupID17, str13 + "MemberInqExtinctionStatementPageVM", "포인트소멸(포인트소멸내역)", "member").InsertQuery());
    }

    private bool InitTableBizSMOrder(long pSiteID)
    {
      int num1 = 2000;
      TProgMenu pData1 = this.OleDB.Create<TProgMenu>();
      pData1.pm_MenuCode = 101;
      int pmMenuCode = pData1.pm_MenuCode;
      pData1.pm_SiteID = pSiteID;
      pData1.pm_ProgKind = 5;
      pData1.pm_MenuSortNo = "02000000";
      pData1.pm_MenuName = "전표관리";
      pData1.pm_GroupID = num1;
      pData1.pm_ProgID = "전표관리";
      pData1.pm_ProgTitle = "전표관리";
      pData1.pm_ViewType = 1;
      pData1.pm_MenuDepth = 1;
      pData1.pm_IconUrl = "invoice";
      if (!this.OleDB.Execute(pData1.InsertQuery()))
        return false;
      int p_pm_GroupID1 = num1 + 1;
      int num2;
      TProgMenu pData2 = this.InitTableBizSMLv2(pData1, num2 = pmMenuCode + 1, "02100000", "발주관리", p_pm_GroupID1, "발주관리", "발주관리", "order");
      if (!this.OleDB.Execute(pData2.InsertQuery()))
        return false;
      int p_pm_GroupID2 = p_pm_GroupID1 + 1;
      int num3;
      TProgMenu pData3 = this.InitTableBizSMLv3(pData2, num3 = num2 + 1, "02110000", "발주", p_pm_GroupID2, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "발주 조회/등록", "order_add");
      if (!this.OleDB.Execute(pData3.InsertQuery()))
        return false;
      string str1 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Order.RegOrder.Order.";
      int num4;
      TProgMenu pData4 = this.InitTableBizSMLv4(pData3, num4 = num3 + 1, "02110010", "발주", p_pm_GroupID2, str1 + "OrderPageVM", "발주리스트", "detail");
      if (!this.OleDB.Execute(pData4.InsertQuery()))
        return false;
      int p_pm_GroupID3 = p_pm_GroupID2 + 1;
      int num5;
      TProgMenu pData5 = this.InitTableBizSMLv2(pData4, num5 = num4 + 1, "02200000", "전표관리", p_pm_GroupID3, "전표관리", "전표관리", "invoice");
      if (!this.OleDB.Execute(pData5.InsertQuery()))
        return false;
      int p_pm_GroupID4 = p_pm_GroupID3 + 1;
      int num6;
      TProgMenu pData6 = this.InitTableBizSMLv3(pData5, num6 = num5 + 1, "02210000", "매입/대출입", p_pm_GroupID4, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "전표 조회/등록", "invoice_manage");
      if (!this.OleDB.Execute(pData6.InsertQuery()))
        return false;
      string str2 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Order.RegOrder.Order.";
      int num7;
      TProgMenu pData7 = this.InitTableBizSMLv4(pData6, num7 = num6 + 1, "02210010", "전표", p_pm_GroupID4, str2 + "StatementPageVM", "전표리스트", "detail");
      if (!this.OleDB.Execute(pData7.InsertQuery()))
        return false;
      int p_pm_GroupID5 = p_pm_GroupID4 + 1;
      int num8;
      TProgMenu pData8 = this.InitTableBizSMLv3(pData7, num8 = num7 + 1, "02230000", "매출전표", p_pm_GroupID5, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "매출 전표 조회/등록", "invoice_manage");
      if (!this.OleDB.Execute(pData8.InsertQuery()))
        return false;
      string str3 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Credit.RegStatement.Statement.";
      int num9;
      TProgMenu pData9 = this.InitTableBizSMLv4(pData8, num9 = num8 + 1, "02230010", "전표", p_pm_GroupID5, str3 + "StatementPageVM", "매출전표리스트", "detail");
      if (!this.OleDB.Execute(pData9.InsertQuery()))
        return false;
      int num10;
      TProgMenu pData10 = this.InitTableBizSMLv4(pData9, num10 = num9 + 1, "02230020", "결제관리", p_pm_GroupID5, str3 + "CreditPaymentPageVM", "회원별 결제관리", "detail");
      if (!this.OleDB.Execute(pData10.InsertQuery()))
        return false;
      int num11;
      TProgMenu pData11 = this.InitTableBizSMLv4(pData10, num11 = num10 + 1, "02230030", "일자별", p_pm_GroupID5, str3 + "CreditPaymentDayPageVM", "일자별 결제 내역", "detail");
      if (!this.OleDB.Execute(pData11.InsertQuery()))
        return false;
      int p_pm_GroupID6 = p_pm_GroupID5 + 1;
      int num12;
      TProgMenu pData12 = this.InitTableBizSMLv2(pData11, num12 = num11 + 1, "02300000", "전표조회", p_pm_GroupID6, "전표조회", "전표조회", "invoice_detail");
      if (!this.OleDB.Execute(pData12.InsertQuery()))
        return false;
      int p_pm_GroupID7 = p_pm_GroupID6 + 1;
      int num13;
      TProgMenu pData13 = this.InitTableBizSMLv3(pData12, num13 = num12 + 1, "02310000", "업체별", p_pm_GroupID7, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "업체별 전표 조회", "invoice_company");
      if (!this.OleDB.Execute(pData13.InsertQuery()))
        return false;
      string str4 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Order.Statement.Supplier.";
      int num14;
      TProgMenu pData14 = this.InitTableBizSMLv4(pData13, num14 = num13 + 1, "02310010", "기간", p_pm_GroupID7, str4 + "PeriodPageVM", "기간별", "term");
      if (!this.OleDB.Execute(pData14.InsertQuery()))
        return false;
      int num15;
      TProgMenu pData15 = this.InitTableBizSMLv4(pData14, num15 = num14 + 1, "02310020", "일자", p_pm_GroupID7, str4 + "DayPageVM", "일자별", "day");
      if (!this.OleDB.Execute(pData15.InsertQuery()))
        return false;
      int num16;
      TProgMenu pData16 = this.InitTableBizSMLv4(pData15, num16 = num15 + 1, "02310030", "전표", p_pm_GroupID7, str4 + "StatementPageVM", "전표별", "invoice");
      if (!this.OleDB.Execute(pData16.InsertQuery()))
        return false;
      int num17;
      TProgMenu pData17 = this.InitTableBizSMLv4(pData16, num17 = num16 + 1, "02310040", "전표상세", p_pm_GroupID7, str4 + "StatementDetailPageVM", "전표상세", "invoice_detail");
      if (!this.OleDB.Execute(pData17.InsertQuery()))
        return false;
      int num18;
      TProgMenu pData18 = this.InitTableBizSMLv4(pData17, num18 = num17 + 1, "02310050", "상품", p_pm_GroupID7, str4 + "GoodsPageVM", "상품별", "item");
      if (!this.OleDB.Execute(pData18.InsertQuery()))
        return false;
      int p_pm_GroupID8 = p_pm_GroupID7 + 1;
      int num19;
      TProgMenu pData19 = this.InitTableBizSMLv3(pData18, num19 = num18 + 1, "02320000", "기간별", p_pm_GroupID8, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "기간별 전표 조회", "term_invoice");
      if (!this.OleDB.Execute(pData19.InsertQuery()))
        return false;
      string str5 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Order.Statement.Period.";
      int num20;
      TProgMenu pData20 = this.InitTableBizSMLv4(pData19, num20 = num19 + 1, "02320010", "지점", p_pm_GroupID8, str5 + "StorePageVM", "지점별", "site");
      if (!this.OleDB.Execute(pData20.InsertQuery()))
        return false;
      int num21;
      TProgMenu pData21 = this.InitTableBizSMLv4(pData20, num21 = num20 + 1, "02320020", "팀", p_pm_GroupID8, str5 + "TeamPageVM", "팀별", "team");
      if (!this.OleDB.Execute(pData21.InsertQuery()))
        return false;
      int num22;
      TProgMenu pData22 = this.InitTableBizSMLv4(pData21, num22 = num21 + 1, "02320030", "부서", p_pm_GroupID8, str5 + "PartPageVM", "부서별", "department");
      if (!this.OleDB.Execute(pData22.InsertQuery()))
        return false;
      int num23;
      TProgMenu pData23 = this.InitTableBizSMLv4(pData22, num23 = num22 + 1, "02320040", "대분류", p_pm_GroupID8, str5 + "CategoryTopPageVM", "대분류별", "category_main_category");
      if (!this.OleDB.Execute(pData23.InsertQuery()))
        return false;
      int num24;
      TProgMenu pData24 = this.InitTableBizSMLv4(pData23, num24 = num23 + 1, "02320050", "중분류", p_pm_GroupID8, str5 + "CategoryMiddlePageVM", "중분류별", "category_middle_category");
      if (!this.OleDB.Execute(pData24.InsertQuery()))
        return false;
      int num25;
      TProgMenu pData25 = this.InitTableBizSMLv4(pData24, num25 = num24 + 1, "02320060", "소분류", p_pm_GroupID8, str5 + "CategoryBottomPageVM", "소분류별", "category_subclass");
      if (!this.OleDB.Execute(pData25.InsertQuery()))
        return false;
      int num26;
      TProgMenu pData26 = this.InitTableBizSMLv4(pData25, num26 = num25 + 1, "02320070", "상품", p_pm_GroupID8, str5 + "GoodsPageVM", "상품별", "item");
      if (!this.OleDB.Execute(pData26.InsertQuery()))
        return false;
      int p_pm_GroupID9 = p_pm_GroupID8 + 1;
      int num27;
      TProgMenu pData27 = this.InitTableBizSMLv3(pData26, num27 = num26 + 1, "02330000", "분류별", p_pm_GroupID9, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "분류별 전표 조회", "category_invoice");
      if (!this.OleDB.Execute(pData27.InsertQuery()))
        return false;
      string str6 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Order.Statement.Category.";
      int num28;
      TProgMenu pData28 = this.InitTableBizSMLv4(pData27, num28 = num27 + 1, "02330010", "분류", p_pm_GroupID9, str6 + "CategoryPageVM", "분류별", "category");
      if (!this.OleDB.Execute(pData28.InsertQuery()))
        return false;
      int num29;
      TProgMenu pData29 = this.InitTableBizSMLv4(pData28, num29 = num28 + 1, "02330020", "상품별", p_pm_GroupID9, str6 + "GoodsPageVM", "상품별", "item");
      if (!this.OleDB.Execute(pData29.InsertQuery()))
        return false;
      int p_pm_GroupID10 = p_pm_GroupID9 + 1;
      int num30;
      TProgMenu pData30 = this.InitTableBizSMLv3(pData29, num30 = num29 + 1, "02360000", "재고조정", p_pm_GroupID10, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "재고조정 현황", "stocktaking");
      if (!this.OleDB.Execute(pData30.InsertQuery()))
        return false;
      string str7 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Order.Statement.Adjust.";
      int num31;
      TProgMenu pData31 = this.InitTableBizSMLv4(pData30, num31 = num30 + 1, "02360010", "상품", p_pm_GroupID10, str7 + "GoodsPageVM", "상품리스트", "item");
      if (!this.OleDB.Execute(pData31.InsertQuery()))
        return false;
      int num32;
      TProgMenu pData32 = this.InitTableBizSMLv4(pData31, num32 = num31 + 1, "02360020", "전표상세", p_pm_GroupID10, str7 + "StatementDetailPageVM", "전표상세", "invoice_detail");
      if (!this.OleDB.Execute(pData32.InsertQuery()))
        return false;
      int p_pm_GroupID11 = p_pm_GroupID10 + 1;
      int num33;
      TProgMenu pData33 = this.InitTableBizSMLv3(pData32, num33 = num32 + 1, "02370000", "폐기", p_pm_GroupID11, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "폐기 현황", "stock_buy_disuse");
      if (!this.OleDB.Execute(pData33.InsertQuery()))
        return false;
      string str8 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Order.Statement.Disuse.";
      int num34;
      TProgMenu pData34 = this.InitTableBizSMLv4(pData33, num34 = num33 + 1, "02370010", "상품", p_pm_GroupID11, str8 + "GoodsPageVM", "상품리스트", "item");
      if (!this.OleDB.Execute(pData34.InsertQuery()))
        return false;
      int num35;
      TProgMenu pData35 = this.InitTableBizSMLv4(pData34, num35 = num34 + 1, "02370020", "전표상세", p_pm_GroupID11, str8 + "StatementDetailPageVM", "전표상세", "invoice_detail");
      if (!this.OleDB.Execute(pData35.InsertQuery()))
        return false;
      int p_pm_GroupID12 = p_pm_GroupID11 + 1;
      int num36;
      TProgMenu pData36 = this.InitTableBizSMLv2(pData35, num36 = num35 + 1, "02500000", "일별 조회", p_pm_GroupID12, "일별 조회", "일별 조회", "day");
      if (!this.OleDB.Execute(pData36.InsertQuery()))
        return false;
      int p_pm_GroupID13 = p_pm_GroupID12 + 1;
      int num37;
      TProgMenu pData37 = this.InitTableBizSMLv3(pData36, num37 = num36 + 1, "02510000", "일별(가로)", p_pm_GroupID13, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "일별 전표 조회 (가로형)", "day_horizontal");
      if (!this.OleDB.Execute(pData37.InsertQuery()))
        return false;
      string str9 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Order.Day.Horizontal.";
      int num38;
      TProgMenu pData38 = this.InitTableBizSMLv4(pData37, num38 = num37 + 1, "02510010", "지점", p_pm_GroupID13, str9 + "StorePageVM", "지점별", "site");
      if (!this.OleDB.Execute(pData38.InsertQuery()))
        return false;
      int num39;
      TProgMenu pData39 = this.InitTableBizSMLv4(pData38, num39 = num38 + 1, "02510020", "팀", p_pm_GroupID13, str9 + "TeamPageVM", "팀별", "team");
      if (!this.OleDB.Execute(pData39.InsertQuery()))
        return false;
      int num40;
      TProgMenu pData40 = this.InitTableBizSMLv4(pData39, num40 = num39 + 1, "02510030", "부서", p_pm_GroupID13, str9 + "PartPageVM", "부서별", "department");
      if (!this.OleDB.Execute(pData40.InsertQuery()))
        return false;
      int num41;
      TProgMenu pData41 = this.InitTableBizSMLv4(pData40, num41 = num40 + 1, "02510040", "대분류", p_pm_GroupID13, str9 + "CategoryTopPageVM", "대분류별", "category_main_category");
      if (!this.OleDB.Execute(pData41.InsertQuery()))
        return false;
      int num42;
      TProgMenu pData42 = this.InitTableBizSMLv4(pData41, num42 = num41 + 1, "02510050", "중분류", p_pm_GroupID13, str9 + "CategoryMiddlePageVM", "중분류별", "category_middle_category");
      if (!this.OleDB.Execute(pData42.InsertQuery()))
        return false;
      int num43;
      TProgMenu pData43 = this.InitTableBizSMLv4(pData42, num43 = num42 + 1, "02510060", "소분류", p_pm_GroupID13, str9 + "CategoryBottomPageVM", "소분류별", "category_subclass");
      if (!this.OleDB.Execute(pData43.InsertQuery()))
        return false;
      int num44;
      TProgMenu pData44 = this.InitTableBizSMLv4(pData43, num44 = num43 + 1, "02510070", "상품", p_pm_GroupID13, str9 + "GoodsPageVM", "상품별", "item");
      if (!this.OleDB.Execute(pData44.InsertQuery()))
        return false;
      int p_pm_GroupID14 = p_pm_GroupID13 + 1;
      int num45;
      TProgMenu pData45 = this.InitTableBizSMLv3(pData44, num45 = num44 + 1, "02520000", "업체(일별)", p_pm_GroupID14, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "업체 일자별 전표 조회", "invoice_company_day");
      if (!this.OleDB.Execute(pData45.InsertQuery()))
        return false;
      string str10 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Order.Day.Supplier.";
      int num46;
      TProgMenu pData46 = this.InitTableBizSMLv4(pData45, num46 = num45 + 1, "02520010", "업체", p_pm_GroupID14, str10 + "SupplierPageVM", "업체별", "company");
      if (!this.OleDB.Execute(pData46.InsertQuery()))
        return false;
      int num47;
      TProgMenu pData47 = this.InitTableBizSMLv4(pData46, num47 = num46 + 1, "02520020", "분류", p_pm_GroupID14, str10 + "CategoryPageVM", "업체-분류별", "company_category");
      if (!this.OleDB.Execute(pData47.InsertQuery()))
        return false;
      int num48;
      TProgMenu pData48 = this.InitTableBizSMLv4(pData47, num48 = num47 + 1, "02520030", "상품", p_pm_GroupID14, str10 + "GoodsPageVM", "업체-분류-상품별", "company_category_item");
      if (!this.OleDB.Execute(pData48.InsertQuery()))
        return false;
      int p_pm_GroupID15 = p_pm_GroupID14 + 1;
      int num49;
      TProgMenu pData49 = this.InitTableBizSMLv3(pData48, num49 = num48 + 1, "02530000", "일별(세로)", p_pm_GroupID15, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "일별 전표 조회 (세로형)", "day_vertical");
      if (!this.OleDB.Execute(pData49.InsertQuery()))
        return false;
      string str11 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Order.Day.Vertical.";
      int num50;
      TProgMenu pData50 = this.InitTableBizSMLv4(pData49, num50 = num49 + 1, "02530010", "지점", p_pm_GroupID15, str11 + "StorePageVM", "지점별", "site");
      if (!this.OleDB.Execute(pData50.InsertQuery()))
        return false;
      int num51;
      TProgMenu pData51 = this.InitTableBizSMLv4(pData50, num51 = num50 + 1, "02530020", "팀", p_pm_GroupID15, str11 + "TeamPageVM", "팀별", "team");
      if (!this.OleDB.Execute(pData51.InsertQuery()))
        return false;
      int num52;
      TProgMenu pData52 = this.InitTableBizSMLv4(pData51, num52 = num51 + 1, "02530030", "부서", p_pm_GroupID15, str11 + "PartPageVM", "부서별", "department");
      if (!this.OleDB.Execute(pData52.InsertQuery()))
        return false;
      int num53;
      TProgMenu pData53 = this.InitTableBizSMLv4(pData52, num53 = num52 + 1, "02530040", "대분류", p_pm_GroupID15, str11 + "CategoryTopPageVM", "대분류별", "category_main_category");
      if (!this.OleDB.Execute(pData53.InsertQuery()))
        return false;
      int num54;
      TProgMenu pData54 = this.InitTableBizSMLv4(pData53, num54 = num53 + 1, "02530050", "중분류", p_pm_GroupID15, str11 + "CategoryMiddlePageVM", "중분류별", "category_middle_category");
      if (!this.OleDB.Execute(pData54.InsertQuery()))
        return false;
      int num55;
      TProgMenu pData55 = this.InitTableBizSMLv4(pData54, num55 = num54 + 1, "02530060", "소분류", p_pm_GroupID15, str11 + "CategoryBottomPageVM", "소분류별", "category_subclass");
      if (!this.OleDB.Execute(pData55.InsertQuery()))
        return false;
      int num56;
      TProgMenu pData56 = this.InitTableBizSMLv4(pData55, num56 = num55 + 1, "02530070", "상품", p_pm_GroupID15, str11 + "GoodsPageVM", "상품별", "item");
      if (!this.OleDB.Execute(pData56.InsertQuery()))
        return false;
      int p_pm_GroupID16 = p_pm_GroupID15 + 1;
      int num57;
      TProgMenu pData57 = this.InitTableBizSMLv2(pData56, num57 = num56 + 1, "02700000", "월별조회", p_pm_GroupID16, "월별조회", "월별조회", "day");
      if (!this.OleDB.Execute(pData57.InsertQuery()))
        return false;
      int p_pm_GroupID17 = p_pm_GroupID16 + 1;
      int num58;
      TProgMenu pData58 = this.InitTableBizSMLv3(pData57, num58 = num57 + 1, "02710000", "월별(가로형)", p_pm_GroupID17, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "월별 전표 조회 (가로형)", "day_horizontal");
      if (!this.OleDB.Execute(pData58.InsertQuery()))
        return false;
      string str12 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Order.Month.Horizontal.";
      int num59;
      TProgMenu pData59 = this.InitTableBizSMLv4(pData58, num59 = num58 + 1, "02710010", "지점", p_pm_GroupID17, str12 + "StorePageVM", "지점별", "site");
      if (!this.OleDB.Execute(pData59.InsertQuery()))
        return false;
      int num60;
      TProgMenu pData60 = this.InitTableBizSMLv4(pData59, num60 = num59 + 1, "02710020", "팀", p_pm_GroupID17, str12 + "TeamPageVM", "팀별", "team");
      if (!this.OleDB.Execute(pData60.InsertQuery()))
        return false;
      int num61;
      TProgMenu pData61 = this.InitTableBizSMLv4(pData60, num61 = num60 + 1, "02710030", "부서", p_pm_GroupID17, str12 + "PartPageVM", "부서별", "department");
      if (!this.OleDB.Execute(pData61.InsertQuery()))
        return false;
      int num62;
      TProgMenu pData62 = this.InitTableBizSMLv4(pData61, num62 = num61 + 1, "02710040", "대분류", p_pm_GroupID17, str12 + "CategoryTopPageVM", "대분류별", "category_main_category");
      if (!this.OleDB.Execute(pData62.InsertQuery()))
        return false;
      int num63;
      TProgMenu pData63 = this.InitTableBizSMLv4(pData62, num63 = num62 + 1, "02710050", "중분류", p_pm_GroupID17, str12 + "CategoryMiddlePageVM", "중분류별", "category_middle_category");
      if (!this.OleDB.Execute(pData63.InsertQuery()))
        return false;
      int num64;
      TProgMenu pData64 = this.InitTableBizSMLv4(pData63, num64 = num63 + 1, "02710060", "소분류", p_pm_GroupID17, str12 + "CategoryBottomPageVM", "소분류별", "category_subclass");
      if (!this.OleDB.Execute(pData64.InsertQuery()))
        return false;
      int num65;
      TProgMenu pData65 = this.InitTableBizSMLv4(pData64, num65 = num64 + 1, "02710070", "상품", p_pm_GroupID17, str12 + "GoodsPageVM", "상품별", "item");
      if (!this.OleDB.Execute(pData65.InsertQuery()))
        return false;
      int p_pm_GroupID18 = p_pm_GroupID17 + 1;
      int num66;
      TProgMenu pData66 = this.InitTableBizSMLv3(pData65, num66 = num65 + 1, "02730000", "업체(월별)", p_pm_GroupID18, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "업체 월별 전표 조회(가로형)", "invoice_company_month");
      if (!this.OleDB.Execute(pData66.InsertQuery()))
        return false;
      string str13 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Order.Month.Supplier.";
      int num67;
      TProgMenu pData67 = this.InitTableBizSMLv4(pData66, num67 = num66 + 1, "02730010", "업체", p_pm_GroupID18, str13 + "SupplierPageVM", "업체별", "company");
      if (!this.OleDB.Execute(pData67.InsertQuery()))
        return false;
      int num68;
      TProgMenu pData68 = this.InitTableBizSMLv4(pData67, num68 = num67 + 1, "02730020", "분류", p_pm_GroupID18, str13 + "CategoryPageVM", "업체-분류별", "company_category");
      if (!this.OleDB.Execute(pData68.InsertQuery()))
        return false;
      int num69;
      TProgMenu pData69 = this.InitTableBizSMLv4(pData68, num69 = num68 + 1, "02730030", "상품", p_pm_GroupID18, str13 + "GoodsPageVM", "업체-분류-상품별", "company_category");
      if (!this.OleDB.Execute(pData69.InsertQuery()))
        return false;
      int p_pm_GroupID19 = p_pm_GroupID18 + 1;
      int num70;
      TProgMenu pData70 = this.InitTableBizSMLv3(pData69, num70 = num69 + 1, "02750000", "월별(세로형)", p_pm_GroupID19, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "월별 전표 조회(세로형)", "month_vertical");
      if (!this.OleDB.Execute(pData70.InsertQuery()))
        return false;
      string str14 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Order.Month.Vertical.";
      int num71;
      TProgMenu pData71 = this.InitTableBizSMLv4(pData70, num71 = num70 + 1, "02750010", "지점", p_pm_GroupID19, str14 + "StorePageVM", "지점별", "site");
      if (!this.OleDB.Execute(pData71.InsertQuery()))
        return false;
      int num72;
      TProgMenu pData72 = this.InitTableBizSMLv4(pData71, num72 = num71 + 1, "02750020", "팀", p_pm_GroupID19, str14 + "TeamPageVM", "팀별", "team");
      if (!this.OleDB.Execute(pData72.InsertQuery()))
        return false;
      int num73;
      TProgMenu pData73 = this.InitTableBizSMLv4(pData72, num73 = num72 + 1, "02750030", "부서", p_pm_GroupID19, str14 + "PartPageVM", "부서별", "department");
      if (!this.OleDB.Execute(pData73.InsertQuery()))
        return false;
      int num74;
      TProgMenu pData74 = this.InitTableBizSMLv4(pData73, num74 = num73 + 1, "02750040", "대분류", p_pm_GroupID19, str14 + "CategoryTopPageVM", "대분류별", "category_main_category");
      if (!this.OleDB.Execute(pData74.InsertQuery()))
        return false;
      int num75;
      TProgMenu pData75 = this.InitTableBizSMLv4(pData74, num75 = num74 + 1, "02750050", "중분류", p_pm_GroupID19, str14 + "CategoryMiddlePageVM", "중분류별", "category_middle_category");
      if (!this.OleDB.Execute(pData75.InsertQuery()))
        return false;
      int num76;
      TProgMenu pData76 = this.InitTableBizSMLv4(pData75, num76 = num75 + 1, "02750060", "소분류", p_pm_GroupID19, str14 + "CategoryBottomPageVM", "소분류별", "category_subclass");
      int num77;
      return this.OleDB.Execute(pData76.InsertQuery()) && this.OleDB.Execute(this.InitTableBizSMLv4(pData76, num77 = num76 + 1, "02750070", "상품", p_pm_GroupID19, str14 + "GoodsPageVM", "상품별", "item").InsertQuery());
    }

    private bool InitTableBizSMPayment(long pSiteID)
    {
      int num1 = 6000;
      TProgMenu pData1 = this.OleDB.Create<TProgMenu>();
      pData1.pm_MenuCode = 501;
      int pmMenuCode = pData1.pm_MenuCode;
      pData1.pm_SiteID = pSiteID;
      pData1.pm_ProgKind = 5;
      pData1.pm_MenuSortNo = "06000000";
      pData1.pm_MenuName = "대금관리";
      pData1.pm_GroupID = num1;
      pData1.pm_ProgID = "대금관리";
      pData1.pm_ProgTitle = "대금관리";
      pData1.pm_ViewType = 1;
      pData1.pm_MenuDepth = 1;
      pData1.pm_IconUrl = "price_manage";
      if (!this.OleDB.Execute(pData1.InsertQuery()))
        return false;
      int p_pm_GroupID1 = num1 + 1;
      int num2;
      TProgMenu pData2 = this.InitTableBizSMLv2(pData1, num2 = pmMenuCode + 1, "06100000", "결제", p_pm_GroupID1, "결제", "결제", "payment_condition");
      if (!this.OleDB.Execute(pData2.InsertQuery()))
        return false;
      int p_pm_GroupID2 = p_pm_GroupID1 + 1;
      int num3;
      TProgMenu pData3 = this.InitTableBizSMLv3(pData2, num3 = num2 + 1, "06110000", "결제지급", p_pm_GroupID2, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "결제 지급 관리 현황", "pos");
      if (!this.OleDB.Execute(pData3.InsertQuery()))
        return false;
      string str1 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Payment.RegPayment.";
      int num4;
      TProgMenu pData4 = this.InitTableBizSMLv4(pData3, num4 = num3 + 1, "06110010", "체크리스트", p_pm_GroupID2, str1 + "PaymentCheckPageVM", "업체 체크 리스트(마감)", "pos");
      if (!this.OleDB.Execute(pData4.InsertQuery()))
        return false;
      int num5;
      TProgMenu pData5 = this.InitTableBizSMLv4(pData4, num5 = num4 + 1, "06110020", "결제관리", p_pm_GroupID2, str1 + "PaymentPageVM", "업체별 결제관리", "pos");
      if (!this.OleDB.Execute(pData5.InsertQuery()))
        return false;
      int num6;
      TProgMenu pData6 = this.InitTableBizSMLv4(pData5, num6 = num5 + 1, "06110030", "결제정보", p_pm_GroupID2, str1 + "PaymentInfoPageVM", "업체별 결제정보", "pos");
      if (!this.OleDB.Execute(pData6.InsertQuery()))
        return false;
      int num7;
      TProgMenu pData7 = this.InitTableBizSMLv4(pData6, num7 = num6 + 1, "06110040", "일자별", p_pm_GroupID2, str1 + "PaymentDayPageVM", "일자별 결제 내역", "pos");
      if (!this.OleDB.Execute(pData7.InsertQuery()))
        return false;
      int p_pm_GroupID3 = p_pm_GroupID2 + 1;
      int num8;
      TProgMenu pData8 = this.InitTableBizSMLv2(pData7, num8 = num7 + 1, "06500000", "결제조건", p_pm_GroupID3, "결제조건", "결제조건", "payment_condition");
      if (!this.OleDB.Execute(pData8.InsertQuery()))
        return false;
      int p_pm_GroupID4 = p_pm_GroupID3 + 1;
      int num9;
      TProgMenu pData9 = this.InitTableBizSMLv3(pData8, num9 = num8 + 1, "06510000", "결제조건", p_pm_GroupID4, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "결제 조건 관리 현황", "payment_condition");
      if (!this.OleDB.Execute(pData9.InsertQuery()))
        return false;
      string str2 = "niBizSM.Client.Core.ViewModels.Page.UniSales.Payment.PayContion.";
      int num10;
      return this.OleDB.Execute(this.InitTableBizSMLv4(pData9, num10 = num9 + 1, "06510010", "결제조건", p_pm_GroupID4, str2 + "UPayContionPageVM", "결제 조건 리스트", "payment_condition").InsertQuery());
    }

    private bool InitTableBizSMPos(long pSiteID)
    {
      int num1 = 5000;
      TProgMenu pData1 = this.OleDB.Create<TProgMenu>();
      pData1.pm_MenuCode = 401;
      int pmMenuCode = pData1.pm_MenuCode;
      pData1.pm_SiteID = pSiteID;
      pData1.pm_ProgKind = 5;
      pData1.pm_MenuSortNo = "05000000";
      pData1.pm_MenuName = "POS관리";
      pData1.pm_GroupID = num1;
      pData1.pm_ProgID = "POS관리";
      pData1.pm_ProgTitle = "POS관리";
      pData1.pm_ViewType = 1;
      pData1.pm_MenuDepth = 1;
      pData1.pm_IconUrl = "pos";
      if (!this.OleDB.Execute(pData1.InsertQuery()))
        return false;
      int p_pm_GroupID1 = num1 + 1;
      int num2;
      TProgMenu pData2 = this.InitTableBizSMLv2(pData1, num2 = pmMenuCode + 1, "05100000", "기초정보", p_pm_GroupID1, "기초정보", "기초정보", "info");
      if (!this.OleDB.Execute(pData2.InsertQuery()))
        return false;
      int p_pm_GroupID2 = p_pm_GroupID1 + 1;
      int num3;
      TProgMenu pData3 = this.InitTableBizSMLv3(pData2, num3 = num2 + 1, "05110000", "POS", p_pm_GroupID2, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "POS 등록 현황", "pos");
      if (!this.OleDB.Execute(pData3.InsertQuery()))
        return false;
      string str1 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Pos.BaseInfo.RegPos.";
      int num4;
      TProgMenu pData4 = this.InitTableBizSMLv4(pData3, num4 = num3 + 1, "05110010", "POS", p_pm_GroupID2, str1 + "RegPosPageVM", "POS 리스트", "pos");
      if (!this.OleDB.Execute(pData4.InsertQuery()))
        return false;
      int p_pm_GroupID3 = p_pm_GroupID2 + 1;
      int num5;
      TProgMenu pData5 = this.InitTableBizSMLv3(pData4, num5 = num4 + 1, "05130000", "영수증폼등록", p_pm_GroupID3, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "영수증 폼 등록", "receipt");
      if (!this.OleDB.Execute(pData5.InsertQuery()))
        return false;
      string str2 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Pos.BaseInfo.RegForm.";
      int num6;
      TProgMenu pData6 = this.InitTableBizSMLv4(pData5, num6 = num5 + 1, "05130010", "영수증폼", p_pm_GroupID3, str2 + "RegFormPageVM", "영수증폼 리스트", "detail");
      if (!this.OleDB.Execute(pData6.InsertQuery()))
        return false;
      int p_pm_GroupID4 = p_pm_GroupID3 + 1;
      int num7;
      TProgMenu pData7 = this.InitTableBizSMLv3(pData6, num7 = num6 + 1, "05150000", "지정키", p_pm_GroupID4, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "지정키 등록", "pos_key");
      if (!this.OleDB.Execute(pData7.InsertQuery()))
        return false;
      string str3 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Pos.BaseInfo.RegShortCut.";
      int num8;
      TProgMenu pData8 = this.InitTableBizSMLv4(pData7, num8 = num7 + 1, "05150010", "지정키", p_pm_GroupID4, str3 + "RegShortCutPageVM", "지정키 리스트", "detail");
      if (!this.OleDB.Execute(pData8.InsertQuery()))
        return false;
      int p_pm_GroupID5 = p_pm_GroupID4 + 1;
      int num9;
      TProgMenu pData9 = this.InitTableBizSMLv3(pData8, num9 = num8 + 1, "05170000", "밴사관리", p_pm_GroupID5, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "밴사관리", "van");
      if (!this.OleDB.Execute(pData9.InsertQuery()))
        return false;
      string str4 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Pos.BaseInfo.RegVan.";
      int num10;
      TProgMenu pData10 = this.InitTableBizSMLv4(pData9, num10 = num9 + 1, "05170010", "밴사", p_pm_GroupID5, str4 + "RegVanPageVM", "밴사 리스트", "detail");
      if (!this.OleDB.Execute(pData10.InsertQuery()))
        return false;
      int num11;
      TProgMenu pData11 = this.InitTableBizSMLv4(pData10, num11 = num10 + 1, "05170020", "카드사", p_pm_GroupID5, str4 + "RegCardCompPageVM", "카드사 리스트", "detail");
      if (!this.OleDB.Execute(pData11.InsertQuery()))
        return false;
      int num12;
      TProgMenu pData12 = this.InitTableBizSMLv4(pData11, num12 = num11 + 1, "05170030", "카드사연결", p_pm_GroupID5, str4 + "RegLinkPageVM", "카드사연결 리스트", "detail");
      if (!this.OleDB.Execute(pData12.InsertQuery()))
        return false;
      int p_pm_GroupID6 = p_pm_GroupID5 + 1;
      int num13;
      TProgMenu pData13 = this.InitTableBizSMLv2(pData12, num13 = num12 + 1, "05300000", "매출시제", p_pm_GroupID6, "매출시제", "매출시제", "sales_tense");
      if (!this.OleDB.Execute(pData13.InsertQuery()))
        return false;
      int p_pm_GroupID7 = p_pm_GroupID6 + 1;
      int num14;
      TProgMenu pData14 = this.InitTableBizSMLv3(pData13, num14 = num13 + 1, "05310000", "POS정산", p_pm_GroupID7, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "POS정산", "pos_calculate");
      if (!this.OleDB.Execute(pData14.InsertQuery()))
        return false;
      string str5 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Pos.Sales.RegPosClose.";
      int num15;
      TProgMenu pData15 = this.InitTableBizSMLv4(pData14, num15 = num14 + 1, "05310010", "정산", p_pm_GroupID7, str5 + "RegPosClosePageVM", "정산 리스트", "detail");
      if (!this.OleDB.Execute(pData15.InsertQuery()))
        return false;
      int p_pm_GroupID8 = p_pm_GroupID7 + 1;
      int num16;
      TProgMenu pData16 = this.InitTableBizSMLv3(pData15, num16 = num15 + 1, "05330000", "사무실정산", p_pm_GroupID8, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "사무실정산", "office_calculate");
      if (!this.OleDB.Execute(pData16.InsertQuery()))
        return false;
      string str6 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Pos.Sales.RegOfficeClose.";
      int num17;
      TProgMenu pData17 = this.InitTableBizSMLv4(pData16, num17 = num16 + 1, "05330010", "정산내역", p_pm_GroupID8, str6 + "RegOfficeClosePageVM", "정산내역 리스트", "calculate_history");
      if (!this.OleDB.Execute(pData17.InsertQuery()))
        return false;
      int p_pm_GroupID9 = p_pm_GroupID8 + 1;
      int num18;
      TProgMenu pData18 = this.InitTableBizSMLv3(pData17, num18 = num17 + 1, "05350000", "TR조회", p_pm_GroupID9, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "TR조회", "tr");
      if (!this.OleDB.Execute(pData18.InsertQuery()))
        return false;
      string str7 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Pos.Sales.InqTr.";
      int num19;
      TProgMenu pData19 = this.InitTableBizSMLv4(pData18, num19 = num18 + 1, "05350010", "TR조회", p_pm_GroupID9, str7 + "InqTrPageVM", "TR 리스트", "tr");
      if (!this.OleDB.Execute(pData19.InsertQuery()))
        return false;
      int p_pm_GroupID10 = p_pm_GroupID9 + 1;
      int num20;
      TProgMenu pData20 = this.InitTableBizSMLv2(pData19, num20 = num19 + 1, "05500000", "승인내역", p_pm_GroupID10, "승인내역", "승인내역", "acknowledgment_history");
      if (!this.OleDB.Execute(pData20.InsertQuery()))
        return false;
      int p_pm_GroupID11 = p_pm_GroupID10 + 1;
      int num21;
      TProgMenu pData21 = this.InitTableBizSMLv3(pData20, num21 = num20 + 1, "05510000", "카드사별", p_pm_GroupID11, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "카드사별 매출조회", "card_sales");
      if (!this.OleDB.Execute(pData21.InsertQuery()))
        return false;
      string str8 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Pos.Approve.InqCard.";
      int num22;
      TProgMenu pData22 = this.InitTableBizSMLv4(pData21, num22 = num21 + 1, "05510010", "카드사", p_pm_GroupID11, str8 + "InqCardPageVM", "카드사별 매출 리스트", "card_sales");
      if (!this.OleDB.Execute(pData22.InsertQuery()))
        return false;
      int p_pm_GroupID12 = p_pm_GroupID11 + 1;
      int num23;
      TProgMenu pData23 = this.InitTableBizSMLv3(pData22, num23 = num22 + 1, "05530000", "일별카드사", p_pm_GroupID12, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "일별 카드사 매출조회", "card_day");
      if (!this.OleDB.Execute(pData23.InsertQuery()))
        return false;
      string str9 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Pos.Approve.InqByDay.";
      int num24;
      TProgMenu pData24 = this.InitTableBizSMLv4(pData23, num24 = num23 + 1, "05530010", "일별", p_pm_GroupID12, str9 + "InqByDayPageVM", "일별 카드사 매출 리스트", "card_sales");
      if (!this.OleDB.Execute(pData24.InsertQuery()))
        return false;
      int p_pm_GroupID13 = p_pm_GroupID12 + 1;
      int num25;
      TProgMenu pData25 = this.InitTableBizSMLv3(pData24, num25 = num24 + 1, "05550000", "현금영수증", p_pm_GroupID13, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "현금영수증 내역 조회", "card_day");
      if (!this.OleDB.Execute(pData25.InsertQuery()))
        return false;
      string str10 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Pos.Approve.InqCash.";
      int num26;
      return this.OleDB.Execute(this.InitTableBizSMLv4(pData25, num26 = num25 + 1, "05550010", "현금영수증", p_pm_GroupID13, str10 + "InqCashPageVM", "현금영수증 내역 리스트", "card_sales").InsertQuery());
    }

    private bool InitTableBizSMProfit(long pSiteID)
    {
      int num1 = 4000;
      TProgMenu pData1 = this.OleDB.Create<TProgMenu>();
      pData1.pm_MenuCode = 301;
      int pmMenuCode = pData1.pm_MenuCode;
      pData1.pm_SiteID = pSiteID;
      pData1.pm_ProgKind = 5;
      pData1.pm_MenuSortNo = "04000000";
      pData1.pm_MenuName = "수불관리";
      pData1.pm_GroupID = num1;
      pData1.pm_ProgID = "수불관리";
      pData1.pm_ProgTitle = "수불관리";
      pData1.pm_ViewType = 1;
      pData1.pm_MenuDepth = 1;
      pData1.pm_IconUrl = "account_book";
      if (!this.OleDB.Execute(pData1.InsertQuery()))
        return false;
      int p_pm_GroupID1 = num1 + 1;
      int num2;
      TProgMenu pData2 = this.InitTableBizSMLv2(pData1, num2 = pmMenuCode + 1, "04100000", "결산", p_pm_GroupID1, "결산", "결산", "account_book_closed");
      if (!this.OleDB.Execute(pData2.InsertQuery()))
        return false;
      int p_pm_GroupID2 = p_pm_GroupID1 + 1;
      int num3;
      TProgMenu pData3 = this.InitTableBizSMLv3(pData2, num3 = num2 + 1, "04110000", "손익(장부)결산", p_pm_GroupID2, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "손익(장부)결산", "account_book_closed");
      if (!this.OleDB.Execute(pData3.InsertQuery()))
        return false;
      string str1 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Stock.Summary.Profit.";
      int num4;
      TProgMenu pData4 = this.InitTableBizSMLv4(pData3, num4 = num3 + 1, "04110010", "장부결산", p_pm_GroupID2, str1 + "ProfitPageVM", "장부결산", "account_book_closed");
      if (!this.OleDB.Execute(pData4.InsertQuery()))
        return false;
      int p_pm_GroupID3 = p_pm_GroupID2 + 1;
      int num5;
      TProgMenu pData5 = this.InitTableBizSMLv3(pData4, num5 = num4 + 1, "04130000", "재고결산", p_pm_GroupID3, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "재고결산", "stock_closed");
      if (!this.OleDB.Execute(pData5.InsertQuery()))
        return false;
      string str2 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Stock.Summary.Stock.";
      int num6;
      TProgMenu pData6 = this.InitTableBizSMLv4(pData5, num6 = num5 + 1, "04130010", "재고결산", p_pm_GroupID3, str2 + "StockPageVM", "재고결산", "stock_closed");
      if (!this.OleDB.Execute(pData6.InsertQuery()))
        return false;
      int p_pm_GroupID4 = p_pm_GroupID3 + 1;
      int num7;
      TProgMenu pData7 = this.InitTableBizSMLv2(pData6, num7 = num6 + 1, "04300000", "재고등록/조회", p_pm_GroupID4, "재고등록/조회", "재고등록/조회", "stocktaking");
      if (!this.OleDB.Execute(pData7.InsertQuery()))
        return false;
      int p_pm_GroupID5 = p_pm_GroupID4 + 1;
      int num8;
      TProgMenu pData8 = this.InitTableBizSMLv3(pData7, num8 = num7 + 1, "04310000", "재고조사", p_pm_GroupID5, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "재고조사 등록/조회", "stocktaking_item");
      if (!this.OleDB.Execute(pData8.InsertQuery()))
        return false;
      string str3 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Stock.Inventory.Reg.";
      int num9;
      TProgMenu pData9 = this.InitTableBizSMLv4(pData8, num9 = num8 + 1, "04310010", "재고결산", p_pm_GroupID5, str3 + "InventoryRegPageVM", "재고조사 등록", "stocktaking_history");
      if (!this.OleDB.Execute(pData9.InsertQuery()))
        return false;
      int num10;
      TProgMenu pData10 = this.InitTableBizSMLv4(pData9, num10 = num9 + 1, "04310020", "전표-상품별", p_pm_GroupID5, str3 + "StatementGoodsPageVM", "전표-상품별 리스트", "invoice_item");
      if (!this.OleDB.Execute(pData10.InsertQuery()))
        return false;
      int num11;
      TProgMenu pData11 = this.InitTableBizSMLv4(pData10, num11 = num10 + 1, "04310030", "상품별", p_pm_GroupID5, str3 + "StatementGoodsPageVM", "상품별 리스트", "invoice_item");
      if (!this.OleDB.Execute(pData11.InsertQuery()))
        return false;
      int p_pm_GroupID6 = p_pm_GroupID5 + 1;
      int num12;
      TProgMenu pData12 = this.InitTableBizSMLv3(pData11, num12 = num11 + 1, "04330000", "재고집계표(매가환원)", p_pm_GroupID6, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "재고집계표(매가환원) 조회", "adjust_total_price_reduction");
      if (!this.OleDB.Execute(pData12.InsertQuery()))
        return false;
      string str4 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Stock.Inventory.Inq.";
      int num13;
      TProgMenu pData13 = this.InitTableBizSMLv4(pData12, num13 = num12 + 1, "04330010", "지점", p_pm_GroupID6, str4 + "StorePageVM", "지점별", "site");
      if (!this.OleDB.Execute(pData13.InsertQuery()))
        return false;
      int num14;
      TProgMenu pData14 = this.InitTableBizSMLv4(pData13, num14 = num13 + 1, "04330020", "팀", p_pm_GroupID6, str4 + "TeamPageVM", "팀별", "team");
      if (!this.OleDB.Execute(pData14.InsertQuery()))
        return false;
      int num15;
      TProgMenu pData15 = this.InitTableBizSMLv4(pData14, num15 = num14 + 1, "04330030", "부서", p_pm_GroupID6, str4 + "PartPageVM", "부서별", "department");
      if (!this.OleDB.Execute(pData15.InsertQuery()))
        return false;
      int num16;
      TProgMenu pData16 = this.InitTableBizSMLv4(pData15, num16 = num15 + 1, "04330040", "대분류", p_pm_GroupID6, str4 + "CategoryTopPageVM", "대분류별", "category_main_category");
      if (!this.OleDB.Execute(pData16.InsertQuery()))
        return false;
      int num17;
      TProgMenu pData17 = this.InitTableBizSMLv4(pData16, num17 = num16 + 1, "04330050", "중분류", p_pm_GroupID6, str4 + "CategoryMiddlePageVM", "중분류별", "category_middle_category");
      if (!this.OleDB.Execute(pData17.InsertQuery()))
        return false;
      int num18;
      TProgMenu pData18 = this.InitTableBizSMLv4(pData17, num18 = num17 + 1, "04330060", "소분류", p_pm_GroupID6, str4 + "CategoryBottomPageVM", "소분류별", "category_subclass");
      if (!this.OleDB.Execute(pData18.InsertQuery()))
        return false;
      int num19;
      TProgMenu pData19 = this.InitTableBizSMLv4(pData18, num19 = num18 + 1, "04330070", "상품", p_pm_GroupID6, str4 + "GoodsPageVM", "상품별", "item");
      if (!this.OleDB.Execute(pData19.InsertQuery()))
        return false;
      int p_pm_GroupID7 = p_pm_GroupID6 + 1;
      int num20;
      TProgMenu pData20 = this.InitTableBizSMLv3(pData19, num20 = num19 + 1, "04350000", "재고집계표(총평균)", p_pm_GroupID7, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "재고집계표(총평균) 조회", "adjust_total_price_reduction");
      if (!this.OleDB.Execute(pData20.InsertQuery()))
        return false;
      string str5 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Stock.Inventory.InqAvg.";
      int num21;
      TProgMenu pData21 = this.InitTableBizSMLv4(pData20, num21 = num20 + 1, "04350010", "지점", p_pm_GroupID7, str5 + "StorePageVM", "지점별", "site");
      if (!this.OleDB.Execute(pData21.InsertQuery()))
        return false;
      int num22;
      TProgMenu pData22 = this.InitTableBizSMLv4(pData21, num22 = num21 + 1, "04350020", "팀", p_pm_GroupID7, str5 + "TeamPageVM", "팀별", "team");
      if (!this.OleDB.Execute(pData22.InsertQuery()))
        return false;
      int num23;
      TProgMenu pData23 = this.InitTableBizSMLv4(pData22, num23 = num22 + 1, "04350030", "부서", p_pm_GroupID7, str5 + "PartPageVM", "부서별", "department");
      if (!this.OleDB.Execute(pData23.InsertQuery()))
        return false;
      int num24;
      TProgMenu pData24 = this.InitTableBizSMLv4(pData23, num24 = num23 + 1, "04350040", "대분류", p_pm_GroupID7, str5 + "CategoryTopPageVM", "대분류별", "category_main_category");
      if (!this.OleDB.Execute(pData24.InsertQuery()))
        return false;
      int num25;
      TProgMenu pData25 = this.InitTableBizSMLv4(pData24, num25 = num24 + 1, "04350050", "중분류", p_pm_GroupID7, str5 + "CategoryMiddlePageVM", "중분류별", "category_middle_category");
      if (!this.OleDB.Execute(pData25.InsertQuery()))
        return false;
      int num26;
      TProgMenu pData26 = this.InitTableBizSMLv4(pData25, num26 = num25 + 1, "04350060", "소분류", p_pm_GroupID7, str5 + "CategoryBottomPageVM", "소분류별", "category_subclass");
      if (!this.OleDB.Execute(pData26.InsertQuery()))
        return false;
      int num27;
      TProgMenu pData27 = this.InitTableBizSMLv4(pData26, num27 = num26 + 1, "04350070", "상품", p_pm_GroupID7, str5 + "GoodsPageVM", "상품별", "item");
      if (!this.OleDB.Execute(pData27.InsertQuery()))
        return false;
      int p_pm_GroupID8 = p_pm_GroupID7 + 1;
      int num28;
      TProgMenu pData28 = this.InitTableBizSMLv2(pData27, num28 = num27 + 1, "04400000", "수불조회", p_pm_GroupID8, "수불조회", "수불조회", "account_book");
      if (!this.OleDB.Execute(pData28.InsertQuery()))
        return false;
      int p_pm_GroupID9 = p_pm_GroupID8 + 1;
      int num29;
      TProgMenu pData29 = this.InitTableBizSMLv3(pData28, num29 = num28 + 1, "04410000", "상품일별조회(매가환원)", p_pm_GroupID9, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "상품 일별 수불(매가환원) 조회", "day_item");
      if (!this.OleDB.Execute(pData29.InsertQuery()))
        return false;
      string str6 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Stock.ReceiptNPay.ByDay.";
      int num30;
      TProgMenu pData30 = this.InitTableBizSMLv4(pData29, num30 = num29 + 1, "04410010", "상품일별", p_pm_GroupID9, str6 + "ByDayPageVM", "상품일별", "day_item");
      if (!this.OleDB.Execute(pData30.InsertQuery()))
        return false;
      int p_pm_GroupID10 = p_pm_GroupID9 + 1;
      int num31;
      TProgMenu pData31 = this.InitTableBizSMLv3(pData30, num31 = num30 + 1, "04420000", "상품일별조회(총평균)", p_pm_GroupID10, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "상품 일별 수불(총평균) 조회", "day_item");
      if (!this.OleDB.Execute(pData31.InsertQuery()))
        return false;
      string str7 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Stock.ReceiptNPay.ByDayAvg.";
      int num32;
      TProgMenu pData32 = this.InitTableBizSMLv4(pData31, num32 = num31 + 1, "04420010", "상품일별", p_pm_GroupID10, str7 + "ByDayPageVM", "상품일별", "day_item");
      if (!this.OleDB.Execute(pData32.InsertQuery()))
        return false;
      int p_pm_GroupID11 = p_pm_GroupID10 + 1;
      int num33;
      TProgMenu pData33 = this.InitTableBizSMLv3(pData32, num33 = num32 + 1, "04430000", "기간수불조회(매가환원)", p_pm_GroupID11, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "기간별 수불(매가환원) 조회", "payment_term_price_reduction");
      if (!this.OleDB.Execute(pData33.InsertQuery()))
        return false;
      string str8 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Stock.ReceiptNPay.Period.";
      int num34;
      TProgMenu pData34 = this.InitTableBizSMLv4(pData33, num34 = num33 + 1, "04430010", "지점", p_pm_GroupID11, str8 + "StorePageVM", "지점별", "site");
      if (!this.OleDB.Execute(pData34.InsertQuery()))
        return false;
      int num35;
      TProgMenu pData35 = this.InitTableBizSMLv4(pData34, num35 = num34 + 1, "04430020", "팀", p_pm_GroupID11, str8 + "TeamPageVM", "팀별", "team");
      if (!this.OleDB.Execute(pData35.InsertQuery()))
        return false;
      int num36;
      TProgMenu pData36 = this.InitTableBizSMLv4(pData35, num36 = num35 + 1, "04430030", "부서", p_pm_GroupID11, str8 + "PartPageVM", "부서별", "department");
      if (!this.OleDB.Execute(pData36.InsertQuery()))
        return false;
      int num37;
      TProgMenu pData37 = this.InitTableBizSMLv4(pData36, num37 = num36 + 1, "04430040", "대분류", p_pm_GroupID11, str8 + "CategoryTopPageVM", "대분류별", "category_main_category");
      if (!this.OleDB.Execute(pData37.InsertQuery()))
        return false;
      int num38;
      TProgMenu pData38 = this.InitTableBizSMLv4(pData37, num38 = num37 + 1, "04430050", "중분류", p_pm_GroupID11, str8 + "CategoryMiddlePageVM", "중분류별", "category_middle_category");
      if (!this.OleDB.Execute(pData38.InsertQuery()))
        return false;
      int num39;
      TProgMenu pData39 = this.InitTableBizSMLv4(pData38, num39 = num38 + 1, "04430060", "소분류", p_pm_GroupID11, str8 + "CategoryBottomPageVM", "소분류별", "category_subclass");
      if (!this.OleDB.Execute(pData39.InsertQuery()))
        return false;
      int num40;
      TProgMenu pData40 = this.InitTableBizSMLv4(pData39, num40 = num39 + 1, "04430070", "상품", p_pm_GroupID11, str8 + "GoodsPageVM", "상품별", "item");
      if (!this.OleDB.Execute(pData40.InsertQuery()))
        return false;
      int p_pm_GroupID12 = p_pm_GroupID11 + 1;
      int num41;
      TProgMenu pData41 = this.InitTableBizSMLv3(pData40, num41 = num40 + 1, "04440000", "기간수불조회(총평균)", p_pm_GroupID12, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "기간별 수불(총평균) 조회", "payment_term_price_reduction");
      if (!this.OleDB.Execute(pData41.InsertQuery()))
        return false;
      string str9 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Stock.ReceiptNPay.PeriodAvg.";
      int num42;
      TProgMenu pData42 = this.InitTableBizSMLv4(pData41, num42 = num41 + 1, "04440010", "지점", p_pm_GroupID12, str9 + "StorePageVM", "지점별", "site");
      if (!this.OleDB.Execute(pData42.InsertQuery()))
        return false;
      int num43;
      TProgMenu pData43 = this.InitTableBizSMLv4(pData42, num43 = num42 + 1, "04440020", "팀", p_pm_GroupID12, str9 + "TeamPageVM", "팀별", "team");
      if (!this.OleDB.Execute(pData43.InsertQuery()))
        return false;
      int num44;
      TProgMenu pData44 = this.InitTableBizSMLv4(pData43, num44 = num43 + 1, "04440030", "부서", p_pm_GroupID12, str9 + "PartPageVM", "부서별", "department");
      if (!this.OleDB.Execute(pData44.InsertQuery()))
        return false;
      int num45;
      TProgMenu pData45 = this.InitTableBizSMLv4(pData44, num45 = num44 + 1, "04440040", "대분류", p_pm_GroupID12, str9 + "CategoryTopPageVM", "대분류별", "category_main_category");
      if (!this.OleDB.Execute(pData45.InsertQuery()))
        return false;
      int num46;
      TProgMenu pData46 = this.InitTableBizSMLv4(pData45, num46 = num45 + 1, "04440050", "중분류", p_pm_GroupID12, str9 + "CategoryMiddlePageVM", "중분류별", "category_middle_category");
      if (!this.OleDB.Execute(pData46.InsertQuery()))
        return false;
      int num47;
      TProgMenu pData47 = this.InitTableBizSMLv4(pData46, num47 = num46 + 1, "04440060", "소분류", p_pm_GroupID12, str9 + "CategoryBottomPageVM", "소분류별", "category_subclass");
      if (!this.OleDB.Execute(pData47.InsertQuery()))
        return false;
      int num48;
      TProgMenu pData48 = this.InitTableBizSMLv4(pData47, num48 = num47 + 1, "04440070", "상품", p_pm_GroupID12, str9 + "GoodsPageVM", "상품별", "item");
      if (!this.OleDB.Execute(pData48.InsertQuery()))
        return false;
      int p_pm_GroupID13 = p_pm_GroupID12 + 1;
      int num49;
      TProgMenu pData49 = this.InitTableBizSMLv3(pData48, num49 = num48 + 1, "04450000", "지점재고(매가환원)", p_pm_GroupID13, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "지점별 재고(매가환원) 조회", "site_adjust_price_reduction");
      if (!this.OleDB.Execute(pData49.InsertQuery()))
        return false;
      string str10 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Stock.ReceiptNPay.Store.";
      int num50;
      TProgMenu pData50 = this.InitTableBizSMLv4(pData49, num50 = num49 + 1, "04450010", "상품재고", p_pm_GroupID13, str10 + "StorePageVM", "상품재고", "adjust");
      if (!this.OleDB.Execute(pData50.InsertQuery()))
        return false;
      int p_pm_GroupID14 = p_pm_GroupID13 + 1;
      int num51;
      TProgMenu pData51 = this.InitTableBizSMLv3(pData50, num51 = num50 + 1, "04460000", "지점재고(총평균)", p_pm_GroupID14, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "지점별 재고(총평균) 조회", "site_adjust_average");
      if (!this.OleDB.Execute(pData51.InsertQuery()))
        return false;
      string str11 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Stock.ReceiptNPay.StoreAvg.";
      int num52;
      TProgMenu pData52 = this.InitTableBizSMLv4(pData51, num52 = num51 + 1, "04460010", "상품재고", p_pm_GroupID14, str11 + "StorePageVM", "상품재고", "adjust");
      if (!this.OleDB.Execute(pData52.InsertQuery()))
        return false;
      int p_pm_GroupID15 = p_pm_GroupID14 + 1;
      int num53;
      TProgMenu pData53 = this.InitTableBizSMLv3(pData52, num53 = num52 + 1, "04610000", "손익 조회(매가환원)", p_pm_GroupID15, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "손익(매가환원) 조회", "month_price_reduction");
      if (!this.OleDB.Execute(pData53.InsertQuery()))
        return false;
      string str12 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Stock.ProfitNLoss.Inq.";
      int num54;
      TProgMenu pData54 = this.InitTableBizSMLv4(pData53, num54 = num53 + 1, "04610010", "지점", p_pm_GroupID15, str12 + "StorePageVM", "지점별", "site");
      if (!this.OleDB.Execute(pData54.InsertQuery()))
        return false;
      int num55;
      TProgMenu pData55 = this.InitTableBizSMLv4(pData54, num55 = num54 + 1, "04610020", "팀", p_pm_GroupID15, str12 + "TeamPageVM", "팀별", "team");
      if (!this.OleDB.Execute(pData55.InsertQuery()))
        return false;
      int num56;
      TProgMenu pData56 = this.InitTableBizSMLv4(pData55, num56 = num55 + 1, "04610030", "부서", p_pm_GroupID15, str12 + "PartPageVM", "부서별", "department");
      if (!this.OleDB.Execute(pData56.InsertQuery()))
        return false;
      int num57;
      TProgMenu pData57 = this.InitTableBizSMLv4(pData56, num57 = num56 + 1, "04610040", "대분류", p_pm_GroupID15, str12 + "CategoryTopPageVM", "대분류별", "category_main_category");
      if (!this.OleDB.Execute(pData57.InsertQuery()))
        return false;
      int num58;
      TProgMenu pData58 = this.InitTableBizSMLv4(pData57, num58 = num57 + 1, "04610050", "중분류", p_pm_GroupID15, str12 + "CategoryMiddlePageVM", "중분류별", "category_middle_category");
      if (!this.OleDB.Execute(pData58.InsertQuery()))
        return false;
      int num59;
      TProgMenu pData59 = this.InitTableBizSMLv4(pData58, num59 = num58 + 1, "04610060", "소분류", p_pm_GroupID15, str12 + "CategoryBottomPageVM", "소분류별", "category_subclass");
      if (!this.OleDB.Execute(pData59.InsertQuery()))
        return false;
      int num60;
      TProgMenu pData60 = this.InitTableBizSMLv4(pData59, num60 = num59 + 1, "04610070", "상품", p_pm_GroupID15, str12 + "GoodsPageVM", "상품별", "item");
      if (!this.OleDB.Execute(pData60.InsertQuery()))
        return false;
      int p_pm_GroupID16 = p_pm_GroupID15 + 1;
      int num61;
      TProgMenu pData61 = this.InitTableBizSMLv3(pData60, num61 = num60 + 1, "04630000", "손익 조회(총평균)", p_pm_GroupID16, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "손익(총평균) 조회", "month_price_reduction");
      if (!this.OleDB.Execute(pData61.InsertQuery()))
        return false;
      string str13 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Stock.ProfitNLoss.InqAvg.";
      int num62;
      TProgMenu pData62 = this.InitTableBizSMLv4(pData61, num62 = num61 + 1, "04630010", "지점", p_pm_GroupID16, str13 + "StorePageVM", "지점별", "site");
      if (!this.OleDB.Execute(pData62.InsertQuery()))
        return false;
      int num63;
      TProgMenu pData63 = this.InitTableBizSMLv4(pData62, num63 = num62 + 1, "04630020", "팀", p_pm_GroupID16, str13 + "TeamPageVM", "팀별", "team");
      if (!this.OleDB.Execute(pData63.InsertQuery()))
        return false;
      int num64;
      TProgMenu pData64 = this.InitTableBizSMLv4(pData63, num64 = num63 + 1, "04630030", "부서", p_pm_GroupID16, str13 + "PartPageVM", "부서별", "department");
      if (!this.OleDB.Execute(pData64.InsertQuery()))
        return false;
      int num65;
      TProgMenu pData65 = this.InitTableBizSMLv4(pData64, num65 = num64 + 1, "04630040", "대분류", p_pm_GroupID16, str13 + "CategoryTopPageVM", "대분류별", "category_main_category");
      if (!this.OleDB.Execute(pData65.InsertQuery()))
        return false;
      int num66;
      TProgMenu pData66 = this.InitTableBizSMLv4(pData65, num66 = num65 + 1, "04630050", "중분류", p_pm_GroupID16, str13 + "CategoryMiddlePageVM", "중분류별", "category_middle_category");
      if (!this.OleDB.Execute(pData66.InsertQuery()))
        return false;
      int num67;
      TProgMenu pData67 = this.InitTableBizSMLv4(pData66, num67 = num66 + 1, "04630060", "소분류", p_pm_GroupID16, str13 + "CategoryBottomPageVM", "소분류별", "category_subclass");
      int num68;
      return this.OleDB.Execute(pData67.InsertQuery()) && this.OleDB.Execute(this.InitTableBizSMLv4(pData67, num68 = num67 + 1, "04630070", "상품", p_pm_GroupID16, str13 + "GoodsPageVM", "상품별", "item").InsertQuery());
    }

    private bool InitTableBizSMSale(long pSiteID)
    {
      int num1 = 1000;
      TProgMenu pData1 = this.OleDB.Create<TProgMenu>();
      pData1.pm_MenuCode = 1;
      int pmMenuCode = pData1.pm_MenuCode;
      pData1.pm_SiteID = pSiteID;
      pData1.pm_ProgKind = 5;
      pData1.pm_MenuSortNo = "01000000";
      pData1.pm_MenuName = "영업정보";
      pData1.pm_GroupID = num1;
      pData1.pm_ProgID = "영업정보";
      pData1.pm_ProgTitle = "영업정보";
      pData1.pm_ViewType = 1;
      pData1.pm_MenuDepth = 1;
      pData1.pm_IconUrl = "sales";
      if (!this.OleDB.Execute(pData1.InsertQuery()))
        return false;
      int p_pm_GroupID1 = num1 + 1;
      int num2;
      TProgMenu pData2 = this.InitTableBizSMLv2(pData1, num2 = pmMenuCode + 1, "01100000", "속보", p_pm_GroupID1, "속보", "속보", "time");
      if (!this.OleDB.Execute(pData2.InsertQuery()))
        return false;
      int p_pm_GroupID2 = p_pm_GroupID1 + 1;
      int num3;
      TProgMenu pData3 = this.InitTableBizSMLv3(pData2, num3 = num2 + 1, "01110000", "기간별 매출", p_pm_GroupID2, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "기간별 매출 현황", "sales_term");
      if (!this.OleDB.Execute(pData3.InsertQuery()))
        return false;
      string str1 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Sales.RealTime.Period.";
      int num4;
      TProgMenu pData4 = this.InitTableBizSMLv4(pData3, num4 = num3 + 1, "01110010", "지점", p_pm_GroupID2, str1 + "StorePageVM", "지점별", "site");
      if (!this.OleDB.Execute(pData4.InsertQuery()))
        return false;
      int num5;
      TProgMenu pData5 = this.InitTableBizSMLv4(pData4, num5 = num4 + 1, "01110020", "팀", p_pm_GroupID2, str1 + "TeamPageVM", "팀별", "team");
      if (!this.OleDB.Execute(pData5.InsertQuery()))
        return false;
      int num6;
      TProgMenu pData6 = this.InitTableBizSMLv4(pData5, num6 = num5 + 1, "01110030", "부서", p_pm_GroupID2, str1 + "PartPageVM", "부서별", "department");
      if (!this.OleDB.Execute(pData6.InsertQuery()))
        return false;
      int num7;
      TProgMenu pData7 = this.InitTableBizSMLv4(pData6, num7 = num6 + 1, "01110040", "대분류", p_pm_GroupID2, str1 + "CategoryTopPageVM", "대분류별", "category_main_category");
      if (!this.OleDB.Execute(pData7.InsertQuery()))
        return false;
      int num8;
      TProgMenu pData8 = this.InitTableBizSMLv4(pData7, num8 = num7 + 1, "01110050", "중분류", p_pm_GroupID2, str1 + "CategoryMiddlePageVM", "중분류별", "category_middle_category");
      if (!this.OleDB.Execute(pData8.InsertQuery()))
        return false;
      int num9;
      TProgMenu pData9 = this.InitTableBizSMLv4(pData8, num9 = num8 + 1, "01110060", "소분류", p_pm_GroupID2, str1 + "CategoryBottomPageVM", "소분류별", "category_subclass");
      if (!this.OleDB.Execute(pData9.InsertQuery()))
        return false;
      int num10;
      TProgMenu pData10 = this.InitTableBizSMLv4(pData9, num10 = num9 + 1, "01110070", "상품", p_pm_GroupID2, str1 + "GoodsPageVM", "상품별", "item");
      if (!this.OleDB.Execute(pData10.InsertQuery()))
        return false;
      int p_pm_GroupID3 = p_pm_GroupID2 + 1;
      int num11;
      TProgMenu pData11 = this.InitTableBizSMLv3(pData10, num11 = num10 + 1, "01130000", "시간대(가로)", p_pm_GroupID3, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "시간대별 매출현황(가로형)", "sales_time_horizontal");
      if (!this.OleDB.Execute(pData11.InsertQuery()))
        return false;
      string str2 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Sales.RealTime.TimeHorizontal.";
      int num12;
      TProgMenu pData12 = this.InitTableBizSMLv4(pData11, num12 = num11 + 1, "01130010", "지점", p_pm_GroupID3, str2 + "StorePageVM", "지점별", "site");
      if (!this.OleDB.Execute(pData12.InsertQuery()))
        return false;
      int num13;
      TProgMenu pData13 = this.InitTableBizSMLv4(pData12, num13 = num12 + 1, "01130020", "팀", p_pm_GroupID3, str2 + "TeamPageVM", "팀별", "team");
      if (!this.OleDB.Execute(pData13.InsertQuery()))
        return false;
      int num14;
      TProgMenu pData14 = this.InitTableBizSMLv4(pData13, num14 = num13 + 1, "01130030", "부서", p_pm_GroupID3, str2 + "PartPageVM", "대분류별", "department");
      if (!this.OleDB.Execute(pData14.InsertQuery()))
        return false;
      int num15;
      TProgMenu pData15 = this.InitTableBizSMLv4(pData14, num15 = num14 + 1, "01130040", "대분류", p_pm_GroupID3, str2 + "CategoryTopPageVM", "대분류별", "category_main_category");
      if (!this.OleDB.Execute(pData15.InsertQuery()))
        return false;
      int num16;
      TProgMenu pData16 = this.InitTableBizSMLv4(pData15, num16 = num15 + 1, "01130050", "중분류", p_pm_GroupID3, str2 + "CategoryMiddlePageVM", "중분류별", "category_middle_category");
      if (!this.OleDB.Execute(pData16.InsertQuery()))
        return false;
      int num17;
      TProgMenu pData17 = this.InitTableBizSMLv4(pData16, num17 = num16 + 1, "01130060", "소분류", p_pm_GroupID3, str2 + "CategoryBottomPageVM", "소분류별", "category_subclass");
      if (!this.OleDB.Execute(pData17.InsertQuery()))
        return false;
      int num18;
      TProgMenu pData18 = this.InitTableBizSMLv4(pData17, num18 = num17 + 1, "01130070", "상품", p_pm_GroupID3, str2 + "GoodsPageVM", "상품별", "item");
      if (!this.OleDB.Execute(pData18.InsertQuery()))
        return false;
      int p_pm_GroupID4 = p_pm_GroupID3 + 1;
      int num19;
      TProgMenu pData19 = this.InitTableBizSMLv3(pData18, num19 = num18 + 1, "01140000", "시간대(세로)", p_pm_GroupID4, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "시간대별 매출현황(세로형)", "sales_time_horizontal");
      if (!this.OleDB.Execute(pData19.InsertQuery()))
        return false;
      string str3 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Sales.RealTime.TimeVertical.";
      int num20;
      TProgMenu pData20 = this.InitTableBizSMLv4(pData19, num20 = num19 + 1, "01140010", "지점", p_pm_GroupID4, str3 + "StorePageVM", "지점별", "site");
      if (!this.OleDB.Execute(pData20.InsertQuery()))
        return false;
      int num21;
      TProgMenu pData21 = this.InitTableBizSMLv4(pData20, num21 = num20 + 1, "01140020", "팀", p_pm_GroupID4, str3 + "TeamPageVM", "팀별", "team");
      if (!this.OleDB.Execute(pData21.InsertQuery()))
        return false;
      int num22;
      TProgMenu pData22 = this.InitTableBizSMLv4(pData21, num22 = num21 + 1, "01140030", "부서", p_pm_GroupID4, str3 + "PartPageVM", "부서별", "department");
      if (!this.OleDB.Execute(pData22.InsertQuery()))
        return false;
      int num23;
      TProgMenu pData23 = this.InitTableBizSMLv4(pData22, num23 = num22 + 1, "01140040", "대분류", p_pm_GroupID4, str3 + "CategoryTopPageVM", "대분류별", "category_main_category");
      if (!this.OleDB.Execute(pData23.InsertQuery()))
        return false;
      int num24;
      TProgMenu pData24 = this.InitTableBizSMLv4(pData23, num24 = num23 + 1, "01140050", "중분류", p_pm_GroupID4, str3 + "CategoryMiddlePageVM", "중분류별", "category_middle_category");
      if (!this.OleDB.Execute(pData24.InsertQuery()))
        return false;
      int num25;
      TProgMenu pData25 = this.InitTableBizSMLv4(pData24, num25 = num24 + 1, "01140060", "소분류", p_pm_GroupID4, str3 + "CategoryBottomPageVM", "소분류별", "category_subclass");
      if (!this.OleDB.Execute(pData25.InsertQuery()))
        return false;
      int num26;
      TProgMenu pData26 = this.InitTableBizSMLv4(pData25, num26 = num25 + 1, "01140070", "상품", p_pm_GroupID4, str3 + "GoodsPageVM", "상품별", "item");
      if (!this.OleDB.Execute(pData26.InsertQuery()))
        return false;
      int p_pm_GroupID5 = p_pm_GroupID4 + 1;
      int num27;
      TProgMenu pData27 = this.InitTableBizSMLv3(pData26, num27 = num26 + 1, "01150000", "기간별 대비", p_pm_GroupID5, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "기간별 대비매출 현황", "sales_term_diff");
      if (!this.OleDB.Execute(pData27.InsertQuery()))
        return false;
      string str4 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Sales.RealTime.Comparison.";
      int num28;
      TProgMenu pData28 = this.InitTableBizSMLv4(pData27, num28 = num27 + 1, "01150010", "지점", p_pm_GroupID5, str4 + "StorePageVM", "지점별", "site");
      if (!this.OleDB.Execute(pData28.InsertQuery()))
        return false;
      int num29;
      TProgMenu pData29 = this.InitTableBizSMLv4(pData28, num29 = num28 + 1, "01150020", "팀", p_pm_GroupID5, str4 + "TeamPageVM", "팀별", "team");
      if (!this.OleDB.Execute(pData29.InsertQuery()))
        return false;
      int num30;
      TProgMenu pData30 = this.InitTableBizSMLv4(pData29, num30 = num29 + 1, "01150030", "부서", p_pm_GroupID5, str4 + "PartPageVM", "부서별", "department");
      if (!this.OleDB.Execute(pData30.InsertQuery()))
        return false;
      int num31;
      TProgMenu pData31 = this.InitTableBizSMLv4(pData30, num31 = num30 + 1, "01150040", "대분류", p_pm_GroupID5, str4 + "CategoryTopPageVM", "대분류별", "category_main_category");
      if (!this.OleDB.Execute(pData31.InsertQuery()))
        return false;
      int num32;
      TProgMenu pData32 = this.InitTableBizSMLv4(pData31, num32 = num31 + 1, "01150050", "중분류", p_pm_GroupID5, str4 + "CategoryMiddlePageVM", "중분류별", "category_middle_category");
      if (!this.OleDB.Execute(pData32.InsertQuery()))
        return false;
      int num33;
      TProgMenu pData33 = this.InitTableBizSMLv4(pData32, num33 = num32 + 1, "01150060", "소분류", p_pm_GroupID5, str4 + "CategoryBottomPageVM", "소분류별", "category_subclass");
      if (!this.OleDB.Execute(pData33.InsertQuery()))
        return false;
      int num34;
      TProgMenu pData34 = this.InitTableBizSMLv4(pData33, num34 = num33 + 1, "01150070", "상품", p_pm_GroupID5, str4 + "GoodsPageVM", "상품별", "item");
      if (!this.OleDB.Execute(pData34.InsertQuery()))
        return false;
      int p_pm_GroupID6 = p_pm_GroupID5 + 1;
      int num35;
      TProgMenu pData35 = this.InitTableBizSMLv2(pData34, num35 = num34 + 1, "01300000", "업체별조회", p_pm_GroupID6, "업체별 조회", "업체별 조회", "company");
      if (!this.OleDB.Execute(pData35.InsertQuery()))
        return false;
      int p_pm_GroupID7 = p_pm_GroupID6 + 1;
      int num36;
      TProgMenu pData36 = this.InitTableBizSMLv3(pData35, num36 = num35 + 1, "01310000", "업체별 매출", p_pm_GroupID7, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "업체별 매출 조회", "invoice_supplier");
      if (!this.OleDB.Execute(pData36.InsertQuery()))
        return false;
      string str5 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Sales.Supplier.Sales.";
      int num37;
      TProgMenu pData37 = this.InitTableBizSMLv4(pData36, num37 = num36 + 1, "01310010", "업체", p_pm_GroupID7, str5 + "SupplierPageVM", "업체별", "company");
      if (!this.OleDB.Execute(pData37.InsertQuery()))
        return false;
      int num38;
      TProgMenu pData38 = this.InitTableBizSMLv4(pData37, num38 = num37 + 1, "01310020", "분류", p_pm_GroupID7, str5 + "CategoryPageVM", "분류별", "company_category");
      if (!this.OleDB.Execute(pData38.InsertQuery()))
        return false;
      int num39;
      TProgMenu pData39 = this.InitTableBizSMLv4(pData38, num39 = num38 + 1, "01310030", "상품", p_pm_GroupID7, str5 + "GoodsPageVM", "상품별", "company_category_item");
      if (!this.OleDB.Execute(pData39.InsertQuery()))
        return false;
      int p_pm_GroupID8 = p_pm_GroupID7 + 1;
      int num40;
      TProgMenu pData40 = this.InitTableBizSMLv3(pData39, num40 = num39 + 1, "01320000", "업체별 대비", p_pm_GroupID8, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "업체별 대비 조회", "invoice_supplier");
      if (!this.OleDB.Execute(pData40.InsertQuery()))
        return false;
      string str6 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Sales.Supplier.Comparison.";
      int num41;
      TProgMenu pData41 = this.InitTableBizSMLv4(pData40, num41 = num40 + 1, "01320010", "업체", p_pm_GroupID8, str6 + "SupplierPageVM", "업체별", "company");
      if (!this.OleDB.Execute(pData41.InsertQuery()))
        return false;
      int num42;
      TProgMenu pData42 = this.InitTableBizSMLv4(pData41, num42 = num41 + 1, "01320020", "분류", p_pm_GroupID8, str6 + "CategoryPageVM", "분류별", "company_category");
      if (!this.OleDB.Execute(pData42.InsertQuery()))
        return false;
      int num43;
      TProgMenu pData43 = this.InitTableBizSMLv4(pData42, num43 = num42 + 1, "01320030", "상품", p_pm_GroupID8, str6 + "GoodsPageVM", "상품별", "company_category_item");
      if (!this.OleDB.Execute(pData43.InsertQuery()))
        return false;
      int p_pm_GroupID9 = p_pm_GroupID8 + 1;
      int num44;
      TProgMenu pData44 = this.InitTableBizSMLv2(pData43, num44 = num43 + 1, "01500000", "일자별 조회", p_pm_GroupID9, "일자별 조회", "일자별 조회", "item");
      if (!this.OleDB.Execute(pData44.InsertQuery()))
        return false;
      int p_pm_GroupID10 = p_pm_GroupID9 + 1;
      int num45;
      TProgMenu pData45 = this.InitTableBizSMLv3(pData44, num45 = num44 + 1, "01510000", "일별(가로형)", p_pm_GroupID10, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "일별 매출 조회 (가로형)", "day_horizontal");
      if (!this.OleDB.Execute(pData45.InsertQuery()))
        return false;
      string str7 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Sales.Day.Horizontal.";
      int num46;
      TProgMenu pData46 = this.InitTableBizSMLv4(pData45, num46 = num45 + 1, "01510010", "지점", p_pm_GroupID10, str7 + "StorePageVM", "지점별", "site");
      if (!this.OleDB.Execute(pData46.InsertQuery()))
        return false;
      int num47;
      TProgMenu pData47 = this.InitTableBizSMLv4(pData46, num47 = num46 + 1, "01510020", "팀", p_pm_GroupID10, str7 + "TeamPageVM", "팀별", "team");
      if (!this.OleDB.Execute(pData47.InsertQuery()))
        return false;
      int num48;
      TProgMenu pData48 = this.InitTableBizSMLv4(pData47, num48 = num47 + 1, "01510030", "부서", p_pm_GroupID10, str7 + "PartPageVM", "부서별", "department");
      if (!this.OleDB.Execute(pData48.InsertQuery()))
        return false;
      int num49;
      TProgMenu pData49 = this.InitTableBizSMLv4(pData48, num49 = num48 + 1, "01510040", "대분류", p_pm_GroupID10, str7 + "CategoryTopPageVM", "대분류별", "category_main_category");
      if (!this.OleDB.Execute(pData49.InsertQuery()))
        return false;
      int num50;
      TProgMenu pData50 = this.InitTableBizSMLv4(pData49, num50 = num49 + 1, "01510050", "소분류", p_pm_GroupID10, str7 + "CategoryMiddlePageVM", "중분류별", "category_middle_category");
      if (!this.OleDB.Execute(pData50.InsertQuery()))
        return false;
      int num51;
      TProgMenu pData51 = this.InitTableBizSMLv4(pData50, num51 = num50 + 1, "01510060", "소분류", p_pm_GroupID10, str7 + "CategoryBottomPageVM", "소분류별", "category_subclass");
      if (!this.OleDB.Execute(pData51.InsertQuery()))
        return false;
      int num52;
      TProgMenu pData52 = this.InitTableBizSMLv4(pData51, num52 = num51 + 1, "01510070", "상품", p_pm_GroupID10, str7 + "GoodsPageVM", "상품별", "item");
      if (!this.OleDB.Execute(pData52.InsertQuery()))
        return false;
      int p_pm_GroupID11 = p_pm_GroupID10 + 1;
      int num53;
      TProgMenu pData53 = this.InitTableBizSMLv3(pData52, num53 = num52 + 1, "01520000", "업체(일별)", p_pm_GroupID11, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "업체 일별 매출 조회", "day_company");
      if (!this.OleDB.Execute(pData53.InsertQuery()))
        return false;
      string str8 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Sales.Day.Supplier.";
      int num54;
      TProgMenu pData54 = this.InitTableBizSMLv4(pData53, num54 = num53 + 1, "01520010", "업체", p_pm_GroupID11, str8 + "SupplierPageVM", "업체별", "company");
      if (!this.OleDB.Execute(pData54.InsertQuery()))
        return false;
      int num55;
      TProgMenu pData55 = this.InitTableBizSMLv4(pData54, num55 = num54 + 1, "01520020", "분류", p_pm_GroupID11, str8 + "CategoryPageVM", "분류별", "company_category");
      if (!this.OleDB.Execute(pData55.InsertQuery()))
        return false;
      int num56;
      TProgMenu pData56 = this.InitTableBizSMLv4(pData55, num56 = num55 + 1, "01520030", "상품", p_pm_GroupID11, str8 + "GoodsPageVM", "상품별", "company_category_item");
      if (!this.OleDB.Execute(pData56.InsertQuery()))
        return false;
      int p_pm_GroupID12 = p_pm_GroupID11 + 1;
      int num57;
      TProgMenu pData57 = this.InitTableBizSMLv3(pData56, num57 = num56 + 1, "01530000", "일별(세로형)", p_pm_GroupID12, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "일별 매출 조회 (세로형)", "day_vertical");
      if (!this.OleDB.Execute(pData57.InsertQuery()))
        return false;
      string str9 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Sales.Day.Vertical.";
      int num58;
      TProgMenu pData58 = this.InitTableBizSMLv4(pData57, num58 = num57 + 1, "01530010", "지점", p_pm_GroupID12, str9 + "StorePageVM", "지점별", "site");
      if (!this.OleDB.Execute(pData58.InsertQuery()))
        return false;
      int num59;
      TProgMenu pData59 = this.InitTableBizSMLv4(pData58, num59 = num58 + 1, "01530020", "팀", p_pm_GroupID12, str9 + "TeamPageVM", "팀별", "team");
      if (!this.OleDB.Execute(pData59.InsertQuery()))
        return false;
      int num60;
      TProgMenu pData60 = this.InitTableBizSMLv4(pData59, num60 = num59 + 1, "01530030", "부서", p_pm_GroupID12, str9 + "PartPageVM", "부서별", "department");
      if (!this.OleDB.Execute(pData60.InsertQuery()))
        return false;
      int num61;
      TProgMenu pData61 = this.InitTableBizSMLv4(pData60, num61 = num60 + 1, "01530040", "대분류", p_pm_GroupID12, str9 + "CategoryTopPageVM", "대분류별", "category_main_category");
      if (!this.OleDB.Execute(pData61.InsertQuery()))
        return false;
      int num62;
      TProgMenu pData62 = this.InitTableBizSMLv4(pData61, num62 = num61 + 1, "01530050", "중분류", p_pm_GroupID12, str9 + "CategoryMiddlePageVM", "중분류별", "category_middle_category");
      if (!this.OleDB.Execute(pData62.InsertQuery()))
        return false;
      int num63;
      TProgMenu pData63 = this.InitTableBizSMLv4(pData62, num63 = num62 + 1, "01530060", "소분류", p_pm_GroupID12, str9 + "CategoryBottomPageVM", "소분류별", "category_subclass");
      if (!this.OleDB.Execute(pData63.InsertQuery()))
        return false;
      int num64;
      TProgMenu pData64 = this.InitTableBizSMLv4(pData63, num64 = num63 + 1, "01530070", "상품", p_pm_GroupID12, str9 + "GoodsPageVM", "상품별", "item");
      if (!this.OleDB.Execute(pData64.InsertQuery()))
        return false;
      int p_pm_GroupID13 = p_pm_GroupID12 + 1;
      int num65;
      TProgMenu pData65 = this.InitTableBizSMLv2(pData64, num65 = num64 + 1, "01700000", "월별 조회", p_pm_GroupID13, "월별 조회", "월별 조회", "month");
      if (!this.OleDB.Execute(pData65.InsertQuery()))
        return false;
      int p_pm_GroupID14 = p_pm_GroupID13 + 1;
      int num66;
      TProgMenu pData66 = this.InitTableBizSMLv3(pData65, num66 = num65 + 1, "01710000", "월별(가로형)", p_pm_GroupID14, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "월별 매출 조회 (가로형)", "month_horizontal");
      if (!this.OleDB.Execute(pData66.InsertQuery()))
        return false;
      string str10 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Sales.Month.Horizontal.";
      int num67;
      TProgMenu pData67 = this.InitTableBizSMLv4(pData66, num67 = num66 + 1, "01710010", "지점", p_pm_GroupID14, str10 + "StorePageVM", "지점별", "site");
      if (!this.OleDB.Execute(pData67.InsertQuery()))
        return false;
      int num68;
      TProgMenu pData68 = this.InitTableBizSMLv4(pData67, num68 = num67 + 1, "01710020", "팀", p_pm_GroupID14, str10 + "TeamPageVM", "팀별", "team");
      if (!this.OleDB.Execute(pData68.InsertQuery()))
        return false;
      int num69;
      TProgMenu pData69 = this.InitTableBizSMLv4(pData68, num69 = num68 + 1, "01710030", "부서", p_pm_GroupID14, str10 + "PartPageVM", "부서별", "department");
      if (!this.OleDB.Execute(pData69.InsertQuery()))
        return false;
      int num70;
      TProgMenu pData70 = this.InitTableBizSMLv4(pData69, num70 = num69 + 1, "01710040", "대분류", p_pm_GroupID14, str10 + "CategoryTopPageVM", "대분류별", "category_main_category");
      if (!this.OleDB.Execute(pData70.InsertQuery()))
        return false;
      int num71;
      TProgMenu pData71 = this.InitTableBizSMLv4(pData70, num71 = num70 + 1, "01710050", "중분류", p_pm_GroupID14, str10 + "CategoryMiddlePageVM", "중분류별", "category_middle_category");
      if (!this.OleDB.Execute(pData71.InsertQuery()))
        return false;
      int num72;
      TProgMenu pData72 = this.InitTableBizSMLv4(pData71, num72 = num71 + 1, "01710060", "소분류", p_pm_GroupID14, str10 + "CategoryBottomPageVM", "소분류별", "category_subclass");
      if (!this.OleDB.Execute(pData72.InsertQuery()))
        return false;
      int num73;
      TProgMenu pData73 = this.InitTableBizSMLv4(pData72, num73 = num72 + 1, "01710070", "상품", p_pm_GroupID14, str10 + "GoodsPageVM", "상품별", "item");
      if (!this.OleDB.Execute(pData73.InsertQuery()))
        return false;
      int p_pm_GroupID15 = p_pm_GroupID14 + 1;
      int num74;
      TProgMenu pData74 = this.InitTableBizSMLv3(pData73, num74 = num73 + 1, "01730000", "업체(월별)", p_pm_GroupID15, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "업체 월별 매출 조회", "month_company");
      if (!this.OleDB.Execute(pData74.InsertQuery()))
        return false;
      string str11 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Sales.Month.Supplier.";
      int num75;
      TProgMenu pData75 = this.InitTableBizSMLv4(pData74, num75 = num74 + 1, "01730010", "업체", p_pm_GroupID15, str11 + "SupplierPageVM", "업체별", "company");
      if (!this.OleDB.Execute(pData75.InsertQuery()))
        return false;
      int num76;
      TProgMenu pData76 = this.InitTableBizSMLv4(pData75, num76 = num75 + 1, "01730020", "분류", p_pm_GroupID15, str11 + "CategoryPageVM", "업체-분류별", "company");
      if (!this.OleDB.Execute(pData76.InsertQuery()))
        return false;
      int num77;
      TProgMenu pData77 = this.InitTableBizSMLv4(pData76, num77 = num76 + 1, "01730030", "상품", p_pm_GroupID15, str11 + "GoodsPageVM", "업체-분류-상품별", "company");
      if (!this.OleDB.Execute(pData77.InsertQuery()))
        return false;
      int p_pm_GroupID16 = p_pm_GroupID15 + 1;
      int num78;
      TProgMenu pData78 = this.InitTableBizSMLv3(pData77, num78 = num77 + 1, "01750000", "월별(세로형)", p_pm_GroupID16, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "월별 매출 조회(세로형)", "month_horizontal");
      if (!this.OleDB.Execute(pData78.InsertQuery()))
        return false;
      string str12 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Sales.Month.Vertical.";
      int num79;
      TProgMenu pData79 = this.InitTableBizSMLv4(pData78, num79 = num78 + 1, "01750010", "지점", p_pm_GroupID16, str12 + "StorePageVM", "지점별", "site");
      if (!this.OleDB.Execute(pData79.InsertQuery()))
        return false;
      int num80;
      TProgMenu pData80 = this.InitTableBizSMLv4(pData79, num80 = num79 + 1, "01750020", "팀", p_pm_GroupID16, str12 + "TeamPageVM", "팀별", "team");
      if (!this.OleDB.Execute(pData80.InsertQuery()))
        return false;
      int num81;
      TProgMenu pData81 = this.InitTableBizSMLv4(pData80, num81 = num80 + 1, "01750030", "부서", p_pm_GroupID16, str12 + "PartPageVM", "부서별", "department");
      if (!this.OleDB.Execute(pData81.InsertQuery()))
        return false;
      int num82;
      TProgMenu pData82 = this.InitTableBizSMLv4(pData81, num82 = num81 + 1, "01750040", "대분류", p_pm_GroupID16, str12 + "CategoryTopPageVM", "대분류별", "category_main_category");
      if (!this.OleDB.Execute(pData82.InsertQuery()))
        return false;
      int num83;
      TProgMenu pData83 = this.InitTableBizSMLv4(pData82, num83 = num82 + 1, "01750050", "중분류", p_pm_GroupID16, str12 + "CategoryMiddlePageVM", "중분류별", "category_middle_category");
      if (!this.OleDB.Execute(pData83.InsertQuery()))
        return false;
      int num84;
      TProgMenu pData84 = this.InitTableBizSMLv4(pData83, num84 = num83 + 1, "01750060", "소분류", p_pm_GroupID16, str12 + "CategoryBottomPageVM", "소분류별", "category_subclass");
      int num85;
      return this.OleDB.Execute(pData84.InsertQuery()) && this.OleDB.Execute(this.InitTableBizSMLv4(pData84, num85 = num84 + 1, "01750070", "상품", p_pm_GroupID16, str12 + "GoodsPageVM", "상품별", "item").InsertQuery());
    }

    private bool InitTableBizSMSystem(long pSiteID)
    {
      int num1 = 9000;
      TProgMenu pData1 = this.OleDB.Create<TProgMenu>();
      pData1.pm_MenuCode = 751;
      int pmMenuCode = pData1.pm_MenuCode;
      pData1.pm_SiteID = pSiteID;
      pData1.pm_ProgKind = 5;
      pData1.pm_MenuSortNo = "99000000";
      pData1.pm_MenuName = "시스템";
      pData1.pm_GroupID = num1;
      pData1.pm_ProgID = "시스템";
      pData1.pm_ProgTitle = "시스템";
      pData1.pm_ViewType = 1;
      pData1.pm_MenuDepth = 1;
      pData1.pm_IconUrl = "system";
      if (!this.OleDB.Execute(pData1.InsertQuery()))
        return false;
      int p_pm_GroupID1 = num1 + 1;
      int num2;
      TProgMenu pData2 = this.InitTableBizSMLv2(pData1, num2 = pmMenuCode + 1, "99100000", "프로그램", p_pm_GroupID1, "프로그램", "프로그램", "program");
      if (!this.OleDB.Execute(pData2.InsertQuery()))
        return false;
      int p_pm_GroupID2 = p_pm_GroupID1 + 1;
      int num3;
      TProgMenu pData3 = this.InitTableBizSMLv3(pData2, num3 = num2 + 1, "99120000", "공통코드", p_pm_GroupID2, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "공통코드 등록 정보", "common_code");
      if (!this.OleDB.Execute(pData3.InsertQuery()))
        return false;
      string str1 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Systems.Program.CommonCode.";
      int num4;
      TProgMenu pData4 = this.InitTableBizSMLv4(pData3, num4 = num3 + 1, "99120010", "공통코드", p_pm_GroupID2, str1 + "CommonCodeListPageVM", "공통코드", "common_code");
      if (!this.OleDB.Execute(pData4.InsertQuery()))
        return false;
      int p_pm_GroupID3 = p_pm_GroupID2 + 1;
      int num5;
      TProgMenu pData5 = this.InitTableBizSMLv3(pData4, num5 = num4 + 1, "99130000", "메뉴", p_pm_GroupID3, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "메뉴 등록 정보", "menu");
      if (!this.OleDB.Execute(pData5.InsertQuery()))
        return false;
      string str2 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Systems.Program.ProgMenu.";
      int num6;
      TProgMenu pData6 = this.InitTableBizSMLv4(pData5, num6 = num5 + 1, "99130010", "메뉴", p_pm_GroupID3, str2 + "ProgMenuListPageVM", "메뉴코드", "menu");
      if (!this.OleDB.Execute(pData6.InsertQuery()))
        return false;
      int p_pm_GroupID4 = p_pm_GroupID3 + 1;
      int num7;
      TProgMenu pData7 = this.InitTableBizSMLv3(pData6, num7 = num6 + 1, "99140000", "메뉴권한", p_pm_GroupID4, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "메뉴 권한 정보", "menu_permit");
      if (!this.OleDB.Execute(pData7.InsertQuery()))
        return false;
      string str3 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Systems.Program.ProgMenuAuth.";
      int num8;
      TProgMenu pData8 = this.InitTableBizSMLv4(pData7, num8 = num7 + 1, "99140010", "메뉴", p_pm_GroupID4, str3 + "ProgMenuAuthListPageVM", "메뉴권한", "menu_permit");
      if (!this.OleDB.Execute(pData8.InsertQuery()))
        return false;
      int num9;
      TProgMenu pData9 = this.InitTableBizSMLv4(pData8, num9 = num8 + 1, "99140020", "권한단계", p_pm_GroupID4, str3 + "ProgMenuAuthDepthPageVM", "메뉴 권한 단계", "menu_permit");
      if (!this.OleDB.Execute(pData9.InsertQuery()))
        return false;
      int p_pm_GroupID5 = p_pm_GroupID4 + 1;
      int num10;
      TProgMenu pData10 = this.InitTableBizSMLv3(pData9, num10 = num9 + 1, "99150000", "팝업", p_pm_GroupID5, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "팝업 등록 정보", "popup");
      if (!this.OleDB.Execute(pData10.InsertQuery()))
        return false;
      string str4 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Systems.Program.ProgMenuProp.";
      int num11;
      TProgMenu pData11 = this.InitTableBizSMLv4(pData10, num11 = num10 + 1, "99150010", "팝업", p_pm_GroupID5, str4 + "ProgMenuPropListPageVM", "팝업", "popup");
      if (!this.OleDB.Execute(pData11.InsertQuery()))
        return false;
      int p_pm_GroupID6 = p_pm_GroupID5 + 1;
      int num12;
      TProgMenu pData12 = this.InitTableBizSMLv3(pData11, num12 = num11 + 1, "99160000", "팝업권한", p_pm_GroupID6, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "팝업 권한 정보", "popup_permit");
      if (!this.OleDB.Execute(pData12.InsertQuery()))
        return false;
      string str5 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Systems.Program.ProgMenuPropAuth.";
      int num13;
      TProgMenu pData13 = this.InitTableBizSMLv4(pData12, num13 = num12 + 1, "99160010", "팝업권한", p_pm_GroupID6, str5 + "ProgMenuPropAuthListPageVM", "팝업 권한", "popup_permit");
      if (!this.OleDB.Execute(pData13.InsertQuery()))
        return false;
      int num14;
      TProgMenu pData14 = this.InitTableBizSMLv4(pData13, num14 = num13 + 1, "99160020", "권한단계", p_pm_GroupID6, str5 + "ProgMenuPropAuthDepthPageVM", "팝업 권한 단계", "popup_permit");
      if (!this.OleDB.Execute(pData14.InsertQuery()))
        return false;
      int p_pm_GroupID7 = p_pm_GroupID6 + 1;
      int num15;
      TProgMenu pData15 = this.InitTableBizSMLv3(pData14, num15 = num14 + 1, "99170000", "환경설정", p_pm_GroupID7, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "환경 설정 정보", "program");
      if (!this.OleDB.Execute(pData15.InsertQuery()))
        return false;
      string str6 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Systems.Program.ProgOption.";
      int num16;
      TProgMenu pData16 = this.InitTableBizSMLv4(pData15, num16 = num15 + 1, "99170010", "환경설정", p_pm_GroupID7, str6 + "ProgOptionPageVM", "환경 설정 등록", "program");
      if (!this.OleDB.Execute(pData16.InsertQuery()))
        return false;
      int p_pm_GroupID8 = p_pm_GroupID7 + 1;
      int num17;
      TProgMenu pData17 = this.InitTableBizSMLv2(pData16, num17 = num16 + 1, "99300000", "보안", p_pm_GroupID8, "보안", "보안", "security_permit");
      if (!this.OleDB.Execute(pData17.InsertQuery()))
        return false;
      int p_pm_GroupID9 = p_pm_GroupID8 + 1;
      int num18;
      TProgMenu pData18 = this.InitTableBizSMLv3(pData17, num18 = num17 + 1, "99310000", "장치등록", p_pm_GroupID9, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "장치 등록 권한 정보", "device");
      if (!this.OleDB.Execute(pData18.InsertQuery()))
        return false;
      string str7 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Systems.Security.OuterConnAuth.";
      int num19;
      TProgMenu pData19 = this.InitTableBizSMLv4(pData18, num19 = num18 + 1, "99310010", "장치", p_pm_GroupID9, str7 + "OuterConnAuthListPageVM", "장치 관리 현황", "device_register");
      if (!this.OleDB.Execute(pData19.InsertQuery()))
        return false;
      int p_pm_GroupID10 = p_pm_GroupID9 + 1;
      int num20;
      TProgMenu pData20 = this.InitTableBizSMLv3(pData19, num20 = num19 + 1, "99320000", "사용로그", p_pm_GroupID10, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "사용 로그 조회", "data_log_search");
      if (!this.OleDB.Execute(pData20.InsertQuery()))
        return false;
      string str8 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Systems.Security.EmpActionLog.";
      int num21;
      TProgMenu pData21 = this.InitTableBizSMLv4(pData20, num21 = num20 + 1, "99320010", "사용로그", p_pm_GroupID10, str8 + "EmpActionLogPageVM", "사용 로그 현황", "data_log");
      if (!this.OleDB.Execute(pData21.InsertQuery()))
        return false;
      int p_pm_GroupID11 = p_pm_GroupID10 + 1;
      int num22;
      TProgMenu pData22 = this.InitTableBizSMLv2(pData21, num22 = num21 + 1, "99500000", "Server", p_pm_GroupID11, "Server", "Server", "info");
      if (!this.OleDB.Execute(pData22.InsertQuery()))
        return false;
      int p_pm_GroupID12 = p_pm_GroupID11 + 1;
      int num23;
      TProgMenu pData23 = this.InitTableBizSMLv3(pData22, num23 = num22 + 1, "99510000", "일마감", p_pm_GroupID12, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "일 마감 개설", "link_table");
      if (!this.OleDB.Execute(pData23.InsertQuery()))
        return false;
      string str9 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Systems.Eod.EodInfo.";
      int num24;
      TProgMenu pData24 = this.InitTableBizSMLv4(pData23, num24 = num23 + 1, "99510010", "일마감", p_pm_GroupID12, str9 + "EodInfoListPageVM", "일 마감 개설 작업", "link_table");
      if (!this.OleDB.Execute(pData24.InsertQuery()))
        return false;
      int p_pm_GroupID13 = p_pm_GroupID12 + 1;
      int num25;
      TProgMenu pData25 = this.InitTableBizSMLv3(pData24, num25 = num24 + 1, "99520000", "디비백업", p_pm_GroupID13, "UniBizSM.Client.Core.ViewModels.Page.Parents.TabParentPageVM", "DB BACKUP", "link_table");
      if (!this.OleDB.Execute(pData25.InsertQuery()))
        return false;
      string str10 = "UniBizSM.Client.Core.ViewModels.Page.UniSales.Systems.Eod.DbBackup.";
      int num26;
      return this.OleDB.Execute(this.InitTableBizSMLv4(pData25, num26 = num25 + 1, "99520010", "DB BACKUP", p_pm_GroupID13, str10 + "DbBackupListPageVM", "마감 데이터베이스 백업 작업", "link_table").InsertQuery());
    }

    public static string CreateTableQuery()
    {
      string tableQuery;
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          tableQuery = ProgMenuCreate.CreateTableMsSql();
          break;
        case EnumDB.MYSQL:
          tableQuery = ProgMenuCreate.CreateTableMySql();
          break;
        default:
          tableQuery = string.Empty;
          break;
      }
      return tableQuery;
    }

    public static string CreateTableMsSql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_BASE, (object) TableCodeType.ProgMenu) + " pm_MenuCode INT NOT NULL,pm_SiteID BIGINT NOT NULL DEFAULT(0),pm_ProgKind INT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "pm_MenuSortNo", (object) 8) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "pm_MenuName", (object) 100) + ",pm_GroupID INT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "pm_ProgID", (object) 200) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "pm_ProgTitle", (object) 100) + ",pm_ViewType INT NOT NULL DEFAULT(0),pm_MenuDepth INT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "pm_IconUrl", (object) 200) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('{2}')", (object) "pm_UseYn", (object) 1, (object) "Y") + ",pm_InDate DATETIME NULL,pm_InUser INT NOT NULL DEFAULT(0),pm_ModDate DATETIME NULL,pm_ModUser INT NOT NULL DEFAULT(0) PRIMARY KEY(pm_MenuCode) ) ;";

    public static string CreateTableMySql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_BASE, (object) TableCodeType.ProgMenu) + " pm_MenuCode INT NOT NULL,pm_SiteID BIGINT NOT NULL DEFAULT 0,pm_ProgKind INT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "pm_MenuSortNo", (object) 8) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "pm_MenuName", (object) 100) + ",pm_GroupID INT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "pm_ProgID", (object) 200) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "pm_ProgTitle", (object) 100) + ",pm_ViewType INT NOT NULL DEFAULT 0,pm_MenuDepth INT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "pm_IconUrl", (object) 200) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT '{2}'", (object) "pm_UseYn", (object) 1, (object) "Y") + ",pm_InDate DATETIME NULL,pm_InUser INT NOT NULL DEFAULT 0,pm_ModDate DATETIME NULL,pm_ModUser INT NOT NULL DEFAULT 0 PRIMARY KEY(pm_MenuCode) ) ;";

    public bool CreateTable()
    {
      if (this.OleDB.Execute(ProgMenuCreate.CreateTableQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public bool DropTable()
    {
      if (this.OleDB.Execute(string.Format("DROP Table {0}..{1}", (object) UbModelBase.UNI_BASE, (object) this.TableCode)))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public bool CreateTableComment(string p_db_category)
    {
      if (DbQueryHelper.DbTypeNotNull() != EnumDB.MSSQL)
        return true;
      StringBuilder stringBuilder = new StringBuilder();
      try
      {
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}';", (object) UbModelBase.UNI_BASE, (object) TableCodeType.ProgMenu.ToDescription(), (object) TableCodeType.ProgMenu));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "메뉴코드", (object) TableCodeType.ProgMenu, (object) "pm_MenuCode"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "싸이트", (object) TableCodeType.ProgMenu, (object) "pm_SiteID"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) UbModelBase.UNI_BASE, (object) "프로그램 종류", (object) 1, (object) TableCodeType.ProgMenu, (object) "pm_ProgKind"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "프로그램 순위", (object) TableCodeType.ProgMenu, (object) "pm_MenuSortNo"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "메뉴명", (object) TableCodeType.ProgMenu, (object) "pm_MenuName"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "모듈 ID", (object) TableCodeType.ProgMenu, (object) "pm_GroupID"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "프로그램 ID", (object) TableCodeType.ProgMenu, (object) "pm_ProgID"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "타이틀", (object) TableCodeType.ProgMenu, (object) "pm_ProgTitle"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) UbModelBase.UNI_BASE, (object) "뷰타입", (object) 33, (object) TableCodeType.ProgMenu, (object) "pm_ViewType"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) UbModelBase.UNI_BASE, (object) "단계", (object) 34, (object) TableCodeType.ProgMenu, (object) "pm_MenuDepth"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "이미지 URL", (object) TableCodeType.ProgMenu, (object) "pm_IconUrl"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "사용상태", (object) TableCodeType.ProgMenu, (object) "pm_UseYn"));
        if (this.OleDB.Execute(stringBuilder.ToString()))
          return true;
        this.message = " " + this.TableCode.ToDescription() + " 주석 Comment 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.DebugColor(this.message);
        return false;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) ex.GetHashCode()) + " 내용 : " + ex.Message + "\n Query : " + stringBuilder.ToString() + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
        stringBuilder.Clear();
      }
      return false;
    }

    public bool InitTable() => this.InitTable(1L);

    public bool InitTable(long pSiteID)
    {
      if (pSiteID == 0L)
        pSiteID = 1L;
      return this.InitTableBizSM(pSiteID) && this.InitTableBizSCM(pSiteID) && this.InitTableBizBO(pSiteID);
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        if (p_rs.IsFieldName("pm_MenuCode"))
          this.pm_MenuCode = p_rs.GetFieldInt("pm_MenuCode");
        if (p_rs.IsFieldName("pm_SiteID"))
          this.pm_SiteID = p_rs.GetFieldLong("pm_SiteID");
        if (p_rs.IsFieldName("pm_ProgKind"))
          this.pm_ProgKind = p_rs.GetFieldInt("pm_ProgKind");
        if (p_rs.IsFieldName("pm_MenuSortNo"))
          this.pm_MenuSortNo = p_rs.GetFieldString("pm_MenuSortNo");
        if (p_rs.IsFieldName("pm_MenuName"))
          this.pm_MenuName = p_rs.GetFieldString("pm_MenuName");
        if (p_rs.IsFieldName("pm_GroupID"))
          this.pm_GroupID = p_rs.GetFieldInt("pm_GroupID");
        if (p_rs.IsFieldName("pm_ProgID"))
          this.pm_ProgID = p_rs.GetFieldString("pm_ProgID");
        if (p_rs.IsFieldName("pm_ProgTitle"))
          this.pm_ProgTitle = p_rs.GetFieldString("pm_ProgTitle");
        if (p_rs.IsFieldName("pm_ViewType"))
          this.pm_ViewType = p_rs.GetFieldInt("pm_ViewType");
        if (p_rs.IsFieldName("pm_MenuDepth"))
          this.pm_MenuDepth = p_rs.GetFieldInt("pm_MenuDepth");
        if (p_rs.IsFieldName("pm_IconUrl"))
          this.pm_IconUrl = p_rs.GetFieldString("pm_IconUrl");
        if (p_rs.IsFieldName("pm_UseYn"))
          this.pm_UseYn = p_rs.GetFieldString("pm_UseYn");
        if (p_rs.IsFieldName("pm_InDate"))
          this.pm_InDate = p_rs.GetFieldDateTime("pm_InDate");
        if (p_rs.IsFieldName("pm_InUser"))
          this.pm_InUser = p_rs.GetFieldInt("pm_InUser");
        if (p_rs.IsFieldName("pm_ModDate"))
          this.pm_ModDate = p_rs.GetFieldDateTime("pm_ModDate");
        if (p_rs.IsFieldName("pm_ModUser"))
          this.pm_ModUser = p_rs.GetFieldInt("pm_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public bool ReCreateTable()
    {
      try
      {
        IList<ProgMenuCreate> progMenuCreateList = this.OleDB.Create<ProgMenuCreate>().SelectAllListE<ProgMenuCreate>((object) new Hashtable()
        {
          {
            (object) "DBMS",
            (object) UbModelBase.UNI_BASE
          }
        });
        if (progMenuCreateList == null)
        {
          this.message = " " + this.TableCode.ToDescription() + " SELECT AND Serialize 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          throw new Exception();
        }
        if (!this.DropTable())
        {
          this.message = " " + this.TableCode.ToDescription() + " Drop 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          throw new Exception();
        }
        if (!this.CreateTable())
        {
          this.message = " " + this.TableCode.ToDescription() + " Create 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          throw new Exception();
        }
        if (!this.CreateTableComment(string.Empty))
        {
          this.message = " " + this.TableCode.ToDescription() + " Create Comment 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          throw new Exception();
        }
        int count = progMenuCreateList.Count;
        int num1 = 0;
        int num2 = 0;
        if (progMenuCreateList.Count > 0)
          Log.Logger.DebugColor("\n--------------------------------------------------------------------------------------------------" + string.Format("\n - {0}({1}) 이전 데이터 작업 시작", (object) TableCodeType.ProgMenu.ToDescription(), (object) TableCodeType.ProgMenu) + "\n--------------------------------------------------------------------------------------------------");
        StringBuilder stringBuilder = new StringBuilder();
        foreach (ProgMenuCreate progMenuCreate in (IEnumerable<ProgMenuCreate>) progMenuCreateList)
        {
          stringBuilder.Append(progMenuCreate.InsertQuery());
          if (stringBuilder.Length > 4000)
          {
            if (!this.OleDB.Execute(stringBuilder.ToString()))
            {
              this.message = " " + this.TableCode.ToDescription() + " Insert 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
              throw new Exception();
            }
            stringBuilder.Clear();
          }
          ++num1;
          int num3 = num1 * 100 / count;
          if (num2 != num3)
          {
            Log.Logger.DebugColor(string.Format(" pro = {0}%", (object) num3));
            num2 = num3;
          }
        }
        if (stringBuilder.Length > 0)
        {
          if (!this.OleDB.Execute(stringBuilder.ToString()))
          {
            this.message = " " + this.TableCode.ToDescription() + " Insert 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
            throw new Exception();
          }
          stringBuilder.Clear();
        }
        if (progMenuCreateList.Count > 0)
        {
          if (num2 != 100)
            Log.Logger.DebugColor(" pro = 100%");
          Log.Logger.DebugColor(string.Format(" - {0}({1}) 이전 데이터 작업 종료", (object) TableCodeType.ProgMenu.ToDescription(), (object) TableCodeType.ProgMenu) + "\n--------------------------------------------------------------------------------------------------");
        }
      }
      catch (Exception ex)
      {
        Log.Logger.DebugColor(this.message);
        return false;
      }
      return true;
    }
  }
}
