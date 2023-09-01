// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniMembers.Inq.BestWorst.MemberInqBestWorstBasic
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using Serilog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UniBiz.Bo.Models.Converter;
using UniBiz.Bo.Models.TableInfo;
using UniBiz.Bo.Models.UniBase.GoodsInfo.Goods;
using UniBiz.Bo.Models.UniBase.GoodsInfo.GoodsHistory;
using UniBiz.Bo.Models.UniBase.Store.StoreInfo;
using UniBiz.Bo.Models.UniMembers.Info.Member;
using UniBizUtil.Util;
using UniOleDbLib;

namespace UniBiz.Bo.Models.UniMembers.Inq.BestWorst
{
  public class MemberInqBestWorstBasic : UbModelBase<MemberInqBestWorstBasic>
  {
    private int _mibwb_Code;
    private long _mibwb_SiteID;
    private string _mibwb_CodeName;
    private double _mibwb_SaleQty;
    private double _mibwb_SaleQtyRate;
    private double _mibwb_SaleAmt;
    private double _mibwb_SaleAmtRate;
    private double _mibwb_EikAmt;
    private double _mibwb_EikAmtRate;
    private double _mibwb_BuyCnt;
    private double _mibwb_BuyCntRate;
    private double _mibwb_BuyPrice;
    private double _mibwb_BuyPriceRate;
    private double _mibwb_MbrSaleAmt;
    private double _mibwb_MbrSaleAmtRate;
    private double _mibwb_MbrEikAmt;
    private double _mibwb_MbrEikAmtRate;
    private double _mibwb_MbrBuyCnt;
    private double _mibwb_MbrBuyCntRate;
    private double _mibwb_MbrBuyPrice;
    private double _mibwb_MbrBuyPriceRate;
    private double _mibwb_MbrRate;

    public override object _Key => (object) new object[1]
    {
      (object) this.mibwb_Code
    };

    public int mibwb_Code
    {
      get => this._mibwb_Code;
      set
      {
        this._mibwb_Code = value;
        this.Changed(nameof (mibwb_Code));
        this.Changed("mibwb_CodeDesc");
      }
    }

    public string mibwb_CodeDesc => this.mibwb_Code != 0 ? MemberInqConverter.ToMemberInqSelectCodeGoods(this.mibwb_Code).ToDescription() : string.Empty;

    public long mibwb_SiteID
    {
      get => this._mibwb_SiteID;
      set
      {
        this._mibwb_SiteID = value;
        this.Changed(nameof (mibwb_SiteID));
      }
    }

    public string mibwb_CodeName
    {
      get => this._mibwb_CodeName;
      set
      {
        this._mibwb_CodeName = value;
        this.Changed(nameof (mibwb_CodeName));
      }
    }

    public double mibwb_SaleQty
    {
      get => this._mibwb_SaleQty;
      set
      {
        this._mibwb_SaleQty = value;
        this.Changed(nameof (mibwb_SaleQty));
      }
    }

    public double mibwb_SaleQtyRate
    {
      get => this._mibwb_SaleQtyRate;
      set
      {
        this._mibwb_SaleQtyRate = value;
        this.Changed(nameof (mibwb_SaleQtyRate));
      }
    }

    public double mibwb_SaleAmt
    {
      get => this._mibwb_SaleAmt;
      set
      {
        this._mibwb_SaleAmt = value;
        this.Changed(nameof (mibwb_SaleAmt));
      }
    }

    public double mibwb_SaleAmtRate
    {
      get => this._mibwb_SaleAmtRate;
      set
      {
        this._mibwb_SaleAmtRate = value;
        this.Changed(nameof (mibwb_SaleAmtRate));
      }
    }

    public double mibwb_EikAmt
    {
      get => this._mibwb_EikAmt;
      set
      {
        this._mibwb_EikAmt = value;
        this.Changed(nameof (mibwb_EikAmt));
      }
    }

    public double mibwb_EikAmtRate
    {
      get => this._mibwb_EikAmtRate;
      set
      {
        this._mibwb_EikAmtRate = value;
        this.Changed(nameof (mibwb_EikAmtRate));
      }
    }

    public double mibwb_BuyCnt
    {
      get => this._mibwb_BuyCnt;
      set
      {
        this._mibwb_BuyCnt = value;
        this.Changed(nameof (mibwb_BuyCnt));
      }
    }

    public double mibwb_BuyCntRate
    {
      get => this._mibwb_BuyCntRate;
      set
      {
        this._mibwb_BuyCntRate = value;
        this.Changed(nameof (mibwb_BuyCntRate));
      }
    }

    public double mibwb_BuyPrice
    {
      get => this._mibwb_BuyPrice;
      set
      {
        this._mibwb_BuyPrice = value;
        this.Changed(nameof (mibwb_BuyPrice));
      }
    }

