// Decompiled with JetBrains decompiler
// Type: UniinfoNet.Extensions.DataTableExtension
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


#nullable enable
namespace UniinfoNet.Extensions
{
  public static class DataTableExtension
  {
    public static void ChangeColumnName(this 
    #nullable disable
    DataTable obj, IDictionary<string, string> dic)
    {
      if (dic == null)
        return;
      obj.Columns.OfType<DataColumn>().ToList<DataColumn>().ForEach((Action<DataColumn>) (col =>
      {
        string str;
        if (!dic.TryGetValue(col.ColumnName, out str))
          return;
        col.ColumnName = str;
      }));
    }

    public static void RemoveNotExistColumn(this DataTable obj, IEnumerable<string> colNames)
    {
      if (colNames == null)
        return;
      obj.Columns.OfType<DataColumn>().ToList<DataColumn>().ForEach((Action<DataColumn>) (col =>
      {
        if (colNames.Any<string>((Func<string, bool>) (it => it.Equals(col.ColumnName))))
          return;
        obj.Columns.Remove(col);
      }));
    }

    public static void SortColumn(this DataTable obj, IEnumerable<string> colNames)
    {
      if (colNames == null)
        return;
      int index = 0;
      colNames.Select((v, i) => new{ i = i, v = v }).ToList().ForEach(iv =>
      {
        DataColumn dataColumn = obj.Columns.OfType<DataColumn>().FirstOrDefault<DataColumn>((Func<DataColumn, bool>) (it => it.ColumnName.Equals(iv.v)));
        if (dataColumn == null)
          return;
        dataColumn.Action<DataColumn>((Action<DataColumn>) (col => col.SetOrdinal(index++)));
      });
    }

    public static void Add(this DataTable obj, DataTable addDataTable)
    {
      List<string> originalColNameList = obj.Columns.Cast<DataColumn>().Select<DataColumn, string>((Func<DataColumn, string>) (col => col.ColumnName)).ToList<string>();
      List<DataColumn> addColList = addDataTable.Columns.Cast<DataColumn>().ToList<DataColumn>();
      addColList.ForEach((Action<DataColumn>) (col =>
      {
        if (originalColNameList.Contains(col.ColumnName))
          return;
        obj.Columns.Add(new DataColumn()
        {
          ColumnName = col.ColumnName,
          DataType = col.DataType,
          DefaultValue = col.DefaultValue
        });
      }));
      addDataTable.Rows.Cast<DataRow>().Select<DataRow, DataRow>((Func<DataRow, DataRow>) (dr =>
      {
        DataRow row = obj.NewRow();
        addColList.ForEach((Action<DataColumn>) (col => row[col.ColumnName] = dr[col.ColumnName]));
        return row;
      })).ToList<DataRow>().ForEach((Action<DataRow>) (row => obj.Rows.Add(row)));
    }

    public static DataTable ToDataTable(this IEnumerable<DataRow> obj)
    {
      DataTable result = new DataTable();
      List<DataRow> list = obj != null ? obj.ToList<DataRow>() : (List<DataRow>) null;
      // ISSUE: explicit non-virtual call
      if ((list != null ? __nonvirtual (list.Count) : 0) <= 0)
        return result;
      list.First<DataRow>().Table.Columns.OfType<DataColumn>().ToList<DataColumn>().ForEach((Action<DataColumn>) (x => result.Columns.Add(new DataColumn(x.ColumnName, x.DataType, x.Expression, x.ColumnMapping))));
      list.ForEach((Action<DataRow>) (r => result.Rows.Add(r.ItemArray)));
      return result;
    }

    public static async Task<DataTable> ToStringDataTableAsync<T>(
      this IEnumerable<T> obj,
      Func<PropertyInfo, bool> propertyFilter = null)
      where T : class
    {
      return await Task.Factory.StartNew<DataTable>((Func<DataTable>) (() => obj.ToStringDataTable<T>(propertyFilter)));
    }

    public static async Task CopyToStringDataTableAsync<T>(
      this IEnumerable<T> obj,
      DataTable destTable,
      Func<PropertyInfo, bool> propertyFilter = null)
      where T : class
    {
      await Task.Factory.StartNew((Action) (() => obj.CopyToStringDataTable<T>(destTable, propertyFilter)));
    }

    public static DataTable ToStringDataTable<T>(
      this IEnumerable<T> obj,
      Func<PropertyInfo, bool> propertyFilter = null)
      where T : class
    {
      DataTable destTable = new DataTable();
      obj.CopyToStringDataTable<T>(destTable, propertyFilter);
      return destTable;
    }

    public static void CopyToStringDataTable<T>(
      this IEnumerable<T> obj,
      DataTable destTable,
      Func<PropertyInfo, bool> propertyFilter = null)
      where T : class
    {
      List<PropertyInfo> pList = ((IEnumerable<PropertyInfo>) typeof (T).GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty)).ToList<PropertyInfo>();
      if (propertyFilter != null)
        pList = pList.Where<PropertyInfo>(propertyFilter).ToList<PropertyInfo>();
      pList.ForEach((Action<PropertyInfo>) (p => destTable.Columns.Add(new DataColumn(p.Name, typeof (string)))));
      if (obj == null)
        return;
      obj.OfType<object>().ToList<object>().ForEach((Action<object>) (o =>
      {
        DataRow row = destTable.NewRow();
        pList.ForEach((Action<PropertyInfo>) (p => row[p.Name] = (object) p.GetValue(o)?.ToString()));
        destTable.Rows.Add(row);
      }));
    }

