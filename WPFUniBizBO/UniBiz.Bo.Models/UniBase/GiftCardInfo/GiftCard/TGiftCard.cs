// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.GiftCardInfo.GiftCard.TGiftCard
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

namespace UniBiz.Bo.Models.UniBase.GiftCardInfo.GiftCard
{
  public class TGiftCard : UbModelBase<TGiftCard>
  {
    private long _gc_GiftCardID;
    private long _gc_SiteID;
    private string _gc_GiftCardName;
    private int _gc_FaceValue;
    private int _gc_ExchangeMinAmt;
    private DateTime? _gc_ExpireDate;
    private int _gc_BuyPoint;
    private string _gc_CashReceiptYn;
    private int _gc_PayableStore;
    private int _gc_GiftCardIssuer;
    private long _gc_GoodsCode;
    private string _gc_UseYn;
    private DateTime? _gc_InDate;
    private int _gc_InUser;
    private DateTime? _gc_ModDate;
    private int _gc_ModUser;

    public override object _Key => (object) new object[1]
    {
      (object) this.gc_GiftCardID
    };

    public long gc_GiftCardID
    {
      get => this._gc_GiftCardID;
      set
      {
        this._gc_GiftCardID = value;
        this.Changed(nameof (gc_GiftCardID));
      }
    }

    public long gc_SiteID
    {
      get => this._gc_SiteID;
      set
      {
        this._gc_SiteID = value;
        this.Changed(nameof (gc_SiteID));
      }
    }

    public string gc_GiftCardName
    {
      get => this._gc_GiftCardName;
      set
      {
        this._gc_GiftCardName = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (gc_GiftCardName));
      }
    }

    public int gc_FaceValue
    {
      get => this._gc_FaceValue;
      set
      {
        this._gc_FaceValue = value;
        this.Changed(nameof (gc_FaceValue));
      }
    }

    public int gc_ExchangeMinAmt
    {
      get => this._gc_ExchangeMinAmt;
      set
      {
        this._gc_ExchangeMinAmt = value;
        this.Changed(nameof (gc_ExchangeMinAmt));
      }
    }

    public DateTime? gc_ExpireDate
    {
      get => this._gc_ExpireDate;
      set
      {
        this._gc_ExpireDate = value;
        this.Changed(nameof (gc_ExpireDate));
      }
    }

    public int gc_BuyPoint
    {
      get => this._gc_BuyPoint;
      set
      {
        this._gc_BuyPoint = value;
        this.Changed(nameof (gc_BuyPoint));
      }
    }