    public double mibwb_BuyPriceRate
    {
      get => this._mibwb_BuyPriceRate;
      set
      {
        this._mibwb_BuyPriceRate = value;
        this.Changed(nameof (mibwb_BuyPriceRate));
      }
    }

    public double mibwb_MbrSaleAmt
    {
      get => this._mibwb_MbrSaleAmt;
      set
      {
        this._mibwb_MbrSaleAmt = value;
        this.Changed(nameof (mibwb_MbrSaleAmt));
      }
    }

    public double mibwb_MbrSaleAmtRate
    {
      get => this._mibwb_MbrSaleAmtRate;
      set
      {
        this._mibwb_MbrSaleAmtRate = value;
        this.Changed(nameof (mibwb_MbrSaleAmtRate));
      }
    }

    public double mibwb_MbrEikAmt
    {
      get => this._mibwb_MbrEikAmt;
      set
      {
        this._mibwb_MbrEikAmt = value;
        this.Changed(nameof (mibwb_MbrEikAmt));
      }
    }

    public double mibwb_MbrEikAmtRate
    {
      get => this._mibwb_MbrEikAmtRate;
      set
      {
        this._mibwb_MbrEikAmtRate = value;
        this.Changed(nameof (mibwb_MbrEikAmtRate));
      }
    }

    public double mibwb_MbrBuyCnt
    {
      get => this._mibwb_MbrBuyCnt;
      set
      {
        this._mibwb_MbrBuyCnt = value;
        this.Changed(nameof (mibwb_MbrBuyCnt));
      }
    }

    public double mibwb_MbrBuyCntRate
    {
      get => this._mibwb_MbrBuyCntRate;
      set
      {
        this._mibwb_MbrBuyCntRate = value;
        this.Changed(nameof (mibwb_MbrBuyCntRate));
      }
    }

    public double mibwb_MbrBuyPrice
    {
      get => this._mibwb_MbrBuyPrice;
      set
      {
        this._mibwb_MbrBuyPrice = value;
        this.Changed(nameof (mibwb_MbrBuyPrice));
      }
    }

    public double mibwb_MbrBuyPriceRate
    {
      get => this._mibwb_MbrBuyPriceRate;
      set
      {
        this._mibwb_MbrBuyPriceRate = value;
        this.Changed(nameof (mibwb_MbrBuyPriceRate));
      }
    }

    public double mibwb_MbrRate
    {
      get => this._mibwb_MbrRate;
      set
      {
        this._mibwb_MbrRate = value;
        this.Changed(nameof (mibwb_MbrRate));
      }
    }

