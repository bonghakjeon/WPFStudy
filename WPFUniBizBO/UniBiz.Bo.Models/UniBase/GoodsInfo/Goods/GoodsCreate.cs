// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.GoodsInfo.Goods.GoodsCreate
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
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.Interface;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniBase.GoodsInfo.Goods
{
  public class GoodsCreate : TGoods, ICreateTable
  {
    public static string CreateTableQuery()
    {
      string tableQuery;
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          tableQuery = GoodsCreate.CreateTableMsSql();
          break;
        case EnumDB.MYSQL:
          tableQuery = GoodsCreate.CreateTableMySql();
          break;
        default:
          tableQuery = string.Empty;
          break;
      }
      return tableQuery;
    }

    public static string CreateTableMsSql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_BASE, (object) TableCodeType.Goods) + " gd_GoodsCode BIGINT NOT NULL,gd_SiteID BIGINT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "gd_GoodsName", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "gd_BarCode", (object) 40) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "gd_GoodsSize", (object) 100) + ",gd_TaxDiv INT NOT NULL DEFAULT(0),gd_MakerCode INT NOT NULL DEFAULT(0),gd_BrandCode INT NOT NULL DEFAULT(0),gd_BoxGoodsCode BIGINT NOT NULL DEFAULT(0),gd_BoxPackQty MONEY NOT NULL DEFAULT(0.0000),gd_Deposit INT NOT NULL DEFAULT(0),gd_SalesUnit INT NOT NULL DEFAULT(0),gd_MinOrderUnit MONEY NOT NULL DEFAULT(0.0000),gd_StockUnit INT NOT NULL DEFAULT(0),gd_StockConvQty MONEY NOT NULL DEFAULT(0.0000),gd_PackUnit INT NOT NULL DEFAULT(0),gd_AbcValue INT NOT NULL DEFAULT(0),gd_StorageDiv INT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('{2}')", (object) "gd_EachDeliveryYn", (object) 1, (object) "Y") + ",gd_VolumeTotal INT NOT NULL DEFAULT(0),gd_VolumeUnit INT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "gd_VolumeUnitText", (object) 100) + ",gd_AddedProperty INT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "gd_Memo", (object) 1000) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "gd_ErpCode", (object) 40) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "gd_ExCode", (object) 40) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('{2}')", (object) "gd_UseYn", (object) 1, (object) "Y") + ",gd_InDate DATETIME NULL,gd_InUser INT NOT NULL DEFAULT(0),gd_ModDate DATETIME NULL,gd_ModUser INT NOT NULL DEFAULT(0) PRIMARY KEY(gd_GoodsCode) ) ;";

    public static string CreateTableMySql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_BASE, (object) TableCodeType.Goods) + " gd_GoodsCode BIGINT NOT NULL,gd_SiteID BIGINT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "gd_GoodsName", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "gd_BarCode", (object) 40) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "gd_GoodsSize", (object) 100) + ",gd_TaxDiv INT NOT NULL DEFAULT 0,gd_MakerCode INT NOT NULL DEFAULT 0,gd_BrandCode INT NOT NULL DEFAULT 0,gd_BoxGoodsCode BIGINT NOT NULL DEFAULT 0,gd_BoxPackQty DECIMAL(19,4) NOT NULL DEFAULT 0.0000,gd_Deposit INT NOT NULL DEFAULT 0,gd_SalesUnit INT NOT NULL DEFAULT 0,gd_MinOrderUnit DECIMAL(19,4) NOT NULL DEFAULT 0.0000,gd_StockUnit INT NOT NULL DEFAULT 0,gd_StockConvQty DECIMAL(19,4) NOT NULL DEFAULT 0.0000,gd_PackUnit INT NOT NULL DEFAULT 0,gd_AbcValue INT NOT NULL DEFAULT 0,gd_StorageDiv INT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT '{2}'", (object) "gd_EachDeliveryYn", (object) 1, (object) "Y") + ",gd_VolumeTotal INT NOT NULL DEFAULT 0,gd_VolumeUnit INT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "gd_VolumeUnitText", (object) 100) + ",gd_AddedProperty INT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "gd_Memo", (object) 1000) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "gd_ErpCode", (object) 40) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "gd_ExCode", (object) 40) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT '{2}'", (object) "gd_UseYn", (object) 1, (object) "Y") + ",gd_InDate DATETIME NULL,gd_InUser INT NOT NULL DEFAULT 0,gd_ModDate DATETIME NULL,gd_ModUser INT NOT NULL DEFAULT 0 PRIMARY KEY(gd_GoodsCode) ) ;";

    public bool CreateTable()
    {
      if (this.OleDB.Execute(GoodsCreate.CreateTableQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public bool DropTable()
    {
      if (this.OleDB.Execute(string.Format("DROP Table {0}..{1}", (object) UbModelBase.UNI_BASE, (object) this.TableCode)))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public bool CreateTableComment(string p_db_category)
    {
      if (DbQueryHelper.DbTypeNotNull() != EnumDB.MSSQL)
        return true;
      StringBuilder stringBuilder = new StringBuilder();
      try
      {
        string str = "EXEC " + UbModelBase.UNI_BASE + ".sys.sp_addextendedproperty N'MS_Description', N'";
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}';", (object) str, (object) TableCodeType.Goods.ToDescription(), (object) TableCodeType.Goods));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "상품코드", (object) TableCodeType.Goods, (object) "gd_GoodsCode"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "싸이트", (object) TableCodeType.Goods, (object) "gd_SiteID"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "상품명", (object) TableCodeType.Goods, (object) "gd_GoodsName"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "상품바코드", (object) TableCodeType.Goods, (object) "gd_BarCode"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "규격", (object) TableCodeType.Goods, (object) "gd_GoodsSize"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) str, (object) "과면세", (object) 51, (object) TableCodeType.Goods, (object) "gd_TaxDiv"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "제조사코드", (object) TableCodeType.Goods, (object) "gd_MakerCode"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "브랜드코드", (object) TableCodeType.Goods, (object) "gd_BrandCode"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "박스코드", (object) TableCodeType.Goods, (object) "gd_BoxGoodsCode"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "박스입수", (object) TableCodeType.Goods, (object) "gd_BoxPackQty"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "보증금", (object) TableCodeType.Goods, (object) "gd_Deposit"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) str, (object) "판매단위", (object) 52, (object) TableCodeType.Goods, (object) "gd_SalesUnit"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "최소발주량", (object) TableCodeType.Goods, (object) "gd_MinOrderUnit"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) str, (object) "재고단위", (object) 53, (object) TableCodeType.Goods, (object) "gd_StockUnit"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "재고환산수량", (object) TableCodeType.Goods, (object) "gd_StockConvQty"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) str, (object) "묶음단위", (object) 54, (object) TableCodeType.Goods, (object) "gd_PackUnit"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) str, (object) "ABC분석", (object) 56, (object) TableCodeType.Goods, (object) "gd_AbcValue"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) str, (object) "보관방법", (object) 57, (object) TableCodeType.Goods, (object) "gd_StorageDiv"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "개별배송여부", (object) TableCodeType.Goods, (object) "gd_EachDeliveryYn"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "총용량", (object) TableCodeType.Goods, (object) "gd_VolumeTotal"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "단위용량", (object) TableCodeType.Goods, (object) "gd_VolumeUnit"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "기준단위", (object) TableCodeType.Goods, (object) "gd_VolumeUnitText"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "추가상품속성", (object) TableCodeType.Goods, (object) "gd_AddedProperty"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "메모", (object) TableCodeType.Goods, (object) "gd_Memo"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "ERP 연결코드", (object) TableCodeType.Goods, (object) "gd_ErpCode"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "확장 연결코드", (object) TableCodeType.Goods, (object) "gd_ExCode"));
        stringBuilder.Append(string.Format("CREATE INDEX {0}_IDX1 ON {1}.dbo.{2}", (object) TableCodeType.Goods, (object) UbModelBase.UNI_BASE, (object) TableCodeType.Goods) + " (gd_SiteID,gd_BarCode);");
        if (this.OleDB.Execute(stringBuilder.ToString()))
          return true;
        this.message = " " + this.TableCode.ToDescription() + " 주석 Comment 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.DebugColor(this.message);
        return false;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) ex.GetHashCode()) + " 내용 : " + ex.Message + "\n Query : " + stringBuilder.ToString() + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
        stringBuilder.Clear();
      }
      return false;
    }

    public bool InitTable() => this.InitTable(1L);

    public bool InitTable(long pSiteID)
    {
      if (pSiteID == 0L)
        pSiteID = 1L;
      GoodsView goodsView = this.OleDB.Create<GoodsView>();
      if (pSiteID == 1L)
      {
        goodsView.gd_SiteID = pSiteID;
        goodsView.gd_GoodsName = "미설정";
        goodsView.gd_BarCode = "0000000000000";
        this.OleDB.Execute(goodsView.InsertQuery());
      }
      return true;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        if (p_rs.IsFieldName("gd_GoodsCode"))
          this.gd_GoodsCode = p_rs.GetFieldLong("gd_GoodsCode");
        if (p_rs.IsFieldName("gd_SiteID"))
          this.gd_SiteID = p_rs.GetFieldLong("gd_SiteID");
        if (p_rs.IsFieldName("gd_GoodsName"))
          this.gd_GoodsName = p_rs.GetFieldString("gd_GoodsName");
        if (p_rs.IsFieldName("gd_BarCode"))
          this.gd_BarCode = p_rs.GetFieldString("gd_BarCode");
        if (p_rs.IsFieldName("gd_GoodsSize"))
          this.gd_GoodsSize = p_rs.GetFieldString("gd_GoodsSize");
        if (p_rs.IsFieldName("gd_TaxDiv"))
          this.gd_TaxDiv = p_rs.GetFieldInt("gd_TaxDiv");
        if (p_rs.IsFieldName("gd_MakerCode"))
          this.gd_MakerCode = p_rs.GetFieldInt("gd_MakerCode");
        if (p_rs.IsFieldName("gd_BrandCode"))
          this.gd_BrandCode = p_rs.GetFieldInt("gd_BrandCode");
        if (p_rs.IsFieldName("gd_BoxGoodsCode"))
          this.gd_BoxGoodsCode = p_rs.GetFieldLong("gd_BoxGoodsCode");
        if (p_rs.IsFieldName("gd_BoxPackQty"))
          this.gd_BoxPackQty = p_rs.GetFieldDouble("gd_BoxPackQty");
        if (p_rs.IsFieldName("gd_Deposit"))
          this.gd_Deposit = p_rs.GetFieldInt("gd_Deposit");
        if (p_rs.IsFieldName("gd_SalesUnit"))
          this.gd_SalesUnit = p_rs.GetFieldInt("gd_SalesUnit");
        if (p_rs.IsFieldName("gd_MinOrderUnit"))
          this.gd_MinOrderUnit = p_rs.GetFieldDouble("gd_MinOrderUnit");
        if (p_rs.IsFieldName("gd_StockUnit"))
          this.gd_StockUnit = p_rs.GetFieldInt("gd_StockUnit");
        if (p_rs.IsFieldName("gd_StockConvQty"))
          this.gd_StockConvQty = p_rs.GetFieldDouble("gd_StockConvQty");
        if (p_rs.IsFieldName("gd_PackUnit"))
          this.gd_PackUnit = p_rs.GetFieldInt("gd_PackUnit");
        if (p_rs.IsFieldName("gd_AbcValue"))
          this.gd_AbcValue = p_rs.GetFieldInt("gd_AbcValue");
        if (p_rs.IsFieldName("gd_StorageDiv"))
          this.gd_StorageDiv = p_rs.GetFieldInt("gd_StorageDiv");
        if (p_rs.IsFieldName("gd_EachDeliveryYn"))
          this.gd_EachDeliveryYn = p_rs.GetFieldString("gd_EachDeliveryYn");
        if (p_rs.IsFieldName("gd_VolumeTotal"))
          this.gd_VolumeTotal = p_rs.GetFieldInt("gd_VolumeTotal");
        if (p_rs.IsFieldName("gd_VolumeUnit"))
          this.gd_VolumeUnit = p_rs.GetFieldInt("gd_VolumeUnit");
        if (p_rs.IsFieldName("gd_VolumeUnitText"))
          this.gd_VolumeUnitText = p_rs.GetFieldString("gd_VolumeUnitText");
        if (p_rs.IsFieldName("gd_AddedProperty"))
          this.gd_AddedProperty = p_rs.GetFieldInt("gd_AddedProperty");
        if (p_rs.IsFieldName("gd_Memo"))
          this.gd_Memo = p_rs.GetFieldString("gd_Memo");
        if (p_rs.IsFieldName("gd_ErpCode"))
          this.gd_ErpCode = p_rs.GetFieldString("gd_ErpCode");
        if (p_rs.IsFieldName("gd_ExCode"))
          this.gd_ExCode = p_rs.GetFieldString("gd_ExCode");
        if (p_rs.IsFieldName("gd_UseYn"))
          this.gd_UseYn = p_rs.GetFieldString("gd_UseYn");
        if (p_rs.IsFieldName("gd_InDate"))
          this.gd_InDate = p_rs.GetFieldDateTime("gd_InDate");
        if (p_rs.IsFieldName("gd_InUser"))
          this.gd_InUser = p_rs.GetFieldInt("gd_InUser");
        if (p_rs.IsFieldName("gd_ModDate"))
          this.gd_ModDate = p_rs.GetFieldDateTime("gd_ModDate");
        if (p_rs.IsFieldName("gd_ModUser"))
          this.gd_ModUser = p_rs.GetFieldInt("gd_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public bool ReCreateTable()
    {
      try
      {
        IList<GoodsCreate> goodsCreateList = this.OleDB.Create<GoodsCreate>().SelectAllListE<GoodsCreate>((object) new Hashtable()
        {
          {
            (object) "DBMS",
            (object) UbModelBase.UNI_BASE
          }
        });
        if (goodsCreateList == null)
        {
          this.message = " " + this.TableCode.ToDescription() + " SELECT AND Serialize 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          throw new Exception();
        }
        if (!this.DropTable())
        {
          this.message = " " + this.TableCode.ToDescription() + " Drop 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          throw new Exception();
        }
        if (!this.CreateTable())
        {
          this.message = " " + this.TableCode.ToDescription() + " Create 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          throw new Exception();
        }
        if (!this.CreateTableComment(string.Empty))
        {
          this.message = " " + this.TableCode.ToDescription() + " Create Comment 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
          throw new Exception();
        }
        int count = goodsCreateList.Count;
        int num1 = 0;
        int num2 = 0;
        if (goodsCreateList.Count > 0)
          Log.Logger.DebugColor("\n--------------------------------------------------------------------------------------------------" + string.Format("\n - {0}({1}) 이전 데이터 작업 시작", (object) TableCodeType.Goods.ToDescription(), (object) TableCodeType.Goods) + "\n--------------------------------------------------------------------------------------------------");
        StringBuilder stringBuilder = new StringBuilder();
        foreach (GoodsCreate goodsCreate in (IEnumerable<GoodsCreate>) goodsCreateList)
        {
          stringBuilder.Append(goodsCreate.InsertQuery());
          if (stringBuilder.Length > 4000)
          {
            if (!this.OleDB.Execute(stringBuilder.ToString()))
            {
              this.message = " " + this.TableCode.ToDescription() + " Insert 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
              throw new Exception();
            }
            stringBuilder.Clear();
          }
          ++num1;
          int num3 = num1 * 100 / count;
          if (num2 != num3)
          {
            Log.Logger.DebugColor(string.Format(" pro = {0}%", (object) num3));
            num2 = num3;
          }
        }
        if (stringBuilder.Length > 0)
        {
          if (!this.OleDB.Execute(stringBuilder.ToString()))
          {
            this.message = " " + this.TableCode.ToDescription() + " Insert 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
            throw new Exception();
          }
          stringBuilder.Clear();
        }
        GoodsView goodsView = this.OleDB.Create<GoodsView>();
        goodsView.gd_SiteID = 1L;
        goodsView.gd_GoodsName = "미설정";
        goodsView.gd_BarCode = "0000000000000";
        goodsView.UpdateExInsert();
        if (goodsCreateList.Count > 0)
        {
          Log.Logger.DebugColor(" pro = 100%");
          Log.Logger.DebugColor(string.Format(" - {0}({1}) 이전 데이터 작업 종료", (object) TableCodeType.Goods.ToDescription(), (object) TableCodeType.Goods) + "\n--------------------------------------------------------------------------------------------------");
        }
      }
      catch (Exception ex)
      {
        Log.Logger.DebugColor(this.message);
        return false;
      }
      return true;
    }
  }
}
