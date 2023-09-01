// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Page.UniSales.Sales.Supplier.Sales.CategoryPageVM
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
  public class CategoryPageVM : SupplierPageBase<
  #nullable disable
  SaleByDayDateSupplierCategoryBot>, ISystemPage
  {
    public CategoryPageVM(IContainer container)
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
        Key = "S2_CategoryViewCode",
        IsDisplay = false
      });
    }

    public override async Task SearchAsync()
    {
      CategoryPageVM categoryPageVm = this;
      try
      {
        // ISSUE: explicit non-virtual call
        using (__nonvirtual (categoryPageVm.Job).CreateJob("검색", (string) null))
        {
          categoryPageVm.Datas.Clear();
          categoryPageVm.FooterRemark = string.Empty;
          int num;
          switch (categoryPageVm.Param.CategoryDepth.comm_TypeNo)
          {
            case 1:
              num = 4;
              break;
            case 2:
              num = 5;
              break;
            default:
              num = 6;
              break;
          }
        }
      }
      catch (Exception ex)
      {
        Log.Error(ex.Message);
        // ISSUE: explicit non-virtual call
        // ISSUE: explicit non-virtual call
        int num = (int) new CommonMsgVM(__nonvirtual (categoryPageVm.Container)).Set(__nonvirtual (categoryPageVm.MenuInfo).Title + " 오류", ex.Message).ShowDialog();
      }
    }

    public override async void NextTabColume((object, object) x)
    {
      CategoryPageVM sender = this;
      SaleByDayDateSupplierCategoryBot supplierCategoryBot = (SaleByDayDateSupplierCategoryBot) x.Item1;
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
        num = supplierCategoryBot.sbd_StoreCode;
        string str2 = num.ToString();
        dictionary2.Add("StoreCodeIn", (object) str2);
        dictionary1.Add("StoreNameIn", (object) supplierCategoryBot.si_StoreName);
      }
      switch (str1)
      {
        case "Store":
label_12:
          // ISSUE: explicit non-virtual call
          await __nonvirtual (sender.SendParamAfterPageAsync((IPage) sender, (ParamBase) sender.Param, (IDictionary<string, object>) dictionary1));
        case "Supplier":
          Dictionary<string, object> dictionary3 = dictionary1;
          num = supplierCategoryBot.sbd_Supplier;
          string str3 = num.ToString();
          dictionary3.Add("SupplierCodeIn", (object) str3);
          dictionary1.Add("SupplierNameIn", (object) supplierCategoryBot.su_SupplierName);
          goto case "Store";
        case "CategoryTop":
          Dictionary<string, object> dictionary4 = dictionary1;
          num = supplierCategoryBot.sbd_Supplier;
          string str4 = num.ToString();
          dictionary4.Add("SupplierCodeIn", (object) str4);
          dictionary1.Add("SupplierNameIn", (object) supplierCategoryBot.su_SupplierName);
          dictionary1.Add("CategoryNameIn", (object) supplierCategoryBot.ctg_lv1_Name);
          Dictionary<string, object> dictionary5 = dictionary1;
          num = supplierCategoryBot.ctg_lv1_ID;
          string str5 = num.ToString();
          dictionary5.Add("CategoryCodeInLv1", (object) str5);
          dictionary1.Add("CategoryCodeInLv2", (object) string.Empty);
          dictionary1.Add("CategoryCodeInLv3", (object) string.Empty);
          goto case "Store";
        case "CategoryMid":
          Dictionary<string, object> dictionary6 = dictionary1;
          num = supplierCategoryBot.sbd_Supplier;
          string str6 = num.ToString();
          dictionary6.Add("SupplierCodeIn", (object) str6);
          dictionary1.Add("SupplierNameIn", (object) supplierCategoryBot.su_SupplierName);
          dictionary1.Add("CategoryNameIn", (object) supplierCategoryBot.ctg_lv2_Name);
          dictionary1.Add("CategoryCodeInLv1", (object) string.Empty);
          Dictionary<string, object> dictionary7 = dictionary1;
          num = supplierCategoryBot.ctg_lv2_ID;
          string str7 = num.ToString();
          dictionary7.Add("CategoryCodeInLv2", (object) str7);
          dictionary1.Add("CategoryCodeInLv3", (object) string.Empty);
          goto case "Store";
        default:
          Dictionary<string, object> dictionary8 = dictionary1;
          num = supplierCategoryBot.sbd_Supplier;
          string str8 = num.ToString();
          dictionary8.Add("SupplierCodeIn", (object) str8);
          dictionary1.Add("SupplierNameIn", (object) supplierCategoryBot.su_SupplierName);
          if (sender.ParamBackup != null)
          {
            num = sender.ParamBackup.CategoryDepth.comm_TypeNo;
            switch (num)
            {
              case 1:
                dictionary1.Add("CategoryNameIn", (object) supplierCategoryBot.ctg_lv1_Name);
                dictionary1.Add("CategoryCodeInLv1", (object) supplierCategoryBot.ctg_lv1_ID.ToString());
                dictionary1.Add("CategoryCodeInLv2", (object) string.Empty);
                dictionary1.Add("CategoryCodeInLv3", (object) string.Empty);
                goto label_12;
              case 2:
                dictionary1.Add("CategoryNameIn", (object) supplierCategoryBot.ctg_lv2_Name);
                dictionary1.Add("CategoryCodeInLv1", (object) string.Empty);
                dictionary1.Add("CategoryCodeInLv2", (object) supplierCategoryBot.ctg_lv2_ID.ToString());
                dictionary1.Add("CategoryCodeInLv3", (object) string.Empty);
                goto label_12;
              default:
                dictionary1.Add("CategoryNameIn", (object) supplierCategoryBot.ctg_CategoryName);
                dictionary1.Add("CategoryCodeInLv1", (object) string.Empty);
                dictionary1.Add("CategoryCodeInLv2", (object) string.Empty);
                dictionary1.Add("CategoryCodeInLv3", (object) supplierCategoryBot.sbd_CategoryCode.ToString());
                goto label_12;
            }
          }
          else
            goto case "Store";
      }
    }
  }
}
