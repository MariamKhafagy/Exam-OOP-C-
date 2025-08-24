using EXAM_CODE.Domain;
using EXAM_CODE.Exams;
using EXAM_CODE.Models;

namespace EXAM_CODE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject(5,"Math");
            subject.CreateExam();
            subject.ShowExam();

           
        }
    }
}
