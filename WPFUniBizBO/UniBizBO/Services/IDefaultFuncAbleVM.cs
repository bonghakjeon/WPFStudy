// Decompiled with JetBrains decompiler
// Type: UniBizBO.Services.IDefaultFuncAbleVM`1
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using System.Collections.Generic;
using UniinfoNet.Windows.Wpf.Commands;

namespace UniBizBO.Services
{
  public interface IDefaultFuncAbleVM<T> where T : DefaultFuncBase
  {
    IEnumerable<T> DefaultFuncs { get; set; }

    bool OnQueryCanDefaultFunc(T funcType);

    void OnQueryDefaultFunc(T funcType);

    WpfCommand<object> CmdDefaultFunc { get; }
  }
}
