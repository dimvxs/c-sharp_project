using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Formats.Asn1;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;

namespace hw
{
    public class ManageQuiz
    {
         private List<Quiz> quizzes; 
         private List<Quiz> predefinedQuizzes;
         private string Name { get; set; }
         private DateTime Date { get; set; }

         public ManageQuiz(){
         quizzes = new List<Quiz>(); 
         predefinedQuizzes =
         [
             new Quiz("История", 20, new List<Question>
               {
new Question("Какая река является самой длинной в мире?", new List<string> { "Нил", "Амазонка", "Янцзы" }, new List<int> { 0 }),
new Question("Какая страна самая большая по площади?", new List<string> { "Россия", "Канада", "США" }, new List<int> { 0 }),
new Question("Какой океан самый глубокий?", new List<string> { "Тихий", "Атлантический", "Индийский" }, new List<int> { 0 }),
new Question("Какая страна имеет наибольшее количество островов?", new List<string> { "Швеция", "Филиппины", "Индонезия" }, new List<int> { 0 }),
new Question("Где находится гора Эверест?", new List<string> { "Непал", "Китай", "Индия" }, new List<int> { 0 }),
new Question("Какое озеро самое глубокое в мире?", new List<string> { "Байкал", "Каспийское", "Гранд-Лейк" }, new List<int> { 0 }),
new Question("Какой континент самый маленький по площади?", new List<string> { "Океания", "Антарктида", "Евразия" }, new List<int> { 0 }),
new Question("В какой стране находится пустыня Сахара?", new List<string> { "Алжир", "Судан", "Марокко" }, new List<int> { 0 }),
new Question("Какой город является столицей Японии?", new List<string> { "Токио", "Осака", "Киото" }, new List<int> { 0 }),
new Question("Какая страна имеет самые высокие горы в Европе?", new List<string> { "Швейцария", "Франция", "Италия" }, new List<int> { 0 }),
new Question("Какой океан омывает берега Австралии?", new List<string> { "Тихий", "Индийский", "Атлантический" }, new List<int> { 0 }),
new Question("В какой стране находится гора Килиманджаро?", new List<string> { "Танзания", "Кения", "Уганда" }, new List<int> { 0 }),
new Question("Какая страна имеет наибольшее население в мире?", new List<string> { "Китай", "Индия", "США" }, new List<int> { 0 }),
new Question("Где расположена Великая Китайская стена?", new List<string> { "Китай", "Южная Корея", "Япония" }, new List<int> { 0 }),
new Question("Какая страна является родиной Олимпийских игр?", new List<string> { "Греция", "Италия", "Франция" }, new List<int> { 0 }),
new Question("Какой город является столицей Франции?", new List<string> { "Париж", "Лион", "Марсель" }, new List<int> { 0 }),
new Question("Какая река протекает через Египет?", new List<string> { "Нил", "Ганг", "Амазонка" }, new List<int> { 0 }),
new Question("Какая страна имеет самую длинную береговую линию?", new List<string> { "Канада", "Австралия", "США" }, new List<int> { 0 }),
new Question("В какой стране расположена самая большая пустыня в мире?", new List<string> { "Сахара", "Гоби", "Атакама" }, new List<int> { 0 }),
new Question("Какая страна разделена на два полушария?", new List<string> { "Эквадор", "Колумбия", "Чили" }, new List<int> { 0 }),
new Question("Какой континент называется родиной большинства древних цивилизаций?", new List<string> { "Азия", "Евразия", "Африка" }, new List<int> { 0 })
               }),
             new Quiz("География", 20, new List<Question>
{
    new Question("Какая река самая длинная в мире?", new List<string> { "Нил", "Амазонка", "Янцзы" }, new List<int> { 1 }),
    new Question("Какая страна самая большая по площади?", new List<string> { "Россия", "Канада", "США" }, new List<int> { 0 }),
    new Question("Какой океан самый глубокий?", new List<string> { "Тихий", "Атлантический", "Индийский" }, new List<int> { 0 }),
    new Question("Какая страна имеет наибольшее количество островов?", new List<string> { "Швеция", "Филиппины", "Индонезия" }, new List<int> { 0 }),
    new Question("Где находится гора Эверест?", new List<string> { "Непал", "Китай", "Индия" }, new List<int> { 0 }),
    new Question("Какое озеро самое глубокое в мире?", new List<string> { "Байкал", "Каспийское", "Гранд-Лейк" }, new List<int> { 0 }),
    new Question("Какой континент самый маленький по площади?", new List<string> { "Океания", "Антарктида", "Евразия" }, new List<int> { 1 }),
    new Question("В какой стране находится пустыня Сахара?", new List<string> { "Алжир", "Судан", "Марокко" }, new List<int> { 0 }),
    new Question("Какой город является столицей Японии?", new List<string> { "Токио", "Осака", "Киото" }, new List<int> { 0 }),
    new Question("Какая страна имеет самые высокие горы в Европе?", new List<string> { "Швейцария", "Франция", "Италия" }, new List<int> { 0 }),
    new Question("Какой океан омывает берега Австралии?", new List<string> { "Тихий", "Индийский", "Атлантический" }, new List<int> { 0 }),
    new Question("В какой стране находится гора Килиманджаро?", new List<string> { "Танзания", "Кения", "Уганда" }, new List<int> { 0 }),
    new Question("Какая страна имеет наибольшее население в мире?", new List<string> { "Китай", "Индия", "США" }, new List<int> { 0 }),
    new Question("Где расположена Великая Китайская стена?", new List<string> { "Китай", "Южная Корея", "Япония" }, new List<int> { 0 }),
    new Question("Какая страна является родиной Олимпийских игр?", new List<string> { "Греция", "Италия", "Франция" }, new List<int> { 0 }),
    new Question("Какой город является столицей Франции?", new List<string> { "Париж", "Лион", "Марсель" }, new List<int> { 0 }),
    new Question("Какая река протекает через Египет?", new List<string> { "Нил", "Ганг", "Амазонка" }, new List<int> { 0 }),
    new Question("Какая страна имеет самую длинную береговую линию?", new List<string> { "Канада", "Австралия", "США" }, new List<int> { 0 }),
    new Question("В какой стране расположена самая большая пустыня в мире?", new List<string> { "Сахара", "Гоби", "Атакама" }, new List<int> { 0 }),
    new Question("Какая страна разделена на два полушария?", new List<string> { "Эквадор", "Колумбия", "Чили" }, new List<int> { 0 }),
    new Question("Какой континент называется родиной большинства древних цивилизаций?", new List<string> { "Азия", "Евразия", "Африка" }, new List<int> { 0 })
}),
new Quiz("Математика", 20, new List<Question>
{
    new Question("Какое число является простым?", new List<string> { "7", "8", "9" }, new List<int> { 0 }),
    new Question("Сколько углов у прямоугольника?", new List<string> { "4", "5", "6" }, new List<int> { 0 }),
    new Question("Какой результат выражения 7 + 3 * 2?", new List<string> { "13", "17", "20" }, new List<int> { 0 }),
    new Question("Что такое квадрат числа?", new List<string> { "Число, умноженное само на себя", "Число, разделенное на себя", "Число, возведенное в третью степень" }, new List<int> { 0 }),
    new Question("Как называется гипотенуза в прямоугольном треугольнике?", new List<string> { "Сторона напротив прямого угла", "Сторона рядом с прямым углом", "Одна из катетов" }, new List<int> { 0 }),
    new Question("Какая формула площади круга?", new List<string> { "πr²", "2πr", "πd" }, new List<int> { 0 }),
    new Question("Сколько сторон у треугольника?", new List<string> { "3", "4", "5" }, new List<int> { 0 }),
    new Question("Какая фигура имеет 6 сторон?", new List<string> { "Шестиугольник", "Пятиугольник", "Квадрат" }, new List<int> { 0 }),
    new Question("Чему равен корень квадратный из 16?", new List<string> { "4", "5", "6" }, new List<int> { 0 }),
    new Question("Как вычислить периметр прямоугольника?", new List<string> { "2(a + b)", "a * b", "2a + 2b" }, new List<int> { 0 }),
    new Question("Какая сумма углов в треугольнике?", new List<string> { "180 градусов", "360 градусов", "90 градусов" }, new List<int> { 0 }),
    new Question("Какой коэффициент наклона у прямой с уравнением y = 3x + 2?", new List<string> { "3", "2", "1" }, new List<int> { 0 }),
    new Question("Чему равна площадь квадрата со стороной 5?", new List<string> { "25", "10", "15" }, new List<int> { 0 }),
    new Question("Какое число является решением уравнения x + 5 = 12?", new List<string> { "7", "17", "6" }, new List<int> { 0 }),
    new Question("Как называется линия, соединяющая две точки окружности?", new List<string> { "Хорд", "Диаметр", "Радиус" }, new List<int> { 0 }),
    new Question("Какой результат выражения 25 ÷ 5?", new List<string> { "5", "4", "6" }, new List<int> { 0 }),
    new Question("Чему равна сумма углов прямого угла?", new List<string> { "90 градусов", "180 градусов", "360 градусов" }, new List<int> { 0 }),
    new Question("Какой результат выражения 3 * (4 + 2)?", new List<string> { "18", "24", "21" }, new List<int> { 0 }),
    new Question("Что такое периметр многоугольника?", new List<string> { "Сумма длин всех его сторон", "Площадь многоугольника", "Диаметр окружности" }, new List<int> { 0 }),
    new Question("Какой результат выражения 8 ÷ 2 + 3?", new List<string> { "7", "10", "5" }, new List<int> { 0 }),
    new Question("Какое число наибольшее среди чисел 5, 12, 8?", new List<string> { "12", "8", "5" }, new List<int> { 0 })
})
         ];

            // Добавляем предустановленные викторины в общий список
            quizzes.AddRange(predefinedQuizzes);
            
         }
        
private void QuizOptions(Quiz quizDirection){
  string yes;
            do{
        WriteLine("Введите текст вопроса:");
            string text = ReadLine();

             WriteLine("Введите варианты ответа через запятую:");
             var options = ReadLine().Split(',').ToList();

             WriteLine("Введите номера правильных ответов через запятую:");
             var correctAnswers = ReadLine().Split(',').Select(x => int.Parse(x) - 1).ToList();
             quizDirection.Questions.Add(new Question(text, options, correctAnswers));

            WriteLine("добавить вопрос?");
            yes = ReadLine();
            }while(yes.ToLower() == "да" || yes.ToLower() == "yes" && (quizDirection.Questions.Count() <= 20));
       }

