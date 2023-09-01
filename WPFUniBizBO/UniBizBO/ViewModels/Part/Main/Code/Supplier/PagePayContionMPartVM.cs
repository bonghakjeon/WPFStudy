// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Part.Main.Code.Supplier.PagePayContionMPartVM
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Serilog;
using Stylet;
using StyletIoC;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;
using UniBiz.Bo.Models;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.UbRest;
using UniBiz.Bo.Models.UniBase.CommonCode;
using UniBiz.Bo.Models.UniBase.Supplier;
using UniBiz.Bo.Models.UniBase.Supplier.PayContion;
using UniBiz.Bo.Models.UniBase.Supplier.Supplier;
using UniBiz.Bo.Models.UniBase.Supplier.SupplierAutoDeduction;
using UniBiz.Bo.Models.UniBase.Supplier.SupplierHistory;
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
using UniinfoNet.Windows.Wpf.DataView;


#nullable enable
namespace UniBizBO.ViewModels.Part.Main.Code.Supplier
{
  public class PagePayContionMPartVM : MPartBase<
  #nullable disable
  SupplierView>
  {
    private SupplierHistoryView _SupplierHistory;
    private string _HistoryRemark = string.Empty;
    private BindableCollection<CommonCodeView> _DeductionAutoTypeDatas = new BindableCollection<CommonCodeView>();
    private UniDataViewDescription _AutoDeductionDataView;
    private IList<PayContionView> _PayContionList = (IList<PayContionView>) new List<PayContionView>();
    private int _StoreCode;
    private string _StoreName;
    private string _FooterRemark = string.Empty;
    private string _FooterAutoDeduction = string.Empty;
    private string _TitleAutoDeduction = string.Empty;
    private bool _IsAdmin;
    private bool _IsEnterNext = true;
    private DateTime ToDay = new DateTime?(DateTime.Now).GetDateToStr("yyyy-MM-dd").GetStr2Date("yyyy-MM-dd").Value;

    public IReadOnlyDictionary<string, TableColumnInfo> SupplierHistoryHeader => this.App.Sys?.TableColumns?.GetDictionary<SupplierHistoryView>();

    public BindableCollection<ObservableDataSet<SupplierHistoryView>> Details { get; } = new BindableCollection<ObservableDataSet<SupplierHistoryView>>();

    public SupplierHistoryView SupplierHistory
    {
      get => this._SupplierHistory;
      set
      {
        this._SupplierHistory = value;
        this.NotifyOfPropertyChange(nameof (SupplierHistory));
        if (this._SupplierHistory == null)
          return;
        __Boxed<int> rowNumber = (ValueType) this._SupplierHistory.row_number;
        DateTime? nullable = this._SupplierHistory.suh_StartDate;
        string dateToStr1 = new DateTime?(nullable.Value).GetDateToStr("yyyy-MM-dd");
        nullable = this._SupplierHistory.suh_EndDate;
        string dateToStr2 = new DateTime?(nullable.Value).GetDateToStr("yyyy-MM-dd");
        this.HistoryRemark = string.Format("No.({0}) > [{1} ~ {2}]", (object) rowNumber, (object) dateToStr1, (object) dateToStr2);
      }
    }

    public string HistoryRemark
    {
      get => this._HistoryRemark;
      set
      {
        this._HistoryRemark = value;
        this.NotifyOfPropertyChange(nameof (HistoryRemark));
      }
    }

    public BindableCollection<CommonCodeView> DeductionAutoTypeDatas
    {
      get => this._DeductionAutoTypeDatas;
      set
      {
        this._DeductionAutoTypeDatas = value;
        this.NotifyOfPropertyChange(nameof (DeductionAutoTypeDatas));
      }
    }

    public IReadOnlyDictionary<string, TableColumnInfo> SupplierAutoDeductionHeader => this.App.Sys?.TableColumns?.GetDictionary<SupplierAutoDeductionView>();

    public BindableCollection<ObservableDataSet<SupplierAutoDeductionView>> AutoDeductionDetails { get; } = new BindableCollection<ObservableDataSet<SupplierAutoDeductionView>>();

    public UniDataViewDescription AutoDeductionDataView
    {
      get => this._AutoDeductionDataView ?? (this._AutoDeductionDataView = new UniDataViewDescription());
      set
      {
        this._AutoDeductionDataView = value;
        this.NotifyOfPropertyChange(nameof (AutoDeductionDataView));
      }
    }

    public IList<PayContionView> PayContionList
    {
      get => this._PayContionList;
      set
      {
        this._PayContionList = value;
        this.NotifyOfPropertyChange(nameof (PayContionList));
      }
    }

    public int StoreCode
    {
      get => this._StoreCode;
      set
      {
        this._StoreCode = value;
        this.NotifyOfPropertyChange(nameof (StoreCode));
        if (this.WorkDataT == null || this.WorkDataT.CurrentT == null || this.WorkDataT.CurrentT.su_Supplier <= 0)
          return;
        this.SearchnAsync(this.WorkDataT.CurrentT.su_Supplier);
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

    public string FooterRemark
    {
      get => this._FooterRemark;
      set
      {
        this._FooterRemark = value;
        this.NotifyOfPropertyChange(nameof (FooterRemark));
      }
    }

    public string FooterAutoDeduction
    {
      get => this._FooterAutoDeduction;
      set
      {
        this._FooterAutoDeduction = value;
        this.NotifyOfPropertyChange(nameof (FooterAutoDeduction));
      }
    }

    public string TitleAutoDeduction
    {
      get => this._TitleAutoDeduction;
      set
      {
        this._TitleAutoDeduction = value;
        this.NotifyOfPropertyChange(nameof (TitleAutoDeduction));
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

    public PagePayContionMPartVM(IContainer container)
      : base(container)
    {
    }

    protected override void OnInitialActivate()
    {
      base.OnInitialActivate();
      this.IsAdmin = this.App.User.User.Source.IsAdmin;
      this.StoreCode = this.App.User.User.Source.emp_BaseStore;
      this.StoreName = this.App.User.User.Source.si_StoreName;
      this.SearchPayContionnAsync();
      this.DeductionAutoTypeDatas.Clear();
      foreach (CommonCodeView commonCodeView1 in this.App.Sys.CommonCodes[CommonCodeTypes.DeductionAutoType].Where<CommonCodeView>((Func<CommonCodeView, bool>) (common => common.comm_TypeNo > 0)).ToArray<CommonCodeView>())
      {
        BindableCollection<CommonCodeView> deductionAutoTypeDatas = this.DeductionAutoTypeDatas;
        CommonCodeView commonCodeView2 = new CommonCodeView();
        commonCodeView2.row_number = this.DeductionAutoTypeDatas.Count;
        commonCodeView2.comm_Type = commonCodeView1.comm_Type;
        commonCodeView2.comm_TypeNo = commonCodeView1.comm_TypeNo;
        commonCodeView2.comm_TypeMemo = commonCodeView1.comm_TypeMemo;
        commonCodeView2.comm_TypeNoMemo = commonCodeView1.comm_TypeNoMemo;
        commonCodeView2.comm_UseYn = commonCodeView1.comm_IsUseYn ? "Y" : "N";
        commonCodeView2.comm_SortNo = commonCodeView1.comm_SortNo;
        commonCodeView2.comm_DataMoney = commonCodeView1.comm_DataMoney;
        commonCodeView2.comm_DataInt = commonCodeView1.comm_DataInt;
        commonCodeView2.comm_DataString = commonCodeView1.comm_DataString;
        deductionAutoTypeDatas.Add(commonCodeView2);
      }
      this.Details.Clear();
      this.AutoDeductionDetails.Clear();
      if (this.WorkDataT == null || this.WorkDataT.CurrentT == null || this.PartContainer.IsCreateMode)
        return;
      this.SearchnAsync(this.WorkDataT.CurrentT.su_Supplier);
    }

    protected override void OnViewLoaded() => base.OnViewLoaded();

    public override async Task OnReceiveAppWinMessageAsync(AppWinMsg p_param)
    {
      PagePayContionMPartVM payContionMpartVm = this;
      // ISSUE: reference to a compiler-generated method
      await payContionMpartVm.\u003C\u003En__0(p_param);
      payContionMpartVm.OnAppWinMsgArgsRequested((string) null, (int) p_param.VKey, p_param.Message, p_param.WParam, p_param.LParam);
      await Task.Yield();
    }

    public async void DoSupplierHistoryPostAsync(SupplierHistoryView p_data)
    {
      PagePayContionMPartVM payContionMpartVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (payContionMpartVm.Job).CreateJob("추가", (string) null))
        {
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          (await SupplierRestServer.PostSupplierHistory(payContionMpartVm.LogInPackInfo.sendType, payContionMpartVm.LogInPackInfo.siteID, p_data.suh_ID, 0, __nonvirtual (payContionMpartVm.MenuInfo).Code, p_data).ExecuteToReturnAsync<UbRes<SupplierHistoryView>>((UniBizHttpClient) __nonvirtual (payContionMpartVm.App).Api)).GetData<SupplierHistoryView>();
          p_data.DB_STATUS = EnumDBStatus.NONE;
          // ISSUE: explicit non-virtual call
          payContionMpartVm.SearchnAsync(__nonvirtual (payContionMpartVm.WorkDataT).CurrentT.su_Supplier);
        }
      }
      catch (Exception ex)
      {
        Log.Error(ex.Message);
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (payContionMpartVm.Container)).Set(__nonvirtual (payContionMpartVm.MenuInfo).Title + " 등록 오류", ex.Message).ShowDialog();
      }
    }

    public async void SearchPayContionnAsync()
    {
      PagePayContionMPartVM payContionMpartVm = this;
      try
      {
        if (payContionMpartVm.PayContionList.Count != 0)
          return;
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (payContionMpartVm.Job).CreateJob("결제 조건 조회", (string) null))
        {
          payContionMpartVm.PayContionList.Clear();
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          UbRes<IList<PayContionView>> returnAsync = await SupplierRestServer.GetPayContionListAsync(payContionMpartVm.LogInPackInfo.sendType, payContionMpartVm.LogInPackInfo.siteID, 0, __nonvirtual (payContionMpartVm.MenuInfo).Code).ExecuteToReturnAsync<UbRes<IList<PayContionView>>>((UniBizHttpClient) __nonvirtual (payContionMpartVm.App).Api);
          payContionMpartVm.PayContionList = returnAsync.GetData<IList<PayContionView>>();
        }
      }
      catch (Exception ex)
      {
        Log.Error(ex.Message);
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (payContionMpartVm.Container)).Set(__nonvirtual (payContionMpartVm.MenuInfo).Title + " 오류", ex.Message).ShowDialog();
      }
    }

