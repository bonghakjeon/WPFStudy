// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Supplier.SupplierImage.TSupplierImage
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

namespace UniBiz.Bo.Models.UniBase.Supplier.SupplierImage
{
  public class TSupplierImage : UbModelBase<TSupplierImage>
  {
    private int _sui_ID;
    private long _sui_SiteID;
    private int _sui_Supplier;
    private int _sui_Kind;
    private int _sui_ImgType;
    private string _sui_ImgFileName;
    private int _sui_ThumbSize;
    protected byte[] _sui_ThumbData = new byte[0];
    private int _sui_OriginSize;
    protected byte[] _sui_OriginData = new byte[0];
    private DateTime? _sui_InDate;
    private int _sui_InUser;
    private DateTime? _sui_ModDate;
    private int _sui_ModUser;

    public override object _Key => (object) new object[1]
    {
      (object) this.sui_ID
    };

    public int sui_ID
    {
      get => this._sui_ID;
      set
      {
        this._sui_ID = value;
        this.Changed(nameof (sui_ID));
      }
    }

    public long sui_SiteID
    {
      get => this._sui_SiteID;
      set
      {
        this._sui_SiteID = value;
        this.Changed(nameof (sui_SiteID));
      }
    }

    public int sui_Supplier
    {
      get => this._sui_Supplier;
      set
      {
        this._sui_Supplier = value;
        this.Changed(nameof (sui_Supplier));
      }
    }

    public int sui_Kind
    {
      get => this._sui_Kind;
      set
      {
        this._sui_Kind = value;
        this.Changed(nameof (sui_Kind));
        this.Changed("sui_KindDesc");
      }
    }

    public string sui_KindDesc => this.sui_Kind <= 0 ? string.Empty : Enum2StrConverter.ToCommonCodeTypeMemo(this.sui_SiteID, EnumCommonCodeType.SupplierImageKind, this.sui_Kind);

    public int sui_ImgType
    {
      get => this._sui_ImgType;
      set
      {
        this._sui_ImgType = value;
        this.Changed(nameof (sui_ImgType));
      }
    }

    public string sui_ImgFileName
    {
      get => this._sui_ImgFileName;
      set
      {
        this._sui_ImgFileName = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (sui_ImgFileName));
        this.sui_ImgType = (int) Enum2StrConverter.GetFileExtensionType(Path.GetExtension(this._sui_ImgFileName));
      }
    }

    public int sui_ThumbSize
    {
      get => this._sui_ThumbSize;
      set
      {
        this._sui_ThumbSize = value;
        this.Changed(nameof (sui_ThumbSize));
      }
    }

    public byte[] sui_ThumbData
    {
      get => this._sui_ThumbData;
      set
      {
        this._sui_ThumbData = value;
        if (this._sui_ThumbData != null)
          this.sui_ThumbSize = this._sui_ThumbData.Length;
        this.Changed(nameof (sui_ThumbData));
        this.Changed("IsThumbData");
        this.Changed("Base64Data");
        this.Changed("Base64DataSize");
      }
    }

    [JsonIgnore]
    public bool IsThumbData => this.sui_ThumbData != null && this.sui_ThumbData.Length != 0;

    public int sui_OriginSize
    {
      get => this._sui_OriginSize;
      set
      {
        this._sui_OriginSize = value;
        this.Changed(nameof (sui_OriginSize));
      }
    }

    public byte[] sui_OriginData
    {
      get => this._sui_OriginData;
      set
      {
        this._sui_OriginData = value;
        if (this._sui_OriginData != null)
          this.sui_OriginSize = this._sui_OriginData.Length;
        this.Changed(nameof (sui_OriginData));
        this.Changed("IsOriginData");
        this.Changed("Base64Data");
        this.Changed("Base64DataSize");
      }
    }

    [JsonIgnore]
    public bool IsOriginData => this.sui_OriginData != null && this.sui_OriginData.Length != 0;

    public string Base64Data
    {
      get
      {
        string fileExtensionName = Enum2StrConverter.ToImageFileExtensionName(this.sui_ImgType);
        if (this.IsOriginData)
          return "data:image/" + fileExtensionName + ";base64," + this.sui_OriginData.ToBase64();
        return this.IsThumbData ? "data:image/" + fileExtensionName + ";base64," + this.sui_ThumbData.ToBase64() : (string) null;
      }
    }

