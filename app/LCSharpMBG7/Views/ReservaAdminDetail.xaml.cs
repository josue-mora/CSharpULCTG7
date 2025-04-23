using Firebase.Database.Query;
using LCSharpMBG7.Code.Models;
using LCSharpMBG7.Code.Services;

namespace LCSharpMBG7.Views
{
    [QueryProperty(nameof(ReservationId), "reservationId")]
    public partial class ReservaAdminDetail : ContentPage
    {
        private string? _firebaseKey;
        public string? ReservationId { get; set; }

        public ReservaAdminDetail()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Solo se corre si hay un ID
            if (!string.IsNullOrEmpty(ReservationId))
            {
                var fb = FirebaseHelper.CreateConnection();
                var all = await fb.Child("Reservations").OnceAsync<ReservationModel>();
                var item = all.FirstOrDefault(x => x.Object.Id == ReservationId);
                if (item != null)
                {
                    _firebaseKey = item.Key;
                    var r = item.Object;

                    vehicleIdEntry.Text       = r.IdVehicle;
                    dateReservationEntry.Text = r.DateReservation;
                    dateAppointmentEntry.Text = r.DateAppointment;
                    clientIdEntry.Text        = r.ClientIdCardNumber;
                    clientNameEntry.Text      = r.ClientName;
                    commentEntry.Text         = r.ClientComment;

                    deleteButton.IsVisible    = true;
                }
            }
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            var r = new ReservationModel(
                vehicleIdEntry.Text,
                dateReservationEntry.Text,
                dateAppointmentEntry.Text,
                clientIdEntry.Text,
                clientNameEntry.Text,
                commentEntry.Text);

            var fb = FirebaseHelper.CreateConnection();
            if (string.IsNullOrEmpty(_firebaseKey))
                await fb.Child("Reservations").PostAsync(r);
            else
                await fb.Child("Reservations").Child(_firebaseKey!).PutAsync(r);

            await Shell.Current.GoToAsync("..");
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_firebaseKey))
                return;

            var fb = FirebaseHelper.CreateConnection();
            await fb.Child("Reservations").Child(_firebaseKey).DeleteAsync();
            await Shell.Current.GoToAsync("..");
        }
    }
}
