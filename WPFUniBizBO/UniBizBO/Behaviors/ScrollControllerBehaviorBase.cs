// Decompiled with JetBrains decompiler
// Type: UniBizBO.Behaviors.ScrollControllerBehaviorBase`1
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Microsoft.Xaml.Behaviors;
using System;
using System.Windows;
using UniinfoNet.Windows.Wpf.Commands;

namespace UniBizBO.Behaviors
{
  public abstract class ScrollControllerBehaviorBase<T> : Behavior<T>, IScrollController where T : DependencyObject
  {
    public static readonly DependencyProperty ScrollControllerProperty = DependencyProperty.Register(nameof (ScrollController), typeof (IScrollController), typeof (ScrollControllerBehaviorBase<T>), new PropertyMetadata((PropertyChangedCallback) null));
    private WpfCommand cmdScrollChangeXByRatio;
    private WpfCommand cmdScrollChangeYByRatio;

    public IScrollController ScrollController
    {
      get => (IScrollController) ((DependencyObject) this).GetValue(ScrollControllerBehaviorBase<T>.ScrollControllerProperty);
      set => ((DependencyObject) this).SetValue(ScrollControllerBehaviorBase<T>.ScrollControllerProperty, (object) value);
    }

    public abstract void ScrollChangeByRatio(double offsetXRatio, double offsetYRatio);

    public abstract void ScrollChangeByAmount(double offsetX, double offsetY);

    protected override void OnAttached()
    {
      base.OnAttached();
      ((DependencyObject) this).SetCurrentValue(ScrollControllerBehaviorBase<T>.ScrollControllerProperty, (object) this);
    }

    protected override void OnDetaching()
    {
      base.OnDetaching();
      ((DependencyObject) this).SetCurrentValue(ScrollControllerBehaviorBase<T>.ScrollControllerProperty, (object) null);
    }

    public WpfCommand CmdScrollChangeXByRatio
    {
      get
      {
        WpfCommand scrollChangeXbyRatio1 = this.cmdScrollChangeXByRatio;
        if (scrollChangeXbyRatio1 != null)
          return scrollChangeXbyRatio1;
        WpfCommand wpfCommand = new WpfCommand();
        wpfCommand.ExecuteAction = (Action<object>) (x =>
        {
          double result;
          if (!double.TryParse(x?.ToString(), out result))
            return;
          this.ScrollChangeByRatio(result, 0.0);
        });
        WpfCommand scrollChangeXbyRatio2 = wpfCommand;
        this.cmdScrollChangeXByRatio = wpfCommand;
        return scrollChangeXbyRatio2;
      }
    }

    public WpfCommand CmdScrollChangeYByRatio
    {
      get
      {
        WpfCommand scrollChangeYbyRatio1 = this.cmdScrollChangeYByRatio;
        if (scrollChangeYbyRatio1 != null)
          return scrollChangeYbyRatio1;
        WpfCommand wpfCommand = new WpfCommand();
        wpfCommand.ExecuteAction = (Action<object>) (x =>
        {
          double result;
          if (!double.TryParse(x?.ToString(), out result))
            return;
          this.ScrollChangeByRatio(0.0, result);
        });
        WpfCommand scrollChangeYbyRatio2 = wpfCommand;
        this.cmdScrollChangeYByRatio = wpfCommand;
        return scrollChangeYbyRatio2;
      }
    }
  }
}
