// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.WeatherBy.WeatherByTime.TWeatherByTime
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

namespace UniBiz.Bo.Models.UniSales.WeatherBy.WeatherByTime
{
  public class TWeatherByTime : UbModelBase<TWeatherByTime>
  {
    private DateTime? _wbt_Date;
    private int _wbt_Hour;
    private string _wbt_WeatherLocation;
    private long _wbt_SiteID;
    private double _wbt_CurrentTemperature;
    private double _wbt_MaxTemperature;
    private double _wbt_MinTemperature;
    private int _wbt_SkyCondition;
    private int _wbt_RainCondition;
    private string _wbt_WeatherKor;
    private string _wbt_WeatherEng;
    private double _wbt_RainfallRate;
    private double _wbt_Hour12RainVolume;
    private double _wbt_Hour12SnowVolume;
    private double _wbt_WindSpeed;
    private int _wbt_WindDirection;
    private string _wbt_WinDirectionKor;
    private string _wbt_WinDirectionEng;
    private double _wbt_Humidity;
    private double _wbt_Hour6RainVolume;
    private double _wbt_Hour6SnowVolume;

    public override object _Key => (object) new object[3]
    {
      (object) this.wbt_Date,
      (object) this.wbt_Hour,
      (object) this.wbt_WeatherLocation
    };

    public DateTime? wbt_Date
    {
      get => this._wbt_Date;
      set
      {
        this._wbt_Date = value;
        this.Changed(nameof (wbt_Date));
      }
    }

    public int wbt_Hour
    {
      get => this._wbt_Hour;
      set
      {
        this._wbt_Hour = value;
        this.Changed(nameof (wbt_Hour));
      }
    }

    public string wbt_WeatherLocation
    {
      get => this._wbt_WeatherLocation;
      set
      {
        this._wbt_WeatherLocation = UbModelBase.LeftStr(value, 50).Replace("'", "´");
        this.Changed(nameof (wbt_WeatherLocation));
      }
    }

    public long wbt_SiteID
    {
      get => this._wbt_SiteID;
      set
      {
        this._wbt_SiteID = value;
        this.Changed(nameof (wbt_SiteID));
      }
    }

    public double wbt_CurrentTemperature
    {
      get => this._wbt_CurrentTemperature;
      set
      {
        this._wbt_CurrentTemperature = value;
        this.Changed(nameof (wbt_CurrentTemperature));
      }
    }

    public double wbt_MaxTemperature
    {
      get => this._wbt_MaxTemperature;
      set
      {
        this._wbt_MaxTemperature = value;
        this.Changed(nameof (wbt_MaxTemperature));
      }
    }

    public double wbt_MinTemperature
    {
      get => this._wbt_MinTemperature;
      set
      {
        this._wbt_MinTemperature = value;
        this.Changed(nameof (wbt_MinTemperature));
      }
    }

    public int wbt_SkyCondition
    {
      get => this._wbt_SkyCondition;
      set
      {
        this._wbt_SkyCondition = value;
        this.Changed(nameof (wbt_SkyCondition));
      }
    }

    public int wbt_RainCondition
    {
      get => this._wbt_RainCondition;
      set
      {
        this._wbt_RainCondition = value;
        this.Changed(nameof (wbt_RainCondition));
      }
    }

    public string wbt_WeatherKor
    {
      get => this._wbt_WeatherKor;
      set
      {
        this._wbt_WeatherKor = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (wbt_WeatherKor));
      }
    }

