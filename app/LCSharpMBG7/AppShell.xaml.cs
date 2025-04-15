using Microsoft.Maui.Controls;
using LCSharpMBG7.Views;


namespace LCSharpMBG7
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("LogInAdmin", typeof(LogInAdmin));
            Routing.RegisterRoute("MainPageMenu", typeof(Views.MainPageMenu));
            Routing.RegisterRoute("AmgGle", typeof(Views.AmgGle));
            Routing.RegisterRoute("AmgGlc", typeof(Views.AmgGlc));
            Routing.RegisterRoute("AmgClaseC", typeof(Views.AmgClaseC));
            Routing.RegisterRoute("Vehiculos", typeof(Views.Vehiculos));
            Routing.RegisterRoute("Cotizador", typeof(Views.Cotizador));
            Routing.RegisterRoute("Sucursales", typeof(Views.Sucursales));


        }
    }
}
