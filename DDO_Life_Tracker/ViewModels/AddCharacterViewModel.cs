using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DDO_Life_Tracker.Models;
using DDO_Life_Tracker.Services;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDO_Life_Tracker.ViewModels
{
    public partial class AddCharacterViewModel : ObservableObject
    {
        [ObservableProperty]
        private Character? _newCharacter;
        [ObservableProperty]
        private string _nameEntry = string.Empty;
        [ObservableProperty]
        private bool _addButtonEnabled = false;
        [ObservableProperty]
        private bool _characterWindowVisible = false;
        [ObservableProperty]
        private Color _buttonBackgroundColor;

        private IncarnationDBService _dbService;
        private readonly ILogger<AddCharacterViewModel> _logger;
        private readonly Color BUTTON_ENABLED_BACKGROUND = Colors.DarkGreen;
        private readonly Color BUTTON_DISABLED_BACKGROUND = Colors.LightGray;

        public AddCharacterViewModel(ILogger<AddCharacterViewModel> logger, IncarnationDBService service)
        {
            _logger = logger;
            _dbService = service;
        }

        public async Task<bool> CheckCharacterNameExists()
        {
            Character? nameCheck = await _dbService.GetCharacterByNameAsync(NameEntry);
            if (nameCheck != null)
            {
                NameEntry = string.Empty;
                AddButtonEnabled = false;
                ButtonBackgroundColor = BUTTON_DISABLED_BACKGROUND;

                return true;
            }

            AddButtonEnabled = true;
            ButtonBackgroundColor = BUTTON_ENABLED_BACKGROUND;

            return false;
        }

        public async Task SaveNewCharacter()
        {
            NewCharacter = new Character(NameEntry);
            NewCharacter.Id = await _dbService.SaveCharacterAsync(NewCharacter);
            CharacterWindowVisible = true;
            _logger.LogInformation($"New character name: {NewCharacter.Name} with Id: {NewCharacter.Id}");
        }

        public void ResetForm()
        {
            NameEntry = string.Empty;
            AddButtonEnabled = false;
            ButtonBackgroundColor = BUTTON_DISABLED_BACKGROUND;
            CharacterWindowVisible= false;
            NewCharacter = default;
        }

        [RelayCommand]
        public async Task GoToNewIncarnationPage()
        {
            if(NewCharacter == default)
            {
                throw new Exception("New character not saved");
            }

            Dictionary<string, object> paramData = new Dictionary<string, object> { { "CurrentCharacter", NewCharacter }};
            await Shell.Current.GoToAsync(nameof(AddIncarnationPage), true, paramData);
            ResetForm();
        }
    }
}
