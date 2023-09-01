// Decompiled with JetBrains decompiler
// Type: UniBizBO.Behaviors.NavigationViewItemBehavior
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Microsoft.Xaml.Behaviors;
using ModernWpf;
using ModernWpf.Controls;
using System.Windows;
using System.Windows.Shapes;

namespace UniBizBO.Behaviors
{
  public class NavigationViewItemBehavior : Behavior<NavigationViewItem>
  {
    protected override void OnAttached()
    {
      base.OnAttached();
      this.AssociatedObject.Loaded += new RoutedEventHandler(this.AssociatedObject_Loaded);
    }

    private void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
    {
      NavigationViewItem element = sender as NavigationViewItem;
      if (element.FindDescendantByName("SelectionIndicator") is Rectangle descendantByName)
        descendantByName.Opacity = 0.0;
      element.OnApplyTemplate();
    }

    protected override void OnDetaching()
    {
      this.AssociatedObject.Loaded -= new RoutedEventHandler(this.AssociatedObject_Loaded);
      base.OnDetaching();
    }
  }
}