    public int Base64DataSize
    {
      get
      {
        if (this.IsOriginData)
          return this.sui_OriginData.Length;
        return !this.IsThumbData ? 0 : this.sui_ThumbData.Length;
      }
    }

    public DateTime? sui_InDate
    {
      get => this._sui_InDate;
      set
      {
        this._sui_InDate = value;
        this.Changed(nameof (sui_InDate));
      }
    }

    public int sui_InUser
    {
      get => this._sui_InUser;
      set
      {
        this._sui_InUser = value;
        this.Changed(nameof (sui_InUser));
      }
    }

    public DateTime? sui_ModDate
    {
      get => this._sui_ModDate;
      set
      {
        this._sui_ModDate = value;
        this.Changed(nameof (sui_ModDate));
      }
    }

    public int sui_ModUser
    {
      get => this._sui_ModUser;
      set
      {
        this._sui_ModUser = value;
        this.Changed(nameof (sui_ModUser));
      }
    }

    public TSupplierImage() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("sui_ID", new TTableColumn()
      {
        tc_orgin_name = "sui_ID",
        tc_trans_name = "업체 이미지"
      });
      columnInfo.Add("sui_SiteID", new TTableColumn()
      {
        tc_orgin_name = "sui_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("sui_Supplier", new TTableColumn()
      {
        tc_orgin_name = "sui_Supplier",
        tc_trans_name = "코드"
      });
      columnInfo.Add("sui_Kind", new TTableColumn()
      {
        tc_orgin_name = "sui_Supplier",
        tc_trans_name = "코드",
        tc_comm_code = 103
      });
      columnInfo.Add("sui_ImgType", new TTableColumn()
      {
        tc_orgin_name = "sui_ImgType",
        tc_trans_name = "파일 타입"
      });
      columnInfo.Add("sui_ImgFileName", new TTableColumn()
      {
        tc_orgin_name = "sui_ImgFileName",
        tc_trans_name = "파일명"
      });
      columnInfo.Add("sui_ThumbSize", new TTableColumn()
      {
        tc_orgin_name = "sui_ThumbSize",
        tc_trans_name = "썸네일 사이즈"
      });
      columnInfo.Add("sui_ThumbData", new TTableColumn()
      {
        tc_orgin_name = "sui_ThumbData",
        tc_trans_name = "썸네일"
      });
      columnInfo.Add("sui_OriginSize", new TTableColumn()
      {
        tc_orgin_name = "sui_OriginSize",
        tc_trans_name = "원본 사이즈"
      });
      columnInfo.Add("sui_OriginData", new TTableColumn()
      {
        tc_orgin_name = "sui_OriginData",
        tc_trans_name = "원본"
      });
      columnInfo.Add("sui_InDate", new TTableColumn()
      {
        tc_orgin_name = "sui_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("sui_InUser", new TTableColumn()
      {
        tc_orgin_name = "sui_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("sui_ModDate", new TTableColumn()
      {
        tc_orgin_name = "sui_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("sui_ModUser", new TTableColumn()
      {
        tc_orgin_name = "sui_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.SupplierImage;
      this.sui_ID = 0;
      this.sui_SiteID = 0L;
      this.sui_Supplier = 0;
      this.sui_Kind = 0;
      this.sui_ImgType = 0;
      this.sui_ImgFileName = string.Empty;
      this.sui_ThumbSize = 0;
      this.sui_ThumbData = new byte[0];
      this.sui_OriginSize = 0;
      this.sui_OriginData = new byte[0];
      this.sui_InDate = new DateTime?();
      this.sui_InUser = 0;
      this.sui_ModDate = new DateTime?();
      this.sui_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TSupplierImage();

    public override object Clone()
    {
      TSupplierImage tsupplierImage = base.Clone() as TSupplierImage;
      tsupplierImage.sui_ID = this.sui_ID;
      tsupplierImage.sui_SiteID = this.sui_SiteID;
      tsupplierImage.sui_Supplier = this.sui_Supplier;
      tsupplierImage.sui_Kind = this.sui_Kind;
      tsupplierImage.sui_ImgType = this.sui_ImgType;
      tsupplierImage.sui_ImgFileName = this.sui_ImgFileName;
      tsupplierImage.sui_ThumbSize = this.sui_ThumbSize;
      tsupplierImage.sui_ThumbData = this.sui_ThumbData;
      tsupplierImage.sui_OriginSize = this.sui_OriginSize;
      tsupplierImage.sui_OriginData = this.sui_OriginData;
      tsupplierImage.sui_InDate = this.sui_InDate;
      tsupplierImage.sui_ModDate = this.sui_ModDate;
      tsupplierImage.sui_InUser = this.sui_InUser;
      tsupplierImage.sui_ModUser = this.sui_ModUser;
      return (object) tsupplierImage;
    }

    public void PutData(TSupplierImage pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.sui_ID = pSource.sui_ID;
      this.sui_SiteID = pSource.sui_SiteID;
      this.sui_Supplier = pSource.sui_Supplier;
      this.sui_Kind = pSource.sui_Kind;
      this.sui_ImgType = pSource.sui_ImgType;
      this.sui_ImgFileName = pSource.sui_ImgFileName;
      this.sui_ThumbSize = pSource.sui_ThumbSize;
      this.sui_ThumbData = pSource.sui_ThumbData;
      this.sui_OriginSize = pSource.sui_OriginSize;
      this.sui_OriginData = pSource.sui_OriginData;
      this.sui_InDate = pSource.sui_InDate;
      this.sui_ModDate = pSource.sui_ModDate;
      this.sui_InUser = pSource.sui_InUser;
      this.sui_ModUser = pSource.sui_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.sui_ID = p_rs.GetFieldInt("sui_ID");
        if (this.sui_ID == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.sui_SiteID = p_rs.GetFieldLong("sui_SiteID");
        this.sui_Supplier = p_rs.GetFieldInt("sui_Supplier");
        this.sui_Kind = p_rs.GetFieldInt("sui_Kind");
        this.sui_ImgType = p_rs.GetFieldInt("sui_ImgType");
        this.sui_ImgFileName = p_rs.GetFieldString("sui_ImgFileName");
        this.sui_ThumbSize = p_rs.GetFieldInt("sui_ThumbSize");
        if (p_rs.IsFieldName("sui_ThumbData"))
        {
          if (this.sui_ThumbData != null)
            this.sui_ThumbData = (byte[]) null;
          this.sui_ThumbData = p_rs.GetFieldBytes("sui_ThumbData");
        }
        this.sui_OriginSize = p_rs.GetFieldInt("sui_OriginSize");
        if (p_rs.IsFieldName("sui_OriginData"))
        {
          if (this.sui_OriginData != null)
            this.sui_OriginData = (byte[]) null;
          this.sui_OriginData = p_rs.GetFieldBytes("sui_OriginData");
        }
        this.sui_InDate = p_rs.GetFieldDateTime("sui_InDate");
        this.sui_InUser = p_rs.GetFieldInt("sui_InUser");
        this.sui_ModDate = p_rs.GetFieldDateTime("sui_ModDate");
        this.sui_ModUser = p_rs.GetFieldInt("sui_ModUser");
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
      if (Enum2StrConverter.IsExtensionWebp(this.sui_ImgType))
      {
        this.sui_ThumbData = pByteValue;
      }
      else
      {
        if (!Enum2StrConverter.IsExtensionImage(this.sui_ImgType))
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
            this.sui_ThumbData = (!Enum2StrConverter.IsExtensionPng(this.sui_ImgType) ? thumbnailImage.ToMemoryStream(ImageFormat.Jpeg) : thumbnailImage.ToMemoryStream(ImageFormat.Png)).ToArray();
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
        stringBuilder.Append(string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " sui_OriginData=?,sui_ImgType=?,sui_ImgFileName=?,sui_OriginSize=?");
        if (this.IsThumbData)
          stringBuilder.Append(",sui_ThumbData=?,sui_ThumbSize=?");
        stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "sui_ID", (object) this.sui_ID));
        using (OleDbCommand command = new OleDbCommand(stringBuilder.ToString(), pOleDB.Connection, pOleDB.Transaction))
        {
          command.Parameters.Add("@sui_OriginData", OleDbType.LongVarBinary, this.sui_OriginData.Length, "sui_OriginData").Value = (object) this.sui_OriginData;
          command.Parameters.Add("@sui_ImgType", OleDbType.Integer).Value = (object) this.sui_ImgType;
          command.Parameters.Add("@sui_ImgFileName", OleDbType.VarChar, Encoding.Default.GetByteCount(this.sui_ImgFileName)).Value = (object) this.sui_ImgFileName;
          command.Parameters.Add("@sui_OriginSize", OleDbType.Integer).Value = (object) this.sui_OriginSize;
          if (this.IsThumbData)
          {
            command.Parameters.Add("@sui_ThumbData", OleDbType.LongVarBinary, this.sui_ThumbData.Length, "sui_ThumbData").Value = (object) this.sui_ThumbData;
            command.Parameters.Add("@sui_ThumbSize", OleDbType.Integer).Value = (object) this.sui_ThumbSize;
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
      TSupplierImage tsupplierImage = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        if (!tsupplierImage.IsOriginData)
          return false;
        db = new UniOleDatabase(tsupplierImage.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, tsupplierImage.OleDB.CommandTimeout);
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) tsupplierImage.TableCode) + " sui_OriginData=?,sui_ImgType=?,sui_ImgFileName=?,sui_OriginSize=?");
        if (tsupplierImage.IsThumbData)
          stringBuilder.Append(",sui_ThumbData=?,sui_ThumbSize=?");
        stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "sui_ID", (object) tsupplierImage.sui_ID));
        using (OleDbCommand command = new OleDbCommand(stringBuilder.ToString(), db.Connection, db.Transaction))
        {
          command.Parameters.Add("@sui_OriginData", OleDbType.LongVarBinary, tsupplierImage.sui_OriginData.Length).Value = (object) tsupplierImage.sui_OriginData;
          command.Parameters.Add("@sui_ImgType", OleDbType.Integer).Value = (object) tsupplierImage.sui_ImgType;
          command.Parameters.Add("@sui_ImgFileName", OleDbType.VarChar, Encoding.Default.GetByteCount(tsupplierImage.sui_ImgFileName)).Value = (object) tsupplierImage.sui_ImgFileName;
          command.Parameters.Add("@sui_OriginSize", OleDbType.Integer).Value = (object) tsupplierImage.sui_OriginSize;
          if (tsupplierImage.IsThumbData)
          {
            command.Parameters.Add("@sui_ThumbData", OleDbType.LongVarBinary, tsupplierImage.sui_ThumbData.Length).Value = (object) tsupplierImage.sui_ThumbData;
            command.Parameters.Add("@sui_ThumbSize", OleDbType.Integer).Value = (object) tsupplierImage.sui_ThumbSize;
          }
          command.CommandTimeout = 0;
          if (!await rs.UpdateAsync(command))
            throw new Exception("이미지 파일 저장 실패 -Update()\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tsupplierImage.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : 이미지 파일 저장 실패 \n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + "     " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
        }
        return true;
      }
      catch (Exception ex)
      {
        Log.Logger.ErrorColor("\n--------------------------------------------------------------------------------------------------\n" + ex.Message + "\n--------------------------------------------------------------------------------------------------");
        return tsupplierImage.SetErrorInfo(0L, ex.Message);
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public override string InsertQuery()
    {
      if (!this.sui_InDate.HasValue)
        this.sui_InDate = new DateTime?(DateTime.Now);
      return string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " sui_ID,sui_SiteID,sui_Supplier,sui_Kind,sui_InDate,sui_InUser,sui_ModDate,sui_ModUser) VALUES ( " + string.Format(" {0}", (object) this.sui_ID) + string.Format(",{0}", (object) this.sui_SiteID) + string.Format(",{0},{1}", (object) this.sui_Supplier, (object) this.sui_Kind) + string.Format(",{0},{1},{2},{3}", (object) this.sui_InDate.GetDateToStrInNull(), (object) this.sui_InUser, (object) this.sui_ModDate.GetDateToStrInNull(), (object) this.sui_ModUser) + ")";
    }

    public override bool Insert()
    {
      this.InsertChecked();
      string pStrExec = this.InsertQuery();
      if (this.OleDB.Execute(pStrExec))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 등록 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.sui_ID, (object) this.sui_SiteID, (object) this.sui_Supplier, (object) this.sui_Kind) + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n 쿼리 : " + pStrExec + "\n--------------------------------------------------------------------------------------------------\n";
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TSupplierImage tsupplierImage = this;
      // ISSUE: reference to a compiler-generated method
      tsupplierImage.\u003C\u003En__0();
      if (await tsupplierImage.OleDB.ExecuteAsync(tsupplierImage.InsertQuery()))
        return true;
      tsupplierImage.message = " " + tsupplierImage.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tsupplierImage.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tsupplierImage.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tsupplierImage.sui_ID, (object) tsupplierImage.sui_SiteID, (object) tsupplierImage.sui_Supplier, (object) tsupplierImage.sui_Kind) + " 내용 : " + tsupplierImage.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tsupplierImage.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + string.Format(" {0}={1}", (object) "sui_Kind", (object) this.sui_Kind) + string.Format(",{0}={1},{2}={3}", (object) "sui_ModDate", (object) this.sui_ModDate.GetDateToStrInNull(), (object) "sui_ModUser", (object) this.sui_ModUser) + string.Format(" WHERE {0}={1}", (object) "sui_ID", (object) this.sui_ID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.sui_ID, (object) this.sui_SiteID, (object) this.sui_Supplier, (object) this.sui_Kind) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TSupplierImage tsupplierImage = this;
      // ISSUE: reference to a compiler-generated method
      tsupplierImage.\u003C\u003En__1();
      if (await tsupplierImage.OleDB.ExecuteAsync(tsupplierImage.UpdateQuery()))
        return true;
      tsupplierImage.message = " " + tsupplierImage.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tsupplierImage.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tsupplierImage.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tsupplierImage.sui_ID, (object) tsupplierImage.sui_SiteID, (object) tsupplierImage.sui_Supplier, (object) tsupplierImage.sui_Kind) + " 내용 : " + tsupplierImage.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tsupplierImage.message);
      return false;
    }

    public override string DeleteQuery() => string.Format(" DELETE FROM {0}{1}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + string.Format(" WHERE {0}={1}", (object) "sui_ID", (object) this.sui_ID);

    public override bool Delete()
    {
      this.InsertChecked();
      string pStrExec = this.DeleteQuery();
      if (this.OleDB.Execute(pStrExec))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 삭제 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) this.sui_ID, (object) this.sui_SiteID, (object) this.sui_Supplier, (object) this.sui_Kind) + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n 쿼리 : " + pStrExec + "\n--------------------------------------------------------------------------------------------------\n";
      return false;
    }

