// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Box.CommonMsgVM
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using StyletIoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows;
using UniBizBO.Services.Box;
using UniinfoNet.Extensions;
using UniinfoNet.Windows.Wpf.Commands;

namespace UniBizBO.ViewModels.Box
{
  public class CommonMsgVM : MsgBoxBase
  {
    private string title;
    private string message;
    private Exception catchedException;
    private MsgBoxButton defaultButton;
    private MsgBoxButton cancelButton;
    private MsgBoxLevel level;
    private List<CommonMsgVM.MsgBoxButtonInfo> buttonInfos;
    private MsgBoxButton selectedButton;

    public CommonMsgVM(IContainer container)
      : base(container)
    {
    }

    protected override void OnInitialActivate()
    {
      base.OnInitialActivate();
      SystemSounds.Beep.Play();
    }

    public CommonMsgVM SetDefaultAndCancel(
      MsgBoxLevel level,
      string title,
      string message,
      MsgBoxButton defaultButton = MsgBoxButton.Confirm,
      MsgBoxButton cancelButton = MsgBoxButton.Cancel,
      params MsgBoxButton[] buttons)
    {
      this.Level = level;
      this.Title = title;
      this.Message = message;
      this.DefaultButton = defaultButton;
      this.CancelButton = cancelButton;
      if (buttons == null || ((IEnumerable<MsgBoxButton>) buttons).Count<MsgBoxButton>() == 0)
        this.ButtonInfos = new List<CommonMsgVM.MsgBoxButtonInfo>()
        {
          ((IEnumerable<CommonMsgVM.MsgBoxButtonInfo>) CommonMsgVM.DefaultButtonInfos).First<CommonMsgVM.MsgBoxButtonInfo>((Func<CommonMsgVM.MsgBoxButtonInfo, bool>) (it2 => it2.Button == MsgBoxButton.Confirm))
        };
      else
        this.ButtonInfos = buttons != null ? ((IEnumerable<MsgBoxButton>) buttons).Select<MsgBoxButton, CommonMsgVM.MsgBoxButtonInfo>((Func<MsgBoxButton, CommonMsgVM.MsgBoxButtonInfo>) (it => ((IEnumerable<CommonMsgVM.MsgBoxButtonInfo>) CommonMsgVM.DefaultButtonInfos).FirstOrDefault<CommonMsgVM.MsgBoxButtonInfo>((Func<CommonMsgVM.MsgBoxButtonInfo, bool>) (it2 => it2.Button == it)))).Where<CommonMsgVM.MsgBoxButtonInfo>((Func<CommonMsgVM.MsgBoxButtonInfo, bool>) (it => it != null)).ToList<CommonMsgVM.MsgBoxButtonInfo>() : (List<CommonMsgVM.MsgBoxButtonInfo>) null;
      CommonMsgVM.MsgBoxButtonInfo msgBoxButtonInfo1 = this.ButtonInfos.FirstOrDefault<CommonMsgVM.MsgBoxButtonInfo>((Func<CommonMsgVM.MsgBoxButtonInfo, bool>) (it => it.Button == this.DefaultButton));
      if (msgBoxButtonInfo1 != null)
        msgBoxButtonInfo1.Action<CommonMsgVM.MsgBoxButtonInfo>((Action<CommonMsgVM.MsgBoxButtonInfo>) (it => it.IsDefault = true));
      CommonMsgVM.MsgBoxButtonInfo msgBoxButtonInfo2 = this.ButtonInfos.FirstOrDefault<CommonMsgVM.MsgBoxButtonInfo>((Func<CommonMsgVM.MsgBoxButtonInfo, bool>) (it => it.Button == this.CancelButton));
      if (msgBoxButtonInfo2 != null)
        msgBoxButtonInfo2.Action<CommonMsgVM.MsgBoxButtonInfo>((Action<CommonMsgVM.MsgBoxButtonInfo>) (it => it.IsCancel = true));
      return this;
    }

    public CommonMsgVM SetDefault(
      MsgBoxLevel level,
      string title,
      string message,
      MsgBoxButton defaultButton = MsgBoxButton.Confirm,
      params MsgBoxButton[] buttons)
    {
      return this.SetDefaultAndCancel(level, title, message, defaultButton, MsgBoxButton.Cancel, buttons);
    }

    public CommonMsgVM Set(string title, string message) => this.SetDefault(MsgBoxLevel.None, title, message, MsgBoxButton.Confirm, MsgBoxButton.Confirm);

    public CommonMsgVM SetException(string title, string message, Exception e)
    {
      this.SetDefault(MsgBoxLevel.Error, title, message, MsgBoxButton.Confirm, MsgBoxButton.Confirm);
      this.CatchedException = e;
      return this;
    }

    public CommonMsgVM SetException(string title, Exception e)
    {
      this.SetException(title, e.Message, e);
      return this;
    }

    public CommonMsgVM SetException(Exception e)
    {
      this.SetException("에러", e);
      return this;
    }

