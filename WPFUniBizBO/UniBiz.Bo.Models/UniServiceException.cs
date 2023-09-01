// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniServiceException
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;

namespace UniBiz.Bo.Models
{
  public class UniServiceException : Exception
  {
    public int _ErrCode;
    public string _UserMessage = string.Empty;

    public int ErrCode
    {
      get => this._ErrCode;
      set => this._ErrCode = value;
    }

    public string UserMessage
    {
      get => this._UserMessage;
      set => this._UserMessage = value;
    }

    public UniServiceException(string p_sys_message, int p_error_code = 0)
      : base(p_sys_message)
    {
      this.ErrCode = p_error_code;
      this.UserMessage = string.Empty;
    }

    public UniServiceException(string p_sys_message, Exception p_exception, int p_error_code = 0)
      : base(p_sys_message, p_exception)
    {
      this.ErrCode = p_error_code;
      this.UserMessage = string.Empty;
    }

    public UniServiceException(string p_sys_message, string p_message = null, int p_error_code = 0)
      : base(p_sys_message)
    {
      this.ErrCode = p_error_code;
      this.UserMessage = p_message;
    }
  }
}
