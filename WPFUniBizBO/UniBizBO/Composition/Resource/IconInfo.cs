// Decompiled with JetBrains decompiler
// Type: UniBizBO.Composition.Resource.IconInfo
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using System.IO;
using System.Text.Json.Serialization;
using UniinfoNet;

namespace UniBizBO.Composition.Resource
{
  public class IconInfo : BindableBase
  {
    private Icons baseGroup;
    private string path;
    private string extension;
    private string fullPath;
    private bool isExist;

    public static string[] DefaultExtensions { get; } = new string[3]
    {
      ".png",
      ".jpg",
      ".bmp"
    };

    public IconInfo(Icons baseGroup) => this.BaseGroup = baseGroup;

    public IconInfo(Icons baseGroup, string path)
      : this(baseGroup)
    {
      this.Path = path;
    }

    [JsonIgnore]
    public Icons BaseGroup
    {
      get => this.baseGroup;
      internal set
      {
        this.baseGroup = value;
        this.Changed(nameof (BaseGroup));
        this.IsExist = false;
      }
    }

    public string Path
    {
      get => this.path;
      internal set
      {
        this.path = value?.Replace("|", "");
        this.Changed(nameof (Path));
        this.IsExist = false;
      }
    }

    public string Extension
    {
      get => this.extension;
      protected set
      {
        this.extension = value;
        this.Changed(nameof (Extension));
      }
    }

    [JsonIgnore]
    public string FullPath
    {
      get
      {
        if (this.isExist)
          return this.fullPath;
        return this.BaseGroup?._NotFound?.fullPath;
      }
      protected set
      {
        this.fullPath = value;
        this.Changed(nameof (FullPath));
      }
    }

    [JsonIgnore]
    public bool IsExist
    {
      get => this.isExist;
      protected set
      {
        this.isExist = value;
        this.Changed(nameof (IsExist));
      }
    }

    public void Refresh(string[] extensions = null)
    {
      if (extensions == null)
        extensions = IconInfo.DefaultExtensions;
      this.Extension = (string) null;
      string str = System.IO.Path.Combine(this.BaseGroup.BasePath, this.Path);
      bool flag = false;
      string path = (string) null;
      foreach (string extension in extensions)
      {
        path = str + extension;
        flag = File.Exists(path);
        if (flag)
        {
          this.Extension = extension;
          break;
        }
      }
      this.IsExist = flag;
      this.FullPath = path;
    }

    public override string ToString() => this.FullPath;

    public static explicit operator IconInfo(string path) => new IconInfo((Icons) null, path);
  }
}
