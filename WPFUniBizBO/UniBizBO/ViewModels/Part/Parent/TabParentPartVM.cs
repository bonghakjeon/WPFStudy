// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Part.Parent.TabParentPartVM
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using StyletIoC;
using System.Linq;
using UniBizBO.Services.Part;
using UniBizBO.ViewModels.Message;

namespace UniBizBO.ViewModels.Part.Parent
{
  public class TabParentPartVM : ParentPartOneBase
  {
    public TabParentPartVM(IContainer container)
      : base(container)
    {
    }

    protected override void OnInitialActivate()
    {
      base.OnInitialActivate();
      if (this.Items.Count <= 0)
        return;
      this.ActivateItem(this.Items.First<IPart>());
    }

    public void PartAppWinMessage(AppWinMsg p_AppWinMsg)
    {
      if (!this.IsActive || this.ActiveItem == null)
        return;
      ((PartBase) this.ActiveItem).OnReceiveAppWinMessageAsync(p_AppWinMsg);
    }
  }
}
