using MongoDB.Bson.Serialization.Attributes;

namespace financial_banking.Domain.Entities
{
    public class Account
    {
        [BsonId]
        public string AccountNumber { get; set; }
        public string Name { get; set; }
        public decimal Balance { get; set; }
        public List<Transaction> TransactionHistory { get; set; } = new List<Transaction>();
    }
}