// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Payment.Statement.TPaymentDetail
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
using System.Threading.Tasks;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.TableInfo;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniStock.Payment.Statement
{
  public class TPaymentDetail : UbModelBase<TPaymentDetail>
  {
    protected long _pd_PaymentID;
    private int _pd_Seq;
    private long _pd_SiteID;
    protected DateTime? _pd_ConfirmDate;
    private int _pd_ConfirmStatus;
    private int _pd_InOutDiv;
    private int _pd_StatementType;
    protected int _pd_ReasonType;
    protected int _pd_WriteType;
    private double _pd_Amount;
    private double _pd_PayAmount;
    private double _pd_DeductAmount;
    private string _pd_Memo = string.Empty;
    private int _pd_TransmitStatus;
    private DateTime? _pd_TransmitDate;
    private DateTime? _pd_InDate;
    private int _pd_InUser;
    private DateTime? _pd_ModDate;
    private int _pd_ModUser;

    public override object _Key => (object) new object[2]
    {
      (object) this.pd_PaymentID,
      (object) this.pd_Seq
    };

    public virtual long pd_PaymentID
    {
      get => this._pd_PaymentID;
      set
      {
        this._pd_PaymentID = value;
        this.Changed(nameof (pd_PaymentID));
      }
    }

    public int pd_Seq
    {
      get => this._pd_Seq;
      set
      {
        this._pd_Seq = value;
        this.Changed(nameof (pd_Seq));
      }
    }

    public long pd_SiteID
    {
      get => this._pd_SiteID;
      set
      {
        this._pd_SiteID = value;
        this.Changed(nameof (pd_SiteID));
      }
    }

    public virtual DateTime? pd_ConfirmDate
    {
      get => this._pd_ConfirmDate;
      set
      {
        this._pd_ConfirmDate = value;
        this.Changed(nameof (pd_ConfirmDate));
      }
    }

    public int pd_ConfirmStatus
    {
      get => this._pd_ConfirmStatus;
      set
      {
        this._pd_ConfirmStatus = value;
        this.Changed(nameof (pd_ConfirmStatus));
        this.Changed("pd_ConfirmStatusDesc");
        this.Changed("IsConfirm");
        this.Changed("IsNotConfirm");
      }
    }

    public string pd_ConfirmStatusDesc => this.pd_ConfirmStatus != 0 ? Enum2StrConverter.ToPayStatementStatus(this.pd_ConfirmStatus).ToDescription() : string.Empty;

    public bool IsConfirm => Enum2StrConverter.ToPayStatementStatus(this.pd_ConfirmStatus) == EnumPayStatementStatus.Confirm;

    public bool IsNotConfirm => Enum2StrConverter.ToPayStatementStatus(this.pd_ConfirmStatus) == EnumPayStatementStatus.NotConfirm;

    public int pd_InOutDiv
    {
      get => this._pd_InOutDiv;
      set
      {
        this._pd_InOutDiv = value;
        this.Changed(nameof (pd_InOutDiv));
        this.Changed("pd_InOutDivDesc");
      }
    }

    public string pd_InOutDivDesc => this.pd_InOutDiv != 0 ? Enum2StrConverter.ToInOutDivMoneyDesc(this.pd_InOutDiv) : string.Empty;

    public int pd_StatementType
    {
      get => this._pd_StatementType;
      set
      {
        this._pd_StatementType = value;
        this.Changed(nameof (pd_StatementType));
        this.Changed("pd_StatementTypeDesc");
        this.Changed("IsPayment");
        this.Changed("IsDeduction");
        this.Changed("pd_ReasonTypeDesc");
      }
    }

    public string pd_StatementTypeDesc => this.pd_StatementType != 0 ? Enum2StrConverter.ToPaymentStatementDiv(this.pd_StatementType).ToDescription() : string.Empty;

    public bool IsPayment => Enum2StrConverter.ToPaymentStatementDiv(this.pd_StatementType) == EnumPaymentStatementDiv.PAYMENT;

    public bool IsDeduction => Enum2StrConverter.ToPaymentStatementDiv(this.pd_StatementType) == EnumPaymentStatementDiv.DEDUCTION;

    public virtual int pd_ReasonType
    {
      get => this._pd_ReasonType;
      set
      {
        this._pd_ReasonType = value;
        this.Changed(nameof (pd_ReasonType));
        this.Changed("pd_ReasonTypeDesc");
      }
    }

    public string pd_ReasonTypeDesc => this.IsPayment ? Enum2StrConverter.ToCommonCodeTypeMemo(this.pd_SiteID, EnumCommonCodeType.SupplierPayMethod, this.pd_ReasonType) : Enum2StrConverter.ToCommonCodeTypeMemo(this.pd_SiteID, EnumCommonCodeType.DeductionType, this.pd_ReasonType);

    public virtual int pd_WriteType
    {
      get => this._pd_WriteType;
      set
      {
        this._pd_WriteType = value;
        this.Changed(nameof (pd_WriteType));
        this.Changed("pd_WriteTypeDesc");
        this.Changed("pd_IsWriteTypeAuto");
      }
    }

    public string pd_WriteTypeDesc => this.pd_WriteType != 0 ? Enum2StrConverter.ToWriteType(this.pd_WriteType).ToDescription() : string.Empty;

    public bool pd_IsWriteTypeAuto => Enum2StrConverter.ToWriteType(this.pd_WriteType) == EnumWriteType.AUTO;

    public double pd_Amount
    {
      get => this._pd_Amount;
      set
      {
        this._pd_Amount = CalcHelper.CalcDoubleToFormatDouble(value);
        this.Changed(nameof (pd_Amount));
      }
    }

    public double pd_PayAmount
    {
      get => this._pd_PayAmount;
      set
      {
        this._pd_PayAmount = CalcHelper.CalcDoubleToFormatDouble(value);
        this.Changed(nameof (pd_PayAmount));
      }
    }

    public double pd_DeductAmount
    {
      get => this._pd_DeductAmount;
      set
      {
        this._pd_DeductAmount = CalcHelper.CalcDoubleToFormatDouble(value);
        this.Changed(nameof (pd_DeductAmount));
      }
    }

    public string pd_Memo
    {
      get => this._pd_Memo;
      set
      {
        this._pd_Memo = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (pd_Memo));
      }
    }

    public int pd_TransmitStatus
    {
      get => this._pd_TransmitStatus;
      set
      {
        this._pd_TransmitStatus = value;
        this.Changed(nameof (pd_TransmitStatus));
      }
    }

    public DateTime? pd_TransmitDate
    {
      get => this._pd_TransmitDate;
      set
      {
        this._pd_TransmitDate = value;
        this.Changed(nameof (pd_TransmitDate));
      }
    }

    public DateTime? pd_InDate
    {
      get => this._pd_InDate;
      set
      {
        this._pd_InDate = value;
        this.Changed(nameof (pd_InDate));
      }
    }

    public int pd_InUser
    {
      get => this._pd_InUser;
      set
      {
        this._pd_InUser = value;
        this.Changed(nameof (pd_InUser));
      }
    }

    public DateTime? pd_ModDate
    {
      get => this._pd_ModDate;
      set
      {
        this._pd_ModDate = value;
        this.Changed(nameof (pd_ModDate));
      }
    }

    public int pd_ModUser
    {
      get => this._pd_ModUser;
      set
      {
        this._pd_ModUser = value;
        this.Changed(nameof (pd_ModUser));
      }
    }

    public TPaymentDetail() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("pd_PaymentID", new TTableColumn()
      {
        tc_orgin_name = "pd_PaymentID",
        tc_trans_name = "결제코드"
      });
      columnInfo.Add("pd_Seq", new TTableColumn()
      {
        tc_orgin_name = "pd_Seq",
        tc_trans_name = "순번"
      });
      columnInfo.Add("pd_SiteID", new TTableColumn()
      {
        tc_orgin_name = "pd_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("pd_ConfirmDate", new TTableColumn()
      {
        tc_orgin_name = "pd_ConfirmDate",
        tc_trans_name = "확정일자"
      });
      columnInfo.Add("pd_ConfirmStatus", new TTableColumn()
      {
        tc_orgin_name = "pd_ConfirmStatus",
        tc_trans_name = "확정타입",
        tc_comm_code = 72
      });
      columnInfo.Add("pd_InOutDiv", new TTableColumn()
      {
        tc_orgin_name = "pd_InOutDiv",
        tc_trans_name = "입출금"
      });
      columnInfo.Add("pd_StatementType", new TTableColumn()
      {
        tc_orgin_name = "pd_StatementType",
        tc_trans_name = "종목",
        tc_comm_code = 69
      });
      columnInfo.Add("pd_ReasonType", new TTableColumn()
      {
        tc_orgin_name = "pd_ReasonType",
        tc_trans_name = "타입"
      });
      columnInfo.Add("pd_WriteType", new TTableColumn()
      {
        tc_orgin_name = "pd_WriteType",
        tc_trans_name = "작성",
        tc_comm_code = 68
      });
      columnInfo.Add("pd_Amount", new TTableColumn()
      {
        tc_orgin_name = "pd_Amount",
        tc_trans_name = "금액"
      });
      columnInfo.Add("pd_PayAmount", new TTableColumn()
      {
        tc_orgin_name = "pd_PayAmount",
        tc_trans_name = "결제금액"
      });
      columnInfo.Add("pd_DeductAmount", new TTableColumn()
      {
        tc_orgin_name = "pd_DeductAmount",
        tc_trans_name = "공제금액"
      });
      columnInfo.Add("pd_Memo", new TTableColumn()
      {
        tc_orgin_name = "pd_Memo",
        tc_trans_name = "메모"
      });
      columnInfo.Add("pd_TransmitStatus", new TTableColumn()
      {
        tc_orgin_name = "pd_TransmitStatus",
        tc_trans_name = "전송상태"
      });
      columnInfo.Add("pd_TransmitDate", new TTableColumn()
      {
        tc_orgin_name = "pd_TransmitDate",
        tc_trans_name = "전송일시"
      });
      columnInfo.Add("pd_InDate", new TTableColumn()
      {
        tc_orgin_name = "pd_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("pd_InUser", new TTableColumn()
      {
        tc_orgin_name = "pd_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("pd_ModDate", new TTableColumn()
      {
        tc_orgin_name = "pd_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("pd_ModUser", new TTableColumn()
      {
        tc_orgin_name = "pd_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.PaymentDetail;
      this.pd_PaymentID = 0L;
      this.pd_Seq = 0;
      this.pd_SiteID = 0L;
      this.pd_ConfirmDate = new DateTime?();
      this.pd_ConfirmStatus = 2;
      this.pd_InOutDiv = -1;
      this.pd_StatementType = 1;
      this.pd_ReasonType = 0;
      this.pd_WriteType = 2;
      this.pd_Amount = this.pd_PayAmount = this.pd_DeductAmount = 0.0;
      this.pd_Memo = string.Empty;
      this.pd_TransmitStatus = 2;
      this.pd_TransmitDate = new DateTime?();
      this.pd_InDate = new DateTime?();
      this.pd_InUser = 0;
      this.pd_ModDate = new DateTime?();
      this.pd_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TPaymentDetail();

    public override object Clone()
    {
      TPaymentDetail tpaymentDetail = base.Clone() as TPaymentDetail;
      tpaymentDetail.pd_PaymentID = this.pd_PaymentID;
      tpaymentDetail.pd_Seq = this.pd_Seq;
      tpaymentDetail.pd_SiteID = this.pd_SiteID;
      tpaymentDetail.pd_ConfirmDate = this.pd_ConfirmDate;
      tpaymentDetail.pd_ConfirmStatus = this.pd_ConfirmStatus;
      tpaymentDetail.pd_InOutDiv = this.pd_InOutDiv;
      tpaymentDetail.pd_StatementType = this.pd_StatementType;
      tpaymentDetail.pd_ReasonType = this.pd_ReasonType;
      tpaymentDetail.pd_WriteType = this.pd_WriteType;
      tpaymentDetail.pd_Amount = this.pd_Amount;
      tpaymentDetail.pd_PayAmount = this.pd_PayAmount;
      tpaymentDetail.pd_DeductAmount = this.pd_DeductAmount;
      tpaymentDetail.pd_Memo = this.pd_Memo;
      tpaymentDetail.pd_TransmitStatus = this.pd_TransmitStatus;
      tpaymentDetail.pd_TransmitDate = this.pd_TransmitDate;
      tpaymentDetail.pd_InDate = this.pd_InDate;
      tpaymentDetail.pd_InUser = this.pd_InUser;
      tpaymentDetail.pd_ModDate = this.pd_ModDate;
      tpaymentDetail.pd_ModUser = this.pd_ModUser;
      return (object) tpaymentDetail;
    }

    public void PutData(TPaymentDetail pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.pd_PaymentID = pSource.pd_PaymentID;
      this.pd_Seq = pSource.pd_Seq;
      this.pd_SiteID = pSource.pd_SiteID;
      this.pd_ConfirmDate = pSource.pd_ConfirmDate;
      this.pd_ConfirmStatus = pSource.pd_ConfirmStatus;
      this.pd_InOutDiv = pSource.pd_InOutDiv;
      this.pd_StatementType = pSource.pd_StatementType;
      this.pd_ReasonType = pSource.pd_ReasonType;
      this.pd_WriteType = pSource.pd_WriteType;
      this.pd_Amount = pSource.pd_Amount;
      this.pd_PayAmount = pSource.pd_PayAmount;
      this.pd_DeductAmount = pSource.pd_DeductAmount;
      this.pd_Memo = pSource.pd_Memo;
      this.pd_TransmitStatus = pSource.pd_TransmitStatus;
      this.pd_TransmitDate = pSource.pd_TransmitDate;
      this.pd_InDate = pSource.pd_InDate;
      this.pd_InUser = pSource.pd_InUser;
      this.pd_ModDate = pSource.pd_ModDate;
      this.pd_ModUser = pSource.pd_ModUser;
    }

    public bool IsZero(EnumZeroCheck pCheckType, TPaymentDetail pSource) => pSource == null || pSource.pd_Amount.IsZero() && pSource.pd_PayAmount.IsZero() && pSource.pd_DeductAmount.IsZero() && string.IsNullOrEmpty(pSource.pd_Memo);

    public virtual bool IsZero(EnumZeroCheck pCheckType) => this.IsZero(pCheckType, this);

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.pd_PaymentID = p_rs.GetFieldLong("pd_PaymentID");
        if (this.pd_PaymentID == 0L)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.pd_Seq = p_rs.GetFieldInt("pd_Seq");
        this.pd_SiteID = p_rs.GetFieldLong("pd_SiteID");
        this.pd_ConfirmDate = p_rs.GetFieldDateTime("pd_ConfirmDate");
        this.pd_ConfirmStatus = p_rs.GetFieldInt("pd_ConfirmStatus");
        this.pd_InOutDiv = p_rs.GetFieldInt("pd_InOutDiv");
        this.pd_StatementType = p_rs.GetFieldInt("pd_StatementType");
        this.pd_ReasonType = p_rs.GetFieldInt("pd_ReasonType");
        this.pd_WriteType = p_rs.GetFieldInt("pd_WriteType");
        this.pd_Amount = p_rs.GetFieldDouble("pd_Amount");
        this.pd_PayAmount = p_rs.GetFieldDouble("pd_PayAmount");
        this.pd_DeductAmount = p_rs.GetFieldDouble("pd_DeductAmount");
        this.pd_Memo = p_rs.GetFieldString("pd_Memo");
        this.pd_TransmitStatus = p_rs.GetFieldInt("pd_TransmitStatus");
        this.pd_TransmitDate = p_rs.GetFieldDateTime("pd_TransmitDate");
        this.pd_InDate = p_rs.GetFieldDateTime("pd_InDate");
        this.pd_InUser = p_rs.GetFieldInt("pd_InUser");
        this.pd_ModDate = p_rs.GetFieldDateTime("pd_ModDate");
        this.pd_ModUser = p_rs.GetFieldInt("pd_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) this.TableCode) + " pd_PaymentID,pd_Seq,pd_SiteID,pd_ConfirmDate,pd_ConfirmStatus,pd_InOutDiv,pd_StatementType,pd_ReasonType,pd_WriteType,pd_Amount,pd_PayAmount,pd_DeductAmount,pd_Memo,pd_TransmitStatus,pd_TransmitDate,pd_InDate,pd_InUser,pd_ModDate,pd_ModUser) VALUES ( " + string.Format(" {0},{1}", (object) this.pd_PaymentID, (object) this.pd_Seq) + string.Format(",{0}", (object) this.pd_SiteID) + "," + this.pd_ConfirmDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + string.Format(",{0},{1},{2},{3},{4}", (object) this.pd_ConfirmStatus, (object) this.pd_InOutDiv, (object) this.pd_StatementType, (object) this.pd_ReasonType, (object) this.pd_WriteType) + "," + this.pd_Amount.FormatTo("{0:0.0000}") + "," + this.pd_PayAmount.FormatTo("{0:0.0000}") + "," + this.pd_DeductAmount.FormatTo("{0:0.0000}") + string.Format(",'{0}',{1}", (object) this.pd_Memo, (object) this.pd_TransmitStatus) + "," + this.pd_TransmitDate.GetDateToStrInNull() + string.Format(",{0},{1}", (object) this.pd_InDate.GetDateToStrInNull(), (object) this.pd_InUser) + string.Format(",{0},{1}", (object) this.pd_ModDate.GetDateToStrInNull(), (object) this.pd_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.pd_PaymentID, (object) this.pd_Seq, (object) this.pd_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TPaymentDetail tpaymentDetail = this;
      // ISSUE: reference to a compiler-generated method
      tpaymentDetail.\u003C\u003En__0();
      if (await tpaymentDetail.OleDB.ExecuteAsync(tpaymentDetail.InsertQuery()))
        return true;
      tpaymentDetail.message = " " + tpaymentDetail.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tpaymentDetail.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tpaymentDetail.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tpaymentDetail.pd_PaymentID, (object) tpaymentDetail.pd_Seq, (object) tpaymentDetail.pd_SiteID) + " 내용 : " + tpaymentDetail.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tpaymentDetail.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) this.TableCode) + " pd_ConfirmDate=" + this.pd_ConfirmDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + string.Format(",{0}={1},{2}={3}", (object) "pd_ConfirmStatus", (object) this.pd_ConfirmStatus, (object) "pd_InOutDiv", (object) this.pd_InOutDiv) + string.Format(",{0}={1},{2}={3}", (object) "pd_StatementType", (object) this.pd_StatementType, (object) "pd_ReasonType", (object) this.pd_ReasonType) + string.Format(",{0}={1}", (object) "pd_WriteType", (object) this.pd_WriteType) + ",pd_Amount=" + this.pd_Amount.FormatTo("{0:0.0000}") + ",pd_PayAmount=" + this.pd_PayAmount.FormatTo("{0:0.0000}") + ",pd_DeductAmount=" + this.pd_DeductAmount.FormatTo("{0:0.0000}") + string.Format(",{0}='{1}',{2}={3}", (object) "pd_Memo", (object) this.pd_Memo, (object) "pd_TransmitStatus", (object) this.pd_TransmitStatus) + ",pd_TransmitDate=" + this.pd_TransmitDate.GetDateToStrInNull() + string.Format(",{0}={1},{2}={3}", (object) "pd_ModDate", (object) this.pd_ModDate.GetDateToStrInNull(), (object) "pd_ModUser", (object) this.pd_ModUser) + string.Format(" WHERE {0}={1}", (object) "pd_PaymentID", (object) this.pd_PaymentID) + string.Format(" AND {0}={1}", (object) "pd_Seq", (object) this.pd_Seq) + string.Format(" AND {0}={1}", (object) "pd_SiteID", (object) this.pd_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.pd_PaymentID, (object) this.pd_Seq, (object) this.pd_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TPaymentDetail tpaymentDetail = this;
      // ISSUE: reference to a compiler-generated method
      tpaymentDetail.\u003C\u003En__1();
      if (await tpaymentDetail.OleDB.ExecuteAsync(tpaymentDetail.UpdateQuery()))
        return true;
      tpaymentDetail.message = " " + tpaymentDetail.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tpaymentDetail.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tpaymentDetail.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tpaymentDetail.pd_PaymentID, (object) tpaymentDetail.pd_Seq, (object) tpaymentDetail.pd_SiteID) + " 내용 : " + tpaymentDetail.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tpaymentDetail.message);
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
      stringBuilder.Append(" pd_ConfirmDate=" + this.pd_ConfirmDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + string.Format(",{0}={1},{2}={3}", (object) "pd_ConfirmStatus", (object) this.pd_ConfirmStatus, (object) "pd_InOutDiv", (object) this.pd_InOutDiv) + string.Format(",{0}={1},{2}={3}", (object) "pd_StatementType", (object) this.pd_StatementType, (object) "pd_ReasonType", (object) this.pd_ReasonType) + string.Format(",{0}={1}", (object) "pd_WriteType", (object) this.pd_WriteType) + ",pd_Amount=" + this.pd_Amount.FormatTo("{0:0.0000}") + ",pd_PayAmount=" + this.pd_PayAmount.FormatTo("{0:0.0000}") + ",pd_DeductAmount=" + this.pd_DeductAmount.FormatTo("{0:0.0000}") + string.Format(",{0}='{1}',{2}={3}", (object) "pd_Memo", (object) this.pd_Memo, (object) "pd_TransmitStatus", (object) this.pd_TransmitStatus) + ",pd_TransmitDate=" + this.pd_TransmitDate.GetDateToStrInNull() + string.Format(",{0}={1},{2}={3}", (object) "pd_ModDate", (object) this.pd_ModDate.GetDateToStrInNull(), (object) "pd_ModUser", (object) this.pd_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.pd_PaymentID, (object) this.pd_Seq, (object) this.pd_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TPaymentDetail tpaymentDetail = this;
      // ISSUE: reference to a compiler-generated method
      tpaymentDetail.\u003C\u003En__1();
      if (await tpaymentDetail.OleDB.ExecuteAsync(tpaymentDetail.UpdateExInsertQuery()))
        return true;
      tpaymentDetail.message = " " + tpaymentDetail.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tpaymentDetail.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tpaymentDetail.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tpaymentDetail.pd_PaymentID, (object) tpaymentDetail.pd_Seq, (object) tpaymentDetail.pd_SiteID) + " 내용 : " + tpaymentDetail.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tpaymentDetail.message);
      return false;
    }

    public override string DeleteQuery() => string.Format(" DELETE FROM {0}{1}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) this.TableCode) + string.Format(" WHERE {0}={1}", (object) "pd_PaymentID", (object) this.pd_PaymentID) + string.Format(" AND {0}={1}", (object) "pd_Seq", (object) this.pd_Seq) + string.Format(" AND {0}={1}", (object) "pd_SiteID", (object) this.pd_SiteID);

    public override bool Delete()
    {
      this.InsertChecked();
      string pStrExec = this.DeleteQuery();
      if (this.OleDB.Execute(pStrExec))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 삭제 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.pd_PaymentID, (object) this.pd_Seq, (object) this.pd_SiteID) + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n 쿼리 : " + pStrExec + "\n--------------------------------------------------------------------------------------------------\n";
      return false;
    }

    public override async Task<bool> DeleteAsync()
    {
      TPaymentDetail tpaymentDetail = this;
      // ISSUE: reference to a compiler-generated method
      tpaymentDetail.\u003C\u003En__0();
      if (await tpaymentDetail.OleDB.ExecuteAsync(tpaymentDetail.DeleteQuery()))
        return true;
      tpaymentDetail.message = " " + tpaymentDetail.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tpaymentDetail.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tpaymentDetail.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tpaymentDetail.pd_PaymentID, (object) tpaymentDetail.pd_Seq, (object) tpaymentDetail.pd_SiteID) + " 내용 : " + tpaymentDetail.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tpaymentDetail.message);
      return false;
    }

    public virtual string DeleteQuery(long p_pd_PaymentID, int p_pd_Seq, long p_pd_SiteID = 0)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format(" DELETE FROM {0}{1} ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) this.TableCode));
      stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "pd_PaymentID", (object) p_pd_PaymentID));
      if (p_pd_Seq > 0)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pd_Seq", (object) p_pd_Seq));
      if (p_pd_SiteID > 0L)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pd_SiteID", (object) p_pd_SiteID));
      return stringBuilder.ToString();
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "pd_SiteID") && Convert.ToInt64(hashtable[(object) "pd_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "pd_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "pd_PaymentID") && Convert.ToInt64(hashtable[(object) "pd_PaymentID"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pd_PaymentID", hashtable[(object) "pd_PaymentID"]));
        if (hashtable.ContainsKey((object) "pd_Seq") && Convert.ToInt32(hashtable[(object) "pd_Seq"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pd_Seq", hashtable[(object) "pd_Seq"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pd_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "pd_ConfirmDate"))
        {
          stringBuilder.Append(" AND pd_ConfirmDate >='" + new DateTime?((DateTime) hashtable[(object) "pd_ConfirmDate"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND pd_ConfirmDate <='" + new DateTime?((DateTime) hashtable[(object) "pd_ConfirmDate"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
        }
        if (hashtable.ContainsKey((object) "pd_ConfirmDate_BEGIN_") && hashtable.ContainsKey((object) "pd_ConfirmDate_END_"))
        {
          stringBuilder.Append(" AND pd_ConfirmDate >='" + new DateTime?((DateTime) hashtable[(object) "pd_ConfirmDate_BEGIN_"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND pd_ConfirmDate <='" + new DateTime?((DateTime) hashtable[(object) "pd_ConfirmDate_END_"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
        }
        if (hashtable.ContainsKey((object) "pd_ConfirmStatus") && Convert.ToInt32(hashtable[(object) "pd_ConfirmStatus"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pd_ConfirmStatus", hashtable[(object) "pd_ConfirmStatus"]));
        if (hashtable.ContainsKey((object) "pd_InOutDiv") && Convert.ToInt32(hashtable[(object) "pd_InOutDiv"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pd_InOutDiv", hashtable[(object) "pd_InOutDiv"]));
        if (hashtable.ContainsKey((object) "pd_StatementType") && Convert.ToInt32(hashtable[(object) "pd_StatementType"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pd_StatementType", hashtable[(object) "pd_StatementType"]));
        if (hashtable.ContainsKey((object) "pd_ReasonType") && Convert.ToInt32(hashtable[(object) "pd_ReasonType"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pd_ReasonType", hashtable[(object) "pd_ReasonType"]));
        if (hashtable.ContainsKey((object) "pd_WriteType") && Convert.ToInt32(hashtable[(object) "pd_WriteType"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pd_WriteType", hashtable[(object) "pd_WriteType"]));
        if (hashtable.ContainsKey((object) "pd_TransmitStatus") && Convert.ToInt32(hashtable[(object) "pd_TransmitStatus"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pd_TransmitStatus", hashtable[(object) "pd_TransmitStatus"]));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "pd_Memo", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(")");
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
        stringBuilder.Append(" SELECT  pd_PaymentID,pd_Seq,pd_SiteID,pd_ConfirmDate,pd_ConfirmStatus,pd_InOutDiv,pd_StatementType,pd_ReasonType,pd_WriteType,pd_Amount,pd_PayAmount,pd_DeductAmount,pd_Memo,pd_TransmitStatus,pd_TransmitDate,pd_InDate,pd_InUser,pd_ModDate,pd_ModUser");
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
