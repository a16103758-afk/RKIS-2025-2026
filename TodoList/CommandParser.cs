using System;

namespace TodoList
{
    public static class CommandParser
    {
        public static ICommand Parse(string input, TodoList todoList, Profile profile)
        {
            string[] parts = input.Split(' ', 2);
            string command = parts[0];

            switch (command)
            {
                case "add":
                    bool isMultiline = parts.Length > 1 && (parts[1] == "--multiline" || parts[1] == "-m");
                    string taskText = parts.Length > 1 && !isMultiline ? parts[1] : "";
                    return new AddCommand(todoList, taskText, isMultiline);

                case "view":
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
                    return new ViewCommand(todoList, showIndex, showDone, showDate);

                case "read":
                    if (parts.Length > 1)
                    {
                        int index = int.Parse(parts[1]) - 1;
                        return new ReadCommand(todoList, index);
                    }
                    break;

                case "done":
                    if (parts.Length > 1)
                    {
                        int index = int.Parse(parts[1]) - 1;
                        return new DoneCommand(todoList, index);
                    }
                    break;

                case "delete":
                    if (parts.Length > 1)
                    {
                        int index = int.Parse(parts[1]) - 1;
                        return new DeleteCommand(todoList, index);
                    }
                    break;

                case "update":
                    if (parts.Length > 1)
                    {
                        string[] updateParts = parts[1].Split(' ', 2);
                        if (updateParts.Length > 1)
                        {
                            int index = int.Parse(updateParts[0]) - 1;
                            return new UpdateCommand(todoList, index, updateParts[1]);
                        }
                    }
                    break;

                case "profile":
                    return new ProfileCommand(profile);

                case "help":
                    return new HelpCommand();
            }

            return new HelpCommand();
        }
    }
}