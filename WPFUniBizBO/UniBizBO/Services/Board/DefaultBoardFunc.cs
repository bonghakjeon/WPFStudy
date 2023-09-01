// Decompiled with JetBrains decompiler
// Type: UniBizBO.Services.Board.DefaultBoardFunc
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

namespace UniBizBO.Services.Board
{
  public class DefaultBoardFunc : DefaultFuncBase
  {
    public static DefaultBoardFunc None { get; } = new DefaultBoardFunc(nameof (None));

    public static DefaultBoardFunc Confirm { get; } = new DefaultBoardFunc(nameof (Confirm));

    public static DefaultBoardFunc Select { get; } = new DefaultBoardFunc(nameof (Select));

    public static DefaultBoardFunc Create { get; } = new DefaultBoardFunc(nameof (Create));

    public static DefaultBoardFunc Search { get; } = new DefaultBoardFunc(nameof (Search));

    public static DefaultBoardFunc Save { get; } = new DefaultBoardFunc(nameof (Save));

    public static DefaultBoardFunc Remove { get; } = new DefaultBoardFunc(nameof (Remove));

    public static DefaultBoardFunc Clear { get; } = new DefaultBoardFunc(nameof (Clear));

    public static DefaultBoardFunc Print { get; } = new DefaultBoardFunc(nameof (Print));

    public static DefaultBoardFunc ExportPDF { get; } = new DefaultBoardFunc(nameof (ExportPDF));

    public static DefaultBoardFunc ExportExcel { get; } = new DefaultBoardFunc(nameof (ExportExcel));

    public static DefaultBoardFunc Help { get; } = new DefaultBoardFunc(nameof (Help));

    public static DefaultBoardFunc Close { get; } = new DefaultBoardFunc(nameof (Close));

    public static DefaultBoardFunc Callback { get; } = new DefaultBoardFunc(nameof (Callback));

    public DefaultBoardFunc(string name)
      : base(name)
    {
    }
  }
}
