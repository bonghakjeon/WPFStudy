// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Store.Location.TLocation
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

namespace UniBiz.Bo.Models.UniBase.Store.Location
{
  public class TLocation : UbModelBase<TLocation>
  {
    private int _loc_LocationID;
    private long _loc_SiteID;
    private int _loc_StoreCode;
    private string _loc_LocationCode;
    private string _loc_LocationName;
    private int _loc_StorageDiv;
    private int _loc_SortNo;
    private int _loc_EmpCode;
    private int _loc_LocationType;
    private int _loc_PermitDiv;
    private int _loc_Level;
    private int _loc_PackUnit;
    private string _loc_Memo;
    private string _loc_UseYn;
    private DateTime? _loc_InDate;
    private int _loc_InUser;
    private DateTime? _loc_ModDate;
    private int _loc_ModUser;

    public override object _Key => (object) new object[1]
    {
      (object) this.loc_LocationID
    };

    public int loc_LocationID
    {
      get => this._loc_LocationID;
      set
      {
        this._loc_LocationID = value;
        this.Changed(nameof (loc_LocationID));
      }
    }

    public long loc_SiteID
    {
      get => this._loc_SiteID;
      set
      {
        this._loc_SiteID = value;
        this.Changed(nameof (loc_SiteID));
      }
    }

    public int loc_StoreCode
    {
      get => this._loc_StoreCode;
      set
      {
        this._loc_StoreCode = value;
        this.Changed(nameof (loc_StoreCode));
      }
    }

    public string loc_LocationCode
    {
      get => this._loc_LocationCode;
      set
      {
        this._loc_LocationCode = UbModelBase.LeftStr(value, 20).Replace("'", "´");
        this.Changed(nameof (loc_LocationCode));
      }
    }

    public string loc_LocationName
    {
      get => this._loc_LocationName;
      set
      {
        this._loc_LocationName = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (loc_LocationName));
      }
    }

    public int loc_StorageDiv
    {
      get => this._loc_StorageDiv;
      set
      {
        this._loc_StorageDiv = value;
        this.Changed(nameof (loc_StorageDiv));
        this.Changed("loc_StorageDivDesc");
      }
    }

    public string loc_StorageDivDesc => this.loc_StorageDiv != 0 ? Enum2StrConverter.ToCommonCodeTypeMemo(this.loc_SiteID, EnumCommonCodeType.StorageDiv, this.loc_StorageDiv) : string.Empty;

    public int loc_SortNo
    {
      get => this._loc_SortNo;
      set
      {
        this._loc_SortNo = value;
        this.Changed(nameof (loc_SortNo));
      }
    }

    public int loc_EmpCode
    {
      get => this._loc_EmpCode;
      set
      {
        this._loc_EmpCode = value;
        this.Changed(nameof (loc_EmpCode));
      }
    }

    public int loc_LocationType
    {
      get => this._loc_LocationType;
      set
      {
        this._loc_LocationType = value;
        this.Changed(nameof (loc_LocationType));
        this.Changed("loc_LocationTypeDesc");
      }
    }

    public string loc_LocationTypeDesc => this.loc_LocationType != 0 ? Enum2StrConverter.ToLocLocationType(this.loc_LocationType).ToDescription() : string.Empty;

    public int loc_PermitDiv
    {
      get => this._loc_PermitDiv;
      set
      {
        this._loc_PermitDiv = value;
        this.Changed(nameof (loc_PermitDiv));
        this.Changed("loc_PermitDivDesc");
      }
    }

    public string loc_PermitDivDesc => this.loc_PermitDiv != 0 ? Enum2StrConverter.ToLocPermitDiv(this.loc_PermitDiv).ToDescription() : string.Empty;

    public int loc_Level
    {
      get => this._loc_Level;
      set
      {
        this._loc_Level = value;
        this.Changed(nameof (loc_Level));
        this.Changed("loc_LevelDesc");
      }
    }

