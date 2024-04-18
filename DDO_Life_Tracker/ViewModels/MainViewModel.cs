using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DDO_Life_Tracker.Models;
using MetroLog;
using Microsoft.Extensions.Logging;
using System.Collections.ObjectModel;

namespace DDO_Life_Tracker.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Incarnation> _incarnations;

        private readonly ILogger<MainViewModel> _logger;

        public MainViewModel(ILogger<MainViewModel> logger) 
        { 
            Incarnations = new ObservableCollection<Incarnation>();
            _logger = logger;
        }

        [RelayCommand]
        public void AddIncarnation()
        {
            _logger.LogInformation($"Adding new incarnation");
            //TEST
            Incarnation newLife = new Incarnation(new Human(), new Monk(12));
            newLife.AddClass(new Fighter(6));
            newLife.AddClass(new Rogue(8));
            Incarnations.Add(newLife);
        }
    }
}
