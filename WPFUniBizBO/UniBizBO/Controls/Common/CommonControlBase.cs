// Decompiled with JetBrains decompiler
// Type: UniBizBO.Controls.Common.CommonControlBase
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using UniinfoNet.Extensions;
using UniinfoNet.Windows.Wpf.Commands;
using UniinfoNet.Windows.Wpf.Job;


#nullable enable
namespace UniBizBO.Controls.Common
{
  public class CommonControlBase : UserControl, INotifyPropertyChanged
  {
    public static readonly 
    #nullable disable
    DependencyProperty ContainerProperty = DependencyProperty.Register(nameof (Container), typeof (StyletIoC.IContainer), typeof (CommonControlBase), new PropertyMetadata((PropertyChangedCallback) null));
    public static readonly DependencyProperty JobProperty = DependencyProperty.Register(nameof (Job), typeof (JobProgressManager), typeof (CommonControlBase), new PropertyMetadata((PropertyChangedCallback) null));
    public static readonly DependencyProperty IsMultiSelectProperty = DependencyProperty.Register(nameof (IsMultiSelect), typeof (bool), typeof (CommonControlBase), new PropertyMetadata((object) true, (PropertyChangedCallback) ((s, e) => s.CoerceValue(CommonControlBase.DisplayTextProperty))));
    public static readonly DependencyProperty DisplayTextProperty = DependencyProperty.Register(nameof (DisplayText), typeof (string), typeof (CommonControlBase), new PropertyMetadata((object) null, (PropertyChangedCallback) null, (CoerceValueCallback) ((s, e) => !(s is CommonControlBase commonControlBase1) ? (object) null : (object) commonControlBase1.OnQueryGetDisplayText(e as string))));
    public static readonly DependencyProperty IsEnabledControlProperty = DependencyProperty.Register(nameof (IsEnabledControl), typeof (bool), typeof (CommonControlBase), new PropertyMetadata((object) true, (PropertyChangedCallback) null));
    private string keyword;
    public static readonly DependencyProperty SelectedDataProperty = DependencyProperty.Register(nameof (SelectedData), typeof (object), typeof (CommonControlBase), new PropertyMetadata((object) null, (PropertyChangedCallback) ((s, e) =>
    {
      if (!(s is CommonControlBase commonControlBase3))
        return;
      commonControlBase3.Action<CommonControlBase>((Action<CommonControlBase>) (con =>
      {
        con.CoerceValue(CommonControlBase.DisplayTextProperty);
        con.Changed(nameof (IsUse));
      }));
    })));
    public static readonly DependencyProperty SelectedDatasProperty = DependencyProperty.Register(nameof (SelectedDatas), typeof (IList), typeof (CommonControlBase), new PropertyMetadata((object) null, (PropertyChangedCallback) ((s, e) =>
    {
      if (!(s is CommonControlBase commonControlBase5))
        return;
      commonControlBase5.Action<CommonControlBase>((Action<CommonControlBase>) (con =>
      {
        con.CoerceValue(CommonControlBase.DisplayTextProperty);
        con.Changed(nameof (IsUse));
      }));
    })));
    public static readonly DependencyProperty SelectedCodeProperty = DependencyProperty.Register(nameof (SelectedCode), typeof (int), typeof (CommonControlBase), new PropertyMetadata((object) 0, (PropertyChangedCallback) ((s, e) =>
    {
      if (!(s is CommonControlBase commonControlBase7))
        return;
      commonControlBase7.Action<CommonControlBase>((Action<CommonControlBase>) (con =>
      {
        con.CoerceValue(CommonControlBase.DisplayTextProperty);
        con.Changed(nameof (IsUse));
      }));
    })));
    public static readonly DependencyProperty SelectedNameProperty = DependencyProperty.Register(nameof (SelectedName), typeof (string), typeof (CommonControlBase), new PropertyMetadata((object) string.Empty, (PropertyChangedCallback) ((s, e) =>
    {
      if (!(s is CommonControlBase commonControlBase9))
        return;
      commonControlBase9.Action<CommonControlBase>((Action<CommonControlBase>) (con =>
      {
        con.CoerceValue(CommonControlBase.DisplayTextProperty);
        con.Changed(nameof (IsUse));
      }));
    })));
    public static readonly DependencyProperty SelectedCodeInProperty = DependencyProperty.Register(nameof (SelectedCodeIn), typeof (string), typeof (CommonControlBase), new PropertyMetadata((object) string.Empty, (PropertyChangedCallback) ((s, e) =>
    {
      if (!(s is CommonControlBase commonControlBase11))
        return;
      commonControlBase11.Action<CommonControlBase>((Action<CommonControlBase>) (con =>
      {
        con.CoerceValue(CommonControlBase.DisplayTextProperty);
        con.Changed(nameof (IsUse));
      }));
    })));
    public static readonly DependencyProperty SelectedNameInProperty = DependencyProperty.Register(nameof (SelectedNameIn), typeof (string), typeof (CommonControlBase), new PropertyMetadata((object) string.Empty, (PropertyChangedCallback) ((s, e) =>
    {
      if (!(s is CommonControlBase commonControlBase13))
        return;
      commonControlBase13.Action<CommonControlBase>((Action<CommonControlBase>) (con =>
      {
        con.CoerceValue(CommonControlBase.DisplayTextProperty);
        con.Changed(nameof (IsUse));
      }));
    })));
    public static readonly DependencyProperty SearchContionProperty = DependencyProperty.Register(nameof (SearchContion), typeof (Hashtable), typeof (CommonControlBase), new PropertyMetadata((PropertyChangedCallback) null));

