// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.UniSite.UniSiteView
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

namespace UniBiz.Bo.Models.UniBase.UniSite
{
  public class UniSiteView : TUniSite<UniSiteView>
  {
    private int _usi_StoreCount;

    public int usi_StoreCount
    {
      get => this._usi_StoreCount;
      set
      {
        this._usi_StoreCount = value;
        this.Changed(nameof (usi_StoreCount));
      }
    }

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("usi_StoreCount", new TTableColumn()
      {
        tc_orgin_name = "usi_StoreCount",
        tc_trans_name = "지점건수"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.usi_StoreCount = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new UniSiteView();

    public override object Clone()
    {
      UniSiteView uniSiteView = base.Clone() as UniSiteView;
      uniSiteView.usi_StoreCount = this.usi_StoreCount;
      return (object) uniSiteView;
    }

    public void PutData(UniSiteView pSource)
    {
      this.PutData((TUniSite) pSource);
      this.usi_StoreCount = pSource.usi_StoreCount;
    }

    protected override EnumDataCheck DataCheck()
    {
      if (!string.IsNullOrEmpty(this.uis_SiteName))
        return EnumDataCheck.Success;
      this.message = "사이트명(uis_SiteName)  " + EnumDataCheck.Empty.ToDescription();
      return EnumDataCheck.Empty;
    }

    protected override EnumDataCheck DataCheck(UniOleDatabase p_db) => base.DataCheck(p_db);

    protected override bool IsPermit(EmployeeView p_app_employee)
    {
      if (EnumDataCheck.Success != this.DataCheck() || p_app_employee == null)
        return false;
      if (p_app_employee.IsSystem)
        return true;
      this.message = p_app_employee.emp_Name + "님(Permit) 변경불가.";
      return false;
    }

    public override string CreateCodeQuery()
    {
      base.CreateCodeQuery();
      string nowTime = DateHelper.GetNowTime("yyyyMMdd");
      string str = string.Format("{0}{1:D4}0000", (object) nowTime, (object) 0);
      return " SELECT " + DbQueryHelper.ToIsNULL() + "(MAX(uis_SiteID), " + str + ")+1 AS uis_SiteID" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode, (object) DbQueryHelper.ToWithNolock()) + " WHERE " + "(uis_SiteID/100000000)".ToInt() + "=" + nowTime;
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
          this.uis_SiteID = uniOleDbRecordset.GetFieldLong(0);
        return this.uis_SiteID > 0L;
      }
      finally
      {
        uniOleDbRecordset?.Close();
        pOleDB?.Close();
      }
    }

    public override async Task<bool> CreateCodeAsync(UniOleDatabase p_db)
    {
      UniSiteView uniSiteView = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(p_db.ConnectionUrl);
        rs = new UniOleDbRecordset(db, db.CommandTimeout);
        if (!await rs.OpenAsync(uniSiteView.CreateCodeQuery()))
        {
          uniSiteView.message = " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + uniSiteView.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) db.LastErrorID) + " 내용 : " + db.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          return false;
        }
        if (await rs.IsDataReadAsync())
          uniSiteView.uis_SiteID = rs.GetFieldLong(0);
        return uniSiteView.uis_SiteID > 0L;
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public override bool Insert() => (this.uis_SiteID != 0L || this.CreateCode(this.OleDB)) && base.Insert() && this.SetSuccessInfo(string.Format("({0}) 등록됨.", (object) this.uis_SiteID));

    public override async Task<bool> InsertAsync()
    {
      UniSiteView uniSiteView = this;
      if (uniSiteView.uis_SiteID == 0L)
      {
        if (!await uniSiteView.CreateCodeAsync(uniSiteView.OleDB))
          return false;
      }
      // ISSUE: reference to a compiler-generated method
      return await uniSiteView.\u003C\u003En__0() && uniSiteView.SetSuccessInfo(string.Format("({0}) 등록됨.", (object) uniSiteView.uis_SiteID));
    }

    public override bool Update(UbModelBase p_old = null) => base.Update(p_old) && this.SetSuccessInfo(string.Format("({0}) 변경됨.", (object) this.uis_SiteID));

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      UniSiteView uniSiteView = this;
      // ISSUE: reference to a compiler-generated method
      return await uniSiteView.\u003C\u003En__1(p_old) && uniSiteView.SetSuccessInfo(string.Format("({0}) 변경됨.", (object) uniSiteView.uis_SiteID));
    }

    public override bool UpdateExInsert() => base.UpdateExInsert() && this.SetSuccessInfo(string.Format("({0}) 변경됨.", (object) this.uis_SiteID));

