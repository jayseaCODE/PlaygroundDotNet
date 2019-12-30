using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Common;
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

        static void TestDecorators()
        {
            Card soldier = new Card("Soldier", 25, 20);
            soldier = new AttackDecorator(soldier, "Sword", 15);
            soldier = new AttackDecorator(soldier, "Amulet", 5);
            soldier = new DefenseDecorator(soldier, "Helmet", 10);
            soldier = new DefenseDecorator(soldier, "Heavy Armour", 45);
            Console.WriteLine($"Soldier final stats: Attack {soldier.Attack} Defense {soldier.Defense}");
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
