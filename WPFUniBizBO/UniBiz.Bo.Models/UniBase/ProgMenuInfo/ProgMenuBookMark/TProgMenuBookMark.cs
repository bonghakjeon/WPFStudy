// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenuBookMark.TProgMenuBookMark
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

namespace UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenuBookMark
{
  public class TProgMenuBookMark : UbModelBase<TProgMenuBookMark>
  {
    private long _pmbm_ID;
    private long _pmbm_SiteID;
    private long _pmbm_Parent;
    private int _pmbm_AppType;
    private int _pmbm_ViewType;
    private int _pmbm_EmpCode;
    private int _pmbm_MenuCode;
    private int _pmbm_Order;
    private int _pmbm_Depth;
    private string _pmbm_Title;
    private string _pmbm_Desc;
    private DateTime? _pmbm_InDate;
    private DateTime? _pmbm_ModDate;

    public override object _Key => (object) new object[1]
    {
      (object) this.pmbm_ID
    };

    public long pmbm_ID
    {
      get => this._pmbm_ID;
      set
      {
        this._pmbm_ID = value;
        this.Changed(nameof (pmbm_ID));
      }
    }

    public long pmbm_SiteID
    {
      get => this._pmbm_SiteID;
      set
      {
        this._pmbm_SiteID = value;
        this.Changed(nameof (pmbm_SiteID));
      }
    }

    public long pmbm_Parent
    {
      get => this._pmbm_Parent;
      set
      {
        this._pmbm_Parent = value;
        this.Changed(nameof (pmbm_Parent));
      }
    }

    public int pmbm_AppType
    {
      get => this._pmbm_AppType;
      set
      {
        this._pmbm_AppType = value;
        this.Changed(nameof (pmbm_AppType));
        this.Changed("pmbm_AppTypeDesc");
      }
    }

    public string pmbm_AppTypeDesc => this.pmbm_AppType != 0 ? Enum2StrConverter.ToAppType(this.pmbm_AppType).ToDescription() : string.Empty;

    public int pmbm_ViewType
    {
      get => this._pmbm_ViewType;
      set
      {
        this._pmbm_ViewType = value;
        this.Changed(nameof (pmbm_ViewType));
        this.Changed("pmbm_ViewTypeDesc");
        this.Changed("pmbm_IsViewTypeView");
      }
    }

    public string pmbm_ViewTypeDesc => this.pmbm_ViewType != 0 ? Enum2StrConverter.ToMenuType(this.pmbm_ViewType).ToDescription() : string.Empty;

    public bool pmbm_IsViewTypeView => this.pmbm_ViewType > 0 && Enum2StrConverter.ToMenuType(this.pmbm_ViewType) == EnumMenuType.View;

    public int pmbm_EmpCode
    {
      get => this._pmbm_EmpCode;
      set
      {
        this._pmbm_EmpCode = value;
        this.Changed(nameof (pmbm_EmpCode));
      }
    }

    public int pmbm_MenuCode
    {
      get => this._pmbm_MenuCode;
      set
      {
        this._pmbm_MenuCode = value;
        this.Changed(nameof (pmbm_MenuCode));
      }
    }

    public int pmbm_Order
    {
      get => this._pmbm_Order;
      set
      {
        this._pmbm_Order = value;
        this.Changed(nameof (pmbm_Order));
      }
    }

    public int pmbm_Depth
    {
      get => this._pmbm_Depth;
      set
      {
        this._pmbm_Depth = value;
        this.Changed(nameof (pmbm_Depth));
        this.Changed("pmbm_DepthDesc");
      }
    }

    public string pmbm_DepthDesc => this.pmbm_Depth != 0 ? Enum2StrConverter.ToMenuDepth(this.pmbm_Depth).ToDescription() : string.Empty;

    public string pmbm_Title
    {
      get => this._pmbm_Title;
      set
      {
        this._pmbm_Title = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (pmbm_Title));
      }
    }

    public string pmbm_Desc
    {
      get => this._pmbm_Desc;
      set
      {
        this._pmbm_Desc = UbModelBase.LeftStr(value, 500).Replace("'", "´");
        this.Changed(nameof (pmbm_Desc));
      }
    }

