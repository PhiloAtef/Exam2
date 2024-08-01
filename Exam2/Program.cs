using Exam2.Models;

namespace Exam2
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Subject subject = new Subject(1, "Mathematics");
            int examType = GetExamType();
            DateTime examTime = DateTime.Now;
            int examDuration = GetExamDuration();
            int questionsNumber = GetNumberOfQuestions();

            Exam exam;

            if (examType == 1) 
            {
                exam = new FinalExam(examTime, questionsNumber, subject,examDuration);
            }
            else
            {
                exam = new PracticalExam(examTime, questionsNumber, subject, examDuration);
            }
            

            for (int i = 0; i < exam.NumberOfQuestions; i++)
            {
                
            }

        }
        public static int GetNumberOfQuestions()
        {
            Console.WriteLine("Please Enter the Number of Questions");
            bool isNumber = int.TryParse(Console.ReadLine(), out int questionsNumber);
            if (!isNumber)
            {
                ClearLine();
                return GetNumberOfQuestions();
            }
            return questionsNumber;
        }
        public static int GetExamDuration()
        {
            Console.WriteLine("Enter the time for the exam (from 30 to 180 minutes)");
            bool isDurationCorrect = int.TryParse(Console.ReadLine(), out int examDuration);
            if (!isDurationCorrect || examDuration < 30 || examDuration > 180)
            {
                ClearLine();
                return GetExamDuration();
            }

            return examDuration;
        }

        public static int GetExamType()
        {
            Console.WriteLine("Please enter the type of exam (1 for Practical | 2 for final)");
            bool isTypeCorrect = int.TryParse(Console.ReadLine(), out int examType);
            if (!isTypeCorrect || examType > 2 || examType < 1)
            {
                Console.Clear();
                return GetExamType();
            }

            return examType;

        }

        public static void ClearLine()
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.BufferWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
        }
    }
}
