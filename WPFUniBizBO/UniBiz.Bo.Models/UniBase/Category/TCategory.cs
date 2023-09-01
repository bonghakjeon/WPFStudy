// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Category.TCategory
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
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniBase.Category
{
  public class TCategory : UbModelBase<TCategory>
  {
    private int _ctg_ID;
    private long _ctg_SiteID;
    private string _ctg_CategoryName;
    private string _ctg_ViewCode;
    private string _ctg_Memo;
    private string _ctg_UseYn;
    private int _ctg_Depth;
    private int _ctg_ParentsID;
    private string _ctg_DepositYn;
    private int _ctg_AddProperty;
    private DateTime? _ctg_InDate;
    private int _ctg_InUser;
    private DateTime? _ctg_ModDate;
    private int _ctg_ModUser;

    public override object _Key => (object) new object[1]
    {
      (object) this.ctg_ID
    };

    public int ctg_ID
    {
      get => this._ctg_ID;
      set
      {
        this._ctg_ID = value;
        this.Changed(nameof (ctg_ID));
        this.Changed("ctg_lv3_ID");
      }
    }

    [JsonIgnore]
    public int ctg_lv3_ID => this.ctg_Depth != 3 ? 0 : this.ctg_ID;

    public long ctg_SiteID
    {
      get => this._ctg_SiteID;
      set
      {
        this._ctg_SiteID = value;
        this.Changed(nameof (ctg_SiteID));
      }
    }

    public string ctg_CategoryName
    {
      get => this._ctg_CategoryName;
      set
      {
        this._ctg_CategoryName = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (ctg_CategoryName));
        this.Changed("ctg_lv3_Name");
      }
    }

    [JsonIgnore]
    public string ctg_lv3_Name => this.ctg_Depth != 3 ? string.Empty : this.ctg_CategoryName;

    public string ctg_ViewCode
    {
      get => this._ctg_ViewCode;
      set
      {
        this._ctg_ViewCode = UbModelBase.LeftStr(value, 10).Replace("'", "´");
        this.Changed(nameof (ctg_ViewCode));
        this.Changed("ctg_lv3_ViewCode");
      }
    }

    [JsonIgnore]
    public string ctg_lv3_ViewCode => this.ctg_Depth != 3 ? string.Empty : this.ctg_ViewCode;

    public string ctg_Memo
    {
      get => this._ctg_Memo;
      set
      {
        this._ctg_Memo = UbModelBase.LeftStr(value, 200).Replace("'", "´");
        this.Changed(nameof (ctg_Memo));
      }
    }

    public string ctg_UseYn
    {
      get => this._ctg_UseYn;
      set
      {
        this._ctg_UseYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (ctg_UseYn));
        this.Changed("ctg_IsUseYn");
        this.Changed("ctg_UseYnDesc");
      }
    }

    public bool ctg_IsUseYn => "Y".Equals(this.ctg_UseYn);

    public string ctg_UseYnDesc => !"Y".Equals(this.ctg_UseYn) ? "미사용" : "사용";

    public int ctg_Depth
    {
      get => this._ctg_Depth;
      set
      {
        this._ctg_Depth = value;
        this.Changed(nameof (ctg_Depth));
        this.Changed("ctg_DepthDesc");
        this.Changed("ctg_lv3_ID");
        this.Changed("ctg_lv3_Name");
        this.Changed("ctg_lv3_ViewCode");
      }
    }

    public string ctg_DepthDesc => this.ctg_Depth != 0 ? Enum2StrConverter.ToCategoryDepth(this.ctg_Depth).ToDescription() : string.Empty;

    public int ctg_ParentsID
    {
      get => this._ctg_ParentsID;
      set
      {
        this._ctg_ParentsID = value;
        this.Changed(nameof (ctg_ParentsID));
        this.Changed("ctg_DepthDesc");
      }
    }

    public string ctg_DepositYn
    {
      get => this._ctg_DepositYn;
      set
      {
        this._ctg_DepositYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (ctg_DepositYn));
        this.Changed("ctg_IsDepositYn");
        this.Changed("ctg_DepositYnDesc");
      }
    }

    public bool ctg_IsDepositYn => "Y".Equals(this.ctg_DepositYn);

    public string ctg_DepositYnDesc => !"Y".Equals(this.ctg_DepositYn) ? "미사용" : "사용";

    public int ctg_AddProperty
    {
      get => this._ctg_AddProperty;
      set
      {
        this._ctg_AddProperty = value;
        this.Changed(nameof (ctg_AddProperty));
      }
    }

    public DateTime? ctg_InDate
    {
      get => this._ctg_InDate;
      set
      {
        this._ctg_InDate = value;
        this.Changed(nameof (ctg_InDate));
      }
    }

    public int ctg_InUser
    {
      get => this._ctg_InUser;
      set
      {
        this._ctg_InUser = value;
        this.Changed(nameof (ctg_InUser));
      }
    }

    public DateTime? ctg_ModDate
    {
      get => this._ctg_ModDate;
      set
      {
        this._ctg_ModDate = value;
        this.Changed(nameof (ctg_ModDate));
      }
    }

    public int ctg_ModUser
    {
      get => this._ctg_ModUser;
      set
      {
        this._ctg_ModUser = value;
        this.Changed(nameof (ctg_ModUser));
      }
    }

    public TCategory() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("ctg_ID", new TTableColumn()
      {
        tc_orgin_name = "ctg_ID",
        tc_trans_name = "분류ID"
      });
      columnInfo.Add("ctg_SiteID", new TTableColumn()
      {
        tc_orgin_name = "ctg_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("ctg_CategoryName", new TTableColumn()
      {
        tc_orgin_name = "ctg_CategoryName",
        tc_trans_name = "소분류명"
      });
      columnInfo.Add("ctg_ViewCode", new TTableColumn()
      {
        tc_orgin_name = "ctg_ViewCode",
        tc_trans_name = "소분류코드"
      });
      columnInfo.Add("ctg_Memo", new TTableColumn()
      {
        tc_orgin_name = "ctg_Memo",
        tc_trans_name = "분류설명"
      });
      columnInfo.Add("ctg_UseYn", new TTableColumn()
      {
        tc_orgin_name = "ctg_UseYn",
        tc_trans_name = "사용상태"
      });
      columnInfo.Add("ctg_Depth", new TTableColumn()
      {
        tc_orgin_name = "ctg_Depth",
        tc_trans_name = "분류단계",
        tc_comm_code = 39
      });
      columnInfo.Add("ctg_ParentsID", new TTableColumn()
      {
        tc_orgin_name = "ctg_ParentsID",
        tc_trans_name = "상위분류"
      });
      columnInfo.Add("ctg_DepositYn", new TTableColumn()
      {
        tc_orgin_name = "ctg_DepositYn",
        tc_trans_name = "저장품"
      });
      columnInfo.Add("ctg_AddProperty", new TTableColumn()
      {
        tc_orgin_name = "ctg_AddProperty",
        tc_trans_name = "속성타입"
      });
      columnInfo.Add("ctg_InDate", new TTableColumn()
      {
        tc_orgin_name = "ctg_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("ctg_InUser", new TTableColumn()
      {
        tc_orgin_name = "ctg_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("ctg_ModDate", new TTableColumn()
      {
        tc_orgin_name = "ctg_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("ctg_ModUser", new TTableColumn()
      {
        tc_orgin_name = "ctg_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.Category;
      this.ctg_ID = 0;
      this.ctg_SiteID = 0L;
      this.ctg_CategoryName = string.Empty;
      this.ctg_ViewCode = string.Empty;
      this.ctg_Memo = string.Empty;
      this.ctg_UseYn = "Y";
      this.ctg_DepositYn = "N";
      this.ctg_Depth = this.ctg_ParentsID = 0;
      this.ctg_AddProperty = 0;
      this.ctg_InDate = new DateTime?();
      this.ctg_InUser = 0;
      this.ctg_ModDate = new DateTime?();
      this.ctg_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TCategory();

    public override object Clone()
    {
      TCategory tcategory = base.Clone() as TCategory;
      tcategory.ctg_ID = this.ctg_ID;
      tcategory.ctg_SiteID = this.ctg_SiteID;
      tcategory.ctg_CategoryName = this.ctg_CategoryName;
      tcategory.ctg_ViewCode = this.ctg_ViewCode;
      tcategory.ctg_Memo = this.ctg_Memo;
      tcategory.ctg_UseYn = this.ctg_UseYn;
      tcategory.ctg_Depth = this.ctg_Depth;
      tcategory.ctg_ParentsID = this.ctg_ParentsID;
      tcategory.ctg_DepositYn = this.ctg_DepositYn;
      tcategory.ctg_AddProperty = this.ctg_AddProperty;
      tcategory.ctg_InDate = this.ctg_InDate;
      tcategory.ctg_ModDate = this.ctg_ModDate;
      tcategory.ctg_InUser = this.ctg_InUser;
      tcategory.ctg_ModUser = this.ctg_ModUser;
      return (object) tcategory;
    }

    public void PutData(TCategory pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.ctg_ID = pSource.ctg_ID;
      this.ctg_SiteID = pSource.ctg_SiteID;
      this.ctg_CategoryName = pSource.ctg_CategoryName;
      this.ctg_ViewCode = pSource.ctg_ViewCode;
      this.ctg_Memo = pSource.ctg_Memo;
      this.ctg_UseYn = pSource.ctg_UseYn;
      this.ctg_Depth = pSource.ctg_Depth;
      this.ctg_ParentsID = pSource.ctg_ParentsID;
      this.ctg_DepositYn = pSource.ctg_DepositYn;
      this.ctg_AddProperty = pSource.ctg_AddProperty;
      this.ctg_InDate = pSource.ctg_InDate;
      this.ctg_ModDate = pSource.ctg_ModDate;
      this.ctg_InUser = pSource.ctg_InUser;
      this.ctg_ModUser = pSource.ctg_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.ctg_ID = p_rs.GetFieldInt("ctg_ID");
        if (this.ctg_ID == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.ctg_SiteID = p_rs.GetFieldLong("ctg_SiteID");
        this.ctg_CategoryName = p_rs.GetFieldString("ctg_CategoryName");
        this.ctg_ViewCode = p_rs.GetFieldString("ctg_ViewCode");
        this.ctg_Memo = p_rs.GetFieldString("ctg_Memo");
        this.ctg_UseYn = p_rs.GetFieldString("ctg_UseYn");
        this.ctg_DepositYn = p_rs.GetFieldString("ctg_DepositYn");
        this.ctg_Depth = p_rs.GetFieldInt("ctg_Depth");
        this.ctg_ParentsID = p_rs.GetFieldInt("ctg_ParentsID");
        this.ctg_AddProperty = p_rs.GetFieldInt("ctg_AddProperty");
        this.ctg_InDate = p_rs.GetFieldDateTime("ctg_InDate");
        this.ctg_InUser = p_rs.GetFieldInt("ctg_InUser");
        this.ctg_ModDate = p_rs.GetFieldDateTime("ctg_ModDate");
        this.ctg_ModUser = p_rs.GetFieldInt("ctg_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " ctg_ID,ctg_SiteID,ctg_CategoryName,ctg_ViewCode,ctg_Memo,ctg_UseYn,ctg_DepositYn,ctg_Depth,ctg_ParentsID,ctg_AddProperty,ctg_InDate,ctg_InUser,ctg_ModDate,ctg_ModUser) VALUES ( " + string.Format(" {0}", (object) this.ctg_ID) + string.Format(",{0}", (object) this.ctg_SiteID) + ",'" + this.ctg_CategoryName + "','" + this.ctg_ViewCode + "','" + this.ctg_Memo + "','" + this.ctg_UseYn + "','" + this.ctg_DepositYn + "'" + string.Format(",{0},{1},{2}", (object) this.ctg_Depth, (object) this.ctg_ParentsID, (object) this.ctg_AddProperty) + string.Format(",{0},{1}", (object) this.ctg_InDate.GetDateToStrInNull(), (object) this.ctg_InUser) + string.Format(",{0},{1}", (object) this.ctg_ModDate.GetDateToStrInNull(), (object) this.ctg_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.ctg_ID, (object) this.ctg_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TCategory tcategory = this;
      // ISSUE: reference to a compiler-generated method
      tcategory.\u003C\u003En__0();
      if (await tcategory.OleDB.ExecuteAsync(tcategory.InsertQuery()))
        return true;
      tcategory.message = " " + tcategory.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tcategory.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tcategory.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tcategory.ctg_ID, (object) tcategory.ctg_SiteID) + " 내용 : " + tcategory.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tcategory.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " ctg_CategoryName='" + this.ctg_CategoryName + "',ctg_ViewCode='" + this.ctg_ViewCode + "',ctg_Memo='" + this.ctg_Memo + "',ctg_UseYn='" + this.ctg_UseYn + "',ctg_DepositYn='" + this.ctg_DepositYn + "'" + string.Format(",{0}={1},{2}={3},{4}={5}", (object) "ctg_Depth", (object) this.ctg_Depth, (object) "ctg_ParentsID", (object) this.ctg_ParentsID, (object) "ctg_AddProperty", (object) this.ctg_AddProperty) + string.Format(",{0}={1},{2}={3}", (object) "ctg_ModDate", (object) this.ctg_ModDate.GetDateToStrInNull(), (object) "ctg_ModUser", (object) this.ctg_ModUser) + string.Format(" WHERE {0}={1}", (object) "ctg_ID", (object) this.ctg_ID) + string.Format(" AND {0}={1}", (object) "ctg_SiteID", (object) this.ctg_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.ctg_ID, (object) this.ctg_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TCategory tcategory = this;
      // ISSUE: reference to a compiler-generated method
      tcategory.\u003C\u003En__1();
      if (await tcategory.OleDB.ExecuteAsync(tcategory.UpdateQuery()))
        return true;
      tcategory.message = " " + tcategory.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tcategory.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tcategory.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tcategory.ctg_ID, (object) tcategory.ctg_SiteID) + " 내용 : " + tcategory.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tcategory.message);
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
      stringBuilder.Append(" ctg_CategoryName='" + this.ctg_CategoryName + "',ctg_ViewCode='" + this.ctg_ViewCode + "',ctg_Memo='" + this.ctg_Memo + "',ctg_UseYn='" + this.ctg_UseYn + "',ctg_DepositYn='" + this.ctg_DepositYn + "'" + string.Format(",{0}={1},{2}={3},{4}={5}", (object) "ctg_Depth", (object) this.ctg_Depth, (object) "ctg_ParentsID", (object) this.ctg_ParentsID, (object) "ctg_AddProperty", (object) this.ctg_AddProperty) + string.Format(",{0}={1},{2}={3}", (object) "ctg_ModDate", (object) this.ctg_ModDate.GetDateToStrInNull(), (object) "ctg_ModUser", (object) this.ctg_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.ctg_ID, (object) this.ctg_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TCategory tcategory = this;
      // ISSUE: reference to a compiler-generated method
      tcategory.\u003C\u003En__1();
      if (await tcategory.OleDB.ExecuteAsync(tcategory.UpdateExInsertQuery()))
        return true;
      tcategory.message = " " + tcategory.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tcategory.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tcategory.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tcategory.ctg_ID, (object) tcategory.ctg_SiteID) + " 내용 : " + tcategory.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tcategory.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "ctg_SiteID") && Convert.ToInt64(hashtable[(object) "ctg_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "ctg_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "ctg_ID") && Convert.ToInt32(hashtable[(object) "ctg_ID"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ctg_ID", hashtable[(object) "ctg_ID"]));
        if (hashtable.ContainsKey((object) "ctg_ID_IN_") && hashtable[(object) "ctg_ID_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "ctg_ID", hashtable[(object) "ctg_ID_IN_"]));
        else
          stringBuilder.Append(" AND ctg_ID>0");
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ctg_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "ctg_ViewCode") && hashtable[(object) "ctg_ViewCode"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "ctg_ViewCode", hashtable[(object) "ctg_ViewCode"]));
        if (hashtable.ContainsKey((object) "ctg_ViewCode_IN_") && hashtable[(object) "ctg_ViewCode_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "ctg_ViewCode", hashtable[(object) "ctg_ViewCode_IN_"]));
        if (hashtable.ContainsKey((object) "ctg_CategoryName") && hashtable[(object) "ctg_CategoryName"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "ctg_CategoryName", hashtable[(object) "ctg_CategoryName"]));
        if (hashtable.ContainsKey((object) "ctg_UseYn") && hashtable[(object) "ctg_UseYn"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "ctg_UseYn", hashtable[(object) "ctg_UseYn"]));
        if (hashtable.ContainsKey((object) "ctg_DepositYn") && hashtable[(object) "ctg_DepositYn"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "ctg_DepositYn", hashtable[(object) "ctg_DepositYn"]));
        if (hashtable.ContainsKey((object) "ctg_Depth") && Convert.ToInt32(hashtable[(object) "ctg_Depth"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ctg_Depth", hashtable[(object) "ctg_Depth"]));
        if (hashtable.ContainsKey((object) "ctg_ParentsID") && Convert.ToInt32(hashtable[(object) "ctg_ParentsID"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ctg_ParentsID", hashtable[(object) "ctg_ParentsID"]));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "ctg_CategoryName", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "ctg_Memo", hashtable[(object) "_KEY_WORD_"]));
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
        stringBuilder.Append(" SELECT  ctg_ID,ctg_SiteID,ctg_CategoryName,ctg_ViewCode,ctg_Memo,ctg_UseYn,ctg_DepositYn,ctg_Depth,ctg_ParentsID,ctg_AddProperty,ctg_InDate,ctg_InUser,ctg_ModDate,ctg_ModUser");
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
