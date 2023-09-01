// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UbRest.UbRestModelAttribute
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using UniinfoNet.Extensions;

namespace UniBiz.Bo.Models.UbRest
{
  [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
  public class UbRestModelAttribute : Attribute
  {
    public string ResourcePath { get; protected set; }

    public object Args { get; set; }

    public object[] ResourcePathArgs { get; set; }

    public TableCodeType TableCode { get; protected set; }

    public string HeaderPath { get; set; }

    public object[] HeaderPathArgs { get; set; }

    public int CommonCodeType { get; set; } = -1;

    public UbRestModelAttribute(string resourcePath, TableCodeType tableCode = TableCodeType.Unknown)
    {
      this.ResourcePath = resourcePath;
      this.TableCode = tableCode;
    }

    public static UbRestModelAttribute Get(Type type) => type.GetAttribute<UbRestModelAttribute>(true);

    public static UbRestModelAttribute Get<T>() => UbRestModelAttribute.Get(typeof (T));

    public static string GetBasePath(Type t) => UbRestModelAttribute.Get(t)?.ResourcePath;

    public static string GetBasePath<T>() => UbRestModelAttribute.GetBasePath(typeof (T));
  }
}
