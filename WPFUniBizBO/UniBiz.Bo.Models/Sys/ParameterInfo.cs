// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Sys.ParameterInfo
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Text.Json.Serialization;
using UniinfoNet;

namespace UniBiz.Bo.Models.Sys
{
  public class ParameterInfo : BindableBase
  {
    private string _Name = string.Empty;
    private string _Desc = string.Empty;
    private string _DataType = string.Empty;

    [JsonPropertyName("name")]
    public string Name
    {
      get => this._Name;
      set
      {
        this._Name = value;
        this.Changed(nameof (Name));
      }
    }

    [JsonPropertyName("desc")]
    public string Desc
    {
      get => this._Desc;
      set
      {
        this._Desc = value;
        this.Changed(nameof (Desc));
      }
    }

    [JsonPropertyName("dataType")]
    public string DataType
    {
      get => this._DataType;
      set
      {
        this._DataType = value;
        this.Changed(nameof (DataType));
      }
    }
  }
}
