// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Profit.ProfitLossWork.TProfitLossWorkCnt
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

namespace UniBiz.Bo.Models.UniStock.Profit.ProfitLossWork
{
  public class TProfitLossWorkCnt : UbModelBase<TProfitLossWorkCnt>
  {
    private int _plwc_YyyyMm;
    private int _plwc_StoreCode;
    private long _plwc_SiteID;
    private int _plwc_WorkCnt;
    private DateTime? _plwc_WorkDate;
    private int _plwc_WorkEmployee;
    private int _plwc_ApplyCnt;
    private DateTime? _plwc_ApplyDate;
    private int _plwc_AmountWorkCnt;
    private DateTime? _plwc_AmountWorkDate;
    private int _plwc_QtyWorkCnt;
    private DateTime? _plwc_QtyWorkDate;
    private int _plwc_WeightWorkCnt;
    private DateTime? _plwc_WeightWorkDate;
    private int _plwc_MinusToZeroWorkCnt;
    private DateTime? _plwc_MinusToZeroWorkDate;
    private int _plwc_PoorToZeroWorkCnt;
    private DateTime? _plwc_PoorToZeroWorkDate;
    private DateTime? _plwc_OriginDate;

    public override object _Key => (object) new object[2]
    {
      (object) this.plwc_YyyyMm,
      (object) this.plwc_StoreCode
    };

    public int plwc_YyyyMm
    {
      get => this._plwc_YyyyMm;
      set
      {
        this._plwc_YyyyMm = value;
        this.Changed(nameof (plwc_YyyyMm));
        this.Changed("_dic_Key");
      }
    }

    public int plwc_StoreCode
    {
      get => this._plwc_StoreCode;
      set
      {
        this._plwc_StoreCode = value;
        this.Changed(nameof (plwc_StoreCode));
        this.Changed("_dic_Key");
      }
    }

    [JsonIgnore]
    public string _dic_Key => string.Format("{0}|{1}", (object) this.plwc_YyyyMm, (object) this.plwc_StoreCode);

    public long plwc_SiteID
    {
      get => this._plwc_SiteID;
      set
      {
        this._plwc_SiteID = value;
        this.Changed(nameof (plwc_SiteID));
      }
    }

    public int plwc_WorkCnt
    {
      get => this._plwc_WorkCnt;
      set
      {
        this._plwc_WorkCnt = value;
        this.Changed(nameof (plwc_WorkCnt));
      }
    }

    public DateTime? plwc_WorkDate
    {
      get => this._plwc_WorkDate;
      set
      {
        this._plwc_WorkDate = value;
        this.Changed(nameof (plwc_WorkDate));
      }
    }

    public int plwc_WorkEmployee
    {
      get => this._plwc_WorkEmployee;
      set
      {
        this._plwc_WorkEmployee = value;
        this.Changed(nameof (plwc_WorkEmployee));
      }
    }

    public int plwc_ApplyCnt
    {
      get => this._plwc_ApplyCnt;
      set
      {
        this._plwc_ApplyCnt = value;
        this.Changed(nameof (plwc_ApplyCnt));
      }
    }

    public DateTime? plwc_ApplyDate
    {
      get => this._plwc_ApplyDate;
      set
      {
        this._plwc_ApplyDate = value;
        this.Changed(nameof (plwc_ApplyDate));
      }
    }

    public int plwc_AmountWorkCnt
    {
      get => this._plwc_AmountWorkCnt;
      set
      {
        this._plwc_AmountWorkCnt = value;
        this.Changed(nameof (plwc_AmountWorkCnt));
      }
    }

    public DateTime? plwc_AmountWorkDate
    {
      get => this._plwc_AmountWorkDate;
      set
      {
        this._plwc_AmountWorkDate = value;
        this.Changed(nameof (plwc_AmountWorkDate));
      }
    }

    public int plwc_QtyWorkCnt
    {
      get => this._plwc_QtyWorkCnt;
      set
      {
        this._plwc_QtyWorkCnt = value;
        this.Changed(nameof (plwc_QtyWorkCnt));
      }
    }

    public DateTime? plwc_QtyWorkDate
    {
      get => this._plwc_QtyWorkDate;
      set
      {
        this._plwc_QtyWorkDate = value;
        this.Changed(nameof (plwc_QtyWorkDate));
      }
    }

