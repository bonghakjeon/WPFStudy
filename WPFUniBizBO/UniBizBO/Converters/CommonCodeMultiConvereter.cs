// Decompiled with JetBrains decompiler
// Type: UniBizBO.Converters.CommonCodeMultiConvereter
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using System;
using System.Globalization;
using UniBiz.Bo.Models.UniBase.CommonCode;
using UniinfoNet.Windows.Wpf;

namespace UniBizBO.Converters
{
  public class CommonCodeMultiConvereter : MultiValueConverterBase<CommonCodeMultiConvereter>
  {
    public override object Convert(
      object[] values,
      Type targetType,
      object parameter,
      CultureInfo culture)
    {
      if ((values != null ? values.Length : 0) <= 1)
        return (object) null;
      CommonCodeGroupDic commonCodeGroupDic = values[0] as CommonCodeGroupDic;
      if (!(values[1] is int key))
      {
        int result;
        if (!int.TryParse(values[1]?.ToString(), out result))
          return (object) null;
        key = result;
      }
      if (values.Length <= 2)
        return (object) commonCodeGroupDic[key];
      int result1;
      if (!int.TryParse(values[2].ToString(), out result1))
        return (object) null;
      CommonCodeView commonCodeView = commonCodeGroupDic[key][result1];
      if (!targetType.Equals(typeof (string)))
        return (object) commonCodeView;
      return commonCodeView == null ? (object) null : (object) commonCodeView.ToString();
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
