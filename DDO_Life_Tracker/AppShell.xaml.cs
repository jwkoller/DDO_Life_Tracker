using DDO_Life_Tracker.Pages;

namespace DDO_Life_Tracker
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AddIncarnationPage), typeof(AddIncarnationPage));
            Routing.RegisterRoute(nameof(AddCharacterPage), typeof(AddCharacterPage));
        }
    }
}
