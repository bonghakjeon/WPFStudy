// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Board.Sys.DataGridExportSysBoardVM
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Microsoft.AppCenter;
using Microsoft.Win32;
using StyletIoC;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Threading;
using UniBiz.Bo.Models.UbRest;
using UniBiz.Bo.Models.UniBase.Employee;
using UniBiz.Bo.Models.UniBase.Employee.EmpActionLog;
using UniBizBO.Document;
using UniBizBO.Services;
using UniBizBO.Services.Board;
using UniBizBO.ViewModels.Box;
using UniinfoNet.Extensions;
using UniinfoNet.Http.UniBiz;
using UniinfoNet.Windows.Wpf;
using UniinfoNet.Windows.Wpf.Commands;
using UniinfoNet.Windows.Wpf.Job;
using UniinfoNet.Xl;


#nullable enable
namespace UniBizBO.ViewModels.Board.Sys
{
  public class DataGridExportSysBoardVM : BoardBase, IAsyncDisposable
  {
    private XlsxExportOptions xlsxOption;
    private bool useCsvColumnOutput;
    private bool isOpenFolderAfterExport;
    private bool isOpenFileAfterExport;
    private 
    #nullable disable
    string outputTitle;
    private string outputDescription;
    private EmpActionLogView _ActionLog;

    [ManagedStatus("c367894b-2ea0-4e70-a59e-87f328bfb5ea")]
    public XlsxExportOptions XlsxOption
    {
      get => this.xlsxOption;
      set
      {
        this.xlsxOption = value;
        this.NotifyOfPropertyChange("");
      }
    }

    public bool IsIncludeColor
    {
      get => (this.XlsxOption & XlsxExportOptions.Color) != 0;
      set
      {
        int num = (int) XlsxExportOptions.Color.Action<XlsxExportOptions>((Action<XlsxExportOptions>) (f =>
        {
          if (value)
            this.XlsxOption |= f;
          else
            this.XlsxOption &= ~f;
        }));
      }
    }

    public bool IsIncludeImage
    {
      get => (this.XlsxOption & XlsxExportOptions.Image) != 0;
      set
      {
        int num = (int) XlsxExportOptions.Image.Action<XlsxExportOptions>((Action<XlsxExportOptions>) (f =>
        {
          if (value)
            this.XlsxOption |= f;
          else
            this.XlsxOption &= ~f;
        }));
      }
    }

    [ManagedStatus("729b0002-4bac-40c3-b75b-ee9093042231")]
    public bool UseCsvColumnOutput
    {
      get => this.useCsvColumnOutput;
      set => this.SetAndNotify<bool>(ref this.useCsvColumnOutput, value, nameof (UseCsvColumnOutput));
    }

    [ManagedStatus("91368ceb-d728-4885-8d54-be1b407f6a47")]
    public bool IsOpenFolderAfterExport
    {
      get => this.isOpenFolderAfterExport;
      set => this.SetAndNotify<bool>(ref this.isOpenFolderAfterExport, value, nameof (IsOpenFolderAfterExport));
    }

    [ManagedStatus("58390548-59ab-4d14-a06c-f20606920979")]
    public bool IsOpenFileAfterExport
    {
      get => this.isOpenFileAfterExport;
      set => this.SetAndNotify<bool>(ref this.isOpenFileAfterExport, value, nameof (IsOpenFileAfterExport));
    }

    public string OutputTitle
    {
      get => this.outputTitle;
      set => this.SetAndNotify<string>(ref this.outputTitle, value, nameof (OutputTitle));
    }

    public string OutputDescription
    {
      get => this.outputDescription;
      set => this.SetAndNotify<string>(ref this.outputDescription, value, nameof (OutputDescription));
    }

    public DataGridExportSysBoardVM(IContainer container)
    {
      EmpActionLogView empActionLogView = new EmpActionLogView();
      empActionLogView.eal_ActionKind = 10;
      this._ActionLog = empActionLogView;
      // ISSUE: explicit constructor call
      base.\u002Ector(container);
      this.DisplayName = "내보내기";
    }

    public DataGridExportSysBoardVM Set(
      IElementExporter exporter,
      string title = null,
      string description = null,
      int menuInfoCode = 0,
      int propInfoCode = 0,
      int applyRowCnt = 0,
      string memo = null,
      string memo2 = null)
    {
      this.Exporter = exporter;
      this._ActionLog.eal_SiteID = this.LogInPackInfo.siteID;
      this._ActionLog.eal_MenuCode = menuInfoCode;
      this._ActionLog.eal_SubProgID = propInfoCode;
      this._ActionLog.eal_EmpCode = this.App.User.User.Source.emp_Code;
      this._ActionLog.eal_ApplyRowCnt = applyRowCnt;
      this._ActionLog.eal_ProgKind = 26;
      this._ActionLog.eal_ActionKind = 10;
      if (memo != null)
        this._ActionLog.eal_Memo = memo;
      if (memo2 != null)
        this._ActionLog.eal_Memo2 = memo2;
      if (title != null && title.Length > 0)
        this.DisplayName = title + " 내보내기";
      this.OutputTitle = title;
      this.OutputDescription = description;
      return this;
    }

