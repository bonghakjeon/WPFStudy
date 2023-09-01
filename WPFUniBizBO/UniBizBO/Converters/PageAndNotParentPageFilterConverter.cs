// Decompiled with JetBrains decompiler
// Type: UniBizBO.Converters.PageAndNotParentPageFilterConverter
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using System;
using System.Globalization;
using System.Windows.Data;
using UniBizBO.Services.Page;

namespace UniBizBO.Converters
{
  public class PageAndNotParentPageFilterConverter : IValueConverter
  {
    private static PageAndNotParentPageFilterConverter instance;

    public static PageAndNotParentPageFilterConverter Instance => PageAndNotParentPageFilterConverter.instance ?? (PageAndNotParentPageFilterConverter.instance = new PageAndNotParentPageFilterConverter());

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => !(value as IPage is IParentPage) ? value : (object) null;

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
