using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAM_CODE.Models
{
    public class Answer  
    {
       public int AnswerId { get; set; }

        public string AnswerText { get; set; }

        public Answer (int Id, string Text)
        {
            AnswerId = Id;
            AnswerText = Text;
        }
        

        public override string ToString() => $"{AnswerId}.{AnswerText}";
      
    }
}
