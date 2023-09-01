// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenuProp.ProgMenuPropCreate
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

namespace UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenuProp
{
  public class ProgMenuPropCreate : TProgMenuProp, ICreateTable
  {
    private int _PropCode;

    private bool InitTableBizBOCode(long pSiteID) => this.InitTableBizBOStore(pSiteID) && this.InitTableBizBOEmployee(pSiteID) && this.InitTableBizBOMaker(pSiteID) && this.InitTableBizBOBrand(pSiteID);

    private bool InitTableBizBOStore(long pSiteID)
    {
      int num1 = 0;
      TProgMenuProp pData1 = this.OleDB.Create<TProgMenuProp>();
      pData1.pmp_SiteID = pSiteID;
      pData1.pmp_ProgKind = 26;
      int num2;
      TProgMenuProp pData2 = this.InitTableBizSMLv1(pData1, this._PropCode++, num2 = num1 + 1, TableCodeType.StoreInfo.ToDescription(), 3, "UniBizBO.ViewModels.Part.Parent.TabParentPartVM", TableCodeType.StoreInfo.ToDescription());
      if (!this.OleDB.Execute(pData2.InsertQuery()))
        return false;
      int num3;
      TProgMenuProp pData3 = this.InitTableBizSMLv2(pData2, this._PropCode++, num3 = num2 + 1, "등록정보", 3, "UniBizBO.ViewModels.Part.Main.Code.Store.PageStoreMPartVM", "등록정보 [" + TableCodeType.StoreInfo.ToDescription() + "]");
      if (!this.OleDB.Execute(pData3.InsertQuery()))
        return false;
      int num4;
      TProgMenuProp pData4 = this.InitTableBizSMLv2(pData3, this._PropCode++, num4 = num3 + 1, "변경로그", 3, "UniBizBO.ViewModels.Part.Sub.DataModLogPartVM", "사용자 변경로그([" + TableCodeType.StoreInfo.ToDescription() + "]) 조회");
      if (!this.OleDB.Execute(pData4.InsertQuery()))
        return false;
      int num5;
      TProgMenuProp pData5 = this.InitTableBizSMLv1(pData4, this._PropCode++, num5 = num4 + 1, TableCodeType.StoreGroupHeader.ToDescription(), 4, "UniBizBO.ViewModels.Part.Parent.TabParentPartVM", TableCodeType.StoreGroupHeader.ToDescription());
      if (!this.OleDB.Execute(pData5.InsertQuery()))
        return false;
      int num6;
      TProgMenuProp pData6 = this.InitTableBizSMLv2(pData5, this._PropCode++, num6 = num5 + 1, "등록정보", 4, "UniBizBO.ViewModels.Part.Main.Code.Store.PageStoreGroupMPartVM", "등록정보 [" + TableCodeType.StoreGroupHeader.ToDescription() + "]");
      int num7;
      return this.OleDB.Execute(pData6.InsertQuery()) && this.OleDB.Execute(this.InitTableBizSMLv2(pData6, this._PropCode++, num7 = num6 + 1, "변경로그", 4, "UniBizBO.ViewModels.Part.Sub.DataModLogPartVM", "사용자 변경로그([" + TableCodeType.StoreGroupHeader.ToDescription() + "]) 조회").InsertQuery());
    }

    private bool InitTableBizBOEmployee(long pSiteID)
    {
      int num1 = 0;
      TProgMenuProp pData1 = this.OleDB.Create<TProgMenuProp>();
      pData1.pmp_SiteID = pSiteID;
      pData1.pmp_ProgKind = 26;
      int num2;
      TProgMenuProp pData2 = this.InitTableBizSMLv1(pData1, this._PropCode++, num2 = num1 + 1, TableCodeType.Employee.ToDescription(), 6, "UniBizBO.ViewModels.Part.Parent.TabParentPartVM", TableCodeType.Employee.ToDescription());
      if (!this.OleDB.Execute(pData2.InsertQuery()))
        return false;
      int num3;
      TProgMenuProp pData3 = this.InitTableBizSMLv2(pData2, this._PropCode++, num3 = num2 + 1, "등록정보", 6, "UniBizBO.ViewModels.Part.Main.Code.Employee.PageEmployeeMPartVM", "등록정보 [" + TableCodeType.Employee.ToDescription() + "]");
      if (!this.OleDB.Execute(pData3.InsertQuery()))
        return false;
      int num4;
      TProgMenuProp pData4 = this.InitTableBizSMLv2(pData3, this._PropCode++, num4 = num3 + 1, "지점권한", 6, "UniBizBO.ViewModels.Part.Main.Code.Employee.PageAuthStoreMPartVM", "지점 권한 등록 변경");
      if (!this.OleDB.Execute(pData4.InsertQuery()))
        return false;
      int num5;
      TProgMenuProp pData5 = this.InitTableBizSMLv2(pData4, this._PropCode++, num5 = num4 + 1, "업체권한", 6, "UniBizBO.ViewModels.Part.Main.Code.Employee.PageAuthSupplierMPartVM", "업체 권한 등록 변경(SCM 포함)");
      if (!this.OleDB.Execute(pData5.InsertQuery()))
        return false;
      int num6;
      TProgMenuProp pData6 = this.InitTableBizSMLv2(pData5, this._PropCode++, num6 = num5 + 1, "업무권한", 6, "UniBizBO.ViewModels.Part.Main.Code.Employee.PageAuthMPartVM", "업무 권한 등록 변경");
      int num7;
      return this.OleDB.Execute(pData6.InsertQuery()) && this.OleDB.Execute(this.InitTableBizSMLv2(pData6, this._PropCode++, num7 = num6 + 1, "변경로그", 6, "UniBizBO.ViewModels.Part.Sub.DataModLogPartVM", "사용자 변경로그([" + TableCodeType.Employee.ToDescription() + "]) 조회").InsertQuery());
    }

    private bool InitTableBizBOMaker(long pSiteID)
    {
      int num1 = 0;
      TProgMenuProp pData1 = this.OleDB.Create<TProgMenuProp>();
      pData1.pmp_SiteID = pSiteID;
      pData1.pmp_ProgKind = 26;
      int num2;
      TProgMenuProp pData2 = this.InitTableBizSMLv1(pData1, this._PropCode++, num2 = num1 + 1, TableCodeType.Maker.ToDescription(), 16, "UniBizBO.ViewModels.Part.Parent.TabParentPartVM", TableCodeType.Maker.ToDescription());
      if (!this.OleDB.Execute(pData2.InsertQuery()))
        return false;
      int num3;
      TProgMenuProp pData3 = this.InitTableBizSMLv2(pData2, this._PropCode++, num3 = num2 + 1, "등록정보", 16, "UniBizBO.ViewModels.Part.Main.Code.Maker.PageMakerMPartVM", "등록정보 [" + TableCodeType.Maker.ToDescription() + "]");
      if (!this.OleDB.Execute(pData3.InsertQuery()))
        return false;
      int num4;
      TProgMenuProp pData4 = this.InitTableBizSMLv2(pData3, this._PropCode++, num4 = num3 + 1, "상품등록건수", 16, "UniBizBO.ViewModels.Part.Sub.Category.GoodsCountByCategoryPartVM", "분류별 상품등록 건수");
      if (!this.OleDB.Execute(pData4.InsertQuery()))
        return false;
      int num5;
      TProgMenuProp pData5 = this.InitTableBizSMLv2(pData4, this._PropCode++, num5 = num4 + 1, "일자별판매", 16, "UniBizBO.ViewModels.Part.Sub.Sales.DaySalesVerticalPartVM", "일자별 판매 현황");
      int num6;
      return this.OleDB.Execute(pData5.InsertQuery()) && this.OleDB.Execute(this.InitTableBizSMLv2(pData5, this._PropCode++, num6 = num5 + 1, "변경로그", 16, "UniBizBO.ViewModels.Part.Sub.DataModLogPartVM", "사용자 변경로그([" + TableCodeType.Maker.ToDescription() + "]) 조회").InsertQuery());
    }

