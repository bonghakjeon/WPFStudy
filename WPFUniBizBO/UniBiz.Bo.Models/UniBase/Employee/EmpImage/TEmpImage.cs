// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Employee.EmpImage.TEmpImage
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using Serilog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.TableInfo;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniBase.Employee.EmpImage
{
  public class TEmpImage : UbModelBase<TEmpImage>
  {
    private int _ei_EmpCode;
    private long _ei_SiteID;
    private string _ei_ImgFileName;
    private int _ei_ImgType;
    private int _ei_ThumbSize;
    protected byte[] _ei_ThumbData = new byte[0];
    private int _ei_OriginSize;
    protected byte[] _ei_OriginData = new byte[0];
    private DateTime? _ei_InDate;
    private int _ei_InUser;
    private DateTime? _ei_ModDate;
    private int _ei_ModUser;

    public override object _Key => (object) new object[1]
    {
      (object) this.ei_EmpCode
    };

    public int ei_EmpCode
    {
      get => this._ei_EmpCode;
      set
      {
        this._ei_EmpCode = value;
        this.Changed(nameof (ei_EmpCode));
      }
    }

    public long ei_SiteID
    {
      get => this._ei_SiteID;
      set
      {
        this._ei_SiteID = value;
        this.Changed(nameof (ei_SiteID));
      }
    }

    public string ei_ImgFileName
    {
      get => this._ei_ImgFileName;
      set
      {
        this._ei_ImgFileName = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (ei_ImgFileName));
        this.ei_ImgType = (int) Enum2StrConverter.GetFileExtensionType(Path.GetExtension(this._ei_ImgFileName));
      }
    }

    public int ei_ImgType
    {
      get => this._ei_ImgType;
      set
      {
        this._ei_ImgType = value;
        this.Changed(nameof (ei_ImgType));
      }
    }

    public int ei_ThumbSize
    {
      get => this._ei_ThumbSize;
      set
      {
        this._ei_ThumbSize = value;
        this.Changed(nameof (ei_ThumbSize));
      }
    }

    public byte[] ei_ThumbData
    {
      get => this._ei_ThumbData;
      set
      {
        this._ei_ThumbData = value;
        if (this._ei_ThumbData != null)
          this.ei_ThumbSize = this._ei_ThumbData.Length;
        this.Changed(nameof (ei_ThumbData));
        this.Changed("IsThumbData");
        this.Changed("Base64Data");
        this.Changed("Base64DataSize");
      }
    }

    [JsonIgnore]
    public bool IsThumbData => this.ei_ThumbData != null && this.ei_ThumbData.Length != 0;

    public int ei_OriginSize
    {
      get => this._ei_OriginSize;
      set
      {
        this._ei_OriginSize = value;
        this.Changed(nameof (ei_OriginSize));
      }
    }

    public byte[] ei_OriginData
    {
      get => this._ei_OriginData;
      set
      {
        this._ei_OriginData = value;
        if (this._ei_OriginData != null)
          this.ei_OriginSize = this._ei_OriginData.Length;
        this.Changed(nameof (ei_OriginData));
        this.Changed("IsOriginData");
        this.Changed("Base64Data");
        this.Changed("Base64DataSize");
      }
    }

    [JsonIgnore]
    public bool IsOriginData => this.ei_OriginData != null && this.ei_OriginData.Length != 0;

    public string Base64Data
    {
      get
      {
        string fileExtensionName = Enum2StrConverter.ToImageFileExtensionName(this.ei_ImgType);
        if (this.IsOriginData)
          return "data:image/" + fileExtensionName + ";base64," + this.ei_OriginData.ToBase64();
        return this.IsThumbData ? "data:image/" + fileExtensionName + ";base64," + this.ei_ThumbData.ToBase64() : (string) null;
      }
    }

    public int Base64DataSize
    {
      get
      {
        if (this.IsOriginData)
          return this.ei_OriginData.Length;
        return !this.IsThumbData ? 0 : this.ei_ThumbData.Length;
      }
    }

    public DateTime? ei_InDate
    {
      get => this._ei_InDate;
      set
      {
        this._ei_InDate = value;
        this.Changed(nameof (ei_InDate));
      }
    }

    public int ei_InUser
    {
      get => this._ei_InUser;
      set
      {
        this._ei_InUser = value;
        this.Changed(nameof (ei_InUser));
      }
    }

    public DateTime? ei_ModDate
    {
      get => this._ei_ModDate;
      set
      {
        this._ei_ModDate = value;
        this.Changed(nameof (ei_ModDate));
      }
    }

    public int ei_ModUser
    {
      get => this._ei_ModUser;
      set
      {
        this._ei_ModUser = value;
        this.Changed(nameof (ei_ModUser));
      }
    }

    public TEmpImage() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("ei_EmpCode", new TTableColumn()
      {
        tc_orgin_name = "ei_EmpCode",
        tc_trans_name = "사원코드"
      });
      columnInfo.Add("ei_SiteID", new TTableColumn()
      {
        tc_orgin_name = "ei_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("ei_ImgFileName", new TTableColumn()
      {
        tc_orgin_name = "ei_ImgFileName",
        tc_trans_name = "파일명"
      });
      columnInfo.Add("ei_ImgType", new TTableColumn()
      {
        tc_orgin_name = "ei_ImgType",
        tc_trans_name = "이미지타입"
      });
      columnInfo.Add("ei_ThumbSize", new TTableColumn()
      {
        tc_orgin_name = "ei_ThumbSize",
        tc_trans_name = "사원 썸네일 크기"
      });
      columnInfo.Add("ei_ThumbData", new TTableColumn()
      {
        tc_orgin_name = "ei_ThumbData",
        tc_trans_name = "사원 썸네일"
      });
      columnInfo.Add("ei_OriginSize", new TTableColumn()
      {
        tc_orgin_name = "ei_OriginSize",
        tc_trans_name = "사원 이미지 크기"
      });
      columnInfo.Add("ei_OriginData", new TTableColumn()
      {
        tc_orgin_name = "ei_OriginData",
        tc_trans_name = "사원 이미지"
      });
      columnInfo.Add("ei_InDate", new TTableColumn()
      {
        tc_orgin_name = "ei_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("ei_InUser", new TTableColumn()
      {
        tc_orgin_name = "ei_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("ei_ModDate", new TTableColumn()
      {
        tc_orgin_name = "ei_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("ei_ModUser", new TTableColumn()
      {
        tc_orgin_name = "ei_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.EmpImage;
      this.ei_EmpCode = 0;
      this.ei_SiteID = 0L;
      this.ei_ImgFileName = string.Empty;
      this.ei_ImgType = 0;
      this.ei_ThumbSize = 0;
      this.ei_ThumbData = new byte[0];
      this.ei_OriginSize = 0;
      this.ei_OriginData = new byte[0];
      this.ei_InDate = new DateTime?();
      this.ei_ModDate = new DateTime?();
      this.ei_InUser = this.ei_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TEmpImage();

    public override object Clone()
    {
      TEmpImage tempImage = base.Clone() as TEmpImage;
      tempImage.ei_EmpCode = this.ei_EmpCode;
      tempImage.ei_SiteID = this.ei_SiteID;
      tempImage.ei_ImgFileName = this.ei_ImgFileName;
      tempImage.ei_ImgType = this.ei_ImgType;
      tempImage.ei_ThumbSize = this.ei_ThumbSize;
      tempImage.ei_ThumbData = this.ei_ThumbData;
      tempImage.ei_OriginSize = this.ei_OriginSize;
      tempImage.ei_OriginData = this.ei_OriginData;
      tempImage.ei_InDate = this.ei_InDate;
      tempImage.ei_ModDate = this.ei_ModDate;
      tempImage.ei_InUser = this.ei_InUser;
      tempImage.ei_ModUser = this.ei_ModUser;
      return (object) tempImage;
    }

    public void PutData(TEmpImage pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.ei_EmpCode = pSource.ei_EmpCode;
      this.ei_SiteID = pSource.ei_SiteID;
      this.ei_ImgFileName = pSource.ei_ImgFileName;
      this.ei_ImgType = pSource.ei_ImgType;
      this.ei_ThumbSize = pSource.ei_ThumbSize;
      this.ei_ThumbData = pSource.ei_ThumbData;
      this.ei_OriginSize = pSource.ei_OriginSize;
      this.ei_OriginData = pSource.ei_OriginData;
      this.ei_InDate = pSource.ei_InDate;
      this.ei_ModDate = pSource.ei_ModDate;
      this.ei_InUser = pSource.ei_InUser;
      this.ei_ModUser = pSource.ei_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.ei_EmpCode = p_rs.GetFieldInt("ei_EmpCode");
        if (this.ei_EmpCode == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.ei_SiteID = p_rs.GetFieldLong("ei_SiteID");
        this.ei_ImgFileName = p_rs.GetFieldString("ei_ImgFileName");
        this.ei_ImgType = p_rs.GetFieldInt("ei_ImgType");
        this.ei_ThumbSize = p_rs.GetFieldInt("ei_ThumbSize");
        this.ei_OriginSize = p_rs.GetFieldInt("ei_OriginSize");
        if (p_rs.IsFieldName("ei_ThumbData"))
        {
          if (this.ei_ThumbData != null)
            this.ei_ThumbData = (byte[]) null;
          this.ei_ThumbData = p_rs.GetFieldBytes("ei_ThumbData");
        }
        if (p_rs.IsFieldName("ei_OriginData"))
        {
          if (this.ei_OriginData != null)
            this.ei_OriginData = (byte[]) null;
          this.ei_OriginData = p_rs.GetFieldBytes("ei_OriginData");
        }
        this.ei_InDate = p_rs.GetFieldDateTime("ei_InDate");
        this.ei_InUser = p_rs.GetFieldInt("ei_InUser");
        this.ei_ModDate = p_rs.GetFieldDateTime("ei_ModDate");
        this.ei_ModUser = p_rs.GetFieldInt("ei_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public void SetThumbData(byte[] pByteValue)
    {
      if (Enum2StrConverter.IsExtensionWebp(this.ei_ImgType))
      {
        this.ei_ThumbData = pByteValue;
      }
      else
      {
        if (!Enum2StrConverter.IsExtensionImage(this.ei_ImgType))
          return;
        using (Image image = Image.FromStream((Stream) new MemoryStream(pByteValue)))
        {
          int thumbHeight;
          int thumbWidth;
          if (image.Height <= 300 && image.Width <= 300)
          {
            thumbHeight = image.Height;
            thumbWidth = image.Width;
          }
          else if (image.Height > image.Width)
          {
            thumbHeight = 300;
            thumbWidth = (int) ((double) image.Width / (double) image.Height * 300.0);
          }
          else if (image.Height < image.Width)
          {
            thumbWidth = 300;
            thumbHeight = (int) ((double) image.Height / (double) image.Width * 300.0);
          }
          else
            thumbWidth = thumbHeight = 300;
          using (Image thumbnailImage = image.GetThumbnailImage(thumbWidth, thumbHeight, (Image.GetThumbnailImageAbort) (() => false), IntPtr.Zero))
            this.ei_ThumbData = (!Enum2StrConverter.IsExtensionPng(this.ei_ImgType) ? thumbnailImage.ToMemoryStream(ImageFormat.Jpeg) : thumbnailImage.ToMemoryStream(ImageFormat.Png)).ToArray();
        }
      }
    }

    protected bool UpdateFile()
    {
      UniOleDbRecordset uniOleDbRecordset = (UniOleDbRecordset) null;
      UniOleDatabase pOleDB = (UniOleDatabase) null;
      try
      {
        if (!this.IsOriginData)
          return false;
        pOleDB = new UniOleDatabase(this.OleDB.ConnectionUrl);
        uniOleDbRecordset = new UniOleDbRecordset(pOleDB, this.OleDB.CommandTimeout);
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " ei_OriginData=?,ei_ImgType=?,ei_ImgFileName=?,ei_OriginSize=?");
        if (this.IsThumbData)
          stringBuilder.Append(",ei_ThumbData=?,ei_ThumbSize=?");
        stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "ei_EmpCode", (object) this.ei_EmpCode));
        using (OleDbCommand command = new OleDbCommand(stringBuilder.ToString(), pOleDB.Connection, pOleDB.Transaction))
        {
          command.Parameters.Add("@ei_OriginData", OleDbType.LongVarBinary, this.ei_OriginData.Length, "ei_OriginData").Value = (object) this.ei_OriginData;
          command.Parameters.Add("@ei_ImgType", OleDbType.Integer).Value = (object) this.ei_ImgType;
          command.Parameters.Add("@ei_ImgFileName", OleDbType.VarChar, Encoding.Default.GetByteCount(this.ei_ImgFileName)).Value = (object) this.ei_ImgFileName;
          command.Parameters.Add("@ei_OriginSize", OleDbType.Integer).Value = (object) this.ei_OriginSize;
          if (this.IsThumbData)
          {
            command.Parameters.Add("@ei_ThumbData", OleDbType.LongVarBinary, this.ei_ThumbData.Length, "ei_ThumbData").Value = (object) this.ei_ThumbData;
            command.Parameters.Add("@ei_ThumbSize", OleDbType.Integer).Value = (object) this.ei_ThumbSize;
          }
          if (!uniOleDbRecordset.Update(command))
            throw new Exception("이미지 파일 저장 실패 -Update()\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : 이미지 파일 저장 실패 \n" + string.Format(" 에러 : {0}\n", (object) uniOleDbRecordset.LastErrorID) + "     " + uniOleDbRecordset.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
        }
        return true;
      }
      catch (Exception ex)
      {
        Log.Logger.ErrorColor("\n--------------------------------------------------------------------------------------------------\n" + ex.Message + "\n--------------------------------------------------------------------------------------------------");
        return this.SetErrorInfo(0L, ex.Message);
      }
      finally
      {
        uniOleDbRecordset?.Close();
        pOleDB?.Close();
      }
    }

    protected async Task<bool> UpdateFileAsync()
    {
      TEmpImage tempImage = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        if (!tempImage.IsOriginData)
          return false;
        db = new UniOleDatabase(tempImage.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, tempImage.OleDB.CommandTimeout);
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) tempImage.TableCode) + " ei_OriginData=?,ei_ImgType=?,ei_ImgFileName=?,ei_OriginSize=?");
        if (tempImage.IsThumbData)
          stringBuilder.Append(",ei_ThumbData=?,ei_ThumbSize=?");
        stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "ei_EmpCode", (object) tempImage.ei_EmpCode));
        using (OleDbCommand command = new OleDbCommand(stringBuilder.ToString(), db.Connection, db.Transaction))
        {
          command.Parameters.Add("@ei_OriginData", OleDbType.LongVarBinary, tempImage.ei_OriginData.Length).Value = (object) tempImage.ei_OriginData;
          command.Parameters.Add("@ei_ImgType", OleDbType.Integer).Value = (object) tempImage.ei_ImgType;
          command.Parameters.Add("@ei_ImgFileName", OleDbType.VarChar, Encoding.Default.GetByteCount(tempImage.ei_ImgFileName)).Value = (object) tempImage.ei_ImgFileName;
          command.Parameters.Add("@ei_OriginSize", OleDbType.Integer).Value = (object) tempImage.ei_OriginSize;
          if (tempImage.IsThumbData)
          {
            command.Parameters.Add("@ei_ThumbData", OleDbType.LongVarBinary, tempImage.ei_ThumbData.Length).Value = (object) tempImage.ei_ThumbData;
            command.Parameters.Add("@ei_ThumbSize", OleDbType.Integer).Value = (object) tempImage.ei_ThumbSize;
          }
          command.CommandTimeout = 0;
          if (!await rs.UpdateAsync(command))
            throw new Exception("이미지 파일 저장 실패 -Update()\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tempImage.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : 이미지 파일 저장 실패 \n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + "     " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
        }
        return true;
      }
      catch (Exception ex)
      {
        Log.Logger.ErrorColor("\n--------------------------------------------------------------------------------------------------\n" + ex.Message + "\n--------------------------------------------------------------------------------------------------");
        return tempImage.SetErrorInfo(0L, ex.Message);
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public override string InsertQuery()
    {
      if (!this.ei_InDate.HasValue)
        this.ei_InDate = new DateTime?(DateTime.Now);
      return string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " ei_EmpCode,ei_SiteID,ei_InDate,ei_InUser,ei_ModDate,ei_ModUser) VALUES ( " + string.Format(" {0}", (object) this.ei_EmpCode) + string.Format(",{0}", (object) this.ei_SiteID) + string.Format(",{0},{1},{2},{3}", (object) this.ei_InDate.GetDateToStrInNull(), (object) this.ei_InUser, (object) this.ei_ModDate.GetDateToStrInNull(), (object) this.ei_ModUser) + ")";
    }

    public override bool Insert()
    {
      this.InsertChecked();
      string pStrExec = this.InsertQuery();
      if (this.OleDB.Execute(pStrExec))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 등록 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 코드 : ({0})\n", (object) this.ei_EmpCode) + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n 쿼리 : " + pStrExec + "\n--------------------------------------------------------------------------------------------------\n";
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TEmpImage tempImage = this;
      // ISSUE: reference to a compiler-generated method
      tempImage.\u003C\u003En__0();
      if (await tempImage.OleDB.ExecuteAsync(tempImage.InsertQuery()))
        return true;
      tempImage.message = " " + tempImage.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tempImage.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tempImage.OleDB.LastErrorID) + string.Format(" 코드 : {0}\n", (object) tempImage.ei_EmpCode) + " 내용 : " + tempImage.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tempImage.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + string.Format(" {0}={1},{2}={3}", (object) "ei_ModDate", (object) this.ei_ModDate.GetDateToStrInNull(), (object) "ei_ModUser", (object) this.ei_ModUser) + string.Format(" WHERE {0}={1}", (object) "ei_EmpCode", (object) this.ei_EmpCode);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : {0}\n", (object) this.ei_EmpCode) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TEmpImage tempImage = this;
      // ISSUE: reference to a compiler-generated method
      tempImage.\u003C\u003En__1();
      if (await tempImage.OleDB.ExecuteAsync(tempImage.UpdateQuery()))
        return true;
      tempImage.message = " " + tempImage.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tempImage.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tempImage.OleDB.LastErrorID) + string.Format(" 코드 : {0}\n", (object) tempImage.ei_EmpCode) + " 내용 : " + tempImage.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tempImage.message);
      return false;
    }

    public override string DeleteQuery() => string.Format(" DELETE FROM {0}{1}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + string.Format(" WHERE {0}={1}", (object) "ei_EmpCode", (object) this.ei_EmpCode);

    public override bool Delete()
    {
      this.InsertChecked();
      string pStrExec = this.DeleteQuery();
      if (this.OleDB.Execute(pStrExec))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 삭제 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 코드 : ({0})\n", (object) this.ei_EmpCode) + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n 쿼리 : " + pStrExec + "\n--------------------------------------------------------------------------------------------------\n";
      return false;
    }

    public override async Task<bool> DeleteAsync()
    {
      TEmpImage tempImage = this;
      // ISSUE: reference to a compiler-generated method
      tempImage.\u003C\u003En__0();
      if (await tempImage.OleDB.ExecuteAsync(tempImage.DeleteQuery()))
        return true;
      tempImage.message = " " + tempImage.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tempImage.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tempImage.OleDB.LastErrorID) + string.Format(" 코드 : {0}\n", (object) tempImage.ei_EmpCode) + " 내용 : " + tempImage.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tempImage.message);
      return false;
    }

    public virtual string DeleteQuery(int p_ei_EmpCode, long p_ei_SiteID = 0)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format(" DELETE FROM {0}{1} ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode));
      stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "ei_EmpCode", (object) p_ei_EmpCode));
      if (p_ei_SiteID > 0L)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ei_SiteID", (object) p_ei_SiteID));
      return stringBuilder.ToString();
    }

    public virtual bool SelectThis(
      UniOleDbRecordset p_rs,
      int p_ei_EmpCode,
      long p_ei_SiteID = 0,
      bool p_is_thumb_data = true,
      bool p_is_file_data = false)
    {
      try
      {
        Hashtable p_param = new Hashtable()
        {
          {
            (object) "ei_EmpCode",
            (object) p_ei_EmpCode
          },
          {
            (object) "IS_THUMB_IMAGE_VIEW",
            (object) p_is_thumb_data
          },
          {
            (object) "IS_FILE_IMAGE_VIEW",
            (object) p_is_file_data
          }
        };
        if (p_ei_SiteID > 0L)
          p_param.Add((object) "ei_SiteID", (object) p_ei_SiteID);
        string selectQuery = this.GetSelectQuery((object) p_param);
        if (!p_rs.Open(selectQuery))
          throw new Exception("검색 오류 - SQL SELECT 실패");
        if (!p_rs.IsDataRead())
          throw new Exception("검색 오류 - COUNT = 0");
        if (!this.GetFieldValues(p_rs))
          throw new Exception("검색 오류 - GetFieldValues 실패");
        return this.SetSuccessInfo(string.Format("{0}({1}) 검색됨", (object) this.ei_ImgFileName, (object) this.ei_EmpCode));
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " SelectThis 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 코드 : ({0},{1})\n", (object) p_ei_EmpCode, (object) p_ei_SiteID) + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
      }
      return false;
    }

    public virtual async Task<IList<TEmpImage>> SelectTListAsync(object p_param)
    {
      TEmpImage tempImage1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(tempImage1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, tempImage1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(tempImage1.GetSelectQuery(p_param)))
        {
          tempImage1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tempImage1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tempImage1.OleDB.LastErrorID) + " 내용 : " + tempImage1.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<TEmpImage>) null;
        }
        IList<TEmpImage> lt_list = (IList<TEmpImage>) new List<TEmpImage>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            TEmpImage tempImage2 = tempImage1.OleDB.Create<TEmpImage>();
            if (tempImage2.GetFieldValues(rs))
            {
              tempImage2.row_number = lt_list.Count + 1;
              lt_list.Add(tempImage2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tempImage1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
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
        long num = 0;
        if (hashtable.ContainsKey((object) "ei_SiteID") && Convert.ToInt64(hashtable[(object) "ei_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "ei_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "ei_EmpCode") && Convert.ToInt32(hashtable[(object) "ei_EmpCode"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ei_EmpCode", hashtable[(object) "ei_EmpCode"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ei_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "ei_ImgFileName") && hashtable[(object) "ei_ImgFileName"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "ei_ImgFileName", hashtable[(object) "ei_ImgFileName"]));
        if (hashtable.ContainsKey((object) "ei_ImgType") && Convert.ToInt32(hashtable[(object) "ei_ImgType"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "ei_ImgType", hashtable[(object) "ei_ImgType"]));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "ei_ImgFileName", hashtable[(object) "_KEY_WORD_"]));
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
        bool flag1 = false;
        bool flag2 = false;
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
          if (hashtable.ContainsKey((object) "IS_THUMB_IMAGE_VIEW") && Convert.ToBoolean(hashtable[(object) "IS_THUMB_IMAGE_VIEW"].ToString()))
            flag1 = Convert.ToBoolean(hashtable[(object) "IS_THUMB_IMAGE_VIEW"].ToString());
          if (hashtable.ContainsKey((object) "IS_FILE_IMAGE_VIEW") && Convert.ToBoolean(hashtable[(object) "IS_FILE_IMAGE_VIEW"].ToString()))
            flag2 = Convert.ToBoolean(hashtable[(object) "IS_FILE_IMAGE_VIEW"].ToString());
        }
        stringBuilder.Append(" SELECT  ei_EmpCode,ei_SiteID,ei_ImgFileName,ei_ImgType,ei_ThumbSize,ei_OriginSize,ei_InDate,ei_InUser,ei_ModDate,ei_ModUser");
        if (flag1)
          stringBuilder.Append(",ei_ThumbData");
        if (flag2)
          stringBuilder.Append(",ei_OriginData");
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
