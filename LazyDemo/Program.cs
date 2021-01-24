using LazyDemo.Models;
using System;
using System.Threading.Tasks;


namespace LazyDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Task<Account> accountTask = CreateAccount();
            Lazy<Task<Account>> getAccount = new Lazy<Task<Account>>(CreateAccount);

            Account account1 = await accountTask;
            Account account2 = await accountTask;

            Console.WriteLine(account1.Id);
            Console.WriteLine(account2.Id);

            Console.ReadLine();
        }

        private static async Task<Account> CreateAccount()
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
