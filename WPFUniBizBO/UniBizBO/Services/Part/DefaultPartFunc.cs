// Decompiled with JetBrains decompiler
// Type: UniBizBO.Services.Part.DefaultPartFunc
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

namespace UniBizBO.Services.Part
{
  public class DefaultPartFunc : DefaultFuncBase
  {
    public static DefaultPartFunc None { get; } = new DefaultPartFunc(nameof (None));

    public static DefaultPartFunc Search { get; } = new DefaultPartFunc(nameof (Search));

    public static DefaultPartFunc Save { get; } = new DefaultPartFunc(nameof (Save));

    public static DefaultPartFunc Clear { get; } = new DefaultPartFunc(nameof (Clear));

    public static DefaultPartFunc Print { get; } = new DefaultPartFunc(nameof (Print));

    public static DefaultPartFunc ExportPDF { get; } = new DefaultPartFunc(nameof (ExportPDF));

    public static DefaultPartFunc ExportExcel { get; } = new DefaultPartFunc(nameof (ExportExcel));

    public static DefaultPartFunc Help { get; } = new DefaultPartFunc(nameof (Help));

    public DefaultPartFunc(string name)
      : base(name)
    {
    }
  }
}
