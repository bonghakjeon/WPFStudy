// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Part.Containers.PageCategoryPartConVM
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
using UniBiz.Bo.Models.UniBase.Category;
using UniBizBO.Composition;
using UniBizBO.Services;
using UniBizBO.Services.Part;
using UniBizBO.ViewModels.Box;
using UniBizBO.ViewModels.Message;
using UniBizUtil.Util;
using UniinfoNet.Http.UniBiz;


#nullable enable
namespace UniBizBO.ViewModels.Part.Containers
{
  public class PageCategoryPartConVM : PartContainerBase<
  #nullable disable
  PageCategoryPartConVM, CategoryView>
  {
    public override TableCodeType TableCode { get; } = TableCodeType.Category;

    public PageCategoryPartConVM(IContainer container)
      : base(container)
    {
    }

    protected override void OnInitialActivate() => base.OnInitialActivate();

    public override async Task ClearWorkDataAsync()
    {
      PageCategoryPartConVM categoryPartConVm = this;
      // ISSUE: reference to a compiler-generated method
      await categoryPartConVm.\u003C\u003En__0();
      categoryPartConVm.ContainerTitle = categoryPartConVm.TableCode.ToDescription() + " 등록 정보 / 초기화";
    }

    protected override async Task OnLoadingWorkDataAsync()
    {
      PageCategoryPartConVM categoryPartConVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (categoryPartConVm.Job).CreateJob(categoryPartConVm.TableCode.ToDescription() + " 불러오기", (string) null))
        {
          // ISSUE: explicit non-virtual call
          UniBizHttpRequest<UbRes<CategoryView>> category = CategoryRestServer.GetCategory(categoryPartConVm.LogInPackInfo.sendType, categoryPartConVm.LogInPackInfo.siteID, (int) ((IEnumerable<object>) __nonvirtual (categoryPartConVm.WorkDataKeys)).First<object>(), 0, categoryPartConVm.MenuInfo.Code);
          // ISSUE: explicit non-virtual call
          CategoryView data = (await (category != null ? category.ExecuteToReturnAsync<UbRes<CategoryView>>((UniBizHttpClient) __nonvirtual (categoryPartConVm.App).Api) : (Task<UbRes<CategoryView>>) null)).GetData<CategoryView>();
          // ISSUE: explicit non-virtual call
          __nonvirtual (categoryPartConVm.WorkDataT).Set(data);
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          categoryPartConVm.ContainerTitle = string.Format("{0} 등록 정보 / {1}({2}) - Lv.{3}", (object) categoryPartConVm.TableCode.ToDescription(), (object) __nonvirtual (categoryPartConVm.WorkDataT).OriginT.ctg_CategoryName, (object) __nonvirtual (categoryPartConVm.WorkDataT).OriginT.ctg_ID, (object) __nonvirtual (categoryPartConVm.WorkDataT).OriginT.ctg_Depth);
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          __nonvirtual (categoryPartConVm.ContentsDisplay) = string.Format("{0}({1}) - Lv.{2}", (object) __nonvirtual (categoryPartConVm.WorkDataT).OriginT.ctg_CategoryName, (object) __nonvirtual (categoryPartConVm.WorkDataT).OriginT.ctg_ID, (object) __nonvirtual (categoryPartConVm.WorkDataT).OriginT.ctg_Depth);
        }
      }
      catch (Exception ex)
      {
        Log.Logger.Error(ex, ex.Message);
        // ISSUE: explicit non-virtual call
        int num = (int) __nonvirtual (categoryPartConVm.Container).Get<CommonMsgVM>().SetException(ex).ShowDialog();
        throw;
      }
    }

    protected override async Task OnSavingWorkDataAsync()
    {
      PageCategoryPartConVM categoryPartConVm1 = this;
      try
      {
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (categoryPartConVm1.Job).CreateJob(categoryPartConVm1.TableCode.ToDescription() + " 저장", (string) null))
        {
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          CategoryView data = (await CategoryRestServer.PostCategory(categoryPartConVm1.LogInPackInfo.sendType, categoryPartConVm1.LogInPackInfo.siteID, (int) ((IEnumerable<object>) __nonvirtual (categoryPartConVm1.WorkDataKeys)).First<object>(), 0, categoryPartConVm1.MenuInfo.Code, __nonvirtual (categoryPartConVm1.WorkDataT).CurrentT).ExecuteToReturnAsync<UbRes<CategoryView>>((UniBizHttpClient) __nonvirtual (categoryPartConVm1.App).Api)).GetData<CategoryView>();
          // ISSUE: explicit non-virtual call
          __nonvirtual (categoryPartConVm1.WorkDataT).Set(data);
          // ISSUE: explicit non-virtual call
          if (__nonvirtual (categoryPartConVm1.IsCreateMode))
          {
            // ISSUE: explicit non-virtual call
            // ISSUE: explicit non-virtual call
            // ISSUE: explicit non-virtual call
            categoryPartConVm1.ContainerTitle = string.Format("{0} 등록 정보 / {1}({2}) - Lv.{3}", (object) categoryPartConVm1.TableCode.ToDescription(), (object) __nonvirtual (categoryPartConVm1.WorkDataT).OriginT.ctg_CategoryName, (object) __nonvirtual (categoryPartConVm1.WorkDataT).OriginT.ctg_ID, (object) __nonvirtual (categoryPartConVm1.WorkDataT).OriginT.ctg_Depth);
            // ISSUE: explicit non-virtual call
            // ISSUE: explicit non-virtual call
            // ISSUE: explicit non-virtual call
            // ISSUE: explicit non-virtual call
            __nonvirtual (categoryPartConVm1.ContentsDisplay) = string.Format("{0}({1}) - Lv.{2}", (object) __nonvirtual (categoryPartConVm1.WorkDataT).OriginT.ctg_CategoryName, (object) __nonvirtual (categoryPartConVm1.WorkDataT).OriginT.ctg_ID, (object) __nonvirtual (categoryPartConVm1.WorkDataT).OriginT.ctg_Depth);
            PageCategoryPartConVM categoryPartConVm2 = categoryPartConVm1;
            object[] objArray;
            // ISSUE: explicit non-virtual call
            if (!(__nonvirtual (categoryPartConVm1.WorkDataT).OriginT._Key is object[] key))
            {
              // ISSUE: explicit non-virtual call
              objArray = new object[1]
              {
                __nonvirtual (categoryPartConVm1.WorkDataT).OriginT._Key
              };
            }
            else
              objArray = key;
            // ISSUE: explicit non-virtual call
            __nonvirtual (categoryPartConVm2.WorkDataKeys) = objArray;
            categoryPartConVm1.RefreshChildren();
          }
        }
      }
      catch (Exception ex)
      {
        Log.Logger.Error(ex, ex.Message);
        // ISSUE: explicit non-virtual call
        int num = (int) __nonvirtual (categoryPartConVm1.Container).Get<CommonMsgVM>().SetException(ex).ShowDialog();
        throw;
      }
    }

    protected override async Task OnClearingWorkDataAsync()
    {
      this.WorkDataT.Set(new CategoryView());
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
