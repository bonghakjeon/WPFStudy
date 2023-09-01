// Decompiled with JetBrains decompiler
// Type: UniinfoNet.SystemInfo`1
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

namespace UniinfoNet
{
  public class SystemInfo<T> : SystemInfo where T : SystemInfo<T>, new()
  {
    private static T _default;

    public static T Default => SystemInfo<T>._default ?? (SystemInfo<T>._default = new T());
  }
}