    private bool InitTableBizBOBrand(long pSiteID)
    {
      int num1 = 0;
      TProgMenuProp pData1 = this.OleDB.Create<TProgMenuProp>();
      pData1.pmp_SiteID = pSiteID;
      pData1.pmp_ProgKind = 26;
      int num2;
      TProgMenuProp pData2 = this.InitTableBizSMLv1(pData1, this._PropCode++, num2 = num1 + 1, TableCodeType.Brand.ToDescription(), 33, "UniBizBO.ViewModels.Part.Parent.TabParentPartVM", TableCodeType.Brand.ToDescription());
      if (!this.OleDB.Execute(pData2.InsertQuery()))
        return false;
      int num3;
      TProgMenuProp pData3 = this.InitTableBizSMLv2(pData2, this._PropCode++, num3 = num2 + 1, "등록정보", 33, "UniBizBO.ViewModels.Part.Main.Code.Brand.PageBrandMPartVM", "등록정보 [" + TableCodeType.Brand.ToDescription() + "]");
      if (!this.OleDB.Execute(pData3.InsertQuery()))
        return false;
      int num4;
      TProgMenuProp pData4 = this.InitTableBizSMLv2(pData3, this._PropCode++, num4 = num3 + 1, "상품등록건수", 33, "UniBizBO.ViewModels.Part.Sub.Category.GoodsCountByCategoryPartVM", "분류별 상품등록 건수");
      if (!this.OleDB.Execute(pData4.InsertQuery()))
        return false;
      int num5;
      TProgMenuProp pData5 = this.InitTableBizSMLv2(pData4, this._PropCode++, num5 = num4 + 1, "일자별판매", 33, "UniBizBO.ViewModels.Part.Sub.Sales.DaySalesVerticalPartVM", "일자별 판매 현황");
      int num6;
      return this.OleDB.Execute(pData5.InsertQuery()) && this.OleDB.Execute(this.InitTableBizSMLv2(pData5, this._PropCode++, num6 = num5 + 1, "변경로그", 33, "UniBizBO.ViewModels.Part.Sub.DataModLogPartVM", "사용자 변경로그([" + TableCodeType.Brand.ToDescription() + "]) 조회").InsertQuery());
    }

    private bool InitTableBizBO(long pSiteID) => this.InitTableBizBOCode(pSiteID) && this.InitTableBizBOSystem(pSiteID);

    private TProgMenuProp InitTableBizBOLv1(
      TProgMenuProp pData,
      int p_pmp_PropCode,
      int p_pmp_SortNo,
      string p_pmp_PropName,
      int p_pmp_TableID,
      string p_pmp_ProgID,
      string p_pmp_ProgTitle,
      string p_pmp_IconUrl = null)
    {
      pData.pmp_PropCode = p_pmp_PropCode;
      pData.pmp_SortNo = p_pmp_SortNo;
      pData.pmp_PropName = p_pmp_PropName;
      pData.pmp_TableID = p_pmp_TableID;
      pData.pmp_ProgID = p_pmp_ProgID;
      pData.pmp_ProgTitle = p_pmp_ProgTitle;
      pData.pmp_PropType = 1;
      pData.pmp_PropDepth = 1;
      return pData;
    }

    private TProgMenuProp InitTableBizBOLv2(
      TProgMenuProp pData,
      int p_pmp_PropCode,
      int p_pmp_SortNo,
      string p_pmp_PropName,
      int p_pmp_TableID,
      string p_pmp_ProgID,
      string p_pmp_ProgTitle,
      string p_pmp_IconUrl = null)
    {
      pData.pmp_PropCode = p_pmp_PropCode;
      pData.pmp_SortNo = p_pmp_SortNo;
      pData.pmp_PropName = p_pmp_PropName;
      pData.pmp_TableID = p_pmp_TableID;
      pData.pmp_ProgID = p_pmp_ProgID;
      pData.pmp_ProgTitle = p_pmp_ProgTitle;
      pData.pmp_PropType = 2;
      pData.pmp_PropDepth = 2;
      return pData;
    }

    private bool InitTableBizBOSystem(long pSiteID) => this.InitTableBizBOOuterConnAuth(pSiteID) && this.InitTableBizBOCommCode(pSiteID) && this.InitTableBizBOProgMenu(pSiteID) && this.InitTableBizBOProgMenuProp(pSiteID) && this.InitTableBizBOProgOption(pSiteID);

    private bool InitTableBizBOOuterConnAuth(long pSiteID)
    {
      int num1 = 0;
      TProgMenuProp pData1 = this.OleDB.Create<TProgMenuProp>();
      pData1.pmp_SiteID = pSiteID;
      pData1.pmp_ProgKind = 26;
      int num2;
      TProgMenuProp pData2 = this.InitTableBizSMLv1(pData1, this._PropCode++, num2 = num1 + 1, TableCodeType.OuterConnAuth.ToDescription(), 14, "UniBizBO.ViewModels.Part.Parent.TabParentPartVM", TableCodeType.OuterConnAuth.ToDescription());
      if (!this.OleDB.Execute(pData2.InsertQuery()))
        return false;
      int num3;
      TProgMenuProp pData3 = this.InitTableBizSMLv2(pData2, this._PropCode++, num3 = num2 + 1, "등록정보", 14, "UniBizBO.ViewModels.Part.Main.Systems.PageProgOuterConnAuthMPartVM", "등록정보 [" + TableCodeType.OuterConnAuth.ToDescription() + "]");
      int num4;
      return this.OleDB.Execute(pData3.InsertQuery()) && this.OleDB.Execute(this.InitTableBizSMLv2(pData3, this._PropCode++, num4 = num3 + 1, "변경로그", 14, "UniBizBO.ViewModels.Part.Sub.DataModLogPartVM", "사용자 변경로그([" + TableCodeType.OuterConnAuth.ToDescription() + "]) 조회").InsertQuery());
    }

    private bool InitTableBizBOCommCode(long pSiteID)
    {
      int num1 = 0;
      TProgMenuProp pData1 = this.OleDB.Create<TProgMenuProp>();
      pData1.pmp_SiteID = pSiteID;
      pData1.pmp_ProgKind = 26;
      int num2;
      TProgMenuProp pData2 = this.InitTableBizSMLv1(pData1, this._PropCode++, num2 = num1 + 1, TableCodeType.CommonCode.ToDescription(), 2, "UniBizBO.ViewModels.Part.Parent.TabParentPartVM", TableCodeType.CommonCode.ToDescription());
      if (!this.OleDB.Execute(pData2.InsertQuery()))
        return false;
      int num3;
      TProgMenuProp pData3 = this.InitTableBizSMLv2(pData2, this._PropCode++, num3 = num2 + 1, "등록정보", 2, "UniBizBO.ViewModels.Part.Main.Systems.PageCommonCodeMPartVM", "등록정보 [" + TableCodeType.CommonCode.ToDescription() + "]");
      int num4;
      return this.OleDB.Execute(pData3.InsertQuery()) && this.OleDB.Execute(this.InitTableBizSMLv2(pData3, this._PropCode++, num4 = num3 + 1, "변경로그", 2, "UniBizBO.ViewModels.Part.Sub.DataModLogPartVM", "사용자 변경로그([" + TableCodeType.CommonCode.ToDescription() + "]) 조회").InsertQuery());
    }

    private bool InitTableBizBOProgMenu(long pSiteID)
    {
      int num1 = 0;
      TProgMenuProp pData1 = this.OleDB.Create<TProgMenuProp>();
      pData1.pmp_SiteID = pSiteID;
      pData1.pmp_ProgKind = 26;
      int num2;
      TProgMenuProp pData2 = this.InitTableBizSMLv1(pData1, this._PropCode++, num2 = num1 + 1, TableCodeType.ProgMenu.ToDescription(), 9, "UniBizBO.ViewModels.Part.Parent.TabParentPartVM", TableCodeType.ProgMenu.ToDescription());
      if (!this.OleDB.Execute(pData2.InsertQuery()))
        return false;
      int num3;
      TProgMenuProp pData3 = this.InitTableBizSMLv2(pData2, this._PropCode++, num3 = num2 + 1, "등록정보", 9, "UniBizBO.ViewModels.Part.Main.Systems.PageProgMenuMPartVM", "등록정보 [" + TableCodeType.ProgMenu.ToDescription() + "]");
      int num4;
      return this.OleDB.Execute(pData3.InsertQuery()) && this.OleDB.Execute(this.InitTableBizSMLv2(pData3, this._PropCode++, num4 = num3 + 1, "변경로그", 9, "UniBizBO.ViewModels.Part.Sub.DataModLogPartVM", "사용자 변경로그([" + TableCodeType.ProgMenu.ToDescription() + "]) 조회").InsertQuery());
    }

