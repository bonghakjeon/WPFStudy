﻿// Decompiled with JetBrains decompiler
// Type: UniBizBO.Services.Part.IPart
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using UniBizBO.Composition;

namespace UniBizBO.Services.Part
{
  public interface IPart : IHaveWorkDataSet
  {
    PartMenuInfo MenuInfo { get; set; }

    IPartContainer PartContainer { get; }
  }
}
