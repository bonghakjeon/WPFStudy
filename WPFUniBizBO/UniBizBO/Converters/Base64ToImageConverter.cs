// Decompiled with JetBrains decompiler
// Type: UniBizBO.Converters.Base64ToImageConverter
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using System;
using System.Globalization;
using System.IO;
using System.Windows.Media.Imaging;
using UniBizUtil.Util;
using UniinfoNet.Windows.Wpf;

namespace UniBizBO.Converters
{
  public class Base64ToImageConverter : ValueConverterBase<Base64ToImageConverter>
  {
    public override object Convert(
      object value,
      Type targetType,
      object parameter,
      CultureInfo culture)
    {
      string str1 = value as string;
      if (string.IsNullOrEmpty(str1))
        return (object) null;
      string str2 = ";base64,";
      if (str1.Length <= str2.Length)
        return (object) null;
      if (str1.Contains(str2))
      {
        int num = str1.IndexOf(str2);
        str1 = str1.ToRight(str1.Length - num - str2.Length);
      }
      using (MemoryStream bitmapStream = new MemoryStream(System.Convert.FromBase64String(str1)))
        return (object) BitmapFrame.Create((Stream) bitmapStream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
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
