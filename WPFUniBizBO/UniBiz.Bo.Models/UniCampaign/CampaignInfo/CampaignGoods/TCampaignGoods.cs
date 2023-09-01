// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniCampaign.CampaignInfo.CampaignGoods.TCampaignGoods
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

namespace UniBiz.Bo.Models.UniCampaign.CampaignInfo.CampaignGoods
{
  public class TCampaignGoods : UbModelBase<TCampaignGoods>
  {
    private long _cig_CampaignCode;
    private int _cig_CodeType;
    private long _cig_GoodsCode;
    private long _cig_SiteID;
    private DateTime? _cig_InDate;
    private int _cig_InUser;
    private DateTime? _cig_ModDate;
    private int _cig_ModUser;

    public override object _Key => (object) new object[3]
    {
      (object) this.cig_CampaignCode,
      (object) this.cig_CodeType,
      (object) this.cig_GoodsCode
    };

    public long cig_CampaignCode
    {
      get => this._cig_CampaignCode;
      set
      {
        this._cig_CampaignCode = value;
        this.Changed(nameof (cig_CampaignCode));
      }
    }

    public int cig_CodeType
    {
      get => this._cig_CodeType;
      set
      {
        this._cig_CodeType = value;
        this.Changed(nameof (cig_CodeType));
        this.Changed("cig_CodeTypeDesc");
      }
    }

    public string cig_CodeTypeDesc => this.cig_CodeType != 0 ? Enum2StrConverter.ToCampaignTargetCodeType(this.cig_CodeType).ToDescription() : string.Empty;

    public long cig_GoodsCode
    {
      get => this._cig_GoodsCode;
      set
      {
        this._cig_GoodsCode = value;
        this.Changed(nameof (cig_GoodsCode));
      }
    }

    public long cig_SiteID
    {
      get => this._cig_SiteID;
      set
      {
        this._cig_SiteID = value;
        this.Changed(nameof (cig_SiteID));
      }
    }

    public DateTime? cig_InDate
    {
      get => this._cig_InDate;
      set
      {
        this._cig_InDate = value;
        this.Changed(nameof (cig_InDate));
      }
    }

    public int cig_InUser
    {
      get => this._cig_InUser;
      set
      {
        this._cig_InUser = value;
        this.Changed(nameof (cig_InUser));
      }
    }

    public DateTime? cig_ModDate
    {
      get => this._cig_ModDate;
      set
      {
        this._cig_ModDate = value;
        this.Changed(nameof (cig_ModDate));
      }
    }

    public int cig_ModUser
    {
      get => this._cig_ModUser;
      set
      {
        this._cig_ModUser = value;
        this.Changed(nameof (cig_ModUser));
      }
    }

    public override DateTime? ModDate => this.cig_ModDate ?? (this.cig_ModDate = this.cig_InDate);

