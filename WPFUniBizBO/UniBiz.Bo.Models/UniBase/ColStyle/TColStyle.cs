// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.ColStyle.TColStyle
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

namespace UniBiz.Bo.Models.UniBase.ColStyle
{
  public class TColStyle : UbModelBase<TColStyle>
  {
    private int _cs_Code;
    private long _cs_SiteID;
    private string _cs_Name;
    private string _cs_Desc;
    private int _cs_Width;
    private int _cs_Align;
    private string _cs_UseYn;
    private string _cs_Foreground;
    private int _cs_BackgroundR;
    private int _cs_BackgroundG;
    private int _cs_BackgroundB;
    private double _cs_BackgroundOpacity;
    private int _cs_Bold;
    private int _cs_Italic;
    private int _cs_AddProperty;
    private DateTime? _cs_InDate;
    private int _cs_InUser;
    private DateTime? _cs_ModDate;
    private int _cs_ModUser;

    public override object _Key => (object) new object[2]
    {
      (object) this.cs_Code,
      (object) this.cs_SiteID
    };

    public int cs_Code
    {
      get => this._cs_Code;
      set
      {
        this._cs_Code = value;
        this.Changed(nameof (cs_Code));
      }
    }

    public long cs_SiteID
    {
      get => this._cs_SiteID;
      set
      {
        this._cs_SiteID = value;
        this.Changed(nameof (cs_SiteID));
      }
    }

    public string cs_Name
    {
      get => this._cs_Name;
      set
      {
        this._cs_Name = UbModelBase.LeftStr(value, 200).Replace("'", "´");
        this.Changed(nameof (cs_Name));
      }
    }

    public string cs_Desc
    {
      get => this._cs_Desc;
      set
      {
        this._cs_Desc = UbModelBase.LeftStr(value, 200).Replace("'", "´");
        this.Changed(nameof (cs_Desc));
      }
    }

    public int cs_Width
    {
      get => this._cs_Width;
      set
      {
        this._cs_Width = value;
        this.Changed(nameof (cs_Width));
      }
    }

    public int cs_Align
    {
      get => this._cs_Align;
      set
      {
        this._cs_Align = value;
        this.Changed(nameof (cs_Align));
      }
    }

    public string cs_UseYn
    {
      get => this._cs_UseYn;
      set
      {
        this._cs_UseYn = UbModelBase.LeftStr(value, 1);
        this.Changed(nameof (cs_UseYn));
        this.Changed("cs_IsUseYn");
        this.Changed("cs_UseYnDesc");
        this.Changed("ColStyleInLine");
        this.Changed("ColStyle");
      }
    }

    public bool cs_IsUseYn => "Y".Equals(this.cs_UseYn);

    public string cs_UseYnDesc => !"Y".Equals(this.cs_UseYn) ? "미사용" : "사용";

    public string cs_Foreground
    {
      get => this._cs_Foreground;
      set
      {
        this._cs_Foreground = UbModelBase.LeftStr(value, 10).Replace("'", "´");
        this.Changed(nameof (cs_Foreground));
        this.Changed("ColStyleInLine");
        this.Changed("ColStyle");
      }
    }

    public int cs_BackgroundR
    {
      get => this._cs_BackgroundR;
      set
      {
        this._cs_BackgroundR = value;
        this.Changed(nameof (cs_BackgroundR));
        this.Changed("cs_BackGroundRGBA");
        this.Changed("cs_BackGroundHex");
        this.Changed("ColStyle");
      }
    }

    public int cs_BackgroundG
    {
      get => this._cs_BackgroundG;
      set
      {
        this._cs_BackgroundG = value;
        this.Changed(nameof (cs_BackgroundG));
        this.Changed("cs_BackGroundRGBA");
        this.Changed("cs_BackGroundHex");
        this.Changed("ColStyle");
      }
    }

