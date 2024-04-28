using DDO_Life_Tracker.ViewModels;

namespace DDO_Life_Tracker;

public partial class NewIncarnationPage : ContentPage
{
	private NewIncarnationViewModel _viewModel;
	public NewIncarnationPage(NewIncarnationViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;

		_viewModel = viewModel;
	}
}