    public IElementExporter Exporter { get; set; }

    protected void DoAfterCompleted(string filePath)
    {
      if (string.IsNullOrWhiteSpace(filePath))
        return;
      if (this.isOpenFolderAfterExport)
        Process.Start("explorer.exe", "/select," + filePath);
      if (!this.IsOpenFileAfterExport)
        return;
      Process.Start(new ProcessStartInfo(filePath)
      {
        UseShellExecute = true
      });
    }

    public bool CanExportXlsx() => this.Exporter != null;

    public async Task ExportXlsxAsync()
    {
      DataGridExportSysBoardVM exportSysBoardVm = this;
      // ISSUE: explicit non-virtual call
      using (JobProgressState j = __nonvirtual (exportSysBoardVm.Job).CreateJob("xlsx 출력", (string) null))
      {
        SaveFileDialog fd = new SaveFileDialog();
        fd.AddExtension = true;
        fd.Filter = "Excel Worksheets|*.xlsx";
        fd.DefaultExt = ".xlsx";
        fd.CheckPathExists = true;
        fd.OverwritePrompt = true;
        if (!fd.ShowDialog().GetValueOrDefault())
        {
          fd = (SaveFileDialog) null;
        }
        else
        {
          try
          {
            j.Value = new double?(0.0);
            using (JobProgressState j1 = j.CreateJob("읽기", (string) null))
            {
              UniXlTableInfo table = await exportSysBoardVm.Exporter.ReadXlTableInfoAsync(progress: (IProgress<double>) new Progress<double>((Action<double>) (it =>
              {
                JobProgressState jobProgressState1 = j;
                JobProgressState jobProgressState2 = j1;
                double? nullable1 = new double?(it);
                double? nullable2 = nullable1;
                jobProgressState2.Value = nullable2;
                double? nullable3 = nullable1;
                double num = 2.0;
                double? nullable4 = nullable3.HasValue ? new double?(nullable3.GetValueOrDefault() / num) : new double?();
                jobProgressState1.Value = nullable4;
              })), token: j.Token);
              j1.Dispose();
              using (JobProgressState j2 = j.CreateJob("생성", (string) null))
              {
                UniXlToClosedXmlWriter toClosedXmlWriter = UniXlToWriterBase<UniXlToClosedXmlWriter>.Create(table);
                toClosedXmlWriter.XlsxTitle = exportSysBoardVm.OutputTitle;
                toClosedXmlWriter.XlsxDesciption = exportSysBoardVm.OutputDescription;
                await toClosedXmlWriter.SaveToXlsxFileAsync(fd.FileName, (IProgress<double>) new Progress<double>((Action<double>) (it =>
                {
                  JobProgressState jobProgressState3 = j;
                  JobProgressState jobProgressState4 = j2;
                  double? nullable5 = new double?(it);
                  double? nullable6 = nullable5;
                  jobProgressState4.Value = nullable6;
                  double? nullable7 = nullable5;
                  double num = 2.0;
                  double? nullable8 = nullable7.HasValue ? new double?(nullable7.GetValueOrDefault() / num + 0.5) : new double?();
                  jobProgressState3.Value = nullable8;
                })), j.Token);
                j2.Dispose();
                exportSysBoardVm.DoAfterCompleted(fd.FileName);
                if (exportSysBoardVm._ActionLog.eal_MenuCode <= 0 && exportSysBoardVm._ActionLog.eal_SubProgID <= 0)
                {
                  fd = (SaveFileDialog) null;
                }
                else
                {
                  UniBizHttpRequest<UbRes<EmpActionLogView>> req = EmployeeRestServer.PostEmpActionLog(exportSysBoardVm.LogInPackInfo.sendType, exportSysBoardVm.LogInPackInfo.siteID, 0L, 0, 0, exportSysBoardVm._ActionLog);
                  // ISSUE: explicit non-virtual call
                  UbRes<EmpActionLogView> returnAsync = await (req != null ? req.ExecuteToReturnAsync<UbRes<EmpActionLogView>>((UniBizHttpClient) __nonvirtual (exportSysBoardVm.App).Api) : (Task<UbRes<EmpActionLogView>>) null);
                  fd = (SaveFileDialog) null;
                }
              }
            }
          }
          catch (CancellationException ex)
          {
            // ISSUE: explicit non-virtual call
            int num = (int) __nonvirtual (exportSysBoardVm.Container).Get<CommonMsgVM>().Set("xlsx 출력", "작업을 취소했습니다.").ShowDialog();
            fd = (SaveFileDialog) null;
          }
        }
      }
    }

