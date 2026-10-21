using System;

namespace TodoListApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            Console.WriteLine("Работу сделали Погиба и Гуляев!");

            Console.WriteLine("Введите своё имя: ");
            var firstName = Console.ReadLine();

            Console.WriteLine("Введите свою фамилию: ");
            var lastName = Console.ReadLine();

            Console.WriteLine("Введите год рождения: ");
            string birthDate = Console.ReadLine();

            int years = int.Parse(birthDate);
            Console.WriteLine($"Добавлен пользователь {firstName} {lastName}, год - {years}.");

            string[] todos = new string[2];
   
            while(true)
            {
                Console.Write("> ");
                string input = Console.ReadLine();

                if(string.IsNullOrWhiteSpace(input))
                    continue;

                string[] parts = input.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
                string command = parts[0].ToLower();
                string argument = parts.Length > 1 ? parts[1] : string.Empty;

                switch (command)
                {
                    case "help":
                        Console.WriteLine("Доступные команды: ");
                        Console.WriteLine(" help          - показать список команд.");
                        Console.WriteLine(" profile       - показать данные пользователя.");
                        Console.WriteLine(" add           - добавить задачу.");
                        Console.WriteLine(" view          - показать все задачи.");
                        Console.WriteLine(" exit          - выйти из программы.");
                        break;

                    case "profile":
                        Console.WriteLine($"{firstName} {lastName}, {years}.");
                        break;

                    case "add":
                        string task = argument.Replace("\"", "").Trim();
                        if (string.IsNullOrWhiteSpace(task))
                        {
                             Console.WriteLine("Укажите текст задачи: add \"текст\"");
                             break;
                        }

                        int freeIndex = -1;
                        for (int i= 0; i < todos.Length; i++)
                        {
                            if(string.IsNullOrEmpty(todos[i]))
                            {
                                freeIndex = i;
                                break;
                            }
                        }
                        if (freeIndex == -1)
                        {
                            string[] newTodos = new string[todos.Length * 2];
                            for (int i = 0; i < todos.Length; i++){
                            
                                newTodos[i] = todos[i];
                                todos = newTodos;
                                freeIndex = i;
                            }

                            for (int i = 0; i < todos.Length; i++)
                            {
                                if (string.IsNullOrEmpty(todos[i]))
                                {
                                    freeIndex = i;
                                    break;
                                }
                            }
                        }
                        todos[freeIndex] = task;
                         Console.WriteLine($"Задача добавлена: {task}");
                        break;

                    case "view":
                        bool any = false;
                        for(int i = 0; i < todos.Length; i++)
                        {
                            if (!string.IsNullOrEmpty(todos[i]))
                            {
                                Console.WriteLine($"{i + 1}. {todos[i]}");
                                any = true;
                            }
                        }
                        if(!any)
                            Console.WriteLine("Список задач пуст.");
                        break;

                    case "exit":
                        Console.WriteLine("Выход из программы.");
                        return;
                    default:
                        Console.WriteLine("Неизвестная команда. Введите help для просмотра команд.");
                        break;
                }
            }
        }
    }
}
