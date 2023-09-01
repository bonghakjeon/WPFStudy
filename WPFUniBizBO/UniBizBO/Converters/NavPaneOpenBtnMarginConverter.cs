// Decompiled with JetBrains decompiler
// Type: UniBizBO.Converters.NavPaneOpenBtnMarginConverter
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace UniBizBO.Converters
{
  public class NavPaneOpenBtnMarginConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (value == null)
        return (object) new Thickness();
      return System.Convert.ToBoolean(value) ? (object) new Thickness(240.0, 60.0, 0.0, 0.0) : (object) new Thickness(40.0, 60.0, 0.0, 0.0);
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
