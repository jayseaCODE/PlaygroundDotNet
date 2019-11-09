using PlaygroundDotNet.Managers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PlaygroundDotNet
{
    public class SingleResponsibilityExample
    {
        public static void Run(string[] args)
        {
            testCountries().Wait();
            Console.ReadKey();
        }

        private async static Task testCountries()
        {
            CountriesManager manager = new CountriesManager();
            var countries = await manager.GetEuropeanCountries();
            foreach(var country in countries)
            {
                Console.WriteLine(country.ToString());
            }
        }
    }
}
