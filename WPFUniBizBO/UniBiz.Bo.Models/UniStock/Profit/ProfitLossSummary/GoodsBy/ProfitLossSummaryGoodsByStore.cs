// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Profit.ProfitLossSummary.GoodsBy.ProfitLossSummaryGoodsByStore
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
using UniBiz.Bo.Models.UniBase.Store.StoreInfo;
using UniBiz.Bo.Models.UniStock.Profit.ProfitLossSummary.Date;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniStock.Profit.ProfitLossSummary.GoodsBy
{
  public class ProfitLossSummaryGoodsByStore : 
    ProfitLossSummaryGoodsBy<ProfitLossSummaryGoodsByStore>
  {
    public void InitInfo(ProfitLossSummaryGoodsByStore pData, IList<StoreInfoView> p_Header)
    {
      if (!this.KeyCode.Equals(pData.KeyCode))
        throw new Exception("pData 의 [pls_GoodsCode] 이 KeyCode 와 다릅니다");
      foreach (StoreInfoView storeInfoView in (IEnumerable<StoreInfoView>) p_Header)
        this.Lt_Details.Add(new TProfitLossSummary()
        {
          pls_StoreCode = storeInfoView.si_StoreCode
        });
    }

    public void Add(ProfitLossSummaryGoodsByStore item)
    {
      if (item.pls_GoodsCode == 0L)
        throw new Exception("item 의 pls_GoodsCode 일자 데이터 널");
      if (this.pls_GoodsCode == 0L)
        this.pls_GoodsCode = item.pls_GoodsCode;
      else if (!this.KeyCode.Equals(item.KeyCode))
        throw new Exception("item 의 pls_GoodsCode 이 pls_GoodsCode 와 다릅니다");
      this.CalcAddSum((ProfitLossSummaryGoodsBy) item);
      TProfitLossSummary tprofitLossSummary = this.Lt_Details.Where<TProfitLossSummary>((Func<TProfitLossSummary, bool>) (it => it.pls_StoreCode.Equals(item.pls_StoreCode))).FirstOrDefault<TProfitLossSummary>();
      if (tprofitLossSummary == null)
        this.Lt_Details.Add((TProfitLossSummary) item);
      else
        tprofitLossSummary.PutData((TProfitLossSummary) item);
    }

    public void AddRange(IList<ProfitLossSummaryGoodsByStore> infos)
    {
      foreach (ProfitLossSummaryGoodsByStore info in (IEnumerable<ProfitLossSummaryGoodsByStore>) infos)
        this.Add(info);
    }

    public bool IsZero(EnumZeroCheck pCheckType, ProfitLossSummaryGoodsByStore pSource) => pSource == null || this.IsZero(pCheckType, (ProfitLossSummaryGoodsBy) pSource);

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      try
      {
        return base.GetFieldValues(p_rs);
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
      }
      return false;
    }

    public async Task<IList<ProfitLossSummaryGoodsByStore>> SelectGoodsByStoreListAsync(
      object p_param)
    {
      ProfitLossSummaryGoodsByStore summaryGoodsByStore1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(summaryGoodsByStore1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, summaryGoodsByStore1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(summaryGoodsByStore1.GetSelectQuery(p_param)))
        {
          summaryGoodsByStore1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + summaryGoodsByStore1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<ProfitLossSummaryGoodsByStore>) null;
        }
        IList<ProfitLossSummaryGoodsByStore> lt_list = (IList<ProfitLossSummaryGoodsByStore>) new List<ProfitLossSummaryGoodsByStore>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            ProfitLossSummaryGoodsByStore summaryGoodsByStore2 = summaryGoodsByStore1.OleDB.Create<ProfitLossSummaryGoodsByStore>();
            if (summaryGoodsByStore2.GetFieldValues(rs))
            {
              summaryGoodsByStore2.row_number = lt_list.Count + 1;
              lt_list.Add(summaryGoodsByStore2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + summaryGoodsByStore1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<ProfitLossSummaryGoodsByStore> SelectGoodsByStoreEnumerableAsync(
      object p_param)
    {
      ProfitLossSummaryGoodsByStore summaryGoodsByStore1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(summaryGoodsByStore1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, summaryGoodsByStore1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(summaryGoodsByStore1.GetSelectQuery(p_param)))
        {
          summaryGoodsByStore1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + summaryGoodsByStore1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            ProfitLossSummaryGoodsByStore summaryGoodsByStore2 = summaryGoodsByStore1.OleDB.Create<ProfitLossSummaryGoodsByStore>();
            if (summaryGoodsByStore2.GetFieldValues(rs))
            {
              summaryGoodsByStore2.row_number = ++row_number;
              yield return summaryGoodsByStore2;
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

    public override string GetSelectQuery(object p_param) => new ProfitLossSummaryDateGoods().GetSelectQuery(p_param);
  }
}
