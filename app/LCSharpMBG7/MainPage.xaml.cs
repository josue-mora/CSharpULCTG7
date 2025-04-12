using System.Diagnostics;
using LCSharpMBG7.Code.Controllers;
using LCSharpMBG7.Code.Logical;
using LCSharpMBG7.Code.DB;

namespace LCSharpMBG7
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            LoadDataAsync();

            // Console printing of items.
            // Note: currently not working with Firebase incoming data.
            Debug.WriteLine("Dummy Vehicles:");
            if (State.vehicles != null)
            {
                foreach (var vehicle in State.vehicles)
                    Debug.WriteLine(vehicle.ToString());
            }

            Debug.WriteLine("Dummy Users:");
            if (State.users != null)
            {
                foreach (var user in State.users)
                    Debug.WriteLine(user.ToString());
            }

            Debug.WriteLine("Dummy Sells:");
            if (State.sells != null)
            {
                foreach (var sell in State.sells)
                    Debug.WriteLine(sell.ToString());
            }

            Debug.WriteLine("Dummy Reservations:");
            if (State.reservations != null)
            {
                foreach (var res in State.reservations)
                    Debug.WriteLine(res.ToString());
            }

            // Testing date formatter.
            string unixDate = DateFormatter.GetUNIXTimestamp().ToString();
            Debug.WriteLine("Unix Date: " + unixDate);
            Debug.WriteLine("Formatted Date: " + DateFormatter.FormatUNIXToDate(unixDate));
        }


        private async void LoadDataAsync()
        {
            // Load data from data source.
            await InitializeDataLoad.LoadAllData();
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
