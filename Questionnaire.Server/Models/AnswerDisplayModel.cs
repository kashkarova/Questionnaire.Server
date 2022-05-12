using System.ComponentModel.DataAnnotations;

namespace Questionnaire.BLL.Models
{
    public class AnswerDisplayModel
    {
        [Required]
        public string Text { get; set; }

        public bool? IsCorrect { get; set; }

        public int Vote { get; set; }
    }
}
