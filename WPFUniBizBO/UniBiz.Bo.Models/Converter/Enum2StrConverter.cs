// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.Enum2StrConverter
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections.Generic;
using System.Linq;
using UniBiz.Bo.Models.JobEvtMessage;
using UniBiz.Bo.Models.UniBase.CommonCode;
using UniBiz.Bo.Models.UniBase.ProgOption;
using UniBiz.Bo.Models.UniBase.UniSite;
using UniBizUtil.Util;

namespace UniBiz.Bo.Models.Converter
{
  public class Enum2StrConverter
  {
    public const string IDS_IN = "입고";
    public const string IDS_OUT = "츨고";
    public const string IDS_Normal = "정상";
    public const string IDS_Return = "반품";
    public const string IDS_COLLECTION = "회수";
    public const string IDS_PAYMENT = "지급";
    public const string IDS_MONEY_IN = "입금";
    public const string IDS_MONEY_OUT = "출금";
    public const string IDS_USE_YES = "Y";
    public const string IDS_USE_NO = "N";
    public const string IDS_USE_YES_DESC = "사용";
    public const string IDS_USE_NO_DESC = "미사용";
    public const string IDS_USE_YES_DESC2 = "가능";
    public const string IDS_USE_NO_DESC2 = "불가능";
    public const string IDS_USE_END = "E";
    public const int THUMB_MAX_SIZE = 300;
    public const int THUMB2_MAX_SIZE = 100;
    public const int THUMB3_MAX_SIZE = 200;
    public const int THUMB4_MAX_SIZE = 400;
    public const int Representative_SUP = 1001;

    public static EnumAppType ToAppType(int p_value)
    {
      foreach (EnumAppType appType in Enum.GetValues(typeof (EnumAppType)))
      {
        if (appType == (EnumAppType) p_value)
          return appType;
      }
      return EnumAppType.NONE;
    }

    public static EnumOsType ToOsType(int p_value)
    {
      foreach (EnumOsType osType in Enum.GetValues(typeof (EnumOsType)))
      {
        if (osType == (EnumOsType) p_value)
          return osType;
      }
      return EnumOsType.NONE;
    }

    public static EnumDevicePermit ToDevicePermit(int p_value)
    {
      foreach (EnumDevicePermit devicePermit in Enum.GetValues(typeof (EnumDevicePermit)))
      {
        if (devicePermit == (EnumDevicePermit) p_value)
          return devicePermit;
      }
      return EnumDevicePermit.NONE;
    }

    public static EnumEmpAuth1 ToEmpAuth1(int p_value)
    {
      foreach (EnumEmpAuth1 empAuth1 in Enum.GetValues(typeof (EnumEmpAuth1)))
      {
        if (empAuth1 == (EnumEmpAuth1) p_value)
          return empAuth1;
      }
      return EnumEmpAuth1.NONE;
    }

    public static EnumEmpAuth2 ToEmpAuth2(int p_value)
    {
      foreach (EnumEmpAuth2 empAuth2 in Enum.GetValues(typeof (EnumEmpAuth2)))
      {
        if (empAuth2 == (EnumEmpAuth2) p_value)
          return empAuth2;
      }
      return EnumEmpAuth2.NONE;
    }

    public static EnumEmpAuth3 ToEmpAuth3(int p_value)
    {
      foreach (EnumEmpAuth3 empAuth3 in Enum.GetValues(typeof (EnumEmpAuth3)))
      {
        if (empAuth3 == (EnumEmpAuth3) p_value)
          return empAuth3;
      }
      return EnumEmpAuth3.NONE;
    }

    public static string ToInOutDivIODesc(int p_value)
    {
      switch (Enum2StrConverter.ToInOutDiv(p_value))
      {
        case EnumInOutDiv.Return:
          return "츨고";
        case EnumInOutDiv.Normal:
          return "입고";
        default:
          return string.Empty;
      }
    }

    public static string ToInOutDivSaleDesc(int p_value)
    {
      switch (Enum2StrConverter.ToInOutDiv(p_value))
      {
        case EnumInOutDiv.Return:
          return "반품";
        case EnumInOutDiv.Normal:
          return "정상";
        default:
          return string.Empty;
      }
    }

    public static string ToInOutDivPaymentDesc(int p_value)
    {
      switch (Enum2StrConverter.ToInOutDiv(p_value))
      {
        case EnumInOutDiv.Return:
          return "지급";
        case EnumInOutDiv.Normal:
          return "회수";
        default:
          return string.Empty;
      }
    }

    public static string ToInOutDivMoneyDesc(int p_value)
    {
      switch (Enum2StrConverter.ToInOutDiv(p_value))
      {
        case EnumInOutDiv.Return:
          return "출금";
        case EnumInOutDiv.Normal:
          return "입금";
        default:
          return string.Empty;
      }
    }

    public static EnumInOutDiv ToInOutDiv(int p_value)
    {
      foreach (EnumInOutDiv inOutDiv in Enum.GetValues(typeof (EnumInOutDiv)))
      {
        if (inOutDiv == (EnumInOutDiv) p_value)
          return inOutDiv;
      }
      return EnumInOutDiv.None;
    }

    public static EnumStatementType ToStatementType(int p_value)
    {
      foreach (EnumStatementType statementType in Enum.GetValues(typeof (EnumStatementType)))
      {
        if (statementType == (EnumStatementType) p_value)
          return statementType;
      }
      return EnumStatementType.None;
    }

    public static EnumStoreType ToStoreType(int p_value)
    {
      foreach (EnumStoreType storeType in Enum.GetValues(typeof (EnumStoreType)))
      {
        if (storeType == (EnumStoreType) p_value)
          return storeType;
      }
      return EnumStoreType.None;
    }

    public static EnumMenuType ToMenuType(int p_value)
    {
      foreach (EnumMenuType menuType in Enum.GetValues(typeof (EnumMenuType)))
      {
        if (menuType == (EnumMenuType) p_value)
          return menuType;
      }
      return EnumMenuType.None;
    }

    public static EnumMenuDepth ToMenuDepth(int p_value)
    {
      foreach (EnumMenuDepth menuDepth in Enum.GetValues(typeof (EnumMenuDepth)))
      {
        if (menuDepth == (EnumMenuDepth) p_value)
          return menuDepth;
      }
      return EnumMenuDepth.None;
    }

    public static EnumMenuPropType ToMenuPropType(int p_value)
    {
      foreach (EnumMenuPropType menuPropType in Enum.GetValues(typeof (EnumMenuPropType)))
      {
        if (menuPropType == (EnumMenuPropType) p_value)
          return menuPropType;
      }
      return EnumMenuPropType.None;
    }

