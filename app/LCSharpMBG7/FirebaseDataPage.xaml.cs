using LCSharpMBG7.Code.Controllers;
using LCSharpMBG7.Code.Logical;
using System.Diagnostics;

namespace LCSharpMBG7
{
    public partial class FirebaseDataPage : ContentPage
    {
        public FirebaseDataPage()
        {
            InitializeComponent();
        }

        // When the page appears, load data from Firebase for all models.
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // Load Vehicles from Firebase
            await VehicleController.LoadVehiclesFromFirebaseAsync();
            VehiclesCollectionView.ItemsSource = State.vehicles;

            // Load Reservations from Firebase
            await ReservationController.LoadReservationsFromFirebaseAsync();
            ReservationsCollectionView.ItemsSource = State.reservations;

            // Load Sells from Firebase
            await SellController.LoadSellsFromFirebaseAsync();
            SellsCollectionView.ItemsSource = State.sells;

            // Load Users from Firebase
            await UserController.LoadUsersFromFirebaseAsync();
            UsersCollectionView.ItemsSource = State.users;

            Debug.WriteLine("Data loaded from Firebase for all models.");
        }
    }
}
