// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.DbQueryHelper
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;

namespace UniBiz.Bo.Models.Converter
{
  public static class DbQueryHelper
  {
    public static EnumDB DbType;
    public const string IDS_DB_NAME_BRIDGE_MSSQL = "..";
    public const string IDS_DB_NAME_BRIDGE_MYSQL = ".";
    public const string IDS_ISNULL_MSSQL = "ISNULL";
    public const string IDS_ISNULL_MYSQL = "IFNULL";
    public const string IDS_WITH_NOLOCK_MSSQL = "WITH (NOLOCK)";
    public const string IDS_LEN_MSSQL = "LEN";
    public const string IDS_LEN_MYSQL = "LENGTH";
    public const string IDS_GET_DATE_MSSQL = "GETDATE()";
    public const string IDS_GET_DATE_MYSQL = "NOW()";

    public static EnumDB DbTypeNotNull() => DbQueryHelper.DbType != EnumDB.NONE ? DbQueryHelper.DbType : EnumDB.MSSQL;

    public static EnumDB ToDBType(int p_value)
    {
      foreach (EnumDB dbType in Enum.GetValues(typeof (EnumDB)))
      {
        if (dbType == (EnumDB) p_value)
          return dbType;
      }
      return EnumDB.MSSQL;
    }

    public static string ToDBNameBridge(EnumDB pDB = EnumDB.NONE)
    {
      if (pDB == EnumDB.NONE)
        pDB = DbQueryHelper.DbTypeNotNull();
      return pDB == EnumDB.MSSQL ? ".." : (pDB == EnumDB.MYSQL ? "." : "..");
    }

    public static string ToDBNameBridge(string pDBName, EnumDB pDB = EnumDB.NONE)
    {
      if (pDB == EnumDB.NONE)
        pDB = DbQueryHelper.DbTypeNotNull();
      return pDBName + DbQueryHelper.ToDBNameBridge(pDB);
    }

    public static string ToIsNULL(EnumDB pDB = EnumDB.NONE)
    {
      if (pDB == EnumDB.NONE)
        pDB = DbQueryHelper.DbTypeNotNull();
      return pDB == EnumDB.MSSQL ? "ISNULL" : (pDB == EnumDB.MYSQL ? "IFNULL" : string.Empty);
    }

    public static string ToWhereIsNULL(bool pIsNULL, EnumDB pDB = EnumDB.NONE)
    {
      if (pDB == EnumDB.NONE)
        pDB = DbQueryHelper.DbTypeNotNull();
      return pDB == EnumDB.MSSQL ? "IS " + (pIsNULL ? string.Empty : "NOT") + " NULL" : (pDB == EnumDB.MYSQL ? "IS " + (pIsNULL ? string.Empty : "NOT") + " NULL" : string.Empty);
    }

    public static string ToWithNolock(EnumDB pDB = EnumDB.NONE)
    {
      if (pDB == EnumDB.NONE)
        pDB = DbQueryHelper.DbTypeNotNull();
      return pDB != EnumDB.MSSQL ? string.Empty : "WITH (NOLOCK)";
    }

    public static string ToLen(EnumDB pDB = EnumDB.NONE)
    {
      if (pDB == EnumDB.NONE)
        pDB = DbQueryHelper.DbTypeNotNull();
      return pDB == EnumDB.MSSQL ? "LEN" : (pDB == EnumDB.MYSQL ? "LENGTH" : string.Empty);
    }

    public static string ToStrAdd(this string pColStart, string pColEnd, EnumDB pDB = EnumDB.NONE)
    {
      if (pDB == EnumDB.NONE)
        pDB = DbQueryHelper.DbTypeNotNull();
      string strAdd;
      if (pDB != EnumDB.MSSQL)
      {
        if (pDB == EnumDB.MYSQL)
          strAdd = "CONCAT(" + pColStart + " , " + pColEnd + ")";
        else
          strAdd = string.Empty;
      }
      else
        strAdd = pColStart + " + " + pColEnd;
      return strAdd;
    }

