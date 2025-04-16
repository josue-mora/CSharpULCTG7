using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using LCSharpMBG7.Code.Models;
using LCSharpMBG7.Code.Controllers;
using LCSharpMBG7.Code.Logical;

namespace LCSharpMBG7.Views;

public class CarruselAutosViewModel : INotifyPropertyChanged
{
    public ObservableCollection<VehicleModel> VehiculosFiltrados { get; set; } = new();
    public ICommand FiltrarCommand { get; }

    public event PropertyChangedEventHandler PropertyChanged;

    public CarruselAutosViewModel()
    {
        if (State.vehicles == null || State.vehicles.Count == 0)
            new VehicleController().LoadDummyVehicles();

        FiltrarCommand = new Command<string>(FiltrarPorModelo);
        FiltrarPorModelo("Todos");
    }

    private void FiltrarPorModelo(string modelo)
    {
        VehiculosFiltrados.Clear();

        var filtrados = State.vehicles
            .Where(v => modelo == "Todos" || v.GetModel() == modelo)
            .ToList();

        foreach (var v in filtrados)
        {
            if (string.IsNullOrWhiteSpace(v.GetImageCarousel()))
                v.SetImageCarousel("missing_asset.png");

            VehiculosFiltrados.Add(v);
        }

        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(VehiculosFiltrados)));
    }
}
