// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.Summary.MemberDaySum.TMemberDaySum
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

namespace UniBiz.Bo.Models.UniMembers.Summary.MemberDaySum
{
  public class TMemberDaySum : UbModelBase<TMemberDaySum>
  {
    private DateTime? _mds_SysDate;
    private long _mds_MemberNo;
    private int _mds_StoreCode;
    private long _mds_SiteID;
    private int _mds_TransCnt;
    private double _mds_TotalSaleAmt;
    private double _mds_SaleAmt;
    private double _mds_PayCashTaxAmt;
    private double _mds_PayCashVatAmt;
    private double _mds_PayCashTaxFreeAmt;
    private int _mds_AddPoint;
    private int _mds_UsePoint;
    private DateTime? _mds_InDate;
    private int _mds_InUser;
    private DateTime? _mds_ModDate;
    private int _mds_ModUser;

    public override object _Key => (object) new object[3]
    {
      (object) this.mds_SysDate,
      (object) this.mds_MemberNo,
      (object) this.mds_StoreCode
    };

    public DateTime? mds_SysDate
    {
      get => this._mds_SysDate;
      set
      {
        this._mds_SysDate = value;
        this.Changed(nameof (mds_SysDate));
      }
    }

    public long mds_MemberNo
    {
      get => this._mds_MemberNo;
      set
      {
        this._mds_MemberNo = value;
        this.Changed(nameof (mds_MemberNo));
      }
    }

    public int mds_StoreCode
    {
      get => this._mds_StoreCode;
      set
      {
        this._mds_StoreCode = value;
        this.Changed(nameof (mds_StoreCode));
      }
    }

    public long mds_SiteID
    {
      get => this._mds_SiteID;
      set
      {
        this._mds_SiteID = value;
        this.Changed(nameof (mds_SiteID));
      }
    }

    public int mds_TransCnt
    {
      get => this._mds_TransCnt;
      set
      {
        this._mds_TransCnt = value;
        this.Changed(nameof (mds_TransCnt));
      }
    }

    public double mds_TotalSaleAmt
    {
      get => this._mds_TotalSaleAmt;
      set
      {
        this._mds_TotalSaleAmt = value;
        this.Changed(nameof (mds_TotalSaleAmt));
      }
    }

    public double mds_SaleAmt
    {
      get => this._mds_SaleAmt;
      set
      {
        this._mds_SaleAmt = value;
        this.Changed(nameof (mds_SaleAmt));
      }
    }

    public double mds_PayCashTaxAmt
    {
      get => this._mds_PayCashTaxAmt;
      set
      {
        this._mds_PayCashTaxAmt = value;
        this.Changed(nameof (mds_PayCashTaxAmt));
      }
    }

    public double mds_PayCashVatAmt
    {
      get => this._mds_PayCashVatAmt;
      set
      {
        this._mds_PayCashVatAmt = value;
        this.Changed(nameof (mds_PayCashVatAmt));
      }
    }

    public double mds_PayCashTaxFreeAmt
    {
      get => this._mds_PayCashTaxFreeAmt;
      set
      {
        this._mds_PayCashTaxFreeAmt = value;
        this.Changed(nameof (mds_PayCashTaxFreeAmt));
      }
    }

    public int mds_AddPoint
    {
      get => this._mds_AddPoint;
      set
      {
        this._mds_AddPoint = value;
        this.Changed(nameof (mds_AddPoint));
      }
    }

    public int mds_UsePoint
    {
      get => this._mds_UsePoint;
      set
      {
        this._mds_UsePoint = value;
        this.Changed(nameof (mds_UsePoint));
      }
    }

    public DateTime? mds_InDate
    {
      get => this._mds_InDate;
      set
      {
        this._mds_InDate = value;
        this.Changed(nameof (mds_InDate));
      }
    }

    public int mds_InUser
    {
      get => this._mds_InUser;
      set
      {
        this._mds_InUser = value;
        this.Changed(nameof (mds_InUser));
      }
    }

    public DateTime? mds_ModDate
    {
      get => this._mds_ModDate;
      set
      {
        this._mds_ModDate = value;
        this.Changed(nameof (mds_ModDate));
      }
    }