    public override Dictionary<string, TTableColumn> ToColumnInfo()
    {
      Dictionary<string, TTableColumn> columnInfo = base.ToColumnInfo();
      columnInfo.Add("mibwb_Code", new TTableColumn()
      {
        tc_orgin_name = "mibwb_Code",
        tc_trans_name = "조회코드"
      });
      columnInfo.Add("mibwb_SiteID", new TTableColumn()
      {
        tc_orgin_name = "mibwb_SiteID",
        tc_trans_name = "싸이트"
      });
      columnInfo.Add("mibwb_CodeName", new TTableColumn()
      {
        tc_orgin_name = "mibwb_CodeName",
        tc_trans_name = "코드명"
      });
      columnInfo.Add("mibwb_SaleQty", new TTableColumn()
      {
        tc_orgin_name = "mibwb_SaleQty",
        tc_trans_name = "수량",
        tc_parents_name = "매출"
      });
      columnInfo.Add("mibwb_SaleQtyRate", new TTableColumn()
      {
        tc_orgin_name = "mibwb_SaleQtyRate",
        tc_trans_name = "수량구성비",
        tc_parents_name = "매출"
      });
      columnInfo.Add("mibwb_SaleAmt", new TTableColumn()
      {
        tc_orgin_name = "mibwb_SaleAmt",
        tc_trans_name = "금액",
        tc_parents_name = "매출"
      });
      columnInfo.Add("mibwb_SaleAmtRate", new TTableColumn()
      {
        tc_orgin_name = "mibwb_SaleAmtRate",
        tc_trans_name = "금액구성비",
        tc_parents_name = "매출"
      });
      columnInfo.Add("mibwb_EikAmt", new TTableColumn()
      {
        tc_orgin_name = "mibwb_EikAmt",
        tc_trans_name = "이익액",
        tc_parents_name = "매출"
      });
      columnInfo.Add("mibwb_EikAmtRate", new TTableColumn()
      {
        tc_orgin_name = "mibwb_EikAmtRate",
        tc_trans_name = "이익액구성비",
        tc_parents_name = "매출"
      });
      columnInfo.Add("mibwb_BuyCnt", new TTableColumn()
      {
        tc_orgin_name = "mibwb_BuyCnt",
        tc_trans_name = "구매횟수",
        tc_parents_name = "구매"
      });
      columnInfo.Add("mibwb_BuyCntRate", new TTableColumn()
      {
        tc_orgin_name = "mibwb_BuyCntRate",
        tc_trans_name = "구매횟수구성비",
        tc_parents_name = "구매"
      });
      columnInfo.Add("mibwb_BuyPrice", new TTableColumn()
      {
        tc_orgin_name = "mibwb_BuyPrice",
        tc_trans_name = "구매단가",
        tc_parents_name = "구매"
      });
      columnInfo.Add("mibwb_BuyPriceRate", new TTableColumn()
      {
        tc_orgin_name = "mibwb_BuyPriceRate",
        tc_trans_name = "구매단가구성비",
        tc_parents_name = "구매"
      });
      columnInfo.Add("mibwb_MbrSaleAmt", new TTableColumn()
      {
        tc_orgin_name = "mibwb_MbrSaleAmt",
        tc_trans_name = "회원금액",
        tc_parents_name = TableCodeType.Member.ToDescription() + "매출"
      });
      columnInfo.Add("mibwb_MbrSaleAmtRate", new TTableColumn()
      {
        tc_orgin_name = "mibwb_MbrSaleAmtRate",
        tc_trans_name = "회원금액구성비",
        tc_parents_name = TableCodeType.Member.ToDescription() + "매출"
      });
      columnInfo.Add("mibwb_MbrEikAmt", new TTableColumn()
      {
        tc_orgin_name = "mibwb_MbrEikAmt",
        tc_trans_name = "회원이익액",
        tc_parents_name = TableCodeType.Member.ToDescription() + "매출"
      });
      columnInfo.Add("mibwb_MbrEikAmtRate", new TTableColumn()
      {
        tc_orgin_name = "mibwb_MbrEikAmtRate",
        tc_trans_name = "회원이익액구성비",
        tc_parents_name = TableCodeType.Member.ToDescription() + "매출"
      });
      columnInfo.Add("mibwb_MbrBuyCnt", new TTableColumn()
      {
        tc_orgin_name = "mibwb_MbrBuyCnt",
        tc_trans_name = "회원구매횟수",
        tc_parents_name = TableCodeType.Member.ToDescription() + "구매"
      });
      columnInfo.Add("mibwb_MbrBuyCntRate", new TTableColumn()
      {
        tc_orgin_name = "mibwb_MbrBuyCntRate",
        tc_trans_name = "회원구매횟수구성비",
        tc_parents_name = TableCodeType.Member.ToDescription() + "구매"
      });
      columnInfo.Add("mibwb_MbrBuyPrice", new TTableColumn()
      {
        tc_orgin_name = "mibwb_MbrBuyPrice",
        tc_trans_name = "회원구매단가",
        tc_parents_name = TableCodeType.Member.ToDescription() + "구매"
      });
      columnInfo.Add("mibwb_MbrBuyPriceRate", new TTableColumn()
      {
        tc_orgin_name = "mibwb_MbrBuyPriceRate",
        tc_trans_name = "회원구매단가구성비",
        tc_parents_name = TableCodeType.Member.ToDescription() + "구매"
      });
      columnInfo.Add("mibwb_MbrRate", new TTableColumn()
      {
        tc_orgin_name = "mibwb_MbrRate",
        tc_trans_name = "회원비중"
      });
      return columnInfo;
    }

    public override void Clear()
    {
      base.Clear();
      this.mibwb_Code = 0;
      this.mibwb_SiteID = 0L;
      this.mibwb_CodeName = string.Empty;
      this.mibwb_SaleQty = 0.0;
      this.mibwb_SaleQtyRate = 0.0;
      this.mibwb_SaleAmt = 0.0;
      this.mibwb_SaleAmtRate = 0.0;
      this.mibwb_EikAmt = 0.0;
      this.mibwb_EikAmtRate = 0.0;
      this.mibwb_BuyCnt = 0.0;
      this.mibwb_BuyCntRate = 0.0;
      this.mibwb_BuyPrice = 0.0;
      this.mibwb_BuyPriceRate = 0.0;
      this.mibwb_MbrSaleAmt = 0.0;
      this.mibwb_MbrSaleAmtRate = 0.0;
      this.mibwb_MbrEikAmt = 0.0;
      this.mibwb_MbrEikAmtRate = 0.0;
      this.mibwb_MbrBuyCnt = 0.0;
      this.mibwb_MbrBuyCntRate = 0.0;
      this.mibwb_MbrBuyPrice = 0.0;
      this.mibwb_MbrBuyPriceRate = 0.0;
      this.mibwb_MbrRate = 0.0;
    }

