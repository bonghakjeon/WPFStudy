// Decompiled with JetBrains decompiler
// Type: UniBizBO.Document.UniXlToClosedXmlWriterBase`1
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UniinfoNet.Extensions;
using UniinfoNet.Xl;


#nullable enable
namespace UniBizBO.Document
{
  public abstract class UniXlToClosedXmlWriterBase<T> : UniXlToWriterBase<
  #nullable disable
  T> where T : UniXlToClosedXmlWriterBase<T>, new()
  {
    public string XlsxTitle { get; set; }

    public string XlsxDesciption { get; set; }

    public string XlsxTimeStamp { get; set; } = System.DateTime.Now.ToString("yyyy-MM-dd ddd HH:mm:ss");

    public UniXlToClosedXmlWriterBase()
    {
    }

    public UniXlToClosedXmlWriterBase(UniXlInfo xl)
      : base(xl)
    {
    }

    public async Task SaveToXlsxFileAsync(
      string savePath,
      IProgress<double> progress = null,
      CancellationToken token = default (CancellationToken))
    {
      UniXlToClosedXmlWriterBase<T> closedXmlWriterBase = this;
      double p = 0.0;
      progress?.Report(p);
      using (XLWorkbook book = new XLWorkbook())
      {
        token.ThrowIfCancellationRequested();
        for (int iSheet = 1; iSheet <= closedXmlWriterBase.Document.Sheets.Count; ++iSheet)
        {
          token.ThrowIfCancellationRequested();
          UniXlSheetInfo sheet = closedXmlWriterBase.Document.Sheets[iSheet - 1];
          IXLWorksheet xlSheet = string.IsNullOrEmpty(sheet.Name) ? book.Worksheets.Add() : book.Worksheets.Add(sheet.Name);
          UniXlTableInfo table = sheet.Tables.FirstOrDefault<UniXlTableInfo>();
          int writeRowLine = 1;
          ++writeRowLine;
          writeRowLine += table.HeaderDepth;
          IXLRow xlRow1 = xlSheet.Row(writeRowLine);
          IXLRange headersRange = await closedXmlWriterBase.WriteColumnsCellsAsync(table, xlRow1.Cell(1));
          ++writeRowLine;
          progress?.Report(p = 0.1);
          IXLColumn xlColumn1 = headersRange.FirstCell().WorksheetColumn();
          IXLColumn xlColumn2 = headersRange.LastCell().WorksheetColumn();
          IXLCell firstCell = xlColumn1.FirstCell();
          IXLCell lastCell = xlColumn2.FirstCell();
          IXLRange xlRange1 = xlSheet.Range(firstCell, lastCell).Merge();
          xlRange1.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
          xlRange1.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
          xlRange1.Value = (object) closedXmlWriterBase.XlsxTitle;
          IXLCell xlCell = lastCell.CellBelow();
          xlCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
          xlCell.Value = (object) closedXmlWriterBase.XlsxTimeStamp;
          IXLRange xlRange2 = xlSheet.Range(firstCell.CellBelow(), xlCell.CellLeft()).Merge();
          xlRange2.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
          xlRange2.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
          xlRange2.Value = (object) closedXmlWriterBase.XlsxDesciption;
          IXLRow xlRow2 = xlSheet.Row(writeRowLine);
          IXLRange rowsRange = await closedXmlWriterBase.WriteRowsCellsAsync(table, xlRow2.Cell(1), (IProgress<double>) new Progress<double>((Action<double>) (it => progress?.Report(p + it * 0.7))));
          writeRowLine += rowsRange.RowCount();
          progress?.Report(p = 0.8);
          IXLRow xlRow3 = xlSheet.Row(writeRowLine);
          IXLRange xlRange3 = await closedXmlWriterBase.WriteColumnFooterCellsAsync(table, xlRow3.Cell(1));
          writeRowLine += xlRange3.RowCount();
          progress?.Report(p = 0.9);
          headersRange.Style.Fill.BackgroundColor = XLColor.LightGray;
          headersRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
          headersRange.Style.Border.OutsideBorderColor = XLColor.Black;
          headersRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
          headersRange.Style.Border.InsideBorderColor = XLColor.Black;
          rowsRange.Style.Fill.BackgroundColor = XLColor.White;
          rowsRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
          rowsRange.Style.Border.OutsideBorderColor = XLColor.Black;
          rowsRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
          rowsRange.Style.Border.InsideBorderColor = XLColor.LightGray;
          xlRange3.Style.Fill.BackgroundColor = XLColor.LightGray;
          xlRange3.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
          xlRange3.Style.Border.OutsideBorderColor = XLColor.Black;
          xlRange3.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
          xlRange3.Style.Border.InsideBorderColor = XLColor.Black;
          IXLRange xlRange4 = xlSheet.Range(headersRange.FirstCell(), xlRange3.LastCell());
          xlRange4.Style.Border.OutsideBorder = XLBorderStyleValues.Medium;
          xlRange4.Style.Border.OutsideBorderColor = XLColor.Black;
          xlSheet.ColumnsUsed().AdjustToContents();
          xlSheet = (IXLWorksheet) null;
          table = (UniXlTableInfo) null;
          headersRange = (IXLRange) null;
          rowsRange = (IXLRange) null;
        }
        token.ThrowIfCancellationRequested();
        await Task.Factory.StartNew((Action) (() => book.SaveAs(savePath)));
        IProgress<double> progress1 = progress;
        if (progress1 == null)
          ;
        else
          progress1.Report(p = 1.0);
      }
    }

    private async Task<IXLRange> WriteColumnFooterCellsAsync(
      UniXlTableInfo table,
      IXLCell startCell)
    {
      IXLCell endCell = startCell;
      IXLWorksheet sheet = startCell.Worksheet;
      IXLCell writeCell = startCell;
      await Task.Factory.StartNew((Action) (() =>
      {
        for (int index = 1; index <= table.Columns.Count; ++index)
        {
          UniXlColumnInfo col = table.Columns[index - 1];
          UniXlTableRowInfo columnFooter = table.ColumnFooter;
          UniXlTableCellInfo uniXlTableCellInfo = columnFooter.Cells.FirstOrDefault<UniXlTableCellInfo>((Func<UniXlTableCellInfo, bool>) (it => it.Column == col));
          if (uniXlTableCellInfo != null)
          {
            writeCell.Value = uniXlTableCellInfo.Value;
            Color? nullable1 = col.Foreground;
            Color? nullable2;
            Color? nullable3;
            if (!nullable1.HasValue)
            {
              nullable2 = columnFooter.Foreground;
              nullable3 = nullable2 ?? uniXlTableCellInfo.Foreground;
            }
            else
              nullable3 = nullable1;
            nullable2 = nullable3;
            ref Color? local1 = ref nullable2;
            if (local1.HasValue)
              local1.GetValueOrDefault().Action<Color>((Action<Color>) (it => writeCell.Style.Font.FontColor = XLColor.FromColor(it)));
            nullable1 = col.Background;
            Color? nullable4;
            if (!nullable1.HasValue)
            {
              nullable2 = columnFooter.Foreground;
              nullable4 = nullable2 ?? uniXlTableCellInfo.Background;
            }
            else
              nullable4 = nullable1;
            nullable2 = nullable4;
            ref Color? local2 = ref nullable2;
            if (local2.HasValue)
              local2.GetValueOrDefault().Action<Color>((Action<Color>) (it => writeCell.Style.Fill.BackgroundColor = XLColor.FromColor(it)));
            writeCell.Style.Font.Bold = uniXlTableCellInfo.IsBold;
            writeCell.Style.Font.Italic = uniXlTableCellInfo.IsItalic;
            if (uniXlTableCellInfo.IsUnderline)
              writeCell.Style.Font.Underline = XLFontUnderlineValues.Single;
          }
          endCell = writeCell;
          writeCell = writeCell.CellRight();
        }
      })).ConfigureAwait(false);
      IXLRange xlRange = sheet.Range(startCell, endCell);
      sheet = (IXLWorksheet) null;
      return xlRange;
    }

    private async Task<IXLRange> WriteRowsCellsAsync(
      UniXlTableInfo table,
      IXLCell startCell,
      IProgress<double> progress = null)
    {
      IXLCell endCell = startCell;
      IXLWorksheet sheet = startCell.Worksheet;
      int columnsCount = table.Columns.Count;
      await Task.Factory.StartNew((Action) (() =>
      {
        for (int index = 1; index <= columnsCount; ++index)
        {
          IXLCell xlCell = startCell.CellRight(index - 1);
          UniXlColumnInfo col = table.Columns[index - 1];
          IXLCell writeCell = xlCell;
          foreach ((UniXlTableRowInfo uniXlTableRowInfo, UniXlTableCellInfo uniXlTableCellInfo) in table.Rows.Select<UniXlTableRowInfo, (UniXlTableRowInfo, UniXlTableCellInfo)>((Func<UniXlTableRowInfo, (UniXlTableRowInfo, UniXlTableCellInfo)>) (xRow => (xRow, xRow.Cells.FirstOrDefault<UniXlTableCellInfo>((Func<UniXlTableCellInfo, bool>) (it => it.Column == col))))))
          {
            writeCell.DataType = XLDataType.Text;
            if (uniXlTableCellInfo != null && uniXlTableCellInfo.Value != null)
            {
              writeCell.Value = uniXlTableCellInfo.Value;
              Color? nullable1 = col.Foreground ?? uniXlTableRowInfo.Foreground ?? uniXlTableCellInfo.Foreground;
              ref Color? local1 = ref nullable1;
              if (local1.HasValue)
                local1.GetValueOrDefault().Action<Color>((Action<Color>) (it => writeCell.Style.Font.FontColor = XLColor.FromColor(it)));
              Color? background = col.Background;
              Color? nullable2;
              if (!background.HasValue)
              {
                nullable1 = uniXlTableRowInfo.Background;
                nullable2 = nullable1 ?? uniXlTableCellInfo.Background;
              }
              else
                nullable2 = background;
              nullable1 = nullable2;
              ref Color? local2 = ref nullable1;
              if (local2.HasValue)
                local2.GetValueOrDefault().Action<Color>((Action<Color>) (it => writeCell.Style.Fill.BackgroundColor = XLColor.FromColor(it)));
              writeCell.Style.Font.Bold = uniXlTableCellInfo.IsBold;
              writeCell.Style.Font.Italic = uniXlTableCellInfo.IsItalic;
              if (uniXlTableCellInfo.IsUnderline)
                writeCell.Style.Font.Underline = XLFontUnderlineValues.Single;
            }
            endCell = writeCell;
            writeCell = writeCell.CellBelow();
          }
          xlCell.WorksheetColumn().AdjustToContents();
          progress?.Report((double) (index / columnsCount));
        }
      })).ConfigureAwait(false);
      IXLRange xlRange = sheet.Range(startCell, endCell);
      sheet = (IXLWorksheet) null;
      return xlRange;
    }

    private async Task<IXLRange> WriteColumnsCellsAsync(UniXlTableInfo table, IXLCell startCell)
    {
      IXLCell endCell = (IXLCell) null;
      IXLWorksheet sheet = startCell.Worksheet;
      IXLCell cLevelStartCell = startCell;
      List<UniXlColumnInfo> cLevelColumns = table.Columns;
      List<UniXlColumnInfo> parentLavelColumns = new List<UniXlColumnInfo>();
      await Task.Factory.StartNew((Action) (() =>
      {
        while (cLevelColumns.Any<UniXlColumnInfo>((Func<UniXlColumnInfo, bool>) (it => it != null)))
        {
          IXLCell wCell = cLevelStartCell;
          startCell = wCell;
          UniXlColumnInfo uniXlColumnInfo1 = (UniXlColumnInfo) null;
          IXLCell firstCell = (IXLCell) null;
          IXLCell lastCell = (IXLCell) null;
          for (int index = 1; index <= cLevelColumns.Count; ++index)
          {
            UniXlColumnInfo uniXlColumnInfo2 = cLevelColumns[index - 1];
            UniXlColumnInfo uniXlColumnInfo3 = index < cLevelColumns.Count ? cLevelColumns[index] : (UniXlColumnInfo) null;
            bool flag = uniXlColumnInfo2 == uniXlColumnInfo3 && uniXlColumnInfo2 != null && uniXlColumnInfo3 != null;
            if (uniXlColumnInfo2 == null)
            {
              wCell = wCell.CellRight();
            }
            else
            {
              parentLavelColumns.Add(uniXlColumnInfo2.ParentColumn);
              if (uniXlColumnInfo1 == null)
              {
                uniXlColumnInfo1 = uniXlColumnInfo2;
                firstCell = wCell;
                lastCell = wCell;
              }
              if (uniXlColumnInfo1 == uniXlColumnInfo2)
                lastCell = wCell;
              if (flag)
              {
                wCell = wCell.CellRight();
              }
              else
              {
                firstCell.Value = (object) uniXlColumnInfo1.Header;
                Color? headerForeground = uniXlColumnInfo1.HeaderForeground;
                ref Color? local1 = ref headerForeground;
                if (local1.HasValue)
                  local1.GetValueOrDefault().Action<Color>((Action<Color>) (it => wCell.Style.Font.FontColor = XLColor.FromColor(it)));
                Color? headerBackground = uniXlColumnInfo1.HeaderBackground;
                ref Color? local2 = ref headerBackground;
                if (local2.HasValue)
                  local2.GetValueOrDefault().Action<Color>((Action<Color>) (it => wCell.Style.Fill.BackgroundColor = XLColor.FromColor(it)));
                if (firstCell != lastCell)
                {
                  firstCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                  firstCell.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                  firstCell.Style.Alignment.WrapText = true;
                  sheet.Range(firstCell, lastCell).Merge();
                }
                uniXlColumnInfo1 = (UniXlColumnInfo) null;
                firstCell = (IXLCell) null;
                lastCell = (IXLCell) null;
                wCell = wCell.CellRight();
              }
            }
          }
          if (endCell == null)
            endCell = wCell;
          cLevelStartCell = cLevelStartCell.CellAbove();
          cLevelColumns = parentLavelColumns;
          parentLavelColumns = new List<UniXlColumnInfo>();
        }
      })).ConfigureAwait(false);
      return sheet.Range(startCell, startCell == endCell ? startCell : endCell?.CellLeft() ?? startCell);
    }
  }
}