    public static async Task<DataTable> ToStringDataTableAsync(
      this IEnumerable obj,
      Type type,
      Func<PropertyInfo, bool> propertyFilter = null)
    {
      return await Task.Factory.StartNew<DataTable>((Func<DataTable>) (() => obj.ToStringDataTable(type, propertyFilter)));
    }

    public static async Task CopyToStringDataTableAsync(
      this IEnumerable obj,
      DataTable destTable,
      Type type,
      Func<PropertyInfo, bool> propertyFilter = null)
    {
      await Task.Factory.StartNew((Action) (() => obj.CopyToStringDataTable(destTable, type, propertyFilter)));
    }

    public static DataTable ToStringDataTable(
      this IEnumerable obj,
      Type type,
      Func<PropertyInfo, bool> propertyFilter = null)
    {
      DataTable destTable = new DataTable();
      obj.CopyToStringDataTable(destTable, type, propertyFilter);
      return destTable;
    }

    public static void CopyToStringDataTable(
      this IEnumerable obj,
      DataTable destTable,
      Type type,
      Func<PropertyInfo, bool> propertyFilter = null)
    {
      if (type == (Type) null)
        return;
      List<PropertyInfo> pList = ((IEnumerable<PropertyInfo>) type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty)).ToList<PropertyInfo>();
      if (propertyFilter != null)
        pList = pList.Where<PropertyInfo>(propertyFilter).ToList<PropertyInfo>();
      pList.ForEach((Action<PropertyInfo>) (p => destTable.Columns.Add(new DataColumn(p.Name, typeof (string)))));
      obj.OfType<object>().ToList<object>().ForEach((Action<object>) (o =>
      {
        DataRow row = destTable.NewRow();
        pList.ForEach((Action<PropertyInfo>) (p => row[p.Name] = (object) p.GetValue(o)?.ToString()));
        destTable.Rows.Add(row);
      }));
    }

    public static void ToStringDataTableRealType(
      this IList obj,
      DataTable destTable,
      Func<PropertyInfo, bool> propertyFilter = null)
    {
      Type type1 = typeof (object);
      List<PropertyInfo> propertyInfoList = propertyFilter == null ? ((IEnumerable<PropertyInfo>) type1.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty)).ToList<PropertyInfo>() : ((IEnumerable<PropertyInfo>) type1.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty)).Where<PropertyInfo>(propertyFilter).ToList<PropertyInfo>();
      foreach (object obj1 in (IEnumerable) obj)
      {
        object o = obj1;
        Type type2 = o.GetType();
        if (!type1.Equals(type2))
        {
          type1 = type2;
          propertyInfoList = propertyFilter == null ? ((IEnumerable<PropertyInfo>) type1.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty)).ToList<PropertyInfo>() : ((IEnumerable<PropertyInfo>) type1.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty)).Where<PropertyInfo>(propertyFilter).ToList<PropertyInfo>();
        }
        propertyInfoList.ForEach((Action<PropertyInfo>) (p =>
        {
          if (destTable.Columns.Contains(p.Name))
            return;
          destTable.Columns.Add(new DataColumn(p.Name, typeof (string)));
        }));
        DataRow row = destTable.NewRow();
        propertyInfoList.ForEach((Action<PropertyInfo>) (p => row[p.Name] = (object) p.GetValue(o)?.ToString()));
        destTable.Rows.Add(row);
      }
    }

    public static bool TryConvertToDataTable(
      this string obj,
      out DataTable table,
      string columnSeparator = "\t",
      string rowSeparator = "\r\n")
    {
      table = (DataTable) null;
      try
      {
        table = obj.ConvertToDataTable(columnSeparator, rowSeparator);
      }
      catch (Exception ex)
      {
      }
      return table != null;
    }

    public static DataTable ConvertToDataTable(
      this string obj,
      string columnSeparator = "\t",
      string rowSeparator = "\r\n")
    {
      if (string.IsNullOrWhiteSpace(obj))
        return (DataTable) null;
      int length = obj.IndexOf(rowSeparator);
      if (length < 0)
        length = obj.Length;
      string[] source1 = obj.Substring(0, length).Split(columnSeparator);
      DataTable dataTable = new DataTable();
      DataColumn[] array = ((IEnumerable<string>) source1).Select<string, DataColumn>((Func<string, int, DataColumn>) ((it, index) => new DataColumn((string) null, typeof (string)))).ToArray<DataColumn>();
      int num = ((IEnumerable<DataColumn>) array).Count<DataColumn>();
      dataTable.Columns.AddRange(array);
      foreach (string str in obj.Split(rowSeparator))
      {
        if (string.IsNullOrWhiteSpace(str))
        {
          dataTable.Rows.Add();
        }
        else
        {
          string[] source2 = str.Split(columnSeparator);
          if (((IEnumerable<string>) source2).Count<string>() > num)
            return (DataTable) null;
          dataTable.Rows.Add((object[]) source2);
        }
      }
      return dataTable;
    }

    public static string ConvertToString(
      this DataTable obj,
      string columnSeparator = "\t",
      string rowSeparator = "\r\n")
    {
      StringBuilder stringBuilder = new StringBuilder();
      foreach (DataRow dataRow in obj.Rows.OfType<DataRow>())
      {
        stringBuilder.Append(dataRow.ItemArray.ToStringWithSeparator(columnSeparator));
        stringBuilder.Append(rowSeparator);
      }
      if (stringBuilder.Length >= rowSeparator.Length)
        stringBuilder.Length -= rowSeparator.Length;
      return stringBuilder.ToString();
    }
  }
}
