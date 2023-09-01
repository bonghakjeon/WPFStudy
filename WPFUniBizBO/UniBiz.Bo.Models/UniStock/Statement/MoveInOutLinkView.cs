// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.MoveInOutLinkView
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

namespace UniBiz.Bo.Models.UniStock.Statement
{
  public class MoveInOutLinkView : TMoveInOutLink<MoveInOutLinkView>
  {
    private int _out_StoreCode;
    private int _in_StoreCode;

    public int out_StoreCode
    {
      get => this._out_StoreCode;
      set
      {
        this._out_StoreCode = value;
        this.Changed(nameof (out_StoreCode));
      }
    }

    public int in_StoreCode
    {
      get => this._in_StoreCode;
      set
      {
        this._in_StoreCode = value;
        this.Changed(nameof (in_StoreCode));
      }
    }

    public override Dictionary<string, TTableColumn> ToColumnInfo() => base.ToColumnInfo();

    public override void Clear()
    {
      base.Clear();
      this.out_StoreCode = this.in_StoreCode = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new MoveInOutLinkView();

    public override object Clone()
    {
      MoveInOutLinkView moveInOutLinkView = base.Clone() as MoveInOutLinkView;
      moveInOutLinkView.out_StoreCode = this.out_StoreCode;
      moveInOutLinkView.in_StoreCode = this.in_StoreCode;
      return (object) moveInOutLinkView;
    }

    public void PutData(MoveInOutLinkView pSource)
    {
      this.PutData((TMoveInOutLink) pSource);
      this.out_StoreCode = pSource.out_StoreCode;
      this.in_StoreCode = pSource.in_StoreCode;
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.mio_SiteID == 0L)
      {
        this.message = "싸이트(mio_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.mio_OuterStatementNo == 0L)
      {
        this.message = "출고 전표번호(mio_OuterStatementNo)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.mio_InnerStatementNo != 0L)
        return EnumDataCheck.Success;
      this.message = "입고 전표번호(mio_InnerStatementNo)  " + EnumDataCheck.CodeZero.ToDescription();
      return EnumDataCheck.CodeZero;
    }

    protected override EnumDataCheck DataCheck(UniOleDatabase p_db) => base.DataCheck(p_db);

    protected override bool IsPermit(EmployeeView p_app_employee) => EnumDataCheck.Success == this.DataCheck(this.OleDB);

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
          if (this.mio_SiteID == 0L)
            this.mio_SiteID = p_app_employee.emp_SiteID;
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
      MoveInOutLinkView moveInOutLinkView = this;
      try
      {
        moveInOutLinkView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != moveInOutLinkView.DataCheck(p_db))
            throw new UniServiceException(moveInOutLinkView.message, moveInOutLinkView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (moveInOutLinkView.mio_SiteID == 0L)
            moveInOutLinkView.mio_SiteID = p_app_employee.emp_SiteID;
          if (!moveInOutLinkView.IsPermit(p_app_employee))
            throw new UniServiceException(moveInOutLinkView.message, moveInOutLinkView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (!await moveInOutLinkView.InsertAsync())
          throw new UniServiceException(moveInOutLinkView.message, moveInOutLinkView.TableCode.ToDescription() + " 등록 오류");
        moveInOutLinkView.db_status = 4;
        moveInOutLinkView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        moveInOutLinkView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        moveInOutLinkView.message = ex.Message;
      }
      return false;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.out_StoreCode = p_rs.GetFieldInt("out_StoreCode");
      this.in_StoreCode = p_rs.GetFieldInt("in_StoreCode");
      return true;
    }

    public async Task<MoveInOutLinkView> SelectOneAsync(
      long p_mio_OuterStatementNo,
      long p_mio_InnerStatementNo,
      long p_mio_SiteID = 0)
    {
      MoveInOutLinkView moveInOutLinkView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "mio_OuterStatementNo",
          (object) p_mio_OuterStatementNo
        },
        {
          (object) "mio_InnerStatementNo",
          (object) p_mio_InnerStatementNo
        }
      };
      if (p_mio_SiteID > 0L)
        p_param.Add((object) "mio_SiteID", (object) p_mio_SiteID);
      return await moveInOutLinkView.SelectOneTAsync<MoveInOutLinkView>((object) p_param);
    }

