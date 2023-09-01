// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Page.UniSales.Systems.Security.OuterConnAuth.OuterConnAuthLevel
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using System.Collections.Generic;
using UniBiz.Bo.Models.UniBase.OuterConnAuth;

namespace UniBizBO.ViewModels.Page.UniSales.Systems.Security.OuterConnAuth
{
  public class OuterConnAuthLevel : OuterConnAuthView
  {
    private IList<OuterConnAuthView> _Items = (IList<OuterConnAuthView>) new List<OuterConnAuthView>();
    private int _oca_TreeDepth;
    private string _oca_TreeName;

    public IList<OuterConnAuthView> Items
    {
      get => this._Items;
      set
      {
        this._Items = value;
        this.Changed(nameof (Items));
      }
    }

    public int oca_TreeDepth
    {
      get => this._oca_TreeDepth;
      set
      {
        this._oca_TreeDepth = value;
        this.Changed(nameof (oca_TreeDepth));
      }
    }

    public string oca_TreeName
    {
      get => this._oca_TreeName;
      set
      {
        this._oca_TreeName = value;
        this.Changed(nameof (oca_TreeName));
      }
    }
  }
}
