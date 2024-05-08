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
        private Character _focusedCharacter;

        public MainPage(MainViewModel viewModel, ILogger<MainPage> logger)
        {
            InitializeComponent();
            BindingContext = viewModel;

            Loaded += OnLoaded;
            _viewModel = viewModel;
            _logger = logger;
        }

        private async void OnLoaded(object? sender, EventArgs e)
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

        private async void DeleteCharacter(object? sender, EventArgs args)
        {
            try
            {
                bool confirm = await DisplayAlert("Confirm Delete", $"Are you sure you want to delete {_focusedCharacter.Name}?", "Yes", "Cancel");
                if (confirm)
                {
                    await _viewModel.DeleteCharacter(_focusedCharacter);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error deleting character: {ex}");
                await DisplayAlert($"ERROR", $"Delete Character failed for {_focusedCharacter.Name}. {ex.Message}", "Shit...");
            }
        }

        private async void OnCharacterViewClick(object sender, TappedEventArgs e)
        {
            if(e.Parameter?.GetType() == typeof(Character))
            {
                _viewModel.SetFocusedCharacter((Character)e.Parameter);
            }

            await _viewModel.GoToAddIncarnationPage();
        }

        private async void OnDoubleTapCharacter(object sender, TappedEventArgs e)
        {
            if (e.Parameter?.GetType() == typeof(Character))
            {
                _focusedCharacter = (Character)e.Parameter;
            }

            await _viewModel.GoToAddIncarnationPage();
        }
    }
}
