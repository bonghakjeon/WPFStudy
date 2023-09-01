// Decompiled with JetBrains decompiler
// Type: UniinfoNet.Extensions.ObjectExtension
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading.Tasks;


#nullable enable
namespace UniinfoNet.Extensions
{
  public static class ObjectExtension
  {
    public static 
    #nullable disable
    T Action<T>(this T obj, System.Action<T> action)
    {
      action(obj);
      return obj;
    }

    public static async Task<T> ActionAsync<T>(this T obj, System.Func<T, Task> action)
    {
      await action(obj);
      return (T) obj;
    }

    public static R Func<T, R>(this T obj, System.Func<T, R> func) => func(obj);

    public static async Task<R> FuncAsync<T, R>(this T obj, System.Func<T, Task<R>> func) => await func(obj);

    public static T DefaultAction<T>(this T obj, System.Action action)
    {
      if (EqualityComparer<T>.Default.Equals(obj, default (T)))
        action();
      return obj;
    }

    public static async Task<T> DefaultActionAsync<T>(this T obj, System.Func<Task> action)
    {
      if (EqualityComparer<T>.Default.Equals(obj, default (T)))
        await action();
      return (T) obj;
    }

    public static R DefaultFunc<T, R>(this T obj, System.Func<R> func) => EqualityComparer<T>.Default.Equals(obj, default (T)) ? func() : default (R);

    public static async Task<R> DefaultFuncAsync<T, R>(this T obj, System.Func<Task<R>> func) => EqualityComparer<T>.Default.Equals(obj, default (T)) ? await func() : default (R);

    public static bool EqualsAny<T>(this T obj, params T[] array) => array != null && ((IEnumerable<T>) array).Any<T>((System.Func<T, bool>) (item => item.Equals((object) (T) obj)));

    public static bool EqualsAll<T>(this T obj, params T[] array) => array != null && ((IEnumerable<T>) array).All<T>((System.Func<T, bool>) (item => item.Equals((object) (T) obj)));

    public static T JsonToClass<T>(this string pJson) => JsonSerializer.Deserialize<T>(pJson);

    public static string ToJson<T>(this T obj) => JsonSerializer.Serialize<T>(obj, new JsonSerializerOptions()
    {
      WriteIndented = true
    });

    public static string ToJsonEncoder<T>(this T obj) => JsonSerializer.Serialize<T>(obj, new JsonSerializerOptions()
    {
      WriteIndented = true,
      Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    });

    public static string ToJsonRaw(this object obj) => JsonSerializer.Serialize(obj, obj.GetType(), new JsonSerializerOptions()
    {
      WriteIndented = true
    });

    public static T CloneByJson<T>(this T obj) => JsonSerializer.Deserialize<T>((ReadOnlySpan<byte>) JsonSerializer.SerializeToUtf8Bytes<T>(obj));

    public static TTarget CopyPropertiesFrom<TTarget>(this TTarget obj, object origin) => obj.CopyPropertiesFrom<TTarget>(origin, (Type) null);

    public static TTarget CopyPropertiesFrom<TTarget>(this TTarget obj, object origin, Type ignore)
    {
      PropertyInfo[] array1 = (object) ignore != null ? ((IEnumerable<PropertyInfo>) ignore.GetProperties(BindingFlags.Instance | BindingFlags.Public)).Where<PropertyInfo>((System.Func<PropertyInfo, bool>) (it => it.CanWrite)).ToArray<PropertyInfo>() : (PropertyInfo[]) null;
      PropertyInfo[] array2 = ((IEnumerable<PropertyInfo>) obj.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)).Where<PropertyInfo>((System.Func<PropertyInfo, bool>) (it => it.CanWrite)).ToArray<PropertyInfo>();
      PropertyInfo[] array3 = ((IEnumerable<PropertyInfo>) origin.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)).Where<PropertyInfo>((System.Func<PropertyInfo, bool>) (it => it.CanRead)).ToArray<PropertyInfo>();
      foreach (PropertyInfo propertyInfo1 in array2)
      {
        PropertyInfo prop = propertyInfo1;
        if (array1 == null || !((IEnumerable<PropertyInfo>) array1).Any<PropertyInfo>((System.Func<PropertyInfo, bool>) (it => string.Equals(prop.Name, it.Name))))
        {
          PropertyInfo propertyInfo2 = ((IEnumerable<PropertyInfo>) array3).Where<PropertyInfo>((System.Func<PropertyInfo, bool>) (it => prop.PropertyType.IsAssignableFrom(it.PropertyType))).FirstOrDefault<PropertyInfo>((System.Func<PropertyInfo, bool>) (it => string.Equals(prop.Name, it.Name)));
          if (!(propertyInfo2 == (PropertyInfo) null))
            prop.SetValue((object) obj, propertyInfo2.GetValue(origin));
        }
      }
      return obj;
    }

    public static T SetPropertyWhenNotEqual<T, V>(
      this T obj,
      string propertyName,
      V value,
      bool isThrowable = false)
      where T : class
    {
      Type type = obj.GetType();
      PropertyInfo property = type.GetProperty(propertyName);
      if (property == (PropertyInfo) null)
      {
        if (isThrowable)
          throw new Exception("property(" + propertyName + ") not found source" + type.Name);
        return obj;
      }
      if (!typeof (V).IsEquivalentTo(property.PropertyType))
      {
        if (isThrowable)
          throw new InvalidCastException();
      }
      else if (!EqualityComparer<V>.Default.Equals((V) property.GetValue((object) obj), value))
        property.SetValue((object) obj, (object) value);
      return obj;
    }
  }
}
