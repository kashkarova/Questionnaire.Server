using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Questionnaire.Data
{
    public class DbContext
    {
        public DbContext(IConfiguration configuration)
        {
            var url = configuration.GetConnectionString("MongoDB");

            var mongoUrl = new MongoUrl(url);
            var client = new MongoClient(mongoUrl);
            MongoDatabase = client.GetDatabase(mongoUrl.DatabaseName);
        }

        public IMongoDatabase MongoDatabase { get; }
    }
}