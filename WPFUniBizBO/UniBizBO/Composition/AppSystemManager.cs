// Decompiled with JetBrains decompiler
// Type: UniBizBO.Composition.AppSystemManager
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using StyletIoC;
using System;
using System.Collections.Generic;
using System.Linq;
using UniBiz.Bo.Models.UniBase.CommonCode;
using UniBiz.Bo.Models.UniBase.ProgOption;
using UniinfoNet;


#nullable enable
namespace UniBizBO.Composition
{
  public class AppSystemManager : BindableBase
  {
    private 
    #nullable disable
    CommonCodeGroupDic commonCodes;
    private ProgOptionGroupDic _ProgOptions;
    private TableColumnDictionary tableColumns;

    public IContainer Container { get; set; }

    public AppSystemManager(IContainer container) => this.Container = container;

    public CommonCodeGroupDic CommonCodes
    {
      get => this.commonCodes ?? (this.commonCodes = new CommonCodeGroupDic());
      set
      {
        this.commonCodes = value;
        this.Changed(nameof (CommonCodes));
      }
    }

    public ProgOptionGroupDic ProgOptions
    {
      get => this._ProgOptions ?? (this._ProgOptions = new ProgOptionGroupDic());
      set
      {
        this._ProgOptions = value;
        this.Changed(nameof (ProgOptions));
      }
    }

    public TableColumnDictionary TableColumns
    {
      get => this.tableColumns ?? (this.tableColumns = new TableColumnDictionary());
      set
      {
        this.tableColumns = value;
        this.Changed(nameof (TableColumns));
      }
    }

    public void UpdateTableColumns() => this.TableColumns.SelectMany<KeyValuePair<Type, IReadOnlyList<TableColumnInfo>>, TableColumnInfo>((Func<KeyValuePair<Type, IReadOnlyList<TableColumnInfo>>, IEnumerable<TableColumnInfo>>) (it => (IEnumerable<TableColumnInfo>) it.Value)).ToList<TableColumnInfo>().ForEach((Action<TableColumnInfo>) (colInfo =>
    {
      CommonCodeGroup commonCode = this.CommonCodes[colInfo.CTypeNum];
      colInfo.CTypeGroupRaw = commonCode;
    }));
  }
}
