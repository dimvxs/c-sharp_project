using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hw
{
    public class Question
    {
        public string Text { get; set; }
        public List<string> Options { get; set; }
        public List<int> CorrectAnswers { get; set; }

        public Question(string text, List<string> options, List<int> answers){
            Text = text;
            Options = options;
            CorrectAnswers = answers;

    }


        public override string ToString()
        {
            return $"Вопрос: {Text}, Варианты ответов: {string.Join(", ", Options)}";
        }
    }

    
}