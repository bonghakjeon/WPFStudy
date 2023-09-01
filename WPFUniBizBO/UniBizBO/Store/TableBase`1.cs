// Decompiled with JetBrains decompiler
// Type: UniBizBO.Store.TableBase`1
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq.Expressions;
using UniinfoNet.Extensions;

namespace UniBizBO.Store
{
  public abstract class TableBase<T> : TableBase where T : TableBase<T>
  {
    public override void BuildModel(ModelBuilder modelBuilder) => modelBuilder.Entity<T>().Action<EntityTypeBuilder<T>>((Action<EntityTypeBuilder<T>>) (m => this.OnBuildModel(m)));

    public virtual void OnBuildModel(EntityTypeBuilder<T> builder)
    {
      builder.Ignore((Expression<Func<T, object>>) (it => (object) it._EnablePropertyChanged));
      builder.Ignore((Expression<Func<T, object>>) (it => (object) it._IsPropertyChanged));
    }

    public abstract T Apply(T source);
  }
}
