// Decompiled with JetBrains decompiler
// Type: UniBizBO.Migrations.Init
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using UniBizBO.Store;

namespace UniBizBO.Migrations
{
  [DbContext(typeof (LocalStatusDb))]
  [Migration("20221201003938_Init")]
  public class Init : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder) => migrationBuilder.CreateTable("Commons", table => new
    {
      Id = table.Column<long>("INTEGER").Annotation("Sqlite:Autoincrement", (object) true),
      TypeName = table.Column<string>("TEXT", nullable: true),
      PropertyName = table.Column<string>("TEXT", nullable: true),
      StatusId = table.Column<string>("TEXT", nullable: true),
      StatusVal = table.Column<string>("TEXT", nullable: true),
      CreateUtcTime = table.Column<DateTime>("TEXT"),
      CreaterName = table.Column<string>("TEXT", nullable: true),
      UpdateUtcTime = table.Column<DateTime>("TEXT"),
      UpdaterName = table.Column<string>("TEXT", nullable: true)
    }, constraints: table => table.PrimaryKey("PK_Commons", x => x.Id));

    protected override void Down(MigrationBuilder migrationBuilder) => migrationBuilder.DropTable("Commons");

    protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
