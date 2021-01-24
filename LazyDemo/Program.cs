using LazyDemo.Models;
using LazyDemo.Services;
using System;
using System.Threading;
using System.Threading.Tasks;


namespace LazyDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            AccountService accountService = new AccountService();

            Console.WriteLine("Press enter to login.");
            Console.ReadLine();

            Console.WriteLine("Successfully logged in.");

            AsyncLazy<Account> getAccount = new AsyncLazy<Account>(() => accountService.LoadAccount());

            while(true)
            {
                Console.WriteLine("Enter the number corresponding to the desired action:");
                Console.WriteLine("1. Show Account Details");
                Console.WriteLine("2. Show Balance");
                Console.WriteLine("3. Refresh Account");
                Console.WriteLine("4. Exit");

                if(int.TryParse(Console.ReadLine(), out int input) && input >= 1 && input <= 4)
                {
                    if(input == 1)
                    {
                        Account account = await getAccount.Value;

                        Console.WriteLine();
                        Console.WriteLine($"Account Id: {account.Id}");
                        Console.WriteLine($"Email: {account.Email}");
                        Console.WriteLine($"Username: {account.Username}");
                        Console.WriteLine();
                    }
                    else if(input == 2)
                    {
                        Account account = await getAccount.Value;

                        Console.WriteLine();
                        Console.WriteLine($"Account Id: {account.Id}");
                        Console.WriteLine($"Balance: {account.Balance:C}");
                        Console.WriteLine();
                    }
                    else if (input == 3)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Refreshing...");
                        Console.WriteLine();

                        getAccount = new AsyncLazy<Account>(() => accountService.LoadAccount());
                        await getAccount.Value;
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
    }

    class AsyncLazy<T> : Lazy<Task<T>>
    {
        public AsyncLazy()
        {
        }

        public AsyncLazy(bool isThreadSafe) : base(isThreadSafe)
        {
        }

        public AsyncLazy(Func<Task<T>> valueFactory) : base(valueFactory)
        {
        }

        public AsyncLazy(LazyThreadSafetyMode mode) : base(mode)
        {
        }

        public AsyncLazy(Task<T> value) : base(value)
        {
        }

        public AsyncLazy(Func<Task<T>> valueFactory, bool isThreadSafe) : base(valueFactory, isThreadSafe)
        {
        }

        public AsyncLazy(Func<Task<T>> valueFactory, LazyThreadSafetyMode mode) : base(valueFactory, mode)
        {
        }
    }
}
