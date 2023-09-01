// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniImages.UniTemplates.Common.PaperMetadata
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections.Generic;
using System.Text.Json.Serialization;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniImages.UniTemplates.Common
{
  public class PaperMetadata : BindableBase
  {
    private PaperPublicInfo _PaperInfo;
    private IList<FormatDataPublicInfo> _ManualSerialFormatDataInfos;

    [JsonPropertyName("d008d69a-6c3b-44e9-926b-41389be6ec19")]
    public PaperPublicInfo PaperInfo
    {
      get => this._PaperInfo;
      set
      {
        this._PaperInfo = value;
        this.Changed(nameof (PaperInfo));
      }
    }

    [JsonPropertyName("db30af50-6978-42b8-bb38-0ebc28f3c851")]
    public IList<FormatDataPublicInfo> ManualSerialFormatDataInfos
    {
      get => this._ManualSerialFormatDataInfos ?? (this._ManualSerialFormatDataInfos = (IList<FormatDataPublicInfo>) new List<FormatDataPublicInfo>());
      set
      {
        this._ManualSerialFormatDataInfos = value;
        this.Changed(nameof (ManualSerialFormatDataInfos));
      }
    }

    public PaperMetadata() => this.Clear();

    public void Clear() => this.PaperInfo = (PaperPublicInfo) null;
  }
}
