// Decompiled with JetBrains decompiler
// Type: UniBizBO.Composition.UserManager
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Stylet;
using StyletIoC;
using System;
using System.Collections.Generic;
using System.Linq;
using UniBiz.Bo.Models;
using UniBiz.Bo.Models.UniBase.Employee.Employee;
using UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenuBookMark;
using UniinfoNet;
using UniinfoNet.Extensions;

namespace UniBizBO.Composition
{
  public class UserManager : BindableBase
  {
    private BindableCollection<PageMenuInfo> _PageMenus = new BindableCollection<PageMenuInfo>();
    private BindableCollection<PartMenuInfo> _PartMenus = new BindableCollection<PartMenuInfo>();
    private BindableCollection<ProgMenuBookMarkView> _MenuBookMarkList = new BindableCollection<ProgMenuBookMarkView>();
    public PageMenuInfoDic PageMenuDic = new PageMenuInfoDic();

    [Inject]
    public UserInfo User { get; private set; }

    public List<PageMenuInfo> DebugPageMenus { get; set; }

    public BindableCollection<PageMenuInfo> PageMenus
    {
      get => this._PageMenus;
      private set
      {
        this._PageMenus = value;
        this.NotifyOfPropertyChange(nameof (PageMenus));
      }
    }

    public List<PartMenuInfo> DebugPartMenus { get; set; }

    public BindableCollection<PartMenuInfo> PartMenus
    {
      get => this._PartMenus;
      private set
      {
        this._PartMenus = value;
        this.NotifyOfPropertyChange(nameof (PartMenus));
      }
    }

    public BindableCollection<ProgMenuBookMarkView> MenuBookMarkList
    {
      get => this._MenuBookMarkList;
      private set
      {
        this._MenuBookMarkList = value;
        this.NotifyOfPropertyChange(nameof (MenuBookMarkList));
      }
    }

    public void SetUser(EmployeeView employee)
    {
      this.User.SetSource(employee);
      this.RefreshMenu();
    }

    public void RefreshMenu()
    {
      this.PageMenus = new BindableCollection<PageMenuInfo>();
      this.PartMenus = new BindableCollection<PartMenuInfo>();
      if (this.DebugPageMenus != null)
        this.PageMenus.AddRange((IEnumerable<PageMenuInfo>) this.DebugPageMenus);
      if (this.DebugPartMenus != null)
        this.PartMenus.AddRange((IEnumerable<PartMenuInfo>) this.DebugPartMenus);
      UserInfo user1 = this.User;
      if (user1 != null)
        user1.Action<UserInfo>((Action<UserInfo>) (it => this.PageMenus.AddRange((IEnumerable<PageMenuInfo>) it.GetPageMenuInfos())));
      UserInfo user2 = this.User;
      if (user2 != null)
        user2.Action<UserInfo>((Action<UserInfo>) (it => this.PartMenus.AddRange((IEnumerable<PartMenuInfo>) it.GetPartMenuInfos())));
      this.PageMenuDic.AddRangeOrigin((IList<PageMenuInfo>) this.PageMenus);
      this.MenuBookMarkList = new BindableCollection<ProgMenuBookMarkView>();
      this.MenuBookMarkList.AddRange((IEnumerable<ProgMenuBookMarkView>) this.User.LogInPackInfo.Lt_BookMark.ToList<ProgMenuBookMarkView>());
    }

    public PartMenuInfo GetPartsBaseMenuInfo(TableCodeType tableCode) => this.PartMenus.FirstOrDefault<PartMenuInfo>((Func<PartMenuInfo, bool>) (it => (TableCodeType) it.PartTableCode == tableCode));
  }
}
