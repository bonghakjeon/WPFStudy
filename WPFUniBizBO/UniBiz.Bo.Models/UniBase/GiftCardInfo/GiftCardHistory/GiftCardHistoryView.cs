// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.GiftCardInfo.GiftCardHistory.GiftCardHistoryView
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
using UniBiz.Bo.Models.UniBase.GiftCardInfo.GiftCard;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniBase.GiftCardInfo.GiftCardHistory
{
  public class GiftCardHistoryView : TGiftCardHistory<GiftCardHistoryView>
  {
    private int _gc_PayableStore;
    private int _gc_GiftCardIssuer;
    private string _gc_GiftCardName;
    private string _gc_UseYn;
    private string _gch_IssueStoreName;
    private string _gch_SaleStoreName;
    private string _gch_ReturnStoreName;
    private string _inEmpName;
    private string _modEmpName;

    public int gc_PayableStore
    {
      get => this._gc_PayableStore;
      set
      {
        this._gc_PayableStore = value;
        this.Changed(nameof (gc_PayableStore));
      }
    }

    public int gc_GiftCardIssuer
    {
      get => this._gc_GiftCardIssuer;
      set
      {
        this._gc_GiftCardIssuer = value;
        this.Changed(nameof (gc_GiftCardIssuer));
        this.Changed("gc_GiftCardIssuerDesc");
      }
    }

    public string gc_GiftCardIssuerDesc => this.gc_GiftCardIssuer != 0 ? Enum2StrConverter.ToGiftCardIssuer(this.gc_GiftCardIssuer).ToDescription() : string.Empty;

    public string gc_GiftCardName
    {
      get => this._gc_GiftCardName;
      set
      {
        this._gc_GiftCardName = value;
        this.Changed(nameof (gc_GiftCardName));
      }
    }

    public string gc_UseYn
    {
      get => this._gc_UseYn;
      set
      {
        this._gc_UseYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (gc_UseYn));
        this.Changed("gc_IsUse");
        this.Changed("gc_UseYnDesc");
      }
    }

    public bool gc_IsUse => "Y".Equals(this.gc_UseYn);

    public string gc_UseYnDesc => !"Y".Equals(this.gc_UseYn) ? "미사용" : "사용";

    public string gch_IssueStoreName
    {
      get => this._gch_IssueStoreName;
      set
      {
        this._gch_IssueStoreName = value;
        this.Changed(nameof (gch_IssueStoreName));
      }
    }

    public string gch_SaleStoreName
    {
      get => this._gch_SaleStoreName;
      set
      {
        this._gch_SaleStoreName = value;
        this.Changed(nameof (gch_SaleStoreName));
      }
    }

    public string gch_ReturnStoreName
    {
      get => this._gch_ReturnStoreName;
      set
      {
        this._gch_ReturnStoreName = value;
        this.Changed(nameof (gch_ReturnStoreName));
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

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("gc_PayableStore", new TTableColumn()
      {
        tc_orgin_name = "gc_PayableStore",
        tc_trans_name = "결제가능지점 (0:전체, else:점코드)"
      });
      columnInfo.Add("gc_GiftCardIssuer", new TTableColumn()
      {
        tc_orgin_name = "gc_GiftCardIssuer",
        tc_trans_name = "상품권발급처"
      });
      columnInfo.Add("gc_GiftCardName", new TTableColumn()
      {
        tc_orgin_name = "gc_GiftCardName",
        tc_trans_name = "상품권명"
      });
      columnInfo.Add("gc_UseYn", new TTableColumn()
      {
        tc_orgin_name = "gc_UseYn",
        tc_trans_name = "사용상태"
      });
      columnInfo.Add("gch_IssueStoreName", new TTableColumn()
      {
        tc_orgin_name = "gch_IssueStoreName",
        tc_trans_name = "발행매장"
      });
      columnInfo.Add("gch_SaleStoreName", new TTableColumn()
      {
        tc_orgin_name = "gch_SaleStoreName",
        tc_trans_name = "판매지점"
      });
      columnInfo.Add("gch_ReturnStoreName", new TTableColumn()
      {
        tc_orgin_name = "gch_ReturnStoreName",
        tc_trans_name = "사용지점"
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
      this.gc_PayableStore = 0;
      this.gc_GiftCardIssuer = 0;
      this.gc_GiftCardName = string.Empty;
      this.gc_UseYn = "N";
      this.gch_IssueStoreName = this.gch_SaleStoreName = this.gch_ReturnStoreName = string.Empty;
      this.inEmpName = string.Empty;
      this.modEmpName = string.Empty;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new GiftCardHistoryView();

    public override object Clone()
    {
      GiftCardHistoryView giftCardHistoryView = base.Clone() as GiftCardHistoryView;
      giftCardHistoryView.gc_PayableStore = this.gc_PayableStore;
      giftCardHistoryView.gc_GiftCardIssuer = this.gc_GiftCardIssuer;
      giftCardHistoryView.gc_UseYn = this.gc_UseYn;
      giftCardHistoryView.gch_IssueStoreName = this.gch_IssueStoreName;
      giftCardHistoryView.gch_SaleStoreName = this.gch_SaleStoreName;
      giftCardHistoryView.gch_ReturnStoreName = this.gch_ReturnStoreName;
      giftCardHistoryView.inEmpName = this.inEmpName;
      giftCardHistoryView.modEmpName = this.modEmpName;
      return (object) giftCardHistoryView;
    }

    public void PutData(GiftCardHistoryView pSource)
    {
      this.PutData((TGiftCardHistory) pSource);
      this.gc_PayableStore = pSource.gc_PayableStore;
      this.gc_GiftCardIssuer = pSource.gc_GiftCardIssuer;
      this.gc_UseYn = pSource.gc_UseYn;
      this.gch_IssueStoreName = pSource.gch_IssueStoreName;
      this.gch_SaleStoreName = pSource.gch_SaleStoreName;
      this.gch_ReturnStoreName = pSource.gch_ReturnStoreName;
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.gch_SiteID == 0L)
      {
        this.message = "싸이트(gch_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (string.IsNullOrEmpty(this.gch_GiftCardNo))
      {
        this.message = "상품권No(gch_GiftCardNo)  " + EnumDataCheck.Empty.ToDescription();
        return EnumDataCheck.Empty;
      }
      if (this.gch_GiftCardID == 0L)
      {
        this.message = "상품권ID(gch_GiftCardID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (Enum2StrConverter.ToGiftCardSaleKind(this.gch_SaleKind) == EnumGiftCardSaleKind.None)
      {
        this.message = "판매구분(gch_SaleKind)  " + EnumDataCheck.Valid.ToDescription();
        return EnumDataCheck.Valid;
      }
      DateTime? nullable = this.gch_IssueDate;
      if (!nullable.HasValue)
      {
        this.message = "발행일(gch_IssueDate)  " + EnumDataCheck.NULL.ToDescription();
        return EnumDataCheck.NULL;
      }
      if (this.gch_IssueStore == 0)
      {
        this.message = "발행매장(gch_IssueStore)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.gch_FaceValue == 0)
      {
        this.message = "액면가(gch_FaceValue)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      nullable = this.gch_ExpireDate;
      if (!nullable.HasValue)
      {
        this.message = "만료일(gch_ExpireDate)  " + EnumDataCheck.NULL.ToDescription();
        return EnumDataCheck.NULL;
      }
      nullable = this.gch_IssueDate;
      int intFormat1 = nullable.Value.ToIntFormat();
      nullable = this.gch_ExpireDate;
      int intFormat2 = nullable.Value.ToIntFormat();
      if (intFormat1 <= intFormat2)
        return EnumDataCheck.Success;
      this.message = "발행일(gch_IssueDate) > 만료일(gch_ExpireDate)  " + EnumDataCheck.Valid.ToDescription();
      return EnumDataCheck.Valid;
    }

    protected override EnumDataCheck DataCheck(UniOleDatabase p_db)
    {
      if (p_db == null)
      {
        this.message = "DB CONNECT (UniOleDatabase) " + EnumDataCheck.NULL.ToDescription();
        return EnumDataCheck.NULL;
      }
      EnumDataCheck enumDataCheck = this.DataCheck();
      if (enumDataCheck != EnumDataCheck.Success)
        return enumDataCheck;
      IList<GiftCardHistoryView> giftCardHistoryViewList = p_db.Create<GiftCardHistoryView>().SelectListE<GiftCardHistoryView>((object) new Hashtable()
      {
        {
          (object) "gch_GiftCardNo",
          (object) this.gch_GiftCardNo
        }
      });
      if (this.IsNew)
      {
        if (giftCardHistoryViewList.Count > 0 && !string.IsNullOrEmpty(this.gch_GiftCardNo))
        {
          this.message = "상품권No(gch_GiftCardNo) " + EnumDataCheck.Exists.ToDescription() + "\n - 상품권 [" + this.gch_GiftCardNo + "] " + EnumDataCheck.Exists.ToDescription() + " 사용중.";
          return EnumDataCheck.Exists;
        }
      }
      else if (this.IsUpdate)
      {
        if (giftCardHistoryViewList.Count == 0)
        {
          this.message = "상품권No(gch_GiftCardNo) " + EnumDataCheck.NULL.ToDescription() + "\n - 상품권 [" + this.gch_GiftCardNo + "] " + EnumDataCheck.NULL.ToDescription() + ".";
          return EnumDataCheck.NULL;
        }
        if (giftCardHistoryViewList.Count > 1)
        {
          this.message = "상품권No(gch_GiftCardNo) " + EnumDataCheck.Exists.ToDescription() + "\n - 상품권 [" + this.gch_GiftCardNo + "] " + EnumDataCheck.Exists.ToDescription() + " (" + giftCardHistoryViewList.Count.ToString("n0") + "건)사용중.";
          return EnumDataCheck.Exists;
        }
      }
      return EnumDataCheck.Success;
    }

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
          if (this.gch_SiteID == 0L)
            this.gch_SiteID = p_app_employee.emp_SiteID;
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
      GiftCardHistoryView giftCardHistoryView = this;
      try
      {
        giftCardHistoryView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != giftCardHistoryView.DataCheck(p_db))
            throw new UniServiceException(giftCardHistoryView.message, giftCardHistoryView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (giftCardHistoryView.gch_SiteID == 0L)
            giftCardHistoryView.gch_SiteID = p_app_employee.emp_SiteID;
          if (!giftCardHistoryView.IsPermit(p_app_employee))
            throw new UniServiceException(giftCardHistoryView.message, giftCardHistoryView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (!await giftCardHistoryView.InsertAsync())
          throw new UniServiceException(giftCardHistoryView.message, giftCardHistoryView.TableCode.ToDescription() + " 등록 오류");
        giftCardHistoryView.db_status = 4;
        giftCardHistoryView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        giftCardHistoryView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        giftCardHistoryView.message = ex.Message;
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
      GiftCardHistoryView giftCardHistoryView = this;
      try
      {
        giftCardHistoryView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != giftCardHistoryView.DataCheck(p_db))
            throw new UniServiceException(giftCardHistoryView.message, giftCardHistoryView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!giftCardHistoryView.IsPermit(p_app_employee))
          throw new UniServiceException(giftCardHistoryView.message, giftCardHistoryView.TableCode.ToDescription() + " 권한 검사 실패");
        if (!await giftCardHistoryView.UpdateAsync())
          throw new UniServiceException(giftCardHistoryView.message, giftCardHistoryView.TableCode.ToDescription() + " 변경 오류");
        giftCardHistoryView.db_status = 4;
        giftCardHistoryView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        giftCardHistoryView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        giftCardHistoryView.message = ex.Message;
      }
      return false;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.gc_PayableStore = p_rs.GetFieldInt("gc_PayableStore");
      this.gc_GiftCardIssuer = p_rs.GetFieldInt("gc_GiftCardIssuer");
      this.gc_GiftCardName = p_rs.GetFieldString("gc_GiftCardName");
      this.gc_UseYn = p_rs.GetFieldString("gc_UseYn");
      this.gch_IssueStoreName = p_rs.GetFieldString("gch_IssueStoreName");
      this.gch_SaleStoreName = p_rs.GetFieldString("gch_SaleStoreName");
      this.gch_ReturnStoreName = p_rs.GetFieldString("gch_ReturnStoreName");
      this.inEmpName = p_rs.GetFieldString("inEmpName");
      this.modEmpName = p_rs.GetFieldString("modEmpName");
      return true;
    }

    public async Task<GiftCardHistoryView> SelectOneAsync(
      string p_gch_GiftCardNo,
      long p_gch_SiteID = 0)
    {
      GiftCardHistoryView giftCardHistoryView = this;
      if (string.IsNullOrEmpty(p_gch_GiftCardNo))
        return new GiftCardHistoryView();
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "gch_GiftCardNo",
          (object) p_gch_GiftCardNo
        }
      };
      if (p_gch_SiteID > 0L)
        p_param.Add((object) "gch_SiteID", (object) p_gch_SiteID);
      return await giftCardHistoryView.SelectOneTAsync<GiftCardHistoryView>((object) p_param);
    }

    public async Task<IList<GiftCardHistoryView>> SelectListAsync(object p_param)
    {
      GiftCardHistoryView giftCardHistoryView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(giftCardHistoryView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, giftCardHistoryView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(giftCardHistoryView1.GetSelectQuery(p_param)))
        {
          giftCardHistoryView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + giftCardHistoryView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<GiftCardHistoryView>) null;
        }
        IList<GiftCardHistoryView> lt_list = (IList<GiftCardHistoryView>) new List<GiftCardHistoryView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            GiftCardHistoryView giftCardHistoryView2 = giftCardHistoryView1.OleDB.Create<GiftCardHistoryView>();
            if (giftCardHistoryView2.GetFieldValues(rs))
            {
              giftCardHistoryView2.row_number = lt_list.Count + 1;
              lt_list.Add(giftCardHistoryView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + giftCardHistoryView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<GiftCardHistoryView> SelectEnumerableAsync(object p_param)
    {
      GiftCardHistoryView giftCardHistoryView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(giftCardHistoryView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, giftCardHistoryView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(giftCardHistoryView1.GetSelectQuery(p_param)))
        {
          giftCardHistoryView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + giftCardHistoryView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            GiftCardHistoryView giftCardHistoryView2 = giftCardHistoryView1.OleDB.Create<GiftCardHistoryView>();
            if (giftCardHistoryView2.GetFieldValues(rs))
            {
              giftCardHistoryView2.row_number = ++row_number;
              yield return giftCardHistoryView2;
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
        stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "gch_GiftCardNo", hashtable[(object) "_KEY_WORD_"]));
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
        bool flag = false;
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
          if (hashtable.ContainsKey((object) "gch_SiteID") && Convert.ToInt64(hashtable[(object) "gch_SiteID"].ToString()) > 0L)
            num2 = Convert.ToInt64(hashtable[(object) "gch_SiteID"].ToString());
          if (hashtable.ContainsKey((object) "GiftCard_DEFULT_TABLE_") && Convert.ToBoolean(hashtable[(object) "GiftCard_DEFULT_TABLE_"].ToString()))
            flag = Convert.ToBoolean(hashtable[(object) "GiftCard_DEFULT_TABLE_"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS (\nSELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n,T_EMPLOYEE_MOD AS (\nSELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n,T_STORE_ISSUE AS (\nSELECT si_StoreCode AS issue_si_StoreCode,si_SiteID AS issue_si_SiteID,si_StoreName AS issue_si_StoreName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()));
        if (num2 > 0L)
          stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "si_SiteID", (object) num2));
        stringBuilder.Append(")");
        stringBuilder.Append("\n,T_STORE_SALE AS (\nSELECT si_StoreCode AS sale_si_StoreCode,si_SiteID AS sale_si_SiteID,si_StoreName AS sale_si_StoreName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()));
        if (num2 > 0L)
          stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "si_SiteID", (object) num2));
        stringBuilder.Append(")");
        stringBuilder.Append("\n,T_STORE_RETURN AS (\nSELECT si_StoreCode AS return_si_StoreCode,si_SiteID AS return_si_SiteID,si_StoreName AS return_si_StoreName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()));
        if (num2 > 0L)
          stringBuilder.Append(string.Format("\nWHERE {0}={1}", (object) "si_SiteID", (object) num2));
        stringBuilder.Append(")");
        stringBuilder.Append("\n,T_HEADER AS (\nSELECT gc_GiftCardID,gc_SiteID,gc_PayableStore,gc_UseYn,gc_GiftCardIssuer,gc_GiftCardName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.GiftCard, (object) DbQueryHelper.ToWithNolock()));
        if (flag)
        {
          stringBuilder.Append("\n");
          stringBuilder.Append(new TGiftCard().GetSelectWhereAnd(p_param));
        }
        else
        {
          p_param1.Clear();
          foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
          {
            if (dictionaryEntry.Key.ToString().Equals("gch_SiteID"))
              p_param1.Add((object) "gc_SiteID", dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("gch_IssueStore"))
              p_param1.Add((object) "gc_PayableStore", dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("gch_IssueStore_IN_"))
              p_param1.Add((object) "gc_PayableStore_IN_", dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("gch_FaceValue"))
              p_param1.Add((object) "gc_FaceValue", dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("gch_FaceValue_BEGIN_"))
              p_param1.Add((object) "gc_FaceValue_BEGIN_", dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("gch_FaceValue_END_"))
              p_param1.Add((object) "gc_FaceValue_END_", dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("gch_ExpireDate"))
              p_param1.Add((object) "gc_ExpireDate", dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("gch_ExpireDate_BEGIN_"))
              p_param1.Add((object) "gc_ExpireDate_BEGIN_", dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("gch_ExpireDate_END_"))
              p_param1.Add((object) "gc_ExpireDate_END_", dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("gc_PayableStore"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("gc_PayableStore_IN_"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("gc_GiftCardIssuer"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
            if (dictionaryEntry.Key.ToString().Equals("gc_UseYn"))
              p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          }
          if (p_param1.Count > 0)
          {
            if (!p_param1.ContainsKey((object) "gc_SiteID"))
              p_param1.Add((object) "gc_SiteID", (object) num2);
            stringBuilder.Append("\n");
            stringBuilder.Append(new TGiftCard().GetSelectWhereAnd((object) p_param1));
          }
          else if (num2 > 0L)
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gc_SiteID", (object) num2));
        }
        stringBuilder.Append(")");
        stringBuilder.Append("\nSELECT  gch_GiftCardNo,gch_SiteID,gch_GiftCardID,gch_IssueDate,gch_IssueStore,gch_FaceValue,gch_ExpireDate,gch_SaleDate,gch_SaleStore,gch_SalePosNo,gch_SaleTransNo,gch_SaleEmpCode,gch_SaleMemberNo,gch_SaleKind,gch_ReturnDate,gch_ReturnStore,gch_ReturnPosNo,gch_ReturnTransNo,gch_ReturnMemberNo,gch_DisuseYn,gch_DisuseDate,gch_DisuseStatement,gch_DisuseEmpCode,gch_UseYn,gch_InDate,gch_InUser,gch_ModDate,gch_ModUser\n,gc_PayableStore,gc_GiftCardIssuer,gc_GiftCardName,gc_UseYn\n,issue_si_StoreName AS gch_IssueStoreName\n,sale_si_StoreName AS gch_SaleStoreName\n,return_si_StoreName AS gch_ReturnStoreName\n,inEmpName,modEmpName\nFROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock() + "\nINNER JOIN T_HEADER ON gch_GiftCardID=issue_gc_GiftCardID AND gch_SiteID=issue_gc_SiteID\nINNER JOIN T_STORE_ISSUE ON gch_IssueStore=issue_si_StoreCode AND gch_SiteID=issue_si_SiteID\nLEFT OUTER JOIN T_STORE_SALE ON gch_SaleStore=sale_si_StoreCode AND gch_SiteID=sale_si_SiteID\nLEFT OUTER JOIN T_STORE_RETURN ON gch_ReturnStore=return_si_StoreCode AND gch_SiteID=return_si_SiteID\nLEFT OUTER JOIN T_EMPLOYEE_IN ON gch_InUser=emp_CodeIn\nLEFT OUTER JOIN T_EMPLOYEE_MOD ON gch_ModUser=emp_CodeMod");
        if (!flag && p_param is Hashtable)
        {
          stringBuilder.Append("\n");
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        }
        if (num1 > 0)
          stringBuilder.Append("\nORDER BY gch_GiftCardNo");
        else if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append("\nORDER BY " + empty);
        else
          stringBuilder.Append("\nORDER BY gch_GiftCardNo");
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
