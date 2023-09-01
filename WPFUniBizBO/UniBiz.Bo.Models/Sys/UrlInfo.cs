// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Sys.UrlInfo
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections.Generic;
using System.Text.Json.Serialization;
using UniinfoNet;

namespace UniBiz.Bo.Models.Sys
{
  public class UrlInfo : BindableBase
  {
    private string _Name = string.Empty;
    private string _Desc = string.Empty;
    private string _HttpType = string.Empty;
    private string _Url = string.Empty;
    private string _ReturnType = string.Empty;
    private IList<ParameterInfo> _Lt_Parameter;

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

    [JsonPropertyName("httpType")]
    public string HttpType
    {
      get => this._HttpType;
      set
      {
        this._HttpType = value;
        this.Changed(nameof (HttpType));
      }
    }

    [JsonPropertyName("url")]
    public string Url
    {
      get => this._Url;
      set
      {
        this._Url = value;
        this.Changed(nameof (Url));
      }
    }

    [JsonPropertyName("returnType")]
    public string ReturnType
    {
      get => this._ReturnType;
      set
      {
        this._ReturnType = value.Replace("System.Threading.Tasks.Task`1", "Task").Replace("UniBiz.Bo.Models.UbRest.ResponseV0`1", "ResponseV0").Replace("Collections.Generic.IList`1", "IList").Replace("System.", string.Empty).Replace("UniBiz.Bo.Models.", string.Empty);
        this.Changed(nameof (ReturnType));
      }
    }

    [JsonPropertyName("lt_Parameter")]
    public IList<ParameterInfo> Lt_Parameter
    {
      get => this._Lt_Parameter ?? (this._Lt_Parameter = (IList<ParameterInfo>) new List<ParameterInfo>());
      set
      {
        this._Lt_Parameter = value;
        this.Changed(nameof (Lt_Parameter));
      }
    }
  }
}