        public void CreateQuiz(){
      WriteLine("Введите название викторины: ");
        string answer = ReadLine();
            Quiz quiz = new Quiz(answer, new List<Question>{});
            QuizOptions(quiz);
            quizzes.Add(quiz);
        }

        public void EditQuiz(){
            WriteLine("Выберите действие: ");
            Write("1 - изменить вопрос");
            Write("2 - изменить название викторины");
            Write("3 - удалить вопрос");
            Write("4 - удалить викторину");
          
            string answer = ReadLine();
            int answ = int.Parse(answer);
switch (answ)
{
    case 1:
        EditQuestion();
        break;
    case 2:
        EditQuizName();
        break;
    case 3:
        RemoveQuestion();
        break;
    case 4:
        RemoveQuiz();
        break;
    default:
        WriteLine("Неверный выбор");
        break;
}
        }


        private void EditQuizName(){
            WriteLine("Введите название викторины: ");
            string quizName = ReadLine();
       
            foreach(var quiz in quizzes){
                if(quiz.Category == quizName){
                    WriteLine("Введите новое название для викторины");
                         string newName = ReadLine();
                         quiz.Category = newName;
                         Write("Название викторины успешно изменено \n");
                         return;
                }
            
            }
        }

        private void EditQuestion(){
            WriteLine("Введите название викторины: ");
            string quizName = ReadLine();
            foreach(var quiz in quizzes){
                if(quiz.Category == quizName){
                   WriteLine("Введите название вопроса, который хотите отредактировать: ");
                   string answer = ReadLine();

                   foreach(var question in quiz.Questions){
                    if(question.Text == answer){
                        WriteLine("Введите новый вопрос");
                        string newQuestion = ReadLine();
                        question.Text = newQuestion;
                        Write("Вопрос успешно заменён \n");
                    }
                   }
                }
            }

            WriteLine("Хотите также заменить варианты ответов?");
            string ask = ReadLine();
            if(ask == "да".ToLower() || ask.ToLower() == "yes"){
            WriteLine("Введите ответ, который нужно заменить: ");
            string userAnswer = ReadLine();
            foreach(var quiz in quizzes){
                foreach(var question in quiz.Questions){
                    if(question.Options.Contains(userAnswer)){
                        WriteLine("Введите новый ответ: ");
                        string newAnswer = ReadLine();
                        int index = question.Options.IndexOf(userAnswer);
                        if (index != -1){
                          question.Options[index] = newAnswer;
                          Write("Варианты ответов успешно заменены");
                                        }
                    }
                }
            }

            WriteLine("Хотите также заменить правильные ответы?");
            string ask2 = ReadLine();
            if(ask2 == "да".ToLower() || ask2 == "yes".ToLower()){
                WriteLine("введите правильный ответ, который нужно заменить (цифру): ");
                 string userAnswer1 = ReadLine();
                 int usrAnswr = int.Parse(userAnswer1);
                 foreach(var quiz in quizzes){
                    foreach(var question in quiz.Questions){
                        WriteLine("Введите новый правильный ответ: ");
                        string newAnswer = ReadLine();
                        int newResult = int.Parse(newAnswer);
                        int index = question.CorrectAnswers.IndexOf(usrAnswr);
                        if(index != -1){
                            question.CorrectAnswers[index] = newResult;
                            Write("Правильные ответы успешно заменены");
                        }


                    }
                 }
            }
            }
        }


    

