// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenu.TProgMenu
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

namespace UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenu
{
  public class TProgMenu : UbModelBase<TProgMenu>
  {
    private int _pm_MenuCode;
    private long _pm_SiteID;
    private int _pm_ProgKind;
    private string _pm_MenuSortNo;
    private string _pm_MenuName;
    private int _pm_GroupID;
    private string _pm_ProgID;
    private string _pm_ProgTitle;
    private int _pm_ViewType;
    private int _pm_MenuDepth;
    private string _pm_IconUrl;
    private string _pm_UseYn;
    private DateTime? _pm_InDate;
    private int _pm_InUser;
    private DateTime? _pm_ModDate;
    private int _pm_ModUser;

    public override object _Key => (object) new object[1]
    {
      (object) this.pm_MenuCode
    };

    public int pm_MenuCode
    {
      get => this._pm_MenuCode;
      set
      {
        this._pm_MenuCode = value;
        this.Changed(nameof (pm_MenuCode));
      }
    }

    public long pm_SiteID
    {
      get => this._pm_SiteID;
      set
      {
        this._pm_SiteID = value;
        this.Changed(nameof (pm_SiteID));
      }
    }

    public int pm_ProgKind
    {
      get => this._pm_ProgKind;
      set
      {
        this._pm_ProgKind = value;
        this.Changed(nameof (pm_ProgKind));
        this.Changed("pm_ProgKindDesc");
      }
    }

    public string pm_ProgKindDesc => this.pm_ProgKind != 0 ? Enum2StrConverter.ToAppType(this.pm_ProgKind).ToDescription() : string.Empty;

    public string pm_MenuSortNo
    {
      get => this._pm_MenuSortNo;
      set
      {
        this._pm_MenuSortNo = UbModelBase.LeftStr(value, 8).Replace("'", "´");
        this.Changed(nameof (pm_MenuSortNo));
      }
    }

    public string pm_MenuName
    {
      get => this._pm_MenuName;
      set
      {
        this._pm_MenuName = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (pm_MenuName));
      }
    }

    public int pm_GroupID
    {
      get => this._pm_GroupID;
      set
      {
        this._pm_GroupID = value;
        this.Changed(nameof (pm_GroupID));
      }
    }

    public string pm_ProgID
    {
      get => this._pm_ProgID;
      set
      {
        this._pm_ProgID = UbModelBase.LeftStr(value, 200).Replace("'", "´");
        this.Changed(nameof (pm_ProgID));
      }
    }

