// Decompiled with JetBrains decompiler
// Type: UniBizBO.Services.DefaultFuncBase
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using UniinfoNet;

namespace UniBizBO.Services
{
  public abstract class DefaultFuncBase : BindableBase
  {
    public DefaultFuncBase(string name) => this.Name = name;

    public string Name { get; }

    public override bool Equals(object obj) => obj is DefaultFuncBase defaultFuncBase ? this.GetHashCode() == defaultFuncBase.GetHashCode() : base.Equals(obj);

    public override int GetHashCode() => this.Name.GetHashCode();

    public override string ToString() => "[" + this.Name + "]";
  }
}
