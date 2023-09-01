// Decompiled with JetBrains decompiler
// Type: UniBizBO.Converters.UseYnToNullBoolConverter
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using System;
using System.Globalization;
using UniinfoNet.Windows.Wpf;

namespace UniBizBO.Converters
{
  public class UseYnToNullBoolConverter : ValueConverterBase<UseYnToNullBoolConverter>
  {
    public override object Convert(
      object value,
      Type targetType,
      object parameter,
      CultureInfo culture)
    {
      switch (value?.ToString().ToLower())
      {
        case "y":
          return (object) true;
        case "n":
          return (object) false;
        default:
          return (object) null;
      }
    }

    public override object ConvertBack(
      object value,
      Type targetType,
      object parameter,
      CultureInfo culture)
    {
      if (value is bool flag)
        return flag ? (object) "Y" : (object) "N";
      bool? nullable = value as bool?;
      if (!nullable.HasValue)
        return (object) null;
      return nullable.GetValueOrDefault() ? (object) "Y" : (object) "N";
    }
  }
}
