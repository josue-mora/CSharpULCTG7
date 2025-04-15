namespace LCSharpMBG7.Views;

public partial class Vehiculos : ContentPage
{
	public Vehiculos()
	{
		InitializeComponent();
        MostrarAlerta();
    }

    private async void MostrarAlerta()
    {
        await DisplayAlert("Información", "En construcción (JEFFERSON)", "OK");
    }
}