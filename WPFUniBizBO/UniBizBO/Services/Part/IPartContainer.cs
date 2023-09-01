// Decompiled with JetBrains decompiler
// Type: UniBizBO.Services.Part.IPartContainer
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using System.Threading.Tasks;
using UniBiz.Bo.Models;
using UniinfoNet.Windows.Wpf.Commands;

namespace UniBizBO.Services.Part
{
  public interface IPartContainer : IHaveWorkDataSet
  {
    TableCodeType TableCode { get; }

    bool IsManualSaveWorkData { get; set; }

    bool IsManualLoadWorkData { get; set; }

    object[] WorkDataKeys { get; set; }

    bool IsCreateMode { get; set; }

    bool CanSaveWorkData();

    string ContentsDisplay { get; set; }

    Task SaveWorkDataAsync();

    bool CanLoadWorkData();

    Task LoadWorkDataAsync();

    bool CanClearWorkData();

    Task ClearWorkDataAsync();

    bool CanRollbackWorkData();

    Task RollbackWorkDataAsync();

    bool CanConfirm();

    Task ConfirmAsync();

    bool WinClose();

    WpfCommand CmdSaveWorkData { get; }

    WpfCommand CmdLoadWorkData { get; }

    WpfCommand CmdClearWorkData { get; }

    WpfCommand CmdRollbackWorkData { get; }

    WpfCommand CmdConfirm { get; }

    WpfCommand CmdClose { get; }
  }
}
