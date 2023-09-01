// Decompiled with JetBrains decompiler
// Type: UniinfoNet.TypeKeyPolyMappingManager
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

using System;
using UniinfoNet.Attributes;

namespace UniinfoNet
{
  public class TypeKeyPolyMappingManager
  {
    public const string SERIALIZE_NAME_TYPE = "4c57a7fb-9cce-4549-bb28-8b7321bceb6b";
    public const string SERIALIZE_NAME_CONTENT = "52d812af-db36-48fa-8b89-62d32fab82b4";
    private static TypeKeyPolyMappingManager _default;
    private TypeKeyPolyGroup groups;

    public static TypeKeyPolyMappingManager Default => TypeKeyPolyMappingManager._default ?? (TypeKeyPolyMappingManager._default = new TypeKeyPolyMappingManager());

    public TypeKeyPolyGroup Groups => this.groups ?? (this.groups = new TypeKeyPolyGroup());

    public bool TryAdd<TGroupClazz, TClazz>() => this.TryAdd(typeof (TGroupClazz), typeof (TClazz));

    public bool TryAdd(Type group, Type type)
    {
      string key = TypeKeyAttribute.GetKey(type);
      if (key == null)
        return false;
      TypeKeyDictionary typeKeyDictionary;
      if (!this.Groups.TryGetValue(group, out typeKeyDictionary))
      {
        typeKeyDictionary = new TypeKeyDictionary();
        this.Groups.Add(group, typeKeyDictionary);
      }
      return typeKeyDictionary.TryAdd(key, type);
    }

    public void Add<TGroupClazz, TClazz>() => this.Add(typeof (TGroupClazz), typeof (TClazz));

    public void Add(Type group, Type type)
    {
      string key = TypeKeyAttribute.GetKey(type);
      if (key == null)
        throw new TypeKeyNotFoundException(type?.Name + "의 키를 찾을 수 없습니다.");
      TypeKeyDictionary typeKeyDictionary;
      if (!this.Groups.TryGetValue(group, out typeKeyDictionary))
      {
        typeKeyDictionary = new TypeKeyDictionary();
        this.Groups.Add(group, typeKeyDictionary);
      }
      if (!typeKeyDictionary.TryAdd(key, type))
        throw new TypeKeyExistException(type?.Name + "의 키는 이미 추가되어 있습니다.");
    }

    public bool TryGetValue(Type Group, string key, out Type value)
    {
      TypeKeyDictionary typeKeyDictionary;
      Type type;
      if (this.Groups.TryGetValue(Group, out typeKeyDictionary) && typeKeyDictionary.TryGetValue(key, out type))
      {
        value = type;
        return true;
      }
      value = (Type) null;
      return false;
    }

    public bool TryGetValue<TGroup>(string key, out Type value) => this.TryGetValue(typeof (TGroup), key, out value);

    public Type GetValue(Type Group, string key) => this.Groups[Group][key];

    public Type GetValue<TGroup>(string key) => this.GetValue(typeof (TGroup), key);
  }
}
