// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsImage.TGoodsImage
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

namespace UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsImage
{
  public class TGoodsImage : UbModelBase<TGoodsImage>
  {
    private long _gi_GoodsCode;
    private long _gi_SiteID;
    private string _gi_ImgFileName;
    private int _gi_ImgType;
    private int _gi_ThumbSize;
    protected byte[] _gi_ThumbData = new byte[0];
    private int _gi_Thumb2Size;
    protected byte[] _gi_Thumb2Data = new byte[0];
    private int _gi_Thumb3Size;
    protected byte[] _gi_Thumb3Data = new byte[0];
    private int _gi_Thumb4Size;
    protected byte[] _gi_Thumb4Data = new byte[0];
    private int _gi_OriginSize;
    protected byte[] _gi_OriginData = new byte[0];
    private DateTime? _gi_InDate;
    private int _gi_InUser;
    private DateTime? _gi_ModDate;
    private int _gi_ModUser;

    public override object _Key => (object) new object[1]
    {
      (object) this.gi_GoodsCode
    };

    public long gi_GoodsCode
    {
      get => this._gi_GoodsCode;
      set
      {
        this._gi_GoodsCode = value;
        this.Changed(nameof (gi_GoodsCode));
      }
    }

    public long gi_SiteID
    {
      get => this._gi_SiteID;
      set
      {
        this._gi_SiteID = value;
        this.Changed(nameof (gi_SiteID));
      }
    }

    public string gi_ImgFileName
    {
      get => this._gi_ImgFileName;
      set
      {
        this._gi_ImgFileName = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (gi_ImgFileName));
        this.gi_ImgType = (int) Enum2StrConverter.GetFileExtensionType(Path.GetExtension(this._gi_ImgFileName));
      }
    }

    public int gi_ImgType
    {
      get => this._gi_ImgType;
      set
      {
        this._gi_ImgType = value;
        this.Changed(nameof (gi_ImgType));
      }
    }

    public int gi_ThumbSize
    {
      get => this._gi_ThumbSize;
      set
      {
        this._gi_ThumbSize = value;
        this.Changed(nameof (gi_ThumbSize));
      }
    }

    public byte[] gi_ThumbData
    {
      get => this._gi_ThumbData;
      set
      {
        this._gi_ThumbData = value;
        if (this._gi_ThumbData != null)
          this.gi_ThumbSize = this._gi_ThumbData.Length;
        this.Changed(nameof (gi_ThumbData));
        this.Changed("IsThumbData");
        this.Changed("Base64Data");
        this.Changed("Base64DataSize");
      }
    }

    [JsonIgnore]
    public bool IsThumbData => this.gi_ThumbData != null && this.gi_ThumbData.Length != 0;

    public int gi_Thumb2Size
    {
      get => this._gi_Thumb2Size;
      set
      {
        this._gi_Thumb2Size = value;
        this.Changed(nameof (gi_Thumb2Size));
      }
    }

    public byte[] gi_Thumb2Data
    {
      get => this._gi_Thumb2Data;
      set
      {
        this._gi_Thumb2Data = value;
        if (this._gi_Thumb2Data != null)
          this.gi_Thumb2Size = this._gi_Thumb2Data.Length;
        this.Changed(nameof (gi_Thumb2Data));
        this.Changed("IsThumb2Data");
        this.Changed("Base64Data");
        this.Changed("Base64DataSize");
      }
    }

    [JsonIgnore]
    public bool IsThumb2Data => this.gi_Thumb2Data != null && this.gi_Thumb2Data.Length != 0;

    public int gi_Thumb3Size
    {
      get => this._gi_Thumb3Size;
      set
      {
        this._gi_Thumb3Size = value;
        this.Changed(nameof (gi_Thumb3Size));
      }
    }

    public byte[] gi_Thumb3Data
    {
      get => this._gi_Thumb3Data;
      set
      {
        this._gi_Thumb3Data = value;
        if (this._gi_Thumb3Data != null)
          this.gi_Thumb3Size = this._gi_Thumb3Data.Length;
        this.Changed(nameof (gi_Thumb3Data));
        this.Changed("IsThumb3Data");
        this.Changed("Base64Data");
        this.Changed("Base64DataSize");
      }
    }

    [JsonIgnore]
    public bool IsThumb3Data => this.gi_Thumb3Data != null && this.gi_Thumb3Data.Length != 0;

