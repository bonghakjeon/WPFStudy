// Decompiled with JetBrains decompiler
// Type: UniBizBO.Behaviors.MenuBookMarkButtonBehavior
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using UniBiz.Bo.Models.UniBase.ProgMenuInfo.ProgMenuBookMark;

namespace UniBizBO.Behaviors
{
  public class MenuBookMarkButtonBehavior : Behavior<Button>
  {
    protected override void OnAttached()
    {
      base.OnAttached();
      this.AssociatedObject.Click += new RoutedEventHandler(this.AssociatedObject_Click);
      this.AssociatedObject.MouseRightButtonUp += new MouseButtonEventHandler(this.AssociatedObject_MouseRightButtonUp);
    }

    private void AssociatedObject_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
    {
      e.Handled = true;
      (sender as Button).ContextMenu.IsOpen = false;
    }

    private void AssociatedObject_Click(object sender, RoutedEventArgs e)
    {
      Button button = sender as Button;
      if (!(button.DataContext is ProgMenuBookMarkView dataContext) || dataContext.pmbm_ViewType != 1)
        return;
      button.ContextMenu.PlacementTarget = (UIElement) button;
      button.ContextMenu.Placement = PlacementMode.Bottom;
      button.ContextMenu.IsOpen = true;
    }

    protected override void OnDetaching()
    {
      base.OnDetaching();
      this.AssociatedObject.Click -= new RoutedEventHandler(this.AssociatedObject_Click);
      this.AssociatedObject.MouseRightButtonUp -= new MouseButtonEventHandler(this.AssociatedObject_MouseRightButtonUp);
    }
  }
}
