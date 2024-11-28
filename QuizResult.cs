using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hw
{
    public class QuizResult
    {
 
    public string QuizName { get; set; }
    public int Score { get; set; }
    public DateTime DateTaken { get; set; }

    public QuizResult(string quizName, int score, DateTime dateTaken)
    {
        QuizName = quizName;
        Score = score;
        DateTaken = dateTaken;
    }

    
}
    }
