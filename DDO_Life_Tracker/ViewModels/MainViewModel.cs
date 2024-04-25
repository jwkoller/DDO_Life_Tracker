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
        private IncarnationDBService _service;
        private readonly ILogger<MainViewModel> _logger;

        public MainViewModel(ILogger<MainViewModel> logger, IncarnationDBService service) 
        { 
            Incarnations = new ObservableCollection<Incarnation>();
            _logger = logger;
            _service = service;
        }

        [RelayCommand]
        public async Task AddIncarnation()
        {
            //TEST
            Character effren = new Character("Effren");
            await _service.SaveCharacterAsync(effren);
            effren = await _service.GetCharacterByName(effren.Name);

            Incarnation newLife = new Incarnation(effren.Id,new Human(), new Monk(12));
            newLife.AddClass(new Fighter(2));
            Incarnations.Add(newLife);

            effren.AddIncarnation(newLife);

            Incarnation secondLife = new Incarnation(effren.Id, new Tabaxi(), new Rogue(20));
            Incarnations.Add(secondLife);

            effren.AddIncarnation(secondLife);

            await _service.SaveCharacterAsync(effren);

            effren = await _service.GetCharacterByIdAsync(effren.Id);

            _logger.LogInformation($"Added new Character life: {newLife.CurrentClass}");
        }

        [RelayCommand]
        public async Task GoToAddIncarnationPage()
        {
            await Shell.Current.GoToAsync(nameof(NewIncarnationPage), true);
        }
    }
}
