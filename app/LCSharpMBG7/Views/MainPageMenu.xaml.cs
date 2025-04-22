using LCSharpMBG7.Code.Logical;
using LCSharpMBG7.Code.Models;

namespace LCSharpMBG7.Views;

public partial class MainPageMenu : ContentPage
{
    public MainPageMenu()
    {
        InitializeComponent();
        LoadPromotedVehicles();
    }

    private void LoadPromotedVehicles()

    {
        //FILTRA LISTA STATE.VEH PARA OBTENER SOLO LOS == TRUE
        // (?) SE ASEGURA DE NO LANZAR ERROR SI STATE ES NULL
        var promotedVehicles = State.vehicles?.Where(v => v.Promoted).ToList();

        // VALIDA SI NOO HAY NULL NI VACIOS 
        if (promotedVehicles == null || promotedVehicles.Count == 0)
        {
            // SI NO HAY MUESTRA EL SIGUIENTE MENSAJE
            PromotedVehiclesStack.Children.Add(new Label
            {
                Text = "No hay vehículos promocionados disponibles.",
                FontSize = 18,
                TextColor = Colors.Black,
                HorizontalOptions = LayoutOptions.Center
            });
            return;
        }

        // RECORRE CADA VEHICULO 
        foreach (var vehicle in promotedVehicles)
        {
            //MUESTRA IMAGEN DEL VEHICULO MISMAS PROPIEDADES
            PromotedVehiclesStack.Children.Add(new Image
            {
                Source = vehicle.ImageCarousel,
                HeightRequest = 200,
                Aspect = Aspect.AspectFit
            });

            //MUESTRA EL NOMBRE DEL VEHICULO MISMA FORMA TODOS
            PromotedVehiclesStack.Children.Add(new Label
            {
                Text = vehicle.Name,
                FontSize = 24,
                FontAttributes = FontAttributes.Bold,
                TextColor = Colors.Black,
                HorizontalOptions = LayoutOptions.Center
            });

            //BOTON SABER MAS
            var button = new Button
            {
                Text = "Saber más",
                BackgroundColor = Colors.Black,
                TextColor = Colors.White,
                FontAttributes = FontAttributes.Bold,
                CornerRadius = 12,
                WidthRequest = 200,
                HorizontalOptions = LayoutOptions.Center
            };

            // Redirigir según el nombre del vehículo
            button.Clicked += async (s, e) =>
            {
                //se evalúa el nombre del vehículo y se asocia con una página (Route) registrada
                string route = vehicle.Name switch
                {
                    "GLE SUV" => "AmgGle",
                    "GLC SUV" => "AmgGlc",
                    "Clase C Sedan" => "AmgClaseC",
                    _ => null
                };

                if (route != null)
                    await Shell.Current.GoToAsync(route);
                else
                    await Application.Current.MainPage.DisplayAlert("Ruta no encontrada", $"No hay una página asociada al vehículo '{vehicle.Name}'.", "OK");
            };

            PromotedVehiclesStack.Children.Add(button);
        }
    }

    private async void GoToVehiculos(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("CarruselAutosPage ");
    }

    private async void GoToCotizador(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("Cotizador");
    }

    private async void GoToSucursales(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("Sucursales");
    }
}
