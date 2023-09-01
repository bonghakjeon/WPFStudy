// Decompiled with JetBrains decompiler
// Type: UniBizBO.Common.FlagNotifyPropertyChanged
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using System.ComponentModel;
using System.Text.Json.Serialization;
using UniinfoNet;

namespace UniBizBO.Common
{
  public class FlagNotifyPropertyChanged : BindableBase
  {
    private bool _isChanged;

    [JsonIgnore]
    public bool _IsChanged
    {
      get
      {
        int num = this._isChanged ? 1 : 0;
        if (num == 0)
          return num != 0;
        this._IsChanged = false;
        return num != 0;
      }
      set
      {
        this._isChanged = value;
        this.Changed(nameof (_IsChanged));
      }
    }

    [JsonIgnore]
    public virtual bool _IsDeepChanged { get; }

    protected FlagNotifyPropertyChanged()
    {
      this.PropertyChanged -= new PropertyChangedEventHandler(this.FlagNotifyPropertyChanged_PropertyChanged);
      this.PropertyChanged += new PropertyChangedEventHandler(this.FlagNotifyPropertyChanged_PropertyChanged);
    }

    private void FlagNotifyPropertyChanged_PropertyChanged(
      object sender,
      PropertyChangedEventArgs e)
    {
      if (string.Equals("_IsChanged", e.PropertyName) || string.IsNullOrEmpty(e.PropertyName))
        return;
      this._IsChanged = true;
    }
  }
}
