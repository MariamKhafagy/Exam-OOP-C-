using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace EXAM_CODE.Models
{
    public abstract class Question    
    { 
      public string Header { get; set; }

        public string Body { get; set; }

        public int Mark { get; set; } 

        public List<Answer> Answers { get; set; }
        public Answer? UserAnswer { get; set; }
        public int RightAnswerId { get; set; }

        protected Question( string header ,string body , int mark,List<Answer> answers,int rightAnswer) 
        {
            Header = header;
            Body = body;
            Mark = mark;
            Answers = answers;
            RightAnswerId = rightAnswer;
        }
        public void SetUserAnswer(int answerId)
        {
            var answer = Answers.Find(a => a.AnswerId == answerId);
            if (answer != null) UserAnswer = answer;
            else UserAnswer = null;
        }

        public abstract void ShowQuestion();
    
    
    }
}
