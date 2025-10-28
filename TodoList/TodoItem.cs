namespace TodoList
{
    public class TodoItem
    {
        private string _text;
        private bool _isDone;
        private DateTime _lastUpdate;

        public string Text => _text;
        public bool IsDone => _isDone;
        public DateTime LastUpdate => _lastUpdate;

        public TodoItem(string text)
        {
            _text = text;
            _isDone = false;
            _lastUpdate = DateTime.Now;
        }

        public void MarkDone()
        {
            _isDone = true;
            _lastUpdate = DateTime.Now;
        }

        public void UpdateText(string newText)
        {
            _text = newText;
            _lastUpdate = DateTime.Now;
        }

        public string GetShortInfo()
        {
            string shortText = _text.Length > 30 ? _text.Substring(0, 27) + "..." : _text;
            string status = _isDone ? "Выполнена" : "Не выполнена";
            return $"{shortText,-30} {status,-15} {_lastUpdate:dd.MM.yyyy HH:mm}";
        }

        public string GetFullInfo()
        {
            return $"Полный текст: {_text}\nСтатус: {(_isDone ? "выполнена" : "не выполнена")}\nДата изменения: {_lastUpdate:dd.MM.yyyy HH:mm}";
        }
    }
}