    public override async Task<bool> UpdateExInsertAsync()
    {
      UniSiteView uniSiteView = this;
      // ISSUE: reference to a compiler-generated method
      return await uniSiteView.\u003C\u003En__2() && uniSiteView.SetSuccessInfo(string.Format("({0}) 변경됨.", (object) uniSiteView.uis_SiteID));
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
        else if (!this.IsPermit(p_app_employee))
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        if (this.uis_SiteID == 0L && !this.CreateCode(p_db))
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 코드 생성 오류", 2);
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
      UniSiteView uniSiteView = this;
      try
      {
        uniSiteView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != uniSiteView.DataCheck(p_db))
            throw new UniServiceException(uniSiteView.message, uniSiteView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!uniSiteView.IsPermit(p_app_employee))
          throw new UniServiceException(uniSiteView.message, uniSiteView.TableCode.ToDescription() + " 권한 검사 실패");
        if (uniSiteView.uis_SiteID == 0L)
        {
          if (!await uniSiteView.CreateCodeAsync(p_db))
            throw new UniServiceException(uniSiteView.message, uniSiteView.TableCode.ToDescription() + " 코드 생성 오류", 2);
        }
        if (!await uniSiteView.InsertAsync())
          throw new UniServiceException(uniSiteView.message, uniSiteView.TableCode.ToDescription() + " 등록 오류");
        uniSiteView.db_status = 4;
        uniSiteView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        uniSiteView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        uniSiteView.message = ex.Message;
      }
      return false;
    }

    public override bool UpdateData(
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
        else if (!this.IsPermit(p_app_employee))
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        if (this.uis_SiteID == 0L)
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 사이트(uis_SiteID)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (!this.Update())
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 변경 오류");
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

    public override async Task<bool> UpdateDataAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      UniSiteView uniSiteView = this;
      try
      {
        uniSiteView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != uniSiteView.DataCheck(p_db))
            throw new UniServiceException(uniSiteView.message, uniSiteView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!uniSiteView.IsPermit(p_app_employee))
          throw new UniServiceException(uniSiteView.message, uniSiteView.TableCode.ToDescription() + " 권한 검사 실패");
        if (uniSiteView.uis_SiteID == 0L)
          throw new UniServiceException(uniSiteView.message, uniSiteView.TableCode.ToDescription() + " 사이트(uis_SiteID)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (!await uniSiteView.UpdateAsync())
          throw new UniServiceException(uniSiteView.message, uniSiteView.TableCode.ToDescription() + " 변경 오류");
        uniSiteView.db_status = 4;
        uniSiteView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        uniSiteView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        uniSiteView.message = ex.Message;
      }
      return false;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.usi_StoreCount = p_rs.GetFieldInt("usi_StoreCount");
      return true;
    }

    public async Task<UniSiteView> SelectOneAsync(long p_uis_SiteID) => await this.SelectOneTAsync<UniSiteView>((object) new Hashtable()
    {
      {
        (object) "uis_SiteID",
        (object) p_uis_SiteID
      }
    });

    public async Task<IList<UniSiteView>> SelectListAsync(object p_param)
    {
      UniSiteView uniSiteView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(uniSiteView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, uniSiteView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(uniSiteView1.GetSelectQuery(p_param)))
        {
          uniSiteView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + uniSiteView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<UniSiteView>) null;
        }
        IList<UniSiteView> lt_list = (IList<UniSiteView>) new List<UniSiteView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            UniSiteView uniSiteView2 = uniSiteView1.OleDB.Create<UniSiteView>();
            if (uniSiteView2.GetFieldValues(rs))
            {
              uniSiteView2.row_number = lt_list.Count + 1;
              lt_list.Add(uniSiteView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + uniSiteView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public override string GetSelectQuery(object p_param)
    {
      StringBuilder stringBuilder = new StringBuilder();
      try
      {
        string uniBase = UbModelBase.UNI_BASE;
        string str = this.TableCode.ToString();
        string empty = string.Empty;
        bool flag = false;
        long num = 0;
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
          if (hashtable.ContainsKey((object) "_ORDER_BY_COL_") && hashtable[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable[(object) "_ORDER_BY_COL_"].ToString();
        }
        stringBuilder.Append("WITH T_STORE AS ( SELECT si_SiteID,COUNT(*) AS usi_StoreCount" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()) + " GROUP BY si_SiteID) ");
        stringBuilder.Append("\n");
        stringBuilder.Append(" SELECT  uis_SiteID,uis_SiteViewCode,uis_SiteName,uis_SiteType,uis_AddProperty,usi_StoreCount FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock() + " LEFT OUTER JOIN T_STORE ON uis_SiteID=si_SiteID");
        stringBuilder.Append("\n");
        if (flag)
        {
          stringBuilder.Append(string.Format(" INNER JOIN T_RESELLER_SITE ON rs_UserID={0} AND {1}=rs_SiteID ", (object) num, (object) "uis_SiteID"));
          stringBuilder.Append("\n");
        }
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        if (empty != null)
        {
          if (empty.Length > 0)
            stringBuilder.Append(" ORDER BY " + empty);
        }
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
