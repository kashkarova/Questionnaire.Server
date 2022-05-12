using Questionnaire.Data.Entities;
using Questionnaire.Server.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Questionnaire.BLL.Models
{
    public class QuestionModel
    {
        [Required]
        public string Text { get; set; }

        [Required]
        public QuestionType Type { get; set; }

        [Required]
        public IEnumerable<AnswerModel> Answers { get; set; }
    }
}
