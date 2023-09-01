// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Message.MenuBookMarkSelectedMsg
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using UniBizBO.Services;

namespace UniBizBO.ViewModels.Message
{
  public class MenuBookMarkSelectedMsg : MsgBase
  {
    public MenuBookMarkSelectedMsg(IUbVM sender)
      : base(sender)
    {
    }

    public int Lv4MenuBookMarkCode { get; set; }
  }
}
