using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CountryAPISummer24.Models;
using CountryAPISummer24.Services;

namespace CountryAPISummer24.ViewModels
{
    public class PokemonListViewModel : BasePageViewModel
    {
        private readonly IPokemonService _pokemonService;
        private List<Pokemon> _pokemon;
        private List<Pokemon> _backupList;
        private Pokemon _selectedPokemon;
        private string _searchText;

        public List<Pokemon> Pokemon
        {
            get => _pokemon;
            set => SetProperty(ref _pokemon, value);
        }

        public List<Pokemon> BackupList
        {
            get => _backupList;
            set => SetProperty(ref _backupList, value);
        }

        public Pokemon SelectedPokemon
        {
            get => _selectedPokemon;
            set => SetProperty(ref _selectedPokemon, value);
        }

        public string SearchText
        {
            get => _searchText;
            set => SetProperty(ref _searchText, value);
        }

        public ICommand SearchCommand { get; }
        public ICommand DetailsCommand { get; }
        public ICommand RefreshCommand { get; }

        public PokemonListViewModel(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
            //Instantiates the new list.
            _backupList = new List<Pokemon>();
            //Sets the title of the page.
            Title = "Pokemon List";

            SearchCommand = new Command(PerformSearch);
            DetailsCommand = new Command(ShowDetails, () => SelectedPokemon != null);
            RefreshCommand = new Command(async () => await LoadPokemonAsync());
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
        /// Pulls the api and loads the information on it.
        /// </summary>
        /// <returns></returns>
        public async Task LoadPokemonAsync()
        {
            await ExecuteAsync(async () =>
            {
                Pokemon = await _pokemonService.GetPokemonAsync();
                BackupList = Pokemon;
            });
        }

        /// <summary>
        /// Loads the Pokemon of the chosen type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public async Task LoadPokemonTypeAsync(string type)
        {
            //First Refreshes the Pokemon list to be read and pulled from.
            //This make it so that pokemon previously removed won't be left out. 
            this.RefreshList();
            List<Pokemon> tempList = new List<Pokemon>();

            //Looks at the pokemon in the pokemon list. Then checks their type arrays in a secondary Foreach. 
            foreach (Pokemon p in Pokemon)
            {
                foreach (string a in p.Type)
                {
                    if (a == type)
                    {
                        tempList.Add(p);
                    }
                }
            }

            //Was unsure of this inclusion though,so I left it commented.
            //Seems to mess with the same .ConfigureAsync(false) thing you pointed out prevously. Something with Threading that I'm unsure would be wise to enable. 
            //Parallel.ForEach(Pokemon, p =>
            //{
            //    foreach (string a in p.Type)
            //    {
            //        if (a == type)
            //        {
            //            tempList.Add(p);
            //        }
            //    }
            //});

            Pokemon = tempList;            
        }

        /// <summary>
        /// Refreshes the Pokemon List for Scrubbing for pokemon types.
        /// </summary>
        public void RefreshList()
        {
            Pokemon = BackupList;
        }

        /// <summary>
        /// Loads the Pokemon Automatically.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public override async Task InitializeAsync(object parameter)
        {
            await LoadPokemonAsync();
        }
    }
}
