// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Board.Sys.UniDataGridPrintSysBoardVM
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using StyletIoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Threading;
using UniBiz.Bo.Models.UbRest;
using UniBiz.Bo.Models.UniBase.Employee;
using UniBiz.Bo.Models.UniBase.Employee.EmpActionLog;
using UniBizBO.Document;
using UniBizBO.Services.Board;
using UniBizBO.ViewModels.Box;
using UniinfoNet.Extensions;
using UniinfoNet.Http.UniBiz;
using UniinfoNet.Windows.Wpf.Commands;
using UniinfoNet.Windows.Wpf.Document;
using UniinfoNet.Windows.Wpf.Job;


#nullable enable
namespace UniBizBO.ViewModels.Board.Sys
{
  public class UniDataGridPrintSysBoardVM : BoardBase, IAsyncDisposable
  {
    private 
    #nullable disable
    List<PrintQueue> installedPrintQueues;
    private PrintQueue selectedPrintQueue;
    private FixedDocument document;
    private FixedPage previewPage;
    private Thickness pageMargin;
    private Size pageSize;
    private PageOrientation pageOrientation;
    private EmpActionLogView actionLog;

    public UniDataGridPrintSysBoardVM(IContainer container)
    {
      EmpActionLogView empActionLogView = new EmpActionLogView();
      empActionLogView.eal_ActionKind = 11;
      this.actionLog = empActionLogView;
      this.Timer = new DispatcherTimer((DispatcherPriority) 2)
      {
        Interval = TimeSpan.FromSeconds(1.0),
        IsEnabled = true
      };
      // ISSUE: explicit constructor call
      base.\u002Ector(container);
    }

    public List<PrintQueue> InstalledPrintQueues => this.installedPrintQueues ?? (this.installedPrintQueues = new LocalPrintServer().GetPrintQueues().ToList<PrintQueue>());

    public PrintQueue SelectedPrintQueue
    {
      get => this.selectedPrintQueue;
      set
      {
        this.selectedPrintQueue = value;
        this.ChangeFastPrintPreview();
        this.NotifyOfPropertyChange("");
      }
    }

    public FixedDocument Document
    {
      get => this.document;
      set
      {
        this.document = value;
        this.NotifyOfPropertyChange(nameof (Document));
      }
    }

    public FixedPage PreviewPage
    {
      get => this.previewPage;
      set
      {
        this.previewPage = value;
        this.NotifyOfPropertyChange(nameof (PreviewPage));
        this.NotifyOfPropertyChange("IsExistPreviewPage");
      }
    }

    public bool IsExistPreviewPage => this.PreviewPage != null;

    public TemplateFixedDocumentCreater Creater { get; set; }

    public Thickness PageMargin
    {
      get => this.pageMargin;
      set
      {
        this.pageMargin = value;
        this.ChangeFastPrintPreview();
        this.NotifyOfPropertyChange(nameof (PageMargin));
        this.NotifyOfPropertyChange("PageMarginLeft");
        this.NotifyOfPropertyChange("PageMarginTop");
        this.NotifyOfPropertyChange("PageMarginRight");
        this.NotifyOfPropertyChange("PageMarginBottom");
      }
    }

    public double PageMarginLeft
    {
      get => this.PageMargin.Left;
      set => this.PageMargin = new Thickness(value, this.PageMarginTop, this.PageMarginRight, this.PageMarginBottom);
    }

    public double PageMarginTop
    {
      get => this.PageMargin.Top;
      set => this.PageMargin = new Thickness(this.PageMarginLeft, value, this.PageMarginRight, this.PageMarginBottom);
    }

    public double PageMarginRight
    {
      get => this.PageMargin.Right;
      set => this.PageMargin = new Thickness(this.PageMarginLeft, this.PageMarginTop, value, this.PageMarginBottom);
    }

    public double PageMarginBottom
    {
      get => this.PageMargin.Bottom;
      set => this.PageMargin = new Thickness(this.PageMarginLeft, this.PageMarginTop, this.PageMarginRight, value);
    }

