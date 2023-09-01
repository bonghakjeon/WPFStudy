// Decompiled with JetBrains decompiler
// Type: UniBizBO.Store.Tables.CommonStatusTable
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq.Expressions;

namespace UniBizBO.Store.Tables
{
  public class CommonStatusTable : TableBase<CommonStatusTable>
  {
    private long id;
    private string typeName;
    private string propertyName;
    private string statusId;
    private string statusVal;

    public override void OnBuildModel(EntityTypeBuilder<CommonStatusTable> builder)
    {
      base.OnBuildModel(builder);
      builder.HasKey((Expression<Func<CommonStatusTable, object>>) (it => (object) it.Id));
    }

    public long Id
    {
      get => this.id;
      set
      {
        this.id = value;
        this.Changed(nameof (Id));
      }
    }

    public string TypeName
    {
      get => this.typeName;
      set
      {
        this.typeName = value;
        this.Changed(nameof (TypeName));
      }
    }

    public string PropertyName
    {
      get => this.propertyName;
      set
      {
        this.propertyName = value;
        this.Changed(nameof (PropertyName));
      }
    }

    public string StatusId
    {
      get => this.statusId;
      set
      {
        this.statusId = value;
        this.Changed(nameof (StatusId));
      }
    }

    public string StatusVal
    {
      get => this.statusVal;
      set
      {
        this.statusVal = value;
        this.Changed(nameof (StatusVal));
      }
    }

    public override CommonStatusTable Apply(CommonStatusTable source) => throw new NotImplementedException();
  }
}
