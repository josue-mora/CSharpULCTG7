using LCSharpMBG7.Code.DB;
using LCSharpMBG7.Code.Helpers;

namespace LCSharpMBG7
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            LoadDataAsync();
            DebugMemory.Data();
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