    public Size PageSize
    {
      get => this.pageSize;
      set
      {
        this.pageSize = value;
        this.ChangeFastPrintPreview();
        this.NotifyOfPropertyChange(nameof (PageSize));
        this.NotifyOfPropertyChange("PageSizeWidth");
        this.NotifyOfPropertyChange("PageSizeHeight");
      }
    }

    public double PageSizeWidth
    {
      get => this.PageSize.Width;
      set => this.PageSize = new Size(value, this.PageSizeHeight);
    }

    public double PageSizeHeight
    {
      get => this.PageSize.Height;
      set => this.PageSize = new Size(this.PageSizeWidth, value);
    }

    public PageOrientation PageOrientation
    {
      get => this.pageOrientation;
      set
      {
        this.pageOrientation = value;
        this.ChangeFastPrintPreview();
        this.NotifyOfPropertyChange(nameof (PageOrientation));
        this.NotifyOfPropertyChange("IsPageLandscape");
      }
    }

    public bool IsPageLandscape
    {
      get => this.PageOrientation == PageOrientation.Landscape;
      set
      {
        if (value)
          this.PageOrientation = PageOrientation.Landscape;
        else
          this.PageOrientation = PageOrientation.Portrait;
      }
    }

    public bool IsHeaderSizeFixed
    {
      get => this.Creater.Arg.IsHeaderSizeFixed;
      set
      {
        this.Creater.Arg.IsHeaderSizeFixed = value;
        this.NotifyOfPropertyChange(nameof (IsHeaderSizeFixed));
      }
    }

    public bool IsItemSizeFixed
    {
      get => this.Creater.Arg.IsItemSizeFixed;
      set
      {
        this.Creater.Arg.IsItemSizeFixed = value;
        this.NotifyOfPropertyChange(nameof (IsItemSizeFixed));
      }
    }

    public DispatcherTimer Timer { get; }

    protected async void ChangeFastPrintPreview()
    {
      this.PreviewPage = (FixedPage) null;
      this.Timer.Stop();
      this.Timer.Start();
      if (this.Document != null)
        await this.ReleaseDocumentMemoryAsync();
      if (this.SelectedPrintQueue == null)
        return;
      this.SelectedPrintQueue.CurrentJobSettings.CurrentPrintTicket.PageOrientation = new PageOrientation?(this.PageOrientation);
    }

    protected override void OnInitialActivate()
    {
      base.OnInitialActivate();
      this.Timer.Tick += new EventHandler(this.Timer_Tick);
      this.PageMargin = this.Creater.PageMarginMm;
      this.PageSize = this.Creater.OriginPageSizeMm;
      this.PageOrientation = this.Creater.Orientation;
      this.SelectedPrintQueue = this.InstalledPrintQueues.FirstOrDefault<PrintQueue>((Func<PrintQueue, bool>) (it => it.FullName.Equals(this.SelectedPrintQueue.FullName))) ?? this.InstalledPrintQueues.FirstOrDefault<PrintQueue>();
      this.SelectedPrintQueue.CurrentJobSettings.CurrentPrintTicket.PageOrientation = new PageOrientation?(this.PageOrientation);
    }

    private async void Timer_Tick(object sender, EventArgs e)
    {
      this.Timer.Stop();
      await this.FastPrintPreviewAsync();
    }

