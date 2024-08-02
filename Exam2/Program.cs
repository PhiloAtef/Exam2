using Exam2.Models;

namespace Exam2
{
    internal class Program
    {
        //do not
        //forget
        //make
        //it
        //so
        //that
        //practical
        //exam
        //only
        //takes 
        //MCQ
        //moheeeeemmmmm

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


            if (exam is FinalExam)
            {
                for (int i = 0; i < exam.NumberOfQuestions; i++)
                {
                    if (GetQuestionType() == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("MCQ Question");
                        string MCQBody = GetQuestionBody();
                        int MCQMark = GetQuestionMark();
                        Question question = new MultiChoiceQuestion("MCQ", MCQBody, MCQMark);
                        // i < 3 can be replaced by a variable given to the function if we want to set number of answers dynamically but we will assume all MCQs have 3 answers only
                        for (int j = 0; j < 3; j++)
                        {
                            Console.WriteLine($"Enter choice number {j + 1} :");
                            string answerText = Console.ReadLine() ?? string.Empty;
                            question.AnswerList.Add(new Answer(j + 1, answerText));
                        }
                        Console.WriteLine("Enter right answer ID:");
                        bool isNumber = int.TryParse(Console.ReadLine(), out var rightAnswerID);
                        if (!isNumber || rightAnswerID > 3 || rightAnswerID < 1)
                        {
                            Console.WriteLine("Not a number inputted or number not in range, Enter a correct answer");
                            bool secondIsNumber = int.TryParse(Console.ReadLine(), out var secondRightAnswerID);
                            rightAnswerID = secondRightAnswerID;
                        }
                        question.RightAnswer = question.AnswerList[rightAnswerID - 1];

                        exam.Questions.Add(question);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("TrueOrFalse Question");
                        string TFBody = GetQuestionBody();
                        int TFMark = GetQuestionMark();
                        Question question = new TrueOrFalseQuestion("TrueOrFalse",TFBody, TFMark);
                        question.RightAnswer = question.AnswerList[GetTrueOrFalseRightAnswer()-1];
                        exam.Questions.Add(question);


                    }
                } 
            }

            Console.Clear();
            Console.WriteLine("Do you want to start Exam (Y|N)");
            ConsoleKeyInfo cki = Console.ReadKey();
            if (cki.Key.ToString().ToLower() == "y")
            {

                subject.CreateExam(exam);

            }
            else if(cki.Key.ToString().ToLower() == "n")
            {
                exam.ShowExam();
            }
            else
            {
                return;
            }
        }

        #region Get functions
        public static int GetTrueOrFalseRightAnswer()
        {
            Console.WriteLine("Please enter the right answer id (1 for True | 2 for False)");
            bool isTrueOrFalse = int.TryParse(Console.ReadLine(), out int TFanswer);
            if (!isTrueOrFalse || TFanswer > 2 || TFanswer < 1)
            {
                Console.Clear();
                return GetTrueOrFalseRightAnswer();
            }

            return TFanswer;
        }

        public static int GetQuestionMark()
        {
            Console.WriteLine("Please enter question mark");
            bool isNumber = int.TryParse(Console.ReadLine(), out int questionMark);
            if (!isNumber)
            {
                LineClear.ClearLine();
                return GetQuestionMark();
            }
            return questionMark;
        }

        public static string GetQuestionBody()
        {
            Console.WriteLine("Please Enter Question Body");
            string body = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrEmpty(body))
            {
                LineClear.ClearLine();
                return GetQuestionBody();
            }
            return body;
        }

        public static int GetQuestionType()
        {
            Console.Clear();
            Console.WriteLine("Please enter type of question (1 for MCQ | 2 for TrueOrFalse)");
            bool isNumber = int.TryParse(Console.ReadLine(), out int questionType);
            if (!isNumber || questionType > 2 || questionType < 1)
            {
                LineClear.ClearLine();
                return GetQuestionType();
            }
            return questionType;
        }

        public static int GetNumberOfQuestions()
        {
            Console.WriteLine("Please Enter the Number of Questions");
            bool isNumber = int.TryParse(Console.ReadLine(), out int questionsNumber);
            if (!isNumber)
            {
                LineClear.ClearLine();
                return GetNumberOfQuestions();
            }
            Console.Clear();
            return questionsNumber;
        }

        public static int GetExamDuration()
        {
            Console.WriteLine("Enter the time for the exam (from 30 to 180 minutes)");
            bool isDurationCorrect = int.TryParse(Console.ReadLine(), out int examDuration);
            if (!isDurationCorrect || examDuration < 30 || examDuration > 180)
            {
                LineClear.ClearLine();
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
        #endregion


    }
}
