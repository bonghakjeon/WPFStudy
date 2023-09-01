// Decompiled with JetBrains decompiler
// Type: UniinfoNet.Extensions.HttpClientExtension
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;


#nullable enable
namespace UniinfoNet.Extensions
{
  public static class HttpClientExtension
  {
    public static async 
    #nullable disable
    Task CopyToFileAsync(
      this HttpContent obj,
      string destFilePath,
      int bufferSize = 8192,
      CancellationToken token = default (CancellationToken),
      IProgress<double> progress = null)
    {
      string directoryName = Path.GetDirectoryName(destFilePath);
      if (!Directory.Exists(directoryName))
        Directory.CreateDirectory(directoryName);
      DirectoryInfo directoryInfo = new DirectoryInfo(directoryName);
      FileInfo fileInfo = new FileInfo(destFilePath);
      using (FileStream fw = File.OpenWrite(destFilePath))
      {
        await obj.CopyToStreamAsync((Stream) fw, bufferSize, token, progress);
        await fw.FlushAsync();
      }
    }

    public static async Task CopyToFileAsync(
      this HttpContent obj,
      FileInfo destFile,
      int bufferSize = 8192,
      CancellationToken token = default (CancellationToken),
      IProgress<double> progress = null)
    {
      using (FileStream fw = destFile.OpenWrite())
      {
        await obj.CopyToStreamAsync((Stream) fw, bufferSize, token, progress);
        await fw.FlushAsync();
      }
    }

    public static async Task CopyToStreamAsync(
      this HttpContent obj,
      Stream destination,
      int bufferSize = 8192,
      CancellationToken token = default (CancellationToken),
      IProgress<double> progress = null)
    {
      long totalSize = obj.Headers.ContentLength.HasValue ? obj.Headers.ContentLength.Value : -1L;
      using (Stream sr = await obj.ReadAsStreamAsync())
      {
        if (progress == null || totalSize <= 0L)
        {
          await sr.CopyToAsync(destination, token);
          progress?.Report(1.0);
          return;
        }
        long totalRead = 0;
        byte[] buffer = new byte[bufferSize];
        while (true)
        {
          IProgress<double> progress1;
          do
          {
            do
            {
              int read = await sr.ReadAsync(buffer, 0, buffer.Length, token);
              if (read != 0)
              {
                await destination.WriteAsync(buffer, 0, read, token);
                totalRead += (long) read;
              }
              else
                goto label_12;
            }
            while (totalSize <= 0L || progress == null);
            progress1 = progress;
          }
          while (progress1 == null);
          progress1.Report((double) totalRead * 1.0 / (double) totalSize);
        }
label_12:
        buffer = (byte[]) null;
      }
    }
  }
}
