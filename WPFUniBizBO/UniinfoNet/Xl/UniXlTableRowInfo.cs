// Decompiled with JetBrains decompiler
// Type: UniinfoNet.Xl.UniXlTableRowInfo
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

using System.Collections.Generic;
using System.Drawing;

namespace UniinfoNet.Xl
{
  public class UniXlTableRowInfo
  {
    private List<UniXlTableCellInfo> cells;

    public List<UniXlTableCellInfo> Cells
    {
      get => this.cells ?? (this.cells = new List<UniXlTableCellInfo>());
      set => this.cells = value;
    }

    public Color? Background { get; set; }

    public Color? Foreground { get; set; }

    public override string ToString() => string.Format("{0} [{1}]", (object) "Cells", (object) this.Cells.Count);
  }
}
