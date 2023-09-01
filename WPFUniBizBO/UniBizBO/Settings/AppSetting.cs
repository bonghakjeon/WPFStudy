// Decompiled with JetBrains decompiler
// Type: UniBizBO.Settings.AppSetting
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Serilog;
using System;
using System.IO;
using System.Text.Json;
using UniinfoNet;

namespace UniBizBO.Settings
{
  public class AppSetting : SettingPartBase
  {
    private static AppSetting _default;
    private UiSettingPart ui;
    private LoginSetting login;

    public static AppSetting Default
    {
      get => AppSetting._default ?? (AppSetting._default = new AppSetting());
      set
      {
        AppSetting._default = value;
        BindableBase.StaticChanged(nameof (Default));
      }
    }

    public UiSettingPart UI
    {
      get => this.ui ?? (this.ui = new UiSettingPart());
      set => this.SetAndNotify<UiSettingPart>(ref this.ui, value, nameof (UI));
    }

    public LoginSetting Login
    {
      get => this.login ?? (this.login = new LoginSetting());
      set
      {
        this.login = value;
        this.Changed(nameof (Login));
      }
    }

    public static void LoadDefaultFromFile(string path)
    {
      FileInfo fileInfo = new FileInfo(path);
      if (!fileInfo.Exists)
        AppSetting.SaveDefaultToFile(path);
      StreamReader streamReader = fileInfo.OpenText();
      string end = streamReader.ReadToEnd();
      streamReader.Dispose();
      AppSetting.Default = AppSetting.Deserialize(end);
    }

    public static void SaveDefaultToFile(string path)
    {
      FileInfo fileInfo = new FileInfo(path);
      fileInfo.Directory.Create();
      StreamWriter text = fileInfo.CreateText();
      text.Write(AppSetting.Serialize(AppSetting.Default));
      text.Dispose();
    }

    public static string Serialize(AppSetting setting) => JsonSerializer.Serialize<AppSetting>(setting, new JsonSerializerOptions()
    {
      WriteIndented = true
    });

    public static AppSetting Deserialize(string txt)
    {
      try
      {
        return JsonSerializer.Deserialize<AppSetting>(txt, new JsonSerializerOptions());
      }
      catch (Exception ex)
      {
        Log.Error(ex.Message);
        return new AppSetting();
      }
    }
  }
}
