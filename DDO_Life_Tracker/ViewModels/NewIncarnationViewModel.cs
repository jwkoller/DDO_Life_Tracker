using CommunityToolkit.Mvvm.ComponentModel;
using DDO_Life_Tracker.Services;
using Microsoft.Extensions.Logging;

namespace DDO_Life_Tracker.ViewModels
{
    public partial class NewIncarnationViewModel : ObservableObject
    {
        [ObservableProperty]
        private IEnumerable<string> _selectableClasses;

        [ObservableProperty]
        private IEnumerable<string> _selectableRaces;

        private ILogger<NewIncarnationViewModel> _logger;
        public NewIncarnationViewModel(ILogger<NewIncarnationViewModel> logger)
        {
            _logger = logger;
            _selectableClasses = Definitions.AllDdoClasses.Select(x => x.Replace("_", " "));
            _selectableRaces = new List<string>();
        }


    }
}
