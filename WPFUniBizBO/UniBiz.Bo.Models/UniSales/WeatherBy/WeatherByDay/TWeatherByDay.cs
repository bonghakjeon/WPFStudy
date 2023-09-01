// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.WeatherBy.WeatherByDay.TWeatherByDay
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
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniSales.WeatherBy.WeatherByDay
{
  public class TWeatherByDay : UbModelBase<TWeatherByDay>
  {
    private DateTime? _wbd_Date;
    private string _wbd_WeatherLocation;
    private long _wbd_SiteID;
    private int _wbd_SkyCondition;
    private int _wbd_RainCondition;
    private double _wbd_AvgTemperature;
    private double _wbd_MinTemperature;
    private double _wbd_MaxTemperature;
    private double _wbd_CloudVolume;
    private double _wbd_RainVolume;
    private double _wbd_SnowVolume;
    private double _wbd_Humidity;
    private string _wbd_WindSpeed;
    private string _wbd_Memo;

    public override object _Key => (object) new object[2]
    {
      (object) this.wbd_Date,
      (object) this.wbd_WeatherLocation
    };

    public DateTime? wbd_Date
    {
      get => this._wbd_Date;
      set
      {
        this._wbd_Date = value;
        this.Changed(nameof (wbd_Date));
      }
    }

    public string wbd_WeatherLocation
    {
      get => this._wbd_WeatherLocation;
      set
      {
        this._wbd_WeatherLocation = UbModelBase.LeftStr(value, 50).Replace("'", "´");
        this.Changed(nameof (wbd_WeatherLocation));
      }
    }

    public long wbd_SiteID
    {
      get => this._wbd_SiteID;
      set
      {
        this._wbd_SiteID = value;
        this.Changed(nameof (wbd_SiteID));
      }
    }

    public int wbd_SkyCondition
    {
      get => this._wbd_SkyCondition;
      set
      {
        this._wbd_SkyCondition = value;
        this.Changed(nameof (wbd_SkyCondition));
      }
    }

    public int wbd_RainCondition
    {
      get => this._wbd_RainCondition;
      set
      {
        this._wbd_RainCondition = value;
        this.Changed(nameof (wbd_RainCondition));
      }
    }

    public double wbd_AvgTemperature
    {
      get => this._wbd_AvgTemperature;
      set
      {
        this._wbd_AvgTemperature = value;
        this.Changed(nameof (wbd_AvgTemperature));
      }
    }

    public double wbd_MinTemperature
    {
      get => this._wbd_MinTemperature;
      set
      {
        this._wbd_MinTemperature = value;
        this.Changed(nameof (wbd_MinTemperature));
      }
    }

    public double wbd_MaxTemperature
    {
      get => this._wbd_MaxTemperature;
      set
      {
        this._wbd_MaxTemperature = value;
        this.Changed(nameof (wbd_MaxTemperature));
      }
    }

    public double wbd_CloudVolume
    {
      get => this._wbd_CloudVolume;
      set
      {
        this._wbd_CloudVolume = value;
        this.Changed(nameof (wbd_CloudVolume));
      }
    }

    public double wbd_RainVolume
    {
      get => this._wbd_RainVolume;
      set
      {
        this._wbd_RainVolume = value;
        this.Changed(nameof (wbd_RainVolume));
      }
    }

    public double wbd_SnowVolume
    {
      get => this._wbd_SnowVolume;
      set
      {
        this._wbd_SnowVolume = value;
        this.Changed(nameof (wbd_SnowVolume));
      }
    }

    public double wbd_Humidity
    {
      get => this._wbd_Humidity;
      set
      {
        this._wbd_Humidity = value;
        this.Changed(nameof (wbd_Humidity));
      }
    }

    public string wbd_WindSpeed
    {
      get => this._wbd_WindSpeed;
      set
      {
        this._wbd_WindSpeed = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (wbd_WindSpeed));
      }
    }

    public string wbd_Memo
    {
      get => this._wbd_Memo;
      set
      {
        this._wbd_Memo = UbModelBase.LeftStr(value, 200).Replace("'", "´");
        this.Changed(nameof (wbd_Memo));
      }
    }

    public TWeatherByDay() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("wbd_Date", new TTableColumn()
      {
        tc_orgin_name = "wbd_Date",
        tc_trans_name = "일자"
      });
      columnInfo.Add("wbd_WeatherLocation", new TTableColumn()
      {
        tc_orgin_name = "wbd_WeatherLocation",
        tc_trans_name = "지역코드"
      });
      columnInfo.Add("wbd_SiteID", new TTableColumn()
      {
        tc_orgin_name = "wbd_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("wbd_SkyCondition", new TTableColumn()
      {
        tc_orgin_name = "wbd_SkyCondition",
        tc_trans_name = "하늘상태"
      });
      columnInfo.Add("wbd_RainCondition", new TTableColumn()
      {
        tc_orgin_name = "wbd_RainCondition",
        tc_trans_name = "강수상태"
      });
      columnInfo.Add("wbd_AvgTemperature", new TTableColumn()
      {
        tc_orgin_name = "wbd_AvgTemperature",
        tc_trans_name = "평균기온"
      });
      columnInfo.Add("wbd_MinTemperature", new TTableColumn()
      {
        tc_orgin_name = "wbd_MinTemperature",
        tc_trans_name = "최저기온"
      });
      columnInfo.Add("wbd_MaxTemperature", new TTableColumn()
      {
        tc_orgin_name = "wbd_MaxTemperature",
        tc_trans_name = "최고기온"
      });
      columnInfo.Add("wbd_CloudVolume", new TTableColumn()
      {
        tc_orgin_name = "wbd_CloudVolume",
        tc_trans_name = "구름양"
      });
      columnInfo.Add("wbd_RainVolume", new TTableColumn()
      {
        tc_orgin_name = "wbd_RainVolume",
        tc_trans_name = "강우량(mm)"
      });
      columnInfo.Add("wbd_SnowVolume", new TTableColumn()
      {
        tc_orgin_name = "wbd_SnowVolume",
        tc_trans_name = "적설량(mm)"
      });
      columnInfo.Add("wbd_Humidity", new TTableColumn()
      {
        tc_orgin_name = "wbd_Humidity",
        tc_trans_name = "습도(%)"
      });
      columnInfo.Add("wbd_WindSpeed", new TTableColumn()
      {
        tc_orgin_name = "wbd_WindSpeed",
        tc_trans_name = "풍향속도"
      });
      columnInfo.Add("wbd_Memo", new TTableColumn()
      {
        tc_orgin_name = "wbd_Memo",
        tc_trans_name = "특이사항"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.WeatherByDay;
      this.wbd_Date = new DateTime?();
      this.wbd_WeatherLocation = string.Empty;
      this.wbd_SiteID = 0L;
      this.wbd_SkyCondition = this.wbd_RainCondition = 0;
      this.wbd_AvgTemperature = this.wbd_MinTemperature = this.wbd_MaxTemperature = this.wbd_CloudVolume = this.wbd_RainVolume = this.wbd_SnowVolume = this.wbd_Humidity = 0.0;
      this.wbd_WindSpeed = string.Empty;
      this.wbd_Memo = string.Empty;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TWeatherByDay();

    public override object Clone()
    {
      TWeatherByDay tweatherByDay = base.Clone() as TWeatherByDay;
      tweatherByDay.wbd_Date = this.wbd_Date;
      tweatherByDay.wbd_WeatherLocation = this.wbd_WeatherLocation;
      tweatherByDay.wbd_SiteID = this.wbd_SiteID;
      tweatherByDay.wbd_SkyCondition = this.wbd_SkyCondition;
      tweatherByDay.wbd_RainCondition = this.wbd_RainCondition;
      tweatherByDay.wbd_AvgTemperature = this.wbd_AvgTemperature;
      tweatherByDay.wbd_MinTemperature = this.wbd_MinTemperature;
      tweatherByDay.wbd_MaxTemperature = this.wbd_MaxTemperature;
      tweatherByDay.wbd_CloudVolume = this.wbd_CloudVolume;
      tweatherByDay.wbd_RainVolume = this.wbd_RainVolume;
      tweatherByDay.wbd_SnowVolume = this.wbd_SnowVolume;
      tweatherByDay.wbd_Humidity = this.wbd_Humidity;
      tweatherByDay.wbd_WindSpeed = this.wbd_WindSpeed;
      tweatherByDay.wbd_Memo = this.wbd_Memo;
      return (object) tweatherByDay;
    }

    public void PutData(TWeatherByDay pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.wbd_Date = pSource.wbd_Date;
      this.wbd_WeatherLocation = pSource.wbd_WeatherLocation;
      this.wbd_SiteID = pSource.wbd_SiteID;
      this.wbd_SkyCondition = pSource.wbd_SkyCondition;
      this.wbd_RainCondition = pSource.wbd_RainCondition;
      this.wbd_AvgTemperature = pSource.wbd_AvgTemperature;
      this.wbd_MinTemperature = pSource.wbd_MinTemperature;
      this.wbd_MaxTemperature = pSource.wbd_MaxTemperature;
      this.wbd_CloudVolume = pSource.wbd_CloudVolume;
      this.wbd_RainVolume = pSource.wbd_RainVolume;
      this.wbd_SnowVolume = pSource.wbd_SnowVolume;
      this.wbd_Humidity = pSource.wbd_Humidity;
      this.wbd_WindSpeed = pSource.wbd_WindSpeed;
      this.wbd_Memo = pSource.wbd_Memo;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.wbd_Date = p_rs.GetFieldDateTime("wbd_Date");
        this.wbd_WeatherLocation = p_rs.GetFieldString("wbd_WeatherLocation");
        if (this.wbd_WeatherLocation.Length == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.wbd_SiteID = p_rs.GetFieldLong("wbd_SiteID");
        this.wbd_SkyCondition = p_rs.GetFieldInt("wbd_SkyCondition");
        this.wbd_RainCondition = p_rs.GetFieldInt("wbd_RainCondition");
        this.wbd_AvgTemperature = p_rs.GetFieldDouble("wbd_AvgTemperature");
        this.wbd_MinTemperature = p_rs.GetFieldDouble("wbd_MinTemperature");
        this.wbd_MaxTemperature = p_rs.GetFieldDouble("wbd_MaxTemperature");
        this.wbd_CloudVolume = p_rs.GetFieldDouble("wbd_CloudVolume");
        this.wbd_RainVolume = p_rs.GetFieldDouble("wbd_RainVolume");
        this.wbd_SnowVolume = p_rs.GetFieldDouble("wbd_SnowVolume");
        this.wbd_Humidity = p_rs.GetFieldDouble("wbd_Humidity");
        this.wbd_WindSpeed = p_rs.GetFieldString("wbd_WindSpeed");
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

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_SALES), (object) this.TableCode) + " wbd_Date,wbd_WeatherLocation,wbd_SiteID,wbd_SkyCondition,wbd_RainCondition,wbd_AvgTemperature,wbd_MinTemperature,wbd_MaxTemperature,wbd_CloudVolume,wbd_RainVolume,wbd_SnowVolume,wbd_Humidity,wbd_WindSpeed,wbd_Memo) VALUES (  '" + this.wbd_Date.GetDateToStr("yyyy-MM-dd 00:00:00") + "','" + this.wbd_WeatherLocation + "'" + string.Format(",{0}", (object) this.wbd_SiteID) + string.Format(",{0},{1}", (object) this.wbd_SkyCondition, (object) this.wbd_RainCondition) + "," + this.wbd_AvgTemperature.FormatTo("{0:0.0000}") + "," + this.wbd_RainCondition.FormatTo("{0:0.0000}") + "," + this.wbd_MaxTemperature.FormatTo("{0:0.0000}") + "," + this.wbd_CloudVolume.FormatTo("{0:0.0000}") + "," + this.wbd_RainVolume.FormatTo("{0:0.0000}") + "," + this.wbd_SnowVolume.FormatTo("{0:0.0000}") + "," + this.wbd_Humidity.FormatTo("{0:0.0000}") + ",'" + this.wbd_WindSpeed + "','" + this.wbd_Memo + "')";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.wbd_Date, (object) this.wbd_WeatherLocation, (object) this.wbd_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TWeatherByDay tweatherByDay = this;
      // ISSUE: reference to a compiler-generated method
      tweatherByDay.\u003C\u003En__0();
      if (await tweatherByDay.OleDB.ExecuteAsync(tweatherByDay.InsertQuery()))
        return true;
      tweatherByDay.message = " " + tweatherByDay.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tweatherByDay.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tweatherByDay.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tweatherByDay.wbd_Date, (object) tweatherByDay.wbd_WeatherLocation, (object) tweatherByDay.wbd_SiteID) + " 내용 : " + tweatherByDay.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tweatherByDay.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_SALES), (object) this.TableCode) + string.Format(" {0}={1},{2}={3}", (object) "wbd_SkyCondition", (object) this.wbd_SkyCondition, (object) "wbd_RainCondition", (object) this.wbd_RainCondition) + ",wbd_AvgTemperature=" + this.wbd_AvgTemperature.FormatTo("{0:0.0000}") + ",wbd_MinTemperature=" + this.wbd_MinTemperature.FormatTo("{0:0.0000}") + ",wbd_MaxTemperature=" + this.wbd_MaxTemperature.FormatTo("{0:0.0000}") + ",wbd_CloudVolume=" + this.wbd_CloudVolume.FormatTo("{0:0.0000}") + ",wbd_RainVolume=" + this.wbd_RainVolume.FormatTo("{0:0.0000}") + ",wbd_SnowVolume=" + this.wbd_SnowVolume.FormatTo("{0:0.0000}") + ",wbd_Humidity=" + this.wbd_Humidity.FormatTo("{0:0.0000}") + ",wbd_WindSpeed='" + this.wbd_WindSpeed + "',wbd_Memo='" + this.wbd_Memo + "' WHERE wbd_Date='" + this.wbd_Date.GetDateToStr("yyyy-MM-dd 00:00:00") + "' AND wbd_WeatherLocation='" + this.wbd_WeatherLocation + "'" + string.Format(" AND {0}={1}", (object) "wbd_SiteID", (object) this.wbd_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.wbd_Date, (object) this.wbd_WeatherLocation, (object) this.wbd_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TWeatherByDay tweatherByDay = this;
      // ISSUE: reference to a compiler-generated method
      tweatherByDay.\u003C\u003En__1();
      if (await tweatherByDay.OleDB.ExecuteAsync(tweatherByDay.UpdateQuery()))
        return true;
      tweatherByDay.message = " " + tweatherByDay.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tweatherByDay.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tweatherByDay.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tweatherByDay.wbd_Date, (object) tweatherByDay.wbd_WeatherLocation, (object) tweatherByDay.wbd_SiteID) + " 내용 : " + tweatherByDay.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tweatherByDay.message);
      return false;
    }

    public override string UpdateExInsertMySQLQuery()
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(this.InsertQuery());
      if (stringBuilder.ToString().Contains(";"))
      {
        string str = stringBuilder.ToString().Replace(";", string.Empty);
        stringBuilder.Clear();
        stringBuilder.Append(str);
      }
      stringBuilder.Append(" ON DUPLICATE KEY UPDATE ");
      stringBuilder.Append("\n");
      stringBuilder.Append(string.Format(" {0}={1},{2}={3}", (object) "wbd_SkyCondition", (object) this.wbd_SkyCondition, (object) "wbd_RainCondition", (object) this.wbd_RainCondition) + ",wbd_AvgTemperature=" + this.wbd_AvgTemperature.FormatTo("{0:0.0000}") + ",wbd_MinTemperature=" + this.wbd_MinTemperature.FormatTo("{0:0.0000}") + ",wbd_MaxTemperature=" + this.wbd_MaxTemperature.FormatTo("{0:0.0000}") + ",wbd_CloudVolume=" + this.wbd_CloudVolume.FormatTo("{0:0.0000}") + ",wbd_RainVolume=" + this.wbd_RainVolume.FormatTo("{0:0.0000}") + ",wbd_SnowVolume=" + this.wbd_SnowVolume.FormatTo("{0:0.0000}") + ",wbd_Humidity=" + this.wbd_Humidity.FormatTo("{0:0.0000}") + ",wbd_WindSpeed='" + this.wbd_WindSpeed + "',wbd_Memo='" + this.wbd_Memo + "'");
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) this.wbd_Date, (object) this.wbd_WeatherLocation, (object) this.wbd_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TWeatherByDay tweatherByDay = this;
      // ISSUE: reference to a compiler-generated method
      tweatherByDay.\u003C\u003En__1();
      if (await tweatherByDay.OleDB.ExecuteAsync(tweatherByDay.UpdateExInsertQuery()))
        return true;
      tweatherByDay.message = " " + tweatherByDay.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tweatherByDay.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tweatherByDay.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2})\n", (object) tweatherByDay.wbd_Date, (object) tweatherByDay.wbd_WeatherLocation, (object) tweatherByDay.wbd_SiteID) + " 내용 : " + tweatherByDay.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tweatherByDay.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "wbd_SiteID") && Convert.ToInt64(hashtable[(object) "wbd_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "wbd_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "wbd_Date"))
        {
          stringBuilder.Append(" AND wbd_Date >='" + new DateTime?((DateTime) hashtable[(object) "wbd_Date"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND wbd_Date <='" + new DateTime?((DateTime) hashtable[(object) "wbd_Date"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
        }
        if (hashtable.ContainsKey((object) "wbd_Date_BEGIN_") && hashtable.ContainsKey((object) "wbd_Date_END_"))
        {
          stringBuilder.Append(" AND wbd_Date >='" + new DateTime?((DateTime) hashtable[(object) "wbd_Date_BEGIN_"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND wbd_Date <='" + new DateTime?((DateTime) hashtable[(object) "wbd_Date_END_"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
        }
        if (hashtable.ContainsKey((object) "wbd_WeatherLocation") && hashtable[(object) "wbd_WeatherLocation"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "wbd_WeatherLocation", hashtable[(object) "wbd_WeatherLocation"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "wbd_SiteID", (object) num));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "wbd_WindSpeed", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "wbd_Memo", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(")");
        }
      }
      return !stringBuilder.ToString().Equals(" WHERE") ? stringBuilder.Replace("WHERE AND", "WHERE").ToString() : string.Empty;
    }

    public override string GetSelectQuery(object p_param)
    {
      StringBuilder stringBuilder = new StringBuilder();
      try
      {
        string uniSales = UbModelBase.UNI_SALES;
        string str = this.TableCode.ToString();
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniSales = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
        }
        stringBuilder.Append(" SELECT  wbd_Date,wbd_WeatherLocation,wbd_SiteID,wbd_SkyCondition,wbd_RainCondition,wbd_AvgTemperature,wbd_MinTemperature,wbd_MaxTemperature,wbd_CloudVolume,wbd_RainVolume,wbd_SnowVolume,wbd_Humidity,wbd_WindSpeed,wbd_Memo");
        stringBuilder.Append(" FROM " + DbQueryHelper.ToDBNameBridge(uniSales) + str + " " + DbQueryHelper.ToWithNolock());
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
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
