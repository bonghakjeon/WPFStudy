// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.Gift.GiftItem.GiftItemView
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

namespace UniBiz.Bo.Models.UniMembers.Gift.GiftItem
{
  public class GiftItemView : TGiftItem<GiftItemView>
  {
    private string _inEmpName;
    private string _modEmpName;

    public string inEmpName
    {
      get => this._inEmpName;
      set
      {
        this._inEmpName = value;
        this.Changed(nameof (inEmpName));
      }
    }

    public string modEmpName
    {
      get => this._modEmpName;
      set
      {
        this._modEmpName = value;
        this.Changed(nameof (modEmpName));
      }
    }

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("inEmpName", new TTableColumn()
      {
        tc_orgin_name = "inEmpName",
        tc_trans_name = "등록사원",
        tc_col_status = 1
      });
      columnInfo.Add("modEmpName", new TTableColumn()
      {
        tc_orgin_name = "modEmpName",
        tc_trans_name = "수정사원",
        tc_col_status = 1
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.inEmpName = string.Empty;
      this.modEmpName = string.Empty;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new GiftItemView();

    public override object Clone()
    {
      GiftItemView giftItemView = base.Clone() as GiftItemView;
      giftItemView.inEmpName = this.inEmpName;
      giftItemView.modEmpName = this.modEmpName;
      return (object) giftItemView;
    }

    public void PutData(GiftItemView pSource)
    {
      this.PutData((TGiftItem) pSource);
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.gi_SiteID == 0L)
      {
        this.message = "싸이트(gi_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.gi_GiftType == 0)
      {
        this.message = "사은품유형(gi_GiftType)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (!string.IsNullOrEmpty(this.gi_GiftName))
        return EnumDataCheck.Success;
      this.message = "사은품명(gi_GiftName)  " + EnumDataCheck.Empty.ToDescription();
      return EnumDataCheck.Empty;
    }

    protected override EnumDataCheck DataCheck(UniOleDatabase p_db) => base.DataCheck(p_db);

    protected override bool IsPermit(EmployeeView p_app_employee)
    {
      if (p_app_employee == null)
      {
        this.message = "사용자 정보 NULL.";
        return false;
      }
      if (!p_app_employee.IsAdmin)
      {
        this.message = p_app_employee.emp_Name + "님(Permit) 변경불가.";
        return false;
      }
      return EnumDataCheck.Success == this.DataCheck(this.OleDB);
    }

    public override string CreateCodeQuery()
    {
      base.CreateCodeQuery();
      return " SELECT " + DbQueryHelper.ToIsNULL() + "(MAX(gi_GiftCode), 0)+1 AS gi_GiftCode" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) this.TableCode, (object) DbQueryHelper.ToWithNolock());
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
          this.gi_GiftCode = uniOleDbRecordset.GetFieldInt(0);
        return this.gi_GiftCode > 0;
      }
      finally
      {
        uniOleDbRecordset?.Close();
        pOleDB?.Close();
      }
    }

    public override async Task<bool> CreateCodeAsync(UniOleDatabase p_db)
    {
      GiftItemView giftItemView = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(p_db.ConnectionUrl);
        rs = new UniOleDbRecordset(db, db.CommandTimeout);
        if (!await rs.OpenAsync(giftItemView.CreateCodeQuery()))
        {
          giftItemView.message = " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + giftItemView.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) db.LastErrorID) + " 내용 : " + db.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          return false;
        }
        if (await rs.IsDataReadAsync())
          giftItemView.gi_GiftCode = rs.GetFieldInt(0);
        return giftItemView.gi_GiftCode > 0;
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
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
          if (this.gi_SiteID == 0L)
            this.gi_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (this.gi_GiftCode == 0 && !this.CreateCode(p_db))
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
      GiftItemView giftItemView = this;
      try
      {
        giftItemView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != giftItemView.DataCheck(p_db))
            throw new UniServiceException(giftItemView.message, giftItemView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (giftItemView.gi_SiteID == 0L)
            giftItemView.gi_SiteID = p_app_employee.emp_SiteID;
          if (!giftItemView.IsPermit(p_app_employee))
            throw new UniServiceException(giftItemView.message, giftItemView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (giftItemView.gi_GiftCode == 0)
        {
          if (!await giftItemView.CreateCodeAsync(p_db))
            throw new UniServiceException(giftItemView.message, giftItemView.TableCode.ToDescription() + " 코드 생성 오류", 2);
        }
        if (!await giftItemView.InsertAsync())
          throw new UniServiceException(giftItemView.message, giftItemView.TableCode.ToDescription() + " 등록 오류");
        giftItemView.db_status = 4;
        giftItemView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        giftItemView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        giftItemView.message = ex.Message;
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
        if (this.gi_GiftCode == 0)
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 사은품코드(gi_GiftCode)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
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
      GiftItemView giftItemView = this;
      try
      {
        giftItemView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != giftItemView.DataCheck(p_db))
            throw new UniServiceException(giftItemView.message, giftItemView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!giftItemView.IsPermit(p_app_employee))
          throw new UniServiceException(giftItemView.message, giftItemView.TableCode.ToDescription() + " 권한 검사 실패");
        if (giftItemView.gi_GiftCode == 0)
          throw new UniServiceException(giftItemView.message, giftItemView.TableCode.ToDescription() + " 사은품코드(gi_GiftCode)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (!await giftItemView.UpdateAsync())
          throw new UniServiceException(giftItemView.message, giftItemView.TableCode.ToDescription() + " 변경 오류");
        giftItemView.db_status = 4;
        giftItemView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        giftItemView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        giftItemView.message = ex.Message;
      }
      return false;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.inEmpName = p_rs.GetFieldString("inEmpName");
      this.modEmpName = p_rs.GetFieldString("modEmpName");
      return true;
    }

    public async Task<GiftItemView> SelectOneAsync(int p_gi_GiftCode, long p_gi_SiteID = 0)
    {
      GiftItemView giftItemView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "gi_GiftCode",
          (object) p_gi_GiftCode
        }
      };
      if (p_gi_SiteID > 0L)
        p_param.Add((object) "gi_SiteID", (object) p_gi_SiteID);
      return await giftItemView.SelectOneTAsync<GiftItemView>((object) p_param);
    }

