using Questionnaire.Data.Entities;
using System.Collections.Generic;

namespace Questionnaire.BLL.Models
{
    public class QuestionDisplayModel
    {
        public string Id { get; set; }

        public string Text { get; set; }

        public QuestionType Type { get; set; }

        public IEnumerable<AnswerDisplayModel> Answers { get; set; }
    }
}