    public CommonControlBase() => this.SetBinding(CommonControlBase.ContainerProperty, (BindingBase) new Binding(nameof (Container)));

    protected virtual string OnQueryGetDisplayText(string before) => before;

    public virtual bool CanOpenSelectBoard() => true;

    public virtual void OnOpenSelectBoard()
    {
    }

    public async void OpenSelectBoard()
    {
      this.OnOpenSelectBoard();
      await Task.CompletedTask;
    }

    public virtual bool CanQuickSearch() => !string.IsNullOrWhiteSpace(this.Keyword);

    public virtual Task OnQuickSearchAsync() => Task.CompletedTask;

    public virtual bool CanClearSelect() => this.IsUse;

    public virtual void OnKeywordInput() => this.OnClearSelect();

    public virtual void OnClearSelect()
    {
    }

    public Dictionary<string, NotifyCommand> Cmds { get; } = new Dictionary<string, NotifyCommand>();

    public WpfCommand CmdOpenSelectBoard => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        IsAutoRefresh = true,
        CanExecuteFunc = (Func<object, bool>) (_ => this.CanOpenSelectBoard()),
        ExecuteAction = (Action<object>) (_ => this.OpenSelectBoard())
      };
    }), nameof (CmdOpenSelectBoard));

    public WpfCommand CmdQuickSearch
    {
      get
      {
        Dictionary<string, NotifyCommand> cmds = this.Cmds;
        WpfCommand wpfCommand = new WpfCommand();
        wpfCommand.CanExecuteFunc = (Func<object, bool>) (_ => this.CanQuickSearch());
        wpfCommand.ExecuteAction = (Action<object>) (async _ => await this.OnQuickSearchAsync());
        return cmds.GetValueOrInsert<NotifyCommand, WpfCommand>(wpfCommand, nameof (CmdQuickSearch));
      }
    }

    public WpfCommand CmdClearSelect => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        IsAutoRefresh = true,
        CanExecuteFunc = (Func<object, bool>) (_ => this.CanClearSelect()),
        ExecuteAction = (Action<object>) (_ => this.OnClearSelect())
      };
    }), nameof (CmdClearSelect));

    public StyletIoC.IContainer Container
    {
      get => (StyletIoC.IContainer) this.GetValue(CommonControlBase.ContainerProperty);
      set => this.SetValue(CommonControlBase.ContainerProperty, (object) value);
    }

    public JobProgressManager Job
    {
      get => (JobProgressManager) this.GetValue(CommonControlBase.JobProperty);
      set => this.SetValue(CommonControlBase.JobProperty, (object) value);
    }

    public bool IsMultiSelect
    {
      get => (bool) this.GetValue(CommonControlBase.IsMultiSelectProperty);
      set => this.SetValue(CommonControlBase.IsMultiSelectProperty, (object) value);
    }

    public string DisplayText
    {
      get => (string) this.GetValue(CommonControlBase.DisplayTextProperty);
      set => this.SetValue(CommonControlBase.DisplayTextProperty, (object) value);
    }

    public bool IsEnabledControl
    {
      get => (bool) this.GetValue(CommonControlBase.IsEnabledControlProperty);
      set => this.SetValue(CommonControlBase.IsEnabledControlProperty, (object) value);
    }

    public string Keyword
    {
      get => this.keyword;
      set
      {
        this.keyword = value;
        this.Changed(nameof (Keyword));
      }
    }

    public virtual bool IsUse
    {
      get
      {
        if (!this.IsMultiSelect)
          return this.SelectedData != null || this.SelectedCode > 0;
        IList selectedDatas = this.SelectedDatas;
        if ((selectedDatas != null ? selectedDatas.Count : 0) > 0 || this.SelectedCodeIn != null && this.SelectedCodeIn.Length > 0)
          return true;
        return this.SelectedNameIn != null && this.SelectedNameIn.Length > 0;
      }
      set
      {
        if (value)
        {
          this.SelectedData = this.SelectedDataBackup;
          this.SelectedDatas = this.SelectedDatasBackup;
          this.SelectedCode = this.SelectedCodeBackup;
          this.SelectedName = this.SelectedNameBackup;
          this.SelectedCodeIn = this.SelectedCodeInBackup;
          this.SelectedNameIn = this.SelectedNameInBackup;
          if (this.IsEmptySelect)
            this.CmdOpenSelectBoard.Execute((object) null);
        }
        else
        {
          this.SelectedDataBackup = this.SelectedData;
          this.SelectedDatasBackup = this.SelectedDatas;
          this.SelectedCodeBackup = this.SelectedCode;
          this.SelectedNameBackup = this.SelectedName;
          this.SelectedCodeInBackup = this.SelectedCodeIn;
          this.SelectedNameInBackup = this.SelectedNameIn;
          this.SelectedData = (object) null;
          this.SelectedDatas = (IList) null;
          this.SelectedCode = 0;
          this.SelectedName = string.Empty;
          this.SelectedCodeIn = string.Empty;
          this.SelectedNameIn = string.Empty;
        }
        this.Changed(nameof (IsUse));
      }
    }

    public virtual bool IsEmptySelect
    {
      get
      {
        if (!this.IsMultiSelect)
          return this.SelectedData == null && this.SelectedCode == 0;
        IList selectedDatas = this.SelectedDatas;
        if ((selectedDatas != null ? selectedDatas.Count : 0) != 0)
          return false;
        return this.SelectedCodeIn == null || this.SelectedCodeIn.Length == 0;
      }
    }

    protected object SelectedDataBackup { get; set; }

    protected IList SelectedDatasBackup { get; set; }

    public object SelectedData
    {
      get => this.GetValue(CommonControlBase.SelectedDataProperty);
      set => this.SetValue(CommonControlBase.SelectedDataProperty, value);
    }

    public IList SelectedDatas
    {
      get => (IList) this.GetValue(CommonControlBase.SelectedDatasProperty);
      set => this.SetValue(CommonControlBase.SelectedDatasProperty, (object) value);
    }

    public event PropertyChangedEventHandler PropertyChanged = (_param1, _param2) => { };

    public void Changed([CallerMemberName] string name = "") => this.PropertyChanged((object) this, new PropertyChangedEventArgs(name));

    public int SelectedCode
    {
      get => (int) this.GetValue(CommonControlBase.SelectedCodeProperty);
      set => this.SetValue(CommonControlBase.SelectedCodeProperty, (object) value);
    }

    protected int SelectedCodeBackup { get; set; }

    public string SelectedName
    {
      get => (string) this.GetValue(CommonControlBase.SelectedNameProperty);
      set => this.SetValue(CommonControlBase.SelectedNameProperty, (object) value);
    }

    protected string SelectedNameBackup { get; set; }

    public string SelectedCodeIn
    {
      get => (string) this.GetValue(CommonControlBase.SelectedCodeInProperty);
      set => this.SetValue(CommonControlBase.SelectedCodeInProperty, (object) value);
    }

    protected string SelectedCodeInBackup { get; set; }

    public string SelectedNameIn
    {
      get => (string) this.GetValue(CommonControlBase.SelectedNameInProperty);
      set => this.SetValue(CommonControlBase.SelectedNameInProperty, (object) value);
    }

    protected string SelectedNameInBackup { get; set; }

    public Hashtable SearchContion
    {
      get => (Hashtable) this.GetValue(CommonControlBase.SearchContionProperty);
      set => this.SetValue(CommonControlBase.SearchContionProperty, (object) value);
    }
  }
}
