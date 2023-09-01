// Decompiled with JetBrains decompiler
// Type: UniBizBO.Services.Page.SystemPageAttribute
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using System;

namespace UniBizBO.Services.Page
{
  [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
  public class SystemPageAttribute : BaseAttribute
  {
    public string Lv1Name { get; set; } = "디버그";

    public string Lv2Name { get; set; }

    public string Lv3Name { get; set; }

    public string Lv4Name { get; set; }

    public SystemPageAttribute(string lv2Name, string lv3Name, string lv4Name)
    {
      this.Lv2Name = lv2Name;
      this.Lv3Name = lv3Name;
      this.Lv4Name = lv4Name;
    }

    public SystemPageAttribute(string lv1Name, string lv2Name, string lv3Name, string lv4Name)
    {
      this.Lv1Name = lv1Name;
      this.Lv2Name = lv2Name;
      this.Lv3Name = lv3Name;
      this.Lv4Name = lv4Name;
    }
  }
}