    public string wbt_WeatherEng
    {
      get => this._wbt_WeatherEng;
      set
      {
        this._wbt_WeatherEng = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (wbt_WeatherEng));
      }
    }

    public double wbt_RainfallRate
    {
      get => this._wbt_RainfallRate;
      set
      {
        this._wbt_RainfallRate = value;
        this.Changed(nameof (wbt_RainfallRate));
      }
    }

    public double wbt_Hour12RainVolume
    {
      get => this._wbt_Hour12RainVolume;
      set
      {
        this._wbt_Hour12RainVolume = value;
        this.Changed(nameof (wbt_Hour12RainVolume));
      }
    }

    public double wbt_Hour12SnowVolume
    {
      get => this._wbt_Hour12SnowVolume;
      set
      {
        this._wbt_Hour12SnowVolume = value;
        this.Changed(nameof (wbt_Hour12SnowVolume));
      }
    }

    public double wbt_WindSpeed
    {
      get => this._wbt_WindSpeed;
      set
      {
        this._wbt_WindSpeed = value;
        this.Changed(nameof (wbt_WindSpeed));
      }
    }

    public int wbt_WindDirection
    {
      get => this._wbt_WindDirection;
      set
      {
        this._wbt_WindDirection = value;
        this.Changed(nameof (wbt_WindDirection));
      }
    }

    public string wbt_WinDirectionKor
    {
      get => this._wbt_WinDirectionKor;
      set
      {
        this._wbt_WinDirectionKor = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (wbt_WinDirectionKor));
      }
    }

    public string wbt_WinDirectionEng
    {
      get => this._wbt_WinDirectionEng;
      set
      {
        this._wbt_WinDirectionEng = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (wbt_WinDirectionEng));
      }
    }

    public double wbt_Humidity
    {
      get => this._wbt_Humidity;
      set
      {
        this._wbt_Humidity = value;
        this.Changed(nameof (wbt_Humidity));
      }
    }

    public double wbt_Hour6RainVolume
    {
      get => this._wbt_Hour6RainVolume;
      set
      {
        this._wbt_Hour6RainVolume = value;
        this.Changed(nameof (wbt_Hour6RainVolume));
      }
    }

    public double wbt_Hour6SnowVolume
    {
      get => this._wbt_Hour6SnowVolume;
      set
      {
        this._wbt_Hour6SnowVolume = value;
        this.Changed(nameof (wbt_Hour6SnowVolume));
      }
    }

    public TWeatherByTime() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("wbt_Date", new TTableColumn()
      {
        tc_orgin_name = "wbt_Date",
        tc_trans_name = "일자"
      });
      columnInfo.Add("wbt_Hour", new TTableColumn()
      {
        tc_orgin_name = "wbt_Hour",
        tc_trans_name = "시간"
      });
      columnInfo.Add("wbt_WeatherLocation", new TTableColumn()
      {
        tc_orgin_name = "wbt_WeatherLocation",
        tc_trans_name = "지역코드"
      });
      columnInfo.Add("wbt_SiteID", new TTableColumn()
      {
        tc_orgin_name = "wbt_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("wbt_CurrentTemperature", new TTableColumn()
      {
        tc_orgin_name = "wbt_CurrentTemperature",
        tc_trans_name = "현재온도"
      });
      columnInfo.Add("wbt_MaxTemperature", new TTableColumn()
      {
        tc_orgin_name = "wbt_MaxTemperature",
        tc_trans_name = "최고온도"
      });
      columnInfo.Add("wbt_MinTemperature", new TTableColumn()
      {
        tc_orgin_name = "wbt_MinTemperature",
        tc_trans_name = "최저온도"
      });
      columnInfo.Add("wbt_SkyCondition", new TTableColumn()
      {
        tc_orgin_name = "wbt_SkyCondition",
        tc_trans_name = "하늘"
      });
      columnInfo.Add("wbt_RainCondition", new TTableColumn()
      {
        tc_orgin_name = "wbt_RainCondition",
        tc_trans_name = "강수"
      });
      columnInfo.Add("wbt_WeatherKor", new TTableColumn()
      {
        tc_orgin_name = "wbt_WeatherKor",
        tc_trans_name = "날씨"
      });
      columnInfo.Add("wbt_WeatherEng", new TTableColumn()
      {
        tc_orgin_name = "wbt_WeatherEng",
        tc_trans_name = "날씨(ENG)"
      });
      columnInfo.Add("wbt_RainfallRate", new TTableColumn()
      {
        tc_orgin_name = "wbt_RainfallRate",
        tc_trans_name = "강수확률"
      });
      columnInfo.Add("wbt_Hour12RainVolume", new TTableColumn()
      {
        tc_orgin_name = "wbt_Hour12RainVolume",
        tc_trans_name = "12시간예상강수량 "
      });
      columnInfo.Add("wbt_Hour12SnowVolume", new TTableColumn()
      {
        tc_orgin_name = "wbt_Hour12SnowVolume",
        tc_trans_name = "12시간예상적설량"
      });
      columnInfo.Add("wbt_WindSpeed", new TTableColumn()
      {
        tc_orgin_name = "wbt_WindSpeed",
        tc_trans_name = "풍속 "
      });
      columnInfo.Add("wbt_WindDirection", new TTableColumn()
      {
        tc_orgin_name = "wbt_WindDirection",
        tc_trans_name = "풍향 "
      });
      columnInfo.Add("wbt_WinDirectionKor", new TTableColumn()
      {
        tc_orgin_name = "wbt_WinDirectionKor",
        tc_trans_name = "풍향_"
      });
      columnInfo.Add("wbt_WinDirectionEng", new TTableColumn()
      {
        tc_orgin_name = "wbt_WinDirectionEng",
        tc_trans_name = "풍향_(ENG)"
      });
      columnInfo.Add("wbt_Humidity", new TTableColumn()
      {
        tc_orgin_name = "wbt_Humidity",
        tc_trans_name = "습도"
      });
      columnInfo.Add("wbt_Hour6RainVolume", new TTableColumn()
      {
        tc_orgin_name = "wbt_Hour6RainVolume",
        tc_trans_name = "6시간예상강수량"
      });
      columnInfo.Add("wbt_Hour6SnowVolume", new TTableColumn()
      {
        tc_orgin_name = "wbt_Hour6SnowVolume",
        tc_trans_name = "6시간예상적설량"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.WeatherByTime;
      this.wbt_Date = new DateTime?();
      this.wbt_Hour = 0;
      this.wbt_WeatherLocation = string.Empty;
      this.wbt_SiteID = 0L;
      this.wbt_CurrentTemperature = this.wbt_MaxTemperature = this.wbt_MinTemperature = 0.0;
      this.wbt_SkyCondition = this.wbt_RainCondition = 0;
      this.wbt_WeatherKor = string.Empty;
      this.wbt_WeatherEng = string.Empty;
      this.wbt_RainfallRate = this.wbt_Hour12RainVolume = this.wbt_Hour12SnowVolume = this.wbt_WindSpeed = 0.0;
      this.wbt_WindDirection = 0;
      this.wbt_WinDirectionKor = string.Empty;
      this.wbt_WinDirectionEng = string.Empty;
      this.wbt_Humidity = this.wbt_Hour6RainVolume = this.wbt_Hour6SnowVolume = 0.0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TWeatherByTime();

    public override object Clone()
    {
      TWeatherByTime tweatherByTime = base.Clone() as TWeatherByTime;
      tweatherByTime.wbt_Date = this.wbt_Date;
      tweatherByTime.wbt_Hour = this.wbt_Hour;
      tweatherByTime.wbt_WeatherLocation = this.wbt_WeatherLocation;
      tweatherByTime.wbt_SiteID = this.wbt_SiteID;
      tweatherByTime.wbt_CurrentTemperature = this.wbt_CurrentTemperature;
      tweatherByTime.wbt_MaxTemperature = this.wbt_MaxTemperature;
      tweatherByTime.wbt_MinTemperature = this.wbt_MinTemperature;
      tweatherByTime.wbt_SkyCondition = this.wbt_SkyCondition;
      tweatherByTime.wbt_RainCondition = this.wbt_RainCondition;
      tweatherByTime.wbt_WeatherKor = this.wbt_WeatherKor;
      tweatherByTime.wbt_WeatherEng = this.wbt_WeatherEng;
      tweatherByTime.wbt_RainfallRate = this.wbt_RainfallRate;
      tweatherByTime.wbt_Hour12RainVolume = this.wbt_Hour12RainVolume;
      tweatherByTime.wbt_Hour12SnowVolume = this.wbt_Hour12SnowVolume;
      tweatherByTime.wbt_WindSpeed = this.wbt_WindSpeed;
      tweatherByTime.wbt_WindDirection = this.wbt_WindDirection;
      tweatherByTime.wbt_WinDirectionKor = this.wbt_WinDirectionKor;
      tweatherByTime.wbt_WinDirectionEng = this.wbt_WinDirectionEng;
      tweatherByTime.wbt_Humidity = this.wbt_Humidity;
      tweatherByTime.wbt_Hour6RainVolume = this.wbt_Hour6RainVolume;
      tweatherByTime.wbt_Hour6SnowVolume = this.wbt_Hour6SnowVolume;
      return (object) tweatherByTime;
    }

    public void PutData(TWeatherByTime pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.wbt_Date = pSource.wbt_Date;
      this.wbt_Hour = pSource.wbt_Hour;
      this.wbt_WeatherLocation = pSource.wbt_WeatherLocation;
      this.wbt_SiteID = pSource.wbt_SiteID;
      this.wbt_CurrentTemperature = pSource.wbt_CurrentTemperature;
      this.wbt_MaxTemperature = pSource.wbt_MaxTemperature;
      this.wbt_MinTemperature = pSource.wbt_MinTemperature;
      this.wbt_SkyCondition = pSource.wbt_SkyCondition;
      this.wbt_RainCondition = pSource.wbt_RainCondition;
      this.wbt_WeatherKor = pSource.wbt_WeatherKor;
      this.wbt_WeatherEng = pSource.wbt_WeatherEng;
      this.wbt_RainfallRate = pSource.wbt_RainfallRate;
      this.wbt_Hour12RainVolume = pSource.wbt_Hour12RainVolume;
      this.wbt_Hour12SnowVolume = pSource.wbt_Hour12SnowVolume;
      this.wbt_WindSpeed = pSource.wbt_WindSpeed;
      this.wbt_WindDirection = pSource.wbt_WindDirection;
      this.wbt_WinDirectionKor = pSource.wbt_WinDirectionKor;
      this.wbt_WinDirectionEng = pSource.wbt_WinDirectionEng;
      this.wbt_Humidity = pSource.wbt_Humidity;
      this.wbt_Hour6RainVolume = pSource.wbt_Hour6RainVolume;
      this.wbt_Hour6SnowVolume = pSource.wbt_Hour6SnowVolume;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.wbt_Date = p_rs.GetFieldDateTime("wbt_Date");
        this.wbt_Hour = p_rs.GetFieldInt("wbt_Hour");
        this.wbt_WeatherLocation = p_rs.GetFieldString("wbt_WeatherLocation");
        if (this.wbt_WeatherLocation.Length == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.wbt_SiteID = p_rs.GetFieldLong("wbt_SiteID");
        this.wbt_CurrentTemperature = p_rs.GetFieldDouble("wbt_CurrentTemperature");
        this.wbt_MaxTemperature = p_rs.GetFieldDouble("wbt_MaxTemperature");
        this.wbt_MinTemperature = p_rs.GetFieldDouble("wbt_MinTemperature");
        this.wbt_SkyCondition = p_rs.GetFieldInt("wbt_SkyCondition");
        this.wbt_RainCondition = p_rs.GetFieldInt("wbt_RainCondition");
        this.wbt_WeatherKor = p_rs.GetFieldString("wbt_WeatherKor");
        this.wbt_WeatherEng = p_rs.GetFieldString("wbt_WeatherEng");
        this.wbt_RainfallRate = p_rs.GetFieldDouble("wbt_RainfallRate");
        this.wbt_Hour12RainVolume = p_rs.GetFieldDouble("wbt_Hour12RainVolume");
        this.wbt_Hour12SnowVolume = p_rs.GetFieldDouble("wbt_Hour12SnowVolume");
        this.wbt_WindSpeed = p_rs.GetFieldDouble("wbt_WindSpeed");
        this.wbt_WindDirection = p_rs.GetFieldInt("wbt_WindDirection");
        this.wbt_WinDirectionKor = p_rs.GetFieldString("wbt_WinDirectionKor");
        this.wbt_WinDirectionEng = p_rs.GetFieldString("wbt_WinDirectionEng");
        this.wbt_Humidity = p_rs.GetFieldDouble("wbt_Humidity");
        this.wbt_Hour6RainVolume = p_rs.GetFieldDouble("wbt_Hour6RainVolume");
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

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_SALES), (object) this.TableCode) + " wbt_Date,wbt_Hour,wbt_WeatherLocation,wbt_SiteID,wbt_CurrentTemperature,wbt_MaxTemperature,wbt_MinTemperature,wbt_SkyCondition,wbt_RainCondition,wbt_WeatherKor,wbt_WeatherEng,wbt_RainfallRate,wbt_Hour12RainVolume,wbt_Hour12SnowVolume,wbt_WindSpeed,wbt_WindDirection,wbt_WinDirectionKor,wbt_WinDirectionEng,wbt_Humidity,wbt_Hour6RainVolume,wbt_Hour6SnowVolume) VALUES ( " + string.Format(" '{0}',{1},'{2}'", (object) this.wbt_Date.GetDateToStr("yyyy-MM-dd 00:00:00"), (object) this.wbt_Hour, (object) this.wbt_WeatherLocation) + string.Format(",{0}", (object) this.wbt_SiteID) + "," + this.wbt_CurrentTemperature.FormatTo("{0:0.0000}") + "," + this.wbt_MaxTemperature.FormatTo("{0:0.0000}") + "," + this.wbt_MinTemperature.FormatTo("{0:0.0000}") + string.Format(",{0},{1}", (object) this.wbt_SkyCondition, (object) this.wbt_RainCondition) + ",'" + this.wbt_WeatherKor + "','" + this.wbt_WeatherEng + "'," + this.wbt_RainfallRate.FormatTo("{0:0.0000}") + "," + this.wbt_Hour12RainVolume.FormatTo("{0:0.0000}") + "," + this.wbt_Hour12SnowVolume.FormatTo("{0:0.0000}") + "," + this.wbt_WindSpeed.FormatTo("{0:0.0000}") + string.Format(",{0}", (object) this.wbt_WindDirection) + ",'" + this.wbt_WinDirectionKor + "','" + this.wbt_WinDirectionEng + "'," + this.wbt_Humidity.FormatTo("{0:0.0000}") + "," + this.wbt_Hour6RainVolume.FormatTo("{0:0.0000}") + "," + this.wbt_Hour6SnowVolume.FormatTo("{0:0.0000}") + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.wbt_Date, (object) this.wbt_Hour, (object) this.wbt_WeatherLocation, (object) this.wbt_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TWeatherByTime tweatherByTime = this;
      // ISSUE: reference to a compiler-generated method
      tweatherByTime.\u003C\u003En__0();
      if (await tweatherByTime.OleDB.ExecuteAsync(tweatherByTime.InsertQuery()))
        return true;
      tweatherByTime.message = " " + tweatherByTime.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tweatherByTime.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tweatherByTime.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tweatherByTime.wbt_Date, (object) tweatherByTime.wbt_Hour, (object) tweatherByTime.wbt_WeatherLocation, (object) tweatherByTime.wbt_SiteID) + " 내용 : " + tweatherByTime.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tweatherByTime.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_SALES), (object) this.TableCode) + " wbt_CurrentTemperature=" + this.wbt_CurrentTemperature.FormatTo("{0:0.0000}") + ",wbt_MaxTemperature=" + this.wbt_MaxTemperature.FormatTo("{0:0.0000}") + ",wbt_MinTemperature=" + this.wbt_MinTemperature.FormatTo("{0:0.0000}") + string.Format(",{0}={1},{2}={3}", (object) "wbt_SkyCondition", (object) this.wbt_SkyCondition, (object) "wbt_RainCondition", (object) this.wbt_RainCondition) + ",wbt_WeatherKor='" + this.wbt_WeatherKor + "',wbt_WeatherEng='" + this.wbt_WeatherEng + "',wbt_RainfallRate=" + this.wbt_RainfallRate.FormatTo("{0:0.0000}") + ",wbt_Hour12RainVolume=" + this.wbt_Hour12RainVolume.FormatTo("{0:0.0000}") + ",wbt_Hour12SnowVolume=" + this.wbt_Hour12SnowVolume.FormatTo("{0:0.0000}") + ",wbt_WindSpeed=" + this.wbt_WindSpeed.FormatTo("{0:0.0000}") + string.Format(",{0}={1}", (object) "wbt_WindDirection", (object) this.wbt_WindDirection) + ",wbt_WinDirectionKor='" + this.wbt_WinDirectionKor + "',wbt_WinDirectionEng='" + this.wbt_WinDirectionEng + "',wbt_Humidity=" + this.wbt_Humidity.FormatTo("{0:0.0000}") + ",wbt_Hour6RainVolume=" + this.wbt_Hour6RainVolume.FormatTo("{0:0.0000}") + ",wbt_Hour6SnowVolume=" + this.wbt_Hour6SnowVolume.FormatTo("{0:0.0000}") + " WHERE wbt_Date='" + this.wbt_Date.GetDateToStr("yyyy-MM-dd 00:00:00") + "'" + string.Format(" AND {0}={1}", (object) "wbt_Hour", (object) this.wbt_Hour) + " AND wbt_WeatherLocation='" + this.wbt_WeatherLocation + "'" + string.Format(" AND {0}={1}", (object) "wbt_SiteID", (object) this.wbt_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.wbt_Date, (object) this.wbt_Hour, (object) this.wbt_WeatherLocation, (object) this.wbt_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TWeatherByTime tweatherByTime = this;
      // ISSUE: reference to a compiler-generated method
      tweatherByTime.\u003C\u003En__1();
      if (await tweatherByTime.OleDB.ExecuteAsync(tweatherByTime.UpdateQuery()))
        return true;
      tweatherByTime.message = " " + tweatherByTime.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tweatherByTime.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tweatherByTime.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tweatherByTime.wbt_Date, (object) tweatherByTime.wbt_Hour, (object) tweatherByTime.wbt_WeatherLocation, (object) tweatherByTime.wbt_SiteID) + " 내용 : " + tweatherByTime.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tweatherByTime.message);
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
      stringBuilder.Append(" wbt_CurrentTemperature=" + this.wbt_CurrentTemperature.FormatTo("{0:0.0000}") + ",wbt_MaxTemperature=" + this.wbt_MaxTemperature.FormatTo("{0:0.0000}") + ",wbt_MinTemperature=" + this.wbt_MinTemperature.FormatTo("{0:0.0000}") + string.Format(",{0}={1},{2}={3}", (object) "wbt_SkyCondition", (object) this.wbt_SkyCondition, (object) "wbt_RainCondition", (object) this.wbt_RainCondition) + ",wbt_WeatherKor='" + this.wbt_WeatherKor + "',wbt_WeatherEng='" + this.wbt_WeatherEng + "',wbt_RainfallRate=" + this.wbt_RainfallRate.FormatTo("{0:0.0000}") + ",wbt_Hour12RainVolume=" + this.wbt_Hour12RainVolume.FormatTo("{0:0.0000}") + ",wbt_Hour12SnowVolume=" + this.wbt_Hour12SnowVolume.FormatTo("{0:0.0000}") + ",wbt_WindSpeed=" + this.wbt_WindSpeed.FormatTo("{0:0.0000}") + string.Format(",{0}={1}", (object) "wbt_WindDirection", (object) this.wbt_WindDirection) + ",wbt_WinDirectionKor='" + this.wbt_WinDirectionKor + "',wbt_WinDirectionEng='" + this.wbt_WinDirectionEng + "',wbt_Humidity=" + this.wbt_Humidity.FormatTo("{0:0.0000}") + ",wbt_Hour6RainVolume=" + this.wbt_Hour6RainVolume.FormatTo("{0:0.0000}") + ",wbt_Hour6SnowVolume=" + this.wbt_Hour6SnowVolume.FormatTo("{0:0.0000}"));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.wbt_Date, (object) this.wbt_Hour, (object) this.wbt_WeatherLocation, (object) this.wbt_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TWeatherByTime tweatherByTime = this;
      // ISSUE: reference to a compiler-generated method
      tweatherByTime.\u003C\u003En__1();
      if (await tweatherByTime.OleDB.ExecuteAsync(tweatherByTime.UpdateExInsertQuery()))
        return true;
      tweatherByTime.message = " " + tweatherByTime.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tweatherByTime.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tweatherByTime.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tweatherByTime.wbt_Date, (object) tweatherByTime.wbt_Hour, (object) tweatherByTime.wbt_WeatherLocation, (object) tweatherByTime.wbt_SiteID) + " 내용 : " + tweatherByTime.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tweatherByTime.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "wbt_SiteID") && Convert.ToInt64(hashtable[(object) "wbt_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "wbt_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "wbt_Date"))
        {
          stringBuilder.Append(" AND wbt_Date >='" + new DateTime?((DateTime) hashtable[(object) "wbt_Date"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND wbt_Date <='" + new DateTime?((DateTime) hashtable[(object) "wbt_Date"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
        }
        if (hashtable.ContainsKey((object) "wbt_Date_BEGIN_") && hashtable.ContainsKey((object) "wbt_Date_END_"))
        {
          stringBuilder.Append(" AND wbt_Date >='" + new DateTime?((DateTime) hashtable[(object) "wbt_Date_BEGIN_"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND wbt_Date <='" + new DateTime?((DateTime) hashtable[(object) "wbt_Date_END_"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
        }
        if (hashtable.ContainsKey((object) "wbt_Hour") && Convert.ToInt32(hashtable[(object) "wbt_Hour"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "wbt_Hour", hashtable[(object) "wbt_Hour"]));
        if (hashtable.ContainsKey((object) "wbt_WeatherLocation") && hashtable[(object) "wbt_WeatherLocation"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "wbt_WeatherLocation", hashtable[(object) "wbt_WeatherLocation"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "wbt_SiteID", (object) num));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_"))
        {
          int length = hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length;
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
        stringBuilder.Append(" SELECT  wbt_Date,wbt_Hour,wbt_WeatherLocation,wbt_SiteID,wbt_CurrentTemperature,wbt_MaxTemperature,wbt_MinTemperature,wbt_SkyCondition,wbt_RainCondition,wbt_WeatherKor,wbt_WeatherEng,wbt_RainfallRate,wbt_Hour12RainVolume,wbt_Hour12SnowVolume,wbt_WindSpeed,wbt_WindDirection,wbt_WinDirectionKor,wbt_WinDirectionEng,wbt_Humidity,wbt_Hour6RainVolume,wbt_Hour6SnowVolume");
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
