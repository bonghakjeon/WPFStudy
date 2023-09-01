// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenuProp.TProgMenuProp
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

namespace UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenuProp
{
  public class TProgMenuProp : UbModelBase<TProgMenuProp>
  {
    private int _pmp_PropCode;
    private long _pmp_SiteID;
    private int _pmp_ProgKind;
    private int _pmp_SortNo;
    private string _pmp_PropName;
    private int _pmp_TableID;
    private string _pmp_ProgID;
    private string _pmp_ProgTitle;
    private int _pmp_PropType;
    private int _pmp_PropDepth;
    private string _pmp_IconUrl;
    private string _pmp_UseYn;
    private DateTime? _pmp_InDate;
    private int _pmp_InUser;
    private DateTime? _pmp_ModDate;
    private int _pmp_ModUser;

    public override object _Key => (object) new object[1]
    {
      (object) this.pmp_PropCode
    };

    public int pmp_PropCode
    {
      get => this._pmp_PropCode;
      set
      {
        this._pmp_PropCode = value;
        this.Changed(nameof (pmp_PropCode));
      }
    }

    public long pmp_SiteID
    {
      get => this._pmp_SiteID;
      set
      {
        this._pmp_SiteID = value;
        this.Changed(nameof (pmp_SiteID));
      }
    }

    public int pmp_ProgKind
    {
      get => this._pmp_ProgKind;
      set
      {
        this._pmp_ProgKind = value;
        this.Changed(nameof (pmp_ProgKind));
        this.Changed("pmp_ProgKindDesc");
      }
    }

    public string pmp_ProgKindDesc => this.pmp_ProgKind != 0 ? Enum2StrConverter.ToAppType(this.pmp_ProgKind).ToDescription() : string.Empty;

    public int pmp_SortNo
    {
      get => this._pmp_SortNo;
      set
      {
        this._pmp_SortNo = value;
        this.Changed(nameof (pmp_SortNo));
      }
    }

    public string pmp_PropName
    {
      get => this._pmp_PropName;
      set
      {
        this._pmp_PropName = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (pmp_PropName));
      }
    }

    public int pmp_TableID
    {
      get => this._pmp_TableID;
      set
      {
        this._pmp_TableID = value;
        this.Changed(nameof (pmp_TableID));
        this.Changed("pmp_TableIDDesc");
      }
    }

    public string pmp_TableIDDesc => this.pmp_TableID != 0 ? Enum2StrConverter.ToTableType(this.pmp_TableID).ToDescription() : string.Empty;

    public string pmp_ProgID
    {
      get => this._pmp_ProgID;
      set
      {
        this._pmp_ProgID = UbModelBase.LeftStr(value, 200).Replace("'", "´");
        this.Changed(nameof (pmp_ProgID));
      }
    }

