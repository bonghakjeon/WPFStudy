// Decompiled with JetBrains decompiler
// Type: UniBizBO.Composition.TableColumnInfoExtension
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using System;
using System.Collections.Generic;
using System.Linq;
using UniinfoNet.Windows;
using UniinfoNet.Windows.Wpf.DataView;

namespace UniBizBO.Composition
{
  public static class TableColumnInfoExtension
  {
    public static void AddTableColumnInfos(
      this UniDataViewDescription obj,
      IEnumerable<TableColumnInfo> tColInfos)
    {
      if (tColInfos == null)
        return;
      SafeObservableCollection<UniDataColumnView> coldiss = obj.ColumnViews;
      List<UniDataColumnView> list = tColInfos.Select<TableColumnInfo, (string, bool)>((Func<TableColumnInfo, (string, bool)>) (it => (it.PropertyName, it.IsVisible))).Where<(string, bool)>((Func<(string, bool), bool>) (it => !coldiss.Any<UniDataColumnView>((Func<UniDataColumnView, bool>) (c => string.Equals(it.PropertyName, c.Key))))).Select<(string, bool), UniDataColumnView>((Func<(string, bool), UniDataColumnView>) (it => new UniDataColumnView()
      {
        Key = it.PropertyName,
        IsDisplay = it.IsVisible
      })).ToList<UniDataColumnView>();
      coldiss.AddRange((IEnumerable<UniDataColumnView>) list);
    }
  }
}
