using LCSharpMBG7.Code.Controllers;
using LCSharpMBG7.Code.Logical;
using LCSharpMBG7.Code.Models;

namespace LCSharpMBG7.Views
{
    public partial class VehiculosAdmin : ContentPage
    {
        public VehiculosAdmin()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await VehicleController.LoadVehiclesAsync();
            VehiclesList.ItemsSource = null;
            VehiclesList.ItemsSource = State.vehicles;
        }

        private async void OnCreateClicked(object sender, EventArgs e)
        {
            State.OnAdminAction = "create_vehicle";
            await Shell.Current.GoToAsync("VehiculoAdminDetail");
        }

        private async void OnVehicleTapped(object sender, TappedEventArgs e)
        {
            if (sender is Frame frame
                && frame.BindingContext is VehicleModel vm)
            {
                State.SelectedVehicleIndex =
                    State.vehicles.FindIndex(v => v.Id == vm.Id);
                State.OnAdminAction = "edit_vehicle";
                await Shell.Current.GoToAsync(
                    $"VehiculoAdminDetail?vehicleId={vm.Id}");
            }
        }
    }
}
