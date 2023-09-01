// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.Gift.GiftItem.TGiftItem
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

namespace UniBiz.Bo.Models.UniMembers.Gift.GiftItem
{
  public class TGiftItem : UbModelBase<TGiftItem>
  {
    private int _gi_GiftCode;
    private long _gi_SiteID;
    private int _gi_GiftType;
    private string _gi_GiftName;
    private string _gi_GiftBarcode;
    private int _gi_GiftPrice;
    private int _gi_DeductionPoint;
    private string _gi_Memo;
    private string _gi_UseYn;
    private DateTime? _gi_InDate;
    private int _gi_InUser;
    private DateTime? _gi_ModDate;
    private int _gi_ModUser;

    public override object _Key => (object) new object[1]
    {
      (object) this.gi_GiftCode
    };

    public int gi_GiftCode
    {
      get => this._gi_GiftCode;
      set
      {
        this._gi_GiftCode = value;
        this.Changed(nameof (gi_GiftCode));
      }
    }

    public long gi_SiteID
    {
      get => this._gi_SiteID;
      set
      {
        this._gi_SiteID = value;
        this.Changed(nameof (gi_SiteID));
      }
    }

    public int gi_GiftType
    {
      get => this._gi_GiftType;
      set
      {
        this._gi_GiftType = value;
        this.Changed(nameof (gi_GiftType));
        this.Changed("gi_GiftTypeDesc");
      }
    }

    public string gi_GiftTypeDesc => this.gi_GiftType != 0 ? Enum2StrConverter.ToCommonCodeTypeMemo(this.gi_SiteID, EnumCommonCodeType.GiftItemType, this.gi_GiftType) : string.Empty;

    public string gi_GiftName
    {
      get => this._gi_GiftName;
      set
      {
        this._gi_GiftName = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (gi_GiftName));
      }
    }

    public string gi_GiftBarcode
    {
      get => this._gi_GiftBarcode;
      set
      {
        this._gi_GiftBarcode = UbModelBase.LeftStr(value, 20).Replace("'", "´");
        this.Changed(nameof (gi_GiftBarcode));
      }
    }

    public int gi_GiftPrice
    {
      get => this._gi_GiftPrice;
      set
      {
        this._gi_GiftPrice = value;
        this.Changed(nameof (gi_GiftPrice));
      }
    }

    public int gi_DeductionPoint
    {
      get => this._gi_DeductionPoint;
      set
      {
        this._gi_DeductionPoint = value;
        this.Changed(nameof (gi_DeductionPoint));
      }
    }

