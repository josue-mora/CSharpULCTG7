using LCSharpMBG7.Code.Controllers;
using LCSharpMBG7.Code.Logical;

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
                Text = "No hay veh�culos promocionados disponibles.",
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
                Text = "Saber m�s",
                BackgroundColor = Colors.Black,
                TextColor = Colors.White,
                FontAttributes = FontAttributes.Bold,
                CornerRadius = 12,
                WidthRequest = 200,
                HorizontalOptions = LayoutOptions.Center
            };

            // Redirigir seg�n el nombre del veh�culo
            button.Clicked += async (s, e) =>
            {
                int _selectedVehicle = -1;
                for (int i = 0; i < State.vehicles.Count; i++)
                {
                    if (State.vehicles[i].Id == vehicle.Id)
                    {
                        _selectedVehicle = i;
                        break;
                    }
                }
                State.SelectedVehicleIndex = _selectedVehicle;
                await Shell.Current.GoToAsync("VehicleDetails");
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
        await DisplayAlert("Informaci�n", "Para cotizar un veh�culo, seleccione uno de nuestros veh�culos seleccionados o utilize el navegador de veh�culos.", "Ok");
    }

    private async void GoToSucursales(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("Sucursales");
    }

    /*
    private void Button_Clicked_Upload_Data(object sender, EventArgs e)
    {
        // Add copy of data in memory to the database.
        State.DATA_SOURCE = 1;
        for (int i = 0; i < State.vehicles.Count; i++)
        {
            VehicleController.AddVehicleAsync(State.vehicles[i]);
        }
        for (int i = 0; i < State.sells.Count; i++)
        {
            SellController.AddSellAsync(State.sells[i]);
        }
        for (int i = 0; i < State.reservations.Count; i++)
        {
            ReservationController.AddReservationAsync(State.reservations[i]);
        }
        for (int i = 0; i < State.users.Count; i++)
        {
            UserController.AddUserAsync(State.users[i]);
        }
        State.DATA_SOURCE = 0;
    }
    */
}
