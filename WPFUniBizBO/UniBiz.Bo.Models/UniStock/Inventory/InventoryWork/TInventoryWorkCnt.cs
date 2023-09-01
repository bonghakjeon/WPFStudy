// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Inventory.InventoryWork.TInventoryWorkCnt
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using Serilog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.TableInfo;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniStock.Inventory.InventoryWork
{
  public class TInventoryWorkCnt : UbModelBase<TInventoryWorkCnt>
  {
    private DateTime? _iwc_InventoryDate;
    private int _iwc_StoreCode;
    private long _iwc_SiteID;
    private int _iwc_WorkCnt;
    private DateTime? _iwc_WorkDate;
    private int _iwc_WorkEmployee;
    private int _iwc_AmountWorkCnt;
    private DateTime? _iwc_AmountWorkDate;
    private int _iwc_QtyWorkCnt;
    private DateTime? _iwc_QtyWorkDate;
    private int _iwc_WeightWorkCnt;
    private DateTime? _iwc_WeightWorkDate;
    private int _iwc_AllWorkCnt;
    private DateTime? _iwc_AllWorkDate;
    private int _iwc_MinusToZeroWorkCnt;
    private DateTime? _iwc_MinusToZeroWorkDate;
    private int _iwc_PoorToZeroWorkCnt;
    private DateTime? _iwc_PoorToZeroWorkDate;
    private int _iwc_UnRegToZeroWorkCnt;
    private DateTime? _iwc_UnRegToZeroWorkDate;

    public override object _Key => (object) new object[2]
    {
      (object) this.iwc_InventoryDate,
      (object) this.iwc_StoreCode
    };

    public DateTime? iwc_InventoryDate
    {
      get => this._iwc_InventoryDate;
      set
      {
        this._iwc_InventoryDate = value;
        this.Changed(nameof (iwc_InventoryDate));
        this.Changed("iwc_InventoryDateInt");
      }
    }

    [JsonIgnore]
    public int iwc_InventoryDateInt => this.iwc_InventoryDate.HasValue ? this.iwc_InventoryDate.Value.ToIntFormat() : 0;

    public int iwc_StoreCode
    {
      get => this._iwc_StoreCode;
      set
      {
        this._iwc_StoreCode = value;
        this.Changed(nameof (iwc_StoreCode));
      }
    }

    public long iwc_SiteID
    {
      get => this._iwc_SiteID;
      set
      {
        this._iwc_SiteID = value;
        this.Changed(nameof (iwc_SiteID));
      }
    }

    public int iwc_WorkCnt
    {
      get => this._iwc_WorkCnt;
      set
      {
        this._iwc_WorkCnt = value;
        this.Changed(nameof (iwc_WorkCnt));
      }
    }

    public DateTime? iwc_WorkDate
    {
      get => this._iwc_WorkDate;
      set
      {
        this._iwc_WorkDate = value;
        this.Changed(nameof (iwc_WorkDate));
      }
    }

    public int iwc_WorkEmployee
    {
      get => this._iwc_WorkEmployee;
      set
      {
        this._iwc_WorkEmployee = value;
        this.Changed(nameof (iwc_WorkEmployee));
      }
    }

    public int iwc_AmountWorkCnt
    {
      get => this._iwc_AmountWorkCnt;
      set
      {
        this._iwc_AmountWorkCnt = value;
        this.Changed(nameof (iwc_AmountWorkCnt));
      }
    }

    public DateTime? iwc_AmountWorkDate
    {
      get => this._iwc_AmountWorkDate;
      set
      {
        this._iwc_AmountWorkDate = value;
        this.Changed(nameof (iwc_AmountWorkDate));
      }
    }

    public int iwc_QtyWorkCnt
    {
      get => this._iwc_QtyWorkCnt;
      set
      {
        this._iwc_QtyWorkCnt = value;
        this.Changed(nameof (iwc_QtyWorkCnt));
      }
    }

    public DateTime? iwc_QtyWorkDate
    {
      get => this._iwc_QtyWorkDate;
      set
      {
        this._iwc_QtyWorkDate = value;
        this.Changed(nameof (iwc_QtyWorkDate));
      }
    }

    public int iwc_WeightWorkCnt
    {
      get => this._iwc_WeightWorkCnt;
      set
      {
        this._iwc_WeightWorkCnt = value;
        this.Changed(nameof (iwc_WeightWorkCnt));
      }
    }

    public DateTime? iwc_WeightWorkDate
    {
      get => this._iwc_WeightWorkDate;
      set
      {
        this._iwc_WeightWorkDate = value;
        this.Changed(nameof (iwc_WeightWorkDate));
      }
    }

    public int iwc_AllWorkCnt
    {
      get => this._iwc_AllWorkCnt;
      set
      {
        this._iwc_AllWorkCnt = value;
        this.Changed(nameof (iwc_AllWorkCnt));
      }
    }

    public DateTime? iwc_AllWorkDate
    {
      get => this._iwc_AllWorkDate;
      set
      {
        this._iwc_AllWorkDate = value;
        this.Changed(nameof (iwc_AllWorkDate));
      }
    }

    public int iwc_MinusToZeroWorkCnt
    {
      get => this._iwc_MinusToZeroWorkCnt;
      set
      {
        this._iwc_MinusToZeroWorkCnt = value;
        this.Changed(nameof (iwc_MinusToZeroWorkCnt));
      }
    }

    public DateTime? iwc_MinusToZeroWorkDate
    {
      get => this._iwc_MinusToZeroWorkDate;
      set
      {
        this._iwc_MinusToZeroWorkDate = value;
        this.Changed(nameof (iwc_MinusToZeroWorkDate));
      }
    }

    public int iwc_PoorToZeroWorkCnt
    {
      get => this._iwc_PoorToZeroWorkCnt;
      set
      {
        this._iwc_PoorToZeroWorkCnt = value;
        this.Changed(nameof (iwc_PoorToZeroWorkCnt));
      }
    }

    public DateTime? iwc_PoorToZeroWorkDate
    {
      get => this._iwc_PoorToZeroWorkDate;
      set
      {
        this._iwc_PoorToZeroWorkDate = value;
        this.Changed(nameof (iwc_PoorToZeroWorkDate));
      }
    }

    public int iwc_UnRegToZeroWorkCnt
    {
      get => this._iwc_UnRegToZeroWorkCnt;
      set
      {
        this._iwc_UnRegToZeroWorkCnt = value;
        this.Changed(nameof (iwc_UnRegToZeroWorkCnt));
      }
    }

    public DateTime? iwc_UnRegToZeroWorkDate
    {
      get => this._iwc_UnRegToZeroWorkDate;
      set
      {
        this._iwc_UnRegToZeroWorkDate = value;
        this.Changed(nameof (iwc_UnRegToZeroWorkDate));
      }
    }

    public TInventoryWorkCnt() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("iwc_InventoryDate", new TTableColumn()
      {
        tc_orgin_name = "iwc_InventoryDate",
        tc_trans_name = "재고조사일자"
      });
      columnInfo.Add("iwc_StoreCode", new TTableColumn()
      {
        tc_orgin_name = "iwc_StoreCode",
        tc_trans_name = "지점코드"
      });
      columnInfo.Add("iwc_SiteID", new TTableColumn()
      {
        tc_orgin_name = "iwc_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("iwc_WorkCnt", new TTableColumn()
      {
        tc_orgin_name = "iwc_WorkCnt",
        tc_trans_name = "작업건수"
      });
      columnInfo.Add("iwc_WorkDate", new TTableColumn()
      {
        tc_orgin_name = "iwc_WorkDate",
        tc_trans_name = "작업일자"
      });
      columnInfo.Add("iwc_WorkEmployee", new TTableColumn()
      {
        tc_orgin_name = "iwc_WorkEmployee",
        tc_trans_name = "작업자"
      });
      columnInfo.Add("iwc_AmountWorkCnt", new TTableColumn()
      {
        tc_orgin_name = "iwc_AmountWorkCnt",
        tc_trans_name = "금액 작업 건수"
      });
      columnInfo.Add("iwc_AmountWorkDate", new TTableColumn()
      {
        tc_orgin_name = "iwc_AmountWorkDate",
        tc_trans_name = "금액 작업일시"
      });
      columnInfo.Add("iwc_QtyWorkCnt", new TTableColumn()
      {
        tc_orgin_name = "iwc_QtyWorkCnt",
        tc_trans_name = "수량 작업 건수"
      });
      columnInfo.Add("iwc_QtyWorkDate", new TTableColumn()
      {
        tc_orgin_name = "iwc_QtyWorkDate",
        tc_trans_name = "수량 작업일시"
      });
      columnInfo.Add("iwc_WeightWorkCnt", new TTableColumn()
      {
        tc_orgin_name = "iwc_WeightWorkCnt",
        tc_trans_name = "중량 작업 건수"
      });
      columnInfo.Add("iwc_WeightWorkDate", new TTableColumn()
      {
        tc_orgin_name = "iwc_WeightWorkDate",
        tc_trans_name = "중량 작업일시"
      });
      columnInfo.Add("iwc_AllWorkCnt", new TTableColumn()
      {
        tc_orgin_name = "iwc_AllWorkCnt",
        tc_trans_name = "전체 재고조사 작업 건수"
      });
      columnInfo.Add("iwc_MinusToZeroWorkCnt", new TTableColumn()
      {
        tc_orgin_name = "iwc_MinusToZeroWorkCnt",
        tc_trans_name = "마이너스재고 0 처리 건수"
      });
      columnInfo.Add("iwc_PoorToZeroWorkCnt", new TTableColumn()
      {
        tc_orgin_name = "iwc_PoorToZeroWorkCnt",
        tc_trans_name = "불량재고 0 처리 건수"
      });
      columnInfo.Add("iwc_UnRegToZeroWorkCnt", new TTableColumn()
      {
        tc_orgin_name = "iwc_UnRegToZeroWorkCnt",
        tc_trans_name = "미등록 로케이션 0 처리 건수"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.InventoryWorkCnt;
      this.iwc_InventoryDate = new DateTime?();
      this.iwc_StoreCode = 0;
      this.iwc_SiteID = 0L;
      this.iwc_WorkCnt = 0;
      this.iwc_WorkDate = new DateTime?();
      this.iwc_WorkEmployee = 0;
      this.iwc_AmountWorkCnt = 0;
      this.iwc_AmountWorkDate = new DateTime?();
      this.iwc_QtyWorkCnt = 0;
      this.iwc_QtyWorkDate = new DateTime?();
      this.iwc_WeightWorkCnt = 0;
      this.iwc_WeightWorkDate = new DateTime?();
      this.iwc_AllWorkCnt = 0;
      this.iwc_AllWorkDate = new DateTime?();
      this.iwc_MinusToZeroWorkCnt = 0;
      this.iwc_MinusToZeroWorkDate = new DateTime?();
      this.iwc_PoorToZeroWorkCnt = 0;
      this.iwc_PoorToZeroWorkDate = new DateTime?();
      this.iwc_UnRegToZeroWorkCnt = 0;
      this.iwc_UnRegToZeroWorkDate = new DateTime?();
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TInventoryWorkCnt();

    public override object Clone()
    {
      TInventoryWorkCnt tinventoryWorkCnt = base.Clone() as TInventoryWorkCnt;
      tinventoryWorkCnt.iwc_InventoryDate = this.iwc_InventoryDate;
      tinventoryWorkCnt.iwc_StoreCode = this.iwc_StoreCode;
      tinventoryWorkCnt.iwc_SiteID = this.iwc_SiteID;
      tinventoryWorkCnt.iwc_WorkCnt = this.iwc_WorkCnt;
      tinventoryWorkCnt.iwc_WorkDate = this.iwc_WorkDate;
      tinventoryWorkCnt.iwc_WorkEmployee = this.iwc_WorkEmployee;
      tinventoryWorkCnt.iwc_AmountWorkCnt = this.iwc_AmountWorkCnt;
      tinventoryWorkCnt.iwc_AmountWorkDate = this.iwc_AmountWorkDate;
      tinventoryWorkCnt.iwc_QtyWorkCnt = this.iwc_QtyWorkCnt;
      tinventoryWorkCnt.iwc_QtyWorkDate = this.iwc_QtyWorkDate;
      tinventoryWorkCnt.iwc_WeightWorkCnt = this.iwc_WeightWorkCnt;
      tinventoryWorkCnt.iwc_WeightWorkDate = this.iwc_WeightWorkDate;
      tinventoryWorkCnt.iwc_AllWorkCnt = this.iwc_AllWorkCnt;
      tinventoryWorkCnt.iwc_AllWorkDate = this.iwc_AllWorkDate;
      tinventoryWorkCnt.iwc_MinusToZeroWorkCnt = this.iwc_MinusToZeroWorkCnt;
      tinventoryWorkCnt.iwc_MinusToZeroWorkDate = this.iwc_MinusToZeroWorkDate;
      tinventoryWorkCnt.iwc_PoorToZeroWorkCnt = this.iwc_PoorToZeroWorkCnt;
      tinventoryWorkCnt.iwc_PoorToZeroWorkDate = this.iwc_PoorToZeroWorkDate;
      tinventoryWorkCnt.iwc_UnRegToZeroWorkCnt = this.iwc_UnRegToZeroWorkCnt;
      tinventoryWorkCnt.iwc_UnRegToZeroWorkDate = this.iwc_UnRegToZeroWorkDate;
      return (object) tinventoryWorkCnt;
    }

    public void PutData(TInventoryWorkCnt pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.iwc_InventoryDate = pSource.iwc_InventoryDate;
      this.iwc_StoreCode = pSource.iwc_StoreCode;
      this.iwc_SiteID = pSource.iwc_SiteID;
      this.iwc_WorkCnt = pSource.iwc_WorkCnt;
      this.iwc_WorkDate = pSource.iwc_WorkDate;
      this.iwc_WorkEmployee = pSource.iwc_WorkEmployee;
      this.iwc_AmountWorkCnt = pSource.iwc_AmountWorkCnt;
      this.iwc_AmountWorkDate = pSource.iwc_AmountWorkDate;
      this.iwc_QtyWorkCnt = pSource.iwc_QtyWorkCnt;
      this.iwc_QtyWorkDate = pSource.iwc_QtyWorkDate;
      this.iwc_WeightWorkCnt = pSource.iwc_WeightWorkCnt;
      this.iwc_WeightWorkDate = pSource.iwc_WeightWorkDate;
      this.iwc_AllWorkCnt = pSource.iwc_AllWorkCnt;
      this.iwc_AllWorkDate = pSource.iwc_AllWorkDate;
      this.iwc_MinusToZeroWorkCnt = pSource.iwc_MinusToZeroWorkCnt;
      this.iwc_MinusToZeroWorkDate = pSource.iwc_MinusToZeroWorkDate;
      this.iwc_PoorToZeroWorkCnt = pSource.iwc_PoorToZeroWorkCnt;
      this.iwc_PoorToZeroWorkDate = pSource.iwc_PoorToZeroWorkDate;
      this.iwc_UnRegToZeroWorkCnt = pSource.iwc_UnRegToZeroWorkCnt;
      this.iwc_UnRegToZeroWorkDate = pSource.iwc_UnRegToZeroWorkDate;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.iwc_InventoryDate = p_rs.GetFieldDateTime("iwc_InventoryDate");
        this.iwc_StoreCode = p_rs.GetFieldInt("iwc_StoreCode");
        if (this.iwc_StoreCode == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.iwc_SiteID = p_rs.GetFieldLong("iwc_SiteID");
        this.iwc_WorkCnt = p_rs.GetFieldInt("iwc_WorkCnt");
        this.iwc_WorkDate = p_rs.GetFieldDateTime("iwc_WorkDate");
        this.iwc_WorkEmployee = p_rs.GetFieldInt("iwc_WorkEmployee");
        this.iwc_AmountWorkCnt = p_rs.GetFieldInt("iwc_AmountWorkCnt");
        this.iwc_AmountWorkDate = p_rs.GetFieldDateTime("iwc_AmountWorkDate");
        this.iwc_QtyWorkCnt = p_rs.GetFieldInt("iwc_QtyWorkCnt");
        this.iwc_QtyWorkDate = p_rs.GetFieldDateTime("iwc_QtyWorkDate");
        this.iwc_WeightWorkCnt = p_rs.GetFieldInt("iwc_WeightWorkCnt");
        this.iwc_WeightWorkDate = p_rs.GetFieldDateTime("iwc_WeightWorkDate");
        this.iwc_AllWorkCnt = p_rs.GetFieldInt("iwc_AllWorkCnt");
        this.iwc_AllWorkDate = p_rs.GetFieldDateTime("iwc_AllWorkDate");
        this.iwc_MinusToZeroWorkCnt = p_rs.GetFieldInt("iwc_MinusToZeroWorkCnt");
        this.iwc_MinusToZeroWorkDate = p_rs.GetFieldDateTime("iwc_MinusToZeroWorkDate");
        this.iwc_PoorToZeroWorkCnt = p_rs.GetFieldInt("iwc_PoorToZeroWorkCnt");
        this.iwc_PoorToZeroWorkDate = p_rs.GetFieldDateTime("iwc_PoorToZeroWorkDate");
        this.iwc_UnRegToZeroWorkCnt = p_rs.GetFieldInt("iwc_UnRegToZeroWorkCnt");
        this.iwc_UnRegToZeroWorkDate = p_rs.GetFieldDateTime("iwc_UnRegToZeroWorkDate");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) this.TableCode) + " iwc_InventoryDate,iwc_StoreCode,iwc_SiteID,iwc_WorkCnt,iwc_WorkDate,iwc_WorkEmployee,iwc_AmountWorkCnt,iwc_AmountWorkDate,iwc_QtyWorkCnt,iwc_QtyWorkDate,iwc_WeightWorkCnt,iwc_WeightWorkDate,iwc_AllWorkCnt,iwc_AllWorkDate,iwc_MinusToZeroWorkCnt,iwc_MinusToZeroWorkDate,iwc_PoorToZeroWorkCnt,iwc_PoorToZeroWorkDate,iwc_UnRegToZeroWorkCnt,iwc_UnRegToZeroWorkDate) VALUES ( " + string.Format(" '{0}',{1}", (object) this.iwc_InventoryDate.GetDateToStr("yyyy-MM-dd 00:00:00"), (object) this.iwc_StoreCode) + string.Format(",{0}", (object) this.iwc_SiteID) + string.Format(",{0},{1},{2}", (object) this.iwc_WorkCnt, (object) this.iwc_WorkDate.GetDateToStrInNull(), (object) this.iwc_WorkEmployee) + string.Format(",{0},{1}", (object) this.iwc_AmountWorkCnt, (object) this.iwc_AmountWorkDate.GetDateToStrInNull()) + string.Format(",{0},{1}", (object) this.iwc_QtyWorkCnt, (object) this.iwc_QtyWorkDate.GetDateToStrInNull()) + string.Format(",{0},{1}", (object) this.iwc_WeightWorkCnt, (object) this.iwc_WeightWorkDate.GetDateToStrInNull()) + string.Format(",{0},{1}", (object) this.iwc_AllWorkCnt, (object) this.iwc_AllWorkDate.GetDateToStrInNull()) + string.Format(",{0},{1}", (object) this.iwc_MinusToZeroWorkCnt, (object) this.iwc_MinusToZeroWorkDate.GetDateToStrInNull()) + string.Format(",{0},{1}", (object) this.iwc_PoorToZeroWorkCnt, (object) this.iwc_PoorToZeroWorkDate.GetDateToStrInNull()) + string.Format(",{0},{1}", (object) this.iwc_UnRegToZeroWorkCnt, (object) this.iwc_UnRegToZeroWorkDate.GetDateToStrInNull()) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.iwc_InventoryDate.GetDateToStr("yyyy-MM-dd"), (object) this.iwc_StoreCode, (object) this.iwc_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TInventoryWorkCnt tinventoryWorkCnt = this;
      // ISSUE: reference to a compiler-generated method
      tinventoryWorkCnt.\u003C\u003En__0();
      if (await tinventoryWorkCnt.OleDB.ExecuteAsync(tinventoryWorkCnt.InsertQuery()))
        return true;
      tinventoryWorkCnt.message = " " + tinventoryWorkCnt.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tinventoryWorkCnt.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tinventoryWorkCnt.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tinventoryWorkCnt.iwc_InventoryDate.GetDateToStr("yyyy-MM-dd"), (object) tinventoryWorkCnt.iwc_StoreCode, (object) tinventoryWorkCnt.iwc_SiteID) + " 내용 : " + tinventoryWorkCnt.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tinventoryWorkCnt.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) this.TableCode) + string.Format(" {0}={1}", (object) "iwc_WorkCnt", (object) (this.iwc_WorkCnt > 0 ? 1 : 0)) + ",iwc_WorkDate=" + this.iwc_WorkDate.GetDateToStrInNull() + string.Format(",{0}={1}", (object) "iwc_WorkEmployee", (object) this.iwc_WorkEmployee) + string.Format(",{0}={1}", (object) "iwc_AmountWorkCnt", (object) (this.iwc_AmountWorkCnt > 0 ? 1 : 0)) + ",iwc_AmountWorkDate=" + this.iwc_AmountWorkDate.GetDateToStrInNull() + string.Format(",{0}={1}", (object) "iwc_QtyWorkCnt", (object) (this.iwc_QtyWorkCnt > 0 ? 1 : 0)) + ",iwc_QtyWorkDate=" + this.iwc_QtyWorkDate.GetDateToStrInNull() + string.Format(",{0}={1}", (object) "iwc_WeightWorkCnt", (object) (this.iwc_WeightWorkCnt > 0 ? 1 : 0)) + ",iwc_WeightWorkDate=" + this.iwc_WeightWorkDate.GetDateToStrInNull() + string.Format(",{0}={1}", (object) "iwc_AllWorkCnt", (object) (this.iwc_AllWorkCnt > 0 ? 1 : 0)) + ",iwc_AllWorkDate=" + this.iwc_AllWorkDate.GetDateToStrInNull() + string.Format(",{0}={1}", (object) "iwc_MinusToZeroWorkCnt", (object) (this.iwc_MinusToZeroWorkCnt > 0 ? 1 : 0)) + ",iwc_MinusToZeroWorkDate=" + this.iwc_MinusToZeroWorkDate.GetDateToStrInNull() + string.Format(",{0}={1}", (object) "iwc_PoorToZeroWorkCnt", (object) (this.iwc_PoorToZeroWorkCnt > 0 ? 1 : 0)) + ",iwc_PoorToZeroWorkDate=" + this.iwc_PoorToZeroWorkDate.GetDateToStrInNull() + string.Format(",{0}={1}", (object) "iwc_UnRegToZeroWorkCnt", (object) (this.iwc_UnRegToZeroWorkCnt > 0 ? 1 : 0)) + ",iwc_UnRegToZeroWorkDate=" + this.iwc_UnRegToZeroWorkDate.GetDateToStrInNull() + " WHERE iwc_InventoryDate='" + this.iwc_InventoryDate.GetDateToStr("yyyy-MM-dd 00:00:00") + "'" + string.Format(" AND {0}={1}", (object) "iwc_StoreCode", (object) this.iwc_StoreCode) + string.Format(" AND {0}={1}", (object) "iwc_SiteID", (object) this.iwc_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.iwc_InventoryDate.GetDateToStr("yyyy-MM-dd"), (object) this.iwc_StoreCode, (object) this.iwc_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TInventoryWorkCnt tinventoryWorkCnt = this;
      // ISSUE: reference to a compiler-generated method
      tinventoryWorkCnt.\u003C\u003En__1();
      if (await tinventoryWorkCnt.OleDB.ExecuteAsync(tinventoryWorkCnt.UpdateQuery()))
        return true;
      tinventoryWorkCnt.message = " " + tinventoryWorkCnt.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tinventoryWorkCnt.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tinventoryWorkCnt.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tinventoryWorkCnt.iwc_InventoryDate.GetDateToStr("yyyy-MM-dd"), (object) tinventoryWorkCnt.iwc_StoreCode, (object) tinventoryWorkCnt.iwc_SiteID) + " 내용 : " + tinventoryWorkCnt.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tinventoryWorkCnt.message);
      return false;
    }

    public override string UpdateExInsertMySQLQuery()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(this.InsertQuery());
      if (stringBuilder.ToString().Contains(";"))
      {
        string str = stringBuilder.ToString().Replace(";", string.Empty);
        stringBuilder.Clear();
        stringBuilder.Append(str);
      }
      stringBuilder.Append(" ON DUPLICATE KEY UPDATE ");
      stringBuilder.Append("\n");
      stringBuilder.Append(string.Format(" {0}={1}", (object) "iwc_WorkCnt", (object) (this.iwc_WorkCnt > 0 ? 1 : 0)) + ",iwc_WorkDate=" + this.iwc_WorkDate.GetDateToStrInNull() + string.Format(",{0}={1}", (object) "iwc_WorkEmployee", (object) this.iwc_WorkEmployee) + string.Format(",{0}={1}", (object) "iwc_AmountWorkCnt", (object) (this.iwc_AmountWorkCnt > 0 ? 1 : 0)) + ",iwc_AmountWorkDate=" + this.iwc_AmountWorkDate.GetDateToStrInNull() + string.Format(",{0}={1}", (object) "iwc_QtyWorkCnt", (object) (this.iwc_QtyWorkCnt > 0 ? 1 : 0)) + ",iwc_QtyWorkDate=" + this.iwc_QtyWorkDate.GetDateToStrInNull() + string.Format(",{0}={1}", (object) "iwc_WeightWorkCnt", (object) (this.iwc_WeightWorkCnt > 0 ? 1 : 0)) + ",iwc_WeightWorkDate=" + this.iwc_WeightWorkDate.GetDateToStrInNull() + string.Format(",{0}={1}", (object) "iwc_AllWorkCnt", (object) (this.iwc_AllWorkCnt > 0 ? 1 : 0)) + ",iwc_AllWorkDate=" + this.iwc_AllWorkDate.GetDateToStrInNull() + string.Format(",{0}={1}", (object) "iwc_MinusToZeroWorkCnt", (object) (this.iwc_MinusToZeroWorkCnt > 0 ? 1 : 0)) + ",iwc_MinusToZeroWorkDate=" + this.iwc_MinusToZeroWorkDate.GetDateToStrInNull() + string.Format(",{0}={1}", (object) "iwc_PoorToZeroWorkCnt", (object) (this.iwc_PoorToZeroWorkCnt > 0 ? 1 : 0)) + ",iwc_PoorToZeroWorkDate=" + this.iwc_PoorToZeroWorkDate.GetDateToStrInNull() + string.Format(",{0}={1}", (object) "iwc_UnRegToZeroWorkCnt", (object) (this.iwc_UnRegToZeroWorkCnt > 0 ? 1 : 0)) + ",iwc_UnRegToZeroWorkDate=" + this.iwc_UnRegToZeroWorkDate.GetDateToStrInNull());
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.iwc_InventoryDate.GetDateToStr("yyyy-MM-dd"), (object) this.iwc_StoreCode, (object) this.iwc_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TInventoryWorkCnt tinventoryWorkCnt = this;
      // ISSUE: reference to a compiler-generated method
      tinventoryWorkCnt.\u003C\u003En__1();
      if (await tinventoryWorkCnt.OleDB.ExecuteAsync(tinventoryWorkCnt.UpdateExInsertQuery()))
        return true;
      tinventoryWorkCnt.message = " " + tinventoryWorkCnt.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tinventoryWorkCnt.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tinventoryWorkCnt.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tinventoryWorkCnt.iwc_InventoryDate.GetDateToStr("yyyy-MM-dd"), (object) tinventoryWorkCnt.iwc_StoreCode, (object) tinventoryWorkCnt.iwc_SiteID) + " 내용 : " + tinventoryWorkCnt.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tinventoryWorkCnt.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "iwc_SiteID") && Convert.ToInt64(hashtable[(object) "iwc_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "iwc_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "iwc_InventoryDate"))
        {
          stringBuilder.Append(" AND iwc_InventoryDate >='" + new DateTime?((DateTime) hashtable[(object) "iwc_InventoryDate"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND iwc_InventoryDate <='" + new DateTime?((DateTime) hashtable[(object) "iwc_InventoryDate"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
        }
        if (hashtable.ContainsKey((object) "iwc_InventoryDate_BEGIN_") && hashtable.ContainsKey((object) "iwc_InventoryDate_END_"))
        {
          stringBuilder.Append(" AND iwc_InventoryDate >='" + new DateTime?((DateTime) hashtable[(object) "iwc_InventoryDate_BEGIN_"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND iwc_InventoryDate <='" + new DateTime?((DateTime) hashtable[(object) "iwc_InventoryDate_END_"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
        }
        if (hashtable.ContainsKey((object) "si_StoreCode") && Convert.ToInt32(hashtable[(object) "si_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "iwc_StoreCode", hashtable[(object) "si_StoreCode"]));
        else if (hashtable.ContainsKey((object) "iwc_StoreCode") && Convert.ToInt32(hashtable[(object) "iwc_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "iwc_StoreCode", hashtable[(object) "iwc_StoreCode"]));
        else if (hashtable.ContainsKey((object) "si_StoreCode_IN_") && hashtable[(object) "si_StoreCode_IN_"].ToString().Length > 0)
        {
          if (hashtable[(object) "si_StoreCode_IN_"].ToString().Contains(","))
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "iwc_StoreCode", hashtable[(object) "si_StoreCode_IN_"]));
          else
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "iwc_StoreCode", hashtable[(object) "si_StoreCode_IN_"]));
        }
        else if (hashtable.ContainsKey((object) "iwc_StoreCode_IN_") && hashtable[(object) "iwc_StoreCode_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "iwc_StoreCode", hashtable[(object) "iwc_StoreCode_IN_"]));
        else if (hashtable.ContainsKey((object) "_STORE_AUTHS_") && hashtable[(object) "_STORE_AUTHS_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "iwc_StoreCode", hashtable[(object) "_STORE_AUTHS_"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "iwc_SiteID", (object) num));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_"))
        {
          int length = hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length;
        }
      }
      return !stringBuilder.ToString().Equals(" WHERE") ? stringBuilder.Replace("WHERE AND", "WHERE").ToString() : string.Empty;
    }

    public override string GetSelectQuery(object p_param)
    {
      StringBuilder stringBuilder = new StringBuilder();
      try
      {
        string uniStock = UbModelBase.UNI_STOCK;
        string str = this.TableCode.ToString();
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniStock = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
        }
        stringBuilder.Append(" SELECT  iwc_InventoryDate,iwc_StoreCode,iwc_SiteID,iwc_WorkCnt,iwc_WorkDate,iwc_WorkEmployee,iwc_AmountWorkCnt,iwc_AmountWorkDate,iwc_QtyWorkCnt,iwc_QtyWorkDate,iwc_WeightWorkCnt,iwc_WeightWorkDate,iwc_AllWorkCnt,iwc_AllWorkDate,iwc_MinusToZeroWorkCnt,iwc_MinusToZeroWorkDate,iwc_PoorToZeroWorkCnt,iwc_PoorToZeroWorkDate,iwc_UnRegToZeroWorkCnt,iwc_UnRegToZeroWorkDate");
        stringBuilder.Append(" FROM " + DbQueryHelper.ToDBNameBridge(uniStock) + str + " " + DbQueryHelper.ToWithNolock());
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) ex.GetHashCode()) + " 내용 : " + ex.Message + "\n Query : " + stringBuilder.ToString() + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
        stringBuilder.Clear();
      }
      return stringBuilder.ToString();
    }
  }
}
