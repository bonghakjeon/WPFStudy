// Decompiled with JetBrains decompiler
// Type: UniBizBO.Converters.IconPathConverter
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using System;
using System.Globalization;
using System.IO;
using UniBizBO.Composition.Resource;
using UniinfoNet.Windows.Wpf;

namespace UniBizBO.Converters
{
  public class IconPathConverter : ValueConverterBase<IconPathConverter>
  {
    public override object Convert(
      object value,
      Type targetType,
      object parameter,
      CultureInfo culture)
    {
      if (parameter != null)
        value = (object) parameter.ToString();
      if (value is IconInfo iconInfo)
        return (object) iconInfo.FullPath;
      string str = value as string;
      if (string.IsNullOrWhiteSpace(str))
        return (object) Icons.Default._NotFound.FullPath;
      if (!Uri.IsWellFormedUriString(str, UriKind.Absolute))
      {
        str = Icons.Default.ConvertToLocalFilePath(str);
        if (!File.Exists(str))
          str = Icons.Default._NotFound.FullPath;
      }
      return (object) str;
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
