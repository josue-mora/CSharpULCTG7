using LCSharpMBG7.Code.Models;
using LCSharpMBG7.Code.Services;

namespace LCSharpMBG7.Views
{
    public partial class ReservasAdmin : ContentPage
    {
        public ReservasAdmin() => InitializeComponent();

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var fb   = FirebaseHelper.CreateConnection();
            var all  = await fb.Child("Reservations").OnceAsync<ReservationModel>();
            ReservationsList.ItemsSource = all.Select(x => x.Object).ToList();
        }

        private async void OnCreateClicked(object sender, EventArgs e)
            => await Shell.Current.GoToAsync("ReservaAdminDetail");

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is ReservationModel rm)
            {
                await Shell.Current.GoToAsync($"ReservaAdminDetail?reservationId={rm.Id}");
                ReservationsList.SelectedItem = null;
            }
        }
    }
}
