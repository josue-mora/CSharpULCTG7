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
        await DisplayAlert("Informaci�n", "En construcci�n (ULTIMO AVANCE REPARTIR)", "OK");
    }
}