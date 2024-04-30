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
        private KeyValuePair<int, string> _selectedClassName;
        [ObservableProperty]
        private KeyValuePair<int, string> _selectedRaceName;
        [ObservableProperty]
        private Incarnation _newIncarnation;
        [ObservableProperty]
        private string _classLevel;

        private IncarnationDBService _dbService;
        private ILogger<AddIncarnationViewModel> _logger;
        private List<IClass> incarnationClasses;

        public AddIncarnationViewModel(ILogger<AddIncarnationViewModel> logger, IncarnationDBService dbService)
        {
            _dbService = dbService;
            _logger = logger;
            incarnationClasses = new List<IClass>();
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
            IClass newClass = Definitions.IdToDDOClass(SelectedClassName.Key);
            if (int.TryParse(ClassLevel, out int lvl))
            {
                //TODO add validator to class level input
                newClass.Level = lvl;
            }
            else
            {
                ClassLevel = string.Empty;
                throw new Exception("Invalid class level");
            }

            if (NewIncarnation == default)
            {
                IRace newRace = Definitions.IdToDDORace(SelectedRaceName.Key);
                NewIncarnation = new Incarnation(CurrentCharacter.Id, newRace, newClass);
                RacesPickerEnabled = false;
            } 
            else
            {
                NewIncarnation.AddClass(newClass);
            }

            ClassLevel = string.Empty;
            SelectedClassName = default;
        }
    }
}