    public static EnumMenuPropDepth ToMenuPropDepth(int p_value)
    {
      foreach (EnumMenuPropDepth menuPropDepth in Enum.GetValues(typeof (EnumMenuPropDepth)))
      {
        if (menuPropDepth == (EnumMenuPropDepth) p_value)
          return menuPropDepth;
      }
      return EnumMenuPropDepth.None;
    }

    public static EnumDeptDepth ToDeptDepth(int p_value)
    {
      foreach (EnumDeptDepth deptDepth in Enum.GetValues(typeof (EnumDeptDepth)))
      {
        if (deptDepth == (EnumDeptDepth) p_value)
          return deptDepth;
      }
      return EnumDeptDepth.None;
    }

    public static EnumCategoryDepth ToCategoryDepth(int p_value)
    {
      foreach (EnumCategoryDepth categoryDepth in Enum.GetValues(typeof (EnumCategoryDepth)))
      {
        if (categoryDepth == (EnumCategoryDepth) p_value)
          return categoryDepth;
      }
      return EnumCategoryDepth.None;
    }

    public static bool IsSupplierTypeDirect(int p_value) => p_value == 1;

    public static bool IsSupplierTypeSpe(int p_value) => p_value == 2;

    public static bool IsSupplierTypeLea(int p_value) => p_value == 3;

    public static EnumSupplierType ToSupplierType(int p_value)
    {
      foreach (EnumSupplierType supplierType in Enum.GetValues(typeof (EnumSupplierType)))
      {
        if (supplierType == (EnumSupplierType) p_value)
          return supplierType;
      }
      return EnumSupplierType.None;
    }

    public static EnumSupplierKind ToSupplierKind(int p_value)
    {
      foreach (EnumSupplierKind supplierKind in Enum.GetValues(typeof (EnumSupplierKind)))
      {
        if (supplierKind == (EnumSupplierKind) p_value)
          return supplierKind;
      }
      return EnumSupplierKind.None;
    }

    public static EnumStdPreTax ToStdPreTax(int p_value)
    {
      foreach (EnumStdPreTax stdPreTax in Enum.GetValues(typeof (EnumStdPreTax)))
      {
        if (stdPreTax == (EnumStdPreTax) p_value)
          return stdPreTax;
      }
      return EnumStdPreTax.None;
    }

    public static EnumSupplierMulti ToSupplierMulti(int p_value)
    {
      foreach (EnumSupplierMulti supplierMulti in Enum.GetValues(typeof (EnumSupplierMulti)))
      {
        if (supplierMulti == (EnumSupplierMulti) p_value)
          return supplierMulti;
      }
      return EnumSupplierMulti.None;
    }

    public static EnumSupplierDeductionDayType ToSupplierDeductionDayType(int p_value)
    {
      foreach (EnumSupplierDeductionDayType deductionDayType in Enum.GetValues(typeof (EnumSupplierDeductionDayType)))
      {
        if (deductionDayType == (EnumSupplierDeductionDayType) p_value)
          return deductionDayType;
      }
      return EnumSupplierDeductionDayType.None;
    }

    public static EnumStatementOrderStatus ToStatementOrderStatus(int pValue)
    {
      foreach (EnumStatementOrderStatus statementOrderStatus in Enum.GetValues(typeof (EnumStatementOrderStatus)))
      {
        if (statementOrderStatus == (EnumStatementOrderStatus) pValue)
          return statementOrderStatus;
      }
      return EnumStatementOrderStatus.None;
    }

    public static EnumStatementConfirmStatus ToStatementConfirmStatus(int pValue)
    {
      foreach (EnumStatementConfirmStatus statementConfirmStatus in Enum.GetValues(typeof (EnumStatementConfirmStatus)))
      {
        if (statementConfirmStatus == (EnumStatementConfirmStatus) pValue)
          return statementConfirmStatus;
      }
      return EnumStatementConfirmStatus.None;
    }

    public static EnumConfirmStatus ToConfirmStatus(int pValue)
    {
      foreach (EnumConfirmStatus confirmStatus in Enum.GetValues(typeof (EnumConfirmStatus)))
      {
        if (confirmStatus == (EnumConfirmStatus) pValue)
          return confirmStatus;
      }
      return EnumConfirmStatus.NONE;
    }

    public static bool IsConfirmYes(int p_value) => p_value == 2;

    public static bool IsConfirmNo(int p_value) => p_value == 1;

    public static EnumDeviceType ToDeviceType(int pValue)
    {
      foreach (EnumDeviceType deviceType in Enum.GetValues(typeof (EnumDeviceType)))
      {
        if (deviceType == (EnumDeviceType) pValue)
          return deviceType;
      }
      return EnumDeviceType.None;
    }

    public static EnumTaxDiv ToTaxDiv(int pValue)
    {
      foreach (EnumTaxDiv taxDiv in Enum.GetValues(typeof (EnumTaxDiv)))
      {
        if (taxDiv == (EnumTaxDiv) pValue)
          return taxDiv;
      }
      return EnumTaxDiv.NONE;
    }

    public static string ToTaxDivDesc(int p_value) => p_value == 0 ? string.Empty : Enum2StrConverter.ToTaxDiv(p_value).ToDescription();

    public static bool IsTax(int p_value) => p_value == 1;

    public static bool IsTaxFree(int p_value) => p_value == 2;

    public static EnumSalesUnit ToSalesUnit(int pValue)
    {
      foreach (EnumSalesUnit salesUnit in Enum.GetValues(typeof (EnumSalesUnit)))
      {
        if (salesUnit == (EnumSalesUnit) pValue)
          return salesUnit;
      }
      return EnumSalesUnit.NONE;
    }

    public static EnumStockUnit ToStockUnit(int pValue)
    {
      foreach (EnumStockUnit stockUnit in Enum.GetValues(typeof (EnumStockUnit)))
      {
        if (stockUnit == (EnumStockUnit) pValue)
          return stockUnit;
      }
      return EnumStockUnit.NONE;
    }

    public static EnumPackUnit ToPackUnit(int pValue)
    {
      foreach (EnumPackUnit packUnit in Enum.GetValues(typeof (EnumPackUnit)))
      {
        if (packUnit == (EnumPackUnit) pValue)
          return packUnit;
      }
      return EnumPackUnit.NONE;
    }

