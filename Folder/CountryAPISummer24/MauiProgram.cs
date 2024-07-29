using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;
using CountryAPISummer24.ViewModels;
using CountryAPISummer24.Services;
using CountryAPISummer24.Views;

namespace CountryAPISummer24
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddHttpClient("PokemonAPI", client => 
            {
                client.BaseAddress = new Uri("https://pokedex2.p.rapidapi.com/");
            });

            builder.Services.AddHttpClient("CountryAPI", client =>
            {
                client.BaseAddress = new Uri("https://countries-cities.p.rapidapi.com/");
            });

            builder.Services.AddLogging();
            builder.Logging.AddDebug();

            builder.Services.AddTransient<ICountryService, CountryService>();
            builder.Services.AddTransient<IPokemonService, PokemonService>();

            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<MainPageViewModel>();
            builder.Services.AddTransient<CountryListViewModel>();
            builder.Services.AddTransient<PokemonListViewModel>();
            builder.Services.AddTransient<CountryListPage>();
            builder.Services.AddTransient<PokemonListPage>();
            builder.Services.AddTransient<ICountryService, CountryService>();
            builder.Services.AddTransient<IPokemonService, PokemonService>();

            return builder.Build();
        }
    }
}