    public int mds_ModUser
    {
      get => this._mds_ModUser;
      set
      {
        this._mds_ModUser = value;
        this.Changed(nameof (mds_ModUser));
      }
    }

    public TMemberDaySum() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("mds_SysDate", new TTableColumn()
      {
        tc_orgin_name = "mds_SysDate",
        tc_trans_name = "발생일시"
      });
      columnInfo.Add("mds_MemberNo", new TTableColumn()
      {
        tc_orgin_name = "mds_MemberNo",
        tc_trans_name = "회원코드"
      });
      columnInfo.Add("mds_StoreCode", new TTableColumn()
      {
        tc_orgin_name = "mds_StoreCode",
        tc_trans_name = "지점코드"
      });
      columnInfo.Add("mds_SiteID", new TTableColumn()
      {
        tc_orgin_name = "mds_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("mds_TransCnt", new TTableColumn()
      {
        tc_orgin_name = "mds_TransCnt",
        tc_trans_name = "영수증건수"
      });
      columnInfo.Add("mds_TotalSaleAmt", new TTableColumn()
      {
        tc_orgin_name = "mds_TotalSaleAmt",
        tc_trans_name = "총매출금액"
      });
      columnInfo.Add("mds_SaleAmt", new TTableColumn()
      {
        tc_orgin_name = "mds_SaleAmt",
        tc_trans_name = "순매출금액"
      });
      columnInfo.Add("mds_PayCashTaxAmt", new TTableColumn()
      {
        tc_orgin_name = "mds_PayCashTaxAmt",
        tc_trans_name = "현금결제과세금액"
      });
      columnInfo.Add("mds_PayCashVatAmt", new TTableColumn()
      {
        tc_orgin_name = "mds_PayCashVatAmt",
        tc_trans_name = "현금결제부가세"
      });
      columnInfo.Add("mds_PayCashTaxFreeAmt", new TTableColumn()
      {
        tc_orgin_name = "mds_PayCashTaxFreeAmt",
        tc_trans_name = "현금결제면세금액"
      });
      columnInfo.Add("mds_AddPoint", new TTableColumn()
      {
        tc_orgin_name = "mds_AddPoint",
        tc_trans_name = "적립포인트"
      });
      columnInfo.Add("mds_UsePoint", new TTableColumn()
      {
        tc_orgin_name = "mds_UsePoint",
        tc_trans_name = "사용포인트"
      });
      columnInfo.Add("mds_InDate", new TTableColumn()
      {
        tc_orgin_name = "mds_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("mds_InUser", new TTableColumn()
      {
        tc_orgin_name = "mds_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("mds_ModDate", new TTableColumn()
      {
        tc_orgin_name = "mds_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("mds_ModUser", new TTableColumn()
      {
        tc_orgin_name = "mds_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.MemberDaySum;
      this.mds_SysDate = new DateTime?();
      this.mds_MemberNo = 0L;
      this.mds_StoreCode = 0;
      this.mds_SiteID = 0L;
      this.mds_TransCnt = 0;
      this.mds_TotalSaleAmt = this.mds_SaleAmt = this.mds_PayCashTaxAmt = this.mds_PayCashVatAmt = this.mds_PayCashTaxFreeAmt = 0.0;
      this.mds_AddPoint = this.mds_UsePoint = 0;
      this.mds_InDate = new DateTime?();
      this.mds_InUser = 0;
      this.mds_ModDate = new DateTime?();
      this.mds_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TMemberDaySum();

    public override object Clone()
    {
      TMemberDaySum tmemberDaySum = base.Clone() as TMemberDaySum;
      tmemberDaySum.mds_SysDate = this.mds_SysDate;
      tmemberDaySum.mds_MemberNo = this.mds_MemberNo;
      tmemberDaySum.mds_StoreCode = this.mds_StoreCode;
      tmemberDaySum.mds_SiteID = this.mds_SiteID;
      tmemberDaySum.mds_TransCnt = this.mds_TransCnt;
      tmemberDaySum.mds_TotalSaleAmt = this.mds_TotalSaleAmt;
      tmemberDaySum.mds_SaleAmt = this.mds_SaleAmt;
      tmemberDaySum.mds_PayCashTaxAmt = this.mds_PayCashTaxAmt;
      tmemberDaySum.mds_PayCashVatAmt = this.mds_PayCashVatAmt;
      tmemberDaySum.mds_PayCashTaxFreeAmt = this.mds_PayCashTaxFreeAmt;
      tmemberDaySum.mds_AddPoint = this.mds_AddPoint;
      tmemberDaySum.mds_UsePoint = this.mds_UsePoint;
      tmemberDaySum.mds_InDate = this.mds_InDate;
      tmemberDaySum.mds_InUser = this.mds_InUser;
      tmemberDaySum.mds_ModDate = this.mds_ModDate;
      tmemberDaySum.mds_ModUser = this.mds_ModUser;
      return (object) tmemberDaySum;
    }

    public void PutData(TMemberDaySum pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.mds_SysDate = pSource.mds_SysDate;
      this.mds_MemberNo = pSource.mds_MemberNo;
      this.mds_StoreCode = pSource.mds_StoreCode;
      this.mds_SiteID = pSource.mds_SiteID;
      this.mds_TransCnt = pSource.mds_TransCnt;
      this.mds_TotalSaleAmt = pSource.mds_TotalSaleAmt;
      this.mds_SaleAmt = pSource.mds_SaleAmt;
      this.mds_PayCashTaxAmt = pSource.mds_PayCashTaxAmt;
      this.mds_PayCashVatAmt = pSource.mds_PayCashVatAmt;
      this.mds_PayCashTaxFreeAmt = pSource.mds_PayCashTaxFreeAmt;
      this.mds_AddPoint = pSource.mds_AddPoint;
      this.mds_UsePoint = pSource.mds_UsePoint;
      this.mds_InDate = pSource.mds_InDate;
      this.mds_InUser = pSource.mds_InUser;
      this.mds_ModDate = pSource.mds_ModDate;
      this.mds_ModUser = pSource.mds_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.mds_SysDate = p_rs.GetFieldDateTime("mds_SysDate");
        this.mds_MemberNo = p_rs.GetFieldLong("mds_MemberNo");
        if (this.mds_MemberNo == 0L)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.mds_StoreCode = p_rs.GetFieldInt("mds_StoreCode");
        this.mds_SiteID = p_rs.GetFieldLong("mds_SiteID");
        this.mds_TransCnt = p_rs.GetFieldInt("mds_TransCnt");
        this.mds_TotalSaleAmt = p_rs.GetFieldDouble("mds_TotalSaleAmt");
        this.mds_SaleAmt = p_rs.GetFieldDouble("mds_SaleAmt");
        this.mds_PayCashTaxAmt = p_rs.GetFieldDouble("mds_PayCashTaxAmt");
        this.mds_PayCashVatAmt = p_rs.GetFieldDouble("mds_PayCashVatAmt");
        this.mds_PayCashTaxFreeAmt = p_rs.GetFieldDouble("mds_PayCashTaxFreeAmt");
        this.mds_AddPoint = p_rs.GetFieldInt("mds_AddPoint");
        this.mds_UsePoint = p_rs.GetFieldInt("mds_UsePoint");
        this.mds_InDate = p_rs.GetFieldDateTime("mds_InDate");
        this.mds_InUser = p_rs.GetFieldInt("mds_InUser");
        this.mds_ModDate = p_rs.GetFieldDateTime("mds_ModDate");
        this.mds_ModUser = p_rs.GetFieldInt("mds_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode) + " mds_SysDate,mds_MemberNo,mds_StoreCode,mds_SiteID,mds_TransCnt,mds_TotalSaleAmt,mds_SaleAmt,mds_PayCashTaxAmt,mds_PayCashVatAmt,mds_PayCashTaxFreeAmt,mds_AddPoint,mds_UsePoint,mds_InDate,mds_InUser,mds_ModDate,mds_ModUser) VALUES (  " + this.mds_SysDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + string.Format(",{0},{1}", (object) this.mds_MemberNo, (object) this.mds_StoreCode) + string.Format(",{0}", (object) this.mds_SiteID) + string.Format(",{0}", (object) this.mds_TransCnt) + "," + this.mds_TotalSaleAmt.FormatTo("{0:0.0000}") + "," + this.mds_SaleAmt.FormatTo("{0:0.0000}") + "," + this.mds_PayCashTaxAmt.FormatTo("{0:0.0000}") + "," + this.mds_PayCashVatAmt.FormatTo("{0:0.0000}") + "," + this.mds_PayCashTaxFreeAmt.FormatTo("{0:0.0000}") + string.Format(",{0},{1}", (object) this.mds_AddPoint, (object) this.mds_UsePoint) + string.Format(",{0},{1}", (object) this.mds_InDate.GetDateToStrInNull(), (object) this.mds_InUser) + string.Format(",{0},{1}", (object) this.mds_ModDate.GetDateToStrInNull(), (object) this.mds_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.mds_SysDate, (object) this.mds_MemberNo, (object) this.mds_StoreCode, (object) this.mds_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TMemberDaySum tmemberDaySum = this;
      // ISSUE: reference to a compiler-generated method
      tmemberDaySum.\u003C\u003En__0();
      if (await tmemberDaySum.OleDB.ExecuteAsync(tmemberDaySum.InsertQuery()))
        return true;
      tmemberDaySum.message = " " + tmemberDaySum.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberDaySum.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberDaySum.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tmemberDaySum.mds_SysDate, (object) tmemberDaySum.mds_MemberNo, (object) tmemberDaySum.mds_StoreCode, (object) tmemberDaySum.mds_SiteID) + " 내용 : " + tmemberDaySum.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberDaySum.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode) + string.Format(" {0}={1}", (object) "mds_TransCnt", (object) this.mds_TransCnt) + ",mds_TotalSaleAmt=" + this.mds_TotalSaleAmt.FormatTo("{0:0.0000}") + ",mds_SaleAmt=" + this.mds_SaleAmt.FormatTo("{0:0.0000}") + ",mds_PayCashTaxAmt=" + this.mds_PayCashTaxAmt.FormatTo("{0:0.0000}") + ",mds_PayCashVatAmt=" + this.mds_PayCashVatAmt.FormatTo("{0:0.0000}") + ",mds_PayCashTaxFreeAmt=" + this.mds_PayCashTaxFreeAmt.FormatTo("{0:0.0000}") + string.Format(",{0}={1},{2}={3}", (object) "mds_AddPoint", (object) this.mds_AddPoint, (object) "mds_UsePoint", (object) this.mds_UsePoint) + string.Format(",{0}={1},{2}={3}", (object) "mds_ModDate", (object) this.mds_ModDate.GetDateToStrInNull(), (object) "mds_ModUser", (object) this.mds_ModUser) + " WHERE mds_SysDate=" + this.mds_SysDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + string.Format(" AND {0}={1}", (object) "mds_MemberNo", (object) this.mds_MemberNo) + string.Format(" AND {0}={1}", (object) "mds_StoreCode", (object) this.mds_StoreCode) + string.Format(" AND {0}={1}", (object) "mds_SiteID", (object) this.mds_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.mds_SysDate, (object) this.mds_MemberNo, (object) this.mds_StoreCode, (object) this.mds_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TMemberDaySum tmemberDaySum = this;
      // ISSUE: reference to a compiler-generated method
      tmemberDaySum.\u003C\u003En__1();
      if (await tmemberDaySum.OleDB.ExecuteAsync(tmemberDaySum.UpdateQuery()))
        return true;
      tmemberDaySum.message = " " + tmemberDaySum.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberDaySum.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberDaySum.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tmemberDaySum.mds_SysDate, (object) tmemberDaySum.mds_MemberNo, (object) tmemberDaySum.mds_StoreCode, (object) tmemberDaySum.mds_SiteID) + " 내용 : " + tmemberDaySum.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberDaySum.message);
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
      stringBuilder.Append(string.Format(" {0}={1}", (object) "mds_TransCnt", (object) this.mds_TransCnt) + ",mds_TotalSaleAmt=" + this.mds_TotalSaleAmt.FormatTo("{0:0.0000}") + ",mds_SaleAmt=" + this.mds_SaleAmt.FormatTo("{0:0.0000}") + ",mds_PayCashTaxAmt=" + this.mds_PayCashTaxAmt.FormatTo("{0:0.0000}") + ",mds_PayCashVatAmt=" + this.mds_PayCashVatAmt.FormatTo("{0:0.0000}") + ",mds_PayCashTaxFreeAmt=" + this.mds_PayCashTaxFreeAmt.FormatTo("{0:0.0000}") + string.Format(",{0}={1},{2}={3}", (object) "mds_AddPoint", (object) this.mds_AddPoint, (object) "mds_UsePoint", (object) this.mds_UsePoint) + string.Format(",{0}={1},{2}={3}", (object) "mds_ModDate", (object) this.mds_ModDate.GetDateToStrInNull(), (object) "mds_ModUser", (object) this.mds_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.mds_SysDate, (object) this.mds_MemberNo, (object) this.mds_StoreCode, (object) this.mds_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TMemberDaySum tmemberDaySum = this;
      // ISSUE: reference to a compiler-generated method
      tmemberDaySum.\u003C\u003En__1();
      if (await tmemberDaySum.OleDB.ExecuteAsync(tmemberDaySum.UpdateExInsertQuery()))
        return true;
      tmemberDaySum.message = " " + tmemberDaySum.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tmemberDaySum.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tmemberDaySum.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tmemberDaySum.mds_SysDate, (object) tmemberDaySum.mds_MemberNo, (object) tmemberDaySum.mds_StoreCode, (object) tmemberDaySum.mds_SiteID) + " 내용 : " + tmemberDaySum.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tmemberDaySum.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "mds_SiteID") && Convert.ToInt64(hashtable[(object) "mds_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "mds_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "mds_SysDate") && !string.IsNullOrEmpty(hashtable[(object) "mds_SysDate"].ToString()))
          stringBuilder.Append(" AND mds_SysDate=" + new DateTime?((DateTime) hashtable[(object) "mds_SysDate"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'"));
        if (hashtable.ContainsKey((object) "mds_SysDate_BEGIN_") && !string.IsNullOrEmpty(hashtable[(object) "mds_SysDate_BEGIN_"].ToString()) && hashtable.ContainsKey((object) "mds_SysDate_END_") && !string.IsNullOrEmpty(hashtable[(object) "mds_SysDate_END_"].ToString()))
          stringBuilder.Append(" AND mds_SysDate<=" + new DateTime?((DateTime) hashtable[(object) "mds_SysDate_BEGIN_"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + " AND mds_SysDate>=" + new DateTime?((DateTime) hashtable[(object) "mds_SysDate_END_"]).GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'"));
        if (hashtable.ContainsKey((object) "mds_MemberNo") && Convert.ToInt64(hashtable[(object) "mds_MemberNo"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mds_MemberNo", hashtable[(object) "mds_MemberNo"]));
        if (hashtable.ContainsKey((object) "mds_StoreCode") && Convert.ToInt32(hashtable[(object) "mds_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mds_StoreCode", hashtable[(object) "mds_StoreCode"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mds_SiteID", (object) num));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_"))
          string.IsNullOrEmpty(hashtable[(object) "_KEY_WORD_"].ToString());
      }
      return !stringBuilder.ToString().Equals(" WHERE") ? stringBuilder.Replace("WHERE AND", "WHERE").ToString() : string.Empty;
    }

    public override string GetSelectQuery(object p_param)
    {
      StringBuilder stringBuilder = new StringBuilder();
      try
      {
        string uniMembers = UbModelBase.UNI_MEMBERS;
        string str = this.TableCode.ToString();
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniMembers = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
        }
        stringBuilder.Append(" SELECT  mds_SysDate,mds_MemberNo,mds_StoreCode,mds_SiteID,mds_TransCnt,mds_TotalSaleAmt,mds_SaleAmt,mds_PayCashTaxAmt,mds_PayCashVatAmt,mds_PayCashTaxFreeAmt,mds_AddPoint,mds_UsePoint,mds_InDate,mds_InUser,mds_ModDate,mds_ModUser");
        stringBuilder.Append(" FROM " + DbQueryHelper.ToDBNameBridge(uniMembers) + str + " " + DbQueryHelper.ToWithNolock());
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
