using CountryAPISummer24.ViewModels;

namespace CountryAPISummer24.Views;

public partial class CountryListPage : ContentPage
{
    private CountryListViewModel _viewModel;

    public CountryListPage(CountryListViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.InitializeAsync(null);
    }
}