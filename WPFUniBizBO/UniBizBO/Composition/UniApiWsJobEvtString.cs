// Decompiled with JetBrains decompiler
// Type: UniBizBO.Composition.UniApiWsJobEvtString
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using UniBiz.Bo.Models.JobEvtMessage;
using UniinfoNet;

namespace UniBizBO.Composition
{
  public class UniApiWsJobEvtString : BindableBase
  {
    public object Sender { get; set; }

    public string JobId { get; set; }

    public EnumJobEvtMessageType JobType { get; set; }

    public string Item { get; set; }

    public UniApiWsJobEvtString(
      object pSender,
      string pJobId,
      EnumJobEvtMessageType pJobType,
      string pItem)
    {
      this.Sender = pSender;
      this.JobId = pJobId;
      this.JobType = pJobType;
      this.Item = pItem;
    }
  }
}
