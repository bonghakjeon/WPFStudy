// Decompiled with JetBrains decompiler
// Type: UniBizBO.Document.TemplateFixedDocumentCreater
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using System;
using System.Printing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using UniinfoNet.Extensions;
using UniinfoNet.Windows.Wpf;
using UniinfoNet.Windows.Wpf.Document;


#nullable enable
namespace UniBizBO.Document
{
  public class TemplateFixedDocumentCreater : ElementFixedDocumentCreaterBase
  {
    private 
    #nullable disable
    TemplateFixedDocumentCreaterArg arg;
    private int currentItemIndex;

    public TemplateFixedDocumentCreaterArg Arg
    {
      get => this.arg ?? (this.arg = new TemplateFixedDocumentCreaterArg());
      set
      {
        this.arg = value;
        this.Changed(nameof (Arg));
      }
    }

    protected override bool CanCreate() => this.Duplicator != null;

    public TemplateFixedDocumentCreater()
    {
      this.OriginPageSizeMm = new Size(210.0, 297.0);
      this.PageMarginMm = new Thickness(5.0);
      this.Orientation = PageOrientation.Portrait;
    }

    public TemplateFixedDocumentCreater(IElementDuplicator duplicator)
      : base(duplicator)
    {
      this.OriginPageSizeMm = new Size(210.0, 297.0);
      this.PageMarginMm = new Thickness(5.0);
      this.Orientation = PageOrientation.Portrait;
    }

    public override void OnDocuemntPrinting() => this.currentItemIndex = 0;

