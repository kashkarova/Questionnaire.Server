namespace Questionnaire.BLL.Models
{
    public class AnswerDisplayModel
    {
        public string Id { get; set; }

        public string Text { get; set; }

        public bool? IsCorrect { get; set; }

        public int Vote { get; set; }
    }
}
