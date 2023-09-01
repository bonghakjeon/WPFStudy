// Decompiled with JetBrains decompiler
// Type: UniBizBO.Composition.PageMenuInfo
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using StyletIoC;
using System;
using System.Collections.Generic;
using System.Linq;
using UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenuAuth;
using UniBizBO.Services.Page;
using UniinfoNet.Clazz;

namespace UniBizBO.Composition
{
  public class PageMenuInfo : MenuInfo<PageMenuInfo>
  {
    public override T GetInstance<T>(InheritClazzFinder finder, IContainer container)
    {
      T instance = base.GetInstance<T>(finder, container);
      if (!(instance is IPage page))
        return instance;
      page.MenuInfo = this;
      return instance;
    }

    public static PageMenuInfo ConvertFrom(ProgMenuAuthView progMenu)
    {
      PageMenuInfo pageMenuInfo = new PageMenuInfo();
      pageMenuInfo.Title = progMenu.pm_ProgTitle;
      pageMenuInfo.Name = progMenu.pm_MenuName;
      pageMenuInfo.Code = progMenu.pmA_MenuCode;
      pageMenuInfo.ClazzName = progMenu.pm_ProgID;
      pageMenuInfo.IconPath = progMenu.pm_IconUrl;
      pageMenuInfo.Level = progMenu.pm_MenuDepth;
      if (progMenu.Lt_Detail != null)
      {
        foreach (ProgMenuAuthView progMenu1 in (IEnumerable<ProgMenuAuthView>) progMenu.Lt_Detail)
          pageMenuInfo.Children.Add(PageMenuInfo.ConvertFrom(progMenu1));
      }
      return pageMenuInfo;
    }

    public static List<PageMenuInfo> ConvertFrom(IEnumerable<ProgMenuAuthView> progMenus) => progMenus.Select<ProgMenuAuthView, PageMenuInfo>((Func<ProgMenuAuthView, PageMenuInfo>) (it => PageMenuInfo.ConvertFrom(it))).ToList<PageMenuInfo>();
  }
}
