// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.OuterConnAuth.TOuterConnAuth
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
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.TableInfo;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniBase.OuterConnAuth
{
  public class TOuterConnAuth : UbModelBase<TOuterConnAuth>
  {
    private int _oca_ID;
    private long _oca_SiteID;
    private int _oca_ProgKind;
    private string _oca_ProgVer;
    private int _oca_StoreCode;
    private string _oca_DeviceName;
    private string _oca_DeviceKey;
    private string _oca_DeviceIpInfo;
    private string _oca_RealIp4;
    private string _oca_Gateway;
    private int _oca_DevicePort;
    private string _oca_BaseUrl;
    private int _oca_Count;
    private int _oca_Status;
    private DateTime? _oca_ExpireDate;
    private string _oca_Memo;
    private int _oca_OsType;
    private string _oca_OsVersion;
    private int _oca_AddProperty;
    private DateTime? _oca_InDate;
    private int _oca_InUser;
    private DateTime? _oca_ModDate;
    private int _oca_ModUser;

    public override object _Key => (object) new object[1]
    {
      (object) this.oca_ID
    };

    public int oca_ID
    {
      get => this._oca_ID;
      set
      {
        this._oca_ID = value;
        this.Changed(nameof (oca_ID));
      }
    }

    public long oca_SiteID
    {
      get => this._oca_SiteID;
      set
      {
        this._oca_SiteID = value;
        this.Changed(nameof (oca_SiteID));
      }
    }

    public int oca_ProgKind
    {
      get => this._oca_ProgKind;
      set
      {
        this._oca_ProgKind = value;
        this.Changed(nameof (oca_ProgKind));
        this.Changed("oca_ProgKindDesc");
      }
    }

    public string oca_ProgKindDesc => this.oca_ProgKind != 0 ? Enum2StrConverter.ToAppType(this.oca_ProgKind).ToDescription() : string.Empty;

    public string oca_ProgVer
    {
      get => this._oca_ProgVer;
      set
      {
        this._oca_ProgVer = UbModelBase.LeftStr(value, 100).Replace("'", "´");
        this.Changed(nameof (oca_ProgVer));
      }
    }

    public int oca_StoreCode
    {
      get => this._oca_StoreCode;
      set
      {
        this._oca_StoreCode = value;
        this.Changed(nameof (oca_StoreCode));
      }
    }

    public string oca_DeviceName
    {
      get => this._oca_DeviceName;
      set
      {
        this._oca_DeviceName = UbModelBase.LeftStr(value, 200).Replace("'", "´");
        this.Changed(nameof (oca_DeviceName));
        this.Changed("oca_TreeNameDesc");
      }
    }

    public string oca_DeviceKey
    {
      get => this._oca_DeviceKey;
      set
      {
        this._oca_DeviceKey = UbModelBase.LeftStr(value, 200).Replace("'", "´");
        this.Changed(nameof (oca_DeviceKey));
      }
    }

    public string oca_DeviceIpInfo
    {
      get => this._oca_DeviceIpInfo;
      set
      {
        this._oca_DeviceIpInfo = UbModelBase.LeftStr(value, 500).Replace("'", "´");
        this.Changed(nameof (oca_DeviceIpInfo));
        this.Changed("Lt_DeviceIpInfo");
      }
    }

    public IList<DeviceIpInfo> Lt_DeviceIpInfo
    {
      get
      {
        if (string.IsNullOrEmpty(this.oca_DeviceIpInfo))
          return (IList<DeviceIpInfo>) null;
        try
        {
          if (this.oca_DeviceIpInfo.Contains("{"))
          {
            if (this.oca_DeviceIpInfo.Contains("}"))
            {
              if (this.oca_DeviceIpInfo.Contains("["))
              {
                if (this.oca_DeviceIpInfo.Contains("]"))
                  return JsonSerializer.Deserialize<IList<DeviceIpInfo>>(this.oca_DeviceIpInfo);
              }
            }
          }
        }
        catch
        {
        }
        return (IList<DeviceIpInfo>) null;
      }
    }

    public string oca_RealIp4
    {
      get => this._oca_RealIp4;
      set
      {
        this._oca_RealIp4 = UbModelBase.LeftStr(value, 20).Replace("'", "´");
        this.Changed(nameof (oca_RealIp4));
      }
    }

    public string oca_Gateway
    {
      get => this._oca_Gateway;
      set
      {
        this._oca_Gateway = UbModelBase.LeftStr(value, 20).Replace("'", "´");
        this.Changed(nameof (oca_Gateway));
      }
    }

    public int oca_DevicePort
    {
      get => this._oca_DevicePort;
      set
      {
        this._oca_DevicePort = value;
        this.Changed(nameof (oca_DevicePort));
      }
    }

    public string oca_BaseUrl
    {
      get => this._oca_BaseUrl;
      set
      {
        this._oca_BaseUrl = UbModelBase.LeftStr(value, 200).Replace("'", "´");
        this.Changed(nameof (oca_BaseUrl));
      }
    }

    public int oca_Count
    {
      get => this._oca_Count;
      set
      {
        this._oca_Count = value;
        this.Changed(nameof (oca_Count));
      }
    }

    public int oca_Status
    {
      get => this._oca_Status;
      set
      {
        this._oca_Status = value;
        this.Changed(nameof (oca_Status));
        this.Changed("oca_StatusDesc");
        this.Changed("oca_TreeNameDesc");
        this.Changed("oca_IsStatusAllow");
        this.Changed("oca_IsStatusBlock");
        this.Changed("oca_IsStatusRequest");
        this.Changed("oca_IsStatusExpireEx");
      }
    }

    public string oca_StatusDesc => this.oca_Status != 0 ? Enum2StrConverter.ToDevicePermit(this.oca_Status).ToDescription() : string.Empty;

    [JsonIgnore]
    public bool oca_IsStatusAllow => Enum2StrConverter.ToDevicePermit(this.oca_Status) == EnumDevicePermit.ALLOW;

    [JsonIgnore]
    public bool oca_IsStatusBlock => Enum2StrConverter.ToDevicePermit(this.oca_Status) == EnumDevicePermit.BLOCK;

    [JsonIgnore]
    public bool oca_IsStatusRequest => Enum2StrConverter.ToDevicePermit(this.oca_Status) == EnumDevicePermit.REQUEST;

    [JsonIgnore]
    public bool oca_IsStatusExpireEx => Enum2StrConverter.ToDevicePermit(this.oca_Status) == EnumDevicePermit.EXPIRE_EX;

    public DateTime? oca_ExpireDate
    {
      get => this._oca_ExpireDate;
      set
      {
        this._oca_ExpireDate = value;
        this.Changed(nameof (oca_ExpireDate));
      }
    }

    public string oca_Memo
    {
      get => this._oca_Memo;
      set
      {
        this._oca_Memo = UbModelBase.LeftStr(value, 500).Replace("'", "´");
        this.Changed(nameof (oca_Memo));
        this.Changed("oca_TreeNameDesc");
      }
    }

    public int oca_OsType
    {
      get => this._oca_OsType;
      set
      {
        this._oca_OsType = value;
        this.Changed(nameof (oca_OsType));
      }
    }

    public string oca_OsTypeDesc => this.oca_OsType != 0 ? Enum2StrConverter.ToOsType(this.oca_OsType).ToDescription() : string.Empty;

    public string oca_OsVersion
    {
      get => this._oca_OsVersion;
      set
      {
        this._oca_OsVersion = UbModelBase.LeftStr(value, 200).Replace("'", "´");
        this.Changed(nameof (oca_OsVersion));
      }
    }

    public int oca_AddProperty
    {
      get => this._oca_AddProperty;
      set
      {
        this._oca_AddProperty = value;
        this.Changed(nameof (oca_AddProperty));
      }
    }

    public DateTime? oca_InDate
    {
      get => this._oca_InDate;
      set
      {
        this._oca_InDate = value;
        this.Changed(nameof (oca_InDate));
      }
    }

    public int oca_InUser
    {
      get => this._oca_InUser;
      set
      {
        this._oca_InUser = value;
        this.Changed(nameof (oca_InUser));
      }
    }

    public DateTime? oca_ModDate
    {
      get => this._oca_ModDate;
      set
      {
        this._oca_ModDate = value;
        this.Changed(nameof (oca_ModDate));
      }
    }

    public int oca_ModUser
    {
      get => this._oca_ModUser;
      set
      {
        this._oca_ModUser = value;
        this.Changed(nameof (oca_ModUser));
      }
    }

    [JsonIgnore]
    public string oca_TreeNameDesc => this.oca_DeviceName + "[" + this.oca_StatusDesc + "]" + this.oca_Memo;

    public TOuterConnAuth() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("oca_ID", new TTableColumn()
      {
        tc_orgin_name = "oca_ID",
        tc_trans_name = "장치 코드"
      });
      columnInfo.Add("oca_SiteID", new TTableColumn()
      {
        tc_orgin_name = "oca_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("oca_ProgKind", new TTableColumn()
      {
        tc_orgin_name = "oca_ProgKind",
        tc_trans_name = "APP ID",
        tc_comm_code = 1
      });
      columnInfo.Add("oca_ProgVer", new TTableColumn()
      {
        tc_orgin_name = "oca_ProgVer",
        tc_trans_name = "APP VER"
      });
      columnInfo.Add("oca_StoreCode", new TTableColumn()
      {
        tc_orgin_name = "oca_StoreCode",
        tc_trans_name = "지점"
      });
      columnInfo.Add("oca_DeviceName", new TTableColumn()
      {
        tc_orgin_name = "oca_DeviceName",
        tc_trans_name = "장치명"
      });
      columnInfo.Add("oca_DeviceKey", new TTableColumn()
      {
        tc_orgin_name = "oca_DeviceKey",
        tc_trans_name = "장치키"
      });
      columnInfo.Add("oca_DeviceIpInfo", new TTableColumn()
      {
        tc_orgin_name = "oca_DeviceIpInfo",
        tc_trans_name = "IP INFO"
      });
      columnInfo.Add("oca_RealIp4", new TTableColumn()
      {
        tc_orgin_name = "oca_RealIp4",
        tc_trans_name = "IP4"
      });
      columnInfo.Add("oca_Gateway", new TTableColumn()
      {
        tc_orgin_name = "oca_Gateway",
        tc_trans_name = "Gateway"
      });
      columnInfo.Add("oca_DevicePort", new TTableColumn()
      {
        tc_orgin_name = "oca_DevicePort",
        tc_trans_name = "장치 포트"
      });
      columnInfo.Add("oca_BaseUrl", new TTableColumn()
      {
        tc_orgin_name = "oca_BaseUrl",
        tc_trans_name = "기본 주소"
      });
      columnInfo.Add("oca_Count", new TTableColumn()
      {
        tc_orgin_name = "oca_Count",
        tc_trans_name = "접속 카운트"
      });
      columnInfo.Add("oca_Status", new TTableColumn()
      {
        tc_orgin_name = "oca_Status",
        tc_trans_name = "허용 상태",
        tc_comm_code = 3
      });
      columnInfo.Add("oca_ExpireDate", new TTableColumn()
      {
        tc_orgin_name = "oca_ExpireDate",
        tc_trans_name = "만료일"
      });
      columnInfo.Add("oca_Memo", new TTableColumn()
      {
        tc_orgin_name = "oca_Memo",
        tc_trans_name = "메모"
      });
      columnInfo.Add("oca_OsType", new TTableColumn()
      {
        tc_orgin_name = "oca_OsType",
        tc_trans_name = "OS TYPE",
        tc_comm_code = 2
      });
      columnInfo.Add("oca_OsVersion", new TTableColumn()
      {
        tc_orgin_name = "oca_OsVersion",
        tc_trans_name = "OS VER"
      });
      columnInfo.Add("oca_AddProperty", new TTableColumn()
      {
        tc_orgin_name = "oca_AddProperty",
        tc_trans_name = "속성타입"
      });
      columnInfo.Add("oca_InDate", new TTableColumn()
      {
        tc_orgin_name = "oca_InDate",
        tc_trans_name = "등록일"
      });
      columnInfo.Add("oca_InUser", new TTableColumn()
      {
        tc_orgin_name = "oca_InUser",
        tc_trans_name = "등록인"
      });
      columnInfo.Add("oca_ModDate", new TTableColumn()
      {
        tc_orgin_name = "oca_ModDate",
        tc_trans_name = "수정일"
      });
      columnInfo.Add("oca_ModUser", new TTableColumn()
      {
        tc_orgin_name = "oca_ModUser",
        tc_trans_name = "수정인"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.OuterConnAuth;
      this.oca_ID = 0;
      this.oca_SiteID = 0L;
      this.oca_ProgKind = 0;
      this.oca_ProgVer = string.Empty;
      this.oca_StoreCode = 0;
      this.oca_DeviceName = string.Empty;
      this.oca_DeviceKey = string.Empty;
      this.oca_DeviceIpInfo = string.Empty;
      this.oca_RealIp4 = string.Empty;
      this.oca_Gateway = string.Empty;
      this.oca_DevicePort = 0;
      this.oca_BaseUrl = string.Empty;
      this.oca_Count = this.oca_Status = 0;
      this.oca_ExpireDate = new DateTime?();
      this.oca_Memo = string.Empty;
      this.oca_OsType = 0;
      this.oca_OsVersion = string.Empty;
      this.oca_AddProperty = 0;
      this.oca_InDate = new DateTime?();
      this.oca_InUser = 0;
      this.oca_ModDate = new DateTime?();
      this.oca_ModUser = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TOuterConnAuth();

    public override object Clone()
    {
      TOuterConnAuth touterConnAuth = base.Clone() as TOuterConnAuth;
      touterConnAuth.oca_ID = this.oca_ID;
      touterConnAuth.oca_SiteID = this.oca_SiteID;
      touterConnAuth.oca_ProgKind = this.oca_ProgKind;
      touterConnAuth.oca_ProgVer = this.oca_ProgVer;
      touterConnAuth.oca_StoreCode = this.oca_StoreCode;
      touterConnAuth.oca_DeviceName = this.oca_DeviceName;
      touterConnAuth.oca_DeviceKey = this.oca_DeviceKey;
      touterConnAuth.oca_DeviceIpInfo = this.oca_DeviceIpInfo;
      touterConnAuth.oca_RealIp4 = this.oca_RealIp4;
      touterConnAuth.oca_Gateway = this.oca_Gateway;
      touterConnAuth.oca_DevicePort = this.oca_DevicePort;
      touterConnAuth.oca_BaseUrl = this.oca_BaseUrl;
      touterConnAuth.oca_Count = this.oca_Count;
      touterConnAuth.oca_Status = this.oca_Status;
      touterConnAuth.oca_AddProperty = this.oca_AddProperty;
      touterConnAuth.oca_ExpireDate = this.oca_ExpireDate;
      touterConnAuth.oca_Memo = this.oca_Memo;
      touterConnAuth.oca_OsType = this.oca_OsType;
      touterConnAuth.oca_OsVersion = this.oca_OsVersion;
      touterConnAuth.oca_InDate = this.oca_InDate;
      touterConnAuth.oca_InUser = this.oca_InUser;
      touterConnAuth.oca_ModDate = this.oca_ModDate;
      touterConnAuth.oca_ModUser = this.oca_ModUser;
      return (object) touterConnAuth;
    }

    public void PutData(TOuterConnAuth pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.oca_ID = pSource.oca_ID;
      this.oca_SiteID = pSource.oca_SiteID;
      this.oca_ProgKind = pSource.oca_ProgKind;
      this.oca_ProgVer = pSource.oca_ProgVer;
      this.oca_StoreCode = pSource.oca_StoreCode;
      this.oca_DeviceName = pSource.oca_DeviceName;
      this.oca_DeviceKey = pSource.oca_DeviceKey;
      this.oca_DeviceIpInfo = pSource.oca_DeviceIpInfo;
      this.oca_RealIp4 = pSource.oca_RealIp4;
      this.oca_Gateway = pSource.oca_Gateway;
      this.oca_DevicePort = pSource.oca_DevicePort;
      this.oca_BaseUrl = pSource.oca_BaseUrl;
      this.oca_Count = pSource.oca_Count;
      this.oca_Status = pSource.oca_Status;
      this.oca_AddProperty = pSource.oca_AddProperty;
      this.oca_ExpireDate = pSource.oca_ExpireDate;
      this.oca_Memo = pSource.oca_Memo;
      this.oca_OsType = pSource.oca_OsType;
      this.oca_OsVersion = pSource.oca_OsVersion;
      this.oca_InDate = pSource.oca_InDate;
      this.oca_InUser = pSource.oca_InUser;
      this.oca_ModDate = pSource.oca_ModDate;
      this.oca_ModUser = pSource.oca_ModUser;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.oca_ID = p_rs.GetFieldInt("oca_ID");
        if (this.oca_ID == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.oca_SiteID = p_rs.GetFieldLong("oca_SiteID");
        this.oca_ProgKind = p_rs.GetFieldInt("oca_ProgKind");
        this.oca_ProgVer = p_rs.GetFieldString("oca_ProgVer");
        this.oca_StoreCode = p_rs.GetFieldInt("oca_StoreCode");
        this.oca_DeviceName = p_rs.GetFieldString("oca_DeviceName");
        this.oca_DeviceKey = p_rs.GetFieldString("oca_DeviceKey");
        this.oca_DeviceIpInfo = p_rs.GetFieldString("oca_DeviceIpInfo");
        this.oca_RealIp4 = p_rs.GetFieldString("oca_RealIp4");
        this.oca_Gateway = p_rs.GetFieldString("oca_Gateway");
        this.oca_DevicePort = p_rs.GetFieldInt("oca_DevicePort");
        this.oca_BaseUrl = p_rs.GetFieldString("oca_BaseUrl");
        this.oca_Count = p_rs.GetFieldInt("oca_Count");
        this.oca_Status = p_rs.GetFieldInt("oca_Status");
        this.oca_ExpireDate = p_rs.GetFieldDateTime("oca_ExpireDate");
        this.oca_Memo = p_rs.GetFieldString("oca_Memo");
        this.oca_OsType = p_rs.GetFieldInt("oca_OsType");
        this.oca_OsVersion = p_rs.GetFieldString("oca_OsVersion");
        this.oca_AddProperty = p_rs.GetFieldInt("oca_AddProperty");
        this.oca_InDate = p_rs.GetFieldDateTime("oca_InDate");
        this.oca_InUser = p_rs.GetFieldInt("oca_InUser");
        this.oca_ModDate = p_rs.GetFieldDateTime("oca_ModDate");
        this.oca_ModUser = p_rs.GetFieldInt("oca_ModUser");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery() => string.Format(" INSERT INTO {0}{1} (", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + " oca_ID,oca_SiteID,oca_ProgKind,oca_ProgVer,oca_StoreCode,oca_DeviceName,oca_DeviceKey,oca_DeviceIpInfo,oca_RealIp4,oca_Gateway,oca_DevicePort,oca_BaseUrl,oca_Count,oca_Status,oca_ExpireDate,oca_Memo,oca_OsType,oca_OsVersion,oca_AddProperty,oca_InDate,oca_InUser,oca_ModDate,oca_ModUser) VALUES ( " + string.Format(" {0}", (object) this.oca_ID) + string.Format(",{0}", (object) this.oca_SiteID) + string.Format(",{0},'{1}',{2}", (object) this.oca_ProgKind, (object) this.oca_ProgVer, (object) this.oca_StoreCode) + ",'" + this.oca_DeviceName + "','" + this.oca_DeviceKey + "','" + this.oca_DeviceIpInfo + "'" + string.Format(",'{0}','{1}',{2}", (object) this.oca_RealIp4, (object) this.oca_Gateway, (object) this.oca_DevicePort) + string.Format(",'{0}',{1},{2}", (object) this.oca_BaseUrl, (object) this.oca_Count, (object) this.oca_Status) + "," + this.oca_ExpireDate.GetDateToStrInNull() + string.Format(",'{0}',{1},'{2}'", (object) this.oca_Memo, (object) this.oca_OsType, (object) this.oca_OsVersion) + string.Format(",{0}", (object) this.oca_AddProperty) + string.Format(",{0},{1}", (object) this.oca_InDate.GetDateToStrInNull(), (object) this.oca_InUser) + string.Format(",{0},{1}", (object) this.oca_ModDate.GetDateToStrInNull(), (object) this.oca_ModUser) + ")";

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.oca_ID, (object) this.oca_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TOuterConnAuth touterConnAuth = this;
      // ISSUE: reference to a compiler-generated method
      touterConnAuth.\u003C\u003En__0();
      if (await touterConnAuth.OleDB.ExecuteAsync(touterConnAuth.InsertQuery()))
        return true;
      touterConnAuth.message = " " + touterConnAuth.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + touterConnAuth.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) touterConnAuth.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) touterConnAuth.oca_ID, (object) touterConnAuth.oca_SiteID) + " 내용 : " + touterConnAuth.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(touterConnAuth.message);
      return false;
    }

    public override string UpdateQuery() => string.Format(" UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) this.TableCode) + string.Format(" {0}='{1}',{2}={3}", (object) "oca_ProgVer", (object) this.oca_ProgVer, (object) "oca_StoreCode", (object) this.oca_StoreCode) + ",oca_DeviceName='" + this.oca_DeviceName + "',oca_DeviceKey='" + this.oca_DeviceKey + "',oca_DeviceIpInfo='" + this.oca_DeviceIpInfo + "'" + string.Format(",{0}='{1}',{2}='{3}',{4}={5}", (object) "oca_RealIp4", (object) this.oca_RealIp4, (object) "oca_Gateway", (object) this.oca_Gateway, (object) "oca_DevicePort", (object) this.oca_DevicePort) + string.Format(",{0}='{1}',{2}={3},{4}={5}", (object) "oca_BaseUrl", (object) this.oca_BaseUrl, (object) "oca_Count", (object) this.oca_Count, (object) "oca_Status", (object) this.oca_Status) + ",oca_ExpireDate=" + this.oca_ExpireDate.GetDateToStrInNull() + string.Format(",{0}='{1}',{2}={3},{4}='{5}'", (object) "oca_Memo", (object) this.oca_Memo, (object) "oca_OsType", (object) this.oca_OsType, (object) "oca_OsVersion", (object) this.oca_OsVersion) + string.Format(",{0}={1}", (object) "oca_AddProperty", (object) this.oca_AddProperty) + string.Format(",{0}={1},{2}={3}", (object) "oca_ModDate", (object) this.oca_ModDate.GetDateToStrInNull(), (object) "oca_ModUser", (object) this.oca_ModUser) + string.Format(" WHERE {0}={1}", (object) "oca_ID", (object) this.oca_ID) + string.Format(" AND {0}={1}", (object) "oca_SiteID", (object) this.oca_SiteID);

    public override bool Update(UbModelBase p_old = null)
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.oca_ID, (object) this.oca_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateAsync(UbModelBase p_old = null)
    {
      TOuterConnAuth touterConnAuth = this;
      // ISSUE: reference to a compiler-generated method
      touterConnAuth.\u003C\u003En__1();
      if (await touterConnAuth.OleDB.ExecuteAsync(touterConnAuth.UpdateQuery()))
        return true;
      touterConnAuth.message = " " + touterConnAuth.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + touterConnAuth.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) touterConnAuth.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) touterConnAuth.oca_ID, (object) touterConnAuth.oca_SiteID) + " 내용 : " + touterConnAuth.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(touterConnAuth.message);
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
      stringBuilder.Append(string.Format(" {0}='{1}',{2}={3}", (object) "oca_ProgVer", (object) this.oca_ProgVer, (object) "oca_StoreCode", (object) this.oca_StoreCode) + ",oca_DeviceName='" + this.oca_DeviceName + "',oca_DeviceKey='" + this.oca_DeviceKey + "',oca_DeviceIpInfo='" + this.oca_DeviceIpInfo + "'" + string.Format(",{0}='{1}',{2}='{3}',{4}={5}", (object) "oca_RealIp4", (object) this.oca_RealIp4, (object) "oca_Gateway", (object) this.oca_Gateway, (object) "oca_DevicePort", (object) this.oca_DevicePort) + string.Format(",{0}='{1}',{2}={3},{4}={5}", (object) "oca_BaseUrl", (object) this.oca_BaseUrl, (object) "oca_Count", (object) this.oca_Count, (object) "oca_Status", (object) this.oca_Status) + ",oca_ExpireDate=" + this.oca_ExpireDate.GetDateToStrInNull() + string.Format(",{0}='{1}',{2}={3},{4}={5}", (object) "oca_Memo", (object) this.oca_Memo, (object) "oca_OsType", (object) this.oca_OsType, (object) "oca_OsVersion", (object) this.oca_OsVersion) + string.Format(",{0}={1}", (object) "oca_AddProperty", (object) this.oca_AddProperty) + string.Format(",{0}={1},{2}={3}", (object) "oca_ModDate", (object) this.oca_ModDate.GetDateToStrInNull(), (object) "oca_ModUser", (object) this.oca_ModUser));
      stringBuilder.Append(";");
      return stringBuilder.ToString();
    }

    public override bool UpdateExInsert()
    {
      this.UpdateChecked();
      if (this.OleDB.Execute(this.UpdateExInsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) this.oca_ID, (object) this.oca_SiteID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> UpdateExInsertAsync()
    {
      TOuterConnAuth touterConnAuth = this;
      // ISSUE: reference to a compiler-generated method
      touterConnAuth.\u003C\u003En__1();
      if (await touterConnAuth.OleDB.ExecuteAsync(touterConnAuth.UpdateExInsertQuery()))
        return true;
      touterConnAuth.message = " " + touterConnAuth.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + touterConnAuth.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) touterConnAuth.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1})\n", (object) touterConnAuth.oca_ID, (object) touterConnAuth.oca_SiteID) + " 내용 : " + touterConnAuth.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(touterConnAuth.message);
      return false;
    }

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "oca_SiteID") && Convert.ToInt64(hashtable[(object) "oca_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "oca_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "oca_ID") && Convert.ToInt32(hashtable[(object) "oca_ID"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "oca_ID", hashtable[(object) "oca_ID"]));
        else
          stringBuilder.Append(" AND oca_ID>0");
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "oca_SiteID", (object) num));
        if (hashtable.ContainsKey((object) "oca_ProgKind") && Convert.ToInt32(hashtable[(object) "oca_ProgKind"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "oca_ProgKind", hashtable[(object) "oca_ProgKind"]));
        if (hashtable.ContainsKey((object) "si_StoreCode") && Convert.ToInt32(hashtable[(object) "si_StoreCode"].ToString()) >= 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "oca_StoreCode", hashtable[(object) "si_StoreCode"]));
        else if (hashtable.ContainsKey((object) "oca_StoreCode") && Convert.ToInt32(hashtable[(object) "oca_StoreCode"].ToString()) >= 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "oca_StoreCode", hashtable[(object) "oca_StoreCode"]));
        else if (hashtable.ContainsKey((object) "si_StoreCode_IN_") && hashtable[(object) "si_StoreCode_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "oca_StoreCode", hashtable[(object) "si_StoreCode_IN_"]));
        else if (hashtable.ContainsKey((object) "oca_StoreCode_IN_") && hashtable[(object) "oca_StoreCode_IN_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "oca_StoreCode", hashtable[(object) "oca_StoreCode_IN_"]));
        else if (hashtable.ContainsKey((object) "_STORE_AUTHS_") && hashtable[(object) "_STORE_AUTHS_"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0} IN ({1})", (object) "oca_StoreCode", hashtable[(object) "_STORE_AUTHS_"]));
        if (hashtable.ContainsKey((object) "oca_DeviceKey") && hashtable[(object) "oca_DeviceKey"].ToString().Length > 0)
          stringBuilder.Append(string.Format(" AND {0}='{1}'", (object) "oca_DeviceKey", hashtable[(object) "oca_DeviceKey"]));
        if (hashtable.ContainsKey((object) "oca_Status") && Convert.ToInt32(hashtable[(object) "oca_Status"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "oca_Status", hashtable[(object) "oca_Status"]));
        if (hashtable.ContainsKey((object) "oca_ExpireDate"))
        {
          stringBuilder.Append(" AND oca_ExpireDate >='" + new DateTime?((DateTime) hashtable[(object) "oca_ExpireDate"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND oca_ExpireDate <='" + new DateTime?((DateTime) hashtable[(object) "oca_ExpireDate"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
        }
        if (hashtable.ContainsKey((object) "oca_ExpireDate_BEGIN_") && hashtable.ContainsKey((object) "oca_ExpireDate_END_"))
        {
          stringBuilder.Append(" AND oca_ExpireDate >='" + new DateTime?((DateTime) hashtable[(object) "oca_ExpireDate_BEGIN_"]).GetDateToStr("yyyy-MM-dd 00:00:00") + "'");
          stringBuilder.Append(" AND oca_ExpireDate <='" + new DateTime?((DateTime) hashtable[(object) "oca_ExpireDate_END_"]).GetDateToStr("yyyy-MM-dd 23:59:59") + "'");
        }
        if (hashtable.ContainsKey((object) "oca_OsType") && Convert.ToInt32(hashtable[(object) "oca_OsType"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "oca_OsType", hashtable[(object) "oca_OsType"]));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_") && hashtable[(object) "_KEY_WORD_"].ToString().Trim().Length > 0)
        {
          stringBuilder.Append(string.Format(" AND ({0} LIKE '%{1}%'", (object) "oca_DeviceName", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "oca_DeviceKey", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "oca_RealIp4", hashtable[(object) "_KEY_WORD_"]));
          stringBuilder.Append(string.Format(" OR {0} LIKE '%{1}%'", (object) "oca_Memo", hashtable[(object) "_KEY_WORD_"]));
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
        stringBuilder.Append(" SELECT  oca_ID,oca_SiteID,oca_ProgKind,oca_ProgVer,oca_StoreCode,oca_DeviceName,oca_DeviceKey,oca_DeviceIpInfo,oca_RealIp4,oca_Gateway,oca_DevicePort,oca_BaseUrl,oca_Count,oca_Status,oca_ExpireDate,oca_Memo,oca_OsType,oca_OsVersion,oca_AddProperty,oca_InDate,oca_InUser,oca_ModDate,oca_ModUser");
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
