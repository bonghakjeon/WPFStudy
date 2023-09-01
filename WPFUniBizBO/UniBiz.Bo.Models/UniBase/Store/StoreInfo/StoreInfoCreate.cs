// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Store.StoreInfo.StoreInfoCreate
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

namespace UniBiz.Bo.Models.UniBase.Store.StoreInfo
{
  public class StoreInfoCreate : TStoreInfo, ICreateTable
  {
    public static string CreateTableQuery()
    {
      string tableQuery;
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          tableQuery = StoreInfoCreate.CreateTableMsSql();
          break;
        case EnumDB.MYSQL:
          tableQuery = StoreInfoCreate.CreateTableMySql();
          break;
        default:
          tableQuery = string.Empty;
          break;
      }
      return tableQuery;
    }

    public static string CreateTableMsSql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_BASE, (object) TableCodeType.StoreInfo) + " si_StoreCode INT NOT NULL,si_SiteID BIGINT NOT NULL DEFAULT(0),si_StoreType INT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "si_StoreViewCode", (object) 6) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "si_StoreName", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "si_Tel1", (object) 20) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "si_Tel2", (object) 20) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "si_LocalIP", (object) 20) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "si_PublicIP", (object) 20) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('{2}')", (object) "si_UseYn", (object) 1, (object) "Y") + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "si_ErpCode", (object) 10) + ",si_ErpUpdateDate DATETIME NULL" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "si_BizNo", (object) 15) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "si_BizName", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "si_BizCeo", (object) 50) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "si_BizType", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "si_BizCategory", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "si_BizAddr1", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "si_BizAddr2", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "si_ZipCode", (object) 7) + ",si_BuyConfirmDate DATETIME NULL,si_StockConfirmDate DATETIME NULL,si_StockStartDate DATETIME NULL,si_SaleConfirmDate DATETIME NULL,si_SortNo INT NOT NULL DEFAULT(0),si_MemberMntStore INT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "si_WeatherCode", (object) 20) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "si_Email", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "si_EmailPwd", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('{2}')", (object) "si_LocationUseYn", (object) 1, (object) "N") + ",si_AutoOrderSafetyFactor MONEY NOT NULL DEFAULT(0.0000),si_AutoOrderOpt INT NOT NULL DEFAULT(0),si_AutoOrderRef INT NOT NULL DEFAULT(0),si_InDate DATETIME NULL,si_InUser INT NOT NULL DEFAULT(0),si_ModDate DATETIME NULL,si_ModUser INT NOT NULL DEFAULT(0) PRIMARY KEY(si_StoreCode ASC) ) ;";

    public static string CreateTableMySql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_BASE, (object) TableCodeType.StoreInfo) + " si_StoreCode INT NOT NULL,si_SiteID BIGINT NOT NULL DEFAULT 0,si_StoreType INT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "si_StoreViewCode", (object) 6) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "si_StoreName", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "si_Tel1", (object) 20) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "si_Tel2", (object) 20) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "si_LocalIP", (object) 20) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "si_PublicIP", (object) 20) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT '{2}'", (object) "si_UseYn", (object) 1, (object) "Y") + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "si_ErpCode", (object) 10) + ",si_ErpUpdateDate DATETIME NULL" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "si_BizNo", (object) 15) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "si_BizName", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "si_BizCeo", (object) 50) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "si_BizType", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "si_BizCategory", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "si_BizAddr1", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "si_BizAddr2", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "si_ZipCode", (object) 7) + ",si_BuyConfirmDate DATETIME NULL,si_StockConfirmDate DATETIME NULL,si_StockStartDate DATETIME NULL,si_SaleConfirmDate DATETIME NULL,si_SortNo INT NOT NULL DEFAULT 0,si_MemberMntStore INT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "si_WeatherCode", (object) 20) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "si_Email", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "si_EmailPwd", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT '{2}'", (object) "si_LocationUseYn", (object) 1, (object) "N") + ",si_AutoOrderSafetyFactor MONEY NOT NULL DEFAULT 0.0000,si_AutoOrderOpt INT NOT NULL DEFAULT 0,si_AutoOrderRef INT NOT NULL DEFAULT 0,si_InDate DATETIME NULL,si_InUser INT NOT NULL DEFAULT 0,si_ModDate DATETIME NULL,si_ModUser INT NOT NULL DEFAULT 0 PRIMARY KEY(si_StoreCode) ) ;";

    public bool CreateTable()
    {
      if (this.OleDB.Execute(StoreInfoCreate.CreateTableQuery()))
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
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}';", (object) UbModelBase.UNI_BASE, (object) TableCodeType.StoreInfo.ToDescription(), (object) TableCodeType.StoreInfo));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "지점코드", (object) TableCodeType.StoreInfo, (object) "si_StoreCode"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "싸이트", (object) TableCodeType.StoreInfo, (object) "si_SiteID"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) UbModelBase.UNI_BASE, (object) "지점타입", (object) 30, (object) TableCodeType.StoreInfo, (object) "si_StoreType"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "관리코드", (object) TableCodeType.StoreInfo, (object) "si_StoreViewCode"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "지점명", (object) TableCodeType.StoreInfo, (object) "si_StoreName"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "TEL 1", (object) TableCodeType.StoreInfo, (object) "si_Tel1"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "TEL 2", (object) TableCodeType.StoreInfo, (object) "si_Tel2"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "로컬 IP", (object) TableCodeType.StoreInfo, (object) "si_LocalIP"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "Public IP", (object) TableCodeType.StoreInfo, (object) "si_PublicIP"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "사용상태", (object) TableCodeType.StoreInfo, (object) "si_UseYn"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "ERP 코드", (object) TableCodeType.StoreInfo, (object) "si_ErpCode"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "ERP 연결 일자", (object) TableCodeType.StoreInfo, (object) "si_ErpUpdateDate"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "사업자번호", (object) TableCodeType.StoreInfo, (object) "si_BizNo"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "사업자명", (object) TableCodeType.StoreInfo, (object) "si_BizName"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "대표자", (object) TableCodeType.StoreInfo, (object) "si_BizCeo"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "업태", (object) TableCodeType.StoreInfo, (object) "si_BizType"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "업종", (object) TableCodeType.StoreInfo, (object) "si_BizCategory"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "주소", (object) TableCodeType.StoreInfo, (object) "si_BizAddr1"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "주소 상세", (object) TableCodeType.StoreInfo, (object) "si_BizAddr2"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "우편번호", (object) TableCodeType.StoreInfo, (object) "si_ZipCode"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "매입확정일", (object) TableCodeType.StoreInfo, (object) "si_BuyConfirmDate"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "수불확정일", (object) TableCodeType.StoreInfo, (object) "si_StockConfirmDate"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "수불시작일", (object) TableCodeType.StoreInfo, (object) "si_StockStartDate"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "판매확정일", (object) TableCodeType.StoreInfo, (object) "si_SaleConfirmDate"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "순위", (object) TableCodeType.StoreInfo, (object) "si_SortNo"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "포인트 지점", (object) TableCodeType.StoreInfo, (object) "si_MemberMntStore"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "날씨", (object) TableCodeType.StoreInfo, (object) "si_WeatherCode"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "이메일", (object) TableCodeType.StoreInfo, (object) "si_Email"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "이메일패스워드", (object) TableCodeType.StoreInfo, (object) "si_EmailPwd"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "로케이션 사용유무", (object) TableCodeType.StoreInfo, (object) "si_LocationUseYn"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "자동발주 안전계수", (object) TableCodeType.StoreInfo, (object) "si_AutoOrderSafetyFactor"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "자동발주 옵션", (object) TableCodeType.StoreInfo, (object) "si_AutoOrderOpt"));
        stringBuilder.Append(string.Format("EXEC {0}.sys.sp_addextendedproperty N'MS_Description', N'{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) UbModelBase.UNI_BASE, (object) "자동발주 최근 참고 데이터 일수", (object) TableCodeType.StoreInfo, (object) "si_AutoOrderRef"));
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
      StoreInfoView storeInfoView = this.OleDB.Create<StoreInfoView>();
      storeInfoView.si_SiteID = pSiteID;
      storeInfoView.si_StoreType = 2;
      storeInfoView.si_StoreName = string.Format("{0}.지점", (object) pSiteID);
      storeInfoView.si_StoreViewCode = string.Format("{0:0000}", (object) pSiteID);
      DateTime now = DateTime.Now;
      storeInfoView.si_BuyConfirmDate = new DateTime?(now);
      storeInfoView.si_StockConfirmDate = new DateTime?(now);
      storeInfoView.si_StockStartDate = new DateTime?(now.ToFirstDateOfYear());
      this.OleDB.Execute(storeInfoView.InsertQuery());
      return true;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        if (p_rs.IsFieldName("si_StoreCode"))
          this.si_StoreCode = p_rs.GetFieldInt("si_StoreCode");
        if (p_rs.IsFieldName("si_SiteID"))
          this.si_SiteID = p_rs.GetFieldLong("si_SiteID");
        if (p_rs.IsFieldName("si_StoreType"))
          this.si_StoreType = p_rs.GetFieldInt("si_StoreType");
        if (p_rs.IsFieldName("si_StoreViewCode"))
          this.si_StoreViewCode = p_rs.GetFieldString("si_StoreViewCode");
        if (p_rs.IsFieldName("si_StoreName"))
          this.si_StoreName = p_rs.GetFieldString("si_StoreName");
        if (p_rs.IsFieldName("si_Tel1"))
          this.si_Tel1 = p_rs.GetFieldString("si_Tel1");
        if (p_rs.IsFieldName("si_Tel2"))
          this.si_Tel2 = p_rs.GetFieldString("si_Tel2");
        if (p_rs.IsFieldName("si_LocalIP"))
          this.si_LocalIP = p_rs.GetFieldString("si_LocalIP");
        if (p_rs.IsFieldName("si_PublicIP"))
          this.si_PublicIP = p_rs.GetFieldString("si_PublicIP");
        if (p_rs.IsFieldName("si_UseYn"))
          this.si_UseYn = p_rs.GetFieldString("si_UseYn");
        if (p_rs.IsFieldName("si_ErpCode"))
          this.si_ErpCode = p_rs.GetFieldString("si_ErpCode");
        if (p_rs.IsFieldName("si_ErpUpdateDate"))
          this.si_ErpUpdateDate = p_rs.GetFieldDateTime("si_ErpUpdateDate");
        if (p_rs.IsFieldName("si_BizNo"))
          this.si_BizNo = p_rs.GetFieldString("si_BizNo");
        if (p_rs.IsFieldName("si_BizName"))
          this.si_BizName = p_rs.GetFieldString("si_BizName");
        if (p_rs.IsFieldName("si_BizCeo"))
          this.si_BizCeo = p_rs.GetFieldString("si_BizCeo");
        if (p_rs.IsFieldName("si_BizType"))
          this.si_BizType = p_rs.GetFieldString("si_BizType");
        if (p_rs.IsFieldName("si_BizCategory"))
          this.si_BizCategory = p_rs.GetFieldString("si_BizCategory");
        if (p_rs.IsFieldName("si_BizAddr1"))
          this.si_BizAddr1 = p_rs.GetFieldString("si_BizAddr1");
        if (p_rs.IsFieldName("si_BizAddr2"))
          this.si_BizAddr2 = p_rs.GetFieldString("si_BizAddr2");
        if (p_rs.IsFieldName("si_ZipCode"))
          this.si_ZipCode = p_rs.GetFieldString("si_ZipCode");
        if (p_rs.IsFieldName("si_BuyConfirmDate"))
          this.si_BuyConfirmDate = p_rs.GetFieldDateTime("si_BuyConfirmDate");
        if (p_rs.IsFieldName("si_StockConfirmDate"))
          this.si_StockConfirmDate = p_rs.GetFieldDateTime("si_StockConfirmDate");
        if (p_rs.IsFieldName("si_StockStartDate"))
          this.si_StockStartDate = p_rs.GetFieldDateTime("si_StockStartDate");
        if (p_rs.IsFieldName("si_SaleConfirmDate"))
          this.si_SaleConfirmDate = p_rs.GetFieldDateTime("si_SaleConfirmDate");
        if (p_rs.IsFieldName("si_SortNo"))
          this.si_SortNo = p_rs.GetFieldInt("si_SortNo");
        if (p_rs.IsFieldName("si_MemberMntStore"))
          this.si_MemberMntStore = p_rs.GetFieldInt("si_MemberMntStore");
        if (p_rs.IsFieldName("si_WeatherCode"))
          this.si_WeatherCode = p_rs.GetFieldString("si_WeatherCode");
        if (p_rs.IsFieldName("si_Email"))
          this.si_Email = p_rs.GetFieldString("si_Email");
        if (p_rs.IsFieldName("si_EmailPwd"))
          this.si_EmailPwd = p_rs.GetFieldString("si_EmailPwd");
        if (p_rs.IsFieldName("si_LocationUseYn"))
          this.si_LocationUseYn = p_rs.GetFieldString("si_LocationUseYn");
        if (p_rs.IsFieldName("si_AutoOrderSafetyFactor"))
          this.si_AutoOrderSafetyFactor = p_rs.GetFieldDouble("si_AutoOrderSafetyFactor");
        if (p_rs.IsFieldName("si_AutoOrderOpt"))
          this.si_AutoOrderOpt = p_rs.GetFieldInt("si_AutoOrderOpt");
        if (p_rs.IsFieldName("si_AutoOrderRef"))
          this.si_AutoOrderRef = p_rs.GetFieldInt("si_AutoOrderRef");
        if (p_rs.IsFieldName("si_InDate"))
          this.si_InDate = p_rs.GetFieldDateTime("si_InDate");
        if (p_rs.IsFieldName("si_InUser"))
          this.si_InUser = p_rs.GetFieldInt("si_InUser");
        if (p_rs.IsFieldName("si_ModDate"))
          this.si_ModDate = p_rs.GetFieldDateTime("si_ModDate");
        if (p_rs.IsFieldName("si_ModUser"))
          this.si_ModUser = p_rs.GetFieldInt("si_ModUser");
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
        IList<StoreInfoCreate> storeInfoCreateList = this.OleDB.Create<StoreInfoCreate>().SelectAllListE<StoreInfoCreate>((object) new Hashtable()
        {
          {
            (object) "DBMS",
            (object) UbModelBase.UNI_BASE
          }
        });
        if (storeInfoCreateList == null)
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
        int count = storeInfoCreateList.Count;
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        if (storeInfoCreateList.Count > 0)
          Log.Logger.DebugColor("\n--------------------------------------------------------------------------------------------------" + string.Format("\n - {0}({1}) 이전 데이터 작업 시작", (object) TableCodeType.StoreInfo.ToDescription(), (object) TableCodeType.StoreInfo) + "\n--------------------------------------------------------------------------------------------------");
        StringBuilder stringBuilder = new StringBuilder();
        foreach (StoreInfoCreate storeInfoCreate in (IEnumerable<StoreInfoCreate>) storeInfoCreateList)
        {
          stringBuilder.Append(storeInfoCreate.InsertQuery());
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
          num2 = num1 * 100 / count;
          if (num3 != num2)
          {
            Log.Logger.DebugColor(string.Format(" pro = {0}%", (object) num2));
            num3 = num2;
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
        StoreInfoView storeInfoView = this.OleDB.Create<StoreInfoView>();
        storeInfoView.si_SiteID = 1L;
        storeInfoView.si_StoreType = 2;
        storeInfoView.si_StoreName = "0.지점";
        storeInfoView.si_StoreViewCode = "0000";
        DateTime now = DateTime.Now;
        storeInfoView.si_BuyConfirmDate = new DateTime?(now);
        storeInfoView.si_StockConfirmDate = new DateTime?(now);
        storeInfoView.si_StockStartDate = new DateTime?(now.ToFirstDateOfYear());
        storeInfoView.UpdateExInsert();
        if (storeInfoCreateList.Count > 0)
        {
          if (num2 != 100)
            Log.Logger.DebugColor(" pro = 100%");
          Log.Logger.DebugColor(string.Format(" - {0}({1}) 이전 데이터 작업 종료", (object) TableCodeType.StoreInfo.ToDescription(), (object) TableCodeType.StoreInfo) + "\n--------------------------------------------------------------------------------------------------");
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
