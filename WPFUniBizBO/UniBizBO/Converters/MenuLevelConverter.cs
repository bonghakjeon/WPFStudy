// Decompiled with JetBrains decompiler
// Type: UniBizBO.Converters.MenuLevelConverter
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Stylet;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Data;
using UniBizBO.Composition;

namespace UniBizBO.Converters
{
  public class MenuLevelConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      BindableCollection<PageMenuInfo> bindableCollection1 = value as BindableCollection<PageMenuInfo>;
      BindableCollection<PageMenuInfo> bindableCollection2 = new BindableCollection<PageMenuInfo>();
      bool flag = false;
      foreach (PageMenuInfo pageMenuInfo in (Collection<PageMenuInfo>) bindableCollection1)
      {
        if (pageMenuInfo.Level == 2)
        {
          flag = true;
          bindableCollection2.AddRange((IEnumerable<PageMenuInfo>) pageMenuInfo.Children);
        }
        if (pageMenuInfo.Level > 3)
          return (object) null;
      }
      return !flag ? value : (object) bindableCollection2;
    }

    public object ConvertBack(
      object value,
      Type targetType,
      object parameter,
      CultureInfo culture)
    {
      return (object) null;
    }
  }
}
