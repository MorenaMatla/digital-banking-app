using financial_banking.Domain.Entities;
using MongoDB.Driver;

namespace financial_banking.Infra.Data
{
    public class MongoContext
    {
        private readonly IMongoDatabase _database;

        public MongoContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("MongoDb"));
            _database = client.GetDatabase(configuration["DatabaseName"]);

            var accountCollection = _database.GetCollection<Account>("Accounts");
            var indexKeys = Builders<Account>.IndexKeys.Ascending(account => account.AccountNumber);
            var indexModel = new CreateIndexModel<Account>(indexKeys, new CreateIndexOptions
            {
                Unique = true
            });
            accountCollection.Indexes.CreateOneAsync(indexModel);
        }

        public IMongoCollection<Account> Accounts => _database.GetCollection<Account>("Accounts");
    
    }
}