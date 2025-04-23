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
            var firebase = FirebaseHelper.CreateConnection();
            var all = await firebase
                .Child("Vehicles")
                .OnceAsync<VehicleModel>();
            VehiclesList.ItemsSource = all.Select(x => x.Object).ToList();
        }

        private async void OnCreateClicked(object sender, EventArgs e)
            => await Shell.Current.GoToAsync("VehiculoAdminDetail");

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is VehicleModel vm)
            {
                await Shell.Current.GoToAsync($"VehiculoAdminDetail?vehicleId={vm.Id}");
                VehiclesList.SelectedItem = null;
            }
        }
    }
}
