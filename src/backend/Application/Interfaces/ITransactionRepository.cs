using financial_banking.Domain.Entities;

namespace financial_banking.Application.Interfaces
{
    public interface ITransactionRepository
    {
        Task<decimal> DepositAccountAsync(string accountNumber, decimal amount);
        Task<bool> TransferAsync(string fromAccountNumber, string toAccountNumber, decimal amount);
    }
}