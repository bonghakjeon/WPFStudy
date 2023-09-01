// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumPosInfoAddProperty
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumPosInfoAddProperty
  {
    [Description("-POS특성-")] NONE = 0,
    [Description("POS")] POS = 1,
    [Description("KIOSK")] KIOSK = 2,
    [Description("PDA")] PDA = 4,
    [Description("차세대포스")] NEXT_POS = 8,
    [Description("사은품가능")] GIFTS_POSSIBLE = 16, // 0x00000010
    [Description("반품가능")] RETURN_POSSIBLE = 32, // 0x00000020
    [Description("에누리가능")] ENURY_POSSIBLE = 64, // 0x00000040
    [Description("예약8")] reservation_8 = 128, // 0x00000080
    [Description("배달POS")] DELIVERY = 256, // 0x00000100
    [Description("가상POS")] VIRTUAL_POS = 512, // 0x00000200
    [Description("예약11")] reservation_11 = 1024, // 0x00000400
    [Description("예약12")] reservation_12 = 2048, // 0x00000800
    [Description("센텀IC")] IC_CENTERM = 4096, // 0x00001000
    [Description("예약14")] reservation_14 = 8192, // 0x00002000
    [Description("예약15")] reservation_15 = 16384, // 0x00004000
    [Description("예약16")] reservation_16 = 32768, // 0x00008000
    [Description("일반매장")] PKU_NORMAL = 65536, // 0x00010000
    [Description("행사매장")] PKU_EVENT = 131072, // 0x00020000
    [Description("예약15")] reservation_19 = 262144, // 0x00040000
    [Description("예약16")] reservation_20 = 524288, // 0x00080000
  }
}
