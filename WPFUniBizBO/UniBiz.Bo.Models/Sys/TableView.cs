// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Sys.TableView
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using UniBiz.Bo.Models.Interface;
using UniBiz.Bo.Models.UniBase.BookmarkGoods.BookmarkGoodsGroup;
using UniBiz.Bo.Models.UniBase.BookmarkGoods.BookmarkGoodsList;
using UniBiz.Bo.Models.UniBase.Brand;
using UniBiz.Bo.Models.UniBase.Category;
using UniBiz.Bo.Models.UniBase.ColStyle;
using UniBiz.Bo.Models.UniBase.CommonCode;
using UniBiz.Bo.Models.UniBase.Dept;
using UniBiz.Bo.Models.UniBase.Employee.DataModLog;
using UniBiz.Bo.Models.UniBase.Employee.EmpActionLog;
using UniBiz.Bo.Models.UniBase.Employee.EmpAuthority;
using UniBiz.Bo.Models.UniBase.Employee.EmpImage;
using UniBiz.Bo.Models.UniBase.Employee.Employee;
using UniBiz.Bo.Models.UniBase.Eod.EodDbBackup;
using UniBiz.Bo.Models.UniBase.Eod.EodInfo;
using UniBiz.Bo.Models.UniBase.GiftCardInfo.GiftCard;
using UniBiz.Bo.Models.UniBase.GiftCardInfo.GiftCardHistory;
using UniBiz.Bo.Models.UniBase.GoodsInfo.Goods;
using UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsHistory;
using UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsImage;
using UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsOldBarcode;
using UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsPack;
using UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsStoreInfo;
using UniBiz.Bo.Models.UniBase.Maker;
using UniBiz.Bo.Models.UniBase.OuterConnAuth;
using UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenu;
using UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenuAuth;
using UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenuBookMark;
using UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenuProp;
using UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenuPropAuth;
using UniBiz.Bo.Models.UniBase.ProgOption;
using UniBiz.Bo.Models.UniBase.Store.Location;
using UniBiz.Bo.Models.UniBase.Store.StoreGroupDetail;
using UniBiz.Bo.Models.UniBase.Store.StoreGroupHeader;
using UniBiz.Bo.Models.UniBase.Store.StoreInfo;
using UniBiz.Bo.Models.UniBase.Supplier.AutoOrderConition;
using UniBiz.Bo.Models.UniBase.Supplier.RebateConditionDetail;
using UniBiz.Bo.Models.UniBase.Supplier.RebateConditionHeader;
using UniBiz.Bo.Models.UniBase.Supplier.Supplier;
using UniBiz.Bo.Models.UniBase.Supplier.SupplierAutoDeduction;
using UniBiz.Bo.Models.UniBase.Supplier.SupplierHistory;
using UniBiz.Bo.Models.UniBase.Supplier.SupplierImage;
using UniBiz.Bo.Models.UniBase.SysInfo.ErrorCode;
using UniBiz.Bo.Models.UniBase.UniSite;
using UniBiz.Bo.Models.UniCampaign.CampaignInfo.Campaign;
using UniBiz.Bo.Models.UniCampaign.CampaignInfo.CampaignGoods;
using UniBiz.Bo.Models.UniCampaign.CampaignInfo.CampaignMember;
using UniBiz.Bo.Models.UniCampaign.CampaignInfo.CampaignPromotion;
using UniBiz.Bo.Models.UniCampaign.CampaignInfo.CampaignStore;
using UniBiz.Bo.Models.UniCampaign.CampaignInfo.Coupon;
using UniBiz.Bo.Models.UniCampaign.CampaignInfo.CouponDetail;
using UniBiz.Bo.Models.UniCampaign.CampaignInfo.Promotion;
using UniBiz.Bo.Models.UniCampaign.CampaignInfo.PromotionMix;
using UniBiz.Bo.Models.UniCampaign.CampaignInfo.PromotionStore;
using UniBiz.Bo.Models.UniCampaign.CampaignInfo.PromotionTarget;
using UniBiz.Bo.Models.UniImages.ErrFiles;
using UniBiz.Bo.Models.UniImages.UniTemplates.Formtec;
using UniBiz.Bo.Models.UniImages.UniTemplates.Label;
using UniBiz.Bo.Models.UniMembers.Environment.MemberCalcCycle;
using UniBiz.Bo.Models.UniMembers.Environment.MemberCycleStd;
using UniBiz.Bo.Models.UniMembers.Environment.MemberGradeCalcStd;
using UniBiz.Bo.Models.UniMembers.Gift.GiftGiveHistory;
using UniBiz.Bo.Models.UniMembers.Gift.GiftItem;
using UniBiz.Bo.Models.UniMembers.History.MemberPointHistory;
using UniBiz.Bo.Models.UniMembers.Info.Member;
using UniBiz.Bo.Models.UniMembers.Info.MemberCard;
using UniBiz.Bo.Models.UniMembers.Info.MemberGrade;
using UniBiz.Bo.Models.UniMembers.Info.MemberGroup;
using UniBiz.Bo.Models.UniMembers.Info.MemberLinkSupplier;
using UniBiz.Bo.Models.UniMembers.Info.MemberType;
using UniBiz.Bo.Models.UniMembers.Info.MemberTypeHistory;
using UniBiz.Bo.Models.UniMembers.Summary.MemberDaySum;
using UniBiz.Bo.Models.UniMembers.Summary.MemberGoodsSum;
using UniBiz.Bo.Models.UniMembers.Summary.MemberPointExtinction;
using UniBiz.Bo.Models.UniSales.SalesBy.GoalBy.GoalByCategory;
using UniBiz.Bo.Models.UniSales.SalesBy.GoalBy.GoalByDept;
using UniBiz.Bo.Models.UniSales.SalesBy.SalesByDay;
using UniBiz.Bo.Models.UniSales.SalesBy.SalesByTime;
using UniBiz.Bo.Models.UniSales.WeatherBy.WeatherByDay;
using UniBiz.Bo.Models.UniSales.WeatherBy.WeatherByTime;
using UniBiz.Bo.Models.UniStock.Inventory;
using UniBiz.Bo.Models.UniStock.Inventory.InventoryWork;
using UniBiz.Bo.Models.UniStock.Payment.Statement;
using UniBiz.Bo.Models.UniStock.Payment.Summary;
using UniBiz.Bo.Models.UniStock.Profit.ProfitLossSummary;
using UniBiz.Bo.Models.UniStock.Profit.ProfitLossWork;
using UniBiz.Bo.Models.UniStock.Statement;
using UniBizUtil.Util;

