// Decompiled with JetBrains decompiler
// Type: UniBizBO.Converters.IEnumerableAndFuncConverter
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Pather.CSharp;
using Serilog;
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
  public class IEnumerableAndFuncConverter : IValueConverter
  {
    private static IEnumerableAndFuncConverter instance;
    private Resolver resolver = new Resolver();

    public static IEnumerableAndFuncConverter Instance => IEnumerableAndFuncConverter.instance ?? (IEnumerableAndFuncConverter.instance = new IEnumerableAndFuncConverter());

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      object[] objArray1;
      switch (value)
      {
        case ItemCollection source1:
          objArray1 = source1.Cast<object>().Where<object>((Func<object, bool>) (it => it != CollectionView.NewItemPlaceholder)).ToArray<object>();
          break;
        case IEnumerable source2:
          objArray1 = source2.Cast<object>().ToArray<object>();
          break;
        default:
          objArray1 = (object[]) null;
          break;
      }
      object[] objArray2 = objArray1;
      if (objArray2 == null)
        return (object) null;
      switch (parameter)
      {
        case string name:
          string[] source3 = name.Split(" ");
          IEnumerable<object> source4;
          if (((IEnumerable<string>) source3).Count<string>() == 2)
          {
            name = source3[0];
            string str = "[]." + source3[1];
            objArray2 = CollectionViewGroupUtil.Flatten((IEnumerable<object>) objArray2).ToArray<object>();
            if (string.IsNullOrWhiteSpace(str))
            {
              source4 = (IEnumerable<object>) objArray2;
            }
            else
            {
              string path = "[]." + str;
              try
              {
                source4 = this.resolver.Resolve((object) objArray2, path) is IEnumerable source5 ? source5.Cast<object>() : (IEnumerable<object>) null;
              }
              catch (Exception ex)
              {
                string message = ex.Message;
                Log.Debug(ex, message);
                return (object) double.NaN;
              }
            }
          }
          else
            source4 = (IEnumerable<object>) objArray2;
          double num;
          switch (name)
          {
            case "count":
              num = (double) source4.Count<object>();
              break;
            case "sum":
              num = source4.Select<object, double>((Func<object, double>) (it => System.Convert.ToDouble(it))).Sum();
              break;
            case "avg":
              num = source4.Select<object, double>((Func<object, double>) (it => System.Convert.ToDouble(it))).Average();
              break;
            case "min":
              num = source4.Select<object, double>((Func<object, double>) (it => System.Convert.ToDouble(it))).Min();
              break;
            case "max":
              num = source4.Select<object, double>((Func<object, double>) (it => System.Convert.ToDouble(it))).Max();
              break;
            default:
              num = double.NaN;
              break;
          }
          double d = num;
          if (!double.IsNaN(d))
            return (object) d;
          Type type = ((IEnumerable<object>) objArray2).FirstOrDefault<object>()?.GetType();
          if (type == (Type) null)
            return (object) null;
          return type.GetProperty(name, BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy)?.GetValue((object) null) is Func<IEnumerable, object> func1 ? func1((IEnumerable) objArray2) : (object) d;
        case Func<IEnumerable, object> func2:
          return func2((IEnumerable) objArray2);
        default:
          return (object) null;
      }
    }

    public object ConvertBack(
      object value,
      Type targetType,
      object parameter,
      CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
