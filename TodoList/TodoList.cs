namespace TodoList
{
    public class TodoList
    {
        private TodoItem[] _items;
        private int _count;

        public TodoList(int capacity = 10)
        {
            _items = new TodoItem[capacity];
            _count = 0;
        }

        public void Add(TodoItem item)
        {
            if (_count >= _items.Length)
            {
                IncreaseArray();
            }
            _items[_count++] = item;
        }

        public void Delete(int index)
        {
            if (index >= 0 && index < _count)
            {
                for (int i = index; i < _count - 1; i++)
                {
                    _items[i] = _items[i + 1];
                }
                _count--;
            }
        }

        public void View(bool showIndex, bool showDone, bool showDate)
        {
            string header = "";
            if (showIndex) header += "№       ";
            if (showDone) header += "Статус       ";
            header += "Текст                          ";
            if (showDate) header += "Дата изменения";

            Console.WriteLine(header);
            Console.WriteLine(new string('-', header.Length));

            for (int i = 0; i < _count; i++)
            {
                string row = "";

                if (showIndex)
                    row += $"{i + 1}       ".Substring(0, 8);

                if (showDone)
                {
                    string status = _items[i].IsDone ? "Выполнено   " : "Не выполнено ";
                    row += status;
                }

                string taskText = _items[i].Text.Replace("\n", " ");
                if (taskText.Length > 31)
                    taskText = taskText.Substring(0, 27) + "...";
                row += taskText + new string(' ', 31 - taskText.Length);

                if (showDate)
                    row += _items[i].LastUpdate.ToString("dd.MM.yyyy HH:mm");

                Console.WriteLine(row);
            }
        }

        public TodoItem GetItem(int index)
        {
            if (index >= 0 && index < _count)
            {
                return _items[index];
            }
            return null;
        }

        private void IncreaseArray()
        {
            TodoItem[] newItems = new TodoItem[_items.Length * 2];
            for (int i = 0; i < _items.Length; i++)
            {
                newItems[i] = _items[i];
            }
            _items = newItems;
        }
    }
}