namespace UniBiz.Bo.Models.Sys
{
  public class TableView : TTable<TableView>
  {
    public static IList<TableView> SelectList()
    {
      IList<TableView> tableViewList = (IList<TableView>) new List<TableView>();
      int num = 1;
      foreach (TableCodeType tableCodeType in Enum.GetValues(typeof (TableCodeType)))
      {
        TableView tableView1 = new TableView();
        tableView1.tb_code = tableCodeType;
        tableView1.row_number = num++;
        TableView tableView2 = tableView1;
        tableViewList.Add(tableView2);
      }
      return tableViewList;
    }

    public IList<TableView> CreateTableList(TableCreate p_data)
    {
      IList<TableView> tableList = (IList<TableView>) new List<TableView>();
      bool flag = false;
      try
      {
        if (p_data.tc_is_re_table_with_data)
        {
          foreach (TableView tableView in (IEnumerable<TableView>) p_data.lt_table)
          {
            switch (tableView.tb_code)
            {
              case TableCodeType.EmpImage:
                if (!flag)
                {
                  flag = p_data.tc_is_re_table_with_data;
                  continue;
                }
                continue;
              case TableCodeType.ProgMenu:
                if (p_data.lt_table.Count > 1)
                  throw new Exception(string.Format("{0}({1}) 데이터 유지 재생성 작업은 단일 모드만 가능합니다", (object) tableView.tb_code.ToDescription(), (object) tableView.tb_code));
                if (!flag)
                {
                  flag = p_data.tc_is_re_table_with_data;
                  continue;
                }
                continue;
              case TableCodeType.ProgMenuProp:
                if (p_data.lt_table.Count > 1)
                  throw new Exception(string.Format("{0}({1}) 데이터 유지 재생성 작업은 단일 모드만 가능합니다", (object) tableView.tb_code.ToDescription(), (object) tableView.tb_code));
                if (!flag)
                {
                  flag = p_data.tc_is_re_table_with_data;
                  continue;
                }
                continue;
              case TableCodeType.SupplierImage:
                if (!flag)
                {
                  flag = p_data.tc_is_re_table_with_data;
                  continue;
                }
                continue;
              case TableCodeType.Goods:
                if (p_data.lt_table.Count > 1)
                  throw new Exception(string.Format("{0}({1}) 데이터 유지 재생성 작업은 단일 모드만 가능합니다", (object) tableView.tb_code.ToDescription(), (object) tableView.tb_code));
                if (!flag)
                {
                  flag = p_data.tc_is_re_table_with_data;
                  continue;
                }
                continue;
              case TableCodeType.GoodsHistory:
                if (p_data.lt_table.Count > 1)
                  throw new Exception(string.Format("{0}({1}) 데이터 유지 재생성 작업은 단일 모드만 가능합니다", (object) tableView.tb_code.ToDescription(), (object) tableView.tb_code));
                if (!flag)
                {
                  flag = p_data.tc_is_re_table_with_data;
                  continue;
                }
                continue;
              case TableCodeType.GoodsOldBarcode:
                if (p_data.lt_table.Count > 1)
                  throw new Exception(string.Format("{0}({1}) 데이터 유지 재생성 작업은 단일 모드만 가능합니다", (object) tableView.tb_code.ToDescription(), (object) tableView.tb_code));
                if (!flag)
                {
                  flag = p_data.tc_is_re_table_with_data;
                  continue;
                }
                continue;
              case TableCodeType.GoodsPack:
                if (p_data.lt_table.Count > 1)
                  throw new Exception(string.Format("{0}({1}) 데이터 유지 재생성 작업은 단일 모드만 가능합니다", (object) tableView.tb_code.ToDescription(), (object) tableView.tb_code));
                if (!flag)
                {
                  flag = p_data.tc_is_re_table_with_data;
                  continue;
                }
                continue;
              case TableCodeType.GoodsStoreInfo:
                if (p_data.lt_table.Count > 1)
                  throw new Exception(string.Format("{0}({1}) 데이터 유지 재생성 작업은 단일 모드만 가능합니다", (object) tableView.tb_code.ToDescription(), (object) tableView.tb_code));
                if (!flag)
                {
                  flag = p_data.tc_is_re_table_with_data;
                  continue;
                }
                continue;
              case TableCodeType.GoodsImage:
                if (p_data.lt_table.Count > 1)
                  throw new Exception(string.Format("{0}({1}) 데이터 유지 재생성 작업은 단일 모드만 가능합니다", (object) tableView.tb_code.ToDescription(), (object) tableView.tb_code));
                if (!flag)
                {
                  flag = p_data.tc_is_re_table_with_data;
                  continue;
                }
                continue;
              case TableCodeType.ProfitLossSummary:
                if (p_data.lt_table.Count > 1)
                  throw new Exception(string.Format("{0}({1}) 데이터 유지 재생성 작업은 단일 모드만 가능합니다", (object) tableView.tb_code.ToDescription(), (object) tableView.tb_code));
                if (!flag)
                {
                  flag = p_data.tc_is_re_table_with_data;
                  continue;
                }
                continue;
              case TableCodeType.StatementHeader:
                if (p_data.lt_table.Count > 1)
                  throw new Exception(string.Format("{0}({1}) 데이터 유지 재생성 작업은 단일 모드만 가능합니다", (object) tableView.tb_code.ToDescription(), (object) tableView.tb_code));
                if (!flag)
                {
                  flag = p_data.tc_is_re_table_with_data;
                  continue;
                }
                continue;
              case TableCodeType.StatementDetail:
                if (p_data.lt_table.Count > 1)
                  throw new Exception(string.Format("{0}({1}) 데이터 유지 재생성 작업은 단일 모드만 가능합니다", (object) tableView.tb_code.ToDescription(), (object) tableView.tb_code));
                if (!flag)
                {
                  flag = p_data.tc_is_re_table_with_data;
                  continue;
                }
                continue;
              case TableCodeType.SalesByDay:
                if (p_data.lt_table.Count > 1)
                  throw new Exception(string.Format("{0}({1}) 데이터 유지 재생성 작업은 단일 모드만 가능합니다", (object) tableView.tb_code.ToDescription(), (object) tableView.tb_code));
                if (!flag)
                {
                  flag = p_data.tc_is_re_table_with_data;
                  continue;
                }
                continue;
              case TableCodeType.SalesByTime:
                if (p_data.lt_table.Count > 1)
                  throw new Exception(string.Format("{0}({1}) 데이터 유지 재생성 작업은 단일 모드만 가능합니다", (object) tableView.tb_code.ToDescription(), (object) tableView.tb_code));
                if (!flag)
                {
                  flag = p_data.tc_is_re_table_with_data;
                  continue;
                }
                continue;
              case TableCodeType.LabelTemplates:
                if (p_data.lt_table.Count > 1)
                  throw new Exception(string.Format("{0}({1}) 데이터 유지 재생성 작업은 단일 모드만 가능합니다", (object) tableView.tb_code.ToDescription(), (object) tableView.tb_code));
                if (!flag)
                {
                  flag = p_data.tc_is_re_table_with_data;
                  continue;
                }
                continue;
              case TableCodeType.FormtecTemplates:
                if (p_data.lt_table.Count > 1)
                  throw new Exception(string.Format("{0}({1}) 데이터 유지 재생성 작업은 단일 모드만 가능합니다", (object) tableView.tb_code.ToDescription(), (object) tableView.tb_code));
                if (!flag)
                {
                  flag = p_data.tc_is_re_table_with_data;
                  continue;
                }
                continue;
              default:
                continue;
            }
          }
        }
        if (!flag)
          this.OleDB.BeginTransaction();
        foreach (TableView p_table in (IEnumerable<TableView>) p_data.lt_table)
        {
          p_table.SetAdoDatabase(this.OleDB);
          tableList.Add(this.CreateTable(p_table, p_data.tc_is_table, p_data.tc_is_re_table, p_data.tc_is_data, p_data.tc_is_re_table_with_data, p_data.tc_type, p_data.tc_siteid));
        }
        if (!flag)
          this.OleDB.CommitTransaction();
        return tableList;
      }
      catch (Exception ex)
      {
        if (!flag && this.OleDB != null)
          this.OleDB.RollbackTransaction();
        throw new Exception(" 생성 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
    }

    public TableView CreateTable(
      TableView p_table,
      bool p_IsCreate,
      bool p_IsReCreateTable,
      bool p_IsDataInsert,
      bool p_IsRecreateTableWithData,
      int p_type,
      long p_siteid)
    {
      switch (p_table.tb_code)
      {
        case TableCodeType.UniSite:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new UniSiteCreate(), DBHelper.UNI_BASE, p_siteid);
          break;
        case TableCodeType.CommonCode:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new CommonCodeCreate(), DBHelper.UNI_BASE, p_siteid);
          break;
        case TableCodeType.StoreInfo:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new StoreInfoCreate(), DBHelper.UNI_BASE, p_siteid);
          break;
        case TableCodeType.StoreGroupHeader:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new StoreGroupHeaderCreate(), DBHelper.UNI_BASE, p_siteid);
          break;
        case TableCodeType.StoreGroupDetail:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new StoreGroupDetailCreate(), DBHelper.UNI_BASE, p_siteid);
          break;
        case TableCodeType.Employee:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new EmployeeCreate(), DBHelper.UNI_BASE, p_siteid);
          break;
        case TableCodeType.EmpImage:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new EmpImageCreate(), DBHelper.UNI_BASE, p_siteid);
          break;
        case TableCodeType.EmpAuthority:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new EmpAuthorityCreate(), DBHelper.UNI_BASE, p_siteid);
          break;
        case TableCodeType.ProgMenu:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new ProgMenuCreate(), DBHelper.UNI_BASE, p_siteid);
          break;
        case TableCodeType.ProgMenuAuth:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new ProgMenuAuthCreate(), DBHelper.UNI_BASE, p_siteid);
          break;
        case TableCodeType.ProgMenuProp:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new ProgMenuPropCreate(), DBHelper.UNI_BASE, p_siteid);
          break;
        case TableCodeType.ProgMenuPropAuth:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new ProgMenuPropAuthCreate(), DBHelper.UNI_BASE, p_siteid);
          break;
        case TableCodeType.ProgMenuBookMark:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new ProgMenuBookMarkCreate(), DBHelper.UNI_BASE, p_siteid);
          break;
        case TableCodeType.OuterConnAuth:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new OuterConnAuthCreate(), DBHelper.UNI_BASE, p_siteid);
          break;
        case TableCodeType.Maker:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new MakerCreate(), DBHelper.UNI_BASE, p_siteid);
          break;
        case TableCodeType.Supplier:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new SupplierCreate(), DBHelper.UNI_BASE, p_siteid);
          break;
        case TableCodeType.SupplierImage:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new SupplierImageCreate(), DBHelper.UNI_BASE, p_siteid);
          break;
        case TableCodeType.SupplierHistory:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new SupplierHistoryCreate(), DBHelper.UNI_BASE, p_siteid);
          break;
        case TableCodeType.SupplierAutoDeduction:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new SupplierAutoDeductionCreate(), DBHelper.UNI_BASE, p_siteid);
          break;
        case TableCodeType.RebateConditionHeader:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new RebateConditionHeaderCreate(), DBHelper.UNI_BASE, p_siteid);
          break;
        case TableCodeType.RebateConditionDetail:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new RebateConditionDetailCreate(), DBHelper.UNI_BASE, p_siteid);
          break;
        case TableCodeType.AutoOrderConition:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new AutoOrderConitionCreate(), DBHelper.UNI_BASE, p_siteid);
          break;
        case TableCodeType.Dept:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new DeptCreate(), DBHelper.UNI_BASE, p_siteid);
          break;
        case TableCodeType.Brand:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new BrandCreate(), DBHelper.UNI_BASE, p_siteid);
          break;
        case TableCodeType.Category:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new CategoryCreate(), DBHelper.UNI_BASE, p_siteid);
          break;
        case TableCodeType.Goods:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new GoodsCreate(), DBHelper.UNI_BASE, p_siteid);
          break;
        case TableCodeType.GoodsHistory:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new GoodsHistoryCreate(), DBHelper.UNI_BASE, p_siteid);
          break;
        case TableCodeType.GoodsOldBarcode:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new GoodsOldBarcodeCreate(), DBHelper.UNI_BASE, p_siteid);
          break;
        case TableCodeType.GoodsPack:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new GoodsPackCreate(), DBHelper.UNI_BASE, p_siteid);
          break;
        case TableCodeType.GoodsStoreInfo:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new GoodsStoreInfoCreate(), DBHelper.UNI_BASE, p_siteid);
          break;
        case TableCodeType.GoodsImage:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new GoodsImageCreate(), DBHelper.UNI_IMAGES, p_siteid);
          break;
        case TableCodeType.BookmarkGoodsGroup:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new BookmarkGoodsGroupCreate(), DBHelper.UNI_BASE, p_siteid);
          break;
        case TableCodeType.BookmarkGoodsList:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new BookmarkGoodsListCreate(), DBHelper.UNI_BASE, p_siteid);
          break;
        case TableCodeType.GiftCard:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new GiftCardCreate(), DBHelper.UNI_BASE, p_siteid);
          break;
        case TableCodeType.GiftCardHistory:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new GiftCardHistoryCreate(), DBHelper.UNI_BASE, p_siteid);
          break;
        case TableCodeType.ProgOption:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new ProgOptionCreate(), DBHelper.UNI_BASE, p_siteid);
          break;
        case TableCodeType.EodInfo:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new EodInfoCreate(), DBHelper.UNI_BASE, p_siteid);
          break;
        case TableCodeType.EodDbBackup:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new EodDbBackupCreate(), DBHelper.UNI_BASE, p_siteid);
          break;
        case TableCodeType.ColStyle:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new ColStyleCreate(), DBHelper.UNI_BASE, p_siteid);
          break;
        case TableCodeType.ErrorCode:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new ErrorCodeCreate(), DBHelper.UNI_BASE, p_siteid);
          break;
        case TableCodeType.Location:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new LocationCreate(), DBHelper.UNI_BASE, p_siteid);
          break;
        case TableCodeType.ProfitLossWorkCnt:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new ProfitLossWorkCntCreate(), DBHelper.UNI_STOCK, p_siteid);
          break;
        case TableCodeType.ProfitLossWorkCntLog:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new ProfitLossWorkCntLogCreate(), DBHelper.UNI_STOCK, p_siteid);
          break;
        case TableCodeType.ProfitLossSummary:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new ProfitLossSummaryCreate(), DBHelper.UNI_STOCK, p_siteid);
          break;
        case TableCodeType.InventoryHeader:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new InventoryHeaderCreate(), DBHelper.UNI_STOCK, p_siteid);
          break;
        case TableCodeType.InventoryDetail:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new InventoryDetailCreate(), DBHelper.UNI_STOCK, p_siteid);
          break;
        case TableCodeType.InventoryWorkCnt:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new InventoryWorkCntCreate(), DBHelper.UNI_STOCK, p_siteid);
          break;
        case TableCodeType.InventoryWorkCntLog:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new InventoryWorkCntLogCreate(), DBHelper.UNI_STOCK, p_siteid);
          break;
        case TableCodeType.StatementHeader:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new StatementHeaderCreate(), DBHelper.UNI_STOCK, p_siteid);
          break;
        case TableCodeType.StatementDetail:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new StatementDetailCreate(), DBHelper.UNI_STOCK, p_siteid);
          break;
        case TableCodeType.MoveInOutLink:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new MoveInOutLinkCreate(), DBHelper.UNI_STOCK, p_siteid);
          break;
        case TableCodeType.PaymentMonth:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new PaymentMonthCreate(), DBHelper.UNI_STOCK, p_siteid);
          break;
        case TableCodeType.Payment:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new PaymentCreate(), DBHelper.UNI_STOCK, p_siteid);
          break;
        case TableCodeType.PaymentDetail:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new PaymentDetailCreate(), DBHelper.UNI_STOCK, p_siteid);
          break;
        case TableCodeType.GoalByDept:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new GoalByDeptCreate(), DBHelper.UNI_SALES, p_siteid);
          break;
        case TableCodeType.GoalByCategory:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new GoalByCategoryCreate(), DBHelper.UNI_SALES, p_siteid);
          break;
        case TableCodeType.WeatherByDay:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new WeatherByDayCreate(), DBHelper.UNI_SALES, p_siteid);
          break;
        case TableCodeType.WeatherByTime:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new WeatherByTimeCreate(), DBHelper.UNI_SALES, p_siteid);
          break;
        case TableCodeType.SalesByDay:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new SalesByDayCreate(), DBHelper.UNI_SALES, p_siteid);
          break;
        case TableCodeType.SalesByTime:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new SalesByTimeCreate(), DBHelper.UNI_SALES, p_siteid);
          break;
        case TableCodeType.MemberType:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new MemberTypeCreate(), DBHelper.UNI_MEMBERS, p_siteid);
          break;
        case TableCodeType.MemberTypeHistory:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new MemberTypeHistoryCreate(), DBHelper.UNI_MEMBERS, p_siteid);
          break;
        case TableCodeType.MemberGroup:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new MemberGroupCreate(), DBHelper.UNI_MEMBERS, p_siteid);
          break;
        case TableCodeType.Member:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new MemberCreate(), DBHelper.UNI_MEMBERS, p_siteid);
          break;
        case TableCodeType.MemberCard:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new MemberCardCreate(), DBHelper.UNI_MEMBERS, p_siteid);
          break;
        case TableCodeType.MemberGrade:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new MemberGradeCreate(), DBHelper.UNI_MEMBERS, p_siteid);
          break;
        case TableCodeType.MemberCalcCycle:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new MemberCalcCycleCreate(), DBHelper.UNI_MEMBERS, p_siteid);
          break;
        case TableCodeType.MemberCycleStd:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new MemberCycleStdCreate(), DBHelper.UNI_MEMBERS, p_siteid);
          break;
        case TableCodeType.MemberGradeCalcStd:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new MemberGradeCalcStdCreate(), DBHelper.UNI_MEMBERS, p_siteid);
          break;
        case TableCodeType.MemberPointExtinction:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new MemberPointExtinctionCreate(), DBHelper.UNI_MEMBERS, p_siteid);
          break;
        case TableCodeType.MemberDaySum:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new MemberDaySumCreate(), DBHelper.UNI_MEMBERS, p_siteid);
          break;
        case TableCodeType.MemberGoodsSum:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new MemberGoodsSumCreate(), DBHelper.UNI_MEMBERS, p_siteid);
          break;
        case TableCodeType.MemberPointHistory:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new MemberPointHistoryCreate(), DBHelper.UNI_MEMBERS, p_siteid);
          break;
        case TableCodeType.GiftItem:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new GiftItemCreate(), DBHelper.UNI_MEMBERS, p_siteid);
          break;
        case TableCodeType.GiftGiveHistory:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new GiftGiveHistoryCreate(), DBHelper.UNI_MEMBERS, p_siteid);
          break;
        case TableCodeType.MemberLinkSupplier:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new MemberLinkSupplierCreate(), DBHelper.UNI_MEMBERS, p_siteid);
          break;
        case TableCodeType.EmpActionLog:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new EmpActionLogCreate(), DBHelper.UNI_BASE, p_siteid);
          break;
        case TableCodeType.DataModLog:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new DataModLogCreate(), DBHelper.UNI_BASE, p_siteid);
          break;
        case TableCodeType.Campaign:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new CampaignCreate(), DBHelper.UNI_CAMPANIGN, p_siteid);
          break;
        case TableCodeType.CampaignPromotion:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new CampaignPromotionCreate(), DBHelper.UNI_CAMPANIGN, p_siteid);
          break;
        case TableCodeType.CampaignMember:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new CampaignMemberCreate(), DBHelper.UNI_CAMPANIGN, p_siteid);
          break;
        case TableCodeType.CampaignGoods:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new CampaignGoodsCreate(), DBHelper.UNI_CAMPANIGN, p_siteid);
          break;
        case TableCodeType.CampaignStore:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new CampaignStoreCreate(), DBHelper.UNI_CAMPANIGN, p_siteid);
          break;
        case TableCodeType.Promotion:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new PromotionCreate(), DBHelper.UNI_CAMPANIGN, p_siteid);
          break;
        case TableCodeType.PromotionStore:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new PromotionStoreCreate(), DBHelper.UNI_CAMPANIGN, p_siteid);
          break;
        case TableCodeType.PromotionTarget:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new PromotionTargetCreate(), DBHelper.UNI_CAMPANIGN, p_siteid);
          break;
        case TableCodeType.PromotionMix:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new PromotionMixCreate(), DBHelper.UNI_CAMPANIGN, p_siteid);
          break;
        case TableCodeType.Coupon:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new CouponCreate(), DBHelper.UNI_CAMPANIGN, p_siteid);
          break;
        case TableCodeType.CouponDetail:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new CouponDetailCreate(), DBHelper.UNI_CAMPANIGN, p_siteid);
          break;
        case TableCodeType.ErrFiles:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new ErrFilesCreate(), DBHelper.UNI_IMAGES, p_siteid);
          break;
        case TableCodeType.LabelTemplates:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new LabelTemplatesCreate(), DBHelper.UNI_IMAGES, p_siteid);
          break;
        case TableCodeType.LabelTemplateCols:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new LabelTemplateColsCreate(), DBHelper.UNI_IMAGES, p_siteid);
          break;
        case TableCodeType.FormtecTemplates:
          p_table = this.CreateTable(p_table, p_IsCreate, p_IsReCreateTable, p_IsDataInsert, p_IsRecreateTableWithData, (ICreateTable) new FormtecTemplatesCreate(), DBHelper.UNI_IMAGES, p_siteid);
          break;
        default:
          p_table.tb_message = "미반영";
          break;
      }
      return p_table;
    }

    public TableView CreateTable(
      TableView p_table,
      bool p_IsCreate,
      bool p_IsReCreateTable,
      bool p_IsDataInsert,
      bool p_IsRecreateTableWithData,
      ICreateTable p_ITable,
      string p_db_category,
      long p_siteid = 0)
    {
      try
      {
        bool flag = TTable.IsTable(this.OleDB, p_db_category, p_table.tb_TableStr);
        p_ITable.SetAdoDatabase(this.OleDB);
        if (flag & p_IsRecreateTableWithData)
        {
          p_ITable.ReCreateTable();
          p_table.tb_message = "RECREATE WITH DATA |";
          p_table.tb_status = 2;
        }
        else
        {
          if (flag & p_IsReCreateTable)
          {
            p_ITable.DropTable();
            p_table.tb_message = "DROP |";
            p_table.tb_status = 2;
          }
          if (p_IsReCreateTable)
          {
            p_ITable.CreateTable();
            p_ITable.CreateTableComment(p_db_category);
            p_table.tb_message += "CREATE |";
            if (p_table.tb_status != 2)
              p_table.tb_status = 1;
          }
          else if (p_IsCreate)
          {
            if (flag)
            {
              TableView tableView = p_table;
              tableView.tb_message = tableView.tb_message + "중복된 테이블 |" + p_table.tb_TableStr + "|";
              p_table.tb_status = 0;
              return p_table;
            }
            p_ITable.CreateTable();
            p_ITable.CreateTableComment(p_db_category);
            p_table.tb_message += "CREATE |";
            if (p_table.tb_status != 2)
              p_table.tb_status = 1;
          }
        }
        if (!p_IsDataInsert || p_ITable.InitTable())
          return p_table;
        p_table.tb_message += "INSERT DATA ERROR! |";
        p_table.tb_status = 3;
        return p_table;
      }
      catch (Exception ex)
      {
        p_table.tb_message += ex.Message;
        p_table.tb_status = 3;
      }
      return p_table;
    }
  }
}
