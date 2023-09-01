// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.WeatherBy.WeatherByDay.WeatherByDayCreate
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

namespace UniBiz.Bo.Models.UniSales.WeatherBy.WeatherByDay
{
  public class WeatherByDayCreate : TWeatherByDay, ICreateTable
  {
    public static string CreateTableQuery()
    {
      string tableQuery;
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          tableQuery = WeatherByDayCreate.CreateTableMsSql();
          break;
        case EnumDB.MYSQL:
          tableQuery = WeatherByDayCreate.CreateTableMySql();
          break;
        default:
          tableQuery = string.Empty;
          break;
      }
      return tableQuery;
    }

    public static string CreateTableMsSql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_SALES, (object) TableCodeType.WeatherByDay) + " wbd_Date DATETIME NOT NULL" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "wbd_WeatherLocation", (object) 50) + ",wbd_SiteID BIGINT NOT NULL DEFAULT(0),wbd_SkyCondition INT NOT NULL DEFAULT(0),wbd_RainCondition INT NOT NULL DEFAULT(0),wbd_AvgTemperature MONEY NOT NULL DEFAULT(0.0000),wbd_MinTemperature MONEY NOT NULL DEFAULT(0.0000),wbd_MaxTemperature MONEY NOT NULL DEFAULT(0.0000),wbd_CloudVolume MONEY NOT NULL DEFAULT(0.0000),wbd_RainVolume MONEY NOT NULL DEFAULT(0.0000),wbd_SnowVolume MONEY NOT NULL DEFAULT(0.0000),wbd_Humidity MONEY NOT NULL DEFAULT(0.0000)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "wbd_WindSpeed", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "wbd_Memo", (object) 200) + " PRIMARY KEY(wbd_Date,wbd_WeatherLocation)  ) ;";

    public static string CreateTableMySql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_SALES, (object) TableCodeType.WeatherByDay) + " wbd_Date DATETIME NOT NULL" + string.Format(",{0} VARCHAR({1}) NOT NULL", (object) "wbd_WeatherLocation", (object) 50) + ",wbd_SiteID BIGINT NOT NULL DEFAULT 0,wbd_SkyCondition INT NOT NULL DEFAULT 0,wbd_RainCondition INT NOT NULL DEFAULT 0,wbd_AvgTemperature DECIMAL(19,4) NOT NULL DEFAULT 0.0000,wbd_MinTemperature DECIMAL(19,4) NOT NULL DEFAULT 0.0000,wbd_MaxTemperature DECIMAL(19,4) NOT NULL DEFAULT 0.0000,wbd_CloudVolume DECIMAL(19,4) NOT NULL DEFAULT 0.0000,wbd_RainVolume DECIMAL(19,4) NOT NULL DEFAULT 0.0000,wbd_SnowVolume DECIMAL(19,4) NOT NULL DEFAULT 0.0000,wbd_Humidity DECIMAL(19,4) NOT NULL DEFAULT 0.0000" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "wbd_WindSpeed", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "wbd_Memo", (object) 200) + " PRIMARY KEY(wbd_Date,wbd_WeatherLocation) ) ;";

    public bool CreateTable()
    {
      if (this.OleDB.Execute(WeatherByDayCreate.CreateTableQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public bool DropTable()
    {
      if (this.OleDB.Execute(string.Format("DROP Table {0}..{1}", (object) UbModelBase.UNI_SALES, (object) this.TableCode)))
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
        string str1 = "EXEC " + UbModelBase.UNI_SALES + ".sys.sp_addextendedproperty N'MS_Description', N'";
        string str2 = "', N'schema', N'dbo', N'table', N'";
        stringBuilder.Append(string.Format("{0}{1}{2}{3}';", (object) str1, (object) TableCodeType.WeatherByDay.ToDescription(), (object) str2, (object) TableCodeType.WeatherByDay));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "일자", (object) str2, (object) TableCodeType.WeatherByDay, (object) "wbd_Date"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "지역코드", (object) str2, (object) TableCodeType.WeatherByDay, (object) "wbd_WeatherLocation"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "싸이트", (object) str2, (object) TableCodeType.WeatherByDay, (object) "wbd_SiteID"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "하늘상태", (object) str2, (object) TableCodeType.WeatherByDay, (object) "wbd_SkyCondition"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "강수상태", (object) str2, (object) TableCodeType.WeatherByDay, (object) "wbd_RainCondition"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "평균기온", (object) str2, (object) TableCodeType.WeatherByDay, (object) "wbd_AvgTemperature"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "최저기온", (object) str2, (object) TableCodeType.WeatherByDay, (object) "wbd_MinTemperature"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "최고기온", (object) str2, (object) TableCodeType.WeatherByDay, (object) "wbd_MaxTemperature"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "구름양", (object) str2, (object) TableCodeType.WeatherByDay, (object) "wbd_CloudVolume"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "강우량(mm)", (object) str2, (object) TableCodeType.WeatherByDay, (object) "wbd_RainVolume"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "적설량(mm)", (object) str2, (object) TableCodeType.WeatherByDay, (object) "wbd_SnowVolume"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "습도(%)", (object) str2, (object) TableCodeType.WeatherByDay, (object) "wbd_Humidity"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "풍향속도", (object) str2, (object) TableCodeType.WeatherByDay, (object) "wbd_WindSpeed"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "특이사항", (object) str2, (object) TableCodeType.WeatherByDay, (object) "wbd_Memo"));
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
        if (p_rs.IsFieldName("wbd_Date"))
          this.wbd_Date = p_rs.GetFieldDateTime("wbd_Date");
        if (p_rs.IsFieldName("wbd_WeatherLocation"))
          this.wbd_WeatherLocation = p_rs.GetFieldString("wbd_WeatherLocation");
        if (p_rs.IsFieldName("wbd_SiteID"))
          this.wbd_SiteID = p_rs.GetFieldLong("wbd_SiteID");
        if (p_rs.IsFieldName("wbd_SkyCondition"))
          this.wbd_SkyCondition = p_rs.GetFieldInt("wbd_SkyCondition");
        if (p_rs.IsFieldName("wbd_RainCondition"))
          this.wbd_RainCondition = p_rs.GetFieldInt("wbd_RainCondition");
        if (p_rs.IsFieldName("wbd_AvgTemperature"))
          this.wbd_AvgTemperature = p_rs.GetFieldDouble("wbd_AvgTemperature");
        if (p_rs.IsFieldName("wbd_MinTemperature"))
          this.wbd_MinTemperature = p_rs.GetFieldDouble("wbd_MinTemperature");
        if (p_rs.IsFieldName("wbd_MaxTemperature"))
          this.wbd_MaxTemperature = p_rs.GetFieldDouble("wbd_MaxTemperature");
        if (p_rs.IsFieldName("wbd_CloudVolume"))
          this.wbd_CloudVolume = p_rs.GetFieldDouble("wbd_CloudVolume");
        if (p_rs.IsFieldName("wbd_RainVolume"))
          this.wbd_RainVolume = p_rs.GetFieldDouble("wbd_RainVolume");
        if (p_rs.IsFieldName("wbd_SnowVolume"))
          this.wbd_SnowVolume = p_rs.GetFieldDouble("wbd_SnowVolume");
        if (p_rs.IsFieldName("wbd_Humidity"))
          this.wbd_Humidity = p_rs.GetFieldDouble("wbd_Humidity");
        if (p_rs.IsFieldName("wbd_WindSpeed"))
          this.wbd_WindSpeed = p_rs.GetFieldString("wbd_WindSpeed");
        if (p_rs.IsFieldName("wbd_Memo"))
          this.wbd_Memo = p_rs.GetFieldString("wbd_Memo");
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
        IList<WeatherByDayCreate> weatherByDayCreateList = this.OleDB.Create<WeatherByDayCreate>().SelectAllListE<WeatherByDayCreate>((object) new Hashtable()
        {
          {
            (object) "DBMS",
            (object) UbModelBase.UNI_SALES
          }
        });
        if (weatherByDayCreateList == null)
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
        int count = weatherByDayCreateList.Count;
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        if (weatherByDayCreateList.Count > 0)
          Log.Logger.DebugColor("\n--------------------------------------------------------------------------------------------------" + string.Format("\n - {0}({1}) 이전 데이터 작업 시작", (object) TableCodeType.WeatherByDay.ToDescription(), (object) TableCodeType.WeatherByDay) + "\n--------------------------------------------------------------------------------------------------");
        StringBuilder stringBuilder = new StringBuilder();
        foreach (WeatherByDayCreate weatherByDayCreate in (IEnumerable<WeatherByDayCreate>) weatherByDayCreateList)
        {
          stringBuilder.Append(weatherByDayCreate.InsertQuery());
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
        if (weatherByDayCreateList.Count > 0)
        {
          if (num2 != 100)
            Log.Logger.DebugColor(" pro = 100%");
          Log.Logger.DebugColor(string.Format(" - {0}({1}) 이전 데이터 작업 종료", (object) TableCodeType.WeatherByDay.ToDescription(), (object) TableCodeType.WeatherByDay) + "\n--------------------------------------------------------------------------------------------------");
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
