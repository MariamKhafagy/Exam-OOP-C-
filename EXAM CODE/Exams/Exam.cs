using EXAM_CODE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAM_CODE.Exams
{
    public  abstract class Exam
    {
        public DateTime Time { get; set;}

        public int NumberOfQuestions { get; set;}
        public List<Question> Questions { get; set; }= new List<Question>();

        protected Exam (DateTime time , int numberOfQuestions,List<Question> question) 
        {
            Time = time;
            NumberOfQuestions = numberOfQuestions;
            Questions = question;
        }
        public abstract void ShowExam();
        public int CalculateTotalMarks()
        {
            int total = 0;
            foreach (var q in Questions)
                if (q.UserAnswer != null && q.UserAnswer.AnswerId == q.RightAnswerId)
                    total += q.Mark;
            return total;
        }

    }
}
