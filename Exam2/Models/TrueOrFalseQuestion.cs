using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2.Models
{
    internal class TrueOrFalseQuestion : Question
    {
        public TrueOrFalseQuestion(string header, string body, int mark) : base(header, body, mark) 
        {
            this.AnswerList.Add(new Answer(1,"True"));
            this.AnswerList.Add(new Answer(2, "False"));
        }
        public override void DisplayQuestion()
        {
            Console.WriteLine("1-True\n2-False");
        }
    }
}
