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

        }
        public override void DisplayQuestion()
        {
            Console.WriteLine($"{Header}\n{Body}\n1. True\n2. False");
        }
    }
}
