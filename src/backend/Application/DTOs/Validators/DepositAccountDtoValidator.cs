using FluentValidation;

namespace financial_banking.Application.DTOs.Validators
{
    public class DepositAccountDtoValidator : AbstractValidator<DepositAccountDto>
    {
        public DepositAccountDtoValidator()
        {
            RuleFor(x => x.accountNumber)
                .NotEmpty().WithMessage("Account Number is required")
                .Length(10).WithMessage("Account Number length must be 10.");

            RuleFor(x => x.amount)
                .GreaterThan(0).WithMessage("Amount must be greater than 0");
        }
    }
}