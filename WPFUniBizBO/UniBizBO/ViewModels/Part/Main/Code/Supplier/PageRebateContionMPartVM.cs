// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Part.Main.Code.Supplier.PageRebateContionMPartVM
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Serilog;
using Stylet;
using StyletIoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using UniBiz.Bo.Models;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.UbRest;
using UniBiz.Bo.Models.UniBase.CommonCode;
using UniBiz.Bo.Models.UniBase.Supplier;
using UniBiz.Bo.Models.UniBase.Supplier.RebateConditionDetail;
using UniBiz.Bo.Models.UniBase.Supplier.RebateConditionHeader;
using UniBiz.Bo.Models.UniBase.Supplier.Supplier;
using UniBizBO.Common;
using UniBizBO.Composition;
using UniBizBO.Exceptions;
using UniBizBO.Services.Part;
using UniBizBO.ViewModels.Box;
using UniBizBO.ViewModels.Message;
using UniBizUtil.Util;
using UniinfoNet.Extensions;
using UniinfoNet.Http.UniBiz;
using UniinfoNet.Windows.Wpf;
using UniinfoNet.Windows.Wpf.Commands;


#nullable enable
namespace UniBizBO.ViewModels.Part.Main.Code.Supplier
{
  public class PageRebateContionMPartVM : MPartBase<
  #nullable disable
  SupplierView>
  {
    private RebateConditionHeaderView _RebateHeader = new RebateConditionHeaderView();
    private IList<CommonCodeView> _RebateDateTypeList;
    private IList<CommonCodeView> _RebateAmountTypeList;
    private int _StoreCode;
    private string _StoreName;
    private bool _IsAdmin;
    private bool _IsEnterNext = true;

    public IReadOnlyDictionary<string, TableColumnInfo> RebateHeaderHeader => this.App.Sys?.TableColumns?.GetDictionary<RebateConditionHeaderView>();

    public RebateConditionHeaderView RebateHeader
    {
      get => this._RebateHeader;
      set
      {
        this._RebateHeader = value;
        this.NotifyOfPropertyChange(nameof (RebateHeader));
      }
    }

    public IReadOnlyDictionary<string, TableColumnInfo> RebateDetailHeader => this.App.Sys?.TableColumns?.GetDictionary<RebateConditionDetailView>();

    public BindableCollection<ObservableDataSet<RebateConditionDetailView>> Details { get; } = new BindableCollection<ObservableDataSet<RebateConditionDetailView>>();

    public IList<CommonCodeView> RebateDateTypeList
    {
      get => this._RebateDateTypeList;
      set
      {
        this._RebateDateTypeList = value;
        this.NotifyOfPropertyChange(nameof (RebateDateTypeList));
      }
    }

    public IList<CommonCodeView> RebateAmountTypeList
    {
      get => this._RebateAmountTypeList;
      set
      {
        this._RebateAmountTypeList = value;
        this.NotifyOfPropertyChange(nameof (RebateAmountTypeList));
      }
    }

    public int StoreCode
    {
      get => this._StoreCode;
      set
      {
        int num = this._StoreCode == 0 ? 1 : 0;
        this._StoreCode = value;
        this.NotifyOfPropertyChange(nameof (StoreCode));
        if (num != 0 || this.WorkDataT == null || this.WorkDataT.CurrentT == null || this.WorkDataT.CurrentT.su_Supplier <= 0)
          return;
        this.DoHeaderSearchAsync(this.WorkDataT.CurrentT.su_Supplier);
      }
    }

    public string StoreName
    {
      get => this._StoreName;
      set
      {
        this._StoreName = value;
        this.NotifyOfPropertyChange(nameof (StoreName));
      }
    }

    public bool IsAdmin
    {
      get => this._IsAdmin;
      set
      {
        this._IsAdmin = value;
        this.NotifyOfPropertyChange(nameof (IsAdmin));
      }
    }

    public bool IsEnterNext
    {
      get => this._IsEnterNext;
      set
      {
        this._IsEnterNext = value;
        this.NotifyOfPropertyChange(nameof (IsEnterNext));
      }
    }

    public PageRebateContionMPartVM(IContainer container)
      : base(container)
    {
    }

    protected override void OnInitialActivate()
    {
      base.OnInitialActivate();
      this.RebateDateTypeList = (IList<CommonCodeView>) this.App.Sys.CommonCodes[CommonCodeTypes.SupRebateStdDate].ToArray<CommonCodeView>();
      this.RebateAmountTypeList = (IList<CommonCodeView>) this.App.Sys.CommonCodes[CommonCodeTypes.SupRebateStdAmount].ToArray<CommonCodeView>();
      this.IsAdmin = this.App.User.User.Source.IsAdmin;
      this.StoreCode = this.App.User.User.Source.emp_BaseStore;
      this.StoreName = this.App.User.User.Source.si_StoreName;
      if (this.WorkDataT == null || this.WorkDataT.CurrentT == null || this.PartContainer.IsCreateMode)
        return;
      this.DoHeaderSearchAsync(this.WorkDataT.CurrentT.su_Supplier);
    }

    protected override void OnViewLoaded() => base.OnViewLoaded();

    public override async Task OnReceiveAppWinMessageAsync(AppWinMsg p_param)
    {
      PageRebateContionMPartVM rebateContionMpartVm = this;
      // ISSUE: reference to a compiler-generated method
      await rebateContionMpartVm.\u003C\u003En__0(p_param);
      rebateContionMpartVm.OnAppWinMsgArgsRequested((string) null, (int) p_param.VKey, p_param.Message, p_param.WParam, p_param.LParam);
      await Task.Yield();
    }

    public async void DoHeaderSearchAsync(int p_su_Supplier)
    {
      PageRebateContionMPartVM rebateContionMpartVm1 = this;
      try
      {
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (rebateContionMpartVm1.Job).CreateJob("조회", (string) null))
        {
          rebateContionMpartVm1.Details.Clear();
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          RebateConditionHeaderView data = (await SupplierRestServer.GetRebateConditionHeader(rebateContionMpartVm1.LogInPackInfo.sendType, rebateContionMpartVm1.LogInPackInfo.siteID, p_su_Supplier, rebateContionMpartVm1.StoreCode, 0, __nonvirtual (rebateContionMpartVm1.MenuInfo).Code).ExecuteToReturnAsync<UbRes<RebateConditionHeaderView>>((UniBizHttpClient) __nonvirtual (rebateContionMpartVm1.App).Api)).GetData<RebateConditionHeaderView>();
          if (data != null)
          {
            if (data.Lt_Details != null)
            {
              rebateContionMpartVm1.RebateHeader = data;
              rebateContionMpartVm1.Details.AddRange(data.Lt_Details.Select<RebateConditionDetailView, ObservableDataSet<RebateConditionDetailView>>((Func<RebateConditionDetailView, ObservableDataSet<RebateConditionDetailView>>) (it => new ObservableDataSet<RebateConditionDetailView>(it))));
            }
          }
        }
      }
      catch (Exception ex)
      {
        Log.Error(ex.Message);
        PageRebateContionMPartVM rebateContionMpartVm2 = rebateContionMpartVm1;
        RebateConditionHeaderView conditionHeaderView = new RebateConditionHeaderView();
        conditionHeaderView.rch_StoreCode = rebateContionMpartVm1.StoreCode;
        // ISSUE: explicit non-virtual call
        conditionHeaderView.rch_Supplier = __nonvirtual (rebateContionMpartVm1.WorkDataT).CurrentT.su_Supplier;
        conditionHeaderView.Lt_Details = (IList<RebateConditionDetailView>) new List<RebateConditionDetailView>();
        conditionHeaderView.si_StoreName = rebateContionMpartVm1.StoreName;
        // ISSUE: explicit non-virtual call
        conditionHeaderView.su_SupplierName = __nonvirtual (rebateContionMpartVm1.WorkDataT).CurrentT.su_SupplierName;
        // ISSUE: explicit non-virtual call
        conditionHeaderView.su_SupplierViewCode = __nonvirtual (rebateContionMpartVm1.WorkDataT).CurrentT.su_SupplierViewCode;
        rebateContionMpartVm2.RebateHeader = conditionHeaderView;
      }
    }