    public async Task<MoveInOutLinkView> SelectOneAsync(
      long p_mio_StatementNo,
      EnumInOutDiv p_InOutType,
      long p_mio_SiteID = 0)
    {
      MoveInOutLinkView moveInOutLinkView = this;
      Hashtable p_param = new Hashtable();
      if (p_InOutType == EnumInOutDiv.Normal)
        p_param.Add((object) "mio_InnerStatementNo", (object) p_mio_StatementNo);
      else
        p_param.Add((object) "mio_OuterStatementNo", (object) p_mio_StatementNo);
      if (p_mio_SiteID > 0L)
        p_param.Add((object) "mio_SiteID", (object) p_mio_SiteID);
      return await moveInOutLinkView.SelectOneTAsync<MoveInOutLinkView>((object) p_param);
    }

    public MoveInOutLinkView SelectOne(
      long p_mio_StatementNo,
      EnumInOutDiv p_InOutType,
      long p_mio_SiteID = 0)
    {
      Hashtable p_param = new Hashtable();
      if (p_InOutType == EnumInOutDiv.Normal)
        p_param.Add((object) "mio_InnerStatementNo", (object) p_mio_StatementNo);
      else
        p_param.Add((object) "mio_OuterStatementNo", (object) p_mio_StatementNo);
      if (p_mio_SiteID > 0L)
        p_param.Add((object) "mio_SiteID", (object) p_mio_SiteID);
      return this.SelectOneT<MoveInOutLinkView>((object) p_param);
    }

    public async Task<IList<MoveInOutLinkView>> SelectListAsync(object p_param)
    {
      MoveInOutLinkView moveInOutLinkView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(moveInOutLinkView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, moveInOutLinkView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(moveInOutLinkView1.GetSelectQuery(p_param)))
        {
          moveInOutLinkView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + moveInOutLinkView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<MoveInOutLinkView>) null;
        }
        IList<MoveInOutLinkView> lt_list = (IList<MoveInOutLinkView>) new List<MoveInOutLinkView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            MoveInOutLinkView moveInOutLinkView2 = moveInOutLinkView1.OleDB.Create<MoveInOutLinkView>();
            if (moveInOutLinkView2.GetFieldValues(rs))
            {
              moveInOutLinkView2.row_number = lt_list.Count + 1;
              lt_list.Add(moveInOutLinkView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + moveInOutLinkView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
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
      Hashtable hashtable = p_param as Hashtable;
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
            hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
          if (hashtable.ContainsKey((object) "_ORDER_BY_COL_") && hashtable[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable.ContainsKey((object) "mio_SiteID") && Convert.ToInt64(hashtable[(object) "mio_SiteID"].ToString()) > 0L)
            Convert.ToInt64(hashtable[(object) "mio_SiteID"].ToString());
        }
        stringBuilder.Append(" SELECT  mio_OuterStatementNo,mio_InnerStatementNo,mio_SiteID,T_OUT.sh_StoreCode AS out_StoreCode,T_IN.sh_StoreCode AS in_StoreCode FROM " + DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK) + str + " " + DbQueryHelper.ToWithNolock() + string.Format(" LEFT OUTER JOIN {0}{1} AS T_OUT {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) TableCodeType.StatementHeader, (object) DbQueryHelper.ToWithNolock()) + " ON mio_OuterStatementNo=T_OUT.sh_StatementNo AND mio_SiteID=T_OUT.sh_SiteID" + string.Format(" LEFT OUTER JOIN {0}{1} AS T_IN {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_STOCK), (object) TableCodeType.StatementHeader, (object) DbQueryHelper.ToWithNolock()) + " ON mio_InnerStatementNo=T_IN.sh_StatementNo AND mio_SiteID=T_IN.sh_SiteID");
        stringBuilder.Append("\n");
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append(" ORDER BY " + empty);
        else
          stringBuilder.Append(" ORDER BY mio_OuterStatementNo,mio_InnerStatementNo");
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
