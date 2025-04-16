namespace LCSharpMBG7.Views;

public partial class Cotizador : ContentPage
{
	public Cotizador()
	{
		InitializeComponent();
        MostrarAlerta();
	}
    private async void MostrarAlerta()
    {
        await DisplayAlert("Información", "En construcción (ULTIMO AVANCE REPARTIR)", "OK");
    }
}