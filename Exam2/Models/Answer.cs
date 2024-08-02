using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2.Models
{
    //Answers are used as holders for the answers with their ID to be fed to question

    public struct Answer : IEquatable<Answer>
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; set; }

        public Answer(int id, string text)
        {
            AnswerId = id;
            AnswerText = text;
        }

        //overriding ToString() for better readability
        public override string ToString()
        {
            return $"Answer of {AnswerId}: {AnswerText}";
        }

        public bool Equals(Answer other)
        {
            if (this.AnswerText.Equals(other.AnswerText, StringComparison.OrdinalIgnoreCase))
            {

                return true;
            }
            return false;
        }
    }
}
