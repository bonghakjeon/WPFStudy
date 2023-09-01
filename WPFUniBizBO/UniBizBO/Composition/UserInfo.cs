// Decompiled with JetBrains decompiler
// Type: UniBizBO.Composition.UserInfo
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using StyletIoC;
using System.Collections.Generic;
using UniBiz.Bo.Models.UniBase.Employee;
using UniBiz.Bo.Models.UniBase.Employee.Employee;
using UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenuAuth;
using UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenuPropAuth;
using UniinfoNet;

namespace UniBizBO.Composition
{
  public class UserInfo : BindableBase
  {
    [Inject]
    public LogInPack LogInPackInfo { get; set; }

    public EmployeeView Source { get; private set; }

    public void SetSource(EmployeeView emp) => this.Source = emp;

    public List<PageMenuInfo> GetPageMenuInfos() => PageMenuInfo.ConvertFrom((IEnumerable<ProgMenuAuthView>) this.LogInPackInfo.UserMenuInfo.Lt_Detail);

    public List<PartMenuInfo> GetPartMenuInfos() => PartMenuInfo.ConvertFrom((IEnumerable<ProgMenuPropAuthView>) this.LogInPackInfo.UserMenuPropInfo.Lt_Detail);
  }
}
