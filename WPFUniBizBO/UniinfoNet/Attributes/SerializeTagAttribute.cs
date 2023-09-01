// Decompiled with JetBrains decompiler
// Type: UniinfoNet.Attributes.SerializeTagAttribute
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using UniinfoNet.Extensions;


#nullable enable
namespace UniinfoNet.Attributes
{
  [AttributeUsage(AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
  public class SerializeTagAttribute : BaseAttribute
  {
    public 
    #nullable disable
    object PreMark { get; private set; }

    public string Name { get; private set; }

    public Type UseType { get; private set; }

    public SerializeTagAttribute(object preMark, object name, Type useType = null)
    {
      this.PreMark = preMark;
      this.Name = name?.ToString();
      this.UseType = useType;
    }

    public SerializeTagAttribute(object name, Type useType = null)
    {
      this.Name = name?.ToString();
      this.UseType = useType;
    }

    public static List<SerializeTagMo> GetSerializeModels(Type type)
    {
      if (!type.IsClass)
        return (List<SerializeTagMo>) null;
      List<FieldInfo> list = ((IEnumerable<FieldInfo>) type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)).ToList<FieldInfo>();
      List<SerializeTagMo> result = new List<SerializeTagMo>();
      list.ForEach((Action<FieldInfo>) (f =>
      {
        SerializeTagAttribute customAttribute = f.GetCustomAttribute<SerializeTagAttribute>(false);
        if (customAttribute == null)
          return;
        customAttribute.Action<SerializeTagAttribute>((Action<SerializeTagAttribute>) (fAttr =>
        {
          List<SerializeTagMo> serializeTagMoList = result;
          SerializeTagMo serializeTagMo = new SerializeTagMo();
          serializeTagMo.SerialName = (fAttr.PreMark != null ? fAttr.PreMark?.ToString() + "_" : (string) null) + fAttr.Name;
          serializeTagMo.SerialFieldInfo = f;
          Type type2 = fAttr.UseType;
          if ((object) type2 == null)
            type2 = f.FieldType;
          serializeTagMo.SerialUseType = type2;
          serializeTagMoList.Add(serializeTagMo);
        }));
      }));
      List<IGrouping<string, SerializeTagMo>> checkList = result.GroupBy<SerializeTagMo, string>((Func<SerializeTagMo, string>) (it => it.SerialName)).Where<IGrouping<string, SerializeTagMo>>((Func<IGrouping<string, SerializeTagMo>, bool>) (it => it.Count<SerializeTagMo>() > 1)).ToList<IGrouping<string, SerializeTagMo>>();
      if (checkList.Count > 0)
        new StringBuilder().Action<StringBuilder>((Action<StringBuilder>) (sb =>
        {
          sb.AppendLine("직렬화를 위한 구분값이 중복됩니다.");
          checkList.SelectMany<IGrouping<string, SerializeTagMo>, string>((Func<IGrouping<string, SerializeTagMo>, IEnumerable<string>>) (g => g.ToList<SerializeTagMo>().Select<SerializeTagMo, string>((Func<SerializeTagMo, string>) (it => it.ToString())))).ToList<string>().ForEach((Action<string>) (s => sb.AppendLine(s)));
          throw new SerializeTagException(sb.ToString());
        }));
      return result;
    }

    public static void GetObjectData(
      ISerializable serializable,
      SerializationInfo info,
      StreamingContext context)
    {
      SerializeTagAttribute.GetSerializeModels(serializable.GetType()).ForEach((Action<SerializeTagMo>) (mo => info.AddValue(mo.SerialName, mo.SerialFieldInfo.GetValue((object) serializable), mo.SerialUseType)));
    }

    public static List<SerializeTagExceptionResult> SetObjectData(
      ISerializable serializable,
      SerializationInfo info,
      StreamingContext context)
    {
      List<SerializeTagExceptionResult> result = new List<SerializeTagExceptionResult>();
      SerializeTagAttribute.GetSerializeModels(serializable.GetType()).ForEach((Action<SerializeTagMo>) (mo =>
      {
        try
        {
          mo.SerialFieldInfo.SetValue((object) serializable, info.GetValue(mo.SerialName, mo.SerialUseType));
        }
        catch (Exception ex)
        {
          result.Add(new SerializeTagExceptionResult(ex, mo));
        }
      }));
      return result.Count != 0 ? result : (List<SerializeTagExceptionResult>) null;
    }
  }
}
