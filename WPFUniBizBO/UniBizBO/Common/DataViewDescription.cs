// Decompiled with JetBrains decompiler
// Type: UniBizBO.Common.DataViewDescription
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using UniinfoNet.Extensions;

namespace UniBizBO.Common
{
  public class DataViewDescription : FlagNotifyPropertyChanged
  {
    private CategoryViewCollection categoryViews;
    private BindableCollection<DataViewDescription.ColumnViewInfo> columnViews;
    private BindableCollection<DataViewDescription.GroupingViewInfo> groupingViews;
    private bool isUseGroupingFooter;
    private int frozenColumnCount;

    [JsonIgnore]
    public CategoryViewCollection CategoryViews
    {
      get => this.categoryViews ?? (this.categoryViews = new CategoryViewCollection());
      set
      {
        this.categoryViews = value;
        this.Changed(nameof (CategoryViews));
      }
    }

    public IList<DataViewDescription.CategoryViewInfo> CategoryViewsProxy
    {
      get => (IList<DataViewDescription.CategoryViewInfo>) this.CategoryViews;
      set => this.CategoryViews = new CategoryViewCollection((IEnumerable<DataViewDescription.CategoryViewInfo>) value);
    }

    [JsonIgnore]
    public BindableCollection<DataViewDescription.ColumnViewInfo> ColumnViews
    {
      get => this.columnViews ?? (this.columnViews = new BindableCollection<DataViewDescription.ColumnViewInfo>());
      set
      {
        this.columnViews = value;
        this.Changed(nameof (ColumnViews));
      }
    }

    public IList<DataViewDescription.ColumnViewInfo> ColumnViewsProxy
    {
      get => (IList<DataViewDescription.ColumnViewInfo>) this.ColumnViews;
      set => this.ColumnViews = new BindableCollection<DataViewDescription.ColumnViewInfo>((IEnumerable<DataViewDescription.ColumnViewInfo>) value);
    }

    [JsonIgnore]
    public BindableCollection<DataViewDescription.GroupingViewInfo> GroupingViews
    {
      get => this.groupingViews ?? (this.groupingViews = new BindableCollection<DataViewDescription.GroupingViewInfo>());
      set
      {
        this.groupingViews = value;
        this.Changed(nameof (GroupingViews));
      }
    }

    public IList<DataViewDescription.GroupingViewInfo> GroupingViewsProxy
    {
      get => (IList<DataViewDescription.GroupingViewInfo>) this.GroupingViews;
      set => this.GroupingViews = new BindableCollection<DataViewDescription.GroupingViewInfo>((IEnumerable<DataViewDescription.GroupingViewInfo>) value);
    }

    public bool IsUseGroupingFooter
    {
      get => this.isUseGroupingFooter;
      set
      {
        this.isUseGroupingFooter = value;
        this.Changed(nameof (IsUseGroupingFooter));
      }
    }

    public int FrozenColumnCount
    {
      get => this.frozenColumnCount;
      set
      {
        this.frozenColumnCount = value;
        this.Changed(nameof (FrozenColumnCount));
      }
    }

    [JsonIgnore]
    public override bool _IsDeepChanged => base._IsDeepChanged || this._IsChanged || this.CategoryViews.Any<DataViewDescription.CategoryViewInfo>((Func<DataViewDescription.CategoryViewInfo, bool>) (it => it._IsDeepChanged)) || this.ColumnViews.Any<DataViewDescription.ColumnViewInfo>((Func<DataViewDescription.ColumnViewInfo, bool>) (it => it._IsDeepChanged)) || this.GroupingViews.Any<DataViewDescription.GroupingViewInfo>((Func<DataViewDescription.GroupingViewInfo, bool>) (it => it._IsDeepChanged));

    public void DistinctChild() => this.CategoryViews.GroupBy<DataViewDescription.CategoryViewInfo, string>((Func<DataViewDescription.CategoryViewInfo, string>) (it => it.Key)).Select<IGrouping<string, DataViewDescription.CategoryViewInfo>, DataViewDescription.CategoryViewInfo>((Func<IGrouping<string, DataViewDescription.CategoryViewInfo>, DataViewDescription.CategoryViewInfo>) (it => it.First<DataViewDescription.CategoryViewInfo>())).ToList<DataViewDescription.CategoryViewInfo>().Action<List<DataViewDescription.CategoryViewInfo>>((Action<List<DataViewDescription.CategoryViewInfo>>) (it =>
    {
      this.CategoryViews.Clear();
      this.CategoryViews.AddRange((IEnumerable<DataViewDescription.CategoryViewInfo>) it);
    }));

