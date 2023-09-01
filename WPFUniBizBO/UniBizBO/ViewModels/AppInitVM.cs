// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.AppInitVM
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Stylet;
using StyletIoC;
using System;
using System.Windows.Threading;
using UniBizBO.Common;
using UniBizBO.Config;
using UniBizBO.Services;
using UniBizBO.ViewModels.Board;
using UniinfoNet.Extensions;
using UniinfoNet.Windows.Wpf.Commands;


#nullable enable
namespace UniBizBO.ViewModels
{
  public class AppInitVM : UbScreen
  {
    [Inject]
    public 
    #nullable disable
    BOConfig BOConfig { get; set; }

    [Inject]
    public ThemeSetting ThemeSetting { get; set; }

    public AppInitVM(IContainer container)
      : base(container)
    {
    }

    protected override async void OnInitialActivate()
    {
      AppInitVM appInitVm = this;
      // ISSUE: reference to a compiler-generated method
      appInitVm.\u003C\u003En__0();
      appInitVm.ThemeSetting.CurrentTheme.LoadTheme(appInitVm.BOConfig.DefaultThemeName);
      // ISSUE: explicit non-virtual call
      LoginBoardVM vm = __nonvirtual (appInitVm.Container).Get<LoginBoardVM>();
      vm.Activated += new EventHandler<ActivationEventArgs>(appInitVm.Vm_Activated);
      await Dispatcher.Yield((DispatcherPriority) 6);
      // ISSUE: explicit non-virtual call
      __nonvirtual (appInitVm.WindowManager).ShowWindow((object) vm);
      vm = (LoginBoardVM) null;
    }

    private async void Vm_Activated(object sender, ActivationEventArgs e)
    {
      AppInitVM appInitVm = this;
      await Dispatcher.Yield((DispatcherPriority) 6);
      appInitVm.RequestClose(new bool?());
      (sender as LoginBoardVM).Activated -= new EventHandler<ActivationEventArgs>(appInitVm.Vm_Activated);
    }

    public WpfCommand CmdLogin
    {
      get
      {
        CommandDictionary<NotifyCommand> cmds = this.Cmds;
        WpfCommand wpfCommand = new WpfCommand();
        wpfCommand.ExecuteAction = (Action<object>) (_ => this.Login());
        return cmds.GetValueOrInsert<NotifyCommand, WpfCommand>(wpfCommand, nameof (CmdLogin));
      }
    }

    public void Login() => this.Container.Get<LoginBoardVM>().ToShowData();
  }
}
