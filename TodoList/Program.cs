namespace TodoList
{
    class Program
    {
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
            int age = 2025 - yearOfBirth;
            Console.WriteLine($"Добавлен пользователь {firstName} {lastName}, возраст – {age}");

            string[] todos = new string[2];
            int count = 0;

            while (true)
            {
                Console.Write("Введите команду: ");
                string command = Console.ReadLine();

                switch (command)
                {
                    case "help":
                        Console.WriteLine("help - список команд");
                        Console.WriteLine("profile - данные пользователя");
                        Console.WriteLine("add - добавить задачу");
                        Console.WriteLine("view - показать задачи");
                        Console.WriteLine("exit - выход");
                        break;
                }
            }
        }
    }
}