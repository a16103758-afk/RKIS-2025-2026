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
                        ShowProfile();
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

                    case "read":
                        ReadTask(parts);
                        break;

                    case "exit":
                        return;
                }
            }
        }

        static void AddTask(string[] parts)
        {
            if (parts.Length > 1)
            {
                string taskText = parts[1];
                
                if (taskText == "--multiline" || taskText == "-m")
                {
                    string multilineText = "";
                    string line;

                    while (true)
                    {
                        Console.Write("> ");
                        line = Console.ReadLine();
                        if (line == "!end")
                            break;
                        multilineText += line + "\n";
                    }
                    
                    taskText = multilineText.Trim();
                }

                TodoItem newItem = new TodoItem(taskText);
                _todoList.Add(newItem);
                Console.WriteLine("Задача добавлена");
            }
        }

        static void ReadTask(string[] parts)
        {
            if (parts.Length > 1)
            {
                int index = int.Parse(parts[1]) - 1;
                TodoItem item = _todoList.GetItem(index);
                if (item != null)
                {
                    Console.WriteLine(item.GetFullInfo());
                }
            }
        }

        static void ViewTasks(string[] parts)
        {
            bool showIndex = false;
            bool showDone = false;
            bool showDate = false;

            if (parts.Length > 1)
            {
                string flags = parts[1];
                showIndex = flags.Contains("-i") || flags.Contains("i") || flags.Contains("--index");
                showDone = flags.Contains("-s") || flags.Contains("s") || flags.Contains("--status");
                showDate = flags.Contains("-d") || flags.Contains("d") || flags.Contains("--update-date");
                
                if (flags.Contains("-a") || flags.Contains("a") || flags.Contains("--all"))
                {
                    showIndex = true;
                    showDone = true;
                    showDate = true;
                }
            }

            _todoList.View(showIndex, showDone, showDate);
        }

        static void ShowHelp()
        {
            Console.WriteLine("help - список команд");
            Console.WriteLine("profile - данные пользователя");
            Console.WriteLine("add - добавить задачу");
            Console.WriteLine("add -m - добавить задачу в многострочном режиме");
            Console.WriteLine("view -i, -s, -d, -a - показать задачи");
            Console.WriteLine("read - просмотреть полный текст задачи");
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
                    TodoItem item = _todoList.GetItem(index);
                    if (item != null)
                    {
                        item.UpdateText(updateParts[1]);
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
                TodoItem item = _todoList.GetItem(index);
                if (item != null)
                {
                    item.MarkDone();
                    Console.WriteLine("Задача выполнена");
                }
            }
        }

        static void DeleteTask(string[] parts)
        {
            if (parts.Length > 1)
            {
                int index = int.Parse(parts[1]) - 1;
                _todoList.Delete(index);
                Console.WriteLine("Задача удалена");
            }
        }

        static void ShowProfile()
        {
            Console.WriteLine($"Пользователь {_userProfile.GetInfo()}");
        }
    }
}