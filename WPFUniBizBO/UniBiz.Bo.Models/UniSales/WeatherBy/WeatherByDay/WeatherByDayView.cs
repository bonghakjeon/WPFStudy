// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.WeatherBy.WeatherByDay.WeatherByDayView
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
using UniBiz.Bo.Models.UniBase.Employee.Employee;
using UniBiz.Bo.Models.UniBase.Store.StoreInfo;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniSales.WeatherBy.WeatherByDay
{
  public class WeatherByDayView : TWeatherByDay<WeatherByDayView>
  {
    private int _si_StoreCode;
    private string _si_StoreName;
    private string _si_StoreViewCode;

    public int si_StoreCode
    {
      get => this._si_StoreCode;
      set
      {
        this._si_StoreCode = value;
        this.Changed(nameof (si_StoreCode));
      }
    }

    public string si_StoreName
    {
      get => this._si_StoreName;
      set
      {
        this._si_StoreName = value;
        this.Changed(nameof (si_StoreName));
      }
    }

    public string si_StoreViewCode
    {
      get => this._si_StoreViewCode;
      set
      {
        this._si_StoreViewCode = value;
        this.Changed(nameof (si_StoreViewCode));
      }
    }

    public override Dictionary<string, TTableColumn> ToColumnInfo() => base.ToColumnInfo();

    public override void Clear()
    {
      base.Clear();
      this.si_StoreCode = 0;
      this.si_StoreName = this.si_StoreViewCode = string.Empty;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new WeatherByDayView();

    public override object Clone()
    {
      WeatherByDayView weatherByDayView = base.Clone() as WeatherByDayView;
      weatherByDayView.si_StoreCode = this.si_StoreCode;
      weatherByDayView.si_StoreName = this.si_StoreName;
      weatherByDayView.si_StoreViewCode = this.si_StoreViewCode;
      return (object) weatherByDayView;
    }

    public void PutData(WeatherByDayView pSource)
    {
      this.PutData((TWeatherByDay) pSource);
      this.si_StoreCode = pSource.si_StoreCode;
      this.si_StoreName = pSource.si_StoreName;
      this.si_StoreViewCode = pSource.si_StoreViewCode;
    }

    protected override EnumDataCheck DataCheck()
    {
      if (this.wbd_SiteID == 0L)
      {
        this.message = "싸이트(wbd_SiteID)  " + EnumDataCheck.CodeZero.ToDescription();
        return EnumDataCheck.CodeZero;
      }
      if (!this.wbd_Date.HasValue)
      {
        this.message = "일자(wbd_Date)  " + EnumDataCheck.NULL.ToDescription();
        return EnumDataCheck.NULL;
      }
      if (!string.IsNullOrEmpty(this.wbd_WeatherLocation))
        return EnumDataCheck.Success;
      this.message = "지역코드(wbd_WeatherLocation)  " + EnumDataCheck.NULL.ToDescription();
      return EnumDataCheck.CodeZero;
    }

    protected override EnumDataCheck DataCheck(UniOleDatabase p_db) => base.DataCheck(p_db);

    protected override bool IsPermit(EmployeeView p_app_employee)
    {
      if (p_app_employee == null)
      {
        this.message = "사용자 정보 NULL.";
        return false;
      }
      return EnumDataCheck.Success == this.DataCheck(this.OleDB);
    }

    public override bool InsertData(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      try
      {
        this.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != this.DataCheck(p_db))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (this.wbd_SiteID == 0L)
            this.wbd_SiteID = p_app_employee.emp_SiteID;
          if (!this.IsPermit(p_app_employee))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (!this.Insert())
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 등록 오류");
        this.db_status = 4;
        this.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        this.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        this.message = ex.Message;
      }
      return false;
    }

    public override async Task<bool> InsertDataAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      WeatherByDayView weatherByDayView = this;
      try
      {
        weatherByDayView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != weatherByDayView.DataCheck(p_db))
            throw new UniServiceException(weatherByDayView.message, weatherByDayView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else
        {
          if (weatherByDayView.wbd_SiteID == 0L)
            weatherByDayView.wbd_SiteID = p_app_employee.emp_SiteID;
          if (!weatherByDayView.IsPermit(p_app_employee))
            throw new UniServiceException(weatherByDayView.message, weatherByDayView.TableCode.ToDescription() + " 권한 검사 실패");
        }
        if (!await weatherByDayView.InsertAsync())
          throw new UniServiceException(weatherByDayView.message, weatherByDayView.TableCode.ToDescription() + " 등록 오류");
        weatherByDayView.db_status = 4;
        weatherByDayView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        weatherByDayView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        weatherByDayView.message = ex.Message;
      }
      return false;
    }

    public override bool UpdateData(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      try
      {
        this.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != this.DataCheck(p_db))
            throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!this.IsPermit(p_app_employee))
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 권한 검사 실패");
        if (!this.Update())
          throw new UniServiceException(this.message, this.TableCode.ToDescription() + " 변경 오류");
        this.db_status = 4;
        this.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        this.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        this.message = ex.Message;
      }
      return false;
    }

    public override async Task<bool> UpdateDataAsync(
      UniOleDatabase p_db,
      EmployeeView p_app_employee,
      bool p_is_trans = false)
    {
      WeatherByDayView weatherByDayView = this;
      try
      {
        weatherByDayView.SetAdoDatabase(p_db);
        if (p_app_employee == null)
        {
          if (EnumDataCheck.Success != weatherByDayView.DataCheck(p_db))
            throw new UniServiceException(weatherByDayView.message, weatherByDayView.TableCode.ToDescription() + " 유효성 검사 실패");
        }
        else if (!weatherByDayView.IsPermit(p_app_employee))
          throw new UniServiceException(weatherByDayView.message, weatherByDayView.TableCode.ToDescription() + " 권한 검사 실패");
        if (!await weatherByDayView.UpdateAsync())
          throw new UniServiceException(weatherByDayView.message, weatherByDayView.TableCode.ToDescription() + " 변경 오류");
        weatherByDayView.db_status = 4;
        weatherByDayView.RowErrorStatus = EnumRowStatus.Success;
        return true;
      }
      catch (UniServiceException ex)
      {
        weatherByDayView.message = ex.UserMessage + "\n" + ex.Message;
      }
      catch (Exception ex)
      {
        weatherByDayView.message = ex.Message;
      }
      return false;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      if (!base.GetFieldValues(p_rs))
        return false;
      this.si_StoreCode = p_rs.GetFieldInt("si_StoreCode");
      this.si_StoreName = p_rs.GetFieldString("si_StoreName");
      this.si_StoreViewCode = p_rs.GetFieldString("si_StoreViewCode");
      return true;
    }

    public async Task<WeatherByDayView> SelectOneAsync(
      DateTime p_wbd_Date,
      string p_wbd_WeatherLocation,
      long p_wbd_SiteID = 0)
    {
      WeatherByDayView weatherByDayView = this;
      Hashtable p_param = new Hashtable()
      {
        {
          (object) "wbd_Date",
          (object) p_wbd_Date
        },
        {
          (object) "wbd_WeatherLocation",
          (object) p_wbd_WeatherLocation
        }
      };
      if (p_wbd_SiteID > 0L)
        p_param.Add((object) "wbd_SiteID", (object) p_wbd_SiteID);
      return await weatherByDayView.SelectOneTAsync<WeatherByDayView>((object) p_param);
    }

    public async Task<IList<WeatherByDayView>> SelectListAsync(object p_param)
    {
      WeatherByDayView weatherByDayView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(weatherByDayView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, weatherByDayView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(weatherByDayView1.GetSelectQuery(p_param)))
        {
          weatherByDayView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + weatherByDayView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<WeatherByDayView>) null;
        }
        IList<WeatherByDayView> lt_list = (IList<WeatherByDayView>) new List<WeatherByDayView>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            WeatherByDayView weatherByDayView2 = weatherByDayView1.OleDB.Create<WeatherByDayView>();
            if (weatherByDayView2.GetFieldValues(rs))
            {
              weatherByDayView2.row_number = lt_list.Count + 1;
              lt_list.Add(weatherByDayView2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + weatherByDayView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<WeatherByDayView> SelectEnumerableAsync(object p_param)
    {
      WeatherByDayView weatherByDayView1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(weatherByDayView1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, weatherByDayView1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(weatherByDayView1.GetSelectQuery(p_param)))
        {
          weatherByDayView1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + weatherByDayView1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            WeatherByDayView weatherByDayView2 = weatherByDayView1.OleDB.Create<WeatherByDayView>();
            if (weatherByDayView2.GetFieldValues(rs))
            {
              weatherByDayView2.row_number = ++row_number;
              yield return weatherByDayView2;
            }
          }
          while (await rs.IsDataReadAsync());
        }
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public override string GetSelectWhereAnd(object p_param)
    {
      StringBuilder stringBuilder = new StringBuilder(this.GetSelectWhereAnd(p_param, false));
      if (string.IsNullOrWhiteSpace(stringBuilder.ToString()))
        stringBuilder.Append(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        if (hashtable.ContainsKey((object) "si_StoreCode") && Convert.ToInt32(hashtable[(object) "si_StoreCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "si_StoreCode", hashtable[(object) "si_StoreCode"]));
        else if (hashtable.ContainsKey((object) "si_StoreCode_IN_") && hashtable[(object) "si_StoreCode_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "si_StoreCode", hashtable[(object) "si_StoreCode_IN_"]));
        else if (hashtable.ContainsKey((object) "_STORE_AUTHS_") && hashtable[(object) "_STORE_AUTHS_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "si_StoreCode", hashtable[(object) "_STORE_AUTHS_"]));
        else
          stringBuilder.Append(" AND si_StoreCode > 0");
        if (hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "si_StoreName", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "si_StoreViewCode", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "wbd_WindSpeed", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "wbd_Memo", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(")");
        }
      }
      return !stringBuilder.ToString().Equals(" WHERE") ? stringBuilder.Replace("WHERE AND", "WHERE").ToString() : string.Empty;
    }

    public override string GetSelectQuery(object p_param)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        string uniBase = UbModelBase.UNI_BASE;
        string str = this.TableCode.ToString();
        string empty = string.Empty;
        long num = 0;
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
          if (hashtable.ContainsKey((object) "_ORDER_BY_COL_") && hashtable[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            empty = hashtable[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable.ContainsKey((object) "wbd_SiteID") && Convert.ToInt64(hashtable[(object) "wbd_SiteID"].ToString()) > 0L)
            num = Convert.ToInt64(hashtable[(object) "wbd_SiteID"].ToString());
        }
        stringBuilder.Append("WITH T_STORE AS ( SELECT si_StoreCode,si_SiteID,si_StoreName,si_StoreViewCode,si_StoreType,si_UseYn,si_LocationUseYn" + string.Format(" FROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("wbd_SiteID"))
            p_param1.Add((object) "si_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add((object) "si_StoreCode", dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "si_SiteID"))
            p_param1.Add((object) "si_SiteID", (object) num);
          stringBuilder.Append(new TStoreInfo().GetSelectWhereAnd((object) p_param1));
        }
        else if (num > 0L)
          stringBuilder.Append(string.Format("  WHERE {0}={1}", (object) "si_SiteID", (object) num));
        stringBuilder.Append(")");
        stringBuilder.Append("\n");
        stringBuilder.Append(" SELECT  wbd_Date,wbd_WeatherLocation,wbd_SiteID,wbd_SkyCondition,wbd_RainCondition,wbd_AvgTemperature,wbd_MinTemperature,wbd_MaxTemperature,wbd_CloudVolume,wbd_RainVolume,wbd_SnowVolume,wbd_Humidity,wbd_WindSpeed,wbd_Memo,si_StoreCode,si_StoreName,si_StoreViewCode\n FROM " + DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_SALES) + str + " " + DbQueryHelper.ToWithNolock() + "\n INNER JOIN T_STORE ON 'wbd_WeatherLocation'='si_WeatherCode' AND wbd_SiteID=si_SiteID");
        stringBuilder.Append("\n");
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
        if (!string.IsNullOrEmpty(empty))
          stringBuilder.Append(" ORDER BY " + empty);
        else
          stringBuilder.Append(" ORDER BY si_StoreCode,wbd_Date");
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) ex.GetHashCode()) + " 내용 : " + ex.Message + "\n" + string.Format(" Query : {0}\n", (object) stringBuilder) + "--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
        stringBuilder.Clear();
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }
  }
}