        public void Control(){
            WriteLine("Выберите действие: ");
            Write("1 - создать викторину");
            Write("2 - редактировать викторину");
            Write("3 - удалить викторину");
            string answer = ReadLine();
            int answ = int.Parse(answer);
    switch (answ)
{
    case 1:
        CreateQuiz();
        break;
    case 2:
        EditQuiz();
        break;
    case 3:
        RemoveQuiz();
        break;
    default:
        WriteLine("Неверный выбор");
        break;
}
        }

        private void RemoveQuestion(){
        WriteLine("Введите вопрос, который хотите удалить: ");
        string userQuestion = ReadLine();
            foreach (var quiz in quizzes)
{
   
        var questionsToRemove = quiz.Questions
                                .Where(question => question.Text.ToLower().Contains(userQuestion.ToLower()))
                                .ToList();


    if (questionsToRemove.Any())
    {
        foreach (var question in questionsToRemove)
        {
            quiz.Questions.Remove(question);
        }
        WriteLine("Вопрос и связанные с ним данные успешно удалены.");
    }
    else
    {
        WriteLine("Вопрос не найден.");
    }
}
        }

        private void RemoveQuiz(){
        WriteLine("Введите название викторины, которую хотите удалить: ");
        string userQuiz = ReadLine();
        var quizToRemove = quizzes.FirstOrDefault(quiz => quiz.Category.ToLower().Contains(userQuiz));

        if(quizToRemove != null){
         quizzes.Remove(quizToRemove);
          }  
            
        }
        
        

