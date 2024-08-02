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
                Console.WriteLine($"{SubjectExam.Questions[i].Header}\t\t\tMark {SubjectExam.Questions[i].Mark}");
                Console.WriteLine($"{SubjectExam.Questions[i].Body}");
                Console.WriteLine();
                if (SubjectExam.Questions[i] is MultiChoiceQuestion)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (SubjectExam.Questions[i] is not null)
                        {
                            answerText = SubjectExam.Questions[i].AnswerList[j].AnswerText;
                            Console.WriteLine($"{j + 1}-{answerText}");
                        }
                        else
                        {
                            Console.WriteLine($"{j + 1}- N/A");
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
                    examAnswers.Add(new Answer() { AnswerId = answerID, AnswerText = SubjectExam.Questions[i].AnswerList.Find(a => a.AnswerId == answerID).AnswerText }); 
                }
                else
                {
                    SubjectExam.Questions[i].DisplayQuestion();
                    int TFAnswerID = GetTFAnswerID();
                    examAnswers.Add(new Answer() { AnswerId = TFAnswerID, AnswerText = SubjectExam.Questions[i].AnswerList.Find(a => a.AnswerId == TFAnswerID).AnswerText });

                }
            }
            GradeExam(SubjectExam, examAnswers);
            
        }
        public void GradeExam(Exam exam, List<Answer> examAnswers)
        {
            int overallgrade = 0;
            int totalgrade = 0;

            if (exam is FinalExam)
            {
                for (int i = 0; i < exam.NumberOfQuestions; i++)
                {
                    totalgrade += exam.Questions[i].Mark;
                    Console.WriteLine($"Question {i + 1} : {exam.Questions[i].Body}");
                    Console.WriteLine($"Your Answer => {examAnswers[i].AnswerText}");
                    Console.WriteLine($"Right Answer => {exam.Questions[i].RightAnswer.AnswerText}");
                    if (examAnswers[i].Equals(exam.Questions[i].RightAnswer))
                    {
                        overallgrade += exam.Questions[i].Mark;
                    }
                }
                Console.WriteLine($"Your Grade is {overallgrade} from {totalgrade}");
            }
            else
            {
                for (int i = 0; i < exam.NumberOfQuestions; i++)
                {
                    Console.WriteLine($"Question {i + 1} : {exam.Questions[i].Body}");
                    Console.WriteLine($"Your Answer => {examAnswers[i].AnswerText}");
                    Console.WriteLine($"Right Answer => {exam.Questions[i].RightAnswer.AnswerText}");
                }
            }
            Console.WriteLine($"Time = ");
            Console.WriteLine("Thank you");
        }

        public override string ToString()
        {
            return $"Subject Id: {SubjectId}, Subject Name: {SubjectName}";
        }

        public static int GetTFAnswerID()
        {
            Console.WriteLine("Please enter the Answer id (1 for True | 2 for False)");
            bool isTrueOrFalse = int.TryParse(Console.ReadLine(), out int TFanswer);
            if (!isTrueOrFalse || TFanswer > 2 || TFanswer < 1)
            {
                LineClear.ClearLine();
                return GetTFAnswerID();
            }

            return TFanswer;
        }
    }
}