    private bool InitTableBizBOProgMenuProp(long pSiteID)
    {
      int num1 = 0;
      TProgMenuProp pData1 = this.OleDB.Create<TProgMenuProp>();
      pData1.pmp_SiteID = pSiteID;
      pData1.pmp_ProgKind = 26;
      int num2;
      TProgMenuProp pData2 = this.InitTableBizSMLv1(pData1, this._PropCode++, num2 = num1 + 1, TableCodeType.ProgMenuProp.ToDescription(), 11, "UniBizBO.ViewModels.Part.Parent.TabParentPartVM", TableCodeType.ProgMenuProp.ToDescription());
      if (!this.OleDB.Execute(pData2.InsertQuery()))
        return false;
      int num3;
      TProgMenuProp pData3 = this.InitTableBizSMLv2(pData2, this._PropCode++, num3 = num2 + 1, "등록정보", 11, "UniBizBO.ViewModels.Part.Main.Systems.PageProgMenuPropMPartVM", "등록정보 [" + TableCodeType.ProgMenuProp.ToDescription() + "]");
      int num4;
      return this.OleDB.Execute(pData3.InsertQuery()) && this.OleDB.Execute(this.InitTableBizSMLv2(pData3, this._PropCode++, num4 = num3 + 1, "변경로그", 11, "UniBizBO.ViewModels.Part.Sub.DataModLogPartVM", "사용자 변경로그([" + TableCodeType.ProgMenuProp.ToDescription() + "]) 조회").InsertQuery());
    }

    private bool InitTableBizBOProgOption(long pSiteID)
    {
      int num1 = 0;
      TProgMenuProp pData1 = this.OleDB.Create<TProgMenuProp>();
      pData1.pmp_SiteID = pSiteID;
      pData1.pmp_ProgKind = 26;
      int num2;
      TProgMenuProp pData2 = this.InitTableBizSMLv1(pData1, this._PropCode++, num2 = num1 + 1, TableCodeType.ProgOption.ToDescription(), 46, "UniBizBO.ViewModels.Part.Parent.TabParentPartVM", TableCodeType.ProgOption.ToDescription());
      if (!this.OleDB.Execute(pData2.InsertQuery()))
        return false;
      int num3;
      TProgMenuProp pData3 = this.InitTableBizSMLv2(pData2, this._PropCode++, num3 = num2 + 1, "등록정보", 46, "UniBizBO.ViewModels.Part.Main.Systems.PageProgOptionMPartVM", "등록정보 [" + TableCodeType.ProgOption.ToDescription() + "]");
      int num4;
      return this.OleDB.Execute(pData3.InsertQuery()) && this.OleDB.Execute(this.InitTableBizSMLv2(pData3, this._PropCode++, num4 = num3 + 1, "변경로그", 46, "UniBizBO.ViewModels.Part.Sub.DataModLogPartVM", "사용자 변경로그([" + TableCodeType.ProgOption.ToDescription() + "]) 조회").InsertQuery());
    }

    private bool InitTableBizSMCode(long pSiteID) => this.InitTableBizSMStore(pSiteID) && this.InitTableBizSMEmployee(pSiteID) && this.InitTableBizSMPayContion(pSiteID) && this.InitTableBizSMPaymentMonth(pSiteID) && this.InitTableBizSMSupplier(pSiteID) && this.InitTableBizSMDept(pSiteID) && this.InitTableBizSMCategory(pSiteID) && this.InitTableBizSMMaker(pSiteID) && this.InitTableBizSMBrand(pSiteID) && this.InitTableBizSMGoods(pSiteID);

    private bool InitTableBizSMStore(long pSiteID)
    {
      int num1 = 0;
      TProgMenuProp pData1 = this.OleDB.Create<TProgMenuProp>();
      pData1.pmp_SiteID = pSiteID;
      pData1.pmp_ProgKind = 5;
      int num2;
      TProgMenuProp pData2 = this.InitTableBizSMLv1(pData1, this._PropCode++, num2 = num1 + 1, TableCodeType.StoreInfo.ToDescription(), 3, "UniBizSM.Client.Core.ViewModels.Part.Parent.TabParentPartVM", TableCodeType.StoreInfo.ToDescription());
      if (!this.OleDB.Execute(pData2.InsertQuery()))
        return false;
      int num3;
      TProgMenuProp pData3 = this.InitTableBizSMLv2(pData2, this._PropCode++, num3 = num2 + 1, "등록정보", 3, "UniBizSM.Client.Core.ViewModels.Part.Main.Code.Store.PageStoreMPartVM", "등록정보 [" + TableCodeType.StoreInfo.ToDescription() + "]");
      if (!this.OleDB.Execute(pData3.InsertQuery()))
        return false;
      int num4;
      TProgMenuProp pData4 = this.InitTableBizSMLv2(pData3, this._PropCode++, num4 = num3 + 1, "변경로그", 3, "UniBizSM.Client.Core.ViewModels.Part.Sub.DataModLogPartVM", "사용자 변경로그([" + TableCodeType.StoreInfo.ToDescription() + "]) 조회");
      if (!this.OleDB.Execute(pData4.InsertQuery()))
        return false;
      int num5;
      TProgMenuProp pData5 = this.InitTableBizSMLv1(pData4, this._PropCode++, num5 = num4 + 1, TableCodeType.StoreGroupHeader.ToDescription(), 4, "UniBizSM.Client.Core.ViewModels.Part.Parent.TabParentPartVM", TableCodeType.StoreGroupHeader.ToDescription());
      if (!this.OleDB.Execute(pData5.InsertQuery()))
        return false;
      int num6;
      TProgMenuProp pData6 = this.InitTableBizSMLv2(pData5, this._PropCode++, num6 = num5 + 1, "등록정보", 4, "UniBizSM.Client.Core.ViewModels.Part.Main.Code.Store.PageStoreGroupMPartVM", "등록정보 [" + TableCodeType.StoreGroupHeader.ToDescription() + "]");
      int num7;
      return this.OleDB.Execute(pData6.InsertQuery()) && this.OleDB.Execute(this.InitTableBizSMLv2(pData6, this._PropCode++, num7 = num6 + 1, "변경로그", 4, "UniBizSM.Client.Core.ViewModels.Part.Sub.DataModLogPartVM", "사용자 변경로그([" + TableCodeType.StoreGroupHeader.ToDescription() + "]) 조회").InsertQuery());
    }

