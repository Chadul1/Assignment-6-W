using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CountryAPISummer24.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CountryAPISummer24.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<CountryService> _logger;

        public PokemonService(IHttpClientFactory httpClientFactory, ILogger<CountryService> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<List<Pokemon>> GetPokemonAsync()
        {
            try 
            {
                var client = _httpClientFactory.CreateClient("PokemonAPI");
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(client.BaseAddress + "pokedex/uk"),
                    Headers =
                    {
                        { "x-rapidapi-key", "05d8a41b55msh42166a0c1d3ff17p186398jsnb603f2ebdac6" },
                        { "x-rapidapi-host", "pokedex2.p.rapidapi.com" },
                    },
                };

                using (var response = await client.SendAsync(request))
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    List<Pokemon> Class = await Task.Run(() => JsonConvert.DeserializeObject<List<Pokemon>>(body));

                    return Class ?? new List<Pokemon>();
                }
            }
            catch (HttpRequestException e)
            {
                _logger.LogError(e, "Error fetching Pokemon from API");
                throw;
            }
            catch (JsonException e)
            {
                _logger.LogError(e, "Error deserializing API response");
                throw;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in GetPokemonAsync: {ex}");
                throw;
            }
        }
    }
}
