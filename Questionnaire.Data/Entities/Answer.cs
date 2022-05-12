using MongoDB.Bson;

namespace Questionnaire.Data.Entities
{
    public class Answer : IEntity
    {
        public ObjectId Id { get; set; }

        public string Text { get; set; }

        public bool? IsCorrect { get; set; }

        public int Vote { get; set; }
    }
}
