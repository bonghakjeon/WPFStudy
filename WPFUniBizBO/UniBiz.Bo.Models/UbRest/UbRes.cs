// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UbRest.UbRes
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using UniinfoNet;

namespace UniBiz.Bo.Models.UbRest
{
  public class UbRes : BindableBase
  {
    public long code { get; set; }

    public string message { get; set; }

    public string sys_message { get; set; }

    public bool isSuccess { get; set; }
  }
}
