using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using PlaygroundDotNet.Managers;

namespace PlaygroundDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            //SingleResponsibilityExample.Run(args);
            try
            {
                TestWebApiConnection().Wait();
                GameBoard gameBoard = new GameBoard();
                gameBoard.PlayArea(1);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to initialize game.");
            }
        }

        static async Task TestWebApiConnection()
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = new HttpResponseMessage();

            int retryCurrentDelay = 100; // 100 milliseconds
            int retryMaxDelay = 1000; // 1 seconds
            bool retry = false, tryGetResponse = true;

            while (tryGetResponse)
            {
                try
                {
                    response = await httpClient.GetAsync("https://localhost:44365/api/cards");
                    if (response.StatusCode == System.Net.HttpStatusCode.OK) return;
                    else
                    {
                        retryCurrentDelay = await CarryOutExponentialBackoffRetries(retry, retryCurrentDelay, retryMaxDelay);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to connect to server.");
                }
            }
        }

        static async Task<int> CarryOutExponentialBackoffRetries(bool retry, int retryCurrentDelay, int retryMaxDelay)
        {
            // Retry getting a response using exponential backoff
            if (retryCurrentDelay > retryMaxDelay)
            {
                throw new Exception("Too many retry attempts.");
            }
            await Task.Delay(retryCurrentDelay).ConfigureAwait(false);
            retryCurrentDelay *= 2;

            return retryCurrentDelay;
        }

        
    }
}
