using CommunityToolkit.Mvvm.Input;
using DDO_Life_Tracker.ViewModels;
using MetroLog;
using Microsoft.Extensions.Logging;

namespace DDO_Life_Tracker
{
    public partial class MainPage : ContentPage
    {
        private MainViewModel _viewModel;
        private readonly ILogger<MainPage> _logger;

        public MainPage(MainViewModel viewModel, ILogger<MainPage> logger)
        {
            InitializeComponent();
            BindingContext = viewModel;
            Loaded += MainPage_Loaded;
            _viewModel = viewModel;
            _logger = logger;
        }

        private async void MainPage_Loaded(object? sender, EventArgs e)
        {
            try
            {
                await _viewModel.LoadCharacters();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error loading characters OnAppearing: {ex}");
                await DisplayAlert("ERROR", "Error retrieving your characters", "Cancel");
            }
        }
 
        private async void AddCharacterTEST(object? sender, EventArgs e)
        {
            try
            {
                await _viewModel.AddCharacterTEST();
            }
            catch (SQLite.SQLiteException ex)
            {
                await DisplayAlert("ERROR", $"Error saving your character: {ex.Message}", "Ok");
            }
            catch(Exception ex)
            {
                await DisplayAlert("ERROR", $"The program has encountered an error: {ex.Message}", "Well shit");
            }
        }
    }
}
