using LCSharpMBG7.Code.Logical;
using LCSharpMBG7.Code.Models;
using LCSharpMBG7.Code.Services;

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
            VehiclesList.ItemsSource = State.vehicles;
        }

        private async void OnCreateClicked(object sender, EventArgs e)
        {
            State.OnAdminAction = "create_vehicle";
            await Shell.Current.GoToAsync("VehiculoAdminDetail");
        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is VehicleModel vm)
            {
                for (int i = 0; i < State.vehicles.Count; i++)
                {
                    if (State.vehicles[i].Id == vm.Id)
                    {
                        State.SelectedVehicleIndex = i;
                        break;
                    }
                }
                State.OnAdminAction = "edit_vehicle";
                await Shell.Current.GoToAsync($"VehiculoAdminDetail?vehicleId={vm.Id}");
                VehiclesList.SelectedItem = null;
            }
        }
    }
}
