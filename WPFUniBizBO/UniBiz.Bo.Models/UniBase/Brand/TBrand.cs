// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Brand.TBrand
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

namespace UniBiz.Bo.Models.UniBase.Brand
{
  public class TBrand : UbModelBase<TBrand>
  {
    private int _br_BrandCode;
    private long _br_SiteID;
    private string _br_BrandName;
    private string _br_UseYn;
    private string _br_Memo;
    private int _br_AddProperty;
    private DateTime? _br_InDate;
    private int _br_InUser;
    private DateTime? _br_ModDate;
    private int _br_ModUser;

    public override object _Key => (object) new object[1]
    {
      (object) this.br_BrandCode
    };

    public int br_BrandCode
    {
      get => this._br_BrandCode;
      set
      {
        this._br_BrandCode = value;
        this.Changed(nameof (br_BrandCode));
      }
    }

    public long br_SiteID
    {
      get => this._br_SiteID;
      set
      {
        this._br_SiteID = value;
        this.Changed(nameof (br_SiteID));
      }
    }

    public string br_BrandName
    {
      get => this._br_BrandName;
      set
      {
        this._br_BrandName = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (br_BrandName));
      }
    }

    public string br_UseYn
    {
      get => this._br_UseYn;
      set
      {
        this._br_UseYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (br_UseYn));
        this.Changed("br_IsUseYn");
        this.Changed("br_UseYnDesc");
      }
    }

    public bool br_IsUseYn => "Y".Equals(this.br_UseYn);

    public string br_UseYnDesc => !"Y".Equals(this.br_UseYn) ? "미사용" : "사용";

    public string br_Memo
    {
      get => this._br_Memo;
      set
      {
        this._br_Memo = UbModelBase.LeftStr(value, 200).Replace("'", "´");
        this.Changed(nameof (br_Memo));
        this.Changed("br_MemoEnterSkip");
      }
    }

    public string br_MemoEnterSkip => this.br_Memo.Replace("\r\n", "↵").Replace("\n", "↵");

    public int br_AddProperty
    {
      get => this._br_AddProperty;
      set
      {
        this._br_AddProperty = value;
        this.Changed(nameof (br_AddProperty));
      }
    }

    public DateTime? br_InDate
    {
      get => this._br_InDate;
      set
      {
        this._br_InDate = value;
        this.Changed(nameof (br_InDate));
        this.Changed("ModDate");
      }
    }

    public int br_InUser
    {
      get => this._br_InUser;
      set
      {
        this._br_InUser = value;
        this.Changed(nameof (br_InUser));
      }
    }

    public DateTime? br_ModDate
    {
      get => this._br_ModDate;
      set
      {
        this._br_ModDate = value;
        this.Changed(nameof (br_ModDate));
        this.Changed("ModDate");
      }
    }

    public int br_ModUser
    {
      get => this._br_ModUser;
      set
      {
        this._br_ModUser = value;
        this.Changed(nameof (br_ModUser));
      }
    }

    public override DateTime? ModDate => !this.br_ModDate.HasValue ? this.br_InDate : this.br_ModDate;

    public TBrand() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("br_BrandCode", new TTableColumn()
      {
        tc_orgin_name = "br_BrandCode",
        tc_trans_name = "브랜드코드"
      });
      columnInfo.Add("br_SiteID", new TTableColumn()
      {
        tc_orgin_name = "br_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("br_BrandName", new TTableColumn()
      {
        tc_orgin_name = "br_BrandName",
        tc_trans_name = "브랜드명"
      });
      columnInfo.Add("br_UseYn", new TTableColumn()
      {
        tc_orgin_name = "br_UseYn",
        tc_trans_name = "사용상태"
      });
      columnInfo.Add("br_Memo", new TTableColumn()
      {
        tc_orgin_name = "br_Memo",
        tc_trans_name = "메모"
      });
      columnInfo.Add("br_AddProperty", new TTableColumn()
      {
        tc_orgin_name = "br_AddProperty",
        tc_trans_name = "속성타입"
      });
      columnInfo.Add("br_InDate", new TTableColumn()
      {
        tc_orgin_name = "br_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("br_InUser", new TTableColumn()
      {
        tc_orgin_name = "br_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("br_ModDate", new TTableColumn()
      {
        tc_orgin_name = "br_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("br_ModUser", new TTableColumn()
      {
        tc_orgin_name = "br_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.Brand;
      this.br_BrandCode = 0;
      this.br_SiteID = 0L;
      this.br_BrandName = string.Empty;
      this.br_UseYn = "Y";
      this.br_Memo = string.Empty;
      this.br_AddProperty = 0;
      this.br_InDate = new DateTime?();
      this.br_InUser = 0;
      this.br_ModDate = new DateTime?();
      this.br_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TBrand();

    public override object Clone()
    {
      TBrand tbrand = base.Clone() as TBrand;
      tbrand.br_BrandCode = this.br_BrandCode;
      tbrand.br_SiteID = this.br_SiteID;
      tbrand.br_BrandName = this.br_BrandName;
      tbrand.br_UseYn = this.br_UseYn;
      tbrand.br_Memo = this.br_Memo;
      tbrand.br_AddProperty = this.br_AddProperty;
      tbrand.br_InDate = this.br_InDate;
      tbrand.br_ModDate = this.br_ModDate;
      tbrand.br_InUser = this.br_InUser;
      tbrand.br_ModUser = this.br_ModUser;
      return (object) tbrand;
    }

    public void PutData(TBrand pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.br_BrandCode = pSource.br_BrandCode;
      this.br_SiteID = pSource.br_SiteID;
      this.br_BrandName = pSource.br_BrandName;
      this.br_UseYn = pSource.br_UseYn;
      this.br_Memo = pSource.br_Memo;
      this.br_AddProperty = pSource.br_AddProperty;
      this.br_InDate = pSource.br_InDate;
      this.br_ModDate = pSource.br_ModDate;
      this.br_InUser = pSource.br_InUser;
      this.br_ModUser = pSource.br_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.br_BrandCode = p_rs.GetFieldInt("br_BrandCode");
        if (this.br_BrandCode == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.br_SiteID = p_rs.GetFieldLong("br_SiteID");
        this.br_BrandName = p_rs.GetFieldString("br_BrandName");
        this.br_UseYn = p_rs.GetFieldString("br_UseYn");
        this.br_Memo = p_rs.GetFieldString("br_Memo");
        this.br_AddProperty = p_rs.GetFieldInt("br_AddProperty");
        this.br_InDate = p_rs.GetFieldDateTime("br_InDate");
        this.br_InUser = p_rs.GetFieldInt("br_InUser");
        this.br_ModDate = p_rs.GetFieldDateTime("br_ModDate");
        this.br_ModUser = p_rs.GetFieldInt("br_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " br_BrandCode,br_SiteID,br_BrandName,br_UseYn,br_Memo,br_AddProperty,br_InDate,br_InUser,br_ModDate,br_ModUser) VALUES ( " + string.Format(" {0}", (object) this.br_BrandCode) + string.Format(",{0}", (object) this.br_SiteID) + string.Format(",'{0}','{1}','{2}',{3}", (object) this.br_BrandName, (object) this.br_UseYn, (object) this.br_Memo, (object) this.br_AddProperty) + string.Format(",{0},{1}", (object) this.br_InDate.GetDateToStrInNull(), (object) this.br_InUser) + string.Format(",{0},{1}", (object) this.br_ModDate.GetDateToStrInNull(), (object) this.br_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.br_BrandCode, (object) this.br_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TBrand tbrand = this;
      // ISSUE: reference to a compiler-generated method
      tbrand.\u003C\u003En__0();
      if (await tbrand.OleDB.ExecuteAsync(tbrand.InsertQuery()))
        return true;
      tbrand.message = " " + tbrand.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tbrand.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tbrand.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tbrand.br_BrandCode, (object) tbrand.br_SiteID) + " 내용 : " + tbrand.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tbrand.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " br_BrandName='" + this.br_BrandName + "',br_UseYn='" + this.br_UseYn + "',br_Memo='" + this.br_Memo + "'" + string.Format(",{0}={1}", (object) "br_AddProperty", (object) this.br_AddProperty) + string.Format(",{0}={1},{2}={3}", (object) "br_ModDate", (object) this.br_ModDate.GetDateToStrInNull(), (object) "br_ModUser", (object) this.br_ModUser) + string.Format(" WHERE {0}={1}", (object) "br_BrandCode", (object) this.br_BrandCode) + string.Format(" AND {0}={1}", (object) "br_SiteID", (object) this.br_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.br_BrandCode, (object) this.br_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TBrand tbrand = this;
      // ISSUE: reference to a compiler-generated method
      tbrand.\u003C\u003En__1();
      if (await tbrand.OleDB.ExecuteAsync(tbrand.UpdateQuery()))
        return true;
      tbrand.message = " " + tbrand.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tbrand.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tbrand.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tbrand.br_BrandCode, (object) tbrand.br_SiteID) + " 내용 : " + tbrand.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tbrand.message);
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
      stringBuilder.Append(" br_BrandName='" + this.br_BrandName + "',br_UseYn='" + this.br_UseYn + "',br_Memo='" + this.br_Memo + "'" + string.Format(",{0}={1}", (object) "br_AddProperty", (object) this.br_AddProperty) + string.Format(",{0}={1},{2}={3}", (object) "br_ModDate", (object) this.br_ModDate.GetDateToStrInNull(), (object) "br_ModUser", (object) this.br_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.br_BrandCode, (object) this.br_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TBrand tbrand = this;
      // ISSUE: reference to a compiler-generated method
      tbrand.\u003C\u003En__1();
      if (await tbrand.OleDB.ExecuteAsync(tbrand.UpdateExInsertQuery()))
        return true;
      tbrand.message = " " + tbrand.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tbrand.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tbrand.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tbrand.br_BrandCode, (object) tbrand.br_SiteID) + " 내용 : " + tbrand.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tbrand.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "br_SiteID") && Convert.ToInt64(hashtable[(object) "br_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "br_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "br_BrandCode") && Convert.ToInt32(hashtable[(object) "br_BrandCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "br_BrandCode", hashtable[(object) "br_BrandCode"]));
        else
          stringBuilder.Append(" AND br_BrandCode>0");
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "br_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "br_BrandName") && hashtable[(object) "br_BrandName"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "br_BrandName", hashtable[(object) "br_BrandName"]));
        if (hashtable.ContainsKey((object) "br_UseYn") && hashtable[(object) "br_UseYn"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "br_UseYn", hashtable[(object) "br_UseYn"]));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "br_BrandName", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "br_Memo", hashtable[(object) "_KEY_WORD_"]));
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
        stringBuilder.Append(" SELECT  br_BrandCode,br_SiteID,br_BrandName,br_UseYn,br_Memo,br_AddProperty,br_InDate,br_InUser,br_ModDate,br_ModUser");
        stringBuilder.Append(" FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock());
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
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
