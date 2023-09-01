// Decompiled with JetBrains decompiler
// Type: UniBizBO.Services.Part.SPartBase`1
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Stylet;
using StyletIoC;
using System;
using System.Collections.Generic;
using UniBizBO.Composition;
using UniinfoNet;

namespace UniBizBO.Services.Part
{
  [HiddenVm]
  public abstract class SPartBase<TData> : PartBase, ISPart, IPart, IHaveWorkDataSet where TData : INotifyPropertyChangedExtend
  {
    private Type dataType;
    private TData selectedData;

    public SPartBase(IContainer container)
      : base(container)
    {
    }

    public Type DataType
    {
      get
      {
        Type dataType = this.dataType;
        return (object) dataType != null ? dataType : (this.dataType = typeof (TData));
      }
    }

    public BindableCollection<TData> Datas { get; } = new BindableCollection<TData>();

    public TData SelectedData
    {
      get => this.selectedData;
      set => this.SetAndNotify<TData>(ref this.selectedData, value, nameof (SelectedData));
    }

    public BindableCollection<TData> SelectedDatas { get; } = new BindableCollection<TData>();

    public override IReadOnlyDictionary<string, TableColumnInfo> OnQueryDataHeaders() => this.App.Sys?.TableColumns?.GetDictionary<TData>();
  }
}
