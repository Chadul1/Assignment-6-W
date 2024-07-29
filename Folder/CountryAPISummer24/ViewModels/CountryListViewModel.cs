using CountryAPISummer24.Models;
using CountryAPISummer24.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CountryAPISummer24.ViewModels
{
    public class CountryListViewModel : BasePageViewModel
    {
        private readonly ICountryService _countryService;
        private List<Country> _countries;
        private Country _selectedCountry;
        private string _searchText;

        public List<Country> Countries
        {
            get => _countries;
            set => SetProperty(ref _countries, value);
        }
        public Country SelectedCountry
        {
            get => _selectedCountry;
            set => SetProperty(ref _selectedCountry, value);
        }

        public string SearchText
        {
            get => _searchText;
            set => SetProperty(ref _searchText, value);
        }

        public ICommand SearchCommand { get; }
        public ICommand DetailsCommand { get; }
        public ICommand RefreshCommand { get; }

        public CountryListViewModel(ICountryService countryService)
        {
            _countryService = countryService;
            Title = "Country List";

            SearchCommand = new Command(PerformSearch);
            DetailsCommand = new Command(ShowDetails, () => SelectedCountry != null);
            RefreshCommand = new Command(async () => await LoadCountriesAsync());
        }

        private void PerformSearch()
        {
            // Implement search logic
        }

        private void ShowDetails()
        {
            // Implement navigation to details page
        }

        /// <summary>
        /// Begins an async that loads and sets the Countries.
        /// </summary>
        /// <returns></returns>
        public async Task LoadCountriesAsync()
        {
            await ExecuteAsync(async () =>
            {
                Countries = await _countryService.GetCountriesAsync();
            });
        }

        /// <summary>
        /// Calls the LoadCountriesAsync method on bootup.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override async Task InitializeAsync(object parameter)
        {
            await LoadCountriesAsync();
            return;
        }
    }
}
