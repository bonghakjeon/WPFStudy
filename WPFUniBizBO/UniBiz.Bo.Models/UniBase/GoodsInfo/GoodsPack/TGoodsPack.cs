// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsPack.TGoodsPack
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

namespace UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsPack
{
  public class TGoodsPack : UbModelBase<TGoodsPack>
  {
    private long _gdp_GoodsCode;
    private long _gdp_SubGoodsCode;
    private long _gdp_SiteID;
    private double _gdp_StockConvQty;
    private DateTime? _gdp_InDate;
    private int _gdp_InUser;
    private DateTime? _gdp_ModDate;
    private int _gdp_ModUser;

    public override object _Key => (object) new object[2]
    {
      (object) this.gdp_GoodsCode,
      (object) this.gdp_SubGoodsCode
    };

    public long gdp_GoodsCode
    {
      get => this._gdp_GoodsCode;
      set
      {
        this._gdp_GoodsCode = value;
        this.Changed(nameof (gdp_GoodsCode));
      }
    }

    public long gdp_SubGoodsCode
    {
      get => this._gdp_SubGoodsCode;
      set
      {
        this._gdp_SubGoodsCode = value;
        this.Changed(nameof (gdp_SubGoodsCode));
      }
    }

    public long gdp_SiteID
    {
      get => this._gdp_SiteID;
      set
      {
        this._gdp_SiteID = value;
        this.Changed(nameof (gdp_SiteID));
      }
    }

    public double gdp_StockConvQty
    {
      get => this._gdp_StockConvQty;
      set
      {
        this._gdp_StockConvQty = value;
        this.Changed(nameof (gdp_StockConvQty));
      }
    }

    public DateTime? gdp_InDate
    {
      get => this._gdp_InDate;
      set
      {
        this._gdp_InDate = value;
        this.Changed(nameof (gdp_InDate));
      }
    }

    public int gdp_InUser
    {
      get => this._gdp_InUser;
      set
      {
        this._gdp_InUser = value;
        this.Changed(nameof (gdp_InUser));
      }
    }

    public DateTime? gdp_ModDate
    {
      get => this._gdp_ModDate;
      set
      {
        this._gdp_ModDate = value;
        this.Changed(nameof (gdp_ModDate));
      }
    }

    public int gdp_ModUser
    {
      get => this._gdp_ModUser;
      set
      {
        this._gdp_ModUser = value;
        this.Changed(nameof (gdp_ModUser));
      }
    }

