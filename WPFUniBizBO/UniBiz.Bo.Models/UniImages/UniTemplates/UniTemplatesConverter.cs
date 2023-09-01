// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniImages.UniTemplates.UniTemplatesConverter
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;

namespace UniBiz.Bo.Models.UniImages.UniTemplates
{
  public class UniTemplatesConverter
  {
    public const string ftf_ID = "ID";
    public const string ftf_SiteID = "싸이트";
    public const string ftf_Title = "타이틀";
    public const string ftf_Url = "URL";
    public const string ftf_FileName = "파일명";
    public const string ftf_ThumbData = "썸네일";
    public const string ftf_OriginData = "템플릿";
    public const string ftf_OriginHash = "템플릿 Hash";
    public const string ltf_ID = "ID";
    public const string ltf_SiteID = "싸이트";
    public const string ltf_Title = "타이틀";
    public const string ltf_Url = "URL";
    public const string ltf_FileName = "파일명";
    public const string ltf_ThumbData = "썸네일";
    public const string ltf_OriginData = "템플릿";
    public const string ltf_OriginHash = "템플릿 Hash";
    public const string ltc_ID = "컬럼ID";
    public const string ltc_Seq = "순번";
    public const string ltc_SiteID = "싸이트";
    public const string ltc_ColID = "오브젝트ID";
    public const string ltc_FormatDataID = "포멧터ID";
    public const string ltc_Count = "카운터";
    public const string ltc_Point = "포인터";
    public const string IDS_SIGNATURE_TEXT = "Uniinfo/UniPaperCore";

    public static EnumUniTemplateDiv ToUniTemplateDiv(int p_value)
    {
      foreach (EnumUniTemplateDiv uniTemplateDiv in Enum.GetValues(typeof (EnumUniTemplateDiv)))
      {
        if (uniTemplateDiv == (EnumUniTemplateDiv) p_value)
          return uniTemplateDiv;
      }
      return EnumUniTemplateDiv.MAX;
    }

    public static bool IsSignatureText(string p_value) => "Uniinfo/UniPaperCore".Equals(p_value);
  }
}
