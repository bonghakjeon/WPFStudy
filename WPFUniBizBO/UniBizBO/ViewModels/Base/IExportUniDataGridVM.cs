// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Base.IExportUniDataGridVM
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using System.Threading.Tasks;
using UniinfoNet.Windows.Wpf;

namespace UniBizBO.ViewModels.Base
{
  public interface IExportUniDataGridVM
  {
    IElementExporter Exporter { get; set; }

    Task ExportExcelAsync();
  }
}