    protected override UbModelBase CreateClone => (UbModelBase) new MemberInqBestWorstBasic();

    public override object Clone()
    {
      MemberInqBestWorstBasic inqBestWorstBasic = base.Clone() as MemberInqBestWorstBasic;
      inqBestWorstBasic.mibwb_Code = this.mibwb_Code;
      inqBestWorstBasic.mibwb_SiteID = this.mibwb_SiteID;
      inqBestWorstBasic.mibwb_CodeName = this.mibwb_CodeName;
      inqBestWorstBasic.mibwb_SaleQty = this.mibwb_SaleQty;
      inqBestWorstBasic.mibwb_SaleQtyRate = this.mibwb_SaleQtyRate;
      inqBestWorstBasic.mibwb_SaleAmt = this.mibwb_SaleAmt;
      inqBestWorstBasic.mibwb_SaleAmtRate = this.mibwb_SaleAmtRate;
      inqBestWorstBasic.mibwb_EikAmt = this.mibwb_EikAmt;
      inqBestWorstBasic.mibwb_EikAmtRate = this.mibwb_EikAmtRate;
      inqBestWorstBasic.mibwb_BuyCnt = this.mibwb_BuyCnt;
      inqBestWorstBasic.mibwb_BuyCntRate = this.mibwb_BuyCntRate;
      inqBestWorstBasic.mibwb_BuyPrice = this.mibwb_BuyPrice;
      inqBestWorstBasic.mibwb_BuyPriceRate = this.mibwb_BuyPriceRate;
      inqBestWorstBasic.mibwb_MbrSaleAmt = this.mibwb_MbrSaleAmt;
      inqBestWorstBasic.mibwb_MbrSaleAmtRate = this.mibwb_MbrSaleAmtRate;
      inqBestWorstBasic.mibwb_MbrEikAmt = this.mibwb_MbrEikAmt;
      inqBestWorstBasic.mibwb_MbrEikAmtRate = this.mibwb_MbrEikAmtRate;
      inqBestWorstBasic.mibwb_MbrBuyCnt = this.mibwb_MbrBuyCnt;
      inqBestWorstBasic.mibwb_MbrBuyCntRate = this.mibwb_MbrBuyCntRate;
      inqBestWorstBasic.mibwb_MbrBuyPrice = this.mibwb_MbrBuyPrice;
      inqBestWorstBasic.mibwb_MbrBuyPriceRate = this.mibwb_MbrBuyPriceRate;
      inqBestWorstBasic.mibwb_MbrRate = this.mibwb_MbrRate;
      return (object) inqBestWorstBasic;
    }

    public void PutData(MemberInqBestWorstBasic pSource)
    {
      this.PutData((UbModelBase) pSource);
      this.mibwb_Code = pSource.mibwb_Code;
      this.mibwb_SiteID = pSource.mibwb_SiteID;
      this.mibwb_CodeName = pSource.mibwb_CodeName;
      this.mibwb_SaleQty = pSource.mibwb_SaleQty;
      this.mibwb_SaleQtyRate = pSource.mibwb_SaleQtyRate;
      this.mibwb_SaleAmt = pSource.mibwb_SaleAmt;
      this.mibwb_SaleAmtRate = pSource.mibwb_SaleAmtRate;
      this.mibwb_EikAmt = pSource.mibwb_EikAmt;
      this.mibwb_EikAmtRate = pSource.mibwb_EikAmtRate;
      this.mibwb_BuyCnt = pSource.mibwb_BuyCnt;
      this.mibwb_BuyCntRate = pSource.mibwb_BuyCntRate;
      this.mibwb_BuyPrice = pSource.mibwb_BuyPrice;
      this.mibwb_BuyPriceRate = pSource.mibwb_BuyPriceRate;
      this.mibwb_MbrSaleAmt = pSource.mibwb_MbrSaleAmt;
      this.mibwb_MbrSaleAmtRate = pSource.mibwb_MbrSaleAmtRate;
      this.mibwb_MbrEikAmt = pSource.mibwb_MbrEikAmt;
      this.mibwb_MbrEikAmtRate = pSource.mibwb_MbrEikAmtRate;
      this.mibwb_MbrBuyCnt = pSource.mibwb_MbrBuyCnt;
      this.mibwb_MbrBuyCntRate = pSource.mibwb_MbrBuyCntRate;
      this.mibwb_MbrBuyPrice = pSource.mibwb_MbrBuyPrice;
      this.mibwb_MbrBuyPriceRate = pSource.mibwb_MbrBuyPriceRate;
      this.mibwb_MbrRate = pSource.mibwb_MbrRate;
    }

