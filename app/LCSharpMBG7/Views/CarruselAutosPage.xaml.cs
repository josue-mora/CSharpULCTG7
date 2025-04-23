using LCSharpMBG7.Code.DB;
using LCSharpMBG7.Code.Helpers;
using LCSharpMBG7.Code.Logical;
using LCSharpMBG7.Code.Models;
using System.Diagnostics;

namespace LCSharpMBG7.Views;

public partial class CarruselAutosPage : ContentPage
{

    private List<VehicleModel> filteredVehicles;
    private int index = 0;

    public CarruselAutosPage()
    {
        InitializeComponent();
        LoadDataAsync();
        DebugMemory.Data();
        // Default all vehicles are filtered.
        filteredVehicles = State.vehicles;
        ProcessView();
    }

    private void ProcessView(int index_action = -2)
    {
        // Validates if there are vehicles.
        if (filteredVehicles.Count == 0) return;

        // Validates if there is only one vehicle so process is cancelled.
        if (filteredVehicles.Count == 1) return;

        // Decrease or lower index of vehicle in filtered vehicles list.
        if (index_action == 0) index++;
        else if (index_action == -1) index--;

        // Validate if index is not out of bounds.
        // If so, it means it circles the list.
        if (index < 0) index = filteredVehicles.Count - 1;
        if (index >= filteredVehicles.Count) index = 0;

        // Process vehicle to be shown.
        VehicleImage.Source = filteredVehicles[index].ImageCarousel;
        VehicleName.Text = filteredVehicles[index].Name;
    }

    private void ProcessFilter(string _filter)
    {
        if (_filter == "all") filteredVehicles = State.vehicles;
        else
        {
            filteredVehicles = State.vehicles.Where(vehicle => vehicle.Model == _filter).ToList();
        }
        ProcessView();
    }

    private async void LoadDataAsync()
    {
        if (State.vehicles == null || State.vehicles.Count == 0)
            await InitializeDataLoad.LoadAllData();
    }

    private void BTN_RIGHT(object sender, EventArgs e)
    {
        ProcessView(-1);
    }

    private void BTN_LEFT(object sender, EventArgs e)
    {
        ProcessView(0);
    }

    private void Button_Clicked_All(object sender, EventArgs e)
    {
        Debug.WriteLine("all");
        ProcessFilter("all");
    }

    private void Button_Clicked_Hatchback(object sender, EventArgs e)
    {
        Debug.WriteLine(Constants.VEHICLE_MODELS[3]);
        ProcessFilter(Constants.VEHICLE_MODELS[3]);
    }

    private void Button_Clicked_Sedan(object sender, EventArgs e)
    {
        Debug.WriteLine(Constants.VEHICLE_MODELS[1]);
        ProcessFilter(Constants.VEHICLE_MODELS[1]);
    }

    private void Button_Clicked_SUV(object sender, EventArgs e)
    {
        Debug.WriteLine(Constants.VEHICLE_MODELS[0]);
        ProcessFilter(Constants.VEHICLE_MODELS[0]);
    }

    private void Button_Clicked_Coupe(object sender, EventArgs e)
    {
        Debug.WriteLine(Constants.VEHICLE_MODELS[2]);
        ProcessFilter(Constants.VEHICLE_MODELS[2]);
    }

    private async void Button_Clicked_Menu_Principal(object sender, EventArgs e)
    {
        //await Task.Delay(400);
        await Shell.Current.GoToAsync("..");
    }
}