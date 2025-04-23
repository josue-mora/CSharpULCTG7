using LCSharpMBG7.Code.Logical;
using LCSharpMBG7.Code.Models;
using LCSharpMBG7.Code.Services;


namespace LCSharpMBG7.Views
{
    public partial class LogInAdmin : ContentPage
    {
        public LogInAdmin()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            if (State.AdminUserSession != null)
            {
                await Task.Delay(400);
                await Shell.Current.GoToAsync("AdminDashboard");
            }
        }

        protected override bool OnBackButtonPressed()
        {
            Shell.Current.GoToAsync("///MainPage");
            return true;
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            var email = usernameEntry.Text?.Trim();
            var password = passwordEntry.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Error", "Correo y contraseña son requeridos.", "OK");
                return;
            }

            try
            {
                var firebase = FirebaseHelper.CreateConnection();

                // Usa "Users" con mayúscula
                var allUsers = await firebase
                    .Child("Users")
                    .OnceAsync<UserModel>();

                // Depuración: ¿cuántos nodos trajiste?
                System.Diagnostics.Debug.WriteLine($"Firebase: encontré {allUsers.Count} usuarios.");

                // Filtramos localmente
                var match = allUsers
                    .Select(u => u.Object)
                    .FirstOrDefault(u =>
                        u.Email?.Trim().Equals(email, StringComparison.OrdinalIgnoreCase) == true
                        && u.Password == password);

                if (match == null)
                {
                    await DisplayAlert(
                        "Credencial incorrecta",
                        "El correo o la contraseña son incorrectos.",
                        "OK");
                    return;
                }

                State.AdminUserSession = match;
                await Shell.Current.GoToAsync("AdminDashboard");
            }
            catch (Exception ex)
            {
                await DisplayAlert(
                    "Error de conexión",
                    $"No se pudo conectar a Firebase:\n{ex.Message}",
                    "OK");
            }
        }
    }
}
