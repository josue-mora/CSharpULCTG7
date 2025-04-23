using LCSharpMBG7.Code.Controllers;
using LCSharpMBG7.Code.DB;
using LCSharpMBG7.Code.Logical;
using LCSharpMBG7.Code.Models;

namespace LCSharpMBG7.Views;

public partial class ReservationForm : ContentPage
{
    public ReservationForm()
    {
        InitializeComponent();
        if (State.DevMode == true)
        {
            LoadDataAsync();
            State.SelectedVehicleIndex = 0;
        }
        SetVehicleData();
    }

    private async void Button_Clicked_Confirmar(object sender, EventArgs e)
    {
        // Validation of client data.
        string[] data = { EntryNombre.Text, EntryCedula.Text, EntryComentarios.Text };
        if (string.IsNullOrEmpty(data[0]))
        {
            await DisplayAlert("Datos faltantes", "Debe ingresar su nombre.", "OK");
            return;
        }
        if (string.IsNullOrEmpty(data[1]))
        {
            await DisplayAlert("Datos faltantes", "Debe ingresar su número de cédula.", "OK");
            return;
        }

        // Creates reservation object.
        ReservationModel reservation = new(
            State.vehicles[State.SelectedVehicleIndex].Id,
            DateFormatter.GetUNIXTimestamp() + "",
            DateFormatter.GetUNIXTimestamp() + "",
            data[0],
            data[1],
            data[2]
        );
        await ReservationController.AddReservationAsync(reservation);
        await DisplayAlert("Realizado", $"Su reserva para el vehículo {State.vehicles[State.SelectedVehicleIndex].Name} ha sido realizada.", "OK");
        ReturnToCarrusel();
    }

    private void SetVehicleData()
    {
        LabelCarTitle.Text = State.vehicles[State.SelectedVehicleIndex].Name;
        ImgCarImage.Source = State.vehicles[State.SelectedVehicleIndex].ImageCarousel;
        LabelModel.Text = State.vehicles[State.SelectedVehicleIndex].Model;
        LabelName.Text = State.vehicles[State.SelectedVehicleIndex].Name;
        LabelYear.Text = State.vehicles[State.SelectedVehicleIndex].Year + "";
    }

    private async void LoadDataAsync()
    {
        await InitializeDataLoad.LoadAllData();
    }

    private async void ReturnToCarrusel()
    {
        if (State.DevMode == true)
        {
            await DisplayAlert("Logic error", "You are in ReservationForm DEV MODE. Exit Dev Mode for safe page navigation", "Ok");
            return;
        }
        await Shell.Current.GoToAsync("..");
    }
}
