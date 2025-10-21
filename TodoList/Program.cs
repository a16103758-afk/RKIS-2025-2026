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
                string input = Console.ReadLine();
                string[] parts = input.Split(' ', 2);
                string command = parts[0];

                switch (command)
                {
                    case "add":
                        if (parts.Length > 1)
                        {
                            if (count >= todos.Length)
                            {
                                string[] newArray = new string[todos.Length * 2];
                                for (int i = 0; i < todos.Length; i++)
                                {
                                    newArray[i] = todos[i];
                                }
                                todos = newArray;
                            }

                            todos[count] = parts[1];
                            count++;
                            Console.WriteLine("Задача добавлена");
                        }
                        break;

                    case "view":
                        for (int i = 0; i < count; i++)
                        {
                            Console.WriteLine((i + 1) + ". " + todos[i]);
                        }
                        break;

                    case "help":
                        Console.WriteLine("help - список команд");
                        Console.WriteLine("profile - данные пользователя");
                        Console.WriteLine("add - добавить задачу");
                        Console.WriteLine("view - показать задачи");
                        Console.WriteLine("exit - выход");
                        break;

                    case "profile":
                        Console.WriteLine($"Пользователь {firstName} {lastName}, возраст – {age}");
                        break;

                    case "exit":
                        return;
                }
            }
        }
    }
}