    public static EnumGoodsHistoryDiv ToGoodsHistoryDiv(int pValue)
    {
      foreach (EnumGoodsHistoryDiv goodsHistoryDiv in Enum.GetValues(typeof (EnumGoodsHistoryDiv)))
      {
        if (goodsHistoryDiv == (EnumGoodsHistoryDiv) pValue)
          return goodsHistoryDiv;
      }
      return EnumGoodsHistoryDiv.NONE;
    }

    public static EnumLocLocationType ToLocLocationType(int pValue)
    {
      foreach (EnumLocLocationType locLocationType in Enum.GetValues(typeof (EnumLocLocationType)))
      {
        if (locLocationType == (EnumLocLocationType) pValue)
          return locLocationType;
      }
      return EnumLocLocationType.None;
    }

    public static EnumLocPermitDiv ToLocPermitDiv(int pValue)
    {
      foreach (EnumLocPermitDiv locPermitDiv in Enum.GetValues(typeof (EnumLocPermitDiv)))
      {
        if (locPermitDiv == (EnumLocPermitDiv) pValue)
          return locPermitDiv;
      }
      return EnumLocPermitDiv.None;
    }

    public static EnumLocLevel ToLocLevel(int pValue)
    {
      foreach (EnumLocLevel locLevel in Enum.GetValues(typeof (EnumLocLevel)))
      {
        if (locLevel == (EnumLocLevel) pValue)
          return locLevel;
      }
      return EnumLocLevel.None;
    }

    public static EnumWriteType ToWriteType(int pValue)
    {
      foreach (EnumWriteType writeType in Enum.GetValues(typeof (EnumWriteType)))
      {
        if (writeType == (EnumWriteType) pValue)
          return writeType;
      }
      return EnumWriteType.NONE;
    }

    public static EnumPaymentStatementDiv ToPaymentStatementDiv(int pValue)
    {
      foreach (EnumPaymentStatementDiv paymentStatementDiv in Enum.GetValues(typeof (EnumPaymentStatementDiv)))
      {
        if (paymentStatementDiv == (EnumPaymentStatementDiv) pValue)
          return paymentStatementDiv;
      }
      return EnumPaymentStatementDiv.NONE;
    }

    public static EnumPayStatementStatus ToPayStatementStatus(int pValue)
    {
      foreach (EnumPayStatementStatus payStatementStatus in Enum.GetValues(typeof (EnumPayStatementStatus)))
      {
        if (payStatementStatus == (EnumPayStatementStatus) pValue)
          return payStatementStatus;
      }
      return EnumPayStatementStatus.None;
    }

    public static EnumDeductionAutoType ToDeductionAutoType(int pValue)
    {
      foreach (EnumDeductionAutoType deductionAutoType in Enum.GetValues(typeof (EnumDeductionAutoType)))
      {
        if (deductionAutoType == (EnumDeductionAutoType) pValue)
          return deductionAutoType;
      }
      return EnumDeductionAutoType.NONE;
    }

    public static EnumDeductionAutoCalc ToDeductionAutoCalc(int pValue)
    {
      foreach (EnumDeductionAutoCalc deductionAutoCalc in Enum.GetValues(typeof (EnumDeductionAutoCalc)))
      {
        if (deductionAutoCalc == (EnumDeductionAutoCalc) pValue)
          return deductionAutoCalc;
      }
      return EnumDeductionAutoCalc.NONE;
    }

    public static EnumSupRebateStdDate ToSupRebateStdDate(int pValue)
    {
      foreach (EnumSupRebateStdDate supRebateStdDate in Enum.GetValues(typeof (EnumSupRebateStdDate)))
      {
        if (supRebateStdDate == (EnumSupRebateStdDate) pValue)
          return supRebateStdDate;
      }
      return EnumSupRebateStdDate.NONE;
    }

    public static EnumSupRebateStdAmount ToSupRebateStdAmount(int pValue)
    {
      foreach (EnumSupRebateStdAmount supRebateStdAmount in Enum.GetValues(typeof (EnumSupRebateStdAmount)))
      {
        if (supRebateStdAmount == (EnumSupRebateStdAmount) pValue)
          return supRebateStdAmount;
      }
      return EnumSupRebateStdAmount.NONE;
    }

    public static EnumGender ToGender(int p_value)
    {
      foreach (EnumGender gender in Enum.GetValues(typeof (EnumGender)))
      {
        if (gender == (EnumGender) p_value)
          return gender;
      }
      return EnumGender.NONE;
    }

    public static EnumMonthCalendarType ToMonthCalendarType(int p_value)
    {
      foreach (EnumMonthCalendarType monthCalendarType in Enum.GetValues(typeof (EnumMonthCalendarType)))
      {
        if (monthCalendarType == (EnumMonthCalendarType) p_value)
          return monthCalendarType;
      }
      return EnumMonthCalendarType.NONE;
    }

    public static string ToFileExtensionDesc(EnumFileExtension p_value) => p_value.ToString();

    public static string ToFileExtensionDesc(int p_value) => Enum2StrConverter.ToFileExtensionDesc((EnumFileExtension) p_value);

    public static EnumFileExtension GetFileExtensionType(string p_value)
    {
      if (string.IsNullOrEmpty(p_value))
        return EnumFileExtension.None;
      EnumFileExtension fileExtensionType;
      switch (p_value.Replace(".", "").ToUpper())
      {
        case "BMP":
          fileExtensionType = EnumFileExtension.BMP;
          break;
        case "GIF":
          fileExtensionType = EnumFileExtension.GIF;
          break;
        case "JPEG":
          fileExtensionType = EnumFileExtension.JPEG;
          break;
        case "JPG":
          fileExtensionType = EnumFileExtension.JPG;
          break;
        case "PNG":
          fileExtensionType = EnumFileExtension.PNG;
          break;
        case "ULD":
          fileExtensionType = EnumFileExtension.ULD;
          break;
        case "UPD":
          fileExtensionType = EnumFileExtension.UPD;
          break;
        case "WEBP":
          fileExtensionType = EnumFileExtension.WEBP;
          break;
        default:
          fileExtensionType = EnumFileExtension.FILE;
          break;
      }
      return fileExtensionType;
    }

    public static EnumFileExtension GetFileExtensionType(int p_value)
    {
      foreach (EnumFileExtension fileExtensionType in Enum.GetValues(typeof (EnumFileExtension)))
      {
        if (fileExtensionType == (EnumFileExtension) p_value)
          return fileExtensionType;
      }
      return EnumFileExtension.None;
    }

