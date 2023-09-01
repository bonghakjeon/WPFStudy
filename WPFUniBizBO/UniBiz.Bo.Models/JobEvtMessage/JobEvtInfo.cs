// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.JobEvtMessage.JobEvtInfo
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

namespace UniBiz.Bo.Models.JobEvtMessage
{
  public class JobEvtInfo : JobEvtBase
  {
    private bool _IsWorkCancel;
    private bool _IsJobDeleteReqStates;
    private string _JobTypeJson;

    public bool IsWorkCancel
    {
      get => this._IsWorkCancel;
      set
      {
        this._IsWorkCancel = value;
        this.Changed(nameof (IsWorkCancel));
      }
    }

    public bool IsJobDeleteReqStates
    {
      get => this._IsJobDeleteReqStates;
      set
      {
        this._IsJobDeleteReqStates = value;
        this.Changed(nameof (IsJobDeleteReqStates));
      }
    }

    public string JobTypeJson
    {
      get => this._JobTypeJson;
      set
      {
        this._JobTypeJson = value;
        this.Changed(nameof (JobTypeJson));
      }
    }

    public JobEvtInfo()
    {
      this.resource = 12;
      this.IsWorkCancel = false;
      this.IsJobDeleteReqStates = false;
    }
  }
}
