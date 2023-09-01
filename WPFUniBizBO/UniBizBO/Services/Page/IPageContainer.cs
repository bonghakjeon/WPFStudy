// Decompiled with JetBrains decompiler
// Type: UniBizBO.Services.Page.IPageContainer
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Stylet;

namespace UniBizBO.Services.Page
{
  public interface IPageContainer
  {
    void AddPage(IPage page);

    void ClearPage();

    IObservableCollection<IPage> Items { get; }
  }
}
