// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.Month.Vertical.StatementMonthVerticalByGoods
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.UniBase.GoodsInfo.Goods;
using UniBiz.Bo.Models.UniStock.Statement.Month.Horizontal;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniStock.Statement.Month.Vertical
{
  public class StatementMonthVerticalByGoods : 
    StatementMonthVerticalByCategoryBot<StatementMonthVerticalByGoods>
  {
    private string _gd_GoodsName;
    private string _gd_BarCode;
    private string _gd_GoodsSize;
    private string _gd_UseYn;
    private double _gdh_BuyCost;
    private double _gdh_BuyVat;
    private double _gdh_SalePrice;
    private double _gdh_EventCost;
    private double _gdh_EventVat;
    private double _gdh_EventPrice;

    public string gd_GoodsName
    {
      get => this._gd_GoodsName;
      set
      {
        this._gd_GoodsName = value;
        this.Changed(nameof (gd_GoodsName));
      }
    }

    public string gd_BarCode
    {
      get => this._gd_BarCode;
      set
      {
        this._gd_BarCode = value;
        this.Changed(nameof (gd_BarCode));
      }
    }

    public string gd_GoodsSize
    {
      get => this._gd_GoodsSize;
      set
      {
        this._gd_GoodsSize = value;
        this.Changed(nameof (gd_GoodsSize));
      }
    }

    public string gd_UseYn
    {
      get => this._gd_UseYn;
      set
      {
        this._gd_UseYn = value;
        this.Changed(nameof (gd_UseYn));
        this.Changed("gd_IsUseYn");
        this.Changed("gd_UseYnDesc");
      }
    }

    public bool gd_IsUseYn => "Y".Equals(this.gd_UseYn);

    public string gd_UseYnDesc => !"Y".Equals(this.gd_UseYn) ? "미사용" : "사용";

    public double gdh_BuyCost
    {
      get => this._gdh_BuyCost;
      set
      {
        this._gdh_BuyCost = value;
        this.Changed(nameof (gdh_BuyCost));
      }
    }

    public double gdh_BuyVat
    {
      get => this._gdh_BuyVat;
      set
      {
        this._gdh_BuyVat = value;
        this.Changed(nameof (gdh_BuyVat));
      }
    }

    public double gdh_SalePrice
    {
      get => this._gdh_SalePrice;
      set
      {
        this._gdh_SalePrice = value;
        this.Changed(nameof (gdh_SalePrice));
      }
    }

    public double gdh_EventCost
    {
      get => this._gdh_EventCost;
      set
      {
        this._gdh_EventCost = value;
        this.Changed(nameof (gdh_EventCost));
      }
    }

    public double gdh_EventVat
    {
      get => this._gdh_EventVat;
      set
      {
        this._gdh_EventVat = value;
        this.Changed(nameof (gdh_EventVat));
      }
    }

    public double gdh_EventPrice
    {
      get => this._gdh_EventPrice;
      set
      {
        this._gdh_EventPrice = value;
        this.Changed(nameof (gdh_EventPrice));
      }
    }

    public override string ToString() => string.Format("{0} [{1}] Count : {2}", (object) nameof (StatementMonthVerticalByGoods), (object) this.sh_ConfirmDate, (object) this.Lt_Details.Count);

    public override void Clear()
    {
      base.Clear();
      this.gd_GoodsName = this.gd_BarCode = this.gd_GoodsSize = string.Empty;
      this.gd_UseYn = string.Empty;
      this.gdh_BuyCost = this.gdh_BuyVat = this.gdh_SalePrice = 0.0;
      this.gdh_EventCost = this.gdh_EventVat = this.gdh_EventPrice = 0.0;
    }

    public void InitInfo(StatementMonthVerticalByGoods pData, IList<TGoods> p_Header)
    {
      if (!this.KeyCode.Equals(pData.KeyCode))
        throw new Exception("pData 의 [sh_ConfirmDate] 이 KeyCode 와 다릅니다");
      foreach (TGoods tgoods in (IEnumerable<TGoods>) p_Header)
      {
        IList<StatementMonthHorizontal> ltDetails = this.Lt_Details;
        StatementMonthHorizontal statementMonthHorizontal = new StatementMonthHorizontal();
        statementMonthHorizontal.sh_StoreCode = pData.sh_StoreCode;
        statementMonthHorizontal.sd_BoxCode = tgoods.gd_GoodsCode;
        ltDetails.Add(statementMonthHorizontal);
      }
    }

    public void Add(StatementMonthVerticalByGoods item)
    {
      if (!item.sh_ConfirmDate.HasValue)
        throw new Exception("item 의 sh_ConfirmDate 일자 데이터 널");
      if (!this.sh_ConfirmDate.HasValue)
        this.sh_ConfirmDate = item.sh_ConfirmDate;
      else if (!this.KeyCode.Equals(item.KeyCode))
        throw new Exception("item 의 sh_ConfirmDate 이 sh_ConfirmDate 와 다릅니다");
      this.CalcAddSum((StatementMonthHorizontal) item);
      StatementMonthHorizontal statementMonthHorizontal = this.Lt_Details.FirstOrDefault<StatementMonthHorizontal>((Func<StatementMonthHorizontal, bool>) (it => it.sh_StoreCode == item.sh_StoreCode && it.sd_BoxCode == item.sd_BoxCode));
      if (statementMonthHorizontal == null)
        this.Lt_Details.Add((StatementMonthHorizontal) item);
      else
        statementMonthHorizontal.PutData((StatementMonthHorizontal) item);
    }

    public void AddRange(IList<StatementMonthVerticalByGoods> infos)
    {
      foreach (StatementMonthVerticalByGoods info in (IEnumerable<StatementMonthVerticalByGoods>) infos)
        this.Add(info);
    }

    public bool IsZero(EnumZeroCheck pCheckType, StatementMonthVerticalByGoods pSource) => pSource == null || this.IsZero(pCheckType, (StatementMonthVerticalByCategoryBot) pSource);

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        if (!base.GetFieldValues(p_rs))
          return false;
        this.gd_GoodsName = p_rs.GetFieldString("gd_GoodsName");
        this.gd_BarCode = p_rs.GetFieldString("gd_BarCode");
        this.gd_GoodsSize = p_rs.GetFieldString("gd_GoodsSize");
        this.gd_UseYn = p_rs.GetFieldString("gd_UseYn");
        this.gdh_BuyCost = p_rs.GetFieldDouble("gdh_BuyCost");
        this.gdh_BuyVat = p_rs.GetFieldDouble("gdh_BuyVat");
        this.gdh_SalePrice = p_rs.GetFieldDouble("gdh_SalePrice");
        this.gdh_EventCost = p_rs.GetFieldDouble("gdh_EventCost");
        this.gdh_EventVat = p_rs.GetFieldDouble("gdh_EventVat");
        this.gdh_EventPrice = p_rs.GetFieldDouble("gdh_EventPrice");
        return true;
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public async Task<IList<StatementMonthVerticalByGoods>> SelectMonthVerticalByGoodsListAsync(
      object p_param)
    {
      StatementMonthVerticalByGoods monthVerticalByGoods1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(monthVerticalByGoods1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, monthVerticalByGoods1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(monthVerticalByGoods1.GetSelectQuery(p_param)))
        {
          monthVerticalByGoods1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + monthVerticalByGoods1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<StatementMonthVerticalByGoods>) null;
        }
        IList<StatementMonthVerticalByGoods> lt_list = (IList<StatementMonthVerticalByGoods>) new List<StatementMonthVerticalByGoods>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            StatementMonthVerticalByGoods monthVerticalByGoods2 = monthVerticalByGoods1.OleDB.Create<StatementMonthVerticalByGoods>();
            if (monthVerticalByGoods2.GetFieldValues(rs))
            {
              monthVerticalByGoods2.row_number = lt_list.Count + 1;
              lt_list.Add(monthVerticalByGoods2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + monthVerticalByGoods1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<StatementMonthVerticalByGoods> SelectMonthVerticalByGoodsEnumerableAsync(
      object p_param)
    {
      StatementMonthVerticalByGoods monthVerticalByGoods1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(monthVerticalByGoods1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, monthVerticalByGoods1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(monthVerticalByGoods1.GetSelectQuery(p_param)))
        {
          monthVerticalByGoods1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + monthVerticalByGoods1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            StatementMonthVerticalByGoods monthVerticalByGoods2 = monthVerticalByGoods1.OleDB.Create<StatementMonthVerticalByGoods>();
            if (monthVerticalByGoods2.GetFieldValues(rs))
            {
              monthVerticalByGoods2.row_number = ++row_number;
              yield return monthVerticalByGoods2;
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

    public override string GetSelectQuery(object p_param) => new StatementMonthHorizontalByGoods().GetSelectQuery(p_param);
  }
}
