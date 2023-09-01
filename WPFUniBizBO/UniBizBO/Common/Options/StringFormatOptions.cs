// Decompiled with JetBrains decompiler
// Type: UniBizBO.Common.Options.StringFormatOptions
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

namespace UniBizBO.Common.Options
{
  public class StringFormatOptions
  {
    public static string Number_Default { get; set; } = "#,###";

    public static string Number_0 { get; set; } = "#,##0 .";

    public static string Number_Double_2 { get; set; } = "#,##0.00 .";

    public static string Number_Double_4 { get; set; } = "#,##0.0000 .";

    public static string DateTime_Default { get; set; } = "yyyy-MM-dd HH:mm:ss";

    public static string DateTime_Date { get; set; } = "yyyy-MM-dd";
  }
}
