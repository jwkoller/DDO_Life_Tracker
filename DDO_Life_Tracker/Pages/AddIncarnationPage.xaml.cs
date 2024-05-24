using CommunityToolkit.Maui.Alerts;
using DDO_Life_Tracker.Models;
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

	private void OnClickClassButton(object sender, EventArgs e)
	{
		try
		{
			_viewModel.ClassButtonHandler();
        }
		catch (Exception ex)
		{
			_logger.LogError($"Error adding/updating class to incarnation btn click: {ex}");
			DisplayAlert("Error", $"Character update failed: {ex.Message}", "Ok");
		}
	}

	private async void OnClickIncarnationButton(object sender, EventArgs e)
	{
		try
		{
			await _viewModel.IncarnationButtonHandler();
            _ = Toast.Make("Character updated.", CommunityToolkit.Maui.Core.ToastDuration.Short, 12).Show();
        }
        catch (Exception ex)
		{
			_logger.LogError($"Error adding/updating incarnation to character: {ex}");
			await DisplayAlert("Error", $"Character update failed: {ex.Message}", "Ok");
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

	private async void OnClickEditIncarnation(object sender, TappedEventArgs e)
	{
		try
		{
			if(e.Parameter?.GetType() == typeof(Incarnation))
			{
				_viewModel.SetIncarnationToEdit((Incarnation)e.Parameter);
			}
		}
		catch(Exception ex)
		{
            _logger.LogError($"Error selecting incarnation from list to edit: {ex}");
            await DisplayAlert("Error", $"Failed to select incarnation: {ex.Message}", "Ok");
        }
	}

	private async void OnClickEditClass(object sender, TappedEventArgs e)
	{
        try
        {
            if (e.Parameter != default)
            {
                _viewModel.SetClassToEdit((IClass)e.Parameter);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error selecting class from list to edit: {ex}");
            await DisplayAlert("Error", $"Failed to select class: {ex.Message}", "Ok");
        }
    }

	private async void OnClickDeleteClass(object sender, TappedEventArgs e)
	{
		try
		{
            if (e.Parameter != default)
            {
                _viewModel.DeleteClassButtonHandler((IClass)e.Parameter);
            }
        }
		catch(Exception ex) 
		{
            _logger.LogError($"Error deleting class from list to edit: {ex}");
            await DisplayAlert("Error", $"Unable to delete class: {ex.Message}", "Ok");
        }
	}

	private async void OnClickDeleteIncarnation(object sender, EventArgs e)
	{
		try
		{
            bool confirm = await DisplayAlert("Delete Character Life", "Delete the selected incarnation from the character?", "Yes", "No");
            if (confirm)
            {
                await _viewModel.DeleteIncarnationButtonHandler();
            }
        }
		catch(Exception ex)
		{
            _logger.LogError($"Error deleting incarnation from character: {ex}");
            await DisplayAlert("Error", $"Failed to remove selected character life: {ex.Message}", "Ok");
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

	private async void OnClickGoBack(object sender, EventArgs e)
	{
        await Shell.Current.GoToAsync("..");
    }

    private void OnExpandedCharacterView(object sender, CommunityToolkit.Maui.Core.ExpandedChangedEventArgs e)
    {
		_viewModel.RotateCharacterViewExpanderArrow();
    }
}