    public static bool IsExtensionImage(EnumFileExtension p_value)
    {
      switch (p_value)
      {
        case EnumFileExtension.JPG:
        case EnumFileExtension.JPEG:
        case EnumFileExtension.GIF:
        case EnumFileExtension.BMP:
        case EnumFileExtension.PNG:
        case EnumFileExtension.WEBP:
          return true;
        default:
          return false;
      }
    }

    public static bool IsExtensionImage(int p_value) => Enum2StrConverter.IsExtensionImage((EnumFileExtension) p_value);

    public static bool IsExtensionPng(EnumFileExtension p_value) => EnumFileExtension.PNG == p_value;

    public static bool IsExtensionPng(int p_value) => Enum2StrConverter.IsExtensionPng((EnumFileExtension) p_value);

    public static bool IsExtensionWebp(EnumFileExtension p_value) => EnumFileExtension.WEBP == p_value;

    public static bool IsExtensionWebp(int p_value) => Enum2StrConverter.IsExtensionWebp((EnumFileExtension) p_value);

    public static string ToImageFileExtensionName(int p_value)
    {
      string fileExtensionName;
      switch (Enum2StrConverter.GetFileExtensionType(p_value))
      {
        case EnumFileExtension.JPG:
          fileExtensionName = "jpg";
          break;
        case EnumFileExtension.JPEG:
          fileExtensionName = "jpg";
          break;
        case EnumFileExtension.PNG:
          fileExtensionName = "png";
          break;
        case EnumFileExtension.WEBP:
          fileExtensionName = "webp";
          break;
        default:
          fileExtensionName = "none";
          break;
      }
      return fileExtensionName;
    }

    public static EnumSupplierImageKind ToSupplierImageKind(int p_value)
    {
      foreach (EnumSupplierImageKind supplierImageKind in Enum.GetValues(typeof (EnumSupplierImageKind)))
      {
        if (supplierImageKind == (EnumSupplierImageKind) p_value)
          return supplierImageKind;
      }
      return EnumSupplierImageKind.NONE;
    }

    public static EnumProgOptionType ToProgOptionType(int p_value)
    {
      foreach (EnumProgOptionType progOptionType in Enum.GetValues(typeof (EnumProgOptionType)))
      {
        if (progOptionType == (EnumProgOptionType) p_value)
          return progOptionType;
      }
      return EnumProgOptionType.None;
    }

    public static EnumProgOptionValueType ToProgOptionValueType(int p_value)
    {
      foreach (EnumProgOptionValueType progOptionValueType in Enum.GetValues(typeof (EnumProgOptionValueType)))
      {
        if (progOptionValueType == (EnumProgOptionValueType) p_value)
          return progOptionValueType;
      }
      return EnumProgOptionValueType.None;
    }

    public static EnumGiftCardIssuer ToGiftCardIssuer(int p_value)
    {
      foreach (EnumGiftCardIssuer giftCardIssuer in Enum.GetValues(typeof (EnumGiftCardIssuer)))
      {
        if (giftCardIssuer == (EnumGiftCardIssuer) p_value)
          return giftCardIssuer;
      }
      return EnumGiftCardIssuer.None;
    }

    public static EnumGiftCardSaleKind ToGiftCardSaleKind(int p_value)
    {
      foreach (EnumGiftCardSaleKind giftCardSaleKind in Enum.GetValues(typeof (EnumGiftCardSaleKind)))
      {
        if (giftCardSaleKind == (EnumGiftCardSaleKind) p_value)
          return giftCardSaleKind;
      }
      return EnumGiftCardSaleKind.None;
    }

    public static EnumInventoryApplyType ToInventoryApplyType(int p_value)
    {
      foreach (EnumInventoryApplyType inventoryApplyType in Enum.GetValues(typeof (EnumInventoryApplyType)))
      {
        if (inventoryApplyType == (EnumInventoryApplyType) p_value)
          return inventoryApplyType;
      }
      return EnumInventoryApplyType.None;
    }

    public static EnumTrSaleType ToTrSaleType(int p_value)
    {
      foreach (EnumTrSaleType trSaleType in Enum.GetValues(typeof (EnumTrSaleType)))
      {
        if (trSaleType == (EnumTrSaleType) p_value)
          return trSaleType;
      }
      return EnumTrSaleType.NONE;
    }

    public static EnumMemberStatus ToMemberStatus(int p_value)
    {
      foreach (EnumMemberStatus memberStatus in Enum.GetValues(typeof (EnumMemberStatus)))
      {
        if (memberStatus == (EnumMemberStatus) p_value)
          return memberStatus;
      }
      return EnumMemberStatus.NONE;
    }

    public static EnumMemberPointExtinctionAgree ToMemberPointExtinctionAgree(int p_value)
    {
      foreach (EnumMemberPointExtinctionAgree pointExtinctionAgree in Enum.GetValues(typeof (EnumMemberPointExtinctionAgree)))
      {
        if (pointExtinctionAgree == (EnumMemberPointExtinctionAgree) p_value)
          return pointExtinctionAgree;
      }
      return EnumMemberPointExtinctionAgree.NONE;
    }

    public static EnumCashReceiptDiv ToCashReceiptDiv(int p_value)
    {
      foreach (EnumCashReceiptDiv cashReceiptDiv in Enum.GetValues(typeof (EnumCashReceiptDiv)))
      {
        if (cashReceiptDiv == (EnumCashReceiptDiv) p_value)
          return cashReceiptDiv;
      }
      return EnumCashReceiptDiv.NONE;
    }

    public static EnumSmsSendAgree ToSmsSendAgree(int p_value)
    {
      foreach (EnumSmsSendAgree smsSendAgree in Enum.GetValues(typeof (EnumSmsSendAgree)))
      {
        if (smsSendAgree == (EnumSmsSendAgree) p_value)
          return smsSendAgree;
      }
      return EnumSmsSendAgree.NONE;
    }

    public static EnumMemberCardType ToMemberCardType(int p_value)
    {
      foreach (EnumMemberCardType memberCardType in Enum.GetValues(typeof (EnumMemberCardType)))
      {
        if (memberCardType == (EnumMemberCardType) p_value)
          return memberCardType;
      }
      return EnumMemberCardType.NONE;
    }

    public static EnumMemberCycle ToMemberCycle(int p_value)
    {
      foreach (EnumMemberCycle memberCycle in Enum.GetValues(typeof (EnumMemberCycle)))
      {
        if (memberCycle == (EnumMemberCycle) p_value)
          return memberCycle;
      }
      return EnumMemberCycle.NONE;
    }

