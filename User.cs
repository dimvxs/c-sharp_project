using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;
using System.Text.RegularExpressions;

namespace hw
{
    public class User: ManageQuiz, IHuman
    {
        public string Login { get; set; } = "null";
        public string Password { get; set; } = "null";
        public DateTime DateOfBirth { get; set; } = default;
        public List<QuizResult> QuizResults { get; set; } 


           public void ChangePassword(string newPassword)
    {
        Password = newPassword;
    }

    public void ChangeBirthDate(DateTime newBirthDate)
    {
        DateOfBirth = newBirthDate;
    }

public User(){
    QuizResults = SetResults();
}

public List<QuizResult> SetResults(){

int score = Start();
string name = GetName();
DateTime date = GetDate();

  File.AppendAllText("usersScore.txt", $"{Login}:{Password} - {DateOfBirth}, {name}, {score}, {date}\n");

  return new List<QuizResult> { new QuizResult(name, score, date)};
}



public void CreateAccount(){
        string pattern = @"^[a-z][a-z0-9]$";
        DateTime birthDate;
            WriteLine("Введите дату рождения (в формате ДД.ММ.ГГГГ): ");
         string birthday = ReadLine();
            bool validDate = DateTime.TryParseExact(birthday, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out birthDate);

            if (validDate){
            DateOfBirth = birthDate;
         }

         WriteLine("Придумайте логин (логин может начинаться только с буквы): ");
         string login = ReadLine();

           bool correct = false;

            Regex regex = new Regex(pattern);

            if(regex.IsMatch(login)){
                correct = true;
            }
            if(correct){
                Login = login;
                WriteLine("Логин успешно сохранен");
            }

        WriteLine("Придумайте пароль (не менее 8 символов): ");
         string password = ReadLine();
if(password.Length < 8){
    WriteLine("Пароль слишком короткий");
    WriteLine("Придумайте пароль (не менее 8 символов): ");
}
else{
     WriteLine("Введите пароль ещё раз для подтверждения: ");
    string passCheck = ReadLine();
    if(password.Equals(passCheck)){
        Password = password;
        WriteLine("Аккаунт успешно создан");
        File.AppendAllText("usersData.txt", $"{Login}:{Password} - {DateOfBirth}\n");
    }
}

            

        }

        public bool SignIn(){
        WriteLine("Введите логин: ");
        string login = ReadLine();
        
        WriteLine("Введите пароль: ");
        string password = ReadLine();

        if (!File.Exists("usersData.txt"))
        {
            WriteLine("Файл данных не найден. Зарегистрируйтесь сначала.");
            return false;
        }

     
        var usersData = File.ReadAllLines("usersData.txt")
                             .Select(line => line.Split(':'))
                             .ToDictionary(parts => parts[0], parts => parts[1]);

     
        if (usersData.ContainsKey(login) && usersData[login] == password)
        {
            WriteLine("Успешный вход!");
            return true;
        }
        else
        {
            WriteLine("Неверный логин или пароль!");
            return false;
        }
        }


  
    }
}