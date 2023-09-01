// Decompiled with JetBrains decompiler
// Type: UniBizBO.Settings.UiSettingPart
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using UniinfoNet.Extensions;

namespace UniBizBO.Settings
{
  public class UiSettingPart : SettingPartBase
  {
    public bool MainMenuAutoFolding
    {
      get => this.Properties.GetValueOrInsert<object, bool>(true, nameof (MainMenuAutoFolding));
      set => this.SetProperty((object) value, nameof (MainMenuAutoFolding));
    }

    public bool MainMenuIsOpen
    {
      get => this.Properties.GetValueOrInsert<object, bool>(true, nameof (MainMenuIsOpen));
      set => this.SetProperty((object) value, nameof (MainMenuIsOpen));
    }

    public bool MainMenuIsOverlayMode
    {
      get => this.Properties.GetValueOrInsert<object, bool>(true, nameof (MainMenuIsOverlayMode));
      set => this.SetProperty((object) value, nameof (MainMenuIsOverlayMode));
    }
  }
}