    private bool InitTableBizSMEmployee(long pSiteID)
    {
      int num1 = 0;
      TProgMenuProp pData1 = this.OleDB.Create<TProgMenuProp>();
      pData1.pmp_SiteID = pSiteID;
      pData1.pmp_ProgKind = 5;
      int num2;
      TProgMenuProp pData2 = this.InitTableBizSMLv1(pData1, this._PropCode++, num2 = num1 + 1, TableCodeType.Employee.ToDescription(), 6, "UniBizSM.Client.Core.ViewModels.Part.Parent.TabParentPartVM", TableCodeType.Employee.ToDescription());
      if (!this.OleDB.Execute(pData2.InsertQuery()))
        return false;
      int num3;
      TProgMenuProp pData3 = this.InitTableBizSMLv2(pData2, this._PropCode++, num3 = num2 + 1, "등록정보", 6, "UniBizSM.Client.Core.ViewModels.Part.Main.Code.Employee.PageEmployeeMPartVM", "등록정보 [" + TableCodeType.Employee.ToDescription() + "]");
      if (!this.OleDB.Execute(pData3.InsertQuery()))
        return false;
      int num4;
      TProgMenuProp pData4 = this.InitTableBizSMLv2(pData3, this._PropCode++, num4 = num3 + 1, "지점권한", 6, "UniBizSM.Client.Core.ViewModels.Part.Main.Code.Employee.PageAuthStoreMPartVM", "지점 권한 등록 변경");
      if (!this.OleDB.Execute(pData4.InsertQuery()))
        return false;
      int num5;
      TProgMenuProp pData5 = this.InitTableBizSMLv2(pData4, this._PropCode++, num5 = num4 + 1, "업체권한", 6, "UniBizSM.Client.Core.ViewModels.Part.Main.Code.Employee.PageAuthSupplierMPartVM", "업체 권한 등록 변경(SCM 포함)");
      if (!this.OleDB.Execute(pData5.InsertQuery()))
        return false;
      int num6;
      TProgMenuProp pData6 = this.InitTableBizSMLv2(pData5, this._PropCode++, num6 = num5 + 1, "업무권한", 6, "UniBizSM.Client.Core.ViewModels.Part.Main.Code.Employee.PageAuthMPartVM", "업무 권한 등록 변경");
      int num7;
      return this.OleDB.Execute(pData6.InsertQuery()) && this.OleDB.Execute(this.InitTableBizSMLv2(pData6, this._PropCode++, num7 = num6 + 1, "변경로그", 6, "UniBizSM.Client.Core.ViewModels.Part.Sub.DataModLogPartVM", "사용자 변경로그([" + TableCodeType.Employee.ToDescription() + "]) 조회").InsertQuery());
    }

    private bool InitTableBizSMPayContion(long pSiteID)
    {
      int num1 = 0;
      TProgMenuProp pData1 = this.OleDB.Create<TProgMenuProp>();
      pData1.pmp_SiteID = pSiteID;
      pData1.pmp_ProgKind = 5;
      int num2;
      TProgMenuProp pData2 = this.InitTableBizSMLv1(pData1, this._PropCode++, num2 = num1 + 1, TableCodeType.PayContion.ToDescription(), 21, "UniBizSM.Client.Core.ViewModels.Part.Parent.TabParentPartVM", TableCodeType.PayContion.ToDescription());
      if (!this.OleDB.Execute(pData2.InsertQuery()))
        return false;
      int num3;
      TProgMenuProp pData3 = this.InitTableBizSMLv2(pData2, this._PropCode++, num3 = num2 + 1, "등록정보", 21, "UniBizSM.Client.Core.ViewModels.Part.Main.PayContion.PagePayContionMPartVM", "등록정보 [" + TableCodeType.PayContion.ToDescription() + "]");
      int num4;
      return this.OleDB.Execute(pData3.InsertQuery()) && this.OleDB.Execute(this.InitTableBizSMLv2(pData3, this._PropCode++, num4 = num3 + 1, "변경로그", 21, "UniBizSM.Client.Core.ViewModels.Part.Sub.DataModLogPartVM", "사용자 변경로그([" + TableCodeType.PayContion.ToDescription() + "]) 조회").InsertQuery());
    }

    private bool InitTableBizSMPaymentMonth(long pSiteID)
    {
      int num1 = 0;
      TProgMenuProp pData1 = this.OleDB.Create<TProgMenuProp>();
      pData1.pmp_SiteID = pSiteID;
      pData1.pmp_ProgKind = 5;
      int num2;
      TProgMenuProp pData2 = this.InitTableBizSMLv1(pData1, this._PropCode++, num2 = num1 + 1, TableCodeType.PaymentMonth.ToDescription(), 72, "UniBizSM.Client.Core.ViewModels.Part.Parent.TabParentPartVM", TableCodeType.PaymentMonth.ToDescription());
      if (!this.OleDB.Execute(pData2.InsertQuery()))
        return false;
      int num3;
      TProgMenuProp pData3 = this.InitTableBizSMLv2(pData2, this._PropCode++, num3 = num2 + 1, "자동", 72, "UniBizSM.Client.Core.ViewModels.Part.Main.Payment.PagePaymentAutoMPartVM", "결제(자동) 결산 [" + TableCodeType.PaymentMonth.ToDescription() + "]");
      if (!this.OleDB.Execute(pData3.InsertQuery()))
        return false;
      int num4;
      TProgMenuProp pData4 = this.InitTableBizSMLv2(pData3, this._PropCode++, num4 = num3 + 1, "수시", 72, "UniBizSM.Client.Core.ViewModels.Part.Main.Payment.PagePaymentManualMPartVM", "결제(수시) 결산 [" + TableCodeType.PaymentMonth.ToDescription() + "]");
      int num5;
      return this.OleDB.Execute(pData4.InsertQuery()) && this.OleDB.Execute(this.InitTableBizSMLv2(pData4, this._PropCode++, num5 = num4 + 1, "변경로그", 72, "UniBizSM.Client.Core.ViewModels.Part.Sub.DataModLogPartVM", "사용자 변경로그([" + TableCodeType.PaymentMonth.ToDescription() + "]) 조회").InsertQuery());
    }

    private bool InitTableBizSMSupplier(long pSiteID)
    {
      int num1 = 0;
      TProgMenuProp pData1 = this.OleDB.Create<TProgMenuProp>();
      pData1.pmp_SiteID = pSiteID;
      pData1.pmp_ProgKind = 5;
      int num2;
      TProgMenuProp pData2 = this.InitTableBizSMLv1(pData1, this._PropCode++, num2 = num1 + 1, TableCodeType.Supplier.ToDescription(), 22, "UniBizSM.Client.Core.ViewModels.Part.Parent.TabParentPartVM", TableCodeType.Supplier.ToDescription());
      if (!this.OleDB.Execute(pData2.InsertQuery()))
        return false;
      int num3;
      TProgMenuProp pData3 = this.InitTableBizSMLv2(pData2, this._PropCode++, num3 = num2 + 1, "등록정보", 22, "UniBizSM.Client.Core.ViewModels.Part.Main.Code.Supplier.PageSupplierMPartVM", "등록정보 [" + TableCodeType.Supplier.ToDescription() + "]");
      if (!this.OleDB.Execute(pData3.InsertQuery()))
        return false;
      int num4;
      TProgMenuProp pData4 = this.InitTableBizSMLv2(pData3, this._PropCode++, num4 = num3 + 1, "결제조건", 22, "UniBizSM.Client.Core.ViewModels.Part.Main.Code.Supplier.PagePayContionMPartVM", "결제 조건 등록 현황");
      if (!this.OleDB.Execute(pData4.InsertQuery()))
        return false;
      int num5;
      TProgMenuProp pData5 = this.InitTableBizSMLv2(pData4, this._PropCode++, num5 = num4 + 1, "성과장려금", 22, "UniBizSM.Client.Core.ViewModels.Part.Main.Code.Supplier.PageRebateContionMPartVM", "성과 장려금 등록 현황");
      if (!this.OleDB.Execute(pData5.InsertQuery()))
        return false;
      int num6;
      TProgMenuProp pData6 = this.InitTableBizSMLv2(pData5, this._PropCode++, num6 = num5 + 1, "자동발주", 22, "UniBizSM.Client.Core.ViewModels.Part.Main.Code.Supplier.PageAutoOrderConitionMPartVM", "자동 발주 등록 현황");
      if (!this.OleDB.Execute(pData6.InsertQuery()))
        return false;
      int num7;
      TProgMenuProp pData7 = this.InitTableBizSMLv2(pData6, this._PropCode++, num7 = num6 + 1, "상품등록건수", 22, "UniBizSM.Client.Core.ViewModels.Part.Sub.Category.GoodsCountByCategoryPartVM", "분류별 상품등록 건수");
      if (!this.OleDB.Execute(pData7.InsertQuery()))
        return false;
      int num8;
      TProgMenuProp pData8 = this.InitTableBizSMLv2(pData7, this._PropCode++, num8 = num7 + 1, "일자별판매", 22, "UniBizSM.Client.Core.ViewModels.Part.Sub.Sales.DaySalesVerticalPartVM", "일자별 판매 현황");
      int num9;
      return this.OleDB.Execute(pData8.InsertQuery()) && this.OleDB.Execute(this.InitTableBizSMLv2(pData8, this._PropCode++, num9 = num8 + 1, "변경로그", 22, "UniBizSM.Client.Core.ViewModels.Part.Sub.DataModLogPartVM", "사용자 변경로그([" + TableCodeType.Supplier.ToDescription() + "]) 조회").InsertQuery());
    }

