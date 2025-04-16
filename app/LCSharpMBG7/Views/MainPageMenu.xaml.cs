namespace LCSharpMBG7.Views;

public partial class MainPageMenu : ContentPage
{
	public MainPageMenu()
	{
		InitializeComponent();
	}
    private async void OnSaberMasClickedGLE(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("AmgGle");
    }

    private async void OnSaberMasClickedGLC(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("AmgGlc");
    }

    private async void OnSaberMasClickedClaseC(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("AmgClaseC");

    }

    private async void GoToVehiculos(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("CarruselAutosPage");
    }

    private async void GoToCotizador(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("Cotizador");
    }

    private async void GoToSucursales(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("Sucursales");
    }

}