    protected override async Task OnFixedPageElementDrawingAsync(
      FixedPageElementDrawingArg arg,
      IProgress<double> mProgress = null,
      IProgress<double> sProgress = null,
      CancellationToken token = default (CancellationToken))
    {
      TemplateFixedDocumentCreater fixedDocumentCreater1 = this;
      if (arg.Number == 1)
        fixedDocumentCreater1.currentItemIndex = 0;
      await fixedDocumentCreater1.ProgressReportAsync(sProgress, 0.0, token);
      DockPanel layout = new DockPanel().Action<DockPanel>((Action<DockPanel>) (it =>
      {
        it.HorizontalAlignment = HorizontalAlignment.Stretch;
        it.VerticalAlignment = VerticalAlignment.Stretch;
        arg.Area.Child = (UIElement) it;
      }));
      new Border().Action<Border>((Action<Border>) (it =>
      {
        DockPanel.SetDock((UIElement) it, Dock.Top);
        layout.Children.Add((UIElement) it);
        if (string.IsNullOrWhiteSpace(this.Arg?.Title))
          return;
        new TextBlock().Action<TextBlock>((Action<TextBlock>) (text =>
        {
          text.Text = this.Arg.Title;
          text.FontSize = 14.0;
          text.HorizontalAlignment = HorizontalAlignment.Center;
          text.Margin = new Thickness(3.0 * this.Ratio(Unit.mm, Unit.dp));
          it.Child = (UIElement) text;
        }));
      }));
      new Border().Action<Border>((Action<Border>) (it =>
      {
        DockPanel.SetDock((UIElement) it, Dock.Top);
        layout.Children.Add((UIElement) it);
        if (string.IsNullOrWhiteSpace(this.Arg?.Top1Left + this.Arg?.Top1Right + this.Arg?.Top2Left + this.Arg?.Top2Right))
          return;
        Grid grid = new Grid();
        grid.ColumnDefinitions.Add(new ColumnDefinition()
        {
          Width = new GridLength(1.0, GridUnitType.Star)
        });
        grid.ColumnDefinitions.Add(new ColumnDefinition()
        {
          Width = GridLength.Auto
        });
        grid.ColumnDefinitions.Add(new ColumnDefinition()
        {
          Width = new GridLength(1.0, GridUnitType.Star)
        });
        grid.RowDefinitions.Add(new RowDefinition()
        {
          Height = GridLength.Auto
        });
        grid.RowDefinitions.Add(new RowDefinition()
        {
          Height = GridLength.Auto
        });
        Thickness margin = new Thickness(1.0 * this.Ratio(Unit.mm, Unit.dp));
        new TextBlock().Action<TextBlock>((Action<TextBlock>) (text =>
        {
          text.Margin = margin;
          text.Text = this.Arg?.Top1Left;
          text.HorizontalAlignment = HorizontalAlignment.Left;
          text.VerticalAlignment = VerticalAlignment.Top;
          Grid.SetColumn((UIElement) text, 0);
          Grid.SetRow((UIElement) text, 0);
          grid.Children.Add((UIElement) text);
        }));
        new TextBlock().Action<TextBlock>((Action<TextBlock>) (text =>
        {
          text.Margin = margin;
          text.Text = this.Arg?.Top1Right;
          text.HorizontalAlignment = HorizontalAlignment.Right;
          text.VerticalAlignment = VerticalAlignment.Top;
          Grid.SetColumn((UIElement) text, 2);
          Grid.SetRow((UIElement) text, 0);
          grid.Children.Add((UIElement) text);
        }));
        new TextBlock().Action<TextBlock>((Action<TextBlock>) (text =>
        {
          text.Margin = margin;
          text.Text = this.Arg?.Top2Left;
          text.HorizontalAlignment = HorizontalAlignment.Left;
          text.VerticalAlignment = VerticalAlignment.Top;
          Grid.SetColumn((UIElement) text, 0);
          Grid.SetRow((UIElement) text, 1);
          grid.Children.Add((UIElement) text);
        }));
        new TextBlock().Action<TextBlock>((Action<TextBlock>) (text =>
        {
          text.Margin = margin;
          text.Text = this.Arg?.Top2Right;
          text.HorizontalAlignment = HorizontalAlignment.Right;
          text.VerticalAlignment = VerticalAlignment.Top;
          Grid.SetColumn((UIElement) text, 2);
          Grid.SetRow((UIElement) text, 1);
          grid.Children.Add((UIElement) text);
        }));
        it.Child = (UIElement) grid;
      }));
      new Border().Action<Border>((Action<Border>) (it =>
      {
        DockPanel.SetDock((UIElement) it, Dock.Bottom);
        layout.Children.Add((UIElement) it);
        if (string.IsNullOrWhiteSpace(this.Arg?.BottomLeft + this.Arg?.BottomRight))
        {
          TemplateFixedDocumentCreaterArg documentCreaterArg = this.Arg;
          if ((documentCreaterArg != null ? (documentCreaterArg.UsePageCountText ? 1 : 0) : 0) == 0)
            return;
        }
        Grid grid = new Grid();
        grid.ColumnDefinitions.Add(new ColumnDefinition()
        {
          Width = new GridLength(1.0, GridUnitType.Star)
        });
        grid.ColumnDefinitions.Add(new ColumnDefinition()
        {
          Width = GridLength.Auto
        });
        grid.ColumnDefinitions.Add(new ColumnDefinition()
        {
          Width = new GridLength(1.0, GridUnitType.Star)
        });
        Thickness margin = new Thickness(1.0 * this.Ratio(Unit.mm, Unit.dp));
        new TextBlock().Action<TextBlock>((Action<TextBlock>) (text =>
        {
          text.Margin = margin;
          text.Text = this.Arg?.BottomLeft;
          text.HorizontalAlignment = HorizontalAlignment.Left;
          text.VerticalAlignment = VerticalAlignment.Top;
          Grid.SetColumn((UIElement) text, 0);
          Grid.SetRow((UIElement) text, 0);
          grid.Children.Add((UIElement) text);
        }));
        new TextBlock().Action<TextBlock>((Action<TextBlock>) (text =>
        {
          text.Margin = margin;
          text.Text = string.Format("{0}", (object) arg.Number);
          text.HorizontalAlignment = HorizontalAlignment.Left;
          text.VerticalAlignment = VerticalAlignment.Top;
          Grid.SetColumn((UIElement) text, 1);
          Grid.SetRow((UIElement) text, 0);
          grid.Children.Add((UIElement) text);
        }));
        new TextBlock().Action<TextBlock>((Action<TextBlock>) (text =>
        {
          text.Margin = margin;
          text.Text = this.Arg?.BottomRight;
          text.HorizontalAlignment = HorizontalAlignment.Right;
          text.VerticalAlignment = VerticalAlignment.Top;
          Grid.SetColumn((UIElement) text, 2);
          Grid.SetRow((UIElement) text, 0);
          grid.Children.Add((UIElement) text);
        }));
        it.Child = (UIElement) grid;
      }));
      Canvas contentSpace = new Canvas().Action<Canvas>((Action<Canvas>) (it =>
      {
        it.ClipToBounds = true;
        layout.Children.Add((UIElement) it);
      }));
      await fixedDocumentCreater1.ProgressReportAsync(sProgress, 0.1, token);
      FrameworkElement elem = (FrameworkElement) null;
      // ISSUE: explicit non-virtual call
      if (__nonvirtual (fixedDocumentCreater1.ItemsControlDuplicator) != null)
      {
        // ISSUE: explicit non-virtual call
        IItemsControlDuplicator controlDuplicator = __nonvirtual (fixedDocumentCreater1.ItemsControlDuplicator);
        ItemsControlCloneArg itemsControlCloneArg = new ItemsControlCloneArg();
        itemsControlCloneArg.TargetSize = contentSpace.RenderSize;
        itemsControlCloneArg.TargetStretch = Stretch.UniformToFill;
        itemsControlCloneArg.SelectItemRange = Range.StartAt((Index) fixedDocumentCreater1.currentItemIndex);
        itemsControlCloneArg.IsItemSizeFixed = fixedDocumentCreater1.Arg.IsItemSizeFixed;
        itemsControlCloneArg.IsHeaderSizeFixed = fixedDocumentCreater1.Arg.IsHeaderSizeFixed;
        Progress<double> progress1 = new Progress<double>((Action<double>) (p => sProgress.Report(0.1 + p * 0.8)));
        CancellationToken token1 = token;
        ItemsControlCloneResult controlCloneResult = await controlDuplicator.CloneItemsControlAsync(itemsControlCloneArg, (IProgress<double>) progress1, token1);
        TemplateFixedDocumentCreater fixedDocumentCreater2 = fixedDocumentCreater1;
        Range range = controlCloneResult.WorkItemRange;
        Index end = range.End;
        int num1 = end.Value;
        fixedDocumentCreater2.currentItemIndex = num1;
        int currentItemIndex = fixedDocumentCreater1.currentItemIndex;
        range = controlCloneResult.AllItemRange;
        end = range.End;
        int num2 = end.Value - 1;
        if (currentItemIndex < num2)
          arg.HasMore = true;
        elem = controlCloneResult.Element;
        TemplateFixedDocumentCreater fixedDocumentCreater3 = fixedDocumentCreater1;
        IProgress<double> progress2 = mProgress;
        range = controlCloneResult.WorkItemRange;
        end = range.End;
        double num3 = (double) end.Value;
        range = controlCloneResult.AllItemRange;
        end = range.End;
        double num4 = (double) end.Value;
        double v = num3 / num4;
        CancellationToken token2 = token;
        await fixedDocumentCreater3.ProgressReportAsync(progress2, v, token2);
      }
      else
      {
        // ISSUE: explicit non-virtual call
        IElementDuplicator duplicator = __nonvirtual (fixedDocumentCreater1.Duplicator);
        ElementCloneArg elementCloneArg = new ElementCloneArg();
        elementCloneArg.TargetSize = contentSpace.RenderSize;
        elementCloneArg.TargetStretch = Stretch.Uniform;
        Progress<double> progress = new Progress<double>((Action<double>) (p => sProgress.Report(0.1 + p * 0.8)));
        CancellationToken token3 = token;
        elem = (await duplicator.CloneElementAsync(elementCloneArg, (IProgress<double>) progress, token3)).Element;
        await fixedDocumentCreater1.ProgressReportAsync(mProgress, 1.0, token);
      }
      Canvas.SetTop((UIElement) elem, 0.0);
      Canvas.SetLeft((UIElement) elem, 0.0);
      contentSpace.Children.Add((UIElement) elem);
      await fixedDocumentCreater1.ProgressReportAsync(sProgress, 1.0, token);
      contentSpace = (Canvas) null;
      elem = (FrameworkElement) null;
    }
  }
}
