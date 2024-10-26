using FluentValidation;

namespace financial_banking.Application.DTOs.Validators
{
    public class UpdateAccountDtoValidator : AbstractValidator<UpdateAccountDto>
    {
        public UpdateAccountDtoValidator()
        {
            RuleFor(x => x.name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(20).WithMessage("Name length can't be more than 20.");
        }
    }
}