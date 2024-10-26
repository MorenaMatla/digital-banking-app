using financial_banking.Application.DTOs;
using financial_banking.Application.Interfaces;
using financial_banking.Domain.Entities;

namespace financial_banking.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ILogger<IAccountService> _logger;

        public AccountService(ILogger<IAccountService> logger, IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
            _logger = logger;
        }
        public async Task<bool> CreateAccountAsync(string accountNumber, string name)
        {
            Account newAccount = new Account {AccountNumber = accountNumber, Balance = 0, Name = name};
            return await _accountRepository.CreateAccountAsync(newAccount);
        }
        public async Task<Account> GetAccountAsync(string accountNumber)
        {
            return await _accountRepository.GetAccountByAccountNumberAsync(accountNumber);
        }
        public async Task<bool> UpdateAccountAsync(string accountNumber, UpdateAccountDto updateAccountDto)
        {
            var account = await GetAccountAsync(accountNumber);
            if (account == null) return false;

            account.Name = updateAccountDto.name;

            return await _accountRepository.UpdateAccountAsync(accountNumber, account);
        }

        public async Task<bool> DeleteAccountAsync(string accountNumber)
        {
            return await _accountRepository.DeleteAccountAsync(accountNumber);
        }

        public Task<decimal> DepositAsync(string accountNumber, decimal amount)
        {
            throw new NotImplementedException();
        }

        public Task<decimal> GetBalanceAsync(string accountNumber)
        {
            throw new NotImplementedException();
        }

        public Task<bool> TransferAsync(string fromAccountNumber, string toAccountNumber, decimal amount)
        {
            throw new NotImplementedException();
        }


    }
}