    public async void SearchnAsync(int p_su_Supplier)
    {
      PagePayContionMPartVM payContionMpartVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (payContionMpartVm.Job).CreateJob("결제 이력 조회", (string) null))
        {
          string sendType = payContionMpartVm.LogInPackInfo.sendType;
          long siteId = payContionMpartVm.LogInPackInfo.siteID;
          int num = p_su_Supplier;
          int storeCode = payContionMpartVm.StoreCode;
          // ISSUE: explicit non-virtual call
          int code = __nonvirtual (payContionMpartVm.MenuInfo).Code;
          int suh_Supplier = num;
          int suh_StoreCode = storeCode;
          // ISSUE: explicit non-virtual call
          IList<SupplierHistoryView> data = (await SupplierRestServer.GetSupplierHistoryList(sendType, siteId, 0, code, suh_Supplier: suh_Supplier, suh_StoreCode: suh_StoreCode, OrderByType: 1).ExecuteToReturnAsync<UbRes<IList<SupplierHistoryView>>>((UniBizHttpClient) __nonvirtual (payContionMpartVm.App).Api)).GetData<IList<SupplierHistoryView>>();
          payContionMpartVm.Details.Clear();
          payContionMpartVm.AutoDeductionDetails.Clear();
          payContionMpartVm.FooterRemark = string.Empty;
          payContionMpartVm.Details.AddRange(data.Select<SupplierHistoryView, ObservableDataSet<SupplierHistoryView>>((Func<SupplierHistoryView, ObservableDataSet<SupplierHistoryView>>) (it => new ObservableDataSet<SupplierHistoryView>(it))));
          if (data.Count > 0)
          {
            payContionMpartVm.FooterRemark = "[" + data.Count.ToString("#,##0") + "] 건 조회";
            payContionMpartVm.SupplierHistory = payContionMpartVm.Details.Select<ObservableDataSet<SupplierHistoryView>, SupplierHistoryView>((Func<ObservableDataSet<SupplierHistoryView>, SupplierHistoryView>) (it => it.OriginT)).FirstOrDefault<SupplierHistoryView>();
            payContionMpartVm.SearchAutoDeductionAsync(payContionMpartVm.Details.Select<ObservableDataSet<SupplierHistoryView>, SupplierHistoryView>((Func<ObservableDataSet<SupplierHistoryView>, SupplierHistoryView>) (it => it.OriginT)).FirstOrDefault<SupplierHistoryView>().suh_ID);
            payContionMpartVm.OnAppWinMsgArgsRequested("GRID");
          }
        }
      }
      catch (Exception ex)
      {
        Log.Error(ex.Message);
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (payContionMpartVm.Container)).Set(__nonvirtual (payContionMpartVm.MenuInfo).Title + " 오류", ex.Message).ShowDialog();
      }
    }

    public async void SearchAutoDeductionAsync(int p_suh_ID)
    {
      PagePayContionMPartVM payContionMpartVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (payContionMpartVm.Job).CreateJob("공제 조건 조회", (string) null))
        {
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          IList<SupplierAutoDeductionView> data = (await SupplierRestServer.GetSupplierAutoDeductionList(payContionMpartVm.LogInPackInfo.sendType, payContionMpartVm.LogInPackInfo.siteID, 0, __nonvirtual (payContionMpartVm.MenuInfo).Code, p_suh_ID).ExecuteToReturnAsync<UbRes<IList<SupplierAutoDeductionView>>>((UniBizHttpClient) __nonvirtual (payContionMpartVm.App).Api)).GetData<IList<SupplierAutoDeductionView>>();
          payContionMpartVm.FooterAutoDeduction = string.Empty;
          payContionMpartVm.TitleAutoDeduction = string.Empty;
          payContionMpartVm.AutoDeductionDetails.Clear();
          payContionMpartVm.AutoDeductionDetails.AddRange(data.Select<SupplierAutoDeductionView, ObservableDataSet<SupplierAutoDeductionView>>((Func<SupplierAutoDeductionView, ObservableDataSet<SupplierAutoDeductionView>>) (it => new ObservableDataSet<SupplierAutoDeductionView>(it))));
          if (data.Count > 0)
          {
            payContionMpartVm.FooterAutoDeduction = "[" + data.Count.ToString("#,##0") + "] 건 조회";
            IEnumerable<SupplierHistoryView> source = payContionMpartVm.Details.Select<ObservableDataSet<SupplierHistoryView>, SupplierHistoryView>((Func<ObservableDataSet<SupplierHistoryView>, SupplierHistoryView>) (it => it.OriginT)).Where<SupplierHistoryView>((Func<SupplierHistoryView, bool>) (it => it.suh_ID == p_suh_ID));
            SupplierHistoryView supplierHistoryView = source != null ? source.FirstOrDefault<SupplierHistoryView>() : (SupplierHistoryView) null;
            if (supplierHistoryView != null)
              payContionMpartVm.TitleAutoDeduction = "[기간 : " + supplierHistoryView.suh_StartDate.GetDateToStr("yyyy-MM-dd") + " ~ " + supplierHistoryView.suh_EndDate.GetDateToStr("yyyy-MM-dd") + "]";
          }
        }
      }
      catch (Exception ex)
      {
        Log.Error(ex.Message);
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (payContionMpartVm.Container)).Set(__nonvirtual (payContionMpartVm.MenuInfo).Title + " 오류", ex.Message).ShowDialog();
      }
      await Task.Yield();
    }

    public async Task PostAutoDeductionAsync(List<SupplierAutoDeductionView> p_list)
    {
      PagePayContionMPartVM payContionMpartVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (payContionMpartVm.Job).CreateJob("공제 조건 추가", (string) null))
        {
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          (await SupplierRestServer.PostSupplierAuthDeducktionList(payContionMpartVm.LogInPackInfo.sendType, payContionMpartVm.LogInPackInfo.siteID, 0, __nonvirtual (payContionMpartVm.MenuInfo).Code, (IList<SupplierAutoDeductionView>) p_list).ExecuteToReturnAsync<UbRes<IList<SupplierAutoDeductionView>>>((UniBizHttpClient) __nonvirtual (payContionMpartVm.App).Api)).GetSuccess<UbRes<IList<SupplierAutoDeductionView>>>();
          payContionMpartVm.SearchAutoDeductionAsync(payContionMpartVm.SupplierHistory.suh_ID);
        }
      }
      catch (Exception ex)
      {
        Log.Error(ex.Message);
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (payContionMpartVm.Container)).Set(__nonvirtual (payContionMpartVm.MenuInfo).Title + " 오류", ex.Message).ShowDialog();
      }
    }

    public async Task DeleteAutoDeductionAsync(List<SupplierAutoDeductionView> p_list)
    {
      PagePayContionMPartVM payContionMpartVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (payContionMpartVm.Job).CreateJob("공제 조건 추가", (string) null))
        {
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          (await SupplierRestServer.DeleteSupplierAutoDeductionList(payContionMpartVm.LogInPackInfo.sendType, payContionMpartVm.LogInPackInfo.siteID, 0, __nonvirtual (payContionMpartVm.MenuInfo).Code, (IList<SupplierAutoDeductionView>) p_list).ExecuteToReturnAsync<UbRes<IList<SupplierAutoDeductionView>>>((UniBizHttpClient) __nonvirtual (payContionMpartVm.App).Api)).GetSuccess<UbRes<IList<SupplierAutoDeductionView>>>();
          payContionMpartVm.SearchAutoDeductionAsync(payContionMpartVm.SupplierHistory.suh_ID);
        }
      }
      catch (Exception ex)
      {
        Log.Error(ex.Message);
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (payContionMpartVm.Container)).Set(__nonvirtual (payContionMpartVm.MenuInfo).Title + " 오류", ex.Message).ShowDialog();
      }
    }

    public void OnWinClose()
    {
      if (new CommonMsgVM(this.Container).SetDefault(MsgBoxLevel.Info, "창 닫기", this.MenuInfo.Title + " 창 을(를) 종료 할까요?", MsgBoxButton.Confirm, MsgBoxButton.Confirm, MsgBoxButton.Cancel).ShowDialog() != MsgBoxButton.Confirm)
        return;
      this.PartContainerT.WinClose();
    }

    public bool CanIsPaymentInput() => this.App.User.User.Source.IsPaymentInput;

    public WpfCommand CmdAddSupplierHistory => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        IsAutoRefresh = true,
        CanExecuteFunc = (Func<object, bool>) (_ => this.CanIsPaymentInput()),
        ExecuteAction = (Action<object>) (_ => this.AddSupplierHistory())
      };
    }), nameof (CmdAddSupplierHistory));

    public void AddSupplierHistory()
    {
      foreach (UbModelBase ubModelBase in this.Details.Select<ObservableDataSet<SupplierHistoryView>, SupplierHistoryView>((Func<ObservableDataSet<SupplierHistoryView>, SupplierHistoryView>) (it => it.OriginT)))
      {
        if (ubModelBase.IsNew)
        {
          int num = (int) new CommonMsgVM(this.Container).Set(this.MenuInfo.Title, "결제 조건 저장후 추가 가능").ShowDialog();
          return;
        }
      }
      PayContionView payContionView1 = this.PayContionList.FirstOrDefault<PayContionView>();
      SupplierHistoryView data1 = new SupplierHistoryView();
      data1.row_number = 0;
      data1.DB_STATUS = EnumDBStatus.NEW;
      data1.suh_Supplier = this.WorkDataT.CurrentT.su_Supplier;
      data1.suh_StoreCode = this.StoreCode;
      data1.suh_StartDate = new DateTime?(DateTime.Now);
      data1.suh_EndDate = new DateTime?(new DateTime(2999, 12, 31));
      data1.suh_PayCondition = payContionView1.payc_ID;
      PayContionView payContionView2 = new PayContionView();
      payContionView2.payc_ID = payContionView1.payc_ID;
      payContionView2.payc_Turn = payContionView1.payc_Turn;
      payContionView2.payc_Round = payContionView1.payc_Round;
      payContionView2.payc_PaymentDay = payContionView1.payc_PaymentDay;
      payContionView2.payc_Memo = payContionView1.payc_Memo;
      data1.PayContion = payContionView2;
      ObservableDataSet<SupplierHistoryView> data = new ObservableDataSet<SupplierHistoryView>(data1);
      this.Details.Insert(0, data);
      ((DispatcherObject) this.View).Dispatcher.InvokeAsync((Action) (() => this.DataView.Target.EditTarget((object) data, (string) null)), (DispatcherPriority) 4);
    }

    public WpfCommand CmdClearSupplierHistory => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        IsAutoRefresh = true,
        CanExecuteFunc = (Func<object, bool>) (_ => this.CanIsPaymentInput()),
        ExecuteAction = (Action<object>) (_ => this.SearchnAsync(this.WorkDataT.CurrentT.su_Supplier))
      };
    }), nameof (CmdClearSupplierHistory));

    public WpfCommand CmdAddDeduction => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        IsAutoRefresh = true,
        CanExecuteFunc = (Func<object, bool>) (_ => this.CanIsPaymentInput()),
        ExecuteAction = (Action<object>) (_ => this.AddDeduction())
      };
    }), nameof (CmdAddDeduction));

    public void AddDeduction()
    {
      if (this.SupplierHistory == null || this.SupplierHistory.suh_ID == 0)
      {
        int num = (int) new CommonMsgVM(this.Container).Set(this.MenuInfo.Title, "결제 이력 데이타 선택 후 공제 추가 가능.").ShowDialog();
      }
      else
      {
        List<SupplierAutoDeductionView> p_list = new List<SupplierAutoDeductionView>();
        foreach (CommonCodeView deductionAutoTypeData in (Collection<CommonCodeView>) this.DeductionAutoTypeDatas)
        {
          CommonCodeView item = deductionAutoTypeData;
          if (item.RowCheckStatus.IsChecked && this.AutoDeductionDetails.Where<ObservableDataSet<SupplierAutoDeductionView>>((Func<ObservableDataSet<SupplierAutoDeductionView>, bool>) (it => it.OriginT.suad_Seq == item.comm_TypeNo)).ToList<ObservableDataSet<SupplierAutoDeductionView>>().Count == 0)
          {
            SupplierAutoDeductionView autoDeductionView1 = new SupplierAutoDeductionView();
            autoDeductionView1.suad_SupplierHistory = this.SupplierHistory.suh_ID;
            autoDeductionView1.suad_Seq = item.comm_TypeNo;
            SupplierAutoDeductionView autoDeductionView2 = autoDeductionView1;
            p_list.Add(autoDeductionView2);
          }
        }
        int count = p_list.Count;
        if (p_list.Count <= 0)
          return;
        this.PostAutoDeductionAsync(p_list);
      }
    }

    public WpfCommand CmdDeleteDeduction => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        IsAutoRefresh = true,
        CanExecuteFunc = (Func<object, bool>) (_ => this.CanIsPaymentInput()),
        ExecuteAction = (Action<object>) (_ => this.DeleteDeduction())
      };
    }), nameof (CmdDeleteDeduction));

    public void DeleteDeduction()
    {
      List<SupplierAutoDeductionView> p_list = new List<SupplierAutoDeductionView>();
      foreach (SupplierAutoDeductionView autoDeductionView in this.AutoDeductionDetails.Where<ObservableDataSet<SupplierAutoDeductionView>>((Func<ObservableDataSet<SupplierAutoDeductionView>, bool>) (it => it.IsChecked)).Select<ObservableDataSet<SupplierAutoDeductionView>, SupplierAutoDeductionView>((Func<ObservableDataSet<SupplierAutoDeductionView>, SupplierAutoDeductionView>) (it => it.OriginT)))
        p_list.Add(autoDeductionView);
      int count = p_list.Count;
      if (p_list.Count <= 0)
        return;
      this.DeleteAutoDeductionAsync(p_list);
    }

    public WpfCommand CmdSaveDeduction => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        IsAutoRefresh = true,
        CanExecuteFunc = (Func<object, bool>) (_ => this.CanIsPaymentInput()),
        ExecuteAction = (Action<object>) (_ => this.SaveDeduction())
      };
    }), nameof (CmdSaveDeduction));

    public void SaveDeduction()
    {
      if (this.SupplierHistory == null)
        return;
      DateTime? suhStartDate = this.SupplierHistory.suh_StartDate;
      DateTime toDay = this.ToDay;
      if ((suhStartDate.HasValue ? (suhStartDate.GetValueOrDefault() < toDay ? 1 : 0) : 0) != 0)
      {
        if (this.IsAdmin)
        {
          if (new CommonMsgVM(this.Container).SetDefault(MsgBoxLevel.Info, "이전 일자 데이타 변경", "이전일자 변경후 결제 정보 재작업이 필요합니다. \n\t데이타를 저장 할까요?", MsgBoxButton.Confirm, MsgBoxButton.Confirm, MsgBoxButton.Cancel).ShowDialog() != MsgBoxButton.Confirm)
            return;
        }
        else
        {
          int num = (int) new CommonMsgVM(this.Container).Set(this.MenuInfo.Title, "이전 일자 데이타 변경 불가.").ShowDialog();
          return;
        }
      }
      List<SupplierAutoDeductionView> p_list = new List<SupplierAutoDeductionView>();
      foreach (SupplierAutoDeductionView autoDeductionView in this.AutoDeductionDetails.Select<ObservableDataSet<SupplierAutoDeductionView>, SupplierAutoDeductionView>((Func<ObservableDataSet<SupplierAutoDeductionView>, SupplierAutoDeductionView>) (it => it.OriginT)).Where<SupplierAutoDeductionView>((Func<SupplierAutoDeductionView, bool>) (it => it.IsNew || it.IsUpdate)))
        p_list.Add(autoDeductionView);
      if (p_list.Count > 0)
      {
        this.PostAutoDeductionAsync(p_list);
      }
      else
      {
        int num1 = (int) new CommonMsgVM(this.Container).Set(this.MenuInfo.Title, "변경할 데이타가 없습니다.").ShowDialog();
      }
    }

    public void BtnClickHistoryRow(object p_object)
    {
      if (p_object is ContentPresenter contentPresenter)
      {
        if (contentPresenter.DataContext is ObservableDataSet<SupplierHistoryView> dataContext)
        {
          if (dataContext.OriginT.IsNew)
          {
            this.DoSupplierHistoryPostAsync(dataContext.OriginT);
          }
          else
          {
            this.SupplierHistory = dataContext.OriginT;
            this.SearchAutoDeductionAsync(dataContext.OriginT.suh_ID);
          }
        }
        else
          Log.Debug(" error !!!!");
      }
      else
        Log.Debug(" error !!!!");
    }

    public Action<UniDataEditArgs> EditingAct => new Action<UniDataEditArgs>(this.DetailesEditing);

    protected void DetailesEditing(UniDataEditArgs arg)
    {
      if (this.View == null)
        return;
      ObservableDataSet<SupplierHistoryView> item = arg.Item as ObservableDataSet<SupplierHistoryView>;
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
            this.DoGridHistoryNextWork(arg, item);
            return;
          }
        }
      }
      if (arg.Target != UniDataEditTarget.PropertyInItem || arg.Act != UniDataEditAction.Commit)
        return;
      item.IsTag = true;
      item.IsWorking = true;
      Func<PagePayContionMPartVM.SupplierHistoryDoGridNextArgs> func;
      ((DispatcherObject) this.View).Dispatcher.InvokeAsync<Task>((Func<Task>) (async () =>
      {
        PagePayContionMPartVM.SupplierHistoryDoGridNextArgs historyDoGridNextArgs = await Task.Factory.StartNew<PagePayContionMPartVM.SupplierHistoryDoGridNextArgs>(func ?? (func = (Func<PagePayContionMPartVM.SupplierHistoryDoGridNextArgs>) (() =>
        {
          if (!arg.IsChangedEditingValue)
            return arg.IsPressedEnter && this.IsEnterNext || arg.IsPressedTab ? new PagePayContionMPartVM.SupplierHistoryDoGridNextArgs(arg, item) : (PagePayContionMPartVM.SupplierHistoryDoGridNextArgs) null;
          bool flag3 = false;
          bool flag4;
          switch (arg.Key)
          {
            case "suh_StartDate":
              flag4 = item.OriginT.suh_StartDate.GetDateToStr("yyyy-MM-dd").IsEqual(new DateTime?((DateTime) arg.EditingValue).GetDateToStr("yyyy-MM-dd"));
              break;
            case "suh_EndDate":
              flag4 = item.OriginT.suh_EndDate.GetDateToStr("yyyy-MM-dd").IsEqual(new DateTime?((DateTime) arg.EditingValue).GetDateToStr("yyyy-MM-dd"));
              break;
            case "suh_PayCondition":
              flag4 = item.OriginT.suh_PayCondition.IsEqual(Convert.ToInt32(arg.EditingValue));
              break;
            case "suh_PayMethod":
              flag4 = item.OriginT.suh_PayMethod.IsEqual(Convert.ToInt32(arg.EditingValue));
              break;
            default:
              flag4 = flag3;
              break;
          }
          if (flag4)
            return new PagePayContionMPartVM.SupplierHistoryDoGridNextArgs(arg, item);
          SupplierHistoryView data = (SupplierHistoryView) null;
          string title = string.Format("[{0}] 변경 중...", (object) this.SupplierHistoryHeader[arg.Key.ToString()]);
          try
          {
            using (this.Job.CreateJob(title, (string) null))
            {
              switch (arg.Key)
              {
                case "suh_StartDate":
                  DateTime? nullable5 = new DateTime?((DateTime) arg.EditingValue);
                  if (nullable5.Value < this.ToDay)
                  {
                    Log.Debug("-- OKKK --");
                    if (!this.IsAdmin)
                      return new PagePayContionMPartVM.SupplierHistoryDoGridNextArgs(arg, item, EnumUniUserException.Stop, "시작 일자 등록 실패", "오늘 이전 일자 등록 불가 합니다.");
                    // ISSUE: explicit non-virtual call
                    if (((DispatcherObject) this.View)?.Dispatcher.Invoke<bool>((Func<bool>) (() => new CommonMsgVM(__nonvirtual (this.Container)).SetDefault(MsgBoxLevel.Info, "이전 일자 데이타 변경", "이전일자 변경후 결제 정보 재작업이 필요합니다. \n\t데이타를 변경 할까요?", MsgBoxButton.Confirm, MsgBoxButton.Confirm, MsgBoxButton.Cancel).ShowDialog() != MsgBoxButton.Confirm)).GetValueOrDefault())
                      return new PagePayContionMPartVM.SupplierHistoryDoGridNextArgs(arg, item, EnumUniUserException.Stop, "시작 일자 등록 실패", "오늘 이전 일자 등록 불가 합니다.");
                  }
                  data = item.OriginT.CloneByJson<SupplierHistoryView>();
                  if (!nullable5.HasValue)
                    return new PagePayContionMPartVM.SupplierHistoryDoGridNextArgs(arg, item, EnumUniUserException.Stop, "시작 일자 등록 실패", "시작일자를 정확히 등록하여 주세요.");
                  DateTime? nullable6 = nullable5;
                  DateTime? suhEndDate = data.suh_EndDate;
                  if ((nullable6.HasValue & suhEndDate.HasValue ? (nullable6.GetValueOrDefault() > suhEndDate.GetValueOrDefault() ? 1 : 0) : 0) != 0)
                    return new PagePayContionMPartVM.SupplierHistoryDoGridNextArgs(arg, item, EnumUniUserException.Stop, "시작 일자 등록 실패", "시작일자가 종료일자 이후 입니다.");
                  data.suh_StartDate = nullable5;
                  item.IsTag = false;
                  break;
                case "suh_EndDate":
                  DateTime? nullable7 = new DateTime?((DateTime) arg.EditingValue);
                  if (nullable7.Value < this.ToDay)
                  {
                    if (!this.IsAdmin)
                      return new PagePayContionMPartVM.SupplierHistoryDoGridNextArgs(arg, item, EnumUniUserException.Stop, "종료 일자 등록 실패", "오늘 이전 일자 등록 불가 합니다.");
                    // ISSUE: explicit non-virtual call
                    if (((DispatcherObject) this.View)?.Dispatcher.Invoke<bool>((Func<bool>) (() => new CommonMsgVM(__nonvirtual (this.Container)).SetDefault(MsgBoxLevel.Info, "이전 일자 데이타 변경", "이전일자 변경후 결제 정보 재작업이 필요합니다. \n\t데이타를 변경 할까요?", MsgBoxButton.Confirm, MsgBoxButton.Confirm, MsgBoxButton.Cancel).ShowDialog() != MsgBoxButton.Confirm)).GetValueOrDefault())
                      return new PagePayContionMPartVM.SupplierHistoryDoGridNextArgs(arg, item, EnumUniUserException.Stop, "종료 일자 등록 실패", "오늘 이전 일자 등록 불가 합니다.");
                  }
                  data = item.OriginT.CloneByJson<SupplierHistoryView>();
                  if (!nullable7.HasValue)
                    return new PagePayContionMPartVM.SupplierHistoryDoGridNextArgs(arg, item, EnumUniUserException.Stop, "종료 일자 등록 실패", "종료일자를 정확히 등록하여 주세요.");
                  DateTime? suhStartDate = data.suh_StartDate;
                  DateTime? nullable8 = nullable7;
                  if ((suhStartDate.HasValue & nullable8.HasValue ? (suhStartDate.GetValueOrDefault() > nullable8.GetValueOrDefault() ? 1 : 0) : 0) != 0)
                    return new PagePayContionMPartVM.SupplierHistoryDoGridNextArgs(arg, item, EnumUniUserException.Stop, "종료 일자 등록 실패", "종료일자가 시작일자 이전 입니다.");
                  data.suh_EndDate = nullable7;
                  item.IsTag = false;
                  break;
                case "suh_PayCondition":
                  data = item.OriginT.CloneByJson<SupplierHistoryView>();
                  data.suh_PayCondition = (int) arg.EditingValue;
                  PayContionView payContionView = this.PayContionList.Where<PayContionView>((Func<PayContionView, bool>) (it => it.payc_ID == data.suh_PayCondition)).FirstOrDefault<PayContionView>();
                  if (payContionView == null)
                    return new PagePayContionMPartVM.SupplierHistoryDoGridNextArgs(arg, item, EnumUniUserException.Stop, "등록 실패", "결제조건을 입니다.");
                  data.PayContion.payc_ID = payContionView.payc_ID;
                  data.PayContion.payc_Turn = payContionView.payc_Turn;
                  data.PayContion.payc_Round = payContionView.payc_Round;
                  data.PayContion.payc_PaymentDay = payContionView.payc_PaymentDay;
                  data.PayContion.payc_Memo = payContionView.payc_Memo;
                  item.IsTag = false;
                  break;
                case "suh_PayMethod":
                  data = item.OriginT.CloneByJson<SupplierHistoryView>();
                  data.suh_PayMethod = (int) arg.EditingValue;
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
            data = (SupplierHistoryView) null;
            item.IsTag = true;
          }
          if (item.IsTag)
            return new PagePayContionMPartVM.SupplierHistoryDoGridNextArgs(arg, item, EnumUniUserException.Stop);
          if (data != null)
          {
            if (!data.IsNew)
              data.db_status = 2;
            item.Set(data);
            this.DataView.Target.NotifyItemsChanged();
          }
          return new PagePayContionMPartVM.SupplierHistoryDoGridNextArgs(arg, item);
        })));
        item.IsWorking = false;
        if (!(historyDoGridNextArgs != (PagePayContionMPartVM.SupplierHistoryDoGridNextArgs) null))
          return;
        this.DoGridHistoryNextWork(historyDoGridNextArgs);
      }), (DispatcherPriority) 4);
    }

    protected void DoGridHistoryNextWork(
      PagePayContionMPartVM.SupplierHistoryDoGridNextArgs arg)
    {
      UniDataEditArgs dataEditArg = arg.DataEditArg;
      ObservableDataSet<SupplierHistoryView> observableDataSet1 = arg.Item;
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
          this.DataView.Target.EditTarget((object) observableDataSet1, "suad_StdPriceType");
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
          ObservableDataSet<SupplierHistoryView> observableDataSet2 = observableDataSet1;
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

    protected void DoGridHistoryNextWork(
      UniDataEditArgs arg,
      ObservableDataSet<SupplierHistoryView> item,
      EnumUniUserException work = EnumUniUserException.Next,
      string messageTitle = "",
      string message = "")
    {
      this.DoGridHistoryNextWork(new PagePayContionMPartVM.SupplierHistoryDoGridNextArgs()
      {
        DataEditArg = arg,
        Item = item,
        Work = work,
        MessageTitle = messageTitle,
        Message = message
      });
    }

    public Action<UniDataEditArgs> EditingActAutoDeduction => new Action<UniDataEditArgs>(this.DetailesEditingAutoDeduction);

    protected void DetailesEditingAutoDeduction(UniDataEditArgs arg)
    {
      if (this.View == null)
        return;
      ObservableDataSet<SupplierAutoDeductionView> item = arg.Item as ObservableDataSet<SupplierAutoDeductionView>;
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
          DateTime? suhStartDate = this.SupplierHistory.suh_StartDate;
          DateTime toDay = this.ToDay;
          if ((suhStartDate.HasValue ? (suhStartDate.GetValueOrDefault() < toDay ? 1 : 0) : 0) != 0 && !this.IsAdmin)
          {
            arg.CancelAct = true;
            ((DispatcherObject) this.View)?.Dispatcher.InvokeAsync((Action) (() => this.DoGridAutoDeductionNextWork(arg, item)), (DispatcherPriority) 4);
            return;
          }
        }
      }
      if (arg.Target != UniDataEditTarget.PropertyInItem || arg.Act != UniDataEditAction.Commit)
        return;
      item.IsTag = true;
      item.IsWorking = true;
      Func<PagePayContionMPartVM.SupplierAutoDeductionDoGridNextArgs> func;
      ((DispatcherObject) this.View).Dispatcher.InvokeAsync<Task>((Func<Task>) (async () =>
      {
        PagePayContionMPartVM.SupplierAutoDeductionDoGridNextArgs deductionDoGridNextArgs = await Task.Factory.StartNew<PagePayContionMPartVM.SupplierAutoDeductionDoGridNextArgs>(func ?? (func = (Func<PagePayContionMPartVM.SupplierAutoDeductionDoGridNextArgs>) (() =>
        {
          if (!arg.IsChangedEditingValue)
            return arg.IsPressedEnter && this.IsEnterNext || arg.IsPressedTab ? new PagePayContionMPartVM.SupplierAutoDeductionDoGridNextArgs(arg, item) : (PagePayContionMPartVM.SupplierAutoDeductionDoGridNextArgs) null;
          bool flag3 = false;
          bool flag4;
          switch (arg.Key)
          {
            case "suad_StdPriceType":
              flag4 = item.OriginT.suad_StdPriceType.IsEqual(Convert.ToInt32(arg.EditingValue));
              break;
            case "suad_StdValue":
              flag4 = item.OriginT.suad_StdValue.IsEqual(Convert.ToDouble(arg.EditingValue));
              break;
            case "suad_CalcType":
              flag4 = item.OriginT.suad_CalcType.IsEqual(Convert.ToInt32(arg.EditingValue));
              break;
            case "suad_Value":
              flag4 = item.OriginT.suad_Value.IsEqual(Convert.ToDouble(arg.EditingValue));
              break;
            default:
              flag4 = flag3;
              break;
          }
          if (flag4)
            return new PagePayContionMPartVM.SupplierAutoDeductionDoGridNextArgs(arg, item);
          SupplierAutoDeductionView data = (SupplierAutoDeductionView) null;
          string title = string.Format("[{0}] 변경 중...", (object) this.SupplierAutoDeductionHeader[arg.Key.ToString()]);
          try
          {
            using (this.Job.CreateJob(title, (string) null))
            {
              switch (arg.Key)
              {
                case "suad_StdPriceType":
                  data = item.OriginT.CloneByJson<SupplierAutoDeductionView>();
                  data.suad_StdPriceType = (int) arg.EditingValue;
                  item.IsTag = false;
                  break;
                case "suad_StdValue":
                  data = item.OriginT.CloneByJson<SupplierAutoDeductionView>();
                  data.suad_StdValue = double.Parse(string.Format("{0:F4}", (object) Convert.ToDouble(arg.EditingValue)));
                  item.IsTag = false;
                  break;
                case "suad_CalcType":
                  data = item.OriginT.CloneByJson<SupplierAutoDeductionView>();
                  data.suad_CalcType = (int) arg.EditingValue;
                  item.IsTag = false;
                  break;
                case "suad_Value":
                  data = item.OriginT.CloneByJson<SupplierAutoDeductionView>();
                  data.suad_Value = double.Parse(string.Format("{0:F4}", (object) Convert.ToDouble(arg.EditingValue)));
                  item.IsTag = false;
                  break;
              }
            }
          }
          catch (Exception ex)
          {
            Log.Information("------------------------------------------");
            Log.Information(ex.Message);
            Log.Information("------------------------------------------");
            data = (SupplierAutoDeductionView) null;
            item.IsTag = true;
          }
          if (item.IsTag)
            return new PagePayContionMPartVM.SupplierAutoDeductionDoGridNextArgs(arg, item, EnumUniUserException.Stop);
          if (data != null)
          {
            if (!data.IsNew)
              data.db_status = 2;
            item.Set(data);
            this.AutoDeductionDataView.Target.NotifyItemsChanged();
          }
          return new PagePayContionMPartVM.SupplierAutoDeductionDoGridNextArgs(arg, item);
        })));
        item.IsWorking = false;
        if (!(deductionDoGridNextArgs != (PagePayContionMPartVM.SupplierAutoDeductionDoGridNextArgs) null))
          return;
        this.DoGridAutoDeductionNextWork(deductionDoGridNextArgs);
      }), (DispatcherPriority) 4);
    }

    protected void DoGridAutoDeductionNextWork(
      PagePayContionMPartVM.SupplierAutoDeductionDoGridNextArgs arg)
    {
      UniDataEditArgs dataEditArg = arg.DataEditArg;
      ObservableDataSet<SupplierAutoDeductionView> observableDataSet1 = arg.Item;
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
          this.AutoDeductionDataView.Target.EditTarget((object) observableDataSet1, "suad_StdPriceType");
          break;
        case EnumUniUserException.Stop:
          observableDataSet1.RollBack();
          if (message.Length > 0)
          {
            int num2 = (int) new CommonMsgVM(this.Container).Set(messageTitle, message).ShowDialog();
          }
          this.AutoDeductionDataView.Target.EditTarget((object) observableDataSet1, dataEditArg.Key);
          break;
        case EnumUniUserException.Next:
          ObservableDataSet<SupplierAutoDeductionView> observableDataSet2 = observableDataSet1;
          string key = dataEditArg.Key;
          int moveCount = 1;
          if (dataEditArg.EditablePropertiesCount == dataEditArg.EditablePropertyIndex + 1)
          {
            observableDataSet2 = this.AutoDeductionDetails[this.AutoDeductionDetails.IndexOf(observableDataSet1) + 1];
            key = (string) null;
            moveCount = 0;
          }
          this.AutoDeductionDataView.Target.EditTarget((object) observableDataSet2, key, moveCount);
          break;
      }
    }

    protected void DoGridAutoDeductionNextWork(
      UniDataEditArgs arg,
      ObservableDataSet<SupplierAutoDeductionView> item,
      EnumUniUserException work = EnumUniUserException.Next,
      string messageTitle = "",
      string message = "")
    {
      this.DoGridAutoDeductionNextWork(new PagePayContionMPartVM.SupplierAutoDeductionDoGridNextArgs()
      {
        DataEditArg = arg,
        Item = item,
        Work = work,
        MessageTitle = messageTitle,
        Message = message
      });
    }

    public record SupplierHistoryDoGridNextArgs()
    {
      public SupplierHistoryDoGridNextArgs(
        UniDataEditArgs arg,
        ObservableDataSet<SupplierHistoryView> item,
        EnumUniUserException work = EnumUniUserException.Next,
        string messageTitle = "",
        string message = "")
      {
        UniDataEditArgs uniDataEditArgs1 = arg;
        ObservableDataSet<SupplierHistoryView> observableDataSet1 = item;
        EnumUniUserException uniUserException1 = work;
        string str1 = messageTitle;
        string str2 = message;
        UniDataEditArgs uniDataEditArgs2;
        this.DataEditArg = uniDataEditArgs2 = uniDataEditArgs1;
        ObservableDataSet<SupplierHistoryView> observableDataSet2;
        this.Item = observableDataSet2 = observableDataSet1;
        EnumUniUserException uniUserException2;
        this.Work = uniUserException2 = uniUserException1;
        this.Message = (this.MessageTitle = str1) = str2;
      }

      public UniDataEditArgs DataEditArg { get; set; }

      public ObservableDataSet<SupplierHistoryView> Item { get; set; }

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

      public override int GetHashCode() => ((((EqualityComparer<Type>.Default.GetHashCode(this.EqualityContract) * -1521134295 + EqualityComparer<UniDataEditArgs>.Default.GetHashCode(this.\u003CDataEditArg\u003Ek__BackingField)) * -1521134295 + EqualityComparer<ObservableDataSet<SupplierHistoryView>>.Default.GetHashCode(this.\u003CItem\u003Ek__BackingField)) * -1521134295 + EqualityComparer<EnumUniUserException>.Default.GetHashCode(this.\u003CWork\u003Ek__BackingField)) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(this.\u003CMessageTitle\u003Ek__BackingField)) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(this.\u003CMessage\u003Ek__BackingField);

      public virtual bool Equals(
        PagePayContionMPartVM.SupplierHistoryDoGridNextArgs? other)
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
        return (object) other != null && this.EqualityContract == other.EqualityContract && EqualityComparer<UniDataEditArgs>.Default.Equals(this.\u003CDataEditArg\u003Ek__BackingField, other.\u003CDataEditArg\u003Ek__BackingField) && EqualityComparer<ObservableDataSet<SupplierHistoryView>>.Default.Equals(this.\u003CItem\u003Ek__BackingField, other.\u003CItem\u003Ek__BackingField) && EqualityComparer<EnumUniUserException>.Default.Equals(this.\u003CWork\u003Ek__BackingField, other.\u003CWork\u003Ek__BackingField) && EqualityComparer<string>.Default.Equals(this.\u003CMessageTitle\u003Ek__BackingField, other.\u003CMessageTitle\u003Ek__BackingField) && EqualityComparer<string>.Default.Equals(this.\u003CMessage\u003Ek__BackingField, other.\u003CMessage\u003Ek__BackingField);
      }

      protected SupplierHistoryDoGridNextArgs(
        PagePayContionMPartVM.SupplierHistoryDoGridNextArgs original)
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

    public record SupplierAutoDeductionDoGridNextArgs()
    {
      public SupplierAutoDeductionDoGridNextArgs(

        #nullable disable
        UniDataEditArgs arg,
        ObservableDataSet<SupplierAutoDeductionView> item,
        EnumUniUserException work = EnumUniUserException.Next,
        string messageTitle = "",
        string message = "")
      {
        UniDataEditArgs uniDataEditArgs1 = arg;
        ObservableDataSet<SupplierAutoDeductionView> observableDataSet1 = item;
        EnumUniUserException uniUserException1 = work;
        string str1 = messageTitle;
        string str2 = message;
        UniDataEditArgs uniDataEditArgs2;
        this.DataEditArg = uniDataEditArgs2 = uniDataEditArgs1;
        ObservableDataSet<SupplierAutoDeductionView> observableDataSet2;
        this.Item = observableDataSet2 = observableDataSet1;
        EnumUniUserException uniUserException2;
        this.Work = uniUserException2 = uniUserException1;
        this.Message = (this.MessageTitle = str1) = str2;
      }

      public UniDataEditArgs DataEditArg { get; set; }

      public ObservableDataSet<SupplierAutoDeductionView> Item { get; set; }

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

      public override int GetHashCode() => ((((EqualityComparer<Type>.Default.GetHashCode(this.EqualityContract) * -1521134295 + EqualityComparer<UniDataEditArgs>.Default.GetHashCode(this.\u003CDataEditArg\u003Ek__BackingField)) * -1521134295 + EqualityComparer<ObservableDataSet<SupplierAutoDeductionView>>.Default.GetHashCode(this.\u003CItem\u003Ek__BackingField)) * -1521134295 + EqualityComparer<EnumUniUserException>.Default.GetHashCode(this.\u003CWork\u003Ek__BackingField)) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(this.\u003CMessageTitle\u003Ek__BackingField)) * -1521134295 + EqualityComparer<string>.Default.GetHashCode(this.\u003CMessage\u003Ek__BackingField);

      public virtual bool Equals(
        PagePayContionMPartVM.SupplierAutoDeductionDoGridNextArgs? other)
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
        return (object) other != null && this.EqualityContract == other.EqualityContract && EqualityComparer<UniDataEditArgs>.Default.Equals(this.\u003CDataEditArg\u003Ek__BackingField, other.\u003CDataEditArg\u003Ek__BackingField) && EqualityComparer<ObservableDataSet<SupplierAutoDeductionView>>.Default.Equals(this.\u003CItem\u003Ek__BackingField, other.\u003CItem\u003Ek__BackingField) && EqualityComparer<EnumUniUserException>.Default.Equals(this.\u003CWork\u003Ek__BackingField, other.\u003CWork\u003Ek__BackingField) && EqualityComparer<string>.Default.Equals(this.\u003CMessageTitle\u003Ek__BackingField, other.\u003CMessageTitle\u003Ek__BackingField) && EqualityComparer<string>.Default.Equals(this.\u003CMessage\u003Ek__BackingField, other.\u003CMessage\u003Ek__BackingField);
      }

      protected SupplierAutoDeductionDoGridNextArgs(
        PagePayContionMPartVM.SupplierAutoDeductionDoGridNextArgs original)
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
