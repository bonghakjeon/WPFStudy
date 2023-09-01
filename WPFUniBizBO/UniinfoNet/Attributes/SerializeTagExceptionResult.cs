// Decompiled with JetBrains decompiler
// Type: UniinfoNet.Attributes.SerializeTagExceptionResult
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

using System;

namespace UniinfoNet.Attributes
{
  public class SerializeTagExceptionResult
  {
    private Exception exception;
    private SerializeTagMo serializeTagMo;

    public Exception Exception => this.exception;

    public SerializeTagMo SerializeTagMo => this.serializeTagMo;

    public SerializeTagExceptionResult(Exception exception, SerializeTagMo serializeTagMo)
    {
      this.exception = exception;
      this.serializeTagMo = serializeTagMo;
    }

    public override string ToString() => string.Format("{0}\t {1}", (object) this.serializeTagMo, (object) this.exception.Message);
  }
}