    public int cs_BackgroundB
    {
      get => this._cs_BackgroundB;
      set
      {
        this._cs_BackgroundB = value;
        this.Changed(nameof (cs_BackgroundB));
        this.Changed("cs_BackGroundRGBA");
        this.Changed("cs_BackGroundHex");
        this.Changed("ColStyle");
      }
    }

    public double cs_BackgroundOpacity
    {
      get => this._cs_BackgroundOpacity;
      set
      {
        this._cs_BackgroundOpacity = value;
        this.Changed(nameof (cs_BackgroundOpacity));
        this.Changed("cs_BackGroundRGBA");
        this.Changed("ColStyle");
      }
    }

    public string cs_BackGroundRGBA => string.Format("{0},{1},{2},{3}", (object) this.cs_BackgroundR, (object) this.cs_BackgroundG, (object) this.cs_BackgroundB, (object) this.cs_BackgroundOpacity.FormatTo("{0:0.0}"));

    public string cs_BackGroundHex => string.Format("#{0:X2}{1:X2}{2:X2}", (object) this.cs_BackgroundR, (object) this.cs_BackgroundG, (object) this.cs_BackgroundB);

    public int cs_Bold
    {
      get => this._cs_Bold;
      set
      {
        this._cs_Bold = value;
        this.Changed(nameof (cs_Bold));
        this.Changed("cs_BoldDesc");
        this.Changed("cs_BoldName");
        this.Changed("ColStyleInLine");
        this.Changed("ColStyle");
      }
    }

    public string cs_BoldDesc => this.cs_Bold != 0 ? Enum2StrConverter.ToFontWeight(this.cs_Bold).ToDescription() : string.Empty;

    public string cs_BoldName => this.cs_Bold != 0 ? Enum2StrConverter.ToFontWeight(this.cs_Bold).ToString() : string.Empty;

    public int cs_Italic
    {
      get => this._cs_Italic;
      set
      {
        this._cs_Italic = value;
        this.Changed(nameof (cs_Italic));
        this.Changed("cs_ItalicDesc");
        this.Changed("cs_ItalicName");
        this.Changed("ColStyleInLine");
        this.Changed("ColStyle");
      }
    }

    public string cs_ItalicDesc => this.cs_Italic != 0 ? Enum2StrConverter.ToFontStyle(this.cs_Italic).ToDescription() : string.Empty;

    public string cs_ItalicName => this.cs_Italic != 0 ? Enum2StrConverter.ToFontStyle(this.cs_Italic).ToString() : string.Empty;

    public string ColStyleInLine
    {
      get
      {
        if (this.cs_IsUseYn)
          return string.Empty;
        StringBuilder stringBuilder = new StringBuilder();
        if (!"#000000".Equals(this.cs_Foreground))
        {
          stringBuilder.Append("color:");
          stringBuilder.Append(this.cs_Foreground);
          stringBuilder.Append(";");
        }
        if (this.cs_Bold > 0)
        {
          stringBuilder.Append("font-weight:");
          stringBuilder.Append(this.cs_BoldName);
          stringBuilder.Append(";");
        }
        if (this.cs_Italic > 0)
        {
          stringBuilder.Append("font-style:");
          stringBuilder.Append(this.cs_ItalicName);
          stringBuilder.Append(";");
        }
        return stringBuilder.ToString();
      }
    }

    public string ColStyle
    {
      get
      {
        if (this.cs_IsUseYn)
          return string.Empty;
        StringBuilder stringBuilder = new StringBuilder();
        if (!this.cs_BackgroundOpacity.IsZero())
        {
          if (this.cs_BackgroundOpacity >= 1.0)
          {
            stringBuilder.Append("background-color:");
            stringBuilder.Append(this.cs_BackGroundHex);
            stringBuilder.Append(";");
          }
          else
          {
            stringBuilder.Append("background-color:");
            stringBuilder.Append(this.cs_BackGroundRGBA);
            stringBuilder.Append(";");
          }
        }
        return stringBuilder.ToString();
      }
    }

