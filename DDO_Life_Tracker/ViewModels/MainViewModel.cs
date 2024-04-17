using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DDO_Life_Tracker.Models;
using System.Collections.ObjectModel;

namespace DDO_Life_Tracker.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        public MainViewModel() 
        { 
            Incarnations = new ObservableCollection<Incarnation>();
        }

        [ObservableProperty]
        private ObservableCollection<Incarnation> _incarnations;

        [RelayCommand]
        public void AddIncarnation()
        {
            //TEST
            Incarnation newLife = new Incarnation(new Human(), new Monk(12));
            newLife.AddClass(new Fighter(6));
            newLife.AddClass(new Rogue(8));
            Incarnations.Add(newLife);
        }
    }
}
