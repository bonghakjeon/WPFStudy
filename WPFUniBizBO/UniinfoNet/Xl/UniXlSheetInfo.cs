// Decompiled with JetBrains decompiler
// Type: UniinfoNet.Xl.UniXlSheetInfo
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

using System.Collections.Generic;

namespace UniinfoNet.Xl
{
  public class UniXlSheetInfo
  {
    private List<UniXlTableInfo> tables;

    public UniXlSheetInfo()
    {
    }

    public UniXlSheetInfo(params UniXlTableInfo[] tables)
      : this()
    {
      this.Tables.AddRange((IEnumerable<UniXlTableInfo>) tables);
    }

    public string Name { get; set; }

    public List<UniXlTableInfo> Tables
    {
      get => this.tables ?? (this.tables = new List<UniXlTableInfo>());
      set => this.tables = value;
    }

    public int SplitCellLength { get; set; } = 1;
  }
}
