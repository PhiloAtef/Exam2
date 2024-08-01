using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2.Models
{
    public class PracticalExam : Exam
    {
        public PracticalExam(DateTime time, int numQuestions, Subject subject) : base(time, numQuestions, subject) { }

        public override void ShowExam()
        {
            foreach (var question in Questions)
            {
                question.DisplayQuestion();
            }
            Console.WriteLine("Right answers will be shown after finishing the exam.");
        }
    }
}
