// Decompiled with JetBrains decompiler
// Type: UniBizBO.Common.Theme
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using System;
using System.Linq;
using System.Windows;

namespace UniBizBO.Common
{
  public class Theme
  {
    public string Name { get; set; }

    public string FileName { get; set; }

    public void SaveTheme(string themeName)
    {
    }

    public void LoadTheme(string themeName)
    {
      ResourceDictionary resourceDictionary1 = new ResourceDictionary();
      resourceDictionary1.Source = new Uri("Themes/" + themeName + ".xaml", UriKind.Relative);
      string removeThemeName = themeName.Equals("NavyTheme") ? "BrownTheme.xaml" : "NavyTheme.xaml";
      ResourceDictionary resourceDictionary2 = Application.Current.Resources.MergedDictionaries.FirstOrDefault<ResourceDictionary>((Func<ResourceDictionary, bool>) (d =>
      {
        Uri source = d.Source;
        return (object) source != null && source.OriginalString.EndsWith(removeThemeName);
      }));
      if (resourceDictionary2 != null)
        Application.Current.Resources.MergedDictionaries.Remove(resourceDictionary2);
      Application.Current.Resources.MergedDictionaries.Add(resourceDictionary1);
    }
  }
}