    public string gi_Memo
    {
      get => this._gi_Memo;
      set
      {
        this._gi_Memo = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (gi_Memo));
      }
    }

    public string gi_UseYn
    {
      get => this._gi_UseYn;
      set
      {
        this._gi_UseYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (gi_UseYn));
        this.Changed("gi_IsUse");
        this.Changed("gi_UseYnDesc");
      }
    }

    public bool gi_IsUse => "Y".Equals(this.gi_UseYn);

    public string gi_UseYnDesc => !"Y".Equals(this.gi_UseYn) ? "미사용" : "사용";

    public DateTime? gi_InDate
    {
      get => this._gi_InDate;
      set
      {
        this._gi_InDate = value;
        this.Changed(nameof (gi_InDate));
      }
    }

    public int gi_InUser
    {
      get => this._gi_InUser;
      set
      {
        this._gi_InUser = value;
        this.Changed(nameof (gi_InUser));
      }
    }

    public DateTime? gi_ModDate
    {
      get => this._gi_ModDate;
      set
      {
        this._gi_ModDate = value;
        this.Changed(nameof (gi_ModDate));
      }
    }

    public int gi_ModUser
    {
      get => this._gi_ModUser;
      set
      {
        this._gi_ModUser = value;
        this.Changed(nameof (gi_ModUser));
      }
    }

    public TGiftItem() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("gi_GiftCode", new TTableColumn()
      {
        tc_orgin_name = "gi_GiftCode",
        tc_trans_name = "사은품코드"
      });
      columnInfo.Add("gi_SiteID", new TTableColumn()
      {
        tc_orgin_name = "gi_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("gi_GiftType", new TTableColumn()
      {
        tc_orgin_name = "gi_GiftType",
        tc_trans_name = "사은품유형",
        tc_comm_code = 187
      });
      columnInfo.Add("gi_GiftName", new TTableColumn()
      {
        tc_orgin_name = "gi_GiftName",
        tc_trans_name = "사은품명"
      });
      columnInfo.Add("gi_GiftBarcode", new TTableColumn()
      {
        tc_orgin_name = "gi_GiftBarcode",
        tc_trans_name = "바코드"
      });
      columnInfo.Add("gi_GiftPrice", new TTableColumn()
      {
        tc_orgin_name = "gi_GiftPrice",
        tc_trans_name = "사은품단가"
      });
      columnInfo.Add("gi_DeductionPoint", new TTableColumn()
      {
        tc_orgin_name = "gi_DeductionPoint",
        tc_trans_name = "차감포인트"
      });
      columnInfo.Add("gi_Memo", new TTableColumn()
      {
        tc_orgin_name = "gi_Memo",
        tc_trans_name = "메모"
      });
      columnInfo.Add("gi_UseYn", new TTableColumn()
      {
        tc_orgin_name = "gi_UseYn",
        tc_trans_name = "사용상태"
      });
      columnInfo.Add("gi_InDate", new TTableColumn()
      {
        tc_orgin_name = "gi_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("gi_InUser", new TTableColumn()
      {
        tc_orgin_name = "gi_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("gi_ModDate", new TTableColumn()
      {
        tc_orgin_name = "gi_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("gi_ModUser", new TTableColumn()
      {
        tc_orgin_name = "gi_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.GiftItem;
      this.gi_GiftCode = 0;
      this.gi_SiteID = 0L;
      this.gi_GiftType = 0;
      this.gi_GiftName = string.Empty;
      this.gi_GiftBarcode = string.Empty;
      this.gi_GiftPrice = this.gi_DeductionPoint = 0;
      this.gi_Memo = string.Empty;
      this.gi_UseYn = "Y";
      this.gi_InDate = new DateTime?();
      this.gi_InUser = 0;
      this.gi_ModDate = new DateTime?();
      this.gi_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TGiftItem();

    public override object Clone()
    {
      TGiftItem tgiftItem = base.Clone() as TGiftItem;
      tgiftItem.gi_GiftCode = this.gi_GiftCode;
      tgiftItem.gi_SiteID = this.gi_SiteID;
      tgiftItem.gi_GiftType = this.gi_GiftType;
      tgiftItem.gi_GiftName = this.gi_GiftName;
      tgiftItem.gi_GiftBarcode = this.gi_GiftBarcode;
      tgiftItem.gi_GiftPrice = this.gi_GiftPrice;
      tgiftItem.gi_DeductionPoint = this.gi_DeductionPoint;
      tgiftItem.gi_Memo = this.gi_Memo;
      tgiftItem.gi_UseYn = this.gi_UseYn;
      tgiftItem.gi_InDate = this.gi_InDate;
      tgiftItem.gi_InUser = this.gi_InUser;
      tgiftItem.gi_ModDate = this.gi_ModDate;
      tgiftItem.gi_ModUser = this.gi_ModUser;
      return (object) tgiftItem;
    }

    public void PutData(TGiftItem pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.gi_GiftCode = pSource.gi_GiftCode;
      this.gi_SiteID = pSource.gi_SiteID;
      this.gi_GiftType = pSource.gi_GiftType;
      this.gi_GiftName = pSource.gi_GiftName;
      this.gi_GiftBarcode = pSource.gi_GiftBarcode;
      this.gi_GiftPrice = pSource.gi_GiftPrice;
      this.gi_DeductionPoint = pSource.gi_DeductionPoint;
      this.gi_Memo = pSource.gi_Memo;
      this.gi_UseYn = pSource.gi_UseYn;
      this.gi_InDate = pSource.gi_InDate;
      this.gi_InUser = pSource.gi_InUser;
      this.gi_ModDate = pSource.gi_ModDate;
      this.gi_ModUser = pSource.gi_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.gi_GiftCode = p_rs.GetFieldInt("gi_GiftCode");
        if (this.gi_GiftCode == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.gi_SiteID = p_rs.GetFieldLong("gi_SiteID");
        this.gi_GiftType = p_rs.GetFieldInt("gi_GiftType");
        this.gi_GiftName = p_rs.GetFieldString("gi_GiftName");
        this.gi_GiftBarcode = p_rs.GetFieldString("gi_GiftBarcode");
        this.gi_GiftPrice = p_rs.GetFieldInt("gi_GiftPrice");
        this.gi_DeductionPoint = p_rs.GetFieldInt("gi_DeductionPoint");
        this.gi_Memo = p_rs.GetFieldString("gi_Memo");
        this.gi_UseYn = p_rs.GetFieldString("gi_UseYn");
        this.gi_InDate = p_rs.GetFieldDateTime("gi_InDate");
        this.gi_InUser = p_rs.GetFieldInt("gi_InUser");
        this.gi_ModDate = p_rs.GetFieldDateTime("gi_ModDate");
        this.gi_ModUser = p_rs.GetFieldInt("gi_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode) + " gi_GiftCode,gi_SiteID,gi_GiftType,gi_GiftName,gi_GiftBarcode,gi_GiftPrice,gi_DeductionPoint,gi_Memo,gi_UseYn,gi_InDate,gi_InUser,gi_ModDate,gi_ModUser) VALUES ( " + string.Format(" {0}", (object) this.gi_GiftCode) + string.Format(",{0}", (object) this.gi_SiteID) + string.Format(",{0},'{1}','{2}'", (object) this.gi_GiftType, (object) this.gi_GiftName, (object) this.gi_GiftBarcode) + string.Format(",{0},{1}", (object) this.gi_GiftPrice, (object) this.gi_DeductionPoint) + ",'" + this.gi_Memo + "','" + this.gi_UseYn + "'" + string.Format(",{0},{1}", (object) this.gi_InDate.GetDateToStrInNull(), (object) this.gi_InUser) + string.Format(",{0},{1}", (object) this.gi_ModDate.GetDateToStrInNull(), (object) this.gi_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.gi_GiftCode, (object) this.gi_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TGiftItem tgiftItem = this;
      // ISSUE: reference to a compiler-generated method
      tgiftItem.\u003C\u003En__0();
      if (await tgiftItem.OleDB.ExecuteAsync(tgiftItem.InsertQuery()))
        return true;
      tgiftItem.message = " " + tgiftItem.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tgiftItem.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tgiftItem.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tgiftItem.gi_GiftCode, (object) tgiftItem.gi_SiteID) + " 내용 : " + tgiftItem.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tgiftItem.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode) + string.Format(" {0}={1}", (object) "gi_GiftType", (object) this.gi_GiftType) + ",gi_GiftName='" + this.gi_GiftName + "',gi_GiftBarcode='" + this.gi_GiftBarcode + "'" + string.Format(",{0}={1}", (object) "gi_GiftPrice", (object) this.gi_GiftPrice) + string.Format(",{0}={1}", (object) "gi_DeductionPoint", (object) this.gi_DeductionPoint) + ",gi_Memo='" + this.gi_Memo + "',gi_UseYn='" + this.gi_UseYn + "'" + string.Format(",{0}={1},{2}={3}", (object) "gi_ModDate", (object) this.gi_ModDate.GetDateToStrInNull(), (object) "gi_ModUser", (object) this.gi_ModUser) + string.Format(" WHERE {0}={1}", (object) "gi_GiftCode", (object) this.gi_GiftCode) + string.Format(" AND {0}={1}", (object) "gi_SiteID", (object) this.gi_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.gi_GiftCode, (object) this.gi_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TGiftItem tgiftItem = this;
      // ISSUE: reference to a compiler-generated method
      tgiftItem.\u003C\u003En__1();
      if (await tgiftItem.OleDB.ExecuteAsync(tgiftItem.UpdateQuery()))
        return true;
      tgiftItem.message = " " + tgiftItem.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tgiftItem.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tgiftItem.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tgiftItem.gi_GiftCode, (object) tgiftItem.gi_SiteID) + " 내용 : " + tgiftItem.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tgiftItem.message);
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
      stringBuilder.Append(string.Format(" {0}={1}", (object) "gi_GiftType", (object) this.gi_GiftType) + ",gi_GiftName='" + this.gi_GiftName + "',gi_GiftBarcode='" + this.gi_GiftBarcode + "'" + string.Format(",{0}={1}", (object) "gi_GiftPrice", (object) this.gi_GiftPrice) + string.Format(",{0}={1}", (object) "gi_DeductionPoint", (object) this.gi_DeductionPoint) + ",gi_Memo='" + this.gi_Memo + "',gi_UseYn='" + this.gi_UseYn + "'" + string.Format(",{0}={1},{2}={3}", (object) "gi_ModDate", (object) this.gi_ModDate.GetDateToStrInNull(), (object) "gi_ModUser", (object) this.gi_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.gi_GiftCode, (object) this.gi_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TGiftItem tgiftItem = this;
      // ISSUE: reference to a compiler-generated method
      tgiftItem.\u003C\u003En__1();
      if (await tgiftItem.OleDB.ExecuteAsync(tgiftItem.UpdateExInsertQuery()))
        return true;
      tgiftItem.message = " " + tgiftItem.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tgiftItem.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tgiftItem.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tgiftItem.gi_GiftCode, (object) tgiftItem.gi_SiteID) + " 내용 : " + tgiftItem.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tgiftItem.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "gi_SiteID") && Convert.ToInt64(hashtable[(object) "gi_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "gi_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "gi_GiftCode") && Convert.ToInt32(hashtable[(object) "gi_GiftCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gi_GiftCode", hashtable[(object) "gi_GiftCode"]));
        else
          stringBuilder.Append(" AND gi_GiftCode>0");
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gi_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "gi_GiftType") && Convert.ToInt32(hashtable[(object) "gi_GiftType"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gi_GiftType", hashtable[(object) "gi_GiftType"]));
        if (hashtable.ContainsKey((object) "gi_GiftName") && !string.IsNullOrEmpty(hashtable[(object) "gi_GiftName"].ToString()))
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "gi_GiftName", hashtable[(object) "gi_GiftName"]));
        if (hashtable.ContainsKey((object) "gi_GiftBarcode") && !string.IsNullOrEmpty(hashtable[(object) "gi_GiftBarcode"].ToString()))
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "gi_GiftBarcode", hashtable[(object) "gi_GiftBarcode"]));
        if (hashtable.ContainsKey((object) "gi_UseYn") && !string.IsNullOrEmpty(hashtable[(object) "gi_UseYn"].ToString()))
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "gi_UseYn", hashtable[(object) "gi_UseYn"]));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && !string.IsNullOrEmpty(hashtable[(object) "_KEY_WORD_"].ToString()))
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "gi_GiftName", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "gi_GiftBarcode", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "gi_Memo", hashtable[(object) "_KEY_WORD_"]));
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
        string uniMembers = UbModelBase.UNI_MEMBERS;
        string str = this.TableCode.ToString();
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniMembers = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
        }
        stringBuilder.Append(" SELECT  gi_GiftCode,gi_SiteID,gi_GiftType,gi_GiftName,gi_GiftBarcode,gi_GiftPrice,gi_DeductionPoint,gi_Memo,gi_UseYn,gi_InDate,gi_InUser,gi_ModDate,gi_ModUser");
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
