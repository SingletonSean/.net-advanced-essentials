using LazyDemo.Models;
using System;
using System.Threading.Tasks;


namespace LazyDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Press Enter to login.");
            Console.ReadLine();

            Account account = await GetAccount();

            Console.WriteLine("Successfully logged in.");

            while(true)
            {
                Console.WriteLine("Enter the number corresponding to the desired action:");
                Console.WriteLine("1. Show Account Details");
                Console.WriteLine("2. Show Balance");
                Console.WriteLine("3. Show Daily Message");
                Console.WriteLine("4. Exit");

                if(int.TryParse(Console.ReadLine(), out int input) && input >= 1 && input <= 4)
                {
                    if(input == 1)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Email: {account.Email}");
                        Console.WriteLine($"Username: {account.Username}");
                        Console.WriteLine();
                    }
                    else if(input == 2)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Balance: {account.Balance:C}");
                        Console.WriteLine();
                    }
                    else if (input == 3)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Daily Message: Hello world.");
                        Console.WriteLine();
                    }
                    else if (input == 4)
                    {
                        Console.WriteLine("Exiting...");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            }
        }

        private static async Task<Account> GetAccount()
        {
            Account account = new Account
            {
                Id = Guid.NewGuid(),
                Email = "test@gmail.com",
                Username = "test",
                Balance = 500
            };

            await Task.Delay(3000);

            return account;
        }
    }
}
