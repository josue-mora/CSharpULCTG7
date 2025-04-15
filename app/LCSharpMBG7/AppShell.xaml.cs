using LCSharpMBG7.Views;

namespace LCSharpMBG7
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("VehicleDetails", typeof(VehicleDetails));
            Routing.RegisterRoute("FirebaseDataPage", typeof(FirebaseDataPage));
        }
    }
}
