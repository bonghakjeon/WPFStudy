// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Part.Containers.PageDeptPartConVM
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
using UniBiz.Bo.Models.UniBase.Dept;
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
  public class PageDeptPartConVM : PartContainerBase<
  #nullable disable
  PageDeptPartConVM, DeptView>
  {
    public override TableCodeType TableCode { get; } = TableCodeType.Dept;

    public PageDeptPartConVM(IContainer container)
      : base(container)
    {
    }

    protected override void OnInitialActivate() => base.OnInitialActivate();

    public override async Task ClearWorkDataAsync()
    {
      PageDeptPartConVM pageDeptPartConVm = this;
      // ISSUE: reference to a compiler-generated method
      await pageDeptPartConVm.\u003C\u003En__0();
      pageDeptPartConVm.ContainerTitle = pageDeptPartConVm.TableCode.ToDescription() + " 등록 정보 / 초기화";
    }

    protected override async Task OnLoadingWorkDataAsync()
    {
      PageDeptPartConVM pageDeptPartConVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (pageDeptPartConVm.Job).CreateJob(pageDeptPartConVm.TableCode.ToDescription() + " 불러오기", (string) null))
        {
          // ISSUE: explicit non-virtual call
          UniBizHttpRequest<UbRes<DeptView>> dept = DeptRestServer.GetDept(pageDeptPartConVm.LogInPackInfo.sendType, pageDeptPartConVm.LogInPackInfo.siteID, (int) ((IEnumerable<object>) __nonvirtual (pageDeptPartConVm.WorkDataKeys)).First<object>(), 0, pageDeptPartConVm.MenuInfo.Code);
          // ISSUE: explicit non-virtual call
          DeptView data = (await (dept != null ? dept.ExecuteToReturnAsync<UbRes<DeptView>>((UniBizHttpClient) __nonvirtual (pageDeptPartConVm.App).Api) : (Task<UbRes<DeptView>>) null)).GetData<DeptView>();
          // ISSUE: explicit non-virtual call
          __nonvirtual (pageDeptPartConVm.WorkDataT).Set(data);
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          pageDeptPartConVm.ContainerTitle = string.Format("{0} 등록 정보 / {1}({2}) - Lv.{3}", (object) pageDeptPartConVm.TableCode.ToDescription(), (object) __nonvirtual (pageDeptPartConVm.WorkDataT).OriginT.dpt_DeptName, (object) __nonvirtual (pageDeptPartConVm.WorkDataT).OriginT.dpt_ID, (object) __nonvirtual (pageDeptPartConVm.WorkDataT).OriginT.dpt_Depth);
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          __nonvirtual (pageDeptPartConVm.ContentsDisplay) = string.Format("{0}({1}) - Lv.{2}", (object) __nonvirtual (pageDeptPartConVm.WorkDataT).OriginT.dpt_DeptName, (object) __nonvirtual (pageDeptPartConVm.WorkDataT).OriginT.dpt_ID, (object) __nonvirtual (pageDeptPartConVm.WorkDataT).OriginT.dpt_Depth);
        }
      }
      catch (Exception ex)
      {
        Log.Logger.Error(ex, ex.Message);
        // ISSUE: explicit non-virtual call
        int num = (int) __nonvirtual (pageDeptPartConVm.Container).Get<CommonMsgVM>().SetException(ex).ShowDialog();
        throw;
      }
    }

    protected override async Task OnSavingWorkDataAsync()
    {
      PageDeptPartConVM pageDeptPartConVm1 = this;
      try
      {
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (pageDeptPartConVm1.Job).CreateJob(pageDeptPartConVm1.TableCode.ToDescription() + " 저장", (string) null))
        {
          string sendType = pageDeptPartConVm1.LogInPackInfo.sendType;
          long siteId = pageDeptPartConVm1.LogInPackInfo.siteID;
          // ISSUE: explicit non-virtual call
          object[] workDataKeys = __nonvirtual (pageDeptPartConVm1.WorkDataKeys);
          int valueOrDefault = ((workDataKeys != null ? ((IEnumerable<object>) workDataKeys).FirstOrDefault<object>() : (object) null) as int?).GetValueOrDefault();
          int code = pageDeptPartConVm1.MenuInfo.Code;
          // ISSUE: explicit non-virtual call
          DeptView currentT = __nonvirtual (pageDeptPartConVm1.WorkDataT).CurrentT;
          UniBizHttpRequest<UbRes<DeptView>> req = DeptRestServer.PostDept(sendType, siteId, valueOrDefault, 0, code, currentT);
          // ISSUE: explicit non-virtual call
          DeptView data = (await (req != null ? req.ExecuteToReturnAsync<UbRes<DeptView>>((UniBizHttpClient) __nonvirtual (pageDeptPartConVm1.App).Api) : (Task<UbRes<DeptView>>) null)).GetData<DeptView>();
          // ISSUE: explicit non-virtual call
          __nonvirtual (pageDeptPartConVm1.WorkDataT).Set(data);
          // ISSUE: explicit non-virtual call
          if (__nonvirtual (pageDeptPartConVm1.IsCreateMode))
          {
            // ISSUE: explicit non-virtual call
            // ISSUE: explicit non-virtual call
            // ISSUE: explicit non-virtual call
            pageDeptPartConVm1.ContainerTitle = string.Format("{0} 등록 정보 / {1}({2}) - Lv.{3}", (object) pageDeptPartConVm1.TableCode.ToDescription(), (object) __nonvirtual (pageDeptPartConVm1.WorkDataT).OriginT.dpt_DeptName, (object) __nonvirtual (pageDeptPartConVm1.WorkDataT).OriginT.dpt_ID, (object) __nonvirtual (pageDeptPartConVm1.WorkDataT).OriginT.dpt_Depth);
            // ISSUE: explicit non-virtual call
            // ISSUE: explicit non-virtual call
            // ISSUE: explicit non-virtual call
            // ISSUE: explicit non-virtual call
            __nonvirtual (pageDeptPartConVm1.ContentsDisplay) = string.Format("{0}({1}) - Lv.{2}", (object) __nonvirtual (pageDeptPartConVm1.WorkDataT).OriginT.dpt_DeptName, (object) __nonvirtual (pageDeptPartConVm1.WorkDataT).OriginT.dpt_ID, (object) __nonvirtual (pageDeptPartConVm1.WorkDataT).OriginT.dpt_Depth);
            PageDeptPartConVM pageDeptPartConVm2 = pageDeptPartConVm1;
            object[] objArray;
            // ISSUE: explicit non-virtual call
            if (!(__nonvirtual (pageDeptPartConVm1.WorkDataT).OriginT._Key is object[] key))
            {
              // ISSUE: explicit non-virtual call
              objArray = new object[1]
              {
                __nonvirtual (pageDeptPartConVm1.WorkDataT).OriginT._Key
              };
            }
            else
              objArray = key;
            // ISSUE: explicit non-virtual call
            __nonvirtual (pageDeptPartConVm2.WorkDataKeys) = objArray;
            pageDeptPartConVm1.RefreshChildren();
          }
        }
      }
      catch (Exception ex)
      {
        Log.Logger.Error(ex, ex.Message);
        // ISSUE: explicit non-virtual call
        int num = (int) __nonvirtual (pageDeptPartConVm1.Container).Get<CommonMsgVM>().SetException(ex).ShowDialog();
        throw;
      }
    }

    protected override async Task OnClearingWorkDataAsync()
    {
      this.WorkDataT.Set(new DeptView());
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
