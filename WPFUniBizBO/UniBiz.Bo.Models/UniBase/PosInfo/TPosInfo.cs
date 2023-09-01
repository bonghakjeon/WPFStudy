// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.PosInfo.TPosInfo
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

namespace UniBiz.Bo.Models.UniBase.PosInfo
{
  public class TPosInfo : UbModelBase<TPosInfo>
  {
    private int _pos_ID;
    private long _pos_SiteID;
    private int _pos_StoreCode;
    private int _pos_VanID;
    private int _pos_AdditionalOpt;
    private string _pos_Name;
    private string _pos_LocalIP;
    private string _pos_MemberInfoModYn;
    private string _pos_UseYn;
    private DateTime? _pos_InDate;
    private DateTime? _pos_ModDate;
    private int _pos_InUser;
    private int _pos_ModUser;

    public override object _Key => (object) new object[1]
    {
      (object) this.pos_ID
    };

    public int pos_ID
    {
      get => this._pos_ID;
      set
      {
        this._pos_ID = value;
        this.Changed(nameof (pos_ID));
      }
    }

    public long pos_SiteID
    {
      get => this._pos_SiteID;
      set
      {
        this._pos_SiteID = value;
        this.Changed(nameof (pos_SiteID));
      }
    }

    public int pos_StoreCode
    {
      get => this._pos_StoreCode;
      set
      {
        this._pos_StoreCode = value;
        this.Changed(nameof (pos_StoreCode));
      }
    }

    public int pos_VanID
    {
      get => this._pos_VanID;
      set
      {
        this._pos_VanID = value;
        this.Changed(nameof (pos_VanID));
      }
    }

    public int pos_AdditionalOpt
    {
      get => this._pos_AdditionalOpt;
      set
      {
        this._pos_AdditionalOpt = value;
        this.Changed(nameof (pos_AdditionalOpt));
        this.Changed("IsPosTypePos");
        this.Changed("IsPosTypeKiosk");
        this.Changed("IsPosTypeNextPos");
        this.Changed("IsPosTypePDA");
        this.Changed("IsPosReturnPossbile");
        this.Changed("IsPosEnuryPossbile");
        this.Changed("IsPosGiftsPossbile");
        this.Changed("IsPosTypeDelivery");
        this.Changed("IsPosTypeVirtual");
        this.Changed("IsPosICCenterm");
      }
    }

    public bool IsPosTypePos => PosInfoAddPropertyDef.IsPos(this.pos_AdditionalOpt);

    public bool IsPosTypeKiosk => PosInfoAddPropertyDef.IsKiosk(this.pos_AdditionalOpt);

    public bool IsPosTypeNextPos => PosInfoAddPropertyDef.IsNextPos(this.pos_AdditionalOpt);

    public bool IsPosTypePDA => PosInfoAddPropertyDef.IsPDA(this.pos_AdditionalOpt);

    public bool IsPosTypeDelivery => PosInfoAddPropertyDef.IsDeliveryPos(this.pos_AdditionalOpt);

    public bool IsPosTypeVirtual => PosInfoAddPropertyDef.IsVirtualPos(this.pos_AdditionalOpt);

    public bool IsPosReturnPossbile => PosInfoAddPropertyDef.IsReturnPossible(this.pos_AdditionalOpt);

    public bool IsPosEnuryPossbile => PosInfoAddPropertyDef.IsEnuryPossible(this.pos_AdditionalOpt);

    public bool IsPosGiftsPossbile => PosInfoAddPropertyDef.IsGiftsPossible(this.pos_AdditionalOpt);

    public bool IsPosICCenterm => PosInfoAddPropertyDef.IsICCenterm(this.pos_AdditionalOpt);

    public bool IsPosKeyTypeormal => PosInfoAddPropertyDef.IsPosKeyTypeNormal(this.pos_AdditionalOpt);

