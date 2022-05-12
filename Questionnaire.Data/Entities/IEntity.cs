using MongoDB.Bson;

namespace Questionnaire.Data.Entities
{
    public interface IEntity
    {
        ObjectId Id { get; set; }
    }
}