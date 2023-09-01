// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Employee.LogInSmallPack
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Text.Json.Serialization;
using UniBiz.Bo.Models.UniBase.Employee.Employee;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniBase.Employee
{
  public class LogInSmallPack : BindableBase, ICloneable
  {
    private string _appID = string.Empty;
    private string _sendType = string.Empty;
    private long _siteID;
    private int _DeviceKey;
    private string _DeviceName;
    private string _LocalIP;
    private string _PublicIP;
    private EmployeeView _employee;

    [JsonPropertyName("2F83D7D4-6F81-43FD-BFCD-ED1BC416387E")]
    public string appID
    {
      get => this._appID;
      set
      {
        this._appID = value;
        this.Changed(nameof (appID));
        this.Changed("userNewPassword");
      }
    }

    [JsonIgnore]
    public string userNewPassword => this.appID;

    [JsonPropertyName("90EDF7EC-7549-4237-A789-22FDBC95DE3E")]
    public string sendType
    {
      get => this._sendType;
      set
      {
        this._sendType = value;
        this.Changed(nameof (sendType));
      }
    }

    public long siteID
    {
      get => this._siteID;
      set
      {
        this._siteID = value;
        this.Changed(nameof (siteID));
      }
    }

    [JsonPropertyName("deviceKey")]
    public int DeviceKey
    {
      get => this._DeviceKey;
      set
      {
        this._DeviceKey = value;
        this.Changed(nameof (DeviceKey));
      }
    }

    [JsonPropertyName("deviceName")]
    public string DeviceName
    {
      get => this._DeviceName;
      set
      {
        this._DeviceName = value;
        this.Changed(nameof (DeviceName));
      }
    }

    [JsonPropertyName("localIP")]
    public string LocalIP
    {
      get => this._LocalIP;
      set
      {
        this._LocalIP = value;
        this.Changed(nameof (LocalIP));
      }
    }

    [JsonPropertyName("publicIP")]
    public string PublicIP
    {
      get => this._PublicIP;
      set
      {
        this._PublicIP = value;
        this.Changed(nameof (PublicIP));
      }
    }

    public EmployeeView employee
    {
      get => this._employee ?? (this._employee = new EmployeeView());
      set
      {
        this._employee = value;
        this.Changed(nameof (employee));
      }
    }

    public LogInSmallPack() => this.Clear();

    public virtual void Clear()
    {
      this.appID = string.Empty;
      this.sendType = string.Empty;
      this.siteID = 0L;
      this.DeviceKey = 0;
      this.DeviceName = string.Empty;
      this.LocalIP = string.Empty;
      this.PublicIP = string.Empty;
      this.employee = (EmployeeView) null;
    }

    protected virtual LogInSmallPack CreateClone => new LogInSmallPack();

    public virtual object Clone()
    {
      LogInSmallPack createClone = this.CreateClone;
      createClone.appID = this.appID;
      createClone.sendType = this.sendType;
      createClone.siteID = this.siteID;
      createClone.DeviceName = this.DeviceName;
      createClone.LocalIP = this.LocalIP;
      createClone.PublicIP = this.PublicIP;
      createClone.employee = (EmployeeView) null;
      if (this.employee.emp_Code != 0)
        createClone.employee.PutData(this.employee);
      return (object) createClone;
    }

    public void PutData(LogInSmallPack pSource)
    {
      this.appID = pSource.appID;
      this.sendType = pSource.sendType;
      this.siteID = pSource.siteID;
      this.DeviceName = pSource.DeviceName;
      this.LocalIP = pSource.LocalIP;
      this.PublicIP = pSource.PublicIP;
      this.employee = (EmployeeView) null;
      if (pSource.employee.emp_Code == 0)
        return;
      this.employee.PutData(pSource.employee);
    }
  }
}
