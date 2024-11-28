// See https://aka.ms/new-console-template for more information


// Создать приложение «Викторина».
// Основная задача проекта: предоставить пользователю возможность проверить свои
// знания в разных областях.
// Интерфейс приложения должен предоставлять такие возможности:
// ■ При старте приложения пользователь вводит логин и пароль для входа.
//  Если пользователь не зарегистрирован, он должен пройти процесс регистрации.
// ■ При регистрации нужно указать:
// • логин (нельзя зарегистрировать уже существующий логин);
// • пароль;
// • дату рождения.
// ■ После входа в систему пользователь может:
// • стартовать новую викторину;
// • посмотреть результаты своих прошлых викторин;
// • посмотреть Топ-20 по конкретной викторине;
// • изменить настройки: можно менять пароль и дату рождения;
// • выход.
// ■ Для старта новой викторины пользователь должен выбрать раздел знаний викторины.
//  Например: «История», «География», «Биология» и т.д. Также нужно предусмотреть смешанную викторину,
//   когда вопросы будут выбираться из разных викторин по случайному принципу.
// ■ Конкретная викторина состоит из двадцати вопросов. У каждого вопроса может
//  быть один или несколько правильных вариантов ответа. Если вопрос предполагает
//   несколько правильных ответов, а пользователь указал не все, вопрос не засчитывается.
// ■ По завершении викторины пользователь получает количество правильно отвеченных вопросов,
//  а также свое место в таблице результатов игроков викторины.
// Необходимо также разработать утилиту для создания и редактирования викторин и их вопросов.
//  Это приложение должно предусматривать вход по логину и паролю.

using hw;

Console.WriteLine("Выберите действие: ");
Console.WriteLine("1 - Админ: ");
Console.WriteLine("2 - Пользователь: ");
string answer = Console.ReadLine();
int answ;

if (int.TryParse(answer, out answ))
{
    switch (answ)
    {
        case 1:
            Admin admin = new Admin();
            HandleAdmin(admin);
            break;

        case 2:
            User user = new User();
            HandleUser(user);
            
            break;

        default:
            Console.WriteLine("Некорректный выбор.");
            break;
    }
}
else
{
    Console.WriteLine("Некорректный ввод.");
}

void HandleAdmin(Admin admin)
{
    Console.WriteLine("1 - Регистрация");
    Console.WriteLine("2 - Вход");
    string action = Console.ReadLine();

    if (action == "1")
    {
        admin.CreateAccount();
    }
    else if (action == "2" && admin.SignIn())
    {
        admin.Control();
        InteractWithQuiz(admin);
    }
    else
    {
        Console.WriteLine("Возникла ошибка");
    }
}

void HandleUser(User user)
{
    Console.WriteLine("1 - Регистрация");
    Console.WriteLine("2 - Вход");
    string action = Console.ReadLine();

    if (action == "1")
    {
        user.CreateAccount();
    }
    else if (action == "2")
    {
        bool check = user.SignIn();
        if(check){
        
        user.Start();
        List<QuizResult> results = user.GetUserQuizResults();
        }
    }
    else
    {
        Console.WriteLine("Некорректный выбор или ошибка входа.");
    }
}

void InteractWithQuiz(Admin admin)
{
    Console.WriteLine("Хотите пройти викторину? (да/нет)");
    string answer = Console.ReadLine();

    if (answer.ToLower() == "да" && admin.SignIn())
    {
        admin.Start();
    }
    else if (answer.ToLower() != "да")
    {
        Console.WriteLine("Вы не выбрали викторину.");
    }
    else
    {
        Console.WriteLine("Возникла ошибка.");
    }
}
