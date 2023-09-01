// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.UniStock.Statement.Month.Vertical.StatementMonthVerticalByTeamPack
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using System.Collections.Generic;
using System.Text.Json.Serialization;
using UniBiz.Bo.Models.UniBase.Dept;
using UniinfoNet;

namespace UniBiz.Bo.Models.UniStock.Statement.Month.Vertical
{
  public class StatementMonthVerticalByTeamPack : BindableBase
  {
    private IList<DeptView> _DataHeader;
    private StatementMonthVerticalByTeamDic _DataBody;

    [JsonPropertyName("dataHeader")]
    public IList<DeptView> DataHeader
    {
      get => this._DataHeader;
      set
      {
        this._DataHeader = value;
        this.Changed(nameof (DataHeader));
      }
    }

    [JsonPropertyName("dataBody")]
    public StatementMonthVerticalByTeamDic DataBody
    {
      get => this._DataBody;
      set
      {
        this._DataBody = value;
        this.Changed(nameof (DataBody));
      }
    }
  }
}
