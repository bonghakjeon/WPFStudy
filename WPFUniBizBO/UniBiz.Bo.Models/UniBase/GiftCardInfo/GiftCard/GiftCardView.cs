// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.GiftCardInfo.GiftCard.GiftCardView
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
using UniBiz.Bo.Models.UniBase.Employee.Employee;
using UniBiz.Bo.Models.UniBase.GiftCardInfo.GiftCardHistory;
using UniBiz.Bo.Models.UniBase.GoodsInfo.Goods;
using UniBiz.Bo.Models.UniBase.Store.StoreInfo;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniBase.GiftCardInfo.GiftCard
{
  public class GiftCardView : TGiftCard<GiftCardView>
  {
    private string _gd_GoodsName;
    private string _gc_PayableStoreName;
    private string _inEmpName;
    private string _modEmpName;
    private IList<GiftCardHistoryView> _Lt_History;

    public string gd_GoodsName
    {
      get => this._gd_GoodsName;
      set
      {
        this._gd_GoodsName = value;
        this.Changed(nameof (gd_GoodsName));
      }
    }

    public string gc_PayableStoreName
    {
      get => this._gc_PayableStoreName;
      set
      {
        this._gc_PayableStoreName = value;
        this.Changed(nameof (gc_PayableStoreName));
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

    [JsonPropertyName("lt_history")]
    public IList<GiftCardHistoryView> Lt_History
    {
      get => this._Lt_History ?? (this._Lt_History = (IList<GiftCardHistoryView>) new List<GiftCardHistoryView>());
      set
      {
        this._Lt_History = value;
        this.Changed(nameof (Lt_History));
      }
    }

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("gd_GoodsName", new TTableColumn()
      {
        tc_orgin_name = "gd_GoodsName",
        tc_trans_name = "상품명"
      });
      columnInfo.Add("gc_PayableStoreName", new TTableColumn()
      {
        tc_orgin_name = "gc_PayableStoreName",
        tc_trans_name = "결제가능지점"
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
      this.gd_GoodsName = string.Empty;
      this.gc_PayableStoreName = string.Empty;
      this.inEmpName = string.Empty;
      this.modEmpName = string.Empty;
      this.Lt_History = (IList<GiftCardHistoryView>) null;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new GiftCardView();

    public override object Clone()
    {
      GiftCardView giftCardView = base.Clone() as GiftCardView;
      giftCardView.gd_GoodsName = this.gd_GoodsName;
      giftCardView.gc_PayableStoreName = this.gc_PayableStoreName;
      giftCardView.inEmpName = this.inEmpName;
      giftCardView.modEmpName = this.modEmpName;
      giftCardView.Lt_History = this.Lt_History;
      return (object) giftCardView;
    }

    public void PutData(GiftCardView pSource)
    {
      this.PutData((TGiftCard) pSource);
      this.gd_GoodsName = pSource.gd_GoodsName;
      this.gc_PayableStoreName = pSource.gc_PayableStoreName;
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
      this.Lt_History = (IList<GiftCardHistoryView>) null;
      foreach (GiftCardHistoryView pSource1 in (IEnumerable<GiftCardHistoryView>) pSource.Lt_History)
      {
        GiftCardHistoryView giftCardHistoryView = new GiftCardHistoryView();
        giftCardHistoryView.PutData(pSource1);
        this.Lt_History.Add(giftCardHistoryView);
      }
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.gc_SiteID == 0L)
      {
        this.message = "싸이트(gc_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (string.IsNullOrEmpty(this.gc_GiftCardName))
      {
        this.message = "상품권명(gc_GiftCardName)  " + EnumDataCheck.Empty.ToDescription();
        return EnumDataCheck.Empty;
      }
      if (this.gc_FaceValue == 0)
      {
        this.message = "액면가(gc_FaceValue)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (Enum2StrConverter.ToGiftCardIssuer(this.gc_GiftCardIssuer) == EnumGiftCardIssuer.None)
      {
        this.message = "상품권발급처(gc_GiftCardIssuer)  " + EnumDataCheck.Valid.ToDescription();
        return EnumDataCheck.Valid;
      }
      if (this.gc_ExpireDate.HasValue)
        return EnumDataCheck.Success;
      this.message = "사용기한(gc_ExpireDate)  " + EnumDataCheck.NULL.ToDescription();
      return EnumDataCheck.NULL;
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
      int intFormat = DateTime.Now.ToIntFormat();
      string str = string.Format("{0}{1:D4}0000", (object) intFormat, (object) 0);
      return " SELECT " + DbQueryHelper.ToIsNULL() + "(MAX(gc_GiftCardID), " + str + ")+1 AS gc_GiftCardID" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode, (object) DbQueryHelper.ToWithNolock()) + string.Format(" WHERE ({0}/100000000)={1}", (object) "gc_GiftCardID", (object) intFormat);
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
          this.gc_GiftCardID = uniOleDbRecordset.GetFieldLong(0);
        return this.gc_GiftCardID > 0L;
      }
      finally
      {
        uniOleDbRecordset?.Close();
        pOleDB?.Close();
      }
    }

    public override async Task<bool> CreateCodeAsync(UniOleDatabase p_db)
    {
      GiftCardView giftCardView = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(p_db.ConnectionUrl);
        rs = new UniOleDbRecordset(db, db.CommandTimeout);
        if (!await rs.OpenAsync(giftCardView.CreateCodeQuery()))
        {
          giftCardView.message = " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + giftCardView.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) db.LastErrorID) + " 내용 : " + db.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          return false;
        }
        if (await rs.IsDataReadAsync())
          giftCardView.gc_GiftCardID = rs.GetFieldLong(0);
        return giftCardView.gc_GiftCardID > 0L;
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
          if (this.gc_SiteID == 0L)
            this.gc_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (this.gc_GiftCardID == 0L && !this.CreateCode(p_db))
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
      GiftCardView giftCardView = this;
      try
      {
        giftCardView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != giftCardView.DataCheck(p_db))
            throw new UniServiceException(giftCardView.message, giftCardView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (giftCardView.gc_SiteID == 0L)
            giftCardView.gc_SiteID = p_app_employee.emp_SiteID;
          if (!giftCardView.IsPermit(p_app_employee))
            throw new UniServiceException(giftCardView.message, giftCardView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (giftCardView.gc_GiftCardID == 0L)
        {
          if (!await giftCardView.CreateCodeAsync(p_db))
            throw new UniServiceException(giftCardView.message, giftCardView.TableCode.ToDescription() + " 코드 생성 오류", 2);
        }
        if (!await giftCardView.InsertAsync())
          throw new UniServiceException(giftCardView.message, giftCardView.TableCode.ToDescription() + " 등록 오류");
        giftCardView.db_status = 4;
        giftCardView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        giftCardView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        giftCardView.message = ex.Message;
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
        if (this.gc_GiftCardID == 0L)
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 상품권ID(gc_GiftCardID)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
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
      GiftCardView giftCardView = this;
      try
      {
        giftCardView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != giftCardView.DataCheck(p_db))
            throw new UniServiceException(giftCardView.message, giftCardView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!giftCardView.IsPermit(p_app_employee))
          throw new UniServiceException(giftCardView.message, giftCardView.TableCode.ToDescription() + " 권한 검사 실패");
        if (giftCardView.gc_GiftCardID == 0L)
          throw new UniServiceException(giftCardView.message, giftCardView.TableCode.ToDescription() + " 상품권ID(gc_GiftCardID)  " + EnumDataCheck.CodeZero.ToDescription() + " 오류", 2);
        if (!await giftCardView.UpdateAsync())
          throw new UniServiceException(giftCardView.message, giftCardView.TableCode.ToDescription() + " 변경 오류");
        giftCardView.db_status = 4;
        giftCardView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        giftCardView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        giftCardView.message = ex.Message;
      }
      return false;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.gd_GoodsName = p_rs.GetFieldString("gd_GoodsName");
      this.gc_PayableStoreName = p_rs.GetFieldString("gc_PayableStoreName");
      this.inEmpName = p_rs.GetFieldString("inEmpName");
      this.modEmpName = p_rs.GetFieldString("modEmpName");
      return true;
    }

    public async Task<GiftCardView> SelectOneAsync(long p_gc_GiftCardID, long p_gc_SiteID = 0)
    {
      GiftCardView giftCardView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "gc_GiftCardID",
          (object) p_gc_GiftCardID
        }
      };
      if (p_gc_SiteID > 0L)
        p_param.Add((object) "gc_SiteID", (object) p_gc_SiteID);
      return await giftCardView.SelectOneTAsync<GiftCardView>((object) p_param);
    }

    public async Task<IList<GiftCardView>> SelectListAsync(object p_param)
    {
      GiftCardView giftCardView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(giftCardView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, giftCardView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(giftCardView1.GetSelectQuery(p_param)))
        {
          giftCardView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + giftCardView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<GiftCardView>) null;
        }
        IList<GiftCardView> lt_list = (IList<GiftCardView>) new List<GiftCardView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            GiftCardView giftCardView2 = giftCardView1.OleDB.Create<GiftCardView>();
            if (giftCardView2.GetFieldValues(rs))
            {
              giftCardView2.row_number = lt_list.Count + 1;
              lt_list.Add(giftCardView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + giftCardView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<GiftCardView> SelectEnumerableAsync(object p_param)
    {
      GiftCardView giftCardView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(giftCardView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, giftCardView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(giftCardView1.GetSelectQuery(p_param)))
        {
          giftCardView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + giftCardView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            GiftCardView giftCardView2 = giftCardView1.OleDB.Create<GiftCardView>();
            if (giftCardView2.GetFieldValues(rs))
            {
              giftCardView2.row_number = ++row_number;
              yield return giftCardView2;
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
      if (p_param is Hashtable hashtable && hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
      {
        stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "gc_GiftCardName", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(")");
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
        int num1 = 0;
        string empty = string.Empty;
        long num2 = 0;
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
          if (hashtable.ContainsKey((object) "_ORDER_BY_TYPE_") && Convert.ToInt32(hashtable[(object) "_ORDER_BY_TYPE_"].ToString()) > 0)
            num1 = Convert.ToInt32(hashtable[(object) "_ORDER_BY_TYPE_"].ToString());
          if (hashtable.ContainsKey((object) "_ORDER_BY_COL_") && hashtable[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable.ContainsKey((object) "gc_SiteID") && Convert.ToInt64(hashtable[(object) "gc_SiteID"].ToString()) > 0L)
            num2 = Convert.ToInt64(hashtable[(object) "gc_SiteID"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS (\nSELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n,T_EMPLOYEE_MOD AS (\nSELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n,T_STORE AS (\nSELECT si_StoreCode,si_SiteID,si_StoreName,si_StoreViewCode,si_UseYn,si_LocationUseYn" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("gc_SiteID"))
            p_param1.Add((object) "si_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gc_PayableStore"))
            p_param1.Add((object) "si_StoreCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gc_PayableStore_IN_"))
            p_param1.Add((object) "si_StoreCode_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_STORE_AUTHS_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_MemberMntStore"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "si_SiteID"))
            p_param1.Add((object) "si_SiteID", (object) num2);
          stringBuilder.Append("\n");
          stringBuilder.Append(new TStoreInfo().GetSelectWhereAnd((object) p_param1));
        }
        else if (num2 > 0L)
          stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "si_SiteID", (object) num2));
        stringBuilder.Append(")");
        stringBuilder.Append("\n,T_GOODS AS (\nSELECT gd_GoodsCode,gd_SiteID,gd_GoodsName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Goods, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("gc_SiteID"))
            p_param1.Add((object) "gd_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gc_GoodsCode"))
            p_param1.Add((object) "gd_GoodsCode", dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "gd_SiteID"))
            p_param1.Add((object) "gd_SiteID", (object) num2);
          stringBuilder.Append("\n");
          stringBuilder.Append(new GoodsView().GetSelectWhereAnd((object) p_param1));
        }
        else if (num2 > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gd_SiteID", (object) num2));
        stringBuilder.Append(")");
        stringBuilder.Append("\nSELECT  gc_GiftCardID,gc_SiteID,gc_GiftCardName,gc_FaceValue,gc_ExchangeMinAmt,gc_ExpireDate,gc_BuyPoint,gc_CashReceiptYn,gc_PayableStore,gc_GiftCardIssuer,gc_GoodsCode,gc_UseYn,gc_InDate,gc_InUser,gc_ModDate,gc_ModUser\n,si_StoreName AS gc_PayableStoreName\n,gd_GoodsName\n,inEmpName,modEmpName\nFROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock() + "\nINNER JOIN T_STORE ON gc_PayableStore=si_StoreCode AND gc_SiteID=si_SiteID\nLEFT OUTER JOIN T_GOODS ON gc_GoodsCode=gd_GoodsCode\nLEFT OUTER JOIN T_EMPLOYEE_IN ON gc_InUser=emp_CodeIn\nLEFT OUTER JOIN T_EMPLOYEE_MOD ON gc_ModUser=emp_CodeMod");
        if (p_param is Hashtable)
        {
          stringBuilder.Append("\n");
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        }
        if (num1 > 0)
          stringBuilder.Append("\nORDER BY gc_GiftCardID");
        else if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append("\nORDER BY " + empty);
        else
          stringBuilder.Append("\nORDER BY gc_GiftCardID");
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