    public string pmp_ProgTitle
    {
      get => this._pmp_ProgTitle;
      set
      {
        this._pmp_ProgTitle = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (pmp_ProgTitle));
      }
    }

    public int pmp_PropType
    {
      get => this._pmp_PropType;
      set
      {
        this._pmp_PropType = value;
        this.Changed(nameof (pmp_PropType));
        this.Changed("pmp_PropTypeDesc");
      }
    }

    public string pmp_PropTypeDesc => this.pmp_PropType != 0 ? Enum2StrConverter.ToMenuPropType(this.pmp_PropType).ToDescription() : string.Empty;

    public int pmp_PropDepth
    {
      get => this._pmp_PropDepth;
      set
      {
        this._pmp_PropDepth = value;
        this.Changed(nameof (pmp_PropDepth));
        this.Changed("pmp_PropDepthDesc");
      }
    }

    public string pmp_PropDepthDesc => this.pmp_PropDepth != 0 ? Enum2StrConverter.ToMenuPropDepth(this.pmp_PropDepth).ToDescription() : string.Empty;

    public string pmp_IconUrl
    {
      get => this._pmp_IconUrl;
      set
      {
        this._pmp_IconUrl = UbModelBase.LeftStr(value, 200).Replace("'", "´");
        this.Changed(nameof (pmp_IconUrl));
      }
    }

    public string pmp_UseYn
    {
      get => this._pmp_UseYn;
      set
      {
        this._pmp_UseYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (pmp_UseYn));
        this.Changed("pmp_IsUseYn");
        this.Changed("pmp_UseYnDesc");
      }
    }

    public bool pmp_IsUseYn => "Y".Equals(this.pmp_UseYn);

    public string pmp_UseYnDesc => !"Y".Equals(this.pmp_UseYn) ? "미사용" : "사용";

    public DateTime? pmp_InDate
    {
      get => this._pmp_InDate;
      set
      {
        this._pmp_InDate = value;
        this.Changed(nameof (pmp_InDate));
        this.Changed("ModDate");
      }
    }

    public int pmp_InUser
    {
      get => this._pmp_InUser;
      set
      {
        this._pmp_InUser = value;
        this.Changed(nameof (pmp_InUser));
      }
    }

    public DateTime? pmp_ModDate
    {
      get => this._pmp_ModDate;
      set
      {
        this._pmp_ModDate = value;
        this.Changed(nameof (pmp_ModDate));
        this.Changed("ModDate");
      }
    }

    public int pmp_ModUser
    {
      get => this._pmp_ModUser;
      set
      {
        this._pmp_ModUser = value;
        this.Changed(nameof (pmp_ModUser));
      }
    }

    public override DateTime? ModDate => !this.pmp_ModDate.HasValue ? this.pmp_InDate : this.pmp_ModDate;

    public TProgMenuProp() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("pmp_PropCode", new TTableColumn()
      {
        tc_orgin_name = "pmp_PropCode",
        tc_trans_name = "팝업 코드"
      });
      columnInfo.Add("pmp_SiteID", new TTableColumn()
      {
        tc_orgin_name = "pmp_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("pmp_ProgKind", new TTableColumn()
      {
        tc_orgin_name = "pmp_ProgKind",
        tc_trans_name = "프로그램 종류"
      });
      columnInfo.Add("pmp_SortNo", new TTableColumn()
      {
        tc_orgin_name = "pmp_SortNo",
        tc_trans_name = "순서"
      });
      columnInfo.Add("pmp_PropName", new TTableColumn()
      {
        tc_orgin_name = "pmp_PropName",
        tc_trans_name = "팝업명"
      });
      columnInfo.Add("pmp_TableID", new TTableColumn()
      {
        tc_orgin_name = "pmp_TableID",
        tc_trans_name = "테이블 ID"
      });
      columnInfo.Add("pmp_ProgID", new TTableColumn()
      {
        tc_orgin_name = "pmp_ProgID",
        tc_trans_name = "팝업 ID"
      });
      columnInfo.Add("pmp_ProgTitle", new TTableColumn()
      {
        tc_orgin_name = "pmp_ProgTitle",
        tc_trans_name = "타이틀"
      });
      columnInfo.Add("pmp_PropType", new TTableColumn()
      {
        tc_orgin_name = "pmp_PropType",
        tc_trans_name = "타입",
        tc_comm_code = 36
      });
      columnInfo.Add("pmp_PropDepth", new TTableColumn()
      {
        tc_orgin_name = "pmp_PropDepth",
        tc_trans_name = "단계",
        tc_comm_code = 37
      });
      columnInfo.Add("pmp_IconUrl", new TTableColumn()
      {
        tc_orgin_name = "pmp_IconUrl",
        tc_trans_name = "이미지 URL"
      });
      columnInfo.Add("pmp_UseYn", new TTableColumn()
      {
        tc_orgin_name = "pmp_UseYn",
        tc_trans_name = "사용상태"
      });
      columnInfo.Add("pmp_InDate", new TTableColumn()
      {
        tc_orgin_name = "pmp_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("pmp_InUser", new TTableColumn()
      {
        tc_orgin_name = "pmp_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("pmp_ModDate", new TTableColumn()
      {
        tc_orgin_name = "pmp_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("pmp_ModUser", new TTableColumn()
      {
        tc_orgin_name = "pmp_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.ProgMenuProp;
      this.pmp_PropCode = 0;
      this.pmp_SiteID = 0L;
      this.pmp_ProgKind = this.pmp_SortNo = 0;
      this.pmp_PropName = string.Empty;
      this.pmp_TableID = 0;
      this.pmp_ProgID = string.Empty;
      this.pmp_ProgTitle = string.Empty;
      this.pmp_PropType = this.pmp_PropDepth = 0;
      this.pmp_IconUrl = string.Empty;
      this.pmp_UseYn = "Y";
      this.pmp_InDate = new DateTime?();
      this.pmp_ModDate = new DateTime?();
      this.pmp_InUser = this.pmp_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TProgMenuProp();

    public override object Clone()
    {
      TProgMenuProp tprogMenuProp = base.Clone() as TProgMenuProp;
      tprogMenuProp.pmp_PropCode = this.pmp_PropCode;
      tprogMenuProp.pmp_SiteID = this.pmp_SiteID;
      tprogMenuProp.pmp_ProgKind = this.pmp_ProgKind;
      tprogMenuProp.pmp_SortNo = this.pmp_SortNo;
      tprogMenuProp.pmp_PropName = this.pmp_PropName;
      tprogMenuProp.pmp_TableID = this.pmp_TableID;
      tprogMenuProp.pmp_ProgID = this.pmp_ProgID;
      tprogMenuProp.pmp_ProgTitle = this.pmp_ProgTitle;
      tprogMenuProp.pmp_PropType = this.pmp_PropType;
      tprogMenuProp.pmp_PropDepth = this.pmp_PropDepth;
      tprogMenuProp.pmp_IconUrl = this.pmp_IconUrl;
      tprogMenuProp.pmp_UseYn = this.pmp_UseYn;
      tprogMenuProp.pmp_InDate = this.pmp_InDate;
      tprogMenuProp.pmp_ModDate = this.pmp_ModDate;
      tprogMenuProp.pmp_InUser = this.pmp_InUser;
      tprogMenuProp.pmp_ModUser = this.pmp_ModUser;
      return (object) tprogMenuProp;
    }

    public void PutData(TProgMenuProp pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.pmp_PropCode = pSource.pmp_PropCode;
      this.pmp_SiteID = pSource.pmp_SiteID;
      this.pmp_ProgKind = pSource.pmp_ProgKind;
      this.pmp_SortNo = pSource.pmp_SortNo;
      this.pmp_PropName = pSource.pmp_PropName;
      this.pmp_TableID = pSource.pmp_TableID;
      this.pmp_ProgID = pSource.pmp_ProgID;
      this.pmp_ProgTitle = pSource.pmp_ProgTitle;
      this.pmp_PropType = pSource.pmp_PropType;
      this.pmp_PropDepth = pSource.pmp_PropDepth;
      this.pmp_IconUrl = pSource.pmp_IconUrl;
      this.pmp_UseYn = pSource.pmp_UseYn;
      this.pmp_InDate = pSource.pmp_InDate;
      this.pmp_ModDate = pSource.pmp_ModDate;
      this.pmp_InUser = pSource.pmp_InUser;
      this.pmp_ModUser = pSource.pmp_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.pmp_PropCode = p_rs.GetFieldInt("pmp_PropCode");
        if (this.pmp_PropCode == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.pmp_SiteID = p_rs.GetFieldLong("pmp_SiteID");
        this.pmp_ProgKind = p_rs.GetFieldInt("pmp_ProgKind");
        this.pmp_SortNo = p_rs.GetFieldInt("pmp_SortNo");
        this.pmp_PropName = p_rs.GetFieldString("pmp_PropName");
        this.pmp_TableID = p_rs.GetFieldInt("pmp_TableID");
        this.pmp_ProgID = p_rs.GetFieldString("pmp_ProgID");
        this.pmp_ProgTitle = p_rs.GetFieldString("pmp_ProgTitle");
        this.pmp_PropType = p_rs.GetFieldInt("pmp_PropType");
        this.pmp_PropDepth = p_rs.GetFieldInt("pmp_PropDepth");
        this.pmp_IconUrl = p_rs.GetFieldString("pmp_IconUrl");
        this.pmp_UseYn = p_rs.GetFieldString("pmp_UseYn");
        this.pmp_InDate = p_rs.GetFieldDateTime("pmp_InDate");
        this.pmp_InUser = p_rs.GetFieldInt("pmp_InUser");
        this.pmp_ModDate = p_rs.GetFieldDateTime("pmp_ModDate");
        this.pmp_ModUser = p_rs.GetFieldInt("pmp_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string CreateCodeQuery()
    {
      base.CreateCodeQuery();
      return " SELECT " + DbQueryHelper.ToIsNULL() + "(MAX(pmp_PropCode), 0)+1 AS pmp_PropCode" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode, (object) DbQueryHelper.ToWithNolock());
    }

    public override bool CreateCode(UniOleDatabase p_db)
    {
      UniOleDbRecordset uniOleDbRecordset = (UniOleDbRecordset) null;
      UniOleDatabase pOleDB = (UniOleDatabase) null;
      try
      {
        pOleDB = new UniOleDatabase(p_db.ConnectionUrl);
        uniOleDbRecordset = new UniOleDbRecordset(pOleDB, pOleDB.CommandTimeout);
        string codeQuery = this.CreateCodeQuery();
        if (!uniOleDbRecordset.Open(codeQuery))
        {
          this.message = " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) pOleDB.LastErrorID) + " 내용 : " + pOleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          return false;
        }
        if (uniOleDbRecordset.IsDataRead())
          this.pmp_PropCode = uniOleDbRecordset.GetFieldInt(0);
        return this.pmp_PropCode > 0;
      }
      finally
      {
        uniOleDbRecordset?.Close();
        pOleDB?.Close();
      }
    }

    public override async Task<bool> CreateCodeAsync(UniOleDatabase p_db)
    {
      TProgMenuProp tprogMenuProp = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(p_db.ConnectionUrl);
        rs = new UniOleDbRecordset(db, db.CommandTimeout);
        if (!await rs.OpenAsync(tprogMenuProp.CreateCodeQuery()))
        {
          tprogMenuProp.message = " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tprogMenuProp.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) db.LastErrorID) + " 내용 : " + db.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          return false;
        }
        if (await rs.IsDataReadAsync())
          tprogMenuProp.pmp_PropCode = rs.GetFieldInt(0);
        return tprogMenuProp.pmp_PropCode > 0;
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " pmp_PropCode,pmp_SiteID,pmp_ProgKind,pmp_SortNo,pmp_PropName,pmp_TableID,pmp_ProgID,pmp_ProgTitle,pmp_PropType,pmp_PropDepth,pmp_IconUrl,pmp_UseYn,pmp_InDate,pmp_InUser,pmp_ModDate,pmp_ModUser) VALUES ( " + string.Format(" {0}", (object) this.pmp_PropCode) + string.Format(",{0},{1}", (object) this.pmp_SiteID, (object) this.pmp_ProgKind) + string.Format(",{0},'{1}',{2}", (object) this.pmp_SortNo, (object) this.pmp_PropName, (object) this.pmp_TableID) + ",'" + this.pmp_ProgID + "','" + this.pmp_ProgTitle + "'" + string.Format(",{0},{1},'{2}','{3}'", (object) this.pmp_PropType, (object) this.pmp_PropDepth, (object) this.pmp_IconUrl, (object) this.pmp_UseYn) + string.Format(",{0},{1},{2},{3}", (object) this.pmp_InDate.GetDateToStrInNull(), (object) this.pmp_InUser, (object) this.pmp_ModDate.GetDateToStrInNull(), (object) this.pmp_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.pmp_PropCode, (object) this.pmp_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TProgMenuProp tprogMenuProp = this;
      // ISSUE: reference to a compiler-generated method
      tprogMenuProp.\u003C\u003En__0();
      if (await tprogMenuProp.OleDB.ExecuteAsync(tprogMenuProp.InsertQuery()))
        return true;
      tprogMenuProp.message = " " + tprogMenuProp.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tprogMenuProp.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tprogMenuProp.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tprogMenuProp.pmp_PropCode, (object) tprogMenuProp.pmp_SiteID) + " 내용 : " + tprogMenuProp.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tprogMenuProp.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + string.Format(" {0}={1}", (object) "pmp_SortNo", (object) this.pmp_SortNo) + ",pmp_PropName='" + this.pmp_PropName + "'" + string.Format(",{0}={1}", (object) "pmp_TableID", (object) this.pmp_TableID) + ",pmp_ProgID='" + this.pmp_ProgID + "',pmp_ProgTitle='" + this.pmp_ProgTitle + "'" + string.Format(",{0}={1}", (object) "pmp_PropType", (object) this.pmp_PropType) + string.Format(",{0}={1}", (object) "pmp_PropDepth", (object) this.pmp_PropDepth) + ",pmp_IconUrl='" + this.pmp_IconUrl + "',pmp_UseYn='" + this.pmp_UseYn + "'" + string.Format(",{0}={1},{2}={3}", (object) "pmp_ModDate", (object) this.pmp_ModDate.GetDateToStrInNull(), (object) "pmp_ModUser", (object) this.pmp_ModUser) + string.Format(" WHERE {0}={1}", (object) "pmp_PropCode", (object) this.pmp_PropCode) + string.Format(" AND {0}={1}", (object) "pmp_SiteID", (object) this.pmp_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.pmp_PropCode, (object) this.pmp_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TProgMenuProp tprogMenuProp = this;
      // ISSUE: reference to a compiler-generated method
      tprogMenuProp.\u003C\u003En__1();
      if (await tprogMenuProp.OleDB.ExecuteAsync(tprogMenuProp.UpdateQuery()))
        return true;
      tprogMenuProp.message = " " + tprogMenuProp.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tprogMenuProp.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tprogMenuProp.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tprogMenuProp.pmp_PropCode, (object) tprogMenuProp.pmp_SiteID) + " 내용 : " + tprogMenuProp.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tprogMenuProp.message);
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
      stringBuilder.Append(string.Format(" {0}={1}", (object) "pmp_SortNo", (object) this.pmp_SortNo) + ",pmp_PropName='" + this.pmp_PropName + "'" + string.Format(",{0}={1}", (object) "pmp_TableID", (object) this.pmp_TableID) + ",pmp_ProgID='" + this.pmp_ProgID + "',pmp_ProgTitle='" + this.pmp_ProgTitle + "'" + string.Format(",{0}={1}", (object) "pmp_PropType", (object) this.pmp_PropType) + string.Format(",{0}={1}", (object) "pmp_PropDepth", (object) this.pmp_PropDepth) + ",pmp_IconUrl='" + this.pmp_IconUrl + "',pmp_UseYn='" + this.pmp_UseYn + "'" + string.Format(",{0}={1},{2}={3}", (object) "pmp_ModDate", (object) this.pmp_ModDate.GetDateToStrInNull(), (object) "pmp_ModUser", (object) this.pmp_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.pmp_PropCode, (object) this.pmp_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TProgMenuProp tprogMenuProp = this;
      // ISSUE: reference to a compiler-generated method
      tprogMenuProp.\u003C\u003En__1();
      if (await tprogMenuProp.OleDB.ExecuteAsync(tprogMenuProp.UpdateExInsertQuery()))
        return true;
      tprogMenuProp.message = " " + tprogMenuProp.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tprogMenuProp.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tprogMenuProp.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tprogMenuProp.pmp_PropCode, (object) tprogMenuProp.pmp_SiteID) + " 내용 : " + tprogMenuProp.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tprogMenuProp.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "pmp_SiteID") && Convert.ToInt64(hashtable[(object) "pmp_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "pmp_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "pmp_PropCode") && Convert.ToInt32(hashtable[(object) "pmp_PropCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pmp_PropCode", hashtable[(object) "pmp_PropCode"]));
        else if (hashtable.ContainsKey((object) "pmp_PropCode_IN_") && hashtable[(object) "pmp_PropCode_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "pmp_PropCode", hashtable[(object) "pmp_PropCode_IN_"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pmp_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "pmp_ProgKind") && Convert.ToInt32(hashtable[(object) "pmp_ProgKind"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pmp_ProgKind", hashtable[(object) "pmp_ProgKind"]));
        if (hashtable.ContainsKey((object) "pmp_PropType") && Convert.ToInt32(hashtable[(object) "pmp_PropType"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pmp_PropType", hashtable[(object) "pmp_PropType"]));
        if (hashtable.ContainsKey((object) "pmp_PropDepth") && Convert.ToInt32(hashtable[(object) "pmp_PropDepth"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pmp_PropDepth", hashtable[(object) "pmp_PropDepth"]));
        if (hashtable.ContainsKey((object) "pmp_UseYn") && hashtable[(object) "pmp_UseYn"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "pmp_UseYn", hashtable[(object) "pmp_UseYn"]));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "pmp_PropName", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "pmp_ProgTitle", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "pmp_ProgID", hashtable[(object) "_KEY_WORD_"]));
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
        stringBuilder.Append(" SELECT  pmp_PropCode,pmp_SiteID,pmp_ProgKind,pmp_SortNo,pmp_PropName,pmp_TableID,pmp_ProgID,pmp_ProgTitle,pmp_PropType,pmp_PropDepth,pmp_IconUrl,pmp_UseYn,pmp_InDate,pmp_InUser,pmp_ModDate,pmp_ModUser");
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
