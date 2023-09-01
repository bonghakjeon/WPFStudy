// Decompiled with JetBrains decompiler
// Type: UniBizBO.Settings.LoginSetting
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using System;
using System.Collections.Generic;
using UniinfoNet;

namespace UniBizBO.Settings
{
  public class LoginSetting : BindableBase
  {
    private string serverPath = "http://localhost:27026/api";
    private string _SiteViewCode = "1";
    private string id = "1";
    private string password = "1";
    private List<string> serverPaths = new List<string>()
    {
      "http://localhost:27026/api",
      "http://192.168.222.250:27026/api"
    };
    private DateTime? _DtLastLogIn = new DateTime?(DateTime.Now);

    public string ServerPath
    {
      get => this.serverPath;
      set
      {
        this.serverPath = value;
        this.Changed(nameof (ServerPath));
      }
    }

    public string SiteViewCode
    {
      get => this._SiteViewCode;
      set
      {
        this._SiteViewCode = value;
        this.Changed(nameof (SiteViewCode));
      }
    }

    public string Id
    {
      get => this.id;
      set
      {
        this.id = value;
        this.Changed(nameof (Id));
      }
    }

    public string Password
    {
      get => this.password;
      set
      {
        this.password = value;
        this.Changed(nameof (Password));
      }
    }

    public List<string> ServerPaths
    {
      get => this.serverPaths;
      set
      {
        this.serverPaths = value;
        this.Changed(nameof (ServerPaths));
      }
    }

    public DateTime? DtLastLogIn
    {
      get => this._DtLastLogIn;
      set
      {
        this._DtLastLogIn = value;
        this.Changed(nameof (DtLastLogIn));
      }
    }
  }
}
