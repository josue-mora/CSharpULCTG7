using System.Diagnostics;
using LCSharpMBG7.Code.Controllers;
using LCSharpMBG7.Code.Logical;
using LCSharpMBG7.Code.DB;
using LCSharpMBG7.Views;

namespace LCSharpMBG7
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            LoadDataAsync();
        }

        private async void LoadDataAsync()
        {
            await InitializeDataLoad.LoadAllData();
        }

        private async void BtnContinuar_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("MainPageMenu");
        }

        private async void LogInAdmin(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("LogInAdmin");
        }

    }
}
