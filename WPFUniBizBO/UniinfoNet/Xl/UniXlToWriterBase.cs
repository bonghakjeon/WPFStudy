// Decompiled with JetBrains decompiler
// Type: UniinfoNet.Xl.UniXlToWriterBase`1
// Assembly: UniinfoNet, Version=1.4.13.0, Culture=neutral, PublicKeyToken=null
// MVID: D07AD835-6E8C-4C9F-9DA6-C44019A506FC
// Assembly location: C:\Users\bhjeon\Downloads\20230411_UniBizBoTest\UniinfoNet.dll

namespace UniinfoNet.Xl
{
  public abstract class UniXlToWriterBase<T> : BindableBase where T : UniXlToWriterBase<T>, new()
  {
    private UniXlInfo document;

    public UniXlToWriterBase()
    {
    }

    public UniXlToWriterBase(UniXlInfo xl) => this.Document = xl;

    public UniXlInfo Document
    {
      get => this.document;
      set
      {
        this.document = value;
        this.SetAndNotify<UniXlInfo>(ref this.document, value, nameof (Document));
      }
    }

    public static T Create(UniXlInfo xl)
    {
      T obj = new T();
      obj.Document = xl;
      return obj;
    }

    public static T Create(UniXlSheetInfo sheet) => UniXlToWriterBase<T>.Create(new UniXlInfo(new UniXlSheetInfo[1]
    {
      sheet
    }));

    public static T Create(UniXlTableInfo table) => UniXlToWriterBase<T>.Create(new UniXlSheetInfo(new UniXlTableInfo[1]
    {
      table
    }));
  }
}
