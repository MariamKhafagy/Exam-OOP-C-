using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAM_CODE.Models
{
    public class TrueFalseQuestion : Question
    {
        public TrueFalseQuestion(string body, int mark, int rightAnswer)
            : base("True/False", body, mark, new List<Answer> { new Answer(1, "True"), new Answer(2, "False") }, rightAnswer)
        {
        }

        public static TrueFalseQuestion CreateQuestion(int QNUM)
        {
            Console.WriteLine($"Question {QNUM} True or False");
            Console.Write("Body: ");
            string? body = Console.ReadLine();

            Console.Write("Mark of question: ");
            int mark = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("ID of right answer (1=True, 2=False): ");
            int correctAnswer = int.Parse(Console.ReadLine() ?? "0");

            return new TrueFalseQuestion(body!, mark, correctAnswer);
        }

        public override void ShowQuestion()
        {
            Console.WriteLine($"[Q]  {Body}({Mark} Marks)");

            foreach (var answer in Answers)
            {
                Console.WriteLine($"{answer.AnswerId}.{answer.AnswerText}");
            }
        }
        private static int ReadInt(string prompt, int min = int.MinValue, int max = int.MaxValue)
        {
            int value;
            do
            {
                Console.Write(prompt);
            } while (!int.TryParse(Console.ReadLine(), out value) || value < min || value > max);
            return value;
        }
    }
}
