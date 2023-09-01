// Decompiled with JetBrains decompiler
// Type: UniBizBO.Config.BOConfig
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using ModernWpf.Controls;
using UniinfoNet;

namespace UniBizBO.Config
{
  public class BOConfig : BindableBase
  {
    private NavigationViewPaneDisplayMode _LeftDisplayMode = NavigationViewPaneDisplayMode.LeftCompact;
    private bool _IsRibbonMenuUse = true;
    private string _DefaultThemeName = "NavyTheme";

    public NavigationViewPaneDisplayMode LeftDisplayMode
    {
      get => this._LeftDisplayMode;
      set
      {
        this._LeftDisplayMode = value;
        this.NotifyOfPropertyChange(nameof (LeftDisplayMode));
      }
    }

    public bool IsRibbonMenuUse
    {
      get => this._IsRibbonMenuUse;
      set
      {
        this._IsRibbonMenuUse = value;
        this.NotifyOfPropertyChange(nameof (IsRibbonMenuUse));
      }
    }

    public string DefaultThemeName
    {
      get => this._DefaultThemeName;
      set
      {
        this._DefaultThemeName = value;
        this.NotifyOfPropertyChange(nameof (DefaultThemeName));
      }
    }
  }
}
