// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UbRest.UbRestModelBase
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Text.Json.Serialization;
using UniinfoNet;

namespace UniBiz.Bo.Models.UbRest
{
  public abstract class UbRestModelBase : BindableBase
  {
    private int _db_status;

    public string message { get; set; }

    public int row_number { get; set; }

    public bool isError { get; set; }

    public bool isSuccess { get; set; }

    public abstract object _Key { get; }

    public int db_status
    {
      get => this._db_status;
      set
      {
        this._db_status = value;
        this.Changed(nameof (db_status));
        this.Changed("DB_STATUS");
      }
    }

    [JsonIgnore]
    public EnumDBStatus DB_STATUS
    {
      get => (EnumDBStatus) this.db_status;
      set
      {
        this.db_status = (int) value;
        this.Changed(nameof (DB_STATUS));
        this.Changed("IsNone");
        this.Changed("IsNew");
        this.Changed("IsNewNot");
        this.Changed("IsUpdate");
        this.Changed("IsSaved");
      }
    }

    public bool IsNone => this.DB_STATUS == EnumDBStatus.NONE;

    public bool IsNew => this.DB_STATUS == EnumDBStatus.NEW;

    public bool IsNewNot => this.DB_STATUS != EnumDBStatus.NEW;

    public bool IsUpdate => this.DB_STATUS == EnumDBStatus.UPDATE;

    public bool IsSaved => this.DB_STATUS == EnumDBStatus.SAVED;
  }
}
