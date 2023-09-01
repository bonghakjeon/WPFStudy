// Decompiled with JetBrains decompiler
// Type: UniinfoNet.License.LicenseManager
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;


#nullable enable
namespace UniinfoNet.License
{
  public class LicenseManager : BindableBase
  {
    private 
    #nullable disable
    List<LicenseInfo> licenseInfos;

    public static string LICENSE_FILENAME_ENDWITH { get; } = ".license";

    public List<LicenseInfo> LicenseInfos
    {
      get => this.licenseInfos ?? (this.licenseInfos = new List<LicenseInfo>());
      set => this.licenseInfos = value;
    }

    public void Load(IEnumerable<Assembly> assemblies)
    {
      List<(Assembly, string[])> list = assemblies.Select<Assembly, (Assembly, string[])>((Func<Assembly, (Assembly, string[])>) (asm => (asm, asm.GetManifestResourceNames()))).ToList<(Assembly, string[])>();
      List<LicenseInfo> result = new List<LicenseInfo>();
      list.ForEach((Action<(Assembly, string[])>) (group => ((IEnumerable<string>) group.Item2).Where<string>((Func<string, bool>) (it => it.EndsWith(LicenseManager.LICENSE_FILENAME_ENDWITH))).ToList<string>().ForEach((Action<string>) (fName =>
      {
        using (StreamReader streamReader = new StreamReader(group.asm.GetManifestResourceStream(fName)))
        {
          LicenseInfo m = new LicenseInfo(streamReader.ReadToEnd());
          if (result.Any<LicenseInfo>((Func<LicenseInfo, bool>) (it => string.Equals(it.Title, m.Title))))
            return;
          result.Add(m);
        }
      }))));
      this.LicenseInfos = result.OrderBy<LicenseInfo, string>((Func<LicenseInfo, string>) (it => it.Title)).ToList<LicenseInfo>();
    }

    public async Task LoadAsync(IEnumerable<Assembly> assemblies)
    {
      List<(Assembly, string[])> asmLicenses = assemblies.Select<Assembly, (Assembly, string[])>((Func<Assembly, (Assembly, string[])>) (asm => (asm, asm.GetManifestResourceNames()))).ToList<(Assembly, string[])>();
      this.LicenseInfos = await Task.Factory.StartNew<List<LicenseInfo>>((Func<List<LicenseInfo>>) (() =>
      {
        List<LicenseInfo> result = new List<LicenseInfo>();
        asmLicenses.ForEach((Action<(Assembly, string[])>) (group => ((IEnumerable<string>) group.Item2).Where<string>((Func<string, bool>) (it => it.EndsWith(LicenseManager.LICENSE_FILENAME_ENDWITH))).ToList<string>().ForEach((Action<string>) (fName =>
        {
          using (StreamReader streamReader = new StreamReader(group.asm.GetManifestResourceStream(fName)))
          {
            LicenseInfo m = new LicenseInfo(streamReader.ReadToEnd());
            if (result.Any<LicenseInfo>((Func<LicenseInfo, bool>) (it => string.Equals(it.Title, m.Title))))
              return;
            result.Add(m);
          }
        }))));
        return result.OrderBy<LicenseInfo, string>((Func<LicenseInfo, string>) (it => it.Title)).ToList<LicenseInfo>();
      }));
    }
  }
}
