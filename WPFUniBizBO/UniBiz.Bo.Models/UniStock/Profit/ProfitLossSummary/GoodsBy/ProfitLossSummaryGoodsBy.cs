// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Profit.ProfitLossSummary.GoodsBy.ProfitLossSummaryGoodsBy
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text.Json.Serialization;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.TableInfo;
using UniBiz.Bo.Models.UniStock.Profit.ProfitLossSummary.Date;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniStock.Profit.ProfitLossSummary.GoodsBy
{
  public class ProfitLossSummaryGoodsBy : ProfitLossSummaryDateGoods<ProfitLossSummaryGoodsBy>
  {
    private int _pls_HeadCount;
    private IList<TProfitLossSummary> _Lt_Details;

    public virtual string KeyCode => string.Format("{0}", (object) this.pls_GoodsCode);

    public override long pls_GoodsCode
    {
      get => this._pls_GoodsCode;
      set
      {
        this._pls_GoodsCode = value;
        this.Changed(nameof (pls_GoodsCode));
        this.Changed("KeyCode");
      }
    }

    public int pls_HeadCount
    {
      get => this._pls_HeadCount;
      set
      {
        this._pls_HeadCount = value;
        this.Changed(nameof (pls_HeadCount));
      }
    }

    [JsonPropertyName("lt_Details")]
    public IList<TProfitLossSummary> Lt_Details
    {
      get => this._Lt_Details ?? (this._Lt_Details = (IList<TProfitLossSummary>) new List<TProfitLossSummary>());
      set
      {
        this._Lt_Details = value;
        this.Changed(nameof (Lt_Details));
      }
    }

    public override Dictionary<string, TTableColumn> ToColumnInfo() => base.ToColumnInfo();

    public override string ToString() => string.Format("{0} [{1}({2})] Count : {3}", (object) nameof (ProfitLossSummaryGoodsBy), (object) this.gd_GoodsName, (object) this.pls_GoodsCode, (object) this.Lt_Details.Count);

    public override void Clear()
    {
      base.Clear();
      this.pls_HeadCount = 0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new ProfitLossSummaryGoodsBy();

    public override object Clone()
    {
      ProfitLossSummaryGoodsBy lossSummaryGoodsBy = base.Clone() as ProfitLossSummaryGoodsBy;
      lossSummaryGoodsBy.pls_HeadCount = this.pls_HeadCount;
      return (object) lossSummaryGoodsBy;
    }

    public void PutData(ProfitLossSummaryGoodsBy pSource)
    {
      this.PutData((ProfitLossSummaryDateGoods) pSource);
      this.pls_HeadCount = pSource.pls_HeadCount;
    }

    public bool CalcAddSum(ProfitLossSummaryGoodsBy pSource) => pSource != null && this.CalcAddSum((ProfitLossSummaryDateStore) pSource);

    public bool IsZero(EnumZeroCheck pCheckType, ProfitLossSummaryGoodsBy pSource) => pSource == null || this.IsZero(pCheckType, (ProfitLossSummaryDateGoods) pSource);

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
  }
}
