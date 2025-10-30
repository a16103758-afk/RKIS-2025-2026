namespace TodoList
{
    public class HelpCommand : ICommand
    {
        public void Execute()
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
    }
}