using System;

namespace PlaygroundDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            //SingleResponsibilityExample.Run(args);

            PrimaryPlayer primaryPlayer = PrimaryPlayer.Instance;
            Console.ReadKey();
        }
    }
}
