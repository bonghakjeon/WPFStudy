// Decompiled with JetBrains decompiler
// Type: UniinfoNet.Providers.ManifestResourceInfo
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

using System.IO;
using System.Reflection;

namespace UniinfoNet.Providers
{
  public class ManifestResourceInfo
  {
    public Assembly Asm { get; private set; }

    public string FullPath { get; private set; }

    public string Extension { get; private set; }

    public string FolderPath { get; private set; }

    public string Name { get; private set; }

    public ManifestResourceInfo(Assembly asm, string resourcePath)
    {
      this.Asm = asm;
      this.FullPath = resourcePath;
      this.FolderPath = Path.GetDirectoryName(resourcePath);
      this.Extension = Path.GetExtension(resourcePath);
      this.Name = Path.GetFileName(resourcePath);
    }
  }
}
