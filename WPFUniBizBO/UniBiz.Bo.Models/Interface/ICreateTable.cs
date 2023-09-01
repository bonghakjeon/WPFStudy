// Decompiled with JetBrains decompiler
// Type: UniBiz.Bo.Models.Interface.ICreateTable
// Assembly: UniBiz.Bo.Models, Version=0.1.48.4101, Culture=neutral, PublicKeyToken=null
// MVID: 27E62FA1-F3BF-4DFF-9EBE-A4E798D683E5
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBiz.Bo.Models.dll

using UniOleDbLib;

namespace UniBiz.Bo.Models.Interface
{
  public interface ICreateTable
  {
    bool ReCreateTable();

    bool CreateTable();

    bool DropTable();

    bool InitTable();

    bool CreateTableComment(string p_db_category);

    void SetAdoDatabase(UniOleDatabase ado);
  }
}