    public TCampaignGoods() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("cig_CampaignCode", new TTableColumn()
      {
        tc_orgin_name = "cig_CampaignCode",
        tc_trans_name = "캠페인코드"
      });
      columnInfo.Add("cig_CodeType", new TTableColumn()
      {
        tc_orgin_name = "cig_CodeType",
        tc_trans_name = "코드타입",
        tc_comm_code = 232
      });
      columnInfo.Add("cig_GoodsCode", new TTableColumn()
      {
        tc_orgin_name = "cig_GoodsCode",
        tc_trans_name = "대상코드"
      });
      columnInfo.Add("cig_SiteID", new TTableColumn()
      {
        tc_orgin_name = "cig_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("cig_InDate", new TTableColumn()
      {
        tc_orgin_name = "cig_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("cig_InUser", new TTableColumn()
      {
        tc_orgin_name = "cig_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("cig_ModDate", new TTableColumn()
      {
        tc_orgin_name = "cig_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("cig_ModUser", new TTableColumn()
      {
        tc_orgin_name = "cig_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.CampaignGoods;
      this.cig_CampaignCode = 0L;
      this.cig_CodeType = 0;
      this.cig_GoodsCode = 0L;
      this.cig_SiteID = 0L;
      this.cig_InDate = new DateTime?();
      this.cig_InUser = 0;
      this.cig_ModDate = new DateTime?();
      this.cig_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TCampaignGoods();

    public override object Clone()
    {
      TCampaignGoods tcampaignGoods = base.Clone() as TCampaignGoods;
      tcampaignGoods.cig_CampaignCode = this.cig_CampaignCode;
      tcampaignGoods.cig_CodeType = this.cig_CodeType;
      tcampaignGoods.cig_GoodsCode = this.cig_GoodsCode;
      tcampaignGoods.cig_SiteID = this.cig_SiteID;
      tcampaignGoods.cig_InDate = this.cig_InDate;
      tcampaignGoods.cig_InUser = this.cig_InUser;
      tcampaignGoods.cig_ModDate = this.cig_ModDate;
      tcampaignGoods.cig_ModUser = this.cig_ModUser;
      return (object) tcampaignGoods;
    }

    public void PutData(TCampaignGoods pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.cig_CampaignCode = pSource.cig_CampaignCode;
      this.cig_CodeType = pSource.cig_CodeType;
      this.cig_GoodsCode = pSource.cig_GoodsCode;
      this.cig_SiteID = pSource.cig_SiteID;
      this.cig_InDate = pSource.cig_InDate;
      this.cig_InUser = pSource.cig_InUser;
      this.cig_ModDate = pSource.cig_ModDate;
      this.cig_ModUser = pSource.cig_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.cig_CampaignCode = p_rs.GetFieldLong("cig_CampaignCode");
        if (this.cig_CampaignCode == 0L)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.cig_CodeType = p_rs.GetFieldInt("cig_CodeType");
        this.cig_GoodsCode = p_rs.GetFieldLong("cig_GoodsCode");
        this.cig_SiteID = p_rs.GetFieldLong("cig_SiteID");
        this.cig_InDate = p_rs.GetFieldDateTime("cig_InDate");
        this.cig_InUser = p_rs.GetFieldInt("cig_InUser");
        this.cig_ModDate = p_rs.GetFieldDateTime("cig_ModDate");
        this.cig_ModUser = p_rs.GetFieldInt("cig_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_CAMPANIGN), (object) this.TableCode) + " cig_CampaignCode,cig_CodeType,cig_GoodsCode,cig_SiteID,cig_InDate,cig_InUser,cig_ModDate,cig_ModUser) VALUES ( " + string.Format(" {0},{1},{2}", (object) this.cig_CampaignCode, (object) this.cig_CodeType, (object) this.cig_GoodsCode) + string.Format(",{0}", (object) this.cig_SiteID) + string.Format(",{0},{1}", (object) this.cig_InDate.GetDateToStrInNull(), (object) this.cig_InUser) + string.Format(",{0},{1}", (object) this.cig_ModDate.GetDateToStrInNull(), (object) this.cig_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.cig_CampaignCode, (object) this.cig_CodeType, (object) this.cig_GoodsCode, (object) this.cig_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TCampaignGoods tcampaignGoods = this;
      // ISSUE: reference to a compiler-generated method
      tcampaignGoods.\u003C\u003En__0();
      if (await tcampaignGoods.OleDB.ExecuteAsync(tcampaignGoods.InsertQuery()))
        return true;
      tcampaignGoods.message = " " + tcampaignGoods.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tcampaignGoods.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tcampaignGoods.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tcampaignGoods.cig_CampaignCode, (object) tcampaignGoods.cig_CodeType, (object) tcampaignGoods.cig_GoodsCode, (object) tcampaignGoods.cig_SiteID) + " 내용 : " + tcampaignGoods.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tcampaignGoods.message);
      return false;
    }

    public override string DeleteQuery() => string.Format(" DELETE FROM {0}{1}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_CAMPANIGN), (object) this.TableCode) + string.Format(" WHERE {0}={1}", (object) "cig_CampaignCode", (object) this.cig_CampaignCode) + string.Format(" AND {0}={1}", (object) "cig_CodeType", (object) this.cig_CodeType) + string.Format(" AND {0}={1}", (object) "cig_GoodsCode", (object) this.cig_GoodsCode) + string.Format(" AND {0}={1}", (object) "cig_SiteID", (object) this.cig_SiteID);

    public override bool Delete()
    {
      this.InsertChecked();
      string pStrExec = this.DeleteQuery();
      if (this.OleDB.Execute(pStrExec))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 삭제 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.cig_CampaignCode, (object) this.cig_CodeType, (object) this.cig_GoodsCode, (object) this.cig_SiteID) + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n 쿼리 : " + pStrExec + "\n--------------------------------------------------------------------------------------------------\n";
      return false;
    }

    public override async Task<bool> DeleteAsync()
    {
      TCampaignGoods tcampaignGoods = this;
      // ISSUE: reference to a compiler-generated method
      tcampaignGoods.\u003C\u003En__0();
      if (await tcampaignGoods.OleDB.ExecuteAsync(tcampaignGoods.DeleteQuery()))
        return true;
      tcampaignGoods.message = " " + tcampaignGoods.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tcampaignGoods.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tcampaignGoods.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tcampaignGoods.cig_CampaignCode, (object) tcampaignGoods.cig_CodeType, (object) tcampaignGoods.cig_GoodsCode, (object) tcampaignGoods.cig_SiteID) + " 내용 : " + tcampaignGoods.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tcampaignGoods.message);
      return false;
    }

    public virtual string DeleteQuery(
      long p_cig_CampaignCode,
      int p_cig_CodeType,
      long p_cig_GoodsCode,
      long p_cig_SiteID = 0)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format(" DELETE FROM {0}{1} ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_CAMPANIGN), (object) this.TableCode));
      stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "cig_CampaignCode", (object) p_cig_CampaignCode));
      stringBuilder.Append(string.Format(" AND {0}={1}", (object) "cig_CodeType", (object) p_cig_CodeType));
      stringBuilder.Append(string.Format(" AND {0}={1}", (object) "cig_GoodsCode", (object) p_cig_GoodsCode));
      if (p_cig_SiteID > 0L)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "cig_SiteID", (object) p_cig_SiteID));
      return stringBuilder.ToString();
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "cig_SiteID") && Convert.ToInt64(hashtable[(object) "cig_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "cig_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "cig_CampaignCode") && Convert.ToInt64(hashtable[(object) "cig_CampaignCode"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "cig_CampaignCode", hashtable[(object) "cig_CampaignCode"]));
        if (hashtable.ContainsKey((object) "cig_CodeType") && Convert.ToInt32(hashtable[(object) "cig_CodeType"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "cig_CodeType", hashtable[(object) "cig_CodeType"]));
        if (hashtable.ContainsKey((object) "cig_GoodsCode") && Convert.ToInt64(hashtable[(object) "cig_GoodsCode"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "cig_GoodsCode", hashtable[(object) "cig_GoodsCode"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "cig_SiteID", (object) num));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_"))
          string.IsNullOrEmpty(hashtable[(object) "_KEY_WORD_"].ToString());
      }
      return !stringBuilder.ToString().Equals(" WHERE") ? stringBuilder.Replace("WHERE AND", "WHERE").ToString() : string.Empty;
    }

    public override string GetSelectQuery(object p_param)
    {
      StringBuilder stringBuilder = new StringBuilder();
      try
      {
        string uniCampanign = UbModelBase.UNI_CAMPANIGN;
        string str = this.TableCode.ToString();
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniCampanign = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
        }
        stringBuilder.Append(" SELECT  cig_CampaignCode,cig_CodeType,cig_GoodsCode,cig_SiteID,cig_InDate,cig_InUser,cig_ModDate,cig_ModUser");
        stringBuilder.Append(" FROM " + DbQueryHelper.ToDBNameBridge(uniCampanign) + str + " " + DbQueryHelper.ToWithNolock());
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
