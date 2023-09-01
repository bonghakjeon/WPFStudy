// Decompiled with JetBrains decompiler
// Type: UniinfoNet.Utils.StringMaskUtil
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


#nullable enable
namespace UniinfoNet.Utils
{
  public class StringMaskUtil
  {
    public static 
    #nullable disable
    string Masking(string s, string mask = "*", int startIndex = 0, int length = 2147483647)
    {
      if (s == null || s.Length == 0 || length == 0)
        return s;
      StringBuilder stringBuilder = new StringBuilder(s.Length);
      if (length < 0)
      {
        startIndex += length;
        length *= -1;
        if (startIndex < 0)
        {
          length += startIndex;
          startIndex = 0;
        }
      }
      if (s.Length <= startIndex)
        return s;
      length = Math.Min(length, s.Length - startIndex);
      for (int index = 0; index < s.Length; ++index)
      {
        char ch = s[index];
        if (index >= startIndex && index < startIndex + length)
          stringBuilder.Append(mask);
        else
          stringBuilder.Append(ch);
      }
      return stringBuilder.ToString();
    }

    public static string Masking(string s, string mask = "*********************", string whiteWords = "-")
    {
      if (s == null || s.Length == 0 || mask == null || mask.Length == 0)
        return s;
      if (whiteWords == null)
        whiteWords = string.Empty;
      StringBuilder stringBuilder = new StringBuilder(s.Length);
      for (int index = 0; index < s.Length; ++index)
      {
        if (index >= mask.Length)
        {
          stringBuilder.Append(s.Substring(index, s.Length - index));
          break;
        }
        char ch = s[index];
        char c = mask[index];
        if (char.IsWhiteSpace(c) || whiteWords.Contains(ch))
          stringBuilder.Append(ch);
        else
          stringBuilder.Append(c);
      }
      return stringBuilder.ToString();
    }

    public class Hangul
    {
      public static int InitialCount => 19;

      public static int MedialCount => 21;

      public static int FinalCount => 28;

      public static int StartIndex => 44032;

      public static int EndIndex => 55203;

      public static int InitialStartIndex => 4352;

      public static int MedialStartIndex => 4449;

      public static int FinalStartIndex => 4519;

      public static string InitialToSingle => "ㄱㄲㄴㄷㄸㄹㅁㅂㅃㅅㅆㅇㅈㅉㅊㅋㅌㅍㅎ";

      public static string MedialToSingle => "ㅏㅐㅑㅒㅓㅔㅕㅖㅗㅘㅙㅚㅛㅜㅝㅞㅟㅠㅡㅢㅣ";

      public static string FinalToSingle => " ㄱㄲㄳㄴㄵㄶㄷㄹㄺㄻㄼㄽㄾㄿㅀㅁㅂㅄㅅㅆㅇㅈㅊㅋㅌㅍㅎ";

      public static bool IsHangul(char s) => (int) s >= StringMaskUtil.Hangul.StartIndex && (int) s <= StringMaskUtil.Hangul.EndIndex;

      public static bool IsOnlyHangul(string s) => s.All<char>((Func<char, bool>) (it => StringMaskUtil.Hangul.IsHangul(it)));

      public static bool HasHangul(string s) => s.Any<char>((Func<char, bool>) (it => StringMaskUtil.Hangul.IsHangul(it)));

      public static IEnumerable<char> Divide(char s, bool isOutputSingleWord = true)
      {
        if (!StringMaskUtil.Hangul.IsHangul(s))
        {
          yield return s;
        }
        else
        {
          int num1 = (int) s - StringMaskUtil.Hangul.StartIndex;
          int index = num1 / (StringMaskUtil.Hangul.MedialCount * StringMaskUtil.Hangul.FinalCount);
          int medial = num1 % (StringMaskUtil.Hangul.MedialCount * StringMaskUtil.Hangul.FinalCount) / StringMaskUtil.Hangul.FinalCount;
          int final = num1 % StringMaskUtil.Hangul.FinalCount;
          if (isOutputSingleWord)
          {
            yield return StringMaskUtil.Hangul.InitialToSingle[index];
            yield return StringMaskUtil.Hangul.MedialToSingle[medial];
            if (final != 0)
              yield return StringMaskUtil.Hangul.FinalToSingle[final];
          }
          else
          {
            int num2 = index + StringMaskUtil.Hangul.InitialStartIndex;
            medial += StringMaskUtil.Hangul.MedialStartIndex;
            final += StringMaskUtil.Hangul.FinalStartIndex;
            yield return (char) num2;
            yield return (char) medial;
            if (final != StringMaskUtil.Hangul.FinalStartIndex)
              yield return (char) final;
          }
        }
      }

      public static string Masking(string s, string defaultMask = "*", int startIndex = 0, int length = 2147483647)
      {
        if (s == null || s.Length == 0 || length == 0)
          return s;
        StringBuilder stringBuilder = new StringBuilder(s.Length);
        if (length < 0)
        {
          startIndex += length;
          length *= -1;
          if (startIndex < 0)
          {
            length += startIndex;
            startIndex = 0;
          }
        }
        if (s.Length <= startIndex)
          return s;
        length = Math.Min(length, s.Length - startIndex);
        for (int index = 0; index < s.Length; ++index)
        {
          char s1 = s[index];
          if (index >= startIndex && index < startIndex + length)
          {
            if (StringMaskUtil.Hangul.IsHangul(s1))
              stringBuilder.Append(StringMaskUtil.Hangul.Divide(s1).FirstOrDefault<char>());
            else
              stringBuilder.Append(defaultMask);
          }
          else
            stringBuilder.Append(s1);
        }
        return stringBuilder.ToString();
      }
    }
  }
}
