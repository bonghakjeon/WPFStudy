// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniImages.UniTemplates.Label.TLabelTemplateCols
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using Serilog;
using System;
using System.Collections;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UniBiz.Bo.Models.Converter;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniImages.UniTemplates.Label
{
  public class TLabelTemplateCols : UbModelBase<TLabelTemplateCols>
  {
    private long _ltc_ID;
    private int _ltc_Seq;
    private long _ltc_SiteID;
    private string _ltc_ColID;
    private string _ltc_FormatDataID;
    private int _ltc_Count;
    private string _ltc_Point;
    private DateTime? _ltc_InDate;
    private DateTime? _ltc_ModDate;

    public override object _Key => (object) new object[2]
    {
      (object) this.ltc_ID,
      (object) this.ltc_Seq
    };

    public long ltc_ID
    {
      get => this._ltc_ID;
      set
      {
        this._ltc_ID = value;
        this.Changed(nameof (ltc_ID));
      }
    }

    public int ltc_Seq
    {
      get => this._ltc_Seq;
      set
      {
        this._ltc_Seq = value;
        this.Changed(nameof (ltc_Seq));
      }
    }

    public long ltc_SiteID
    {
      get => this._ltc_SiteID;
      set
      {
        this._ltc_SiteID = value;
        this.Changed(nameof (ltc_SiteID));
      }
    }

    public string ltc_ColID
    {
      get => this._ltc_ColID;
      set
      {
        this._ltc_ColID = UbModelBase.LeftStr(value, 40).Replace("'", "´");
        this.Changed(nameof (ltc_ColID));
      }
    }

    public string ltc_FormatDataID
    {
      get => this._ltc_FormatDataID;
      set
      {
        this._ltc_FormatDataID = UbModelBase.LeftStr(value, 40).Replace("'", "´");
        this.Changed(nameof (ltc_FormatDataID));
      }
    }

    public int ltc_Count
    {
      get => this._ltc_Count;
      set
      {
        this._ltc_Count = value;
        this.Changed(nameof (ltc_Count));
      }
    }

    public string ltc_Point
    {
      get => this._ltc_Point;
      set
      {
        this._ltc_Point = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (ltc_Point));
      }
    }

    public DateTime? ltc_InDate
    {
      get => this._ltc_InDate;
      set
      {
        this._ltc_InDate = value;
        this.Changed(nameof (ltc_InDate));
      }
    }

    public DateTime? ltc_ModDate
    {
      get => this._ltc_ModDate;
      set
      {
        this._ltc_ModDate = value;
        this.Changed(nameof (ltc_ModDate));
      }
    }

    public TLabelTemplateCols() => this.Clear();

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.LabelTemplateCols;
      this.ltc_ID = 0L;
      this.ltc_Seq = 0;
      this.ltc_SiteID = 0L;
      this.ltc_ColID = this.ltc_FormatDataID = string.Empty;
      this.ltc_Count = 0;
      this.ltc_Point = string.Empty;
      this.ltc_InDate = new DateTime?();
      this.ltc_ModDate = new DateTime?();
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TLabelTemplateCols();

    public override object Clone()
    {
      TLabelTemplateCols tlabelTemplateCols = base.Clone() as TLabelTemplateCols;
      tlabelTemplateCols.ltc_ID = this.ltc_ID;
      tlabelTemplateCols.ltc_Seq = this.ltc_Seq;
      tlabelTemplateCols.ltc_SiteID = this.ltc_SiteID;
      tlabelTemplateCols.ltc_ColID = this.ltc_ColID;
      tlabelTemplateCols.ltc_FormatDataID = this.ltc_FormatDataID;
      tlabelTemplateCols.ltc_Count = this.ltc_Count;
      tlabelTemplateCols.ltc_Point = this.ltc_Point;
      tlabelTemplateCols.ltc_InDate = this.ltc_InDate;
      tlabelTemplateCols.ltc_ModDate = this.ltc_ModDate;
      return (object) tlabelTemplateCols;
    }

    public void PutData(TLabelTemplateCols pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.ltc_ID = pSource.ltc_ID;
      this.ltc_Seq = pSource.ltc_Seq;
      this.ltc_SiteID = pSource.ltc_SiteID;
      this.ltc_ColID = pSource.ltc_ColID;
      this.ltc_FormatDataID = pSource.ltc_FormatDataID;
      this.ltc_Count = pSource.ltc_Count;
      this.ltc_Point = pSource.ltc_Point;
      this.ltc_InDate = pSource.ltc_InDate;
      this.ltc_ModDate = pSource.ltc_ModDate;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.ltc_ID = p_rs.GetFieldLong("ltc_ID");
        if (this.ltc_ID == 0L)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.ltc_Seq = p_rs.GetFieldInt("ltc_Seq");
        this.ltc_SiteID = p_rs.GetFieldLong("ltc_SiteID");
        this.ltc_ColID = p_rs.GetFieldString("ltc_ColID");
        this.ltc_FormatDataID = p_rs.GetFieldString("ltc_FormatDataID");
        this.ltc_Count = p_rs.GetFieldInt("ltc_Count");
        this.ltc_Point = p_rs.GetFieldString("ltc_Point");
        this.ltc_InDate = p_rs.GetFieldDateTime("ltc_InDate");
        this.ltc_ModDate = p_rs.GetFieldDateTime("ltc_ModDate");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_IMAGES), (object) this.TableCode) + " ltc_ID,ltc_Seq,ltc_SiteID,ltc_ColID,ltc_FormatDataID,ltc_Count,ltc_Point,ltc_InDate,ltc_ModDate) VALUES ( " + string.Format(" {0},{1}", (object) this.ltc_ID, (object) this.ltc_Seq) + string.Format(",{0}", (object) this.ltc_SiteID) + ",'" + this.ltc_ColID + "','" + this.ltc_FormatDataID + "'" + string.Format(",{0},'{1}'", (object) this.ltc_Count, (object) this.ltc_Point) + "," + this.ltc_InDate.GetDateToStrInNull() + "," + this.ltc_ModDate.GetDateToStrInNull() + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.ltc_ID, (object) this.ltc_Seq, (object) this.ltc_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TLabelTemplateCols tlabelTemplateCols = this;
      // ISSUE: reference to a compiler-generated method
      tlabelTemplateCols.\u003C\u003En__0();
      if (await tlabelTemplateCols.OleDB.ExecuteAsync(tlabelTemplateCols.InsertQuery()))
        return true;
      tlabelTemplateCols.message = " " + tlabelTemplateCols.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tlabelTemplateCols.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tlabelTemplateCols.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tlabelTemplateCols.ltc_ID, (object) tlabelTemplateCols.ltc_Seq, (object) tlabelTemplateCols.ltc_SiteID) + " 내용 : " + tlabelTemplateCols.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tlabelTemplateCols.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_IMAGES), (object) this.TableCode) + " ltc_ColID='" + this.ltc_ColID + "',ltc_FormatDataID='" + this.ltc_FormatDataID + "'" + string.Format(",{0}={1},{2}='{3}'", (object) "ltc_Count", (object) this.ltc_Count, (object) "ltc_Point", (object) this.ltc_Point) + ",ltc_ModDate=" + this.ltc_ModDate.GetDateToStrInNull() + string.Format(" WHERE {0}={1}", (object) "ltc_ID", (object) this.ltc_ID) + string.Format(" AND {0}={1}", (object) "ltc_Seq", (object) this.ltc_Seq) + string.Format(" AND {0}={1}", (object) "ltc_SiteID", (object) this.ltc_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.ltc_ID, (object) this.ltc_Seq, (object) this.ltc_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TLabelTemplateCols tlabelTemplateCols = this;
      // ISSUE: reference to a compiler-generated method
      tlabelTemplateCols.\u003C\u003En__1();
      if (await tlabelTemplateCols.OleDB.ExecuteAsync(tlabelTemplateCols.UpdateQuery()))
        return true;
      tlabelTemplateCols.message = " " + tlabelTemplateCols.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tlabelTemplateCols.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tlabelTemplateCols.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tlabelTemplateCols.ltc_ID, (object) tlabelTemplateCols.ltc_Seq, (object) tlabelTemplateCols.ltc_SiteID) + " 내용 : " + tlabelTemplateCols.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tlabelTemplateCols.message);
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
      stringBuilder.Append(" ltc_ColID='" + this.ltc_ColID + "',ltc_FormatDataID='" + this.ltc_FormatDataID + "'" + string.Format(",{0}={1},{2}='{3}'", (object) "ltc_Count", (object) this.ltc_Count, (object) "ltc_Point", (object) this.ltc_Point) + ",ltc_ModDate=" + this.ltc_ModDate.GetDateToStrInNull());
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.ltc_ID, (object) this.ltc_Seq, (object) this.ltc_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TLabelTemplateCols tlabelTemplateCols = this;
      // ISSUE: reference to a compiler-generated method
      tlabelTemplateCols.\u003C\u003En__1();
      if (await tlabelTemplateCols.OleDB.ExecuteAsync(tlabelTemplateCols.UpdateExInsertQuery()))
        return true;
      tlabelTemplateCols.message = " " + tlabelTemplateCols.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tlabelTemplateCols.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tlabelTemplateCols.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tlabelTemplateCols.ltc_ID, (object) tlabelTemplateCols.ltc_Seq, (object) tlabelTemplateCols.ltc_SiteID) + " 내용 : " + tlabelTemplateCols.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tlabelTemplateCols.message);
      return false;
    }

    public override string DeleteQuery() => string.Format(" DELETE FROM {0}{1}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_IMAGES), (object) this.TableCode) + string.Format(" WHERE {0}={1}", (object) "ltc_ID", (object) this.ltc_ID) + string.Format(" AND {0}={1}", (object) "ltc_Seq", (object) this.ltc_Seq) + string.Format(" AND {0}={1}", (object) "ltc_SiteID", (object) this.ltc_SiteID);

    public override bool Delete()
    {
      this.InsertChecked();
      string pStrExec = this.DeleteQuery();
      if (this.OleDB.Execute(pStrExec))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 삭제 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.ltc_ID, (object) this.ltc_Seq, (object) this.ltc_SiteID) + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n 쿼리 : " + pStrExec + "\n--------------------------------------------------------------------------------------------------\n";
      return false;
    }

    public override async Task<bool> DeleteAsync()
    {
      TLabelTemplateCols tlabelTemplateCols = this;
      // ISSUE: reference to a compiler-generated method
      tlabelTemplateCols.\u003C\u003En__0();
      if (await tlabelTemplateCols.OleDB.ExecuteAsync(tlabelTemplateCols.DeleteQuery()))
        return true;
      tlabelTemplateCols.message = " " + tlabelTemplateCols.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tlabelTemplateCols.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tlabelTemplateCols.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tlabelTemplateCols.ltc_ID, (object) tlabelTemplateCols.ltc_Seq, (object) tlabelTemplateCols.ltc_SiteID) + " 내용 : " + tlabelTemplateCols.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tlabelTemplateCols.message);
      return false;
    }

    public virtual string DeleteQuery(long p_ltc_ID, int p_ltc_Seq, long p_ltc_SiteID = 0)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format(" DELETE FROM {0}{1} ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_IMAGES), (object) this.TableCode));
      stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "ltc_ID", (object) p_ltc_ID));
      stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ltc_Seq", (object) p_ltc_Seq));
      if (p_ltc_SiteID > 0L)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ltc_SiteID", (object) p_ltc_SiteID));
      return stringBuilder.ToString();
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "ltc_SiteID") && Convert.ToInt64(hashtable[(object) "ltc_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "ltc_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "ltc_ID") && Convert.ToInt64(hashtable[(object) "ltc_ID"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ltc_ID", hashtable[(object) "ltc_ID"]));
        if (hashtable.ContainsKey((object) "ltc_Seq") && Convert.ToInt32(hashtable[(object) "ltc_Seq"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ltc_Seq", hashtable[(object) "ltc_Seq"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ltc_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "ltc_ColID") && !string.IsNullOrEmpty(hashtable[(object) "ltc_ColID"].ToString()))
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "ltc_ColID", hashtable[(object) "ltc_ColID"]));
        if (hashtable.ContainsKey((object) "ltc_FormatDataID") && !string.IsNullOrEmpty(hashtable[(object) "ltc_FormatDataID"].ToString()))
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "ltc_FormatDataID", hashtable[(object) "ltc_FormatDataID"]));
        if (hashtable.ContainsKey((object) "ltc_Count") && Convert.ToInt32(hashtable[(object) "ltc_Count"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ltc_Count", hashtable[(object) "ltc_Count"]));
        if (hashtable.ContainsKey((object) "ltc_Point") && !string.IsNullOrEmpty(hashtable[(object) "ltc_Point"].ToString()))
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "ltc_Point", hashtable[(object) "ltc_Point"]));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "ltc_ColID", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "ltc_FormatDataID", hashtable[(object) "_KEY_WORD_"]));
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
        string uniImages = UbModelBase.UNI_IMAGES;
        string str = this.TableCode.ToString();
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniImages = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
          if (hashtable.ContainsKey((object) "IS_THUMB_IMAGE_VIEW") && Convert.ToBoolean(hashtable[(object) "IS_THUMB_IMAGE_VIEW"].ToString()))
            Convert.ToBoolean(hashtable[(object) "IS_THUMB_IMAGE_VIEW"].ToString());
          if (hashtable.ContainsKey((object) "IS_FILE_IMAGE_VIEW") && Convert.ToBoolean(hashtable[(object) "IS_FILE_IMAGE_VIEW"].ToString()))
            Convert.ToBoolean(hashtable[(object) "IS_FILE_IMAGE_VIEW"].ToString());
        }
        stringBuilder.Append(" SELECT  ltc_ID,ltc_Seq,ltc_SiteID,ltc_ColID,ltc_FormatDataID,ltc_Count,ltc_Point,ltc_InDate,ltc_ModDate FROM " + DbQueryHelper.ToDBNameBridge(uniImages) + str + " " + DbQueryHelper.ToWithNolock());
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
