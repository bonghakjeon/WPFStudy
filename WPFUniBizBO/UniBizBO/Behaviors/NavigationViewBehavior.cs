// Decompiled with JetBrains decompiler
// Type: UniBizBO.Behaviors.NavigationViewBehavior
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Microsoft.Xaml.Behaviors;
using ModernWpf;
using ModernWpf.Controls;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace UniBizBO.Behaviors
{
  public class NavigationViewBehavior : Behavior<NavigationView>
  {
    protected override void OnAttached()
    {
      base.OnAttached();
      this.AssociatedObject.PaneOpening += new TypedEventHandler<NavigationView, object>(this.AssociatedObject_PaneOpening);
      this.AssociatedObject.PaneClosing += new TypedEventHandler<NavigationView, NavigationViewPaneClosingEventArgs>(this.AssociatedObject_PaneClosing);
      this.AssociatedObject.Loaded += new RoutedEventHandler(this.AssociatedObject_Loaded);
    }

    private void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
    {
      NavigationView element = sender as NavigationView;
      Image child = (element.FindDescendantByName("IconHost") as Viewbox).Child as Image;
      if (element.IsPaneOpen)
        child.Source = (ImageSource) new BitmapImage(new Uri("/Resources/Icon/NavCloseBtn.png", UriKind.Relative));
      else
        child.Source = (ImageSource) new BitmapImage(new Uri("/Resources/Icon/NavOpenBtn.png", UriKind.Relative));
    }

    private void AssociatedObject_PaneClosing(
      NavigationView sender,
      NavigationViewPaneClosingEventArgs args)
    {
      ((sender.FindDescendantByName("IconHost") as Viewbox).Child as Image).Source = (ImageSource) new BitmapImage(new Uri("/Resources/Icon/NavOpenBtn.png", UriKind.Relative));
    }

    private void AssociatedObject_PaneOpening(NavigationView sender, object args) => ((sender.FindDescendantByName("IconHost") as Viewbox).Child as Image).Source = (ImageSource) new BitmapImage(new Uri("/Resources/Icon/NavCloseBtn.png", UriKind.Relative));

    protected override void OnDetaching()
    {
      this.AssociatedObject.PaneOpening -= new TypedEventHandler<NavigationView, object>(this.AssociatedObject_PaneOpening);
      this.AssociatedObject.PaneClosing -= new TypedEventHandler<NavigationView, NavigationViewPaneClosingEventArgs>(this.AssociatedObject_PaneClosing);
      this.AssociatedObject.Loaded -= new RoutedEventHandler(this.AssociatedObject_Loaded);
      base.OnDetaching();
    }
  }
}
