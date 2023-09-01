// Decompiled with JetBrains decompiler
// Type: UniBizBO.Converters.CommonCodeGroupConverter
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using System;
using System.Globalization;
using UniBiz.Bo.Models.UniBase.CommonCode;
using UniinfoNet.Windows.Wpf;

namespace UniBizBO.Converters
{
  public class CommonCodeGroupConverter : ValueConverterBase<CommonCodeGroupConverter>
  {
    public override object Convert(
      object value,
      Type targetType,
      object parameter,
      CultureInfo culture)
    {
      if (!(value is CommonCodeGroupDic commonCodeGroupDic) || parameter == null)
        return (object) null;
      key = 0;
      int result;
      if (!(parameter is int key) && int.TryParse(parameter?.ToString(), out result))
        key = result;
      return (object) commonCodeGroupDic[key];
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