    public override async Task<bool> DeleteAsync()
    {
      TSupplierImage tsupplierImage = this;
      // ISSUE: reference to a compiler-generated method
      tsupplierImage.\u003C\u003En__0();
      if (await tsupplierImage.OleDB.ExecuteAsync(tsupplierImage.DeleteQuery()))
        return true;
      tsupplierImage.message = " " + tsupplierImage.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tsupplierImage.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tsupplierImage.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},{2},{3})\n", (object) tsupplierImage.sui_ID, (object) tsupplierImage.sui_SiteID, (object) tsupplierImage.sui_Supplier, (object) tsupplierImage.sui_Kind) + " 내용 : " + tsupplierImage.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tsupplierImage.message);
      return false;
    }

    public virtual string DeleteQuery(int p_sui_ID, long p_sui_SiteID = 0)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format(" DELETE FROM {0}{1} ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode));
      stringBuilder.Append(string.Format(" WHERE {0}={1}", (object) "sui_ID", (object) p_sui_ID));
      if (p_sui_SiteID > 0L)
        stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sui_SiteID", (object) p_sui_SiteID));
      return stringBuilder.ToString();
    }

    public virtual bool SelectThis(
      UniOleDbRecordset p_rs,
      int p_sui_ID,
      long p_sui_SiteID = 0,
      bool p_is_thumb_data = true,
      bool p_is_file_data = false)
    {
      try
      {
        Hashtable p_param = new Hashtable()
        {
          {
            (object) "sui_ID",
            (object) p_sui_ID
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
        if (p_sui_SiteID > 0L)
          p_param.Add((object) "sui_SiteID", (object) p_sui_SiteID);
        string selectQuery = this.GetSelectQuery((object) p_param);
        if (!p_rs.Open(selectQuery))
          throw new Exception("검색 오류 - SQL SELECT 실패");
        if (!p_rs.IsDataRead())
          throw new Exception("검색 오류 - COUNT = 0");
        if (!this.GetFieldValues(p_rs))
          throw new Exception("검색 오류 - GetFieldValues 실패");
        return this.SetSuccessInfo(string.Format("{0}({1},{2},{3},{4}) 검색됨", (object) this.sui_ImgFileName, (object) this.sui_ID, (object) this.sui_SiteID, (object) this.sui_Supplier, (object) this.sui_Kind));
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " SelectThis 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 코드 : ({0},{1})\n", (object) p_sui_ID, (object) p_sui_SiteID) + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
      }
      return false;
    }

    public virtual async Task<IList<TSupplierImage>> SelectTListAsync(object p_param)
    {
      TSupplierImage tsupplierImage1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(tsupplierImage1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, tsupplierImage1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(tsupplierImage1.GetSelectQuery(p_param)))
        {
          tsupplierImage1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tsupplierImage1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tsupplierImage1.OleDB.LastErrorID) + " 내용 : " + tsupplierImage1.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<TSupplierImage>) null;
        }
        IList<TSupplierImage> lt_list = (IList<TSupplierImage>) new List<TSupplierImage>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            TSupplierImage tsupplierImage2 = tsupplierImage1.OleDB.Create<TSupplierImage>();
            if (tsupplierImage2.GetFieldValues(rs))
            {
              tsupplierImage2.row_number = lt_list.Count + 1;
              lt_list.Add(tsupplierImage2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tsupplierImage1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
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
        if (hashtable.ContainsKey((object) "sui_SiteID") && Convert.ToInt64(hashtable[(object) "sui_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "sui_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "sui_ID") && Convert.ToInt32(hashtable[(object) "sui_ID"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sui_ID", hashtable[(object) "sui_ID"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sui_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "sui_ID") && Convert.ToInt32(hashtable[(object) "sui_ID"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sui_ID", hashtable[(object) "sui_ID"]));
        if (hashtable.ContainsKey((object) "sui_Supplier") && Convert.ToInt32(hashtable[(object) "sui_Supplier"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sui_Supplier", hashtable[(object) "sui_Supplier"]));
        if (hashtable.ContainsKey((object) "sui_Kind") && Convert.ToInt32(hashtable[(object) "sui_Kind"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sui_Kind", hashtable[(object) "sui_Kind"]));
        if (hashtable.ContainsKey((object) "sui_ImgFileName") && hashtable[(object) "sui_ImgFileName"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "sui_ImgFileName", hashtable[(object) "sui_ImgFileName"]));
        if (hashtable.ContainsKey((object) "sui_ImgType") && Convert.ToInt32(hashtable[(object) "sui_ImgType"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "sui_ImgType", hashtable[(object) "sui_ImgType"]));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "sui_ImgFileName", hashtable[(object) "_KEY_WORD_"]));
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
        stringBuilder.Append(" SELECT  sui_ID,sui_SiteID,sui_Supplier,sui_Kind,sui_ImgType,sui_ImgFileName,sui_ThumbSize,sui_OriginSize,sui_InDate,sui_InUser,sui_ModDate,sui_ModUser");
        if (flag1)
          stringBuilder.Append(",sui_ThumbData");
        if (flag2)
          stringBuilder.Append(",sui_OriginData");
        stringBuilder.Append(" FROM " + DbQueryHelper.ToDBNameBridge(uniBase) + str + " " + DbQueryHelper.ToWithNolock());
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
