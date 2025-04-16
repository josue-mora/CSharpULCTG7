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
        await DisplayAlert("Información", "En construcción (ULTIMO AVANCE SANTIAGO)", "OK");
    }
}