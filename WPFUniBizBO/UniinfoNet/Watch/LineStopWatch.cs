// Decompiled with JetBrains decompiler
// Type: UniinfoNet.Watch.LineStopWatch
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;


#nullable enable
namespace UniinfoNet.Watch
{
  public class LineStopWatch : Stopwatch
  {
    private 
    #nullable disable
    object _lock = new object();

    public List<LineStopWatch.LineStopInfo> Memorys { get; } = new List<LineStopWatch.LineStopInfo>();

    public LineStopWatch.LineStopInfo Check([CallerFilePath] string path = "", [CallerLineNumber] int line = -1, [CallerMemberName] string name = "")
    {
      TimeSpan elapsed = this.Elapsed;
      string fileName = Path.GetFileName(path);
      LineStopWatch.LineStopInfo lineStopInfo1 = (LineStopWatch.LineStopInfo) null;
      lock (this._lock)
      {
        LineStopWatch.LineStopInfo lineStopInfo2 = this.Memorys.LastOrDefault<LineStopWatch.LineStopInfo>();
        if (lineStopInfo2 == null)
        {
          lineStopInfo2 = new LineStopWatch.LineStopInfo()
          {
            Location = new LineStopWatch.LineLocation("", -1, ""),
            Time = TimeSpan.Zero,
            Differ = TimeSpan.Zero
          };
          this.Memorys.Add(lineStopInfo2);
        }
        LineStopWatch.LineStopInfo lineStopInfo3 = new LineStopWatch.LineStopInfo();
        lineStopInfo3.Location = new LineStopWatch.LineLocation(fileName, line, name);
        lineStopInfo3.Time = elapsed;
        TimeSpan timeSpan = elapsed;
        TimeSpan? time = lineStopInfo2?.Time;
        lineStopInfo3.Differ = (time.HasValue ? new TimeSpan?(timeSpan - time.GetValueOrDefault()) : new TimeSpan?()).GetValueOrDefault();
        lineStopInfo1 = lineStopInfo3;
        this.Memorys.Add(lineStopInfo1);
      }
      return lineStopInfo1;
    }

    public LineStopWatch.LineStopInfo CheckAndDebugOutput([CallerFilePath] string path = "", [CallerLineNumber] int line = -1, [CallerMemberName] string name = "") => this.Check(path, line, name);

    public List<LineStopWatch.LineStopPathInfo> TotalInfos()
    {
      Dictionary<LineStopWatch.LineLocationPath, LineStopWatch.LineStopPathInfo> source = new Dictionary<LineStopWatch.LineLocationPath, LineStopWatch.LineStopPathInfo>();
      LineStopWatch.LineStopInfo lineStopInfo = (LineStopWatch.LineStopInfo) null;
      foreach (LineStopWatch.LineStopInfo memory in this.Memorys)
      {
        if (lineStopInfo == null)
        {
          lineStopInfo = memory;
        }
        else
        {
          LineStopWatch.LineLocationPath key = new LineStopWatch.LineLocationPath(lineStopInfo.Location, memory.Location);
          LineStopWatch.LineStopPathInfo lineStopPathInfo;
          if (!source.TryGetValue(key, out lineStopPathInfo))
          {
            lineStopPathInfo = new LineStopWatch.LineStopPathInfo()
            {
              LocationPath = key,
              Differs = new List<TimeSpan>()
            };
            source[key] = lineStopPathInfo;
          }
          lineStopPathInfo.Differs.Add(memory.Differ);
          lineStopInfo = memory;
        }
      }
      return source.Select<KeyValuePair<LineStopWatch.LineLocationPath, LineStopWatch.LineStopPathInfo>, LineStopWatch.LineStopPathInfo>((Func<KeyValuePair<LineStopWatch.LineLocationPath, LineStopWatch.LineStopPathInfo>, LineStopWatch.LineStopPathInfo>) (it => it.Value)).ToList<LineStopWatch.LineStopPathInfo>();
    }

    public List<LineStopWatch.LineStopPathInfo> TotalInfosAndDebugOutput()
    {
      List<LineStopWatch.LineStopPathInfo> list = this.TotalInfos().OrderBy<LineStopWatch.LineStopPathInfo, TimeSpan>((Func<LineStopWatch.LineStopPathInfo, TimeSpan>) (it => it.Average)).ToList<LineStopWatch.LineStopPathInfo>();
      foreach (LineStopWatch.LineStopPathInfo lineStopPathInfo in list)
        ;
      return list;
    }

    public record LineLocation(string FileName, int Line, string Member);

    public record LineLocationPath(LineStopWatch.LineLocation Start, LineStopWatch.LineLocation End);

    public class LineStopInfo
    {
      public LineStopWatch.LineLocation Location { get; init; }

      public TimeSpan Time { get; init; }

      public TimeSpan Differ { get; init; }

      public override string ToString()
      {
        object[] objArray = new object[5]
        {
          (object) this.Time,
          (object) this.Differ.TotalMilliseconds,
          (object) this.Location?.FileName,
          null,
          null
        };
        LineStopWatch.LineLocation location = this.Location;
        objArray[3] = (object) ((object) location != null ? location.Line : 0);
        objArray[4] = (object) this.Location?.Member;
        return string.Format("{0} {1,10:0.00}ms : {2} {3,5:0} {4}", objArray);
      }
    }

    public class LineStopPathInfo
    {
      public LineStopWatch.LineLocationPath LocationPath { get; init; }

      public List<TimeSpan> Differs { get; init; }

      public int Count => this.Differs.Count;

      public TimeSpan Sum => TimeSpan.FromTicks(this.Differs.Sum<TimeSpan>((Func<TimeSpan, long>) (it => it.Ticks)));

      public TimeSpan Average => this.Sum / (double) this.Count;

      public override string ToString()
      {
        LineStopWatch.LineLocation start = this.LocationPath.Start;
        LineStopWatch.LineLocation end = this.LocationPath.End;
        return string.Format("{0,10:0.00}ms / {1,5:0} = {2,10:0.00}ms : {3} {4,5:0} {5} =>> {6} {7,5:0} {8}", (object) this.Sum.TotalMilliseconds, (object) this.Count, (object) this.Average.TotalMilliseconds, (object) start.FileName, (object) start.Line, (object) start.Member, (object) end.FileName, (object) end.Line, (object) end.Member);
      }
    }
  }
}
