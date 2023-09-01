// Decompiled with JetBrains decompiler
// Type: UniBizBO.Composition.PartMenuInfo
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using StyletIoC;
using System;
using System.Collections.Generic;
using System.Linq;
using UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenuPropAuth;
using UniBizBO.Services.Part;
using UniinfoNet.Clazz;

namespace UniBizBO.Composition
{
  public class PartMenuInfo : MenuInfo<PartMenuInfo>
  {
    private int partTableCode;

    public int PartTableCode
    {
      get => this.partTableCode;
      set
      {
        this.partTableCode = value;
        this.Changed(nameof (PartTableCode));
      }
    }

    public override T GetInstance<T>(InheritClazzFinder finder, IContainer container)
    {
      T instance = base.GetInstance<T>(finder, container);
      if (!(instance is IPart part))
        return instance;
      part.MenuInfo = this;
      return instance;
    }

    public static PartMenuInfo ConvertFrom(ProgMenuPropAuthView menu)
    {
      PartMenuInfo partMenuInfo = new PartMenuInfo();
      partMenuInfo.Title = menu.pmp_ProgTitle;
      partMenuInfo.Name = menu.pmp_PropName;
      partMenuInfo.Code = menu.pmpA_PropCode;
      partMenuInfo.ClazzName = menu.pmp_ProgID;
      partMenuInfo.IconPath = menu.pmp_IconUrl;
      partMenuInfo.PartTableCode = menu.pmp_TableID;
      if (menu.Lt_Detail != null)
      {
        foreach (ProgMenuPropAuthView menu1 in (IEnumerable<ProgMenuPropAuthView>) menu.Lt_Detail)
          partMenuInfo.Children.Add(PartMenuInfo.ConvertFrom(menu1));
      }
      return partMenuInfo;
    }

    public static List<PartMenuInfo> ConvertFrom(IEnumerable<ProgMenuPropAuthView> progMenus) => progMenus.Select<ProgMenuPropAuthView, PartMenuInfo>((Func<ProgMenuPropAuthView, PartMenuInfo>) (it => PartMenuInfo.ConvertFrom(it))).ToList<PartMenuInfo>();
  }
}
