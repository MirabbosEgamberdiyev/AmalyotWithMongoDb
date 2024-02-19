using CRM.Data.Entities;
using MongoDB.Driver;

namespace CRM.Data
{
    public class InventoryDatabase
    {
        public IMongoDatabase mongoDatabase { get; set; }
        public InventoryDatabase(string connectionString, string databaseName)
        {
            var connection = new MongoClient(connectionString);
            mongoDatabase = connection.GetDatabase(databaseName);
        }
        public IMongoCollection<Fan> Fans =>
            mongoDatabase.GetCollection<Fan>("Fans");
        public IMongoCollection<Teacher> Teachers =>
            mongoDatabase.GetCollection<Teacher>("Teachers");
    }

}
