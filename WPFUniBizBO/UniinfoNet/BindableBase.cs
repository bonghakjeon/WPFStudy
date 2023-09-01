// Decompiled with JetBrains decompiler
// Type: UniinfoNet.BindableBase
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using UniinfoNet.Extensions;

namespace UniinfoNet
{
  public abstract class BindableBase : INotifyPropertyChangedExtend, INotifyPropertyChanged
  {
    private bool _isPropertyChanged;

    public static event PropertyChangedEventHandler StaticPropertyChanged;

    public static void StaticChanged([CallerMemberName] string name = null)
    {
      PropertyChangedEventHandler staticPropertyChanged = BindableBase.StaticPropertyChanged;
      if (staticPropertyChanged == null)
        return;
      staticPropertyChanged((object) null, new PropertyChangedEventArgs(name));
    }

    public event PropertyChangedEventHandler PropertyChanged;

    [JsonIgnore]
    public bool _EnablePropertyChanged { get; set; } = true;

    [JsonIgnore]
    public bool _IsPropertyChanged
    {
      get => this._isPropertyChanged && !(this._isPropertyChanged = false);
      set => this._isPropertyChanged = value;
    }

    public void Changed<TProperty>(Expression<Func<TProperty>> property) => this.OnPropertyChanged(property.GetMemberInfo().Name);

    public void Changed([CallerMemberName] string name = "") => this.OnPropertyChanged(name);

    public void Changed(params string[] names)
    {
      if ((names != null ? names.Length : 0) <= 0)
        return;
      foreach (string name in names)
        this.OnPropertyChanged(name);
    }

    public void NotifyOfPropertyChange<TProperty>(Expression<Func<TProperty>> property) => this.OnPropertyChanged(property.GetMemberInfo().Name);

    public void NotifyOfPropertyChange([CallerMemberName] string name = "") => this.OnPropertyChanged(name);

    public void NotifyOfPropertyChange(params string[] names)
    {
      if ((names != null ? names.Length : 0) <= 0)
        return;
      foreach (string name in names)
        this.OnPropertyChanged(name);
    }

    public bool SetAndNotify<T>(ref T field, T value, [CallerMemberName] string name = "")
    {
      if (EqualityComparer<T>.Default.Equals(field, value))
        return false;
      field = value;
      this.OnPropertyChanged(name);
      return true;
    }

    protected virtual void OnPropertyChanged(string name)
    {
      if (!this._EnablePropertyChanged)
        return;
      PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
      if (propertyChanged != null)
        propertyChanged((object) this, new PropertyChangedEventArgs(name));
      this._IsPropertyChanged = true;
    }

    public PropertyChangedDisableSection StartPropertyChangedDisableSection() => new PropertyChangedDisableSection(this);
  }
}
