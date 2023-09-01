// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.JobEvtMessage.JobEvtEodReWork
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using UniBiz.Bo.Models.UniBase.Employee;
using UniBiz.Bo.Models.UniBase.Employee.Employee;

namespace UniBiz.Bo.Models.JobEvtMessage
{
  public class JobEvtEodReWork : JobEvtBase
  {
    private int _eod_ID;
    private EmployeeView _EmployeeInfo;
    private LogInSmallPack _LogInPack;
    private int _work_pm_MenuCode;
    private int _work_pmp_PropCode;

    public int eod_ID
    {
      get => this._eod_ID;
      set
      {
        this._eod_ID = value;
        this.Changed(nameof (eod_ID));
      }
    }

    public EmployeeView EmployeeInfo
    {
      get => this._EmployeeInfo;
      set
      {
        this._EmployeeInfo = value;
        this.Changed(nameof (EmployeeInfo));
      }
    }

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

    public JobEvtEodReWork() => this.resource = 8;
  }
}
