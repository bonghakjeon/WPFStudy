// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Part.Main.Code.Supplier.PageSupplierMPartVM
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Microsoft.Win32;
using Models.Addr.MoisGoKr;
using Serilog;
using Stylet;
using StyletIoC;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Threading;
using UniBiz.Bo.Models.UbRest;
using UniBiz.Bo.Models.UniBase.Supplier;
using UniBiz.Bo.Models.UniBase.Supplier.Supplier;
using UniBiz.Bo.Models.UniBase.Supplier.SupplierImage;
using UniBizBO.Services;
using UniBizBO.Services.Board;
using UniBizBO.Services.Part;
using UniBizBO.ViewModels.Board.Common;
using UniBizBO.ViewModels.Box;
using UniBizBO.ViewModels.Message;
using UniBizUtil.Util;
using UniinfoNet.Extensions;
using UniinfoNet.Http.UniBiz;
using UniinfoNet.Windows.Wpf.Commands;
using UniinfoNet.Windows.Wpf.Job;


#nullable enable
namespace UniBizBO.ViewModels.Part.Main.Code.Supplier
{
  public class PageSupplierMPartVM : MPartBase<
  #nullable disable
  SupplierView>
  {
    private PageSupplierMPartVM.SearchParam param = new PageSupplierMPartVM.SearchParam();
    private bool _IsAdmin;
    private bool _IsSupplierSave;

    public PageSupplierMPartVM.SearchParam Param
    {
      get => this.param;
      set
      {
        this.param = value;
        this.NotifyOfPropertyChange(nameof (Param));
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

    public bool IsSupplierSave
    {
      get => this._IsSupplierSave;
      set
      {
        this._IsSupplierSave = value;
        this.NotifyOfPropertyChange(nameof (IsSupplierSave));
      }
    }

    public PageSupplierMPartVM(IContainer container)
      : base(container)
    {
    }

    protected override void OnInitialActivate()
    {
      base.OnInitialActivate();
      this.IsAdmin = this.App.User.User.Source.IsAdmin;
      this.IsSupplierSave = this.App.User.User.Source.IsSupplierSave;
      if (this.PartContainer.IsCreateMode)
        this.WorkDataT.CurrentT.su_MultiSuplierDiv = 1;
      if (this.WorkDataT == null || this.WorkDataT.CurrentT == null)
        return;
      SupplierImageView supplierImageView1 = this.WorkDataT.CurrentT.ImageInfo.Items.Where<SupplierImageView>((Func<SupplierImageView, bool>) (x => x.sui_Kind == 1)).FirstOrDefault<SupplierImageView>();
      SupplierImageView supplierImageView2 = this.WorkDataT.CurrentT.ImageInfo.Items.Where<SupplierImageView>((Func<SupplierImageView, bool>) (x => x.sui_Kind == 2)).FirstOrDefault<SupplierImageView>();
      SupplierImageView supplierImageView3 = this.WorkDataT.CurrentT.ImageInfo.Items.Where<SupplierImageView>((Func<SupplierImageView, bool>) (x => x.sui_Kind == 3)).FirstOrDefault<SupplierImageView>();
      if (supplierImageView1 != null)
      {
        this.Param.sui_ID_Kind_1 = supplierImageView1.sui_ID;
        this.Param.sui_ThumbImage1Url = supplierImageView1.Base64Data;
      }
      if (supplierImageView2 != null)
      {
        this.Param.sui_ID_Kind_2 = supplierImageView2.sui_ID;
        this.Param.sui_ThumbImage2Url = supplierImageView2.Base64Data;
      }
      if (supplierImageView3 == null)
        return;
      this.Param.sui_ID_Kind_3 = supplierImageView3.sui_ID;
      this.Param.sui_ThumbImage3Url = supplierImageView3.Base64Data;
    }

    protected override void OnViewLoaded() => base.OnViewLoaded();

    public override async Task OnReceiveAppWinMessageAsync(AppWinMsg p_param)
    {
      PageSupplierMPartVM pageSupplierMpartVm = this;
      // ISSUE: reference to a compiler-generated method
      await pageSupplierMpartVm.\u003C\u003En__0(p_param);
      pageSupplierMpartVm.OnAppWinMsgArgsRequested((string) null, (int) p_param.VKey, p_param.Message, p_param.WParam, p_param.LParam);
      await Task.Yield();
    }

    public void OnWinClose()
    {
      if (new CommonMsgVM(this.Container).SetDefault(MsgBoxLevel.Info, "창 닫기", this.MenuInfo.Title + " 창 을(를) 종료 할까요?", MsgBoxButton.Confirm, MsgBoxButton.Confirm, MsgBoxButton.Cancel).ShowDialog() != MsgBoxButton.Confirm)
        return;
      this.PartContainerT.WinClose();
    }

    public WpfCommand CmdSaveData => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        IsAutoRefresh = true,
        CanExecuteFunc = (Func<object, bool>) (_ => this.CanSaveData()),
        ExecuteAction = (Action<object>) (_ => this.SaveData())
      };
    }), nameof (CmdSaveData));

    public bool CanSaveData() => this.App.User.User.Source.IsSupplierSave;

    public void SaveData()
    {
      if (!this.CanSaveData())
        return;
      if (new CommonMsgVM(this.Container).SetDefault(MsgBoxLevel.Info, "데이타 저장", this.MenuInfo.Title + " 데이타를 저장 할까요?", MsgBoxButton.Confirm, MsgBoxButton.Confirm, MsgBoxButton.Cancel).ShowDialog() != MsgBoxButton.Confirm)
        return;
      this.PartContainerT?.SaveWorkDataAsync();
    }

    public void BtnSearchEmployee()
    {
    }

    public bool CanSearchZip() => true;

    public void OnSearchZip()
    {
      AddrInfoBoardVM viewModel = this.Container.Get<AddrInfoBoardVM>();
      viewModel.IsMultiSelectMode = false;
      viewModel.Confirmed += new EventHandler<CommonBoardBase<AddrInfoView>>(this.VmAddrInfoConfirmed);
      this.Container.Get<IWindowManager>().ShowDialog((object) viewModel);
    }

    private void VmAddrInfoConfirmed(object sender, CommonBoardBase<AddrInfoView> e)
    {
      if (e.SelectedData.ZipNo.Length == 0)
        return;
      this.WorkDataT.CurrentT.su_ZipCode = e.SelectedData.ZipNo;
      this.WorkDataT.CurrentT.su_Addr1 = e.SelectedData.RoadAddr;
      ((DispatcherObject) this.View).Dispatcher.InvokeAsync((Action) (() => this.OnAppWinMsgArgsRequested("su_Addr2")), (DispatcherPriority) 4);
    }

    public WpfCommand CmdSearchZip => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        IsAutoRefresh = true,
        CanExecuteFunc = (Func<object, bool>) (_ => this.CanSearchZip()),
        ExecuteAction = (Action<object>) (_ => this.OnSearchZip())
      };
    }), nameof (CmdSearchZip));

    public WpfCommand<string> CmdUploadImage => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<string>>((Func<WpfCommand<string>>) (() => new WpfCommand<string>().AutoRefreshOn<WpfCommand<string>>().ApplyCanExecute<string>(new Func<string, bool>(this.CanUploadImage)).ApplyExecute<string>(new Func<string, Task>(this.UploadImageAsync))), nameof (CmdUploadImage));

    public bool CanUploadImage(object p_object) => true;

    public async Task UploadImageAsync(object p_object)
    {
      PageSupplierMPartVM pageSupplierMpartVm = this;
      try
      {
        if (!p_object.ToString().IsNumeric())
          return;
        int sui_ID = 0;
        int sui_Kind = int.Parse(p_object.ToString());
        // ISSUE: explicit non-virtual call
        SupplierImageView supplierImageView1 = __nonvirtual (pageSupplierMpartVm.WorkDataT).CurrentT.ImageInfo.Items.Where<SupplierImageView>((Func<SupplierImageView, bool>) (x => x.sui_Kind == 1)).FirstOrDefault<SupplierImageView>();
        // ISSUE: explicit non-virtual call
        SupplierImageView supplierImageView2 = __nonvirtual (pageSupplierMpartVm.WorkDataT).CurrentT.ImageInfo.Items.Where<SupplierImageView>((Func<SupplierImageView, bool>) (x => x.sui_Kind == 2)).FirstOrDefault<SupplierImageView>();
        // ISSUE: explicit non-virtual call
        SupplierImageView supplierImageView3 = __nonvirtual (pageSupplierMpartVm.WorkDataT).CurrentT.ImageInfo.Items.Where<SupplierImageView>((Func<SupplierImageView, bool>) (x => x.sui_Kind == 3)).FirstOrDefault<SupplierImageView>();
        switch (sui_Kind)
        {
          case 1:
            if (supplierImageView1 != null)
            {
              sui_ID = supplierImageView1.sui_ID;
              break;
            }
            break;
          case 2:
            if (supplierImageView2 != null)
            {
              sui_ID = supplierImageView2.sui_ID;
              break;
            }
            break;
          case 3:
            if (supplierImageView3 != null)
            {
              sui_ID = supplierImageView3.sui_ID;
              break;
            }
            break;
          default:
            return;
        }
        UniBizHttpRequest<UbRes<SupplierImageView>> req;
        // ISSUE: explicit non-virtual call
        using (JobProgressState j = __nonvirtual (pageSupplierMpartVm.Job).CreateJob("프로필 이미지 업로드", (string) null))
        {
          OpenFileDialog openFileDialog = new OpenFileDialog();
          openFileDialog.Filter = "Image File|*.png;*.jpg;*.jpeg;*.bmp";
          bool? nullable = openFileDialog.ShowDialog();
          bool flag = true;
          if (!(nullable.GetValueOrDefault() == flag & nullable.HasValue) || !File.Exists(openFileDialog.FileName))
            return;
          FileStream dataStream = File.OpenRead(openFileDialog.FileName);
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          req = SupplierRestServer.PostEmpImageFile(pageSupplierMpartVm.LogInPackInfo.sendType, pageSupplierMpartVm.LogInPackInfo.siteID, sui_ID, __nonvirtual (pageSupplierMpartVm.WorkDataT).CurrentT.su_Supplier, sui_Kind, 0, __nonvirtual (pageSupplierMpartVm.MenuInfo).Code, openFileDialog.SafeFileName, (Stream) dataStream);
          try
          {
            // ISSUE: explicit non-virtual call
            (await req.ExecuteToReturnAsync<UbRes<SupplierImageView>>((UniBizHttpClient) __nonvirtual (pageSupplierMpartVm.App).Api, (IProgress<double>) new Progress<double>((Action<double>) (p => j.Value = new double?(p))), j.Token)).GetData<SupplierImageView>();
            switch (sui_Kind)
            {
            }
            // ISSUE: explicit non-virtual call
            __nonvirtual (pageSupplierMpartVm.Cmds).RefreshAllCanExecute();
          }
          finally
          {
            req?.Dispose();
          }
        }
        req = (UniBizHttpRequest<UbRes<SupplierImageView>>) null;
      }
      catch (Exception ex)
      {
        // ISSUE: explicit non-virtual call
        Log.Error(__nonvirtual (pageSupplierMpartVm.MenuInfo).Title + " 오류=" + ex.Message);
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (pageSupplierMpartVm.Container)).Set(__nonvirtual (pageSupplierMpartVm.MenuInfo).Title + " 오류", ex.Message).ShowDialog();
      }
    }

    public WpfCommand<object> CmdDeleteImage => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<object>>((Func<WpfCommand<object>>) (() => new WpfCommand<object>().AutoRefreshOn<WpfCommand<object>>().ApplyCanExecute<object>(new Func<object, bool>(this.CanDeleteImage)).ApplyExecute<object>(new Func<object, Task>(this.DeleteImageAsync))), nameof (CmdDeleteImage));

    public bool CanDeleteImage(object p_object)
    {
      if (this.WorkDataT == null || !p_object.ToString().IsNumeric())
        return false;
      switch (int.Parse(p_object.ToString()))
      {
        case 1:
          return this.Param.sui_ID_Kind_1 > 0;
        case 2:
          return this.Param.sui_ID_Kind_2 > 0;
        case 3:
          return this.Param.sui_ID_Kind_3 > 0;
        default:
          return false;
      }
    }

    public async Task DeleteImageAsync(object p_object)
    {
      PageSupplierMPartVM pageSupplierMpartVm = this;
      try
      {
        if (!pageSupplierMpartVm.CanDeleteImage(p_object))
          return;
        int sui_ID = 0;
        int sui_Kind = int.Parse(p_object.ToString());
        // ISSUE: explicit non-virtual call
        SupplierImageView bizImage = __nonvirtual (pageSupplierMpartVm.WorkDataT).CurrentT.ImageInfo.Items.Where<SupplierImageView>((Func<SupplierImageView, bool>) (x => x.sui_Kind == 1)).FirstOrDefault<SupplierImageView>();
        // ISSUE: explicit non-virtual call
        SupplierImageView tag1Image = __nonvirtual (pageSupplierMpartVm.WorkDataT).CurrentT.ImageInfo.Items.Where<SupplierImageView>((Func<SupplierImageView, bool>) (x => x.sui_Kind == 2)).FirstOrDefault<SupplierImageView>();
        // ISSUE: explicit non-virtual call
        SupplierImageView tag2Image = __nonvirtual (pageSupplierMpartVm.WorkDataT).CurrentT.ImageInfo.Items.Where<SupplierImageView>((Func<SupplierImageView, bool>) (x => x.sui_Kind == 3)).FirstOrDefault<SupplierImageView>();
        switch (sui_Kind)
        {
          case 1:
            if (bizImage != null)
            {
              sui_ID = bizImage.sui_ID;
              break;
            }
            break;
          case 2:
            if (tag1Image != null)
            {
              sui_ID = tag1Image.sui_ID;
              break;
            }
            break;
          case 3:
            if (tag2Image != null)
            {
              sui_ID = tag2Image.sui_ID;
              break;
            }
            break;
          default:
            return;
        }
        // ISSUE: explicit non-virtual call
        using (JobProgressState j = __nonvirtual (pageSupplierMpartVm.Job).CreateJob("이미지 삭제", (string) null))
        {
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          (await SupplierRestServer.DeleteSupplierImage(pageSupplierMpartVm.LogInPackInfo.sendType, pageSupplierMpartVm.LogInPackInfo.siteID, sui_ID, 0, __nonvirtual (pageSupplierMpartVm.MenuInfo).Code).ExecuteToReturnAsync<UbRes<SupplierImageView>>((UniBizHttpClient) __nonvirtual (pageSupplierMpartVm.App).Api, (IProgress<double>) new Progress<double>((Action<double>) (p => j.Value = new double?(p))), j.Token)).GetSuccess<UbRes<SupplierImageView>>();
          switch (sui_Kind)
          {
            case 1:
              // ISSUE: explicit non-virtual call
              __nonvirtual (pageSupplierMpartVm.WorkDataT).CurrentT.ImageInfo.Remove(bizImage);
              break;
            case 2:
              // ISSUE: explicit non-virtual call
              __nonvirtual (pageSupplierMpartVm.WorkDataT).CurrentT.ImageInfo.Remove(tag1Image);
              break;
            case 3:
              // ISSUE: explicit non-virtual call
              __nonvirtual (pageSupplierMpartVm.WorkDataT).CurrentT.ImageInfo.Remove(tag2Image);
              break;
            default:
              return;
          }
        }
        bizImage = (SupplierImageView) null;
        tag1Image = (SupplierImageView) null;
        tag2Image = (SupplierImageView) null;
      }
      catch (Exception ex)
      {
        // ISSUE: explicit non-virtual call
        Log.Error(__nonvirtual (pageSupplierMpartVm.MenuInfo).Title + " 오류=" + ex.Message);
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (pageSupplierMpartVm.Container)).Set(__nonvirtual (pageSupplierMpartVm.MenuInfo).Title + " 오류", ex.Message).ShowDialog();
      }
    }

    public WpfCommand<object> CmdDownloadImage => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<object>>((Func<WpfCommand<object>>) (() => new WpfCommand<object>().AutoRefreshOn<WpfCommand<object>>().ApplyCanExecute<object>(new Func<object, bool>(this.CanDownloadImage)).ApplyExecute<object>(new Func<object, Task>(this.DownloadImageAsync))), nameof (CmdDownloadImage));

    public bool CanDownloadImage(object p_object)
    {
      if (this.WorkDataT == null || !p_object.ToString().IsNumeric())
        return false;
      switch (int.Parse(p_object.ToString()))
      {
        case 1:
          return this.Param.sui_ID_Kind_1 > 0;
        case 2:
          return this.Param.sui_ID_Kind_2 > 0;
        case 3:
          return this.Param.sui_ID_Kind_3 > 0;
        default:
          return false;
      }
    }

    public async Task DownloadImageAsync(object p_object)
    {
      PageSupplierMPartVM pageSupplierMpartVm = this;
      try
      {
        if (!pageSupplierMpartVm.CanDownloadImage(p_object))
          return;
        int num = int.Parse(p_object.ToString());
        // ISSUE: explicit non-virtual call
        SupplierImageView supplierImageView1 = __nonvirtual (pageSupplierMpartVm.WorkDataT).CurrentT.ImageInfo.Items.Where<SupplierImageView>((Func<SupplierImageView, bool>) (x => x.sui_Kind == 1)).FirstOrDefault<SupplierImageView>();
        // ISSUE: explicit non-virtual call
        SupplierImageView supplierImageView2 = __nonvirtual (pageSupplierMpartVm.WorkDataT).CurrentT.ImageInfo.Items.Where<SupplierImageView>((Func<SupplierImageView, bool>) (x => x.sui_Kind == 2)).FirstOrDefault<SupplierImageView>();
        // ISSUE: explicit non-virtual call
        SupplierImageView supplierImageView3 = __nonvirtual (pageSupplierMpartVm.WorkDataT).CurrentT.ImageInfo.Items.Where<SupplierImageView>((Func<SupplierImageView, bool>) (x => x.sui_Kind == 3)).FirstOrDefault<SupplierImageView>();
        int suiId;
        switch (num)
        {
          case 1:
            suiId = supplierImageView1.sui_ID;
            break;
          case 2:
            suiId = supplierImageView2.sui_ID;
            break;
          case 3:
            suiId = supplierImageView3.sui_ID;
            break;
          default:
            return;
        }
        // ISSUE: explicit non-virtual call
        using (JobProgressState j = __nonvirtual (pageSupplierMpartVm.Job).CreateJob("이미지 다운로드", (string) null))
        {
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          UniBizHttpDownloadInfo downloadInfoAsync = await SupplierRestServer.GetSupplierImageFile(pageSupplierMpartVm.LogInPackInfo.sendType, pageSupplierMpartVm.LogInPackInfo.siteID, suiId, 0, __nonvirtual (pageSupplierMpartVm.MenuInfo).Code).ExecuteToDownloadInfoAsync((UniBizHttpClient) __nonvirtual (pageSupplierMpartVm.App).Api, (IProgress<double>) new Progress<double>((Action<double>) (p => j.Value = new double?(p))), j.Token);
          await File.WriteAllBytesAsync(Environment.ExpandEnvironmentVariables("%userprofile%/downloads/") + downloadInfoAsync.Disposition.FileName, downloadInfoAsync.Data, j.Token);
        }
      }
      catch (Exception ex)
      {
        // ISSUE: explicit non-virtual call
        Log.Error(__nonvirtual (pageSupplierMpartVm.MenuInfo).Title + " 오류=" + ex.Message);
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (pageSupplierMpartVm.Container)).Set(__nonvirtual (pageSupplierMpartVm.MenuInfo).Title + " 오류", ex.Message).ShowDialog();
      }
    }

    public WpfCommand CmdSearchHeadSupplier => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand>((Func<WpfCommand>) (() =>
    {
      return new WpfCommand()
      {
        IsAutoRefresh = true,
        CanExecuteFunc = (Func<object, bool>) (_ => this.CanSearchHeadSupplier()),
        ExecuteAction = (Action<object>) (_ => this.SearchHeadSupplier())
      };
    }), nameof (CmdSearchHeadSupplier));

    public bool CanSearchHeadSupplier() => this.App.User.User.Source.IsSupplierSave && this.WorkDataT != null && this.WorkDataT.CurrentT != null;

    public void SearchHeadSupplier()
    {
      try
      {
        if (!this.CanSearchHeadSupplier())
          return;
        SupplierView supplierView = this.Container.Get<SupplierCommonBoardVM>().Action<SupplierCommonBoardVM>((Action<SupplierCommonBoardVM>) (it => it.LoadManagedStatus())).Set("(" + this.WorkDataT.CurrentT.su_SupplierName + ")업체 대표 업체 등록").ShowDialog2Data();
        if (supplierView == null || supplierView.su_Supplier == 0)
          return;
        if (this.WorkDataT.CurrentT.su_Supplier != supplierView.su_Supplier && supplierView.su_Supplier != supplierView.su_HeadSupplier)
        {
          int num = (int) new CommonMsgVM(this.Container).Set("대표 업체 등록 오류", supplierView.su_SupplierName + " 업체는 대표업체가 아닙니다.").ShowDialog();
        }
        else
        {
          this.WorkDataT.CurrentT.su_HeadSupplier = supplierView.su_Supplier;
          this.WorkDataT.CurrentT.su_head_Name = supplierView.su_SupplierName;
        }
      }
      catch (Exception ex)
      {
        Log.Error("대표 업체 등록 오류=" + ex.Message);
        int num = (int) new CommonMsgVM(this.Container).Set("대표 업체 등록 오류", ex.Message).ShowDialog();
      }
    }

    public class SearchParam : ParamBase<PageSupplierMPartVM.SearchParam>
    {
      private int _sui_ID_Kind_1;
      private string _sui_ThumbImage1Url = string.Empty;
      private int _sui_ID_Kind_2;
      private string _sui_ThumbImage2Url = string.Empty;
      private int _sui_ID_Kind_3;
      private string _sui_ThumbImage3Url = string.Empty;

      public int sui_ID_Kind_1
      {
        get => this._sui_ID_Kind_1;
        set
        {
          this._sui_ID_Kind_1 = value;
          this.Changed(nameof (sui_ID_Kind_1));
        }
      }

      public string sui_ThumbImage1Url
      {
        get => this._sui_ThumbImage1Url;
        set
        {
          this._sui_ThumbImage1Url = value;
          this.Changed(nameof (sui_ThumbImage1Url));
        }
      }

      public int sui_ID_Kind_2
      {
        get => this._sui_ID_Kind_2;
        set
        {
          this._sui_ID_Kind_2 = value;
          this.Changed(nameof (sui_ID_Kind_2));
        }
      }

      public string sui_ThumbImage2Url
      {
        get => this._sui_ThumbImage2Url;
        set
        {
          this._sui_ThumbImage2Url = value;
          this.Changed(nameof (sui_ThumbImage2Url));
        }
      }

      public int sui_ID_Kind_3
      {
        get => this._sui_ID_Kind_3;
        set
        {
          this._sui_ID_Kind_3 = value;
          this.Changed(nameof (sui_ID_Kind_3));
        }
      }

      public string sui_ThumbImage3Url
      {
        get => this._sui_ThumbImage3Url;
        set
        {
          this._sui_ThumbImage3Url = value;
          this.Changed(nameof (sui_ThumbImage3Url));
        }
      }
    }
  }
}
