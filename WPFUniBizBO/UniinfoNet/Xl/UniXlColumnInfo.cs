// Decompiled with JetBrains decompiler
// Type: UniinfoNet.Xl.UniXlColumnInfo
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

using System.Collections.Generic;
using System.Drawing;

namespace UniinfoNet.Xl
{
  public class UniXlColumnInfo
  {
    public UniXlColumnInfo ParentColumn { get; set; }

    public string Header { get; set; }

    public Color? HeaderBackground { get; set; }

    public Color? HeaderForeground { get; set; }

    public Color? Background { get; set; }

    public Color? Foreground { get; set; }

    public bool UseVMergeWhenValueEqual { get; set; }

    public string[] GetHierarchyHeaders()
    {
      Stack<string> stringStack = new Stack<string>();
      UniXlColumnInfo uniXlColumnInfo = this;
      while (true)
      {
        stringStack.Push(uniXlColumnInfo.Header);
        if (uniXlColumnInfo.ParentColumn != null)
          uniXlColumnInfo = uniXlColumnInfo.ParentColumn;
        else
          break;
      }
      return stringStack.ToArray();
    }

    public override string ToString() => this.Header ?? "";
  }
}