    [JsonIgnore]
    public Action<object, string> ScrollTargetAct { get; set; }

    [JsonIgnore]
    public Action<object, string> EditTargetAct { get; set; }

    public void ScrollTarget(object item, string key = null)
    {
      Action<object, string> scrollTargetAct = this.ScrollTargetAct;
      if (scrollTargetAct == null)
        return;
      scrollTargetAct(item, key);
    }

    public void EditTargetColumn(object item, string key = null)
    {
      Action<object, string> editTargetAct = this.EditTargetAct;
      if (editTargetAct == null)
        return;
      editTargetAct(item, key);
    }

    public class GroupingViewInfo : FlagNotifyPropertyChanged
    {
      private string propertyName;
      private string name;
      private bool isGrouping;

      public GroupingViewInfo() => this._IsChanged = true;

      [JsonIgnore]
      public override bool _IsDeepChanged => base._IsDeepChanged || this._IsChanged;

      public string PropertyName
      {
        get => this.propertyName;
        set
        {
          this.propertyName = value;
          this.Changed(nameof (PropertyName));
        }
      }

      public string Name
      {
        get => this.name;
        set
        {
          this.name = value;
          this.Changed(nameof (Name));
        }
      }

      public bool IsGrouping
      {
        get => this.isGrouping;
        set
        {
          this.isGrouping = value;
          this.Changed(nameof (IsGrouping));
        }
      }
    }

    public class ColumnViewInfo : FlagNotifyPropertyChanged
    {
      private string key;
      private BindableCollection<DataViewDescription.ColumnInfo> columns;
      private bool isDisplay = true;
      private bool isExist;

      [JsonIgnore]
      public override bool _IsDeepChanged => base._IsDeepChanged || this._IsChanged || this.Columns.Any<DataViewDescription.ColumnInfo>((Func<DataViewDescription.ColumnInfo, bool>) (it => it._IsDeepChanged));

      public string Key
      {
        get => this.key;
        set
        {
          this.key = value;
          this.Changed(nameof (Key));
        }
      }

      [JsonIgnore]
      public BindableCollection<DataViewDescription.ColumnInfo> Columns => this.columns ?? (this.columns = new BindableCollection<DataViewDescription.ColumnInfo>());

      public bool IsDisplay
      {
        get => this.isDisplay;
        set
        {
          this.isDisplay = value;
          this.Changed(nameof (IsDisplay));
        }
      }

      [JsonIgnore]
      public bool IsExist
      {
        get => this.isExist;
        set
        {
          this.isExist = value;
          this.Changed(nameof (IsExist));
        }
      }
    }

    public class ColumnInfo : FlagNotifyPropertyChanged
    {
      private string groupName;
      private string name;
      private bool isExist;

      [JsonIgnore]
      public override bool _IsDeepChanged => base._IsDeepChanged || this._IsChanged;

      public string GroupName
      {
        get => this.groupName;
        set
        {
          this.groupName = value;
          this.Changed(nameof (GroupName));
        }
      }

      public string Name
      {
        get => this.name;
        set
        {
          this.name = value;
          this.Changed(nameof (Name));
        }
      }

      [JsonIgnore]
      public bool IsExist
      {
        get => this.isExist;
        set
        {
          this.isExist = value;
          this.Changed(nameof (IsExist));
        }
      }
    }

    public class CategoryViewInfo : FlagNotifyPropertyChanged
    {
      private string key;
      private bool isDisplay = true;
      private bool isExist;
      private string name;

      [JsonIgnore]
      public override bool _IsDeepChanged => base._IsDeepChanged || this._IsChanged;

      public string Key
      {
        get => this.key;
        set
        {
          this.key = value;
          this.Changed(nameof (Key));
        }
      }

      public bool IsDisplay
      {
        get => this.isDisplay;
        set
        {
          this.isDisplay = value;
          this.Changed(nameof (IsDisplay));
        }
      }

      [JsonIgnore]
      public bool IsExist
      {
        get => this.isExist;
        set
        {
          this.isExist = value;
          this.Changed(nameof (IsExist));
        }
      }

      [JsonIgnore]
      public string Name
      {
        get => this.name;
        set
        {
          this.name = value;
          this.Changed(nameof (Name));
        }
      }
    }
  }
}
