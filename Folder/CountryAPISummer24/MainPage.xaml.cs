using CountryAPISummer24.ViewModels;

namespace CountryAPISummer24;

public partial class MainPage : ContentPage
{
	public MainPage(MainPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}