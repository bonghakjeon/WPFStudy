// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniImages.UniTemplates.Common.PaperPublicInfo
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Text.Json.Serialization;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniImages.UniTemplates.Common
{
  public class PaperPublicInfo : BindableBase
  {
    private string _PaperId;
    private int _Width;
    private int _Height;

    [JsonPropertyName("dd55b83a-5e68-464e-bfa6-0345065873f9")]
    public string PaperId
    {
      get => this._PaperId;
      set
      {
        this._PaperId = value;
        this.Changed(nameof (PaperId));
      }
    }

    [JsonPropertyName("9c855c73-7594-4fa1-abff-30ed8d4e9e0e")]
    public int Width
    {
      get => this._Width;
      set
      {
        this._Width = value;
        this.Changed(nameof (Width));
      }
    }

    [JsonPropertyName("de9a5ab7-bde1-4a07-8af3-440cccf6bb04")]
    public int Height
    {
      get => this._Height;
      set
      {
        this._Height = value;
        this.Changed(nameof (Height));
      }
    }

    public PaperPublicInfo() => this.Clear();

    public void Clear()
    {
      this.PaperId = string.Empty;
      this.Width = this.Height = 0;
    }
  }
}
