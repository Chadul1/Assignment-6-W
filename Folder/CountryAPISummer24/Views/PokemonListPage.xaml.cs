using CountryAPISummer24.ViewModels;


namespace CountryAPISummer24.Views;
public partial class PokemonListPage : ContentPage
{
    private PokemonListViewModel _viewModel;

    public PokemonListPage(PokemonListViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = _viewModel = viewModel;
    }

    /// <summary>
    /// The result of the picker is made to be checked and entered into a method that finds pokemon of the chosen type.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private async void OnPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        //finds the picker, gets the selected item, and then lowers it for consistency sake.
        Picker picker = sender as Picker;
        string selectedItem = (string)picker.SelectedItem;
        string result = selectedItem.ToLower();
        
        //checks to see if the result is null, just to be safe :)
        if (result != null)
        {
            //If all, then it refreshes the list using a backup. This is to lower the amount of API pulls.
            if (result == "all")
            {
                _viewModel.RefreshList();
            }
            else
            {
                //Calls a method using the chosen result. 
                await _viewModel.LoadPokemonTypeAsync(result);
            }
        }
    }

    /// <summary>
    /// Loads the viewmodel on bootup to be used for display functions.
    /// </summary>
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.InitializeAsync(null);
    }
}