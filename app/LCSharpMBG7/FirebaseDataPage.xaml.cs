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
            var vehicleController = new VehicleController();
            await vehicleController.LoadVehiclesFromFirebaseAsync();
            VehiclesCollectionView.ItemsSource = State.vehicles;

            // Load Reservations from Firebase
            var reservationController = new ReservationController();
            await reservationController.LoadReservationsFromFirebaseAsync();
            ReservationsCollectionView.ItemsSource = State.reservations;

            // Load Sells from Firebase
            var sellController = new SellController();
            await sellController.LoadSellsFromFirebaseAsync();
            SellsCollectionView.ItemsSource = State.sells;

            // Load Users from Firebase
            var userController = new UserController();
            await userController.LoadUsersFromFirebaseAsync();
            UsersCollectionView.ItemsSource = State.users;

            Debug.WriteLine("Data loaded from Firebase for all models.");
        }
    }
}
