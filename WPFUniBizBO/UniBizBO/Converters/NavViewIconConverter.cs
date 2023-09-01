// Decompiled with JetBrains decompiler
// Type: UniBizBO.Converters.NavViewIconConverter
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using System;
using System.Globalization;
using System.IO;
using UniBizBO.Composition;
using UniBizBO.Composition.Resource;
using UniinfoNet.Windows.Wpf;

namespace UniBizBO.Converters
{
  public class NavViewIconConverter : ValueConverterBase<NavViewIconConverter>
  {
    public override object Convert(
      object value,
      Type targetType,
      object parameter,
      CultureInfo culture)
    {
      if (!(value is PageMenuInfo pageMenuInfo))
        return (object) string.Empty;
      string str = pageMenuInfo.IconPath;
      if (pageMenuInfo.Level == 3)
      {
        if (!Uri.IsWellFormedUriString(str, UriKind.Absolute))
        {
          str = Icons.Default.ConvertToLocalFilePath("submenu");
          if (!File.Exists(str))
            str = Icons.Default._NotFound.FullPath;
        }
      }
      else
      {
        if (value is IconInfo iconInfo)
          return (object) iconInfo.FullPath;
        if (string.IsNullOrWhiteSpace(str))
          return (object) Icons.Default._NotFound.FullPath;
        if (!Uri.IsWellFormedUriString(str, UriKind.Absolute))
        {
          str = Icons.Default.ConvertToLocalFilePath(str);
          if (!File.Exists(str))
            str = Icons.Default._NotFound.FullPath;
        }
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
