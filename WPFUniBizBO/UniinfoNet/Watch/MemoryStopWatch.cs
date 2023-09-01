// Decompiled with JetBrains decompiler
// Type: UniinfoNet.Watch.MemoryStopWatch
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace UniinfoNet.Watch
{
  public class MemoryStopWatch : Stopwatch
  {
    private List<TimeSpan> memorys = new List<TimeSpan>();

    public IReadOnlyList<TimeSpan> Memorys => (IReadOnlyList<TimeSpan>) this.memorys;

    public virtual TimeSpan Check()
    {
      TimeSpan elapsed = this.Elapsed;
      TimeSpan timeSpan = this.memorys.LastOrDefault<TimeSpan>();
      if (timeSpan > elapsed)
      {
        this.memorys.Clear();
        timeSpan = TimeSpan.Zero;
      }
      this.memorys.Add(elapsed);
      return elapsed - timeSpan;
    }

    public string CheckToString(string format = "G") => this.Check().ToString(format) ?? "";
  }
}
