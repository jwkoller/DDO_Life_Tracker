using DDO_Life_Tracker.ViewModels;
using MetroLog;
using Microsoft.Extensions.Logging;

namespace DDO_Life_Tracker.Pages;

public partial class AddCharacterPage : ContentPage
{
	private AddCharacterViewModel _viewModel;
	private readonly ILogger<AddCharacterPage> _logger;

	public AddCharacterPage(AddCharacterViewModel viewModel, ILogger<AddCharacterPage> logger)
	{
		InitializeComponent();
		BindingContext = viewModel;

		_logger = logger;
		_viewModel = viewModel;
	}

    private async void OnNameEntered(object sender, EventArgs e)
    {
        try
		{
            bool nameExists = await _viewModel.CheckCharacterNameExists();

			if (!nameExists)
			{
                await _viewModel.SaveNewCharacter();
                await DisplayAlert("Save Success", $"Character created", "Ok");
            } 
			else
			{
                await DisplayAlert("Duplicate Character", $"A character with the same name already exists.", "Ok");
            }
        }
		catch(Exception ex)
		{
			_logger.LogError($"Error checking name: {ex}");
		}
    }
}