using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using static System.Console;

namespace hw
{
    public class Quiz
    {
        public string Category { get; set; }
        public List<Question> Questions { get; set;}
        public int CountOfQuestions { get; set; }

        public Quiz(string category, List<Question> questions){
            Category = category;
            Questions = questions;
        }

          public Quiz(string category, int count, List<Question> questions){
            Category = category;
            Questions = questions;
            CountOfQuestions = count;
        }


    }
}