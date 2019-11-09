using Newtonsoft.Json;
using PlaygroundDotNet.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PlaygroundDotNet.Managers
{
    public class CountriesManager
    {
        HttpClient _httpClient;
        Country[] _countries;

        public CountriesManager()
        {
            _httpClient = new HttpClient();
        }

        public async Task<Country[]> GetEuropeanCountries()
        {
            if (_countries != null)
            {
                List<Country> europeanCountries = new List<Country>();
                foreach(Country country in _countries)
                {
                    if (country.Region == "Europe")
                    {
                        europeanCountries.Add(country);
                    }
                }
                return europeanCountries.ToArray();
            }
            else
            {
                await GetAll();
                List<Country> europeanCountries = new List<Country>();
                foreach (Country country in _countries)
                {
                    if (country.Region == "Europe")
                    {
                        europeanCountries.Add(country);
                    }
                }
                return europeanCountries.ToArray();
            }
        }

        public async Task GetAll()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("https://restcountries.eu/rest/v2/all");
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();
                _countries = JsonConvert.DeserializeObject<Country[]>(content);
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                Console.WriteLine("Countries API is momentarily unavailable.");
            }
            else if (response.StatusCode == HttpStatusCode.InternalServerError)
            {
                Console.WriteLine("Countries API encountered an error.");
            }
            else
            {
                Console.WriteLine("An error has occured while fetching all countries.");
            }
        }
    }
}
