using CountryAPISummer24.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CountryAPISummer24.Services
{
    public class CountryService : ICountryService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<CountryService> _logger;

        public CountryService(IHttpClientFactory httpClientFactory, ILogger<CountryService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<List<Country>> GetCountriesAsync()
        {
            try
            {
                var client = _httpClientFactory.CreateClient("CountryAPI");
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(client.BaseAddress + "location/country/list?format=json"),
                    Headers =
                    {
                        { "x-rapidapi-key", "4a2245ab73msh3603b3dd8459aa4p189107jsn23c4550b9ff9" },
                        { "x-rapidapi-host", "countries-cities.p.rapidapi.com" },
                    },
                };

                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var jsonString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                var jObject = JObject.Parse(jsonString);
                var countriesObject = jObject["countries"] as JObject;

                if (countriesObject == null)
                {
                    throw new JsonException("Unexpected JSON structure: 'countries' property not found or not an object");
                }

                var countries = countriesObject.Properties()
                    .Select(p => new Country { Code = p.Name, Name = p.Value.ToString() })
                    .ToList();

                return countries;
            }
            catch (HttpRequestException e)
            {
                _logger.LogError(e, "Error fetching countries from API");
                throw;
            }
            catch (JsonException e)
            {
                _logger.LogError(e, "Error deserializing API response");
                throw;
            }
        }

    }
}

