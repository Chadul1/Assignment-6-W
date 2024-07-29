using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CountryAPISummer24.Models;

namespace CountryAPISummer24.Services
{
    /// <summary>
    /// The interface that helps connect the Pokemon class functions.
    /// </summary>
    public interface IPokemonService
    {
        Task<List<Pokemon>> GetPokemonAsync();
    }
}