    public UniDataGridPrintSysBoardVM Set(
      TemplateFixedDocumentCreater creater,
      string memo1 = null,
      string memo2 = null,
      int pMenuInfoCode = 0,
      int pPropInfoCode = 0,
      int pApplyRowCnt = 0)
    {
      this.Creater = creater;
      this.actionLog.eal_SiteID = this.LogInPackInfo.siteID;
      this.actionLog.eal_MenuCode = pMenuInfoCode;
      this.actionLog.eal_SubProgID = pPropInfoCode;
      this.actionLog.eal_EmpCode = this.App.User.User.Source.emp_Code;
      this.actionLog.eal_ApplyRowCnt = pApplyRowCnt;
      this.actionLog.eal_ProgKind = 26;
      this.actionLog.eal_ActionKind = 11;
      if (!string.IsNullOrWhiteSpace(memo1))
        this.actionLog.eal_Memo = memo1;
      if (!string.IsNullOrWhiteSpace(memo2))
        this.actionLog.eal_Memo2 = memo2;
      return this;
    }

    private async Task PrintAsync()
    {
      UniDataGridPrintSysBoardVM gridPrintSysBoardVm = this;
      // ISSUE: explicit non-virtual call
      using (JobProgressState j1 = __nonvirtual (gridPrintSysBoardVm.Job).CreateJob("인쇄", (string) null))
      {
        await gridPrintSysBoardVm.CreateDocumentAsync(j1);
        j1.Msg = "인쇄 데이터 전송 : " + gridPrintSysBoardVm.SelectedPrintQueue.FullName;
        new PrintDialog()
        {
          PrintQueue = gridPrintSysBoardVm.SelectedPrintQueue
        }.PrintDocument(gridPrintSysBoardVm.Document.DocumentPaginator, gridPrintSysBoardVm.Creater.Arg.Title);
        j1.Msg = "로그 기록";
        await gridPrintSysBoardVm.SendActionLogAsync();
      }
    }

    private async Task PrintPreviewAsync() => await this.CreateDocumentAsync();

    private async Task FastPrintPreviewAsync()
    {
      UniDataGridPrintSysBoardVM gridPrintSysBoardVm = this;
      // ISSUE: explicit non-virtual call
      JobProgressManager job = __nonvirtual (gridPrintSysBoardVm.Job);
      gridPrintSysBoardVm.previewPage = (FixedPage) null;
      JobProgressState j2;
      FixedPage page;
      using (JobProgressState j1 = job.CreateJob("빠른 미리보기", (string) null))
      {
        gridPrintSysBoardVm.Creater.InitDocumentPrint();
        gridPrintSysBoardVm.Creater.OriginPageSizeMm = gridPrintSysBoardVm.PageSize;
        gridPrintSysBoardVm.Creater.PageMarginMm = gridPrintSysBoardVm.PageMargin;
        gridPrintSysBoardVm.Creater.Orientation = gridPrintSysBoardVm.PageOrientation;
        j2 = j1?.CreateJob("페이지 생성", (string) null);
        try
        {
          page = gridPrintSysBoardVm.Creater.CreateFixedPage();
          TemplateFixedDocumentCreater creater = gridPrintSysBoardVm.Creater;
          FixedPageDrawingArg fixedPageDrawingArg = new FixedPageDrawingArg();
          fixedPageDrawingArg.Page = page;
          fixedPageDrawingArg.Number = 1;
          JobProgressState mProgress = j1;
          JobProgressState sProgress = j2;
          CancellationToken token = new CancellationToken();
          await creater.ApplyToPageAsync(fixedPageDrawingArg, (IProgress<double>) mProgress, (IProgress<double>) sProgress, token);
          gridPrintSysBoardVm.PreviewPage = page;
          await gridPrintSysBoardVm.ReleaseDocumentMemoryAsync();
        }
        finally
        {
          j2?.Dispose();
        }
      }
      j2 = (JobProgressState) null;
      page = (FixedPage) null;
    }

