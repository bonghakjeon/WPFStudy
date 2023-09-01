// Decompiled with JetBrains decompiler
// Type: UniBizBO.Services.Part.PartContainerBase`2
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using StyletIoC;
using System;
using System.Threading.Tasks;
using UniinfoNet;


#nullable enable
namespace UniBizBO.Services.Part
{
  [HiddenVm]
  public abstract class PartContainerBase<TPartContainer, TData> : PartContainerBase<
  #nullable disable
  TData>
    where TPartContainer : PartContainerBase<TPartContainer, TData>
    where TData : class, INotifyPropertyChangedExtend
  {
    public Func<TPartContainer, Task> WorkDataManualLoadingAsync;
    public Func<TPartContainer, Task> WorkDataManualSavingAsync;
    public Func<TPartContainer, Task> LoadedAsync;
    public Func<TPartContainer, Task> SavedAsync;
    public Func<TPartContainer, Task> RollbackedAsync;
    public Func<TPartContainer, Task> ConfirmedAsync;

    public PartContainerBase(IContainer container)
      : base(container)
    {
    }

    public override async Task LoadWorkDataAsync()
    {
      PartContainerBase<TPartContainer, TData> partContainerBase = this;
      if (partContainerBase.IsManualLoadWorkData)
      {
        Func<TPartContainer, Task> manualLoadingAsync = partContainerBase.WorkDataManualLoadingAsync;
        await ((manualLoadingAsync != null ? manualLoadingAsync((TPartContainer) partContainerBase) : (Task) null) ?? Task.CompletedTask);
      }
      else
      {
        partContainerBase.ContainerTitle = "등록정보";
        // ISSUE: explicit non-virtual call
        if (__nonvirtual (partContainerBase.IsCreateMode))
          await partContainerBase.ClearWorkDataAsync();
        else
          await partContainerBase.OnLoadingWorkDataAsync();
        Func<TPartContainer, Task> loadedAsync = partContainerBase.LoadedAsync;
        await ((loadedAsync != null ? loadedAsync((TPartContainer) partContainerBase) : (Task) null) ?? Task.CompletedTask);
      }
    }

    public override async Task SaveWorkDataAsync()
    {
      PartContainerBase<TPartContainer, TData> partContainerBase = this;
      if (partContainerBase.IsManualSaveWorkData)
      {
        Func<TPartContainer, Task> manualSavingAsync = partContainerBase.WorkDataManualSavingAsync;
        await ((manualSavingAsync != null ? manualSavingAsync((TPartContainer) partContainerBase) : (Task) null) ?? Task.CompletedTask);
      }
      else
        await partContainerBase.OnSavingWorkDataAsync();
      Func<TPartContainer, Task> savedAsync = partContainerBase.SavedAsync;
      await ((savedAsync != null ? savedAsync((TPartContainer) partContainerBase) : (Task) null) ?? Task.CompletedTask);
    }

    public override async Task ClearWorkDataAsync()
    {
      PartContainerBase<TPartContainer, TData> partContainerBase = this;
      await partContainerBase.OnClearingWorkDataAsync();
      partContainerBase.ContainerTitle = "등록정보 / 초기화";
    }

    public override async Task RollbackWorkDataAsync()
    {
      PartContainerBase<TPartContainer, TData> partContainerBase = this;
      // ISSUE: reference to a compiler-generated method
      await partContainerBase.\u003C\u003En__0();
      Func<TPartContainer, Task> rollbackedAsync = partContainerBase.RollbackedAsync;
      await ((rollbackedAsync != null ? rollbackedAsync((TPartContainer) partContainerBase) : (Task) null) ?? Task.CompletedTask);
    }

    public override async Task ConfirmAsync()
    {
      PartContainerBase<TPartContainer, TData> partContainerBase = this;
      // ISSUE: reference to a compiler-generated method
      await partContainerBase.\u003C\u003En__1();
      Func<TPartContainer, Task> confirmedAsync = partContainerBase.ConfirmedAsync;
      await ((confirmedAsync != null ? confirmedAsync((TPartContainer) partContainerBase) : (Task) null) ?? Task.CompletedTask);
    }
  }
}
