// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Sys.TableCreate
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections.Generic;
using UniinfoNet;

namespace UniBiz.Bo.Models.Sys
{
  public class TableCreate : BindableBase
  {
    public bool _tc_is_table;
    public bool _tc_is_re_table;
    public bool _tc_is_data;
    public bool _tc_is_re_table_with_data;
    public string _tc_id;
    public string _tc_pwd;
    public int _tc_type;
    public long _tc_siteid;
    private IList<TableView> _lt_table = (IList<TableView>) new List<TableView>();

    public bool tc_is_table
    {
      get => this._tc_is_table;
      set
      {
        this._tc_is_table = value;
        this.Changed(nameof (tc_is_table));
      }
    }

    public bool tc_is_re_table
    {
      get => this._tc_is_re_table;
      set
      {
        this._tc_is_re_table = value;
        this.Changed(nameof (tc_is_re_table));
      }
    }

    public bool tc_is_data
    {
      get => this._tc_is_data;
      set
      {
        this._tc_is_data = value;
        this.Changed(nameof (tc_is_data));
      }
    }

    public bool tc_is_re_table_with_data
    {
      get => this._tc_is_re_table_with_data;
      set
      {
        this._tc_is_re_table_with_data = value;
        this.Changed(nameof (tc_is_re_table_with_data));
      }
    }

    public string tc_id
    {
      get => this._tc_id;
      set
      {
        this._tc_id = value;
        this.Changed(nameof (tc_id));
      }
    }

    public string tc_pwd
    {
      get => this._tc_pwd;
      set
      {
        this._tc_pwd = value;
        this.Changed(nameof (tc_pwd));
      }
    }

    public int tc_type
    {
      get => this._tc_type;
      set
      {
        this._tc_type = value;
        this.Changed(nameof (tc_type));
      }
    }

    public long tc_siteid
    {
      get => this._tc_siteid;
      set
      {
        this._tc_siteid = value;
        this.Changed(nameof (tc_siteid));
      }
    }

    public IList<TableView> lt_table
    {
      get => this._lt_table;
      set
      {
        this._lt_table = value;
        this.Changed(nameof (lt_table));
      }
    }
  }
}