    public static string ToStrAdd(EnumDB pDB, string pKeyWordDivision, params string[] pCols)
    {
      if (pDB == EnumDB.NONE)
        pDB = DbQueryHelper.DbTypeNotNull();
      string str = pDB == EnumDB.MSSQL ? " + " : (pDB == EnumDB.MYSQL ? ", " : string.Empty);
      if (pCols == null || pCols.Length == 0)
        return string.Empty;
      string strAdd;
      switch (pDB)
      {
        case EnumDB.MSSQL:
          strAdd = string.Join(str + pKeyWordDivision + str, pCols);
          break;
        case EnumDB.MYSQL:
          strAdd = "CONCAT(" + string.Join(str + pKeyWordDivision + str, pCols) + ")";
          break;
        default:
          strAdd = string.Empty;
          break;
      }
      return strAdd;
    }

    public static string ToDate(EnumDB pDB = EnumDB.NONE)
    {
      if (pDB == EnumDB.NONE)
        pDB = DbQueryHelper.DbTypeNotNull();
      return pDB == EnumDB.MSSQL ? "GETDATE()" : (pDB == EnumDB.MYSQL ? "NOW()" : string.Empty);
    }

    public static string DateToStr(this string pValue, EnumDbDateType pType, EnumDB pDB = EnumDB.NONE)
    {
      if (pDB == EnumDB.NONE)
        pDB = DbQueryHelper.DbTypeNotNull();
      return pDB == EnumDB.MSSQL ? pValue.MsSqlDateToStr(pType) : (pDB == EnumDB.MYSQL ? pValue.MySqlDateToStr(pType) : string.Empty);
    }

    public static string MsSqlDateToStr(this string pValue, EnumDbDateType pType)
    {
      string str;
      switch (pType)
      {
        case EnumDbDateType.YYYY_MM_DD:
          str = "CONVERT(CHAR(10)," + pValue + ",23)";
          break;
        case EnumDbDateType.YYYYMMDD:
          str = "CONVERT(CHAR(8)," + pValue + ",112)";
          break;
        case EnumDbDateType.YYYYMM:
          str = "CONVERT(CHAR(6)," + pValue + ",112)";
          break;
        case EnumDbDateType.YYYY_MM:
          str = "CONVERT(CHAR(7)," + pValue + ",23)";
          break;
        case EnumDbDateType.HH_MM_SS:
          str = "CONVERT(CHAR(8)," + pValue + ",8)";
          break;
        case EnumDbDateType.HH_MM:
          str = "CONVERT(CHAR(5)," + pValue + ",8)";
          break;
        case EnumDbDateType.HH:
          str = "CONVERT(CHAR(2)," + pValue + ",8)";
          break;
        case EnumDbDateType.MM:
          str = "SUBSTRING(CONVERT(CHAR(5)," + pValue + ",8),4,2)";
          break;
        default:
          str = string.Empty;
          break;
      }
      return str;
    }

    public static string MySqlDateToStr(this string pValue, EnumDbDateType pType)
    {
      string str;
      switch (pType)
      {
        case EnumDbDateType.YYYY_MM_DD:
          str = "DATE_FORMAT(" + pValue + ",'%Y-%m-%d')";
          break;
        case EnumDbDateType.YYYYMMDD:
          str = "DATE_FORMAT(" + pValue + ",'%Y%m%d')";
          break;
        case EnumDbDateType.YYYYMM:
          str = "DATE_FORMAT(" + pValue + ",'%Y%m')";
          break;
        case EnumDbDateType.YYYY_MM:
          str = "DATE_FORMAT(" + pValue + ",'%Y-%m')";
          break;
        case EnumDbDateType.HH_MM_SS:
          str = "DATE_FORMAT(" + pValue + ",'%T')";
          break;
        case EnumDbDateType.HH_MM:
          str = "DATE_FORMAT(" + pValue + ",'%H:%i')";
          break;
        case EnumDbDateType.HH:
          str = "DATE_FORMAT(" + pValue + ",'%H')";
          break;
        case EnumDbDateType.MM:
          str = "DATE_FORMAT(" + pValue + ",'%i')";
          break;
        default:
          str = string.Empty;
          break;
      }
      return str;
    }

