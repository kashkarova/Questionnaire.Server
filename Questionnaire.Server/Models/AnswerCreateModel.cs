using System.ComponentModel.DataAnnotations;

namespace Questionnaire.Server.Models
{
    public class AnswerCreateModel
    {
        [Required]
        public string Text { get; set; }

        public bool? IsCorrect { get; set; }
    }
}
