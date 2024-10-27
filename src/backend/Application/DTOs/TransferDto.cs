namespace financial_banking.Application.DTOs
{
    public class TransferDto
    {
        public string fromAccountNumber {get; set;}
        public string toAccountNumber {get; set;}
        public decimal amount {get; set;}
    }
}