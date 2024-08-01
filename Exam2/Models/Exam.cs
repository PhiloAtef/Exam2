using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2.Models
{
    public abstract class Exam : ICloneable, IComparable<Exam>
    {
        public DateTime TimeOfExam { get; set; }
        public int NumberOfQuestions { get; set; }
        public List<Question> Questions { get; set; }
        public Subject ExamSubject { get; set; }
        public int Duration { get; set; }

        public Exam(DateTime time, int numQuestions, Subject subject, int duration)
        {
            TimeOfExam = time;
            NumberOfQuestions = numQuestions;
            Questions = new List<Question>();
            ExamSubject = subject;
            Duration = duration;
        }

        public abstract void ShowExam();

        public int CompareTo(Exam? other)
        {
            throw new NotImplementedException();
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }
    }
}
