using System;
using System.Threading.Tasks;
using TaskCompletionSourceDemo.Services;

namespace TaskCompletionSourceDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            WebAuthenticationService authenticator = new WebAuthenticationService();

            authenticator.LoginFailed = false;

            try
            {
                string token = await authenticator.GetAccessToken();
                Console.WriteLine(token);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
