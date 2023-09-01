// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.JobEvtMessage.JobEvtInventoryWork
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Text.Json.Serialization;
using UniBiz.Bo.Models.UniBase.Employee;
using UniBiz.Bo.Models.UniBase.Employee.Employee;
using UniBiz.Bo.Models.UniStock.Inventory.InventoryWork;

namespace UniBiz.Bo.Models.JobEvtMessage
{
  public class JobEvtInventoryWork : JobEvtBase
  {
    private int _si_StoreCode;
    private string _si_StoreCodeIn;
    private InventoryWorkCntTPack _WorkInfo;
    private EmployeeView _EmployeeInfo;
    private LogInSmallPack _LogInPack;
    private int _work_pm_MenuCode;
    private int _work_pmp_PropCode;

    public int si_StoreCode
    {
      get => this._si_StoreCode;
      set
      {
        this._si_StoreCode = value;
        this.Changed(nameof (si_StoreCode));
      }
    }

    public string si_StoreCodeIn
    {
      get => this._si_StoreCodeIn;
      set
      {
        this._si_StoreCodeIn = value;
        this.Changed(nameof (si_StoreCodeIn));
      }
    }

    [JsonPropertyName("workInfo")]
    public InventoryWorkCntTPack WorkInfo
    {
      get => this._WorkInfo;
      set
      {
        this._WorkInfo = value;
        this.Changed(nameof (WorkInfo));
      }
    }

    [JsonIgnore]
    public EmployeeView EmployeeInfo
    {
      get => this._EmployeeInfo;
      set
      {
        this._EmployeeInfo = value;
        this.Changed(nameof (EmployeeInfo));
      }
    }

    [JsonIgnore]
    public LogInSmallPack LogInPack
    {
      get => this._LogInPack;
      set
      {
        this._LogInPack = value;
        this.Changed(nameof (LogInPack));
      }
    }

    public int work_pm_MenuCode
    {
      get => this._work_pm_MenuCode;
      set
      {
        this._work_pm_MenuCode = value;
        this.Changed(nameof (work_pm_MenuCode));
      }
    }

    public int work_pmp_PropCode
    {
      get => this._work_pmp_PropCode;
      set
      {
        this._work_pmp_PropCode = value;
        this.Changed(nameof (work_pmp_PropCode));
      }
    }

    public JobEvtInventoryWork() => this.resource = 10;
  }
}
