namespace financial_banking.Application.Interfaces
{
    public interface ITransactionService
    {
        Task<decimal> DepositAccountAsync(string accountNumber, decimal amount);
        Task<bool> TransferAsync(string fromAccountNumber, string toAccountNumber, decimal amount);
    }
}