    private bool InitTableBizSMDept(long pSiteID)
    {
      int num1 = 0;
      TProgMenuProp pData1 = this.OleDB.Create<TProgMenuProp>();
      pData1.pmp_SiteID = pSiteID;
      pData1.pmp_ProgKind = 5;
      int num2;
      TProgMenuProp pData2 = this.InitTableBizSMLv1(pData1, this._PropCode++, num2 = num1 + 1, TableCodeType.Dept.ToDescription(), 31, "UniBizSM.Client.Core.ViewModels.Part.Parent.TabParentPartVM", TableCodeType.Dept.ToDescription());
      if (!this.OleDB.Execute(pData2.InsertQuery()))
        return false;
      int num3;
      TProgMenuProp pData3 = this.InitTableBizSMLv2(pData2, this._PropCode++, num3 = num2 + 1, "등록정보", 31, "UniBizSM.Client.Core.ViewModels.Part.Main.PageDeptMPartVM", "등록정보 [" + TableCodeType.Dept.ToDescription() + "]");
      int num4;
      return this.OleDB.Execute(pData3.InsertQuery()) && this.OleDB.Execute(this.InitTableBizSMLv2(pData3, this._PropCode++, num4 = num3 + 1, "변경로그", 16, "UniBizSM.Client.Core.ViewModels.Part.Sub.DataModLogPartVM", "사용자 변경로그([" + TableCodeType.Maker.ToDescription() + "]) 조회").InsertQuery());
    }

    private bool InitTableBizSMCategory(long pSiteID)
    {
      int num1 = 0;
      TProgMenuProp pData1 = this.OleDB.Create<TProgMenuProp>();
      pData1.pmp_SiteID = pSiteID;
      pData1.pmp_ProgKind = 5;
      int num2;
      TProgMenuProp pData2 = this.InitTableBizSMLv1(pData1, this._PropCode++, num2 = num1 + 1, TableCodeType.Category.ToDescription(), 34, "UniBizSM.Client.Core.ViewModels.Part.Parent.TabParentPartVM", TableCodeType.Category.ToDescription());
      if (!this.OleDB.Execute(pData2.InsertQuery()))
        return false;
      int num3;
      TProgMenuProp pData3 = this.InitTableBizSMLv2(pData2, this._PropCode++, num3 = num2 + 1, "등록정보", 34, "UniBizSM.Client.Core.ViewModels.Part.Main.PageCategoryMPartVM", "등록정보 [" + TableCodeType.Dept.ToDescription() + "]");
      if (!this.OleDB.Execute(pData3.InsertQuery()))
        return false;
      int num4;
      TProgMenuProp pData4 = this.InitTableBizSMLv2(pData3, this._PropCode++, num4 = num3 + 1, "상품등록건수", 34, "UniBizSM.Client.Core.ViewModels.Part.Sub.Category.GoodsCountByCategoryPartVM", "분류별 상품등록 건수");
      if (!this.OleDB.Execute(pData4.InsertQuery()))
        return false;
      int num5;
      TProgMenuProp pData5 = this.InitTableBizSMLv2(pData4, this._PropCode++, num5 = num4 + 1, "일자별판매", 34, "UniBizSM.Client.Core.ViewModels.Part.Sub.Sales.DaySalesVerticalPartVM", "일자별 판매 현황");
      int num6;
      return this.OleDB.Execute(pData5.InsertQuery()) && this.OleDB.Execute(this.InitTableBizSMLv2(pData5, this._PropCode++, num6 = num5 + 1, "변경로그", 34, "UniBizSM.Client.Core.ViewModels.Part.Sub.DataModLogPartVM", "사용자 변경로그([" + TableCodeType.Category.ToDescription() + "]) 조회").InsertQuery());
    }

    private bool InitTableBizSMMaker(long pSiteID)
    {
      int num1 = 0;
      TProgMenuProp pData1 = this.OleDB.Create<TProgMenuProp>();
      pData1.pmp_SiteID = pSiteID;
      pData1.pmp_ProgKind = 5;
      int num2;
      TProgMenuProp pData2 = this.InitTableBizSMLv1(pData1, this._PropCode++, num2 = num1 + 1, TableCodeType.Maker.ToDescription(), 16, "UniBizSM.Client.Core.ViewModels.Part.Parent.TabParentPartVM", TableCodeType.Maker.ToDescription());
      if (!this.OleDB.Execute(pData2.InsertQuery()))
        return false;
      int num3;
      TProgMenuProp pData3 = this.InitTableBizSMLv2(pData2, this._PropCode++, num3 = num2 + 1, "등록정보", 16, "UniBizSM.Client.Core.ViewModels.Part.Main.PageMakerMPartVM", "등록정보 [" + TableCodeType.Maker.ToDescription() + "]");
      if (!this.OleDB.Execute(pData3.InsertQuery()))
        return false;
      int num4;
      TProgMenuProp pData4 = this.InitTableBizSMLv2(pData3, this._PropCode++, num4 = num3 + 1, "상품등록건수", 16, "UniBizSM.Client.Core.ViewModels.Part.Sub.Category.GoodsCountByCategoryPartVM", "분류별 상품등록 건수");
      if (!this.OleDB.Execute(pData4.InsertQuery()))
        return false;
      int num5;
      TProgMenuProp pData5 = this.InitTableBizSMLv2(pData4, this._PropCode++, num5 = num4 + 1, "일자별판매", 16, "UniBizSM.Client.Core.ViewModels.Part.Sub.Sales.DaySalesVerticalPartVM", "일자별 판매 현황");
      int num6;
      return this.OleDB.Execute(pData5.InsertQuery()) && this.OleDB.Execute(this.InitTableBizSMLv2(pData5, this._PropCode++, num6 = num5 + 1, "변경로그", 16, "UniBizSM.Client.Core.ViewModels.Part.Sub.DataModLogPartVM", "사용자 변경로그([" + TableCodeType.Maker.ToDescription() + "]) 조회").InsertQuery());
    }

    private bool InitTableBizSMBrand(long pSiteID)
    {
      int num1 = 0;
      TProgMenuProp pData1 = this.OleDB.Create<TProgMenuProp>();
      pData1.pmp_SiteID = pSiteID;
      pData1.pmp_ProgKind = 5;
      int num2;
      TProgMenuProp pData2 = this.InitTableBizSMLv1(pData1, this._PropCode++, num2 = num1 + 1, TableCodeType.Brand.ToDescription(), 33, "UniBizSM.Client.Core.ViewModels.Part.Parent.TabParentPartVM", TableCodeType.Brand.ToDescription());
      if (!this.OleDB.Execute(pData2.InsertQuery()))
        return false;
      int num3;
      TProgMenuProp pData3 = this.InitTableBizSMLv2(pData2, this._PropCode++, num3 = num2 + 1, "등록정보", 33, "UniBizSM.Client.Core.ViewModels.Part.Main.PageBrandMPartVM", "등록정보 [" + TableCodeType.Brand.ToDescription() + "]");
      if (!this.OleDB.Execute(pData3.InsertQuery()))
        return false;
      int num4;
      TProgMenuProp pData4 = this.InitTableBizSMLv2(pData3, this._PropCode++, num4 = num3 + 1, "상품등록건수", 33, "UniBizSM.Client.Core.ViewModels.Part.Sub.Category.GoodsCountByCategoryPartVM", "분류별 상품등록 건수");
      if (!this.OleDB.Execute(pData4.InsertQuery()))
        return false;
      int num5;
      TProgMenuProp pData5 = this.InitTableBizSMLv2(pData4, this._PropCode++, num5 = num4 + 1, "일자별판매", 33, "UniBizSM.Client.Core.ViewModels.Part.Sub.Sales.DaySalesVerticalPartVM", "일자별 판매 현황");
      int num6;
      return this.OleDB.Execute(pData5.InsertQuery()) && this.OleDB.Execute(this.InitTableBizSMLv2(pData5, this._PropCode++, num6 = num5 + 1, "변경로그", 33, "UniBizSM.Client.Core.ViewModels.Part.Sub.DataModLogPartVM", "사용자 변경로그([" + TableCodeType.Brand.ToDescription() + "]) 조회").InsertQuery());
    }

