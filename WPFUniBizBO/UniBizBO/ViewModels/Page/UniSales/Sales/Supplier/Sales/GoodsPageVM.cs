// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Page.UniSales.Sales.Supplier.Sales.GoodsPageVM
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Serilog;
using StyletIoC;
using System;
using System.Linq;
using System.Threading.Tasks;
using UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay.Supplier;
using UniBizBO.Composition;
using UniBizBO.Services.Page;
using UniBizBO.ViewModels.Box;
using UniinfoNet.Windows.Wpf.DataView;


#nullable enable
namespace UniBizBO.ViewModels.Page.UniSales.Sales.Supplier.Sales
{
  public class GoodsPageVM : SupplierPageBase<
  #nullable disable
  SaleByDayDateSupplierGoods>, ISystemPage
  {
    public GoodsPageVM(IContainer container)
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
      this.DataView.CategoryViews.Add(new UniDataCategoryView()
      {
        Key = "S2_CategoryName",
        IsDisplay = false
      });
      this.DataView.CategoryViews.Add(new UniDataCategoryView()
      {
        Key = "S2_CategoryViewCode",
        IsDisplay = false
      });
      this.DataView.CategoryViews.Add(new UniDataCategoryView()
      {
        Key = "S2_GoodsEx",
        IsDisplay = false
      });
      this.DataView.CategoryViews.Add(new UniDataCategoryView()
      {
        Key = "S2_GoodsPrice",
        IsDisplay = false
      });
    }

    public override async Task SearchAsync()
    {
      GoodsPageVM goodsPageVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (goodsPageVm.Job).CreateJob("검색", (string) null))
        {
          goodsPageVm.Datas.Clear();
          goodsPageVm.FooterRemark = string.Empty;
        }
      }
      catch (Exception ex)
      {
        Log.Error(ex.Message);
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (goodsPageVm.Container)).Set(__nonvirtual (goodsPageVm.MenuInfo).Title + " 오류", ex.Message).ShowDialog();
      }
    }

    public override bool CanDataOpen(SaleByDayDateSupplierGoods item) => item != null;

    public override async void DataOpen(SaleByDayDateSupplierGoods item)
    {
      GoodsPageVM goodsPageVm = this;
      // ISSUE: explicit non-virtual call
      if (!goodsPageVm.CanDataOpen(item) || __nonvirtual (goodsPageVm.App).User.PartMenus.Where<PartMenuInfo>((Func<PartMenuInfo, bool>) (it => it.PartTableCode == 36)).ToList<PartMenuInfo>().Count == 0)
        return;
      await Task.Yield();
    }
  }
}
