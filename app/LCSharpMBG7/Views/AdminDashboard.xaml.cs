using LCSharpMBG7.Code.Logical;

namespace LCSharpMBG7.Views;

public partial class AdminDashboard : ContentPage
{
    public AdminDashboard()
    {
        InitializeComponent();
    }

    private async void Button_Clicked_Logout(object sender, EventArgs e)
    {
        State.AdminUserSession = null;
        await Shell.Current.GoToAsync("LogInAdmin");
    }

    protected override async void OnAppearing()
    {
        if (State.AdminUserSession == null)
        {
            NavigateTo(0);
        }
    }


    protected override bool OnBackButtonPressed()
    {
        if (State.AdminUserSession != null)
        {
            NavigateTo(0);
        }
        else
        {
            NavigateTo(1);
        }
        return true;
    }

    private async void NavigateTo(int move_index)
    {
        if (move_index == 0)
        {
            await Shell.Current.GoToAsync("///MainPage");
        }
        if (move_index == 1)
        {
            await Shell.Current.GoToAsync("LogInAdmin");
        }
    }
}