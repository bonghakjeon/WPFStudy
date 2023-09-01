// Decompiled with JetBrains decompiler
// Type: UniBizBO.Services.UbAppStatus
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using StyletIoC;
using UniBiz.Bo.Models.UbRest;
using UniBizBO.Composition;
using UniinfoNet.Clazz;

namespace UniBizBO.Services
{
  public class UbAppStatus
  {
    [Inject]
    public UbHttpClient Api { get; set; }

    [Inject]
    public UserManager User { get; set; }

    [Inject]
    public AppSystemManager Sys { get; set; }

    [Inject]
    public LocalSettingManager Local { get; set; }

    [Inject]
    public InheritClazzFinder ClazzFinder { get; set; }

    [Inject]
    public UniApiWsManager ApiWebSocket { get; set; }
  }
}
