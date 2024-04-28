using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DDO_Life_Tracker.Models;
using DDO_Life_Tracker.Pages;
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

        public async Task AddCharacterTEST()
        {

            //TEST
            Character effren = new Character("Effren");
            effren.Id = await _service.SaveCharacterAsync(effren);

            Incarnation newLife = new Incarnation(effren.Id,new Aasimar(), [new Monk(12), new Fighter(8)]);
            effren.AddIncarnation(newLife);
            Incarnation secondLife = new Incarnation(effren.Id, new Shifter(), new Wizard(20));
            effren.AddIncarnation(secondLife);

            await _service.SaveCharacterAsync(effren);
            Characters.Add(effren);

            Character bob = new Character("Bob");
            bob.Id = await _service.SaveCharacterAsync(bob);

            Characters.Add(bob);

            Incarnation bobLife = new Incarnation(bob.Id, new Gnome(), [new Rogue(11), new Fighter(9)]);
            bob.AddIncarnation(bobLife);
            Incarnation bobSecond = new Incarnation(bob.Id, new Tabaxi(), [new Bard(16), new Fighter(2), new Rogue(2)]);
            bob.AddIncarnation(bobSecond);
            Incarnation bobThird = new Incarnation(bob.Id, new Elf(), new Cleric(20));
            bob.AddIncarnation(bobThird);
        }

        public async Task DeleteCharacterTEST(Character character)
        {
            await _service.DeleteCharacterAsync(character);
            await LoadCharacters();
        }

        public async Task LoadCharacters()
        {
            Characters.Clear();
            List<Character> chars = await _service.GetCharactersAsync();

            chars.ForEach(c => Characters.Add(c));
        }

        [RelayCommand]
        public async Task GoToAddIncarnationPage()
        {
            await Shell.Current.GoToAsync(nameof(NewIncarnationPage), true);
        }

        [RelayCommand]
        public async Task GoToAddCharacterPage()
        {
            await Shell.Current.GoToAsync(nameof(AddCharacterPage), true);
        }
    }
}
