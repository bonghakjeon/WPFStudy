// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Part.Containers.Code.Supplier.PageSupplierPartConVM
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Serilog;
using StyletIoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniBiz.Bo.Models;
using UniBiz.Bo.Models.UbRest;
using UniBiz.Bo.Models.UniBase.Supplier;
using UniBiz.Bo.Models.UniBase.Supplier.Supplier;
using UniBizBO.Composition;
using UniBizBO.Services;
using UniBizBO.Services.Part;
using UniBizBO.ViewModels.Box;
using UniBizBO.ViewModels.Message;
using UniBizUtil.Util;
using UniinfoNet.Http.UniBiz;


#nullable enable
namespace UniBizBO.ViewModels.Part.Containers.Code.Supplier
{
  public class PageSupplierPartConVM : PartContainerBase<
  #nullable disable
  PageSupplierPartConVM, SupplierView>
  {
    public override TableCodeType TableCode { get; } = TableCodeType.Supplier;

    public PageSupplierPartConVM(IContainer container)
      : base(container)
    {
    }

    protected override void OnInitialActivate() => base.OnInitialActivate();

    public override async Task ClearWorkDataAsync()
    {
      PageSupplierPartConVM supplierPartConVm = this;
      // ISSUE: reference to a compiler-generated method
      await supplierPartConVm.\u003C\u003En__0();
      supplierPartConVm.ContainerTitle = supplierPartConVm.TableCode.ToDescription() + " 등록 정보 / 초기화";
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      __nonvirtual (supplierPartConVm.WorkDataT).CurrentT.su_AssignUser = __nonvirtual (supplierPartConVm.App).User.User.Source.emp_Code;
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      __nonvirtual (supplierPartConVm.WorkDataT).CurrentT.su_AssignUser_Name = __nonvirtual (supplierPartConVm.App).User.User.Source.emp_Name;
    }

    protected override async Task OnLoadingWorkDataAsync()
    {
      PageSupplierPartConVM supplierPartConVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (supplierPartConVm.Job).CreateJob(supplierPartConVm.TableCode.ToDescription() + " 불러오기", (string) null))
        {
          // ISSUE: explicit non-virtual call
          UniBizHttpRequest<UbRes<SupplierView>> supplier = SupplierRestServer.GetSupplier(supplierPartConVm.LogInPackInfo.sendType, supplierPartConVm.LogInPackInfo.siteID, (int) ((IEnumerable<object>) __nonvirtual (supplierPartConVm.WorkDataKeys)).First<object>(), 0, supplierPartConVm.MenuInfo.Code);
          // ISSUE: explicit non-virtual call
          SupplierView data = (await (supplier != null ? supplier.ExecuteToReturnAsync<UbRes<SupplierView>>((UniBizHttpClient) __nonvirtual (supplierPartConVm.App).Api) : (Task<UbRes<SupplierView>>) null)).GetData<SupplierView>();
          // ISSUE: explicit non-virtual call
          __nonvirtual (supplierPartConVm.WorkDataT).Set(data);
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          supplierPartConVm.ContainerTitle = string.Format("{0} 등록 정보 / {1}[{2}]({3})", (object) supplierPartConVm.TableCode.ToDescription(), (object) __nonvirtual (supplierPartConVm.WorkDataT).OriginT.su_SupplierName, (object) __nonvirtual (supplierPartConVm.WorkDataT).OriginT.su_SupplierViewCode, (object) __nonvirtual (supplierPartConVm.WorkDataT).OriginT.su_Supplier);
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          __nonvirtual (supplierPartConVm.ContentsDisplay) = string.Format("{0}[{1}]({2})", (object) __nonvirtual (supplierPartConVm.WorkDataT).OriginT.su_SupplierName, (object) __nonvirtual (supplierPartConVm.WorkDataT).OriginT.su_SupplierViewCode, (object) __nonvirtual (supplierPartConVm.WorkDataT).OriginT.su_Supplier);
        }
      }
      catch (Exception ex)
      {
        Log.Logger.Error(ex, ex.Message);
        // ISSUE: explicit non-virtual call
        int num = (int) __nonvirtual (supplierPartConVm.Container).Get<CommonMsgVM>().SetException(ex).ShowDialog();
        throw;
      }
    }

    protected override async Task OnSavingWorkDataAsync()
    {
      PageSupplierPartConVM supplierPartConVm1 = this;
      try
      {
        if (!await supplierPartConVm1.DataCheck())
          return;
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (supplierPartConVm1.Job).CreateJob("저장", (string) null))
        {
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          UniBizHttpRequest<UbRes<SupplierView>> req = SupplierRestServer.PostSupplier(supplierPartConVm1.LogInPackInfo.sendType, supplierPartConVm1.LogInPackInfo.siteID, (int) ((IEnumerable<object>) __nonvirtual (supplierPartConVm1.WorkDataKeys)).First<object>(), 0, supplierPartConVm1.MenuInfo.Code, __nonvirtual (supplierPartConVm1.WorkDataT).CurrentT);
          // ISSUE: explicit non-virtual call
          SupplierView data = (await (req != null ? req.ExecuteToReturnAsync<UbRes<SupplierView>>((UniBizHttpClient) __nonvirtual (supplierPartConVm1.App).Api) : (Task<UbRes<SupplierView>>) null)).GetData<SupplierView>();
          // ISSUE: explicit non-virtual call
          __nonvirtual (supplierPartConVm1.WorkDataT).Set(data);
          // ISSUE: explicit non-virtual call
          if (__nonvirtual (supplierPartConVm1.IsCreateMode))
          {
            // ISSUE: explicit non-virtual call
            // ISSUE: explicit non-virtual call
            // ISSUE: explicit non-virtual call
            supplierPartConVm1.ContainerTitle = string.Format("{0} 등록 정보 / {1}[{2}]({3})", (object) supplierPartConVm1.TableCode.ToDescription(), (object) __nonvirtual (supplierPartConVm1.WorkDataT).OriginT.su_SupplierName, (object) __nonvirtual (supplierPartConVm1.WorkDataT).OriginT.su_SupplierViewCode, (object) __nonvirtual (supplierPartConVm1.WorkDataT).OriginT.su_Supplier);
            // ISSUE: explicit non-virtual call
            // ISSUE: explicit non-virtual call
            // ISSUE: explicit non-virtual call
            // ISSUE: explicit non-virtual call
            __nonvirtual (supplierPartConVm1.ContentsDisplay) = string.Format("{0}[{1}]({2})", (object) __nonvirtual (supplierPartConVm1.WorkDataT).OriginT.su_SupplierName, (object) __nonvirtual (supplierPartConVm1.WorkDataT).OriginT.su_SupplierViewCode, (object) __nonvirtual (supplierPartConVm1.WorkDataT).OriginT.su_Supplier);
            PageSupplierPartConVM supplierPartConVm2 = supplierPartConVm1;
            object[] objArray;
            // ISSUE: explicit non-virtual call
            if (!(__nonvirtual (supplierPartConVm1.WorkDataT).OriginT._Key is object[] key))
            {
              // ISSUE: explicit non-virtual call
              objArray = new object[1]
              {
                __nonvirtual (supplierPartConVm1.WorkDataT).OriginT._Key
              };
            }
            else
              objArray = key;
            // ISSUE: explicit non-virtual call
            __nonvirtual (supplierPartConVm2.WorkDataKeys) = objArray;
            supplierPartConVm1.RefreshChildren();
          }
        }
      }
      catch (Exception ex)
      {
        Log.Logger.Error(ex, ex.Message);
        // ISSUE: explicit non-virtual call
        int num = (int) __nonvirtual (supplierPartConVm1.Container).Get<CommonMsgVM>().SetException(ex).ShowDialog();
        throw;
      }
    }

    private async Task<bool> DataCheck()
    {
      PageSupplierPartConVM supplierPartConVm = this;
      bool isContinue = true;
      try
      {
        // ISSUE: explicit non-virtual call
        if (!__nonvirtual (supplierPartConVm.IsCreateMode))
        {
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          if (!(__nonvirtual (supplierPartConVm.WorkDataT).CurrentT.su_BizNo != __nonvirtual (supplierPartConVm.WorkDataT).OriginT.su_BizNo))
            goto label_15;
        }
        List<SupplierView> supplierViewList = await supplierPartConVm.SearchBizNo();
        if (supplierViewList != null)
        {
          if (supplierViewList.Count > 0)
          {
            string str = string.Empty;
            foreach (SupplierView supplierView in supplierViewList)
              str = str + supplierView.su_SupplierViewCode + " " + supplierView.su_SupplierName + "\r\n";
            string message = str + "\r\n같은 사업자번호를 사용하는 거래처가 존재합니다.\r\n등록하시겠습니까?";
            // ISSUE: explicit non-virtual call
            if (new CommonMsgVM(__nonvirtual (supplierPartConVm.Container)).SetDefault(MsgBoxLevel.Info, "데이타 저장", message, MsgBoxButton.Yes, MsgBoxButton.Yes, MsgBoxButton.No).ShowDialog() == MsgBoxButton.No)
              isContinue = false;
          }
        }
        else
          isContinue = false;
      }
      catch (Exception ex)
      {
        // ISSUE: explicit non-virtual call
        int num = (int) __nonvirtual (supplierPartConVm.Container).Get<CommonMsgVM>().SetException(ex).ShowDialog();
        throw;
      }
label_15:
      return isContinue;
    }

    private async Task<List<SupplierView>> SearchBizNo()
    {
      PageSupplierPartConVM supplierPartConVm = this;
      List<SupplierView> response;
      try
      {
        int su_Supplier = 0;
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        if (!__nonvirtual (supplierPartConVm.IsCreateMode) && __nonvirtual (supplierPartConVm.WorkDataT).CurrentT.su_BizNo != __nonvirtual (supplierPartConVm.WorkDataT).OriginT.su_BizNo)
        {
          // ISSUE: explicit non-virtual call
          su_Supplier = __nonvirtual (supplierPartConVm.WorkDataT).CurrentT.su_Supplier;
        }
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        response = (List<SupplierView>) (await SupplierRestServer.GetSupplierBizNoList(supplierPartConVm.LogInPackInfo.sendType, supplierPartConVm.LogInPackInfo.siteID, __nonvirtual (supplierPartConVm.WorkDataT).CurrentT.su_BizNo, 0, supplierPartConVm.MenuInfo.Code, su_Supplier).ExecuteToReturnAsync<UbRes<IList<SupplierView>>>((UniBizHttpClient) __nonvirtual (supplierPartConVm.App).Api)).GetSuccess<UbRes<IList<SupplierView>>>().response;
      }
      catch (Exception ex)
      {
        // ISSUE: explicit non-virtual call
        int num = (int) __nonvirtual (supplierPartConVm.Container).Get<CommonMsgVM>().SetException(ex).ShowDialog();
        throw;
      }
      return response;
    }

    protected override async Task OnClearingWorkDataAsync()
    {
      this.WorkDataT.Set(new SupplierView());
      await Task.Yield();
    }

    public void SendWinMessage(VKeys p_vkey, int p_message, long p_wParam, long p_lParam) => this.PartAppWinMessage(new AppWinMsg((IUbVM) this)
    {
      VKey = p_vkey,
      Message = p_message,
      WParam = p_wParam,
      LParam = p_lParam
    });
  }
}
