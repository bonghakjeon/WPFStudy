// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.TableInfo.SchemaTableView
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
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.TableInfo
{
  public class SchemaTableView : TSchemaTable<SchemaTableView>
  {
    public override void Clear() => base.Clear();

    protected override UbModelBase CreateClone => (UbModelBase) new SchemaTableView();

    public override object Clone() => (object) (base.Clone() as SchemaTableView);

    public void PutData(SchemaTableView pSource) => this.PutData((TSchemaTable) pSource);

    protected override EnumDataCheck DataCheck()
    {
      if (string.IsNullOrEmpty(this.table_catalog))
      {
        this.message = "디비명(" + this.table_catalog + ")  " + EnumDataCheck.Empty.ToDescription();
        return EnumDataCheck.Empty;
      }
      if (string.IsNullOrEmpty(this.table_name))
      {
        this.message = "테이블명(" + this.table_name + ")  " + EnumDataCheck.Empty.ToDescription();
        return EnumDataCheck.Empty;
      }
      if (!string.IsNullOrEmpty(this.table_desc))
        return EnumDataCheck.Success;
      this.message = "테이블 설명(" + this.table_desc + ")  " + EnumDataCheck.Empty.ToDescription();
      return EnumDataCheck.Empty;
    }

    protected override EnumDataCheck DataCheck(UniOleDatabase p_db) => base.DataCheck(p_db);

    public bool IsPermit() => EnumDataCheck.Success == this.DataCheck();

    public override bool GetFieldValues(UniOleDbRecordset p_rs) => base.GetFieldValues(p_rs);

    public async Task<SchemaTableView> SelectOneAsync(string p_table_catalog, string p_table_name) => await this.SelectOneTAsync<SchemaTableView>((object) new Hashtable()
    {
      {
        (object) "table_catalog",
        (object) p_table_catalog
      },
      {
        (object) "table_name",
        (object) p_table_name
      }
    });

    public async Task<IList<SchemaTableView>> SelectListAsync(object p_param)
    {
      SchemaTableView schemaTableView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(schemaTableView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, schemaTableView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(schemaTableView1.GetSelectQuery(p_param)))
        {
          schemaTableView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + schemaTableView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<SchemaTableView>) null;
        }
        IList<SchemaTableView> lt_list = (IList<SchemaTableView>) new List<SchemaTableView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            SchemaTableView schemaTableView2 = schemaTableView1.OleDB.Create<SchemaTableView>();
            if (schemaTableView2.GetFieldValues(rs))
            {
              schemaTableView2.row_number = lt_list.Count + 1;
              lt_list.Add(schemaTableView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + schemaTableView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        if (hashtable.ContainsKey((object) "table_catalog") && hashtable[(object) "table_catalog"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND TABLE_CATALOG='{0}'", hashtable[(object) "table_catalog"]));
        if (hashtable.ContainsKey((object) "table_name") && hashtable[(object) "table_name"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND TABLE_NAME='{0}'", hashtable[(object) "table_name"]));
      }
      return !stringBuilder.ToString().Equals(" WHERE") ? stringBuilder.Replace("WHERE AND", "WHERE").ToString() : string.Empty;
    }

    public override string GetSelectQuery(object p_param)
    {
      StringBuilder stringBuilder = new StringBuilder();
      try
      {
        string selectWhereAnd = this.GetSelectWhereAnd(p_param);
        stringBuilder.Append("WITH T_UNI_BASE AS (\n SELECT F.TABLE_CATALOG AS table_catalog,'기본' AS table_catalog_desc,F.TABLE_NAME AS table_name,CONVERT(char,C.VALUE) AS table_desc\n FROM " + UbModelBase.UNI_BASE + "..SYSOBJECTS A " + DbQueryHelper.ToWithNolock() + "\n INNER JOIN " + UbModelBase.UNI_BASE + "..SYSUSERS B " + DbQueryHelper.ToWithNolock() + " ON A.UID = B.UID\n INNER JOIN " + UbModelBase.UNI_BASE + ".INFORMATION_SCHEMA.TABLES F " + DbQueryHelper.ToWithNolock() + " ON A.NAME = F.TABLE_NAME\n LEFT OUTER JOIN " + UbModelBase.UNI_BASE + ".SYS.EXTENDED_PROPERTIES C " + DbQueryHelper.ToWithNolock() + " ON C.MAJOR_ID = A.ID AND C.MINOR_ID = 0 AND C.NAME = 'MS_Description'");
        if (selectWhereAnd.Length > 0)
          stringBuilder.Append(selectWhereAnd);
        stringBuilder.Append(") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(", T_UNI_SALES AS (\n SELECT F.TABLE_CATALOG AS table_catalog,'판매' AS table_catalog_desc,F.TABLE_NAME AS table_name,CONVERT(char,C.VALUE) AS table_desc\n FROM " + UbModelBase.UNI_SALES + "..SYSOBJECTS A " + DbQueryHelper.ToWithNolock() + "\n INNER JOIN " + UbModelBase.UNI_SALES + "..SYSUSERS B " + DbQueryHelper.ToWithNolock() + " ON A.UID = B.UID\n INNER JOIN " + UbModelBase.UNI_SALES + ".INFORMATION_SCHEMA.TABLES F " + DbQueryHelper.ToWithNolock() + " ON A.NAME = F.TABLE_NAME\n LEFT OUTER JOIN " + UbModelBase.UNI_SALES + ".SYS.EXTENDED_PROPERTIES C " + DbQueryHelper.ToWithNolock() + " ON C.MAJOR_ID = A.ID AND C.MINOR_ID = 0 AND C.NAME = 'MS_Description'");
        if (selectWhereAnd.Length > 0)
          stringBuilder.Append(selectWhereAnd);
        stringBuilder.Append(") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(", T_UNI_TR_DATA AS (\n SELECT F.TABLE_CATALOG AS table_catalog,'TR' AS table_catalog_desc,F.TABLE_NAME AS table_name,CONVERT(char,C.VALUE) AS table_desc\n FROM " + UbModelBase.UNI_TR_DATA + "..SYSOBJECTS A " + DbQueryHelper.ToWithNolock() + "\n INNER JOIN " + UbModelBase.UNI_TR_DATA + "..SYSUSERS B " + DbQueryHelper.ToWithNolock() + " ON A.UID = B.UID\n INNER JOIN " + UbModelBase.UNI_TR_DATA + ".INFORMATION_SCHEMA.TABLES F " + DbQueryHelper.ToWithNolock() + " ON A.NAME = F.TABLE_NAME\n LEFT OUTER JOIN " + UbModelBase.UNI_TR_DATA + ".SYS.EXTENDED_PROPERTIES C " + DbQueryHelper.ToWithNolock() + " ON C.MAJOR_ID = A.ID AND C.MINOR_ID = 0 AND C.NAME = 'MS_Description'");
        if (selectWhereAnd.Length > 0)
          stringBuilder.Append(selectWhereAnd);
        stringBuilder.Append(") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(", T_UNI_STOCK AS (\n SELECT F.TABLE_CATALOG AS table_catalog,'손익' AS table_catalog_desc,F.TABLE_NAME AS table_name,CONVERT(char,C.VALUE) AS table_desc\n FROM " + UbModelBase.UNI_STOCK + "..SYSOBJECTS A " + DbQueryHelper.ToWithNolock() + "\n INNER JOIN " + UbModelBase.UNI_STOCK + "..SYSUSERS B " + DbQueryHelper.ToWithNolock() + " ON A.UID = B.UID\n INNER JOIN " + UbModelBase.UNI_STOCK + ".INFORMATION_SCHEMA.TABLES F " + DbQueryHelper.ToWithNolock() + " ON A.NAME = F.TABLE_NAME\n LEFT OUTER JOIN " + UbModelBase.UNI_STOCK + ".SYS.EXTENDED_PROPERTIES C " + DbQueryHelper.ToWithNolock() + " ON C.MAJOR_ID = A.ID AND C.MINOR_ID = 0 AND C.NAME = 'MS_Description'");
        if (selectWhereAnd.Length > 0)
          stringBuilder.Append(selectWhereAnd);
        stringBuilder.Append(") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(", T_UNI_MEMBERS AS (\n SELECT F.TABLE_CATALOG AS table_catalog,'손익' AS table_catalog_desc,F.TABLE_NAME AS table_name,CONVERT(char,C.VALUE) AS table_desc\n FROM " + UbModelBase.UNI_MEMBERS + "..SYSOBJECTS A " + DbQueryHelper.ToWithNolock() + "\n INNER JOIN " + UbModelBase.UNI_MEMBERS + "..SYSUSERS B " + DbQueryHelper.ToWithNolock() + " ON A.UID = B.UID\n INNER JOIN " + UbModelBase.UNI_MEMBERS + ".INFORMATION_SCHEMA.TABLES F " + DbQueryHelper.ToWithNolock() + " ON A.NAME = F.TABLE_NAME\n LEFT OUTER JOIN " + UbModelBase.UNI_MEMBERS + ".SYS.EXTENDED_PROPERTIES C " + DbQueryHelper.ToWithNolock() + " ON C.MAJOR_ID = A.ID AND C.MINOR_ID = 0 AND C.NAME = 'MS_Description'");
        if (selectWhereAnd.Length > 0)
          stringBuilder.Append(selectWhereAnd);
        stringBuilder.Append(") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(", T_UNI_INTERFACE AS (\n SELECT F.TABLE_CATALOG AS table_catalog,'인터페이스' AS table_catalog_desc,F.TABLE_NAME AS table_name,CONVERT(char,C.VALUE) AS table_desc\n FROM " + UbModelBase.UNI_INTERFACE + "..SYSOBJECTS A " + DbQueryHelper.ToWithNolock() + "\n INNER JOIN " + UbModelBase.UNI_INTERFACE + "..SYSUSERS B " + DbQueryHelper.ToWithNolock() + " ON A.UID = B.UID\n INNER JOIN " + UbModelBase.UNI_INTERFACE + ".INFORMATION_SCHEMA.TABLES F " + DbQueryHelper.ToWithNolock() + " ON A.NAME = F.TABLE_NAME\n LEFT OUTER JOIN " + UbModelBase.UNI_INTERFACE + ".SYS.EXTENDED_PROPERTIES C " + DbQueryHelper.ToWithNolock() + " ON C.MAJOR_ID = A.ID AND C.MINOR_ID = 0 AND C.NAME = 'MS_Description'");
        if (selectWhereAnd.Length > 0)
          stringBuilder.Append(selectWhereAnd);
        stringBuilder.Append(") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(", T_UNI_IMAGES AS (\n SELECT F.TABLE_CATALOG AS table_catalog,'SMS' AS table_catalog_desc,F.TABLE_NAME AS table_name,CONVERT(char,C.VALUE) AS table_desc\n FROM " + UbModelBase.UNI_IMAGES + "..SYSOBJECTS A " + DbQueryHelper.ToWithNolock() + "\n INNER JOIN " + UbModelBase.UNI_IMAGES + "..SYSUSERS B " + DbQueryHelper.ToWithNolock() + " ON A.UID = B.UID\n INNER JOIN " + UbModelBase.UNI_IMAGES + ".INFORMATION_SCHEMA.TABLES F " + DbQueryHelper.ToWithNolock() + " ON A.NAME = F.TABLE_NAME\n LEFT OUTER JOIN " + UbModelBase.UNI_IMAGES + ".SYS.EXTENDED_PROPERTIES C " + DbQueryHelper.ToWithNolock() + " ON C.MAJOR_ID = A.ID AND C.MINOR_ID = 0 AND C.NAME = 'MS_Description'");
        if (selectWhereAnd.Length > 0)
          stringBuilder.Append(selectWhereAnd);
        stringBuilder.Append(") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(", T_UNI_CAMPANIGN AS (\n SELECT F.TABLE_CATALOG AS table_catalog,'SMS' AS table_catalog_desc,F.TABLE_NAME AS table_name,CONVERT(char,C.VALUE) AS table_desc\n FROM " + UbModelBase.UNI_CAMPANIGN + "..SYSOBJECTS A " + DbQueryHelper.ToWithNolock() + "\n INNER JOIN " + UbModelBase.UNI_CAMPANIGN + "..SYSUSERS B " + DbQueryHelper.ToWithNolock() + " ON A.UID = B.UID\n INNER JOIN " + UbModelBase.UNI_CAMPANIGN + ".INFORMATION_SCHEMA.TABLES F " + DbQueryHelper.ToWithNolock() + " ON A.NAME = F.TABLE_NAME\n LEFT OUTER JOIN " + UbModelBase.UNI_CAMPANIGN + ".SYS.EXTENDED_PROPERTIES C " + DbQueryHelper.ToWithNolock() + " ON C.MAJOR_ID = A.ID AND C.MINOR_ID = 0 AND C.NAME = 'MS_Description'");
        if (selectWhereAnd.Length > 0)
          stringBuilder.Append(selectWhereAnd);
        stringBuilder.Append(") ");
        stringBuilder.Append("\n");
        stringBuilder.Append(" SELECT  table_catalog,table_catalog_desc,table_name,table_desc FROM (");
        string str = " SELECT  table_catalog,table_catalog_desc,table_name,table_desc";
        stringBuilder.Append("\n");
        stringBuilder.Append(str);
        stringBuilder.Append(" FROM T_UNI_BASE");
        stringBuilder.Append(" UNION ALL");
        stringBuilder.Append("\n");
        stringBuilder.Append(str);
        stringBuilder.Append(" FROM T_UNI_SALES");
        stringBuilder.Append(" UNION ALL");
        stringBuilder.Append("\n");
        stringBuilder.Append(str);
        stringBuilder.Append(" FROM T_UNI_TR_DATA");
        stringBuilder.Append(" UNION ALL");
        stringBuilder.Append("\n");
        stringBuilder.Append(str);
        stringBuilder.Append(" FROM T_UNI_STOCK");
        stringBuilder.Append(" UNION ALL");
        stringBuilder.Append("\n");
        stringBuilder.Append(str);
        stringBuilder.Append(" FROM T_UNI_MEMBERS");
        stringBuilder.Append(" UNION ALL");
        stringBuilder.Append("\n");
        stringBuilder.Append(str);
        stringBuilder.Append(" FROM T_UNI_INTERFACE");
        stringBuilder.Append(" UNION ALL");
        stringBuilder.Append("\n");
        stringBuilder.Append(str);
        stringBuilder.Append(" FROM T_UNI_IMAGES");
        stringBuilder.Append(" UNION ALL");
        stringBuilder.Append("\n");
        stringBuilder.Append(str);
        stringBuilder.Append(" FROM T_UNI_CAMPANIGN");
        stringBuilder.Append("\n");
        stringBuilder.Append(" ) MAIN");
        stringBuilder.Append("\n");
        if (p_param is Hashtable hashtable && hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" WHERE {0} LIKE '%{1}%'", (object) "table_name", hashtable[(object) "_KEY_WORD_"]));
        stringBuilder.Append("\n");
        stringBuilder.Append(" ORDER BY table_catalog,table_name");
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
