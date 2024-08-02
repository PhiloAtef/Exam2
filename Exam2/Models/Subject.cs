using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Exam? SubjectExam { get; set; }

        public Subject(int id, string name)
        {
            SubjectId = id;
            SubjectName = name;
        }
        public void CreateExam(Exam exam)
        {
            SubjectExam = exam;
            List<Answer> examAnswers = new List<Answer>();
            string answerText = string.Empty;
            Console.Clear();
            for (int i = 0; i < SubjectExam.NumberOfQuestions; i++)
            {
                Console.WriteLine($"{SubjectExam.Questions[i].Header}            {SubjectExam.Questions[i].Mark}");
                Console.WriteLine($"{SubjectExam.Questions[i].Body}");
                Console.WriteLine();
                for (int j = 0; j < 3; j++)
                {
                    if (SubjectExam.Questions[i] is not null ) 
                    {
                        answerText = SubjectExam.Questions[i].AnswerList[j].AnswerText;
                        Console.WriteLine($"{j + 1}-{answerText}");
                    }
                    else
                    {
                        Console.WriteLine($"{j+1}- N/A");
                    }
                }
                Console.WriteLine();
                bool isNumber;
                int answerID;
                do
                {
                    Console.WriteLine("Please Enter the Answer ID (in numbers)");
                    isNumber = int.TryParse(Console.ReadLine(), out answerID);

                } while (!isNumber || answerID < 1 || answerID > 3);
                examAnswers.Add( new Answer() {AnswerId = answerID, AnswerText = answerText});
            }
            
        }

        public override string ToString()
        {
            return $"Subject Id: {SubjectId}, Subject Name: {SubjectName}";
        }
    }
}
