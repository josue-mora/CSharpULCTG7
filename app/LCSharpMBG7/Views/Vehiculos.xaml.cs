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
        await DisplayAlert("Informaci�n", "En construcci�n (JEFFERSON)", "OK");
    }
}