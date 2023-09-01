// Decompiled with JetBrains decompiler
// Type: UniBizBO.Converters.NotNavViewMarginConverter
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using ModernWpf.Controls;
using System;
using System.Globalization;
using System.Windows;
using UniinfoNet.Windows.Wpf;

namespace UniBizBO.Converters
{
  public class NotNavViewMarginConverter : MultiValueConverterBase<NotNavViewMarginConverter>
  {
    public override object Convert(
      object[] values,
      Type targetType,
      object parameter,
      CultureInfo culture)
    {
      if ((values != null ? values.Length : 0) <= 1)
        return (object) null;
      foreach (object obj in values)
      {
        if (obj == null || obj == DependencyProperty.UnsetValue)
          return (object) new Thickness(240.0, 160.0, 0.0, 0.0);
      }
      bool boolean1 = System.Convert.ToBoolean(values[0]);
      NavigationView navigationView = values[1] as NavigationView;
      bool boolean2 = System.Convert.ToBoolean(values[2]);
      return navigationView.PaneDisplayMode == NavigationViewPaneDisplayMode.Left ? (boolean2 ? (boolean1 ? (object) new Thickness(240.0, 160.0, 0.0, 0.0) : (object) new Thickness(240.0, 35.0, 0.0, 0.0)) : (boolean1 ? (object) new Thickness(40.0, 160.0, 0.0, 0.0) : (object) new Thickness(40.0, 35.0, 0.0, 0.0))) : (boolean1 ? (object) new Thickness(40.0, 160.0, 0.0, 0.0) : (object) new Thickness(40.0, 35.0, 0.0, 0.0));
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
