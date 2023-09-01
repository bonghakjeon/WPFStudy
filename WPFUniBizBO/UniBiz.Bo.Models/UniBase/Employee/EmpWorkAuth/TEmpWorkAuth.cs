// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniBase.Employee.EmpWorkAuth.TEmpWorkAuth
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.TableInfo;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniBase.Employee.EmpWorkAuth
{
  public class TEmpWorkAuth : UbModelBase<TEmpWorkAuth>
  {
    private int _emp_Code;
    private long _emp_SiteID;
    private int _emp_ProgAuth;
    private int _emp_TypeNo;
    private string _ColName;

    public override object _Key => (object) new object[1]
    {
      (object) this.emp_Code
    };

    public int emp_Code
    {
      get => this._emp_Code;
      set
      {
        this._emp_Code = value;
        this.Changed(nameof (emp_Code));
      }
    }

    public long emp_SiteID
    {
      get => this._emp_SiteID;
      set
      {
        this._emp_SiteID = value;
        this.Changed(nameof (emp_SiteID));
      }
    }

    public int emp_ProgAuth
    {
      get => this._emp_ProgAuth;
      set
      {
        this._emp_ProgAuth = value;
        this.Changed(nameof (emp_ProgAuth));
        this.Changed("emp_IsTypeNo");
      }
    }

    public int emp_TypeNo
    {
      get => this._emp_TypeNo;
      set
      {
        this._emp_TypeNo = value;
        this.Changed(nameof (emp_TypeNo));
        this.Changed("emp_IsTypeNo");
        this.Changed("emp_TypeNoDesc");
        this.Changed("emp_IsTypeNoFixed");
      }
    }

    public virtual string emp_TypeNoDesc => this.emp_TypeNo != 0 ? string.Empty : string.Empty;

    public virtual bool emp_IsTypeNoFixed => true;

    public string ColName
    {
      get => this._ColName;
      set
      {
        this._ColName = value;
        this.Changed(nameof (ColName));
      }
    }

    public bool emp_IsTypeNo => (this.emp_ProgAuth & this.emp_TypeNo) == this.emp_TypeNo;

    public TEmpWorkAuth() => this.Clear();

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("emp_Code", new TTableColumn()
      {
        tc_orgin_name = "emp_Code",
        tc_trans_name = "사원코드"
      });
      columnInfo.Add("emp_SiteID", new TTableColumn()
      {
        tc_orgin_name = "emp_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("emp_ProgAuth", new TTableColumn()
      {
        tc_orgin_name = "emp_ProgAuth",
        tc_trans_name = "허용코드"
      });
      columnInfo.Add("emp_TypeNo", new TTableColumn()
      {
        tc_orgin_name = "emp_TypeNo",
        tc_trans_name = "작업 권한 타입"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.TableCode = TableCodeType.Employee;
      this.emp_Code = 0;
      this.emp_SiteID = 0L;
      this.emp_ProgAuth = this.emp_TypeNo = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new TEmpWorkAuth();

    public override object Clone()
    {
      TEmpWorkAuth tempWorkAuth = base.Clone() as TEmpWorkAuth;
      tempWorkAuth.emp_Code = this.emp_Code;
      tempWorkAuth.emp_SiteID = this.emp_SiteID;
      tempWorkAuth.emp_ProgAuth = this.emp_ProgAuth;
      tempWorkAuth.emp_TypeNo = this.emp_TypeNo;
      return (object) tempWorkAuth;
    }

    public void PutData(TEmpWorkAuth pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.emp_Code = pSource.emp_Code;
      this.emp_SiteID = pSource.emp_SiteID;
      this.emp_ProgAuth = pSource.emp_ProgAuth;
      this.emp_TypeNo = pSource.emp_TypeNo;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        this.emp_Code = p_rs.GetFieldInt("emp_Code");
        if (this.emp_Code == 0)
          throw new Exception(EnumDataCheck.NULL.ToDescription());
        this.emp_SiteID = p_rs.GetFieldLong("emp_SiteID");
        this.emp_ProgAuth = p_rs.GetFieldInt("emp_ProgAuth");
        this.emp_TypeNo = p_rs.GetFieldInt("emp_TypeNo");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public override string InsertQuery()
    {
      if (string.IsNullOrEmpty(this.ColName))
        return string.Empty;
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format("UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.Employee));
      stringBuilder.Append(string.Format(" {0}={1}|{2}", (object) this.ColName, (object) this.ColName, (object) this.emp_TypeNo));
      stringBuilder.Append(string.Format(" WHERE emp_Code={0}", (object) this.emp_Code));
      stringBuilder.Append(string.Format(" AND emp_SiteID={0}", (object) this.emp_SiteID));
      return stringBuilder.ToString();
    }

    public override bool Insert()
    {
      this.InsertChecked();
      if (this.OleDB.Execute(this.InsertQuery()))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},[{2}={3}])\n", (object) this.emp_Code, (object) this.emp_SiteID, (object) this.ColName, (object) this.emp_TypeNo) + " 내용 : " + this.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(this.message);
      return false;
    }

    public override async Task<bool> InsertAsync()
    {
      TEmpWorkAuth tempWorkAuth = this;
      // ISSUE: reference to a compiler-generated method
      tempWorkAuth.\u003C\u003En__0();
      if (await tempWorkAuth.OleDB.ExecuteAsync(tempWorkAuth.InsertQuery()))
        return true;
      tempWorkAuth.message = " " + tempWorkAuth.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tempWorkAuth.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tempWorkAuth.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},[{2}={3}])\n", (object) tempWorkAuth.emp_Code, (object) tempWorkAuth.emp_SiteID, (object) tempWorkAuth.ColName, (object) tempWorkAuth.emp_TypeNo) + " 내용 : " + tempWorkAuth.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tempWorkAuth.message);
      return false;
    }

    public override string DeleteQuery()
    {
      if (string.IsNullOrEmpty(this.ColName))
        return string.Empty;
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(string.Format("UPDATE {0}{1} SET ", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_BASE), (object) TableCodeType.Employee));
      stringBuilder.Append(string.Format(" {0}={1}& ~{2}", (object) this.ColName, (object) this.ColName, (object) this.emp_TypeNo));
      stringBuilder.Append(string.Format(" WHERE emp_Code={0}", (object) this.emp_Code));
      stringBuilder.Append(string.Format(" AND emp_SiteID={0}", (object) this.emp_SiteID));
      return stringBuilder.ToString();
    }

    public override bool Delete()
    {
      this.InsertChecked();
      string pStrExec = this.DeleteQuery();
      if (this.OleDB.Execute(pStrExec))
        return true;
      this.message = " " + this.TableCode.ToDescription() + " 삭제 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().DeclaringType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 코드 : ({0},{1},[{2}={3}])\n", (object) this.emp_Code, (object) this.emp_SiteID, (object) this.ColName, (object) this.emp_TypeNo) + string.Format(" 에러 : {0}\n", (object) this.OleDB.LastErrorID) + " 내용 : " + this.OleDB.LastErrorMessage + "\n 쿼리 : " + pStrExec + "\n--------------------------------------------------------------------------------------------------\n";
      return false;
    }

    public override async Task<bool> DeleteAsync()
    {
      TEmpWorkAuth tempWorkAuth = this;
      // ISSUE: reference to a compiler-generated method
      tempWorkAuth.\u003C\u003En__0();
      if (await tempWorkAuth.OleDB.ExecuteAsync(tempWorkAuth.DeleteQuery()))
        return true;
      tempWorkAuth.message = " " + tempWorkAuth.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + tempWorkAuth.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) tempWorkAuth.OleDB.LastErrorID) + string.Format(" 코드 : ({0},{1},[{2}={3}])\n", (object) tempWorkAuth.emp_Code, (object) tempWorkAuth.emp_SiteID, (object) tempWorkAuth.ColName, (object) tempWorkAuth.emp_TypeNo) + " 내용 : " + tempWorkAuth.OleDB.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n";
      Log.Logger.DebugColor(tempWorkAuth.message);
      return false;
    }
  }
}
