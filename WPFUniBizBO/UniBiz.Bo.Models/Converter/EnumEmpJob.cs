// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumEmpJob
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumEmpJob
  {
    [Description("-직책-")] NONE,
    [Description("팀원")] MEMBER,
    [Description("팀장")] TEAM,
    [Description("파트장")] PART,
    [Description("그룹장")] GROUP,
    [Description("부문장")] DIVISION,
    [Description("CEO")] CEO,
  }
}
