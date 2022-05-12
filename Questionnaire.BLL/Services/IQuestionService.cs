using MongoDB.Bson;
using Questionnaire.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Questionnaire.BLL.Services
{
    public interface IQuestionService
    {
        Task<Question> AddQuestionWithAnswers(Question question);

        Task<Question> GetQuestion(ObjectId id);

        Task<List<Answer>> VoteForQuestion(ObjectId questionId, ObjectId answerId);
    }
}
