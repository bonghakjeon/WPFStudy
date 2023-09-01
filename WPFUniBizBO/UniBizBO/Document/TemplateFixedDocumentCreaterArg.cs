// Decompiled with JetBrains decompiler
// Type: UniBizBO.Document.TemplateFixedDocumentCreaterArg
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using UniinfoNet;

namespace UniBizBO.Document
{
  public class TemplateFixedDocumentCreaterArg : BindableBase
  {
    private string title;
    private string top1Left;
    private string top1Right;
    private string top2Left;
    private string top2Right;
    private string bottomLeft;
    private string bottomRight;
    private bool usePageCountText = true;
    private bool isItemSizeFixed = true;
    private bool isHeaderSizeFixed = true;

    public string Title
    {
      get => this.title;
      set
      {
        this.title = value;
        this.Changed(nameof (Title));
      }
    }

    public string Top1Left
    {
      get => this.top1Left;
      set
      {
        this.top1Left = value;
        this.Changed(nameof (Top1Left));
      }
    }

    public string Top1Right
    {
      get => this.top1Right;
      set
      {
        this.top1Right = value;
        this.Changed(nameof (Top1Right));
      }
    }

    public string Top2Left
    {
      get => this.top2Left;
      set
      {
        this.top2Left = value;
        this.Changed(nameof (Top2Left));
      }
    }

    public string Top2Right
    {
      get => this.top2Right;
      set
      {
        this.top2Right = value;
        this.Changed(nameof (Top2Right));
      }
    }

    public string BottomLeft
    {
      get => this.bottomLeft;
      set
      {
        this.bottomLeft = value;
        this.Changed(nameof (BottomLeft));
      }
    }

    public string BottomRight
    {
      get => this.bottomRight;
      set
      {
        this.bottomRight = value;
        this.Changed(nameof (BottomRight));
      }
    }

    public bool UsePageCountText
    {
      get => this.usePageCountText;
      set
      {
        this.usePageCountText = value;
        this.Changed(nameof (UsePageCountText));
      }
    }

    public bool IsItemSizeFixed
    {
      get => this.isItemSizeFixed;
      set
      {
        this.isItemSizeFixed = value;
        this.Changed(nameof (IsItemSizeFixed));
      }
    }

    public bool IsHeaderSizeFixed
    {
      get => this.isHeaderSizeFixed;
      set
      {
        this.isHeaderSizeFixed = value;
        this.Changed(nameof (IsHeaderSizeFixed));
      }
    }
  }
}
