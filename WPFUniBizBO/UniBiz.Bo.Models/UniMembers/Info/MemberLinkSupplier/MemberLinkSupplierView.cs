// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.Info.MemberLinkSupplier.MemberLinkSupplierView
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
using UniBiz.Bo.Models.UniBase.Employee.Employee;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniMembers.Info.MemberLinkSupplier
{
  public class MemberLinkSupplierView : TMemberLinkSupplier<MemberLinkSupplierView>
  {
    private string _mbr_MemberName;
    private string _su_SupplierName;
    private int _si_MemberMntStore;
    private string _si_StoreNameMember;
    private string _inEmpName;

    public string mbr_MemberName
    {
      get => this._mbr_MemberName;
      set
      {
        this._mbr_MemberName = value;
        this.Changed(nameof (mbr_MemberName));
      }
    }

    public string su_SupplierName
    {
      get => this._su_SupplierName;
      set
      {
        this._su_SupplierName = value;
        this.Changed(nameof (su_SupplierName));
      }
    }

    public int si_MemberMntStore
    {
      get => this._si_MemberMntStore;
      set
      {
        this._si_MemberMntStore = value;
        this.Changed(nameof (si_MemberMntStore));
      }
    }

    public string si_StoreNameMember
    {
      get => this._si_StoreNameMember;
      set
      {
        this._si_StoreNameMember = value;
        this.Changed(nameof (si_StoreNameMember));
      }
    }

    public string inEmpName
    {
      get => this._inEmpName;
      set
      {
        this._inEmpName = value;
        this.Changed(nameof (inEmpName));
      }
    }

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("mbr_MemberName", new TTableColumn()
      {
        tc_orgin_name = "mbr_MemberName",
        tc_trans_name = "회원명",
        tc_col_status = 1
      });
      columnInfo.Add("su_SupplierName", new TTableColumn()
      {
        tc_orgin_name = "su_SupplierName",
        tc_trans_name = "업체명",
        tc_col_status = 1
      });
      columnInfo.Add("si_MemberMntStore", new TTableColumn()
      {
        tc_orgin_name = "si_MemberMntStore",
        tc_trans_name = "포인트 지점",
        tc_col_status = 1
      });
      columnInfo.Add("si_StoreNameMember", new TTableColumn()
      {
        tc_orgin_name = "si_StoreNameMember",
        tc_trans_name = "포인트 지점명",
        tc_col_status = 1
      });
      columnInfo.Add("inEmpName", new TTableColumn()
      {
        tc_orgin_name = "inEmpName",
        tc_trans_name = "등록사원",
        tc_col_status = 1
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.mbr_MemberName = this.su_SupplierName = string.Empty;
      this.si_MemberMntStore = 0;
      this.si_StoreNameMember = string.Empty;
      this.inEmpName = string.Empty;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new MemberLinkSupplierView();

    public override object Clone()
    {
      MemberLinkSupplierView linkSupplierView = base.Clone() as MemberLinkSupplierView;
      linkSupplierView.mbr_MemberName = this.mbr_MemberName;
      linkSupplierView.su_SupplierName = this.su_SupplierName;
      linkSupplierView.si_MemberMntStore = this.si_MemberMntStore;
      linkSupplierView.si_StoreNameMember = this.si_StoreNameMember;
      linkSupplierView.inEmpName = this.inEmpName;
      return (object) linkSupplierView;
    }

    public void PutData(MemberLinkSupplierView pSource)
    {
      this.PutData((TMemberLinkSupplier) pSource);
      this.mbr_MemberName = pSource.mbr_MemberName;
      this.su_SupplierName = pSource.su_SupplierName;
      this.si_MemberMntStore = pSource.si_MemberMntStore;
      this.si_StoreNameMember = pSource.si_StoreNameMember;
      this.inEmpName = pSource.inEmpName;
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.mbrs_SiteID == 0L)
      {
        this.message = "싸이트(mbrs_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.mbrs_MemberNo == 0L)
      {
        this.message = "회원코드(mbrs_MemberNo)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.mbrs_Supplier == 0)
      {
        this.message = "업체코드(mbrs_Supplier)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.mbrs_MemberStore != 0)
        return EnumDataCheck.Success;
      this.message = "포인트지점코드(mbrs_MemberStore)  " + EnumDataCheck.CodeZero.ToDescription();
      return EnumDataCheck.CodeZero;
    }

    protected override EnumDataCheck DataCheck(UniOleDatabase p_db) => base.DataCheck(p_db);

    protected override bool IsPermit(EmployeeView p_app_employee)
    {
      if (p_app_employee == null)
      {
        this.message = "사용자 정보 NULL.";
        return false;
      }
      return EnumDataCheck.Success == this.DataCheck(this.OleDB);
    }

    public override bool InsertData(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      try
      {
        this.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != this.DataCheck(p_db))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (this.mbrs_SiteID == 0L)
            this.mbrs_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (!this.Insert())
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 등록 오류");
        this.db_status = 4;
        this.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        this.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        this.message = ex.Message;
      }
      return false;
    }

    public override async Task<bool> InsertDataAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      MemberLinkSupplierView linkSupplierView = this;
      try
      {
        linkSupplierView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != linkSupplierView.DataCheck(p_db))
            throw new UniServiceException(linkSupplierView.message, linkSupplierView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (linkSupplierView.mbrs_SiteID == 0L)
            linkSupplierView.mbrs_SiteID = p_app_employee.emp_SiteID;
          if (!linkSupplierView.IsPermit(p_app_employee))
            throw new UniServiceException(linkSupplierView.message, linkSupplierView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (!await linkSupplierView.InsertAsync())
          throw new UniServiceException(linkSupplierView.message, linkSupplierView.TableCode.ToDescription() + " 등록 오류");
        linkSupplierView.db_status = 4;
        linkSupplierView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        linkSupplierView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        linkSupplierView.message = ex.Message;
      }
      return false;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.mbr_MemberName = p_rs.GetFieldString("mbr_MemberName");
      this.su_SupplierName = p_rs.GetFieldString("su_SupplierName");
      this.si_MemberMntStore = p_rs.GetFieldInt("si_MemberMntStore");
      this.si_StoreNameMember = p_rs.GetFieldString("si_StoreNameMember");
      this.inEmpName = p_rs.GetFieldString("inEmpName");
      return true;
    }

    public async Task<MemberLinkSupplierView> SelectOneAsync(
      long p_mbrs_MemberNo,
      int p_mbrs_Supplier,
      int p_mbrs_MemberStore,
      long p_mbrs_SiteID = 0)
    {
      MemberLinkSupplierView linkSupplierView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "mbrs_MemberNo",
          (object) p_mbrs_MemberNo
        },
        {
          (object) "mbrs_Supplier",
          (object) p_mbrs_Supplier
        },
        {
          (object) "mbrs_MemberStore",
          (object) p_mbrs_MemberStore
        }
      };
      if (p_mbrs_SiteID > 0L)
        p_param.Add((object) "mbrs_SiteID", (object) p_mbrs_SiteID);
      return await linkSupplierView.SelectOneTAsync<MemberLinkSupplierView>((object) p_param);
    }

    public MemberLinkSupplierView SelectOne(
      long p_mbrs_MemberNo,
      int p_mbrs_Supplier,
      int p_mbrs_MemberStore,
      long p_mbrs_SiteID = 0)
    {
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "mbrs_MemberNo",
          (object) p_mbrs_MemberNo
        },
        {
          (object) "mbrs_Supplier",
          (object) p_mbrs_Supplier
        },
        {
          (object) "mbrs_MemberStore",
          (object) p_mbrs_MemberStore
        }
      };
      if (p_mbrs_SiteID > 0L)
        p_param.Add((object) "mbrs_SiteID", (object) p_mbrs_SiteID);
      return this.SelectOneT<MemberLinkSupplierView>((object) p_param);
    }

    public async Task<IList<MemberLinkSupplierView>> SelectListAsync(object p_param)
    {
      MemberLinkSupplierView linkSupplierView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(linkSupplierView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, linkSupplierView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(linkSupplierView1.GetSelectQuery(p_param)))
        {
          linkSupplierView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + linkSupplierView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<MemberLinkSupplierView>) null;
        }
        IList<MemberLinkSupplierView> lt_list = (IList<MemberLinkSupplierView>) new List<MemberLinkSupplierView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            MemberLinkSupplierView linkSupplierView2 = linkSupplierView1.OleDB.Create<MemberLinkSupplierView>();
            if (linkSupplierView2.GetFieldValues(rs))
            {
              linkSupplierView2.row_number = lt_list.Count + 1;
              lt_list.Add(linkSupplierView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + linkSupplierView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<MemberLinkSupplierView> SelectEnumerableAsync(object p_param)
    {
      MemberLinkSupplierView linkSupplierView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(linkSupplierView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, linkSupplierView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(linkSupplierView1.GetSelectQuery(p_param)))
        {
          linkSupplierView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + linkSupplierView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            MemberLinkSupplierView linkSupplierView2 = linkSupplierView1.OleDB.Create<MemberLinkSupplierView>();
            if (linkSupplierView2.GetFieldValues(rs))
            {
              linkSupplierView2.row_number = ++row_number;
              yield return linkSupplierView2;
            }
          }
          while (await rs.IsDataReadAsync());
        }
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public override string GetSelectWhereAnd(object p_param)
    {
      StringBuilder stringBuilder = new StringBuilder(this.GetSelectWhereAnd(p_param, false));
      if (string.IsNullOrWhiteSpace(stringBuilder.ToString()))
        stringBuilder.Append(" WHERE");
      return !stringBuilder.ToString().Equals(" WHERE") ? stringBuilder.Replace("WHERE AND", "WHERE").ToString() : string.Empty;
    }

    public override string GetSelectQuery(object p_param)
    {
      StringBuilder stringBuilder = new StringBuilder();
      try
      {
        string uniBase = UbModelBase.UNI_BASE;
        string str = this.TableCode.ToString();
        string empty = string.Empty;
        long num = 0;
        bool flag = true;
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
          if (hashtable.ContainsKey((object) "_ORDER_BY_COL_") && hashtable[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable.ContainsKey((object) "mbrs_SiteID") && Convert.ToInt64(hashtable[(object) "mbrs_SiteID"].ToString()) > 0L)
            num = Convert.ToInt64(hashtable[(object) "mbrs_SiteID"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS (\nSELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n,T_STORE_MEMBER AS (\nSELECT si_StoreCode,si_SiteID,si_StoreName,si_StoreViewCode,si_UseYn,si_LocationUseYn" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()) + string.Format("\nWHERE {0}={1}", (object) "si_SiteID", (object) num) + " AND si_StoreCode=si_MemberMntStore)");
        stringBuilder.Append("\n,T_MEMBER AS (\nSELECT mbr_MemberNo,mbr_SiteID,mbr_MemberName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) TableCodeType.Member, (object) DbQueryHelper.ToWithNolock()) + "\nWHERE mbr_MemberNo>0" + string.Format(" AND {0}={1}", (object) "mbr_SiteID", (object) num) + ")");
        stringBuilder.Append("\n,T_SUPPLIER AS (\nSELECT su_Supplier,su_SiteID,su_SupplierName,su_SupplierViewCode,su_SupplierType,su_PreTaxDiv,su_MultiSuplierDiv,su_DeductionDayDiv,su_NewStatementYn" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Supplier, (object) DbQueryHelper.ToWithNolock()) + "\nWHERE su_Supplier>0" + string.Format(" AND {0}={1}", (object) "su_SiteID", (object) num) + ")");
        stringBuilder.Append("\n,T_LINK AS (\nSELECT mbrs_MemberNo,mbrs_Supplier,mbrs_MemberStore,mbrs_SiteID,mbrs_InDate,mbrs_InUser\nFROM " + DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS) + str + " " + DbQueryHelper.ToWithNolock());
        if (p_param is Hashtable)
        {
          stringBuilder.Append("\n");
          stringBuilder.Append(new TMemberLinkSupplier().GetSelectWhereAnd(p_param));
        }
        stringBuilder.Append(")");
        stringBuilder.Append("\nSELECT  mbrs_MemberNo,mbrs_Supplier,mbrs_MemberStore,mbrs_SiteID,mbrs_InDate,mbrs_InUser,inEmpName,mbr_MemberName,su_SupplierName");
        if (flag)
        {
          stringBuilder.Append("\n,'' AS si_StoreNameMember,0 AS si_MemberMntStore");
          stringBuilder.Append("\nFROM T_LINK\nINNER JOIN T_MEMBER ON mbr_MemberNo=mbrs_MemberNo AND mbr_SiteID=mbrs_SiteID\nINNER JOIN T_SUPPLIER ON su_Supplier=mbrs_Supplier AND su_SiteID=mbrs_SiteID");
        }
        else
        {
          stringBuilder.Append("\n,si_StoreName AS si_StoreNameMember,si_MemberMntStore");
          stringBuilder.Append("\nFROM T_STORE_MEMBER\nLEFT OUTER JOIN T_LINK ON si_StoreCode=mbrs_MemberStore\nLEFT OUTER JOIN T_MEMBER ON mbr_MemberNo=mbrs_MemberNo AND mbr_SiteID=mbrs_SiteID\nLEFT OUTER JOIN T_SUPPLIER ON su_Supplier=mbrs_Supplier AND su_SiteID=mbrs_SiteID");
        }
        stringBuilder.Append("\nLEFT OUTER JOIN T_EMPLOYEE_IN ON mbrs_InUser=emp_CodeIn");
        if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append("\nORDER BY " + empty);
        else
          stringBuilder.Append("\nORDER BY mbrs_MemberNo,mbrs_Supplier,mbrs_MemberStore");
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
