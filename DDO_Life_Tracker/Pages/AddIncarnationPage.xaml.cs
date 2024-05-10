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
			DisplayAlert("Error", $"Failed adding the class: {ex.Message}", "Ok");
		}
	}

	private async void OnClickAddIncarntaionToCharacter(object sender, EventArgs e)
	{
		try
		{
			await _viewModel.AddIncarnationToCharacter();
            _ = Toast.Make("New character life added.", CommunityToolkit.Maui.Core.ToastDuration.Short, 12).Show();
        }
        catch (Exception ex)
		{
			_logger.LogError($"Error adding incarnation to character: {ex}");
			await DisplayAlert("Error", $"Unable to add new incarnation to character: {ex.Message}", "Ok");
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
			await DisplayAlert("Error", $"Saving character failed: {ex.Message}", "Ok");
		}
	}

	private async void OnClickDeleteCharacter(object sender, EventArgs e)
	{
		try
		{
			bool confirm = await DisplayAlert("Warning", "Are you sure you want to permanently delete this character?", "Yes", "No");
			if (confirm)
			{
                bool doubleConfirm = await DisplayAlert("No really...", "Like sure, sure?", "Delete it already", "On second thought, no");
				if (doubleConfirm)
				{
                    await _viewModel.DeleteCharacter();
                    await Shell.Current.GoToAsync("..");
                }
            }		
		}
		catch (Exception ex)
		{
            _logger.LogError($"Error deleting character: {ex}");
            await DisplayAlert("Error", $"Failed to delete character: {ex.Message}", "Ok");
        }
	}
}