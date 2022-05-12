using MongoDB.Bson;
using Questionnaire.Data.Entities;
using Questionnaire.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Questionnaire.BLL.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IMongoRepository<Question> _questionRepository;

        public QuestionService(IMongoRepository<Question> questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public async Task<Question> AddQuestionWithAnswers(Question question)
        {
            if (question.Type == QuestionType.Trivia && !question.Answers.Any(a => a.IsCorrect == true))
            {
                throw new ArgumentException("Trivia questions should have correct answers!");
            }

            if (question.Type == QuestionType.Poll && question.Answers.Any(a => a.IsCorrect == true))
            {
                throw new ArgumentException("Poll questions shouldn`t have correct answers!");
            }

            foreach (var answer in question.Answers)
            {
                answer.Id = ObjectId.GenerateNewId();
            }

            var addedQuestion = await _questionRepository.SaveAsync(question);

            return addedQuestion;
        }

        public async Task<Question> GetQuestion(ObjectId id)
        {
            return await _questionRepository.GetByIdAsync(id);
        }

        public async Task<List<Answer>> VoteForQuestion(ObjectId questionId, ObjectId answerId)
        {
            var question = await _questionRepository.GetByIdAsync(questionId);

            var answer = question.Answers.FirstOrDefault(a => a.Id.Equals(answerId));

            if (answer == null)
            {
                throw new ArgumentException("Answer hasn`t been found!");
            }

            answer.Vote++;

            var updatedQuestion = await _questionRepository.SaveAsync(question);

            return updatedQuestion.Answers.ToList();
        }
    }
}
