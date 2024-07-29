using CountryAPISummer24.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryAPISummer24.Services
{
    /// <summary>
    /// The interface that helps connect the country service class functions.
    /// </summary>
    public interface ICountryService
    {
        Task<List<Country>> GetCountriesAsync();
    }
}
