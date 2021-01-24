using LazyDemo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LazyDemo.Services
{
    public class AccountService
    {
        public async Task<Account> LoadAccount()
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
