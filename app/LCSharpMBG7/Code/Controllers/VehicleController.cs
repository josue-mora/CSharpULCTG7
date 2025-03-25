using LCSharpMBG7.Code.Models;
using LCSharpMBG7.Code.DB.Dummies;
using LCSharpMBG7.Code.Logical;

namespace LCSharpMBG7.Code.Controllers
{
    public class VehicleController
    {
        public void LoadDummyVehicles()
        {
            List<VehicleModel> vehicleModels = VehicleDbDummies.CreateVehicles();
            State.vehicles = vehicleModels;
        }
    }
}
