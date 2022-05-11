namespace Questionnaire.BLL.Models
{
    public class Answer
    {
        string Text { get; set; }

        public bool IsCorrect { get; private set; }

        public Answer()
        {
            IsCorrect = false;
        }
    }
}
