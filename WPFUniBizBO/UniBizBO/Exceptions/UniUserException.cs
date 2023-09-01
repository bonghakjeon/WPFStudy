// Decompiled with JetBrains decompiler
// Type: UniBizBO.Exceptions.UniUserException
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using System;
using UniBizUtil.Util;

namespace UniBizBO.Exceptions
{
  public class UniUserException : Exception
  {
    public EnumUniUserException code { get; set; }

    public string user_message { get; set; } = string.Empty;

    public UniUserException()
    {
    }

    public UniUserException(string message)
      : base(message)
    {
    }

    public UniUserException(string message, Exception inner)
      : base(message, inner)
    {
    }

    public UniUserException(EnumUniUserException code, string message, string user_message)
      : base(message)
    {
      this.code = code;
      this.user_message = user_message;
    }

    public UniUserException(EnumUniUserException code)
      : base(code.ToDescription())
    {
      this.code = code;
    }
  }
}
