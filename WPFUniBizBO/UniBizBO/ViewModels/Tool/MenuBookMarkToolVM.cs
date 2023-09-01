// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Tool.MenuBookMarkToolVM
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Stylet;
using StyletIoC;
using System;
using System.Collections.Generic;
using UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenuBookMark;
using UniBizBO.Composition;
using UniBizBO.Services;
using UniBizBO.Services.Page;
using UniBizBO.ViewModels.Message;
using UniinfoNet.Extensions;
using UniinfoNet.Windows.Wpf.Commands;

namespace UniBizBO.ViewModels.Tool
{
  public class MenuBookMarkToolVM : UbScreen
  {
    private BindableCollection<ProgMenuBookMarkView> _SelectedBookMarkItem = new BindableCollection<ProgMenuBookMarkView>();

    public BindableCollection<ProgMenuBookMarkView> SelectedBookMarkItem
    {
      get => this._SelectedBookMarkItem;
      private set
      {
        this._SelectedBookMarkItem = value;
        this.NotifyOfPropertyChange(nameof (SelectedBookMarkItem));
      }
    }

    public MenuBookMarkToolVM(IContainer container)
      : base(container)
    {
    }

    protected override void OnInitialActivate() => base.OnInitialActivate();

    protected override void OnActivate() => base.OnActivate();

    protected override void OnViewLoaded() => base.OnViewLoaded();

    public WpfCommand<ProgMenuBookMarkView> CmdSelecBookMark => this.Cmds.GetValueOrInsert<NotifyCommand, WpfCommand<ProgMenuBookMarkView>>((Func<WpfCommand<ProgMenuBookMarkView>>) (() => new WpfCommand<ProgMenuBookMarkView>().ApplyExecute<ProgMenuBookMarkView>(new Action<ProgMenuBookMarkView>(this.SelecBookMark))), nameof (CmdSelecBookMark));

    public void SelecBookMark(ProgMenuBookMarkView menu)
    {
      if (menu.pmbm_IsViewTypeView)
      {
        PageMenuInfo pValue;
        if (!this.App.User.PageMenuDic.TryGetValue(menu.lv3_pm_MenuCode, out pValue))
          return;
        Type implementType = pValue.GetImplementType(this.App.ClazzFinder);
        if (implementType == (Type) null || !typeof (IParentPage).IsAssignableFrom(implementType))
          return;
        IParentPage parentPage = this.Container.Get<IParentPage>(implementType.FullName);
        parentPage.MenuInfo = pValue;
        IEventAggregator eventAggregator = this.EventAggregator;
        OpenPageMsg message = new OpenPageMsg((IUbVM) this);
        message.Page = (IPage) parentPage;
        message.IsMenuBookMarkSelected = true;
        message.Lv4MenuBookMarkCode = menu.pmbm_MenuCode;
        string[] strArray = Array.Empty<string>();
        eventAggregator.PublishOnUIThread((object) message, strArray);
      }
      else
      {
        if (menu.pmbm_Depth != 1)
          return;
        this.SelectedBookMarkItem.Clear();
        this.SelectedBookMarkItem.AddRange((IEnumerable<ProgMenuBookMarkView>) menu.Lt_Detail);
      }
    }
  }
}
