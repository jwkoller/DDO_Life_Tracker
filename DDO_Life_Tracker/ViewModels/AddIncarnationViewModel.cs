using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DDO_Life_Tracker.Models;
using DDO_Life_Tracker.Services;
using Microsoft.Extensions.Logging;

namespace DDO_Life_Tracker.ViewModels
{
    [QueryProperty("CurrentCharacter", "CurrentCharacter")]
    public partial class AddIncarnationViewModel : ObservableObject
    {
        public Character CurrentCharacter { get; set; }

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
        private Incarnation _newIncarnation;
        [ObservableProperty]
        private string _classLevel;

        private IncarnationDBService _dbService;
        private ILogger<AddIncarnationViewModel> _logger;

        public AddIncarnationViewModel(ILogger<AddIncarnationViewModel> logger, IncarnationDBService dbService)
        {
            _dbService = dbService;
            _logger = logger;
            SelectableClasses = Definitions.AllDdoClassesFormatted.ToList();
            SelectableRaces = Definitions.AllDdoRacesFormatted.ToList();
        }

        [RelayCommand]
        public async Task SaveCharacter()
        {
            try
            {

                CurrentCharacter.AddIncarnation(NewIncarnation);

                await _dbService.SaveCharacterAsync(CurrentCharacter);
                CurrentCharacter = await _dbService.GetCharacterByIdAsync(CurrentCharacter.Id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error saving incarnation: {ex}");
                
            }
        }

        public void AddClassToIncarnation()
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

            ClassLevel = string.Empty;
            SelectedClass = default;
        }
    }
}
