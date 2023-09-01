// Decompiled with JetBrains decompiler
// Type: UniBizBO.Converters.IEnumerbleBindingPathFuncConverter
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Pather.CSharp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Data;
using UniinfoNet.Windows.Wpf.Utils;

namespace UniBizBO.Converters
{
  public class IEnumerbleBindingPathFuncConverter : IMultiValueConverter
  {
    private static IEnumerbleBindingPathFuncConverter instance;
    private Resolver resolver = new Resolver();

    public static IEnumerbleBindingPathFuncConverter Instance => IEnumerbleBindingPathFuncConverter.instance ?? (IEnumerbleBindingPathFuncConverter.instance = new IEnumerbleBindingPathFuncConverter());

    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
      if ((values != null ? ((IEnumerable<object>) values).Count<object>() : 0) != 3)
        throw new InvalidOperationException("값 배열의 요소 수는 반드시 3개여야 합니다.");
      object[] objArray;
      switch (values[0])
      {
        case ItemCollection source1:
          objArray = source1.Cast<object>().Where<object>((Func<object, bool>) (it => it != CollectionView.NewItemPlaceholder)).ToArray<object>();
          break;
        case IEnumerable source2:
          objArray = source2.Cast<object>().ToArray<object>();
          break;
        default:
          objArray = (object[]) null;
          break;
      }
      object[] origin = objArray;
      string str = values[1]?.ToString();
      if (origin == null)
        return (object) null;
      object[] array = CollectionViewGroupUtil.Flatten((IEnumerable<object>) origin).ToArray<object>();
      IEnumerable<object> source3;
      if (string.IsNullOrWhiteSpace(str))
      {
        source3 = (IEnumerable<object>) array;
      }
      else
      {
        string path = "[]." + str;
        try
        {
          source3 = this.resolver.Resolve((object) array, path) is IEnumerable source4 ? source4.Cast<object>() : (IEnumerable<object>) null;
        }
        catch (Exception ex)
        {
          return (object) double.NaN;
        }
      }
      if (values[2] is string name)
      {
        double num;
        switch (name)
        {
          case "count":
            num = (double) source3.Count<object>();
            break;
          case "sum":
            num = source3.Select<object, double>((Func<object, double>) (it => System.Convert.ToDouble(it))).Sum();
            break;
          case "avg":
            num = source3.Select<object, double>((Func<object, double>) (it => System.Convert.ToDouble(it))).Average();
            break;
          case "min":
            num = source3.Select<object, double>((Func<object, double>) (it => System.Convert.ToDouble(it))).Min();
            break;
          case "max":
            num = source3.Select<object, double>((Func<object, double>) (it => System.Convert.ToDouble(it))).Max();
            break;
          default:
            num = double.NaN;
            break;
        }
        double d = num;
        if (!double.IsNaN(d))
          return (object) d;
        Type type = source3.FirstOrDefault<object>()?.GetType();
        if (type == (Type) null)
          return (object) null;
        return type.GetProperty(name, BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy)?.GetValue((object) null) is Func<IEnumerable, object> func ? func((IEnumerable) source3) : (object) d;
      }
      return values[2] is Func<IEnumerable, object> func1 ? func1((IEnumerable) source3) : (object) null;
    }

    public object[] ConvertBack(
      object value,
      Type[] targetTypes,
      object parameter,
      CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
