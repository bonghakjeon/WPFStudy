// Decompiled with JetBrains decompiler
// Type: UniBizBO.Store.LocalStatusStore
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using Microsoft.EntityFrameworkCore;
using StyletIoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using UniBizBO.Services;
using UniBizBO.Store.Tables;
using UniinfoNet;
using UniinfoNet.Extensions;

namespace UniBizBO.Store
{
  public class LocalStatusStore : BindableBase
  {
    [Inject]
    public IContainer Container { get; set; }

    public void LoadManagedStatus<T>(T target) where T : class
    {
      Type vmType = target.GetType();
      List<ManagedStatusPropertyInfo> statusPropertyInfos = ManagedStatusAttribute.GetManagedStatusPropertyInfos<T>(target);
      JsonSerializerOptions jsonOption = new JsonSerializerOptions();
      jsonOption.Converters.Add((JsonConverter) new LocalStatusStore.NullToBoolJsonConverter());
      using (LocalStatusDb localStatusDb = this.Container.Get<LocalStatusDb>())
      {
        DbSet<CommonStatusTable> commons = localStatusDb.Commons;
        Expression<Func<CommonStatusTable, bool>> predicate = (Expression<Func<CommonStatusTable, bool>>) (it => it.TypeName.Equals(vmType.FullName));
        foreach (CommonStatusTable commonStatusTable in commons.Where<CommonStatusTable>(predicate).ToList<CommonStatusTable>())
        {
          CommonStatusTable dbitem = commonStatusTable;
          ManagedStatusPropertyInfo statusPropertyInfo = statusPropertyInfos.FirstOrDefault<ManagedStatusPropertyInfo>((Func<ManagedStatusPropertyInfo, bool>) (it => it.ItemName.Equals(dbitem.StatusId)));
          if (statusPropertyInfo != null)
            statusPropertyInfo.Action<ManagedStatusPropertyInfo>((Action<ManagedStatusPropertyInfo>) (item =>
            {
              PropertyInfo pinfo = item.PInfo;
              // ISSUE: variable of a boxed type
              __Boxed<T> local = (object) (T) target;
              string statusVal = dbitem.StatusVal;
              Type returnType = item.RealType;
              if ((object) returnType == null)
                returnType = item.PInfo.PropertyType;
              JsonSerializerOptions options = jsonOption;
              object obj = JsonSerializer.Deserialize(statusVal, returnType, options);
              pinfo.SetValue((object) local, obj);
            }));
        }
      }
    }

    public void SaveManagedStatus<T>(T target) where T : class
    {
      Type vmType = target.GetType();
      List<ManagedStatusPropertyInfo> statusPropertyInfos = ManagedStatusAttribute.GetManagedStatusPropertyInfos<T>(target);
      using (LocalStatusDb localStatusDb = this.Container.Get<LocalStatusDb>())
      {
        List<CommonStatusTable> list = localStatusDb.Commons.Where<CommonStatusTable>((Expression<Func<CommonStatusTable, bool>>) (it => it.TypeName.Equals(vmType.FullName))).ToList<CommonStatusTable>();
        List<CommonStatusTable> entities = new List<CommonStatusTable>();
        foreach (ManagedStatusPropertyInfo statusPropertyInfo in statusPropertyInfos)
        {
          ManagedStatusPropertyInfo item = statusPropertyInfo;
          CommonStatusTable commonStatusTable = list.FirstOrDefault<CommonStatusTable>((Func<CommonStatusTable, bool>) (it => it.StatusId.Equals(item.ItemName)));
          object obj = item.PInfo.GetValue((object) target);
          Type inputType = item.RealType;
          if ((object) inputType == null)
            inputType = item.PInfo.PropertyType;
          string str = JsonSerializer.Serialize(obj, inputType);
          if (commonStatusTable == null)
          {
            commonStatusTable = new CommonStatusTable()
            {
              TypeName = vmType.FullName,
              StatusId = item.ItemName,
              PropertyName = item.PInfo.Name
            };
            entities.Add(commonStatusTable);
          }
          commonStatusTable.StatusVal = str;
        }
        if (entities.Count != 0)
          localStatusDb.AddRange((IEnumerable<object>) entities);
        localStatusDb.SaveChanges();
      }
    }

    public class NullToBoolJsonConverter : JsonConverter<bool>
    {
      public override bool Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
      {
        return reader.TokenType != JsonTokenType.Null && reader.GetBoolean();
      }

      public override void Write(Utf8JsonWriter writer, bool value, JsonSerializerOptions options) => writer.WriteBooleanValue(value);
    }
  }
}
