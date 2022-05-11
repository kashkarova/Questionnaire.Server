using System;
using System.Collections.Generic;

namespace Questionnaire.BLL.Models
{
    public class Poll : Question
    {
        public override IEnumerable<Answer> Answers 
        { 
            get => throw new NotImplementedException(); 
            set => throw new NotImplementedException(); 
        }
    }
}
