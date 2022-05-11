using System.Collections.Generic;

namespace Questionnaire.BLL.Models
{
    public abstract class Question
    {
        public string Text { get; set; }

        public abstract IEnumerable<Answer> Answers { get; set; }
    }
}
