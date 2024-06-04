using CommunityToolkit.Mvvm.ComponentModel;
using DDO_Life_Tracker.Models;
using MetroLog;
using Microcharts;
using Microsoft.Extensions.Logging;

namespace DDO_Life_Tracker.ViewModels
{
    [QueryProperty("CurrentCharacter", "CurrentCharacter")]
    public partial class CharacterDetailsViewModel : ObservableObject
    {
        // QueryProperty
        [ObservableProperty]
        private Character _currentCharacter;

        [ObservableProperty]
        private Chart _chart;


        private readonly ILogger<CharacterDetailsViewModel> _logger;

        public CharacterDetailsViewModel(ILogger<CharacterDetailsViewModel> logger)
        {
            _chart = new BarChart();
        }
    }
}
