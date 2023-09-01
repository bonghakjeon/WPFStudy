// Decompiled with JetBrains decompiler
// Type: UniinfoNet.Xl.UniXlTableInfo
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using UniinfoNet.Extensions;

namespace UniinfoNet.Xl
{
  public class UniXlTableInfo
  {
    private List<UniXlColumnInfo> columns;
    private List<UniXlTableRowInfo> rows;
    private UniXlTableRowInfo columnFooter;

    public string Name { get; set; }

    public List<UniXlColumnInfo> Columns
    {
      get => this.columns ?? (this.columns = new List<UniXlColumnInfo>());
      set => this.columns = value;
    }

    public List<UniXlTableRowInfo> Rows
    {
      get => this.rows ?? (this.rows = new List<UniXlTableRowInfo>());
      set => this.rows = value;
    }

    public UniXlTableRowInfo ColumnFooter
    {
      get => this.columnFooter ?? (this.columnFooter = new UniXlTableRowInfo());
      set => this.columnFooter = value;
    }

    public int HeaderDepth => this.CalcHeaderDepth((IEnumerable<UniXlColumnInfo>) this.Columns);

    protected int CalcHeaderDepth(IEnumerable<UniXlColumnInfo> cols, int currentDepth = 1)
    {
      if (cols == null || cols.Count<UniXlColumnInfo>() == 0)
        return currentDepth - 1;
      cols = cols.Where<UniXlColumnInfo>((Func<UniXlColumnInfo, bool>) (it => it.ParentColumn != null)).Select<UniXlColumnInfo, UniXlColumnInfo>((Func<UniXlColumnInfo, UniXlColumnInfo>) (it => it.ParentColumn));
      return this.CalcHeaderDepth(cols, ++currentDepth);
    }

    private string ConvertToSingleHeader(string[] headers, string separator = "_") => headers.ToStringWithSeparator(separator);

    public DataTable ToDataTable(string headerSeparator = "_")
    {
      DataTable dataTable = new DataTable(this.Name);
      Dictionary<UniXlColumnInfo, string> dictionary = new Dictionary<UniXlColumnInfo, string>();
      foreach (UniXlColumnInfo column1 in this.Columns)
      {
        string singleHeader = this.ConvertToSingleHeader(column1.GetHierarchyHeaders(), headerSeparator);
        if (!dictionary.Values.Contains<string>(singleHeader) && dictionary.TryAdd(column1, singleHeader))
        {
          DataColumn column2 = new DataColumn(singleHeader, typeof (string));
          dataTable.Columns.Add(column2);
        }
      }
      foreach (UniXlTableRowInfo row1 in this.Rows)
      {
        DataRow row2 = dataTable.NewRow();
        foreach (UniXlTableCellInfo cell in row1.Cells)
        {
          string columnName = dictionary[cell.Column];
          row2[columnName] = cell.Value;
        }
        dataTable.Rows.Add(row2);
      }
      return dataTable;
    }

    public override string ToString() => string.Format("{0} {1}, {2} [{3}]", (object) "Columns", (object) this.Columns.Count, (object) "Rows", (object) this.Rows.Count);
  }
}
