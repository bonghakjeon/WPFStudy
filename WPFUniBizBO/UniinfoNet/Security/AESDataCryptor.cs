// Decompiled with JetBrains decompiler
// Type: UniinfoNet.Security.AESDataCryptor
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

using System;
using System.IO;
using System.Security.Cryptography;

namespace UniinfoNet.Security
{
  public class AESDataCryptor : IDisposable
  {
    private static AESDataCryptor instance;
    public const int MAX_KEYSIZE_BYTE = 32;
    public const int MIN_KEYSIZE_BYTE = 16;
    public const int SKIP_KEYSIZE_BYTE = 4;
    public const int IVSIZE_BYTE = 16;
    private bool disposedValue;
    private Aes aes;
    private static byte[] defaultKey = new byte[32]
    {
      (byte) 97,
      (byte) 98,
      (byte) 99,
      (byte) 100,
      (byte) 101,
      (byte) 102,
      (byte) 103,
      (byte) 104,
      (byte) 97,
      (byte) 98,
      (byte) 99,
      (byte) 100,
      (byte) 101,
      (byte) 102,
      (byte) 103,
      (byte) 104,
      (byte) 97,
      (byte) 98,
      (byte) 99,
      (byte) 100,
      (byte) 101,
      (byte) 102,
      (byte) 103,
      (byte) 104,
      (byte) 97,
      (byte) 98,
      (byte) 99,
      (byte) 100,
      (byte) 101,
      (byte) 102,
      (byte) 103,
      (byte) 104
    };
    private static byte[] defaultIV = new byte[16]
    {
      (byte) 48,
      (byte) 49,
      (byte) 50,
      (byte) 51,
      (byte) 52,
      (byte) 53,
      (byte) 54,
      (byte) 55,
      (byte) 48,
      (byte) 49,
      (byte) 50,
      (byte) 51,
      (byte) 52,
      (byte) 53,
      (byte) 54,
      (byte) 55
    };

    public static AESDataCryptor Instance => AESDataCryptor.instance ?? (AESDataCryptor.instance = new AESDataCryptor());

    private AESDataCryptor() => this.aes = Aes.Create();

    public byte[] Encrypt(byte[] b, byte[] key = null, byte[] iv = null)
    {
      if (b == null)
        throw new Exception("압축할 데이터가 없습니다.");
      key = key ?? AESDataCryptor.defaultKey;
      iv = iv ?? AESDataCryptor.defaultIV;
      this.aes.Key = key;
      this.aes.IV = iv;
      ICryptoTransform encryptor = this.aes.CreateEncryptor();
      MemoryStream memoryStream = new MemoryStream();
      using (CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, encryptor, CryptoStreamMode.Write))
      {
        int offset = 0;
        int num = 4096;
        for (; offset < b.Length; offset += num)
        {
          int count = b.Length - offset;
          if (count > num)
            count = num;
          cryptoStream.Write(b, offset, count);
        }
      }
      encryptor.Dispose();
      return memoryStream.ToArray();
    }

    public byte[] Decrypt(byte[] b, byte[] key = null, byte[] iv = null)
    {
      if (b == null)
        throw new Exception("압축해제할 데이터가 없습니다.");
      key = key ?? AESDataCryptor.defaultKey;
      iv = iv ?? AESDataCryptor.defaultIV;
      this.aes.Key = key;
      this.aes.IV = iv;
      ICryptoTransform decryptor = this.aes.CreateDecryptor();
      MemoryStream memoryStream1 = new MemoryStream(b);
      MemoryStream memoryStream2 = new MemoryStream();
      using (CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream1, decryptor, CryptoStreamMode.Read))
      {
        int count1 = 4096;
        byte[] buffer = new byte[4096];
        for (int count2 = cryptoStream.Read(buffer, 0, count1); count2 > 0; count2 = cryptoStream.Read(buffer, 0, count1))
          memoryStream2.Write(buffer, 0, count2);
      }
      decryptor.Dispose();
      memoryStream2.Dispose();
      return memoryStream2.ToArray();
    }

    protected virtual void Dispose(bool disposing)
    {
      if (this.disposedValue)
        return;
      if (disposing)
        this.aes.Dispose();
      this.disposedValue = true;
    }

    public void Dispose() => this.Dispose(true);
  }
}
