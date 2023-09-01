// Decompiled with JetBrains decompiler
// Type: UniinfoNet.Extensions.DirectoryInfoExtension
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

using System.Collections.Generic;
using System.IO;

namespace UniinfoNet.Extensions
{
  public static class DirectoryInfoExtension
  {
    public static List<DirectoryInfo> GetListFromRoot(this DirectoryInfo dir)
    {
      List<DirectoryInfo> list = new List<DirectoryInfo>();
      DirectoryInfoExtension.ParentAdd(dir, list);
      return list;
    }

    private static void ParentAdd(DirectoryInfo dir, List<DirectoryInfo> list)
    {
      if (dir.Root.FullName.Equals(dir.FullName))
      {
        list.Add(dir);
      }
      else
      {
        DirectoryInfoExtension.ParentAdd(dir.Parent, list);
        list.Add(dir);
      }
    }
  }
}