    public TGoodsPack() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("gdp_GoodsCode", new TTableColumn()
      {
        tc_orgin_name = "gdp_GoodsCode",
        tc_trans_name = "세트 상품"
      });
      columnInfo.Add("gdp_SubGoodsCode", new TTableColumn()
      {
        tc_orgin_name = "gdp_SubGoodsCode",
        tc_trans_name = "구성 상품"
      });
      columnInfo.Add("gdp_SiteID", new TTableColumn()
      {
        tc_orgin_name = "gdp_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("gdp_StockConvQty", new TTableColumn()
      {
        tc_orgin_name = "gdp_StockConvQty",
        tc_trans_name = "구성 입수량"
      });
      columnInfo.Add("gdp_InDate", new TTableColumn()
      {
        tc_orgin_name = "gdp_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("gdp_InUser", new TTableColumn()
      {
        tc_orgin_name = "gdp_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("gdp_ModDate", new TTableColumn()
      {
        tc_orgin_name = "gdp_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("gdp_ModUser", new TTableColumn()
      {
        tc_orgin_name = "gdp_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.GoodsPack;
      this.gdp_GoodsCode = this.gdp_SubGoodsCode = 0L;
      this.gdp_SiteID = 0L;
      this.gdp_StockConvQty = 0.0;
      this.gdp_InDate = new DateTime?();
      this.gdp_InUser = 0;
      this.gdp_ModDate = new DateTime?();
      this.gdp_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TGoodsPack();

    public override object Clone()
    {
      TGoodsPack tgoodsPack = base.Clone() as TGoodsPack;
      tgoodsPack.gdp_GoodsCode = this.gdp_GoodsCode;
      tgoodsPack.gdp_SubGoodsCode = this.gdp_SubGoodsCode;
      tgoodsPack.gdp_SiteID = this.gdp_SiteID;
      tgoodsPack.gdp_StockConvQty = this.gdp_StockConvQty;
      tgoodsPack.gdp_InDate = this.gdp_InDate;
      tgoodsPack.gdp_InUser = this.gdp_InUser;
      tgoodsPack.gdp_ModDate = this.gdp_ModDate;
      tgoodsPack.gdp_ModUser = this.gdp_ModUser;
      return (object) tgoodsPack;
    }

    public void PutData(TGoodsPack pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.gdp_GoodsCode = pSource.gdp_GoodsCode;
      this.gdp_SubGoodsCode = pSource.gdp_SubGoodsCode;
      this.gdp_SiteID = pSource.gdp_SiteID;
      this.gdp_StockConvQty = pSource.gdp_StockConvQty;
      this.gdp_InDate = pSource.gdp_InDate;
      this.gdp_InUser = pSource.gdp_InUser;
      this.gdp_ModDate = pSource.gdp_ModDate;
      this.gdp_ModUser = pSource.gdp_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.gdp_GoodsCode = p_rs.GetFieldLong("gdp_GoodsCode");
        if (this.gdp_GoodsCode == 0L)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.gdp_SubGoodsCode = p_rs.GetFieldLong("gdp_SubGoodsCode");
        this.gdp_SiteID = p_rs.GetFieldLong("gdp_SiteID");
        this.gdp_StockConvQty = p_rs.GetFieldDouble("gdp_StockConvQty");
        this.gdp_InDate = p_rs.GetFieldDateTime("gdp_InDate");
        this.gdp_InUser = p_rs.GetFieldInt("gdp_InUser");
        this.gdp_ModDate = p_rs.GetFieldDateTime("gdp_ModDate");
        this.gdp_ModUser = p_rs.GetFieldInt("gdp_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " gdp_GoodsCode,gdp_SubGoodsCode,gdp_SiteID,gdp_StockConvQty,gdp_InDate,gdp_InUser,gdp_ModDate,gdp_ModUser) VALUES ( " + string.Format(" {0},{1}", (object) this.gdp_GoodsCode, (object) this.gdp_SubGoodsCode) + string.Format(",{0}", (object) this.gdp_SiteID) + "," + this.gdp_StockConvQty.FormatTo("{0:0.0000}") + string.Format(",{0},{1}", (object) this.gdp_InDate.GetDateToStrInNull(), (object) this.gdp_InUser) + string.Format(",{0},{1}", (object) this.gdp_ModDate.GetDateToStrInNull(), (object) this.gdp_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.gdp_GoodsCode, (object) this.gdp_SubGoodsCode, (object) this.gdp_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TGoodsPack tgoodsPack = this;
      // ISSUE: reference to a compiler-generated method
      tgoodsPack.\u003C\u003En__0();
      if (await tgoodsPack.OleDB.ExecuteAsync(tgoodsPack.InsertQuery()))
        return true;
      tgoodsPack.message = " " + tgoodsPack.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tgoodsPack.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tgoodsPack.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tgoodsPack.gdp_GoodsCode, (object) tgoodsPack.gdp_SubGoodsCode, (object) tgoodsPack.gdp_SiteID) + " 내용 : " + tgoodsPack.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tgoodsPack.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " gdp_StockConvQty=" + this.gdp_StockConvQty.FormatTo("{0:0.0000}") + string.Format(",{0}={1},{2}={3}", (object) "gdp_ModDate", (object) this.gdp_ModDate.GetDateToStrInNull(), (object) "gdp_ModUser", (object) this.gdp_ModUser) + string.Format(" WHERE {0}={1}", (object) "gdp_GoodsCode", (object) this.gdp_GoodsCode) + string.Format(" AND {0}={1}", (object) "gdp_SubGoodsCode", (object) this.gdp_SubGoodsCode) + string.Format(" AND {0}={1}", (object) "gdp_SiteID", (object) this.gdp_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.gdp_GoodsCode, (object) this.gdp_SubGoodsCode, (object) this.gdp_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TGoodsPack tgoodsPack = this;
      // ISSUE: reference to a compiler-generated method
      tgoodsPack.\u003C\u003En__1();
      if (await tgoodsPack.OleDB.ExecuteAsync(tgoodsPack.UpdateQuery()))
        return true;
      tgoodsPack.message = " " + tgoodsPack.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tgoodsPack.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tgoodsPack.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tgoodsPack.gdp_GoodsCode, (object) tgoodsPack.gdp_SubGoodsCode, (object) tgoodsPack.gdp_SiteID) + " 내용 : " + tgoodsPack.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tgoodsPack.message);
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
      stringBuilder.Append(" gdp_StockConvQty=" + this.gdp_StockConvQty.FormatTo("{0:0.0000}") + string.Format(",{0}={1},{2}={3}", (object) "gdp_ModDate", (object) this.gdp_ModDate.GetDateToStrInNull(), (object) "gdp_ModUser", (object) this.gdp_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.gdp_GoodsCode, (object) this.gdp_SubGoodsCode, (object) this.gdp_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TGoodsPack tgoodsPack = this;
      // ISSUE: reference to a compiler-generated method
      tgoodsPack.\u003C\u003En__1();
      if (await tgoodsPack.OleDB.ExecuteAsync(tgoodsPack.UpdateExInsertQuery()))
        return true;
      tgoodsPack.message = " " + tgoodsPack.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tgoodsPack.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tgoodsPack.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tgoodsPack.gdp_GoodsCode, (object) tgoodsPack.gdp_SubGoodsCode, (object) tgoodsPack.gdp_SiteID) + " 내용 : " + tgoodsPack.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tgoodsPack.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "gdp_SiteID") && Convert.ToInt64(hashtable[(object) "gdp_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "gdp_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "gdp_GoodsCode") && Convert.ToInt64(hashtable[(object) "gdp_GoodsCode"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gdp_GoodsCode", hashtable[(object) "gdp_GoodsCode"]));
        if (hashtable.ContainsKey((object) "gdp_SubGoodsCode") && Convert.ToInt64(hashtable[(object) "gdp_SubGoodsCode"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gdp_SubGoodsCode", hashtable[(object) "gdp_SubGoodsCode"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gdp_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "gdp_StockConvQty데이터 0 제외") && Convert.ToBoolean(hashtable[(object) "gdp_StockConvQty데이터 0 제외"].ToString()))
          stringBuilder.Append(" AND gdp_StockConvQty > 0");
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_"))
        {
          int length = hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length;
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
        stringBuilder.Append(" SELECT  gdp_GoodsCode,gdp_SubGoodsCode,gdp_SiteID,gdp_StockConvQty,gdp_InDate,gdp_InUser,gdp_ModDate,gdp_ModUser");
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
