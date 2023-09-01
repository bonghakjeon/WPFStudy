// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.Day.Vertical.StatementDayVerticalByStore
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.UniBase.Store.StoreInfo;
using UniBiz.Bo.Models.UniStock.Statement.Day.Horizontal;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniStock.Statement.Day.Vertical
{
  public class StatementDayVerticalByStore : StatementDayHorizontal<StatementDayVerticalByStore>
  {
    private string _si_StoreName;
    private string _si_StoreViewCode;
    private string _si_UseYn;
    private int _si_StoreType;
    private IList<StatementDayHorizontal> _Lt_Details;

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

    public string si_UseYn
    {
      get => this._si_UseYn;
      set
      {
        this._si_UseYn = value;
        this.Changed(nameof (si_UseYn));
        this.Changed("si_IsUseYn");
        this.Changed("si_UseYnDesc");
      }
    }

    public bool si_IsUseYn => "Y".Equals(this.si_UseYn);

    public string si_UseYnDesc => !"Y".Equals(this.si_UseYn) ? "미사용" : "사용";

    public int si_StoreType
    {
      get => this._si_StoreType;
      set
      {
        this._si_StoreType = value;
        this.Changed(nameof (si_StoreType));
        this.Changed("si_StoreTypeDesc");
      }
    }

    public string si_StoreTypeDesc => this.si_StoreType != 0 ? Enum2StrConverter.ToStoreType(this.si_StoreType).ToDescription() : string.Empty;

    [JsonPropertyName("lt_Details")]
    public IList<StatementDayHorizontal> Lt_Details
    {
      get => this._Lt_Details ?? (this._Lt_Details = (IList<StatementDayHorizontal>) new List<StatementDayHorizontal>());
      set
      {
        this._Lt_Details = value;
        this.Changed(nameof (Lt_Details));
      }
    }

    public override string ToString() => string.Format("{0} [{1}:{2}] Count : {3}", (object) nameof (StatementDayVerticalByStore), (object) this.si_StoreName, (object) this.sh_StoreCode, (object) this.Lt_Details.Count);

    public override void Clear()
    {
      base.Clear();
      this.si_StoreName = string.Empty;
      this.si_StoreViewCode = string.Empty;
      this.si_UseYn = "Y";
      this.si_StoreType = 0;
      this.Lt_Details = (IList<StatementDayHorizontal>) null;
    }

    public void InitInfo(StatementDayVerticalByStore pData, IList<StoreInfoView> p_Header)
    {
      if (!this.KeyCode.Equals(pData.KeyCode))
        throw new Exception("pData 의 [sh_ConfirmDate] 이 KeyCode 와 다릅니다");
      foreach (StoreInfoView storeInfoView in (IEnumerable<StoreInfoView>) p_Header)
        this.Lt_Details.Add(new StatementDayHorizontal()
        {
          sh_StoreCode = storeInfoView.si_StoreCode
        });
    }

    public void Add(StatementDayVerticalByStore item)
    {
      if (!item.sh_ConfirmDate.HasValue)
        throw new Exception("item 의 sh_ConfirmDate 일자 데이터 널");
      if (!this.sh_ConfirmDate.HasValue)
        this.sh_ConfirmDate = item.sh_ConfirmDate;
      else if (!this.KeyCode.Equals(item.KeyCode))
        throw new Exception("item 의 sh_ConfirmDate 이 sh_ConfirmDate 와 다릅니다");
      this.CalcAddSum((StatementDayHorizontal) item);
      StatementDayHorizontal statementDayHorizontal = this.Lt_Details.FirstOrDefault<StatementDayHorizontal>((Func<StatementDayHorizontal, bool>) (it => it.sh_StoreCode.Equals(item.sh_StoreCode)));
      if (statementDayHorizontal == null)
        this.Lt_Details.Add((StatementDayHorizontal) item);
      else
        statementDayHorizontal.PutData((StatementDayHorizontal) item);
    }

    public void AddRange(IList<StatementDayVerticalByStore> infos)
    {
      foreach (StatementDayVerticalByStore info in (IEnumerable<StatementDayVerticalByStore>) infos)
        this.Add(info);
    }

    public bool IsZero(EnumZeroCheck pCheckType, StatementDayVerticalByStore pSource) => pSource == null || this.IsZero(pCheckType, (StatementDayHorizontal) pSource);

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        if (!base.GetFieldValues(p_rs))
          return false;
        this.si_StoreName = p_rs.GetFieldString("si_StoreName");
        this.si_StoreViewCode = p_rs.GetFieldString("si_StoreViewCode");
        this.si_UseYn = p_rs.GetFieldString("si_UseYn");
        this.si_StoreType = p_rs.GetFieldInt("si_StoreType");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public async Task<IList<StatementDayVerticalByStore>> SelectDayVerticalByStoreListAsync(
      object p_param)
    {
      StatementDayVerticalByStore dayVerticalByStore1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(dayVerticalByStore1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, dayVerticalByStore1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(dayVerticalByStore1.GetSelectQuery(p_param)))
        {
          dayVerticalByStore1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + dayVerticalByStore1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<StatementDayVerticalByStore>) null;
        }
        IList<StatementDayVerticalByStore> lt_list = (IList<StatementDayVerticalByStore>) new List<StatementDayVerticalByStore>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            StatementDayVerticalByStore dayVerticalByStore2 = dayVerticalByStore1.OleDB.Create<StatementDayVerticalByStore>();
            if (dayVerticalByStore2.GetFieldValues(rs))
            {
              dayVerticalByStore2.row_number = lt_list.Count + 1;
              lt_list.Add(dayVerticalByStore2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + dayVerticalByStore1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<StatementDayVerticalByStore> SelectDayVerticalByStoreEnumerableAsync(
      object p_param)
    {
      StatementDayVerticalByStore dayVerticalByStore1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(dayVerticalByStore1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, dayVerticalByStore1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(dayVerticalByStore1.GetSelectQuery(p_param)))
        {
          dayVerticalByStore1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + dayVerticalByStore1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            StatementDayVerticalByStore dayVerticalByStore2 = dayVerticalByStore1.OleDB.Create<StatementDayVerticalByStore>();
            if (dayVerticalByStore2.GetFieldValues(rs))
            {
              dayVerticalByStore2.row_number = ++row_number;
              yield return dayVerticalByStore2;
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

    public override string GetSelectQuery(object p_param) => new StatementDayHorizontalByStore().GetSelectQuery(p_param);
  }
}
