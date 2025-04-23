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
            Routing.RegisterRoute("LogInAdmin", typeof(LogInAdmin));
            Routing.RegisterRoute("MainPageMenu", typeof(Views.MainPageMenu));
            Routing.RegisterRoute("AmgGle", typeof(Views.AmgGle));
            Routing.RegisterRoute("AmgGlc", typeof(Views.AmgGlc));
            Routing.RegisterRoute("AmgClaseC", typeof(Views.AmgClaseC));
            Routing.RegisterRoute("Vehiculos", typeof(Views.Vehiculos));
            Routing.RegisterRoute("Cotizador", typeof(Views.Cotizador));
            Routing.RegisterRoute("Sucursales", typeof(Views.Sucursales));
            Routing.RegisterRoute("AdminDashboard", typeof(Views.AdminDashboard));
            Routing.RegisterRoute("MainPage", typeof(MainPage));
            Routing.RegisterRoute("CarruselAutosPage", typeof(CarruselAutosPage));
            Routing.RegisterRoute("ReservationForm", typeof(Views.ReservationForm));
            Routing.RegisterRoute(nameof(AdminDashboard), typeof(AdminDashboard));
            Routing.RegisterRoute(nameof(VehiculosAdmin), typeof(VehiculosAdmin));
            Routing.RegisterRoute(nameof(VehiculoAdminDetail), typeof(VehiculoAdminDetail));
            Routing.RegisterRoute(nameof(ReservasAdmin), typeof(ReservasAdmin));
            Routing.RegisterRoute(nameof(ReservaAdminDetail), typeof(ReservaAdminDetail));
        }
    }
}
