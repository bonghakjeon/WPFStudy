// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Part.Containers.Code.Employee.PageEmployeePartConVM
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
using UniBiz.Bo.Models.UniBase.Employee;
using UniBiz.Bo.Models.UniBase.Employee.Employee;
using UniBizBO.Composition;
using UniBizBO.Services;
using UniBizBO.Services.Part;
using UniBizBO.ViewModels.Box;
using UniBizBO.ViewModels.Message;
using UniBizUtil.Util;
using UniinfoNet.Http.UniBiz;


#nullable enable
namespace UniBizBO.ViewModels.Part.Containers.Code.Employee
{
  public class PageEmployeePartConVM : PartContainerBase<
  #nullable disable
  PageEmployeePartConVM, EmployeeView>
  {
    public override TableCodeType TableCode { get; } = TableCodeType.Employee;

    public PageEmployeePartConVM(IContainer container)
      : base(container)
    {
    }

    protected override void OnInitialActivate() => base.OnInitialActivate();

    public override async Task ClearWorkDataAsync()
    {
      PageEmployeePartConVM employeePartConVm = this;
      // ISSUE: reference to a compiler-generated method
      await employeePartConVm.\u003C\u003En__0();
      employeePartConVm.ContainerTitle = employeePartConVm.TableCode.ToDescription() + " 등록 정보 / 초기화";
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      __nonvirtual (employeePartConVm.WorkDataT).CurrentT.emp_BaseStore = __nonvirtual (employeePartConVm.App).User.User.Source.emp_BaseStore;
      // ISSUE: explicit non-virtual call
      // ISSUE: explicit non-virtual call
      __nonvirtual (employeePartConVm.WorkDataT).CurrentT.si_StoreName = __nonvirtual (employeePartConVm.App).User.User.Source.si_StoreName;
    }

    protected override async Task OnLoadingWorkDataAsync()
    {
      PageEmployeePartConVM employeePartConVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (employeePartConVm.Job).CreateJob(employeePartConVm.TableCode.ToDescription() + " 불러오기", (string) null))
        {
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          EmployeeView data = (await EmployeeRestServer.GetEmployee(employeePartConVm.LogInPackInfo.sendType, employeePartConVm.LogInPackInfo.siteID, (int) ((IEnumerable<object>) __nonvirtual (employeePartConVm.WorkDataKeys)).First<object>(), 0, employeePartConVm.MenuInfo.Code, true).ExecuteToReturnAsync<UbRes<EmployeeView>>((UniBizHttpClient) __nonvirtual (employeePartConVm.App).Api)).GetData<EmployeeView>();
          // ISSUE: explicit non-virtual call
          __nonvirtual (employeePartConVm.WorkDataT).Set(data);
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          employeePartConVm.ContainerTitle = string.Format("{0} 등록 정보 / {1}[{2}]({3})", (object) employeePartConVm.TableCode.ToDescription(), (object) __nonvirtual (employeePartConVm.WorkDataT).OriginT.emp_Name, (object) __nonvirtual (employeePartConVm.WorkDataT).OriginT.emp_ID, (object) __nonvirtual (employeePartConVm.WorkDataT).OriginT.emp_Code);
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          __nonvirtual (employeePartConVm.ContentsDisplay) = string.Format("{0}[{1}]({2})", (object) __nonvirtual (employeePartConVm.WorkDataT).OriginT.emp_Name, (object) __nonvirtual (employeePartConVm.WorkDataT).OriginT.emp_ID, (object) __nonvirtual (employeePartConVm.WorkDataT).OriginT.emp_Code);
        }
      }
      catch (Exception ex)
      {
        Log.Logger.Error(ex, ex.Message);
        // ISSUE: explicit non-virtual call
        int num = (int) __nonvirtual (employeePartConVm.Container).Get<CommonMsgVM>().SetException(ex).ShowDialog();
        throw;
      }
    }

    protected override async Task OnSavingWorkDataAsync()
    {
      PageEmployeePartConVM employeePartConVm1 = this;
      try
      {
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (employeePartConVm1.Job).CreateJob(employeePartConVm1.TableCode.ToDescription() + " 저장", (string) null))
        {
          // ISSUE: explicit non-virtual call
          if (__nonvirtual (employeePartConVm1.IsCreateMode))
          {
            // ISSUE: explicit non-virtual call
            __nonvirtual (employeePartConVm1.WorkDataT).CurrentT.emp_SiteID = employeePartConVm1.LogInPackInfo.siteID;
          }
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          // ISSUE: explicit non-virtual call
          EmployeeView data = (await EmployeeRestServer.PostEmployee(employeePartConVm1.LogInPackInfo.sendType, employeePartConVm1.LogInPackInfo.siteID, __nonvirtual (employeePartConVm1.IsCreateMode) ? 0 : (int) ((IEnumerable<object>) __nonvirtual (employeePartConVm1.WorkDataKeys)).FirstOrDefault<object>(), 0, employeePartConVm1.MenuInfo.Code, __nonvirtual (employeePartConVm1.WorkDataT).CurrentT).ExecuteToReturnAsync<UbRes<EmployeeView>>((UniBizHttpClient) __nonvirtual (employeePartConVm1.App).Api)).GetData<EmployeeView>();
          // ISSUE: explicit non-virtual call
          __nonvirtual (employeePartConVm1.WorkDataT).Set(data);
          // ISSUE: explicit non-virtual call
          if (__nonvirtual (employeePartConVm1.IsCreateMode))
          {
            // ISSUE: explicit non-virtual call
            // ISSUE: explicit non-virtual call
            // ISSUE: explicit non-virtual call
            employeePartConVm1.ContainerTitle = string.Format("{0} 등록 정보 / {1}[{2}]({3})", (object) employeePartConVm1.TableCode.ToDescription(), (object) __nonvirtual (employeePartConVm1.WorkDataT).OriginT.emp_Name, (object) __nonvirtual (employeePartConVm1.WorkDataT).OriginT.emp_ID, (object) __nonvirtual (employeePartConVm1.WorkDataT).OriginT.emp_Code);
            // ISSUE: explicit non-virtual call
            // ISSUE: explicit non-virtual call
            // ISSUE: explicit non-virtual call
            // ISSUE: explicit non-virtual call
            __nonvirtual (employeePartConVm1.ContentsDisplay) = string.Format("{0}[{1}]({2})", (object) __nonvirtual (employeePartConVm1.WorkDataT).OriginT.emp_Name, (object) __nonvirtual (employeePartConVm1.WorkDataT).OriginT.emp_ID, (object) __nonvirtual (employeePartConVm1.WorkDataT).OriginT.emp_Code);
            PageEmployeePartConVM employeePartConVm2 = employeePartConVm1;
            object[] objArray;
            // ISSUE: explicit non-virtual call
            if (!(__nonvirtual (employeePartConVm1.WorkDataT).OriginT._Key is object[] key))
            {
              // ISSUE: explicit non-virtual call
              objArray = new object[1]
              {
                __nonvirtual (employeePartConVm1.WorkDataT).OriginT._Key
              };
            }
            else
              objArray = key;
            // ISSUE: explicit non-virtual call
            __nonvirtual (employeePartConVm2.WorkDataKeys) = objArray;
            employeePartConVm1.RefreshChildren();
          }
        }
      }
      catch (Exception ex)
      {
        Log.Logger.Error(ex, ex.Message);
        // ISSUE: explicit non-virtual call
        int num = (int) __nonvirtual (employeePartConVm1.Container).Get<CommonMsgVM>().SetException(ex).ShowDialog();
        throw;
      }
    }

    protected override async Task OnClearingWorkDataAsync()
    {
      this.WorkDataT.Set(new EmployeeView());
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
