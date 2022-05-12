using Questionnaire.Data.Entities;
using Questionnaire.Server.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Questionnaire.BLL.Models
{
    public class QuestionCreateModel
    { 
        [Required]
        public string Text { get; set; }

        [Required]
        public QuestionType Type { get; set; }

        [Required]
        public IEnumerable<AnswerCreateModel> Answers { get; set; }
    }
}