    public int plwc_WeightWorkCnt
    {
      get => this._plwc_WeightWorkCnt;
      set
      {
        this._plwc_WeightWorkCnt = value;
        this.Changed(nameof (plwc_WeightWorkCnt));
      }
    }

    public DateTime? plwc_WeightWorkDate
    {
      get => this._plwc_WeightWorkDate;
      set
      {
        this._plwc_WeightWorkDate = value;
        this.Changed(nameof (plwc_WeightWorkDate));
      }
    }

    public int plwc_MinusToZeroWorkCnt
    {
      get => this._plwc_MinusToZeroWorkCnt;
      set
      {
        this._plwc_MinusToZeroWorkCnt = value;
        this.Changed(nameof (plwc_MinusToZeroWorkCnt));
      }
    }

    public DateTime? plwc_MinusToZeroWorkDate
    {
      get => this._plwc_MinusToZeroWorkDate;
      set
      {
        this._plwc_MinusToZeroWorkDate = value;
        this.Changed(nameof (plwc_MinusToZeroWorkDate));
      }
    }

    public int plwc_PoorToZeroWorkCnt
    {
      get => this._plwc_PoorToZeroWorkCnt;
      set
      {
        this._plwc_PoorToZeroWorkCnt = value;
        this.Changed(nameof (plwc_PoorToZeroWorkCnt));
      }
    }

    public DateTime? plwc_PoorToZeroWorkDate
    {
      get => this._plwc_PoorToZeroWorkDate;
      set
      {
        this._plwc_PoorToZeroWorkDate = value;
        this.Changed(nameof (plwc_PoorToZeroWorkDate));
      }
    }

    public DateTime? plwc_OriginDate
    {
      get => this._plwc_OriginDate;
      set
      {
        this._plwc_OriginDate = value;
        this.Changed(nameof (plwc_OriginDate));
      }
    }

