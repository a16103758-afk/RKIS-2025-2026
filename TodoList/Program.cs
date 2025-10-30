using System;

namespace TodoList
{
    class Program
    {
        static TodoList _todoList = new TodoList();
        static Profile _userProfile;

        public static void Main()
        {
            Console.WriteLine("Работу выполнила Сайтамирова");

            Console.WriteLine("Введите вашу фамилию:");
            string lastName = Console.ReadLine();

            Console.WriteLine("Введите ваше имя:");
            string firstName = Console.ReadLine();

            Console.WriteLine("Введите ваш год рождения:");
            string yearOfBirthInput = Console.ReadLine();

            int yearOfBirth = int.Parse(yearOfBirthInput);
            _userProfile = new Profile(firstName, lastName, yearOfBirth);
            Console.WriteLine($"Добавлен пользователь {_userProfile.GetInfo()}");

            while (true)
            {
                Console.Write("Введите команду: ");
                string input = Console.ReadLine();

                if (input == "exit")
                    return;

                ICommand command = CommandParser.Parse(input, _todoList, _userProfile);
                command.Execute();
            }
        }
    }
}