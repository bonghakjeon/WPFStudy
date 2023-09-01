// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniImages.UniTemplates.Common.UniLabelCalcBar
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using UniBizUtil.Util;

namespace UniBiz.Bo.Models.UniImages.UniTemplates.Common
{
  public class UniLabelCalcBar
  {
    private int value;
    private const int CHAR_0 = 48;
    private const int CHAR_9 = 57;
    private const int NUMBER_MAX = 10;
    private const int CHAR_A = 65;
    private const int CHAR_Z = 90;
    private const int CHAR_a = 97;
    private const int CHAR_z = 122;
    private const int CHAR_MAX = 26;

    public UniLabelCalcBar(int value) => this.value = value;

    private static bool isCheckedData(int p_data) => (p_data < 48 || p_data > 57) && (p_data < 65 || p_data > 90) && (p_data < 97 || p_data > 122);

    private static byte AddCalc(int p_or, UniLabelCalcBar p_ref_add_data)
    {
      if (p_or >= 48 && p_or <= 57)
      {
        int num = p_or - 48 + p_ref_add_data.value;
        p_ref_add_data.value = num / 10;
        if (num % 10 < 0)
          --p_ref_add_data.value;
        return num >= 0 ? (byte) (num % 10 + 48) : (byte) (57 + num % 10 + 1);
      }
      if (p_or >= 65 && p_or <= 90)
      {
        int num = p_or - 65 + p_ref_add_data.value;
        p_ref_add_data.value = num / 26;
        if (num % 26 < 0)
          --p_ref_add_data.value;
        return num >= 0 ? (byte) (num % 26 + 65) : (byte) (90 + num % 26 + 1);
      }
      if (p_or < 97 || p_or > 122)
        return (byte) p_or;
      int num1 = p_or - 97 + p_ref_add_data.value;
      p_ref_add_data.value = num1 / 26;
      if (num1 % 26 < 0)
        --p_ref_add_data.value;
      return num1 >= 0 ? (byte) (num1 % 26 + 97) : (byte) (122 + num1 % 26 + 1);
    }

    public static string CalcBarLine(string p_init_data, int p_add_data)
    {
      byte[] bytes = p_init_data.ToBytes(EnumEncodingCodePage.US_ASCII);
      int length = bytes.Length;
      for (UniLabelCalcBar p_ref_add_data = new UniLabelCalcBar(p_add_data); length > 0 && p_ref_add_data.value != 0; --length)
      {
        if (!UniLabelCalcBar.isCheckedData((int) bytes[length - 1]))
          bytes[length - 1] = UniLabelCalcBar.AddCalc((int) bytes[length - 1], p_ref_add_data);
      }
      return bytes.ToString(EnumEncodingCodePage.US_ASCII);
    }
  }
}
