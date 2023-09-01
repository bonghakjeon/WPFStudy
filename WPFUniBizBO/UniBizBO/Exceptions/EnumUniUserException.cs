// Decompiled with JetBrains decompiler
// Type: UniBizBO.Exceptions.EnumUniUserException
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using System.ComponentModel;

namespace UniBizBO.Exceptions
{
  public enum EnumUniUserException
  {
    [Description("Error")] Error,
    [Description("Nothing")] Nothing,
    [Description("Stop")] Stop,
    [Description("Next")] Next,
    [Description("GoodsSearch")] GoodsSearch,
  }
}
