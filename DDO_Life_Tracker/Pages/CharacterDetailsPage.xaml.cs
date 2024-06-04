using DDO_Life_Tracker.ViewModels;
using MetroLog;
using Microsoft.Extensions.Logging;

namespace DDO_Life_Tracker.Pages;

public partial class CharacterDetailsPage : ContentPage
{
	private readonly ILogger<CharacterDetailsPage> _logger;
	private readonly CharacterDetailsViewModel _viewModel;
	public CharacterDetailsPage(CharacterDetailsViewModel viewModel, ILogger<CharacterDetailsPage> logger)
	{
		_logger = logger;
		InitializeComponent();
		BindingContext = viewModel;

		_viewModel = viewModel;
	}
}