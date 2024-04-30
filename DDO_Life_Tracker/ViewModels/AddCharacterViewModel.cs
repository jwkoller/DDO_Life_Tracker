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
        private readonly ILogger<AddCharacterViewModel> _logger;
        private IncarnationDBService _dbService;

        [ObservableProperty]
        private Character _newCharacter;

        [ObservableProperty]
        private string _nameEntry = string.Empty;

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

                return true;
            }

            return false;
        }

        public async Task SaveNewCharacter()
        {
            NewCharacter = new Character(NameEntry);
            NewCharacter.Id = await _dbService.SaveCharacterAsync(NewCharacter);
            _logger.LogInformation($"New character name: {NewCharacter.Name} with Id: {NewCharacter.Id}");
        }

        [RelayCommand]
        public async Task GoToNewIncarnationPage()
        {
            Dictionary<string, object> paramData = new Dictionary<string, object> { { "CurrentCharacter", NewCharacter }};
            await Shell.Current.GoToAsync(nameof(AddIncarnationPage), true, paramData);
        }
    }
}
