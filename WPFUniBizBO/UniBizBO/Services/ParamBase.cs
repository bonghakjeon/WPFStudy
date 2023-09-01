// Decompiled with JetBrains decompiler
// Type: UniBizBO.Services.ParamBase`1
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.Json;
using UniinfoNet.Extensions;

namespace UniBizBO.Services
{
  [HiddenVm]
  public class ParamBase<TParam> : ParamBase where TParam : ParamBase<TParam>
  {
    public static TParam Create(ParamBase param, IDictionary<string, object> arg)
    {
      TParam result = JsonSerializer.Deserialize<TParam>(JsonSerializer.Serialize((object) param, param.GetType()), new JsonSerializerOptions()
      {
        MaxDepth = 5
      });
      Type type = typeof (TParam);
      if (arg != null)
      {
        foreach (KeyValuePair<string, object> keyValuePair in (IEnumerable<KeyValuePair<string, object>>) arg)
        {
          KeyValuePair<string, object> kv = keyValuePair;
          PropertyInfo property = type.GetProperty(kv.Key, BindingFlags.Instance | BindingFlags.Public);
          if ((object) property != null)
            property.Action<PropertyInfo>((Action<PropertyInfo>) (prop =>
            {
              if (!prop.CanWrite)
                return;
              try
              {
                prop.SetValue((object) result, kv.Value);
              }
              catch (Exception ex)
              {
              }
            }));
        }
      }
      return result;
    }
  }
}
