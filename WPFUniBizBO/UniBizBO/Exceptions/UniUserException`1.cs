﻿// Decompiled with JetBrains decompiler
// Type: UniBizBO.Exceptions.UniUserException`1
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

namespace UniBizBO.Exceptions
{
  public class UniUserException<T> : UniUserException
  {
    public T response { get; set; }
  }
}
