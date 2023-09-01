// Decompiled with JetBrains decompiler
// Type: UniinfoNet.Attributes.NameTagModel
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

using System;
using System.Collections.Generic;
using System.Linq;

namespace UniinfoNet.Attributes
{
  public class NameTagModel
  {
    private Type targetType;
    private System.Collections.Generic.List<NameTagModel> list;

    public Type TargetType
    {
      get => this.targetType;
      set
      {
        this.targetType = value;
        this.list = (System.Collections.Generic.List<NameTagModel>) null;
      }
    }

    public object Value { get; private set; }

    public string Tag { get; private set; }

    public string Name { get; private set; }

    public string ValueStr
    {
      get
      {
        string tag = this.Tag;
        if (tag != null)
          return tag;
        string name = this.Name;
        if (name != null)
          return name;
        return this.Value?.ToString();
      }
    }

    public System.Collections.Generic.List<NameTagModel> List => this.list ?? (this.list = this.Get());

    private System.Collections.Generic.List<NameTagModel> Get()
    {
      System.Collections.Generic.List<NameTagModel> result = new System.Collections.Generic.List<NameTagModel>();
      if (this.TargetType == (Type) null)
        return result;
      if (this.TargetType.IsEnum)
      {
        foreach (object obj in Enum.GetValues(this.TargetType))
        {
          NameTagModel nameTagModel = new NameTagModel();
          nameTagModel.Value = obj;
          nameTagModel.Name = Enum.GetName(this.TargetType, obj);
          NameTagAttribute[] customAttributes = this.TargetType.GetField(obj.ToString()).GetCustomAttributes(typeof (NameTagAttribute), false) as NameTagAttribute[];
          if (customAttributes.Length != 0)
            nameTagModel.Tag = customAttributes[0].Name;
          result.Add(nameTagModel);
        }
      }
      else if (this.TargetType.IsClass)
        this.TargetType.GetNameTagDic().ToList<KeyValuePair<string, string>>().ForEach((Action<KeyValuePair<string, string>>) (it => result.Add(new NameTagModel()
        {
          Value = (object) it.Key,
          Name = it.Key,
          Tag = it.Value
        })));
      return result;
    }
  }
}