    public DateTime? pmbm_InDate
    {
      get => this._pmbm_InDate;
      set
      {
        this._pmbm_InDate = value;
        this.Changed(nameof (pmbm_InDate));
        this.Changed("ModDate");
      }
    }

    public DateTime? pmbm_ModDate
    {
      get => this._pmbm_ModDate;
      set
      {
        this._pmbm_ModDate = value;
        this.Changed(nameof (pmbm_ModDate));
        this.Changed("ModDate");
      }
    }

    public override DateTime? ModDate => this.pmbm_ModDate ?? (this.pmbm_ModDate = this.pmbm_InDate);

    public TProgMenuBookMark() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("pmbm_ID", new TTableColumn()
      {
        tc_orgin_name = "pmbm_ID",
        tc_trans_name = "ID"
      });
      columnInfo.Add("pmbm_SiteID", new TTableColumn()
      {
        tc_orgin_name = "pmbm_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("pmbm_Parent", new TTableColumn()
      {
        tc_orgin_name = "pmbm_Parent",
        tc_trans_name = "부모"
      });
      columnInfo.Add("pmbm_AppType", new TTableColumn()
      {
        tc_orgin_name = "pmbm_AppType",
        tc_trans_name = "프로그램 종류",
        tc_comm_code = 1
      });
      columnInfo.Add("pmbm_ViewType", new TTableColumn()
      {
        tc_orgin_name = "pmbm_ViewType",
        tc_trans_name = "뷰타입",
        tc_comm_code = 33
      });
      columnInfo.Add("pmbm_EmpCode", new TTableColumn()
      {
        tc_orgin_name = "pmbm_EmpCode",
        tc_trans_name = "사용자 코드"
      });
      columnInfo.Add("pmbm_MenuCode", new TTableColumn()
      {
        tc_orgin_name = "pmbm_MenuCode",
        tc_trans_name = "메뉴 코드"
      });
      columnInfo.Add("pmbm_Order", new TTableColumn()
      {
        tc_orgin_name = "pmbm_Order",
        tc_trans_name = "순서"
      });
      columnInfo.Add("pmbm_Depth", new TTableColumn()
      {
        tc_orgin_name = "pmbm_Depth",
        tc_trans_name = "단계",
        tc_comm_code = 34
      });
      columnInfo.Add("pmbm_Title", new TTableColumn()
      {
        tc_orgin_name = "pmbm_Title",
        tc_trans_name = "즐겨찿기"
      });
      columnInfo.Add("pmbm_Desc", new TTableColumn()
      {
        tc_orgin_name = "pmbm_Desc",
        tc_trans_name = "설명"
      });
      columnInfo.Add("pmbm_InDate", new TTableColumn()
      {
        tc_orgin_name = "pmbm_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("pmbm_ModDate", new TTableColumn()
      {
        tc_orgin_name = "pmbm_ModDate",
        tc_trans_name = "수정일"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.ProgMenuBookMark;
      this.pmbm_ID = this.pmbm_SiteID = this.pmbm_Parent = 0L;
      this.pmbm_AppType = 0;
      this.pmbm_ViewType = 0;
      this.pmbm_EmpCode = this.pmbm_MenuCode = 0;
      this.pmbm_Order = 0;
      this.pmbm_Depth = 0;
      this.pmbm_Title = this.pmbm_Desc = string.Empty;
      this.pmbm_InDate = new DateTime?();
      this.pmbm_ModDate = new DateTime?();
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TProgMenuBookMark();

    public override object Clone()
    {
      TProgMenuBookMark tprogMenuBookMark = base.Clone() as TProgMenuBookMark;
      tprogMenuBookMark.pmbm_ID = this.pmbm_ID;
      tprogMenuBookMark.pmbm_SiteID = this.pmbm_SiteID;
      tprogMenuBookMark.pmbm_Parent = this.pmbm_Parent;
      tprogMenuBookMark.pmbm_AppType = this.pmbm_AppType;
      tprogMenuBookMark.pmbm_ViewType = this.pmbm_ViewType;
      tprogMenuBookMark.pmbm_EmpCode = this.pmbm_EmpCode;
      tprogMenuBookMark.pmbm_MenuCode = this.pmbm_MenuCode;
      tprogMenuBookMark.pmbm_Order = this.pmbm_Order;
      tprogMenuBookMark.pmbm_Depth = this.pmbm_Depth;
      tprogMenuBookMark.pmbm_Title = this.pmbm_Title;
      tprogMenuBookMark.pmbm_Desc = this.pmbm_Desc;
      tprogMenuBookMark.pmbm_InDate = this.pmbm_InDate;
      tprogMenuBookMark.pmbm_ModDate = this.pmbm_ModDate;
      return (object) tprogMenuBookMark;
    }

    public void PutData(TProgMenuBookMark pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.pmbm_ID = pSource.pmbm_ID;
      this.pmbm_SiteID = pSource.pmbm_SiteID;
      this.pmbm_Parent = pSource.pmbm_Parent;
      this.pmbm_AppType = pSource.pmbm_AppType;
      this.pmbm_ViewType = pSource.pmbm_ViewType;
      this.pmbm_EmpCode = pSource.pmbm_EmpCode;
      this.pmbm_MenuCode = pSource.pmbm_MenuCode;
      this.pmbm_Order = pSource.pmbm_Order;
      this.pmbm_Depth = pSource.pmbm_Depth;
      this.pmbm_Title = pSource.pmbm_Title;
      this.pmbm_Desc = pSource.pmbm_Desc;
      this.pmbm_InDate = pSource.pmbm_InDate;
      this.pmbm_ModDate = pSource.pmbm_ModDate;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.pmbm_ID = p_rs.GetFieldLong("pmbm_ID");
        if (this.pmbm_ID == 0L)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.pmbm_SiteID = p_rs.GetFieldLong("pmbm_SiteID");
        this.pmbm_Parent = p_rs.GetFieldLong("pmbm_Parent");
        this.pmbm_AppType = p_rs.GetFieldInt("pmbm_AppType");
        this.pmbm_ViewType = p_rs.GetFieldInt("pmbm_ViewType");
        this.pmbm_EmpCode = p_rs.GetFieldInt("pmbm_EmpCode");
        this.pmbm_MenuCode = p_rs.GetFieldInt("pmbm_MenuCode");
        this.pmbm_Order = p_rs.GetFieldInt("pmbm_Order");
        this.pmbm_Depth = p_rs.GetFieldInt("pmbm_Depth");
        this.pmbm_Title = p_rs.GetFieldString("pmbm_Title");
        this.pmbm_Desc = p_rs.GetFieldString("pmbm_Desc");
        this.pmbm_InDate = p_rs.GetFieldDateTime("pmbm_InDate");
        this.pmbm_ModDate = p_rs.GetFieldDateTime("pmbm_ModDate");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " pmbm_ID,pmbm_SiteID,pmbm_Parent,pmbm_AppType,pmbm_ViewType,pmbm_EmpCode,pmbm_MenuCode,pmbm_Order,pmbm_Depth,pmbm_Title,pmbm_Desc,pmbm_InDate,pmbm_ModDate) VALUES ( " + string.Format(" {0}", (object) this.pmbm_ID) + string.Format(",{0}", (object) this.pmbm_SiteID) + string.Format(",{0},{1},{2}", (object) this.pmbm_Parent, (object) this.pmbm_AppType, (object) this.pmbm_ViewType) + string.Format(",{0},{1}", (object) this.pmbm_EmpCode, (object) this.pmbm_MenuCode) + string.Format(",{0},{1}", (object) this.pmbm_Order, (object) this.pmbm_Depth) + ",'" + this.pmbm_Title + "','" + this.pmbm_Desc + "'," + this.pmbm_InDate.GetDateToStrInNull() + "," + this.pmbm_ModDate.GetDateToStrInNull() + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.pmbm_ID, (object) this.pmbm_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TProgMenuBookMark tprogMenuBookMark = this;
      // ISSUE: reference to a compiler-generated method
      tprogMenuBookMark.\u003C\u003En__0();
      if (await tprogMenuBookMark.OleDB.ExecuteAsync(tprogMenuBookMark.InsertQuery()))
        return true;
      tprogMenuBookMark.message = " " + tprogMenuBookMark.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tprogMenuBookMark.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tprogMenuBookMark.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tprogMenuBookMark.pmbm_ID, (object) tprogMenuBookMark.pmbm_SiteID) + " 내용 : " + tprogMenuBookMark.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tprogMenuBookMark.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + string.Format(" {0}={1},{2}={3},{4}={5}", (object) "pmbm_Parent", (object) this.pmbm_Parent, (object) "pmbm_AppType", (object) this.pmbm_AppType, (object) "pmbm_ViewType", (object) this.pmbm_ViewType) + string.Format(",{0}={1},{2}={3}", (object) "pmbm_EmpCode", (object) this.pmbm_EmpCode, (object) "pmbm_MenuCode", (object) this.pmbm_MenuCode) + string.Format(",{0}={1},{2}={3}", (object) "pmbm_Order", (object) this.pmbm_Order, (object) "pmbm_Depth", (object) this.pmbm_Depth) + ",pmbm_Title='" + this.pmbm_Title + "',pmbm_Desc='" + this.pmbm_Desc + "',pmbm_ModDate=" + this.pmbm_ModDate.GetDateToStrInNull() + string.Format(" WHERE {0}={1}", (object) "pmbm_ID", (object) this.pmbm_ID) + string.Format(" AND {0}={1}", (object) "pmbm_SiteID", (object) this.pmbm_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.pmbm_ID, (object) this.pmbm_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TProgMenuBookMark tprogMenuBookMark = this;
      // ISSUE: reference to a compiler-generated method
      tprogMenuBookMark.\u003C\u003En__1();
      if (await tprogMenuBookMark.OleDB.ExecuteAsync(tprogMenuBookMark.UpdateQuery()))
        return true;
      tprogMenuBookMark.message = " " + tprogMenuBookMark.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tprogMenuBookMark.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tprogMenuBookMark.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tprogMenuBookMark.pmbm_ID, (object) tprogMenuBookMark.pmbm_SiteID) + " 내용 : " + tprogMenuBookMark.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tprogMenuBookMark.message);
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
      stringBuilder.Append(string.Format(" {0}={1},{2}={3},{4}={5}", (object) "pmbm_Parent", (object) this.pmbm_Parent, (object) "pmbm_AppType", (object) this.pmbm_AppType, (object) "pmbm_ViewType", (object) this.pmbm_ViewType) + string.Format(",{0}={1},{2}={3}", (object) "pmbm_EmpCode", (object) this.pmbm_EmpCode, (object) "pmbm_MenuCode", (object) this.pmbm_MenuCode) + string.Format(",{0}={1},{2}={3}", (object) "pmbm_Order", (object) this.pmbm_Order, (object) "pmbm_Depth", (object) this.pmbm_Depth) + ",pmbm_Title='" + this.pmbm_Title + "',pmbm_Desc='" + this.pmbm_Desc + "',pmbm_ModDate=" + this.pmbm_ModDate.GetDateToStrInNull());
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.pmbm_ID, (object) this.pmbm_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TProgMenuBookMark tprogMenuBookMark = this;
      // ISSUE: reference to a compiler-generated method
      tprogMenuBookMark.\u003C\u003En__1();
      if (await tprogMenuBookMark.OleDB.ExecuteAsync(tprogMenuBookMark.UpdateExInsertQuery()))
        return true;
      tprogMenuBookMark.message = " " + tprogMenuBookMark.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tprogMenuBookMark.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tprogMenuBookMark.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tprogMenuBookMark.pmbm_ID, (object) tprogMenuBookMark.pmbm_SiteID) + " 내용 : " + tprogMenuBookMark.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tprogMenuBookMark.message);
      return false;
    }

