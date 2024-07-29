using CountryAPISummer24.Views;

namespace CountryAPISummer24
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(CountryListPage), typeof(CountryListPage));
            Routing.RegisterRoute(nameof(PokemonListPage), typeof(PokemonListPage));
        }
    }
}
