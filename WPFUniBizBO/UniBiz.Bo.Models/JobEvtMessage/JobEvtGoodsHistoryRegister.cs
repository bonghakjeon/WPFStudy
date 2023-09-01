// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.JobEvtMessage.JobEvtGoodsHistoryRegister
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections.Generic;
using System.Text.Json.Serialization;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.UniBase.Employee;
using UniBiz.Bo.Models.UniBase.Employee.Employee;
using UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsHistory;

namespace UniBiz.Bo.Models.JobEvtMessage
{
  public class JobEvtGoodsHistoryRegister : JobEvtBase
  {
    private EnumGoodsHistoryUpdateType _WorkType;
    private IList<GoodsHistoryView> _Lt_History;
    private EmployeeView _EmployeeInfo;
    private LogInSmallPack _LogInPack;
    private int _work_pm_MenuCode;
    private int _work_pmp_PropCode;

    [JsonPropertyName("workType")]
    public EnumGoodsHistoryUpdateType WorkType
    {
      get => this._WorkType;
      set
      {
        this._WorkType = value;
        this.Changed(nameof (WorkType));
      }
    }

    [JsonPropertyName("lt_History")]
    public IList<GoodsHistoryView> Lt_History
    {
      get => this._Lt_History ?? (this._Lt_History = (IList<GoodsHistoryView>) new List<GoodsHistoryView>());
      set
      {
        this._Lt_History = value;
        this.Changed(nameof (Lt_History));
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

    public JobEvtGoodsHistoryRegister() => this.resource = 7;
  }
}
