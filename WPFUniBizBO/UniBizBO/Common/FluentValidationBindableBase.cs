// Decompiled with JetBrains decompiler
// Type: UniBizBO.Common.FluentValidationBindableBase
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using FluentValidation.Results;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using UniinfoNet;

namespace UniBizBO.Common
{
  public abstract class FluentValidationBindableBase : ValidationBindableBase
  {
    [JsonIgnore]
    public ValidationResult ValidResult { get; set; }

    protected virtual ValidationResult GetValidationResult(string name) => (ValidationResult) null;

    protected override void OnValidation(string name)
    {
      ValidationResult validResult1 = this.ValidResult;
      this.ValidResult = this.GetValidationResult(name);
      ValidationResult validResult2 = this.ValidResult;
      if ((validResult2 != null ? (validResult2.IsValid ? 1 : 0) : 1) != 0 && (validResult1 != null ? (validResult1.IsValid ? 1 : 0) : 1) != 0)
        return;
      int count1 = validResult1 != null ? validResult1.Errors.Count : 0;
      ValidationResult validResult3 = this.ValidResult;
      int count2 = validResult3 != null ? validResult3.Errors.Count : 0;
      List<string> source = new List<string>(count1 + count2 + 1);
      if (validResult1?.Errors != null)
        source.AddRange(validResult1.Errors.Select<ValidationFailure, string>((Func<ValidationFailure, string>) (it => it.PropertyName)));
      if (this.ValidResult?.Errors != null)
        source.AddRange(this.ValidResult.Errors.Select<ValidationFailure, string>((Func<ValidationFailure, string>) (it => it.PropertyName)));
      foreach (string name1 in source.Distinct<string>())
        this.ErrorChanged(name1);
    }

    public override bool HasErrors
    {
      get
      {
        ValidationResult validResult = this.ValidResult;
        return (validResult != null ? (validResult.IsValid ? 1 : 0) : 1) == 0;
      }
    }

    public override IEnumerable GetErrors(string propertyName)
    {
      if (string.IsNullOrEmpty(propertyName))
        return (IEnumerable) this.ValidResult?.Errors;
      ValidationResult validResult = this.ValidResult;
      if (validResult == null)
        return (IEnumerable) null;
      IList<ValidationFailure> errors = validResult.Errors;
      return errors == null ? (IEnumerable) null : (IEnumerable) errors.Where<ValidationFailure>((Func<ValidationFailure, bool>) (it => string.Equals(it.PropertyName, propertyName)));
    }
  }
}
