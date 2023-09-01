// Decompiled with JetBrains decompiler
// Type: UniBizBO.Services.Part.ParentPartOneBase
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using StyletIoC;
using System;
using System.Linq;
using UniBizBO.Composition;
using UniinfoNet.Extensions;

namespace UniBizBO.Services.Part
{
  [HiddenVm]
  public abstract class ParentPartOneBase : 
    UbConductorOne<IPart>,
    IParentPart,
    IPart,
    IHaveWorkDataSet
  {
    private PartMenuInfo menuInfo;

    public PartMenuInfo MenuInfo
    {
      get => this.menuInfo;
      set => this.SetAndNotify<PartMenuInfo>(ref this.menuInfo, value, nameof (MenuInfo));
    }

    public WorkDataSet WorkData => !(this.Parent is IPartContainer parent) ? (WorkDataSet) null : parent.WorkData;

    public IPartContainer PartContainer
    {
      get
      {
        if (this.Parent is IPartContainer parent1)
          return parent1;
        return !(this.Parent is IPart parent2) ? (IPartContainer) null : parent2.PartContainer;
      }
    }

    protected ParentPartOneBase(IContainer container)
      : base(container)
    {
    }

    protected void RefreshChildren()
    {
      this.Items.Clear();
      this.MenuInfo.Children.ToList<PartMenuInfo>().ForEach((Action<PartMenuInfo>) (menu =>
      {
        IPart instance = menu.GetInstance<IPart>(this.App.ClazzFinder, this.Container);
        if (instance == null)
          return;
        instance.Action<IPart>((Action<IPart>) (part => this.ActivateItem(part)));
      }));
    }

    protected override void OnInitialActivate()
    {
      base.OnInitialActivate();
      this.RefreshChildren();
    }
  }
}
