// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.JobEvtMessage.JobEvtBase
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Text.Json.Serialization;
using UniBizUtil.Util;
using UniinfoNet;

namespace UniBiz.Bo.Models.JobEvtMessage
{
  public class JobEvtBase : BindableBase
  {
    private int _resource;
    private string _Id;
    private string _JobId;
    private bool _IsJobIdWork = true;
    private long _SiteID;
    private int _ReasonCode;

    public int resource
    {
      get => this._resource;
      set
      {
        this._resource = value;
        this.Changed(nameof (resource));
        this.Changed("JobType");
        this.Changed("resourceDesc");
      }
    }

    [JsonIgnore]
    public EnumJobEvtMessageType JobType => JobEvtConverter.ToJobEvtMessageType(this.resource);

    [JsonIgnore]
    public string resourceDesc => this.JobType.ToDescription();

    [JsonPropertyName("id")]
    public string Id
    {
      get => this._Id;
      set
      {
        this._Id = value;
        this.Changed(nameof (Id));
      }
    }

    [JsonPropertyName("jobId")]
    public string JobId
    {
      get => this._JobId;
      set
      {
        this._JobId = value;
        this.Changed(nameof (JobId));
      }
    }

    [JsonPropertyName("isJobIdWork")]
    public bool IsJobIdWork
    {
      get => this._IsJobIdWork;
      set
      {
        this._IsJobIdWork = value;
        this.Changed(nameof (IsJobIdWork));
      }
    }

    [JsonPropertyName("siteID")]
    public long SiteID
    {
      get => this._SiteID;
      set
      {
        this._SiteID = value;
        this.Changed(nameof (SiteID));
      }
    }

    [JsonPropertyName("reasonCode")]
    public int ReasonCode
    {
      get => this._ReasonCode;
      set
      {
        this._ReasonCode = value;
        this.Changed(nameof (ReasonCode));
      }
    }

    public JobEvtBase() => this.resource = 0;
  }
}
