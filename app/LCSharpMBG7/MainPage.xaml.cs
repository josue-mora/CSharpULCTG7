using System.Diagnostics;
using LCSharpMBG7.Code.Controllers;
using LCSharpMBG7.Code.Logical;

namespace LCSharpMBG7
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();

            // Dummy data tests (displaying debug output).
            VehicleController.LoadDummyVehicles();
            Debug.WriteLine("Dummy Vehicles:");
            if (State.vehicles != null)
            {
                foreach (var vehicle in State.vehicles)
                    Debug.WriteLine(vehicle.ToString());
            }

            var userController = new UserController();
            userController.LoadDummyUsers();
            Debug.WriteLine("Dummy Users:");
            if (State.users != null)
            {
                foreach (var user in State.users)
                    Debug.WriteLine(user.ToString());
            }

            SellController.LoadDummySells();
            Debug.WriteLine("Dummy Sells:");
            if (State.sells != null)
            {
                foreach (var sell in State.sells)
                    Debug.WriteLine(sell.ToString());
            }

            ReservationController.LoadDummyReservations();
            Debug.WriteLine("Dummy Reservations:");
            if (State.reservations != null)
            {
                foreach (var res in State.reservations)
                    Debug.WriteLine(res.ToString());
            }

            // Testing the date formatter.
            string unixDate = DateFormatter.GetUNIXTimestamp().ToString();
            Debug.WriteLine("Unix Date: " + unixDate);
            Debug.WriteLine("Formatted Date: " + DateFormatter.FormatUNIXToDate(unixDate));
        }


        // Handle the Firebase test button click.
        private async void OnTestFirebaseConnectionClicked(object sender, EventArgs e)
        {
            FirebaseTestController testController = new FirebaseTestController();
            await testController.TestAllModelsFirebaseAsync();
            await DisplayAlert("Test Complete", "Test data for all models has been inserted. Check Firebase console.", "OK");
        }

        // New event handler for navigating to the VehiclesPage.
        private async void OnViewVehiclesClicked(object sender, EventArgs e)
        {
            // Navigate to the VehiclesPage.
            await Navigation.PushAsync(new FirebaseDataPage());
        }
    }
}
