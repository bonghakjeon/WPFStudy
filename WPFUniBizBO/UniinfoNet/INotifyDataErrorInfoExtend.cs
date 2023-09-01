// Decompiled with JetBrains decompiler
// Type: UniinfoNet.INotifyDataErrorInfoExtend
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace UniinfoNet
{
  public interface INotifyDataErrorInfoExtend : INotifyDataErrorInfo
  {
    bool _IsEnableErrorChanged { get; set; }

    void ErrorChanged([CallerMemberName] string name = "");

    void Validate([CallerMemberName] string name = "");
  }
}
