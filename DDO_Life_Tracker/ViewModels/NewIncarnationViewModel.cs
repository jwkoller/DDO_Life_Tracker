using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.Logging;

namespace DDO_Life_Tracker.ViewModels
{
    public partial class NewIncarnationViewModel : ObservableObject
    {
        [ObservableProperty]
        private List<string> _selectableClasses;

        [ObservableProperty]
        private List<string> _selectableRaces;

        private ILogger<NewIncarnationViewModel> _logger;
        public NewIncarnationViewModel(ILogger<NewIncarnationViewModel> logger)
        {
            _logger = logger;
            _selectableClasses = new List<string>();
            _selectableRaces = new List<string>();
        }


    }
}