    public int gi_Thumb4Size
    {
      get => this._gi_Thumb4Size;
      set
      {
        this._gi_Thumb4Size = value;
        this.Changed(nameof (gi_Thumb4Size));
      }
    }

    public byte[] gi_Thumb4Data
    {
      get => this._gi_Thumb4Data;
      set
      {
        this._gi_Thumb4Data = value;
        if (this._gi_Thumb4Data != null)
          this.gi_Thumb4Size = this._gi_Thumb4Data.Length;
        this.Changed(nameof (gi_Thumb4Data));
        this.Changed("IsThumb4Data");
        this.Changed("Base64Data");
        this.Changed("Base64DataSize");
      }
    }

    [JsonIgnore]
    public bool IsThumb4Data => this.gi_Thumb4Data != null && this.gi_Thumb4Data.Length != 0;

    public int gi_OriginSize
    {
      get => this._gi_OriginSize;
      set
      {
        this._gi_OriginSize = value;
        this.Changed(nameof (gi_OriginSize));
      }
    }

    public byte[] gi_OriginData
    {
      get => this._gi_OriginData;
      set
      {
        this._gi_OriginData = value;
        if (this._gi_OriginData != null)
          this.gi_OriginSize = this._gi_OriginData.Length;
        this.Changed(nameof (gi_OriginData));
        this.Changed("IsOriginData");
        this.Changed("Base64Data");
        this.Changed("Base64DataSize");
      }
    }

    [JsonIgnore]
    public bool IsOriginData => this.gi_OriginData != null && this.gi_OriginData.Length != 0;

    public string Base64Data
    {
      get
      {
        string fileExtensionName = Enum2StrConverter.ToImageFileExtensionName(this.gi_ImgType);
        if (this.IsOriginData)
          return "data:image/" + fileExtensionName + ";base64," + this.gi_OriginData.ToBase64();
        if (this.IsThumb4Data)
          return "data:image/" + fileExtensionName + ";base64," + this.gi_Thumb4Data.ToBase64();
        if (this.IsThumb3Data)
          return "data:image/" + fileExtensionName + ";base64," + this.gi_Thumb3Data.ToBase64();
        if (this.IsThumb2Data)
          return "data:image/" + fileExtensionName + ";base64," + this.gi_Thumb2Data.ToBase64();
        return this.IsThumbData ? "data:image/" + fileExtensionName + ";base64," + this.gi_ThumbData.ToBase64() : (string) null;
      }
    }

    public int Base64DataSize
    {
      get
      {
        if (this.IsOriginData)
          return this.gi_OriginData.Length;
        if (this.IsThumb4Data)
          return this.gi_Thumb4Data.Length;
        if (this.IsThumb3Data)
          return this.gi_Thumb3Data.Length;
        if (this.IsThumb2Data)
          return this.gi_Thumb2Data.Length;
        return this.IsThumbData ? this.gi_ThumbData.Length : 0;
      }
    }

    public DateTime? gi_InDate
    {
      get => this._gi_InDate;
      set
      {
        this._gi_InDate = value;
        this.Changed(nameof (gi_InDate));
      }
    }

    public int gi_InUser
    {
      get => this._gi_InUser;
      set
      {
        this._gi_InUser = value;
        this.Changed(nameof (gi_InUser));
      }
    }

    public DateTime? gi_ModDate
    {
      get => this._gi_ModDate;
      set
      {
        this._gi_ModDate = value;
        this.Changed(nameof (gi_ModDate));
      }
    }

    public int gi_ModUser
    {
      get => this._gi_ModUser;
      set
      {
        this._gi_ModUser = value;
        this.Changed(nameof (gi_ModUser));
      }
    }

