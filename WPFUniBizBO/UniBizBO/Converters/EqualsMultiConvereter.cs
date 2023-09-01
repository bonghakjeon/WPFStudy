// Decompiled with JetBrains decompiler
// Type: UniBizBO.Converters.EqualsMultiConvereter
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using System;
using System.Globalization;
using UniinfoNet.Windows.Wpf;

namespace UniBizBO.Converters
{
  public class EqualsMultiConvereter : MultiValueConverterBase<EqualsMultiConvereter>
  {
    public override object Convert(
      object[] values,
      Type targetType,
      object parameter,
      CultureInfo culture)
    {
      if ((values != null ? values.Length : 0) <= 1)
        return (object) null;
      object obj1 = values[0];
      object obj2 = values[1];
      return obj1 == null || obj2 == null ? (object) null : (object) obj1.ToString().Equals(obj2.ToString());
    }

    public override object[] ConvertBack(
      object value,
      Type[] targetTypes,
      object parameter,
      CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