    public static string ToDateTime(this string pValue, EnumDB pDB = EnumDB.NONE)
    {
      if (pDB == EnumDB.NONE)
        pDB = DbQueryHelper.DbTypeNotNull();
      return pDB == EnumDB.MSSQL ? "CONVERT(DATETIME," + pValue + ")" : (pDB == EnumDB.MYSQL ? "STR_TO_DATE({pValue},'%Y-%m-%d %H%i%s')" : string.Empty);
    }

    public static string ToInt(this string pValue, EnumDB pDB = EnumDB.NONE)
    {
      if (pDB == EnumDB.NONE)
        pDB = DbQueryHelper.DbTypeNotNull();
      return pDB == EnumDB.MSSQL ? "CONVERT(INT," + pValue + ")" : (pDB == EnumDB.MYSQL ? "CAST(" + pValue + " AS INT)" : string.Empty);
    }

    public static string ToStr(this int pValue, EnumDB pDB = EnumDB.NONE)
    {
      if (pDB == EnumDB.NONE)
        pDB = DbQueryHelper.DbTypeNotNull();
      return pDB == EnumDB.MSSQL ? string.Format("CONVERT(VARCHAR,{0})", (object) pValue) : (pDB == EnumDB.MYSQL ? string.Format("CAST({0} AS CHAR)", (object) pValue) : string.Empty);
    }

    public static string ToStr(this string pValue, EnumDB pDB = EnumDB.NONE)
    {
      if (pDB == EnumDB.NONE)
        pDB = DbQueryHelper.DbTypeNotNull();
      return pDB == EnumDB.MSSQL ? "CONVERT(VARCHAR," + pValue + ")" : (pDB == EnumDB.MYSQL ? "CAST(" + pValue + " AS CHAR)" : string.Empty);
    }

    public static string ToStr(this string pValue, int pLen, EnumDB pDB = EnumDB.NONE)
    {
      if (pDB == EnumDB.NONE)
        pDB = DbQueryHelper.DbTypeNotNull();
      return pDB == EnumDB.MSSQL ? string.Format("CONVERT(CHAR({0}),{1})", (object) pLen, (object) pValue) : (pDB == EnumDB.MYSQL ? "CAST(" + pValue + " AS CHAR)" : string.Empty);
    }

    public static string ToMoney(this string pValue, EnumDB pDB = EnumDB.NONE)
    {
      if (pDB == EnumDB.NONE)
        pDB = DbQueryHelper.DbTypeNotNull();
      return pDB == EnumDB.MSSQL ? "CONVERT(decimal(19,4)," + pValue + ")" : (pDB == EnumDB.MYSQL ? "CAST(" + pValue + " AS decimal(19,4))" : string.Empty);
    }

    public static string ToMoney(this double pValue, EnumDB pDB = EnumDB.NONE)
    {
      if (pDB == EnumDB.NONE)
        pDB = DbQueryHelper.DbTypeNotNull();
      return pDB == EnumDB.MSSQL ? string.Format("CONVERT(decimal(19,4),{0})", (object) pValue) : (pDB == EnumDB.MYSQL ? string.Format("CAST({0} AS decimal(19,4))", (object) pValue) : string.Empty);
    }

    public static string ToDatePart(this string pValue, EnumDbPartType pDBPartType, EnumDB pDB = EnumDB.NONE)
    {
      if (pDB == EnumDB.NONE)
        pDB = DbQueryHelper.DbTypeNotNull();
      return pDB == EnumDB.MSSQL ? pValue.MsSqlToDatePart(pDBPartType) : (pDB == EnumDB.MYSQL ? pValue.MySqlToDatePart(pDBPartType) : string.Empty);
    }

