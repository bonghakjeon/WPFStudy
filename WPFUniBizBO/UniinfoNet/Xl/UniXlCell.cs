// Decompiled with JetBrains decompiler
// Type: UniinfoNet.Xl.UniXlCell
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

using System.Drawing;

namespace UniinfoNet.Xl
{
  public class UniXlCell
  {
    public object Value { get; set; }

    public UniXlPurposeValueType PurposeValueType { get; set; }

    public Color? Background { get; set; }

    public Color? Foreground { get; set; }

    public bool IsBold { get; set; }

    public bool IsItalic { get; set; }

    public bool IsUnderline { get; set; }

    public override string ToString() => string.Format("{0}", this.Value);
  }
}
