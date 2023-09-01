// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniCampaign.CampaignInfo.Promotion.PromotionCreate
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

namespace UniBiz.Bo.Models.UniCampaign.CampaignInfo.Promotion
{
  public class PromotionCreate : TPromotion, ICreateTable
  {
    public static string CreateTableQuery()
    {
      string tableQuery;
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          tableQuery = PromotionCreate.CreateTableMsSql();
          break;
        case EnumDB.MYSQL:
          tableQuery = PromotionCreate.CreateTableMySql();
          break;
        default:
          tableQuery = string.Empty;
          break;
      }
      return tableQuery;
    }

    public static string CreateTableMsSql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_CAMPANIGN, (object) TableCodeType.Promotion) + " pm_PromotionCode BIGINT NOT NULL,pm_SiteID BIGINT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "pm_PromotionName", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "pm_PromotionDesc", (object) 500) + string.Format(",{0} INT NOT NULL DEFAULT({1})", (object) "pm_PromotionKind", (object) 0) + string.Format(",{0} INT NOT NULL DEFAULT({1})", (object) "pm_PromotionType", (object) 0) + string.Format(",{0} INT NOT NULL DEFAULT({1})", (object) "pm_PromotionDiv", (object) 0) + string.Format(",{0} INT NOT NULL DEFAULT({1})", (object) "pm_TargetGroup", (object) 0) + ",pm_DcValue MONEY NOT NULL DEFAULT(0.0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "pm_MixYn", (object) 1) + string.Format(",{0} INT NOT NULL DEFAULT({1})", (object) "pm_MixOperator", (object) 0) + ",pm_MixQty INT NOT NULL DEFAULT(0)" + string.Format(",{0} INT NOT NULL DEFAULT({1})", (object) "pm_ApplyDiv", (object) 0) + ",pm_ApplyPackQty INT NOT NULL DEFAULT(0),pm_ApplyMinQty INT NOT NULL DEFAULT(0),pm_ApplyMaxQty INT NOT NULL DEFAULT(0),pm_ApplyMinAmt MONEY NOT NULL DEFAULT(0.0),pm_ApplyMaxAmt MONEY NOT NULL DEFAULT(0.0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "pm_ApplyAllYn", (object) 1) + ",pm_EventReceiptID INT NOT NULL DEFAULT(0),pm_StartDate DATETIME NOT NULL" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "pm_StartTime", (object) 4) + ",pm_EndDate DATETIME NOT NULL" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "pm_EndTime", (object) 4) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "pm_SunYn", (object) 1) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "pm_MonYn", (object) 1) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "pm_TueYn", (object) 1) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "pm_WedYn", (object) 1) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "pm_ThuYn", (object) 1) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "pm_FriYn", (object) 1) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "pm_SatYn", (object) 1) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "pm_DuplicationYn", (object) 1) + ",pm_InDate DATETIME NULL,pm_InUser INT NOT NULL DEFAULT(0),pm_ModDate DATETIME NULL,pm_ModUser INT NOT NULL DEFAULT(0) PRIMARY KEY(pm_PromotionCode) ) ;";

    public static string CreateTableMySql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_CAMPANIGN, (object) TableCodeType.Promotion) + " pm_PromotionCode BIGINT NOT NULL,pm_SiteID BIGINT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "pm_PromotionName", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "pm_PromotionDesc", (object) 500) + string.Format(",{0} INT NOT NULL DEFAULT {1}", (object) "pm_PromotionKind", (object) 0) + string.Format(",{0} INT NOT NULL DEFAULT {1}", (object) "pm_PromotionType", (object) 0) + string.Format(",{0} INT NOT NULL DEFAULT {1}", (object) "pm_PromotionDiv", (object) 0) + string.Format(",{0} INT NOT NULL DEFAULT {1}", (object) "pm_TargetGroup", (object) 0) + ",pm_DcValue DECIMAL(19,4) NOT NULL DEFAULT 0.0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "pm_MixYn", (object) 1) + string.Format(",{0} INT NOT NULL DEFAULT {1}", (object) "pm_MixOperator", (object) 0) + ",pm_MixQty INT NOT NULL DEFAULT 0" + string.Format(",{0} INT NOT NULL DEFAULT {1}", (object) "pm_ApplyDiv", (object) 0) + ",pm_ApplyPackQty INT NOT NULL DEFAULT 0,pm_ApplyMinQty INT NOT NULL DEFAULT 0,pm_ApplyMaxQty INT NOT NULL DEFAULT 0,pm_ApplyMinAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0,pm_ApplyMaxAmt DECIMAL(19,4) NOT NULL DEFAULT 0.0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "pm_ApplyAllYn", (object) 1) + ",pm_EventReceiptID INT NOT NULL DEFAULT 0,pm_StartDate DATETIME NOT NULL" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "pm_StartTime", (object) 4) + ",pm_EndDate DATETIME NOT NULL" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "pm_EndTime", (object) 4) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "pm_SunYn", (object) 1) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "pm_MonYn", (object) 1) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "pm_TueYn", (object) 1) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "pm_WedYn", (object) 1) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "pm_ThuYn", (object) 1) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "pm_FriYn", (object) 1) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "pm_SatYn", (object) 1) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "pm_DuplicationYn", (object) 1) + ",pm_InDate DATETIME NULL,pm_InUser INT NOT NULL DEFAULT 0,pm_ModDate DATETIME NULL,pm_ModUser INT NOT NULL DEFAULT 0 PRIMARY KEY(pm_PromotionCode) ) ;";

    public bool CreateTable()
    {
      if (this.OleDB.Execute(PromotionCreate.CreateTableQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public bool DropTable()
    {
      if (this.OleDB.Execute(string.Format("DROP Table {0}..{1}", (object) UbModelBase.UNI_CAMPANIGN, (object) this.TableCode)))
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
        string str = "EXEC " + UbModelBase.UNI_CAMPANIGN + ".sys.sp_addextendedproperty N'MS_Description', N'";
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}';", (object) str, (object) TableCodeType.Promotion.ToDescription(), (object) TableCodeType.Promotion));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "프로모션코드", (object) TableCodeType.Promotion, (object) "pm_PromotionCode"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "싸이트", (object) TableCodeType.Promotion, (object) "pm_SiteID"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "프로모션명", (object) TableCodeType.Promotion, (object) "pm_PromotionName"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "프로모션상세명", (object) TableCodeType.Promotion, (object) "pm_PromotionDesc"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) str, (object) "종류", (object) 221, (object) TableCodeType.Promotion, (object) "pm_PromotionKind"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) str, (object) "유형", (object) 222, (object) TableCodeType.Promotion, (object) "pm_PromotionType"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) str, (object) "구분", (object) 223, (object) TableCodeType.Promotion, (object) "pm_PromotionDiv"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) str, (object) "적용대상", (object) 224, (object) TableCodeType.Promotion, (object) "pm_TargetGroup"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "할인값", (object) TableCodeType.Promotion, (object) "pm_DcValue"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "믹스조건", (object) TableCodeType.Promotion, (object) "pm_MixYn"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) str, (object) "연산자", (object) 225, (object) TableCodeType.Promotion, (object) "pm_MixOperator"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "믹스수량", (object) TableCodeType.Promotion, (object) "pm_MixQty"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) str, (object) "적용체크", (object) 226, (object) TableCodeType.Promotion, (object) "pm_ApplyDiv"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "적용묶음수량", (object) TableCodeType.Promotion, (object) "pm_ApplyPackQty"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "적용최소수량", (object) TableCodeType.Promotion, (object) "pm_ApplyMinQty"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "적용최대수량", (object) TableCodeType.Promotion, (object) "pm_ApplyMaxQty"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "적용최소금액", (object) TableCodeType.Promotion, (object) "pm_ApplyMinAmt"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "적용최대금액", (object) TableCodeType.Promotion, (object) "pm_ApplyMaxAmt"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "모두적용", (object) TableCodeType.Promotion, (object) "pm_ApplyAllYn"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "이벤트영수증ID", (object) TableCodeType.Promotion, (object) "pm_EventReceiptID"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "시작일자", (object) TableCodeType.Promotion, (object) "pm_StartDate"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "시작시간", (object) TableCodeType.Promotion, (object) "pm_StartTime"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "종료일자", (object) TableCodeType.Promotion, (object) "pm_EndDate"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "종료시간", (object) TableCodeType.Promotion, (object) "pm_EndTime"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "일", (object) TableCodeType.Promotion, (object) "pm_SunYn"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "월", (object) TableCodeType.Promotion, (object) "pm_MonYn"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "화", (object) TableCodeType.Promotion, (object) "pm_TueYn"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "수", (object) TableCodeType.Promotion, (object) "pm_WedYn"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "목", (object) TableCodeType.Promotion, (object) "pm_ThuYn"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "금", (object) TableCodeType.Promotion, (object) "pm_FriYn"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "토", (object) TableCodeType.Promotion, (object) "pm_SatYn"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "중복가능", (object) TableCodeType.Promotion, (object) "pm_DuplicationYn"));
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
      return true;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        if (p_rs.IsFieldName("pm_PromotionCode"))
          this.pm_PromotionCode = p_rs.GetFieldLong("pm_PromotionCode");
        if (p_rs.IsFieldName("pm_SiteID"))
          this.pm_SiteID = p_rs.GetFieldLong("pm_SiteID");
        if (p_rs.IsFieldName("pm_PromotionName"))
          this.pm_PromotionName = p_rs.GetFieldString("pm_PromotionName");
        if (p_rs.IsFieldName("pm_PromotionDesc"))
          this.pm_PromotionDesc = p_rs.GetFieldString("pm_PromotionDesc");
        if (p_rs.IsFieldName("pm_PromotionKind"))
          this.pm_PromotionKind = p_rs.GetFieldInt("pm_PromotionKind");
        if (p_rs.IsFieldName("pm_PromotionType"))
          this.pm_PromotionType = p_rs.GetFieldInt("pm_PromotionType");
        if (p_rs.IsFieldName("pm_PromotionDiv"))
          this.pm_PromotionDiv = p_rs.GetFieldInt("pm_PromotionDiv");
        if (p_rs.IsFieldName("pm_TargetGroup"))
          this.pm_TargetGroup = p_rs.GetFieldInt("pm_TargetGroup");
        if (p_rs.IsFieldName("pm_DcValue"))
          this.pm_DcValue = p_rs.GetFieldDouble("pm_DcValue");
        if (p_rs.IsFieldName("pm_MixYn"))
          this.pm_MixYn = p_rs.GetFieldString("pm_MixYn");
        if (p_rs.IsFieldName("pm_MixOperator"))
          this.pm_MixOperator = p_rs.GetFieldInt("pm_MixOperator");
        if (p_rs.IsFieldName("pm_MixQty"))
          this.pm_MixQty = p_rs.GetFieldInt("pm_MixQty");
        if (p_rs.IsFieldName("pm_ApplyDiv"))
          this.pm_ApplyDiv = p_rs.GetFieldInt("pm_ApplyDiv");
        if (p_rs.IsFieldName("pm_ApplyPackQty"))
          this.pm_ApplyPackQty = p_rs.GetFieldInt("pm_ApplyPackQty");
        if (p_rs.IsFieldName("pm_ApplyMinQty"))
          this.pm_ApplyMinQty = p_rs.GetFieldInt("pm_ApplyMinQty");
        if (p_rs.IsFieldName("pm_ApplyMaxQty"))
          this.pm_ApplyMaxQty = p_rs.GetFieldInt("pm_ApplyMaxQty");
        if (p_rs.IsFieldName("pm_ApplyMinAmt"))
          this.pm_ApplyMinAmt = p_rs.GetFieldDouble("pm_ApplyMinAmt");
        if (p_rs.IsFieldName("pm_ApplyMaxAmt"))
          this.pm_ApplyMaxAmt = p_rs.GetFieldDouble("pm_ApplyMaxAmt");
        if (p_rs.IsFieldName("pm_ApplyAllYn"))
          this.pm_ApplyAllYn = p_rs.GetFieldString("pm_ApplyAllYn");
        if (p_rs.IsFieldName("pm_EventReceiptID"))
          this.pm_EventReceiptID = p_rs.GetFieldInt("pm_EventReceiptID");
        if (p_rs.IsFieldName("pm_StartDate"))
          this.pm_StartDate = p_rs.GetFieldDateTime("pm_StartDate");
        if (p_rs.IsFieldName("pm_StartTime"))
          this.pm_StartTime = p_rs.GetFieldString("pm_StartTime");
        if (p_rs.IsFieldName("pm_EndDate"))
          this.pm_EndDate = p_rs.GetFieldDateTime("pm_EndDate");
        if (p_rs.IsFieldName("pm_EndTime"))
          this.pm_EndTime = p_rs.GetFieldString("pm_EndTime");
        if (p_rs.IsFieldName("pm_SunYn"))
          this.pm_SunYn = p_rs.GetFieldString("pm_SunYn");
        if (p_rs.IsFieldName("pm_MonYn"))
          this.pm_MonYn = p_rs.GetFieldString("pm_MonYn");
        if (p_rs.IsFieldName("pm_TueYn"))
          this.pm_TueYn = p_rs.GetFieldString("pm_TueYn");
        if (p_rs.IsFieldName("pm_WedYn"))
          this.pm_WedYn = p_rs.GetFieldString("pm_WedYn");
        if (p_rs.IsFieldName("pm_ThuYn"))
          this.pm_ThuYn = p_rs.GetFieldString("pm_ThuYn");
        if (p_rs.IsFieldName("pm_FriYn"))
          this.pm_FriYn = p_rs.GetFieldString("pm_FriYn");
        if (p_rs.IsFieldName("pm_SatYn"))
          this.pm_SatYn = p_rs.GetFieldString("pm_SatYn");
        if (p_rs.IsFieldName("pm_DuplicationYn"))
          this.pm_DuplicationYn = p_rs.GetFieldString("pm_DuplicationYn");
        if (p_rs.IsFieldName("pm_InDate"))
          this.pm_InDate = p_rs.GetFieldDateTime("pm_InDate");
        if (p_rs.IsFieldName("pm_InUser"))
          this.pm_InUser = p_rs.GetFieldInt("pm_InUser");
        if (p_rs.IsFieldName("pm_ModDate"))
          this.pm_ModDate = p_rs.GetFieldDateTime("pm_ModDate");
        if (p_rs.IsFieldName("pm_ModUser"))
          this.pm_ModUser = p_rs.GetFieldInt("pm_ModUser");
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
        IList<PromotionCreate> promotionCreateList = this.OleDB.Create<PromotionCreate>().SelectAllListE<PromotionCreate>((object) new Hashtable()
        {
          {
            (object) "DBMS",
            (object) UbModelBase.UNI_CAMPANIGN
          }
        });
        if (promotionCreateList == null)
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
        int count = promotionCreateList.Count;
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        if (promotionCreateList.Count > 0)
          Log.Logger.DebugColor("\n--------------------------------------------------------------------------------------------------" + string.Format("\n - {0}({1}) 이전 데이터 작업 시작", (object) TableCodeType.Promotion.ToDescription(), (object) TableCodeType.Promotion) + "\n--------------------------------------------------------------------------------------------------");
        StringBuilder stringBuilder = new StringBuilder();
        foreach (PromotionCreate promotionCreate in (IEnumerable<PromotionCreate>) promotionCreateList)
        {
          stringBuilder.Append(promotionCreate.InsertQuery());
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
        if (promotionCreateList.Count > 0)
        {
          if (num2 != 100)
            Log.Logger.DebugColor(" pro = 100%");
          Log.Logger.DebugColor(string.Format(" - {0}({1}) 이전 데이터 작업 종료", (object) TableCodeType.Promotion.ToDescription(), (object) TableCodeType.Promotion) + "\n--------------------------------------------------------------------------------------------------");
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
