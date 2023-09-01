// Decompiled with JetBrains decompiler
// Type: UniBizBO.Services.Page.PageContainerBase
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Stylet;
using StyletIoC;
using System.Linq;
using System.Runtime.CompilerServices;

namespace UniBizBO.Services.Page
{
  public abstract class PageContainerBase : UbConductorOne<IPage>, IPageContainer
  {
    protected PageContainerBase(IContainer container)
      : base(container)
    {
    }

    public virtual void AddPage(IPage page) => this.ActivateItem(page);

    public virtual void ClearPage()
    {
      foreach (IPage page in this.Items.ToArray<IPage>())
      {
        if (page is IRequestClose requestClose)
        {
          bool? dialogResult = new bool?();
          requestClose.RequestClose(dialogResult);
        }
      }
    }

    [SpecialName]
    IObservableCollection<IPage> IPageContainer.get_Items() => this.Items;
  }
}
