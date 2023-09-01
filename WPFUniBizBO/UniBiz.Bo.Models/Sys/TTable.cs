// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Sys.TTable
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using UniBiz.Bo.Models.Converter;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.Sys
{
  public class TTable : UbModelBase<TTable>
  {
    protected TableCodeType _tb_code;
    public int _tb_status;
    public string _tb_message;
    public const string DbmsPath = "D:\\DB_DATA\\";

    public override object _Key => (object) this.tb_code;

    public TableCodeType tb_code
    {
      get => this._tb_code;
      set
      {
        this._tb_code = value;
        this.Changed(nameof (tb_code));
        this.Changed("tb_TableStr");
        this.Changed("tb_TableDesc");
      }
    }

    public string tb_TableStr => this.tb_code.ToString();

    public string tb_TableDesc => this.tb_code.ToDescription();

    public int tb_status
    {
      get => this._tb_status;
      set
      {
        this._tb_status = value;
        this.Changed(nameof (tb_status));
        this.Changed("tb_status_desc");
        this.Changed("IsStatusSuccess");
      }
    }

    public string tb_status_desc => ((EnumTableStatus) this.tb_status).ToDescription();

    public bool IsStatusSuccess => Enum2StrConverter.IsTableStatusSuccess(this.tb_status);

    public string tb_message
    {
      get => this._tb_message;
      set
      {
        this._tb_message = value;
        this.Changed(nameof (tb_message));
      }
    }

    public static bool IsTable(
      UniOleDatabase p_sql_session,
      string p_table_catalog,
      string p_table_name)
    {
      if (p_table_name.ToUpper().Equals("UNKNOWN"))
      {
        Log.Logger.ErrorColor(" 생성 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : UNKNOWN\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n");
        return false;
      }
      UniOleDatabase pOleDB = new UniOleDatabase(p_sql_session.ConnectionUrl);
      UniOleDbRecordset uniOleDbRecordset = new UniOleDbRecordset(pOleDB, pOleDB.CommandTimeout);
      if (!uniOleDbRecordset.Open(TTable.TableQuery(p_table_catalog, p_table_name)))
        return false;
      int num = 0;
      if (uniOleDbRecordset.IsDataRead())
        num = uniOleDbRecordset.GetFieldInt("table_count");
      uniOleDbRecordset?.Close();
      pOleDB?.Close();
      return num > 0;
    }

    public static string TableQuery(string p_table_catalog, string p_table_name)
    {
      StringBuilder stringBuilder = new StringBuilder();
      try
      {
        EnumDB enumDb = DbQueryHelper.DbTypeNotNull();
        if (enumDb == EnumDB.MYSQL)
          stringBuilder.Append("SELECT COUNT(1) AS table_count FROM Information_schema.tables WHERE table_schema = '" + p_table_catalog + "' AND table_name = '" + p_table_name + "'");
        else
          stringBuilder.Append("SELECT COUNT(*) AS table_count FROM " + p_table_catalog + "..SYSOBJECTS WITH (NOLOCK) WHERE name = '" + p_table_name + "'");
        Log.Logger.DebugColor(string.Format("\n DATABASE : {0}", (object) enumDb) + string.Format("\n{0}", (object) stringBuilder));
      }
      catch (Exception ex)
      {
        Log.Logger.ErrorColor("  실패\n--------------------------------------------------------------------------------------------------\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) ex.GetHashCode()) + " 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
        stringBuilder.Clear();
      }
      return stringBuilder.ToString();
    }

    public static bool IsDatabase(UniOleDatabase p_sql_session, long p_siteid, string p_database)
    {
      UniOleDatabase pOleDB = (UniOleDatabase) null;
      UniOleDbRecordset uniOleDbRecordset = (UniOleDbRecordset) null;
      try
      {
        pOleDB = new UniOleDatabase(p_sql_session.ConnectionUrl);
        uniOleDbRecordset = new UniOleDbRecordset(pOleDB, pOleDB.CommandTimeout);
        string empty = string.Empty;
        if (!uniOleDbRecordset.Open(string.Format("SELECT * FROM sys.sysdatabases WITH (NOLOCK) WHERE name='{0}_{1}'", (object) p_database, (object) p_siteid)))
          throw new UniServiceException(uniOleDbRecordset.LastErrorMessage, "데이터베이스 SELECT ERROR.", 2);
        IList<string> stringList = (IList<string>) new List<string>();
        if (uniOleDbRecordset.IsDataRead())
        {
          do
          {
            string fieldString = uniOleDbRecordset.GetFieldString(0);
            stringList.Add(fieldString);
          }
          while (uniOleDbRecordset.IsDataRead());
        }
        return stringList.Count > 0;
      }
      catch (UniServiceException ex)
      {
        Log.Logger.ErrorColor(" 조회 실패\n--------------------------------------------------------------------------------------------------\n" + string.Format(" 데이터베이스 : {0}_{1}\n", (object) p_database, (object) p_siteid) + " 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) ex.GetHashCode()) + " 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      catch (Exception ex)
      {
        Log.Logger.ErrorColor(" 조회 실패\n--------------------------------------------------------------------------------------------------\n" + string.Format(" 데이터베이스 : {0}_{1}\n", (object) p_database, (object) p_siteid) + " 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) ex.GetHashCode()) + " 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        uniOleDbRecordset?.Close();
        pOleDB?.Close();
      }
      return false;
    }
  }
}
