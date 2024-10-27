using financial_banking.Application.Interfaces;

namespace financial_banking.Application.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly ILogger<ITransactionRepository> _logger;

        public TransactionService(ILogger<ITransactionRepository> logger, ITransactionRepository transactionRepository)
        {
            _logger = logger;
            _transactionRepository = transactionRepository;
        }


        public async Task<decimal> DepositAccountAsync(string accountNumber, decimal amount)
        {
            return await _transactionRepository.DepositAccountAsync(accountNumber, amount);
        }

        public async Task<bool> TransferAsync(string fromAccountNumber, string toAccountNumber, decimal amount)
        {
            return await _transactionRepository.TransferAsync(fromAccountNumber, toAccountNumber, amount);
        }
    }
}