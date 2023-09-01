// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Employee.Employee.EmployeePassword
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Text.Json.Serialization;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniBase.Employee.Employee
{
  public class EmployeePassword : BindableBase
  {
    private string _SendType = string.Empty;
    private int _AppType;
    private int _ChangedType;
    private int _emp_Code;
    private long _emp_SiteID;
    private string _OldPass;
    private string _NewPass;

    [JsonPropertyName("90EDF7EC-7549-4237-A789-22FDBC95DE3E")]
    public string SendType
    {
      get => this._SendType;
      set
      {
        this._SendType = value;
        this.Changed(nameof (SendType));
      }
    }

    [JsonPropertyName("2F83D7D4-6F81-43FD-BFCD-ED1BC416387E")]
    public int AppType
    {
      get => this._AppType;
      set
      {
        this._AppType = value;
        this.Changed(nameof (AppType));
      }
    }

    [JsonPropertyName("A0ECBCD1-9F71-4C3D-A567-371AEEAB0DC8")]
    public int ChangedType
    {
      get => this._ChangedType;
      set
      {
        this._ChangedType = value;
        this.Changed(nameof (ChangedType));
        this.Changed("ChangedTypeEnum");
      }
    }

    [JsonIgnore]
    public EnumEmployeePasswordType ChangedTypeEnum => EmployeePassword.ToEmployeePasswordType(this.ChangedType);

    [JsonPropertyName("772E1BB7-0B43-4168-B34E-44EC5DC55B64")]
    public int emp_Code
    {
      get => this._emp_Code;
      set
      {
        this._emp_Code = value;
        this.Changed(nameof (emp_Code));
      }
    }

    [JsonPropertyName("0D6C7516-6055-4870-A9FC-E62ED0CCDF8D")]
    public long emp_SiteID
    {
      get => this._emp_SiteID;
      set
      {
        this._emp_SiteID = value;
        this.Changed(nameof (emp_SiteID));
      }
    }

    [JsonPropertyName("678862F0-4948-4B39-AED4-CFEE6DC58693")]
    public string OldPass
    {
      get => this._OldPass;
      set
      {
        this._OldPass = value;
        this.Changed(nameof (OldPass));
      }
    }

    [JsonPropertyName("98923DF2-08BE-4478-BB48-8290D28A48FA")]
    public string NewPass
    {
      get => this._NewPass;
      set
      {
        this._NewPass = value;
        this.Changed(nameof (NewPass));
      }
    }

    public static EnumEmployeePasswordType ToEmployeePasswordType(int p_value)
    {
      foreach (EnumEmployeePasswordType employeePasswordType in Enum.GetValues(typeof (EnumEmployeePasswordType)))
      {
        if (employeePasswordType == (EnumEmployeePasswordType) p_value)
          return employeePasswordType;
      }
      return EnumEmployeePasswordType.NONE;
    }
  }
}
