// Decompiled with JetBrains decompiler
// Type: UniBizBO.Services.Page.DefaultPageFunc
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

namespace UniBizBO.Services.Page
{
  public class DefaultPageFunc : DefaultFuncBase
  {
    public static DefaultPageFunc None { get; } = new DefaultPageFunc(nameof (None));

    public static DefaultPageFunc Create { get; } = new DefaultPageFunc(nameof (Create));

    public static DefaultPageFunc Search { get; } = new DefaultPageFunc(nameof (Search));

    public static DefaultPageFunc Save { get; } = new DefaultPageFunc(nameof (Save));

    public static DefaultPageFunc Remove { get; } = new DefaultPageFunc(nameof (Remove));

    public static DefaultPageFunc Clear { get; } = new DefaultPageFunc(nameof (Clear));

    public static DefaultPageFunc Print { get; } = new DefaultPageFunc(nameof (Print));

    public static DefaultPageFunc ExportPDF { get; } = new DefaultPageFunc(nameof (ExportPDF));

    public static DefaultPageFunc ExportExcel { get; } = new DefaultPageFunc(nameof (ExportExcel));

    public static DefaultPageFunc PrintLabel { get; } = new DefaultPageFunc(nameof (PrintLabel));

    public static DefaultPageFunc Help { get; } = new DefaultPageFunc(nameof (Help));

    public static DefaultPageFunc Close { get; } = new DefaultPageFunc(nameof (Close));

    public static DefaultPageFunc BookMark { get; } = new DefaultPageFunc(nameof (BookMark));

    public DefaultPageFunc(string name)
      : base(name)
    {
    }
  }
}
