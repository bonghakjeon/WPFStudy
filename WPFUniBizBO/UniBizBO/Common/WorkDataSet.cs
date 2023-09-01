// Decompiled with JetBrains decompiler
// Type: UniBizBO.Common.WorkDataSet
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using System;
using UniinfoNet;

namespace UniBizBO.Common
{
  public abstract class WorkDataSet : BindableBase
  {
    private INotifyPropertyChangedExtend origin;
    private INotifyPropertyChangedExtend current;

    public INotifyPropertyChangedExtend Origin
    {
      get => this.origin;
      protected set
      {
        if (this.origin == value)
          return;
        this.origin = value;
        this.OnOriginChanged();
      }
    }

    public INotifyPropertyChangedExtend Current
    {
      get => this.current;
      protected set
      {
        if (this.current == value)
          return;
        this.current = value;
        this.OnCurrentChanged();
      }
    }

    public event Action<WorkDataSet> OriginChanged = _param1 => { };

    public event Action<WorkDataSet> CurrentChanged = _param1 => { };

    public override string ToString() => string.Format("[C]{0} / [O]{1}", (object) this.Current, (object) this.Origin);

    protected virtual void OnOriginChanged()
    {
      this.Changed("Origin");
      this.OriginChanged(this);
    }

    protected virtual void OnCurrentChanged()
    {
      this.Changed("Current");
      this.CurrentChanged(this);
    }

    public abstract void RollBack();

    public abstract void SetOriginByCurrent();
  }
}
