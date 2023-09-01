// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Part.Containers.Code.Store.PageStorePartConVM
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
using UniBiz.Bo.Models.UniBase.Store;
using UniBiz.Bo.Models.UniBase.Store.StoreInfo;
using UniBizBO.Composition;
using UniBizBO.Services;
using UniBizBO.Services.Part;
using UniBizBO.ViewModels.Box;
using UniBizBO.ViewModels.Message;
using UniBizUtil.Util;
using UniinfoNet.Http.UniBiz;


#nullable enable
namespace UniBizBO.ViewModels.Part.Containers.Code.Store
{
  public class PageStorePartConVM : PartContainerBase<
  #nullable disable
  PageStorePartConVM, StoreInfoView>
  {
    public override TableCodeType TableCode { get; } = TableCodeType.StoreInfo;

    public PageStorePartConVM(IContainer container)
      : base(container)
    {
    }

    protected override void OnInitialActivate() => base.OnInitialActivate();

    public override async Task ClearWorkDataAsync()
    {
      PageStorePartConVM pageStorePartConVm = this;
      // ISSUE: reference to a compiler-generated method
      await pageStorePartConVm.\u003C\u003En__0();
      pageStorePartConVm.ContainerTitle = pageStorePartConVm.TableCode.ToDescription() + " 등록 정보 / 초기화";
    }

    protected override async Task OnLoadingWorkDataAsync()
    {
      PageStorePartConVM pageStorePartConVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (pageStorePartConVm.Job).CreateJob(pageStorePartConVm.TableCode.ToDescription() + " 불러오기", (string) null))
        {
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          StoreInfoView data = (await StoreRestServer.GetStoreInfo(pageStorePartConVm.LogInPackInfo.sendType, pageStorePartConVm.LogInPackInfo.siteID, (int) ((IEnumerable<object>) __nonvirtual (pageStorePartConVm.WorkDataKeys)).First<object>(), 0, pageStorePartConVm.MenuInfo.Code).ExecuteToReturnAsync<UbRes<StoreInfoView>>((UniBizHttpClient) __nonvirtual (pageStorePartConVm.App).Api)).GetData<StoreInfoView>();
          // ISSUE: explicit non-virtual call
          __nonvirtual (pageStorePartConVm.WorkDataT).Set(data);
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          pageStorePartConVm.ContainerTitle = string.Format("{0} 등록 정보 / {1}[{2}]({3})", (object) pageStorePartConVm.TableCode.ToDescription(), (object) __nonvirtual (pageStorePartConVm.WorkDataT).OriginT.si_StoreName, (object) __nonvirtual (pageStorePartConVm.WorkDataT).OriginT.si_StoreViewCode, (object) __nonvirtual (pageStorePartConVm.WorkDataT).OriginT.si_StoreCode);
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          __nonvirtual (pageStorePartConVm.ContentsDisplay) = string.Format("{0}[{1}]({2})", (object) __nonvirtual (pageStorePartConVm.WorkDataT).OriginT.si_StoreName, (object) __nonvirtual (pageStorePartConVm.WorkDataT).OriginT.si_StoreViewCode, (object) __nonvirtual (pageStorePartConVm.WorkDataT).OriginT.si_StoreCode);
        }
      }
      catch (Exception ex)
      {
        Log.Logger.Error(ex, ex.Message);
        // ISSUE: explicit non-virtual call
        int num = (int) __nonvirtual (pageStorePartConVm.Container).Get<CommonMsgVM>().SetException(ex).ShowDialog();
        throw;
      }
    }

    protected override async Task OnSavingWorkDataAsync()
    {
      PageStorePartConVM pageStorePartConVm1 = this;
      try
      {
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (pageStorePartConVm1.Job).CreateJob(pageStorePartConVm1.TableCode.ToDescription() + " 저장", (string) null))
        {
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          StoreInfoView data = (await StoreRestServer.PostStoreInfo(pageStorePartConVm1.LogInPackInfo.sendType, pageStorePartConVm1.LogInPackInfo.siteID, (int) ((IEnumerable<object>) __nonvirtual (pageStorePartConVm1.WorkDataKeys)).First<object>(), 0, pageStorePartConVm1.MenuInfo.Code, __nonvirtual (pageStorePartConVm1.WorkDataT).CurrentT).ExecuteToReturnAsync<UbRes<StoreInfoView>>((UniBizHttpClient) __nonvirtual (pageStorePartConVm1.App).Api)).GetData<StoreInfoView>();
          // ISSUE: explicit non-virtual call
          __nonvirtual (pageStorePartConVm1.WorkDataT).Set(data);
          // ISSUE: explicit non-virtual call
          if (__nonvirtual (pageStorePartConVm1.IsCreateMode))
          {
            // ISSUE: explicit non-virtual call
            // ISSUE: explicit non-virtual call
            // ISSUE: explicit non-virtual call
            pageStorePartConVm1.ContainerTitle = string.Format("{0} 등록 정보 / {1}[{2}]({3})", (object) pageStorePartConVm1.TableCode.ToDescription(), (object) __nonvirtual (pageStorePartConVm1.WorkDataT).OriginT.si_StoreName, (object) __nonvirtual (pageStorePartConVm1.WorkDataT).OriginT.si_StoreViewCode, (object) __nonvirtual (pageStorePartConVm1.WorkDataT).OriginT.si_StoreCode);
            // ISSUE: explicit non-virtual call
            // ISSUE: explicit non-virtual call
            // ISSUE: explicit non-virtual call
            // ISSUE: explicit non-virtual call
            __nonvirtual (pageStorePartConVm1.ContentsDisplay) = string.Format("{0}[{1}]({2})", (object) __nonvirtual (pageStorePartConVm1.WorkDataT).OriginT.si_StoreName, (object) __nonvirtual (pageStorePartConVm1.WorkDataT).OriginT.si_StoreViewCode, (object) __nonvirtual (pageStorePartConVm1.WorkDataT).OriginT.si_StoreCode);
            PageStorePartConVM pageStorePartConVm2 = pageStorePartConVm1;
            object[] objArray;
            // ISSUE: explicit non-virtual call
            if (!(__nonvirtual (pageStorePartConVm1.WorkDataT).OriginT._Key is object[] key))
            {
              // ISSUE: explicit non-virtual call
              objArray = new object[1]
              {
                __nonvirtual (pageStorePartConVm1.WorkDataT).OriginT._Key
              };
            }
            else
              objArray = key;
            // ISSUE: explicit non-virtual call
            __nonvirtual (pageStorePartConVm2.WorkDataKeys) = objArray;
            pageStorePartConVm1.RefreshChildren();
          }
        }
      }
      catch (Exception ex)
      {
        Log.Logger.Error(ex, ex.Message);
        // ISSUE: explicit non-virtual call
        int num = (int) __nonvirtual (pageStorePartConVm1.Container).Get<CommonMsgVM>().SetException(ex).ShowDialog();
        throw;
      }
    }

    protected override async Task OnClearingWorkDataAsync()
    {
      this.WorkDataT.Set(new StoreInfoView());
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
