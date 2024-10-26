using FluentValidation;

namespace financial_banking.Application.DTOs.Validators
{
    public class CreateAccountDtoValidator : AbstractValidator<CreateAccountDto>
    {
        public CreateAccountDtoValidator()
        {
            RuleFor(x => x.accountNumber)
                .NotEmpty().WithMessage("Account Number is required")
                .Length(10).WithMessage("Account Number length must be 10.");

            RuleFor(x => x.name)
                .NotEmpty().WithMessage("Name is required")
                .MaximumLength(20).WithMessage("Name length can't be more than 20.");
        }
    }
}