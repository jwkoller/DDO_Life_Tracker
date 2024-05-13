using CommunityToolkit.Maui.Core.Extensions;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DDO_Life_Tracker.Models;
using DDO_Life_Tracker.Services;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;
using System.Text;

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
        private Incarnation? _activeIncarnation;
        [ObservableProperty]
        private string _classLevel;
        [ObservableProperty]
        private ObservableCollection<IClass> _classesToAdd;
        [ObservableProperty]
        private string _classBtnText = ADD_CLASS_BTN_TEXT;
        [ObservableProperty]
        private string _incarnationBtnText = ADD_INCARNATION_BTN_TEXT;
        [ObservableProperty]
        private bool _deleteIncarnationButtonEnabled = false;

        private IClass? _classBeingEdited;

        private const string ADD_CLASS_BTN_TEXT = "+Add Class";
        private const string UPDATE_CLASS_BTN_TEXT = "Update Class";
        private const string ADD_INCARNATION_BTN_TEXT = "+Add";
        private const string UPDATE_INCARNATION_BTN_TEXT = "Update";

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

        public void ClassButtonHandler()
        {
            if(ClassBtnText == ADD_CLASS_BTN_TEXT)
            {
                AddClass();
            } 
            else
            {
                UpdateClass();
            }
        }

        public async Task IncarnationButtonHandler()
        {
            if(IncarnationBtnText == ADD_INCARNATION_BTN_TEXT)
            {
                await AddIncarnationToCharacter();
            } 
            else
            {
                await UpdateIncarnation();
            }
        }

        public void DeleteClassButtonHandler(IClass classToDelete)
        {
            _classBeingEdited = classToDelete;
            RemoveClassFromIncarnation();
            ResetClassEditor();
        }

        public async Task DeleteIncarnationButtonHandler()
        {
            if(ActiveIncarnation == default)
            {
                throw new Exception("No incarnation selected.");
            }

            CurrentCharacter.RemoveIncarnation(ActiveIncarnation);
            await _dbService.DeleteIncarnation(ActiveIncarnation);
            await SaveCharacter();
            ResetForm();
        }

        public async Task AddIncarnationToCharacter()
        {
            if (ActiveIncarnation == default)
            {
                AddClass();
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

            if (ActiveIncarnation == default)
            {
                throw new Exception("Incarnation not set.");
            }

            CurrentCharacter.AddIncarnation(ActiveIncarnation);
            await SaveCharacter();
            ResetForm();
        }

        public void AddClass()
        {
            if(SelectedClass.Key == default || SelectedRace.Key == default) 
            {
                throw new Exception($"Select both class and race.");
            }

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

            if (ActiveIncarnation == default)
            {
                IRace newRace = Definitions.IdToDDORace(SelectedRace.Key);
                ActiveIncarnation = new Incarnation(CurrentCharacter.Id, newRace, newClass);
                RacesPickerEnabled = false;
            }
            else
            {
                ActiveIncarnation.AddClass(newClass);
            }

            ClassesToAdd.Add(newClass);

            ClassLevel = string.Empty;
            SelectedClass = default;
            ClassBtnText = ADD_CLASS_BTN_TEXT;
        }

        public void SetIncarnationToEdit(Incarnation incarnation)
        {
            ResetClassEditor();
            ResetRaceEditor();
            ActiveIncarnation = (Incarnation)incarnation.Clone();
            ClassesToAdd = ActiveIncarnation.CurrentClassDefinitions.ToObservableCollection();
            SelectedRace = SelectableRaces.First(r => r.Key == ActiveIncarnation.Race.Id);
            IncarnationBtnText = UPDATE_INCARNATION_BTN_TEXT;
            DeleteIncarnationButtonEnabled = true;
        }

        public void SetClassToEdit(IClass classToEdit)
        {
            _classBeingEdited = classToEdit;
            ClassLevel = classToEdit.Level.ToString();
            SelectedClass = SelectableClasses.First(c => c.Key == classToEdit.ClassId);
            ClassBtnText = UPDATE_CLASS_BTN_TEXT;
        }

        public bool RemoveClassFromIncarnation()
        {
            if(_classBeingEdited == default)
            {
                throw new Exception("Select a class to edit");
            }

            if (ActiveIncarnation == default)
            {
                throw new Exception("No incarnation selected.");
            }

            bool classRemoved = ActiveIncarnation.RemoveClass(_classBeingEdited);
            if (classRemoved)
            {
                ClassesToAdd = ActiveIncarnation.CurrentClassDefinitions.ToObservableCollection();
            }

            return classRemoved;
        }

        public void UpdateClass()
        {
            bool oldClassRemoved = RemoveClassFromIncarnation();
            if (oldClassRemoved)
            {
                AddClass();
            }
        }

        public async Task UpdateIncarnation()
        {
            if (ActiveIncarnation == default)
            {
                throw new Exception("No incarnation selected.");
            }

            if(SelectedRace.Key != ActiveIncarnation.Race.Id)
            {
                ActiveIncarnation.Race = Definitions.IdToDDORace(SelectedRace.Key);
            }

            CurrentCharacter.UpdateIncarnation(ActiveIncarnation);
            await SaveCharacter();
            ResetForm();
        }

        public async Task SaveCharacter()
        {
            await _dbService.SaveCharacterAsync(CurrentCharacter);
            CurrentCharacter = await _dbService.GetCharacterByIdAsync(CurrentCharacter.Id);
            _logger.LogInformation($"Character {CurrentCharacter.Name} saved with {CurrentCharacter.NumberOfLives} incarnations");
        }

        public async Task DeleteCharacter()
        {
            await _dbService.DeleteCharacterAsync(CurrentCharacter);
            _logger.LogInformation($"Character {CurrentCharacter.Id} {CurrentCharacter.Name} deleted.");
            ResetForm();
        }

        [RelayCommand]
        public void ResetForm()
        {
            ActiveIncarnation = default;
            IncarnationBtnText = ADD_INCARNATION_BTN_TEXT;
            ClassesToAdd = new ObservableCollection<IClass>();
            DeleteIncarnationButtonEnabled = false;
            ResetRaceEditor();
            ResetClassEditor();
        }

        private void ResetClassEditor()
        {
            _classBeingEdited = default;
            SelectedClass = default;
            ClassLevel = string.Empty;
            ClassBtnText = ADD_CLASS_BTN_TEXT;
        }

        private void ResetRaceEditor()
        {
            SelectedRace = default;
            RacesPickerEnabled = true;
        }
    }
}
