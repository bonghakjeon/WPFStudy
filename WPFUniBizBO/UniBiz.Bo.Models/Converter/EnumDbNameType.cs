﻿// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumDbNameType
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumDbNameType
  {
    [Description("-DB Name-")] None,
    [Description("UniBase")] UniBase,
    [Description("UniSales")] UniSales,
    [Description("UniTrData")] UniTrData,
    [Description("UniStock")] UniStock,
    [Description("UniMembers")] UniMembers,
    [Description("UniInterface")] UniInterface,
    [Description("UniSMS")] UniSMS,
    [Description("UniPop")] UniPop,
    [Description("UniImages")] UniImages,
    [Description("UniCampaign")] UniCampaign,
  }
}
