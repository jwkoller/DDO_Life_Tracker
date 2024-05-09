using CommunityToolkit.Mvvm.Input;
using DDO_Life_Tracker.Models;
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

            _viewModel = viewModel;
            _logger = logger;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadCharactersFromDB();
        } 

        private async Task LoadCharactersFromDB()
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

        private async void OnCharacterViewClick(object sender, TappedEventArgs e)
        {
            if(e.Parameter?.GetType() == typeof(Character))
            {
                _viewModel.SetFocusedCharacter((Character)e.Parameter);
            }

            try
            {
                await _viewModel.GoToAddIncarnationPage();
            }
            catch(Exception ex)
            {
                _logger.LogError($"Error going to incarnation page: {ex}");
                await DisplayAlert("ERROR", "Select a character", "Ok");
            }
        }
    }
}
