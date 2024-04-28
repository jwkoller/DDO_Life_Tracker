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
        private IncarnationDBService _service;

        [ObservableProperty]
        private Character _newCharacter;

        [ObservableProperty]
        private string _nameEntry = string.Empty;

        public AddCharacterViewModel(ILogger<AddCharacterViewModel> logger, IncarnationDBService service)
        {
            _logger = logger;
            _service = service;
        }

        public async Task<bool> CheckCharacterNameExists()
        {
            Character? nameCheck = await _service.GetCharacterByNameAsync(NameEntry);
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
            NewCharacter.Id = await _service.SaveCharacterAsync(NewCharacter);
            _logger.LogInformation($"New character name: {NewCharacter.Name} with Id: {NewCharacter.Id}");
        }

    }
}
