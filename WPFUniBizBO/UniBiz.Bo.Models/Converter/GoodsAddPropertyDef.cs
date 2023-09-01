// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.GoodsAddPropertyDef
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

namespace UniBiz.Bo.Models.Converter
{
  public class GoodsAddPropertyDef
  {
    public static bool IsDeliveryPrt(int p_auth1) => (65536 & p_auth1) > 0;

    public static bool IsDeliveryDisp(int p_auth1) => (131072 & p_auth1) > 0;

    public static bool IsDepositBottole(int p_auth1) => (1048576 & p_auth1) > 0;

    public static bool IsDepositBox(int p_auth1) => (2097152 & p_auth1) > 0;

    public static bool IsDepositBag(int p_auth1) => (4194304 & p_auth1) > 0;

    public static bool IsDepositDeli(int p_auth1) => (8388608 & p_auth1) > 0;

    public static bool IsNotCoupon(int p_auth1) => (4 & p_auth1) > 0;

    public static bool IsOnPumbun(int p_auth1) => (8 & p_auth1) > 0;
  }
}
