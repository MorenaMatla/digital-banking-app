using financial_banking.Application.Interfaces;
using financial_banking.Domain.Entities;
using financial_banking.Infra.Data;
using MongoDB.Driver;

namespace financial_banking.Infra.Repository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly IMongoCollection<Account> _accounts;
        private readonly IAccountRepository _accountRepository;
        private readonly ILogger<ITransactionRepository> _logger;
        public TransactionRepository(ILogger<ITransactionRepository> logger, IAccountRepository accountRepository, MongoContext context)
        {
            _logger = logger;
            _accounts = context.Accounts;
            _accountRepository = accountRepository;
        }

        public async Task<decimal> DepositAccountAsync(string accountNumber, decimal amount)
        {
            var account = await _accountRepository.GetAccountByAccountNumberAsync(accountNumber);

            if(account == null)
                return 0;

            var previousBalance = account.Balance;
            account.Balance += amount;

            var transaction = new Transaction
            {
                Description = $"Deposit to {account.Name}",
                Amount = amount,
                PreviousBalance = previousBalance,
                NewBalance = account.Balance,
                Date = DateTime.UtcNow
            };
            account.TransactionHistory.Add(transaction);

            await _accounts.ReplaceOneAsync(a => a.AccountNumber == accountNumber, account);

            return account.Balance;
        }

        public async Task<bool> TransferAsync(string fromAccountNumber, string toAccountNumber, decimal amount)
        {
            var fromAccount = await _accounts.Find(x => x.AccountNumber == fromAccountNumber).FirstOrDefaultAsync();
            var toAccount = await _accounts.Find(x => x.AccountNumber == toAccountNumber).FirstOrDefaultAsync();

            if (fromAccount == null || toAccount == null || fromAccount.Balance - amount < 0) return false;

            var fromAccountPreviousBalance = fromAccount.Balance;
            var toAccountPreviousBalance = toAccount.Balance;

            fromAccount.Balance -= amount;
            toAccount.Balance += amount;


            var transaction = new Transaction
            {
                Description = $"Transfer to {toAccount.Name}",
                Amount = amount,
                PreviousBalance = fromAccountPreviousBalance,
                NewBalance = fromAccount.Balance,
                Date = DateTime.UtcNow
            };
            fromAccount.TransactionHistory.Add(transaction);

            var receiveTransaction = new Transaction
            {
                Description = $"Transfer from {fromAccount.Name}",
                Amount = amount,
                PreviousBalance = toAccountPreviousBalance,
                NewBalance = toAccount.Balance,
                Date = DateTime.UtcNow
            };
            toAccount.TransactionHistory.Add(receiveTransaction);

            await _accounts.ReplaceOneAsync(x => x.AccountNumber == fromAccountNumber, fromAccount);
            await _accounts.ReplaceOneAsync(x => x.AccountNumber == toAccountNumber, toAccount);


            return true;
        }
    }
}