        private Quiz CreateMixedQuiz(List<Quiz> quizzes)
{
    var allQuestions = quizzes.SelectMany(q => q.Questions).ToList();
    var random = new Random();
    var mixedQuestions = allQuestions.OrderBy(q => random.Next()).Take(20).ToList();
    return new Quiz("Смешанная", mixedQuestions);
}


public int Start(){
            WriteLine("Выберите викторину: ");
            Write("1 - Историческая");
            Write("2 - Политическая");
            Write("3 - Математическая");
            Write("4 - Смешанная");
            string answer = ReadLine();
            int answ = int.Parse(answer);
            
            int score = 0;

 
    switch (answ)
{
    case 1:
     score = HelpToStart("История");
      Name = "История";
      Date = DateTime.Now;
        break;
    case 2:
      score = HelpToStart("Политика");
       Name = "Политика";
        break;
    case 3:
      score = HelpToStart("Математика");
      Name = "Математика";
        break;
    case 4:
      score = HelpToStart("Смешанная");
      Name = "Смешанная";
        break;
    default:
        WriteLine("Неверный выбор");
        break;
}

return score;

}

public string GetName(){

  return Name;

}

public DateTime GetDate(){
    return Date;
}


private int HelpToStart(string quizName){
          int score = 0;
    if(quizName != "Смешанная"){
  Quiz quiz = predefinedQuizzes.FirstOrDefault(q => q.Category == quizName);
        List<int> userAnswers = new List<int>();
        if(quiz != null){
            foreach(var question in quiz.Questions){
                Write(question);
                WriteLine("Выберите ответ (введите несколько, где требуется, через запятую): ");
                string userResponse = ReadLine();
                string[] userAnswerStrings = userResponse.Split(',');
                 List<int> userAnswerInts = userAnswerStrings.Select(answer => int.Parse(answer.Trim())).ToList();
              if (question.CorrectAnswers.All(userAnswerInts.Contains))
        {
            Write("Все ответы правильные!");
            userAnswers.AddRange(userAnswerInts); 
            score++;
        }
        else{

                     Write("Неправильно");
                     userAnswers.AddRange(userAnswerInts);
        }
                

                
            }
            Write("Количество правильных ответов: " + (score - 1) + "\n");
            Top20();
        }

}
else{
    Quiz quiz = CreateMixedQuiz(predefinedQuizzes);
     List<int> userAnswers = new List<int>();
        if(quiz != null){
            foreach(var question in quiz.Questions){
                Write(question);
                WriteLine("Выберите ответ (введите несколько, где требуется, через запятую): ");
                string userResponse = ReadLine();
                string[] userAnswerStrings = userResponse.Split(',');
                 List<int> userAnswerInts = userAnswerStrings.Select(answer => int.Parse(answer.Trim())).ToList();
              if (question.CorrectAnswers.All(userAnswerInts.Contains))
        {
            Write("Все ответы правильные!");
            userAnswers.AddRange(userAnswerInts); 
            score++;
        }
        else{
                     Write("Неправильно");
                     userAnswers.AddRange(userAnswerInts); 
        }
                
}
 Write("Количество правильных ответов: " + (score - 1) + "\n");
 Top20();
        }
}
return score;
    }

