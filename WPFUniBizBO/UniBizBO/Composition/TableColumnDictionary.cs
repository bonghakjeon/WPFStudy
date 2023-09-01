// Decompiled with JetBrains decompiler
// Type: UniBizBO.Composition.TableColumnDictionary
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using UniinfoNet;

namespace UniBizBO.Composition
{
  public class TableColumnDictionary : 
    BindableBase,
    IReadOnlyDictionary<Type, IReadOnlyList<TableColumnInfo>>,
    IEnumerable<KeyValuePair<Type, IReadOnlyList<TableColumnInfo>>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<Type, IReadOnlyList<TableColumnInfo>>>
  {
    private Dictionary<Type, IReadOnlyList<TableColumnInfo>> source = new Dictionary<Type, IReadOnlyList<TableColumnInfo>>();

    public IReadOnlyDictionary<Type, IReadOnlyList<TableColumnInfo>> Source => (IReadOnlyDictionary<Type, IReadOnlyList<TableColumnInfo>>) this.source;

    public IReadOnlyList<TableColumnInfo> this[Type key]
    {
      get
      {
        if (key == (Type) null)
          return (IReadOnlyList<TableColumnInfo>) null;
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

    public void Clear() => this.source.Clear();

    public void Add(TableColumnInfo info)
    {
      IReadOnlyList<TableColumnInfo> tableColumnInfoList1;
      if (!this.source.TryGetValue(info.ClazzType, out tableColumnInfoList1))
      {
        tableColumnInfoList1 = (IReadOnlyList<TableColumnInfo>) new List<TableColumnInfo>();
        this.source.Add(info.ClazzType, tableColumnInfoList1);
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

    public IEnumerable<Type> Keys => this.Source.Keys;

    public IEnumerable<IReadOnlyList<TableColumnInfo>> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public bool ContainsKey(Type key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<Type, IReadOnlyList<TableColumnInfo>>> GetEnumerator() => this.Source.GetEnumerator();

    public bool TryGetValue(Type key, [MaybeNullWhen(false)] out IReadOnlyList<TableColumnInfo> value) => this.Source.TryGetValue(key, out value);

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();
  }
}
