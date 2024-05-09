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
        [ObservableProperty]
        private bool _loadingSpinnerActive = false;

        private IncarnationDBService _service;
        private readonly ILogger<MainViewModel> _logger;
        private Character? _focusedCharacter;

        public MainViewModel(ILogger<MainViewModel> logger, IncarnationDBService service) 
        { 
            Characters = new ObservableCollection<Character>();
            _logger = logger;
            _service = service;
        }

        public async Task DeleteCharacter(Character character)
        {
            LoadingSpinnerActive = true;

            await _service.DeleteCharacterAsync(character);
            _logger.LogInformation($"Character {character.Id} {character.Name} deleted.");
            await LoadCharacters();

            LoadingSpinnerActive = false;
        }

        public async Task LoadCharacters()
        {
            LoadingSpinnerActive = true;

            // reset list since .Clear() will keep empty elements in the CollectionsView
            Characters = new ObservableCollection<Character>();
            List<Character> chars = await _service.GetCharactersAsync();
            chars.ForEach(c => Characters.Add(c));

            LoadingSpinnerActive = false;
        }

        [RelayCommand]
        public void SetFocusedCharacter(Character character)
        {
            _focusedCharacter = character;
        }

        public async Task GoToAddIncarnationPage()
        {
            if(_focusedCharacter == default)
            {
                throw new Exception("No Character selected");
            }

            Dictionary<string, object> paramData = new Dictionary<string, object> { { "CurrentCharacter", _focusedCharacter } };
            await Shell.Current.GoToAsync(nameof(AddIncarnationPage), true, paramData);
        }

        [RelayCommand]
        public async Task GoToAddCharacterPage()
        {
            await Shell.Current.GoToAsync(nameof(AddCharacterPage), true);
        }
    }
}
