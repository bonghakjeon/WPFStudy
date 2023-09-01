// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumAppType
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumAppType
  {
    [Description("-APP-")] NONE,
    [Description("UniBizApi")] UniBizApi,
    [Description("WebDriver")] WebDriver,
    [Description("LabelMaker")] LabelMaker,
    [Description("PopMaker")] PopMaker,
    [Description("UniBizSM")] UniBizSM,
    [Description("UNIHTStockMgr")] UNIHTStockMgr,
    [Description("UniBizPos")] UniBizPos,
    [Description("UniCallClient")] UniCallClient,
    [Description("UniBizSCM")] UniBizSCM,
    [Description("UniBizMiddleServer")] UniBizMiddleServer,
    [Description("UniBizTMobileApi")] BizTMobileApi,
    [Description("UniBizTMobile")] BizTMobile,
    [Description("UniBizKiosk")] UniBizKiosk,
    [Description("UniBizPosApi")] UniBizPosApi,
    [Description("UniBizMobilePOS")] UniBizMobilePOS,
    [Description("UniLink.Kakao.Api")] UniLinkApi,
    [Description("UniLink.Neo.Api")] UniLinkNeoApi,
    [Description("UniBizSmsWeb")] UniBizSmsWeb,
    [Description("UniLink.Kakao.Sender")] UniLinkKakaoSender,
    [Description("UniBizDeliveryBoard")] UniBizDeliveryBoard,
    [Description("UniBizDeliveryPOS")] UniBizDeliveryPOS,
    [Description("UniBizMallAdmin")] UniBizMallAdmin,
    [Description("UniBizMall")] UniBizMall,
    [Description("UniLink.Delivery.Api")] UniLinkDeliveryApi,
    [Description("UniBiz.Bo.api")] UniBizBoApi,
    [Description("UniBizBO")] UniBizBO,
    [Description("UniBiz.Middle.Outer.Api")] UniBizMiddleOuterApi,
    [Description("UniBizMiddleOuterFront")] UniBizMiddleOuterFront,
  }
}
