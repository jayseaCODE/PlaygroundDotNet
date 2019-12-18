using System;
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
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to connect to server.");
                }
            }
        }

            GameBoard gameBoard = new GameBoard();
            gameBoard.PlayArea(1);
            Console.ReadKey();
        }
    }
}