    public static EnumMemberCalcCycleDiv ToMemberCalcCycleDiv(int p_value)
    {
      foreach (EnumMemberCalcCycleDiv memberCalcCycleDiv in Enum.GetValues(typeof (EnumMemberCalcCycleDiv)))
      {
        if (memberCalcCycleDiv == (EnumMemberCalcCycleDiv) p_value)
          return memberCalcCycleDiv;
      }
      return EnumMemberCalcCycleDiv.NONE;
    }

    public static EnumMemberTaxBillCycle ToMemberTaxBillCycle(int p_value)
    {
      foreach (EnumMemberTaxBillCycle memberTaxBillCycle in Enum.GetValues(typeof (EnumMemberTaxBillCycle)))
      {
        if (memberTaxBillCycle == (EnumMemberTaxBillCycle) p_value)
          return memberTaxBillCycle;
      }
      return EnumMemberTaxBillCycle.NONE;
    }

    public static EnumEodInfoType ToEodInfoType(int p_value)
    {
      foreach (EnumEodInfoType eodInfoType in Enum.GetValues(typeof (EnumEodInfoType)))
      {
        if (eodInfoType == (EnumEodInfoType) p_value)
          return eodInfoType;
      }
      return EnumEodInfoType.NONE;
    }

    public static EnumEodInfoStatus ToEodInfoStatus(int p_value)
    {
      foreach (EnumEodInfoStatus eodInfoStatus in Enum.GetValues(typeof (EnumEodInfoStatus)))
      {
        if (eodInfoStatus == (EnumEodInfoStatus) p_value)
          return eodInfoStatus;
      }
      return EnumEodInfoStatus.NONE;
    }

    public static EnumDbNameType ToDbNameType(int p_value)
    {
      foreach (EnumDbNameType dbNameType in Enum.GetValues(typeof (EnumDbNameType)))
      {
        if (dbNameType == (EnumDbNameType) p_value)
          return dbNameType;
      }
      return EnumDbNameType.None;
    }

    public static EnumPromotionKind ToPromotionKind(int p_value)
    {
      foreach (EnumPromotionKind promotionKind in Enum.GetValues(typeof (EnumPromotionKind)))
      {
        if (promotionKind == (EnumPromotionKind) p_value)
          return promotionKind;
      }
      return EnumPromotionKind.None;
    }

    public static EnumPromotionType ToPromotionType(int p_value)
    {
      foreach (EnumPromotionType promotionType in Enum.GetValues(typeof (EnumPromotionType)))
      {
        if (promotionType == (EnumPromotionType) p_value)
          return promotionType;
      }
      return EnumPromotionType.None;
    }

    public static EnumPromotionDiv ToPromotionDiv(int p_value)
    {
      foreach (EnumPromotionDiv promotionDiv in Enum.GetValues(typeof (EnumPromotionDiv)))
      {
        if (promotionDiv == (EnumPromotionDiv) p_value)
          return promotionDiv;
      }
      return EnumPromotionDiv.None;
    }

    public static EnumPromotionTargetGroup ToPromotionTargetGroup(int p_value)
    {
      foreach (EnumPromotionTargetGroup promotionTargetGroup in Enum.GetValues(typeof (EnumPromotionTargetGroup)))
      {
        if (promotionTargetGroup == (EnumPromotionTargetGroup) p_value)
          return promotionTargetGroup;
      }
      return EnumPromotionTargetGroup.None;
    }

    public static EnumOperatorAndOr ToOperatorAndOr(int p_value)
    {
      foreach (EnumOperatorAndOr operatorAndOr in Enum.GetValues(typeof (EnumOperatorAndOr)))
      {
        if (operatorAndOr == (EnumOperatorAndOr) p_value)
          return operatorAndOr;
      }
      return EnumOperatorAndOr.None;
    }

    public static EnumApplyDiv ToApplyDiv(int p_value)
    {
      foreach (EnumApplyDiv applyDiv in Enum.GetValues(typeof (EnumApplyDiv)))
      {
        if (applyDiv == (EnumApplyDiv) p_value)
          return applyDiv;
      }
      return EnumApplyDiv.None;
    }

    public static EnumCouponType ToCouponType(int p_value)
    {
      foreach (EnumCouponType couponType in Enum.GetValues(typeof (EnumCouponType)))
      {
        if (couponType == (EnumCouponType) p_value)
          return couponType;
      }
      return EnumCouponType.None;
    }

    public static EnumCouponApply ToCouponApply(int p_value)
    {
      foreach (EnumCouponApply couponApply in Enum.GetValues(typeof (EnumCouponApply)))
      {
        if (couponApply == (EnumCouponApply) p_value)
          return couponApply;
      }
      return EnumCouponApply.None;
    }

    public static EnumCouponStatus ToCouponStatus(int p_value)
    {
      foreach (EnumCouponStatus couponStatus in Enum.GetValues(typeof (EnumCouponStatus)))
      {
        if (couponStatus == (EnumCouponStatus) p_value)
          return couponStatus;
      }
      return EnumCouponStatus.None;
    }

    public static EnumCouponApplyDiv ToCouponApplyDiv(int p_value)
    {
      foreach (EnumCouponApplyDiv couponApplyDiv in Enum.GetValues(typeof (EnumCouponApplyDiv)))
      {
        if (couponApplyDiv == (EnumCouponApplyDiv) p_value)
          return couponApplyDiv;
      }
      return EnumCouponApplyDiv.None;
    }

    public static EnumCampaignType ToCampaignType(int p_value)
    {
      foreach (EnumCampaignType campaignType in Enum.GetValues(typeof (EnumCampaignType)))
      {
        if (campaignType == (EnumCampaignType) p_value)
          return campaignType;
      }
      return EnumCampaignType.None;
    }

    public static EnumCampaignTargetCodeType ToCampaignTargetCodeType(int p_value)
    {
      foreach (EnumCampaignTargetCodeType campaignTargetCodeType in Enum.GetValues(typeof (EnumCampaignTargetCodeType)))
      {
        if (campaignTargetCodeType == (EnumCampaignTargetCodeType) p_value)
          return campaignTargetCodeType;
      }
      return EnumCampaignTargetCodeType.None;
    }

    public static EnumEmpJob ToEmpJob(int p_value)
    {
      foreach (EnumEmpJob empJob in Enum.GetValues(typeof (EnumEmpJob)))
      {
        if (empJob == (EnumEmpJob) p_value)
          return empJob;
      }
      return EnumEmpJob.NONE;
    }

    public static EnumLotteNotiType GetLotteNotiType(int pValue)
    {
      foreach (EnumLotteNotiType lotteNotiType in Enum.GetValues(typeof (EnumLotteNotiType)))
      {
        if (lotteNotiType == (EnumLotteNotiType) pValue)
          return lotteNotiType;
      }
      return EnumLotteNotiType.None;
    }

