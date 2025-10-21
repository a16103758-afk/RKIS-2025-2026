namespace TodoList
{
    class Program
    {
        static string[] todos = new string[2];
        static int count = 0;

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

            while (true)
            {
                Console.Write("Введите команду: ");
                string input = Console.ReadLine();
                string[] parts = input.Split(' ', 2);
                string command = parts[0];
                
                switch (command)
                {
                    case "add":
                        AddTask(parts);
                        break;

                    case "view":
                        ViewTasks();
                        break;

                    case "help":
                        ShowHelp();
                        break;

                    case "profile":
                        ShowProfile(firstName, lastName, age);
                        break;

                    case "exit":
                        return;
                }
            }
        }

        static void ExpandArrays()
        {
            string[] newTodos = new string[todos.Length * 2];
            for (int i = 0; i < todos.Length; i++)
            {
                newTodos[i] = todos[i];
            }
            todos = newTodos;
        }

        static void AddTask(string[] parts)
        {
            if (parts.Length > 1)
            {
                if (count >= todos.Length)
                {
                    ExpandArrays();
                }
                todos[count] = parts[1];
                count++;
                Console.WriteLine("Задача добавлена");
            }
        }

        static void ViewTasks()
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"{i + 1}. {todos[i]}");
            }
        }

        static void ShowHelp()
        {
            Console.WriteLine("help - список команд");
            Console.WriteLine("profile - данные пользователя");
            Console.WriteLine("add - добавить задачу");
            Console.WriteLine("view - показать задачи");
            Console.WriteLine("exit - выход");
        }

        static void ShowProfile(string firstName, string lastName, int age)
        {
            Console.WriteLine($"Пользователь {firstName} {lastName}, возраст – {age}");
        }
    }
}