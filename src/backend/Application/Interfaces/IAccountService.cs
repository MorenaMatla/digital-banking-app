
using financial_banking.Application.DTOs;
using financial_banking.Domain.Entities;

namespace financial_banking.Application.Interfaces
{
    public interface IAccountService
    {
        Task<bool> DeleteAccountAsync(string accountNumber);
        Task<bool> UpdateAccountAsync(string accountNumber, UpdateAccountDto account);
        Task<bool> CreateAccountAsync(string accountNumber, string name);
        Task<decimal> GetBalanceAsync(string accountNumber);
        Task<List<Transaction>> GetTransactionHistoryAsync(string accountNumber);
        Task<Account> GetAccountAsync(string accountNumber);
    }
}