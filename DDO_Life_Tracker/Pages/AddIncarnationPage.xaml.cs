using CommunityToolkit.Maui.Alerts;
using DDO_Life_Tracker.ViewModels;
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
			_viewModel.AddClass();
        }
		catch (Exception ex)
		{
			_logger.LogError($"Error adding class to incarnation btn click: {ex}");
			DisplayAlert("Error", $"Error adding the class: {ex.Message}", "Ok");
		}
	}

	private void OnClickAddIncarntaionToCharacter(object sender, EventArgs e)
	{
		try
		{
			_viewModel.AddIncarnationToCharacter();
            Toast.Make("New character life added.", CommunityToolkit.Maui.Core.ToastDuration.Short, 12).Show();
        }
        catch (Exception ex)
		{
			_logger.LogError($"Error adding incarnation to character: {ex}");
			DisplayAlert("Error", $"Error adding new incarnation to character: {ex.Message}", "Ok");
		}
	}

	private async void OnClickSaveCharacter(object sender, EventArgs e)
	{
		try
		{
			await _viewModel.SaveCharacter();
            _ = Toast.Make("Character saved.", CommunityToolkit.Maui.Core.ToastDuration.Short, 12).Show();
		}
		catch (Exception ex)
		{
			_logger.LogError($"Error saving character: {ex}");
			await DisplayAlert("Error", $"Error saving the character: {ex.Message}", "Ok");
		}
	}
}