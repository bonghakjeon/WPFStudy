// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.TableInfo.TSchemaTable
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections.Generic;

namespace UniBiz.Bo.Models.TableInfo
{
  public class TSchemaTable : UbModelBase<TSchemaTable>
  {
    private string _table_catalog;
    private string _table_catalog_desc;
    private string _table_name;
    private string _table_desc;

    public string table_catalog
    {
      get => this._table_catalog;
      set
      {
        this._table_catalog = value;
        this.Changed(nameof (table_catalog));
      }
    }

    public string table_catalog_desc
    {
      get => this._table_catalog_desc;
      set
      {
        this._table_catalog_desc = value;
        this.Changed(nameof (table_catalog_desc));
      }
    }

    public string table_name
    {
      get => this._table_name;
      set
      {
        this._table_name = value;
        this.Changed(nameof (table_name));
      }
    }

    public string table_desc
    {
      get => this._table_desc;
      set
      {
        this._table_desc = value;
        this.Changed(nameof (table_desc));
      }
    }

    public TSchemaTable() => this.Clear();

    public override void Clear()
    {
      base.Clear();
      this.table_catalog = string.Empty;
      this.table_catalog_desc = string.Empty;
      this.table_name = string.Empty;
      this.table_desc = string.Empty;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TSchemaTable();

    public override object Clone()
    {
      TSchemaTable tschemaTable = base.Clone() as TSchemaTable;
      tschemaTable.table_catalog = this.table_catalog;
      tschemaTable.table_catalog_desc = this.table_catalog_desc;
      tschemaTable.table_name = this.table_name;
      tschemaTable.table_desc = this.table_desc;
      return (object) tschemaTable;
    }

    public void PutData(TSchemaTable pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.table_catalog = pSource.table_catalog;
      this.table_catalog_desc = pSource.table_catalog_desc;
      this.table_name = pSource.table_name;
      this.table_desc = pSource.table_desc;
    }

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("table_catalog", new TTableColumn()
      {
        tc_orgin_name = "table_catalog",
        tc_trans_name = "디비명"
      });
      columnInfo.Add("table_catalog_desc", new TTableColumn()
      {
        tc_orgin_name = "table_catalog_desc",
        tc_trans_name = "디비 설명"
      });
      columnInfo.Add("table_name", new TTableColumn()
      {
        tc_orgin_name = "table_name",
        tc_trans_name = "테이블명"
      });
      columnInfo.Add("table_desc", new TTableColumn()
      {
        tc_orgin_name = "table_desc",
        tc_trans_name = "테이블 설명"
      });
      return columnInfo;
    }
  }
}
