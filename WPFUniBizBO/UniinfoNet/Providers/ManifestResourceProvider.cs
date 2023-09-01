// Decompiled with JetBrains decompiler
// Type: UniinfoNet.Providers.ManifestResourceProvider
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace UniinfoNet.Providers
{
  public class ManifestResourceProvider : BindableBase
  {
    private Assembly[] assemblies;
    private IReadOnlyList<ManifestResourceInfo> resources;

    public Assembly[] Assemblies
    {
      get => this.assemblies;
      set
      {
        this.assemblies = value;
        this.Refresh();
        this.Changed(nameof (Assemblies));
      }
    }

    public IReadOnlyList<ManifestResourceInfo> Resources
    {
      get => this.resources;
      set
      {
        this.resources = value;
        this.Changed(nameof (Resources));
      }
    }

    public ManifestResourceProvider() => this.Assemblies = (Assembly[]) null;

    public ManifestResourceProvider(IEnumerable<Assembly> asms) => this.Assemblies = asms.ToArray<Assembly>();

    private void Refresh()
    {
      List<ManifestResourceInfo> manifestResourceInfoList = new List<ManifestResourceInfo>();
      if (this.assemblies != null)
      {
        foreach (Assembly assembly in this.Assemblies)
        {
          foreach (string manifestResourceName in assembly.GetManifestResourceNames())
            manifestResourceInfoList.Add(new ManifestResourceInfo(assembly, manifestResourceName));
        }
      }
      this.Resources = (IReadOnlyList<ManifestResourceInfo>) manifestResourceInfoList;
    }
  }
}
