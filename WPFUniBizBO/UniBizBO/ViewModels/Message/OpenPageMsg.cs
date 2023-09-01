// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Message.OpenPageMsg
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using UniBizBO.Services;
using UniBizBO.Services.Page;

namespace UniBizBO.ViewModels.Message
{
  public class OpenPageMsg : MsgBase
  {
    public OpenPageMsg(IUbVM sender)
      : base(sender)
    {
    }

    public IPage Page { get; set; }

    public bool IsMenuBookMarkSelected { get; set; }

    public int Lv4MenuBookMarkCode { get; set; }
  }
}
