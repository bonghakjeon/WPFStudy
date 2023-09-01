// Decompiled with JetBrains decompiler
// Type: UniBizBO.Services.AppWinMsgEventArgs
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using System;

namespace UniBizBO.Services
{
  public class AppWinMsgEventArgs : EventArgs
  {
    public AppWinMsgEventArgs(
      string propertyName,
      int propertyKeyNnumber,
      int propertyMessage,
      long propertyWParam,
      long propertyLParam)
    {
      this.PropertyName = propertyName;
      this.PropertyKeyNnumber = propertyKeyNnumber;
      this.PropertyMessage = propertyMessage;
      this.PropertyLParam = propertyWParam;
      this.PropertyLParam = propertyLParam;
    }

    public string PropertyName { get; private set; }

    public int PropertyKeyNnumber { get; private set; }

    public int PropertyMessage { get; private set; }

    public long PropertyWParam { get; private set; }

    public long PropertyLParam { get; private set; }
  }
}
