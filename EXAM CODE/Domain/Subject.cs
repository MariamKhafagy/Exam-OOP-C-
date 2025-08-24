using EXAM_CODE.Exams;
using EXAM_CODE.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Quic;
using System.Text;
using System.Threading.Tasks;

namespace EXAM_CODE.Domain
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Exam? Exam { get; set; }

        public Subject(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void CreateExam()
        {
            Console.Write(" a) Practical - b) Final : ");
            string examType = Console.ReadLine()?.ToLower() ?? "b";

            int numberQuestions = ReadInt("Number of questions: ", 1);

            List<Question> questions = new List<Question>();

            if (examType[0] == 'a') // Practical
            {
                for (int i = 0; i < numberQuestions; i++)
                {
                    var q = MCQQuestion.CreateQuestion(i + 1); // Practical exam uses MCQ only
                    questions.Add(q);
                }
                Exam = new PracticalExam(DateTime.Now, numberQuestions, questions);
            }
            else if (examType[0] == 'b') // Final
            {
                for (int i = 0; i < numberQuestions; i++)
                {
                    Console.Write($"Question type {i + 1} a) MCQ - b) True/False : ");
                    string input = Console.ReadLine()?.ToLower() ?? "a";

                    if (input[0] == 'a')
                        questions.Add(MCQQuestion.CreateQuestion(i + 1));
                    else
                        questions.Add(TrueFalseQuestion.CreateQuestion(i + 1));
                }
                Exam = new FinalExam(DateTime.Now, numberQuestions, questions);
            }
        }

        public void ShowExam()
        {
            if (Exam == null)
            {
                Console.WriteLine("No exam created for this subject.");
                return;
            }

            Console.WriteLine($"Subject : {Name} (Id: {Id})");
            Console.Write("Start exam? a)Yes - b)No: ");
            string go = Console.ReadLine()?.ToLower() ?? "b";

            if (go[0] != 'a')
            {
                Console.WriteLine("Exam canceled.");
                return;
            }

            Exam.Time = DateTime.Now;
            int totalPossible = 0;
            int studentScore = 0;

            for (int i = 0; i < Exam.NumberOfQuestions; i++)
            {
                var question = Exam.Questions[i];
                Console.WriteLine($"\nQuestion {i + 1}: {question.Body}");

                foreach (var answer in question.Answers)
                    Console.WriteLine(answer);

                int answerId = ReadInt("Enter your answer ID: ", 1, question.Answers.Count);
                question.SetUserAnswer(answerId);

                totalPossible += question.Mark;
                if (question.UserAnswer != null && question.UserAnswer.AnswerId == question.RightAnswerId)
                    studentScore += question.Mark;

                DateTime finish = DateTime.Now;
                TimeSpan duration = finish - Exam.Time;

                Console.WriteLine($"Time so far: {duration.Minutes} minutes {duration.Seconds} seconds");
                Console.WriteLine($"Your current score: {studentScore} / {totalPossible}\n");
            }

            Console.WriteLine("\nExam finished!\n");
            Exam.ShowExam();
        }

        private int ReadInt(string prompt, int min = int.MinValue, int max = int.MaxValue)
        {
            int value;
            while (true)
            {
                Console.Write(prompt);
                string? input = Console.ReadLine();
                if (int.TryParse(input, out value) && value >= min && value <= max)
                    return value;
                Console.WriteLine("Invalid input. Try again.");
            }
        }
    }
}

