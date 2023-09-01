// Decompiled with JetBrains decompiler
// Type: UniBizBO.Services.FluentModelValidator`1
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using FluentValidation;
using FluentValidation.Results;
using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


#nullable enable
namespace UniBizBO.Services
{
  public class FluentModelValidator<T> : IModelValidator<
  #nullable disable
  T>, IModelValidator
  {
    private readonly IValidator<T> validator;
    private T subject;

    public FluentModelValidator(IValidator<T> validator) => this.validator = validator;

    public void Initialize(object subject) => this.subject = (T) subject;

    public async Task<IEnumerable<string>> ValidatePropertyAsync(string propertyName) => (await this.validator.ValidateAsync<T>(this.subject, CancellationToken.None, propertyName).ConfigureAwait(false)).Errors.Select<ValidationFailure, string>((Func<ValidationFailure, string>) (x => x.ErrorMessage));

    public async Task<Dictionary<string, IEnumerable<string>>> ValidateAllPropertiesAsync() => (await this.validator.ValidateAsync(this.subject).ConfigureAwait(false)).Errors.GroupBy<ValidationFailure, string>((Func<ValidationFailure, string>) (x => x.PropertyName)).ToDictionary<IGrouping<string, ValidationFailure>, string, IEnumerable<string>>((Func<IGrouping<string, ValidationFailure>, string>) (x => x.Key), (Func<IGrouping<string, ValidationFailure>, IEnumerable<string>>) (x => x.Select<ValidationFailure, string>((Func<ValidationFailure, string>) (failure => failure.ErrorMessage))));
  }
}
