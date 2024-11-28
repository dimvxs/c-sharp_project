using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;
using System.Text.RegularExpressions;
using System.Reflection.Metadata.Ecma335;

namespace hw
{
    public class Admin: ManageQuiz, IHuman
    {
        public string Login { get; set; } = "null";
        public string Password { get; set; } = "null";
        public DateTime DateOfBirth { get; set; } = default;
        public List<QuizResult> Results { get; set; } = default;

        public void ChangePassword(string newPassword)
    {
        Password = newPassword;
    }

    public void ChangeBirthDate(DateTime newBirthDate)
    {
        DateOfBirth = newBirthDate;
    }

        public void CreateAccount(){

            string pattern = @"^[a-zA-Z][a-zA-Z0-9]*$";
            DateTime birthDate;
            bool validDate = false;
         WriteLine("Введите дату рождения (в формате ДД.ММ.ГГГГ): ");
         string birthday = ReadLine();
         validDate = DateTime.TryParseExact(birthday, "dd.MM.yyyy", null, System.Globalization.DateTimeStyles.None, out birthDate);
            string filePath = "adminsData.txt";
            string fileContent = File.ReadAllText(filePath);

         if(validDate){
            DateOfBirth = birthDate;
         }

         WriteLine("Придумайте логин (логин может начинаться только с буквы): ");
         string login = ReadLine();


            Regex regex = new Regex(pattern);

            if(!regex.IsMatch(login)){
                 WriteLine("Логин должен начинаться с буквы и содержать только буквы и цифры.");
                 return;
            }

             if (fileContent.Contains(login))
    {
        WriteLine("Такой логин уже существует. Придумайте другой.");
        return;
    }
           
              Login = login;
                WriteLine("Логин успешно сохранен");

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
        File.AppendAllText("adminsData.txt", $"{Login}:{Password} - {DateOfBirth}\n");
    }
}

            

        }


        public QuizResult SetResults(){

int score = Start();
string name = GetName();
DateTime date = GetDate();

  File.AppendAllText("usersScores.txt", $"{Login}:{Password} - {DateOfBirth}, {name}, {score}, {date}\n");

  return new QuizResult(name, score, date);

   

}



        public bool SignIn(){
        WriteLine("Введите логин: ");
        string login = ReadLine();
        
        WriteLine("Введите пароль: ");
        string password = ReadLine();

        if (!File.Exists("adminsData.txt"))
        {
            WriteLine("Файл данных не найден. Зарегистрируйтесь сначала.");
            return false;
        }

     
        var usersData = File.ReadAllLines("adminsData.txt")
                            .Select(line => line.Trim()) // Убираем пробелы и пустые строки
                            .Where(line => !string.IsNullOrWhiteSpace(line) && line.Contains(":")) // Проверяем наличие логина и пароля
                            .Select(line =>
                            {
                                var parts = line.Split(':'); // Разделяем логин и остальные данные
                                var passwordPart = parts[1].Split(" - ")[0]; // Извлекаем пароль до " - "
                                return new
                                {
                                    Login = parts[0],
                                    Password = passwordPart
                                };
                            })
                            .ToDictionary(data => data.Login, data => data.Password);


     
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