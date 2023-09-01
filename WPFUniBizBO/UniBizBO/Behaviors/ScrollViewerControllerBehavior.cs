// Decompiled with JetBrains decompiler
// Type: UniBizBO.Behaviors.ScrollViewerControllerBehavior
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using System.Windows.Controls;

namespace UniBizBO.Behaviors
{
  public class ScrollViewerControllerBehavior : ScrollControllerBehaviorBase<ScrollViewer>
  {
    public override void ScrollChangeByRatio(double offsetXRatio, double offsetYRatio)
    {
      ScrollViewer associatedObject = this.AssociatedObject;
      if (associatedObject == null)
        return;
      this.ScrollChangeByAmount(associatedObject.ViewportWidth * offsetXRatio, associatedObject.ViewportHeight * offsetYRatio);
    }

    public override void ScrollChangeByAmount(double offsetX, double offsetY)
    {
      ScrollViewer associatedObject = this.AssociatedObject;
      if (associatedObject == null)
        return;
      if (offsetX != 0.0)
        associatedObject.ScrollToHorizontalOffset(associatedObject.HorizontalOffset + offsetX);
      if (offsetY == 0.0)
        return;
      associatedObject.ScrollToVerticalOffset(associatedObject.VerticalOffset + offsetY);
    }
  }
}
