using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace EXAM_CODE.Models
{
    public class MCQQuestion : Question
    {
        public MCQQuestion(string header, string body, int mark, List<Answer> answers, int rightId)
            : base(header, body, mark, answers, rightId)
        {
        }

        public static MCQQuestion CreateQuestion(int QNUM)
        {
            Console.WriteLine($"Question {QNUM} (MCQ)");
            Console.Write("Body: ");
            string? body = Console.ReadLine();

            int numChoices = ReadInt("Number of choices: ", 2);
            List<Answer> answers = new List<Answer>();

            for (int i = 0; i < numChoices; i++)
            {
                Console.Write($"Enter choice {i + 1}: ");
                string choice = Console.ReadLine() ?? "";
                answers.Add(new Answer(i + 1, choice));
            }

            int correctAnswer = ReadInt("ID of right answer: ", 1, numChoices);
            int mark = ReadInt("Mark of question: ", 1);

            return new MCQQuestion("MCQ", body!, mark, answers, correctAnswer);
        }

        public override void ShowQuestion()
        {
            Console.WriteLine($"[Q] {Body} ({Mark} Marks)");
            foreach (var answer in Answers)
                Console.WriteLine(answer);
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
    

