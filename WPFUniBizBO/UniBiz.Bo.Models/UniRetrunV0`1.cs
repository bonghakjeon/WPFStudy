// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniRetrunV0`1
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

namespace UniBiz.Bo.Models
{
  public class UniRetrunV0<T>
  {
    private T response;
    private string message;

    public T Response
    {
      get => this.response;
      set => this.response = value;
    }

    public string Message
    {
      get => this.message;
      set => this.message = value;
    }

    public void SetData(T p_data, string p_message)
    {
      this.response = p_data;
      this.Message = p_message;
    }
  }
}
