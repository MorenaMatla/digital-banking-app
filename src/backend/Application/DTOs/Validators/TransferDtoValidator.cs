using FluentValidation;

namespace financial_banking.Application.DTOs.Validators
{
    public class TransferDtoValidator : AbstractValidator<TransferDto>
    {
        public TransferDtoValidator()
        {
            RuleFor(x => x.fromAccountNumber)
                .NotEmpty().WithMessage("From Account Number is required")
                .Length(10).WithMessage("From Account Number length must be 10.");

            RuleFor(x => x.toAccountNumber)
                .NotEmpty().WithMessage("To Account Number is required")
                .Length(10).WithMessage("To Account Number length must be 10.");

            RuleFor(x => x.amount)
                .GreaterThan(0).WithMessage("Amount must be greater than 0");
        }
    }
}