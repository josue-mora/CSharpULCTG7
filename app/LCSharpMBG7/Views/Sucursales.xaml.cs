namespace LCSharpMBG7.Views;

public partial class Sucursales : ContentPage
{
    public Sucursales()
    {
        InitializeComponent();
        MostrarAlerta();
	}

    private async void MostrarAlerta()
    {
        await DisplayAlert("Informaci�n", "En construcci�n (ULTIMO AVANCE SANTIAGO)", "OK");
    }
}