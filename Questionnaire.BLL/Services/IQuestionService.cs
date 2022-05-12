using MongoDB.Bson;
using Questionnaire.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Questionnaire.BLL.Services
{
    public interface IQuestionService
    {
        Task<Question> AddQuestionWithAnswersAsync(Question question);

        Task<Question> GetQuestionAsync(ObjectId id);

        Task<List<Answer>> VoteForQuestionAsync(ObjectId questionId, ObjectId answerId);

        Task<List<Question>> GetQuestionsAsync();
    }
}