    public static EnumLotteResultCodeType GetLotteResultCodeType(int pValue)
    {
      foreach (EnumLotteResultCodeType lotteResultCodeType in Enum.GetValues(typeof (EnumLotteResultCodeType)))
      {
        if (lotteResultCodeType == (EnumLotteResultCodeType) pValue)
          return lotteResultCodeType;
      }
      return EnumLotteResultCodeType.None;
    }

    public static EnumSmsPayType GetSmsPayType(int pValue)
    {
      foreach (EnumSmsPayType smsPayType in Enum.GetValues(typeof (EnumSmsPayType)))
      {
        if (smsPayType == (EnumSmsPayType) pValue)
          return smsPayType;
      }
      return EnumSmsPayType.None;
    }

    public static bool IsSmsPayTypeBefore(int p_value) => p_value == 1;

    public static bool IsSmsPayTypeAfter(int p_value) => p_value == 2;

    public static EnumDeliveryMovingStatus GetDeliveryMovingStatus(int pValue)
    {
      foreach (EnumDeliveryMovingStatus deliveryMovingStatus in Enum.GetValues(typeof (EnumDeliveryMovingStatus)))
      {
        if (deliveryMovingStatus == (EnumDeliveryMovingStatus) pValue)
          return deliveryMovingStatus;
      }
      return EnumDeliveryMovingStatus.NONE;
    }

    public static EnumMessageReqType GetMessageReqType(int pValue)
    {
      foreach (EnumMessageReqType messageReqType in Enum.GetValues(typeof (EnumMessageReqType)))
      {
        if (messageReqType == (EnumMessageReqType) pValue)
          return messageReqType;
      }
      return EnumMessageReqType.None;
    }

    public static EnumLotteTemplateStatue GetLotteTemplateStatue(int pValue)
    {
      foreach (EnumLotteTemplateStatue lotteTemplateStatue in Enum.GetValues(typeof (EnumLotteTemplateStatue)))
      {
        if (lotteTemplateStatue == (EnumLotteTemplateStatue) pValue)
          return lotteTemplateStatue;
      }
      return EnumLotteTemplateStatue.None;
    }

    public static EnumLotteTemplateStatue GetLotteTemplateStatue(string pValue)
    {
      if (pValue == null || pValue.Length == 0 || pValue.Length > 1)
        return EnumLotteTemplateStatue.None;
      string str = pValue;
      int index = 0;
      return index < str.Length ? Enum2StrConverter.GetLotteTemplateStatue((int) str[index]) : EnumLotteTemplateStatue.None;
    }

    public static EnumLotteTemplateMessageType GetLotteTemplateMessageType(int pValue)
    {
      foreach (EnumLotteTemplateMessageType templateMessageType in Enum.GetValues(typeof (EnumLotteTemplateMessageType)))
      {
        if (templateMessageType == (EnumLotteTemplateMessageType) pValue)
          return templateMessageType;
      }
      return EnumLotteTemplateMessageType.None;
    }

    public static EnumLotteTemplateMessageType GetLotteTemplateMessageTypeFromString(string pValue)
    {
      foreach (EnumLotteTemplateMessageType messageTypeFromString in Enum.GetValues(typeof (EnumLotteTemplateMessageType)))
      {
        if (messageTypeFromString.ToString().Equals(pValue))
          return messageTypeFromString;
      }
      return EnumLotteTemplateMessageType.None;
    }

    public static EnumLotteTemplateEmphasizeType GetLotteTemplateEmphasizeType(int pValue)
    {
      foreach (EnumLotteTemplateEmphasizeType templateEmphasizeType in Enum.GetValues(typeof (EnumLotteTemplateEmphasizeType)))
      {
        if (templateEmphasizeType == (EnumLotteTemplateEmphasizeType) pValue)
          return templateEmphasizeType;
      }
      return EnumLotteTemplateEmphasizeType.None;
    }

    public static EnumLotteTemplateEmphasizeType GetLotteTemplateEmphasizeTypeFromString(
      string pValue)
    {
      foreach (EnumLotteTemplateEmphasizeType emphasizeTypeFromString in Enum.GetValues(typeof (EnumLotteTemplateEmphasizeType)))
      {
        if (emphasizeTypeFromString.ToString().Equals(pValue))
          return emphasizeTypeFromString;
      }
      return EnumLotteTemplateEmphasizeType.None;
    }

    public static EnumLotteKakaoButtonType GetLotteKakaoButtonType(int pValue)
    {
      foreach (EnumLotteKakaoButtonType lotteKakaoButtonType in Enum.GetValues(typeof (EnumLotteKakaoButtonType)))
      {
        if (lotteKakaoButtonType == (EnumLotteKakaoButtonType) pValue)
          return lotteKakaoButtonType;
      }
      return EnumLotteKakaoButtonType.NONE;
    }

    public static EnumLotteKakaoButtonType GetLotteKakaoButtonType(string pValue)
    {
      if (pValue == null || pValue.Length == 0 || pValue.Length > 1)
        return EnumLotteKakaoButtonType.NONE;
      foreach (EnumLotteKakaoButtonType lotteKakaoButtonType in Enum.GetValues(typeof (EnumLotteKakaoButtonType)))
      {
        if (lotteKakaoButtonType.ToString().Equals(pValue))
          return lotteKakaoButtonType;
      }
      return EnumLotteKakaoButtonType.NONE;
    }

    public static EnumDeliveryOrderByType GetDeliveryOrderByType(int pValue)
    {
      foreach (EnumDeliveryOrderByType deliveryOrderByType in Enum.GetValues(typeof (EnumDeliveryOrderByType)))
      {
        if (deliveryOrderByType == (EnumDeliveryOrderByType) pValue)
          return deliveryOrderByType;
      }
      return EnumDeliveryOrderByType.None;
    }

    public static EnumGoodsEventDisplayType GetGoodsEventDisplayType(int pValue)
    {
      foreach (EnumGoodsEventDisplayType eventDisplayType in Enum.GetValues(typeof (EnumGoodsEventDisplayType)))
      {
        if (eventDisplayType == (EnumGoodsEventDisplayType) pValue)
          return eventDisplayType;
      }
      return EnumGoodsEventDisplayType.None;
    }

    public static EnumTermsOfUseType GetTermsOfUseType(int pValue)
    {
      foreach (EnumTermsOfUseType termsOfUseType in Enum.GetValues(typeof (EnumTermsOfUseType)))
      {
        if (termsOfUseType == (EnumTermsOfUseType) pValue)
          return termsOfUseType;
      }
      return EnumTermsOfUseType.None;
    }

