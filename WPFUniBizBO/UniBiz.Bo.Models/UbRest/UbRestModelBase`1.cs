// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UbRest.UbRestModelBase`1
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Text.Json.Serialization;

namespace UniBiz.Bo.Models.UbRest
{
  public abstract class UbRestModelBase<T> : UbRestModelBase where T : UbRestModelBase<T>
  {
    public static TableCodeType DefaultTableCode
    {
      get
      {
        UbRestModelAttribute restModelAttribute = UbRestModelAttribute.Get<T>();
        return restModelAttribute == null ? TableCodeType.Unknown : restModelAttribute.TableCode;
      }
    }

    [JsonIgnore]
    public UbRestModelAttribute DefaultAttributeByInstance => UbRestModelAttribute.Get(this.GetType());

    public static int CommonCodeTypeNum
    {
      get
      {
        UbRestModelAttribute restModelAttribute = UbRestModelAttribute.Get<T>();
        return restModelAttribute == null ? -1 : restModelAttribute.CommonCodeType;
      }
    }
  }
}