    private bool InitTableBizSMGoods(long pSiteID)
    {
      int num1 = 0;
      TProgMenuProp pData1 = this.OleDB.Create<TProgMenuProp>();
      pData1.pmp_SiteID = pSiteID;
      pData1.pmp_ProgKind = 5;
      int num2;
      TProgMenuProp pData2 = this.InitTableBizSMLv1(pData1, this._PropCode++, num2 = num1 + 1, TableCodeType.Goods.ToDescription(), 36, "UniBizSM.Client.Core.ViewModels.Part.Parent.TabParentPartVM", TableCodeType.Goods.ToDescription());
      if (!this.OleDB.Execute(pData2.InsertQuery()))
        return false;
      int num3;
      TProgMenuProp pData3 = this.InitTableBizSMLv2(pData2, this._PropCode++, num3 = num2 + 1, "등록정보", 36, "UniBizSM.Client.Core.ViewModels.Part.Main.Code.GoodsInfo.Goods.PageGoodsMPartVM", "등록정보 [" + TableCodeType.Goods.ToDescription() + "]");
      if (!this.OleDB.Execute(pData3.InsertQuery()))
        return false;
      int num4;
      TProgMenuProp pData4 = this.InitTableBizSMLv2(pData3, this._PropCode++, num4 = num3 + 1, "이력정보", 36, "UniBizSM.Client.Core.ViewModels.Part.Main.Code.GoodsInfo.Goods.PageGoodsHistoryMPartVM", "이력정보 [" + TableCodeType.GoodsHistory.ToDescription() + "]");
      if (!this.OleDB.Execute(pData4.InsertQuery()))
        return false;
      int num5;
      TProgMenuProp pData5 = this.InitTableBizSMLv2(pData4, this._PropCode++, num5 = num4 + 1, "이력변경", 36, "UniBizSM.Client.Core.ViewModels.Part.Main.Code.GoodsInfo.Goods.PageGoodsHistoryChangedMPartVM", TableCodeType.GoodsHistory.ToDescription() + " 변경");
      if (!this.OleDB.Execute(pData5.InsertQuery()))
        return false;
      int num6;
      TProgMenuProp pData6 = this.InitTableBizSMLv2(pData5, this._PropCode++, num6 = num5 + 1, "연계상품", 36, "UniBizSM.Client.Core.ViewModels.Part.Main.Code.GoodsInfo.Goods.PageGoodsPackMPartVM", TableCodeType.GoodsPack.ToDescription() ?? "");
      if (!this.OleDB.Execute(pData6.InsertQuery()))
        return false;
      int num7;
      TProgMenuProp pData7 = this.InitTableBizSMLv2(pData6, this._PropCode++, num7 = num6 + 1, "점별상품", 36, "UniBizSM.Client.Core.ViewModels.Part.Main.Code.GoodsInfo.Goods.PageGoodsStoreMPartVM", TableCodeType.GoodsStoreInfo.ToDescription() ?? "");
      if (!this.OleDB.Execute(pData7.InsertQuery()))
        return false;
      int num8;
      TProgMenuProp pData8 = this.InitTableBizSMLv2(pData7, this._PropCode++, num8 = num7 + 1, "일자별판매", 36, "UniBizSM.Client.Core.ViewModels.Part.Sub.Sales.DaySalesVerticalPartVM", "일자별 판매 현황");
      if (!this.OleDB.Execute(pData8.InsertQuery()))
        return false;
      int num9;
      TProgMenuProp pData9 = this.InitTableBizSMLv2(pData8, this._PropCode++, num9 = num8 + 1, "일자별 재고", 36, "UniBizSM.Client.Core.ViewModels.Part.Main.Code.GoodsInfo.Goods.PageGoodsStockByDayMPartVM", "일자별 재고 현황");
      if (!this.OleDB.Execute(pData9.InsertQuery()))
        return false;
      int num10;
      TProgMenuProp pData10 = this.InitTableBizSMLv2(pData9, this._PropCode++, num10 = num9 + 1, "월별 재고", 36, "UniBizSM.Client.Core.ViewModels.Part.Main.Code.GoodsInfo.Goods.PageGoodsStockByMonthMPartVM", "월별 재고 현황");
      if (!this.OleDB.Execute(pData10.InsertQuery()))
        return false;
      int num11;
      TProgMenuProp pData11 = this.InitTableBizSMLv2(pData10, this._PropCode++, num11 = num10 + 1, "지점별 재고", 36, "UniBizSM.Client.Core.ViewModels.Part.Main.Code.GoodsInfo.Goods.PageGoodsStockByStoreMPartVM", "지점별 재고 현황");
      if (!this.OleDB.Execute(pData11.InsertQuery()))
        return false;
      int num12;
      TProgMenuProp pData12 = this.InitTableBizSMLv2(pData11, this._PropCode++, num12 = num11 + 1, "이미지", 36, "UniBizSM.Client.Core.ViewModels.Part.Main.Code.GoodsInfo.Goods.PageGoodsImageMPartVM", TableCodeType.GoodsImage.ToDescription() ?? "");
      int num13;
      return this.OleDB.Execute(pData12.InsertQuery()) && this.OleDB.Execute(this.InitTableBizSMLv2(pData12, this._PropCode++, num13 = num12 + 1, "변경로그", 36, "UniBizSM.Client.Core.ViewModels.Part.Sub.DataModLogPartVM", "사용자 변경로그([" + TableCodeType.Goods.ToDescription() + "]) 조회").InsertQuery());
    }

    private bool InitTableBizSM(long pSiteID) => this.InitTableBizSMCode(pSiteID) && this.InitTableBizSMSystem(pSiteID);

    private TProgMenuProp InitTableBizSMLv1(
      TProgMenuProp pData,
      int p_pmp_PropCode,
      int p_pmp_SortNo,
      string p_pmp_PropName,
      int p_pmp_TableID,
      string p_pmp_ProgID,
      string p_pmp_ProgTitle,
      string p_pmp_IconUrl = null)
    {
      pData.pmp_PropCode = p_pmp_PropCode;
      pData.pmp_SortNo = p_pmp_SortNo;
      pData.pmp_PropName = p_pmp_PropName;
      pData.pmp_TableID = p_pmp_TableID;
      pData.pmp_ProgID = p_pmp_ProgID;
      pData.pmp_ProgTitle = p_pmp_ProgTitle;
      pData.pmp_PropType = 1;
      pData.pmp_PropDepth = 1;
      return pData;
    }

    private TProgMenuProp InitTableBizSMLv2(
      TProgMenuProp pData,
      int p_pmp_PropCode,
      int p_pmp_SortNo,
      string p_pmp_PropName,
      int p_pmp_TableID,
      string p_pmp_ProgID,
      string p_pmp_ProgTitle,
      string p_pmp_IconUrl = null)
    {
      pData.pmp_PropCode = p_pmp_PropCode;
      pData.pmp_SortNo = p_pmp_SortNo;
      pData.pmp_PropName = p_pmp_PropName;
      pData.pmp_TableID = p_pmp_TableID;
      pData.pmp_ProgID = p_pmp_ProgID;
      pData.pmp_ProgTitle = p_pmp_ProgTitle;
      pData.pmp_PropType = 2;
      pData.pmp_PropDepth = 2;
      return pData;
    }

