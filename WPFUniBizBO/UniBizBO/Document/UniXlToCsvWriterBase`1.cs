// Decompiled with JetBrains decompiler
// Type: UniBizBO.Document.UniXlToCsvWriterBase`1
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UniinfoNet.Xl;


#nullable enable
namespace UniBizBO.Document
{
  public abstract class UniXlToCsvWriterBase<T> : UniXlToWriterBase<
  #nullable disable
  T> where T : UniXlToCsvWriterBase<T>, new()
  {
    public bool UseColumnOutput { get; set; }

    public string CsvColumnSeparator { get; set; } = ",";

    public string CsvColumnSeparatorReplace { get; set; } = "";

    public string CsvRowSeparator { get; set; } = "\n";

    public string CsvRowSeparatorReplace { get; set; } = " ";

    public UniXlToCsvWriterBase()
    {
    }

    public UniXlToCsvWriterBase(UniXlInfo xl)
      : base(xl)
    {
    }

    public async Task SaveToCsvFileAsync(
      string filePath,
      IProgress<double> progress = null,
      CancellationToken token = default (CancellationToken))
    {
      using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8))
      {
        await this.WriteToCsvStringAsync(sw, progress, token);
        await sw.FlushAsync();
      }
    }

    public async Task<string> GetCsvStringAsync(IProgress<double> progress = null, CancellationToken token = default (CancellationToken))
    {
      string csvStringAsync;
      using (StringWriter sb = new StringWriter())
      {
        await this.WriteToCsvStringAsync(sb, progress, token);
        csvStringAsync = sb.ToString();
      }
      return csvStringAsync;
    }

    public async Task WriteToCsvStringAsync(
      StringWriter sw,
      IProgress<double> progress = null,
      CancellationToken token = default (CancellationToken))
    {
      UniXlToCsvWriterBase<T> xlToCsvWriterBase = this;
      double p = 0.0;
      progress?.Report(p);
      token.ThrowIfCancellationRequested();
      UniXlSheetInfo uniXlSheetInfo = xlToCsvWriterBase.Document.Sheets.FirstOrDefault<UniXlSheetInfo>();
      UniXlTableInfo uniXlTableInfo;
      if (uniXlSheetInfo == null)
      {
        uniXlTableInfo = (UniXlTableInfo) null;
      }
      else
      {
        List<UniXlTableInfo> tables = uniXlSheetInfo.Tables;
        uniXlTableInfo = tables != null ? tables.FirstOrDefault<UniXlTableInfo>() : (UniXlTableInfo) null;
      }
      UniXlTableInfo table = uniXlTableInfo;
      if (table == null)
      {
        table = (UniXlTableInfo) null;
      }
      else
      {
        if (xlToCsvWriterBase.UseColumnOutput)
          await xlToCsvWriterBase.WriteColumnCellAsync(table, (TextWriter) sw, (IProgress<double>) new Progress<double>((Action<double>) (it => progress?.Report(it * 0.1 + p))), token);
        progress?.Report(p = 0.1);
        await xlToCsvWriterBase.WriteRowCellAsync(table, (TextWriter) sw, (IProgress<double>) new Progress<double>((Action<double>) (it => progress?.Report(it * 0.9 + p))), token);
        IProgress<double> progress1 = progress;
        if (progress1 == null)
        {
          table = (UniXlTableInfo) null;
        }
        else
        {
          progress1.Report(p = 1.0);
          table = (UniXlTableInfo) null;
        }
      }
    }

    public async Task WriteToCsvStringAsync(
      StreamWriter sw,
      IProgress<double> progress = null,
      CancellationToken token = default (CancellationToken))
    {
      UniXlToCsvWriterBase<T> xlToCsvWriterBase = this;
      double p = 0.0;
      progress?.Report(p);
      token.ThrowIfCancellationRequested();
      UniXlSheetInfo uniXlSheetInfo = xlToCsvWriterBase.Document.Sheets.FirstOrDefault<UniXlSheetInfo>();
      UniXlTableInfo uniXlTableInfo;
      if (uniXlSheetInfo == null)
      {
        uniXlTableInfo = (UniXlTableInfo) null;
      }
      else
      {
        List<UniXlTableInfo> tables = uniXlSheetInfo.Tables;
        uniXlTableInfo = tables != null ? tables.FirstOrDefault<UniXlTableInfo>() : (UniXlTableInfo) null;
      }
      UniXlTableInfo table = uniXlTableInfo;
      if (table == null)
      {
        table = (UniXlTableInfo) null;
      }
      else
      {
        if (xlToCsvWriterBase.UseColumnOutput)
          await xlToCsvWriterBase.WriteColumnCellAsync(table, (TextWriter) sw, (IProgress<double>) new Progress<double>((Action<double>) (it => progress?.Report(it * 0.1 + p))), token);
        progress?.Report(p = 0.1);
        await xlToCsvWriterBase.WriteRowCellAsync(table, (TextWriter) sw, (IProgress<double>) new Progress<double>((Action<double>) (it => progress?.Report(it * 0.9 + p))), token);
        IProgress<double> progress1 = progress;
        if (progress1 == null)
        {
          table = (UniXlTableInfo) null;
        }
        else
        {
          progress1.Report(p = 1.0);
          table = (UniXlTableInfo) null;
        }
      }
    }

    protected string ConvertValidCsvString(string origin) => origin == null ? string.Empty : origin.Replace(this.CsvColumnSeparator, this.CsvColumnSeparatorReplace).Replace(this.CsvColumnSeparator, this.CsvColumnSeparatorReplace).TrimEnd();

    protected async Task WriteColumnCellAsync(
      UniXlTableInfo table,
      TextWriter tw,
      IProgress<double> progress = null,
      CancellationToken token = default (CancellationToken))
    {
      await Task.Factory.StartNew((Action) (() =>
      {
        for (int index = 0; index < table.Columns.Count; ++index)
        {
          // ISSUE: reference to a compiler-generated field
          tw.Write(this.\u003C\u003E4__this.ConvertValidCsvString(table.Columns[index].Header));
          if (index != table.Columns.Count - 1)
          {
            // ISSUE: reference to a compiler-generated field
            tw.Write(this.\u003C\u003E4__this.CsvColumnSeparator);
          }
          progress?.Report((double) index / (double) table.Columns.Count);
        }
        // ISSUE: reference to a compiler-generated field
        tw.Write(this.\u003C\u003E4__this.CsvRowSeparator);
      })).ConfigureAwait(false);
    }

    protected async Task WriteRowCellAsync(
      UniXlTableInfo table,
      TextWriter tw,
      IProgress<double> progress = null,
      CancellationToken token = default (CancellationToken))
    {
      int count1 = table.Columns.Count;
      await Task.Factory.StartNew((Action) (() =>
      {
        int count2 = table.Rows.Count;
        for (int index1 = 0; index1 < count2; ++index1)
        {
          token.ThrowIfCancellationRequested();
          UniXlTableRowInfo row = table.Rows[index1];
          int count3 = row.Cells.Count;
          for (int index2 = 0; index2 < count3; ++index2)
          {
            // ISSUE: reference to a compiler-generated field
            tw.Write(this.\u003C\u003E4__this.ConvertValidCsvString(row.Cells[index2].Value?.ToString()));
            if (index2 != count3 - 1)
            {
              // ISSUE: reference to a compiler-generated field
              tw.Write(this.\u003C\u003E4__this.CsvColumnSeparator);
            }
          }
          // ISSUE: reference to a compiler-generated field
          tw.Write(this.\u003C\u003E4__this.CsvRowSeparator);
          progress?.Report((double) index1 / (double) count2);
        }
      })).ConfigureAwait(false);
    }
  }
}
