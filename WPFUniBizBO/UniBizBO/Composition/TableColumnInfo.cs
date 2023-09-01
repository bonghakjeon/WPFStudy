// Decompiled with JetBrains decompiler
// Type: UniBizBO.Composition.TableColumnInfo
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UniBiz.Bo.Models.TableInfo;
using UniBiz.Bo.Models.UniBase.CommonCode;
using UniinfoNet;
using UniinfoNet.Extensions;

namespace UniBizBO.Composition
{
  public class TableColumnInfo : BindableBase
  {
    private CommonCodeGroup cTypeGroupRaw;

    public string PropertyName { get; set; }

    public string TransName { get; set; }

    public string GroupName { get; set; }

    public string Description { get; set; }

    public Type ClazzType { get; set; }

    public Type PropertyType { get; set; }

    public int CTypeNum { get; set; }

    public CommonCodeGroup CTypeGroupRaw
    {
      get => this.cTypeGroupRaw;
      set
      {
        this.cTypeGroupRaw = value;
        if (value == null)
          this.CTypeGroup = (CommonCodeGroup) null;
        else
          this.CTypeGroup = new CommonCodeGroup(value.Type, (IEnumerable<CommonCodeView>) value.Where<CommonCodeView>((Func<CommonCodeView, bool>) (it => it.comm_TypeNo != 0)).ToArray<CommonCodeView>());
      }
    }

    public CommonCodeGroup CTypeGroup { get; protected set; }

    public bool IsKey { get; set; }

    public bool IsEnable { get; set; } = true;

    public bool IsVisible { get; set; } = true;

    public bool IsReadOnly { get; set; }

    public bool IsRequired { get; set; }

    public bool IsExistServer { get; set; }

    public TableColumnInfo() => this.Init();

    public override string ToString() => this.TransName;

    private void Init()
    {
      this.PropertyName = (string) null;
      this.TransName = (string) null;
      this.Description = (string) null;
      this.ClazzType = (Type) null;
      this.PropertyType = (Type) null;
      this.IsEnable = true;
      this.IsVisible = true;
      this.IsReadOnly = false;
      this.IsRequired = false;
      this.IsExistServer = false;
    }

    public TableColumnInfo Apply<T>(TTableColumn tcolumn)
    {
      this.Init();
      this.ClazzType = typeof (T);
      this.PropertyName = tcolumn.tc_orgin_name;
      this.TransName = tcolumn.tc_trans_name;
      this.Description = tcolumn.tc_col_hint;
      PropertyInfo property = this.ClazzType.GetProperty(this.PropertyName);
      if ((object) property != null)
        property.Action<PropertyInfo>((Action<PropertyInfo>) (p => this.PropertyType = p.PropertyType));
      return this;
    }

    public TableColumnInfo Apply(Type clazzType, TTableColumn tcolumn)
    {
      this.Init();
      this.ClazzType = clazzType;
      this.PropertyName = tcolumn.tc_orgin_name;
      this.TransName = tcolumn.tc_trans_name;
      this.Description = tcolumn.tc_col_hint;
      PropertyInfo property = this.ClazzType.GetProperty(this.PropertyName);
      if ((object) property != null)
        property.Action<PropertyInfo>((Action<PropertyInfo>) (p => this.PropertyType = p.PropertyType));
      return this;
    }

    public static List<TableColumnInfo> CreateList(
      Type clazzType,
      IEnumerable<TTableColumn> TTableColumns)
    {
      List<TableColumnInfo> list = ((IEnumerable<PropertyInfo>) clazzType.GetProperties(BindingFlags.Instance | BindingFlags.Public)).Select<PropertyInfo, TableColumnInfo>((Func<PropertyInfo, TableColumnInfo>) (it => new TableColumnInfo()
      {
        ClazzType = clazzType,
        PropertyName = it.Name,
        PropertyType = it.PropertyType,
        IsExistServer = false
      })).ToList<TableColumnInfo>();
      foreach (TTableColumn ttableColumn in TTableColumns)
      {
        TTableColumn col = ttableColumn;
        TableColumnInfo tableColumnInfo = list.FirstOrDefault<TableColumnInfo>((Func<TableColumnInfo, bool>) (it => it.PropertyName.Equals(col.tc_orgin_name)));
        if (tableColumnInfo == null)
        {
          tableColumnInfo = new TableColumnInfo()
          {
            ClazzType = clazzType,
            PropertyName = col.tc_orgin_name
          };
          list.Add(tableColumnInfo);
        }
        tableColumnInfo.IsExistServer = true;
        tableColumnInfo.TransName = string.IsNullOrWhiteSpace(col.tc_trans_name) ? "(None)" : col.tc_trans_name;
        tableColumnInfo.IsReadOnly = col.IsRequired;
        tableColumnInfo.CTypeNum = col.tc_comm_code;
        tableColumnInfo.IsKey = col.IsKey;
        tableColumnInfo.Description = col.tc_col_hint;
        tableColumnInfo.IsVisible = col.tc_col_visible;
        tableColumnInfo.GroupName = col.tc_parents_name;
      }
      return list.OrderBy<TableColumnInfo, string>((Func<TableColumnInfo, string>) (it => it.PropertyName)).ToList<TableColumnInfo>();
    }
  }
}