    private async Task CreateDocumentAsync(JobProgressState j = null)
    {
      UniDataGridPrintSysBoardVM gridPrintSysBoardVm = this;
      // ISSUE: explicit non-virtual call
      JobProgressState j1 = j?.CreateJob((string) null, (string) null) ?? __nonvirtual (gridPrintSysBoardVm.Job).CreateJob((string) null, (string) null);
      try
      {
        j1.Title = "인쇄 데이터 생성";
        j1.CanCancel = true;
        try
        {
          if (gridPrintSysBoardVm.Document != null)
          {
            j1 = (JobProgressState) null;
            return;
          }
          await gridPrintSysBoardVm.ReleaseDocumentMemoryAsync();
          using (JobProgressState j2 = j1?.CreateJob("페이지 생성", (string) null))
          {
            gridPrintSysBoardVm.Creater.OriginPageSizeMm = gridPrintSysBoardVm.PageSize;
            gridPrintSysBoardVm.Creater.PageMarginMm = gridPrintSysBoardVm.PageMargin;
            gridPrintSysBoardVm.Creater.Orientation = gridPrintSysBoardVm.PageOrientation;
            FixedDocument fixedDocument = gridPrintSysBoardVm.Creater.CreateFixedDocument();
            gridPrintSysBoardVm.Document = fixedDocument;
            await gridPrintSysBoardVm.Creater.ApplyToDocumentAsync(fixedDocument, (IProgress<double>) j1, (IProgress<double>) j2, j1.Token);
          }
        }
        catch (OperationCanceledException ex)
        {
          // ISSUE: explicit non-virtual call
          int num = (int) __nonvirtual (gridPrintSysBoardVm.Container).Get<CommonMsgVM>().Set(j1.Title, "작업을 취소했습니다").ShowDialog();
        }
        catch (Exception ex)
        {
          // ISSUE: explicit non-virtual call
          int num = (int) __nonvirtual (gridPrintSysBoardVm.Container).Get<CommonMsgVM>().Set(j1.Title, ex.Message).ShowDialog();
        }
        gridPrintSysBoardVm.PreviewPage = (FixedPage) null;
        j1 = (JobProgressState) null;
      }
      finally
      {
        j1?.Dispose();
      }
    }

    public async Task SendActionLogAsync()
    {
      UniDataGridPrintSysBoardVM gridPrintSysBoardVm = this;
      try
      {
        if (gridPrintSysBoardVm.actionLog.eal_MenuCode <= 0 && gridPrintSysBoardVm.actionLog.eal_SubProgID <= 0)
          return;
        UniBizHttpRequest<UbRes<EmpActionLogView>> req = EmployeeRestServer.PostEmpActionLog(gridPrintSysBoardVm.LogInPackInfo.sendType, gridPrintSysBoardVm.LogInPackInfo.siteID, 0L, 0, 0, gridPrintSysBoardVm.actionLog);
        // ISSUE: explicit non-virtual call
        UbRes<EmpActionLogView> returnAsync = await (req != null ? req.ExecuteToReturnAsync<UbRes<EmpActionLogView>>((UniBizHttpClient) __nonvirtual (gridPrintSysBoardVm.App).Api) : (Task<UbRes<EmpActionLogView>>) null);
      }
      catch (Exception ex)
      {
      }
    }

    private async Task ReleaseDocumentMemoryAsync()
    {
      this.Document = (FixedDocument) null;
      await Dispatcher.Yield((DispatcherPriority) 1);
      GC.Collect();
      GC.WaitForPendingFinalizers();
      GC.Collect();
    }

    public async ValueTask DisposeAsync() => await this.ReleaseDocumentMemoryAsync();

    public override async Task<bool> CanCloseAsync()
    {
      await this.ReleaseDocumentMemoryAsync();
      return await base.CanCloseAsync();
    }

    public WpfCommand CmdPrint => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        ExecuteAction = (Action<object>) (_ => await this.PrintAsync())
      };
    }), nameof (CmdPrint));

    public WpfCommand CmdPrintPreview => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        ExecuteAction = (Action<object>) (_ => await this.PrintPreviewAsync())
      };
    }), nameof (CmdPrintPreview));

    public WpfCommand CmdFastPrintPreview => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        ExecuteAction = (Action<object>) (_ => await this.FastPrintPreviewAsync())
      };
    }), nameof (CmdFastPrintPreview));
  }
}
