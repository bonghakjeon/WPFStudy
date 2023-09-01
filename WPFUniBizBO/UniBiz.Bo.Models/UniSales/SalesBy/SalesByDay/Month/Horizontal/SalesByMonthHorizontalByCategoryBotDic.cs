// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Month.Horizontal.SalesByMonthHorizontalByCategoryBotDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Month.Horizontal
{
  public class SalesByMonthHorizontalByCategoryBotDic : 
    BindableBase,
    IReadOnlyDictionary<string, SalesByMonthHorizontalByCategoryBot>,
    IEnumerable<KeyValuePair<string, SalesByMonthHorizontalByCategoryBot>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, SalesByMonthHorizontalByCategoryBot>>
  {
    private Dictionary<string, SalesByMonthHorizontalByCategoryBot> _Source = new Dictionary<string, SalesByMonthHorizontalByCategoryBot>();

    public IReadOnlyDictionary<string, SalesByMonthHorizontalByCategoryBot> Source => (IReadOnlyDictionary<string, SalesByMonthHorizontalByCategoryBot>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<SalesByMonthHorizontalByCategoryBot> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public SalesByMonthHorizontalByCategoryBot this[string key]
    {
      get
      {
        SalesByMonthHorizontalByCategoryBot horizontalByCategoryBot;
        return !this.Source.TryGetValue(key, out horizontalByCategoryBot) ? (SalesByMonthHorizontalByCategoryBot) null : horizontalByCategoryBot;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(SalesByMonthHorizontalByCategoryBot pData, IList<DateTime> p_Days)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out SalesByMonthHorizontalByCategoryBot _))
        return;
      SalesByMonthHorizontalByCategoryBot horizontalByCategoryBot = new SalesByMonthHorizontalByCategoryBot();
      horizontalByCategoryBot.si_StoreCode = pData.sbd_StoreCode;
      horizontalByCategoryBot.dpt_lv1_ID = pData.dpt_lv1_ID;
      horizontalByCategoryBot.dpt_lv2_ID = pData.dpt_lv2_ID;
      horizontalByCategoryBot.sbd_DeptCode = pData.sbd_DeptCode;
      horizontalByCategoryBot.ctg_lv1_ID = pData.ctg_lv1_ID;
      horizontalByCategoryBot.ctg_lv2_ID = pData.ctg_lv2_ID;
      horizontalByCategoryBot.sbd_CategoryCode = pData.sbd_CategoryCode;
      this._Source.Add(pData.KeyCode, horizontalByCategoryBot);
      horizontalByCategoryBot.InitInfo(pData, p_Days);
    }

    public void Add(SalesByMonthHorizontalByCategoryBot info)
    {
      SalesByMonthHorizontalByCategoryBot horizontalByCategoryBot;
      if (!this._Source.TryGetValue(info.KeyCode, out horizontalByCategoryBot))
      {
        horizontalByCategoryBot = new SalesByMonthHorizontalByCategoryBot();
        horizontalByCategoryBot.si_StoreCode = info.sbd_StoreCode;
        horizontalByCategoryBot.dpt_lv1_ID = info.dpt_lv1_ID;
        horizontalByCategoryBot.dpt_lv2_ID = info.dpt_lv2_ID;
        horizontalByCategoryBot.sbd_DeptCode = info.sbd_DeptCode;
        horizontalByCategoryBot.ctg_lv1_ID = info.ctg_lv1_ID;
        horizontalByCategoryBot.ctg_lv2_ID = info.ctg_lv2_ID;
        horizontalByCategoryBot.sbd_CategoryCode = info.sbd_CategoryCode;
        this._Source.Add(info.KeyCode, horizontalByCategoryBot);
      }
      horizontalByCategoryBot?.Add(info);
    }

    public void AddRange(
      IEnumerable<SalesByMonthHorizontalByCategoryBot> infos)
    {
      foreach (SalesByMonthHorizontalByCategoryBot info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, SalesByMonthHorizontalByCategoryBot>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out SalesByMonthHorizontalByCategoryBot value) => this.Source.TryGetValue(key, out value);
  }
}
