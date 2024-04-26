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

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                await _viewModel.LoadCharacters();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error loading characters on startup: {ex}");
                await DisplayAlert("ERROR", "Error retrieving your characters", "Cancel");
            }
        }
        private void MainPage_Loaded(object? sender, EventArgs e)
        {
            
        }
    }

}