     public List<QuizResult> GetUserQuizResults()
    {

        WriteLine("Введите ваш ник для отображения результатов:");
        string login = ReadLine();

        string filePath = "usersScore.txt";
     
        var lines = File.ReadAllLines(filePath);

        var results = lines
            .Where(line => line.StartsWith($"{login}:"))
            .Select(line =>
            {
               
                var parts = line.Split(['-', ','], StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length < 4) return null;

                var name = parts[1].Trim();
                var score = int.Parse(parts[2].Trim());
                var date = DateTime.Parse(parts[3].Trim());


                return new QuizResult(name, score, date);
            })
            .Where(result => result != null)
            .ToList();

            if (results.Any())
        {
            WriteLine($"Результаты викторин для пользователя {login}:");
            foreach (var result in results)
            {
                WriteLine($"Имя: {result.QuizName}, Оценка: {result.Score}, Дата: {result.DateTaken}");
            }
        }
        else
        {
            WriteLine($"Результаты викторин для пользователя {login} не найдены.");
        }

        return results;
    }

    public void Top20(){
     string filePath = "usersScore.txt";
     
        var lines = File.ReadAllLines(filePath);

       var results = lines
        .Select(line =>
        {
            var parts = line.Split(['-', ','], StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 4) return null;

            var name = parts[1].Trim(); 
            return name;
        })
        .Where(result => result != null)
        .ToList();

    if (results.Any())
    {
        WriteLine($"Топ 20 игроков:");
        foreach (var name in results)
        {
            WriteLine($"Имя: {name}");
        }
    }
}
}

}




