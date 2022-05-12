using MongoDB.Driver;
using Questionnaire.Data.Entities;

namespace Questionnaire.Data.Repositories
{
    public class QuestionRepository : BaseMongoRepository<Question>
    {
        private const string QuestionCollectionName = "Question";

        private readonly DbContext _dbContext;

        public QuestionRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        protected override IMongoCollection<Question> Collection 
            => _dbContext.MongoDatabase.GetCollection<Question>(QuestionCollectionName);
    }
}
