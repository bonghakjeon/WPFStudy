// Decompiled with JetBrains decompiler
// Type: UniBizBO.AppEventLog
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace UniBizBO
{
  public class AppEventLog
  {
    protected static Dictionary<string, string> CreateData() => new Dictionary<string, string>();

    protected static Dictionary<string, string> CreateDataWithTime()
    {
      Dictionary<string, string> data = AppEventLog.CreateData();
      data["Time"] = DateTime.UtcNow.ToString("HH");
      return data;
    }

    protected static void Logging(IDictionary<string, string> dic, [CallerMemberName] string name = "NoEventName") => Microsoft.AppCenter.Analytics.Analytics.TrackEvent(name, dic);

    public static void AppStart(Dictionary<string, string> dic) => AppEventLog.Logging((IDictionary<string, string>) dic, "App Start");

    public static void ProgramSetting(Dictionary<string, string> dic) => AppEventLog.Logging((IDictionary<string, string>) dic, nameof (ProgramSetting));

    public static void Login(Dictionary<string, string> dic) => AppEventLog.Logging((IDictionary<string, string>) dic, nameof (Login));

    public static void DeliverySearch(Dictionary<string, string> dic) => AppEventLog.Logging((IDictionary<string, string>) dic, nameof (DeliverySearch));

    public static void DeliveryLocationSearch(Dictionary<string, string> dic) => AppEventLog.Logging((IDictionary<string, string>) dic, nameof (DeliveryLocationSearch));

    public static void StartPageLinkRequest(Dictionary<string, string> dic) => AppEventLog.Logging((IDictionary<string, string>) dic, "Link : Start Page");
  }
}
