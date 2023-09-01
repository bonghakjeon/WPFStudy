// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.CommonCode.TCommonCode
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

namespace UniBiz.Bo.Models.UniBase.CommonCode
{
  public class TCommonCode : UbModelBase<TCommonCode>
  {
    private int _comm_Type;
    private int _comm_TypeNo;
    private long _comm_SiteID;
    private string _comm_TypeMemo;
    private string _comm_TypeNoMemo;
    private string _comm_UseYn;
    private int _comm_SortNo;
    private double _comm_DataMoney;
    private int _comm_DataInt;
    private string _comm_DataString;
    private DateTime? _comm_InDate;
    private int _comm_InUser;
    private DateTime? _comm_ModDate;
    private int _comm_ModUser;

    public override object _Key => (object) new object[3]
    {
      (object) this.comm_Type,
      (object) this.comm_TypeNo,
      (object) this.comm_SiteID
    };

    public int comm_Type
    {
      get => this._comm_Type;
      set
      {
        this._comm_Type = value;
        this.Changed(nameof (comm_Type));
        this.Changed("comm_IsFixed");
      }
    }

    public bool comm_IsFixed => Enum2StrConverter.IsCommonCodeFixedType(this.comm_Type);

    public int comm_TypeNo
    {
      get => this._comm_TypeNo;
      set
      {
        this._comm_TypeNo = value;
        this.Changed(nameof (comm_TypeNo));
      }
    }

    public long comm_SiteID
    {
      get => this._comm_SiteID;
      set
      {
        this._comm_SiteID = value;
        this.Changed(nameof (comm_SiteID));
      }
    }

    public string comm_TypeMemo
    {
      get => this._comm_TypeMemo;
      set
      {
        this._comm_TypeMemo = UbModelBase.LeftStr(value, 50).Replace("'", "´");
        this.Changed(nameof (comm_TypeMemo));
      }
    }

    public string comm_TypeNoMemo
    {
      get => this._comm_TypeNoMemo;
      set
      {
        this._comm_TypeNoMemo = UbModelBase.LeftStr(value, 50).Replace("'", "´");
        this.Changed(nameof (comm_TypeNoMemo));
      }
    }

    public string comm_UseYn
    {
      get => this._comm_UseYn;
      set
      {
        this._comm_UseYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (comm_UseYn));
        this.Changed("comm_IsUseYn");
        this.Changed("comm_UseYnDesc");
      }
    }

    public bool comm_IsUseYn => "Y".Equals(this.comm_UseYn);

    public string comm_UseYnDesc => !"Y".Equals(this.comm_UseYn) ? "미사용" : "사용";

    public int comm_SortNo
    {
      get => this._comm_SortNo;
      set
      {
        this._comm_SortNo = value;
        this.Changed(nameof (comm_SortNo));
      }
    }

    public double comm_DataMoney
    {
      get => this._comm_DataMoney;
      set
      {
        this._comm_DataMoney = value;
        this.Changed(nameof (comm_DataMoney));
      }
    }

    public int comm_DataInt
    {
      get => this._comm_DataInt;
      set
      {
        this._comm_DataInt = value;
        this.Changed(nameof (comm_DataInt));
      }
    }

    public string comm_DataString
    {
      get => this._comm_DataString;
      set
      {
        this._comm_DataString = UbModelBase.LeftStr(value, 50).Replace("'", "´");
        this.Changed(nameof (comm_DataString));
      }
    }

    public DateTime? comm_InDate
    {
      get => this._comm_InDate;
      set
      {
        this._comm_InDate = value;
        this.Changed(nameof (comm_InDate));
        this.Changed("ModDate");
      }
    }

    public int comm_InUser
    {
      get => this._comm_InUser;
      set
      {
        this._comm_InUser = value;
        this.Changed(nameof (comm_InUser));
      }
    }

    public DateTime? comm_ModDate
    {
      get => this._comm_ModDate;
      set
      {
        this._comm_ModDate = value;
        this.Changed(nameof (comm_ModDate));
        this.Changed("ModDate");
      }
    }

    public int comm_ModUser
    {
      get => this._comm_ModUser;
      set
      {
        this._comm_ModUser = value;
        this.Changed(nameof (comm_ModUser));
      }
    }