    public MsgBoxButton ShowDialog()
    {
      this.WindowManager.ShowDialog((object) this);
      return this.SelectedButton;
    }

    public void ContentCopy()
    {
      StringBuilder stringBuilder = new StringBuilder();
      Clipboard.SetText(stringBuilder != null ? stringBuilder.Action<StringBuilder>((Action<StringBuilder>) (sb =>
      {
        sb.AppendLine("Windows=" + Environment.OSVersion.VersionString);
        sb.AppendLine(string.Format("Runtime={0}", (object) Environment.Version));
        sb.AppendLine(string.Format("{0}={1}", (object) "Level", (object) this.Level));
        sb.AppendLine("Title=" + this.Title);
        sb.AppendLine("Message=" + this.Message);
        sb.AppendLine("Type=" + (this.CatchedException?.GetType()?.Name ?? "None"));
      })).ToString() : (string) null);
    }

    public void SelectButton(CommonMsgVM.MsgBoxButtonInfo info)
    {
      this.SelectedButton = info.Button;
      this.RequestClose(new bool?(true));
    }

    public override void RequestClose(bool? dialogResult = null)
    {
      base.RequestClose(dialogResult);
      bool? nullable = dialogResult;
      bool flag = true;
      if (nullable.GetValueOrDefault() == flag & nullable.HasValue)
        return;
      this.SelectedButton = this.DefaultButton;
    }

    public string Title
    {
      get => this.title;
      set
      {
        this.title = value;
        this.NotifyOfPropertyChange(nameof (Title));
      }
    }

    public string Message
    {
      get => this.message;
      set
      {
        this.message = value;
        this.NotifyOfPropertyChange(nameof (Message));
      }
    }

    public Exception CatchedException
    {
      get => this.catchedException;
      set
      {
        this.catchedException = value;
        this.NotifyOfPropertyChange(nameof (CatchedException));
      }
    }

    public MsgBoxButton DefaultButton
    {
      get => this.defaultButton;
      set
      {
        this.defaultButton = value;
        this.NotifyOfPropertyChange(nameof (DefaultButton));
      }
    }

    public MsgBoxButton CancelButton
    {
      get => this.cancelButton;
      set
      {
        this.cancelButton = value;
        this.NotifyOfPropertyChange(nameof (CancelButton));
      }
    }

    public MsgBoxLevel Level
    {
      get => this.level;
      set
      {
        this.level = value;
        this.NotifyOfPropertyChange(nameof (Level));
      }
    }

    public List<CommonMsgVM.MsgBoxButtonInfo> ButtonInfos
    {
      get => this.buttonInfos;
      set
      {
        this.buttonInfos = value;
        this.NotifyOfPropertyChange(nameof (ButtonInfos));
      }
    }

    public MsgBoxButton SelectedButton
    {
      get => this.selectedButton;
      set
      {
        this.selectedButton = value;
        this.NotifyOfPropertyChange(nameof (SelectedButton));
      }
    }

    public static CommonMsgVM.MsgBoxButtonInfo[] DefaultButtonInfos => new CommonMsgVM.MsgBoxButtonInfo[6]
    {
      new CommonMsgVM.MsgBoxButtonInfo(MsgBoxButton.OK, "좋아요"),
      new CommonMsgVM.MsgBoxButtonInfo(MsgBoxButton.Cancel, "취소"),
      new CommonMsgVM.MsgBoxButtonInfo(MsgBoxButton.Yes, "예"),
      new CommonMsgVM.MsgBoxButtonInfo(MsgBoxButton.No, "아니오"),
      new CommonMsgVM.MsgBoxButtonInfo(MsgBoxButton.Confirm, "확인"),
      new CommonMsgVM.MsgBoxButtonInfo(MsgBoxButton.Accept, "수락")
    };

    public WpfCommand<CommonMsgVM.MsgBoxButtonInfo> CmdSelectButton => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<CommonMsgVM.MsgBoxButtonInfo>>((Func<WpfCommand<CommonMsgVM.MsgBoxButtonInfo>>) (() =>
    {
      return new WpfCommand<CommonMsgVM.MsgBoxButtonInfo>()
      {
        IsAutoRefresh = true,
        CanExecuteFunc = (Func<CommonMsgVM.MsgBoxButtonInfo, bool>) (x => x != null),
        ExecuteAction = (Action<CommonMsgVM.MsgBoxButtonInfo>) (x => this.SelectButton(x))
      };
    }), nameof (CmdSelectButton));

    public WpfCommand CmdContentCopy => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        IsAutoRefresh = true,
        ExecuteAction = (Action<object>) (x => this.ContentCopy())
      };
    }), nameof (CmdContentCopy));

    public class MsgBoxButtonInfo
    {
      public MsgBoxButtonInfo(MsgBoxButton button, string text)
      {
        this.Button = button;
        this.ButtonText = text;
      }

      public MsgBoxButton Button { get; set; }

      public bool IsDefault { get; set; }

      public bool IsCancel { get; set; }

      public string ButtonText { get; set; }

      public bool IsVisible => this.Button != 0;
    }
  }
}
