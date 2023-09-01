// Decompiled with JetBrains decompiler
// Type: UniBizBO.Common.ObservableDataSet`1
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using System.ComponentModel;
using UniinfoNet;

namespace UniBizBO.Common
{
  public class ObservableDataSet<TData> : WorkDataSet<TData> where TData : class, INotifyPropertyChangedExtend
  {
    private bool isChangedCurrentTProperty;
    private bool isWorking;
    private bool isTag;
    private object tag;
    private bool isChecked;

    public bool IsChangedCurrentTProperty
    {
      get => this.isChangedCurrentTProperty;
      set
      {
        this.isChangedCurrentTProperty = value;
        this.Changed(nameof (IsChangedCurrentTProperty));
      }
    }

    public bool IsWorking
    {
      get => this.isWorking;
      set
      {
        this.isWorking = value;
        this.Changed(nameof (IsWorking));
      }
    }

    public bool IsTag
    {
      get => this.isTag;
      set
      {
        this.isTag = value;
        this.Changed(nameof (IsTag));
      }
    }

    public object Tag
    {
      get => this.tag;
      set
      {
        this.tag = value;
        this.Changed(nameof (Tag));
      }
    }

    public bool IsChecked
    {
      get => this.isChecked;
      set
      {
        this.isChecked = value;
        this.Changed(nameof (IsChecked));
      }
    }

    public override string ToString() => string.Format("[t] {0} [w] {1} [c] {2} / [C({3})]{4} / [O({5})]{6}", (object) this.IsTag, (object) this.IsWorking, (object) this.IsChangedCurrentTProperty, (object) this.CurrentT?.GetType().Name, (object) this.CurrentT, (object) this.OriginT?.GetType().Name, (object) this.OriginT);

    protected override void OnCurrentTChanging()
    {
      base.OnCurrentTChanging();
      if ((object) this.CurrentT == null)
        return;
      this.CurrentT.PropertyChanged -= new PropertyChangedEventHandler(this.CurrentT_PropertyChanged);
    }

    protected override void OnCurrentTChanged()
    {
      base.OnCurrentTChanged();
      if ((object) this.CurrentT == null)
        return;
      this.CurrentT.PropertyChanged += new PropertyChangedEventHandler(this.CurrentT_PropertyChanged);
    }

    private void CurrentT_PropertyChanged(object sender, PropertyChangedEventArgs e) => this.IsChangedCurrentTProperty = true;

    ~ObservableDataSet() => this.CurrentT.PropertyChanged -= new PropertyChangedEventHandler(this.CurrentT_PropertyChanged);

    public ObservableDataSet()
    {
    }

    public ObservableDataSet(TData data)
      : base(data)
    {
    }
  }
}
