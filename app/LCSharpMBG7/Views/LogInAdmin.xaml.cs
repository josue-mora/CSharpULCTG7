using LCSharpMBG7.Code.DB;
using LCSharpMBG7.Code.Logical;
using LCSharpMBG7.Code.Models;

namespace LCSharpMBG7.Views;

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

    private async void GoToMainPage()
    {
        await Shell.Current.GoToAsync("///MainPage");
    }

    protected override bool OnBackButtonPressed()
    {
        GoToMainPage();
        return true;
    }

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        if (State.users == null || State.users.Count() == 0)
        {
            await DisplayAlert("Aviso", "No hay usuarios en la base de datos.", "OK");
            return;
        }
        // Looks for the user in memory.
        string input_user = usernameEntry.Text;
        string input_password = passwordEntry.Text;
        int user_index = -1; // -1 means does not exist.
        for (int i = 0; i < State.users.Count(); i++)
        {
            if (State.users[i].Name.ToLower() == input_user.ToLower())
            {
                user_index = i;
                break;
            }
        }
        string message_wrong_process_title = "Credencial incorrecto";
        string message_wrong_process = "El usuario no existe o la contraseña es incorrecta.";
        if (user_index == -1)
        {
            await DisplayAlert(message_wrong_process_title, message_wrong_process, "OK");
            return;
        }
        // User exists. Checks for credentials.
        if (State.users[user_index].Password != input_password)
        {
            await DisplayAlert(message_wrong_process_title, message_wrong_process, "OK");
            return;
        }
        // Reached this point, credentials are correct.
        // Sets admin session in state.
        // Would move to admin panel now.
        State.AdminUserSession = State.users[user_index];
        await Shell.Current.GoToAsync("AdminDashboard");
    }

}