    public static string MsSqlToDatePart(this string pValue, EnumDbPartType pDBPartType)
    {
      string datePart;
      switch (pDBPartType)
      {
        case EnumDbPartType.YEAR:
          datePart = "DATEPART(YEAR, " + pValue + ")";
          break;
        case EnumDbPartType.HALF:
          datePart = "CASE WHEN DATEPART(MONTH, " + pValue + ") BETWEEN 1 AND 6 THEN '상반기' ELSE '하반기' END";
          break;
        case EnumDbPartType.QUARTER:
          datePart = "DATEPART(Q, " + pValue + ")";
          break;
        case EnumDbPartType.MONTH:
          datePart = "DATEPART(MONTH, " + pValue + ")";
          break;
        case EnumDbPartType.DAY:
          datePart = "DATEPART(DAY, " + pValue + ")";
          break;
        case EnumDbPartType.WEEK_OF_YEAR:
          datePart = "DATEPART(WK, " + pValue + ")";
          break;
        case EnumDbPartType.WEEK_OF_MONTH:
          datePart = "DATEPART(WK, " + pValue + ") - DATEPART(WK, LEFT(CONVERT(VARCHAR, " + pValue + ", 112), 6) + '01') + 1";
          break;
        case EnumDbPartType.WEEK_OF_DAY:
          datePart = "DATEPART(DW, " + pValue + ")";
          break;
        case EnumDbPartType.WEEK_OF_DAY_KOR:
          datePart = "DATENAME(W, " + pValue + ")";
          break;
        case EnumDbPartType.DAY_OF_YEAR:
          datePart = "DATEPART(DY, " + pValue + ")";
          break;
        default:
          datePart = string.Empty;
          break;
      }
      return datePart;
    }

    public static string MySqlToDatePart(this string pValue, EnumDbPartType pDBPartType)
    {
      string datePart;
      switch (pDBPartType)
      {
        case EnumDbPartType.YEAR:
          datePart = "YEAR(" + pValue + ")";
          break;
        case EnumDbPartType.HALF:
          datePart = string.Empty;
          break;
        case EnumDbPartType.QUARTER:
          datePart = "QUARTER(" + pValue + ")";
          break;
        case EnumDbPartType.MONTH:
          datePart = "MONTH(" + pValue + ")";
          break;
        case EnumDbPartType.DAY:
          datePart = "DAYOFMONTH(" + pValue + ")";
          break;
        case EnumDbPartType.WEEK_OF_YEAR:
          datePart = "WEEKOFYEAR(" + pValue + ")";
          break;
        case EnumDbPartType.WEEK_OF_MONTH:
          datePart = string.Empty;
          break;
        case EnumDbPartType.WEEK_OF_DAY:
          datePart = "DAYOFWEEK(" + pValue + ")";
          break;
        case EnumDbPartType.WEEK_OF_DAY_KOR:
          datePart = "DAYNAME(" + pValue + ")";
          break;
        case EnumDbPartType.DAY_OF_YEAR:
          datePart = "DAYOFYEAR(" + pValue + ")";
          break;
        default:
          datePart = string.Empty;
          break;
      }
      return datePart;
    }

    public static string DateAdd(
      this string pOrgin,
      int pAddData,
      EnumDbAddType pAddType,
      EnumDB pDB = EnumDB.NONE)
    {
      if (pDB == EnumDB.NONE)
        pDB = DbQueryHelper.DbTypeNotNull();
      return pDB == EnumDB.MSSQL ? pOrgin.MsSqlDateAdd(pAddData, pAddType) : (pDB == EnumDB.MYSQL ? pOrgin.MySqlDateAdd(pAddData, pAddType) : string.Empty);
    }

    public static string DateAdd(
      this string pOrgin,
      string pAddDbColumn,
      EnumDbAddType pAddType,
      EnumDB pDB = EnumDB.NONE)
    {
      if (pDB == EnumDB.NONE)
        pDB = DbQueryHelper.DbTypeNotNull();
      return pDB == EnumDB.MSSQL ? pOrgin.MsSqlDateAdd(pAddDbColumn, pAddType) : (pDB == EnumDB.MYSQL ? pOrgin.MySqlDateAdd(pAddDbColumn, pAddType) : string.Empty);
    }

