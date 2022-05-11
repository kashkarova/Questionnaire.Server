using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.BLL.Models
{
    public class Trivia : Question
    {
        private IEnumerable<Answer> _answers;
        
        public override IEnumerable<Answer> Answers 
        { 
            get => throw new NotImplementedException(); 
            set => throw new NotImplementedException(); 
        }
    }
}