    public override DateTime? ModDate => !this.comm_ModDate.HasValue ? this.comm_InDate : this.comm_ModDate;

    public TCommonCode() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("comm_Type", new TTableColumn()
      {
        tc_orgin_name = "comm_Type",
        tc_trans_name = "타입"
      });
      columnInfo.Add("comm_TypeNo", new TTableColumn()
      {
        tc_orgin_name = "comm_TypeNo",
        tc_trans_name = "코드"
      });
      columnInfo.Add("comm_SiteID", new TTableColumn()
      {
        tc_orgin_name = "comm_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("comm_TypeMemo", new TTableColumn()
      {
        tc_orgin_name = "comm_TypeMemo",
        tc_trans_name = "타입설명"
      });
      columnInfo.Add("comm_TypeNoMemo", new TTableColumn()
      {
        tc_orgin_name = "comm_TypeNoMemo",
        tc_trans_name = "코드명"
      });
      columnInfo.Add("comm_UseYn", new TTableColumn()
      {
        tc_orgin_name = "comm_UseYn",
        tc_trans_name = "사용상태"
      });
      columnInfo.Add("comm_SortNo", new TTableColumn()
      {
        tc_orgin_name = "comm_SortNo",
        tc_trans_name = "순서"
      });
      columnInfo.Add("comm_DataMoney", new TTableColumn()
      {
        tc_orgin_name = "comm_DataMoney",
        tc_trans_name = "실수형"
      });
      columnInfo.Add("comm_DataInt", new TTableColumn()
      {
        tc_orgin_name = "comm_DataInt",
        tc_trans_name = "정수형"
      });
      columnInfo.Add("comm_DataString", new TTableColumn()
      {
        tc_orgin_name = "comm_DataString",
        tc_trans_name = "문자형"
      });
      columnInfo.Add("comm_InDate", new TTableColumn()
      {
        tc_orgin_name = "comm_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("comm_InUser", new TTableColumn()
      {
        tc_orgin_name = "comm_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("comm_ModDate", new TTableColumn()
      {
        tc_orgin_name = "comm_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("comm_ModUser", new TTableColumn()
      {
        tc_orgin_name = "comm_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.CommonCode;
      this.comm_Type = this.comm_TypeNo = 0;
      this.comm_SiteID = 0L;
      this.comm_TypeMemo = string.Empty;
      this.comm_TypeNoMemo = string.Empty;
      this.comm_UseYn = "Y";
      this.comm_SortNo = this.comm_DataInt = 0;
      this.comm_DataMoney = 0.0;
      this.comm_DataString = string.Empty;
      this.comm_InDate = new DateTime?();
      this.comm_ModDate = new DateTime?();
      this.comm_InUser = this.comm_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TCommonCode();

    public override object Clone()
    {
      TCommonCode tcommonCode = base.Clone() as TCommonCode;
      tcommonCode.comm_Type = this.comm_Type;
      tcommonCode.comm_TypeNo = this.comm_TypeNo;
      tcommonCode.comm_SiteID = this.comm_SiteID;
      tcommonCode.comm_TypeMemo = this.comm_TypeMemo;
      tcommonCode.comm_TypeNoMemo = this.comm_TypeNoMemo;
      tcommonCode.comm_SortNo = this.comm_SortNo;
      tcommonCode.comm_DataInt = this.comm_DataInt;
      tcommonCode.comm_DataMoney = this.comm_DataMoney;
      tcommonCode.comm_DataString = this.comm_DataString;
      tcommonCode.comm_UseYn = this.comm_UseYn;
      tcommonCode.comm_InDate = this.comm_InDate;
      tcommonCode.comm_ModDate = this.comm_ModDate;
      tcommonCode.comm_InUser = this.comm_InUser;
      tcommonCode.comm_ModUser = this.comm_ModUser;
      return (object) tcommonCode;
    }

    public void PutData(TCommonCode pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.comm_Type = pSource.comm_Type;
      this.comm_TypeNo = pSource.comm_TypeNo;
      this.comm_SiteID = pSource.comm_SiteID;
      this.comm_TypeMemo = pSource.comm_TypeMemo;
      this.comm_TypeNoMemo = pSource.comm_TypeNoMemo;
      this.comm_SortNo = pSource.comm_SortNo;
      this.comm_DataInt = pSource.comm_DataInt;
      this.comm_DataMoney = pSource.comm_DataMoney;
      this.comm_DataString = pSource.comm_DataString;
      this.comm_UseYn = pSource.comm_UseYn;
      this.comm_InDate = pSource.comm_InDate;
      this.comm_ModDate = pSource.comm_ModDate;
      this.comm_InUser = pSource.comm_InUser;
      this.comm_ModUser = pSource.comm_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.comm_Type = p_rs.GetFieldInt("comm_Type");
        if (this.comm_Type == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.comm_TypeNo = p_rs.GetFieldInt("comm_TypeNo");
        this.comm_SiteID = p_rs.GetFieldLong("comm_SiteID");
        this.comm_TypeMemo = p_rs.GetFieldString("comm_TypeMemo");
        this.comm_TypeNoMemo = p_rs.GetFieldString("comm_TypeNoMemo");
        this.comm_SortNo = p_rs.GetFieldInt("comm_SortNo");
        this.comm_DataInt = p_rs.GetFieldInt("comm_DataInt");
        this.comm_DataMoney = p_rs.GetFieldDouble("comm_DataMoney");
        this.comm_DataString = p_rs.GetFieldString("comm_DataString");
        this.comm_UseYn = p_rs.GetFieldString("comm_UseYn");
        this.comm_InDate = p_rs.GetFieldDateTime("comm_InDate");
        this.comm_InUser = p_rs.GetFieldInt("comm_InUser");
        this.comm_ModDate = p_rs.GetFieldDateTime("comm_ModDate");
        this.comm_ModUser = p_rs.GetFieldInt("comm_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " comm_Type,comm_TypeNo,comm_SiteID,comm_TypeMemo,comm_TypeNoMemo,comm_SortNo,comm_DataInt,comm_DataMoney,comm_DataString,comm_UseYn,comm_InDate,comm_InUser,comm_ModDate,comm_ModUser) VALUES ( " + string.Format(" {0},{1},{2}", (object) this.comm_Type, (object) this.comm_TypeNo, (object) this.comm_SiteID) + string.Format(",'{0}','{1}',{2}", (object) this.comm_TypeMemo, (object) this.comm_TypeNoMemo, (object) this.comm_SortNo) + string.Format(",{0},{1},'{2}','{3}'", (object) this.comm_DataInt, (object) this.comm_DataMoney, (object) this.comm_DataString, (object) this.comm_UseYn) + string.Format(",{0},{1},{2},{3}", (object) this.comm_InDate.GetDateToStrInNull(), (object) this.comm_InUser, (object) this.comm_ModDate.GetDateToStrInNull(), (object) this.comm_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.comm_Type, (object) this.comm_TypeNo, (object) this.comm_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TCommonCode tcommonCode = this;
      // ISSUE: reference to a compiler-generated method
      tcommonCode.\u003C\u003En__0();
      if (await tcommonCode.OleDB.ExecuteAsync(tcommonCode.InsertQuery()))
        return true;
      tcommonCode.message = " " + tcommonCode.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tcommonCode.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tcommonCode.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tcommonCode.comm_Type, (object) tcommonCode.comm_TypeNo, (object) tcommonCode.comm_SiteID) + " 내용 : " + tcommonCode.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tcommonCode.message);
      return false;
    }

    public virtual string UpdateTypeNoMemoQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " comm_TypeNoMemo='" + this.comm_TypeNoMemo + "'" + string.Format(" WHERE {0}={1}", (object) "comm_SiteID", (object) this.comm_SiteID) + string.Format(" AND {0}={1}", (object) "comm_Type", (object) this.comm_Type) + " AND comm_TypeNo > 0";

    public virtual bool UpdateTypeNoMemo()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateTypeNoMemoQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.comm_Type, (object) this.comm_TypeNo, (object) this.comm_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public virtual async Task<bool> UpdateTypeNoMemoAsync()
    {
      TCommonCode tcommonCode = this;
      // ISSUE: reference to a compiler-generated method
      tcommonCode.\u003C\u003En__1();
      if (await tcommonCode.OleDB.ExecuteAsync(tcommonCode.UpdateTypeNoMemoQuery()))
        return true;
      tcommonCode.message = " " + tcommonCode.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tcommonCode.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tcommonCode.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tcommonCode.comm_Type, (object) tcommonCode.comm_TypeNo, (object) tcommonCode.comm_SiteID) + " 내용 : " + tcommonCode.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tcommonCode.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " comm_TypeMemo='" + this.comm_TypeMemo + "',comm_TypeNoMemo='" + this.comm_TypeNoMemo + "'" + string.Format(",{0}={1}", (object) "comm_SortNo", (object) this.comm_SortNo) + string.Format(",{0}={1}", (object) "comm_DataInt", (object) this.comm_DataInt) + string.Format(",{0}={1}", (object) "comm_DataMoney", (object) this.comm_DataMoney) + ",comm_DataString='" + this.comm_DataString + "',comm_UseYn='" + this.comm_UseYn + "'" + string.Format(",{0}={1},{2}={3}", (object) "comm_ModDate", (object) this.comm_ModDate.GetDateToStrInNull(), (object) "comm_ModUser", (object) this.comm_ModUser) + string.Format(" WHERE {0}={1}", (object) "comm_SiteID", (object) this.comm_SiteID) + string.Format(" AND {0}={1}", (object) "comm_Type", (object) this.comm_Type) + string.Format(" AND {0}={1}", (object) "comm_TypeNo", (object) this.comm_TypeNo);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.comm_Type, (object) this.comm_TypeNo, (object) this.comm_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TCommonCode tcommonCode = this;
      // ISSUE: reference to a compiler-generated method
      tcommonCode.\u003C\u003En__1();
      if (await tcommonCode.OleDB.ExecuteAsync(tcommonCode.UpdateQuery()))
        return true;
      tcommonCode.message = " " + tcommonCode.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tcommonCode.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tcommonCode.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tcommonCode.comm_Type, (object) tcommonCode.comm_TypeNo, (object) tcommonCode.comm_SiteID) + " 내용 : " + tcommonCode.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tcommonCode.message);
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
      stringBuilder.Append(" comm_TypeMemo='" + this.comm_TypeMemo + "',comm_TypeNoMemo='" + this.comm_TypeNoMemo + "'" + string.Format(",{0}={1}", (object) "comm_SortNo", (object) this.comm_SortNo) + string.Format(",{0}={1}", (object) "comm_DataInt", (object) this.comm_DataInt) + string.Format(",{0}={1}", (object) "comm_DataMoney", (object) this.comm_DataMoney) + ",comm_DataString='" + this.comm_DataString + "',comm_UseYn='" + this.comm_UseYn + "'" + string.Format(",{0}={1},{2}={3}", (object) "comm_ModDate", (object) this.comm_ModDate.GetDateToStrInNull(), (object) "comm_ModUser", (object) this.comm_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.comm_Type, (object) this.comm_TypeNo, (object) this.comm_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TCommonCode tcommonCode = this;
      // ISSUE: reference to a compiler-generated method
      tcommonCode.\u003C\u003En__1();
      if (await tcommonCode.OleDB.ExecuteAsync(tcommonCode.UpdateExInsertQuery()))
        return true;
      tcommonCode.message = " " + tcommonCode.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tcommonCode.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tcommonCode.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tcommonCode.comm_Type, (object) tcommonCode.comm_TypeNo, (object) tcommonCode.comm_SiteID) + " 내용 : " + tcommonCode.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tcommonCode.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "comm_SiteID") && Convert.ToInt64(hashtable[(object) "comm_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "comm_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "comm_Type") && Convert.ToInt32(hashtable[(object) "comm_Type"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "comm_Type", hashtable[(object) "comm_Type"]));
        if (hashtable.ContainsKey((object) "comm_TypeNo") && Convert.ToInt32(hashtable[(object) "comm_TypeNo"].ToString()) > -1)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "comm_TypeNo", hashtable[(object) "comm_TypeNo"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "comm_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "comm_UseYn") && hashtable[(object) "comm_UseYn"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "comm_UseYn", hashtable[(object) "comm_UseYn"]));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "comm_TypeMemo", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "comm_TypeNoMemo", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(") ");
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
        stringBuilder.Append(" SELECT  comm_Type,comm_TypeNo,comm_SiteID,comm_TypeMemo,comm_TypeNoMemo,comm_SortNo,comm_DataInt,comm_DataMoney,comm_DataString,comm_UseYn,comm_InDate,comm_InUser,comm_ModDate,comm_ModUser");
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