    public override string DeleteQuery() => string.Format(" DELETE FROM {0}{1}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + string.Format(" WHERE {0}={1}", (object) "pmbm_ID", (object) this.pmbm_ID) + string.Format(" AND {0}={1}", (object) "pmbm_SiteID", (object) this.pmbm_SiteID);

    public override bool Delete()
    {
      this.InsertChecked();
      string pStrExec = this.DeleteQuery();
      if (this.OleDB.Execute(pStrExec))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 삭제 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 코드 : ({0},{1})\n", (object) this.pmbm_ID, (object) this.pmbm_SiteID) + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n 쿼리 : " + pStrExec + "\n--------------------------------------------------------------------------------------------------\n";
      return false;
    }

    public override async Task<bool> DeleteAsync()
    {
      TProgMenuBookMark tprogMenuBookMark = this;
      // ISSUE: reference to a compiler-generated method
      tprogMenuBookMark.\u003C\u003En__0();
      if (await tprogMenuBookMark.OleDB.ExecuteAsync(tprogMenuBookMark.DeleteQuery()))
        return true;
      tprogMenuBookMark.message = " " + tprogMenuBookMark.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tprogMenuBookMark.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tprogMenuBookMark.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tprogMenuBookMark.pmbm_ID, (object) tprogMenuBookMark.pmbm_SiteID) + " 내용 : " + tprogMenuBookMark.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tprogMenuBookMark.message);
      return false;
    }

    public virtual string DeleteQuery(
      long p_pmbm_ID,
      int p_pmbm_EmpCode,
      long p_pmbm_Parent,
      long p_pmbm_SiteID = 0)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format(" DELETE FROM {0}{1} ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode));
      if (p_pmbm_ID > 0L)
        stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "pmbm_ID", (object) p_pmbm_ID));
      else if (p_pmbm_EmpCode > 0)
        stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "pmbm_EmpCode", (object) p_pmbm_EmpCode));
      else
        stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "pmbm_ID", (object) 0));
      if (p_pmbm_SiteID > 0L)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pmbm_SiteID", (object) p_pmbm_SiteID));
      if (p_pmbm_Parent > 0L)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pmbm_Parent", (object) p_pmbm_Parent));
      return stringBuilder.ToString();
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "pmbm_SiteID") && Convert.ToInt64(hashtable[(object) "pmbm_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "pmbm_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "pmbm_ID") && Convert.ToInt64(hashtable[(object) "pmbm_ID"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pmbm_ID", hashtable[(object) "pmbm_ID"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pmbm_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "pmbm_Parent") && Convert.ToInt64(hashtable[(object) "pmbm_Parent"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pmbm_Parent", hashtable[(object) "pmbm_Parent"]));
        if (hashtable.ContainsKey((object) "pmbm_AppType") && Convert.ToInt32(hashtable[(object) "pmbm_AppType"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pmbm_AppType", hashtable[(object) "pmbm_AppType"]));
        if (hashtable.ContainsKey((object) "pmbm_ViewType") && Convert.ToInt32(hashtable[(object) "pmbm_ViewType"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pmbm_ViewType", hashtable[(object) "pmbm_ViewType"]));
        if (hashtable.ContainsKey((object) "pmbm_EmpCode") && Convert.ToInt32(hashtable[(object) "pmbm_EmpCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pmbm_EmpCode", hashtable[(object) "pmbm_EmpCode"]));
        if (hashtable.ContainsKey((object) "pmbm_MenuCode") && Convert.ToInt32(hashtable[(object) "pmbm_MenuCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pmbm_MenuCode", hashtable[(object) "pmbm_MenuCode"]));
        if (hashtable.ContainsKey((object) "pmbm_Order") && Convert.ToInt32(hashtable[(object) "pmbm_Order"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pmbm_Order", hashtable[(object) "pmbm_Order"]));
        if (hashtable.ContainsKey((object) "pmbm_Depth") && Convert.ToInt32(hashtable[(object) "pmbm_Depth"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "pmbm_Depth", hashtable[(object) "pmbm_Depth"]));
        if (hashtable.ContainsKey((object) "pmbm_Title") && string.IsNullOrEmpty(hashtable[(object) "pmbm_Title"].ToString()))
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "pmbm_Title", hashtable[(object) "pmbm_Title"]));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && !string.IsNullOrEmpty(hashtable[(object) "_KEY_WORD_"].ToString()))
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "pmbm_Title", hashtable[(object) "_KEY_WORD_"]));
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
        stringBuilder.Append(" SELECT  pmbm_ID,pmbm_SiteID,pmbm_Parent,pmbm_AppType,pmbm_ViewType,pmbm_EmpCode,pmbm_MenuCode,pmbm_Order,pmbm_Depth,pmbm_Title,pmbm_Desc,pmbm_InDate,pmbm_ModDate");
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
