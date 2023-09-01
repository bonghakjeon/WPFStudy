// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.OuterConnAuth.DeviceIpInfo
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Text.Json.Serialization;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniBase.OuterConnAuth
{
  public class DeviceIpInfo : BindableBase
  {
    private string _IpAddress;
    private string _MacAddress;

    [JsonPropertyName("ipAddress")]
    public string IpAddress
    {
      get => this._IpAddress;
      set
      {
        this._IpAddress = value;
        this.Changed(nameof (IpAddress));
      }
    }

    [JsonPropertyName("macAddress")]
    public string MacAddress
    {
      get => this._MacAddress;
      set
      {
        this._MacAddress = value;
        this.Changed(nameof (MacAddress));
      }
    }
  }
}
