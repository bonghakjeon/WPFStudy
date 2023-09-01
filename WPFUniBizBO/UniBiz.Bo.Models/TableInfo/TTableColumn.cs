// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.TableInfo.TTableColumn
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Text.Json.Serialization;
using UniBiz.Bo.Models.Converter;
using UniBizUtil.Util;
using UniinfoNet;

namespace UniBiz.Bo.Models.TableInfo
{
  public class TTableColumn : BindableBase
  {
    private string _tc_orgin_name;
    private string _tc_trans_name;
    private string _tc_parents_name;
    private int _tc_col_status;
    private int _tc_comm_code;
    private string _tc_col_hint;
    private bool _tc_col_visible = true;

    public string tc_orgin_name
    {
      get => this._tc_orgin_name;
      set
      {
        this._tc_orgin_name = value;
        this.Changed(nameof (tc_orgin_name));
      }
    }

    public string tc_trans_name
    {
      get => this._tc_trans_name;
      set
      {
        this._tc_trans_name = value;
        this.Changed(nameof (tc_trans_name));
      }
    }

    public string tc_parents_name
    {
      get => this._tc_parents_name;
      set
      {
        this._tc_parents_name = value;
        this.Changed(nameof (tc_parents_name));
      }
    }

    [JsonIgnore]
    public int tc_col_status
    {
      get => this._tc_col_status;
      set
      {
        this._tc_col_status = value;
        this.Changed(nameof (tc_col_status));
      }
    }

    public string StatusDesc => this.tc_col_status != 0 ? Enum2StrConverter.ToTableColumnStatus(this.tc_col_status).ToDescription() : string.Empty;

    public bool IsJoin => (this.tc_col_status & 1) == 1;

    public bool IsAttribute => (this.tc_col_status & 2) == 2;

    public bool IsKey => (this.tc_col_status & 4) == 4;

    public bool IsRequired => (this.tc_col_status & 8) == 8;

    public int tc_comm_code
    {
      get => this._tc_comm_code;
      set
      {
        this._tc_comm_code = value;
        this.Changed(nameof (tc_comm_code));
      }
    }

    public string tc_col_hint
    {
      get => this._tc_col_hint;
      set
      {
        this._tc_col_hint = value;
        this.Changed(nameof (tc_col_hint));
      }
    }

    public bool tc_col_visible
    {
      get => this._tc_col_visible;
      set
      {
        this._tc_col_visible = value;
        this.Changed(nameof (tc_col_visible));
      }
    }

    public TTableColumn() => this.Clear();

    public void Clear()
    {
      this.tc_orgin_name = string.Empty;
      this.tc_trans_name = string.Empty;
      this.tc_parents_name = string.Empty;
      this.tc_col_status = 0;
      this.tc_comm_code = 0;
      this.tc_col_hint = string.Empty;
      this.tc_col_visible = true;
    }
  }
}
