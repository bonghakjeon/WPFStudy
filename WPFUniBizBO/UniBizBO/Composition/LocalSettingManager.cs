// Decompiled with JetBrains decompiler
// Type: UniBizBO.Composition.LocalSettingManager
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using StyletIoC;
using UniBizBO.Store;
using UniinfoNet;

namespace UniBizBO.Composition
{
  public class LocalSettingManager : BindableBase
  {
    [Inject]
    public LocalStatusStore Status { get; set; }

    public void Init()
    {
    }

    public void Exit()
    {
    }
  }
}
