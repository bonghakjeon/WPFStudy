// Decompiled with JetBrains decompiler
// Type: UniBizBO.Store.TableBase
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Microsoft.EntityFrameworkCore;
using System;
using UniinfoNet;

namespace UniBizBO.Store
{
  public abstract class TableBase : BindableBase
  {
    private DateTime createUtcTime;
    private string createrName;
    private DateTime updateUtcTime;
    private string updaterName;

    public DateTime CreateUtcTime
    {
      get => this.createUtcTime;
      set
      {
        this.createUtcTime = value;
        this.Changed(nameof (CreateUtcTime));
      }
    }

    public string CreaterName
    {
      get => this.createrName;
      set
      {
        this.createrName = value;
        this.Changed(nameof (CreaterName));
      }
    }

    public DateTime UpdateUtcTime
    {
      get => this.updateUtcTime;
      set
      {
        this.updateUtcTime = value;
        this.Changed(nameof (UpdateUtcTime));
      }
    }

    public string UpdaterName
    {
      get => this.updaterName;
      set
      {
        this.updaterName = value;
        this.Changed(nameof (UpdaterName));
      }
    }

    public virtual void BuildModel(ModelBuilder modelBuilder)
    {
    }
  }
}
