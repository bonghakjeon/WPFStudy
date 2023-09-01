// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UbModelAttribute
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using UniinfoNet.Extensions;

namespace UniBiz.Bo.Models
{
  [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
  public class UbModelAttribute : Attribute
  {
    public static readonly string QUERY_END = ";";

    public string ResourcePath { get; protected set; }

    public object Args { get; set; }

    public object[] ResourcePathArgs { get; set; }

    public TableCodeType TableCode { get; protected set; }

    public string HeaderPath { get; set; }

    public object[] HeaderPathArgs { get; set; }

    public int CommonCodeType { get; set; } = -1;

    public UbModelAttribute(string resourcePath, TableCodeType tableCode = TableCodeType.Unknown)
    {
      this.ResourcePath = resourcePath;
      this.TableCode = tableCode;
    }

    public static UbModelAttribute Get(Type type) => type.GetAttribute<UbModelAttribute>(true);

    public static UbModelAttribute Get<T>() => UbModelAttribute.Get(typeof (T));

    public static string GetBasePath(Type t) => UbModelAttribute.Get(t)?.ResourcePath;

    public static string GetBasePath<T>() => UbModelAttribute.GetBasePath(typeof (T));
  }
}
