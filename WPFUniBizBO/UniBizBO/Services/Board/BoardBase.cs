// Decompiled with JetBrains decompiler
// Type: UniBizBO.Services.Board.BoardBase
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using StyletIoC;
using System;
using System.Collections.Generic;
using UniBizBO.Composition;
using UniinfoNet.Extensions;
using UniinfoNet.Windows.Wpf.Commands;

namespace UniBizBO.Services.Board
{
  [HiddenVm]
  public abstract class BoardBase : UbScreen, IDefaultFuncAbleVM<DefaultBoardFunc>
  {
    public BoardBase(IContainer container)
      : base(container)
    {
    }

    public IEnumerable<DefaultBoardFunc> DefaultFuncs { get; set; }

    public virtual IReadOnlyDictionary<string, TableColumnInfo> OnQueryDataHeaders() => (IReadOnlyDictionary<string, TableColumnInfo>) null;

    public virtual bool OnQueryCanDefaultFunc(DefaultBoardFunc funcType) => true;

    public virtual void OnQueryDefaultFunc(DefaultBoardFunc funcType)
    {
      if (!DefaultBoardFunc.Close.Equals((object) funcType))
        return;
      this.RequestClose(new bool?());
    }

    public WpfCommand<object> CmdDefaultFunc => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<object>>((Func<WpfCommand<object>>) (() => new WpfCommand<object>().AutoRefreshOn<WpfCommand<object>>().ApplyCanExecute<object>((Func<object, bool>) (it =>
    {
      DefaultBoardFunc funcType = (DefaultBoardFunc) null;
      switch (it)
      {
        case string name2:
          funcType = new DefaultBoardFunc(name2);
          break;
        case DefaultBoardFunc defaultBoardFunc2:
          funcType = defaultBoardFunc2;
          break;
      }
      return this.OnQueryCanDefaultFunc(funcType);
    })).ApplyExecute<object>((Action<object>) (it =>
    {
      DefaultBoardFunc funcType = (DefaultBoardFunc) null;
      switch (it)
      {
        case string name4:
          funcType = new DefaultBoardFunc(name4);
          break;
        case DefaultBoardFunc defaultBoardFunc4:
          funcType = defaultBoardFunc4;
          break;
      }
      this.OnQueryDefaultFunc(funcType);
    }))), nameof (CmdDefaultFunc));
  }
}