    public string gc_CashReceiptYn
    {
      get => this._gc_CashReceiptYn;
      set
      {
        this._gc_CashReceiptYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (gc_CashReceiptYn));
      }
    }

    public bool gc_IsCashReceipt => "Y".Equals(this.gc_CashReceiptYn);

    public string gc_CashReceiptYnDesc => !"Y".Equals(this.gc_CashReceiptYn) ? "현금영수증 미적립" : "현금영수증 적립";

    public int gc_PayableStore
    {
      get => this._gc_PayableStore;
      set
      {
        this._gc_PayableStore = value;
        this.Changed(nameof (gc_PayableStore));
      }
    }

    public int gc_GiftCardIssuer
    {
      get => this._gc_GiftCardIssuer;
      set
      {
        this._gc_GiftCardIssuer = value;
        this.Changed(nameof (gc_GiftCardIssuer));
        this.Changed("gc_GiftCardIssuerDesc");
      }
    }

    public string gc_GiftCardIssuerDesc => this.gc_GiftCardIssuer != 0 ? Enum2StrConverter.ToGiftCardIssuer(this.gc_GiftCardIssuer).ToDescription() : string.Empty;

    public long gc_GoodsCode
    {
      get => this._gc_GoodsCode;
      set
      {
        this._gc_GoodsCode = value;
        this.Changed(nameof (gc_GoodsCode));
      }
    }

    public string gc_UseYn
    {
      get => this._gc_UseYn;
      set
      {
        this._gc_UseYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (gc_UseYn));
        this.Changed("gc_IsUse");
        this.Changed("gc_UseYnDesc");
      }
    }

    public bool gc_IsUse => "Y".Equals(this.gc_UseYn);

    public string gc_UseYnDesc => !"Y".Equals(this.gc_UseYn) ? "미사용" : "사용";

    public DateTime? gc_InDate
    {
      get => this._gc_InDate;
      set
      {
        this._gc_InDate = value;
        this.Changed(nameof (gc_InDate));
        this.Changed("ModDate");
      }
    }

    public int gc_InUser
    {
      get => this._gc_InUser;
      set
      {
        this._gc_InUser = value;
        this.Changed(nameof (gc_InUser));
      }
    }

    public DateTime? gc_ModDate
    {
      get => this._gc_ModDate;
      set
      {
        this._gc_ModDate = value;
        this.Changed(nameof (gc_ModDate));
        this.Changed("ModDate");
      }
    }

    public int gc_ModUser
    {
      get => this._gc_ModUser;
      set
      {
        this._gc_ModUser = value;
        this.Changed(nameof (gc_ModUser));
      }
    }

    public override DateTime? ModDate => this.gc_ModDate ?? (this.gc_ModDate = this.gc_InDate);

    public TGiftCard() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("gc_GiftCardID", new TTableColumn()
      {
        tc_orgin_name = "gc_GiftCardID",
        tc_trans_name = "상품권ID"
      });
      columnInfo.Add("gc_SiteID", new TTableColumn()
      {
        tc_orgin_name = "gc_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("gc_GiftCardName", new TTableColumn()
      {
        tc_orgin_name = "gc_GiftCardName",
        tc_trans_name = "상품권명"
      });
      columnInfo.Add("gc_FaceValue", new TTableColumn()
      {
        tc_orgin_name = "gc_FaceValue",
        tc_trans_name = "액면가"
      });
      columnInfo.Add("gc_ExchangeMinAmt", new TTableColumn()
      {
        tc_orgin_name = "gc_ExchangeMinAmt",
        tc_trans_name = "환전최소금액 (최소사용금액)"
      });
      columnInfo.Add("gc_ExpireDate", new TTableColumn()
      {
        tc_orgin_name = "gc_ExpireDate",
        tc_trans_name = "사용기한"
      });
      columnInfo.Add("gc_BuyPoint", new TTableColumn()
      {
        tc_orgin_name = "gc_BuyPoint",
        tc_trans_name = "포인트로 상품권구매시 차감포인트"
      });
      columnInfo.Add("gc_CashReceiptYn", new TTableColumn()
      {
        tc_orgin_name = "gc_CashReceiptYn",
        tc_trans_name = "현금영수증적립가능여부"
      });
      columnInfo.Add("gc_PayableStore", new TTableColumn()
      {
        tc_orgin_name = "gc_PayableStore",
        tc_trans_name = "결제가능지점 (0:전체, else:점코드)"
      });
      columnInfo.Add("gc_GiftCardIssuer", new TTableColumn()
      {
        tc_orgin_name = "gc_GiftCardIssuer",
        tc_trans_name = "상품권발급처",
        tc_comm_code = 154
      });
      columnInfo.Add("gc_GoodsCode", new TTableColumn()
      {
        tc_orgin_name = "gc_GoodsCode",
        tc_trans_name = "상품코드"
      });
      columnInfo.Add("gc_UseYn", new TTableColumn()
      {
        tc_orgin_name = "gc_UseYn",
        tc_trans_name = "사용상태"
      });
      columnInfo.Add("gc_InDate", new TTableColumn()
      {
        tc_orgin_name = "gc_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("gc_InUser", new TTableColumn()
      {
        tc_orgin_name = "gc_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("gc_ModDate", new TTableColumn()
      {
        tc_orgin_name = "gc_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("gc_ModUser", new TTableColumn()
      {
        tc_orgin_name = "gc_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.GiftCard;
      this.gc_GiftCardID = 0L;
      this.gc_SiteID = 0L;
      this.gc_GiftCardName = string.Empty;
      this.gc_FaceValue = this.gc_ExchangeMinAmt = 0;
      this.gc_ExpireDate = new DateTime?();
      this.gc_BuyPoint = 0;
      this.gc_CashReceiptYn = "Y";
      this.gc_PayableStore = 0;
      this.gc_GiftCardIssuer = 0;
      this.gc_GoodsCode = 0L;
      this.gc_UseYn = "Y";
      this.gc_InDate = new DateTime?();
      this.gc_InUser = 0;
      this.gc_ModDate = new DateTime?();
      this.gc_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TGiftCard();

    public override object Clone()
    {
      TGiftCard tgiftCard = base.Clone() as TGiftCard;
      tgiftCard.gc_GiftCardID = this.gc_GiftCardID;
      tgiftCard.gc_SiteID = this.gc_SiteID;
      tgiftCard.gc_GiftCardName = this.gc_GiftCardName;
      tgiftCard.gc_FaceValue = this.gc_FaceValue;
      tgiftCard.gc_ExchangeMinAmt = this.gc_ExchangeMinAmt;
      tgiftCard.gc_ExpireDate = this.gc_ExpireDate;
      tgiftCard.gc_BuyPoint = this.gc_BuyPoint;
      tgiftCard.gc_CashReceiptYn = this.gc_CashReceiptYn;
      tgiftCard.gc_PayableStore = this.gc_PayableStore;
      tgiftCard.gc_GiftCardIssuer = this.gc_GiftCardIssuer;
      tgiftCard.gc_GoodsCode = this.gc_GoodsCode;
      tgiftCard.gc_UseYn = this.gc_UseYn;
      tgiftCard.gc_InDate = this.gc_InDate;
      tgiftCard.gc_ModDate = this.gc_ModDate;
      tgiftCard.gc_InUser = this.gc_InUser;
      tgiftCard.gc_ModUser = this.gc_ModUser;
      return (object) tgiftCard;
    }

    public void PutData(TGiftCard pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.gc_GiftCardID = pSource.gc_GiftCardID;
      this.gc_SiteID = pSource.gc_SiteID;
      this.gc_GiftCardName = pSource.gc_GiftCardName;
      this.gc_FaceValue = pSource.gc_FaceValue;
      this.gc_ExchangeMinAmt = pSource.gc_ExchangeMinAmt;
      this.gc_ExpireDate = pSource.gc_ExpireDate;
      this.gc_BuyPoint = pSource.gc_BuyPoint;
      this.gc_CashReceiptYn = pSource.gc_CashReceiptYn;
      this.gc_PayableStore = pSource.gc_PayableStore;
      this.gc_GiftCardIssuer = pSource.gc_GiftCardIssuer;
      this.gc_GoodsCode = pSource.gc_GoodsCode;
      this.gc_UseYn = pSource.gc_UseYn;
      this.gc_InDate = pSource.gc_InDate;
      this.gc_ModDate = pSource.gc_ModDate;
      this.gc_InUser = pSource.gc_InUser;
      this.gc_ModUser = pSource.gc_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.gc_GiftCardID = p_rs.GetFieldLong("gc_GiftCardID");
        if (this.gc_GiftCardID == 0L)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.gc_SiteID = p_rs.GetFieldLong("gc_SiteID");
        this.gc_GiftCardName = p_rs.GetFieldString("gc_GiftCardName");
        this.gc_FaceValue = p_rs.GetFieldInt("gc_FaceValue");
        this.gc_ExchangeMinAmt = p_rs.GetFieldInt("gc_ExchangeMinAmt");
        this.gc_ExpireDate = p_rs.GetFieldDateTime("gc_ExpireDate");
        this.gc_BuyPoint = p_rs.GetFieldInt("gc_BuyPoint");
        this.gc_CashReceiptYn = p_rs.GetFieldString("gc_CashReceiptYn");
        this.gc_PayableStore = p_rs.GetFieldInt("gc_PayableStore");
        this.gc_GiftCardIssuer = p_rs.GetFieldInt("gc_GiftCardIssuer");
        this.gc_GoodsCode = p_rs.GetFieldLong("gc_GoodsCode");
        this.gc_UseYn = p_rs.GetFieldString("gc_UseYn");
        this.gc_InDate = p_rs.GetFieldDateTime("gc_InDate");
        this.gc_InUser = p_rs.GetFieldInt("gc_InUser");
        this.gc_ModDate = p_rs.GetFieldDateTime("gc_ModDate");
        this.gc_ModUser = p_rs.GetFieldInt("gc_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " gc_GiftCardID,gc_SiteID,gc_GiftCardName,gc_FaceValue,gc_ExchangeMinAmt,gc_ExpireDate,gc_BuyPoint,gc_CashReceiptYn,gc_PayableStore,gc_GiftCardIssuer,gc_GoodsCode,gc_UseYn,gc_InDate,gc_InUser,gc_ModDate,gc_ModUser) VALUES ( " + string.Format(" {0}", (object) this.gc_GiftCardID) + string.Format(",{0}", (object) this.gc_SiteID) + string.Format(",'{0}',{1},{2}", (object) this.gc_GiftCardName, (object) this.gc_FaceValue, (object) this.gc_ExchangeMinAmt) + "," + this.gc_ExpireDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + string.Format(",{0},'{1}',{2}", (object) this.gc_BuyPoint, (object) this.gc_CashReceiptYn, (object) this.gc_PayableStore) + string.Format(",{0},{1},'{2}'", (object) this.gc_GiftCardIssuer, (object) this.gc_GoodsCode, (object) this.gc_UseYn) + string.Format(",{0},{1}", (object) this.gc_InDate.GetDateToStrInNull(), (object) this.gc_InUser) + string.Format(",{0},{1}", (object) this.gc_ModDate.GetDateToStrInNull(), (object) this.gc_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.gc_GiftCardID, (object) this.gc_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TGiftCard tgiftCard = this;
      // ISSUE: reference to a compiler-generated method
      tgiftCard.\u003C\u003En__0();
      if (await tgiftCard.OleDB.ExecuteAsync(tgiftCard.InsertQuery()))
        return true;
      tgiftCard.message = " " + tgiftCard.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tgiftCard.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tgiftCard.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tgiftCard.gc_GiftCardID, (object) tgiftCard.gc_SiteID) + " 내용 : " + tgiftCard.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tgiftCard.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " gc_GiftCardName='" + this.gc_GiftCardName + "'" + string.Format(",{0}={1}", (object) "gc_FaceValue", (object) this.gc_FaceValue) + string.Format(",{0}={1}", (object) "gc_ExchangeMinAmt", (object) this.gc_ExchangeMinAmt) + ",gc_ExpireDate=" + this.gc_ExpireDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + string.Format(",{0}={1}", (object) "gc_BuyPoint", (object) this.gc_BuyPoint) + ",gc_CashReceiptYn='" + this.gc_CashReceiptYn + "'" + string.Format(",{0}={1}", (object) "gc_PayableStore", (object) this.gc_PayableStore) + string.Format(",{0}={1}", (object) "gc_GiftCardIssuer", (object) this.gc_GiftCardIssuer) + string.Format(",{0}={1}", (object) "gc_GoodsCode", (object) this.gc_GoodsCode) + ",gc_UseYn='" + this.gc_UseYn + "'" + string.Format(",{0}={1},{2}={3}", (object) "gc_ModDate", (object) this.gc_ModDate.GetDateToStrInNull(), (object) "gc_ModUser", (object) this.gc_ModUser) + string.Format(" WHERE {0}={1}", (object) "gc_GiftCardID", (object) this.gc_GiftCardID) + string.Format(" AND {0}={1}", (object) "gc_SiteID", (object) this.gc_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.gc_GiftCardID, (object) this.gc_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TGiftCard tgiftCard = this;
      // ISSUE: reference to a compiler-generated method
      tgiftCard.\u003C\u003En__1();
      if (await tgiftCard.OleDB.ExecuteAsync(tgiftCard.UpdateQuery()))
        return true;
      tgiftCard.message = " " + tgiftCard.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tgiftCard.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tgiftCard.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tgiftCard.gc_GiftCardID, (object) tgiftCard.gc_SiteID) + " 내용 : " + tgiftCard.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tgiftCard.message);
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
      stringBuilder.Append(" gc_GiftCardName='" + this.gc_GiftCardName + "'" + string.Format(",{0}={1}", (object) "gc_FaceValue", (object) this.gc_FaceValue) + string.Format(",{0}={1}", (object) "gc_ExchangeMinAmt", (object) this.gc_ExchangeMinAmt) + ",gc_ExpireDate=" + this.gc_ExpireDate.GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + string.Format(",{0}={1}", (object) "gc_BuyPoint", (object) this.gc_BuyPoint) + ",gc_CashReceiptYn='" + this.gc_CashReceiptYn + "'" + string.Format(",{0}={1}", (object) "gc_PayableStore", (object) this.gc_PayableStore) + string.Format(",{0}={1}", (object) "gc_GiftCardIssuer", (object) this.gc_GiftCardIssuer) + string.Format(",{0}={1}", (object) "gc_GoodsCode", (object) this.gc_GoodsCode) + ",gc_UseYn='" + this.gc_UseYn + "'" + string.Format(",{0}={1},{2}={3}", (object) "gc_ModDate", (object) this.gc_ModDate.GetDateToStrInNull(), (object) "gc_ModUser", (object) this.gc_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.gc_GiftCardID, (object) this.gc_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TGiftCard tgiftCard = this;
      // ISSUE: reference to a compiler-generated method
      tgiftCard.\u003C\u003En__1();
      if (await tgiftCard.OleDB.ExecuteAsync(tgiftCard.UpdateExInsertQuery()))
        return true;
      tgiftCard.message = " " + tgiftCard.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tgiftCard.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tgiftCard.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tgiftCard.gc_GiftCardID, (object) tgiftCard.gc_SiteID) + " 내용 : " + tgiftCard.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tgiftCard.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "gc_SiteID") && Convert.ToInt64(hashtable[(object) "gc_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "gc_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "gc_GiftCardID") && Convert.ToInt64(hashtable[(object) "gc_GiftCardID"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gc_GiftCardID", hashtable[(object) "gc_GiftCardID"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gc_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "gc_GiftCardName") && hashtable[(object) "gc_GiftCardName"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "gc_GiftCardName", hashtable[(object) "gc_GiftCardName"]));
        if (hashtable.ContainsKey((object) "gc_FaceValue") && Convert.ToInt32(hashtable[(object) "gc_FaceValue"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gc_FaceValue", hashtable[(object) "gc_FaceValue"]));
        else if (hashtable.ContainsKey((object) "gc_FaceValue_BEGIN_") && string.IsNullOrEmpty(hashtable[(object) "gc_FaceValue_BEGIN_"].ToString()) && hashtable.ContainsKey((object) "gc_FaceValue_END_") && string.IsNullOrEmpty(hashtable[(object) "gc_FaceValue_END_"].ToString()))
          stringBuilder.Append(" AND gc_FaceValue>=gc_FaceValue_BEGIN_ AND gc_FaceValue<=gc_FaceValue_END_");
        if (hashtable.ContainsKey((object) "gc_ExpireDate") && !string.IsNullOrEmpty(hashtable[(object) "gc_ExpireDate"].ToString()))
          stringBuilder.Append(" AND gc_ExpireDate=" + new DateTime?((DateTime) hashtable[(object) "gc_ExpireDate"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'"));
        else if (hashtable.ContainsKey((object) "gc_ExpireDate_BEGIN_") && !string.IsNullOrEmpty(hashtable[(object) "gc_ExpireDate_BEGIN_"].ToString()) && hashtable.ContainsKey((object) "gc_ExpireDate_END_") && !string.IsNullOrEmpty(hashtable[(object) "gc_ExpireDate_END_"].ToString()))
          stringBuilder.Append(" AND gc_ExpireDate<=" + new DateTime?((DateTime) hashtable[(object) "gc_ExpireDate_BEGIN_"]).GetDateToStr("\\'yyyy-MM-dd 00:00:00\\'") + " AND gc_ExpireDate>=" + new DateTime?((DateTime) hashtable[(object) "gc_ExpireDate_END_"]).GetDateToStr("\\'yyyy-MM-dd 23:59:59\\'"));
        if (hashtable.ContainsKey((object) "gc_CashReceiptYn") && hashtable[(object) "gc_CashReceiptYn"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "gc_CashReceiptYn", hashtable[(object) "gc_CashReceiptYn"]));
        if (hashtable.ContainsKey((object) "gc_PayableStore") && Convert.ToInt32(hashtable[(object) "gc_PayableStore"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gc_PayableStore", hashtable[(object) "gc_PayableStore"]));
        else if (hashtable.ContainsKey((object) "gc_PayableStore_IN_") && !string.IsNullOrEmpty(hashtable[(object) "gc_PayableStore_IN_"].ToString()))
        {
          if (hashtable[(object) "gc_PayableStore_IN_"].ToString().Contains(","))
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "gc_PayableStore", hashtable[(object) "gc_PayableStore_IN_"]));
          else
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gc_PayableStore", hashtable[(object) "gc_PayableStore_IN_"]));
        }
        if (hashtable.ContainsKey((object) "gc_GiftCardIssuer") && Convert.ToInt32(hashtable[(object) "gc_GiftCardIssuer"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gc_GiftCardIssuer", hashtable[(object) "gc_GiftCardIssuer"]));
        if (hashtable.ContainsKey((object) "gc_GoodsCode") && Convert.ToInt64(hashtable[(object) "gc_GoodsCode"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gc_GoodsCode", hashtable[(object) "gc_GoodsCode"]));
        if (hashtable.ContainsKey((object) "gc_UseYn") && hashtable[(object) "gc_UseYn"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "gc_UseYn", hashtable[(object) "gc_UseYn"]));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "gc_GiftCardName", hashtable[(object) "_KEY_WORD_"]));
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
        string uniBase = UbModelBase.UNI_BASE;
        string str = this.TableCode.ToString();
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
        }
        stringBuilder.Append(" SELECT  gc_GiftCardID,gc_SiteID,gc_GiftCardName,gc_FaceValue,gc_ExchangeMinAmt,gc_ExpireDate,gc_BuyPoint,gc_CashReceiptYn,gc_PayableStore,gc_GiftCardIssuer,gc_GoodsCode,gc_UseYn,gc_InDate,gc_InUser,gc_ModDate,gc_ModUser");
        stringBuilder.Append(" FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock());
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) ex.GetHashCode()) + " 내용 : " + ex.Message + "\n" + string.Format(" Query : {0}\n", (object) stringBuilder) + "--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
        stringBuilder.Clear();
      }
      return stringBuilder.ToString();
    }
  }
}
