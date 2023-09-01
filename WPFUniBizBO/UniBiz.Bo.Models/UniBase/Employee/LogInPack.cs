// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Employee.LogInPack
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections.Generic;
using System.Text.Json.Serialization;
using UniBiz.Bo.Models.UniBase.CommonCode;
using UniBiz.Bo.Models.UniBase.Employee.EmpAuthority;
using UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenuAuth;
using UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenuBookMark;
using UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenuPropAuth;

namespace UniBiz.Bo.Models.UniBase.Employee
{
  public class LogInPack : LogInSmallPack
  {
    private string _userID = string.Empty;
    private string _userPwd = string.Empty;
    private string _AppVersion = string.Empty;
    private ProgMenuAuthView _UserMenuInfo;
    private ProgMenuPropAuthView _UserMenuPropInfo;
    private IList<ProgMenuBookMarkView> _Lt_BookMark;

    [JsonPropertyName("55C4544C-096C-41F3-9274-FE74EB211B3F")]
    public string userID
    {
      get => this._userID;
      set
      {
        this._userID = value;
        this.Changed(nameof (userID));
      }
    }

    [JsonPropertyName("6D99A081-0A68-4645-8B86-659BF6D33021")]
    public string userPwd
    {
      get => this._userPwd;
      set
      {
        this._userPwd = value;
        this.Changed(nameof (userPwd));
      }
    }

    [JsonPropertyName("appVersion")]
    public string AppVersion
    {
      get => this._AppVersion;
      set
      {
        this._AppVersion = value;
        this.Changed(nameof (AppVersion));
      }
    }

    public Dictionary<int, CommonCodeView> hm_CommonCode { get; set; }

    [JsonPropertyName("userMenuInfo")]
    public ProgMenuAuthView UserMenuInfo
    {
      get => this._UserMenuInfo ?? (this._UserMenuInfo = new ProgMenuAuthView());
      set
      {
        this._UserMenuInfo = value;
        this.Changed(nameof (UserMenuInfo));
      }
    }

    [JsonPropertyName("userMenuPropInfo")]
    public ProgMenuPropAuthView UserMenuPropInfo
    {
      get => this._UserMenuPropInfo ?? (this._UserMenuPropInfo = new ProgMenuPropAuthView());
      set
      {
        this._UserMenuPropInfo = value;
        this.Changed(nameof (UserMenuPropInfo));
      }
    }

    [JsonPropertyName("lt_BookMark")]
    public IList<ProgMenuBookMarkView> Lt_BookMark
    {
      get => this._Lt_BookMark ?? (this._Lt_BookMark = (IList<ProgMenuBookMarkView>) new List<ProgMenuBookMarkView>());
      set
      {
        this._Lt_BookMark = value;
        this.Changed(nameof (Lt_BookMark));
      }
    }

    [JsonPropertyName("lt_UserAuthorityStore")]
    public IList<EmpAuthorityStore> Lt_UserAuthorityStore { get; set; }

    public IList<EmpAuthoritySupplier> Lt_UserAuthoritySupplier { get; set; }

    public LogInPack() => this.Clear();

    public override void Clear()
    {
      base.Clear();
      this.userID = string.Empty;
      this.userPwd = string.Empty;
      this.AppVersion = string.Empty;
      if (this.hm_CommonCode != null)
        this.hm_CommonCode.Clear();
      this.UserMenuInfo = (ProgMenuAuthView) null;
      this.UserMenuPropInfo = (ProgMenuPropAuthView) null;
      if (this.Lt_UserAuthorityStore != null)
        this.Lt_UserAuthorityStore.Clear();
      if (this.Lt_UserAuthoritySupplier == null)
        return;
      this.Lt_UserAuthoritySupplier.Clear();
    }

    protected override LogInSmallPack CreateClone => (LogInSmallPack) new LogInPack();

    public override object Clone()
    {
      LogInPack logInPack = base.Clone() as LogInPack;
      logInPack.userID = this.userID;
      logInPack.userPwd = this.userPwd;
      logInPack.AppVersion = this.AppVersion;
      logInPack.hm_CommonCode = this.hm_CommonCode;
      logInPack.UserMenuInfo = this.UserMenuInfo;
      logInPack.UserMenuPropInfo = this.UserMenuPropInfo;
      logInPack.Lt_UserAuthorityStore = this.Lt_UserAuthorityStore;
      logInPack.Lt_UserAuthoritySupplier = this.Lt_UserAuthoritySupplier;
      return (object) logInPack;
    }

    public void PutData(LogInPack pSource)
    {
      this.PutData((LogInSmallPack) pSource);
      this.userID = pSource.userID;
      this.userPwd = pSource.userPwd;
      this.AppVersion = pSource.AppVersion;
      if (this.hm_CommonCode == null)
        this.hm_CommonCode = new Dictionary<int, CommonCodeView>();
      else
        this.hm_CommonCode.Clear();
      if (pSource.hm_CommonCode != null)
      {
        foreach (KeyValuePair<int, CommonCodeView> keyValuePair in pSource.hm_CommonCode)
          this.hm_CommonCode.Add(keyValuePair.Key, keyValuePair.Value);
      }
      if (pSource.UserMenuInfo != null)
        this.UserMenuInfo.PutData(pSource.UserMenuInfo);
      else
        this.UserMenuInfo.Clear();
      if (pSource.UserMenuPropInfo != null)
        this.UserMenuPropInfo.PutData(pSource.UserMenuPropInfo);
      else
        this.UserMenuPropInfo.Clear();
      if (this.Lt_UserAuthorityStore == null)
        this.Lt_UserAuthorityStore = (IList<EmpAuthorityStore>) new List<EmpAuthorityStore>();
      else
        this.Lt_UserAuthorityStore.Clear();
      if (pSource.Lt_UserAuthorityStore != null)
      {
        foreach (EmpAuthorityStore pSource1 in (IEnumerable<EmpAuthorityStore>) pSource.Lt_UserAuthorityStore)
        {
          EmpAuthorityStore empAuthorityStore = new EmpAuthorityStore();
          empAuthorityStore.PutData(pSource1);
          this.Lt_UserAuthorityStore.Add(empAuthorityStore);
        }
      }
      if (this.Lt_UserAuthoritySupplier == null)
        this.Lt_UserAuthoritySupplier = (IList<EmpAuthoritySupplier>) new List<EmpAuthoritySupplier>();
      else
        this.Lt_UserAuthoritySupplier.Clear();
      if (pSource.Lt_UserAuthoritySupplier != null)
      {
        foreach (EmpAuthoritySupplier pSource2 in (IEnumerable<EmpAuthoritySupplier>) pSource.Lt_UserAuthoritySupplier)
        {
          EmpAuthoritySupplier authoritySupplier = new EmpAuthoritySupplier();
          authoritySupplier.PutData(pSource2);
          this.Lt_UserAuthoritySupplier.Add(authoritySupplier);
        }
      }
      else
        this.Lt_UserAuthoritySupplier = (IList<EmpAuthoritySupplier>) null;
      if (pSource.Lt_BookMark == null)
        return;
      foreach (ProgMenuBookMarkView menuBookMarkView in (IEnumerable<ProgMenuBookMarkView>) pSource.Lt_BookMark)
        this.Lt_BookMark.Add(menuBookMarkView);
    }
  }
}
