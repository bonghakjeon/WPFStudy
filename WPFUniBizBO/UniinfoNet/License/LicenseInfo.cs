// Decompiled with JetBrains decompiler
// Type: UniinfoNet.License.LicenseInfo
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

using System;
using System.Collections.Generic;
using System.Linq;

namespace UniinfoNet.License
{
  public class LicenseInfo : BindableBase
  {
    private string title;
    private string plink;
    private string llink;
    private string copyright;
    private string summary;
    private string content;

    public static string CONTENT_SEPARATOR { get; } = Environment.NewLine + Environment.NewLine;

    public string Title
    {
      get => this.title;
      set
      {
        this.title = value;
        this.Changed(nameof (Title));
      }
    }

    public string Plink
    {
      get => this.plink;
      set
      {
        this.plink = value;
        this.Changed(nameof (Plink));
      }
    }

    public string Llink
    {
      get => this.llink;
      set
      {
        this.llink = value;
        this.Changed(nameof (Llink));
      }
    }

    public string Copyright
    {
      get => this.copyright;
      set
      {
        this.copyright = value;
        this.Changed(nameof (Copyright));
      }
    }

    public string Summary
    {
      get => this.summary;
      set
      {
        this.summary = value;
        this.Changed(nameof (Summary));
      }
    }

    public string Content
    {
      get => this.content;
      set
      {
        this.content = value;
        this.Changed(nameof (Content));
      }
    }

    public LicenseInfo()
    {
    }

    public LicenseInfo(string txt) => this.Load(txt);

    public LicenseInfo Load(string txt)
    {
      this.Title = this.Plink = this.Llink = this.Summary = this.Content = (string) null;
      int length = txt.IndexOf(LicenseInfo.CONTENT_SEPARATOR);
      if (length < 0)
        return this;
      string str1 = txt.Substring(0, length);
      this.Content = txt.Substring(length + LicenseInfo.CONTENT_SEPARATOR.Length);
      ((IEnumerable<string>) str1.Split(new string[1]
      {
        Environment.NewLine
      }, StringSplitOptions.RemoveEmptyEntries)).ToList<string>().ForEach((Action<string>) (line =>
      {
        if (!line.Contains("="))
          return;
        string[] strArray = line.Split('=');
        string str2 = strArray[0];
        string str3 = string.IsNullOrWhiteSpace(strArray[1]) ? (string) null : strArray[1];
        switch (str2)
        {
          case "Title":
            this.Title = str3;
            break;
          case "Plink":
            this.Plink = str3;
            break;
          case "Llink":
            this.Llink = str3;
            break;
          case "Summary":
            this.Summary = str3;
            break;
          case "Copyright":
            this.Copyright = str3;
            break;
        }
      }));
      return this;
    }
  }
}
