using DDO_Life_Tracker.ViewModels;
using MetroLog;
using Microsoft.Extensions.Logging;

namespace DDO_Life_Tracker;

public partial class AddIncarnationPage : ContentPage
{
	private AddIncarnationViewModel _viewModel;
	private readonly ILogger<AddIncarnationPage> _logger;
	public AddIncarnationPage(AddIncarnationViewModel viewModel, ILogger<AddIncarnationPage> logger)
	{
		_logger = logger;
		InitializeComponent();
		BindingContext = viewModel;

		_viewModel = viewModel;
	}

	private void OnClickAddClass(object sender, EventArgs e)
	{
		try
		{
			_viewModel.AddClassToIncarnation();
		}
		catch (Exception ex)
		{
			_logger.LogError($"Error adding class to incarnation btn click: {ex}");
			DisplayAlert("Error", $"There was an error adding the class: {ex.Message}", "Ok");
		}
	}

	private async void OnSaveCharacterClick(object sender, EventArgs e)
	{
		try
		{
			await _viewModel.SaveCharacter();
			await DisplayAlert("Save Success", "Character saved.", "Ok");
		}
		catch (Exception ex)
		{
			_logger.LogError($"Error saving character: {ex}");
			await DisplayAlert("Error", $"There was an error saving the character", "Ok");
		}
	}
}