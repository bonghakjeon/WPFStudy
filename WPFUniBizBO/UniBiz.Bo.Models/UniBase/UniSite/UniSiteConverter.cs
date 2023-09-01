// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.UniSite.UniSiteConverter
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

namespace UniBiz.Bo.Models.UniBase.UniSite
{
  public static class UniSiteConverter
  {
    public const string uis_SiteID = "사이트";
    public const string uis_SiteViewCode = "사이트뷰코드";
    public const string uis_SiteName = "사이트명";
    public const string uis_SiteType = "사이트타입";
    public const string uis_AddProperty = "속성타입";
    public const string usi_StoreCount = "지점건수";

    public static bool IsEmpActionLog(int pValue) => (1 & pValue) == 1;

    public static bool IsDataModLog(int pValue) => (2 & pValue) == 2;
  }
}
