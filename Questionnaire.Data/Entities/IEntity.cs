using MongoDB.Bson;

namespace Questionnaire.Data.Entities
{
    public interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }

    public interface IEntity : IEntity<ObjectId>
    {
    }
}