    public string loc_LevelDesc => this.loc_Level != 0 ? Enum2StrConverter.ToLocLevel(this.loc_Level).ToDescription() : string.Empty;

    public int loc_PackUnit
    {
      get => this._loc_PackUnit;
      set
      {
        this._loc_PackUnit = value;
        this.Changed(nameof (loc_PackUnit));
        this.Changed("loc_PackUnitDesc");
      }
    }

    public string loc_PackUnitDesc => this.loc_PackUnit != 0 ? Enum2StrConverter.ToPackUnit(this.loc_PackUnit).ToDescription() : string.Empty;

    public string loc_Memo
    {
      get => this._loc_Memo;
      set
      {
        this._loc_Memo = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (loc_Memo));
      }
    }

    public string loc_UseYn
    {
      get => this._loc_UseYn;
      set
      {
        this._loc_UseYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (loc_UseYn));
        this.Changed("loc_IsUse");
        this.Changed("loc_UseYnDesc");
      }
    }

    public bool loc_IsUse => "Y".Equals(this.loc_UseYn);

    public string loc_UseYnDesc => !"Y".Equals(this.loc_UseYn) ? "미사용" : "사용";

    public DateTime? loc_InDate
    {
      get => this._loc_InDate;
      set
      {
        this._loc_InDate = value;
        this.Changed(nameof (loc_InDate));
        this.Changed("ModDate");
      }
    }

    public int loc_InUser
    {
      get => this._loc_InUser;
      set
      {
        this._loc_InUser = value;
        this.Changed(nameof (loc_InUser));
      }
    }

    public DateTime? loc_ModDate
    {
      get => this._loc_ModDate;
      set
      {
        this._loc_ModDate = value;
        this.Changed(nameof (loc_ModDate));
        this.Changed("ModDate");
      }
    }

    public int loc_ModUser
    {
      get => this._loc_ModUser;
      set
      {
        this._loc_ModUser = value;
        this.Changed(nameof (loc_ModUser));
      }
    }

    public override DateTime? ModDate => this.loc_ModDate ?? (this.loc_ModDate = this.loc_InDate);

    public TLocation() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("loc_LocationID", new TTableColumn()
      {
        tc_orgin_name = "loc_LocationID",
        tc_trans_name = "로케이션ID"
      });
      columnInfo.Add("loc_SiteID", new TTableColumn()
      {
        tc_orgin_name = "loc_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("loc_StoreCode", new TTableColumn()
      {
        tc_orgin_name = "loc_StoreCode",
        tc_trans_name = "지점코드"
      });
      columnInfo.Add("loc_LocationCode", new TTableColumn()
      {
        tc_orgin_name = "loc_LocationCode",
        tc_trans_name = "로케이션코드"
      });
      columnInfo.Add("loc_LocationName", new TTableColumn()
      {
        tc_orgin_name = "loc_LocationName",
        tc_trans_name = "로케이션명"
      });
      columnInfo.Add("loc_StorageDiv", new TTableColumn()
      {
        tc_orgin_name = "loc_StorageDiv",
        tc_trans_name = "보관방법 [ETC_TYPE:57](1:상온,2:냉장,3:냉동)",
        tc_comm_code = 57
      });
      columnInfo.Add("loc_SortNo", new TTableColumn()
      {
        tc_orgin_name = "loc_SortNo",
        tc_trans_name = "순서"
      });
      columnInfo.Add("loc_EmpCode", new TTableColumn()
      {
        tc_orgin_name = "loc_EmpCode",
        tc_trans_name = "담당자"
      });
      columnInfo.Add("loc_LocationType", new TTableColumn()
      {
        tc_orgin_name = "loc_LocationType",
        tc_trans_name = "로케이션타입 [ETC_TYPE:61](1:일반,2:입출고,3:불량)",
        tc_comm_code = 61
      });
      columnInfo.Add("loc_PermitDiv", new TTableColumn()
      {
        tc_orgin_name = "loc_PermitDiv",
        tc_trans_name = "재고인정구분 [ETC_TYPE:62](1:인정,2:미인정)",
        tc_comm_code = 62
      });
      columnInfo.Add("loc_Level", new TTableColumn()
      {
        tc_orgin_name = "loc_Level",
        tc_trans_name = "단계 [ETC_TYPE:63](1:창고,2:지역,3:열,4:단<2:2:2:2, 1:층(F),2:곤도라,3:층,4:열>)",
        tc_comm_code = 63
      });
      columnInfo.Add("loc_PackUnit", new TTableColumn()
      {
        tc_orgin_name = "loc_PackUnit",
        tc_trans_name = "묶음단위 [ETC_TYPE:54](1:EA,2:BUNDLE,3:BOX,4:BOM)",
        tc_comm_code = 54
      });
      columnInfo.Add("loc_Memo", new TTableColumn()
      {
        tc_orgin_name = "loc_Memo",
        tc_trans_name = "메모"
      });
      columnInfo.Add("loc_UseYn", new TTableColumn()
      {
        tc_orgin_name = "loc_UseYn",
        tc_trans_name = "사용상태"
      });
      columnInfo.Add("loc_InDate", new TTableColumn()
      {
        tc_orgin_name = "loc_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("loc_InUser", new TTableColumn()
      {
        tc_orgin_name = "loc_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("loc_ModDate", new TTableColumn()
      {
        tc_orgin_name = "loc_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("loc_ModUser", new TTableColumn()
      {
        tc_orgin_name = "loc_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.Location;
      this.loc_LocationID = 0;
      this.loc_SiteID = 0L;
      this.loc_StoreCode = 0;
      this.loc_LocationCode = this.loc_LocationName = string.Empty;
      this.loc_StorageDiv = 0;
      this.loc_SortNo = this.loc_EmpCode = 0;
      this.loc_LocationType = 0;
      this.loc_PermitDiv = 0;
      this.loc_Level = 0;
      this.loc_PackUnit = 0;
      this.loc_Memo = string.Empty;
      this.loc_UseYn = "Y";
      this.loc_InDate = new DateTime?();
      this.loc_InUser = 0;
      this.loc_ModDate = new DateTime?();
      this.loc_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TLocation();

    public override object Clone()
    {
      TLocation tlocation = base.Clone() as TLocation;
      tlocation.loc_LocationID = this.loc_LocationID;
      tlocation.loc_SiteID = this.loc_SiteID;
      tlocation.loc_StoreCode = this.loc_StoreCode;
      tlocation.loc_LocationCode = this.loc_LocationCode;
      tlocation.loc_LocationName = this.loc_LocationName;
      tlocation.loc_StorageDiv = this.loc_StorageDiv;
      tlocation.loc_SortNo = this.loc_SortNo;
      tlocation.loc_EmpCode = this.loc_EmpCode;
      tlocation.loc_LocationType = this.loc_LocationType;
      tlocation.loc_PermitDiv = this.loc_PermitDiv;
      tlocation.loc_Level = this.loc_Level;
      tlocation.loc_PackUnit = this.loc_PackUnit;
      tlocation.loc_Memo = this.loc_Memo;
      tlocation.loc_UseYn = this.loc_UseYn;
      tlocation.loc_InDate = this.loc_InDate;
      tlocation.loc_ModDate = this.loc_ModDate;
      tlocation.loc_InUser = this.loc_InUser;
      tlocation.loc_ModUser = this.loc_ModUser;
      return (object) tlocation;
    }

    public void PutData(TLocation pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.loc_LocationID = pSource.loc_LocationID;
      this.loc_SiteID = pSource.loc_SiteID;
      this.loc_StoreCode = pSource.loc_StoreCode;
      this.loc_LocationCode = pSource.loc_LocationCode;
      this.loc_LocationName = pSource.loc_LocationName;
      this.loc_StorageDiv = pSource.loc_StorageDiv;
      this.loc_SortNo = pSource.loc_SortNo;
      this.loc_EmpCode = pSource.loc_EmpCode;
      this.loc_LocationType = pSource.loc_LocationType;
      this.loc_PermitDiv = pSource.loc_PermitDiv;
      this.loc_Level = pSource.loc_Level;
      this.loc_PackUnit = pSource.loc_PackUnit;
      this.loc_Memo = pSource.loc_Memo;
      this.loc_UseYn = pSource.loc_UseYn;
      this.loc_InDate = pSource.loc_InDate;
      this.loc_ModDate = pSource.loc_ModDate;
      this.loc_InUser = pSource.loc_InUser;
      this.loc_ModUser = pSource.loc_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.loc_LocationID = p_rs.GetFieldInt("loc_LocationID");
        if (this.loc_LocationID == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.loc_SiteID = p_rs.GetFieldLong("loc_SiteID");
        this.loc_StoreCode = p_rs.GetFieldInt("loc_StoreCode");
        this.loc_LocationCode = p_rs.GetFieldString("loc_LocationCode");
        this.loc_LocationName = p_rs.GetFieldString("loc_LocationName");
        this.loc_StorageDiv = p_rs.GetFieldInt("loc_StorageDiv");
        this.loc_SortNo = p_rs.GetFieldInt("loc_SortNo");
        this.loc_EmpCode = p_rs.GetFieldInt("loc_EmpCode");
        this.loc_LocationType = p_rs.GetFieldInt("loc_LocationType");
        this.loc_PermitDiv = p_rs.GetFieldInt("loc_PermitDiv");
        this.loc_Level = p_rs.GetFieldInt("loc_Level");
        this.loc_PackUnit = p_rs.GetFieldInt("loc_PackUnit");
        this.loc_Memo = p_rs.GetFieldString("loc_Memo");
        this.loc_UseYn = p_rs.GetFieldString("loc_UseYn");
        this.loc_InDate = p_rs.GetFieldDateTime("loc_InDate");
        this.loc_InUser = p_rs.GetFieldInt("loc_InUser");
        this.loc_ModDate = p_rs.GetFieldDateTime("loc_ModDate");
        this.loc_ModUser = p_rs.GetFieldInt("loc_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " loc_LocationID,loc_SiteID,loc_StoreCode,loc_LocationCode,loc_LocationName,loc_StorageDiv,loc_SortNo,loc_EmpCode,loc_LocationType,loc_PermitDiv,loc_Level,loc_PackUnit,loc_Memo,loc_UseYn,loc_InDate,loc_InUser,loc_ModDate,loc_ModUser) VALUES ( " + string.Format(" {0}", (object) this.loc_LocationID) + string.Format(",{0}", (object) this.loc_SiteID) + string.Format(",{0},'{1}','{2}'", (object) this.loc_StoreCode, (object) this.loc_LocationCode, (object) this.loc_LocationName) + string.Format(",{0},{1},{2}", (object) this.loc_StorageDiv, (object) this.loc_SortNo, (object) this.loc_EmpCode) + string.Format(",{0},{1},{2}", (object) this.loc_LocationType, (object) this.loc_PermitDiv, (object) this.loc_Level) + string.Format(",{0},'{1}','{2}'", (object) this.loc_PackUnit, (object) this.loc_Memo, (object) this.loc_UseYn) + string.Format(",{0},{1}", (object) this.loc_InDate.GetDateToStrInNull(), (object) this.loc_InUser) + string.Format(",{0},{1}", (object) this.loc_ModDate.GetDateToStrInNull(), (object) this.loc_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.loc_LocationID, (object) this.loc_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TLocation tlocation = this;
      // ISSUE: reference to a compiler-generated method
      tlocation.\u003C\u003En__0();
      if (await tlocation.OleDB.ExecuteAsync(tlocation.InsertQuery()))
        return true;
      tlocation.message = " " + tlocation.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tlocation.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tlocation.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tlocation.loc_LocationID, (object) tlocation.loc_SiteID) + " 내용 : " + tlocation.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tlocation.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + string.Format(" {0}={1}", (object) "loc_StoreCode", (object) this.loc_StoreCode) + ",loc_LocationCode='" + this.loc_LocationCode + "',loc_LocationName='" + this.loc_LocationName + "'" + string.Format(",{0}={1},{2}={3}", (object) "loc_StorageDiv", (object) this.loc_StorageDiv, (object) "loc_SortNo", (object) this.loc_SortNo) + string.Format(",{0}={1},{2}={3}", (object) "loc_EmpCode", (object) this.loc_EmpCode, (object) "loc_LocationType", (object) this.loc_LocationType) + string.Format(",{0}={1},{2}={3}", (object) "loc_PermitDiv", (object) this.loc_PermitDiv, (object) "loc_Level", (object) this.loc_Level) + string.Format(",{0}={1}", (object) "loc_PackUnit", (object) this.loc_PackUnit) + ",loc_Memo='" + this.loc_Memo + "',loc_UseYn='" + this.loc_UseYn + "'" + string.Format(",{0}={1},{2}={3}", (object) "loc_ModDate", (object) this.loc_ModDate.GetDateToStrInNull(), (object) "loc_ModUser", (object) this.loc_ModUser) + string.Format(" WHERE {0}={1}", (object) "loc_LocationID", (object) this.loc_LocationID) + string.Format(" AND {0}={1}", (object) "loc_SiteID", (object) this.loc_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.loc_LocationID, (object) this.loc_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TLocation tlocation = this;
      // ISSUE: reference to a compiler-generated method
      tlocation.\u003C\u003En__1();
      if (await tlocation.OleDB.ExecuteAsync(tlocation.UpdateQuery()))
        return true;
      tlocation.message = " " + tlocation.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tlocation.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tlocation.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tlocation.loc_LocationID, (object) tlocation.loc_SiteID) + " 내용 : " + tlocation.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tlocation.message);
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
      stringBuilder.Append(string.Format(" {0}={1}", (object) "loc_StoreCode", (object) this.loc_StoreCode) + ",loc_LocationCode='" + this.loc_LocationCode + "',loc_LocationName='" + this.loc_LocationName + "'" + string.Format(",{0}={1},{2}={3}", (object) "loc_StorageDiv", (object) this.loc_StorageDiv, (object) "loc_SortNo", (object) this.loc_SortNo) + string.Format(",{0}={1},{2}={3}", (object) "loc_EmpCode", (object) this.loc_EmpCode, (object) "loc_LocationType", (object) this.loc_LocationType) + string.Format(",{0}={1},{2}={3}", (object) "loc_PermitDiv", (object) this.loc_PermitDiv, (object) "loc_Level", (object) this.loc_Level) + string.Format(",{0}={1}", (object) "loc_PackUnit", (object) this.loc_PackUnit) + ",loc_Memo='" + this.loc_Memo + "',loc_UseYn='" + this.loc_UseYn + "'" + string.Format(",{0}={1},{2}={3}", (object) "loc_ModDate", (object) this.loc_ModDate.GetDateToStrInNull(), (object) "loc_ModUser", (object) this.loc_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.loc_LocationID, (object) this.loc_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TLocation tlocation = this;
      // ISSUE: reference to a compiler-generated method
      tlocation.\u003C\u003En__1();
      if (await tlocation.OleDB.ExecuteAsync(tlocation.UpdateExInsertQuery()))
        return true;
      tlocation.message = " " + tlocation.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tlocation.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tlocation.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tlocation.loc_LocationID, (object) tlocation.loc_SiteID) + " 내용 : " + tlocation.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tlocation.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "loc_SiteID") && Convert.ToInt64(hashtable[(object) "loc_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "loc_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "loc_LocationID") && Convert.ToInt32(hashtable[(object) "loc_LocationID"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "loc_LocationID", hashtable[(object) "loc_LocationID"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "loc_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "loc_StoreCode") && Convert.ToInt32(hashtable[(object) "loc_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "loc_StoreCode", hashtable[(object) "loc_StoreCode"]));
        else if (hashtable.ContainsKey((object) "si_StoreCode") && Convert.ToInt32(hashtable[(object) "si_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "loc_StoreCode", hashtable[(object) "si_StoreCode"]));
        else if (hashtable.ContainsKey((object) "si_StoreCode_IN_") && hashtable[(object) "si_StoreCode_IN_"].ToString().Length > 0)
        {
          if (hashtable[(object) "si_StoreCode_IN_"].ToString().Contains(","))
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "loc_StoreCode", hashtable[(object) "si_StoreCode_IN_"]));
          else
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "loc_StoreCode", hashtable[(object) "si_StoreCode_IN_"]));
        }
        else if (hashtable.ContainsKey((object) "loc_StoreCode_IN_") && hashtable[(object) "loc_StoreCode_IN_"].ToString().Length > 0)
        {
          if (hashtable[(object) "loc_StoreCode_IN_"].ToString().Contains(","))
            stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "loc_StoreCode", hashtable[(object) "loc_StoreCode_IN_"]));
          else
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "loc_StoreCode", hashtable[(object) "loc_StoreCode_IN_"]));
        }
        else if (hashtable.ContainsKey((object) "_STORE_AUTHS_") && !string.IsNullOrEmpty(hashtable[(object) "_STORE_AUTHS_"].ToString()))
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "loc_StoreCode", hashtable[(object) "_STORE_AUTHS_"]));
        if (hashtable.ContainsKey((object) "loc_LocationCode") && !string.IsNullOrEmpty(hashtable[(object) "loc_LocationCode"].ToString()))
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "loc_LocationCode", hashtable[(object) "loc_LocationCode"]));
        if (hashtable.ContainsKey((object) "loc_LocationName") && !string.IsNullOrEmpty(hashtable[(object) "loc_LocationName"].ToString()))
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "loc_LocationName", hashtable[(object) "loc_LocationName"]));
        if (hashtable.ContainsKey((object) "loc_StorageDiv") && Convert.ToInt32(hashtable[(object) "loc_StorageDiv"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "loc_StorageDiv", hashtable[(object) "loc_StorageDiv"]));
        if (hashtable.ContainsKey((object) "loc_EmpCode") && Convert.ToInt32(hashtable[(object) "loc_EmpCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "loc_EmpCode", hashtable[(object) "loc_EmpCode"]));
        if (hashtable.ContainsKey((object) "loc_LocationType") && Convert.ToInt32(hashtable[(object) "loc_LocationType"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "loc_LocationType", hashtable[(object) "loc_LocationType"]));
        if (hashtable.ContainsKey((object) "loc_PermitDiv") && Convert.ToInt32(hashtable[(object) "loc_PermitDiv"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "loc_PermitDiv", hashtable[(object) "loc_PermitDiv"]));
        if (hashtable.ContainsKey((object) "loc_Level") && Convert.ToInt32(hashtable[(object) "loc_Level"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "loc_Level", hashtable[(object) "loc_Level"]));
        if (hashtable.ContainsKey((object) "loc_PackUnit") && Convert.ToInt32(hashtable[(object) "loc_PackUnit"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "loc_PackUnit", hashtable[(object) "loc_PackUnit"]));
        if (hashtable.ContainsKey((object) "loc_UseYn") && !string.IsNullOrEmpty(hashtable[(object) "loc_UseYn"].ToString()))
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "loc_UseYn", hashtable[(object) "loc_UseYn"]));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "loc_LocationName", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "loc_LocationCode", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "loc_Memo", hashtable[(object) "_KEY_WORD_"]));
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
        stringBuilder.Append(" SELECT  loc_LocationID,loc_SiteID,loc_StoreCode,loc_LocationCode,loc_LocationName,loc_StorageDiv,loc_SortNo,loc_EmpCode,loc_LocationType,loc_PermitDiv,loc_Level,loc_PackUnit,loc_Memo,loc_UseYn,loc_InDate,loc_InUser,loc_ModDate,loc_ModUser");
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
