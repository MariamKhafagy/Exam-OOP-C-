using EXAM_CODE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAM_CODE.Exams
{
    public class FinalExam : Exam
    {
        public FinalExam(DateTime time, int numberOfQuestions, List<Question> question) : base(time, numberOfQuestions, question)
        {
        }

        public override void ShowExam()
        {
            Console.WriteLine("\n--- Final Exam ---\n");

            int qNum = 1;
            foreach (var question in Questions)
            {
                Console.WriteLine($"Question {qNum}: {question.Body}");

                string studentAnswer = question.UserAnswer != null ? question.UserAnswer.AnswerText : "No answer";
                Console.WriteLine($"Student Answer: {studentAnswer}");

                var correctAnswer = question.Answers.Find(a => a.AnswerId == question.RightAnswerId)?.AnswerText ?? "Unknown";
                Console.WriteLine($"Correct Answer: {correctAnswer}");

                Console.WriteLine($"Mark: {question.Mark}\n");

                qNum++;
            }
            Console.WriteLine($"Total Score: {CalculateTotalMarks()}/{Questions.Sum(q => q.Mark)}");
        }
    }
}
