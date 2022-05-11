using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.Data.Entities
{
    public class Question
    {
        public Guid Id { get; set; }

        public string Text { get; set; }

        public QuestionType Type { get; set; }

        public string Answer { get; set; }
    }
}
