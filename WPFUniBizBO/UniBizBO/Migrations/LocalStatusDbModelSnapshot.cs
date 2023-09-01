// Decompiled with JetBrains decompiler
// Type: UniBizBO.Migrations.LocalStatusDbModelSnapshot
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using UniBizBO.Store;

namespace UniBizBO.Migrations
{
  [DbContext(typeof (LocalStatusDb))]
  internal class LocalStatusDbModelSnapshot : ModelSnapshot
  {
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
      modelBuilder.HasAnnotation("ProductVersion", (object) "5.0.0");
      modelBuilder.Entity("UniBizBO.Store.Tables.CommonStatusTable", (Action<EntityTypeBuilder>) (b =>
      {
        b.Property<long>("Id").ValueGeneratedOnAdd().HasColumnType<long>("INTEGER");
        b.Property<DateTime>("CreateUtcTime").HasColumnType<DateTime>("TEXT");
        b.Property<string>("CreaterName").HasColumnType<string>("TEXT");
        b.Property<string>("PropertyName").HasColumnType<string>("TEXT");
        b.Property<string>("StatusId").HasColumnType<string>("TEXT");
        b.Property<string>("StatusVal").HasColumnType<string>("TEXT");
        b.Property<string>("TypeName").HasColumnType<string>("TEXT");
        b.Property<DateTime>("UpdateUtcTime").HasColumnType<DateTime>("TEXT");
        b.Property<string>("UpdaterName").HasColumnType<string>("TEXT");
        b.HasKey("Id");
        b.ToTable("Commons");
      }));
    }
  }
}
