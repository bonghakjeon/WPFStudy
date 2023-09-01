// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UbRest.ResponseV0`1
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using UniBiz.Bo.Models.Converter;

namespace UniBiz.Bo.Models.UbRest
{
  public class ResponseV0<T>
  {
    private int code = 1;
    private string message;
    private string sys_message;
    private T response;

    public int Code
    {
      get => this.code;
      set => this.code = value;
    }

    public bool IsSuccess => this.code == 1;

    public string Message
    {
      get => this.message;
      set => this.message = value;
    }

    public string Sys_message
    {
      get => this.sys_message;
      set => this.sys_message = value;
    }

    public T Response
    {
      get => this.response;
      set => this.response = value;
    }

    public void SetErrData(EnumResult p_err_code, string p_err_message, string p_sys_message)
    {
      this.code = (int) p_err_code;
      this.message = p_err_message;
      this.sys_message = p_sys_message;
    }
  }
}
