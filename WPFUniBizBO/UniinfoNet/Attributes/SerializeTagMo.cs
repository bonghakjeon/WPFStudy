// Decompiled with JetBrains decompiler
// Type: UniinfoNet.Attributes.SerializeTagMo
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

using System;
using System.Reflection;

namespace UniinfoNet.Attributes
{
  public class SerializeTagMo
  {
    public string SerialName { get; set; }

    public FieldInfo SerialFieldInfo { get; set; }

    public Type SerialUseType { get; set; }

    public override string ToString() => "<" + this.SerialFieldInfo.DeclaringType.FullName + ">\t (" + this.SerialUseType.Name + ")\t " + this.SerialFieldInfo.Name + "\t : " + this.SerialName + " ";
  }
}
