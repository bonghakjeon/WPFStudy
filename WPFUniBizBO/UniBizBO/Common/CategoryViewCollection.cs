// Decompiled with JetBrains decompiler
// Type: UniBizBO.Common.CategoryViewCollection
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UniBizBO.Common
{
  public class CategoryViewCollection : BindableCollection<DataViewDescription.CategoryViewInfo>
  {
    public CategoryViewCollection()
    {
    }

    public CategoryViewCollection(
      IEnumerable<DataViewDescription.CategoryViewInfo> collection)
      : base(collection)
    {
    }

    public DataViewDescription.CategoryViewInfo this[string key] => this.FirstOrDefault<DataViewDescription.CategoryViewInfo>((Func<DataViewDescription.CategoryViewInfo, bool>) (it => string.Equals(it.Key, key)));
  }
}
