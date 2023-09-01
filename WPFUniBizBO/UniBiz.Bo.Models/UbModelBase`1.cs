// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UbModelBase`1
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Reflection;
using System.Text.Json.Serialization;

namespace UniBiz.Bo.Models
{
  public class UbModelBase<T> : UbModelBase where T : UbModelBase<T>
  {
    [JsonIgnore]
    protected readonly string error_message_format = "\n 작 업 : [NAME]\n 파 일 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "\n 메소드 : [METHOD]\n--------------------------------------------------------------------------------------------------\n [REMARK]\n--------------------------------------------------------------------------------------------------";
    [JsonIgnore]
    protected readonly string debug_message_format = "\n [NAME] / " + MethodBase.GetCurrentMethod().ReflectedType.Name + ".[METHOD] | [REMARK]\n--------------------------------------------------------------------------------------------------";

    public static int CommonCodeTypeNum
    {
      get
      {
        UbModelAttribute ubModelAttribute = UbModelAttribute.Get<T>();
        return ubModelAttribute == null ? -1 : ubModelAttribute.CommonCodeType;
      }
    }
  }
}