    public static string MsSqlDateAdd(this string pOrgin, int pAddData, EnumDbAddType pAddType)
    {
      string str;
      switch (pAddType)
      {
        case EnumDbAddType.SECOND:
          str = string.Format("DATEADD(SECOND,{0},{1})", (object) pAddData, (object) pOrgin);
          break;
        case EnumDbAddType.MINUTE:
          str = string.Format("DATEADD(MINUTE,{0},{1})", (object) pAddData, (object) pOrgin);
          break;
        case EnumDbAddType.HOUR:
          str = string.Format("DATEADD(HOUR,{0},{1})", (object) pAddData, (object) pOrgin);
          break;
        case EnumDbAddType.DAY:
          str = string.Format("DATEADD(DAY,{0},{1})", (object) pAddData, (object) pOrgin);
          break;
        case EnumDbAddType.WEEK:
          str = string.Format("DATEADD(WEEK,{0},{1})", (object) pAddData, (object) pOrgin);
          break;
        case EnumDbAddType.MONTH:
          str = string.Format("DATEADD(MONTH,{0},{1})", (object) pAddData, (object) pOrgin);
          break;
        case EnumDbAddType.QUARTER:
          str = string.Format("DATEADD(QUARTER,{0},{1})", (object) pAddData, (object) pOrgin);
          break;
        case EnumDbAddType.YEAR:
          str = string.Format("DATEADD(YEAR,{0},{1})", (object) pAddData, (object) pOrgin);
          break;
        default:
          str = string.Empty;
          break;
      }
      return str;
    }

    public static string MsSqlDateAdd(this string pOrgin, string pAddData, EnumDbAddType pAddType)
    {
      string str;
      switch (pAddType)
      {
        case EnumDbAddType.SECOND:
          str = "DATEADD(SECOND," + pAddData + "," + pOrgin + ")";
          break;
        case EnumDbAddType.MINUTE:
          str = "DATEADD(MINUTE," + pAddData + "," + pOrgin + ")";
          break;
        case EnumDbAddType.HOUR:
          str = "DATEADD(HOUR," + pAddData + "," + pOrgin + ")";
          break;
        case EnumDbAddType.DAY:
          str = "DATEADD(DAY," + pAddData + "," + pOrgin + ")";
          break;
        case EnumDbAddType.WEEK:
          str = "DATEADD(WEEK," + pAddData + "," + pOrgin + ")";
          break;
        case EnumDbAddType.MONTH:
          str = "DATEADD(MONTH," + pAddData + "," + pOrgin + ")";
          break;
        case EnumDbAddType.QUARTER:
          str = "DATEADD(QUARTER," + pAddData + "," + pOrgin + ")";
          break;
        case EnumDbAddType.YEAR:
          str = "DATEADD(YEAR," + pAddData + "," + pOrgin + ")";
          break;
        default:
          str = string.Empty;
          break;
      }
      return str;
    }

    public static string MySqlDateAdd(this string pOrgin, int pAddData, EnumDbAddType pAddType)
    {
      string str;
      switch (pAddType)
      {
        case EnumDbAddType.SECOND:
          str = string.Format("STR_TO_DATE(DATE_ADD({0},INTERVAL {1} SECOND),'%Y-%m-%d %H:%i:%s')", (object) pOrgin, (object) pAddData);
          break;
        case EnumDbAddType.MINUTE:
          str = string.Format("STR_TO_DATE(DATE_ADD({0},INTERVAL {1} MINUTE),'%Y-%m-%d %H:%i:%s')", (object) pOrgin, (object) pAddData);
          break;
        case EnumDbAddType.HOUR:
          str = string.Format("STR_TO_DATE(DATE_ADD({0},INTERVAL {1} HOUR),'%Y-%m-%d %H:%i:%s')", (object) pOrgin, (object) pAddData);
          break;
        case EnumDbAddType.DAY:
          str = string.Format("STR_TO_DATE(DATE_ADD({0},INTERVAL {1} DAY),'%Y-%m-%d %H:%i:%s')", (object) pOrgin, (object) pAddData);
          break;
        case EnumDbAddType.WEEK:
          str = string.Format("STR_TO_DATE(DATE_ADD({0},INTERVAL {1} WEEK),'%Y-%m-%d %H:%i:%s')", (object) pOrgin, (object) pAddData);
          break;
        case EnumDbAddType.MONTH:
          str = string.Format("STR_TO_DATE(DATE_ADD({0},INTERVAL {1} MONTH),'%Y-%m-%d %H:%i:%s')", (object) pOrgin, (object) pAddData);
          break;
        case EnumDbAddType.QUARTER:
          str = string.Format("STR_TO_DATE(DATE_ADD({0},INTERVAL {1} QUARTER),'%Y-%m-%d %H:%i:%s')", (object) pOrgin, (object) pAddData);
          break;
        case EnumDbAddType.YEAR:
          str = string.Format("STR_TO_DATE(DATE_ADD({0},INTERVAL {1} YEAR),'%Y-%m-%d %H:%i:%s')", (object) pOrgin, (object) pAddData);
          break;
        default:
          str = string.Empty;
          break;
      }
      return str;
    }

