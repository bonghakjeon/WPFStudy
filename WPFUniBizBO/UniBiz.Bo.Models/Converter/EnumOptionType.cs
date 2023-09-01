// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumOptionType
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumOptionType
  {
    None = -1, // 0xFFFFFFFF
    opt_SystemCode = 0,
    opt_HomePage = 1,
    opt_WeightBarcodeLen = 2,
    opt_MemPriceGroup = 3,
    opt_AutoOrderStandard = 4,
    opt_DualPriceGroupStandard = 5,
    opt_InvoiceStyle = 6,
    opt_PurChangeItemType = 7,
    opt_PurPricesChanges = 8,
    opt_PurPriceDown = 9,
    opt_GrantItemType = 10, // 0x0000000A
    opt_OnlySiteMember = 11, // 0x0000000B
    opt_MemberPointRateType = 12, // 0x0000000C
    opt_WeightStockType = 13, // 0x0000000D
    opt_UsingSupCostOptionOnTerminal = 14, // 0x0000000E
    opt_TerminalItemExclude = 15, // 0x0000000F
    opt_TerminalDevice = 16, // 0x00000010
    opt_DataKeepingDaysStore = 17, // 0x00000011
    opt_DataKeepingDaysPOS = 18, // 0x00000012
    opt_WeatherDaily = 19, // 0x00000013
    opt_WeatherMonth = 20, // 0x00000014
    opt_DeductionInit = 21, // 0x00000015
    opt_ItemImageSupport = 22, // 0x00000016
    opt_ErpUploadLink = 23, // 0x00000017
    opt_ErpUploadType = 24, // 0x00000018
    opt_DaemonOptions = 25, // 0x00000019
    opt_StoreCodeLen = 26, // 0x0000001A
    opt_CreditPaymentType = 27, // 0x0000001B
    opt_SaleSearchMonthBeforeAfter = 28, // 0x0000001C
    opt_point_ExcDcEventItem = 200, // 0x000000C8
    opt_Point_Change2Point = 201, // 0x000000C9
    opt_Point_Change2Rate = 202, // 0x000000CA
    opt_Point_Change2PayPoint = 203, // 0x000000CB
    opt_Point_NewMemberPoint = 204, // 0x000000CC
    opt_Point_NewMemberSMSAutoSend = 205, // 0x000000CD
    opt_Point_PayForMinSumPoint = 206, // 0x000000CE
    opt_Point_WebInterface = 207, // 0x000000CF
    opt_Point_Birthday = 208, // 0x000000D0
    opt_Point_MemorialDay = 209, // 0x000000D1
    opt_Point_NonMemberType = 210, // 0x000000D2
    opt_Point_PaySearchText = 211, // 0x000000D3
    opt_ItemDescOption = 212, // 0x000000D4
    opt_LiquorBeer = 213, // 0x000000D5
    opt_LiquorWhiskey = 214, // 0x000000D6
    opt_LiquorSoju = 215, // 0x000000D7
    opt_LiquorEtc = 216, // 0x000000D8
    opt_ServiceKeyZipcode = 217, // 0x000000D9
    opt_MemberUniqueFields = 218, // 0x000000DA
    opt_POS_ItemCancel = 301, // 0x0000012D
    opt_POS_SalesCancel = 302, // 0x0000012E
    opt_POS_PayExpense = 303, // 0x0000012F
    opt_POS_PriceChange = 304, // 0x00000130
    opt_POS_AllDiscounts = 305, // 0x00000131
    opt_POS_RegistReturn = 306, // 0x00000132
    opt_POS_RegistReturnBySalesDetail = 307, // 0x00000133
    opt_POS_PayMemberPoint = 308, // 0x00000134
    opt_POS_DeliveryBillCopy = 309, // 0x00000135
    opt_POS_TRControl = 310, // 0x00000136
    opt_POS_DefaultBoxQty = 311, // 0x00000137
    opt_POS_PayTrust = 312, // 0x00000138
    opt_POS_DuplicateScan = 313, // 0x00000139
    opt_POS_PrintESignatureCopy = 314, // 0x0000013A
    opt_POS_ReturnWhileSales = 315, // 0x0000013B
    opt_POS_CDPSizeMode = 316, // 0x0000013C
    opt_POS_CDPSizeWaitTime = 317, // 0x0000013D
    opt_POS_CDPMsgScrollTime = 318, // 0x0000013E
    opt_POS_AutoCashReceipt = 319, // 0x0000013F
    opt_POS_PrintESignature = 320, // 0x00000140
    opt_POS_AlwaysMemberSearch = 321, // 0x00000141
    POS_SlipForm = 322, // 0x00000142
    opt_POS_ReceiptHeaderPrint = 323, // 0x00000143
    opt_POS_ReceiptFooterPrint = 324, // 0x00000144
    opt_POS_ReceiptFormPrint = 325, // 0x00000145
    opt_POS_ReturnReceiptCopy = 326, // 0x00000146
    opt_POS_CancelReceiptCopy = 327, // 0x00000147
    opt_POS_PrintMemberInfo = 328, // 0x00000148
    opt_POS_PrintPendingReceipt = 329, // 0x00000149
    opt_POS_UnpaidReceiptCopy = 330, // 0x0000014A
    opt_POS_AmountOfNoCVM = 331, // 0x0000014B
    opt_POS_PrintMoneyTypes = 332, // 0x0000014C
    opt_POS_RuntimeFlags = 333, // 0x0000014D
    opt_POS_ItemSearchType = 334, // 0x0000014E
    opt_POS_DeliveryOptions = 335, // 0x0000014F
    opt_CutOutCalc = 336, // 0x00000150
    opt_Msg_CDP_HeadMessageBegin = 350, // 0x0000015E
    opt_Msg_CDP_HeadMessageEnd = 354, // 0x00000162
    opt_Msg_CDP_SiteMessageBegin = 355, // 0x00000163
    opt_Msg_CDP_SiteMessageEnd = 359, // 0x00000167
    opt_Msg_POS_HeadMessageBegin = 360, // 0x00000168
    opt_Msg_POS_SiteMessageEnd = 365, // 0x0000016D
    opt_Receipt_TopMsgBegin = 370, // 0x00000172
    opt_Receipt_TopMsgEnd = 374, // 0x00000176
    opt_Receipt_BottomMsgBegin = 375, // 0x00000177
    opt_Receipt_BottomMsgEnd = 399, // 0x0000018F
  }
}
