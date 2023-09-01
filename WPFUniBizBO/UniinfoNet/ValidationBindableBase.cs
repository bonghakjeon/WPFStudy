// Decompiled with JetBrains decompiler
// Type: UniinfoNet.ValidationBindableBase
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace UniinfoNet
{
  public abstract class ValidationBindableBase : 
    BindableBase,
    INotifyDataErrorInfoExtend,
    INotifyDataErrorInfo
  {
    public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

    [JsonIgnore]
    public bool _IsEnableErrorChanged { get; set; } = true;

    [JsonIgnore]
    public bool _IsAutoValidate { get; set; }

    [JsonIgnore]
    public abstract bool HasErrors { get; }

    public abstract IEnumerable GetErrors(string propertyName);

    public void Validate([CallerMemberName] string name = "") => this.OnValidation(name);

    protected abstract void OnValidation(string name);

    public void ErrorChanged([CallerMemberName] string name = "") => this.OnErrorChanged(name);

    protected virtual void OnErrorChanged(string name)
    {
      if (!this._IsEnableErrorChanged)
        return;
      EventHandler<DataErrorsChangedEventArgs> errorsChanged = this.ErrorsChanged;
      if (errorsChanged == null)
        return;
      errorsChanged((object) this, new DataErrorsChangedEventArgs(name));
    }

    protected override void OnPropertyChanged(string name)
    {
      base.OnPropertyChanged(name);
      if (!this._IsAutoValidate)
        return;
      this.Validate(name);
    }
  }
}
