using LCSharpMBG7.Code.Controllers;
using LCSharpMBG7.Code.Models;

namespace LCSharpMBG7.Views
{
    [QueryProperty(nameof(ReservationId), "reservationId")]
    public partial class ReservaAdminDetail : ContentPage
    {
        private string? _reservationKey;
        public string? ReservationId { get; set; }

        public ReservaAdminDetail() => InitializeComponent();

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (string.IsNullOrEmpty(ReservationId)) return;

            var r = await ReservationController.GetReservationAsync(ReservationId);
            if (r == null) return;

            _reservationKey            = r.Id;
            vehicleIdEntry.Text        = r.IdVehicle;
            dateReservationEntry.Text  = r.DateReservation;
            dateAppointmentEntry.Text  = r.DateAppointment;
            clientIdEntry.Text         = r.ClientIdCardNumber;
            clientNameEntry.Text       = r.ClientName;
            commentEntry.Text          = r.ClientComment;
            deleteButton.IsVisible     = true;
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            var r = new ReservationModel(
                vehicleIdEntry.Text!,
                dateReservationEntry.Text!,
                dateAppointmentEntry.Text!,
                clientIdEntry.Text!,
                clientNameEntry.Text!,
                commentEntry.Text!);

            if (string.IsNullOrEmpty(_reservationKey))
                _reservationKey = await ReservationController.AddReservationAsync(r);
            else
            {
                r.Id = _reservationKey;
                await ReservationController.UpdateReservationAsync(_reservationKey, r);
            }

            await DisplayAlert("Éxito", "Guardado correctamente.", "OK");
            await Shell.Current.GoToAsync("..");
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            if (_reservationKey == null) return;
            if (!await DisplayAlert("Confirmar", "¿Eliminar reserva?", "Sí", "No")) return;

            await ReservationController.DeleteReservationAsync(_reservationKey);
            await DisplayAlert("Eliminado", "Reserva borrada.", "OK");
            await Shell.Current.GoToAsync("..");
        }
    }
}