    public async void DoRebateSaveAsync()
    {
      PageRebateContionMPartVM rebateContionMpartVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (rebateContionMpartVm.Job).CreateJob("성과 장려율 저장", (string) null))
        {
          foreach (RebateConditionDetailView conditionDetailView in rebateContionMpartVm.Details.Select<ObservableDataSet<RebateConditionDetailView>, RebateConditionDetailView>((Func<ObservableDataSet<RebateConditionDetailView>, RebateConditionDetailView>) (it => it.OriginT)))
          {
            if (conditionDetailView.IsNew || conditionDetailView.IsUpdate)
              rebateContionMpartVm.RebateHeader.Lt_Details.Add(conditionDetailView);
          }
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          RebateConditionHeaderView data = (await SupplierRestServer.PostRebateConditionHeader(rebateContionMpartVm.LogInPackInfo.sendType, rebateContionMpartVm.LogInPackInfo.siteID, __nonvirtual (rebateContionMpartVm.WorkDataT).CurrentT.su_Supplier, rebateContionMpartVm.StoreCode, 0, __nonvirtual (rebateContionMpartVm.MenuInfo).Code, rebateContionMpartVm.RebateHeader).ExecuteToReturnAsync<UbRes<RebateConditionHeaderView>>((UniBizHttpClient) __nonvirtual (rebateContionMpartVm.App).Api)).GetData<RebateConditionHeaderView>();
          rebateContionMpartVm.Details.Clear();
          if (data != null)
          {
            if (data.Lt_Details != null)
            {
              rebateContionMpartVm.RebateHeader = data;
              rebateContionMpartVm.Details.AddRange(rebateContionMpartVm.RebateHeader.Lt_Details.Select<RebateConditionDetailView, ObservableDataSet<RebateConditionDetailView>>((Func<RebateConditionDetailView, ObservableDataSet<RebateConditionDetailView>>) (it => new ObservableDataSet<RebateConditionDetailView>(it))));
            }
          }
        }
      }
      catch (Exception ex)
      {
        Log.Error(ex.Message);
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (rebateContionMpartVm.Container)).Set(__nonvirtual (rebateContionMpartVm.MenuInfo).Title + " 오류", ex.Message).ShowDialog();
      }
    }

    public WpfCommand CmdRebateDetailInsertRow => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        IsAutoRefresh = true,
        CanExecuteFunc = (Func<object, bool>) (_ => this.CanIsPaymentInput()),
        ExecuteAction = (Action<object>) (_ => this.RebateDetailInsertRow())
      };
    }), nameof (CmdRebateDetailInsertRow));

    public void RebateDetailInsertRow()
    {
      foreach (UbModelBase ubModelBase in this.Details.Select<ObservableDataSet<RebateConditionDetailView>, RebateConditionDetailView>((Func<ObservableDataSet<RebateConditionDetailView>, RebateConditionDetailView>) (it => it.OriginT)))
      {
        if (ubModelBase.IsNew)
        {
          int num = (int) new CommonMsgVM(this.Container).Set(this.MenuInfo.Title, "장려율 구간 조건 저장후 추가 가능").ShowDialog();
          return;
        }
      }
      RebateConditionDetailView data1 = new RebateConditionDetailView();
      data1.row_number = 0;
      data1.DB_STATUS = EnumDBStatus.NEW;
      data1.rcd_StoreCode = this.RebateHeader.rch_StoreCode;
      data1.rcd_Supplier = this.RebateHeader.rch_Supplier;
      ObservableDataSet<RebateConditionDetailView> data = new ObservableDataSet<RebateConditionDetailView>(data1);
      this.Details.Insert(0, data);
      ((DispatcherObject) this.View).Dispatcher.InvokeAsync((Action) (() => this.DataView.Target.EditTarget((object) data, (string) null)), (DispatcherPriority) 4);
    }

    public bool CanIsPaymentInput() => this.App.User.User.Source.IsPaymentInput;

    public WpfCommand CmdRebateSave => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        IsAutoRefresh = true,
        CanExecuteFunc = (Func<object, bool>) (_ => this.CanIsPaymentInput()),
        ExecuteAction = (Action<object>) (_ => this.RebateSave())
      };
    }), nameof (CmdRebateSave));

    public void RebateSave()
    {
      if (new CommonMsgVM(this.Container).SetDefault(MsgBoxLevel.Info, "저장", "성과 장려율을 저장 할까요?", MsgBoxButton.Confirm, MsgBoxButton.Confirm, MsgBoxButton.Cancel).ShowDialog() != MsgBoxButton.Confirm)
        return;
      this.DoRebateSaveAsync();
    }

    public void OnWinClose()
    {
      if (new CommonMsgVM(this.Container).SetDefault(MsgBoxLevel.Info, "창 닫기", this.MenuInfo.Title + " 창 을(를) 종료 할까요?", MsgBoxButton.Confirm, MsgBoxButton.Confirm, MsgBoxButton.Cancel).ShowDialog() != MsgBoxButton.Confirm)
        return;
      this.PartContainerT.WinClose();
    }

    public Action<UniDataEditArgs> EditingAct => new Action<UniDataEditArgs>(this.DetailesEditing);

    protected void DetailesEditing(UniDataEditArgs arg)
    {
      if (this.View == null)
        return;
      ObservableDataSet<RebateConditionDetailView> item = arg.Item as ObservableDataSet<RebateConditionDetailView>;
      if (item == null)
        return;
      if (arg.Act == UniDataEditAction.Begin)
      {
        if (item.IsWorking)
        {
          arg.CancelAct = true;
          return;
        }
        if (arg.Target == UniDataEditTarget.PropertyInItem)
        {
          if (arg.Key == null)
            return;
          if (!item.OriginT.IsNew)
          {
            arg.CancelAct = true;
            this.DoGridNextWork(arg, item);
            return;
          }
        }
      }
      if (arg.Target != UniDataEditTarget.PropertyInItem || arg.Act != UniDataEditAction.Commit)
        return;
      item.IsTag = true;
      item.IsWorking = true;
      Func<PageRebateContionMPartVM.RebateDoGridNextArgs> func;
      ((DispatcherObject) this.View).Dispatcher.InvokeAsync<Task>((Func<Task>) (async () =>
      {
        PageRebateContionMPartVM.RebateDoGridNextArgs rebateDoGridNextArgs = await Task.Factory.StartNew<PageRebateContionMPartVM.RebateDoGridNextArgs>(func ?? (func = (Func<PageRebateContionMPartVM.RebateDoGridNextArgs>) (() =>
        {
          if (!arg.IsChangedEditingValue)
            return arg.IsPressedEnter && this.IsEnterNext || arg.IsPressedTab ? new PageRebateContionMPartVM.RebateDoGridNextArgs(arg, item) : (PageRebateContionMPartVM.RebateDoGridNextArgs) null;
          bool flag3 = false;
          bool flag4;
          switch (arg.Key)
          {
            case "rcd_StdAmtFrom":
              flag4 = item.OriginT.rcd_StdAmtFrom.IsEqual(Convert.ToDouble(arg.EditingValue));
              break;
            case "rcd_StdAmtTo":
              flag4 = item.OriginT.rcd_StdAmtTo.IsEqual(Convert.ToDouble(arg.EditingValue));
              break;
            case "rcd_RebateRate":
              flag4 = item.OriginT.rcd_RebateRate.IsEqual(Convert.ToDouble(arg.EditingValue));
              break;
            default:
              flag4 = flag3;
              break;
          }
          if (flag4)
            return new PageRebateContionMPartVM.RebateDoGridNextArgs(arg, item);
          RebateConditionDetailView data = (RebateConditionDetailView) null;
          string title = string.Format("[{0}] 변경 중...", (object) this.RebateDetailHeader[arg.Key.ToString()]);
          try
          {
            using (this.Job.CreateJob(title, (string) null))
            {
              switch (arg.Key)
              {
                case "rcd_StdAmtFrom":
                  data = item.OriginT.CloneByJson<RebateConditionDetailView>();
                  data.rcd_StdAmtFrom = double.Parse(string.Format("{0:F4}", (object) Convert.ToDouble(arg.EditingValue)));
                  item.IsTag = false;
                  break;
                case "rcd_StdAmtTo":
                  data = item.OriginT.CloneByJson<RebateConditionDetailView>();
                  data.rcd_StdAmtTo = double.Parse(string.Format("{0:F4}", (object) Convert.ToDouble(arg.EditingValue)));
                  item.IsTag = false;
                  break;
                case "rcd_RebateRate":
                  data = item.OriginT.CloneByJson<RebateConditionDetailView>();
                  data.rcd_RebateRate = double.Parse(string.Format("{0:F4}", (object) Convert.ToDouble(arg.EditingValue)));
                  item.IsTag = false;
                  break;
              }
            }
          }
          catch (Exception ex)
          {
            Log.Debug("------------------------------------------");
            Log.Debug(ex.Message);
            Log.Debug("------------------------------------------");
            data = (RebateConditionDetailView) null;
            item.IsTag = true;
          }
          if (item.IsTag)
            return new PageRebateContionMPartVM.RebateDoGridNextArgs(arg, item, EnumUniUserException.Stop);
          if (data != null)
          {
            if (!data.IsNew)
              data.db_status = 2;
            item.Set(data);
            this.DataView.Target.NotifyItemsChanged();
          }
          return new PageRebateContionMPartVM.RebateDoGridNextArgs(arg, item);
        })));
        item.IsWorking = false;
        if (!(rebateDoGridNextArgs != (PageRebateContionMPartVM.RebateDoGridNextArgs) null))
          return;
        this.DoGridNextWork(rebateDoGridNextArgs);
      }), (DispatcherPriority) 4);
    }

    protected void DoGridNextWork(PageRebateContionMPartVM.RebateDoGridNextArgs arg)
    {
      UniDataEditArgs dataEditArg = arg.DataEditArg;
      ObservableDataSet<RebateConditionDetailView> observableDataSet1 = arg.Item;
      string messageTitle = arg.MessageTitle;
      string message = arg.Message;
      EnumUniUserException work = arg.Work;
      if (this.View == null)
        return;
      switch (work)
      {
        case EnumUniUserException.Error:
          observableDataSet1.RollBack();
          if (message.Length > 0)
          {
            int num1 = (int) new CommonMsgVM(this.Container).Set(messageTitle, message).ShowDialog();
          }
          this.DataView.Target.EditTarget((object) observableDataSet1, "rcd_StdAmtFrom");
          break;
        case EnumUniUserException.Stop:
          observableDataSet1.RollBack();
          if (message.Length > 0)
          {
            int num2 = (int) new CommonMsgVM(this.Container).Set(messageTitle, message).ShowDialog();
          }
          this.DataView.Target.EditTarget((object) observableDataSet1, dataEditArg.Key);
          break;
        case EnumUniUserException.Next:
          ObservableDataSet<RebateConditionDetailView> observableDataSet2 = observableDataSet1;
          string key = dataEditArg.Key;
          int moveCount = 1;
          if (dataEditArg.EditablePropertiesCount == dataEditArg.EditablePropertyIndex + 1)
          {
            observableDataSet2 = this.Details[this.Details.IndexOf(observableDataSet1) + 1];
            key = (string) null;
            moveCount = 0;
          }
          this.DataView.Target.EditTarget((object) observableDataSet2, key, moveCount);
          break;
      }
    }

    protected void DoGridNextWork(
      UniDataEditArgs arg,
      ObservableDataSet<RebateConditionDetailView> item,
      EnumUniUserException work = EnumUniUserException.Next,
      string messageTitle = "",
      string message = "")
    {
      this.DoGridNextWork(new PageRebateContionMPartVM.RebateDoGridNextArgs()
      {
        DataEditArg = arg,
        Item = item,
        Work = work,
        MessageTitle = messageTitle,
        Message = message
      });
    }

    protected async Task DoGridNextWorkAsync(
      UniDataEditArgs pArg,
      ObservableDataSet<RebateConditionDetailView> pItem,
      EnumUniUserException pWork = EnumUniUserException.Next,
      string pMessageTitle = "",
      string pMessage = "")
    {
      PageRebateContionMPartVM rebateContionMpartVm = this;
      // ISSUE: explicit non-virtual call
      if (__nonvirtual (rebateContionMpartVm.View) == null)
        return;
      switch (pWork)
      {
        case EnumUniUserException.Error:
          // ISSUE: explicit non-virtual call
          await ((DispatcherObject) __nonvirtual (rebateContionMpartVm.View)).Dispatcher.InvokeAsync((Action) (() =>
          {
            pItem.RollBack();
            pItem.IsWorking = false;
            if (pMessage.Length > 0)
            {
              int num = (int) new CommonMsgVM(this.Container).Set(pMessageTitle, pMessage).ShowDialog();
            }
            this.DataView.Target.EditTarget((object) pItem, pArg.Key);
          }), (DispatcherPriority) 4);
          break;
        case EnumUniUserException.Stop:
          // ISSUE: explicit non-virtual call
          await ((DispatcherObject) __nonvirtual (rebateContionMpartVm.View)).Dispatcher.InvokeAsync((Action) (() =>
          {
            pItem.IsWorking = false;
            if (pMessage.Length > 0)
            {
              int num = (int) new CommonMsgVM(this.Container).Set(pMessageTitle, pMessage).ShowDialog();
            }
            this.DataView.Target.EditTarget((object) pItem, pArg.Key);
          }), (DispatcherPriority) 4);
          break;
        case EnumUniUserException.Next:
          // ISSUE: explicit non-virtual call
          await ((DispatcherObject) __nonvirtual (rebateContionMpartVm.View)).Dispatcher.InvokeAsync((Action) (() =>
          {
            pItem.IsWorking = false;
            if (pArg.IsPressedEnter && this.IsEnterNext)
            {
              this.DataView.Target.EditTarget((object) pItem, pArg.Key, 1);
            }
            else
            {
              if (!pArg.IsPressedTab)
                return;
              this.DataView.Target.EditTarget((object) pItem, pArg.Key, 1);
            }
          }), (DispatcherPriority) 4);
          break;
      }
    }

    public record RebateDoGridNextArgs()
    {
      public RebateDoGridNextArgs(
        UniDataEditArgs arg,
        ObservableDataSet<RebateConditionDetailView> item,
        EnumUniUserException work = EnumUniUserException.Next,
        string messageTitle = "",
        string message = "")
      {
        UniDataEditArgs uniDataEditArgs1 = arg;
        ObservableDataSet<RebateConditionDetailView> observableDataSet1 = item;
        EnumUniUserException uniUserException1 = work;
        string str1 = messageTitle;
        string str2 = message;
        UniDataEditArgs uniDataEditArgs2;
        this.DataEditArg = uniDataEditArgs2 = uniDataEditArgs1;
        ObservableDataSet<RebateConditionDetailView> observableDataSet2;
        this.Item = observableDataSet2 = observableDataSet1;
        EnumUniUserException uniUserException2;
        this.Work = uniUserException2 = uniUserException1;
        this.Message = (this.MessageTitle = str1) = str2;
      }

      public UniDataEditArgs DataEditArg { get; set; }

      public ObservableDataSet<RebateConditionDetailView> Item { get; set; }

      public EnumUniUserException Work { get; set; } = EnumUniUserException.Next;

      public string MessageTitle { get; set; }

      public string Message { get; set; }

      protected virtual bool PrintMembers(
      #nullable enable
      StringBuilder builder)
      {
        builder.Append("DataEditArg");
        builder.Append(" = ");
        builder.Append((object) this.DataEditArg);
        builder.Append(", ");
        builder.Append("Item");
        builder.Append(" = ");
        builder.Append((object) this.Item);
        builder.Append(", ");
        builder.Append("Work");
        builder.Append(" = ");
        builder.Append(this.Work.ToString());
        builder.Append(", ");
        builder.Append("MessageTitle");
        builder.Append(" = ");
        builder.Append((object) this.MessageTitle);
        builder.Append(", ");
        builder.Append("Message");
        builder.Append(" = ");
        builder.Append((object) this.Message);
        return true;
      }

      public override int GetHashCode() => ((((EqualityComparer<Type>.Default.GetHashCode(this.EqualityContract) * -1521134295 + EqualityComparer<UniDataEditArgs>.Default.GetHashCode(this.\u003CDataEditArg\u003Ek__BackingField)) * -1521134295 + EqualityComparer<ObservableDataSet<RebateConditionDetailView>>.Default.GetHashCode(this.\u003CItem\u003Ek__BackingField)) * -1521134295 + EqualityComparer<EnumUniUserException>.Default.GetHashCode(this.\u003CWork\u003Ek__BackingField)) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(this.\u003CMessageTitle\u003Ek__BackingField)) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(this.\u003CMessage\u003Ek__BackingField);

      public virtual bool Equals(
        PageRebateContionMPartVM.RebateDoGridNextArgs? other)
      {
        if ((object) this == (object) other)
          return true;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        return (object) other != null && this.EqualityContract == other.EqualityContract && EqualityComparer<UniDataEditArgs>.Default.Equals(this.\u003CDataEditArg\u003Ek__BackingField, other.\u003CDataEditArg\u003Ek__BackingField) && EqualityComparer<ObservableDataSet<RebateConditionDetailView>>.Default.Equals(this.\u003CItem\u003Ek__BackingField, other.\u003CItem\u003Ek__BackingField) && EqualityComparer<EnumUniUserException>.Default.Equals(this.\u003CWork\u003Ek__BackingField, other.\u003CWork\u003Ek__BackingField) && EqualityComparer<string>.Default.Equals(this.\u003CMessageTitle\u003Ek__BackingField, other.\u003CMessageTitle\u003Ek__BackingField) && EqualityComparer<string>.Default.Equals(this.\u003CMessage\u003Ek__BackingField, other.\u003CMessage\u003Ek__BackingField);
      }

      protected RebateDoGridNextArgs(
        PageRebateContionMPartVM.RebateDoGridNextArgs original)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.\u003CDataEditArg\u003Ek__BackingField = original.\u003CDataEditArg\u003Ek__BackingField;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.\u003CItem\u003Ek__BackingField = original.\u003CItem\u003Ek__BackingField;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.\u003CWork\u003Ek__BackingField = original.\u003CWork\u003Ek__BackingField;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.\u003CMessageTitle\u003Ek__BackingField = original.\u003CMessageTitle\u003Ek__BackingField;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.\u003CMessage\u003Ek__BackingField = original.\u003CMessage\u003Ek__BackingField;
      }
    }
  }
}
