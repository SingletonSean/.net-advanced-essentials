using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskCompletionSourceDemo.Services
{
    public class WebAuthenticationService
    {
        public bool LoginFailed { get; set; }

        public async Task<string> GetAccessToken()
        {
            TaskCompletionSource<string> accessTokenTaskSource = new TaskCompletionSource<string>();

            // Start a new thread for UI popup.
            new Thread(() =>
            {
                // Waiting for user to enter login credentials...
                Thread.Sleep(500);

                if (LoginFailed)
                {
                    accessTokenTaskSource.SetException(new Exception("invalid_credentials"));
                }
                else
                {
                    accessTokenTaskSource.SetResult("access_token");
                }
            }).Start();

            string accessToken = await accessTokenTaskSource.Task;

            return accessToken;
        }
    }
}
