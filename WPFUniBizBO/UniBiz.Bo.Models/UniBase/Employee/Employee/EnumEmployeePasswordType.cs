// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Employee.Employee.EnumEmployeePasswordType
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.UniBase.Employee.Employee
{
  public enum EnumEmployeePasswordType
  {
    [Description("-변경 타입-")] NONE,
    [Description("프로그램 패스워드")] emp_ProgPwd,
    [Description("포스 패스워드")] emp_PosPwd,
    [Description("이메일 패스워드")] emp_EmailPwd,
  }
}
