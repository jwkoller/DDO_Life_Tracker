namespace DDO_Life_Tracker
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(NewIncarnationPage), typeof(NewIncarnationPage));
        }
    }
}
