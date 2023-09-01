// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.JobEvtMessage.JobEvtMessage
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Text.Json.Serialization;

namespace UniBiz.Bo.Models.JobEvtMessage
{
  public class JobEvtMessage : JobEvtBase
  {
    private string _Msg;

    [JsonPropertyName("msg")]
    public string Msg
    {
      get => this._Msg;
      set
      {
        this._Msg = value;
        this.Changed(nameof (Msg));
      }
    }

    public JobEvtMessage() => this.resource = 5;
  }
}
