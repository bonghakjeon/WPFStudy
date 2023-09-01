// Decompiled with JetBrains decompiler
// Type: UniinfoNet.SingleDelegateWrapper`1
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

using System;

namespace UniinfoNet
{
  public struct SingleDelegateWrapper<T> where T : Delegate
  {
    private T inner;

    public T Inner => this.inner;

    public bool IsNull => (Delegate) this.Inner == (Delegate) null;

    public SingleDelegateWrapper(T del)
    {
      // ISSUE: variable of a boxed type
      __Boxed<T> local = (object) del;
      if ((local != null ? local.GetInvocationList().Length : 0) > 0)
        throw new Exception("only use single delegate");
      this.inner = del;
    }

    public SingleDelegateWrapper<T> Assign(T del)
    {
      this.Clear();
      // ISSUE: variable of a boxed type
      __Boxed<T> local = (object) del;
      if ((local != null ? local.GetInvocationList().Length : 0) > 0)
        throw new Exception("only use single delegate");
      this.inner = del;
      return this;
    }

    public SingleDelegateWrapper<T> AssignWhenNull(T del)
    {
      if (this.IsNull)
        this.Assign(del);
      return this;
    }

    public SingleDelegateWrapper<T> AssignWhenNotNull(T del)
    {
      if (!this.IsNull)
        this.Assign(del);
      return this;
    }

    public SingleDelegateWrapper<T> Clear()
    {
      this.inner = default (T);
      return this;
    }
  }
}
