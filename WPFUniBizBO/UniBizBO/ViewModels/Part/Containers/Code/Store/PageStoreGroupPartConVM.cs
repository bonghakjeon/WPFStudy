// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Part.Containers.Code.Store.PageStoreGroupPartConVM
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
using UniBiz.Bo.Models.UniBase.Store.StoreGroupHeader;
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
  public class PageStoreGroupPartConVM : 
    PartContainerBase<
    #nullable disable
    PageStoreGroupPartConVM, StoreGroupHeaderView>
  {
    public override TableCodeType TableCode { get; } = TableCodeType.StoreGroupHeader;

    public PageStoreGroupPartConVM(IContainer container)
      : base(container)
    {
    }

    protected override void OnInitialActivate() => base.OnInitialActivate();

    public override async Task ClearWorkDataAsync()
    {
      PageStoreGroupPartConVM storeGroupPartConVm = this;
      // ISSUE: reference to a compiler-generated method
      await storeGroupPartConVm.\u003C\u003En__0();
      storeGroupPartConVm.ContainerTitle = storeGroupPartConVm.TableCode.ToDescription() + " 등록 정보 / 초기화";
    }

    protected override async Task OnLoadingWorkDataAsync()
    {
      PageStoreGroupPartConVM storeGroupPartConVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (storeGroupPartConVm.Job).CreateJob(storeGroupPartConVm.TableCode.ToDescription() + " 불러오기", (string) null))
        {
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          StoreGroupHeaderView data = (await StoreRestServer.GetStoreGroupHeader(storeGroupPartConVm.LogInPackInfo.sendType, storeGroupPartConVm.LogInPackInfo.siteID, (int) ((IEnumerable<object>) __nonvirtual (storeGroupPartConVm.WorkDataKeys)).First<object>(), 0, storeGroupPartConVm.MenuInfo.Code).ExecuteToReturnAsync<UbRes<StoreGroupHeaderView>>((UniBizHttpClient) __nonvirtual (storeGroupPartConVm.App).Api)).GetData<StoreGroupHeaderView>();
          // ISSUE: explicit non-virtual call
          __nonvirtual (storeGroupPartConVm.WorkDataT).Set(data);
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          storeGroupPartConVm.ContainerTitle = string.Format("{0} 등록 정보 / {1}({2})", (object) storeGroupPartConVm.TableCode.ToDescription(), (object) __nonvirtual (storeGroupPartConVm.WorkDataT).OriginT.sgh_GroupName, (object) __nonvirtual (storeGroupPartConVm.WorkDataT).OriginT.sgh_GroupCode);
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          __nonvirtual (storeGroupPartConVm.ContentsDisplay) = string.Format("{0}({1})", (object) __nonvirtual (storeGroupPartConVm.WorkDataT).OriginT.sgh_GroupName, (object) __nonvirtual (storeGroupPartConVm.WorkDataT).OriginT.sgh_GroupCode);
        }
      }
      catch (Exception ex)
      {
        Log.Logger.Error(ex, ex.Message);
        // ISSUE: explicit non-virtual call
        int num = (int) __nonvirtual (storeGroupPartConVm.Container).Get<CommonMsgVM>().SetException(ex).ShowDialog();
        throw;
      }
    }

    protected override async Task OnSavingWorkDataAsync()
    {
      PageStoreGroupPartConVM storeGroupPartConVm1 = this;
      try
      {
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (storeGroupPartConVm1.Job).CreateJob(storeGroupPartConVm1.TableCode.ToDescription() + " 저장", (string) null))
        {
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          StoreGroupHeaderView data = (await StoreRestServer.PostStoreGroupHeader(storeGroupPartConVm1.LogInPackInfo.sendType, storeGroupPartConVm1.LogInPackInfo.siteID, (int) ((IEnumerable<object>) __nonvirtual (storeGroupPartConVm1.WorkDataKeys)).First<object>(), 0, storeGroupPartConVm1.MenuInfo.Code, __nonvirtual (storeGroupPartConVm1.WorkDataT).CurrentT).ExecuteToReturnAsync<UbRes<StoreGroupHeaderView>>((UniBizHttpClient) __nonvirtual (storeGroupPartConVm1.App).Api)).GetData<StoreGroupHeaderView>();
          // ISSUE: explicit non-virtual call
          __nonvirtual (storeGroupPartConVm1.WorkDataT).Set(data);
          // ISSUE: explicit non-virtual call
          if (__nonvirtual (storeGroupPartConVm1.IsCreateMode))
          {
            // ISSUE: explicit non-virtual call
            // ISSUE: explicit non-virtual call
            storeGroupPartConVm1.ContainerTitle = string.Format("{0} 등록 정보 / {1}({2})", (object) storeGroupPartConVm1.TableCode.ToDescription(), (object) __nonvirtual (storeGroupPartConVm1.WorkDataT).OriginT.sgh_GroupName, (object) __nonvirtual (storeGroupPartConVm1.WorkDataT).OriginT.sgh_GroupCode);
            // ISSUE: explicit non-virtual call
            // ISSUE: explicit non-virtual call
            // ISSUE: explicit non-virtual call
            __nonvirtual (storeGroupPartConVm1.ContentsDisplay) = string.Format("{0}({1})", (object) __nonvirtual (storeGroupPartConVm1.WorkDataT).OriginT.sgh_GroupName, (object) __nonvirtual (storeGroupPartConVm1.WorkDataT).OriginT.sgh_GroupCode);
            PageStoreGroupPartConVM storeGroupPartConVm2 = storeGroupPartConVm1;
            object[] objArray;
            // ISSUE: explicit non-virtual call
            if (!(__nonvirtual (storeGroupPartConVm1.WorkDataT).OriginT._Key is object[] key))
            {
              // ISSUE: explicit non-virtual call
              objArray = new object[1]
              {
                __nonvirtual (storeGroupPartConVm1.WorkDataT).OriginT._Key
              };
            }
            else
              objArray = key;
            // ISSUE: explicit non-virtual call
            __nonvirtual (storeGroupPartConVm2.WorkDataKeys) = objArray;
            storeGroupPartConVm1.RefreshChildren();
          }
        }
      }
      catch (Exception ex)
      {
        Log.Logger.Error(ex, ex.Message);
        // ISSUE: explicit non-virtual call
        int num = (int) __nonvirtual (storeGroupPartConVm1.Container).Get<CommonMsgVM>().SetException(ex).ShowDialog();
        throw;
      }
    }

    protected override async Task OnClearingWorkDataAsync()
    {
      this.WorkDataT.Set(new StoreGroupHeaderView());
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
