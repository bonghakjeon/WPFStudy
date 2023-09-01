// Decompiled with JetBrains decompiler
// Type: UniBizBO.Services.ObservableDataSet`1
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using System.ComponentModel;
using UniinfoNet;

namespace UniBizBO.Services
{
  public class ObservableDataSet<TData> : WorkDataSet<TData> where TData : class, INotifyPropertyChangedExtend
  {
    private bool isChangedCurrentTProperty;
    private bool isTag;
    private object tag;

    public bool IsChangedCurrentTProperty
    {
      get => this.isChangedCurrentTProperty;
      set
      {
        this.isChangedCurrentTProperty = value;
        this.Changed(nameof (IsChangedCurrentTProperty));
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

    protected override void OnCurrentTChanging()
    {
      base.OnCurrentTChanging();
      this.CurrentT.PropertyChanged -= new PropertyChangedEventHandler(this.CurrentT_PropertyChanged);
    }

    protected override void OnCurrentTChanged()
    {
      base.OnCurrentTChanged();
      this.CurrentT.PropertyChanged += new PropertyChangedEventHandler(this.CurrentT_PropertyChanged);
    }

    private void CurrentT_PropertyChanged(object sender, PropertyChangedEventArgs e) => this.IsChangedCurrentTProperty = true;

    public ObservableDataSet()
    {
    }

    public ObservableDataSet(TData data)
      : base(data)
    {
    }
  }
}