    public bool CanExportCsv() => this.Exporter != null;

    public async Task ExportCsvAsync()
    {
      DataGridExportSysBoardVM exportSysBoardVm = this;
      // ISSUE: explicit non-virtual call
      using (JobProgressState j = __nonvirtual (exportSysBoardVm.Job).CreateJob("csv 출력", (string) null))
      {
        SaveFileDialog fd = new SaveFileDialog();
        fd.AddExtension = true;
        fd.Filter = "Csv|*.csv";
        fd.DefaultExt = ".csv";
        fd.CheckPathExists = true;
        fd.OverwritePrompt = true;
        if (!fd.ShowDialog().GetValueOrDefault())
        {
          fd = (SaveFileDialog) null;
        }
        else
        {
          try
          {
            j.Value = new double?(0.0);
            using (JobProgressState j1 = j.CreateJob("읽기", (string) null))
            {
              UniXlTableInfo table = await exportSysBoardVm.Exporter.ReadXlTableInfoAsync(progress: (IProgress<double>) new Progress<double>((Action<double>) (it =>
              {
                JobProgressState jobProgressState1 = j;
                JobProgressState jobProgressState2 = j1;
                double? nullable1 = new double?(it);
                double? nullable2 = nullable1;
                jobProgressState2.Value = nullable2;
                double? nullable3 = nullable1;
                double num = 2.0;
                double? nullable4 = nullable3.HasValue ? new double?(nullable3.GetValueOrDefault() / num) : new double?();
                jobProgressState1.Value = nullable4;
              })), token: j.Token);
              j1.Dispose();
              using (JobProgressState j2 = j.CreateJob("생성", (string) null))
              {
                UniXlToCsvWriter uniXlToCsvWriter = UniXlToWriterBase<UniXlToCsvWriter>.Create(table);
                uniXlToCsvWriter.UseColumnOutput = exportSysBoardVm.UseCsvColumnOutput;
                await uniXlToCsvWriter.SaveToCsvFileAsync(fd.FileName, (IProgress<double>) new Progress<double>((Action<double>) (it =>
                {
                  JobProgressState jobProgressState3 = j;
                  JobProgressState jobProgressState4 = j2;
                  double? nullable5 = new double?(it);
                  double? nullable6 = nullable5;
                  jobProgressState4.Value = nullable6;
                  double? nullable7 = nullable5;
                  double num = 2.0;
                  double? nullable8 = nullable7.HasValue ? new double?(nullable7.GetValueOrDefault() / num + 0.5) : new double?();
                  jobProgressState3.Value = nullable8;
                })), j.Token);
                j2.Dispose();
                exportSysBoardVm.DoAfterCompleted(fd.FileName);
                if (exportSysBoardVm._ActionLog.eal_MenuCode <= 0 && exportSysBoardVm._ActionLog.eal_SubProgID <= 0)
                {
                  fd = (SaveFileDialog) null;
                }
                else
                {
                  UniBizHttpRequest<UbRes<EmpActionLogView>> req = EmployeeRestServer.PostEmpActionLog(exportSysBoardVm.LogInPackInfo.sendType, exportSysBoardVm.LogInPackInfo.siteID, 0L, 0, 0, exportSysBoardVm._ActionLog);
                  // ISSUE: explicit non-virtual call
                  UbRes<EmpActionLogView> returnAsync = await (req != null ? req.ExecuteToReturnAsync<UbRes<EmpActionLogView>>((UniBizHttpClient) __nonvirtual (exportSysBoardVm.App).Api) : (Task<UbRes<EmpActionLogView>>) null);
                  fd = (SaveFileDialog) null;
                }
              }
            }
          }
          catch (CancellationException ex)
          {
            // ISSUE: explicit non-virtual call
            int num = (int) __nonvirtual (exportSysBoardVm.Container).Get<CommonMsgVM>().Set("xlsx 출력", "작업을 취소했습니다.").ShowDialog();
            fd = (SaveFileDialog) null;
          }
        }
      }
    }

    protected override void OnClose()
    {
      this.Job.First?.Cancel();
      base.OnClose();
    }

    public async ValueTask DisposeAsync() => await Dispatcher.Yield();

    public WpfCommand CmdExportXlsx => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        CanExecuteFunc = (Func<object, bool>) (x => this.CanExportXlsx()),
        ExecuteAction = (Action<object>) (x => await this.ExportXlsxAsync())
      };
    }), nameof (CmdExportXlsx));

    public WpfCommand CmdExportCsv => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        CanExecuteFunc = (Func<object, bool>) (x => this.CanExportCsv()),
        ExecuteAction = (Action<object>) (x => await this.ExportCsvAsync())
      };
    }), nameof (CmdExportCsv));
  }
}
