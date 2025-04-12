using LCSharpMBG7.Code.Logical;
using LCSharpMBG7.Code.Controllers;

namespace LCSharpMBG7.Code.DB
{
    public class InitializeDataLoad
    {
        public async static Task LoadAllData()
        {
            // 0 = Dummies
            // 1 = Firebase
            // 2 = Dummies and Firebase
            if (State.DATA_SOURCE == 0 || State.DATA_SOURCE == 1)
            {
                // Vahicles
                await VehicleController.LoadVehiclesAsync();
                // Reservations
                await ReservationController.LoadReservationsAsync();
                // Sells
                await SellController.LoadSellsAsync();
                // Users
                await UserController.LoadUsersAsync();
            }
            else if (State.DATA_SOURCE == 2)
            {
                throw new ArgumentException("Configuration for Dummies + Firebase combined not implemented yet.");
            }
            else
            {
                throw new ArgumentException("Invalid data load configuration.");
            }
        }
    }
}
