using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Список запущенных процессов:");
        ListAllProcesses();

        Console.WriteLine("\nВведите ID процесса для его завершения (0 для выхода):");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int processId))
        {
            if (processId != 0)
            {
                try
                {
                    Process process = Process.GetProcessById(processId);
                    process.Kill();
                    Console.WriteLine($"Процесс с ID {processId} успешно завершен.");
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Процесс с указанным ID не найден.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при завершении процесса: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("Выход из программы.");
            }
        }
        else
        {
            Console.WriteLine("Некорректный ввод ID процесса.");
        }
    }

    static void ListAllProcesses()
    {
        Process[] processes = Process.GetProcesses();
        foreach (Process process in processes)
        {
            Console.WriteLine($"ID: {process.Id}, Имя: {process.ProcessName}");
        }
    }
}
