// Decompiled with JetBrains decompiler
// Type: UniBizBO.Services.Board.CommonBoardBase`1
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Stylet;
using StyletIoC;
using System;
using System.Threading.Tasks;
using UniBizBO.ViewModels.Message;
using UniinfoNet.Windows.Wpf;


#nullable enable
namespace UniBizBO.Services.Board
{
  [HiddenVm]
  public abstract class CommonBoardBase<TData> : 
    BoardBase<
    #nullable disable
    TData>,
    IAppWinMsgEventArgs,
    IReceiveKeyCapture
  {
    private bool isMultiSelectMode;

    public CommonBoardBase(IContainer container)
      : base(container)
    {
    }

    public bool IsMultiSelectMode
    {
      get => this.isMultiSelectMode;
      set
      {
        this.isMultiSelectMode = value;
        this.NotifyOfPropertyChange(nameof (IsMultiSelectMode));
      }
    }

    public override void OnQueryDefaultFunc(DefaultBoardFunc funcType)
    {
      base.OnQueryDefaultFunc(funcType);
      if (DefaultBoardFunc.Confirm.Equals((object) funcType))
      {
        this.OnConfirm();
      }
      else
      {
        if (!DefaultBoardFunc.Callback.Equals((object) funcType))
          return;
        this.OnCallbackData();
      }
    }

    public override bool OnQueryCanDefaultFunc(DefaultBoardFunc funcType)
    {
      bool flag = base.OnQueryCanDefaultFunc(funcType);
      if (DefaultBoardFunc.Confirm.Equals((object) funcType))
      {
        int num;
        if ((object) this.SelectedData == null)
        {
          BindableCollection<TData> selectedDatas = this.SelectedDatas;
          // ISSUE: explicit non-virtual call
          num = (selectedDatas != null ? __nonvirtual (selectedDatas.Count) : 0) > 0 ? 1 : 0;
        }
        else
          num = 1;
        flag = num != 0;
      }
      else if (DefaultBoardFunc.Callback.Equals((object) funcType))
      {
        int num;
        if ((object) this.SelectedData == null)
        {
          BindableCollection<TData> selectedDatas = this.SelectedDatas;
          // ISSUE: explicit non-virtual call
          num = (selectedDatas != null ? __nonvirtual (selectedDatas.Count) : 0) > 0 ? 1 : 0;
        }
        else
          num = 1;
        flag = num != 0;
      }
      return flag;
    }

    public virtual void OnSelected()
    {
      EventHandler<CommonBoardBase<TData>> selected = this.Selected;
      if (selected == null)
        return;
      selected((object) this, this);
    }

    public virtual void OnConfirm()
    {
      this.IsConfirm = true;
      EventHandler<CommonBoardBase<TData>> confirmed = this.Confirmed;
      if (confirmed != null)
        confirmed((object) this, this);
      this.RequestClose(new bool?());
    }

    public virtual void OnCallbackData()
    {
      EventHandler<CommonBoardBase<TData>> callbackData = this.CallbackData;
      if (callbackData == null)
        return;
      callbackData((object) this, this);
    }

    public event EventHandler<CommonBoardBase<TData>> Selected;

    public event EventHandler<CommonBoardBase<TData>> Confirmed;

    public event EventHandler<CommonBoardBase<TData>> CallbackData;

    public virtual async Task OnReceiveAppWinMessageAsync(AppWinMsg p_param) => await Task.Yield();

    public event EventHandler<AppWinMsgEventArgs> AppWinMsgArgsRequested;

    public virtual void OnAppWinMsgArgsRequested(
      string propertyName,
      int propertyKeyNnumber = 0,
      int propertyMessage = 0,
      long propertyWParam = 0,
      long propertyLParam = 0)
    {
      EventHandler<AppWinMsgEventArgs> msgArgsRequested = this.AppWinMsgArgsRequested;
      if (msgArgsRequested == null)
        return;
      msgArgsRequested((object) this, new AppWinMsgEventArgs(propertyName, propertyKeyNnumber, propertyMessage, propertyWParam, propertyLParam));
    }

    public virtual bool OnReceiveKeyState(KeyCaptureState state) => false;
  }
}