    public TGoodsImage() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("gi_GoodsCode", new TTableColumn()
      {
        tc_orgin_name = "gi_GoodsCode",
        tc_trans_name = "상품코드"
      });
      columnInfo.Add("gi_SiteID", new TTableColumn()
      {
        tc_orgin_name = "gi_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("gi_ImgFileName", new TTableColumn()
      {
        tc_orgin_name = "gi_ImgFileName",
        tc_trans_name = "파일명"
      });
      columnInfo.Add("gi_ImgType", new TTableColumn()
      {
        tc_orgin_name = "gi_ImgType",
        tc_trans_name = "이미지타입"
      });
      columnInfo.Add("gi_ThumbSize", new TTableColumn()
      {
        tc_orgin_name = "gi_ThumbSize",
        tc_trans_name = "썸네일 크기"
      });
      columnInfo.Add("gi_ThumbData", new TTableColumn()
      {
        tc_orgin_name = "gi_ThumbData",
        tc_trans_name = "썸네일"
      });
      columnInfo.Add("gi_Thumb2Size", new TTableColumn()
      {
        tc_orgin_name = "gi_Thumb2Size",
        tc_trans_name = "썸네일2 크기"
      });
      columnInfo.Add("gi_Thumb2Data", new TTableColumn()
      {
        tc_orgin_name = "gi_Thumb2Data",
        tc_trans_name = "썸네일2"
      });
      columnInfo.Add("gi_Thumb3Size", new TTableColumn()
      {
        tc_orgin_name = "gi_Thumb3Size",
        tc_trans_name = "썸네일3 크기"
      });
      columnInfo.Add("gi_Thumb3Data", new TTableColumn()
      {
        tc_orgin_name = "gi_Thumb3Data",
        tc_trans_name = "썸네일3"
      });
      columnInfo.Add("gi_Thumb4Size", new TTableColumn()
      {
        tc_orgin_name = "gi_Thumb4Size",
        tc_trans_name = "썸네일4 크기"
      });
      columnInfo.Add("gi_Thumb4Data", new TTableColumn()
      {
        tc_orgin_name = "gi_Thumb4Data",
        tc_trans_name = "썸네일4"
      });
      columnInfo.Add("gi_OriginSize", new TTableColumn()
      {
        tc_orgin_name = "gi_OriginSize",
        tc_trans_name = "이미지 크기"
      });
      columnInfo.Add("gi_OriginData", new TTableColumn()
      {
        tc_orgin_name = "gi_OriginData",
        tc_trans_name = "이미지"
      });
      columnInfo.Add("gi_InDate", new TTableColumn()
      {
        tc_orgin_name = "gi_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("gi_InUser", new TTableColumn()
      {
        tc_orgin_name = "gi_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("gi_ModDate", new TTableColumn()
      {
        tc_orgin_name = "gi_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("gi_ModUser", new TTableColumn()
      {
        tc_orgin_name = "gi_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.GoodsImage;
      this.gi_GoodsCode = 0L;
      this.gi_SiteID = 0L;
      this.gi_ImgFileName = string.Empty;
      this.gi_ImgType = 0;
      this.gi_ThumbSize = 0;
      this.gi_ThumbData = new byte[0];
      this.gi_Thumb2Size = 0;
      this.gi_Thumb2Data = new byte[0];
      this.gi_Thumb3Size = 0;
      this.gi_Thumb3Data = new byte[0];
      this.gi_Thumb4Size = 0;
      this.gi_Thumb4Data = new byte[0];
      this.gi_OriginSize = 0;
      this.gi_OriginData = new byte[0];
      this.gi_InDate = new DateTime?();
      this.gi_InUser = 0;
      this.gi_ModDate = new DateTime?();
      this.gi_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TGoodsImage();

    public override object Clone()
    {
      TGoodsImage tgoodsImage = base.Clone() as TGoodsImage;
      tgoodsImage.gi_GoodsCode = this.gi_GoodsCode;
      tgoodsImage.gi_SiteID = this.gi_SiteID;
      tgoodsImage.gi_ImgFileName = this.gi_ImgFileName;
      tgoodsImage.gi_ImgType = this.gi_ImgType;
      tgoodsImage.gi_ThumbSize = this.gi_ThumbSize;
      tgoodsImage.gi_ThumbData = this.gi_ThumbData;
      tgoodsImage.gi_Thumb2Size = this.gi_Thumb2Size;
      tgoodsImage.gi_Thumb2Data = this.gi_Thumb2Data;
      tgoodsImage.gi_Thumb3Size = this.gi_Thumb3Size;
      tgoodsImage.gi_Thumb3Data = this.gi_Thumb3Data;
      tgoodsImage.gi_Thumb4Size = this.gi_Thumb4Size;
      tgoodsImage.gi_Thumb4Data = this.gi_Thumb4Data;
      tgoodsImage.gi_OriginSize = this.gi_OriginSize;
      tgoodsImage.gi_OriginData = this.gi_OriginData;
      tgoodsImage.gi_InDate = this.gi_InDate;
      tgoodsImage.gi_ModDate = this.gi_ModDate;
      tgoodsImage.gi_InUser = this.gi_InUser;
      tgoodsImage.gi_ModUser = this.gi_ModUser;
      return (object) tgoodsImage;
    }

    public void PutData(TGoodsImage pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.gi_GoodsCode = pSource.gi_GoodsCode;
      this.gi_SiteID = pSource.gi_SiteID;
      this.gi_ImgFileName = pSource.gi_ImgFileName;
      this.gi_ImgType = pSource.gi_ImgType;
      this.gi_ThumbSize = pSource.gi_ThumbSize;
      this.gi_ThumbData = pSource.gi_ThumbData;
      this.gi_Thumb2Size = pSource.gi_Thumb2Size;
      this.gi_Thumb2Data = pSource.gi_Thumb2Data;
      this.gi_Thumb3Size = pSource.gi_Thumb3Size;
      this.gi_Thumb3Data = pSource.gi_Thumb3Data;
      this.gi_Thumb4Size = pSource.gi_Thumb4Size;
      this.gi_Thumb4Data = pSource.gi_Thumb4Data;
      this.gi_OriginSize = pSource.gi_OriginSize;
      this.gi_OriginData = pSource.gi_OriginData;
      this.gi_InDate = pSource.gi_InDate;
      this.gi_ModDate = pSource.gi_ModDate;
      this.gi_InUser = pSource.gi_InUser;
      this.gi_ModUser = pSource.gi_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.gi_GoodsCode = p_rs.GetFieldLong("gi_GoodsCode");
        if (this.gi_GoodsCode == 0L)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.gi_SiteID = p_rs.GetFieldLong("gi_SiteID");
        this.gi_ImgFileName = p_rs.GetFieldString("gi_ImgFileName");
        this.gi_ImgType = p_rs.GetFieldInt("gi_ImgType");
        this.gi_ThumbSize = p_rs.GetFieldInt("gi_ThumbSize");
        if (p_rs.IsFieldName("gi_ThumbData"))
        {
          if (this.gi_ThumbData != null)
            this.gi_ThumbData = (byte[]) null;
          this.gi_ThumbData = p_rs.GetFieldBytes("gi_ThumbData");
        }
        this.gi_Thumb2Size = p_rs.GetFieldInt("gi_Thumb2Size");
        if (p_rs.IsFieldName("gi_Thumb2Data"))
        {
          if (this.gi_Thumb2Data != null)
            this.gi_Thumb2Data = (byte[]) null;
          this.gi_Thumb2Data = p_rs.GetFieldBytes("gi_Thumb2Data");
        }
        this.gi_Thumb3Size = p_rs.GetFieldInt("gi_Thumb3Size");
        if (p_rs.IsFieldName("gi_Thumb3Data"))
        {
          if (this.gi_Thumb3Data != null)
            this.gi_Thumb3Data = (byte[]) null;
          this.gi_Thumb3Data = p_rs.GetFieldBytes("gi_Thumb3Data");
        }
        this.gi_Thumb4Size = p_rs.GetFieldInt("gi_Thumb4Size");
        if (p_rs.IsFieldName("gi_Thumb4Data"))
        {
          if (this.gi_Thumb4Data != null)
            this.gi_Thumb4Data = (byte[]) null;
          this.gi_Thumb4Data = p_rs.GetFieldBytes("gi_Thumb4Data");
        }
        this.gi_OriginSize = p_rs.GetFieldInt("gi_OriginSize");
        if (p_rs.IsFieldName("gi_OriginData"))
        {
          if (this.gi_OriginData != null)
            this.gi_OriginData = (byte[]) null;
          this.gi_OriginData = p_rs.GetFieldBytes("gi_OriginData");
        }
        this.gi_InDate = p_rs.GetFieldDateTime("gi_InDate");
        this.gi_InUser = p_rs.GetFieldInt("gi_InUser");
        this.gi_ModDate = p_rs.GetFieldDateTime("gi_ModDate");
        this.gi_ModUser = p_rs.GetFieldInt("gi_ModUser");
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
      if (Enum2StrConverter.IsExtensionWebp(this.gi_ImgType))
      {
        this.gi_ThumbData = pByteValue;
        this.gi_Thumb2Data = pByteValue;
        this.gi_Thumb3Data = pByteValue;
        this.gi_Thumb4Data = pByteValue;
      }
      else
      {
        if (!Enum2StrConverter.IsExtensionImage(this.gi_ImgType))
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
            this.gi_ThumbData = (!Enum2StrConverter.IsExtensionPng(this.gi_ImgType) ? thumbnailImage.ToMemoryStream(ImageFormat.Jpeg) : thumbnailImage.ToMemoryStream(ImageFormat.Png)).ToArray();
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
        stringBuilder.Append(string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_IMAGES), (object) this.TableCode) + " gi_OriginData=?,gi_ImgType=?,gi_ImgFileName=?,gi_OriginSize=?");
        if (this.IsThumbData)
          stringBuilder.Append(",gi_ThumbData=?,gi_ThumbSize=?");
        if (this.IsThumb2Data)
          stringBuilder.Append(",gi_Thumb2Data=?,gi_Thumb2Size=?");
        if (this.IsThumb3Data)
          stringBuilder.Append(",gi_Thumb3Data=?,gi_Thumb3Size=?");
        if (this.IsThumb4Data)
          stringBuilder.Append(",gi_Thumb4Data=?,gi_Thumb4Size=?");
        stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "gi_GoodsCode", (object) this.gi_GoodsCode) + string.Format(" AND {0}={1}", (object) "gi_SiteID", (object) this.gi_SiteID));
        using (OleDbCommand command = new OleDbCommand(stringBuilder.ToString(), pOleDB.Connection, pOleDB.Transaction))
        {
          command.Parameters.Add("@gi_OriginData", OleDbType.LongVarBinary, this.gi_OriginData.Length, "gi_OriginData").Value = (object) this.gi_OriginData;
          command.Parameters.Add("@gi_ImgType", OleDbType.Integer).Value = (object) this.gi_ImgType;
          command.Parameters.Add("@gi_ImgFileName", OleDbType.VarChar, Encoding.Default.GetByteCount(this.gi_ImgFileName)).Value = (object) this.gi_ImgFileName;
          command.Parameters.Add("@gi_OriginSize", OleDbType.Integer).Value = (object) this.gi_OriginSize;
          if (this.IsThumbData)
          {
            command.Parameters.Add("@gi_ThumbData", OleDbType.LongVarBinary, this.gi_ThumbData.Length, "gi_ThumbData").Value = (object) this.gi_ThumbData;
            command.Parameters.Add("@gi_ThumbSize", OleDbType.Integer).Value = (object) this.gi_ThumbSize;
          }
          if (this.IsThumb2Data)
          {
            command.Parameters.Add("@gi_Thumb2Data", OleDbType.LongVarBinary, this.gi_Thumb2Data.Length, "gi_Thumb2Data").Value = (object) this.gi_Thumb2Data;
            command.Parameters.Add("@gi_Thumb2Size", OleDbType.Integer).Value = (object) this.gi_Thumb2Size;
          }
          if (this.IsThumb3Data)
          {
            command.Parameters.Add("@gi_Thumb3Data", OleDbType.LongVarBinary, this.gi_Thumb3Data.Length, "gi_Thumb3Data").Value = (object) this.gi_Thumb3Data;
            command.Parameters.Add("@gi_Thumb3Size", OleDbType.Integer).Value = (object) this.gi_Thumb3Size;
          }
          if (this.IsThumb4Data)
          {
            command.Parameters.Add("@gi_Thumb4Data", OleDbType.LongVarBinary, this.gi_Thumb4Data.Length, "gi_Thumb4Data").Value = (object) this.gi_Thumb4Data;
            command.Parameters.Add("@gi_Thumb4Size", OleDbType.Integer).Value = (object) this.gi_Thumb4Size;
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
      TGoodsImage tgoodsImage = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        if (!tgoodsImage.IsOriginData)
          return false;
        db = new UniOleDatabase(tgoodsImage.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, tgoodsImage.OleDB.CommandTimeout);
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_IMAGES), (object) tgoodsImage.TableCode) + " gi_OriginData=?,gi_ImgType=?,gi_ImgFileName=?,gi_OriginSize=?");
        if (tgoodsImage.IsThumbData)
          stringBuilder.Append(",gi_ThumbData=?,gi_ThumbSize=?");
        if (tgoodsImage.IsThumb2Data)
          stringBuilder.Append(",gi_Thumb2Data=?,gi_Thumb2Size=?");
        if (tgoodsImage.IsThumb3Data)
          stringBuilder.Append(",gi_Thumb3Data=?,gi_Thumb3Size=?");
        if (tgoodsImage.IsThumb4Data)
          stringBuilder.Append(",gi_Thumb4Data=?,gi_Thumb4Size=?");
        stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "gi_GoodsCode", (object) tgoodsImage.gi_GoodsCode) + string.Format(" AND {0}={1}", (object) "gi_SiteID", (object) tgoodsImage.gi_SiteID));
        using (OleDbCommand command = new OleDbCommand(stringBuilder.ToString(), db.Connection, db.Transaction))
        {
          command.Parameters.Add("@gi_OriginData", OleDbType.LongVarBinary, tgoodsImage.gi_OriginData.Length, "gi_OriginData").Value = (object) tgoodsImage.gi_OriginData;
          command.Parameters.Add("@gi_ImgType", OleDbType.Integer).Value = (object) tgoodsImage.gi_ImgType;
          command.Parameters.Add("@gi_ImgFileName", OleDbType.VarChar, Encoding.Default.GetByteCount(tgoodsImage.gi_ImgFileName)).Value = (object) tgoodsImage.gi_ImgFileName;
          command.Parameters.Add("@gi_OriginSize", OleDbType.Integer).Value = (object) tgoodsImage.gi_OriginSize;
          if (tgoodsImage.IsThumbData)
          {
            command.Parameters.Add("@gi_ThumbData", OleDbType.LongVarBinary, tgoodsImage.gi_ThumbData.Length, "gi_ThumbData").Value = (object) tgoodsImage.gi_ThumbData;
            command.Parameters.Add("@gi_ThumbSize", OleDbType.Integer).Value = (object) tgoodsImage.gi_ThumbSize;
          }
          if (tgoodsImage.IsThumb2Data)
          {
            command.Parameters.Add("@gi_Thumb2Data", OleDbType.LongVarBinary, tgoodsImage.gi_Thumb2Data.Length, "gi_Thumb2Data").Value = (object) tgoodsImage.gi_Thumb2Data;
            command.Parameters.Add("@gi_Thumb2Size", OleDbType.Integer).Value = (object) tgoodsImage.gi_Thumb2Size;
          }
          if (tgoodsImage.IsThumb3Data)
          {
            command.Parameters.Add("@gi_Thumb3Data", OleDbType.LongVarBinary, tgoodsImage.gi_Thumb3Data.Length, "gi_Thumb3Data").Value = (object) tgoodsImage.gi_Thumb3Data;
            command.Parameters.Add("@gi_Thumb3Size", OleDbType.Integer).Value = (object) tgoodsImage.gi_Thumb3Size;
          }
          if (tgoodsImage.IsThumb4Data)
          {
            command.Parameters.Add("@gi_Thumb4Data", OleDbType.LongVarBinary, tgoodsImage.gi_Thumb4Data.Length, "gi_Thumb4Data").Value = (object) tgoodsImage.gi_Thumb4Data;
            command.Parameters.Add("@gi_Thumb4Size", OleDbType.Integer).Value = (object) tgoodsImage.gi_Thumb4Size;
          }
          command.CommandTimeout = 0;
          if (!await rs.UpdateAsync(command))
            throw new Exception("이미지 파일 저장 실패 -Update()\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tgoodsImage.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : 이미지 파일 저장 실패 \n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + "     " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
        }
        return true;
      }
      catch (Exception ex)
      {
        Log.Logger.ErrorColor("\n--------------------------------------------------------------------------------------------------\n" + ex.Message + "\n--------------------------------------------------------------------------------------------------");
        return tgoodsImage.SetErrorInfo(0L, ex.Message);
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public override string InsertQuery()
    {
      if (!this.gi_InDate.HasValue)
        this.gi_InDate = new DateTime?(DateTime.Now);
      return string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_IMAGES), (object) this.TableCode) + " gi_GoodsCode,gi_SiteID,gi_InDate,gi_InUser,gi_ModDate,gi_ModUser) VALUES ( " + string.Format(" {0}", (object) this.gi_GoodsCode) + string.Format(",{0}", (object) this.gi_SiteID) + string.Format(",{0},{1},{2},{3}", (object) this.gi_InDate.GetDateToStrInNull(), (object) this.gi_InUser, (object) this.gi_ModDate.GetDateToStrInNull(), (object) this.gi_ModUser) + ")";
    }

