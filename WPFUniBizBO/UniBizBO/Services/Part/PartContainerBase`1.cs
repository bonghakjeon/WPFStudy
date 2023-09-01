// Decompiled with JetBrains decompiler
// Type: UniBizBO.Services.Part.PartContainerBase`1
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using StyletIoC;
using System;
using System.Collections.Generic;
using UniBizBO.Composition;
using UniinfoNet;

namespace UniBizBO.Services.Part
{
  [HiddenVm]
  public abstract class PartContainerBase<TData> : 
    PartContainerBase,
    IPartContainer<TData>,
    IPartContainer,
    IHaveWorkDataSet,
    IHaveWorkDataSet<TData>
    where TData : class, INotifyPropertyChangedExtend
  {
    private Type dataType;

    public Type DataType
    {
      get
      {
        Type dataType = this.dataType;
        return (object) dataType != null ? dataType : (this.dataType = typeof (TData));
      }
    }

    public WorkDataSet<TData> WorkDataT
    {
      get => this.WorkData as WorkDataSet<TData>;
      protected set
      {
        this.WorkData = (WorkDataSet) value;
        this.NotifyOfPropertyChange(nameof (WorkDataT));
      }
    }

    public PartContainerBase(IContainer container)
      : base(container)
    {
      this.WorkDataT = new WorkDataSet<TData>();
    }

    public override IReadOnlyDictionary<string, TableColumnInfo> OnQueryDataHeaders() => this.App.Sys?.TableColumns?.GetDictionary<TData>();
  }
}
