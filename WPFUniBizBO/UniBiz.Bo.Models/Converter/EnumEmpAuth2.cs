// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumEmpAuth2
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumEmpAuth2
  {
    [Description("-사용권한2-")] NONE = 0,
    [Description("발주등록")] ORDER_INPUT = 1,
    [Description("발주확정")] ORDER_CONFIRM = 2,
    [Description("발주삭제")] ORDER_DELETE = 4,
    [Description("전표(발주->매입)이동")] ORDER_PURCHASE_MOVE = 8,
    [Description("매입등록")] BUY_INPUT = 16, // 0x00000010
    [Description("매입확정")] BUY_CONFIRM = 32, // 0x00000020
    [Description("매입삭제")] BUY_DELETE = 64, // 0x00000040
    [Description("예약 8")] AUTH2_8 = 128, // 0x00000080
    [Description("점간이동등록")] OUTER_MOVE_INPUT = 256, // 0x00000100
    [Description("점간이동확정")] OUTER_MOVE_CONFIRM = 512, // 0x00000200
    [Description("점간이동삭제")] OUTER_MOVE_DELETE = 1024, // 0x00000400
    [Description("예약 12")] AUTH2_12 = 2048, // 0x00000800
    [Description("점내이동등록")] INNER_MOVE_INPUT = 4096, // 0x00001000
    [Description("점내이동확정")] INNER_MOVE_CONFIRM = 8192, // 0x00002000
    [Description("점내이동삭제")] INNER_MOVE_DELETE = 16384, // 0x00004000
    [Description("예약 16")] AUTH2_16 = 32768, // 0x00008000
    [Description("재고조정등록")] ADJUST_INPUT = 65536, // 0x00010000
    [Description("재고조정확정")] ADJUST_CONFIRM = 131072, // 0x00020000
    [Description("재고조정삭제")] ADJUST_DELETE = 262144, // 0x00040000
    [Description("예약 20")] AUTH2_20 = 524288, // 0x00080000
    [Description("폐기등록")] DISUSE_INPUT = 1048576, // 0x00100000
    [Description("폐기확정")] DISUSE_CONFIRM = 2097152, // 0x00200000
    [Description("폐기삭제")] DISUSE_DELETE = 4194304, // 0x00400000
    [Description("예약 24")] AUTH2_24 = 8388608, // 0x00800000
    [Description("재고조사등록")] STOCK_INVENTORY_INPUT = 16777216, // 0x01000000
    [Description("재고조사확정")] STOCK_INVENTORY_CONFIRM = 33554432, // 0x02000000
    [Description("재고조사삭제")] STOCK_INVENTORY_DELETE = 67108864, // 0x04000000
    [Description("자동발주지정")] AUTO_ORDER_SET = 134217728, // 0x08000000
    [Description("예약 29")] AUTH2_29 = 268435456, // 0x10000000
    [Description("예약 30")] AUTH2_30 = 536870912, // 0x20000000
    [Description("예약 31")] AUTH2_31 = 1073741824, // 0x40000000
  }
}
