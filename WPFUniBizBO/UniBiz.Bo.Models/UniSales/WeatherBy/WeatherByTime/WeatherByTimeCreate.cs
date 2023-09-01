// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.WeatherBy.WeatherByTime.WeatherByTimeCreate
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

namespace UniBiz.Bo.Models.UniSales.WeatherBy.WeatherByTime
{
  public class WeatherByTimeCreate : TWeatherByTime, ICreateTable
  {
    public static string CreateTableQuery()
    {
      string tableQuery;
      switch (DbQueryHelper.DbTypeNotNull())
      {
        case EnumDB.MSSQL:
          tableQuery = WeatherByTimeCreate.CreateTableMsSql();
          break;
        case EnumDB.MYSQL:
          tableQuery = WeatherByTimeCreate.CreateTableMySql();
          break;
        default:
          tableQuery = string.Empty;
          break;
      }
      return tableQuery;
    }

    public static string CreateTableMsSql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_SALES, (object) TableCodeType.WeatherByTime) + " wbt_Date DATETIME NOT NULL,wbt_Hour INT NOT NULL" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "wbt_WeatherLocation", (object) 50) + ",wbt_SiteID BIGINT NOT NULL DEFAULT(0),wbt_CurrentTemperature MONEY NOT NULL DEFAULT(0.0000),wbt_MaxTemperature MONEY NOT NULL DEFAULT(0.0000),wbt_MinTemperature MONEY NOT NULL DEFAULT(0.0000),wbt_SkyCondition INT NOT NULL DEFAULT(0),wbt_RainCondition INT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "wbt_WeatherKor", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "wbt_WeatherEng", (object) 100) + ",wbt_RainfallRate MONEY NOT NULL DEFAULT(0.0000),wbt_Hour12RainVolume MONEY NOT NULL DEFAULT(0.0000),wbt_Hour12SnowVolume MONEY NOT NULL DEFAULT(0.0000),wbt_WindSpeed MONEY NOT NULL DEFAULT(0.0000),wbt_WindDirection INT NOT NULL DEFAULT(0)" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "wbt_WinDirectionKor", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT('')", (object) "wbt_WinDirectionEng", (object) 100) + ",wbt_Humidity MONEY NOT NULL DEFAULT(0.0000),wbt_Hour6RainVolume MONEY NOT NULL DEFAULT(0.0000),wbt_Hour6SnowVolume MONEY NOT NULL DEFAULT(0.0000) PRIMARY KEY(wbt_Date,wbt_Hour,wbt_WeatherLocation)  ) ;";

    public static string CreateTableMySql() => string.Format("CREATE TABLE {0}..{1} (", (object) UbModelBase.UNI_SALES, (object) TableCodeType.WeatherByTime) + " wbt_Date DATETIME NOT NULL,wbt_Hour INT NOT NULL" + string.Format(",{0} VARCHAR({1}) NOT NULL", (object) "wbt_WeatherLocation", (object) 50) + ",wbt_SiteID BIGINT NOT NULL DEFAULT 0,wbt_CurrentTemperature DECIMAL(19,4) NOT NULL DEFAULT 0.0000,wbt_MaxTemperature DECIMAL(19,4) NOT NULL DEFAULT 0.0000,wbt_MinTemperature DECIMAL(19,4) NOT NULL DEFAULT 0.0000,wbt_SkyCondition INT NOT NULL DEFAULT 0,wbt_RainCondition INT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "wbt_WeatherKor", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "wbt_WeatherEng", (object) 100) + ",wbt_RainfallRate DECIMAL(19,4) NOT NULL DEFAULT 0.0000,wbt_Hour12RainVolume DECIMAL(19,4) NOT NULL DEFAULT 0.0000,wbt_Hour12SnowVolume DECIMAL(19,4) NOT NULL DEFAULT 0.0000,wbt_WindSpeed DECIMAL(19,4) NOT NULL DEFAULT 0.0000,wbt_WindDirection INT NOT NULL DEFAULT 0" + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "wbt_WinDirectionKor", (object) 100) + string.Format(",{0} VARCHAR({1}) NOT NULL DEFAULT ''", (object) "wbt_WinDirectionEng", (object) 100) + ",wbt_Humidity DECIMAL(19,4) NOT NULL DEFAULT 0.0000,wbt_Hour6RainVolume DECIMAL(19,4) NOT NULL DEFAULT 0.0000,wbt_Hour6SnowVolume DECIMAL(19,4) NOT NULL DEFAULT 0.0000 PRIMARY KEY(wbt_Date,wbt_Hour,wbt_WeatherLocation) ) ;";

    public bool CreateTable()
    {
      if (this.OleDB.Execute(WeatherByTimeCreate.CreateTableQuery()))
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
        stringBuilder.Append(string.Format("{0}{1}{2}{3}';", (object) str1, (object) TableCodeType.WeatherByTime.ToDescription(), (object) str2, (object) TableCodeType.WeatherByTime));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "일자", (object) str2, (object) TableCodeType.WeatherByTime, (object) "wbt_Date"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "시간", (object) str2, (object) TableCodeType.WeatherByTime, (object) "wbt_Hour"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "지역코드", (object) str2, (object) TableCodeType.WeatherByTime, (object) "wbt_WeatherLocation"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "싸이트", (object) str2, (object) TableCodeType.WeatherByTime, (object) "wbt_SiteID"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "현재온도", (object) str2, (object) TableCodeType.WeatherByTime, (object) "wbt_CurrentTemperature"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "최고온도", (object) str2, (object) TableCodeType.WeatherByTime, (object) "wbt_MaxTemperature"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "최저온도", (object) str2, (object) TableCodeType.WeatherByTime, (object) "wbt_MinTemperature"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "하늘", (object) str2, (object) TableCodeType.WeatherByTime, (object) "wbt_SkyCondition"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "강수", (object) str2, (object) TableCodeType.WeatherByTime, (object) "wbt_RainCondition"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "날씨", (object) str2, (object) TableCodeType.WeatherByTime, (object) "wbt_WeatherKor"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "날씨(ENG)", (object) str2, (object) TableCodeType.WeatherByTime, (object) "wbt_WeatherEng"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "강수확률", (object) str2, (object) TableCodeType.WeatherByTime, (object) "wbt_RainfallRate"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "12시간예상강수량 ", (object) str2, (object) TableCodeType.WeatherByTime, (object) "wbt_Hour12RainVolume"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "12시간예상적설량", (object) str2, (object) TableCodeType.WeatherByTime, (object) "wbt_Hour12SnowVolume"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "풍속 ", (object) str2, (object) TableCodeType.WeatherByTime, (object) "wbt_WindSpeed"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "풍향 ", (object) str2, (object) TableCodeType.WeatherByTime, (object) "wbt_WindDirection"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "풍향_", (object) str2, (object) TableCodeType.WeatherByTime, (object) "wbt_WinDirectionKor"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "풍향_(ENG)", (object) str2, (object) TableCodeType.WeatherByTime, (object) "wbt_WinDirectionEng"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "습도", (object) str2, (object) TableCodeType.WeatherByTime, (object) "wbt_Humidity"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "6시간예상강수량", (object) str2, (object) TableCodeType.WeatherByTime, (object) "wbt_Hour6RainVolume"));
        stringBuilder.Append(string.Format("{0}{1}{2}{3}', N'column', N'{4}';", (object) str1, (object) "6시간예상적설량", (object) str2, (object) TableCodeType.WeatherByTime, (object) "wbt_Hour6SnowVolume"));
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
        if (p_rs.IsFieldName("wbt_Date"))
          this.wbt_Date = p_rs.GetFieldDateTime("wbt_Date");
        if (p_rs.IsFieldName("wbt_Hour"))
          this.wbt_Hour = p_rs.GetFieldInt("wbt_Hour");
        if (p_rs.IsFieldName("wbt_WeatherLocation"))
          this.wbt_WeatherLocation = p_rs.GetFieldString("wbt_WeatherLocation");
        if (p_rs.IsFieldName("wbt_SiteID"))
          this.wbt_SiteID = p_rs.GetFieldLong("wbt_SiteID");
        if (p_rs.IsFieldName("wbt_CurrentTemperature"))
          this.wbt_CurrentTemperature = p_rs.GetFieldDouble("wbt_CurrentTemperature");
        if (p_rs.IsFieldName("wbt_MaxTemperature"))
          this.wbt_MaxTemperature = p_rs.GetFieldDouble("wbt_MaxTemperature");
        if (p_rs.IsFieldName("wbt_MinTemperature"))
          this.wbt_MinTemperature = p_rs.GetFieldDouble("wbt_MinTemperature");
        if (p_rs.IsFieldName("wbt_SkyCondition"))
          this.wbt_SkyCondition = p_rs.GetFieldInt("wbt_SkyCondition");
        if (p_rs.IsFieldName("wbt_RainCondition"))
          this.wbt_RainCondition = p_rs.GetFieldInt("wbt_RainCondition");
        if (p_rs.IsFieldName("wbt_WeatherKor"))
          this.wbt_WeatherKor = p_rs.GetFieldString("wbt_WeatherKor");
        if (p_rs.IsFieldName("wbt_WeatherEng"))
          this.wbt_WeatherEng = p_rs.GetFieldString("wbt_WeatherEng");
        if (p_rs.IsFieldName("wbt_RainfallRate"))
          this.wbt_RainfallRate = p_rs.GetFieldDouble("wbt_RainfallRate");
        if (p_rs.IsFieldName("wbt_Hour12RainVolume"))
          this.wbt_Hour12RainVolume = p_rs.GetFieldDouble("wbt_Hour12RainVolume");
        if (p_rs.IsFieldName("wbt_Hour12SnowVolume"))
          this.wbt_Hour12SnowVolume = p_rs.GetFieldDouble("wbt_Hour12SnowVolume");
        if (p_rs.IsFieldName("wbt_WindSpeed"))
          this.wbt_WindSpeed = p_rs.GetFieldDouble("wbt_WindSpeed");
        if (p_rs.IsFieldName("wbt_WindDirection"))
          this.wbt_WindDirection = p_rs.GetFieldInt("wbt_WindDirection");
        if (p_rs.IsFieldName("wbt_WinDirectionKor"))
          this.wbt_WinDirectionKor = p_rs.GetFieldString("wbt_WinDirectionKor");
        if (p_rs.IsFieldName("wbt_WinDirectionEng"))
          this.wbt_WinDirectionEng = p_rs.GetFieldString("wbt_WinDirectionEng");
        if (p_rs.IsFieldName("wbt_Humidity"))
          this.wbt_Humidity = p_rs.GetFieldDouble("wbt_Humidity");
        if (p_rs.IsFieldName("wbt_Hour6RainVolume"))
          this.wbt_Hour6RainVolume = p_rs.GetFieldDouble("wbt_Hour6RainVolume");
        if (p_rs.IsFieldName("wbt_Hour6SnowVolume"))
          this.wbt_Hour6SnowVolume = p_rs.GetFieldDouble("wbt_Hour6SnowVolume");
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
        IList<WeatherByTimeCreate> weatherByTimeCreateList = this.OleDB.Create<WeatherByTimeCreate>().SelectAllListE<WeatherByTimeCreate>((object) new Hashtable()
        {
          {
            (object) "DBMS",
            (object) UbModelBase.UNI_SALES
          }
        });
        if (weatherByTimeCreateList == null)
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
        int count = weatherByTimeCreateList.Count;
        int num1 = 0;
        int num2 = 0;
        int num3 = 0;
        if (weatherByTimeCreateList.Count > 0)
          Log.Logger.DebugColor("\n--------------------------------------------------------------------------------------------------" + string.Format("\n - {0}({1}) 이전 데이터 작업 시작", (object) TableCodeType.WeatherByTime.ToDescription(), (object) TableCodeType.WeatherByTime) + "\n--------------------------------------------------------------------------------------------------");
        StringBuilder stringBuilder = new StringBuilder();
        foreach (WeatherByTimeCreate weatherByTimeCreate in (IEnumerable<WeatherByTimeCreate>) weatherByTimeCreateList)
        {
          stringBuilder.Append(weatherByTimeCreate.InsertQuery());
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
        if (weatherByTimeCreateList.Count > 0)
        {
          if (num2 != 100)
            Log.Logger.DebugColor(" pro = 100%");
          Log.Logger.DebugColor(string.Format(" - {0}({1}) 이전 데이터 작업 종료", (object) TableCodeType.WeatherByTime.ToDescription(), (object) TableCodeType.WeatherByTime) + "\n--------------------------------------------------------------------------------------------------");
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
