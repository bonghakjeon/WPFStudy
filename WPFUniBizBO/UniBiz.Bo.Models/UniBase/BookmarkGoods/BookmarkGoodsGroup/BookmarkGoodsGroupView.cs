// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.BookmarkGoods.BookmarkGoodsGroup.BookmarkGoodsGroupView
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
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.TableInfo;
using UniBiz.Bo.Models.UniBase.BookmarkGoods.BookmarkGoodsList;
using UniBiz.Bo.Models.UniBase.Employee.Employee;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniBase.BookmarkGoods.BookmarkGoodsGroup
{
  public class BookmarkGoodsGroupView : TBookmarkGoodsGroup<BookmarkGoodsGroupView>
  {
    private int _bgl_GoodsCount;
    private string _inEmpName;
    private string _modEmpName;
    private IList<BookmarkGoodsListView> _Lt_History;

    public int bgl_GoodsCount
    {
      get => this._bgl_GoodsCount;
      set
      {
        this._bgl_GoodsCount = value;
        this.Changed(nameof (bgl_GoodsCount));
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

    public string modEmpName
    {
      get => this._modEmpName;
      set
      {
        this._modEmpName = value;
        this.Changed(nameof (modEmpName));
      }
    }

    [JsonPropertyName("lt_History")]
    public IList<BookmarkGoodsListView> Lt_History
    {
      get => this._Lt_History ?? (this._Lt_History = (IList<BookmarkGoodsListView>) new List<BookmarkGoodsListView>());
      set
      {
        this._Lt_History = value;
        this.Changed(nameof (Lt_History));
      }
    }

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("bgl_GoodsCount", new TTableColumn()
      {
        tc_orgin_name = "bgl_GoodsCount",
        tc_trans_name = "건수",
        tc_col_status = 1
      });
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
      this.bgl_GoodsCount = 0;
      this.inEmpName = string.Empty;
      this.modEmpName = string.Empty;
      this.Lt_History = (IList<BookmarkGoodsListView>) null;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new BookmarkGoodsGroupView();

    public override object Clone()
    {
      BookmarkGoodsGroupView bookmarkGoodsGroupView = base.Clone() as BookmarkGoodsGroupView;
      bookmarkGoodsGroupView.bgl_GoodsCount = this.bgl_GoodsCount;
      bookmarkGoodsGroupView.inEmpName = this.inEmpName;
      bookmarkGoodsGroupView.modEmpName = this.modEmpName;
      bookmarkGoodsGroupView.Lt_History = (IList<BookmarkGoodsListView>) null;
      if (this.Lt_History.Count > 0)
      {
        foreach (BookmarkGoodsListView bookmarkGoodsListView in (IEnumerable<BookmarkGoodsListView>) this.Lt_History)
          bookmarkGoodsGroupView.Lt_History.Add(bookmarkGoodsListView);
      }
      return (object) bookmarkGoodsGroupView;
    }

    public void PutData(BookmarkGoodsGroupView pSource)
    {
      this.PutData((TBookmarkGoodsGroup) pSource);
      this.bgl_GoodsCount = pSource.bgl_GoodsCount;
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
      this.Lt_History = (IList<BookmarkGoodsListView>) null;
      if (pSource.Lt_History.Count <= 0)
        return;
      foreach (BookmarkGoodsListView pSource1 in (IEnumerable<BookmarkGoodsListView>) pSource.Lt_History)
      {
        BookmarkGoodsListView bookmarkGoodsListView = new BookmarkGoodsListView();
        bookmarkGoodsListView.PutData(pSource1);
        this.Lt_History.Add(bookmarkGoodsListView);
      }
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.bgg_SiteID == 0L)
      {
        this.message = "싸이트(bgg_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (!string.IsNullOrEmpty(this.bgg_GroupName))
        return EnumDataCheck.Success;
      this.message = "관심상품그룹명(bgg_GroupName)  " + EnumDataCheck.Empty.ToDescription();
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
      if (!p_app_employee.IsMasterCommonSave)
      {
        this.message = p_app_employee.emp_Name + "님(Permit) 변경불가.";
        return false;
      }
      if (this.bgg_InUser != p_app_employee.emp_Code)
      {
        this.message = p_app_employee.emp_Name + "님(Permit) 변경불가.\n" + this.inEmpName + "님 등록 데이터 입니다.";
        return false;
      }
      return EnumDataCheck.Success == this.DataCheck(this.OleDB);
    }

    public override string CreateCodeQuery()
    {
      base.CreateCodeQuery();
      return " SELECT " + DbQueryHelper.ToIsNULL() + "(MAX(bgg_GroupID), 0)+1 AS bgg_GroupID" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode, (object) DbQueryHelper.ToWithNolock());
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
          this.bgg_GroupID = uniOleDbRecordset.GetFieldInt(0);
        return this.bgg_GroupID > 0;
      }
      finally
      {
        uniOleDbRecordset?.Close();
        pOleDB?.Close();
      }
    }

    public override async Task<bool> CreateCodeAsync(UniOleDatabase p_db)
    {
      BookmarkGoodsGroupView bookmarkGoodsGroupView = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(p_db.ConnectionUrl);
        rs = new UniOleDbRecordset(db, db.CommandTimeout);
        if (!await rs.OpenAsync(bookmarkGoodsGroupView.CreateCodeQuery()))
        {
          bookmarkGoodsGroupView.message = " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + bookmarkGoodsGroupView.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) db.LastErrorID) + " 내용 : " + db.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          return false;
        }
        if (await rs.IsDataReadAsync())
          bookmarkGoodsGroupView.bgg_GroupID = rs.GetFieldInt(0);
        return bookmarkGoodsGroupView.bgg_GroupID > 0;
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
          if (this.bgg_SiteID == 0L)
            this.bgg_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (this.bgg_GroupID == 0 && !this.CreateCode(p_db))
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 코드 생성 오류", 2);
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!this.Insert())
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 등록 오류");
        if (!this.InsertDetail(p_db, p_app_employee, true))
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 상세 등록 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        this.db_status = 4;
        this.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        this.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        this.message = ex.Message;
      }
      return false;
    }

    public override async Task<bool> InsertDataAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      BookmarkGoodsGroupView bookmarkGoodsGroupView = this;
      try
      {
        bookmarkGoodsGroupView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != bookmarkGoodsGroupView.DataCheck(p_db))
            throw new UniServiceException(bookmarkGoodsGroupView.message, bookmarkGoodsGroupView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (bookmarkGoodsGroupView.bgg_SiteID == 0L)
            bookmarkGoodsGroupView.bgg_SiteID = p_app_employee.emp_SiteID;
          if (!bookmarkGoodsGroupView.IsPermit(p_app_employee))
            throw new UniServiceException(bookmarkGoodsGroupView.message, bookmarkGoodsGroupView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (bookmarkGoodsGroupView.bgg_GroupID == 0)
        {
          if (!await bookmarkGoodsGroupView.CreateCodeAsync(p_db))
            throw new UniServiceException(bookmarkGoodsGroupView.message, bookmarkGoodsGroupView.TableCode.ToDescription() + " 코드 생성 오류", 2);
        }
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await bookmarkGoodsGroupView.InsertAsync())
          throw new UniServiceException(bookmarkGoodsGroupView.message, bookmarkGoodsGroupView.TableCode.ToDescription() + " 등록 오류");
        if (!await bookmarkGoodsGroupView.InsertDetailAsync(p_db, p_app_employee, true))
          throw new UniServiceException(bookmarkGoodsGroupView.message, bookmarkGoodsGroupView.TableCode.ToDescription() + " 상세 등록 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        bookmarkGoodsGroupView.db_status = 4;
        bookmarkGoodsGroupView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        bookmarkGoodsGroupView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        bookmarkGoodsGroupView.message = ex.Message;
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
        if (this.bgg_GroupID == 0)
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 관심상품그룹(bgg_GroupID)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!this.Update())
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 변경 오류");
        if (!this.InsertDetail(p_db, p_app_employee, false))
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 상세 변경 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        this.db_status = 4;
        this.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        this.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        this.message = ex.Message;
      }
      return false;
    }

    public override async Task<bool> UpdateDataAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      BookmarkGoodsGroupView bookmarkGoodsGroupView = this;
      try
      {
        bookmarkGoodsGroupView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != bookmarkGoodsGroupView.DataCheck(p_db))
            throw new UniServiceException(bookmarkGoodsGroupView.message, bookmarkGoodsGroupView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!bookmarkGoodsGroupView.IsPermit(p_app_employee))
          throw new UniServiceException(bookmarkGoodsGroupView.message, bookmarkGoodsGroupView.TableCode.ToDescription() + " 권한 검사 실패");
        if (bookmarkGoodsGroupView.bgg_GroupID == 0)
          throw new UniServiceException(bookmarkGoodsGroupView.message, bookmarkGoodsGroupView.TableCode.ToDescription() + " 관심상품그룹(bgg_GroupID)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await bookmarkGoodsGroupView.UpdateAsync())
          throw new UniServiceException(bookmarkGoodsGroupView.message, bookmarkGoodsGroupView.TableCode.ToDescription() + " 변경 오류");
        if (!await bookmarkGoodsGroupView.InsertDetailAsync(p_db, p_app_employee, false))
          throw new UniServiceException(bookmarkGoodsGroupView.message, bookmarkGoodsGroupView.TableCode.ToDescription() + " 상세 변경 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        bookmarkGoodsGroupView.db_status = 4;
        bookmarkGoodsGroupView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        bookmarkGoodsGroupView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        bookmarkGoodsGroupView.message = ex.Message;
      }
      return false;
    }

    public override bool DeleteData(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      try
      {
        this.SetAdoDatabase(p_db);
        if (p_app_employee == null || p_app_employee.emp_Code == 0)
        {
          if (EnumDataCheck.Success != this.DataCheck(p_db))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!this.IsPermit(p_app_employee))
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        if (this.bgg_GroupID == 0)
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 관심상품그룹(bgg_GroupID)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!this.Delete())
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 변경 오류");
        if (!this.Execute(new TBookmarkGoodsList().DeleteQuery(this.bgg_GroupID, 0L, this.bgg_SiteID)))
          throw new UniServiceException(this.message, TableCodeType.BookmarkGoodsList.ToDescription() + " 삭제 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        this.db_status = 4;
        this.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        this.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        this.message = ex.Message;
      }
      return false;
    }

    public override async Task<bool> DeleteDataAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      BookmarkGoodsGroupView bookmarkGoodsGroupView = this;
      try
      {
        bookmarkGoodsGroupView.SetAdoDatabase(p_db);
        if (p_app_employee == null || p_app_employee.emp_Code == 0)
        {
          if (EnumDataCheck.Success != bookmarkGoodsGroupView.DataCheck(p_db))
            throw new UniServiceException(bookmarkGoodsGroupView.message, bookmarkGoodsGroupView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!bookmarkGoodsGroupView.IsPermit(p_app_employee))
          throw new UniServiceException(bookmarkGoodsGroupView.message, bookmarkGoodsGroupView.TableCode.ToDescription() + " 권한 검사 실패");
        if (bookmarkGoodsGroupView.bgg_GroupID == 0)
          throw new UniServiceException(bookmarkGoodsGroupView.message, bookmarkGoodsGroupView.TableCode.ToDescription() + " 관심상품그룹(bgg_GroupID)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await bookmarkGoodsGroupView.DeleteAsync())
          throw new UniServiceException(bookmarkGoodsGroupView.message, bookmarkGoodsGroupView.TableCode.ToDescription() + " 삭제 오류");
        if (!await bookmarkGoodsGroupView.ExecuteAsync(new TBookmarkGoodsList().DeleteQuery(bookmarkGoodsGroupView.bgg_GroupID, 0L, bookmarkGoodsGroupView.bgg_SiteID)))
          throw new UniServiceException(bookmarkGoodsGroupView.message, TableCodeType.BookmarkGoodsList.ToDescription() + " 삭제 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        bookmarkGoodsGroupView.db_status = 4;
        bookmarkGoodsGroupView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        bookmarkGoodsGroupView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        bookmarkGoodsGroupView.message = ex.Message;
      }
      return false;
    }

    public bool InsertDetail(UniOleDatabase p_db, EmployeeView p_app_employee, bool p_is_new)
    {
      try
      {
        if (p_is_new && this.Lt_History.Count == 0)
        {
          BookmarkGoodsListView bookmarkGoodsListView = new BookmarkGoodsListView();
          bookmarkGoodsListView.bgl_GroupID = this.bgg_GroupID;
          bookmarkGoodsListView.bgl_UseYn = this.bgg_UseYn;
          bookmarkGoodsListView.DB_STATUS = EnumDBStatus.NEW;
          this.Lt_History.Add(bookmarkGoodsListView);
        }
        if (this.Lt_History.Count == 0)
          return true;
        foreach (BookmarkGoodsListView bookmarkGoodsListView in (IEnumerable<BookmarkGoodsListView>) this.Lt_History)
        {
          if (bookmarkGoodsListView.bgl_SiteID == 0L)
            bookmarkGoodsListView.bgl_SiteID = this.bgg_SiteID;
          if (bookmarkGoodsListView.IsNew)
          {
            if (!bookmarkGoodsListView.InsertData(p_db, p_app_employee, false))
              throw new Exception(bookmarkGoodsListView.message);
          }
          else if (bookmarkGoodsListView.IsUpdate && !bookmarkGoodsListView.UpdateData(p_db, p_app_employee, false))
            throw new Exception(bookmarkGoodsListView.message);
        }
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

    public async Task<bool> InsertDetailAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_new)
    {
      BookmarkGoodsGroupView bookmarkGoodsGroupView = this;
      try
      {
        if (p_is_new && bookmarkGoodsGroupView.Lt_History.Count == 0)
        {
          BookmarkGoodsListView bookmarkGoodsListView = new BookmarkGoodsListView();
          bookmarkGoodsListView.bgl_GroupID = bookmarkGoodsGroupView.bgg_GroupID;
          bookmarkGoodsListView.bgl_UseYn = bookmarkGoodsGroupView.bgg_UseYn;
          bookmarkGoodsListView.DB_STATUS = EnumDBStatus.NEW;
          bookmarkGoodsGroupView.Lt_History.Add(bookmarkGoodsListView);
        }
        if (bookmarkGoodsGroupView.Lt_History.Count == 0)
          return true;
        foreach (BookmarkGoodsListView detail in (IEnumerable<BookmarkGoodsListView>) bookmarkGoodsGroupView.Lt_History)
        {
          if (detail.bgl_SiteID == 0L)
            detail.bgl_SiteID = bookmarkGoodsGroupView.bgg_SiteID;
          if (detail.IsNew)
          {
            if (!await detail.InsertDataAsync(p_db, p_app_employee, false))
              throw new Exception(detail.message);
          }
          else if (detail.IsUpdate)
          {
            if (!await detail.UpdateDataAsync(p_db, p_app_employee, false))
              throw new Exception(detail.message);
          }
        }
        return true;
      }
      catch (UniServiceException ex)
      {
        bookmarkGoodsGroupView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        bookmarkGoodsGroupView.message = ex.Message;
      }
      return false;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.bgl_GoodsCount = p_rs.GetFieldInt("bgl_GoodsCount");
      this.inEmpName = p_rs.GetFieldString("inEmpName");
      this.modEmpName = p_rs.GetFieldString("modEmpName");
      return true;
    }

    public async Task<BookmarkGoodsGroupView> SelectOneAsync(int p_bgg_GroupID, long p_bgg_SiteID = 0)
    {
      BookmarkGoodsGroupView bookmarkGoodsGroupView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "bgg_GroupID",
          (object) p_bgg_GroupID
        }
      };
      if (p_bgg_SiteID > 0L)
        p_param.Add((object) "bgg_SiteID", (object) p_bgg_SiteID);
      return await bookmarkGoodsGroupView.SelectOneTAsync<BookmarkGoodsGroupView>((object) p_param);
    }

    public async Task<IList<BookmarkGoodsGroupView>> SelectListAsync(object p_param)
    {
      BookmarkGoodsGroupView bookmarkGoodsGroupView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(bookmarkGoodsGroupView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, bookmarkGoodsGroupView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(bookmarkGoodsGroupView1.GetSelectQuery(p_param)))
        {
          bookmarkGoodsGroupView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + bookmarkGoodsGroupView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<BookmarkGoodsGroupView>) null;
        }
        IList<BookmarkGoodsGroupView> lt_list = (IList<BookmarkGoodsGroupView>) new List<BookmarkGoodsGroupView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            BookmarkGoodsGroupView bookmarkGoodsGroupView2 = bookmarkGoodsGroupView1.OleDB.Create<BookmarkGoodsGroupView>();
            if (bookmarkGoodsGroupView2.GetFieldValues(rs))
            {
              bookmarkGoodsGroupView2.row_number = lt_list.Count + 1;
              lt_list.Add(bookmarkGoodsGroupView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + bookmarkGoodsGroupView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
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
      if (p_param is Hashtable hashtable)
      {
        if (hashtable.ContainsKey((object) "emp_Code") && Convert.ToInt32(hashtable[(object) "emp_Code"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "bgg_InUser", hashtable[(object) "emp_Code"]));
        if (hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "bgg_GroupName", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(")");
        }
      }
      return !stringBuilder.ToString().Equals(" WHERE") ? stringBuilder.Replace("WHERE AND", "WHERE").ToString() : string.Empty;
    }

    public override string GetSelectQuery(object p_param)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        string uniBase = UbModelBase.UNI_BASE;
        string str = this.TableCode.ToString();
        string empty = string.Empty;
        int num1 = 0;
        long num2 = 0;
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
          if (hashtable.ContainsKey((object) "_ORDER_BY_COL_") && hashtable[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable.ContainsKey((object) "_ORDER_BY_TYPE_") && Convert.ToInt32(hashtable[(object) "_ORDER_BY_TYPE_"].ToString()) > 0)
            num1 = Convert.ToInt32(hashtable[(object) "_ORDER_BY_TYPE_"].ToString());
          if (hashtable.ContainsKey((object) "bgg_SiteID") && Convert.ToInt64(hashtable[(object) "bgg_SiteID"].ToString()) > 0L)
            num2 = Convert.ToInt64(hashtable[(object) "bgg_SiteID"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS ( SELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_EMPLOYEE_MOD AS ( SELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_LIST AS ( SELECT bgl_GroupID,bgl_SiteID, COUNT(*) AS bgl_GoodsCount" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.BookmarkGoodsList, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("bgg_SiteID"))
            p_param1.Add((object) "bgl_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("bgg_GroupID"))
            p_param1.Add((object) "bgl_GroupID", dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "bgl_SiteID"))
            p_param1.Add((object) "bgl_SiteID", (object) num2);
          stringBuilder.Append(new TBookmarkGoodsList().GetSelectWhereAnd((object) p_param1));
        }
        else if (num2 > 0L)
          stringBuilder.Append(string.Format("  WHERE {0}={1}", (object) "bgl_SiteID", (object) num2));
        stringBuilder.Append("\nGROUP BY bgl_GroupID,bgl_SiteID");
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(" SELECT  bgg_GroupID,bgg_SiteID,bgg_GroupName,bgg_UseYn,bgg_InDate,bgg_InUser,bgg_ModDate,bgg_ModUser,bgl_GoodsCount,inEmpName,modEmpName FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock() + " LEFT OUTER JOIN T_LIST ON bgg_GroupID=bgl_GroupID AND bgg_SiteID=bgl_SiteID LEFT OUTER JOIN T_EMPLOYEE_IN ON bgg_InUser=emp_CodeIn LEFT OUTER JOIN T_EMPLOYEE_MOD ON bgg_ModUser=emp_CodeMod");
        stringBuilder.Append("\n");
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        if (num1 > 0)
        {
          switch (num1)
          {
            case 1:
              stringBuilder.Append(" ORDER BY " + DbQueryHelper.ToIsNULL() + "(bgg_ModDate,bgg_InDate),bgg_GroupID");
              break;
            case 2:
              stringBuilder.Append(" ORDER BY " + DbQueryHelper.ToIsNULL() + "(bgg_ModDate DESC,bgg_InDate),bgg_GroupID");
              break;
          }
        }
        else if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append(" ORDER BY " + empty);
        else
          stringBuilder.Append(" ORDER BY " + DbQueryHelper.ToIsNULL() + "(bgg_ModDate,bgg_InDate) DESC,bgg_GroupID");
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) ex.GetHashCode()) + " 내용 : " + ex.Message + "\n" + string.Format(" Query : {0}\n", (object) stringBuilder) + "--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
        stringBuilder.Clear();
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }
  }
}