    public override bool GetFieldValues(UniOleDbRecordset p_rs)
    {
      this.mibwb_Code = p_rs.GetFieldInt("mibwb_Code");
      this.mibwb_SiteID = p_rs.GetFieldLong("mibwb_SiteID");
      this.mibwb_CodeName = p_rs.GetFieldString("mibwb_CodeName");
      this.mibwb_SaleQty = p_rs.GetFieldDouble("mibwb_SaleQty");
      this.mibwb_SaleQtyRate = p_rs.GetFieldDouble("mibwb_SaleQtyRate");
      this.mibwb_SaleAmt = p_rs.GetFieldDouble("mibwb_SaleAmt");
      this.mibwb_SaleAmtRate = p_rs.GetFieldDouble("mibwb_SaleAmtRate");
      this.mibwb_EikAmt = p_rs.GetFieldDouble("mibwb_EikAmt");
      this.mibwb_EikAmtRate = p_rs.GetFieldDouble("mibwb_EikAmtRate");
      this.mibwb_BuyCnt = p_rs.GetFieldDouble("mibwb_BuyCnt");
      this.mibwb_BuyCntRate = p_rs.GetFieldDouble("mibwb_BuyCntRate");
      this.mibwb_BuyPrice = p_rs.GetFieldDouble("mibwb_BuyPrice");
      this.mibwb_BuyPriceRate = p_rs.GetFieldDouble("mibwb_BuyPriceRate");
      this.mibwb_MbrSaleAmt = p_rs.GetFieldDouble("mibwb_MbrSaleAmt");
      this.mibwb_MbrSaleAmtRate = p_rs.GetFieldDouble("mibwb_MbrSaleAmtRate");
      this.mibwb_MbrEikAmt = p_rs.GetFieldDouble("mibwb_MbrEikAmt");
      this.mibwb_MbrEikAmtRate = p_rs.GetFieldDouble("mibwb_MbrEikAmtRate");
      this.mibwb_MbrBuyCnt = p_rs.GetFieldDouble("mibwb_MbrBuyCnt");
      this.mibwb_MbrBuyCntRate = p_rs.GetFieldDouble("mibwb_MbrBuyCntRate");
      this.mibwb_MbrBuyPrice = p_rs.GetFieldDouble("mibwb_MbrBuyPrice");
      this.mibwb_MbrBuyPriceRate = p_rs.GetFieldDouble("mibwb_MbrBuyPriceRate");
      this.mibwb_MbrRate = p_rs.GetFieldDouble("mibwb_MbrRate");
      return true;
    }

    public async Task<IList<MemberInqBestWorstBasic>> SelectListAsync(object p_param)
    {
      MemberInqBestWorstBasic inqBestWorstBasic1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(inqBestWorstBasic1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, inqBestWorstBasic1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(inqBestWorstBasic1.GetSelectQuery(p_param)))
        {
          inqBestWorstBasic1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + inqBestWorstBasic1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          return (IList<MemberInqBestWorstBasic>) null;
        }
        IList<MemberInqBestWorstBasic> lt_list = (IList<MemberInqBestWorstBasic>) new List<MemberInqBestWorstBasic>();
        if (await rs.IsDataReadAsync())
        {
          do
          {
            MemberInqBestWorstBasic inqBestWorstBasic2 = inqBestWorstBasic1.OleDB.Create<MemberInqBestWorstBasic>();
            if (inqBestWorstBasic2.GetFieldValues(rs))
            {
              inqBestWorstBasic2.row_number = lt_list.Count + 1;
              lt_list.Add(inqBestWorstBasic2);
            }
          }
          while (await rs.IsDataReadAsync());
        }
        return lt_list;
      }
      catch (Exception ex)
      {
        throw new Exception(" 검색 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + inqBestWorstBasic1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n 내용 : " + ex.Message + "\n--------------------------------------------------------------------------------------------------\n");
      }
      finally
      {
        rs?.Close();
        db?.Close();
      }
    }

