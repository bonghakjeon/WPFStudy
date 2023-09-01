// Decompiled with JetBrains decompiler
// Type: UniBizBO.Behaviors.ScrollSizeChangeBehavior
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using MahApps.Metro.Controls;
using Microsoft.Xaml.Behaviors;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace UniBizBO.Behaviors
{
  public class ScrollSizeChangeBehavior : Behavior<ScrollBar>
  {
    public int StepSize { get; set; }

    protected override void OnAttached()
    {
      this.AssociatedObject.PreviewMouseLeftButtonDown += new MouseButtonEventHandler(this.AssociatedObject_MouseLeftButtonDown);
      base.OnAttached();
    }

    private void AssociatedObject_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
      RepeatButton parent1 = (e.OriginalSource as FrameworkElement).TryFindParent<RepeatButton>();
      ScrollBar parent2 = parent1.TryFindParent<ScrollBar>();
      ScrollViewer parent3 = parent2.TryFindParent<ScrollViewer>();
      if (parent1 == null || parent2 == null || !(parent2.Name == "PART_HorizontalScrollBar"))
        return;
      if (parent1.Name == "HorizontalSmallIncrease")
        parent3.ScrollToHorizontalOffset(parent3.HorizontalOffset + (double) this.StepSize);
      if (!(parent1.Name == "HorizontalSmallDecrease"))
        return;
      parent3.ScrollToHorizontalOffset(parent3.HorizontalOffset - (double) this.StepSize);
    }

    protected override void OnDetaching()
    {
      this.AssociatedObject.PreviewMouseLeftButtonDown -= new MouseButtonEventHandler(this.AssociatedObject_MouseLeftButtonDown);
      base.OnDetaching();
    }

    [Conditional("DEBUG")]
    private void CheckHeightModulesStepSize()
    {
      if (this.AssociatedObject.Height % (double) this.StepSize > 0.0)
        throw new ArgumentException("StepSize should be set to a value by which the height van be divised without a remainder.");
    }
  }
}