    public static string MySqlDateAdd(this string pOrgin, string pAddData, EnumDbAddType pAddType)
    {
      string str;
      switch (pAddType)
      {
        case EnumDbAddType.SECOND:
          str = "STR_TO_DATE(DATE_ADD(" + pOrgin + ",INTERVAL " + pAddData + " SECOND),'%Y-%m-%d %H:%i:%s')";
          break;
        case EnumDbAddType.MINUTE:
          str = "STR_TO_DATE(DATE_ADD(" + pOrgin + ",INTERVAL " + pAddData + " MINUTE),'%Y-%m-%d %H:%i:%s')";
          break;
        case EnumDbAddType.HOUR:
          str = "STR_TO_DATE(DATE_ADD(" + pOrgin + ",INTERVAL " + pAddData + " HOUR),'%Y-%m-%d %H:%i:%s')";
          break;
        case EnumDbAddType.DAY:
          str = "STR_TO_DATE(DATE_ADD(" + pOrgin + ",INTERVAL " + pAddData + " DAY),'%Y-%m-%d %H:%i:%s')";
          break;
        case EnumDbAddType.WEEK:
          str = "STR_TO_DATE(DATE_ADD(" + pOrgin + ",INTERVAL " + pAddData + " WEEK),'%Y-%m-%d %H:%i:%s')";
          break;
        case EnumDbAddType.MONTH:
          str = "STR_TO_DATE(DATE_ADD(" + pOrgin + ",INTERVAL " + pAddData + " MONTH),'%Y-%m-%d %H:%i:%s')";
          break;
        case EnumDbAddType.QUARTER:
          str = "STR_TO_DATE(DATE_ADD(" + pOrgin + ",INTERVAL " + pAddData + " QUARTER),'%Y-%m-%d %H:%i:%s')";
          break;
        case EnumDbAddType.YEAR:
          str = "STR_TO_DATE(DATE_ADD(" + pOrgin + ",INTERVAL " + pAddData + " YEAR),'%Y-%m-%d %H:%i:%s')";
          break;
        default:
          str = string.Empty;
          break;
      }
      return str;
    }

    public static string DateDiff(
      this string pStart,
      string pEnd,
      EnumDbAddType pAddType,
      EnumDB pDB = EnumDB.NONE)
    {
      if (pDB == EnumDB.NONE)
        pDB = DbQueryHelper.DbTypeNotNull();
      return pDB == EnumDB.MSSQL ? pStart.MsSqlDateDiff(pEnd, pAddType) : (pDB == EnumDB.MYSQL ? pStart.MySqlDateDiff(pEnd, pAddType) : string.Empty);
    }

    public static string MsSqlDateDiff(this string pStart, string pEnd, EnumDbAddType pAddType)
    {
      string str;
      switch (pAddType)
      {
        case EnumDbAddType.SECOND:
          str = "DATEDIFF(SECOND," + pStart + "," + pEnd + ")";
          break;
        case EnumDbAddType.MINUTE:
          str = "DATEDIFF(MINUTE," + pStart + "," + pEnd + ")";
          break;
        case EnumDbAddType.HOUR:
          str = "DATEDIFF(HOUR," + pStart + "," + pEnd + ")";
          break;
        case EnumDbAddType.DAY:
          str = "DATEDIFF(DAY," + pStart + "," + pEnd + ")";
          break;
        case EnumDbAddType.WEEK:
          str = "DATEDIFF(WEEK," + pStart + "," + pEnd + ")";
          break;
        case EnumDbAddType.MONTH:
          str = "DATEDIFF(MONTH," + pStart + "," + pEnd + ")";
          break;
        case EnumDbAddType.QUARTER:
          str = "DATEDIFF(QUARTER," + pStart + "," + pEnd + ")";
          break;
        case EnumDbAddType.YEAR:
          str = "DATEDIFF(YEAR," + pStart + "," + pEnd + ")";
          break;
        default:
          str = string.Empty;
          break;
      }
      return str;
    }