    public TProfitLossWorkCnt() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("plwc_YyyyMm", new TTableColumn()
      {
        tc_orgin_name = "plwc_YyyyMm",
        tc_trans_name = "결산년월"
      });
      columnInfo.Add("plwc_StoreCode", new TTableColumn()
      {
        tc_orgin_name = "plwc_StoreCode",
        tc_trans_name = "지점코드"
      });
      columnInfo.Add("plwc_SiteID", new TTableColumn()
      {
        tc_orgin_name = "plwc_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("plwc_WorkCnt", new TTableColumn()
      {
        tc_orgin_name = "plwc_WorkCnt",
        tc_trans_name = "작업"
      });
      columnInfo.Add("plwc_WorkDate", new TTableColumn()
      {
        tc_orgin_name = "plwc_WorkDate",
        tc_trans_name = "작업일시"
      });
      columnInfo.Add("plwc_WorkEmployee", new TTableColumn()
      {
        tc_orgin_name = "plwc_WorkEmployee",
        tc_trans_name = "작업사원"
      });
      columnInfo.Add("plwc_ApplyCnt", new TTableColumn()
      {
        tc_orgin_name = "plwc_ApplyCnt",
        tc_trans_name = "재고 조정"
      });
      columnInfo.Add("plwc_ApplyDate", new TTableColumn()
      {
        tc_orgin_name = "plwc_ApplyDate",
        tc_trans_name = "재고 조정 일시"
      });
      columnInfo.Add("plwc_AmountWorkCnt", new TTableColumn()
      {
        tc_orgin_name = "plwc_AmountWorkCnt",
        tc_trans_name = "금액"
      });
      columnInfo.Add("plwc_AmountWorkDate", new TTableColumn()
      {
        tc_orgin_name = "plwc_AmountWorkDate",
        tc_trans_name = "금액 일시"
      });
      columnInfo.Add("plwc_QtyWorkCnt", new TTableColumn()
      {
        tc_orgin_name = "plwc_QtyWorkCnt",
        tc_trans_name = "수량"
      });
      columnInfo.Add("plwc_QtyWorkDate", new TTableColumn()
      {
        tc_orgin_name = "plwc_QtyWorkDate",
        tc_trans_name = "수량 일시"
      });
      columnInfo.Add("plwc_WeightWorkCnt", new TTableColumn()
      {
        tc_orgin_name = "plwc_WeightWorkCnt",
        tc_trans_name = "중량"
      });
      columnInfo.Add("plwc_WeightWorkDate", new TTableColumn()
      {
        tc_orgin_name = "plwc_WeightWorkDate",
        tc_trans_name = "중량 일시"
      });
      columnInfo.Add("plwc_MinusToZeroWorkCnt", new TTableColumn()
      {
        tc_orgin_name = "plwc_MinusToZeroWorkCnt",
        tc_trans_name = "마이너스재고 0 처리"
      });
      columnInfo.Add("plwc_MinusToZeroWorkDate", new TTableColumn()
      {
        tc_orgin_name = "plwc_MinusToZeroWorkDate",
        tc_trans_name = "마이너스재고 0 처리 일시"
      });
      columnInfo.Add("plwc_PoorToZeroWorkCnt", new TTableColumn()
      {
        tc_orgin_name = "plwc_PoorToZeroWorkCnt",
        tc_trans_name = "불량 재고 0 처리"
      });
      columnInfo.Add("plwc_PoorToZeroWorkDate", new TTableColumn()
      {
        tc_orgin_name = "plwc_PoorToZeroWorkDate",
        tc_trans_name = "불량 재고 0 처리 일시"
      });
      columnInfo.Add("plwc_OriginDate", new TTableColumn()
      {
        tc_orgin_name = "plwc_OriginDate",
        tc_trans_name = "작업 기준일자"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.ProfitLossWorkCnt;
      this.plwc_YyyyMm = this.plwc_StoreCode = 0;
      this.plwc_SiteID = 0L;
      this.plwc_WorkCnt = this.plwc_ApplyCnt = this.plwc_AmountWorkCnt = this.plwc_QtyWorkCnt = this.plwc_WeightWorkCnt = this.plwc_PoorToZeroWorkCnt = this.plwc_MinusToZeroWorkCnt = 0;
      this.plwc_WorkEmployee = 0;
      this.plwc_WorkDate = new DateTime?();
      this.plwc_ApplyDate = new DateTime?();
      this.plwc_AmountWorkDate = new DateTime?();
      this.plwc_QtyWorkDate = new DateTime?();
      this.plwc_WeightWorkDate = new DateTime?();
      this.plwc_PoorToZeroWorkDate = new DateTime?();
      this.plwc_MinusToZeroWorkDate = new DateTime?();
      this.plwc_OriginDate = new DateTime?();
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TProfitLossWorkCnt();

    public override object Clone()
    {
      TProfitLossWorkCnt tprofitLossWorkCnt = base.Clone() as TProfitLossWorkCnt;
      tprofitLossWorkCnt.plwc_YyyyMm = this.plwc_YyyyMm;
      tprofitLossWorkCnt.plwc_StoreCode = this.plwc_StoreCode;
      tprofitLossWorkCnt.plwc_SiteID = this.plwc_SiteID;
      tprofitLossWorkCnt.plwc_WorkCnt = this.plwc_WorkCnt;
      tprofitLossWorkCnt.plwc_WorkDate = this.plwc_WorkDate;
      tprofitLossWorkCnt.plwc_WorkEmployee = this.plwc_WorkEmployee;
      tprofitLossWorkCnt.plwc_ApplyCnt = this.plwc_ApplyCnt;
      tprofitLossWorkCnt.plwc_ApplyDate = this.plwc_ApplyDate;
      tprofitLossWorkCnt.plwc_AmountWorkCnt = this.plwc_AmountWorkCnt;
      tprofitLossWorkCnt.plwc_AmountWorkDate = this.plwc_AmountWorkDate;
      tprofitLossWorkCnt.plwc_QtyWorkCnt = this.plwc_QtyWorkCnt;
      tprofitLossWorkCnt.plwc_QtyWorkDate = this.plwc_QtyWorkDate;
      tprofitLossWorkCnt.plwc_WeightWorkCnt = this.plwc_WeightWorkCnt;
      tprofitLossWorkCnt.plwc_WeightWorkDate = this.plwc_WeightWorkDate;
      tprofitLossWorkCnt.plwc_PoorToZeroWorkCnt = this.plwc_PoorToZeroWorkCnt;
      tprofitLossWorkCnt.plwc_PoorToZeroWorkDate = this.plwc_PoorToZeroWorkDate;
      tprofitLossWorkCnt.plwc_MinusToZeroWorkCnt = this.plwc_MinusToZeroWorkCnt;
      tprofitLossWorkCnt.plwc_MinusToZeroWorkDate = this.plwc_MinusToZeroWorkDate;
      tprofitLossWorkCnt.plwc_OriginDate = this.plwc_OriginDate;
      return (object) tprofitLossWorkCnt;
    }

    public void PutData(TProfitLossWorkCnt pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.plwc_YyyyMm = pSource.plwc_YyyyMm;
      this.plwc_StoreCode = pSource.plwc_StoreCode;
      this.plwc_SiteID = pSource.plwc_SiteID;
      this.plwc_WorkCnt = pSource.plwc_WorkCnt;
      this.plwc_WorkDate = pSource.plwc_WorkDate;
      this.plwc_WorkEmployee = pSource.plwc_WorkEmployee;
      this.plwc_ApplyCnt = pSource.plwc_ApplyCnt;
      this.plwc_ApplyDate = pSource.plwc_ApplyDate;
      this.plwc_AmountWorkCnt = pSource.plwc_AmountWorkCnt;
      this.plwc_AmountWorkDate = pSource.plwc_AmountWorkDate;
      this.plwc_QtyWorkCnt = pSource.plwc_QtyWorkCnt;
      this.plwc_QtyWorkDate = pSource.plwc_QtyWorkDate;
      this.plwc_WeightWorkCnt = pSource.plwc_WeightWorkCnt;
      this.plwc_WeightWorkDate = pSource.plwc_WeightWorkDate;
      this.plwc_PoorToZeroWorkCnt = pSource.plwc_PoorToZeroWorkCnt;
      this.plwc_PoorToZeroWorkDate = pSource.plwc_PoorToZeroWorkDate;
      this.plwc_MinusToZeroWorkCnt = pSource.plwc_MinusToZeroWorkCnt;
      this.plwc_MinusToZeroWorkDate = pSource.plwc_MinusToZeroWorkDate;
      this.plwc_OriginDate = pSource.plwc_OriginDate;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.plwc_YyyyMm = p_rs.GetFieldInt("plwc_YyyyMm");
        this.plwc_StoreCode = p_rs.GetFieldInt("plwc_StoreCode");
        if (this.plwc_StoreCode == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.plwc_SiteID = p_rs.GetFieldLong("plwc_SiteID");
        this.plwc_WorkCnt = p_rs.GetFieldInt("plwc_WorkCnt");
        this.plwc_WorkDate = p_rs.GetFieldDateTime("plwc_WorkDate");
        this.plwc_WorkEmployee = p_rs.GetFieldInt("plwc_WorkEmployee");
        this.plwc_ApplyCnt = p_rs.GetFieldInt("plwc_ApplyCnt");
        this.plwc_ApplyDate = p_rs.GetFieldDateTime("plwc_ApplyDate");
        this.plwc_AmountWorkCnt = p_rs.GetFieldInt("plwc_AmountWorkCnt");
        this.plwc_AmountWorkDate = p_rs.GetFieldDateTime("plwc_AmountWorkDate");
        this.plwc_QtyWorkCnt = p_rs.GetFieldInt("plwc_QtyWorkCnt");
        this.plwc_QtyWorkDate = p_rs.GetFieldDateTime("plwc_QtyWorkDate");
        this.plwc_WeightWorkCnt = p_rs.GetFieldInt("plwc_WeightWorkCnt");
        this.plwc_WeightWorkDate = p_rs.GetFieldDateTime("plwc_WeightWorkDate");
        this.plwc_PoorToZeroWorkCnt = p_rs.GetFieldInt("plwc_PoorToZeroWorkCnt");
        this.plwc_PoorToZeroWorkDate = p_rs.GetFieldDateTime("plwc_PoorToZeroWorkDate");
        this.plwc_MinusToZeroWorkCnt = p_rs.GetFieldInt("plwc_MinusToZeroWorkCnt");
        this.plwc_MinusToZeroWorkDate = p_rs.GetFieldDateTime("plwc_MinusToZeroWorkDate");
        this.plwc_OriginDate = p_rs.GetFieldDateTime("plwc_OriginDate");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) this.TableCode) + " plwc_YyyyMm,plwc_StoreCode,plwc_SiteID,plwc_WorkCnt,plwc_WorkDate,plwc_WorkEmployee,plwc_ApplyCnt,plwc_ApplyDate,plwc_AmountWorkCnt,plwc_AmountWorkDate,plwc_QtyWorkCnt,plwc_QtyWorkDate,plwc_WeightWorkCnt,plwc_WeightWorkDate,plwc_PoorToZeroWorkCnt,plwc_PoorToZeroWorkDate,plwc_MinusToZeroWorkCnt,plwc_MinusToZeroWorkDate,plwc_OriginDate) VALUES ( " + string.Format(" {0},{1}", (object) this.plwc_YyyyMm, (object) this.plwc_StoreCode) + string.Format(",{0}", (object) this.plwc_SiteID) + string.Format(",{0},{1},{2}", (object) this.plwc_WorkCnt, (object) this.plwc_WorkDate.GetDateToStrInNull(), (object) this.plwc_WorkEmployee) + string.Format(",{0},{1}", (object) this.plwc_ApplyCnt, (object) this.plwc_ApplyDate.GetDateToStrInNull()) + string.Format(",{0},{1}", (object) this.plwc_AmountWorkCnt, (object) this.plwc_AmountWorkDate.GetDateToStrInNull()) + string.Format(",{0},{1}", (object) this.plwc_QtyWorkCnt, (object) this.plwc_QtyWorkDate.GetDateToStrInNull()) + string.Format(",{0},{1}", (object) this.plwc_WeightWorkCnt, (object) this.plwc_WeightWorkDate.GetDateToStrInNull()) + string.Format(",{0},{1}", (object) this.plwc_PoorToZeroWorkCnt, (object) this.plwc_PoorToZeroWorkDate.GetDateToStrInNull()) + string.Format(",{0},{1}", (object) this.plwc_MinusToZeroWorkCnt, (object) this.plwc_MinusToZeroWorkDate.GetDateToStrInNull()) + "," + this.plwc_OriginDate.GetDateToStrInNull() + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.plwc_YyyyMm, (object) this.plwc_StoreCode, (object) this.plwc_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TProfitLossWorkCnt tprofitLossWorkCnt = this;
      // ISSUE: reference to a compiler-generated method
      tprofitLossWorkCnt.\u003C\u003En__0();
      if (await tprofitLossWorkCnt.OleDB.ExecuteAsync(tprofitLossWorkCnt.InsertQuery()))
        return true;
      tprofitLossWorkCnt.message = " " + tprofitLossWorkCnt.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tprofitLossWorkCnt.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tprofitLossWorkCnt.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tprofitLossWorkCnt.plwc_YyyyMm, (object) tprofitLossWorkCnt.plwc_StoreCode, (object) tprofitLossWorkCnt.plwc_SiteID) + " 내용 : " + tprofitLossWorkCnt.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tprofitLossWorkCnt.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) this.TableCode) + string.Format(" {0}={1}", (object) "plwc_WorkCnt", (object) (this.plwc_WorkCnt > 0 ? 1 : 0)) + ",plwc_WorkDate=" + this.plwc_WorkDate.GetDateToStrInNull() + string.Format(",{0}={1}", (object) "plwc_WorkEmployee", (object) this.plwc_WorkEmployee) + string.Format(",{0}={1}", (object) "plwc_ApplyCnt", (object) (this.plwc_ApplyCnt > 0 ? 1 : 0)) + ",plwc_ApplyDate=" + this.plwc_ApplyDate.GetDateToStrInNull() + string.Format(",{0}={1}", (object) "plwc_AmountWorkCnt", (object) (this.plwc_AmountWorkCnt > 0 ? 1 : 0)) + ",plwc_AmountWorkDate=" + this.plwc_AmountWorkDate.GetDateToStrInNull() + string.Format(",{0}={1}", (object) "plwc_QtyWorkCnt", (object) (this.plwc_QtyWorkCnt > 0 ? 1 : 0)) + ",plwc_QtyWorkDate=" + this.plwc_QtyWorkDate.GetDateToStrInNull() + string.Format(",{0}={1}", (object) "plwc_WeightWorkCnt", (object) (this.plwc_WeightWorkCnt > 0 ? 1 : 0)) + ",plwc_WeightWorkDate=" + this.plwc_WeightWorkDate.GetDateToStrInNull() + string.Format(",{0}={1}", (object) "plwc_PoorToZeroWorkCnt", (object) (this.plwc_PoorToZeroWorkCnt > 0 ? 1 : 0)) + ",plwc_PoorToZeroWorkDate=" + this.plwc_PoorToZeroWorkDate.GetDateToStrInNull() + string.Format(",{0}={1}", (object) "plwc_MinusToZeroWorkCnt", (object) (this.plwc_MinusToZeroWorkCnt > 0 ? 1 : 0)) + ",plwc_MinusToZeroWorkDate=" + this.plwc_MinusToZeroWorkDate.GetDateToStrInNull() + ",plwc_OriginDate=" + this.plwc_OriginDate.GetDateToStrInNull() + string.Format(" WHERE {0}={1}", (object) "plwc_YyyyMm", (object) this.plwc_YyyyMm) + string.Format(" AND {0}={1}", (object) "plwc_StoreCode", (object) this.plwc_StoreCode) + string.Format(" AND {0}={1}", (object) "plwc_SiteID", (object) this.plwc_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.plwc_YyyyMm, (object) this.plwc_StoreCode, (object) this.plwc_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TProfitLossWorkCnt tprofitLossWorkCnt = this;
      // ISSUE: reference to a compiler-generated method
      tprofitLossWorkCnt.\u003C\u003En__1();
      if (await tprofitLossWorkCnt.OleDB.ExecuteAsync(tprofitLossWorkCnt.UpdateQuery()))
        return true;
      tprofitLossWorkCnt.message = " " + tprofitLossWorkCnt.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tprofitLossWorkCnt.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tprofitLossWorkCnt.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tprofitLossWorkCnt.plwc_YyyyMm, (object) tprofitLossWorkCnt.plwc_StoreCode, (object) tprofitLossWorkCnt.plwc_SiteID) + " 내용 : " + tprofitLossWorkCnt.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tprofitLossWorkCnt.message);
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
      stringBuilder.Append(string.Format(" {0}={1}", (object) "plwc_WorkCnt", (object) (this.plwc_WorkCnt > 0 ? 1 : 0)) + ",plwc_WorkDate=" + this.plwc_WorkDate.GetDateToStrInNull() + string.Format(",{0}={1}", (object) "plwc_WorkEmployee", (object) this.plwc_WorkEmployee) + string.Format(",{0}={1}", (object) "plwc_ApplyCnt", (object) (this.plwc_ApplyCnt > 0 ? 1 : 0)) + ",plwc_ApplyDate=" + this.plwc_ApplyDate.GetDateToStrInNull() + string.Format(",{0}={1}", (object) "plwc_AmountWorkCnt", (object) (this.plwc_AmountWorkCnt > 0 ? 1 : 0)) + ",plwc_AmountWorkDate=" + this.plwc_AmountWorkDate.GetDateToStrInNull() + string.Format(",{0}={1}", (object) "plwc_QtyWorkCnt", (object) (this.plwc_QtyWorkCnt > 0 ? 1 : 0)) + ",plwc_QtyWorkDate=" + this.plwc_QtyWorkDate.GetDateToStrInNull() + string.Format(",{0}={1}", (object) "plwc_WeightWorkCnt", (object) (this.plwc_WeightWorkCnt > 0 ? 1 : 0)) + ",plwc_WeightWorkDate=" + this.plwc_WeightWorkDate.GetDateToStrInNull() + string.Format(",{0}={1}", (object) "plwc_PoorToZeroWorkCnt", (object) (this.plwc_PoorToZeroWorkCnt > 0 ? 1 : 0)) + ",plwc_PoorToZeroWorkDate=" + this.plwc_PoorToZeroWorkDate.GetDateToStrInNull() + string.Format(",{0}={1}", (object) "plwc_MinusToZeroWorkCnt", (object) (this.plwc_MinusToZeroWorkCnt > 0 ? 1 : 0)) + ",plwc_MinusToZeroWorkDate=" + this.plwc_MinusToZeroWorkDate.GetDateToStrInNull() + ",plwc_OriginDate=" + this.plwc_OriginDate.GetDateToStrInNull());
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.plwc_YyyyMm, (object) this.plwc_StoreCode, (object) this.plwc_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TProfitLossWorkCnt tprofitLossWorkCnt = this;
      // ISSUE: reference to a compiler-generated method
      tprofitLossWorkCnt.\u003C\u003En__1();
      if (await tprofitLossWorkCnt.OleDB.ExecuteAsync(tprofitLossWorkCnt.UpdateExInsertQuery()))
        return true;
      tprofitLossWorkCnt.message = " " + tprofitLossWorkCnt.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tprofitLossWorkCnt.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tprofitLossWorkCnt.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tprofitLossWorkCnt.plwc_YyyyMm, (object) tprofitLossWorkCnt.plwc_StoreCode, (object) tprofitLossWorkCnt.plwc_SiteID) + " 내용 : " + tprofitLossWorkCnt.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tprofitLossWorkCnt.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "plwc_SiteID") && Convert.ToInt64(hashtable[(object) "plwc_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "plwc_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "plwc_YyyyMm") && Convert.ToInt32(hashtable[(object) "plwc_YyyyMm"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "plwc_YyyyMm", hashtable[(object) "plwc_YyyyMm"]));
        if (hashtable.ContainsKey((object) "plwc_YyyyMm_BEGIN_") && hashtable.ContainsKey((object) "plwc_YyyyMm_END_"))
        {
          stringBuilder.Append(string.Format(" AND {0} >= {1}", (object) "plwc_YyyyMm", (object) Convert.ToInt32(hashtable[(object) "plwc_YyyyMm_BEGIN_"].ToString())));
          stringBuilder.Append(string.Format(" AND {0} <= {1}", (object) "plwc_YyyyMm", (object) Convert.ToInt32(hashtable[(object) "plwc_YyyyMm_END_"].ToString())));
        }
        if (hashtable.ContainsKey((object) "plwc_YyyyMm_NEXT_") && Convert.ToInt32(hashtable[(object) "plwc_YyyyMm_NEXT_"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}>={1}", (object) "plwc_YyyyMm", hashtable[(object) "plwc_YyyyMm"]));
        if (hashtable.ContainsKey((object) "_DT_DATE_"))
          stringBuilder.Append(" AND plwc_YyyyMm = " + new DateTime?((DateTime) hashtable[(object) "_DT_DATE_"]).GetDateToStr("yyyyMM"));
        if (hashtable.ContainsKey((object) "si_StoreCode") && Convert.ToInt32(hashtable[(object) "si_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "plwc_StoreCode", hashtable[(object) "si_StoreCode"]));
        else if (hashtable.ContainsKey((object) "plwc_StoreCode") && Convert.ToInt32(hashtable[(object) "plwc_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "plwc_StoreCode", hashtable[(object) "plwc_StoreCode"]));
        else if (hashtable.ContainsKey((object) "si_StoreCode_IN_") && hashtable[(object) "si_StoreCode_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "plwc_StoreCode", hashtable[(object) "si_StoreCode_IN_"]));
        else if (hashtable.ContainsKey((object) "plwc_StoreCode_IN_") && hashtable[(object) "plwc_StoreCode_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "plwc_StoreCode", hashtable[(object) "plwc_StoreCode_IN_"]));
        else if (hashtable.ContainsKey((object) "_STORE_AUTHS_") && hashtable[(object) "_STORE_AUTHS_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "plwc_StoreCode", hashtable[(object) "_STORE_AUTHS_"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "plwc_SiteID", (object) num));
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
        stringBuilder.Append(" SELECT  plwc_YyyyMm,plwc_StoreCode,plwc_SiteID,plwc_WorkCnt,plwc_WorkDate,plwc_WorkEmployee,plwc_ApplyCnt,plwc_ApplyDate,plwc_AmountWorkCnt,plwc_AmountWorkDate,plwc_QtyWorkCnt,plwc_QtyWorkDate,plwc_WeightWorkCnt,plwc_WeightWorkDate,plwc_PoorToZeroWorkCnt,plwc_PoorToZeroWorkDate,plwc_MinusToZeroWorkCnt,plwc_MinusToZeroWorkDate,plwc_OriginDate");
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
