// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsImage.GoodsImageView
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
using UniBiz.Bo.Models.UniBase.GoodsInfo.Goods;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsImage
{
  public class GoodsImageView : TGoodsImage<GoodsImageView>
  {
    private string _gd_GoodsName;
    private string _inEmpName;
    private string _modEmpName;

    public string gd_GoodsName
    {
      get => this._gd_GoodsName;
      set
      {
        this._gd_GoodsName = value;
        this.Changed(nameof (gd_GoodsName));
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
      columnInfo.Add("inEmpName", new TTableColumn()
      {
        tc_orgin_name = "inEmpName",
        tc_trans_name = "등록사원"
      });
      columnInfo.Add("modEmpName", new TTableColumn()
      {
        tc_orgin_name = "modEmpName",
        tc_trans_name = "수정사원"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.gd_GoodsName = string.Empty;
      this.inEmpName = string.Empty;
      this.modEmpName = string.Empty;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new GoodsImageView();

    public override object Clone()
    {
      GoodsImageView goodsImageView = base.Clone() as GoodsImageView;
      goodsImageView.gd_GoodsName = this.gd_GoodsName;
      goodsImageView.inEmpName = this.inEmpName;
      goodsImageView.modEmpName = this.modEmpName;
      return (object) goodsImageView;
    }

    public void PutData(GoodsImageView pSource)
    {
      this.PutData((TGoodsImage) pSource);
      this.gd_GoodsName = pSource.gd_GoodsName;
      this.inEmpName = pSource.inEmpName;
      this.modEmpName = pSource.modEmpName;
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.gi_GoodsCode == 0L)
      {
        this.message = "상품코드(gi_GoodsCode)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (this.gi_SiteID == 0L)
      {
        this.message = "싸이트(gi_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (Enum2StrConverter.IsExtensionImage(this.gi_ImgType))
        return EnumDataCheck.Success;
      this.message = "이미지타입(gi_ImgType)  " + EnumDataCheck.Valid.ToDescription();
      return EnumDataCheck.Valid;
    }

    protected override EnumDataCheck DataCheck(UniOleDatabase p_db) => base.DataCheck(p_db);

    protected override bool IsPermit(EmployeeView p_app_employee) => EnumDataCheck.Success == this.DataCheck(this.OleDB);

    public override bool Insert()
    {
      if (!base.Insert())
        return false;
      if (this.IsOriginData)
        this.UpdateFile();
      return this.SetSuccessInfo(string.Format("({0},{1}) 등록됨.", (object) this.gi_GoodsCode, (object) this.gi_SiteID));
    }

    public override async Task<bool> InsertAsync()
    {
      GoodsImageView goodsImageView = this;
      // ISSUE: reference to a compiler-generated method
      if (!await goodsImageView.\u003C\u003En__0())
        return false;
      if (goodsImageView.IsOriginData)
      {
        int num = await goodsImageView.UpdateFileAsync() ? 1 : 0;
      }
      return goodsImageView.SetSuccessInfo(string.Format("({0},{1}) 등록됨.", (object) goodsImageView.gi_GoodsCode, (object) goodsImageView.gi_SiteID));
    }

    public override bool Update(UbModelBase p_old = null)
    {
      if (!base.Update(p_old))
        return false;
      if (this.IsOriginData)
        this.UpdateFile();
      return this.SetSuccessInfo(string.Format("({0},{1}) 변경됨.", (object) this.gi_GoodsCode, (object) this.gi_SiteID));
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      GoodsImageView goodsImageView = this;
      // ISSUE: reference to a compiler-generated method
      if (!await goodsImageView.\u003C\u003En__1(p_old))
        return false;
      if (goodsImageView.IsOriginData)
      {
        int num = await goodsImageView.UpdateFileAsync() ? 1 : 0;
      }
      return goodsImageView.SetSuccessInfo(string.Format("({0},{1}) 변경됨.", (object) goodsImageView.gi_GoodsCode, (object) goodsImageView.gi_SiteID));
    }

    public override bool UpdateExInsert()
    {
      if (!base.UpdateExInsert())
        return false;
      if (this.IsOriginData)
        this.UpdateFile();
      return this.SetSuccessInfo(string.Format("({0},{1}) 변경됨.", (object) this.gi_GoodsCode, (object) this.gi_SiteID));
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      GoodsImageView goodsImageView = this;
      // ISSUE: reference to a compiler-generated method
      if (!await goodsImageView.\u003C\u003En__2())
        return false;
      if (goodsImageView.IsOriginData)
      {
        int num = await goodsImageView.UpdateFileAsync() ? 1 : 0;
      }
      return goodsImageView.SetSuccessInfo(string.Format("({0},{1}) 변경됨.", (object) goodsImageView.gi_GoodsCode, (object) goodsImageView.gi_SiteID));
    }

    public override bool InsertData(
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
        else
        {
          if (this.gi_SiteID == 0L)
            this.gi_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!this.Insert())
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 등록 오류");
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
      GoodsImageView goodsImageView = this;
      try
      {
        goodsImageView.SetAdoDatabase(p_db);
        if (p_app_employee == null || p_app_employee.emp_Code == 0)
        {
          if (EnumDataCheck.Success != goodsImageView.DataCheck(p_db))
            throw new UniServiceException(goodsImageView.message, goodsImageView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (goodsImageView.gi_SiteID == 0L)
            goodsImageView.gi_SiteID = p_app_employee.emp_SiteID;
          if (!goodsImageView.IsPermit(p_app_employee))
            throw new UniServiceException(goodsImageView.message, goodsImageView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await goodsImageView.InsertAsync())
          throw new UniServiceException(goodsImageView.message, goodsImageView.TableCode.ToDescription() + " 등록 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        goodsImageView.db_status = 4;
        goodsImageView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        goodsImageView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        goodsImageView.message = ex.Message;
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
        if (p_app_employee == null || p_app_employee.emp_Code == 0)
        {
          if (EnumDataCheck.Success != this.DataCheck(p_db))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!this.IsPermit(p_app_employee))
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!this.Update())
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 변경 오류");
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
      GoodsImageView goodsImageView = this;
      try
      {
        goodsImageView.SetAdoDatabase(p_db);
        if (p_app_employee == null || p_app_employee.emp_Code == 0)
        {
          if (EnumDataCheck.Success != goodsImageView.DataCheck(p_db))
            throw new UniServiceException(goodsImageView.message, goodsImageView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!goodsImageView.IsPermit(p_app_employee))
          throw new UniServiceException(goodsImageView.message, goodsImageView.TableCode.ToDescription() + " 권한 검사 실패");
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await goodsImageView.UpdateAsync())
          throw new UniServiceException(goodsImageView.message, goodsImageView.TableCode.ToDescription() + " 변경 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        goodsImageView.db_status = 4;
        goodsImageView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        goodsImageView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        goodsImageView.message = ex.Message;
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
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!this.Delete())
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 변경 오류");
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
      GoodsImageView goodsImageView = this;
      try
      {
        goodsImageView.SetAdoDatabase(p_db);
        if (p_app_employee == null || p_app_employee.emp_Code == 0)
        {
          if (EnumDataCheck.Success != goodsImageView.DataCheck(p_db))
            throw new UniServiceException(goodsImageView.message, goodsImageView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!goodsImageView.IsPermit(p_app_employee))
          throw new UniServiceException(goodsImageView.message, goodsImageView.TableCode.ToDescription() + " 권한 검사 실패");
        if (p_is_trans)
          p_db.BeginTransaction();
        if (!await goodsImageView.DeleteAsync())
          throw new UniServiceException(goodsImageView.message, goodsImageView.TableCode.ToDescription() + " 변경 오류");
        if (p_is_trans)
          p_db.CommitTransaction();
        goodsImageView.db_status = 4;
        goodsImageView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        goodsImageView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        if (p_is_trans && p_db != null)
          p_db.RollbackTransaction();
        goodsImageView.message = ex.Message;
      }
      return false;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.gd_GoodsName = p_rs.GetFieldString("gd_GoodsName");
      this.inEmpName = p_rs.GetFieldString("inEmpName");
      this.modEmpName = p_rs.GetFieldString("modEmpName");
      return true;
    }

    public async Task<GoodsImageView> SelectOneAsync(
      long p_gi_GoodsCode,
      long p_gi_SiteID = 0,
      bool p_is_thumb_data = true,
      bool p_is_file_data = false)
    {
      GoodsImageView goodsImageView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "gi_GoodsCode",
          (object) p_gi_GoodsCode
        },
        {
          (object) "IS_THUMB_IMAGE_VIEW",
          (object) p_is_thumb_data
        },
        {
          (object) "IS_FILE_IMAGE_VIEW",
          (object) p_is_file_data
        }
      };
      if (p_gi_SiteID > 0L)
        p_param.Add((object) "gi_SiteID", (object) p_gi_SiteID);
      return await goodsImageView.SelectOneTAsync<GoodsImageView>((object) p_param);
    }

    public async Task<IList<GoodsImageView>> SelectListAsync(object p_param)
    {
      GoodsImageView goodsImageView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(goodsImageView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, goodsImageView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(goodsImageView1.GetSelectQuery(p_param)))
        {
          goodsImageView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + goodsImageView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<GoodsImageView>) null;
        }
        IList<GoodsImageView> lt_list = (IList<GoodsImageView>) new List<GoodsImageView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            GoodsImageView goodsImageView2 = goodsImageView1.OleDB.Create<GoodsImageView>();
            if (goodsImageView2.GetFieldValues(rs))
            {
              goodsImageView2.row_number = lt_list.Count + 1;
              lt_list.Add(goodsImageView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + goodsImageView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<GoodsImageView> SelectEnumerableAsync(object p_param)
    {
      GoodsImageView goodsImageView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(goodsImageView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, goodsImageView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(goodsImageView1.GetSelectQuery(p_param)))
        {
          goodsImageView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + goodsImageView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            GoodsImageView goodsImageView2 = goodsImageView1.OleDB.Create<GoodsImageView>();
            if (goodsImageView2.GetFieldValues(rs))
            {
              goodsImageView2.row_number = ++row_number;
              yield return goodsImageView2;
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
        stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "gi_ImgFileName", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "gd_GoodsName", hashtable[(object) "_KEY_WORD_"]));
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
        long num = 0;
        bool flag1 = false;
        bool flag2 = false;
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
          if (hashtable.ContainsKey((object) "_ORDER_BY_COL_") && hashtable[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable.ContainsKey((object) "gi_SiteID") && Convert.ToInt64(hashtable[(object) "gi_SiteID"].ToString()) > 0L)
            num = Convert.ToInt64(hashtable[(object) "gi_SiteID"].ToString());
          if (hashtable.ContainsKey((object) "IS_THUMB_IMAGE_VIEW") && Convert.ToBoolean(hashtable[(object) "IS_THUMB_IMAGE_VIEW"].ToString()))
            flag1 = Convert.ToBoolean(hashtable[(object) "IS_THUMB_IMAGE_VIEW"].ToString());
          if (hashtable.ContainsKey((object) "IS_FILE_IMAGE_VIEW") && Convert.ToBoolean(hashtable[(object) "IS_FILE_IMAGE_VIEW"].ToString()))
            flag2 = Convert.ToBoolean(hashtable[(object) "IS_FILE_IMAGE_VIEW"].ToString());
        }
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS ( SELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_EMPLOYEE_MOD AS ( SELECT emp_Code AS emp_CodeMod,emp_Name AS modEmpName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(",T_GOODS AS ( SELECT gd_GoodsCode,gd_SiteID,gd_GoodsName" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Goods, (object) DbQueryHelper.ToWithNolock()));
        Hashtable p_param1 = new Hashtable();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("gi_SiteID"))
            p_param1.Add((object) "gd_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gi_GoodsCode"))
            p_param1.Add((object) "gd_GoodsCode", dictionaryEntry.Value);
          if (!dictionaryEntry.Key.ToString().Equals("_KEY_WORD_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
          stringBuilder.Append(new TGoods().GetSelectWhereAnd((object) p_param1));
        else if (num > 0L)
          stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "gd_SiteID", (object) num));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(" SELECT  gi_GoodsCode,gi_SiteID,gi_ImgType,gi_ImgFileName,gi_ThumbSize,gi_Thumb2Size,gi_Thumb3Size,gi_Thumb4Size,gi_OriginSize,gi_InDate,gi_InUser,gi_ModDate,gi_ModUser,gd_GoodsName,inEmpName,modEmpName");
        if (flag1)
          stringBuilder.Append(",gi_ThumbData");
        if (flag2)
          stringBuilder.Append(",gi_OriginData");
        stringBuilder.Append("\n");
        stringBuilder.Append(" FROM " + DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_IMAGES) + str + " " + DbQueryHelper.ToWithNolock() + " INNER JOIN T_GOODS ON gi_GoodsCode=gd_GoodsCode AND gi_SiteID=gd_SiteID");
        stringBuilder.Append(" LEFT OUTER JOIN T_EMPLOYEE_IN ON gi_InUser=emp_CodeIn LEFT OUTER JOIN T_EMPLOYEE_MOD ON gi_ModUser=emp_CodeMod");
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append(" ORDER BY " + empty);
        else
          stringBuilder.Append(" ORDER BY gi_GoodsCode");
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
