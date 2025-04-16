namespace LCSharpMBG7.Views;

public partial class AmgGlc : ContentPage
{
	public AmgGlc()
	{
		InitializeComponent();
	}
    private async void OnCotizarClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("Cotizador");
    }
}