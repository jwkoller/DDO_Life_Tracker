using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DDO_Life_Tracker.Models;
using DDO_Life_Tracker.Services;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;

namespace DDO_Life_Tracker.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Incarnation> _incarnations;
        private IncarnationsDBService _service;
        private readonly ILogger<MainViewModel> _logger;

        public MainViewModel(ILogger<MainViewModel> logger, IncarnationsDBService service) 
        { 
            Incarnations = new ObservableCollection<Incarnation>();
            _logger = logger;
            _service = service;
        }

        [RelayCommand]
        public async Task AddIncarnation()
        {
            //TEST
            Incarnation newLife = new Incarnation(10,new Human(), new Monk(12));
            newLife.AddClass(new Fighter(6));
            newLife.AddClass(new Rogue(2));
            Incarnations.Add(newLife);

            List<Incarnation> saved = await _service.GetIncarnationsByCharacterIdAsync(10);
            _logger.LogInformation($"Added new Character life: {newLife.CurrentClass}");
        }

        [RelayCommand]
        public async Task GoToAddIncarnationPage()
        {
            await Shell.Current.GoToAsync(nameof(NewIncarnationPage), true);
        }
    }
}
