// Decompiled with JetBrains decompiler
// Type: UniinfoNet.INotifyPropertyChangedExtend
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace UniinfoNet
{
  public interface INotifyPropertyChangedExtend : INotifyPropertyChanged
  {
    [JsonIgnore]
    bool _EnablePropertyChanged { get; set; }

    [JsonIgnore]
    bool _IsPropertyChanged { get; set; }

    void Changed([CallerMemberName] string name = "");

    void NotifyOfPropertyChange([CallerMemberName] string name = "");

    bool SetAndNotify<T>(ref T field, T value, [CallerMemberName] string name = "");
  }
}
