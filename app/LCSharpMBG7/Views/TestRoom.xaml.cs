using System.Diagnostics;
using LCSharpMBG7.Code.Controllers;
using LCSharpMBG7.Code.Logical;
using LCSharpMBG7.Code.DB;
using LCSharpMBG7.Views;

namespace LCSharpMBG7;
public partial class TestRoom : ContentPage
{
	public TestRoom()
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
        Navigation.PushAsync(new VehicleDetails());
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

    private async void Button_Clicked_Edit_First_Vehicle_name(object sender, EventArgs e)
    {
        if
        (
            State.vehicles == null ||
            State.vehicles.Count == 0
        )
        {
            await DisplayAlert("Test Failed", "There is no elements in memory. Please, add at least one.", "OK");
            return;
        }
        string new_name = LabelEditFirstVehicleName.Text;
        string key = State.vehicles.First().Id;
        State.vehicles.First().Name = new_name;
        await VehicleController.UpdateVehicleAsync(key, State.vehicles.First());
        await DisplayAlert("Test Complete", "First vehicle in memory name updated", "OK");
    }

    private async void Button_Clicked_Edit_Sell_name(object sender, EventArgs e)
    {
        if
        (
           State.sells == null ||
           State.sells.Count == 0
        )
        {
            await DisplayAlert("Test Failed", "There is no elements in memory. Please, add at least one.", "OK");
            return;
        }
        string new_name = LabelEditSellName.Text;
        string key = State.sells.First().Id;
        State.sells.First().ClientName = new_name;
        await SellController.UpdateSellAsync(key, State.sells.First());
        await DisplayAlert("Test Complete", "First sell in memory client name updated", "OK");
    }

    private async void Button_Clicked_Edit_Reservation_name(object sender, EventArgs e)
    {
        if
        (
           State.reservations == null ||
           State.reservations.Count == 0
        )
        {
            await DisplayAlert("Test Failed", "There is no elements in memory. Please, add at least one.", "OK");
            return;
        }
        string new_name = LabelEditReservationName.Text;
        string key = State.reservations.First().Id;
        State.reservations.First().ClientName = new_name;
        await ReservationController.UpdateReservationAsync(key, State.reservations.First());
        await DisplayAlert("Test Complete", "First reservation in memory client name updated", "OK");
    }

    private async void Button_Clicked_Edit_User_name(object sender, EventArgs e)
    {
        if
        (
           State.users == null ||
           State.users.Count == 0
        )
        {
            await DisplayAlert("Test Failed", "There is no elements in memory. Please, add at least one.", "OK");
            return;
        }
        string new_name = LabelEditUserName.Text;
        string key = State.users.First().Id;
        State.users.First().Name = new_name;
        await UserController.UpdateUserAsync(key, State.users.First());
        await DisplayAlert("Test Complete", "First user in memory client name updated", "OK");
    }

    private async void Button_Clicked_Delete_Vehicle_Index_0(object sender, EventArgs e)
    {
        if (State.vehicles == null || State.vehicles.Count == 0)
        {
            await DisplayAlert("Test Failed", "No vehicles in memory", "OK");
            return;
        }
        string id = State.vehicles.First().Id;
        await VehicleController.DeleteVehicleAsync(id);
        await DisplayAlert("Test Complete", "First vehicle deleted", "OK");
    }

    private async void Button_Clicked_Delete_Sell_Index_0(object sender, EventArgs e)
    {
        if (State.sells == null || State.sells.Count == 0)
        {
            await DisplayAlert("Test Failed", "No sells in memory", "OK");
            return;
        }
        string id = State.sells.First().Id;
        await SellController.DeleteSellAsync(id);
        await DisplayAlert("Test Complete", "First sell deleted", "OK");
    }

    private async void Button_Clicked_Delete_User_Index_0(object sender, EventArgs e)
    {
        if (State.users == null || State.users.Count == 0)
        {
            await DisplayAlert("Test Failed", "No users in memory", "OK");
            return;
        }
        string id = State.users.First().Id;
        await UserController.DeleteUserAsync(id);
        await DisplayAlert("Test Complete", "First user deleted", "OK");
    }

    private async void Button_Clicked_Reservation_Index_0(object sender, EventArgs e)
    {
        if (State.reservations == null || State.reservations.Count == 0)
        {
            await DisplayAlert("Test Failed", "No reservations in memory", "OK");
            return;
        }
        string id = State.reservations.First().Id;
        await ReservationController.DeleteReservationAsync(id);
        await DisplayAlert("Test Complete", "First reservations deleted", "OK");
    }
}