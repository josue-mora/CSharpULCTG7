namespace LCSharpMBG7.Views;

public partial class AmgGle : ContentPage
{
	public AmgGle()
	{
		InitializeComponent();
	}

    private async void OnCotizarClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("Cotizador");
    }
}