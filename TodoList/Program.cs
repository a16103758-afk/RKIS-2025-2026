Console.WriteLine("Работу выполнила Сайтамирова");

Console.WriteLine("Введите вашу фамилию:");
string lastName = Console.ReadLine();

Console.WriteLine("Введите ваше имя:");
string firstName = Console.ReadLine();

Console.WriteLine("Введите ваш год рождения:");
string yearOfBirthInput = Console.ReadLine();

int yearOfBirth = int.Parse(yearOfBirthInput);
int age = 2025 - yearOfBirth;
Console.WriteLine($"Добавлен пользователь {firstName} {lastName}, возраст – {age}");