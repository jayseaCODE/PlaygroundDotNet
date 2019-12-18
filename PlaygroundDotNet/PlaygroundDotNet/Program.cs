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
                GameBoard gameBoard = new GameBoard();
                gameBoard.PlayArea(1);
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to initialize game.");
            }

            GameBoard gameBoard = new GameBoard();
            gameBoard.PlayArea(1);
            Console.ReadKey();
        }
    }
}
