using financial_banking.Domain.Entities;

namespace financial_banking.Application.Interfaces
{
    public interface IAccountRepository
    {
        Task<bool> CreateAccountAsync(Account account);
        Task<Account> GetAccountByAccountNumberAsync(string accountNumber);
        Task<bool> UpdateAccountAsync(string accountNumber, Account account);
        Task<bool> DeleteAccountAsync(string accountNumber);
    }
}