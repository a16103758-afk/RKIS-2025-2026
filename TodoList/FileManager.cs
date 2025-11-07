using System;
using System.IO;

namespace TodoList
{
    public static class FileManager
    {
        public static void EnsureDataDirectory(string dirPath)
        {
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
        }

        public static void SaveProfile(Profile profile, string filePath)
        {
            string[] profileData = 
            {
                profile.FirstName,
                profile.LastName,
                profile.BirthYear.ToString()
            };
            File.WriteAllLines(filePath, profileData);
        }

        public static Profile LoadProfile(string filePath)
        {
            if (!File.Exists(filePath))
                return null;

            string[] lines = File.ReadAllLines(filePath);
            if (lines.Length >= 3)
            {
                string firstName = lines[0];
                string lastName = lines[1];
                int birthYear = int.Parse(lines[2]);
                return new Profile(firstName, lastName, birthYear);
            }
            return null;
        }

        public static void SaveTodos(TodoList todos, string filePath)
        {
            string[] lines = new string[todos.GetCount()];
            
            for (int i = 0; i < todos.GetCount(); i++)
            {
                var item = todos.GetItem(i);
                string escapedText = EscapeCsv(item.Text);
                lines[i] = $"{i + 1};{escapedText};{item.IsDone};{item.LastUpdate:yyyy-MM-ddTHH:mm:ss}";
            }
            
            File.WriteAllLines(filePath, lines);
        }

        public static TodoList LoadTodos(string filePath)
        {
            var todoList = new TodoList();
            
            if (!File.Exists(filePath))
                return todoList;

            string[] lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var parts = line.Split(';');
                if (parts.Length >= 4)
                {
                    string text = UnescapeCsv(parts[1]);
                    bool isDone = bool.Parse(parts[2]);
                    DateTime lastUpdate = DateTime.Parse(parts[3]);
                    
                    var item = new TodoItem(text);
                    if (isDone) item.MarkDone();
                    todoList.Add(item);
                }
            }
            
            return todoList;
        }

        private static string EscapeCsv(string text) =>
            "\"" + text.Replace("\"", "\"\"").Replace("\n", "\\n") + "\"";


        private static string UnescapeCsv(string text) =>
            text.Trim('"').Replace("\"\"", "\"").Replace("\\n", "\n");

    }
}