    public static string MySqlDateDiff(this string pStart, string pEnd, EnumDbAddType pAddType)
    {
      string str;
      switch (pAddType)
      {
        case EnumDbAddType.SECOND:
          str = "TIMESTAMPDIFF(SECOND," + pStart + "," + pEnd + ")";
          break;
        case EnumDbAddType.MINUTE:
          str = "TIMESTAMPDIFF(MINUTE," + pStart + "," + pEnd + ")";
          break;
        case EnumDbAddType.HOUR:
          str = "TIMESTAMPDIFF(HOUR," + pStart + "," + pEnd + ")";
          break;
        case EnumDbAddType.DAY:
          str = "TIMESTAMPDIFF(DAY," + pStart + "," + pEnd + ")";
          break;
        case EnumDbAddType.WEEK:
          str = "TIMESTAMPDIFF(WEEK," + pStart + "," + pEnd + ")";
          break;
        case EnumDbAddType.MONTH:
          str = "TIMESTAMPDIFF(MONTH," + pStart + "," + pEnd + ")";
          break;
        case EnumDbAddType.QUARTER:
          str = "TIMESTAMPDIFF(QUARTER," + pStart + "," + pEnd + ")";
          break;
        case EnumDbAddType.YEAR:
          str = "TIMESTAMPDIFF(YEAR," + pStart + "," + pEnd + ")";
          break;
        default:
          str = string.Empty;
          break;
      }
      return str;
    }

    public static string ToFloor(this string pOrigin, int pCount, EnumDB pDB = EnumDB.NONE)
    {
      if (pDB == EnumDB.NONE)
        pDB = DbQueryHelper.DbTypeNotNull();
      return pDB == EnumDB.MSSQL ? string.Format("ROUND({0},{1},1)", (object) pOrigin, (object) pCount) : (pDB == EnumDB.MYSQL ? string.Format("TRUNCATE({0},{1})", (object) pOrigin, (object) pCount) : string.Empty);
    }

    public static string ToReplace(this string pOrigin, string pOld, string pNew, EnumDB pDB = EnumDB.NONE)
    {
      if (pDB == EnumDB.NONE)
        pDB = DbQueryHelper.DbTypeNotNull();
      string replace;
      if (pDB != EnumDB.MSSQL)
      {
        if (pDB == EnumDB.MYSQL)
          replace = "REPLACE(" + pOrigin + ",'" + pOld + "','" + pNew + "')";
        else
          replace = string.Empty;
      }
      else
        replace = "REPLACE(" + pOrigin + ",'" + pOld + "','" + pNew + "')";
      return replace;
    }

    public static string ToRowNumber(this string pOrderBy, EnumDB pDB = EnumDB.NONE)
    {
      if (pDB == EnumDB.NONE)
        pDB = DbQueryHelper.DbTypeNotNull();
      return pDB == EnumDB.MSSQL ? " ROW_NUMBER() OVER(ORDER BY " + (string.IsNullOrEmpty(pOrderBy) ? "(SELECT 1)" : pOrderBy) + ")" : (pDB == EnumDB.MYSQL ? " @ROWNUM := @ROWNUM + 1" : string.Empty);
    }

    public static string ToRowNumberTable(EnumDB pDB = EnumDB.NONE)
    {
      if (pDB == EnumDB.NONE)
        pDB = DbQueryHelper.DbTypeNotNull();
      return pDB == EnumDB.MSSQL ? string.Empty : (pDB == EnumDB.MYSQL ? " INNER JOIN (SELECT @rownum:=0) TABLE_ROW_NUMBER" : string.Empty);
    }
  }
}
