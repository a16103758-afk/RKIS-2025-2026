using System;

namespace TodoList
{
    public class DoneCommand : ICommand
    {
        public int Index { get; private set; }
        public TodoList TodoList { get; private set; }

        public DoneCommand(TodoList todoList, int index)
        {
            TodoList = todoList;
            Index = index;
        }

        public void Execute()
        {
            TodoItem item = TodoList.GetItem(Index);
            if (item != null)
            {
                item.MarkDone();
                Console.WriteLine("Задача выполнена");
            }
        }
    }
}