    public static EnumCategoryBannerType GetCategoryBannerType(int pValue)
    {
      foreach (EnumCategoryBannerType categoryBannerType in Enum.GetValues(typeof (EnumCategoryBannerType)))
      {
        if (categoryBannerType == (EnumCategoryBannerType) pValue)
          return categoryBannerType;
      }
      return EnumCategoryBannerType.None;
    }

    public static EnumMallMainStartPageType GetMallMainStartPageType(int pValue)
    {
      foreach (EnumMallMainStartPageType mainStartPageType in Enum.GetValues(typeof (EnumMallMainStartPageType)))
      {
        if (mainStartPageType == (EnumMallMainStartPageType) pValue)
          return mainStartPageType;
      }
      return EnumMallMainStartPageType.None;
    }

    public static EnumLotteNoticeTemplateType ToLotteNoticeTemplateType(int pValue)
    {
      foreach (EnumLotteNoticeTemplateType noticeTemplateType in Enum.GetValues(typeof (EnumLotteNoticeTemplateType)))
      {
        if (noticeTemplateType == (EnumLotteNoticeTemplateType) pValue)
          return noticeTemplateType;
      }
      return EnumLotteNoticeTemplateType.None;
    }

    public static JobEvtInfoByIdDic Dic_JobEvtInfoById { get; set; }

    public static ProgOptionBySiteDic Dic_ProgOptionBySite { get; set; }

    public static SiteCommonCodeGroupDic Dic_SiteCommonCodes { get; set; }

    public static UniSiteGroup UniSiteInfo { get; set; }

    public static JobEvtInfoById ToJobEvtInfoById(string p_SendType)
    {
      if (Enum2StrConverter.Dic_JobEvtInfoById == null)
        return (JobEvtInfoById) null;
      return !Enum2StrConverter.Dic_JobEvtInfoById.ContainsKey(p_SendType) ? (JobEvtInfoById) null : Enum2StrConverter.Dic_JobEvtInfoById[p_SendType];
    }

    public static JobEvtInfo ToJobEvtInfo(string p_SendType, string p_JobId)
    {
      if (Enum2StrConverter.Dic_JobEvtInfoById == null)
        return (JobEvtInfo) null;
      return !Enum2StrConverter.Dic_JobEvtInfoById.ContainsKey(p_SendType) ? (JobEvtInfo) null : Enum2StrConverter.Dic_JobEvtInfoById[p_SendType].Where<JobEvtInfo>((Func<JobEvtInfo, bool>) (it => it.JobId.Equals(p_JobId))).FirstOrDefault<JobEvtInfo>();
    }

    public static ProgOptionView ToProgOptionInfo(
      long p_opt_SiteID,
      int p_opt_StoreCode,
      EnumOptionType p_opt_Code)
    {
      if (Enum2StrConverter.Dic_ProgOptionBySite == null)
        return (ProgOptionView) null;
      if (!Enum2StrConverter.Dic_ProgOptionBySite.ContainsKey(p_opt_SiteID))
        return (ProgOptionView) null;
      return !Enum2StrConverter.Dic_ProgOptionBySite[p_opt_SiteID].ContainsKey(p_opt_StoreCode) ? (ProgOptionView) null : Enum2StrConverter.Dic_ProgOptionBySite[p_opt_SiteID][p_opt_StoreCode].Where<ProgOptionView>((Func<ProgOptionView, bool>) (it => (EnumOptionType) it.opt_Code == p_opt_Code)).FirstOrDefault<ProgOptionView>();
    }

    public static IList<ProgOptionView> ToProgOptionList(
      long p_opt_SiteID,
      EnumOptionType p_opt_Code)
    {
      if (Enum2StrConverter.Dic_ProgOptionBySite == null)
        return (IList<ProgOptionView>) null;
      if (!Enum2StrConverter.Dic_ProgOptionBySite.ContainsKey(p_opt_SiteID))
        return (IList<ProgOptionView>) null;
      IList<ProgOptionView> progOptionList = (IList<ProgOptionView>) new List<ProgOptionView>();
      foreach (KeyValuePair<int, ProgOptionByStore> keyValuePair in Enum2StrConverter.Dic_ProgOptionBySite[p_opt_SiteID])
      {
        foreach (ProgOptionView progOptionView in keyValuePair.Value.Items)
        {
          if ((EnumOptionType) progOptionView.opt_Code == p_opt_Code)
            progOptionList.Add(progOptionView);
        }
      }
      return progOptionList;
    }

    public static CommonCodeView ToCommonCodeInfo(
      long p_comm_SiteID,
      EnumCommonCodeType p_comm_Type,
      int p_comm_TypeNo)
    {
      if (Enum2StrConverter.Dic_SiteCommonCodes == null)
        return (CommonCodeView) null;
      if (!Enum2StrConverter.Dic_SiteCommonCodes.ContainsKey(p_comm_SiteID))
        return (CommonCodeView) null;
      return !Enum2StrConverter.Dic_SiteCommonCodes[p_comm_SiteID].ContainsKey((int) p_comm_Type) ? (CommonCodeView) null : Enum2StrConverter.Dic_SiteCommonCodes[p_comm_SiteID][(int) p_comm_Type].FirstOrDefault<CommonCodeView>((Func<CommonCodeView, bool>) (it => it.comm_TypeNo == p_comm_TypeNo));
    }

    public static string ToCommonCodeTypeMemo(
      long p_comm_SiteID,
      EnumCommonCodeType p_comm_Type,
      int p_comm_TypeNo)
    {
      CommonCodeView commonCodeInfo = Enum2StrConverter.ToCommonCodeInfo(p_comm_SiteID, p_comm_Type, p_comm_TypeNo);
      return commonCodeInfo != null && commonCodeInfo.comm_TypeNo != 0 ? commonCodeInfo.comm_TypeNoMemo : string.Empty;
    }

    public static UniSiteView ToUniSite(long p_uis_SiteID) => Enum2StrConverter.UniSiteInfo == null ? (UniSiteView) null : Enum2StrConverter.UniSiteInfo[p_uis_SiteID];

    public static bool IsActionLog(long p_uis_SiteID)
    {
      UniSiteView uniSite = Enum2StrConverter.ToUniSite(p_uis_SiteID);
      return uniSite != null && uniSite.IsEmpActionLog;
    }