    public async IAsyncEnumerable<MemberInqBestWorstBasic> SelectEnumerableAsync(object p_param)
    {
      MemberInqBestWorstBasic inqBestWorstBasic1 = this;
      UniOleDbRecordset rs = (UniOleDbRecordset) null;
      UniOleDatabase db = (UniOleDatabase) null;
      try
      {
        db = new UniOleDatabase(inqBestWorstBasic1.OleDB.ConnectionUrl);
        rs = new UniOleDbRecordset(db, inqBestWorstBasic1.OleDB.CommandTimeout);
        if (!await rs.OpenAsync(inqBestWorstBasic1.GetSelectQuery(p_param)))
        {
          inqBestWorstBasic1.SetErrorInfo(rs.LastErrorID, "검색 오류 - SQL OPEN 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + inqBestWorstBasic1.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) rs.LastErrorID) + " 내용 : " + rs.LastErrorMessage + "\n--------------------------------------------------------------------------------------------------\n");
          // ISSUE: reference to a compiler-generated field
          this.\u003C\u003Ew__disposeMode = true;
        }
        else if (await rs.IsDataReadAsync())
        {
          int row_number = 0;
          do
          {
            MemberInqBestWorstBasic inqBestWorstBasic2 = inqBestWorstBasic1.OleDB.Create<MemberInqBestWorstBasic>();
            if (inqBestWorstBasic2.GetFieldValues(rs))
            {
              inqBestWorstBasic2.row_number = ++row_number;
              yield return inqBestWorstBasic2;
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

    public override string GetSelectWhereAnd(object p_param, bool p_isKeyWord)
    {
      StringBuilder stringBuilder = new StringBuilder(" WHERE");
      if (p_param is Hashtable hashtable)
      {
        long num = 0;
        if (hashtable.ContainsKey((object) "mibwb_SiteID") && Convert.ToInt64(hashtable[(object) "mibwb_SiteID"].ToString()) > 0L)
          num = Convert.ToInt64(hashtable[(object) "mibwb_SiteID"].ToString());
        if (hashtable.ContainsKey((object) "mibwb_Code") && Convert.ToInt32(hashtable[(object) "mibwb_Code"].ToString()) > 0)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mibwb_Code", hashtable[(object) "mibwb_Code"]));
        if (num > 0L)
          stringBuilder.Append(string.Format(" AND {0}={1}", (object) "mibwb_SiteID", (object) num));
        if (p_isKeyWord && hashtable.ContainsKey((object) "_KEY_WORD_"))
          string.IsNullOrEmpty(hashtable[(object) "_KEY_WORD_"].ToString());
      }
      return !stringBuilder.ToString().Equals(" WHERE") ? stringBuilder.Replace("WHERE AND", "WHERE").ToString() : string.Empty;
    }

    public override string GetSelectQuery(object p_param)
    {
      StringBuilder stringBuilder = new StringBuilder();
      Hashtable p_param1 = new Hashtable();
      try
      {
        string uniBase = UbModelBase.UNI_BASE;
        this.TableCode.ToString();
        string empty = string.Empty;
        long num1 = 0;
        int num2 = 0;
        int num3 = 0;
        string str1 = (string) null;
        string str2 = (string) null;
        if (p_param is Hashtable hashtable)
        {
          if (hashtable.ContainsKey((object) "DBMS") && hashtable[(object) "DBMS"].ToString().Length > 0)
            uniBase = hashtable[(object) "DBMS"].ToString();
          if (hashtable.ContainsKey((object) "table") && hashtable[(object) "table"].ToString().Length > 0)
            hashtable[(object) "table"].ToString();
          if (hashtable.ContainsKey((object) "_ORDER_BY_COL_") && hashtable[(object) "_ORDER_BY_COL_"].ToString().Length > 0)
            hashtable[(object) "_ORDER_BY_COL_"].ToString();
          if (hashtable.ContainsKey((object) "mibwb_SiteID") && Convert.ToInt64(hashtable[(object) "mibwb_SiteID"].ToString()) > 0L)
            num1 = Convert.ToInt64(hashtable[(object) "mibwb_SiteID"].ToString());
          if (hashtable.ContainsKey((object) "MemberBuyCycleGroup") && Convert.ToInt32(hashtable[(object) "MemberBuyCycleGroup"].ToString()) > 0)
            num2 = Convert.ToInt32(hashtable[(object) "MemberBuyCycleGroup"].ToString());
          if (hashtable.ContainsKey((object) "bgg_GroupID") && Convert.ToInt32(hashtable[(object) "bgg_GroupID"].ToString()) > 0)
            num3 = Convert.ToInt32(hashtable[(object) "bgg_GroupID"].ToString());
          if (hashtable.ContainsKey((object) "mibwb_Code") && Convert.ToInt32(hashtable[(object) "mibwb_Code"].ToString()) > 0)
            Convert.ToInt32(hashtable[(object) "mibwb_Code"].ToString());
          if (hashtable.ContainsKey((object) "_DT_START_DATE_") && !string.IsNullOrEmpty(hashtable.ContainsKey((object) "_DT_START_DATE_").ToString()) && hashtable.ContainsKey((object) "_DT_END_DATE_") && !string.IsNullOrEmpty(hashtable.ContainsKey((object) "_DT_END_DATE_").ToString()))
          {
            str1 = new DateTime?((DateTime) hashtable[(object) "_DT_START_DATE_"]).GetDateToStr("yyyy-MM-dd 00:00:00");
            str2 = new DateTime?((DateTime) hashtable[(object) "_DT_END_DATE_"]).GetDateToStr("yyyy-MM-dd 23:59:59");
          }
        }
        if (string.IsNullOrEmpty(str1) || string.IsNullOrEmpty(str2))
          throw new Exception("쿼리 일자 구성 오류");
        stringBuilder.Append("WITH T_EMPLOYEE_IN AS (\nSELECT emp_Code AS emp_CodeIn,emp_Name AS inEmpName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Employee, (object) DbQueryHelper.ToWithNolock()) + ") ");
        stringBuilder.Append("\n,T_STORE AS (\nSELECT si_StoreCode,si_SiteID,si_StoreName,si_StoreViewCode,si_UseYn,si_LocationUseYn" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.StoreInfo, (object) DbQueryHelper.ToWithNolock()));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("mibwb_SiteID"))
            p_param1.Add((object) "si_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_StoreCode_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_STORE_AUTHS_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("si_MemberMntStore"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          dictionaryEntry.Key.ToString().Equals("_KEY_WORD_");
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "si_SiteID"))
            p_param1.Add((object) "si_SiteID", (object) num1);
          stringBuilder.Append("\n");
          stringBuilder.Append(new TStoreInfo().GetSelectWhereAnd((object) p_param1));
        }
        else if (num1 > 0L)
          stringBuilder.Append(string.Format("  WHERE {0}={1}", (object) "si_SiteID", (object) num1));
        stringBuilder.Append(")");
        stringBuilder.Append("\n,T_MEMBER AS (\nSELECT mbr_MemberNo,mbr_SiteID,mbr_MemberName,mbr_Birthday,mbr_RegStore" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) TableCodeType.Member, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_STORE ON si_SiteID=mbr_SiteID AND si_StoreCode=mbr_RegStore)");
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("mibwb_SiteID"))
            p_param1.Add((object) "si_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("mbr_MemberType"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("mbr_MemberCycle"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("mbr_MemberGrade"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("mbr_GroupCode"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("mbr_Gender"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("mbr_BuyCycle"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("mbr_BuyCycle_BEGIN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("mbr_BuyCycle_END_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("mbr_BuyCycle_NEXT_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("mbr_BuyCycle_BEFORE_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("mbr_Age"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("mbr_Age_BEGIN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("mbr_Age_END_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "mbr_SiteID"))
            p_param1.Add((object) "mbr_SiteID", (object) num1);
          if (!p_param1.ContainsKey((object) "mbr_Status"))
            p_param1.Add((object) "mbr_Status", (object) 1);
          stringBuilder.Append("\n");
          stringBuilder.Append(new TMember().GetSelectWhereAnd((object) p_param1));
        }
        else if (num1 > 0L)
          stringBuilder.Append(string.Format("  WHERE {0}={1}", (object) "mbr_SiteID", (object) num1));
        stringBuilder.Append(")");
        stringBuilder.Append("\n,T_MEMBER_POINT_HISTORY AS (\nSELECT mph_StoreCode,mph_SaleDate,mph_PosNo,mph_PosNo,mph_TransNo,mbr_MemberNo,mbr_SiteID" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(UbModelBase.UNI_MEMBERS), (object) TableCodeType.MemberPointHistory, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_MEMBER ON mbr_MemberNo=mph_MemberNo\n AND mbr_SiteID=mph_SiteID");
        if (num2 > 0)
          stringBuilder.Append(string.Format("\nINNER JOIN {0}{1}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.CommonCode) + string.Format(" ON {0}={1}", (object) "comm_Type", (object) 197) + string.Format(" AND {0}={1}", (object) "comm_TypeNo", (object) num2));
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("mibwb_SiteID"))
            p_param1.Add((object) "mph_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_DT_START_DATE_"))
            p_param1.Add((object) "mph_SaleDate_BEGIN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_DT_END_DATE_"))
            p_param1.Add((object) "mph_SaleDate_END_", dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "mph_SiteID"))
            p_param1.Add((object) "mph_SiteID", (object) num1);
          stringBuilder.Append("\n");
          stringBuilder.Append(new TGoods().GetSelectWhereAnd((object) p_param1));
        }
        else if (num1 > 0L)
          stringBuilder.Append(string.Format("  WHERE {0}={1}", (object) "gd_SiteID", (object) num1));
        stringBuilder.Append(")");
        if (num3 > 0)
        {
          stringBuilder.Append("\n,T_BOOKMARK_GOODS AS (\nSELECT bgl_GoodsCode,bgl_SiteID" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.BookmarkGoodsList, (object) DbQueryHelper.ToWithNolock()) + string.Format("\nWHERE {0}={1}", (object) "bgl_GroupID", (object) num3));
          if (num1 > 0L)
            stringBuilder.Append(string.Format(" AND {0}={1}", (object) "bgl_SiteID", (object) num1));
          stringBuilder.Append(" GROUP BY bgl_GoodsCode,bgl_SiteID");
          stringBuilder.Append(")");
        }
        stringBuilder.Append("\n,T_GODDS AS (\nSELECT gd_GoodsCode,gd_SiteID,gd_GoodsName" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.Goods, (object) DbQueryHelper.ToWithNolock()));
        if (num3 > 0)
          stringBuilder.Append("\n INNER JOIN T_BOOKMARK_GOODS ON gd_GoodsCode=bgl_GoodsCode AND gd_SiteID=bgl_SiteID");
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("mibwb_SiteID"))
            p_param1.Add((object) "gd_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_GoodsCode"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "gd_SiteID"))
            p_param1.Add((object) "gd_SiteID", (object) num1);
          stringBuilder.Append("\n");
          stringBuilder.Append(new TGoods().GetSelectWhereAnd((object) p_param1));
        }
        else if (num1 > 0L)
          stringBuilder.Append(string.Format("  WHERE {0}={1}", (object) "gd_SiteID", (object) num1));
        stringBuilder.Append(")");
        stringBuilder.Append("\n,T_GODDS_HISTORY AS (\nSELECT gdh_StoreCode,gdh_GoodsCode,gdh_StartDate,gdh_SiteID,gdh_EndDate,gdh_GoodsCategory,gdh_Supplier,CASE gdh_BuyVat WHEN 0 THEN gdh_SalePrice ELSE gdh_SalePrice END - gdh_BuyCost AS mibwb_EikAmt,dpt_lv1_ID, dpt_lv2_ID, dept_code,ctg_lv1_ID, ctg_lv2_ID, ctg_code" + string.Format("\nFROM {0}{1} {2}", (object) DbQueryHelper.ToDBNameBridge(uniBase), (object) TableCodeType.GoodsHistory, (object) DbQueryHelper.ToWithNolock()) + "\nINNER JOIN T_GODDS ON gd_GoodsCode=gdh_GoodsCode AND gd_SiteID=gdh_SiteID\nLEFT OUTER MERGE JOIN " + DbQueryHelper.ToDBNameBridge(uniBase) + "view_category_v1 " + DbQueryHelper.ToWithNolock() + " ON gdh_GoodsCategory=view_category_v1.ctg_code AND gdh_SiteID=view_category_v1.ctg_SiteID");
        p_param1.Clear();
        foreach (DictionaryEntry dictionaryEntry in (Hashtable) p_param)
        {
          if (dictionaryEntry.Key.ToString().Equals("mibwb_SiteID"))
            p_param1.Add((object) "gdh_SiteID", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("gd_GoodsCode"))
            p_param1.Add((object) "gdh_GoodsCode", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_DT_START_DATE_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("_DT_END_DATE_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("su_Supplier"))
            p_param1.Add((object) "gdh_Supplier", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("su_Supplier_IN_"))
            p_param1.Add((object) "gdh_Supplier_IN_", dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("dpt_lv1_ID"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("dpt_lv2_ID"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("dpt_lv3_ID"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ctg_lv1_ID"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ctg_lv1_ID_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ctg_lv2_ID"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ctg_lv2_ID_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ctg_lv3_ID"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
          if (dictionaryEntry.Key.ToString().Equals("ctg_lv3_ID_IN_"))
            p_param1.Add(dictionaryEntry.Key, dictionaryEntry.Value);
        }
        if (p_param1.Count > 0)
        {
          if (!p_param1.ContainsKey((object) "gdh_SiteID"))
            p_param1.Add((object) "gdh_SiteID", (object) num1);
          stringBuilder.Append("\n");
          stringBuilder.Append(new GoodsHistoryView().GetSelectWhereAnd((object) p_param1));
        }
        else if (num1 > 0L)
          stringBuilder.Append(string.Format("  WHERE {0}={1}", (object) "gdh_SiteID", (object) num1));
        stringBuilder.Append(")");
      }
      catch (Exception ex)
      {
        this.message = " " + this.TableCode.ToDescription() + " 실패\n--------------------------------------------------------------------------------------------------\n 테이블 : " + this.TableCode.ToDescription() + "\n 메소드 : " + MethodBase.GetCurrentMethod().ReflectedType.Name + "==>" + MethodBase.GetCurrentMethod().Name + "\n" + string.Format(" LINE : {0} 행\n", (object) new StackFrame(0, true).GetFileLineNumber()) + "--------------------------------------------------------------------------------------------------\n" + string.Format(" 에러 : {0}\n", (object) ex.GetHashCode()) + " 내용 : " + ex.Message + "\n" + string.Format(" Query : {0}\n", (object) stringBuilder) + "--------------------------------------------------------------------------------------------------\n";
        Log.Logger.ErrorColor(this.message);
        stringBuilder.Clear();
      }
      finally
      {
        p_param1.Clear();
      }
      return stringBuilder.ToString();
    }
  }
}
