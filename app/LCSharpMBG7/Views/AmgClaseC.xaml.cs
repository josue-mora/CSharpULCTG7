namespace LCSharpMBG7.Views;

public partial class AmgClaseC : ContentPage
{
	public AmgClaseC()
	{
		InitializeComponent();
	}

    private async void OnCotizarClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("Cotizador");
    }
}