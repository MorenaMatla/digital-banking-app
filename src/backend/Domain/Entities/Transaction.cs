namespace financial_banking.Domain.Entities
{
    public class Transaction
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public decimal PreviousBalance { get; set; }
        public decimal NewBalance { get; set; }
        public DateTime Date { get; set; }
    }
}