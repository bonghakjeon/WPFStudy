// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.TableInfo.TableColumnInfoDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UniinfoNet;

namespace UniBiz.Bo.Models.TableInfo
{
  public class TableColumnInfoDic : 
    BindableBase,
    IReadOnlyDictionary<Type, IReadOnlyList<TableColumnInfo>>,
    IEnumerable<KeyValuePair<Type, IReadOnlyList<TableColumnInfo>>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<Type, IReadOnlyList<TableColumnInfo>>>
  {
    private Dictionary<Type, IReadOnlyList<TableColumnInfo>> _Source = new Dictionary<Type, IReadOnlyList<TableColumnInfo>>();

    public IReadOnlyDictionary<Type, IReadOnlyList<TableColumnInfo>> Source => (IReadOnlyDictionary<Type, IReadOnlyList<TableColumnInfo>>) this._Source;

    public IEnumerable<Type> Keys => this.Source.Keys;

    public IEnumerable<IReadOnlyList<TableColumnInfo>> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public IReadOnlyList<TableColumnInfo> this[Type key]
    {
      get
      {
        IReadOnlyList<TableColumnInfo> tableColumnInfoList;
        return !this.Source.TryGetValue(key, out tableColumnInfoList) ? (IReadOnlyList<TableColumnInfo>) null : tableColumnInfoList;
      }
    }

    public IReadOnlyList<TableColumnInfo> GetList<T>() => this[typeof (T)];

    public IReadOnlyDictionary<string, TableColumnInfo> GetDictionary(Type key)
    {
      IReadOnlyList<TableColumnInfo> source1 = this[key];
      Dictionary<string, TableColumnInfo> dictionary = source1 != null ? source1.ToDictionary<TableColumnInfo, string, TableColumnInfo>((Func<TableColumnInfo, string>) (it => it.PropertyName), (Func<TableColumnInfo, TableColumnInfo>) (it => it)) : (Dictionary<string, TableColumnInfo>) null;
      if (dictionary == null)
      {
        IReadOnlyList<TableColumnInfo> source2 = this[this.Keys.FirstOrDefault<Type>((Func<Type, bool>) (it => it.IsAssignableFrom(key)))];
        dictionary = source2 != null ? source2.ToDictionary<TableColumnInfo, string, TableColumnInfo>((Func<TableColumnInfo, string>) (it => it.PropertyName), (Func<TableColumnInfo, TableColumnInfo>) (it => it)) : (Dictionary<string, TableColumnInfo>) null;
      }
      return (IReadOnlyDictionary<string, TableColumnInfo>) dictionary;
    }

    public IReadOnlyDictionary<string, TableColumnInfo> GetDictionary<T>() => this.GetDictionary(typeof (T));

    public void Clear() => this._Source.Clear();

    public void Add(TableColumnInfo info)
    {
      IReadOnlyList<TableColumnInfo> tableColumnInfoList1;
      if (!this._Source.TryGetValue(info.ClazzType, out tableColumnInfoList1))
      {
        tableColumnInfoList1 = (IReadOnlyList<TableColumnInfo>) new List<TableColumnInfo>();
        this._Source.Add(info.ClazzType, tableColumnInfoList1);
      }
      if (!(tableColumnInfoList1 is IList<TableColumnInfo> tableColumnInfoList2))
        return;
      tableColumnInfoList2.Add(info);
    }

    public void AddRange(IEnumerable<TableColumnInfo> infos)
    {
      foreach (TableColumnInfo info in infos)
        this.Add(info);
    }

    public bool ContainsKey(Type key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<Type, IReadOnlyList<TableColumnInfo>>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(Type key, [MaybeNullWhen(false)] out IReadOnlyList<TableColumnInfo> value) => this.Source.TryGetValue(key, out value);
  }
}