    public override bool Insert()
    {
      this.InsertChecked();
      string pStrExec = this.InsertQuery();
      if (this.OleDB.Execute(pStrExec))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 등록 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 코드 : ({0},{1})\n", (object) this.gi_GoodsCode, (object) this.gi_SiteID) + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n 쿼리 : " + pStrExec + "\n--------------------------------------------------------------------------------------------------\n";
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TGoodsImage tgoodsImage = this;
      // ISSUE: reference to a compiler-generated method
      tgoodsImage.\u003C\u003En__0();
      if (await tgoodsImage.OleDB.ExecuteAsync(tgoodsImage.InsertQuery()))
        return true;
      tgoodsImage.message = " " + tgoodsImage.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tgoodsImage.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tgoodsImage.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tgoodsImage.gi_GoodsCode, (object) tgoodsImage.gi_SiteID) + " 내용 : " + tgoodsImage.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tgoodsImage.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_IMAGES), (object) this.TableCode) + string.Format(" {0}={1},{2}={3}", (object) "gi_ModDate", (object) this.gi_ModDate.GetDateToStrInNull(), (object) "gi_ModUser", (object) this.gi_ModUser) + string.Format(" WHERE {0}={1}", (object) "gi_GoodsCode", (object) this.gi_GoodsCode) + string.Format(" AND {0}={1}", (object) "gi_SiteID", (object) this.gi_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.gi_GoodsCode, (object) this.gi_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TGoodsImage tgoodsImage = this;
      // ISSUE: reference to a compiler-generated method
      tgoodsImage.\u003C\u003En__1();
      if (await tgoodsImage.OleDB.ExecuteAsync(tgoodsImage.UpdateQuery()))
        return true;
      tgoodsImage.message = " " + tgoodsImage.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tgoodsImage.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tgoodsImage.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tgoodsImage.gi_GoodsCode, (object) tgoodsImage.gi_SiteID) + " 내용 : " + tgoodsImage.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tgoodsImage.message);
      return false;
    }

    public override string DeleteQuery() => string.Format(" DELETE FROM {0}{1}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_IMAGES), (object) this.TableCode) + string.Format(" WHERE {0}={1}", (object) "gi_GoodsCode", (object) this.gi_GoodsCode) + string.Format(" AND {0}={1}", (object) "gi_SiteID", (object) this.gi_SiteID);

    public override bool Delete()
    {
      this.InsertChecked();
      string pStrExec = this.DeleteQuery();
      if (this.OleDB.Execute(pStrExec))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 삭제 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 코드 : ({0},{1})\n", (object) this.gi_GoodsCode, (object) this.gi_SiteID) + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n 쿼리 : " + pStrExec + "\n--------------------------------------------------------------------------------------------------\n";
      return false;
    }

    public override async Task<bool> DeleteAsync()
    {
      TGoodsImage tgoodsImage = this;
      // ISSUE: reference to a compiler-generated method
      tgoodsImage.\u003C\u003En__0();
      if (await tgoodsImage.OleDB.ExecuteAsync(tgoodsImage.DeleteQuery()))
        return true;
      tgoodsImage.message = " " + tgoodsImage.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tgoodsImage.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tgoodsImage.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) tgoodsImage.gi_GoodsCode, (object) tgoodsImage.gi_SiteID) + " 내용 : " + tgoodsImage.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tgoodsImage.message);
      return false;
    }

    public virtual string DeleteQuery(long p_gi_GoodsCode, long p_gi_SiteID = 0)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format(" DELETE FROM {0}{1} ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_IMAGES), (object) this.TableCode));
      stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "gi_GoodsCode", (object) p_gi_GoodsCode));
      if (p_gi_SiteID > 0L)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gi_SiteID", (object) p_gi_SiteID));
      return stringBuilder.ToString();
    }

    public virtual bool SelectThis(
      UniOleDbRecordset p_rs,
      long p_gi_GoodsCode,
      long p_gi_SiteID = 0,
      bool p_is_thumb_data = true,
      bool p_is_file_data = false)
    {
      try
      {
        Hashtable p_param = new Hashtable()
        {
          {
            (object) "gi_GoodsCode",
            (object) p_gi_GoodsCode
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
        if (p_gi_SiteID > 0L)
          p_param.Add((object) "gi_SiteID", (object) p_gi_SiteID);
        string selectQuery = this.GetSelectQuery((object) p_param);
        if (!p_rs.Open(selectQuery))
          throw new Exception("검색 오류 - SQL SELECT 실패");
        if (!p_rs.IsDataRead())
          throw new Exception("검색 오류 - COUNT = 0");
        if (!this.GetFieldValues(p_rs))
          throw new Exception("검색 오류 - GetFieldValues 실패");
        return this.SetSuccessInfo(string.Format("{0}({1},{2}) 검색됨", (object) this.gi_ImgFileName, (object) this.gi_GoodsCode, (object) this.gi_SiteID));
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " SelectThis 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 코드 : ({0},{1})\n", (object) p_gi_GoodsCode, (object) p_gi_SiteID) + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
      }
      return false;
    }

    public virtual async Task<IList<TGoodsImage>> SelectTListAsync(object p_param)
    {
      TGoodsImage tgoodsImage1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(tgoodsImage1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, tgoodsImage1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(tgoodsImage1.GetSelectQuery(p_param)))
        {
          tgoodsImage1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tgoodsImage1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tgoodsImage1.OleDB.LastErrorID) + " 내용 : " + tgoodsImage1.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<TGoodsImage>) null;
        }
        IList<TGoodsImage> lt_list = (IList<TGoodsImage>) new List<TGoodsImage>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            TGoodsImage tgoodsImage2 = tgoodsImage1.OleDB.Create<TGoodsImage>();
            if (tgoodsImage2.GetFieldValues(rs))
            {
              tgoodsImage2.row_number = lt_list.Count + 1;
              lt_list.Add(tgoodsImage2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tgoodsImage1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
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
        if (hashtable.ContainsKey((object) "gi_SiteID") && Convert.ToInt64(hashtable[(object) "gi_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "gi_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "gi_GoodsCode") && Convert.ToInt64(hashtable[(object) "gi_GoodsCode"].ToString()) > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gi_GoodsCode", hashtable[(object) "gi_GoodsCode"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gi_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "gi_ImgFileName") && hashtable[(object) "gi_ImgFileName"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "gi_ImgFileName", hashtable[(object) "gi_ImgFileName"]));
        if (hashtable.ContainsKey((object) "gi_ImgType") && Convert.ToInt32(hashtable[(object) "gi_ImgType"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "gi_ImgType", hashtable[(object) "gi_ImgType"]));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "gi_ImgFileName", hashtable[(object) "_KEY_WORD_"]));
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
        string uniImages = UbModelBase.UNI_IMAGES;
        string str = this.TableCode.ToString();
        bool flag1 = false;
        bool flag2 = false;
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniImages = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            str = hashtable[(object) "table"].ToString();
          if (hashtable.ContainsKey((object) "IS_THUMB_IMAGE_VIEW") && Convert.ToBoolean(hashtable[(object) "IS_THUMB_IMAGE_VIEW"].ToString()))
            flag1 = Convert.ToBoolean(hashtable[(object) "IS_THUMB_IMAGE_VIEW"].ToString());
          if (hashtable.ContainsKey((object) "IS_FILE_IMAGE_VIEW") && Convert.ToBoolean(hashtable[(object) "IS_FILE_IMAGE_VIEW"].ToString()))
            flag2 = Convert.ToBoolean(hashtable[(object) "IS_FILE_IMAGE_VIEW"].ToString());
        }
        stringBuilder.Append(" SELECT  gi_GoodsCode,gi_SiteID,gi_ImgType,gi_ImgFileName,gi_ThumbSize,gi_Thumb2Size,gi_Thumb3Size,gi_Thumb4Size,gi_OriginSize,gi_InDate,gi_InUser,gi_ModDate,gi_ModUser");
        if (flag1)
          stringBuilder.Append(",gi_ThumbData");
        if (flag2)
          stringBuilder.Append(",gi_OriginData");
        stringBuilder.Append(" FROM " + DbQueryHelper.ToDBNameBridge(uniImages) + str + " " + DbQueryHelper.ToWithNolock());
        if (p_param is Hashtable)
          stringBuilder.Append(this.GetSelectWhereAnd(p_param));
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) ex.GetHashCode()) + " 내용 : " + ex.Message + "\n" + string.Format(" Query : {0}\n", (object) stringBuilder) + "--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
        stringBuilder.Clear();
      }
      return stringBuilder.ToString();
    }
  }
}
