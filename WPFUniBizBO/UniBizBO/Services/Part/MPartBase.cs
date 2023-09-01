// Decompiled with JetBrains decompiler
// Type: UniBizBO.Services.Part.MPartBase`1
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
  public abstract class MPartBase<TData> : 
    PartBase,
    IMPart,
    IPart,
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

    public IPartContainer<TData> PartContainerT => this.PartContainer as IPartContainer<TData>;

    public WorkDataSet<TData> WorkDataT => (this.Parent is IHaveWorkDataSet parent ? parent.WorkData : (WorkDataSet) null) as WorkDataSet<TData>;

    public MPartBase(IContainer container)
      : base(container)
    {
    }

    public override IReadOnlyDictionary<string, TableColumnInfo> OnQueryDataHeaders() => this.App.Sys?.TableColumns?.GetDictionary<TData>();
  }
}
