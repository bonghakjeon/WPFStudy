// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniImages.UniTemplates.EnumUniTemplateDiv
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.UniImages.UniTemplates
{
  public enum EnumUniTemplateDiv
  {
    [Description("파일시그니처")] SIGNATURE = 0,
    [Description("헤더길이")] HEAD_LENGTH = 1,
    [Description("헤더")] HEAD = 2,
    [Description("메타데이터길이")] MATADATA_LENGTH = 3,
    [Description("메타데이터")] MATADATA = 4,
    [Description("컨텐츠길이")] CONTENTS_LENGTH = 5,
    [Description("컨텐츠")] CONTENTS = 6,
    [Description("썸네일길이")] THUMB_LENGTH = 7,
    [Description("썸네일")] THUMB = 8,
    MAX = 9,
    SIGNATURE_MAX = 50, // 0x00000032
  }
}
