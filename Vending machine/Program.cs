using System;
using System.IO;

namespace VendingMachine
{
    class Program
    {
        private const string LogFilePath = "VendingMachineLog.txt";

        static void Main(string[] args)
        {
            ShowMenu();
            int choice = GetUserChoice();
            VendItem(choice);
        }

        static void ShowMenu()
        {
            Console.WriteLine("Welcome to the Vending Machine!");
            Console.WriteLine("Please select an item:");
            Console.WriteLine("1. Soda");
            Console.WriteLine("2. Candy");
            Console.WriteLine("3. Gum");
            Console.WriteLine("4. Chips");
        }

        static int GetUserChoice()
        {
            Console.Write("Enter the number of your choice: ");
            string? input = Console.ReadLine();
            int choice;
            while (!int.TryParse(input, out choice) || choice < 1 || choice > 4) // Adjusted to match all menu options
            {
                Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                input = Console.ReadLine();
            }
            return choice;
        }

        static void VendItem(int choice)
        {
            string item = choice switch
            {
                1 => "Soda",
                2 => "Candy",
                3 => "Gum",
                4 => "Chips",
                _ => "Unknown"
            };

            Console.WriteLine($"Vending {item}...");
            LogActivity(item); // Log the transaction
            Console.WriteLine("Transaction logged.");
        }

        static void LogActivity(string item)
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string logEntry = $"{timestamp} - Vended: {item}";

            // Append the log entry to the log file
            File.AppendAllText(LogFilePath, logEntry + Environment.NewLine);
        }
    }
}
