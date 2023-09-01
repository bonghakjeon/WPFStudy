// Decompiled with JetBrains decompiler
// Type: UniBizBO.ViewModels.Board.LoginBoardVMValidater
// Assembly: UniBizBO, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1D413834-2C5F-4B5A-A726-6B319CB8172A
// Assembly location: E:\유니정보\20230411_UniBizBoTest\UniBizBO.dll

using FluentValidation;
using System;
using System.Linq.Expressions;

namespace UniBizBO.ViewModels.Board
{
  public class LoginBoardVMValidater : AbstractValidator<LoginBoardVM>
  {
    public LoginBoardVMValidater()
    {
      this.RuleFor<string>((Expression<Func<LoginBoardVM, string>>) (it => it.SiteViewCode)).MinimumLength<LoginBoardVM>(1).WithMessage<LoginBoardVM, string>("그룹ID가 너무 짧습니다");
      this.RuleFor<string>((Expression<Func<LoginBoardVM, string>>) (it => it.Id)).MinimumLength<LoginBoardVM>(1).WithMessage<LoginBoardVM, string>("아이디가 너무 짧습니다");
      this.RuleFor<string>((Expression<Func<LoginBoardVM, string>>) (it => it.Password)).MinimumLength<LoginBoardVM>(1).WithMessage<LoginBoardVM, string>("비밀번호가 너무 짧습니다");
    }
  }
}
