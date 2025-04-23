using Microsoft.Maui.ApplicationModel;
//using Microsoft.Maui.Controls.Maps;

namespace LCSharpMBG7.Views;

public partial class Sucursales : ContentPage
{
    public Sucursales()
    {
        InitializeComponent();
        
	}

    private async void OnObtenerDireccionClicked(object sender, EventArgs e)
    {
        string opcion = await DisplayActionSheet("Elegí una sucursal", "Cancelar", null, "Escazú", "Uruca");

        double lat = 0, lng = 0;
        string nombre = "";

        if (opcion == "Escazú")
        {
            nombre = "Sucursal Escazú";
            lat = 9.940783;
            lng = -84.144544;
        }
        else if (opcion == "Uruca")
        {
            nombre = "Sucursal Uruca";
            lat = 9.948048;
            lng = -84.092504;
        }
        else
        {
            return; 
        }

        await Map.OpenAsync(lat, lng, new MapLaunchOptions
        {
            Name = nombre,
            NavigationMode = NavigationMode.None
        });

    }


}