    private bool InitTableBizSMSystem(long pSiteID) => this.InitTableBizSMOuterConnAuth(pSiteID) && this.InitTableBizSMCommCode(pSiteID) && this.InitTableBizSMProgMenu(pSiteID) && this.InitTableBizSMProgMenuProp(pSiteID) && this.InitTableBizSMProgOption(pSiteID);

    private bool InitTableBizSMOuterConnAuth(long pSiteID)
    {
      int num1 = 0;
      TProgMenuProp pData1 = this.OleDB.Create<TProgMenuProp>();
      pData1.pmp_SiteID = pSiteID;
      pData1.pmp_ProgKind = 5;
      int num2;
      TProgMenuProp pData2 = this.InitTableBizSMLv1(pData1, this._PropCode++, num2 = num1 + 1, TableCodeType.OuterConnAuth.ToDescription(), 14, "UniBizSM.Client.Core.ViewModels.Part.Parent.TabParentPartVM", TableCodeType.OuterConnAuth.ToDescription());
      if (!this.OleDB.Execute(pData2.InsertQuery()))
        return false;
      int num3;
      TProgMenuProp pData3 = this.InitTableBizSMLv2(pData2, this._PropCode++, num3 = num2 + 1, "등록정보", 14, "UniBizSM.Client.Core.ViewModels.Part.Main.Systems.PageProgOuterConnAuthMPartVM", "등록정보 [" + TableCodeType.OuterConnAuth.ToDescription() + "]");
      int num4;
      return this.OleDB.Execute(pData3.InsertQuery()) && this.OleDB.Execute(this.InitTableBizSMLv2(pData3, this._PropCode++, num4 = num3 + 1, "변경로그", 14, "UniBizSM.Client.Core.ViewModels.Part.Sub.DataModLogPartVM", "사용자 변경로그([" + TableCodeType.OuterConnAuth.ToDescription() + "]) 조회").InsertQuery());
    }

    private bool InitTableBizSMCommCode(long pSiteID)
    {
      int num1 = 0;
      TProgMenuProp pData1 = this.OleDB.Create<TProgMenuProp>();
      pData1.pmp_SiteID = pSiteID;
      pData1.pmp_ProgKind = 5;
      int num2;
      TProgMenuProp pData2 = this.InitTableBizSMLv1(pData1, this._PropCode++, num2 = num1 + 1, TableCodeType.CommonCode.ToDescription(), 2, "UniBizSM.Client.Core.ViewModels.Part.Parent.TabParentPartVM", TableCodeType.CommonCode.ToDescription());
      if (!this.OleDB.Execute(pData2.InsertQuery()))
        return false;
      int num3;
      TProgMenuProp pData3 = this.InitTableBizSMLv2(pData2, this._PropCode++, num3 = num2 + 1, "등록정보", 2, "UniBizSM.Client.Core.ViewModels.Part.Main.Systems.PageCommonCodeMPartVM", "등록정보 [" + TableCodeType.CommonCode.ToDescription() + "]");
      int num4;
      return this.OleDB.Execute(pData3.InsertQuery()) && this.OleDB.Execute(this.InitTableBizSMLv2(pData3, this._PropCode++, num4 = num3 + 1, "변경로그", 2, "UniBizSM.Client.Core.ViewModels.Part.Sub.DataModLogPartVM", "사용자 변경로그([" + TableCodeType.CommonCode.ToDescription() + "]) 조회").InsertQuery());
    }

    private bool InitTableBizSMProgMenu(long pSiteID)
    {
      int num1 = 0;
      TProgMenuProp pData1 = this.OleDB.Create<TProgMenuProp>();
      pData1.pmp_SiteID = pSiteID;
      pData1.pmp_ProgKind = 5;
      int num2;
      TProgMenuProp pData2 = this.InitTableBizSMLv1(pData1, this._PropCode++, num2 = num1 + 1, TableCodeType.ProgMenu.ToDescription(), 9, "UniBizSM.Client.Core.ViewModels.Part.Parent.TabParentPartVM", TableCodeType.ProgMenu.ToDescription());
      if (!this.OleDB.Execute(pData2.InsertQuery()))
        return false;
      int num3;
      TProgMenuProp pData3 = this.InitTableBizSMLv2(pData2, this._PropCode++, num3 = num2 + 1, "등록정보", 9, "UniBizSM.Client.Core.ViewModels.Part.Main.Systems.PageProgMenuMPartVM", "등록정보 [" + TableCodeType.ProgMenu.ToDescription() + "]");
      int num4;
      return this.OleDB.Execute(pData3.InsertQuery()) && this.OleDB.Execute(this.InitTableBizSMLv2(pData3, this._PropCode++, num4 = num3 + 1, "변경로그", 9, "UniBizSM.Client.Core.ViewModels.Part.Sub.DataModLogPartVM", "사용자 변경로그([" + TableCodeType.ProgMenu.ToDescription() + "]) 조회").InsertQuery());
    }

    private bool InitTableBizSMProgMenuProp(long pSiteID)
    {
      int num1 = 0;
      TProgMenuProp pData1 = this.OleDB.Create<TProgMenuProp>();
      pData1.pmp_SiteID = pSiteID;
      pData1.pmp_ProgKind = 5;
      int num2;
      TProgMenuProp pData2 = this.InitTableBizSMLv1(pData1, this._PropCode++, num2 = num1 + 1, TableCodeType.ProgMenuProp.ToDescription(), 11, "UniBizSM.Client.Core.ViewModels.Part.Parent.TabParentPartVM", TableCodeType.ProgMenuProp.ToDescription());
      if (!this.OleDB.Execute(pData2.InsertQuery()))
        return false;
      int num3;
      TProgMenuProp pData3 = this.InitTableBizSMLv2(pData2, this._PropCode++, num3 = num2 + 1, "등록정보", 11, "UniBizSM.Client.Core.ViewModels.Part.Main.Systems.PageProgMenuPropMPartVM", "등록정보 [" + TableCodeType.ProgMenuProp.ToDescription() + "]");
      int num4;
      return this.OleDB.Execute(pData3.InsertQuery()) && this.OleDB.Execute(this.InitTableBizSMLv2(pData3, this._PropCode++, num4 = num3 + 1, "변경로그", 11, "UniBizSM.Client.Core.ViewModels.Part.Sub.DataModLogPartVM", "사용자 변경로그([" + TableCodeType.ProgMenuProp.ToDescription() + "]) 조회").InsertQuery());
    }

    private bool InitTableBizSMProgOption(long pSiteID)
    {
      int num1 = 0;
      TProgMenuProp pData1 = this.OleDB.Create<TProgMenuProp>();
      pData1.pmp_SiteID = pSiteID;
      pData1.pmp_ProgKind = 5;
      int num2;
      TProgMenuProp pData2 = this.InitTableBizSMLv1(pData1, this._PropCode++, num2 = num1 + 1, TableCodeType.ProgOption.ToDescription(), 46, "UniBizSM.Client.Core.ViewModels.Part.Parent.TabParentPartVM", TableCodeType.ProgOption.ToDescription());
      if (!this.OleDB.Execute(pData2.InsertQuery()))
        return false;
      int num3;
      TProgMenuProp pData3 = this.InitTableBizSMLv2(pData2, this._PropCode++, num3 = num2 + 1, "등록정보", 46, "UniBizSM.Client.Core.ViewModels.Part.Main.Systems.PageProgOptionMPartVM", "등록정보 [" + TableCodeType.ProgOption.ToDescription() + "]");
      int num4;
      return this.OleDB.Execute(pData3.InsertQuery()) && this.OleDB.Execute(this.InitTableBizSMLv2(pData3, this._PropCode++, num4 = num3 + 1, "변경로그", 46, "UniBizSM.Client.Core.ViewModels.Part.Sub.DataModLogPartVM", "사용자 변경로그([" + TableCodeType.ProgOption.ToDescription() + "]) 조회").InsertQuery());
    }