    public int cs_AddProperty
    {
      get => this._cs_AddProperty;
      set
      {
        this._cs_AddProperty = value;
        this.Changed(nameof (cs_AddProperty));
      }
    }

    public DateTime? cs_InDate
    {
      get => this._cs_InDate;
      set
      {
        this._cs_InDate = value;
        this.Changed(nameof (cs_InDate));
      }
    }

    public int cs_InUser
    {
      get => this._cs_InUser;
      set
      {
        this._cs_InUser = value;
        this.Changed(nameof (cs_InUser));
      }
    }

    public DateTime? cs_ModDate
    {
      get => this._cs_ModDate;
      set
      {
        this._cs_ModDate = value;
        this.Changed(nameof (cs_ModDate));
      }
    }

    public int cs_ModUser
    {
      get => this._cs_ModUser;
      set
      {
        this._cs_ModUser = value;
        this.Changed(nameof (cs_ModUser));
      }
    }

    public TColStyle() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("cs_Code", new TTableColumn()
      {
        tc_orgin_name = "cs_Code",
        tc_trans_name = "컬럼 코드"
      });
      columnInfo.Add("cs_SiteID", new TTableColumn()
      {
        tc_orgin_name = "cs_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("cs_Name", new TTableColumn()
      {
        tc_orgin_name = "cs_Name",
        tc_trans_name = "컬럼명"
      });
      columnInfo.Add("cs_Desc", new TTableColumn()
      {
        tc_orgin_name = "cs_Desc",
        tc_trans_name = "컬럼명 설명"
      });
      columnInfo.Add("cs_Width", new TTableColumn()
      {
        tc_orgin_name = "cs_Width",
        tc_trans_name = "컬럼 사이즈"
      });
      columnInfo.Add("cs_Align", new TTableColumn()
      {
        tc_orgin_name = "cs_Align",
        tc_trans_name = "컬럼 정렬"
      });
      columnInfo.Add("cs_UseYn", new TTableColumn()
      {
        tc_orgin_name = "cs_UseYn",
        tc_trans_name = "사용상태"
      });
      columnInfo.Add("cs_Foreground", new TTableColumn()
      {
        tc_orgin_name = "cs_Foreground",
        tc_trans_name = "전경색"
      });
      columnInfo.Add("cs_BackgroundR", new TTableColumn()
      {
        tc_orgin_name = "cs_BackgroundR",
        tc_trans_name = "배경색 RED"
      });
      columnInfo.Add("cs_BackgroundG", new TTableColumn()
      {
        tc_orgin_name = "cs_BackgroundG",
        tc_trans_name = "배경색 GREEN"
      });
      columnInfo.Add("cs_BackgroundB", new TTableColumn()
      {
        tc_orgin_name = "cs_BackgroundB",
        tc_trans_name = "배경색 BLUE"
      });
      columnInfo.Add("cs_BackgroundOpacity", new TTableColumn()
      {
        tc_orgin_name = "cs_BackgroundOpacity",
        tc_trans_name = "배경색 투명도"
      });
      columnInfo.Add("cs_Bold", new TTableColumn()
      {
        tc_orgin_name = "cs_Bold",
        tc_trans_name = "글꼴 굵기"
      });
      columnInfo.Add("cs_Italic", new TTableColumn()
      {
        tc_orgin_name = "cs_Italic",
        tc_trans_name = "글꼴 기울기"
      });
      columnInfo.Add("cs_AddProperty", new TTableColumn()
      {
        tc_orgin_name = "cs_AddProperty",
        tc_trans_name = "속성타입"
      });
      columnInfo.Add("cs_InDate", new TTableColumn()
      {
        tc_orgin_name = "cs_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("cs_InUser", new TTableColumn()
      {
        tc_orgin_name = "cs_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("cs_ModDate", new TTableColumn()
      {
        tc_orgin_name = "cs_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("cs_ModUser", new TTableColumn()
      {
        tc_orgin_name = "cs_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.ColStyle;
      this.cs_Code = 0;
      this.cs_SiteID = 0L;
      this.cs_Name = string.Empty;
      this.cs_Desc = string.Empty;
      this.cs_UseYn = "Y";
      this.cs_Foreground = "#000000";
      this.cs_BackgroundR = this.cs_BackgroundG = this.cs_BackgroundB = 0;
      this.cs_BackgroundOpacity = 0.0;
      this.cs_Align = 0;
      this.cs_Bold = this.cs_Italic = 0;
      this.cs_AddProperty = 0;
      this.cs_InDate = new DateTime?();
      this.cs_InUser = 0;
      this.cs_ModDate = new DateTime?();
      this.cs_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TColStyle();

    public override object Clone()
    {
      TColStyle tcolStyle = base.Clone() as TColStyle;
      tcolStyle.cs_SiteID = this.cs_SiteID;
      tcolStyle.cs_Code = this.cs_Code;
      tcolStyle.cs_Name = this.cs_Name;
      tcolStyle.cs_Desc = this.cs_Desc;
      tcolStyle.cs_UseYn = this.cs_UseYn;
      tcolStyle.cs_Foreground = this.cs_Foreground;
      tcolStyle.cs_BackgroundR = this.cs_BackgroundR;
      tcolStyle.cs_BackgroundG = this.cs_BackgroundG;
      tcolStyle.cs_BackgroundB = this.cs_BackgroundB;
      tcolStyle.cs_BackgroundOpacity = this.cs_BackgroundOpacity;
      tcolStyle.cs_Align = this.cs_Align;
      tcolStyle.cs_Bold = this.cs_Bold;
      tcolStyle.cs_Italic = this.cs_Italic;
      tcolStyle.cs_AddProperty = this.cs_AddProperty;
      tcolStyle.cs_InDate = this.cs_InDate;
      tcolStyle.cs_ModDate = this.cs_ModDate;
      tcolStyle.cs_InUser = this.cs_InUser;
      tcolStyle.cs_ModUser = this.cs_ModUser;
      return (object) tcolStyle;
    }

    public void PutData(TColStyle pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.cs_SiteID = pSource.cs_SiteID;
      this.cs_Code = pSource.cs_Code;
      this.cs_Name = pSource.cs_Name;
      this.cs_Desc = pSource.cs_Desc;
      this.cs_UseYn = pSource.cs_UseYn;
      this.cs_Foreground = pSource.cs_Foreground;
      this.cs_BackgroundR = pSource.cs_BackgroundR;
      this.cs_BackgroundG = pSource.cs_BackgroundG;
      this.cs_BackgroundB = pSource.cs_BackgroundB;
      this.cs_BackgroundOpacity = pSource.cs_BackgroundOpacity;
      this.cs_Align = pSource.cs_Align;
      this.cs_Bold = pSource.cs_Bold;
      this.cs_Italic = pSource.cs_Italic;
      this.cs_AddProperty = pSource.cs_AddProperty;
      this.cs_InDate = pSource.cs_InDate;
      this.cs_ModDate = pSource.cs_ModDate;
      this.cs_InUser = pSource.cs_InUser;
      this.cs_ModUser = pSource.cs_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.cs_Code = p_rs.GetFieldInt("cs_Code");
        if (this.cs_Code == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.cs_SiteID = p_rs.GetFieldLong("cs_SiteID");
        this.cs_Name = p_rs.GetFieldString("cs_Name");
        this.cs_Desc = p_rs.GetFieldString("cs_Desc");
        this.cs_UseYn = p_rs.GetFieldString("cs_UseYn");
        this.cs_Foreground = p_rs.GetFieldString("cs_Foreground");
        this.cs_BackgroundR = p_rs.GetFieldInt("cs_BackgroundR");
        this.cs_BackgroundG = p_rs.GetFieldInt("cs_BackgroundG");
        this.cs_BackgroundB = p_rs.GetFieldInt("cs_BackgroundB");
        this.cs_BackgroundOpacity = p_rs.GetFieldDouble("cs_BackgroundOpacity");
        this.cs_Align = p_rs.GetFieldInt("cs_Align");
        this.cs_Bold = p_rs.GetFieldInt("cs_Bold");
        this.cs_Italic = p_rs.GetFieldInt("cs_Italic");
        this.cs_AddProperty = p_rs.GetFieldInt("cs_AddProperty");
        this.cs_InDate = p_rs.GetFieldDateTime("cs_InDate");
        this.cs_InUser = p_rs.GetFieldInt("cs_InUser");
        this.cs_ModDate = p_rs.GetFieldDateTime("cs_ModDate");
        this.cs_ModUser = p_rs.GetFieldInt("cs_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " cs_Code,cs_SiteID,cs_Name,cs_Desc,cs_UseYn,cs_Foreground,cs_BackgroundR,cs_BackgroundG,cs_BackgroundB,cs_BackgroundOpacity,cs_Align,cs_Bold,cs_Italic,cs_AddProperty,cs_InDate,cs_InUser,cs_ModDate,cs_ModUser) VALUES ( " + string.Format(" {0}", (object) this.cs_Code) + string.Format(",{0}", (object) this.cs_SiteID) + ",'" + this.cs_Name + "','" + this.cs_Desc + "','" + this.cs_UseYn + "','" + this.cs_Foreground + "'" + string.Format(",{0},{1},{2},{3}", (object) this.cs_BackgroundR, (object) this.cs_BackgroundG, (object) this.cs_BackgroundB, (object) this.cs_BackgroundOpacity.FormatTo("{0:0.0}")) + string.Format(",{0},{1},{2},{3}", (object) this.cs_Align, (object) this.cs_Bold, (object) this.cs_Italic, (object) this.cs_AddProperty) + string.Format(",{0},{1}", (object) this.cs_InDate.GetDateToStrInNull(), (object) this.cs_InUser) + string.Format(",{0},{1}", (object) this.cs_ModDate.GetDateToStrInNull(), (object) this.cs_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.cs_Code, (object) this.cs_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TColStyle tcolStyle = this;
      // ISSUE: reference to a compiler-generated method
      tcolStyle.\u003C\u003En__0();
      if (await tcolStyle.OleDB.ExecuteAsync(tcolStyle.InsertQuery()))
        return true;
      tcolStyle.message = " " + tcolStyle.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tcolStyle.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tcolStyle.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tcolStyle.cs_Code, (object) tcolStyle.cs_SiteID) + " 내용 : " + tcolStyle.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tcolStyle.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " cs_Name='" + this.cs_Name + "',cs_Desc='" + this.cs_Desc + "',cs_UseYn='" + this.cs_UseYn + "',cs_Foreground='" + this.cs_Foreground + "'" + string.Format(",{0}={1},{2}={3}", (object) "cs_BackgroundR", (object) this.cs_BackgroundR, (object) "cs_BackgroundG", (object) this.cs_BackgroundG) + string.Format(",{0}={1}", (object) "cs_BackgroundB", (object) this.cs_BackgroundB) + ",cs_BackgroundOpacity=" + this.cs_BackgroundOpacity.FormatTo("{0:0.0}") + string.Format(",{0}={1},{2}={3}", (object) "cs_Align", (object) this.cs_Align, (object) "cs_Bold", (object) this.cs_Bold) + string.Format(",{0}={1},{2}={3}", (object) "cs_Italic", (object) this.cs_Italic, (object) "cs_AddProperty", (object) this.cs_AddProperty) + string.Format(",{0}={1},{2}={3}", (object) "cs_ModDate", (object) this.cs_ModDate.GetDateToStrInNull(), (object) "cs_ModUser", (object) this.cs_ModUser) + string.Format(" WHERE {0}={1}", (object) "cs_Code", (object) this.cs_Code) + string.Format(" AND {0}={1}", (object) "cs_SiteID", (object) this.cs_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.cs_Code, (object) this.cs_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TColStyle tcolStyle = this;
      // ISSUE: reference to a compiler-generated method
      tcolStyle.\u003C\u003En__1();
      if (await tcolStyle.OleDB.ExecuteAsync(tcolStyle.UpdateQuery()))
        return true;
      tcolStyle.message = " " + tcolStyle.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tcolStyle.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tcolStyle.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tcolStyle.cs_Code, (object) tcolStyle.cs_SiteID) + " 내용 : " + tcolStyle.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tcolStyle.message);
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
      stringBuilder.Append(" cs_Name='" + this.cs_Name + "',cs_Desc='" + this.cs_Desc + "',cs_UseYn='" + this.cs_UseYn + "',cs_Foreground='" + this.cs_Foreground + "'" + string.Format(",{0}={1},{2}={3}", (object) "cs_BackgroundR", (object) this.cs_BackgroundR, (object) "cs_BackgroundG", (object) this.cs_BackgroundG) + string.Format(",{0}={1}", (object) "cs_BackgroundB", (object) this.cs_BackgroundB) + ",cs_BackgroundOpacity=" + this.cs_BackgroundOpacity.FormatTo("{0:0.0}") + string.Format(",{0}={1},{2}={3}", (object) "cs_Align", (object) this.cs_Align, (object) "cs_Bold", (object) this.cs_Bold) + string.Format(",{0}={1},{2}={3}", (object) "cs_Italic", (object) this.cs_Italic, (object) "cs_AddProperty", (object) this.cs_AddProperty) + string.Format(",{0}={1},{2}={3}", (object) "cs_ModDate", (object) this.cs_ModDate.GetDateToStrInNull(), (object) "cs_ModUser", (object) this.cs_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.cs_Code, (object) this.cs_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TColStyle tcolStyle = this;
      // ISSUE: reference to a compiler-generated method
      tcolStyle.\u003C\u003En__1();
      if (await tcolStyle.OleDB.ExecuteAsync(tcolStyle.UpdateExInsertQuery()))
        return true;
      tcolStyle.message = " " + tcolStyle.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tcolStyle.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tcolStyle.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tcolStyle.cs_Code, (object) tcolStyle.cs_SiteID) + " 내용 : " + tcolStyle.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tcolStyle.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "cs_SiteID") && Convert.ToInt64(hashtable[(object) "cs_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "cs_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "cs_Code") && Convert.ToInt32(hashtable[(object) "cs_Code"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "cs_Code", hashtable[(object) "cs_Code"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "cs_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "cs_Name") && hashtable[(object) "cs_Name"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "cs_Name", hashtable[(object) "cs_Name"]));
        if (hashtable.ContainsKey((object) "cs_UseYn") && hashtable[(object) "cs_UseYn"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "cs_UseYn", hashtable[(object) "cs_UseYn"]));
        if (hashtable.ContainsKey((object) "cs_Align") && Convert.ToInt32(hashtable[(object) "cs_Align"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "cs_Align", hashtable[(object) "cs_Align"]));
        if (hashtable.ContainsKey((object) "cs_Bold") && Convert.ToInt32(hashtable[(object) "cs_Bold"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "cs_Bold", hashtable[(object) "cs_Bold"]));
        if (hashtable.ContainsKey((object) "cs_Italic") && Convert.ToInt32(hashtable[(object) "cs_Italic"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "cs_Italic", hashtable[(object) "cs_Italic"]));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "cs_Name", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "cs_Desc", hashtable[(object) "_KEY_WORD_"]));
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
        string uniBase = UbModelBase.UNI_BASE;
        string str = this.TableCode.ToString();
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
        }
        stringBuilder.Append(" SELECT  cs_Code,cs_SiteID,cs_Name,cs_Desc,cs_UseYn,cs_Foreground,cs_BackgroundR,cs_BackgroundG,cs_BackgroundB,cs_BackgroundOpacity,cs_Align,cs_Bold,cs_Italic,cs_AddProperty,cs_InDate,cs_InUser,cs_ModDate,cs_ModUser");
        stringBuilder.Append(" FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock());
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
