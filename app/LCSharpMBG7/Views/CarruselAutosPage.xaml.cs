using LCSharpMBG7.Code.DB;

namespace LCSharpMBG7.Views;

public partial class CarruselAutosPage : ContentPage
{
	public CarruselAutosPage()
	{
		InitializeComponent();
        LoadDataAsync();
    }

    private async void LoadDataAsync()
    {
        // Load data from data source.
        await InitializeDataLoad.LoadAllData();
    }
}