// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniImages.UniTemplates.Common.FormatDataPublicInfo
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Text.Json.Serialization;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniImages.UniTemplates.Common
{
  public class FormatDataPublicInfo : BindableBase
  {
    private string _ObjectId;
    private string _FormatDataId;
    private string _InitValue;
    private int _ChangeValue;

    [JsonPropertyName("d865028e-d06d-4413-923e-387dec0b7a24")]
    public string ObjectId
    {
      get => this._ObjectId;
      set
      {
        this._ObjectId = value;
        this.Changed(nameof (ObjectId));
      }
    }

    [JsonPropertyName("26bc2945-cb4a-4994-88ee-e6b9c1467bbd")]
    public string FormatDataId
    {
      get => this._FormatDataId;
      set
      {
        this._FormatDataId = value;
        this.Changed(nameof (FormatDataId));
      }
    }

    [JsonPropertyName("ad50184a-59ea-4dc2-ab00-2ac112b84c88")]
    public string InitValue
    {
      get => this._InitValue;
      set
      {
        this._InitValue = value;
        this.Changed(nameof (InitValue));
      }
    }

    [JsonPropertyName("4ee6609c-ce7b-4d08-b545-6f182d9c6908")]
    public int ChangeValue
    {
      get => this._ChangeValue;
      set
      {
        this._ChangeValue = value;
        this.Changed(nameof (ChangeValue));
      }
    }

    public FormatDataPublicInfo() => this.Clear();

    public void Clear()
    {
      this.ObjectId = this.FormatDataId = this.InitValue = string.Empty;
      this.ChangeValue = 0;
    }
  }
}
