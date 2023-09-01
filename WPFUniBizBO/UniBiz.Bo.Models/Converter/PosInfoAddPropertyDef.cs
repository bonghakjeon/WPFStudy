// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.PosInfoAddPropertyDef
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

namespace UniBiz.Bo.Models.Converter
{
  public class PosInfoAddPropertyDef
  {
    public static bool IsPos(int p_auth1) => (1 & p_auth1) > 0;

    public static bool IsKiosk(int p_auth1) => (2 & p_auth1) > 0;

    public static bool IsPDA(int p_auth1) => (4 & p_auth1) > 0;

    public static bool IsNextPos(int p_auth1) => (8 & p_auth1) > 0;

    public static bool IsDeliveryPos(int p_auth1) => (256 & p_auth1) > 0;

    public static bool IsVirtualPos(int p_auth1) => (512 & p_auth1) > 0;

    public static bool IsReturnPossible(int p_auth1) => (32 & p_auth1) > 0;

    public static bool IsEnuryPossible(int p_auth1) => (64 & p_auth1) > 0;

    public static bool IsGiftsPossible(int p_auth1) => (16 & p_auth1) > 0;

    public static bool IsICCenterm(int p_auth1) => (4096 & p_auth1) > 0;

    public static bool IsPosKeyTypeNormal(int p_auth1) => (65536 & p_auth1) > 0;

    public static bool IsPosKeyTypeEvent(int p_auth1) => (131072 & p_auth1) > 0;
  }
}
