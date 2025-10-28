namespace TodoList
{
    class Program
    {
        static string[] todos = new string[2];
        static bool[] statuses = new bool[2];
        static DateTime[] dates = new DateTime[2];
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
                        ViewTasks(parts);
                        break;

                    case "help":
                        ShowHelp();
                        break;

                    case "profile":
                        ShowProfile(firstName, lastName, age);
                        break;

                    case "done":
                        MarkDone(parts);
                        break;

                    case "delete":
                        DeleteTask(parts);
                        break;

                    case "update":
                        UpdateTask(parts);
                        break;

                    case "exit":
                        return;
                }
            }
        }

        static void ExpandArrays()
        {
            string[] newTodos = new string[todos.Length * 2];
            bool[] newStatuses = new bool[statuses.Length * 2];
            DateTime[] newDates = new DateTime[dates.Length * 2];

            for (int i = 0; i < todos.Length; i++)
            {
                newTodos[i] = todos[i];
                newStatuses[i] = statuses[i];
                newDates[i] = dates[i];
            }
            todos = newTodos;
            statuses = newStatuses;
            dates = newDates;
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
                statuses[count] = false;
                dates[count] = DateTime.Now;
                count++;
                Console.WriteLine("Задача добавлена");
            }
        }

        static void ViewTasks(string[] parts)
        {
                bool showIndex = false;
                bool showStatus = false;
                bool showDate = false;
                bool showAll = false;

                if (parts.Length > 1)
                {
                    string flags = parts[1];
                    showIndex = flags.Contains("-i") || flags.Contains("i") || flags.Contains("--index");
                    showStatus = flags.Contains("-s") || flags.Contains("s") || flags.Contains("--status");
                    showDate = flags.Contains("-d") || flags.Contains("d") || flags.Contains("--update-date");
                    showAll = flags.Contains("-a") || flags.Contains("a") || flags.Contains("--all");
                }

                if (showAll)
                {
                    showIndex = true;
                    showStatus = true;
                    showDate = true;
                }

                string header = "";
                if (showIndex) header += "№       ";
                if (showStatus) header += "Статус       ";
                header += "Текст                          ";
                if (showDate) header += "Дата изменения";

                Console.WriteLine(header);
                Console.WriteLine(new string('-', header.Length));

                for (int i = 0; i < count; i++)
                {
                    string row = "";

                    if (showIndex) 
                        row += $"{i + 1}       ".Substring(0, 8);

                    if (showStatus)
                    {
                        string status = statuses[i] ? "Выполнено   " : "Не выполнено ";
                        row += status;
                    }

                    string taskText = todos[i].Replace("\n", " ");
                    if (taskText.Length > 31)
                        taskText = taskText.Substring(0, 27) + "...";
                    row += taskText + new string(' ', 31 - taskText.Length);

                    if (showDate)
                        row += dates[i].ToString("dd.MM.yyyy HH:mm");

                    Console.WriteLine(row);
                }
        }

        static void ShowHelp()
        {
            Console.WriteLine("help - список команд");
            Console.WriteLine("profile - данные пользователя");
            Console.WriteLine("add - добавить задачу");
            Console.WriteLine("view - показать задачи");
            Console.WriteLine("done - отметить задачу выполненной");
            Console.WriteLine("delete - удалить задачу");
            Console.WriteLine("update - обновить задачу");
            Console.WriteLine("exit - выход");
        }

        static void UpdateTask(string[] parts)
        {
            if (parts.Length > 1)
            {
                string[] updateParts = parts[1].Split(' ', 2);
                if (updateParts.Length > 1)
                {
                    int index = int.Parse(updateParts[0]) - 1;
                    if (index >= 0 && index < count)
                    {
                        todos[index] = updateParts[1];
                        dates[index] = DateTime.Now;
                        Console.WriteLine("Задача обновлена");
                    }
                }
            }
        }

        static void MarkDone(string[] parts)
        {
            if (parts.Length > 1)
            {
                int index = int.Parse(parts[1]) - 1;
                if (index >= 0 && index < count)
                {
                    statuses[index] = true;
                    dates[index] = DateTime.Now;
                    Console.WriteLine("Задача выполнена");
                }
            }
        }

        static void DeleteTask(string[] parts)
        {
            if (parts.Length > 1)
            {
                int index = int.Parse(parts[1]) - 1;
                if (index >= 0 && index < count)
                {
                    for (int i = index; i < count - 1; i++)
                    {
                        todos[i] = todos[i + 1];
                        statuses[i] = statuses[i + 1];
                        dates[i] = dates[i + 1];
                    }
                    count--;
                    Console.WriteLine("Задача удалена");
                }
            }
        }

        static void ShowProfile(string firstName, string lastName, int age)
        {
            Console.WriteLine($"Пользователь {firstName} {lastName}, возраст – {age}");
        }
    }
}