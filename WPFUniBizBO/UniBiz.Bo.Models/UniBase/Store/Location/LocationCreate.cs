// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Store.Location.LocationCreate
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

namespace UniBiz.Bo.Models.UniBase.Store.Location
{
  public class LocationCreate : TLocation, ICreateTable
  {
    public static string CreateTableQuery()
    {
      string tableQuery;
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          tableQuery = LocationCreate.CreateTableMsSql();
          break;
        case EnumDB.MYSQL:
          tableQuery = LocationCreate.CreateTableMySql();
          break;
        default:
          tableQuery = string.Empty;
          break;
      }
      return tableQuery;
    }

    public static string CreateTableMsSql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_BASE, (object) TableCodeType.Location) + " loc_LocationID INT NOT NULL,loc_SiteID BIGINT NOT NULL DEFAULT(0),loc_StoreCode INT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "loc_LocationCode", (object) 20) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "loc_LocationName", (object) 20) + ",loc_StorageDiv INT NOT NULL DEFAULT(0),loc_SortNo INT NOT NULL DEFAULT(0),loc_EmpCode INT NOT NULL DEFAULT(0)" + string.Format(",{0} INT NOT NULL DEFAULT({1})", (object) "loc_LocationType", (object) 0) + string.Format(",{0} INT NOT NULL DEFAULT({1})", (object) "loc_PermitDiv", (object) 0) + string.Format(",{0} INT NOT NULL DEFAULT({1})", (object) "loc_Level", (object) 0) + string.Format(",{0} INT NOT NULL DEFAULT({1})", (object) "loc_PackUnit", (object) 0) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "loc_Memo", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('{2}')", (object) "loc_UseYn", (object) 1, (object) "Y") + ",loc_InDate DATETIME NULL,loc_InUser INT NOT NULL DEFAULT(0),loc_ModDate DATETIME NULL,loc_ModUser INT NOT NULL DEFAULT(0) PRIMARY KEY(loc_LocationID) ) ;";

    public static string CreateTableMySql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_BASE, (object) TableCodeType.Location) + " loc_LocationID INT NOT NULL,loc_SiteID BIGINT NOT NULL DEFAULT 0,loc_StoreCode INT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "loc_LocationCode", (object) 20) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "loc_LocationName", (object) 20) + ",loc_StorageDiv INT NOT NULL DEFAULT 0,loc_SortNo INT NOT NULL DEFAULT 0,loc_EmpCode INT NOT NULL DEFAULT 0" + string.Format(",{0} INT NOT NULL DEFAULT {1}", (object) "loc_LocationType", (object) 0) + string.Format(",{0} INT NOT NULL DEFAULT {1}", (object) "loc_PermitDiv", (object) 0) + string.Format(",{0} INT NOT NULL DEFAULT {1}", (object) "loc_Level", (object) 0) + string.Format(",{0} INT NOT NULL DEFAULT {1}", (object) "loc_PackUnit", (object) 0) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "loc_Memo", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT '{2}'", (object) "loc_UseYn", (object) 1, (object) "Y") + ",loc_InDate DATETIME NULL,loc_InUser INT NOT NULL DEFAULT 0,loc_ModDate DATETIME NULL,loc_ModUser INT NOT NULL DEFAULT 0 PRIMARY KEY(loc_LocationID) ) ;";

    public bool CreateTable()
    {
      if (this.OleDB.Execute(LocationCreate.CreateTableQuery()))
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
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}';", (object) str, (object) TableCodeType.Location.ToDescription(), (object) TableCodeType.Location));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "로케이션ID", (object) TableCodeType.Location, (object) "loc_LocationID"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "싸이트", (object) TableCodeType.Location, (object) "loc_SiteID"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "지점코드", (object) TableCodeType.Location, (object) "loc_StoreCode"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "로케이션코드", (object) TableCodeType.Location, (object) "loc_LocationCode"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "로케이션명", (object) TableCodeType.Location, (object) "loc_LocationName"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) str, (object) "보관방법 [ETC_TYPE:57](1:상온,2:냉장,3:냉동)", (object) 57, (object) TableCodeType.Location, (object) "loc_StorageDiv"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "순서", (object) TableCodeType.Location, (object) "loc_SortNo"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "담당자", (object) TableCodeType.Location, (object) "loc_EmpCode"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) str, (object) "로케이션타입 [ETC_TYPE:61](1:일반,2:입출고,3:불량)", (object) 61, (object) TableCodeType.Location, (object) "loc_LocationType"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) str, (object) "재고인정구분 [ETC_TYPE:62](1:인정,2:미인정)", (object) 62, (object) TableCodeType.Location, (object) "loc_PermitDiv"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) str, (object) "단계 [ETC_TYPE:63](1:창고,2:지역,3:열,4:단<2:2:2:2, 1:층(F),2:곤도라,3:층,4:열>)", (object) 63, (object) TableCodeType.Location, (object) "loc_Level"));
        stringBuilder.Append(string.Format("{0}{1} 공통({2})', N'schema', N'dbo', N'table', N'{3}', N'column', N'{4}';", (object) str, (object) "묶음단위 [ETC_TYPE:54](1:EA,2:BUNDLE,3:BOX,4:BOM)", (object) 54, (object) TableCodeType.Location, (object) "loc_PackUnit"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "메모", (object) TableCodeType.Location, (object) "loc_Memo"));
        stringBuilder.Append(string.Format("{0}{1}', N'schema', N'dbo', N'table', N'{2}', N'column', N'{3}';", (object) str, (object) "사용상태", (object) TableCodeType.Location, (object) "loc_UseYn"));
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
      TLocation tlocation = this.OleDB.Create<TLocation>();
      if (pSiteID == 1L)
      {
        tlocation.loc_SiteID = pSiteID;
        tlocation.loc_StoreCode = 1;
        tlocation.loc_LocationName = "미설정";
        this.OleDB.Execute(tlocation.InsertQuery());
      }
      return true;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        if (p_rs.IsFieldName("loc_LocationID"))
          this.loc_LocationID = p_rs.GetFieldInt("loc_LocationID");
        if (p_rs.IsFieldName("loc_SiteID"))
          this.loc_SiteID = p_rs.GetFieldLong("loc_SiteID");
        if (p_rs.IsFieldName("loc_StoreCode"))
          this.loc_StoreCode = p_rs.GetFieldInt("loc_StoreCode");
        if (p_rs.IsFieldName("loc_LocationCode"))
          this.loc_LocationCode = p_rs.GetFieldString("loc_LocationCode");
        if (p_rs.IsFieldName("loc_LocationName"))
          this.loc_LocationName = p_rs.GetFieldString("loc_LocationName");
        if (p_rs.IsFieldName("loc_StorageDiv"))
          this.loc_StorageDiv = p_rs.GetFieldInt("loc_StorageDiv");
        if (p_rs.IsFieldName("loc_SortNo"))
          this.loc_SortNo = p_rs.GetFieldInt("loc_SortNo");
        if (p_rs.IsFieldName("loc_EmpCode"))
          this.loc_EmpCode = p_rs.GetFieldInt("loc_EmpCode");
        if (p_rs.IsFieldName("loc_LocationType"))
          this.loc_LocationType = p_rs.GetFieldInt("loc_LocationType");
        if (p_rs.IsFieldName("loc_PermitDiv"))
          this.loc_PermitDiv = p_rs.GetFieldInt("loc_PermitDiv");
        if (p_rs.IsFieldName("loc_Level"))
          this.loc_Level = p_rs.GetFieldInt("loc_Level");
        if (p_rs.IsFieldName("loc_PackUnit"))
          this.loc_PackUnit = p_rs.GetFieldInt("loc_PackUnit");
        if (p_rs.IsFieldName("loc_Memo"))
          this.loc_Memo = p_rs.GetFieldString("loc_Memo");
        if (p_rs.IsFieldName("loc_UseYn"))
          this.loc_UseYn = p_rs.GetFieldString("loc_UseYn");
        if (p_rs.IsFieldName("loc_InDate"))
          this.loc_InDate = p_rs.GetFieldDateTime("loc_InDate");
        if (p_rs.IsFieldName("loc_InUser"))
          this.loc_InUser = p_rs.GetFieldInt("loc_InUser");
        if (p_rs.IsFieldName("loc_ModDate"))
          this.loc_ModDate = p_rs.GetFieldDateTime("loc_ModDate");
        if (p_rs.IsFieldName("loc_ModUser"))
          this.loc_ModUser = p_rs.GetFieldInt("loc_ModUser");
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
        IList<LocationCreate> locationCreateList = this.OleDB.Create<LocationCreate>().SelectAllListE<LocationCreate>((object) new Hashtable()
        {
          {
            (object) "DBMS",
            (object) UbModelBase.UNI_BASE
          }
        });
        if (locationCreateList == null)
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
        int count = locationCreateList.Count;
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        if (locationCreateList.Count > 0)
          Log.Logger.DebugColor("\n--------------------------------------------------------------------------------------------------" + string.Format("\n - {0}({1}) 이전 데이터 작업 시작", (object) TableCodeType.Location.ToDescription(), (object) TableCodeType.Location) + "\n--------------------------------------------------------------------------------------------------");
        StringBuilder stringBuilder = new StringBuilder();
        foreach (LocationCreate locationCreate in (IEnumerable<LocationCreate>) locationCreateList)
        {
          stringBuilder.Append(locationCreate.InsertQuery());
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
        TLocation tlocation = this.OleDB.Create<TLocation>();
        tlocation.loc_SiteID = 1L;
        tlocation.loc_StoreCode = 1;
        tlocation.loc_LocationName = "미설정";
        tlocation.UpdateExInsert();
        if (locationCreateList.Count > 0)
        {
          if (num2 != 100)
            Log.Logger.DebugColor(" pro = 100%");
          Log.Logger.DebugColor(string.Format(" - {0}({1}) 이전 데이터 작업 종료", (object) TableCodeType.Location.ToDescription(), (object) TableCodeType.Location) + "\n--------------------------------------------------------------------------------------------------");
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