    public GiftItemView SelectOne(int p_gi_GiftCode, long p_gi_SiteID = 0)
    {
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "gi_GiftCode",
          (object) p_gi_GiftCode
        }
      };
      if (p_gi_SiteID > 0L)
        p_param.Add((object) "gi_SiteID", (object) p_gi_SiteID);
      return this.SelectOneT<GiftItemView>((object) p_param);
    }

    public async Task<IList<GiftItemView>> SelectListAsync(object p_param)
    {
      GiftItemView giftItemView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(giftItemView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, giftItemView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(giftItemView1.GetSelectQuery(p_param)))
        {
          giftItemView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + giftItemView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<GiftItemView>) null;
        }
        IList<GiftItemView> lt_list = (IList<GiftItemView>) new List<GiftItemView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            GiftItemView giftItemView2 = giftItemView1.OleDB.Create<GiftItemView>();
            if (giftItemView2.GetFieldValues(rs))
            {
              giftItemView2.row_number = lt_list.Count + 1;
              lt_list.Add(giftItemView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + giftItemView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<GiftItemView> SelectEnumerableAsync(object p_param)
    {
      GiftItemView giftItemView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(giftItemView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, giftItemView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(giftItemView1.GetSelectQuery(p_param)))
        {
          giftItemView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + giftItemView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            GiftItemView giftItemView2 = giftItemView1.OleDB.Create<GiftItemView>();
            if (giftItemView2.GetFieldValues(rs))
            {
              giftItemView2.row_number = ++row_number;
              yield return giftItemView2;
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
      if (p_param is Hashtable hashtable && hashtable.ContainsKey((object) "_KEY_WORD_") && !string.IsNullOrEmpty(hashtable[(object) "_KEY_WORD_"].ToString()))
      {
        stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "gi_GiftName", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "gi_GiftBarcode", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "gi_Memo", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(")");
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
        string empty = string.Empty;
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
          if (hashtable.ContainsKey((object) "_ORDER_BY_COL_") && hashtable[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable.ContainsKey((object) "gi_SiteID") && Convert.ToInt64(hashtable[(object) "gi_SiteID"].ToString()) > 0L)
            Convert.ToInt64(hashtable[(object) "gi_SiteID"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS (\nSELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n,T_EMPLOYEE_MOD AS (\nSELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\nSELECT  gi_GiftCode,gi_SiteID,gi_GiftType,gi_GiftName,gi_GiftBarcode,gi_GiftPrice,gi_DeductionPoint,gi_Memo,gi_UseYn,gi_InDate,gi_InUser,gi_ModDate,gi_ModUser,inEmpName,modEmpName\nFROM " + DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS) + str + " " + DbQueryHelper.ToWithNolock() + "\nLEFT OUTER JOIN T_EMPLOYEE_IN ON gi_InUser=emp_CodeIn\nLEFT OUTER JOIN T_EMPLOYEE_MOD ON gi_ModUser=emp_CodeMod");
        if (p_param is Hashtable)
        {
          stringBuilder.Append("\n");
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        }
        if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append("\nORDER BY " + empty);
        else
          stringBuilder.Append("\nORDER BY gi_GiftCode");
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
