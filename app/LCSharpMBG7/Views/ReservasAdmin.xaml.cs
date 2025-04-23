using LCSharpMBG7.Code.Controllers;
using LCSharpMBG7.Code.Logical;
using LCSharpMBG7.Code.Models;

namespace LCSharpMBG7.Views
{
    public partial class ReservasAdmin : ContentPage
    {
        public ReservasAdmin()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (State.DATA_SOURCE != 0)
                await ReservationController.LoadReservationsAsync();

            ReservationsList.ItemsSource = null;
            ReservationsList.ItemsSource = State.reservations;
        }

        private async void OnCreateClicked(object sender, EventArgs e)
            => await Shell.Current.GoToAsync("ReservaAdminDetail");

        private async void OnReservationTapped(object sender, TappedEventArgs e)
        {
            if (sender is Frame frame
                && frame.BindingContext is ReservationModel rm)
            {
                await Shell.Current.GoToAsync(
                    $"ReservaAdminDetail?reservationId={rm.Id}");
            }
        }
    }
}
