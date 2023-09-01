// Decompiled with JetBrains decompiler
// Type: UniBizBO.Settings.SettingPartBase
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using UniinfoNet;

namespace UniBizBO.Settings
{
  public class SettingPartBase : BindableBase
  {
    [JsonIgnore]
    public SortedDictionary<string, object> Properties { get; protected set; } = new SortedDictionary<string, object>();

    protected void SetProperty(object value, [CallerMemberName] string key = null)
    {
      this.Properties[key] = value;
      this.Changed(key);
    }
  }
}
