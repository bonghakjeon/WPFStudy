// Decompiled with JetBrains decompiler
// Type: UniinfoNet.NotifyPropertyChanged
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
  [Obsolete("BindableBase")]
  public class NotifyPropertyChanged : INotifyPropertyChangedExtend, INotifyPropertyChanged
  {
    [JsonIgnore]
    private bool _isPropertyChanged;

    public event PropertyChangedEventHandler PropertyChanged;

    [JsonIgnore]
    public bool _EnablePropertyChanged { get; set; }

    [JsonIgnore]
    public bool _IsPropertyChanged
    {
      get => this._isPropertyChanged;
      set => this._isPropertyChanged = value;
    }

    public void Changed<TProperty>(Expression<Func<TProperty>> property) => this.Changed(property.GetMemberInfo().Name);

    public void Changed([CallerMemberName] string name = "")
    {
      if (this._EnablePropertyChanged)
        return;
      PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
      if (propertyChanged != null)
        propertyChanged((object) this, new PropertyChangedEventArgs(name));
      this._IsPropertyChanged = true;
    }

    public void NotifyOfPropertyChange<TProperty>(Expression<Func<TProperty>> property) => this.Changed<TProperty>(property);

    public void NotifyOfPropertyChange([CallerMemberName] string name = "") => this.Changed(name);

    public bool SetAndNotify<T>(ref T field, T value, [CallerMemberName] string name = "")
    {
      if (EqualityComparer<T>.Default.Equals(field, value))
        return false;
      field = value;
      this.Changed(name);
      return true;
    }
  }
}
