// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Page.UniSales.Sales.Supplier.Sales.SupplierPageVM
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Serilog;
using StyletIoC;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Supplier;
using UniBizBO.Services;
using UniBizBO.Services.Page;
using UniBizBO.ViewModels.Box;
using UniinfoNet.Windows.Wpf.DataView;


#nullable enable
namespace UniBizBO.ViewModels.Page.UniSales.Sales.Supplier.Sales
{
  public class SupplierPageVM : SupplierPageBase<
  #nullable disable
  SaleByDayDateSupplier>, ISystemPage
  {
    public SupplierPageVM(IContainer container)
      : base(container)
    {
    }

    protected override void InitCategoryViews()
    {
      if (this.DataView.CategoryViews.Count != 0)
        return;
      this.CreateCategoryViews();
    }

    protected override void CreateCategoryViews()
    {
      base.CreateCategoryViews();
      this.DataView.CategoryViews.Add(new UniDataCategoryView()
      {
        Key = "S2_StoreEx",
        IsDisplay = false
      });
      this.DataView.CategoryViews.Add(new UniDataCategoryView()
      {
        Key = "S2_SupplierEx",
        IsDisplay = true
      });
    }

    public override async Task SearchAsync()
    {
      SupplierPageVM supplierPageVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (supplierPageVm.Job).CreateJob("검색", (string) null))
        {
          supplierPageVm.Datas.Clear();
          supplierPageVm.FooterRemark = string.Empty;
        }
      }
      catch (Exception ex)
      {
        Log.Error(ex.Message);
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (supplierPageVm.Container)).Set(__nonvirtual (supplierPageVm.MenuInfo).Title + " 오류", ex.Message).ShowDialog();
      }
    }

    public override async void NextTabColume((object, object) x)
    {
      SupplierPageVM sender = this;
      SaleByDayDateSupplier byDayDateSupplier = (SaleByDayDateSupplier) x.Item1;
      string str1 = x.Item2 == null ? string.Empty : x.Item2.ToString();
      Dictionary<string, object> dictionary1 = new Dictionary<string, object>();
      int num;
      if (sender.ParamBackup != null && sender.ParamBackup.IsStoreTotal)
      {
        dictionary1.Add("StoreCodeIn", (object) sender.ParamBackup.StoreCodeIn);
        dictionary1.Add("StoreNameIn", (object) sender.ParamBackup.StoreNameIn);
      }
      else
      {
        Dictionary<string, object> dictionary2 = dictionary1;
        num = byDayDateSupplier.sbd_StoreCode;
        string str2 = num.ToString();
        dictionary2.Add("StoreCodeIn", (object) str2);
        dictionary1.Add("StoreNameIn", (object) byDayDateSupplier.si_StoreName);
      }
      if (!(str1 == "Store"))
      {
        Dictionary<string, object> dictionary3 = dictionary1;
        num = byDayDateSupplier.sbd_Supplier;
        string str3 = num.ToString();
        dictionary3.Add("SupplierCodeIn", (object) str3);
        dictionary1.Add("SupplierNameIn", (object) byDayDateSupplier.su_SupplierName);
      }
      // ISSUE: explicit non-virtual call
      await __nonvirtual (sender.SendParamAfterPageAsync((IPage) sender, (ParamBase) sender.Param, (IDictionary<string, object>) dictionary1));
    }
  }
}
