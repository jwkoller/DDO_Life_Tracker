using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DDO_Life_Tracker.Models;
using DDO_Life_Tracker.Services;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;

namespace DDO_Life_Tracker.ViewModels
{
    [QueryProperty("CurrentCharacter", "CurrentCharacter")]
    public partial class AddIncarnationViewModel : ObservableObject
    {
        // QueryProperty
        [ObservableProperty]
        private Character _currentCharacter;

        [ObservableProperty]
        private List<KeyValuePair<int, string>> _selectableClasses;
        [ObservableProperty]
        private List<KeyValuePair<int, string>> _selectableRaces;
        [ObservableProperty]
        private bool _racesPickerEnabled = true;
        [ObservableProperty]
        private KeyValuePair<int, string> _selectedClass;
        [ObservableProperty]
        private KeyValuePair<int, string> _selectedRace;
        [ObservableProperty]
        private Incarnation? _newIncarnation;
        [ObservableProperty]
        private string _classLevel;
        [ObservableProperty]
        private ObservableCollection<IClass> _classesToAdd;

        private IncarnationDBService _dbService;
        private ILogger<AddIncarnationViewModel> _logger;

        public AddIncarnationViewModel(ILogger<AddIncarnationViewModel> logger, IncarnationDBService dbService)
        {
            _dbService = dbService;
            _logger = logger;
            ClassesToAdd = new ObservableCollection<IClass>();
            SelectableClasses = Definitions.AllDdoClassesFormatted.ToList();
            SelectableRaces = Definitions.AllDdoRacesFormatted.ToList();
        }

        public async void AddIncarnationToCharacter()
        {
            if (NewIncarnation == default)
            {
                AddClass();

                if(NewIncarnation == default)
                {
                    throw new Exception("Incarnation not set.");
                }
            } 
            else
            {
                // catch if AddIncarnation btn clicked before adding 2nd+ class
                // does rely on selector being cleared once class added to prevent duplicates
                if (SelectedClass.Key != default)
                {
                    AddClass();
                }
            }

            CurrentCharacter.AddIncarnation(NewIncarnation);
            await SaveCharacter();
            ResetForm();
        }

        public async Task SaveCharacter()
        {
            await _dbService.SaveCharacterAsync(CurrentCharacter);
            CurrentCharacter = await _dbService.GetCharacterByIdAsync(CurrentCharacter.Id);
            _logger.LogInformation($"Character {CurrentCharacter.Name} saved with {CurrentCharacter.NumberOfLives} incarnations");
        }

        public void AddClass()
        {
            IClass newClass = Definitions.IdToDDOClass(SelectedClass.Key);
            if (int.TryParse(ClassLevel, out int lvl))
            {
                //TODO add custom validator to class level input
                newClass.Level = lvl;
            }
            else
            {
                ClassLevel = string.Empty;
                throw new Exception("Invalid class level");
            }

            if (NewIncarnation == default)
            {
                IRace newRace = Definitions.IdToDDORace(SelectedRace.Key);
                NewIncarnation = new Incarnation(CurrentCharacter.Id, newRace, newClass);
                RacesPickerEnabled = false;
            }
            else
            {
                NewIncarnation.AddClass(newClass);
            }

            ClassesToAdd.Add(newClass);
            ClassLevel = string.Empty;
            SelectedClass = default;
        }

        [RelayCommand]
        public void ResetForm()
        {
            SelectedClass = default;
            SelectedRace = default;
            RacesPickerEnabled = true;
            ClassLevel = string.Empty;
            NewIncarnation = default;
            ClassesToAdd = new ObservableCollection<IClass>();
        }
    }
}
