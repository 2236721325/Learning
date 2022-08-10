using FluentValidation;

namespace JWT.Models.Validators;

public class UserInfoValidator : AbstractValidator<UserInfo>
{

    public UserInfoValidator()
    {
        RuleFor(e => e.Name).MaximumLength(12).WithMessage("名称过长,最大长度为12！");
        RuleFor(e => e.UserName).MaximumLength(24).WithMessage("名称过长,最大长度为24！");
        RuleFor(e => e.TempPwd).MaximumLength(24).WithMessage("密码过长,最大长度为24！");
    }
}

