using LCSharpMBG7.Code.Validators;
using LCSharpMBG7.Code.Controllers;

namespace LCSharpMBG7.Code.DB
{
    public class InitializeDataLoad
    {
        public async static Task LoadAllData()
        {
            // Validates data source has a valid value.
            StateDataSourceValidator.Validate();

            // Load data.
            // Vehicles
            await VehicleController.LoadVehiclesAsync();
            // Reservations
            await ReservationController.LoadReservationsAsync();
            // Sells
            await SellController.LoadSellsAsync();
            // Users
            await UserController.LoadUsersAsync();
        }
    }
}
