// Decompiled with JetBrains decompiler
// Type: UniBizBO.Converters.ImagePathConverter
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Media.Imaging;
using UniBizBO.Composition.Resource;
using UniinfoNet.Windows.Wpf;

namespace UniBizBO.Converters
{
  public class ImagePathConverter : ValueConverterBase<ImagePathConverter>
  {
    public override object Convert(
      object value,
      Type targetType,
      object parameter,
      CultureInfo culture)
    {
      string uriString = value as string;
      if (string.IsNullOrWhiteSpace(uriString))
        return (object) Icons.Default._NotFound.FullPath;
      if (uriString == null)
        return DependencyProperty.UnsetValue;
      Uri uri = new Uri(uriString);
      BitmapImage bitmapImage = new BitmapImage();
      bitmapImage.BeginInit();
      bitmapImage.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
      bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
      bitmapImage.UriSource = uri;
      bitmapImage.EndInit();
      return (object) bitmapImage;
    }

    public override object ConvertBack(
      object value,
      Type targetType,
      object parameter,
      CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
