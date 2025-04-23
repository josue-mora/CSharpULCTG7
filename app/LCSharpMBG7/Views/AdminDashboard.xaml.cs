using LCSharpMBG7.Code.Logical;

namespace LCSharpMBG7.Views
{
    public partial class AdminDashboard : ContentPage
    {
        public AdminDashboard()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (State.AdminUserSession == null)
            {
                // Si no está logueado, volver al login
                await Shell.Current.GoToAsync("LogInAdmin");
            }
        }

        protected override bool OnBackButtonPressed()
        {
            // Siempre envía al MainPage cuando presionan back
            Shell.Current.GoToAsync("///MainPage");
            return true;
        }

        private async void OnVehiclesClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("VehiculosAdmin");
        }

        private async void OnReservationsClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("ReservasAdmin");
        }

        private async void Button_Clicked_Logout(object sender, EventArgs e)
        {
            State.AdminUserSession = null;
            await Shell.Current.GoToAsync("LogInAdmin");
        }
    }
}
