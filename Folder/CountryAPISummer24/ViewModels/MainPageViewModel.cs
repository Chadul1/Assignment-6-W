using System.Windows.Input;
using CountryAPISummer24.Views;

namespace CountryAPISummer24.ViewModels
{
    /// <summary>
    /// 
    /// </summary>
    public class MainPageViewModel : BasePageViewModel
    {
        public ICommand NavigateToCountryListCommand { get; }
        public ICommand NavigateToPokemonCommand { get; }

        public MainPageViewModel()
        {
            //Sets the title of the Xaml Page.
            Title = "API Explorer";

            NavigateToCountryListCommand = new Command(async () => await NavigateToCountryList());
            NavigateToPokemonCommand = new Command(async () => await NavigateToPokemon());
        }

        /// <summary>
        /// Using the name routes set earlier, the method sends the user to the PokemonListPage.
        /// </summary>
        /// <returns></returns>
        private async Task NavigateToCountryList()
        {
            //Goes to the Country List page.
            await Shell.Current.GoToAsync(nameof(CountryListPage));
        }

        /// <summary>
        /// Using the name routes set earlier, the method sends the user to the PokemonListPage.
        /// </summary>
        /// <returns></returns>
        private async Task NavigateToPokemon()
        {
            // Will eventually go to the Pokemon Page.
            await Shell.Current.GoToAsync(nameof(PokemonListPage));
        }
    }
}