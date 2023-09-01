// Decompiled with JetBrains decompiler
// Type: UniinfoNet.Watch.DictionaryStopWatch
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace UniinfoNet.Watch
{
  public class DictionaryStopWatch : Stopwatch
  {
    private Dictionary<string, TimeSpan> memorys = new Dictionary<string, TimeSpan>();
    private Dictionary<string, TimeSpan> results = new Dictionary<string, TimeSpan>();

    public IReadOnlyDictionary<string, TimeSpan> Memorys => (IReadOnlyDictionary<string, TimeSpan>) this.memorys;

    public IReadOnlyDictionary<string, TimeSpan> Results => (IReadOnlyDictionary<string, TimeSpan>) this.results;

    public virtual TimeSpan Check(string tag = null)
    {
      TimeSpan elapsed = this.Elapsed;
      TimeSpan zero = TimeSpan.Zero;
      this.memorys.TryGetValue(tag, out zero);
      TimeSpan timeSpan = elapsed - zero;
      this.memorys[tag] = elapsed;
      this.results[tag] = timeSpan;
      return timeSpan;
    }

    public string CheckToString(string tag = null, string format = "G") => this.Check(tag).ToString(format) + " : " + tag;
  }
}
