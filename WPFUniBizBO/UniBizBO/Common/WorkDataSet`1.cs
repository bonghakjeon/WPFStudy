// Decompiled with JetBrains decompiler
// Type: UniBizBO.Common.WorkDataSet`1
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using System;
using UniinfoNet;
using UniinfoNet.Extensions;

namespace UniBizBO.Common
{
  public class WorkDataSet<TData> : WorkDataSet where TData : class, INotifyPropertyChangedExtend
  {
    public TData OriginT
    {
      get => this.Origin as TData;
      protected set => this.Origin = (INotifyPropertyChangedExtend) value;
    }

    public TData CurrentT
    {
      get => this.Current as TData;
      protected set => this.Current = (INotifyPropertyChangedExtend) value;
    }

    public event Action<WorkDataSet<TData>> OriginTChanging = _param1 => { };

    public event Action<WorkDataSet<TData>> CurrentTChanging = _param1 => { };

    public event Action<WorkDataSet<TData>> OriginTChanged = _param1 => { };

    public event Action<WorkDataSet<TData>> CurrentTChanged = _param1 => { };

    protected virtual void OnOriginTChanging() => this.OriginTChanging(this);

    protected virtual void OnCurrentTChanging() => this.CurrentTChanging(this);

    protected virtual void OnOriginTChanged()
    {
      this.Changed("OriginT");
      this.OriginTChanged(this);
    }

    protected virtual void OnCurrentTChanged()
    {
      this.Changed("CurrentT");
      this.CurrentTChanged(this);
    }

    protected override void OnOriginChanged()
    {
      base.OnOriginChanged();
      this.OnOriginTChanged();
    }

    protected override void OnCurrentChanged()
    {
      base.OnCurrentChanged();
      this.OnCurrentTChanged();
    }

    public WorkDataSet()
    {
    }

    public WorkDataSet(TData data) => this.Set(data);

    public override string ToString() => string.Format("[C({0})]{1} / [O({2})]{3}", (object) this.CurrentT?.GetType().Name, (object) this.CurrentT, (object) this.OriginT?.GetType().Name, (object) this.OriginT);

    public virtual WorkDataSet<TData> Set(TData data)
    {
      this.CurrentT = data;
      this.OriginT = data.CloneByJson<TData>();
      return this;
    }

    public override void RollBack() => this.CurrentT = this.OriginT.CloneByJson<TData>();

    public override void SetOriginByCurrent() => this.OriginT = this.CurrentT.CloneByJson<TData>();
  }
}
