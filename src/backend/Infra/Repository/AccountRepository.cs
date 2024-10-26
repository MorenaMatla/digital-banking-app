using financial_banking.Application.Interfaces;
using financial_banking.Domain.Entities;
using financial_banking.Infra.Data;
using MongoDB.Driver;

namespace financial_banking.Infra.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly IMongoCollection<Account> _accounts;
        private readonly ILogger<IAccountRepository> _logger;
        public AccountRepository(ILogger<IAccountRepository> logger, MongoContext context)
        {
            _logger = logger;
            _accounts = context.Accounts;
        }

        public async Task<Account> GetAccountByAccountNumberAsync(string accountNumber)
        {
            return await _accounts.Find<Account>(account => account.AccountNumber == accountNumber).FirstOrDefaultAsync();
        }

        public async Task<bool> CreateAccountAsync(Account account)
        {
            try
            {
                await _accounts.InsertOneAsync(account);
                return true;
            }
            catch (MongoWriteException ex) when (ex.WriteError.Category == ServerErrorCategory.DuplicateKey)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> DeleteAccountAsync(string accountNumber)
        {
            try
            {
                var result = await _accounts.DeleteOneAsync(acc => acc.AccountNumber == accountNumber);
                return result.DeletedCount > 0;
            }
            catch (MongoWriteException ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateAccountAsync(string accountNumber, Account account)
        {
            try
            {
                var result = await _accounts.ReplaceOneAsync(acc => acc.AccountNumber == accountNumber, account);
                return result.ModifiedCount > 0;
            }
            catch(MongoWriteException ex)
            {
                _logger.LogError(ex.Message);
                return false;
            }
        }
    }
}