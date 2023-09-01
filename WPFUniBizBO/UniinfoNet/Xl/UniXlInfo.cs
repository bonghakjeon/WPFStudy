// Decompiled with JetBrains decompiler
// Type: UniinfoNet.Xl.UniXlInfo
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

using System.Collections.Generic;

namespace UniinfoNet.Xl
{
  public class UniXlInfo
  {
    private List<UniXlSheetInfo> sheets;

    public UniXlInfo()
    {
    }

    public UniXlInfo(params UniXlSheetInfo[] sheets)
      : this()
    {
      this.Sheets.AddRange((IEnumerable<UniXlSheetInfo>) sheets);
    }

    public string Name { get; set; }

    public List<UniXlSheetInfo> Sheets
    {
      get => this.sheets ?? (this.sheets = new List<UniXlSheetInfo>());
      set => this.sheets = value;
    }
  }
}
