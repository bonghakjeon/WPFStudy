// Decompiled with JetBrains decompiler
// Type: UniinfoNet.SingletoneBindableBase`1
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

using System;

namespace UniinfoNet
{
  public abstract class SingletoneBindableBase<TItem> : BindableBase where TItem : SingletoneBindableBase<TItem>
  {
    private static object syncLock = new object();
    private static TItem _instance;

    public static TItem Instance => SingletoneBindableBase<TItem>._instance ?? SingletoneBindableBase<TItem>.CreateInstance();

    private static TItem CreateInstance()
    {
      lock (SingletoneBindableBase<TItem>.syncLock)
      {
        if ((object) SingletoneBindableBase<TItem>._instance == null)
        {
          Type type = typeof (TItem);
          SingletoneBindableBase<TItem>._instance = type.GetConstructors().Length == 0 ? (TItem) Activator.CreateInstance(type, true) : throw new InvalidOperationException("싱글톤으로 지정하려는 클래스에 public 생성자가 있습니다.");
        }
        return SingletoneBindableBase<TItem>._instance;
      }
    }
  }
}
