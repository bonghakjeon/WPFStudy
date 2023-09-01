// Decompiled with JetBrains decompiler
// Type: UniBizBO.Behaviors.IScrollController
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

namespace UniBizBO.Behaviors
{
  public interface IScrollController
  {
    void ScrollChangeByRatio(double offsetXRatio, double offsetYRatio);

    void ScrollChangeByAmount(double offsetX, double offsetY);
  }
}
