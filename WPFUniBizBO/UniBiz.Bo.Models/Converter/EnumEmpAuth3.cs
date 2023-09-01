// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Converter.EnumEmpAuth3
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.ComponentModel;

namespace UniBiz.Bo.Models.Converter
{
  public enum EnumEmpAuth3
  {
    [Description("-사용권한3-")] NONE = 0,
    [Description("예약 1")] AUTH3_1 = 1,
    [Description("예약 2")] AUTH3_2 = 2,
    [Description("예약 3")] AUTH3_3 = 4,
    [Description("예약 4")] AUTH3_4 = 8,
    [Description("예약 5")] AUTH3_5 = 16, // 0x00000010
    [Description("예약 6")] AUTH3_6 = 32, // 0x00000020
    [Description("예약 7")] AUTH3_7 = 64, // 0x00000040
    [Description("예약 8")] AUTH3_8 = 128, // 0x00000080
    [Description("예약 9")] AUTH3_9 = 256, // 0x00000100
    [Description("예약 10")] AUTH3_10 = 512, // 0x00000200
    [Description("예약 11")] AUTH3_11 = 1024, // 0x00000400
    [Description("예약 12")] AUTH3_12 = 2048, // 0x00000800
    [Description("예약 13")] AUTH3_13 = 4096, // 0x00001000
    [Description("예약 14")] AUTH3_14 = 8192, // 0x00002000
    [Description("예약 15")] AUTH3_15 = 16384, // 0x00004000
    [Description("예약 16")] AUTH3_16 = 32768, // 0x00008000
    [Description("예약 17")] AUTH3_17 = 65536, // 0x00010000
    [Description("예약 18")] AUTH3_18 = 131072, // 0x00020000
    [Description("예약 19")] AUTH3_19 = 262144, // 0x00040000
    [Description("예약 20")] AUTH3_20 = 524288, // 0x00080000
    [Description("예약 21")] AUTH3_21 = 1048576, // 0x00100000
    [Description("예약 22")] AUTH3_22 = 2097152, // 0x00200000
    [Description("예약 23")] AUTH3_23 = 4194304, // 0x00400000
    [Description("예약 24")] AUTH3_24 = 8388608, // 0x00800000
    [Description("예약 25")] AUTH3_25 = 16777216, // 0x01000000
    [Description("예약 26")] AUTH3_26 = 33554432, // 0x02000000
    [Description("예약 27")] AUTH3_27 = 67108864, // 0x04000000
    [Description("예약 28")] AUTH3_28 = 134217728, // 0x08000000
    [Description("예약 29")] AUTH3_29 = 268435456, // 0x10000000
    [Description("예약 30")] AUTH3_30 = 536870912, // 0x20000000
    [Description("예약 31")] AUTH3_31 = 1073741824, // 0x40000000
  }
}