    public static string CreateTableQuery()
    {
      string tableQuery;
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          tableQuery = ProgMenuPropCreate.CreateTableMsSql();
          break;
        case EnumDB.MYSQL:
          tableQuery = ProgMenuPropCreate.CreateTableMySql();
          break;
        default:
          tableQuery = string.Empty;
          break;
      }
      return tableQuery;
    }

    public static string CreateTableMsSql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_BASE, (object) TableCodeType.ProgMenuProp) + " pmp_PropCode INT NOT NULL,pmp_SiteID BIGINT NOT NULL DEFAULT(0),pmp_ProgKind INT NOT NULL DEFAULT(0),pmp_SortNo INT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "pmp_PropName", (object) 100) + ",pmp_TableID INT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "pmp_ProgID", (object) 200) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "pmp_ProgTitle", (object) 100) + ",pmp_PropType INT NOT NULL DEFAULT(0),pmp_PropDepth INT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "pmp_IconUrl", (object) 200) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('{2}')", (object) "pmp_UseYn", (object) 1, (object) "Y") + ",pmp_InDate DATETIME NULL,pmp_InUser INT NOT NULL DEFAULT(0),pmp_ModDate DATETIME NULL,pmp_ModUser INT NOT NULL DEFAULT(0) PRIMARY KEY(pmp_PropCode) ) ;";

    public static string CreateTableMySql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_BASE, (object) TableCodeType.ProgMenu) + " pmp_PropCode INT NOT NULL,pmp_SiteID BIGINT NOT NULL DEFAULT 0,pmp_ProgKind INT NOT NULL DEFAULT 0,pmp_SortNo INT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "pmp_PropName", (object) 100) + ",pmp_TableID INT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "pmp_ProgID", (object) 200) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "pmp_ProgTitle", (object) 100) + ",pmp_PropType INT NOT NULL DEFAULT 0,pmp_PropDepth INT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "pmp_IconUrl", (object) 200) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT '{2}'", (object) "pmp_UseYn", (object) 1, (object) "Y") + ",pmp_InDate DATETIME NULL,pmp_InUser INT NOT NULL DEFAULT 0,pmp_ModDate DATETIME NULL,pmp_ModUser INT NOT NULL DEFAULT 0 PRIMARY KEY(pmp_PropCode) ) ;";

    public bool CreateTable()
    {
      if (this.OleDB.Execute(ProgMenuPropCreate.CreateTableQuery()))
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
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}';", (object) UbModelBase.UNI_BASE, (object) TableCodeType.ProgMenuProp.ToDescription(), (object) TableCodeType.ProgMenuProp));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "팝업 코드", (object) TableCodeType.ProgMenuProp, (object) "pmp_PropCode"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "싸이트", (object) TableCodeType.ProgMenuProp, (object) "pmp_SiteID"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) UbModelBase.UNI_BASE, (object) "프로그램 종류", (object) 1, (object) TableCodeType.ProgMenuProp, (object) "pmp_ProgKind"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "순서", (object) TableCodeType.ProgMenuProp, (object) "pmp_SortNo"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "팝업명", (object) TableCodeType.ProgMenuProp, (object) "pmp_PropName"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "테이블 ID", (object) TableCodeType.ProgMenuProp, (object) "pmp_TableID"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "팝업 ID", (object) TableCodeType.ProgMenuProp, (object) "pmp_ProgID"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "타이틀", (object) TableCodeType.ProgMenuProp, (object) "pmp_ProgTitle"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) UbModelBase.UNI_BASE, (object) "타입", (object) 36, (object) TableCodeType.ProgMenuProp, (object) "pmp_PropType"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) UbModelBase.UNI_BASE, (object) "단계", (object) 37, (object) TableCodeType.ProgMenuProp, (object) "pmp_PropDepth"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "이미지 URL", (object) TableCodeType.ProgMenuProp, (object) "pmp_IconUrl"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "사용상태", (object) TableCodeType.ProgMenuProp, (object) "pmp_UseYn"));
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
      this._PropCode = 1;
      return this.InitTableBizSM(pSiteID) && this.InitTableBizBO(pSiteID);
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        if (p_rs.IsFieldName("pmp_PropCode"))
          this.pmp_PropCode = p_rs.GetFieldInt("pmp_PropCode");
        if (p_rs.IsFieldName("pmp_SiteID"))
          this.pmp_SiteID = p_rs.GetFieldLong("pmp_SiteID");
        if (p_rs.IsFieldName("pmp_ProgKind"))
          this.pmp_ProgKind = p_rs.GetFieldInt("pmp_ProgKind");
        if (p_rs.IsFieldName("pmp_SortNo"))
          this.pmp_SortNo = p_rs.GetFieldInt("pmp_SortNo");
        if (p_rs.IsFieldName("pmp_PropName"))
          this.pmp_PropName = p_rs.GetFieldString("pmp_PropName");
        if (p_rs.IsFieldName("pmp_TableID"))
          this.pmp_TableID = p_rs.GetFieldInt("pmp_TableID");
        if (p_rs.IsFieldName("pmp_ProgID"))
          this.pmp_ProgID = p_rs.GetFieldString("pmp_ProgID");
        if (p_rs.IsFieldName("pmp_ProgTitle"))
          this.pmp_ProgTitle = p_rs.GetFieldString("pmp_ProgTitle");
        if (p_rs.IsFieldName("pmp_PropType"))
          this.pmp_PropType = p_rs.GetFieldInt("pmp_PropType");
        if (p_rs.IsFieldName("pmp_PropDepth"))
          this.pmp_PropDepth = p_rs.GetFieldInt("pmp_PropDepth");
        if (p_rs.IsFieldName("pmp_IconUrl"))
          this.pmp_IconUrl = p_rs.GetFieldString("pmp_IconUrl");
        if (p_rs.IsFieldName("pmp_UseYn"))
          this.pmp_UseYn = p_rs.GetFieldString("pmp_UseYn");
        if (p_rs.IsFieldName("pmp_InDate"))
          this.pmp_InDate = p_rs.GetFieldDateTime("pmp_InDate");
        if (p_rs.IsFieldName("pmp_InUser"))
          this.pmp_InUser = p_rs.GetFieldInt("pmp_InUser");
        if (p_rs.IsFieldName("pmp_ModDate"))
          this.pmp_ModDate = p_rs.GetFieldDateTime("pmp_ModDate");
        if (p_rs.IsFieldName("pmp_ModUser"))
          this.pmp_ModUser = p_rs.GetFieldInt("pmp_ModUser");
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
        IList<ProgMenuPropCreate> progMenuPropCreateList = this.OleDB.Create<ProgMenuPropCreate>().SelectAllListE<ProgMenuPropCreate>((object) new Hashtable()
        {
          {
            (object) "DBMS",
            (object) UbModelBase.UNI_BASE
          }
        });
        if (progMenuPropCreateList == null)
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
        int count = progMenuPropCreateList.Count;
        int num1 = 0;
        int num2 = 0;
        if (progMenuPropCreateList.Count > 0)
          Log.Logger.DebugColor("\n--------------------------------------------------------------------------------------------------" + string.Format("\n - {0}({1}) 이전 데이터 작업 시작", (object) TableCodeType.ProgMenuProp.ToDescription(), (object) TableCodeType.ProgMenuProp) + "\n--------------------------------------------------------------------------------------------------");
        StringBuilder stringBuilder = new StringBuilder();
        foreach (ProgMenuPropCreate progMenuPropCreate in (IEnumerable<ProgMenuPropCreate>) progMenuPropCreateList)
        {
          stringBuilder.Append(progMenuPropCreate.InsertQuery());
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
        if (progMenuPropCreateList.Count > 0)
        {
          if (num2 != 100)
            Log.Logger.DebugColor(" pro = 100%");
          Log.Logger.DebugColor(string.Format(" - {0}({1}) 이전 데이터 작업 종료", (object) TableCodeType.ProgMenuProp.ToDescription(), (object) TableCodeType.ProgMenuProp) + "\n--------------------------------------------------------------------------------------------------");
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
