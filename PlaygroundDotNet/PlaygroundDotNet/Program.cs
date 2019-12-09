using System;
using PlaygroundDotNet.Managers;

namespace PlaygroundDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            //SingleResponsibilityExample.Run(args);

            GameBoard gameBoard = new GameBoard();
            gameBoard.PlayArea(1);
            Console.ReadKey();
        }
    }
}