    public bool IsPosKeyTypeEvent => PosInfoAddPropertyDef.IsPosKeyTypeEvent(this.pos_AdditionalOpt);

    public string pos_Name
    {
      get => this._pos_Name;
      set
      {
        this._pos_Name = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (pos_Name));
      }
    }

    public string pos_LocalIP
    {
      get => this._pos_LocalIP;
      set
      {
        this._pos_LocalIP = value;
        this.Changed(nameof (pos_LocalIP));
      }
    }

    public string pos_MemberInfoModYn
    {
      get => this._pos_MemberInfoModYn;
      set
      {
        this._pos_MemberInfoModYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (pos_MemberInfoModYn));
        this.Changed("pos_IsMemberInfoMod");
        this.Changed("pos_MemberInfoModYnDesc");
      }
    }

    public bool pos_IsMemberInfoMod => this.pos_MemberInfoModYn.Equals("Y");

    public string pos_MemberInfoModYnDesc => !this.pos_MemberInfoModYn.Equals("Y") ? "불가능" : "가능";

    public string pos_UseYn
    {
      get => this._pos_UseYn;
      set
      {
        this._pos_UseYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (pos_UseYn));
        this.Changed("pos_IsUseYn");
        this.Changed("pos_UseYnDesc");
      }
    }

    public bool pos_IsUseYn => "Y".Equals(this.pos_UseYn);

    public string pos_UseYnDesc => !"Y".Equals(this.pos_UseYn) ? "미사용" : "사용";

    public DateTime? pos_InDate
    {
      get => this._pos_InDate;
      set
      {
        this._pos_InDate = value;
        this.Changed(nameof (pos_InDate));
      }
    }

    public DateTime? pos_ModDate
    {
      get => this._pos_ModDate;
      set
      {
        this._pos_ModDate = value;
        this.Changed(nameof (pos_ModDate));
      }
    }

    public int pos_InUser
    {
      get => this._pos_InUser;
      set
      {
        this._pos_InUser = value;
        this.Changed(nameof (pos_InUser));
      }
    }

    public int pos_ModUser
    {
      get => this._pos_ModUser;
      set
      {
        this._pos_ModUser = value;
        this.Changed(nameof (pos_ModUser));
      }
    }

    public TPosInfo() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("pos_ID", new TTableColumn()
      {
        tc_orgin_name = "pos_ID",
        tc_trans_name = "POS번호"
      });
      columnInfo.Add("pos_SiteID", new TTableColumn()
      {
        tc_orgin_name = "pos_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("pos_StoreCode", new TTableColumn()
      {
        tc_orgin_name = "pos_StoreCode",
        tc_trans_name = "매장코드"
      });
      columnInfo.Add("pos_VanID", new TTableColumn()
      {
        tc_orgin_name = "pos_VanID",
        tc_trans_name = "밴사코드"
      });
      columnInfo.Add("pos_AdditionalOpt", new TTableColumn()
      {
        tc_orgin_name = "pos_AdditionalOpt",
        tc_trans_name = "추가속성"
      });
      columnInfo.Add("pos_Name", new TTableColumn()
      {
        tc_orgin_name = "pos_Name",
        tc_trans_name = "POS명칭"
      });
      columnInfo.Add("pos_LocalIP", new TTableColumn()
      {
        tc_orgin_name = "pos_LocalIP",
        tc_trans_name = "POS IP주소"
      });
      columnInfo.Add("pos_MemberInfoModYn", new TTableColumn()
      {
        tc_orgin_name = "pos_MemberInfoModYn",
        tc_trans_name = "회원수정"
      });
      columnInfo.Add("pos_UseYn", new TTableColumn()
      {
        tc_orgin_name = "pos_UseYn",
        tc_trans_name = "사용상태"
      });
      columnInfo.Add("pos_InDate", new TTableColumn()
      {
        tc_orgin_name = "pos_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("pos_InUser", new TTableColumn()
      {
        tc_orgin_name = "pos_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("pos_ModDate", new TTableColumn()
      {
        tc_orgin_name = "pos_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("pos_ModUser", new TTableColumn()
      {
        tc_orgin_name = "pos_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.PosInfo;
      this.pos_ID = 0;
      this.pos_SiteID = 0L;
      this.pos_StoreCode = 0;
      this.pos_VanID = 0;
      this.pos_AdditionalOpt = 0;
      this.pos_Name = string.Empty;
      this.pos_LocalIP = string.Empty;
      this.pos_MemberInfoModYn = "Y";
      this.pos_UseYn = "Y";
      this.pos_InDate = new DateTime?();
      this.pos_InUser = 0;
      this.pos_ModDate = new DateTime?();
      this.pos_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TPosInfo();

    public override object Clone()
    {
      TPosInfo tposInfo = base.Clone() as TPosInfo;
      tposInfo.pos_ID = this.pos_ID;
      tposInfo.pos_SiteID = this.pos_SiteID;
      tposInfo.pos_StoreCode = this.pos_StoreCode;
      tposInfo.pos_VanID = this.pos_VanID;
      tposInfo.pos_AdditionalOpt = this.pos_AdditionalOpt;
      tposInfo.pos_Name = this.pos_Name;
      tposInfo.pos_LocalIP = this.pos_LocalIP;
      tposInfo.pos_MemberInfoModYn = this.pos_MemberInfoModYn;
      tposInfo.pos_UseYn = this.pos_UseYn;
      tposInfo.pos_InDate = this.pos_InDate;
      tposInfo.pos_InUser = this.pos_InUser;
      tposInfo.pos_ModDate = this.pos_ModDate;
      tposInfo.pos_ModUser = this.pos_ModUser;
      return (object) tposInfo;
    }

    public void PutData(TPosInfo pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.pos_ID = pSource.pos_ID;
      this.pos_SiteID = pSource.pos_SiteID;
      this.pos_StoreCode = pSource.pos_StoreCode;
      this.pos_VanID = pSource.pos_VanID;
      this.pos_AdditionalOpt = pSource.pos_AdditionalOpt;
      this.pos_Name = pSource.pos_Name;
      this.pos_LocalIP = pSource.pos_LocalIP;
      this.pos_MemberInfoModYn = pSource.pos_MemberInfoModYn;
      this.pos_UseYn = pSource.pos_UseYn;
      this.pos_InDate = pSource.pos_InDate;
      this.pos_InUser = pSource.pos_InUser;
      this.pos_ModDate = pSource.pos_ModDate;
      this.pos_ModUser = pSource.pos_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.pos_ID = p_rs.GetFieldInt("pos_ID");
        if (this.pos_ID == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.pos_SiteID = p_rs.GetFieldLong("pos_SiteID");
        this.pos_StoreCode = p_rs.GetFieldInt("pos_StoreCode");
        this.pos_VanID = p_rs.GetFieldInt("pos_VanID");
        this.pos_AdditionalOpt = p_rs.GetFieldInt("pos_AdditionalOpt");
        this.pos_Name = p_rs.GetFieldString("pos_Name");
        this.pos_LocalIP = p_rs.GetFieldString("pos_LocalIP");
        this.pos_MemberInfoModYn = p_rs.GetFieldString("pos_MemberInfoModYn");
        this.pos_UseYn = p_rs.GetFieldString("pos_UseYn");
        this.pos_InDate = p_rs.GetFieldDateTime("pos_InDate");
        this.pos_InUser = p_rs.GetFieldInt("pos_InUser");
        this.pos_ModDate = p_rs.GetFieldDateTime("pos_ModDate");
        this.pos_ModUser = p_rs.GetFieldInt("pos_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " pos_ID,pos_SiteID,pos_StoreCode,pos_VanID,pos_AdditionalOpt,pos_Name,pos_LocalIP,pos_MemberInfoModYn,pos_UseYn,pos_InDate,pos_InUser,pos_ModDate,pos_ModUser) VALUES ( " + string.Format(" {0}", (object) this.pos_ID) + string.Format(",{0},{1}", (object) this.pos_SiteID, (object) this.pos_StoreCode) + string.Format(",{0},{1}", (object) this.pos_VanID, (object) this.pos_AdditionalOpt) + ",'" + this.pos_Name + "','" + this.pos_LocalIP + "','" + this.pos_MemberInfoModYn + "','" + this.pos_UseYn + "'" + string.Format(",{0},{1}", (object) this.pos_InDate.GetDateToStrInNull(), (object) this.pos_InUser) + string.Format(",{0},{1}", (object) this.pos_ModDate.GetDateToStrInNull(), (object) this.pos_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.pos_ID, (object) this.pos_StoreCode, (object) this.pos_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TPosInfo tposInfo = this;
      // ISSUE: reference to a compiler-generated method
      tposInfo.\u003C\u003En__0();
      if (await tposInfo.OleDB.ExecuteAsync(tposInfo.InsertQuery()))
        return true;
      tposInfo.message = " " + tposInfo.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tposInfo.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tposInfo.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tposInfo.pos_ID, (object) tposInfo.pos_StoreCode, (object) tposInfo.pos_SiteID) + " 내용 : " + tposInfo.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tposInfo.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + string.Format(" {0}={1},{2}='{3}',{4}='{5}',{6}={7}", (object) "pos_StoreCode", (object) this.pos_StoreCode, (object) "pos_Name", (object) this.pos_Name, (object) "pos_LocalIP", (object) this.pos_LocalIP, (object) "pos_VanID", (object) this.pos_VanID) + string.Format(",{0}={1},{2}='{3}',{4}='{5}'", (object) "pos_AdditionalOpt", (object) this.pos_AdditionalOpt, (object) "pos_MemberInfoModYn", (object) this.pos_MemberInfoModYn, (object) "pos_UseYn", (object) this.pos_UseYn) + string.Format(",{0}={1},{2}={3}", (object) "pos_ModDate", (object) this.pos_ModDate.GetDateToStrInNull(), (object) "pos_ModUser", (object) this.pos_ModUser) + string.Format(" WHERE {0}={1}", (object) "pos_ID", (object) this.pos_ID) + string.Format(" AND {0}={1}", (object) "pos_SiteID", (object) this.pos_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.pos_ID, (object) this.pos_StoreCode, (object) this.pos_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TPosInfo tposInfo = this;
      // ISSUE: reference to a compiler-generated method
      tposInfo.\u003C\u003En__1();
      if (await tposInfo.OleDB.ExecuteAsync(tposInfo.UpdateQuery()))
        return true;
      tposInfo.message = " " + tposInfo.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tposInfo.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tposInfo.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tposInfo.pos_ID, (object) tposInfo.pos_StoreCode, (object) tposInfo.pos_SiteID) + " 내용 : " + tposInfo.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tposInfo.message);
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
      stringBuilder.Append(string.Format(" {0}={1},{2}='{3}',{4}='{5}',{6}={7}", (object) "pos_StoreCode", (object) this.pos_StoreCode, (object) "pos_Name", (object) this.pos_Name, (object) "pos_LocalIP", (object) this.pos_LocalIP, (object) "pos_VanID", (object) this.pos_VanID) + string.Format(",{0}={1},{2}='{3}',{4}='{5}'", (object) "pos_AdditionalOpt", (object) this.pos_AdditionalOpt, (object) "pos_MemberInfoModYn", (object) this.pos_MemberInfoModYn, (object) "pos_UseYn", (object) this.pos_UseYn) + string.Format(",{0}={1},{2}={3}", (object) "pos_ModDate", (object) this.pos_ModDate.GetDateToStrInNull(), (object) "pos_ModUser", (object) this.pos_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.pos_ID, (object) this.pos_StoreCode, (object) this.pos_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TPosInfo tposInfo = this;
      // ISSUE: reference to a compiler-generated method
      tposInfo.\u003C\u003En__1();
      if (await tposInfo.OleDB.ExecuteAsync(tposInfo.UpdateExInsertQuery()))
        return true;
      tposInfo.message = " " + tposInfo.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tposInfo.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tposInfo.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tposInfo.pos_ID, (object) tposInfo.pos_StoreCode, (object) tposInfo.pos_SiteID) + " 내용 : " + tposInfo.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tposInfo.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "pos_SiteID") && Convert.ToInt64(hashtable[(object) "pos_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "pos_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "pos_ID") && Convert.ToInt32(hashtable[(object) "pos_ID"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pos_ID", hashtable[(object) "pos_ID"]));
        else
          stringBuilder.Append(" AND pos_ID>0");
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pos_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "pos_StoreCode") && Convert.ToInt32(hashtable[(object) "pos_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pos_StoreCode", hashtable[(object) "pos_StoreCode"]));
        if (hashtable.ContainsKey((object) "pos_VanID") && Convert.ToInt32(hashtable[(object) "pos_VanID"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pos_VanID", hashtable[(object) "pos_VanID"]));
        if (hashtable.ContainsKey((object) "pos_AdditionalOpt") && Convert.ToInt32(hashtable[(object) "pos_AdditionalOpt"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pos_AdditionalOpt", hashtable[(object) "pos_AdditionalOpt"]));
        else if (hashtable.ContainsKey((object) "IsPosReturnPossbile") && Convert.ToBoolean(hashtable[(object) "IsPosReturnPossbile"].ToString()))
          stringBuilder.Append(string.Format(" AND ({0} & {1})={2}", (object) "pos_AdditionalOpt", (object) 32, (object) 32));
        else if (hashtable.ContainsKey((object) "IsPosEnuryPossbile") && Convert.ToBoolean(hashtable[(object) "IsPosEnuryPossbile"].ToString()))
          stringBuilder.Append(string.Format(" AND ({0} & {1})={2}", (object) "pos_AdditionalOpt", (object) 64, (object) 64));
        else if (hashtable.ContainsKey((object) "IsPosGiftsPossbile") && Convert.ToBoolean(hashtable[(object) "IsPosGiftsPossbile"].ToString()))
          stringBuilder.Append(string.Format(" AND ({0} & {1})={2}", (object) "pos_AdditionalOpt", (object) 16, (object) 16));
        else if (hashtable.ContainsKey((object) "IsPosTypeVirtual") && Convert.ToBoolean(hashtable[(object) "IsPosTypeVirtual"].ToString()))
          stringBuilder.Append(string.Format(" AND ({0} & {1})={2}", (object) "pos_AdditionalOpt", (object) 512, (object) 512));
        if (hashtable.ContainsKey((object) "pos_MemberInfoModYn") && hashtable[(object) "pos_MemberInfoModYn"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "pos_MemberInfoModYn", hashtable[(object) "pos_MemberInfoModYn"]));
        if (hashtable.ContainsKey((object) "pos_UseYn") && hashtable[(object) "pos_UseYn"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "pos_UseYn", hashtable[(object) "pos_UseYn"]));
        if (hashtable.ContainsKey((object) "pos_Name") && hashtable[(object) "pos_Name"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "pos_Name", hashtable[(object) "pos_Name"]));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} LIKE '%{1}%'", (object) "pos_Name", hashtable[(object) "_KEY_WORD_"]));
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
        stringBuilder.Append(" SELECT  pos_ID,pos_SiteID,pos_StoreCode,pos_VanID,pos_AdditionalOpt,pos_Name,pos_LocalIP,pos_MemberInfoModYn,pos_UseYn,pos_InDate,pos_InUser,pos_ModDate,pos_ModUser");
        stringBuilder.Append(" FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock());
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
