// Decompiled with JetBrains decompiler
// Type: UniBizBO.Composition.CommonCode
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using UniBiz.Bo.Models.UniBase.CommonCode;
using UniinfoNet;

namespace UniBizBO.Composition
{
  public class CommonCode : BindableBase
  {
    public bool IsFixed { get; set; }

    public int CType { get; set; }

    public string CTypeMemo { get; set; }

    public int Number { get; set; }

    public string NumberMemo { get; set; }

    public int Order { get; set; }

    public bool IsUse { get; set; }

    public double? DataDouble { get; set; }

    public int? DataInt { get; set; }

    public string DataString { get; set; }

    public override string ToString() => this.NumberMemo;

    public override int GetHashCode() => base.GetHashCode();

    public override bool Equals(object obj)
    {
      bool flag = true;
      return !(obj is UniBizBO.Composition.CommonCode commonCode) ? this.GetHashCode() == obj.GetHashCode() : flag & this.CType == commonCode.CType & this.Number == commonCode.Number;
    }

    public UniBizBO.Composition.CommonCode Apply(CommonCodeView o)
    {
      this.CType = o.comm_Type;
      this.CTypeMemo = o.comm_TypeMemo;
      this.Number = o.comm_TypeNo;
      this.NumberMemo = o.comm_TypeNoMemo;
      this.Order = o.comm_SortNo;
      this.IsUse = o.comm_UseYn.Equals("Y");
      this.DataDouble = new double?(o.comm_DataMoney);
      this.DataInt = new int?(o.comm_DataInt);
      this.DataString = o.comm_DataString;
      return this;
    }
  }
}
