﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2.Models
{
    internal class FinalExam: Exam
    {
        public FinalExam(DateTime time, int numQuestions, Subject subject) : base(time, numQuestions, subject) { }

        public override void ShowExam()
        {
            foreach (var question in Questions)
            {
                question.DisplayQuestion();
            }
        }
    }
}
