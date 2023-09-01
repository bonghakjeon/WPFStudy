// Decompiled with JetBrains decompiler
// Type: UniBizBO.SystemCurrentInfo
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using System;
using System.Threading;
using UniinfoNet;
using UniinfoNet.Extensions;

namespace UniBizBO
{
  public class SystemCurrentInfo : BindableBase, IDisposable
  {
    private static SystemCurrentInfo instance;
    private DateTime timeNow;
    private Timer innerTimer;
    private bool disposedValue;

    public static SystemCurrentInfo Instance
    {
      get
      {
        SystemCurrentInfo instance = SystemCurrentInfo.instance;
        if (instance != null)
          return instance;
        SystemCurrentInfo systemCurrentInfo = new SystemCurrentInfo();
        return SystemCurrentInfo.instance = systemCurrentInfo.Action<SystemCurrentInfo>((Action<SystemCurrentInfo>) (it => it.Init()));
      }
    }

    private SystemCurrentInfo()
    {
    }

    public DateTime TimeNow
    {
      get => this.timeNow;
      protected set => this.SetAndNotify<DateTime>(ref this.timeNow, value, nameof (TimeNow));
    }

    private void Init() => this.innerTimer = new Timer(new TimerCallback(this.OnRefreshTimerCallback), (object) this, 0, 1000);

    protected void OnRefreshTimerCallback(object obj) => this.TimeNow = DateTime.Now;

    protected virtual void Dispose(bool disposing)
    {
      if (this.disposedValue)
        return;
      if (disposing)
      {
        this.innerTimer?.Dispose();
        this.innerTimer = (Timer) null;
      }
      this.disposedValue = true;
    }

    public void Dispose()
    {
      this.Dispose(true);
      GC.SuppressFinalize((object) this);
    }
  }
}