    public string pm_ProgTitle
    {
      get => this._pm_ProgTitle;
      set
      {
        this._pm_ProgTitle = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (pm_ProgTitle));
      }
    }

    public int pm_ViewType
    {
      get => this._pm_ViewType;
      set
      {
        this._pm_ViewType = value;
        this.Changed(nameof (pm_ViewType));
        this.Changed("pm_ViewTypeDesc");
      }
    }

    public string pm_ViewTypeDesc => this.pm_ViewType != 0 ? Enum2StrConverter.ToMenuType(this.pm_ViewType).ToDescription() : string.Empty;

    public int pm_MenuDepth
    {
      get => this._pm_MenuDepth;
      set
      {
        this._pm_MenuDepth = value;
        this.Changed(nameof (pm_MenuDepth));
        this.Changed("pm_MenuDepthDesc");
      }
    }

    public string pm_MenuDepthDesc => this.pm_MenuDepth != 0 ? Enum2StrConverter.ToMenuDepth(this.pm_MenuDepth).ToDescription() : string.Empty;

    public string pm_IconUrl
    {
      get => this._pm_IconUrl;
      set
      {
        this._pm_IconUrl = UbModelBase.LeftStr(value, 200).Replace("'", "´");
        this.Changed(nameof (pm_IconUrl));
      }
    }

    public string pm_UseYn
    {
      get => this._pm_UseYn;
      set
      {
        this._pm_UseYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (pm_UseYn));
        this.Changed("pm_IsUseYn");
        this.Changed("pm_UseYnDesc");
      }
    }

    public bool pm_IsUseYn => "Y".Equals(this.pm_UseYn);

    public string pm_UseYnDesc => !"Y".Equals(this.pm_UseYn) ? "미사용" : "사용";

    public DateTime? pm_InDate
    {
      get => this._pm_InDate;
      set
      {
        this._pm_InDate = value;
        this.Changed(nameof (pm_InDate));
        this.Changed("ModDate");
      }
    }

    public int pm_InUser
    {
      get => this._pm_InUser;
      set
      {
        this._pm_InUser = value;
        this.Changed(nameof (pm_InUser));
      }
    }

    public DateTime? pm_ModDate
    {
      get => this._pm_ModDate;
      set
      {
        this._pm_ModDate = value;
        this.Changed(nameof (pm_ModDate));
        this.Changed("ModDate");
      }
    }

    public int pm_ModUser
    {
      get => this._pm_ModUser;
      set
      {
        this._pm_ModUser = value;
        this.Changed(nameof (pm_ModUser));
      }
    }

    public override DateTime? ModDate => !this.pm_ModDate.HasValue ? this.pm_InDate : this.pm_ModDate;

    public TProgMenu() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("pm_MenuCode", new TTableColumn()
      {
        tc_orgin_name = "pm_MenuCode",
        tc_trans_name = "메뉴코드"
      });
      columnInfo.Add("pm_SiteID", new TTableColumn()
      {
        tc_orgin_name = "pm_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("pm_ProgKind", new TTableColumn()
      {
        tc_orgin_name = "pm_ProgKind",
        tc_trans_name = "프로그램 종류",
        tc_comm_code = 1
      });
      columnInfo.Add("pm_MenuSortNo", new TTableColumn()
      {
        tc_orgin_name = "pm_MenuSortNo",
        tc_trans_name = "프로그램 순위"
      });
      columnInfo.Add("pm_MenuName", new TTableColumn()
      {
        tc_orgin_name = "pm_MenuName",
        tc_trans_name = "메뉴명"
      });
      columnInfo.Add("pm_GroupID", new TTableColumn()
      {
        tc_orgin_name = "pm_GroupID",
        tc_trans_name = "모듈 ID"
      });
      columnInfo.Add("pm_ProgID", new TTableColumn()
      {
        tc_orgin_name = "pm_ProgID",
        tc_trans_name = "프로그램 ID"
      });
      columnInfo.Add("pm_ProgTitle", new TTableColumn()
      {
        tc_orgin_name = "pm_ProgTitle",
        tc_trans_name = "타이틀"
      });
      columnInfo.Add("pm_ViewType", new TTableColumn()
      {
        tc_orgin_name = "pm_ViewType",
        tc_trans_name = "뷰타입",
        tc_comm_code = 33
      });
      columnInfo.Add("pm_MenuDepth", new TTableColumn()
      {
        tc_orgin_name = "pm_MenuDepth",
        tc_trans_name = "단계",
        tc_comm_code = 34
      });
      columnInfo.Add("pm_IconUrl", new TTableColumn()
      {
        tc_orgin_name = "pm_IconUrl",
        tc_trans_name = "이미지 URL"
      });
      columnInfo.Add("pm_UseYn", new TTableColumn()
      {
        tc_orgin_name = "pm_UseYn",
        tc_trans_name = "사용상태"
      });
      columnInfo.Add("pm_InDate", new TTableColumn()
      {
        tc_orgin_name = "pm_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("pm_InUser", new TTableColumn()
      {
        tc_orgin_name = "pm_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("pm_ModDate", new TTableColumn()
      {
        tc_orgin_name = "pm_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("pm_ModUser", new TTableColumn()
      {
        tc_orgin_name = "pm_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.ProgMenu;
      this.pm_MenuCode = 0;
      this.pm_SiteID = 0L;
      this.pm_ProgKind = 0;
      this.pm_MenuSortNo = string.Empty;
      this.pm_MenuName = string.Empty;
      this.pm_GroupID = 0;
      this.pm_ProgID = string.Empty;
      this.pm_ProgTitle = string.Empty;
      this.pm_ViewType = this.pm_MenuDepth = 0;
      this.pm_IconUrl = string.Empty;
      this.pm_UseYn = "Y";
      this.pm_InDate = new DateTime?();
      this.pm_ModDate = new DateTime?();
      this.pm_InUser = this.pm_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TProgMenu();

    public override object Clone()
    {
      TProgMenu tprogMenu = base.Clone() as TProgMenu;
      tprogMenu.pm_MenuCode = this.pm_MenuCode;
      tprogMenu.pm_SiteID = this.pm_SiteID;
      tprogMenu.pm_ProgKind = this.pm_ProgKind;
      tprogMenu.pm_MenuSortNo = this.pm_MenuSortNo;
      tprogMenu.pm_MenuName = this.pm_MenuName;
      tprogMenu.pm_GroupID = this.pm_GroupID;
      tprogMenu.pm_ProgID = this.pm_ProgID;
      tprogMenu.pm_ProgTitle = this.pm_ProgTitle;
      tprogMenu.pm_ViewType = this.pm_ViewType;
      tprogMenu.pm_MenuDepth = this.pm_MenuDepth;
      tprogMenu.pm_IconUrl = this.pm_IconUrl;
      tprogMenu.pm_UseYn = this.pm_UseYn;
      tprogMenu.pm_InDate = this.pm_InDate;
      tprogMenu.pm_ModDate = this.pm_ModDate;
      tprogMenu.pm_InUser = this.pm_InUser;
      tprogMenu.pm_ModUser = this.pm_ModUser;
      return (object) tprogMenu;
    }

    public void PutData(TProgMenu pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.pm_MenuCode = pSource.pm_MenuCode;
      this.pm_SiteID = pSource.pm_SiteID;
      this.pm_ProgKind = pSource.pm_ProgKind;
      this.pm_MenuSortNo = pSource.pm_MenuSortNo;
      this.pm_MenuName = pSource.pm_MenuName;
      this.pm_GroupID = pSource.pm_GroupID;
      this.pm_ProgID = pSource.pm_ProgID;
      this.pm_ProgTitle = pSource.pm_ProgTitle;
      this.pm_ViewType = pSource.pm_ViewType;
      this.pm_MenuDepth = pSource.pm_MenuDepth;
      this.pm_IconUrl = pSource.pm_IconUrl;
      this.pm_UseYn = pSource.pm_UseYn;
      this.pm_InDate = pSource.pm_InDate;
      this.pm_ModDate = pSource.pm_ModDate;
      this.pm_InUser = pSource.pm_InUser;
      this.pm_ModUser = pSource.pm_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.pm_MenuCode = p_rs.GetFieldInt("pm_MenuCode");
        if (this.pm_MenuCode == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.pm_SiteID = p_rs.GetFieldLong("pm_SiteID");
        this.pm_ProgKind = p_rs.GetFieldInt("pm_ProgKind");
        this.pm_MenuSortNo = p_rs.GetFieldString("pm_MenuSortNo");
        this.pm_MenuName = p_rs.GetFieldString("pm_MenuName");
        this.pm_GroupID = p_rs.GetFieldInt("pm_GroupID");
        this.pm_ProgID = p_rs.GetFieldString("pm_ProgID");
        this.pm_ProgTitle = p_rs.GetFieldString("pm_ProgTitle");
        this.pm_ViewType = p_rs.GetFieldInt("pm_ViewType");
        this.pm_MenuDepth = p_rs.GetFieldInt("pm_MenuDepth");
        this.pm_IconUrl = p_rs.GetFieldString("pm_IconUrl");
        this.pm_UseYn = p_rs.GetFieldString("pm_UseYn");
        this.pm_InDate = p_rs.GetFieldDateTime("pm_InDate");
        this.pm_InUser = p_rs.GetFieldInt("pm_InUser");
        this.pm_ModDate = p_rs.GetFieldDateTime("pm_ModDate");
        this.pm_ModUser = p_rs.GetFieldInt("pm_ModUser");
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
      return " SELECT " + DbQueryHelper.ToIsNULL() + "(MAX(pm_MenuCode), 0)+1 AS pm_MenuCode" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode, (object) DbQueryHelper.ToWithNolock());
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
          this.pm_MenuCode = uniOleDbRecordset.GetFieldInt(0);
        return this.pm_MenuCode > 0;
      }
      finally
      {
        uniOleDbRecordset?.Close();
        pOleDB?.Close();
      }
    }

    public override async Task<bool> CreateCodeAsync(UniOleDatabase p_db)
    {
      TProgMenu tprogMenu = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(p_db.ConnectionUrl);
        rs = new UniOleDbRecordset(db, db.CommandTimeout);
        if (!await rs.OpenAsync(tprogMenu.CreateCodeQuery()))
        {
          tprogMenu.message = " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tprogMenu.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) db.LastErrorID) + " 내용 : " + db.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          return false;
        }
        if (await rs.IsDataReadAsync())
          tprogMenu.pm_MenuCode = rs.GetFieldInt(0);
        return tprogMenu.pm_MenuCode > 0;
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " pm_MenuCode,pm_SiteID,pm_ProgKind,pm_MenuSortNo,pm_MenuName,pm_GroupID,pm_ProgID,pm_ProgTitle,pm_ViewType,pm_MenuDepth,pm_IconUrl,pm_UseYn,pm_InDate,pm_InUser,pm_ModDate,pm_ModUser) VALUES ( " + string.Format(" {0}", (object) this.pm_MenuCode) + string.Format(",{0},{1}", (object) this.pm_SiteID, (object) this.pm_ProgKind) + string.Format(",'{0}','{1}',{2}", (object) this.pm_MenuSortNo, (object) this.pm_MenuName, (object) this.pm_GroupID) + ",'" + this.pm_ProgID + "','" + this.pm_ProgTitle + "'" + string.Format(",{0},{1},'{2}','{3}'", (object) this.pm_ViewType, (object) this.pm_MenuDepth, (object) this.pm_IconUrl, (object) this.pm_UseYn) + string.Format(",{0},{1},{2},{3}", (object) this.pm_InDate.GetDateToStrInNull(), (object) this.pm_InUser, (object) this.pm_ModDate.GetDateToStrInNull(), (object) this.pm_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.pm_MenuCode, (object) this.pm_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TProgMenu tprogMenu = this;
      // ISSUE: reference to a compiler-generated method
      tprogMenu.\u003C\u003En__0();
      if (await tprogMenu.OleDB.ExecuteAsync(tprogMenu.InsertQuery()))
        return true;
      tprogMenu.message = " " + tprogMenu.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tprogMenu.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tprogMenu.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tprogMenu.pm_MenuCode, (object) tprogMenu.pm_SiteID) + " 내용 : " + tprogMenu.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tprogMenu.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " pm_MenuSortNo='" + this.pm_MenuSortNo + "',pm_MenuName='" + this.pm_MenuName + "'" + string.Format(",{0}={1}", (object) "pm_GroupID", (object) this.pm_GroupID) + ",pm_ProgID='" + this.pm_ProgID + "',pm_ProgTitle='" + this.pm_ProgTitle + "'" + string.Format(",{0}={1}", (object) "pm_ViewType", (object) this.pm_ViewType) + string.Format(",{0}={1}", (object) "pm_MenuDepth", (object) this.pm_MenuDepth) + ",pm_IconUrl='" + this.pm_IconUrl + "',pm_UseYn='" + this.pm_UseYn + "'" + string.Format(",{0}={1},{2}={3}", (object) "pm_ModDate", (object) this.pm_ModDate.GetDateToStrInNull(), (object) "pm_ModUser", (object) this.pm_ModUser) + string.Format(" WHERE {0}={1}", (object) "pm_MenuCode", (object) this.pm_MenuCode) + string.Format(" AND {0}={1}", (object) "pm_SiteID", (object) this.pm_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.pm_MenuCode, (object) this.pm_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TProgMenu tprogMenu = this;
      // ISSUE: reference to a compiler-generated method
      tprogMenu.\u003C\u003En__1();
      if (await tprogMenu.OleDB.ExecuteAsync(tprogMenu.UpdateQuery()))
        return true;
      tprogMenu.message = " " + tprogMenu.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tprogMenu.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tprogMenu.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tprogMenu.pm_MenuCode, (object) tprogMenu.pm_SiteID) + " 내용 : " + tprogMenu.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tprogMenu.message);
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
      stringBuilder.Append(" pm_MenuSortNo='" + this.pm_MenuSortNo + "',pm_MenuName='" + this.pm_MenuName + "'" + string.Format(",{0}={1}", (object) "pm_GroupID", (object) this.pm_GroupID) + ",pm_ProgID='" + this.pm_ProgID + "',pm_ProgTitle='" + this.pm_ProgTitle + "'" + string.Format(",{0}={1}", (object) "pm_ViewType", (object) this.pm_ViewType) + string.Format(",{0}={1}", (object) "pm_MenuDepth", (object) this.pm_MenuDepth) + ",pm_IconUrl='" + this.pm_IconUrl + "',pm_UseYn='" + this.pm_UseYn + "'" + string.Format(",{0}={1},{2}={3}", (object) "pm_ModDate", (object) this.pm_ModDate.GetDateToStrInNull(), (object) "pm_ModUser", (object) this.pm_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.pm_MenuCode, (object) this.pm_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TProgMenu tprogMenu = this;
      // ISSUE: reference to a compiler-generated method
      tprogMenu.\u003C\u003En__1();
      if (await tprogMenu.OleDB.ExecuteAsync(tprogMenu.UpdateExInsertQuery()))
        return true;
      tprogMenu.message = " " + tprogMenu.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tprogMenu.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tprogMenu.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tprogMenu.pm_MenuCode, (object) tprogMenu.pm_SiteID) + " 내용 : " + tprogMenu.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tprogMenu.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "pm_SiteID") && Convert.ToInt64(hashtable[(object) "pm_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "pm_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "pm_MenuCode") && Convert.ToInt32(hashtable[(object) "pm_MenuCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pm_MenuCode", hashtable[(object) "pm_MenuCode"]));
        else if (hashtable.ContainsKey((object) "pm_MenuCode_IN_") && hashtable[(object) "pm_MenuCode_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "pm_MenuCode", hashtable[(object) "pm_MenuCode_IN_"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pm_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "pm_ProgKind") && Convert.ToInt32(hashtable[(object) "pm_ProgKind"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pm_ProgKind", hashtable[(object) "pm_ProgKind"]));
        if (hashtable.ContainsKey((object) "pm_ViewType") && Convert.ToInt32(hashtable[(object) "pm_ViewType"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pm_ViewType", hashtable[(object) "pm_ViewType"]));
        if (hashtable.ContainsKey((object) "pm_MenuDepth") && Convert.ToInt32(hashtable[(object) "pm_MenuDepth"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pm_MenuDepth", hashtable[(object) "pm_MenuDepth"]));
        if (hashtable.ContainsKey((object) "pm_UseYn") && hashtable[(object) "pm_UseYn"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "pm_UseYn", hashtable[(object) "pm_UseYn"]));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "pm_MenuName", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "pm_ProgTitle", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "pm_ProgID", hashtable[(object) "_KEY_WORD_"]));
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
        stringBuilder.Append(" SELECT  pm_MenuCode,pm_SiteID,pm_ProgKind,pm_MenuSortNo,pm_MenuName,pm_GroupID,pm_ProgID,pm_ProgTitle,pm_ViewType,pm_MenuDepth,pm_IconUrl,pm_UseYn,pm_InDate,pm_InUser,pm_ModDate,pm_ModUser");
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
