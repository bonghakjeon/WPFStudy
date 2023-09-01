// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Day.Horizontal.SalesByDayHorizontalByCategoryBotDic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Day.Horizontal
{
  public class SalesByDayHorizontalByCategoryBotDic : 
    BindableBase,
    IReadOnlyDictionary<string, SalesByDayHorizontalByCategoryBot>,
    IEnumerable<KeyValuePair<string, SalesByDayHorizontalByCategoryBot>>,
    IEnumerable,
    IReadOnlyCollection<KeyValuePair<string, SalesByDayHorizontalByCategoryBot>>
  {
    private Dictionary<string, SalesByDayHorizontalByCategoryBot> _Source = new Dictionary<string, SalesByDayHorizontalByCategoryBot>();

    public IReadOnlyDictionary<string, SalesByDayHorizontalByCategoryBot> Source => (IReadOnlyDictionary<string, SalesByDayHorizontalByCategoryBot>) this._Source;

    public IEnumerable<string> Keys => this.Source.Keys;

    public IEnumerable<SalesByDayHorizontalByCategoryBot> Values => this.Source.Values;

    public int Count => this.Source.Count;

    public SalesByDayHorizontalByCategoryBot this[string key]
    {
      get
      {
        SalesByDayHorizontalByCategoryBot horizontalByCategoryBot;
        return !this.Source.TryGetValue(key, out horizontalByCategoryBot) ? (SalesByDayHorizontalByCategoryBot) null : horizontalByCategoryBot;
      }
    }

    public void Clear() => this._Source.Clear();

    public void InitInfo(SalesByDayHorizontalByCategoryBot pData, IList<DateTime> p_Days)
    {
      if (this._Source.TryGetValue(pData.KeyCode, out SalesByDayHorizontalByCategoryBot _))
        return;
      SalesByDayHorizontalByCategoryBot horizontalByCategoryBot = new SalesByDayHorizontalByCategoryBot();
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

    public void Add(SalesByDayHorizontalByCategoryBot info)
    {
      SalesByDayHorizontalByCategoryBot horizontalByCategoryBot;
      if (!this._Source.TryGetValue(info.KeyCode, out horizontalByCategoryBot))
      {
        horizontalByCategoryBot = new SalesByDayHorizontalByCategoryBot();
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
      IEnumerable<SalesByDayHorizontalByCategoryBot> infos)
    {
      foreach (SalesByDayHorizontalByCategoryBot info in infos)
        this.Add(info);
    }

    public bool ContainsKey(string key) => this.Source.ContainsKey(key);

    public IEnumerator<KeyValuePair<string, SalesByDayHorizontalByCategoryBot>> GetEnumerator() => this.Source.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.Source.GetEnumerator();

    public bool TryGetValue(string key, [MaybeNullWhen(false)] out SalesByDayHorizontalByCategoryBot value) => this.Source.TryGetValue(key, out value);
  }
}
