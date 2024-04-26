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
        private ObservableCollection<Character> _characters;
        private IncarnationDBService _service;
        private readonly ILogger<MainViewModel> _logger;

        public MainViewModel(ILogger<MainViewModel> logger, IncarnationDBService service) 
        { 
            Characters = new ObservableCollection<Character>();
            _logger = logger;
            _service = service;
        }

        [RelayCommand]
        public async Task AddCharacter()
        {
            //TEST
            Character effren = new Character("Bob");
            effren.Id = await _service.SaveCharacterAsync(effren);

            Incarnation newLife = new Incarnation(effren.Id,new Aasimar(), new Monk(12));
            newLife.AddClass(new Fighter(2));

            effren.AddIncarnation(newLife);

            Incarnation secondLife = new Incarnation(effren.Id, new Shifter(), new Wizard(20));

            effren.AddIncarnation(secondLife);

            await _service.SaveCharacterAsync(effren);
            Characters.Add(effren);
            _logger.LogInformation($"Added new Character life: {newLife.CurrentClass}");
        }

        public async Task LoadCharacters()
        {
            Characters.Clear();
            List<Character> chars = await _service.GetCharactersAsync();
            foreach (Character c in chars)
            {
                Characters.Add(c);
            }
        }

        [RelayCommand]
        public async Task GoToAddIncarnationPage()
        {
            await Shell.Current.GoToAsync(nameof(NewIncarnationPage), true);
        }
    }
}
