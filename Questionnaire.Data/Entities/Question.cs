using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace Questionnaire.Data.Entities
{
    public class Question : IEntity
    {
        public ObjectId Id { get; set; }

        public string Text { get; set; }

        public QuestionType Type { get; set; }

        public IEnumerable<Answer> Answers { get; set; }  
    }

    public enum QuestionType
    {
        Poll = 1,
        Trivia = 2
    }
}
