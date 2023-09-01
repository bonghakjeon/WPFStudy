// Decompiled with JetBrains decompiler
// Type: UniBizBO.Store.LocalStatusDb
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using UniBizBO.Common;
using UniBizBO.Store.Tables;

namespace UniBizBO.Store
{
  public class LocalStatusDb : DbContext
  {
    public static readonly string FolderPath = DefaultPaths.DbFolderPath;
    public static readonly LoggerFactory DuLoggerFactory = new LoggerFactory((IEnumerable<ILoggerProvider>) new DebugLoggerProvider[1]
    {
      new DebugLoggerProvider()
    }, new LoggerFilterOptions()
    {
      MinLevel = LogLevel.Warning
    });
    private static bool migrationFlag = false;

    public DbSet<CommonStatusTable> Commons { get; set; }

    public LocalStatusDb()
    {
      if (LocalStatusDb.migrationFlag)
        return;
      LocalStatusDb.migrationFlag = true;
      try
      {
        this.Database.Migrate();
      }
      catch (Exception ex)
      {
        Process.Start("explorer.exe", LocalStatusDb.FolderPath);
        throw new Exception("개발 단계에서 이 위치 예외가 발생하면, 데이터베이스 파일을 삭제해 주세요.\n" + LocalStatusDb.FolderPath, ex);
      }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      base.OnConfiguring(optionsBuilder);
      DirectoryInfo directory = Directory.CreateDirectory(LocalStatusDb.FolderPath);
      optionsBuilder.UseSqlite(string.Format("Data Source={0}{1}Status.db", (object) directory, (object) Path.DirectorySeparatorChar), (Action<SqliteDbContextOptionsBuilder>) (option => { }));
      optionsBuilder.UseLoggerFactory((ILoggerFactory) LocalStatusDb.DuLoggerFactory);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);
      ((IEnumerable<TableBase>) new TableBase[1]
      {
        (TableBase) new CommonStatusTable()
      }).ToList<TableBase>().ForEach((Action<TableBase>) (it => it.BuildModel(modelBuilder)));
    }

    public override int SaveChanges()
    {
      IEnumerable<EntityEntry> entityEntries = this.ChangeTracker.Entries().Where<EntityEntry>((Func<EntityEntry, bool>) (x => x.State == EntityState.Added || x.State == EntityState.Modified));
      string userName = Environment.UserName;
      DateTime utcNow = DateTime.UtcNow;
      foreach (EntityEntry entityEntry in entityEntries)
      {
        TableBase entity = entityEntry.Entity as TableBase;
        if (entityEntry.State == EntityState.Added)
        {
          entity.CreaterName = userName ?? "unknown";
          entity.CreateUtcTime = utcNow;
        }
        entity.UpdaterName = userName ?? "unknown";
        entity.UpdateUtcTime = utcNow;
      }
      return base.SaveChanges();
    }
  }
}