    public static bool IsDataModLog(long p_uis_SiteID)
    {
      UniSiteView uniSite = Enum2StrConverter.ToUniSite(p_uis_SiteID);
      return uniSite != null && uniSite.IsDataModLog;
    }

    public static EnumCommonCodeFixedType ToCommonCodeFixed(int p_value)
    {
      foreach (EnumCommonCodeFixedType commonCodeFixed in Enum.GetValues(typeof (EnumCommonCodeFixedType)))
      {
        if (commonCodeFixed == (EnumCommonCodeFixedType) p_value)
          return commonCodeFixed;
      }
      return EnumCommonCodeFixedType.None;
    }

    public static bool IsCommonCodeFixedType(int p_value) => Enum2StrConverter.ToCommonCodeFixed(p_value) != 0;

    public static TableCodeType ToTableType(int p_value)
    {
      foreach (TableCodeType tableType in Enum.GetValues(typeof (TableCodeType)))
      {
        if (tableType == (TableCodeType) p_value)
          return tableType;
      }
      return TableCodeType.Unknown;
    }

    public static bool IsTableStatusSuccess(EnumTableStatus p_value) => p_value == EnumTableStatus.NEW || p_value == EnumTableStatus.RE_INPUT;

    public static bool IsTableStatusSuccess(int p_value) => p_value == 1 || p_value == 2;

    public static bool IsTableStatusError(EnumTableStatus p_value) => p_value == EnumTableStatus.ERROR;

    public static bool IsTableStatusError(int p_value) => p_value == 3;

    public static EnumEmpActionKind ToEmpActionKind(int p_value)
    {
      foreach (EnumEmpActionKind empActionKind in Enum.GetValues(typeof (EnumEmpActionKind)))
      {
        if (empActionKind == (EnumEmpActionKind) p_value)
          return empActionKind;
      }
      return EnumEmpActionKind.NONE;
    }

    public static EnumGoodsHistoryUpdateType ToGoodsHistoryUpdateType(int p_value)
    {
      foreach (EnumGoodsHistoryUpdateType historyUpdateType in Enum.GetValues(typeof (EnumGoodsHistoryUpdateType)))
      {
        if (historyUpdateType == (EnumGoodsHistoryUpdateType) p_value)
          return historyUpdateType;
      }
      return EnumGoodsHistoryUpdateType.None;
    }

    public static EnumTableColumnStatus ToTableColumnStatus(int p_value)
    {
      foreach (EnumTableColumnStatus tableColumnStatus in Enum.GetValues(typeof (EnumTableColumnStatus)))
      {
        if (tableColumnStatus == (EnumTableColumnStatus) p_value)
          return tableColumnStatus;
      }
      return EnumTableColumnStatus.None;
    }

    public static EnumFontWeight ToFontWeight(int pValue)
    {
      foreach (EnumFontWeight fontWeight in Enum.GetValues(typeof (EnumFontWeight)))
      {
        if (fontWeight == (EnumFontWeight) pValue)
          return fontWeight;
      }
      return EnumFontWeight.None;
    }

    public static EnumFontStyle ToFontStyle(int pValue)
    {
      foreach (EnumFontStyle fontStyle in Enum.GetValues(typeof (EnumFontStyle)))
      {
        if (fontStyle == (EnumFontStyle) pValue)
          return fontStyle;
      }
      return EnumFontStyle.None;
    }

    public static EnumZeroCheck ToZeroCheck(int pValue)
    {
      foreach (EnumZeroCheck zeroCheck in Enum.GetValues(typeof (EnumZeroCheck)))
      {
        if (zeroCheck == (EnumZeroCheck) pValue)
          return zeroCheck;
      }
      return EnumZeroCheck.None;
    }

    public static bool IsZeroCheckSubsetAmount(int pValue) => (pValue & 1) == 1;

    public static bool IsZeroCheckSubsetAmount(EnumZeroCheck pValue) => Enum2StrConverter.IsZeroCheckSubsetAmount((int) pValue);

    public static bool IsZeroCheckSubsetQty(int pValue) => (pValue & 2) == 2;

    public static bool IsZeroCheckSubsetQty(EnumZeroCheck pValue) => Enum2StrConverter.IsZeroCheckSubsetQty((int) pValue);

    public static EnumRowType ToRowType(int pValue)
    {
      foreach (EnumRowType rowType in Enum.GetValues(typeof (EnumRowType)))
      {
        if (rowType == (EnumRowType) pValue)
          return rowType;
      }
      return EnumRowType.None;
    }

    public static EnumRowTimeStatus ToRowTimeStatus(int pValue)
    {
      foreach (EnumRowTimeStatus rowTimeStatus in Enum.GetValues(typeof (EnumRowTimeStatus)))
      {
        if (rowTimeStatus == (EnumRowTimeStatus) pValue)
          return rowTimeStatus;
      }
      return EnumRowTimeStatus.None;
    }

    public static EnumRowDateCondition ToRowDateCondition(int pValue)
    {
      foreach (EnumRowDateCondition rowDateCondition in Enum.GetValues(typeof (EnumRowDateCondition)))
      {
        if (rowDateCondition == (EnumRowDateCondition) pValue)
          return rowDateCondition;
      }
      return EnumRowDateCondition.None;
    }

    public static EnumContionDayBeforeType ToContionDayBeforeType(int pValue)
    {
      foreach (EnumContionDayBeforeType contionDayBeforeType in Enum.GetValues(typeof (EnumContionDayBeforeType)))
      {
        if (contionDayBeforeType == (EnumContionDayBeforeType) pValue)
          return contionDayBeforeType;
      }
      return EnumContionDayBeforeType.None;
    }

    public static EnumSearchType ToSearchType(int pValue)
    {
      foreach (EnumSearchType searchType in Enum.GetValues(typeof (EnumSearchType)))
      {
        if (searchType == (EnumSearchType) pValue)
          return searchType;
      }
      return EnumSearchType.None;
    }

    public static EnumSupplierSearchType ToSupplierSearchType(int pValue)
    {
      foreach (EnumSupplierSearchType supplierSearchType in Enum.GetValues(typeof (EnumSupplierSearchType)))
      {
        if (supplierSearchType == (EnumSupplierSearchType) pValue)
          return supplierSearchType;
      }
      return EnumSupplierSearchType.None;
    }

    public static EnumOptionType ToOptionType(int pValue)
    {
      foreach (EnumOptionType optionType in Enum.GetValues(typeof (EnumOptionType)))
      {
        if (optionType == (EnumOptionType) pValue)
          return optionType;
      }
      return EnumOptionType.None;
    }
  }
}
